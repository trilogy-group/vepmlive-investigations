using System;
using System.ServiceModel;
using Tenrox.Shared.Utilities;
using UplandIntegrations.Tenrox.Managers;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal static class ObjectManagerFactory
    {
        #region Methods (1) 

        // Public Methods (1) 

        public static IObjectManager GetManager(string objectName, BasicHttpBinding binding, string endpointAddress,
            UserToken token)
        {
            switch (objectName.Trim().ToLower())
            {
                case "project":
                    return new ProjectManager(binding, endpointAddress, token);
                default:
                    throw new Exception(objectName + " is not a valid Tenrox object.");
            }
        }

        #endregion Methods 
    }
}