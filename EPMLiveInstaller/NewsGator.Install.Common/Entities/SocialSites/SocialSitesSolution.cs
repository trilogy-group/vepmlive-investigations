using System;
using System.Runtime.Serialization;
using NewsGator.Install.Common.Entities.Flags;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    /// <summary>
    /// NewsGator Social Sites SharePoint Solution details.
    /// </summary>
    [DataContract, Serializable]
    public class SocialSitesSolution
    {
        /// <summary>
        /// (Rarely Used) Compatibility range flag to use when deploying to SharePoint 2013.
        /// </summary>
        [DataMember]
        public string CompatibilityRange { get; set; }
        /// <summary>
        /// Do not install the solution if found.
        /// </summary>
        [DataMember]
        public bool Ignore { get; set; }
        /// <summary>
        /// Version installed to the local SharePoint farm.
        /// </summary>
        [DataMember]
        public Version InstalledVersion { get; set; }
        /// <summary>
        /// Is installed on the local SharePoint farm.
        /// </summary>
        [DataMember]
        public bool IsInstalled { get; set; }
        /// <summary>
        /// Is available on the file system to the installer.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Wsp"), DataMember]
        public bool IsWspAvailable { get; set; }
        /// <summary>
        /// Minimum version of SharePoint required (14, 15, etc).
        /// </summary>
        [DataMember]
        public int MinimumVersion { get; set; }
        /// <summary>
        /// Required for the Solution Set.
        /// </summary>
        [DataMember]
        public bool Required { get; set; }
        /// <summary>
        /// SharePoint Solution ID
        /// </summary>
        [DataMember]
        public Guid SolutionId { get; set; }
        /// <summary>
        /// Solution File Name
        /// </summary>
        [DataMember]
        public string SolutionName { get; set; }
        /// <summary>
        /// Group the Solution belongs to
        /// </summary>
        [DataMember]
        public SolutionSet SolutionSet { get; set; }
        /// <summary>
        /// Order to install the solution within the Solution Set
        /// </summary>
        [DataMember]
        public int InstallOrder { get; set; }
        /// <summary>
        /// Retract and remove the solution before updating it
        /// </summary>
        [DataMember]
        public bool RetractBeforeUpgrade { get; set; }
        /// <summary>
        /// Remove the solution if found
        /// </summary>
        [DataMember]
        public bool RemoveIfFoundOnFarm { get; set; }
    }
}
