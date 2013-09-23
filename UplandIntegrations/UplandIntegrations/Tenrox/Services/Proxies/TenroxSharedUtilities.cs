namespace Tenrox.Shared.Utilities
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UserToken", Namespace = "http://schemas.datacontract.org/2004/07/Tenrox.Shared.Utilities")]
    public partial class UserToken : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private string AuthenticatedGuidField;

        private bool ForceTenroxField;

        private string IPAddressFieldField;

        private string OrgNameField;

        private string PasswordField;

        private int UniqueIdField;

        private string UserNameField;

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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AuthenticatedGuid
        {
            get
            {
                return this.AuthenticatedGuidField;
            }
            set
            {
                this.AuthenticatedGuidField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ForceTenrox
        {
            get
            {
                return this.ForceTenroxField;
            }
            set
            {
                this.ForceTenroxField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IPAddressField
        {
            get
            {
                return this.IPAddressFieldField;
            }
            set
            {
                this.IPAddressFieldField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrgName
        {
            get
            {
                return this.OrgNameField;
            }
            set
            {
                this.OrgNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password
        {
            get
            {
                return this.PasswordField;
            }
            set
            {
                this.PasswordField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UniqueId
        {
            get
            {
                return this.UniqueIdField;
            }
            set
            {
                this.UniqueIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName
        {
            get
            {
                return this.UserNameField;
            }
            set
            {
                this.UserNameField = value;
            }
        }
    }
}