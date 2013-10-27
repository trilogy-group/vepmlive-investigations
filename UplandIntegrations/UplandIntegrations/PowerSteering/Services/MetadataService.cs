using System;
using System.Collections.Generic;
using RestSharp;
using UplandIntegrations.Infrastructure;
using UplandIntegrations.PowerSteering.Entities;

namespace UplandIntegrations.PowerSteering.Services
{
    internal class MetadataService
    {
        #region Fields (4) 

        private readonly RestRepository<Field> _allObjRepository;
        private readonly RestRepository<Field> _orgRepository;
        private readonly RestRepository<Field> _projectRepository;
        private readonly RestRepository<Field> _taskRepository;

        #endregion Fields 

        #region Constructors (1) 

        public MetadataService(RestClient client)
        {
            client.BaseUrl = client.BaseUrl + "/metadataservice/v1";

            _allObjRepository = new RestRepository<Field>(client, "upland/all");
            _projectRepository = new RestRepository<Field>(client, "upland/project");
            _taskRepository = new RestRepository<Field>(client, "upland/task");
            _orgRepository = new RestRepository<Field>(client, "upland/organization");
        }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        public IEnumerable<Field> GetFields(string objectKind = null)
        {
            switch ((objectKind ?? string.Empty).ToLower())
            {
                case "project":
                    return _projectRepository.GetAll();
                case "task":
                    return _taskRepository.GetAll();
                case "organization":
                    return _orgRepository.GetAll();
                default:
                    return _allObjRepository.GetAll();
            }
        }

        #endregion Methods 
    }
}