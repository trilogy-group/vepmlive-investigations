using System;
using System.ServiceModel;
using UplandIntegrations.Tenrox.Managers;
using UplandIntegrations.TenroxAuthService;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal static class ObjectManagerFactory
    {
        #region Methods (1) 

        // Public Methods (1) 

        public static IObjectManager GetManager(string objectName, HttpBindingBase binding, string endpointAddress,
            UserToken token)
        {
            switch (objectName.Trim().ToLower())
            {
                case "project":
                    return new ProjectManager(binding, endpointAddress, token);
                case "task":
                    return new TaskManager(binding, endpointAddress, token);
                case "client":
                    return new ClientManager(binding, endpointAddress, token);
                case "user":
                    return new UserManager(binding, endpointAddress, token);
                default:
                    throw new Exception(objectName + " is not a valid Tenrox object.");
            }
        }

        #endregion Methods 
    }
}