using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointServiceApplication
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
        [DataMember]
        internal Version Version { get; set; }
        [DataMember]
        internal string Status { get; set; }
        [DataMember]
        internal Collection<SharePointAccessRule> AccessRules { get; set; }
        [DataMember]
        internal Collection<SharePointAccessRule> AdminAccessRules { get; set; }
    }
}
