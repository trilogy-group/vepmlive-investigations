﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18444.
// 
#pragma warning disable 1591

namespace EPMLiveCore.UsageTracking {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SiteUsageTrackingSoap", Namespace="http://epmlive.com/")]
    public partial class SiteUsageTracking : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback PostUsageTrackingInfoToTotangoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SiteUsageTracking() {
            this.Url = "http://localhost:8080/UsageTracking/SiteUsageTracking.asmx";
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
        public event PostUsageTrackingInfoToTotangoCompletedEventHandler PostUsageTrackingInfoToTotangoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://epmlive.com/PostUsageTrackingInfoToTotango", RequestNamespace="http://epmlive.com/", ResponseNamespace="http://epmlive.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string PostUsageTrackingInfoToTotango(string siteGuid, string siteUrl, string siteName, string userEmail, string userName, string version, string pageTitle, string toolKitOrderNumber) {
            object[] results = this.Invoke("PostUsageTrackingInfoToTotango", new object[] {
                        siteGuid,
                        siteUrl,
                        siteName,
                        userEmail,
                        userName,
                        version,
                        pageTitle,
                        toolKitOrderNumber});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void PostUsageTrackingInfoToTotangoAsync(string siteGuid, string siteUrl, string siteName, string userEmail, string userName, string version, string pageTitle, string toolKitOrderNumber) {
            this.PostUsageTrackingInfoToTotangoAsync(siteGuid, siteUrl, siteName, userEmail, userName, version, pageTitle, toolKitOrderNumber, null);
        }
        
        /// <remarks/>
        public void PostUsageTrackingInfoToTotangoAsync(string siteGuid, string siteUrl, string siteName, string userEmail, string userName, string version, string pageTitle, string toolKitOrderNumber, object userState) {
            if ((this.PostUsageTrackingInfoToTotangoOperationCompleted == null)) {
                this.PostUsageTrackingInfoToTotangoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPostUsageTrackingInfoToTotangoOperationCompleted);
            }
            this.InvokeAsync("PostUsageTrackingInfoToTotango", new object[] {
                        siteGuid,
                        siteUrl,
                        siteName,
                        userEmail,
                        userName,
                        version,
                        pageTitle,
                        toolKitOrderNumber}, this.PostUsageTrackingInfoToTotangoOperationCompleted, userState);
        }
        
        private void OnPostUsageTrackingInfoToTotangoOperationCompleted(object arg) {
            if ((this.PostUsageTrackingInfoToTotangoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PostUsageTrackingInfoToTotangoCompleted(this, new PostUsageTrackingInfoToTotangoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void PostUsageTrackingInfoToTotangoCompletedEventHandler(object sender, PostUsageTrackingInfoToTotangoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PostUsageTrackingInfoToTotangoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PostUsageTrackingInfoToTotangoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591