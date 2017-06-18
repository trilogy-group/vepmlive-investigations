using System;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Net;

namespace EPMLive.SSRSCustomAuthentication.AuthenticationProvider
{
    public class ADAuthenticationProvider : IAuthenticationProvider
    {
        public bool VerifyPassword(string userName, string password, out string error)
        {
            error = string.Empty;
            try
            {
                var credentials = new NetworkCredential(userName, password, Environment.UserDomainName);
                var ldapConnection = new LdapConnection(new LdapDirectoryIdentifier((string)null, false, false))
                {
                    Credential = credentials,
                    AuthType = AuthType.Negotiate
                };
                ldapConnection.Bind(credentials);
                return true;
            }
            catch (LdapException exception)
            {
                error = exception.Message;
                return false;
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