using System;
using Microsoft.SharePoint.Administration;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;
using NewsGator.Install.Common.Entities.SocialSites.Services;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceApplications
{
    internal static class EnrichServiceApplication
    {
        internal static Type ServiceApplicationType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.Enrich.EnrichServiceApplicationTypeFullName, NGAssemblies.Enrich.NewsGatorLearningServiceLibrary);
            }
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPIisWebServiceApplication FindInstance()
        {
            return Utilities.ServiceApplication.FindServiceInstanceWhereOrDefault(x => x.GetType() == ServiceApplicationType);
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPIisWebServiceApplication FindInstanceByTypeName()
        {
            return Utilities.ServiceApplication.FindServiceInstanceWhereOrDefault(x => x.GetType().FullName == NGTypes.Enrich.EnrichServiceApplicationTypeFullName);
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPPersistedObject Create(string name, SPPersistedObject service, SPIisWebServiceApplicationPool pool)
        {
            return (SPPersistedObject)Utilities.Reflection.ExecuteMethod(ServiceApplicationType,
                ServiceApplicationType,
                "Create",
                new[] {
                    typeof(string),
                    EnrichService.ServiceType,
                    typeof(SPIisWebServiceApplicationPool)
                },
                new object[]
                {
                    name,
                    service, 
                    pool
                });
        }
    }
}
