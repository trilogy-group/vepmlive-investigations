using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceApplicationProxies
{
    internal static class InterCommServiceApplicationProxy
    {
        internal static Type ServiceApplicationProxyType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.InterComm.InterCommServiceApplicationProxyTypeFullName, NGAssemblies.InterComm.NewsGatorCorpCommCore);
            }
        }
    }
}
