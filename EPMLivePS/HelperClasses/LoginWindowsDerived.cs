using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace EPMLiveEnterprise
{
    // Derive from LoginWindows class; include additional property and 
    // override the web request header.
    public class LoginWindowsDerived : WebSvcLoginWindows.LoginWindows
    {
        public LoginWindowsDerived(string url)
        {
            base.Url = url;            
        }

        public bool EnforceWindowsAuth { get; set; }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest request = base.GetWebRequest(uri);

            if (this.EnforceWindowsAuth)
            {
                request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            }
            return request;
        }
    }
}
