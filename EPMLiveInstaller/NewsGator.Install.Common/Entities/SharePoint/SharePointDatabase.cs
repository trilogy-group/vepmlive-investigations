using System;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointDatabase
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal string Username { get; set; }
        [DataMember]
        internal string Server { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
    }
}
