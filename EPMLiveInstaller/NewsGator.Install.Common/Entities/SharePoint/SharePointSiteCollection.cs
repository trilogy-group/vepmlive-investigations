using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointSiteCollection
    {
        [DataMember]
        internal Guid? Id { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string Url { get; set; }
        [DataMember]
        internal Collection<SharePointWeb> Webs { get; set; }
        [DataMember]
        internal Collection<SharePointEventReceiver> EventReceivers { get; set; }
        [DataMember]
        internal Collection<SharePointFeature> Features { get; set; }
        [DataMember]
        internal SharePointDatabase Database { get; set; }
    }
}
