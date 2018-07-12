using System;
using System.Linq;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Logging;
using EPMLiveCore.ListDefinitions;
using EPMLiveCore.PfeData;

using Microsoft.SharePoint;

namespace EPMLiveCore
{
    /// <summary>
    /// Implements Archive / Restore project functionality.
    /// </summary>
    public class ProjectArchiverService
    {
        public const string ArchivedColumn = "EPM_Archived";

        public const string ArchivedColumnTitle = "Is Archived";

        public const string TimesheetColumn = "Timesheet";

        public const string ArchivedTimesheetColumn = "EPM_Archived_Timesheet";

        private const string ArchiveProjectAction = "Archive";

        private const string RestoreProjectAction = "Restore";

        private ILogger _log;

        /// <summary>
        /// Archives the project.
        /// </summary>
        /// <param name="listItem">The list item.</param>
        public void ArchiveProject(SPListItem listItem)
        {
            UpdateProjectStatus(listItem, true);
        }

        /// <summary>
        /// Restores the project.
        /// </summary>
        /// <param name="listItem">The list item.</param>
        public void RestoreProject(SPListItem listItem)
        {
            UpdateProjectStatus(listItem, false);
        }

        /// <summary>
        /// Determines whether the specified project is archived.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <param name="webId">The web identifier.</param>
        /// <param name="listId">The list identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>
        ///   <c>true</c> if the specified project is archived; otherwise, <c>false</c>.
        /// </returns>
        public bool IsArchived(Guid siteId, Guid webId, Guid listId, int itemId)
        {
            var result = false;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(
                    () =>
                        {
                            using (var site = new SPSite(siteId))
                            {
                                using (var web = site.OpenWeb(webId))
                                {
                                    try
                                    {
                                        var list = web.Lists.GetList(listId, true);
                                        if (!list.Fields.ContainsField(ArchivedColumn))
                                        {
                                            return;
                                        }

                                        var item = list.GetItemById(itemId);
                                        var value = item[ArchivedColumn];
                                        result = (bool?)value ?? false;
                                    }
                                    catch (Exception ex)
                                    {
                                        LogError(web, ex);
                                    }
                                }
                            }
                        });
            }
            catch (Exception ex)
            {
                TryLogError(ex);
            }

            return result;
        }

        /// <summary>
        /// Updates the project status.
        /// </summary>
        /// <param name="projectListItem">The project list item.</param>
        /// <param name="status">if set to <c>true</c> project will be archived, otherwise restored.</param>
        private void UpdateProjectStatus(SPListItem projectListItem, bool status)
        {
            if (projectListItem == null)
            {
                throw new ArgumentNullException();
            }

            var web = projectListItem.Web;
            web.AllowUnsafeUpdates = true;

            try
            {
                var action = status ? ArchiveProjectAction : RestoreProjectAction;
                LogMessage(web, $"Updating project '{projectListItem.ID}' - Action: '{action}'", LogKind.Info);

                projectListItem[ArchivedColumn] = status;
                projectListItem.Update();

                // when associated lists configured - move to archive all of them
                SPSecurity.RunWithElevatedPrivileges(
                    () =>
                        {
                            using (var elevatedSite = new SPSite(web.Site.ID))
                            {
                                using (var elevatedWeb = elevatedSite.OpenWeb(web.ID))
                                {
                                    elevatedWeb.AllowUnsafeUpdates = true;

                                    if (PfeData.ConnectionProvider.AllowDatabaseConnections(elevatedWeb))
                                    {
                                        var pfeProjectRepository = new ProjectRepository();
                                        pfeProjectRepository.UpdateArchivedStatus(web, projectListItem.ParentList.ID, projectListItem.ID, status);
                                    }

                                    try
                                    {
                                        var elevatedProjectList = elevatedWeb.Lists.GetList(
                                            projectListItem.ParentList.ID,
                                            false);
                                        var settings = ListCommands.GetGridGanttSettings(elevatedProjectList);
                                        if (settings.AssociatedItems)
                                        {
                                            var associated = ListCommands.GetAssociatedLists(elevatedProjectList)
                                                .Cast<AssociatedListInfo>().ToArray();
                                            UpdateAssociatedLists(elevatedWeb, projectListItem.ID, status, associated);
                                        }
                                    }
                                    finally
                                    {
                                        elevatedWeb.AllowUnsafeUpdates = false;
                                    }
                                }
                            }
                        });
            }
            catch (Exception ex)
            {
                LogError(web, ex);
                throw;
            }
            finally
            {
                web.AllowUnsafeUpdates = false;
            }
        }

        /// <summary>
        /// Updates the associated lists.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="archived">if set to <c>true</c> associated lists will be archived, otherwise restored.</param>
        /// <param name="associatedLists">The associated lists.</param>
        private void UpdateAssociatedLists(
            SPWeb web,
            int projectId,
            bool archived,
            AssociatedListInfo[] associatedLists)
        {
            foreach (var associatedListInfo in associatedLists)
            {
                var associatedList = web.Lists.GetList(associatedListInfo.ListId, true);
                var lookupField = associatedListInfo.LinkedField;

                // verify list requirements before proceed with the update
                if (!associatedList.Fields.ContainsField(ArchivedColumn)
                    || !associatedList.Fields.ContainsField(lookupField))
                {
                    // no Archived column or no lookup field in associated list - possibly wrong configuration - skip the list with log message.
                    LogMessage(
                        web,
                        $"List '{associatedListInfo.Title}' with id '{associatedListInfo.ListId}' does not contain required lookup '{lookupField}' or archived '{ArchivedColumn}' columns",
                        LogKind.Warning);
                    continue;
                }

                // by default we do not try update Timesheet column
                var updateTimesheetColumn = false;

                // except for Task center if it contains Timesheet column
                if ((int)associatedList.BaseTemplate == (int)EPMLiveLists.TaskCenter)
                {
                    updateTimesheetColumn = associatedList.Fields.ContainsField(TimesheetColumn);
                    if (updateTimesheetColumn && !associatedList.Fields.ContainsField(ArchivedTimesheetColumn))
                    {
                        // no backup column for Timesheet in task list - possibly wrong configuration - skip the list with log message.
                        LogMessage(
                            web,
                            $"List '{associatedListInfo.Title}' with id '{associatedListInfo.ListId}' does not contain required '{ArchivedTimesheetColumn}' column",
                            LogKind.Warning);
                        continue;
                    }
                }

                // done with requirements check, proceed with list data
                var query = new SPQuery
                                {
                                    Query =
                                        $"<Where><Eq><FieldRef Name='{lookupField}' LookupId='TRUE'/><Value Type='Lookup'>{projectId}</Value></Eq></Where>"
                                };

                var items = associatedList.GetItems(query);
                foreach (SPListItem item in items)
                {
                    var archivedChanged = item[ArchivedColumn] == null || (bool)item[ArchivedColumn] != archived;
                    if (!archivedChanged)
                    {
                        // skip if status not changed
                        continue;
                    }

                    UpdateAssociatedListItem(item, archived, updateTimesheetColumn);
                }
            }
        }

        /// <summary>
        /// Updates the associated list item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="value">if set to <c>true</c> item will be archived, otherwise restored.</param>
        /// <param name="updateTimesheet">if set to <c>true</c> Timesheet column value will be set to <c>false</c> or its original value,
        /// otherwise no changes will be performed.</param>
        private void UpdateAssociatedListItem(SPListItem item, bool value, bool updateTimesheet)
        {
            item[ArchivedColumn] = value;

            if (updateTimesheet)
            {
                // explicitly for Tasks by specification we need mark item as "No Timesheet"
                if (value)
                {
                    // when moving to archive, store backup value of Timesheet column and set original Timesheet column value to false
                    item[ArchivedTimesheetColumn] = item[TimesheetColumn];
                    item[TimesheetColumn] = false;
                }
                else
                {
                    item[TimesheetColumn] = item[ArchivedTimesheetColumn];
                }
            }

            item.Update();
        }

        private void TryLogError(Exception ex)
        {
            if (SPContext.Current?.Web != null)
            {
                LogError(SPContext.Current.Web, ex);
            }
        }

        private void LogError(SPWeb web, Exception ex)
        {
            try
            {
                EnsureLogInstance(web);
                _log.LogMessage(ex, nameof(ProjectArchiverService));
            }
            catch
            {
                // leaving logging failures ignored in this context, assume logging framework is stable enough
            }
        }

        private void LogMessage(SPWeb web, string message, LogKind level)
        {
            try
            {
                EnsureLogInstance(web);
                _log.LogMessage(message, nameof(ProjectArchiverService), level);
            }
            catch
            {
                // leaving logging failures ignored in this context, assume logging framework is stable enough
            }
        }

        private void EnsureLogInstance(SPWeb web)
        {
            if (_log == null)
            {
                _log = new Logger(web);
            }
        }
    }
}