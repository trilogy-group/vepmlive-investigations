using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    internal class CAdmin
    {
        public int ApprovalCode;
        public int ProjectChargeNumberCFID;
        public int ProjectChargeStatusCFID;
        public int TaskChargeNumberCFID;
        public int TaskChargeStatusCFID;
        public int PortfolioChargeNumberCFID;
        public int PortfolioChargeStatusCFID;
        public int MajorCategoryCode;
        public int MajorCategoryDefault;
        public int TaskEstimatedFinishDFID;
        public int LookaheadDays;
        public int PortfolioCommitmentsCalendarUID;
        public int PortfolioCommitmentsMode;
        public int PortfolioCommitmentsOpMode;
        // RPE stands for Resource Plan Editor which is the same as PortfolioCommitments but much shorter
        public int RPDeptCode;
        public bool RPEValidateRevenueProcess;
        public bool RPEExcludeNonWorkHours;
        public DateTime StatusDate;
        public bool StatusDateIsNull;
        public int RoleCode;
        public int TSVersion;
        public int DefaultVersion;
        public int EVVersion;
        public int EVCalendar;
        public int EVNodeLookup;
        public int EVOBSLookup;
        public int EVMethodLookup;
        public string CurrencySymbol;
        public int CurrencyDigits;
        public int CurrencyPosition;
        public int MinutesPerDay;
        public bool TSRuleAllSubmitted;
        public bool TSRuleAllDeptApproved;
        public bool TSRuleAllProjApproved;
        public bool TSRuleAllDeptsClosed;
        public bool TSAllowAddRowWhenNobodyAssigned;
        public bool TSAllowAddRowWhenOthersAssigned;
        public string WEServerURL;
        public string PSServerURL;
        public string PSPublishedDBConnect;
        public string PSReportingDBConnect;
        public int PIGroupCF1;
        public int PIGroupCF2;
        public bool WIAllowProvMembers;
        public bool AssnsNeedRMApproval;
        public int UploadScheduleMethod;
        public int DefaultFTEWH;
        public int DefaultFTEHOL;
        public string WEReportingDBConnect;

        public StatusEnum GetAdminInfo(DBAccess dba)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            try
            {
                SqlCommand oCommand = null;
                SqlDataReader reader = null;
                oCommand = new SqlCommand("EPG_SP_ReadAdmin", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                reader = oCommand.ExecuteReader();

                bool bIsNull = false;
                if (reader.Read())
                {
                    ApprovalCode = DBAccess.ReadIntValue(reader["ADM_DEPT_CODE"]);
                    ProjectChargeNumberCFID = DBAccess.ReadIntValue(reader["ADM_PROJ_CHARGENUMBER_CFID"]);
                    ProjectChargeStatusCFID = DBAccess.ReadIntValue(reader["ADM_PROJ_CHARGESTATUS_CFID"]);
                    TaskChargeNumberCFID = DBAccess.ReadIntValue(reader["ADM_TASK_CHARGENUMBER_CFID"]);
                    TaskChargeStatusCFID = DBAccess.ReadIntValue(reader["ADM_TASK_CHARGESTATUS_CFID"]);
                    PortfolioChargeNumberCFID = DBAccess.ReadIntValue(reader["ADM_PORT_CHARGENUMBER_CFID"]);
                    PortfolioChargeStatusCFID = DBAccess.ReadIntValue(reader["ADM_PORT_CHARGESTATUS_CFID"]);
                    MajorCategoryCode = DBAccess.ReadIntValue(reader["ADM_MC_LOOKUP"]);
                    MajorCategoryDefault = DBAccess.ReadIntValue(reader["ADM_MC_DEFAULT"]);
                    TaskEstimatedFinishDFID = DBAccess.ReadIntValue(reader["ADM_TASK_ESTIMATEDFINISH_DFID"]);
                    RoleCode = DBAccess.ReadIntValue(reader["ADM_ROLE_CODE"]);

                    int lLookaheadDays = 0;
                    lLookaheadDays = DBAccess.ReadIntValue(reader["ADM_WORK_LOOKAHEAD_DAYS"], out bIsNull);
                    if (bIsNull || lLookaheadDays < 1)
                        LookaheadDays = 7;
                    else
                        LookaheadDays = lLookaheadDays;

                    PortfolioCommitmentsCalendarUID = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_CB_ID"], out bIsNull);
                    if (bIsNull)
                        PortfolioCommitmentsCalendarUID = -1;

                    StatusDate = DBAccess.ReadDateValue(reader["ADM_STATUS_DATE"], out bIsNull);
                    StatusDateIsNull = bIsNull;

                    PortfolioCommitmentsMode = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_MODE"]);
                    PortfolioCommitmentsOpMode = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_OPMODE"]);
                    RPDeptCode = DBAccess.ReadIntValue(reader["ADM_RPE_DEPT_CODE"]);
                    RPEValidateRevenueProcess = DBAccess.ReadBoolValue(reader["ADM_RPE_VALIDATE_REVENUE_PROCESS"]);
                    RPEExcludeNonWorkHours = DBAccess.ReadBoolValue(reader["ADM_RPE_EXCLUDE_NONWORKHOURS"]);
                    CurrencySymbol = DBAccess.ReadStringValue(reader["ADM_CURRENCY_SYMBOL"]);
                    CurrencyDigits = DBAccess.ReadIntValue(reader["ADM_CURRENCY_DIGITS"]);
                    CurrencyPosition = DBAccess.ReadIntValue(reader["ADM_CURRENCY_POSITION"]);
                    MinutesPerDay = DBAccess.ReadIntValue(reader["ADM_MINUTES_PER_DAY"]);
                    TSVersion = DBAccess.ReadIntValue(reader["ADM_TS_PROJ_VERSION_ID"]);
                    DefaultVersion = DBAccess.ReadIntValue(reader["ADM_DEFAULT_PROJ_VERSION_ID"]);
                    EVVersion = DBAccess.ReadIntValue(reader["ADM_EV_VERSION_ID"]);
                    EVCalendar = DBAccess.ReadIntValue(reader["ADM_EV_CB_ID"], out bIsNull);
                    if (bIsNull)
                        EVCalendar = -1;

                    EVNodeLookup = DBAccess.ReadIntValue(reader["ADM_EV_NODE_LOOKUP"]);
                    EVOBSLookup = DBAccess.ReadIntValue(reader["ADM_EV_OBS_LOOKUP"]);
                    EVMethodLookup = DBAccess.ReadIntValue(reader["ADM_EV_METHOD_LOOKUP"]);

                    TSRuleAllSubmitted = DBAccess.ReadBoolValue(reader["ADM_TS_RULE_ALLSUBMITTED"]);
                    TSRuleAllDeptApproved = DBAccess.ReadBoolValue(reader["ADM_TS_RULE_ALLDEPTAPPROVED"]);
                    TSRuleAllProjApproved = DBAccess.ReadBoolValue(reader["ADM_TS_RULE_ALLPROJAPPROVED"]);
                    TSRuleAllDeptsClosed = DBAccess.ReadBoolValue(reader["ADM_TS_RULE_ALLDEPTSCLOSED"]);

                    TSAllowAddRowWhenNobodyAssigned = DBAccess.ReadBoolValue(reader["ADM_TS_ALLOW_NO_ASSNS"]);
                    TSAllowAddRowWhenOthersAssigned = DBAccess.ReadBoolValue(reader["ADM_TS_ALLOW_OTHER_ASSNS"]);

                    WEServerURL = DBAccess.ReadStringValue(reader["ADM_WE_SERVERURL"]);
                    PSServerURL = DBAccess.ReadStringValue(reader["ADM_SERVERURL"]);
                    PSPublishedDBConnect = DBAccess.ReadStringValue(reader["ADM_PS_PUBLISHED_DB_CONNECT"]);
                    PSReportingDBConnect = DBAccess.ReadStringValue(reader["ADM_PS_REPORTING_DB_CONNECT"]);

                    PIGroupCF1 = DBAccess.ReadIntValue(reader["ADM_PI_GROUP_CF1"]);
                    PIGroupCF2 = DBAccess.ReadIntValue(reader["ADM_PI_GROUP_CF2"]);

                    WIAllowProvMembers = DBAccess.ReadBoolValue(reader["ADM_WI_ALLOW_PROV_MEMBERS"]);
                    AssnsNeedRMApproval = DBAccess.ReadBoolValue(reader["ADM_ASSNS_NEED_RM_APPROVAL"]);

                    UploadScheduleMethod = DBAccess.ReadIntValue(reader["ADM_UPLOAD_SCHEDULE_METHOD"]);

                    DefaultFTEWH = DBAccess.ReadIntValue(reader["ADM_DEF_FTE_WH"]);
                    DefaultFTEHOL = DBAccess.ReadIntValue(reader["ADM_DEF_FTE_HOL"]);
                    WEReportingDBConnect = DBAccess.ReadStringValue(reader["ADM_WE_REPORTING_DB_CONNECT"]);

                    reader.Close();
                    reader = null;
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleException("GetAdminInfo", (StatusEnum)99999, ex);
            }
            return eStatus;
        }

    }
}
