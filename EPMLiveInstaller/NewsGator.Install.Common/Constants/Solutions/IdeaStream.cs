using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the Idea
    /// Stream module
    /// </summary>
    internal static class IdeaStream
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>
                {
					NewsGatorSocialIdeaModuleApplication,
                    NewsGatorSocialIdeaModule,
                    NewsGatorSocialIdeaModuleSites,
                    NewsGatorIdeaModuleFifteen,
//					NewsGatorIdeaApplicationOLD
                };
            }
        }

		internal static SocialSitesSolution NewsGatorSocialIdeaModuleApplication =
			new SocialSitesSolution
			{
				SolutionId = new Guid("54d49bba-b1c0-4607-86f9-c5fb5522c266"),
				SolutionName = "NewsGator.Social.IdeaModule.Application.wsp",
				SolutionSet = SolutionSet.IdeaStream,
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
				InstallOrder = 5
			};

        internal static SocialSitesSolution NewsGatorSocialIdeaModule =
            new SocialSitesSolution 
            {
                SolutionId = new Guid("3a0e2dd4-46f3-4fbe-8738-fbeaac39451d"),
                SolutionName = "NewsGator.Social.IdeaModule.wsp", 
	            SolutionSet = SolutionSet.IdeaStream, 
	            MinimumVersion = 14,
                CompatibilityRange = "14,15",
	            Required = true,
                InstallOrder = 10 
            };

        internal static SocialSitesSolution NewsGatorSocialIdeaModuleSites =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("551579e6-46ae-4dce-a71f-f37be1d3f544"),
                SolutionName = "NewsGator.Social.IdeaModule.Sites.wsp",
                SolutionSet = SolutionSet.IdeaStream, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 20 
            };

        internal static SocialSitesSolution NewsGatorIdeaModuleFifteen =
            new SocialSitesSolution
            {
                SolutionId = new Guid("a88b50a1-b7de-4ddf-a0f2-1d5219515365"),
                SolutionName = "NewsGator.IdeaModule.Fifteen.wsp",
                SolutionSet = SolutionSet.IdeaStream,
                MinimumVersion = 15,
                Required = true,
                InstallOrder = 30
            };

        //internal static SocialSitesSolution NewsGatorIdeaApplicationOLD =
        //new SocialSitesSolution
        //{
        //    SolutionId = new Guid("54d49bba-b1c0-4607-86f9-c5fb5522c266"),
        //    SolutionName = "NewsGator.IdeaApplication.wsp",
        //    SolutionSet = SolutionSet.IdeaStream,
        //    MinimumVersion = 14,
        //    Required = true,
        //    InstallOrder = 3
        //};
    }
}
