using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PortfolioEngineCore
{

    public class dbaResourcePlanning
    {
        public static StatusEnum SelectCustomFields(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT FieldName,FieldId,FA_NAME,FA_LOOKUP_UID FROM"
                    + " (VALUES ('Code1', 9305),('Code2', 9306),('Code3', 9307),('Code4', 9308),('Code5', 9309), ('Text1', 9300),('Text2', 9301),('Text3', 9302),('Text4', 9303),('Text5', 9304)) A(FieldName, FieldId)"
                    + " left join EPGP_FIELD_ATTRIBS ON (FieldId = FA_FIELD_ID)";
            return dba.SelectData(cmdText, (StatusEnum)99979, out dt);
        }

        public static StatusEnum SelectCustomField(DBAccess dba, int nFieldId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_FIELD_ATTRIBS WHERE FA_FIELD_ID = @p1";
            return dba.SelectDataById(cmdText, nFieldId, (StatusEnum)99979, out dt);
        }

        public static StatusEnum UpdateCustomFieldInfo(DBAccess dba, int nFieldId, string sFieldName, string sFieldDesc,int nLookupID, int nLeafOnly, int nUseFullName, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                if (nFieldId > 0)
                {
                    // make sure a field name is entered
                    sFieldName = sFieldName.Trim();
                    if (sFieldName.Length == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "dbaResourcePlanning.UpdateCustomFieldInfo", "Please enter a Field Name");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                    //  a Code field MUST have a Lookup
                    if (nFieldId >= 9305 && nLookupID == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "dbaResourcePlanning.UpdateCustomFieldInfo", "You must specify a lookup table for any Code field");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }

                    //   just delete the field and re-add it
                    cmdText = "DELETE FROM EPGP_FIELD_ATTRIBS WHERE FA_FIELD_ID = @pFIELDID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@pFIELDID", nFieldId);
                    oCommand.ExecuteNonQuery();
                                        
                    cmdText = "INSERT Into EPGP_FIELD_ATTRIBS " + " (FA_FIELD_ID,FA_NAME,FA_DESC,FA_LOOKUPONLY,FA_LOOKUP_UID,FA_LEAFONLY,FA_USEFULLNAME)"
                               + " Values(@pFIELDID,@pNAME,@pDESC,@pLOOKUPONLY,@pLOOKUPUID,@pLEAFONLY,@pUSEFULLNAME)";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pFIELDID", nFieldId);
                    oCommand.Parameters.AddWithValue("@pNAME", sFieldName);
                    oCommand.Parameters.AddWithValue("@pDESC", sFieldDesc);
                    oCommand.Parameters.AddWithValue("@pLOOKUPONLY", 0);
                    oCommand.Parameters.AddWithValue("@pLOOKUPUID", nLookupID);
                    oCommand.Parameters.AddWithValue("@pLEAFONLY", nLeafOnly);
                    oCommand.Parameters.AddWithValue("@pUSEFULLNAME", nUseFullName);
                    oCommand.ExecuteNonQuery();

                    // need to update default RP view which isn't available to the user in WE so slightly different update than PfE original
                    // if field already exists then update the name if necessary
                    string sExistingTitle = "";
                    cmdText = "SELECT FIELD_TITLE From EPG_VIEW_FIELDS WHERE FIELD_ID = @p1";
                    DataTable dt;
                    if (dba.SelectDataById(cmdText, nFieldId, (StatusEnum)99999, out dt) != StatusEnum.rsSuccess)
                    {
                        sReply = DBAccess.FormatAdminError("exception", "ResourcePlanning.UpdateCustomFieldInfo", dba.StatusText);
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                    else if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        sExistingTitle = DBAccess.ReadStringValue(row["FIELD_TITLE"]);
                        if (sExistingTitle != sFieldName)
                        {
                            cmdText = "UPDATE EPG_VIEW_FIELDS SET FIELD_TITLE=@pFIELD_NAME WHERE FIELD_ID = @pFIELDID";
                            oCommand = new SqlCommand(cmdText, dba.Connection);
                            oCommand.Parameters.AddWithValue("@pFIELD_NAME", sFieldName);
                            oCommand.Parameters.AddWithValue("@pFIELDID", nFieldId);
                            oCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // need to add, first determine new colid then insert
                        int lNextColID = 0;
                        cmdText = "Select MAX(FIELD_COL_ID) as Max_ColID From EPG_VIEW_FIELDS Where VIEW_UID=101";
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        SqlDataReader reader = oCommand.ExecuteReader();
                        if (reader.Read())
                            lNextColID = DBAccess.ReadIntValue(reader["Max_ColID"]) + 1;
                        else
                            lNextColID = 1;
                        reader.Close();

                        cmdText = "INSERT Into EPG_VIEW_FIELDS (VIEW_UID,FIELD_ID,FIELD_COL_ID,FIELD_TITLE,FIELD_ALIGN,FIELD_HIDDEN,FIELD_FROZEN)"
                           + " Values(101,@pFIELDID,@pColId,@pTitle,@pAlign,@pHidden,@pFrozen)";
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        oCommand.Parameters.AddWithValue("@pFIELDID", nFieldId);
                        oCommand.Parameters.AddWithValue("@pColId", lNextColID);
                        oCommand.Parameters.AddWithValue("@pTitle", sFieldName);
                        oCommand.Parameters.AddWithValue("@pAlign", 0);
                        oCommand.Parameters.AddWithValue("@pHidden", 0);
                        oCommand.Parameters.AddWithValue("@pFrozen", 0);
                        oCommand.ExecuteNonQuery();
                    }


                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "dbaResourcePlanning.UpdateCustomFieldInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
        public static StatusEnum DeleteCustomField(DBAccess dba, int nFieldId, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                cmdText = "DELETE FROM EPGP_FIELD_ATTRIBS WHERE FA_FIELD_ID = @pFIELDID";
                oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                oCommand.Parameters.AddWithValue("@pFIELDID", nFieldId);
                oCommand.ExecuteNonQuery();

                // remove also from Default RP View which is a fixed thing in WE environment
                cmdText = "DELETE FROM EPG_VIEW_FIELDS WHERE VIEW_UID=101 and FIELD_ID = @pFIELDID";
                oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                oCommand.Parameters.AddWithValue("@pFIELDID", nFieldId);
                oCommand.ExecuteNonQuery();

                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "dbaResourcePlanning.DeleteCustomField", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
    }
}

