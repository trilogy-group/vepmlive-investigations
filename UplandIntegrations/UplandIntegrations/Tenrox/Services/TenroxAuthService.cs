﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18331
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://Tenrox.Server.Framework.WebServices.FaultContracts", ClrNamespace="tenrox.server.framework.webservices.faultcontracts")]

namespace Tenrox.Shared.Utilities
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserToken", Namespace="http://schemas.datacontract.org/2004/07/Tenrox.Shared.Utilities")]
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
namespace tenrox.server.framework.webservices.faultcontracts
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TenroxFaultContract", Namespace="http://Tenrox.Server.Framework.WebServices.FaultContracts")]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="LogonFaultContract", Namespace="http://Tenrox.Server.Framework.WebServices.FaultContracts")]
    public partial class LogonFaultContract : tenrox.server.framework.webservices.faultcontracts.TenroxFaultContract
    {
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="Tenrox.Server.Framework.Business.ServiceContracts", ConfigurationName="ILogonAs")]
public interface ILogonAs
{
    
    [System.ServiceModel.OperationContractAttribute(Action="LogonAs", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/AuthUserResponse")]
    string AuthUser(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox);
    
    [System.ServiceModel.OperationContractAttribute(Action="LogonAs", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/AuthUserResponse")]
    System.Threading.Tasks.Task<string> AuthUserAsync(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox);
    
    [System.ServiceModel.OperationContractAttribute(Action="LogonAsDesktop", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/AuthUserDesktopRespons" +
        "e")]
    string AuthUserDesktop(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox);
    
    [System.ServiceModel.OperationContractAttribute(Action="LogonAsDesktop", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/AuthUserDesktopRespons" +
        "e")]
    System.Threading.Tasks.Task<string> AuthUserDesktopAsync(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox);
    
    [System.ServiceModel.OperationContractAttribute(Action="LogonAsMobile", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/AuthUserMobileResponse" +
        "")]
    string AuthUserMobile(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox);
    
    [System.ServiceModel.OperationContractAttribute(Action="LogonAsMobile", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/AuthUserMobileResponse" +
        "")]
    System.Threading.Tasks.Task<string> AuthUserMobileAsync(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox);
    
    [System.ServiceModel.OperationContractAttribute(Action="Authenticate", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/AuthenticateResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(tenrox.server.framework.webservices.faultcontracts.LogonFaultContract), Action="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/AuthenticateLogonFault" +
        "ContractFault", Name="LogonFaultContract", Namespace="http://Tenrox.Server.Framework.WebServices.FaultContracts")]
    Tenrox.Shared.Utilities.UserToken Authenticate(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox);
    
    [System.ServiceModel.OperationContractAttribute(Action="Authenticate", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/AuthenticateResponse")]
    System.Threading.Tasks.Task<Tenrox.Shared.Utilities.UserToken> AuthenticateAsync(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox);
    
    [System.ServiceModel.OperationContractAttribute(Action="ImpersonateUser", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/ImpersonateUserRespons" +
        "e")]
    string ImpersonateUser(string p_strOrgName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox, int p_intIdToImpersonate);
    
    [System.ServiceModel.OperationContractAttribute(Action="ImpersonateUser", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/ImpersonateUserRespons" +
        "e")]
    System.Threading.Tasks.Task<string> ImpersonateUserAsync(string p_strOrgName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox, int p_intIdToImpersonate);
    
    [System.ServiceModel.OperationContractAttribute(Action="ImpersonateUserToken", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/ImpersonateUserTokenRe" +
        "sponse")]
    string ImpersonateUserToken(string p_strToken, int p_intIdToImpersonate);
    
    [System.ServiceModel.OperationContractAttribute(Action="ImpersonateUserToken", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/ImpersonateUserTokenRe" +
        "sponse")]
    System.Threading.Tasks.Task<string> ImpersonateUserTokenAsync(string p_strToken, int p_intIdToImpersonate);
    
    [System.ServiceModel.OperationContractAttribute(Action="ReinitializeToken", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/ReinitializeTokenRespo" +
        "nse")]
    bool ReinitializeToken(Tenrox.Shared.Utilities.UserToken p_userToken);
    
    [System.ServiceModel.OperationContractAttribute(Action="ReinitializeToken", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/ReinitializeTokenRespo" +
        "nse")]
    System.Threading.Tasks.Task<bool> ReinitializeTokenAsync(Tenrox.Shared.Utilities.UserToken p_userToken);
    
    [System.ServiceModel.OperationContractAttribute(Action="Reinitialize", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/ReinitializeResponse")]
    bool Reinitialize(string p_strOrgname, string p_strLogonName, System.Guid p_AuthenticationGuid);
    
    [System.ServiceModel.OperationContractAttribute(Action="Reinitialize", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/ReinitializeResponse")]
    System.Threading.Tasks.Task<bool> ReinitializeAsync(string p_strOrgname, string p_strLogonName, System.Guid p_AuthenticationGuid);
    
    [System.ServiceModel.OperationContractAttribute(Action="VerifyUserInCache", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/VerifyUserInCacheRespo" +
        "nse")]
    int VerifyUserInCache(string p_strOrgname, string p_strLogonName, string p_AuthenticationGuid);
    
    [System.ServiceModel.OperationContractAttribute(Action="VerifyUserInCache", ReplyAction="Tenrox.Server.Framework.Business.ServiceContracts/ILogonAs/VerifyUserInCacheRespo" +
        "nse")]
    System.Threading.Tasks.Task<int> VerifyUserInCacheAsync(string p_strOrgname, string p_strLogonName, string p_AuthenticationGuid);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ILogonAsChannel : ILogonAs, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class LogonAsClient : System.ServiceModel.ClientBase<ILogonAs>, ILogonAs
{
    
    public LogonAsClient()
    {
    }
    
    public LogonAsClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public LogonAsClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LogonAsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LogonAsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string AuthUser(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox)
    {
        return base.Channel.AuthUser(p_strOrgName, p_strUserName, p_strPassword, p_strIPAddress, p_boolForceTenrox);
    }
    
    public System.Threading.Tasks.Task<string> AuthUserAsync(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox)
    {
        return base.Channel.AuthUserAsync(p_strOrgName, p_strUserName, p_strPassword, p_strIPAddress, p_boolForceTenrox);
    }
    
    public string AuthUserDesktop(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox)
    {
        return base.Channel.AuthUserDesktop(p_strOrgName, p_strUserName, p_strPassword, p_strIPAddress, p_boolForceTenrox);
    }
    
    public System.Threading.Tasks.Task<string> AuthUserDesktopAsync(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox)
    {
        return base.Channel.AuthUserDesktopAsync(p_strOrgName, p_strUserName, p_strPassword, p_strIPAddress, p_boolForceTenrox);
    }
    
    public string AuthUserMobile(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox)
    {
        return base.Channel.AuthUserMobile(p_strOrgName, p_strUserName, p_strPassword, p_strIPAddress, p_boolForceTenrox);
    }
    
    public System.Threading.Tasks.Task<string> AuthUserMobileAsync(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox)
    {
        return base.Channel.AuthUserMobileAsync(p_strOrgName, p_strUserName, p_strPassword, p_strIPAddress, p_boolForceTenrox);
    }
    
    public Tenrox.Shared.Utilities.UserToken Authenticate(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox)
    {
        return base.Channel.Authenticate(p_strOrgName, p_strUserName, p_strPassword, p_strIPAddress, p_boolForceTenrox);
    }
    
    public System.Threading.Tasks.Task<Tenrox.Shared.Utilities.UserToken> AuthenticateAsync(string p_strOrgName, string p_strUserName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox)
    {
        return base.Channel.AuthenticateAsync(p_strOrgName, p_strUserName, p_strPassword, p_strIPAddress, p_boolForceTenrox);
    }
    
    public string ImpersonateUser(string p_strOrgName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox, int p_intIdToImpersonate)
    {
        return base.Channel.ImpersonateUser(p_strOrgName, p_strPassword, p_strIPAddress, p_boolForceTenrox, p_intIdToImpersonate);
    }
    
    public System.Threading.Tasks.Task<string> ImpersonateUserAsync(string p_strOrgName, string p_strPassword, string p_strIPAddress, bool p_boolForceTenrox, int p_intIdToImpersonate)
    {
        return base.Channel.ImpersonateUserAsync(p_strOrgName, p_strPassword, p_strIPAddress, p_boolForceTenrox, p_intIdToImpersonate);
    }
    
    public string ImpersonateUserToken(string p_strToken, int p_intIdToImpersonate)
    {
        return base.Channel.ImpersonateUserToken(p_strToken, p_intIdToImpersonate);
    }
    
    public System.Threading.Tasks.Task<string> ImpersonateUserTokenAsync(string p_strToken, int p_intIdToImpersonate)
    {
        return base.Channel.ImpersonateUserTokenAsync(p_strToken, p_intIdToImpersonate);
    }
    
    public bool ReinitializeToken(Tenrox.Shared.Utilities.UserToken p_userToken)
    {
        return base.Channel.ReinitializeToken(p_userToken);
    }
    
    public System.Threading.Tasks.Task<bool> ReinitializeTokenAsync(Tenrox.Shared.Utilities.UserToken p_userToken)
    {
        return base.Channel.ReinitializeTokenAsync(p_userToken);
    }
    
    public bool Reinitialize(string p_strOrgname, string p_strLogonName, System.Guid p_AuthenticationGuid)
    {
        return base.Channel.Reinitialize(p_strOrgname, p_strLogonName, p_AuthenticationGuid);
    }
    
    public System.Threading.Tasks.Task<bool> ReinitializeAsync(string p_strOrgname, string p_strLogonName, System.Guid p_AuthenticationGuid)
    {
        return base.Channel.ReinitializeAsync(p_strOrgname, p_strLogonName, p_AuthenticationGuid);
    }
    
    public int VerifyUserInCache(string p_strOrgname, string p_strLogonName, string p_AuthenticationGuid)
    {
        return base.Channel.VerifyUserInCache(p_strOrgname, p_strLogonName, p_AuthenticationGuid);
    }
    
    public System.Threading.Tasks.Task<int> VerifyUserInCacheAsync(string p_strOrgname, string p_strLogonName, string p_AuthenticationGuid)
    {
        return base.Channel.VerifyUserInCacheAsync(p_strOrgname, p_strLogonName, p_AuthenticationGuid);
    }
}
