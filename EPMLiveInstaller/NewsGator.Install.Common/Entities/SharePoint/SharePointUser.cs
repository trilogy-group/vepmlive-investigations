using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointUser
    {
        [DataMember]
        internal string Username { get; set; }
        [DataMember]
        internal Collection<string> Permissions { get; set; }
    }
}
