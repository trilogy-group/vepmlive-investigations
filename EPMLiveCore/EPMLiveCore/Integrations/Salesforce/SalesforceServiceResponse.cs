using System.Runtime.Serialization;

namespace EPMLiveCore.Integrations.Salesforce
{
    [DataContract]
    internal class SalesforceServiceResponse
    {
        #region Properties (2) 

        [DataMember(Name = "Message")]
        public string Message { get; set; }

        [DataMember(Name = "Success")]
        public bool Success { get; set; }

        #endregion Properties 
    }
}