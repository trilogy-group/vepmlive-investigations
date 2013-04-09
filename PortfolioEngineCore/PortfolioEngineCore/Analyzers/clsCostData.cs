using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using PortfolioEngineCore;
using System.Globalization;


namespace CostDataValues
{
    public enum cdFieldIDs : int
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
    [Serializable()]
    public class clsPeriodData
    {
        public string PeriodName;
        public int PeriodID;
        public DateTime StartDate;
        public DateTime FinishDate;
    };
    [Serializable()]
    public class clsCatItemData
    {
        public int UID, ID, Level, Role_UID, Mode, PID, MC_UID, Category;
        public string Name, UoM, FullName, MC_Val, Role_Name;
        public double[] Rates, FTEConv;

        public clsCatItemData(int arraysize)
        {

            Rates = new double[arraysize + 1];
            FTEConv = new double[arraysize + 1];

            for (int i = 0; i <= arraysize; i++)
            {
                Rates[i] = 0;
                FTEConv[i] = 0;
            }
        }

    }
    [Serializable()]
    public class clsListItemData
    {
        public int UID, ID, Level;
        public string Name, FullName;
        public bool InActive;
    }
    [Serializable()]
    public class clsPortFieldData
    {
        public int ID, Editable, Required, Identity, Visible, Frozen, Sequence;
        public string Name, GivenName;
    }
    [Serializable()]
    public class clsCustomFieldData
    {
        public int FieldID;
        public string Name;
        public string DisplayName;
        public int LookupOnly, LookupID, LeafOnly, UseFullName;
        public Dictionary<int, clsListItemData> ListItems;
        public string jsonMenu;
    }
    [Serializable()]
    public class clsDataItem
    {
        public string Name = "";
        public string Desc = "";
        public int UID = 0;
        public int ID = 0;
        public bool bEditiable = false;
        public bool bSelected = true;
    };
    [Serializable()]
    public class clsPIData : IComparable<clsPIData>
    {
        public int PI_ID, ScenarioID, Internal_ID, PISelected, GroupingPosn;
        public DateTime StartDate, FinishDate, oStartDate, oFinishDate;
        public string PI_Name, Scenario_name, GroupingID;
        public string[] m_PI_Extra_data;
        public string[] m_PI_Format_Extra_data;

        public int CompareTo(clsPIData rhs)
        {
            return this.PI_Name.CompareTo(rhs.PI_Name);
        }


        public clsPIData(int arraysize)
        {
            m_PI_Extra_data = new string[arraysize + 1];
            m_PI_Format_Extra_data = new string[arraysize + 1];
            Scenario_name = "";
            GroupingID = "";

        }
    }
    [Serializable()]
    public class clsTargetRowData
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
    public class clsDetailRowData
    {
        public int CB_ID;
        public int CT_ID;
        public int CT_ind;
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
        public bool bFiltered;

        public int m_uid;
        public int m_total_to;

        public int rowid;
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

        public clsDetailRowData(int arraysize)
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
            bFiltered = false;

            mxdim = arraysize;
            zCost = new double[arraysize + 1];
            zValue = new double[arraysize + 1];
            zFTE = new double[arraysize + 1];
            oCosts = new double[arraysize + 1];
            oUnits = new double[arraysize + 1];
            oFTE = new double[arraysize + 1];
            for (int i = 0; i <= mxdim; i++)
            {
                zCost[i] = 0;
                zValue[i] = 0;
                zFTE[i] = 0;
                oCosts[i] = 0;
                oUnits[i] = 0;
                oFTE[i] = 0;
            }

            BurnDuration = new int[arraysize + 1];
            Burnrate = new double[arraysize + 1];
            UseBurnrate = new double[arraysize + 1];
            OutsideAdj = new double[arraysize + 1];
            Budget = new double[arraysize + 1];

            OCVal = new int[6];
            Text_OCVal = new string[6];
            TXVal = new string[6];
        }

        public void CopyData(clsDetailRowData src)
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
        public void CopyToTargetData(ref clsTargetRowData dest)
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

        public void AddToTargetData(ref clsTargetRowData dest)
        {

            for (int i = 1; i <= mxdim; i++)
            {

                dest.zCost[i] += zCost[i];
                dest.zValue[i] += zValue[i];
                dest.zFTE[i] += zFTE[i];

            }

        }

        public void CaputureInitialData(Dictionary<int, clsPeriodData> clnPer)
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

        public void RestoreInitialData(Dictionary<int, clsPeriodData> clnPer)
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

        private void CaptureBurnRates(Dictionary<int, clsPeriodData> clnPer)
        {
            int i = 0;
            int lPerSpan = 0;

            foreach (clsPeriodData oPer in clnPer.Values)
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
    public class clsTargetColours
    {
        public int ID, rgb_val;
        public double low_val, high_val;
        public string Desc;
    }
    [Serializable()]
    public class clsRateTable
    {
        public int UID, ID, Level;
        public string Name;
        public double[] zRate;
        private int mxdim;

        public clsRateTable(int arraysize)
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
    public class clsRateFTECache
    {
        public double[] zRate, zFTE;
        private int mxdim;

        public clsRateFTECache(int arraysize)
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
    public  class clsCostData
    {

        public const int EPK_FTYPE_DATE = 1;
        public const int EPK_FTYPE_INTEGER = 2;
        public const int EPK_FTYPE_NUMBER = 3;
        public const int EPK_FTYPE_CODE = 4;
        public const int EPK_FTYPE_URL = 6;
        public const int EPK_FTYPE_RES = 7;
        public const int EPK_FTYPE_CURRENCY = 8;
        public const int EPK_FTYPE_TEXT = 9;
        public const int EPK_FTYPE_PERCENT = 11;
        public const int EPK_FTYPE_YESNO = 13;
        public const int EPK_FTYPE_RTF = 19;
        public const int EPK_FTYPE_WORK = 20;
        public const int EPK_FTYPE_DURATION = 23;
        public const int EPK_FTYPE_OWNER = 12346;

        public const string CONST_CURRENT = "Current";


        public bool m_GotAllPIs = true;
        public string m_sPids = "";
        public int m_PI_Count = 0;

        public int m_CB_ID = 0;
        public string m_sCostTypes = "";
        public string m_sOtherCostTypes = "";
        public string m_sCalcCostTypes = "";
        public DateTime m_statdate = DateTime.MinValue;
        public DateTime m_dtMin = DateTime.MinValue;
        public DateTime m_dtMax = DateTime.MinValue;

        public int m_status_period = 0;
        public int m_max_period = 0;


        

        public Dictionary<int, clsPeriodData> m_Periods = null;

        public Dictionary<int, clsCatItemData> m_CostCat = null;
        public Dictionary<string, int> m_Role_CC = null;
        public Dictionary<int, clsCatItemData> m_CostCat_rolly = null;

        public  Dictionary<int, clsCustomFieldData> m_CustFields = null;
        public List<clsPortFieldData> m_CustAttribs = null;

        public Dictionary<int, clsDataItem> m_CostTypes = null;
        public Dictionary<int, clsDataItem> m_stages = null;


        public string[] m_sextra = new string[(int)cdFieldIDs.MAX_PI_EXTRA + 1];
        public string[] m_ExtraFieldNames = new string[(int)cdFieldIDs.MAX_PI_EXTRA + 1];
        public int[] m_fidextra = new int[(int)cdFieldIDs.MAX_PI_EXTRA + 1];
        public int[] m_ExtraFieldTypes = new int[(int)cdFieldIDs.MAX_PI_EXTRA + 1];
        public int m_Use_extra = 0;

        public Dictionary<string, clsPIData> m_PIs = null;

        public int m_SelFID = 0;
        public string m_Select_FieldName = "";

        public Dictionary<int, clsDataItem> m_codes = null;
        public Dictionary<int, clsDataItem> m_reses = null;
 
        
        
        public Dictionary<string, clsDetailRowData> m_detaildata = null;
        public Dictionary<string, clsDetailRowData> m_targetdata = null;
        public Dictionary<int, clsDataItem> m_targets = null;

        public List<clsTargetColours> m_clsTargetColours = null; 

        public Dictionary<int, clsRateTable> m_Rates = null; 
        public Dictionary<string, clsRateFTECache> m_ratecache = null;

        public int m_firstperiod_data = 0;
        public int m_lastperiod_data = 0;

        public int m_gPOPerm = 0;

        private double StripDBL(ref string sin)
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

            return double.Parse(sval);
        }
    }
}
