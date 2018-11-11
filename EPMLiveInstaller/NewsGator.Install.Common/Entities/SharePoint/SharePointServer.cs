using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointServer
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal string Role { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
        [DataMember]
        internal string Address { get; set; }
        [DataMember]
        internal Collection<SharePointService> Services { get; set; }
        [DataMember]
        internal string Status { get; set; }
    }
}
