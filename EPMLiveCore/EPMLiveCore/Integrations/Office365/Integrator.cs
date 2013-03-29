using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using EPMLiveCore.Integrations.Office365.Infrastructure;
using EPMLiveIntegration;

namespace EPMLiveCore.Integrations.Office365
{
    public class Integrator : IIntegrator
    {
        #region Methods (9) 

        // Public Methods (9) 

        public TransactionTable DeleteItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            throw new NotImplementedException();
        }

        public List<ColumnProperty> GetColumns(WebProperties webProps, IntegrationLog log, string listName)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetDropDownValues(WebProperties webProps, IntegrationLog log, string property,
                                                            string parentPropertyValue)
        {
            throw new NotImplementedException();
        }

        public DataTable GetItem(WebProperties webProps, IntegrationLog log, string itemId, DataTable items)
        {
            throw new NotImplementedException();
        }

        public bool InstallIntegration(WebProperties webProps, IntegrationLog log, out string message,
                                       string integrationKey,
                                       string apiUrl)
        {
            throw new NotImplementedException();
        }

        public DataTable PullData(WebProperties webProps, IntegrationLog log, DataTable items, DateTime lastSynchDate)
        {
            throw new NotImplementedException();
        }

        public bool RemoveIntegration(WebProperties webProps, IntegrationLog log, out string message,
                                      string integrationKey)
        {
            throw new NotImplementedException();
        }

        public bool TestConnection(WebProperties webProps, IntegrationLog log, out string message)
        {
            message = string.Empty;

            try
            {
                O365Service o365Service = GetO365Service(webProps);
                return o365Service.EnsureEPMLiveAppInstalled();
            }
            catch (Exception e)
            {
                message = e.Message;
                log.LogMessage(message, IntegrationLogType.Error);
            }

            return false;
        }

        public TransactionTable UpdateItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            throw new NotImplementedException();
        }

        #endregion Methods 

        private O365Service GetO365Service(WebProperties webProps)
        {
            string username;
            SecureString password;
            string url;

            GetAuthParameters(webProps, out username, out password, out url);

            return new O365Service(username, password, url);
        }

        private static void GetAuthParameters(WebProperties webProps, out string username, out SecureString password,
                                              out string url)
        {
            username = webProps.Properties["Username"].ToString();
            if (string.IsNullOrEmpty(username)) throw new Exception("Please provide the username.");

            string pwd = webProps.Properties["Password"].ToString();
            if (string.IsNullOrEmpty(pwd)) throw new Exception("Please provide the password.");

            password = pwd.ToSecureString();

            url = webProps.Properties["URL"].ToString();
            if (string.IsNullOrEmpty(url)) throw new Exception("Please provide the Office 365 site url.");

            Uri uri;
            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uri))
            {
                throw new Exception(url + " is not a valid url.");
            }
        }
    }
}