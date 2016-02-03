using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace UplandIntegrations.Tfs
{
    public class TfsService : IDisposable
    {
        private TfsConfigurationServer tfsConfigurationServer;
        private TfsClientCredentials tfsCred;
        private string tfsWorkItemChangedEventName = "WorkItemChangedEvent";
        private string[] tfsWorkItemColumnList = new string[] { "id", "name", "title", "assigned to", "completed work", "remaining work", "original estimate", "start date", "finish date" };

        #region Constructor

        public TfsService(string serverUrl, string userName, string password, bool useBasicAuthCredential)
        {
            try
            {
                if (string.IsNullOrEmpty(serverUrl))
                {
                    throw new Exception("Please provide the serverurl");
                }
                if (string.IsNullOrEmpty(userName))
                {
                    throw new Exception("Please provide the username");
                }
                if (string.IsNullOrEmpty(password))
                {
                    throw new Exception("Please provide the password");
                }

                NetworkCredential netCred = new NetworkCredential(userName, password);
                Uri serverUri = new Uri(serverUrl);

                if (useBasicAuthCredential)
                {
                    BasicAuthCredential basicCred = new BasicAuthCredential(netCred);
                    tfsCred = new TfsClientCredentials(basicCred);
                }
                else
                {
                    WindowsCredential windowsCred = new WindowsCredential(netCred);
                    tfsCred = new TfsClientCredentials(windowsCred);
                }

                tfsCred.AllowInteractive = false;

                tfsConfigurationServer = new TfsConfigurationServer(new Uri(serverUrl), tfsCred);
                tfsConfigurationServer.Authenticate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Public

        public void InstallEvent(string projectCollection, string objectName, string integrationKey, string apiUrl)
        {
            try
            {
                if (!objectName.ToLower().Equals("projects"))
                {
                    using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
                    {
                        IEventService eventService = tfsTeamProjectCollection.GetService(typeof(IEventService)) as IEventService;
                        DeliveryPreference delivery = new DeliveryPreference();
                        delivery.Type = DeliveryType.Soap;
                        delivery.Schedule = DeliverySchedule.Immediate;
                        delivery.Address = string.Format("{0}?integrationkey={1}", apiUrl, integrationKey);
                        eventService.SubscribeEvent("", tfsWorkItemChangedEventName, "", delivery, string.Format("{0}-{1}", integrationKey, tfsWorkItemChangedEventName));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RemoveEvent(string projectCollection, string objectName, string serverUrl, string integrationKey)
        {
            try
            {
                try
                {
                    if (!objectName.ToLower().Equals("projects"))
                    {
                        using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
                        {
                            IEventService eventService = tfsTeamProjectCollection.GetService(typeof(IEventService)) as IEventService;
                            foreach (Subscription eventSub in eventService.GetEventSubscriptions("", string.Format("{0}-{1}", integrationKey, tfsWorkItemChangedEventName)))
                            {
                                eventService.UnsubscribeEvent(eventSub.ID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void GetTeamProjectCollections(DataTable items, Boolean isOnlyColumns)
        //{
        //    ITeamProjectCollectionService tpcService = tfsConfigurationServer.GetService<ITeamProjectCollectionService>();
        //    {
        //        foreach (TeamProjectCollection teamProjectCollection in tpcService.GetCollections())
        //        {
        //            FillDataTable(teamProjectCollection, items, isOnlyColumns);
        //        }
        //    }
        //}
        //public void GetTeamProjectCollection(DataTable items, string teamProjectCollectionId, Boolean isOnlyColumns)
        //{
        //    ITeamProjectCollectionService tpcService = tfsConfigurationServer.GetService<ITeamProjectCollectionService>();
        //    {
        //        TeamProjectCollection teamProjectCollection = tpcService.GetCollection(new Guid(teamProjectCollectionId));
        //        FillDataTable(teamProjectCollection, items, isOnlyColumns);
        //    }
        //}

        public void GetTeamProjectCollections(DataTable items, Boolean isOnlyColumns)
        {
            // Get the catalog of team project collections
            CatalogNode catalogNode = tfsConfigurationServer.CatalogNode;

            ReadOnlyCollection<CatalogNode> tpcNodes = catalogNode.QueryChildren(new Guid[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);

            // List the team project collections
            foreach (CatalogNode tpcNode in tpcNodes)
            {
                // Use the InstanceId property to get the team project collection
                Guid tpcId = new Guid(tpcNode.Resource.Properties["InstanceId"]);
                TfsTeamProjectCollection tpc = tfsConfigurationServer.GetTeamProjectCollection(tpcId);
                FillDataTable(tpcNode.Resource, items, isOnlyColumns);
            }
        }
        public void GetTeamProjectCollection(DataTable items, string teamProjectCollectionId, Boolean isOnlyColumns)
        {

            TfsTeamProjectCollection tpc = tfsConfigurationServer.GetTeamProjectCollection(new Guid(teamProjectCollectionId));
            FillDataTable(tpc, items, isOnlyColumns);
        }

        public void GetTeamProjects(string projectCollection, DataTable items, Boolean isOnlyColumns)
        {
            using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
            {
                tfsTeamProjectCollection.Authenticate();
                var workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();
                foreach (Project project in workItemStore.Projects)
                {
                    FillDataTable(project, items, isOnlyColumns);
                }
            }

        }
        public void GetTeamProject(string projectCollection, DataTable items, string projectId, Boolean isOnlyColumns)
        {
            using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
            {
                tfsTeamProjectCollection.Authenticate();
                var workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();
                foreach (Project project in workItemStore.Projects)
                {
                    if (project.Id.Equals(projectId))
                    {
                        FillDataTable(project, items, isOnlyColumns);
                        break;
                    }
                }
            }
        }

        public void GetWorkItemTypes(string projectCollection, DataTable items, Boolean isOnlyColumns)
        {
            using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
            {
                tfsTeamProjectCollection.Authenticate();
                var workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();
                foreach (Project project in workItemStore.Projects)
                {
                    foreach (WorkItemType workitem in project.WorkItemTypes)
                    {
                        if (items.Rows.Count == 0)
                        {
                            FillDataTable(workitem, items, isOnlyColumns);
                        }
                        else if (items.Rows.Count > 0 && items.Select(string.Format("Name ='{0}'", workitem.Name)).Count() <= 0)
                        {
                            FillDataTable(workitem, items, isOnlyColumns);
                        }
                    }
                }
            }

        }

        public void GetObjectItem(string projectCollection, string objectName, DataTable items, string itemId, Boolean isOnlyColumns)
        {
            try
            {
                if (objectName.ToLower().Equals("projects"))
                {
                    GetTeamProject(projectCollection, items, itemId, isOnlyColumns);
                }
                else
                {
                    GetWorkItem(projectCollection, objectName.Replace("_", " "), items, itemId, isOnlyColumns);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetObjectItems(string projectCollection, string objectName, DataTable items, DateTime lastSyncDateTime, Boolean isOnlyColumns)
        {
            try
            {
                if (objectName.ToLower().Equals("projects"))
                {
                    GetTeamProjects(projectCollection, items, isOnlyColumns);
                }
                else
                {
                    GetWorkItems(projectCollection, objectName.Replace("_", " "), items, lastSyncDateTime, isOnlyColumns);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 CreateObjectItem(string projectCollection, string objectName, DataRow Item, DataColumnCollection dataColumns)
        {
            try
            {
                if (!objectName.ToLower().Equals("projects"))
                {
                    return CreateWorkItem(projectCollection, objectName.Replace("_", " "), Item, dataColumns);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateObjectItem(string projectCollection, string objectName, DataRow Item, Int32 itemId, DataColumnCollection dataColumns)
        {
            try
            {
                if (!objectName.ToLower().Equals("projects"))
                {
                    UpdateWorkItem(projectCollection, objectName.Replace("_", " "), Item, itemId, dataColumns);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteObjectItem(string projectCollection, string objectName, Int32 itemId)
        {
            try
            {
                if (!objectName.ToLower().Equals("projects"))
                {
                    DeleteWorkItem(projectCollection, itemId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetWorkItemURL(string projectCollection, string workItemType, string id)
        {
            using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
            {
                tfsTeamProjectCollection.Authenticate();
                var tfsVersionControlServer = tfsTeamProjectCollection.GetService<VersionControlServer>();
                var workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();
                string wiqlQuery = string.Format("Select ID, Title from WorkItems where [Work Item Type] = '{0}' and [ID] = {1}", workItemType, id);
                var workItems = workItemStore.Query(wiqlQuery);
                if (workItems != null && workItems.Count > 0)
                {
                    switch (tfsVersionControlServer.WebServiceLevel)
                    {
                        case WebServiceLevel.PreTfs2010:
                        case WebServiceLevel.Tfs2010:
                            return string.Format("{0}/web/UI/Pages/WorkItems/WorkItemEdit.aspx?id={1}", tfsConfigurationServer.Uri.AbsoluteUri, id);
                            break;
                        default:
                            return string.Format("{0}/{1}/{2}/_workItems#id={3}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection, workItems[0].Project.Name, id);
                            break;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        #endregion

        #region Private

        private Int32 CreateWorkItem(string projectCollection, string workItemType, DataRow item, DataColumnCollection dataColumns)
        {
            if (string.IsNullOrEmpty(Convert.ToString(item["Project|Id"])))
            {
                throw new Exception("Project|Id is required for creating this workitem.");
            }
            using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
            {
                tfsTeamProjectCollection.Authenticate();
                var workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();
                Project project = null;
                foreach (Project prj in workItemStore.Projects)
                {
                    if (prj.Id.ToString().Equals(Convert.ToString(item["Project|Id"])))
                    {
                        project = prj;
                        break;
                    }
                }

                var workItemTypes = project.WorkItemTypes;
                var workItem = new WorkItem(workItemTypes[workItemType]);
                FillWorkItemFromDataRow(workItem, item, dataColumns);

                ArrayList fields = workItem.Validate();
                if (fields.Count > 0)
                {
                    StringBuilder error = new StringBuilder();
                    error.Append(string.Format("{0} {1}", "The value(s) assigned to the following field(s) are not valid:", Environment.NewLine));
                    foreach (Field field in fields)
                    {
                        error.Append(string.Format("[{0}] {1} ", field.Name, Environment.NewLine));
                    }
                    throw new Exception(error.ToString());
                }
                workItem.Save();
                return workItem.Id;
            }
        }
        private void UpdateWorkItem(string projectCollection, string workItemType, DataRow item, Int32 itemId, DataColumnCollection dataColumns)
        {
            using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
            {
                tfsTeamProjectCollection.Authenticate();
                var workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();
                string wiqlQuery = string.Format("Select ID, Title from WorkItems where [Work Item Type] = '{0}' and [ID] = {1}", workItemType, itemId);

                var workItems = workItemStore.Query(wiqlQuery);
                if (workItems != null && workItems.Count > 0)
                {
                    workItems[0].Open();
                    FillWorkItemFromDataRow(workItems[0], item, dataColumns);
                    workItems[0].Save();
                }
            }
        }
        private void DeleteWorkItem(string projectCollection, Int32 itemId)
        {
            List<int> itemIds = new List<int>();
            itemIds.Add(itemId);
            using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
            {
                tfsTeamProjectCollection.Authenticate();
                var workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();

                foreach (WorkItemOperationError error in workItemStore.DestroyWorkItems(itemIds.ToArray()))
                {
                    if (error != null)
                    {
                        throw new Exception(error.Exception.Message);
                    }
                }
                workItemStore.RefreshCache();
                workItemStore.SyncToCache();
            }
        }

        private void GetWorkItems(string projectCollection, string workItemType, DataTable items, DateTime lastSyncDateTime, Boolean isOnlyColumns)
        {
            using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
            {
                tfsTeamProjectCollection.Authenticate();
                var workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();
                string wiqlQuery = string.Format("Select ID, Title from WorkItems where [Work Item Type] = '{0}' and [Changed Date] >= '{1}'", workItemType, lastSyncDateTime.ToString("yyyy/MM/dd"));
                var workItems = workItemStore.Query(wiqlQuery);
                foreach (WorkItem workItem in workItems)
                {
                    FillDataTable(workItem, items, isOnlyColumns);
                }
            }
        }
        private void GetWorkItem(string projectCollection, string workItemType, DataTable items, string id, Boolean isOnlyColumns)
        {
            using (TfsTeamProjectCollection tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Format("{0}/{1}", tfsConfigurationServer.Uri.AbsoluteUri, projectCollection)), tfsCred))
            {
                tfsTeamProjectCollection.Authenticate();
                var workItemStore = tfsTeamProjectCollection.GetService<WorkItemStore>();
                string wiqlQuery = string.Format("Select ID, Title from WorkItems where [Work Item Type] = '{0}' and [ID] = {1}", workItemType, id);
                var workItems = workItemStore.Query(wiqlQuery);
                foreach (WorkItem workItem in workItems)
                {
                    FillDataTable(workItem, items, isOnlyColumns);
                    break;
                }
            }
        }


        private void FillDataTable(object item, DataTable dataTable, Boolean isOnlyColumns)
        {
            PropertyInfo[] Props = item.GetType().GetProperties();
            foreach (PropertyInfo prop in Props)
            {
                if (prop.PropertyType == typeof(string) || prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(int) || prop.PropertyType == typeof(Guid))
                //if (prop.Name.ToLower().Equals("id") || prop.Name.ToLower().Equals("name"))
                {
                    if (!dataTable.Columns.Contains(prop.Name))
                    {
                        dataTable.Columns.Add(prop.Name);
                    }
                }
                else if (prop.PropertyType == typeof(FieldCollection))
                {
                    foreach (Field filed in (FieldCollection)prop.GetValue(item, null))
                    {
                        if (!dataTable.Columns.Contains(string.Format("Field|{0}", filed.Name)))
                        {
                            dataTable.Columns.Add(string.Format("Field|{0}", filed.Name));
                        }
                    }
                }
                else if (prop.PropertyType == typeof(Project))
                {
                    Project project = (Project)prop.GetValue(item, null);
                    if (project != null)
                    {
                        if (!dataTable.Columns.Contains(string.Format("Project|{0}", "Id")))
                        {
                            dataTable.Columns.Add(string.Format("Project|{0}", "Id"));
                        }
                        project = null;
                    }
                }
            }

            if (!isOnlyColumns)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (PropertyInfo prop in Props)
                {
                    try
                    {
                        if (prop.PropertyType == typeof(string) || prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(int) || prop.PropertyType == typeof(Guid))
                        //if (prop.Name.ToLower().Equals("id") || prop.Name.ToLower().Equals("name"))
                        {
                            if (dataTable.Columns.Contains(prop.Name))
                            {
                                dataRow[prop.Name] = prop.GetValue(item, null);
                            }
                        }
                        else if (prop.PropertyType == typeof(FieldCollection))
                        {
                            foreach (Field filed in (FieldCollection)prop.GetValue(item, null))
                            {
                                if (dataTable.Columns.Contains(string.Format("Field|{0}", filed.Name)))
                                {
                                    dataRow[string.Format("Field|{0}", filed.Name)] = filed.Value;
                                }
                            }
                        }
                        else if (prop.PropertyType == typeof(Project))
                        {
                            Project project = (Project)prop.GetValue(item, null);
                            if (project != null)
                            {
                                if (dataTable.Columns.Contains(string.Format("Project|{0}", "Id")))
                                {
                                    dataRow[string.Format("Project|{0}", "Id")] = project.Id;
                                }
                                project = null;
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
                dataTable.Rows.Add(dataRow);
            }

        }
        private void FillWorkItemFromDataRow(WorkItem workItem, DataRow dataRow, DataColumnCollection dataColumns)
        {
            var dataColumnsList = (from dc in dataColumns.Cast<DataColumn>()
                                   select dc).OrderBy(c => c.ColumnName);

            //Dictionary<string, PropertyInfo> props = new Dictionary<string, PropertyInfo>();
            //foreach (PropertyInfo p in workItem.GetType().GetProperties())
            //{
            //    if (!props.ContainsKey(p.Name))
            //        props.Add(p.Name, p);
            //}


            foreach (DataColumn column in dataColumns)
            {
                if (column.ColumnName.Equals("SPID"))
                    continue;

                if (dataRow[column] != null && !string.IsNullOrEmpty(Convert.ToString(dataRow[column])))
                {
                    if (column.ColumnName.Contains("|"))
                    {
                        string[] subColumnsArray = column.ColumnName.Split('|');
                        if (subColumnsArray.Count() == 2 && subColumnsArray[0] == "Field")
                        {
                            workItem.Fields[subColumnsArray[1]].Value = dataRow[column];
                        }
                    }
                    //else
                    //{
                    //    object item = dataRow[column.ColumnName];
                    //    PropertyInfo p = props[column.ColumnName];
                    //    if (p.PropertyType != column.DataType)
                    //        item = Convert.ChangeType(item, p.PropertyType);
                    //    if (p.SetMethod != null)
                    //        p.SetValue(workItem, item, null);
                    //}
                }
            }



        }

        #endregion

        #region Interface

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }

}
