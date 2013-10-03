using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PortfolioEngineCore
{
    public class dbaCostValues
    {
        public static bool PostCostValues(DBAccess dba, string data, out string sResult, out string sPostInstruction)
        {
            try
            {
                dba.WriteImmTrace("PfECore", "PostCostValues", "Input", data);

                sResult = "";
                string sErrorReply = "";
                bool bPostToWE = false;
                sPostInstruction = "";

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
                bool allPIs = false;
                foreach (CStruct xProject in listPIs)
                {
                    int PROJECT_ID = xProject.GetIntAttr("Id");
                    PIs.Add(PROJECT_ID);
                }
                if (PIs.Count == 0)
                {
                    allPIs = true;
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
                Dictionary<int, int> xrefs = new Dictionary<int, int>();
                Dictionary<int, PfECostCategory> costcategories = new Dictionary<int, PfECostCategory>();
                Dictionary<int, EPKItem> majorcategories = new Dictionary<int, EPKItem>();
                Dictionary<int, Dictionary<int,double>> rates = new Dictionary<int,Dictionary<int,double>>();
                PfENamedRates namedrates = new PfENamedRates();
                //Dictionary<int, double> Periodrates;
                PfEAdmin admininfo = new PfEAdmin();

                CTEditMode = (CTEditMode)nCTEditMode;
                switch (CTEditMode)
                {
                    case CTEditMode.ctBudget:
                    case CTEditMode.ctDisplay:
                    case CTEditMode.ctDisplaywDetails:
                        if (GetPeriods(dba, CB_ID, periods, ref sErrorReply) != StatusEnum.rsSuccess)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of periods: " + sErrorReply);
                            return false;
                        }
                        if (CopyCostValues(dba, CB_ID, CT_ID, nInputCalendar, PIs, periods, out sErrorReply) == false)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, sErrorReply);
                            return false;
                        }
                        break;
                    case CTEditMode.ctTSActuals:
                    case CTEditMode.ctTSActualsToDate:
                        // no reason to do this here - does include Hershey filter on CF option if ever done need to consider that also    
                        break;
                    case CTEditMode.ctWEActuals:
                        if (GetPeriods(dba, CB_ID, periods, ref sErrorReply) != StatusEnum.rsSuccess)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of periods: " + sErrorReply);
                            return false;
                        }
                        if (GetXrefs(dba, xrefs, ref sErrorReply) != StatusEnum.rsSuccess)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of xrefs: " + sErrorReply);
                            return false;
                        }
                        if (GetCostCategories(dba, CT_ID, costcategories, majorcategories, ref sErrorReply) != StatusEnum.rsSuccess) 
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of cost categoiories: " + sErrorReply);
                            return false;
                        }
                        if (GetCostCategoryRates(dba, CB_ID, rates, ref sErrorReply) != StatusEnum.rsSuccess) 
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of cost categoiory rates: " + sErrorReply);
                            return false;
                        }
                        if (GetNamedRates(dba, ref namedrates, ref sErrorReply) != StatusEnum.rsSuccess) 
                        {
                            sResult = "Failed during load of named rates";
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of named rates: " + sErrorReply);
                            return false;
                        }
                        GetAdminInfo(dba, admininfo);
                        SetDefaultMC(admininfo, majorcategories);

                        if (PostWETimesheets(dba, CB_ID, CT_ID, PIs, allPIs, periods, xrefs, costcategories, majorcategories, rates, namedrates, admininfo, out sErrorReply) == false)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during PostWETimesheets: " + sErrorReply);
                            return false;
                        }
                        break;
                    case CTEditMode.ctCommitments: // this is the only one that should exist right now
                    case CTEditMode.ctForecastCommitments:
                    case CTEditMode.ctCommitmentsREV:
                    case CTEditMode.ctForecastCommitmentsREV:
                        if (GetPeriods(dba, CB_ID, periods, ref sErrorReply) != StatusEnum.rsSuccess)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of periods: " + sErrorReply);
                            return false;
                        }
                        if (GetXrefs(dba, xrefs, ref sErrorReply) != StatusEnum.rsSuccess)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of xrefs: " + sErrorReply);
                            return false;
                        }
                        if (GetCostCategories(dba, CT_ID, costcategories, majorcategories, ref sErrorReply) != StatusEnum.rsSuccess)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of cost categoiories: " + sErrorReply);
                            return false;
                        }
                        if (GetCostCategoryRates(dba, CB_ID, rates, ref sErrorReply) != StatusEnum.rsSuccess)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of cost categoiory rates: " + sErrorReply);
                            return false;
                        }
                        if (GetNamedRates(dba, ref namedrates, ref sErrorReply) != StatusEnum.rsSuccess)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during load of named rates: " + sErrorReply);
                            return false;
                        }
                        GetAdminInfo(dba, admininfo);
                        SetDefaultMC(admininfo, majorcategories);

                        if (PostCommitments(dba, CB_ID, CT_ID, PIs, allPIs, periods, xrefs, costcategories, majorcategories, rates, namedrates, admininfo, ref bPostToWE, out sErrorReply) == false)
                        {
                            sResult = FormatError(dba, CB_ID, CT_ID, "Failed during PostCommitments: " + sErrorReply);
                            return false;
                        }
                        break;
                    default:
                        break;
                }

                // if we hve a successfull Post and there are Cost Totals to post to WE then pass that instruction back to WorkEnginePPM
                if (bPostToWE)
                {
                    CStruct xPost = new CStruct();
                    xPost.Initialize("Post");
                    CStruct xItem = xPost.CreateSubStruct("PIs");
                    if (allPIs)
                    {
                        xItem.CreateStringAttr("Ids", "");
                    }
                    else
                    {
                        string sPIs = "";
                        foreach (int ProjectID in PIs)
                        {
                            if (sPIs.Length < 1) { sPIs = ProjectID.ToString(); }
                            else { sPIs += "," + ProjectID.ToString(); }
                            xItem.CreateStringAttr("IDs", sPIs);
                        }
                    }
                    sPostInstruction = xPost.XML();

                    // if return NOT true then sResult should contain info
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

        //////////////////////////////////////////////////////////////////////////////
        // PostWETimesheets
        //////////////////////////////////////////////////////////////////////////////
        private static bool PostWETimesheets(DBAccess dba, int nCB_ID, int nCT_ID, List<int> PIs, bool allPIs,
                                                List<PfEPeriod> periods, Dictionary<int, int> xrefs, 
                                                Dictionary<int, PfECostCategory> costcategories,
                                                Dictionary<int, EPKItem> majorcategories,
                                                Dictionary<int, Dictionary<int, double>> rates,
                                                PfENamedRates namedrates,
                                                PfEAdmin admininfo,
                                                out string sReply)
        {
            if (nCB_ID < 0 || nCT_ID <= 0)
            {
                sReply = "Calendar and Cost Type must be specified";
                return false;
            }

            SqlCommand oCommand;
            SqlDataReader reader;

            try
            {
                sReply = "";

                double [,] quantity = new double[costcategories.Count + 1, periods.Count + 1];
                double[,] cost = new double[costcategories.Count + 1, periods.Count + 1];

                bool firsttimethrough = true;
                foreach (int ProjectID in PIs) 
                {
                    // clear arrays for this PI
                    for (int i=0; i < quantity.GetLength(0); i++)
                    {
                        for (int j = 0; j < quantity.GetLength(1); j++)
                        {
                            quantity[i, j] = 0;
                            cost[i, j] = 0;
                        }
                    }

                    oCommand = new SqlCommand("EPG_SP_PCTReadWEActuals", dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@ProjID", ProjectID);
                    reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                        DateTime startdate = DBAccess.ReadDateValue(reader["WEH_DATE"]);
                        string majorcategory = DBAccess.ReadStringValue(reader["WEC_MAJORCATEGORY"]);
                        double hours = DBAccess.ReadDoubleValue(reader["WEH_NORMALHOURS"]);
                        double overtimehours = DBAccess.ReadDoubleValue(reader["WEH_OVERTIMEHOURS"]);

                        hours = hours / 100;
                        overtimehours = overtimehours / 100;

                        // map resource to cost category
                        int lCatUID = 0;
                        PfECostCategory costcategory = MapToCostCategory(lWResID, lCatUID, majorcategory, costcategories, majorcategories, xrefs, admininfo);
                        if (costcategory != null)
                        {
                            // map date to period
                            int periodid = MapToPeriod(startdate, periods);
                            if (periodid>0)
                            {
                                // get rates for this resource or cost category
                                double dblRate;
                                double dblOvertimeRate;
                                GetRate(namedrates, rates, costcategory.UID, lWResID, periodid, startdate, out dblRate, out dblOvertimeRate);

                                // tabulate quantity and cost
                                quantity[costcategory.ID, periodid] += hours;
                                quantity[costcategory.ID, periodid] += overtimehours;
                                cost[costcategory.ID, periodid] += hours * dblRate;
                                cost[costcategory.ID, periodid] += overtimehours * dblOvertimeRate;
                            }
                        }
                    }
                    reader.Close();

                    // rollup
                    Rollup(quantity, cost, costcategories);

                    WriteToDatabaseThisPI(dba, ProjectID, nCB_ID, nCT_ID, allPIs, ref firsttimethrough, quantity, cost, costcategories);

                    // update Cost Totals
                    bool bUpdatedTotal = false;
                    if (allPIs)
                    {
                        bUpdatedTotal = SetCostTotals(dba, 0, nCB_ID, nCT_ID);
                    }
                    else
                    {
                        foreach (int nProjectID in PIs) // if it comes here then likely only a single entry
                        {
                            bUpdatedTotal = SetCostTotals(dba, nProjectID, nCB_ID, nCT_ID);
                        }
                    }

                }
            }
            catch (Exception exception)
            {
                sReply = "CostValues.PostWETimesheets, Exception: " + exception.Message;
                return false;
            }
            return true;
        }


        //////////////////////////////////////////////////////////////////////////////
        // PostCommitments
        //////////////////////////////////////////////////////////////////////////////
        private static bool PostCommitments(DBAccess dba, int nCB_ID, int nCT_ID, List<int> PIs, bool allPIs,
                                                List<PfEPeriod> periods, Dictionary<int, int> xrefs,
                                                Dictionary<int, PfECostCategory> costcategories,
                                                Dictionary<int, EPKItem> majorcategories,
                                                Dictionary<int, Dictionary<int, double>> rates,
                                                PfENamedRates namedrates,
                                                PfEAdmin admininfo,
                                                ref bool bPostToWE,
                                                out string sReply)
        {
            bPostToWE = false;

            if (nCB_ID < 0 || nCT_ID <= 0)
            {
                sReply = "Calendar and Cost Type must be specified";
                return false;
            }

            SqlCommand oCommand;
            SqlDataReader reader;

            try
            {
                sReply = "";

                double[,] quantity = new double[costcategories.Count + 1, periods.Count + 1];
                double[,] cost = new double[costcategories.Count + 1, periods.Count + 1];

                bool firsttimethrough = true;
                foreach (int ProjectID in PIs)
                {
                    // clear arrays for this PI
                    for (int i = 0; i < quantity.GetLength(0); i++)
                    {
                        for (int j = 0; j < quantity.GetLength(1); j++)
                        {
                            quantity[i, j] = 0;
                            cost[i, j] = 0;
                        }
                    }

                    int lReadCustomFields = 0;
                    oCommand = new SqlCommand("EPG_SP_PCTReadCommitments", dba.Connection);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@MODE", lReadCustomFields);
                    oCommand.Parameters.AddWithValue("@ProjID", ProjectID);
                    reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        int periodid = DBAccess.ReadIntValue(reader["PRD_ID"]);

                        if (periodid > 0 && periodid < periods.Count)  // if period out of range ignore this record
                        {
                            // use period start date when necessary to map to a different calendar than the Planning calendar
                            DateTime startdate = GetPeriodStartDate(periodid, periods);

                            int lWResID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                            int lDept = DBAccess.ReadIntValue(reader["CMT_DEPT"]);
                            //int lRateType = DBAccess.ReadIntValue(reader["CMT_RATETYPE_UID"]);
                            //int lNamedRate = DBAccess.ReadIntValue(reader["CMT_RT_UID"]);
                            int lRPCatUID = DBAccess.ReadIntValue(reader["BC_UID"]);
                            string majorcategory = DBAccess.ReadStringValue(reader["CMT_MAJORCATEGORY"]);
                            double hours = DBAccess.ReadDoubleValue(reader["CMH_HOURS"]);
                            //double dblRevenue = DBAccess.ReadDoubleValue(reader["CMH_REVENUES"]);

                            hours = hours / 100;

                            // map resource to cost category
                            PfECostCategory costcategory = MapToCostCategory(lWResID, lRPCatUID, majorcategory, costcategories, majorcategories, xrefs, admininfo);
                            if (costcategory != null)
                            {
                                // map date to period - seems like we can avoid this most of the time as using Planning Calendar - not a big deal though I guess
                                periodid = MapToPeriod(startdate, periods);
                                if (periodid > 0)
                                {
                                    // get rates for this resource or cost category
                                    double dblRate;
                                    double dblOvertimeRate;
                                    GetRate(namedrates, rates, costcategory.UID, lWResID, periodid, startdate, out dblRate, out dblOvertimeRate);

                                    // tabulate quantity and cost
                                    // in the old system here we checked the editmode for: Commitments, Forecast Commitments, Revenue, or Forecast Revenue
                                    //    right now we only have Commitments
                                    quantity[costcategory.ID, periodid] += hours;
                                    cost[costcategory.ID, periodid] += hours * dblRate;
                                }
                            }
                        }
                    }
                    reader.Close();

                    // rollup
                    Rollup(quantity, cost, costcategories);

                    WriteToDatabaseThisPI(dba, ProjectID, nCB_ID, nCT_ID, allPIs, ref firsttimethrough, quantity, cost, costcategories);

                    // update Cost Totals
                    bool bUpdatedTotal = false;
                    if (allPIs)
                    {
                        bUpdatedTotal = SetCostTotals(dba, 0, nCB_ID, nCT_ID);
                    }
                    else
                    {
                        foreach (int nProjectID in PIs) // if it comes here then likely only a single entry
                        {
                            bUpdatedTotal = SetCostTotals(dba, nProjectID, nCB_ID, nCT_ID);
                        }
                    }

                    // Send instruction back to WorkEnginePPM to post new Cost Totals
                    bPostToWE = bUpdatedTotal;
                    }
            }
            catch (Exception exception)
            {
                sReply = "CostValues.PostWETimesheets, Exception: " + exception.Message;
                return false;
            }
            return true;
        }

        //
        //
        private static StatusEnum GetPeriods(DBAccess dba, int CB_ID, List<PfEPeriod> periods, ref string sErrorReply)
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
                sErrorReply = ex.Message;
                return StatusEnum.rsServerError;
            }
        }

        private static int MapToPeriod(DateTime dtDate, List<PfEPeriod> periods)
        {
            int nPeriod = 0;

            foreach (PfEPeriod period in periods)
            {
                nPeriod++;
                if (dtDate >= period.StartDate && dtDate <= period.FinishDate)
                {
                    return nPeriod;
                }
            }
            return nPeriod;
        }
        private static DateTime GetPeriodStartDate(int PeriodID, List<PfEPeriod> periods)
        {
            if (PeriodID > 0 && PeriodID < periods.Count)
            {
                PfEPeriod period = periods[PeriodID - 1];
                return period.StartDate;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        private static PfECostCategory MapToCostCategory(int lWResID, int lCatUID, string majorcategory,
                                                Dictionary<int, PfECostCategory> costcategories,
                                                Dictionary<int, EPKItem> majorcategories,
                                                Dictionary<int, int> xrefs,
                                                PfEAdmin admininfo)
        {
            PfECostCategory oCat = null;
            int nCat;

            if (costcategories == null || costcategories.Count == 0) return oCat;

            if (lCatUID > 0)
            {
                // we already know the Category but need to come here to consider MajorCategory
                nCat = lCatUID;
            }
            else
            {
                if (xrefs == null || xrefs.Count == 0) return oCat;
                // get resource category - category not cost category
                if (xrefs.ContainsKey(lWResID))
                {
                    nCat = xrefs[lWResID];
                }
                else
                {
                    // not dealing initially with DEFAULT resource category (can we specify that in WE?)
                    return oCat;
                }
            }

            // figure out the effect of Major Category
            // if this MC not specified or not in lookup then use 'blank' MC leg, if that not available then use Default MC
            // failing that I guess we have to give up and return 0

            int lMCUID = 0;
            if (majorcategory.Length > 0)
            {
                foreach (KeyValuePair<int, EPKItem> oItem in majorcategories)
                {
                    if (oItem.Value.Name.ToUpper() == majorcategory.ToUpper())
                    {
                        lMCUID=oItem.Value.ID;
                        break;
                    }
                }
            }

            // find Cost Category with correct majorcategory - if it is available
            int nCCat = 0;
            foreach (KeyValuePair<int, PfECostCategory> costcategory in costcategories)
            {
                if (costcategory.Value.category == nCat && costcategory.Value.majorcategory == lMCUID)
                {
                    if (costcategory.Value.available == 1)
                    {
                        nCCat = costcategory.Value.UID;
                        oCat = costcategory.Value;
                    }
                    break;
                }
            }
            // if not there ( or not available) then use Default MC if that exists and is available
            if (nCCat == 0)
            {
                foreach (KeyValuePair<int, PfECostCategory> costcategory in costcategories)
                {
                    if (costcategory.Value.category == nCat && costcategory.Value.majorcategory == admininfo.MCDefault)
                    {
                        if (costcategory.Value.available == 1)
                        {
                            nCCat = costcategory.Value.UID;
                            oCat = costcategory.Value;
                        }
                        break;
                    }
                }
            }

            return oCat;
        }

        private static StatusEnum GetXrefs(DBAccess dba, Dictionary<int, int> xrefs, ref string sMessage)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            try
            {
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand = "";

                sMessage = "";

                sCommand = "SELECT * FROM EPGP_COST_XREF ORDER BY WRES_ID";
                SqlCommand = new SqlCommand(sCommand, dba.Connection);
                SqlReader = SqlCommand.ExecuteReader();
                while (SqlReader.Read())
                {
                    int lWresId = DBAccess.ReadIntValue(SqlReader["WRES_ID"]);
                    int lCatId = DBAccess.ReadIntValue(SqlReader["BC_UID"]);
                    xrefs.Add(lWresId, lCatId);
                }
                SqlReader.Close();
                return eStatus;
            }
            catch (Exception ex)
            {
                //HandleException("GetTimerJobDetails", 99999, ex);
                sMessage = ex.Message;
                return StatusEnum.rsServerError;
            }

        }

        private static StatusEnum GetCostCategories(DBAccess dba, int CT_ID, Dictionary<int, PfECostCategory> costcategories, Dictionary<int, EPKItem> majorcategories, ref string sMessage)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            try
            {
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand = "";

                sMessage = "";

                // read the available cost categories so we can set that flag in the Cost Categories collection
                List<int> availableccs = new List<int>();
                sCommand = "SELECT * FROM EPGP_AVAIL_CATEGORIES WHERE CT_ID=@pCTID";
                SqlCommand = new SqlCommand(sCommand, dba.Connection);
                SqlCommand.Parameters.AddWithValue("@pCTID", CT_ID);
                SqlReader = SqlCommand.ExecuteReader();
                while (SqlReader.Read())
                {
                    int lCatId = DBAccess.ReadIntValue(SqlReader["BC_UID"]);
                    availableccs.Add(lCatId);
                }
                SqlReader.Close();

                //Get Cost Categories and also Major Categories contained in there
                PfECostCategory costcategory;
                sCommand = "SELECT BC_UID,BC_ID,BC_LEVEL,BC_NAME,MC_UID,CA_UID,BC_UOM FROM EPGP_COST_CATEGORIES ORDER BY BC_ID";
                SqlCommand = new SqlCommand(sCommand, dba.Connection);
                SqlReader = SqlCommand.ExecuteReader();
                while (SqlReader.Read())
                {
                    costcategory = new PfECostCategory();
                    costcategory.majorcategory = DBAccess.ReadIntValue(SqlReader["MC_UID"]);
                    costcategory.category = DBAccess.ReadIntValue(SqlReader["CA_UID"]);
                    costcategory.UID = DBAccess.ReadIntValue(SqlReader["BC_UID"]);
                    costcategory.ID = costcategories.Count+1;
                    costcategory.level = DBAccess.ReadIntValue(SqlReader["BC_LEVEL"]);
                    costcategory.name = DBAccess.ReadStringValue(SqlReader["BC_NAME"]);
                    costcategory.UOM = DBAccess.ReadStringValue(SqlReader["BC_UOM"]);

                    if (availableccs.Contains(costcategory.UID)) costcategory.available = 1;

                    if (!costcategories.ContainsKey(costcategory.UID))
                    {
                        costcategories.Add(costcategory.UID, costcategory);
                    }
                    else
                    {
                        return StatusEnum.rsRequestCannotBeCompleted;  // must be duplicate BC_UID - BAD!
                    }
                    if (!majorcategories.ContainsKey(costcategory.majorcategory))
                    {
                        EPKItem oItem = new EPKItem();
                        oItem.ID = costcategory.majorcategory;
                        majorcategories.Add(costcategory.majorcategory, oItem);
                    }
                }
                SqlReader.Close();

                //   get names for the major categories we've hit
                sCommand = "Select * From EPGP_LOOKUP_VALUES Where LOOKUP_UID=(Select ADM_MC_LOOKUP From EPG_ADMIN)";
                SqlCommand = new SqlCommand(sCommand, dba.Connection);
                SqlReader = SqlCommand.ExecuteReader();
                while (SqlReader.Read())
                {
                    int lMCUID = DBAccess.ReadIntValue(SqlReader["LV_UID"]);
                    string sMC = DBAccess.ReadStringValue(SqlReader["LV_VALUE"]);

                    foreach (KeyValuePair<int, EPKItem> oItem in majorcategories)
                    {
                        if (oItem.Value.ID == lMCUID)
                        {
                            oItem.Value.Name = sMC.ToUpper();
                            break;
                        }
                    }
                }
                SqlReader.Close();

                return eStatus;
            }
            catch (Exception ex)
            {
                //HandleException("GetTimerJobDetails", 99999, ex);
                sMessage = ex.Message;
                return StatusEnum.rsServerError;
            }
        }

        private static StatusEnum GetCostCategoryRates(DBAccess dba, int CB_ID, Dictionary<int, Dictionary<int,double>> rates, ref string sMessage)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            try
            {
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand = "";

                sMessage = "";

                // each entry in the rates dictionary is a dictionary of period rates - indexed by BC_UID
                Dictionary<int, double> periodrates = null;
                int BCUID;
                int prevBCUID=0;
                int period;
                double rate;
                sCommand = "SELECT BA_BC_UID,BA_PRD_ID,BA_RATE"
                            + " FROM EPGP_COST_BREAKDOWN_ATTRIBS WHERE CB_ID=@pCBID And BA_RATETYPE_UID=0 and BA_CODE_UID=0"
                            + " ORDER BY BA_BC_UID,BA_PRD_ID";
                SqlCommand = new SqlCommand(sCommand, dba.Connection);
                SqlCommand.Parameters.AddWithValue("@pCBID", CB_ID);
                SqlReader = SqlCommand.ExecuteReader();
                while (SqlReader.Read())
                {
                    BCUID = DBAccess.ReadIntValue(SqlReader["BA_BC_UID"]);
                    period = DBAccess.ReadIntValue(SqlReader["BA_PRD_ID"]);
                    rate = DBAccess.ReadDoubleValue(SqlReader["BA_RATE"]);

                    if (BCUID != prevBCUID)
                    {
                        if (periodrates != null && periodrates.Count > 0)
                        {
                            rates.Add(prevBCUID, periodrates);
                        }
                        periodrates = new Dictionary<int, double>();
                    }
                    prevBCUID = BCUID;
                    periodrates.Add(period, rate);

                }
                SqlReader.Close();
                if (periodrates != null && periodrates.Count > 0)
                {
                    rates.Add(prevBCUID, periodrates);
                }
                return eStatus;
            }
            catch (Exception ex)
            {
                //HandleException("GetTimerJobDetails", 99999, ex);
                sMessage = ex.Message;
                return StatusEnum.rsServerError;
            }
        }

        private static bool GetRate(PfENamedRates namedrates, Dictionary<int, Dictionary<int, double>> categoryrates, int costcategory, int lWresID, int periodid, DateTime startdate, out double dblRate, out double dblOvertimeRate)
        {
            dblRate = 0;
            dblOvertimeRate = 0;

            // if resource specified and it has a rate use that
            bool bfoundresourcerate = false;
            if (lWresID > 0)
            {
                if (namedrates.resourcerates.ContainsKey(lWresID))
                {
                    int lRTUID=namedrates.resourcerates[lWresID];
                    if (namedrates.rates.ContainsKey(lRTUID))
                    {
                        List<PfENamedRate> ratevalues = namedrates.rates[lRTUID];
                        bfoundresourcerate = true;
                        bool bfirstrate = true;
                        foreach (PfENamedRate rate in ratevalues)
                        {
                            if (bfirstrate)
                            {
                                bfirstrate = false;
                                dblRate = rate.rate;
                                dblOvertimeRate = rate.overtimerate;
                            }
                            else
                            {
                                if (startdate < rate.effectivedate) break;
                                dblRate = rate.rate;
                                dblOvertimeRate = rate.overtimerate;
                            }
                        }
                    }
                }
            }
            // if no resource rate then use Cost Category rate
            if (!bfoundresourcerate && costcategory > 0)
            {
                if (categoryrates.ContainsKey(costcategory))
                {
                    Dictionary<int, double> categoryratetable = categoryrates[costcategory];
                    if (categoryratetable.ContainsKey(periodid))
                    {
                        dblRate = categoryratetable[periodid];
                        dblOvertimeRate = dblRate;
                    }
                }
            }
            return true;
        }

        private static StatusEnum GetNamedRates(DBAccess dba, ref PfENamedRates namedrates, ref string sMessage)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            namedrates.rates=new Dictionary<int,List<PfENamedRate>>();
            namedrates.resourcerates = new Dictionary<int, int>();
            try
            {
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand = "";

                sMessage = "";

                // each entry in the rates dictionary is a list of rate values - indexed by rate UID and ordered by effective date
                List<PfENamedRate> rates = null;
                int RTUID;
                int prevRTUID = 0;
                DateTime startdate;
                double rate;
                double overtimerate;

                sCommand = "Select rc.RT_UID,RT_EFFECTIVE_DATE,RT_RATE,RT_OVERTIME_RATE"
                            + " From EPG_RATE_VALUES rv"
                            + " left join EPG_RATES rc On rc.RT_UID=rv.RT_UID"
                            + " ORDER BY RT_ID,RT_EFFECTIVE_DATE";
                SqlCommand = new SqlCommand(sCommand, dba.Connection);
                SqlReader = SqlCommand.ExecuteReader();
                while (SqlReader.Read())
                {
                    RTUID = DBAccess.ReadIntValue(SqlReader["RT_UID"]);
                    startdate = DBAccess.ReadDateValue(SqlReader["RT_EFFECTIVE_DATE"]);
                    rate = DBAccess.ReadDoubleValue(SqlReader["RT_RATE"]);
                    overtimerate = DBAccess.ReadDoubleValue(SqlReader["RT_OVERTIME_RATE"]);

                    if (RTUID != prevRTUID)
                    {
                        if (rates != null)
                        {
                            namedrates.rates.Add(prevRTUID, rates);
                            rates = new List<PfENamedRate>();
                        }
                        prevRTUID = RTUID;
                    }
                    if (rates == null) rates = new List<PfENamedRate>();
                    PfENamedRate ratevalue = new PfENamedRate();
                    ratevalue.effectivedate = startdate;
                    ratevalue.rate = rate;
                    ratevalue.overtimerate = overtimerate;
                    rates.Add(ratevalue);
                }
                if (rates != null) namedrates.rates.Add(prevRTUID, rates);
                SqlReader.Close();

                sCommand = "SELECT * FROM EPGP_COST_RATES";
                SqlCommand = new SqlCommand(sCommand, dba.Connection);
                SqlReader = SqlCommand.ExecuteReader();
                while (SqlReader.Read())
                {
                    int lWresId = DBAccess.ReadIntValue(SqlReader["WRES_ID"]);
                    int lRateId = DBAccess.ReadIntValue(SqlReader["RT_UID"]);
                    namedrates.resourcerates.Add(lWresId, lRateId);
                }
                SqlReader.Close();

                return eStatus;
            }
            catch (Exception ex)
            {
                //HandleException("GetTimerJobDetails", 99999, ex);
                sMessage = ex.Message;
                return StatusEnum.rsServerError;
            }
        }

        private static StatusEnum GetAdminInfo(DBAccess dba, PfEAdmin admininfo)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            try
            {
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand = "";

                sCommand = "SELECT ADM_MC_DEFAULT FROM EPG_ADMIN";
                SqlCommand = new SqlCommand(sCommand, dba.Connection);
                SqlReader = SqlCommand.ExecuteReader();
                if (SqlReader.Read())
                {
                    PfEPeriod period = new PfEPeriod();
                    admininfo.MCDefault = DBAccess.ReadIntValue(SqlReader["ADM_MC_DEFAULT"]);
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

        private static StatusEnum SetDefaultMC(PfEAdmin admininfo, Dictionary<int, EPKItem> majorcategories)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;
            try
            {
                foreach (KeyValuePair<int, EPKItem> oItem in majorcategories)
                {
                    if (oItem.Value.ID == admininfo.MCDefault)
                    {
                        admininfo.sMCDefault = oItem.Value.Name;
                        break;
                    }
                }
                return eStatus;
            }
            catch (Exception ex)
            {
                //HandleException("GetTimerJobDetails", 99999, ex);
                return StatusEnum.rsServerError;
            }
        }

        private static bool Rollup(double [,] quantity, double [,] cost, Dictionary<int, PfECostCategory> costcategories)
        {
            // prepare the data we've accumulated for writing out
            PfECostCategory oCat = null;
            int nCat;

            // need to generate ParentUIDs and so on but also this shows how rolllup done for CopyCostValues - LOOK AT IT

            //int[] ParentUIDs = new int[nMaxLevel + 1];
            //foreach (KeyValuePair<int, CostCategoryInternal> costcategoryentry in costcategories)
            //{
            //    CostCategoryInternal costcategory = costcategoryentry.Value;
            //    ParentUIDs[costcategory.Level] = costcategory.UID;
            //    if (costcategory.Level > 1) costcategory.ParentUID = ParentUIDs[costcategory.Level - 1];
            //}
            //ParentUIDs = null;

            //// 'Roll up' the UOM values to determine when the quantities will be rolled up - if only one UOM used then always roll up

            //// Rollup UOMs to summary lines without UOM - set to NO if childs with diff UOMs - only consider categories available for this CT
            ////    This means that if a summary contains > 1 UOM it won't rollup even if the summary UOM is set to one of the values - TOUGH!

            //string sTotalUoM = "@@@@";
            //if (!bsingleUOM)  // if only one UOM can always roll up
            //{
            //    for (int i = lCategoryCount - 1; i >= 0; i--)
            //    {
            //        int categoryUID = costcategoriesindex[i];
            //        CostCategoryInternal costcategory = costcategories[categoryUID];

            //        if (costcategory.IsAvailable)
            //        {
            //            string sUOM = costcategory.RollupUOM;   // final determined UOM for this line as children already handled
            //            if (costcategory.ParentUID == 0)
            //            {
            //                // this is a level 1 Category so check UOM against Total line UoM
            //                if (sTotalUoM == "@@@@") sTotalUoM = sUOM; else if (sTotalUoM != sUOM) sTotalUoM = "@@NO@@";
            //            }
            //            else
            //            {
            //                // rollup UOM all the way up to level 1
            //                while (costcategory.ParentUID > 0)
            //                {
            //                    costcategory = costcategories[costcategory.ParentUID];
            //                    if (costcategory.RollupUOM == "") costcategory.RollupUOM = sUOM; else if (costcategory.RollupUOM != sUOM) costcategory.RollupUOM = "@@NO@@";
            //                }
            //            }
            //        }
            //    }
            //}


            // will create a couple arrays to hold info for each cost category entry in the dictionary - ID in dic entry points at
            int[] catindex = new int[quantity.GetLength(0)];
            bool[] catflag = new bool[quantity.GetLength(0)];

            // need to figure parentUIDs
            int maxlevel = 0;
            foreach (KeyValuePair<int, PfECostCategory> costcategory in costcategories)
            {
                catindex[costcategory.Value.ID] = costcategory.Value.UID;  // save the indexes in my array
                costcategory.Value.flag = false;                           // flag used to make sure parents receive values correctly from children
                if (costcategory.Value.level > maxlevel) maxlevel = costcategory.Value.level;
            }
            int[] ParentUIDs = new int[maxlevel + 1];
            foreach (KeyValuePair<int, PfECostCategory> costcategory in costcategories)
            {
                ParentUIDs[costcategory.Value.level] = costcategory.Value.UID;
                if (costcategory.Value.level > 1) costcategory.Value.parentUID = ParentUIDs[costcategory.Value.level - 1];
            }
            ParentUIDs = null;

            string sSameUom = "xxFIRSTxx";
            bool ballSameUOM = true;

            // check if all level 1 entries have same UOM, if so then can roll up to the total line Note: Major Ctegories will screw this up eh?
            foreach (KeyValuePair<int, PfECostCategory> costcategory in costcategories)
            {
                if (costcategory.Value.available == 1)
                {
                    if (costcategory.Value.level == 1)
                    {
                        if (sSameUom == "xxFIRSTxx") sSameUom = costcategory.Value.UOM;
                        if (sSameUom != costcategory.Value.UOM) ballSameUOM = false;
                    }
                }
            }

            // Go through CCs bottom to top 
            for (int i = catindex.GetLength(0)-1; i > 0; i--)
            {
                PfECostCategory CT = costcategories[catindex[i]];
                PfECostCategory parentCT = null;
                if (CT.parentUID > 0) parentCT = costcategories[CT.parentUID];

                if (CT.available == 1)
                {
                    int thisindex = i;   //  sb same as CT.ID
                    int parentindex = 0;
                    if (parentCT != null) parentindex = parentCT.ID;
                    int numperiods = quantity.GetLength(1);

                    if (parentindex > 0)
                    // Roll up this CC to the parent for each period
                    {
                        for (int j = 1; j < numperiods; j++)
                        {
                            // Mark and prepre a parent to receive values from this and other children 
                            //  not quite sure why it does this, one effect is to make sure no tabulated values exist on a parent node
                            if (parentCT.flag == false && (cost[thisindex, j] != 0 || quantity[thisindex, j] != 0))
                            {
                                parentCT.flag = true;
                                for (int k = 1; k < numperiods; k++)
                                {
                                    cost[parentindex, k] = 0;
                                    quantity[parentindex, k] = 0;
                                }
                            }

                            cost[parentindex, j] = cost[parentindex, j] + cost[thisindex, j];
                            if (CT.UOM == parentCT.UOM)
                            {
                                quantity[parentindex, j] = quantity[parentindex, j] + quantity[thisindex, j];
                            }
                        }
                    }
                    else
                    // This CC has no parent so it is a L1	- Roll up to top only if each L1 has same UOM 
                    //       (means it will never happen if there are Major Categories as MC lines have no UOM and are at L1
                    // Could roll up the UOM from a real L1 to the MC line?
                    {
                        for (int j = 1; j < numperiods; j++)
                        {
                            cost[parentindex, j] = cost[parentindex, j] + cost[thisindex, j];
                            if (ballSameUOM == true)
                            {
                                quantity[parentindex, j] = quantity[parentindex, j] + quantity[thisindex, j];
                            }
                        }
                    }
                }
            }
            return true;
        }

        private static void WriteToDatabaseThisPI(DBAccess dba, int ProjectID, int nCB_ID, int nCT_ID,
                                                    bool allPIs, ref bool firsttimethrough,
                                                    double[,] quantity, double[,] cost, Dictionary<int, PfECostCategory> costcategories)
        {
            SqlCommand oCommand;
            string cmdText;

            string swhereclause;
            dba.BeginTransaction();

            // clear all existing values and write out new ones, all at once when for allPIs
            if (!allPIs || firsttimethrough)
            {
                firsttimethrough = false;
                if (allPIs)
                {
                    swhereclause = " WHERE CB_ID=@CalID And CT_ID=@CTID";
                }
                else
                {
                    swhereclause = " WHERE CB_ID=@CalID And CT_ID=@CTID And PROJECT_ID=@ProjectID";
                }
                cmdText = "DELETE FROM  EPGP_COST_VALUES" + swhereclause;
                oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();

                cmdText = "DELETE FROM  EPGP_DETAIL_VALUES" + swhereclause;
                oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();

                cmdText = "DELETE FROM  EPGP_COST_DETAILS" + swhereclause;
                oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();

                if (allPIs)
                {
                    swhereclause = " WHERE CB_ID=@CalID And CT_ID=@CTID";
                    cmdText = "DELETE FROM  EPGP_COST_VALUES_INFO" + swhereclause;
                    oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                    oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();
                }
            }

            // Create new values 

            // set up the INSERT I need to add new records
            cmdText = "INSERT INTO EPGP_COST_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID,BD_PERIOD,BD_VALUE,BD_COST,BD_IS_SUMMARY)"
                    + " VALUES(@CalID,@CTID,@ProjectID,@BC_UID,@BD_PERIOD,@BD_VALUE,@BD_COST,@SUM_FLAG)";
            oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
            oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
            oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
            oCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlParameter pBC_UID = oCommand.Parameters.Add("@BC_UID", SqlDbType.Int);
            SqlParameter pBD_PERIOD = oCommand.Parameters.Add("@BD_PERIOD", SqlDbType.Int);
            SqlParameter pBD_VALUE = oCommand.Parameters.Add("@BD_VALUE", SqlDbType.Decimal);
            SqlParameter pBD_COST = oCommand.Parameters.Add("@BD_COST", SqlDbType.Decimal);
            SqlParameter pSUM_FLAG = oCommand.Parameters.Add("@SUM_FLAG", SqlDbType.Int);
            pBD_VALUE.Precision = 25;
            pBD_VALUE.Scale = 6;
            pBD_COST.Precision = 25;
            pBD_COST.Scale = 6;

            // go through each Cost Category
            int numperiods = quantity.GetLength(1);
            foreach (KeyValuePair<int, PfECostCategory> costcategory in costcategories)
            {

                int catindex = costcategory.Value.ID;
                if (costcategory.Value.available == 1)
                {
                    for (int j = 1; j < numperiods; j++)
                    {
                        double dQuantity = quantity[catindex, j];
                        double dCost = cost[catindex, j];
                        if (dQuantity != 0 || dCost != 0)
                        {
                            pBC_UID.Value = costcategory.Value.UID;
                            pBD_PERIOD.Value = j;
                            pBD_VALUE.Value = dQuantity;
                            pBD_COST.Value = dCost;
                            if (costcategory.Value.flag == true) pSUM_FLAG.Value = 1; else pSUM_FLAG.Value = 0;
                            oCommand.ExecuteNonQuery();
                        }
                    }
                }
            }

            // write out the TOTAL line 
            {
                for (int j = 1; j < numperiods; j++)
                {
                    double dQuantity = quantity[0, j];
                    double dCost = cost[0, j];
                    if (dQuantity != 0 || dCost != 0)
                    {
                        pBC_UID.Value = 0;
                        pBD_PERIOD.Value = j;
                        pBD_VALUE.Value = dQuantity;
                        pBD_COST.Value = dCost;
                        pSUM_FLAG.Value = 1;
                        oCommand.ExecuteNonQuery();
                    }
                }
            }
            dba.CommitTransaction();

            // write n INFO record if appropriate
            if (allPIs)
            {
                cmdText = "INSERT INTO EPGP_COST_VALUES_INFO (CB_ID,CT_ID,CV_INFO,CV_TIMESTAMP)"
                        + " VALUES(@CalID,@CTID,@INFO,GETDATE())";
                oCommand = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                oCommand.Parameters.AddWithValue("@CalID", nCB_ID);
                oCommand.Parameters.AddWithValue("@CTID", nCT_ID);
                oCommand.Parameters.AddWithValue("@INFO", "Post Cost Values");

                oCommand.ExecuteNonQuery();
            }

            return;
        }

        private static bool SetCostTotals(DBAccess dba, int ProjectID, int nCB_ID, int nCT_ID)
        {
            SqlCommand oCommand;

            bool bTotalUpdated = false;

            oCommand = new SqlCommand("EPG_SP_ReadCostTotals", dba.Connection);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            dataTable.Load(oCommand.ExecuteReader());
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    int lCB_ID = DBAccess.ReadIntValue(row["CB_ID"]);
                    int lCT_ID = DBAccess.ReadIntValue(row["CT_ID"]);
                    int lField_ID = DBAccess.ReadIntValue(row["BUDGET_TOTAL_FIELD"]);
                    if (lCB_ID == nCB_ID && lCT_ID == nCT_ID)
                    {
                        bTotalUpdated = UpdateCostTotal(dba, ProjectID, nCB_ID, nCT_ID, lField_ID);
                    }
                }
            }
            dataTable.Dispose();

            return bTotalUpdated;
        }
        
        private static bool UpdateCostTotal(DBAccess dba, int ProjectID, int nCB_ID, int nCT_ID, int nField_ID)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;

            // ProjectID = 0 means allPIs

            if(nField_ID < 20000 || nCB_ID < 0 || nCT_ID <= 0) return false;

            int lTableID = 0;
            int lFieldInTableID = 0;
            oCommand = new SqlCommand("EPG_SP_ReadFieldInfo", dba.Connection);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            oCommand.Parameters.AddWithValue("@FieldID", nField_ID);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                lTableID = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                lFieldInTableID = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
            }
            reader.Close();

            if (lTableID <= 0 || lFieldInTableID <= 0) return false;

            string tableName;
            string fieldName;
            Common.CalculateTableFieldName(lFieldInTableID, lTableID, out tableName, out fieldName);

            // get editmode for the CT
            int lEditMode = -1;
            cmdText = "SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=@CT_ID";
            oCommand = new SqlCommand(cmdText, dba.Connection);
            oCommand.Parameters.AddWithValue("@CT_ID", nCT_ID);
            reader = oCommand.ExecuteReader();
            if (reader.Read())
            {
                lEditMode = DBAccess.ReadIntValue(reader["CT_EDIT_MODE"]);
            }
            reader.Close();
                    
            // first zeroize all Cost values and then set from COST VALUES
               
            //  we are going to deal differently with CTs populated by the user rather than entered in EPK
            //     Assuming summary values NOT there when entered by the user
            //   so use TOTAL row except for user entered directly to DBS where we total ALL rows where IS_SUMMARY field is 0 to avoid summary rows even if there

            int lAffectedRows = 0;
            if (ProjectID == 0)
            {
                cmdText = "Update " + tableName + " SET " + fieldName + "=0";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                lAffectedRows = oCommand.ExecuteNonQuery();

                cmdText = "Update " + tableName + " SET " + fieldName + "=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES"
                                + " WHERE  (CB_ID=@CB_ID AND CT_ID=@CT_ID";
                if (lEditMode == 0 || lEditMode == 101)
                {
                    cmdText += " AND BD_IS_SUMMARY=0";
                }
                else
                {
                    cmdText += " AND BC_UID=0";
                }
                cmdText += ") AND (" + tableName + ".PROJECT_ID=PROJECT_ID))";

                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@CB_ID", nCB_ID);
                oCommand.Parameters.AddWithValue("@CT_ID", nCT_ID);
                lAffectedRows= oCommand.ExecuteNonQuery();
            }
            else
            {
                cmdText = "Update " + tableName + " SET " + fieldName + "=0 Where PROJECT_ID=@ProjID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@ProjID", ProjectID);
                lAffectedRows = oCommand.ExecuteNonQuery();

                cmdText = "Update " + tableName + " SET " + fieldName + "=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES"
                                + " WHERE  (CB_ID=@CB_ID AND CT_ID=@CT_ID";
                if (lEditMode == 0 || lEditMode == 101)
                {
                    cmdText += " AND BD_IS_SUMMARY=0";
                }
                else
                {
                    cmdText += " AND BC_UID=0";
                }
                cmdText += ") AND (" + tableName + ".PROJECT_ID=PROJECT_ID))";

                cmdText += " Where PROJECT_ID=@ProjID";

                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@CB_ID", nCB_ID);
                oCommand.Parameters.AddWithValue("@CT_ID", nCT_ID);
                oCommand.Parameters.AddWithValue("@ProjID", ProjectID);
                lAffectedRows = oCommand.ExecuteNonQuery();
            }
            return true;
        }

        private static bool GetAutoPosts(DBAccess dba, string datatype, ref int[,] autoposts)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            string cmdText;

            int larrayindex = 0;
            int lmainkey = -1;
            if (datatype.ToUpper() == "TIMESHEETS") {lmainkey=31;}
            else if (datatype.ToUpper() == "RESOURCEPLANS") { lmainkey = 1; }

            cmdText = "SELECT CT_ID,CB_ID From EPGP_COST_VALUES_TOSET Where TOSET_MAINKEY=@mainkey";
            oCommand = new SqlCommand(cmdText, dba.Connection);
            oCommand.Parameters.AddWithValue("@mainkey", lmainkey);
            reader = oCommand.ExecuteReader();
            if (reader.Read())
            {
                if (autoposts.GetUpperBound(0) >= larrayindex)
                {
                    autoposts[larrayindex, 0] = DBAccess.ReadIntValue(reader["CT_ID"]);
                    autoposts[larrayindex, 1] = DBAccess.ReadIntValue(reader["CB_ID"]);
                }
                larrayindex ++;
            }
            reader.Close();

            return true;
        }


        private static string FormatError(DBAccess dba, int nCB_ID, int nCT_ID, string sMessage)
        {
            string sErrorReply = "For Calendar=" + nCB_ID.ToString() + ", Cost Type=" + nCT_ID.ToString() + " - " + sMessage;
            dba.WriteImmTrace("PfECore", "PostCostValues", "Failure", sErrorReply);
            return sErrorReply;
        }

        private class PfEAdmin
        {
            public int MCDefault;
            public string sMCDefault;  // not sure we need this - text for default MC
            public int XrefDefault;  // think this should be changed to an entry in EPG_ADMIN and set on RPAdmin page?
        }

        private class PfEPeriod
        {
            public string PeriodName;
            public int PeriodID;
            public DateTime StartDate;
            public DateTime FinishDate;
        }

        private class PfECostCategory
        {
            public int majorcategory;
            public int category;
            public int UID;
            public int ID;
            public int level;
            public string name;
            public string UOM;
            public int available;
            public int parentUID;
            public bool flag;
        }

        private class PfENamedRate
        {
            public DateTime effectivedate;
            public double rate;
            public double overtimerate;
        }

        private class PfENamedRates
        {
            public Dictionary<int, List<PfENamedRate>> rates;  //cln for each named rate
            public Dictionary<int, int> resourcerates;  // named rates specified for resources
        }

    }
}
