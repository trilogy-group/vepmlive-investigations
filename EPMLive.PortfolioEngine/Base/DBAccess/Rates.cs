using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PortfolioEngineCore
{
    public class dbaRates
    {
        public static StatusEnum SelectAdminRates(DBAccess dba, out DataTable dt)
        {
            string cmdText = "EPG_SP_ReadAdminRates";
            return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
        }

        public static StatusEnum SelectResources(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT WRES_ID,RES_NAME FROM EPG_RESOURCES WHERE WRES_INACTIVE = 0 ORDER BY RES_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
        }

        public static StatusEnum UpdateRatesInfo(DBAccess dba, DataTable dtValues, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                //  Replace Rate Table with new set

                // first establish RT_UID we'll use for any new entries
                int lNextUID = 0;
                cmdText = "Select MAX(RT_UID) as Max_UID From EPG_RATES";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                reader = oCommand.ExecuteReader();
                if (reader.Read())
                    lNextUID = DBAccess.ReadIntValue(reader["Max_UID"]) + 1;
                else
                    lNextUID = 1;
                reader.Close();
                int lStartNextUID = lNextUID;

                //  delete and re-add the rates table
                dba.BeginTransaction();
                {
                    cmdText = "DELETE FROM EPG_RATES";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.ExecuteNonQuery();

                    cmdText = "INSERT INTO EPG_RATES (RT_UID,RT_NAME,RT_ID,RT_LEVEL) VALUES(@RTUID,@RTNAME,@RTID,@RTLEVEL)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    SqlParameter pRTUID = oCommand.Parameters.Add("@RTUID", SqlDbType.Int);
                    SqlParameter pRTNAME = oCommand.Parameters.Add("@RTNAME", SqlDbType.VarChar, 255);
                    SqlParameter pRTID = oCommand.Parameters.Add("@RTID", SqlDbType.Int);
                    SqlParameter pRTLEVEL = oCommand.Parameters.Add("@RTLEVEL", SqlDbType.Int);

                    int nIndex = 0;
                    foreach (DataRow row in dtValues.Rows)
                    {
                        int nRTUID = DBAccess.ReadIntValue(row["RT_UID"]);
                        string sRTName = DBAccess.ReadStringValue(row["RT_NAME"]);
                        int nRTLevel = DBAccess.ReadIntValue(row["RT_LEVEL"]);
                        //string sResources = DBAccess.ReadStringValue(row["res_names"]);
                        //string sWResids = DBAccess.ReadStringValue(row["wres_ids"]);
                        //string sRates = DBAccess.ReadStringValue(row["rates"]);

                        nIndex++;
                        if (nRTUID > 0) { pRTUID.Value = nRTUID; } else { pRTUID.Value = lNextUID; lNextUID++; }
                        pRTNAME.Value = sRTName;
                        pRTID.Value = nIndex;
                        pRTLEVEL.Value = nRTLevel;
                        oCommand.ExecuteNonQuery();
                    }
                }

                // delete and re-add the rates values
                {
                    lNextUID = lStartNextUID;
                    
                    cmdText = "DELETE FROM EPG_RATE_VALUES";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.ExecuteNonQuery();

                    cmdText = "INSERT INTO EPG_RATE_VALUES (RT_UID,RT_EFFECTIVE_DATE,RT_RATE,RT_OVERTIME_RATE) VALUES(@RTUID,@RTDATE,@RTRATE,0)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    SqlParameter pRTUID = oCommand.Parameters.Add("@RTUID", SqlDbType.Int);
                    SqlParameter pRTDATE = oCommand.Parameters.Add("@RTDATE", SqlDbType.DateTime);
                    SqlParameter pRTRATE = oCommand.Parameters.Add("@RTRATE", SqlDbType.Float);
                    pRTRATE.Precision = 25;
                    pRTRATE.Scale = 6;


                    //  going through dt again including recalculating any new RT_UIDs
                    foreach (DataRow row in dtValues.Rows)
                    {
                        int nRTUID = DBAccess.ReadIntValue(row["RT_UID"]);
                        string sRTName = DBAccess.ReadStringValue(row["RT_NAME"]);
                        string sRates = DBAccess.ReadStringValue(row["rates"]);

                        if (nRTUID == 0) {nRTUID = lNextUID; lNextUID++; }
                        if (sRates.Length > 0)
                        {
                            // before saving the rates make sure the values are valid
                            // can't have two effective dates the same, also base rate must be specified now it is separate on the page
                            List<DateTime> list = new List<DateTime>();
                            foreach (string sEntry in sRates.Split(','))
                            {
                                string[] values = sEntry.Split(':');

                                DateTime effectivedate;
                                if (!DateTime.TryParse(values[0], out effectivedate))
                                {
                                    dba.RollbackTransaction();
                                    sReply = DBAccess.FormatAdminError("error", "Rates.UpdateRates", sRTName + ": Effective dates must be specified");
                                    return StatusEnum.rsRequestCannotBeCompleted;
                                }
                                //DateTime effectivedate = DateTime.Parse(values[0]);
                                list.Add(effectivedate);
                            }
                            list.Sort();
                            // after sort loop through keys to check for duplicates
                            DateTime prevDate = DateTime.MinValue;
                            bool bfirstdate = true;
                            foreach (DateTime dateKey in list)
                            {
                                //  doesn't work here because save done at end - need to stop them when OK on popup
                                //if (bfirstdate == true)
                                //{
                                //    dba.RollbackTransaction();
                                //    sReply = DBAccess.FormatAdminError("error", "Rates.UpdateRates", sRTName + ": Base Rate must be specified");
                                //    return StatusEnum.rsRequestCannotBeCompleted;
                                //}
                                if (dateKey == prevDate && prevDate != DateTime.MinValue)
                                {
                                    dba.RollbackTransaction();
                                    sReply = DBAccess.FormatAdminError("error", "Rates.UpdateRates", sRTName + ": Effective dates must be unique");
                                    return StatusEnum.rsRequestCannotBeCompleted;
                                }
                                else
                                {
                                    prevDate = dateKey;
                                }
                            }

                            // we're ok so go ahead and save
                            foreach (string sEntry in sRates.Split(','))
                            {
                                string[] values = sEntry.Split(':');
                                DateTime effectivedate = DateTime.Parse(values[0]);
                                double dValue = double.Parse(values[2]);
                                pRTUID.Value = nRTUID;
                                pRTDATE.Value = effectivedate;
                                pRTRATE.Value = dValue;
                                oCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // delete and re-add the resource rate assignments
                {
                    lNextUID = lStartNextUID;

                    cmdText = "DELETE FROM EPGP_COST_RATES";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.ExecuteNonQuery();

                    cmdText = "INSERT INTO EPGP_COST_RATES (TB_UID,RT_UID,WRES_ID) VALUES(0,@RTUID,@RTWRESID)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    SqlParameter pRTUID = oCommand.Parameters.Add("@RTUID", SqlDbType.Int);
                    SqlParameter pRTWRESID = oCommand.Parameters.Add("@RTWRESID", SqlDbType.Int);


                    //  going through dt again including recalculating any new RT_UIDs
                    foreach (DataRow row in dtValues.Rows)
                    {
                        int nRTUID = DBAccess.ReadIntValue(row["RT_UID"]);
                        string sWResids = DBAccess.ReadStringValue(row["wres_ids"]);

                        if (nRTUID == 0) { nRTUID = lNextUID; lNextUID++; }
                        if (sWResids.Length > 0)
                        {
                            foreach (string sEntry in sWResids.Split(','))
                            {
                                int nWRESID = int.Parse(sEntry);
                                if (nWRESID > 0)
                                {
                                    pRTUID.Value = nRTUID;
                                    pRTWRESID.Value = nWRESID;
                                    oCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                dba.CommitTransaction();

                // update the resources


                //// make sure there isn't already another Lookup with this name
                //{
                //    sName = sName.Trim();
                //    if (sName.Length == 0)
                //    {
                //        sReply = DBAccess.FormatAdminError("error", "Lookups.UpdateLookupInfo", "Please enter a Lookup Name");
                //        return StatusEnum.rsRequestCannotBeCompleted;
                //    }
                //    cmdText = "SELECT LOOKUP_UID From EPGP_LOOKUP_TABLES WHERE LOOKUP_NAME = @p1";
                //    DataTable dt;
                //    if (dba.SelectDataByName(cmdText, sName, (StatusEnum)99999, out dt) != StatusEnum.rsSuccess)
                //        sReply = DBAccess.FormatAdminError("exception", "Lookups.UpdateLookupInfo1", dba.StatusText);
                //    else if (dt.Rows.Count > 0)
                //    {
                //        DataRow row = dt.Rows[0];
                //        int nExistingId = DBAccess.ReadIntValue(row["LOOKUP_UID"]);
                //        if (nExistingId != nLOOKUP_UID)
                //        {
                //            sReply = DBAccess.FormatAdminError("error", "Lookups.UpdateLookupInfo", "Can't save Lookup.\nA Lookup with name '" + sName + "' already exists");
                //            return StatusEnum.rsRequestCannotBeCompleted;
                //        }
                //    }
                //}

                //if (nLOOKUP_UID == 0)
                //{
                //    // ADD - no need to figure new UID as IDENTITY
                //    Guid g = Guid.NewGuid();
                //    string sg = g.ToString();
                //    cmdText =
                //           "INSERT Into EPGP_LOOKUP_TABLES (LOOKUP_NAME,LOOKUP_DESC,LOOKUP_EXT_UID)"
                //       + " Values(@ppLOOKUP_NAME, @pLOOKUP_DESC,@pLOOKUP_EXT_UID)";
                //    oCommand = new SqlCommand(cmdText, dba.Connection);
                //    oCommand.Parameters.AddWithValue("@ppLOOKUP_NAME", sName);
                //    oCommand.Parameters.AddWithValue("@pLOOKUP_DESC", sDesc);
                //    oCommand.Parameters.AddWithValue("@pLOOKUP_EXT_UID", sg);
                //    oCommand.ExecuteNonQuery();
                //    dba.GetLastIdentityValue(out nLOOKUP_UID);

                //}
                //else
                //{
                //    //  update
                //    cmdText = "UPDATE EPGP_LOOKUP_TABLES "
                //                + " SET LOOKUP_NAME=@pLOOKUP_NAME,LOOKUP_DESC=@pLOOKUP_DESC"
                //                + " WHERE LOOKUP_UID = @pLOOKUP_UID";
                //    oCommand = new SqlCommand(cmdText, dba.Connection);
                //    oCommand.Parameters.AddWithValue("@pLOOKUP_NAME", sName);
                //    oCommand.Parameters.AddWithValue("@pLOOKUP_DESC", sDesc);
                //    oCommand.Parameters.AddWithValue("@pLOOKUP_UID", nLOOKUP_UID);
                //    oCommand.ExecuteNonQuery();
                //}

                //if (nLOOKUP_UID > 0)
                //{
                //    //  update the Lookup values - using IDENTITY so can't delete and re-add
                //    bool bInserts = false;
                //    bool bUpdates = false;
                //    bool bDeletes = false;

                //    // read new lookup values into dic
                //    Dictionary<int, PFELookupItem> dicValues = new Dictionary<int, PFELookupItem>();
                //    int nIndex = 0;
                //    int nMaxLevel = 0;
                //    foreach (DataRow row in dtValues.Rows)
                //    {
                //        PFELookupItem oItemLookup = new PFELookupItem();
                //        nIndex++;
                //        oItemLookup.UID = DBAccess.ReadIntValue(row["LV_UID"]);
                //        oItemLookup.ID = nIndex;
                //        oItemLookup.level = DBAccess.ReadIntValue(row["LV_LEVEL"]);
                //        oItemLookup.inactive = DBAccess.ReadIntValue(row["LV_INACTIVE"]);
                //        oItemLookup.name = DBAccess.ReadStringValue(row["LV_VALUE"]);

                //        int nkey;
                //        if (oItemLookup.UID == 0) { nkey = oItemLookup.ID + 200000000; bInserts = true; } else nkey = oItemLookup.UID;
                //        dicValues.Add(nkey, oItemLookup);

                //        if (nMaxLevel < oItemLookup.level) nMaxLevel = oItemLookup.level;
                //    }

                //    // figure fullname
                //    string[] sLevelName = new string[nMaxLevel + 1];
                //    int l = 0;
                //    string sParentName = "";

                //    foreach (KeyValuePair<int, PFELookupItem> oItemLookup in dicValues)
                //    {
                //        int lLevel = oItemLookup.Value.level;
                //        sLevelName[lLevel] = oItemLookup.Value.name;
                //        sParentName = "";
                //        for (l = 1; l <= lLevel - 1; l++)
                //        {
                //            if (l == 1) sParentName = sLevelName[l] + ".";
                //            else sParentName = sParentName + "." + sLevelName[l];
                //        }
                //        oItemLookup.Value.fullname = sParentName + oItemLookup.Value.name;
                //    }

                //    // update existing then insert new values

                //    SqlTransaction transaction = dba.Connection.BeginTransaction();
                //    cmdText = "SELECT LOOKUP_UID,LV_UID,LV_EXT_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_INACTIVE From EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @LookupUID";
                //    oCommand = new SqlCommand(cmdText, dba.Connection);
                //    oCommand.Transaction = transaction;
                //    oCommand.Parameters.AddWithValue("@LookupUID", nLOOKUP_UID);
                //    DataTable dataTable = new DataTable();
                //    dataTable.Load(oCommand.ExecuteReader());

                //    if (dataTable != null)
                //    {
                //        foreach (DataRow row in dataTable.Rows)
                //        {
                //            string sExistingName = DBAccess.ReadStringValue(row["LV_VALUE"]);
                //            int nExistingLevel = DBAccess.ReadIntValue(row["LV_LEVEL"]);
                //            int nExistingInActive = DBAccess.ReadIntValue(row["LV_INACTIVE"]);
                //            int nUID = DBAccess.ReadIntValue(row["LV_UID"]);
                //            int nExistingID = DBAccess.ReadIntValue(row["LV_ID"]);
                //            //string sExistingExtID = DBAccess.ReadStringValue(row["LV_EXT_UID"]);
                //            string sExistingFullName = DBAccess.ReadStringValue(row["LV_FULLVALUE"]);

                //            if (dicValues.ContainsKey(nUID))
                //            {
                //                PFELookupItem value = dicValues[nUID];
                //                value.bflag = true;
                //                if (nExistingID != value.ID || nExistingLevel != value.level || sExistingName != value.name || sExistingFullName != value.fullname
                //                             || nExistingInActive != value.inactive)
                //                {
                //                    row["LV_VALUE"] = value.name;
                //                    row["LV_LEVEL"] = value.level;
                //                    row["LV_EXT_UID"] = value.ExtId;
                //                    row["LV_ID"] = value.ID;
                //                    row["LV_INACTIVE"] = value.inactive;
                //                    row["LV_FULLVALUE"] = value.fullname;
                //                    bUpdates = true;
                //                }
                //            }
                //            else
                //            {
                //                //  item deleted
                //                bDeletes = true;
                //                row.Delete();
                //            }
                //        }
                //        //  apply updates to dbs
                //        if (bUpdates)
                //        {
                //            cmdText = @"Update EPGP_LOOKUP_VALUES SET LV_VALUE=@LV_value, LV_FULLVALUE=@LV_fullvalue, LV_LEVEL=@LV_level, LV_ID=@LV_id, LV_EXT_UID=@LV_extid" +
                //                " Where LV_UID=@LV_uid";
                //            oCommand = new SqlCommand(cmdText, dba.Connection);
                //            oCommand.Transaction = transaction;
                //            oCommand.CommandType = CommandType.Text;

                //            SqlParameter pUID = oCommand.Parameters.Add("@LV_uid", SqlDbType.Int);
                //            SqlParameter pLEVEL = oCommand.Parameters.Add("@LV_level", SqlDbType.Int);
                //            SqlParameter pID = oCommand.Parameters.Add("@LV_id", SqlDbType.Int);
                //            SqlParameter pVALUE = oCommand.Parameters.Add("@LV_value", SqlDbType.VarChar);
                //            SqlParameter pFULLVALUE = oCommand.Parameters.Add("@LV_fullvalue", SqlDbType.VarChar);
                //            SqlParameter pEXTID = oCommand.Parameters.Add("@LV_extid", SqlDbType.VarChar);

                //            foreach (DataRow row in dataTable.Rows)
                //            {
                //                if (row.RowState == DataRowState.Modified)
                //                {
                //                    pUID.Value = row["LV_UID"];
                //                    pLEVEL.Value = row["LV_LEVEL"];
                //                    pID.Value = row["LV_ID"];
                //                    pVALUE.Value = row["LV_VALUE"];
                //                    pFULLVALUE.Value = row["LV_FULLVALUE"];
                //                    pEXTID.Value = row["LV_EXT_UID"];
                //                    oCommand.ExecuteNonQuery();
                //                }
                //            }
                //        }
                //        //  apply deletes to dbs
                //        if (bDeletes)
                //        {
                //            cmdText = @"Delete From EPGP_LOOKUP_VALUES Where LV_UID=@LV_uid";
                //            oCommand = new SqlCommand(cmdText, dba.Connection);
                //            oCommand.Transaction = transaction;
                //            oCommand.CommandType = CommandType.Text;

                //            SqlParameter pUID = oCommand.Parameters.Add("@LV_uid", SqlDbType.Int);
                //            foreach (DataRow row in dataTable.Rows)
                //            {
                //                if (row.RowState == DataRowState.Deleted)
                //                {
                //                    pUID.Value = row["LV_UID"];
                //                    oCommand.ExecuteNonQuery();
                //                }
                //            }
                //        }

                //    }
                //    dataTable.Dispose();

                //    //  check for inserts
                //    if (bInserts)
                //    {
                //        cmdText = @"SET NOCOUNT ON;"
                //                   + "Insert Into EPGP_LOOKUP_VALUES (LOOKUP_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_EXT_UID)"
                //                   + " Values (@LV_lookupuid,@LV_value,@LV_fullvalue,@LV_id,@LV_level,@LV_extid);"
                //                   + "Select @@IDENTITY as NewID";
                //        oCommand = new SqlCommand(cmdText, dba.Connection);
                //        oCommand.Transaction = transaction;
                //        oCommand.CommandType = CommandType.Text;

                //        SqlParameter pLookupUID = oCommand.Parameters.Add("@LV_lookupuid", SqlDbType.Int);
                //        SqlParameter pLEVEL = oCommand.Parameters.Add("@LV_level", SqlDbType.Int);
                //        SqlParameter pID = oCommand.Parameters.Add("@LV_id", SqlDbType.Int);
                //        SqlParameter pVALUE = oCommand.Parameters.Add("@LV_value", SqlDbType.VarChar);
                //        SqlParameter pFULLVALUE = oCommand.Parameters.Add("@LV_fullvalue", SqlDbType.VarChar);
                //        SqlParameter pEXTID = oCommand.Parameters.Add("@LV_extid", SqlDbType.VarChar);

                //        foreach (KeyValuePair<int, PFELookupItem> lookupitem in dicValues)
                //        {
                //            if (lookupitem.Value.bflag == false)
                //            {
                //                pLookupUID.Value = nLOOKUP_UID;
                //                pLEVEL.Value = lookupitem.Value.level;
                //                pID.Value = lookupitem.Value.ID;
                //                pVALUE.Value = lookupitem.Value.name;
                //                pFULLVALUE.Value = lookupitem.Value.fullname;
                //                Guid g = Guid.NewGuid();
                //                pEXTID.Value = g.ToString();

                //                reader = oCommand.ExecuteReader();
                //                if (reader.Read())
                //                {
                //                    lookupitem.Value.UID = Convert.ToInt32(reader["NewID"]);
                //                }
                //                reader.Close();
                //            }
                //        }
                //    }
                //    transaction.Commit();
                //}
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "Rates.UpdateRatesInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

    }
}

