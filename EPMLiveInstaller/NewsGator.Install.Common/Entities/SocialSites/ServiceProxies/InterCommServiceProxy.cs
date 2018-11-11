using System;
using Microsoft.SharePoint.Administration;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceProxies
{
    internal static class InterCommServiceProxy
    {
        internal static Type ServiceProxyType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.InterComm.InterCommServiceProxyTypeFullName, NGAssemblies.InterComm.NewsGatorCorpCommCore);
            }
        }

        internal static SPPersistedObject Get(SPServiceProxyCollection proxies)
        {
            if (proxies == null)
                return null;

            var method = proxies.GetType().GetMethod("GetValue", new Type[] { });
            var generic = method.MakeGenericMethod(ServiceProxyType);
            return (SPPersistedObject)generic.Invoke(proxies, null);
        }
    }
}
