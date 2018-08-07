using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint solutions for the Video
    /// Stream module
    /// </summary>
    internal static class VideoStream
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorVideoStreamApp,
                    NewsGatorVideoStreamApplication,
                    NewsGatorVideoStreamAppSp2013,
                    NewsGatorVideoStreamKontikiIntegration,
                    NewsGatorVideoStreamUi,
                    NewsGatorVideoStreamUiSp2013,
                    NewsGatorVideoStreamSiteDefinitions
                };
            }
        }

        internal static SocialSitesSolution NewsGatorVideoStreamApp =
            new SocialSitesSolution 
            {
                SolutionId = new Guid("9d45fb1e-449d-47cf-9ed1-5446b2df97c6"),
                SolutionName = "NewsGator.VideoStream.App.wsp",
                SolutionSet = SolutionSet.VideoStream, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 10 
            };

        internal static SocialSitesSolution NewsGatorVideoStreamUi =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("7a0fee4a-a1ea-495c-be0e-81d96737952f"),
                SolutionName = "NewsGator.VideoStream.UI.wsp",
                SolutionSet = SolutionSet.VideoStream, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 20
            };

        internal static SocialSitesSolution NewsGatorVideoStreamAppSp2013 =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("9defc99b-42a8-42e7-b7b7-42b061e0828d"),
                SolutionName = "NewsGator.VideoStream.App.SP2013.wsp",
                SolutionSet = SolutionSet.VideoStream, 
				MinimumVersion = 15, 
				Required = true,
                InstallOrder = 30
            };

        internal static SocialSitesSolution NewsGatorVideoStreamUiSp2013 =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("e8e6c961-fc1b-410e-8634-d7c08e401600"),
                SolutionName = "NewsGator.VideoStream.UI.SP2013.wsp",
                SolutionSet = SolutionSet.VideoStream, 
				MinimumVersion = 15, 
				Required = true,
                InstallOrder = 40 
            };

        internal static SocialSitesSolution NewsGatorVideoStreamKontikiIntegration =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("ce20e5d0-4550-41d0-8624-12802c7080a0"),
                SolutionName = "NewsGator.VideoStream.KontikiIntegration.wsp",
                SolutionSet = SolutionSet.VideoStream, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				InstallOrder = 50
            };

        internal static SocialSitesSolution NewsGatorVideoStreamApplication =
            new SocialSitesSolution
            {
                SolutionId = new Guid("3d24edff-701e-4c74-9e05-1929095e11ff"),
                SolutionName = "NewsGator.VideoStream.Application.wsp",
                SolutionSet = SolutionSet.VideoStream,
                MinimumVersion = 14,
                Ignore = true,
                InstallOrder = 60,
                RemoveIfFoundOnFarm = true
            };

        internal static SocialSitesSolution NewsGatorVideoStreamSiteDefinitions =
            new SocialSitesSolution
            {
                SolutionId = new Guid("b59ce528-a51e-44fe-a736-1f4ff0fbba0a"),
                SolutionName = "NewsGator.VideoStream.SiteDefinitions.wsp",
                SolutionSet = SolutionSet.VideoStream,
                MinimumVersion = 14,
                CompatibilityRange = "14,15",
                InstallOrder = 70,
                Required = false
            };
    }
}
