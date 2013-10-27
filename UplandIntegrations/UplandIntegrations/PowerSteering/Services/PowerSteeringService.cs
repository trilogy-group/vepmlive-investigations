using System;
using System.Security;
using RestSharp;

namespace UplandIntegrations.PowerSteering.Services
{
    internal class PowerSteeringService
    {
        #region Fields (1) 

        private readonly RestClient _client;

        #endregion Fields 

        #region Constructors (1) 

        public PowerSteeringService(string serverUrl, string contextName, string apiKey, SecureString apiSecret)
        {
            _client = new RestClient
            {
                BaseUrl = new Uri(new Uri(serverUrl), contextName + "/rest").ToString(),
                Authenticator = new HttpBasicAuthenticator(apiKey, apiSecret.ToUnsecureString())
            };
        }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        public void TestConnection()
        {
            new MetadataService(_client).GetFields();
        }

        #endregion Methods 
    }
}