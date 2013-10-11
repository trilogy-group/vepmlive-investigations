using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace PortfolioEngineCore
{
    public class dbaRPAdmin
    {
        public static StatusEnum SelectLookupTables(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "SELECT LOOKUP_UID, LOOKUP_NAME FROM EPGP_LOOKUP_TABLES ORDER BY LOOKUP_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
        }

        public static StatusEnum UpdateRPAdminInfo(DBAccess dba, int deptuid, int roleuid, int caluid, int mode, int opmode, int hoursuid)
        {
            const string cmdText = "UPDATE EPG_ADMIN "
                    + "SET ADM_RPE_DEPT_CODE=@ADM_RPE_DEPT_CODE,ADM_ROLE_CODE=@ADM_ROLE_CODE,ADM_PORT_COMMITMENTS_CB_ID=@ADM_PORT_COMMITMENTS_CB_ID,"
                    + "ADM_PORT_COMMITMENTS_MODE=@ADM_PORT_COMMITMENTS_MODE,ADM_PORT_COMMITMENTS_OPMODE=@ADM_PORT_COMMITMENTS_OPMODE,ADM_PROJ_RES_HOURS_CFID=@ADM_PROJ_RES_HOURS_CFID";

            string s = cmdText;
            s = s.Replace("@ADM_RPE_DEPT_CODE", deptuid.ToString("0"));
            s = s.Replace("@ADM_ROLE_CODE", roleuid.ToString("0"));
            s = s.Replace("@ADM_PORT_COMMITMENTS_CB_ID", caluid.ToString("0"));
            s = s.Replace("@ADM_PORT_COMMITMENTS_MODE", mode.ToString("0"));
            s = s.Replace("@ADM_PORT_COMMITMENTS_OPMODE", opmode.ToString("0"));
            s = s.Replace("@ADM_PROJ_RES_HOURS_CFID", hoursuid.ToString("0"));
            
            int lRowsAffected;
            return dba.ExecuteNonQuery(s, (StatusEnum)99999, out lRowsAffected);
        }

        public static int GetRPCalendar (DBAccess dba)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;
            int nCal=0;

            cmdText = "SELECT ADM_PORT_COMMITMENTS_CB_ID FROM EPG_ADMIN";
            oCommand = new SqlCommand(cmdText, dba.Connection);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                nCal = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_CB_ID"]);
            }
            reader.Close();
            reader = null;

            return nCal;
        }
    }
    public class dbaCustomFields
    {
        public static StatusEnum SelectCustomFields(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "SELECT FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,FA_DESC,"
                            + " case When (FA_TABLE_ID >100 And FA_TABLE_ID<200) Then 1 When (FA_TABLE_ID >200 And FA_TABLE_ID<300) Then 2 Else 0 End as Entity"
                            + " FROM EPGC_FIELD_ATTRIBS"
                            + " Where FA_TABLE_ID > 100 and FA_TABLE_ID < 300"
                            + " ORDER BY Entity,FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99857, out dt);
        }
        public static StatusEnum SelectPortfolioFormulaCustomFields(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "SELECT FA_FIELD_ID,FA_NAME"
                            + " FROM EPGC_FIELD_ATTRIBS"
                            + " WHERE FA_TABLE_ID > 200 AND FA_TABLE_ID < 300 AND (FA_FORMAT = 3 OR FA_FORMAT = 8 OR FA_FORMAT = 9)"
                            + " ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99857, out dt);
        }
        public static StatusEnum SelectCustomField(DBAccess dba, int lFieldId, out DataTable dt)
        {
            if (lFieldId > 0)
            {
                const string cmdText = "SELECT FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,FA_DESC,"
                                + " case When (FA_TABLE_ID >100 And FA_TABLE_ID<200) Then 1 When (FA_TABLE_ID >200 And FA_TABLE_ID<300) Then 2 Else 0 End as Entity"
                                + " FROM EPGC_FIELD_ATTRIBS"
                                + " Where FA_TABLE_ID > 100 and FA_TABLE_ID < 300 AND FA_FIELD_ID=@p1"
                                + " ORDER BY Entity,FA_NAME";
                return dba.SelectDataById(cmdText, lFieldId, (StatusEnum)99857, out dt);
            }
            else
            {
                const string cmdText = "SELECT FA_FIELD_ID=0,FA_NAME='New Custom Field',FA_FORMAT=9,FA_TABLE_ID=0,FA_FIELD_IN_TABLE=0,FA_DESC='',Entity=2";
                return dba.SelectData(cmdText, (StatusEnum)99857, out dt);
            }
        }
        public static StatusEnum UpdateCustomFieldInfo(DBAccess dba, int nEntity, int nFieldType, ref int nFieldId, string sFieldName, string sFieldDesc, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            SqlDataReader reader;
            StatusEnum eStatus = StatusEnum.rsSuccess;
            sReply = "";
            try
            {
                {
                    // make sure there isn't already another field with this name
                    sFieldName = sFieldName.Trim();
                    if (sFieldName.Length == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "Customfields.UpdateCustomFieldInfo", "Please enter a Field Name");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                    cmdText = "SELECT FA_FIELD_ID From EPGC_FIELD_ATTRIBS WHERE FA_NAME = @p1";
                    DataTable dt;
                    dba.SelectDataByName(cmdText, sFieldName, (StatusEnum)99917, out dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nExistingId = DBAccess.ReadIntValue(row["FA_FIELD_ID"]);
                        if (nExistingId != nFieldId)
                        {
                            sReply = DBAccess.FormatAdminError("error", "Customfields.UpdateCustomFieldInfo", "Can't save field.\nA field with name '" + sFieldName + "' already exists");
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                    }
                }

                if (nFieldId == 0)
                {

                    //   ADD new field - no need to figure new Field_ID now because the ID is an IDENTITY column

                    // figure which table
                    int nTableID = EPKClass01.GetTableID(nEntity, nFieldType);
                    string sTable;
                    string sField;
                    if (EPKClass01.GetTableAndField(nTableID, 1, out sTable, out sField))
                    {
                        cmdText = "SELECT TOP 1 * FROM " + sTable;
                        DataTable dt;
                        eStatus = dba.SelectData(cmdText, (StatusEnum)99885, out dt);

                        // find the field with the highest number suffix - eg PC_050 - user can add to these tables
                        string ColumnName;
                        int nMaxField = 0;
                        string sPrefix = sField.Substring(0, 3);
                        DataColumnCollection columns = dt.Columns;
                        foreach (DataColumn column in columns)
                        {
                            ColumnName = column.ColumnName;
                            string sThisPrefix = ColumnName.Substring(0, 3);
                            if (sThisPrefix == sPrefix)
                            {
                                string sfieldnumber = ColumnName.Substring(3);
                                int nFieldNumber = Int32.Parse(ColumnName.Substring(3));
                                if (nFieldNumber > nMaxField) nMaxField = nFieldNumber;
                            }
                        }
                        List<int> ListUsedFields = new List<int>();
                        cmdText = "SELECT FA_FIELD_IN_TABLE FROM EPGC_FIELD_ATTRIBS Where FA_TABLE_ID=" + nTableID.ToString();
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        reader = oCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            int nFieldNumber = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                            ListUsedFields.Add(nFieldNumber);
                        }
                        reader.Close();
                        reader = null;

                        int nUseField;
                        for (nUseField = 1; nUseField < nMaxField + 2; nUseField++)
                        {
                            if (!ListUsedFields.Contains(nUseField))
                                break;
                        }
                        if (nUseField > nMaxField)
                        {
                            //eStatus = dba.HandleStatusError(SeverityEnum.Error, "Update_CustomField", (StatusEnum)99884, "Can't save Field, all Fields of this type are already used");
                            sReply = DBAccess.FormatAdminError("error", "Customfields.UpdateCustomFieldInfo", "Can't save Field, all Fields of this type are already used");
                            return eStatus;
                        }
                        else
                        {
                            cmdText = "INSERT Into EPGC_FIELD_ATTRIBS " + " (FA_NAME,FA_DESC,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE)" + " Values(@pNAME,@pDESC,@pFORMAT,@pTABLE,@pFIELD)";
                            oCommand = new SqlCommand(cmdText, dba.Connection);
                            oCommand.Parameters.AddWithValue("@pNAME", sFieldName);
                            oCommand.Parameters.AddWithValue("@pDESC", sFieldDesc);
                            oCommand.Parameters.AddWithValue("@pFORMAT", nFieldType);
                            oCommand.Parameters.AddWithValue("@pTABLE", nTableID);
                            oCommand.Parameters.AddWithValue("@pFIELD", nUseField);
                            oCommand.ExecuteNonQuery();
                            dba.GetLastIdentityValue(out nFieldId);
                        }
                    }
                }
                else
                {

                    cmdText = "UPDATE EPGC_FIELD_ATTRIBS "
                        + " SET FA_NAME=@pNAME,FA_DESC=@pDESC"
                        + " WHERE FA_FIELD_ID = @pFIELDID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@pNAME", sFieldName);
                    oCommand.Parameters.AddWithValue("@pDESC", sFieldDesc);
                    oCommand.Parameters.AddWithValue("@pFIELDID", nFieldId);
                    int lRowsAffected = oCommand.ExecuteNonQuery();
                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "Customfields.UpdateCustomFieldInfo", ex.Message);
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
                // check if field can be deleted - not the best place for it but should be fine
                string sdeletemessage;
                if (CanDeleteCustomField(dba, nFieldId, out sdeletemessage) != StatusEnum.rsSuccess) goto Exit_Function;
                if (sdeletemessage.Length > 0)
                {
                    sReply = DBAccess.FormatAdminError("error", "Customfields.DeleteCustomField", "This Custom Field cannot be deleted, it is currently used as follows:" + "\n" + "\n" + sdeletemessage);
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                // get info for field to be deleted
                int nTable;
                int nField;
                {
                    cmdText = "SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID = @p1";
                    DataTable dt;
                    dba.SelectDataById(cmdText, nFieldId, (StatusEnum)99999, out dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        nTable = DBAccess.ReadIntValue(row["FA_TABLE_ID"]);
                        nField = DBAccess.ReadIntValue(row["FA_FIELD_IN_TABLE"]);
                    }
                    else
                    {
                        sReply = DBAccess.FormatAdminError("error", "Customfields.DeleteCustomField", "Can't delete field, field not found");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                }

                //   to be tidy need to clear field data

                string sTable;
                string sField;
                if (EPKClass01.GetTableAndField(nTable, nField, out sTable, out sField))
                {
                    if (nTable >= (int)CustomFieldTable.PortfolioINT && nTable <= (int)CustomFieldTable.PortfolioDATE)
                    {
                        cmdText = "Update " + sTable + " Set " + sField + "=NULL";
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        int lRowsAffected = oCommand.ExecuteNonQuery();
                    }
                    else if (nTable >= (int)CustomFieldTable.ResourceINT && nTable <= (int)CustomFieldTable.ResourceINT)
                    {
                        cmdText = "Update " + sTable + " Set " + sField + "=NULL";
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        int lRowsAffected = oCommand.ExecuteNonQuery();
                    }
                    else if (nTable == (int)CustomFieldTable.ResourceMV)
                    {
                        cmdText = "Delete From EPGC_RESOURCE_MV_VALUES Where MVR_FIELD_ID=@pField";
                        oCommand = new SqlCommand(cmdText, dba.Connection);
                        oCommand.Parameters.AddWithValue("@pField", nField);
                        int lRowsAffected = oCommand.ExecuteNonQuery();
                    }
                    // Delete any CALCs or CALC components
                    cmdText = "DELETE FROM EPGP_CALCS Where CL_RESULT=@pField1 Or CL_COMPONENT=@pField2";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pField1", nFieldId);
                    oCommand.Parameters.AddWithValue("@pField2", nFieldId);
                    oCommand.ExecuteNonQuery();

                    // Delete the CF itself
                    cmdText = "DELETE FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=@pField";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pField", nFieldId);
                    oCommand.ExecuteNonQuery();
                }

        Exit_Function:
                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "Customfields.DeleteCustomField", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum CanDeleteCustomField(DBAccess dba, int nFieldId, out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                // check if field can be deleted - not the best place for it but should be fine
                oCommand = new SqlCommand("EPG_SP_ReadUsedCF", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@FieldID", nFieldId);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    sReply += DBAccess.ReadStringValue(reader["UsedMessage"]) + ": ";
                    sReply += DBAccess.ReadStringValue(reader["UsedData"]) + "\n";
                }
                reader.Close();
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "Customfields.CanDeleteCustomField", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
        public static StatusEnum GetCustomFieldNameFromID(DBAccess dba, int lFieldID, out string sTableName, out string sFieldName)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            sTableName = "";
            sFieldName = "";
            try
            {
                // Bugfix 27JUN08 V5.3 - Don't allow showthrough of table or field if fieldid not found
                SqlCommand oCommand = new SqlCommand("EPG_SP_ReadFieldInfo", dba.Connection, dba.Transaction);
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
        public static StatusEnum SelectRPTotalHoursCustomFieldCandidates(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "SELECT FA_FIELD_ID,FA_NAME,FA_DESC"
                            + " FROM EPGC_FIELD_ATTRIBS"
                            + " Where FA_TABLE_ID = 203 And FA_FORMAT=3"
                            + " ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99857, out dt);
        }
        public static StatusEnum SelectRoles(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "SELECT LV_UID, LV_VALUE "
                            + " FROM EPGP_LOOKUP_VALUES"
                            + " WHERE LOOKUP_UID = (SELECT ADM_ROLE_CODE FROM EPG_ADMIN)"
                            + " ORDER BY LV_ID";
            return dba.SelectData(cmdText, (StatusEnum)99857, out dt);
        }
        private static void GetCFFieldName(int lTableID, int lFieldID, out string sTable, out string sField)
        {
            switch ((CustomFieldDBTable)lTableID)
            {
                case CustomFieldDBTable.ResourceINT:
                    sTable = "EPGC_RESOURCE_INT_VALUES";
                    sField = "RI_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceTEXT:
                    sTable = "EPGC_RESOURCE_TEXT_VALUES";
                    sField = "RT_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceDEC:
                    sTable = "EPGC_RESOURCE_DEC_VALUES";
                    sField = "RC_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceNTEXT:
                    sTable = "EPGC_RESOURCE_NTEXT_VALUES";
                    sField = "RN_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceDATE:
                    sTable = "EPGC_RESOURCE_DATE_VALUES";
                    sField = "RD_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceMV:
                    sTable = "EPGC_RESOURCE_MV_VALUES";
                    sField = "MVR_UID";
                    break;
                case CustomFieldDBTable.PortfolioINT:
                    sTable = "EPGP_PROJECT_INT_VALUES";
                    sField = "PI_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioTEXT:
                    sTable = "EPGP_PROJECT_TEXT_VALUES";
                    sField = "PT_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioDEC:
                    sTable = "EPGP_PROJECT_DEC_VALUES";
                    sField = "PC_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioNTEXT:
                    sTable = "EPGP_PROJECT_NTEXT_VALUES";
                    sField = "PN_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioDATE:
                    sTable = "EPGP_PROJECT_DATE_VALUES";
                    sField = "PD_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.Program:
                    sTable = "EPGP_PI_PROGS";
                    sField = "PROG_UID";
                    break;
                case CustomFieldDBTable.ProjectINT:
                    sTable = "EPGX_PROJ_INT_VALUES";
                    sField = "XI_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectTEXT:
                    sTable = "EPGX_PROJ_TEXT_VALUES";
                    sField = "XT_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectDEC:
                    sTable = "EPGX_PROJ_DEC_VALUES";
                    sField = "XC_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectNTEXT:
                    sTable = "EPGX_PROJ_NTEXT_VALUES";
                    sField = "XN_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectDATE:
                    sTable = "EPGX_PROJ_DATE_VALUES";
                    sField = "XD_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProgramText:
                    sTable = "EPGP_PI_PROGS";
                    sField = "PROG_PI_TEXT" + lFieldID.ToString("0");
                    break;
                case CustomFieldDBTable.TaskWIINT:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_FLAG" + lFieldID.ToString("0");
                    break;
                case CustomFieldDBTable.TaskWITEXT:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_CTEXT" + lFieldID.ToString("0");
                    break;
                case CustomFieldDBTable.TaskWIDEC:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_NUMBER" + lFieldID.ToString("0");
                    break;
                default:
                    sTable = "Unknown Table";
                    sField = "";
                    break;
            }
        }
        public static StatusEnum SelectCustomFieldFormula(DBAccess dba, int lFieldId, out DataTable dt)
        {
            const string cmdText = "SELECT CL_UID,CL_SEQ,CL_RESULT,CL_COMPONENT,CL_RATIO,CL_OP,CL_PRI,f1.FA_NAME as ResultName,f2.FA_NAME as ComponentName"
                + " FROM EPGP_CALCS c "
                + " Join EPGC_FIELD_ATTRIBS f1 On c.CL_RESULT=f1.FA_FIELD_ID"
                + " Left Join EPGC_FIELD_ATTRIBS f2 On c.CL_COMPONENT=f2.FA_FIELD_ID"
                + " Where CL_OBJECT=1 AND CL_RESULT=@p1"
                + " Order By CL_UID,CL_SEQ";
            return dba.SelectDataById(cmdText, lFieldId, (StatusEnum)99857, out dt);
        }
        public static StatusEnum DeleteCustomFieldFormula(DBAccess dba, int lFieldId, out int lRowsAffected)
        {
            const string cmdText = "DELETE EPGP_CALCS WHERE CL_OBJECT=1 AND CL_RESULT=@p1";
            return dba.DeleteDataById(cmdText, lFieldId, (StatusEnum)99857, out lRowsAffected);
        }

        private class ItemRow
        {
            public bool hasOp = false;
            public bool hasField = false;
            public bool hasConstant = false;
            public decimal ratio = (decimal)1;
            public int fieldId = 0;
            public int opId = 0;
            public string value = "";
        }

        public static string ValidateAndSaveCustomFieldFormula(DBAccess dba, int nFieldId, ref string sFormula, bool bSave = false)
        {
            string sError = "";
            sFormula = sFormula.Trim();
            if (sFormula == string.Empty)
            {
                if (bSave)
                {
                    int lRowsAffected;
                    dbaCustomFields.DeleteCustomFieldFormula(dba, nFieldId, out  lRowsAffected);
                }
                goto Exit_Function;
            }

            // read in the valid operands (other than constants)
            DataTable dt;
            dbaCustomFields.SelectPortfolioFormulaCustomFields(dba, out dt);
            // split formula on operators but keep operators in array
            string[] arrFormula = Regex.Split(sFormula, @"([-+/*])");
            // validate and trim the array
            int opCount = 0;
            int fieldCount = 0;
            int decCount = 0;
            List<ItemRow> itemRows = new List<ItemRow>();
            for (int i = 0; i < arrFormula.Length; i++)
            {
                arrFormula[i] = arrFormula[i].Trim();
                if (arrFormula[i] != string.Empty)
                {
                    ItemRow itemRow = new ItemRow();
                    itemRow.value = arrFormula[i];
                    switch (arrFormula[i])
                    {
                        case "*":
                        case "/":
                        case "+":
                        case "-":
                            itemRow.hasOp = true;
                            switch (arrFormula[i])
                            {
                                case "+":
                                    itemRow.opId = 0;
                                    break;
                                case "-":
                                    itemRow.opId = 1;
                                    break;
                                case "*":
                                    itemRow.opId = 2;
                                    break;
                                case "/":
                                    itemRow.opId = 3;
                                    break;
                            }
                            itemRows.Add(itemRow);
                            opCount++;
                            if (opCount > decCount + fieldCount)
                            {
                                sError = DBAccess.FormatAdminError("error", "dbaCustomFields.ValidateAndSaveCustomFieldFormula", "Too many operators");
                                goto Exit_Function;
                            }
                            break;
                        default:
                            // check for field or constant
                            if (Regex.IsMatch(arrFormula[i], @"\A[0-9]*(\.[0-9]+)\z|\A[0-9]+\z") != true)
                            {
                                // field
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (DBAccess.ReadStringValue(row["FA_NAME"]) == arrFormula[i])
                                    {
                                        int nFoundFieldId = DBAccess.ReadIntValue(row["FA_FIELD_ID"]);
                                        if (nFoundFieldId == nFieldId)
                                        {
                                            sError = DBAccess.FormatAdminError("error", "dbaCustomFields.ValidateAndSaveCustomFieldFormula", "Cannot use custom field in its own formula");
                                            goto Exit_Function;
                                        }
                                        itemRow.hasField = true;
                                        itemRow.fieldId = nFoundFieldId;
                                        itemRows.Add(itemRow);
                                        fieldCount++;
                                        break;
                                    }
                                }
                                if (itemRow.hasField == false)
                                {
                                    sError = DBAccess.FormatAdminError("error", "dbaCustomFields.ValidateAndSaveCustomFieldFormula", "Unknown custom field name: " + itemRow.value);
                                    goto Exit_Function;
                                }
                            }
                            else
                            {
                                decimal dec;
                                if (decimal.TryParse(arrFormula[i], out dec))
                                {
                                    itemRow.hasConstant = true;
                                    itemRow.ratio = dec;
                                    itemRows.Add(itemRow);
                                    decCount++;
                                }
                                else
                                {
                                    sError = DBAccess.FormatAdminError("error", "dbaCustomFields.ValidateAndSaveCustomFieldFormula", "invalid value: " + itemRow.value);
                                    goto Exit_Function;
                                }
                            }
                            if (opCount+1 < decCount + fieldCount)
                            {
                                sError = DBAccess.FormatAdminError("error", "dbaCustomFields.ValidateAndSaveCustomFieldFormula", "Too few operators");
                                goto Exit_Function;
                            }
                            break;
                    }
                }
            }
            if (opCount >= decCount + fieldCount)
            {
                sError = DBAccess.FormatAdminError("error", "dbaCustomFields.ValidateAndSaveCustomFieldFormula", "Formula cannot start or finish with an operator");
                goto Exit_Function;
            }

            // if we get here then have a list of pre-validated operators, fields and constants.

            ItemRow[] arrItemRows = itemRows.ToArray();

            // reinit list to put consolidated items in
            itemRows = new List<ItemRow>();

            {
                int i = 0;
                ItemRow itemRow = new ItemRow();
                while (i < arrItemRows.Length)
                {
                    int nInc = 1;
                    if (arrItemRows[i].hasOp)
                        itemRow.opId = arrItemRows[i].opId;
                    else
                    {
                        bool bRowComplete = false;
                        if (i + 2 < arrItemRows.Length)
                        {
                            if (arrItemRows[i].hasField && arrItemRows[i + 1].value == "*" && arrItemRows[i + 2].hasConstant)
                            {
                                itemRow.fieldId = arrItemRows[i].fieldId;
                                itemRow.ratio = arrItemRows[i + 2].ratio;
                                nInc = 3;
                                bRowComplete = true;
                            }
                            else if (arrItemRows[i].hasConstant && arrItemRows[i + 1].value == "*" && arrItemRows[i + 2].hasField)
                            {
                                itemRow.fieldId = arrItemRows[i + 2].fieldId;
                                itemRow.ratio = arrItemRows[i].ratio;
                                nInc = 3;
                                bRowComplete = true;
                            }
                        }
                        if (bRowComplete == false)
                        {
                            if (arrItemRows[i].hasField)
                            {
                                itemRow.fieldId = arrItemRows[i].fieldId;
                                itemRow.ratio = 1;
                                bRowComplete = true;
                            }
                            else if (arrItemRows[i].hasConstant)
                            {
                                itemRow.fieldId = 0;
                                itemRow.ratio = arrItemRows[i].ratio;
                                bRowComplete = true;
                            }
                        }
                        if (bRowComplete)
                        {
                            itemRows.Add(itemRow);
                            itemRow = new ItemRow();
                        }
                    }
                    i += nInc;
                }
            }


            // if we get here we can assume formula is valid.
            if (bSave)
            {
                int lRowsAffected;
                dbaCustomFields.DeleteCustomFieldFormula(dba, nFieldId, out  lRowsAffected);
                int nNewCLUID = 0;
                const string cmdText = "SELECT MAX(CL_UID) As maxUID FROM EPGP_CALCS";
                dba.SelectData(cmdText, (StatusEnum)99999, out dt);
                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    nNewCLUID = DBAccess.ReadIntValue(row["maxUID"]) + 1;
                }


                const string sCommand = "INSERT INTO  EPGP_CALCS (CL_OBJECT, CL_PRI, CL_OP, CL_UID, CL_SEQ, CL_RESULT, CL_COMPONENT, CL_RATIO) " +
                            "VALUES(1, 0, @CL_OP, @CL_UID, @CL_SEQ, @CL_RESULT, @CL_COMPONENT, @CL_RATIO)";

                SqlCommand oCmdCL = new SqlCommand(sCommand, dba.Connection);
                SqlParameter cl_op = oCmdCL.Parameters.Add("@CL_OP", SqlDbType.Int);
                SqlParameter cl_uid = oCmdCL.Parameters.Add("@CL_UID", SqlDbType.Int);
                SqlParameter cl_seq = oCmdCL.Parameters.Add("@CL_SEQ", SqlDbType.Int);
                SqlParameter cl_result = oCmdCL.Parameters.Add("@CL_RESULT", SqlDbType.Int);
                SqlParameter cl_component = oCmdCL.Parameters.Add("@CL_COMPONENT", SqlDbType.Int);
                SqlParameter cl_ratio = oCmdCL.Parameters.Add("@CL_RATIO", SqlDbType.Decimal);

                cl_ratio.Precision = 25;
                cl_ratio.Scale = 6;

                //PriItemDefn ritem;
                //PriItemDefn citem;
                int seq = 0;
                foreach (ItemRow itemRow in itemRows)
                {
                    cl_op.Value = itemRow.opId;
                    cl_uid.Value = nNewCLUID;
                    cl_seq.Value = ++seq;
                    cl_result.Value = nFieldId;
                    cl_component.Value = itemRow.fieldId;
                    cl_ratio.Value = itemRow.ratio;

                    oCmdCL.ExecuteNonQuery();
                }
            }

        Exit_Function:
            return sError;
        }
    }

    public class dbaPrioritz
    {
        public static StatusEnum SelectFields(DBAccess dba, out DataTable dt)
        {
            const string cmdText =
                "SELECT * FROM EPGC_FIELD_ATTRIBS Where ((FA_TABLE_ID=203 and FA_FORMAT=3) or (FA_TABLE_ID=202 and FA_FORMAT=9)) ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum) 99858, out dt);
        }

        public static StatusEnum SelectComponents(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "Select * From EPGP_PI_PRI_COMPONENTS Order BY CC_SEQ";
            return dba.SelectData(cmdText, (StatusEnum) 99857, out dt);
        }

        public static StatusEnum SelectFormulas(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "Select Distinct c.CW_RESULT,f.FA_NAME From EPGP_PI_PRI_WEIGHTS c" +
                             " Inner Join EPGC_FIELD_ATTRIBS f On f.FA_FIELD_ID=c.CW_RESULT Order BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum) 99856, out dt);
        }

        public static StatusEnum SelectWeights(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "Select * From EPGP_PI_PRI_WEIGHTS";
            return dba.SelectData(cmdText, (StatusEnum) 99855, out dt);
        }

        public static StatusEnum SelectComponentFields(DBAccess dba, out DataTable dt)
        {
            const string cmdText =
                "SELECT * FROM EPGC_FIELD_ATTRIBS Where ((FA_TABLE_ID=203 and FA_FORMAT=3) or (FA_TABLE_ID=202 and FA_FORMAT=9))" +
                " And FA_FIELD_ID Not In (Select Distinct CL_RESULT From EPGP_CALCS Where CL_PRI=1)" +
                " ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum) 99854, out dt);
        }

        public static StatusEnum SelectFormulaFields(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "SELECT * FROM EPGC_FIELD_ATTRIBS Where (FA_TABLE_ID=203 and FA_FORMAT=3)" +
                             " And FA_FIELD_ID Not In (Select CC_COMPONENT From EPGP_PI_PRI_COMPONENTS)" +
                             " ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum) 99853, out dt);
        }

        public static StatusEnum UpdateComponents(DBAccess dba, DataTable dtComponents, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;

            if (eStatus == StatusEnum.rsSuccess)
            {
                lRowsAffected = 0;
                {
                    dba.BeginTransaction();
                    try
                    {
                        SqlCommand oCommand;
                        string cmdText;
                        cmdText = "DELETE FROM EPGP_PI_PRI_COMPONENTS";
                        oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                        lRowsAffected = oCommand.ExecuteNonQuery();

                        if (dtComponents.Rows.Count > 0)
                        {
                            cmdText = "INSERT INTO EPGP_PI_PRI_COMPONENTS (CC_COMPONENT,CC_SEQ) VALUES(@CC_COMPONENT,@CC_SEQ)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            SqlParameter pComponent = oCommand.Parameters.Add("@CC_COMPONENT", SqlDbType.Int);
                            SqlParameter pSEQ = oCommand.Parameters.Add("@CC_SEQ", SqlDbType.Int);

                            int lCTRowsAffected = 0;
                            int lSEQ = 0;
                            foreach (DataRow row in dtComponents.Rows)
                            {
                                pSEQ.Value = ++lSEQ;
                                int nValue = DBAccess.ReadIntValue(row["ComponentValue"]);
                                pComponent.Value = nValue;
                                lCTRowsAffected += oCommand.ExecuteNonQuery();
                            }

                            // clean out orphans that may have been caused in WEIGHTS
                            cmdText = "DELETE FROM EPGP_PI_PRI_WEIGHTS Where CW_COMPONENT Not In (Select CC_COMPONENT From EPGP_PI_PRI_COMPONENTS)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            lRowsAffected = oCommand.ExecuteNonQuery();

                            eStatus = UpdateCalcs(dba);
                        }
                        dba.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateComponents", (StatusEnum) 99852, ex.Message);
                        dba.RollbackTransaction();
                    }
                }
            }
            return eStatus;
        }

        public static StatusEnum UpdateFormulas(DBAccess dba, DataTable dtFormulas, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;

            SqlCommand oCommand;
            string cmdText;

            // need to read existing formulas and components
            DataTable dt;
            List<int> Components = new List<int>();
            if (SelectComponents(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
            foreach (DataRow row in dt.Rows)
            {
                int lFieldID = DBAccess.ReadIntValue(row["CC_COMPONENT"]);
                Components.Add(lFieldID);
            }

            List<int> OLDFormulas = new List<int>();
            if (SelectFormulas(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
            foreach (DataRow row in dt.Rows)
            {
                int lFieldID = DBAccess.ReadIntValue(row["CW_RESULT"]);
                OLDFormulas.Add(lFieldID);
            }


            if (eStatus == StatusEnum.rsSuccess)
            {
                lRowsAffected = 0;
                {
                    dba.BeginTransaction();
                    try
                    {
                        if (dtFormulas.Rows.Count > 0)
                        {
                            cmdText =
                                "INSERT INTO EPGP_PI_PRI_WEIGHTS (CW_RESULT,CW_COMPONENT,CW_RATIO) VALUES(@CW_RESULT,@CW_COMPONENT,@CW_RATIO)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            SqlParameter pRESULT = oCommand.Parameters.Add("@CW_RESULT", SqlDbType.Int);
                            SqlParameter pCOMPONENT = oCommand.Parameters.Add("@CW_COMPONENT", SqlDbType.Int);
                            oCommand.Parameters.AddWithValue("@CW_RATIO", 0);

                            foreach (DataRow row in dtFormulas.Rows)
                            {
                                int nFormula = DBAccess.ReadIntValue(row["Formula"]);
                                if (OLDFormulas.Contains(nFormula))
                                {
                                    OLDFormulas.Remove(nFormula);
                                }
                                else
                                {
                                    // add an entry into WEIGHT table for each component
                                    foreach (int nComponent in Components)
                                    {
                                        pRESULT.Value = nFormula;
                                        pCOMPONENT.Value = nComponent;
                                        int lCCRowsAffected = oCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        // delete formulas no longer needed
                        foreach (int nFormula in OLDFormulas)
                        {
                            cmdText = "DELETE FROM EPGP_PI_PRI_WEIGHTS Where CW_RESULT=" + nFormula.ToString("0");
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            int lCCRowsAffected = oCommand.ExecuteNonQuery();
                        }

                        eStatus = UpdateCalcs(dba);

                        dba.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateFormulas", (StatusEnum) 99851, ex.Message);
                        dba.RollbackTransaction();
                    }
                }
            }
            Status_Error:

            return eStatus;
        }

        public static StatusEnum UpdateWeights(DBAccess dba, List<EPKPriFormula> Formulas, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;

            SqlCommand oCommand;
            string cmdText;

            if (eStatus == StatusEnum.rsSuccess)
            {
                lRowsAffected = 0;
                {
                    dba.BeginTransaction();
                    try
                    {
                        cmdText = "DELETE FROM EPGP_PI_PRI_WEIGHTS";
                        oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                        lRowsAffected = oCommand.ExecuteNonQuery();

                        if (Formulas.Count > 0)
                        {
                            cmdText =
                                "INSERT INTO EPGP_PI_PRI_WEIGHTS (CW_RESULT,CW_COMPONENT,CW_RATIO) VALUES(@CW_RESULT,@CW_COMPONENT,@CW_RATIO)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            SqlParameter pResult = oCommand.Parameters.Add("@CW_RESULT", SqlDbType.Int);
                            SqlParameter pComponent = oCommand.Parameters.Add("@CW_COMPONENT", SqlDbType.Int);
                            SqlParameter pRatio = oCommand.Parameters.Add("@CW_RATIO", SqlDbType.Float);
                            pRatio.Precision = 25;
                            pRatio.Scale = 6;

                            int lCWRowsAffected = 0;
                            foreach (EPKPriFormula Formula in Formulas)
                            {
                                foreach (ComponentWeight component in Formula.components)
                                {
                                    pResult.Value = Formula.uid;
                                    pComponent.Value = component.ComponentId;
                                    pRatio.Value = component.Weight;
                                    lCWRowsAffected += oCommand.ExecuteNonQuery();
                                }
                            }
                            eStatus = UpdateCalcs(dba);
                        }
                        dba.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateComponents", (StatusEnum) 99850, ex.Message);
                        dba.RollbackTransaction();
                    }
                }
            }
            if (dba.Status == StatusEnum.rsSuccess) eStatus = PerformCustomFieldsCalculate(dba);

            return eStatus;
        }

        private static StatusEnum UpdateCalcs(DBAccess dba)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;

            SqlCommand oCommand;
            string cmdText;

            // read formulas and components
            DataTable dt;
            List<int> Components = new List<int>();
            if (SelectComponents(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
            foreach (DataRow row in dt.Rows)
            {
                int lFieldID = DBAccess.ReadIntValue(row["CC_COMPONENT"]);
                Components.Add(lFieldID);
            }

            List<int> Formulas = new List<int>();
            if (SelectFormulas(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
            foreach (DataRow row in dt.Rows)
            {
                int lFieldID = DBAccess.ReadIntValue(row["CW_RESULT"]);
                Formulas.Add(lFieldID);
            }

            if (eStatus == StatusEnum.rsSuccess)
            {
                int lRowsAffected = 0;
                {
                    try
                    {
                        cmdText = "DELETE FROM EPGP_CALCS Where CL_PRI=1";
                        oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                        lRowsAffected = oCommand.ExecuteNonQuery();

                        if (Formulas.Count > 0 && Components.Count > 0)
                        {
                            // get UID for next formula
                            int nNewCLUID = 0;
                            cmdText = "SELECT MAX(CL_UID) As maxUID FROM EPGP_CALCS";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            SqlDataReader reader = oCommand.ExecuteReader();

                            if (reader.Read())
                            {
                                nNewCLUID = DBAccess.ReadIntValue(reader["maxUID"]);
                            }
                            reader.Close();

                            cmdText =
                                "INSERT INTO EPGP_CALCS (CL_OBJECT,CL_UID,CL_SEQ,CL_RESULT,CL_COMPONENT,CL_RATIO,CL_OP,CL_PRI) VALUES(@CL_OBJECT,@CL_UID,@CL_SEQ,@CL_RESULT,@CL_COMPONENT,@CL_RATIO,@CL_OP,@CL_PRI)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            oCommand.Parameters.AddWithValue("@CL_OBJECT", 1);
                            SqlParameter pUID = oCommand.Parameters.Add("@CL_UID", SqlDbType.Int);
                            SqlParameter pSEQ = oCommand.Parameters.Add("@CL_SEQ", SqlDbType.Int);
                            SqlParameter pRESULT = oCommand.Parameters.Add("@CL_RESULT", SqlDbType.Int);
                            SqlParameter pCOMPONENT = oCommand.Parameters.Add("@CL_COMPONENT", SqlDbType.Int);
                            oCommand.Parameters.AddWithValue("@CL_RATIO", 0);
                            oCommand.Parameters.AddWithValue("@CL_OP", 0);
                            oCommand.Parameters.AddWithValue("@CL_PRI", 1);

                            foreach (int nFormula in Formulas)
                            {
                                // add an entry into CLAC table for each component for each formula
                                int lSEQ = 0;
                                nNewCLUID = nNewCLUID + 1;
                                foreach (int nComponent in Components)
                                {
                                    lSEQ = lSEQ + 1;
                                    pUID.Value = nNewCLUID;
                                    pSEQ.Value = lSEQ;
                                    pRESULT.Value = nFormula;
                                    pCOMPONENT.Value = nComponent;
                                    int lCCRowsAffected = oCommand.ExecuteNonQuery();
                                }
                            }

                            // update the Ratios in the CALC table from the Weights table
                            cmdText = "Update EPGP_CALCS Set CL_RATIO=CW_RATIO"
                                      + " From EPGP_CALCS JOIN EPGP_PI_PRI_WEIGHTS"
                                      +
                                      " On EPGP_CALCS.CL_RESULT=EPGP_PI_PRI_WEIGHTS.CW_RESULT And EPGP_CALCS.CL_COMPONENT=EPGP_PI_PRI_WEIGHTS.CW_COMPONENT"
                                      + " And EPGP_CALCS.CL_PRI=1";
                            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                            lRowsAffected = oCommand.ExecuteNonQuery();

                        }
                    }
                    catch (Exception ex)
                    {
                        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdateComponents", (StatusEnum) 99849,
                                                        ex.Message.ToString());
                    }
                }
            }

            Status_Error:

            return eStatus;
        }

        private static StatusEnum PerformCustomFieldsCalculate(DBAccess dba)
        {
            //StatusEnum eStatus = StatusEnum.rsSuccess;

            List<string> sqlstatements = new List<string>();
            string seqStmt = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            int lastuid = -1;
            int uid = 0;
            int fit = 0;
            int fat = 0;
            double dRatio = 0;
            int seq = 0;
            int op = 0;
            string sOp = "";

            string sCommand =
                "SELECT     EPGP_CALCS.CL_UID, EPGP_CALCS.CL_SEQ, EPGP_CALCS.CL_RESULT, EPGC_FIELD_ATTRIBS.FA_FIELD_IN_TABLE, " +
                "EPGP_CALCS.CL_COMPONENT, EPGC_FIELD_ATTRIBS_1.FA_FIELD_IN_TABLE AS Expr1, EPGP_CALCS.CL_RATIO, EPGP_CALCS.CL_OP, " +
                "EPGC_FIELD_ATTRIBS_1.FA_TABLE_ID AS EXFAT " +
                "FROM         EPGP_CALCS INNER JOIN " +
                "EPGC_FIELD_ATTRIBS ON EPGP_CALCS.CL_RESULT = EPGC_FIELD_ATTRIBS.FA_FIELD_ID LEFT JOIN " +
                "EPGC_FIELD_ATTRIBS AS EPGC_FIELD_ATTRIBS_1 ON EPGP_CALCS.CL_COMPONENT = EPGC_FIELD_ATTRIBS_1.FA_FIELD_ID " +
                "Where (EPGP_CALCS.CL_OBJECT = 1) ";

            //          if (bonlyPRIs)
            sCommand += " AND (EPGP_CALCS.CL_PRI = 1) ";

            sCommand += " ORDER BY EPGP_CALCS.CL_UID, EPGP_CALCS.CL_SEQ";

            string sWhereClause = "";

            oCommand = new SqlCommand(sCommand, dba.Connection);
            reader = oCommand.ExecuteReader();
            string sErrSQL = "";


            while (reader.Read())
            {
                uid = DBAccess.ReadIntValue(reader["CL_UID"]);

                if (lastuid != uid)
                {
                    if (seqStmt != "")
                    {
                        seqStmt +=
                            "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID ";
                        sqlstatements.Add(seqStmt + sWhereClause);

                        if (sWhereClause != "")
                            sqlstatements.Add(sErrSQL + sWhereClause);
                    }

                    seqStmt = "";
                    sWhereClause = "";

                    lastuid = uid;

                    fit = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);

                    seqStmt = "UPDATE EPGP_PROJECT_DEC_VALUES SET PC_" + fit.ToString("000") + " = ";

                    sErrSQL = "UPDATE EPGP_PROJECT_DEC_VALUES SET PC_" + fit.ToString("000") + " = 999999 ";

                }



                seq = DBAccess.ReadIntValue(reader["CL_SEQ"]);
                op = DBAccess.ReadIntValue(reader["CL_OP"]);

                if (seq != 1)
                {
                    if (op == 1)
                        sOp = " - ";
                    else if (op == 2)
                        sOp = " * ";
                    else if (op == 3)
                        sOp = " / ";
                    else
                        sOp = " + ";


                    seqStmt += sOp;
                }

                fit = DBAccess.ReadIntValue(reader["Expr1"]);
                fat = DBAccess.ReadIntValue(reader["EXFAT"]);

                dRatio = DBAccess.ReadDoubleValue(reader["CL_RATIO"]);

                if (fit == 0)
                    seqStmt += dRatio.ToString();
                else
                {

                    string sval = GetCustFieldVal(fit, fat); //  "PC_" + fit.ToString("000");

                    seqStmt += "(" + sval + " * " + dRatio.ToString() + ")";

                    if (seq != 1)
                    {
                        if (op == 3)
                        {
                            if (sWhereClause == "")
                                sWhereClause = " WHERE (" + sval + "<> 0) ";
                            else
                                sWhereClause += " AND (" + sval + "<> 0) ";
                        }
                    }


                }


            }

            if (seqStmt != "")
            {
                seqStmt +=
                    "  FROM EPGP_PROJECT_DEC_VALUES  INNER JOIN  EPGP_PROJECT_TEXT_VALUES ON EPGP_PROJECT_DEC_VALUES.PROJECT_ID = EPGP_PROJECT_TEXT_VALUES.PROJECT_ID ";
                sqlstatements.Add(seqStmt + sWhereClause);
                if (sWhereClause != "")
                    sqlstatements.Add(sErrSQL + sWhereClause);
            }

            reader.Close();

            foreach (string sql in sqlstatements)
            {


                oCommand = new SqlCommand(sql, dba.Connection);
                int lRowsAffected = oCommand.ExecuteNonQuery();
            }

            string sWEServerURL = "";

            sCommand = "SELECT ADM_WE_SERVERURL FROM EPG_ADMIN";

            oCommand = new SqlCommand(sCommand, dba.Connection);
            reader = oCommand.ExecuteReader();


            while (reader.Read())
            {
                sWEServerURL = DBAccess.ReadStringValue(reader["ADM_WE_SERVERURL"]);
            }

            reader.Close();

            //if (sWEServerURL.Length > 0)
            //{
            //    string sXMLRequest;
            //    if (dbaUsers.ExportPIInfo(dba, Projectids, out sXMLRequest) == StatusEnum.rsSuccess)
            //    {

            //XmlNode xNode;
            //if (SendXMLToWorkEngine(dba, sWEServerURL, "UpdateItems", sXMLRequest, out xNode) != StatusEnum.rsSuccess)
            //    goto Exit_Function;

            //if (xNode != null)
            //{
            //    CStruct xResult = new CStruct();
            //    if (xResult.LoadXML(xNode.OuterXml) == false)
            //    {
            //        dba.HandleStatusError(SeverityEnum.Error, "PerformCustomFieldsCalculate", (StatusEnum)99843, "Invalid XML response from WorkEngine WebService");
            //        goto Exit_Function;
            //    }

            //    if (xResult.GetIntAttr("Status") != 0)
            //    {
            //        CStruct xError = xResult.GetSubStruct("Error");
            //        string sError = xError.GetStringAttr("ID") + " : " + xError.GetString("");
            //        dba.HandleStatusError(SeverityEnum.Error, "PerformCustomFieldsCalculate", (StatusEnum)99842, "Invalid XML response from WorkEngine WebService\n\nStatus=" + xResult.GetStringAttr("Status") + "\n\nError=" + sError);
            //        goto Exit_Function;
            //    }
            //}

            //    }
            //}

            //Exit_Function:

            //if (dba != null)
            //{
            //    if (dba.Status != StatusEnum.rsSuccess)
            //    {
            //        HandleDBAccessError("PerformCustomFieldsCalculate", dba);
            //    }
            //}

            return dba.Status;
        }

        private static string GetCustFieldVal(int lfit, int lfat)
        {
            string sfn = "0";
            if (lfat == 203)
                sfn = "PC_" + lfit.ToString("000");
            else if (lfat == 202)
            {
                //sfn = "CAST(PT_" + lfit.ToString("000") + " AS int)";

                //  want: IsNull(cast(Left(PT_003, PatIndex('%[^0-9]%', PT_003+'x' ) - 1 ) as int),0)
                sfn = "IsNull(cast(Left(PT_" + lfit.ToString("000") + ", PatIndex('%[^0-9]%', PT_" +
                      lfit.ToString("000") + "+'x' ) - 1 ) as int),0)";
            }

            return sfn;
        }

    }
}
