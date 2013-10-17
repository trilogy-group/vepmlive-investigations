using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Security;
using EPMLiveIntegration;
using UplandIntegrations.Tenrox.Infrastructure;
using UplandIntegrations.Tenrox.Services;

namespace UplandIntegrations.Tenrox
{
    public class Integrator : IIntegrator, IIntegratorControls
    {
        #region Fields (4) 

        private const string EXPENSES_URL =
            @"{0}/TEnterprise/core/base/logon.aspx?Linktype=9999&LiveLink=1&LinkUID=-1&OrgName={1}";

        private const string PROJECT_INFO_URL =
            @"{0}/TEnterprise/core/base/logon.aspx?HideCloseButton=1&Linktype=2&LiveLink=1&LinkUID={1}&OrgName={2}";

        private const string TIMESHEET_URL = @"{0}/TEnterprise/core/base/logon.aspx?Linktype=12&LiveLink=1&OrgName={1}";

        private const string UPSERT_ERROR_MESSAGE =
            @"Could not upsert record. Tenrox ID: {0}. EPMLive ID: {1}. Reason: {2}";

        #endregion Fields 

        #region Methods (13) 

        // Public Methods (9) 

        public TransactionTable DeleteItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                TenroxService txService = GetTenroxService(webProps);

                List<string> ids;
                Dictionary<string, string> idMap = BuildIdMap(items, out ids);

                var itemIds = new List<int>();
                foreach (string id in ids)
                {
                    try
                    {
                        itemIds.Add(int.Parse(id));
                    }
                    catch { }
                }

                IEnumerable<TenroxTransactionResult> results =
                    txService.DeleteItems((string) webProps.Properties["Object"],
                        itemIds.ToArray(), webProps.IntegrationId);

                ProcessResults(items, log, results, idMap, transactionTable);
            }
            catch (Exception exception)
            {
                log.LogMessage(exception.Message, IntegrationLogType.Error);
            }

            return transactionTable;
        }

        public List<ColumnProperty> GetColumns(WebProperties webProps, IntegrationLog log, string listName)
        {
            try
            {
                string objectName = null;

                try
                {
                    objectName = webProps.Properties["Object"] as string;
                }
                catch { }

                if (string.IsNullOrEmpty(objectName)) throw new Exception("Please provide an object.");

                return GetTenroxService(webProps).GetObjectFields(objectName);
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, IntegrationLogType.Error);
            }

            return null;
        }

        public Dictionary<string, string> GetDropDownValues(WebProperties webProps, IntegrationLog log, string property,
            string parentpropertyValue)
        {
            try
            {
                if (property.Equals("Object"))
                {
                    return new Dictionary<string, string>
                    {
                        {"Client", "Client"},
                        {"Project", "Project"},
                        {"Task", "Task"}
                    };
                }

                if (property.Equals("UserMapType"))
                {
                    return new Dictionary<string, string> {{"Email", "Email"}};
                }
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, IntegrationLogType.Error);
            }

            return new Dictionary<string, string>();
        }

        public DataTable GetItem(WebProperties webProps, IntegrationLog log, string itemId, DataTable items)
        {
            try
            {
                TenroxService txService = GetTenroxService(webProps);
                txService.GetObjectItemsById((string) webProps.Properties["Object"], itemId, items);
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, e.Message.StartsWith("No records found")
                    ? IntegrationLogType.Warning
                    : IntegrationLogType.Error);
            }

            return items;
        }

        public bool InstallIntegration(WebProperties webProps, IntegrationLog log, out string message,
            string integrationKey,
            string apiUrl)
        {
            message = null;
            return true;
        }

        public DataTable PullData(WebProperties webProps, IntegrationLog log, DataTable items, DateTime lastSynchDate)
        {
            return items;
        }

        public bool RemoveIntegration(WebProperties webProps, IntegrationLog log, out string message,
            string integrationKey)
        {
            message = null;
            return true;
        }

        public bool TestConnection(WebProperties webProps, IntegrationLog log, out string message)
        {
            message = null;

            try
            {
                GetTenroxService(webProps);
            }
            catch (Exception e)
            {
                message = e.Message + e.InnerException.Message;
                log.LogMessage(message, IntegrationLogType.Error);

                return false;
            }

            return true;
        }

        public TransactionTable UpdateItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                TenroxService txService = GetTenroxService(webProps);

                List<string> ids;
                Dictionary<string, string> idMap = BuildIdMap(items, out ids);

                IEnumerable<TenroxTransactionResult> results =
                    txService.UpsertItems((string) webProps.Properties["Object"],
                        items, webProps.IntegrationId);

                ProcessResults(items, log, results, idMap, transactionTable);
            }
            catch (Exception exception)
            {
                log.LogMessage(exception.Message, IntegrationLogType.Error);
            }

            return transactionTable;
        }

        // Private Methods (4) 

        private Dictionary<string, string> BuildIdMap(DataTable items, out List<string> ids)
        {
            var idMap = new Dictionary<string, string>();
            ids = new List<string>();

            foreach (DataRow dataRow in items.Rows)
            {
                object oId = dataRow["ID"];

                if (oId == null || oId == DBNull.Value) continue;

                string id = oId.ToString();
                if (ids.Contains(id)) continue;

                ids.Add(id);
                idMap.Add(id, dataRow["SPID"].ToString());
            }

            return idMap;
        }

        private void GetAuthInfo(WebProperties webProps, out string orgUrl, out string orgName, out string username,
            out SecureString password)
        {
            if (!webProps.Properties.ContainsKey("OrgUrl"))
            {
                throw new Exception("Please provide organization url.");
            }

            orgUrl = webProps.Properties["OrgUrl"] as string;
            if (string.IsNullOrEmpty(orgUrl))
            {
                throw new Exception("Invalid organization url.");
            }

            if (!webProps.Properties.ContainsKey("OrgName"))
            {
                throw new Exception("Please provide organization name.");
            }

            orgName = webProps.Properties["OrgName"] as string;
            if (string.IsNullOrEmpty(orgName))
            {
                throw new Exception("Invalid organization nname.");
            }

            if (!webProps.Properties.ContainsKey("Username"))
            {
                throw new Exception("Please provide username.");
            }

            username = webProps.Properties["Username"] as string;
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Invalid username.");
            }

            if (!webProps.Properties.ContainsKey("Password"))
            {
                throw new Exception("Please provide password.");
            }

            var pwd = webProps.Properties["Password"] as string;
            if (string.IsNullOrEmpty(pwd))
            {
                throw new Exception("Invalid password.");
            }

            password = pwd.ToSecureString();
        }

        private TenroxService GetTenroxService(WebProperties webProps)
        {
            string orgUrl;
            string orgName;
            string username;
            SecureString password;

            GetAuthInfo(webProps, out orgUrl, out orgName, out username, out password);

            return new TenroxService(orgUrl, orgName, username, password);
        }

        private void ProcessResults(DataTable items, IntegrationLog log, IEnumerable<TenroxTransactionResult> results,
            Dictionary<string, string> idMap, TransactionTable transactionTable)
        {
            int index = 0;

            foreach (TenroxTransactionResult result in results)
            {
                string txId = result.Id.ToString(CultureInfo.InvariantCulture);
                string spId;

                try
                {
                    spId = idMap[txId];
                }
                catch
                {
                    spId = items.Rows[index]["SPID"].ToString();
                }

                if (result.Success)
                {
                    transactionTable.AddRow(spId, txId, result.TransactionType);
                }
                else
                {
                    transactionTable.AddRow(spId, txId, TransactionType.FAILED);
                    log.LogMessage(string.Format(UPSERT_ERROR_MESSAGE, txId, spId, result.Error),
                        IntegrationLogType.Warning);
                }

                index++;
            }
        }

        #endregion Methods 

        #region Implementation of IIntegratorControls

        public List<string> GetEmbeddedItemControls(WebProperties webProps, IntegrationLog log)
        {
            return new List<string>();
        }

        public List<IntegrationControl> GetPageButtons(WebProperties webProps, IntegrationLog log, bool globalButtons)
        {
            if (webProps.Properties["Object"].Equals("Project"))
            {
                if (globalButtons)
                {
                    return new List<IntegrationControl>
                    {
                        new IntegrationControl
                        {
                            Control = "TX_Timesheet",
                            Title = "Timesheet",
                            Image = "tx_timesheet.png",
                            Window = IntegrationControlWindowStyle.IFrame
                        },
                        new IntegrationControl
                        {
                            Control = "TX_Expenses",
                            Title = "Expenses",
                            Image = "tx_expenses.png",
                            Window = IntegrationControlWindowStyle.IFrame
                        }
                    };
                }

                return new List<IntegrationControl>
                {
                    new IntegrationControl
                    {
                        Control = "TX_ProjectInfo",
                        Title = "Project Info",
                        Image = "tx_projectinfo.png",
                        Window = IntegrationControlWindowStyle.SmallDialog
                    }
                };
            }

            return new List<IntegrationControl>();
        }

        public string GetURL(WebProperties webProps, IntegrationLog log, string control, string itemId)
        {
            try
            {
                string orgUrl;
                string orgName;
                string username;
                SecureString password;

                GetAuthInfo(webProps, out orgUrl, out orgName, out username, out password);

                if (orgUrl.EndsWith("/"))
                {
                    orgUrl = orgUrl.Substring(0, orgUrl.Length - 1);
                }

                switch (control.ToLower())
                {
                    case "tx_timesheet":
                        return string.Format(TIMESHEET_URL, orgUrl, orgName);
                    case "tx_expenses":
                        return string.Format(EXPENSES_URL, orgUrl, orgName);
                    case "tx_projectinfo":
                        return string.Format(PROJECT_INFO_URL, orgUrl, itemId, orgName);
                }

                throw new Exception(control + " is not a valid Tenrox control.");
            }
            catch (Exception exception)
            {
                log.LogMessage(exception.Message, IntegrationLogType.Error);
            }

            return null;
        }

        public string GetControlCode(WebProperties webProps, IntegrationLog log, string itemId, string control)
        {
            return string.Empty;
        }

        public string GetProxyResult(WebProperties webProps, IntegrationLog log, string itemId, string control,
            string property)
        {
            return string.Empty;
        }

        #endregion
    }
}