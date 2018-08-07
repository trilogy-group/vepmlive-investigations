using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointWebApplication
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
        [DataMember]
        internal Collection<SharePointSiteCollection> SiteCollections { get; set; }
        [DataMember]
        internal Collection<SharePointFeature> Features { get; set; }
        [DataMember]
        internal Collection<SharePointDatabase> Databases { get; set; }
        [DataMember]
        internal Collection<SharePointProperty> Properties { get; set; }
        [DataMember]
        internal string Status { get; set; }
        [DataMember]
        internal bool? IsCentralAdministration { get; set; }
        [DataMember]
        internal string UrlZoneDefault { get; set; }
        [DataMember]
        internal string UrlZoneIntranet { get; set; }
        [DataMember]
        internal string UrlZoneInternet { get; set; }
        [DataMember]
        internal string UrlZoneExtranet { get; set; }
        [DataMember]
        internal string UrlZoneCustom { get; set; }
    }
}
