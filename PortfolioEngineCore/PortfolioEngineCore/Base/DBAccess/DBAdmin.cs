using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace PortfolioEngineCore
{
    public class dbaDBAdmin
    {
        public static StatusEnum ClosePI(DBAccess dba, int nPROJECTID, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                //   set Deleted flag to 1
                cmdText = "UPDATE EPGP_PROJECTS SET PROJECT_MARKED_DELETION = 1 WHERE PROJECT_ID = @pPROJECT_ID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pPROJECT_ID", nPROJECTID);
                oCommand.ExecuteNonQuery();

                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "DBAdmin.ClosePI", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum OpenPI(DBAccess dba, int nPROJECTID, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                //   set Deleted flag to 0
                cmdText = "UPDATE EPGP_PROJECTS SET PROJECT_MARKED_DELETION = 0 WHERE PROJECT_ID = @pPROJECT_ID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pPROJECT_ID", nPROJECTID);
                oCommand.ExecuteNonQuery();

                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "DBAdmin.OpenPI", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum CheckInPI(DBAccess dba, int nPROJECTID, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                //   set Checked Out Flag to 0, keep ID of user because it still tells us who checked it out last
                cmdText = "UPDATE EPGP_PROJECTS SET PROJECT_CHECKEDOUT = 0 WHERE PROJECT_ID = @pPROJECT_ID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pPROJECT_ID", nPROJECTID);
                oCommand.ExecuteNonQuery();

                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "DBAdmin.OpenPI", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum DeletePI(DBAccess dba, int nPROJECT_ID, out string sReply)
        {
            SqlCommand oCommand;
            sReply = "";
            try
            {
                //   just delete the PI, PI is top of the heap so no checking just do it
                oCommand = new SqlCommand("EPG_SP_DeletePI", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@PROJID", nPROJECT_ID);
                oCommand.ExecuteNonQuery();

                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "DBAdmin.DeletePI", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
        public static StatusEnum DeleteResource(DBAccess dba, int nWRES_ID, out string sReply)
        {
            SqlCommand oCommand;
            sReply = "";
            try
            {
                // check if Resource can be deleted - should have already been verified but worth double checking here
                string sdeletemessage;
                if (CanDeleteResource(dba, nWRES_ID, out sdeletemessage) != StatusEnum.rsSuccess) return dba.Status;
                if (sdeletemessage.Length > 0)
                {
                    sReply = DBAccess.FormatAdminError("error", "CostViews.DeleteCostView", "This Cost View cannot be deleted, it is currently used as follows:" + "\n" + "\n" + sdeletemessage);
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                //   delete the Resource also replace where necessary
                oCommand = new SqlCommand("EPG_SP_DeleteResource", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@WRESID", nWRES_ID);
                oCommand.Parameters.AddWithValue("@ReplacementWRESID", dba.UserWResID);  // switch to me who is doing this
                oCommand.ExecuteNonQuery();

                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "DBAdmin.DeleteResource", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
        public static StatusEnum CanDeleteResource(DBAccess dba, int nWRES_ID, out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;
            sReply = "";
            try
            {
                if (nWRES_ID == dba.UserWResID)
                {
                    sReply = "You are logged in as this resource, cannot delete";
                    return StatusEnum.rsSuccess;
                }
                if (nWRES_ID == 1)
                {
                    sReply = "You cannot delete the Administrator";
                    return StatusEnum.rsSuccess;
                }
                //  check if resource used so as to prohibit delete
                int nMaxlines = 12;
                int nLines = 0;
                oCommand = new SqlCommand("EPG_SP_ReadUsedResource1", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@WresID", nWRES_ID);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    nLines ++;
                    if (nLines == nMaxlines)
                    {
                        sReply += "...";
                    }
                    else if (nLines < nMaxlines)
                    {
                        sReply += DBAccess.ReadStringValue(reader["Type"]) + ": " + DBAccess.ReadStringValue(reader["Name"]) + "\n";
                    }
                }
                reader.Close();

                //  Need to check the use of the resource in a CF here - ended up as only in PI CFs - can't handle in SP
                //  read list of PI Code fields used anywhere
                List<PfEItem> cfs = new List<PfEItem>();
                cmdText = "Select FA_NAME as Field_Name,FA_FIELD_ID as Field_ID,FA_TABLE_ID as Table_ID,FA_FIELD_IN_TABLE as Field_IN_TABLE" +
                            " From EPGC_FIELD_ATTRIBS" +
                            " Where FA_FORMAT = 7 And FA_TABLE_ID= 201" +
                            " Order by Field_ID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    PfEItem cfitem = new PfEItem();
                    cfitem.UID = DBAccess.ReadIntValue(reader["Field_ID"]);
                    cfitem.name = DBAccess.ReadStringValue(reader["Field_Name"]);
                    cfitem.lValue1 = DBAccess.ReadIntValue(reader["Table_ID"]);
                    cfitem.lValue2 = DBAccess.ReadIntValue(reader["Field_IN_TABLE"]);
                    cfs.Add(cfitem);
                }
                reader.Close();

                foreach (PfEItem cfitem in cfs)
                {
                    string sTable;
                    string sField;
                    int nTableID=cfitem.lValue1;
                    EPKClass01.GetTableAndField(nTableID, cfitem.lValue2, out sTable, out sField);
                    if (nTableID == (int)CustomFieldDBTable.ResourceINT)
                    {
                        // ended up that no Resource type CF on resources so far
                    }
                    else if (nTableID == (int)CustomFieldDBTable.PortfolioINT)
                    {
                        cmdText = "Select Top 2 PROJECT_NAME From EPGP_PROJECT_INT_VALUES iv"
                                + " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=iv.PROJECT_ID"
                                + " Where iv." + sField + "=@WresID";
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        oCommand.Parameters.AddWithValue("@WresID", nWRES_ID);
                        reader = oCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            sReply += "PI field " + cfitem.name + ": " + DBAccess.ReadStringValue(reader["PROJECT_NAME"]) + "\n";
                        }
                        reader.Close();

                        // PI codes also used for Program Data
                        cmdText = "Select Top 2 LV_VALUE as Program_Name From EPGP_PROG_INT_VALUES iv"
                                + " Inner Join EPGP_LOOKUP_VALUES p On p.LV_UID=iv.PROG_UID"
                                + " Where iv." + sField + "=@WresID";
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        oCommand.Parameters.AddWithValue("@WresID", nWRES_ID);
                        reader = oCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            sReply += "Program field " + cfitem.name + ": " + DBAccess.ReadStringValue(reader["Program_Name"]) + "\n";
                        }
                        reader.Close();
                    }
                }

                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "DBAdmin.CanDeleteResource", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
        public static StatusEnum CanDeleteResourceWarning(DBAccess dba, int nWRES_ID, out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                //  check if resource used so as to warn about delete
                int nMaxlines = 12;
                int nLines = 0;
                oCommand = new SqlCommand("EPG_SP_ReadUsedResource2", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@WresID", nWRES_ID);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    nLines++;
                    if (nLines == nMaxlines)
                    {
                        sReply += "...";
                    }
                    else if (nLines < nMaxlines)
                    {
                        sReply += DBAccess.ReadStringValue(reader["Type"]) + ": " + DBAccess.ReadStringValue(reader["Name"]) + "\n";
                    }
                }
                reader.Close();

                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "DBAdmin.CanDeleteResource", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        private class PfEItem
        {
            public int UID;
            public string name;
            public double dValue1;
            public int lValue1;
            public int lValue2;
            public bool bflag;
        }
    }
}
