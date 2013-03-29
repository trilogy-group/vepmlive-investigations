using System.Security;
using Microsoft.SharePoint.Client;

namespace EPMLiveCore.Integrations.Office365.Infrastructure
{
    internal class O365Service
    {
        #region Fields (3) 

        private readonly SecureString _password;
        private readonly string _url;
        private readonly string _username;

        #endregion Fields 

        #region Constructors (1) 

        internal O365Service(string username, SecureString password, string url)
        {
            _username = username;
            _password = password;
            _url = url;
        }

        #endregion Constructors 

        public bool EnsureEPMLiveAppInstalled()
        {
            throw new System.NotImplementedException();
        }

        private ClientContext GetClientContext()
        {
            return new ClientContext(_url)
            {
                Credentials = new SharePointOnlineCredentials(_username, _password)
            };
        }
    }
}