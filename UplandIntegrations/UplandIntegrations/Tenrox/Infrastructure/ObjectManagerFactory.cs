using System;
using UplandIntegrations.Tenrox.Managers;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal static class ObjectManagerFactory
    {
        #region Methods (1) 

        // Public Methods (1) 

        public static IObjectManager GetManager(string objectName)
        {
            switch (objectName.Trim().ToLower())
            {
                case "project":
                    return new ProjectManager();
                default:
                    throw new Exception(objectName + " is not a valid Tenrox object.");
            }
        }

        #endregion Methods 
    }
}