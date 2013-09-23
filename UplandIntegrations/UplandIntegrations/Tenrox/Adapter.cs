using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using EPMLiveIntegration;
using UplandIntegrations.Tenrox.Services;

namespace UplandIntegrations.Tenrox
{
    public class Adapter : IIntegrator, IIntegratorControls
    {
        #region Methods (2) 

        // Private Methods (2) 

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
            throw new NotImplementedException();
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
                var txService = GetTenroxService(webProps);
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