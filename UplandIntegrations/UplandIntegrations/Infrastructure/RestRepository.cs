using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace UplandIntegrations.Infrastructure
{
    internal class RestRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        #region Fields (3) 

        private const string ERROR_MESSAGE = "Could not process a request. Status: ({0}) {1}. Endpoint: [{2}] {3}";
        private readonly RestClient _client;
        private readonly string _resource;

        #endregion Fields 

        #region Constructors (1) 

        public RestRepository(RestClient client, string resource)
        {
            _client = client;
            _resource = resource;
        }

        #endregion Constructors 

        #region Properties (1) 

        protected virtual List<HttpStatusCode> ValidStatuCodes
        {
            get
            {
                return new List<HttpStatusCode>
                {
                    HttpStatusCode.OK,
                    HttpStatusCode.Created,
                    HttpStatusCode.NoContent
                };
            }
        }

        #endregion Properties 

        #region Methods (2) 

        // Protected Methods (2) 

        protected T Execute<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response = _client.Execute<T>(request);

            if (ValidStatuCodes.Contains(response.StatusCode))
            {
                return response.Data;
            }

            if (!string.IsNullOrEmpty(response.ErrorMessage)) throw new Exception(response.ErrorMessage);

            throw new Exception(string.Format(ERROR_MESSAGE,
                (int) response.StatusCode, response.StatusDescription, request.Method,
                _client.BaseUrl + "/" + request.Resource));
        }

        protected void Execute(IRestRequest request)
        {
            IRestResponse response = _client.Execute(request);

            if (!string.IsNullOrEmpty(response.ErrorMessage)) throw new Exception(response.ErrorMessage);

            throw new Exception(string.Format(ERROR_MESSAGE,
                (int) response.StatusCode, response.StatusDescription, request.Method,
                _client.BaseUrl + "/" + request.Resource));
        }

        #endregion Methods 

        #region Implementation of IRepository<TEntity>

        public virtual TEntity Add(TEntity entity)
        {
            return Execute<TEntity>(new RestRequest(_resource, Method.POST));
        }

        public virtual void Update(TEntity entity)
        {
            Execute<List<TEntity>>(new RestRequest(_resource, Method.PUT));
        }

        public virtual void Delete(string id)
        {
            string resource = (_resource.EndsWith("/") ? _resource : _resource + "/") + "{id}";

            var request = new RestRequest(resource, Method.DELETE);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            Execute(request);
        }

        public virtual IEnumerable<TEntity> Find(Dictionary<string, string> parameters)
        {
            var request = new RestRequest(_resource);

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value, ParameterType.UrlSegment);
            }

            return Execute<List<TEntity>>(request);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Execute<List<TEntity>>(new RestRequest(_resource));
        }

        #endregion
    }
}