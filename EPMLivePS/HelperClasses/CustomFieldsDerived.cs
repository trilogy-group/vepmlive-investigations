using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;
using System.Net;
using Microsoft.Office.Project.Server.Library;


namespace EPMLiveEnterprise
{
    public class CustomFieldsDerived : WebSvcCustomFields.CustomFields
    {

        public CustomFieldsDerived(string url)
        {
            base.Url = url;            
        }

        //private static String ContextString = String.Empty;
        public bool EnforceWindowsAuth { get; set; }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            //here we are overriding the GetWebRequest method and adding the 2 web request headers
            WebRequest webRequest = base.GetWebRequest(uri);

            if (this.EnforceWindowsAuth)
            {
                webRequest.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            }
            return webRequest;
        }

        //public static void SetImpersonationContext(bool isWindowsUser, String userNTAccount, Guid userGuid, Guid trackingGuid, Guid siteId, String lcid)
        //{
        //    ContextString = GetImpersonationContext(isWindowsUser, userNTAccount, userGuid, trackingGuid, siteId, lcid);
        //}

        //private static String GetImpersonationContext(bool isWindowsUser, String userNTAccount, Guid userGuid, Guid trackingGuid, Guid siteId, String lcid)
        //{
        //    PSContextInfo contextInfo = new PSContextInfo(isWindowsUser, userNTAccount, userGuid, trackingGuid, siteId, lcid);
        //    String contextString = PSContextInfo.SerializeToString(contextInfo);
        //    return contextString;
        //}
    }
}
