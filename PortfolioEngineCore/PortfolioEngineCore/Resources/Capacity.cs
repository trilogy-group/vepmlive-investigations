using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using ResourceValues;

namespace PortfolioEngineCore
{
    public class Capacity : PFEBase
    {
        public Capacity(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading Capacity Class");
        }

        public Capacity(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading Capacity Class");
        }

        public bool GetSuperRM()
        {
            bool bSuperRM = false;
            if (_userWResID == 1)
            {
                bSuperRM = true;
            }
            else
            {
                if (_dba.Open() != StatusEnum.rsSuccess)
                    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());
                bSuperRM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperRM);
            }

            return bSuperRM;
        }

        public bool GetSuperPM()
        {
            bool bSuperPM = false;
            if (_userWResID == 1)
            {
                bSuperPM = true;
            }
            else
            {
                if (_dba.Open() != StatusEnum.rsSuccess)
                    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());
                bSuperPM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperPIM);
            }
            if (bSuperPM == false)
            {
                bSuperPM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpPMOAdmin);
            }
            return bSuperPM;
        }

        public int SelectMyDepts(out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            StatusEnum eStatus = StatusEnum.rsSuccess;
            CStruct xDepts = null;
            xDepts = new CStruct();
            xDepts.Initialize("Depts");

            try
            {
                bool bSuperRm = GetSuperRM();

                Dictionary<int, int> dicDepts = new Dictionary<int, int>();
                if (bSuperRm == false)
                {
                    //  this gets us a list of departments I manage or am a delegate for that 
                    oCommand = new SqlCommand("EPG_SP_ReadManagerResDepts", _dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("ApproverWResID", _userWResID);
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int lDeptID = DBAccess.ReadIntValue(reader["DeptUID"]);
                        dicDepts.Add(lDeptID, lDeptID);
                    }
                    reader.Close();

                    //  this gets us a list of departments I manage from the new DEPT_MANAGERS table - we might want to merge these SPs but awkward because of CANREAD and CANWRITE
                    oCommand = new SqlCommand("EPG_SP_ReadManagerResDeptsA", _dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("ApproverWResID", _userWResID);
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int lDeptID = DBAccess.ReadIntValue(reader["DeptUID"]);
                        dicDepts[lDeptID] = lDeptID;  // likely a duplicate from above list so don't want to try create new entry
                    }
                    reader.Close();
                }

                string sCommand = "SELECT LV_UID,LV_VALUE,LV_ID,LV_LEVEL,LV_INACTIVE,RES_NAME" +
                                    " FROM EPGP_LOOKUP_VALUES v" +
                                    " Left Join EPG_RES_MANAGERS m On v.LV_UID=m.CODE_UID" +
                                    " Left Join EPG_RESOURCES r On m.WRES_ID = r.WRES_ID" +
                                    " WHERE LOOKUP_UID = (Select Top 1 ADM_RPE_DEPT_CODE From EPG_ADMIN)" +
                                    " ORDER BY LV_ID";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                reader = oCommand.ExecuteReader();

                int lAccessLevel = 0;
                while (reader.Read())
                {
                    int nDeptID = DBAccess.ReadIntValue(reader["LV_UID"]);
                    int nLevel = DBAccess.ReadIntValue(reader["LV_LEVEL"]);
                    string sDeptName = DBAccess.ReadStringValue(reader["LV_VALUE"]);
                    string sManagerName = DBAccess.ReadStringValue(reader["RES_NAME"]);

                    int lDeptID;
                    bool bHavAccess = false;
                    if (bSuperRm == true) bHavAccess = true;  // have access to all depts
                    else if (dicDepts.TryGetValue(nDeptID, out lDeptID))   // have access to this dept
                    {
                        bHavAccess = true;
                        if ((nLevel < lAccessLevel) || (lAccessLevel == 0)) lAccessLevel = nLevel;  // always remember the highest level we have access to in the outline
                    }
                    else
                    {
                        if (nLevel <= lAccessLevel) lAccessLevel = 0;
                        else if (lAccessLevel != 0) bHavAccess = true;  // have access as child of dept with access
                    }

                    if (bHavAccess == true)
                    {
                        CStruct xDept = xDepts.CreateSubStruct("Dept");
                        xDept.CreateIntAttr("ID", nDeptID);
                        xDept.CreateStringAttr("Name", sDeptName);
                        xDept.CreateStringAttr("MgrName", sManagerName);
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                eStatus = _dba.HandleException("GetMyDepts", (StatusEnum)9999, ex);
                sReply = "";
                return (int)StatusEnum.rsRequestInvalid;
            }

            sReply = xDepts.XML();
            return (int)eStatus;
        }

        public int SelectMyResources(out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            StatusEnum eStatus = StatusEnum.rsSuccess;
            CStruct xResources = new CStruct();
            xResources.Initialize("Resources");

            try
            {
                string sDeptXML;
                SelectMyDepts(out sDeptXML);

                CStruct xSelDepts = new CStruct();
                xSelDepts.LoadXML(sDeptXML);
                List<CStruct> listDepts = xSelDepts.GetList("Dept");

                string sDeptList = "";
                foreach (CStruct xSelDept in listDepts)
                {
                    int lDeptID = xSelDept.GetIntAttr("ID");
                    if (sDeptList.Length < 1) sDeptList = lDeptID.ToString(); else sDeptList += "," + lDeptID.ToString();
                }

                if (sDeptList.Length > 0)
                {
                    //  assumption here that IS_RESOURCE and IS_GENERIC can't both be set at once and only gets Resources

                    //  Aug 2012 - think we treat Generics just like any other resource as they have depts right
                    string sCommand = "SELECT WRES_ID,WRES_EXT_UID,RES_NAME" +
                                        " FROM EPG_RESOURCES" +
                                        " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sDeptList + "') LT on WRES_RP_DEPT=LT.TokenVal" +
                                        " ORDER BY RES_NAME";
                    //" Where WRES_IS_RESOURCE=1" +

                    oCommand = new SqlCommand(sCommand, _dba.Connection);
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        string sExtID = DBAccess.ReadStringValue(reader["WRES_EXT_UID"]);
                        string sResName = DBAccess.ReadStringValue(reader["RES_NAME"]);
                        CStruct xResource = xResources.CreateSubStruct("Resource");
                        xResource.CreateIntAttr("ID", lWResID);
                        xResource.CreateStringAttr("ExtID", sExtID);
                        xResource.CreateStringAttr("Name", sResName);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                eStatus = _dba.HandleException("GetMyResources", (StatusEnum)9999, ex);
                sReply = "";
                return (int)StatusEnum.rsRequestInvalid;
            }

            sReply = xResources.XML();
            return (int)eStatus;
        }

        public int SelectMyProjects(out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            StatusEnum eStatus = StatusEnum.rsSuccess;
            CStruct xProjects = new CStruct();
            xProjects.Initialize("Projects");

            try
            {
                string sCommand = "SELECT PROJECT_ID,PROJECT_NAME FROM EPGP_PROJECTS" +
                                    " WHERE (PROJECT_MANAGER = @WresId1 OR PROJECT_ID IN (select SURR_CONTEXT_VALUE FROM EPG_DELEGATES WHERE SURR_CONTEXT = 4 AND SURR_WRES_ID = @WresId2))" +
                                    " And PROJECT_MARKED_DELETION <> 1 ORDER BY PROJECT_ID";

                oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.Parameters.AddWithValue("@WresId1", _userWResID);
                oCommand.Parameters.AddWithValue("@WresId2", _userWResID);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    int lProjId = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    string sProjName = DBAccess.ReadStringValue(reader["PROJECT_NAME"]);
                    CStruct xProject = xProjects.CreateSubStruct("Project");
                    xProject.CreateIntAttr("ID", lProjId);
                    xProject.CreateStringAttr("Name", sProjName);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                eStatus = _dba.HandleException("GetMyProjects", (StatusEnum)9999, ex);
                sReply = "";
                return (int)StatusEnum.rsRequestInvalid;
            }

            sReply = xProjects.XML();
            return (int)eStatus;
        }

        public int SelectResourcesFromTicket(string sTicket, out string sReply, out string sReplyMessage)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            StatusEnum eStatus = StatusEnum.rsSuccess;
            CStruct xResult = null;
            xResult = new CStruct();

            try
            {
                string sticketData = "";
                string sCommand;


                sCommand = "SELECT DC_DATA FROM EPG_DATA_CACHE WHERE DC_TICKET = '" + sTicket + "'";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                reader = oCommand.ExecuteReader();

                if (reader.Read())
                {
                    sticketData = DBAccess.ReadStringValue(reader["DC_DATA"]);
                }
                reader.Close();

                bool bisValidResourceTicket = true;
                foreach (string sList in sticketData.Split(','))
                {
                    int nWresID;
                    if (sList.Length > 0)
                    { if (int.TryParse(sList, out nWresID) == false) { bisValidResourceTicket = false; break; } }
                }

                if (bisValidResourceTicket)
                {
                    xResult.Initialize("Resources");
                    if (sticketData.Length > 0)
                    {
                        sCommand = "Select WRES_ID,RES_NAME From EPG_RESOURCES" +
                                    " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sticketData + "') LT on WRES_ID=LT.TokenVal";

                        oCommand = new SqlCommand(sCommand, _dba.Connection);
                        reader = oCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                            string sResName = DBAccess.ReadStringValue(reader["RES_NAME"]);

                            CStruct xResource = xResult.CreateSubStruct("Resource");
                            xResource.CreateIntAttr("ID", lWResID);
                            xResource.CreateStringAttr("Name", sResName);
                        }
                        reader.Close();
                    }
                }
                else
                {
                    // maybe it is a ticket full of WEPIDs
                    xResult.Initialize("PIs");
                    if (sticketData.Length > 0)
                    {
                        sCommand = "Select PROJECT_ID,PROJECT_NAME From EPGP_PROJECTS" +
                                    " INNER JOIN dbo.EPG_FN_ConvertWEPIDToTable(N'" + sticketData + "') LT on PROJECT_EXT_UID=LT.TokenVal";

                        oCommand = new SqlCommand(sCommand, _dba.Connection);
                        reader = oCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            int lProjID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                            string sProjName = DBAccess.ReadStringValue(reader["PROJECT_NAME"]);

                            CStruct xPI = xResult.CreateSubStruct("PI");
                            xPI.CreateIntAttr("ID", lProjID);
                            xPI.CreateStringAttr("Name", sProjName);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                eStatus = _dba.HandleException("GetResourcesFromTicket", (StatusEnum)9999, ex);
                sReply = "";
                sReplyMessage = "GetResourcesFromTicket: Invalid Ticket";
                return (int)StatusEnum.rsRequestInvalid;
            }

            sReply = xResult.XML();
            sReplyMessage = "";
            return (int)eStatus;
        }


        public int GetRVInfo(string sParmXML, out string sReplyXML, out string sResult)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            StatusEnum eStatus = StatusEnum.rsSuccess;
            string cmdText;
            bool bIsNull;
            string sErrorInfo = "";
            string sDeptList = "", sPIList = "", sResourceList = "";

            ResourceValues.clsResourceValues RVClass = new ResourceValues.clsResourceValues();

            // extract parameters and get set up to extract the required data
            sErrorInfo = "loading parameters";
            CStruct xParms = new CStruct();
            xParms.LoadXML(sParmXML);
            int nRequestNo = xParms.GetInt("RequestNo");

            RVClass.CalendarID = xParms.GetInt("CalID");
            RVClass.FromPeriodID = xParms.GetInt("StartPeriodID");
            RVClass.ToPeriodID = xParms.GetInt("FinishPeriodID");

            CStruct xDepts = xParms.GetSubStruct("Depts");
            if (xDepts != null)
            {
                List<CStruct> listDepts = xDepts.GetList("Dept");
                foreach (CStruct xSelDept in listDepts)
                {
                    int lDeptID = xSelDept.GetIntAttr("ID");
                    //string sDeptName = xSelDept.GetStringAttr("Name");
                    if (sDeptList.Length < 1) { sDeptList = lDeptID.ToString(); }
                    else { sDeptList += "," + lDeptID.ToString(); }
                }
                xDepts = null;
                listDepts = null;
            }

            CStruct xPIs = xParms.GetSubStruct("PIs");
            if (xPIs != null)
            {
                List<CStruct> listPIs = xPIs.GetList("PI");
                foreach (CStruct xSelPI in listPIs)
                {
                    int lProjID = xSelPI.GetIntAttr("ID");
                    if (sPIList.Length < 1) { sPIList = lProjID.ToString(); }
                    else { sPIList += "," + lProjID.ToString(); }
                }
                xPIs = null;
                listPIs = null;
            }

            List<int> SelectedResources = new List<int>();
            CStruct xResources = xParms.GetSubStruct("Resources");
            if (xResources != null)
            {
                List<CStruct> listResources = xResources.GetList("Resource");
                foreach (CStruct xSelResource in listResources)
                {
                    int lWresID = xSelResource.GetIntAttr("ID");
                    if (sResourceList.Length < 1) { sResourceList = lWresID.ToString(); }
                    else { sResourceList += "," + lWresID.ToString(); }
                    SelectedResources.Add(lWresID);  // may need this list later as list of resources which must appear in RPA
                }
                xResources = null;
                listResources = null;
            }


            ResCenterRequest lRequestNo = (ResCenterRequest)nRequestNo;

            RVClass.lRequestNo = nRequestNo;

            // set up lists of Depts, PIs, Resources we will use to select the data we want
            bool bOKtoContinue = false;

            int lSPRequestNo = (int)lRequestNo;


            if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts)
            // Resource Plans for one or more depts
            {
                sPIList = "NONE";
                sResourceList = "NONE";
                if (sDeptList.Length > 0) { bOKtoContinue = true; }
            }
            else if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIsinDept)
            // Resource Plans for one or more PIs but for one or more depts (called from Capacity Center)
            {
                sResourceList = "NONE";
                if ((sDeptList.Length > 0) && (sPIList.Length > 0)) { bOKtoContinue = true; }
            }
            else if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIinDept)
            // Resource Plan refresh for one PI after calling Planning dialog - DOUBT IF THIS WILL EXIST IN NON-ACTIVEX
            //  note that Plan Editor only available when Resource Plans Display called for one or more depts
            //  allowing it to be called for resources or PIs would require extra work to refresh the correct info after
            {
                sResourceList = "NONE";
                if (sDeptList.Length > 0) { bOKtoContinue = true; }
                lSPRequestNo = (int)ResourceValues.ResCenterRequest.ResourceValuesForPIsinDept;
            }
            else if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIs)
            // Resoruce Plans for one or more PIs - all depts - called from Portfolio View
            {
                sDeptList = "NONE";
                sResourceList = "NONE";
                if (sPIList.Length > 0) { bOKtoContinue = true; }
            }
            else if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForResources)
            // Resource Plans for a list of resources - all PIs - dept not used
            {
                sDeptList = "NONE";
                sPIList = "NONE";
                if (sResourceList.Length > 0) { bOKtoContinue = true; }
            }
            else if (lRequestNo == ResourceValues.ResCenterRequest.CapacityValues)
            {
                sDeptList = "NONE";
                sPIList = "NONE";
                sResourceList = "NONE";
                bOKtoContinue = true;
            }

            if (bOKtoContinue == false)
            {
                eStatus = StatusEnum.rsRequestIncomplete;
                sErrorInfo = "No data to display";
                goto Error_Return;
            }

            try
            {
                //Get Admin Info
                sErrorInfo = "a001";

                int lDefaultVersion = -1, lAssnsNeedRMApproval = 0;
                cmdText = "SELECT ADM_ROLE_CODE,ADM_MC_LOOKUP,ADM_PORT_COMMITMENTS_CB_ID,ADM_PORT_COMMITMENTS_OPMODE,ADM_ASSNS_NEED_RM_APPROVAL,ADM_DEFAULT_PROJ_VERSION_ID FROM EPG_ADMIN";
                oCommand = new SqlCommand(cmdText, _dba.Connection);
                reader = oCommand.ExecuteReader();
                if (reader.Read())
                {
                    RVClass.RoleFieldID = DBAccess.ReadIntValue(reader["ADM_ROLE_CODE"], out bIsNull);
                    RVClass.MajorCategoryFieldID = DBAccess.ReadIntValue(reader["ADM_MC_LOOKUP"], out bIsNull);
                    RVClass.PlanningCalendarID = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_CB_ID"], out bIsNull);
                    RVClass.CommitmentsOpMode = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_OPMODE"], out bIsNull);
                    lAssnsNeedRMApproval = DBAccess.ReadIntValue(reader["ADM_ASSNS_NEED_RM_APPROVAL"], out bIsNull);
                    lDefaultVersion = DBAccess.ReadIntValue(reader["ADM_DEFAULT_PROJ_VERSION_ID"], out bIsNull);
                }
                reader.Close();

                sErrorInfo = "b001";
                if (RVClass.CalendarID == -1)
                {
                    cmdText = "SELECT MAX(CB_ID) AS MXCBID, MAX(PRD_ID) AS MXPID, MIN(PRD_ID) AS MNPID From EPG_PERIODS WHERE CB_ID = (SELECT ADM_PORT_COMMITMENTS_CB_ID FROM EPG_ADMIN)";
                    oCommand = new SqlCommand(cmdText, _dba.Connection);
                    reader = oCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        RVClass.CalendarID = DBAccess.ReadIntValue(reader["MXCBID"], out bIsNull);
                        RVClass.FromPeriodID = DBAccess.ReadIntValue(reader["MNPID"], out bIsNull);
                        RVClass.ToPeriodID = DBAccess.ReadIntValue(reader["MXPID"], out bIsNull);
                    }
                    reader.Close();
                }

                // Calendar and Periods
                sErrorInfo = "c001";
                cmdText = "SELECT CB_NAME FROM EPGP_COST_BREAKDOWNS WHERE CB_ID = " + RVClass.CalendarID.ToString();
                oCommand = new SqlCommand(cmdText, _dba.Connection);
                reader = oCommand.ExecuteReader();
                if (reader.Read())
                {
                    RVClass.CalendarName = DBAccess.ReadStringValue(reader["CB_NAME"], out bIsNull);
                }
                else
                {
                    RVClass.CalendarName = "Timesheet Periods";
                }
                reader.Close();

                sErrorInfo = "c010";

                ResourceValues.CPeriod oPeriod;
                DateTime FirstStartDate = new DateTime(1960, 01, 01);
                DateTime LastFinishDate = new DateTime(2060, 01, 01);
                bool bfirstperiod = true;
                RVClass.Periods = new Dictionary<int, ResourceValues.CPeriod>();

                oCommand = new SqlCommand("EPG_SP_ReadPeriod", _dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("CalID", RVClass.CalendarID);
                oCommand.Parameters.AddWithValue("FromPeriodID", RVClass.FromPeriodID);
                oCommand.Parameters.AddWithValue("ToPeriodID", RVClass.ToPeriodID);

                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oPeriod = new ResourceValues.CPeriod();
                    oPeriod.PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                    oPeriod.PeriodName = reader["PRD_NAME"].ToString();
                    oPeriod.StartDate = DBAccess.ReadDateValue(reader["PRD_START_DATE"]);
                    oPeriod.FinishDate = DBAccess.ReadDateValue(reader["PRD_FINISH_DATE"]);
                    if (bfirstperiod)
                    {
                        bfirstperiod = false;
                        FirstStartDate = oPeriod.StartDate;
                        LastFinishDate = oPeriod.FinishDate;
                    }
                    else
                    {
                        if (FirstStartDate > oPeriod.StartDate) { FirstStartDate = oPeriod.StartDate; }
                        if (LastFinishDate < oPeriod.FinishDate) { LastFinishDate = oPeriod.FinishDate; }
                    }
                    RVClass.Periods.Add(oPeriod.PeriodID, oPeriod);
                }
                reader.Close();

                sErrorInfo = "c020";
                if (RVClass.PlanningCalendarID < 0)
                {
                    eStatus = StatusEnum.rsRequestIncomplete;
                    sErrorInfo = "Resource Planning Calendar not specified";
                    goto Error_Return;
                }

                int lFirstPeriod = 0, lLastPeriod = 0;
                Dictionary<int, int> dicDisplayPeriods = new Dictionary<int, int>();
                if (RVClass.PlanningCalendarID != RVClass.CalendarID)
                {
                    // Display calendar is different from Commitments calendar
                    //  read periods from Planning Calendar within the specified date range
                    //  calc Period on Display Calendar for each - used to transform to display periods as commmitments and avail are read

                    oCommand = new SqlCommand("EPG_SP_ReadPeriodByDate", _dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("CalID", RVClass.PlanningCalendarID);
                    oCommand.Parameters.AddWithValue("FromDate", FirstStartDate);
                    oCommand.Parameters.AddWithValue("ToDate", LastFinishDate);
                    reader = oCommand.ExecuteReader();

                    int lDisplayPeriod = RVClass.FromPeriodID;
                    bool bFirstPeriod = true;
                    bool bHavePeriod = false;
                    int lRPPeriodID;
                    DateTime StartDate;
                    oPeriod = null;
                    while (reader.Read())
                    {
                        lRPPeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        StartDate = DBAccess.ReadDateValue(reader["PRD_START_DATE"]);

                        if (bFirstPeriod)
                        {
                            bFirstPeriod = false;
                            lFirstPeriod = lRPPeriodID;
                            lLastPeriod = lRPPeriodID;
                            bHavePeriod = RVClass.Periods.TryGetValue(lDisplayPeriod, out oPeriod);
                        }
                        else
                            lLastPeriod = lRPPeriodID;

                        // compare the Planning Period with each Display Period in turn as necessary
                        while (StartDate > oPeriod.FinishDate && bHavePeriod)
                        {
                            lDisplayPeriod++;
                            bHavePeriod = RVClass.Periods.TryGetValue(lDisplayPeriod, out oPeriod);
                        }
                        if (bHavePeriod) dicDisplayPeriods[lRPPeriodID] = oPeriod.PeriodID;
                    }
                    reader.Close();
                }
                else
                {
                    lFirstPeriod = RVClass.FromPeriodID;
                    lLastPeriod = RVClass.ToPeriodID;
                }

                //  set PMO permission
                bool bPMOAdmin = false;
                if (_userWResID == 1)
                {
                    bPMOAdmin = true;
                }
                else
                {
                    bPMOAdmin = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpPMOAdmin);
                }
                if (bPMOAdmin) RVClass.gpPMOAdmin = 1; else RVClass.gpPMOAdmin = 0;

                // get the Cost Category structure
                sErrorInfo = "d010";
                int lCatMaxLevel = 0;
                ResourceValues.clsCatItem oCatItem;
                RVClass.CostCategories = new Dictionary<int, ResourceValues.clsCatItem>();

                string sCommand = "SELECT  BC_UID, BC_NAME, BC_ID, BC_LEVEL, BC_ROLE, BC_UOM, MC_UID, CA_UID, EPGP_LOOKUP_VALUES.LV_VALUE FROM EPGP_COST_CATEGORIES LEFT OUTER JOIN  EPGP_LOOKUP_VALUES ON " +
                    " EPGP_COST_CATEGORIES.BC_ROLE = EPGP_LOOKUP_VALUES.LV_UID ORDER BY BC_ID";



                oCommand = new SqlCommand(sCommand, _dba.Connection);
                //         reader = oCommand.ExecuteReader();


                //         oCommand = new SqlCommand("EPG_SP_ReadCategoryItems", _dba.Connection);
                //         oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oCatItem = new ResourceValues.clsCatItem();
                    oCatItem.UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    oCatItem.Role_UID = DBAccess.ReadIntValue(reader["BC_ROLE"]);
                    oCatItem.MajorCategory = DBAccess.ReadIntValue(reader["MC_UID"]);
                    oCatItem.Category = DBAccess.ReadIntValue(reader["CA_UID"]);
                    oCatItem.ID = DBAccess.ReadIntValue(reader["BC_ID"]);
                    oCatItem.Level = DBAccess.ReadIntValue(reader["BC_LEVEL"]);
                    oCatItem.Name = reader["BC_NAME"].ToString();

                    oCatItem.RoleName = DBAccess.ReadStringValue(reader["LV_VALUE"]);

                    if (oCatItem.Level > lCatMaxLevel) { lCatMaxLevel = oCatItem.Level; }
                    RVClass.CostCategories.Add(oCatItem.UID, oCatItem);
                }
                reader.Close();
                if (RVClass.CostCategories.Count > 0) { SetParentUIDs(RVClass.CostCategories, lCatMaxLevel); }
                else
                {
                    eStatus = StatusEnum.rsRequestIncomplete;
                    sErrorInfo = "Cost Categories not specified";
                    goto Error_Return;
                }

                // get CATEGORY/PERIOD ATTRIBS (FTE Conversion Factors) - clnFTEs is a collection of collections, each for a BCUID
                sErrorInfo = "e001";
                int lPeriodID, lFTEConv, lBCUID, lPrevBCUID = 0;
                Dictionary<int, int> clnFTEPeriods = null;
                Dictionary<int, Dictionary<int, int>> clnFTEs = new Dictionary<int, Dictionary<int, int>>();

                oCommand = new SqlCommand("EPG_SP_ReadCBAttribsForPeriods", _dba.Connection);
                oCommand.Parameters.AddWithValue("CBID", RVClass.CalendarID);
                oCommand.Parameters.AddWithValue("FromPeriodID", RVClass.FromPeriodID);
                oCommand.Parameters.AddWithValue("ToPeriodID", RVClass.ToPeriodID);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    lBCUID = DBAccess.ReadIntValue(reader["BA_BC_UID"]);
                    lPeriodID = DBAccess.ReadIntValue(reader["BA_PRD_ID"]);
                    lFTEConv = DBAccess.ReadIntValue(reader["BA_FTE_CONV"]);

                    if (lBCUID != lPrevBCUID)
                    {
                        if (lPrevBCUID > 0)
                        {
                            if (clnFTEPeriods != null && clnFTEPeriods.Count > 0)
                            {
                                clnFTEs.Add(lPrevBCUID, clnFTEPeriods);
                            }
                        }
                        clnFTEPeriods = new Dictionary<int, int>();
                    }
                    lPrevBCUID = lBCUID;
                    clnFTEPeriods.Add(lPeriodID, lFTEConv);
                }
                reader.Close();
                if (clnFTEPeriods != null && clnFTEPeriods.Count > 0)
                {
                    clnFTEs.Add(lPrevBCUID, clnFTEPeriods);
                }

                // jwg - 5/4/12 need to save the cost cat by display period FTE conv factor in resource values for drag row
                RVClass.FTEConvData = new List<clsFTEConv>();
                foreach (clsCatItem oCtm in RVClass.CostCategories.Values)
                {
                    for (int fci = lFirstPeriod; fci <= lLastPeriod; fci++)
                    {
                        int xper = fci - lFirstPeriod + 1;
                        int fteconv = GetFTEConv(clnFTEs, oCtm.UID, fci);

                        if (fteconv != 0)
                        {
                            clsFTEConv ofte = new clsFTEConv();
                            ofte.Cat_UID = oCtm.UID;
                            ofte.PeriodID = xper;
                            ofte.FTEConv = fteconv;
                            RVClass.FTEConvData.Add(ofte);
                        }
                    }
                }


                //  Have a look at the Resource Plan Custom Fields, add info to class
                sErrorInfo = "e020";
                string sGivenName;
                int lField;
                bool[] baFieldDefined = new bool[11];
                ResourceValues.clsPortField oFieldItem;
                RVClass.PlanFields = new List<ResourceValues.clsPortField>();

                oCommand = new SqlCommand("EPG_SP_ReadRPCustomFields", _dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    sGivenName = reader["FA_NAME"].ToString();
                    if (sGivenName.Length > 0)
                    {
                        oFieldItem = new ResourceValues.clsPortField();
                        oFieldItem.GivenName = sGivenName;
                        oFieldItem.Name = reader["FIELD_NAME"].ToString();
                        lField = DBAccess.ReadIntValue(reader["FIELD_ID"]);
                        oFieldItem.ID = lField;
                        lField = lField - 9299;  // gives 1 - 5 = text,  6 - 10 = code
                        if (lField < 11) { baFieldDefined[lField] = true; }
                        if (lField <= 5) { oFieldItem.Fieldtype = 9; }
                        else { oFieldItem.Fieldtype = 4; }

                        RVClass.PlanFields.Add(oFieldItem);
                    }
                }
                reader.Close();

                //  Have a look at the Resource and PI extra Fields, add info to classes
                sErrorInfo = "e030";
                RVClass.PIFields = new List<ResourceValues.clsPortField>();
                RVClass.ResFields = new List<ResourceValues.clsPortField>();

                // here we were reading selected CFs for PIs and Resources - now reading all Code and Text fields... why ONLY CODE and TEXT? leave at that for now
                //oCommand = new SqlCommand("EPG_SP_ReadRDCustomFields", _dba.Connection);
                //oCommand.Parameters.AddWithValue("UserID", 0);  // this parm not used in SP but leave it there to avoid disruption
                //oCommand.CommandType = System.Data.CommandType.StoredProcedure;

                cmdText = "Select FA_FIELD_ID as FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,FA_LOOKUP_UID" +
                            " From EPGC_FIELD_ATTRIBS" +
                            " Where (FA_FORMAT = 4 or FA_FORMAT = 9) and (FA_TABLE_ID > 100 and FA_TABLE_ID < 210)" +
                            " ORDER BY FA_TABLE_ID,FIELD_ID";
                oCommand = new SqlCommand(cmdText, _dba.Connection);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oFieldItem = new ResourceValues.clsPortField();
                    oFieldItem.ID = DBAccess.ReadIntValue(reader["FIELD_ID"]);
                    oFieldItem.CFTable = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                    oFieldItem.CFField = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                    oFieldItem.GivenName = reader["FA_NAME"].ToString();
                    oFieldItem.Fieldtype = DBAccess.ReadIntValue(reader["FA_FORMAT"]);
                    oFieldItem.LookupID = DBAccess.ReadIntValue(reader["FA_LOOKUP_UID"]);

                    if (oFieldItem.CFTable >= 200)
                    { RVClass.PIFields.Add(oFieldItem); }
                    else
                    { RVClass.ResFields.Add(oFieldItem); }
                }
                reader.Close();

                //  Add the Resource Plan Lookup lists for the RP Codes that are used
                sErrorInfo = "e040";
                RVClass.Lookups = new Dictionary<int, ResourceValues.clsLookupList>();

                if (baFieldDefined[6] == true) if (AddCustomFieldLookup(_dba, RVClass.Lookups, 9305, 0) != StatusEnum.rsSuccess) goto Error_Return;
                if (baFieldDefined[7] == true) if (AddCustomFieldLookup(_dba, RVClass.Lookups, 9306, 0) != StatusEnum.rsSuccess) goto Error_Return;
                if (baFieldDefined[8] == true) if (AddCustomFieldLookup(_dba, RVClass.Lookups, 9307, 0) != StatusEnum.rsSuccess) goto Error_Return;
                if (baFieldDefined[9] == true) if (AddCustomFieldLookup(_dba, RVClass.Lookups, 9308, 0) != StatusEnum.rsSuccess) goto Error_Return;
                if (baFieldDefined[10] == true) if (AddCustomFieldLookup(_dba, RVClass.Lookups, 9309, 0) != StatusEnum.rsSuccess) goto Error_Return;

                // Add Lookups for any PI extra fields
                sErrorInfo = "e041";
                foreach (ResourceValues.clsPortField oPIFieldItem in RVClass.PIFields)
                {
                    if (oPIFieldItem.LookupID > 0) if (AddCustomFieldLookup(_dba, RVClass.Lookups, oPIFieldItem.ID, oPIFieldItem.LookupID) != StatusEnum.rsSuccess) goto Error_Return;
                }

                // Add Lookups for any Resource extra fields
                sErrorInfo = "e042";
                foreach (ResourceValues.clsPortField oResFieldItem in RVClass.ResFields)
                {
                    if (oResFieldItem.LookupID > 0) if (AddCustomFieldLookup(_dba, RVClass.Lookups, oResFieldItem.ID, oResFieldItem.LookupID) != StatusEnum.rsSuccess) goto Error_Return;
                }

                // Add Lookups for Major Categories if there is one
                sErrorInfo = "e043";
                if (AddCustomFieldLookup(_dba, RVClass.Lookups, 0, RVClass.MajorCategoryFieldID) != StatusEnum.rsSuccess) goto Error_Return;

                //  ............................time to get the real data ... eventually ...................................................

                // Get the Plan Lines we are interested in
                sErrorInfo = "f010";
                RVClass.Commitments = new Dictionary<int, ResourceValues.clsCommitment>();
                RVClass.OpenReqs = new Dictionary<int, ResourceValues.clsCommitment>();
                string sPlanRowListC = "", sPlanRowListP = "", sPlanRowListR = "";
                ResourceValues.clsCommitment oCommitment;

                cmdText = "Select cm.CMT_UID,cm.RP_GROUP,cm.PROJECT_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_START_DATE,cm.CMT_FINISH_DATE," +
                        " cm.CMT_TOTAL_COST,cm.BC_UID,cm.PARENT_BC_UID,cm.WRES_ID,cm.WRES_ID_PENDING,cm.CMT_STATUS as Status,cm.RP_ACTIVE_COMMITMENT as Commitment," +
                        " CMT_MAJORCATEGORY,CAT_CODE_1,CAT_CODE_2,CAT_CODE_3,CAT_CODE_4,CAT_CODE_5,CAT_TEXT_1,CAT_TEXT_2,CAT_TEXT_3,CAT_TEXT_4,CAT_TEXT_5" +
                        " From EPG_RESOURCEPLANS cm" +
                        " Inner Join EPGP_PROJECTS ex On ex.PROJECT_ID=cm.PROJECT_ID and ex.PROJECT_MARKED_DELETION = 0" +
                        " Left Join EPGP_RP_CATEGORY_VALUES cv On cv.CAT_CMT_UID = cm.CMT_UID";
                // joins based on mode of request
                if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts)
                {
                    cmdText += " Join EPG_FN_ConvertListToTable(N'" + sDeptList + "') LT1 on cm.CMT_DEPT=LT1.TokenVal";
                }
                else if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIsinDept)
                {
                    cmdText += " Join EPG_FN_ConvertListToTable(N'" + sDeptList + "') LT1 on cm.CMT_DEPT=LT1.TokenVal" +
                            " Join EPG_FN_ConvertListToTable(N'" + sPIList + "') LT2 on cm.PROJECT_ID=LT2.TokenVal";
                }
                else if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIs)
                {
                    cmdText += " Join EPG_FN_ConvertListToTable(N'" + sPIList + "') LT1 on cm.PROJECT_ID=LT1.TokenVal";
                }
                else if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForResources)
                {
                    //cmdText += " Join EPG_FN_ConvertListToTable(N'" + sResourceList + "') LT1 on cm.WRES_ID=LT1.TokenVal";
                    cmdText += " Join EPG_FN_ConvertListToTable(N'" + sResourceList +
                               "') LT1 on (cm.RP_ACTIVE_COMMITMENT=1 and cm.WRES_ID=LT1.TokenVal) or (cm.RP_ACTIVE_COMMITMENT=0 and cm.WRES_ID_PENDING=LT1.TokenVal)";
                }
                cmdText += " Where (cm.CMT_STATUS=256 Or cm.CMT_STATUS=1) And (CMT_PRIVATE is NULL Or CMT_PRIVATE <> 1)";
                cmdText += " Order By cm.Project_ID,cm.CMT_DEPT,cm.CMT_ROLE,cm.CMT_UID";

                oCommand = new SqlCommand(cmdText, _dba.Connection);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oCommitment = new ResourceValues.clsCommitment();
                    oCommitment.ID = DBAccess.ReadIntValue(reader["CMT_UID"]);
                    oCommitment.UID = oCommitment.ID;
                    oCommitment.Group = reader["RP_GROUP"].ToString();
                    oCommitment.ProjectID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    int nWresid = DBAccess.ReadIntValue(reader["WRES_ID"]);
                    int nPendingWresid = DBAccess.ReadIntValue(reader["WRES_ID_PENDING"]);
                    oCommitment.RoleUID = DBAccess.ReadIntValue(reader["CMT_ROLE"]);
                    oCommitment.BC_UID_Role = DBAccess.ReadIntValue(reader["BC_UID"]);
                    oCommitment.BC_UID_CC = DBAccess.ReadIntValue(reader["PARENT_BC_UID"]);
                    oCommitment.MajorCategory = reader["CMT_MAJORCATEGORY"].ToString();
                    oCommitment.DeptUID = DBAccess.ReadIntValue(reader["CMT_DEPT"]);
                    oCommitment.Status = DBAccess.ReadIntValue(reader["Status"]);
                    oCommitment.StartDate = DBAccess.ReadDateValue(reader["CMT_START_DATE"]);
                    oCommitment.FinishDate = DBAccess.ReadDateValue(reader["CMT_FINISH_DATE"]);
                    //oCommitment.Rate = DBAccess.ReadDoubleValue(reader["CMT_RATE"]);
                    //oCommitment.RateType = reader["RT_NAME"].ToString();
                    oCommitment.cost = DBAccess.ReadDoubleValue(reader["CMT_TOTAL_COST"]);
                    oCommitment.HoursInWindow = 0;
                    //if (RVClass.CommitmentsOpMode == 1 && RVClass.PlanningCalendarID == RVClass.CalendarID) oCommitment.Dragable = 1;  // non-negotiation mode only
                    if (RVClass.PlanningCalendarID == RVClass.CalendarID) oCommitment.Dragable = 1;  // always dragable now by me but John looks at Neg/Non-Neg - may be changed later

                    // Create lists of Plan Row UIDs - they are unique
                    int l_Commitment = DBAccess.ReadIntValue(reader["Commitment"]);

                    if (oCommitment.Status == 1)
                    {
                        // Requirement (remaining summary (fulfillment) row now)
                        oCommitment.WResID = nWresid;
                        if (sPlanRowListR.Length < 1) { sPlanRowListR = oCommitment.UID.ToString(); } else { sPlanRowListR += "," + oCommitment.UID.ToString(); }
                    }
                    else
                    {
                        if (l_Commitment == 1)
                        {
                            // commitment
                            oCommitment.WResID = nWresid;
                            if (sPlanRowListC.Length < 1) { sPlanRowListC = oCommitment.UID.ToString(); } else { sPlanRowListC += "," + oCommitment.UID.ToString(); }
                        }
                        else
                        {
                            // proposal
                            oCommitment.Status = 4;   //  set to old REQUEST ID
                            oCommitment.WResID = nPendingWresid;
                            if (sPlanRowListP.Length < 1) { sPlanRowListP = oCommitment.UID.ToString(); } else { sPlanRowListP += "," + oCommitment.UID.ToString(); }
                        }
                    }

                    //  Add Custom Field Values
                    oCommitment.CustomFields = new List<string>();

                    if (baFieldDefined[1] == true) { AddCustomField(oCommitment.CustomFields, 9300, 9, reader, "CAT_TEXT_1"); }
                    if (baFieldDefined[2] == true) { AddCustomField(oCommitment.CustomFields, 9301, 9, reader, "CAT_TEXT_2"); }
                    if (baFieldDefined[3] == true) { AddCustomField(oCommitment.CustomFields, 9302, 9, reader, "CAT_TEXT_3"); }
                    if (baFieldDefined[4] == true) { AddCustomField(oCommitment.CustomFields, 9303, 9, reader, "CAT_TEXT_4"); }
                    if (baFieldDefined[5] == true) { AddCustomField(oCommitment.CustomFields, 9304, 9, reader, "CAT_TEXT_5"); }

                    if (baFieldDefined[6] == true) { AddCustomField(oCommitment.CustomFields, 9305, 4, reader, "CAT_CODE_1"); }
                    if (baFieldDefined[7] == true) { AddCustomField(oCommitment.CustomFields, 9306, 4, reader, "CAT_CODE_2"); }
                    if (baFieldDefined[8] == true) { AddCustomField(oCommitment.CustomFields, 9307, 4, reader, "CAT_CODE_3"); }
                    if (baFieldDefined[9] == true) { AddCustomField(oCommitment.CustomFields, 9308, 4, reader, "CAT_CODE_4"); }
                    if (baFieldDefined[10] == true) { AddCustomField(oCommitment.CustomFields, 9309, 4, reader, "CAT_CODE_5"); }

                    if (oCommitment.Status == 1)
                    {
                        RVClass.OpenReqs.Add(oCommitment.UID, oCommitment);
                    }
                    else
                    {
                        RVClass.Commitments.Add(oCommitment.UID, oCommitment);
                    }
                }
                reader.Close();

                // we will be using 6 separate lists below to keep track of what we hit for Resources, PIs, Roles, Depts, UIDs, and also a sep superset of resources
                //  define them all here for clarity (done differently in VB)
                //  not doing this above because we are waiting to see which lines have any values in the window we are dealing with
                List<int> RVLists_Resources = new List<int>();
                List<int> RVLists_PIs = new List<int>();
                List<int> RVLists_Roles = new List<int>();
                List<int> RVLists_Depts = new List<int>();
                List<int> RVLists_UIDs = new List<int>();
                List<int> RVLists_ResourcesWOinDept = new List<int>();

                // read the Commitment hours and then the Proposal hours - execute the same code twice
                sErrorInfo = "f020";
                RVClass.CommitmentHours = new List<ResourceValues.clsCommitmentHours>();
                ResourceValues.clsCommitmentHours oCommitmentHours;

                string status = "Commitments";
                bool bContinue;
                while (status != "ALL DONE")
                {
                    bContinue = false;


                    if (status == "Commitments")
                    {
                        if (sPlanRowListC.Length > 0)
                        {
                            cmdText = "Select CMT_UID,PRD_ID,CMH_HOURS,CMH_FTES From EPG_RESOURCEPLANS_HOURS" +
                                        " Join dbo.EPG_FN_ConvertListToTable(N'" + sPlanRowListC + "') LT2 on CMT_UID=LT2.TokenVal" +
                                        " Where (CMH_PENDING = 0 or CMH_PENDING is NULL) And (PRD_ID >= @FirstPeriod And PRD_ID <= @LastPeriod) and CMH_HOURS > 0" +
                                        " Order By CMT_UID,PRD_ID";
                            bContinue = true;
                        }
                        status = "Proposals"; // for next time around
                    }
                    else if (status == "Proposals")
                    {
                        if (sPlanRowListP.Length > 0)
                        {
                            cmdText = "Select CMT_UID,PRD_ID,CMH_HOURS,CMH_FTES From EPG_RESOURCEPLANS_HOURS" +
                                        " Join dbo.EPG_FN_ConvertListToTable(N'" + sPlanRowListP + "') LT2 on CMT_UID=LT2.TokenVal" +
                                        " Where (CMH_PENDING = 1) And (PRD_ID >= @FirstPeriod And PRD_ID <= @LastPeriod) and CMH_HOURS > 0" +
                                        " Order By CMT_UID,PRD_ID";
                            bContinue = true;
                        }
                        status = "ALL DONE";  // for next time around
                    }
                    else
                    {
                        break;
                    }

                    if (bContinue == true)
                    {
                        oCommand = new SqlCommand(cmdText, _dba.Connection);
                        oCommand.Parameters.AddWithValue("@FirstPeriod", lFirstPeriod);
                        oCommand.Parameters.AddWithValue("@LastPeriod", lLastPeriod);
                        reader = oCommand.ExecuteReader();

                        oCommitmentHours = new ResourceValues.clsCommitmentHours();

                        int l_UID, l_PeriodID;
                        int l_PrevUID = 0;
                        int l_PrevPRD = 0;
                        double dPeriodHours = 0;
                        int l_PeriodFTEs = 0;
                        double dHours = 0;

                        while (reader.Read())         // this recordset is ordered by CMT_UID and PRD
                        {
                            l_UID = DBAccess.ReadIntValue(reader["CMT_UID"]);
                            l_PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);

                            if (RVClass.PlanningCalendarID != RVClass.CalendarID)
                            {
                                int lDisplayPeriod;
                                if (dicDisplayPeriods.TryGetValue(l_PeriodID, out lDisplayPeriod)) l_PeriodID = lDisplayPeriod; else l_PeriodID = 0;
                            }
                            dPeriodHours = DBAccess.ReadDoubleValue(reader["CMH_HOURS"]) / 100;

                            //  Need to calc FTE value when Plan Cal different from display Calendar
                            //  right now the FTE Factor comes from the CCR on the Plan Row - possible we want the resource one
                            //     but we don't have the resource info yet so looks like answer would be to run through the commitmenthours after the resource info is read below and calc the FTE values then
                            //   OR - it might be easier as prob faster too to go get the xref info needed for these specifc resources (or all) - this similar to GetFORCDetails below
                            //   AND - now we've added Scheduled Work in here for call from Portfolio View we have the code below, so just need to move it up above here                     

                            l_PeriodFTEs = 0;
                            if (RVClass.PlanningCalendarID == RVClass.CalendarID)
                            {
                                l_PeriodFTEs = DBAccess.ReadIntValue(reader["CMH_FTES"]);
                            }
                            else
                            {
                                if (RVClass.Commitments.TryGetValue(l_UID, out oCommitment))
                                {
                                    if (oCommitment != null)
                                    {
                                        l_PeriodFTEs = GetFTEValue(clnFTEs, oCommitment.BC_UID_Role, dPeriodHours, l_PeriodID, 0);
                                    }
                                }
                            }

                            // if we are on the same plan line and for the same period then increment the existing HOURS entry - can happen when Calendar != RP Calendar
                            if (l_PrevUID == 0 || l_PrevUID != l_UID || l_PrevPRD != l_PeriodID)
                            {
                                if (oCommitmentHours.Hours > 0) RVClass.CommitmentHours.Add(oCommitmentHours);
                                oCommitmentHours = new ResourceValues.clsCommitmentHours();
                                oCommitmentHours.UID = l_UID;
                                oCommitmentHours.PeriodID = l_PeriodID;
                            }
                            oCommitmentHours.Hours += dPeriodHours;
                            oCommitmentHours.FTES += l_PeriodFTEs;
                            l_PrevPRD = l_PeriodID;

                            // a total for the UID - across all periods
                            if (l_PrevUID > 0 && l_PrevUID != l_UID)
                            {
                                ResourceValues.clsCommitment oCommitment1 = new ResourceValues.clsCommitment();
                                if (RVClass.Commitments.TryGetValue(l_PrevUID, out oCommitment1)) { oCommitment1.HoursInWindow = dHours; }
                                dHours = 0;
                            }
                            l_PrevUID = l_UID;
                            dHours += dPeriodHours;
                        }
                        if (l_PrevUID > 0 && oCommitmentHours.Hours > 0) RVClass.CommitmentHours.Add(oCommitmentHours);
                        if (l_PrevUID > 0 && dHours > 0)
                        {
                            ResourceValues.clsCommitment oCommitment1 = new ResourceValues.clsCommitment();
                            if (RVClass.Commitments.TryGetValue(l_PrevUID, out oCommitment1)) { oCommitment1.HoursInWindow = dHours; }
                        }
                        reader.Close();
                    }
                }

                sErrorInfo = "f030";
                //  get rid of any plan rows with no hours
                RemovePlanRowsWOHours(RVClass.Commitments);

                // make lists of objects we've hit AFTER removing items w/o hours
                foreach (KeyValuePair<int, ResourceValues.clsCommitment> oCommitmentKeyValue in RVClass.Commitments)
                {
                    if ((oCommitmentKeyValue.Value.WResID > 0) && !RVLists_Resources.Contains(oCommitmentKeyValue.Value.WResID)) { RVLists_Resources.Add(oCommitmentKeyValue.Value.WResID); }
                    if ((oCommitmentKeyValue.Value.ProjectID > 0) && !RVLists_PIs.Contains(oCommitmentKeyValue.Value.ProjectID)) { RVLists_PIs.Add(oCommitmentKeyValue.Value.ProjectID); }
                    if ((oCommitmentKeyValue.Value.RoleUID > 0) && !RVLists_Roles.Contains(oCommitmentKeyValue.Value.RoleUID)) { RVLists_Roles.Add(oCommitmentKeyValue.Value.RoleUID); }
                    if ((oCommitmentKeyValue.Value.DeptUID > 0) && !RVLists_Depts.Contains(oCommitmentKeyValue.Value.DeptUID)) { RVLists_Depts.Add(oCommitmentKeyValue.Value.DeptUID); }
                }


                // *********************************  Get Open Requirement hours
                {
                    sErrorInfo = "g001";
                    RVClass.OpenReqHours = new List<ResourceValues.clsCommitmentHours>();

                    cmdText = "Select CMT_UID,PRD_ID,CMH_HOURS,CMH_FTES From EPG_RESOURCEPLANS_HOURS" +
                                " Join dbo.EPG_FN_ConvertListToTable(N'" + sPlanRowListR + "') LT2 on CMT_UID=LT2.TokenVal" +
                                " Where (PRD_ID >= @FirstPeriod And PRD_ID <= @LastPeriod) and CMH_HOURS > 0" +
                                " Order By CMT_UID,PRD_ID";

                    oCommand = new SqlCommand(cmdText, _dba.Connection);
                    oCommand.Parameters.AddWithValue("@FirstPeriod", lFirstPeriod);
                    oCommand.Parameters.AddWithValue("@LastPeriod", lLastPeriod);
                    reader = oCommand.ExecuteReader();

                    oCommitmentHours = new ResourceValues.clsCommitmentHours();

                    int l_UID, l_PeriodID;
                    int l_PrevUID = 0;
                    int l_PrevPRD = 0;
                    double dPeriodHours = 0;
                    int l_PeriodFTEs = 0;
                    double dHours = 0;

                    while (reader.Read())         // this recordset is ordered by CMT_UID and PRD
                    {
                        l_UID = DBAccess.ReadIntValue(reader["CMT_UID"]);
                        l_PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);

                        if (RVClass.PlanningCalendarID != RVClass.CalendarID)
                        {
                            int lDisplayPeriod;
                            if (dicDisplayPeriods.TryGetValue(l_PeriodID, out lDisplayPeriod)) l_PeriodID = lDisplayPeriod; else l_PeriodID = 0;
                        }
                        dPeriodHours = DBAccess.ReadDoubleValue(reader["CMH_HOURS"]) / 100;
                        //  Need to calc FTE value when Plan Cal different from display Calendar

                        l_PeriodFTEs = 0;
                        if (RVClass.PlanningCalendarID == RVClass.CalendarID)
                        {
                            l_PeriodFTEs = DBAccess.ReadIntValue(reader["CMH_FTES"]);
                        }
                        else
                        {
                            if (RVClass.OpenReqs.TryGetValue(l_UID, out oCommitment))
                            {
                                if (oCommitment != null)
                                {
                                    l_PeriodFTEs = GetFTEValue(clnFTEs, oCommitment.BC_UID_Role, dPeriodHours, l_PeriodID, 0);
                                }
                            }
                        }

                        // if we are on the same plan line and for the same period then increment the existing HOURS entry - can happen when Calendar != RP Calendar
                        if (l_PrevUID == 0 || l_PrevUID != l_UID || l_PrevPRD != l_PeriodID)
                        {
                            if (oCommitmentHours.Hours > 0) RVClass.OpenReqHours.Add(oCommitmentHours);
                            oCommitmentHours = new ResourceValues.clsCommitmentHours();
                            oCommitmentHours.UID = l_UID;
                            oCommitmentHours.PeriodID = l_PeriodID;
                        }
                        oCommitmentHours.Hours += dPeriodHours;
                        oCommitmentHours.FTES += l_PeriodFTEs;
                        l_PrevPRD = l_PeriodID;

                        // a total for the UID - across all periods
                        if (l_PrevUID > 0 && l_PrevUID != l_UID)
                        {
                            ResourceValues.clsCommitment oCommitment1 = new ResourceValues.clsCommitment();
                            if (RVClass.OpenReqs.TryGetValue(l_PrevUID, out oCommitment1)) { oCommitment1.HoursInWindow = dHours; }
                            dHours = 0;
                        }
                        l_PrevUID = l_UID;
                        dHours += dPeriodHours;
                    }
                    if (l_PrevUID > 0 && oCommitmentHours.Hours > 0) RVClass.OpenReqHours.Add(oCommitmentHours);
                    if (l_PrevUID > 0 && dHours > 0)
                    {
                        ResourceValues.clsCommitment oCommitment1 = new ResourceValues.clsCommitment();
                        if (RVClass.OpenReqs.TryGetValue(l_PrevUID, out oCommitment1)) { oCommitment1.HoursInWindow = dHours; }
                    }
                    reader.Close();
                }  //  get Requirement Hours

                //  get rid of any plan rows with no hours
                RemovePlanRowsWOHours(RVClass.OpenReqs);

                // add to lists of objects we've hit AFTER removing items w/o hours
                if (RVClass.OpenReqs != null)
                {
                    foreach (KeyValuePair<int, ResourceValues.clsCommitment> oCommitmentKeyValue in RVClass.OpenReqs)
                    {
                        if ((oCommitmentKeyValue.Value.WResID > 0) && !RVLists_Resources.Contains(oCommitmentKeyValue.Value.WResID)) { RVLists_Resources.Add(oCommitmentKeyValue.Value.WResID); }
                        if ((oCommitmentKeyValue.Value.ProjectID > 0) && !RVLists_PIs.Contains(oCommitmentKeyValue.Value.ProjectID)) { RVLists_PIs.Add(oCommitmentKeyValue.Value.ProjectID); }
                        if ((oCommitmentKeyValue.Value.RoleUID > 0) && !RVLists_Roles.Contains(oCommitmentKeyValue.Value.RoleUID)) { RVLists_Roles.Add(oCommitmentKeyValue.Value.RoleUID); }
                        if ((oCommitmentKeyValue.Value.DeptUID > 0) && !RVLists_Depts.Contains(oCommitmentKeyValue.Value.DeptUID)) { RVLists_Depts.Add(oCommitmentKeyValue.Value.DeptUID); }
                    }
                }
                // *********************************  End of Open Requirement stuff

                // get default Cost Category and Role from Xref table for when a resource doesn't have an explicit value
                sErrorInfo = "h001";
                int lDefaultCostCategory = 0, lDefaultRole = 0;
                cmdText = "SELECT xr.BC_UID as CCUID,cc.BC_ROLE as RoleUID From EPGP_COST_XREF xr" +
                    " Left Join EPGP_COST_CATEGORIES cc ON cc.BC_UID=xr.BC_UID" +
                    " Where WRES_ID = 0";
                oCommand = new SqlCommand(cmdText, _dba.Connection);
                reader = oCommand.ExecuteReader();
                if (reader.Read())
                {
                    lDefaultCostCategory = DBAccess.ReadIntValue(reader["CCUID"], out bIsNull);
                    lDefaultRole = DBAccess.ReadIntValue(reader["RoleUID"], out bIsNull);
                }
                reader.Close();

                // Get all WresIDs in the selected departments (only in the two Dept modes) and make sure they exist in the resources collection
                //   Needed for Reading Scheduled Work as well as getting Resource Info down lower
                //   (not obvious why we need do this for PIsInDept as we don't get Personal Items and Avail in that case anyway - leave alone though)

                //  before that make a copy of the resource collection - this is a list of resources we have info for - only needed if by dept or by resource
                sErrorInfo = "h002";
                if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts || lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForResources)
                {
                    foreach (int lResource in RVLists_Resources)
                    {
                        if (!RVLists_ResourcesWOinDept.Contains(lResource)) { RVLists_ResourcesWOinDept.Add(lResource); }
                    }
                }

                //  Create separate collection of just resources in the dept(s) - used below for getting Personal Items and avail
                //  add any extra resources into the Resource List we made above
                //   later note - don't want Personal Items and avail for resources no longer in the selected dept(s)
                sErrorInfo = "h010";
                List<int> clnDeptResources = new List<int>();
                if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts || lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIsinDept)
                {
                    oCommand = new SqlCommand("EPG_SP_ReadDeptsResMembers", _dba.Connection);
                    oCommand.Parameters.AddWithValue("sList", sDeptList);
                    oCommand.Parameters.AddWithValue("DeptMode", 1);
                    oCommand.Parameters.AddWithValue("ResourcesOnly", 1);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int l_WResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        clnDeptResources.Add(l_WResID);
                        if (!RVLists_Resources.Contains(l_WResID)) { RVLists_Resources.Add(l_WResID); }
                    }
                    reader.Close();
                }

                // Make a list of the selected WresIDs - unless list passed in or Mode = For PIs where Resource List = "NONE" still for SchedWork
                sErrorInfo = "h020";
                if (lRequestNo != ResourceValues.ResCenterRequest.ResourceValuesForResources && lRequestNo != ResourceValues.ResCenterRequest.ResourceValuesForPIs)
                {
                    sResourceList = MakeListFromCollection(RVLists_Resources);
                }

                sErrorInfo = "h030";
                //  we need the xrefs info so we can figure out the FTE values for the Scheduled Work and so on
                //  we are doing a lot of work for FTE - wonder if some people would like an option to disable it

                //  there were several different ways to determine the Xrefs we want for example INNER JOIN to the Forecast records for now though we'll just get them all
                Dictionary<int, int> clnXref = new Dictionary<int, int>();
                int lCat;
                cmdText = "select WRES_ID,BC_UID From EPGP_COST_XREF";
                oCommand = new SqlCommand(cmdText, _dba.Connection);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    int nWResID = DBAccess.ReadIntValue(reader["WRES_ID"], out bIsNull);
                    lCat = DBAccess.ReadIntValue(reader["BC_UID"], out bIsNull);
                    clnXref.Add(nWResID, lCat);
                }
                reader.Close();

                //   ***************************** Get Scheduled Work if required
                //     for now in  new version we will say it is always required
                //       NOTE - could probably aggregate in SQL rather than in code here (like Personal Items below) - guess would need temp table because of UNION
                sErrorInfo = "h035";
                {
                    RVClass.SchedWorkHours = new List<ResourceValues.clsSchedWork>();
                    ResourceValues.clsSchedWork oSchedWork = null;

                    //  would like to use GROUP BY in the SP to cut down on data from db sever but don't think can combine GROUP BY and UNION as I'd want
                    //    if we ever want to present all the different sources of Scheduled Work separately then GROUP BY would work great
                    oCommand = new SqlCommand("EPG_SP_ReadScheduledWork", _dba.Connection);
                    oCommand.Parameters.AddWithValue("Mode", lSPRequestNo);
                    oCommand.Parameters.AddWithValue("FromDate", FirstStartDate);
                    oCommand.Parameters.AddWithValue("ToDate", LastFinishDate);
                    oCommand.Parameters.AddWithValue("sList", sPIList);
                    oCommand.Parameters.AddWithValue("sRList", sResourceList);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = oCommand.ExecuteReader();

                    int lProjectID, lResInPlan, lWResID = 0;
                    DateTime dtWorkDate;
                    string sMajorCategory;
                    lPeriodID = 0;

                    while (reader.Read())
                    {
                        lProjectID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                        lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        lResInPlan = DBAccess.ReadIntValue(reader["RES_IN_PLAN"]);
                        sMajorCategory = reader["TSWORK_MAJORCATEGORY"].ToString();
                        dtWorkDate = DBAccess.ReadDateValue(reader["TSWORK_DATE"]);

                        // always show Provisional item if we are displaying for PIs (from PI Center)
                        //        ... otherwise ignore where the resource NOT in Resource Plan AND option set to only show them to PM 
                        //               VERY confusing and not quite sure it's right!
                        if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIs || ((lAssnsNeedRMApproval != 1) || (lResInPlan == 1)))
                        {
                            lPeriodID = MapToPeriod(RVClass.Periods, dtWorkDate);
                            if (!RVLists_Resources.Contains(lWResID)) { RVLists_Resources.Add(lWResID); }
                            if (!RVLists_PIs.Contains(lProjectID)) { RVLists_PIs.Add(lProjectID); }
                            if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts || lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForResources)
                            {
                                if (!RVLists_ResourcesWOinDept.Contains(lWResID)) { RVLists_ResourcesWOinDept.Add(lWResID); }  // our sep list w/o dept resources added
                            }
                        }
                        if (oSchedWork != null)
                        {
                            //  if we've hit a new PI, Resource, Period, or MajorCategory then save to collection
                            if ((oSchedWork.ProjectID != lProjectID) || (oSchedWork.WResID != lWResID) ||
                                    (oSchedWork.MajorCategory != sMajorCategory) || (oSchedWork.PeriodID != lPeriodID))
                            {
                                // get the resource Cost Category Role, use this together with period to pick up the FTE factor and calc the value
                                if (oSchedWork.PeriodID > 0)
                                {
                                    lBCUID = GetBCUID(clnXref, lWResID);
                                    if (lBCUID == 0) { lBCUID = lDefaultCostCategory; }
                                    oSchedWork.Hours = oSchedWork.Hours / 100;
                                    oSchedWork.FTES = GetFTEValue(clnFTEs, lBCUID, oSchedWork.Hours, oSchedWork.PeriodID, 0);
                                    RVClass.SchedWorkHours.Add(oSchedWork);
                                }
                                oSchedWork = new ResourceValues.clsSchedWork();
                            }
                        }
                        else
                        {
                            oSchedWork = new ResourceValues.clsSchedWork();
                        }
                        oSchedWork.ProjectID = lProjectID;
                        oSchedWork.WResID = lWResID;
                        oSchedWork.MajorCategory = sMajorCategory;
                        oSchedWork.PeriodID = lPeriodID;
                        oSchedWork.Hours += DBAccess.ReadDoubleValue(reader["TSWORK_WORK"]);
                    }
                    reader.Close();

                    //  add possible last entry
                    if (oSchedWork != null && oSchedWork.PeriodID > 0)
                    {
                        lBCUID = GetBCUID(clnXref, lWResID);
                        if (lBCUID == 0) { lBCUID = lDefaultCostCategory; };
                        oSchedWork.Hours = oSchedWork.Hours / 100;
                        oSchedWork.FTES = GetFTEValue(clnFTEs, lBCUID, oSchedWork.Hours, oSchedWork.PeriodID, 0);
                        RVClass.SchedWorkHours.Add(oSchedWork);
                    }
                }
                //   ***************************** end of section to get Scheduled Work

                //   ***************************** Get Actual Work if required
                //     for now we will say it is always required but me worry about amount of data even though Grouping will cut that way down
                sErrorInfo = "h040";
                {
                    RVClass.ActualWorkHours = new List<ResourceValues.clsSchedWork>();
                    ResourceValues.clsSchedWork oActualWork = null;

                    oCommand = new SqlCommand("EPG_SP_ReadActualWork", _dba.Connection);
                    oCommand.Parameters.AddWithValue("Mode", lSPRequestNo);
                    oCommand.Parameters.AddWithValue("CalID", RVClass.CalendarID);
                    oCommand.Parameters.AddWithValue("FromPeriodID", RVClass.FromPeriodID);
                    oCommand.Parameters.AddWithValue("ToPeriodID", RVClass.ToPeriodID);
                    oCommand.Parameters.AddWithValue("sList", sPIList);
                    oCommand.Parameters.AddWithValue("sRList", sResourceList);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        oActualWork = new clsSchedWork();
                        oActualWork.ProjectID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                        oActualWork.WResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        oActualWork.MajorCategory = reader["WEC_MAJORCATEGORY"].ToString();
                        oActualWork.PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        oActualWork.Hours = (DBAccess.ReadDoubleValue(reader["Hours"])) / 100.0;

                        if (!RVLists_Resources.Contains(oActualWork.WResID)) { RVLists_Resources.Add(oActualWork.WResID); }
                        if (!RVLists_PIs.Contains(oActualWork.ProjectID)) { RVLists_PIs.Add(oActualWork.ProjectID); }
                        if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts || lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForResources)
                        {
                            if (!RVLists_ResourcesWOinDept.Contains(oActualWork.WResID)) { RVLists_ResourcesWOinDept.Add(oActualWork.WResID); }  // our sep list w/o dept resources added
                        }

                        // get the resource Cost Category Role, use this together with period to pick up the FTE factor and calc the value
                        if (oActualWork.PeriodID > 0)
                        {
                            lBCUID = GetBCUID(clnXref, oActualWork.WResID);
                            if (lBCUID == 0) { lBCUID = lDefaultCostCategory; }
                            oActualWork.FTES = GetFTEValue(clnFTEs, lBCUID, oActualWork.Hours, oActualWork.PeriodID, 0);
                            RVClass.ActualWorkHours.Add(oActualWork);
                        }
                    }
                    reader.Close();
                }
                //   ***************************** end of section to get Actual Work


                //  comment from VB: If we are refreshing the values for a list of PIs (one) within a dept then don't need all the stuff following here
                //      don't think we'll be supporting that option in non_ActiveX
                //If lRequestNo = ResCenterRequest.ResourceValuesForPIinDept Then GoTo byebye

                // unless a list of PIs was passed in then make a list of the PIs we have hit
                sErrorInfo = "h050";
                if (lRequestNo != ResourceValues.ResCenterRequest.ResourceValuesForPIsinDept && lRequestNo != ResourceValues.ResCenterRequest.ResourceValuesForPIinDept &&
                        lRequestNo != ResourceValues.ResCenterRequest.ResourceValuesForPIs)
                {
                    sPIList = MakeListFromCollection(RVLists_PIs);
                }

                // *********************** get data for the PIs we're interested in
                sErrorInfo = "h060";
                if (sPIList.Length > 0)
                {
                    RVClass.PIs = new Dictionary<int, ResourceValues.clsPIData>();

                    // create a dirty great SQL stmnt to get all the regular fields plus the custom fields we've selected
                    string sSQLExtraFields1 = "", sSQLExtraFields2 = "";
                    bool bPortfolioINT = false, bPortfolioTEXT = false, bProjectINT = false, bProjectTEXT = false;

                    string sTable;
                    string sField;
                    foreach (ResourceValues.clsPortField oPIFieldItem in RVClass.PIFields)
                    {
                        if (oPIFieldItem.CFTable == (int)CustomFieldDBTable.PortfolioINT)
                        {
                            if (EPKClass01.GetTableAndField(oPIFieldItem.CFTable, oPIFieldItem.CFField, out sTable, out sField))
                            {
                                bPortfolioINT = true;
                                sSQLExtraFields1 += "," + sField;
                                oPIFieldItem.FullGenName = sField;
                            }
                        }
                        else if (oPIFieldItem.CFTable == (int)CustomFieldDBTable.PortfolioTEXT)
                        {
                            if (EPKClass01.GetTableAndField(oPIFieldItem.CFTable, oPIFieldItem.CFField, out sTable, out sField))
                            {
                                bPortfolioTEXT = true;
                                sSQLExtraFields1 += "," + sField;
                                oPIFieldItem.FullGenName = sField;
                            }
                        }
                        else if (oPIFieldItem.CFTable == (int)CustomFieldDBTable.ProjectINT)
                        {
                            if (EPKClass01.GetTableAndField(oPIFieldItem.CFTable, oPIFieldItem.CFField, out sTable, out sField))
                            {
                                bProjectINT = true;
                                sSQLExtraFields2 += "," + sField;
                                oPIFieldItem.FullGenName = sField;
                            }
                        }
                        else if (oPIFieldItem.CFTable == (int)CustomFieldDBTable.ProjectTEXT)
                        {
                            if (EPKClass01.GetTableAndField(oPIFieldItem.CFTable, oPIFieldItem.CFField, out sTable, out sField))
                            {
                                bProjectTEXT = true;
                                sSQLExtraFields2 += "," + sField;
                                oPIFieldItem.FullGenName = sField;
                            }
                        }
                        else
                        {
                            oPIFieldItem.CFTable = -1;
                        }
                    }

                    cmdText = "SELECT p.PROJECT_ID,pv.WPROJ_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_PRIORITY,PROJECT_MANAGER," +
                        "r1.RES_NAME as ItemMgr,r2.RES_NAME as StageOwner, s.STAGE_NAME " + sSQLExtraFields1 + sSQLExtraFields2 +
                    " FROM EPGP_PROJECTS p" +
                    " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sPIList + "') LT on p.PROJECT_ID=LT.TokenVal" +
                    " Left Join EPGX_PROJECT_VERSIONS pv On pv.PROJECT_ID=p.PROJECT_ID And pv.VERSION_ID=" + lDefaultVersion.ToString();
                    if (bPortfolioINT == true) { cmdText += " Left Join EPGP_PROJECT_INT_VALUES pi On pi.PROJECT_ID=p.PROJECT_ID"; }
                    if (bPortfolioTEXT == true) { cmdText += " Left Join EPGP_PROJECT_TEXT_VALUES pt On pt.PROJECT_ID=p.PROJECT_ID"; }
                    if (bProjectINT == true) { cmdText += " Left Join EPGX_PROJ_INT_VALUES ei On ei.WPROJ_ID=pv.WPROJ_ID"; }
                    if (bProjectTEXT == true) { cmdText += " Left Join EPGX_PROJ_TEXT_VALUES et On et.WPROJ_ID=pv.WPROJ_ID"; }
                    cmdText += " Left Join EPG_RESOURCES r1 On r1.WRES_ID=p.PROJECT_MANAGER" +
                            " Left Join EPG_RESOURCES r2 On r2.WRES_ID=p.PROJECT_OWNER" +
                            " Left Join EPGP_STAGES s On s.STAGE_ID=p.PROJECT_STAGE_ID";

                    sErrorInfo = "h070";
                    oCommand = new SqlCommand(cmdText, _dba.Connection);
                    reader = oCommand.ExecuteReader();

                    ResourceValues.clsPIData oPIData;
                    int lProjectID = 0, lWProjID = 0;
                    while (reader.Read())
                    {
                        oPIData = new ResourceValues.clsPIData();
                        lProjectID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                        oPIData.ProjectID = lProjectID;
                        lWProjID = DBAccess.ReadIntValue(reader["WPROJ_ID"]);   // Wonder what this is used for because it is now different
                        oPIData.WprojID = lWProjID;
                        oPIData.PIName = DBAccess.ReadStringValue(reader["PROJECT_NAME"]);
                        oPIData.start = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"]);
                        oPIData.finish = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"]);
                        oPIData.Priority = DBAccess.ReadIntValue(reader["PROJECT_PRIORITY"]);
                        oPIData.ItemManagerWresID = DBAccess.ReadIntValue(reader["PROJECT_MANAGER"]);
                        oPIData.ItemManager = DBAccess.ReadStringValue(reader["ItemMgr"]);
                        oPIData.Stage = DBAccess.ReadStringValue(reader["STAGE_NAME"]);
                        oPIData.StageOwner = DBAccess.ReadStringValue(reader["StageOwner"]);

                        oPIData.CustomFields = new List<string>();
                        foreach (ResourceValues.clsPortField oPIFieldCustom in RVClass.PIFields)
                        {
                            if (oPIFieldCustom.CFTable > 0)
                            {
                                AddCustomField(oPIData.CustomFields, oPIFieldCustom.ID, oPIFieldCustom.Fieldtype, reader, oPIFieldCustom.FullGenName);
                            }
                        }
                        RVClass.PIs.Add(lProjectID, oPIData);
                    }
                    reader.Close();
                }
                //   ************************ end of section to get PI data

                // make a list from the full list of resources we are interested in except if resources passed in then use that list we've already created above
                sErrorInfo = "j001";
                if (lRequestNo != ResourceValues.ResCenterRequest.ResourceValuesForResources)
                {
                    sResourceList = MakeListFromCollection(RVLists_Resources);
                }

                // *********************** get data for the resources we're interested in
                sErrorInfo = "j010";
                if (sResourceList.Length > 0)
                {
                    RVClass.Resources = new Dictionary<int, ResourceValues.clsResCap>();

                    // create a dirty great SQL stmnt to get all the regular fields plus the custom fields we've selected
                    string sSQLExtraFields1 = "";
                    bool bResourceINT = false, bResourceTEXT = false;

                    string sTable;
                    string sField;
                    foreach (ResourceValues.clsPortField oResFieldItem in RVClass.ResFields)
                    {
                        if (oResFieldItem.CFTable == (int)CustomFieldDBTable.ResourceINT)
                        {
                            if (EPKClass01.GetTableAndField(oResFieldItem.CFTable, oResFieldItem.CFField, out sTable, out sField))
                            {
                                bResourceINT = true;
                                sSQLExtraFields1 += "," + sField;
                                oResFieldItem.FullGenName = sField;
                            }
                        }
                        else if (oResFieldItem.CFTable == (int)CustomFieldDBTable.ResourceTEXT)
                        {
                            if (EPKClass01.GetTableAndField(oResFieldItem.CFTable, oResFieldItem.CFField, out sTable, out sField))
                            {
                                bResourceTEXT = true;
                                sSQLExtraFields1 += "," + sField;
                                oResFieldItem.FullGenName = sField;
                            }
                        }
                        else
                        {
                            oResFieldItem.CFTable = -1;
                        }
                    }

                    cmdText = "SELECT wr.WRES_ID,RES_NAME,WRES_IS_RESOURCE,WRES_IS_GENERIC,WRES_INACTIVE,xr.BC_UID as CCUID,cc.BC_ROLE as RoleUID,WRES_RP_DEPT" + sSQLExtraFields1 +
                        " From EPG_RESOURCES wr" +
                    " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sResourceList + "') LT on WRES_ID=LT.TokenVal";
                    if (bResourceINT == true) { cmdText += " Left Join EPGC_RESOURCE_INT_VALUES cf ON wr.WRES_ID=cf.WRES_ID"; }
                    if (bResourceTEXT == true) { cmdText += " Left Join EPGC_RESOURCE_TEXT_VALUES ct ON wr.WRES_ID=ct.WRES_ID"; }
                    cmdText += " LEFT JOIN EPGP_COST_XREF xr ON WR.WRES_ID=xr.WRES_ID" +
                            " Left Join EPGP_COST_CATEGORIES cc ON cc.BC_UID=xr.BC_UID";

                    sErrorInfo = "j020";
                    oCommand = new SqlCommand(cmdText, _dba.Connection);
                    reader = oCommand.ExecuteReader();

                    ResourceValues.clsResCap oResData;
                    int lXrefCC = 0;
                    while (reader.Read())
                    {
                        oResData = new ResourceValues.clsResCap();
                        oResData.ID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        oResData.IsResource = (DBAccess.ReadIntValue(reader["WRES_IS_RESOURCE"]) == 1);
                        oResData.IsGeneric = (DBAccess.ReadIntValue(reader["WRES_IS_GENERIC"]) == 1);
                        oResData.Inactive = (DBAccess.ReadIntValue(reader["WRES_INACTIVE"]) == 1);
                        oResData.DeptUID = DBAccess.ReadIntValue(reader["WRES_RP_DEPT"]);
                        oResData.Name = DBAccess.ReadStringValue(reader["RES_NAME"]);
                        oResData.RoleUID = DBAccess.ReadIntValue(reader["RoleUID"]);
                        lXrefCC = DBAccess.ReadIntValue(reader["CCUID"]);
                        if (lXrefCC == 0)
                        {
                            lXrefCC = lDefaultCostCategory;
                            oResData.RoleUID = lDefaultRole;
                        }

                        if (oResData.RoleUID > 0 && !RVLists_Roles.Contains(oResData.RoleUID)) { RVLists_Roles.Add(oResData.RoleUID); }
                        if (oResData.DeptUID > 0 && !RVLists_Depts.Contains(oResData.DeptUID)) { RVLists_Depts.Add(oResData.DeptUID); }

                        ResourceValues.clsCatItem oCatItem1 = new ResourceValues.clsCatItem();
                        if (RVClass.CostCategories.TryGetValue(lXrefCC, out oCatItem1))
                        {
                            if (oCatItem1.Role_UID > 0)
                            {
                                oResData.BC_UID_Role = lXrefCC;
                                oResData.BC_UID_CC = oCatItem1.PID;
                            }
                            else
                            {
                                oResData.BC_UID_Role = lXrefCC;
                                oResData.BC_UID_CC = lXrefCC;
                            }
                        }
                        else
                        {
                            oResData.BC_UID_Role = lXrefCC;
                            oResData.BC_UID_CC = lXrefCC;
                        }

                        sErrorInfo = "j030";
                        oResData.CustomFields = new List<string>();
                        foreach (ResourceValues.clsPortField oResFieldCustom in RVClass.ResFields)
                        {
                            if (oResFieldCustom.CFTable > 0)
                            {
                                AddCustomField(oResData.CustomFields, oResFieldCustom.ID, oResFieldCustom.Fieldtype, reader, oResFieldCustom.FullGenName);
                            }
                        }
                        RVClass.Resources.Add(oResData.ID, oResData);
                    }
                    reader.Close();

                }
                //   ************************ end of section to get resource data

                // Make a list of the departments we've hit (unless list passed in) and get their names
                sErrorInfo = "k001";
                RVClass.UserDepartments = new List<int>();
                if (lRequestNo != ResourceValues.ResCenterRequest.ResourceValuesForDepts)
                {
                    // June 2013 - new List of Departments I have access to when called from Resource Grid
                    //      won't work for list of Depts passed in but that can't happen in WE
                    //      need to add to the departments I've hit list before I get the data for that
                    if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForResources)
                    {
                        string sDeptXML;
                        SelectMyDepts(out sDeptXML);
                        CStruct xSelDepts = new CStruct();
                        xSelDepts.LoadXML(sDeptXML);
                        List<CStruct> listDepts = xSelDepts.GetList("Dept");
                        foreach (CStruct xSelDept in listDepts)
                        {
                            int lDeptID = xSelDept.GetIntAttr("ID");
                            RVClass.UserDepartments.Add(lDeptID);
                            if (!RVLists_Depts.Contains(lDeptID)) { RVLists_Depts.Add(lDeptID); }
                        }
                    }

                    sDeptList = MakeListFromCollection(RVLists_Depts);
                }

                RVClass.Departments = new Dictionary<int, ResourceValues.clsEPKItem>();
                if (sDeptList.Length > 0)
                {
                    oCommand = new SqlCommand("EPG_SP_ReadLookupValues", _dba.Connection);
                    oCommand.Parameters.AddWithValue("sList", sDeptList);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    ResourceValues.clsEPKItem oDept;
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        oDept = new ResourceValues.clsEPKItem();
                        oDept.ID = DBAccess.ReadIntValue(reader["LV_UID"]);
                        oDept.Name = DBAccess.ReadStringValue(reader["LV_VALUE"]);
                        RVClass.Departments.Add(oDept.ID, oDept);
                    }
                    reader.Close();
                }

                // *********************** Get Capacity Target Sets, first names then values - Only when called for a list of depts
                sErrorInfo = "k020";
                // if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts)
                {
                    RVClass.CapacityTargets = new Dictionary<int, ResourceValues.clsEPKItem>();

                    // now we can't call for Depts and this bit is executed for resources we want the Capacity Scenarios for the Departments I manage not the ones we've hit
                    // wouldn't expect it would be different but not sure
                    string sManagedDeptList = MakeListFromCollection(RVClass.UserDepartments);

                    string sDeptListPlus0;
                    if (sManagedDeptList.Length > 0) { sDeptListPlus0 = sManagedDeptList + ",0"; }
                    else { sDeptListPlus0 = "0"; }


                    cmdText = "SELECT * From EPGP_CAPACITY_SETS WHERE DEPT_UID IN (" + sDeptListPlus0 + ") Order by DEPT_UID,CS_NAME";

                    oCommand = new SqlCommand(cmdText, _dba.Connection);





                    //oCommand = new SqlCommand("EPG_SP_ReadCapacityTargets", _dba.Connection);
                    //oCommand.Parameters.AddWithValue("sList", sDeptListPlus0);
                    //oCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    ResourceValues.clsEPKItem oCapacityItem;

                    reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        oCapacityItem = new ResourceValues.clsEPKItem();
                        oCapacityItem.ID = DBAccess.ReadIntValue(reader["CS_ID"]);
                        oCapacityItem.Name = DBAccess.ReadStringValue(reader["CS_NAME"]);
                        oCapacityItem.UID = DBAccess.ReadIntValue(reader["DEPT_UID"]);

                        try
                        {
                            oCapacityItem.Flag = DBAccess.ReadIntValue(reader["CS_ROLE_BASED"]);
                        }
                        catch (Exception ex)
                        {
                            oCapacityItem.Flag = 0;
                        }


                        RVClass.CapacityTargets.Add(oCapacityItem.ID, oCapacityItem);
                    }
                    reader.Close();

                    sErrorInfo = "k021";
                    RVClass.CapacityTargetValues = new List<ResourceValues.clsCapacityValue>();
                    ResourceValues.clsCapacityValue oCapacityValue = null;

                    oCommand = new SqlCommand("EPG_SP_ReadCapacityValues", _dba.Connection);
                    oCommand.Parameters.AddWithValue("CalID", RVClass.PlanningCalendarID);
                    oCommand.Parameters.AddWithValue("TargetID", 0);  // 0 means all periods so ignores following parms
                    oCommand.Parameters.AddWithValue("FromPeriodID", lFirstPeriod);
                    oCommand.Parameters.AddWithValue("ToPeriodID", lLastPeriod);
                    oCommand.Parameters.AddWithValue("sList", sDeptListPlus0);   // in VB we had sDeptList here - looked wrong?
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = oCommand.ExecuteReader();

                    int l_UID, l_PeriodID, l_DeptUID, l_CCRUID;
                    while (reader.Read())
                    {
                        l_UID = DBAccess.ReadIntValue(reader["CS_ID"]);
                        l_PeriodID = DBAccess.ReadIntValue(reader["BD_PERIOD"]);
                        l_DeptUID = DBAccess.ReadIntValue(reader["DEPT_UID"]);
                        l_CCRUID = DBAccess.ReadIntValue(reader["ROLE_ID"]);

                        if (RVClass.PlanningCalendarID != RVClass.CalendarID)
                        {
                            int lDisplayPeriod;
                            if (dicDisplayPeriods.TryGetValue(l_PeriodID, out lDisplayPeriod)) l_PeriodID = lDisplayPeriod; else l_PeriodID = 0;
                        }

                        //  if we've hit a new Set, Period, Dept, or Role then save this item - have to save behind read because multiple periods may be combined
                        if (oCapacityValue != null)
                        {
                            if ((oCapacityValue.ID != l_UID) || (oCapacityValue.PeriodID != l_PeriodID) ||
                                    (oCapacityValue.DeptUID != l_DeptUID) || (oCapacityValue.RoleUID != l_CCRUID))
                            {
                                // There is a lot of shenanigans here in he VB to do with the Categories item that it picks up. 
                                //  Didn't do much and makes no sense to me. For sure it has been changed over time - I decided to leave it all out - KT: Jan 2012

                                if (oCapacityValue.Hours > 0 && oCapacityValue.FTES <= 0)
                                {
                                    oCapacityValue.FTES = GetFTEValue(clnFTEs, oCapacityValue.RoleUID, oCapacityValue.Hours, oCapacityValue.PeriodID, 0);
                                }
                                RVClass.CapacityTargetValues.Add(oCapacityValue);
                                // in case we hit some new CCRs here 
                                if ((oCapacityValue.RoleUID > 0) && !RVLists_Roles.Contains(oCapacityValue.RoleUID)) { RVLists_Roles.Add(oCapacityValue.RoleUID); }
                                oCapacityValue = new ResourceValues.clsCapacityValue();
                            }
                        }
                        else
                        {
                            oCapacityValue = new ResourceValues.clsCapacityValue();
                        }
                        oCapacityValue.ID = l_UID;
                        oCapacityValue.PeriodID = l_PeriodID;
                        oCapacityValue.DeptUID = l_DeptUID;
                        oCapacityValue.RoleUID = l_CCRUID;
                        oCapacityValue.Hours += DBAccess.ReadDoubleValue(reader["CS_AVAIL"]);
                        if (RVClass.PlanningCalendarID == RVClass.CalendarID) { oCapacityValue.FTES = DBAccess.ReadIntValue(reader["CS_FTES"]); }
                    }
                    reader.Close();

                    //  add possible last entry
                    if (oCapacityValue != null && oCapacityValue.PeriodID > 0)
                    {
                        if (oCapacityValue.Hours > 0 && oCapacityValue.FTES <= 0)
                        {
                            oCapacityValue.FTES = GetFTEValue(clnFTEs, oCapacityValue.RoleUID, oCapacityValue.Hours, oCapacityValue.PeriodID, 0);
                        }
                        RVClass.CapacityTargetValues.Add(oCapacityValue);
                        if ((oCapacityValue.RoleUID > 0) && !RVLists_Roles.Contains(oCapacityValue.RoleUID)) { RVLists_Roles.Add(oCapacityValue.RoleUID); }
                    }
                }
                //   ************************ end of section to get Capacity Target Sets

                // Make a list of the roles we've hit and get their names
                sErrorInfo = "m001";
                string sRoleList = MakeListFromCollection(RVLists_Roles);

                sErrorInfo = "m010";
                RVClass.Roles = new Dictionary<int, ResourceValues.clsListItem>();
                if (sRoleList.Length > 0)
                {
                    oCommand = new SqlCommand("EPG_SP_ReadLookupValues", _dba.Connection);
                    oCommand.Parameters.AddWithValue("sList", sRoleList);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    ResourceValues.clsListItem oRole;
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        oRole = new ResourceValues.clsListItem();
                        oRole.ID = DBAccess.ReadIntValue(reader["LV_UID"]);
                        oRole.Name = DBAccess.ReadStringValue(reader["LV_VALUE"]);
                        RVClass.Roles.Add(oRole.ID, oRole);
                    }
                    reader.Close();
                }


                // for a Dept(s) call - from here on we only want data for the resources currently in the dept(s)
                if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts) { sResourceList = MakeListFromCollection(clnDeptResources); }


                // Tidier to get Personal Items before availability now - also, always get because need for PIs to reduce availability
                // ok so we want availability now even for PIs but we still don't want Personal Items

                // following line used to step over this section
                //if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIs || lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIsinDept) { goto Wrapup; }

                // Get Personal Items data for the selected WresIDs (in dept)
                sErrorInfo = "m030";
                if (sResourceList.Length > 0)
                {
                    RVClass.ResNWValues = new List<ResourceValues.clsNWValue>();
                    ResourceValues.clsNWValue oResNWValue = null;

                    oCommand = new SqlCommand("EPG_SP_GetNonWorkByPeriod", _dba.Connection);
                    oCommand.Parameters.AddWithValue("CalID", RVClass.PlanningCalendarID);
                    oCommand.Parameters.AddWithValue("FirstPeriodID", RVClass.FromPeriodID);
                    oCommand.Parameters.AddWithValue("LastPeriodID", RVClass.ToPeriodID);
                    oCommand.Parameters.AddWithValue("sList", sResourceList);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        oResNWValue = new ResourceValues.clsNWValue();
                        oResNWValue.UID = DBAccess.ReadIntValue(reader["NWI_ID"]);
                        oResNWValue.WResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        oResNWValue.PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        oResNWValue.Hours = DBAccess.ReadDoubleValue(reader["Hours"]);

                        // get the resource Cost Category Role, then use this together with period to pick up the FTE factor and calc the value
                        ResourceValues.clsResCap oResData;
                        if (RVClass.Resources.TryGetValue(oResNWValue.WResID, out oResData))
                        {
                            oResNWValue.FTES = GetFTEValue(clnFTEs, oResData.BC_UID_Role, oResNWValue.Hours, oResNWValue.PeriodID, 0);
                        }
                        RVClass.ResNWValues.Add(oResNWValue);

                        if (!RVLists_UIDs.Contains(oResNWValue.UID)) { RVLists_UIDs.Add(oResNWValue.UID); }
                        if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts || lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForResources)
                        {
                            if (!RVLists_ResourcesWOinDept.Contains(oResNWValue.WResID)) { RVLists_ResourcesWOinDept.Add(oResNWValue.WResID); }  // our sep list w/o dept resources added
                        }
                    }
                    reader.Close();
                }

                // add a dummy Personal Item for any resource, either in the list of selected resources or selected depts, if it isn't mentioned somewhere else
                sErrorInfo = "m031";
                List<int> clnResourcesWeMustShow = new List<int>();
                if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForDepts)
                { clnResourcesWeMustShow = clnDeptResources; }
                else
                { clnResourcesWeMustShow = SelectedResources; }

                if (clnResourcesWeMustShow != null)
                {
                    foreach (int lWResIDinList in clnResourcesWeMustShow)
                    {
                        if (!RVLists_ResourcesWOinDept.Contains(lWResIDinList))
                        {
                            ResourceValues.clsNWValue oResNWValue = new ResourceValues.clsNWValue();
                            oResNWValue.UID = 999999;
                            oResNWValue.WResID = lWResIDinList;
                            oResNWValue.Hours = 0;
                            oResNWValue.PeriodID = RVClass.FromPeriodID;
                            RVClass.ResNWValues.Add(oResNWValue);
                        }
                    }
                }

                //  get names for the Personal Items
                sErrorInfo = "m040";
                string sNWIList = MakeListFromCollection(RVLists_UIDs);

                RVClass.NWItems = new Dictionary<int, ResourceValues.clsEPKItem>();
                ResourceValues.clsEPKItem oResNWI;

                // first add in the dummy Personal Item we may have used above
                oResNWI = new ResourceValues.clsEPKItem();
                oResNWI.ID = 999999;
                oResNWI.Name = "No Assigned Work";
                RVClass.NWItems.Add(oResNWI.ID, oResNWI);

                if (sNWIList.Length > 0)
                {
                    oCommand = new SqlCommand("EPG_SP_GetNonWorkItemNames", _dba.Connection);
                    oCommand.Parameters.AddWithValue("sList", sNWIList);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        oResNWI = new ResourceValues.clsEPKItem();
                        oResNWI.ID = DBAccess.ReadIntValue(reader["NWI_ID"]);
                        oResNWI.Name = DBAccess.ReadStringValue(reader["NWI_NAME"]);
                        RVClass.NWItems.Add(oResNWI.ID, oResNWI);
                    }
                    reader.Close();
                }


                // ********* Get AVAILABILITY data for the selected Resources - always now regardless of calling mode

                //      We are assuming the cal for the calculated avail is the Planning Calendar. 
                //      This is correct as that is the only calc option (except for speecial option we did for someone) but no real reason for that in this code
                sErrorInfo = "m060";
                if (sResourceList.Length > 0)
                {
                    // now we're going to read the avail into a period 'array' for each resource so we can subtract usage when called for a PI

                    // create a period 'array' for each resource
                    Dictionary<int, Dictionary<int, double>> ResourceAvailabilities = new Dictionary<int, Dictionary<int, double>>();
                    Dictionary<int, Dictionary<int, double>> ResourceOffHours = new Dictionary<int, Dictionary<int, double>>();
                    Dictionary<int, double> PeriodAvailabilities;
                    Dictionary<int, double> PeriodOffHours;

                    string[] spWresIds = sResourceList.Split(',');
                    foreach (string spWresId in spWresIds)
                    {
                        int lWresID = Convert.ToInt32(spWresId);
                        PeriodAvailabilities = new Dictionary<int, double>();
                        PeriodOffHours = new Dictionary<int, double>();
                        for (int i = RVClass.FromPeriodID; i <= RVClass.ToPeriodID; i++)
                        {
                            PeriodAvailabilities.Add(i, 0);
                            PeriodOffHours.Add(i, 0);
                        }
                        ResourceAvailabilities.Add(lWresID, PeriodAvailabilities);
                        ResourceOffHours.Add(lWresID, PeriodOffHours);
                    }
                    // now we've got a bunch of empty arrays ...  just waiting for availabilities

                    sErrorInfo = "m061";
                    RVClass.ResAvail = new List<ResourceValues.clsResAvail>();
                    ResourceValues.clsResAvail oResAvail = null;

                    oCommand = new SqlCommand("EPG_SP_ReadResourceAvail", _dba.Connection);
                    oCommand.Parameters.AddWithValue("CalID", RVClass.PlanningCalendarID);
                    oCommand.Parameters.AddWithValue("FromPeriodID", lFirstPeriod);
                    oCommand.Parameters.AddWithValue("ToPeriodID", lLastPeriod);
                    oCommand.Parameters.AddWithValue("sList", sResourceList);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int l_WresID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        int l_PeriodID = DBAccess.ReadIntValue(reader["BD_PERIOD"]);

                        if (RVClass.PlanningCalendarID != RVClass.CalendarID)
                        {
                            int lDisplayPeriod;
                            if (dicDisplayPeriods.TryGetValue(l_PeriodID, out lDisplayPeriod)) l_PeriodID = lDisplayPeriod; else l_PeriodID = 0;
                        }

                        Dictionary<int, double> Availabilities;
                        if (ResourceAvailabilities.TryGetValue(l_WresID, out Availabilities))
                        {
                            if (l_PeriodID >= RVClass.FromPeriodID && l_PeriodID <= RVClass.ToPeriodID)
                                Availabilities[l_PeriodID] += DBAccess.ReadDoubleValue(reader["CS_AVAIL"]);
                        }

                        Dictionary<int, double> OffHours;
                        if (ResourceOffHours.TryGetValue(l_WresID, out OffHours))
                        {
                            if (l_PeriodID >= RVClass.FromPeriodID && l_PeriodID <= RVClass.ToPeriodID)
                                OffHours[l_PeriodID] += DBAccess.ReadDoubleValue(reader["CS_OFF"]);
                        }
                    }
                    reader.Close();

                    // Reduce AVAILABILITY by Personal Time Off on Personal Items AND by work on all OTHER PIs - ONLY when called for PIs as Personal Items are in RPA for resource modes
                    if (lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIs || lRequestNo == ResourceValues.ResCenterRequest.ResourceValuesForPIsinDept)
                    {
                        // reduce by Personal TIme Off which we've already read above
                        foreach (clsNWValue oNWItem in RVClass.ResNWValues)
                        {
                            Dictionary<int, double> Availabilities;
                            if (ResourceAvailabilities.TryGetValue(oNWItem.WResID, out Availabilities))
                            {
                                if (oNWItem.PeriodID >= RVClass.FromPeriodID && oNWItem.PeriodID <= RVClass.ToPeriodID)
                                    Availabilities[oNWItem.PeriodID] -= oNWItem.Hours;
                            }
                        }

                        // If calling mode is for PIs then we don't need to pass Personal Items - get rid of the collection we made
                        RVClass.ResNWValues = null;
                        RVClass.NWItems = null;

                        // read work for all other PIs and subtract from availability
                        // SQL here owes quite a bit to Rob's SP ReadResourcesWorkB so condition for which work to include should especially be the same
                        cmdText = "SELECT RPH.PRD_ID,RP.WRES_ID,SUM(CMH_HOURS) as Hours" +
                                  " FROM EPG_RESOURCEPLANS_HOURS RPH" +
                                  " JOIN EPG_RESOURCEPLANS RP ON (RP.CMT_UID = RPH.CMT_UID)" +
                                  " WHERE RP.PROJECT_ID NOT IN" +
                                  " (Select TokenVal From EPG_FN_ConvertListToTable(N'" + sPIList + "') LT Join EPGP_PROJECTS p On p.PROJECT_ID=LT.TokenVal And PROJECT_MARKED_DELETION=0)" +
                                  " AND (RPH.PRD_ID >= @FromPeriodID AND RPH.PRD_ID <= @ToPeriodID)" +
                                  " AND (RP.CMT_STATUS = 256 AND RPH.CMH_PENDING = 0)" +
                                  " GROUP BY RPH.PRD_ID,RP.WRES_ID" +
                                  " ORDER BY RP.WRES_ID,RPH.PRD_ID";
                        oCommand = new SqlCommand(cmdText, _dba.Connection);
                        oCommand.Parameters.AddWithValue("@FromPeriodID", lFirstPeriod);
                        oCommand.Parameters.AddWithValue("@ToPeriodID", lLastPeriod);
                        reader = oCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            int lWresID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                            int l_PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                            double dHours = DBAccess.ReadDoubleValue(reader["Hours"]) / 100;

                            if (RVClass.PlanningCalendarID != RVClass.CalendarID)
                            {
                                int lDisplayPeriod;
                                if (dicDisplayPeriods.TryGetValue(l_PeriodID, out lDisplayPeriod)) l_PeriodID = lDisplayPeriod; else l_PeriodID = 0;
                            }

                            Dictionary<int, double> Availabilities;
                            if (ResourceAvailabilities.TryGetValue(lWresID, out Availabilities))
                            {
                                if (l_PeriodID >= RVClass.FromPeriodID && l_PeriodID <= RVClass.ToPeriodID)
                                    Availabilities[l_PeriodID] -= dHours;
                            }
                        }
                        reader.Close();
                    }

                    // read the period array for each resource and add entries to ResourceValues class
                    sErrorInfo = "m062";
                    foreach (KeyValuePair<int, Dictionary<int, double>> periodavailabilities in ResourceAvailabilities)
                    {
                        int lWresId = periodavailabilities.Key;
                        foreach (KeyValuePair<int, double> availability in periodavailabilities.Value)
                        {
                            if (!(availability.Value == 0))
                            {
                                double offHours = ResourceOffHours[lWresId][availability.Key];
                                oResAvail = new ResourceValues.clsResAvail();
                                oResAvail.WResID = lWresId;
                                oResAvail.PeriodID = availability.Key;
                                oResAvail.Hours = availability.Value - offHours;
                                ResourceValues.clsResCap oResData;
                                if (RVClass.Resources.TryGetValue(oResAvail.WResID, out oResData))
                                {
                                    oResAvail.FTES = GetFTEValue(clnFTEs, oResData.BC_UID_Role, oResAvail.Hours, oResAvail.PeriodID, offHours);
                                }
                                RVClass.ResAvail.Add(oResAvail);
                            }
                        }
                    }
                }
            //   ************************ end of section to get AVAILABILITY


            Wrapup:
                // Read Target Color info from BUDSPEC_BAND
                sErrorInfo = "p001";
                RVClass.TargetColors = new Dictionary<int, ResourceValues.clsViewTargetColours>();
                ResourceValues.clsViewTargetColours oTargetColour;

                oCommand = new SqlCommand("EPG_SP_ReadTargetColors", _dba.Connection);
                oCommand.Parameters.AddWithValue("BDUID", 0);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    oTargetColour = new ResourceValues.clsViewTargetColours();
                    oTargetColour.ID = DBAccess.ReadIntValue(reader["BAND_ID"]);
                    oTargetColour.low_val = DBAccess.ReadIntValue(reader["BAND_BOT"]);
                    oTargetColour.high_val = DBAccess.ReadIntValue(reader["BAND_TOP"]);
                    oTargetColour.rgb_val = DBAccess.ReadIntValue(reader["BAND_BACKCOLOR"]);
                    oTargetColour.Desc = DBAccess.ReadStringValue(reader["BAND_NAME"]);
                    RVClass.TargetColors.Add(oTargetColour.ID, oTargetColour);
                }
                reader.Close();
                sResult = "Data Grab Complete";
            }
            catch (Exception ex)
            {
                sResult = "Get Data for Analyzer exception at code = " + sErrorInfo; // +"  " + ex.Message;  using ex.Message here results in runtime error - don't know why
                eStatus = _dba.HandleException("GetPIResourcesStruct", (StatusEnum)9999, ex);
                sReplyXML = "";
                return (int)StatusEnum.rsRequestInvalid;
            }

            sReplyXML = RVClass.XML();
            sResult = "";
            return (int)eStatus;

        Error_Return:
            if (eStatus == StatusEnum.rsRequestIncomplete)
            {
                sResult = sErrorInfo;
            }
            else
            {
                sResult = "Get Data for Analyzer failed with error code = " + sErrorInfo;
            }
            sReplyXML = "";
            return (int)eStatus;
        }

        private static void SetParentUIDs(Dictionary<int, ResourceValues.clsCatItem> costcategories, int lMaxLevel)
        {
            int[] ParentUIDs = new int[lMaxLevel + 1];
            foreach (KeyValuePair<int, ResourceValues.clsCatItem> costcategoryentry in costcategories)
            {
                ResourceValues.clsCatItem costcategory = costcategoryentry.Value;
                ParentUIDs[costcategory.Level] = costcategory.UID;
                if (costcategory.Level > 1) costcategory.PID = ParentUIDs[costcategory.Level - 1];
            }

        }

        private static void AddCustomField(List<string> customfields, int lFieldID, int lFieldType, SqlDataReader reader, string sFieldName)
        {
            switch (lFieldType)
            {
                case 1:
                    DateTime dt = DBAccess.ReadDateValue(reader[sFieldName]);
                    customfields.Add(lFieldID.ToString() + " " + dt.ToString("yyyyMMddHHmm"));
                    break;
                case 2:
                case 4:
                case 13:
                    customfields.Add(lFieldID.ToString() + " " + DBAccess.ReadIntValue(reader[sFieldName]).ToString());
                    break;
                case 3:
                case 8:
                    customfields.Add(lFieldID.ToString() + " " + DBAccess.ReadDoubleValue(reader[sFieldName]).ToString());
                    break;
                case 9:
                    string s = DBAccess.ReadStringValue(reader[sFieldName]);
                    customfields.Add(lFieldID.ToString() + " " + s.Length.ToString() + " " + s);
                    break;
            }

        }

        private static StatusEnum AddCustomFieldLookup(DBAccess dba, Dictionary<int, ResourceValues.clsLookupList> Lookups, int lFieldID, int lLookupID)
        {
            SqlCommand oCommand;
            SqlDataReader reader;

            StatusEnum eStatus = StatusEnum.rsSuccess;

            if (lLookupID <= 0)
            {
                //  get the lookupID
                oCommand = new SqlCommand("EPG_SP_ReadFieldInfo", dba.Connection);
                oCommand.Parameters.AddWithValue("FieldID", lFieldID);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;

                reader = oCommand.ExecuteReader();
                if (reader.Read())
                {
                    lLookupID = DBAccess.ReadIntValue(reader["FA_LOOKUP_UID"]);
                }
                reader.Close();
            }

            if (lLookupID > 0)
            {
                ResourceValues.clsLookupList oLookupList = new ResourceValues.clsLookupList();
                oLookupList.FieldID = lFieldID;
                ResourceValues.clsListItem oListItem;
                oLookupList.ListItems = new Dictionary<int, ResourceValues.clsListItem>();

                oCommand = new SqlCommand("EPG_SP_ReadListItems", dba.Connection);
                oCommand.Parameters.AddWithValue("LookupUID", lLookupID);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;

                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    oListItem = new ResourceValues.clsListItem();
                    oListItem.UID = DBAccess.ReadIntValue(reader["LV_UID"]);
                    oListItem.ID = DBAccess.ReadIntValue(reader["LV_ID"]);
                    oListItem.Level = DBAccess.ReadIntValue(reader["LV_LEVEL"]);
                    oListItem.Inactive = (DBAccess.ReadIntValue(reader["LV_INACTIVE"]) != 0);
                    oListItem.Name = reader["LV_VALUE"].ToString();

                    oLookupList.ListItems.Add(oListItem.UID, oListItem);
                }
                reader.Close();
                Lookups.Add(lFieldID, oLookupList);
            }


            return eStatus;
        }

        private static string MakeListFromCollection(List<int> uids)
        {
            string s = "";
            if (uids != null)
            {
                foreach (int uid in uids)
                {
                    if (s.Length < 1) { s = uid.ToString(); }
                    else { s = s + "," + uid.ToString(); }
                }
            }
            return s;
        }

        private static void RemovePlanRowsWOHours(Dictionary<int, ResourceValues.clsCommitment> oCommitments)
        {
            if (oCommitments != null)
            {
                List<int> delList = new List<int>();
                foreach (KeyValuePair<int, ResourceValues.clsCommitment> oCommitmentKeyValue in oCommitments)
                {
                    //int iKey = oCommitmentKeyValue.Key;
                    if (oCommitmentKeyValue.Value.HoursInWindow == 0) { delList.Add(oCommitmentKeyValue.Key); }
                }
                foreach (int delKey in delList)
                {
                    oCommitments.Remove(delKey);
                }
            }
        }

        private static int MapToPeriod(Dictionary<int, ResourceValues.CPeriod> clnPeriods, DateTime dtWorkDate)
        {
            int lRetPeriod = 0;
            foreach (KeyValuePair<int, ResourceValues.CPeriod> oPeriod in clnPeriods)
            {
                if (dtWorkDate >= oPeriod.Value.StartDate && dtWorkDate <= oPeriod.Value.FinishDate)
                {
                    lRetPeriod = oPeriod.Value.PeriodID;
                    break;
                }
            }

            return lRetPeriod;
        }

        private static int GetBCUID(Dictionary<int, int> clnXrefs, int lWResID)
        {
            int lXRef = 0;
            if (!clnXrefs.TryGetValue(lWResID, out lXRef)) { lXRef = 0; }
            return lXRef;
        }

        private static int GetFTEValue(Dictionary<int, Dictionary<int, int>> clnFTEs, int lBC_UID, double dblHours, int lPeriodID, double dblOffHours)
        {
            int lFTEValue = 0;
            double dblFTE = -1;
            Dictionary<int, int> clnFTEPeriods;
            clnFTEs.TryGetValue(lBC_UID, out clnFTEPeriods);
            if (clnFTEPeriods != null) { if (!clnFTEPeriods.TryGetValue(lPeriodID, out lFTEValue)) { lFTEValue = 0; }; }
            if (lFTEValue > 0) { dblFTE = (dblHours * 1000000) / (lFTEValue - (dblOffHours * 100)); }
            return (int)dblFTE;
        }

        // jwg - 5/4/12 need to somehow stash the FTE conv factors into resource vals to allow rows to be dragged and convert the data correctly

        private static int GetFTEConv(Dictionary<int, Dictionary<int, int>> clnFTEs, int lBC_UID, int lPeriodID)
        {
            int lFTEValue = 0;
            Dictionary<int, int> clnFTEPeriods;
            clnFTEs.TryGetValue(lBC_UID, out clnFTEPeriods);
            if (clnFTEPeriods != null) { if (!clnFTEPeriods.TryGetValue(lPeriodID, out lFTEValue)) { lFTEValue = 0; }; }
            return lFTEValue;
        }
    }

    public class EPKClass01
    {

        public static int GetEntityID(int iTable)
        {
            EntityID nEntity;
            CustomFieldDBTable nTable = (CustomFieldDBTable)iTable;
            if (nTable >= CustomFieldDBTable.ResourceINT && nTable <= CustomFieldDBTable.ResourceMV)
                nEntity = EntityID.Resource;
            else if (nTable >= CustomFieldDBTable.PortfolioINT && nTable <= CustomFieldDBTable.PortfolioDATE)
                nEntity = EntityID.Portfolio;
            else if (nTable == CustomFieldDBTable.Program)
                nEntity = EntityID.Program;
            else if (nTable >= CustomFieldDBTable.ProjectINT && nTable <= CustomFieldDBTable.ProjectDATE)
                nEntity = EntityID.Project;
            else if (nTable >= CustomFieldDBTable.TaskWIINT && nTable <= CustomFieldDBTable.TaskWIDEC)
                nEntity = EntityID.Task;
            else
                nEntity = EntityID.Unknown;
            int iEntity = (Int32)nEntity;
            return iEntity;
        }

        public static string GetEntity(int iEntity)
        {
            string sEntity = "";
            EntityID nEntity = (EntityID)iEntity;

            if (nEntity == EntityID.Resource)
                sEntity = "Resource";
            else if (nEntity == EntityID.Portfolio)
                sEntity = "Portfolio";
            else if (nEntity == EntityID.Program)
                sEntity = "Program";
            else if (nEntity == EntityID.Project)
                sEntity = "Project";
            else if (nEntity == EntityID.Task)
                sEntity = "Task";
            else
                sEntity = "Unknown";
            return sEntity;
        }
        //public static string GetDataType(int iFieldType)
        //{
        //    string sDataType = "";
        //    FieldType nFieldType = (FieldType)iFieldType;

        //    switch (nFieldType)
        //    {
        //        case FieldType.TypeCost:
        //            sDataType = "Cost";
        //            break;
        //        case FieldType.TypeCode:
        //            sDataType = "Code";
        //            break;
        //        case FieldType.TypeDate:
        //            sDataType = "Date";
        //            break;
        //        case FieldType.TypeFlag:
        //            sDataType = "Flag";
        //            break;
        //        case FieldType.TypeNumber:
        //            sDataType = "Number";
        //            break;
        //        case FieldType.TypeText:
        //            sDataType = "Text";
        //            break;
        //        case FieldType.TypeNText:
        //            sDataType = "RTF";
        //            break;
        //        default:
        //            sDataType = "Unknown";
        //            break;

        //    }
        //    return sDataType;
        //}

        public static string GetFieldFormat(int iDataType, out bool bIsDeprecated)
        {
            string sdatatype = "";
            bIsDeprecated = false;
            FieldType nDataType = (FieldType)iDataType;
            switch (nDataType)
            {
                case FieldType.TypeCost:
                    sdatatype = "Cost";
                    break;
                case FieldType.TypeCode:
                    sdatatype = "Code (Deprecated)";
                    bIsDeprecated = true;
                    break;
                case FieldType.TypeMVCode:
                    sdatatype = "MV Code (Deprecated)";
                    bIsDeprecated = true;
                    break;
                case FieldType.TypeFlag:
                    sdatatype = "Flag";
                    break;
                case FieldType.TypeText:
                    sdatatype = "Text";
                    break;
                case FieldType.TypeNumber:
                    sdatatype = "Number";
                    break;
                case FieldType.TypeDate:
                    sdatatype = "Date";
                    break;
                case FieldType.TypeNText:
                    sdatatype = "NText";
                    break;
                default:
                    sdatatype = "Unknown Type";
                    break;
            }
            return sdatatype;
        }

        public static bool GetTableAndField(int iTable, int iField, out string sTable, out string sField)
        {
            bool bFound = true;
            string stable = "";
            string sfield = "";
            CustomFieldDBTable nTable = (CustomFieldDBTable)iTable;
            switch (nTable)
            {
                case CustomFieldDBTable.ResourceINT:
                    stable = "EPGC_RESOURCE_INT_VALUES";
                    sfield = "RI_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldDBTable.ResourceTEXT:
                    stable = "EPGC_RESOURCE_TEXT_VALUES";
                    sfield = "RT_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldDBTable.ResourceDEC:
                    stable = "EPGC_RESOURCE_DEC_VALUES";
                    sfield = "RC_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldDBTable.ResourceNTEXT:
                    stable = "EPGC_RESOURCE_NTEXT_VALUES";
                    sfield = "RN_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldDBTable.ResourceDATE:
                    stable = "EPGC_RESOURCE_DATE_VALUES";
                    sfield = "RD_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldDBTable.ResourceMV:
                    stable = "EPGC_RESOURCE_MV_VALUES";
                    sfield = "MVR_UID";
                    break;
                case CustomFieldDBTable.PortfolioINT:
                    stable = "EPGP_PROJECT_INT_VALUES";
                    sfield = "PI_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldDBTable.PortfolioTEXT:
                    stable = "EPGP_PROJECT_TEXT_VALUES";
                    sfield = "PT_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldDBTable.PortfolioDEC:
                    stable = "EPGP_PROJECT_DEC_VALUES";
                    sfield = "PC_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldDBTable.PortfolioNTEXT:
                    stable = "EPGP_PROJECT_NTEXT_VALUES";
                    sfield = "PN_" + String.Format("{0:d3}", iField);
                    break;
                case CustomFieldDBTable.PortfolioDATE:
                    stable = "EPGP_PROJECT_DATE_VALUES";
                    sfield = "PD_" + String.Format("{0:d3}", iField);
                    break;
                default:
                    stable = "Unknown Table";
                    sfield = "";
                    bFound = false;
                    break;
            }

            sTable = stable;
            sField = sfield;
            return bFound;
        }

        public static int GetTableID(int iEntity, int iDataType)
        {
            CustomFieldDBTable nTable = 0;
            FieldType nDataType = (FieldType)iDataType;
            EntityID nEntity = (EntityID)iEntity;

            switch (nEntity)
            {
                case EntityID.Resource:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                        case FieldType.TypeCost:
                            nTable = CustomFieldDBTable.ResourceDEC;
                            break;
                        case FieldType.TypeDate:
                            nTable = CustomFieldDBTable.ResourceDATE;
                            break;
                        case FieldType.TypeCode:
                        case FieldType.TypeFlag:
                            nTable = CustomFieldDBTable.ResourceINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldDBTable.ResourceTEXT;
                            break;
                        case FieldType.TypeMVCode:
                            nTable = CustomFieldDBTable.ResourceMV;
                            break;
                    }
                    break;
                case EntityID.Portfolio:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                        case FieldType.TypeCost:
                            nTable = CustomFieldDBTable.PortfolioDEC;
                            break;
                        case FieldType.TypeDate:
                            nTable = CustomFieldDBTable.PortfolioDATE;
                            break;
                        case FieldType.TypeCode:
                        case FieldType.TypeFlag:
                            nTable = CustomFieldDBTable.PortfolioINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldDBTable.PortfolioTEXT;
                            break;
                        case FieldType.TypeNText:
                            nTable = CustomFieldDBTable.PortfolioNTEXT;
                            break;
                    }
                    break;
                case EntityID.Program:
                    nTable = CustomFieldDBTable.Program;
                    break;
                case EntityID.Project:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                        case FieldType.TypeCost:
                            nTable = CustomFieldDBTable.ProjectDEC;
                            break;
                        case FieldType.TypeDate:
                            nTable = CustomFieldDBTable.ProjectDATE;
                            break;
                        case FieldType.TypeCode:
                        case FieldType.TypeFlag:
                            nTable = CustomFieldDBTable.ProjectINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldDBTable.ProjectTEXT;
                            break;
                        case FieldType.TypeNText:
                            nTable = CustomFieldDBTable.ProjectNTEXT;
                            break;
                    }
                    break;
                case EntityID.Task:
                    switch (nDataType)
                    {
                        case FieldType.TypeNumber:
                            nTable = CustomFieldDBTable.TaskWIDEC;
                            break;
                        case FieldType.TypeFlag:
                            nTable = CustomFieldDBTable.TaskWIINT;
                            break;
                        case FieldType.TypeText:
                            nTable = CustomFieldDBTable.TaskWITEXT;
                            break;
                    }
                    break;
                default:
                    nTable = CustomFieldDBTable.Unknown;
                    break;
            }
            return (int)nTable;
        }

    }

    internal class EPKLookupValue
    {
        public int Id;
        public int UID;
        public string Name;
        public string FullName;
        public int Level;
        public string ExtID;
        public int InActive;
        public bool IsSummary;
        public bool IsFlagged;

        public EPKLookupValue()
        {
            IsFlagged = false;
        }
    }
    internal class EPKLookup
    {
        public int UID;
        public string Name;
        public string Desc;
        public List<EPKLookupValue> Values;
        public SortedList<int, EPKLookupValue> IndexedValues;

        public EPKLookup()
        {
            Values = new List<EPKLookupValue>();
        }

        public bool SetFullNames()
        {
            int iMaxLevel = 10;
            List<string> ParentNodes = new List<string>(iMaxLevel + 1);
            for (int i = 1; i <= iMaxLevel + 1; i++) ParentNodes.Add("");  // need to initialize list to contain entries I want to use

            foreach (EPKLookupValue value in Values)
            {
                string sfullName = "";
                for (int i = 1; i < value.Level; i++)
                {
                    if (sfullName.Length < 1) sfullName = ParentNodes[i]; else sfullName = sfullName + "." + ParentNodes[i];
                }
                if (sfullName.Length < 1) value.FullName = value.Name; else value.FullName = sfullName + "." + value.Name;
                if (value.FullName.Length > 250) value.FullName = value.FullName.Substring(0, 249) + "...";
                ParentNodes[value.Level] = value.Name;
            }
            return true;
        }

        public void CreateIndexedValues()
        {
            IndexedValues = new SortedList<int, EPKLookupValue>();
            int UIDwhenZero = 999999;

            foreach (EPKLookupValue value in Values)
            {
                if (value.UID > 0)
                {
                    IndexedValues.Add(value.UID, value);
                }
                else
                {
                    UIDwhenZero = UIDwhenZero + 1;
                    IndexedValues.Add(UIDwhenZero, value);
                }
            }
        }

    }

    public class ComponentWeight
    {
        public int ScenarioId;
        public int ComponentId;
        public double Weight;
    }

    public class EPKPriFormula
    {
        public int uid;
        public string name;
        public List<ComponentWeight> components;

        public EPKPriFormula()
        {
            components = new List<ComponentWeight>();
        }
    }
}
