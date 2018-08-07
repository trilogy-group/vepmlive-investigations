using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceInstances
{
    internal static class SocialServiceInstance
    {
        internal static Type ServiceInstanceType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.SocialPlatform.SocialServiceInstanceTypeFullName, NGAssemblies.SocialPlatform.SocialSitesCoreApplicationServices);
            }
        }
    }
}
