using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PortfolioEngineCore
{
    public partial class Admininfos
    {
        /// <summary>
        /// Updates a holiday schedule.
        /// </summary>
        /// <param name="xmlText">xml defn of Holiday Schedule.</param>
        /// <returns></returns>
        public bool UpdateHolidaySchedule(string xmlText, out string result)
        {
            Utilities.ArgumentIsNotNull(xmlText, nameof(xmlText));

            try
            {
                _dba.WriteImmTrace("DataSynch", "UpdateHolidaySchedule", "Input", xmlText);

                var cStruct = new CStruct();
                cStruct.LoadXML(xmlText);
                var tempResult = new CStruct();
                tempResult.Initialize("HolidaySchedule");
                var status = tempResult.CreateSubStruct("Result");

                var dataId = cStruct.GetStringAttr("DataId");

                if (dataId.Length > 0)
                {
                    tempResult.CreateStringAttr("DataId", dataId);
                }

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                var transaction = _sqlConnection.BeginTransaction();
                var existingTitle = string.Empty;
                var title = cStruct.GetStringAttr("Title");
                var id = cStruct.GetIntAttr("Id");
                var canContinue = ValidateHolidaySchedule(transaction, title, tempResult, status, ref id, ref existingTitle);

                if (canContinue)
                {
                    string commandText;

                    if (id > 0)
                    {
                        if (existingTitle != title)
                        {
                            commandText = @"Update EPG_GROUPS SET GROUP_NAME=@NewName Where GROUP_ID=@Id";
                            InsertOrUpdateEpgGroups(transaction, commandText, title, id);
                        }
                    }
                    else
                    {
                        commandText = "SELECT MAX(GROUP_ID) as MaxId FROM EPG_GROUPS";
                        InitializeId(transaction, commandText, out id);
                        commandText = "INSERT Into EPG_GROUPS (GROUP_ID,GROUP_NAME,GROUP_ENTITY) Values (@Id,@NewName,11)";
                        InsertOrUpdateEpgGroups(transaction, commandText, title, id);
                    }

                    PopulateNonWorkHours(cStruct, transaction, id);
                    ResetDefault(cStruct, transaction, id);
                    transaction.Commit();
                    AdminFunctions.CalcRPAllAvailabilities(_dba);
                    AdminFunctions.CalcAllDefaultFTEs(_dba);
                    tempResult.CreateIntAttr("Id", id);
                    status.CreateIntAttr("Status", 0);
                }

                result = tempResult.XML();
                return true;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new PFEException((int)PFEError.UpdateHolidaySchedule, exception.GetBaseMessage());
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        private void PopulateNonWorkHours(CStruct cStruct, SqlTransaction transaction, int id)
        {
            Utilities.ArgumentIsNotNull(transaction, nameof(transaction));
            Utilities.ArgumentIsNotNull(cStruct, nameof(cStruct));

            var nonWorkItemsId = id + 1000000;
            var commandText = "Delete From EPG_GROUP_NONWORK_ITEMS Where GROUP_ID=@Id";

            using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }

            commandText = "INSERT Into EPG_GROUP_NONWORK_ITEMS (GROUP_ID,NWI_ID,NWI_CHARGENUMBER) Values (@Id,@NWI_ID,@NWI_CN)";

            using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@NWI_ID", nonWorkItemsId);
                sqlCommand.Parameters.AddWithValue("@NWI_CN", string.Empty);
                sqlCommand.ExecuteNonQuery();
            }

            commandText = "Delete From EPG_GROUP_NONWORK_HOURS Where GROUP_ID=@Id";

            using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }

            var holidays = cStruct.GetList("Holiday");

            if (holidays != null && holidays.Count > 0)
            {
                commandText = "INSERT Into EPG_GROUP_NONWORK_HOURS (GROUP_ID,NWH_DATE,NWH_HOURS,NWH_COMMENT) Values (@Id,@NWI_Date,@NWI_Hours,@NWI_Title)";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
                {
                    var paramId = sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
                    var paramDate = sqlCommand.Parameters.Add("@NWI_Date", SqlDbType.DateTime);
                    var paramName = sqlCommand.Parameters.Add("@NWI_Title", SqlDbType.VarChar);
                    var paramHours = sqlCommand.Parameters.Add("@NWI_Hours", SqlDbType.Decimal);

                    foreach (var holiday in holidays)
                    {
                        var holidayDate = DateTime.Parse(holiday.GetStringAttr("Date"));
                        var holidayTitle = holiday.GetStringAttr("Title");
                        var holidayHours = holiday.GetDoubleAttr("Hours", 0);

                        if (holidayHours == 0)
                        {
                            holidayHours = 24;
                        }

                        paramId.Value = id;
                        paramDate.Value = holidayDate;
                        paramHours.Value = holidayHours * 100;
                        paramName.Value = holidayTitle;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private void ResetDefault(CStruct cStruct, SqlTransaction transaction, int id)
        {
            Utilities.ArgumentIsNotNull(transaction, nameof(transaction));
            Utilities.ArgumentIsNotNull(cStruct, nameof(cStruct));

            string commandText;
            var defaultValue = cStruct.GetStringAttr("Default");

            if (defaultValue == "1")
            {
                commandText = @"Update EPG_ADMIN Set ADM_DEF_FTE_HOL=@HOLId";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
                {
                    sqlCommand.Parameters.AddWithValue("@HOLId", id);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            else
            {
                var resetDefault = false;
                commandText = "SELECT ADM_DEF_FTE_WH,ADM_DEF_FTE_HOL FROM EPG_ADMIN";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
                {
                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            if (SqlDb.ReadIntValue(sqlDataReader["ADM_DEF_FTE_HOL"]) == id)
                            {
                                resetDefault = true;
                            }
                        }
                    }
                }

                if (resetDefault)
                {
                    commandText = @"Update EPG_ADMIN Set ADM_DEF_FTE_HOL=@HOLId";

                    using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
                    {
                        sqlCommand.Parameters.AddWithValue("@HOLId", 0);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private bool ValidateHolidaySchedule(
            SqlTransaction transaction,
            string title,
            CStruct tempResult,
            CStruct status,
            ref int id,
            ref string existingTitle)
        {
            Utilities.ArgumentIsNotNull(existingTitle, nameof(existingTitle));
            Utilities.ArgumentIsNotNull(status, nameof(status));
            Utilities.ArgumentIsNotNull(tempResult, nameof(tempResult));
            Utilities.ArgumentIsNotNull(title, nameof(title));
            Utilities.ArgumentIsNotNull(transaction, nameof(transaction));

            var isFound = false;

            if (id > 0)
            {
                var commandText = "SELECT GROUP_NAME FROM EPG_GROUPS Where GROUP_ID=@Id And GROUP_ENTITY=11";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection, transaction))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            existingTitle = SqlDb.ReadStringValue(sqlDataReader["GROUP_NAME"]);
                            isFound = true;
                        }
                    }
                }
            }

            if (isFound == false)
            {
                var commandText = "SELECT GROUP_ID FROM EPG_GROUPS Where GROUP_NAME=@Name And GROUP_ENTITY=11";

                using (var sqlCommand = new SqlCommand(commandText, _sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Name", title);
                    sqlCommand.Transaction = transaction;

                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            existingTitle = title;
                            id = SqlDb.ReadIntValue(sqlDataReader["GROUP_ID"]);
                            isFound = true;
                        }
                    }
                }
            }

            if (id > 0 && isFound == false)
            {
                tempResult.CreateIntAttr("Id", id);
                status.CreateIntAttr("Status", 1);
                status.CreateCDataSection("HolidaySchedule Group not found in PortfolioEngine");
                return false;
            }

            return true;
        }
    }
}