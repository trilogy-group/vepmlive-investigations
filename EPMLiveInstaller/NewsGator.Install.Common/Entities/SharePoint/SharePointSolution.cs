using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointSolution
    {
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal Guid? Id { get; set; }
        [DataMember]
        internal bool? Deployed { get; set; }
        [DataMember]
        internal Collection<string> WebApplications { get; set; }
    }
}
