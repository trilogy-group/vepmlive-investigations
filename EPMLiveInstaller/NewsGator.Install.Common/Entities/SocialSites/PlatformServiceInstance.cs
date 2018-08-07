using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;
using NewsGator.Install.Common.Utilities;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    internal static class PlatformServiceInstance
    {
        internal static Type NewsGatorPlatformServiceInstanceType
        {
            get
            {
                return Types.TryGetType(NGTypes.SocialPlatform.SocialPlatformServiceInstanceTypeFullName, NGAssemblies.SocialPlatform.NewsGatorSocialLibrary);
            }
        }        
    }
}
