using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel.Channels;
using UplandIntegrations.Tenrox.Infrastructure;
using UplandIntegrations.TenroxClientService;
using UserToken = UplandIntegrations.TenroxAuthService.UserToken;

namespace UplandIntegrations.Tenrox.Managers
{
    internal class ClientManager : ObjectManager
    {
        #region Constructors (1) 

        public ClientManager(Binding binding, string endpointAddress, UserToken token) :
            base(binding, endpointAddress, "clients.svc", token,
                typeof (Client), typeof (TenroxClientService.UserToken), typeof (ClientsClient)) { }

        #endregion Constructors 

        #region Overrides of ObjectManager

        protected override void BuildObjects(DataTable items, object client, List<string> columns,
            List<object> newObjects, List<object> existingObjects)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}