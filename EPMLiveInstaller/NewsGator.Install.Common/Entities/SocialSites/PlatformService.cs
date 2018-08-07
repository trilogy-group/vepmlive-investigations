using System;
using Microsoft.SharePoint.Administration;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;
using NewsGator.Install.Common.Utilities;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    internal static class PlatformService
    {        
        internal static Type NewsGatorPlatformServiceType
        {
            get
            {
                return Types.TryGetType(NGTypes.SocialPlatform.SocialPlatformServiceTypeFullName, NGAssemblies.SocialPlatform.NewsGatorSocialLibrary);
            }
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPService Get()
        {
            return (SPService)Service.Get(NewsGatorPlatformServiceType);
        }
    }
}
