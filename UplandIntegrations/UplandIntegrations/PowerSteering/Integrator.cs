using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using EPMLiveIntegration;
using UplandIntegrations.PowerSteering.Services;

namespace UplandIntegrations.PowerSteering
{
    public class Integrator : IIntegrator
    {
        #region Methods (2) 

        // Private Methods (2) 

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
            throw new NotImplementedException();
        }

        public DataTable PullData(WebProperties webProps, IntegrationLog log, DataTable items, DateTime lastSynchDate)
        {
            throw new NotImplementedException();
        }

        public DataTable GetItem(WebProperties webProps, IntegrationLog log, string itemId, DataTable items)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool RemoveIntegration(WebProperties webProps, IntegrationLog log, out string message,
            string integrationKey)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}