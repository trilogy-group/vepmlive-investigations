using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceInstances
{
    internal static class EnrichServiceInstance
    {
        internal static Type ServiceInstanceType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.Enrich.EnrichServiceInstanceTypeFullName, NGAssemblies.Enrich.NewsGatorLearningServiceLibrary);
            }
        }
    }
}
