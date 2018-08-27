using System;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointService
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
        [DataMember]
        internal string Status { get; set; }
    }
}
