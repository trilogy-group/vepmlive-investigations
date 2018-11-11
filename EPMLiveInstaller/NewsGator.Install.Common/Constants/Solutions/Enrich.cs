using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.SocialSites;
using NewsGator.Install.Common.Entities.Flags;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the Enrich
    /// module
    /// </summary>
    internal static class Enrich
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorLearningPointApp,
                    NewsGatorLearningPointAppSp2013,
                    NewsGatorLearningPointUi,
                    NewsGatorLearningPointUiSp2013
                };
            }
        }

        internal static SocialSitesSolution NewsGatorLearningPointApp =
            new SocialSitesSolution {
                SolutionId = new Guid("ce7bc9d2-2bca-4f5a-afcd-7dca07f55f57"),
                SolutionName = "NewsGator.LearningPoint.App.wsp", 
				SolutionSet = SolutionSet.Enrich, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true ,
                InstallOrder = 10
            };

        internal static SocialSitesSolution NewsGatorLearningPointUi =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("b29d6e79-2848-423c-9212-934c0f205b0f"),
                SolutionName = "NewsGator.LearningPoint.Ui.wsp", 
				SolutionSet = SolutionSet.Enrich, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 20
            };

        internal static SocialSitesSolution NewsGatorLearningPointAppSp2013 =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("c955f21b-3606-440b-88da-897daba38606"),
                SolutionName = "NewsGator.LearningPoint.App.SP2013.wsp", 
				SolutionSet = SolutionSet.Enrich, 
				MinimumVersion = 15, 
				Required = true,
                InstallOrder = 30 
            };

        internal static SocialSitesSolution NewsGatorLearningPointUiSp2013 =
            new SocialSitesSolution
            {
                SolutionId = new Guid("4469c0fa-fd86-4655-b0c8-6bce506bb6e4"),
                SolutionName = "NewsGator.LearningPoint.UI.SP2013.wsp",
                SolutionSet = SolutionSet.Enrich,
                MinimumVersion = 15,
                Required = true,
                InstallOrder = 40
            };
    }
}
