using System.Collections.Generic;
using RestSharp;
using UplandIntegrations.PowerSteering.Entities;

namespace UplandIntegrations.PowerSteering.Services
{
    internal class MetadataService : BaseService
    {
        #region Constructors (1) 

        public MetadataService(RestClient client) : base(client, "metadataservice") { }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        public IEnumerable<Field> GetFields(string objectKind)
        {
            return Execute<List<Field>>(new RestRequest("upland/" + objectKind.ToLower()));
        }

        #endregion Methods 
    }
}