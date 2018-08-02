using System;
using Microsoft.SharePoint.Administration;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceProxies
{
    internal static class SocialServiceProxy
    {
        internal static Type ServiceProxyType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.SocialPlatform.SocialServiceProxyTypeFullName, NGAssemblies.SocialPlatform.NewsGatorSocialLibrary);
            }
        }

        internal static SPPersistedObject Get(SPServiceProxyCollection proxies)
        {
            if (proxies != null)
            {
                var method = proxies.GetType().GetMethod("GetValue", new Type[] { });
                var generic = method.MakeGenericMethod(ServiceProxyType);
                return (SPPersistedObject)generic.Invoke(proxies, null);
            }
            return
                null;
        }
    }
}
