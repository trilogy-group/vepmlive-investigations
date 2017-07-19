using System;
using System.DirectoryServices.AccountManagement;

namespace EPMLive.SSRSCustomAuthentication.AuthenticationProvider
{
    public class AdAuthenticationProvider : IAuthenticationProvider
    {
        public bool VerifyPassword(string userName, string password)
        {
            using (var domainContext = new PrincipalContext(ContextType.Domain))
            {
                return domainContext.ValidateCredentials(userName, password);
            }
        }

        public bool VerifyUser(string principalName)
        {
            using (var domainContext = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
            {
                using (var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, principalName))
                {
                    return foundUser != null;
                }
            }
        }
    }
}