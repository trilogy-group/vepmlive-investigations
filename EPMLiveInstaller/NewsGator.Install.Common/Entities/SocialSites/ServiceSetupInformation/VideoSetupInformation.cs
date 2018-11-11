using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceSetupInformation
{
    internal static class VideoSetupInformation
    {
        internal static Type SetupInformationType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.VideoStream.VideoSetupInformationTypeFullName, NGAssemblies.VideoStream.NewsGatorVideoStreamCommonSharePoint);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        internal static string GetVersionInfo()
        {
            return Utilities.Reflection.ExecuteMethod(SetupInformationType, Activator.CreateInstance(SetupInformationType), "GetVersionInfo", new Type[] { }, null) as string;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        internal static object GetConfigRepository()
        {
            return Utilities.Reflection.ExecuteMethod(SetupInformationType, Activator.CreateInstance(SetupInformationType), "GetVideoConfigRepository", new Type[] { }, null) as object;
        }
    }
}
