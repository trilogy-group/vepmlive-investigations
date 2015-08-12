using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PortfolioEngineCore
{
    internal class ResourceSelector : PFEBase
    {

        public ResourceSelector(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading ResourceSelector Class");
        }

        public ResourceSelector(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading ResourceSelector Class");
        }

        public bool ReadResources(int lSearchMode,
                                    string sSeekWResIDs,
                                    string sAdvancedQueryXML,
                                    string sDisplayFieldsXML,
                                    bool bIncludeInactive,
                                    bool bIncludeUsers,
                                    bool bIncludeGenerics,
                                    out string sReply)
        {
            bool bIgnoreSecurity = false;
            sReply = "";
            try
            {
                // Decode the request parameters
                // SearchMode = 0 = My Resources
                // SearchMode = 1 = Simple find - begins
                // SearchMode = 2 = Simple find - contains
                // SearchMode = 3 = Simple find - WResID list
                // SearchMode = 4 = Simple find - multiple contains e.g. tom,fred,john
                // SearchMode = 9 = Advanced

                // Get uid list of resources this user can view
                string sWResIDs = "";
                Security.GetResourcesUserCanView(_dba, _userWResID, out sWResIDs);

                //bool bNull = false;
                TSFieldFormatEnum eFieldFormat;
                SpecialFieldIDsEnum eFieldID;
                string sName = "";

                int lRowLimit = 0;
                bool bIgnoreLimit = false;
                int lCCRoleUID = 0;

                CStruct xQuery = null;
                if (sAdvancedQueryXML != "")
                {
                    xQuery = new CStruct();
                    xQuery.LoadXML(sAdvancedQueryXML);
                }

                List<CStruct> clnDisplayFields = null;
                CStruct xResourceDisplayFields = null;
                if (sDisplayFieldsXML != "")
                {
                    xResourceDisplayFields = new CStruct();
                    xResourceDisplayFields.LoadXML(sDisplayFieldsXML);
                    if (xResourceDisplayFields != null)
                    {
                        lRowLimit = xResourceDisplayFields.GetInt("RowLimit");
                        bIgnoreLimit = xResourceDisplayFields.GetBoolean("IgnoreLimit");

                        CStruct xItems = xResourceDisplayFields.GetSubStruct("Items");
                        clnDisplayFields = xItems.GetList("Item");
                    }
                }
                if (lRowLimit <= 0)
                    lRowLimit = 250;

                string sCommand = BuildResourceSelectQuery(_dba, lSearchMode, xQuery, this._userWResID, clnDisplayFields, sSeekWResIDs, bIncludeUsers, bIncludeInactive, IncludeGenericsEnum.igNo);

                SqlCommand oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                SqlDataReader reader = oCommand.ExecuteReader();

                CStruct xResourcesSelected = new CStruct();
                xResourcesSelected.Initialize("ResourcesSelected");
                xResourcesSelected.CreateInt("WResID", _dba.UserWResID);
                if (xResourceDisplayFields != null)
                    xResourcesSelected.AppendSubStruct(xResourceDisplayFields);
                CStruct xResources = xResourcesSelected.CreateSubStruct("Resources");

                int lCount = 0;
                if (reader.HasRows)
                {
                    //int lRUID = 0;
                    //int lWResID = 0;
                    //ResourceTypeEnum eType;
                    //string sNotes = "";
                    bool bIncludeGroups = false;
                    bool bIncludeMVCodes = false;
                    bool bIncludeCostCategoryNames = false;
                    bool bIncludeRoleNames = false;
                    SortedList<string, CStruct> lstResources = new SortedList<string, CStruct>();
                    string sGroupWResIDs = "";
                    bool bAdd = false;
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    reader.Dispose();
                    foreach (DataRow row in dt.Rows)
                    {
                        bAdd = true;
                        int lWResID = DBAccess.ReadIntValue(row["WRES_ID"]);
                        if (bAdd && bIgnoreSecurity == false)
                        {
                            if (Common.IsIDInList(sWResIDs, lWResID) == false)
                                bAdd = false;
                        }
                        if (bAdd)
                        {
                            lCount++;
                            //if (bIgnoreLimit == false && lCount > lRowLimit)
                            //    goto RowLimtExceeded;
                            Common.AddIDToList(ref sGroupWResIDs, lWResID);
                            CStruct xResource = xResources.CreateSubStruct("Resource");
                            xResource.CreateInt("WResID", lWResID);
                            xResource.CreateString("ResourceName", DBAccess.ReadStringValue(row["RES_NAME"]));
                            string sNotes = DBAccess.ReadStringValue(row["MR_NOTES"]);
                            if (sNotes != "")
                                xResource.CreateString("Notes", sNotes);

                            ResourceTypeEnum eType = ResourceTypeEnum.rtUser;
                            if (DBAccess.ReadIntValue(row["WRES_IS_GENERIC"]) == 1)
                                eType = ResourceTypeEnum.rtGeneric;
                            else if (DBAccess.ReadIntValue(row["WRES_IS_RESOURCE"]) == 1)
                                eType = ResourceTypeEnum.rtResource;

                            xResource.CreateInt("Type", (int)eType);
                            xResource.CreateInt("Status", (int)(DBAccess.ReadIntValue(reader["WRES_INACTIVE"]) == 1 ? ResourceStatusEnum.rsInactive : ResourceStatusEnum.rsActive));

                            lCCRoleUID = DBAccess.ReadIntValue(row["CCRoleUID"]);
                            if (lCCRoleUID > 0)
                            {
                                xResource.CreateInt("CCRoleUID", lCCRoleUID);
                            }

                            if (clnDisplayFields != null)
                            {
                                foreach (CStruct xItem in clnDisplayFields)
                                {
                                    eFieldFormat = (TSFieldFormatEnum)xItem.GetIntAttr("FieldFormat");
                                    eFieldID = (SpecialFieldIDsEnum)xItem.GetIntAttr("FieldID");
                                    sName = "Field" + ((int)eFieldID).ToString("0");
                                    switch (eFieldFormat)
                                    {
                                        case TSFieldFormatEnum.ffCode:
                                            xResource.CreateString(sName, DBAccess.ReadStringValue(reader[sName]));
                                            break;
                                        case TSFieldFormatEnum.ffText:
                                            switch (eFieldID)
                                            {
                                                case SpecialFieldIDsEnum.sfResourceName:
                                                case SpecialFieldIDsEnum.sfResourceNotes:
                                                case SpecialFieldIDsEnum.sfResourceEMail:
                                                    break;
                                                case SpecialFieldIDsEnum.sfResourceCostCategory:
                                                    bIncludeCostCategoryNames = true;
                                                    break;
                                                case SpecialFieldIDsEnum.sfRoleName:
                                                    bIncludeRoleNames = true;
                                                    break;
                                                default:
                                                    xResource.CreateString(sName, DBAccess.ReadStringValue(row[sName]));
                                                    break;
                                            }
                                            break;
                                        case TSFieldFormatEnum.ffGroups:
                                            bIncludeGroups = true;
                                            break;
                                        case TSFieldFormatEnum.ffMVCode:
                                            bIncludeMVCodes = true;
                                            break;
                                        case TSFieldFormatEnum.ffCustom:
                                            switch (eFieldID)
                                            {
                                                case SpecialFieldIDsEnum.sfResourceRate:
                                                    xResource.CreateString(sName, DBAccess.ReadStringValue(row[sName]));
                                                    break;
                                            }
                                            break;
                                    }
                                }
                            }
                            lstResources.Add(lWResID.ToString("0"), xResource);
                        }
                    }
                    reader.Close();

                    // need to make sure these are included
                    bIncludeCostCategoryNames = true;
                    bIncludeRoleNames = true;


                    if (bIncludeCostCategoryNames || bIncludeRoleNames)
                    {
                        Dictionary<string, CStruct> dicCostCategoryRoles;
                        if (GetCostCategoryRoles(_dba, -1, 0, out dicCostCategoryRoles) == StatusEnum.rsSuccess)
                        {
                            string sFullName = "";

                            CStruct[] xArr = new CStruct[lstResources.Values.Count];
                            lstResources.Values.CopyTo(xArr, 0);

                            foreach (CStruct xResource in xArr)
                            {
                                lCCRoleUID = xResource.GetInt("CCRoleUID");
                                if (lCCRoleUID > 0)
                                {
                                    CStruct xCostCategoryRole = null; ;
                                    dicCostCategoryRoles.TryGetValue(lCCRoleUID.ToString(), out xCostCategoryRole);
                                    // BUGFIX 28May09 V60 CRL - Handle Invalid CCRole allocation
                                    if (xCostCategoryRole == null)
                                    {
                                        sName = "InvalidCCNoRole" + lCCRoleUID.ToString("0");
                                        sFullName = sName;
                                    }
                                    else
                                    {
                                        sName = xCostCategoryRole.GetStringAttr("Name");
                                        sFullName = xCostCategoryRole.GetStringAttr("ParentName") + "." + sName;
                                    }

                                    if (bIncludeCostCategoryNames)
                                    {
                                        xResource.CreateString("Field" + ((int)SpecialFieldIDsEnum.sfResourceCostCategory).ToString("0"), sFullName);
                                    }
                                    if (bIncludeRoleNames)
                                    {
                                        xResource.CreateString("Field" + ((int)SpecialFieldIDsEnum.sfRoleName).ToString("0"), sName);
                                    }
                                }
                            }
                        }
                    }

                    // Now the task, if selected, of adding resource groups info
                    if (bIncludeGroups && sGroupWResIDs != "")
                    {
                        sCommand = "SELECT WR.WRES_ID,GROUP_NAME"
                                 + "  FROM EPG_RESOURCES WR"
                                 + "  LEFT JOIN EPG_GROUP_MEMBERS SGM ON SGM.MEMBER_UID = WR.WRES_ID"
                                 + "  LEFT JOIN EPG_GROUPS SG ON SG.GROUP_ID = SGM.GROUP_ID AND GROUP_ENTITY = 1"
                                 + " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sGroupWResIDs + "') LT on WR.WRES_ID=LT.TokenVal"
                                 + " WHERE GROUP_NAME IS NOT NULL ORDER BY WR.RES_NAME";
                        //sCommand = "SELECT WRES_ID,GROUP_NAME"
                        //        + "  FROM EPG_RESOURCES WR"
                        //        + "  LEFT JOIN EPG_GROUP_MEMBERS SGM ON SGM.MEMBER_UID = WR.WRES_ID"
                        //        + "  LEFT JOIN EPG_GROUPS SG ON SG.GROUP_ID = SGM.GROUP_ID"
                        //        + " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sGroupWResIDs + "') LT on WRES_ID=LT.TokenVal"
                        //        + " WHERE GROUP_ENTITY=1 ORDER BY WR.RES_NAME";
                        oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                        reader = oCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            int lLastWResID = 0;
                            string sGroups = "";
                            while (reader.Read())
                            {
                                int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                                if (lWResID != lLastWResID)
                                {
                                    if (lLastWResID != 0)
                                    {
                                        // Get the Resource and add the group string
                                        CStruct xResource = null;
                                        lstResources.TryGetValue(lLastWResID.ToString(), out xResource);
                                        if (xResource != null)
                                        {
                                            xResource.CreateString("Field" + ((int)SpecialFieldIDsEnum.sfResourceGroups).ToString("0"), sGroups);
                                        }
                                    }
                                    sGroups = "";
                                }
                                sGroups = Common.AppendItemToList(sGroups, DBAccess.ReadStringValue(reader["GROUP_NAME"]));
                                lLastWResID = lWResID;
                            }
                            reader.Close();
                            if (lLastWResID != 0)
                            {
                                // Get the Resource and add the group string
                                CStruct xResource = null;
                                lstResources.TryGetValue(lLastWResID.ToString(), out xResource);
                                if (xResource != null)
                                {
                                    xResource.CreateString("Field" + ((int)SpecialFieldIDsEnum.sfResourceGroups).ToString("0"), sGroups);
                                }
                            }
                        }
                    }

                    // Add in any multivalue codes
                    if (bIncludeMVCodes && sGroupWResIDs != "")
                    {
                        if (clnDisplayFields != null)
                        {
                            foreach (CStruct xItem in clnDisplayFields)
                            {
                                eFieldFormat = (TSFieldFormatEnum)xItem.GetIntAttr("FieldFormat");
                                eFieldID = (SpecialFieldIDsEnum)xItem.GetIntAttr("FieldID");
                                if (eFieldFormat == TSFieldFormatEnum.ffMVCode)
                                {
                                    int lLastWResID = 0;
                                    string sGroups = "";
                                    sCommand = "SELECT WR.WRES_ID,LV_VALUE"
                                             + " FROM EPG_RESOURCES WR"
                                             + " LEFT JOIN EPGC_RESOURCE_MV_VALUES MV ON WR.WRES_ID = MV.WRES_ID AND MV.MVR_FIELD_ID = " + ((int)eFieldID).ToString("0")
                                             + " LEFT JOIN EPGP_LOOKUP_VALUES LV ON LV.LV_UID = MV.MVR_UID"
                                             + " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sGroupWResIDs + "') LT on WR.WRES_ID=LT.TokenVal"
                                             + " ORDER BY WR.RES_NAME";

                                    oCommand = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                                    reader = oCommand.ExecuteReader();
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                                            if (lWResID != lLastWResID)
                                            {
                                                if (lLastWResID != 0)
                                                {
                                                    // Get the Resource and add the string
                                                    CStruct xResource = null;
                                                    lstResources.TryGetValue(lLastWResID.ToString(), out xResource);
                                                    if (xResource != null)
                                                    {
                                                        xResource.CreateString("Field" + ((int)eFieldID).ToString("0"), sGroups);
                                                    }
                                                }
                                                sGroups = "";
                                            }
                                            sGroups = Common.AppendItemToList(sGroups, DBAccess.ReadStringValue(reader["LV_VALUE"]));
                                            lLastWResID = lWResID;
                                        }
                                        if (lLastWResID != 0)
                                        {
                                            // Get the Resource and add the group string
                                            CStruct xResource = null;
                                            lstResources.TryGetValue(lLastWResID.ToString(), out xResource);
                                            if (xResource != null)
                                            {
                                                xResource.CreateString("Field" + ((int)eFieldID).ToString("0"), sGroups);
                                            }
                                        }
                                        reader.Close();
                                    }
                                }
                            }
                        }
                    }
                }
                xResourcesSelected.CreateInt("ResourceCount", lCount);
                sReply = xResourcesSelected.XML();
            }
            catch (Exception ex)
            {
                _dba.HandleException("ReadResources", (StatusEnum)99999, ex);
            }
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private string BuildResourceSelectQuery(DBAccess dba, int lSearchMode, CStruct xQuery, int lWResID, List<CStruct> clnDisplayFields, string sWResIDs, bool bIncludeUsers, bool bIncludeInactive, IncludeGenericsEnum eIncludeGenerics)
        {
            // converts XML query into SQL
            string s = "";
            //StatusEnum eStatus;
            // check for display fields
            int lCodeCount = 0;
            string sName = "";
            string sSelect = "";
            string sFrom = "";
            string stemp = "";
            string sTableAlias = "";
            string sWhere = "";
            string sTable = "";
            string sField = "";

            sSelect = " SELECT DISTINCT WR.WRES_ID,WR.RES_NAME,MR_NOTES,WR.WRES_DEPT as DeptUID,WR.WRES_RP_DEPT as RPDeptUID,WRES_INACTIVE,WRES_IS_RESOURCE,WRES_IS_GENERIC,CX.BC_UID as CCRoleUID,MR_SEQ";
            sFrom = " FROM EPG_RESOURCES WR " + " LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = " + lWResID.ToString() + " LEFT JOIN EPGP_COST_XREF CX ON WR.WRES_ID = CX.WRES_ID";
            if (clnDisplayFields != null)
            {
                foreach (CStruct xItem in clnDisplayFields)
                {
                    TSFieldFormatEnum eFieldFormat = (TSFieldFormatEnum)xItem.GetIntAttr("FieldFormat");
                    SpecialFieldIDsEnum eFieldID = (SpecialFieldIDsEnum)xItem.GetIntAttr("FieldID");
                    sName = "Field" + ((int)eFieldID).ToString();
                    switch (eFieldFormat)
                    {
                        case TSFieldFormatEnum.ffCode:
                            switch (eFieldID)
                            {
                                case SpecialFieldIDsEnum.sfDeptName:
                                    sSelect = sSelect + ",DEPT.LV_VALUE AS " + sName;
                                    sFrom = sFrom + " LEFT JOIN EPGP_LOOKUP_VALUES DEPT ON (DEPT.LV_UID = WR.WRES_DEPT)";
                                    break;
                                case SpecialFieldIDsEnum.sfRPDeptName:
                                    sSelect = sSelect + ",RPDEPT.LV_VALUE AS " + sName;
                                    sFrom = sFrom + " LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT ON (RPDEPT.LV_UID = WR.WRES_RP_DEPT)";
                                    break;
                                default:
                                    if (GetCustomFieldNameFromID(dba, (int)eFieldID, out sTable, out sField) != StatusEnum.rsSuccess)
                                        goto Exit_Function;

                                    // BUGFIX 27JUN08 V5.3 - Bill reported 8781 at St Judes. Custom field has likely been deleted
                                    if (sTable != "" && sField != "")
                                    {
                                        lCodeCount++;
                                        sTableAlias = "C" + lCodeCount.ToString();
                                        stemp = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                        sFrom += sTableAlias.Replace(stemp, "XX");
                                        stemp = " LEFT JOIN EPGP_LOOKUP_VALUES XY ON XY.LV_UID = XX." + sField + " ";
                                        stemp = sTableAlias.Replace(stemp, "XX");
                                        lCodeCount++;
                                        sTableAlias = "C" + lCodeCount.ToString();
                                        sFrom += sTableAlias.Replace(stemp, "XY");
                                        sSelect += sTableAlias.Replace(",XY.LV_VALUE AS ", "XY") + sName;
                                    }
                                    else
                                    {
                                        sSelect = sSelect + ",'**Invalid Column**' AS " + sName;
                                    }
                                    break;
                            }
                            break;
                        case TSFieldFormatEnum.ffText:
                            switch (eFieldID)
                            {
                                case SpecialFieldIDsEnum.sfResourceName:
                                case SpecialFieldIDsEnum.sfResourceNotes:
                                case SpecialFieldIDsEnum.sfResourceCostCategory:
                                case SpecialFieldIDsEnum.sfRoleName:
                                case SpecialFieldIDsEnum.sfResourceEMail:
                                    break;
                                default:
                                    if (GetCustomFieldNameFromID(dba, (int)eFieldID, out sTable, out sField) != StatusEnum.rsSuccess)
                                        goto Exit_Function;

                                    // BUGFIX 27JUN08 V5.3 - Bill reported 8781 at St Judes. Custom field has likely been deleted
                                    if (sTable != "" && sField != "")
                                    {
                                        lCodeCount++;
                                        sTableAlias = "T" + lCodeCount.ToString("0");
                                        stemp = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                        sFrom += sTableAlias.Replace(stemp, "XX");
                                        sSelect += sTableAlias.Replace(",XY." + sField + " AS ", "XY") + sName;
                                    }
                                    else
                                    {
                                        sSelect = sSelect + ",'**Invalid Column**' AS " + sName;
                                    }
                                    break;
                            }
                            break;
                        case TSFieldFormatEnum.ffCustom:
                            switch (eFieldID)
                            {
                                case SpecialFieldIDsEnum.sfResourceRate:
                                    sTable = "EPGP_COST_RATES";
                                    sField = "RT_UID";
                                    lCodeCount++;
                                    sTableAlias = "C" + lCodeCount.ToString("0");
                                    stemp = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                    sFrom += sTableAlias.Replace(stemp, "XX");
                                    stemp = " LEFT JOIN EPG_RATES XY ON XY.RT_UID = XX." + sField + " ";
                                    stemp = sTableAlias.Replace(stemp, "XX");
                                    lCodeCount++;
                                    sTableAlias = "C" + lCodeCount.ToString("0");
                                    sFrom += sTableAlias.Replace(stemp, "XY");
                                    sSelect += sTableAlias.Replace(",XY.RT_NAME AS ", "XY") + sName;
                                    break;
                            }
                            break;
                    }
                }
            }

            string sJoin = "";
            string sValue = "";

            sWhere = " WHERE WR.WRES_ID <> 1 ";
            if (eIncludeGenerics == IncludeGenericsEnum.igExclusive)
            {
                // Only want to see generics
                sWhere += " AND WR.WRES_IS_GENERIC <> 0 ";
            }
            else
            {
                //               WRES_IS_RESOURCE    WRES_IS_GENERIC
                // User              0                   0
                // Resource          1                   0
                // Generic           0                   1
                if (bIncludeUsers == false && eIncludeGenerics == IncludeGenericsEnum.igNo)
                {
                    // don't want to see Users or Generics
                    sWhere += " AND WR.WRES_IS_RESOURCE <> 0 ";
                }
                else if (eIncludeGenerics == IncludeGenericsEnum.igNo)
                {
                    // Don't want generics but want users
                    sWhere += " AND WR.WRES_IS_GENERIC = 0 ";
                }
                else if (bIncludeUsers == false)
                {
                    // Don't want users but want generics
                    sWhere += " AND (WR.WRES_IS_RESOURCE <> 0 OR WR.WRES_IS_GENERIC <> 0) ";
                }
            }

            if (bIncludeInactive == false)
                sWhere += " AND WR.WRES_INACTIVE = 0 ";

            switch (lSearchMode)
            {
                case 0: // Special select only interested in MyResources:

                    sWhere += " AND MR_WRES_ID = " + lWResID.ToString("0") + " ORDER BY MR_SEQ";
                    s = sSelect + sFrom + sWhere;

                    break;
                case 3: // Get list of specified WResIDs:

                    sJoin = " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sWResIDs + "') LT on WR.WRES_ID=LT.TokenVal";
                    s = sSelect + sFrom + sJoin + sWhere;


                    break;
                case 4: //' Simple find - multiple contains e.g. tom,fred,john:

                    bool bFirst = false;
                    bFirst = true;
                    if (xQuery != null)
                    {
                        Queue<CStruct> clnQueryRows = xQuery.GetCollection("QueryRow");
                        if (clnQueryRows != null)
                        {
                            foreach (CStruct xQueryRow in clnQueryRows)
                            {
                                sValue = xQueryRow.GetStringAttr("Value");
                                if (bFirst)
                                {
                                    sWhere += " AND (";
                                    bFirst = false;
                                }
                                else
                                {
                                    sWhere += " OR ";
                                }
                                sWhere += " RES_NAME LIKE " + DBAccess.PrepareText("%" + sValue + "%");
                            }
                            if (bFirst == false)
                                sWhere += " )";
                        }
                    }
                    s = sSelect + sFrom + sWhere;

                    break;
                default:

                    s = sSelect + sFrom;
                    if (xQuery != null)
                    {
                        Queue<CStruct> clnQueryRows = xQuery.GetCollection("QueryRow");
                        if (clnQueryRows != null)
                        {
                            int lOperator = 0;
                            string sJoins = "";
                            foreach (CStruct xQueryRow in clnQueryRows)
                            {
                                TSFieldFormatEnum eFieldFormat = (TSFieldFormatEnum)xQueryRow.GetIntAttr("FieldFormat");
                                SpecialFieldIDsEnum eFieldID = (SpecialFieldIDsEnum)xQueryRow.GetIntAttr("FieldID");
                                switch (eFieldFormat)
                                {
                                    case TSFieldFormatEnum.ffCode:
                                        lOperator = xQueryRow.GetIntAttr("Operator");
                                        sValue = xQueryRow.GetStringAttr("Value");
                                        switch (eFieldID)
                                        {
                                            case SpecialFieldIDsEnum.sfDeptName:
                                                sTableAlias = "WR";
                                                sField = "WRES_DEPT";
                                                break;
                                            case SpecialFieldIDsEnum.sfRPDeptName:
                                                sTableAlias = "WR";
                                                sField = "WRES_RP_DEPT";
                                                break;
                                            default:
                                                if (GetCustomFieldNameFromID(dba, (int)eFieldID, out sTable, out sField) != StatusEnum.rsSuccess)
                                                    goto Exit_Function;

                                                // BUGFIX 27JUN08 V5.3 - Bill reported 8781 at St Judes. Custom field has likely been deleted
                                                if (sTable != "" && sField != "")
                                                {
                                                    lCodeCount++;
                                                    sTableAlias = "C" + lCodeCount.ToString("0");
                                                    sJoin = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                                    sJoins += sJoin.Replace("XX", sTableAlias);
                                                }
                                                break;
                                        }

                                        switch (lOperator)
                                        {
                                            case 1:
                                            case 3:
                                                sWhere += (" AND XX." + sField + " IN (").Replace("XX", sTableAlias) + sValue + ")";
                                                break;
                                            case 2:
                                            case 4:
                                                sWhere += (" AND XX." + sField + " NOT IN (").Replace("XX", sTableAlias) + sValue + ")";
                                                break;
                                            case 5:
                                                sWhere += (" AND XX." + sField + " is null").Replace("XX", sTableAlias);
                                                break;
                                            case 6:
                                                sWhere += (" AND XX." + sField + " is not null").Replace("XX", sTableAlias);
                                                break;
                                        }
                                        break;
                                    case TSFieldFormatEnum.ffMVCode:
                                        if (GetCustomFieldNameFromID(dba, (int)eFieldID, out sTable, out sField) != StatusEnum.rsSuccess)
                                            goto Exit_Function;

                                        // BUGFIX 27JUN08 V5.3 - Bill reported 8781 at St Judes. Custom field has likely been deleted
                                        if (sTable != "" && sField != "")
                                        {
                                            lCodeCount++;
                                            sTableAlias = "C" + lCodeCount.ToString("0");
                                            lOperator = xQueryRow.GetIntAttr("Operator");
                                            sValue = xQueryRow.GetStringAttr("Value");
                                            sJoin = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                            sJoins += sJoin.Replace("XX", sTableAlias);

                                            switch (lOperator)
                                            {
                                                case 1:
                                                    sWhere += (" AND XX." + sField + " = (").Replace("XX", sTableAlias) + sValue + ")";
                                                    break;
                                                case 2:
                                                    sWhere += (" AND XX." + sField + " NOT IN (").Replace("XX", sTableAlias) + sValue + ")";
                                                    break;
                                                case 3:
                                                    sWhere += (" AND XX." + sField + " IN (").Replace("XX", sTableAlias) + sValue + ")";
                                                    break;
                                                case 4:
                                                    sWhere += (" AND XX." + sField + " NOT IN (").Replace("XX", sTableAlias) + sValue + ")";
                                                    break;
                                            }
                                        }
                                        break;
                                    case TSFieldFormatEnum.ffGroups:
                                        lOperator = xQueryRow.GetIntAttr("Operator");
                                        sValue = xQueryRow.GetStringAttr("Value");
                                        switch (lOperator)
                                        {
                                            case 1:
                                                sWhere += " AND WR.WRES_ID IN (SELECT MEMBER_UID FROM EPG_GROUP_MEMBERS WHERE GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUPS WHERE GROUP_ENTITY = 1 AND GROUP_ID=" + sValue + "))";
                                                break;
                                            case 2:
                                                sWhere += " AND WR.WRES_ID NOT IN (SELECT MEMBER_UID FROM EPG_GROUP_MEMBERS WHERE GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUPS WHERE GROUP_ENTITY = 1 AND GROUP_ID=" + sValue + "))";
                                                break;
                                            case 3:
                                                sWhere += " AND WR.WRES_ID IN (SELECT MEMBER_UID FROM EPG_GROUP_MEMBERS WHERE GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUPS WHERE GROUP_ENTITY = 1 AND GROUP_ID IN (" + sValue + ")))";
                                                break;
                                            case 4:
                                                sWhere += " AND WR.WRES_ID NOT IN (SELECT MEMBER_UID FROM EPG_GROUP_MEMBERS WHERE GROUP_ID IN (SELECT GROUP_ID FROM EPG_GROUPS WHERE GROUP_ENTITY = 1 AND GROUP_ID IN (" + sValue + ")))";
                                                break;
                                        }
                                        break;
                                    case TSFieldFormatEnum.ffText:
                                        // Operators
                                        // 1 = is equal to
                                        // 2 = is not equal to
                                        // 3 = contains
                                        // 4 = begins with
                                        lOperator = xQueryRow.GetIntAttr("Operator");
                                        sValue = xQueryRow.GetStringAttr("Value");
                                        if (eFieldID == SpecialFieldIDsEnum.sfResourceName)
                                        {
                                            switch (lOperator)
                                            {
                                                case 1:
                                                    sWhere += " AND RES_NAME LIKE " + DBAccess.PrepareText(sValue);
                                                    break;
                                                case 2:
                                                    sWhere += " AND RES_NAME NOT LIKE " + DBAccess.PrepareText(sValue);
                                                    break;
                                                case 3:
                                                    sWhere += " AND RES_NAME LIKE " + DBAccess.PrepareText("%" + sValue + "%");
                                                    break;
                                                case 4:
                                                    sWhere += " AND RES_NAME LIKE " + DBAccess.PrepareText(sValue + "%");
                                                    break;
                                            }
                                        }
                                        else if (eFieldID == SpecialFieldIDsEnum.sfRoleName)
                                        {
                                            sJoins += " LEFT JOIN EPGP_COST_CATEGORIES CAT ON CX.BC_UID = CAT.BC_UID";
                                            switch (lOperator)
                                            {
                                                case 1:
                                                    sWhere += " AND CAT.BC_NAME LIKE " + DBAccess.PrepareText(sValue);
                                                    break;
                                                case 2:
                                                    sWhere += " AND CAT.BC_NAME NOT LIKE " + DBAccess.PrepareText(sValue);
                                                    break;
                                                case 3:
                                                    sWhere += " AND CAT.BC_NAME LIKE " + DBAccess.PrepareText("%" + sValue + "%");
                                                    break;
                                                case 4:
                                                    sWhere += " AND CAT.BC_NAME LIKE " + DBAccess.PrepareText(sValue + "%");
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            if (GetCustomFieldNameFromID(dba, (int)eFieldID, out sTable, out sField) != StatusEnum.rsSuccess)
                                                goto Exit_Function;

                                            // BUGFIX 27JUN08 V5.3 - Bill reported 8781 at St Judes. Custom field has likely been deleted
                                            if (sTable != "" && sField != "")
                                            {
                                                lCodeCount++;
                                                sTableAlias = "C" + lCodeCount.ToString("0");
                                                lOperator = xQueryRow.GetIntAttr("Operator");
                                                sValue = xQueryRow.GetStringAttr("Value");

                                                sJoin = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                                switch (lOperator)
                                                {
                                                    case 1:
                                                        sWhere += (" AND XX." + sField + " LIKE ").Replace("XX", sTableAlias) + DBAccess.PrepareText(sValue);
                                                        break;
                                                    case 2:
                                                        sWhere += (" AND XX." + sField + " NOT LIKE ").Replace("XX", sTableAlias) + DBAccess.PrepareText(sValue);
                                                        break;
                                                    case 3:
                                                        sWhere += (" AND XX." + sField + " LIKE ").Replace("XX", sTableAlias) + DBAccess.PrepareText("%" + sValue + "%");
                                                        break;
                                                    case 4:
                                                        sWhere += (" AND XX." + sField + " LIKE ").Replace("XX", sTableAlias) + DBAccess.PrepareText(sValue + "%");
                                                        break;
                                                }
                                                sJoins += sJoin.Replace("XX", sTableAlias);
                                            }
                                        }
                                        break;
                                    case TSFieldFormatEnum.ffCustom:
                                        switch (eFieldID)
                                        {
                                            case SpecialFieldIDsEnum.sfResourceType:
                                                // Operators
                                                // 1 = is equal to
                                                // 2 = is not equal to
                                                lOperator = xQueryRow.GetIntAttr("Operator");
                                                ResourceTypeEnum eType = (ResourceTypeEnum)xQueryRow.GetIntAttr("Value");
                                                if (eType == ResourceTypeEnum.rtResource)
                                                {
                                                    switch (lOperator)
                                                    {
                                                        case 1:
                                                            sWhere += " AND WRES_IS_RESOURCE <> 0 ";
                                                            break;
                                                        case 2:
                                                            sWhere += " AND WRES_IS_RESOURCE = 0 ";
                                                            break;
                                                    }
                                                }
                                                else if (eType == ResourceTypeEnum.rtUser)
                                                {
                                                    switch (lOperator)
                                                    {
                                                        case 1:
                                                            sWhere += " AND WRES_CAN_LOGIN <> 0 ";
                                                            break;
                                                        case 2:
                                                            sWhere += " AND WRES_CAN_LOGIN = 0 ";
                                                            break;
                                                    }
                                                }
                                                break;
                                            case SpecialFieldIDsEnum.sfResourceRate:
                                                lOperator = xQueryRow.GetIntAttr("Operator");
                                                sValue = xQueryRow.GetStringAttr("Value");

                                                sTable = "EPGP_COST_RATES";
                                                sField = "RT_UID";

                                                // BUGFIX 27JUN08 V5.3 - Bill reported 8781 at St Judes. Custom field has likely been deleted
                                                if (sTable != "" && sField != "")
                                                {
                                                    lCodeCount++;
                                                    sTableAlias = "C" + lCodeCount.ToString("0");
                                                    sJoin = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                                    sJoins += sJoin.Replace("XX", sTableAlias);
                                                }

                                                switch (lOperator)
                                                {
                                                    case 1:
                                                    case 3:
                                                        sWhere += (" AND XX." + sField + " IN (").Replace("XX", sTableAlias) + sValue + ")";
                                                        break;
                                                    case 2:
                                                    case 4:
                                                        sWhere += (" AND XX." + sField + " NOT IN (").Replace("XX", sTableAlias) + sValue + ")";
                                                        break;
                                                    case 5:
                                                        sWhere += (" AND XX." + sField + " is null").Replace("XX", sTableAlias);
                                                        break;
                                                    case 6:
                                                        sWhere += (" AND XX." + sField + " is not null").Replace("XX", sTableAlias);
                                                        break;
                                                }

                                                break;
                                            case SpecialFieldIDsEnum.sfResourceStatus:
                                                // Operators
                                                // 1 = is equal to
                                                // 2 = is not equal to
                                                lOperator = xQueryRow.GetIntAttr("Operator");
                                                ResourceStatusEnum eResStatus = (ResourceStatusEnum)xQueryRow.GetIntAttr("Value");
                                                if (eResStatus == ResourceStatusEnum.rsInactive)
                                                {
                                                    switch (lOperator)
                                                    {
                                                        case 1:
                                                            sWhere += " AND WRES_INACTIVE <> 0 ";
                                                            break;
                                                        case 2:
                                                            sWhere += " AND WRES_INACTIVE = 0 ";
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    switch (lOperator)
                                                    {
                                                        case 1:
                                                            sWhere += " AND WRES_INACTIVE = 0 ";
                                                            break;
                                                        case 2:
                                                            sWhere += " AND WRES_INACTIVE <> 0 ";
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                        break;
                                }
                            }
                            s = s + sJoins + sWhere + " ORDER BY WR.RES_NAME";
                        }
                    }

                    break;
            }
        Exit_Function:
            return s;
        }

        public bool GetPIResourcesXML(string sWEPID, string sWResIDs, bool bIgnoreStatusDate, out string sReply)
        {
            sReply = "";
            int lProjectID;
            if (DBCommon.SelectProjectIDByExtUID(_dba, sWEPID, out lProjectID) != StatusEnum.rsSuccess)
                return false;
            return GetPIResourcesXML(lProjectID, sWResIDs, bIgnoreStatusDate, out sReply);
        }

        public bool GetPIResourcesXML(int lProjectID, string sWResIDs, bool bIgnoreStatusDate, out string sReply)
        {
            sReply = "";
            try
            {
                CAdmin oAdmin = new CAdmin();
                if (oAdmin.GetAdminInfo(_dba) != StatusEnum.rsSuccess)
                    goto Exit_Function;

                // Read in the PI Commitments calendar periods
                List<CPeriod> clnPeriods;
                if (GetPeriods(_dba, oAdmin.PortfolioCommitmentsCalendarUID, out clnPeriods) != StatusEnum.rsSuccess)
                    goto Exit_Function;

                // Take into account the status date
                int lStartPeriodID = 0;
                if (oAdmin.StatusDateIsNull || bIgnoreStatusDate)
                {
                    lStartPeriodID = 1;
                }
                else
                {
                    List<CPeriod> clnPeriods2;
                    clnPeriods2 = new List<CPeriod>();
                    lStartPeriodID = 0;
                    foreach (CPeriod oPeriod in clnPeriods)
                    {
                        if (lStartPeriodID == 0)
                        {
                            if (oPeriod.StartDate <= oAdmin.StatusDate && oPeriod.FinishDate >= oAdmin.StatusDate)
                            {
                                lStartPeriodID = oPeriod.PeriodID;
                                clnPeriods2.Add(oPeriod);
                            }
                        }
                        else
                        {
                            clnPeriods2.Add(oPeriod);
                        }
                    }
                    clnPeriods = clnPeriods2;
                }

                CStruct xReply;
                if (GetPIResourcesStruct(_dba, _userWResID, lProjectID.ToString(), sWResIDs, clnPeriods, oAdmin, lStartPeriodID, out xReply) != StatusEnum.rsSuccess)
                    goto Exit_Function;
                sReply = xReply.XML();
            }
            catch (Exception ex)
            {
                _dba.HandleException("GetPIResourcesXML", (StatusEnum)9503, ex);

            }
        Exit_Function:
            return (_dba.Status == StatusEnum.rsSuccess);
        }

        private static StatusEnum GetResourceDisplayFields(DBAccess dba, out CStruct xReply)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            xReply = null;
            try
            {
                CStruct xResourceDisplayFields = new CStruct();
                xResourceDisplayFields.Initialize("ResourceDisplayFields");
                CStruct xItems = xResourceDisplayFields.CreateSubStruct("Items");

                //sb.Append("<Item Name=\"Name\" FieldID=\"9004\" FieldFormat=\"9\" Title=\"Candidate Name\" Align=\"0\"/>");
                CStruct xItem = xItems.CreateSubStruct("Item");
                xItem.CreateIntAttr("FieldID", 9004);
                xItem.CreateStringAttr("Name", "Name");
                xItem.CreateIntAttr("FieldFormat", 9);
                xItem.CreateStringAttr("Title", "Candidate Name");
                xItem.CreateIntAttr("Align", 0);

                //sb.Append("<Item Name=\"Cost Category Role\" FieldID=\"9019\" FieldFormat=\"9\" Title=\"Cost Category Role\" Align=\"0\"/>");
                xItem = xItems.CreateSubStruct("Item");
                xItem.CreateIntAttr("FieldID", 9019);
                xItem.CreateStringAttr("Name", "Cost Category Role");
                xItem.CreateIntAttr("FieldFormat", 9);
                xItem.CreateStringAttr("Title", "Cost Category Role");
                xItem.CreateIntAttr("Align", 0);
                //sb.Append("<Item Name=\"Role\" FieldID=\"9006\" FieldFormat=\"9\" Title=\"Role\" Align=\"0\"/>");
                xItem = xItems.CreateSubStruct("Item");
                xItem.CreateIntAttr("FieldID", 9006);
                xItem.CreateStringAttr("Name", "Role");
                xItem.CreateIntAttr("FieldFormat", 9);
                xItem.CreateStringAttr("Title", "Role");
                xItem.CreateIntAttr("Align", 0);
                //sb.Append("<Item Name=\"RP Dept\" FieldID=\"9015\" FieldFormat=\"4\" Title=\"Department\" Align=\"0\"/>");
                xItem = xItems.CreateSubStruct("Item");
                xItem.CreateIntAttr("FieldID", 9015);
                xItem.CreateStringAttr("Name", "RP Dept");
                xItem.CreateIntAttr("FieldFormat", 4);
                xItem.CreateStringAttr("Title", "Department");
                xItem.CreateIntAttr("Align", 0);
                //sb.Append("<Item Name=\"Rate\" FieldID=\"9020\" FieldFormat=\"96\" Title=\"Rate\" Align=\"0\"/>");
                xItem = xItems.CreateSubStruct("Item");
                xItem.CreateIntAttr("FieldID", 9020);
                xItem.CreateStringAttr("Name", "Rate");
                xItem.CreateIntAttr("FieldFormat", 96);
                xItem.CreateStringAttr("Title", "Rate");
                xItem.CreateIntAttr("Align", 0);
                //sb.Append("<Item Name=\"Groups\" FieldID=\"9017\" FieldFormat=\"98\" Title=\"Groups\" Align=\"0\"/>");
                xItem = xItems.CreateSubStruct("Item");
                xItem.CreateIntAttr("FieldID", 9017);
                xItem.CreateStringAttr("Name", "Groups");
                xItem.CreateIntAttr("FieldFormat", 98);
                xItem.CreateStringAttr("Title", "Groups");
                xItem.CreateIntAttr("Align", 0);
                //sb.Append("<Item Name=\"Notes\" FieldID=\"9016\" FieldFormat=\"9\" Title=\"Notes\" Align=\"0\"/>");
                xItem = xItems.CreateSubStruct("Item");
                xItem.CreateIntAttr("FieldID", 9016);
                xItem.CreateStringAttr("Name", "Notes");
                xItem.CreateIntAttr("FieldFormat", 9);
                xItem.CreateStringAttr("Title", "Notes");
                xItem.CreateIntAttr("Align", 0);
                //sb.Append("<Item Name=\"Name\" FieldID=\"9024\" FieldFormat=\"9\" Title=\"eMail\" Align=\"0\"/>");
                xItem = xItems.CreateSubStruct("Item");
                xItem.CreateIntAttr("FieldID", 9024);
                xItem.CreateStringAttr("Name", "Name");
                xItem.CreateIntAttr("FieldFormat", 9);
                xItem.CreateStringAttr("Title", "eMail");
                xItem.CreateIntAttr("Align", 0);
                ////sb.Append("<Item Name=\"TS Dept\" FieldID=\"9005\" FieldFormat=\"4\" Title=\"TS Dept\" Align=\"0\"/>");
                // Add in the Resource Codes
                //sb.Append("<Item Name=\"ResCode1\" FieldID=\"20032\" FieldFormat=\"4\" Title=\"ResCode1\" Align=\"0\"/>");
                SqlCommand oCommand;
                SqlDataReader reader;
                int nId = 0;
                oCommand = new SqlCommand("EPG_SP_ReadInitialisedCustomFields", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("TableID", SqlDbType.Int).Value = CustomFieldDBTable.ResourceINT;
                oCommand.Parameters.Add("FormatID", SqlDbType.Int).Value = FieldType.TypeCode;
                reader = oCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        xItem = xItems.CreateSubStruct("Item");
                        xItem.CreateIntAttr("FieldID", DBAccess.ReadIntValue(reader["FA_FIELD_ID"]));
                        xItem.CreateStringAttr("Name", "Cust" + (++nId).ToString());
                        xItem.CreateIntAttr("FieldFormat", (int)TSFieldFormatEnum.ffCode);
                        xItem.CreateStringAttr("Title", DBAccess.ReadStringValue(reader["FA_NAME"]));
                        xItem.CreateIntAttr("Align", 0);
                    }
                }
                reader.Close();

                //' Add in the MV Resource Codes
                oCommand = new SqlCommand("EPG_SP_ReadInitialisedCustomFields", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("TableID", SqlDbType.Int).Value = CustomFieldDBTable.ResourceMV;
                oCommand.Parameters.Add("FormatID", SqlDbType.Int).Value = FieldType.TypeMVCode;
                reader = oCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        xItem = xItems.CreateSubStruct("Item");
                        xItem.CreateIntAttr("FieldID", DBAccess.ReadIntValue(reader["FA_FIELD_ID"]));
                        xItem.CreateStringAttr("Name", "Cust" + (++nId).ToString());
                        xItem.CreateIntAttr("FieldFormat", (int)TSFieldFormatEnum.ffMVCode);
                        xItem.CreateStringAttr("Title", DBAccess.ReadStringValue(reader["FA_NAME"]));
                        xItem.CreateIntAttr("Align", 0);
                    }
                }
                reader.Close();
                //' Add in the Resource Text Fields
                oCommand = new SqlCommand("EPG_SP_ReadInitialisedCustomFields", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("TableID", SqlDbType.Int).Value = CustomFieldDBTable.ResourceTEXT;
                oCommand.Parameters.Add("FormatID", SqlDbType.Int).Value = FieldType.TypeText;
                reader = oCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        xItem = xItems.CreateSubStruct("Item");
                        xItem.CreateIntAttr("FieldID", DBAccess.ReadIntValue(reader["FA_FIELD_ID"]));
                        xItem.CreateStringAttr("Name", "Cust" + (++nId).ToString());
                        xItem.CreateIntAttr("FieldFormat", (int)TSFieldFormatEnum.ffText);
                        xItem.CreateStringAttr("Title", DBAccess.ReadStringValue(reader["FA_NAME"]));
                        xItem.CreateIntAttr("Align", 0);
                    }
                }
                reader.Close();
                xReply = xResourceDisplayFields;
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleException("GetResourceDisplayFields", (StatusEnum)99999, ex);
            }
        Exit_Function:
            return eStatus;
        }

        public static StatusEnum GetPIResourcesStruct(DBAccess dba, int lUserWResId, string sProjectIDs, string sWResIDs, List<CPeriod> clnPeriods, CAdmin oAdmin, int lStartPeriodID, out CStruct xReply)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            CStruct xPIResources = null;
            string sPos = "a";
            try
            {
                string sResManagerDeptUIDs = "";
                bool bSuperRM = Security.CheckUserGlobalPermission(dba, lUserWResId, GlobalPermissionsEnum.gpSuperRM);
                SqlDataReader reader;
                SqlCommand oCommand;
                if (bSuperRM == false)
                {
                    oCommand = new SqlCommand("EPG_SP_ReadManagerResDeptsB", dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.Add("ApproverWResID", SqlDbType.Int).Value = lUserWResId;
                    if ((reader = oCommand.ExecuteReader()) != null)
                    {
                        while (reader.Read())
                        {
                            Common.AddIDToList(ref sResManagerDeptUIDs, DBAccess.ReadIntValue(reader["DeptUID"]));
                        }
                        reader.Close();
                    }
                }
                xPIResources = new CStruct();
                xPIResources.Initialize("PIResources");
                xPIResources.CreateString("ProjectIDs", sProjectIDs);
                // Get the display field settings
                List<CStruct> clnDisplayFields;

                CStruct xResourceDisplayFields;
                if (GetResourceDisplayFields(dba, out xResourceDisplayFields) != StatusEnum.rsSuccess) goto Exit_Function;
                xPIResources.AppendSubStruct(xResourceDisplayFields);

                CStruct xItems = xResourceDisplayFields.GetSubStruct("Items");
                clnDisplayFields = xItems.GetList("Item");

                CStruct xCalendar = xPIResources.CreateSubStruct("Calendar");
                xCalendar.CreateIntAttr("CalID", oAdmin.PortfolioCommitmentsCalendarUID);
                xPIResources.CreateInt("StartPeriodID", lStartPeriodID);
                int lFinishPeriodID = 0;
                if (clnPeriods.Count > 0)
                {
                    lFinishPeriodID = clnPeriods[clnPeriods.Count - 1].PeriodID;
                }
                else
                    lFinishPeriodID = lStartPeriodID;
                xPIResources.CreateInt("FinishPeriodID", lFinishPeriodID);

                CStruct xPeriods = xCalendar.CreateSubStruct("Periods");

                sPos = "b";
                if (clnPeriods.Count == 0)
                {
                    dba.HandleStatusError(SeverityEnum.Error, "GetPIResourcesStruct", StatusEnum.rsRequestInvalidPeriod, "No Periods found!");
                    eStatus = StatusEnum.rsRequestInvalidPeriod;
                    goto Exit_Function;
                }

                foreach (CPeriod oPeriod in clnPeriods)
                {
                    CStruct xPeriod = xPeriods.CreateSubStruct("Period");
                    xPeriod.CreateIntAttr("ID", oPeriod.PeriodID);
                    xPeriod.CreateStringAttr("Name", oPeriod.PeriodName);
                    xPeriod.CreateDateAttr("Start", oPeriod.StartDate);
                    xPeriod.CreateDateAttr("Finish", oPeriod.FinishDate);
                }

                CStruct oRPCategories = xPIResources.CreateSubStruct("RPCategories");

                sPos = "c";
                CStruct oRPCategory = oRPCategories.CreateSubStruct("RPCategory");
                oRPCategory.CreateInt("FieldID", (int)SpecialFieldIDsEnum.sfRPDeptName);
                CStruct oRPCategoryList;
                if (DBCommon.GetLookupListXML(dba, oAdmin.RPDeptCode, out oRPCategoryList) == StatusEnum.rsSuccess)
                {
                    oRPCategory.AppendSubStruct(oRPCategoryList);
                }

                CStruct xResources = xPIResources.CreateSubStruct("Resources");

                Dictionary<string, CStruct> dicResources = new Dictionary<string, CStruct>();

                sPos = "d";
                string sCommand = BuildPortfolioResourcesSelectQuery(dba, lUserWResId, clnDisplayFields, sWResIDs, oAdmin.RPDeptCode, oAdmin.RoleCode);
                oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                sPos = sCommand;
                reader = oCommand.ExecuteReader();
                string sGroupWResIDs = "";
                sPos = "d1";
                if (reader.HasRows == false)
                {
                    reader.Close();
                    reader.Dispose();
                }
                else
                {
                    Dictionary<string, CStruct> dicCostCategoryRoles;
                    sPos = "e";
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    reader.Dispose();

                    if (GetCostCategoryRoles(dba, -1, 0, out dicCostCategoryRoles) != StatusEnum.rsSuccess) goto Exit_Function;

                    string sName = "";
                    TSFieldFormatEnum eFieldFormat;
                    SpecialFieldIDsEnum eFieldID;
                    bool bIncludeGroups = false;
                    bool bIncludeMVCodes = false;
                    bool bIncludeCostCategoryNames = false;
                    bool bIncludeRoleNames = false;
                    string sCCWResIDs = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        int lWResID = DBAccess.ReadIntValue(row["WRES_ID"]);
                        Common.AddIDToList(ref sGroupWResIDs, lWResID);
                        CStruct xResource = xResources.CreateSubStruct("Resource");
                        xResource.CreateIntAttr("WResID", lWResID);
                        xResource.CreateStringAttr("Name", DBAccess.ReadStringValue(row["RES_NAME"]));
                        xResource.CreateStringAttr("EMail", DBAccess.ReadStringValue(row["WRES_EMAIL"]));
                        int lDeptUID = DBAccess.ReadIntValue(row["RPDeptUID"]);
                        xResource.CreateInt("DeptUID", lDeptUID);
                        if (bSuperRM || Common.IsIDInList(sResManagerDeptUIDs, lDeptUID) == true)
                            xResource.CreateBooleanAttr("UserIsRM", true);

                        //Call xResource.CreateInt("RoleUID", dba.FieldValue(oRecordset, "RoleUID", bNull))
                        int lCCRoleUID = DBAccess.ReadIntValue(row["CCRoleUID"]);
                        if (lCCRoleUID > 0)
                        {
                            xResource.CreateInt("CCRoleUID", lCCRoleUID);
                            CStruct xCostCategoryRole = null; ;
                            dicCostCategoryRoles.TryGetValue(lCCRoleUID.ToString(), out xCostCategoryRole);
                            if (xCostCategoryRole != null)
                            {
                                xResource.CreateInt("RoleUID", xCostCategoryRole.GetIntAttr("RoleUID"));
                                xResource.CreateInt("CCRoleParentUID", xCostCategoryRole.GetIntAttr("ParentID"));
                            }
                        }
                        else
                            Common.AddIDToList(ref sCCWResIDs, lWResID);

                        bool bIsInactive = (DBAccess.ReadIntValue(row["WRES_INACTIVE"]) != 0);
                        if (bIsInactive)
                            xResource.CreateBoolean("Inactive", bIsInactive);
                        bool bIsGeneric = (DBAccess.ReadIntValue(row["WRES_IS_GENERIC"]) != 0);
                        if (bIsGeneric)
                            xResource.CreateBoolean("IsGeneric", bIsGeneric);
                        string sNotes = DBAccess.ReadStringValue(row["MR_NOTES"]);
                        if (sNotes != "")
                            xResource.CreateString("Notes", sNotes);


                        // save resource in a keyed collection for easy access
                        dicResources.Add(lWResID.ToString(), xResource);

                        if (clnDisplayFields != null)
                        {
                            foreach (CStruct xItem in clnDisplayFields)
                            {
                                eFieldFormat = (TSFieldFormatEnum)xItem.GetIntAttr("FieldFormat");
                                eFieldID = (SpecialFieldIDsEnum)xItem.GetIntAttr("FieldID");
                                sName = "Field" + ((int)eFieldID).ToString("0");
                                switch (eFieldFormat)
                                {
                                    case TSFieldFormatEnum.ffCode:
                                        switch (eFieldID)
                                        {
                                            case SpecialFieldIDsEnum.sfRPDeptName:
                                                xResource.CreateString("DeptName", DBAccess.ReadStringValue(row[sName]));
                                                break;
                                            default:
                                                xResource.CreateString(sName, DBAccess.ReadStringValue(row[sName]));
                                                break;
                                        }
                                        break;
                                    case TSFieldFormatEnum.ffText:
                                        switch (eFieldID)
                                        {
                                            case SpecialFieldIDsEnum.sfResourceName:
                                            case SpecialFieldIDsEnum.sfResourceNotes:
                                            case SpecialFieldIDsEnum.sfResourceEMail:
                                                break;
                                            case SpecialFieldIDsEnum.sfResourceCostCategory:
                                                //bIncludeCostCategoryNames = true;
                                                break;
                                            case SpecialFieldIDsEnum.sfRoleName:
                                                //bIncludeRoleNames = true;
                                                break;
                                            default:
                                                xResource.CreateString(sName, DBAccess.ReadStringValue(row[sName]));
                                                break;
                                        }
                                        //''                            If eFieldID = SpecialFieldIDsEnum.sfResourceCostCategory Then
                                        //''                                bIncludeCostCategoryNames = True
                                        //''                            ElseIf eFieldID <> sfResourceName And eFieldID <> sfResourceNotes Then
                                        //''                                Call xResource.CreateString(sName, dba.FieldValue(oRecordset, sName))
                                        //''                            End If
                                        break;
                                    case TSFieldFormatEnum.ffGroups:
                                        bIncludeGroups = true;
                                        break;
                                    case TSFieldFormatEnum.ffMVCode:
                                        bIncludeMVCodes = true;
                                        break;
                                    case TSFieldFormatEnum.ffCustom:
                                        switch (eFieldID)
                                        {
                                            case SpecialFieldIDsEnum.sfResourceRate:
                                                xResource.CreateString(sName, DBAccess.ReadStringValue(row[sName]));
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    reader.Close();


                    sPos = "f";
                    if (sProjectIDs != "")
                    {
                        // flag the team resources
                        string sCommand1 = "SELECT WRES_ID FROM EPGP_TEAMS JOIN dbo.EPG_FN_ConvertListToTable(N'" + sProjectIDs + "') LT on PROJECT_ID=LT.TokenVal";
                        SqlCommand oCommand1 = new SqlCommand(sCommand1, dba.Connection, dba.Transaction);
                        SqlDataReader reader1 = oCommand1.ExecuteReader();
                        while (reader1.Read())
                        {
                            int lWResID = DBAccess.ReadIntValue(reader1["WRES_ID"]);
                            //Common.AddIDToList(ref sWResIDsInProject, lWResId);
                            CStruct xResource = null;
                            if (dicResources.TryGetValue(lWResID.ToString(), out xResource))
                                xResource.CreateBoolean("InTeam", true);
                        }
                        reader1.Close();
                    }

                    sPos = "g";
                    // Give resources without a specific Cost Category the generic one
                    if (sCCWResIDs != "")
                    {
                        sCommand = "SELECT BC_UID as CCRoleUID FROM EPGP_COST_XREF WHERE WRES_ID = 0";
                        oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                        reader = oCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            int lCCRoleUID = DBAccess.ReadIntValue(reader["CCRoleUID"]);

                            int lWResID = 0;
                            Int32.TryParse(Common.GetFirstItemFromList(ref sCCWResIDs), out lWResID);
                            while (lWResID > 0)
                            {
                                CStruct xResource = null;
                                if (dicResources.TryGetValue(lWResID.ToString(), out xResource))
                                    xResource.CreateInt("CCRoleUID", lCCRoleUID);
                                Int32.TryParse(Common.GetFirstItemFromList(ref sCCWResIDs), out lWResID);
                            }
                        }
                        reader.Close();
                    }

                    sPos = "h";
                    bIncludeCostCategoryNames = true;
                    bIncludeRoleNames = true;
                    if (bIncludeCostCategoryNames || bIncludeRoleNames)
                    {
                        //Dictionary<string, CStruct> dicCostCategoryRoles;
                        //if (GetCostCategoryRoles(dba, oAdmin.PortfolioCommitmentsCalendarUID, lStartPeriodID, out dicCostCategoryRoles) == StatusEnum.rsSuccess)
                        {
                            string sParentName = "";
                            string sFullName = "";
                            CStruct xCostCategoryRole;

                            CStruct[] xArr = new CStruct[dicResources.Values.Count];
                            dicResources.Values.CopyTo(xArr, 0);

                            foreach (CStruct xResource in xArr)
                            {
                                int lCCRoleUID = xResource.GetInt("CCRoleUID");
                                if (lCCRoleUID > 0)
                                {
                                    // BUGFIX 28May09 V60 CRL - Handle Invalid CCRole allocation
                                    //CStruct xCostCategoryRole = dicCostCategoryRoles.TryGetValue(lCCRoleUID.ToString());
                                    //If bIncludeCostCategoryNames Then
                                    //    sFullName = xCostCategoryRole.GetStringAttr("ParentName") & "." & xCostCategoryRole.GetStringAttr("Name")
                                    //    Call xResource.CreateString("Field" & Format$(SpecialFieldIDsEnum.sfResourceCostCategory, "0"), sFullName)
                                    //End If
                                    //If bIncludeRoleNames Then
                                    //    Call xResource.CreateString("Field" & Format$(SpecialFieldIDsEnum.sfRoleName, "0"), xCostCategoryRole.GetStringAttr("Name"))
                                    //End If
                                    xCostCategoryRole = null;
                                    dicCostCategoryRoles.TryGetValue(lCCRoleUID.ToString(), out xCostCategoryRole);

                                    if (xCostCategoryRole == null)
                                    {
                                        sName = "InvalidCCNoRole" + lCCRoleUID.ToString("0");
                                        sParentName = "";
                                        sFullName = sName;
                                    }
                                    else
                                    {
                                        sName = xCostCategoryRole.GetStringAttr("Name");
                                        sParentName = xCostCategoryRole.GetStringAttr("ParentName");
                                        sFullName = sParentName + "." + sName;
                                    }

                                    if (bIncludeCostCategoryNames)
                                    {
                                        xResource.CreateString("CCRoleName", sFullName);
                                        xResource.CreateString("CCRoleParentName", sParentName);
                                        if (xCostCategoryRole != null)
                                        {
                                            xResource.CreateString("FTEPeriods", xCostCategoryRole.GetString("Periods"));
                                            xResource.CreateString("FTEToHours", xCostCategoryRole.GetString("FTEToHours"));
                                        }
                                    }
                                    if (bIncludeRoleNames)
                                    {
                                        xResource.CreateString("RoleName", sName);
                                    }
                                }
                            }
                        }
                    }
                    //''        If bIncludeCostCategoryNames Then
                    //''            Dim clnCostCategoryRoles As Collection
                    //''            If GetCostCategoryRoles(dba, oXMLDocument, -1, 0, clnCostCategoryRoles, eStatus) <> StatusEnum.rsSuccess Then GoTo Exit_Function
                    //''
                    //''            Dim sFullName As String
                    //''            Dim xCostCategoryRole As CStruct
                    //''            For Each xResource In clnResources
                    //''                lCCRoleUID = xResource.GetInt("CCRoleUID", eStatus)
                    //''                If lCCRoleUID > 0 Then
                    //''                    Set xCostCategoryRole = clnCostCategoryRoles.Item(CStr(lCCRoleUID))
                    //''                    sFullName = xCostCategoryRole.GetStringAttr("ParentName") & "." & xCostCategoryRole.GetStringAttr("Name")
                    //''                    Call xResource.CreateString("Field" & Format$(SpecialFieldIDsEnum.sfResourceCostCategory, "0"), sFullName)
                    //''                End If
                    //''            Next
                    //''        End If

                    sPos = "i";
                    if (bIncludeGroups && sGroupWResIDs != "")
                    {
                        sCommand = "SELECT WR.WRES_ID,GROUP_NAME"
                                 + "  FROM EPG_RESOURCES WR"
                                 + "  LEFT JOIN EPG_GROUP_MEMBERS SGM ON SGM.MEMBER_UID = WR.WRES_ID"
                                 + "  LEFT JOIN EPG_GROUPS SG ON SG.GROUP_ID = SGM.GROUP_ID AND GROUP_ENTITY = 1"
                                 + " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sGroupWResIDs + "') LT on WR.WRES_ID=LT.TokenVal"
                                 + " WHERE GROUP_NAME IS NOT NULL ORDER BY WR.RES_NAME";
                        oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                        reader = oCommand.ExecuteReader();
                        if (reader.HasRows == false)
                        {
                            reader.Close();
                            reader.Dispose();
                        }
                        else
                        {
                            int lLastWResID = 0;
                            string sGroups = "";
                            while (reader.Read())
                            {
                                int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                                if (lWResID != lLastWResID)
                                {
                                    if (lLastWResID != 0)
                                    {
                                        // Get the Resource and add the group string
                                        CStruct xResource = null;
                                        dicResources.TryGetValue(lLastWResID.ToString(), out xResource);
                                        if (xResource != null)
                                        {
                                            xResource.CreateString("Field" + ((int)SpecialFieldIDsEnum.sfResourceGroups).ToString("0"), sGroups);
                                        }
                                    }
                                    sGroups = "";
                                }
                                sGroups = Common.AppendItemToList(sGroups, DBAccess.ReadStringValue(reader["GROUP_NAME"]));
                                lLastWResID = lWResID;

                            }
                            reader.Close();
                            if (lLastWResID != 0)
                            {
                                // Get the Resource and add the group string
                                CStruct xResource = null;
                                dicResources.TryGetValue(lLastWResID.ToString(), out xResource);
                                if (xResource != null)
                                {
                                    xResource.CreateString("Field" + ((int)SpecialFieldIDsEnum.sfResourceGroups).ToString("0"), sGroups);
                                }
                            }
                        }
                    }

                    sPos = "j";
                    // Add in any multivalue codes
                    if (bIncludeMVCodes && sGroupWResIDs != "")
                    {
                        if (clnDisplayFields != null)
                        {
                            foreach (CStruct xItem in clnDisplayFields)
                            {
                                eFieldFormat = (TSFieldFormatEnum)xItem.GetIntAttr("FieldFormat");
                                eFieldID = (SpecialFieldIDsEnum)xItem.GetIntAttr("FieldID");
                                if (eFieldFormat == TSFieldFormatEnum.ffMVCode)
                                {
                                    int lLastWResID = 0;
                                    string sGroups = "";
                                    sCommand = "SELECT WR.WRES_ID,LV_VALUE"
                                             + " FROM EPG_RESOURCES WR"
                                             + " LEFT JOIN EPGC_RESOURCE_MV_VALUES MV ON WR.WRES_ID = MV.WRES_ID AND MV.MVR_FIELD_ID = " + ((int)eFieldID).ToString("0")
                                             + " LEFT JOIN EPGP_LOOKUP_VALUES LV ON LV.LV_UID = MV.MVR_UID"
                                             + " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sGroupWResIDs + "') LT on WR.WRES_ID=LT.TokenVal"
                                             + " ORDER BY WR.RES_NAME";

                                    oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                                    reader = oCommand.ExecuteReader();
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                                            if (lWResID != lLastWResID)
                                            {
                                                if (lLastWResID != 0)
                                                {
                                                    // Get the Resource and add the string
                                                    CStruct xResource = null;
                                                    dicResources.TryGetValue(lLastWResID.ToString(), out xResource);
                                                    if (xResource != null)
                                                    {
                                                        xResource.CreateString("Field" + ((int)eFieldID).ToString("0"), sGroups);
                                                    }
                                                }
                                                sGroups = "";
                                            }
                                            sGroups = Common.AppendItemToList(sGroups, DBAccess.ReadStringValue(reader["LV_VALUE"]));
                                            lLastWResID = lWResID;
                                        }
                                        if (lLastWResID != 0)
                                        {
                                            // Get the Resource and add the group string
                                            CStruct xResource = null;
                                            dicResources.TryGetValue(lLastWResID.ToString(), out xResource);
                                            if (xResource != null)
                                            {
                                                xResource.CreateString("Field" + ((int)eFieldID).ToString("0"), sGroups);
                                            }
                                        }
                                        reader.Close();
                                    }
                                }
                            }
                        }
                    }
                }


                sPos = "k";
                // Read available, committed and NonWork hours for resources over calendar period span
                if (oAdmin.PortfolioCommitmentsCalendarUID >= 0)
                {
                    oCommand = new SqlCommand("EPG_SP_ReadResourcesWorkA", dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.Add("CalID", SqlDbType.Int).Value = oAdmin.PortfolioCommitmentsCalendarUID;
                    oCommand.Parameters.Add("StartPeriodID", SqlDbType.Int).Value = lStartPeriodID;
                    oCommand.Parameters.Add("FinishPeriodID", SqlDbType.Int).Value = lFinishPeriodID;
                    oCommand.Parameters.Add("WResIDs", SqlDbType.NVarChar, sGroupWResIDs.Length).Value = sGroupWResIDs;

                    reader = oCommand.ExecuteReader();

                    // The recordsets are sorted by WResID and PeriodID

                    // Availability
                    int lPrevWResID = 0;
                    int lPeriodID = 0;
                    double dblHours = 0;
                    double dblOffHours = 0;
                    var sPeriods = new StringBuilder();
                    var sHours = new StringBuilder();
                    var sOffHours = new StringBuilder();
                    bool bFirst = false;
                    bFirst = true;
                    while (reader.Read())
                    {
                        int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        lPeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        dblHours = DBAccess.ReadDoubleValue(reader["AvailableHours"]) * Common.const_HoursMultiplier;
                        dblOffHours = DBAccess.ReadDoubleValue(reader["OffHours"]) * Common.const_HoursMultiplier;
                        if (lWResID == lPrevWResID || bFirst)
                        {
                            bFirst = false;
                        }
                        else
                        {
                            CStruct xResource = null;
                            dicResources.TryGetValue(lPrevWResID.ToString(), out xResource);
                            if (xResource != null)
                            {
                                xResource.CreateString("AvailablePeriods", sPeriods.ToString().TrimEnd(','));
                                xResource.CreateString("AvailableHours", sHours.ToString().TrimEnd(','));
                                xResource.CreateString("OffHours", sOffHours.ToString().TrimEnd(','));
                            }
                            sPeriods.Clear();
                            sHours.Clear();
                            sOffHours.Clear();
                        }
                        sPeriods.Append((lPeriodID.ToString("0"))).Append(',');
                        sHours.Append(dblHours.ToString("0")).Append(',');
                        sOffHours.Append(dblOffHours.ToString("0")).Append(',');
                        lPrevWResID = lWResID;
                    }
                    // write the final item
                    if (sHours.ToString() != "")
                    {
                        CStruct xResource = null;
                        dicResources.TryGetValue(lPrevWResID.ToString(), out xResource);
                        if (xResource != null)
                        {
                            xResource.CreateString("AvailablePeriods", sPeriods.ToString().TrimEnd(','));
                            xResource.CreateString("AvailableHours", sHours.ToString().TrimEnd(','));
                            xResource.CreateString("OffHours", sOffHours.ToString().TrimEnd(','));
                        }
                    }
                    reader.Close();

                    //// Commitments on other PIs - If ProjectID is 0 then department view displayed which has all work for resource
                    ////if (lProjectID > 0)
                    // V4.3 non-activex RPE - return all work for resource
                    sPos = "l";
                    {
                        oCommand = new SqlCommand("EPG_SP_ReadResourcesWorkB", dba.Connection);
                        oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        oCommand.Parameters.Add("ExcludeProjectID", SqlDbType.Int).Value = 0;
                        oCommand.Parameters.Add("StartPeriodID", SqlDbType.Int).Value = lStartPeriodID;
                        oCommand.Parameters.Add("FinishPeriodID", SqlDbType.Int).Value = lFinishPeriodID;
                        oCommand.Parameters.Add("WResIDs", SqlDbType.NVarChar, sGroupWResIDs.Length).Value = sGroupWResIDs;

                        reader = oCommand.ExecuteReader();

                        string sPeriodTag = "";
                        string sHoursTag = "";
                        sPeriodTag = "CommittedPeriods";
                        sHoursTag = "CommittedHours";
                        sHours.Clear();
                        lPrevWResID = 0;
                        sPeriods.Clear();
                        sHours.Clear();
                        bFirst = true;
                        while (reader.Read())
                        {
                            int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                            lPeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                            dblHours = DBAccess.ReadDoubleValue(reader[sHoursTag]);
                            if (lWResID == lPrevWResID || bFirst)
                            {
                                bFirst = false;
                            }
                            else
                            {
                                CStruct xResource = null;
                                dicResources.TryGetValue(lPrevWResID.ToString(), out xResource);
                                if (xResource != null)
                                {
                                    xResource.CreateString(sPeriodTag, sPeriods.ToString().TrimEnd(','));
                                    xResource.CreateString(sHoursTag, sHours.ToString().TrimEnd(','));
                                    sPeriods.Clear();
                                    sHours.Clear();
                                }
                            }
                            sPeriods.Append((lPeriodID.ToString("0"))).Append(',');
                            sHours.Append(dblHours.ToString("0")).Append(',');
                            lPrevWResID = lWResID;
                        }
                        // write the final item
                        if (sHours.ToString() != "")
                        {
                            CStruct xResource = null;
                            dicResources.TryGetValue(lPrevWResID.ToString(), out xResource);
                            if (xResource != null)
                            {
                                xResource.CreateString(sPeriodTag, sPeriods.ToString().TrimEnd(','));
                                xResource.CreateString(sHoursTag, sHours.ToString().TrimEnd(','));
                            }
                        }
                        reader.Close();
                    }

                    sPos = "m";
                    // NonWork
                    oCommand = new SqlCommand("EPG_SP_ReadResourcesWorkC", dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.Add("CalID", SqlDbType.Int).Value = oAdmin.PortfolioCommitmentsCalendarUID;
                    oCommand.Parameters.Add("StartPeriodID", SqlDbType.Int).Value = lStartPeriodID;
                    oCommand.Parameters.Add("FinishPeriodID", SqlDbType.Int).Value = lFinishPeriodID;
                    oCommand.Parameters.Add("WResIDs", SqlDbType.NVarChar, sGroupWResIDs.Length).Value = sGroupWResIDs;

                    reader = oCommand.ExecuteReader();

                    sHours.Clear();
                    lPrevWResID = 0;
                    sPeriods.Clear();
                    sHours.Clear();
                    bFirst = true;
                    while (reader.Read())
                    {
                        int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        lPeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        dblHours = DBAccess.ReadDoubleValue(reader["NonWorkHours"]);
                        if (lWResID == lPrevWResID || bFirst)
                        {
                            bFirst = false;
                        }
                        else
                        {
                            CStruct xResource = null;
                            dicResources.TryGetValue(lPrevWResID.ToString(), out xResource);
                            if (xResource != null)
                            {
                                xResource.CreateString("NonWorkPeriods", sPeriods.ToString().TrimEnd(','));
                                xResource.CreateString("NonWorkHours", sHours.ToString().TrimEnd(','));
                            }
                            sPeriods.Clear();
                            sHours.Clear();
                        }
                        sPeriods.Append((lPeriodID.ToString("0"))).Append(',');
                        sHours.Append(dblHours.ToString("0")).Append(',');
                        lPrevWResID = lWResID;
                    }
                    // write the final item
                    if (sHours.ToString() != "")
                    {
                        CStruct xResource = null;
                        dicResources.TryGetValue(lPrevWResID.ToString(), out xResource);
                        if (xResource != null)
                        {
                            xResource.CreateString("NonWorkPeriods", sPeriods.ToString().TrimEnd(','));
                            xResource.CreateString("NonWorkHours", sHours.ToString().TrimEnd(','));
                        }
                    }

                    reader.Close();
                }
                eStatus = dba.Status;
                sPos = "z";
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleException("GetPIResourcesStruct : " + sPos, (StatusEnum)8791, ex);
            }
        Exit_Function:
            xReply = xPIResources;
            return eStatus;
        }

        private static string BuildPortfolioResourcesSelectQuery(DBAccess dba, int lWResID, List<CStruct> clnDisplayFields, string sWResIDs, int lDeptCode, int lRoleCode)
        {
            // converts XML query into SQL
            //string s = "";
            //StatusEnum eStatus = StatusEnum.rsSuccess;
            // check for display fields
            int lCodeCount = 0;
            string sName = "";
            string sSelect = "";
            string sFrom = "";
            string stemp = "";
            string sTableAlias = "";
            string sWhere = "";
            string sTable = "";
            string sField = "";


            sSelect = "SELECT WR.WRES_ID,RES_NAME,WRES_INACTIVE,WRES_IS_GENERIC,MR_NOTES,WR.WRES_RP_DEPT as RPDeptUID,BC_UID as CCRoleUID,WRES_EMAIL";
            sFrom = " FROM EPG_RESOURCES WR " + " LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = " + lWResID.ToString() + " LEFT JOIN EPGP_COST_XREF CX ON WR.WRES_ID = CX.WRES_ID";
            if (clnDisplayFields != null)
            {
                foreach (CStruct xItem in clnDisplayFields)
                {
                    TSFieldFormatEnum eFieldFormat = (TSFieldFormatEnum)xItem.GetIntAttr("FieldFormat");
                    SpecialFieldIDsEnum eFieldID = (SpecialFieldIDsEnum)xItem.GetIntAttr("FieldID");
                    sName = "Field" + ((int)eFieldID).ToString();
                    switch (eFieldFormat)
                    {
                        case TSFieldFormatEnum.ffCode:
                            switch (eFieldID)
                            {
                                case SpecialFieldIDsEnum.sfDeptName:
                                    lCodeCount++;
                                    sTableAlias = "TSDEPT" + lCodeCount.ToString();
                                    //sSelect = sSelect + sTableAlias.Replace(",XY.LV_VALUE AS ", "XY") + sName;
                                    sSelect += (",XY.LV_VALUE AS ").Replace("XY", sTableAlias) + sName;
                                    sFrom += (" LEFT JOIN EPGP_LOOKUP_VALUES XY ON (XY.LV_UID = WR.WRES_DEPT)").Replace("XY", sTableAlias);
                                    break;
                                case SpecialFieldIDsEnum.sfRPDeptName:
                                    lCodeCount++;
                                    sTableAlias = "RPDEPT" + lCodeCount.ToString();
                                    //sSelect = sSelect + sTableAlias.Replace(",XY.LV_VALUE AS ", "XY") + sName;
                                    sSelect += (",XY.LV_VALUE AS ").Replace("XY", sTableAlias) + sName;
                                    sFrom += (" LEFT JOIN EPGP_LOOKUP_VALUES XY ON (XY.LV_UID = WR.WRES_RP_DEPT)").Replace("XY", sTableAlias);
                                    break;
                                default:
                                    if (GetCustomFieldNameFromID(dba, (int)eFieldID, out sTable, out sField) != StatusEnum.rsSuccess)
                                        goto Exit_Function;

                                    // BUGFIX 27JUN08 V5.3 - Bill reported 8781 at St Judes. Custom field has likely been deleted
                                    if (sTable != "" && sField != "")
                                    {
                                        lCodeCount++;
                                        sTableAlias = "C" + lCodeCount.ToString();
                                        stemp = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                        //sFrom += sTableAlias.Replace(stemp, "XX");
                                        sFrom += stemp.Replace("XX", sTableAlias);
                                        stemp = " LEFT JOIN EPGP_LOOKUP_VALUES XY ON XY.LV_UID = XX." + sField + " ";
                                        stemp = stemp.Replace("XX", sTableAlias);
                                        lCodeCount++;
                                        sTableAlias = "C" + lCodeCount.ToString();
                                        sFrom += stemp.Replace("XY", sTableAlias);
                                        sSelect += (",XY.LV_VALUE AS ").Replace("XY", sTableAlias) + sName;
                                        ////lCodeCount = lCodeCount + 1
                                        ////sTableAlias = "C" & Format$(lCodeCount, "0")
                                        ////stemp = " LEFT JOIN " & sTable & " XX ON WR.WRES_ID = XX.WRES_ID"
                                        ////sFrom = sFrom & Replace(stemp, "XX", sTableAlias)
                                        ////stemp = " LEFT JOIN EPGP_LOOKUP_VALUES XY ON XY.LV_UID = XX." & sField & " "
                                        //stemp = Replace(stemp, "XX", sTableAlias)
                                        //lCodeCount = lCodeCount + 1
                                        //sTableAlias = "C" & Format$(lCodeCount, "0")
                                        //sFrom = sFrom & Replace(stemp, "XY", sTableAlias)
                                        //sSelect = sSelect & Replace(",XY.LV_VALUE AS ", "XY", sTableAlias) & sName
                                    }
                                    else
                                    {
                                        sSelect += ",'**Invalid Column**' AS " + sName;
                                    }
                                    break;
                            }
                            break;
                        case TSFieldFormatEnum.ffText:
                            //''                    If eFieldID <> sfResourceName And eFieldID <> sfResourceNotes And eFieldID <> sfResourceCostCategory Then
                            //''                        lCodeCount = lCodeCount + 1
                            //''                        sTableAlias = "T" & Format$(lCodeCount, "0")
                            //''                        If GetCustomFieldNameFromID(oDataAccess, eFieldID, sTable, sField, eStatus) <> rsSuccess Then GoTo Exit_Function
                            //''
                            //''                        stemp = " LEFT JOIN " & sTable & " XX ON WR.WRES_ID = XX.WRES_ID"
                            //''                        sFrom = sFrom & Replace(stemp, "XX", sTableAlias)
                            //''                        sSelect = sSelect & Replace(",XY." & sField & " AS ", "XY", sTableAlias) & sName
                            //''                    End If
                            switch (eFieldID)
                            {
                                case SpecialFieldIDsEnum.sfResourceName:
                                case SpecialFieldIDsEnum.sfResourceNotes:
                                case SpecialFieldIDsEnum.sfResourceCostCategory:
                                case SpecialFieldIDsEnum.sfRoleName:
                                case SpecialFieldIDsEnum.sfResourceEMail:
                                    break;
                                default:
                                    if (GetCustomFieldNameFromID(dba, (int)eFieldID, out sTable, out sField) != StatusEnum.rsSuccess)
                                        goto Exit_Function;

                                    // BUGFIX 27JUN08 V5.3 - Bill reported 8781 at St Judes. Custom field has likely been deleted
                                    if (sTable != "" && sField != "")
                                    {
                                        lCodeCount++;
                                        sTableAlias = "T" + lCodeCount.ToString("0");
                                        stemp = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                        sFrom += stemp.Replace("XX", sTableAlias);
                                        sSelect += (",XY." + sField + " AS ").Replace("XY", sTableAlias) + sName;
                                    }
                                    else
                                    {
                                        sSelect += ",'**Invalid Column**' AS " + sName;
                                    }
                                    break;
                            }
                            break;
                        case TSFieldFormatEnum.ffCustom:
                            switch (eFieldID)
                            {
                                case SpecialFieldIDsEnum.sfResourceRate:
                                    sTable = "EPGP_COST_RATES";
                                    sField = "RT_UID";
                                    lCodeCount++;
                                    sTableAlias = "C" + lCodeCount.ToString("0");
                                    stemp = " LEFT JOIN " + sTable + " XX ON WR.WRES_ID = XX.WRES_ID";
                                    sFrom += stemp.Replace("XX", sTableAlias);
                                    stemp = " LEFT JOIN EPG_RATES XY ON XY.RT_UID = XX." + sField + " ";
                                    stemp = stemp.Replace("XX", sTableAlias);
                                    lCodeCount++;
                                    sTableAlias = "C" + lCodeCount.ToString("0");
                                    sFrom += stemp.Replace("XY", sTableAlias);
                                    sSelect += (",XY.RT_NAME AS ").Replace("XY", sTableAlias) + sName;
                                    //Case SpecialFieldIDsEnum.sfResourceRate
                                    //    sTable = "EPGP_COST_RATES"
                                    //    sField = "RT_UID"
                                    //    lCodeCount = lCodeCount + 1
                                    //    sTableAlias = "C" & Format$(lCodeCount, "0")
                                    //    stemp = " LEFT JOIN " & sTable & " XX ON WR.WRES_ID = XX.WRES_ID"
                                    //    sFrom = sFrom & Replace(stemp, "XX", sTableAlias)
                                    //    stemp = " LEFT JOIN EPG_RATES XY ON XY.RT_UID = XX." & sField & " "
                                    //    stemp = Replace(stemp, "XX", sTableAlias)
                                    //    lCodeCount = lCodeCount + 1
                                    //    sTableAlias = "C" & Format$(lCodeCount, "0")
                                    //    sFrom = sFrom & Replace(stemp, "XY", sTableAlias)
                                    //    sSelect = sSelect & Replace(",XY.RT_NAME AS ", "XY", sTableAlias) & sName
                                    break;
                            }
                            break;
                    }
                }
            }

            sWhere = " WHERE WR.WRES_ID <> 1 ";
            sWhere += " AND WR.WRES_INACTIVE = 0 ";
            sWhere += " AND (WR.WRES_IS_RESOURCE <> 0 OR WR.WRES_IS_GENERIC <> 0) ";
            if (sWResIDs != "")
                sFrom += " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + sWResIDs + "') LT on WR.WRES_ID=LT.TokenVal ";

        Exit_Function:
            return sSelect + sFrom + sWhere + " ORDER BY RES_NAME";
        }

        private static StatusEnum GetCustomFieldNameFromID(DBAccess dba, int lFieldID, out string sTableName, out string sFieldName)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            sTableName = "";
            sFieldName = "";
            try
            {
                // Bugfix 27JUN08 V5.3 - Don't allow showthrough of table or field if fieldid not found
                SqlCommand oCommand = new SqlCommand("EPG_SP_ReadFieldInfo", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("FieldID", SqlDbType.Int).Value = lFieldID;
                SqlDataReader reader = oCommand.ExecuteReader();

                if (reader.Read())
                {
                    int lTableID = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                    int lFieldInTableID = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                    GetCFFieldName(lTableID, lFieldInTableID, out sTableName, out sFieldName);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleException("GetCustomFieldNameFromID", (StatusEnum)9194, ex);
            }
            return eStatus;
        }

        private static StatusEnum GetCostCategoryRoles(DBAccess dba, int lPortfolioCommitmentsCalendarUID, int lStartPeriodID, out Dictionary<string, CStruct> dicCostCategoryRolesOut)
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
                List<CStruct> list = new List<CStruct>();
                string sCostCategoryUIDs = "";

                CStruct xCostCategoryRole;
                while (reader.Read())
                {
                    lRoleUID = DBAccess.ReadIntValue(reader["BC_ROLE"]);
                    lLevel = DBAccess.ReadIntValue(reader["BC_LEVEL"]);
                    bAdd = false;
                    if (lRoleUID > 0 || lLevel == lNextValidLevel)
                    {
                        bAdd = true;
                        lNextValidLevel = lLevel - 1;
                        lCostCategoryUID = DBAccess.ReadIntValue(reader["BC_UID"]);
                        if (lRoleUID > 0)
                        {
                            // Build up list of cost categories with associated roles - use to get FTEs later
                            Common.AddIDToList(ref sCostCategoryUIDs, lCostCategoryUID);
                        }
                    }

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
                    if (bAdd)
                        dic.Add(lCostCategoryUID.ToString(), xCostCategoryRole);
                    if (list.Count == 0) list.Add(xCostCategoryRole); else list.Insert(0, xCostCategoryRole);

                }
                reader.Close();


                // Pick up the FTE conversion factor information
                if (sCostCategoryUIDs != "" && lPortfolioCommitmentsCalendarUID >= 0 && lStartPeriodID > 0)
                {
                    oCommand = new SqlCommand("EPG_SP_ReadFTEs", dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.Add("CalID", SqlDbType.Int).Value = lPortfolioCommitmentsCalendarUID;
                    oCommand.Parameters.Add("FromPeriodID", SqlDbType.Int).Value = lStartPeriodID;
                    oCommand.Parameters.Add("CostCategoryUIDs", SqlDbType.VarChar, 255).Value = sCostCategoryUIDs;
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
                //int l = 0;
                string sParentName = "";
                foreach (CStruct xCostCategoryRole2 in list)
                {
                    lLevel = xCostCategoryRole2.GetIntAttr("Level") - 1;
                    sLevelName[lLevel] = xCostCategoryRole2.GetStringAttr("Name");
                    lLevelID[lLevel] = xCostCategoryRole2.GetIntAttr("ID");
                    if (lLevel > 0)
                    {
                        for (int l = 0; l < lLevel; l++)
                        {
                            if (l == 0)
                                sParentName = sLevelName[l];
                            else
                                sParentName += "." + sLevelName[l];
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

        private static void GetCFFieldName(int lTableID, int lFieldID, out string sTable, out string sField)
        {
            sTable = "";
            sField = "";
            string sFormat = lFieldID.ToString("000");
            switch ((CustomFieldDBTable)lTableID)
            {
                case CustomFieldDBTable.ResourceINT:
                    sTable = "EPGC_RESOURCE_INT_VALUES";
                    sField = "RI_" + sFormat;
                    break;
                case CustomFieldDBTable.ResourceTEXT:
                    sTable = "EPGC_RESOURCE_TEXT_VALUES";
                    sField = "RT_" + sFormat;
                    break;
                case CustomFieldDBTable.ResourceDEC:
                    sTable = "EPGC_RESOURCE_DEC_VALUES";
                    sField = "RC_" + sFormat;
                    break;
                case CustomFieldDBTable.ResourceNTEXT:
                    sTable = "EPGC_RESOURCE_NTEXT_VALUES";
                    sField = "RN_" + sFormat;
                    break;
                case CustomFieldDBTable.ResourceDATE:
                    sTable = "EPGC_RESOURCE_DATE_VALUES";
                    sField = "RD_" + sFormat;
                    break;
                case CustomFieldDBTable.ResourceMV:
                    sTable = "EPGC_RESOURCE_MV_VALUES";
                    sField = "MVR_UID";
                    break;
                case CustomFieldDBTable.PortfolioINT:
                    sTable = "EPGP_PROJECT_INT_VALUES";
                    sField = "PI_" + sFormat;
                    break;
                case CustomFieldDBTable.PortfolioTEXT:
                    sTable = "EPGP_PROJECT_TEXT_VALUES";
                    sField = "PT_" + sFormat;
                    break;
                case CustomFieldDBTable.PortfolioDEC:
                    sTable = "EPGP_PROJECT_DEC_VALUES";
                    sField = "PC_" + sFormat;
                    break;
                case CustomFieldDBTable.PortfolioNTEXT:
                    sTable = "EPGP_PROJECT_NTEXT_VALUES";
                    sField = "PN_" + sFormat;
                    break;
                case CustomFieldDBTable.PortfolioDATE:
                    sTable = "EPGP_PROJECT_DATE_VALUES";
                    sField = "PD_" + sFormat;
                    break;
                case CustomFieldDBTable.Program:
                    sTable = "EPGP_PI_PROGS";
                    sField = "PROG_UID";
                    break;
                case (CustomFieldDBTable)301:
                    sTable = "EPGX_PROJ_INT_VALUES";
                    sField = "XI_" + sFormat;
                    break;
                case (CustomFieldDBTable)302:
                    sTable = "EPGX_PROJ_TEXT_VALUES";
                    sField = "XT_" + sFormat;
                    break;
                case (CustomFieldDBTable)303:
                    sTable = "EPGX_PROJ_DEC_VALUES";
                    sField = "XC_" + sFormat;
                    break;
                case (CustomFieldDBTable)304:
                    sTable = "EPGX_PROJ_NTEXT_VALUES";
                    sField = "XN_" + sFormat;
                    break;
                case (CustomFieldDBTable)305:
                    sTable = "EPGX_PROJ_DATE_VALUES";
                    sField = "XD_" + sFormat;
                    break;
                case (CustomFieldDBTable)402:
                    sTable = "EPGP_PI_PROGS";
                    sField = "PROG_PI_TEXT" + lFieldID.ToString("0");
                    break;
                case (CustomFieldDBTable)801:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_FLAG" + lFieldID.ToString("0");
                    break;
                case (CustomFieldDBTable)802:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_CTEXT" + lFieldID.ToString("0");
                    break;
                case (CustomFieldDBTable)803:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_NUMBER" + lFieldID.ToString("0");
                    break;
                default:
                    sTable = "Unknown Table";
                    sField = "";
                    break;
            }
        }

        private static StatusEnum GetPeriods(DBAccess dba, int iCal, out List<CPeriod> clnPeriods)
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

        private static StatusEnum ReadUserInfo(DBAccess dba, int lWResID, UserInfoContextsEnum eContext, out int lData, out string sXML)
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
    }
}
