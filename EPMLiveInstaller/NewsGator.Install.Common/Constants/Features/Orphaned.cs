using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Features
{
    /// <summary>
    /// List of old NewsGator Social Sites Features to remove if found.
    /// </summary>
    internal static class Orphaned
    {
        internal static Collection<SocialSitesFeature> GetOrphanedFeaturesToRemove()
        {
            return new Collection<SocialSitesFeature>
	            {
                    new SocialSitesFeature() { FeatureName = "Old Video Feature", FeatureId = new Guid("47db2af8-7256-4f82-b025-7c1f5bdfa3de"), FeatureScope = Microsoft.SharePoint.SPFeatureScope.Web }
                };
        }
    }
}
