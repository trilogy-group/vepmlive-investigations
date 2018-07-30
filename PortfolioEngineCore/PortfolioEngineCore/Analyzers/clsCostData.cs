using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using PortfolioEngineCore;
using System.Globalization;
using PortfolioEngineCore.Analyzers;

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
    // (CC-76706, 2018-07-30) Properties, that implement both getter and setter, behave in the same way as fields for the purpose of serialization)
    [Serializable()]
    public class clsPeriodData : IPeriodData
    {
        public DateTime FinishDate { get; set; }
        public int PeriodID { get; set; }

        public string PeriodName { get; set; }

        public DateTime StartDate { get; set; }
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
    public class clsDetailRowData : BaseDetailRowData
    {
        public int CT_ind;
        public bool bFiltered;
        public int rowid;
        public string m_dict_key = string.Empty;

        public clsDetailRowData(int arraysize)
            : base (arraysize)
        {
            bFiltered = false;

            for (int i = 0; i <= mxdim; i++)
            {
                zFTE[i] = 0;
                oCosts[i] = 0;
                oUnits[i] = 0;
                oFTE[i] = 0;
            }
        }

        public void CopyData(clsDetailRowData src)
        {
            base.CopyData(src);
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


            CaptureBurnRates(clnPer.Values);
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

            CaptureBurnRates(clnPer.Values);
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
