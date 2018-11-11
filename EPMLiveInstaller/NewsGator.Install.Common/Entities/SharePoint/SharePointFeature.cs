using System;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    /// <summary>
    /// SharePoint Feature Details
    /// </summary>
    [DataContract]
    internal class SharePointFeature
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
        [DataMember]
        internal string Scope { get; set; }
    }
}
