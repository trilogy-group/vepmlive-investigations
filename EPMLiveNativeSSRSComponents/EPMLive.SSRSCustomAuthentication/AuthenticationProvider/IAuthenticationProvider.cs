namespace EPMLive.SSRSCustomAuthentication.AuthenticationProvider
{
    public interface IAuthenticationProvider
    {
        bool VerifyUser(string principalName);

        bool VerifyPassword(string userName, string password);
    }
}