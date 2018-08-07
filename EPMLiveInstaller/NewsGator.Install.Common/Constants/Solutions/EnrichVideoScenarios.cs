using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the Enrich
    /// Video Scenarios module.
    /// </summary>
    internal static class EnrichVideoScenarios
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorLearningVideoScenariosApp,
                    NewsGatorLearningVideoScenariosAppSp2013,
                    NewsGatorLearningVideoScenariosUi,
                    NewsGatorLearningVideoScenariosUiSp2013
                };
            }
        }

        internal static SocialSitesSolution NewsGatorLearningVideoScenariosApp =
            new SocialSitesSolution 
            {
                SolutionId = new Guid("0b27064b-c9b7-4ab4-8526-427348d5b7fb"),
                SolutionName = "NewsGator.Learning.VideoScenarios.App.wsp", 
			    SolutionSet = SolutionSet.EnrichVideoScenarios, 
			    MinimumVersion = 14,
                CompatibilityRange = "14,15",
			    Required = true,
                InstallOrder = 10
            };

        internal static SocialSitesSolution NewsGatorLearningVideoScenariosUi = 
			new SocialSitesSolution 
            {
                SolutionId = new Guid("b3618f6b-f43e-463e-9a44-0fa0eb942bf5"),
                SolutionName = "NewsGator.Learning.VideoScenarios.UI.wsp", 
				SolutionSet = SolutionSet.EnrichVideoScenarios, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 20
            };

        internal static SocialSitesSolution NewsGatorLearningVideoScenariosAppSp2013 =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("37762f4f-aa25-4d7c-bfc5-4706637b4f3a"),
                SolutionName = "NewsGator.Learning.VideoScenarios.App.SP2013.wsp", 
				SolutionSet = SolutionSet.EnrichVideoScenarios, 
				MinimumVersion = 15, 
				Required = true,
                InstallOrder = 30
            };

        internal static SocialSitesSolution NewsGatorLearningVideoScenariosUiSp2013 =
            new SocialSitesSolution
            {
                SolutionId = new Guid("bd268d8b-9451-4169-b570-bdf4d7d63179"),
                SolutionName = "NewsGator.Learning.VideoScenarios.UI.SP2013.wsp",
                SolutionSet = SolutionSet.EnrichVideoScenarios,
                MinimumVersion = 15,
                InstallOrder = 40
            };
    }
}
