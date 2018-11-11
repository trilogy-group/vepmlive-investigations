using System;
using Microsoft.SharePoint.Administration;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;
using NewsGator.Install.Common.Entities.SocialSites.Services;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceApplications
{
    internal static class NewsManagerServiceApplication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static Type ServiceApplicationType
        {
            get
            {
                Type returnValue = null;

                try
                {
                    returnValue = Utilities.Types.TryGetType(NGTypes.NewsStream.NewsManagerServiceApplicationTypeFullName, NGAssemblies.NewsStream.NewsGatorNewsManagerApplication);
                }
                catch
                { }

                if (returnValue == null)
                {
                    try
                    {
                        returnValue = Utilities.Types.TryGetType(NGTypes.NewsStream.NewsManagerServiceApplicationTypeFullName, NGAssemblies.NewsStream.NewsGatorNewsManager);
                    }
                    catch
                    { }
                }

                return returnValue;
            }
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPIisWebServiceApplication FindInstance()
        {
            return Utilities.ServiceApplication.FindServiceInstanceWhereOrDefault(x => x.GetType() == ServiceApplicationType);
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPPersistedObject Create(string name, SPPersistedObject service, SPIisWebServiceApplicationPool pool, SPDatabaseParameters dbParameters)
        {
            return (SPPersistedObject)Utilities.Reflection.ExecuteMethod(ServiceApplicationType,
                ServiceApplicationType,
                "Create",
                new[] {
                    typeof(string),
                    NewsManagerService.ServiceType,
                    typeof(SPIisWebServiceApplicationPool),
                    typeof(SPDatabaseParameters)
                },
                new object[]
                {
                    name,
                    service, 
                    pool,
                    dbParameters
                });
        }
    }
}
