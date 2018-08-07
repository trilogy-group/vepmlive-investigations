using System;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Constants.Solutions
{
    /// <summary>
    /// NewsGator Social Sites SharePoint solutions for the Canadian
    /// modules
    /// </summary>
    internal static class CanadaCommon
    {
        internal static Collection<SocialSitesSolution> All
        {
            get
            {
                return new Collection<SocialSitesSolution>()
                {
                    NewsGatorCaCommonAssembliesApp,
                    NewsGatorCaCommonAssembliesAppSp2013,
                    NewsGatorCaCommonAssembliesUi,
                    NewsGatorCaCommonAssembliesUiSp2013
                };
            }
        }

        internal static SocialSitesSolution NewsGatorCaCommonAssembliesUi =
            new SocialSitesSolution 
            {
                SolutionId = new Guid("669700a1-3e88-436f-a543-314d7164b656"),
                SolutionName = "NewsGator.CA.CommonAssemblies.UI.wsp", 
				SolutionSet = SolutionSet.CanadaCommon, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 10
            };

        internal static SocialSitesSolution NewsGatorCaCommonAssembliesApp =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("c619c31f-ab56-4593-a50d-9b6a7a715dd1"),
                SolutionName = "NewsGator.CA.CommonAssemblies.App.wsp", 
				SolutionSet = SolutionSet.CanadaCommon, 
				MinimumVersion = 14,
                CompatibilityRange = "14,15",
				Required = true,
                InstallOrder = 20
            };

        internal static SocialSitesSolution NewsGatorCaCommonAssembliesAppSp2013 =
			new SocialSitesSolution 
            {
                SolutionId = new Guid("8dfc583f-ae97-4d89-af16-e5fd3366abc6"),
                SolutionName = "NewsGator.CA.CommonAssemblies.SP2013.wsp", 
				SolutionSet = SolutionSet.CanadaCommon, 
				MinimumVersion = 15, 
				Required = true,
                InstallOrder = 30
            };

        internal static SocialSitesSolution NewsGatorCaCommonAssembliesUiSp2013 =
            new SocialSitesSolution
            {
                SolutionId = new Guid("336302ce-2676-4f00-96da-71848c5c0e67"),
                SolutionName = "NewsGator.CA.CommonAssemblies.App.SP2013.wsp",
                SolutionSet = SolutionSet.CanadaCommon,
                MinimumVersion = 15,
                Required = true,
                InstallOrder = 40
            };
    }
}
