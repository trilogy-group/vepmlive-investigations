using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointList
    {
        [DataMember]
        internal string Title { get; set; }
        [DataMember]
        internal string Description { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
        [DataMember]
        internal Collection<SharePointEventReceiver> EventReceivers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string Url { get; set; }
        [DataMember]
        internal int? ItemCount { get; set; }
    }
}
