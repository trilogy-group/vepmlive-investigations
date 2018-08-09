using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solutions for the Pivot
    /// Viewer module
    /// </summary>
    internal static class PivotViewer
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorPvModule
                };
            }
        }

        internal static SocialSitesSolution NewsGatorPvModule =
            new SocialSitesSolution
            {
                SolutionId = new Guid("adad55b4-3bc1-4a01-a524-fa0d905ed6a5"),
                SolutionName = "NewsGator.PVModule.wsp",
                SolutionSet = SolutionSet.PivotViewer,
                MinimumVersion = 14,
                CompatibilityRange = "14,15",
                Required = true,
                InstallOrder = 10
            };
    }
}
