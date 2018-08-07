using System;
using System.Security.Permissions;
using Microsoft.SharePoint.Administration;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;
using NewsGator.Install.Common.Entities.SocialSites.Services;
using NewsGator.Install.Common.Constants;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceApplications
{
    internal static class SocialServiceApplication
    {
        internal static Type ServiceApplicationType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.SocialPlatform.SocialServiceApplicationTypeFullName, NGAssemblies.SocialPlatform.SocialSitesCoreApplicationServices);
            }
        }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPIisWebServiceApplication FindInstance()
        {
            return Utilities.ServiceApplication.FindServiceInstanceWhereOrDefault(x => x.GetType() == ServiceApplicationType);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate"), PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPIisWebServiceApplication GetInstance()
        {
            return LocalFarm.Get().GetObject(FarmIdentifiers.SocialServiceApplicationIdentifier) as SPIisWebServiceApplication;
        }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPPersistedObject Create(string name, SPPersistedObject service, SPIisWebServiceApplicationPool pool, SPDatabaseParameters dbParameters, SPDatabaseParameters rdbParameters)
        {
            return (SPPersistedObject)Utilities.Reflection.ExecuteMethod(ServiceApplicationType,
                ServiceApplicationType,
                "Create",
                new[] {
                    typeof(string),
                    SocialService.ServiceType,
                    typeof(SPIisWebServiceApplicationPool),
                    typeof(SPDatabaseParameters),
                    typeof(SPDatabaseParameters)
                },
                new object[]
                {
                    name,
                    service, 
                    pool,
                    dbParameters,
                    rdbParameters
                });
        }
    }
}
