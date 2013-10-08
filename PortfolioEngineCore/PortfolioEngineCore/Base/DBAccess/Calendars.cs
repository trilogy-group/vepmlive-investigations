using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{

    public class dbaCalendars
    {
        public static StatusEnum SelectCalendars(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS ORDER BY CB_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99998, out dt);
        }

        public static StatusEnum SelectCalendar(DBAccess dba, int nCalendarId, out DataTable dt)
        {
            if (nCalendarId >= 0)
            {
                const string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS WHERE CB_ID = @p1";
                return dba.SelectDataById(cmdText, nCalendarId, (StatusEnum)99997, out dt);
            }
            else
            {
                const string cmdText = "SELECT CB_ID=0,CB_NAME='New Calendar',CB_DESC=NULL,CB_LOCK_TO=NULL,CB_LOCK_FROM=NULL";
                return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
            }
        }

        public static StatusEnum SelectCalendarByName(DBAccess dba, string sName, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS WHERE CB_NAME = @p1";
            return dba.SelectDataByName(cmdText, sName, (StatusEnum)99997, out dt);
        }

        public static StatusEnum SelectCalendarPeriods(DBAccess dba, int nCalendarId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_PERIODS WHERE CB_ID = @p1 Order By PRD_ID";
            return dba.SelectDataById(cmdText, nCalendarId, (StatusEnum)99996, out dt);
        }

        public static StatusEnum SelectCalendarPeriodCount(DBAccess dba, int nCalendarId, out DataTable dt)
        {
            // for now assuming periods start at 1 - which will likely remian true
            string cmdText = "SELECT MAX(PRD_ID) as PeriodCount FROM EPG_PERIODS WHERE CB_ID = @p1";
            return dba.SelectDataById(cmdText, nCalendarId, (StatusEnum)99996, out dt);
        }

        public static StatusEnum UpdateCalendar(DBAccess dba, ref int nCalendarId, string sCalendarName, string sCalendarDescription, out string sReply)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            int lRowsAffected = 0;

            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;
            sReply = "";

            try
            {
                // make sure there isn't already another calendar with this name
                sCalendarName = sCalendarName.Trim();
                if (sCalendarName.Length == 0)
                {
                    sReply = DBAccess.FormatAdminError("error", "Calendars.UpdateCalendar", "Please enter a Calendar Name");
                    return StatusEnum.rsRequestCannotBeCompleted;
                }
                cmdText = "SELECT CB_ID From EPGP_COST_BREAKDOWNS WHERE CB_NAME = @p1";
                DataTable dt;
                dba.SelectDataByName(cmdText, sCalendarName, (StatusEnum)99917, out dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    int nExistingId = DBAccess.ReadIntValue(row["CB_ID"]);
                    if (nExistingId != nCalendarId)
                    {
                        sReply = DBAccess.FormatAdminError("error", "Calendars.UpdateCustomFieldInfo", "Can't save Calendar.\nA field with name '" + sCalendarName + "' already exists");
                        dba.HandleStatusError(SeverityEnum.Error, "UpdateCalendar", (StatusEnum)99995, "Can't save Calendar, a Calendar with this name already exists");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                }

                if (nCalendarId >= 0)
                {
                    cmdText =
                            "UPDATE EPGP_COST_BREAKDOWNS "
                        + " SET CB_NAME=@CB_NAME,CB_DESC=@CB_DESC"
                        + " WHERE CB_ID = " + nCalendarId.ToString();
                }
                else
                {
                    //   need to figure new CB_ID
                    cmdText = "SELECT MAX(CB_ID) As maxCalId FROM EPGP_COST_BREAKDOWNS";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    reader = oCommand.ExecuteReader();

                    if (reader.Read())
                        nCalendarId = DBAccess.ReadIntValue(reader["maxCalId"]) + 1;
                    else
                        nCalendarId = 1;

                    reader.Close();

                    cmdText =
                            "INSERT Into EPGP_COST_BREAKDOWNS "
                        + " (CB_ID,CB_NAME,CB_DESC)"
                        + " Values(" + nCalendarId.ToString() + ",@CB_NAME,@CB_DESC)";
                }
                oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                oCommand.Parameters.AddWithValue("@CB_NAME", sCalendarName);
                oCommand.Parameters.AddWithValue("@CB_DESC", sCalendarDescription);
                lRowsAffected += oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateCalendar", (StatusEnum)99994, ex.Message.ToString());
                sReply = DBAccess.FormatAdminError("exception", "UpdateCalendar", ex.Message);
            }

            return eStatus;
        }

        public static StatusEnum DeleteCalendar(DBAccess dba, int nCalendar, out string sReply)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            sReply = "";

            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;

            try
            {
                // get info for calendar to be deleted
                {
                    cmdText = "SELECT CB_ID FROM EPGP_COST_BREAKDOWNS WHERE CB_ID=@p1";
                    DataTable dt;
                    dba.SelectDataById(cmdText, nCalendar, (StatusEnum)99999, out dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nCB = DBAccess.ReadIntValue(row["CB_ID"]);
                    }
                    else
                    {
                        sReply = DBAccess.FormatAdminError("error", "Calendars.DeleteCalendar", "Can't delete Calendar, Calendar not found");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                }

                if (nCalendar == 0)
                {
                    sReply = DBAccess.FormatAdminError("error", "Calendars.DeleteCalendar", "Can't delete Timesheet Calendar");
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                string smessage = "";
                oCommand = new SqlCommand("EPG_SP_ReadUsedCB", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@CBID", nCalendar);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    smessage += DBAccess.ReadStringValue(reader["Type"]) + ": ";
                    smessage += DBAccess.ReadStringValue(reader["Name"]) + "\n";
                }
                reader.Close();
                if (smessage.Length > 0) 
                {
                    sReply = DBAccess.FormatAdminError("error", "Calendars.DeleteCalendar", "This Calendar cannot be deleted, it is used as follows:" + "\n" + "\n" + smessage);
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                // OK let's delete the little rascal

                //   clear if used in Cost Views
                cmdText = "Delete From EPGT_COSTVIEW_DISPLAY Where VIEW_COST_BREAKDOWN = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();

                cmdText = "Delete From EPGT_COSTVIEW_COST_TYPES Where VIEW_UID Not In (Select VIEW_UID From EPGT_COSTVIEW_DISPLAY)";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.ExecuteNonQuery();
                cmdText = "Update EPGT_VIEW_DISPLAY Set COSTVIEW_UID=0 Where COSTVIEW_UID Not In (Select VIEW_UID From EPGT_COSTVIEW_DISPLAY)";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.ExecuteNonQuery();

                //  Delete Model Target entries
                cmdText = "DELETE FROM EPGP_MODEL_TARGET_VALUES WHERE TARGET_ID IN (SELECT TARGET_ID FROM EPGP_MODEL_TARGETS WHERE CB_ID = @pCBld)";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();
                cmdText = "DELETE FROM EPGP_MODEL_TARGET_DETAILS WHERE TARGET_ID IN (SELECT TARGET_ID FROM EPGP_MODEL_TARGETS WHERE CB_ID = @pCBld)";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();
                cmdText = "DELETE FROM EPGP_MODEL_TARGETS WHERE CB_ID = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();

                //   Delete Rates and FTE conversion values for this CB
                cmdText = "DELETE FROM EPGP_COST_BREAKDOWN_ATTRIBS Where CB_ID = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();

                //   Delete Cost Total specs for all Cost Types using this CB
                cmdText = "DELETE FROM EPGP_BREAKDOWN_COST_TYPES Where CB_ID = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();

                //   Delete cost values for this CB
                cmdText = "DELETE FROM EPGP_COST_VALUES Where CB_ID = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();
                cmdText = "DELETE FROM EPGP_COST_DETAILS Where CB_ID = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();
                cmdText = "DELETE FROM EPGP_DETAIL_VALUES Where CB_ID = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();
                cmdText = "DELETE FROM EPGP_PROJECT_CT_STATUS Where CB_ID = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();
              
                //  Delete the calendar itself
                cmdText = "DELETE FROM EPG_PERIODS WHERE CB_ID = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();

                cmdText = "DELETE From EPGP_COST_BREAKDOWNS WHERE CB_ID = @pCBld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCBld", nCalendar);
                oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCalendar", (StatusEnum)99993, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeletePeriods(DBAccess dba, int nCalendar, out int lRowsAffected)
        {
            string cmdText = "DELETE FROM EPG_PERIODS WHERE CB_ID = @p1";
            return (dba.DeleteDataById(cmdText, nCalendar, (StatusEnum)99992, out lRowsAffected));
        }

        public static StatusEnum InsertPeriods(DBAccess dba, int nCalendar, DataTable dt, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;

            SqlCommand oCommand;
            lRowsAffected = 0;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string cmdText = "INSERT INTO EPG_PERIODS (PRD_ID,CB_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE,PRD_CLOSED_DATE,PRD_CLOSED_NAME,PRD_IS_CLOSED) VALUES(@PRD_ID,@CB_ID,@PRD_NAME,@PRD_START_DATE,@PRD_FINISH_DATE,@PRD_CLOSED_DATE,@PRD_CLOSED_NAME,@PRD_IS_CLOSED)";

                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);

                    SqlParameter pPRD_ID = oCommand.Parameters.Add("@PRD_ID", SqlDbType.Int);
                    SqlParameter pCB_ID = oCommand.Parameters.Add("@CB_ID", SqlDbType.Int);
                    SqlParameter pPRD_NAME = oCommand.Parameters.Add("@PRD_NAME", SqlDbType.VarChar, 255);
                    SqlParameter pPRD_START_DATE = oCommand.Parameters.Add("@PRD_START_DATE", SqlDbType.DateTime);
                    SqlParameter pPRD_FINISH_DATE = oCommand.Parameters.Add("@PRD_FINISH_DATE", SqlDbType.DateTime);
                    SqlParameter pPRD_CLOSED_DATE = oCommand.Parameters.Add("@PRD_CLOSED_DATE", SqlDbType.DateTime);
                    SqlParameter pPRD_CLOSED_NAME = oCommand.Parameters.Add("@PRD_CLOSED_NAME", SqlDbType.VarChar, 255);
                    SqlParameter pPRD_IS_CLOSED = oCommand.Parameters.Add("@PRD_IS_CLOSED", SqlDbType.TinyInt);

                    int nIndex = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        nIndex++;
                        pPRD_ID.Value = nIndex;
                        pCB_ID.Value = nCalendar;
                        pPRD_NAME.Value = row["PRD_NAME"];
                        pPRD_START_DATE.Value = row["PRD_START_DATE"];
                        pPRD_FINISH_DATE.Value = row["PRD_FINISH_DATE"];
                        pPRD_CLOSED_DATE.Value = DBNull.Value;
                        pPRD_CLOSED_NAME.Value = DBNull.Value;
                        pPRD_IS_CLOSED.Value = false;
                        lRowsAffected += oCommand.ExecuteNonQuery();
                    }
                }

                // need to make sure this insert set wasn't to replace deleted set with more periods which then left orphan BREAKDOWN_ATTRIBS
                oCommand = new SqlCommand("EPG_SP_CleanCTAdmin", dba.Connection,dba.Transaction);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertPeriods", (StatusEnum)99991, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum CheckPeriods(DataTable dt, out string sReply)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            sReply="";
            try
            {
                if (dt.Rows.Count > 0)
                {
                    int nIndex = 0;
                    DateTime prevfinishdate=DateTime.MinValue;
                    foreach (DataRow row in dt.Rows)
                    {
                        nIndex++;
                        string sName = row["PRD_NAME"].ToString();
                        DateTime startdate = DateTime.Parse(row["PRD_START_DATE"].ToString());
                        DateTime finishdate = DateTime.Parse(row["PRD_FINISH_DATE"].ToString());

                        if(sName.Trim().Length==0)
                        {
                            sReply = "All Periods must have a name";
                            //sReply = DBAccess.FormatAdminError("error", "Calendars.CheckPeriods", "All Periods must have a name");
                            //dba.HandleStatusError(SeverityEnum.Error, "UpdateCalendar", (StatusEnum)99995, "Can't save Calendar, a Calendar with this name already exists");
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                        if (startdate > finishdate)
                        {
                            sReply = "Period finish must be later than period start: " + sName;
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                        if (nIndex == 1)
                        {
                            prevfinishdate = finishdate;
                        }
                        else
                        {
                            if (startdate != prevfinishdate.AddDays(1))
                            {
                                sReply = "Period start date must be contiguous with previous period finish date: " + sName;
                                return StatusEnum.rsRequestCannotBeCompleted;
                            }
                            prevfinishdate = finishdate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = "exception" + ex.Message.ToString();
                eStatus = StatusEnum.rsRequestCannotBeCompleted;
            }
            return eStatus;
        }

        public static StatusEnum ReadCalendarFTEs(DBAccess dba, int nCalendarId, out DataTable dt)
        {
            const string cmdText = "EPG_SP_ReadCalendarFTEs @p1";
            return dba.SelectDataById(cmdText, nCalendarId, (StatusEnum)99997, out dt);
        }
    }
}

