using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class dbaLookups
    {
        public static StatusEnum SelectLookups(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT LOOKUP_UID, LOOKUP_NAME, LOOKUP_DESC FROM EPGP_LOOKUP_TABLES"
                            + " WHERE LOOKUP_UID <> (SELECT ADM_RPE_DEPT_CODE FROM EPG_ADMIN)"
                            + " AND LOOKUP_UID <> (SELECT ADM_ROLE_CODE FROM EPG_ADMIN)"
                            + " ORDER BY LOOKUP_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99941, out dt);
        }
        public static StatusEnum SelectLookup(DBAccess dba, int nLookupId, out DataTable dt)
        {
            string cmdText = "SELECT LOOKUP_UID, LOOKUP_NAME, LOOKUP_DESC FROM EPGP_LOOKUP_TABLES WHERE LOOKUP_UID = @p1";
            return dba.SelectDataById(cmdText, nLookupId, (StatusEnum)99940, out dt);
        }
        public static StatusEnum SelectLookupValues(DBAccess dba, int nLookupId, out DataTable dt)
        {
            string cmdText = "SELECT LV_UID, LV_VALUE, LV_LEVEL, LV_INACTIVE FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID";
            return dba.SelectDataById(cmdText, nLookupId, (StatusEnum)99939, out dt);
        }
        public static StatusEnum UpdateLookupInfo(DBAccess dba, ref int nLOOKUP_UID, string sName, string sDesc, DataTable dtValues, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                // make sure there isn't already another Lookup with this name
                {
                    sName = sName.Trim();
                    if (sName.Length == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "Lookups.UpdateLookupInfo", "Please enter a Lookup Name");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                    cmdText = "SELECT LOOKUP_UID From EPGP_LOOKUP_TABLES WHERE LOOKUP_NAME = @p1";
                    DataTable dt;
                    if (dba.SelectDataByName(cmdText, sName, (StatusEnum)99999, out dt) != StatusEnum.rsSuccess)
                        sReply = DBAccess.FormatAdminError("exception", "Lookups.UpdateLookupInfo1", dba.StatusText);
                    else if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nExistingId = DBAccess.ReadIntValue(row["LOOKUP_UID"]);
                        if (nExistingId != nLOOKUP_UID)
                        {
                            sReply = DBAccess.FormatAdminError("error", "Lookups.UpdateLookupInfo", "Can't save Lookup.\nA Lookup with name '" + sName + "' already exists");
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                    }
                }

                if (nLOOKUP_UID == 0)
                {
                    // ADD - no need to figure new UID as IDENTITY
                    Guid g = Guid.NewGuid();
                    string sg = g.ToString();
                    cmdText =
                           "INSERT Into EPGP_LOOKUP_TABLES (LOOKUP_NAME,LOOKUP_DESC,LOOKUP_EXT_UID)"
                       + " Values(@ppLOOKUP_NAME, @pLOOKUP_DESC,@pLOOKUP_EXT_UID)";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@ppLOOKUP_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pLOOKUP_DESC", sDesc);
                    oCommand.Parameters.AddWithValue("@pLOOKUP_EXT_UID", sg);
                    oCommand.ExecuteNonQuery();
                    dba.GetLastIdentityValue(out nLOOKUP_UID);

                }
                else
                {
                    //  update
                    cmdText = "UPDATE EPGP_LOOKUP_TABLES "
                                + " SET LOOKUP_NAME=@pLOOKUP_NAME,LOOKUP_DESC=@pLOOKUP_DESC"
                                + " WHERE LOOKUP_UID = @pLOOKUP_UID";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pLOOKUP_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pLOOKUP_DESC", sDesc);
                    oCommand.Parameters.AddWithValue("@pLOOKUP_UID", nLOOKUP_UID);
                    oCommand.ExecuteNonQuery();
                }

                if (nLOOKUP_UID > 0)
                {
                    //  update the Lookup values - using IDENTITY so can't delete and re-add
                    bool bInserts = false;
                    bool bUpdates = false;
                    bool bDeletes = false;

                    // read new lookup values into dic
                    Dictionary<int, PFELookupItem> dicValues = new Dictionary<int, PFELookupItem>();
                    int nIndex = 0;
                    int nMaxLevel = 0;
                    foreach (DataRow row in dtValues.Rows)
                    {
                        PFELookupItem oItemLookup = new PFELookupItem();
                        nIndex++;
                        oItemLookup.UID = DBAccess.ReadIntValue(row["LV_UID"]);
                        oItemLookup.ID = nIndex;
                        oItemLookup.level = DBAccess.ReadIntValue(row["LV_LEVEL"]);
                        oItemLookup.inactive = DBAccess.ReadIntValue(row["LV_INACTIVE"]);
                        oItemLookup.name = DBAccess.ReadStringValue(row["LV_VALUE"]);

                        int nkey;
                        if (oItemLookup.UID == 0) { nkey = oItemLookup.ID + 200000000; bInserts = true; } else nkey = oItemLookup.UID;
                        dicValues.Add(nkey, oItemLookup);

                        if (nMaxLevel < oItemLookup.level) nMaxLevel = oItemLookup.level;
                    }

                    // figure fullname
                    string[] sLevelName = new string[nMaxLevel+1];
                    int l = 0;
                    string sParentName = "";
                    // used to check for duplicate siblings
                    Dictionary<string, string> dicFullnames = new Dictionary<string, string>();

                    foreach (KeyValuePair<int, PFELookupItem> oItemLookup in dicValues)
                    {
                        int lLevel = oItemLookup.Value.level;
                        sLevelName[lLevel] = oItemLookup.Value.name;
                        sParentName = "";
                        for (l = 1; l <= lLevel - 1; l++)
                        {
                            if (l == 1) sParentName = sLevelName[l] + ".";
                            else sParentName = sParentName + "." + sLevelName[l];
                        }
                        oItemLookup.Value.fullname = sParentName + oItemLookup.Value.name;

                        // need to check for duplicate siblings so stuff full name into dic, any error will be dup
                        if (dicFullnames.ContainsKey(oItemLookup.Value.fullname))
                        {
                            sReply = DBAccess.FormatAdminError("error", "Lookups.UpdateLookupInfo", "Can't save Lookup.\nDuplicate value not allowed: " + oItemLookup.Value.fullname);
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                        else
                        {
                            dicFullnames.Add(oItemLookup.Value.fullname, oItemLookup.Value.fullname);
                        }
                    }

                    // update existing then insert new values

                    SqlTransaction transaction = dba.Connection.BeginTransaction();
                    cmdText = "SELECT LOOKUP_UID,LV_UID,LV_EXT_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_INACTIVE From EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @LookupUID";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Transaction = transaction;
                    oCommand.Parameters.AddWithValue("@LookupUID", nLOOKUP_UID);
                    DataTable dataTable = new DataTable();
                    dataTable.Load(oCommand.ExecuteReader());

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string sExistingName = DBAccess.ReadStringValue(row["LV_VALUE"]);
                            int nExistingLevel = DBAccess.ReadIntValue(row["LV_LEVEL"]);
                            int nExistingInActive = DBAccess.ReadIntValue(row["LV_INACTIVE"]);
                            int nUID = DBAccess.ReadIntValue(row["LV_UID"]);
                            int nExistingID = DBAccess.ReadIntValue(row["LV_ID"]);
                            //string sExistingExtID = DBAccess.ReadStringValue(row["LV_EXT_UID"]);
                            string sExistingFullName = DBAccess.ReadStringValue(row["LV_FULLVALUE"]);

                            if (dicValues.ContainsKey(nUID))
                            {
                                PFELookupItem value = dicValues[nUID];
                                value.bflag = true;
                                if (nExistingID != value.ID || nExistingLevel != value.level || sExistingName != value.name || sExistingFullName != value.fullname
                                             || nExistingInActive != value.inactive)
                                {
                                    row["LV_VALUE"] = value.name;
                                    row["LV_LEVEL"] = value.level;
                                    row["LV_EXT_UID"] = value.ExtId;
                                    row["LV_ID"] = value.ID;
                                    row["LV_INACTIVE"] = value.inactive;
                                    row["LV_FULLVALUE"] = value.fullname;
                                    bUpdates = true;
                                }
                            }
                            else
                            {
                                //  item deleted
                                bDeletes = true;
                                row.Delete();
                            }
                        }
                        //  apply updates to dbs
                        if (bUpdates)
                        {
                            cmdText = @"Update EPGP_LOOKUP_VALUES SET LV_VALUE=@LV_value, LV_FULLVALUE=@LV_fullvalue, LV_LEVEL=@LV_level, LV_ID=@LV_id, LV_EXT_UID=@LV_extid," +
                                " LV_INACTIVE=@LV_inactive Where LV_UID=@LV_uid";
                            oCommand = new SqlCommand(cmdText, dba.Connection);
                            oCommand.Transaction = transaction;
                            oCommand.CommandType = CommandType.Text;

                            SqlParameter pUID = oCommand.Parameters.Add("@LV_uid", SqlDbType.Int);
                            SqlParameter pLEVEL = oCommand.Parameters.Add("@LV_level", SqlDbType.Int);
                            SqlParameter pID = oCommand.Parameters.Add("@LV_id", SqlDbType.Int);
                            SqlParameter pVALUE = oCommand.Parameters.Add("@LV_value", SqlDbType.VarChar);
                            SqlParameter pFULLVALUE = oCommand.Parameters.Add("@LV_fullvalue", SqlDbType.VarChar);
                            SqlParameter pEXTID = oCommand.Parameters.Add("@LV_extid", SqlDbType.VarChar);
                            SqlParameter pINACTIVE = oCommand.Parameters.Add("@LV_inactive", SqlDbType.Int);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row.RowState == DataRowState.Modified)
                                {
                                    pUID.Value = row["LV_UID"];
                                    pLEVEL.Value = row["LV_LEVEL"];
                                    pID.Value = row["LV_ID"];
                                    pVALUE.Value = row["LV_VALUE"];
                                    pFULLVALUE.Value = row["LV_FULLVALUE"];
                                    pEXTID.Value = row["LV_EXT_UID"];
                                    pINACTIVE.Value = row["LV_INACTIVE"];
                                    oCommand.ExecuteNonQuery();
                                }
                            }
                        }
                        //  apply deletes to dbs
                        if (bDeletes)
                        {
                            cmdText = @"Delete From EPGP_LOOKUP_VALUES Where LV_UID=@LV_uid";
                            oCommand = new SqlCommand(cmdText, dba.Connection);
                            oCommand.Transaction = transaction;
                            oCommand.CommandType = CommandType.Text;

                            SqlParameter pUID = oCommand.Parameters.Add("@LV_uid", SqlDbType.Int);
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row.RowState == DataRowState.Deleted)
                                {
                                    pUID.Value = row["LV_UID", DataRowVersion.Original];
                                    oCommand.ExecuteNonQuery();
                                }
                            }
                        }

                    }
                    dataTable.Dispose();

                    //  check for inserts
                    if (bInserts)
                    {
                        cmdText = @"SET NOCOUNT ON;"
                                   + "Insert Into EPGP_LOOKUP_VALUES (LOOKUP_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_EXT_UID,LV_INACTIVE)"
                                   + " Values (@LV_lookupuid,@LV_value,@LV_fullvalue,@LV_id,@LV_level,@LV_extid,@LV_inactive);"
                                   + "Select @@IDENTITY as NewID";
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        oCommand.Transaction = transaction;
                        oCommand.CommandType = CommandType.Text;

                        SqlParameter pLookupUID = oCommand.Parameters.Add("@LV_lookupuid", SqlDbType.Int);
                        SqlParameter pLEVEL = oCommand.Parameters.Add("@LV_level", SqlDbType.Int);
                        SqlParameter pID = oCommand.Parameters.Add("@LV_id", SqlDbType.Int);
                        SqlParameter pVALUE = oCommand.Parameters.Add("@LV_value", SqlDbType.VarChar);
                        SqlParameter pFULLVALUE = oCommand.Parameters.Add("@LV_fullvalue", SqlDbType.VarChar);
                        SqlParameter pEXTID = oCommand.Parameters.Add("@LV_extid", SqlDbType.VarChar);
                        SqlParameter pINACTIVE = oCommand.Parameters.Add("@LV_inactive", SqlDbType.Int);

                        foreach (KeyValuePair<int, PFELookupItem> lookupitem in dicValues)
                        {
                            if (lookupitem.Value.bflag == false)
                            {
                                pLookupUID.Value = nLOOKUP_UID;
                                pLEVEL.Value = lookupitem.Value.level;
                                pID.Value = lookupitem.Value.ID;
                                pVALUE.Value = lookupitem.Value.name;
                                pFULLVALUE.Value = lookupitem.Value.fullname;
                                Guid g = Guid.NewGuid();
                                pEXTID.Value = g.ToString();
                                pINACTIVE.Value = lookupitem.Value.inactive;

                                reader = oCommand.ExecuteReader();
                                if (reader.Read())
                                {
                                    lookupitem.Value.UID = Convert.ToInt32(reader["NewID"]);
                                }
                                reader.Close();
                            }
                        }
                    }
                    transaction.Commit();
                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "Lookups.UpdateLookupInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum CanDeleteLookupItems(DBAccess dba, string sLVUIDs, out string sReply)
        {
            // there is a version of this in AdminInfos.cs but that works the old way - passed in ONE item and it determines if there are any children, etc
            SqlCommand oCommand;
            SqlDataReader reader;
            string sCommand;
            sReply = "";
            try
            {
                // check if each Lookup Item can be deleted
                string smessage = "";
                if (sLVUIDs.Length > 0)
                {
                    string[] sArrayLVUID = sLVUIDs.Split(',');
                    int numberofmessagelines = 0;
                    for (int i = 0; i <= sArrayLVUID.GetUpperBound(0); i++)
                    {
                        string sLVUID = sArrayLVUID[i];
                        int nLVUID = int.Parse(sLVUID);
                        bool bFirstMessage = true;
                        //bool bnewBCUID = true;
                        oCommand = new SqlCommand("EPG_SP_ReadUsedListValue", dba.Connection);
                        oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        oCommand.Parameters.AddWithValue("@LV_UID", nLVUID);
                        reader = oCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            if (numberofmessagelines < 12)
                            {
                                if (bFirstMessage == true) { bFirstMessage = false; smessage += "Cannot Delete Lookup Item, it is used as follows: " + "\n"; }
                                //if (bnewBCUID == true) { bnewBCUID = false; smessage += "For Lookup Item: " + sLVUID + "\n"; }
                                smessage += DBAccess.ReadStringValue(reader["UsedMessage"]) + ": ";
                                smessage += DBAccess.ReadStringValue(reader["UsedData"]) + "\n";
                            }
                            numberofmessagelines++;
                        }
                        reader.Close();

                        //  other chcecks not in SP
                        //  read list of Code fields used anywhere
                        sCommand = "Select FA_NAME as Field_Name,FA_FIELD_ID as Field_ID,0 as Table_ID,0 as Field_IN_TABLE" +
                                     " From EPGP_FIELD_ATTRIBS" +
                                     " Where (FA_FIELD_ID >= 9105 And FA_FIELD_ID <= 9109) Or (FA_FIELD_ID >= 9305 And FA_FIELD_ID <= 9309)" +
                                     " Or (FA_FIELD_ID >= 9505 And FA_FIELD_ID <= 9509)Or (FA_FIELD_ID >= 11801 And FA_FIELD_ID <= 11805)" +
                                     " Union" +
                                     " Select FA_NAME as Field_Name,FA_FIELD_ID as Field_ID,FA_TABLE_ID as Table_ID,FA_FIELD_IN_TABLE as Field_IN_TABLE" +
                                     " From EPGC_FIELD_ATTRIBS" +
                                     " Where FA_FORMAT = 4" +
                                     " Order by Field_ID";
                        oCommand = new SqlCommand(sCommand, dba.Connection);
                        reader = oCommand.ExecuteReader();

                        List<CField> clnFields = new List<CField>();
                        CField oField;
                        while (reader.Read())
                        {
                            oField = new CField();
                            oField.Id = DBAccess.ReadIntValue(reader["Field_ID"]);
                            oField.Name = DBAccess.ReadStringValue(reader["Field_Name"]);
                            oField.CFTable = DBAccess.ReadIntValue(reader["Table_ID"]);
                            oField.CFField = DBAccess.ReadIntValue(reader["Field_IN_TABLE"]);
                            clnFields.Add(oField);
                        }
                        reader.Close();

                        string sField;
                        foreach (CField field in clnFields)
                        {
                            if (field.Id >= 9105 && field.Id <= 9109)
                            {
                                // TS Code fields
                                sField = string.Format("CAT_CODE_{0:0}", field.Id - 9104);
                                sCommand = "Select DISTINCT Top 3 RES_NAME,PRD_NAME" +
                                    " From EPG_TS_CATEGORY_VALUES cv" +
                                    " Inner Join EPG_TS_CHARGES ch ON ch.CHG_UID = cv.CAT_CHG_UID" +
                                    " Inner Join EPG_TS_TIMESHEETS ts ON ts.TS_UID = ch.TS_UID" +
                                    " Inner Join EPG_PERIODS p On p.PRD_ID = ts.PRD_ID and p.CB_ID=0" +
                                    " Inner Join EPG_RESOURCES r On r.WRES_ID = ts.WRES_ID" +
                                    " Where cv." + sField + " = " + nLVUID.ToString();
                                oCommand = new SqlCommand(sCommand, dba.Connection);
                                reader = oCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (bFirstMessage == true) { bFirstMessage = false; smessage += "Cannot Delete Lookup Item, it is used as follows: " + "\n"; }
                                    smessage += "Timesheet  " + DBAccess.ReadStringValue(reader["PRD_NAME"]) + "  " +
                                                               field.Name + ":  " + DBAccess.ReadStringValue(reader["RES_NAME"]) + "\n";
                                }
                                reader.Close();
                            }
                            else if (field.Id >= 9305 && field.Id <= 9309)
                            {
                                // RP Code fields
                                sField = string.Format("CAT_CODE_{0:0}", field.Id - 9304);
                                sCommand = "Select DISTINCT TOP 3 PROJECT_NAME" +
                                    " From EPGP_RP_CATEGORY_VALUES cv" +
                                    " Inner Join EPG_RESOURCEPLANS c On c.CMT_UID=cv.CAT_CMT_UID" +
                                    " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=c.PROJECT_ID" +
                                    " Where cv." + sField + " = " + nLVUID.ToString();
                                oCommand = new SqlCommand(sCommand, dba.Connection);
                                reader = oCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (bFirstMessage == true) { bFirstMessage = false; smessage += "Cannot Delete Lookup Item, it is used as follows: " + "\n"; }
                                    smessage += "Resource Plan  " + field.Name + ":  " + DBAccess.ReadStringValue(reader["PROJECT_NAME"]) + "\n";
                                }
                                reader.Close();
                            }
                            else if (field.Id >= 11801 && field.Id <= 11805)
                            {
                                // CT Code fields
                                sField = string.Format("OC_{0:00}", field.Id - 11800);
                                sCommand = "Select DISTINCT Top 3 PROJECT_NAME,CT_NAME,BC_NAME,CB_NAME" +
                                    " From EPGP_COST_DETAILS cv" +
                                    " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=cv.PROJECT_ID" +
                                    " Inner Join EPGP_COST_TYPES ct On ct.CT_ID=cv.CT_ID" +
                                    " Inner Join EPGP_COST_CATEGORIES cc On cc.BC_UID=cv.BC_UID" +
                                    " Inner Join EPGP_COST_BREAKDOWNS cb On cb.CB_ID=cv.CB_ID" +
                                    " Where cv." + sField + " = " + nLVUID.ToString();
                                oCommand = new SqlCommand(sCommand, dba.Connection);
                                reader = oCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (bFirstMessage == true) { bFirstMessage = false; smessage += "Cannot Delete Lookup Item, it is used as follows: " + "\n"; }
                                    smessage += "PI Cost Value  " +
                                        DBAccess.ReadStringValue(reader["CT_NAME"]) + "  " +
                                        DBAccess.ReadStringValue(reader["CB_NAME"]) + "  " +
                                        DBAccess.ReadStringValue(reader["BC_NAME"]) + "  " +
                                        field.Name + ":  " +
                                        DBAccess.ReadStringValue(reader["PROJECT_NAME"]) + "\n";
                                }
                                reader.Close();
                            }
                            else if (field.Id > 20000)
                            {
                                // PI or Resource fields Code fields
                                string tableName;
                                string fieldName;
                                Common.CalculateTableFieldName(field.CFField, field.CFTable, out tableName, out fieldName);

                                if ((Common.CustomFieldTable)field.CFTable == Common.CustomFieldTable.ResourceINT)
                                {
                                    // resource code fields
                                    sCommand = "Select Top 3 RES_NAME" +
                                        " From EPGC_RESOURCE_INT_VALUES iv" +
                                        " Inner Join EPG_RESOURCES r On r.WRES_ID=iv.WRES_ID" +
                                        " Where iv." + fieldName + " = " + nLVUID.ToString();
                                    oCommand = new SqlCommand(sCommand, dba.Connection);
                                    reader = oCommand.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        if (bFirstMessage == true) { bFirstMessage = false; smessage += "Cannot Delete Lookup Item, it is used as follows: " + "\n"; }
                                        smessage += "Resource  " + field.Name + ":  " + DBAccess.ReadStringValue(reader["RES_NAME"]) + "\n";
                                    }
                                    reader.Close();
                                }
                                else if ((Common.CustomFieldTable)field.CFTable == Common.CustomFieldTable.PortfolioINT)
                                {
                                    //  PI code fields
                                    sCommand = "Select Top 3 PROJECT_NAME" +
                                        " From EPGP_PROJECT_INT_VALUES iv" +
                                        " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=iv.PROJECT_ID" +
                                        " Where iv." + fieldName + " = " + nLVUID.ToString();
                                    oCommand = new SqlCommand(sCommand, dba.Connection);
                                    reader = oCommand.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        if (bFirstMessage == true) { bFirstMessage = false; smessage += "Cannot Delete Lookup Item, it is used as follows: " + "\n"; }
                                        smessage += "PI  " + field.Name + ":  " + DBAccess.ReadStringValue(reader["PROJECT_NAME"]) + "\n";
                                    }
                                    reader.Close();

                                    //  PI codes also used for Program Data
                                    sCommand = "Select Top 3 LV_VALUE as Program_Name" +
                                        " From EPGP_PROG_INT_VALUES iv" +
                                        " Inner Join EPGP_LOOKUP_VALUES p On p.LV_UID=iv.PROG_UID" +
                                        " Where iv." + fieldName + " = " + nLVUID.ToString();
                                    oCommand = new SqlCommand(sCommand, dba.Connection);
                                    reader = oCommand.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        if (bFirstMessage == true) { bFirstMessage = false; smessage += "Cannot Delete Lookup Item, it is used as follows: " + "\n"; }
                                        smessage += "Program Data  " + field.Name + ":  " + DBAccess.ReadStringValue(reader["Program_Name"]) + "\n";
                                    }
                                    reader.Close();
                                }
                            }
                        }
                    }
                }
                if (smessage != "")
                    sReply = DBAccess.FormatAdminError("error", "Lookups.CanDeleteLookupItems", smessage);

                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostCategories.CanDeleteCostCategory", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        private class PFELookupItem
        {
            public int UID;
            public string ExtId;
            public string name;
            public string fullname;
            public int ID;
            public int level;
            public int inactive;
            public bool bflag;
        }
        private class CField
        {
            public int CFField;
            public int CFTable;
            public int Id;
            public string Name;
        }
    }
}

