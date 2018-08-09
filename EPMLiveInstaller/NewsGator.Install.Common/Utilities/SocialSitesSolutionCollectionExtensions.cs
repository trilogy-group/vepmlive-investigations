using System.Collections.Generic;
using System.Linq;
using NewsGator.Install.Common.Entities.SocialSites;
using NewsGator.Install.Common.Entities.Flags;

namespace NewsGator.Install.Common.Utilities
{
	internal static class SocialSitesSolutionCollectionExtensions
	{
		internal static bool IsSolutionSetComplete(this IEnumerable<SocialSitesSolution> collection)
		{
			return !collection.Any(p => (!p.Ignore) && (p.Required) && (!p.IsWspAvailable));
		}

		internal static IEnumerable<SocialSitesSolution> WhereSolutionSet(this IEnumerable<SocialSitesSolution> collection, SolutionSet set, int version)
		{
			return collection.Where(p => (p.SolutionSet == set) && (p.MinimumVersion <= version));
		}		
	}
}
