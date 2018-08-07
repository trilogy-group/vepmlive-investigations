using System;
using NGAssemblies = NewsGator.Install.Common.Constants.Assemblies;
using NGTypes = NewsGator.Install.Common.Constants.TypeNames;

namespace NewsGator.Install.Common.Entities.SocialSites.ServiceApplicationProxies
{
	internal static class InnovationServiceApplicationProxy
	{
		internal static Type ServiceApplicationProxyType
		{
			get
			{
                return Utilities.Types.TryGetType(NGTypes.Innovation.InnovationServiceApplicationProxyTypeFullName, NGAssemblies.Innovation.NewsGatorInnovationServiceLibrary);
			}
		}
	}
}