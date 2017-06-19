using EPMLive.SSRSCustomAuthentication.AuthenticationProvider;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Security.Principal;
using System.Web;

namespace EPMLive.SSRSCustomAuthentication
{
    public class AuthenticationExtension : IAuthenticationExtension2
    {
        private readonly IAuthenticationProvider authProvider;

        public AuthenticationExtension()
        {
            authProvider = new AdAuthenticationProvider();
        }

        public string LocalizedName
        {
            get
            {
                return null;
            }
        }

        public void GetUserInfo(out IIdentity userIdentity, out IntPtr userId)
        {
            if (HttpContext.Current != null && HttpContext.Current.User != null)
            {
                userIdentity = HttpContext.Current.User.Identity;
            }
            else
            {
                throw new NullReferenceException("Anonymous logon is not allowed!");
            }

            userId = IntPtr.Zero;
        }

        public void GetUserInfo(IRSRequestContext requestContext, out IIdentity userIdentity, out IntPtr userId)
        {
            userIdentity = null;

            if (requestContext.User != null)
            {
                userIdentity = requestContext.User;
            }

            userId = IntPtr.Zero;
        }

        public bool IsValidPrincipalName(string principalName)
        {
            return authProvider.VerifyUser(principalName);
        }

        public bool LogonUser(string userName, string password, string authority)
        {
            return authProvider.VerifyPassword(userName, password);
        }

        public void SetConfiguration(string configuration)
        {
            // Nothing to set in configuration
        }
    }
}