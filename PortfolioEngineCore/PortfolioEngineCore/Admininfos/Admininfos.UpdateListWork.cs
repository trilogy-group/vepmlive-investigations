using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PortfolioEngineCore
{
    public partial class Admininfos
    {
        /// <summary>
        /// Updates(replaces) Work for a PI - either Work1(Planner) or Work2(MSP).
        /// </summary>
        /// <param name="data">xmll defn of work.</param>
        /// <returns></returns>
        public bool UpdateListWork(string data, out string result)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "UpdateListWork", "Input", data);
                var cStruct = new CStruct();
                cStruct.LoadXML(data);

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();
                var tempResult = new CStruct();
                tempResult.Initialize("Data");

                var commandText = "Select * From EPG_GROUP_WEEKLYHOURS";
                DataTable dataTable1;
                DataTable dataTable2;

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection))
                {
                    dataTable1 = new DataTable();
                    dataTable1.Load(sqlCommand.ExecuteReader());
                }

                commandText = "Select * From EPG_GROUP_NONWORK_HOURS Order By GROUP_ID,NWH_DATE";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection))
                {
                    dataTable2 = new DataTable();
                    dataTable2.Load(sqlCommand.ExecuteReader());
                }

                var workHours = new AllWorkhours();
                workHours.Initialize(dataTable1, dataTable2);

                dataTable1.Dispose();
                dataTable2.Dispose();

                IDictionary<int, int> workHourGroups;
                IDictionary<int, int> holidayGroups;

                GetGroups(out workHourGroups, out holidayGroups);

                var canUpdate = ProcessProjects(cStruct, holidayGroups, workHourGroups, workHours, tempResult);

                result = tempResult.XML();

                var autoPosts = new int[10, 2];
                GetAutoPosts("ScheduledWork", ref autoPosts);

                if (autoPosts[0, 0] > 0)
                {
                    PostCostValuesForScheduledWork();
                }

                return canUpdate;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.UpdateListWork, exception.GetBaseMessage());
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        private void GetGroups(out IDictionary<int, int> workHourGroups, out IDictionary<int, int> holidayGroups)
        {
            workHourGroups = new Dictionary<int, int>();
            holidayGroups = new Dictionary<int, int>();
            const string CommandText = "select m.*,GROUP_ENTITY from EPG_GROUP_MEMBERS m Join EPG_GROUPS g On g.GROUP_ID=m.GROUP_ID Where (g.GROUP_ENTITY=10 Or g.GROUP_ENTITY=11)";

            using (var sqlCommand = new SqlCommand(CommandText, _sqlConnection))
            {
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        var groupId = SqlDb.ReadIntValue(sqlReader["GROUP_ID"]);
                        var groupEntity = SqlDb.ReadIntValue(sqlReader["GROUP_ENTITY"]);
                        var resourceId = SqlDb.ReadIntValue(sqlReader["MEMBER_UID"]);

                        if (groupEntity == 10)
                        {
                            workHourGroups.Add(resourceId, groupId);
                        }
                        else
                        {
                            holidayGroups.Add(resourceId, groupId);
                        }
                    }
                }
            }
        }

        private bool ProcessProjects(
            CStruct cStruct,
            IDictionary<int, int> holidayGroups,
            IDictionary<int, int> workHourGroups,
            AllWorkhours workHours,
            CStruct tempResult)
        {
            Utilities.ArgumentIsNotNull(tempResult, nameof(tempResult));
            Utilities.ArgumentIsNotNull(workHours, nameof(workHours));
            Utilities.ArgumentIsNotNull(workHourGroups, nameof(workHourGroups));
            Utilities.ArgumentIsNotNull(holidayGroups, nameof(holidayGroups));
            Utilities.ArgumentIsNotNull(cStruct, nameof(cStruct));

            SqlTransaction transaction = null;
            var canUpdate = true;

            foreach (var project in cStruct.GetList("Project"))
            {
                var extId = project.GetStringAttr("ExtId");
                var sourceId = project.GetIntAttr("Source");
                var projectId = 0;
                var totalRows = 0;
                var errorMessage = "empty";
                var warningMessage = string.Empty;

                errorMessage = ProcessWorkItems(
                    holidayGroups,
                    workHourGroups,
                    workHours,
                    extId,
                    errorMessage,
                    projectId,
                    project,
                    sourceId,
                    ref transaction,
                    ref totalRows,
                    ref warningMessage,
                    ref canUpdate);

                var subStructProject = tempResult.CreateSubStruct("Project");

                if (canUpdate)
                {
                    transaction?.Commit();

                    if (warningMessage.Length > 0)
                    {
                        subStructProject.CreateIntAttr("Status", 2);
                        subStructProject.CreateStringAttr("ExtId", extId);
                        subStructProject.CreateCDataSection($"Work rows added = {totalRows}{warningMessage}");
                    }
                    else
                    {
                        subStructProject.CreateIntAttr("Status", 0);
                        subStructProject.CreateStringAttr("ExtId", extId);
                        subStructProject.CreateCDataSection("Work rows added = " + totalRows);
                    }
                }
                else
                {
                    transaction?.Rollback();

                    subStructProject.CreateIntAttr("Status", 1);
                    subStructProject.CreateStringAttr("ExtId", extId);
                    subStructProject.CreateCDataSection(errorMessage);
                }

                transaction = null;
            }

            return canUpdate;
        }

        private string ProcessWorkItems(
            IDictionary<int, int> holidayGroups,
            IDictionary<int, int> workHourGroups,
            AllWorkhours workHours,
            string extId,
            string errorMessage,
            int projectId,
            CStruct project,
            int sourceId,
            ref SqlTransaction transaction,
            ref int totalRows,
            ref string warningMessage,
            ref bool canUpdate)
        {
            Utilities.ArgumentIsNotNull(warningMessage, nameof(warningMessage));
            Utilities.ArgumentIsNotNull(project, nameof(project));
            Utilities.ArgumentIsNotNull(errorMessage, nameof(errorMessage));
            Utilities.ArgumentIsNotNull(extId, nameof(extId));
            Utilities.ArgumentIsNotNull(workHours, nameof(workHours));
            Utilities.ArgumentIsNotNull(workHourGroups, nameof(workHourGroups));
            Utilities.ArgumentIsNotNull(holidayGroups, nameof(holidayGroups));

            if (IsBUpdateOk(extId, ref errorMessage, ref projectId))
            {
                transaction = _sqlConnection.BeginTransaction();
                var commandText = "Delete from EPGP_PI_WORK1 Where PROJECT_ID=@ProjectID";
                DeleteDuplicatedWork(transaction, commandText, projectId);

                var workItems = project.GetList("Item");

                foreach (var workItem in workItems)
                {
                    var workItemName = workItem.GetStringAttr("Id");
                    commandText = "Delete from EPGP_PI_WORK2 Where PW_ITEM_ID=@WIName";

                    using (var sqlCommand = new SqlCommand(commandText, _sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@WIName", workItemName);
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Transaction = transaction;
                        sqlCommand.ExecuteNonQuery();
                    }

                    commandText =
                        "INSERT Into EPGP_PI_WORK2 (PROJECT_ID,WRES_ID,PW_ITEM_ID,PW_SOURCE,PW_DATE,PW_WORK,PW_MAJORCATEGORY) Values (@ProjectID,@WresId,@WI,@WIExtId,@date,@hours,\'\')";

                    using (var sqlCommand = new SqlCommand(commandText, _sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProjectID", projectId);
                        sqlCommand.Transaction = transaction;

                        ProcessResources(
                            holidayGroups,
                            workHourGroups,
                            workHours,
                            sourceId,
                            ref totalRows,
                            ref warningMessage,
                            workItem,
                            sqlCommand,
                            workItemName);
                    }
                }

                errorMessage = UpdateResourcesNotIdentified(errorMessage, projectId, transaction, ref canUpdate);
            }

            return errorMessage;
        }

        private static void ProcessResources(
            IDictionary<int, int> holidayGroups,
            IDictionary<int, int> workHourGroups,
            AllWorkhours workHours,
            int sourceId,
            ref int totalRows,
            ref string warningMessage,
            CStruct workItem,
            SqlCommand sqlCommand,
            string workItemName)
        {
            Utilities.ArgumentIsNotNull(workItemName, nameof(workItemName));
            Utilities.ArgumentIsNotNull(sqlCommand, nameof(sqlCommand));
            Utilities.ArgumentIsNotNull(workItem, nameof(workItem));
            Utilities.ArgumentIsNotNull(warningMessage, nameof(warningMessage));
            Utilities.ArgumentIsNotNull(workHours, nameof(workHours));
            Utilities.ArgumentIsNotNull(workHourGroups, nameof(workHourGroups));
            Utilities.ArgumentIsNotNull(holidayGroups, nameof(holidayGroups));

            var listResources = workItem.GetList("Resource");

            foreach (var resource in listResources)
            {
                var hours = resource.GetDoubleAttr("Hours", 0);
                var sDate = resource.GetStringAttr("FinishDate");
                int holidayGroup;
                var resourceId = resource.GetIntAttr("Id");

                if (!holidayGroups.TryGetValue(resourceId, out holidayGroup))
                {
                    holidayGroup = -1;
                }

                int workHourGroup;

                if (!workHourGroups.TryGetValue(resourceId, out workHourGroup))
                {
                    workHourGroup = -1;
                }

                var workStartDate = DateTime.Parse(sDate);
                var workFinishDate = DateTime.Parse(sDate);

                if (workHours.Prorate(workHourGroup, holidayGroup, workStartDate, workFinishDate, hours))
                {
                    var thisDate = workStartDate;
                    var index = 0;
                    double getWorkHours;

                    while (workHours.Getwork(index, out getWorkHours))
                    {
                        if (getWorkHours > 0)
                        {
                            sqlCommand.Parameters.Add("@WresId", SqlDbType.Int).Value = resourceId;
                            sqlCommand.Parameters.Add("@WI", SqlDbType.NVarChar, 255).Value = workItemName;
                            sqlCommand.Parameters.Add("@WIExtId", SqlDbType.Int).Value = sourceId;
                            sqlCommand.Parameters.Add("@date", SqlDbType.Date).Value = thisDate;
                            sqlCommand.Parameters.Add("@hours", SqlDbType.Float).Value = getWorkHours;
                            var affectedRows = sqlCommand.ExecuteNonQuery();
                            totalRows += affectedRows;
                        }

                        thisDate = thisDate.AddDays(1);
                        index += 1;
                    }
                }
                else
                {
                    if (warningMessage.Length == 0)
                    {
                        warningMessage =
                            "  -- Work has not been imported for one or more resources, check date range and make sure resources have a WorkHours group assigned";
                    }
                }
            }
        }

        private string UpdateResourcesNotIdentified(string errorMessage, int projectId, SqlTransaction transaction, ref bool canUpdate)
        {
            Utilities.ArgumentIsNotNull(transaction, nameof(transaction));
            Utilities.ArgumentIsNotNull(errorMessage, nameof(errorMessage));

            if (canUpdate)
            {
                errorMessage = "These Resources are not defined:";
                var commandText = "Select DISTINCT WRES_ID From EPGP_PI_WORK2 Where PROJECT_ID=@ProjectId And WRES_ID Not In (Select WRES_ID From EPG_RESOURCES)";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ProjectId", projectId);
                    sqlCommand.Transaction = transaction;

                    using (var sqlReader = sqlCommand.ExecuteReader())
                    {
                        var errorMessageBuilder = new StringBuilder(errorMessage);

                        while (sqlReader.Read())
                        {
                            errorMessageBuilder.Append($" {SqlDb.ReadIntValue(sqlReader["WRES_ID"])}");
                            canUpdate = false;
                        }

                        errorMessage = errorMessageBuilder.ToString();
                    }
                }
            }

            return errorMessage;
        }
    }
}