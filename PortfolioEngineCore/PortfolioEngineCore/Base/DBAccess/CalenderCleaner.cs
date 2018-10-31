using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace PortfolioEngineCore
{
    internal class CalenderCleaner
    {
        const int InvalidCalendarId = -1;

        public static StatusEnum DeleteCalendar(DBAccess dbAccess, int calendar, out string reply)
        {
            StatusEnum status = StatusEnum.rsSuccess;
            reply = string.Empty;

            try
            {
                if (dbAccess == null)
                {
                    throw new ArgumentNullException(nameof(dbAccess));
                }

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
            int calendar = InvalidCalendarId)
        {
            using (var command = new SqlCommand(cmdText, dbAccess.Connection))
            {
                addCalenderParameter?.Invoke(calendar, command);
                command.ExecuteNonQuery();
            }
        }

        private static void AddCalenderParameter(int calendar, SqlCommand command)
        {
            command.Parameters.AddWithValue("@pCBld", calendar);
        }
    }
}