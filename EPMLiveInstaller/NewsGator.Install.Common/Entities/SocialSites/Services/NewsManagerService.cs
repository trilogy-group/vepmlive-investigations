using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.Services
{
    internal static class NewsManagerService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static Type ServiceType
        {
            get
            {
                Type returnValue = null;

                try
                {
                    returnValue = Utilities.Types.TryGetType(NGTypes.NewsStream.NewsManagerServiceTypeFullName, NGAssemblies.NewsStream.NewsGatorNewsManagerApplication);
                }
                catch
                { }

                if (returnValue == null)
                {
                    try
                    {
                        returnValue = Utilities.Types.TryGetType(NGTypes.NewsStream.NewsManagerServiceTypeFullName, NGAssemblies.NewsStream.NewsGatorNewsManager);
                    }
                    catch
                    { }
                }

                return returnValue;
            }
        }
    }
}
