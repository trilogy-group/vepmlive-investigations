using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel.Channels;
using UplandIntegrations.Tenrox.Infrastructure;
using UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.Tenrox.Managers
{
    internal class TaskManager : ObjectManager
    {
        #region Fields (1) 

        private readonly UserToken _token;

        #endregion Fields 

        #region Constructors (1) 

        public TaskManager(Binding binding, string endpointAddress, TenroxAuthService.UserToken token)
            : base(binding, endpointAddress, "tasks.svc", token,
                typeof (Task), typeof (UserToken), typeof (TasksClient))
        {
            MappingDict = new Dictionary<string, string>
            {
                {"Name", "Title"},
                {"StartDate", "Start"},
                {"EndDate", "Finish"}
            };

            ObjectId = 10;

            _token = (UserToken) Token;
        }

        #endregion Constructors 

        #region Overrides of ObjectManager

        protected override void BuildObjects(DataTable items, object client, List<string> columns,
            List<object> newTasks, List<object> existingTasks)
        {
            var tasksClient = (TasksClient) client;

            foreach (DataRow row in items.Rows)
            {
                Task task = null;

                try
                {
                    task = tasksClient.QueryByUniqueId(_token, int.Parse(row["ID"].ToString()));
                }
                catch { }

                if (task == null)
                {
                    try
                    {
                        task = tasksClient.CreateNew(_token);
                        task.AccessType = 1;
                        task.Capitalized = 0;
                        task.IsBillable = 0;
                        task.IsCosted = 0;
                        task.IsFunded = 0;
                        task.IsRandD = 0;
                        task.StartDate = DateTime.Now;
                    }
                    catch { }
                }

                if (task == null) continue;

                FillObjects(columns, newTasks, existingTasks, task, row);
            }
        }

        #endregion
    }
}