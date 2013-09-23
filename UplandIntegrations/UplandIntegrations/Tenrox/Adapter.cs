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
    public class Adapter : IIntegrator, IIntegratorControls
    {
        #region Fields (1) 

        private const string UPSERT_ERROR_MESSAGE =
            @"Could not upsert record. Tenrox ID: {0}.EPMLive ID: {1}. Reason: {2}";

        #endregion Fields 

        #region Methods (3) 

        // Private Methods (3) 

        private static Dictionary<string, string> BuildIdMap(DataTable items, out List<string> ids)
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

        #endregion Methods 

        #region Implementation of IIntegrator

        public TransactionTable UpdateItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                TenroxService txService = GetTenroxService(webProps);

                List<string> ids;
                Dictionary<string, string> idMap = BuildIdMap(items, out ids);

                int index = 0;

                IEnumerable<TenroxUpsertResult> results = txService.UpsertItems((string) webProps.Properties["Object"],
                    items, webProps.IntegrationId, "EPM12345");

                foreach (TenroxUpsertResult result in results)
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
            catch (Exception exception)
            {
                log.LogMessage(exception.Message, IntegrationLogType.Error);
            }

            return transactionTable;
        }

        public TransactionTable DeleteItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            throw new NotImplementedException();
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

        public DataTable PullData(WebProperties webProps, IntegrationLog log, DataTable items, DateTime lastSynchDate)
        {
            throw new NotImplementedException();
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

                throw new Exception("Invalid property.");
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, IntegrationLogType.Error);
            }

            return null;
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
                message = e.Message;
                log.LogMessage(message, IntegrationLogType.Error);

                return false;
            }

            return true;
        }


        public bool InstallIntegration(WebProperties webProps, IntegrationLog log, out string message,
            string integrationKey,
            string apiUrl)
        {
            throw new NotImplementedException();
        }

        public bool RemoveIntegration(WebProperties webProps, IntegrationLog log, out string message,
            string integrationKey)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IIntegratorControls

        public List<string> GetLocalControls(WebProperties webProps, IntegrationLog log)
        {
            throw new NotImplementedException();
        }

        public List<IntegrationControl> GetRemoteControls(WebProperties webProps, IntegrationLog log)
        {
            throw new NotImplementedException();
        }

        public string GetURL(WebProperties webProps, IntegrationLog log, string control, string url)
        {
            throw new NotImplementedException();
        }

        public string GetControlCode(WebProperties webProps, IntegrationLog log, string itemId, string control)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}