using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceInstances
{
	internal static class InnovationServiceInstance
	{
		internal static Type ServiceInstanceType
		{
			get
			{
                return Utilities.Types.TryGetType(NGTypes.Innovation.InnovationServiceInstanceTypeFullName, NGAssemblies.Innovation.NewsGatorInnovationServiceLibrary);
			}
		}
	}
}