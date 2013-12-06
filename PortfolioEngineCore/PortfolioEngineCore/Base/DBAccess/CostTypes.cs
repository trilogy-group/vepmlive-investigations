using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PortfolioEngineCore
{

    public class dbaCostTypes
    {
        public static StatusEnum SelectCalendars(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_BREAKDOWNS ORDER BY CB_ID";
            return dba.SelectData(cmdText, (StatusEnum)99989, out dt);
        }

        public static StatusEnum SelectCustomFields_Cost(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FORMAT=8 ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99988, out dt);
        }

        public static StatusEnum SelectCostTypeFormula(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT CL_CT_ID, CL_OP, CT_NAME FROM EPGP_COST_CALC CC LEFT JOIN EPGP_COST_TYPES CT ON (CC.CL_CT_ID = CT.CT_ID) WHERE CC.CT_ID = @p1 ORDER BY CL_ID";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99986, out dt);
        }

        public static StatusEnum SelectCostTypePostOptions(DBAccess dba, int nCostType, out DataTable dt)
        {
            // When TOSET_MAINKEY=0 it has a different meaning in the Post World so need to exclude those guys
            string cmdText = "SELECT cb.CB_ID, CB_NAME, case When (cvts.CT_ID is null) Then 0  Else 1 End as used FROM EPGP_COST_BREAKDOWNS cb LEFT JOIN EPGP_COST_VALUES_TOSET cvts ON (cvts.CB_ID = cb.CB_ID AND CT_ID = @p1) Where (cvts.TOSET_MAINKEY > 0 Or cvts.TOSET_MAINKEY is NULL) ORDER BY CB_NAME";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99986, out dt);
        }

//        public static StatusEnum DeleteCostType(DBAccess dba, int nCostType, out int lRowsAffected)
//        {
//            string cmdText = "DELETE FROM EPGP_BREAKDOWN_COST_TYPES WHERE CT_ID = @p1";
//            if (dba.DeleteDataById(cmdText, nCostType, (StatusEnum)99985, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

//            cmdText = "DELETE FROM EPGT_COSTVIEW_COST_TYPES WHERE CT_ID = @p1";
//            if (dba.DeleteDataById(cmdText, nCostType, (StatusEnum)99984, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

//            cmdText = "DELETE FROM EPGP_COST_TYPES WHERE CT_ID = @p1";
//            if (dba.DeleteDataById(cmdText, nCostType, (StatusEnum)99983, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;
//Exit_Function:
//            return dba.Status;
//        }

        //public static StatusEnum InsertCostTypes(DBAccess dba, DataTable dt, out int lRowsAffected)
        //{
        //    StatusEnum eStatus = StatusEnum.rsSuccess;
        //    lRowsAffected = 0;
        //    try
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            string cmdText =
        //                  "INSERT INTO EPGP_COST_TYPES "
        //            + " (CT_NAME,CT_EDIT_MODE,INITIAL_LEVEL,CT_CB_ID,CT_ALLOW_NAMED_RATES) "
        //            + " VALUES(@CT_NAME,@CT_EDIT_MODE,@INITIAL_LEVEL,@CT_CB_ID,@CT_ALLOW_NAMED_RATES)";

        //            SqlCommand oCommand = new SqlCommand(cmdText, dba.Connection);

        //            SqlParameter pCT_NAME = oCommand.Parameters.Add("@CT_NAME", SqlDbType.VarChar, 255);
        //            SqlParameter pCT_EDIT_MODE = oCommand.Parameters.Add("@CT_EDIT_MODE", SqlDbType.Int);
        //            SqlParameter pINITIAL_LEVEL = oCommand.Parameters.Add("@INITIAL_LEVEL", SqlDbType.Int);
        //            SqlParameter pCT_CB_ID = oCommand.Parameters.Add("@CT_CB_ID", SqlDbType.Int);
        //            SqlParameter pCT_ALLOW_NAMED_RATES = oCommand.Parameters.Add("@CT_ALLOW_NAMED_RATES", SqlDbType.Int);

        //            foreach (DataRow row in dt.Rows)
        //            {
        //                pCT_NAME.Value = row["CT_NAME"];
        //                pCT_EDIT_MODE.Value = row["CT_EDIT_MODE"];
        //                pINITIAL_LEVEL.Value = row["INITIAL_LEVEL"];
        //                pCT_CB_ID.Value = row["CT_CB_ID"];
        //                pCT_ALLOW_NAMED_RATES.Value = row["CT_ALLOW_NAMED_RATES"];
        //                lRowsAffected += oCommand.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostTypes", (StatusEnum)99981, ex.Message.ToString());
        //    }
        //    return eStatus;
        //}

        public static StatusEnum SelectCostCategories(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT CC.BC_UID, BC_NAME, BC_LEVEL, AC.CT_ID FROM EPGP_COST_CATEGORIES CC LEFT JOIN EPGP_AVAIL_CATEGORIES AC ON (CC.BC_UID = AC.BC_UID and AC.CT_ID = @p1) ORDER BY BC_ID";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99980, out dt);
        }

        public static StatusEnum SelectCustomFieldForCostType(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT TOP 1 * From EPGP_BREAKDOWN_COST_TYPES Where CT_ID = @p1";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99979, out dt);
        }

        public static StatusEnum SelectCostTypeCustomFields(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT FieldName,FieldId,FA_NAME,FA_LOOKUP_UID FROM"
                    + " (VALUES ('Code1', 11801),('Code2', 11802),('Code3', 11803),('Code4', 11804),('Code5', 11805), ('Text1', 11811),('Text2', 11812),('Text3', 11813),('Text4', 11814),('Text5', 11815)) A(FieldName, FieldId)"
                    + " left join EPGP_FIELD_ATTRIBS ON (FieldId = FA_FIELD_ID)";
            return dba.SelectData(cmdText, (StatusEnum)99979, out dt);
        }

        public static StatusEnum SelectInitializedCostTypeCustomFields(DBAccess dba, int nFieldId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_FIELD_ATTRIBS"
            + " left join EPGP_COST_CUSTOM_FIELDS ON (CF_FIELD_ID = FA_FIELD_ID And CT_ID = @p1)"
            + " Where FA_FIELD_ID >= 11801 And FA_FIELD_ID <= 11815";
            return dba.SelectDataById(cmdText, nFieldId, (StatusEnum)99999, out dt);
        }

        public static StatusEnum SelectCostTypeCustomField(DBAccess dba, int nFieldId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_FIELD_ATTRIBS WHERE FA_FIELD_ID = @p1";
            return dba.SelectDataById(cmdText, nFieldId, (StatusEnum)99979, out dt);
        }

        public static StatusEnum SelectBudgetTotalList(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT FA_FIELD_ID,FA_NAME FROM EPGC_FIELD_ATTRIBS WHERE FA_FORMAT=8 and FA_TABLE_ID=203 ORDER BY FA_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99980, out dt);
        }

        public static StatusEnum SelectCostTotalsInfo(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT cb.CB_ID, CB_NAME, BUDGET_TOTAL_FIELD FROM EPGP_COST_BREAKDOWNS cb Left Join EPGP_BREAKDOWN_COST_TYPES ct on ct.CB_ID = cb.CB_ID AND CT_ID = @p1 ORDER BY CB_NAME";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99980, out dt);
        }

        public static StatusEnum DeleteAvailableCostTypeCategories(DBAccess dba, int nCostTypeID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_AVAIL_CATEGORIES WHERE CT_ID = @CT_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteAvailableCostTypeCategories", (StatusEnum)99978, ex.Message.ToString());
            }
            return eStatus;
        }
        public static StatusEnum UpdateCostTypeCustomFieldInfo(DBAccess dba, int nFieldId, string sFieldName, string sFieldDesc,int nLookupID, int nLeafOnly, int nUseFullName, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            StatusEnum eStatus = StatusEnum.rsSuccess;
            sReply = "";
            try
            {
                if (nFieldId > 0)
                {
                    // make sure a field name is entered
                    sFieldName = sFieldName.Trim();
                    if (sFieldName.Length == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "CostTypes.UpdateCostTypeCustomFieldInfo", "Please enter a Field Name");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                    //  a Code field MUST have a Lookup
                    if (nFieldId < 11810 && nLookupID == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "CostTypes.UpdateCostTypeCustomFieldInfo", "You must specify a lookup table for any Code field");
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
                sReply = DBAccess.FormatAdminError("exception", "CostTypes.UpdateCostTypeCustomFieldInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
        public static StatusEnum DeleteCostTypeCustomField(DBAccess dba, int nFieldId, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            StatusEnum eStatus = StatusEnum.rsSuccess;
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
                sReply = DBAccess.FormatAdminError("exception", "CostTypes.DeleteCostTypeCustomFieldInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }


        public static StatusEnum DeleteCostTypeFormula(DBAccess dba, int nCostTypeID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_COST_CALC WHERE CT_ID = @CT_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostTypeFormula", (StatusEnum)99977, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeleteCostTotals(DBAccess dba, int nCostTypeID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_BREAKDOWN_COST_TYPES WHERE CT_ID = @CT_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostTotals", (StatusEnum)99976, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeleteCTCustomFields(DBAccess dba, int nCostTypeID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_COST_CUSTOM_FIELDS WHERE CT_ID = @CT_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostTotals", (StatusEnum)99955, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum InsertAvailableCostTypeCategories(DBAccess dba, int nCostTypeID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_AVAIL_CATEGORIES (CT_ID,BC_UID) VALUES(@CT_ID,@BC_UID)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);

                    SqlParameter pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertAvailableCostTypeCategories", (StatusEnum)99975, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostTotals(DBAccess dba, int nCostTypeID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_BREAKDOWN_COST_TYPES (CT_ID,CB_ID,BUDGET_TOTAL_FIELD) VALUES(@CT_ID,@CB_ID,@BUDGET_TOTAL_FIELD)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);

                    SqlParameter pCB_ID = cmd.Parameters.Add("@CB_ID", SqlDbType.Int);
                    SqlParameter pBUDGET_TOTAL_FIELD = cmd.Parameters.Add("@BUDGET_TOTAL_FIELD", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pCB_ID.Value = row["CB_ID"];
                        pBUDGET_TOTAL_FIELD.Value = row["BUDGET_TOTAL_FIELD"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostTotals", (StatusEnum)99974, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostCustomFields(DBAccess dba, int nCostTypeID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_COST_CUSTOM_FIELDS (CT_ID,CF_ID,CF_FIELD_ID,CF_VISIBLE,CF_EDITABLE,CF_FROZEN,CF_IDENTITY,CF_REQUIRED) VALUES(@CT_ID,@CF_ID,@CF_FIELD_ID,@CF_VISIBLE,@CF_EDITABLE,@CF_FROZEN,@CF_IDENTITY,@CF_REQUIRED)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);

                    SqlParameter pCF_ID = cmd.Parameters.Add("@CF_ID", SqlDbType.Int);
                    SqlParameter pCF_FIELD_ID = cmd.Parameters.Add("@CF_FIELD_ID", SqlDbType.Int);
                    SqlParameter pCF_VISIBLE = cmd.Parameters.Add("@CF_VISIBLE", SqlDbType.Int);
                    SqlParameter pCF_EDITABLE = cmd.Parameters.Add("@CF_EDITABLE", SqlDbType.Int);
                    SqlParameter pCF_FROZEN = cmd.Parameters.Add("@CF_FROZEN", SqlDbType.Int);
                    SqlParameter pCF_IDENTITY = cmd.Parameters.Add("@CF_IDENTITY", SqlDbType.Int);
                    SqlParameter pCF_REQUIRED = cmd.Parameters.Add("@CF_REQUIRED", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pCF_ID.Value = row["CF_FIELD_ID"];
                        pCF_FIELD_ID.Value = row["CF_FIELD_ID"];
                        pCF_VISIBLE.Value = row["CF_VISIBLE"];
                        pCF_EDITABLE.Value = row["CF_EDITABLE"];
                        pCF_FROZEN.Value = row["CF_FROZEN"];
                        pCF_IDENTITY.Value = row["CF_IDENTITY"];
                        pCF_REQUIRED.Value = row["CF_REQUIRED"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostCustomFields", (StatusEnum)99954, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostTypeFormula(DBAccess dba, int nCostTypeID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_COST_CALC (CT_ID,CL_ID,CL_CT_ID,CL_OP) VALUES(@CT_ID,@CL_ID,@CL_CT_ID,@CL_OP)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);

                    SqlParameter pCL_ID = cmd.Parameters.Add("@CL_ID", SqlDbType.Int);
                    SqlParameter pCL_CT_ID = cmd.Parameters.Add("@CL_CT_ID", SqlDbType.Int);
                    SqlParameter pCL_OP = cmd.Parameters.Add("@CL_OP", SqlDbType.Int);

                    int nIndex = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        pCL_ID.Value = nIndex++;
                        pCL_CT_ID.Value = row["CL_CT_ID"];
                        pCL_OP.Value = row["CL_OP"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostTypeFormula", (StatusEnum)99973, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum SelectCostTypes(DBAccess dba, out DataTable dt)
        {
            const string cmdText = "SELECT CT_ID, CT_NAME, CT_EDIT_MODE, CT_CB_ID FROM EPGP_COST_TYPES ORDER BY CT_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
        }

        public static StatusEnum SelectCostTypesForCalc(DBAccess dba, int nThisCT, out DataTable dt)
        {
            const string cmdText = "SELECT CT_ID, CT_NAME FROM EPGP_COST_TYPES Where CT_ID <> @p1 And CT_EDIT_MODE Not In (3,30) ORDER BY CT_NAME";
            return dba.SelectDataById(cmdText, nThisCT, (StatusEnum)99999, out dt);
        }
        public static StatusEnum SelectCostType(DBAccess dba, int nCTID, out DataTable dt)
        {
            const string cmdText = "SELECT * FROM EPGP_COST_TYPES Where CT_ID=@p1";

            return dba.SelectDataById(cmdText, nCTID, (StatusEnum)99999, out dt);
        }
        public static StatusEnum UpdateCostTypeInfo(DBAccess dba, ref int nCTId, string sName, int nEditMode, int nInitialLevel, int nInputCalendar, int nNamedRates, CStruct xAvailCCs, CStruct xCFs, string sFormula, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                // make sure there isn't already another Cost Type with this name
                {
                    sName = sName.Trim();
                    if (sName.Length == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "CostTypes.UpdateCostTypeInfo", "Please enter a Cost Type Name");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                    cmdText = "SELECT CT_ID From EPGP_COST_TYPES WHERE CT_NAME = @p1";
                    DataTable dt;
                    if (dba.SelectDataByName(cmdText, sName, (StatusEnum)99999, out dt) != StatusEnum.rsSuccess)
                        sReply = DBAccess.FormatAdminError("exception", "CostTypes.UpdateCostTypeInfo1", dba.StatusText);
                    else if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nExistingId = DBAccess.ReadIntValue(row["CT_ID"]);
                        if (nExistingId != nCTId)
                        {
                            sReply = DBAccess.FormatAdminError("error", "CostTypes.UpdateCostTypeInfo", "Can't save Cost Type.\nA Cost Type with name '" + sName + "' already exists");
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                    }
                }

                // check the formula for calculated CTs
                if (nEditMode == (int)CTEditMode.ctCalculated || nEditMode == (int)CTEditMode.ctCalculatedCumulative)
                {
                    if (sFormula != "")
                    {
                        sReply = dbaCostTypes.ValidateAndSaveCostTypeFormula(dba, nCTId, ref sFormula, false);
                        if (sReply != "")
                        {
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                    }
                }


                List<CStruct> listAvailCCs = xAvailCCs.GetList("AvailCC");  //new list of Available Cost Categories
                List<CStruct> listCFs = xCFs.GetList("CF");  //new list of Custom Field entries

                if (nCTId == 0)
                {
                    // ADD - no need to figure new CT_ID as IDENTITY
                    cmdText =
                           "INSERT Into EPGP_COST_TYPES (CT_NAME,CT_EDIT_MODE,INITIAL_LEVEL, CT_CB_ID,CT_ALLOW_NAMED_RATES)"
                       + " Values(@pCT_NAME, @pEditMode,@pInitialLevel,@InputCalendar,@pNamedRates)";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pCT_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pEditMode", nEditMode);
                    oCommand.Parameters.AddWithValue("@pInitialLevel", nInitialLevel);
                    oCommand.Parameters.AddWithValue("@InputCalendar", nInputCalendar);
                    oCommand.Parameters.AddWithValue("@pNamedRates", nNamedRates);
                    oCommand.ExecuteNonQuery();
                    dba.GetLastIdentityValue(out nCTId);
                }
                else
                {
                    //  update
                    cmdText = "UPDATE EPGP_COST_TYPES "
                                + " SET CT_NAME=@pCT_NAME,CT_EDIT_MODE=@pEditMode,INITIAL_LEVEL=@pInitialLevel,CT_CB_ID=@InputCalendar,CT_ALLOW_NAMED_RATES=@pNamedRates"
                                + " WHERE CT_ID = @pCT_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pCT_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pEditMode", nEditMode);
                    oCommand.Parameters.AddWithValue("@pInitialLevel", nInitialLevel);
                    oCommand.Parameters.AddWithValue("@InputCalendar", nInputCalendar);
                    oCommand.Parameters.AddWithValue("@pNamedRates", nNamedRates);
                    oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                    oCommand.ExecuteNonQuery();
                }

                if (nCTId > 0)
                { 
                    //  update the available cost categopries or Calculation Formula
                    SqlTransaction transaction = dba.Connection.BeginTransaction();
                    cmdText =
                        "DELETE FROM EPGP_COST_CALC WHERE CT_ID = @pCT_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                    oCommand.ExecuteNonQuery();
                    cmdText =
                        "DELETE FROM EPGP_AVAIL_CATEGORIES WHERE CT_ID = @pCT_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                    oCommand.ExecuteNonQuery();
                    cmdText =
                        "DELETE FROM EPGP_COST_CUSTOM_FIELDS WHERE CT_ID = @pCT_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                    oCommand.ExecuteNonQuery();

                    //  if Calc or Cumul Calc CT then should be some calc entries otherwise should be some avail cc entries
                    if (nEditMode == (int)CTEditMode.ctCalculated || nEditMode == (int)CTEditMode.ctCalculatedCumulative)
                    {
                        // formula now handled below

                        //if (listCalcs.Count > 0)
                        //{
                        //    cmdText =
                        //    "INSERT INTO EPGP_COST_CALC (CT_ID,CL_CT_ID,CL_OP,CL_ID)  VALUES(@pCT_ID,@pCL_CT_ID,@pCL_OP,@pCL_ID)";
                        //    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                        //    oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                        //    SqlParameter pCL_CT_ID = oCommand.Parameters.Add("@pCL_CT_ID", SqlDbType.Int);
                        //    SqlParameter pCL_OP = oCommand.Parameters.Add("@pCL_OP", SqlDbType.Int);
                        //    SqlParameter pCL_ID = oCommand.Parameters.Add("@pCL_ID", SqlDbType.Int);

                        //    int nID = 0;
                        //    foreach (CStruct xC in listAvailCCs)
                        //    {
                        //        pCL_CT_ID.Value = xC.GetIntAttr("CT");
                        //        pCL_OP.Value = xC.GetIntAttr("OP");
                        //        nID++;
                        //        pCL_ID.Value = nID;
                        //        oCommand.ExecuteNonQuery();
                        //    }
                        //}
                    }
                    else 
                    { 
                        if (listAvailCCs.Count > 0)
                        {
                            cmdText =
                            "INSERT INTO EPGP_AVAIL_CATEGORIES (CT_ID,BC_UID)  VALUES(@pCT_ID,@pBC_UID)";
                            oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                            oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                            SqlParameter pBC_UID = oCommand.Parameters.Add("@pBC_UID", SqlDbType.Int);

                            foreach (CStruct xA in listAvailCCs)
                            {
                                pBC_UID.Value = xA.GetIntAttr("BC_UID");
                                oCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    if (listCFs.Count > 0)
                    {
                        cmdText =
                        "INSERT INTO EPGP_COST_CUSTOM_FIELDS (CT_ID,CF_ID,CF_FIELD_ID,CF_EDITABLE,CF_VISIBLE,CF_FROZEN,CF_IDENTITY,CF_REQUIRED)"
                            + " VALUES(@pCT_ID,@pCF_ID,@pCF_FIELD,@pCF_EDITABLE,@pCF_VISIBLE,@pCF_FROZEN,@pCF_IDENTITY,@pCF_REQUIRED)";
                        oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                        oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                        SqlParameter pCF_ID = oCommand.Parameters.Add("@pCF_ID", SqlDbType.Int);
                        SqlParameter pCF_FIELD = oCommand.Parameters.Add("@pCF_FIELD", SqlDbType.Int);
                        SqlParameter pCF_EDITABLE = oCommand.Parameters.Add("@pCF_EDITABLE", SqlDbType.Int);
                        SqlParameter pCF_VISIBLE = oCommand.Parameters.Add("@pCF_VISIBLE", SqlDbType.Int);
                        SqlParameter pCF_FROZEN = oCommand.Parameters.Add("@pCF_FROZEN", SqlDbType.Int);
                        SqlParameter pCF_IDENTITY = oCommand.Parameters.Add("@pCF_IDENTITY", SqlDbType.Int);
                        SqlParameter pCF_REQUIRED = oCommand.Parameters.Add("@pCF_REQUIRED", SqlDbType.Int);

                        foreach (CStruct xC in listCFs)
                        {
                            pCF_ID.Value = xC.GetIntAttr("ID");
                            pCF_FIELD.Value = xC.GetIntAttr("ID");
                            pCF_EDITABLE.Value = xC.GetIntAttr("Editable");
                            pCF_VISIBLE.Value = xC.GetIntAttr("Visible");
                            pCF_FROZEN.Value = xC.GetIntAttr("Frozen");
                            pCF_IDENTITY.Value = xC.GetIntAttr("Identity");
                            pCF_REQUIRED.Value = xC.GetIntAttr("Required");
                            oCommand.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();

                    // save the formula for Calculated CTs - outside transaction but we checked it above so no reason to fail
                    if (nEditMode == (int)CTEditMode.ctCalculated || nEditMode == (int)CTEditMode.ctCalculatedCumulative)
                    {
                        if (sFormula != "")
                        {
                            sReply = dbaCostTypes.ValidateAndSaveCostTypeFormula(dba, nCTId, ref sFormula, true);
                            if (sReply != "")
                            {
                                return StatusEnum.rsRequestCannotBeCompleted;
                            }
                        }
                    }
                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostTypes.UpdateCostTypeInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
        public static StatusEnum UpdateCostTypeSecurityInfo(DBAccess dba, int nCTId, CStruct xSGs, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                List<CStruct> listSGs = xSGs.GetList("SG");  //new list of Security Group entries

                if (nCTId > 0)
                {
                    SqlTransaction transaction = dba.Connection.BeginTransaction();
                    cmdText =
                        "DELETE FROM EPGP_DATA_SECURITY WHERE DS_CONTEXT=2 And DS_UID = @pCT_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                    oCommand.ExecuteNonQuery();

                    if (listSGs.Count > 0)
                    {
                        cmdText =
                        "INSERT INTO EPGP_DATA_SECURITY (DS_CONTEXT,DS_UID,GROUP_ID,DS_READ,DS_EDIT)"
                            + " VALUES(2,@pCT_ID,@pGROUP_ID,@pDS_READ,@pDS_EDIT)";
                        oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                        oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                        SqlParameter pGROUP_ID = oCommand.Parameters.Add("@pGROUP_ID", SqlDbType.Int);
                        SqlParameter pDS_READ = oCommand.Parameters.Add("@pDS_READ", SqlDbType.Int);
                        SqlParameter pDS_EDIT = oCommand.Parameters.Add("@pDS_EDIT", SqlDbType.Int);

                        foreach (CStruct xC in listSGs)
                        {
                            pGROUP_ID.Value = xC.GetIntAttr("ID");
                            pDS_READ.Value = xC.GetIntAttr("Readable");
                            pDS_EDIT.Value = xC.GetIntAttr("Editable");
                            oCommand.ExecuteNonQuery();
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
        public static StatusEnum UpdateCostTotalsInfo(DBAccess dba, int nCTId, DataTable dt, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                if (nCTId > 0 && dt != null)
                {
                    SqlTransaction transaction = dba.Connection.BeginTransaction();
                    cmdText =
                        "DELETE FROM EPGP_BREAKDOWN_COST_TYPES WHERE CT_ID = @pCT_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                    oCommand.ExecuteNonQuery();

                    if (dt.Rows.Count > 0)
                    {
                        cmdText =
                        "INSERT INTO EPGP_BREAKDOWN_COST_TYPES (CT_ID,CB_ID,BUDGET_TOTAL_FIELD)"
                            + " VALUES(@pCT_ID,@pCB_ID,@pCF)";
                        oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                        oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                        SqlParameter pCB_ID = oCommand.Parameters.Add("@pCB_ID", SqlDbType.Int);
                        SqlParameter pCF = oCommand.Parameters.Add("@pCF", SqlDbType.Int);

                        foreach (DataRow row in dt.Rows)
                        {
                            pCB_ID.Value = DBAccess.ReadIntValue(row["CB_ID"]);
                            int nCField = DBAccess.ReadIntValue(row["BUDGET_TOTAL_FIELD"]);
                            if (nCField > 0)
                            {
                                pCF.Value = nCField;
                                oCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostTypes.UpdateCostTotalsInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }
        public static StatusEnum UpdatePostOptionsInfo(DBAccess dba, int nCTId, string sCalendars, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            SqlDataReader reader = null;
            sReply = "";
            try
            {
                if (nCTId > 0)
                {
                    // get the EDIT_MODE for the Cost Type
                    cmdText = "SELECT CT_EDIT_MODE FROM EPGP_COST_TYPES  WHERE CT_ID = @pCT_ID";
                    int lEMode = 0;
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                    reader = oCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        lEMode = DBAccess.ReadIntValue(reader["CT_EDIT_MODE"]);

                        if (lEMode != 9 && lEMode != 41 && lEMode != 5)  // Resource Plans and WE Timesheet Actuals and Scheduled Work
                        {
                            sReply = DBAccess.FormatAdminError("error", "CostTypes.UpdatePostOptionsInfo", "Post Options not valid for this Cost Type");
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                    }
                    reader.Close();
                    reader = null;

                    int lMainKey = 1;                   // 1 = Resource Plans
                    if (lEMode == 41) lMainKey = 31;    //31 = WE Timesheet Actuals

                    SqlTransaction transaction = dba.Connection.BeginTransaction();
                    cmdText = "DELETE FROM EPGP_COST_VALUES_TOSET WHERE TOSET_MAINKEY > 0 And CT_ID = @pCT_ID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                    oCommand.ExecuteNonQuery();

                    if (sCalendars.Length > 0)
                    {
                        cmdText = "INSERT INTO EPGP_COST_VALUES_TOSET (TOSET_MAINKEY,CT_ID,CB_ID,CV_TIMESTAMP)"
                                    + " VALUES(@pMainKey,@pCT_ID,@pCB_ID,GETDATE())";
                        oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                        oCommand.Parameters.AddWithValue("@pMainKey", lMainKey);
                        oCommand.Parameters.AddWithValue("@pCT_ID", nCTId);
                        SqlParameter pCB_ID = oCommand.Parameters.Add("@pCB_ID", SqlDbType.Int);

                        string[] cals = sCalendars.Split(',');
                        foreach (string sentry in cals)
                        {
                            int ientry;
                            int.TryParse(sentry, out ientry);
                            if (ientry > 0)
                            {
                                pCB_ID.Value = ientry;
                                oCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostTypes.UpdatePostOptionsInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum DeleteCostType(DBAccess dba, int nCTId, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                // check if CT can be deleted
                string sdeletemessage;
                if (CanDeleteCostType(dba, nCTId, out sdeletemessage) != StatusEnum.rsSuccess) return dba.Status;
                if (sdeletemessage.Length > 0)
                {
                    sReply = DBAccess.FormatAdminError("error", "CostTypes.DeleteCostType", "This Cost Type cannot be deleted, it is currently used as follows:" + "\n" + "\n" + sdeletemessage);
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                // get info for group to be deleted
                {
                    cmdText = "SELECT CT_ID, CT_NAME FROM EPGP_COST_TYPES Where CT_ID=@p1";
                    DataTable dt;
                    dba.SelectDataById(cmdText, nCTId, (StatusEnum)99999, out dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nCT = DBAccess.ReadIntValue(row["CT_ID"]);
                    }
                    else
                    {
                        sReply = DBAccess.FormatAdminError("error", "CostTypes.DeleteCostType", "Can't delete Cost Type, Cost Type not found");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                }

                //   clear if used in Cost Views
                cmdText = "DELETE FROM EPGT_COSTVIEW_COST_TYPES WHERE CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();
                cmdText = "UPDATE EPGT_COSTVIEW_COST_TYPES SET CT_ID_COMPARE = 0 WHERE CT_ID_COMPARE = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();

                //   Delete Cost Total specs for all Cost Types using this CT
                cmdText = "DELETE FROM EPGP_BREAKDOWN_COST_TYPES WHERE CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();

                //   Delete Cost Values for all Cost Types using this CT
                cmdText = "DELETE FROM EPGP_COST_VALUES WHERE CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();
                cmdText = "DELETE FROM EPGP_COST_DETAILS WHERE CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();
                cmdText = "DELETE FROM EPGP_DETAIL_VALUES WHERE CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();
                cmdText = "DELETE FROM EPGP_PROJECT_CT_STATUS WHERE CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();

                //   clear Avail Categories
                cmdText = "DELETE FROM EPGP_AVAIL_CATEGORIES WHERE CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();

                //    clear any Calc entries
                cmdText = "DELETE FROM EPGP_COST_CALC WHERE CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();
                cmdText = "DELETE FROM EPGP_COST_CALC WHERE CL_CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();

                // Delete the Cost Type itself
                cmdText = "DELETE FROM EPGP_COST_TYPES WHERE CT_ID = @pCTld";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pCTld", nCTId);
                oCommand.ExecuteNonQuery();

                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostTypes.DeleteCostType", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum CanDeleteCostType(DBAccess dba, int nCTId, out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                // check if CT can be deleted
                oCommand = new SqlCommand("EPG_SP_ReadUsedCT", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@CTID", nCTId);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    sReply += DBAccess.ReadStringValue(reader["Type"]) + ": ";
                    sReply += DBAccess.ReadStringValue(reader["Name"]) + "\n";
                }
                reader.Close();
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostTypes.CanDeleteCostType", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        private class ItemRow
        {
            public bool hasOp = false;
            public bool hasField = false;
            public bool hasConstant = false;
            public int fieldId = 0;
            public int opId = 0;
            public string value = "";
        }

        public static string ValidateAndSaveCostTypeFormula(DBAccess dba, int nCTId, ref string sFormula, bool bSave = false)
        {
            string sError = "";
            sFormula = sFormula.Trim();
            if (sFormula == string.Empty)
                goto Exit_Function;

            // read in the valid operands (other than constants)
            DataTable dt;
            dbaCostTypes.SelectCostTypesForCalc(dba, nCTId, out dt);
            // split formula on operators but keep operators in array
            string[] arrFormula = Regex.Split(sFormula, @"([-+])");
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
                            }
                            itemRows.Add(itemRow);
                            opCount++;
                            if (opCount > decCount + fieldCount)
                            {
                                sError = DBAccess.FormatAdminError("error", "dbaCostTypes.ValidateAndSaveCostTypeFormula", "Too many operators");
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
                                    if (DBAccess.ReadStringValue(row["CT_NAME"]) == arrFormula[i])
                                    {
                                        int nFoundFieldId = DBAccess.ReadIntValue(row["CT_ID"]);
                                        itemRow.hasField = true;
                                        itemRow.fieldId = nFoundFieldId;
                                        itemRows.Add(itemRow);
                                        fieldCount++;
                                        break;
                                    }
                                }
                                if (itemRow.hasField == false)
                                {
                                    sError = DBAccess.FormatAdminError("error", "dbaCostTypes.ValidateAndSaveCostTypeFormula", "Unknown Cost Type name: " + itemRow.value);
                                    goto Exit_Function;
                                }
                            }
                            else
                            {
                                decimal dec;
                                if (decimal.TryParse(arrFormula[i], out dec))
                                {
                                    itemRow.hasConstant = true;
                                    itemRows.Add(itemRow);
                                    decCount++;
                                }
                                else
                                {
                                    sError = DBAccess.FormatAdminError("error", "dbaCustomdbaCostTypesFields.ValidateAndSaveCostTypeFormula", "invalid value: " + itemRow.value);
                                    goto Exit_Function;
                                }
                            }
                            if (opCount + 1 < decCount + fieldCount)
                            {
                                sError = DBAccess.FormatAdminError("error", "dbaCostTypes.ValidateAndSaveCostTypeFormula", "Too few operators");
                                goto Exit_Function;
                            }
                            break;
                    }
                }
            }
            if (opCount >= decCount + fieldCount)
            {
                sError = DBAccess.FormatAdminError("error", "dbaCostTypes.ValidateAndSaveCostTypeFormula", "Formula cannot start or finish with an operator");
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
                                nInc = 3;
                                bRowComplete = true;
                            }
                            else if (arrItemRows[i].hasConstant && arrItemRows[i + 1].value == "*" && arrItemRows[i + 2].hasField)
                            {
                                itemRow.fieldId = arrItemRows[i + 2].fieldId;
                                nInc = 3;
                                bRowComplete = true;
                            }
                        }
                        if (bRowComplete == false)
                        {
                            if (arrItemRows[i].hasField)
                            {
                                itemRow.fieldId = arrItemRows[i].fieldId;
                                bRowComplete = true;
                            }
                            else if (arrItemRows[i].hasConstant)
                            {
                                itemRow.fieldId = 0;
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
                dbaCostTypes.DeleteCostTypeFormula(dba, nCTId, out  lRowsAffected);

                const string sCommand = "INSERT INTO  EPGP_COST_CALC (CT_ID, CL_ID, CL_CT_ID, CL_OP) " +
                            "VALUES(@CT_ID, @CL_ID, @CL_CT_ID, @CL_OP)";

                SqlCommand oCmdCL = new SqlCommand(sCommand, dba.Connection);
                SqlParameter ct_id = oCmdCL.Parameters.Add("@CT_ID", SqlDbType.Int);
                SqlParameter cl_id = oCmdCL.Parameters.Add("@CL_ID", SqlDbType.Int);
                SqlParameter cl_ct_id = oCmdCL.Parameters.Add("@CL_CT_ID", SqlDbType.Int);
                SqlParameter cl_op = oCmdCL.Parameters.Add("@CL_OP", SqlDbType.Int);

                int seq = 0;
                foreach (ItemRow itemRow in itemRows)
                {
                    ct_id.Value = nCTId;
                    cl_id.Value = ++seq;
                    cl_ct_id.Value = itemRow.fieldId;
                    cl_op.Value = itemRow.opId;
                    oCmdCL.ExecuteNonQuery();
                }
            }

        Exit_Function:
            return sError;
        }
    }
}

