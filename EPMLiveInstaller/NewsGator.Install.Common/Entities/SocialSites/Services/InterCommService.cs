using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.Services
{
    internal static class InterCommService
    {
        internal static Type ServiceType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.InterComm.InterCommServiceTypeFullName, NGAssemblies.InterComm.NewsGatorCorpCommCore);
            }
        }
    }
}
