using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the InterComm
    /// module
    /// </summary>
    internal static class InterComm
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorCorpComm,
                    NewsGatorCorpCommApplication,
                    NewsGatorCorpCommSiteDefinitions,
                    NewsGatorCorpCommSiteDefinitionsFifteen
                };
            }
        }

        internal static SocialSitesSolution NewsGatorCorpComm =
            new SocialSitesSolution 
            {
                SolutionId = new Guid("c61dc981-6de2-43ff-8939-b6892ac59ad8"),
                SolutionName = "NewsGator.CorpComm.wsp", 
				SolutionSet = SolutionSet.InterComm, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 10
            };

        internal static SocialSitesSolution NewsGatorCorpCommApplication =
            new SocialSitesSolution 
            {
                SolutionId = new Guid("f61f89de-59ef-44dc-b908-311d3d0da528"),
                SolutionName = "NewsGator.CorpComm.Application.wsp", 
				SolutionSet = SolutionSet.InterComm, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 20
            };

        internal static SocialSitesSolution NewsGatorCorpCommSiteDefinitions =
            new SocialSitesSolution 
            {
                SolutionId = new Guid("f891c068-78b4-4876-99d1-36a3e5aafcc7"),
                SolutionName = "NewsGator.CorpComm.SiteDefinitions.wsp", 
				SolutionSet = SolutionSet.InterComm, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				InstallOrder = 30
            };

        internal static SocialSitesSolution NewsGatorCorpCommSiteDefinitionsFifteen =
            new SocialSitesSolution
            {
                SolutionId = new Guid("c980c46d-78af-4c67-87e9-132366be8ead"),
                SolutionName = "NewsGator.CorpComm.SiteDefinitions.Fifteen.wsp",
                SolutionSet = SolutionSet.InterComm,
                MinimumVersion = 15,
                InstallOrder = 40
            };                                        
    }
}
