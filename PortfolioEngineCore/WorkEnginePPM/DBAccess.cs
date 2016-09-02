using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace WorkEnginePPM
{
    public enum StatusEnum
    {
        rsSuccess = 0,                          // Operation Succeeded,
        rsRequestUnknown = 1,                    // Request not recognised
        rsRequestInvalid = 2,                    // Some part of the request syntax is invalid (general status)
        rsRequestIncomplete = 3,                 // More info expected in request
        rsRequestStringEmpty = 4,                // Request string contained no info
        rsRequestNotImplemented = 5,             // Request is known but currently not implemented
        rsRequestInvalidParameter = 6,           // One of the request nodes/parameters is invalid or cotextually invalid
        rsNodeNameInvalid = 7,                   // Node name not recognised as valid syntax for the request
        rsSessionExpired = 8,
        rsDBConnectFailed = 9,
        rsDBTableNotFound = 10,
        rsUserNotAuthenticated = 11,
        rsSessionNotInitialized = 12,
        rsDateFormatInvalid = 21,                // The format of a string date is invalid ("YYYYMMDDhhmmss")
        rsDecodeInvalidInteger = 23,             // A request numeric parameter did not hold a numeric value
        rsDecodeIntegerTooSmall = 24,            // A request numeric parameters value was too small
        rsDecodeIntegerTooLarge = 25,            // A request numeric parameters value was too large
        rsRequestInvalidXML = 30,                // Request XML contains a syntax error - i.e. it can//t be parsed
        rsRequestInvalidRoot = 32,               // No root node found for the request
        rsRequestMultiplesInvalid = 31,          // Request contains repeated parameters which is invalid
        rsRequestMissing = 33,                   // Request node was found but the request itself was missing
        rsRequestParameterMissing = 34,          // A required parameter for the request was missing
        rsRequestCannotBeCompleted = 35,         // A general failure to perform as desired - display mess on client
        rsRequestEncounteredDuplicate = 36,      // A failure to perform because some kind of duplicate encountered
        rsRequestInvalidPeriodRange = 37,
        rsRequestInvalidPeriod = 38,
        rsWEIBeginSessionFailed = 39,
        rsWEIWebServiceNotSpecified = 40,
        rsWEIWebServiceError = 41,
        rsSecurityAccessDenied = 50,             // User does not have permission to make this request
        rsVarCharInvalidCharacters = 59,
        rsVarCharInvalidLength = 60,
    
        rsPasswordChangeFailed = 61,
        rsCannotDeleteUsedRateType = 62,
    
        rsTriggerValidationError = 64,
    
        rsUserJobNotInRegistry = 70,
        rsUserJobCreateObjectFailed = 71,
        rsUserJobInvalidObject = 72,
    
        rsProjIDtoWProjIDConversionFailed = 102,
    
        rsServerError = 999,
    
        rsProjectNotFound = 1000,
        rsProjectAlreadyExists = 1001,
        rsProjectParametersInvalid = 1004,
        rsProjectCheckedout = 1007,
        rsProjectNameInvalid = 1016,
        rsProjectPrefixTooLong = 1019,
        rsProjectPrefixTooShort = 1020,
        rsProjectPrefixInvalidCharacters = 1021,
        rsProjStartDateMissing = 1025,
        rsMailSendFailure = 1030,
        rsMailConfigInvalid = 1031,
    
    
        // Reserve 2000 - 2100 for QueueManager errors
    
        rsLookupInvalidLevelSequence = 2001,
        rsLookupAlreadyExists = 2002,
        rsLookupWriteError = 2003,
    
        rsPortfolioNoViews = 3001,
        rsPIResourceCalendarNotSet = 3002,
        rsPIResourcePlanViewNotSet = 3003,
        rsPIResourceApprovalCodeNotSet = 3004,
    
        rsEVCalcError = 3100,
    
        // Sync 4000 - 4999 between vb and C#
        rsNotifyEventNotFound = 4001,
        rsNoSenderEMailAddress = 4002,
        rsNoRecipientEMailAddress = 4003,
        
        rsInvalidPeriodID = 8000,
        rsTSNotFound = 8001,
        rsTSDeptStatusChanged = 8002,
        rsTSProjStatusChanged = 8003,
        rsTSCantDeleteSubmittedRow = 8004,
        rsTSDeptManagerLocked = 8005,
        rsTSHasChanged = 8006,
        rsInvalidCustomFieldID = 8007,
        rsBasePathNotSet = 8008,
        rsTaskStatusUpdateFailed = 8009,
        rsOtherResourceAssignedTask = 8010,
        rsTSPeriodClosed = 8011,
        rsTSDeptPeriodClosed = 8012,
        rsDelegatePermissionDenied = 8013,
        rsRoleCodeInvalid = 8014,
        rsTimestampHasChanged = 8015,
    
        rsWSSUnknownError = 8100,
        rsWSSSiteAlreadyExists = 8101,
        rsWSSSiteNotFound = 8102,
        rsWSSNoUserNTAccount = 8103,
        rsWSSCannotDeleteSiteUsedByOtherPIs = 8104,
        rsWSSCannotDeleteSiteUsedByOtherProjects = 8105,
        rsWSSCannotAttachSiteUsedByOtherProjects = 8106,
        rsWSSCannotAttachSiteUsedByOtherPIs = 8107,
        rsWSSRoleNameAlreadyExists = 8108,
        rsWSSNoAdminData = 8109,
        rsWSSNoServerData = 8110,
        rsWSSNoCurrentServer = 8111,
        rsWSSSecurityPrincipalInvalid = 8112,
        rsWSSAdminComponentFailed = 8113,
        rsWSSURLErrorOrPermissionsProblem = 8114,
    
        rsWSSLoginFailed = 8120,
        rsWSSReadFailed = 8121,
        rsWSSCOMPlusComponentFailed = 8122,
        rsWSSClassNotInitialized = 8123,
    
        rsResourceRowLimitExceeded = 8200,
    
        rsPSILoginFailed = 8300,
        rsLookupTableAlreadyExists = 8301,
    
        rsRequestAuthenticationFailed = 8999
    }

    public enum TraceChannelEnum
    {
        All = -1,
        None = 0x0,
        Exception = 0x1,
        WSS = 0x2,
        Upload = 0x4,
        WebServices = 0x8
    }

    public enum SeverityEnum
    {
        None = 0,
        Information = 1,
        Warning = 2,
        Error = 3,
        Exception = 4,
        DBException = 5
    }

    internal class dbaCalendars
    {
        public static StatusEnum SelectCalendars(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS ORDER BY CB_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99998, out dt);
        }

        public static StatusEnum SelectCalendar(DBAccess dba, int nCalendarId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS WHERE CB_ID = @p1";
            return dba.SelectDataById(cmdText, nCalendarId, (StatusEnum)99997, out dt);
        }

        public static StatusEnum SelectCalendarPeriods(DBAccess dba, int nCalendarId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_PERIODS WHERE CB_ID = @p1";
            return dba.SelectDataById(cmdText, nCalendarId, (StatusEnum)99996, out dt);
        }

        public static StatusEnum UpdateCalendar(DBAccess dba, DataTable dt, ref int nCalendar)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            int lRowsAffected = 0;

            SqlCommand oCommand;
            string cmdText;

            try
            {
                // make sure there isn't already another calendar with this name
                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    Int32.TryParse(row["CB_ID"].ToString(), out nCalendar);
                    string sCalendarName = row["CB_NAME"].ToString();
                    string sCalendarDescription = row["CB_DESC"].ToString();

                    cmdText = "SELECT CB_ID From EPGP_COST_BREAKDOWNS WHERE CB_NAME = @CB_NAME";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.Add("@CB_NAME", SqlDbType.VarChar, 255).Value = sCalendarName;
                    SqlDataReader reader = oCommand.ExecuteReader();

                    int nExistingCalId;
                    if (reader.Read())
                    {
                        nExistingCalId = DBAccess.ReadIntValue(reader["CB_ID"]);
                        if (nExistingCalId != nCalendar)
                        {
                            return dba.HandleStatusError(SeverityEnum.Error, "UpdateCalendar", (StatusEnum)99995, "Can't save Calendar, a Calendar with this name already exists");
                        }
                    }
                    reader.Close();

                    if (nCalendar >= 0)
                    {
                        cmdText =
                               "UPDATE EPGP_COST_BREAKDOWNS "
                           + " SET CB_NAME=@CB_NAME,CB_DESC=@CB_DESC"
                           + " WHERE CB_ID = " + nCalendar.ToString();
                    }
                    else
                    {
                        //   need to figure new CB_ID
                        cmdText = "SELECT MAX(CB_ID) As maxCalId FROM EPGP_COST_BREAKDOWNS";
                        oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                        reader = oCommand.ExecuteReader();

                        if (reader.Read())
                            nCalendar = DBAccess.ReadIntValue(reader["maxCalId"]) + 1;
                        else
                            nCalendar = 1;

                        reader.Close();

                        cmdText =
                               "INSERT Into EPGP_COST_BREAKDOWNS "
                           + " (CB_ID,CB_NAME,CB_DESC)"
                           + " Values(" + nCalendar.ToString() + ",@CB_NAME,@CB_DESC)";
                    }
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CB_NAME", sCalendarName);
                    oCommand.Parameters.AddWithValue("@CB_DESC", sCalendarDescription);

                    lRowsAffected += oCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateCalendar", (StatusEnum)99994, ex.Message.ToString());
            }

            return eStatus;
        }

        public static StatusEnum DeleteCalendar(DBAccess dba, int nCalendar, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;

            SqlCommand oCommand;
            string cmdText;

            try
            {
                cmdText = "DELETE FROM EPG_PERIODS WHERE CB_ID = " + nCalendar.ToString();
                oCommand = new SqlCommand(cmdText, dba.Connection);
                lRowsAffected = oCommand.ExecuteNonQuery();

                cmdText = "DELETE From EPGP_COST_BREAKDOWNS WHERE CB_ID = " + nCalendar.ToString();
                oCommand = new SqlCommand(cmdText, dba.Connection);
                lRowsAffected += oCommand.ExecuteNonQuery();

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
            lRowsAffected = 0;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string cmdText = "INSERT INTO EPG_PERIODS (PRD_ID,CB_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE,PRD_CLOSED_DATE,PRD_CLOSED_NAME,PRD_IS_CLOSED) VALUES(@PRD_ID,@CB_ID,@PRD_NAME,@PRD_START_DATE,@PRD_FINISH_DATE,@PRD_CLOSED_DATE,@PRD_CLOSED_NAME,@PRD_IS_CLOSED)";

                    SqlCommand oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);

                    SqlParameter pPRD_ID = oCommand.Parameters.Add("@PRD_ID", SqlDbType.Int);
                    SqlParameter pCB_ID = oCommand.Parameters.Add("@CB_ID", SqlDbType.Int);
                    SqlParameter pPRD_NAME = oCommand.Parameters.Add("@PRD_NAME", SqlDbType.VarChar, 255);
                    SqlParameter pPRD_START_DATE = oCommand.Parameters.Add("@PRD_START_DATE", SqlDbType.Timestamp);
                    SqlParameter pPRD_FINISH_DATE = oCommand.Parameters.Add("@PRD_FINISH_DATE", SqlDbType.Timestamp);
                    SqlParameter pPRD_CLOSED_DATE = oCommand.Parameters.Add("@PRD_CLOSED_DATE", SqlDbType.Timestamp);
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
                        pPRD_CLOSED_DATE.Value = null;
                        pPRD_CLOSED_NAME.Value = null;
                        pPRD_IS_CLOSED.Value = false;
                        lRowsAffected += oCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertPeriods", (StatusEnum)99991, ex.Message.ToString());
            }
            return eStatus;
        }
    }

    internal class dbaCostCategories
    {
        public static StatusEnum SelectCostCategories(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_CATEGORIES ORDER BY CA_ID";
            return dba.SelectData(cmdText, (StatusEnum)99957, out dt);
        }

        public static StatusEnum DeleteCostCategories(DBAccess dba, out int lRowsAffected)
        {
            string cmdText = "DELETE FROM EPGP_CATEGORIES";
            return (dba.DeleteData(cmdText, (StatusEnum)99956, out lRowsAffected));
        }

    //    public static StatusEnum InsertCostCategories(DBAccess dba, DataTable dt, out int lRowsAffected)
    //    {
    //        StatusEnum eStatus = StatusEnum.rsSuccess;
    //        lRowsAffected = 0;
    //        try
    //        {
    //            if (dt.Rows.Count > 0)
    //            {
    //                string cmdText = "INSERT INTO EPG_PERIODS (PRD_ID,CB_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE,PRD_CLOSED_DATE,PRD_CLOSED_NAME,PRD_IS_CLOSED) VALUES(@,@,@,@,@,@,@,@)";

    //                SqlCommand oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);

    //                SqlParameter pBC_UID = oCommand.Parameters.Add("BC_UID", SqlDbType.Int);
    //                SqlParameter pBC_NAME = oCommand.Parameters.Add("BC_NAME", SqlDbType.VarChar, 255);
    //                SqlParameter pBC_ID = oCommand.Parameters.Add("BC_ID", SqlDbType.Int);
    //                SqlParameter pBC_LEVEL = oCommand.Parameters.Add("BC_LEVEL", SqlDbType.Int);
    //                SqlParameter pBC_ROLE = oCommand.Parameters.Add("BC_ROLE", SqlDbType.Int);
    //                SqlParameter pBC_UOM = oCommand.Parameters.Add("BC_UOM", SqlDbType.VarChar, 255);
    //                SqlParameter pMC_UID = oCommand.Parameters.Add("MC_UID", SqlDbType.Int);
    //                SqlParameter pCA_UID = oCommand.Parameters.Add("CA_UID", SqlDbType.Int);



    //                int nIndex = 0;
    //                foreach (DataRow row in dt.Rows)
    //                {
    //                    nIndex++;
    //                    pPRD_ID.Value = nIndex;
    //                    pCB_ID.Value = nCalendar;
    //                    pPRD_NAME.Value = row["PRD_NAME"];
    //                    pPRD_START_DATE.Value = row["PRD_START_DATE"];
    //                    pPRD_FINISH_DATE.Value = row["PRD_FINISH_DATE"];
    //                    pPRD_CLOSED_DATE.Value = null;
    //                    pPRD_CLOSED_NAME.Value = null;
    //                    pPRD_IS_CLOSED.Value = false;
    //                    lRowsAffected += oCommand.ExecuteNonQuery();
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertPeriods", (StatusEnum)99999, ex.Message.ToString());
    //        }
    //        return eStatus;
    //    }
    }

    internal class dbaCostTypes
    {
        public static StatusEnum SelectCostTypes(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_TYPES ORDER BY CT_ID";
            return dba.SelectData(cmdText, (StatusEnum)99990, out dt);
        }

        public static StatusEnum SelectCalendars(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS ORDER BY CB_ID";
            return dba.SelectData(cmdText, (StatusEnum)99989, out dt);
        }

        public static StatusEnum SelectCustomFields_Cost(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FORMAT=8 ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99988, out dt);
        }

        public static StatusEnum SelectCostType(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_TYPES WHERE CT_ID = @p1";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99987, out dt);
        }

        public static StatusEnum SelectCostTypeFormula(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT CL_CT_ID, CL_OP, CT_NAME FROM EPGP_COST_CALC CC LEFT JOIN EPGP_COST_TYPES CT ON (CC.CL_CT_ID = CT.CT_ID) WHERE CC.CT_ID = @p1 ORDER BY CL_ID";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99986, out dt);
        }

        public static StatusEnum DeleteCostType(DBAccess dba, int nCostType, out int lRowsAffected)
        {
            string cmdText = "DELETE FROM EPGP_BREAKDOWN_COST_TYPES WHERE CT_ID = @p1";
            if (dba.DeleteDataById(cmdText, nCostType, (StatusEnum)99985, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

            cmdText = "DELETE FROM EPGT_COSTVIEW_COST_TYPES WHERE CT_ID = @p1";
            if (dba.DeleteDataById(cmdText, nCostType, (StatusEnum)99984, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

            cmdText = "DELETE FROM EPGP_COST_TYPES WHERE CT_ID = @p1";
            if (dba.DeleteDataById(cmdText, nCostType, (StatusEnum)99983, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;
Exit_Function:
            return dba.Status;
        }

        public static StatusEnum UpdateCostTypes(DBAccess dba, DataTable dt, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string cmdText =
                          "UPDATE EPGP_COST_TYPES "
                        + " SET CT_NAME=@CT_NAME,CT_EDIT_MODE=@CT_EDIT_MODE,INITIAL_LEVEL=@INITIAL_LEVEL,CT_CB_ID=@CT_CB_ID,CT_ALLOW_NAMED_RATES=@CT_ALLOW_NAMED_RATES "
                        + " WHERE CT_ID = @CT_ID";

                    SqlCommand oCommand = new SqlCommand(cmdText, dba.Connection);

                    SqlParameter pCT_NAME = oCommand.Parameters.Add("@CT_NAME", SqlDbType.VarChar, 255);
                    SqlParameter pCT_EDIT_MODE = oCommand.Parameters.Add("@CT_EDIT_MODE", SqlDbType.Int);
                    SqlParameter pINITIAL_LEVEL = oCommand.Parameters.Add("@INITIAL_LEVEL", SqlDbType.Int);
                    SqlParameter pCT_CB_ID = oCommand.Parameters.Add("@CT_CB_ID", SqlDbType.Int);
                    SqlParameter pCT_ALLOW_NAMED_RATES = oCommand.Parameters.Add("@CT_ALLOW_NAMED_RATES", SqlDbType.Int);
                    SqlParameter pCT_ID = oCommand.Parameters.Add("@CT_ID", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pCT_NAME.Value = row["CT_NAME"];
                        pCT_EDIT_MODE.Value = row["CT_EDIT_MODE"];
                        pINITIAL_LEVEL.Value = row["INITIAL_LEVEL"];
                        pCT_CB_ID.Value = row["CT_CB_ID"];
                        pCT_ALLOW_NAMED_RATES.Value = row["CT_ALLOW_NAMED_RATES"];
                        pCT_ID.Value = row["CT_ID"];
                        lRowsAffected += oCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateCostTypes", (StatusEnum)99982, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum InsertCostTypes(DBAccess dba, DataTable dt, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string cmdText =
                          "INSERT INTO EPGP_COST_TYPES "
                    + " (CT_NAME,CT_EDIT_MODE,INITIAL_LEVEL,CT_CB_ID,CT_ALLOW_NAMED_RATES) "
                    + " VALUES(@CT_NAME,@CT_EDIT_MODE,@INITIAL_LEVEL,@CT_CB_ID,@CT_ALLOW_NAMED_RATES)";

                    SqlCommand oCommand = new SqlCommand(cmdText, dba.Connection);

                    SqlParameter pCT_NAME = oCommand.Parameters.Add("@CT_NAME", SqlDbType.VarChar, 255);
                    SqlParameter pCT_EDIT_MODE = oCommand.Parameters.Add("@CT_EDIT_MODE", SqlDbType.Int);
                    SqlParameter pINITIAL_LEVEL = oCommand.Parameters.Add("@INITIAL_LEVEL", SqlDbType.Int);
                    SqlParameter pCT_CB_ID = oCommand.Parameters.Add("@CT_CB_ID", SqlDbType.Int);
                    SqlParameter pCT_ALLOW_NAMED_RATES = oCommand.Parameters.Add("@CT_ALLOW_NAMED_RATES", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pCT_NAME.Value = row["CT_NAME"];
                        pCT_EDIT_MODE.Value = row["CT_EDIT_MODE"];
                        pINITIAL_LEVEL.Value = row["INITIAL_LEVEL"];
                        pCT_CB_ID.Value = row["CT_CB_ID"];
                        pCT_ALLOW_NAMED_RATES.Value = row["CT_ALLOW_NAMED_RATES"];
                        lRowsAffected += oCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostTypes", (StatusEnum)99981, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum SelectCostCategories(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT CC.BC_UID, BC_NAME, BC_LEVEL, AC.CT_ID FROM EPGP_COST_CATEGORIES CC LEFT JOIN EPGP_AVAIL_CATEGORIES AC ON (CC.BC_UID = AC.BC_UID and AC.CT_ID = @p1) ORDER BY BC_ID";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99980, out dt);
        }

        public static StatusEnum SelectCustomFieldForCostType(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT TOP 1 * From EPGP_BREAKDOWN_COST_TYPES Where CT_ID = @p1";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99979, out dt);
        }

        public static StatusEnum DeleteAvailableCostTypeCategories(DBAccess dba, int nCostTypeID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_AVAIL_CATEGORIES WHERE CT_ID = @CT_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteAvailableCostTypeCategories", (StatusEnum)99978, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeleteCostTypeFormula(DBAccess dba, int nCostTypeID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_COST_CALC WHERE CT_ID = @CT_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostTypeFormula", (StatusEnum)99977, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeleteCostTotals(DBAccess dba, int nCostTypeID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_BREAKDOWN_COST_TYPES WHERE CT_ID = @CT_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostTotals", (StatusEnum)99976, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeleteCTCustomFields(DBAccess dba, int nCostTypeID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_COST_CUSTOM_FIELDS WHERE CT_ID = @CT_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostTotals", (StatusEnum)99955, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum InsertAvailableCostTypeCategories(DBAccess dba, int nCostTypeID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_AVAIL_CATEGORIES (CT_ID,BC_UID) VALUES(@CT_ID,@BC_UID)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);

                    SqlParameter pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertAvailableCostTypeCategories", (StatusEnum)99975, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostTotals(DBAccess dba, int nCostTypeID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_BREAKDOWN_COST_TYPES (CT_ID,CB_ID,BUDGET_TOTAL_FIELD) VALUES(@CT_ID,@CB_ID,@BUDGET_TOTAL_FIELD)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);

                    SqlParameter pCB_ID = cmd.Parameters.Add("@CB_ID", SqlDbType.Int);
                    SqlParameter pBUDGET_TOTAL_FIELD = cmd.Parameters.Add("@BUDGET_TOTAL_FIELD", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pCB_ID.Value = row["CB_ID"];
                        pBUDGET_TOTAL_FIELD.Value = row["BUDGET_TOTAL_FIELD"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostTotals", (StatusEnum)99974, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostCustomFields(DBAccess dba, int nCostTypeID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_COST_CUSTOM_FIELDS (CT_ID,CF_ID,CF_FIELD_ID,CF_VISIBLE,CF_EDITABLE,CF_FROZEN,CF_IDENTITY,CF_REQUIRED) VALUES(@CT_ID,@CF_ID,@CF_FIELD_ID,@CF_VISIBLE,@CF_EDITABLE,@CF_FROZEN,@CF_IDENTITY,@CF_REQUIRED)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);

                    SqlParameter pCF_ID = cmd.Parameters.Add("@CF_ID", SqlDbType.Int);
                    SqlParameter pCF_FIELD_ID = cmd.Parameters.Add("@CF_FIELD_ID", SqlDbType.Int);
                    SqlParameter pCF_VISIBLE = cmd.Parameters.Add("@CF_VISIBLE", SqlDbType.Int);
                    SqlParameter pCF_EDITABLE = cmd.Parameters.Add("@CF_EDITABLE", SqlDbType.Int);
                    SqlParameter pCF_FROZEN = cmd.Parameters.Add("@CF_FROZEN", SqlDbType.Int);
                    SqlParameter pCF_IDENTITY = cmd.Parameters.Add("@CF_IDENTITY", SqlDbType.Int);
                    SqlParameter pCF_REQUIRED = cmd.Parameters.Add("@CF_REQUIRED", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pCF_ID.Value = row["CF_FIELD_ID"];
                        pCF_FIELD_ID.Value = row["CF_FIELD_ID"];
                        pCF_VISIBLE.Value = row["CF_VISIBLE"];
                        pCF_EDITABLE.Value = row["CF_EDITABLE"];
                        pCF_FROZEN.Value = row["CF_FROZEN"];
                        pCF_IDENTITY.Value = row["CF_IDENTITY"];
                        pCF_REQUIRED.Value = row["CF_REQUIRED"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostCustomFields", (StatusEnum)99954, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostTypeFormula(DBAccess dba, int nCostTypeID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_COST_CALC (CT_ID,CL_ID,CL_CT_ID,CL_OP) VALUES(@CT_ID,@CL_ID,@CL_CT_ID,@CL_OP)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);

                    SqlParameter pCL_ID = cmd.Parameters.Add("@CL_ID", SqlDbType.Int);
                    SqlParameter pCL_CT_ID = cmd.Parameters.Add("@CL_CT_ID", SqlDbType.Int);
                    SqlParameter pCL_OP = cmd.Parameters.Add("@CL_OP", SqlDbType.Int);

                    int nIndex = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        pCL_ID.Value = nIndex++;
                        pCL_CT_ID.Value = row["CL_CT_ID"];
                        pCL_OP.Value = row["CL_OP"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostTypeFormula", (StatusEnum)99973, ex.Message.ToString());
                }
            }
            return eStatus;
        }
    }

    internal class dbaEditCosts
    {
        public static StatusEnum SelectProjectIDByExtUID(DBAccess dba, string sExtUID, out int nProjectID)
        {
            string cmdText = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID = @PROJECT_EXT_UID";
            StatusEnum eStatus = StatusEnum.rsSuccess;
            nProjectID = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.Add("@PROJECT_EXT_UID", SqlDbType.VarChar, 128).Value = sExtUID;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nProjectID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectProjectIDByExtUID", (StatusEnum)99999, ex.Message.ToString());
            }
            return eStatus;
        }
        
        public static StatusEnum SelectPIs(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT PROJECT_ID, PROJECT_NAME FROM EPGP_PROJECTS ORDER BY PROJECT_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99972, out dt);
        }

        public static StatusEnum SelectViews(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT VIEW_UID, VIEW_NAME FROM EPGT_COSTVIEW_DISPLAY ORDER BY VIEW_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99971, out dt);
        }

        public static StatusEnum SelectCostTypesByView(DBAccess dba, int nViewUID, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_TYPES CT LEFT JOIN EPGT_COSTVIEW_COST_TYPES CV ON (CT.CT_ID = CV.CT_ID AND VIEW_UID = " + nViewUID.ToString() + ") WHERE CT.CT_ID IN (SELECT CT_ID FROM EPGT_COSTVIEW_COST_TYPES WHERE VIEW_UID = " + nViewUID.ToString() + ") ORDER BY CV.VT_ID";
            return dba.SelectData(cmdText, (StatusEnum)99970, out dt);
        }

        public static StatusEnum SelectCostType(DBAccess dba, int nCostTypeID, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_TYPES WHERE CT_ID = @p1";
            return dba.SelectDataById(cmdText, nCostTypeID, (StatusEnum)99953, out dt);
        }

        public static StatusEnum SelectCostTypeOperations(DBAccess dba, int nCostTypeID, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_CALC WHERE CT_ID = @p1 ORDER BY CL_ID";
            return dba.SelectDataById(cmdText, nCostTypeID, (StatusEnum)99952, out dt);
        }

        public static StatusEnum SelectNamedRateItems(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_RATES ORDER BY RT_ID, RT_LEVEL";
            return dba.SelectData(cmdText, (StatusEnum)99951, out dt);
        }

        public static StatusEnum SelectNamedRateValues(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_RATE_VALUES ORDER BY RT_UID, RT_EFFECTIVE_DATE DESC";
            return dba.SelectData(cmdText, (StatusEnum)99950, out dt);
        }

        public static StatusEnum SelectCalendarPeriods(DBAccess dba, int nCalendarID, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_PERIODS WHERE CB_ID=@p1 ORDER BY PRD_ID";
            return dba.SelectDataById(cmdText, nCalendarID, (StatusEnum)99969, out dt);
        }

        public static StatusEnum SelectViewCalendarInfo(DBAccess dba, int nViewUID, out int nCalendarID, out int nFirstPeriod, out int nLastPeriod)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            string s = string.Empty;
            nCalendarID = -1;
            nFirstPeriod = Int32.MinValue;
            nLastPeriod = Int32.MaxValue;
            bool bIsNull;
            try
            {
                string cmdText = "SELECT * FROM EPGT_COSTVIEW_DISPLAY WHERE VIEW_UID=@p1";
                DataTable dt;
                if (dba.SelectDataById(cmdText, nViewUID, (StatusEnum)99968, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    nCalendarID = (int)row["VIEW_COST_BREAKDOWN"];
                    int n = DBAccess.ReadIntValue(row["VIEW_FIRST_PERIOD"], out bIsNull);
                    if (bIsNull == false && n > 0) nFirstPeriod = n;
                    n = DBAccess.ReadIntValue(row["VIEW_LAST_PERIOD"], out bIsNull);
                    if (bIsNull == false && n > 0) nLastPeriod = n;
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectViewCalendarInfo", (StatusEnum)99967, ex.Message.ToString());
            }
            return eStatus;
Status_Error:
            return dba.Status;
        }

        public static StatusEnum SelectCostCategories(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT CC.BC_UID, CC.BC_ID, BC_NAME, BC_LEVEL, BC_UOM, AC.CT_ID FROM EPGP_COST_CATEGORIES CC LEFT JOIN EPGP_AVAIL_CATEGORIES AC ON (CC.BC_UID = AC.BC_UID and AC.CT_ID = @p1) ORDER BY BC_ID";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99949, out dt);
        }

        public static StatusEnum SelectPIDetails(DBAccess dba, int nProjectID, out DataTable dt)
        {
            string cmdText = 
                "SELECT PROJECT_CHECKEDOUT,PROJECT_CHECKEDOUT_BY, PROJECT_CHECKEDOUT_DATE, EPG_RESOURCES.RES_NAME" +
                " FROM EPGP_PROJECTS" + 
                " LEFT OUTER JOIN EPG_RESOURCES ON EPGP_PROJECTS.PROJECT_CHECKEDOUT_BY = EPG_RESOURCES.WRES_ID" +
                " WHERE PROJECT_ID = @p1";
            return dba.SelectDataById(cmdText, nProjectID, (StatusEnum)99949, out dt);
        }

        public static StatusEnum SelectCostCategoryData(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                //string cmdText =
                //      "SELECT BC.*, CD.* "
                //    + "FROM EPGP_COST_CATEGORIES BC "
                //    + "left JOIN EPGP_COST_DETAILS CD ON (BC.BC_UID = null) "
                //    + "union "
                //    + "SELECT BC.*, CD.* "
                //    + "FROM EPGP_COST_CATEGORIES BC "
                //    + "left JOIN EPGP_COST_DETAILS CD ON (BC.BC_UID = CD.BC_UID) "
                //    + "WHERE CD.CB_ID = @p1 AND CD.CT_ID = @p1 AND CD.PROJECT_ID = @p1 "
                //    + "ORDER BY BC_ID ";
                //string cmdText =
                //      "SELECT BC.*, CD.BC_UID as Used,OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05 "
                //    + "FROM EPGP_COST_CATEGORIES BC "
                //    + "inner JOIN EPGP_AVAIL_CATEGORIES AC ON (BC.BC_UID = AC.BC_UID AND  AC.CT_ID = @p1) "
                //    + "left JOIN EPGP_COST_DETAILS CD ON (BC.BC_UID = CD.BC_UID AND CD.CT_ID = @p1 AND CD.PROJECT_ID = @p1 AND CD.CB_ID = @p1) "
                //    + "ORDER BY BC_ID ";
                string cmdText =
                      "SELECT BC.*,CD.BC_UID as Used,CD.BC_SEQ as Seq,CD.RT_UID,R.RT_NAME,LV1.LV_VALUE as LV_01, LV2.LV_VALUE as LV_02, LV3.LV_VALUE as LV_03, LV4.LV_VALUE as LV_04, LV5.LV_VALUE as LV_05, OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05 "
                    + "FROM EPGP_COST_CATEGORIES BC "
                    + "inner JOIN EPGP_AVAIL_CATEGORIES AC ON (BC.BC_UID = AC.BC_UID AND AC.CT_ID = @p1) "
                    + "left JOIN EPGP_COST_DETAILS CD ON (BC.BC_UID = CD.BC_UID AND CD.CT_ID = @p2 AND CD.PROJECT_ID = @p3 AND CD.CB_ID = @p4) "
                    + "left JOIN EPG_RATES R ON (R.RT_UID = CD.RT_UID) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV1 ON (LV1.LV_UID = OC_01) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV2 ON (LV2.LV_UID = OC_02) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV3 ON (LV3.LV_UID = OC_03) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV4 ON (LV4.LV_UID = OC_04) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV5 ON (LV5.LV_UID = OC_05) "
                    + "ORDER BY BC_ID,CD.BC_SEQ ";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                //cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                cmd.Parameters.AddWithValue("@p1", nCostTypeID);
                cmd.Parameters.AddWithValue("@p2", nCostTypeID);
                cmd.Parameters.AddWithValue("@p3", nProjectID);
                cmd.Parameters.AddWithValue("@p4", nCalendarID);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectCostCategoryData", (StatusEnum)99966, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum SelectCostCustomFields(DBAccess dba, int nCostTypeId, out DataTable dt)
        {
            //string cmdText = "SELECT * FROM EPGP_COST_CUSTOM_FIELDS ORDER BY CT_ID, CF_ID";
            string cmdText = "SELECT * FROM EPGP_COST_CUSTOM_FIELDS "
                    + "INNER JOIN EPGP_FIELD_ATTRIBS ON (FA_FIELD_ID = CF_FIELD_ID) "
                    + "WHERE CT_ID = @p1 "
                    + "ORDER BY CT_ID, CF_ID ";
            return dba.SelectDataById(cmdText, nCostTypeId, (StatusEnum)99948, out dt);
        }

        public static StatusEnum SelectLookup(DBAccess dba, int nLookupId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID";
            return dba.SelectDataById(cmdText, nLookupId, (StatusEnum)99947, out dt);
        }

        public static StatusEnum SelectPeriodsRates(DBAccess dba, int nCalendarID, out DataTable dt)
        {
            string cmdText =
                "SELECT * "
              + "FROM EPGP_COST_BREAKDOWN_ATTRIBS "
              + "WHERE CB_ID=@p1 "
              + "ORDER BY BA_BC_UID, BA_PRD_ID";
            return dba.SelectDataById(cmdText, nCalendarID, (StatusEnum)99965, out dt);
        }

        public static StatusEnum SelectPeriodsCostDetailsValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                string cmdText =
                    "SELECT DISTINCT CD.*, BD_PERIOD,BD_VALUE,BD_COST "
                  + "FROM EPGP_COST_DETAILS CD "
                  + "LEFT JOIN EPGP_DETAIL_VALUES DV ON (DV.CB_ID = CD.CB_ID AND DV.CT_ID = CD.CT_ID AND DV.PROJECT_ID = CD.PROJECT_ID AND DV.BC_UID = CD.BC_UID AND DV.BC_SEQ = CD.BC_SEQ) "
                  + "WHERE CD.CB_ID=@p1 AND CD.CT_ID=@p2 AND CD.PROJECT_ID=@p3 "
                  + "ORDER BY CD.CB_ID, CD.CT_ID, CD.PROJECT_ID, CD.BC_UID, CD.BC_SEQ, BD_PERIOD";

                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                cmd.Parameters.AddWithValue("@p1", nCalendarID);
                cmd.Parameters.AddWithValue("@p2", nCostTypeID);
                cmd.Parameters.AddWithValue("@p3", nProjectID);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectPeriodsCostDetailsValues", (StatusEnum)99964, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum SelectPeriodsCostValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                string cmdText =
                    "SELECT * FROM EPGP_COST_VALUES "
                  + "WHERE CB_ID=@CB_ID AND CT_ID=@CT_ID AND PROJECT_ID=@PROJECT_ID "
                  + "ORDER BY CB_ID, CT_ID, PROJECT_ID, BC_UID, BD_PERIOD";

                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectPeriodsCostValues", (StatusEnum)99946, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeleteCostDetailValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "DELETE FROM EPGP_DETAIL_VALUES WHERE PROJECT_ID = @PROJECT_ID AND CT_ID = @CT_ID AND CB_ID = @CB_ID AND BC_UID = @BC_UID AND BC_SEQ = @BC_SEQ AND BD_PERIOD = @BD_PERIOD";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                    cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);

                    SqlParameter pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);
                    SqlParameter pBC_SEQ = cmd.Parameters.Add("@BC_SEQ", SqlDbType.Int);
                    SqlParameter pBD_PERIOD = cmd.Parameters.Add("@BD_PERIOD", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        pBC_SEQ.Value = row["BC_SEQ"];
                        pBD_PERIOD.Value = row["BD_PERIOD"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetailValues", (StatusEnum)99963, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostDetails(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_COST_DETAILS (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_SEQ,RT_UID,OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05) VALUES(@CB_ID,@CT_ID,@PROJECT_ID,@BC_UID,@BC_SEQ,@RT_UID,@OC_01,@OC_02,@OC_03,@OC_04,@OC_05,@TEXT_01,@TEXT_02,@TEXT_03,@TEXT_04,@TEXT_05)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                    cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);

                    SqlParameter pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);
                    SqlParameter pBC_SEQ = cmd.Parameters.Add("@BC_SEQ", SqlDbType.Int);
                    SqlParameter pRT_UID = cmd.Parameters.Add("@RT_UID", SqlDbType.Int);
                    SqlParameter pOC_01 = cmd.Parameters.Add("@OC_01", SqlDbType.Int);
                    SqlParameter pOC_02 = cmd.Parameters.Add("@OC_02", SqlDbType.Int);
                    SqlParameter pOC_03 = cmd.Parameters.Add("@OC_03", SqlDbType.Int);
                    SqlParameter pOC_04 = cmd.Parameters.Add("@OC_04", SqlDbType.Int);
                    SqlParameter pOC_05 = cmd.Parameters.Add("@OC_05", SqlDbType.Int);
                    SqlParameter pTEXT_01 = cmd.Parameters.Add("@TEXT_01", SqlDbType.VarChar, 255);
                    SqlParameter pTEXT_02 = cmd.Parameters.Add("@TEXT_02", SqlDbType.VarChar, 255);
                    SqlParameter pTEXT_03 = cmd.Parameters.Add("@TEXT_03", SqlDbType.VarChar, 255);
                    SqlParameter pTEXT_04 = cmd.Parameters.Add("@TEXT_04", SqlDbType.VarChar, 255);
                    SqlParameter pTEXT_05 = cmd.Parameters.Add("@TEXT_05", SqlDbType.VarChar, 255);

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        pBC_SEQ.Value = row["BC_SEQ"];
                        pRT_UID.Value = row["RT_UID"];
                        pOC_01.Value = row["OC_01"];
                        pOC_02.Value = row["OC_02"];
                        pOC_03.Value = row["OC_03"];
                        pOC_04.Value = row["OC_04"];
                        pOC_05.Value = row["OC_05"];
                        pTEXT_01.Value = row["TEXT_01"];
                        pTEXT_02.Value = row["TEXT_02"];
                        pTEXT_03.Value = row["TEXT_03"];
                        pTEXT_04.Value = row["TEXT_04"];
                        pTEXT_05.Value = row["TEXT_05"];
                        cmd.ExecuteNonQuery();
                    }

                    cmdText =
                        "INSERT INTO EPGP_PROJECT_CT_STATUS (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_STATUS) VALUES(@CB_ID,@CT_ID,@PROJECT_ID,@BC_UID,1)";
                    cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                    cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);

                    pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostDetails", (StatusEnum)99945, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostDetailValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_DETAIL_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_SEQ,BD_PERIOD,BD_VALUE,BD_COST) VALUES(@CB_ID,@CT_ID,@PROJECT_ID,@BC_UID,@BC_SEQ,@BD_PERIOD,@BD_VALUE,@BD_COST)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                    cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);

                    SqlParameter pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);
                    SqlParameter pBC_SEQ = cmd.Parameters.Add("@BC_SEQ", SqlDbType.Int);
                    SqlParameter pBD_PERIOD = cmd.Parameters.Add("@BD_PERIOD", SqlDbType.Int);
                    SqlParameter pBD_VALUE = cmd.Parameters.Add("@BD_VALUE", SqlDbType.Decimal);
                    SqlParameter pBD_COST = cmd.Parameters.Add("@BD_COST", SqlDbType.Decimal);

                    pBD_VALUE.Precision = 25;
                    pBD_VALUE.Scale = 6;
                    pBD_COST.Precision = 25;
                    pBD_COST.Scale = 6;

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        pBC_SEQ.Value = row["BC_SEQ"];
                        pBD_PERIOD.Value = row["BD_PERIOD"];
                        pBD_VALUE.Value = row["BD_VALUE"];
                        pBD_COST.Value = row["BD_COST"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostDetailValues", (StatusEnum)99962, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        //sCommand = "UPDATE EPGP_PROJECTS SET PROJECT_CHECKEDOUT = 1, PROJECT_CHECKEDOUT_BY = " & Format(lWResID) & _
        //           ", PROJECT_CHECKEDOUT_DATE = Getdate() WHERE PROJECT_ID = " & Format(lPI)
                   
        //Call oDataAccess.ExecuteSQL(oRecordset, sCommand, 8512, eStatus)

        public static StatusEnum CheckoutPI(DBAccess dba, int nProjectID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "UPDATE EPGP_PROJECTS SET PROJECT_CHECKEDOUT = 1, PROJECT_CHECKEDOUT_BY = @PROJECT_CHECKEDOUT_BY, PROJECT_CHECKEDOUT_DATE = @PROJECT_CHECKEDOUT_DATE"
                 + " WHERE PROJECT_ID = @PROJECT_ID AND (PROJECT_CHECKEDOUT = 0 OR PROJECT_CHECKEDOUT IS NULL OR PROJECT_CHECKEDOUT_BY = @PROJECT_CHECKEDOUT_BY2)";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                cmd.Parameters.AddWithValue("@PROJECT_CHECKEDOUT_BY", dba.UserWResID);
                cmd.Parameters.AddWithValue("@PROJECT_CHECKEDOUT_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@PROJECT_CHECKEDOUT_BY2", dba.UserWResID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "CheckoutPI", (StatusEnum)99999, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum CheckinPI(DBAccess dba, int nProjectID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "UPDATE EPGP_PROJECTS SET PROJECT_CHECKEDOUT = 0 WHERE PROJECT_ID = @PROJECT_ID AND PROJECT_CHECKEDOUT = 1 AND PROJECT_CHECKEDOUT_BY = @PROJECT_CHECKEDOUT_BY";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@PROJECT_CHECKEDOUT_BY", dba.UserWResID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "CheckinPI", (StatusEnum)99999, ex.Message.ToString());
            }
            return eStatus;
        }

        //public static StatusEnum DeleteCostDetailsAndValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, string sDeletedIds, out int lRowsAffected)
        //{
        //    StatusEnum eStatus = StatusEnum.rsSuccess;
        //    lRowsAffected = 0;
        //    {
        //        try
        //        {
        //            string cmdText =
        //                "DELETE FROM EPGP_COST_DETAILS WHERE PROJECT_ID = @p1 AND CT_ID = @p1 AND CB_ID = @p1 AND BC_UID IN (" + sDeletedIds + ")";
        //            SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
        //            cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
        //            cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
        //            cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
        //            lRowsAffected = cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetailsAndValues1", (StatusEnum)99944, ex.Message.ToString());
        //        }
        //    }
        //    if (eStatus == StatusEnum.rsSuccess)
        //    {
        //        try
        //        {
        //            string cmdText =
        //                "DELETE FROM EPGP_DETAIL_VALUES WHERE PROJECT_ID = @p1 AND CT_ID = @p1 AND CB_ID = @p1 AND BC_UID IN (" + sDeletedIds + ")";
        //            SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
        //            cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
        //            cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
        //            cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
        //            lRowsAffected = cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetailsAndValues2", (StatusEnum)99943, ex.Message.ToString());
        //        }
        //    }
        //    return eStatus;
        //}

        public static StatusEnum DeleteCostDetails(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_COST_DETAILS WHERE PROJECT_ID = @PROJECT_ID AND CT_ID = @CT_ID AND CB_ID = @CB_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                lRowsAffected = cmd.ExecuteNonQuery();

                cmdText =
                    "DELETE FROM EPGP_PROJECT_CT_STATUS WHERE PROJECT_ID = @PROJECT_ID AND CT_ID = @CT_ID AND CB_ID = @CB_ID";
                cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                cmd.ExecuteNonQuery();
            
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetails", (StatusEnum)99961, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeleteCostDetailsValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                        "DELETE FROM EPGP_DETAIL_VALUES WHERE PROJECT_ID = @PROJECT_ID AND CT_ID = @CT_ID AND CB_ID = @CB_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetailsValues", (StatusEnum)99960, ex.Message.ToString());
            }
            return eStatus;
        }
    }

    internal class dbaGeneral
    {
        public static StatusEnum SelectAdmin(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_ADMIN";
            return dba.SelectData(cmdText, (StatusEnum)99942, out dt);
        }
        public static StatusEnum SelectLookups(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_LOOKUP_TABLES ORDER BY LOOKUP_UID";
            return dba.SelectData(cmdText, (StatusEnum)99941, out dt);
        }
        public static StatusEnum SelectLookup(DBAccess dba, int nLookupId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID";
            return dba.SelectDataById(cmdText, nLookupId, (StatusEnum)99940, out dt);
        }
    }

    internal class DBAccess : SqlDb
    {
        private int m_lActiveTraceChannels = 0;
        private CStruct m_xTraceMessages = null;
        private string m_sSessionInfo = "";
        public int UserWResID = 0;
        public string UserName = "";

        public DBAccess(string connectionString) : base(connectionString) { }


        public override StatusEnum HandleException(string sFunction, StatusEnum eStatus, Exception ex)
        {
            base.HandleException(sFunction, eStatus, ex);
            DBTrace(eStatus, TraceChannelEnum.Exception, "HandleException", sFunction, ex.Message.ToString(), "Exception Stack : " + ex.StackTrace.ToString(), true);
            return eStatus;
        }

        public override StatusEnum HandleStatusError(SeverityEnum eSeverity, string sFunction, StatusEnum eStatus, string sText)
        {
            base.HandleStatusError(eSeverity, sFunction, eStatus, sText);
            DBTrace(eStatus, TraceChannelEnum.Exception, "HandleStatusError", sFunction, sText, "Severity : " + eSeverity.ToString(), true);
            return eStatus;
        }

        public override void DBTrace(StatusEnum eStatus, TraceChannelEnum eChannel, string sKeyword, string sFunction, string sText, string sDetails, bool bImmediate)
        {

            // let's see if the channel is one of the active DB trace channels
            if (((int)eChannel & m_lActiveTraceChannels) == 0)
                return;

            if (m_xTraceMessages == null)
            {
                m_xTraceMessages = new CStruct();
                m_xTraceMessages.Initialize("TraceMessages");
            }

            CStruct xTrace;
            xTrace = m_xTraceMessages.CreateSubStruct("Trace");
            xTrace.CreateIntAttr("Status", (int)eStatus);
            xTrace.CreateIntAttr("Channel", (int)eChannel);
            xTrace.CreateDateAttr("Timestamp", DateTime.Now);
            xTrace.CreateStringAttr("Keyword", sKeyword);
            xTrace.CreateStringAttr("Function", sFunction);
            xTrace.CreateStringAttr("Text", sText);
            xTrace.CreateStringAttr("Details", sDetails);

            if (bImmediate)
            {
                WriteTrace();
            }
        }

        private void WriteTrace()
        {
            if (m_xTraceMessages == null)
                return;
            if (Open() != StatusEnum.rsSuccess)
                return;

            string sCommand =
                "INSERT INTO EPG_LOG (LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS) "
              + " VALUES(@LOG_WRES_ID,@LOG_SESSION,@LOG_STATUS,@LOG_CHANNEL,@LOG_TIMESTAMP,@LOG_KEYWORD,@LOG_FUNCTION,@LOG_TEXT,@LOG_DETAILS)";
            try
            {
                SqlCommand oCommand = new SqlCommand(sCommand, base.Connection);

                oCommand.Parameters.Add("@LOG_WRES_ID", SqlDbType.Int).Value = UserWResID;
                oCommand.Parameters.Add("@LOG_SESSION", SqlDbType.VarChar, vb.Max(1, m_sSessionInfo.Length)).Value = m_sSessionInfo;

                SqlParameter pStatus = oCommand.Parameters.Add("@LOG_STATUS", SqlDbType.Int);
                SqlParameter pChannel = oCommand.Parameters.Add("@LOG_CHANNEL", SqlDbType.Int);
                SqlParameter pTimestamp = oCommand.Parameters.Add("@LOG_TIMESTAMP", SqlDbType.Timestamp);
                SqlParameter pKeyword = oCommand.Parameters.Add("@LOG_KEYWORD", SqlDbType.VarChar, 50);
                SqlParameter pFunction = oCommand.Parameters.Add("@LOG_FUNCTION", SqlDbType.VarChar, 50);
                SqlParameter pText = oCommand.Parameters.Add("@LOG_TEXT", SqlDbType.VarChar, 255);
                SqlParameter pDetails = oCommand.Parameters.Add("@LOG_DETAILS", SqlDbType.VarChar, 2048);


                Queue<CStruct> clnTraceMessages = m_xTraceMessages.GetCollection("Trace");
                foreach (CStruct xTrace in clnTraceMessages)
                {
                    pStatus.Value = xTrace.GetIntAttr("Status");
                    pChannel.Value = xTrace.GetIntAttr("Channel");
                    pTimestamp.Value = xTrace.GetDateAttr("Timestamp");
                    pKeyword.Value = vb.Left(xTrace.GetStringAttr("Keyword"), 48);
                    pFunction.Value = vb.Left(xTrace.GetStringAttr("Function"), 48);
                    pText.Value = vb.Left(xTrace.GetStringAttr("Text"), 253);
                    pDetails.Value = vb.Left(xTrace.GetStringAttr("Details"), 2048);

                    int lRowsAffected = oCommand.ExecuteNonQuery();
                }
                m_xTraceMessages = null;
            }
            catch (Exception ex)
            {
                Status = (StatusEnum)9899;
                StatusText = "WriteTrace Exception : " + ex.Message.ToString();
                // can't call HandleStatusError here
                //HandleStatusError(SeverityEnum.Exception, "CDataAccess.WriteTrace", (StatusEnum)9265, ex.Message.ToString());
            }
            return;
        }
    }

    internal class SqlDb
    {
        private string m_sConnect = string.Empty;
        private string m_sEPKUID = string.Empty;
        private string m_sEPKPWD = string.Empty;
        private SqlConnection m_oConnection = null;
        private SqlTransaction m_oTransaction = null;

        private static SeverityEnum m_eStatusSeverity = SeverityEnum.None;
        private static StatusEnum m_eStatus = StatusEnum.rsSuccess;
        private static string m_sStatusFunction = string.Empty;
        private static string m_sStatusText = string.Empty;
        private static string m_sStackTrace = string.Empty;


        public SqlDb(string connectionString)
        {
            m_sConnect = connectionString;
        }

        public StatusEnum Open()
        {
            ResetStatus();
            try
            {
                if (m_oConnection == null)
                {
                    if (m_oConnection == null) m_oConnection = new SqlConnection();
                    var dbConnectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = m_sConnect };
                    dbConnectionStringBuilder.Remove("Provider");
                    //if (m_sEPKUID == "")
                        m_oConnection.ConnectionString = dbConnectionStringBuilder.ToString() + ";Application Name=PortfolioEngine";
                    //else
                    //    m_oConnection.ConnectionString = m_sConnect + ";UID=" + m_sEPKUID + ";PWD=" + m_sEPKPWD + ";Application Name=PortfolioEngine";

                }
                if (m_oConnection.State == ConnectionState.Open) 
                    m_oConnection.Close();
                m_oConnection.Open();
            }
            catch (Exception ex)
            {
                HandleStatusError(SeverityEnum.Exception, "Sql.Open", (StatusEnum)99959, ex.Message.ToString() + "; Connect='" + m_oConnection.ConnectionString + "'");
            }
            return m_eStatus;
        }

        public void Close()
        {
            if (m_oConnection != null)
            {
                if (m_oConnection.State != System.Data.ConnectionState.Closed)
                    m_oConnection.Close();
                m_oConnection.Dispose();
                m_oConnection = null;
            }
        }

        public StatusEnum SelectData(string cmdText, StatusEnum eStatusOnException, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "SelectData", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            finally {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            return eStatus;
        }

        public StatusEnum SelectData(SqlCommand cmd, StatusEnum eStatusOnException, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            SqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "SelectData", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            return eStatus;
        }

        public StatusEnum SelectDataById(string cmdText, int id, StatusEnum eStatusOnException, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                cmd.Parameters.AddWithValue("@p1", id);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "SelectDataById", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            return eStatus;
        }

        public StatusEnum DeleteDataById(string cmdText, int id, StatusEnum eStatusOnException, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                cmd.Parameters.AddWithValue("@p1", id);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "DeleteDataById", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            return eStatus;
        }

        public StatusEnum DeleteData(string cmdText, StatusEnum eStatusOnException, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "DeleteData", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            return eStatus;
        }

        public StatusEnum InsertData(string cmdText, StatusEnum eStatusOnException, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, m_oConnection, m_oTransaction);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = HandleStatusError(SeverityEnum.Exception, "InsertData", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            return eStatus;
        }



        public StatusEnum Status
        {
            get
            {
                return m_eStatus;
            }
            set
            {
                m_eStatus = value;
            }
        }

        public string StatusText
        {
            get
            {
                return m_sStatusText;
            }
            set
            {
                m_sStatusText = value;
            }
        }

        public string StackTrace
        {
            get
            {
                return m_sStackTrace;
            }
            set
            {
                m_sStackTrace = value;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return m_oConnection;
            }
        }

        public SqlTransaction Transaction
        {
            get
            {
                return m_oTransaction;
            }
        }

        public void ResetStatus()
        {
            m_eStatus = StatusEnum.rsSuccess;
            m_sStatusFunction = string.Empty;
            m_sStatusText = string.Empty;
            m_sStackTrace = string.Empty;
        }


        public virtual string FormatErrorText()
        {
            
            string s = "";
            if (m_eStatus != StatusEnum.rsSuccess)
            {
                switch (m_eStatusSeverity)
                {
                    case SeverityEnum.Exception:
                        s = "Exception " + m_eStatus.ToString() + " has occurred in " + m_sStatusFunction;
                        break;
                    case SeverityEnum.Error:
                        s = "Error " + m_eStatus.ToString() + " has occurred in " + m_sStatusFunction;
                        break;
                    default:
                        s = "Status Error " + m_eStatus.ToString() + " has occurred in " + m_sStatusFunction;
                        break;
                }

                if (m_sStatusText != string.Empty)
                    s += "\n" + "Text : '" + m_sStatusText + "'"; ;
                if (m_sStackTrace != string.Empty)
                    s += "\n" + "Trace : '" + m_sStackTrace + "'"; ;
            }
            return s;
        }

        public virtual StatusEnum HandleException(string sFunction, StatusEnum eStatus, Exception ex)
        {
            m_eStatusSeverity = SeverityEnum.Exception;
            m_sStatusFunction = sFunction;
            m_eStatus = eStatus;
            m_sStatusText = ex.Message.ToString();
            m_sStackTrace = ex.StackTrace.ToString();
            return m_eStatus;
        }

        public virtual StatusEnum HandleStatusError(SeverityEnum eSeverity, string sFunction, StatusEnum eStatus, string sText)
        {
            m_eStatusSeverity = eSeverity;
            m_sStatusFunction = sFunction;
            m_eStatus = eStatus;
            m_sStatusText = sText;
            return m_eStatus;
        }

        public void BeginTransaction()
        {
            //m_oConnection.Execute CommandText:="BEGIN TRAN", Options:=adExecuteNoRecords
            m_oTransaction = m_oConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            //m_oConnection.Execute CommandText:="IF @@TRANCOUNT > 0 COMMIT TRAN", Options:=adExecuteNoRecords
            if (m_oTransaction != null)
                m_oTransaction.Commit();
            m_oTransaction = null;
        }

        public void RollbackTransaction()
        {
            //m_oConnection.Execute CommandText:="IF @@TRANCOUNT > 0 ROLLBACK TRAN", Options:=adExecuteNoRecords
            if (m_oTransaction != null)
                m_oTransaction.Rollback();
            m_oTransaction = null;
        }

        public virtual void DBTrace(StatusEnum eStatus, TraceChannelEnum eChannel, string sKeyword, string sFunction, string sText, string sDetails, bool bImmediate)
        {
        }

        static public DateTime ReadDateValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToDateTime(obj);
            }
            return DateTime.MinValue;
        }

        static public DateTime ReadDateValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToDateTime(obj);
            }
            bIsNull = true;
            return DateTime.MinValue;
        }

        static public string ReadStringValue(object obj)
        {
            return ReadStringValue(obj, "");
        }

        static public string ReadStringValue(object obj, string sDefault)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToString(obj);
            }
            return sDefault;
        }

        static public string ReadStringValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToString(obj);
            }
            bIsNull = true;
            return "";
        }

        static public double ReadDoubleValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToDouble(obj);
            }
            return 0.0;
        }

        static public double ReadDoubleValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToDouble(obj);
            }
            bIsNull = true;
            return 0.0;
        }

        static public decimal ReadDecimalValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToDecimal(obj);
            }
            return 0.0M;
        }

        static public decimal ReadDecimalValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToDecimal(obj);
            }
            bIsNull = true;
            return 0.0M;
        }

        static public bool ReadBoolValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToBoolean(obj);
            }
            return false;
        }

        static public bool ReadBoolValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToBoolean(obj);
            }
            bIsNull = true;
            return false;
        }

        static public int ReadIntValue(object obj)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

        static public int ReadIntValue(object obj, out bool bIsNull)
        {
            if (!obj.Equals(System.DBNull.Value))
            {
                bIsNull = false;
                return Convert.ToInt32(obj);
            }
            bIsNull = true;
            return 0;
        }

        public string PrepareText(string sText)
        {
            return "'" + sText.Replace("'", "''") + "'";
        }

        //public StatusEnum GetLastIdentityValue(out int lAutoNumber)
        //{
        //    ResetStatus();
        //    SqlCommand oCommand = new SqlCommand("EPG_SP_GetLastAutonumber", this.Connection);
        //    oCommand.Transaction = this.Transaction;
        //    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //    SqlDataReader reader = oCommand.ExecuteReader();
        //    lAutoNumber = 0;
        //    if (reader.Read())
        //    {
        //        lAutoNumber = ReadIntValue(reader["AutoNumber"]);
        //    }
        //    reader.Close();
        //    return m_eStatus;
        //    //Exception_Error:
        //    //    eStatus = HandleException("CDbAccess.GetLastIdentityValue", 9703)
        //    //    GetLastIdentityValue = eStatus
        //}

        //public StatusEnum ExecuteReader(string sCommand, StatusEnum eExceptionStatus, out SqlDataReader reader, out StatusEnum eStatus)
        //{
        //    ResetStatus();
        //    SqlCommand oCommand = null;
        //    try
        //    {
        //        oCommand = new SqlCommand(sCommand, m_oConnection);
        //        reader = oCommand.ExecuteReader();
        //    }
        //    catch (Exception ex)
        //    {
        //        reader = null;
        //        HandleException("DbBase.ExecuteReader", eExceptionStatus, ex);
        //    }
        //    finally
        //    {
        //        oCommand = null;
        //    }
        //    eStatus = m_eStatus;
        //    return m_eStatus;
        //}

    }
}

