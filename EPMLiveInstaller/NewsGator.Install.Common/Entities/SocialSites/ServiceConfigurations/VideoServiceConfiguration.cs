﻿using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceConfigurations
{
    internal static class VideoServiceConfiguration
    {
        internal static Type ServiceConfigurationType
        {
            get
            {
                return Utilities.Types.TryGetType(NGTypes.VideoStream.VideoServiceConfigurationTypeFullName, NGAssemblies.VideoStream.NewsGatorVideoStreamCommon);
            }
        }
    }
}