using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceConfigurations
{
    internal static class EnrichServiceConfiguration
    {
        internal static Type ServiceConfigurationType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.Enrich.EnrichServiceConfigurationTypeFullName, NGAssemblies.Enrich.NewsGatorLearningCommon);
            }
        }
    }
}
