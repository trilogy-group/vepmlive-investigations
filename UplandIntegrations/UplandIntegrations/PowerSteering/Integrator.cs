using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using EPMLiveIntegration;
using UplandIntegrations.Infrastructure;
using UplandIntegrations.PowerSteering.Services;

namespace UplandIntegrations.PowerSteering
{
    public class Integrator : IIntegrator, IIntegratorControls
    {
        #region Fields (2) 

        private const string PROJECT_INFO_URL = @"{0}/{1}/project/Summary1.epage?sp=U{2}";

        private const string UPSERT_ERROR_MESSAGE =
            @"Could not upsert record. PowerSteering ID: {0}. EPMLive ID: {1}. Reason: {2}";

        #endregion Fields 

        #region Methods (4) 

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

        private void GetAuthInfo(WebProperties webProps, out string serverUrl, out string contextName, out string apiKey,
            out SecureString apiSecret)
        {
            if (!webProps.Properties.ContainsKey("ServerUrl"))
            {
                throw new Exception("Please provide server url.");
            }

            serverUrl = webProps.Properties["ServerUrl"] as string;
            if (string.IsNullOrEmpty(serverUrl))
            {
                throw new Exception("Invalid server url.");
            }

            if (!webProps.Properties.ContainsKey("ContextName"))
            {
                throw new Exception("Please provide context name.");
            }

            contextName = webProps.Properties["ContextName"] as string;
            if (string.IsNullOrEmpty(contextName))
            {
                throw new Exception("Invalid context nname.");
            }

            if (!webProps.Properties.ContainsKey("APIKey"))
            {
                throw new Exception("Please provide API key.");
            }

            apiKey = webProps.Properties["APIKey"] as string;
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("Invalid API key.");
            }

            if (!webProps.Properties.ContainsKey("APISecret"))
            {
                throw new Exception("Please provide API secret.");
            }

            var sec = webProps.Properties["APISecret"] as string;
            if (string.IsNullOrEmpty(sec))
            {
                throw new Exception("Invalid API secret.");
            }

            apiSecret = sec.ToSecureString();
        }

        private PowerSteeringService GetPowerSteeringService(WebProperties webProps)
        {
            string serverUrl;
            string contextName;
            string apiKey;
            SecureString apiSecret;

            GetAuthInfo(webProps, out serverUrl, out contextName, out apiKey, out apiSecret);

            return new PowerSteeringService(serverUrl, contextName, apiKey, apiSecret);
        }

        private void ProcessResults(DataTable items, IntegrationLog log, IEnumerable<IntTransactionResult> results,
            Dictionary<string, string> idMap, TransactionTable transactionTable)
        {
            int index = 0;

            foreach (IntTransactionResult result in results)
            {
                string psId = result.Id;
                string spId;

                try
                {
                    spId = idMap[psId];
                }
                catch
                {
                    spId = items.Rows[index]["SPID"].ToString();
                }

                if (result.Success)
                {
                    transactionTable.AddRow(spId, psId, result.TransactionType);
                }
                else
                {
                    transactionTable.AddRow(spId, psId, TransactionType.FAILED);
                    log.LogMessage(string.Format(UPSERT_ERROR_MESSAGE, psId, spId, result.Error),
                        IntegrationLogType.Warning);
                }

                index++;
            }
        }

        #endregion Methods 

        #region Implementation of IIntegrator

        public TransactionTable UpdateItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                PowerSteeringService psService = GetPowerSteeringService(webProps);

                List<string> ids;
                Dictionary<string, string> idMap = BuildIdMap(items, out ids);

                IEnumerable<IntTransactionResult> results =
                    psService.UpsertItems((string) webProps.Properties["Object"],
                        items, webProps.IntegrationId);

                ProcessResults(items, log, results, idMap, transactionTable);
            }
            catch (Exception exception)
            {
                log.LogMessage(exception.Message, IntegrationLogType.Error);
            }

            return transactionTable;
        }

        public TransactionTable DeleteItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                PowerSteeringService psService = GetPowerSteeringService(webProps);

                List<string> ids;
                Dictionary<string, string> idMap = BuildIdMap(items, out ids);

                IEnumerable<IntTransactionResult> results =
                    psService.DeleteItems((string) webProps.Properties["Object"],
                        ids.ToArray(), webProps.IntegrationId);

                ProcessResults(items, log, results, idMap, transactionTable);
            }
            catch (Exception exception)
            {
                log.LogMessage(exception.Message.Replace("upsert", "remove"), IntegrationLogType.Error);
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

                return GetPowerSteeringService(webProps).GetObjectFields(objectName);
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, IntegrationLogType.Error);
            }

            return null;
        }

        public DataTable PullData(WebProperties webProps, IntegrationLog log, DataTable items, DateTime lastSynchDate)
        {
            return items;
        }

        public DataTable GetItem(WebProperties webProps, IntegrationLog log, string itemId, DataTable items)
        {
            try
            {
                PowerSteeringService psService = GetPowerSteeringService(webProps);
                psService.GetObjectItemsById((string) webProps.Properties["Object"], itemId, items);
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
                        {"Organization", "Organization"},
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

        public bool TestConnection(WebProperties webProps, IntegrationLog log, out string message)
        {
            message = null;

            try
            {
                GetPowerSteeringService(webProps).TestConnection();
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
            message = null;
            return true;
        }

        public bool RemoveIntegration(WebProperties webProps, IntegrationLog log, out string message,
            string integrationKey)
        {
            message = null;
            return true;
        }

        #endregion

        #region Implementation of IIntegratorControls

        public List<string> GetEmbeddedItemControls(WebProperties webProps, IntegrationLog log)
        {
            return new List<string>();
        }

        public List<IntegrationControl> GetPageButtons(WebProperties webProps, IntegrationLog log, bool globalButtons)
        {
            if (webProps.Properties["Object"].ToString().ToLower().Equals("project"))
            {
                return new List<IntegrationControl>
                {
                    new IntegrationControl
                    {
                        Control = "PS_ProjectInfo",
                        Title = "Project Information",
                        Image = "ps_projectinfo.png",
                        Window = IntegrationControlWindowStyle.FullDialog
                    }
                };
            }

            return new List<IntegrationControl>();
        }

        public string GetURL(WebProperties webProps, IntegrationLog log, string control, string itemId)
        {
            try
            {
                string serverUrl;
                string contextName;
                string apiKey;
                SecureString apiSecret;

                GetAuthInfo(webProps, out serverUrl, out contextName, out apiKey, out apiSecret);

                if (serverUrl.EndsWith("/"))
                {
                    serverUrl = serverUrl.Substring(0, serverUrl.Length - 1);
                }

                switch (control.ToLower())
                {
                    case "ps_projectinfo":
                        return string.Format(PROJECT_INFO_URL, serverUrl, contextName, itemId);
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