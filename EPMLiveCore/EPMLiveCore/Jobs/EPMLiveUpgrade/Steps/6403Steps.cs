using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using EPMLiveCore.ListDefinitions;

using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V640, Order = 3, Description = "Adding archive / restore project feature to SharePoint")]
    internal class ProjectArchiveRestoreSharePointInstall64 : UpgradeStep
    {
        private const string ArchivedProjectsViewName = "Archived Projects";
        private const string ArchivedRecordsViewName = "Archived Items";

        private const string ViewFilterArchived = "<Eq><FieldRef Name=\"" + ProjectArchiverService.ArchivedColumn
                                                                          + "\" /><Value Type=\"Boolean\">1</Value></Eq>";

        private const string ViewFilterNonArchived = "<Neq><FieldRef Name=\"" + ProjectArchiverService.ArchivedColumn
                                                                              + "\" /><Value Type=\"Boolean\">1</Value></Neq>";

        private const string ViewFilterJoinTemplate = "<And>{0}{1}</And>";
        private const string DefaultTargetProjectCenterList = "Project Center";
        private const string TargetProjectCenterConfigSetting = "ProjectArchvierTargetLists";
        private const char ConfigSettingSeparator = ',';
        private readonly List<Guid> _processedLists;


        public ProjectArchiveRestoreSharePointInstall64(SPWeb spWeb, bool isPfeSite)
            : base(spWeb, isPfeSite)
        {
            _processedLists = new List<Guid>();
        }

        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);
                SPSecurity.RunWithElevatedPrivileges(UpgradeSharePoint);
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 1);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Upgrades the SharePoint lists and views.
        /// Perform following updates: 
        ///  * Determines project lists to proceed
        ///  * Adds archived column to each project list
        ///  * For each project list updates existing views to filter data by Archived column
        ///  * For each project list adds new view to show Archived items
        ///  * For each project list process all associated lists
        /// </summary>
        private void UpgradeSharePoint()
        {
            using (var elevatedSite = new SPSite(Web.Site.ID))
            {
                using (var elevatedWeb = elevatedSite.OpenWeb(Web.ID))
                {
                    elevatedWeb.AllowUnsafeUpdates = true;
                    try
                    {
                        // try get lists to process and if could not get then log error
                        var lists = GetTargetProjectLists(elevatedWeb);
                        if (lists.Length == 0)
                        {
                            LogMessage($"Could not find default list {DefaultTargetProjectCenterList}. Skipped.", MessageKind.SKIPPED, 2);
                            LogMessage(
                                $"Could not find project list configuration {TargetProjectCenterConfigSetting}. Skipped.",
                                MessageKind.SKIPPED,
                                2);
                        }
                        else
                        {
                            foreach (var listId in lists)
                            {
                                // gets the list for further processing
                                var projectCenterList = elevatedWeb.Lists.GetList(listId, true);
                                LogMessage($"About to update {projectCenterList.Title} list.", 2);

                                // adds new column and uses it for each view to filter data
                                AddArchivedColumn(projectCenterList, 2);
                                ProcessListViews(projectCenterList, ArchivedProjectsViewName, 2);

                                // we have _processedLists variable to remember all lists which 
                                // we already updated to avoid double checking of same list 
                                // when will process associated lists
                                _processedLists.Add(projectCenterList.ID);

                                // go for each associated list and do similar steps as above
                                ProcessAssociatedLists(elevatedWeb, projectCenterList);
                            }
                        }
                    }
                    finally
                    {
                        elevatedWeb.AllowUnsafeUpdates = false;
                    }
                }
            }
        }

        /// <summary>
        /// Processes all associated lists.
        /// </summary>
        /// <param name="elevatedWeb">The elevated web.</param>
        /// <param name="baseList">The base projects list.</param>
        private void ProcessAssociatedLists(SPWeb elevatedWeb, SPList baseList)
        {
            var associated = ListCommands.GetAssociatedLists(baseList).Cast<AssociatedListInfo>().ToArray();
            if (associated.Length > 0)
            {
                LogMessage($"Updating associated lists for {baseList.Title}.", 2);
                foreach (var associatedListInfo in associated)
                {
                    UpdateAssociatedList(elevatedWeb, associatedListInfo, 3);
                }
            }
            else
            {
                LogMessage($"Associated lists are not configured for list {baseList.Title}. Skipped.", MessageKind.SKIPPED, 2);
            }
        }

        /// <summary>
        /// Updates the associated list.
        /// Perform following updates: 
        ///  * Adds archived column
        ///  * Explicitly for task center adds Timesheet backup column
        ///  * Updates existing views to filter data by Archived column
        ///  * Adds new view to show Archived items
        /// </summary>
        /// <param name="elevatedWeb">The elevated web.</param>
        /// <param name="associatedListInfo">The associated list information.</param>
        /// <param name="level">The logging level.</param>
        private void UpdateAssociatedList(SPWeb elevatedWeb, AssociatedListInfo associatedListInfo, int level)
        {
            try
            {
                if (!_processedLists.Contains(associatedListInfo.ListId))
                {
                    LogMessage($"About to update {associatedListInfo.Title} list.", level);
                    var associatedList = elevatedWeb.Lists.GetList(associatedListInfo.ListId, true);
                    AddArchivedColumn(associatedList, level);

                    if ((int)associatedList.BaseTemplate == (int)EPMLiveLists.TaskCenter)
                    {
                        AddArchivedTimesheetColumn(associatedList, level);
                    }

                    ProcessListViews(associatedList, ArchivedRecordsViewName, level);
                    _processedLists.Add(associatedList.ID);
                }
            }
            catch (Exception ex)
            {
                LogMessage(
                    $"Could not process associated list '{associatedListInfo.Title} with id {associatedListInfo.ListId}'.",
                    MessageKind.FAILURE,
                    3);
                LogMessage(ex.Message, MessageKind.FAILURE, 3);
            }
        }

        private Guid[] GetTargetProjectLists(SPWeb elevatedWeb)
        {
            var projectListIds = new List<Guid>();
            var projectListNamesCsv = DefaultTargetProjectCenterList;
            try
            {
                var setting = elevatedWeb.AllProperties["TargetProjectCenterConfigSetting"];
                if (!string.IsNullOrWhiteSpace(setting?.ToString()))
                {
                    projectListNamesCsv = setting.ToString();
                }
            }
            catch
            {
                // no setting, will use default list name
            }

            foreach (var projectListName in projectListNamesCsv.Split(ConfigSettingSeparator))
            {
                var list = elevatedWeb.Lists.TryGetList(projectListName);
                if (list != null)
                {
                    projectListIds.Add(list.ID);
                }
            }

            return projectListIds.ToArray();
        }

        private void ProcessListViews(SPList list, string archivedViewName, int level)
        {
            UpdateExistingListViews(list, level);
            CreateViewForArchivedRecords(list, archivedViewName, level);
        }

        private void UpdateExistingListViews(SPList list, int level)
        {
            LogMessage($"About to update {list.Title} views.", level);
            var column = ProjectArchiverService.ArchivedColumn;
            var views = GetAllViews(list);
            foreach (var viewId in views)
            {
                var view = list.GetView(viewId);
                try
                {
                    var query = view.Query;

                    var xml = new XmlDocument();
                    xml.LoadXml("<Query>" + (query ?? string.Empty) + "</Query>");
                    var queryNode = xml.FirstChild;
                    var whereNode = xml.SelectSingleNode("//Where");
                    if (whereNode == null)
                    {
                        whereNode = xml.CreateElement("Where");
                        whereNode.InnerXml = ViewFilterNonArchived;
                        queryNode.AppendChild(whereNode);
                    }
                    else if (!whereNode.InnerXml.Contains(column))
                    {
                        whereNode.InnerXml = string.Format(ViewFilterJoinTemplate, whereNode.InnerXml, ViewFilterNonArchived);
                    }
                    else
                    {
                        LogMessage($"View {view.Title} already have filter by {column} column.", MessageKind.SKIPPED, level + 1);
                        continue;
                    }

                    view.Query = queryNode.InnerXml;
                    view.Update();

                    LogMessage($"Updated view {view.Title} to filter values by {column} column.", MessageKind.SUCCESS, level + 1);
                }
                catch (Exception ex)
                {
                    LogMessage($"Could not update view '{view.Title} for list {list.Title}'.", MessageKind.FAILURE, level + 1);
                    LogMessage(ex.Message, MessageKind.FAILURE, level + 1);
                }
            }

            LogMessage($"All views for {list.Title} updated.", MessageKind.SUCCESS, level);
        }

        private void CreateViewForArchivedRecords(SPList list, string viewName, int level)
        {
            if (list.Views.Count <= 0)
            {
                return;
            }

            try
            {
                if (ViewExists(list, viewName))
                {
                    LogMessage($"View '{viewName}' already exists in list {list.Title}.", MessageKind.SKIPPED, level);
                    return;
                }

                var defaultView = list.DefaultView ?? list.Views[0];
                var newView = defaultView.Clone(viewName, defaultView.RowLimit, defaultView.Paged, false);
                newView.Query = newView.Query.Replace(ViewFilterNonArchived, ViewFilterArchived);
                newView.Update();

                LogMessage($"Created view {viewName} for list {list.Title}.", MessageKind.SUCCESS, level);
            }
            catch (Exception ex)
            {
                LogMessage($"Could not create view '{viewName} for list {list.Title}'.", MessageKind.FAILURE, level);
                LogMessage(ex.Message, MessageKind.FAILURE, level + 1);
            }
        }

        private bool ViewExists(SPList list, string viewName)
        {
            try
            {
                var view = list.Views[viewName];
                return view != null;
            }
            catch
            {
                return false;
            }
        }

        private Guid[] GetAllViews(SPList list)
        {
            var views = new List<Guid>();
            foreach (SPView view in list.Views)
            {
                views.Add(view.ID);
            }

            return views.ToArray();
        }

        private bool AddColumn(SPList list, string internalName, string title, bool visibleToEndUser, int level)
        {
            if (list.Fields.ContainsField(internalName))
            {
                LogMessage($"Column '{internalName}' already exists in list {list.Title}.", MessageKind.SKIPPED, level);
                return false;
            }

            var field = list.Fields.CreateNewField(SPFieldType.Boolean.ToString(), internalName);
            list.Fields.Add(field);
            list.Update();

            field = list.Fields.GetFieldByInternalName(internalName);
            field.Title = title;
            field.ShowInDisplayForm = visibleToEndUser;
            field.ShowInListSettings = visibleToEndUser;
            field.ShowInEditForm = false;
            field.ShowInNewForm = false;
            field.DefaultValue = "0";
            field.Update();

            LogMessage($"Column '{internalName}' added to list {list.Title}.", MessageKind.SUCCESS, level);
            return true;
        }

        private void AddArchivedColumn(SPList list, int level)
        {
            var internalName = ProjectArchiverService.ArchivedColumn;
            var title = ProjectArchiverService.ArchivedColumnTitle;

            AddColumn(list, internalName, title, true, level);
        }

        private void AddArchivedTimesheetColumn(SPList list, int level)
        {
            var internalName = ProjectArchiverService.ArchivedTimesheetColumn;
            AddColumn(list, internalName, internalName, false, level);
        }
    }
}