using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel.Channels;
using UplandIntegrations.Tenrox.Infrastructure;
using UplandIntegrations.TenroxTaskService;
using UserToken = UplandIntegrations.TenroxAuthService.UserToken;

namespace UplandIntegrations.Tenrox.Managers
{
    internal class TaskManager : ObjectManager
    {
        #region Constructors (1) 

        public TaskManager(Binding binding, string endpointAddress, UserToken token)
            : base(binding, endpointAddress, "tasks.svc", token,
                typeof (Task), typeof (TenroxTaskService.UserToken), typeof (TasksClient)) { }

        #endregion Constructors 

        #region Overrides of ObjectManager

        protected override void BuildObjects(DataTable items, object client, List<string> columns,
            List<object> newObjects, List<object> existingObjects)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}