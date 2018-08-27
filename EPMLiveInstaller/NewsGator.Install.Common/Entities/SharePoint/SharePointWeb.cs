using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointWeb
    {
        [DataMember]
        internal string Title { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string Url { get; set; }
        [DataMember]
        internal Collection<SharePointFeature> Features { get; set; }
        [DataMember]
        internal Collection<SharePointEventReceiver> EventReceivers { get; set; }
        [DataMember]
        internal Collection<SharePointProperty> Properties { get; set; }
        [DataMember]
        internal string Description { get; set; }
        [DataMember]
        internal bool? IsRootWeb { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string MasterPageUrl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string CustomMasterPageUrl { get; set; }
        [DataMember]
        internal Guid? ParentWebId { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string LogoUrl { get; set; }
        [DataMember]
        internal int? UIVersion { get; set; }
        [DataMember]
        internal string WebTemplate { get; set; }
        [DataMember]
        internal Collection<SharePointList> Lists { get; set; }
    }
}
