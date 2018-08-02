using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the Engagement Scorecard module
    /// </summary>
    internal static class Scorecard
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorSocialInsights,
                    NewsGatorEngagementScorecardWeb
                };
            }
        }

        internal static SocialSitesSolution NewsGatorSocialInsights =
            new SocialSitesSolution
            {
                SolutionId = new Guid("3dbe7334-c11e-4b48-b64a-f556d3c6b776"),
                SolutionName = "NewsGator.SocialInsights.wsp",
                SolutionSet = SolutionSet.Scorecard,
                MinimumVersion = 14,
                CompatibilityRange = "14,15",
                Required = true,
                RetractBeforeUpgrade = true,
                InstallOrder = 10
            };

        internal static SocialSitesSolution NewsGatorEngagementScorecardWeb =
            new SocialSitesSolution
            {
                SolutionId = new Guid(" af3f8bad-0557-4c1d-b962-9708ba7cc208"),
                SolutionName = "NewsGator.EngagementScorecard.Web.wsp",
                SolutionSet = SolutionSet.Scorecard,
                MinimumVersion = 14,
                CompatibilityRange = "14,15",
                Required = true,
                RetractBeforeUpgrade = true,
                InstallOrder = 20
            };
    }
}
