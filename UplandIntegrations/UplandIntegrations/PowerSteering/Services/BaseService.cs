using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace UplandIntegrations.PowerSteering.Services
{
    internal abstract class BaseService
    {
        #region Fields (2) 

        private readonly RestClient _client;
        private readonly List<HttpStatusCode> _validStatuCodes;

        #endregion Fields 

        #region Constructors (1) 

        protected BaseService(RestClient client, string endpoint)
        {
            _client = client;
            _client.BaseUrl = new Uri(new Uri(client.BaseUrl), "rest/" + endpoint + "/v1").ToString();

            _validStatuCodes = new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
                HttpStatusCode.Created,
                HttpStatusCode.NoContent
            };
        }

        #endregion Constructors 

        #region Methods (1) 

        // Protected Methods (1) 

        protected T Execute<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response = _client.Execute<T>(request);

            if (_validStatuCodes.Contains(response.StatusCode))
            {
                return response.Data;
            }

            if (!string.IsNullOrEmpty(response.ErrorMessage)) throw new Exception(response.ErrorMessage);

            throw new Exception(string.Format("Could not process a request. Status: {0}. Endpoint: [{1}] {2}",
                response.StatusDescription, request.Method, _client.BaseUrl + request.Resource));
        }

        #endregion Methods 
    }
}