using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PortfolioEngineCore
{

    public class dbaCostCategories
    {
        public static StatusEnum SelectCostCategories(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_CATEGORIES ORDER BY CA_ID";
            return dba.SelectData(cmdText, (StatusEnum)99957, out dt);
        }
        public static StatusEnum ReadCostCategoryRates(DBAccess dba, int nBCUID, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_CATEGORIES cc"
                        + " LEFT JOIN EPG_COST_CATEGORY_RATE_VALUES rv on cc.CA_UID = rv.BC_UID"
                        + " WHERE rv.BC_UID = @p1"
                        + " ORDER BY rv.BC_EFFECTIVE_DATE";
            return dba.SelectDataById(cmdText, nBCUID, (StatusEnum)99986, out dt);
        }
        public static StatusEnum CanDeleteCostCategory(DBAccess dba, string sBCUIDs, out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                // check if each CC can be deleted
                string s = "";
                if (sBCUIDs.Length > 0) 
                {
                    string[] sArrayBCUID = sBCUIDs.Split(',');
                    int numberofmessagelines = 0;
                    for (int i = 0; i <= sArrayBCUID.GetUpperBound(0); i++)
                    {
                        string sBCUID = sArrayBCUID[i];
                        int nBCUID = int.Parse(sBCUID);
                        bool bnewBCUID = true;
                        oCommand = new SqlCommand("EPG_SP_ReadCategoryUsedCTs", dba.Connection);
                        oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        oCommand.Parameters.AddWithValue("@BCUID", nBCUID);
                        reader = oCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            if (numberofmessagelines < 12)
                            {
                                if (bnewBCUID == true) { bnewBCUID = false; s += "For Cost Category: " + sBCUID + "\n"; }
                                s += DBAccess.ReadStringValue(reader["Type"]) + ": ";
                                s += DBAccess.ReadStringValue(reader["Name"]) + "\n";
                            }
                            numberofmessagelines++;
                        }
                        reader.Close();
                    }
                }
                if (s != "")
                    sReply = DBAccess.FormatAdminError("error", "CostCategories.CanDeleteCostCategory", s);

                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostCategories.CanDeleteCostCategory", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        //public static StatusEnum DeleteCostCategories(DBAccess dba, out int lRowsAffected)
        //{
        //    string cmdText = "DELETE FROM EPGP_CATEGORIES";
        //    return (dba.DeleteData(cmdText, (StatusEnum)99956, out lRowsAffected));
        //}

        public static StatusEnum SaveCostCategories(DBAccess dba, int nMCLookupId, int nMCDefaultId, DataTable dt, out string sReply)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            int lRowsAffected = 0;

            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;
            sReply = "";

            try
            {
                // update the MC stuff in EPG_ADMIN if it has changed
                //      in VB we are clearing the MC values in PIs, Tasks, etc when changed - not sure that's a good idea but in any case don't know what to clear in WE
                DataTable dt1;
                int nMCLookup=0;
                int nMCDefault=0;
                dbaGeneral.SelectAdmin(dba, out dt1);
                if (dt1.Rows.Count == 1)
                {
                    DataRow row = dt1.Rows[0];
                    nMCLookup = DBAccess.ReadIntValue(row["ADM_MC_LOOKUP"]);
                    nMCDefault = DBAccess.ReadIntValue(row["ADM_MC_DEFAULT"]);
                    dt1 = null;
                }
                if (nMCLookupId != nMCLookup || nMCDefaultId != nMCDefault)
                {
                    cmdText = "UPDATE EPG_ADMIN Set ADM_MC_LOOKUP=@Lookup,ADM_MC_DEFAULT=@Default";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@Lookup", nMCLookupId);
                    oCommand.Parameters.AddWithValue("@Default", nMCDefaultId);
                    lRowsAffected += oCommand.ExecuteNonQuery();
                }

                //  Replace CATEGORIES with new set

                // first establish BCUID we'll use for any new Categories or Cost Categories
                //  if we need to create any new Category need MAX UID currently used in COST CATEGORIES (yes that's right!)
                int lNextUID = 0;
                cmdText = "Select MAX(BC_UID) as Max_UID From EPGP_COST_CATEGORIES";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                reader = oCommand.ExecuteReader();
                if (reader.Read())
                    lNextUID = DBAccess.ReadIntValue(reader["Max_UID"]) + 1;
                else
                    lNextUID = 1;
                reader.Close();

                //  ok - delete and re-add the categories
                dba.BeginTransaction();
                cmdText = "DELETE FROM EPGP_CATEGORIES";
                oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                oCommand.ExecuteNonQuery();

                if (dt.Rows.Count > 0)
                {
                    cmdText = "INSERT INTO EPGP_CATEGORIES (CA_UID,CA_NAME,CA_ID,CA_LEVEL,CA_ROLE,CA_UOM) VALUES(@CAUID,@CANAME,@CAID,@CALEVEL,@CAROLE,@CAUOM)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    SqlParameter pCAUID = oCommand.Parameters.Add("@CAUID", SqlDbType.Int);
                    SqlParameter pCANAME = oCommand.Parameters.Add("@CANAME", SqlDbType.VarChar, 255);
                    SqlParameter pCAID = oCommand.Parameters.Add("@CAID", SqlDbType.Int);
                    SqlParameter pCALEVEL = oCommand.Parameters.Add("@CALEVEL", SqlDbType.Int);
                    SqlParameter pCAROLE = oCommand.Parameters.Add("@CAROLE", SqlDbType.Int);
                    SqlParameter pCAUOM = oCommand.Parameters.Add("@CAUOM", SqlDbType.VarChar, 255);

                    int nIndex = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        nIndex++;
                        // these two are set to an empty string for a new row so have to grab carefully
                        int nCAUID = DBAccess.ReadIntValue(row["CA_UID"]);
                        int nCAROLE = DBAccess.ReadIntValue(row["CA_ROLE"]);

                        if (nCAUID > 0) { pCAUID.Value = nCAUID; } else { pCAUID.Value = lNextUID; lNextUID++; }
                        pCANAME.Value = row["CA_NAME"];
                        pCAID.Value = nIndex;
                        pCALEVEL.Value = row["CA_LEVEL"];
                        pCAROLE.Value = nCAROLE;
                        pCAUOM.Value = row["CA_UOM"];
                        oCommand.ExecuteNonQuery();
                    }
                }
                dba.CommitTransaction();

                // Create COST_CATEGORIES from CATEGORIES
                string sMessage;
                if (CreateCostCategories(dba, out sMessage) != StatusEnum.rsSuccess)
                {
                    sReply = DBAccess.FormatAdminError("error", "SaveCostCategories.CreateCostCategories", sMessage);
                    eStatus = StatusEnum.rsRequestCannotBeCompleted;
                }
                else
                {
                    // Clean up orphans that may have been created by deleting periods or categories at any time
                    oCommand = new SqlCommand("EPG_SP_CleanCTAdmin", dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "SaveCostCategories", ex.Message);
            }

            return eStatus;
        }
        public static StatusEnum UpdateCostCategoryRates(DBAccess dba, int nCA_UID, DataTable dt, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                if (nCA_UID > 0 && dt != null)
                {
                    // need to chek the data as it is not well controlled on the client
                    //   put data into a dictionary and then sort it by the data
                    Dictionary<DateTime, double> dic = new Dictionary<DateTime, double>();
                    List<DateTime> list = new List<DateTime>();
                    bool bIsNull;
                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime dDate = DBAccess.ReadDateValue(row["BC_EFFECTIVE_DATE"], out bIsNull);
                        double dRate = DBAccess.ReadDoubleValue(row["BC_RATE"]);
                        if (dRate > 0 || dDate > DateTime.MinValue)
                        {
                            if (!dic.ContainsKey(dDate)) dic.Add(dDate, dRate);  // realized this error means dup dates but need to know first date and anyway like what's below
                            list.Add(dDate);
                        }
                    }
                    list.Sort();

                    // after sort loop through keys to check for duplicates
                    DateTime prevDate = DateTime.MinValue;
                    foreach (DateTime dateKey in list)
                    {
                        if (dateKey == prevDate)
                        {
                            sReply = DBAccess.FormatAdminError("error", "CostCategories.UpdateRates", "The first date is empty but all other dates must be unique");
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                        else
                        {
                            prevDate = dateKey;
                        }
                    }


                    SqlTransaction transaction = dba.Connection.BeginTransaction();
                    cmdText =
                        "DELETE FROM EPG_COST_CATEGORY_RATE_VALUES WHERE BC_UID = @pCA_UID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pCA_UID", nCA_UID);
                    oCommand.ExecuteNonQuery();

                    if (dt.Rows.Count > 0)
                    {
                        cmdText =
                        "INSERT INTO EPG_COST_CATEGORY_RATE_VALUES (BC_UID,BC_EFFECTIVE_DATE,BC_RATE)"
                            + " VALUES(@pCA_UID,@pDate,@pRate)";
                        oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                        oCommand.Parameters.AddWithValue("@pCA_UID", nCA_UID);
                        SqlParameter pDate = oCommand.Parameters.Add("@pDate", SqlDbType.DateTime);
                        SqlParameter pRate = oCommand.Parameters.Add("@pRate", SqlDbType.Decimal);
                        //  need sizing data here?

                        bool bFirstDate = true;
                        foreach (DateTime dDate in list)
                        {
                            double dRate = dic[dDate];
                            if (dRate > 0 || dDate > DateTime.MinValue)  //  make sure we don't get no 'blank' lines
                            {
                                pRate.Value = dRate;
                                if (dDate == DateTime.Parse("1901-01-01") || bFirstDate == true) { pDate.Value = System.DBNull.Value; } else { pDate.Value = dDate; }
                                oCommand.ExecuteNonQuery();
                                bFirstDate = false;
                            }
                        }
                    }
                    transaction.Commit();
                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostTypes.UpdateCostTypeSecurityInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum CreateCostCategories(DBAccess dba, out string sReply)
        // Feb 2013 - I now need this functionality here for .NET Admin pages but it previously existed in the Data Synch area - Update Roles 
        //              I'll create a function here but will leave Data Synch stuff for now (safer) but if messing there then consider using this function
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;
            sReply = "";
            try
            {
                DataTable dt1;
                int MajorCategoryLookup = 0;
                dbaGeneral.SelectAdmin(dba, out dt1);
                if (dt1.Rows.Count == 1)
                {
                    DataRow row = dt1.Rows[0];
                    MajorCategoryLookup = DBAccess.ReadIntValue(row["ADM_MC_LOOKUP"]);
                    dt1 = null;
                }

                //  not using a transaction here as there is no point keeping the old values which will be wrong presumably or we wouldn't be re-creating them
                if (MajorCategoryLookup <= 0)
                {
                    //  just copy updated CATEGORIES into COST_CATEGORIES
                    cmdText = "Delete From EPGP_COST_CATEGORIES";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();


                    cmdText = "Insert Into EPGP_COST_CATEGORIES (BC_UID,BC_NAME,BC_ID,BC_LEVEL,BC_ROLE,BC_UOM,MC_UID,CA_UID)" +
                                " Select CA_UID,CA_NAME,CA_ID,CA_LEVEL,CA_ROLE,CA_UOM,0,CA_UID as CC From EPGP_CATEGORIES";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.ExecuteNonQuery();
                }
                else
                {
                    // regenerate all the Cost Categories but must keep old BC_UIDs, so first read then all into a list, then delete
                    int lMaxUID = 0;
                    cmdText = "Select BC_UID,BC_NAME,MC_UID,CA_UID From EPGP_COST_CATEGORIES ORDER BY BC_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    reader = oCommand.ExecuteReader();
                    List<PfECategory> costcategories = new List<PfECategory>();
                    while (reader.Read())
                    {
                        PfECategory costcategory = new PfECategory();
                        costcategory.Uid = DBAccess.ReadIntValue(reader["BC_UID"]);
                        costcategory.mc_Uid = DBAccess.ReadIntValue(reader["MC_UID"]);
                        costcategory.ID = DBAccess.ReadIntValue(reader["CA_UID"]);  // saving UID from EPGP_CATEGORIES in ID
                        costcategory.Name = DBAccess.ReadStringValue(reader["BC_NAME"]);
                        costcategories.Add(costcategory);
                        if (costcategory.Uid > lMaxUID) lMaxUID = costcategory.Uid;
                    }
                    reader.Close();

                    cmdText = "Delete From EPGP_COST_CATEGORIES";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();


                    // read the list of Major Categories
                    cmdText = "Select LV_UID,LV_VALUE From EPGP_LOOKUP_VALUES Where LOOKUP_UID=@MCUID" +
                                " ORDER BY LV_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@MCUID", MajorCategoryLookup);
                    reader = oCommand.ExecuteReader();

                    List<PfECategory> mcs = new List<PfECategory>();
                    while (reader.Read())
                    {
                        PfECategory mc = new PfECategory();
                        mc.Uid = DBAccess.ReadIntValue(reader["LV_UID"]);
                        mc.Name = DBAccess.ReadStringValue(reader["LV_VALUE"]);
                        mcs.Add(mc);
                    }
                    reader.Close();

                    //  read in the Categories which will be written multiple times into Cost Categories
                    cmdText = "Select CA_UID,CA_NAME,CA_ID,CA_LEVEL,CA_ROLE,CA_UOM From EPGP_CATEGORIES ORDER BY CA_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    reader = oCommand.ExecuteReader();
                    List<PfECategory> categories = new List<PfECategory>();
                    while (reader.Read())
                    {
                        PfECategory category = new PfECategory();
                        category.Uid = DBAccess.ReadIntValue(reader["CA_UID"]);
                        category.ID = DBAccess.ReadIntValue(reader["CA_ID"]);
                        category.Level = DBAccess.ReadIntValue(reader["CA_LEVEL"]);
                        category.Role = DBAccess.ReadIntValue(reader["CA_ROLE"]);
                        category.Name = DBAccess.ReadStringValue(reader["CA_NAME"]);
                        category.UOM = DBAccess.ReadStringValue(reader["CA_UOM"]);
                        categories.Add(category);
                        if (category.Uid > lMaxUID) lMaxUID = category.Uid; // we might have created some new ones just now
                    }
                    reader.Close();
                    int lMasterCount = categories.Count + 1;

                    //  ready to start inserting...
                    cmdText = "Insert Into EPGP_COST_CATEGORIES (BC_UID,BC_NAME,BC_ID,BC_LEVEL,BC_ROLE,BC_UOM,MC_UID,CA_UID)" +
                               " Values (@UID,@NAME,@ID,@LEVEL,@ROLE,@UOM,@MCUID,@CAUID)";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    SqlParameter puid = oCommand.Parameters.Add("@UID", SqlDbType.Int);
                    SqlParameter pname = oCommand.Parameters.Add("@NAME", SqlDbType.NVarChar, 255);
                    SqlParameter pid = oCommand.Parameters.Add("@ID", SqlDbType.Int);
                    SqlParameter plevel = oCommand.Parameters.Add("@LEVEL", SqlDbType.Int);
                    SqlParameter prole = oCommand.Parameters.Add("@ROLE", SqlDbType.Int);
                    SqlParameter puom = oCommand.Parameters.Add("@UOM", SqlDbType.NVarChar, 255);
                    SqlParameter pmcuid = oCommand.Parameters.Add("@MCUID", SqlDbType.Int);
                    SqlParameter pcauid = oCommand.Parameters.Add("@CAUID", SqlDbType.Int);

                    //  make copy of categories - no Major Category
                    foreach (PfECategory category in categories)
                    {
                        puid.Value = category.Uid;
                        pname.Value = category.Name;
                        pid.Value = category.ID;
                        plevel.Value = category.Level;
                        prole.Value = category.Role;
                        puom.Value = category.UOM;
                        pmcuid.Value = 0;
                        pcauid.Value = category.Uid;
                        oCommand.ExecuteNonQuery();
                    }

                    //  make copy of categories for each Major Category
                    int lMajorIndex = 1;
                    foreach (PfECategory mc in mcs)
                    {
                        // add an entry for the MC itself
                        puid.Value = GetUID(costcategories, mc.Uid, 0, ref lMaxUID);
                        pname.Value = mc.Name;
                        pid.Value = lMajorIndex * lMasterCount;
                        plevel.Value = 1;
                        prole.Value = 0;
                        puom.Value = "";
                        pmcuid.Value = mc.Uid;
                        pcauid.Value = 0;
                        oCommand.ExecuteNonQuery();

                        foreach (PfECategory category in categories)
                        {
                            puid.Value = GetUID(costcategories, mc.Uid, category.Uid, ref lMaxUID);
                            pname.Value = category.Name;
                            pid.Value = (lMajorIndex * lMasterCount) + category.ID;
                            plevel.Value = category.Level + 1;
                            prole.Value = category.Role;
                            puom.Value = category.UOM;
                            pmcuid.Value = mc.Uid;
                            pcauid.Value = category.Uid;
                            oCommand.ExecuteNonQuery();
                        }
                        lMajorIndex += 1;
                    }

                }
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostCategories.CreateCostCategories", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }

            return eStatus;
        }

        private static int GetUID(List<PfECategory> oldItems, int mcUID, int CATUID, ref int lMaxUID)
        {
            foreach (PfECategory categoryitem in oldItems)
            {
                if (categoryitem.mc_Uid == mcUID && categoryitem.ID == CATUID)
                {
                    return categoryitem.Uid;
                }
            }
            lMaxUID += 1;
            return lMaxUID;
        }

        private class PfECategory
        {
            public int ID;
            public int Level;
            public string Name;
            public string ParentName;
            public int Role;
            public int Uid;
            public int mc_Uid;
            public string ExtId;
            public string UOM;
        }

    }
}

