using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointProperty
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal object Value { get; set; }
    }
}
