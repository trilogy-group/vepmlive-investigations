using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceInstances
{
    internal static class NewsManagerServiceInstance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static Type ServiceInstanceType
        {
            get
            {
                Type returnValue = null;

                try
                {
                    returnValue = Utilities.Types.TryGetType(NGTypes.NewsStream.NewsManagerServiceInstanceTypeFullName, NGAssemblies.NewsStream.NewsGatorNewsManagerApplication);
                }
                catch
                { }

                if (returnValue == null)
                {
                    try
                    {
                        returnValue = Utilities.Types.TryGetType(NGTypes.NewsStream.NewsManagerServiceInstanceTypeFullName, NGAssemblies.NewsStream.NewsGatorNewsManager);
                    }
                    catch
                    { }
                }

                return returnValue;
            }
        }
    }
}
