using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PortfolioEngineCore
{
    public class dbaCostValues
    {
        public static bool PostCostValues(DBAccess dba, string data, out string sResult)
        {
            try
            {
                //dba.WriteImmTrace("PfECore", "PostCostValues", "Input", data);

                sResult = "";

                CStruct xData = new CStruct();
                xData.LoadXML(data);
                CStruct xDataCT = xData.GetSubStruct("CT");
                int CT_ID = xDataCT.GetIntAttr("Id");
                CStruct xDataCB = xData.GetSubStruct("CB");
                int CB_ID = xDataCB.GetIntAttr("Id");
                List<CStruct> listPIs = xData.GetList("PI");

                //  if CT or CB not set then error
                if (CB_ID < 0 || CT_ID <= 0)
                {
                    sResult = "Calendar and Cost Type must be specified";
                    return false;
                }

                SqlCommand oCommand;
                SqlDataReader reader;
                string cmdText;

                bool bupdateOK = true;

                string sCTName;
                int nCTEditMode = -1;
                CTEditMode CTEditMode;
                int nInputCalendar=-1;
                cmdText = "SELECT CT_NAME,CT_EDIT_MODE,CT_CB_ID FROM EPGP_COST_TYPES Where CT_ID=@CTID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@CTID", CT_ID);
                reader = oCommand.ExecuteReader();
                if (reader.Read())
                {
                    nCTEditMode = DBAccess.ReadIntValue(reader["CT_EDIT_MODE"]);
                    nInputCalendar = DBAccess.ReadIntValue(reader["CT_CB_ID"]);
                    sCTName = DBAccess.ReadStringValue(reader["CT_NAME"]);
                }
                reader.Close();

                // set up the list of PIs we are going to process - as passed or ALL
                List<int> PIs = new List<int>();
                foreach (CStruct xProject in listPIs)
                {
                    int PROJECT_ID = xProject.GetIntAttr("Id");
                    PIs.Add(PROJECT_ID);
                }
                if (PIs.Count == 0)
                {
                    cmdText = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION = 0";
                    oCommand = new SqlCommand(cmdText, dba.Connection);
                    if (dbaUsers.ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
                    {
                        while (reader.Read())
                        {
                            int lProjectID = (int)reader["PROJECT_ID"];
                            PIs.Add(lProjectID);
                        }
                        reader.Close();
                    }

                }
                //  any pIs to process?
                if (PIs.Count == 0)
                {
                    sResult = "No PIs to process";
                    return false;
                }

                List<PfEPeriod> periods = new List<PfEPeriod>();

                CTEditMode = (CTEditMode)nCTEditMode;
                switch (CTEditMode)
                {
                    case CTEditMode.ctBudget:
                    case CTEditMode.ctDisplay:
                    case CTEditMode.ctDisplaywDetails:
                        GetPeriods(dba, CB_ID, periods);
                        string sMessage;
                        if (CopyCostValues(dba, CB_ID, CT_ID, nInputCalendar, PIs, periods, out sMessage) == false)
                        {
                            sResult = sMessage;
                            return false;
                        }
                        break;
                    case CTEditMode.ctTSActuals:
                    case CTEditMode.ctTSActualsToDate:
                    case CTEditMode.ctWEActuals:
                        break;
                    default:
                        break;
                }

                return bupdateOK;

            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.PostCostValues, exception.GetBaseMessage());
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        // CopyCostValues
        //  notice that cost is not calculated here for Labor quantities
        //  that's because we are rolling up the costs from the input calendar rather than using the rates on the target calendar
        //  it will NOT be recalculated when displayed in Portolio view
        //   to extend this so that it can copy to a DIFFERENT Cost Type rather than just a different calendar is harder
        //    and will require a complete re-write
        //   In some case it is not possible to do it - if the target had CCs at a lower level than the source
        //   If the target CT has CCs at a higher level then need to rollup through the CC structure - tough when there are Cost Details
        //     we could say - can only copy when available CCs are the same?
        //////////////////////////////////////////////////////////////////////////////
        private static bool CopyCostValues(DBAccess dba, int nCB_ID, int nCT_ID, int nInputCalendar, List<int> PIs, List<PfEPeriod> periods, out string sReply)
        {
            if (nCB_ID < 0 || nCT_ID <= 0 || nInputCalendar < 0)
            {
                sReply = "Calendars and Cost Type must be specified";
                return false;
            }

            try
            {
                sReply = "";

                SqlCommand oCommand;
                SqlDataReader reader;
                string cmdText;

                foreach (int ProjectID in PIs)
                {
                    dba.BeginTransaction();

                    // clear existing COST VALUES
                    cmdText = "DELETE FROM  EPGP_COST_VALUES WHERE CB_ID=@CalID And CT_ID=@CTID And PROJECT_ID=@ProjectID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                    oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                    oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();

                    cmdText = "DELETE FROM  EPGP_DETAIL_VALUES WHERE CB_ID=@CalID And CT_ID=@CTID And PROJECT_ID=@ProjectID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                    oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                    oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();

                    cmdText = "DELETE FROM  EPGP_COST_DETAILS WHERE CB_ID=@CalID And CT_ID=@CTID And PROJECT_ID=@ProjectID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                    oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                    oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();

                    cmdText = "DELETE FROM  EPGP_PROJECT_CT_STATUS WHERE CB_ID=@CalID And CT_ID=@CTID And PROJECT_ID=@ProjectID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                    oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                    oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();

                    // Create new values - first just copy CT_STATUS
                    cmdText = "Insert Into EPGP_PROJECT_CT_STATUS (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_STATUS)"
                            + " Select " + nCB_ID.ToString() + ",CT_ID,PROJECT_ID,BC_UID,BC_STATUS FROM  EPGP_PROJECT_CT_STATUS WHERE CB_ID=@CalID And CT_ID=@CTID And PROJECT_ID=@ProjectID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CalID", nInputCalendar);
                    oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                    oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();

                    //  straight copy for COST_DETAILS then read in the CB/CT info from DETAIL_VALUES, convert to new period and write out for new calendar
                    cmdText = "INSERT INTO EPGP_COST_DETAILS (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_SEQ,OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05)"
                            + " Select " + nCB_ID.ToString() + ",CT_ID,PROJECT_ID,BC_UID,BC_SEQ,OC_01,OC_02,OC_03,OC_04,OC_05,TEXT_01,TEXT_02,TEXT_03,TEXT_04,TEXT_05"
                            + " FROM  EPGP_COST_DETAILS WHERE CB_ID=@CalID And CT_ID=@CTID And PROJECT_ID=@ProjectID";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CalID", nInputCalendar);
                    oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                    oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();

                    cmdText = "Select BC_UID,BC_SEQ,BD_PERIOD,PRD_START_DATE,BD_VALUE,BD_COST From EPGP_DETAIL_VALUES cv"
                                + " Inner Join EPG_PERIODS p On cv.CB_ID = p.CB_ID And cv.BD_PERIOD = p.PRD_ID"
                                + " Where cv.CB_ID = @CalID And CT_ID = @CTID And PROJECT_ID=@ProjectID Order by BC_UID,BC_SEQ,BD_PERIOD";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CalID", nInputCalendar);
                    oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                    oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                    DataTable dt = new DataTable();
                    dt.Load(oCommand.ExecuteReader());

                    // set up the INSERT I need to add new records
                    cmdText = "INSERT INTO EPGP_DETAIL_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID,BC_SEQ,BD_PERIOD,BD_VALUE,BD_COST) VALUES(@CalID,@CTID,@ProjectID,@BC_UID,@BC_SEQ,@BD_PERIOD,@BD_VALUE,@BD_COST)";
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                    oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                    oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);

                    SqlParameter pBC_UID = oCommand.Parameters.Add("@BC_UID", SqlDbType.Int);
                    SqlParameter pBC_SEQ = oCommand.Parameters.Add("@BC_SEQ", SqlDbType.Int);
                    SqlParameter pBD_PERIOD = oCommand.Parameters.Add("@BD_PERIOD", SqlDbType.Int);
                    SqlParameter pBD_VALUE = oCommand.Parameters.Add("@BD_VALUE", SqlDbType.Decimal);
                    SqlParameter pBD_COST = oCommand.Parameters.Add("@BD_COST", SqlDbType.Decimal);
                    pBD_VALUE.Precision = 25;
                    pBD_VALUE.Scale = 6;
                    pBD_COST.Precision = 25;
                    pBD_COST.Scale = 6;

                    int lCat; int lSeq; int lPeriodID; int lNewPeriodID=0;
                    int lPrevCat=0; int lPrevSeq=0; int lPrevNewPeriodID=0;
                    DateTime dtStartDate;
                    double dHours; double dCost;
                    double dTotalHours=0; double dTotalCost=0;

                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            PfEPeriod period = new PfEPeriod();
                            lPeriodID = DBAccess.ReadIntValue(row["BD_PERIOD"]);
                            dtStartDate = DBAccess.ReadDateValue(row["PRD_START_DATE"]);
                            lCat = DBAccess.ReadIntValue(row["BC_UID"]);
                            lSeq = DBAccess.ReadIntValue(row["BC_SEQ"]);
                            dHours = DBAccess.ReadDoubleValue(row["BD_VALUE"]);
                            dCost = DBAccess.ReadDoubleValue(row["BD_COST"]);

                            lNewPeriodID = MapToPeriod(dtStartDate, periods);
                                
                            if (lPrevNewPeriodID != lNewPeriodID || lPrevCat != lCat || lPrevSeq != lSeq)
                            {
                                if (lPrevCat >= 0 && lPrevNewPeriodID > 0 && (dTotalHours != 0 || dTotalCost != 0))
                                {
                                    // write out the record for this cat/seq for this period
                                    pBC_UID.Value = lPrevCat;
                                    pBC_SEQ.Value = lPrevSeq;
                                    pBD_PERIOD.Value = lPrevNewPeriodID;
                                    pBD_VALUE.Value = dTotalHours;
                                    pBD_COST.Value = dTotalCost;
                                    oCommand.ExecuteNonQuery();
                                }
                                dTotalHours = 0;
                                dTotalCost = 0;
                            }
        
                            dTotalHours = dTotalHours + dHours;
                            dTotalCost = dTotalCost + dCost;
                            lPrevNewPeriodID = lNewPeriodID;
                            lPrevCat = lCat;
                            lPrevSeq = lSeq;                   
                        }
                    }
                    if (lPrevCat >= 0 && lPrevNewPeriodID > 0 && (dTotalHours != 0 || dTotalCost != 0))
                    {
                        // write out possible final record
                        pBC_UID.Value = lPrevCat;
                        pBC_SEQ.Value = lPrevSeq;
                        pBD_PERIOD.Value = lPrevNewPeriodID;
                        pBD_VALUE.Value = dTotalHours;
                        pBD_COST.Value = dTotalCost;
                        oCommand.ExecuteNonQuery();
                    }
                    dba.CommitTransaction();

                    // use CalculateCostValues (as used in Cost Planner) to create COST_VALUES from COST DETAILS
                    string sResult;
                    if (dbaCCV.CalculateCostValues(dba, nCT_ID, nCB_ID, ProjectID, out sResult) != StatusEnum.rsSuccess)
                    { 
                        sReply = sResult;
                        return false;
                    }
                }
            }
            catch (Exception exception)
            {
                sReply = "CostValues.CopyCostValues, Exception: " + exception.Message;
                return false;
            }
            return true;
        }

        private static StatusEnum GetPeriods(DBAccess dba, int CB_ID, List<PfEPeriod> periods)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            try
            {

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand = "";


                sCommand = "SELECT PRD_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE FROM EPG_PERIODS WHERE CB_ID = @CalID ORDER BY PRD_ID";
                SqlCommand = new SqlCommand(sCommand, dba.Connection);
                SqlCommand.Parameters.AddWithValue("@CalID", CB_ID);
                SqlReader = SqlCommand.ExecuteReader();
                while (SqlReader.Read())
                {
                    PfEPeriod period = new PfEPeriod();
                    period.PeriodID = DBAccess.ReadIntValue(SqlReader["PRD_ID"]);
                    period.StartDate = DBAccess.ReadDateValue(SqlReader["PRD_START_DATE"]);
                    period.FinishDate = DBAccess.ReadDateValue(SqlReader["PRD_FINISH_DATE"]);
                    periods.Add(period);
                }
                SqlReader.Close();

                return eStatus;

            }
            catch (Exception ex)
            {
                //HandleException("GetTimerJobDetails", 99999, ex);
                return StatusEnum.rsServerError;
            }

        }
        private static int MapToPeriod(DateTime dtDate, List<PfEPeriod> periods)
        {
            int nPeriod = 0;
            
            foreach (PfEPeriod period in periods)
            {
                nPeriod++;
                if(dtDate >= period.StartDate && dtDate <= period.FinishDate)
                {
                    return nPeriod;
                }
            }
            return nPeriod;
        }

        private class PfEPeriod
        {
            public string PeriodName;
            public int PeriodID;
            public DateTime StartDate;
            public DateTime FinishDate;
        }
    }
}
