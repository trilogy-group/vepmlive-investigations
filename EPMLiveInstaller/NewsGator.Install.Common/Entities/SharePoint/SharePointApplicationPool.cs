using System;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointApplicationPool
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
        [DataMember]
        internal string ManagedAccount { get; set; }
        [DataMember]
        internal string ProcessAccount { get; set; }
        [DataMember]
        internal string TypeName { get; set; }
        [DataMember]
        internal string Username { get; set; }        
    }
}
