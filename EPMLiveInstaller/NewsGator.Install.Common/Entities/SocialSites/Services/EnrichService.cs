using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.Services
{
    internal static class EnrichService
    {
        internal static Type ServiceType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.Enrich.EnrichServiceTypeFullName, NGAssemblies.Enrich.NewsGatorLearningServiceLibrary);
            }
        }
    }
}
