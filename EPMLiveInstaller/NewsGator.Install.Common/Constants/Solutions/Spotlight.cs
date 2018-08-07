using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solution for the Spotlight
    /// module
    /// </summary>
    internal static class Spotlight
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorSocialSpotlight,
                    NewsGatorSocialSpotlightApplication
                };
            }
        }

        internal static SocialSitesSolution NewsGatorSocialSpotlight =
            new SocialSitesSolution
            {
                SolutionId = new Guid("4c34553b-cc30-4e63-af01-4a509cf174e5"),
                SolutionName = "NewsGator.Social.Spotlight.wsp",
                SolutionSet = SolutionSet.Spotlight,
                MinimumVersion = 14,
                CompatibilityRange = "14,15",
                Required = true,
                InstallOrder = 10
            };

        internal static SocialSitesSolution NewsGatorSocialSpotlightApplication =
            new SocialSitesSolution
            {
                SolutionId = new Guid("f8078eda-270d-476f-aad3-6443dc72520d"),
                SolutionName = "NewsGator.Social.Spotlight.Application.wsp",
                SolutionSet = SolutionSet.Spotlight,
                MinimumVersion = 14,
                CompatibilityRange = "14,15",
                Required = true,
                InstallOrder = 20
            };
    }
}
