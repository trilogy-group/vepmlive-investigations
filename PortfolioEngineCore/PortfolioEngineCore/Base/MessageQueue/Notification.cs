using System.Runtime.Serialization;

namespace PortfolioEngineCore
{
    [DataContract]
    public class Notification
    {
        [DataMember]
        public string BasePath { get; set; }
    }
}