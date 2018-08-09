using System;
using Microsoft.SharePoint.Administration;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    internal static class Service
    {
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPPersistedObject Get(Type serviceType)
        {
            if (serviceType == null)
                return null;

            foreach (var service in LocalFarm.Get().Services)
            {
                if (string.Equals(service.GetType().FullName, serviceType.FullName, StringComparison.OrdinalIgnoreCase))
                {
                    return service;
                }
            }

            return null;

            //var farm = SPFarm.Local;
            //var services = farm.Services;

            //var method = services.GetType().GetMethod("GetValue", new Type[] { });
            //var generic = method.MakeGenericMethod(serviceType);

            //return (SPPersistedObject)generic.Invoke(services, null);
        }
    }
}
