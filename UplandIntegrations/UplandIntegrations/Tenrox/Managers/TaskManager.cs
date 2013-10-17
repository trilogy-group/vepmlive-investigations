using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using EPMLiveIntegration;
using UplandIntegrations.Tenrox.Infrastructure;
using UplandIntegrations.TenroxAssignmentService;
using UplandIntegrations.TenroxTaskService;
using Assignment = UplandIntegrations.TenroxAssignmentService.Assignment;
using Task = UplandIntegrations.TenroxTaskService.Task;
using UserToken = UplandIntegrations.TenroxAuthService.UserToken;

namespace UplandIntegrations.Tenrox.Managers
{
    internal class TaskManager : ObjectManager
    {
        #region Fields (4) 

        private readonly UserToken _authToken;
        private readonly HttpBindingBase _binding;
        private readonly string _endpointAddress;
        private readonly TenroxTaskService.UserToken _token;

        #endregion Fields 

        #region Constructors (1) 

        public TaskManager(HttpBindingBase binding, string endpointAddress, UserToken token)
            : base(binding, endpointAddress, "tasks.svc", token,
                typeof (Task), typeof (TenroxTaskService.UserToken), typeof (TasksClient))
        {
            _binding = binding;
            _endpointAddress = endpointAddress;
            _authToken = token;

            MappingDict = new Dictionary<string, string>
            {
                {"Name", "Title"},
                {"StartDate", "Start"},
                {"DueDate", "Finish"}
            };

            ObjectId = 10;

            _token = (TenroxTaskService.UserToken) Token;
        }

        #endregion Constructors 

        #region Methods (1) 

        // Private Methods (1) 

        private void AddTaskAssignments(IEnumerable<TenroxTransactionResult> upsertItems,
            EnumerableRowCollection<DataRow> rows)
        {
            using (var client = new AssignmentsClient(_binding,
                new EndpointAddress(_endpointAddress + "sdk/assignments.svc")))
            {
                var token = (TenroxAssignmentService.UserToken) TranslateToken(_authToken,
                    typeof (TenroxAssignmentService.UserToken));

                foreach (TenroxTransactionResult result in upsertItems.Where(result => result.Success))
                {
                    TenroxTransactionResult upsertResult = result;

                    DataRow row = (from r in rows
                        where r["SPID"].ToString().Equals(upsertResult.SpId.ToString(CultureInfo.InvariantCulture))
                        select r).FirstOrDefault();

                    if (row == null) continue;

                    foreach (Assignment assignment in client.QueryBy(token, "taskid = @0", new object[] {result.Id}))
                    {
                        try
                        {
                            client.Delete(token, assignment.UniqueId);
                        }
                        catch { }
                    }

                    var task = (Task) result.TxObject;

                    foreach (int userId in row["Assignment"].ToString().Split(',')
                        .Select(TranslateEmailToUserId).Where(userId => userId != 0))
                    {
                        Assignment assignment = client.CreateNew(token);

                        assignment.TaskId = result.Id;
                        assignment.UserId = userId;
                        if (task.StartDate != null) assignment.StartDate = task.StartDate.Value;
                        if (task.EndDate != null) assignment.EndDate = task.EndDate.Value;

                        client.Save(token, assignment);
                    }
                }
            }
        }

        #endregion Methods 

        #region Overrides of ObjectManager

        public override List<ColumnProperty> GetColumns()
        {
            List<ColumnProperty> columnProperties = base.GetColumns();

            columnProperties.Add(new ColumnProperty
            {
                ColumnName = "TimesheetHours",
                DefaultListColumn = "TimesheetHours",
                DiplayName = "Timesheet Hours",
                type = typeof (decimal)
            });

            columnProperties.Add(new ColumnProperty
            {
                ColumnName = "TimesheetBillableHours",
                DiplayName = "Timesheet Billable Hours",
                type = typeof (decimal)
            });

            return columnProperties;
        }

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
                        task.WorktypeId = 71;
                        task.StartDate = DateTime.Now;
                        task.Id = row["SPID"].ToString();
                    }
                    catch { }
                }

                if (task == null) continue;

                FillObjects(columns, newTasks, existingTasks, task, row);
            }
        }

        public override IEnumerable<TenroxTransactionResult> UpsertItems(DataTable items, Guid integrationId)
        {
            IEnumerable<TenroxTransactionResult> results = base.UpsertItems(items, integrationId);
            TenroxTransactionResult[] upsertItems = results as TenroxTransactionResult[] ?? results.ToArray();

            EnumerableRowCollection<DataRow> rows = items.AsEnumerable();

            try
            {
                AddTaskAssignments(upsertItems, rows);
            }
            catch (Exception exception)
            {
                throw new Exception("Could not process an assignment. Error: " + exception.Message);
            }

            return upsertItems;
        }

        #endregion
    }
}