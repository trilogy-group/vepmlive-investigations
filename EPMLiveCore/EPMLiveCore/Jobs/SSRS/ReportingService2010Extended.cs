using EPMLiveCore.SSRS2010;
using System;
using System.Net;
using System.Web;

namespace EPMLiveCore.Jobs.SSRS
{
    public class ReportingService2010Extended : ReportingService2010
    {
        
        private string authCookies = null;

        protected override WebRequest GetWebRequest(Uri uri)
        {
            var request = base.GetWebRequest(uri);//(HttpWebRequest)WebRequest.Create(uri);

            if (authCookies != null && request is HttpWebRequest)
            {
                if (((HttpWebRequest)request).CookieContainer == null) ((HttpWebRequest)request).CookieContainer = new CookieContainer();
                ((HttpWebRequest)request).CookieContainer.SetCookies(uri, authCookies );
            }
            request.Timeout = -1;

            if (HttpContext.Current != null && HttpContext.Current.Request.Headers["Accept-Language"] != null)
                request.Headers.Add("Accept-Language", HttpContext.Current.Request.Headers["Accept-Language"]);

            return request;
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            var response = base.GetWebResponse(request);
            if (!string.IsNullOrEmpty(response.Headers["Set-Cookie"]))
            {
                authCookies = response.Headers["Set-Cookie"];
               
            }
            return response;
        }
    }
}