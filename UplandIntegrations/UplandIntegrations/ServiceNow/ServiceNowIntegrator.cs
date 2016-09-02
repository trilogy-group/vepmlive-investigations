using EPMLiveIntegration;
using System;
using System.Collections.Generic;
using System.Data;

namespace UplandIntegrations.ServiceNow
{
    public class ServiceNowIntegrator : IIntegrator, IIntegratorControls
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
                //using (ServiceNowService serviceNowService = new ServiceNowService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
                //{
                //    serviceNowService.InstallWebhook((string)WebProps.Properties["Object"], IntegrationKey, (string)WebProps.Properties["Username"], (string)WebProps.Properties["Password"], APIUrl);
                //}
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
                //using (ServiceNowService serviceNowService = new ServiceNowService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
                //{
                //    serviceNowService.RemoveWebhook((string)WebProps.Properties["Object"], Convert.ToString(WebProps.Properties["ServerUrl"]), IntegrationKey);
                //}
            }
            catch (Exception ex)
            {
                Message = "Error: " + ex.Message;
                Log.LogMessage("Remove integration. " + ex.Message, IntegrationLogType.Error);
                return false;
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
            using (ServiceNowService serviceNowService = new ServiceNowService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
            {
                DataTable dataTable = new DataTable();
                String objectName = (string)WebProps.Properties["Object"];
                serviceNowService.GetObjectItems(objectName, dataTable, DateTime.Now.AddYears(-1), true);
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
            return columnPropertyList;
        }
        public Dictionary<string, string> GetDropDownValues(WebProperties WebProps, IntegrationLog log, string Property, string ParentPropertyValue)
        {

            Dictionary<string, string> props = new Dictionary<string, string>();
            if (Property == "Object")
            {
                CheckWebProps(WebProps, false);
                using (ServiceNowService serviceNowService = new ServiceNowService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
                {
                    DataTable collection = new DataTable();
                    serviceNowService.GetSystemTables(collection, false);
                    foreach (DataRow dataRow in collection.Rows)
                    {
                        props.Add(Convert.ToString(dataRow["name"]), Convert.ToString(dataRow["label"]));
                    }
                }
            }
            return props;
        }
        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            try
            {
                Message = "";
                CheckWebProps(WebProps, false);
                using (ServiceNowService serviceNowService = new ServiceNowService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
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
            using (ServiceNowService serviceNowService = new ServiceNowService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
            {
                foreach (DataRow item in Items.Rows)
                {
                    string curId = item["ID"].ToString();
                    string spId = item["SPID"].ToString();
                    try
                    {
                        serviceNowService.DeleteObjectItem((string)WebProps.Properties["Object"], curId);
                        transactionTable.AddRow(spId, curId, TransactionType.DELETE);
                    }
                    catch (Exception ex)
                    {
                        transactionTable.AddRow(spId, curId, TransactionType.FAILED);
                        Log.LogMessage("Delete items. " + ex.Message, IntegrationLogType.Warning);
                    }
                }
            }
            return transactionTable;
        }
        public TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            CheckWebProps(WebProps, true);
            TransactionTable transactionTable = new TransactionTable();
            using (ServiceNowService serviceNowService = new ServiceNowService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
            {
                foreach (DataRow item in Items.Rows)
                {
                    string curId = item["ID"].ToString();
                    string spId = item["SPID"].ToString();
                    try
                    {
                        if (string.IsNullOrEmpty(curId))
                        {
                            curId = serviceNowService.CreateObjectItem((string)WebProps.Properties["Object"], item, Items.Columns).ToString();
                            transactionTable.AddRow(spId, curId, TransactionType.INSERT);
                        }
                        else
                        {
                            DataTable getItemDataTable = new DataTable();
                            serviceNowService.GetObjectItem((string)WebProps.Properties["Object"], getItemDataTable, curId, false);

                            if (getItemDataTable.Rows.Count == 0)
                            {
                                curId = serviceNowService.CreateObjectItem((string)WebProps.Properties["Object"], item, Items.Columns).ToString();
                                transactionTable.AddRow(spId, curId, TransactionType.INSERT);
                            }
                            else
                            {
                                serviceNowService.UpdateObjectItem((string)WebProps.Properties["Object"], item, curId, Items.Columns);
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
                using (ServiceNowService serviceNowService = new ServiceNowService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
                {
                    serviceNowService.GetObjectItem((string)WebProps.Properties["Object"], Items, ItemID, false);
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
                using (ServiceNowService serviceNowService = new ServiceNowService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
                {
                    serviceNowService.GetObjectItems((string)WebProps.Properties["Object"], Items, LastSynchDate, false);
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

            if (checkOtherWebProperties)
            {
                if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["Object"]))) throw new Exception("Please provide the object.");
            }
        }
        private string GetDefaultColumn(string objectName, string columnName)
        {
            return "";
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
                                Control = string.Format("SN_View{0}",WebProps.Properties["Object"].ToString().Replace(" ", "_").ToLower()) ,
                                Title = string.Format("View {0}",WebProps.Properties["Object"].ToString()),
                                Image =string.Format("sn_viewitem.png"),
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
                using (ServiceNowService serviceNowService = new ServiceNowService(webProps.Properties["ServerUrl"].ToString(), webProps.Properties["Username"].ToString(), webProps.Properties["Password"].ToString()))
                {
                    DataTable itemDataTable = new DataTable();
                    GetItem(webProps, log, itemId, itemDataTable);
                    if (itemDataTable != null & itemDataTable.Rows.Count > 0)
                    {
                        return string.Format("{0}/{1}sys_id={2}", webProps.Properties["ServerUrl"].ToString(), serviceNowService.GetViewUrlResourceByServiceNowType(control.Replace("SN_View", "").Replace("_", " ")), itemDataTable.Rows[0]["sys_id"]);
                    }
                }
            }
            catch (Exception exception)
            {
                log.LogMessage(exception.Message, IntegrationLogType.Error);
                throw new Exception(control + " is not a valid servicenow control.");
            }

            return string.Empty;
        }

        public string GetProxyResult(WebProperties WebProps, IntegrationLog Log, string ItemID, string Control, string Property)
        {
            return string.Empty;
        }
    }
}
