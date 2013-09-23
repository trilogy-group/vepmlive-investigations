using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.ServiceModel;
using EPMLiveIntegration;
using Tenrox.Shared.Utilities;
using UplandIntegrations.Tenrox.Infrastructure;

namespace UplandIntegrations.Tenrox.Services
{
    internal class TenroxService
    {
        #region Fields (3) 

        private readonly BasicHttpBinding _binding;
        private readonly string _svcUrl;
        private readonly UserToken _token;

        #endregion Fields 

        #region Constructors (1) 

        public TenroxService(string orgUrl, string orgName, string username, SecureString password)
        {
            _svcUrl = string.Format(@"{0}{1}twebservice/", orgUrl, orgUrl.EndsWith("/") ? string.Empty : "/");

            BasicHttpSecurityMode mode = orgUrl.StartsWith("https", StringComparison.InvariantCultureIgnoreCase)
                ? BasicHttpSecurityMode.Transport
                : BasicHttpSecurityMode.None;

            _binding = new BasicHttpBinding(mode) {MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue};

            var authEndpoint = new EndpointAddress(_svcUrl + "logonas.svc");
            using (var authService = new LogonAsClient(_binding, authEndpoint))
            {
                _token = authService.Authenticate(orgName, username, password.ToUnsecureString(), null, true);
            }
        }

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (2) 

        public List<ColumnProperty> GetObjectFields(string objectName)
        {
            return GetManager(objectName).GetColumns();
        }

        public void GetObjectItemsById(string objectName, string itemId, DataTable items)
        {
            List<string> columns = (from DataColumn column in items.Columns select column.ColumnName).ToList();

            foreach (TenroxObject txObject in GetManager(objectName).GetItems(GetIds(itemId).ToArray()))
            {
                object item = txObject.Item;
                if (item == null) continue;

                DataRow row = items.NewRow();

                foreach (string column in columns)
                {
                    try
                    {
                        object value;

                        switch (column)
                        {
                            case "SPID":
                                value = item.GetType().GetProperty("Id").GetValue(item);
                                break;
                            case "ID":
                                value = item.GetType().GetProperty("UniqueId").GetValue(item);
                                break;
                            default:
                                value = item.GetType().GetProperty(column).GetValue(item);
                                break;
                        }

                        row[column] = value;
                    }
                    catch { }
                }

                items.Rows.Add(row);
            }
        }

        // Private Methods (2) 

        private static IEnumerable<int> GetIds(string itemId)
        {
            foreach (string id in itemId.Split(','))
            {
                int i;
                if (int.TryParse(id, out i))
                {
                    yield return i;
                }
            }
        }

        private IObjectManager GetManager(string objectName)
        {
            return ObjectManagerFactory.GetManager(objectName, _binding, _svcUrl, _token);
        }

        #endregion Methods 
    }
}