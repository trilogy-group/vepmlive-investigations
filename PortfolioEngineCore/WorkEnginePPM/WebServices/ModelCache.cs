using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using WorkEnginePPM;
//using WorkEnginePPM_old;
using PortfolioEngineCore;

using System.Text;
using System.Data;
using System.Globalization;
namespace ModelDataCache
{
    [Serializable()]
    public class CSNamedRate
    {
        public int UID, ID, Level;
        public string Name;
        public double[] Rates;
    }
    [Serializable()]
    public class CSCategoryEntry
    {
        public int UID, ID, Level, Role_UID, Mode, PID, MC_UID, Category;
        public string Name, UoM, FullName, MC_Val, Role_Name;
        public double[] Rates, FTEConv;
    }
    [Serializable()]
    public class ListItemData
    {
        public int UID, ID, Level;
        public string Name, FullName;
        public bool InActive;
    }
    [Serializable()]
    public class CustomFieldsDefn
    {
        public int FieldID;
        public string Name;
        public int LookupOnly, LookupID, LeafOnly, UseFullName;
        public ListItemData[] LookUp;
        public string jsonMenu;
    }
    [Serializable()]
    public class CSRatesAndCategory
    {
        public int numberPeriods;
        public CSNamedRate[] NamedRates;
        public CSCategoryEntry[] Categories;
        public string CatjsonMenu;
        public ItemDefn[] Versions;
        public ItemDefn[] CostTypes;
        public CustomFieldsDefn[] CustomFields;
        // custom codes and lookups...
    }
    [Serializable()]
    public class TargetRowData
    {
        public int CT_ID;
        public int BC_UID;
        public int BC_ROLE_UID;
        public int BC_SEQ;
        public string MC_Val;
        public int CAT_UID;
        public string CT_Name, Cat_Name, Role_Name, MC_Name, FullCatName, CC_Name, FullCCName, Grouping;
        public bool bGroupRow;

        public int m_rt;
        public string m_rt_name;


        public string sUoM;
        public double[] zCost, zValue, zFTE;
        public int[] OCVal;
        public string[] Text_OCVal;
        public string[] TXVal;
    }
    [Serializable()]
    public class CSTargetData
    {
        public TargetRowData[] targetRows;
    }
    [Serializable()]
    public class ModelBarsChanged
    {
        public int redrawCompleteGrid;
        public int barsAffected;
        public int[] RowID;
        public string[] Starts;
        public string[] Finishs;
    }
    [Serializable()]
    public class ItemDefn
    {
        public int Id;
        public string Name;
        public int Deflt;
        public int editable;
    }
    public class SortRowDefn
    {
        public int fid;
        public int decf;
        public int grpf;
    }
    [Serializable()]
    public class SortFieldDefn
    {
        public int fid;
        public string name;
        public int selected;
        public bool touched;
    }
    [Serializable()]
    public class SortGroupDefn
    {
        public SortRowDefn[] DetRows;
        public SortRowDefn[] TotRows;
        public SortFieldDefn[] DetFields, TotFields;
        public int DetFreeze, TotFreeze, DetShowToLevel, TotShowToLevel;
        public int NumPIs, MissingPIs, LoadReturnCode, HaveLowlevelData;
        public string errMsg;
        public int TotalsCmp;
        public string ViewZoomTo = "";
    }
    [Serializable()]
    public class PeriodsAndOptions
    {
        public ItemDefn[] Periods;
        public int displayStart, displayFinish, dragStart, dragFinish, showQTY, showWhichQTY, showCosts, showRHSDecCosts;
    }

    internal enum CustomFieldDBTable : int
    {
        ResourceINT = 101,
        ResourceTEXT = 102,
        ResourceDEC = 103,
        ResourceNTEXT = 104,
        ResourceDATE = 105,
        ResourceMV = 151,
        PortfolioINT = 201,
        PortfolioTEXT = 202,
        PortfolioDEC = 203,
        PortfolioNTEXT = 204,
        PortfolioDATE = 205,
        Program = 251,
        ProjectINT = 301,
        ProjectTEXT = 302,
        ProjectDEC = 303,
        ProjectNTEXT = 304,
        ProjectDATE = 305,
        ProgramText = 402,
        TaskWIINT = 801,
        TaskWITEXT = 802,
        TaskWIDEC = 803
    }
    internal enum FieldIDs : int
    {
        PI_FID = 1,
        CT_FID = 2,
        SCEN_FID = 3,
        BC_FID = 4,
        SD_FID = 5,
        FD_FID = 6,
        UOM_FID = 7,
        BC_ROLE = 8,
        MC_FID = 9,
        FULLC_FID = 10,
        CAT_FID = 11,
        FULLCAT_FID = 12,
        FTOT_FID = 13,
        DTOT_FID = 14,
        PI_USE_EXTRA = 100,
        MAX_PI_EXTRA = 256
    }
    static class ModelErrorHandling
    {
        static public void HandleStatusError(SqlConnection oDataAccess, PortfolioEngineCore.SeverityEnum eSeverity, string sFunction, PortfolioEngineCore.StatusEnum eStatus, string sText, int UserWResID, string sSessionInfo)
        {
            DBTrace(oDataAccess, eStatus, PortfolioEngineCore.TraceChannelEnum.Exception, "HandleStatusError", sFunction, sText, "Severity : " + eSeverity.ToString(), UserWResID, sSessionInfo);
            return;
        }

        static void DBTrace(SqlConnection oDataAccess, PortfolioEngineCore.StatusEnum eStatus, PortfolioEngineCore.TraceChannelEnum eChannel, string sKeyword, string sFunction, string sText, string sDetails, int UserWResID, string sSessionInfo)
        {
            CStruct xTraceMessages = new CStruct();
            xTraceMessages.Initialize("TraceMessages");

            CStruct xTrace;
            xTrace = xTraceMessages.CreateSubStruct("Trace");
            xTrace.CreateIntAttr("Status", (int)eStatus);
            xTrace.CreateIntAttr("Channel", (int)eChannel);
            xTrace.CreateDateAttr("Timestamp", DateTime.Now);
            xTrace.CreateStringAttr("Keyword", sKeyword);
            xTrace.CreateStringAttr("Function", sFunction);
            xTrace.CreateStringAttr("Text", sText);
            xTrace.CreateStringAttr("Details", sDetails);

            WriteTrace(oDataAccess, xTraceMessages, UserWResID, sSessionInfo);
        }

        static void WriteTrace(SqlConnection oDataAccess, CStruct xTrace, int UserWResID, string sSessionInfo)
        {

            if (xTrace == null)
                return;



            string sCommand =
                "INSERT INTO EPG_LOG (LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS) "
              + " VALUES(@LOG_WRES_ID,@LOG_SESSION,@LOG_STATUS,@LOG_CHANNEL,@LOG_TIMESTAMP,@LOG_KEYWORD,@LOG_FUNCTION,@LOG_TEXT,@LOG_DETAILS)";
            try
            {
                SqlCommand oCommand = new SqlCommand(sCommand, oDataAccess);

                oCommand.Parameters.AddWithValue("@LOG_WRES_ID", UserWResID);
                oCommand.Parameters.AddWithValue("@LOG_SESSION", sSessionInfo);

                oCommand.Parameters.AddWithValue("LOG_STATUS", xTrace.GetIntAttr("Status"));
                oCommand.Parameters.AddWithValue("LOG_CHANNEL", xTrace.GetIntAttr("Channel"));
                oCommand.Parameters.AddWithValue("LOG_TIMESTAMP",  xTrace.GetDateAttr("Timestamp"));
                oCommand.Parameters.AddWithValue("LOG_KEYWORD", vb.Left(xTrace.GetStringAttr("Keyword"), 48));
                oCommand.Parameters.AddWithValue("LOG_FUNCTION", vb.Left(xTrace.GetStringAttr("Function"), 48));
                oCommand.Parameters.AddWithValue("LOG_TEXT", vb.Left(xTrace.GetStringAttr("Text"), 253));
                oCommand.Parameters.AddWithValue("LOG_DETAILS", vb.Left(xTrace.GetStringAttr("Details"), 2048));

                int lRowsAffected = oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string StatusText = "";
                StatusText = "WriteTrace Exception : " + ex.Message.ToString();
            }
            return;
        }

    }
    [Serializable()]
    class BarMoved
    {
        public int RowID;
        public string Starts;
        public string Finishs;
    }
    [Serializable()]
    class DataItem
    {
        public string Name = "";
        public string Desc = "";
        public int ID = 0;
        public int UID = 0;
        public int level = 0, group = 0;
        public bool bLoaded = false;
        public bool bEditiable = false;
        public bool bSelected = false;
        public bool bAllSelected = false;
        public int filterpos = 0;
    };
    [Serializable()]
    class PeriodData
    {
        public string PeriodName;
        public int PeriodID;
        public DateTime StartDate;
        public DateTime FinishDate;
    };
    [Serializable()]
    class CatItemData
    {
        public int UID, ID, Level, Role_UID, Mode, PID, MC_UID, Category;
        public string Name, UoM, FullName, MC_Val, Role_Name;
        public double[] Rates, FTEConv;

        public CatItemData(int arraysize)
        {

            Rates = new double[arraysize + 1];
            FTEConv = new double[arraysize + 1];
        }

    }
    [Serializable()]
    class CustomFieldData
    {
        public int FieldID;
        public string Name;
        public string DisplayName;
        public int LookupOnly, LookupID, LeafOnly, UseFullName;
        public Dictionary<int, ListItemData> ListItems;
        public string jsonMenu;
    }
    [Serializable()]
    class PortFieldData
    {
        public int ID, Editable, Required, Identity, Visible, Frozen, Sequence;
        public string Name, GivenName;
    }
    [Serializable()]
    class SecItemData
    {
        public int Group_ID, Allow_Read, Allow_Edit, Object_UID;
    }
    [Serializable()]
    class PIData : IComparable<PIData>
    {
        public int PI_ID, ScenarioID, Internal_ID, PISelected, GroupingPosn;
        public DateTime StartDate, FinishDate, oStartDate, oFinishDate;
        public string PI_Name, Scenario_name, GroupingID;
        public string[] m_PI_Extra_data;
        public string[] m_PI_Format_Extra_data;

        public int CompareTo(PIData rhs)
        {
            return this.PI_Name.CompareTo(rhs.PI_Name);
        }


        public PIData(int arraysize)
        {
            m_PI_Extra_data = new string[arraysize + 1];
            m_PI_Format_Extra_data = new string[arraysize + 1];
            Scenario_name = "";
            GroupingID = "";

        }
    }
    [Serializable()]
    class DetailRowData
    {
        public int CB_ID;
        public int CT_ID;
        public int PROJECT_ID;
        public int Internal_ID;
        public int BC_UID;
        public int BC_ROLE_UID;
        public int BC_SEQ;
        public string MC_Val;
        public int CAT_UID;
        public DateTime Det_Start;
        public DateTime Det_Finish;
        public DateTime oDet_Start;
        public DateTime oDet_Finish;
        public bool bHadPData;
        public string PI_Name, CT_Name, Scen_Name, Cat_Name, Role_Name, MC_Name, FullCatName, CC_Name, FullCCName;
        public int Scenario_ID;
        public bool b_PIOver;
        public bool LinkedToPI;
        public int m_mode;   //' bitwise field 1 = no edit - data cannot move be changed
        //   '               2 = can move it but not save it...
        //   '               4 = Don't recalc the values for cost here


        public double m_tot1;
        public double m_tot2;
        public double m_tot3;

        public int m_rt;
        public string m_rt_name;

        public bool bSelected;

        public int m_uid;
        public int m_total_to;

        public int g1, g2, g3;
        public int m_par;
        public bool bRealone;
        public bool bGotChildren;
        public string sName;
        public string sUoM;
        public bool bRollupTouched;

        public int m_sort_id;
        public int lUoM;
        public bool HasValues;
        public int m_lev, m_index;

        public bool bUseCosts;
        public double[] zCost, zValue, zFTE;

        private double[] oCosts, oUnits, oFTE;

        private int[] BurnDuration;
        private double[] Burnrate;
        private double[] UseBurnrate;
        private double[] OutsideAdj;
        private double[] Budget;
        public bool bCapture;




        public int mxdim;
        public int[] OCVal;
        public string[] Text_OCVal;
        public string[] TXVal;


        public string[] m_PI_Format_Extra_data;

        public DetailRowData(int arraysize)
        {
            PI_Name = "";
            CT_Name = "";
            Scen_Name = "";
            Cat_Name = "";
            Role_Name = "";
            MC_Name = "";
            FullCatName = "";
            FullCCName = "";
            CC_Name = "";
            m_rt_name = "";
            HasValues = false;
            LinkedToPI = false;

            mxdim = arraysize;
            zCost = new double[arraysize + 1];
            zValue = new double[arraysize + 1];
            zFTE = new double[arraysize + 1];

            for (int i = 0; i <= mxdim; i++)
            {
                zCost[i] = 0;
                zValue[i] = 0;
            }

            oCosts = new double[arraysize + 1];
            oUnits = new double[arraysize + 1];
            oFTE = new double[arraysize + 1];



            BurnDuration = new int[arraysize + 1];
            Burnrate = new double[arraysize + 1];
            UseBurnrate = new double[arraysize + 1];
            OutsideAdj = new double[arraysize + 1];
            Budget = new double[arraysize + 1];

            OCVal = new int[6];
            Text_OCVal = new string[6];
            TXVal = new string[6];
        }

        public void CopyData(DetailRowData src)
        {

            CB_ID = src.CB_ID;
            CT_ID = src.CT_ID;

            PROJECT_ID = src.PROJECT_ID;
            BC_UID = src.BC_UID;
            BC_ROLE_UID = src.BC_ROLE_UID;
            BC_SEQ = src.BC_SEQ;
            MC_Val = src.MC_Val;
            CAT_UID = src.CAT_UID;
            Det_Start = src.Det_Start;
            Det_Finish = src.Det_Finish;
            oDet_Start = src.oDet_Start;
            oDet_Finish = src.oDet_Finish;
            bHadPData = src.bHadPData;
            PI_Name = src.PI_Name;
            CT_Name = src.CT_Name;
            Scen_Name = src.Scen_Name;
            Cat_Name = src.Cat_Name;
            Role_Name = src.Role_Name;
            MC_Name = src.MC_Name;
            FullCatName = src.FullCatName;
            Scenario_ID = src.Scenario_ID;
            b_PIOver = src.b_PIOver;
            LinkedToPI = src.LinkedToPI;
            m_mode = src.m_mode;
            CC_Name = src.CC_Name;
            FullCCName = src.FullCCName;

            OCVal = src.OCVal;
            Text_OCVal = src.Text_OCVal;
            TXVal = src.TXVal;
            m_PI_Format_Extra_data = src.m_PI_Format_Extra_data;


            m_tot1 = src.m_tot1;
            m_tot2 = src.m_tot2;
            m_tot3 = src.m_tot3;

            m_rt = src.m_rt;
            m_rt_name = src.m_rt_name;

            bSelected = src.bSelected;

            bRealone = src.bRealone;
            lUoM = src.lUoM;
            HasValues = src.HasValues;

            bUseCosts = src.bUseCosts;

            for (int i = 1; i <= mxdim; i++)
            {

                zCost[i] = src.zCost[i];
                zValue[i] = src.zValue[i];
                zFTE[i] = src.zFTE[i];

                oCosts[i] = src.oCosts[i];
                oUnits[i] = src.oUnits[i];
                zFTE[i] = src.oFTE[i];

                BurnDuration[i] = src.BurnDuration[i];
                Burnrate[i] = src.Burnrate[i];
                UseBurnrate[i] = src.UseBurnrate[i];

                OutsideAdj[i] = src.OutsideAdj[i];
                oUnits[i] = src.oUnits[i];
                Budget[i] = src.Budget[i];
            }

        }
        public void CopyToTargetData(ref TargetRowData dest)
        {

            dest.CT_ID = CT_ID;

            dest.BC_UID = BC_UID;
            dest.BC_ROLE_UID = BC_ROLE_UID;
            dest.BC_SEQ = BC_SEQ;
            dest.MC_Val = MC_Val;
            dest.CAT_UID = CAT_UID;
            dest.CT_Name = CT_Name;
            dest.Cat_Name = Cat_Name;
            dest.Role_Name = Role_Name;
            dest.MC_Name = MC_Name;
            dest.FullCatName = FullCatName;
            dest.CC_Name = CC_Name;
            dest.FullCCName = FullCCName;

            dest.bGroupRow = false;
            dest.Grouping = "";

            dest.OCVal = OCVal;
            dest.Text_OCVal = Text_OCVal;
            dest.TXVal = TXVal;

            dest.zCost = new double[mxdim + 1];
            dest.zValue = new double[mxdim + 1];
            dest.zFTE = new double[mxdim + 1];


            for (int i = 1; i <= mxdim; i++)
            {

                dest.zCost[i] = zCost[i];
                dest.zValue[i] = zValue[i];
                dest.zFTE[i] = zFTE[i];

            }

        }

        public void AddToTargetData(ref TargetRowData dest)
        {

            for (int i = 1; i <= mxdim; i++)
            {

                dest.zCost[i] += zCost[i];
                dest.zValue[i] += zValue[i];
                dest.zFTE[i] += zFTE[i];

            }

        }

        public void SetSnGInd(int i, int lv)
        {
            switch (i)
            {
                case 0:
                    g1 = lv;
                    break;
                case 1:
                    g2 = lv;
                    break;
                case 2:
                    g3 = lv;
                    break;
            }
        }
        public void CaputureInitialData(Dictionary<int, PeriodData> clnPer)
        {
            bCapture = true;
            oDet_Start = Det_Start;
            oDet_Finish = Det_Finish;


            for (int i = 1; i <= mxdim; i++)
            {
                oCosts[i] = zCost[i];
                oUnits[i] = zValue[i];
                oFTE[i] = zFTE[i];
            }

            bUseCosts = (sUoM == "");


            CaptureBurnRates(clnPer);
        }

        public void RestoreInitialData(Dictionary<int, PeriodData> clnPer)
        {
            Det_Start = oDet_Start;
            Det_Finish = oDet_Finish;


            for (int i = 1; i <= mxdim; i++)
            {
                zCost[i] = oCosts[i];
                zValue[i] = oUnits[i];
                zFTE[i] = oFTE[i];
            }

            CaptureBurnRates(clnPer);
        }

        private void CaptureBurnRates(Dictionary<int, PeriodData> clnPer)
        {
            int i = 0;
            int lPerSpan = 0;

            foreach (PeriodData oPer in clnPer.Values)
            {
                ++i;
                lPerSpan = CalculateOverlapLocal(Det_Start, Det_Finish, oPer.StartDate, oPer.FinishDate);
                BurnDuration[i] = lPerSpan;

                if (bUseCosts)
                    Burnrate[i] = zCost[i];
                else
                    Burnrate[i] = zValue[i];

                if (Burnrate[i] != 0)
                {
                    if (lPerSpan == 0)
                        Burnrate[i] = 0;
                    else
                        Burnrate[i] = Burnrate[i] / (double)lPerSpan;
                }
            }

        }

        private int CalculateOverlapLocal(DateTime dtBarStart, DateTime dtBarFinish, DateTime dtPeriodStart, DateTime dtPeriodFinish)
        {

            if (dtBarStart > dtPeriodFinish || dtBarFinish < dtPeriodStart)
                return 0;

            if (dtBarStart <= dtPeriodStart && dtBarFinish >= dtPeriodFinish)
                return dtPeriodFinish.Subtract(dtPeriodStart).Days + 1;

            DateTime dt1;
            DateTime dt2;

            dt1 = (dtBarStart < dtPeriodStart ? dtPeriodStart : dtBarStart);     //' take the max of the two start dates
            dt2 = (dtBarFinish < dtPeriodFinish ? dtBarFinish : dtPeriodFinish);  //    ' take the min of the two finish dates dates

            if (dt1 > dt2)
                return 0;

            return dt2.Subtract(dt1).Days + 1;
        }

        private double AFiddler(double f)
        {
            return double.Parse(f.ToString("0.00"));
        }


        public void DragBar(DateTime[] dtPeriodStart, DateTime[] dtPeriodFinish, int[] PeriodMode, int minp, int maxp)
        {
            //  Input data
            // dtPeriodStart(num_periods)  - start date of each period
            // dtPeriodFinish(num_periods)  - finish date of each period
            // PeriodMode(num_periods)  - true if this period should be included in the calc.

            double per_span;
            double per_offset;
            int xtraburn;
            int amt;
            double useamt;

            double useadj;
            double mvtotal;

            double span1, span2;

            // useadj is used to apportion the burn rate - handling the expand and compress affect

            span1 = oDet_Finish.Subtract(oDet_Start).Days;
            span2 = Det_Finish.Subtract(Det_Start).Days;

            if (span1 <= 0)
                useadj = 1;
            else
                useadj = span2 / span1;


            if (useadj == 0)
                useadj = 0.00001;

            mvtotal = 0;

            for (int per = 1; per <= mxdim; per++)
            {
                // only perform these calculations if this period "visible" in the Analyzer view.

                if (PeriodMode[per] != 0)
                {
                    mvtotal = mvtotal + (bUseCosts ? zCost[per] : zValue[per]);
                    Budget[per] = 0;
                    OutsideAdj[per] = 0;
                    UseBurnrate[per] = Burnrate[per];

                }
                else
                {
                    OutsideAdj[per] = (bUseCosts ? zCost[per] : zValue[per]);
                    Budget[per] = 0;
                    UseBurnrate[per] = 0;
                }
            }


            for (int per = 1; per <= mxdim; per++)
            {
                // only perform these calculations if this period "visible" in the Analyzer view.

                if (PeriodMode[per] != 0)
                {

                    // For each period - calculate the overlap (in days) between the period and the new start and finish dates


                    if (per == 6)
                        per_span = 1;

                    per_span = CalculateOverlapLocal(Det_Start, Det_Finish, dtPeriodStart[per], dtPeriodFinish[per]);

                    // we should never get a -ve value but its always worth checking.....

                    if (per_span < 0)
                        per_span = 0;


                    // map this span into expanded or compressed amount

                    per_span = per_span / useadj;

                    if (per_span != 0)
                    {

                        // OK there is some overlap - so now calculate where this overlap starts wrt the new startdate

                        per_offset = dtPeriodStart[per].Subtract(Det_Start).Days;

                        if (per_offset < 0)
                            // well the new start is after the period start - so the offest must be 0
                            per_offset = 0;


                        // so now find where this offset starts in the burn duration list....

                        // and map the period offest into expanded/compressed offsets as well

                        per_offset = per_offset / useadj;

                        for (int burn = 1; burn <= mxdim; burn++)
                        {
                            if (per_offset - BurnDuration[burn] < 0)
                            {

                                // OK this offset starts in this burn period - so calc how many days left in this burn

                                amt = BurnDuration[burn] - (int)(per_offset + 0.5);


                                xtraburn = 0;

                                while (per_span > 0)
                                {

                                    if (amt > per_span)
                                        useamt = per_span;
                                    else
                                        useamt = amt;


                                    // apply this amts burn to this period

                                    Budget[per] = Budget[per] + AFiddler(useamt * UseBurnrate[burn + xtraburn]);


                                    per_span = per_span - useamt;

                                    if (per_span > 0)
                                    {

                                        // step onto the next burn .... if not off the end - other wise use the last periods burn...
                                        if (burn + xtraburn < mxdim)
                                            xtraburn = xtraburn + 1;
                                        else
                                            break;


                                        amt = BurnDuration[burn + xtraburn];
                                    }
                                }

                            }

                            else
                                per_offset = per_offset - BurnDuration[burn];

                        }



                    }
                }
            }

            //     dump overflow into start or end buckets

            for (int per = 1; per < minp; per++)
            {
                Budget[minp] = Budget[minp] + Budget[per];
                Budget[per] = 0;
            }

            for (int per = maxp + 1; per < mxdim; per++)
            {
                Budget[maxp] = Budget[maxp] + Budget[per];
                Budget[per] = 0;
            }


            double fnTot = 0;

            for (int per = minp; per <= maxp; per++)
            {
                fnTot += Budget[per];
            }


            mvtotal = mvtotal - fnTot;

            if (Det_Start < oDet_Start)
                Budget[minp] = Budget[minp] + mvtotal;
            else
                Budget[maxp] = Budget[maxp] + mvtotal;

            for (int per = 1; per <= mxdim; per++)
            {
                if (bUseCosts)
                    zCost[per] = Budget[per] + OutsideAdj[per];
                else
                    zValue[per] = Budget[per] + OutsideAdj[per];
            }
        }

    }
    [Serializable()]
    class RateTable
    {
        public int UID, ID, Level;
        public string Name;
        public double[] zRate;
        private int mxdim;

        public RateTable(int arraysize)
        {
            mxdim = arraysize + 1;
            zRate = new double[arraysize + 1];
            for (int i = 0; i < mxdim; i++)
            {
                zRate[i] = 0;
            }

        }
    }
    [Serializable()]
    class RateFTECache
    {
        public double[] zRate, zFTE;
        private int mxdim;

        public RateFTECache(int arraysize)
        {
            mxdim = arraysize + 1;
            zRate = new double[arraysize + 1];
            zFTE = new double[arraysize + 1];
            for (int i = 0; i < mxdim; i++)
            {
                zRate[i] = 0;
                zFTE[i] = 0;
            }

        }
    }
    [Serializable()]
    class TargetColours
    {
        public int ID, rgb_val;
        public double low_val, high_val;
        public string Desc;
    }
    internal class TopGridCostsLayout
    {
        private CStruct xGrid;
        private CStruct m_xPeriodCols;
        private CStruct m_xHeader1;
        private CStruct m_xHeader2;


        public bool InitializeGridLayout(bool UsingGrouping, bool ShowFTEs, bool ShowGantt, DateTime dtMin, DateTime dtMax, List<SortFieldDefn> DetCol, int DetFreeze)
        {

            bool UseCols = false;

            if (DetFreeze == 0)
                UseCols = true;

            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            if (UsingGrouping)
                xCfg.CreateStringAttr("MainCol", "Grouping");

            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");

            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateBooleanAttr("NoTreeLines", true);

            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("FilterEmpty", 1);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            xCfg.CreateIntAttr("ExportFormat", 1);
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("PrintCols", 0);

            xCfg.CreateIntAttr("LeftWidth", 400);


            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "Modeler");

            xCfg.CreateIntAttr("RightWidth", 800);
            xCfg.CreateIntAttr("MinMidWidth", 200);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 1);
            xCfg.CreateIntAttr("RightCanResize", 1);

            CStruct m_xDef;
            CStruct m_xDefTree;

            m_xDef = xGrid.CreateSubStruct("Def");

            m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");


            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefTree.CreateIntAttr("NoColorState", 1);

            //xCfg.CreateStringAttr("HoverCell", "Color");
            //xCfg.CreateStringAttr("HoverRow", "Color");
            //xCfg.CreateStringAttr("FocusCell", "");
            //xCfg.CreateStringAttr("HoverCell", "Color");
            //xCfg.CreateIntAttr("NoColorState", 1);
            //xCfg.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            //xCfg.CreateIntAttr("FocusWholeRow", 1);
            if (ShowGantt)
            {

                xCfg.CreateStringAttr("ScrollLeft", "0");
            }


            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");
            m_xPeriodCols = xGrid.CreateSubStruct("RightCols");
     //       m_xPeriodCols = xCols;
            CStruct xHead = xGrid.CreateSubStruct("Head");
            m_xHeader1 = xHead.CreateSubStruct("Header");
            m_xHeader2 = xHead.CreateSubStruct("Header");

            m_xHeader2.CreateStringAttr("id", "Header");
            m_xHeader2.CreateIntAttr("SortIcons", 0);

            m_xHeader1.CreateIntAttr("Spanned", -1);
            m_xHeader1.CreateIntAttr("SortIcons", 0);

            m_xHeader1.CreateStringAttr("HoverCell", "Color");
            m_xHeader1.CreateStringAttr("HoverRow", "");
            m_xHeader2.CreateStringAttr("HoverCell", "Color");
            m_xHeader2.CreateStringAttr("HoverRow", "");
            // Add category column
            CStruct xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "Select");
            xC.CreateStringAttr("Type", "Bool");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Width", "20");
            m_xHeader1.CreateStringAttr("Select", " ");
            m_xHeader2.CreateStringAttr("Select", " ");

            if (UsingGrouping)
            {

                xC = xLeftCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "Grouping");
                xC.CreateStringAttr("Type", "Text");
                //xC.CreateIntAttr("Width", 250);
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateBooleanAttr("CanEdit", false);
                m_xHeader1.CreateStringAttr("Grouping", " ");
                m_xHeader2.CreateStringAttr("Grouping", "Grouping");
            }


            foreach (SortFieldDefn sng in DetCol)
            {
                string sn = sng.name.Replace(" ", "");

                sn = sn.Replace("\r", "");
                sn = sn.Replace("\n", "");

                string h1 = " ";
                string h2 = " ";
                int isp = sng.name.IndexOf(" ");

                if (isp == -1)
                {
                    h1 = " ";
                    h2 = sng.name;
                }
                else
                {
                    h1 = sng.name.Substring(0, isp);
                    h2 = sng.name.Substring(isp + 1);
                }
                if (UseCols)
                    xC = xCols.CreateSubStruct("C");
                else
                    xC = xLeftCols.CreateSubStruct("C");

                xC.CreateStringAttr("Name", sn);
                if (sng.fid == (int)FieldIDs.SD_FID || sng.fid == (int)FieldIDs.FD_FID)
                {
                    xC.CreateStringAttr("Type", "Date");
                    xC.CreateStringAttr("Format", "MM/dd/yyyy");
                }
                else if (sng.fid == (int)FieldIDs.FTOT_FID || sng.fid == (int)FieldIDs.DTOT_FID)
                {
                    xC.CreateStringAttr("Type", "Float");
                    xC.CreateStringAttr("Format", ",#.##");

                }
                else
                    xC.CreateStringAttr("Type", "Text");

                xC.CreateIntAttr("CanMove", 0);

                if (sng.selected == 0)
                {
                    xC.CreateIntAttr("Width", 0);
                    //         xC.CreateIntAttr("Hidden", 1);
                }

                xC.CreateBooleanAttr("CanEdit", false);
                m_xHeader1.CreateStringAttr(sn, h1);
                m_xHeader2.CreateStringAttr(sn, h2);

                if (sng.fid == DetFreeze)
                    UseCols = true;
            }


            if (ShowGantt == false)
                return true;

            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "G");
            xC.CreateStringAttr("Type", "Gantt");
            xC.CreateStringAttr("GanttObject", "Main");

            xC.CreateStringAttr("CanExport", "0");

            xC.CreateIntAttr("GanttLap", 1);
            xC.CreateStringAttr("GanttStart", "Start");
            xC.CreateStringAttr("GanttEnd", "Finish");
     //       xC.CreateStringAttr("GanttComplete", "0");



            xC.CreateStringAttr("GanttUnits", "d");
            xC.CreateStringAttr("GanttChartRound", "w");


            xC.CreateStringAttr("GanttRight", "1");
            xC.CreateStringAttr("GanttSlack", "Slack");
            xC.CreateStringAttr("GanttHeader1", "y#yy");
            xC.CreateStringAttr("GanttHeader2", "M#MMM");

  //          xC.CreateStringAttr("GanttZoom", "Zoom1");
 
 //           xC.CreateStringAttr("GanttRight", "1");
 //           xC.CreateStringAttr("GanttLeft", "0");
 //           xC.CreateStringAttr("GanttEndLast", "0");
            xC.CreateStringAttr("GanttChartMinStart", dtMin.ToString("MM/dd/yyyy"));
            xC.CreateStringAttr("GanttChartMinEnd", dtMax.ToString("MM/dd/yyyy"));
            xC.CreateStringAttr("GanttChartMaxStart", dtMin.ToString("MM/dd/yyyy"));
            xC.CreateStringAttr("GanttChartMaxEnd", dtMax.ToString("MM/dd/yyyy"));

 //           xC.CreateIntAttr("GanttEditStartMove", 1);
  //           xC.CreateStringAttr("GanttResizeDelete", "0");

             
                    

            m_xHeader1.CreateStringAttr("G", " ");

            CStruct xZoom = xGrid.CreateSubStruct("Zoom");

            CStruct xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom1");
            xZ.CreateStringAttr("GanttUnits", "M6");
            //xZ.CreateStringAttr("GanttWidth", "100");
            xZ.CreateStringAttr("GanttWidth", "60");
            //          xZ.CreateStringAttr("GanttWidthEx", "101");
            xZ.CreateStringAttr("GanttChartRound", "M");
            xZ.CreateStringAttr("GanttHeader1", "y#yyyy");
            xZ.CreateStringAttr("GanttHeader2", "M6#MMM");

            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom2");
            //xZ.CreateStringAttr("GanttWidth", "200");
            xZ.CreateStringAttr("GanttWidth", "40");
            //          xZ.CreateStringAttr("GanttWidthEx", "101");
            xZ.CreateStringAttr("GanttUnits", "M3");
            xZ.CreateStringAttr("GanttChartRound", "y");
            xZ.CreateStringAttr("GanttHeader1", "y#MM yyyy");
            xZ.CreateStringAttr("GanttHeader2", "M3#MMM");

            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom3");
            xZ.CreateStringAttr("GanttUnits", "M");
            xZ.CreateStringAttr("GanttWidth", "50");
            //         xZ.CreateStringAttr("GanttWidthEx", "150");
            xZ.CreateStringAttr("GanttChartRound", "y");
            xZ.CreateStringAttr("GanttHeader1", "M6# MMM yyyy");
            xZ.CreateStringAttr("GanttHeader2", "M#MMM");

            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom4");
            xZ.CreateStringAttr("GanttUnits", "M");
            //xZ.CreateStringAttr("GanttWidth", "90");
            xZ.CreateStringAttr("GanttWidth", "50");
            //         xZ.CreateStringAttr("GanttWidthEx", "50");
            xZ.CreateStringAttr("GanttChartRound", "M");
            xZ.CreateStringAttr("GanttHeader1", "M3#MM");
            xZ.CreateStringAttr("GanttHeader2", "M#MMM");

            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom5");
            xZ.CreateStringAttr("GanttUnits", "d");
            //xZ.CreateStringAttr("GanttWidth", "10");
            xZ.CreateStringAttr("GanttWidth", "6");
            //         xZ.CreateStringAttr("GanttWidthEx", "20");
            xZ.CreateStringAttr("GanttChartRound", "M");
            xZ.CreateStringAttr("GanttHeader1", "M#MM yyyy");
            xZ.CreateStringAttr("GanttHeader2", "w#dd");


            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom6");
            xZ.CreateStringAttr("GanttUnits", "d");
            xZ.CreateStringAttr("GanttWidth", "20");
            //        xZ.CreateStringAttr("GanttWidthEx", "50");
            xZ.CreateStringAttr("GanttChartRound", "M");
            xZ.CreateStringAttr("GanttHeader1", "M#MM yyyy");
            xZ.CreateStringAttr("GanttHeader2", "d#dd");


            return true;
        }
        public void AddPeriodColumn(string sId, string sName, bool ShowFTEs, bool bUseQTY, bool bUseCost, bool bShowdeccosts)
        {
            CStruct xC = null;

            if (bUseQTY && bUseCost)
            {
                m_xHeader1.CreateStringAttr("P" + sId + "VSpan", "2");
                m_xHeader1.CreateStringAttr("P" + sId + "V", sName);
            }
            else if (bUseQTY)
            {
                m_xHeader1.CreateStringAttr("P" + sId + "V", sName);
            }
            else
                m_xHeader1.CreateStringAttr("P" + sId + "C", sName);


            if (bUseQTY)
            {

                if (ShowFTEs)
                    m_xHeader2.CreateStringAttr("P" + sId + "V", " FTE ");
                else
                    m_xHeader2.CreateStringAttr("P" + sId + "V", " Qty ");
            }

            if (bUseCost)
                m_xHeader2.CreateStringAttr("P" + sId + "C", " Cost ");

            if (bUseQTY)
            {
                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + sId + "V");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", "#.##");
            }
            //xC.CreateBooleanAttr("CanEdit", true);
            if (bUseCost)
            {

                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + sId + "C");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                //             xC.CreateStringAttr("Format", "#.##");
                xC.CreateStringAttr("Format", (bShowdeccosts ? ",#.00;-,#.00;0" : ",0"));
            }
            //xC.CreateBooleanAttr("CanEdit", false);

        }
        public void FinalizeGridLayout()
        {
            //m_xTabber.CreateStringAttr("Cells", m_sTabCells);


        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }
    internal class TopGridCostsData
    {
        private CStruct xGrid;
        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;

        public bool InitializeGridData()
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            //xCfg.CreateStringAttr("id", "EditCostsGrid");
            //xCfg.CreateStringAttr("id", "g_" + CostTypeId.ToString());
            xCfg.CreateIntAttr("FilterEmpty", 1);

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_nLevel = 0;
            m_xLevels[m_nLevel] = xI;
            return true;
        }
        public void AddDetailRow(DetailRowData oDet, int rID, bool UsingGrouping, bool ShowFTEs, bool ShowGantt, List<SortFieldDefn> DetCol, int minp, int maxp, bool bUseQTY, bool bUseCost, bool bshowcostdec)
        {
            CStruct xIParent = m_xLevels[oDet.m_lev - 1];
            CStruct xI = xIParent.CreateSubStruct("I");

            bool bCellhtml = false;

            m_xLevels[oDet.m_lev] = xI;
            xI.CreateStringAttr("id", rID.ToString());
            if (oDet.bRealone == false)
            {

        //        xI.CreateStringAttr("Color", "0xDADCDD");             //     "204,236,255");

                //if (ShowGantt)
                //    bCellhtml = true;
                //else
                //{

                //    xI.CreateStringAttr("HtmlPrefix", "<B>");
                //    xI.CreateStringAttr("HtmlPostfix", "</B>");
                //}

            }
            else
            {
                xI.CreateStringAttr("Color", "255,255,255");

            }

        //    xI.CreateStringAttr("Color", "255,255,255");

            xI.CreateStringAttr("Select", (oDet.bSelected ? "1" : "0"));
            xI.CreateBooleanAttr("SelectCanEdit", true);
             xI.CreateBooleanAttr("CanEdit", false);

            if (oDet.m_lev != 1)
                xI.CreateIntAttr("CanFilter", 2);


            if (UsingGrouping)
            {
                xI.CreateStringAttr("Grouping", oDet.sName);
                if (bCellhtml)
                {

                    xI.CreateStringAttr("GroupingHtmlPrefix", "<B>");
                    xI.CreateStringAttr("GroupingHtmlPostfix", "</B>");
                }

            }


            foreach (SortFieldDefn sng in DetCol)
            {
                string sn = sng.name.Replace(" ", "");


                sn = sn.Replace("\r", "");
                sn = sn.Replace("\n", "");

                //if (bCellhtml)
                //{

                //    xI.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                //    xI.CreateStringAttr(sn + "HtmlPostfix", "</B>");
                //}

             //   if (oDet.bRealone == false)
            //        xI.CreateStringAttr(sn + "Color", "0xDADCDD");  


                if (sng.fid == (int)FieldIDs.SD_FID)
                {

                    if (oDet.Det_Start != DateTime.MinValue)
                        xI.CreateStringAttr(sn, oDet.Det_Start.ToShortDateString());

                }
                else if (sng.fid == (int)FieldIDs.FD_FID)
                {
                    if (oDet.Det_Finish != DateTime.MinValue)
                        xI.CreateStringAttr(sn, oDet.Det_Finish.ToShortDateString());
                }

                else if (sng.fid == (int)FieldIDs.FTOT_FID)
                    xI.CreateStringAttr(sn, oDet.m_tot1.ToString());

                else if (sng.fid == (int)FieldIDs.DTOT_FID)
                    xI.CreateStringAttr(sn, oDet.m_tot2.ToString());
                else if (sng.fid == (int)FieldIDs.PI_FID)
                    xI.CreateStringAttr(sn, oDet.PI_Name);

                else if (sng.fid == (int)FieldIDs.CT_FID)
                    xI.CreateStringAttr(sn, oDet.CT_Name);

                else if (sng.fid == (int)FieldIDs.SCEN_FID)
                    xI.CreateStringAttr(sn, oDet.Scen_Name);

                else if (sng.fid == (int)FieldIDs.BC_FID)
                    xI.CreateStringAttr(sn, oDet.Cat_Name);

                else if (sng.fid == (int)FieldIDs.FULLC_FID)
                    xI.CreateStringAttr(sn, oDet.FullCatName);

                else if (sng.fid == (int)FieldIDs.CAT_FID)
                    xI.CreateStringAttr(sn, oDet.CC_Name);

                else if (sng.fid == (int)FieldIDs.FULLCAT_FID)
                    xI.CreateStringAttr(sn, oDet.FullCCName);

                else if (sng.fid == (int)FieldIDs.BC_ROLE)
                    xI.CreateStringAttr(sn, oDet.Role_Name);

                else if (sng.fid == (int)FieldIDs.MC_FID)
                    xI.CreateStringAttr(sn, oDet.MC_Name);

                else if (sng.fid >= 11801 && sng.fid <= 11805)
                    xI.CreateStringAttr(sn, oDet.Text_OCVal[sng.fid - 11800]);

                else if (sng.fid >= 11811 && sng.fid <= 11815)
                    xI.CreateStringAttr(sn, oDet.TXVal[sng.fid - 11810]);
                else if (sng.fid >= (int)FieldIDs.PI_USE_EXTRA + 1 && sng.fid <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                {

                    if (oDet.m_PI_Format_Extra_data != null)
                        xI.CreateStringAttr(sn, oDet.m_PI_Format_Extra_data[sng.fid - (int)FieldIDs.PI_USE_EXTRA]);
                }
                else
                    xI.CreateStringAttr(sn, " ");

            }



                xI.CreateIntAttr("NoColorState", 1);


            if (ShowGantt)
            {
                if (oDet.bGotChildren == false)
                     xI.CreateStringAttr("GGanttClass", "GanttBlue");


                return;
            }

            for (int i = minp; i <= maxp; i++)
            {

                if (bUseQTY)
                {
                    if (ShowFTEs)
                    {
                        if (oDet.zFTE[i] != double.MinValue)
                            xI.CreateDoubleAttr("P" + i.ToString() + "V", oDet.zFTE[i]);
                    }
                    else
                    {
                        if (oDet.zValue[i] != double.MinValue)
                            xI.CreateDoubleAttr("P" + i.ToString() + "V", oDet.zValue[i]);
                    }
                }

                if (bUseCost)
                {
                    double dcost = oDet.zCost[i];

                    if (bshowcostdec == false)
                        dcost = Math.Floor(dcost);

                    if (oDet.zCost[i] != double.MinValue)
                        xI.CreateDoubleAttr("P" + i.ToString() + "C", dcost);
                }
            }
        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }
    internal class BottomGridCostsLayout
    {
        private CStruct xGrid;
        private CStruct m_xPeriodCols;
        private CStruct m_xHeader1;
        private CStruct m_xHeader2;


        public bool InitializeGridLayout(bool UsingGrouping, List<SortFieldDefn> TotCol, int TotFreeze)
        {
            bool UseCols = false;

            if (TotFreeze == 0)
                UseCols = true;

            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            //xCfg.CreateStringAttr("id", "g_" + CostTypeId.ToString());
            if (UsingGrouping)
                xCfg.CreateStringAttr("MainCol", "Grouping");
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("PrintCols", 0);

            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateBooleanAttr("NoTreeLines", true);

            //xCfg.CreateIntAttr("MaxHeight", 1);
            xCfg.CreateIntAttr("MaxWidth", 1);
            //xCfg.CreateStringAttr("IdNames", "Grouping");
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            //        xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            xCfg.CreateIntAttr("LeftWidth", 400);

            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);

            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "Modeler");

            xCfg.CreateIntAttr("FocusWholeRow", 1);

            //xCfg.CreateStringAttr("HoverCell", "Color");
            //xCfg.CreateStringAttr("HoverRow", "Color");
            //xCfg.CreateStringAttr("FocusCell", "");
            //xCfg.CreateStringAttr("HoverCell", "Color");
            //xCfg.CreateIntAttr("NoColorState", 1);
            //xCfg.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");

            CStruct m_xDef;
            CStruct m_xDefTree;

            m_xDef = xGrid.CreateSubStruct("Def");

            m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");


            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefTree.CreateIntAttr("NoColorState", 1);

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");

            m_xPeriodCols = xGrid.CreateSubStruct("RightCols");
            //m_xPeriodCols = xCols;
            CStruct xHead = xGrid.CreateSubStruct("Head");
            m_xHeader1 = xHead.CreateSubStruct("Header");
            m_xHeader1.CreateIntAttr("CategoryVisible", -1);
            m_xHeader1.CreateIntAttr("Spanned", -1);
            m_xHeader1.CreateIntAttr("SortIcons", 0);

            m_xHeader2 = xHead.CreateSubStruct("Header");
            m_xHeader2.CreateStringAttr("id", "Header");
            m_xHeader2.CreateIntAttr("SortIcons", 0);

            m_xHeader1.CreateStringAttr("HoverCell", "Color");
            m_xHeader1.CreateStringAttr("HoverRow", "");
            m_xHeader2.CreateStringAttr("HoverCell", "Color");
            m_xHeader2.CreateStringAttr("HoverRow", "");

            xCfg.CreateIntAttr("RightWidth", 800);
            xCfg.CreateIntAttr("MinMidWidth", 200);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 1);
            xCfg.CreateIntAttr("RightCanResize", 1);

            // Add category column
            CStruct xC = xLeftCols.CreateSubStruct("C");

            if (UsingGrouping)
            {

                xC = xLeftCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "Grouping");
                xC.CreateStringAttr("Type", "Text");
                //xC.CreateIntAttr("Width", 250);
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateBooleanAttr("CanEdit", false);
                m_xHeader1.CreateStringAttr("Grouping", " ");
                m_xHeader2.CreateStringAttr("Grouping", "Grouping");
            }


            foreach (SortFieldDefn sng in TotCol)
            {
                string sn = sng.name.Replace(" ", "");


                sn = sn.Replace("\r", "");
                sn = sn.Replace("\n", "");

                string h1 = " ";
                string h2 = " ";
                int isp = sng.name.IndexOf(" ");

                if (isp == -1)
                {
                    h1 = " ";
                    h2 = sng.name;
                }
                else
                {
                    h1 = sng.name.Substring(0, isp);
                    h2 = sng.name.Substring(isp + 1);
                }
                if (UseCols)
                    xC = xCols.CreateSubStruct("C");
                else
                    xC = xLeftCols.CreateSubStruct("C");

                xC.CreateStringAttr("Name", sn);
                if (sng.fid == (int)FieldIDs.SD_FID || sng.fid == (int)FieldIDs.FD_FID)
                {
                    xC.CreateStringAttr("Type", "Date");
                    xC.CreateStringAttr("Format", "MM/dd/yyyy");
                }
                else if (sng.fid == (int)FieldIDs.FTOT_FID || sng.fid == (int)FieldIDs.DTOT_FID)
                {
                    xC.CreateStringAttr("Type", "Float");
                    xC.CreateStringAttr("Format", ",#.##");

                }
                else
                    xC.CreateStringAttr("Type", "Text");

                xC.CreateIntAttr("CanMove", 0);

                if (sng.selected == 0)
                {
                    xC.CreateIntAttr("Width", 0);
                    //         xC.CreateIntAttr("Hidden", 1);
                }

                xC.CreateBooleanAttr("CanEdit", false);
                m_xHeader1.CreateStringAttr(sn, h1);
                m_xHeader2.CreateStringAttr(sn, h2);

                if (sng.fid == TotFreeze)
                    UseCols = true;
            }



            return true;
        }
        public void AddPeriodColumn(string sId, string sName, bool ShowFTEs, bool bUseQTY, bool bUseCost, bool bShowdeccosts)
        {


            CStruct xC = null;

            if (bUseQTY && bUseCost)
            {
                m_xHeader1.CreateStringAttr("P" + sId + "VSpan", "2");
                m_xHeader1.CreateStringAttr("P" + sId + "V", sName);
            }
            else if (bUseQTY)
            {
                m_xHeader1.CreateStringAttr("P" + sId + "V", sName);
            }
            else
                m_xHeader1.CreateStringAttr("P" + sId + "C", sName);


            if (bUseQTY)
            {

                if (ShowFTEs)
                    m_xHeader2.CreateStringAttr("P" + sId + "V", " FTE ");
                else
                    m_xHeader2.CreateStringAttr("P" + sId + "V", " Qty ");
            }

            if (bUseCost)
                m_xHeader2.CreateStringAttr("P" + sId + "C", " Cost ");

            if (bUseQTY)
            {
                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + sId + "V");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", "#.##");
            }


            if (bUseCost)
            {

                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + sId + "C");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", (bShowdeccosts ? ",#.00;-,#.00;0" : ",0"));
            }
        }
        public void FinalizeGridLayout()
        {
            //m_xTabber.CreateStringAttr("Cells", m_sTabCells);


        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }
    internal class BottomGridCostsData
    {
        private CStruct xGrid;
        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;
        public bool InitializeGridData(bool UsingGrouping)
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            //xCfg.CreateStringAttr("id", "EditCostsGrid");
            //xCfg.CreateStringAttr("id", "g_" + CostTypeId.ToString());

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateStringAttr("Def", "Summary");
            m_nLevel = 0;
            m_xLevels[m_nLevel] = xI;
            return true;
        }
        public void AddDetailRow(DetailRowData oDet, DetailRowData oTar, List<TargetColours> TargetColours, int rID, bool UsingGrouping, bool ShowFTEs, List<SortFieldDefn> TotCol, int minp, int maxp, bool bUseQTY, bool bUseCost, bool bshowRemaining, bool bshowcostdec)
        {
            CStruct xIParent = m_xLevels[oDet.m_lev - 1];
            CStruct xI = xIParent.CreateSubStruct("I");
            m_xLevels[oDet.m_lev] = xI;
            xI.CreateStringAttr("id", rID.ToString());
            xI.CreateStringAttr("Color", "255,255,255");

            xI.CreateBooleanAttr("CanEdit", false);
            if (UsingGrouping)
                xI.CreateStringAttr("Grouping", oDet.sName);

            foreach (SortFieldDefn sng in TotCol)
            {
                string sn = sng.name.Replace(" ", "");

                sn = sn.Replace("\r", "");
                sn = sn.Replace("\n", "");


                if (sng.fid == (int)FieldIDs.SD_FID)
                {

                    if (oDet.Det_Start != DateTime.MinValue)
                        xI.CreateStringAttr(sn, oDet.Det_Start.ToShortDateString());

                }
                else if (sng.fid == (int)FieldIDs.FD_FID)
                {
                    if (oDet.Det_Finish != DateTime.MinValue)
                        xI.CreateStringAttr(sn, oDet.Det_Finish.ToShortDateString());
                }

                else if (sng.fid == (int)FieldIDs.FTOT_FID)
                    xI.CreateStringAttr(sn, oDet.m_tot1.ToString());

                else if (sng.fid == (int)FieldIDs.DTOT_FID)
                    xI.CreateStringAttr(sn, oDet.m_tot2.ToString());
                else if (sng.fid == (int)FieldIDs.PI_FID)
                    xI.CreateStringAttr(sn, oDet.PI_Name);

                else if (sng.fid == (int)FieldIDs.CT_FID)
                    xI.CreateStringAttr(sn, oDet.CT_Name);

                else if (sng.fid == (int)FieldIDs.SCEN_FID)
                    xI.CreateStringAttr(sn, oDet.Scen_Name);

                else if (sng.fid == (int)FieldIDs.BC_FID)
                    xI.CreateStringAttr(sn, oDet.Cat_Name);

                else if (sng.fid == (int)FieldIDs.FULLC_FID)
                    xI.CreateStringAttr(sn, oDet.FullCatName);

                else if (sng.fid == (int)FieldIDs.CAT_FID)
                    xI.CreateStringAttr(sn, oDet.CC_Name);

                else if (sng.fid == (int)FieldIDs.FULLCAT_FID)
                    xI.CreateStringAttr(sn, oDet.FullCCName);

                else if (sng.fid == (int)FieldIDs.BC_ROLE)
                    xI.CreateStringAttr(sn, oDet.Role_Name);

                else if (sng.fid == (int)FieldIDs.MC_FID)
                    xI.CreateStringAttr(sn, oDet.MC_Name);

                else if (sng.fid >= 11801 && sng.fid <= 11805)
                    xI.CreateStringAttr(sn, oDet.Text_OCVal[sng.fid - 11800]);

                else if (sng.fid >= 11811 && sng.fid <= 11815)
                    xI.CreateStringAttr(sn, oDet.TXVal[sng.fid - 11810]);
                else
                    xI.CreateStringAttr(sn, " ");

            }


            //xI.CreateStringAttr("CostCat", oDet.Cat_Name);
            //xI.CreateStringAttr("FullCostCat", oDet.FullCatName);

            //xI.CreateStringAttr("TotCost", oDet.m_tot1.ToString());
            //xI.CreateStringAttr("DispCost", oDet.m_tot2.ToString());


            //xI.CreateStringAttr("Def", "Row");

            double t1, t2, p1, p2, xval;

            string crgb = "", qrgb = "";



            for (int i = minp; i <= maxp; i++)
            {
                if (bUseQTY)
                {
                    if (ShowFTEs)
                    {

                        t1 = oDet.zFTE[i];

                        if (oTar != null)
                            p1 = oTar.zFTE[i];
                        else
                            p1 = 0;

                        xval = t1;

                        if (bshowRemaining)
                            xval -= p1;

                        if (xval != 0)
                            xI.CreateStringAttr("P" + i.ToString() + "V", xval.ToString("0.###"));
                    }
                    else
                    {

                        t1 = oDet.zValue[i];

                        if (oTar != null)
                            p1 = oTar.zValue[i];
                        else
                            p1 = 0;

                        xval = t1;

                        if (bshowRemaining)
                            xval -= p1;

                        if (xval != 0)
                            xI.CreateStringAttr("P" + i.ToString() + "V", xval.ToString("0.##"));
                    }

                    if (t1 == 0 && p1 == 0)
                        qrgb = TargetBackground(t1, 1, TargetColours);
                    else
                        qrgb = TargetBackground(t1, p1, TargetColours);


                }

                if (bUseCost)
                {


                    t2 = oDet.zCost[i];

                    if (oTar != null)
                        p2 = oTar.zCost[i];
                    else
                        p2 = 0;

                    if (t2 == 0 && p2 == 0)
                        crgb = TargetBackground(t2, 1, TargetColours);
                    else
                        crgb = TargetBackground(t2, p2, TargetColours);


                    xval = t2;

                    if (bshowRemaining)
                        xval -= p2;

             //       if (oDet.zCost[i] != 0)

                    if (bshowcostdec == false)
                        xval = Math.Floor(xval);

                        xI.CreateStringAttr("P" + i.ToString() + "C", xval.ToString("0.##"));
                }



                if (crgb != "" && bUseCost)
                    xI.CreateStringAttr("P" + i.ToString() + "CColor", crgb);

                if (qrgb != "" && bUseQTY)
                    xI.CreateStringAttr("P" + i.ToString() + "VColor", qrgb);



            }
        }

        public string GetString()
        {
            return xGrid.XML();
        }


        private string TargetBackground(double Tdbl, double Pdbl, List<TargetColours> TargetColours)
        {


            string sRet = "RGB(217, 255, 255)";

            int rgb = -1;

            if (TargetColours == null)
                return sRet;

            if (TargetColours.Count == 0)
                return sRet;

            if (Tdbl == 0 && Pdbl == 0)
            {
                foreach (TargetColours oT in TargetColours)
                {
                    if (oT.ID == -3)
                    {
                        rgb = oT.rgb_val;
                        break;
                    }
                }
            }
            else if (Tdbl == 0)
            {

                foreach (TargetColours oT in TargetColours)
                {
                    if (oT.ID == -2)
                    {
                        rgb = oT.rgb_val;
                        break;
                    }
                }
            }
            else if (Pdbl == 0)
            {

                foreach (TargetColours oT in TargetColours)
                {
                    if (oT.ID == -1)
                    {
                        rgb = oT.rgb_val;
                        break;
                    }
                }
            }
            else
            {

                double percnt;

                percnt = (Tdbl / Pdbl) * 100;

                foreach (TargetColours oT in TargetColours)
                {
                    if (oT.ID > 0)
                    {

                        if ((percnt >= oT.low_val && percnt <= oT.high_val) || (oT.high_val == 0))
                        {
                            rgb = oT.rgb_val;
                            break;
                        }
                    }
                }
            }

            if (rgb == -1)
                return "";

            return "RGB(" + (rgb & 0xFF).ToString() + "," + ((rgb & 0xFF00) >> 8).ToString() + "," + ((rgb & 0xFF0000) >> 16).ToString() + ")";
        }
    }
    internal class FilterGridCostsLayout
    {
        private CStruct xGrid;

        public void InitializeGridLayout()
        {


            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            xCfg.CreateStringAttr("MainCol", "Filtering");

            xCfg.CreateBooleanAttr("NoTreeLines", true);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            //          xCfg.CreateIntAttr("MaxWidth", 1);
            //          xCfg.CreateIntAttr("ConstHeight", 1);

            xCfg.CreateIntAttr("ExactSize", 0);
            xCfg.CreateIntAttr("SelectingCells", 1);



            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("PrintCols", 0);

            //xCfg.CreateIntAttr("LeftWidth", 200);
            //xCfg.CreateIntAttr("Width", 300);

            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("FilterEmpty", 1);

            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);

            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "Modeler");






            CStruct xCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xHead = xGrid.CreateSubStruct("Header");

            xHead.CreateIntAttr("Visible", 0);
            // Add category column
            CStruct xC = xCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "Select");
            xC.CreateStringAttr("Type", "Bool");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateStringAttr("Width", "20");
            xHead.CreateStringAttr("Select", " ");

            xC = xCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Filtering");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("Width", 200);
            xC.CreateBooleanAttr("CanEdit", false);
            xHead.CreateStringAttr("Filtering", "Filter");
        }


        public string GetString()
        {
            return xGrid.XML();
        }
    }
    internal class FilterGridCostsData
    {
        private CStruct xGrid;
        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;
        public void InitializeGridData()
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateIntAttr("FilterEmpty", 1);

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_nLevel = 0;
            m_xLevels[m_nLevel] = xI;
        }
        public void AddRow(int rID, int level, string Name, bool Selected)
        {
            CStruct xIParent = null;

            if (level != 0)
                xIParent = m_xLevels[level - 1];
            else
                xIParent = m_xLevels[0];

            CStruct xI = xIParent.CreateSubStruct("I");

            if (level != 0)
                m_xLevels[level] = xI;

            xI.CreateStringAttr("id", rID.ToString());
            if (level == 1)
            {

                xI.CreateStringAttr("Color", "204,236,255");
                xI.CreateStringAttr("SelectType", "Text");
                xI.CreateStringAttr("Select", " ");
                xI.CreateBooleanAttr("SelectCanEdit", false);
            }
            else
            {
                xI.CreateStringAttr("Color", "254,254,254");

                xI.CreateStringAttr("Select", (Selected ? "1" : "0"));
                xI.CreateBooleanAttr("SelectCanEdit", true);
            }

            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateIntAttr("NoColorState", 1);



            xI.CreateStringAttr("Filtering", Name);

        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }
    internal class TargetGridLayout
    {
        private CStruct xGrid;

        private CStruct m_xHeader1;
        private CStruct m_xHeader2;
        private CStruct m_xPeriodCols;


        public bool InitializeGridLayout(bool ShowFTEs, Dictionary<int, CustomFieldData> CustFields, int ratecount, string costtypejsonMenu, string costcatjsonMenu, int MC_Count)
        {

            CStruct xC = null;

            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("ColResizing", 1);


            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateBooleanAttr("NoTreeLines", true);

            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("FilterEmpty", 1);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            xCfg.CreateIntAttr("ExportFormat", 1);

            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);


            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateStringAttr("Style", "GM"); 
            


 
            //xCfg.CreateIntAttr("ConstHeight", 0);
            //xCfg.CreateIntAttr("ConstWidth", 1);

         // xCfg.CreateIntAttr("MaxHeight", 300);

    //        xCfg.CreateIntAttr("ResizingMain", 3);
    //        xCfg.CreateIntAttr("ResizingMainLap", 1);

            

     //       xCfg.CreateIntAttr("ShowVScroll", 1);

     //       xCfg.CreateIntAttr("ExactSize", 0);
                      




            xCfg.CreateStringAttr("CSS", "Modeler");

            xCfg.CreateIntAttr("LeftWidth", 400);



            xCfg.CreateIntAttr("SuppressCfg", 1);
            xCfg.CreateIntAttr("PrintCols", 0);

            xCfg.CreateIntAttr("Sorting", 0);


            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            m_xPeriodCols = xGrid.CreateSubStruct("Cols");
            //           m_xPeriodCols = xGrid.CreateSubStruct("RightCols");

            CStruct xHead = xGrid.CreateSubStruct("Head");
            m_xHeader1 = xHead.CreateSubStruct("Header");
            m_xHeader2 = xHead.CreateSubStruct("Header");

            m_xHeader2.CreateStringAttr("id", "Header");
            m_xHeader2.CreateIntAttr("SortIcons", 0);

            m_xHeader1.CreateIntAttr("Spanned", -1);
            m_xHeader1.CreateIntAttr("SortIcons", 0);

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Select");
            xC.CreateStringAttr("Type", "Bool");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Width", "20");
            m_xHeader1.CreateStringAttr("Select", " ");
            m_xHeader2.CreateStringAttr("Select", " ");


            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "GroupVal");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateBooleanAttr("Visible", false);
            m_xHeader1.CreateStringAttr("GroupVal", "Group");
            m_xHeader2.CreateStringAttr("GroupVal", "Value");

            // Add category column
            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateStringAttr("Name", "CostType");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateStringAttr("Defaults", costtypejsonMenu);
            m_xHeader1.CreateStringAttr("CostType", "Cost");
            m_xHeader2.CreateStringAttr("CostType", "Type");


            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "CostCategory");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateStringAttr("Defaults", costcatjsonMenu);
            m_xHeader1.CreateStringAttr("CostCategory", "Cost");
            m_xHeader2.CreateStringAttr("CostCategory", "Category");

            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "MajorCategory");
            xC.CreateBooleanAttr("CanEdit", false);

            if (MC_Count <= 1)
                xC.CreateIntAttr("Visible", 0);

            m_xHeader1.CreateStringAttr("MajorCategory", "Major");
            m_xHeader2.CreateStringAttr("MajorCategory", "Category");

            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "Role");
            xC.CreateBooleanAttr("CanEdit", false);
            m_xHeader1.CreateStringAttr("Role", " ");
            m_xHeader2.CreateStringAttr("Role", "Role");

            if (ratecount != 0)
            {

                xC = xLeftCols.CreateSubStruct("C");

                xC.CreateStringAttr("Name", "NamedRate");
                xC.CreateBooleanAttr("CanEdit", false);
                m_xHeader1.CreateStringAttr("NamedRate", "Named ");
                m_xHeader2.CreateStringAttr("NamedRate", "Rate");
            }


            foreach (CustomFieldData oc in CustFields.Values)
            {
                xC = xLeftCols.CreateSubStruct("C");

                xC.CreateStringAttr("Name", "z" + oc.Name);

                if (oc.jsonMenu == "")
                    xC.CreateBooleanAttr("CanEdit", true);
                else
                {
                    xC.CreateBooleanAttr("CanEdit", false);
                    xC.CreateStringAttr("Defaults", oc.jsonMenu);
                }
                m_xHeader1.CreateStringAttr("z" + oc.Name, " ");
                m_xHeader2.CreateStringAttr("z" + oc.Name, oc.DisplayName);

            }



            return true;
        }
        public void AddPeriodColumn(string sId, string sName, bool ShowFTEs)
        {
            CStruct xC = null;

            m_xHeader1.CreateStringAttr("P" + sId + "VSpan", "2");
            m_xHeader1.CreateStringAttr("P" + sId + "V", sName);

            if (ShowFTEs)
                m_xHeader2.CreateStringAttr("P" + sId + "V", " FTE ");
            else
                m_xHeader2.CreateStringAttr("P" + sId + "V", " Qty ");

            m_xHeader2.CreateStringAttr("P" + sId + "C", " Cost ");

            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P" + sId + "V");
            xC.CreateStringAttr("Type", "Float");
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Format", "0.###");

            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P" + sId + "C");
            xC.CreateStringAttr("Type", "Float");
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Format", "#.##");

        }
        public void FinalizeGridLayout()
        {
            //m_xTabber.CreateStringAttr("Cells", m_sTabCells);


        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }
    internal class TargetGridsData
    {
        private CStruct xGrid;
        private CStruct m_xIParentRoot;

        public bool InitializeGridData()
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            //xCfg.CreateStringAttr("id", "EditCostsGrid");
            //xCfg.CreateStringAttr("id", "g_" + CostTypeId.ToString());
            xCfg.CreateIntAttr("FilterEmpty", 1);


            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_xIParentRoot = xI;
            return true;
        }
        public void AddDetailRow(DetailRowData oDet, int rID, bool ShowFTEs, int maxp, Dictionary<int, CustomFieldData> CustFields, int ratecount)
        {
            CStruct xIParent = m_xIParentRoot;
            CStruct xI = xIParent.CreateSubStruct("I");
 
            xI.CreateStringAttr("id", rID.ToString());
    

            xI.CreateStringAttr("CostType", oDet.CT_Name);
            xI.CreateStringAttr("CostCategory", oDet.FullCatName);

            xI.CreateStringAttr("CostTypeButton", "Defaults");
            xI.CreateStringAttr("CostCategoryButton", "Defaults");

            xI.CreateStringAttr("MajorCategory", oDet.MC_Name);
            xI.CreateIntAttr("MajorCategoryCanEdit", 0);
            xI.CreateStringAttr("Role", oDet.Role_Name);
            xI.CreateIntAttr("RoleCanEdit", 0);
            if (ratecount != 0)
            {
                xI.CreateStringAttr("NamedRate", oDet.m_rt_name);
            }


            foreach (CustomFieldData oc in CustFields.Values)
            {
                string stxt;

                if (oc.FieldID < 11810)
                    stxt = oDet.Text_OCVal[oc.FieldID - 11800];
                else
                    stxt = oDet.TXVal[oc.FieldID - 11810];

                xI.CreateStringAttr("z" + oc.Name, stxt);

                if (oc.jsonMenu != "")
                    xI.CreateStringAttr("z" + oc.Name + "Button", "Defaults");

            }


            xI.CreateIntAttr("NoColorState", 1);


            for (int i = 0; i <= maxp; i++)
            {
                if (ShowFTEs)
                {
                    if (oDet.zFTE[i] != double.MinValue)
                        xI.CreateDoubleAttr("P" + i.ToString() + "V", oDet.zFTE[i]);
                }
                else
                {
                    if (oDet.zValue[i] != double.MinValue)
                        xI.CreateDoubleAttr("P" + i.ToString() + "V", oDet.zValue[i]);
                }

                if (oDet.zCost[i] != double.MinValue)
                    xI.CreateDoubleAttr("P" + i.ToString() + "C", oDet.zCost[i]);


                if (oDet.sUoM == "")
                {
                    xI.CreateIntAttr("P" + i.ToString() + "VCanEdit", 0);
                    xI.CreateIntAttr("P" + i.ToString() + "CCanEdit", 1);
                }
                else
                {
                    xI.CreateIntAttr("P" + i.ToString() + "CCanEdit", 0);
                    xI.CreateIntAttr("P" + i.ToString() + "VCanEdit", 1);
                }
            }
        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }
    internal class TargetLegendGridLayout
    {
        private CStruct xGrid;

        public void InitializeGridLayout()
        {


            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("FilterEmpty", 1);

            xCfg.CreateBooleanAttr("NoTreeLines", true);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("HideHScroll", 1);

            //xCfg.CreateIntAttr("ExactSize", 0);
            xCfg.CreateIntAttr("SelectingCells", 1);





            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("FilterEmpty", 1);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "Modeler");

            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);

  

            CStruct xCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xHead = xGrid.CreateSubStruct("Header");

            xHead.CreateIntAttr("Visible", 0);
            // Add category column
            CStruct xC = xCols.CreateSubStruct("C");


            xC = xCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Key");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("Width", 400);
            xC.CreateBooleanAttr("CanEdit", false);
            xHead.CreateStringAttr("Key", " ");
        }


        public string GetString()
        {
            return xGrid.XML();
        }
    }
    internal class TargetLegendGridData
    {
        private CStruct xGrid;
        private CStruct m_Par = new CStruct();
        public void InitializeGridData()
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateIntAttr("FilterEmpty", 1);

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_Par = xI;
        }

        public void AddRow(string Name, string srgb)
        {

            CStruct xI = m_Par.CreateSubStruct("I");

            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateIntAttr("NoColorState", 1);



            xI.CreateStringAttr("Key", Name);
            if (srgb != "")
                xI.CreateStringAttr("KeyColor", srgb);

        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }

    [Serializable()]
    public class ModelCache
    {

        private const int EPK_FTYPE_DATE = 1;
        private const int EPK_FTYPE_INTEGER = 2;
        private const int EPK_FTYPE_NUMBER = 3;
        private const int EPK_FTYPE_CODE = 4;
        private const int EPK_FTYPE_URL = 6;
        private const int EPK_FTYPE_RES = 7;
        private const int EPK_FTYPE_CURRENCY = 8;
        private const int EPK_FTYPE_TEXT = 9;
        private const int EPK_FTYPE_PERCENT = 11;
        private const int EPK_FTYPE_YESNO = 13;
        private const int EPK_FTYPE_RTF = 19;
        private const int EPK_FTYPE_WORK = 20;
        private const int EPK_FTYPE_DURATION = 23;
        private const int EPK_FTYPE_OWNER = 12346;

        private const string CONST_CURRENT = "Current";


        private string m_sTicket = "";
        private string m_sModel = "";
        private bool m_GotAllPIs = true;
        private int m_PI_Count = 0;
        private int m_lowlevelDataCount = 0;
        private int m_loaddatareturn = 0;
        private string m_loadmsg = "";

        private string m_sPids = "";

        private string m_Selected_Table = "";
        private string m_Select_FieldName = "";
        private int m_CB_ID = 0;
        private int m_SelFID = 0;
        private string m_sCostTypes = "";
        private string m_sOtherCostTypes = "";
        private string m_sCalcCostTypes = "";
        private int m_PI_Group = 0;
        private int m_PI_Group_fid = 0;
        private int m_PI_Seq = 0;
        private int m_PI_Seq_fid = 0;
        private bool m_pi_top = false;

        private List<DataItem> m_CT_Views = null;

        private Dictionary<int, PeriodData> m_Periods = null;
        private int maxp = 0;
        private DateTime m_statdate;
        private int m_status_period = 0;
        private int[] perind = null;
        private DateTime[] persta = null;
        private DateTime[] perfin = null;
        private int[] m_PeriodMode = null;
        private int m_max_period = 0;

        private Dictionary<int, CatItemData> m_CostCat = null;
        private Dictionary<int, CatItemData> m_CostCat_rolly = null;
        private Dictionary<string, int> m_Role_CC = null;

        private Dictionary<int, CustomFieldData> m_CustFields = null;
        private List<PortFieldData> m_CustAttribs = null;
        private Dictionary<int, DataItem> m_CostTypes = null;
        private Dictionary<int, DataItem> m_Scenario = null;
        private Dictionary<int, DataItem> m_stages = null;

        private string[] m_sextra = new string[(int)FieldIDs.MAX_PI_EXTRA + 1];
        private string[] m_ExtraFieldNames = new string[(int)FieldIDs.MAX_PI_EXTRA + 1];
        private int[] m_fidextra = new int[(int)FieldIDs.MAX_PI_EXTRA + 1];
        private int[] m_ExtraFieldTypes = new int[(int)FieldIDs.MAX_PI_EXTRA + 1];
        private int m_Use_extra = 0;

        private Dictionary<string, PIData> m_PIs = null;
        private Dictionary<int, DataItem> m_codes = null;
        private Dictionary<int, DataItem> m_reses = null;

        private Dictionary<string, DetailRowData> m_detaildata = null;
        private Dictionary<string, DetailRowData> m_targetdata = null;
        private List<TargetColours> m_TargetColours = null;
        private List<DataItem> m_Target = null;
        private List<DataItem> m_AssignableCTS = null;

        private Dictionary<int, RateTable> m_Rates = null;
        private Dictionary<string, RateFTECache> m_ratecache = null;

        private int m_display_minp, m_display_maxp;
        private int m_drag_minp, m_drag_maxp;

        private bool[] m_cust_Defn = null;
        private int[] m_cust_full = null;
        private CustomFieldData[] m_cust_ocf = null;
        private Dictionary<int, ListItemData>[] m_cust_lk = null;
        private Dictionary<int, DataItem>[] m_filter_sel = new Dictionary<int, DataItem>[31];
        private bool m_allow_grouping = false;
        private bool m_grouping_enabled = true;
        private List<ListItemData> m_CT_List = null;
        private List<ListItemData> m_BC_List = null;
        private List<ListItemData> m_BC_Role_List = null;

        private List<DetailRowData> m_filtersource = null;
        private List<DetailRowData> m_tgrid_sorted = null;
        private List<DetailRowData> m_tgrid_displayed = null;
        private List<DetailRowData> m_bgrid_sorted = null;
        private List<DetailRowData> m_target_sorted = null;

        private bool m_Det_grouped = false, m_Tot_grouped = false;

        private List<DataItem> m_filterList = null;
        private List<DataItem> m_filterRoot = null;
        private Dictionary<string, DataItem> m_selcln = null;
        private List<DataItem> m_TotalRoot = null;
        private List<DataItem> m_CTARoot = null;
        private List<SortFieldDefn> m_DetColRoot = null;
        private List<SortFieldDefn> m_TotColRoot = null;
        private int m_DetFreeze = 0, m_TotFreeze = 0;

        int m_apply_target;
        private Dictionary<string, DetailRowData> m_total_dets = null, m_target_dets = null;
        private List<DetailRowData> m_list_total_dets = null, m_list_target_dets = null;
        private int[,] m_SnGFids = new int[2, 3];
        private int[,] m_SnGGrp = new int[2, 3];
        private int[,] m_SnGAsc = new int[2, 3];

        private List<SortFieldDefn> m_DetFields = null, m_TotFields = null;

        private string bottomgridlayoutcache;
        private bool bShowFTEs, bUseQTY, bUseCosts;
        private bool bShowGantt;
        private DateTime m_dtMin, m_dtMax;

        private int m_detShowToLevel, m_totShowToLevel;

        string m_CostCatjsonMenu = "";
        string m_CostTypejsonMenu = "";

        List<DetailRowData> m_editTargetList = null;

        private bool m_bCTAMode = false;
        private int m_mode = 0;

        private bool m_ShowRemaining = false;
        private string m_WResID = "";
        private bool m_show_rhs_dec_costs = false;
        private DataItem m_init_def_view = null;
        private int m_init_def_view_pos = -1;

        private string m_tarnames = "";
        private string m_initial_zoom = "";



        //      private SqlConnection oDataAccess = null;


        public int InitalLoadData(SqlConnection oDataAccess, string ticket, string model, string versions, string sWResID, string sViewID)
        {
            try {

                m_loadmsg = "";
                bShowFTEs = false;
                bShowGantt = false;
                bUseQTY = true;
                bUseCosts = true;


                bottomgridlayoutcache = "";
                //      oDataAccess = oDataAccess;
                m_sTicket = ticket;
                m_sModel = model;

                m_WResID = sWResID;

                GrabPidsFromTickect(oDataAccess, ticket, out m_sPids, out m_GotAllPIs, out m_PI_Count);

                int lFirstP = 0;
                int lLastP = 0;

                m_bCTAMode = false;

                if (sViewID != "")
                {
                    GrabCostViewInfo(oDataAccess, sViewID, out m_CB_ID, out m_sCostTypes, out m_sOtherCostTypes, out lFirstP, out lLastP);
                    m_SelFID = 0;
                    m_bCTAMode = true;

                    m_mode = 1001;
                }
                else
                {
                    GrabModelInfo(oDataAccess, model, out m_CB_ID, out m_SelFID, out m_sCostTypes, out m_sOtherCostTypes);
                    m_mode = 1000;
                    bShowGantt = true;
                }


                m_lowlevelDataCount = 0;
                m_loaddatareturn = 0;


                if (m_CB_ID < 0 || m_sPids == "")
                {
                    if (m_CB_ID < 0)
                    {
                        m_loadmsg = "No Cost Breakdown (CB_IB) specified";
                        m_loaddatareturn = 1;
                    }

                    return 1;
                }


                if (m_sCostTypes == "" && m_sOtherCostTypes == "")
                {
                    m_loadmsg = "No Cost Types specified";
                    m_loaddatareturn = 2;
                    return 2;
                }



                GrabViewsAndStatus(oDataAccess, sWResID, m_mode);
                m_init_def_view = null;
                m_init_def_view_pos = -1;
                int xi = -1;

                if (m_CT_Views != null)
                {
                    foreach (DataItem oitem in m_CT_Views)
                    {
                        ++xi;

                        if (m_init_def_view == null)
                        {
                            m_init_def_view = oitem;   // default to first view if no defaults
                            m_init_def_view_pos = 0;

                        }
  
                        if (oitem.UID == 1)
                        {
                            m_init_def_view = oitem;
                            m_init_def_view_pos = xi;
                            break;
                        }
                    }
                }


                ReadPeriods(oDataAccess);
                ReadCatItems(oDataAccess);
                ReadCustomFields(oDataAccess);
                ReadCostTypeNames(oDataAccess);

                List<ItemDefn> optlist = null;
                DateTime edate, ldate;
                ReadModelNames(model, sWResID, oDataAccess, ref optlist);
                ReadStages(oDataAccess);
                ReadExtraPifields(oDataAccess);
                ReadPILevelData(oDataAccess, out edate, out ldate);
                ReadCostCustomFieldsAndData(oDataAccess);
                ReadBudgetBands(oDataAccess);
                ReadModelTargets(oDataAccess, sWResID);
                ReadRateTable(oDataAccess);


                int psfppid = 0;
                int pslppid = 0;

                            
                foreach (PeriodData oPeriod in m_Periods.Values) {

                    if (edate != DateTime.MinValue)
                    {
                        if (oPeriod.StartDate <= edate && edate <= oPeriod.FinishDate) 
                            psfppid = oPeriod.PeriodID;
                    }

                    if (ldate != DateTime.MinValue)
                    {
                        if (oPeriod.StartDate <= ldate && ldate <= oPeriod.FinishDate) 
                            pslppid = oPeriod.PeriodID;
                    }

                }




                m_display_minp = 1;
                m_display_maxp = m_max_period;
                m_drag_minp = 1;
                m_drag_maxp = m_max_period;

                if (lFirstP == 0 && psfppid != 0)
                {
                    m_display_minp = psfppid;
                    m_drag_minp = m_display_minp;
                }

                else if (lFirstP >= m_display_minp && lFirstP <= m_display_maxp)
                {

                    m_display_minp = lFirstP;
                }

                if (lLastP == 0 && pslppid != 0)
                {
                    m_display_maxp = pslppid;
                    m_drag_maxp = m_display_maxp;
                }

                else if (lLastP >= m_display_minp && lLastP <= m_display_maxp)
                {

                    m_display_maxp = lLastP;
                }


                if (versions != "")
                    LoadScenarios(oDataAccess, versions, false, true);

                oDataAccess = null;

                m_allow_grouping = (m_PI_Group_fid != 0 && m_PI_Seq_fid != 0);

                m_allow_grouping = false;

                if (m_detaildata != null)
                    m_lowlevelDataCount = (m_detaildata.Count == 0 ? 0 : 1);

                if (m_lowlevelDataCount == 0)
                    return 0;


                StashRateCache();

                m_dtMin = m_dtMin.AddDays(-190);
                m_dtMax = m_dtMax.AddDays(5 * 366);   // add 5 years onto the end of the Gantt
 
                BuildCustomFilterLists();

                m_initial_zoom = SelectUserViewData(oDataAccess, m_init_def_view_pos);

                ProcessAndCreateDistplayLists();

                

                return 0;
 

            }

            catch (Exception ex)
            {
                m_loadmsg = ex.Message;
                m_loaddatareturn = 3;
                return 3;

            }

            //return 2;
        }

        public bool AllPIsPresent()
        {
            return m_GotAllPIs;
        }
        public int LoadScenarioData(SqlConnection oDataAccess, string versions)
        {
            try
            {

                //                m_oDataAccess = oDataAccess;

                if (versions != "")
                    LoadScenarios(oDataAccess, versions, true, true);

                //                m_oDataAccess = null;

                ProcessAndCreateDistplayLists();


                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }
        public int LoadTargetData(SqlConnection oDataAccess, string targets)
        {
            try
            {

                //     m_oDataAccess = oDataAccess;


                if (targets != "")
                    m_apply_target = LoadTargets(oDataAccess, targets);

                //     m_oDataAccess = null;

                ProcessAndCreateDistplayLists();

                return 0;
            }
            catch (Exception)
            {
                return 1;
            }


        }
        private int GrabPidsFromTickect(SqlConnection oDataAccess, string ticket, out string sPids, out bool bNoneMissing, out int PICount)
        {

            string sCommand = "";
            int eStatus = 0;
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sGuids = "";
            string sGin = "";
            sPids = "";
            bNoneMissing = true;
            PICount = 0;
            int i = 0;
            int lPid;

            //if (ticket == "debug")
            //{
            //    sCommand = "SELECT PROJECT_ID FROM EPGP_PROJECTS";

            //    oCommand = new SqlCommand(sCommand, oDataAccess);
            //    reader = oCommand.ExecuteReader();
            //    lPid = 0;
            //    while (reader.Read())
            //    {
            //        lPid = DBAccess.ReadIntValue(reader["PROJECT_ID"]);


            //        ++PICount;
            //        if (sPids == "")
            //            sPids = lPid.ToString();
            //        else
            //            sPids = sPids + "," + lPid.ToString();
            //    }
            //    reader.Close();
            //    reader = null;


            //    return eStatus;
            //}

            sCommand = "SELECT DC_DATA FROM EPG_DATA_CACHE WHERE DC_TICKET = '" + ticket + "'";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                sGuids = DBAccess.ReadStringValue(reader["DC_DATA"]);
            }
            reader.Close();
            reader = null;


            sGuids = sGuids.Replace(",", " ");
            sGuids = sGuids.ToUpper();
            sGuids = sGuids.Trim();


            while (sGuids.Length != 0)
            {
                sGin = "";

                i = sGuids.IndexOf(" ");

                if (i == -1)
                {
                    sGin = sGuids;
                    sGuids = "";
                }
                else
                {
                    sGin = sGuids.Substring(0, i);
                    sGuids = sGuids.Substring(i + 1);
                }

                if (sGin != "")
                {

                    sCommand = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE { fn UCASE(PROJECT_EXT_UID) }  = '" + sGin + "'";

                    oCommand = new SqlCommand(sCommand, oDataAccess);
                    reader = oCommand.ExecuteReader();
                    lPid = 0;
                    while (reader.Read())
                    {
                        lPid = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    }
                    reader.Close();
                    reader = null;

                    if (lPid == 0)
                        bNoneMissing = false;
                    else
                    {
                        ++PICount;
                        if (sPids == "")
                            sPids = lPid.ToString();
                        else
                            sPids = sPids + "," + lPid.ToString();
                    }

                }

            }
            return eStatus;

        }
        private int GrabModelInfo(SqlConnection oDataAccess, string sModel, out int lCB_ID, out int lSelFID, out string sCostTypes, out string sOtherCostTypes)
        {

            int eStatus = 0;
            int lModel = 0;
            string sCommand = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;


            lCB_ID = 0;
            lSelFID = 0;
            sCostTypes = "";
            sOtherCostTypes = "";


            try
            {
                lModel = Int32.Parse(sModel);
            }
            catch
            {
                lModel = 0;
            }

            if (lModel == 0)
                return 1;


            sCommand = "SELECT * FROM EPGP_MODEL_SCENARIOS WHERE MODEL_UID = " + sModel;
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();


            while (reader.Read())
            {
                lCB_ID = DBAccess.ReadIntValue(reader["MODEL_CB_ID"]);
                lSelFID = DBAccess.ReadIntValue(reader["MODEL_SELECTED_FIELD_ID"]);

                if (lSelFID < 0)
                    lSelFID = 0;
            }
            reader.Close();
            reader = null;

            if (lCB_ID == 0)
                return 1;


            sCommand = "SELECT EPGP_MODEL_CTS.MODEL_CT_ID, EPGP_COST_TYPES.CT_EDIT_MODE FROM  EPGP_MODEL_CTS INNER JOIN EPGP_COST_TYPES ON EPGP_MODEL_CTS.MODEL_CT_ID = EPGP_COST_TYPES.CT_ID WHERE MODEL_UID = " + sModel;

            int lCTID = 0;
            int lEMode = 0;

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                lCTID = DBAccess.ReadIntValue(reader["MODEL_CT_ID"]);
                lEMode = DBAccess.ReadIntValue(reader["CT_EDIT_MODE"]);

                if (lEMode == 1)
                {
                    if (sCostTypes == "")
                        sCostTypes = lCTID.ToString();
                    else
                        sCostTypes = sCostTypes + "," + lCTID.ToString();

                }
                else
                {
                    if (sOtherCostTypes == "")
                        sOtherCostTypes = lCTID.ToString();
                    else
                        sOtherCostTypes = sOtherCostTypes + "," + lCTID.ToString();

                }

            }
            reader.Close();
            reader = null;

            if (lSelFID != 0)
            {


                oCommand = new SqlCommand("EPG_SP_ReadFieldInfo", oDataAccess);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("FieldID", lSelFID);
                reader = oCommand.ExecuteReader();

                int lTid = 0;
                int lfit = 0;

                while (reader.Read())
                {
                    lTid = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                    lfit = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);


                }
                reader.Close();
                reader = null;

                string stab = "";
                string sfnam = "";


                GetCFFieldName(lTid, lfit, out stab, out sfnam);
                m_Selected_Table = stab;
                m_Select_FieldName = sfnam;
            }
            else
            {
                m_Selected_Table = "";
                m_Select_FieldName = "";
            }
            return eStatus;
        }
        private int GrabCostViewInfo(SqlConnection oDataAccess, string sCostView, out int lCB_ID, out string sCostTypes, out string sOtherCostTypes, out int lMinP, out int lMaxP)
        {

            int eStatus = 0;
            string sCommand = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;

            int lCostView = 0;
            lMinP = 0;
            lMaxP = 0;



            lCB_ID = 0;
            sCostTypes = "";
            sOtherCostTypes = "";


            try
            {
                lCostView = Int32.Parse(sCostView);
            }
            catch
            {
                lCostView = 0;
            }

            if (lCostView == 0)
                return 1;



            sCommand = "SELECT * FROM EPGT_COSTVIEW_DISPLAY WHERE VIEW_UID = " + sCostView;
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();


            while (reader.Read())
            {
                lCB_ID = DBAccess.ReadIntValue(reader["VIEW_COST_BREAKDOWN"]);
                lMinP = DBAccess.ReadIntValue(reader["VIEW_FIRST_PERIOD"]);
                lMaxP = DBAccess.ReadIntValue(reader["VIEW_LAST_PERIOD"]);


            }
            reader.Close();
            reader = null;

            if (lCB_ID == 0)
                return 1;




            sCommand = "SELECT  EPGT_COSTVIEW_COST_TYPES.CT_ID, EPGP_COST_TYPES.CT_EDIT_MODE FROM EPGT_COSTVIEW_COST_TYPES INNER JOIN EPGP_COST_TYPES ON EPGT_COSTVIEW_COST_TYPES.CT_ID = EPGP_COST_TYPES.CT_ID WHERE VIEW_UID = " + sCostView;

            int lCTID = 0;
            int lEMode = 0;

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                lCTID = DBAccess.ReadIntValue(reader["CT_ID"]);
                lEMode = DBAccess.ReadIntValue(reader["CT_EDIT_MODE"]);

                if (lEMode == 1)
                {
                    if (sCostTypes == "")
                        sCostTypes = lCTID.ToString();
                    else
                        sCostTypes = sCostTypes + "," + lCTID.ToString();

                }
                else 
                {
                    if (sOtherCostTypes == "")
                        sOtherCostTypes = lCTID.ToString();
                    else
                        sOtherCostTypes = sOtherCostTypes + "," + lCTID.ToString();

                    if (lEMode == 3)
                    {
                        if (m_sCalcCostTypes == "")
                            m_sCalcCostTypes = lCTID.ToString();
                        else
                            m_sCalcCostTypes = m_sCalcCostTypes + "," + lCTID.ToString();
                    }


                }

            }
            reader.Close();
            reader = null;

            return eStatus;
        }
        private void GrabViewsAndStatus(SqlConnection oDataAccess, string sWResID, int lMode)
        {

            string sCommand = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;


            sCommand = " SELECT ADM_STATUS_DATE, ADM_PI_GROUP_CF1 AS GID, ADM_PI_GROUP_CF2 AS GSQ From EPG_ADMIN";
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                m_statdate = DBAccess.ReadDateValue(reader["ADM_STATUS_DATE"]);
                m_PI_Group = DBAccess.ReadIntValue(reader["GID"]);
                m_PI_Seq = DBAccess.ReadIntValue(reader["GSQ"]);

            }
            reader.Close();
            reader = null;

            m_PI_Group = 0;
            m_PI_Seq = 0;

            LoadUserViews(oDataAccess);


        }
        private void ReadPeriods(SqlConnection oDataAccess)
        {
            PeriodData oPeriod;

            //if (oDataAccess.State == ConnectionState.Open) oDataAccess.Close();
            //oDataAccess.Open();

            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            maxp = 0;

            m_Periods = new Dictionary<int, PeriodData>();

            oCommand = new SqlCommand("EPG_SP_ReadPeriods", oDataAccess);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            oCommand.Parameters.AddWithValue("CalID", m_CB_ID);
            reader = oCommand.ExecuteReader();




            while (reader.Read())
            {
                oPeriod = new PeriodData();


                oPeriod.PeriodID = DBAccess.ReadIntValue(reader["PRD_ID"]);
                oPeriod.PeriodName = DBAccess.ReadStringValue(reader["PRD_NAME"]);
                oPeriod.StartDate = DBAccess.ReadDateValue(reader["PRD_START_DATE"]);
                oPeriod.FinishDate = DBAccess.ReadDateValue(reader["PRD_FINISH_DATE"]);

                if (maxp == 0)
                {
                    m_dtMin = oPeriod.StartDate;
                    m_dtMax = oPeriod.FinishDate;
                }
                else if (m_dtMax < oPeriod.FinishDate)
                    m_dtMax = oPeriod.FinishDate;





                if (oPeriod.PeriodID > maxp)
                    maxp = oPeriod.PeriodID;

                if (m_statdate >= oPeriod.StartDate && m_statdate <= oPeriod.FinishDate)
                    m_status_period = oPeriod.PeriodID;

                m_Periods.Add(oPeriod.PeriodID, oPeriod);
            }

            reader.Close();
            reader = null;

            m_max_period = maxp;

            perind = new int[m_max_period + 1];
            persta = new DateTime[m_max_period + 1];
            perfin = new DateTime[m_max_period + 1];
            m_PeriodMode = new int[m_max_period + 1];



            maxp = 0;
            foreach (PeriodData oP in m_Periods.Values)
            {
                perind[oP.PeriodID] = ++maxp;   //' converts period id into the index into the recordset -
                persta[oP.PeriodID] = oP.StartDate;
                perfin[oP.PeriodID] = oP.FinishDate;
            }
        }
        private void ReadCatItems(SqlConnection oDataAccess)
        {
            CatItemData oCat, xCat;
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            int CatItemId = 0;
            int PerID = 0;
            string sCommand = "";
            int[] PidSet = new int[1000];
            int iTemp = 0;
            Dictionary<int, CatItemData> rolenames = new Dictionary<int, CatItemData>();


            sCommand = "SELECT BC_UID, BC_ID, BC_LEVEL, BC_NAME, BC_UOM, BC_ROLE, CA_UID, EPGP_LOOKUP_VALUES.LV_VALUE, MC_UID " +
                       " FROM EPGP_COST_CATEGORIES LEFT OUTER JOIN EPGP_LOOKUP_VALUES ON EPGP_COST_CATEGORIES.MC_UID = EPGP_LOOKUP_VALUES.LV_UID " +
                       " ORDER BY EPGP_COST_CATEGORIES.BC_ID";

            m_CostCat = new Dictionary<int, CatItemData>();
            m_Role_CC = new Dictionary<string, int>();
            m_CostCat_rolly = new Dictionary<int, CatItemData>();

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                oCat = new CatItemData(m_max_period);

                oCat.UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                oCat.ID = ++i;
                oCat.Level = DBAccess.ReadIntValue(reader["BC_LEVEL"]);
                oCat.Role_UID = DBAccess.ReadIntValue(reader["BC_ROLE"]);
                oCat.MC_UID = DBAccess.ReadIntValue(reader["MC_UID"]);

                if (oCat.Level < 1000)
                {
                    PidSet[oCat.Level] = oCat.UID;

                    if (oCat.Level > 1)
                        oCat.PID = PidSet[oCat.Level - 1];
                    else
                        oCat.PID = 0;
                }
                else
                    oCat.PID = 0;

                oCat.Name = DBAccess.ReadStringValue(reader["BC_NAME"]);
                oCat.UoM = DBAccess.ReadStringValue(reader["BC_UOM"]);
                oCat.Mode = (oCat.UoM == "" ? 0 : 1);
                oCat.Category = DBAccess.ReadIntValue(reader["CA_UID"]);
                oCat.MC_Val = DBAccess.ReadStringValue(reader["LV_VALUE"]);

                m_CostCat.Add(oCat.UID, oCat);


                if (oCat.Role_UID > 0)
                {

                    if (m_Role_CC.TryGetValue(oCat.Name, out iTemp) == false)
                    {
                        m_Role_CC.Add(oCat.Name, oCat.UID);
                        m_CostCat_rolly.Add(oCat.UID, oCat);
                        rolenames.Add(oCat.Role_UID, oCat);
                    }



                    if (rolenames.TryGetValue(oCat.Role_UID, out xCat) == true)
                    {
                        oCat.Role_Name = xCat.Name;
                    }



                }



            }

            reader.Close();
            reader = null;


            sCommand = "SELECT BA_BC_UID, BA_PRD_ID, BA_FTE_CONV,BA_RATE FROM EPGP_COST_BREAKDOWN_ATTRIBS WHERE  BA_RATETYPE_UID = 0 And BA_CODE_UID = 0 And CB_ID = " + m_CB_ID.ToString();

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                CatItemId = DBAccess.ReadIntValue(reader["BA_BC_UID"]);
                PerID = DBAccess.ReadIntValue(reader["BA_PRD_ID"]);

                if (PerID <= maxp)
                    PerID = perind[PerID];

                if (m_CostCat.TryGetValue(CatItemId, out oCat) == true)
                {
                    oCat.FTEConv[PerID] = DBAccess.ReadDoubleValue(reader["BA_FTE_CONV"]);
                    oCat.Rates[PerID] = DBAccess.ReadDoubleValue(reader["BA_RATE"]);

                }
            }
            reader.Close();
            reader = null;

            string[] sFull = new string[500];

            foreach (CatItemData oxCat in m_CostCat.Values)
            {
                sFull[oxCat.Level] = oxCat.Name;

                oxCat.FullName = "";

                for (int xi = 1; xi < oxCat.Level; xi++)
                    oxCat.FullName = oxCat.FullName + sFull[xi] + ".";

                oxCat.FullName = oxCat.FullName + oxCat.Name;
            }


        }
        private void ReadCustomFields(SqlConnection oDataAccess)
        {
            m_CustFields = new Dictionary<int, CustomFieldData>();
            CustomFieldData ocf;


            SqlCommand oCommand = null;
            SqlDataReader reader = null;

            oCommand = new SqlCommand("EPG_SP_ReadCTFieldsInfo", oDataAccess);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                ocf = new CustomFieldData();

                ocf.FieldID = DBAccess.ReadIntValue(reader["FA_FIELD_ID"]);
                ocf.DisplayName = DBAccess.ReadStringValue(reader["FA_NAME"]);
                ocf.Name = ocf.DisplayName.Replace(" ", "");

                ocf.LookupOnly = DBAccess.ReadIntValue(reader["FA_LOOKUPONLY"]);
                ocf.LookupID = DBAccess.ReadIntValue(reader["FA_LOOKUP_UID"]);
                ocf.LeafOnly = DBAccess.ReadIntValue(reader["FA_LEAFONLY"]);
                ocf.UseFullName = DBAccess.ReadIntValue(reader["FA_USEFULLNAME"]);

                ocf.ListItems = new Dictionary<int, ListItemData>();
                m_CustFields.Add(ocf.FieldID, ocf);
            }

            reader.Close();
            reader = null;


            ListItemData oListItem;
            string sCommand = "";

            foreach (CustomFieldData oc in m_CustFields.Values)
            {

                if (oc.LookupID != 0)
                {
                    sCommand = "SELECT LV_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_INACTIVE From EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = " + oc.LookupID.ToString() + " ORDER BY LV_ID ";

                    oCommand = new SqlCommand(sCommand, oDataAccess);
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        oListItem = new ListItemData();

                        oListItem.UID = DBAccess.ReadIntValue(reader["LV_UID"]);
                        oListItem.ID = DBAccess.ReadIntValue(reader["LV_ID"]);
                        oListItem.Level = DBAccess.ReadIntValue(reader["LV_LEVEL"]);
                        oListItem.InActive = DBAccess.ReadBoolValue(reader["LV_INACTIVE"]);

                        oListItem.Name = DBAccess.ReadStringValue(reader["LV_VALUE"]);
                        oListItem.FullName = DBAccess.ReadStringValue(reader["LV_FULLVALUE"]);

                        oc.ListItems.Add(oListItem.UID, oListItem);
                    }

                    reader.Close();
                    reader = null;
                }
            }

            m_CustAttribs = new List<PortFieldData>();
            string sdata = m_sCostTypes.Trim();
            string stmp = "";
            sdata = sdata.Replace(",", " ").Trim();

            while (sdata != "")
            {
                int i = 0;

                i = sdata.IndexOf(" ");

                if (i == -1)
                {
                    stmp = sdata;
                    sdata = "";
                }
                else
                {
                    stmp = sdata.Substring(0, i);
                    sdata = sdata.Substring(i + 1);
                }

                i = int.Parse(stmp);

                oCommand = new SqlCommand("EPG_SP_ReadCTCustomFields", oDataAccess);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("CTID", i);

                reader = oCommand.ExecuteReader();

                PortFieldData oFieldItem = null;

                while (reader.Read())
                {
                    oFieldItem = new PortFieldData();

                    oFieldItem.ID = DBAccess.ReadIntValue(reader["FIELD_ID"]);
                    oFieldItem.Name = DBAccess.ReadStringValue(reader["FIELD_NAME"]);
                    oFieldItem.GivenName = DBAccess.ReadStringValue(reader["FA_NAME"]);

                    oFieldItem.Editable = DBAccess.ReadIntValue(reader["CF_EDITABLE"]);
                    oFieldItem.Required = DBAccess.ReadIntValue(reader["CF_REQUIRED"]);
                    oFieldItem.Identity = DBAccess.ReadIntValue(reader["CF_IDENTITY"]);
                    oFieldItem.Visible = DBAccess.ReadIntValue(reader["CF_VISIBLE"]);
                    oFieldItem.Frozen = DBAccess.ReadIntValue(reader["CF_FROZEN"]);

                    oFieldItem.Sequence = i;
                    m_CustAttribs.Add(oFieldItem);
                }
                reader.Close();
                reader = null;
            }

        }
        private void ReadCostTypeNames(SqlConnection oDataAccess)
        {
            string stmp = "";
            string sCommand = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            DataItem oItem = null;


            stmp = m_sCostTypes;

            if (m_sOtherCostTypes != "")
            {
                if (stmp == "")
                    stmp = m_sOtherCostTypes;
                else
                    stmp = stmp + "," + m_sOtherCostTypes;
            }


            sCommand = " SELECT CT_ID, CT_NAME From EPGP_COST_TYPES Where CT_ID in (" + stmp + ")";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            m_CostTypes = new Dictionary<int, DataItem>();

            while (reader.Read())
            {
                oItem = new DataItem();

                oItem.UID = DBAccess.ReadIntValue(reader["CT_ID"]);
                oItem.Name = DBAccess.ReadStringValue(reader["CT_NAME"]);
                oItem.Desc = oItem.Name;
                oItem.bSelected = true;
                m_CostTypes.Add(oItem.UID, oItem);
            }

            reader.Close();
            reader = null;

        }
        private void CheckVersionSecurity(int vid, Dictionary<int, DataItem> sec_cln, List<SecItemData> ver_sec_cln, out bool bEdit, out bool bView)
        {


            if (ver_sec_cln.Count == 0)
            {
                bEdit = true;
                bView = true;
                return;
            }

            List<SecItemData> cln = new List<SecItemData>();

            foreach (SecItemData ogs in ver_sec_cln)
            {
                if (ogs.Object_UID == vid)
                    cln.Add(ogs);
            }

            if (cln.Count == 0)
            {
                bEdit = true;
                bView = true;
                return;
            }

            bEdit = false;
            bView = false;

            // now for each security item - see if user is a member for that group...

            DataItem oItem = null;
            foreach (SecItemData ogs in ver_sec_cln)
            {
                if (sec_cln.TryGetValue(ogs.Group_ID, out oItem))
                {


                    if (ogs.Allow_Edit == 1)
                    {
                        bEdit = true;
                        bView = true;
                    }

                    if (ogs.Allow_Read == 1)
                        bView = true;
                }
            }
        }

        public void ReadModelNames(string model, string sWResID, SqlConnection oDataAccess, ref List<ItemDefn> optlist)
        {
            string sCommand = "";
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            DataItem oItem = null;
            ItemDefn mdl = null;


            if (optlist == null)
            {


                m_Scenario = new Dictionary<int, DataItem>();

                oItem = new DataItem();
                oItem.UID = -1;
                oItem.Name = CONST_CURRENT;
                oItem.Desc = oItem.Name;
                oItem.bLoaded = true;
                oItem.bEditiable = true;

                m_Scenario.Add(oItem.UID, oItem);
            }
            else
            {


                mdl = new ItemDefn();
                mdl.Id = 0;
                mdl.Name = CONST_CURRENT;
                mdl.Deflt = 1;
                mdl.editable = 0;
                optlist.Add(mdl);
            }


            if (model != "" && model != "0")
            {

                List<SecItemData> ver_sec_cln = new List<SecItemData>();
                Dictionary<int, DataItem> sec_cln = new Dictionary<int, DataItem>();
                SecItemData ogs = null;

                sCommand = "Select m.GROUP_ID From EPG_GROUP_MEMBERS m INNER Join EPG_GROUPS g On g.GROUP_ID=m.GROUP_ID and GROUP_ENTITY=1  Where MEMBER_UID=" + sWResID;
                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oItem = new DataItem();
                    oItem.UID = DBAccess.ReadIntValue(reader["GROUP_ID"]);
                    sec_cln.Add(oItem.UID, oItem);
                }

                reader.Close();
                reader = null;

                sCommand = "SELECT  * FROM EPGP_MODEL_GROUP_SECURITY WHERE MODEL_UID =" + model + " ORDER BY MODEL_VERSION_UID";
                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();


                while (reader.Read())
                {
                    ogs = new SecItemData();
                    ogs.Group_ID = DBAccess.ReadIntValue(reader["GROUP_ID"]);
                    ogs.Allow_Read = DBAccess.ReadIntValue(reader["VIEW_PERMISSION"]);
                    ogs.Allow_Edit = DBAccess.ReadIntValue(reader["EDIT_PERMISSION"]);
                    ogs.Object_UID = DBAccess.ReadIntValue(reader["MODEL_VERSION_UID"]);
                    ver_sec_cln.Add(ogs);
                }

                reader.Close();
                reader = null;


                //Dim sec_cln As Collection
                //Dim ver_sec_cln As New Collection
                //Dim bIsAdmin As Boolean
                //Dim ogs As clsSecItem
                //Dim bEdit As Boolean
                //Dim bView As Boolean

                sCommand = " SELECT  * From EPGP_MODEL_VERSIONS WHERE MODEL_VERSION_UID <> 0 AND MODEL_UID = " + model + " ORDER BY MODEL_VERSION_NAME";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();


                bool bEdit, bView;

                while (reader.Read())
                {

                    if (optlist == null)
                    {
                        oItem = new DataItem();
                        oItem.UID = DBAccess.ReadIntValue(reader["MODEL_VERSION_UID"]);
                        oItem.Name = DBAccess.ReadStringValue(reader["MODEL_VERSION_NAME"]);
                        oItem.Desc = oItem.Name;

                        CheckVersionSecurity(oItem.UID, sec_cln, ver_sec_cln, out bEdit, out bView);

                        oItem.bEditiable = bEdit;

                        if (bView)
                            m_Scenario.Add(oItem.UID, oItem);
                    }
                    else
                    {

                        mdl = new ItemDefn();
                        mdl.Id = DBAccess.ReadIntValue(reader["MODEL_VERSION_UID"]);
                        mdl.Deflt = DBAccess.ReadIntValue(reader["MODEL_DEFAULT"]);

                        mdl.Name = DBAccess.ReadStringValue(reader["MODEL_VERSION_NAME"]);

                        CheckVersionSecurity(mdl.Id, sec_cln, ver_sec_cln, out bEdit, out bView);

                        mdl.editable = (bEdit == true ? 1 : 0);

                        if (bView)
                            optlist.Add(mdl);

                    }


                }

                reader.Close();
                reader = null;
            }
        }
        private void ReadStages(SqlConnection oDataAccess)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            DataItem oItem = null;

            string sCommand = "";
            int i = 0;
            m_stages = new Dictionary<int, DataItem>();

            sCommand = "SELECT  STAGE_ID, STAGE_SEQ, STAGE_NAME From EPGP_STAGES";
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                oItem = new DataItem();

                i = DBAccess.ReadIntValue(reader["STAGE_ID"]);
                oItem.UID = DBAccess.ReadIntValue(reader["STAGE_ID"]);
                oItem.Name = DBAccess.ReadStringValue(reader["STAGE_NAME"]);
                m_stages.Add(i, oItem);
            }
            reader.Close();
            reader = null;
        }
        private void ReadExtraPifields(SqlConnection oDataAccess)
        {

            SqlCommand oCommand = null;
            SqlDataReader reader = null;

            string sCommand = "";
            int i = 0;
            int ftabextra = 0;
            int fintabextra = 0;


//            sCommand = "Select rd.*,FIELD_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,at.FA_FORMAT, fl.FIELD_NAME_SQL, at.FA_NAME, fl.FIELD_NAME AS Expr1" +
//                       " From EPGP_RD_FIELDS rd  Left Join EPGT_FIELDS fl On fl.FIELD_ID=rd.FIELD_ID  Left Join EPGC_FIELD_ATTRIBS at On at.FA_FIELD_ID=rd.FIELD_ID Where CONTEXT_ID = 101";

            sCommand =
                "Select t.* From EPGT_FIELDS t Left Join  EPGP_RD_FIELDS r On t.FIELD_ID=r.FIELD_ID And CONTEXT_ID=101 " +
                " Where t.FIELD_ID IN (9901,9902,9904,9911,9928,9950,9922,9925,9930)";

            // need to read these and munge them into the arrays that were used before
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read() && i <= (int)FieldIDs.MAX_PI_EXTRA) {
                ++i;

                m_fidextra[i] = DBAccess.ReadIntValue(reader["FIELD_ID"]);

                if (m_PI_Group == m_fidextra[i])
                    m_PI_Group_fid = i;

                if (m_PI_Seq == m_fidextra[i])
                    m_PI_Seq_fid = i;

                m_ExtraFieldNames[i] = "";

                if (m_ExtraFieldNames[i] == "")
                    m_ExtraFieldNames[i] = DBAccess.ReadStringValue(reader["FIELD_NAME"]);

                m_ExtraFieldNames[i] = m_ExtraFieldNames[i].Replace("%", "Percent");

                if (m_fidextra[i] == 9911)
                    m_ExtraFieldTypes[i] = 9911;     //   ' change Stage from an integer (2) to a special text field (9911)
                else if (m_ExtraFieldTypes[i] == 0)
                    m_ExtraFieldTypes[i] = DBAccess.ReadIntValue(reader["FIELD_FORMAT"]);


                m_sextra[i] = DBAccess.ReadStringValue(reader["FIELD_NAME_SQL"]);

   

            }
            reader.Close();
            reader = null;

            sCommand =  "SELECT     rd.CONTEXT_ID, rd.FIELD_ID, rd.FIELD_NAME, rd.FIELD_SELECT, fl.FIELD_FORMAT, at.FA_TABLE_ID, at.FA_FIELD_IN_TABLE, at.FA_FORMAT, fl.FIELD_NAME_SQL,  " +
                "  at.FA_NAME, fl.FIELD_NAME AS Expr1 FROM  EPGC_FIELD_ATTRIBS AS at LEFT OUTER JOIN EPGP_RD_FIELDS AS rd ON rd.FIELD_ID = at.FA_FIELD_ID AND rd.CONTEXT_ID = 101 LEFT OUTER JOIN " +
                " EPGT_FIELDS AS fl ON fl.FIELD_ID = rd.FIELD_ID WHERE     (at.FA_TABLE_ID = 201) AND (at.FA_FORMAT = 4 OR at.FA_FORMAT = 13 OR at.FA_FORMAT = 7) OR " +
                " (at.FA_TABLE_ID = 202) OR (at.FA_TABLE_ID = 203) OR (at.FA_TABLE_ID = 205)";
            
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read() && i <= (int)FieldIDs.MAX_PI_EXTRA)
            {
                ++i;

                m_fidextra[i] = DBAccess.ReadIntValue(reader["FIELD_ID"]);

                if (m_PI_Group == m_fidextra[i])
                    m_PI_Group_fid = i;

                if (m_PI_Seq == m_fidextra[i])
                    m_PI_Seq_fid = i;

                m_ExtraFieldNames[i] = "";

                if (m_ExtraFieldNames[i] == "")
                    m_ExtraFieldNames[i] = DBAccess.ReadStringValue(reader["FA_NAME"]);

                if (m_ExtraFieldNames[i] == "")
                    m_ExtraFieldNames[i] = DBAccess.ReadStringValue(reader["Expr1"]);


                m_ExtraFieldNames[i] = m_ExtraFieldNames[i].Replace("%", "Percent");

                m_ExtraFieldTypes[i] = DBAccess.ReadIntValue(reader["FIELD_FORMAT"]);

                if (m_fidextra[i] == 9911)
                    m_ExtraFieldTypes[i] = 9911;     //   ' change Stage from an integer (2) to a special text field (9911)
                else if (m_ExtraFieldTypes[i] == 0)
                    m_ExtraFieldTypes[i] = DBAccess.ReadIntValue(reader["FA_FORMAT"]);


                m_sextra[i] = DBAccess.ReadStringValue(reader["FIELD_NAME_SQL"]);

                if (m_sextra[i] == "")
                {
                    ftabextra = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                    fintabextra = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);

                    string stab = "";
                    string sfnam = "";

                    GetCFFieldName(ftabextra, fintabextra, out stab, out sfnam);
                    m_sextra[i] = sfnam;
                }

            }
            reader.Close();
            reader = null;

            m_Use_extra = i;
        }
        private int StripNum(ref string sin)
        {
            int i = 0;
            string sval = "";

            sin = sin.Trim();
            i = sin.IndexOf(" ");

            if (i == -1)
            {
                sval = sin;
                sin = "";
            }
            else
            {
                sval = sin.Substring(0, i);
                sin = sin.Substring(i + 1); //, sin.Length - i);
            }

            return int.Parse(sval);
        }
        private string MyFormat(object obj, int lt, ref string sCodes, ref string sRes)
        {



            switch (lt)
            {
                case EPK_FTYPE_DATE:
                    DateTime dt;

                    dt = DBAccess.ReadDateValue(obj);
                    string rs = dt.ToString("yyyyMMddHHmm");
                    return rs;


                case EPK_FTYPE_INTEGER:
                case EPK_FTYPE_NUMBER:
                case EPK_FTYPE_CURRENCY:
                case EPK_FTYPE_PERCENT:
                case EPK_FTYPE_YESNO:
                case EPK_FTYPE_WORK:
                case EPK_FTYPE_DURATION:

                    long i;

                    i = (long) DBAccess.ReadDecimalValue(obj);
                    return i.ToString();

                case EPK_FTYPE_URL:
                case EPK_FTYPE_TEXT:
                case EPK_FTYPE_RTF:
                    return DBAccess.ReadStringValue(obj);

                case EPK_FTYPE_CODE:
                    int c;

                    c = DBAccess.ReadIntValue(obj);

                    if (sCodes.IndexOf(" " + c.ToString() + " ") == -1)
                    {
                        if (sCodes == "")
                            sCodes = " " + c.ToString() + " ";
                        else
                            sCodes = sCodes + ", " + c.ToString() + " ";
                    }

                    return c.ToString();

                case EPK_FTYPE_RES:
                    int r;

                    r = DBAccess.ReadIntValue(obj);

                    if (sRes.IndexOf(" " + r.ToString() + " ") == -1)
                    {
                        if (sRes == "")
                            sRes = " " + r.ToString() + " ";
                        else
                            sRes = sRes + ", " + r.ToString() + " ";
                    }

                    return r.ToString();
            }
            return "";
        }
        private void ReadPILevelData(SqlConnection oDataAccess, out DateTime earlystart, out DateTime latefinish)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            DataItem oItem = null;
            earlystart = DateTime.MinValue;
            latefinish = DateTime.MinValue;

            string sCommand = "";

            m_PIs = new Dictionary<string, PIData>();


            sCommand = "SELECT  EPGP_PROJECTS.PROJECT_ID,  EPGP_PROJECTS.PROJECT_START_DATE,  EPGP_PROJECTS.PROJECT_FINISH_DATE,  EPGP_PROJECTS.PROJECT_NAME ";

            if (m_SelFID == 0)
                sCommand = sCommand + ",1 AS XYZZY ";
            else
                sCommand = sCommand + "," + m_Select_FieldName + " AS XYZZY ";


            for (int i = 1; i <= m_Use_extra; i++)
                sCommand = sCommand + "," + m_sextra[i];

            string sCodes = "";
            string sRes = "";


            sCommand = sCommand + " From EPGP_PROJECTS "
                        + " left join EPGP_PROJECT_INT_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_INT_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_TEXT_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_TEXT_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_NTEXT_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_NTEXT_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_DEC_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_DEC_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_DATE_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_DATE_VALUES.PROJECT_ID"
                        + " Where  EPGP_PROJECTS.PROJECT_ID in (" + m_sPids + ")";


            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            PIData oPI;



            while (reader.Read())
            {
                oPI = new PIData((int)FieldIDs.MAX_PI_EXTRA);
                oPI.PI_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                oPI.PI_Name = DBAccess.ReadStringValue(reader["PROJECT_NAME"]);
                oPI.StartDate = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"]);
                oPI.FinishDate = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"]);
                oPI.oStartDate = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"]);
                oPI.oFinishDate = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"]);

                if (earlystart == DateTime.MinValue)
                    earlystart = oPI.oStartDate;
                else if (oPI.oStartDate !=  DateTime.MinValue)
                {
                    if (earlystart > oPI.oStartDate)
                        earlystart = oPI.oStartDate;
                }


                if (latefinish < oPI.FinishDate)
                    latefinish = oPI.FinishDate;

                oPI.Scenario_name = CONST_CURRENT;


                if (m_dtMin > oPI.StartDate && oPI.StartDate != DateTime.MinValue)
                    m_dtMin = oPI.StartDate;

                if (m_dtMax < oPI.FinishDate)
                    m_dtMax = oPI.FinishDate;


                oPI.ScenarioID = -1;
                oPI.PISelected = DBAccess.ReadIntValue(reader["XYZZY"]);

                if (oPI.PISelected != 0)
                    oPI.PISelected = 1;

                object obj = null;

                for (int i = 1; i <= m_Use_extra; i++)
                {
                    obj = reader[4 + i];

                    if (m_fidextra[i] == 9911)
                    {
                        int xi = 0;
                        if (!obj.Equals(System.DBNull.Value))
                            xi = Convert.ToInt32(obj);
                        else
                            xi = 0;

                        if (m_stages.TryGetValue(xi, out oItem))
                            oPI.m_PI_Extra_data[i] = oItem.UID.ToString();
                        else
                            oPI.m_PI_Extra_data[i] = "";
                    }
                    else
                        oPI.m_PI_Extra_data[i] = MyFormat(obj, m_ExtraFieldTypes[i], ref sCodes, ref sRes);
                }

                string sKey = oPI.PI_ID.ToString() + " " + oPI.ScenarioID.ToString();

                m_PIs.Add(sKey, oPI);
                oPI.Internal_ID = m_PIs.Count;
            }
            reader.Close();
            reader = null;

            sCodes = sCodes.Replace(" ", "");
            sRes = sRes.Replace(" ", "");

            m_codes = new Dictionary<int, DataItem>();
            m_reses = new Dictionary<int, DataItem>();

            // ' Now read Code and resource values....

            if (sCodes != "")
            {

                sCommand = "SELECT LV_UID, LV_VALUE, LV_FULLVALUE From EPGP_LOOKUP_VALUES WHERE LV_UID IN (" + sCodes + ")";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oItem = new DataItem();

                    oItem.UID = DBAccess.ReadIntValue(reader["LV_UID"]);
                    oItem.Name = DBAccess.ReadStringValue(reader["LV_VALUE"]);
                    oItem.Desc = DBAccess.ReadStringValue(reader["LV_FULLVALUE"]);
                    m_codes.Add(oItem.UID, oItem);

                }
                reader.Close();
                reader = null;
            }

            if (sRes != "")
            {

                sCommand = "SELECT WRES_ID, RES_NAME FROM  EPG_RESOURCES WHERE WRES_ID IN (" + sRes + ")";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oItem = new DataItem();

                    oItem.UID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                    oItem.Name = DBAccess.ReadStringValue(reader["RES_NAME"]);
                    m_reses.Add(oItem.UID, oItem);

                }
                reader.Close();
                reader = null;
            }
        }
        private void ReadCostCustomFieldsAndData(SqlConnection oDataAccess)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            DetailRowData Det = null;
            DetailRowData TryDet = null;
            string sCommand = "";
            Dictionary<int, DataItem> clnCalcs = new Dictionary<int, DataItem>();
            DataItem oItem = null;


            int xCT_ID = 0;
            int xProject_ID = 0;
            int xBC_UID = 0;
            int xBC_SEQ = 0;
            int Peracc = 0;
            int xCurScen = -1;

            int ctid = 0;
            int CL_CT_ID = 0;
            int CL_OP = 0;

            m_detaildata = new Dictionary<string, DetailRowData>();
            m_targetdata = new Dictionary<string, DetailRowData>();

            if (m_sCostTypes != "")
            {
                sCommand = "SELECT * FROM EPGP_COST_DETAILS " +
                          " WHERE CB_ID = " + m_CB_ID.ToString() +
                          " AND CT_ID IN (" + m_sCostTypes + ") " +
                          " AND PROJECT_ID IN (" + m_sPids + ") " +
                          " ORDER BY PROJECT_ID, CT_ID, BC_UID, BC_SEQ";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();


                while (reader.Read())
                {
                    Det = new DetailRowData(m_max_period);

                    Det.CB_ID = DBAccess.ReadIntValue(reader["CB_ID"]);
                    Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                    Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    Det.BC_SEQ = DBAccess.ReadIntValue(reader["BC_SEQ"]);
                    Det.Scenario_ID = xCurScen;

                    for (int i = 1; i <= 5; i++)
                    {
                        Det.OCVal[i] = DBAccess.ReadIntValue(reader["OC_0" + i.ToString()]);
                        Det.TXVal[i] = DBAccess.ReadStringValue(reader["TEXT_0" + i.ToString()]);
                    }

                    Det.m_rt = DBAccess.ReadIntValue(reader["RT_UID"]);
                    Det.bSelected = true;
                    sCommand = "K" + Det.CT_ID.ToString() + " " + Det.PROJECT_ID.ToString() + " " + Det.BC_UID.ToString() + " " + Det.BC_SEQ.ToString() + " " + Det.Scenario_ID.ToString();

                    if (m_detaildata.TryGetValue(sCommand, out TryDet) == false)
                        m_detaildata.Add(sCommand, Det);
                }
                reader.Close();
                reader = null;


                if (m_sCalcCostTypes != "")
                {
                    sCommand = "SELECT * FROM EPGP_COST_CALC WHERE CT_ID IN (" + m_sCalcCostTypes + ") ORDER BY CT_ID,CL_ID";


                    oCommand = new SqlCommand(sCommand, oDataAccess);
                    reader = oCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        ctid = DBAccess.ReadIntValue(reader["CT_ID"]);
                        CL_CT_ID = DBAccess.ReadIntValue(reader["CL_CT_ID"]);
                        CL_OP = DBAccess.ReadIntValue(reader["CL_OP"]);

                        if (clnCalcs.TryGetValue(ctid, out oItem) == false)
                        {
                            oItem = new DataItem();
                            oItem.UID = ctid;
                            clnCalcs.Add(ctid, oItem);
                            oItem.Desc = "";
                        }

                        oItem.Desc = oItem.Desc + " " + CL_CT_ID.ToString() + " " + CL_OP.ToString();
                        oItem.Name = oItem.Name + " " + CL_CT_ID.ToString();

                    }
                    reader.Close();
                    reader = null;
                    DataItem oi = null;

                    foreach (KeyValuePair<int, DataItem> pair in clnCalcs)
                    {
                        oi = pair.Value;
                        oi.Name = oi.Name.Trim();
                        oi.Name = oi.Name.Replace(" ", ",");

                        sCommand = "SELECT * FROM EPGP_COST_DETAILS WHERE CB_ID = " + m_CB_ID.ToString() + " AND CT_ID IN (" + oi.Name + ") AND PROJECT_ID IN (" + m_sPids + ")  ORDER BY PROJECT_ID, CT_ID, BC_UID, BC_SEQ";

                        oCommand = new SqlCommand(sCommand, oDataAccess);
                        reader = oCommand.ExecuteReader();


                        while (reader.Read())
                        {
                            Det = new DetailRowData(m_max_period);

                            Det.CB_ID = DBAccess.ReadIntValue(reader["CB_ID"]);
                            Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                            Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                            Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                            Det.BC_SEQ = 0;
                            Det.bSelected = true;

                            Det.Scenario_ID = xCurScen;
                            for (int i = 1; i <= 5; i++)
                            {
                                Det.OCVal[i] = DBAccess.ReadIntValue(reader["OC_0" + i.ToString()]);
                                Det.TXVal[i] = DBAccess.ReadStringValue(reader["TEXT_0" + i.ToString()]);
                            }

                            Det.m_rt = DBAccess.ReadIntValue(reader["RT_UID"]);

                            sCommand = "K" + oi.UID.ToString() + " " + Det.PROJECT_ID.ToString() + " " + Det.BC_UID.ToString() + " " + Det.Scenario_ID.ToString();

                            if (m_detaildata.TryGetValue(sCommand, out TryDet) == false)
                                m_detaildata.Add(sCommand, Det);
                            else
                            {
                                for (int i = 1; i <= 5; i++)
                                {
                                    if (TryDet.OCVal[i] != Det.OCVal[i])
                                        TryDet.OCVal[i] = 0;
                                    if (TryDet.TXVal[i] != Det.TXVal[i])
                                        TryDet.TXVal[i] = "";
                                }

                                if (TryDet.m_rt != Det.m_rt)
                                    TryDet.m_rt = 0;

                            }
                        }
                        reader.Close();
                        reader = null;
                    }
                }


                sCommand = "SELECT * FROM EPGP_DETAIL_VALUES WHERE CB_ID = " + m_CB_ID.ToString() + " AND CT_ID IN (" + m_sCostTypes + ") AND PROJECT_ID IN (" + m_sPids + ")  ORDER BY PROJECT_ID, CT_ID, BC_UID, BC_SEQ";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();


                while (reader.Read())
                {
                    xCT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                    xProject_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    xBC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    xBC_SEQ = DBAccess.ReadIntValue(reader["BC_SEQ"]);

                    sCommand = "K" + xCT_ID.ToString() + " " + xProject_ID.ToString() + " " + xBC_UID.ToString() + " " + xBC_SEQ.ToString() + " " + xCurScen.ToString();

                    if (m_detaildata.TryGetValue(sCommand, out Det) == false)
                    {
                        Det = new DetailRowData(m_max_period);

                        Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                        Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                        Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                        Det.BC_SEQ = DBAccess.ReadIntValue(reader["BC_SEQ"]);
                        Det.Scenario_ID = xCurScen;
                        Det.bSelected = true;

                        for (int i = 1; i <= 5; i++)
                        {
                            Det.OCVal[i] = 0;
                            Det.TXVal[i] = "";
                        }

                        Det.m_rt = 0;
                        m_detaildata.Add(sCommand, Det);
                    }

                    Peracc = DBAccess.ReadIntValue(reader["BD_PERIOD"]);
                    Peracc = perind[Peracc];
                    Det.zCost[Peracc] = DBAccess.ReadDoubleValue(reader["BD_Cost"]);
                    Det.zValue[Peracc] = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);

                    if (Det.zCost[Peracc] != 0 || Det.zValue[Peracc] != 0)
                        Det.HasValues = true;

                }
                reader.Close();
                reader = null;
            }


            if (m_sOtherCostTypes != "")
            {

                sCommand = "SELECT  * From EPGP_COST_VALUES WHERE CB_ID = " + m_CB_ID.ToString() +
                           " AND CT_ID IN (" + m_sOtherCostTypes + ") AND PROJECT_ID IN (" + m_sPids + ") AND BD_IS_SUMMARY = 0  ORDER BY PROJECT_ID, CT_ID, BC_UID";



                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();


                while (reader.Read())
                {
                    xCT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                    xProject_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    xBC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    xBC_SEQ = 0;


                    sCommand = "K" + xCT_ID.ToString() + " " + xProject_ID.ToString() + " " + xBC_UID.ToString() + " " + xBC_SEQ.ToString() + " " + xCurScen.ToString();

                    if (m_detaildata.TryGetValue(sCommand, out Det) == false)
                    {
                        Det = new DetailRowData(m_max_period);

                        Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                        Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                        Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                        Det.BC_SEQ = 0;
                        Det.Scenario_ID = xCurScen;
                        Det.bSelected = true;


                        for (int i = 1; i <= 5; i++)
                        {
                            Det.OCVal[i] = 0;
                            Det.TXVal[i] = "";
                        }

                        Det.m_rt = 0;
                        m_detaildata.Add(sCommand, Det);
                    }

                    Peracc = DBAccess.ReadIntValue(reader["BD_PERIOD"]);
                    Peracc = perind[Peracc];
                    Det.zCost[Peracc] = DBAccess.ReadDoubleValue(reader["BD_Cost"]);
                    Det.zValue[Peracc] = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);
                    if (Det.zCost[Peracc] != 0 || Det.zValue[Peracc] != 0)
                        Det.HasValues = true;

                }
                reader.Close();
                reader = null;
            }


            string scalc = "";


            if (m_sCalcCostTypes != "")
            {
                foreach (KeyValuePair<int, DataItem> pair in clnCalcs)
                {
                    DataItem oi = null;

                    oi = pair.Value;

                    scalc = oi.Desc.Trim();

                    while (scalc != "")
                    {

                        CL_CT_ID = StripNum(ref scalc);
                        CL_OP = StripNum(ref scalc);

                        sCommand = "SELECT * FROM EPGP_DETAIL_VALUES " +
                                 " WHERE CB_ID = " + m_CB_ID.ToString() +
                                 " AND CT_ID = " + CL_CT_ID.ToString() +
                                 " AND PROJECT_ID IN (" + m_sPids + ") " +
                                 " ORDER BY PROJECT_ID, CT_ID, BC_UID, BC_SEQ";



                        oCommand = new SqlCommand(sCommand, oDataAccess);
                        reader = oCommand.ExecuteReader();


                        while (reader.Read())
                        {
                            xCT_ID = oi.UID;  //oDBAccess.ReadIntValue(reader["CT_ID"]);
                            xProject_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                            xBC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                            xBC_SEQ = 0;


                            sCommand = "K" + xCT_ID.ToString() + " " + xProject_ID.ToString() + " " + xBC_UID.ToString() + " " + xBC_SEQ.ToString() + " " + xCurScen.ToString();
                            
                            if (m_detaildata.TryGetValue(sCommand, out Det) == false)
                            {
                                Det = new DetailRowData(m_max_period);

                                Det.CT_ID = xCT_ID;
                                Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                                Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                                Det.BC_SEQ = 0;
                                Det.Scenario_ID = xCurScen;

                                Det.bSelected = true;

                                for (int i = 1; i <= 5; i++)
                                {
                                    Det.OCVal[i] = 0;
                                    Det.TXVal[i] = "";
                                }

                                Det.m_rt = 0;
                                m_detaildata.Add(sCommand, Det);
                            }


                            double dCost = 0;
                            double dValue = 0;

                            Peracc = DBAccess.ReadIntValue(reader["BD_PERIOD"]);
                            Peracc = perind[Peracc];
                            dCost = DBAccess.ReadDoubleValue(reader["BD_Cost"]);
                            dValue = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);

                            if (CL_OP == 0)
                            {
                                Det.zCost[Peracc] = Det.zCost[Peracc] + dCost;
                                Det.zValue[Peracc] = Det.zValue[Peracc] + dValue;
                                if (Det.zCost[Peracc] != 0 || Det.zValue[Peracc] != 0)
                                    Det.HasValues = true;
                            }
                            else
                            {

                                Det.zCost[Peracc] = Det.zCost[Peracc] - dCost;
                                Det.zValue[Peracc] = Det.zValue[Peracc] - dValue;
                                if (Det.zCost[Peracc] != 0 || Det.zValue[Peracc] != 0)
                                    Det.HasValues = true;
                            }

                        }
                        reader.Close();
                        reader = null;
                    }
                }
            }

            foreach (DetailRowData xDet in m_detaildata.Values)
            {

                PIData oPI = null;
                CatItemData oCat;

                if (m_PIs.TryGetValue(xDet.PROJECT_ID.ToString() + " -1", out oPI))
                    xDet.PI_Name = oPI.PI_Name;
                else
                    xDet.PI_Name = "";

                if (m_CostTypes.TryGetValue(xDet.CT_ID, out oItem))
                    xDet.CT_Name = oItem.Name;
                else
                    xDet.CT_Name = "";

                if (m_Scenario.TryGetValue(xDet.Scenario_ID, out oItem))
                    xDet.Scen_Name = oItem.Name;
                else
                    xDet.Scen_Name = "";

                if (m_CostCat.TryGetValue(xDet.BC_UID, out oCat))
                {
                    xDet.Cat_Name = oCat.Name;
                    xDet.FullCatName = oCat.FullName;
                    xDet.MC_Name = oCat.MC_Val;
                    xDet.Role_Name = oCat.Role_Name;

                    if (m_CostCat.TryGetValue(oCat.Category, out oCat))
                    {
                        xDet.CC_Name = oCat.Name;
                        xDet.FullCCName = oCat.FullName;
                    }
                }

                for (int xi = 1; xi <= 5; ++xi)
                {
                    xDet.Text_OCVal[xi] = "";

                }




            }


        }
        private void ReadBudgetBands(SqlConnection oDataAccess)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sCommand = "";

            TargetColours TarCol = null;

            m_TargetColours = new List<TargetColours>();


            sCommand = "SELECT BUDSP_UID, BAND_ID, BAND_BOT,BAND_TOP,BAND_BACKCOLOR,BAND_NAME FROM EPGT_VIEW_BUDSPEC_BAND WHERE BUDSP_UID = 0 ORDER BY BAND_ID";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                TarCol = new TargetColours();

                TarCol.ID = DBAccess.ReadIntValue(reader["BAND_ID"]);
                TarCol.rgb_val = DBAccess.ReadIntValue(reader["BAND_BACKCOLOR"]);
                TarCol.low_val = DBAccess.ReadDoubleValue(reader["BAND_BOT"]);
                TarCol.high_val = DBAccess.ReadDoubleValue(reader["BAND_TOP"]);
                TarCol.Desc = DBAccess.ReadStringValue(reader["BAND_NAME"]);

                m_TargetColours.Add(TarCol);

            }
            reader.Close();
            reader = null;
        }
        private void ReadModelTargets(SqlConnection oDataAccess, string sWResID)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sCommand = "";
            DataItem oItem = null;


            m_Target = new List<DataItem>();
            m_AssignableCTS = new List<DataItem>();

            sCommand = "SELECT * FROM EPGP_MODEL_TARGETS WHERE CB_ID = " + m_CB_ID.ToString() + " AND (WRES_ID = 0 OR WRES_ID = " + sWResID + ") ORDER BY WRES_ID,TARGET_NAME";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                oItem = new DataItem();

                oItem.UID = DBAccess.ReadIntValue(reader["TARGET_ID"]);
                oItem.ID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                oItem.Name = DBAccess.ReadStringValue(reader["TARGET_NAME"]);
                oItem.Desc = DBAccess.ReadStringValue(reader["TARGET_DESC"]);

                m_Target.Add(oItem);

            }
            reader.Close();
            reader = null;

            sCommand = "SELECT CT_ID, CT_NAME FROM   EPGP_COST_TYPES WHERE CT_EDIT_MODE = 1 ORDER BY CT_NAME";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                oItem = new DataItem();

                oItem.UID = DBAccess.ReadIntValue(reader["CT_ID"]);
                oItem.Name = DBAccess.ReadStringValue(reader["CT_NAME"]);

                m_AssignableCTS.Add(oItem);

            }
            reader.Close();
            reader = null;
        }
        private void ReadRateTable(SqlConnection oDataAccess)
        {

            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sCommand = "";
            int rCount = 0;

            m_Rates = new Dictionary<int, RateTable>();
            m_ratecache = new Dictionary<string, RateFTECache>();




            sCommand = "SELECT COUNT(CT_ALLOW_NAMED_RATES) AS CT_ALLOW_NAMED_RATES From EPGP_COST_TYPES Where (CT_ALLOW_NAMED_RATES <> 0)";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                rCount = DBAccess.ReadIntValue(reader["CT_ALLOW_NAMED_RATES"]);
            }
            reader.Close();
            reader = null;



            // will only need rates if there is a CT that uas rates enabled

            if (rCount != 0)
            {


                sCommand = "SELECT  * FROM   EPG_RATES ORDER BY RT_ID";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();
                RateTable oRatItem = null;

                while (reader.Read())
                {
                    oRatItem = new RateTable(m_max_period);
                    oRatItem.UID = DBAccess.ReadIntValue(reader["RT_UID"]);
                    oRatItem.ID = DBAccess.ReadIntValue(reader["RT_ID"]);
                    oRatItem.Level = DBAccess.ReadIntValue(reader["RT_LEVEL"]);
                    oRatItem.Name = DBAccess.ReadStringValue(reader["RT_NAME"]);
                    m_Rates.Add(oRatItem.UID, oRatItem);


                }
                reader.Close();
                reader = null;


                sCommand = "SELECT  * FROM    EPG_RATE_VALUES ORDER BY RT_UID,RT_EFFECTIVE_DATE";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();
                int RT_UID = 0;
                DateTime EffectiveDate;
                double Rate = 0;
                int sp;

                while (reader.Read())
                {
                    RT_UID = DBAccess.ReadIntValue(reader["RT_UID"]);
                    Rate = DBAccess.ReadDoubleValue(reader["RT_RATE"]);
                    EffectiveDate = DBAccess.ReadDateValue(reader["RT_EFFECTIVE_DATE"]);

                    if (m_Rates.TryGetValue(RT_UID, out oRatItem) == false)
                    {
                        oRatItem = new RateTable(m_max_period);
                        oRatItem.UID = RT_UID;
                        m_Rates.Add(oRatItem.UID, oRatItem);
                    }

                    if (EffectiveDate <= DateTime.MinValue)
                        sp = 1;
                    else
                    {
                        sp = 0;
                        foreach (PeriodData oPer in m_Periods.Values)
                        {
                            ++sp;
                            if (oPer.StartDate >= EffectiveDate)
                                break;

                        }

                    }

                    for (int i = sp; i <= m_max_period; i++)
                    {
                        oRatItem.zRate[i] = Rate;
                    }


                }
                reader.Close();
                reader = null;
            }

        }
        private void LoadScenarios(SqlConnection oDataAccess, string Scenarios, bool bdoTxtThing, bool bSetSelected)
        {
            // This will load previously saved model scenarios and add them into the main data store
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sCommand = "";
            string sCTs = "";
            PIData oPI = null;
            PIData oTempPI = null;
            DataItem oItem = null;
            DetailRowData Det = null;
            DetailRowData TryDet = null;

            int xCT_ID = 0;
            int xProject_ID = 0;
            int xBC_UID = 0;
            int xBC_SEQ = 0;
            int xScenID = 0;
            int Peracc;
            string sKey = "";


 //           if (Scenarios == "" || Scenarios == "0")
 //               return;

            List<DetailRowData> cln = new List<DetailRowData>();

            //string Scenarios = "";

            //string sWrk = inScenarios.Replace(',', ' ').Trim();


            //while (sWrk != "")
            //{
            //    int tmpscen = StripNum(ref(sWrk));

            //    if (tmpscen >= 0)
            //    {
            //        if (m_Scenario.TryGetValue(tmpscen, out oItem) == true)
            //        {
            //            if (oItem.bLoaded == false)
            //            {
            //                oItem.bLoaded = true;
            //                if (Scenarios == "")
            //                    Scenarios = tmpscen.ToString();
            //                else
            //                    Scenarios = Scenarios + "," + tmpscen.ToString();
            //            }
            //        }
            //    }
            //}

            // if (Scenarios == "")
            //    return;




            sCTs = m_sCostTypes;

            if (m_sOtherCostTypes != "")
            {
                if (sCTs == "")
                    sCTs = m_sOtherCostTypes;
                else
                    sCTs = sCTs + "," + m_sOtherCostTypes;
            }

            sCommand = "SELECT PROJECT_ID, PROJECT_START_DATE, PROJECT_FINISH_DATE, PROJECT_SELECTED,MODEL_VERSION_UID From EPGP_MODEL_PROJECT_DATES  WHERE MODEL_UID = " + m_sModel +
                       " AND PROJECT_ID IN (" + m_sPids + ") " +
                       " AND MODEL_VERSION_UID IN (" + Scenarios + ") ORDER BY MODEL_VERSION_UID";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            int iZero = -1;


            while (reader.Read())
            {
                oPI = new PIData((int)FieldIDs.MAX_PI_EXTRA);
                oPI.PI_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                oPI.StartDate = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"]);
                oPI.FinishDate = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"]);
                oPI.ScenarioID = DBAccess.ReadIntValue(reader["MODEL_VERSION_UID"]);
                oPI.PISelected = DBAccess.ReadIntValue(reader["PROJECT_SELECTED"]);

                if (m_Scenario.TryGetValue(oPI.ScenarioID, out oItem) == true)
                {
                    oPI.Scenario_name = oItem.Name;

                    sKey = oPI.PI_ID.ToString() + " " + iZero.ToString();
                    if (m_PIs.TryGetValue(sKey, out oTempPI))
                    {
                        oPI.PI_Name = oTempPI.PI_Name;
                        oPI.oStartDate = oTempPI.oStartDate;
                        oPI.oFinishDate = oTempPI.oFinishDate;



                        for (int ix = 1; ix <= (int)FieldIDs.MAX_PI_EXTRA; ix++)
                            oPI.m_PI_Extra_data[ix] = oTempPI.m_PI_Extra_data[ix];

                        oPI.m_PI_Format_Extra_data = oTempPI.m_PI_Format_Extra_data;
                    }

                    sKey = oPI.PI_ID.ToString() + " " + oPI.ScenarioID.ToString();

                    if (m_PIs.TryGetValue(sKey, out oTempPI))
                    {
                        oTempPI.StartDate = oPI.StartDate;
                        oTempPI.FinishDate = oPI.FinishDate;
                    }
                    else
                    {
                        m_PIs.Add(sKey, oPI);
                        oPI.Internal_ID = m_PIs.Count;
                    }
                }
            }
            reader.Close();
            reader = null;

            sCommand = "SELECT * FROM EPGP_MODEL_COST_DETAILS WHERE MODEL_UID = " + m_sModel +
                       " AND CT_ID IN (" + sCTs + ") AND PROJECT_ID IN (" + m_sPids + ") " +
                       " AND MODEL_VERSION_UID IN (" + Scenarios + ") ORDER BY MODEL_VERSION_UID,PROJECT_ID, CT_ID, BC_UID, BC_SEQ";


            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                Det = new DetailRowData(m_max_period);

                Det.CB_ID = DBAccess.ReadIntValue(reader["CB_ID"]);
                Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                Det.BC_SEQ = DBAccess.ReadIntValue(reader["BC_SEQ"]);
                Det.Scenario_ID = DBAccess.ReadIntValue(reader["MODEL_VERSION_UID"]);
                Det.bSelected = (DBAccess.ReadIntValue(reader["MODEL_VERSION_UID"]) != 0);

                for (int i = 1; i <= 5; i++)
                {
                    Det.OCVal[i] = DBAccess.ReadIntValue(reader["OC_0" + i.ToString()]);
                    Det.TXVal[i] = DBAccess.ReadStringValue(reader["TEXT_0" + i.ToString()]);
                }

                Det.m_rt = DBAccess.ReadIntValue(reader["RT_UID"]);
                sCommand = "K" + Det.CT_ID.ToString() + " " + Det.PROJECT_ID.ToString() + " " + Det.BC_UID.ToString() + " " + Det.BC_SEQ.ToString() + " " + Det.Scenario_ID.ToString();

                CatItemData oCat;

                if (m_PIs.TryGetValue(Det.PROJECT_ID.ToString() + " " + Det.Scenario_ID.ToString(), out oPI))
                {
                    Det.PI_Name = oPI.PI_Name;
                    Det.Internal_ID = oPI.Internal_ID;
                    Det.m_PI_Format_Extra_data = oPI.m_PI_Format_Extra_data;
                }
                else
                {
                    Det.Internal_ID = 0;
                    Det.PI_Name = "";
                }

                if (m_CostTypes.TryGetValue(Det.CT_ID, out oItem))
                    Det.CT_Name = oItem.Name;
                else
                    Det.CT_Name = "";

                if (m_Scenario.TryGetValue(Det.Scenario_ID, out oItem))
                    Det.Scen_Name = oItem.Name;
                else
                    Det.Scen_Name = "";

                if (m_CostCat.TryGetValue(Det.BC_UID, out oCat))
                {
                    Det.Cat_Name = oCat.Name;
                    Det.FullCatName = oCat.FullName;
                    Det.MC_Name = oCat.MC_Val;
                }

                if (m_CostCat_rolly.TryGetValue(Det.BC_ROLE_UID, out oCat))
                {
                    Det.Role_Name = oCat.Name;
                }

                if (m_detaildata.TryGetValue(sCommand, out TryDet) == false)
                    m_detaildata.Add(sCommand, Det);

                cln.Add(Det);

            }
            reader.Close();
            reader = null;



            sCommand = "SELECT * FROM EPGP_MODEL_DETAIL_VALUES WHERE MODEL_UID = " + m_sModel +
                       " AND CT_ID IN (" + sCTs + ") AND  PROJECT_ID IN (" + m_sPids + ") " +
                       " AND MODEL_VERSION_UID IN (" + Scenarios + ") ORDER BY MODEL_VERSION_UID,PROJECT_ID, CT_ID, BC_UID, BC_SEQ";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();


            while (reader.Read())
            {

                xCT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                xProject_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                xBC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                xBC_SEQ = DBAccess.ReadIntValue(reader["BC_SEQ"]);
                xScenID = DBAccess.ReadIntValue(reader["MODEL_VERSION_UID"]);


                sCommand = "K" + xCT_ID.ToString() + " " + xProject_ID.ToString() + " " + xBC_UID.ToString() + " " + xBC_SEQ.ToString() + " " + xScenID.ToString();

                if (m_detaildata.TryGetValue(sCommand, out Det) == false)
                {
                    Det = new DetailRowData(m_max_period);

                    Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                    Det.PROJECT_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    Det.BC_SEQ = DBAccess.ReadIntValue(reader["BC_SEQ"]); ;
                    Det.Scenario_ID = DBAccess.ReadIntValue(reader["MODEL_VERSION_UID"]);


                    for (int i = 1; i <= 5; i++)
                    {
                        Det.OCVal[i] = 0;
                        Det.TXVal[i] = "";
                    }

                    Det.m_rt = 0;
                    m_detaildata.Add(sCommand, Det);
                }

                Peracc = DBAccess.ReadIntValue(reader["BD_PERIOD"]);
                Peracc = perind[Peracc];
                Det.zCost[Peracc] = DBAccess.ReadDoubleValue(reader["BD_Cost"]);
                Det.zValue[Peracc] = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);
                Det.HasValues = true;


            }
            reader.Close();
            reader = null;

            StashRateCache();

            while (Scenarios != "")
            {
                int xi = 0;
                string sm = "";

                xi = Scenarios.IndexOf(",");
                if (xi == -1)
                {
                    sm = Scenarios;
                    Scenarios = "";
                }
                else
                {
                    sm = Scenarios.Substring(0, xi);
                    Scenarios = Scenarios.Substring(xi + 1);
                }

                xi = int.Parse(sm);

                if (xi == 0)
                    xi = -1;

                if (m_Scenario.TryGetValue(xi, out oItem))
                {
                    oItem.bLoaded = true;
                    oItem.bSelected = bSetSelected;
                }

                foreach (DetailRowData xdet in cln)
                {
                    for (int xj = 1; xj <= m_Periods.Count; xj++)
                    {
                        if (xdet.zCost[xj] != 0 || xdet.zValue[xj] != 0)
                        {

                            if (xdet.Det_Start == DateTime.MinValue)
                                xdet.Det_Start = persta[xj];

                            xdet.Det_Finish = perfin[xj];
                        }

                    }

                    if (bdoTxtThing)
                    {
                        for (int xj = 1; xj <= 5; xj++)
                        {
                            string stxt;
                            int tempj;
                            tempj = xdet.OCVal[xj];
                            stxt = GetLookUpString(xj, ref tempj);
                            xdet.OCVal[xj] = tempj;
                            xdet.Text_OCVal[xj] = stxt;
                        }
                    }

                    CatItemData oCat;

                    if (m_CostCat.TryGetValue(xdet.BC_UID, out oCat))
                    {
                        xdet.Cat_Name = oCat.Name;
                        xdet.FullCatName = oCat.FullName;
                        xdet.MC_Name = oCat.MC_Val;
                        xdet.Role_Name = oCat.Role_Name;

                        if (m_CostCat.TryGetValue(oCat.Category, out oCat))
                        {
                            xdet.CC_Name = oCat.Name;
                            xdet.FullCCName = oCat.FullName;
                        }
                    }

                }

            }
        }
        private int LoadTargets(SqlConnection oDataAccess, string targets)
        {

            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sCommand = "";
            string sCTs = "";
            DetailRowData Det = null;
            DetailRowData TryDet = null;
            int xBC_SEQ = 0;
            int xScenID = 0;
            int Peracc;

            int retv = 0;

            sCommand = targets.Trim();
            sCommand = targets.Replace(",", " ");

            string lp = " " + sCommand + " ";
            Dictionary<string, DetailRowData> newtar = new Dictionary<string, DetailRowData>();

            foreach (DetailRowData det in m_targetdata.Values)
            {
                if (lp.IndexOf(" " + det.Scenario_ID + " ") == -1)
                {
                    newtar.Add("K" + det.BC_SEQ.ToString() + " " + det.Scenario_ID.ToString(), det);

                }

            }


            m_targetdata = newtar;



            retv = StripNum(ref sCommand);


            sCTs = m_sCostTypes;

            if (m_sOtherCostTypes != "")
            {
                if (sCTs == "")
                    sCTs = m_sOtherCostTypes;
                else
                    sCTs = sCTs + "," + m_sOtherCostTypes;
            }

            sCommand = "SELECT * FROM EPGP_MODEL_TARGET_DETAILS WHERE TARGET_ID IN (" + targets + ") ORDER BY TARGET_ID";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                Det = new DetailRowData(m_max_period);

                Det.CB_ID = m_CB_ID;
                Det.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                Det.BC_UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                Det.BC_SEQ = DBAccess.ReadIntValue(reader["TARGET_UID"]);

                Det.Scenario_ID = DBAccess.ReadIntValue(reader["TARGET_ID"]);

                for (int i = 1; i <= 5; i++)
                {
                    Det.OCVal[i] = DBAccess.ReadIntValue(reader["OC_0" + i.ToString()]);
                    Det.TXVal[i] = DBAccess.ReadStringValue(reader["TEXT_0" + i.ToString()]);
                }

                sCommand = "K" + Det.BC_SEQ.ToString() + " " + Det.Scenario_ID.ToString();

                if (m_targetdata.TryGetValue(sCommand, out TryDet) == false)
                    m_targetdata.Add(sCommand, Det);

            }
            reader.Close();
            reader = null;



            sCommand = "SELECT * FROM EPGP_MODEL_TARGET_VALUES WHERE TARGET_ID IN (" + targets + ") ORDER BY TARGET_ID,TARGET_UID";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();


            while (reader.Read())
            {

                xBC_SEQ = DBAccess.ReadIntValue(reader["TARGET_UID"]);
                xScenID = DBAccess.ReadIntValue(reader["TARGET_ID"]);

                sCommand = "K" + xBC_SEQ.ToString() + " " + xScenID.ToString();

                if (m_targetdata.TryGetValue(sCommand, out Det))
                {

                    Peracc = DBAccess.ReadIntValue(reader["BD_PERIOD"]);
                    Peracc = perind[Peracc];
                    Det.zCost[Peracc] = DBAccess.ReadDoubleValue(reader["BD_Cost"]);
                    Det.zValue[Peracc] = DBAccess.ReadDoubleValue(reader["BD_VALUE"]);
                }
            }
            reader.Close();
            reader = null;

            return retv;
        }
        public void ApplyUserOptions()
        {
            int i = 0;
            // to do -  set the display and drag periods from the UI

            if (m_display_minp > m_display_maxp)
            {
                i = m_display_minp;
                m_display_minp = m_display_maxp;
                m_display_maxp = i;
            }

            if (m_drag_minp > m_drag_maxp)
            {
                i = m_drag_minp;
                m_drag_minp = m_drag_maxp;
                m_drag_maxp = i;
            }

            if (m_drag_minp < m_display_minp)
                m_drag_minp = m_display_minp;

            if (m_drag_maxp > m_display_maxp)
                m_drag_maxp = m_display_maxp;

            for (int ix = 1; ix <= m_max_period; ix++)
            {
                if (ix < m_drag_minp || ix > m_drag_maxp)
                    m_PeriodMode[ix] = 0;
                else if (ix == m_drag_minp || ix == m_drag_maxp)
                    m_PeriodMode[ix] = 2;
                else
                    m_PeriodMode[ix] = 1;
            }
            LoadAnyScenarios();
        }
        private void LoadAnyScenarios()
        {
            // Trawl through the UI and find out if the user wants any scenarios displayed that have not yet been loaded - and)  load them

        }
        private void StashRateCache()
        {

            // This code caches a unique collectrion of rate/fte conversion factors based upon the details BC_UID and RT ID - which allows the rapid conversion calcs to be carried out
            string sKey = "";
            RateFTECache oRF = null;
            CatItemData oCat = null;
            RateTable oRT = null;

            foreach (DetailRowData Det in m_detaildata.Values)
            {
                sKey = "K" + Det.BC_UID.ToString() + " " + Det.m_rt.ToString();

                if (m_ratecache.TryGetValue(sKey, out oRF) == false)
                {
                    oRF = new RateFTECache(m_max_period);

                    if (m_CostCat.TryGetValue(Det.BC_UID, out oCat))
                    {
                        for (int i = 1; i <= m_max_period; i++)
                        {
                            oRF.zRate[i] = oCat.Rates[i];
                            oRF.zFTE[i] = oCat.FTEConv[i];
                        }
                    }

                    if (m_Rates.TryGetValue(Det.m_rt, out oRT))
                    {
                        for (int i = 1; i <= m_max_period; i++)
                        {
                            oRF.zRate[i] = oRT.zRate[i];
                        }
                    }

                    m_ratecache.Add(sKey, oRF);
                }
            }
        }
        private void BuildCustomFilterLists()
        {
            DataItem oItem;
            int tempj = 0;


            m_cust_Defn = new bool[11];
            m_cust_full = new int[11];
            m_cust_ocf = new CustomFieldData[11];
            m_cust_lk = new Dictionary<int, ListItemData>[11];


            for (int xj = 1; xj <= 10; xj++)
                m_cust_Defn[xj] = false;

            for (int xj = 1; xj <= 30; xj++)
                m_filter_sel[xj] = new Dictionary<int, DataItem>();


            foreach (CustomFieldData ocf in m_CustFields.Values)
            {
                tempj = ocf.FieldID - 11800;

                if (tempj >= 11 && tempj <= 20)
                    tempj = tempj - 5;

                if (tempj >= 1 && tempj <= 10)
                {

                    m_cust_Defn[tempj] = true;
                    m_cust_full[tempj] = ocf.UseFullName;
                    m_cust_ocf[tempj] = ocf;

                    m_cust_lk[tempj] = ocf.ListItems;
                }
            }

            m_filter_sel[(int)FieldIDs.SCEN_FID] = m_Scenario;
            m_filter_sel[(int)FieldIDs.PI_FID] = new Dictionary<int, DataItem>();

            tempj = 0;
            var dbg = 0;

            foreach (PIData oPI in m_PIs.Values)
            {

                if (oPI.PI_Name == "juan-Test project ")
                    dbg = 1;

                ++tempj;
                if (oPI.ScenarioID == -1 && m_allow_grouping)
                {
                    oPI.GroupingID = ""; // oPI.m_PI_Extra_data[m_PI_Group_fid];
                    oPI.GroupingPosn = 0; // int.Parse(oPI.m_PI_Extra_data[m_PI_Seq_fid]);
                }

                oPI.Internal_ID = tempj;

                if (oPI.ScenarioID == -1)
                {
                    oItem = new DataItem();

                    oItem.bSelected = true;
                    oItem.UID = oPI.PI_ID;
                    oItem.Name = oPI.PI_Name;
                    oItem.Desc = oPI.PI_Name;
                    m_filter_sel[(int)FieldIDs.PI_FID].Add(oItem.UID, oItem);

                    for (int f = (int)FieldIDs.PI_USE_EXTRA + 1; f <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA; ++f)
                    {
                        if (m_ExtraFieldTypes[f - (int)FieldIDs.PI_USE_EXTRA] != 0)
                        {
                            oPI.m_PI_Format_Extra_data[f - (int)FieldIDs.PI_USE_EXTRA] = FormatExtraDisplay(oPI.m_PI_Extra_data[f - (int)FieldIDs.PI_USE_EXTRA], m_ExtraFieldTypes[f - (int)FieldIDs.PI_USE_EXTRA]);
                        }
                        else
                            oPI.m_PI_Format_Extra_data[f - (int)FieldIDs.PI_USE_EXTRA] = "";
                    }
                }
                else
                {
                    string sPIKey = oPI.PI_ID.ToString() + " -1";
                    PIData xPI = null;

                    if (m_PIs.TryGetValue(sPIKey, out xPI) == true)
                        oPI.m_PI_Format_Extra_data = xPI.m_PI_Format_Extra_data;

                }
            }



            m_filter_sel[(int)FieldIDs.CT_FID] = m_CostTypes;

            ListItemData oLI = null;

            m_CT_List = new List<ListItemData>();
            m_BC_List = new List<ListItemData>();
            m_BC_Role_List = new List<ListItemData>();


            Dictionary<string, string> clnUom = new Dictionary<string, string>();
            Dictionary<string, DataItem> clnUomData = new Dictionary<string, DataItem>();
            Dictionary<string, string> clnMC = new Dictionary<string, string>();
            string sKey, sUom;

            string[] fullnames = new string[256];
            string s_full_name;

            m_CTARoot = new List<DataItem>();

            DataItem odi = null;


            foreach (DataItem oi in m_CostTypes.Values)
            {
                oLI = new ListItemData();
                oLI.ID = oi.UID;
                oLI.UID = oi.UID;
                oLI.Level = 1;
                oLI.Name = oi.Name;
                m_CT_List.Add(oLI);

                odi = new DataItem();
                odi.UID = oi.UID;
                odi.bSelected = false;
                odi.Name = oi.Name;

                m_CTARoot.Add(odi);

            }


            foreach (CatItemData oCat in m_CostCat.Values)
            {
                if (oCat.Level > 0)
                    fullnames[oCat.Level] = oCat.Name;

                s_full_name = fullnames[oCat.Level];

                for (int xi = 2; xi <= oCat.Level; ++xi)
                    s_full_name = s_full_name + "." + fullnames[xi];

                if (oCat.Category == oCat.UID)
                {

                    oItem = new DataItem();

                    oItem.UID = oCat.UID;
                    oItem.bSelected = true;

                    if (oCat.Level > 1)
                    {
                        oItem.Name = new string(' ', (oCat.Level - 1) * 2);
                        oItem.Name = oItem.Name + oCat.Name;
                    }
                    else
                        oItem.Name = oCat.Name;


                    oItem.Desc = oItem.Name;

                    m_filter_sel[(int)FieldIDs.CAT_FID].Add(oItem.UID, oItem);

                    oItem = new DataItem();

                    oItem.UID = oCat.UID;
                    oItem.bSelected = true;

                    oItem.Name = s_full_name;


                    oItem.Desc = s_full_name;

                    m_filter_sel[(int)FieldIDs.FULLCAT_FID].Add(oItem.UID, oItem);

                }

                oItem = new DataItem();

                oItem.UID = oCat.UID;
                oItem.bSelected = true;

                if (oCat.Level > 1)
                {
                    oItem.Name = new string(' ', (oCat.Level - 1) * 2);
                    oItem.Name = oItem.Name + oCat.Name;
                }
                else
                    oItem.Name = oCat.Name;


                oItem.Desc = oItem.Name;
                oItem.Desc = oItem.Name;
                m_filter_sel[(int)FieldIDs.BC_FID].Add(oItem.UID, oItem);

                oItem = new DataItem();

                oItem.UID = oCat.UID;
                oItem.ID = oCat.PID;
                oItem.bSelected = true;

                if (oCat.Level > 1)
                {
                    oItem.Name = new string(' ', (oCat.Level - 1) * 2);
                    oItem.Name = oItem.Name + oCat.Name;
                }
                else
                    oItem.Name = oCat.Name;


                oItem.Desc = oItem.Name;

                oItem = new DataItem();

                oItem.UID = oCat.UID;
                oItem.bSelected = true;

                oItem.Name = s_full_name;


                oItem.Desc = s_full_name;

                m_filter_sel[(int)FieldIDs.FULLC_FID].Add(oItem.UID, oItem);

                sKey = "K" + oCat.UoM;

                if (clnUom.TryGetValue(sKey, out sUom) == false)
                {
                    oItem = new DataItem();
                    oItem.UID = clnUom.Count + 1;
                    oItem.bSelected = true;
                    oItem.Name = (oCat.UoM == "" ? "(Blank - Cost Only)" : oCat.UoM);

                    m_filter_sel[(int)FieldIDs.UOM_FID].Add(oItem.UID, oItem);
                    clnUom.Add(sKey, oCat.UoM);
                    clnUomData.Add(sKey, oItem);
                }

                sKey = "K" + oCat.MC_Val;

                if (clnMC.TryGetValue(sKey, out sUom) == false)
                {
                    oItem = new DataItem();
                    oItem.UID = clnMC.Count + 1;
                    oItem.bSelected = true;
                    oItem.Name = (oCat.MC_Val == "" ? "None" : oCat.MC_Val);

                    m_filter_sel[(int)FieldIDs.MC_FID].Add(oItem.UID, oItem);
                    clnMC.Add(sKey, oCat.MC_Val);
                }


                oLI = new ListItemData();
                oLI.ID = oCat.UID;
                oLI.UID = oCat.UID;
                oLI.Level = oCat.Level;
                oLI.Name = oCat.Name;

                m_BC_List.Add(oLI);
            }


            foreach (CatItemData oCat in m_CostCat_rolly.Values)
            {
                oItem = new DataItem();
                oItem.UID = oCat.UID;
                oItem.bSelected = true;
                oItem.Name = oCat.Name;
                oItem.Desc = oCat.Name;

                m_filter_sel[(int)FieldIDs.BC_ROLE].Add(oItem.UID, oItem);



                oLI = new ListItemData();
                oLI.ID = oCat.UID;
                oLI.UID = oCat.UID;
                oLI.Level = oCat.Level;
                oLI.Name = oCat.Name;

                m_BC_Role_List.Add(oLI);
            }

            oItem = new DataItem();
            oItem.UID = 0;
            oItem.bSelected = true;
            oItem.Name = "No Role";
            oItem.Desc = oItem.Name;
            m_filter_sel[(int)FieldIDs.BC_ROLE].Add(oItem.UID, oItem);

            oLI = new ListItemData();
            oLI.ID = 0;
            oLI.UID = 0;
            oLI.Level = 1;
            oLI.Name = oItem.Name;
            m_BC_Role_List.Add(oLI);

            PIData otempPI = null;
            CatItemData oTempCat = null;


            foreach (DetailRowData odet in m_detaildata.Values)
            {
                odet.lUoM = 0;

                sKey = odet.PROJECT_ID.ToString() + " " + odet.Scenario_ID.ToString();
                if (m_PIs.TryGetValue(sKey, out otempPI) == false)
                {
                    odet.PROJECT_ID = 0;
                }
                else
                {

                    odet.m_PI_Format_Extra_data = otempPI.m_PI_Format_Extra_data;

                    if (m_CostCat.TryGetValue(odet.BC_UID, out oTempCat) == true)
                    {
                        odet.MC_Val = oTempCat.FullName;
                        odet.CAT_UID = GetShortCatUID(oTempCat);
                        odet.sUoM = oTempCat.UoM;

                        sKey = "K" + oTempCat.UoM;


                        if (clnUomData.TryGetValue(sKey, out oItem))
                        {
                            odet.lUoM = oItem.UID;
                        }

                    }
                    else
                    {
                        odet.MC_Val = "";
                        odet.CAT_UID = 0;
                        odet.sUoM = "";

                    }

                    odet.Internal_ID = otempPI.Internal_ID;

                    if ((m_CostTypes.TryGetValue(odet.CT_ID, out oItem) == false) || (m_Scenario.TryGetValue(odet.Scenario_ID, out oItem) == false))
                        odet.PROJECT_ID = 0;
                    else
                    {
                        if (odet.Det_Start == DateTime.MinValue || odet.Det_Finish == DateTime.MinValue)
                        {
                            for (int xi = 1; xi <= m_Periods.Count; xi++)
                            {
                                if (odet.zCost[xi] != 0 || odet.zValue[xi] != 0)
                                {

                                    if (odet.Det_Start == DateTime.MinValue)
                                        odet.Det_Start = persta[xi];

                                    odet.Det_Finish = perfin[xi];
                                }



                            }

                        }

                    }

                    for (int i = 1; i <= 5; i++)
                    {
                        string stxt;
                        tempj = odet.OCVal[i];
                        stxt = GetLookUpString(i, ref tempj);
                        odet.OCVal[i] = tempj;
                        odet.Text_OCVal[i] = stxt;




                        if (m_filter_sel[i + 20].TryGetValue(tempj, out oItem) == false)
                        {
                            oItem = new DataItem();
                            oItem.UID = tempj;
                            oItem.bSelected = true;
                            oItem.Name = stxt;
                            oItem.Desc = (tempj == 0 ? "ZZZZZZZZZZZZZZZZZZZZZZZ" : stxt);
                            m_filter_sel[i + 20].Add(oItem.UID, oItem);
                        }

                        stxt = odet.TXVal[i];
                        bool bTxtFound;

                        bTxtFound = false;

                        foreach (DataItem oi in m_filter_sel[i + 25].Values)
                        {
                            if (stxt == oi.Name)
                            {
                                bTxtFound = true;
                                break;
                            }
                        }

                        if (bTxtFound == false)
                        {
                            oItem = new DataItem();
                            oItem.UID = m_filter_sel[i + 25].Count;
                            oItem.bSelected = true;
                            oItem.Name = stxt;
                            oItem.Desc = (stxt == "" ? "ZZZZZZZZZZZZZZZZZZZZZZZ" : stxt);
                            m_filter_sel[i + 25].Add(oItem.UID, oItem);
                        }


                    }


                    PerformCalcs(odet, false);


                }
            }

            ApplyUserOptions();

            foreach (DetailRowData odet in m_detaildata.Values)
            {
                odet.CaputureInitialData(m_Periods);
            }

            foreach (DetailRowData odet in m_targetdata.Values)
            {
                PerformCalcs(odet, false);
            }


            SortCollection((int)FieldIDs.PI_FID);
            SortCollection((int)FieldIDs.CT_FID);
            SortCollection((int)FieldIDs.SCEN_FID);
            SortCollection((int)FieldIDs.UOM_FID);

            for (int xo = 21; xo <= 25; xo++)
                SortCollection(xo);
            for (int xo = 26; xo <= 30; xo++)
                SortCollection(xo);


            m_filterList = new List<DataItem>();
            m_filterRoot = new List<DataItem>();
            m_TotalRoot = new List<DataItem>();
            m_DetColRoot = new List<SortFieldDefn>();
            m_TotColRoot = new List<SortFieldDefn>();


            ConCatCollection((int)FieldIDs.PI_FID, (int)FieldIDs.PI_FID, "PIs");
            ConCatCollection((int)FieldIDs.CT_FID, (int)FieldIDs.CT_FID, "Cost Types");

            if (!m_bCTAMode)
                ConCatCollection((int)FieldIDs.SCEN_FID, (int)FieldIDs.SCEN_FID, "Versions");

            ConCatCollection((int)FieldIDs.BC_FID, (int)FieldIDs.BC_FID, "Cost Categories");
            ConCatCollection((int)FieldIDs.UOM_FID, (int)FieldIDs.UOM_FID, "UoM");
            ConCatCollection((int)FieldIDs.MC_FID, (int)FieldIDs.MC_FID, "Major Category");
            ConCatCollection((int)FieldIDs.CAT_FID, (int)FieldIDs.CAT_FID, "Category");
            ConCatCollection((int)FieldIDs.BC_ROLE, (int)FieldIDs.BC_ROLE, "Role");


            CustomFieldData xocf = null;

            for (int xo = 21; xo <= 25; xo++)
            {
                if (m_cust_Defn[xo - 20] == true && m_filter_sel[xo].Count > 1)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                        ConCatCollection(xo, 11800 + xo - 20, xocf.Name);

                }
            }

            for (int xo = 26; xo <= 30; xo++)
            {
                if (m_cust_Defn[xo - 20] == true && m_filter_sel[xo].Count > 1)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                        ConCatCollection(xo, 11810 + xo - 25, xocf.Name);

                }
            }

            SetHighlevelFilterFlag();

            AddTotalEntry("PIs", (int)FieldIDs.PI_FID, false);
            AddTotalEntry("Cost Types", (int)FieldIDs.CT_FID, false);
            if (!m_bCTAMode)
                AddTotalEntry("Versions", (int)FieldIDs.SCEN_FID, false);

            AddTotalEntry("Cost Categories", (int)FieldIDs.BC_FID, true);
            AddTotalEntry("Category", (int)FieldIDs.CAT_FID, false);
            AddTotalEntry("Role", (int)FieldIDs.BC_ROLE, false);


            for (int xo = 21; xo <= 25; xo++)
            {
                if (m_cust_Defn[xo - 20] == true && m_filter_sel[xo].Count > 1)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                    {
                        AddTotalEntry(xocf.Name, 11800 + xo - 20, false);
                    }

                }
            }


            for (int xo = 26; xo <= 30; xo++)
            {
                if (m_cust_Defn[xo - 20] == true && m_filter_sel[xo].Count > 1)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                    {
                        AddTotalEntry(xocf.Name, 11810 + xo - 25, false);
                    }
                }
            }

            m_DetFields = new List<SortFieldDefn>();
            m_TotFields = new List<SortFieldDefn>();


            DoSnGStuff(0, "None", true);
            DoSnGStuff((int)FieldIDs.PI_FID, "PIs", true);

            DoSnGStuff((int)FieldIDs.SD_FID, "Start", false);
            DoSnGStuff((int)FieldIDs.FD_FID, "Finish", false);

            DoSnGStuff((int)FieldIDs.CT_FID, "Cost Types", true);
            if (!m_bCTAMode)
                DoSnGStuff((int)FieldIDs.SCEN_FID, "Versions", true);

            DoSnGStuff((int)FieldIDs.BC_FID, "Cost Categories", true);
            DoSnGStuff((int)FieldIDs.BC_ROLE, "Role", true);
            DoSnGStuff((int)FieldIDs.MC_FID, "Major Category", true);
            DoSnGStuff((int)FieldIDs.FULLC_FID, "Full Cost Category", true);
            DoSnGStuff((int)FieldIDs.CAT_FID, "Category", true);
            DoSnGStuff((int)FieldIDs.FULLCAT_FID, "Full Category", true);
            DoSnGStuff((int)FieldIDs.FTOT_FID, "Total Cost", true);
            DoSnGStuff((int)FieldIDs.FTOT_FID, "Display Cost", true);

            for (int xo = 21; xo <= 25; xo++)
            {
                if (m_cust_Defn[xo - 20] == true && m_filter_sel[xo].Count > 1)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                    {
                        DoSnGStuff(11800 + xo - 20, xocf.Name, true);
                    }

                }
            }

            for (int xo = 26; xo <= 30; xo++)
            {
                if (m_cust_Defn[xo - 20] == true && m_filter_sel[xo].Count > 1)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                    {
                        DoSnGStuff(11810 + xo - 25, xocf.Name, true);
                    }
                }
            }


            for (int xo = 1; xo <= m_Use_extra; xo++)
            {
                DoSnGStuff((int)FieldIDs.PI_USE_EXTRA + xo, m_ExtraFieldNames[xo], false);
            }


            AddColEntry("PIs", (int)FieldIDs.PI_FID, true, true, true);
            AddColEntry("Start", (int)FieldIDs.SD_FID, true, false, false);
            AddColEntry("Finish", (int)FieldIDs.FD_FID, true, false, false);


            AddColEntry("Cost Types", (int)FieldIDs.CT_FID, true, true, true);
            if (!m_bCTAMode)
                AddColEntry("Versions", (int)FieldIDs.SCEN_FID, true, true, true);

            AddColEntry("Cost Categories", (int)FieldIDs.BC_FID, true, true, true);

            AddColEntry("Role", (int)FieldIDs.BC_ROLE, true, true, true);
            AddColEntry("Major Category", (int)FieldIDs.MC_FID, true, false, true);
            AddColEntry("Full Cost Category", (int)FieldIDs.FULLC_FID, false, false, true);


            AddColEntry("Category", (int)FieldIDs.CAT_FID, false, true, false);
            AddColEntry("Full Category", (int)FieldIDs.FULLCAT_FID, false, true, false);

            AddColEntry("Total Cost", (int)FieldIDs.FTOT_FID, true, true, true);
            AddColEntry("Display Cost", (int)FieldIDs.DTOT_FID, true, true, true);



            for (int xo = 21; xo <= 25; xo++)
            {
                if (m_cust_Defn[xo - 20] == true && m_filter_sel[xo].Count > 1)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                    {
                        AddColEntry(xocf.Name, 11800 + xo - 20, true, true, true);
                    }

                }
            }

            for (int xo = 26; xo <= 30; xo++)
            {
                if (m_cust_Defn[xo - 20] == true && m_filter_sel[xo].Count > 1)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                    {
                        AddColEntry(xocf.Name, 11810 + xo - 25, true, true, true);
                    }
                }
            }


            for (int xo = 1; xo <= m_Use_extra; xo++)
            {
                AddColEntry(m_ExtraFieldNames[xo], (int)FieldIDs.PI_USE_EXTRA + xo, true, false, false);
            }



            m_SnGFids[0, 0] = (int)FieldIDs.PI_FID;
            m_SnGGrp[0, 0] = 1;

            m_SnGFids[0, 1] = 0;
            m_SnGFids[1, 1] = 0;


            m_detShowToLevel = 1;
            m_totShowToLevel = 0;
        }

        private void AddTotalEntry(string Name, int fid, bool bSel)
        {
            DataItem oItem = new DataItem();
            oItem.Name = Name;
            oItem.bSelected = bSel;
            oItem.UID = fid;
            m_TotalRoot.Add(oItem);
        }

        private void AddColEntry(string Name, int fid, bool bDSel, bool bAddToTot, bool bTSel)
        {
            SortFieldDefn sfd = new SortFieldDefn();
            sfd.name = Name;
            sfd.selected = (bDSel ? 1 : 0);
            sfd.fid = fid;

            m_DetColRoot.Add(sfd);

            if (bAddToTot == true)
            {
                sfd = new SortFieldDefn();
                sfd.name = Name;
                sfd.selected = (bTSel ? 1 : 0);
                sfd.fid = fid;
                m_TotColRoot.Add(sfd);
            }
        }



        private void DoSnGStuff(int fid, string name, bool bAddTot)
        {
            SortFieldDefn sdf;

            sdf = new SortFieldDefn();
            sdf.name = name;
            sdf.fid = fid;

            m_DetFields.Add(sdf);
            if (bAddTot == true)
                m_TotFields.Add(sdf);
        }



        private void SortCollection(int i)
        {

            Dictionary<int, DataItem> cln = new Dictionary<int, DataItem>();

            if (m_filter_sel[i].Count <= 1)
                return;
            SortAndGroup sng = new SortAndGroup();
            sng.NewGrouping();


            int j = 0;
            foreach (DataItem oi in m_filter_sel[i].Values)
            {
                ++j;
                if (oi.UID == 0)
                    oi.Name = "No Value";

                sng.DefineItemValues(j, 0, 0, 0, oi.Desc, oi.Name);

            }

            sng.SortItems(1);

            int grpel = sng.CalculateGrouplingList(0, 0);


            int grp = 0;
            int ID = 0;
            int level = 0;
            int grp_lev = 0;
            string buff = "";
            DataItem xI = null;


            while (grpel != -1)
            {

                grpel = sng.ElementDetails(grpel, ref grp, ref ID, ref level, ref grp_lev, ref buff);
                xI = m_filter_sel[i].Values.ElementAt(ID - 1);
                cln.Add(xI.UID, xI);
            }

            sng.FinishedWithGrouping();



            m_filter_sel[i] = cln;

        }

        private void ConCatCollection(int i, int groupfid, string sgroup)
        {
            if (m_filter_sel[i].Count <= 1)
                return;

            DataItem oi = new DataItem();


            oi.Name = sgroup;
            oi.Desc = sgroup;
            oi.level = 1;
            oi.group = groupfid;
            oi.bSelected = true;
            oi.filterpos = m_filterList.Count + 1;

            m_filterList.Add(oi);
            m_filterRoot.Add(oi);


            foreach (DataItem x in m_filter_sel[i].Values)
            {
                x.level = 2;
                x.group = groupfid;
                m_filterList.Add(x);

            }


        }

        private void SetHighlevelFilterFlag()
        {
            m_selcln = new Dictionary<string, DataItem>();

            DataItem opar = null;
            foreach (DataItem oi in m_filterList)
            {
                if (oi.level == 1)
                {
                    opar = oi;
                    opar.bAllSelected = true;
                }

                else
                {
                    if (opar != null)
                        opar.bAllSelected &= oi.bSelected;
                }

            }

            bool bTry = false;

            foreach (DataItem oi in m_filterList)
            {
                if (oi.level == 1)
                {
                    bTry = oi.bAllSelected == false;
                }

                else if (bTry && oi.bSelected == true)
                {
                    if (oi.group <= 11810 && oi.group != (int)FieldIDs.MC_FID)
                        m_selcln.Add("K " + oi.group.ToString() + " " + oi.UID.ToString(), oi);
                    else
                        m_selcln.Add("K " + oi.group.ToString() + " " + oi.Name, oi);
                }

            }

        }


        private int GetShortCatUID(CatItemData oCat)
        {
            try
            {
                if (oCat.Category != oCat.UID)
                {
                    if (m_CostCat.TryGetValue(oCat.Category, out oCat))
                        return oCat.UID;

                    return 0;
                }
                return oCat.UID;

            }
            catch
            {
                return 0;
            }
        }

        private string GetLookUpString(int index, ref int lUID)
        {
            ListItemData oLI = null;

            if (lUID != 0)
            {
                if (m_cust_lk[index].TryGetValue(lUID, out oLI) == false)
                    lUID = 0;
            }

            if (lUID != 0)
            {
                if (m_cust_full[index] == 1)
                    return oLI.FullName;

                return oLI.Name;
            }

            return "";
        }

        private void GetCFFieldName(int lTableID, int lFieldID, out string sTable, out string sField)
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
        private void PerformCalcs(DetailRowData odet, bool bConvFtoQ)
        {

            if (odet.sUoM == "")
            {
                for (int i = 1; i <= maxp; i++)
                {
                    odet.zValue[i] = 0;
                    odet.zFTE[i] = 0;
                }
                return;
            }
            else if (bConvFtoQ == false)
            {
                for (int i = 1; i <= maxp; i++)
                {
                    odet.zFTE[i] = 0;
                }
            }

            string sKey = "";
            RateFTECache oRF = null;
            CatItemData oCat = null;

            double[] rates = null, fte = null;

            sKey = "K" + odet.BC_UID.ToString() + " " + odet.m_rt.ToString();

            if (m_ratecache.TryGetValue(sKey, out oRF))
            {
                rates = oRF.zRate;
                fte = oRF.zFTE;
            }
            else if (m_CostCat.TryGetValue(odet.BC_UID, out oCat))
            {
                rates = oCat.Rates;
                fte = oCat.FTEConv;
            }

            if (rates == null)
            {

                for (int i = 1; i <= maxp; i++)
                {
                    odet.zCost[i] = 0;
                }
                return;
            }


            if (bConvFtoQ)
            {
                for (int i = 1; i <= maxp; i++)
                {
                    odet.zValue[i] = (odet.zFTE[i] * fte[i]) / 100;
                }
            }

            for (int i = 1; i <= maxp; i++)
            {
                odet.zCost[i] = odet.zValue[i] * rates[i];
            }

            if (bConvFtoQ == false)
            {
                for (int i = 1; i <= maxp; i++)
                {
                    if (fte[i] != 0)
                        odet.zFTE[i] = (odet.zValue[i] / fte[i]) * 100;
                    else
                        odet.zFTE[i] = 0;
                }
            }
        }

        public void ProcessAndCreateDistplayLists()
        {

            // filter

            m_filtersource = new List<DetailRowData>();
            m_tgrid_sorted = new List<DetailRowData>();
            m_bgrid_sorted = new List<DetailRowData>();
            m_target_sorted = new List<DetailRowData>();
            m_list_total_dets = new List<DetailRowData>();
            m_list_target_dets = new List<DetailRowData>();


            m_total_dets = new Dictionary<string, DetailRowData>();
            m_target_dets = new Dictionary<string, DetailRowData>();





            foreach (DetailRowData odet in m_detaildata.Values)
            {
                // if filtered in 
                if (odet.HasValues)
                {
                    if (IsFiltered(odet) == true)
                        m_filtersource.Add(odet);
                }
            }

            // Build the set of total strings

            DetailRowData otot = null;

            foreach (DetailRowData odet in m_filtersource)
            {

                string sKey = BuildTotalsKey(odet);

                if (m_total_dets.TryGetValue(sKey, out otot) == false)
                {
                    otot = new DetailRowData(m_max_period);
                    otot.m_uid = m_target_dets.Count + 1;
                    otot.lUoM = odet.lUoM;
                    otot.sUoM = odet.sUoM;
                    CopyOverTotFields(otot, odet);
                    otot.m_lev = 1;
                    m_target_dets.Add(sKey, otot);
                    m_list_target_dets.Add(otot);

                    otot = new DetailRowData(m_max_period);
                    otot.m_uid = m_total_dets.Count + 1;
                    otot.lUoM = odet.lUoM;
                    otot.sUoM = odet.sUoM;
                    CopyOverTotFields(otot, odet);
                    otot.m_lev = 1;
                    m_total_dets.Add(sKey, otot);
                    m_list_total_dets.Add(otot);


                }
                else
                {
                    if (otot.lUoM != odet.lUoM)
                        otot.lUoM = -1;
                }

                odet.m_total_to = otot.m_uid;
            }

            ProcessTotals();


            if (m_bCTAMode)
                CreatePsuedoTarget();
            else
            {

                m_tarnames = "";

                foreach (DataItem oi in m_Target)
                {
                    if (m_apply_target == oi.UID)
                    {
                        m_tarnames = oi.Name;
                        break;
                    }
                }
            }
            ProcessTargets();




            m_tgrid_sorted = SortAndGroupCollection(m_filtersource, 0, out m_Det_grouped);
            m_bgrid_sorted = SortAndGroupCollection(m_list_total_dets, 1, out m_Tot_grouped);

            if (m_apply_target != 0)
            {
                bool bTemp = false;
                m_target_sorted = SortAndGroupCollection(m_list_target_dets, 1, out bTemp);
            }

            m_pi_top = true;

            for (int xi = 0; xi <= 0; ++xi)
            {
                if (m_SnGGrp[0, xi] == 1)
                {
                    if (m_SnGFids[0, xi] != (int)FieldIDs.PI_FID)
                    {
                        m_pi_top = false;

                    }
                    else
                        break;
                }
                else if (m_SnGFids[0, xi] != (int)FieldIDs.PI_FID && m_SnGFids[0, xi] < (int)FieldIDs.PI_USE_EXTRA)
                {
                    m_pi_top = false;
                    break;
                }
            }



            RollUp(m_tgrid_sorted, true, 0, m_display_minp, m_display_maxp);
            RollUp(m_bgrid_sorted, false, 1, m_display_minp, m_display_maxp);

            if (m_apply_target != 0)
                RollUp(m_target_sorted, false, 1, m_display_minp, m_display_maxp);


            // create total strings


        }
        private string BuildTotalsKey(DetailRowData odet)
        {
            string sKey = "K";
            int lVal;
            string sVal;
            int lFid = 0;

            foreach (DataItem oi in m_TotalRoot)
            {
                if (oi.bSelected == true)
                {
                    lFid = oi.UID;

                    GetDetFieldValue(odet, lFid, out lVal, out sVal);


                    if (lFid <= 11810 && lFid != (int)FieldIDs.MC_FID)
                        sKey = sKey + " " + lVal.ToString();
                    else
                        sKey = sKey + " " + sVal;
                }
            }

            return sKey;

        }
        private void GetDetFieldValue(DetailRowData odet, int fid, out int lVal, out string sVal)
        {

            lVal = 0;
            sVal = "";


            if (fid == (int)FieldIDs.PI_FID)
                lVal = odet.PROJECT_ID;
            else if (fid == (int)FieldIDs.CT_FID)
                lVal = odet.CT_ID;
            else if (fid == (int)FieldIDs.SCEN_FID)
                lVal = odet.Scenario_ID;
            else if (fid == (int)FieldIDs.BC_FID)
                lVal = odet.BC_UID;
            else if (fid == (int)FieldIDs.BC_ROLE)
                lVal = odet.BC_ROLE_UID;
            else if (fid == (int)FieldIDs.SD_FID)
                sVal = odet.Det_Start.ToString();
            else if (fid == (int)FieldIDs.FD_FID)
                sVal = odet.Det_Finish.ToString();
            else if (fid == (int)FieldIDs.UOM_FID)
                lVal = odet.lUoM;
            else if (fid == (int)FieldIDs.MC_FID)
            {
                sVal = odet.MC_Val;

                if (sVal == "")
                    sVal = "None";
            }
            else if (fid == (int)FieldIDs.CAT_FID)
                lVal = odet.CAT_UID;
            else if (fid >= 11800 && fid <= 11810)
            {
                lVal = odet.OCVal[fid - 11800];
                sVal = odet.Text_OCVal[fid - 11800];
            }
            else if (fid > 11810 && fid <= 11820)
                sVal = odet.TXVal[fid - 11810];

        }
        private void SetTotalDetFieldValue(DetailRowData odet, int fid, int lVal, string sVal)
        {
            if (fid == (int)FieldIDs.PI_FID)
                odet.PROJECT_ID = lVal;
            else if (fid == (int)FieldIDs.CT_FID)
                odet.CT_ID = lVal;
            else if (fid == (int)FieldIDs.SCEN_FID)
                odet.Scenario_ID = lVal;
            else if (fid == (int)FieldIDs.BC_FID)
                odet.BC_UID = lVal;
            else if (fid == (int)FieldIDs.BC_ROLE)
                odet.BC_ROLE_UID = lVal;
            else if (fid == (int)FieldIDs.MC_FID)
                odet.MC_Val = sVal;
            else if (fid == (int)FieldIDs.CAT_FID)
                odet.CAT_UID = lVal;
            else if (fid >= 11800 && fid <= 11810)
            {
                odet.OCVal[fid - 11800] = lVal;
                odet.Text_OCVal[fid - 11800] = sVal;
            }
            else if (fid > 11810 && fid <= 11820)
                odet.TXVal[fid - 11810] = sVal;

        }
        private void CopyOverTotFields(DetailRowData otot, DetailRowData odet)
        {
            int lVal;
            string sVal;
            int lFid = (int)FieldIDs.BC_FID;
            bool bPid = false;

            foreach (DataItem oi in m_TotalRoot)
            {
                if (oi.bSelected == true)
                {
                    lFid = oi.UID;

                    GetDetFieldValue(odet, lFid, out lVal, out sVal);
                    SetTotalDetFieldValue(otot, lFid, lVal, sVal);

                    if (lFid == (int)FieldIDs.BC_FID)
                    {
                        otot.Cat_Name = odet.Cat_Name;
                        otot.FullCatName = odet.FullCatName;
                    }

                    if (lFid == (int)FieldIDs.CAT_FID)
                    {
                        otot.CC_Name = odet.CC_Name;
                        otot.FullCCName = odet.FullCCName;
                    }

                    if (lFid >= 11801 && lFid <= 11805)
                        otot.Text_OCVal[lFid - 11800] = odet.Text_OCVal[lFid - 11800];

                    if (lFid >= 11811 && lFid <= 11815)
                        otot.TXVal[lFid - 11810] = odet.TXVal[lFid - 11810];

                    if (lFid == (int)FieldIDs.SCEN_FID)
                    {
                        otot.Scen_Name = odet.Scen_Name;
                    }

                    if (lFid == (int)FieldIDs.CT_FID)
                    {
                        otot.CT_Name = odet.CT_Name;
                    }

                    if (lFid == (int)FieldIDs.BC_ROLE)
                    {
                        otot.Role_Name = odet.Role_Name;
                    }


                    if (lFid == (int)FieldIDs.PI_FID)
                    {
                        otot.PI_Name = odet.PI_Name;

                   //     if (bPid)
                            otot.Internal_ID = odet.Internal_ID;
                    }

                }
            }
        }
        private List<DetailRowData> SortAndGroupCollection(List<DetailRowData> clnIn, int index, out bool bGrouped)
        {


            List<DetailRowData> clnsort = new List<DetailRowData>();
            int PI_Level = 0;
            int i = 0;
            bool bHadSort = false;
            bool bNoSort = false;

            string sunass = "";

            for (int xxi = 1; xxi <= 20; ++xxi)
                sunass = sunass + (char)255;


            bGrouped = false;

            foreach (DetailRowData cdata in clnIn)
            {
                cdata.g1 = 0;
                cdata.g2 = 0;
                cdata.g3 = 0;
                i = i + 1;
                cdata.m_index = i;
                cdata.bRealone = true;
            }

            SortAndGroup sng = new SortAndGroup();
            int grp_2_lev = 0;
            int f;
            string s = "";
            sng.NewGrouping();

            for (int xi = 0; xi <= 2; xi++)
            {
                if (m_SnGFids[index, xi] == 0)
                    break;

                bHadSort = true;
                bNoSort = false;

                if (m_SnGGrp[index, xi] == 1)
                    grp_2_lev = xi + 1;

                f = m_SnGFids[index, xi];


                if (PI_Level >= 0)
                {
                    if ((f == (int)FieldIDs.PI_FID || (f >= (int)FieldIDs.PI_USE_EXTRA + 1 && f <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)) == false)
                        PI_Level = -1;
                }

                if (f == (int)FieldIDs.PI_FID)
                {
                    if (PI_Level == 0)
                        PI_Level = xi + 1;

                    foreach (PIData oPI in m_PIs.Values)
                    {
                        s = oPI.PI_Name;

                        if (oPI.Scenario_name.Length != 0)
                            s = s + " (" + oPI.Scenario_name + ")";

                        sng.DefineGroupingValue(xi + 1, 0, oPI.Internal_ID, s, s);
                    }

                    foreach (DetailRowData cdata in clnIn)
                    {
                        cdata.SetSnGInd(xi, cdata.Internal_ID);

                    }
                }

                if (f == (int)FieldIDs.CT_FID)
                {

                    foreach (DataItem oi in m_CostTypes.Values)
                    {
                        sng.DefineGroupingValue(xi + 1, 0, oi.UID, oi.Name, oi.Name);
                    }

                    foreach (DetailRowData cdata in clnIn)
                    {
                        cdata.SetSnGInd(xi, cdata.CT_ID);

                    }
                }


                if (f == (int)FieldIDs.SCEN_FID)
                {

                    foreach (DataItem oi in m_Scenario.Values)
                    {
                        sng.DefineGroupingValue(xi + 1, 0, oi.UID, oi.Name, oi.Name);
                    }

                    foreach (DetailRowData cdata in clnIn)
                    {
                        cdata.SetSnGInd(xi, cdata.Scenario_ID);

                    }
                }

                if (f == (int)FieldIDs.BC_FID)
                {

                    foreach (CatItemData oCatItem in m_CostCat.Values)
                    {
                        if (index == 0)
                            sng.DefineGroupingValue(xi + 1, 0, oCatItem.UID, oCatItem.Name, oCatItem.Name);
                        else
                            sng.DefineGroupingValue(xi + 1, oCatItem.PID, oCatItem.UID, oCatItem.Name, oCatItem.Name);

                    }

                    foreach (DetailRowData cdata in clnIn)
                        cdata.SetSnGInd(xi, cdata.BC_UID);

                    bNoSort = true;

                }

                if (f == (int)FieldIDs.FULLC_FID)
                {

                    foreach (DataItem oi in m_filter_sel[(int)FieldIDs.FULLC_FID].Values)
                    {
                        if (index == 0)
                            sng.DefineGroupingValue(xi + 1, 0, oi.UID, oi.Name, oi.Name);
                        else
                            sng.DefineGroupingValue(xi + 1, oi.ID, oi.UID, oi.Name, oi.Name);

                    }

                    foreach (DetailRowData cdata in clnIn)
                        cdata.SetSnGInd(xi, cdata.BC_UID);


                    bNoSort = true;
                }

                if (f == (int)FieldIDs.CAT_FID)
                {

                    foreach (DataItem oi in m_filter_sel[(int)FieldIDs.CAT_FID].Values)
                    {
                        sng.DefineGroupingValue(xi + 1, 0, oi.UID, oi.Name, oi.Name);

                    }

                    foreach (DetailRowData cdata in clnIn)
                        cdata.SetSnGInd(xi, cdata.CAT_UID);



                    bNoSort = true;
                }


                if (f == (int)FieldIDs.FULLCAT_FID)
                {

                    foreach (DataItem oi in m_filter_sel[(int)FieldIDs.FULLCAT_FID].Values)
                    {
                        sng.DefineGroupingValue(xi + 1, 0, oi.UID, oi.Name, oi.Name);

                    }

                    foreach (DetailRowData cdata in clnIn)
                        cdata.SetSnGInd(xi, cdata.CAT_UID);


                    bNoSort = true;
                }

                if (f == (int)FieldIDs.SD_FID || f == (int)FieldIDs.FD_FID)
                {

                    Dictionary<string, int> scln = new Dictionary<string, int>();
                    int iclnind = 0;
                    DateTime dt;
                    int ix;


                    foreach (DetailRowData cdata in clnIn)
                    {
                        dt = (f == (int)FieldIDs.SD_FID ? cdata.Det_Start : cdata.Det_Finish);

                        if (dt != DateTime.MinValue)
                        {
                            s = dt.ToString("YYYYMMDD");
                            if (scln.TryGetValue(s, out ix) == false)
                            {
                                sng.DefineGroupingValue(xi + 1, 0, ++iclnind, s, dt.ToString("MM/dd/yyyy"));
                                scln.Add(s, iclnind);
                            }
                        }

                    }

                    sng.DefineGroupingValue(xi + 1, 0, 0, sunass, "Unassigned");

                    foreach (DetailRowData cdata in clnIn)
                    {
                        dt = (f == (int)FieldIDs.SD_FID ? cdata.Det_Start : cdata.Det_Finish);

                        iclnind = 0;

                        if (dt != DateTime.MinValue)
                        {
                            s = dt.ToString("YYYYMMDD");
                            if (scln.TryGetValue(s, out iclnind) == true)
                                cdata.SetSnGInd(xi, iclnind);
                        }
                    }
                }

                if (f == (int)FieldIDs.FTOT_FID || f == (int)FieldIDs.DTOT_FID)
                {

                    Dictionary<string, int> scln = new Dictionary<string, int>();
                    int iclnind = 0;
                    double d;
                    int ix;


                    foreach (DetailRowData cdata in clnIn)
                    {
                        d = (f == (int)FieldIDs.FTOT_FID ? cdata.m_tot1 : cdata.m_tot2);

                        s = d.ToString("00000000000000000");
                        if (scln.TryGetValue(s, out ix) == false)
                        {
                            sng.DefineGroupingValue(xi + 1, 0, ++iclnind, s, d.ToString());
                            scln.Add(s, iclnind);
                        }

                    }

                    foreach (DetailRowData cdata in clnIn)
                    {
                        d = (f == (int)FieldIDs.FTOT_FID ? cdata.m_tot1 : cdata.m_tot2);

                        s = d.ToString("00000000000000000");

                        iclnind = 0;

                        if (scln.TryGetValue(s, out iclnind) == true)
                            cdata.SetSnGInd(xi, iclnind);
                    }
                }

                if (f == (int)FieldIDs.BC_ROLE || f == (int)FieldIDs.MC_FID)
                {

                    foreach (DataItem x in m_filter_sel[f].Values)
                    {
                        if (x.UID != 0)
                            sng.DefineGroupingValue(xi + 1, 0, x.UID, x.Name, x.Name);

                    }

                    sng.DefineGroupingValue(xi + 1, 0, 0, sunass, "Unassigned");

                    foreach (DetailRowData cdata in clnIn)
                    {
                        s = (f == (int)FieldIDs.BC_ROLE ? cdata.Role_Name : cdata.MC_Name);

                        if (s == "")
                            cdata.SetSnGInd(xi, 0);
                        else
                        {
                            foreach (DataItem x in m_filter_sel[f].Values)
                            {
                                if (s == x.Name)
                                    cdata.SetSnGInd(xi, x.UID);
                            }
                        }
                    }
                }

                if (f >= 11801 && f <= 11805)
                {

                    int fi = f - 11800;


                    foreach (DataItem x in m_filter_sel[fi + 20].Values)
                    {
                        if (x.UID != 0)
                            sng.DefineGroupingValue(xi + 1, 0, x.UID, x.Name, x.Name);
                    }


                    sng.DefineGroupingValue(xi + 1, 0, 0, sunass, "Unassigned");

                    foreach (DetailRowData cdata in clnIn)
                        cdata.SetSnGInd(xi, cdata.OCVal[fi]);
                }

                if (f >= 11811 && f <= 11815)
                {

                    Dictionary<string, int> scln = new Dictionary<string, int>();
                    int iclnind = 0;
                    int ix;
                    int fi = f - 11810;



                    foreach (DetailRowData cdata in clnIn)
                    {
                        s = cdata.TXVal[fi];

                        if (s != "")
                        {
                            if (scln.TryGetValue(s, out ix) == false)
                            {
                                sng.DefineGroupingValue(xi + 1, 0, ++iclnind, s, s);
                                scln.Add(s, iclnind);
                            }
                        }

                    }

                    sng.DefineGroupingValue(xi + 1, 0, 0, sunass, "Unassigned");

                    foreach (DetailRowData cdata in clnIn)
                    {
                        s = cdata.TXVal[fi];
                        iclnind = 0;

                        if (scln.TryGetValue(s, out iclnind) == true)
                            cdata.SetSnGInd(xi, iclnind);
                    }


                }


                if (f >= (int)FieldIDs.PI_USE_EXTRA + 1 && f <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                {

                    Dictionary<string, int> scln = new Dictionary<string, int>();
                    int iclnind = 0;
                    int ix;
                    int fi = f - 11810;
                    PIData zPI;

                    foreach (PIData oPI in m_PIs.Values)
                    {
                        if (oPI.ScenarioID == -1)
                        {
                            s = FormatExtraSort(oPI.m_PI_Extra_data[f - (int)FieldIDs.PI_USE_EXTRA], m_ExtraFieldTypes[f - (int)FieldIDs.PI_USE_EXTRA]);
                            if (s != "")
                            {
                                if (scln.TryGetValue(s, out ix) == false)
                                {
                                    if (m_ExtraFieldTypes[f - (int)FieldIDs.PI_USE_EXTRA] == 9911)
                                    {
                                        iclnind = int.Parse(oPI.m_PI_Extra_data[f - (int)FieldIDs.PI_USE_EXTRA]);
                                        sng.DefineGroupingValue(xi + 1, 0, iclnind, s, FormatExtraDisplay(oPI.m_PI_Extra_data[f - (int)FieldIDs.PI_USE_EXTRA], m_ExtraFieldTypes[f - (int)FieldIDs.PI_USE_EXTRA]));
                                    }
                                    else
                                        sng.DefineGroupingValue(xi + 1, 0, ++iclnind, s, s);

                                    scln.Add(s, iclnind);
                                }
                            }

                        }

                    }

                    sng.DefineGroupingValue(xi + 1, 0, 0, sunass, "Unassigned");


                    foreach (DetailRowData cdata in clnIn)
                    {
                        iclnind = 0;

                        if (m_PIs.TryGetValue(cdata.PROJECT_ID.ToString() + " -1", out zPI) == true)
                        {

                            s = FormatExtraSort(zPI.m_PI_Extra_data[f - (int)FieldIDs.PI_USE_EXTRA], m_ExtraFieldTypes[f - (int)FieldIDs.PI_USE_EXTRA]);

                            if (scln.TryGetValue(s, out iclnind) == true)
                                cdata.SetSnGInd(xi, iclnind);
                        }
                    }


                }


                if (bNoSort == false)
                    sng.SortGroup(xi + 1, (m_SnGAsc[index, xi] == 1 ? -1 : 1));
                else
                    sng.DoNotSortGroup(xi + 1);



            }

            if (bHadSort == false)
            {
                foreach (DetailRowData cdata in clnIn)
                {
                    cdata.m_lev = 1;
                }

                return clnIn;
            }


            i = 0;
            foreach (DetailRowData cdata in clnIn)
            {
                ++i;
                s = i.ToString();
                sng.DefineItemValues(i, cdata.g1, cdata.g2, cdata.g3, s, s);
            }

            int sub_Lev = 0;
            int ign_Lev = 0;

            if (grp_2_lev != 1 && index == 0)
            {

                for (int xi = grp_2_lev - 1; xi >= 1; --xi)
                {
                    if (m_SnGGrp[index, xi - 1] == 0)
                    {
                        ign_Lev = xi;
                        break;
                    }
                }
            }

            int grpel = sng.CalculateGrouplingList(0, grp_2_lev);

            i = 0;

            int[] LvArr = new int[256];
            LvArr[0] = 0;

            int grp = 0;
            int ID = 0;
            int level = 0;
            int grp_lev = 0;
            string buff = "";
            DetailRowData xPI = null;


            while (grpel != -1)
            {

                grpel = sng.ElementDetails(grpel, ref grp, ref ID, ref level, ref grp_lev, ref buff);

                if (grp == 0)
                {

                    if (ID <= clnIn.Count && ID > 0) {
                        ++i;
                        level = level - sub_Lev;
                        xPI = clnIn.ElementAt(ID - 1);
                        xPI.m_par = LvArr[level - 1];
                        clnsort.Add(xPI);
                        xPI.m_index = clnsort.Count;
                        xPI.m_lev = level;
                    }
                }
                else if (grp <= ign_Lev)
                    sub_Lev = level;

                else
                {
                    ++i;

                    xPI = new DetailRowData(m_max_period);

                    xPI.bRealone = false;

                    xPI.b_PIOver = (grp == PI_Level) && (index == 0);  // only for top grid...

                    if (xPI.b_PIOver)
                    {
                        xPI.PROJECT_ID = ID;

                        PIData oPI = null;
                        DataItem oItem;

                        foreach (PIData xxx in m_PIs.Values)
                        {
                            if (xxx.Internal_ID == ID)
                            {
                                oPI = xxx;
                                break;
                            }
                        }

                        if (oPI != null)
                        {
                            m_PIs.TryGetValue(oPI.PI_ID.ToString() + " -1", out oPI);
                        }


                        if (oPI != null)
                        {

                            xPI.PI_Name = oPI.PI_Name;
                            xPI.Det_Start = oPI.StartDate;
                            xPI.Det_Finish = oPI.FinishDate;
                            xPI.m_PI_Format_Extra_data = oPI.m_PI_Format_Extra_data;

                            if (m_Scenario.TryGetValue(oPI.ScenarioID, out oItem))
                                xPI.Scen_Name = oItem.Name;
                            else
                                xPI.Scen_Name = "";
                        }


                        else
                        {
                            xPI.PI_Name = "";
                            xPI.Det_Start = DateTime.MinValue;
                            xPI.Det_Finish = DateTime.MinValue;
                            xPI.Scen_Name = "";
                        }



                    }



                    if (ID != 0)
                        xPI.sName = buff;
                    else
                        xPI.sName = "Unassigned";


                    xPI.m_sort_id = ID;

                    level = level - sub_Lev;

                    LvArr[level] = i;

                    if (level > 1)
                        xPI.m_par = LvArr[level - 1];
                    else
                        xPI.m_par = 0;


                    clnsort.Add(xPI);
                    xPI.m_index = clnsort.Count;
                    xPI.m_lev = level;
                }
            }

            sng.FinishedWithGrouping();

            foreach (DetailRowData cdata in clnIn)
            {

                cdata.g1 = 0;
                cdata.g2 = 0;
                cdata.g3 = 0;
                cdata.bGotChildren = false;
            }

            int j = 0;
            DetailRowData cpar;

            for (i = clnsort.Count; i > 0; i--)
            {
                xPI = clnsort.ElementAt(i - 1);

                if (xPI.bRealone == true)
                {

                    j = xPI.m_par;


                    while (j != 0)
                    {

                        cpar = clnsort.ElementAt(j - 1);


                        if (cpar.bGotChildren == true)
                            j = 0;
                        else
                        {
                            cpar.bGotChildren = true;
                            j = cpar.m_par;
                        }
                    }
                }


                if (xPI.m_par != 0)
                {

                    cpar = clnsort.ElementAt(xPI.m_par - 1);

                    if (cpar.g1 == 0)
                    {
                        cpar.g1 = i;
                        cpar.g2 = 1;
                        cpar.bSelected = xPI.bSelected;

                        xPI.m_mode = ((xPI.m_mode & 1) == 0 ? 0 : 1);
                        cpar.PROJECT_ID = xPI.PROJECT_ID;
                        cpar.sUoM = xPI.sUoM;
                        cpar.lUoM = xPI.lUoM;
                    }
                    else
                    {
                        if (cpar.bSelected != xPI.bSelected)
                            cpar.bSelected = false;

                        if ((xPI.m_mode & 1) == 0)
                            xPI.m_mode = 0;

                        if (cpar.sUoM != xPI.sUoM)
                        {
                            cpar.g2 = 0;
                            cpar.lUoM = -1;
                        }
                    }
                }
            }

            bGrouped = (grp_2_lev != 0);

            return clnsort;
        }

        private void RollUp(List<DetailRowData> cln, bool bdoPiCheck, int ind, int minp, int maxp)
        {

            DetailRowData odet = null;
            DetailRowData oPar = null;
            int i;
            int j = 0;
            int llim = 0;
            PIData oPI;
            double t1 = 0;
            double t2 = 0;

            llim = m_max_period;

            for (i = cln.Count; i > 0; i--)
            {
                odet = cln.ElementAt(i - 1);

                if (odet.bRealone)
                {
                    t1 = 0;
                    t2 = 0;


                    for (j = 1; j <= llim; j++)
                        t1 = t1 + odet.zCost[j];

                    for (j = minp; j <= maxp; j++)
                        t2 = t2 + odet.zCost[j];

                    odet.m_tot1 = t1;
                    odet.m_tot2 = t2;
                }


                odet.bRollupTouched = false;
            }


            if (m_SnGGrp[ind, 0] == 0 && m_SnGGrp[ind, 1] == 0 && m_SnGGrp[ind, 2] == 0)
                return;


            for (i = cln.Count; i > 0; i--)
            {
                odet = cln.ElementAt(i - 1);

                if (odet.m_par != 0)
                {
                    oPar = cln.ElementAt(odet.m_par - 1);

                    if (oPar.bRollupTouched == false)
                    {
                        oPar.bRollupTouched = true;
                        oPar.BC_ROLE_UID = odet.BC_ROLE_UID;
                        oPar.BC_UID = odet.BC_UID;
                        oPar.CAT_UID = odet.CAT_UID;
                        oPar.CB_ID = odet.CB_ID;
                        oPar.CT_ID = odet.CT_ID;
                        oPar.lUoM = odet.lUoM;
                        oPar.MC_Val = odet.MC_Val;
                        oPar.PROJECT_ID = odet.PROJECT_ID;
                        oPar.Scenario_ID = odet.Scenario_ID;
                        oPar.sUoM = odet.sUoM;

                        for (j = 1; j <= 5; j++)
                        {
                            oPar.OCVal[j] = odet.OCVal[j];
                            oPar.TXVal[j] = odet.TXVal[j];
                            oPar.Text_OCVal[j] = odet.Text_OCVal[j];
                        }


                        oPar.m_tot1 = odet.m_tot1;
                        oPar.m_tot2 = odet.m_tot2;

                        //if (oPar.Det_Start > odet.Det_Start || oPar.Det_Start == DateTime.MinValue)
                        //     oPar.Det_Start = odet.Det_Start;
                        //if (oPar.Det_Finish < odet.Det_Finish || oPar.Det_Finish == DateTime.MinValue)
                        //    oPar.Det_Finish = odet.Det_Finish;
                    }
                    else
                    {

                        if (oPar.BC_ROLE_UID != odet.BC_ROLE_UID)
                            oPar.BC_ROLE_UID = 0;

                        if (oPar.BC_UID != odet.BC_UID)
                            oPar.BC_UID = 0;
                        if (oPar.CAT_UID != odet.CAT_UID)
                            oPar.CAT_UID = 0;
                        if (oPar.CB_ID != odet.CB_ID)
                            oPar.CB_ID = 0;
                        if (oPar.CT_ID != odet.CT_ID)
                            oPar.CT_ID = 0;
                        if (oPar.lUoM != odet.lUoM)
                            oPar.lUoM = 0;
                        if (oPar.MC_Val != odet.MC_Val)
                            oPar.MC_Val = "";
                        if (oPar.PROJECT_ID != odet.PROJECT_ID)
                            oPar.PROJECT_ID = 0;
                        if (oPar.sUoM != odet.sUoM)
                            oPar.sUoM = "";
                        if (oPar.Scenario_ID != odet.Scenario_ID)
                            oPar.Scenario_ID = -2;


                        for (j = 1; j <= 5; j++)
                        {
                            if (oPar.OCVal[j] != odet.OCVal[j]) oPar.OCVal[j] = 0;
                            if (oPar.Text_OCVal[j] != odet.Text_OCVal[j]) oPar.Text_OCVal[j] = "";
                            if (oPar.TXVal[j] != odet.TXVal[j]) oPar.TXVal[j] = "";
                        }
                        oPar.m_tot1 = oPar.m_tot1 + odet.m_tot1;
                        oPar.m_tot2 = oPar.m_tot2 + odet.m_tot2;

                        //if (oPar.Det_Start > odet.Det_Start || oPar.Det_Start == DateTime.MinValue)
                        //    oPar.Det_Start = odet.Det_Start;
                        //if (oPar.Det_Finish < odet.Det_Finish || oPar.Det_Finish == DateTime.MinValue)
                        //    oPar.Det_Finish = odet.Det_Finish;

                    }


                    if (oPar.g1 == i)
                    {
                        oPar.Det_Start = odet.Det_Start;
                        oPar.Det_Finish = odet.Det_Finish;

                        if (bdoPiCheck == true)
                        {
                            if (oPar.b_PIOver == true && oPar.PROJECT_ID != 0)
                            {
                                if (oPar.Scenario_ID == 0)
                                    oPar.Scenario_ID = -1;

                                if (m_PIs.TryGetValue(oPar.PROJECT_ID.ToString() + " " + oPar.Scenario_ID.ToString(), out oPI))
                                {

                                    oPar.LinkedToPI = true;

                                    if (oPI.StartDate != DateTime.MinValue)
                                         oPar.Det_Start = oPI.StartDate;

                                    if (oPI.FinishDate != DateTime.MinValue)
                                        oPar.Det_Finish = oPI.FinishDate;
                                }
                            }
                        }

                        for (j = 1; j <= llim; j++)
                            oPar.zCost[j] = odet.zCost[j];


                        if (oPar.g2 == 1)
                        {
                            for (j = 1; j <= llim; j++)
                            {
                                oPar.zValue[j] = odet.zValue[j];
                                oPar.zFTE[j] = odet.zFTE[j];
                            }
                        }
                    }
                    else
                    {

                        if (!(bdoPiCheck == true && oPar.b_PIOver == true && oPar.PROJECT_ID != 0))
                        {
                            if (oPar.Det_Start == DateTime.MinValue)
                                oPar.Det_Start = odet.Det_Start;
                            else if (oPar.Det_Start > odet.Det_Start && odet.Det_Start != DateTime.MinValue)
                                oPar.Det_Start = odet.Det_Start;


                            if (oPar.Det_Finish < odet.Det_Finish)
                                oPar.Det_Finish = odet.Det_Finish;

                        }


                        for (j = 1; j <= llim; j++)
                            oPar.zCost[j] += odet.zCost[j];

                        if (oPar.g2 == 1)
                        {
                            for (j = 1; j <= llim; j++)
                            {
                                oPar.zValue[j] += odet.zValue[j];
                                oPar.zFTE[j] += odet.zFTE[j];
                            }

                        }
                    }
                }
            }

            if (bdoPiCheck == true)
            {

                foreach (DetailRowData xPar in cln)
                {
                    if (xPar.b_PIOver == true && xPar.PROJECT_ID != 0 && xPar.bGotChildren == false)
                    {
                        foreach (PIData xPI in m_PIs.Values)
                        {
                            if (xPI.Internal_ID == xPar.PROJECT_ID && xPI.ScenarioID == xPar.Scenario_ID)
                            {
                                xPar.LinkedToPI = true;
                                xPar.PROJECT_ID = xPI.PI_ID;


                                if (xPI.StartDate != DateTime.MinValue)
                                    xPar.Det_Start = xPI.StartDate;

                                if (xPI.FinishDate != DateTime.MinValue)
                                    xPar.Det_Finish = xPI.FinishDate;
 
                                break;
                            }
                        }
                    }
                }
            }

        }

        public String GetTopGridLayout()
        {
            TopGridCostsLayout oGrid = new TopGridCostsLayout();
            oGrid.InitializeGridLayout(m_Det_grouped, bShowFTEs, bShowGantt, m_dtMin, m_dtMax, m_DetColRoot, m_DetFreeze);

            if (bShowGantt == false)
            {
                int i = 0;

                foreach (PeriodData period in m_Periods.Values)
                {
                    ++i;

                    if (i >= m_display_minp && i <= m_display_maxp)
                        oGrid.AddPeriodColumn(i.ToString(), period.PeriodName, bShowFTEs, bUseQTY, bUseCosts, m_show_rhs_dec_costs);
                }
            }

            oGrid.FinalizeGridLayout();

            string s = oGrid.GetString();
            return s;
        }

        public String GetTopGridData()
        {
            TopGridCostsData oGrid = new TopGridCostsData();
            oGrid.InitializeGridData();
            int i = 0;

            m_tgrid_displayed = new List<DetailRowData>();

            foreach (DetailRowData oDet in m_tgrid_sorted)
            {
                if (oDet.bRealone == false)
                {
                    if (oDet.bGotChildren)
                    {
                        oGrid.AddDetailRow(oDet, ++i, true, bShowFTEs, bShowGantt, m_DetColRoot, m_display_minp, m_display_maxp, bUseQTY, bUseCosts, m_show_rhs_dec_costs);
                        m_tgrid_displayed.Add(oDet);
                    }

                }
                else
                {
                    oGrid.AddDetailRow(oDet, ++i, true, bShowFTEs, bShowGantt, m_DetColRoot, m_display_minp, m_display_maxp, bUseQTY, bUseCosts, m_show_rhs_dec_costs);
                    m_tgrid_displayed.Add(oDet);
                }

            }

            string s = oGrid.GetString();

            return s;

  

        }

        public String GetBottomGridLayout()
        {
            if (bottomgridlayoutcache != "")
                return bottomgridlayoutcache;

            BottomGridCostsLayout oGrid = new BottomGridCostsLayout();
            oGrid.InitializeGridLayout(m_Tot_grouped, m_TotColRoot, m_TotFreeze);

            int i = 0;

            foreach (PeriodData period in m_Periods.Values)
            {
                i++;
                if (i >= m_display_minp && i <= m_display_maxp)
                    oGrid.AddPeriodColumn(period.PeriodID.ToString(), period.PeriodName, bShowFTEs, bUseQTY, bUseCosts, m_show_rhs_dec_costs);
            }

            oGrid.FinalizeGridLayout();

            bottomgridlayoutcache = oGrid.GetString();
            return bottomgridlayoutcache;
        }

        public String GetBottomGridData()
        {

            BottomGridCostsData oGrid = new BottomGridCostsData();
            oGrid.InitializeGridData(false);
            int i = 0;

            DetailRowData oTar = null;

            foreach (DetailRowData oDet in m_bgrid_sorted)
            {
                if (m_apply_target != 0)
                {
                    oTar = m_target_sorted.ElementAt(i);

                    
                }
                else
                    oTar = null;

                if (oDet.bRealone == false)
                {
                    if (oDet.bGotChildren)
                        oGrid.AddDetailRow(oDet, oTar, m_TargetColours, ++i, m_Tot_grouped, bShowFTEs, m_TotColRoot, m_display_minp, m_display_maxp, bUseQTY, bUseCosts, m_ShowRemaining, m_show_rhs_dec_costs);
                }
                else
                    oGrid.AddDetailRow(oDet, oTar, m_TargetColours, ++i, m_Tot_grouped, bShowFTEs, m_TotColRoot, m_display_minp, m_display_maxp, bUseQTY, bUseCosts, m_ShowRemaining, m_show_rhs_dec_costs);
            }

            string s = oGrid.GetString();

            return s;

        }

        public void SetFTEMode(int FTEMode)
        {
            bottomgridlayoutcache = "";
            bShowFTEs = (FTEMode != 0);
        }


        public int SetGanttMode(int GanttMode)
        {
            bShowGantt = (GanttMode != 0);

            if (GanttMode == 0)
                return 0;
            else
            {
                if (m_pi_top && m_allow_grouping)
                {
                    if (m_grouping_enabled)
                        return 1;
                    else
                        return 2;

                }

                return 0;
            }
        }

        public void DoSetGroupingFlag(int GroupMode)
        {
            m_grouping_enabled = (GroupMode != 0);
        }

        private void ProcessTotals()
        {
            DetailRowData oTot;
            foreach (DetailRowData odet in m_total_dets.Values)
            {
                odet.g1 = 0;

                for (int i = 1; i <= m_max_period; i++)
                {
                    odet.zCost[i] = 0;
                    odet.zValue[i] = 0;
                    odet.zFTE[i] = 0;
                }
            }

            foreach (DetailRowData odet in m_filtersource)
            {
                if (odet.bSelected)
                {
                    oTot = m_total_dets.Values.ElementAt(odet.m_total_to - 1);


                    for (int i = 1; i <= m_max_period; i++)
                    {
                        oTot.zCost[i] += odet.zCost[i];
                        oTot.zValue[i] += odet.zValue[i];
                        oTot.zFTE[i] += odet.zFTE[i];
                    }

                }
            }
        }

        private void CreatePsuedoTarget()
        {
            m_targetdata = new Dictionary<string, DetailRowData>();

            DetailRowData xdet = null;
            string sKey = "";

            m_tarnames = "";

            foreach (DataItem oi in m_CTARoot)
            {
                if (oi.bSelected == true)
                {
                    if (m_tarnames != "")
                        m_tarnames += ",";

                    m_tarnames += oi.Name;
                    foreach (DetailRowData odet in m_detaildata.Values)
                    {
                        if (odet.Scenario_ID == -1 && odet.CT_ID == oi.UID)
                        {
                            // create a new copy o the detail

                            xdet = new DetailRowData(m_max_period);

                            xdet.CopyData(odet);

                            xdet.Scenario_ID = 1;

                            sKey = "K" + (m_targetdata.Count + 1).ToString() + " 1";

                            m_targetdata.Add(sKey, xdet);
                        }


                    }


                }
            }

            m_apply_target = 1;

            if (m_targetdata.Count == 0)
                m_apply_target = 0;


        }

        private void ProcessTargets()
        {
            if (m_apply_target == 0)
                return;


            DetailRowData oTar;
            foreach (DetailRowData odet in m_target_dets.Values)
            {
                odet.g1 = 0;

                for (int i = 1; i <= m_max_period; i++)
                {
                    odet.zCost[i] = 0;
                    odet.zValue[i] = 0;
                    odet.zFTE[i] = 0;
                }
            }

            foreach (DetailRowData odet in m_targetdata.Values)
            {
                if (odet.Scenario_ID == m_apply_target)
                {

                    string sKey = BuildTotalsKey(odet);

                    if (m_target_dets.TryGetValue(sKey, out oTar) == true)
                    {

                        for (int i = 1; i <= m_max_period; i++)
                        {
                            oTar.zCost[i] += odet.zCost[i];
                            oTar.zValue[i] += odet.zValue[i];
                            oTar.zFTE[i] += odet.zFTE[i];
                        }
                    }

                }
            }
        }

        public void SetSelectedForRow(string Row)
        {
            int lRow = int.Parse(Row);

            DetailRowData oDet = null;
            DetailRowData osDet = null;

            oDet = m_tgrid_displayed.ElementAt(lRow - 1);

            bool bSel = !oDet.bSelected;

            oDet.bSelected = bSel;

            for (int j = lRow; j < m_tgrid_displayed.Count; j++)
            {
                osDet = m_tgrid_displayed.ElementAt(j);

                if (osDet.m_lev <= oDet.m_lev)
                    break;

                osDet.bSelected = bSel;
            }


            ProcessTotals();
            RollUp(m_bgrid_sorted, false, 1, m_display_minp, m_display_maxp);

        }

        public void DoBarMove(string Row, string sStart, string sFinish, ref ModelBarsChanged retData)
        {

            int lRow = int.Parse(Row);

            List<BarMoved> bmc = new List<BarMoved>();
            BarMoved obm = null;

            retData.redrawCompleteGrid = 0;

            DetailRowData oDet = null;
            DetailRowData osDet = null;
            DateTime inStart, inFinish;
            int dragMode, delta, d1, d2;

            oDet = m_tgrid_displayed.ElementAt(lRow - 1);

            try
            {

                inStart = DateTime.ParseExact(sStart, "MM/dd/yyyy", null);
                inFinish = DateTime.ParseExact(sFinish, "MM/dd/yyyy", null);

                d1 = inStart.Subtract(oDet.Det_Start).Days;
                d2 = inFinish.Subtract(oDet.Det_Finish).Days;
            }

            catch
            {
                inStart = DateTime.MinValue;
                inFinish = DateTime.MinValue;

                d1 = 0;
                d2 = 0;
            }



            if (d1 == 0 && d2 == 0)
            {

                retData.redrawCompleteGrid = 1;
                return;
            }
 
            //if (d2 == 0)      // basiclly bars should be streched from Finish - of moved not stretched from the start!)
            //    return;


            if (d1 == 0)
            {
                dragMode = 1;
                delta = d2;
            }
            else
            {
                dragMode = 2;
                delta = d2;
            }

            retData.barsAffected = 0;

           

            if (oDet.bRealone)
            {
                if (inStart < m_dtMin)
                {
                    m_dtMin = inStart.AddDays(-90);
                    retData.redrawCompleteGrid = 1;
                }

                if (inFinish > m_dtMax)
                {
                    m_dtMax = inFinish.AddDays(370);
                    retData.redrawCompleteGrid = 1;
                }

                oDet.Det_Start = inStart;
                oDet.Det_Finish = inFinish;
                oDet.DragBar(persta, perfin, m_PeriodMode, m_drag_minp, m_drag_maxp);
                PerformCalcs(oDet, false);
            }
            else
            {
                oDet.Det_Start = inStart;
                oDet.Det_Finish = inFinish;
                PIData oPI = null;

 

                if (oDet.LinkedToPI == true && oDet.m_lev == 1)
                {
                    if (m_PIs.TryGetValue(oDet.PROJECT_ID.ToString() + " " + oDet.Scenario_ID.ToString(), out oPI))
                    {
                        oPI.StartDate = inStart;
                        oPI.FinishDate = inFinish;
                    }

                    if (inStart < m_dtMin)
                    {
                        m_dtMin = inStart.AddDays(-90);
                        retData.redrawCompleteGrid = 1;
                    }

                    if (inFinish > m_dtMax)
                    {
                        m_dtMax = inFinish.AddDays(370);
                        retData.redrawCompleteGrid = 1;
                    }

                }

                for (int j = lRow; j < m_tgrid_displayed.Count; j++)
                {
                    osDet = m_tgrid_displayed.ElementAt(j);



                    if (osDet.m_lev <= oDet.m_lev)
                        break;

                    if (dragMode == 1)
                    {
                        osDet.Det_Finish = osDet.Det_Finish.AddDays(delta);
                        if (osDet.Det_Finish < osDet.Det_Start)
                            osDet.Det_Finish = osDet.Det_Start;
                    }
                    else
                    {
                        osDet.Det_Start = osDet.Det_Start.AddDays(delta);
                        osDet.Det_Finish = osDet.Det_Finish.AddDays(delta);
                    }



                    if (osDet.bRealone)
                    {
                        osDet.DragBar(persta, perfin, m_PeriodMode, m_drag_minp, m_drag_maxp);
                        PerformCalcs(osDet, false);
                    }

                    if (osDet.Det_Start < m_dtMin)
                    {
                        m_dtMin = osDet.Det_Start.AddDays(-90);
                        retData.redrawCompleteGrid = 1;
                    }

                    if (osDet.Det_Finish > m_dtMax)
                    {
                        m_dtMax = osDet.Det_Finish.AddDays(370);
                        retData.redrawCompleteGrid = 1;
                    }


                    obm = new BarMoved();

                    obm.RowID = j + 1;
                    obm.Starts = osDet.Det_Start.ToShortDateString();
                    obm.Finishs = osDet.Det_Finish.ToShortDateString();
                    bmc.Add(obm);
                }


                if ((m_pi_top) && (oDet.m_lev == 1) && (m_grouping_enabled) && oPI != null)
                {
                    PIData xPI = null;

                    int xScen = oPI.ScenarioID;
                    string xGrp = oPI.GroupingID;
                    int xpos = oPI.GroupingPosn;

                    bool doPI = false;

                    if (oPI.GroupingID != "")
                    {


                        for (int j = 0; j < m_tgrid_displayed.Count; j++)
                        {
                            osDet = m_tgrid_displayed.ElementAt(j);

                            if (osDet.m_lev == 1)
                            {
                                doPI = false;

                                if (m_PIs.TryGetValue(osDet.PROJECT_ID.ToString() + " " + oDet.Scenario_ID.ToString(), out xPI))
                                {

                                    if (xPI.GroupingPosn > xpos && xPI.GroupingID == xGrp && xPI.ScenarioID == xScen)
                                    {
                                        doPI = true;
                                        if (dragMode == 1)
                                        {
                                            osDet.Det_Finish = osDet.Det_Finish.AddDays(delta);
                                        }
                                        else
                                        {
                                            osDet.Det_Start = osDet.Det_Start.AddDays(delta);
                                            osDet.Det_Finish = osDet.Det_Finish.AddDays(delta);
                                        }

                                        xPI.StartDate = osDet.Det_Start;
                                        xPI.FinishDate = osDet.Det_Finish;

                                        obm = new BarMoved();
                                        obm.RowID = j + 1;
                                        obm.Starts = osDet.Det_Start.ToShortDateString();
                                        obm.Finishs = osDet.Det_Finish.ToShortDateString();
                                        bmc.Add(obm);


                                    }
                                }
                            }
                            else if (doPI)
                            {
                                if (dragMode == 1)
                                {
                                    osDet.Det_Finish = osDet.Det_Finish.AddDays(delta);
                                }
                                else
                                {
                                    osDet.Det_Start = osDet.Det_Start.AddDays(delta);
                                    osDet.Det_Finish = osDet.Det_Finish.AddDays(delta);
                                }



                                if (osDet.bRealone)
                                {
                                    osDet.DragBar(persta, perfin, m_PeriodMode, m_drag_minp, m_drag_maxp);
                                    PerformCalcs(osDet, false);
                                }

                                obm = new BarMoved();
                                obm.RowID = j + 1;
                                obm.Starts = osDet.Det_Start.ToShortDateString();
                                obm.Finishs = osDet.Det_Finish.ToShortDateString();
                                bmc.Add(obm);


                            }
                        }
                    }

                }

                retData.barsAffected = bmc.Count;
                retData.RowID = new int[retData.barsAffected];
                retData.Starts = new string[retData.barsAffected];
                retData.Finishs = new string[retData.barsAffected];

                int cnt = 0;
                foreach (BarMoved xbm in bmc)
                {
                    retData.RowID[cnt] = xbm.RowID;
                    retData.Starts[cnt] = xbm.Starts;
                    retData.Finishs[cnt++] = xbm.Finishs;
                }

            }



            ProcessTotals();
            RollUp(m_tgrid_sorted, true, 0, m_display_minp, m_display_maxp);
            RollUp(m_bgrid_sorted, false, 1, m_display_minp, m_display_maxp);
            return;
        }

        public void DoCopyVersion(string sFrom, string sTo, string sPIs)
        {

            int iFrom = int.Parse(sFrom);
            int iTo = int.Parse(sTo);
            string sToScenName;
            string sKey;

            if (iFrom == 0)
                iFrom = -1;

            if (iTo <= 0)
                return;

            DataItem oItem = null;

            if (m_Scenario.TryGetValue(iTo, out oItem))
            {
                sToScenName = oItem.Name;
                oItem.bLoaded = true;
                oItem.bSelected = true;
                SetHighlevelFilterFlag();
            }
            else
                return;



            sPIs = sPIs.Trim();

            if (sPIs != "")
                sPIs = " " + sPIs + " ";

            Dictionary<string, DetailRowData> newCln = new Dictionary<string, DetailRowData>();
            foreach (DetailRowData oDet in m_detaildata.Values)
            {

                sKey = "K" + oDet.CT_ID.ToString() + " " + oDet.PROJECT_ID.ToString() + " " + oDet.BC_UID.ToString() + " " + oDet.BC_SEQ.ToString() + " " + oDet.Scenario_ID.ToString();

                if (oDet.Scenario_ID != iTo)
                {
                    newCln.Add(sKey, oDet);
                }

                if (oDet.Scenario_ID == iTo)
                {
                    if (sPIs != "")
                    {
                        // we are only to copy over specific PIs)

                        if (sPIs.IndexOf(" " + oDet.PROJECT_ID.ToString() + " ") == -1)
                        {
                            // if PI assoc with this Det is not in the list of PIs to copy over then it should be left in the mix
                            newCln.Add(sKey, oDet);
                        }
                    }
                }

                if (oDet.Scenario_ID == iFrom)
                {
                    // oK we may need to make a copy of this det but link it to the PI for this version

                    bool bDoIt = false;

                    if (sPIs == "")
                        bDoIt = true;
                    else
                    {
                        // we are only to copy over specific PIs)

                        if (sPIs.IndexOf(" " + oDet.PROJECT_ID.ToString() + " ") != -1)
                            bDoIt = true;
                    }

                    if (bDoIt)
                    {
                        PIData oPI = null;
                        PIData oTempPI = null;
                        DetailRowData oNew = null;



                        sKey = oDet.PROJECT_ID.ToString() + " " + oDet.Scenario_ID.ToString();
                        m_PIs.TryGetValue(sKey, out oTempPI);

                        sKey = oDet.PROJECT_ID.ToString() + " " + iTo.ToString();

                        // PI not present in that version
                        if (m_PIs.TryGetValue(sKey, out oPI) == false)
                        {
                            oPI = new PIData((int)FieldIDs.MAX_PI_EXTRA);
                            oPI.PI_ID = oTempPI.PI_ID;
                            //                            oPI.StartDate = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"]);
                            //                            oPI.FinishDate = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"]);
                            oPI.ScenarioID = iTo;
                            oPI.PISelected = oTempPI.PISelected;

                            oPI.PI_Name = oTempPI.PI_Name;
                            oPI.Scenario_name = sToScenName;

                            for (int ix = 1; ix <= (int)FieldIDs.MAX_PI_EXTRA; ix++)
                                oPI.m_PI_Extra_data[ix] = oTempPI.m_PI_Extra_data[ix];

                            oPI.m_PI_Format_Extra_data = oTempPI.m_PI_Format_Extra_data;


                            m_PIs.Add(sKey, oPI);
                            oPI.Internal_ID = m_PIs.Count;

                        }
                        oPI.StartDate = oTempPI.StartDate;
                        oPI.FinishDate = oTempPI.FinishDate;

                        oNew = new DetailRowData(m_max_period);

                        oNew.CopyData(oDet);

                        oNew.Scenario_ID = iTo;
                        oNew.Scen_Name = sToScenName;
                        oNew.Internal_ID = oPI.Internal_ID;
                        oNew.sUoM = oDet.sUoM;


                        sKey = "K" + oNew.CT_ID.ToString() + " " + oNew.PROJECT_ID.ToString() + " " + oNew.BC_UID.ToString() + " " + oNew.BC_SEQ.ToString() + " " + oNew.Scenario_ID.ToString();
                        newCln.Add(sKey, oNew);
                    }

                }

            }

            bool xDoIt = false;
            List<PIData> cln = new List<PIData>();

            foreach (PIData xPI in m_PIs.Values)
            {
                if (xPI.ScenarioID == iFrom)
                {
                    if (sPIs == "")
                        xDoIt = true;
                    else
                    {
                        if (sPIs.IndexOf(" " + xPI.PI_ID.ToString() + " ") != -1)
                            xDoIt = true;
                    }

                    if (xDoIt)
                    {
                        PIData xTmpPI, basePI;

                        sKey = xPI.PI_ID.ToString() + " " + iTo.ToString();

                        if (m_PIs.TryGetValue(sKey, out xTmpPI) == false)
                        {
                            if (m_PIs.TryGetValue(xPI.PI_ID.ToString() + " -1", out basePI) == true)
                            {
                                xTmpPI = new PIData((int)FieldIDs.MAX_PI_EXTRA);
                                xTmpPI.PI_ID = basePI.PI_ID;
                                //                            oPI.StartDate = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"]);
                                //                            oPI.FinishDate = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"]);
                                xTmpPI.ScenarioID = iTo;
                                xTmpPI.PISelected = basePI.PISelected;

                                xTmpPI.PI_Name = basePI.PI_Name;
                                xTmpPI.Scenario_name = sToScenName;

                                for (int ix = 1; ix <= (int)FieldIDs.MAX_PI_EXTRA; ix++)
                                    xTmpPI.m_PI_Extra_data[ix] = basePI.m_PI_Extra_data[ix];

                                xTmpPI.m_PI_Format_Extra_data = basePI.m_PI_Format_Extra_data;


                                cln.Add(xTmpPI);
                                xTmpPI.Internal_ID = m_PIs.Count + cln.Count;

                            }
                            xTmpPI.StartDate = basePI.StartDate;
                            xTmpPI.FinishDate = basePI.FinishDate;

                        }


                    }
                }

            }

            foreach (PIData xPI in cln)
            {
                sKey = xPI.PI_ID.ToString() + " " + iTo.ToString();
                m_PIs.Add(sKey, xPI);
            }


            m_detaildata = newCln;
            ProcessAndCreateDistplayLists();



        }


        public String GetFilterGridLayout()
        {
            FilterGridCostsLayout oGrid = new FilterGridCostsLayout();
            oGrid.InitializeGridLayout();

            string s = oGrid.GetString();
            return s;
        }

        public String GetFilterGridData()
        {

            FilterGridCostsData oGrid = new FilterGridCostsData();
            oGrid.InitializeGridData();
            int i = 0;


            foreach (DataItem oi in m_filterList)
                oGrid.AddRow(++i, oi.level, oi.Name, oi.bSelected);


            string s = oGrid.GetString();

            return s;

        }

        public string SetFilterData(string sFilterData)
        {
            int i;
            string sWrk = sFilterData;

            foreach (DataItem oi in m_filterList)
            {
                i = StripNum(ref sWrk);

                oi.bSelected = (i != 0);

            }

            SetHighlevelFilterFlag();


            string sScen = "";

            foreach (DataItem oi in m_Scenario.Values)
            {
                if (oi.bSelected == true && oi.bLoaded == false)
                {
                    if (sScen == "")
                        sScen = oi.UID.ToString();
                    else
                        sScen = sScen + "," + oi.UID.ToString();
                }

            }

            return sScen;
        }


        private bool IsFiltered(DetailRowData oDet)
        {
            int lVal = 0;
            string sVal = "";
            DataItem xi;

            foreach (DataItem oi in m_filterRoot)
            {
                if (oi.bAllSelected == false)
                {
                    GetDetFieldValue(oDet, oi.group, out lVal, out sVal);
                    if (oi.group <= 11810 && oi.group != (int)FieldIDs.MC_FID)
                    {
                        if (m_selcln.TryGetValue("K " + oi.group.ToString() + " " + lVal.ToString(), out xi) == false)
                            return false;
                    }
                    else
                    {
                        if (m_selcln.TryGetValue("K " + oi.group.ToString() + " " + sVal, out xi) == false)
                            return false;
                    }
                }

            }

            return true;

        }

        public String GetTotalGridLayout()
        {
            FilterGridCostsLayout oGrid = new FilterGridCostsLayout();
            oGrid.InitializeGridLayout();

            string s = oGrid.GetString();
            return s;
        }

        public String GetCTCmpGridData()
        {

            FilterGridCostsData oGrid = new FilterGridCostsData();
            oGrid.InitializeGridData();
            int i = 0;


            foreach (DataItem oi in m_CTARoot)
                oGrid.AddRow(++i, 0, oi.Name, oi.bSelected);


            string s = oGrid.GetString();

            return s;

        }

        public void SetCTCmpData(string sCTCmpData)
        {
            int i;
            string sWrk = sCTCmpData;

            foreach (DataItem oi in m_CTARoot)
            {
                i = StripNum(ref sWrk);

                oi.bSelected = (i != 0);

            }

            return;
        }



        public String GetTotalGridData()
        {

            FilterGridCostsData oGrid = new FilterGridCostsData();
            oGrid.InitializeGridData();
            int i = 0;


            foreach (DataItem oi in m_TotalRoot)
                oGrid.AddRow(++i, 0, oi.Name, oi.bSelected);


            string s = oGrid.GetString();

            return s;

        }

        private void SetTotColsbasedonTotaling()
        {


            foreach (DataItem oi in m_TotalRoot)
            {

                if (oi.UID == (int)FieldIDs.PI_FID || oi.UID == (int)FieldIDs.SCEN_FID || oi.UID == (int)FieldIDs.BC_ROLE || oi.UID == (int)FieldIDs.CT_FID || oi.UID == (int)FieldIDs.MC_FID || oi.UID == (int)FieldIDs.BC_FID || oi.UID == (int)FieldIDs.FULLC_FID || oi.UID == (int)FieldIDs.CAT_FID || oi.UID == (int)FieldIDs.FULLCAT_FID)
                {
                    foreach (SortFieldDefn osng in m_TotColRoot)
                    {
                        if (osng.fid == oi.UID)
                            osng.selected = (oi.bSelected ? 1 : 0);

                    }
                }

            }

            bottomgridlayoutcache = "";            
        }

        public void SetTotalData(string sTotalData)
        {
            int i;
            string sWrk = sTotalData;

            foreach (DataItem oi in m_TotalRoot)
            {
                i = StripNum(ref sWrk);

                oi.bSelected = (i != 0);


 


            }


            SetTotColsbasedonTotaling();
            return;
        }



        public void GetSortAndGroup(ref SortGroupDefn sng)
        {
            if (m_initial_zoom != "")
                sng.ViewZoomTo = m_initial_zoom;

            m_initial_zoom = "";

            sng.errMsg = m_loadmsg;
            sng.LoadReturnCode = m_loaddatareturn;
            sng.HaveLowlevelData = m_lowlevelDataCount;
            sng.NumPIs = m_PI_Count;
            sng.MissingPIs = (m_GotAllPIs == false ? 1 : 0);

            sng.TotalsCmp = (m_apply_target != 0 ? 1 : 0);
         
            if (m_DetFields == null)
            {
                sng.DetFields = new SortFieldDefn[0];
                sng.TotFields = new SortFieldDefn[0];
                sng.DetRows = new SortRowDefn[3];
                sng.TotRows = new SortRowDefn[3];
                return;

            }

            sng.DetFields = new SortFieldDefn[m_DetFields.Count];
            sng.TotFields = new SortFieldDefn[m_TotFields.Count];
            sng.DetRows = new SortRowDefn[3];
            sng.TotRows = new SortRowDefn[3];

            int i = 0;

            foreach (SortFieldDefn sfd in m_DetFields)
                sng.DetFields[i++] = sfd;


            i = 0;

            foreach (SortFieldDefn sfd in m_TotFields)
                sng.TotFields[i++] = sfd;

            for (int xo = 0; xo < 3; xo++)
            {
                sng.DetRows[xo] = new SortRowDefn();
                sng.TotRows[xo] = new SortRowDefn();

                sng.DetRows[xo].fid = m_SnGFids[0, xo];
                sng.TotRows[xo].fid = m_SnGFids[1, xo];

                sng.DetRows[xo].decf = m_SnGAsc[0, xo];
                sng.TotRows[xo].decf = m_SnGAsc[1, xo];

                sng.DetRows[xo].grpf = m_SnGGrp[0, xo];
                sng.TotRows[xo].grpf = m_SnGGrp[1, xo];

            }

            sng.DetShowToLevel = m_detShowToLevel;
            sng.TotShowToLevel = m_totShowToLevel;


        }
        public void SetSortAndGroup(SortGroupDefn sng)
        {

            for (int xo = 0; xo < 3; xo++)
            {

                m_SnGFids[0, xo] = sng.DetRows[xo].fid;
                m_SnGFids[1, xo] = sng.TotRows[xo].fid;

                m_SnGAsc[0, xo] = sng.DetRows[xo].decf;
                m_SnGAsc[1, xo] = sng.TotRows[xo].decf;

                m_SnGGrp[0, xo] = sng.DetRows[xo].grpf;
                m_SnGGrp[1, xo] = sng.TotRows[xo].grpf;

            }
            m_detShowToLevel = sng.DetShowToLevel;
            m_totShowToLevel = sng.TotShowToLevel;

            bottomgridlayoutcache = "";
            ProcessAndCreateDistplayLists();

        }

        private string FormatExtraSort(string sIn, int lt)
        {
            int l;
            double d;
            DataItem oi;

            switch (lt)
            {
                case 1:
                    return sIn;


                case 2:
                    l = int.Parse(sIn);
                    return l.ToString("00000000000");

                case 3:
                    d = Double.Parse(sIn);
                    return d.ToString("00000000000");

                case 11:
                    l = int.Parse(sIn);
                    return l.ToString("000");

                case 13:
                    l = int.Parse(sIn);
                    return (l == 0 ? "No" : "Yes");

                case 6:
                case 9:
                case 19:
                    return sIn;


                case 8:
                    d = Double.Parse(sIn);
                    return d.ToString("00000000000");

                case 20:
                    d = Double.Parse(sIn);
                    return d.ToString("00000000000");

                case 23:
                    d = Double.Parse(sIn);
                    return d.ToString("00000000000");

                case 9911:
                    l = int.Parse(sIn);
                    return l.ToString("000");

                case 4:
                    l = int.Parse(sIn);

                    if (m_codes.TryGetValue(l, out oi))
                        return oi.Name;

                    return "";

                case 7:
                    l = int.Parse(sIn);

                    if (m_reses.TryGetValue(l, out oi))
                        return oi.Name;

                    return "";
            }

            return "";
        }

        private string FormatExtraDisplay(string sIn, int lt)
        {
            DateTime dt;
            int l;
            double d;
            DataItem oi;


            switch (lt)
            {
                case 1:
                    dt = DateTime.MinValue;

                    try
                    {
                        dt = DateTime.ParseExact(sIn, "yyyyMMdd", null);
                    }

                    catch
                    {
                    }

                    try
                    {
                        if (dt == DateTime.MinValue)
                            dt = DateTime.ParseExact(sIn, "yyyyMMddHHmm", null);
                    }

                    catch
                    {
                    }

                    if (dt > DateTime.MinValue)
                        return dt.ToString("MM/dd/yyyy");

                    return "";

                case 2:
                   try
                    {
                        l = int.Parse(sIn);
                    }

                    catch
                    {
                         l = 0;
                    }

                    

                    if (l != 0)
                        return l.ToString();

                    return "";


                case 3:
                    
                    try
                    {
                        d = Double.Parse(sIn);
                    }

                    catch
                    {
                        d = 0;
                    }

                    
                    if (d != 0)
                        return d.ToString();

                    return "";

                case 11:
                   try
                    {
                        l = int.Parse(sIn);
                    }

                    catch
                    {
                         l = 0;
                    }

                    if (l != 0)
                        return l.ToString("0%");

                    return "";

                case 13:
                   try
                    {
                        l = int.Parse(sIn);
                    }

                    catch
                    {
                         l = 0;
                    }

                    return (l == 0 ? "No" : "Yes");

                case 6:
                case 9:
                case 19:
                    return sIn;


                case 8:
                    try
                    {
                        d = Double.Parse(sIn);
                    }

                    catch
                    {
                        d = 0;
                    }

                    if (d != 0)
                        return d.ToString("$#,##0.00");

                    return "";

                case 20:
                    try
                    {
                        d = Double.Parse(sIn);
                    }

                    catch
                    {
                        d = 0;
                    }

                    
                    return FormatWork(d);

                case 23:
                    try
                    {
                        d = Double.Parse(sIn);
                    }

                    catch
                    {
                        d = 0;
                    }

                    return FormatDuration(d);

                case 4:
                    try
                    {
                        l = int.Parse(sIn);
                    }

                    catch
                    {
                         l = 0;
                    }

                    if (m_codes.TryGetValue(l, out oi))
                        return oi.Name;

                    return "";

                case 7:
                    try
                    {
                        l = int.Parse(sIn);
                    }

                    catch
                    {
                        l = 0;
                    }

                    if (m_reses.TryGetValue(l, out oi))
                        return oi.Name;

                    return "";

                case 9911:
                    try
                    {
                        l = int.Parse(sIn);
                    }

                    catch
                    {
                        l = 0;
                    }

                    if (m_stages.TryGetValue(l, out oi))
                        return oi.Name;

                    return "";
            }

            return "";
        }

        private string FormatWork(double Hours)
        {
            string s;
            double d;

            d = Hours / 100;

            if (d < 0.005)
                return "";

            s = d.ToString("0.000");

            for (int i = 1; i <= 3; ++i)
            {
                if (s[s.Length] == '0')
                    s = s.Substring(0, s.Length - 1);
            }

            if (s[s.Length] == '.')
                s = s.Substring(0, s.Length - 1);

            if (s == "0")
                return "";

            return s + " h";
        }

        private string FormatDuration(double minutes)
        {
            string s;
            double d;


            if (minutes == 0)
                return "";


            d = minutes / (60 * 8 * 10);

            s = d.ToString("0.000");

            for (int i = 1; i <= 3; ++i)
            {
                if (s[s.Length] == '0')
                    s = s.Substring(0, s.Length - 1);
            }

            if (s[s.Length] == '.')
                s = s.Substring(0, s.Length - 1);


            if (s == "0")
                return "";

            return s + " d";
        }

        public string GetColumnGridData()
        {
            FilterGridCostsData oGrid = new FilterGridCostsData();
            oGrid.InitializeGridData();

            for (int i = 1; i <= 50; ++i)
                oGrid.AddRow(i, 0, "", false);


            string s = oGrid.GetString();

            return s;

        }

        public void GetColumnData(ref SortGroupDefn sng)
        {
            sng.DetFields = new SortFieldDefn[m_DetColRoot.Count];
            sng.TotFields = new SortFieldDefn[m_TotColRoot.Count];

            int i = 0;

            foreach (SortFieldDefn sfd in m_DetColRoot)
                sng.DetFields[i++] = sfd;

            sng.DetFreeze = m_DetFreeze;


            i = 0;

            foreach (SortFieldDefn sfd in m_TotColRoot)
                sng.TotFields[i++] = sfd;

            sng.TotFreeze = m_TotFreeze;
        }

        public void SetColumnOrderData(SortGroupDefn sng)
        {

            List<SortFieldDefn> cln = null;

            cln = new List<SortFieldDefn>();

            for (var i = 0; i < m_DetColRoot.Count; i++)
                cln.Add(sng.DetFields[i]);

            m_DetColRoot = cln;
            m_DetFreeze = sng.DetFreeze;

            cln = new List<SortFieldDefn>();

            for (var i = 0; i < m_TotColRoot.Count; i++)
                cln.Add(sng.TotFields[i]);

            m_TotColRoot = cln;
            m_TotFreeze = sng.TotFreeze;

            bottomgridlayoutcache = "";


        }

        public void GetVersionsPILists(ref SortGroupDefn sng, int fromVer, int toVer)
        {

            if (fromVer == toVer || toVer == 0)
            {
                sng.DetFields = new SortFieldDefn[0];
                sng.TotFields = new SortFieldDefn[0];
                return;
            }

            if (fromVer == 0)
                fromVer = -1;

            Dictionary<int, PIData> clnFrom = new Dictionary<int, PIData>();
            Dictionary<int, PIData> clnTo = new Dictionary<int, PIData>();
            List<PIData> clnNotTo = new List<PIData>();
            List<PIData> clnBoth = new List<PIData>();
            PIData xPI = null;

            foreach (PIData oPI in m_PIs.Values)
            {
                if (oPI.ScenarioID == fromVer)
                    clnFrom.Add(oPI.PI_ID, oPI);
                else if (oPI.ScenarioID == toVer)
                    clnTo.Add(oPI.PI_ID, oPI);
            }

            foreach (PIData oPI in clnFrom.Values)
            {
                if (clnTo.TryGetValue(oPI.PI_ID, out xPI) == true)
                    clnBoth.Add(oPI);
                else
                    clnNotTo.Add(oPI);
            }

            sng.DetFields = new SortFieldDefn[clnNotTo.Count];
            sng.TotFields = new SortFieldDefn[clnBoth.Count];

            int i = 0;
            SortFieldDefn sfd = null;

            clnNotTo.Sort();
            foreach (PIData oPI in clnNotTo)
            {
                sfd = new SortFieldDefn();
                sfd.name = oPI.PI_Name;
                sfd.fid = oPI.PI_ID;

                sng.DetFields[i++] = sfd;
            }


            i = 0;


            foreach (PIData oPI in clnBoth)
            {
                sfd = new SortFieldDefn();
                sfd.name = oPI.PI_Name;
                sfd.fid = oPI.PI_ID;

                sng.TotFields[i++] = sfd;
            }

        }
        public void GetSaveVersions(ref List<ItemDefn> versions)
        {
            ItemDefn xi = null;

            foreach (DataItem oi in m_Scenario.Values)
            {
                if (oi.bLoaded == true && oi.UID > 0)
                {
                    xi = new ItemDefn();

                    xi.Id = oi.UID;
                    xi.Name = oi.Name;
                    versions.Add(xi);
                }
            }


        }

        public void GetTargets(ref List<ItemDefn> targets)
        {
            ItemDefn xi = null;

            foreach (DataItem oi in m_Target)
            {
                xi = new ItemDefn();

                xi.Id = oi.UID;
                xi.Name = oi.Name;
                targets.Add(xi);
            }


        }



        public int SaveVersion(SqlConnection oDataAccess, string version)
        {
            try
            {

                //              m_oDataAccess = oDataAccess;



                if (version != "")
                {

                    int iVers = Int16.Parse(version);
                    int lRowsAffected = 0;

                    string sCommand = "";

                    string sWhereP1 = "MODEL_UID = " + m_sModel + " AND MODEL_VERSION_UID = " + version;
                    string sPIs = "";
                    string sCTs = "";

                    foreach (PIData oPI in m_PIs.Values)
                    {
                        if (oPI.ScenarioID <= 0)
                        {
                            if (sPIs == "")
                                sPIs = oPI.PI_ID.ToString();
                            else
                                sPIs += "," + oPI.PI_ID.ToString();
                        }
                    }

                    foreach (DataItem oCT in m_CostTypes.Values)
                    {
                        if (sCTs == "")
                            sCTs = oCT.UID.ToString();
                        else
                            sCTs += "," + oCT.UID.ToString();

                    }


                    try
                    {
                        sCommand = "DELETE FROM EPGP_MODEL_PROJECT_DATES WHERE " + sWhereP1 + " AND PROJECT_ID IN (" + sPIs + ")";
                        SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                        lRowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveVersion", (PortfolioEngineCore.StatusEnum)99826, ex.Message.ToString(), 0, "");
                    }


                    try
                    {
                        sCommand = "DELETE FROM EPGP_MODEL_COST_DETAILS WHERE " + sWhereP1 + " AND PROJECT_ID IN (" + sPIs + ") AND CT_ID IN (" + sCTs + ")";
                        SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                        lRowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveVersion", (PortfolioEngineCore.StatusEnum)99825, ex.Message.ToString(), 0, "");
                    }

                    try
                    {
                        sCommand = "DELETE FROM EPGP_MODEL_DETAIL_VALUES WHERE " + sWhereP1 + " AND PROJECT_ID IN (" + sPIs + ") AND CT_ID IN (" + sCTs + ")";
                        SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                        lRowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveVersion", (PortfolioEngineCore.StatusEnum)99824, ex.Message.ToString(), 0, "");
                    }

                    sCommand = "insert into EPGP_MODEL_PROJECT_DATES (MODEL_UID, MODEL_VERSION_UID,  PROJECT_ID, PROJECT_START_DATE, PROJECT_FINISH_DATE,PROJECT_SELECTED) " +
                                " VALUES(" + m_sModel + "," + version + ",@PROJECT_ID, @PROJECT_START_DATE, @PROJECT_FINISH_DATE,@PROJECT_SELECTED)";

                    try
                    {
                        SqlCommand oCommand = new SqlCommand(sCommand, oDataAccess);

                        SqlParameter project_id = oCommand.Parameters.Add("@PROJECT_ID", SqlDbType.Int);
                        SqlParameter project_Start = oCommand.Parameters.Add("@PROJECT_START_DATE", SqlDbType.DateTime);
                        SqlParameter project_Finish = oCommand.Parameters.Add("@PROJECT_FINISH_DATE", SqlDbType.DateTime);
                        SqlParameter project_selected = oCommand.Parameters.Add("@PROJECT_SELECTED", SqlDbType.Int);

                        foreach (PIData oPI in m_PIs.Values)
                        {
                            if (oPI.ScenarioID == iVers)
                            {

                                project_id.Value = oPI.PI_ID;

                                if (oPI.StartDate <= DateTime.MinValue)
                                    project_Start.Value = DBNull.Value;
                                else
                                    project_Start.Value = oPI.StartDate;


                                if (oPI.FinishDate <= DateTime.MinValue)
                                    project_Finish.Value = DBNull.Value;
                                else
                                    project_Finish.Value = oPI.FinishDate; 
                                
                                
                                project_selected.Value = oPI.PISelected;

                                lRowsAffected = oCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveVersion", (PortfolioEngineCore.StatusEnum)99823, ex.Message.ToString(), 0, "");
                    }

                    try
                    {

                        sCommand = "insert into EPGP_MODEL_COST_DETAILS (MODEL_UID,MODEL_VERSION_UID, CB_ID,CT_ID, PROJECT_ID, BC_SEQ, BC_UID, OC_01,OC_02, OC_03, OC_04, OC_05,TEXT_01,TEXT_02, TEXT_03, TEXT_04, TEXT_05,SELECTED_FLAG, RT_UID) " +
                                 " VALUES(" + m_sModel + "," + version + "," + m_CB_ID.ToString() + ",@CT_ID, @PROJECT_ID, @BC_SEQ, @BC_UID, @OC_01,@OC_02, @OC_03, @OC_04, @OC_05,@TEXT_01,@TEXT_02, @TEXT_03, @TEXT_04, @TEXT_05,@SELECTED_FLAG, @RT_UID)";

                        SqlCommand oCmdCF = new SqlCommand(sCommand, oDataAccess);

                        SqlParameter ct_id = oCmdCF.Parameters.Add("@CT_ID", SqlDbType.Int);
                        SqlParameter project_id = oCmdCF.Parameters.Add("@PROJECT_ID", SqlDbType.Int);
                        SqlParameter bc_seq_id = oCmdCF.Parameters.Add("@BC_SEQ", SqlDbType.Int);
                        SqlParameter bc_uid = oCmdCF.Parameters.Add("@BC_UID", SqlDbType.Int);

                        SqlParameter oc1_id = oCmdCF.Parameters.Add("@OC_01", SqlDbType.Int);
                        SqlParameter oc2_id = oCmdCF.Parameters.Add("@OC_02", SqlDbType.Int);
                        SqlParameter oc3_id = oCmdCF.Parameters.Add("@OC_03", SqlDbType.Int);
                        SqlParameter oc4_id = oCmdCF.Parameters.Add("@OC_04", SqlDbType.Int);
                        SqlParameter oc5_id = oCmdCF.Parameters.Add("@OC_05", SqlDbType.Int);

                        SqlParameter tx1_id = oCmdCF.Parameters.Add("@TEXT_01", SqlDbType.VarChar, 255);
                        SqlParameter tx2_id = oCmdCF.Parameters.Add("@TEXT_02", SqlDbType.VarChar, 255);
                        SqlParameter tx3_id = oCmdCF.Parameters.Add("@TEXT_03", SqlDbType.VarChar, 255);
                        SqlParameter tx4_id = oCmdCF.Parameters.Add("@TEXT_04", SqlDbType.VarChar, 255);
                        SqlParameter tx5_id = oCmdCF.Parameters.Add("@TEXT_05", SqlDbType.VarChar, 255);

                        SqlParameter self_id = oCmdCF.Parameters.Add("@SELECTED_FLAG", SqlDbType.Int);
                        SqlParameter rt_id = oCmdCF.Parameters.Add("@RT_UID", SqlDbType.Int);

                        foreach (DetailRowData oDet in m_detaildata.Values)
                        {
                            if (oDet.Scenario_ID == iVers)
                            {
                                ct_id.Value = oDet.CT_ID;
                                project_id.Value = oDet.PROJECT_ID;
                                bc_seq_id.Value = oDet.BC_SEQ;
                                bc_uid.Value = oDet.BC_UID;

                                oc1_id.Value = oDet.OCVal[1];
                                oc2_id.Value = oDet.OCVal[2];
                                oc3_id.Value = oDet.OCVal[3];
                                oc4_id.Value = oDet.OCVal[4];
                                oc5_id.Value = oDet.OCVal[5];

                                tx1_id.Value = oDet.TXVal[1];
                                tx2_id.Value = oDet.TXVal[2];
                                tx3_id.Value = oDet.TXVal[3];
                                tx4_id.Value = oDet.TXVal[4];
                                tx5_id.Value = oDet.TXVal[5];

                                self_id.Value = (oDet.bSelected ? 1 : 0);
                                rt_id.Value = oDet.m_rt;
                                oCmdCF.ExecuteNonQuery();


                            }
                        }

                    }

                    catch (Exception ex)
                    {
                        ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveVersion", (PortfolioEngineCore.StatusEnum)99822, ex.Message.ToString(), 0, "");
                    }

                    try
                    {


                        sCommand = "insert into EPGP_MODEL_DETAIL_VALUES (MODEL_UID,MODEL_VERSION_UID, CB_ID,CT_ID, PROJECT_ID, BC_UID, BC_SEQ, BD_PERIOD, BD_COST, BD_VALUE) " +
                                    "VALUES(" + m_sModel + "," + version + "," + m_CB_ID.ToString() + ",@CT_ID, @PROJECT_ID, @BC_UID, @BC_SEQ, @BD_PERIOD, @BD_COST, @BD_VALUE)";

                        SqlCommand oCmdVal = new SqlCommand(sCommand, oDataAccess);

                        SqlParameter val_ct_id = oCmdVal.Parameters.Add("@CT_ID", SqlDbType.Int);
                        SqlParameter val_project_id = oCmdVal.Parameters.Add("@PROJECT_ID", SqlDbType.Int);
                        SqlParameter val_bc_uid = oCmdVal.Parameters.Add("@BC_UID", SqlDbType.Int);
                        SqlParameter val_bc_seq_id = oCmdVal.Parameters.Add("@BC_SEQ", SqlDbType.Int);

                        SqlParameter val_per_id = oCmdVal.Parameters.Add("@BD_PERIOD", SqlDbType.Int);
                        SqlParameter val_cost_id = oCmdVal.Parameters.Add("@BD_COST", SqlDbType.Decimal);
                        SqlParameter val_val_id = oCmdVal.Parameters.Add("@BD_VALUE", SqlDbType.Decimal);
                        val_cost_id.Precision = 25;
                        val_cost_id.Scale = 6;
                        val_val_id.Precision = 25;
                        val_val_id.Scale = 6;

                        foreach (DetailRowData oDet in m_detaildata.Values)
                        {
                            if (oDet.Scenario_ID == iVers)
                            {
  
                                val_ct_id.Value = oDet.CT_ID;
                                val_project_id.Value = oDet.PROJECT_ID;
                                val_bc_uid.Value = oDet.BC_UID;
                                val_bc_seq_id.Value = oDet.BC_SEQ;

                                for (int xi = 1; xi <= m_max_period; xi++)
                                {
                                    if (oDet.zCost[xi] != 0 || oDet.zValue[xi] != 0)
                                    {

                                        val_per_id.Value = xi;
                                        val_cost_id.Value = oDet.zCost[xi];
                                        val_val_id.Value = oDet.zValue[xi];
                                        oCmdVal.ExecuteNonQuery();
                                    }
                                }

                            }
                        }

                    }

                    catch (Exception ex)
                    {
                        ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveVersion", (PortfolioEngineCore.StatusEnum)99822, ex.Message.ToString(), 0, "");
                    }


                }


                // m_oDataAccess = null;

                return 0;
            }
            catch (Exception)
            {
                return 1;
            }


        }

        public void GetPeriodsandVersions(ref PeriodsAndOptions poa)
        {
            poa.Periods = new ItemDefn[m_Periods.Count];


            int i = 0;

            foreach (PeriodData oPer in m_Periods.Values)
            {
                poa.Periods[i] = new ItemDefn();
                poa.Periods[i].Id = oPer.PeriodID;
                poa.Periods[i++].Name = oPer.PeriodName;
            }

            poa.displayStart = m_display_minp;
            poa.displayFinish = m_display_maxp;
            poa.dragStart = m_drag_minp;
            poa.dragFinish = m_drag_maxp;

            poa.showWhichQTY = (bShowFTEs ? 1 : 0);
            poa.showQTY = (bUseQTY ? 1 : 0);
            poa.showCosts = (bUseCosts ? 1 : 0);
            poa.showRHSDecCosts = (m_show_rhs_dec_costs ? 1 : 0);



        }


        public void SetPeriodsandVersions(PeriodsAndOptions poa)
        {
            m_display_minp = poa.displayStart;
            m_display_maxp = poa.displayFinish;
            m_drag_minp = poa.dragStart;
            m_drag_maxp = poa.dragFinish;

            bShowFTEs = (poa.showWhichQTY == 1);
            bUseQTY = (poa.showQTY == 1);
            bUseCosts = (poa.showCosts == 1);
            m_show_rhs_dec_costs = poa.showRHSDecCosts == 1;
            bottomgridlayoutcache = "";
            ApplyUserOptions();



        }

        public void DeleteTarget(SqlConnection oDataAccess, string sTarget)
        {
            string sCommand = "";

            try
            {
                //m_oDataAccess = oDataAccess;

                sCommand = "Delete FROM EPGP_MODEL_TARGETS  Where TARGET_ID = " + sTarget;
                SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                cmd.ExecuteNonQuery();

                sCommand = "Delete FROM EPGP_MODEL_TARGET_DETAILS  Where TARGET_ID = " + sTarget;
                cmd = new SqlCommand(sCommand, oDataAccess);
                cmd.ExecuteNonQuery();

                sCommand = "Delete FROM EPGP_MODEL_TARGET_VALUES  Where TARGET_ID = " + sTarget;
                cmd = new SqlCommand(sCommand, oDataAccess);
                cmd.ExecuteNonQuery();


                //m_oDataAccess = null;
                List<DataItem> newTargets = new List<DataItem>();

                int thisTar = int.Parse(sTarget);

                foreach (DataItem oi in m_Target)
                {
                    if (oi.UID != thisTar)
                        newTargets.Add(oi);

                }

                m_Target = newTargets;
            }

            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "DeleteTarget", (PortfolioEngineCore.StatusEnum)99821, ex.Message.ToString(), 0, "");
            }


        }

        private string PrepareText(string sText)
        {

            return "'" + sText.Replace("'", "''") + "'";
        }


        public int CreateTarget(SqlConnection oDataAccess, string sTargetName, string sTargetDesc, int localTarget, int lCopyfromTarget)
        {
            string sCommand = "";
            int ret = 0;

            try
            {
                //m_oDataAccess = oDataAccess;

                SqlCommand oCommand = null;
                SqlDataReader reader = null;
                int nameCount = 0;
                int targetID = 0;
                int LocalTarget = 0;

                sCommand = "SELECT COUNT(TARGET_NAME) AS TARGET_COUNT FROM EPGP_MODEL_TARGETS WHERE TARGET_NAME = " + PrepareText(sTargetName);

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    nameCount = DBAccess.ReadIntValue(reader["TARGET_COUNT"]);
                }
                reader.Close();
                reader = null;

                if (nameCount != 0)
                {
                    return -1;
                }

                sCommand = "SELECT MAX(TARGET_ID) AS TARGET_ID FROM EPGP_MODEL_TARGETS";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    targetID = DBAccess.ReadIntValue(reader["TARGET_ID"]);
                }
                reader.Close();
                reader = null;

                ++targetID;

                sCommand = "INSERT into EPGP_MODEL_TARGETS (CB_ID, TARGET_ID,WRES_ID,TARGET_NAME,TARGET_DESC) VALUES(" +
                   m_CB_ID.ToString() + ", " + targetID.ToString() + "," + LocalTarget.ToString() + "," + PrepareText(sTargetName) + "," + PrepareText(sTargetDesc) + ")";


                SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                cmd.ExecuteNonQuery();
                //m_oDataAccess = null;


                DataItem oi = new DataItem();

                oi.UID = targetID;
                oi.Name = sTargetName;
                oi.Desc = sTargetDesc;

                ret = targetID;



                m_Target.Add(oi);


                if (lCopyfromTarget != 0)
                {
                   sCommand = "INSERT INTO EPGP_MODEL_TARGET_VALUES (TARGET_ID, TARGET_UID, BD_PERIOD, BD_VALUE, BD_COST) (SELECT " + targetID.ToString() + 
                                 ",TARGET_UID, BD_PERIOD, BD_VALUE, BD_COST  FROM EPGP_MODEL_TARGET_VALUES WHERE TARGET_ID = " + lCopyfromTarget.ToString() + ")";

                   cmd = new SqlCommand(sCommand, oDataAccess);
                   cmd.ExecuteNonQuery();

                   sCommand = "INSERT INTO EPGP_MODEL_TARGET_DETAILS " +
                              "(TARGET_ID, TARGET_UID, CT_ID, BC_UID, OC_01, OC_02, OC_03, OC_04, OC_05, TEXT_01, TEXT_02, TEXT_03, TEXT_04, TEXT_05) " + 
                              " (SELECT " + targetID.ToString() +
                                  ",TARGET_UID, CT_ID, BC_UID, OC_01, OC_02, OC_03, OC_04, OC_05, TEXT_01, TEXT_02, TEXT_03, TEXT_04, TEXT_05 " +
                                  "  FROM EPGP_MODEL_TARGET_DETAILS WHERE TARGET_ID = " + lCopyfromTarget.ToString() + ")";


                   cmd = new SqlCommand(sCommand, oDataAccess);
                   cmd.ExecuteNonQuery();


                }
           }

            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "CreateTarget", (PortfolioEngineCore.StatusEnum)99820, ex.Message.ToString(), 0, "");
            }

            return ret;
        }

        private string BuildCatJSon(CSRatesAndCategory rdata, int index, int max)
        {
            CSCategoryEntry ce, ne, initial;
            string sRet = "";

            initial = rdata.Categories[index];

            for (int i = index; i <= max; i++)
            {

                ce = rdata.Categories[i];

                if (initial.Level == ce.Level)
                {

                    if (sRet != "")
                        sRet = sRet + ",";

                    sRet += "{Name:'" + ce.ID.ToString() + "',Text:'" + ce.Name + "',Value:'" + ce.UID.ToString() + "'}";


                    if (i != max)
                    {
                        ne = rdata.Categories[i + 1];

                        if (ne.Level > ce.Level)
                        {
                            sRet += ",{Name:'Level" + ce.ID.ToString() + "',Expanded:-1,Level:" + ce.Level.ToString() + ", Items:[ " + BuildCatJSon(rdata, i + 1, max) + "]}";
                            //"{Items:[{Name:'Name1',Text:'Text1',Value:'Value1'},{Name:'Level2',Expanded:-1,Level:1,Items:[ {Name:'Name1.1',Text:'Text1.1',Value:'Value1.1'}, {Name:'Name1.2',Text:'Text1.2',Value:'Value1.2'}]}]}"

                        }
                        else if (ne.Level < ce.Level)
                            return sRet;

                    }
                }
 

                //else if (index != 0)
                //    return sRet;
            }


            return sRet;



        }



        private string BuildCustFieldJSon(CustomFieldData oc, int index, int max)
        {
            ListItemData ce, ne, initial;
            string sRet = "";

            if (max < 0)
                return "";

            initial = oc.ListItems.ElementAt(index).Value;

            for (int i = index; i <= max; i++)
            {

                ce = oc.ListItems.ElementAt(i).Value;

                if (initial.Level == ce.Level)
                {

                    if (sRet != "")
                        sRet = sRet + ",";

                    if (oc.UseFullName == 1)
                        sRet += "{Name:'" + ce.ID.ToString() + "',Text:'" + ce.FullName + "',Value:'" + ce.UID.ToString() + "'}";
                    else
                        sRet += "{Name:'" + ce.ID.ToString() + "',Text:'" + ce.Name + "',Value:'" + ce.UID.ToString() + "'}";


                    if (i != max)
                    {
                        ne = oc.ListItems.ElementAt(i + 1).Value;

                        if (ne.Level > ce.Level)
                        {
                            sRet += ",{Name:'Level" + ce.ID.ToString() + "',Expanded:-1,Level:" + ce.Level.ToString() + ", Items:[ " + BuildCustFieldJSon(oc, i + 1, max) + "]}";
                            //"{Items:[{Name:'Name1',Text:'Text1',Value:'Value1'},{Name:'Level2',Expanded:-1,Level:1,Items:[ {Name:'Name1.1',Text:'Text1.1',Value:'Value1.1'}, {Name:'Name1.2',Text:'Text1.2',Value:'Value1.2'}]}]}"

                        }
                        else if (ne.Level < ce.Level)
                            return sRet;

                    }
                }
                //else if (index != 0)
                //    return sRet;
            }


            return sRet;



        }

        public void RatesAndCategory(ref CSRatesAndCategory rdata)
        {
            // targets do not have named rates Yet!

            CSCategoryEntry ce = null;
            ItemDefn ve = null;

            rdata.numberPeriods = m_Periods.Count;

            rdata.NamedRates = new CSNamedRate[0];
            //   rdata.NamedRates = new CSNamedRate[m_Rates.Count];
            rdata.Categories = new CSCategoryEntry[m_CostCat.Count];
            rdata.Versions = new ItemDefn[m_Scenario.Count];
            rdata.CostTypes = new ItemDefn[m_CostTypes.Count];
            rdata.CustomFields = new CustomFieldsDefn[m_CustFields.Count];

            int cnt = 0;


            string jsonMenu = "";





            //foreach (RateTable rt in m_Rates.Values)
            //{
            //    nr = new CSNamedRate();
            //    rdata.NamedRates[cnt] = nr;

            //    rdata.NamedRates[cnt].ID = rt.ID;
            //    rdata.NamedRates[cnt].UID = rt.UID;
            //    rdata.NamedRates[cnt].Level = rt.Level;
            //    rdata.NamedRates[cnt].Name = rt.Name;
            //    rdata.NamedRates[cnt++].Rates = rt.zRate;
            //}

            cnt = 0;
            foreach (CatItemData oCat in m_CostCat.Values)
            {

                ce = new CSCategoryEntry();
                rdata.Categories[cnt] = ce;

                rdata.Categories[cnt].ID = oCat.ID;
                rdata.Categories[cnt].UID = oCat.UID;
                rdata.Categories[cnt].Level = oCat.Level;
                rdata.Categories[cnt].Role_UID = oCat.Role_UID;
                rdata.Categories[cnt].MC_UID = oCat.MC_UID;
                rdata.Categories[cnt].Category = oCat.Category;


                rdata.Categories[cnt].Name = oCat.Name;
                rdata.Categories[cnt].UoM = oCat.UoM;
                rdata.Categories[cnt].FullName = oCat.FullName;
                rdata.Categories[cnt].MC_Val = oCat.MC_Val;
                rdata.Categories[cnt].Role_Name = oCat.Role_Name;

                rdata.Categories[cnt].Rates = oCat.Rates;

                rdata.Categories[cnt++].FTEConv = oCat.FTEConv;

            }

            jsonMenu = "{Items:[" + BuildCatJSon(rdata, 0, m_CostCat.Count - 1) + "]}";

            m_CostCatjsonMenu = jsonMenu;



            cnt = 0;

            foreach (DataItem oi in m_Scenario.Values)
            {
                ve = new ItemDefn();

                rdata.Versions[cnt] = ve;

                rdata.Versions[cnt].Id = oi.UID;
                rdata.Versions[cnt++].Name = oi.Name;

            }

            cnt = 0;

            foreach (DataItem oi in m_CostTypes.Values)
            {

                ve = new ItemDefn();

                rdata.CostTypes[cnt] = ve;

                rdata.CostTypes[cnt].Id = oi.UID;
                rdata.CostTypes[cnt++].Name = oi.Name;
            }

            jsonMenu = "{Name:'0',Text:'No Cost Type',Value:'0'}";
            for (cnt = 0; cnt < m_CostTypes.Count; cnt++)
            {
                jsonMenu += ",{Name:'" + rdata.CostTypes[cnt].Id.ToString() + "',Text:'" + rdata.CostTypes[cnt].Name + "',Value:'" + rdata.CostTypes[cnt].Id.ToString() + "'}";
            }


            jsonMenu = "{Items:[" + jsonMenu + "]}";



            m_CostTypejsonMenu = jsonMenu;


            cnt = 0;
            CustomFieldsDefn cfd;

            foreach (CustomFieldData oc in m_CustFields.Values)
            {
                cfd = new CustomFieldsDefn();

                rdata.CustomFields[cnt] = cfd;
                rdata.CustomFields[cnt].FieldID = oc.FieldID;

                rdata.CustomFields[cnt].Name = "z" + oc.Name;

                rdata.CustomFields[cnt].LookupOnly = oc.LookupOnly;
                rdata.CustomFields[cnt].LookupID = oc.LookupID;
                rdata.CustomFields[cnt].LeafOnly = oc.LeafOnly;
                rdata.CustomFields[cnt].UseFullName = oc.UseFullName;

                rdata.CustomFields[cnt].jsonMenu = "";


                rdata.CustomFields[cnt].LookUp = new ListItemData[oc.ListItems.Count];

                int xcnt = 0;

                foreach (ListItemData oi in oc.ListItems.Values)
                {
                    ListItemData oicopy = new ListItemData();

                    rdata.CustomFields[cnt].LookUp[xcnt++] = oicopy;

                    oicopy.ID = oi.ID;
                    oicopy.UID = oi.UID;
                    oicopy.Level = oi.Level;


                    oicopy.Name = oi.Name;
                    oicopy.FullName = oi.FullName;
                    oicopy.InActive = oi.InActive;

                }

                if (oc.ListItems.Count > 0)
                    rdata.CustomFields[cnt].jsonMenu = "{Items:[" + BuildCustFieldJSon(oc, 0, oc.ListItems.Count - 1) + "]}";



                oc.jsonMenu = rdata.CustomFields[cnt].jsonMenu;
                cnt++;

            }

        }

        public void PrepareTargetData(SqlConnection oDataAccess, int targetID, ref CSTargetData targetData)
        {

            try
            {
                CatItemData oCat;
                DataItem oItem;
                //m_oDataAccess = oDataAccess;

                LoadTargets(oDataAccess, targetID.ToString());

                m_editTargetList = new List<DetailRowData>();

                foreach (DetailRowData oDet in m_targetdata.Values)
                {

                    if (oDet.Scenario_ID == targetID)
                    {
                        if (m_CostCat.TryGetValue(oDet.BC_UID, out oCat))
                        {
                            oDet.Cat_Name = oCat.Name;
                            oDet.FullCatName = oCat.FullName;
                            oDet.MC_Name = oCat.MC_Val;
                            oDet.Role_Name = oCat.Role_Name;
                            oDet.sUoM = oCat.UoM;

                            if (m_CostCat.TryGetValue(oCat.Category, out oCat))
                            {
                                oDet.CC_Name = oCat.Name;
                                oDet.FullCCName = oCat.FullName;
                            }
                        }


                        if (m_CostTypes.TryGetValue(oDet.CT_ID, out oItem))
                            oDet.CT_Name = oItem.Name;
                        else
                            oDet.CT_Name = "";

                        RateTable ort;

                        if (m_Rates.TryGetValue(oDet.m_rt, out ort))
                            oDet.m_rt_name = ort.Name;
                        else
                            oDet.m_rt_name = "";

                        int tempj;

                        for (int i = 1; i <= 5; i++)
                        {
                            string stxt;
                            tempj = oDet.OCVal[i];
                            stxt = GetLookUpString(i, ref tempj);
                            oDet.OCVal[i] = tempj;
                            oDet.Text_OCVal[i] = stxt;
                        }




                        m_editTargetList.Add(oDet);


                    }
                }


                targetData.targetRows = new TargetRowData[m_editTargetList.Count];

                int cnt = 0;

                foreach (DetailRowData oDet in m_editTargetList)
                {
                    targetData.targetRows[cnt] = new TargetRowData();
                    oDet.CopyToTargetData(ref targetData.targetRows[cnt++]);
                }

            }

            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "PrepareTargetData", (PortfolioEngineCore.StatusEnum)99819, ex.Message.ToString(), 0, "");
            }

            //m_oDataAccess = null;


        }



        public void LoadVersionTargetData(SqlConnection oDataAccess, int VersID, ref CSTargetData targetData)
        {
            // m_oDataAccess = oDataAccess;
            foreach (DataItem oi in m_Scenario.Values)
            {
                if (oi.UID == VersID)
                {
                    if (oi.bLoaded == false)
                        LoadScenarios(oDataAccess, VersID.ToString(), false, false);

                    break;
                }
            }

            int cnt = 0;
            string sKey = "";
            string presKey = ""; 

            Dictionary<string, string> preaggr = new Dictionary<string, string>();

            foreach (DetailRowData odet in m_detaildata.Values)
            {
                if (odet.Scenario_ID == VersID)
                {
                    sKey = BuildTargetKey(odet);

                    if (preaggr.TryGetValue(sKey, out presKey) == false)
                    {
                        ++cnt;
                        preaggr.Add(sKey, sKey);
                    }
                }
            }

            targetData.targetRows = new TargetRowData[cnt];

            Dictionary<string, TargetRowData> aggr = new Dictionary<string, TargetRowData>();

            cnt = 0;
            TargetRowData tdata = null; 

            foreach (DetailRowData odet in m_detaildata.Values)
            {
                if (odet.Scenario_ID == VersID)
                {
                    sKey = BuildTargetKey(odet);

                    if (aggr.TryGetValue(sKey, out tdata) == false)
                    {
                        tdata = new TargetRowData();
                        targetData.targetRows[cnt++] = tdata;
                        odet.CopyToTargetData(ref tdata);
                        aggr.Add(sKey, tdata);
                    }
                    else
                        odet.AddToTargetData(ref tdata);
                }
            }

            // m_oDataAccess = null;

        }

         private string BuildTargetKey(DetailRowData odet) 
         {
            string sKey = "";
      
            sKey = odet.CT_ID.ToString() + " " + odet.BC_UID.ToString();

             for (int i = 1; i <= 5; i++)
                sKey +=  " " + odet.OCVal[i].ToString();
            
             for (int i = 1; i <= 5; i++)
                sKey +=  " <" + odet.TXVal[i] + ">";

             return sKey;
         }
   
      

        public String GetTargetGridLayout()
        {
            TargetGridLayout oGrid = new TargetGridLayout();
            oGrid.InitializeGridLayout(bShowFTEs, m_CustFields, m_Rates.Count, m_CostTypejsonMenu, m_CostCatjsonMenu, m_filter_sel[(int) FieldIDs.MC_FID].Count);

            int i = 0;

            foreach (PeriodData period in m_Periods.Values)
            {
                ++i;

                oGrid.AddPeriodColumn(i.ToString(), period.PeriodName, bShowFTEs);
            }

            oGrid.FinalizeGridLayout();

            string s = oGrid.GetString();
            return s;
        }

        public String GetTargetGridData()
        {

            TargetGridsData oGrid = new TargetGridsData();
            oGrid.InitializeGridData();
            int i = 0;

            foreach (DetailRowData oDet in m_editTargetList)
            {
                oGrid.AddDetailRow(oDet, ++i, bShowFTEs, m_Periods.Count, m_CustFields, m_Rates.Count);
            }

            string s = oGrid.GetString();

            return s;

        }

        public void SaveTargetData(SqlConnection oDataAccess, int TargetID, CSTargetData targetData)
        {
            //m_oDataAccess = oDataAccess;
            string sCommand = "";
            int lRowsAffected = 0;

            try
            {
                sCommand = "DELETE FROM EPGP_MODEL_TARGET_VALUES WHERE TARGET_ID = " + TargetID.ToString();
                SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveTargetData", (PortfolioEngineCore.StatusEnum)99818, ex.Message.ToString(), 0, "");
            }


            try
            {
                sCommand = "DELETE FROM EPGP_MODEL_TARGET_DETAILS WHERE TARGET_ID = " + TargetID.ToString();
                SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveTargetData", (PortfolioEngineCore.StatusEnum)99817, ex.Message.ToString(), 0, "");
            }

            try
            {
                sCommand = "insert into EPGP_MODEL_TARGET_DETAILS (TARGET_ID,CT_ID, BC_UID, TARGET_UID, OC_01,OC_02, OC_03, OC_04, OC_05,TEXT_01,TEXT_02, TEXT_03, TEXT_04, TEXT_05) " +
                            "VALUES(" + TargetID.ToString() + ",@CT_ID, @BC_UID, @TARGET_UID, @OC_01,@OC_02, @OC_03, @OC_04, @OC_05,@TEXT_01,@TEXT_02, @TEXT_03, @TEXT_04, @TEXT_05)";

                SqlCommand oCmdCF = new SqlCommand(sCommand, oDataAccess);

                SqlParameter ct_id = oCmdCF.Parameters.Add("@CT_ID", SqlDbType.Int);
                SqlParameter bc_uid = oCmdCF.Parameters.Add("@BC_UID", SqlDbType.Int);
                SqlParameter tar_uid = oCmdCF.Parameters.Add("@TARGET_UID", SqlDbType.Int);

                SqlParameter oc1_id = oCmdCF.Parameters.Add("@OC_01", SqlDbType.Int);
                SqlParameter oc2_id = oCmdCF.Parameters.Add("@OC_02", SqlDbType.Int);
                SqlParameter oc3_id = oCmdCF.Parameters.Add("@OC_03", SqlDbType.Int);
                SqlParameter oc4_id = oCmdCF.Parameters.Add("@OC_04", SqlDbType.Int);
                SqlParameter oc5_id = oCmdCF.Parameters.Add("@OC_05", SqlDbType.Int);

                SqlParameter tx1_id = oCmdCF.Parameters.Add("@TEXT_01", SqlDbType.VarChar, 255);
                SqlParameter tx2_id = oCmdCF.Parameters.Add("@TEXT_02", SqlDbType.VarChar, 255);
                SqlParameter tx3_id = oCmdCF.Parameters.Add("@TEXT_03", SqlDbType.VarChar, 255);
                SqlParameter tx4_id = oCmdCF.Parameters.Add("@TEXT_04", SqlDbType.VarChar, 255);
                SqlParameter tx5_id = oCmdCF.Parameters.Add("@TEXT_05", SqlDbType.VarChar, 255);

                sCommand = "insert into EPGP_MODEL_TARGET_VALUES (TARGET_ID,TARGET_UID, BD_PERIOD, BD_COST, BD_VALUE) " +
                           "VALUES(" + TargetID.ToString() + ",@TARGET_UID, @BD_PERIOD, @BD_COST, @BD_VALUE)";

                SqlCommand oCmdVal = new SqlCommand(sCommand, oDataAccess);
                SqlParameter val_tar_uid = oCmdVal.Parameters.Add("@TARGET_UID", SqlDbType.Int);

                SqlParameter val_per_id = oCmdVal.Parameters.Add("@BD_PERIOD", SqlDbType.Int);
                SqlParameter val_cost_id = oCmdVal.Parameters.Add("@BD_COST", SqlDbType.Decimal );
                SqlParameter val_val_id = oCmdVal.Parameters.Add("@BD_VALUE", SqlDbType.Decimal);
                val_cost_id.Precision = 25;
                val_cost_id.Scale = 6;
                val_val_id.Precision = 25;
                val_val_id.Scale = 6;


                TargetRowData oTar = null;

                for (int i = 0; i < targetData.targetRows.Length; i++)
                {
                    oTar = targetData.targetRows[i];

                    if (oTar.bGroupRow == false)
                    {
                        ct_id.Value = oTar.CT_ID;
                        tar_uid.Value = i + 1;
                        bc_uid.Value = oTar.BC_UID;

                        oc1_id.Value = oTar.OCVal[1];
                        oc2_id.Value = oTar.OCVal[2];
                        oc3_id.Value = oTar.OCVal[3];
                        oc4_id.Value = oTar.OCVal[4];
                        oc5_id.Value = oTar.OCVal[5];

                        tx1_id.Value = oTar.TXVal[1];
                        tx2_id.Value = oTar.TXVal[2];
                        tx3_id.Value = oTar.TXVal[3];
                        tx4_id.Value = oTar.TXVal[4];
                        tx5_id.Value = oTar.TXVal[5];

                        oCmdCF.ExecuteNonQuery();


                        val_tar_uid.Value = i + 1;

                        for (int xi = 1; xi <= m_max_period; xi++)
                        {
                            if (oTar.zCost[xi] != 0 || oTar.zValue[xi] != 0)
                            {

                                val_per_id.Value = xi;
                                val_cost_id.Value = oTar.zCost[xi];
                                val_val_id.Value = oTar.zValue[xi];
                                oCmdVal.ExecuteNonQuery();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveTargetData", (PortfolioEngineCore.StatusEnum)99816, ex.Message.ToString(), 0, "");
            }
            //m_oDataAccess = null;
        }

        public void SetShowRemainingFlag(bool bVal)
        {
            m_ShowRemaining = bVal;
        }

        public string GetLegendGridLayout()
        {
            TargetLegendGridLayout xg = new TargetLegendGridLayout();

            xg.InitializeGridLayout();

            return xg.GetString();
        }

        public string GetLegendGridData()
        {
            TargetLegendGridData xg = new TargetLegendGridData();
            int rgb;
            string sRGB = "";

            xg.InitializeGridData();

            foreach (TargetColours otar in m_TargetColours)
            {

                rgb = otar.rgb_val;

                if (rgb == -1)
                    sRGB = "";
                else
                    sRGB = "RGB(" + (rgb & 0xFF).ToString() + "," + ((rgb & 0xFF00) >> 8).ToString() + "," + ((rgb & 0xFF0000) >> 16).ToString() + ")";

                xg.AddRow(otar.Desc, sRGB);

            }



            return xg.GetString();
        }


        public List<ItemDefn> LoadUserViewData()
        {
            List<ItemDefn> retval = new List<ItemDefn>();
            ItemDefn oi = null;

            foreach (DataItem od in m_CT_Views)
            {
                oi = new ItemDefn();

                oi.Id = od.ID;
                oi.Name = od.Name;
                oi.Deflt = od.UID;

                retval.Add(oi);
            }

            return retval;
        }

        public void DeleteUserViewData(SqlConnection oDataAccess, string sviewName, int localflag)
        {
            //m_oDataAccess = oDataAccess;
            string sCommand = "";
            int lRowsAffected = 0;

            string slocResID = (localflag == 1 ? m_WResID : "0");

            try
            {
                sCommand = "DELETE FROM EPG_CT_VIEWS WHERE (WRES_ID = " + slocResID + ") AND UINF_CONTEXT = " + m_mode.ToString() + " AND VIEW_NAME = " + PrepareText(sviewName);
                SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "DeleteUserViewData", (PortfolioEngineCore.StatusEnum)99815, ex.Message.ToString(), 0, "");
            }

            LoadUserViews(oDataAccess);

            //m_oDataAccess = null;
        }

        public void RenameUserViewData(SqlConnection oDataAccess, string snewName, string sviewName, int localflag)
        {
            //m_oDataAccess = oDataAccess;
            string sCommand = "";
            int lRowsAffected = 0;

            string slocResID = (localflag == 1 ? m_WResID : "0");

            try
            {
                sCommand = "UPDATE EPG_CT_VIEWS SET VIEW_NAME = " + PrepareText(snewName) +  " WHERE (WRES_ID = " + slocResID + ") AND UINF_CONTEXT = " + m_mode.ToString() + " AND VIEW_NAME = " + PrepareText(sviewName);
                SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "RenameUserViewData", (PortfolioEngineCore.StatusEnum)99999, ex.Message.ToString(), 0, "");
            }

            LoadUserViews(oDataAccess);

            //m_oDataAccess = null;
        }

        public void SaveUserViewData(SqlConnection oDataAccess, string sviewName, int localflag, string sZoomTo)
        {
            //m_oDataAccess = oDataAccess;
            string sCommand = "";
            int lRowsAffected = 0;

            string slocResID = ((localflag & 1) == 1 ? m_WResID : "0");
            string sDefView = ((localflag >= 2) ? "1" : "0");

            try
            {
                sCommand = "DELETE FROM EPG_CT_VIEWS WHERE (WRES_ID = " + slocResID + ") AND UINF_CONTEXT = " + m_mode.ToString() + " AND VIEW_NAME = " + PrepareText(sviewName);
                SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveUserViewData", (PortfolioEngineCore.StatusEnum)99814, ex.Message.ToString(), 0, "");
            }



            try
            {
                sCommand = "INSERT INTO EPG_CT_VIEWS (WRES_ID, UINF_CONTEXT, VIEW_NAME, VIEW_DEFN) " +
                            "  VALUES(" + slocResID + " , " + m_mode.ToString() + " , " + PrepareText(sviewName) + "," + PrepareText(GetUserViewSlug(sZoomTo)) + ")";

                SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelErrorHandling.HandleStatusError(oDataAccess, PortfolioEngineCore.SeverityEnum.Exception, "SaveUserViewData", (PortfolioEngineCore.StatusEnum)99813, ex.Message.ToString(), 0, "");
            }

            try
            {
                sCommand = "UPDATE EPG_CT_VIEWS SET VIEW_DEFAULT = " + sDefView + " WHERE (WRES_ID = " + slocResID + ") AND UINF_CONTEXT = " + m_mode.ToString() + " AND VIEW_NAME = " + PrepareText(sviewName);

                SqlCommand cmd = new SqlCommand(sCommand, oDataAccess);
                lRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
 //               ModelErrorHandling.HandleStatusError(oDataAccess, SeverityEnum.Exception, "SaveUserViewData", (StatusEnum)99813, ex.Message.ToString(), 0, "");
                // hey ho they should have run the script01 - but carry on regardless
            }



            LoadUserViews(oDataAccess);

            //m_oDataAccess = null;
        }

        private string GetUserViewSlug(string sZoomTo)
        {

            CStruct xSlug = new CStruct();

            xSlug.Initialize("Slug");

            List<string> tmp = new List<string>();

            string sall = "";
            string stot = "";
            string sfid = "";
            DataItem oPar = null;


            xSlug.CreateString("ZoomTo", sZoomTo);

            foreach (DataItem oi in m_filterList)
            {
                if (oi.level == 1)
                {
                    if (sfid != "")
                        tmp.Add(sfid + sall + stot);

                    oi.bAllSelected = true;
                    oPar = oi;

                    stot = " 0";
                    foreach (DataItem oit in m_TotalRoot)
                    {
                        if (oit.UID == oi.group && oit.bSelected)
                        {
                            stot = " 1";
                            break;
                        }
                    }


                    sfid = oi.group.ToString();

                    sall = " 1";
                }
                else if (oi.bSelected == false)
                {
                    if (oPar != null)
                        oPar.bAllSelected = false;

                    sall = " 0";
                }

            }

            tmp.Add(sfid + sall + stot);

            foreach (string s in tmp)
            {

                xSlug.CreateString("FFID", s);
            }

            bool bDoThisFilter = false;

            stot = "";
            oPar = null;

            foreach (DataItem oi in m_filterList)
            {
                if (oi.level == 1)
                {

                    oPar = oi;
                    if (stot != "")
                        xSlug.CreateString("FFIDVal", sfid + stot);


                    sfid = oi.group.ToString();
                    stot = "";

                    if (oi.bAllSelected == true)
                        bDoThisFilter = false;
                    else if (oi.group == (int)FieldIDs.SCEN_FID)
                        bDoThisFilter = false;
                    else
                        bDoThisFilter = true;
                }
                else if (bDoThisFilter == true)
                {
                    if (oi.bSelected == true && oPar != null)
                    {
                        if (oPar.group <= 11810 && oPar.group != (int)FieldIDs.MC_FID)
                            stot += " " + oi.UID.ToString();
                        else
                            stot += " " + oi.Name;

                    }
                }

            }

            if (stot != "")
                xSlug.CreateString("FFIDVal", sfid + stot);

            stot = (bUseQTY ? "1" : "0");
            stot += (bShowFTEs == false ? " 1" : " 0");
            stot += (bUseCosts ? " 1" : " 0");


            stot += " " + m_display_minp.ToString() + " " + m_display_maxp.ToString();
            stot += " " + m_drag_minp.ToString() + " " + m_drag_maxp.ToString();

            xSlug.CreateString("QTY", stot);
            xSlug.CreateString("SHWDEC", (m_show_rhs_dec_costs ? "1" : "0"));
            xSlug.CreateString("LABDESC", "0");
            xSlug.CreateString("GWID", "-1");
            xSlug.CreateString("BGWID", "-1");



            foreach (SortFieldDefn sng in m_DetColRoot)
            {
                xSlug.CreateString("DR", sng.fid.ToString() + (sng.selected == 0 ? " 1" : " 0") + " -1");
            }

            foreach (SortFieldDefn sng in m_TotColRoot)
            {
                xSlug.CreateString("TR", sng.fid.ToString() + (sng.selected == 0 ? " 1" : " 0") + " -1");
            }

            xSlug.CreateString("FRZ", m_DetFreeze.ToString() + " " + m_TotFreeze.ToString());

            stot = m_detShowToLevel.ToString() + " " + m_totShowToLevel.ToString();

            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    stot += " " + m_SnGFids[i, j].ToString() + " " + m_SnGAsc[i, j].ToString() + " " + m_SnGGrp[i, j].ToString();
                }
            }

            xSlug.CreateString("SNG", stot);
            xSlug.CreateString("APVIEW", (m_bCTAMode ? "0" : m_apply_target.ToString()));
            xSlug.CreateString("DGRP", (m_grouping_enabled ? "1" : "0"));

            if (m_bCTAMode)
            {


                foreach (DataItem oi in m_CTARoot)
                {
                    if (oi.bSelected == true)
                        xSlug.CreateString("CTCmp", oi.UID.ToString());
                }
                if (m_apply_target == 1)
                    xSlug.CreateString("CTApCmp", "1");

            }
            return xSlug.XML();
        }

        private void LoadUserViews(SqlConnection oDataAccess)
        {

            string sCommand = "";
            SqlCommand oCommand = null;
            DataItem oItem = null;
            SqlDataReader reader = null;

            m_CT_Views = new List<DataItem>();
            List<DataItem> ringfence = new List<DataItem>();

            sCommand = "SELECT *  FROM EPG_CT_VIEWS WHERE (WRES_ID = 0 OR  WRES_ID= " + m_WResID + ") AND UINF_CONTEXT = " + m_mode.ToString();
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                oItem = new DataItem();

                oItem.Name = DBAccess.ReadStringValue(reader["VIEW_NAME"]);
                oItem.Desc = DBAccess.ReadStringValue(reader["VIEW_DEFN"]);
                oItem.ID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                oItem.UID = 0;

                m_CT_Views.Add(oItem);

            }
            reader.Close();

            reader = null;

            try
            {
                sCommand = "SELECT *  FROM EPG_CT_VIEWS WHERE (WRES_ID = 0 OR  WRES_ID= " + m_WResID + ") AND UINF_CONTEXT = " + m_mode.ToString();
                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oItem = new DataItem();

                    oItem.Name = DBAccess.ReadStringValue(reader["VIEW_NAME"]);
                    oItem.Desc = DBAccess.ReadStringValue(reader["VIEW_DEFN"]);
                    oItem.ID = DBAccess.ReadIntValue(reader["WRES_ID"]);
                    oItem.UID = DBAccess.ReadIntValue(reader["VIEW_DEFAULT"]);

                    ringfence.Add(oItem);

                }
                reader.Close();
                reader = null;
                m_CT_Views = ringfence;

            }
            catch(Exception ex)
            {
                
            }
        }

        public string SelectUserViewData(SqlConnection oDataAccess, int viewID)
        {
            //m_oDataAccess = oDataAccess;
            DataItem oItem = null;
            string slug = "";
            int fid = 0;
            int fall = 0;
            int ftot = 0;
            bool bDoit = false;
            string slook = "";

            if (viewID == -1)
                return "";

            List<SortFieldDefn> new_DetColRoot = new List<SortFieldDefn>();
            List<SortFieldDefn> new_TotColRoot = new List<SortFieldDefn>();

            oItem = m_CT_Views.ElementAt(viewID);

            slug = oItem.Desc;

            CStruct xSlug = new CStruct();

            //  XmlNode oNode = null;

            xSlug.LoadXML(slug);

            //  oNode = xSlug.GetXMLNode();    Why has Rob made this a protected item - makes parsing xml a bit hard - so had to add a new method to build a list of all the nodes child nodes

            List<CStruct> cln = xSlug.GetChildNodeCollection();

            if (m_bCTAMode)
            {
                foreach (DataItem oi in m_CTARoot)
                {
                    oi.bSelected = false;
                }
            }

            // mark if the fields have not been touched 

            foreach (SortFieldDefn sng in m_DetColRoot)
            {
                sng.touched = false;
            }

            foreach (SortFieldDefn sng in m_TotColRoot)
            {
                sng.touched = false;
            }


            string sZoomTo = "";

            foreach (CStruct odata in cln)
            {
                slug = odata.GetString("");

                switch (odata.Name)
                {

                    case "ZoomTo":
                        sZoomTo = slug;
                        break;

                    case "FFID":

                        fid = StripNum(ref slug);
                        fall = StripNum(ref slug);
                        ftot = StripNum(ref slug);

                        if (fid != (int) FieldIDs.SCEN_FID)
                        {

                            foreach (DataItem oit in m_TotalRoot)
                            {
                                if (oit.UID == fid)
                                {
                                    oit.bSelected = (ftot == 1);
                                    break;
                                }
                            }

                            bDoit = false;

                            foreach (DataItem oi in m_filterList)
                            {
                                if (oi.level == 1)
                                {
                                    if (oi.group == fid)
                                    {
                                        bDoit = true;
                                        oi.bAllSelected = (fall == 1);
                                    }
                                    else if (bDoit == true)
                                        break;
                                }
                                else if (bDoit == true)
                                    oi.bSelected = (fall == 1);
                            }
                        }
                        break;

                    case "FFIDVal":
                        fid = StripNum(ref slug);
                        slug = " " + slug + " ";

                        bDoit = false;

                        foreach (DataItem oi in m_filterList)
                        {
                            if (oi.level == 1)
                            {
                                if (oi.group == fid)
                                {
                                    bDoit = true;
                                }
                                else if (bDoit == true)
                                    break;
                            }
                            else if (bDoit == true)
                            {
                                if (fid <= 11810 && fid != (int)FieldIDs.MC_FID)
                                    slook = " " + oi.UID.ToString() + " ";
                                else
                                    slook = " " + oi.Name + " ";

                                oi.bSelected = (slug.IndexOf(slook) != -1);
                            }
                        }
                        break;

                    case "QTY":
                        bUseQTY = (StripNum(ref slug) != 0);
                        bShowFTEs = (StripNum(ref slug) == 0);
                        bUseCosts = (StripNum(ref slug) != 0);

                        fid = StripNum(ref slug);

                        // basically let the project dates control the first and last periods from now IF this is the Cost Analyzer

                        if (m_bCTAMode == false)
                        {

                            if (fid > 0 && fid <= m_max_period)
                                m_display_minp = fid;

                            fid = StripNum(ref slug);
                            if (fid > 0 && fid <= m_max_period)
                                m_display_maxp = fid;

                            fid = StripNum(ref slug);
                            if (fid > 0 && fid <= m_max_period)
                                m_drag_minp = fid;

                            fid = StripNum(ref slug);
                            if (fid > 0 && fid <= m_max_period)
                                m_drag_maxp = fid;
                        }

                        break;

                    case "SHWDEC":
                        m_show_rhs_dec_costs = (StripNum(ref slug) != 0);
                        break;

                    case "LABDESC":
                    case "GWID":
                    case "BGWID":
                        break;

                    case "DR":
                        fid = StripNum(ref slug);
                        fall = StripNum(ref slug);

                        foreach (SortFieldDefn sng in m_DetColRoot)
                        {
                            if (sng.fid == fid)
                            {
                                sng.selected = (fall == 0 ? 1 : 0);
                                sng.touched = true;
                                new_DetColRoot.Add(sng);
                                break;
                            }
                        }

                        break;

                    case "TR":
                        fid = StripNum(ref slug);
                        fall = StripNum(ref slug);

                        foreach (SortFieldDefn sng in m_TotColRoot)
                        {
                            if (sng.fid == fid)
                            {
                                sng.selected = (fall == 0 ? 1 : 0);
                                new_TotColRoot.Add(sng);
                                sng.touched = true;
                                break;
                            }
                        }

                        break;


                    case "FRZ":
                        m_DetFreeze = StripNum(ref slug);
                        m_TotFreeze = StripNum(ref slug);
                        break;

                    case "SNG":

                        m_detShowToLevel = StripNum(ref slug);
                        m_totShowToLevel = StripNum(ref slug);

                        for (int i = 0; i <= 1; i++)
                        {
                            for (int j = 0; j <= 2; j++)
                            {
                                m_SnGFids[i, j] = StripNum(ref slug);
                                m_SnGAsc[i, j] = StripNum(ref slug);
                                m_SnGGrp[i, j] = StripNum(ref slug);
                            }
                        }

                        break;

                    case "APVIEW":
                        m_apply_target = StripNum(ref slug);
                        break;

                    case "DGRP":
                        m_grouping_enabled = (StripNum(ref slug) != 0);
                        break;

                    case "CTCmp":
                        fid = StripNum(ref slug);

                        foreach (DataItem oi in m_CTARoot)
                        {
                            if (oi.UID == fid)
                                oi.bSelected = true;
                        }
                        break;

                    case "CTApCmp":
                        foreach (DataItem oi in m_CTARoot)
                        {
                            if (oi.bSelected)
                                m_apply_target = 1;
                        }
                        break;

                }


            }


            foreach (SortFieldDefn sng in m_DetColRoot)
            {
                if (sng.touched == false)
                    new_DetColRoot.Add(sng);

            }

            foreach (SortFieldDefn sng in m_TotColRoot)
            {
                if (sng.touched == false)
                    new_TotColRoot.Add(sng);
            }

            m_DetColRoot = new_DetColRoot;
            m_TotColRoot = new_TotColRoot;

            SetTotColsbasedonTotaling();


            bottomgridlayoutcache = "";

            ApplyUserOptions();

            SetHighlevelFilterFlag();







            //m_oDataAccess = null;

            slug = sZoomTo;



            return slug;
        }

        public string GetCmpString()
        {
            return m_tarnames;
        }



    }


}

