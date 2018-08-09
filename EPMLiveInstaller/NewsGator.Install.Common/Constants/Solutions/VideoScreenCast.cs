using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the Video
    /// ScreenCast module
    /// </summary>
    internal static class VideoScreenCast
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorScreenCastClickOnceDeployment
                };
            }
        }

        internal static SocialSitesSolution NewsGatorScreenCastClickOnceDeployment =
            new SocialSitesSolution
            {
                SolutionId = new Guid("a2610780-d6d0-4eb2-adbf-9857e1737e08"),
                SolutionName = "NewsGator.ScreenCast.ClickOnceDeployment.wsp",
                SolutionSet = SolutionSet.VideoScreenCast,
                MinimumVersion = 14,
                CompatibilityRange = "14,15",
                Required = true,
                InstallOrder = 10
            };
    }
}
