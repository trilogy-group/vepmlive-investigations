using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using UplandIntegrations.Tenrox.Infrastructure;
using UplandIntegrations.TenroxClientService;

namespace UplandIntegrations.Tenrox.Managers
{
    internal class ClientManager : ObjectManager
    {
        #region Fields (1) 

        private readonly UserToken _token;

        #endregion Fields 

        #region Constructors (1) 

        public ClientManager(Binding binding, string endpointAddress, TenroxAuthService.UserToken token) :
            base(binding, endpointAddress, "clients.svc", token,
                typeof (Client), typeof (UserToken), typeof (ClientsClient))
        {
            MappingDict = new Dictionary<string, string>
            {
                {"Name", "Title"}
            };

            ObjectId = 9;

            _token = (UserToken) Token;
        }

        #endregion Constructors 

        #region Overrides of ObjectManager

        protected override void BuildObjects(DataTable items, object client, List<string> columns,
            List<object> newClients, List<object> existingClients)
        {
            var clientsClient = (ClientsClient) client;

            foreach (DataRow row in items.Rows)
            {
                Client c = null;

                try
                {
                    c = clientsClient.QueryByUniqueId(_token, int.Parse(row["ID"].ToString()));
                }
                catch { }

                if (c == null)
                {
                    try
                    {
                        c = clientsClient.CreateNew(_token);
                        c.AccessType = 1;
                        c.IsPlaceholder = 0;
                        c.ParentId = 12;
                    }
                    catch { }
                }

                if (c == null) continue;

                Type type = c.GetType();

                foreach (
                    string column in
                        from column in columns
                        let col = column.ToLower()
                        where !col.Equals("id") && !col.Equals("spid")
                        select column)
                {
                    try
                    {
                        PropertyInfo property = type.GetProperty(column);
                        property.SetValue(c, GetValue(row[column], property));
                    }
                    catch { }
                }


                if (c.UniqueId > 0)
                {
                    existingClients.Add(c);
                }
                else
                {
                    newClients.Add(c);
                }
            }
        }

        #endregion
    }
}