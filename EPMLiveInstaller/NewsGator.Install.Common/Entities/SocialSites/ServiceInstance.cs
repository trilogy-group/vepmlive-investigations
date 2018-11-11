using System;
using Microsoft.SharePoint.Administration;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    internal static class ServiceInstance
    {
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPPersistedObject Get(SPServer server, Type serviceType)
        {
            //var si = server.ServiceInstances;

            //var method = si.GetType().GetMethod("GetValue", new Type[] { });
            //var generic = method.MakeGenericMethod(serviceType);
            //return (SPPersistedObject)generic.Invoke(si, null);

            if ((server == null) || (serviceType == null))
                return null;

            foreach (var serviceInstance in server.ServiceInstances)
            {
                if (string.Equals(serviceInstance.GetType().FullName, serviceType.FullName, StringComparison.OrdinalIgnoreCase))
                {
                    return serviceInstance;
                }
            }

            return null;
        }
    }
}
