using System;
using System.Security;
using System.ServiceModel;
using Tenrox.Shared.Utilities;

namespace UplandIntegrations.Tenrox.Services
{
    internal class TenroxService
    {
        #region Fields (2) 

        private BasicHttpBinding _binding;
        private UserToken _token;

        #endregion Fields 

        #region Constructors (1) 

        public TenroxService(string orgUrl, string orgName, string username, SecureString password)
        {
            string svcUrl = string.Format(@"{0}{1}twebservice/", orgUrl, orgUrl.EndsWith("/") ? string.Empty : "/");

            BasicHttpSecurityMode mode = orgUrl.StartsWith("https", StringComparison.InvariantCultureIgnoreCase)
                ? BasicHttpSecurityMode.Transport
                : BasicHttpSecurityMode.None;

            _binding = new BasicHttpBinding(mode) {MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue};

            var authEndpoint = new EndpointAddress(svcUrl + "logonas.svc");
            using (var authService = new LogonAsClient(_binding, authEndpoint))
            {
                _token = authService.Authenticate(orgName, username, password.ToUnsecureString(), null, true);
            }
        }

        #endregion Constructors 
    }
}