using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security;
using EPMLiveIntegration;
using RestSharp;
using UplandIntegrations.Infrastructure;
using UplandIntegrations.PowerSteering.Entities;
using UplandIntegrations.PowerSteering.Infrastructure;

namespace UplandIntegrations.PowerSteering.Services
{
    internal class PowerSteeringService
    {
        #region Fields (1) 

        private readonly RestClient _client;

        #endregion Fields 

        #region Constructors (1) 

        public PowerSteeringService(string serverUrl, string contextName, string apiKey, SecureString apiSecret)
        {
            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };

            _client = new RestClient
            {
                BaseUrl = new Uri(new Uri(serverUrl), contextName + "/rest").ToString(),
                Authenticator = new HttpBasicAuthenticator(apiKey, apiSecret.ToUnsecureString())
            };

            _client.AddDefaultHeader("Accept", "application/xml, text/xml");
        }

        #endregion Constructors 

        #region Methods (8) 

        // Public Methods (5) 

        public IEnumerable<IntTransactionResult> DeleteItems(string objectName, string[] ids, Guid integrationId)
        {
            return GetManager(objectName).DeleteItems(ids, integrationId);
        }

        public List<ColumnProperty> GetObjectFields(string objectName)
        {
            return GetManager(objectName).GetColumns();
        }

        public void GetObjectItemsById(string objectName, string itemId, DataTable items)
        {
            List<string> columns = (from DataColumn column in items.Columns select column.ColumnName).ToList();

            IObjectManager objectManager = GetManager(objectName);
            foreach (IntObject intObject in objectManager.GetItems(GetIds(itemId).ToArray()))
            {
                object item = intObject.Item;
                if (item == null) continue;

                DataRow row = items.NewRow();

                foreach (string column in columns)
                {
                    try
                    {
                        object value;

                        switch (column)
                        {
                            case "ID":
                                value = GetValue(item, "Id");
                                break;
                            default:
                                value = GetValue(item, column);
                                break;
                        }

                        row[column] = value;
                    }
                    catch { }
                }

                items.Rows.Add(row);
            }
        }

        public void TestConnection()
        {
            GetManager("Project").GetColumns();
        }

        public IEnumerable<IntTransactionResult> UpsertItems(string objectName, DataTable items, Guid integrationId)
        {
            return GetManager(objectName).UpsertItems(items, integrationId);
        }

        // Private Methods (3) 

        private static IEnumerable<string> GetIds(string itemId)
        {
            return itemId.Split(',');
        }

        private IObjectManager GetManager(string objectName)
        {
            return ObjectManagerFactory.GetManager(objectName, _client);
        }

        private static object GetValue(object item, string property)
        {
            object value = null;

            var entity = ((Entity) item);

            foreach (var field in entity.Fields.Where(field => field.Key.ToLower().Equals(property.ToLower())))
            {
                value = entity.Fields[field.Key];
            }

            if (!property.ToLower().Contains("date")) return value;

            try
            {
                value = DateTime.Parse(value.ToString());
            }
            catch { }

            return value;
        }

        #endregion Methods 
    }
}