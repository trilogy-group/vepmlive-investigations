using EPMLiveIntegration;
using System;
using System.Collections.Generic;
using System.Data;

namespace EPMLiveCore.Integrations.Jira
{
    public class JiraIntegrator : IIntegrator
    {
        #region Interface Methods
        public bool InstallIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey, string APIUrl)
        {
            try
            {
                Message = "";
                CheckWebProps(WebProps);
                using (JiraService jiraService = new JiraService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
                {
                    jiraService.InstallWebhook((string)WebProps.Properties["Object"], IntegrationKey, APIUrl);
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
                CheckWebProps(WebProps);
                using (JiraService jiraService = new JiraService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
                {
                    jiraService.RemoveWebhook((string)WebProps.Properties["Object"], Convert.ToString(WebProps.Properties["ServerUrl"]), IntegrationKey);
                }
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
        public string GetURL(WebProperties WebProps, IntegrationLog Log, string control, string url)
        {
            throw new NotImplementedException();
        }
        public List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName)
        {
            CheckWebProps(WebProps);
            List<ColumnProperty> columnPropertyList = new List<ColumnProperty>();
            using (JiraService jiraService = new JiraService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
            {
                DataTable dataTable = new DataTable();
                String objectName = (string)WebProps.Properties["Object"];
                jiraService.GetObjectItems(objectName, dataTable, DateTime.Now.AddYears(-1), true);
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
            props.Add(JiraType.Users.ToString(), JiraType.Users.ToString());
            props.Add(JiraType.Projects.ToString(), JiraType.Projects.ToString());
            props.Add(JiraType.Components.ToString(), JiraType.Components.ToString());
            props.Add(JiraType.Versions.ToString(), JiraType.Versions.ToString());
            props.Add(JiraType.Issues.ToString(), JiraType.Issues.ToString());
            return props;
        }
        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            try
            {
                Message = "";
                CheckWebProps(WebProps);
                using (JiraService jiraService = new JiraService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
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
            CheckWebProps(WebProps);
            TransactionTable transactionTable = new TransactionTable();
            using (JiraService jiraService = new JiraService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
            {
                foreach (DataRow item in Items.Rows)
                {
                    string curId = item["ID"].ToString();
                    string spId = item["SPID"].ToString();
                    try
                    {
                        jiraService.DeleteObjectItem((string)WebProps.Properties["Object"], Convert.ToInt64(curId));
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
            CheckWebProps(WebProps);
            TransactionTable transactionTable = new TransactionTable();
            using (JiraService jiraService = new JiraService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
            {
                foreach (DataRow item in Items.Rows)
                {
                    string curId = item["ID"].ToString();
                    string spId = item["SPID"].ToString();
                    try
                    {
                        if (string.IsNullOrEmpty(curId))
                        {
                            jiraService.CreateObjectItem((string)WebProps.Properties["Object"], item, Items.Columns);
                            transactionTable.AddRow(spId, curId, TransactionType.INSERT);
                        }
                        else
                        {
                            DataTable getItemDataTable = new DataTable();
                            jiraService.GetObjectItem((string)WebProps.Properties["Object"], getItemDataTable, curId, false);

                            if (getItemDataTable.Rows.Count == 0)
                            {
                                jiraService.CreateObjectItem((string)WebProps.Properties["Object"], item, Items.Columns);
                                transactionTable.AddRow(spId, curId, TransactionType.INSERT);
                            }
                            else
                            {
                                jiraService.UpdateObjectItem((string)WebProps.Properties["Object"], item, Convert.ToInt64(curId), Items.Columns);
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
                CheckWebProps(WebProps);
                using (JiraService jiraService = new JiraService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
                {
                    jiraService.GetObjectItem((string)WebProps.Properties["Object"], Items, ItemID, false);
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
                CheckWebProps(WebProps);
                using (JiraService jiraService = new JiraService(WebProps.Properties["ServerUrl"].ToString(), WebProps.Properties["Username"].ToString(), WebProps.Properties["Password"].ToString()))
                {
                    jiraService.GetObjectItems((string)WebProps.Properties["Object"], Items, LastSynchDate, false);
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

        private void CheckWebProps(WebProperties WebProps)
        {
            if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["ServerUrl"]))) throw new Exception("Please provide the serverurl.");
            if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["Username"]))) throw new Exception("Please provide the username.");
            if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["Password"]))) throw new Exception("Please provide the password.");
            if (string.IsNullOrEmpty(Convert.ToString(WebProps.Properties["Object"]))) throw new Exception("Please provide the object.");
        }
        private string GetDefaultColumn(string objectName, string columnName)
        {
            JiraType jiraType;
            if (Enum.TryParse(objectName, true, out jiraType))
            {
                if (jiraType == JiraType.Users)
                {
                    switch (columnName)
                    {
                        default:
                            return "";
                    }
                }
                else if (jiraType == JiraType.Projects)
                {
                    switch (columnName)
                    {
                        default:
                            return "";
                    }
                }
                else if (jiraType == JiraType.Components)
                {
                    switch (columnName)
                    {
                        default:
                            return "";
                    }
                }
                else if (jiraType == JiraType.Versions)
                {
                    switch (columnName)
                    {
                        default:
                            return "";
                    }
                }
                else if (jiraType == JiraType.Issues)
                {
                    switch (columnName)
                    {
                        default:
                            return "";
                    }
                }
            }
            return "";
        }

        #endregion
    }
}
