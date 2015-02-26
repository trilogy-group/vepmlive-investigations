using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;
using System.Net;
using Microsoft.Office.Project.Server.Library;

namespace EPMLiveEnterprise
{
    public class EventsDerived : WebSvcEvents.Events
    {
        public EventsDerived(string url)
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
    }
}
