using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{

    public class dbaCostViews
    {
        public static StatusEnum SelectViews(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT VIEW_UID, VIEW_NAME, VIEW_DESC FROM EPGT_COSTVIEW_DISPLAY ORDER BY VIEW_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99971, out dt);
        }
        public static StatusEnum SelectCostView(DBAccess dba, int nViewId, out DataTable dt)
        {
            //if (nViewId > 0)
            {
                const string cmdText = "SELECT * FROM EPGT_COSTVIEW_DISPLAY WHERE VIEW_UID = @p1";
                return dba.SelectDataById(cmdText, nViewId, (StatusEnum)99971, out dt);
            }
            //else
            //{
            //    const string cmdText = "SELECT CB_ID=0,CB_NAME='New Calendar',CB_DESC=NULL,CB_LOCK_TO=NULL,CB_LOCK_FROM=NULL";
            //    return dba.SelectData(cmdText, (StatusEnum)99999, out dt);
            //}
        }

        public static StatusEnum SelectCostTypesForView(DBAccess dba, int nViewId, out DataTable dt)
        {
            const string cmdText = "SELECT ct.CT_ID, CT_NAME,"
            + " case When (cvct.CT_ID is null) Then 0 Else 1 End as used"
            + " FROM EPGP_COST_TYPES ct"
            + " LEFT JOIN  EPGT_COSTVIEW_COST_TYPES cvct ON (cvct.CT_ID = ct.CT_ID AND VIEW_UID = @p1)"
            + " ORDER BY cvct.VT_ID, CT_NAME";
            return dba.SelectDataById(cmdText, nViewId, (StatusEnum)99971, out dt);
        }

        public static StatusEnum UpdateCostViewInfo(DBAccess dba, ref int nVIEW_UID, string sName, string sDesc, int nCalendar, int nFirstPeriod, int nLastPeriod, string sCTs, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                // make sure there isn't already another Cost View with this name
                {
                    sName = sName.Trim();
                    if (sName.Length == 0)
                    {
                        sReply = DBAccess.FormatAdminError("error", "CostViews.UpdateCostViewInfo", "Please enter a Cost View Name");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                    cmdText = "SELECT VIEW_UID From EPGT_COSTVIEW_DISPLAY WHERE VIEW_NAME = @p1";
                    DataTable dt;
                    if (dba.SelectDataByName(cmdText, sName, (StatusEnum)99999, out dt) != StatusEnum.rsSuccess)
                        sReply = DBAccess.FormatAdminError("exception", "CostViews.UpdateCostViewInfo1", dba.StatusText);
                    else if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nExistingId = DBAccess.ReadIntValue(row["VIEW_UID"]);
                        if (nExistingId != nVIEW_UID)
                        {
                            sReply = DBAccess.FormatAdminError("error", "CostViews.UpdateCostViewInfo", "Can't save Cost View.\nA Cost View with name '" + sName + "' already exists");
                            return StatusEnum.rsRequestCannotBeCompleted;
                        }
                    }
                }

                if (nVIEW_UID == 0)
                {
                    //   ADD - need to figure new VIEW UID
                    cmdText = "SELECT MAX(VIEW_UID) as maxUID FROM EPGT_COSTVIEW_DISPLAY";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    reader = oCommand.ExecuteReader();
                    if (reader.Read())
                        nVIEW_UID = DBAccess.ReadIntValue(reader["maxUID"]) + 1;
                    else
                        nVIEW_UID = 1;
                    reader.Close();

                    cmdText =
                           "INSERT Into EPGT_COSTVIEW_DISPLAY (VIEW_UID,VIEW_NAME,VIEW_DESC,VIEW_COST_BREAKDOWN, VIEW_FIRST_PERIOD,VIEW_LAST_PERIOD)"
                       + " Values(@pVIEW_UID,@pVIEW_NAME, @pVIEW_DESC,@pCB,@pFirstPeriod,@pLastPeriod)";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pVIEW_UID", nVIEW_UID);
                    oCommand.Parameters.AddWithValue("@pVIEW_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pVIEW_DESC", sDesc);
                    oCommand.Parameters.AddWithValue("@pCB", nCalendar);
                    oCommand.Parameters.AddWithValue("@pFirstPeriod", nFirstPeriod);
                    oCommand.Parameters.AddWithValue("@pLastPeriod", nLastPeriod);
                    oCommand.ExecuteNonQuery();
                }
                else
                {
                    //  update
                    cmdText = "UPDATE EPGT_COSTVIEW_DISPLAY "
                                + " SET VIEW_NAME=@pVIEW_NAME,VIEW_DESC=@pVIEW_DESC,VIEW_COST_BREAKDOWN=@pCB,VIEW_FIRST_PERIOD=@pFirstPeriod,VIEW_LAST_PERIOD=@pLastPeriod"
                                + " WHERE VIEW_UID = @pVIEW_UID";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    oCommand.Parameters.AddWithValue("@pVIEW_NAME", sName);
                    oCommand.Parameters.AddWithValue("@pVIEW_DESC", sDesc);
                    oCommand.Parameters.AddWithValue("@pCB", nCalendar);
                    oCommand.Parameters.AddWithValue("@pFirstPeriod", nFirstPeriod);
                    oCommand.Parameters.AddWithValue("@pLastPeriod", nLastPeriod);
                    oCommand.Parameters.AddWithValue("@pVIEW_UID", nVIEW_UID);
                    oCommand.ExecuteNonQuery();
                }

                if (nVIEW_UID > 0)
                {
                    //  update the list of CTs included in this view
                    SqlTransaction transaction = dba.Connection.BeginTransaction();
                    cmdText =
                        "DELETE FROM EPGT_COSTVIEW_COST_TYPES WHERE VIEW_UID = @pVIEW_UID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pVIEW_UID", nVIEW_UID);
                    oCommand.ExecuteNonQuery();

                    string[] costtypes = sCTs.Split(',');
                    cmdText =
                    "INSERT INTO EPGT_COSTVIEW_COST_TYPES (VIEW_UID,VT_ID,CT_ID)  VALUES(@pVIEW_UID,@pVT_ID,@pCT_ID)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, transaction);
                    oCommand.Parameters.AddWithValue("@pVIEW_UID", nVIEW_UID);
                    SqlParameter pVT_ID = oCommand.Parameters.Add("@pVT_ID", SqlDbType.Int);
                    SqlParameter pCT_ID = oCommand.Parameters.Add("@pCT_ID", SqlDbType.Int);

                    int nID = 0;
                    int ientry;
                    foreach (string sentry in costtypes)
                    {
                        int.TryParse(sentry, out ientry);
                        if (ientry > 0)
                        {
                            nID++;
                            pVT_ID.Value = nID;
                            pCT_ID.Value = ientry;
                            oCommand.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostViews.UpdateCostViewInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum DeleteCostView(DBAccess dba, int nVIEW_UID, out string sReply)
        {
            string cmdText;
            SqlCommand oCommand;
            sReply = "";
            try
            {
                // check if Cost View can be deleted
                string sdeletemessage;
                if (CanDeleteCostView(dba, nVIEW_UID, out sdeletemessage) != StatusEnum.rsSuccess) return dba.Status;
                if (sdeletemessage.Length > 0)
                {
                    sReply = DBAccess.FormatAdminError("error", "CostViews.DeleteCostView", "This Cost View cannot be deleted, it is currently used as follows:" + "\n" + "\n" + sdeletemessage);
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                // get info for view to be deleted
                {
                    cmdText = "SELECT VIEW_UID, VIEW_NAME FROM EPGT_COSTVIEW_DISPLAY Where VIEW_UID=@p1";
                    DataTable dt;
                    dba.SelectDataById(cmdText, nVIEW_UID, (StatusEnum)99999, out dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        int nCV = DBAccess.ReadIntValue(row["VIEW_UID"]);
                    }
                    else
                    {
                        sReply = DBAccess.FormatAdminError("error", "CostViews.DeleteCostView", "Can't delete Cost View, Cost View not found");
                        return StatusEnum.rsRequestCannotBeCompleted;
                    }
                }

                //   clear if used in Portfolio Views - won't happen while we disallow that
                cmdText = "UPDATE EPGT_VIEW_DISPLAY SET COSTVIEW_UID = NULL WHERE COSTVIEW_UID = @pVIEW_UID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pVIEW_UID", nVIEW_UID);
                oCommand.ExecuteNonQuery();

                //    clear any CT entries
                cmdText = "DELETE FROM EPGT_COSTVIEW_COST_TYPES WHERE VIEW_UID = @pVIEW_UID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pVIEW_UID", nVIEW_UID);
                oCommand.ExecuteNonQuery();

                // Delete the Cost View itself
                cmdText = "DELETE FROM EPGT_COSTVIEW_DISPLAY WHERE VIEW_UID = @pVIEW_UID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pVIEW_UID", nVIEW_UID);
                oCommand.ExecuteNonQuery();

                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostViews.DeleteCostView", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum CanDeleteCostView(DBAccess dba, int nVIEW_UID, out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                // check if Cost View can be deleted
                oCommand = new SqlCommand("EPG_SP_ReadUsedCostViews", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@UID", nVIEW_UID);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    sReply += "Portfolio View: " + DBAccess.ReadStringValue(reader["VIEW_NAME"]) + "\n";
                }
                reader.Close();
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostViews.CanDeleteCostView", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

    }
}

