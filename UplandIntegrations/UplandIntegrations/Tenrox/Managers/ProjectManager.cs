using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Tenrox.Application.SDK;
using Tenrox.Shared.Utilities;
using UplandIntegrations.Tenrox.Infrastructure;

namespace UplandIntegrations.Tenrox.Managers
{
    internal class ProjectManager : ObjectManager
    {
        #region Constructors (1) 

        public ProjectManager(Binding binding, string endpointAddress, UserToken token)
            : base(binding, endpointAddress + "sdk/projects.svc", token, typeof (Project))
        {
            MappingDict = new Dictionary<string, string>
            {
                {"Name", "Title"},
                {"StartDate", "Start"},
                {"EndDate", "End"},
            };
        }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        public override IEnumerable<TenroxObject> GetItems(int[] itemIds)
        {
            var tasks = new List<Task<TenroxObject>>();

            using (var projectsClient = new ProjectsClient(Binding, EndpointAddress))
            {
                tasks.AddRange(itemIds.Select(id => Task<TenroxObject>.Factory.StartNew(() =>
                {
                    try
                    {
                        return new TenroxObject(id, projectsClient.QueryByUniqueId(Token, id));
                    }
                    catch (Exception exception)
                    {
                        return new TenroxObject(id, exception);
                    }
                })));

                foreach (var task in tasks)
                {
                    yield return task.Result;
                }
            }
        }

        #endregion Methods 
    }
}