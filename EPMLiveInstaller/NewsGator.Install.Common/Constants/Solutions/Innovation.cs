using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the Innovation
    /// module.
    /// </summary>
    internal static class Innovation
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>
	                {
                    NewsGatorInnovationApp,
					NewsGatorInnovationSiteDefinitions,
                    NewsGatorInnovationUi
                };
            }
        }

        internal static SocialSitesSolution NewsGatorInnovationApp =
            new SocialSitesSolution 
            {
                SolutionId = new Guid("4dd8c6df-cdd9-4d00-b599-2b46669ad8a3"),
                SolutionName = "NewsGator.Innovation.App.wsp", 
				SolutionSet = SolutionSet.Innovation,
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 10
            };

		internal static SocialSitesSolution NewsGatorInnovationSiteDefinitions =
			new SocialSitesSolution
			{
				SolutionId = new Guid("30ae8abd-2280-425b-969f-f1a6110c9d07"),
				SolutionName = "NewsGator.Innovation.SiteDefinitions.wsp",
				SolutionSet = SolutionSet.Innovation,
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
				InstallOrder = 20
			};

        internal static SocialSitesSolution NewsGatorInnovationUi =
            new SocialSitesSolution
            {
                SolutionId = new Guid("e18878f0-fd65-4658-aa83-88c853a90836"),
                SolutionName = "NewsGator.Innovation.UI.wsp",
                SolutionSet = SolutionSet.Innovation,
                CompatibilityRange = "14,15",
                MinimumVersion = 14,
                Required = true,
                InstallOrder = 30
            };
    }
}
