using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.Caching
{
    internal static class CacheSettings
    {
        internal static Type CacheSettingsType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.SocialPlatform.CacheSettingsTypeFullName, NGAssemblies.SocialPlatform.NewsGatorCaching);
            }
        }
    }
}
