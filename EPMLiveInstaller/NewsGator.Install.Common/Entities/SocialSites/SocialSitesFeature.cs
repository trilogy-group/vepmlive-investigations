using System;
using Microsoft.SharePoint;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Feature Details
    /// </summary>
    internal class SocialSitesFeature
    {
        internal Guid FeatureId { get; set; }
        internal string FeatureName { get; set; }
        internal Version FeatureDefinitionVersion { get; set; }
        internal SPFeatureScope FeatureScope { get; set; }
        internal int SolutionInstallOrder { get; set; }
    }
}
