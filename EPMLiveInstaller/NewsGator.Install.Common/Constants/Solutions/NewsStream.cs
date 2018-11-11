using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the News
    /// Stream module
    /// </summary>
    internal static class NewsStream
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorNewsManager,
                    NewsGatorNewsManagerApplication
                };
            }
        }

        internal static SocialSitesSolution NewsGatorNewsManager =
            new SocialSitesSolution
            {
                SolutionId = new Guid("f29d32bb-9ba5-490e-87cb-e9ee09c4e784"),
                SolutionName = "NewsGator.NewsManager.wsp",
                SolutionSet = SolutionSet.NewsStream,
                MinimumVersion = 14,
                CompatibilityRange = "14,15",
                Required = true,
                InstallOrder = 10
            };

        internal static SocialSitesSolution NewsGatorNewsManagerApplication =
            new SocialSitesSolution
            {
                SolutionId = new Guid("6d07a8f0-38f0-4370-854f-856783426b13"),
                SolutionName = "NewsGator.NewsManager.Application.wsp",
                SolutionSet = SolutionSet.NewsStream,
                MinimumVersion = 14,
                CompatibilityRange = "14,15",
                Required = true,
                InstallOrder = 20
            };
    }
}
