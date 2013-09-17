using System;
using System.Collections.Generic;
using System.Data;
using EPMLiveIntegration;

namespace UplandIntegrations.Tenrox
{
    public class Adapter : IIntegrator, IIntegratorControls
    {
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
            throw new NotImplementedException();
        }

        public bool TestConnection(WebProperties webProps, IntegrationLog log, out string message)
        {
            throw new NotImplementedException();
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