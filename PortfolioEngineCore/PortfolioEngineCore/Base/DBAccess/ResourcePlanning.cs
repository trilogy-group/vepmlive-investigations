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
                    if (nFieldId < 11810 && nLookupID == 0)
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

