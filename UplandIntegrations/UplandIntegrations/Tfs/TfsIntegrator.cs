using EPMLiveIntegration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace UplandIntegrations.Tfs
{
    public class TfsIntegrator : IIntegrator, IIntegratorControls
    {
        #region Interface Methods
        public bool InstallIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey, string APIUrl)
        {
            try
            {
                Message = "";
                CheckWebProps(WebProps, true);
                if (string.IsNullOrEmpty(APIUrl))
                {
                    Message = "APIUrl is required for integration. Please contact administrator.";
                    return false;
                }
                using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
                {
                    tfsService.InstallEvent((string)WebProps.Properties["TeamProjectCollection"], (string)WebProps.Properties["Object"], IntegrationKey, APIUrl);
                }
            }
            catch (Exception ex)
            {
                Message = "Error: " + ex.Message;
                Log.LogMessage("Install integration. " + ex.Message, IntegrationLogType.Error);
                return false;
            }
            return true;
        }
        public bool RemoveIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey)
        {
            try
            {
                Message = "";
                CheckWebProps(WebProps, true);
                using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
                {
                    tfsService.RemoveEvent((string)WebProps.Properties["TeamProjectCollection"], (string)WebProps.Properties["Object"], Convert.ToString(WebProps.Properties["ServerUrl"]), IntegrationKey);
                }
            }
            catch (Exception ex)
            {
                Message = "Error: " + ex.Message;
                Log.LogMessage("Remove integration. " + ex.Message, IntegrationLogType.Error);
                return true;
            }
            return true;
        }

        public List<IntegrationControl> GetControls(WebProperties WebProps, IntegrationLog Log)
        {
            throw new NotImplementedException();
        }
        public List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName)
        {
            CheckWebProps(WebProps, true);
            List<ColumnProperty> columnPropertyList = new List<ColumnProperty>();
            List<ColumnProperty> columnPropertyListSorted = new List<ColumnProperty>();
            using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
            {
                DataTable dataTable = new DataTable();
                String objectName = (string)WebProps.Properties["Object"];
                String teamProjectCollection = (string)WebProps.Properties["TeamProjectCollection"];
                tfsService.GetObjectItems(teamProjectCollection, objectName, dataTable, DateTime.Now.AddYears(-1), true);
                foreach (DataColumn item in dataTable.Columns)
                {
                    ColumnProperty prop = new ColumnProperty();
                    prop.ColumnName = item.ColumnName;
                    prop.DiplayName = item.ColumnName;
                    prop.DefaultListColumn = GetDefaultColumn(objectName, item.ColumnName);
                    columnPropertyList.Add(prop);
                }
                dataTable.Dispose();
                dataTable = null;
            }

            columnPropertyListSorted = (from cp in columnPropertyList
                                        orderby cp.ColumnName
                                        select cp).ToList();

            return columnPropertyListSorted;
        }
        public Dictionary<string, string> GetDropDownValues(WebProperties WebProps, IntegrationLog log, string Property, string ParentPropertyValue)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            if (Property == "TeamProjectCollection")
            {
                CheckWebProps(WebProps, false);
                using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
                {
                    DataTable collection = new DataTable();
                    tfsService.GetTeamProjectCollections(collection, false);
                    foreach (DataRow dataRow in collection.Rows)
                    {
                        props.Add(Convert.ToString(dataRow["DisplayName"]), Convert.ToString(dataRow["DisplayName"]));
                    }
                }
            }
            else if (Property == "Object")
            {
                CheckWebProps(WebProps, false);
                using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
                {
                    DataTable collection = new DataTable();
                    String teamProjectCollection = Convert.ToString(WebProps.Properties["TeamProjectCollection"]);
                    if (string.IsNullOrEmpty(teamProjectCollection))
                    {
                        DataTable projectCollection = new DataTable();
                        tfsService.GetTeamProjectCollections(projectCollection, false);
                        if (projectCollection.Rows.Count > 0)
                        {
                            teamProjectCollection = Convert.ToString(projectCollection.Rows[0]["DisplayName"]);
                        }
                        else
                        {
                            throw new Exception("Please provide the project collection.");
                        }
                    }
                    tfsService.GetWorkItemTypes(teamProjectCollection, collection, false);
                    foreach (DataRow dataRow in collection.Rows)
                    {
                        props.Add(Convert.ToString(dataRow["Name"]), Convert.ToString(dataRow["Name"]));
                    }
                }
            }
            else if (Property == "UseBasicAuthentication")
            {
                props.Add("true", "true");
                props.Add("false", "false");
            }
            return props;
        }
        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            try
            {
                Message = "";
                CheckWebProps(WebProps, false);
                using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
                {
                }
                return true;
            }
            catch (Exception ex)
            {
                Message = "Error: " + ex.Message;
                Log.LogMessage("Test connection. " + ex.Message, IntegrationLogType.Error);
                return false;
            }
        }

        public TransactionTable DeleteItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            CheckWebProps(WebProps, true);
            TransactionTable transactionTable = new TransactionTable();
            using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
            {
                foreach (DataRow item in Items.Rows)
                {
                    string curId = item["ID"].ToString();
                    string spId = item["SPID"].ToString();
                    try
                    {
                        tfsService.DeleteObjectItem((string)WebProps.Properties["TeamProjectCollection"], (string)WebProps.Properties["Object"], Convert.ToInt32(curId));
                        transactionTable.AddRow(spId, curId, TransactionType.DELETE);
                    }
                    catch (Exception ex)
                    {
                        transactionTable.AddRow(spId, curId, TransactionType.FAILED);
                        Log.LogMessage("Delete items. " + ex.Message, IntegrationLogType.Warning);
                    }
                }
            }
            //Log.LogMessage("Delete items. Not supported in TFS", IntegrationLogType.Error);
            return transactionTable;
        }
        public TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            CheckWebProps(WebProps, true);
            TransactionTable transactionTable = new TransactionTable();
            using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
            {
                foreach (DataRow item in Items.Rows)
                {
                    string curId = item["ID"].ToString();
                    string spId = item["SPID"].ToString();
                    try
                    {
                        if (string.IsNullOrEmpty(curId))
                        {
                            curId = tfsService.CreateObjectItem((string)WebProps.Properties["TeamProjectCollection"], (string)WebProps.Properties["Object"], item, Items.Columns).ToString();
                            transactionTable.AddRow(spId, curId, TransactionType.INSERT);
                        }
                        else
                        {
                            DataTable getItemDataTable = new DataTable();
                            tfsService.GetObjectItem((string)WebProps.Properties["TeamProjectCollection"], (string)WebProps.Properties["Object"], getItemDataTable, curId, false);

                            if (getItemDataTable.Rows.Count == 0)
                            {
                                curId = tfsService.CreateObjectItem((string)WebProps.Properties["TeamProjectCollection"], (string)WebProps.Properties["Object"], item, Items.Columns).ToString();
                                transactionTable.AddRow(spId, curId, TransactionType.INSERT);
                            }
                            else
                            {
                                tfsService.UpdateObjectItem((string)WebProps.Properties["TeamProjectCollection"], (string)WebProps.Properties["Object"], item, Convert.ToInt32(curId), Items.Columns);
                                transactionTable.AddRow(spId, curId, TransactionType.UPDATE);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transactionTable.AddRow(spId, curId, TransactionType.FAILED);
                        Log.LogMessage("Update items. " + ex.Message, IntegrationLogType.Warning);
                    }
                }
            }
            return transactionTable;
        }
        public DataTable GetItem(WebProperties WebProps, IntegrationLog log, string ItemID, DataTable Items)
        {
            try
            {
                CheckWebProps(WebProps, true);
                using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
                {
                    tfsService.GetObjectItem((string)WebProps.Properties["TeamProjectCollection"], (string)WebProps.Properties["Object"], Items, ItemID, false);
                }
            }
            catch (Exception ex)
            {
                log.LogMessage("Get item. " + ex.Message, IntegrationLogType.Error);
            }
            return Items;
        }
        public DataTable PullData(WebProperties WebProps, IntegrationLog log, DataTable Items, DateTime LastSynchDate)
        {
            try
            {
                CheckWebProps(WebProps, true);
                using (TfsService tfsService = new TfsService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString(), Convert.ToBoolean(WebProps.Properties["UseBasicAuthentication"].ToString())))
                {
                    tfsService.GetObjectItems((string)WebProps.Properties["TeamProjectCollection"], (string)WebProps.Properties["Object"], Items, LastSynchDate, false);
                }
            }
            catch (Exception ex)
            {
                log.LogMessage("Pull data. " + ex.Message, IntegrationLogType.Error);
            }
            return Items;
        }
        #endregion

        #region Private Methods

        private void CheckWebProps(WebProperties WebProps, Boolean checkOtherWebProperties)
        {
            if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["ServerUrl"]))) throw new Exception("Please provide the serverurl.");
            if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["Username"]))) throw new Exception("Please provide the username.");
            if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["Password"]))) throw new Exception("Please provide the password.");
            if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["UseBasicAuthentication"]))) throw new Exception("Please provide use basic auth credential.");

            if (checkOtherWebProperties)
            {
                if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["TeamProjectCollection"]))) throw new Exception("Please provide the project collection.");
                if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["Object"]))) throw new Exception("Please provide the object.");
            }
        }
        private string GetDefaultColumn(string objectName, string columnName)
        {
            return string.Empty;
        }

        #endregion

        public string GetControlCode(WebProperties WebProps, IntegrationLog Log, string ItemID, string Control)
        {
            return string.Empty;
        }

        public List<string> GetEmbeddedItemControls(WebProperties WebProps, IntegrationLog Log)
        {
            return new List<string>();
        }

        public List<IntegrationControl> GetPageButtons(WebProperties WebProps, IntegrationLog Log, bool GlobalButtons)
        {
            if (!GlobalButtons)
            {
                CheckWebProps(WebProps, true);
                return new List<IntegrationControl>
                {
                    new IntegrationControl
                    {
                        Control = "TF_ViewWorkItem",
                        Title = "View Work Item",
                        Image = "tf_viewworkitem.png",
                        Window = IntegrationControlWindowStyle.FullWindow
                    }

                };
            }
            return new List<IntegrationControl>();
        }

        public string GetURL(WebProperties webProps, IntegrationLog log, string control, string itemId)
        {
            try
            {
                CheckWebProps(webProps, true);
                switch (control)
                {
                    case "TF_ViewWorkItem":
                        using (TfsService tfsService = new TfsService(webProps.Properties["ServerUrl"].ToString(), webProps.Properties["Username"].ToString(), webProps.Properties["Password"].ToString(), Convert.ToBoolean(webProps.Properties["UseBasicAuthentication"].ToString())))
                        {
                            return tfsService.GetWorkItemURL((string)webProps.Properties["TeamProjectCollection"], (string)webProps.Properties["Object"], itemId);
                        }
                        break;
                }
                throw new Exception(control + " is not a valid tfs control.");
            }
            catch (Exception exception)
            {
                log.LogMessage(exception.Message, IntegrationLogType.Error);
            }

            return string.Empty;
        }

        public string GetProxyResult(WebProperties WebProps, IntegrationLog Log, string ItemID, string Control, string Property)
        {
            return string.Empty;
        }
    }
}
