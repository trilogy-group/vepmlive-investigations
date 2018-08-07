using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceApplicationProxies
{
    internal static class NewsManagerServiceApplicationProxy
    {
        internal static Type ServiceApplicationProxyType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.NewsStream.NewsManagerServiceApplicationProxyTypeFullName, NGAssemblies.NewsStream.NewsGatorNewsManagerClient);
            }
        }

        internal static Type LegacyServiceApplicationProxyType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.NewsStream.NewsManagerLegacyServiceApplicationProxyTypeFullName, NGAssemblies.NewsStream.NewsGatorNewsManagerClient);
            }
        }
    }
}
