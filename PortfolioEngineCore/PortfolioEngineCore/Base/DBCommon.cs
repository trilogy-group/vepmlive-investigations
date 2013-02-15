using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace PortfolioEngineCore
{
    class DBCommon
    {
        public static StatusEnum ReadUserInfo(DBAccess dba, int lWResID, UserInfoContextsEnum eContext, out int lData, out string sXML)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            string sCommand = "SELECT * FROM EPG_USERINFO WHERE WRES_ID = " + lWResID.ToString() + " AND UINF_CONTEXT = " + ((int)eContext).ToString();
            SqlCommand oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
            SqlDataReader reader = oCommand.ExecuteReader();

            lData = 0;
            sXML = "";
            if (reader.Read())
            {
                lData = DBAccess.ReadIntValue(reader["UINF_DATA"]);
                sXML = DBAccess.ReadStringValue(reader["UINF_XML"]);
            }
            return eStatus;
        }

        public static StatusEnum ReadSystemInfo(DBAccess dba, int lContextID, UserInfoContextsEnum eContext, out string sXML)
        {
            //bool bNull = false;
            StatusEnum eStatus = StatusEnum.rsSuccess;
            string sCommand = "";
            sCommand = "SELECT * FROM EPG_SYSTEM_INFO WHERE SI_CONTEXT_ID = " + lContextID.ToString() + " AND SI_CONTEXT = " + ((int)eContext).ToString();
            SqlCommand oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
            SqlDataReader reader = oCommand.ExecuteReader();
            sXML = "";
            if (reader.Read())
            {
                sXML = DBAccess.ReadStringValue(reader["SI_XML"]);
            }
            return eStatus;
        }

        public static StatusEnum GetUserButtonsStruct(DBAccess dba, string sButtonCodes, out CStruct xUserButtons)
        {
            xUserButtons = null;
            StatusEnum eStatus = StatusEnum.rsSuccess;
            try
            {
                string sCommand = "SELECT * FROM EPGT_USERBUTTONS WHERE BTN_PAGE IN (" + sButtonCodes + ") ORDER BY BTN_PAGE, BTN_SEQ";
                SqlCommand oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                SqlDataReader reader = oCommand.ExecuteReader();
                xUserButtons = new CStruct();
                xUserButtons.Initialize("GUB");

                if (reader.HasRows)
                {
                    //bool bNull = false;
                    CStruct xUserButton;
                    while (reader.Read())
                    {
                        xUserButton = xUserButtons.CreateSubStruct("USRBUT");

                        xUserButton.CreateIntAttr("PageID", DBAccess.ReadIntValue(reader["BTN_PAGE"]));
                        xUserButton.CreateString("Caption", DBAccess.ReadStringValue(reader["BTN_CAPTION"]));
                        xUserButton.CreateString("Tooltip", DBAccess.ReadStringValue(reader["BTN_TOOLTIP"]));
                        xUserButton.CreateString("Image", DBAccess.ReadStringValue(reader["BTN_IMAGE"]));
                        xUserButton.CreateString("Key", DBAccess.ReadStringValue(reader["BTN_ACCESSKEY"]));
                        xUserButton.CreateString("Width", DBAccess.ReadStringValue(reader["BTN_WIDTH"]));
                        xUserButton.CreateString("XMLTag", DBAccess.ReadStringValue(reader["BTN_XMLTAG"]));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleException("GetUserButtonsStruct", (StatusEnum)99999, ex);
            }
            return eStatus;
        }

        public static StatusEnum ReadPlanViewFields(DBAccess dba, int lViewUID, out List<CTSFieldDefinition> clnFields)
        {
            clnFields = null;
            try
            {
                SqlCommand oCommand = null;
                SqlDataReader reader = null;
                oCommand = new SqlCommand("EPG_SP_ReadViewFieldDefinitions", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("ViewTypeID", SqlDbType.Int).Value = (int)ViewTypeEnum.vtResourcePlan;
                oCommand.Parameters.Add("ViewUID", SqlDbType.Int).Value = lViewUID;
                reader = oCommand.ExecuteReader();


                clnFields = new List<CTSFieldDefinition>();
                //bool bNull = false;
                CTSFieldDefinition oTSFieldDefinition;
                //SpecialFieldIDsEnum eFieldID;
                while (reader.Read())
                {
                    if (CopyRSToRPFieldDefinition(dba, reader, out oTSFieldDefinition) != StatusEnum.rsSuccess)
                        break;
                    clnFields.Add(oTSFieldDefinition);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                return dba.HandleException("ReadPlanViewFields", (StatusEnum)99999, ex);
            }
            return StatusEnum.rsSuccess;
        }

        private static StatusEnum CopyRSToRPFieldDefinition(DBAccess dba, SqlDataReader reader, out CTSFieldDefinition oTSFieldDefinition)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            oTSFieldDefinition = new CTSFieldDefinition();
            try
            {
                bool bNull = false;
                oTSFieldDefinition.FieldID = DBAccess.ReadIntValue(reader["FIELD_ID"]);
                oTSFieldDefinition.Title = DBAccess.ReadStringValue(reader["FIELD_TITLE"]);
                oTSFieldDefinition.Align = (TSFieldAlignEnum)DBAccess.ReadIntValue(reader["FIELD_ALIGN"]);
                oTSFieldDefinition.Hidden = DBAccess.ReadBoolValue(reader["FIELD_HIDDEN"]);
                oTSFieldDefinition.Frozen = DBAccess.ReadBoolValue(reader["FIELD_FROZEN"]);
                oTSFieldDefinition.SQLName = DBAccess.ReadStringValue(reader["FIELD_NAME_SQL"]);

                oTSFieldDefinition.Format = (TSFieldFormatEnum)DBAccess.ReadIntValue(reader["FIELD_FORMAT"]);

                string lFieldID = "";
                lFieldID = DBAccess.ReadStringValue(reader["FA_FIELD_ID"], out bNull);
                if (bNull)
                {
                    oTSFieldDefinition.IsCategory = false;
                }
                else
                {
                    oTSFieldDefinition.IsCategory = true;
                    oTSFieldDefinition.CategoryListID = DBAccess.ReadIntValue(reader["FA_LOOKUP_UID"]);
                    oTSFieldDefinition.CategorySelectListLeafOnly = DBAccess.ReadBoolValue(reader["FA_LEAFONLY"]);
                    oTSFieldDefinition.CategoryUseFullName = DBAccess.ReadBoolValue(reader["FA_USEFULLNAME"]);
                    oTSFieldDefinition.CategoryIsIdentity = DBAccess.ReadBoolValue(reader["FA_VALUE_UNIQUE"]);
                }
            }
            catch (Exception ex)
            {
                dba.HandleException("CopyRSToRPFieldDefinition", (StatusEnum)99999, ex);
            }
            return eStatus;
        }

        public static StatusEnum GetPeriods(DBAccess dba, int iCal, out List<CPeriod> clnPeriods)
        {
            clnPeriods = null;
            try
            {
                clnPeriods = new List<CPeriod>();

                SqlCommand oCommand = new SqlCommand("EPG_SP_ReadPeriods", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("CalID", SqlDbType.Int).Value = iCal;
                SqlDataReader reader = oCommand.ExecuteReader();

                CPeriod oPeriod;
                while (reader.Read())
                {
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

        public static StatusEnum GetCostCategoryRolesStruct(DBAccess dba, int lPortfolioCommitmentsCalendarUID, int lStartPeriodID, out CStruct xCostCategoryRolesOut, bool bGetAll = false)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            xCostCategoryRolesOut = null;
            //List<CStruct> cln;
            Dictionary<string, CStruct> dic;

           if (GetCostCategoryRoles(dba, lPortfolioCommitmentsCalendarUID, lStartPeriodID, out dic, bGetAll) != StatusEnum.rsSuccess)
                    goto Exit_Function;
 
            // Now add the relevant cost category/role rows into the XML

            CStruct xCostCategoryRoles;
            xCostCategoryRoles = new CStruct();
            xCostCategoryRoles.Initialize("CostCategoryRoles");
            foreach (CStruct xCostCategoryRole in dic.Values)
            {
                xCostCategoryRoles.AppendSubStruct(xCostCategoryRole);
            }

            xCostCategoryRolesOut = xCostCategoryRoles;

        Exit_Function:
            return eStatus;
        }


        // jwg 3/22/12 - added an optional paramter to control getting ALL the data (ftes etc) for ALl cost category rows

        public static StatusEnum GetCostCategoryRoles(DBAccess dba, int lPortfolioCommitmentsCalendarUID, int lStartPeriodID, out Dictionary<string, CStruct> dicCostCategoryRolesOut, bool bGetAll = false)
        {
            dicCostCategoryRolesOut = null;
            try
            {
                dicCostCategoryRolesOut = new Dictionary<string, CStruct>();

                // Read in the cost categories with role names
                // NB the rows are presented in reverse order - this makes it easier to determine which ones have roles as a leaf
                SqlCommand oCommand = new SqlCommand("EPG_SP_ReadCostCategoryWithRoles", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = oCommand.ExecuteReader();

                string sName = "";
                int lLevel = 0;
                int lNextValidLevel = 0;
                int lRoleUID = 0;
                int lCostCategoryUID = 0;
                bool bAdd = false;
                //List<CStruct> cln = new List<CStruct>();
                Dictionary<string, CStruct> dic = new Dictionary<string, CStruct>();
                string sCostCategoryUIDs = "";

                CStruct xCostCategoryRole;
                while (reader.Read())
                {
                    lRoleUID = DBAccess.ReadIntValue(reader["BC_ROLE"]);
                    lCostCategoryUID = DBAccess.ReadIntValue(reader["BC_UID"]); 
                    lLevel = DBAccess.ReadIntValue(reader["BC_LEVEL"]);

                    bAdd = false;
                    if (lRoleUID > 0 || bGetAll == true || lLevel == lNextValidLevel)
                    {
                        bAdd = true;
                        lNextValidLevel = lLevel - 1;

                        if (lRoleUID > 0 || bGetAll == true)
                        {
                            // Build up list of cost categories with associated roles - use to get FTEs later
                            Common.AddIDToList(ref sCostCategoryUIDs, lCostCategoryUID);
                        }
                    }

                    if (bAdd || (bGetAll == true))
                    {
                        xCostCategoryRole = new CStruct();
                        xCostCategoryRole.Initialize("CostCategoryRole");
                        xCostCategoryRole.CreateIntAttr("ID", lCostCategoryUID);
                        xCostCategoryRole.CreateIntAttr("Level", lLevel);
                        if (lRoleUID > 0)
                            xCostCategoryRole.CreateIntAttr("RoleUID", lRoleUID);
                        sName = DBAccess.ReadStringValue(reader["RoleName"]);
                        if (sName == "")
                            sName = DBAccess.ReadStringValue(reader["BC_NAME"]);
                        xCostCategoryRole.CreateStringAttr("Name", sName);
                        dic.Add(lCostCategoryUID.ToString(), xCostCategoryRole);
                    }
                }
                reader.Close();


                // Pick up the FTE conversion factor information
                if (sCostCategoryUIDs != "" && lPortfolioCommitmentsCalendarUID >= 0 && lStartPeriodID > 0)
                {
                    oCommand = new SqlCommand("EPG_SP_ReadFTEs", dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.Add("CalID", SqlDbType.Int).Value = lPortfolioCommitmentsCalendarUID;
                    oCommand.Parameters.Add("FromPeriodID", SqlDbType.Int).Value = lStartPeriodID;
                    oCommand.Parameters.Add("CostCategoryUIDs", SqlDbType.VarChar, sCostCategoryUIDs.Length).Value = sCostCategoryUIDs;
                    reader = oCommand.ExecuteReader();

                    int lPrevCostCategoryUID = 0;
                    string sFTEToHours = "";
                    string sPeriods = "";
                    int lPeriodID = 0;
                    int lFTEToHours = 0;
                    sPeriods = "";
                    sFTEToHours = "";

                    while (reader.Read())
                    {
                        lCostCategoryUID = DBAccess.ReadIntValue(reader["CostCategoryUID"]);
                        if (lCostCategoryUID != lPrevCostCategoryUID)
                        {
                            if (sPeriods != "")
                            {
                                if (dic.TryGetValue(lPrevCostCategoryUID.ToString(), out xCostCategoryRole))
                                {
                                    xCostCategoryRole.CreateString("Periods", sPeriods);
                                    xCostCategoryRole.CreateString("FTEToHours", sFTEToHours);
                                }
                            }
                            sPeriods = "";
                            sFTEToHours = "";
                            lPrevCostCategoryUID = lCostCategoryUID;
                        }
                        lPeriodID = DBAccess.ReadIntValue(reader["PeriodID"]);
                        sPeriods = Common.AppendItemToList(sPeriods, lPeriodID.ToString());
                        lFTEToHours = DBAccess.ReadIntValue(reader["FTE"]);
                        sFTEToHours = Common.AppendItemToList(sFTEToHours, lFTEToHours.ToString());
                    }

                    reader.Close();
                    if (sPeriods != "")
                    {
                        if (dic.TryGetValue(lPrevCostCategoryUID.ToString(), out xCostCategoryRole))
                        {
                            xCostCategoryRole.CreateString("Periods", sPeriods);
                            xCostCategoryRole.CreateString("FTEToHours", sFTEToHours);
                        }
                    }
                }


                // Calculate the full name of each cost category

                string[] sLevelName = new string[100];
                int[] lLevelID = new int[100];
                int l = 0;
                string sParentName = "";

                // jwg 3/22/12 because the sproc orders the values by BC_ID decending this code used to assign the children to the wrong parent.... 
                // the dictonary needs to be processed in the reverse order


                //foreach (CStruct xCostCategoryRole2 in dic.Values)
                // replace with 

                CStruct xCostCategoryRole2;

                List<CStruct> RevAccess = new List<CStruct>();
                foreach (CStruct xCostCategoryRole3 in dic.Values)
                    RevAccess.Add(xCostCategoryRole3);

                for (int i = RevAccess.Count - 1; i >= 0; i--)
                {
                   
                    xCostCategoryRole2 = RevAccess[i];

                    // jwg 3/22/12 end of replace

                    lLevel = xCostCategoryRole2.GetIntAttr("Level");
                    sLevelName[lLevel] = xCostCategoryRole2.GetStringAttr("Name");
                    lLevelID[lLevel] = xCostCategoryRole2.GetIntAttr("ID");
                    if (lLevel > 1)
                    {
                        for (l = 1; l <= lLevel - 1; l++)
                        {
                            if (l == 1)
                            {
                                sParentName = sLevelName[l];
                            }
                            else
                            {
                                sParentName = sParentName + "." + sLevelName[l];
                            }
                        }
                        xCostCategoryRole2.CreateStringAttr("ParentName", sParentName);
                        xCostCategoryRole2.CreateIntAttr("ParentID", lLevelID[lLevel - 1]);
                    }
                }

                // return a collection of cstructs indexed by Cost Category UID
                dicCostCategoryRolesOut = dic;
            }
            catch (Exception ex)
            {
                return dba.HandleException("GetCostCategoryRoles", (StatusEnum)99999, ex);
            }
            return StatusEnum.rsSuccess;
        }
        public static StatusEnum GetLookupListXML(DBAccess dba, int lLookupID, out CStruct xReply)
        {
            return GetLookupListXML(dba, lLookupID, out xReply, "LookupList");
        }

        public static StatusEnum GetLookupListXML(DBAccess dba, int lLookupID, out CStruct xReply, string sLookupName)
        {
            xReply = null;
            try
            {
                CStruct oLookupListItems;
                CStruct oLookupListItem;

                CStruct oLookupList = new CStruct();
                oLookupList.Initialize(sLookupName);
                oLookupList.CreateIntAttr("ListUID", lLookupID);
                oLookupListItems = oLookupList.CreateSubStruct("Items");

                if (lLookupID > 0)
                {
                    // Read field from LOOKUP_VALUES and get its list id
                    SqlCommand oCommand = new SqlCommand("EPG_SP_ReadListItems", dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.Add("LookupUID", SqlDbType.Int).Value = lLookupID;
                    SqlDataReader reader = oCommand.ExecuteReader();

                    bool bInactive = false;
                    while (reader.Read())
                    {
                        oLookupListItem = oLookupListItems.CreateSubStruct("Item");
                        oLookupListItem.CreateIntAttr("ID", DBAccess.ReadIntValue(reader["LV_UID"]));
                        oLookupListItem.CreateIntAttr("Level", DBAccess.ReadIntValue(reader["LV_LEVEL"]));
                        oLookupListItem.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["LV_VALUE"]));
                        bInactive = DBAccess.ReadBoolValue(reader["LV_INACTIVE"]);
                        if (bInactive)
                            oLookupListItem.CreateBooleanAttr("Inactive", bInactive);
                    }
                    reader.Close();
                }
                xReply = oLookupList;
            }
            catch (Exception ex)
            {
                return dba.HandleException("GetCostCategoryRoles", (StatusEnum)99999, ex);
            }
            return StatusEnum.rsSuccess;
        }

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

    }
}
