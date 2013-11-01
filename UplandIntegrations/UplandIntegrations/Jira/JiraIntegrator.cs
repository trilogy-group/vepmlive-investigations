using EPMLiveIntegration;
using System;
using System.Collections.Generic;
using System.Data;

namespace UplandIntegrations.Jira
{
    public class JiraIntegrator : IIntegrator, IIntegratorControls
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
                CheckWebProps(WebProps, true);
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

        public List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName)
        {
            CheckWebProps(WebProps, true);
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
            if (Property == "Object")
            {
                props.Add(JiraType.Users.ToString(), JiraType.Users.ToString());
                props.Add(JiraType.Projects.ToString(), JiraType.Projects.ToString());
                props.Add(JiraType.Components.ToString(), JiraType.Components.ToString());
                props.Add(JiraType.Versions.ToString(), JiraType.Versions.ToString());
                props.Add(JiraType.Issues.ToString(), JiraType.Issues.ToString());
            }
            return props;
        }
        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            try
            {
                Message = "";
                CheckWebProps(WebProps, false);
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
            CheckWebProps(WebProps, true);
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
            CheckWebProps(WebProps, true);
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
                            curId = jiraService.CreateObjectItem((string)WebProps.Properties["Object"], item, Items.Columns).ToString();
                            transactionTable.AddRow(spId, curId, TransactionType.INSERT);
                        }
                        else
                        {
                            DataTable getItemDataTable = new DataTable();
                            jiraService.GetObjectItem((string)WebProps.Properties["Object"], getItemDataTable, curId, false);

                            if (getItemDataTable.Rows.Count == 0)
                            {
                                curId = jiraService.CreateObjectItem((string)WebProps.Properties["Object"], item, Items.Columns).ToString();
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
                CheckWebProps(WebProps, true);
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
                CheckWebProps(WebProps, true);
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
                JiraType jiraType = (JiraType)Enum.Parse(typeof(JiraType), Convert.ToString(WebProps.Properties["Object"]));
                switch (jiraType)
                {
                    case JiraType.Issues:
                        return new List<IntegrationControl>
                        {
                            new IntegrationControl
                            {
                                Control = "JI_ViewIssue",
                                Title = "View Issue",
                                Image = "ji_viewissue.png",
                                Window = IntegrationControlWindowStyle.FullWindow
                            }
                    
                        };
                        break;
                    default:
                        break;
                }
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
                    case "JI_ViewIssue":
                        DataTable itemDataTable = new DataTable();
                        GetItem(webProps, log, itemId, itemDataTable);
                        if (itemDataTable != null & itemDataTable.Rows.Count > 0)
                        {
                            return string.Format("{0}/{1}/{2}", webProps.Properties["ServerUrl"].ToString(), "browse", itemDataTable.Rows[0]["key"]);
                        }
                        break;
                }
                throw new Exception(control + " is not a valid jira control.");
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
