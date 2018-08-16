using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class EPKItem
    {
        public int ID;
        public string Name;
        public int Value;
    }

    public class EPKCustomField
    {
        public int ID;
        public string Name;
        public string FieldName;
        public int Value;
        public int Fieldtype;
        public int CFTable;
        public int CFField;
        public int LookupID;
    }
    
    internal class CostCategoryInternal
    {
        public int UID;
        public int ID;
        public int Level;
        public string UOM;
        public int ParentUID;
        public string RollupUOM;
        public bool IsSummary;
        public bool HasData;
        public bool IsAvailable;
    }
        internal class CostValues
        {
            private double[,] quantities;
            private double[,] costs;

            private int lPeriodCount;
            private int lCategoryCount;

            public CostValues(int periodCount, int categoryCount)
            {
               //  category 0 is the TOTAL line
                lPeriodCount = periodCount;
                lCategoryCount = categoryCount + 1;
                quantities = new double[lPeriodCount, lCategoryCount];
                costs = new double[lPeriodCount, lCategoryCount];
            }

            public void SetArrays ()
            {
                for (int i = 0; i < lPeriodCount; i++)
                {
                    for (int j = 0; j < lCategoryCount; j++)
                    {
                        quantities[i, j] = 0;
                        costs[i, j] = 0;
                    }
                }
            }

            public void setCost(int period, int category, double costvalue)
            {
                if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                    costs[period - 1, category] = costvalue;
            }

            public void incrCost(int period, int category, double costvalue)
            {
                if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                    costs[period - 1, category] += costvalue;
            }

            public double getCost(int period, int category)
            {
                if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                {
                    return costs[period - 1, category];
                }
                else
                {
                    return 0;
                }
            }

            public void setQuantity(int period, int category, double quantityvalue)
            {
                if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                    quantities[period - 1, category] = quantityvalue;
            }
            public void incrQuantity(int period, int category, double quantityvalue)
            {
                if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                    quantities[period - 1, category] += quantityvalue;
            }

            public double getQuantity(int period, int category)
            {
                if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                {
                    return quantities[period - 1, category];
                }
                else
                {
                    return 0;
                }
            }
        }

        internal class CostTotal
        {
            public int CB_ID;
            public int CT_ID;
            public int FIELD_ID;
        }

    public class dbaUsers
    {
        public static StatusEnum ExecuteSQLSelect(SqlCommand oCommand, out SqlDataReader reader)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            reader = null;
            try
            {
                reader = oCommand.ExecuteReader();
            }
            catch
            {
                //eStatus = HandleStatusError(SeverityEnum.Exception, "ExecuteSQL", (StatusEnum)eStatusOnException, ex.Message.ToString());
                eStatus = (StatusEnum)99871;
            }
            return eStatus;
        }
        public static StatusEnum ExportPIInfo(DBAccess dba, string sProjectIDs, out string sResult)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;

            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;

            // see if we have a list of mapped fields, if we do the we will use them to limit the fields we pass
            bool bMappedFields = false;

            // jwg 6/12/12 - send back ALL custom fields - ignore any mapping

            //cmdText = "SELECT COUNT(*) as lCount FROM EPG_WE_MAPPING WHERE WEM_ENTITY=20";
            //oCommand = new SqlCommand(cmdText, dba.Connection);
            //if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            //{
            //    if (reader.Read())
            //    {
            //        int lCount = (int)reader["lCount"];
            //        if (lCount > 0) bMappedFields = true;
            //    }
            //    reader.Close();
            //}

            // Read list of Standard Portfolio Fields we want - Standard means all except for Custom Fields - only ones that are mapped
            List<int> clnLookups = new List<int>();
            SortedList<int, EPKItem> clnStandardFields = new SortedList<int, EPKItem>();
            SortedList<int, EPKCustomField> clnCustomFields = new SortedList<int, EPKCustomField>();
            EPKItem oField;
            EPKCustomField oCustomField;
            bool bNeedResources = false;

            // We want these fields regardless so we'll just add them - they won't be mapped
            cmdText = "SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS" +
                    " Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID";
     //       oCommand.CommandText = cmdText;
            oCommand = new SqlCommand(cmdText, dba.Connection);
            if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            {
                while (reader.Read())
                {
                    int nID = (int)reader["FIELD_ID"];
                    int nFieldType = (int)reader["FIELD_FORMAT"];
                    string sName = reader["FIELD_NAME"].ToString();
                    oField = new EPKItem();
                    oField.ID = nID;
                    oField.Name = sName;
                    oField.Value = nFieldType;
                    clnStandardFields.Add(nID, oField);
                }
                reader.Close();
            }

            //  now read marked list from EPGT_FIELDS
            cmdText = "SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f";
            if (bMappedFields) cmdText = cmdText + " Join EPG_WE_MAPPING m On f.FIELD_ID=m.WEM_EPK_FIELD_ID And WEM_ENTITY=20";
            cmdText = cmdText + " Where FIELD_EXPORT=1 ORDER BY FIELD_ID";
            oCommand = new SqlCommand(cmdText, dba.Connection);
            if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            {
                while (reader.Read())
                {
                    int nID = (int)reader["FIELD_ID"];
                    int nFieldType = (int)reader["FIELD_FORMAT"];
                    string sName = reader["FIELD_NAME"].ToString();
                    oField = new EPKItem();
                    oField.ID = nID;
                    oField.Name = sName;
                    oField.Value = nFieldType;
                    clnStandardFields.Add(nID, oField);
                    // add lookup UID to collection if TS Dept or RP Dept  - will we have Charge Code and similar here for PIs?
                    //                    if (nID == 3010) if (!clnLookups.Contains(lTSDeptEROC)) clnLookups.Add(lTSDeptEROC);
                    //                    if (nID == 3020) if (!clnLookups.Contains(lRPDeptEROC)) clnLookups.Add(lRPDeptEROC);
                    // we could remove joins to get Resource Name from main SQL because we might have to read the list of resaources anyway
                    //  for now we won't do that and expect that usually there will not be a CF of type Resource and we can avoid reading them
                    //  if the main SQL stmnt is too slow then removing the joins to EPG_RESOURCES might be one thing to try
                }
                reader.Close();
            }


            {
                //eStatus = HandleStatusError(SeverityEnum.Exception, "SelectDataById", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }

            // read list of Custom Portfolio Fields - if there is a list of mapped fields then get only the ones that are mapped
            cmdText = "Select * From EPGC_FIELD_ATTRIBS f";
            if (bMappedFields) cmdText = cmdText + " Join EPG_WE_MAPPING m On f.FA_FIELD_ID=m.WEM_EPK_FIELD_ID And WEM_ENTITY=20";
            cmdText = cmdText + " Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID";
            oCommand.CommandText = cmdText;
            oCommand = new SqlCommand(cmdText, dba.Connection);
            if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            {
                while (reader.Read())
                {
                    oCustomField = new EPKCustomField();
                    int nID = DBAccess.ReadIntValue(reader["FA_FIELD_ID"]);
                    oCustomField.ID = nID;
                    oCustomField.Name = reader["FA_NAME"].ToString();
                    oCustomField.Fieldtype = DBAccess.ReadIntValue(reader["FA_FORMAT"]);
                    oCustomField.CFTable = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                    oCustomField.CFField = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                    oCustomField.LookupID = DBAccess.ReadIntValue(reader["FA_LOOKUP_UID"]);

                    clnCustomFields.Add(nID, oCustomField);
                    // if it is a Code then add the Lookup to those we need to go get 
                    if (oCustomField.Fieldtype == 4 && oCustomField.LookupID > 0) if (!clnLookups.Contains(nID)) clnLookups.Add(nID);
                    if (oCustomField.Fieldtype == 7) bNeedResources = true;
                }
                reader.Close();
            }

            // Make a list of the lookups we need           
            SortedList<int, string> clnLookupValues = new SortedList<int, string>();
            string sLookupList = "";
            //int lLookup = 0;

            foreach (int iLookupId in clnLookups)
            {
                if (sLookupList.Length > 0)
                    sLookupList = sLookupList + "," + iLookupId.ToString();
                else
                    sLookupList = iLookupId.ToString();
            }

            // get the full(?) values for the lookup tables
            if (sLookupList.Length > 0)
            {
                oCommand = new SqlCommand("PPM_SP_ReadLookupValuesByLookup", dba.Connection);
                oCommand.Parameters.AddWithValue("sList", sLookupList);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    int lVal = DBAccess.ReadIntValue(reader["LV_UID"]);
                    string sVal = reader["LV_FULLVALUE"].ToString();
                    clnLookupValues.Add(lVal, sVal);
                }
                reader.Close();
            }

            // before getting most fields for each PI in one SQL stmnt get the MV field values (Programs only for PIs) into a collection of collections
            //    stick with same method as for Resources even though there can only be a single MV field
            SortedList<int, SortedList<int, string>> clnMVs = new SortedList<int, SortedList<int, string>>();
            SortedList<int, string> clnMVValues;
            int lPrevProjectID;
            string sGroups;

            // Program Groups - more complicated as there can be multiple groups - for now I'll just lump them all together and assume the result is self explanatory
            if (clnStandardFields.ContainsKey(9960))
            {
                lPrevProjectID = 0;
                sGroups = "";
                cmdText = "Select pg.PROG_UID,PROJECT_ID,LV_FULLVALUE as GROUP_NAME From EPGP_PI_PROGS pg" +
                            " Join EPGP_LOOKUP_VALUES lv on lv.LV_UID=pg.PROG_UID";
                if (sProjectIDs.Length > 0) cmdText = cmdText + " JOIN dbo.EPG_FN_ConvertListToTable(N'" + sProjectIDs + "') LT on PROJECT_ID=LT.TokenVal";
                cmdText = cmdText + " Order By PROJECT_ID,pg.FIELD_ID";

                oCommand = new SqlCommand(cmdText, dba.Connection);
                if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
                {
                    clnMVValues = new SortedList<int, string>();
                    int lProjectID = 0;
                    while (reader.Read())
                    {
                        lProjectID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        string sVal = reader["GROUP_NAME"].ToString();
                        if (lProjectID != lPrevProjectID && lPrevProjectID > 0)
                        {
                            if (!clnMVValues.ContainsKey(lPrevProjectID)) clnMVValues.Add(lPrevProjectID, sGroups);
                            sGroups = "";
                        }
                        if (sGroups.Length > 0) sGroups = sGroups + ", " + sVal; else sGroups = sVal;
                        lPrevProjectID = lProjectID;
                    }
                    reader.Close();
                    if (sGroups.Length > 0) if (!clnMVValues.ContainsKey(lPrevProjectID)) clnMVValues.Add(lPrevProjectID, sGroups);
                    clnMVs.Add(9960, clnMVValues);
                }
            }

            // get a resources collection if we need to resolve any Custom Fields
            SortedList<int, string> clnResources = new SortedList<int, string>();
            if (bNeedResources)
            {
                cmdText = "Select WRES_ID,RES_NAME From EPG_RESOURCES";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
                {
                    while (reader.Read())
                    {
                        int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        string sName = reader["RES_NAME"].ToString();
                        clnResources.Add(lWResID, sName);
                    }
                    reader.Close();
                }
            }

            // Build SQL to get Portfolio fields - only add the joins that are needed by special selected fields and Custom Fields
            string sFields, sJoins;

            // standard fields
            sFields = "pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID," +
                "PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE";
            sJoins = " ";

            if (clnStandardFields.ContainsKey(9224))    //  Linked Schedule
            {
                sFields = sFields + ",ps.WPROJ_ID";
                sJoins = sJoins + " Left Join EPGX_PROJECT_VERSIONS ps On ps.PROJECT_ID=pi.PROJECT_ID";
            }
            if (clnStandardFields.ContainsKey(9911))    //  Stage
            {
                sFields = sFields + ",sg.STAGE_NAME";
                sJoins = sJoins + " Left Join EPGP_STAGES sg On sg.STAGE_ID=pi.PROJECT_STAGE_ID";
            }
            if (clnStandardFields.ContainsKey(9922))    //  Stage Owner
            {
                sFields = sFields + ",r1.RES_NAME as StageOwner";
                sJoins = sJoins + " Left Join EPG_RESOURCES r1 On r1.WRES_ID=pi.PROJECT_OWNER";
            }
            if (clnStandardFields.ContainsKey(9925))    //  Item Manager
            {
                sFields = sFields + ",r2.RES_NAME as ItemManager";
                sJoins = sJoins + " Left Join EPG_RESOURCES r2 On r2.WRES_ID=pi.PROJECT_MANAGER";
            }
            if (clnStandardFields.ContainsKey(9930))    //  Schedule Manager
            {
                sFields = sFields + ",r3.RES_NAME as ScheduleManager";
                sJoins = sJoins + " Left Join EPG_RESOURCES r3 On r3.WRES_ID=pi.PROJECT_PLAN_OWNER";
            }
            if (clnStandardFields.ContainsKey(9920))    //  Created By
            {
                sFields = sFields + ",r4.RES_NAME as CreatedBy";
                sJoins = sJoins + " Left Join EPG_RESOURCES r4 On r4.WRES_ID=pi.PROJECT_CREATEDBY";
            }

            //  add custom fields
            bool b01 = false, b02 = false, b03 = false, b05 = false;
            string sTable, sField;

            foreach (KeyValuePair<int, EPKCustomField> oCustomField1 in clnCustomFields)
            {
                switch (oCustomField1.Value.CFTable)
                {
                    case 201:
                        if (EPKClass01.GetTableAndField(oCustomField1.Value.CFTable, oCustomField1.Value.CFField, out sTable, out sField))
                        {
                            sFields = sFields + "," + sField;
                            if (!b01) sJoins = sJoins + " LEFT JOIN " + sTable + " x1 ON x1.PROJECT_ID=pi.PROJECT_ID";
                            oCustomField1.Value.FieldName = sField;
                            b01 = true;
                        }
                        break;
                    case 202:
                        if (EPKClass01.GetTableAndField(oCustomField1.Value.CFTable, oCustomField1.Value.CFField, out sTable, out sField))
                        {
                            sFields = sFields + "," + sField;
                            if (!b02) sJoins = sJoins + " LEFT JOIN " + sTable + " x2 ON x2.PROJECT_ID=pi.PROJECT_ID";
                            oCustomField1.Value.FieldName = sField;
                            b02 = true;
                        }
                        break;
                    case 203:
                        if (EPKClass01.GetTableAndField(oCustomField1.Value.CFTable, oCustomField1.Value.CFField, out sTable, out sField))
                        {
                            sFields = sFields + "," + sField;
                            if (!b03) sJoins = sJoins + " LEFT JOIN " + sTable + " x3 ON x3.PROJECT_ID=pi.PROJECT_ID";
                            oCustomField1.Value.FieldName = sField;
                            b03 = true;
                        }
                        break;
                    case 205:
                        if (EPKClass01.GetTableAndField(oCustomField1.Value.CFTable, oCustomField1.Value.CFField, out sTable, out sField))
                        {
                            sFields = sFields + "," + sField;
                            if (!b05) sJoins = sJoins + " LEFT JOIN " + sTable + " x5 ON x5.PROJECT_ID=pi.PROJECT_ID";
                            oCustomField1.Value.FieldName = sField;
                            b05 = true;
                        }
                        break;
                }
            }

            // ready to put the beast together and read some data
            cmdText = "SELECT " + sFields + " FROM EPGP_PROJECTS pi " + sJoins;
            if (sProjectIDs.Length > 0) cmdText = cmdText + " JOIN dbo.EPG_FN_ConvertListToTable(N'" + sProjectIDs + "') LT on pi.PROJECT_ID=LT.TokenVal";
            cmdText = cmdText + " Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID";

            CStruct xPortfolioItems = new CStruct();
            xPortfolioItems.Initialize("PortfolioItems");
            xPortfolioItems.CreateStringAttr("Key", "EPK");

            oCommand = new SqlCommand(cmdText, dba.Connection);
            if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                foreach (DataRow row in dt.Rows)
                {
                    int lProjectID = 0;
                    string sWeePID = "";
                    string sXMLType = "";
                    string sVal = "";
                    DateTime dVal = DateTime.MinValue;
                    double dblVal = 0;
                    int lVal = 0;

                    lProjectID = DBAccess.ReadIntValue(row["PROJECT_ID"]);
                    sWeePID = row["PROJECT_EXT_UID"].ToString();
                    if (lProjectID > 0 && sWeePID.Length > 0)
                    {
                        CStruct xPortfolioItem = xPortfolioItems.CreateSubStruct("PortfolioItem");
                        xPortfolioItem.CreateStringAttr("ItemID", sWeePID);

                        //  get the team -  another SELECT withing the main one is ok? I guess so but not if using SQLDataREader by the way
                        SqlDataReader reader1;
                        string steamlist = "";
                        cmdText = "Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ";  // reject entries w/o resource in case
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        SqlParameter pPROJECT_ID = oCommand.Parameters.AddWithValue("@PROJECT_ID", lProjectID);
                        if (ExecuteSQLSelect(oCommand, out reader1) == StatusEnum.rsSuccess)
                        {
                            while (reader1.Read())
                            {
                                string steammember = DBAccess.ReadIntValue(reader1["WRES_ID"]).ToString(); ;
                                if (steamlist.Length == 0) steamlist = steammember; else steamlist += "," + steammember;
                            }
                        }
                        reader1.Close();
                        if (steamlist.Length > 0)
                        {
                            CStruct xTeam = xPortfolioItem.CreateSubStruct("Field");
                            xTeam.CreateStringAttr("ID", "Team"); 
                            xTeam.CreateStringAttr("Value", steamlist);
                        }

                        foreach (KeyValuePair<int, EPKItem> oField1 in clnStandardFields)
                        {
                            switch (oField1.Value.ID)
                            {
                                case 9900:
                                    sXMLType = "s";
                                    sVal = row["PROJECT_NAME"].ToString();
                                    break;
                                case 9903:
                                    sXMLType = "i";
                                    lVal = lProjectID;
                                    break;
                                case 9901:
                                    dVal = DBAccess.ReadDateValue(row["PROJECT_START_DATE"]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                case 9902:
                                    dVal = DBAccess.ReadDateValue(row["PROJECT_FINISH_DATE"]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                case 9911:
                                    sVal = row["STAGE_NAME"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9918:
                                    sXMLType = "";
                                    //sVal = row["PROJECT_EXT_UID"].ToString();
                                    break;
                                case 9920:
                                    sVal = row["CreatedBy"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9921:
                                    dVal = DBAccess.ReadDateValue(row["PROJECT_CREATED"]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                case 9922:
                                    sVal = row["StageOwner"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9924:
                                    sXMLType = "i";
                                    lVal = DBAccess.ReadIntValue(row["WPROJ_ID"]);
                                    break;
                                case 9925:
                                    sVal = row["ItemManager"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9928:
                                    sXMLType = "i";
                                    lVal = DBAccess.ReadIntValue(row["PROJECT_PRIORITY"]);
                                    break;
                                case 9930:
                                    sVal = row["ScheduleManager"].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 9936:
                                    dVal = DBAccess.ReadDateValue(row["WORKITEM_START_DATE"]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                case 9960:
                                    sVal = GetMVValue(clnMVs, oField1.Value.ID, lProjectID);
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                default:
                                    sXMLType = "";
                                    break;
                            }

                            if (sXMLType.Length > 0)
                            {
                                CStruct xField = xPortfolioItem.CreateSubStruct("Field");
                                xField.CreateIntAttr("ID", oField1.Value.ID);
                                switch (sXMLType)
                                {
                                    case "d":
                                        xField.CreateDateAttr("Value", dVal);
                                        break;
                                    case "i":
                                        xField.CreateIntAttr("Value", lVal);
                                        break;
                                    case "dbl":
                                        xField.CreateDoubleAttr("Value", dblVal);
                                        break;
                                    default:
                                        xField.CreateStringAttr("Value", sVal);
                                        break;
                                }
                            }
                        }

                        foreach (KeyValuePair<int, EPKCustomField> oField1 in clnCustomFields)
                        {
                            switch (oField1.Value.CFTable)
                            {
                                case 201:
                                    if (oField1.Value.Fieldtype == 4)  // code
                                    {
                                        lVal = DBAccess.ReadIntValue(row[oField1.Value.FieldName]);
                                        sVal = GetLookupValue(clnLookupValues, lVal);
                                        if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    }
                                    else if (oField1.Value.Fieldtype == 7)  // resource
                                    {
                                        lVal = DBAccess.ReadIntValue(row[oField1.Value.FieldName]);
                                        sVal = GetLookupValue(clnResources, lVal);
                                        if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    }
                                    else
                                    {
                                        sXMLType = "i";
                                        lVal = DBAccess.ReadIntValue(row[oField1.Value.FieldName]);
                                    }
                                    break;
                                case 202:
                                    sVal = row[oField1.Value.FieldName].ToString();
                                    if (sVal.Length > 0) sXMLType = "s"; else sXMLType = "";
                                    break;
                                case 203:
                                    sXMLType = "dbl";
                                    dblVal = DBAccess.ReadDoubleValue(row[oField1.Value.FieldName]);
                                    break;
                                case 205:
                                    dVal = DBAccess.ReadDateValue(row[oField1.Value.FieldName]);
                                    if (dVal == DateTime.MinValue) sXMLType = ""; else sXMLType = "d";
                                    break;
                                default:
                                    sXMLType = "";
                                    break;
                            }
                            if (sXMLType.Length > 0)
                            {
                                CStruct xField = xPortfolioItem.CreateSubStruct("Field");
                                xField.CreateIntAttr("ID", oField1.Value.ID);
                                switch (sXMLType)
                                {
                                    case "d":
                                        xField.CreateDateAttr("Value", dVal);
                                        break;
                                    case "i":
                                        xField.CreateIntAttr("Value", lVal);
                                        break;
                                    case "dbl":
                                        xField.CreateDoubleAttr("Value", dblVal);
                                        break;
                                    default:
                                        xField.CreateStringAttr("Value", sVal);
                                        break;
                                }
                            }
                        }
                    }
                }
                reader.Close();
            }


            sResult = xPortfolioItems.XML();
            return eStatus;

        }
        public static string GetMVValue(SortedList<int, SortedList<int, string>> clnMVs, int lFieldID, int lWresID)
        {
            string sValue = "";
            SortedList<int, string> clnMVValues;

            if (clnMVs.ContainsKey(lFieldID))
            {
                clnMVValues = clnMVs[lFieldID];
                if (clnMVValues.ContainsKey(lWresID)) sValue = clnMVValues[lWresID];
            }
            return sValue;
        }
        public static string GetLookupValue(SortedList<int, string> clnLookupValues, int lID)
        {
            string sValue = "";
            if (clnLookupValues.ContainsKey(lID)) sValue = clnLookupValues[lID];
            return sValue;
        }
        public static StatusEnum SelectGroupPermissions(DBAccess dba, int nGroupId, out DataTable dt)
        {
            string cmdText = "SELECT distinct (p.PERM_UID), p.PERM_ID, p.PERM_LEVEL, p.PERM_NAME, CAST(p.PERM_NOTES AS NVARCHAR(MAX)), p.PERM_WEINCLUDE, "
                                + "gp.GROUP_ID From EPG_PERMISSIONS p"
                                + " Left Join EPG_GROUP_PERMISSIONS gp On gp.PERM_UID=p.PERM_UID and gp.GROUP_ID=@p1"
                                + " Where p.PERM_WEINCLUDE=1"
                                + " Order by PERM_ID";

            dba.SelectDataById(cmdText, nGroupId, (StatusEnum)99925, out dt);
            return dba.Status;
        }
        public static StatusEnum SelectAvailCCs(DBAccess dba, int nCTId, out DataTable dt)
        {
            string cmdText = "SELECT cc.*,ac.BC_UID as BC_UID_incl From EPGP_COST_CATEGORIES cc"
                                + " Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID=cc.BC_UID and ac.CT_ID=@p1"
                                + " Order by BC_ID";
            dba.SelectDataById(cmdText, nCTId, (StatusEnum)99999, out dt);
            return dba.Status;
        }
        public static StatusEnum SelectCTCalcs(DBAccess dba, int nCTId, out DataTable dt)
        {
            string cmdText = "SELECT * From EPGP_COST_CALC"
                                + " Where CT_ID=@p1"
                                + " Order by CL_ID";
            dba.SelectDataById(cmdText, nCTId, (StatusEnum)99999, out dt);
            return dba.Status;
        }
    }


    public enum CustomFieldTable
    {
        Unknown = 0,
        ResourceINT = 101,
        ResourceTEXT = 102,
        ResourceDEC = 103,
        ResourceNTEXT = 104,
        ResourceDATE = 105,
        ResourceMV = 151,
        PortfolioINT = 201,
        PortfolioTEXT = 202,
        PortfolioDEC = 203,
        PortfolioNTEXT = 204,
        PortfolioDATE = 205,
        Program = 251,
        ProjectINT = 301,
        ProjectTEXT = 302,
        ProjectDEC = 303,
        ProjectNTEXT = 304,
        ProjectDATE = 305,
        ProgramText = 402, //  ??
        TaskWIINT = 801,
        TaskWITEXT = 802,
        TaskWIDEC = 803
    }

    //public enum FieldType
    //{
    //    TypeCost = 8,
    //    TypeCode = 4,
    //    TypeMVCode = 40,
    //    TypeFlag = 13,
    //    TypeText = 9,
    //    TypeNumber = 3,
    //    TypeDate = 1,
    //    TypeNText = 19,
    //}

    //public enum EntityID
    //{
    //    Resource = 1,
    //    Portfolio = 2,
    //    Program = 3,
    //    Project = 4,
    //    Task = 5,
    //    Unknown = 0
    //}

    //public class EPKClass01
    //{

    //    public static int GetEntityID(int iTable)
    //    {
    //        EntityID nEntity;
    //        CustomFieldTable nTable = (CustomFieldTable)iTable;
    //        if (nTable >= CustomFieldTable.ResourceINT && nTable <= CustomFieldTable.ResourceMV)
    //            nEntity = EntityID.Resource;
    //        else if (nTable >= CustomFieldTable.PortfolioINT && nTable <= CustomFieldTable.PortfolioDATE)
    //            nEntity = EntityID.Portfolio;
    //        else if (nTable == CustomFieldTable.Program)
    //            nEntity = EntityID.Program;
    //        else if (nTable >= CustomFieldTable.ProjectINT && nTable <= CustomFieldTable.ProjectDATE)
    //            nEntity = EntityID.Project;
    //        else if (nTable >= CustomFieldTable.TaskWIINT && nTable <= CustomFieldTable.TaskWIDEC)
    //            nEntity = EntityID.Task;
    //        else
    //            nEntity = EntityID.Unknown;
    //        int iEntity = (Int32)nEntity;
    //        return iEntity;
    //    }

    //    public static string GetEntity(int iEntity)
    //    {
    //        string sEntity = "";
    //        EntityID nEntity = (EntityID)iEntity;

    //        if (nEntity == EntityID.Resource)
    //            sEntity = "Resource";
    //        else if (nEntity == EntityID.Portfolio)
    //            sEntity = "Portfolio";
    //        else if (nEntity == EntityID.Program)
    //            sEntity = "Program";
    //        else if (nEntity == EntityID.Project)
    //            sEntity = "Project";
    //        else if (nEntity == EntityID.Task)
    //            sEntity = "Task";
    //        else
    //            sEntity = "Unknown";
    //        return sEntity;
    //    }
    //    public static string GetDataType(int iFieldType)
    //    {
    //        string sDataType = "";
    //        FieldType nFieldType = (FieldType)iFieldType;

    //        switch (nFieldType)
    //        {
    //            case FieldType.TypeCost:
    //                sDataType = "Cost";
    //                break;
    //            case FieldType.TypeCode:
    //                sDataType = "Code";
    //                break;
    //            case FieldType.TypeDate:
    //                sDataType = "Date";
    //                break;
    //            case FieldType.TypeFlag:
    //                sDataType = "Flag";
    //                break;
    //            case FieldType.TypeNumber:
    //                sDataType = "Number";
    //                break;
    //            case FieldType.TypeText:
    //                sDataType = "Text";
    //                break;
    //            case FieldType.TypeNText:
    //                sDataType = "RTF";
    //                break;
    //            default:
    //                sDataType = "Unknown";
    //                break;

    //        }
    //        return sDataType;
    //    }

    //    public static string GetFieldFormat(int iDataType)
    //    {
    //        string sdatatype = "";
    //        FieldType nDataType = (FieldType)iDataType;
    //        switch (nDataType)
    //        {
    //            case FieldType.TypeCost:
    //                sdatatype = "Cost";
    //                break;
    //            case FieldType.TypeCode:
    //                sdatatype = "Code";
    //                break;
    //            case FieldType.TypeMVCode:
    //                sdatatype = "MV Code";
    //                break;
    //            case FieldType.TypeFlag:
    //                sdatatype = "Flag";
    //                break;
    //            case FieldType.TypeText:
    //                sdatatype = "Text";
    //                break;
    //            case FieldType.TypeNumber:
    //                sdatatype = "Number";
    //                break;
    //            case FieldType.TypeDate:
    //                sdatatype = "Date";
    //                break;
    //            case FieldType.TypeNText:
    //                sdatatype = "NText";
    //                break;
    //            default:
    //                sdatatype = "Unknown Type";
    //                break;
    //        }
    //        return sdatatype;
    //    }

    //    public static bool GetTableAndField(int iTable, int iField, out string sTable, out string sField)
    //    {
    //        bool bFound = true;
    //        string stable = "";
    //        string sfield = "";
    //        CustomFieldTable nTable = (CustomFieldTable)iTable;
    //        switch (nTable)
    //        {
    //            case CustomFieldTable.ResourceINT:
    //                stable = "EPGC_RESOURCE_INT_VALUES";
    //                sfield = "RI_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceTEXT:
    //                stable = "EPGC_RESOURCE_TEXT_VALUES";
    //                sfield = "RT_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceDEC:
    //                stable = "EPGC_RESOURCE_DEC_VALUES";
    //                sfield = "RC_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceNTEXT:
    //                stable = "EPGC_RESOURCE_NTEXT_VALUES";
    //                sfield = "RN_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceDATE:
    //                stable = "EPGC_RESOURCE_DATE_VALUES";
    //                sfield = "RD_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceMV:
    //                stable = "EPGC_RESOURCE_MV_VALUES";
    //                sfield = "MVR_UID";
    //                break;
    //            case CustomFieldTable.PortfolioINT:
    //                stable = "EPGP_PROJECT_INT_VALUES";
    //                sfield = "PI_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.PortfolioTEXT:
    //                stable = "EPGP_PROJECT_TEXT_VALUES";
    //                sfield = "PT_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.PortfolioDEC:
    //                stable = "EPGP_PROJECT_DEC_VALUES";
    //                sfield = "PC_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.PortfolioNTEXT:
    //                stable = "EPGP_PROJECT_NTEXT_VALUES";
    //                sfield = "PN_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.PortfolioDATE:
    //                stable = "EPGP_PROJECT_DATE_VALUES";
    //                sfield = "PD_" + String.Format("{0:d3}", iField);
    //                break;
    //            default:
    //                stable = "Unknown Table";
    //                sfield = "";
    //                bFound = false;
    //                break;
    //        }

    //        sTable = stable;
    //        sField = sfield;
    //        return bFound;
    //    }

    //    public static int GetTableID(int iEntity, int iDataType)
    //    {
    //        CustomFieldTable nTable = 0;
    //        FieldType nDataType = (FieldType)iDataType;
    //        EntityID nEntity = (EntityID)iEntity;

    //        switch (nEntity)
    //        {
    //            case EntityID.Resource:
    //                switch (nDataType)
    //                {
    //                    case FieldType.TypeNumber:
    //                    case FieldType.TypeCost:
    //                        nTable = CustomFieldTable.ResourceDEC;
    //                        break;
    //                    case FieldType.TypeDate:
    //                        nTable = CustomFieldTable.ResourceDATE;
    //                        break;
    //                    case FieldType.TypeCode:
    //                    case FieldType.TypeFlag:
    //                        nTable = CustomFieldTable.ResourceINT;
    //                        break;
    //                    case FieldType.TypeText:
    //                        nTable = CustomFieldTable.ResourceTEXT;
    //                        break;
    //                    case FieldType.TypeMVCode:
    //                        nTable = CustomFieldTable.ResourceMV;
    //                        break;
    //                }
    //                break;
    //            case EntityID.Portfolio:
    //                switch (nDataType)
    //                {
    //                    case FieldType.TypeNumber:
    //                    case FieldType.TypeCost:
    //                        nTable = CustomFieldTable.PortfolioDEC;
    //                        break;
    //                    case FieldType.TypeDate:
    //                        nTable = CustomFieldTable.PortfolioDATE;
    //                        break;
    //                    case FieldType.TypeCode:
    //                    case FieldType.TypeFlag:
    //                        nTable = CustomFieldTable.PortfolioINT;
    //                        break;
    //                    case FieldType.TypeText:
    //                        nTable = CustomFieldTable.PortfolioTEXT;
    //                        break;
    //                    case FieldType.TypeNText:
    //                        nTable = CustomFieldTable.PortfolioNTEXT;
    //                        break;
    //                }
    //                break;
    //            case EntityID.Program:
    //                nTable = CustomFieldTable.Program;
    //                break;
    //            case EntityID.Project:
    //                switch (nDataType)
    //                {
    //                    case FieldType.TypeNumber:
    //                    case FieldType.TypeCost:
    //                        nTable = CustomFieldTable.ProjectDEC;
    //                        break;
    //                    case FieldType.TypeDate:
    //                        nTable = CustomFieldTable.ProjectDATE;
    //                        break;
    //                    case FieldType.TypeCode:
    //                    case FieldType.TypeFlag:
    //                        nTable = CustomFieldTable.ProjectINT;
    //                        break;
    //                    case FieldType.TypeText:
    //                        nTable = CustomFieldTable.ProjectTEXT;
    //                        break;
    //                    case FieldType.TypeNText:
    //                        nTable = CustomFieldTable.ProjectNTEXT;
    //                        break;
    //                }
    //                break;
    //            case EntityID.Task:
    //                switch (nDataType)
    //                {
    //                    case FieldType.TypeNumber:
    //                        nTable = CustomFieldTable.TaskWIDEC;
    //                        break;
    //                    case FieldType.TypeFlag:
    //                        nTable = CustomFieldTable.TaskWIINT;
    //                        break;
    //                    case FieldType.TypeText:
    //                        nTable = CustomFieldTable.TaskWITEXT;
    //                        break;
    //                }
    //                break;
    //            default:
    //                nTable = CustomFieldTable.Unknown;
    //                break;
    //        }
    //        return (int)nTable;
    //    }

    //}
}
