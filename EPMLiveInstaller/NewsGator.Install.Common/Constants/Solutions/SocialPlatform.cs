using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the NewsGator
    /// Social Platform
    /// </summary>
    internal static class SocialPlatform
    {
        internal static Collection<SocialSitesSolution> All 
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorInstallJobs,
                    SharePointAjaxLibrary,
                    NewsGatorApplicationFifteen,
                    NewsGatorBlankSite,
                    NewsGatorCommunities,
                    NewsGatorCommunityTemplates,
                    NewsGatorCore,
                    NewsGatorCoreApplication,
                    NewsGatorCoreFifteen,
                    NewsGatorApplicationSixteen,
                    NewsGatorDependencies,
                    NewsGatorSiteDefinitions,
                    NewsGatorSiteDefinitionsFifteen,
                    NewsGatorWorkflowActions,
                    NewsGatorSocialSearch,
                    NewsGatorSocialSearchFifteen,
                    NewsGatorOffice365,
                    NewsGatorSocialMobile
                };
            }
        }

        internal static SocialSitesSolution NewsGatorInstallJobs =
            new SocialSitesSolution
            {
                SolutionId = new Guid("155cc0fa-3137-4575-a2a3-16c27914838f"),
                SolutionName = "NewsGator.Install.Jobs.wsp",
                SolutionSet = SolutionSet.SocialPlatform,
                MinimumVersion = 14,
                Ignore = true
            };

        internal static SocialSitesSolution SharePointAjaxLibrary = 
            new SocialSitesSolution 
            { 
		        SolutionId = new Guid("874541a9-3936-4a22-bb53-a77f586a2a94"), 
		        SolutionName = "SharePoint.Ajax.Library.wsp", 
		        SolutionSet = SolutionSet.SocialPlatform, 
		        MinimumVersion = 14,
                CompatibilityRange = "14,15",
		        Required = true,
                InstallOrder = 10 
            };

		internal static SocialSitesSolution NewsGatorDependencies = 
            new SocialSitesSolution 
            {
			    SolutionId = new Guid("d841cabb-c5ac-49a6-89f4-0c32dbed5e74"), 
			    SolutionName = "NewsGator.Dependencies.wsp", 
			    SolutionSet = SolutionSet.SocialPlatform, 
			    MinimumVersion = 14, 
			    Required = true,
                RetractBeforeUpgrade = true,
                InstallOrder = 20,
                Ignore = true,
                RemoveIfFoundOnFarm = true
            };         
        
        internal static SocialSitesSolution NewsGatorCore =        
			new SocialSitesSolution 
            { 
				SolutionId = new Guid("2276df7b-4dc1-4d9c-9f02-fd5e7fbdaf16"), 
				SolutionName = "NewsGator.Core.wsp", 
				SolutionSet = SolutionSet.SocialPlatform, 
				MinimumVersion = 14, 
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 30
            };

        internal static SocialSitesSolution NewsGatorCoreApplication =
			new SocialSitesSolution 
            { 										 
				SolutionId = new Guid("a0568c57-9382-4c40-9229-2119d6a345d8"), 
				SolutionName = "NewsGator.Core.Application.wsp", 
				SolutionSet = SolutionSet.SocialPlatform, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,                                        
                InstallOrder = 40
            };

        internal static SocialSitesSolution NewsGatorCommunities =
			new SocialSitesSolution 
            {  
				SolutionId = new Guid("18d3eac6-d7de-4916-9f3c-708dfcaeddf7"), 
				SolutionName = "NewsGator.Communities.wsp", 
				SolutionSet = SolutionSet.SocialPlatform, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,        
                InstallOrder = 50
            };

        internal static SocialSitesSolution NewsGatorSiteDefinitions =
			new SocialSitesSolution 
            {  
				SolutionId = new Guid("61a408ca-9c3c-4653-802b-3ece307da72b"), 
				SolutionName = "NewsGator.SiteDefinitions.wsp", 
				SolutionSet = SolutionSet.SocialPlatform, 
				MinimumVersion = 14, 	 
				CompatibilityRange = "14,15", 
				Required = true,        
                InstallOrder = 60 
            };

        internal static SocialSitesSolution NewsGatorApplicationFifteen =
			new SocialSitesSolution 
            {  
				SolutionId = new Guid("716a2c76-3e54-42e1-a2dc-d0ed39d62c4a"), 
				SolutionName = "NewsGator.Application15.wsp", 
				SolutionSet = SolutionSet.SocialPlatform, 
				MinimumVersion = 15, 	 
				Required = true,        
                InstallOrder = 70
            };

        internal static SocialSitesSolution NewsGatorCoreFifteen =
			new SocialSitesSolution 
            {  
				SolutionId = new Guid("ddbd6848-a5a2-4201-85d7-102ba4018167"), 
				SolutionName = "NewsGator.Core.Fifteen.wsp", 
				SolutionSet = SolutionSet.SocialPlatform, 
				MinimumVersion = 15, 	 
				Required = true,        
                InstallOrder = 80
            };

        internal static SocialSitesSolution NewsGatorApplicationSixteen =
            new SocialSitesSolution
            {
                SolutionId = new Guid("071e1f1f-383e-4a36-88d0-6e0cdfef7105"),
                SolutionName = "NewsGator.Application16.wsp",
                SolutionSet = SolutionSet.SocialPlatform,
                MinimumVersion = 16,
                Required = true,
                InstallOrder = 85
            };

        internal static SocialSitesSolution NewsGatorSiteDefinitionsFifteen =
			new SocialSitesSolution
            {  
				SolutionId = new Guid("9e206ae1-c4e7-4d3b-88aa-aad8246d8b95"), 
				SolutionName = "NewsGator.SiteDefinitions.15.wsp", 
				SolutionSet = SolutionSet.SocialPlatform, 
				MinimumVersion = 15, 	 
				Required = true,        
                InstallOrder = 90 
            };

        internal static SocialSitesSolution NewsGatorBlankSite =
            new SocialSitesSolution 
            {  
			    SolutionId = new Guid("c180eee5-f987-4388-882e-11f24e6037de"), 
			    SolutionName = "NewsGator.BlankSite.wsp", 
			    SolutionSet = SolutionSet.SocialPlatform, 
			    MinimumVersion = 15,    
                InstallOrder = 100,
                Ignore = true,
                RemoveIfFoundOnFarm = true
            };

        internal static SocialSitesSolution NewsGatorCommunityTemplates =
            new SocialSitesSolution
            {
                SolutionId = new Guid("14441236-4af6-4914-b212-b78bf5f601e2"),
                SolutionName = "NewsGator.CommunityTemplates.wsp",
                SolutionSet = SolutionSet.SocialPlatform,
                MinimumVersion = 15,
                InstallOrder = 110,
                Ignore = true,
                RemoveIfFoundOnFarm = true
            };

        internal static SocialSitesSolution NewsGatorWorkflowActions = 
            new SocialSitesSolution
            {
                SolutionId = new Guid("b07886f4-68eb-4f7e-88f4-4ffe7472e3c2"),
                SolutionName = "NewsGator.WorkflowActions.wsp",
                SolutionSet = SolutionSet.SocialPlatform,
                MinimumVersion = 14,
                InstallOrder = 120,
                Ignore = true,
                RemoveIfFoundOnFarm = true
            };

        internal static SocialSitesSolution NewsGatorSocialSearch =
            new SocialSitesSolution
            {
                SolutionId = new Guid("9ed1f72e-652a-4b1c-be57-a15d2e84a9e6"),
                SolutionName = "NewsGator.Social.Search.wsp",
                SolutionSet = SolutionSet.SocialPlatform,
                MinimumVersion = 14,
                InstallOrder = 130,
                Ignore = true,
                RemoveIfFoundOnFarm = true
            };

        internal static SocialSitesSolution NewsGatorSocialSearchFifteen =
            new SocialSitesSolution
            {
                SolutionId = new Guid("5b936df4-0528-418a-b2df-e0cf98d590e3"),
                SolutionName = "NewsGator.Social.Search.Fifteen.wsp",
                SolutionSet = SolutionSet.SocialPlatform,
                MinimumVersion = 15,
                InstallOrder = 131,
                Ignore = true,
                RemoveIfFoundOnFarm = true
            };

        internal static SocialSitesSolution NewsGatorOffice365 =
            new SocialSitesSolution
            {
                SolutionId = new Guid("a9515838-a48c-4f91-8f3f-76a02111d3f9"),
                SolutionName = "NewsGator.Office365.wsp",
                SolutionSet = SolutionSet.SocialPlatform,
                MinimumVersion = 140,                
                InstallOrder = 10,
                Ignore = true,
                RemoveIfFoundOnFarm = true
            };

        internal static SocialSitesSolution NewsGatorSocialMobile =
            new SocialSitesSolution
            {
                SolutionId = new Guid("94cbe35b-fdee-47b3-95ea-212e4a264bc5"),
                SolutionName = "NewsGator.Social.Mobile.wsp",
                SolutionSet = SolutionSet.SocialPlatform,
                MinimumVersion = 14,
                InstallOrder = 10,
                Ignore = true,
                RemoveIfFoundOnFarm = true
            };
    }
}
