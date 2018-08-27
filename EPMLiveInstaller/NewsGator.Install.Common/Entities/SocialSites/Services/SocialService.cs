using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.Services
{
    internal static class SocialService
    {
        internal static Type ServiceType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.SocialPlatform.SocialServiceTypeFullName, NGAssemblies.SocialPlatform.SocialSitesCoreApplicationServices);
            }
        }
    }
}
