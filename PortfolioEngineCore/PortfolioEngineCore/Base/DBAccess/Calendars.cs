using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace PortfolioEngineCore
{
    public class dbaCalendars
    {
        public static StatusEnum SelectCalendars(DBAccess dbAccess, out DataTable dataTable)
        {
            GuardNotNull(dbAccess, nameof(dbAccess));
            const string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS ORDER BY CB_NAME";
            return dbAccess.SelectData(cmdText, (StatusEnum)99998, out dataTable);
        }

        public static StatusEnum SelectCalendar(DBAccess dbAccess, int calendarId, out DataTable dataTable)
        {
            GuardNotNull(dbAccess, nameof(dbAccess));
            if (calendarId >= 0)
            {
                const string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS WHERE CB_ID = @p1";
                return dbAccess.SelectDataById(cmdText, calendarId, (StatusEnum)99997, out dataTable);
            }
            else
            {
                const string cmdText = "SELECT CB_ID=0,CB_NAME='New Calendar',CB_DESC=NULL,CB_LOCK_TO=NULL,CB_LOCK_FROM=NULL";
                return dbAccess.SelectData(cmdText, (StatusEnum)99999, out dataTable);
            }
        }

        public static StatusEnum SelectCalendarByName(DBAccess dbAccess, string name, out DataTable dataTable)
        {
            GuardNotNull(dbAccess, nameof(dbAccess));
            const string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS WHERE CB_NAME = @p1";
            return dbAccess.SelectDataByName(cmdText, name, (StatusEnum)99997, out dataTable);
        }

        public static StatusEnum SelectCalendarPeriods(DBAccess dbAccess, int calendarId, out DataTable dataTable)
        {
            GuardNotNull(dbAccess, nameof(dbAccess));
            string cmdText = "SELECT * FROM EPG_PERIODS WHERE CB_ID = @p1 Order By PRD_ID";
            return dbAccess.SelectDataById(cmdText, calendarId, (StatusEnum)99996, out dataTable);
        }

        public static StatusEnum SelectCalendarPeriodCount(DBAccess dbAccess, int calendarId, out DataTable dataTable)
        {
            GuardNotNull(dbAccess, nameof(dbAccess));
            // for now assuming periods start at 1 - which will likely remian true
            const string cmdText = "SELECT MAX(PRD_ID) as PeriodCount FROM EPG_PERIODS WHERE CB_ID = @p1";
            return dbAccess.SelectDataById(cmdText, calendarId, (StatusEnum)99996, out dataTable);
        }

        public static StatusEnum UpdateCalendar(
            DBAccess dbAccess, 
            ref int calendarId, 
            string calendarName, 
            string calendarDescription, 
            out string reply)
        {
            var status = StatusEnum.rsSuccess;
            reply = string.Empty;

            try
            {
                GuardNotNull(dbAccess, nameof(dbAccess));
                GuardNotNull(calendarName, nameof(calendarName));

                // make sure there isn't already another calendar with this name
                calendarName = calendarName.Trim();
                if (calendarName.Length == 0)
                {
                    reply = DBAccess.FormatAdminError("error", "Calendars.UpdateCalendar", "Please enter a Calendar Name");
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                const string cmdText = "SELECT CB_ID From EPGP_COST_BREAKDOWNS WHERE CB_NAME = @p1";
                DataTable dataTable;
                dbAccess.SelectDataByName(cmdText, calendarName, (StatusEnum)99917, out dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];
                    var existingId = DBAccess.ReadIntValue(row["CB_ID"]);
                    if (existingId != calendarId)
                    {
                        reply = DBAccess.FormatAdminError(
                            "error",
                            "Calendars.UpdateCustomFieldInfo",
                            $"Can't save Calendar.\nA field with name '{calendarName}' already exists");
                        dbAccess.HandleStatusError(
                            SeverityEnum.Error,
                            "UpdateCalendar",
                            (StatusEnum)99995,
                            "Can't save Calendar, a Calendar with this name already exists");

                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                }

                InsertOrUpdateCostBreakDowns(dbAccess, calendarId, calendarName, calendarDescription);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                reply = DBAccess.FormatAdminError("exception", "UpdateCalendar", ex.Message);
            }

            return status;
        }

        private static void InsertOrUpdateCostBreakDowns(
            DBAccess dbAccess,
            int calendarId,
            string calendarName,
            string calendarDescription)
        {
            var rowsAffected = 0;
            string cmdText;
            if (calendarId >= 0)
            {
                cmdText = $@"UPDATE EPGP_COST_BREAKDOWNS 
                             SET CB_NAME=@CB_NAME,CB_DESC=@CB_DESC
                             WHERE CB_ID = {calendarId.ToString()}";
            }
            else
            {
                // Need to figure new CB_ID
                cmdText = "SELECT MAX(CB_ID) As maxCalId FROM EPGP_COST_BREAKDOWNS";
                using (var command = new SqlCommand(cmdText, dbAccess.Connection, dbAccess.Transaction))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        calendarId = reader.Read()
                           ? DBAccess.ReadIntValue(reader["maxCalId"]) + 1
                           : 1;
                    }
                }

                cmdText = $@"INSERT Into EPGP_COST_BREAKDOWNS (CB_ID,CB_NAME,CB_DESC)
                             Values({calendarId.ToString()},@CB_NAME,@CB_DESC)";
            }

            using (var command = new SqlCommand(cmdText, dbAccess.Connection, dbAccess.Transaction))
            {
                command.Parameters.AddWithValue("@CB_NAME", calendarName);
                command.Parameters.AddWithValue("@CB_DESC", calendarDescription);
                rowsAffected += command.ExecuteNonQuery();
            }
        }

        public static StatusEnum DeleteCalendar(DBAccess dbAccess, int calendar, out string reply)
        {
            StatusEnum status = StatusEnum.rsSuccess;
            reply = string.Empty;

            try
            {
                GuardNotNull(dbAccess, nameof(dbAccess));

                // get info for calendar to be deleted
                const string cmdText = "SELECT CB_ID FROM EPGP_COST_BREAKDOWNS WHERE CB_ID=@p1";
                DataTable dataTable;
                dbAccess.SelectDataById(cmdText, calendar, (StatusEnum)99999, out dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];
                    DBAccess.ReadIntValue(row["CB_ID"]);
                }
                else
                {
                    reply = DBAccess.FormatAdminError(
                        "error",
                        "Calendars.DeleteCalendar",
                        "Can't delete Calendar, Calendar not found");
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                if (calendar == 0)
                {
                    reply = DBAccess.FormatAdminError("error", "Calendars.DeleteCalendar", "Can't delete Timesheet Calendar");
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                var message = new StringBuilder();
                using (var command = new SqlCommand("EPG_SP_ReadUsedCB", dbAccess.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CBID", calendar);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            message.AppendFormat("{0}: ", DBAccess.ReadStringValue(reader["Type"]));
                            message.AppendFormat("{0}\n", DBAccess.ReadStringValue(reader["Name"]));
                        }
                    }

                    if (message.Length > 0)
                    {
                        reply = DBAccess.FormatAdminError(
                            "error",
                            "Calendars.DeleteCalendar",
                            $"This Calendar cannot be deleted, it is used as follows:\n\n{message.ToString()}");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                }

                CleanCostViewsAndDelete(dbAccess, calendar);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                status = dbAccess.HandleStatusError(
                    SeverityEnum.Exception, 
                    "DeleteCalendar",
                    (StatusEnum)99993, 
                    ex.Message.ToString());
            }

            return status;
        }

        private static void CleanCostViewsAndDelete(DBAccess dbAccess, int calendar)
        {
            ExecuteNonQuery(
                dbAccess,
                "Delete From EPGT_COSTVIEW_DISPLAY Where VIEW_COST_BREAKDOWN = @pCBld",
                AddCalenderParameter,
                calendar);

            ExecuteNonQuery(
                dbAccess,
                "Delete From EPGT_COSTVIEW_COST_TYPES Where VIEW_UID Not In (Select VIEW_UID From EPGT_COSTVIEW_DISPLAY)");

            ExecuteNonQuery(
                dbAccess,
                "Update EPGT_VIEW_DISPLAY Set COSTVIEW_UID=0 Where COSTVIEW_UID Not In (Select VIEW_UID From EPGT_COSTVIEW_DISPLAY)");

            //  Delete Model Target entries
            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPGP_MODEL_TARGET_VALUES WHERE TARGET_ID IN (SELECT TARGET_ID FROM EPGP_MODEL_TARGETS WHERE CB_ID = @pCBld)",
                AddCalenderParameter,
                calendar);

            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPGP_MODEL_TARGET_DETAILS WHERE TARGET_ID IN (SELECT TARGET_ID FROM EPGP_MODEL_TARGETS WHERE CB_ID = @pCBld)",
                AddCalenderParameter,
                calendar);

            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPGP_MODEL_TARGETS WHERE CB_ID = @pCBld",
                AddCalenderParameter,
                calendar);

            // Delete Rates and FTE conversion values for this CB
            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPGP_COST_BREAKDOWN_ATTRIBS Where CB_ID = @pCBld",
                AddCalenderParameter,
                calendar);

            // Delete Cost Total specs for all Cost Types using this CB
            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPGP_BREAKDOWN_COST_TYPES Where CB_ID = @pCBld",
                AddCalenderParameter,
                calendar);

            // Delete cost values for this CB
            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPGP_COST_VALUES Where CB_ID = @pCBld",
                AddCalenderParameter,
                calendar);

            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPGP_COST_DETAILS Where CB_ID = @pCBld",
                AddCalenderParameter,
                calendar);

            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPGP_DETAIL_VALUES Where CB_ID = @pCBld",
                AddCalenderParameter,
                calendar);

            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPGP_PROJECT_CT_STATUS Where CB_ID = @pCBld",
                AddCalenderParameter,
                calendar);

            // Delete the calendar itself
            ExecuteNonQuery(
                dbAccess,
                "DELETE FROM EPG_PERIODS WHERE CB_ID = @pCBld",
                AddCalenderParameter,
                calendar);

            ExecuteNonQuery(
                dbAccess,
                "DELETE From EPGP_COST_BREAKDOWNS WHERE CB_ID = @pCBld",
                AddCalenderParameter,
                calendar);
        }

        private static void ExecuteNonQuery(
            DBAccess dbAccess,
            string cmdText,
            Action<int, SqlCommand> addCalenderParameter = null,
            int calendar = -1)
        {
            using (var command = new SqlCommand(cmdText, dbAccess.Connection))
            {
                AddCalenderParameter(calendar, command);
                command.ExecuteNonQuery();
            }
        }

        private static void AddCalenderParameter(int calendar, SqlCommand command)
        {
            command.Parameters.AddWithValue("@pCBld", calendar);
        }

        public static StatusEnum DeletePeriods(DBAccess dbAccess, int calendar, out int rowsAffected)
        {
            GuardNotNull(dbAccess, nameof(dbAccess));
            const string cmdText = "DELETE FROM EPG_PERIODS WHERE CB_ID = @p1";
            return dbAccess.DeleteDataById(cmdText, calendar, (StatusEnum)99992, out rowsAffected);
        }

        public static StatusEnum InsertPeriods(DBAccess dbAccess, int calendar, DataTable dataTable, out int rowsAffected)
        {
            var status = StatusEnum.rsSuccess;
            rowsAffected = 0;

            try
            {
                GuardNotNull(dbAccess, nameof(dbAccess));
                GuardNotNull(dataTable, nameof(dataTable));

                if (dataTable.Rows.Count > 0)
                {
                    const string cmdText = "INSERT INTO EPG_PERIODS (PRD_ID,CB_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE,PRD_CLOSED_DATE,PRD_CLOSED_NAME,PRD_IS_CLOSED) VALUES(@PRD_ID,@CB_ID,@PRD_NAME,@PRD_START_DATE,@PRD_FINISH_DATE,@PRD_CLOSED_DATE,@PRD_CLOSED_NAME,@PRD_IS_CLOSED)";
                    using (var command = new SqlCommand(cmdText, dbAccess.Connection, dbAccess.Transaction))
                    {
                        var periodId = command.Parameters.Add("@PRD_ID", SqlDbType.Int);
                        var cbId = command.Parameters.Add("@CB_ID", SqlDbType.Int);
                        var name = command.Parameters.Add("@PRD_NAME", SqlDbType.VarChar, 255);
                        var startDate = command.Parameters.Add("@PRD_START_DATE", SqlDbType.DateTime);
                        var finishDate = command.Parameters.Add("@PRD_FINISH_DATE", SqlDbType.DateTime);
                        var closedDate = command.Parameters.Add("@PRD_CLOSED_DATE", SqlDbType.DateTime);
                        var closedName = command.Parameters.Add("@PRD_CLOSED_NAME", SqlDbType.VarChar, 255);
                        var isClosed = command.Parameters.Add("@PRD_IS_CLOSED", SqlDbType.TinyInt);

                        var index = 0;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            index++;
                            periodId.Value = index;
                            cbId.Value = calendar;
                            name.Value = row["PRD_NAME"];
                            startDate.Value = row["PRD_START_DATE"];
                            finishDate.Value = row["PRD_FINISH_DATE"];
                            closedDate.Value = DBNull.Value;
                            closedName.Value = DBNull.Value;
                            isClosed.Value = false;
                            rowsAffected += command.ExecuteNonQuery();
                        }
                    }
                }

                // need to make sure this insert set wasn't to replace deleted set with more periods which then left orphan BREAKDOWN_ATTRIBS
                using (var oCommand = new SqlCommand("EPG_SP_CleanCTAdmin", dbAccess.Connection, dbAccess.Transaction))
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                status = dbAccess.HandleStatusError(
                    SeverityEnum.Exception, 
                    "InsertPeriods",
                    (StatusEnum)99991, 
                    ex.Message.ToString());
            }
            return status;
        }

        public static StatusEnum CheckPeriods(DataTable dataTable, out string reply)
        {
            var status = StatusEnum.rsSuccess;
            reply = string.Empty;

            try
            {
                GuardNotNull(dataTable, nameof(dataTable));

                if (dataTable.Rows.Count > 0)
                {
                    var index = 0;
                    var prevfinishdate = DateTime.MinValue;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        index++;
                        var name = row["PRD_NAME"].ToString();
                        var startdate = DateTime.Parse(row["PRD_START_DATE"].ToString());
                        var finishdate = DateTime.Parse(row["PRD_FINISH_DATE"].ToString());
                        if (name.Trim().Length == 0)
                        {
                            reply = "All Periods must have a name";
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }

                        if (startdate > finishdate)
                        {
                            reply = $"Period finish must be later than period start: {name}";
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }

                        if (index == 1)
                        {
                            prevfinishdate = finishdate;
                        }
                        else
                        {
                            if (startdate != prevfinishdate.AddDays(1))
                            {
                                reply = $"Period start date must be contiguous with previous period finish date: {name}";
                                return StatusEnum.rsRequestCannotBeCompleted;
                            }

                            prevfinishdate = finishdate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                reply = $"exception{ex.Message.ToString()}";
                status = StatusEnum.rsRequestCannotBeCompleted;
            }

            return status;
        }

        public static StatusEnum ReadCalendarFTEs(DBAccess dbAccess, int calendarId, out DataTable dataTable)
        {
            GuardNotNull(dbAccess, nameof(dbAccess));
            const string cmdText = "EPG_SP_ReadCalendarFTEs @p1";
            return dbAccess.SelectDataById(cmdText, calendarId, (StatusEnum)99997, out dataTable);
        }

        private static void GuardNotNull(object obj, string objectName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(objectName);
            }
        }
    }
}

