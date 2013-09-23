[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://Tenrox.Server.Framework.WebServices.FaultContracts", ClrNamespace = "tenrox.server.framework.webservices.faultcontracts")]

namespace tenrox.server.framework.webservices.faultcontracts
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "TenroxFaultContract", Namespace = "http://Tenrox.Server.Framework.WebServices.FaultContracts")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(tenrox.server.framework.webservices.faultcontracts.LogonFaultContract))]
    public partial class TenroxFaultContract : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int ErrorIdField;

        private string ErrorMessageField;

        private System.Guid CorrelationIdField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
        public int ErrorId
        {
            get
            {
                return this.ErrorIdField;
            }
            set
            {
                this.ErrorIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
        public string ErrorMessage
        {
            get
            {
                return this.ErrorMessageField;
            }
            set
            {
                this.ErrorMessageField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 2)]
        public System.Guid CorrelationId
        {
            get
            {
                return this.CorrelationIdField;
            }
            set
            {
                this.CorrelationIdField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "LogonFaultContract", Namespace = "http://Tenrox.Server.Framework.WebServices.FaultContracts")]
    public partial class LogonFaultContract : tenrox.server.framework.webservices.faultcontracts.TenroxFaultContract
    {
    }
}