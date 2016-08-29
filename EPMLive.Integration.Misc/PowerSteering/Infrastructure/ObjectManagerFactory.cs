using System;
using RestSharp;
using UplandIntegrations.Infrastructure;
using UplandIntegrations.PowerSteering.Managers;
using ProjectManager = UplandIntegrations.PowerSteering.Managers.ProjectManager;
using TaskManager = UplandIntegrations.PowerSteering.Managers.TaskManager;
using UserManager = UplandIntegrations.PowerSteering.Managers.UserManager;

namespace UplandIntegrations.PowerSteering.Infrastructure
{
    internal static class ObjectManagerFactory
    {
        #region Methods (1) 

        // Public Methods (1) 

        public static IObjectManager GetManager(string objectName, RestClient client)
        {
            switch (objectName.Trim().ToLower())
            {
                case "project":
                    return new ProjectManager(client);
                case "task":
                    return new TaskManager(client);
                case "organization":
                    return new OrganizationManager(client);
                case "user":
                    return new UserManager(client);
                default:
                    throw new Exception(objectName + " is not a valid PowerSteering object.");
            }
        }

        #endregion Methods 
    }
}