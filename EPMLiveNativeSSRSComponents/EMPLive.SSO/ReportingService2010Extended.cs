using EMPLive.SSO.ReportServer;
using System;
using System.Net;
using System.Web;

namespace EMPLive.SSO
{
    public class ReportingService2010Extended : ReportingService2010
    {
        private string cookieName;
        private Cookie authCookie;

        protected override WebRequest GetWebRequest(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.CookieContainer = new CookieContainer();

            if (!string.IsNullOrEmpty(cookieName))
            {
                request.CookieContainer.Add(authCookie);
            }
            request.Timeout = -1;

            if (HttpContext.Current != null && HttpContext.Current.Request.Headers["Accept-Language"] != null)
                request.Headers.Add("Accept-Language", HttpContext.Current.Request.Headers["Accept-Language"]);

            return request;
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            var response = base.GetWebResponse(request);
            if (string.IsNullOrEmpty(cookieName))
            {
                cookieName = response.Headers["RSAuthenticationHeader"];
                if (cookieName != null)
                {
                    var webResponse = (HttpWebResponse)response;
                    authCookie = webResponse.Cookies[cookieName];
                    if (authCookie == null)
                    {
                        throw new Exception(
                            "Authorization ticket not received by LogonUser");
                    }
                }
            }
            return response;
        }
    }
}