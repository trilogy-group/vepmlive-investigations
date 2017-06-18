using System;

namespace EPMLive.SSRSCustomAuthentication.AuthenticationProvider
{
    public class ADAuthenticationProvider : IAuthenticationProvider
    {
        public bool VerifyPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool VerifyUser(string principalName)
        {
            throw new NotImplementedException();
        }
    }
}