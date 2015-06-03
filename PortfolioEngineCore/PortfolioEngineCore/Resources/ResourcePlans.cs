using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace PortfolioEngineCore
{
    public class ResourcePlans : PFEBase
    {
        private enum RPDisplayModeEnum
        {
            ProjectManager,
            ResourceManager
        }
        public ResourcePlans(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading ResourcePlans Class");
        }

        public ResourcePlans(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading ResourcePlans Class");
        }

        public bool HandleRequest(string sRequest, out string sReply)
        {
            // there are two reply formats:
            // e.g.
            // WorkEngine : <Result Status="1"><Error ID="100"><![CDATA[" + ex.Message + "]]></Error></Result>
            // Treegrid   : <Grid><IO Result="-11" Message="" /></Grid>
            //
            // I want to use something like:
            //              <Execute Function="GetCostCategoryRoles" />
            // Let's try:
            // <Result Status="0" Function="GetCostCategoryRoles"> + filling + </Result>
            // where filling can be:
            // if status != 0               <Error ID="100"><![CDATA[" + ex.Message + "]]></Error>
            // or if using treegrid         <Grid><IO Result="-11" Message="" /></Grid>
            // or just call specific xml if no error
            sReply = "";
            string sFunction = "HandleRequest";
            try
            {
                if (_dba.Open() != StatusEnum.rsSuccess)
                    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    sFunction = xExecute.GetStringAttr("Function");
                    switch (sFunction)
                    {
                        case "AddNote":
                            return AddNote(sRequest, out sReply);
                        case "DeleteResourcePlanView":
                            return DeleteResourcePlanView(sRequest, out sReply);
                        case "GetImportCostPlanHours":
                            return GetImportCostPlanHours(sRequest, out sReply);
                        case "GetImportWorkHours":
                            return GetImportWorkHours(sRequest, out sReply);
                        case "GetPIList":
                            return GetPIList(sRequest, out sReply);
                        case "GetMetaData":
                            return GetMetaData(sRequest, out sReply);
                        //case "GetCostCategoryRoles":
                        //    return GetCostCategoryRoles(sRequest, out sReply);
                        //case "GetResourcePlanViews":
                        //    return GetResourcePlanViews(sRequest, out sReply);
                        case "GetPlanResources":
                            return GetPlanResources(sRequest, out sReply);
                        case "GetPlanRowNotes":
                            return GetPlanRowNotes(sRequest, out sReply);
                        case "GetRowEvents":
                            return GetRowEvents(sRequest, out sReply);
                        case "GetResourcePlan":
                            return GetResourcePlan(sRequest, out sReply);
                        case "GetRowNote":
                            return GetRowNote(sRequest, out sReply);
                        case "GetPlanResourceWork":
                            return GetResourcePlanWork(sRequest, out sReply);
                        case "PostCostValues":
                            return PostCostValues(sRequest, out sReply);
                        case "ReadCalendarCosttypeCombinations":
                            return ReadCalendarCosttypeCombinations(sRequest, out sReply);
                        case "SaveResourcePlan":
                            return SaveResourcePlan(sRequest, out sReply);
                        case "SaveResourcePlanView":
                            return SaveResourcePlanView(sRequest, out sReply);
                        case "SaveRowNote":
                            return SaveRowNote(sRequest, out sReply);
                    }
                }
                else
                {
                    sReply = HandleError("HandleRequest", Status, FormatErrorText());
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException(sFunction, 99999, ex);
            }
            finally { _dba.Close(); }
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private bool GetPIList(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                int nStatus = 0;
                string sStatus = "";
                CStruct xExecute = new CStruct();
                CStruct xPIs = new CStruct();
                xPIs.Initialize("PIs");
                if (xExecute.LoadXML(sRequest) == true)
                {
                    string sProjectIDs = "";
                    bool bSuperPIM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperPIM);
                    bool bSuperRM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperRM);

                    string sCommand = "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID IS NOT NULL OR PROJECT_EXT_UID <> '' ORDER BY PROJECT_NAME";
                    SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection);
                    SqlDataReader reader = null;
                    reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        CStruct xPI = xPIs.CreateSubStruct("PI");
                        int lUID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                        if (sProjectIDs == "")
                            sProjectIDs = lUID.ToString();
                        else
                            sProjectIDs += "," + lUID.ToString();
                        string wepid = DBAccess.ReadStringValue(reader["PROJECT_EXT_UID"]);
                        xPI.CreateIntAttr("id", lUID);
                        xPI.CreateStringAttr("wepid", wepid);
                        xPI.CreateStringAttr("name", DBAccess.ReadStringValue(reader["PROJECT_NAME"]));
                    }
                    reader.Close();
                    reader = null;

                    if (bSuperPIM == false)
                    {
                        xPIs = new CStruct();
                        xPIs.Initialize("PIs");

                        sCommand = "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS" +
                       " LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4 AND SURR_CONTEXT_VALUE = PROJECT_ID" +
                       " WHERE PROJECT_MARKED_DELETION = 0 AND (PROJECT_MANAGER = " + _userWResID.ToString("0") + " OR SU.SURR_WRES_ID = " + _userWResID.ToString("0") + ")" +
                       " AND PROJECT_ID in (" + sProjectIDs + ")  ORDER BY PROJECT_NAME";

                        oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                        reader = oCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            CStruct xPI = xPIs.CreateSubStruct("PI");
                            int lUID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                            string wepid = DBAccess.ReadStringValue(reader["PROJECT_EXT_UID"]);
                            xPI.CreateIntAttr("id", lUID);
                            xPI.CreateStringAttr("wepid", wepid);
                            xPI.CreateStringAttr("name", DBAccess.ReadStringValue(reader["PROJECT_NAME"]));
                        }
                        reader.Close();
                    }
                    //{
                    //    PortfolioItems.PortfolioItems pis = new PortfolioItems.PortfolioItems(_basepath, _username, _pid, _company, _dbcnstring, _debug);
                    //    string sExtIDList;
                    //    string sPIDList;
                    //    string sXML;
                    //    pis.ObtainManagedPortfolioItems(out sExtIDList, out sPIDList, out sXML);
                    //}
                }

                CStruct xResult = BuildResultStruct("GetPIList", nStatus, sStatus);
                if (nStatus == 0)
                {
                    xResult.AppendSubStruct(xPIs);
                }
                sReply = xResult.XML();
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetPIList", 99999, ex);
            }

            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            if (bResult == false)
            {
                sReply = HandleError("GetPIList", Status, FormatErrorText());
            }
            return bResult;
        }

        private bool GetMetaData(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                int nStatus = 0;
                string sStatus = "";
                if (Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpResourcePlan) == false)
                {
                    nStatus = (int) StatusEnum.rsSecurityAccessDenied;
                    sStatus = "You do not have permission to view resource plan";
                }
                else
                {
                    SqlCommand oCommand;
                    SqlDataReader reader;
                    string sCommand;
                    CStruct xExecute = new CStruct();
                    if (xExecute.LoadXML(sRequest) == true)
                    {
                        string sWEPID = xExecute.GetString("Wepid");
                        string sTicket = xExecute.GetString("TicketVal");
                        bool bIsResource = xExecute.GetBoolean("IsResource", false);
                        string sTicketInfo = "";
                        string sProjectIDs = "";
                        if (sTicket != string.Empty)
                        {
                            if (ReadTicketString(sTicket, out sTicketInfo) == false) goto Exit_Function;
                        }
                        else if (sWEPID != string.Empty)
                        {
                            int lProjectID;
                            if (DBCommon.SelectProjectIDByExtUID(_dba, sWEPID, out lProjectID) != StatusEnum.rsSuccess) goto Exit_Function;
                            sProjectIDs = lProjectID.ToString("0");
                            bIsResource = false;
                        }
                        if (bIsResource)
                        {
                            bool bSuperRM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperRM);
                            if (bSuperRM == false)
                            {
                                string sResourceUIDs = sTicketInfo;
                                string sResManagerDeptUIDs = "";
                                oCommand = new SqlCommand("EPG_SP_ReadManagerResDeptsB", _dba.Connection);
                                oCommand.CommandType = CommandType.StoredProcedure;
                                oCommand.Parameters.Add("ApproverWResID", SqlDbType.Int).Value = _userWResID;
                                reader = oCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    Common.AddIDToList(ref sResManagerDeptUIDs, DBAccess.ReadIntValue(reader["DeptUID"]));
                                }
                                reader.Close();
                                string sInvalidResources = "";
                                int nInvalidCount = 0;
                                string[] items = sResourceUIDs.Split(',');
                                int nCount = items.Length;
                                if (sResourceUIDs != "" && sResManagerDeptUIDs != "")
                                {
                                    //sCommand = "SELECT WRES_ID, RES_NAME FROM EPG_RESOURCES WHERE WRES_RP_DEPT IN (" + sResManagerDeptUIDs + ")";
                                    sCommand = "SELECT WRES_ID, RES_NAME, WRES_RP_DEPT FROM EPG_RESOURCES" +
                                               "  JOIN dbo.EPG_FN_ConvertListToTable(N'" + sResourceUIDs + "')" + 
                                               "    LT on (WRES_ID = LT.TokenVal AND WRES_RP_DEPT IS NOT NULL)" +
                                               " WHERE WRES_RP_DEPT NOT IN (" + sResManagerDeptUIDs + ")";
                                    oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                                    reader = oCommand.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                                        if (Common.IsIDInList(sResourceUIDs, lWResID) == true)
                                        {
                                            nInvalidCount++;
                                        }
                                        sInvalidResources += "\n" + DBAccess.ReadStringValue(reader["RES_NAME"]);
                                    }
                                    reader.Close();
                                    if (sInvalidResources != "")
                                    {
                                        sStatus = "You do not have permission to view resource plan for resource(s):\n" + sInvalidResources;
                                    }
                                    if (nInvalidCount >= nCount)
                                        nStatus = (int)StatusEnum.rsSecurityNoResources;
                                }
                                else
                                {
                                    nStatus = (int)StatusEnum.rsSecurityNoResources;
                                    sStatus = "You do not have permission to view resource plan for any resources";
                                }
                            }
                        }
                        else
                        {
                            if (sProjectIDs == string.Empty)
                            {
                                // convert wepids list to projectid list
                                sCommand =
                                    "SELECT PROJECT_ID FROM EPGP_PROJECTS JOIN dbo.EPG_FN_ConvertWEPIDToTable(N'" +
                                    sTicketInfo + "') LT on PROJECT_EXT_UID=LT.TokenVal";

                                oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                                reader = oCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    Common.AddIDToList(ref sProjectIDs, DBAccess.ReadIntValue(reader["PROJECT_ID"]));
                                }
                                reader.Close();
                            }
                            if (sProjectIDs == string.Empty)
                            {
                                sStatus = "None of the selected projects have valid WEPIDS";
                                nStatus = (int)StatusEnum.rsSecurityNoProjects;
                            }
                            else
                            {
                                bool bSuperPIM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperPIM);
                                if (bSuperPIM == false)
                                {
                                    // get list of projects user can manage from the selected list
                                    string sValidProjects = "";
                                    int nValidCount = 0;
                                    sCommand = "SELECT PROJECT_ID, PROJECT_NAME" +
                                               " FROM EPGP_PROJECTS" +
                                               " LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4" +
                                               " AND SURR_CONTEXT_VALUE = PROJECT_ID" +
                                               " WHERE PROJECT_MARKED_DELETION = 0" +
                                               " AND (PROJECT_MANAGER = " +
                                               _userWResID.ToString("0") +
                                               " OR SU.SURR_WRES_ID = " +
                                               _userWResID.ToString("0") + ")" +
                                               " AND PROJECT_ID in (" + sProjectIDs + ")";
                                    oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                                    reader = oCommand.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        int lProjectID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                                        Common.AddIDToList(ref sValidProjects, lProjectID);
                                        nValidCount++;
                                    }
                                    reader.Close();

                                    if (nValidCount == 0)
                                    {
                                        sStatus = "You do not have permission to view the selected project(s)";
                                        nStatus = (int) StatusEnum.rsSecurityNoProjects;
                                    }
                                    else
                                    {
                                        string sInvalidProjectIDs = "";
                                        while (sProjectIDs != "")
                                        {
                                            int lProjectID = Common.GetFirstIDFromList(ref sProjectIDs);
                                            if (Common.IsIDInList(sValidProjects, lProjectID) == false)
                                            {
                                                Common.AddIDToList(ref sInvalidProjectIDs, lProjectID);
                                            }
                                        }
                                        if (sInvalidProjectIDs != "")
                                        {
                                            sCommand = "SELECT PROJECT_ID, PROJECT_NAME" +
                                                       " FROM EPGP_PROJECTS" +
                                                       " WHERE PROJECT_ID in (" + sInvalidProjectIDs + ")";

                                            oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);

                                            string sInvalidProjects = "";
                                            reader = oCommand.ExecuteReader();
                                            while (reader.Read())
                                            {
                                                sInvalidProjects += "\n" + DBAccess.ReadStringValue(reader["PROJECT_NAME"]);
                                            }
                                            reader.Close();
                                            sStatus =
                                                "You do not have permission to view resource plan for project(s):\n" +
                                                sInvalidProjects;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                CStruct xResult = BuildResultStruct("GetMetaData", nStatus, sStatus);
                if (nStatus == 0)
                {
                    // reply holds data to support RPE such as CCRoles, Views and negotiation mode
                    CAdmin oAdmin = new CAdmin();
                    if (oAdmin.GetAdminInfo(_dba) != StatusEnum.rsSuccess)
                        goto Exit_Function;

                    CStruct xCostCategoryRoles;
                    if (
                        DBCommon.GetCostCategoryRolesStruct(_dba, oAdmin.PortfolioCommitmentsCalendarUID, 1,
                                                            out xCostCategoryRoles) != StatusEnum.rsSuccess)
                        goto Exit_Function;

                    CStruct xPlanViews;
                    if (GetResourcePlanViewsXML(out xPlanViews) == false)
                        goto Exit_Function;

                    xResult.CreateBoolean("NegotiationMode", (oAdmin.PortfolioCommitmentsOpMode == 0));
                    xResult.AppendSubStruct(xCostCategoryRoles);
                    xResult.AppendSubStruct(xPlanViews);
                }
                sReply = xResult.XML();
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetMetaData", 99999, ex);
            }
        Exit_Function:
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            if (bResult == false)
            {
                sReply = HandleError("GetMetaData", Status, FormatErrorText());
            }
            return bResult;
        }

        //private bool GetCostCategoryRoles(string sRequest, out string sReply)
        //{
        //    bool bResult = false;
        //    // <Result Status="0" Function="GetCostCategoryRoles"> + filling + </Result>
        //    // where filling can be:
        //    // if status != 0               <Error ID="100"><![CDATA[" + ex.Message + "]]></Error>
        //    // or if using treegrid         <Grid><IO Result="-11" Message="" /></Grid>
        //    // or just call specific xml if no error
        //    sReply = "";
        //    try
        //    {
        //        CAdmin oAdmin = new CAdmin();
        //        if (oAdmin.GetAdminInfo(_dba) != StatusEnum.rsSuccess)
        //            goto Exit_Function;
        //        CStruct xCostCategoryRoles;
        //        if (DBCommon.GetCostCategoryRolesStruct(_dba, oAdmin.PortfolioCommitmentsCalendarUID, 1, out xCostCategoryRoles) != StatusEnum.rsSuccess)
        //            goto Exit_Function;
        //        CStruct xResult = BuildResultStruct("GetCostCategoryRoles");
        //        xResult.AppendSubStruct(xCostCategoryRoles);
        //        sReply = xResult.XML();
        //    }
        //    catch (Exception ex)
        //    {
        //        sReply = HandleException("GetCostCategoryRoles", 99999, ex);
        //    }
        //Exit_Function:
        //    bResult = (_dba.Status == StatusEnum.rsSuccess);
        //    if (bResult == false)
        //    {
        //        sReply = HandleError("GetCostCategoryRoles", Status, FormatErrorText());
        //    }
        //    return bResult;
        //}

        //private bool GetResourcePlanViews(string sRequest, out string sReply)
        //{
        //    bool bResult = false;
        //    sReply = "";
        //    try
        //    {
        //        CStruct xPlanViews;
        //        if (GetResourcePlanViewsXML(out xPlanViews) == true)
        //        {
        //            CStruct xResult = BuildResultStruct("GetResourcePlanViews");
        //            xResult.AppendSubStruct(xPlanViews);
        //            sReply = xResult.XML();
        //        }
        //        else
        //        {
        //            sReply = HandleError("GetResourcePlanViews", Status, FormatErrorText());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sReply = HandleException("GetResourcePlanViews", 99999, ex);
        //    }

        //    bResult = (_dba.Status == StatusEnum.rsSuccess);
        //    if (bResult == false)
        //    {
        //        sReply = HandleError("GetResourcePlanViews", Status, FormatErrorText());
        //    }
        //    return bResult;
        //}

        private bool GetResourcePlan(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    //sbDataxml.append('<Execute Function="GetResourcePlan">');
                    //sbDataxml.append('<Wepid>' + this.params.WEPID + '</Wepid>');
                    //sbDataxml.append('<TicketVal>' + this.params.TicketVal + '</TicketVal>');
                    //sbDataxml.append('<IsResource>' + this.params.IsResource + '</IsResource>');
                    //sbDataxml.append('</Execute>');
                    CStruct xRPE;
                    if (GetResourcePlanStruct(xExecute, out xRPE) != true)
                        goto Exit_Function;

                    if (xRPE != null)
                    {
                        CStruct xGrid;
                        //string sDebug = xRPE.XML();
                        RPEditorData.BuildResourcePlanGridXML(xRPE, out xGrid);
                        //xGrid.AppendXML("<IO Result=\"0\" Message=\"hello john gotta new mota\" />");
                        CStruct xResult = BuildResultStruct("GetResourcePlan");
                        xResult.AppendSubStruct(xGrid);
                        sReply = xResult.XML();
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetResourcePlan", 99999, ex);
            }
        Exit_Function:
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            if (bResult == false)
            {
                sReply = HandleError("GetResourcePlan", Status, FormatErrorText());
            }
            return bResult;
        }

        private bool GetResourcePlanWork(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    string Wepid = xExecute.GetString("Wepid");
                    string sWResIDs = xExecute.GetString("WResIDs");

                    CAdmin oAdmin = new CAdmin();
                    if (oAdmin.GetAdminInfo(_dba) != StatusEnum.rsSuccess)
                        goto Exit_Function;

                    // Read in the PI Commitments calendar periods
                    List<CPeriod> clnPeriods;
                    if (GetPeriods(_dba, oAdmin.PortfolioCommitmentsCalendarUID, out clnPeriods) != StatusEnum.rsSuccess)
                        goto Exit_Function;

                    // Take into account the status date
                    int lStartPeriodID = 1;

                    int lProjectID;
                    if (DBCommon.SelectProjectIDByExtUID(_dba, Wepid, out lProjectID) == StatusEnum.rsSuccess)
                    {
                        CStruct xReply;
                        if (ResourceSelector.GetPIResourcesStruct(_dba, _userWResID, lProjectID.ToString("0"), sWResIDs, clnPeriods, oAdmin, lStartPeriodID, out xReply) != StatusEnum.rsSuccess)
                            goto Exit_Function;

                        sReply = RPEditorResources.BuildPlanResourcesGridXML(BuildResultStruct("GetResourcePlanWork"), xReply);
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetResourcePlanWork", 99999, ex);
            }
        Exit_Function:
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            if (bResult == false)
            {
                sReply = HandleError("GetResourcePlanWork", Status, FormatErrorText());
            }
            return bResult;
        }

        private bool ReadTicketString(string sTicket, out string sReply)
        {
            sReply = "";
            _dba.Status = StatusEnum.rsSuccess;
            bool bRet = false;
            try
            {
                Guid guid = new Guid(sTicket);
                const string sCommand = "SELECT DC_DATA FROM EPG_DATA_CACHE WHERE DC_TICKET = @DC_TICKET";

                SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.Parameters.AddWithValue("@DC_TICKET", guid);
                SqlDataReader reader = oCommand.ExecuteReader();
                if (reader.Read())
                {
                    sReply = DBAccess.ReadStringValue(reader["DC_DATA"]).Trim();
                    bRet = true;
                }
                else
                    _dba.HandleStatusError(SeverityEnum.Error, "ReadTicketString", StatusEnum.rsTicketNotFound,
                                            "Unable to read ticket data for " + DBAccess.PrepareText(sTicket));
                reader.Close();
            }
            catch (Exception ex)
            {
                _dba.HandleException("ReadTicketString", (StatusEnum)9999, ex);
            }
            return bRet;
        }

        private bool PostCostValues(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    int lProjectID = xExecute.GetInt("ProjectID");
                    bool bPublish = xExecute.GetBoolean("Publish");
                    bool bPublishBaseline = xExecute.GetBoolean("PublishBaseline");

                    PostCostValues(lProjectID.ToString("0"), bPublish, bPublishBaseline);
                    CStruct xResult = BuildResultStruct("PostCostValues");
                    xResult.AppendXML("<Grid><IO Result=\"0\"/></Grid>");
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("PostCostValues", 99999, ex);
            }
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private bool ReadCalendarCosttypeCombinations(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    int lProjectID = xExecute.GetInt("ProjectID");

                    CAdmin oAdmin = new CAdmin();
                    if (oAdmin.GetAdminInfo(_dba) != StatusEnum.rsSuccess)
                        goto Exit_Function;


                    SqlCommand oCommand = new SqlCommand("EPG_SP_ReadCostValueSetswRole", _dba.Connection);
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.Add("ProjectID", SqlDbType.Int).Value = lProjectID;
                    CStruct xCosttypes = new CStruct();
                    xCosttypes.Initialize("Costtypes");
                    SqlDataReader reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        int ctId = DBAccess.ReadIntValue(reader["CB_ID"]);
                        if (ctId == oAdmin.PortfolioCommitmentsCalendarUID)
                        {
                            CStruct xCosttype = xCosttypes.CreateSubStruct("Costtype");
                            xCosttype.CreateIntAttr("cbId", DBAccess.ReadIntValue(reader["CB_ID"]));
                            xCosttype.CreateIntAttr("ctId", DBAccess.ReadIntValue(reader["CT_ID"]));
                            xCosttype.CreateIntAttr("ctEditmode", DBAccess.ReadIntValue(reader["CT_EDIT_MODE"]));
                            xCosttype.CreateStringAttr("ctName", DBAccess.ReadStringValue(reader["CT_NAME"]));
                            xCosttype.CreateStringAttr("cbName", DBAccess.ReadStringValue(reader["CB_NAME"]));
                        }
                    }
                    reader.Close();
                    CStruct xResult = BuildResultStruct("ReadCalendarCosttypeCombinations");
                    xResult.AppendSubStruct(xCosttypes);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("ReadCalendarCosttypeCombinations", 99999, ex);
            }
        Exit_Function:
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private bool SaveResourcePlan(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    CStruct xGrid = xExecute.GetSubStruct("Grid");
                    if (SaveResourcePlanStruct(xGrid) == true)
                    {
                        CStruct xResult = BuildResultStruct("SaveResourcePlan");
                        xResult.AppendXML("<Grid><IO Result=\"0\"/></Grid>");
                        sReply = xResult.XML();
                    }
                    else
                    {
                        CStruct xResult = BuildResultStruct("SaveResourcePlan", (int)_dba.Status);
                        xGrid = xResult.CreateSubStruct("Grid");
                        CStruct xIO = xGrid.CreateSubStruct("IO");
                        xIO.CreateIntAttr("Result", -11);
                        if (_dba.Status == (StatusEnum)123456)
                        {
                            xIO.CreateStringAttr("Message", _dba.StatusText);
                        }
                        else
                        {
                            xIO.CreateStringAttr("Message", FormatErrorText());
                        }
                        sReply = xResult.XML();
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveResourcePlan", 99999, ex);
            }
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private bool AddNote(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    CStruct xNote = xExecute.GetSubStruct("Note");
                    Guid planrowGUID = xNote.GetGuidAttr("Planrow_GUID");
                    int lProjectID = xNote.GetIntAttr("Project_UID");

                    string to = xNote.GetString("To");
                    string title = xNote.GetString("Title");
                    string sHTML = xNote.GetString("HTML");
                    DateTime timestamp = xNote.GetDate("Timestamp");
                    const string sCommand = "INSERT INTO EPG_RPE_NOTES (RPEN_CMT_GUID,RPEN_PROJECT_ID,RPEN_TIMESTAMP,RPEN_WRES_ID,RPEN_TITLE,RPEN_HTML,RPEN_TO) VALUES(@RPEN_CMT_GUID,@RPEN_PROJECT_ID,@RPEN_TIMESTAMP,@RPEN_WRES_ID,@RPEN_TITLE,@RPEN_HTML,@RPEN_TO)";
                    SqlCommand cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    cmd.Parameters.AddWithValue("@RPEN_CMT_GUID", planrowGUID);
                    cmd.Parameters.AddWithValue("@RPEN_PROJECT_ID", lProjectID);
                    cmd.Parameters.AddWithValue("@RPEN_TIMESTAMP", timestamp);
                    cmd.Parameters.AddWithValue("@RPEN_WRES_ID", _dba.UserWResID);
                    cmd.Parameters.AddWithValue("@RPEN_TITLE", title);
                    cmd.Parameters.AddWithValue("@RPEN_HTML", sHTML);
                    cmd.Parameters.AddWithValue("@RPEN_TO", to);
                    int nRowsAffected = cmd.ExecuteNonQuery();

                    if (nRowsAffected > 0)
                    {
                        CStruct xResult = BuildResultStruct("AddNote");
                        //xResult.AppendSubStruct(xNote);
                        sReply = xResult.XML();
                    }
                    else
                    {
                        _dba.Status = (StatusEnum)99999;
                        _dba.StatusText = "No database rows affected";
                        sReply = HandleError("AddNote", Status, FormatErrorText());
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("AddNote", 99999, ex);
            }
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private bool AddNotificationNote(int lProjectID, Guid planrowGUID, int nContext, int nEventContext, string sTitle, string sHTML)
        {
            try
            {

                string to = "";
                DateTime timestamp = DateTime.Now;
                const string sCommand = "INSERT INTO EPG_RPE_NOTES (RPEN_CMT_GUID,RPEN_PROJECT_ID,RPEN_CONTEXT,RPEN_EVENT_CONTEXT,RPEN_TIMESTAMP,RPEN_WRES_ID,RPEN_TITLE,RPEN_HTML,RPEN_TO) VALUES(@RPEN_CMT_GUID,@RPEN_PROJECT_ID,@RPEN_CONTEXT,@RPEN_EVENT_CONTEXT,@RPEN_TIMESTAMP,@RPEN_WRES_ID,@RPEN_TITLE,@RPEN_HTML,@RPEN_TO)";
                SqlCommand cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                cmd.Parameters.AddWithValue("@RPEN_CMT_GUID", planrowGUID);
                cmd.Parameters.AddWithValue("@RPEN_PROJECT_ID", lProjectID);
                cmd.Parameters.AddWithValue("@RPEN_CONTEXT", nContext);
                cmd.Parameters.AddWithValue("@RPEN_EVENT_CONTEXT", nEventContext);
                cmd.Parameters.AddWithValue("@RPEN_TIMESTAMP", timestamp);
                cmd.Parameters.AddWithValue("@RPEN_WRES_ID", _dba.UserWResID);
                cmd.Parameters.AddWithValue("@RPEN_TITLE", sTitle);
                cmd.Parameters.AddWithValue("@RPEN_HTML", sHTML);
                cmd.Parameters.AddWithValue("@RPEN_TO", to);
                int nRowsAffected = cmd.ExecuteNonQuery();

                if (nRowsAffected > 0)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        private bool SaveRowNote(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    CStruct xNote = xExecute.GetSubStruct("Note");
                    Guid planrowGUID = xNote.GetGuidAttr("Planrow_GUID");
                    int lProjectID = xNote.GetIntAttr("Project_UID");

                    string sCommand = "DELETE FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID=@RPEN_CMT_GUID AND RPEN_TO IS NULL";
                    SqlCommand cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    cmd.Parameters.AddWithValue("@RPEN_CMT_GUID", planrowGUID);
                    cmd.ExecuteNonQuery();

                    string sHTML = xNote.GetString("HTML");
                    if (sHTML == "")
                    {
                        CStruct xResult = BuildResultStruct("SaveRowNote");
                        sReply = xResult.XML();
                    }
                    else
                    {
                        DateTime timestamp = xNote.GetDate("Timestamp");
                        sCommand =
                            "INSERT INTO EPG_RPE_NOTES (RPEN_CMT_GUID,RPEN_PROJECT_ID,RPEN_TIMESTAMP,RPEN_WRES_ID,RPEN_TITLE,RPEN_HTML,RPEN_TO) VALUES(@RPEN_CMT_GUID,@RPEN_PROJECT_ID,@RPEN_TIMESTAMP,@RPEN_WRES_ID,NULL,@RPEN_HTML,NULL)";
                        cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                        cmd.Parameters.AddWithValue("@RPEN_CMT_GUID", planrowGUID);
                        cmd.Parameters.AddWithValue("@RPEN_PROJECT_ID", lProjectID);
                        cmd.Parameters.AddWithValue("@RPEN_TIMESTAMP", timestamp);
                        cmd.Parameters.AddWithValue("@RPEN_WRES_ID", _dba.UserWResID);
                        cmd.Parameters.AddWithValue("@RPEN_HTML", sHTML);
                        int nRowsAffected = cmd.ExecuteNonQuery();

                        if (nRowsAffected > 0)
                        {
                            CStruct xResult = BuildResultStruct("SaveRowNote");
                            sReply = xResult.XML();
                        }
                        else
                        {
                            _dba.Status = (StatusEnum) 99999;
                            _dba.StatusText = "No database rows affected";
                            sReply = HandleError("SaveRowNote", Status, FormatErrorText());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveRowNote", 99999, ex);
            }
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private string GetValidResourcesFromList(string sResourceUIDs)
        {
            bool bSuperRM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperRM);
            if (bSuperRM)
                return sResourceUIDs;

            string sManagedResourceUIDs = "";
            string sResManagerDeptUIDs = "";
            SqlCommand oCommand = new SqlCommand("EPG_SP_ReadManagerResDeptsB", _dba.Connection);
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.Parameters.Add("ApproverWResID", SqlDbType.Int).Value = _userWResID;
            SqlDataReader reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                Common.AddIDToList(ref sResManagerDeptUIDs, DBAccess.ReadIntValue(reader["DeptUID"]));
            }
            reader.Close();
            if (sResManagerDeptUIDs != "")
            {
                string sCommand = "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_RP_DEPT IN (" + sResManagerDeptUIDs + ")";
                oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                    if (Common.IsIDInList(sResourceUIDs, lWResID) == true)
                        Common.AddIDToList(ref sManagedResourceUIDs, lWResID);
                }
                reader.Close();
            }
            return sManagedResourceUIDs;
        }

        private bool GetPlanResources(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    string Wepid = xExecute.GetString("Wepid");
                    string sTicket = xExecute.GetString("TicketVal");
                    bool bIsResource = xExecute.GetBoolean("IsResource");
                    string sWResIDs = xExecute.GetString("WResIDs");

                    string sProjectIDs = "";

                    if (sTicket != string.Empty)
                    {
                        string sTicketInfo;
                        if (ReadTicketString(sTicket, out sTicketInfo) == false) goto Exit_Function;
                        if (bIsResource)
                        {
                            //sWResIDs = sTicketInfo;
                            sWResIDs = GetValidResourcesFromList(sTicketInfo);
                        }
                        else
                        {
                            string sProjectWepids = sTicketInfo;
                            // convert wepids list to projectid list
                            string sSelect =
                                "SELECT PROJECT_ID FROM EPGP_PROJECTS JOIN dbo.EPG_FN_ConvertWEPIDToTable(N'" +
                                sProjectWepids + "') LT on PROJECT_EXT_UID=LT.TokenVal";

                            SqlCommand oCommand = new SqlCommand(sSelect, _dba.Connection, _dba.Transaction);
                            SqlDataReader reader = oCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                if (sProjectIDs != "") sProjectIDs += ",";
                                int lProjectID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                                sProjectIDs += lProjectID.ToString("0");
                            }
                            reader.Close();
                        }
                    }
                    else
                    {
                        int lProjectID;
                        if (DBCommon.SelectProjectIDByExtUID(_dba, Wepid, out lProjectID) == StatusEnum.rsSuccess)
                        {
                            sProjectIDs = lProjectID.ToString("0");
                        }
                    }

                    CAdmin oAdmin = new CAdmin();
                    if (oAdmin.GetAdminInfo(_dba) != StatusEnum.rsSuccess)
                        goto Exit_Function;

                    // Read in the PI Commitments calendar periods
                    List<CPeriod> clnPeriods;
                    if (GetPeriods(_dba, oAdmin.PortfolioCommitmentsCalendarUID, out clnPeriods) != StatusEnum.rsSuccess)
                        goto Exit_Function;

                    // Take into account the status date
                    int lStartPeriodID = 1;

                    {
                        CStruct xReply;
                        if (ResourceSelector.GetPIResourcesStruct(_dba, _userWResID, sProjectIDs, sWResIDs, clnPeriods, oAdmin, lStartPeriodID, out xReply) != StatusEnum.rsSuccess)
                            goto Exit_Function;

                        sReply = RPEditorResources.BuildPlanResourcesGridXML(BuildResultStruct("GetPlanResources"), xReply);
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetPlanResources", 99999, ex);
            }
        Exit_Function:
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            if (bResult == false)
            {
                sReply = HandleError("GetPlanResources", Status, FormatErrorText());
            }
            return bResult;
        }

        private bool GetRowNote(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    string planrowGUID = xExecute.GetString("guid");

                    const string sSelect = "SELECT * FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID = @RPEN_CMT_GUID AND RPEN_CONTEXT = 0";
                    SqlCommand cmd = new SqlCommand(sSelect, _dba.Connection, _dba.Transaction);
                    cmd.Parameters.AddWithValue("@RPEN_CMT_GUID", planrowGUID);
                    CStruct xNote = null;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        xNote = new CStruct();
                        xNote.Initialize("RowNote");
                        xNote.CreateDateAttr("Date", DBAccess.ReadDateValue(reader["RPEN_TIMESTAMP"]));
                        //xNote.CreateStringAttr("Title", DBAccess.ReadStringValue(reader["RPEN_TITLE"]));
                        xNote.CreateStringAttr("HTML", DBAccess.ReadStringValue(reader["RPEN_HTML"]));
                    }
                    reader.Close();
                    CStruct xResult = BuildResultStruct("GetRowNote");
                    xResult.CreateStringAttr("guid", planrowGUID);
                    if (xNote != null)
                        xResult.AppendSubStruct(xNote);

                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetRowNote", 99999, ex);
            }
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            if (bResult == false)
            {
                sReply = HandleError("GetRowNote", Status, FormatErrorText());
            }
            return bResult;
        }

        private bool GetRowEvents(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    string planrowGUID = xExecute.GetString("guid");

                    const string sSelect = "SELECT RN.*, WR.RES_NAME FROM EPG_RPE_NOTES RN"
                    + " LEFT JOIN EPG_RESOURCES WR ON (RN.RPEN_WRES_ID = WR.WRES_ID)"
                    + " WHERE RPEN_CMT_GUID = @RPEN_CMT_GUID AND RPEN_CONTEXT = 1 AND RPEN_EVENT_CONTEXT >= 0"
                    + " ORDER BY RPEN_TIMESTAMP";
                    SqlCommand cmd = new SqlCommand(sSelect, _dba.Connection, _dba.Transaction);
                    cmd.Parameters.AddWithValue("@RPEN_CMT_GUID", planrowGUID);
                    CStruct xRowEvents = xExecute.CreateSubStruct("RowEvents");
                    string sHtml = "";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CStruct xRowEvent = xRowEvents.CreateSubStruct("RowEvent");
                        //xRowEvent.CreateIntAttr("Event", DBAccess.ReadIntValue(reader["RPEN_EVENT_CONTEXT"]));
                        DateTime dt = DBAccess.ReadDateValue(reader["RPEN_TIMESTAMP"]);
                        string sName = DBAccess.ReadStringValue(reader["RES_NAME"]);
                        sHtml += dt.ToString() + " " + sName + ":<br />";
                        string sTitle = DBAccess.ReadStringValue(reader["RPEN_TITLE"]);
                        if (sTitle.Trim() != "")
                            sHtml += "<b>" + sTitle + "</b><br />";
                        sHtml += DBAccess.ReadStringValue(reader["RPEN_HTML"]);
                        sHtml += "<br />";
                    }
                    reader.Close();
                    CStruct xResult = BuildResultStruct("GetRowEvents");
                    xResult.CreateStringAttr("guid", planrowGUID);
                    //xResult.CreateString("HTML", "<div id='idDivRowEventsHtml' style='width:100%;height:100%;overflow:scroll;'>" + sHtml + "</div>");
                    xResult.CreateString("HTML", sHtml);

                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetRowEvents", 99999, ex);
            }
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            if (bResult == false)
            {
                sReply = HandleError("GetRowEvents", Status, FormatErrorText());
            }
            return bResult;
        }

        private bool GetPlanRowNotes(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    string planrowGUID = xExecute.GetString("guid");

                    CStruct xGrid = new CStruct();
                    xGrid.Initialize("Grid");
                    CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
                    xToolbar.CreateIntAttr("Visible", 0);
                    CStruct xPanel = xGrid.CreateSubStruct("Panel");
                    xPanel.CreateIntAttr("Visible", 0);
                    xPanel.CreateIntAttr("Select", 0);
                    xPanel.CreateIntAttr("Delete", 0);
                    CStruct xCfg = xGrid.CreateSubStruct("Cfg");
                    //xCfg.CreateStringAttr("MainCol", "Title");
                    xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
                    xCfg.CreateIntAttr("SuppressCfg", 3);
                    xCfg.CreateIntAttr("InEditMode", 0);
                    xCfg.CreateIntAttr("Sorting", 1);
                    xCfg.CreateIntAttr("ColsMoving", 0);
                    xCfg.CreateIntAttr("ColsPosLap", 1);
                    xCfg.CreateIntAttr("ColsLap", 1);
                    xCfg.CreateIntAttr("VisibleLap", 1);
                    xCfg.CreateIntAttr("SectionWidthLap", 1);
                    xCfg.CreateIntAttr("GroupLap", 1);
                    xCfg.CreateIntAttr("WideHScroll", 0);
                    xCfg.CreateIntAttr("LeftWidth", 400);
                    xCfg.CreateIntAttr("Width", 400);
                    xCfg.CreateIntAttr("RightWidth", 400);
                    xCfg.CreateIntAttr("MaxHeight", 0);
                    xCfg.CreateIntAttr("ShowDeleted", 0);
                    xCfg.CreateBooleanAttr("DateStrings", true);
                    xCfg.CreateIntAttr("MaxWidth", 1);
                    xCfg.CreateIntAttr("MaxSort", 2);
                    xCfg.CreateIntAttr("AppendId", 0);
                    xCfg.CreateIntAttr("FullId", 0);
                    xCfg.CreateStringAttr("IdChars", "0123456789");
                    xCfg.CreateIntAttr("NumberId", 1);
                    xCfg.CreateIntAttr("LastId", 1);
                    xCfg.CreateIntAttr("CaseSensitiveId", 0);
                    xCfg.CreateStringAttr("Style", "GM");
                    xCfg.CreateStringAttr("CSS", "RPEditor");
                    xCfg.CreateIntAttr("FastColumns", 1);
                    xCfg.CreateIntAttr("ConstHeight", 1); // If set to 1, updates height of grid to fill whole main tag. It does not modify main tag height, see MaxHeight.

                    CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");

                    CStruct xHead = xGrid.CreateSubStruct("Head");
                    CStruct xFilter = xHead.CreateSubStruct("Filter");
                    xFilter.CreateStringAttr("id", "Filter");
                    xFilter.CreateIntAttr("Visible", 0);

                    CStruct xC = xLeftCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "Date");
                    xC.CreateStringAttr("Type", "Date");
                    xC.CreateStringAttr("Format", "G");
                    xC.CreateIntAttr("CanEdit", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateIntAttr("CanSort", 1);
                    //xC.CreateIntAttr("Width", 15);
                    //xHeader1.CreateStringAttr("Current", " ");

                    xC = xLeftCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "Title");
                    xC.CreateStringAttr("Type", "Text");
                    //xC.CreateIntAttr("Width", 200);
                    xC.CreateIntAttr("CanEdit", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateIntAttr("CanSort", 1);
                    //xC.CreateIntAttr("RelWidth", 1);

                    xC = xLeftCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "To");
                    xC.CreateStringAttr("Type", "Text");
                    //xC.CreateIntAttr("Width", 200);
                    xC.CreateIntAttr("CanEdit", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateIntAttr("CanSort", 1);
                    xC.CreateIntAttr("RelWidth", 1);


                    // ******************************************* DATA *****************************************

                    CStruct xBody = xGrid.CreateSubStruct("Body");
                    CStruct xB = xBody.CreateSubStruct("B");

                    // NB this statement is meant to bring back all depts for the specified resources even if the resource is generic without a fixed dept
                    const string sSelect = "SELECT * FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID = @RPEN_CMT_GUID ORDER BY RPEN_TIMESTAMP DESC";
                    SqlCommand cmd = new SqlCommand(sSelect, _dba.Connection, _dba.Transaction);
                    cmd.Parameters.AddWithValue("@RPEN_CMT_GUID", planrowGUID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    //string sHTML="";
                    //string sTitle="";
                    while (reader.Read())
                    {
                        CStruct xI = xB.CreateSubStruct("I");
                        xI.CreateDateAttr("Date", DBAccess.ReadDateValue(reader["RPEN_TIMESTAMP"]));
                        xI.CreateStringAttr("Title", DBAccess.ReadStringValue(reader["RPEN_TITLE"]));
                        xI.CreateStringAttr("HTML", DBAccess.ReadStringValue(reader["RPEN_HTML"]));
                        xI.CreateStringAttr("To", DBAccess.ReadStringValue(reader["RPEN_TO"]));
                        //sHTML = DBAccess.ReadStringValue(reader["RPEN_HTML"]);
                    }
                    reader.Close();

                    CStruct xResult = BuildResultStruct("GetPlanRowNotes");
                    xResult.AppendSubStruct(xGrid);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetPlanRowNotes", 99999, ex);
            }
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            if (bResult == false)
            {
                sReply = HandleError("GetPlanRowNotes", Status, FormatErrorText());
            }
            return bResult;
        }

        private bool SaveResourcePlanView(string sRequest, out string sReply)
        {
            //sReply = "";
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    CStruct xView = xExecute.GetSubStruct("View");

                    Guid guidView = xView.GetGuidAttr("ViewGUID");
                    string sName = xView.GetStringAttr("Name");
                    bool bPersonal = xView.GetIntAttr("Personal") == 1;
                    bool bDefault = (xView.GetIntAttr("Default") == 1);
                    string sData = xView.XML();

                    string sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@VIEW_NAME,WRES_ID=@WRES_ID,VIEW_DEFAULT=@VIEW_DEFAULT,VIEW_DATA=@VIEW_DATA,VIEW_CONTEXT=30000 WHERE VIEW_GUID=@VIEW_GUID";
                    SqlCommand cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    cmd.Parameters.AddWithValue("@VIEW_NAME", sName);
                    cmd.Parameters.AddWithValue("@WRES_ID", bPersonal ? _userWResID : 0);
                    cmd.Parameters.AddWithValue("@VIEW_DEFAULT", bDefault);
                    cmd.Parameters.AddWithValue("@VIEW_DATA", sData);
                    cmd.Parameters.AddWithValue("@VIEW_GUID", guidView);
                    int nRowsAffected = cmd.ExecuteNonQuery();

                    if (nRowsAffected == 0)
                    {
                        sCommand = "INSERT INTO EPG_VIEWS (VIEW_GUID,VIEW_NAME,WRES_ID,VIEW_DEFAULT,VIEW_DATA,VIEW_CONTEXT) VALUES(@VIEW_GUID,@VIEW_NAME,@WRES_ID,@VIEW_DEFAULT,@VIEW_DATA,30000)";
                        cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                        cmd.Parameters.AddWithValue("@VIEW_GUID", guidView);
                        cmd.Parameters.AddWithValue("@VIEW_NAME", sName);
                        cmd.Parameters.AddWithValue("@WRES_ID", bPersonal ? _userWResID : 0);
                        cmd.Parameters.AddWithValue("@VIEW_DEFAULT", bDefault);
                        cmd.Parameters.AddWithValue("@VIEW_DATA", sData);
                        nRowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (nRowsAffected != 1) {
                        _dba.Status = (StatusEnum)99999;
                        _dba.StatusText = "No database rows affected";
                        sReply = HandleError("SaveResourcePlanView", Status, FormatErrorText());
                    }
                    else
                    {
                        if (bDefault)
                        {
                            // clear other view default flags
                            sCommand = "UPDATE EPG_VIEWS SET VIEW_DEFAULT=0 WHERE VIEW_CONTEXT=30000 AND VIEW_GUID<>@VIEW_GUID";
                            cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                            cmd.Parameters.AddWithValue("@VIEW_GUID", guidView);
                            nRowsAffected = cmd.ExecuteNonQuery();
                        }

                        CStruct xResult = BuildResultStruct("SaveResourcePlanView");
                        xResult.AppendSubStruct(xView);
                        sReply = xResult.XML();
                    }
                }
                else
                {
                    sReply = HandleError("SaveResourcePlanView2", Status, FormatErrorText());
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveResourcePlanView", 99999, ex);
            }
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            return bResult;
        }

        private bool DeleteResourcePlanView(string sRequest, out string sReply)
        {
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    CStruct xView = xExecute.GetSubStruct("View");

                    Guid guidView = xView.GetGuidAttr("ViewGUID");
                    const string sCommand = "DELETE FROM EPG_VIEWS WHERE VIEW_GUID=@VIEW_GUID";
                    SqlCommand cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    cmd.Parameters.AddWithValue("@VIEW_GUID", guidView);
                    int nRowsAffected = cmd.ExecuteNonQuery();
                    if (nRowsAffected != 1)
                    {
                        _dba.Status = (StatusEnum)99999;
                        _dba.StatusText = "No database rows affected";
                        sReply = HandleError("DeleteResourcePlanView", Status, FormatErrorText());
                    }
                    else
                    {
                        CStruct xResult = BuildResultStruct("DeleteResourcePlanView");
                        xResult.AppendSubStruct(xView);
                        sReply = xResult.XML();
                    }
                }
                else
                {
                    sReply = HandleError("DeleteResourcePlanView2", Status, FormatErrorText());
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("DeleteResourcePlanView", 99999, ex);
            }
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            return bResult;
        }

        private bool GetImportWorkHours(string sRequest, out string sReply)
        {
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {

                    int lProjectID = xExecute.GetInt("ProjectID");

                    //string sWEPID = xExecute.GetString("Wepid");
                    //if (DBCommon.SelectProjectIDByExtUID(_dba, sWEPID, out lProjectID) != StatusEnum.rsSuccess) goto Exit_Function;
                    //bool bIgnoreStatusDate = xExecute.GetBoolean("IgnoreStatusDate");

                    SqlCommand oCommand = new SqlCommand("EPG_SP_ReadPlannedWorkByPeriod_NAX", _dba.Connection);
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.Add("ProjID", SqlDbType.Int).Value = lProjectID;
                    oCommand.Parameters.Add("StartPeriodID", SqlDbType.Int).Value = 0;

                    int lPrevWResID = 0;
                    string sWResIDs = "";
                    string sPeriods = "";
                    string sHours = "";

                    CStruct xResources = new CStruct();
                    xResources.Initialize("Resources");
                    SqlDataReader reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        if (lWResID != lPrevWResID)
                        {
                            if (lPrevWResID > 0)
                            {
                                Common.AddIDToList(ref sWResIDs, lPrevWResID);
                                CStruct xResource = xResources.CreateSubStruct("Resource");
                                xResource.CreateIntAttr("WResID", lPrevWResID);
                                xResource.CreateStringAttr("Periods", sPeriods);
                                xResource.CreateStringAttr("Hours", sHours);
                                sPeriods = "";
                                sHours = "";
                            }
                            lPrevWResID = lWResID;
                        }

                        int lPeriod = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        double dblHours = DBAccess.ReadDoubleValue(reader["Hours"]);

                        Common.AddIDToList(ref sPeriods, lPeriod);
                        sHours = Common.AppendDoubleToList(sHours, dblHours);
                    }
                    reader.Close();
                    // create the final entry
                    if (lPrevWResID > 0)
                    {
                        Common.AddIDToList(ref sWResIDs, lPrevWResID);
                        CStruct xResource = xResources.CreateSubStruct("Resource");
                        xResource.CreateIntAttr("WResID", lPrevWResID);
                        xResource.CreateStringAttr("Periods", sPeriods);
                        xResource.CreateStringAttr("Hours", sHours);
                    }

                    CStruct xResult = BuildResultStruct("GetImportWorkHours");
                    xResult.AppendSubStruct(xResources);
                    sReply = xResult.XML();

                }
                else
                {
                    sReply = HandleError("GetImportWorkHours", Status, FormatErrorText());
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetImportWorkHours", 99999, ex);
            }
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            return bResult;
        }

        private bool GetImportCostPlanHours(string sRequest, out string sReply)
        {
            try
            {
                CStruct xExecute = new CStruct();
                if (xExecute.LoadXML(sRequest) == true)
                {
                    int lProjectID = xExecute.GetInt("ProjectID");
                    int ctId = xExecute.GetInt("ctId");
                    int cbId = xExecute.GetInt("cbId");


                    SqlCommand oCommand = new SqlCommand("EPG_SP_ReadPICVwRole", _dba.Connection);
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.Add("ProjectID", SqlDbType.Int).Value = lProjectID;
                    oCommand.Parameters.Add("CTID", SqlDbType.Int).Value = ctId;
                    oCommand.Parameters.Add("CBID", SqlDbType.Int).Value = cbId;
                    CStruct xCostValues = new CStruct();
                    xCostValues.Initialize("CostValues");
                    xCostValues.CreateIntAttr("ProjectID", lProjectID);
                    xCostValues.CreateIntAttr("ctId", ctId);
                    xCostValues.CreateIntAttr("cbId", cbId);
                    // group on the bcuid
                    int lastbcuid = 0;
                    CStruct xCostValue = null;
                    SqlDataReader reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        int bcUid = DBAccess.ReadIntValue(reader["BC_UID"]);
                        if (bcUid != lastbcuid) xCostValue = null;
                        if (xCostValue == null)
                        {
                            xCostValue = xCostValues.CreateSubStruct("CostValue");
                            xCostValue.CreateIntAttr("bcUid", bcUid);
                            xCostValue.CreateIntAttr("caUid", DBAccess.ReadIntValue(reader["CA_UID"]));
                            xCostValue.CreateIntAttr("mcUid", DBAccess.ReadIntValue(reader["MC_UID"]));
                            xCostValue.CreateStringAttr("periods",
                                                        DBAccess.ReadIntValue(reader["BD_PERIOD"]).ToString(
                                                            "0"));
                            double dblHours = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);
                            xCostValue.CreateStringAttr("hours",
                                                        ((Int32) (dblHours*100)).ToString(
                                                            "0"));
                        }
                        else
                        {
                            string sPeriods = xCostValue.GetStringAttr("periods") + "," +
                                                DBAccess.ReadIntValue(reader["BD_PERIOD"]).ToString(
                                                    "0");
                            double dblHours = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);
                            string sHours = xCostValue.GetStringAttr("hours") + "," +
                                            ((Int32) (dblHours*100)).ToString("0");
                            xCostValue.SetStringAttr("periods", sPeriods);
                            xCostValue.SetStringAttr("hours", sHours);
                        }
                        lastbcuid = bcUid;
                    }
                    reader.Close();

                    CStruct xResult = BuildResultStruct("GetImportCostPlanHours");
                    xResult.AppendSubStruct(xCostValues);
                    sReply = xResult.XML();
                }
                else
                {
                    sReply = HandleError("GetImportCostPlanHours", Status, FormatErrorText());
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetImportCostPlanHours", 99999, ex);
            }
            bool bResult = (_dba.Status == StatusEnum.rsSuccess);
            return bResult;
        }

        private bool GetResourcePlanStruct(CStruct xExecute, out CStruct xReply)
        {
            xReply = null;
            string sPos = "";
            try
            {
                if (Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpResourcePlan) == false)
                {
                    _dba.Status = StatusEnum.rsSecurityAccessDenied;
                    goto Exit_Function;
                }
                sPos = "a";
                string sWEPID = xExecute.GetString("Wepid").Trim();
                string sTicket = xExecute.GetString("TicketVal").Trim();
                bool bIsResource = xExecute.GetBoolean("IsResource");

                string sProjectIDs = "";
                string sResourceUIDs = "";
                string sManagedResourceUIDs = "";
                string sManagedProjectIDs = "";
                string sResManagerDeptUIDs = "";

                SqlCommand oCommand;
                SqlDataReader reader;
                RPDisplayModeEnum eDisplayMode = RPDisplayModeEnum.ProjectManager;
                if (sTicket != string.Empty)
                {
                    string sTicketInfo;
                    if (ReadTicketString(sTicket, out sTicketInfo) == false) goto Exit_Function;
                    if (bIsResource)
                    {
                        sResourceUIDs = sTicketInfo;
                        eDisplayMode = RPDisplayModeEnum.ResourceManager;
                    }
                    else
                    {
                        // convert wepids list to projectid list
                        string sSelect = "SELECT PROJECT_ID FROM EPGP_PROJECTS JOIN dbo.EPG_FN_ConvertWEPIDToTable(N'" + sTicketInfo + "') LT on PROJECT_EXT_UID=LT.TokenVal";

                        oCommand = new SqlCommand(sSelect, _dba.Connection, _dba.Transaction);
                        sProjectIDs = "";
                        reader = oCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            if (sProjectIDs != "") sProjectIDs += ",";
                            int lProjectID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                            sProjectIDs += lProjectID.ToString("0");
                        }
                        reader.Close();
                    }
                }
                else if (sWEPID != string.Empty)
                {
                    int lProjectID;
                    if (DBCommon.SelectProjectIDByExtUID(_dba, sWEPID, out lProjectID) != StatusEnum.rsSuccess) goto Exit_Function;
                    sProjectIDs = lProjectID.ToString("0");
                }
                sPos = "b";
                CAdmin oAdmin = new CAdmin();
                if (oAdmin.GetAdminInfo(_dba) != StatusEnum.rsSuccess)
                    goto Exit_Function;

                // Read in the PI Commitments calendar periods
                List<CPeriod> clnPeriods;
                if (DBCommon.GetPeriods(_dba, oAdmin.PortfolioCommitmentsCalendarUID, out clnPeriods) != StatusEnum.rsSuccess)
                    goto Exit_Function;

                bool bNull;
                sPos = "c";
                CStruct xRPE = new CStruct();
                xRPE.Initialize("ResourcePlanEditor");

                // Add in the requesting parameters - only one should be set
                switch (eDisplayMode)
                {
                    case RPDisplayModeEnum.ProjectManager:
                        if (sProjectIDs != string.Empty)
                            xRPE.CreateStringAttr("ProjectIDs", sProjectIDs);
                        break;
                    case RPDisplayModeEnum.ResourceManager:
                        if (sResourceUIDs != string.Empty)
                            xRPE.CreateStringAttr("ResourceUIDs", sResourceUIDs);
                        break;
                }

                xRPE.CreateIntAttr("OpMode", oAdmin.PortfolioCommitmentsOpMode);
                if (oAdmin.RPEValidateRevenueProcess)
                    xRPE.CreateBooleanAttr("ValidateRevenueProcess", oAdmin.RPEValidateRevenueProcess);
                if (oAdmin.RPEExcludeNonWorkHours)
                    xRPE.CreateBooleanAttr("ExcludeNonWorkHours", oAdmin.RPEExcludeNonWorkHours);

                // check to see what can be published
                bool bCanPublish = false;
                bool bCanPublishBaseline = false;

                string sCommand = "SELECT TOSET_MAINKEY FROM EPGP_COST_VALUES_TOSET WHERE TOSET_MAINKEY < 3";

                oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);

                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (DBAccess.ReadIntValue(reader["TOSET_MAINKEY"]) == 1)
                        bCanPublish = true;
                    else if (DBAccess.ReadIntValue(reader["TOSET_MAINKEY"]) == 2)
                        bCanPublishBaseline = true;
                }
                reader.Close();
                if (bCanPublish)
                    xRPE.CreateBooleanAttr("CanPublish", true);
                if (bCanPublishBaseline)
                    xRPE.CreateBooleanAttr("CanPublishBaseline", true);

                if (oAdmin.StatusDateIsNull == false)
                    xRPE.CreateDate("StatusDate", oAdmin.StatusDate);
                sPos = "d";
                // Get the view field definitions
                List<CTSFieldDefinition> clnFieldDefinitions;
                if (DBCommon.ReadPlanViewFields(_dba, 101, out clnFieldDefinitions) != StatusEnum.rsSuccess)
                    goto Exit_Function;

                if (clnFieldDefinitions == null)
                {
                    _dba.Status = StatusEnum.rsPIResourcePlanViewNotSet;
                    goto Exit_Function;
                }

                CStruct xFieldDefinitions = xRPE.CreateSubStruct("FieldDefinitions");
                XmlDocument oXMLDocument = new XmlDocument();
                foreach (CTSFieldDefinition oFieldDefinition in clnFieldDefinitions)
                {
                    CStruct xFieldDefinition = new CStruct();
                    xFieldDefinition.SetXMLNode(oFieldDefinition.XMLEncode(oXMLDocument), oXMLDocument);
                    xFieldDefinitions.AppendSubStruct(xFieldDefinition);
                }
                sPos = "e";
                xRPE.CreateInt("UserWResID", _userWResID);
                bool bSuperPIM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperPIM);
                bool bSuperRM = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpSuperRM);

                switch (eDisplayMode)
                {
                    case RPDisplayModeEnum.ProjectManager:
                        if (bSuperPIM)
                        {
                            sPos = "f";
                            sManagedProjectIDs = sProjectIDs;
                            xRPE.CreateBoolean("SuperPIM", true);
                        }
                        else
                        {
                            sPos = "g";
                            sCommand = "SELECT PROJECT_ID" +
                                       " FROM EPGP_PROJECTS" +
                                       " LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4" +
                                           " AND SURR_CONTEXT_VALUE = PROJECT_ID" +
                                       " WHERE PROJECT_MARKED_DELETION = 0" +
                                       " AND (PROJECT_MANAGER = " + _userWResID.ToString("0") +
                                       " OR SU.SURR_WRES_ID = " + _userWResID.ToString("0") + ")" +
                                       " AND PROJECT_ID in (" + sProjectIDs + ")";

                            oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                            reader = oCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                Common.AddIDToList(ref sManagedProjectIDs, DBAccess.ReadIntValue(reader["PROJECT_ID"]));
                            }
                            reader.Close();
                        }
                        if (sManagedProjectIDs == "")
                        {
                            sPos = "h";
                            _dba.Status = StatusEnum.rsSecurityNoProjects;
                            _dba.StatusText = "User does not have permission to see resource plans for any of the selected projects";
                            goto Exit_Function;
                        }
                        sCommand = "SELECT DISTINCT p.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_MANAGER,WPROJ_ID,WORKITEM_START_DATE"
                                    + "  FROM EPGP_PROJECTS p"
                                    + "  Left Join EPGX_PROJECT_VERSIONS pv On pv.PROJECT_ID=p.PROJECT_ID And VERSION_ID= "
                                    + oAdmin.DefaultVersion.ToString("0")
                                    + " WHERE PROJECT_MARKED_DELETION = 0 AND p.PROJECT_ID in (" + sManagedProjectIDs + ")"
                                    + " ORDER BY PROJECT_NAME";
                        break;
                    case RPDisplayModeEnum.ResourceManager:
                        if (bSuperRM)
                        {
                            sPos = "i";
                            sManagedResourceUIDs = sResourceUIDs;
                            xRPE.CreateBoolean("SuperRM", true);
                        }
                        else
                        {
                            sPos = "j";
                            oCommand = new SqlCommand("EPG_SP_ReadManagerResDeptsB", _dba.Connection);
                            oCommand.CommandType = CommandType.StoredProcedure;
                            oCommand.Parameters.Add("ApproverWResID", SqlDbType.Int).Value = _userWResID;
                            reader = oCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                Common.AddIDToList(ref sResManagerDeptUIDs, DBAccess.ReadIntValue(reader["DeptUID"]));
                            }
                            reader.Close();
                            if (sResManagerDeptUIDs != "")
                            {
                                sCommand = "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_RP_DEPT IN (" + sResManagerDeptUIDs + ")";
                                oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                                reader = oCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                                    if (Common.IsIDInList(sResourceUIDs, lWResID) == true)
                                        Common.AddIDToList(ref sManagedResourceUIDs, lWResID);
                                }
                                reader.Close();
                            }
                        }
                        if (sManagedResourceUIDs == "")
                        {
                            _dba.Status = StatusEnum.rsSecurityNoResources;
                            goto Exit_Function;
                        }
                        sCommand = "SELECT DISTINCT PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_MANAGER"
                                    + "  FROM EPGP_PROJECTS"
                                    + " WHERE PROJECT_MARKED_DELETION = 0"
                                    + "   AND PROJECT_ID IN "
                                    + " (SELECT DISTINCT PROJECT_ID"
                                    + "    FROM EPG_RESOURCEPLANS "
                                    + "   WHERE WRES_ID IN (" + sManagedResourceUIDs + ")"
                                    + "      OR WRES_ID_PENDING IN (" + sManagedResourceUIDs + "))"
                                    + " ORDER BY PROJECT_NAME";
                        break;
                }

                // Read in PI Details
                DateTime dt;
                oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                Dictionary<string, CStruct> dicPIs = new Dictionary<string, CStruct>();

                CStruct xPIs = xRPE.CreateSubStruct("PIs");
                reader = oCommand.ExecuteReader();
                sPos = "k";
                while (reader.Read())
                {
                    CStruct xPI = xPIs.CreateSubStruct("PI");
                    int lPI = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    xPI.CreateIntAttr("ProjectID", lPI);
                    xPI.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["PROJECT_NAME"]));
                    dt = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"], out bNull);
                    int lPeriod;
                    if (!bNull)
                    {
                        xPI.CreateDateAttr("StartDate", dt);
                        if (ConvertDateToPeriod(clnPeriods, dt, out lPeriod))
                            xPI.CreateIntAttr("StartPeriod", lPeriod);
                    }

                    dt = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"], out bNull);
                    if (!bNull)
                    {
                        xPI.CreateDateAttr("FinishDate", dt);
                        if (ConvertDateToPeriod(clnPeriods, dt, out lPeriod))
                            xPI.CreateIntAttr("FinishPeriod", lPeriod);
                    }
                    if (Common.IsIDInList(sManagedProjectIDs, lPI))
                        xPI.CreateBooleanAttr("UserIsPM", true);
                    xPI.CreateBooleanAttr("UserCanEdit", true);
                    dicPIs.Add(lPI.ToString("0"), xPI);
                }
                reader.Close();
                sPos = "l";
                // Check for calendar set
                if (oAdmin.PortfolioCommitmentsCalendarUID < 0)
                {
                    _dba.Status = StatusEnum.rsPIResourceCalendarNotSet;
                    goto Exit_Function;
                }

                CStruct xCalendar = xRPE.CreateSubStruct("Calendar");
                xCalendar.CreateIntAttr("CalID", oAdmin.PortfolioCommitmentsCalendarUID);

                // Take into account the status date
                const int lStartPeriodID = 1;
                int lFinishPeriodID;
                xRPE.CreateInt("StartPeriodID", lStartPeriodID);
                if (clnPeriods.Count > 0)
                {
                    CPeriod oPeriod = clnPeriods[clnPeriods.Count - 1];
                    lFinishPeriodID = oPeriod.PeriodID;
                }
                else
                    lFinishPeriodID = lStartPeriodID;
                xRPE.CreateInt("FinishPeriodID", lFinishPeriodID);

                CStruct xPeriods = xCalendar.CreateSubStruct("Periods");

                foreach (CPeriod oPeriod2 in clnPeriods)
                {
                    CStruct xPeriod = xPeriods.CreateSubStruct("Period");
                    xPeriod.CreateIntAttr("ID", oPeriod2.PeriodID);
                    xPeriod.CreateStringAttr("Name", oPeriod2.PeriodName);
                    xPeriod.CreateDateAttr("Start", oPeriod2.StartDate);
                    xPeriod.CreateDateAttr("Finish", oPeriod2.FinishDate);
                }

                // Add in the Cost category-role-fte information
                CStruct xCostCategoryRoles;
                if (DBCommon.GetCostCategoryRolesStruct(_dba, oAdmin.PortfolioCommitmentsCalendarUID, lStartPeriodID, out xCostCategoryRoles) != StatusEnum.rsSuccess)
                    goto Exit_Function;
                sPos = "m";
                xRPE.AppendSubStruct(xCostCategoryRoles);

                // add in the category lists including the Dept, Cost Category/Role and Major Category codes
                CStruct oRPCategories = xRPE.CreateSubStruct("RPCategories");
                CStruct oRPCategoryList;

                if (oAdmin.RPDeptCode <= 0)
                {
                    _dba.Status = StatusEnum.rsPIResourceApprovalCodeNotSet;
                    goto Exit_Function;
                }

                CStruct oRPCategory = oRPCategories.CreateSubStruct("RPCategory");
                oRPCategory.CreateInt("FieldID", (int)SpecialFieldIDsEnum.sfCostCategoryRoleName);
                if (DBCommon.GetLookupListXML(_dba, oAdmin.RoleCode, out oRPCategoryList) == StatusEnum.rsSuccess)
                {
                    oRPCategory.AppendSubStruct(oRPCategoryList);
                }
                sPos = "n";
                oRPCategory = oRPCategories.CreateSubStruct("RPCategory");
                oRPCategory.CreateInt("FieldID", (int)SpecialFieldIDsEnum.sfRPDeptName);
                if (DBCommon.GetLookupListXML(_dba, oAdmin.RPDeptCode, out oRPCategoryList) == StatusEnum.rsSuccess)
                {
                    oRPCategory.AppendSubStruct(oRPCategoryList);
                }

                if (oAdmin.MajorCategoryCode > 0)
                {
                    oRPCategory = oRPCategories.CreateSubStruct("RPCategory");
                    oRPCategory.CreateInt("FieldID", (int)SpecialFieldIDsEnum.sfMajorCategory);
                    if (DBCommon.GetLookupListXML(_dba, oAdmin.MajorCategoryCode, out oRPCategoryList) == StatusEnum.rsSuccess)
                    {
                        oRPCategory.AppendSubStruct(oRPCategoryList);
                    }
                }
                sPos = "o";
                foreach (CTSFieldDefinition oFieldDefinition in clnFieldDefinitions)
                {
                    if (oFieldDefinition.IsCategory)
                    {
                        if (oFieldDefinition.CategoryListID > 0)
                        {
                            oRPCategory = oRPCategories.CreateSubStruct("RPCategory");
                            oRPCategory.CreateInt("FieldID", oFieldDefinition.FieldID);
                            if (DBCommon.GetLookupListXML(_dba, oFieldDefinition.CategoryListID, out oRPCategoryList) == StatusEnum.rsSuccess)
                            {
                                oRPCategory.AppendSubStruct(oRPCategoryList);
                            }
                        }
                    }
                }
                sPos = "p";
                oCommand = new SqlCommand("EPG_SP_ReadRateTypes", _dba.Connection);
                oCommand.CommandType = CommandType.StoredProcedure;
                reader = oCommand.ExecuteReader();

                CStruct xRateTypes = xRPE.CreateSubStruct("RateTypes");
                while (reader.Read())
                {
                    CStruct xRateType = xRateTypes.CreateSubStruct("RateType");

                    xRateType.CreateIntAttr("ID", DBAccess.ReadIntValue(reader["RT_UID"]));
                    xRateType.CreateIntAttr("CalcMethodID", DBAccess.ReadIntValue(reader["RT_CALC_METHOD_ID"]));
                    xRateType.CreateIntAttr("RateTableID", DBAccess.ReadIntValue(reader["RT_RATE_TABLE_ID"]));
                    xRateType.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["RT_NAME"]));
                }
                reader.Close();
                sPos = "q";
                // Read in the rates used for named rates
                oRPCategory = oRPCategories.CreateSubStruct("RPCategory");
                oRPCategory.CreateInt("FieldID", (int)SpecialFieldIDsEnum.sfResourceRate);
                CStruct oLookupList = oRPCategory.CreateSubStruct("LookupList");
                CStruct xItems = oLookupList.CreateSubStruct("Items");

                oCommand = new SqlCommand("EPG_SP_ReadRates", _dba.Connection);
                oCommand.CommandType = CommandType.StoredProcedure;
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    CStruct xItem = xItems.CreateSubStruct("Item");
                    xItem.CreateIntAttr("ID", DBAccess.ReadIntValue(reader["RT_UID"]));
                    xItem.CreateIntAttr("Level", DBAccess.ReadIntValue(reader["RT_LEVEL"]));
                    xItem.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["RT_NAME"]));
                }
                reader.Close();

                sPos = "r";

                CStruct xPlanRows = xRPE.CreateSubStruct("PlanRows");

                Dictionary<string, CStruct> dicPlanRows = new Dictionary<string, CStruct>();

                // Read in the team resources info for the requested PI
                // Modes:
                // 0 = Read all planrows for one or more selected PIs where user is PI manager
                // 1 = Read planrows for selected resources
                int lMode = 0;
                switch (eDisplayMode)
                {
                    case RPDisplayModeEnum.ProjectManager:
                        lMode = 0;
                        break;
                    case RPDisplayModeEnum.ResourceManager:
                        lMode = 1;
                        break;
                }

                oCommand = new SqlCommand("EPG_SP_ReadResourcePlans_NAX", _dba.Connection);
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add("Mode", SqlDbType.Int).Value = lMode;
                oCommand.Parameters.Add("ProjectIDs", SqlDbType.VarChar, sProjectIDs.Length).Value = sProjectIDs;
                oCommand.Parameters.Add("WResIDs", SqlDbType.VarChar, sManagedResourceUIDs.Length).Value = sManagedResourceUIDs;
                reader = oCommand.ExecuteReader();
                sPos = "s";

                int lPrevUID = 0;
                string sCMTUIDs = "";
                while (reader.Read())
                {
                    PlanRowStatusEnum ePlanRowStatus = (PlanRowStatusEnum)DBAccess.ReadIntValue(reader["CMT_STATUS"]);
                    int lUID = DBAccess.ReadIntValue(reader["CMT_UID"]);
                    Guid gUID = DBAccess.ReadGuidValue(reader["CMT_GUID"]);
                    CStruct xPlanRow = xPlanRows.CreateSubStruct("PlanRow");
                    Common.AddIDToList(ref sCMTUIDs, lUID);
                    xPlanRow.CreateIntAttr("UID", lUID);
                    xPlanRow.CreateGuidAttr("GUID", gUID);

                    int lPI = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    CStruct xPI;
                    if (dicPIs.TryGetValue(lPI.ToString("0"), out xPI))
                        xPI.SetBooleanAttr("IsUsed", true);
                    xPlanRow.CreateIntAttr("ProjectID", lPI);
                    int lDeptUID = DBAccess.ReadIntValue(reader["CMT_DEPT"]);
                    xPlanRow.CreateIntAttr("DeptUID", lDeptUID);
                    if (bSuperPIM || Common.IsIDInList(sManagedProjectIDs, lPI) == true)
                        xPlanRow.CreateIntAttr("UserIsPM", 1);
                    if (bSuperRM || Common.IsIDInList(sResManagerDeptUIDs, lDeptUID) == true)
                        xPlanRow.CreateIntAttr("UserIsRM", 1);


                    xPlanRow.CreateIntAttr("Status", (int)ePlanRowStatus);
                    xPlanRow.CreateIntAttr("EnteredByWResID", DBAccess.ReadIntValue(reader["CMT_ENTEREDBY_WRES_ID"]));
                    xPlanRow.CreateDateAttr("Timestamp", DBAccess.ReadDateValue(reader["CMT_TIMESTAMP"]));
                    xPlanRow.CreateStringAttr("Group", DBAccess.ReadStringValue(reader["RP_GROUP"]));
                    xPlanRow.CreateIntAttr("Private", DBAccess.ReadIntValue(reader["CMT_PRIVATE"]));

                    if (ePlanRowStatus != PlanRowStatusEnum.rpsRequirement)
                    {
                        xPlanRow.CreateIntAttr("PMStatus", DBAccess.ReadIntValue(reader["RP_PM_STATUS"]));
                        xPlanRow.CreateIntAttr("RMStatus", DBAccess.ReadIntValue(reader["RP_RM_STATUS"]));

                        bool bValue = (bool)vb.IIf((DBAccess.ReadIntValue(reader["RP_ACTIVE_COMMITMENT"], out bNull) != 0), true, false);
                        if (!bNull && bValue)
                            xPlanRow.CreateBooleanAttr("ActiveCommitment", bValue);
                    }

                    int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                    bool bIsInactive;
                    if (lWResID > 0)
                    {
                        xPlanRow.CreateInt("WResID", lWResID);
                        xPlanRow.CreateString("ResName", DBAccess.ReadStringValue(reader["ResName"]));
                        xPlanRow.CreateInt("ResDept", DBAccess.ReadIntValue(reader["ResDept"]));
                        bIsInactive = ((DBAccess.ReadIntValue(reader["ResInactive"]) != 0) && lWResID > 0);
                        if (bIsInactive)
                            xPlanRow.CreateBoolean("ResInactive", bIsInactive);
                    }
                    lWResID = DBAccess.ReadIntValue(reader["WRES_ID_PENDING"]);
                    if (lWResID > 0)
                    {
                        xPlanRow.CreateInt("PendingWResID", lWResID);
                        xPlanRow.CreateString("PendingResName", DBAccess.ReadStringValue(reader["PendingResName"]));
                        xPlanRow.CreateInt("PendingResDept", DBAccess.ReadIntValue(reader["PendingResDept"]));
                        bIsInactive = (DBAccess.ReadIntValue(reader["PendingResInactive"]) != 0 && lWResID > 0);
                        if (bIsInactive)
                            xPlanRow.CreateBoolean("PendingResInactive", bIsInactive);
                    }
                    xPlanRow.CreateInt("CCRoleUID", DBAccess.ReadIntValue(reader["BC_UID"]));
                    xPlanRow.CreateInt("CCRoleParentUID", DBAccess.ReadIntValue(reader["PARENT_BC_UID"]));
                    xPlanRow.CreateInt("RoleUID", DBAccess.ReadIntValue(reader["CMT_ROLE"]));

                    string sValue = DBAccess.ReadStringValue(reader["CMT_MAJORCATEGORY"]);
                    if (sValue != "")
                        xPlanRow.CreateString("MajorCategory", sValue);

                    sValue = DBAccess.ReadStringValue(reader["CMT_DESC"]);
                    if (sValue != "")
                        xPlanRow.CreateString("Description", sValue);
                    dt = DBAccess.ReadDateValue(reader["CMT_START_DATE"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateDate("StartDate", dt);
                    dt = DBAccess.ReadDateValue(reader["CMT_FINISH_DATE"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateDate("FinishDate", dt);

                    double dblValue = DBAccess.ReadDoubleValue(reader["CMT_ALLOCATION"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateDouble("Allocation", dblValue);
                    int lValue = DBAccess.ReadIntValue(reader["CMT_ALLOCATION_MODE"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateInt("AllocationMode", lValue);

                    // Add the rate info
                    lValue = DBAccess.ReadIntValue(reader["CMT_RATETYPE_UID"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateInt("RateTypeUID", lValue);
                    lValue = DBAccess.ReadIntValue(reader["CMT_RATE_PRD_ID"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateInt("RatePeriodID", lValue);
                    dblValue = DBAccess.ReadDoubleValue(reader["CMT_RATE"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateDouble("Rate", dblValue);

                    lValue = DBAccess.ReadIntValue(reader["CMT_RT_UID"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateInt("Rate_UID", lValue);

                    dblValue = DBAccess.ReadDoubleValue(reader["CMT_CALC_TOTAL_COST"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateDouble("CalcTotalCost", dblValue);
                    dblValue = DBAccess.ReadDoubleValue(reader["CMT_TOTAL_COST"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateDouble("TotalCost", dblValue);

                    lValue = DBAccess.ReadIntValue(reader["RPEN_UID"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateInt("RowNoteUID", lValue);
                    // Creating string attribute for hidden note field to be used while exporting to excel.
                    sValue = DBAccess.ReadStringValue(reader["RPEN_HTML"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateString("RowNote_HTML", sValue);

                    lValue = DBAccess.ReadIntValue(reader["CMT_LAST_EVENT_CONTEXT"], out bNull);
                    if (!bNull)
                        xPlanRow.CreateInt("LastRowEvent", lValue);

                    // Now add the view field values
                    foreach (CTSFieldDefinition oTSFieldDefinition in clnFieldDefinitions)
                    {
                        switch ((SpecialFieldIDsEnum)oTSFieldDefinition.FieldID)
                        {
                            case SpecialFieldIDsEnum.sfRowType:
                                break;
                            case SpecialFieldIDsEnum.sfRoleName:
                                break;
                            case SpecialFieldIDsEnum.sfDeptName:
                                break;
                            case SpecialFieldIDsEnum.sfRPDeptName:
                                break;
                            case SpecialFieldIDsEnum.sfResourceName:
                                break;
                            case SpecialFieldIDsEnum.sfMajorCategory:
                                break;
                            case SpecialFieldIDsEnum.sfRPCatCode1:
                            case SpecialFieldIDsEnum.sfRPCatCode2:
                            case SpecialFieldIDsEnum.sfRPCatCode3:
                            case SpecialFieldIDsEnum.sfRPCatCode4:
                            case SpecialFieldIDsEnum.sfRPCatCode5:
                                lValue = DBAccess.ReadIntValue(reader[oTSFieldDefinition.SQLName]);
                                if (lValue != 0)
                                    xPlanRow.CreateInt("Field" + oTSFieldDefinition.FieldID.ToString("0"), lValue);
                                break;
                            case SpecialFieldIDsEnum.sfRPCatText1:
                            case SpecialFieldIDsEnum.sfRPCatText2:
                            case SpecialFieldIDsEnum.sfRPCatText3:
                            case SpecialFieldIDsEnum.sfRPCatText4:
                            case SpecialFieldIDsEnum.sfRPCatText5:
                                sValue = DBAccess.ReadStringValue(reader[oTSFieldDefinition.SQLName]);
                                if (sValue != "")
                                    xPlanRow.CreateString("Field" + oTSFieldDefinition.FieldID.ToString("0"), sValue);
                                break;
                            case SpecialFieldIDsEnum.sfRPStartDate:
                                break;
                            case SpecialFieldIDsEnum.sfRPFinishDate:
                                break;
                        }
                    }

                    dicPlanRows.Add(lUID.ToString("0"), xPlanRow);
                }
                reader.Close();
                sPos = "t";
                if (oAdmin.PortfolioCommitmentsCalendarUID >= 0 && sCMTUIDs != "")
                {
                    oCommand = new SqlCommand("EPG_SP_ReadResourcePlansHours", _dba.Connection);
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.Add("StartPeriodID", SqlDbType.Int).Value = lStartPeriodID;
                    oCommand.Parameters.Add("sList", SqlDbType.VarChar, sCMTUIDs.Length).Value = sCMTUIDs;
                    reader = oCommand.ExecuteReader();

                    string sPeriods = "";
                    string sHours = "";
                    string sFTEs = "";
                    string sModes = "";
                    string sRevenues = "";
                    string sEnteredBys = "";
                    bool bPrevPending = false;
                    bool bFirst = true;
                    while (reader.Read())
                    {
                        int lUID = DBAccess.ReadIntValue(reader["CMT_UID"]);
                        int lPeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        double dblHours = (DBAccess.ReadDoubleValue(reader["CMH_HOURS"]));
                        int lFTEs = DBAccess.ReadIntValue(reader["CMH_FTES"]);
                        int nMode = DBAccess.ReadIntValue(reader["CMH_MODE"]);
                        double dblRevenue = (DBAccess.ReadDoubleValue(reader["CMH_REVENUES"], out bNull));
                        if (bNull)
                            dblRevenue = double.MinValue;
                        bool bPending = (DBAccess.ReadIntValue(reader["CMH_PENDING"]) != 0);
                        int lEnteredBy = DBAccess.ReadIntValue(reader["CMH_ENTEREDBY"]);
                        if ((lUID == lPrevUID && bPending == bPrevPending) || bFirst)
                        {
                            bFirst = false;
                        }
                        else
                        {
                            CStruct xPlanRow;
                            if (dicPlanRows.TryGetValue(lPrevUID.ToString("0"), out xPlanRow))
                            {
                                if (bPrevPending == false)
                                {
                                    if (sPeriods != "")
                                        xPlanRow.CreateString("Periods", sPeriods);
                                    if (sHours != "")
                                        xPlanRow.CreateString("PeriodHours", sHours);
                                    if (sFTEs != "")
                                        xPlanRow.CreateString("PeriodFTEs", sFTEs);
                                    if (sModes != "")
                                        xPlanRow.CreateString("PeriodModes", sModes);
                                    if (sRevenues != "")
                                        xPlanRow.CreateString("PeriodRevenues", sRevenues);
                                }
                                else
                                {
                                    if (sPeriods != "")
                                        xPlanRow.CreateString("PendingPeriods", sPeriods);
                                    if (sHours != "")
                                        xPlanRow.CreateString("PendingHours", sHours);
                                    if (sFTEs != "")
                                        xPlanRow.CreateString("PendingFTEs", sFTEs);
                                    if (sModes != "")
                                        xPlanRow.CreateString("PendingModes", sModes);
                                    if (sRevenues != "")
                                        xPlanRow.CreateString("PendingRevenues", sRevenues);
                                    if (sEnteredBys != "")
                                        xPlanRow.CreateString("PendingEnteredBys", sEnteredBys);
                                }
                                sPeriods = "";
                                sHours = "";
                                sFTEs = "";
                                sRevenues = "";
                                sModes = "";
                                sEnteredBys = "";
                            }
                        }
                        sPeriods = Common.AppendItemToList(sPeriods, lPeriodID.ToString("0"));
                        sHours = Common.AppendItemToList(sHours, dblHours.ToString("0"));
                        sFTEs = Common.AppendItemToList(sFTEs, lFTEs.ToString("0"));
                        sModes = Common.AppendItemToList(sModes, nMode.ToString("0"));
                        sRevenues = Common.AppendDoubleToList(sRevenues, dblRevenue);
                        sEnteredBys = Common.AppendItemToList(sEnteredBys, lEnteredBy.ToString("0"));
                        lPrevUID = lUID;
                        bPrevPending = bPending;
                    }
                    // write the final item
                    //If sHours <> "" Or sFTEs <> "" Or dblPriorHours > 0 Then
                    if (sHours != "" || sFTEs != "" || sModes != "")
                    {
                        CStruct xPlanRow;
                        if (dicPlanRows.TryGetValue(lPrevUID.ToString("0"), out xPlanRow))
                        {
                            if (bPrevPending == false)
                            {
                                if (sPeriods != "")
                                    xPlanRow.CreateString("Periods", sPeriods);
                                if (sHours != "")
                                    xPlanRow.CreateString("PeriodHours", sHours);
                                if (sFTEs != "")
                                    xPlanRow.CreateString("PeriodFTEs", sFTEs);
                                if (sModes != "")
                                    xPlanRow.CreateString("PeriodModes", sModes);
                                if (sRevenues != "")
                                    xPlanRow.CreateString("PeriodRevenues", sRevenues);
                            }
                            else
                            {
                                if (sPeriods != "")
                                    xPlanRow.CreateString("PendingPeriods", sPeriods);
                                if (sHours != "")
                                    xPlanRow.CreateString("PendingHours", sHours);
                                if (sFTEs != "")
                                    xPlanRow.CreateString("PendingFTEs", sFTEs);
                                if (sModes != "")
                                    xPlanRow.CreateString("PendingModes", sModes);
                                if (sRevenues != "")
                                    xPlanRow.CreateString("PendingRevenues", sRevenues);
                                if (sEnteredBys != "")
                                    xPlanRow.CreateString("PendingEnteredBys", sEnteredBys);
                            }
                        }
                    }
                    reader.Close();
                    sPos = "u";
                }

                xReply = xRPE;
            }
            catch (Exception ex)
            {
                throw new PFEException(90001, "GetResourcePlanStruct : " + sPos + " : " + ex.GetBaseMessage());
            }
        Exit_Function:
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private bool ConvertDateToPeriod(List<CPeriod> clnPeriods, DateTime dt, out int lPeriod)
        {
            lPeriod = 0;
            foreach (CPeriod oPeriod in clnPeriods)
            {
                if (dt >= oPeriod.StartDate && dt <= oPeriod.FinishDate)
                {
                    lPeriod = oPeriod.PeriodID;
                    return true;
                }
            }
            return false;
        }

        private string FormatSQLDateTime(DateTime dt)
        {
            return "CONVERT(DATETIME, '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', 102)";
        }

        private string BuildSQLPlanRowInsert(CStruct xI, double dblHours)
        {
            StringBuilder sbParams = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            sbParams.Append(" CMT_GUID");
            sbValues.Append("'" + xI.GetGuidAttr("GUID") + "'");
            sbParams.Append(",CMT_UID");
            sbValues.Append("," + xI.GetIntAttr("UID").ToString("0"));
            sbParams.Append(",CMT_STATUS");
            sbValues.Append("," + xI.GetIntAttr("Status").ToString("0"));
            sbParams.Append(",CMT_PRIVATE");
            sbValues.Append("," + xI.GetIntAttr("Private").ToString("0"));
            sbParams.Append(",CMT_TIMESTAMP");
            sbValues.Append("," + FormatSQLDateTime(xI.GetDateAttr("Timestamp")));
            sbParams.Append(",RP_GROUP");
            string s = xI.GetStringAttr("Group");
            if (s == "")
                s = "M" + xI.GetIntAttr("UID").ToString("0000");
            sbValues.Append("," + DBAccess.PrepareText(s));
            sbParams.Append(",RP_PM_STATUS");
            sbValues.Append("," + xI.GetIntAttr("PMStatus").ToString("0"));
            sbParams.Append(",RP_RM_STATUS");
            sbValues.Append("," + xI.GetIntAttr("RMStatus").ToString("0"));
            sbParams.Append(",RP_ACTIVE_COMMITMENT");
            sbValues.Append("," + xI.GetIntAttr("ActiveCommitment", 0).ToString("0"));
            sbParams.Append(",PROJECT_ID");
            sbValues.Append("," + xI.GetIntAttr("Project_UID").ToString("0"));
            sbParams.Append(",BC_UID");
            sbValues.Append("," + xI.GetIntAttr("CCRole_UID").ToString("0"));
            sbParams.Append(",PARENT_BC_UID");
            sbValues.Append("," + xI.GetIntAttr("CCRoleParent_UID").ToString("0"));
            sbParams.Append(",CMT_ROLE");
            sbValues.Append("," + xI.GetIntAttr("Role_UID").ToString("0"));
            sbParams.Append(",CMT_DEPT");
            sbValues.Append("," + xI.GetIntAttr("Dept_UID").ToString("0"));
            sbParams.Append(",CMT_RT_UID");
            sbValues.Append("," + xI.GetIntAttr("NamedRate_UID").ToString("0"));
            sbParams.Append(",WRES_ID");
            sbValues.Append("," + xI.GetIntAttr("Res_UID").ToString("0"));
            sbParams.Append(",WRES_ID_PENDING");
            sbValues.Append("," + xI.GetIntAttr("PendingRes_UID").ToString("0"));
            sbParams.Append(",CMT_ENTEREDBY_WRES_ID");
            sbValues.Append("," + _dba.UserWResID.ToString("0"));
            sbParams.Append(",CMT_RATE_PRD_ID");
            sbValues.Append(",0");
            sbParams.Append(",CMT_HOURS");
            sbValues.Append("," + dblHours.ToString("0"));
            sbParams.Append(",CMT_DESC");
            sbValues.Append("," + DBAccess.PrepareText(xI.GetStringAttr("Description")));
            sbParams.Append(",CMT_LAST_EVENT_CONTEXT");
            sbValues.Append("," + xI.GetIntAttr("RowEventId").ToString("0"));
            return "INSERT INTO [EPG_RESOURCEPLANS] (" + sbParams + ") VALUES (" + sbValues + ")";
        }

        private string BuildSQLPlanCategoryRowInsert(CStruct xI)
        {
            StringBuilder sbParams = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            sbParams.Append(" CAT_CMT_UID");
            sbValues.Append(" " + xI.GetIntAttr("UID").ToString("0"));
            for (int i = 0; i < 5; i++)
            {
                sbParams.Append(",CAT_TEXT_" + (i + 1).ToString("0"));
                sbValues.Append("," + DBAccess.PrepareText(xI.GetStringAttr("X" + (i + 9300).ToString("0") + "_Name")));
            }
            for (int i = 0; i < 5; i++)
            {
                sbParams.Append(",CAT_CODE_" + (i + 1).ToString("0"));
                sbValues.Append("," + xI.GetStringAttr("X" + (i + 9305).ToString("0") + "_UID", "0"));
            }
            return "INSERT INTO [EPGP_RP_CATEGORY_VALUES] (" + sbParams + ") VALUES (" + sbValues + ")";
        }

        private string BuildSQLPlanRowUpdate(CStruct xI, double dblHours)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [EPG_RESOURCEPLANS] SET ");
            sb.Append("CMT_TIMESTAMP=" + FormatSQLDateTime(xI.GetDateAttr("Timestamp")));
            sb.Append(",CMT_STATUS=" + xI.GetIntAttr("Status").ToString("0"));
            sb.Append(",CMT_PRIVATE=" + xI.GetIntAttr("Private").ToString("0"));
            if (xI.GetBooleanAttr("GroupChanged") == true)
                sb.Append(",RP_GROUP=" + DBAccess.PrepareText(xI.GetStringAttr("Group")));
            sb.Append(",RP_PM_STATUS=" + xI.GetIntAttr("PMStatus").ToString("0"));
            sb.Append(",RP_RM_STATUS=" + xI.GetIntAttr("RMStatus").ToString("0"));
            sb.Append(",RP_ACTIVE_COMMITMENT=" + xI.GetIntAttr("ActiveCommitment", 0).ToString("0"));
            sb.Append(",PROJECT_ID=" + xI.GetIntAttr("Project_UID").ToString("0"));
            sb.Append(",BC_UID=" + xI.GetIntAttr("CCRole_UID").ToString("0"));
            sb.Append(",CMT_ROLE=" + xI.GetIntAttr("Role_UID").ToString("0"));
            if (xI.GetBooleanAttr("CCRoleParent_UIDChanged") == true)
                sb.Append(",PARENT_BC_UID=" + xI.GetIntAttr("CCRoleParent_UID").ToString("0"));
            sb.Append(",CMT_DEPT=" + xI.GetIntAttr("Dept_UID").ToString("0"));
            sb.Append(",CMT_RT_UID=" + xI.GetIntAttr("NamedRate_UID").ToString("0"));
            sb.Append(",WRES_ID=" + xI.GetIntAttr("Res_UID").ToString("0"));
            sb.Append(",WRES_ID_PENDING=" + xI.GetIntAttr("PendingRes_UID").ToString("0"));

            sb.Append(",CMT_ENTEREDBY_WRES_ID=" + _dba.UserWResID.ToString("0"));
            sb.Append(",CMT_HOURS=" + dblHours.ToString("0"));
            if (xI.GetBooleanAttr("DescriptionChanged") == true)
                sb.Append(",CMT_DESC=" + DBAccess.PrepareText(xI.GetStringAttr("Description")));
            bool bFound;
            int eventId = xI.GetIntAttr("RowEventId", out bFound);
            if (bFound)
                sb.Append(",CMT_LAST_EVENT_CONTEXT=" + eventId.ToString("0"));

            sb.Append(" WHERE CMT_TIMESTAMP=" + FormatSQLDateTime(xI.GetDateAttr("TimestampOrig")));
            sb.Append(" AND CMT_GUID='" + xI.GetGuidAttr("GUID") + "'");

            return sb.ToString();
        }

        private string BuildSQLPlanCategoryRowUpdate(CStruct xI)
        {
            StringBuilder sb = new StringBuilder();
            bool bAdded = false;
            sb.Append("UPDATE [EPGP_RP_CATEGORY_VALUES] SET ");
            for (int i = 0; i < 5; i++)
            {
                if (xI.GetBooleanAttr("X" + (i + 9300).ToString("0") + "_NameChanged") == true)
                {
                    if (bAdded) sb.Append(",");
                    sb.Append("CAT_TEXT_" + (i + 1).ToString("0") + "=" + DBAccess.PrepareText(xI.GetStringAttr("X" + (i + 9300).ToString("0") + "_Name")));
                    bAdded = true;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (xI.GetBooleanAttr("X" + (i + 9305).ToString("0") + "_UIDChanged") == true)
                {
                    if (bAdded) sb.Append(",");
                    sb.Append("CAT_CODE_" + (i + 1).ToString("0") + "='" + xI.GetStringAttr("X" + (i + 9305).ToString("0") + "_UID") + "'");
                    bAdded = true;
                }
            }

            if (bAdded == false)
                return "";

            sb.Append(" WHERE CAT_CMT_UID=" + xI.GetIntAttr("UID").ToString("0"));

            return sb.ToString();
        }

        private bool SaveResourcePlanStruct(CStruct xGrid)
        {
            try
            {
                _dba.Status = StatusEnum.rsSuccess;
                // the xml is in treegrid format
                //CStruct xGrid = new CStruct();
                //xGrid.LoadXML(sRPEXML);

                CAdmin oAdmin = new CAdmin();
                if (oAdmin.GetAdminInfo(_dba) != StatusEnum.rsSuccess)
                    goto Exit_Function;
                if (oAdmin.PortfolioCommitmentsCalendarUID < 0)
                {
                    _dba.Status = StatusEnum.rsPIResourceCalendarNotSet;
                    goto Exit_Function;
                }

                bool bNegotiationMode = (oAdmin.PortfolioCommitmentsOpMode == 0); // 0 = Negotiation mode on. 1= off
                //bool bNegotiationMode = false;
                // Read in the PI Commitments calendar periods
                List<CPeriod> clnPeriods;
                if (DBCommon.GetPeriods(_dba, oAdmin.PortfolioCommitmentsCalendarUID, out clnPeriods) != StatusEnum.rsSuccess)
                    goto Exit_Function;

                int lStartPeriodID = 1;
                int lFinishPeriodID = 1;
                foreach (CPeriod oPeriod in clnPeriods)
                {
                    if (lFinishPeriodID < oPeriod.PeriodID) lFinishPeriodID = oPeriod.PeriodID;
                }

                List<CStruct> clnPlanRows = new List<CStruct>();

                // flatten out the rows
                CStruct xBody = xGrid.GetSubStruct("Body");
                CStruct xB = xBody.GetSubStruct("B");
                List<CStruct> listI = new List<CStruct>();
                List<CStruct> list = xB.GetList("I");
                if (list.Count > 0)
                {
                    foreach (CStruct xI in list)
                    {
                        clnPlanRows.Add(xI);
                        List<CStruct> listChildI = xI.GetList("I");
                        if (listChildI.Count <= 0) continue;
                        foreach (CStruct xChildI in listChildI)
                        {
                            clnPlanRows.Add(xChildI);
                            List<CStruct> listChildChildI = xChildI.GetList("I");
                            if (listChildChildI.Count <= 0) continue;
                            foreach (CStruct xChildChildI in listChildChildI)
                            {
                                clnPlanRows.Add(xChildChildI);
                            }
                        }
                    }
                }

                // let's see if we need any new ids
                bool bRequireNewUIDs = false;
                string sGUIDs = "";
                foreach (CStruct xI in clnPlanRows)
                {
                    int lUID = xI.GetIntAttr("UID", 0);
                    if (lUID == 0)
                    {
                        string sGUID = xI.GetStringAttr("GUID", "");
                        Common.AddGUIDToList(ref sGUIDs, sGUID);
                    }
                }

                if (sGUIDs != "")
                {
                    string sCommand = "SELECT CMT_UID, CMT_GUID FROM EPG_RESOURCEPLANS INNER JOIN dbo.EPG_FN_ConvertGuidListToTable(N'" + sGUIDs + "') LT on CMT_GUID=LT.TokenVal";
                    SqlDataReader reader;
                    if (_dba.ExecuteReader(sCommand, (StatusEnum)99999, out reader) == StatusEnum.rsSuccess)
                    {
                        while (reader.Read())
                        {
                            foreach (CStruct xI in clnPlanRows)
                            {
                                if (xI.GetStringAttr("GUID", "") == DBAccess.ReadStringValue(reader["CMT_GUID"]))
                                {
                                    xI.SetIntAttr("UID", DBAccess.ReadIntValue(reader["CMT_UID"]));
                                    break;
                                }
                            }
                        }
                        reader.Close();
                        foreach (CStruct xI in clnPlanRows)
                        {
                            if (xI.GetIntAttr("UID", 0) == 0)
                            {
                                bRequireNewUIDs = true;
                                break;
                            }
                        }
                    }
                }


                // Get the view field definitions
                List<CTSFieldDefinition> clnFieldDefinitions;
                if (DBCommon.ReadPlanViewFields(_dba, 101, out clnFieldDefinitions) != StatusEnum.rsSuccess)
                    goto Exit_Function;

                if (clnFieldDefinitions == null)
                {
                    _dba.HandleStatusError(SeverityEnum.Error, "SaveResourcePlanXML", StatusEnum.rsPIResourcePlanViewNotSet, "No planrow field definitions found");
                    goto Exit_Function;
                }
                
                // start the transaction - we don't want anybody to sneek an update in whilst we're doing ours
                _dba.BeginTransaction();
                if (bRequireNewUIDs)
                {
                    int lHighestUID = 0;
                    const string sCommand = "SELECT MAX(CMT_UID) as HighestUID FROM EPG_RESOURCEPLANS";
                    SqlDataReader reader;
                    if (_dba.ExecuteReader(sCommand, (StatusEnum)99999, out reader) == StatusEnum.rsSuccess)
                    {
                        if (reader.Read() == true)
                            lHighestUID = DBAccess.ReadIntValue(reader["HighestUID"]);
                        reader.Close();
                    }
                    // now allocate the ids
                    foreach (CStruct xI in clnPlanRows)
                    {
                        if (xI.GetIntAttr("UID", 0) == 0)
                        {
                            xI.SetIntAttr("UID", ++lHighestUID);
                        }
                    }
                }

                string sDeleteCMTUIDs = "";
                string sCMTUIDs = "";
                string sTeamPIs = "";
                foreach (CStruct xI in clnPlanRows)
                {
                    Common.AddIDToList(ref sTeamPIs, xI.GetIntAttr("Project_UID", 0));
                    // check for a project row
                    if (xI.GetIntAttr("Status") == 0)
                    {
                        // check to see if option set to delete existing data
                        if (xI.GetBooleanAttr("Changed") == true && xI.GetBooleanAttr("DeleteExistingPlan") == true)
                        {
                            int lProjectID = xI.GetIntAttr("Project_UID");
                            if (lProjectID > 0)
                            {
                                string sCommand = "DELETE FROM EPGP_RP_CATEGORY_VALUES WHERE CAT_CMT_UID IN (SELECT CMT_UID FROM EPG_RESOURCEPLANS WHERE PROJECT_ID = " + lProjectID.ToString("0") + ")";
                                SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                                int lRowsAffected = oCommand.ExecuteNonQuery();
                                // Delete existing actual hours
                                //int lStartPeriodID = 1;
                                sCommand = "DELETE FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID IN (SELECT CMT_UID FROM EPG_RESOURCEPLANS WHERE PROJECT_ID = " + lProjectID.ToString("0") + ")";
                                oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                                lRowsAffected = oCommand.ExecuteNonQuery();
                                sCommand = "DELETE FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID IN (SELECT CMT_GUID FROM EPG_RESOURCEPLANS WHERE PROJECT_ID = " + lProjectID.ToString("0") + ")";
                                oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                                lRowsAffected = oCommand.ExecuteNonQuery();
                                sCommand = "DELETE FROM EPG_RESOURCEPLANS WHERE PROJECT_ID = " + lProjectID.ToString("0");
                                oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                                lRowsAffected = oCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (xI.GetBooleanAttr("Deleted") == true && xI.GetBooleanAttr("Added") == false)
                    {
                        string sCommand = "DELETE FROM EPG_RESOURCEPLANS WHERE CMT_UID = " + xI.GetIntAttr("UID", 0).ToString("0");
                        SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                        oCommand.ExecuteNonQuery();
                        sCommand = "DELETE FROM EPGP_RP_CATEGORY_VALUES WHERE CAT_CMT_UID = " + xI.GetIntAttr("UID", 0).ToString("0");
                        oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                        oCommand.ExecuteNonQuery();
                        // Delete existing actual hours
                        //int lStartPeriodID = 1;
                        sCommand = "DELETE FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID = " + xI.GetIntAttr("UID", 0).ToString("0") + " AND PRD_ID >= " + lStartPeriodID.ToString("0");
                        oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                        oCommand.ExecuteNonQuery();
                        sCommand = "DELETE FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID = '" + xI.GetGuidAttr("GUID") + "'";
                        oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                        oCommand.ExecuteNonQuery();
                    }
                    else if (xI.GetBooleanAttr("Changed") == true && xI.GetBooleanAttr("Deleted") == false)
                    {
                        Common.AddIDToList(ref sCMTUIDs, xI.GetIntAttr("UID", 0));

                        // total the hours
                        double dblHours = 0;
                        for (int lPeriod = lStartPeriodID; lPeriod <= lFinishPeriodID; lPeriod++)
                        {
                            bool bFoundH;
                            string suffix = lPeriod.ToString("0");
                            string sHours = xI.GetStringAttr("H" + suffix, "0", out bFoundH);
                            if (bFoundH)
                            {
                                dblHours += Convert.ToDouble(sHours);
                            }
                        }

                        string sSQL;
                        if (xI.GetBooleanAttr("Added") == true)
                        {
                            sSQL = BuildSQLPlanRowInsert(xI, dblHours);
                            SqlCommand oCommand = new SqlCommand(sSQL, _dba.Connection, _dba.Transaction);
                            oCommand.ExecuteNonQuery();
                            sSQL = BuildSQLPlanCategoryRowInsert(xI);
                            oCommand = new SqlCommand(sSQL, _dba.Connection, _dba.Transaction);
                            oCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            Common.AddIDToList(ref sDeleteCMTUIDs, xI.GetIntAttr("UID", 0));
                            sSQL = BuildSQLPlanRowUpdate(xI, dblHours);
                            SqlCommand oCommand = new SqlCommand(sSQL, _dba.Connection, _dba.Transaction);
                            int lRowsAffected = oCommand.ExecuteNonQuery();
                            if (lRowsAffected != 1)
                            {
                                string itemname = xI.GetStringAttr("ItemName");
                                string sCommand = "SELECT CMT_ENTEREDBY_WRES_ID,RES_NAME FROM EPG_RESOURCEPLANS LEFT JOIN EPG_RESOURCES on CMT_ENTEREDBY_WRES_ID=EPG_RESOURCES.WRES_ID WHERE CMT_UID = " + xI.GetIntAttr("UID", 0).ToString("0");
                                SqlDataReader reader;
                                string changedby = "unknown user";
                                if (_dba.ExecuteReader(sCommand, (StatusEnum)99999, out reader) == StatusEnum.rsSuccess)
                                {
                                    if (reader.Read())
                                        changedby = DBAccess.ReadStringValue(reader["RES_NAME"]); // +"(" + DBAccess.ReadIntValue(reader["CMT_ENTEREDBY_WRES_ID"]).ToString() + ")";
                                    reader.Close();
                                }
                                
                                _dba.Status = (StatusEnum)123456;
                                _dba.StatusText = "Save has failed.\nRow '" + itemname + "' has been already been changed by '" + changedby + "'.\nPlease refresh your plan and resave your changes.";
                                goto Exit_Transaction;
                            }
                            sSQL = BuildSQLPlanCategoryRowUpdate(xI);
                            if (sSQL != "")
                            {
                                oCommand = new SqlCommand(sSQL, _dba.Connection, _dba.Transaction);
                                oCommand.ExecuteNonQuery();
                            }
                        }
                        //if (xI.GetBooleanAttr("PrivateChanged") == true)
                        //{
                        //    Guid guid = xI.GetGuidAttr("GUID");
                        //    int lProjectID = xI.GetIntAttr("Project_UID");
                        //    AddNotificationNote(lProjectID, guid, 1, 1, "row made public");
                        //}
                        bool bFound;
                        int eventId = xI.GetIntAttr("RowEventId", out bFound);
                        if (bFound)
                        {
                            Guid guid = xI.GetGuidAttr("GUID");
                            int lProjectID = xI.GetIntAttr("Project_UID");
                            string sTitle = xI.GetStringAttr("RowEventTitle");
                            string sHtml = xI.GetStringAttr("RowEventHtml");
                            AddNotificationNote(lProjectID, guid, 1, eventId, sTitle, sHtml);
                        }
                    }
                }

                if (sDeleteCMTUIDs != "")
                {
                    string sCommand = "DELETE FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID IN (" + sDeleteCMTUIDs + ") AND PRD_ID >= " + lStartPeriodID.ToString("0");
                    SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                    oCommand.ExecuteNonQuery();
                }

                if (sCMTUIDs != "")
                {
                    const string sCommand = "INSERT INTO EPG_RESOURCEPLANS_HOURS (CMT_UID,PRD_ID,CMH_HOURS,CMH_FTES,CMH_MODE,CMH_REVENUES,CMH_PENDING) VALUES(@CMT_UID,@PRD_ID,@CMH_HOURS,@CMH_FTES,@CMH_MODE,@CMH_REVENUES,@CMH_PENDING)";
                    SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);

                    SqlParameter pCMT_UID = oCommand.Parameters.Add("@CMT_UID", SqlDbType.Int);
                    SqlParameter pPRD_ID = oCommand.Parameters.Add("@PRD_ID", SqlDbType.Int);
                    SqlParameter pCMH_HOURS = oCommand.Parameters.Add("@CMH_HOURS", SqlDbType.Decimal);
                    SqlParameter pCMH_FTES = oCommand.Parameters.Add("@CMH_FTES", SqlDbType.Int);
                    SqlParameter pCMH_MODE = oCommand.Parameters.Add("@CMH_MODE", SqlDbType.TinyInt);
                    SqlParameter pCMH_REVENUES = oCommand.Parameters.Add("@CMH_REVENUES", SqlDbType.Decimal);
                    SqlParameter pCMH_PENDING = oCommand.Parameters.Add("@CMH_PENDING", SqlDbType.Decimal);

                    foreach (CStruct xI in clnPlanRows)
                    {
                        if (xI.GetBooleanAttr("Changed") == true && xI.GetBooleanAttr("Deleted") == false)
                        {
                            int lUID = xI.GetIntAttr("UID");
                            for (int lPeriod = lStartPeriodID; lPeriod <= lFinishPeriodID; lPeriod++)
                            {
                                bool bFoundH,bFoundF,bFoundM;
                                string suffix = lPeriod.ToString("0");
                                string sHours = xI.GetStringAttr("H" + suffix, "0", out bFoundH);
                                string sFTE = xI.GetStringAttr("F" + suffix, "0", out bFoundF);
                                string sMode = xI.GetStringAttr("M" + suffix, "0", out bFoundM);
                                if (bFoundH || bFoundF || bFoundM)
                                {
                                    double dblHours = Convert.ToDouble(sHours);
                                    int lFTEs = Convert.ToInt32(sFTE);
                                    int lMode = Convert.ToInt32(sMode);
                                    if (dblHours != 0 || lFTEs != 0)
                                    {
                                        pCMT_UID.Value = lUID;
                                        pPRD_ID.Value = lPeriod;
                                        pCMH_HOURS.Value = dblHours;
                                        pCMH_FTES.Value = lFTEs;
                                        pCMH_MODE.Value = lMode;
                                        pCMH_REVENUES.Value = 0.0;
                                        pCMH_PENDING.Value = 0;

                                        oCommand.ExecuteNonQuery();
                                    }
                                }
                                if (bNegotiationMode)
                                {
                                    sHours = xI.GetStringAttr("h" + suffix, "0", out bFoundH);
                                    sFTE = xI.GetStringAttr("f" + suffix, "0", out bFoundF);
                                    sMode = xI.GetStringAttr("m" + suffix, "0", out bFoundM);
                                    if (bFoundH || bFoundF || bFoundM)
                                    {
                                        double dblHours = Convert.ToDouble(sHours);
                                        int lFTEs = Convert.ToInt32(sFTE);
                                        int lMode = Convert.ToInt32(sMode);

                                        pCMT_UID.Value = lUID;
                                        pPRD_ID.Value = lPeriod;
                                        pCMH_HOURS.Value = dblHours;
                                        pCMH_FTES.Value = lFTEs;
                                        pCMH_MODE.Value = lMode;
                                        pCMH_REVENUES.Value = 0.0;
                                        pCMH_PENDING.Value = 1;

                                        oCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

                // update the team - add in any new resources
                if (sTeamPIs != "")
                {
                    string sPIs = sTeamPIs;
                    while (sPIs != "")
                    {
                        int lProjectID3 = vb.val(Common.GetFirstItemFromList(ref sPIs));
                        SqlCommand oCommand = new SqlCommand("EPG_SP_AddPlanResourcesToTeam", _dba.Connection, _dba.Transaction);
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.Parameters.Add("ProjectID", SqlDbType.Int).Value = lProjectID3;
                        oCommand.ExecuteNonQuery();
                    }
                }

                // V4.4 addition to update total hours to custom dec field if specified in admin
                if (oAdmin.ProjectResourceHoursCFID > 0)
                {
                    string sTableName;
                    string sFieldName;
                    if (dbaCustomFields.GetCustomFieldNameFromID(_dba, oAdmin.ProjectResourceHoursCFID, out sTableName, out sFieldName) == StatusEnum.rsSuccess)
                    {
                        string sPIs = sTeamPIs;
                        while (sPIs != "")
                        {
                            int lProjectID3 = vb.val(Common.GetFirstItemFromList(ref sPIs));
                            string s = "UPDATE " + sTableName + " SET " + sFieldName + " =  (SELECT SUM(CMT_HOURS) / 100 FROM EPG_RESOURCEPLANS WHERE RP_ACTIVE_COMMITMENT = 1 AND CMT_PRIVATE = 0 AND CMT_STATUS = 256 AND PROJECT_ID = " + lProjectID3.ToString() + ") WHERE PROJECT_ID = " + lProjectID3.ToString() + "";
                            int lRowsAffected;
                            if (_dba.ExecuteNonQuery(s, (StatusEnum)99999, out lRowsAffected) != StatusEnum.rsSuccess)
                                break;
                        }
                    }
                }


        Exit_Transaction:
                if (_dba.Status == StatusEnum.rsSuccess)
                    _dba.CommitTransaction();
                else
                _dba.RollbackTransaction();

                // do a post costs for each PI NB - this is now done after synchronizeteam
                //if (sTeamPIs != "")
                //{
                //    PostCostValues(sTeamPIs);
                //    //string sPIs = sTeamPIs;
                //    //while (sPIs != "")
                //    //{
                //    //    int lProjectID3 = vb.val(Common.GetFirstItemFromList(ref sPIs));
                //    //    PostCostValues(lProjectID3.ToString("0"));
                //    //}
                //}
            }
            catch (Exception ex)
            {
                _dba.HandleException("SaveResourcePlanXML", (StatusEnum)99999, ex);
                _dba.RollbackTransaction();
            }
            
        Exit_Function:
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool PostCostValues(string sProjectIDs, bool bPublish = true, bool bPublishBaseline = false)
        {
            try
            {
                if (_dba.Open() != StatusEnum.rsSuccess)
                    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());
                CStruct xRequest = new CStruct();
                xRequest.Initialize("Request");
                CStruct xSet = xRequest.CreateSubStruct("EPKSet");
                xSet.CreateString("EPKAuth", "");
                CStruct xProcess = xSet.CreateSubStruct("EPKProcess");
                // SetSaveRPCostValues = 3
                xProcess.CreateInt("RequestNo", 3);
                xProcess.CreateString("PIs", sProjectIDs);
                if (bPublish) xProcess.CreateBoolean("Publish", true);
                if (bPublishBaseline) xProcess.CreateBoolean("PublishBaseline", true);

                const string sCommand = "INSERT INTO EPG_JOBS(JOB_GUID,JOB_CONTEXT,JOB_SESSION,WRES_ID,JOB_SUBMITTED,JOB_STATUS,JOB_COMMENT,JOB_CONTEXT_DATA) VALUES(@JOB_GUID,@JOB_CONTEXT,@JOB_SESSION,@WRES_ID,@JOB_SUBMITTED,@JOB_STATUS,@JOB_COMMENT,@JOB_CONTEXT_DATA)";
                SqlCommand cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                cmd.Parameters.AddWithValue("@JOB_GUID", Guid.NewGuid());
                //    qjcCustom = 0
                cmd.Parameters.AddWithValue("@JOB_CONTEXT", 0);
                cmd.Parameters.AddWithValue("@JOB_SESSION", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@WRES_ID", _dba.UserWResID);
                cmd.Parameters.AddWithValue("@JOB_SUBMITTED", DateTime.Now);
                cmd.Parameters.AddWithValue("@JOB_STATUS", 0); // For now let 0 mean Not Started
                cmd.Parameters.AddWithValue("@JOB_COMMENT", "RPE Post for ProjectIDs " + sProjectIDs);
                cmd.Parameters.AddWithValue("@JOB_CONTEXT_DATA", xRequest.XML());
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                _dba.HandleException("PostCostValues", (StatusEnum)99999, ex);
            }
            finally { _dba.Close(); }
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private bool GetResourcePlanViewsXML(out CStruct xReply)
        {
            CStruct xRPE = new CStruct();
            xRPE.Initialize("Views");

            //string sCommand = "SELECT VIEW_GUID,VIEW_NAME,VIEW_PERSONAL,VIEW_DEFAULT FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND (WRES_ID=0 OR WRES_ID=" + this._userWResID.ToString() + ") ORDER BY VIEW_DEFAULT DESC,WRES_ID DESC,VIEW_NAME";
            string sCommand = "SELECT VIEW_DEFAULT,VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND (WRES_ID=0 OR WRES_ID=" + _userWResID.ToString("0") + ") ORDER BY VIEW_DEFAULT DESC,WRES_ID DESC,VIEW_NAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
            SqlDataReader reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                CStruct xView = new CStruct();
                //CStruct xView = xRPE.CreateSubStruct("View");
                //xView.CreateGuidAttr("ViewGUID", DBAccess.ReadGuidValue(reader["VIEW_GUID"]));
                //xView.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["VIEW_NAME"]));
                //xView.CreateBooleanAttr("Personal", DBAccess.ReadBoolValue(reader["VIEW_PERSONAL"]));
                //xView.CreateBooleanAttr("Default", DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]));
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                {
                    xView.LoadXML(sXML);
                    xView.SetBooleanAttr("Default", DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]));
                    xRPE.AppendSubStruct(xView);
                }
            }
            reader.Close();
            xReply = xRPE;
            //        Exit_Function:
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool GetResourcePlanViewXML(Guid guidView, out string sReply)
        {
            CStruct xView = new CStruct();
            //xView.Initialize("View");

            const string sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND VIEW_GUID=@VIEW_GUID";
            //string sCommand = "SELECT WAU_UID,UINF_VIEWNAME,UINF_XML FROM EPGT_LOCALVIEWS WHERE UINF_VIEWNAME=" + _dba.PrepareText(sViewName) + " ORDER BY UINF_VIEWNAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
            oCommand.Parameters.AddWithValue("@VIEW_GUID", guidView);
            SqlDataReader reader = oCommand.ExecuteReader();
            if (reader.Read())
            {
                //Guid guidView2 = DBAccess.ReadGuidValue(reader["VIEW_GUID"]);
                //string sName = DBAccess.ReadStringValue(reader["VIEW_NAME"]);
                //bool bPersonal = DBAccess.ReadBoolValue(reader["VIEW_PERSONAL"]);
                //bool bDefault = DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]);
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                    xView.LoadXML(sXML);
                //xView.SetIntAttr("ViewUID", nUID);
                //xView.SetStringAttr("Name", sName);
                //xView.SetBooleanAttr("Personal", bPersonal);
                //xView.SetBooleanAttr("Default", bDefault);
            }
            reader.Close();
            sReply = xView.XML();
            //        Exit_Function:
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        //public bool SaveResourcePlanViewXML(Guid guidView, string sName, bool bPersonal, bool bDefault, string sData)
        //{
        //    //SqlCommand cmd = new SqlCommand("DELETE FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND VIEW_UID=@", _dba.Connection, _dba.Transaction);
        //    //cmd.Parameters.AddWithValue("VIEW_UID", nViewUID);
        //    //int lRowsAffected = cmd.ExecuteNonQuery();
        //    string sCommand;
        //    sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@,WRES_ID=@,VIEW_DEFAULT=@,VIEW_DATA=@,VIEW_CONTEXT=30000 WHERE VIEW_GUID=@";
        //    SqlCommand cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
        //    cmd.Parameters.AddWithValue("VIEW_NAME", sName);
        //    cmd.Parameters.AddWithValue("WRES_ID", bPersonal @ this._userWResID : 0);
        //    cmd.Parameters.AddWithValue("VIEW_DEFAULT", bDefault);
        //    cmd.Parameters.AddWithValue("VIEW_DATA", sData);
        //    cmd.Parameters.AddWithValue("VIEW_GUID", guidView);
        //    int nRowsAffected = cmd.ExecuteNonQuery();

        //    if (nRowsAffected == 0)
        //    {
        //        sCommand = "INSERT INTO EPG_VIEWS (VIEW_GUID,VIEW_NAME,WRES_ID,VIEW_DEFAULT,VIEW_DATA,VIEW_CONTEXT) VALUES(@,@,@,@,@,30000)";
        //        cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
        //        cmd.Parameters.AddWithValue("VIEW_GUID", guidView);
        //        cmd.Parameters.AddWithValue("VIEW_NAME", sName);
        //        cmd.Parameters.AddWithValue("WRES_ID", bPersonal @ this._userWResID : 0);
        //        cmd.Parameters.AddWithValue("VIEW_DEFAULT", bDefault);
        //        cmd.Parameters.AddWithValue("VIEW_DATA", sData);
        //        nRowsAffected = cmd.ExecuteNonQuery();
        //    }

        //    return (_dba.Status == StatusEnum.rsSuccess);
        //}

        //public bool DeleteResourcePlanViewXML(Guid guidView)
        //{
        //    string sCommand = "DELETE FROM EPG_VIEWS WHERE VIEW_GUID=@";
        //    SqlCommand cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
        //    cmd.Parameters.AddWithValue("VIEW_GUID", guidView);
        //    int nRowsAffected = cmd.ExecuteNonQuery();
        //    return (_dba.Status == StatusEnum.rsSuccess);
        //}

        private static StatusEnum GetPeriods(DBAccess dba, int iCal, out List<CPeriod> clnPeriods)
        {
            clnPeriods = null;
            try
            {
                clnPeriods = new List<CPeriod>();

                SqlCommand oCommand = new SqlCommand("EPG_SP_ReadPeriods", dba.Connection);
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add("CalID", SqlDbType.Int).Value = iCal;
                SqlDataReader reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    CPeriod oPeriod;
                    CopyRSToPeriod(reader, out oPeriod);
                    clnPeriods.Add(oPeriod);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                return dba.HandleException("GetPeriods", (StatusEnum)99999, ex);
            }
            return StatusEnum.rsSuccess;
        }

        private static void CopyRSToPeriod(SqlDataReader reader, out CPeriod oPeriod)
        {
            //bool bNull = false;
            oPeriod = new CPeriod();
            oPeriod.PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
            oPeriod.PeriodName = DBAccess.ReadStringValue(reader["PRD_NAME"]);
            oPeriod.StartDate = DBAccess.ReadDateValue(reader["PRD_START_DATE"]);
            oPeriod.FinishDate = DBAccess.ReadDateValue(reader["PRD_FINISH_DATE"]);
            oPeriod.Closed = DBAccess.ReadIntValue(reader["PRD_IS_CLOSED"]);
            oPeriod.ClosedDate = DBAccess.ReadDateValue(reader["PRD_CLOSED_DATE"]);
            oPeriod.ClosedName = DBAccess.ReadStringValue(reader["PRD_CLOSED_NAME"]);
        }

        //private static StatusEnum ReadUserInfo(DBAccess dba, int lWResID, UserInfoContextsEnum eContext, out int lData, out string sXML)
        //{
        //    string sCommand = "SELECT * FROM EPG_USERINFO WHERE WRES_ID = " + lWResID.ToString("0") + " AND UINF_CONTEXT = " + ((int)eContext).ToString("0");
        //    SqlCommand oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
        //    SqlDataReader reader = oCommand.ExecuteReader();

        //    lData = 0;
        //    sXML = "";
        //    if (reader.Read())
        //    {
        //        lData = DBAccess.ReadIntValue(reader["UINF_DATA"]);
        //        sXML = DBAccess.ReadStringValue(reader["UINF_XML"]);
        //    }
        //    return StatusEnum.rsSuccess;
        //}
       
        //public bool GetCostCategoryRolesXML(out string sReply)
        //{
        //    sReply = "";

        //    CAdmin oAdmin = new CAdmin();
        //    if (oAdmin.GetAdminInfo(_dba) != StatusEnum.rsSuccess)
        //        goto Exit_Function;
        //    CStruct xCostCategoryRoles;
        //    if (DBCommon.GetCostCategoryRolesStruct(_dba, oAdmin.PortfolioCommitmentsCalendarUID, 1, out xCostCategoryRoles) != StatusEnum.rsSuccess)
        //        goto Exit_Function;

        //    //        Exit_Function:
        //    sReply = xCostCategoryRoles.XML();
        //Exit_Function:
        //    return (_dba.Status == StatusEnum.rsSuccess);
        //}

        private static CStruct BuildResultStruct(string sFunction, int nStatus = 0, string sStatus = "")
        {
            CStruct xResult = new CStruct();
            xResult.Initialize("Result");
            xResult.CreateStringAttr("Function", sFunction);
            xResult.CreateIntAttr("Status", nStatus);
            if (sStatus != "")
                xResult.CreateStringAttr("Message", sStatus);
            return xResult;
        }

        private static string HandleError(string sFunction, int nStatus, string sError)
        {
            CStruct xResult = BuildResultStruct(sFunction, nStatus);
            CStruct xGrid = xResult.CreateSubStruct("Grid");
            CStruct xIO = xGrid.CreateSubStruct("IO");
            xIO.CreateIntAttr("Result", 0);
            xIO.CreateStringAttr("Message", sError);
            CStruct xError = xResult.CreateSubStruct("Error");
            //xError.Value = sError;
            xError.CreateIntAttr("ID", nStatus);
            xError.CreateStringAttr("Value", sError);
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            CStruct xBody = xGrid.CreateSubStruct("Body");
            //xBody.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            return xResult.XML();
        }

        private static string HandleException(string sFunction, int nStatus, Exception ex)
        {
            return HandleError(sFunction, nStatus, "Exception in ResourcePlans." + sFunction + " : '" + ex.Message + "'");
        }
    }
}
