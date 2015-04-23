using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace PortfolioEngineCore
{
    public class AdminFunctions : PFEBase
    {
        
        public AdminFunctions(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading AdminFunctions Class");
        }

        public AdminFunctions(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading AdminFunctions Class");
        }

        public bool HandleRequest(string sRequest, out string sReply)
        {
            sReply = "";
            try
            {
                if (_dba.Open() != StatusEnum.rsSuccess)
                    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());
                CStruct xInputData = new CStruct();
                if (xInputData.LoadXML(sRequest) == true)
                {
                    CStruct xDataInputElement = xInputData.GetSubStruct("Data");
                    if (xDataInputElement == null) throw new Exception("Cannot find the data element.");

                    // Determine fn to call here and for each one initialize the correct class in PortfolioEngineCore and call it - eg Capacity.cs
                    string sFunction = xDataInputElement.GetStringAttr("Function");
                    switch (sFunction)
                    {
                        case "CalcCategoryRates":
                            return CalcCategoryRates(_dba, out sReply);
                        case "CalcDefaultFTEs":
                            return CalcAllDefaultFTEs(_dba);
                        case "CalcRPAllAvailabilities":
                            return CalcRPAllAvailabilities(_dba);
                        case "SaveReportingConnection":
                            return SaveReportingConnection(xDataInputElement);
                        case "SubmitReportExtract":
                            return SubmitReportExtract(xDataInputElement.XML());
                        default:
                            break;
                    }
                }
                else
                {
                    sReply = HandleError("HandleRequest", Status, FormatErrorText());
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("HandleRequest", 99999, ex);
            }
            finally { _dba.Close(); }
            return (_dba.Status == StatusEnum.rsSuccess);
        }


        public static bool CalcCategoryRates(DBAccess dba, out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            StatusEnum eStatus = StatusEnum.rsSuccess;
            string sCommand;
            
            bool bResult = false;
            sReply = "";
            try
            {
                CategoryRate categoryrate;
                List<CategoryRate> rates = new List<CategoryRate>();
                Dictionary<int, List<CategoryRate>> categoryrates = new Dictionary<int, List<CategoryRate>>();
                
                try
                {
                    sCommand = "SELECT * FROM EPG_COST_CATEGORY_RATE_VALUES Order By BC_UID,BC_EFFECTIVE_DATE";
                    oCommand = new SqlCommand(sCommand, dba.Connection);
                    reader = oCommand.ExecuteReader();

                    int prevuid = 0;
                    while (reader.Read())
                    {
                        int nBCUID = DBAccess.ReadIntValue(reader["BC_UID"]);
                        DateTime dEffectiveDate = DBAccess.ReadDateValue(reader["BC_EFFECTIVE_DATE"]);
                        double dRate = DBAccess.ReadDoubleValue(reader["BC_RATE"]);
                        double dOvertimeRate = DBAccess.ReadDoubleValue(reader["BC_OVERTIME_RATE"]);

                        if (prevuid > 0 && prevuid != nBCUID)
                        {
                            categoryrates.Add(prevuid, rates);
                            rates = null;
                        }
                        if (rates == null) rates = new List<CategoryRate>();
                        prevuid = nBCUID;
                        categoryrate = new CategoryRate();
                        categoryrate.UID = prevuid;
                        categoryrate.EffectiveDate = dEffectiveDate;
                        categoryrate.Rate = dRate;
                        categoryrate.OvertimeRate = dOvertimeRate;
                        rates.Add(categoryrate);
                    }
                    if (rates != null && rates.Count > 0) categoryrates.Add(prevuid, rates);
                }
                catch (Exception ex)
                {
                    return true;   // thinking an error here will be because the rates table added in X5 doesn't exist and we want to leave the existing Periodic rates alone w/o error
                }
                reader.Close();

                if (categoryrates.Count == 0) return true;    //  no rates found - don't do anything - will leave old Periodic Rates as is

                //  read list of calendars
                sCommand = "SELECT * FROM EPGP_COST_BREAKDOWNS";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                reader = oCommand.ExecuteReader();

                List<int> calendars = new List<int>();
                while (reader.Read())
                {
                    int nCalID = DBAccess.ReadIntValue(reader["CB_ID"]);
                    calendars.Add(nCalID);
                }
                reader.Close();

                //  read list of Cost Categories that are added because of Major Categories and therefore have no separate rate values - Dic entry contains list for each category
                sCommand = "Select CA_UID,BC_UID From EPGP_COST_CATEGORIES Where CA_UID>0 And CA_UID<>BC_UID Order By CA_UID";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                reader = oCommand.ExecuteReader();

                Dictionary<int,List<int>> listccs = new Dictionary<int,List<int>>();
                List<int> ccs=new List<int>();
                int prevCA_UID = 0;
                while (reader.Read())
                {
                    int nCA_UID = DBAccess.ReadIntValue(reader["CA_UID"]);
                    int nBC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    if (prevCA_UID > 0 && prevCA_UID != nCA_UID)
                    {
                        listccs.Add(prevCA_UID, ccs);
                        ccs = null;
                    }
                    if (ccs == null) ccs = new List<int>();
                    prevCA_UID = nCA_UID;
                    ccs.Add(nBC_UID);
                }
                if (ccs != null && ccs.Count > 0) listccs.Add(prevCA_UID, ccs); 
                reader.Close();

                Dictionary<int, Dictionary<int, PfEItem>> periodrates;  // set as a list of category rates for each period
                Dictionary<int, PfEItem> catrates;
                
                foreach (int nCalID in calendars)
                {
                    // create a dictionary containing rates for each period for this calendar
                    sCommand = "SELECT PRD_ID,PRD_START_DATE FROM EPG_PERIODS Where CB_ID=@CalID Order by PRD_ID";
                    oCommand = new SqlCommand(sCommand, dba.Connection);
                    oCommand.Parameters.AddWithValue("@CalID", nCalID);
                    reader = oCommand.ExecuteReader();

                    periodrates = new Dictionary<int, Dictionary<int, PfEItem>>();
                    while (reader.Read())
                    {
                        int nPrdID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        DateTime dStartDate = DBAccess.ReadDateValue(reader["PRD_START_DATE"]);
                        catrates = new Dictionary<int, PfEItem>();
                        foreach (KeyValuePair<int, List<CategoryRate>> category in categoryrates)
                        {
                            PfEItem rateitem = new PfEItem();
                            rateitem.UID = category.Key;
                            List<CategoryRate> ratelist = category.Value;
                            rateitem.dValue1 = GetPeriodRate(dStartDate, rateitem.UID, ratelist);
                            // after first attempt at migration the following stmnt failed because we're adding the Cost Categories because of Major Cateories below but then also reading from rates the migration created - need to settle
                            catrates.Add(rateitem.UID, rateitem);
                            // add copies of the rate tables for Cost Categories from Major Categories
                            if (listccs.ContainsKey(rateitem.UID))
                            {
                                foreach (int cc in listccs[rateitem.UID])
                                {
                                    catrates.Add(cc, rateitem);
                                }
                            }
                        }
                        periodrates.Add(nPrdID, catrates);
                    }
                    reader.Close();

                    // we're ready to read old records and update
                    bool bupdateOK = true;
                    dba.BeginTransaction();
                    sCommand = "Select CB_ID,BA_BC_UID,BA_PRD_ID,BA_RATE From EPGP_COST_BREAKDOWN_ATTRIBS Where CB_ID=@CB_ID And BA_RATETYPE_UID=0 And BA_CODE_UID=0";
                    oCommand = new SqlCommand(sCommand, dba.Connection,dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CB_ID", nCalID);
                    DataTable dataTable = new DataTable();
                    dataTable.Load(oCommand.ExecuteReader());

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int bcuid = DBAccess.ReadIntValue(row["BA_BC_UID"]);
                            int prdid = DBAccess.ReadIntValue(row["BA_PRD_ID"]);
                            double oldrate = DBAccess.ReadIntValue(row["BA_RATE"]);

                            if (periodrates.ContainsKey(prdid))
                            {
                                catrates = periodrates[prdid];  // does this contain every category? No only those for which there is a rate - remember rates are entered for Categories NOT Cost Categories
                                
                                double newrate = 0;
                                if (catrates.ContainsKey(bcuid))    // this is wrong because new rates entered for Categories where as old Category Rates entered for Cost Categories
                                {
                                    PfEItem rateitem = catrates[bcuid];
                                    rateitem.bflag = true;
                                    newrate = rateitem.dValue1;
                                    if (newrate != oldrate)
                                    {
                                        row["BA_RATE"] = newrate;
                                    }
                                }
                            }
                            else
                            {
                                //  period doesn't exist delete record
                                //  row.Delete();  // this idea doesn't work the way I've done it - this shouldn't happen, if it does then modify general cleanup at the botttom here
                            }
                        }
                        //  apply updates to dbs
                        if (bupdateOK)
                        {
                            sCommand = @"Update EPGP_COST_BREAKDOWN_ATTRIBS SET BA_RATE=@rate" +
                                " Where CB_ID=@cal And BA_BC_UID=@cc And BA_PRD_ID=@period And BA_RATETYPE_UID=0 And BA_CODE_UID=0";
                            oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                            oCommand.CommandType = CommandType.Text;

                            SqlParameter rate = oCommand.Parameters.Add("@rate", SqlDbType.Float);
                            SqlParameter cal = oCommand.Parameters.Add("@cal", SqlDbType.Int);
                            SqlParameter cc = oCommand.Parameters.Add("@cc", SqlDbType.Int);
                            SqlParameter period = oCommand.Parameters.Add("@period", SqlDbType.Int);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row.RowState == DataRowState.Modified)
                                {
                                    rate.Value = row["BA_RATE"];
                                    cal.Value = nCalID;
                                    cc.Value = row["BA_BC_UID"];
                                    period.Value = row["BA_PRD_ID"];
                                    oCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    dataTable.Dispose();

                    //  check for inserts
                    if (bupdateOK)
                    {
                        sCommand = @"Insert Into EPGP_COST_BREAKDOWN_ATTRIBS (CB_ID,BA_RATETYPE_UID,BA_CODE_UID,BA_BC_UID,BA_PRD_ID,BA_RATE)" +
                            " Values (@cal,0,0,@cc,@period,@rate)";
                        oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                        oCommand.CommandType = CommandType.Text;

                        SqlParameter cal = oCommand.Parameters.Add("@cal", SqlDbType.Int);
                        SqlParameter cc = oCommand.Parameters.Add("@cc", SqlDbType.Int);
                        SqlParameter period = oCommand.Parameters.Add("@period", SqlDbType.Int);
                        SqlParameter rate = oCommand.Parameters.Add("@rate", SqlDbType.Float);

                        foreach (KeyValuePair<int, Dictionary<int, PfEItem>> clncatrates in periodrates)
                        {
                            foreach (KeyValuePair<int, PfEItem> catitem in clncatrates.Value)
                            {
                                if (catitem.Value.bflag == false)
                                {
                                    if (catitem.Value.dValue1 > 0)  // don't write out rows with nothing in there
                                    {
                                        cal.Value = nCalID;
                                        cc.Value = catitem.Value.UID;
                                        period.Value = clncatrates.Key;
                                        rate.Value = catitem.Value.dValue1;
                                        oCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    if (bupdateOK) dba.CommitTransaction();
                }

                //  execute a delete to clear out possible left overs where a rate was deleted and there is no FTE either
                //    (?) this means any rates left over or entered in old Calendar page will remain there - which is what we want for now at least
                {
                    sCommand = @"Delete From EPGP_COST_BREAKDOWN_ATTRIBS" +
                        " Where (BA_FTE_CONV = 0 Or BA_FTE_CONV is NULL) And (BA_RATE = 0 Or BA_RATE is NULL)";
                    oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();

                    // might as well run a clean up just in case
                    sCommand = @"Delete From EPGP_COST_BREAKDOWN_ATTRIBS" +
                       " Where BA_BC_UID Not in (Select BC_UID From EPGP_COST_CATEGORIES) or CB_ID Not in (Select CB_ID From EPGP_COST_BREAKDOWNS)";
                    oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("CalcCategoryRates", 99999, ex);
                return false;
            }
            bResult = (dba.Status == StatusEnum.rsSuccess);
            if (bResult == false)
            {
                sReply = HandleError("CalcCategoryRates", (int)dba.Status, dba.FormatErrorText());
            }
            return bResult;
        }

        public bool CalcAvailabilities(int calendar, string reslist)
        {
            if (!string.IsNullOrEmpty(reslist))
                return CalcInternalAvailabilities(_dba, -1, reslist);
            else
                return CalcInternalAvailabilities(_dba, -1, "");
        }

        public static bool CalcRPAllAvailabilities(DBAccess dba)
        {
            return CalcInternalAvailabilities(dba, -1, "");
        }

        public static bool CalcInternalAvailabilities(DBAccess dba, int calendar, string reslist)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            StatusEnum eStatus = StatusEnum.rsSuccess;
            string sCommand;

            dba.DBTrace((StatusEnum)0, (TraceChannelEnum)0, "CalculateAvailabilities", "CalcInternalAvailabilities", "start calendar : " + calendar.ToString() + "; reslist : " + reslist, "", true);

            //if (_dba.Open() != StatusEnum.rsSuccess)
            //    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            bool bResult = false;
            string sReply = "";

            try
            {
                if(dba.Connection.State != ConnectionState.Open)
                    dba.Connection.Open();

                if (calendar < 0)
                {
                    sCommand = "SELECT ADM_PORT_COMMITMENTS_CB_ID FROM EPG_ADMIN";
                    oCommand = new SqlCommand(sCommand, dba.Connection);
                    reader = oCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        calendar = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_CB_ID"]);
                    }
                    reader.Close();
                }
                if (calendar < 0) return false;

                // grab the Periods for the selected calendar
                sCommand = "SELECT PRD_ID,PRD_START_DATE,PRD_FINISH_DATE FROM EPG_PERIODS WHERE CB_ID=@CalID Order By PRD_ID";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                oCommand.Parameters.AddWithValue("@CalID", calendar);
                reader = oCommand.ExecuteReader();

                List<PfEPeriod> Periods = new List<PfEPeriod>();
                DateTime CalStart = new DateTime(1900, 01, 01), CalEnd = new DateTime(1900, 01, 01);
                bool bFirst = true;
                while (reader.Read())
                {
                    PfEPeriod oPeriod = new PfEPeriod();
                    oPeriod.PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                    oPeriod.StartDate = DBAccess.ReadDateValue(reader["PRD_START_DATE"]);
                    oPeriod.FinishDate = DBAccess.ReadDateValue(reader["PRD_FINISH_DATE"]);
                    if (bFirst) { CalStart = oPeriod.StartDate; CalEnd = oPeriod.FinishDate; bFirst = false; }
                    CalEnd = oPeriod.FinishDate;
                    Periods.Add(oPeriod);
                }
                reader.Close();
                if (Periods.Count <= 0) return false;

                bool bisValidResourceList = true;
                if (reslist.Length > 0)
                {
                    foreach (string sList in reslist.Split(','))
                    {
                        int nWresID;
                        if (int.TryParse(sList, out nWresID) == false) { bisValidResourceList = false; break; }
                    }
                }
                if (bisValidResourceList == false) return false;

                List<PfEResource> Resources = new List<PfEResource>();
                sCommand = "Select r.WRES_ID,r.WRES_AVAILABLEFROM,r.WRES_AVAILABLETO,g1.GROUP_ID as WHGroup,g2.GROUP_ID as HolGroup" +
                            " From EPG_RESOURCES r" +
                            " Left Join EPG_GROUP_MEMBERS g1 On r.WRES_ID=g1.MEMBER_UID And (g1.GROUP_ID In (Select GROUP_ID From EPG_GROUPS Where GROUP_ENTITY=10))" +
                            " Left Join EPG_GROUP_MEMBERS g2 On r.WRES_ID=g2.MEMBER_UID And (g2.GROUP_ID In (Select GROUP_ID From EPG_GROUPS Where GROUP_ENTITY=11))";
                if (reslist.Length > 0) sCommand += " INNER JOIN dbo.EPG_FN_ConvertListToTable(N'" + reslist + "') LT on r.WRES_ID=LT.TokenVal";
                sCommand += " Where r.WRES_ID <>1 And r.WRES_INACTIVE=0 And r.WRES_IS_RESOURCE=1 And r.WRES_IS_GENERIC=0";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    PfEResource oResource = new PfEResource();
                    oResource.WresID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                    oResource.WHGroupId = DBAccess.ReadIntValue(reader["WHGroup"]);
                    oResource.HolGroupId = DBAccess.ReadIntValue(reader["HolGroup"]);
                    oResource.StartDate = DBAccess.ReadDateValue(reader["WRES_AVAILABLEFROM"]);
                    oResource.FinishDate = DBAccess.ReadDateValue(reader["WRES_AVAILABLETO"]);
                    if (oResource.StartDate < CalStart) oResource.StartDate = CalStart;
                    if (oResource.FinishDate < oResource.StartDate || oResource.FinishDate > CalEnd) oResource.FinishDate = CalEnd;
                    Resources.Add(oResource);
                }
                reader.Close();

                // set up all info on Workhours and Holidays so we can use to calculate avail amounts (we could easily make a list of the ones we need but v. unlikely to be worth bothering)
                sCommand = "Select * From EPG_GROUP_WEEKLYHOURS";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                DataTable dataTable1 = new DataTable();
                dataTable1.Load(oCommand.ExecuteReader());

                sCommand = "Select * From EPG_GROUP_NONWORK_HOURS Order By GROUP_ID,NWH_DATE";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                DataTable dataTable2 = new DataTable();
                dataTable2.Load(oCommand.ExecuteReader());

                AllWorkhours workhours = new AllWorkhours();
                workhours.Initialize(dataTable1, dataTable2);

                dataTable1.Dispose();
                dataTable2.Dispose();

                dba.BeginTransaction();

                // get rid of the old entries for the set of resources we are calculating
                if (reslist.Length > 0)
                {
                    sCommand = "Delete EPGP_CAPACITY_VALUES From EPGP_CAPACITY_VALUES" +
                                " JOIN dbo.EPG_FN_ConvertListToTable(N'" + reslist + "') LT on EPGP_CAPACITY_VALUES.WRES_ID=LT.TokenVal";
                    // used to use calendar but this fails when RP Calendar changed I guess need to delete availabilities in RP Admin - for now though there can only be one calendar in EPM Live
                    //  " JOIN dbo.EPG_FN_ConvertListToTable(N'" + reslist + "') LT on EPGP_CAPACITY_VALUES.WRES_ID=LT.TokenVal Where CB_ID=@CalID"; 
                }
                else
                {
                    sCommand = "Delete From EPGP_CAPACITY_VALUES";
                    //sCommand = "Delete From EPGP_CAPACITY_VALUES Where CB_ID=@CalID";
                }
                oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                //oCommand.Parameters.AddWithValue("@CalID", calendar);
                oCommand.CommandType = CommandType.Text;
                oCommand.ExecuteNonQuery();

                sCommand = "INSERT Into EPGP_CAPACITY_VALUES (CB_ID,BD_PERIOD,WRES_ID,CS_AVAIL,CS_OFF)" +
                                            " Values (@CalID,@PerId,@WresId,@avail,@off)"; 
                oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                oCommand.Parameters.AddWithValue("@CalID", calendar);
                SqlParameter p_per = oCommand.Parameters.Add("@PerId", SqlDbType.Int);
                SqlParameter p_res = oCommand.Parameters.Add("@WresId", SqlDbType.Int);
                SqlParameter p_avail = oCommand.Parameters.Add("@avail", SqlDbType.Float);
                SqlParameter p_off = oCommand.Parameters.Add("@off", SqlDbType.Float);

                foreach (PfEResource resource in Resources)
                {
                    foreach (PfEPeriod period in Periods)
                    {
                        if (period.FinishDate >= resource.StartDate && period.StartDate <= resource.FinishDate) // any avail in this period?
                        {
                            DateTime START = period.StartDate;
                            if (resource.StartDate > START) START = resource.StartDate;
                            DateTime FINISH = period.FinishDate;
                            if (resource.FinishDate < FINISH) FINISH = resource.FinishDate;

                            p_per.Value = period.PeriodID;
                            p_res.Value = resource.WresID;
                            p_avail.Value = workhours.workhours(resource.WHGroupId, resource.HolGroupId, START, FINISH);
                            p_off.Value = workhours.offhours(resource.WHGroupId, resource.HolGroupId, START, FINISH);
                            oCommand.ExecuteNonQuery();
                        }
                    }
                }
                dba.CommitTransaction();
                bResult = true;
            }
            catch (Exception ex)
            {
                //sReply = HandleException("CalcAvailabilities", 99999, ex);
                dba.HandleException("CalcInternalAvailabilities", (StatusEnum)99119, ex);
                throw ex;
            }
            dba.DBTrace((StatusEnum)0, (TraceChannelEnum)0, "CalculateAvailabilities", "CalcInternalAvailabilities", "Finish", "", true);
            return bResult;
        }

        public bool SaveReportingConnection(CStruct xData)
        {
            string sReply = "";
            try
            {
                string sConnection = xData.GetStringAttr("Connection");
                return ImportReportingConnection(sConnection);
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveReportingConnection", 99999, ex);
                return false;
            }
        }

        public static bool CalcAllDefaultFTEs(DBAccess dba)
        {
            return CalcDefaultFTEs(dba, -1, "");
        }

        public static bool CalcDefaultFTEs(DBAccess dba,int calendar, string catlist)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            StatusEnum eStatus = StatusEnum.rsSuccess;
            string sCommand;

            //if (_dba.Open() != StatusEnum.rsSuccess)
            //    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            bool bResult = false;
            string sReply = "";

            try
            {
                //  get specified WH and HOL info from ADMIN - if no WH then don't do anything, ok to have no HOL specified
                int lWH = 0;
                int lHOL = 0;
                sCommand = "SELECT ADM_DEF_FTE_WH,ADM_DEF_FTE_HOL FROM EPG_ADMIN";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    lWH = DBAccess.ReadIntValue(reader["ADM_DEF_FTE_WH"]);
                    lHOL = DBAccess.ReadIntValue(reader["ADM_DEF_FTE_HOL"]);
                }
                reader.Close();
                if (lWH == 0) return false;

                List<int> calendars = new List<int>();
                if (calendar < 0)
                {
                    sCommand = "SELECT CB_ID FROM EPGP_COST_BREAKDOWNS";
                    oCommand = new SqlCommand(sCommand, dba.Connection);
                    reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        calendars.Add(DBAccess.ReadIntValue(reader["CB_ID"]));
                    }
                    reader.Close();
                }
                else
                {
                    calendars.Add(calendar);
                }
                if (calendars.Count <= 0) return false;

                bool bisValidCatList = true;
                List<PfEItem> Categories = new List<PfEItem>();
                if (catlist.Length > 0)
                {
                    foreach (string sList in catlist.Split(','))
                    {
                        int nBCUID;
                        if (int.TryParse(sList, out nBCUID) == false)
                        {
                            bisValidCatList = false;
                            break;
                        }
                        else
                        {
                            PfEItem oCat = new PfEItem();
                            oCat.UID = nBCUID;
                            Categories.Add(oCat);                           
                        }
                    }
                }
                else
                {
                    sCommand = "Select BC_UID From EPGP_COST_CATEGORIES Where (BC_UOM <>'' And BC_UOM Is Not NULL)";
                    oCommand = new SqlCommand(sCommand, dba.Connection);
                    reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        PfEItem oCat = new PfEItem();
                        oCat.UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                        Categories.Add(oCat);
                    }
                    reader.Close();
                }
                if (bisValidCatList == false || Categories.Count==0) return false;

                // set up info on Workhours and Holidays so we can use to calculate avail amounts 
                sCommand = "Select * From EPG_GROUP_WEEKLYHOURS Where GROUP_ID=@ID";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                oCommand.Parameters.AddWithValue("@ID", lWH);
                DataTable dataTable1 = new DataTable();
                dataTable1.Load(oCommand.ExecuteReader());

                sCommand = "Select * From EPG_GROUP_NONWORK_HOURS Where GROUP_ID=@ID Order By GROUP_ID,NWH_DATE";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                oCommand.Parameters.AddWithValue("@ID", lHOL);
                DataTable dataTable2 = new DataTable();
                dataTable2.Load(oCommand.ExecuteReader());

                if (dataTable1.Rows.Count == 0) return false;

                AllWorkhours workhours = new AllWorkhours();
                workhours.Initialize(dataTable1, dataTable2);

                dataTable1.Dispose();
                dataTable2.Dispose();

                Dictionary<int, Dictionary<int, PfEItem>> periodftes;  // set as a list of category ftes for each period (sure same for ea cat but need flag)
                Dictionary<int, PfEItem> catftes;

                //   need to do for ea calendar
                foreach (int lcal in calendars)
                {
                    // grab the Periods for the selected calendar
                    sCommand = "SELECT PRD_ID,PRD_START_DATE,PRD_FINISH_DATE FROM EPG_PERIODS WHERE CB_ID=@CalID Order By PRD_ID";
                    oCommand = new SqlCommand(sCommand, dba.Connection);
                    oCommand.Parameters.AddWithValue("@CalID", lcal);
                    reader = oCommand.ExecuteReader();

                    periodftes = new Dictionary<int, Dictionary<int, PfEItem>>();
                    while (reader.Read())
                    {
                        int lPeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        DateTime dStartDate = DBAccess.ReadDateValue(reader["PRD_START_DATE"]);
                        DateTime dFinishDate = DBAccess.ReadDateValue(reader["PRD_FINISH_DATE"]);

                        int lConv = (int)(workhours.workhours(lWH, lHOL, dStartDate, dFinishDate) * 100);
                        catftes = new Dictionary<int, PfEItem>();
                        foreach (PfEItem category in Categories)
                        {
                            PfEItem fteitem = new PfEItem();
                            fteitem.UID = category.UID;
                            fteitem.lValue1 = lConv;
                            catftes.Add(fteitem.UID, fteitem);
                        }
                        periodftes.Add(lPeriodID, catftes);
                    }
                    reader.Close();

                    // we've got all the info we want to write so go to it - a real pain, we shouldn't have used same record for FTE and Rate
                    bool bupdateOK = true;
                    dba.BeginTransaction();
                    sCommand = "Select CB_ID,BA_BC_UID,BA_PRD_ID,BA_FTE_CONV From EPGP_COST_BREAKDOWN_ATTRIBS Where CB_ID=@CB_ID And BA_RATETYPE_UID=0 And BA_CODE_UID=0";
                    oCommand = new SqlCommand(sCommand, dba.Connection,dba.Transaction);
                    oCommand.Parameters.AddWithValue("@CB_ID", lcal);
                    DataTable dataTable = new DataTable();
                    dataTable.Load(oCommand.ExecuteReader());

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int bcuid = DBAccess.ReadIntValue(row["BA_BC_UID"]);
                            int prdid = DBAccess.ReadIntValue(row["BA_PRD_ID"]);
                            int oldfte = DBAccess.ReadIntValue(row["BA_FTE_CONV"]);

                            if (periodftes.ContainsKey(prdid))
                            {
                                catftes = periodftes[prdid];  
                                
                                int newfte = 0;
                                if (catftes.ContainsKey(bcuid))
                                {
                                    PfEItem fteitem = catftes[bcuid];
                                    fteitem.bflag = true;
                                    newfte = fteitem.lValue1;
                                }
                                if (newfte != oldfte)
                                {
                                    row["BA_FTE_CONV"] = newfte;
                                }
                            }
                            else
                            {
                                //  period doesn't exist, delete record
                                //  row.Delete();  // this idea doesn't work the way I've done it - this shouldn't happen, if it does then modify general cleanup at the botttom here
                            }
                        }
                        //  apply updates to dbs
                        if (bupdateOK)
                        {
                            sCommand = @"Update EPGP_COST_BREAKDOWN_ATTRIBS SET BA_FTE_CONV=@fte" +
                                " Where CB_ID=@cal And BA_BC_UID=@cc And BA_PRD_ID=@period And BA_RATETYPE_UID=0 And BA_CODE_UID=0";
                            oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                            oCommand.CommandType = CommandType.Text;

                            SqlParameter fte = oCommand.Parameters.Add("@fte", SqlDbType.Int);
                            SqlParameter cal = oCommand.Parameters.Add("@cal", SqlDbType.Int);
                            SqlParameter cc = oCommand.Parameters.Add("@cc", SqlDbType.Int);
                            SqlParameter period = oCommand.Parameters.Add("@period", SqlDbType.Int);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row.RowState == DataRowState.Modified)
                                {
                                    fte.Value = row["BA_FTE_CONV"];
                                    cal.Value = lcal;
                                    cc.Value = row["BA_BC_UID"];
                                    period.Value = row["BA_PRD_ID"];
                                    oCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    dataTable.Dispose();

                    //  check for inserts
                    if (bupdateOK)
                    {
                        sCommand = @"Insert Into EPGP_COST_BREAKDOWN_ATTRIBS (CB_ID,BA_RATETYPE_UID,BA_CODE_UID,BA_BC_UID,BA_PRD_ID,BA_FTE_CONV,BA_RATE)" +
                            " Values (@cal,0,0,@cc,@period,@fte,0)";
                        oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                        oCommand.CommandType = CommandType.Text;

                        SqlParameter cal = oCommand.Parameters.Add("@cal", SqlDbType.Int);
                        SqlParameter cc = oCommand.Parameters.Add("@cc", SqlDbType.Int);
                        SqlParameter period = oCommand.Parameters.Add("@period", SqlDbType.Int);
                        SqlParameter fte = oCommand.Parameters.Add("@fte", SqlDbType.Int);

                        foreach (KeyValuePair<int, Dictionary<int, PfEItem>> clncatftes in periodftes)
                        {
                            foreach (KeyValuePair<int, PfEItem> fteitem in clncatftes.Value)
                            {
                                if (fteitem.Value.bflag == false)
                                {
                                    if (fteitem.Value.lValue1 > 0)  // don't write out rows with nothing in there
                                    {
                                        cal.Value = lcal;
                                        cc.Value = fteitem.Value.UID;
                                        period.Value = clncatftes.Key;
                                        fte.Value = fteitem.Value.lValue1;
                                        oCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    if (bupdateOK) dba.CommitTransaction();
                }
                //  execute a delete to clear out possible left overs where a rate was deleted and there is no FTE either
                {
                    sCommand = @"Delete From EPGP_COST_BREAKDOWN_ATTRIBS" +
                        " Where (BA_FTE_CONV = 0 Or BA_FTE_CONV is NULL) And (BA_RATE = 0 Or BA_RATE is NULL)";
                    oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();

                    // might as well run a clean up just in case
                    sCommand = @"Delete From EPGP_COST_BREAKDOWN_ATTRIBS" +
                       " Where BA_BC_UID Not in (Select BC_UID From EPGP_COST_CATEGORIES) or CB_ID Not in (Select CB_ID From EPGP_COST_BREAKDOWNS)";
                    oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                    oCommand.CommandType = CommandType.Text;
                    oCommand.ExecuteNonQuery();
                }
                bResult = true;
            }
            catch (Exception ex)
            {
                sReply = HandleException("CalcDefaultFTEs", 99999, ex);
                bResult = false;
            }
            return bResult;
        }

        public bool SaveReportingConnection(string sData)
        {
            // the xml for this function should be in the format 
            // </ReportingConnection Connection="connection">
            string sReply = "";
            try
            {
                CStruct xData = new CStruct();

                if (xData.LoadXML(sData) == false)
                {
                    _dba.Status = StatusEnum.rsRequestInvalidParameter;
                    return false;
                }

                if (xData.Name != "ReportingConnection")
                {
                    _dba.Status = StatusEnum.rsRequestInvalidParameter;
                    return false;
                }
                string sConnection = xData.GetStringAttr("Connection");
                return ImportReportingConnection(sConnection);
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveReportingConnection", 99999, ex);
                return false;
            }
        }
        public bool SavePEConnection(string sData)
        {
            // the xml for this function should be in the format 
            // </PEConnection Connection="connection">
            string sReply = "";
            try
            {
                CStruct xData = new CStruct();

                if (xData.LoadXML(sData) == false)
                {
                    _dba.Status = StatusEnum.rsRequestInvalidParameter;
                    return false;
                }

                if (xData.Name != "PEConnection")
                {
                    _dba.Status = StatusEnum.rsRequestInvalidParameter;
                    return false;
                }
                string sConnection = xData.GetStringAttr("Connection");
                return ImportPEConnection(sConnection);
            }
            catch (Exception ex)
            {
                sReply = HandleException("SavePEConnection", 99999, ex);
                return false;
            }
        }


        private bool ImportReportingConnection(string connection)
        {
            SqlCommand oCommand;
            string sReply = "";

            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            bool bResult = false;

            try
            {
                string sCommand;
                sCommand = "Update EPG_ADMIN Set ADM_WE_REPORTING_DB_CONNECT=@Conn";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.Parameters.AddWithValue("@Conn", connection);
                oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sReply = HandleException("ImportReportingConnection", 99999, ex);
                return false;
            }

            bResult = true;

            return bResult;
        }

        private bool ImportPEConnection(string connection)
        {
            SqlCommand oCommand;
            string sReply = "";

            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            bool bResult = false;

            try
            {
                string sCommand;
                sCommand = "Update EPG_ADMIN Set ADM_PS_REPORTING_DB_CONNECT=@Conn";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.Parameters.AddWithValue("@Conn", connection);
                oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sReply = HandleException("ImportPEConnection", 99999, ex);
                return false;
            }

            bResult = true;

            return bResult;
        }


        public bool SubmitReportExtract(string sData)
        {
            //decimal dRate = CalcResourceRate(5);
            
            string sReply = "";
            try
            {
                CStruct xData = new CStruct();
                if (xData.LoadXML(sData) == true)
                {

                    int nFrequency = xData.GetIntAttr("Frequency");
                    // Frequency Codes  0-don't run, 1-run once at start time, 2-run every hour, 3-run every day, 4-run every week, 5-run every same day of month, 9-run every minute-testing only
                    string sDate = xData.GetStringAttr("StartDate");
                    DateTime dStartDate = DateTime.Parse(sDate);

                    return SubmitTimerJob(100, "Reporting Extract", nFrequency, dStartDate);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SubmitReportExtract", 99999, ex);
                return false;
            }
        }

        private bool SubmitTimerJob(int JobCode, string JobDesc, int Frequency, DateTime StartDate)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            string sReply = "";
            string sCommand;

            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            bool bResult = false;

            try
            {
                // New Report Extract will replace old one for now - otherwise need proper Timer Job page where Jobs can be created, deleted, etc
                sCommand = "Delete From EPG_JOBS_TIMER Where JOT_CONTEXT = @JobCode";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.Parameters.AddWithValue("@JobCode", JobCode); 
                oCommand.ExecuteNonQuery();

                CStruct xContext = new CStruct();
                xContext.Initialize("Request");
                CStruct xData = xContext.CreateSubStruct("Data");
                xData.CreateStringAttr("Data", "I am some data");

                sCommand = "SET NOCOUNT ON;"
                   + "INSERT Into EPG_JOBS_TIMER (JOT_FIRST_RUN,JOT_FREQ_MODE,WRES_ID,JOT_CONTEXT_DATA,JOT_SESSION,JOT_CONTEXT,JOT_COMMENT)"
                   + " Values(@Firstrun,@Freq,@Resource,@ContextData,@Session, @JobCode, @JobDesc);"
                   + "Select @@IDENTITY as NewID";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.Parameters.AddWithValue("@Firstrun", StartDate);
                oCommand.Parameters.AddWithValue("@Freq", Frequency);
                oCommand.Parameters.AddWithValue("@Resource", 0);
                oCommand.Parameters.AddWithValue("@ContextData", xContext.XML());
                oCommand.Parameters.AddWithValue("@Session", "I'm a session");
                oCommand.Parameters.AddWithValue("@JobCode", JobCode);
                oCommand.Parameters.AddWithValue("@JobDesc", JobDesc);
                reader = oCommand.ExecuteReader();
                int nNewId = 0;
                if (reader.Read())
                {
                    nNewId = DBAccess.ReadIntValue(reader["NewID"]);
                }
                reader.Close();

                // new job submitted with UID = nNewId
            }
            catch (Exception ex)
            {
                sReply = HandleException("SubmitTimerJob", 99999, ex);
                return false;
            }

            bResult = true;

            return bResult;
        }

        public static bool SubmitJobRequest(DBAccess dba, int WresID, string sData)
        {
            SqlCommand oCommand;
            string sCommand;

            bool bResult = false;
            CStruct xData = new CStruct();
            if (xData.LoadXML(sData) == false)
            {
                dba.Status = StatusEnum.rsRequestInvalidParameter;
                return false;
            }

            try
            {
                int nContext = xData.GetInt("JobContext", 0);
                string sComment = xData.GetString("Comment","Job Request");
                string sContextData = xData.GetString("Data", "No Context Data");

                Guid guid = Guid.NewGuid();

                sCommand = "INSERT INTO EPG_JOBS(JOB_GUID,JOB_CONTEXT,JOB_SESSION,WRES_ID,JOB_SUBMITTED,JOB_STATUS,JOB_COMMENT,JOB_CONTEXT_DATA)"
                   + " VALUES(@GUID,@JobContext,@JobSession,@WresID,@JobSubmitted,@JobStatus,@JobComment,@JobData)";
                oCommand = new SqlCommand(sCommand, dba.Connection);
                oCommand.Parameters.AddWithValue("@GUID", guid);
                oCommand.Parameters.AddWithValue("@JobContext", nContext);
                oCommand.Parameters.AddWithValue("@JobSession", "I'm a Session?");
                oCommand.Parameters.AddWithValue("@WresID", WresID);
                oCommand.Parameters.AddWithValue("@JobSubmitted", DateTime.Now);
                oCommand.Parameters.AddWithValue("@JobStatus", 0);
                oCommand.Parameters.AddWithValue("@JobComment", sComment);
                oCommand.Parameters.AddWithValue("@JobData", sContextData);
                oCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //sReply = HandleException("SubmitJobRequest", 99999, ex);
                return false;
            }
            bResult = true;
            return bResult;
        }

        public bool SaveWorkEngineURL(string sData)
        {

            // the xml for this function should be in the format 
            // </WEServerURL WEURL="url">
      
            string sReply = "";
            try
            {
                CStruct xData = new CStruct();

                if (xData.LoadXML(sData) == false)
                {
                    _dba.Status = StatusEnum.rsRequestInvalidParameter;
                    return false;
                }

                if (xData.Name != "WEServerURL")
                {
                    _dba.Status = StatusEnum.rsRequestInvalidParameter;
                    return false;
                }

                string sURL = xData.GetStringAttr("WEURL");
                return ImportWE_URL(sURL);
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveWorkEngineURL", 99999, ex);
                return false;
            }
        }

        private bool ImportWE_URL(string sURL)
        {
            SqlCommand oCommand;
            string sReply = "";

            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            bool bResult = false;

            try
            {
                string sCommand;
                sCommand = "Update EPG_ADMIN Set ADM_WE_SERVERURL=@WEURL";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.Parameters.AddWithValue("@WEURL", sURL);
                oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sReply = HandleException("ImportWE_URL", 99999, ex);
                return false;
            }

            bResult = true;

            return bResult;
        }


        public bool SaveWorkEngineFieldMappings(string sData)
        {
            string sReply = "";

            // the xml for this function should be in the format 
            // <FieldMapping><PI><Field ID="20020" Name="Budget"/></PI></FieldMapping>
            // where Field ID is the EPK field number and Field Name is the WE name
            // the PI section is there just incase we want to add sections for resources etc.

            try
            {
                 CStruct xData = new CStruct();

                if (xData.LoadXML(sData) == false)
                {

                    _dba.Status = StatusEnum.rsRequestInvalidParameter;
                    return false;
                }
                if (xData.Name != "FieldMapping")
                {
                    _dba.Status = StatusEnum.rsRequestInvalidParameter;
                    return false;
                }

                _dba.BeginTransaction();

                List<CStruct> piVals = xData.GetList("PI");

                if (piVals.Count != 0)
                {
                    CStruct xPI = piVals[0];
                    List<CStruct> piFieldVals = xPI.GetList("Field");

                    if (ImportWE_FieldMappings(piFieldVals, 20) == false)
                    {
                        _dba.RollbackTransaction();
                        return false;
                    }
               }


            //    return ImportWE_URL(sURL);
                _dba.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                sReply = HandleException("SaveWorkEngineFieldMappings", 99999, ex);
                return false;
            }
        }

        private bool ImportWE_FieldMappings(List<CStruct> piFieldVals, int wem_entity)
        {
            SqlCommand oCommand;
            string sReply = "";

            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            bool bResult = false;

            try
            {
                string sCommand;
                int wem_uid = 0;


                sCommand = "DELETE FROM EPG_WE_MAPPING WHERE WEM_ENTITY = " + wem_entity.ToString();
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.ExecuteNonQuery();


                sCommand = "INSERT INTO EPG_WE_MAPPING ( WEM_UID, WEM_ENTITY, WEM_EPK_FIELD_ID, WEM_WE_FIELD_ID, WEM_WE_NAME) " +
                              "VALUES (@WEM_UID," + wem_entity.ToString() + ",@WEM_EPK_FIELD_ID,@WEM_WE_FIELD_ID,@WEM_WE_NAME)";

                oCommand = new SqlCommand(sCommand, _dba.Connection);

                SqlParameter pwem_uid = oCommand.Parameters.Add("@WEM_UID", SqlDbType.Int);
                SqlParameter pWEM_EPK_FIELD_ID = oCommand.Parameters.Add("@WEM_EPK_FIELD_ID", SqlDbType.Int);
                SqlParameter pWEM_WE_FIELD_ID = oCommand.Parameters.Add("@WEM_WE_FIELD_ID", SqlDbType.Int);
                SqlParameter pWEM_WE_NAME = oCommand.Parameters.Add("@WEM_WE_NAME", SqlDbType.VarChar, 255);

                foreach (CStruct xfld in piFieldVals)
                {
                    pwem_uid.Value = ++wem_uid;
                    pWEM_EPK_FIELD_ID.Value = xfld.GetIntAttr("ID");
                    pWEM_WE_FIELD_ID.Value = xfld.GetIntAttr("WEID");
                    pWEM_WE_NAME.Value = xfld.GetStringAttr("Name");
                    int lRowsAffected = oCommand.ExecuteNonQuery();
                }

                oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sReply = HandleException("ImportWE_URL", 99999, ex);
                return false;
            }

            bResult = true;

            return bResult;
        }
        public string GetTimerJobs()
        {
            try
            {

                SqlCommand oCommand;
                SqlDataReader reader;
                string sCommand = "";

                if (_dba.Open() != StatusEnum.rsSuccess)
                    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

                CStruct xRoot = new CStruct();
                xRoot.Initialize("TimerJobs");

                sCommand =
                    "SELECT JOT_UID, JOT_FIRST_RUN, JOT_LAST_RUN, JOT_NEXT_RUN, JOT_FREQ_MODE, JOT_SESSION, EPG_JOBS_TIMER.WRES_ID, JOT_CONTEXT, JOT_CONTEXT_DATA, " +
                    " JOT_COMMENT, EPG_RESOURCES.RES_NAME " +
                    " FROM EPG_JOBS_TIMER INNER JOIN EPG_RESOURCES ON EPG_JOBS_TIMER.WRES_ID = EPG_RESOURCES.WRES_ID ORDER BY JOT_UID";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    CStruct xJob = xRoot.CreateSubStruct("TimerJob");

                    xJob.CreateIntAttr("UID", DBAccess.ReadIntValue(reader["JOT_UID"]));
                    xJob.CreateStringAttr("Desc", DBAccess.ReadStringValue(reader["JOT_COMMENT"]));
                    xJob.CreateIntAttr("Freq", DBAccess.ReadIntValue(reader["JOT_FREQ_MODE"]));
                    xJob.CreateDateAttr("LastRan", DBAccess.ReadDateValue(reader["JOT_LAST_RUN"]));
                    xJob.CreateDateAttr("NextRun", DBAccess.ReadDateValue(reader["JOT_NEXT_RUN"]));
                    xJob.CreateDateAttr("FirstRun", DBAccess.ReadDateValue(reader["JOT_FIRST_RUN"]));
                    xJob.CreateIntAttr("WRESID", DBAccess.ReadIntValue(reader["WRES_ID"]));
                    xJob.CreateStringAttr("UserName", DBAccess.ReadStringValue(reader["RES_NAME"]));
                    xJob.CreateIntAttr("Context", DBAccess.ReadIntValue(reader["JOT_CONTEXT"]));
                    xJob.CreateStringAttr("ConextData", DBAccess.ReadStringValue(reader["JOT_CONTEXT_DATA"]));
                    xJob.CreateStringAttr("Session", DBAccess.ReadStringValue(reader["JOT_SESSION"]));

                }
                reader.Close();

                return xRoot.XML();

            }
            catch (Exception ex)
            {
                HandleException("GetTimerJobs", 99999, ex);
                return "";
            }

        }

        public string GetTimerJobDetails(string jobUID)
        {
            try
            {

                SqlCommand oCommand;
                SqlDataReader reader;

                if (_dba.Open() != StatusEnum.rsSuccess)
                    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

                string sCommand = "";
                CStruct xRoot = new CStruct();

                xRoot.Initialize("TimerJob");

                sCommand =
                    "SELECT JOT_UID, JOT_FIRST_RUN, JOT_LAST_RUN, JOT_NEXT_RUN, JOT_FREQ_MODE, JOT_SESSION, WRES_ID, JOT_CONTEXT, JOT_CONTEXT_DATA, " +
                    " JOT_COMMENT " +
                    " FROM EPG_JOBS_TIMER WHERE JOT_UID = " + jobUID;
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    xRoot.CreateIntAttr("UID", DBAccess.ReadIntValue(reader["JOT_UID"]));
                    xRoot.CreateStringAttr("Desc", DBAccess.ReadStringValue(reader["JOT_COMMENT"]));
                    xRoot.CreateIntAttr("Freq", DBAccess.ReadIntValue(reader["JOT_FREQ_MODE"]));
                    xRoot.CreateDateAttr("LastRan", DBAccess.ReadDateValue(reader["JOT_LAST_RUN"]));
                    xRoot.CreateDateAttr("NextRun", DBAccess.ReadDateValue(reader["JOT_NEXT_RUN"]));
                    xRoot.CreateDateAttr("FirstRun", DBAccess.ReadDateValue(reader["JOT_FIRST_RUN"]));
                    xRoot.CreateIntAttr("WRESID", DBAccess.ReadIntValue(reader["WRES_ID"]));
                    xRoot.CreateIntAttr("Context", DBAccess.ReadIntValue(reader["JOT_CONTEXT"]));
                    xRoot.CreateStringAttr("ContextData", DBAccess.ReadStringValue(reader["JOT_CONTEXT_DATA"]));
                    xRoot.CreateStringAttr("Session", DBAccess.ReadStringValue(reader["JOT_SESSION"]));

                }
                reader.Close();

                return xRoot.XML();

            }
            catch (Exception ex)
            {
                HandleException("GetTimerJobDetails", 99999, ex);
                return "";
            }

        }


        public bool SetTimerJobDetails(string sxml)
        {
            SqlCommand oCommand;
            SqlDataReader reader;

            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            CStruct xData = new CStruct();
            string sReply = "";

            try {

                 if (xData.LoadXML(sxml) == false)
                     return false;

                int freq = xData.GetIntAttr("Freq");
                int context = xData.GetIntAttr("Context");
                DateTime nextrun = xData.GetDateAttr("NextRun");
                string contextdata = "<" + xData.GetStringAttr("ContextData") + "/>";
                string desc = xData.GetStringAttr("Desc");
                Guid guid = Guid.NewGuid();



                 // New Report Extract will replace old one for now - otherwise need proper Timer Job page where Jobs can be created, deleted, etc
                string sCommand = "Delete From EPG_JOBS_TIMER Where JOT_CONTEXT = @JobCode";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.Parameters.AddWithValue("@JobCode", context);
                oCommand.ExecuteNonQuery();

                sCommand = "SET NOCOUNT ON;"
                   + "INSERT Into EPG_JOBS_TIMER (JOT_FIRST_RUN,JOT_FREQ_MODE,WRES_ID,JOT_CONTEXT_DATA,JOT_SESSION,JOT_CONTEXT,JOT_COMMENT)"
                   + " Values(@Firstrun,@Freq,@Resource,@ContextData,@Session, @JobCode, @JobDesc);"
                   + "Select @@IDENTITY as NewID";

                oCommand = new SqlCommand(sCommand, _dba.Connection);

                if (nextrun == DateTime.MinValue)
                    oCommand.Parameters.AddWithValue("@Firstrun", null);
                else
                      oCommand.Parameters.AddWithValue("@Firstrun", nextrun);

                oCommand.Parameters.AddWithValue("@Freq", freq);
                oCommand.Parameters.AddWithValue("@Resource", _userWResID);
                oCommand.Parameters.AddWithValue("@ContextData", contextdata);
                oCommand.Parameters.AddWithValue("@Session", guid);
                oCommand.Parameters.AddWithValue("@JobCode", context);
                oCommand.Parameters.AddWithValue("@JobDesc", desc);
                reader = oCommand.ExecuteReader();
                int nNewId = 0;
                if (reader.Read())
                {
                    nNewId = DBAccess.ReadIntValue(reader["NewID"]);
                }
                reader.Close();

                return true;

            }
            catch (Exception ex)
            {
                sReply = HandleException("SubmitTimerJob", 99999, ex);
                return false;
            }




        }
  

        public string DeleteTimerJob(string jobUID)
        {
            try
            {

                SqlCommand oCommand;
                SqlDataReader reader;

                if (_dba.Open() != StatusEnum.rsSuccess)
                    debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

                string sCommand = "";
                CStruct xRoot = new CStruct();

                xRoot.Initialize("TimerJob");

                sCommand = "DELETE FROM EPG_JOBS_TIMER WHERE JOT_UID = " + jobUID;
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                int lRowsAffected = oCommand.ExecuteNonQuery();

                xRoot.CreateStringAttr("UID", jobUID);
                xRoot.CreateIntAttr("Deleted", lRowsAffected);


                return xRoot.XML();

            }
            catch (Exception ex)
            {
                HandleException("GetTimerJobDetails", 99999, ex);
                return "";
            }

        }

        /// <summary>
        /// Calculates the resource rate.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        /// <returns></returns>
        public decimal CalcResourceRate(int resourceId)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            string sCommand = "";
            bool bIsNull;

            if (_dba.Open() != StatusEnum.rsSuccess)
                debug.AddMessage("Open DB Error=" + _dba.FormatErrorText());

            try
            {
                decimal dRate = 0;
                // read the resource named rate and if necessary cost category
                int lBC_UID = 0;
                int lRT_UID = 0;
                sCommand = "Select RT_UID From EPGP_COST_RATES  Where TB_UID=0 And WRES_ID=@WresId";
                oCommand = new SqlCommand(sCommand, _dba.Connection);
                oCommand.Parameters.AddWithValue("@WresId", resourceId);
                reader = oCommand.ExecuteReader();
                if (reader.Read())
                {
                    lRT_UID = DBAccess.ReadIntValue(reader["RT_UID"]);
                }
                reader.Close();

                if (lRT_UID > 0)
                {
                    sCommand = "Select RT_RATE From EPG_RATE_VALUES Where RT_EFFECTIVE_DATE<=GETDATE() And RT_UID=@RT_UID Order By RT_EFFECTIVE_DATE";
                    oCommand = new SqlCommand(sCommand, _dba.Connection);
                    oCommand.Parameters.AddWithValue("@RT_UID", lRT_UID);
                    reader = oCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        dRate = (decimal)DBAccess.ReadDoubleValue(reader["RT_RATE"]);
                    }
                    reader.Close();
                }
                else
                {
                    sCommand = "Select BC_UID From EPGP_COST_XREF  Where WRES_ID=@WresId";
                    oCommand = new SqlCommand(sCommand, _dba.Connection);
                    oCommand.Parameters.AddWithValue("@WresId", resourceId);
                    reader = oCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        lBC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    }
                    reader.Close();
                    if (lBC_UID > 0)
                    {
                        //  Get Resource Planning Calendar which we will use for Category Rates
                        int lFiscal = -99;
                        sCommand = "SELECT ADM_PORT_COMMITMENTS_CB_ID FROM EPG_ADMIN";
                        oCommand = new SqlCommand(sCommand, _dba.Connection);
                        reader = oCommand.ExecuteReader();
                        {
                            if (reader.Read())
                            {
                                lFiscal = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_CB_ID"], out bIsNull);
                                if (bIsNull) lFiscal = -99;
                            }
                            reader.Close();
                        }
                        if (lFiscal >= 0)
                        {
                            // read the rate for the period containing TODAY but also read Period 1 in case calendar starts in the future
                            sCommand = "Select BA_RATE" +
                                        " From EPGP_COST_BREAKDOWN_ATTRIBS a" +
                                        " Join EPG_PERIODS p On p.CB_ID=a.CB_ID And p.PRD_ID=a.BA_PRD_ID" +
                                        " Join EPGP_CATEGORIES c On c.CA_UID=a.BA_BC_UID" +
                                        " Where a.CB_ID=@CBId And BA_BC_UID=@BC_UID" +
                                        " And BA_RATETYPE_UID=0 And ((PRD_START_DATE<=GETDATE() And PRD_FINISH_DATE>GETDATE()) Or PRD_ID=1)" +
                                        "Order by PRD_ID";
                            oCommand = new SqlCommand(sCommand, _dba.Connection);
                            oCommand.Parameters.AddWithValue("@CBId", lFiscal);
                            oCommand.Parameters.AddWithValue("@BC_UID", lBC_UID);
                            reader = oCommand.ExecuteReader();
                            {
                                while (reader.Read())
                                {
                                    dRate = (decimal)DBAccess.ReadDoubleValue(reader["BA_RATE"]);
                                }
                                reader.Close();
                            }
                        }
                    }
                }


                return dRate;
            }
            catch (Exception ex)
            {
                // do something
                throw ex;
            }

        }


        #region Private Methods ()

        private static double GetPeriodRate(DateTime prdstart, int catID, List<CategoryRate> rates)
        {
            double rate = 0;
            bool firstitem = true;
            foreach (CategoryRate rateitem in rates)
            {
                if (firstitem) { firstitem = false; rate = rateitem.Rate; }
                else if (prdstart >= rateitem.EffectiveDate) rate = rateitem.Rate;
                else if (prdstart < rateitem.EffectiveDate) break;
            }
            return rate;
        }

        private static CStruct BuildResultStruct(string sFunction, int nStatus = 0)
        {
            CStruct xResult = new CStruct();
            xResult.Initialize("Result");
            xResult.CreateStringAttr("Function", sFunction);
            xResult.CreateIntAttr("Status", nStatus);
            return xResult;
        }

        private static string HandleError(string sFunction, int nStatus, string sError)
        {
            CStruct xResult = BuildResultStruct(sFunction, nStatus);
            CStruct xGrid = xResult.CreateSubStruct("Grid");
            CStruct xIO = xGrid.CreateSubStruct("IO");
            xIO.CreateIntAttr("Result", 0);
            xIO.CreateStringAttr("Message", sError);
            CStruct xError = xResult.CreateSubStruct("Error");
            //xError.Value = sError;
            xError.CreateIntAttr("ID", nStatus);
            xError.CreateStringAttr("Value", sError);
            return xResult.XML();
        }

        private static string HandleException(string sFunction, int nStatus, Exception ex)
        {
            return HandleError(sFunction, nStatus, "Exception in AdminFunctions : '" + ex.Message.ToString() + "'");
        }

        #endregion Private Methods

        #region Private Classes ()

        private class CategoryRate
        {
            public int UID;
            public DateTime EffectiveDate;
            public double Rate;
            public double OvertimeRate;
        }

        private class PfEItem
        {
            public int UID;
            public string name;
            public double dValue1;
            public double dValue2;
            public int lValue1;
            public bool bflag;
        }

        private class PfEPeriod
        {
            public string PeriodName;
            public int PeriodID;
            public DateTime StartDate;
            public DateTime FinishDate;
        }

        private class PfEResource
        {
            public string Name;
            public int WresID;
            public int WHGroupId;
            public int HolGroupId;
            public DateTime StartDate;
            public DateTime FinishDate;
        }
        #endregion Private Classes
    }
}
