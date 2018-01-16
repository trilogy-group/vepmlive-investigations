﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ProjectPublisher2016.WSSService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://epmlive.com/")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback addUserToSiteOperationCompleted;
        
        private System.Threading.SendOrPostCallback getWebRequestsOperationCompleted;
        
        private System.Threading.SendOrPostCallback getSitesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service() {
            this.Url = global::ProjectPublisher2016.Properties.Settings.Default.ProjectPublisher2016_WSSService_Service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event addUserToSiteCompletedEventHandler addUserToSiteCompleted;
        
        /// <remarks/>
        public event getWebRequestsCompletedEventHandler getWebRequestsCompleted;
        
        /// <remarks/>
        public event getSitesCompletedEventHandler getSitesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://epmlive.com/addUserToSite", RequestNamespace="http://epmlive.com/", ResponseNamespace="http://epmlive.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string addUserToSite(string siteguid, string webguid, string email, string group) {
            object[] results = this.Invoke("addUserToSite", new object[] {
                        siteguid,
                        webguid,
                        email,
                        group});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void addUserToSiteAsync(string siteguid, string webguid, string email, string group) {
            this.addUserToSiteAsync(siteguid, webguid, email, group, null);
        }
        
        /// <remarks/>
        public void addUserToSiteAsync(string siteguid, string webguid, string email, string group, object userState) {
            if ((this.addUserToSiteOperationCompleted == null)) {
                this.addUserToSiteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddUserToSiteOperationCompleted);
            }
            this.InvokeAsync("addUserToSite", new object[] {
                        siteguid,
                        webguid,
                        email,
                        group}, this.addUserToSiteOperationCompleted, userState);
        }
        
        private void OnaddUserToSiteOperationCompleted(object arg) {
            if ((this.addUserToSiteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addUserToSiteCompleted(this, new addUserToSiteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://epmlive.com/getWebRequests", RequestNamespace="http://epmlive.com/", ResponseNamespace="http://epmlive.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet getWebRequests() {
            object[] results = this.Invoke("getWebRequests", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void getWebRequestsAsync() {
            this.getWebRequestsAsync(null);
        }
        
        /// <remarks/>
        public void getWebRequestsAsync(object userState) {
            if ((this.getWebRequestsOperationCompleted == null)) {
                this.getWebRequestsOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetWebRequestsOperationCompleted);
            }
            this.InvokeAsync("getWebRequests", new object[0], this.getWebRequestsOperationCompleted, userState);
        }
        
        private void OngetWebRequestsOperationCompleted(object arg) {
            if ((this.getWebRequestsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getWebRequestsCompleted(this, new getWebRequestsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://epmlive.com/getSites", RequestNamespace="http://epmlive.com/", ResponseNamespace="http://epmlive.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public SiteInfo[] getSites() {
            object[] results = this.Invoke("getSites", new object[0]);
            return ((SiteInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void getSitesAsync() {
            this.getSitesAsync(null);
        }
        
        /// <remarks/>
        public void getSitesAsync(object userState) {
            if ((this.getSitesOperationCompleted == null)) {
                this.getSitesOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetSitesOperationCompleted);
            }
            this.InvokeAsync("getSites", new object[0], this.getSitesOperationCompleted, userState);
        }
        
        private void OngetSitesOperationCompleted(object arg) {
            if ((this.getSitesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getSitesCompleted(this, new getSitesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://epmlive.com/")]
    public partial class SiteInfo {
        
        private string titleField;
        
        private string urlField;
        
        private string roleField;
        
        /// <remarks/>
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }
        
        /// <remarks/>
        public string role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void addUserToSiteCompletedEventHandler(object sender, addUserToSiteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class addUserToSiteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal addUserToSiteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void getWebRequestsCompletedEventHandler(object sender, getWebRequestsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getWebRequestsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getWebRequestsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void getSitesCompletedEventHandler(object sender, getSitesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getSitesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getSitesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public SiteInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((SiteInfo[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591