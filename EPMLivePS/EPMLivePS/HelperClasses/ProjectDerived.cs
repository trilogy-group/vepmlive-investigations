using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;
using System.Net;
using Microsoft.Office.Project.Server.Library;


namespace EPMLiveEnterprise
{
    class ProjectDerived : WebSvcProject.Project
    {
        private static String ContextString = String.Empty;

        protected override WebRequest GetWebRequest(Uri uri)
        {            
            //here we are overriding the GetWebRequest method and adding the 2 web request headers
            WebRequest webRequest = base.GetWebRequest(uri);
            if (ContextString != String.Empty)
            {
                webRequest.UseDefaultCredentials = true;

                bool isImpersonating = (System.Security.Principal.WindowsIdentity.GetCurrent(true) != null);
                webRequest.Credentials = CredentialCache.DefaultNetworkCredentials;

                webRequest.Headers.Add("PjAuth", ContextString);
                webRequest.Headers.Add("ForwardFrom", "/_vti_bin/psi/pwa.asmx");

                webRequest.PreAuthenticate = true;
            }
            return webRequest;
        }

        public static void SetImpersonationContext(bool isWindowsUser, String userNTAccount, Guid userGuid, Guid trackingGuid, Guid siteId, String lcid)
        {
            ContextString = GetImpersonationContext(isWindowsUser, userNTAccount, userGuid, trackingGuid, siteId, lcid);
        }

        private static String GetImpersonationContext(bool isWindowsUser, String userNTAccount, Guid userGuid, Guid trackingGuid, Guid siteId, String lcid)
        {
            PSContextInfo contextInfo = new PSContextInfo(isWindowsUser, userNTAccount, userGuid, trackingGuid, siteId, lcid);
            String contextString = PSContextInfo.SerializeToString(contextInfo);
            return contextString;
        }
    }
}
