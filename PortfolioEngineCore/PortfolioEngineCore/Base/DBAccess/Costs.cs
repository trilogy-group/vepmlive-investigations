using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{

    public class dbaEditCosts
    {
        public static StatusEnum SelectProjectIDByExtUID(DBAccess dba, string sExtUID, out int nProjectID)
        {
            string cmdText = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID = @PROJECT_EXT_UID";
            StatusEnum eStatus = StatusEnum.rsSuccess;
            nProjectID = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.Add("@PROJECT_EXT_UID", SqlDbType.VarChar, 128).Value = sExtUID;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nProjectID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectProjectIDByExtUID", (StatusEnum)99999, ex.Message.ToString());
            }
            return eStatus;
        }
        
        public static StatusEnum SelectPIs(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT PROJECT_ID, PROJECT_NAME FROM EPGP_PROJECTS ORDER BY PROJECT_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99972, out dt);
        }

        public static StatusEnum SelectViews(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT VIEW_UID, VIEW_NAME FROM EPGT_COSTVIEW_DISPLAY ORDER BY VIEW_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99971, out dt);
        }

        public static StatusEnum SelectCostTypesByView(DBAccess dba, int nViewUID, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_TYPES CT LEFT JOIN EPGT_COSTVIEW_COST_TYPES CV ON (CT.CT_ID = CV.CT_ID AND VIEW_UID = " + nViewUID.ToString() + ") WHERE CT.CT_ID IN (SELECT CT_ID FROM EPGT_COSTVIEW_COST_TYPES WHERE VIEW_UID = " + nViewUID.ToString() + ") ORDER BY CV.VT_ID";
            return dba.SelectData(cmdText, (StatusEnum)99970, out dt);
        }

        public static StatusEnum SelectCostType(DBAccess dba, int nCostTypeID, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_TYPES WHERE CT_ID = @p1";
            return dba.SelectDataById(cmdText, nCostTypeID, (StatusEnum)99953, out dt);
        }

        public static StatusEnum SelectCostTypeOperations(DBAccess dba, int nCostTypeID, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_COST_CALC WHERE CT_ID = @p1 ORDER BY CL_ID";
            return dba.SelectDataById(cmdText, nCostTypeID, (StatusEnum)99952, out dt);
        }

        public static StatusEnum SelectNamedRateItems(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_RATES ORDER BY RT_ID, RT_LEVEL";
            return dba.SelectData(cmdText, (StatusEnum)99951, out dt);
        }

        public static StatusEnum SelectNamedRateValues(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_RATE_VALUES ORDER BY RT_UID, RT_EFFECTIVE_DATE DESC";
            return dba.SelectData(cmdText, (StatusEnum)99950, out dt);
        }

        public static StatusEnum SelectCalendarPeriods(DBAccess dba, int nCalendarID, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_PERIODS WHERE CB_ID=@p1 ORDER BY PRD_ID";
            return dba.SelectDataById(cmdText, nCalendarID, (StatusEnum)99969, out dt);
        }

        public static StatusEnum SelectViewCalendarInfo(DBAccess dba, int nViewUID, out int nCalendarID, out int nFirstPeriod, out int nLastPeriod)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            string s = string.Empty;
            nCalendarID = -1;
            nFirstPeriod = Int32.MinValue;
            nLastPeriod = Int32.MaxValue;
            bool bIsNull;
            try
            {
                string cmdText = "SELECT * FROM EPGT_COSTVIEW_DISPLAY WHERE VIEW_UID=@p1";
                DataTable dt;
                if (dba.SelectDataById(cmdText, nViewUID, (StatusEnum)99968, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    nCalendarID = (int)row["VIEW_COST_BREAKDOWN"];
                    int n = DBAccess.ReadIntValue(row["VIEW_FIRST_PERIOD"], out bIsNull);
                    if (bIsNull == false && n > 0) nFirstPeriod = n;
                    n = DBAccess.ReadIntValue(row["VIEW_LAST_PERIOD"], out bIsNull);
                    if (bIsNull == false && n > 0) nLastPeriod = n;
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectViewCalendarInfo", (StatusEnum)99967, ex.Message.ToString());
            }
            return eStatus;
Status_Error:
            return dba.Status;
        }

        public static StatusEnum SelectCostCategories(DBAccess dba, int nCostType, out DataTable dt)
        {
            string cmdText = "SELECT CC.BC_UID, CC.BC_ID, BC_NAME, BC_LEVEL, BC_UOM, AC.CT_ID FROM EPGP_COST_CATEGORIES CC LEFT JOIN EPGP_AVAIL_CATEGORIES AC ON (CC.BC_UID = AC.BC_UID and AC.CT_ID = @p1) ORDER BY BC_ID";
            return dba.SelectDataById(cmdText, nCostType, (StatusEnum)99949, out dt);
        }

        public static StatusEnum SelectPIDetails(DBAccess dba, int nProjectID, out DataTable dt)
        {
            string cmdText = 
                "SELECT PROJECT_CHECKEDOUT,PROJECT_CHECKEDOUT_BY, PROJECT_CHECKEDOUT_DATE, EPG_RESOURCES.RES_NAME" +
                " FROM EPGP_PROJECTS" + 
                " LEFT OUTER JOIN EPG_RESOURCES ON EPGP_PROJECTS.PROJECT_CHECKEDOUT_BY = EPG_RESOURCES.WRES_ID" +
                " WHERE PROJECT_ID = @p1";
            return dba.SelectDataById(cmdText, nProjectID, (StatusEnum)99949, out dt);
        }

        public static StatusEnum SelectCostCategoryData(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                //string cmdText =
                //      "SELECT BC.*, CD.* "
                //    + "FROM EPGP_COST_CATEGORIES BC "
                //    + "left JOIN EPGP_COST_DETAILS CD ON (BC.BC_UID = null) "
                //    + "union "
                //    + "SELECT BC.*, CD.* "
                //    + "FROM EPGP_COST_CATEGORIES BC "
                //    + "left JOIN EPGP_COST_DETAILS CD ON (BC.BC_UID = CD.BC_UID) "
                //    + "WHERE CD.CB_ID = @p1 AND CD.CT_ID = @p1 AND CD.PROJECT_ID = @p1 "
                //    + "ORDER BY BC_ID ";
                //string cmdText =
                //      "SELECT BC.*, CD.BC_UID as Used,OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05 "
                //    + "FROM EPGP_COST_CATEGORIES BC "
                //    + "inner JOIN EPGP_AVAIL_CATEGORIES AC ON (BC.BC_UID = AC.BC_UID AND  AC.CT_ID = @p1) "
                //    + "left JOIN EPGP_COST_DETAILS CD ON (BC.BC_UID = CD.BC_UID AND CD.CT_ID = @p1 AND CD.PROJECT_ID = @p1 AND CD.CB_ID = @p1) "
                //    + "ORDER BY BC_ID ";
                string cmdText =
                      "SELECT BC.*,CD.BC_UID as Used,CD.BC_SEQ as Seq,CD.RT_UID,R.RT_NAME,LV1.LV_VALUE as LV_01, LV2.LV_VALUE as LV_02, LV3.LV_VALUE as LV_03, LV4.LV_VALUE as LV_04, LV5.LV_VALUE as LV_05, OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05 "
                    + "FROM EPGP_COST_CATEGORIES BC "
                    + "inner JOIN EPGP_AVAIL_CATEGORIES AC ON (BC.BC_UID = AC.BC_UID AND AC.CT_ID = @p1) "
                    + "left JOIN EPGP_COST_DETAILS CD ON (BC.BC_UID = CD.BC_UID AND CD.CT_ID = @p2 AND CD.PROJECT_ID = @p3 AND CD.CB_ID = @p4) "
                    + "left JOIN EPG_RATES R ON (R.RT_UID = CD.RT_UID) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV1 ON (LV1.LV_UID = OC_01) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV2 ON (LV2.LV_UID = OC_02) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV3 ON (LV3.LV_UID = OC_03) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV4 ON (LV4.LV_UID = OC_04) "
                    + "left JOIN EPGP_LOOKUP_VALUES LV5 ON (LV5.LV_UID = OC_05) "
                    + "ORDER BY BC_ID,CD.BC_SEQ ";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                //cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                cmd.Parameters.AddWithValue("@p1", nCostTypeID);
                cmd.Parameters.AddWithValue("@p2", nCostTypeID);
                cmd.Parameters.AddWithValue("@p3", nProjectID);
                cmd.Parameters.AddWithValue("@p4", nCalendarID);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectCostCategoryData", (StatusEnum)99966, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum SelectCostCustomFields(DBAccess dba, int nCostTypeId, out DataTable dt)
        {
            //string cmdText = "SELECT * FROM EPGP_COST_CUSTOM_FIELDS ORDER BY CT_ID, CF_ID";
            string cmdText = "SELECT * FROM EPGP_COST_CUSTOM_FIELDS "
                    + "INNER JOIN EPGP_FIELD_ATTRIBS ON (FA_FIELD_ID = CF_FIELD_ID) "
                    + "WHERE CT_ID = @p1 "
                    + "ORDER BY CT_ID, CF_ID ";
            return dba.SelectDataById(cmdText, nCostTypeId, (StatusEnum)99948, out dt);
        }

        public static StatusEnum SelectLookup(DBAccess dba, int nLookupId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID";
            return dba.SelectDataById(cmdText, nLookupId, (StatusEnum)99947, out dt);
        }

        public static StatusEnum SelectPeriodsRates(DBAccess dba, int nCalendarID, out DataTable dt)
        {
            string cmdText =
                "SELECT * "
              + "FROM EPGP_COST_BREAKDOWN_ATTRIBS "
              + "WHERE CB_ID=@p1 "
              + "ORDER BY BA_BC_UID, BA_PRD_ID";
            return dba.SelectDataById(cmdText, nCalendarID, (StatusEnum)99965, out dt);
        }

        public static StatusEnum SelectPeriodsCostDetailsValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                string cmdText =
                    "SELECT DISTINCT CD.*, BD_PERIOD,BD_VALUE,BD_COST "
                  + "FROM EPGP_COST_DETAILS CD "
                  + "LEFT JOIN EPGP_DETAIL_VALUES DV ON (DV.CB_ID = CD.CB_ID AND DV.CT_ID = CD.CT_ID AND DV.PROJECT_ID = CD.PROJECT_ID AND DV.BC_UID = CD.BC_UID AND DV.BC_SEQ = CD.BC_SEQ) "
                  + "WHERE CD.CB_ID=@p1 AND CD.CT_ID=@p2 AND CD.PROJECT_ID=@p3 "
                  + "ORDER BY CD.CB_ID, CD.CT_ID, CD.PROJECT_ID, CD.BC_UID, CD.BC_SEQ, BD_PERIOD";

                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                cmd.Parameters.AddWithValue("@p1", nCalendarID);
                cmd.Parameters.AddWithValue("@p2", nCostTypeID);
                cmd.Parameters.AddWithValue("@p3", nProjectID);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectPeriodsCostDetailsValues", (StatusEnum)99964, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum SelectPeriodsCostValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dt = null;
            try
            {
                string cmdText =
                    "SELECT * FROM EPGP_COST_VALUES "
                  + "WHERE CB_ID=@CB_ID AND CT_ID=@CT_ID AND PROJECT_ID=@PROJECT_ID "
                  + "ORDER BY CB_ID, CT_ID, PROJECT_ID, BC_UID, BD_PERIOD";

                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "SelectPeriodsCostValues", (StatusEnum)99946, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeleteCostDetailValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "DELETE FROM EPGP_DETAIL_VALUES WHERE PROJECT_ID = @PROJECT_ID AND CT_ID = @CT_ID AND CB_ID = @CB_ID AND BC_UID = @BC_UID AND BC_SEQ = @BC_SEQ AND BD_PERIOD = @BD_PERIOD";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                    cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);

                    SqlParameter pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);
                    SqlParameter pBC_SEQ = cmd.Parameters.Add("@BC_SEQ", SqlDbType.Int);
                    SqlParameter pBD_PERIOD = cmd.Parameters.Add("@BD_PERIOD", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        pBC_SEQ.Value = row["BC_SEQ"];
                        pBD_PERIOD.Value = row["BD_PERIOD"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetailValues", (StatusEnum)99963, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostDetails(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_COST_DETAILS (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_SEQ,RT_UID,OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05) VALUES(@CB_ID,@CT_ID,@PROJECT_ID,@BC_UID,@BC_SEQ,@RT_UID,@OC_01,@OC_02,@OC_03,@OC_04,@OC_05,@TEXT_01,@TEXT_02,@TEXT_03,@TEXT_04,@TEXT_05)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                    cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);

                    SqlParameter pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);
                    SqlParameter pBC_SEQ = cmd.Parameters.Add("@BC_SEQ", SqlDbType.Int);
                    SqlParameter pRT_UID = cmd.Parameters.Add("@RT_UID", SqlDbType.Int);
                    SqlParameter pOC_01 = cmd.Parameters.Add("@OC_01", SqlDbType.Int);
                    SqlParameter pOC_02 = cmd.Parameters.Add("@OC_02", SqlDbType.Int);
                    SqlParameter pOC_03 = cmd.Parameters.Add("@OC_03", SqlDbType.Int);
                    SqlParameter pOC_04 = cmd.Parameters.Add("@OC_04", SqlDbType.Int);
                    SqlParameter pOC_05 = cmd.Parameters.Add("@OC_05", SqlDbType.Int);
                    SqlParameter pTEXT_01 = cmd.Parameters.Add("@TEXT_01", SqlDbType.VarChar, 255);
                    SqlParameter pTEXT_02 = cmd.Parameters.Add("@TEXT_02", SqlDbType.VarChar, 255);
                    SqlParameter pTEXT_03 = cmd.Parameters.Add("@TEXT_03", SqlDbType.VarChar, 255);
                    SqlParameter pTEXT_04 = cmd.Parameters.Add("@TEXT_04", SqlDbType.VarChar, 255);
                    SqlParameter pTEXT_05 = cmd.Parameters.Add("@TEXT_05", SqlDbType.VarChar, 255);

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        pBC_SEQ.Value = row["BC_SEQ"];
                        pRT_UID.Value = row["RT_UID"];
                        pOC_01.Value = row["OC_01"];
                        pOC_02.Value = row["OC_02"];
                        pOC_03.Value = row["OC_03"];
                        pOC_04.Value = row["OC_04"];
                        pOC_05.Value = row["OC_05"];
                        pTEXT_01.Value = row["TEXT_01"];
                        pTEXT_02.Value = row["TEXT_02"];
                        pTEXT_03.Value = row["TEXT_03"];
                        pTEXT_04.Value = row["TEXT_04"];
                        pTEXT_05.Value = row["TEXT_05"];
                        cmd.ExecuteNonQuery();
                    }

                    cmdText =
                        "INSERT INTO EPGP_PROJECT_CT_STATUS (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_STATUS) VALUES(@CB_ID,@CT_ID,@PROJECT_ID,@BC_UID,1)";
                    cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                    cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);

                    pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostDetails", (StatusEnum)99945, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        public static StatusEnum InsertCostDetailValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, DataTable dt)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            {
                try
                {
                    string cmdText =
                        "INSERT INTO EPGP_DETAIL_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_SEQ,BD_PERIOD,BD_VALUE,BD_COST) VALUES(@CB_ID,@CT_ID,@PROJECT_ID,@BC_UID,@BC_SEQ,@BD_PERIOD,@BD_VALUE,@BD_COST)";
                    SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                    cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                    cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);

                    SqlParameter pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);
                    SqlParameter pBC_SEQ = cmd.Parameters.Add("@BC_SEQ", SqlDbType.Int);
                    SqlParameter pBD_PERIOD = cmd.Parameters.Add("@BD_PERIOD", SqlDbType.Int);
                    SqlParameter pBD_VALUE = cmd.Parameters.Add("@BD_VALUE", SqlDbType.Decimal);
                    SqlParameter pBD_COST = cmd.Parameters.Add("@BD_COST", SqlDbType.Decimal);

                    pBD_VALUE.Precision = 25;
                    pBD_VALUE.Scale = 6;
                    pBD_COST.Precision = 25;
                    pBD_COST.Scale = 6;

                    foreach (DataRow row in dt.Rows)
                    {
                        pBC_UID.Value = row["BC_UID"];
                        pBC_SEQ.Value = row["BC_SEQ"];
                        pBD_PERIOD.Value = row["BD_PERIOD"];
                        pBD_VALUE.Value = row["BD_VALUE"];
                        pBD_COST.Value = row["BD_COST"];
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCostDetailValues", (StatusEnum)99962, ex.Message.ToString());
                }
            }
            return eStatus;
        }

        //sCommand = "UPDATE EPGP_PROJECTS SET PROJECT_CHECKEDOUT = 1, PROJECT_CHECKEDOUT_BY = " & Format(lWResID) & _
        //           ", PROJECT_CHECKEDOUT_DATE = Getdate() WHERE PROJECT_ID = " & Format(lPI)
                   
        //Call oDataAccess.ExecuteSQL(oRecordset, sCommand, 8512, eStatus)

        public static StatusEnum CheckoutPI(DBAccess dba, int nProjectID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "UPDATE EPGP_PROJECTS SET PROJECT_CHECKEDOUT = 1, PROJECT_CHECKEDOUT_BY = @PROJECT_CHECKEDOUT_BY, PROJECT_CHECKEDOUT_DATE = @PROJECT_CHECKEDOUT_DATE"
                 + " WHERE PROJECT_ID = @PROJECT_ID AND (PROJECT_CHECKEDOUT = 0 OR PROJECT_CHECKEDOUT IS NULL OR PROJECT_CHECKEDOUT_BY = @PROJECT_CHECKEDOUT_BY2)";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                cmd.Parameters.AddWithValue("@PROJECT_CHECKEDOUT_BY", dba.UserWResID);
                cmd.Parameters.AddWithValue("@PROJECT_CHECKEDOUT_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@PROJECT_CHECKEDOUT_BY2", dba.UserWResID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "CheckoutPI", (StatusEnum)99999, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum CheckinPI(DBAccess dba, int nProjectID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "UPDATE EPGP_PROJECTS SET PROJECT_CHECKEDOUT = 0 WHERE PROJECT_ID = @PROJECT_ID AND PROJECT_CHECKEDOUT = 1 AND PROJECT_CHECKEDOUT_BY = @PROJECT_CHECKEDOUT_BY";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@PROJECT_CHECKEDOUT_BY", dba.UserWResID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "CheckinPI", (StatusEnum)99999, ex.Message.ToString());
            }
            return eStatus;
        }

        //public static StatusEnum DeleteCostDetailsAndValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, string sDeletedIds, out int lRowsAffected)
        //{
        //    StatusEnum eStatus = StatusEnum.rsSuccess;
        //    lRowsAffected = 0;
        //    {
        //        try
        //        {
        //            string cmdText =
        //                "DELETE FROM EPGP_COST_DETAILS WHERE PROJECT_ID = @p1 AND CT_ID = @p1 AND CB_ID = @p1 AND BC_UID IN (" + sDeletedIds + ")";
        //            SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
        //            cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
        //            cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
        //            cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
        //            lRowsAffected = cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetailsAndValues1", (StatusEnum)99944, ex.Message.ToString());
        //        }
        //    }
        //    if (eStatus == StatusEnum.rsSuccess)
        //    {
        //        try
        //        {
        //            string cmdText =
        //                "DELETE FROM EPGP_DETAIL_VALUES WHERE PROJECT_ID = @p1 AND CT_ID = @p1 AND CB_ID = @p1 AND BC_UID IN (" + sDeletedIds + ")";
        //            SqlCommand cmd = new SqlCommand(cmdText, dba.Connection);
        //            cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
        //            cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
        //            cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
        //            lRowsAffected = cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetailsAndValues2", (StatusEnum)99943, ex.Message.ToString());
        //        }
        //    }
        //    return eStatus;
        //}

        public static StatusEnum DeleteCostDetails(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                    "DELETE FROM EPGP_COST_DETAILS WHERE PROJECT_ID = @PROJECT_ID AND CT_ID = @CT_ID AND CB_ID = @CB_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                lRowsAffected = cmd.ExecuteNonQuery();

                cmdText =
                    "DELETE FROM EPGP_PROJECT_CT_STATUS WHERE PROJECT_ID = @PROJECT_ID AND CT_ID = @CT_ID AND CB_ID = @CB_ID";
                cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                cmd.ExecuteNonQuery();
            
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetails", (StatusEnum)99961, ex.Message.ToString());
            }
            return eStatus;
        }

        public static StatusEnum DeleteCostDetailsValues(DBAccess dba, int nCalendarID, int nCostTypeID, int nProjectID, out int lRowsAffected)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            lRowsAffected = 0;
            try
            {
                string cmdText =
                        "DELETE FROM EPGP_DETAIL_VALUES WHERE PROJECT_ID = @PROJECT_ID AND CT_ID = @CT_ID AND CB_ID = @CB_ID";
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                cmd.Parameters.AddWithValue("@PROJECT_ID", nProjectID);
                cmd.Parameters.AddWithValue("@CT_ID", nCostTypeID);
                cmd.Parameters.AddWithValue("@CB_ID", nCalendarID);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "DeleteCostDetailsValues", (StatusEnum)99960, ex.Message.ToString());
            }
            return eStatus;
        }
        public static StatusEnum GetProjectInfo(DBAccess dba, int nProjectID, out DateTime dtStart, out DateTime dtFinish)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            dtStart = DateTime.MinValue;
            dtFinish = DateTime.MinValue;
            try
            {
                string sCommand = "SELECT PROJECT_START_DATE,PROJECT_FINISH_DATE FROM EPGP_PROJECTS WHERE PROJECT_ID = " + nProjectID.ToString("0");
                SqlCommand oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                SqlDataReader reader = oCommand.ExecuteReader();

                int lStartPeriod = 0;
                int lFinishPeriod = 0;
                if (reader.Read() == true)
                {
                    bool bNull;
                    dtStart = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"], out bNull);
                    dtFinish = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"], out bNull);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "GetProjectInfo", (StatusEnum)99960, ex.Message);
            }
            return eStatus;
        }

        public static bool CheckCostTypeSecurity(DBAccess dba, int costtypeId, ref int costtypeEditMode)
        {
            // check, and if required, modify CT edit/read security
            bool bAdd = true;
            int lWResId = dba.UserWResID;
            if (lWResId != 1)
            {
                string sCommand =
                    "SELECT COUNT(*) as nCount FROM EPGP_DATA_SECURITY WHERE DS_CONTEXT=2 AND DS_UID = " +
                    costtypeId.ToString("0");
                SqlCommand oCommand = new SqlCommand(sCommand, dba.Connection);
                SqlDataReader reader = oCommand.ExecuteReader();
                if (reader.Read() == true)
                {
                    int nCount = DBAccess.ReadIntValue(reader["nCount"]);
                    reader.Close();
                    if (nCount > 0)
                    {
                        sCommand =
                            "SELECT SUM(DS_READ) AS CanRead, SUM(DS_EDIT) as CanEdit FROM EPGP_DATA_SECURITY WHERE DS_CONTEXT=2 AND DS_UID = " +
                            costtypeId.ToString("0") + " AND GROUP_ID IN (select GROUP_ID from EPG_GROUP_MEMBERS where MEMBER_UID = " + lWResId.ToString("0") + ")";
                        oCommand = new SqlCommand(sCommand, dba.Connection);
                        reader = oCommand.ExecuteReader();
                        if (reader.Read() == true)
                        {
                            bool bIsNullRead;
                            bool bIsNullEdit;
                            int nCanRead = DBAccess.ReadIntValue(reader["CanRead"], out bIsNullRead);
                            int nCanEdit = DBAccess.ReadIntValue(reader["CanEdit"], out bIsNullEdit);
                            if ((bIsNullRead && bIsNullEdit) == false)
                            {
                                if (nCanEdit <= 0)
                                {
                                    if (nCanRead > 0)
                                        costtypeEditMode = 0; // make sure only read perm at this point
                                    else
                                        bAdd = false;
                                }
                            }
                            else
                            {
                                bAdd = false;
                            }
                        }
                        reader.Close();
                    }
                }
            }
            return bAdd;
        }
    }

}

