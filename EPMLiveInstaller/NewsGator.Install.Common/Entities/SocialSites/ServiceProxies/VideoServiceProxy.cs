using System;
using Microsoft.SharePoint.Administration;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceProxies
{
    internal static class VideoServiceProxy
    {
        internal static Type ServiceProxyType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.VideoStream.VideoServiceProxyTypeFullName, NGAssemblies.VideoStream.NewsGatorVideoStreamServiceLibrary);
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
            else
                return null;
        }
    }
}
