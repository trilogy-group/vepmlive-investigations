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
                            cmdText = @"Update EPGP_LOOKUP_VALUES SET LV_VALUE=@LV_value, LV_FULLVALUE=@LV_fullvalue, LV_LEVEL=@LV_level, LV_ID=@LV_id, LV_EXT_UID=@LV_extid" +
                                " Where LV_UID=@LV_uid";
                            oCommand = new SqlCommand(cmdText, dba.Connection);
                            oCommand.Transaction = transaction;
                            oCommand.CommandType = CommandType.Text;

                            SqlParameter pUID = oCommand.Parameters.Add("@LV_uid", SqlDbType.Int);
                            SqlParameter pLEVEL = oCommand.Parameters.Add("@LV_level", SqlDbType.Int);
                            SqlParameter pID = oCommand.Parameters.Add("@LV_id", SqlDbType.Int);
                            SqlParameter pVALUE = oCommand.Parameters.Add("@LV_value", SqlDbType.VarChar);
                            SqlParameter pFULLVALUE = oCommand.Parameters.Add("@LV_fullvalue", SqlDbType.VarChar);
                            SqlParameter pEXTID = oCommand.Parameters.Add("@LV_extid", SqlDbType.VarChar);

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
                                    pUID.Value = row["LV_UID"];
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
                                   + "Insert Into EPGP_LOOKUP_VALUES (LOOKUP_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_EXT_UID)"
                                   + " Values (@LV_lookupuid,@LV_value,@LV_fullvalue,@LV_id,@LV_level,@LV_extid);"
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

    }
}

