using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

using EPMLiveCore.ListDefinitions;

using Microsoft.SharePoint;

namespace EPMLiveCore.API.ProjectArchiver
{
    public class ProjectArchiverSetupService : IProjectArchiverSetupService
    {
        private const string ArchivedProjectsViewName = "Archived Projects";

        private const string ArchivedRecordsViewName = "Archived Items";

        private const string ViewFilterArchived = "<Eq><FieldRef Name=\"" + ProjectArchiverService.ArchivedColumn
                                                                          + "\" /><Value Type=\"Boolean\">1</Value></Eq>";

        private const string ViewFilterNonArchived = "<Neq><FieldRef Name=\"" + ProjectArchiverService.ArchivedColumn
                                                                              + "\" /><Value Type=\"Boolean\">1</Value></Neq>";

        private const string ViewFilterJoinTemplate = "<And>{0}{1}</And>";

        private const string DefaultTargetProjectCenterList = "Project Center";

        private const string TargetProjectCenterConfigSetting = "ProjectArchiverTargetLists";

        private const char ConfigSettingSeparator = ',';

        private readonly List<Guid> _processedLists;

        private readonly int _rootLogScope;

        public ProjectArchiverSetupService()
        {
            _processedLists = new List<Guid>();
            _rootLogScope = 0;
        }

        public ProjectArchiverSetupService(int logScope)
        {
            _processedLists = new List<Guid>();
            _rootLogScope = logScope;
        }

        /// <summary>
        /// Occurs on log event.
        /// </summary>
        public event EventHandler<ProjectArchiverSetupServiceLogEventArgs> LogEvent;

        /// <summary>
        /// Upgrades the SharePoint lists and views.
        /// Perform following updates: 
        ///  * Determines project lists to proceed
        ///  * Adds archived column to each project list
        ///  * For each project list updates existing views to filter data by Archived column
        ///  * For each project list adds new view to show Archived items
        ///  * For each project list process all associated lists.
        /// Must be executed with elevated privileges.
        /// </summary>
        public void EnsureFeatureIsInstalledForWeb(Guid siteId, Guid webId)
        {
            using (var site = new SPSite(siteId))
            {
                using (var web = site.OpenWeb(webId))
                {
                    web.AllowUnsafeUpdates = true;
                    try
                    {
                        // try get lists to process and if could not get then log error
                        var lists = GetTargetProjectLists(web);
                        if (lists.Length == 0)
                        {
                            LogItemSkipped($"Could not find default list {DefaultTargetProjectCenterList}.", _rootLogScope);
                            LogItemSkipped($"Could not find project list configuration {TargetProjectCenterConfigSetting}.", _rootLogScope);
                        }
                        else
                        {
                            foreach (var listId in lists)
                            {
                                // gets the list for further processing
                                var projectCenterList = web.Lists.GetList(listId, true);
                                LogInfo($"About to update {projectCenterList.Title} list.", _rootLogScope);

                                // adds new column and uses it for each view to filter data
                                AddArchivedColumn(projectCenterList, _rootLogScope);
                                UpdateExistingListViews(projectCenterList, _rootLogScope);

                                // creates new view for archived items
                                CreateViewForArchivedRecords(projectCenterList, ArchivedProjectsViewName, _rootLogScope);

                                // we have _processedLists variable to remember all lists which 
                                // we already updated to avoid double checking of same list 
                                // when will process associated lists
                                _processedLists.Add(projectCenterList.ID);

                                // go for each associated list and do similar steps as above
                                ProcessAssociatedLists(web, projectCenterList, _rootLogScope);
                            }
                        }
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
        }

        /// <summary>
        /// Processes all associated lists.
        /// </summary>
        /// <param name="elevatedWeb">The elevated web.</param>
        /// <param name="baseList">The base projects list.</param>
        /// <param name="level">The logging level.</param>
        private void ProcessAssociatedLists(SPWeb elevatedWeb, SPList baseList, int level)
        {
            var associated = ListCommands.GetAssociatedLists(baseList).Cast<AssociatedListInfo>().ToArray();
            if (associated.Length > 0)
            {
                LogInfo($"Updating associated lists for {baseList.Title}.", level);
                foreach (var associatedListInfo in associated)
                {
                    UpdateAssociatedList(elevatedWeb, associatedListInfo, level + 1);
                }
            }
            else
            {
                LogItemSkipped($"Associated lists are not configured for list {baseList.Title}.", level);
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
                    LogInfo($"About to update {associatedListInfo.Title} list.", level);
                    var associatedList = elevatedWeb.Lists.GetList(associatedListInfo.ListId, true);
                    AddArchivedColumn(associatedList, level);

                    if ((int)associatedList.BaseTemplate == (int)EPMLiveLists.TaskCenter)
                    {
                        AddArchivedTimesheetColumn(associatedList, level);
                    }

                    UpdateExistingListViews(associatedList, level);
                    CreateViewForArchivedRecords(associatedList, ArchivedRecordsViewName, level);

                    _processedLists.Add(associatedList.ID);
                }
            }
            catch (Exception ex)
            {
                LogError($"Could not process associated list '{associatedListInfo.Title} with id {associatedListInfo.ListId}'.", level);
                LogError(ex.Message, level);
            }
        }

        private void UpdateExistingListViews(SPList list, int level)
        {
            LogInfo($"About to update {list.Title} views.", level);
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
                        // no change required, view already uses filter
                        continue;
                    }

                    view.Query = queryNode.InnerXml;
                    view.Update();
                }
                catch (Exception ex)
                {
                    LogError($"Could not update view '{view.Title} for list {list.Title}'.", level + 1);
                    LogError(ex.Message, level + 1);
                }
            }

            LogSuccess($"All views for {list.Title} now will exclude archived items.", level);
        }

        private void CreateViewForArchivedRecords(SPList list, string viewName, int level)
        {
            if (list.Views.Count <= 0)
            {
                LogItemSkipped(
                    $"List {list.Title} does not have any views. Cannot use anything as template for archived items view.",
                    level);
                return;
            }

            try
            {
                if (ViewExists(list, viewName))
                {
                    LogItemSkipped($"View '{viewName}' already exists in list {list.Title}.", level);
                    return;
                }

                var defaultView = list.DefaultView ?? list.Views[0];
                var newView = defaultView.Clone(viewName, defaultView.RowLimit, defaultView.Paged, false);
                newView.Query = newView.Query.Replace(ViewFilterNonArchived, ViewFilterArchived);
                newView.Update();

                LogSuccess($"Created view {viewName} for list {list.Title}.", level);
            }
            catch (Exception ex)
            {
                LogError($"Could not create view '{viewName} for list {list.Title}'.", level);
                LogError(ex.Message, level + 1);
            }
        }

        private Guid[] GetTargetProjectLists(SPWeb elevatedWeb)
        {
            var projectListIds = new List<Guid>();
            var projectListNamesCsv = DefaultTargetProjectCenterList;
            try
            {
                var setting = elevatedWeb.AllProperties[TargetProjectCenterConfigSetting];
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

        private Guid[] GetAllViews(SPList list)
        {
            var views = new List<Guid>();
            foreach (SPView view in list.Views)
            {
                views.Add(view.ID);
            }

            return views.ToArray();
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

        private void AddColumn(SPList list, string internalName, string title, bool visibleToEndUser, int level)
        {
            if (list.Fields.ContainsField(internalName))
            {
                LogItemSkipped($"Column '{internalName}' already exists in list {list.Title}.", level);
                return;
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

            LogSuccess($"Column '{internalName}' added to list {list.Title}.", level);
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

        private void LogItemSkipped(string message, int scope)
        {
            LogMessage(message, ProjectArchiverSetupServiceLogEventArgs.Skipped, scope);
        }

        private void LogInfo(string message, int scope)
        {
            LogMessage(message, ProjectArchiverSetupServiceLogEventArgs.Info, scope);
        }

        private void LogError(string message, int scope)
        {
            LogMessage(message, ProjectArchiverSetupServiceLogEventArgs.Error, scope);
        }

        private void LogSuccess(string message, int scope)
        {
            LogMessage(message, ProjectArchiverSetupServiceLogEventArgs.Success, scope);
        }

        private void LogMessage(string message, int level, int scope)
        {
            OnLogEvent(new ProjectArchiverSetupServiceLogEventArgs(message, level, scope));
        }

        private void OnLogEvent(ProjectArchiverSetupServiceLogEventArgs e)
        {
            LogEvent?.Invoke(this, e);
        }
    }
}