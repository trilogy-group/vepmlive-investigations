using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointAccessRule
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal string Description { get; set; }
        [DataMember]
        internal string AllowedRights { get; set; }
        [DataMember]
        internal string AllowedObjectRights { get; set; }
    }
}
