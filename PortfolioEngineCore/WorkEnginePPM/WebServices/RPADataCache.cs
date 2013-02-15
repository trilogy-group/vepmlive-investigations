using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Linq;
using WorkEnginePPM;
using ResourceValues;


namespace RPADataCache
{

    [Serializable()]
    public class RPAColumnFieldDefn
    {
        public int fid;
        public string name;
        public int selected;
    }
    [Serializable()]
    class RPATGRow
    {
        public bool bUse;
        public int fid;
        public string Name;
        public string DisplayName;
    }
    [Serializable()]
    public static class RPConstants
    {

        public const int CONST_Commitment = 256;
        public const int CONST_Offer = 32;
        public const int CONST_REQUEST = 1;
        public const int CONST_Pending = 16;
        public const int CONST_NW = 16384;
        public const int CONST_MSPF = 32768;
        public const int CONST_REQUIRE = 4;
        public const int CONST_OPENREQUEST = 14;
        public const int CONST_ACTUALWORK = 128;


        public const string CONST_MSGBOX_TITLE = "Resource Plans";

        public const string CONST_text_Commitment = "Commitment";

        public const string CONST_text_Request = "Proposal";
        public const string CONST_text_NW = "Personal Item";
        public const string CONST_text_MSPF = "Scheduled Work";
        public const string CONST_text_ACTUALWORK = "Actual Work";
        public const string CONST_text_OpenRequire = "Open Requirement";


        public const string CONST_DEPT = "Department";
        public const string CONST_ROLE = "Role";
        public const string CONST_RESOURCE = "Resource";

        public const string CONST_GROUPING = "Grouping";
        public const string CONST_ITEM = "Portfolio Item";
        public const string CONST_ROWTYPE = "Row Type";
        public const string CONST_START = "PI Start Date";
        public const string CONST_FINISH = "PI Finish Date";
        public const string CONST_POWNER = "Owner";
        public const string CONST_STAGE = "Stage";
        public const string CONST_SOWNER = "Stage Owner";
        public const string CONST_CSDATE = "Start Date";
        public const string CONST_CFDATE = "Finish Date";
        public const string CONST_CRATE = "Set Rate";
        public const string CONST_CCOST = "Revenue";
        public const string CONST_CRTYPE = "Rate Type";
        public const string CONST_PLANID = "Plan ID";
        public const string CONST_PLANGRP = "Plan Group";
        public const string CONST_PRIORITY = "Priority";


        public const string CONST_ROWCC = "Cost Category";
        public const string CONST_ROWCCFULL = "Full Cost Category";
        public const string CONST_ROWCCROLE = "Cost Category Role";
        public const string CONST_ROWCCROLEFULL = "Full Cost Category Role";
        public const string CONST_ROWMAJORCAT = "Major Category";
        public const string CONST_ROWFULLCATROLE = "Full Category Role";
        public const string CONST_ROWGENERIC = "Generic";

        public const string CONST_BMODE_TOT_HRS = "Totals";
        public const string CONST_BMODE_TOT_HRS_CAPACITY = "Totals and Capacity";
        public const string CONST_BMODE_CAPACITY = "Capacity";
        public const string CONST_BMODE_REM_CAPACITY = "Remaining Capacity";
        public const string CONST_BMODE_FTE = "Total FTE";
        public const string CONST_BMODE_FTE_PERCENT = "Percentage Total FTE";

        public const string CONST_BMODE_TOT_SND = "Cost Category Roles with Role Summaries";
        public const string CONST_BMODE_TOT_S = "Role Summaries only";
        public const string CONST_BMODE_TOT_D = "Cost Category Roles only";
        public const string CONST_BMODE_TOT_R = "By Roles only";



        public const int TGRID_MAXCOLS = 8;
        public const int TGRID_CHECKCOL = 1;

        public const int TGRID_GRP_ID = 1;
        public const int TGRID_ITEM_ID = 2;
        public const int TGRID_RES_ID = 3;
        public const int TGRID_STAT_ID = 5;
        public const int TGRID_DEPT_ID = 6;
        public const int TGRID_ROLE_ID = 4;
        public const int TGRID_CC_ID = 7;
        public const int TGRID_CCFULL_ID = 8;
        public const int TGRID_CCROLE_ID = 9;
        public const int TGRID_CCROLEFULL_ID = 10;
        public const int TGRID_SDATE = 11;
        public const int TGRID_FDATE = 12;
        public const int TGRID_OWNER = 13;
        public const int TGRID_STAGE = 14;
        public const int TGRID_STAGE_OWNER = 15;
        public const int TGRID_CSDATE = 16;
        public const int TGRID_CFDATE = 17;
        public const int TGRID_CRATE = 18;
        public const int TGRID_CCOST = 19;
        public const int TGRID_CRTYPE = 20;
        public const int TGRID_PLANID = 21;
        public const int TGRID_PRIORITY = 22;
        public const int TGRID_PLANGRP = 23;
        public const int TGRID_MAJCAT = 24;
        public const int TGRID_FROLL = 25;
        public const int TGRID_GENERIC = 26;

        public const int CONST_TOP_FIXED_FIELDS = 26;


        public const int TGRID_TOTDEPT_ID = 1;
        public const int TGRID_TOTRESRES_ID = 2;
        public const int TGRID_TOTROLE_ID = 3;
        public const int TGRID_TOTCC_ID = 4;
        public const int TGRID_TOTCCFULL_ID = 5;
        public const int TGRID_TOTITEM_ID = 6;


        public const int CONST_SORT_ASCENDING = 1;
        public const int CONST_SORT_DESCENDING = -1;
        public const string ConstRawAvail = "Availability";
        public const string ConstRawForecast = "Scheduled Work";
        public const string ConstNone = "None";


        public static int StripNum(ref string sin)
        {
            try
            {
                int i = 0;
                string sval = "";

                sin = sin.Trim();
                i = sin.IndexOf(" ");

                if (i == -1)
                {
                    sval = sin;
                    sin = "";

                    if (sval == "")
                        return 0;
                }
                else
                {
                    sval = sin.Substring(0, i);
                    sin = sin.Substring(i + 1); //, sin.Length - i);
                }

                return int.Parse(sval);
            }
            catch (Exception ex)
            {
                string StatusText = "";
                StatusText = "WriteTrace Exception : " + ex.Message.ToString();
              
                return 0;
            }
        }

        internal static void GetCustValue(int fid, List<String> cln, out int lVal, out string sVal, clsResourceValues m_cResVals)
        {
           string s = "";
           int j;
           int i = 0;

            lVal = 0;
            sVal = "";

            if (cln == null)
                return;

            foreach (string v in cln)
            {
                s = v;

                j = RPConstants.StripNum(ref s);

                if (j == fid)
                {

                    i = RPConstants.StripNum(ref s);

                    if ((i == 0))
                        return;

                    if (s != "")
                        sVal = s;
                    else
                    {
                        lVal = i;

                        clsLookupList lu;
                        clsListItem oListItem;

                        if (m_cResVals.Lookups != null)
                        {

                            if (m_cResVals.Lookups.TryGetValue(fid, out lu) == true)
                            {

                                if (lu.ListItems.TryGetValue(lVal, out oListItem) == true)
                                    sVal = oListItem.Name;
                            }
                        }

                    }
                    return;
                }
                
            }

            lVal = 0;
            sVal = "";

        }



       

    }
    [Serializable()]
    class clsRXDept
    {
        public int ID;
        public string Name;
    }
    [Serializable()]
    class clsResFullDAta
    {
        public clsResxAvail resavail = null;
        public string ResOrRole = "";

        public clsResXData tot_Totals = new clsResXData();
        public clsResXData tot_actual = new clsResXData();
        public clsResXData tot_proposed = new clsResXData();
        public clsResXData tot_committed = new clsResXData();
        public clsResXData tot_personel = new clsResXData();
        public clsResXData tot_scheduled = new clsResXData();
        public clsResXData tot_avail = new clsResXData();

        public List<clsResXData> actual = new List<clsResXData>();
        public List<clsResXData> proposed = new List<clsResXData>();
        public List<clsResXData> committed = new List<clsResXData>();
        public List<clsResXData> personel = new List<clsResXData>();
        public List<clsResXData> scheduled = new List<clsResXData>();
        public List<clsResXData> avail = new List<clsResXData>();

        public List<clsResXData> CapScen = new List<clsResXData>();

        public Dictionary<int, string> PIList = new Dictionary<int, string>(); 

        public void CreateTotals(bool chkCommit, bool chkNonWork, bool ckkMSPF, bool chkActual, bool chkOpenRequest )
        {

            PIList = new Dictionary<int, string>(); 
            tot_Totals.SetPeriodsToZero();

            CreateTotalsForList(tot_actual, actual, chkActual, true);
            CreateTotalsForList(tot_proposed, proposed, chkOpenRequest, true);
            CreateTotalsForList(tot_committed, committed, chkCommit, true);
            CreateTotalsForList(tot_personel, personel, chkNonWork, false);
            CreateTotalsForList(tot_scheduled, scheduled, ckkMSPF, true);
            CreateTotalsForList(tot_avail, avail, false);
        }

        private void CreateTotalsForList(clsResXData tot, List<clsResXData> tot_list, bool bDoTotals = true, bool bDoPICollation = false)
        {
            tot.SetPeriodsToZero();

            foreach (clsResXData oDet in tot_list)
            {
                //                if (oDet.bDisplay == true && oDet.bTotalize == true && oDet.bFilteredOut == false)
                if (oDet.bTotalize == true && oDet.bFilteredOut == false)
                {
                    tot.AddToPeriods(oDet);
                    if (bDoTotals == true)
                    {
                        string sPI;
                        tot_Totals.AddToPeriods(oDet);

                        if (PIList.TryGetValue(oDet.ProjectID, out sPI) == false && oDet.ProjectName != "")
                            PIList.Add(oDet.ProjectID, oDet.ProjectName);
                    }
                }
            }
       }

        public void MoveOverAvail()
        {
            if (resavail == null)
                return;

            clsResXData oDet = new clsResXData();
            oDet.bDisplay = true;
            oDet.bTotalize = true;
            oDet.bFilteredOut = false;

            oDet.WrkHours = resavail.AvailHours;
            oDet.FTEVals = resavail.AvailFTEs;

            avail.Add(oDet);

        }

    }
    [Serializable()]
    class clsResxAvail
    {
        public int ID;
        public int RoleID;
        public int DeptID;
        public string Name;
        public int CostCat;
        public int CostCatRole;
        public bool isResource;

        public double[] AvailHours;
        public double[] AvailFTEs;
        public bool[] AvailHoursSet;
        int m_nump;

        public List<string> CustomFields;

        public void SetUpPeriods(int nPNum)
        {
            AvailHours = new double[nPNum + 1];
            AvailFTEs = new double[nPNum + 1];
            AvailHoursSet = new bool[nPNum + 1];

            int i = 0;
            m_nump = nPNum;


            for (i = 1; i <= nPNum; i++)
            {
                AvailHoursSet[i] = false;
                AvailHours[i] = 0;
                AvailFTEs[i] = 0;
            }
        }

        public void AddInAvail(clsResxAvail inavail)
        {
            if (inavail == null)
                return;
  
            for (int i = 1; i <= m_nump; i++)
            {
                AvailHours[i] += inavail.AvailHours[i];
                AvailFTEs[i] += inavail.AvailFTEs[i];
                AvailHoursSet[i] |= inavail.AvailHoursSet[i];
                
            }
        }

        public double getvarr(int cid)
        {
            return AvailHours[cid];
        }
        public void setvarr(int cid, double value)
        {
            AvailHours[cid] = value;
            AvailHoursSet[cid] = true;
        }
        public void addvarr(int cid, double value)
        {
            AvailHours[cid] += value;
            AvailHoursSet[cid] = true;
        }
        public double getftarr(int cid)
        {
            return AvailFTEs[cid];
        }
        public void setftarr(int cid, double value)
        {
            AvailFTEs[cid] = value;
        }
        public void addftarr(int cid, double value)
        {
            AvailFTEs[cid] += value;
        }
        public bool HasValue(int cid)
        {
            return (AvailHours[cid] != 0);
        }
        public string TextifyAvail(int cid)
        {
            double d = 0;

            if (AvailHoursSet[cid] == false)
            {
                return "N/A";
            }
            else
            {
                d = AvailHours[cid];

                return (d == 0 ? "" : d.ToString());
            }
        }
        public string TextifyFTEAvail(int cid, int lMode)
        {
            double d = 0;

            if (AvailHoursSet[cid] == false)
            {
                return "N/A";
            }
            else
            {
                d = AvailFTEs[cid];

                if ((lMode == 1 || lMode == -1))
                {
                    d /= 100;
                    return (d == 0 ? "" : d.ToString());
                }
                else if ((lMode == 2))
                {
                    return (d == 0 ? "" : d.ToString() + "%");
                }
                else if ((lMode == -2))
                {
                    return (d == 0 ? "" : d.ToString());
                }

                return "";
            }
        }
    }

    [Serializable()]
    class clsResXDragCloneList
    {
        public List<clsResXDragClone> m_cloneList = new List<clsResXDragClone>();
    }

 
    [Serializable()]
    class clsResXDragClone 
    {
        public double[] WrkHours;
        public double[] FTEVals;
        public clsResXData m_oDet;

        private int m_num_per;


        public void SetUpAndClonePeriods(int nPNum, double[] oDetWrk, double[] oDetFTE)
        {
            WrkHours = new double[nPNum + 1];
            FTEVals = new double[nPNum + 1];
            m_num_per = nPNum;

            for (int i = 1; i <= m_num_per; i++)
            {
                WrkHours[i] = oDetWrk[i];
                FTEVals[i] = oDetFTE[i];
            }

        }
    }

    [Serializable()]
    class clsResXData 
    {
        public int ID;
        public bool bTouched = false;

        public bool bTotalize;
        public bool bFilteredOut = false;
        public int UID;
        public int ProjectID;
        public string ProjectName = "";
        public int WResID = 0;
        public int RoleUID = 0;
        public int DeptUID;
        public int Status;
        public double[] WrkHours;
        public double[] FTEVals;
        public bool bRealone = true;
        public int rowid = 0;
         public string sName = "";
        public bool bDisplay = true;
        public int CostCat;
        public int CostCatRole = 0;
        public List<string> otherdata;
        public List<string> PIotherdata;
        public List<string> Resotherdata;
        public string PlanID;
        public string Priority = "";
        public string PlanGroup;
        public string majorcat;

        public DateTime cSDate;
        public DateTime cFDate;
        public double cRate;
        public double cCost;
        public string cRateType;
        public bool bDragged = false;
        public bool bDraggable = true;
        public int iDragCnt = 0;
 
        private int m_num_per;


 
        public void SetUpPeriods(int nPNum)
        {
            WrkHours = new double[nPNum + 1];
            FTEVals = new double[nPNum + 1];
            m_num_per = nPNum;

        }

        public void SetPeriodsToZero()
        {
            for (int i = 1; i <= m_num_per; i++)
            {
                WrkHours[i] = 0;
                FTEVals[i] = 0;
            }
        }

        public void AddToPeriods(clsResXData oSum)
        {
            for (int i = 1; i <= m_num_per; i++)
            {
                WrkHours[i] += oSum.WrkHours[i];
                FTEVals[i] += oSum.FTEVals[i];
            }
        }

         public double getvarr(int cid)
        {
            return WrkHours[cid];
        }
        public void setvarr(int cid, double value)
        {
            WrkHours[cid] = value;
         }
        public double getftarr(int cid)
        {
            return FTEVals[cid];
        }
        public void setftarr(int cid, double value)
        {
            FTEVals[cid] = value;
        }

        public void CloneArrayData(out clsResXDragClone odetclone)
        {
            odetclone = new clsResXDragClone();
            odetclone.SetUpAndClonePeriods(m_num_per, WrkHours, FTEVals);

        }


        public void ResoreClonedArrayData(clsResXDragClone odetclone)
        {
            for (int i = 1; i <= m_num_per; i++)
            {
                WrkHours[i] = odetclone.WrkHours[i];
                FTEVals[i] = odetclone.FTEVals[i];
            }
        }

        public void ShuntData(int fromCol, int toCol, clsRPAFTEConv ofte, int mode) {
            int tCol = 0;
            int sCol = 0;

            int diffr = 0;


 
            if (fromCol < toCol)
            {
                diffr = toCol - fromCol;

                for (var xi = 1; xi <= diffr; xi++)
                {

                    if (WrkHours[m_num_per] != 0 || FTEVals[m_num_per] != 0)
                        return;

                    bDragged = true;

                    for (int i = m_num_per; i >= 2; i--)
                    {
                        tCol = i;
                        sCol = i - 1;

                        if (mode == 0)
                        {
                            WrkHours[tCol] = WrkHours[sCol];
                            if (ofte == null)
                                FTEVals[tCol] = 0;
                            else if (ofte.FTEConv[tCol] == 0)
                                FTEVals[tCol] = 0;
                            else
                                FTEVals[tCol] = (WrkHours[tCol]*10000)/ofte.FTEConv[tCol];
                        }
                        else
                        {

                            FTEVals[tCol] = FTEVals[sCol];
                            if (ofte == null)
                                WrkHours[tCol] = 0;
                            else if (ofte.FTEConv[tCol] == 0)
                                WrkHours[tCol] = 0;
                            else
                                WrkHours[tCol] = (FTEVals[tCol]*ofte.FTEConv[tCol])/10000;
                        }
                    }
                    WrkHours[1] = 0;
                    FTEVals[1] = 0;
                }


            }
            else
            {
                diffr = fromCol - toCol;

                for (var xi = 1; xi <= diffr; xi++)
                {

                    if (WrkHours[1] != 0 || FTEVals[1] != 0)
                        return;

                    bDragged = true;

                    for (var i = 1; i <= m_num_per - 1; i++)
                    {
                        tCol = i;
                        sCol = i + 1;

                        if (mode == 0)
                        {
                            WrkHours[tCol] = WrkHours[sCol];
                            if (ofte == null)
                                FTEVals[tCol] = 0;
                            else if (ofte.FTEConv[tCol] == 0)
                                FTEVals[tCol] = 0;
                            else
                                FTEVals[tCol] = (WrkHours[tCol]*10000)/ofte.FTEConv[tCol];
                        }
                        else
                        {

                            FTEVals[tCol] = FTEVals[sCol];
                            if (ofte == null)
                                WrkHours[tCol] = 0;
                            else if (ofte.FTEConv[tCol] == 0)
                                WrkHours[tCol] = 0;
                            else
                                WrkHours[tCol] = (FTEVals[tCol]*ofte.FTEConv[tCol])/10000;
                        }
                    }

                    WrkHours[m_num_per] = 0;
                    FTEVals[m_num_per] = 0;
                }
            }
         }
    }

    [Serializable()]
    class clsRPAFTEConv
    {
        public int ID;
        public int[] FTEConv;

        private int m_num_per;


        public void SetUpPeriods(int nPNum)
        {
            FTEConv = new int[nPNum + 1];
            m_num_per = nPNum;

            for (int i = 1; i <= m_num_per; i++)
            {
                FTEConv[i] = 0;
            }
        }

    }
    [Serializable()]
    public class clsRXDisp
    {
        public string m_realname = "";
        public string m_dispname;
        public bool m_col_hidden;
        public int m_id;
        public int m_col;
        public int m_acc;
        public int m_width;
        public bool m_touched;
        public int m_type;
    }
    [Serializable()]
    public class RPAData
    {
        int m_pmo_admin = 0;
        bool chkOpenRequire = true;
        bool chkNonWork = true;
        int m_MaxUID = 0;
        bool m_use_role;
        bool m_use_heatmap = true;
        int m_use_heatmapID = -6;
        private int m_use_heatmapColour = 1;
  

        clsResourceValues m_cResVals;
        clsLookupList m_maj_Cat_lookup;
 
        Dictionary<int, clsResFullDAta> m_reslist = new Dictionary<int, clsResFullDAta>();
        Dictionary<int, clsResFullDAta> m_ccrolelist = new Dictionary<int, clsResFullDAta>();
        Dictionary<int, clsResFullDAta> m_rolelist = new Dictionary<int, clsResFullDAta>();

        Dictionary <int, clsRXDept> m_cln_depts = new Dictionary<int,clsRXDept>();
        int m_num_per;
        Dictionary<int, int> m_CCR_Role_Mapping;
        Dictionary<int, clsPIData> m_cln_pis;
        Dictionary<int, clsResxAvail> m_resavail;
        Dictionary<int, clsResXData> m_resdata;


        List<clsRXDisp> m_totmastercln, m_totdispcln, m_detdispcln;
        Dictionary<int, clsRXDisp> m_detmastercln;
        List<CPeriod> m_cs_perlist = new List<CPeriod>();
        Dictionary<int, clsResxAvail> m_cs_editdata = new Dictionary<int, clsResxAvail>();
        Dictionary<int, clsRPAFTEConv> m_fte_conv = new Dictionary<int, clsRPAFTEConv>();


        bool chkOffers = false;
        bool chkPend = false;
        bool chkRequests = false;
        bool chkCommit = true;
        bool chkActual = false;
        bool ckkMSPF = false;
        bool chkOpenRequest = false;

        int m_role_mode;

           List<clsResXData> m_clnsort = new List<clsResXData>();


        List<RPATGRow> TGStandard;
        List<RPATGRow> TotGeneral;
        List<RPATGRow> TotCapacity;
        List<RPATGRow> TotSelectedOrder;

        string m_viewsxml = "";
        string m_reload_cs_data = "";

  
 
        int m_DispMode = 0;
        int m_StartPerOffset = 1;
        private int m_useingCal = 0;

        Stack<clsResXDragCloneList> m_drag_stack = new Stack<clsResXDragCloneList>();

        private int m_firstperiod_data = 0;
        private int m_lastperiod_data = 0;

        private string m_heatmap_text = "";

        private bool m_hadopen_reqs = false;
        private string m_sParamXML = "";
        private bool m_neg_mode = false;

        public RPAData()
        {
 
            m_role_mode = 1;
            m_DispMode = 0;

            chkCommit = true;
            chkOffers = false;
            chkPend = false;
            chkRequests = false;
            chkNonWork = false;
            ckkMSPF = false;

            chkOpenRequire = false;
            chkOpenRequest = false;

            m_firstperiod_data = 0;
            m_lastperiod_data = 0;

        }

        internal void GrabRAData(clsResourceValues o_cResVals, string sReturnText, string sApplyView, int StartPerOffset, int iUsingCal, string sParamXML, out string stage_error_logging)
        {
            stage_error_logging = "I001";
            
            m_cResVals = new clsResourceValues();

            m_cResVals = o_cResVals;

            m_StartPerOffset = StartPerOffset;
            m_useingCal = iUsingCal;
            m_sParamXML = sParamXML;

            SetMajorCatListlookup();
            stage_error_logging = "I002";

            TGStandard = new List<RPATGRow>();
            TotGeneral = new List<RPATGRow>();
            TotCapacity = new List<RPATGRow>();
            TotSelectedOrder = new List<RPATGRow>();


            TGStandard.Add(CreatetgLayout(true, 0, " ", ""));

            TotGeneral.Add(CreatetgLayout(true, 0, "Totals", "Totals (from Top Grid)"));
            TotSelectedOrder.Add(TotGeneral[0]);

            TotGeneral.Add(CreatetgLayout(false, -1, "Actual Work", ""));
            TotGeneral.Add(CreatetgLayout(false, -2, "Proposed Work", ""));
            TotGeneral.Add(CreatetgLayout(false, -3, "Scheduled Work", ""));
            TotGeneral.Add(CreatetgLayout(false, -4, "Commited Work", ""));
            TotGeneral.Add(CreatetgLayout(false, -5, "Personal Time Off", ""));
            TotGeneral.Add(CreatetgLayout(false, -6, "Availability", ""));
            TotGeneral.Add(CreatetgLayout(false, -7, "Rem. Avail.", ""));


            m_pmo_admin = (m_cResVals.gpPMOAdmin == 0 ? 0 : 1);
            m_neg_mode = (m_cResVals.CommitmentsOpMode == 0);

            //          if (m_cResVals.OpenReqs == null) {
            //                chkOpenRequire = false;
            //          }

            //           else if (m_cResVals.OpenReqs.Count == 0)
            //           {
            //               chkOpenRequire = false;
            //          }
            //          else
            {

                stage_error_logging = "I003";
                m_MaxUID = 0;

                if (m_cResVals.Commitments != null)
                {

                    foreach (clsCommitment oCmt in m_cResVals.Commitments.Values)
                    {
                        if (oCmt.UID > m_MaxUID)
                            m_MaxUID = oCmt.UID;
                    }
                }

                m_MaxUID = m_MaxUID + 100000;    // add 10000 to max uid to add to open reqs and requirements to stop UID clash

                chkOpenRequire = true;

                // convert any Open Reqs into commitemnts

                if (m_cResVals.OpenReqs != null)
                {

                    m_hadopen_reqs = false;

                    foreach (clsCommitment oCmt in m_cResVals.OpenReqs.Values)
                    {
                        m_hadopen_reqs = true;


                        //                     if (oCmt.Status == RPConstants.CONST_REQUEST)    // anything in this list is an onren request
                        oCmt.Status = RPConstants.CONST_OPENREQUEST;

                        oCmt.UID = oCmt.UID + m_MaxUID;

                        m_cResVals.Commitments.Add(oCmt.UID, oCmt);
                    }

                    m_cResVals.OpenReqs = null;
                }

                stage_error_logging = "I004";

                if (m_cResVals.OpenReqHours != null)
                {

                    foreach (clsCommitmentHours oHrs in m_cResVals.OpenReqHours)
                    {
                        oHrs.UID = oHrs.UID + m_MaxUID;
                        m_cResVals.CommitmentHours.Add(oHrs);
                    }
                }

                m_cResVals.OpenReqHours = null;
            }



            m_use_role = false;





            PopulateInternals(out stage_error_logging);


            stage_error_logging = "I005";
            setupdispcolns(out stage_error_logging);

            stage_error_logging = "I007";
            ReDrawGrid();

        }

        private void SetMajorCatListlookup()
        {

            m_maj_Cat_lookup = null;

            try
            {

                foreach (clsLookupList Cat_lookup in m_cResVals.Lookups.Values)
                {
                    if (Cat_lookup.FieldID == m_cResVals.MajorCategoryFieldID)
                    {
                        m_maj_Cat_lookup = Cat_lookup;
                        return;
                    }
                }
            }

            catch
            {

            }
        }


        private void ItemListAddItem(List<clsEPKItem> oList, int id, string desc, string extradesc)
        {

            clsEPKItem oItem = new clsEPKItem();
            oItem.ID = id;
            oItem.Name = desc;
            oItem.Desc = extradesc;
            oList.Add(oItem);
        }

        private void PopulateInternals(out string serrlog)
        {
            int i = 0;
            Dictionary<int, clsRXDept> clnOldDepts;
            clnOldDepts = m_cln_depts;
            TotCapacity = new List<RPATGRow>();


            m_resdata = new Dictionary<int, clsResXData>();
            m_resavail = new Dictionary<int, clsResxAvail>();
            //m_grp_byrole = new Collection;
            //m_grp_onlyrole = new Collection;
            //m_cln_csrole = new Collection;
            //m_grp_byres = new Collection;
            m_cln_depts = new Dictionary<int, clsRXDept>();
            m_cln_pis = new Dictionary<int, clsPIData>();


            m_reslist = new Dictionary<int, clsResFullDAta>();
            m_ccrolelist = new Dictionary<int, clsResFullDAta>();
            m_rolelist = new Dictionary<int, clsResFullDAta>();


            clsResXData clsRD;

            m_num_per = m_cResVals.Periods.Count;


            if (m_firstperiod_data == 0)
            {
                m_firstperiod_data = m_num_per;
                m_lastperiod_data = 0;

            }

            clsRPAFTEConv ofconv;

            serrlog = "P001";

            if (m_cResVals.FTEConvData != null)
            {

                foreach (clsFTEConv ofte in m_cResVals.FTEConvData)
                {
                    if (m_fte_conv.TryGetValue(ofte.Cat_UID, out ofconv) == false)
                    {
                        ofconv = new clsRPAFTEConv();

                        ofconv.SetUpPeriods(m_num_per);
                        m_fte_conv.Add(ofte.Cat_UID, ofconv);
                    }

                    ofconv.FTEConv[ofte.PeriodID] = ofte.FTEConv;

                }
            }

            serrlog = "P002";

            clsRXDept clsdept;
            clsResxAvail clsra;
            clsResxAvail clsraunnassigned;

            clsPIData clsPI;
            int Max_PI = 0;
            int Max_CMTUID = 0;

            Max_PI = 0;
            Max_CMTUID = 0;

            BuileCCR2RoleMap();

            //    // first create a collection of PI's - capture the max PI num...


            serrlog = "P003";
            if (m_cResVals.PIs != null)
            {
                foreach (clsPIData oPI in m_cResVals.PIs.Values)
                {
                    if (oPI.ProjectID > Max_PI)
                        Max_PI = oPI.ProjectID;

                    oPI.bIsRealPI = true;
                    m_cln_pis.Add(oPI.ProjectID, oPI);

                }
            }


            serrlog = "P004";       // now create psuedo PI's to hold NWI
            Max_PI = Max_PI + 10;

            if (m_cResVals.NWItems != null)
            {

                foreach (clsEPKItem oi in m_cResVals.NWItems.Values)
                {
                    clsPI = new clsPIData();

                    clsPI.finish = DateTime.MinValue;
                    clsPI.bIsRealPI = false;
                    clsPI.ItemManager = "";
                    clsPI.ItemManagerWresID = 0;
                    clsPI.PIName = oi.Name;
                    clsPI.ProjectID = oi.ID + Max_PI;
                    clsPI.start = DateTime.MinValue;
                    clsPI.Priority = 0;
                    m_cln_pis.Add(clsPI.ProjectID, clsPI);

                }
            }


            // now build the collection of departments

            serrlog = "P005";
            if (m_cResVals.Departments != null)
            {
                foreach (clsEPKItem oi in m_cResVals.Departments.Values)
                {
                    clsdept = new clsRXDept();
                    clsdept.ID = oi.ID;
                    clsdept.Name = oi.Name;
                    m_cln_depts.Add(clsdept.ID, clsdept);

                }
            }

            clnOldDepts = null;

            clsdept = new clsRXDept();
            clsdept.ID = 0;
            m_cln_depts.Add(0, clsdept);


            // Now build a list of ALL resources - and have avail structures set up.
            // but also populate the dept for that res with the roles....

            clsResFullDAta rFull;


            serrlog = "P006";
            if (m_cResVals.Resources != null)
            {
                foreach (clsResCap oRCap in m_cResVals.Resources.Values)
                {
                    clsra = new clsResxAvail();

                    rFull = CreateNewResFullDAta();
                    rFull.resavail = clsra;
                    rFull.ResOrRole = oRCap.Name;


                    m_reslist.Add(oRCap.ID, rFull);

                    clsra.ID = oRCap.ID;
                    clsra.RoleID = oRCap.RoleUID;
                    clsra.DeptID = oRCap.DeptUID;
                    clsra.CostCat = oRCap.BC_UID_CC;
                    clsra.CostCatRole = oRCap.BC_UID_Role;
                    clsra.isResource = oRCap.IsResource;

                    clsra.CustomFields = oRCap.CustomFields;

                    clsra.Name = oRCap.Name;
                    clsra.SetUpPeriods(m_num_per);


                    m_resavail.Add(oRCap.ID, clsra);


                    // now set up the res forecast....

                    clsra = new clsResxAvail();

                    clsra.ID = oRCap.ID;
                    clsra.RoleID = oRCap.RoleUID;
                    clsra.DeptID = oRCap.DeptUID;
                    clsra.CostCat = oRCap.BC_UID_CC;
                    clsra.CostCatRole = oRCap.BC_UID_Role;
                    clsra.SetUpPeriods(m_num_per);

                }
            }
            clsra = new clsResxAvail();

            clsra.ID = 0;      // no resource;
            clsra.RoleID = 0; // no role;
            clsra.CostCatRole = 0;
            clsra.DeptID = 0;  // no dept;
            clsra.Name = "Unassigned";
            clsra.SetUpPeriods(m_num_per);

            m_resavail.Add(0, clsra);

            // should not need unassinged as only list ArgumentOutOfRangeException resources are passed in


            //rFull = CreateNewResFullDAta();
            //rFull.resavail = clsra;
            //rFull.ResOrRole = clsra.Name;

            //m_reslist.Add(0, rFull);

            clsra = new clsResxAvail();

            clsra.ID = 0;     // no resource;
            clsra.RoleID = 0;  // no role;
            clsra.CostCatRole = 0;
            clsra.DeptID = 0;  // no dept;
            clsra.Name = "Unassigned";
            clsra.SetUpPeriods(m_num_per);

            clsraunnassigned = clsra;

            serrlog = "P007";


            //     Now populate the resources with the availability....

            if (m_cResVals.ResAvail != null)
            {

                foreach (clsResAvail oRA in m_cResVals.ResAvail)
                {
                    if (m_resavail.TryGetValue(oRA.WResID, out clsra) == true)
                    {
                        clsra.setvarr(oRA.PeriodID - m_cResVals.FromPeriodID + 1, ConvHRs(oRA.Hours));
                        clsra.setftarr(oRA.PeriodID - m_cResVals.FromPeriodID + 1, ConvFTEs(oRA.FTES));
                    }
                }
            }


            // now run through m_reslists and copy avail values  from resavil into avail class...

            foreach (clsResFullDAta orfull in m_reslist.Values)
                orfull.MoveOverAvail();


            // So now lets run through the resources - and create the department availability


            serrlog = "P008";
            if (m_cResVals.Commitments != null)
            {
                foreach (clsCommitment oclsCmt in m_cResVals.Commitments.Values)
                {
                    if (m_resdata.TryGetValue(oclsCmt.UID, out clsRD) == false)
                    {
                        clsRD = new clsResXData();

                        if (m_reslist.TryGetValue(oclsCmt.WResID, out rFull) == true)
                        {
                            if (oclsCmt.Status == RPConstants.CONST_Commitment)
                                rFull.committed.Add(clsRD);
                            else if (oclsCmt.Status == RPConstants.CONST_OPENREQUEST || oclsCmt.Status == RPConstants.CONST_OPENREQUEST)
                                rFull.proposed.Add(clsRD);
                        }


                        clsRD.ID = m_resdata.Count + 1;
                        clsRD.bTotalize = true;
                        clsRD.DeptUID = oclsCmt.DeptUID;
                        clsRD.bDraggable = (oclsCmt.Dragable == 1);
                        clsRD.ProjectID = oclsCmt.ProjectID;
                        clsRD.ProjectName = ResolvePIName(oclsCmt.ProjectID);
                        clsRD.RoleUID = oclsCmt.RoleUID;
                        clsRD.Status = oclsCmt.Status;
                        clsRD.UID = oclsCmt.UID;
                        clsRD.CostCat = oclsCmt.BC_UID_CC;
                        clsRD.CostCatRole = oclsCmt.BC_UID_Role;

                        clsRD.majorcat = oclsCmt.MajorCategory;


                        clsRD.cSDate = oclsCmt.StartDate;
                        clsRD.cFDate = oclsCmt.FinishDate;
                        clsRD.cRate = oclsCmt.Rate;
                        clsRD.cCost = oclsCmt.cost;
                        clsRD.cRateType = oclsCmt.RateType;

                        clsRD.PlanID = oclsCmt.ID.ToString("0000");
                        clsRD.PlanGroup = oclsCmt.Group;

                        clsRD.otherdata = oclsCmt.CustomFields;

                        if (m_cln_pis.TryGetValue(oclsCmt.ProjectID, out clsPI) == true)
                        {

                            clsRD.PIotherdata = clsPI.CustomFields;
                            clsRD.Priority = (clsPI.Priority == 0 ? "" : clsPI.Priority.ToString());



                        }

                        if (m_resavail.TryGetValue(oclsCmt.WResID, out clsra) == true)
                        {

                            clsRD.Resotherdata = clsra.CustomFields;
                        }


                        if (clsRD.UID > Max_CMTUID)
                            Max_CMTUID = clsRD.UID;


                        clsRD.WResID = oclsCmt.WResID;

                        clsRD.SetUpPeriods(m_num_per);

                        m_resdata.Add(oclsCmt.UID, clsRD);


                    }
                }
            }


            serrlog = "P009";
            if (m_cResVals.CommitmentHours != null)
            {
                foreach (clsCommitmentHours oCommitmentHours in m_cResVals.CommitmentHours)
                {
                    if (m_resdata.TryGetValue(oCommitmentHours.UID, out clsRD) == true)
                    {

                        i = oCommitmentHours.PeriodID - m_cResVals.FromPeriodID + 1;
                        if ((i >= 1 && i <= m_num_per))
                        {
                            clsRD.setvarr(oCommitmentHours.PeriodID - m_cResVals.FromPeriodID + 1, ConvHRs(oCommitmentHours.Hours));
                            clsRD.setftarr(oCommitmentHours.PeriodID - m_cResVals.FromPeriodID + 1, ConvFTEs(oCommitmentHours.FTES));

                            if (oCommitmentHours.Hours != 0)
                            {

                                if (m_firstperiod_data > i)
                                    m_firstperiod_data = i;

                                if (i > m_lastperiod_data)
                                    m_lastperiod_data = i;
                            }


                        }
                    }
                }
            }


            serrlog = "P010";
            // now run thorugh the Non Work
            Max_CMTUID = -100000000;
            Dictionary<string, clsResXData> NWCln = new Dictionary<string, clsResXData>();

            if (m_cResVals.ResNWValues != null)
            {
                foreach (clsNWValue clsnwv in m_cResVals.ResNWValues)
                {
                    if (m_resavail.TryGetValue(clsnwv.WResID, out clsra) == true)
                    {


                        if (NWCln.TryGetValue(clsnwv.WResID.ToString() + " " + clsnwv.UID.ToString(), out clsRD) == false)
                        {
                            clsRD = new clsResXData();
                            Max_CMTUID++;

                            clsRD.bDraggable = false;

                            if (m_reslist.TryGetValue(clsnwv.WResID, out rFull) == true)
                                rFull.personel.Add(clsRD);

                            clsRD.ID = m_resdata.Count + 1;
                            clsRD.bTotalize = true;
                            clsRD.DeptUID = clsra.DeptID;
                            clsRD.ProjectID = clsnwv.UID + Max_PI;
                            clsRD.RoleUID = clsra.RoleID;
                            clsRD.Status = RPConstants.CONST_NW;
                            clsRD.UID = Max_CMTUID;
                            clsRD.WResID = clsnwv.WResID;
                            clsRD.CostCat = clsra.CostCat;
                            clsRD.CostCatRole = clsra.CostCatRole;
                            clsRD.Resotherdata = clsra.CustomFields;

                            clsRD.SetUpPeriods(m_cResVals.Periods.Count);


                            NWCln.Add(clsnwv.WResID.ToString() + " " + clsnwv.UID.ToString(), clsRD);


                        }

                        i = clsnwv.PeriodID - m_cResVals.FromPeriodID + 1;
                        if ((i >= 1 && i <= m_num_per))
                        {
                            clsRD.setvarr(clsnwv.PeriodID - m_cResVals.FromPeriodID + 1, ConvHRs(clsnwv.Hours));
                            clsRD.setftarr(clsnwv.PeriodID - m_cResVals.FromPeriodID + 1, ConvFTEs(clsnwv.FTES));
                            if (clsnwv.Hours != 0)
                            {

                                if (m_firstperiod_data > i)
                                    m_firstperiod_data = i;

                                if (i > m_lastperiod_data)
                                    m_lastperiod_data = i;
                            }
                        }
                    }

                }

                // lets filter out anything without any non-work

                bool bgd = false;
                foreach (clsResXData orxd in NWCln.Values)
                {
                    bgd = false;

                    for (int xi = 1; xi <= m_num_per; xi++)
                    {
                        if (orxd.getvarr(xi) != 0)
                        {
                            bgd = true;
                            break;
                        }
                    }

                    if (bgd)
                        m_resdata.Add(orxd.UID, orxd);
                }



            }

            NWCln = null;

            // this is where I shall process the MSP Scheduled work 

            serrlog = "P011";
            Max_CMTUID = -200000000;
            Dictionary<string, clsResXData> MSPFcln = new Dictionary<string, clsResXData>();


            if (m_cResVals.SchedWorkHours != null)
            {

                foreach (clsSchedWork cMSPF in m_cResVals.SchedWorkHours)
                {

                    if (m_resavail.TryGetValue(cMSPF.WResID, out clsra) == true)
                    {

                        // from this we get the resource, dept and role...;

                        if (MSPFcln.TryGetValue(cMSPF.WResID.ToString() + " " + cMSPF.ProjectID.ToString() + " " + cMSPF.MajorCategory.ToString(), out clsRD) == false)
                        {
                            clsRD = new clsResXData();

                            clsRD.bDraggable = false;

                            Max_CMTUID++;

                            if (m_reslist.TryGetValue(cMSPF.WResID, out rFull) == true)
                                rFull.scheduled.Add(clsRD);


                            clsRD.ID = m_resdata.Count + 1;
                            clsRD.bTotalize = true;
                            clsRD.DeptUID = clsra.DeptID;
                            clsRD.ProjectID = cMSPF.ProjectID;
                            clsRD.ProjectName = ResolvePIName(cMSPF.ProjectID);
                            clsRD.RoleUID = clsra.RoleID;
                            clsRD.Status = RPConstants.CONST_MSPF;
                            clsRD.UID = Max_CMTUID;
                            clsRD.WResID = cMSPF.WResID;
                            clsRD.majorcat = cMSPF.MajorCategory;

                            clsRD.CostCat = clsra.CostCat;
                            clsRD.CostCatRole = clsra.CostCatRole;
                            clsRD.Resotherdata = clsra.CustomFields;


                            if (m_cln_pis.TryGetValue(cMSPF.ProjectID, out clsPI) == true)
                            {
                                clsRD.PIotherdata = clsPI.CustomFields;
                                clsRD.Priority = (clsPI.Priority == 0 ? "" : clsPI.Priority.ToString());
                            }

                            clsRD.SetUpPeriods(m_cResVals.Periods.Count);

                            MSPFcln.Add(cMSPF.WResID.ToString() + " " + cMSPF.ProjectID.ToString() + " " + cMSPF.MajorCategory.ToString(), clsRD);
                            m_resdata.Add(clsRD.UID, clsRD);


                        }
                        i = cMSPF.PeriodID - m_cResVals.FromPeriodID + 1;
                        if ((i >= 1 && i <= m_num_per))
                        {
                            clsRD.setvarr(cMSPF.PeriodID - m_cResVals.FromPeriodID + 1, ConvHRs(cMSPF.Hours));
                            clsRD.setftarr(cMSPF.PeriodID - m_cResVals.FromPeriodID + 1, ConvFTEs(cMSPF.FTES));
                            if (cMSPF.Hours != 0)
                            {

                                if (m_firstperiod_data > i)
                                    m_firstperiod_data = i;

                                if (i > m_lastperiod_data)
                                    m_lastperiod_data = i;
                            }
                        }
                    }
                }


            }
            MSPFcln = null;

            // now do the actual work

            Max_CMTUID = -300000000;
            Dictionary<string, clsResXData> AWcln = new Dictionary<string, clsResXData>();


            serrlog = "P012";
            if (m_cResVals.ActualWorkHours != null)
            {

                foreach (clsSchedWork cMSPF in m_cResVals.ActualWorkHours)
                {

                    if (m_resavail.TryGetValue(cMSPF.WResID, out clsra) == true)
                    {

                        // from this we get the resource, dept and role...;

                        if (AWcln.TryGetValue(cMSPF.WResID.ToString() + " " + cMSPF.ProjectID.ToString() + " " + cMSPF.MajorCategory.ToString(), out clsRD) == false)
                        {
                            clsRD = new clsResXData();

                            clsRD.bDraggable = false;

                            Max_CMTUID++;

                            if (m_reslist.TryGetValue(cMSPF.WResID, out rFull) == true)
                                rFull.actual.Add(clsRD);


                            clsRD.ID = m_resdata.Count + 1;
                            clsRD.bTotalize = true;
                            clsRD.DeptUID = clsra.DeptID;
                            clsRD.ProjectID = cMSPF.ProjectID;
                            clsRD.RoleUID = clsra.RoleID;
                            clsRD.Status = RPConstants.CONST_ACTUALWORK;
                            clsRD.UID = Max_CMTUID;
                            clsRD.WResID = cMSPF.WResID;
                            clsRD.majorcat = cMSPF.MajorCategory;

                            clsRD.CostCat = clsra.CostCat;
                            clsRD.CostCatRole = clsra.CostCatRole;
                            clsRD.Resotherdata = clsra.CustomFields;


                            if (m_cln_pis.TryGetValue(cMSPF.ProjectID, out clsPI) == true)
                            {
                                clsRD.PIotherdata = clsPI.CustomFields;
                                clsRD.Priority = (clsPI.Priority == 0 ? "" : clsPI.Priority.ToString());
                            }

                            clsRD.SetUpPeriods(m_cResVals.Periods.Count);

                            AWcln.Add(cMSPF.WResID.ToString() + " " + cMSPF.ProjectID.ToString() + " " + cMSPF.MajorCategory.ToString(), clsRD);
                            m_resdata.Add(clsRD.UID, clsRD);


                        }
                        i = cMSPF.PeriodID - m_cResVals.FromPeriodID + 1;
                        if ((i >= 1 && i <= m_num_per))
                        {
                            clsRD.setvarr(cMSPF.PeriodID - m_cResVals.FromPeriodID + 1, ConvHRs(cMSPF.Hours));
                            clsRD.setftarr(cMSPF.PeriodID - m_cResVals.FromPeriodID + 1, ConvFTEs(cMSPF.FTES));

                            if (cMSPF.Hours != 0)
                            {

                                if (m_firstperiod_data > i)
                                    m_firstperiod_data = i;

                                if (i > m_lastperiod_data)
                                    m_lastperiod_data = i;
                            }
                        }
                    }
                }
            }
            AWcln = null;


            // oK so now create the dictionarys of all the CCROlels and Roles - for the resources - and append availability, scheculed work, actual work and personal work


            clsCatItem oc;
            clsListItem li;

            serrlog = "P013";
            foreach (clsResFullDAta orfull in m_reslist.Values)
            {
                if (orfull.resavail != null)
                {
                    if (m_ccrolelist.TryGetValue(orfull.resavail.CostCatRole, out rFull) == false && orfull.resavail.CostCatRole != 0)    // first for the ccrole
                    {
                        rFull = CreateNewResFullDAta();
                        m_ccrolelist.Add(orfull.resavail.CostCatRole, rFull);

                        if (m_cResVals.CostCategories.TryGetValue(orfull.resavail.CostCatRole, out oc) == true)
                            rFull.ResOrRole = oc.FullName;

                    }
                    if (rFull != null)
                    {
                        rFull.avail.AddRange(orfull.avail);
                        rFull.actual.AddRange(orfull.actual);
                        rFull.personel.AddRange(orfull.personel);
                        rFull.scheduled.AddRange(orfull.scheduled);
                    }

                    if (m_rolelist.TryGetValue(orfull.resavail.RoleID, out rFull) == false && orfull.resavail.RoleID != 0)    // first for the role
                    {
                        rFull = CreateNewResFullDAta();
                        m_rolelist.Add(orfull.resavail.RoleID, rFull);

                        if (m_cResVals.Roles.TryGetValue(orfull.resavail.RoleID, out li) == true)
                            rFull.ResOrRole = li.Name;

                    }

                    if (rFull != null)
                    {

                        rFull.avail.AddRange(orfull.avail);
                        rFull.actual.AddRange(orfull.actual);
                        rFull.personel.AddRange(orfull.personel);
                        rFull.scheduled.AddRange(orfull.scheduled);
                    }
                }
            }


            // now go through the same steps for commitments and proposed!

            serrlog = "P014";
            foreach (clsResXData orx in m_resdata.Values)
            {
                if ((orx.Status == RPConstants.CONST_Commitment) || (orx.Status == RPConstants.CONST_OPENREQUEST))
                {

                    if (m_ccrolelist.TryGetValue(orx.CostCatRole, out rFull) == false)    // first for the ccrole
                    {
                        rFull = CreateNewResFullDAta();
                        m_ccrolelist.Add(orx.CostCatRole, rFull);

                        if (m_cResVals.CostCategories != null)
                        {
                            if (m_cResVals.CostCategories.TryGetValue(orx.CostCatRole, out oc) == true)
                                rFull.ResOrRole = oc.FullName;
                        }
                        else
                        {
                            rFull.ResOrRole = "";
                        }
                    }

                    if (orx.Status == RPConstants.CONST_Commitment)
                        rFull.committed.Add(orx);
                    else if (orx.Status == RPConstants.CONST_Commitment)
                        rFull.proposed.Add(orx);


                    if (m_rolelist.TryGetValue(orx.RoleUID, out rFull) == false)    // first for the ccrole
                    {
                        rFull = CreateNewResFullDAta();
                        m_rolelist.Add(orx.RoleUID, rFull);

                        if (m_cResVals.Roles != null)
                        {
                            if (m_cResVals.Roles.TryGetValue(orx.RoleUID, out li) == true)
                                rFull.ResOrRole = li.Name;
                        }
                        else
                            rFull.ResOrRole = "";
                    }

                    if (orx.Status == RPConstants.CONST_Commitment)
                        rFull.committed.Add(orx);
                    else if (orx.Status == RPConstants.CONST_Commitment)
                        rFull.proposed.Add(orx);

                }


            }

            if (m_cResVals.CostCategories == null)
                m_cResVals.CostCategories = new Dictionary<int, clsCatItem>();

            if (m_cResVals.Roles == null)
                m_cResVals.Roles = new Dictionary<int, clsListItem>();


            serrlog = "P015";
            if (m_cResVals.CapacityTargets != null)
            {
                Dictionary<string, int> capcon = new Dictionary<string, int>();
                int capindx;

                foreach (clsEPKItem oi in m_cResVals.CapacityTargets.Values)
                {
                    if (capcon.TryGetValue(oi.Name, out capindx) == false)
                    {
                        capindx = capcon.Count + 1;
                        capcon.Add(oi.Name, capindx);

                        TotCapacity.Add(CreatetgLayout(false, capindx, oi.Name, ""));
                    }
                }

                if (m_cResVals.CapacityTargets.Count > 0 && TotGeneral.Count <= 8)
                    TotGeneral.Add(CreatetgLayout(false, -8, "Rem. Capacity", ""));



                foreach (clsResFullDAta orfull in m_ccrolelist.Values)
                {
                    for (int xi = 0; xi < capcon.Count; xi++)
                    {

                        clsRD = new clsResXData();

                        clsRD.SetUpPeriods(m_cResVals.Periods.Count);
                        orfull.CapScen.Add(clsRD);

                    }
                }
                foreach (clsResFullDAta orfull in m_rolelist.Values)
                {
                    for (int xi = 0; xi < capcon.Count; xi++)
                    {

                        clsRD = new clsResXData();

                        clsRD.SetUpPeriods(m_cResVals.Periods.Count);
                        clsRD.SetPeriodsToZero();
                        orfull.CapScen.Add(clsRD);

                    }

                }


                serrlog = "P016";
                if (m_cResVals.CapacityTargetValues != null)
                {
                    clsEPKItem oItem;
                    int perid;

                    foreach (clsCapacityValue oCapacityValue in m_cResVals.CapacityTargetValues)
                    {
                        if (m_cResVals.CapacityTargets.TryGetValue(oCapacityValue.ID, out oItem) == true)
                        {

                            if (capcon.TryGetValue(oItem.Name, out capindx) == true)
                            {
                                // so capindex gives us the index into the list of cap scens per ccrole and role

                                --capindx;
                                perid = oCapacityValue.PeriodID - m_cResVals.FromPeriodID + 1;

                                if (m_ccrolelist.TryGetValue(oCapacityValue.RoleUID, out rFull) == true)
                                {
                                    clsRD = rFull.CapScen[capindx];
                                    clsRD.WrkHours[perid] += ConvHRs(oCapacityValue.Hours);
                                    clsRD.FTEVals[perid] += ConvFTEs(oCapacityValue.FTES);
                                }


                                // now map the ccrole to the role

                                int mappedrole = MapCCR2Role(oCapacityValue.RoleUID);

                                if (m_rolelist.TryGetValue(mappedrole, out rFull) == true)
                                {
                                    clsRD = rFull.CapScen[capindx];
                                    clsRD.WrkHours[perid] += ConvHRs(oCapacityValue.Hours);
                                    clsRD.FTEVals[perid] += ConvFTEs(oCapacityValue.FTES);
                                }

                            }

                        }

                    }
                }



            }





        }
        private void BuileCCR2RoleMap()
        {
            string sShort = "";
            int ccr = 0;
            int v;

            m_CCR_Role_Mapping = new Dictionary<int, int>();

            if ((m_cResVals.CostCategories == null))
                return;

            foreach (clsCatItem oc in m_cResVals.CostCategories.Values)
            {

                sShort = oc.Name;
                ccr = oc.UID;

                v = 0;
                if (m_cResVals.Roles != null)
                {
                    foreach (clsListItem oListItem in m_cResVals.Roles.Values)
                    {
                        if (oListItem.Name == sShort)
                        {
                            v = oListItem.ID;
                            break;
                        }
                    }
                }

                m_CCR_Role_Mapping.Add(ccr, v);

            }
        }

        private int MapCCR2Role(int ccr)
        {
            int v;

            if (m_CCR_Role_Mapping == null)
                return 0;

            if (m_CCR_Role_Mapping.TryGetValue(ccr, out v) == false)
                return 0;

            return v;
        }

        private double ConvFTEs(double dFTEs)
        {
            double d;

            d = Math.Round(dFTEs / 10);

            return d / 10;

        }

        private double ConvHRs(double dhrs)
        {
            double d;
            d = dhrs * 100;
            d = Math.Round(d);
            return d / 100;

        }
        private string ExtractEmbeddedString(ref string sin)
        {
            int j;
            string s;

            j = RPConstants.StripNum(ref sin);

            if (j == 0)
            {
                sin = sin.Trim();
                return "";
            }


            s = sin.Substring(0, j);
            sin = sin.Substring(j + 1);
            return s;
        }

        private void GetCostCatStrings(int lUID, out string sShort, out string sFull)
        {

            sShort = "";
            sFull = "";

            clsCatItem oc;

            if (m_cResVals.CostCategories.TryGetValue(lUID, out oc) == true)
            {
                sShort = oc.Name;
                sFull = oc.FullName;
            }

        }

        private string GetRoleName(int ruid)
        {
            clsListItem oListItem;

            if (m_cResVals.Roles.TryGetValue(ruid, out  oListItem) == true)
                return oListItem.Name;

            return "Unknown";
        }

        private void setupdispcolns(out string errlog)
        {
            clsRXDisp orxd;
            int i = 0;


            errlog = "D001";

            m_totmastercln = new List<clsRXDisp>();
            m_totdispcln = new List<clsRXDisp>();
            m_detmastercln = new Dictionary<int, clsRXDisp>();
            m_detdispcln = new List<clsRXDisp>();

            orxd = new clsRXDisp();
            orxd.m_col_hidden = false;
            orxd.m_dispname = RPConstants.CONST_ROLE + "/n" + RPConstants.CONST_RESOURCE;
            orxd.m_realname = orxd.m_dispname;
            orxd.m_id = RPConstants.TGRID_TOTRESRES_ID;
            orxd.m_acc = 2;
            orxd.m_col = 2;
            orxd.m_width = -1;


            m_totmastercln.Add(orxd);
            m_totdispcln.Add(orxd);

            orxd = new clsRXDisp();
            orxd.m_col_hidden = false;
            orxd.m_dispname = RPConstants.CONST_DEPT;
            orxd.m_realname = RPConstants.CONST_DEPT;
            orxd.m_id = RPConstants.TGRID_TOTDEPT_ID;
            orxd.m_acc = 1;
            orxd.m_col = 1;
            orxd.m_width = -1;

            m_totmastercln.Add(orxd);
            m_totdispcln.Add(orxd);

            orxd = new clsRXDisp();
            orxd.m_col_hidden = false;
            orxd.m_dispname = RPConstants.CONST_ROLE;
            orxd.m_realname = RPConstants.CONST_ROLE;
            orxd.m_id = RPConstants.TGRID_TOTROLE_ID;
            orxd.m_acc = 3;
            orxd.m_col = 3;
            orxd.m_width = -1;

            m_totmastercln.Add(orxd);
            m_totdispcln.Add(orxd);

            m_totmastercln.Add(orxd);
            m_totdispcln.Add(orxd);

            orxd = new clsRXDisp();
            orxd.m_col_hidden = false;
            orxd.m_dispname = RPConstants.CONST_ROWCC;
            orxd.m_realname = RPConstants.CONST_ROWCC;
            orxd.m_id = RPConstants.TGRID_TOTCC_ID;
            orxd.m_acc = 4;
            orxd.m_col = 4;
            orxd.m_width = -1;

            m_totmastercln.Add(orxd);
            m_totdispcln.Add(orxd);

            orxd = new clsRXDisp();
            orxd.m_col_hidden = false;
            orxd.m_dispname = RPConstants.CONST_ROWCCROLEFULL;
            orxd.m_realname = RPConstants.CONST_ROWCCROLEFULL;
            orxd.m_id = RPConstants.TGRID_TOTCCFULL_ID;
            orxd.m_acc = 5;
            orxd.m_col = 5;
            orxd.m_width = -1;

            orxd = new clsRXDisp();
            orxd.m_col_hidden = false;
            orxd.m_dispname = RPConstants.CONST_ITEM;
            orxd.m_realname = RPConstants.CONST_ITEM;
            orxd.m_id = RPConstants.TGRID_TOTITEM_ID;
            orxd.m_acc = 6;
            orxd.m_col = 6;
            orxd.m_width = -1;

            m_totmastercln.Add(orxd);
            m_totdispcln.Add(orxd);



            errlog = "D002";

            if (m_cResVals.ResFields != null)
            {
                foreach (clsPortField opf in m_cResVals.ResFields)
                {
                    orxd = new clsRXDisp();
                    orxd.m_col_hidden = false;
                    orxd.m_id = opf.ID;
                    orxd.m_col = i;
                    orxd.m_acc = m_totmastercln.Count + 1;
                    orxd.m_width = -1;


                    if (opf.GivenName != "")
                    {
                        orxd.m_dispname = opf.GivenName;
                    }
                    else
                    {
                        orxd.m_dispname = opf.Name;
                    }

                    orxd.m_realname = "x" + orxd.m_dispname;

                    m_totmastercln.Add(orxd);
                    m_totdispcln.Add(orxd);


                    i++;
                }
            }

            errlog = "D003";

            for (i = 1; i <= RPConstants.CONST_TOP_FIXED_FIELDS; i++)
            {
                orxd = new clsRXDisp();
                orxd.m_col_hidden = false;
                orxd.m_id = i;
                orxd.m_col = i;
                orxd.m_acc = m_detmastercln.Count + 1;
                orxd.m_width = -1;
                orxd.m_type = 1;


                switch (i)
                {
                    case RPConstants.TGRID_GRP_ID:
                        orxd.m_dispname = RPConstants.CONST_GROUPING;
                        break;
                    case RPConstants.TGRID_STAT_ID:
                        orxd.m_dispname = RPConstants.CONST_ROWTYPE;
                        break;
                    case RPConstants.TGRID_DEPT_ID:
                        orxd.m_dispname = RPConstants.CONST_DEPT;
                        break;
                    case RPConstants.TGRID_ROLE_ID:
                        orxd.m_dispname = RPConstants.CONST_ROLE;
                        break;
                    case RPConstants.TGRID_ITEM_ID:
                        orxd.m_dispname = RPConstants.CONST_ITEM;
                        break;
                    case RPConstants.TGRID_RES_ID:
                        orxd.m_dispname = RPConstants.CONST_RESOURCE;
                        break;
                    case RPConstants.TGRID_CC_ID:
                        orxd.m_dispname = RPConstants.CONST_ROWCC;
                        break;
                    case RPConstants.TGRID_CCFULL_ID:
                        orxd.m_dispname = RPConstants.CONST_ROWCCFULL;
                        //                      orxd.m_col_hidden = true;
                        break;
                    case RPConstants.TGRID_CCROLE_ID:
                        orxd.m_dispname = RPConstants.CONST_ROWCCROLE;
                        break;
                    case RPConstants.TGRID_CCROLEFULL_ID:
                        orxd.m_dispname = RPConstants.CONST_ROWCCROLEFULL;
                        //                    orxd.m_col_hidden = true;

                        break;
                    case RPConstants.TGRID_SDATE:
                        orxd.m_dispname = RPConstants.CONST_START;
                        orxd.m_type = 2;
                        break;
                    case RPConstants.TGRID_FDATE:
                        orxd.m_dispname = RPConstants.CONST_FINISH;
                        orxd.m_type = 2;
                        break;
                    case RPConstants.TGRID_OWNER:
                        orxd.m_dispname = RPConstants.CONST_POWNER;
                        break;
                    case RPConstants.TGRID_STAGE:
                        orxd.m_dispname = RPConstants.CONST_STAGE;
                        break;
                    case RPConstants.TGRID_STAGE_OWNER:
                        orxd.m_dispname = RPConstants.CONST_SOWNER;

                        break;
                    case RPConstants.TGRID_CSDATE:
                        orxd.m_dispname = RPConstants.CONST_CSDATE;
                        orxd.m_type = 2;

                        break;
                    case RPConstants.TGRID_CFDATE:
                        orxd.m_dispname = RPConstants.CONST_CFDATE;
                        orxd.m_type = 2;

                        break;
                    case RPConstants.TGRID_CRATE:
                        orxd.m_dispname = RPConstants.CONST_CRATE;

                        break;
                    case RPConstants.TGRID_CCOST:
                        orxd.m_dispname = RPConstants.CONST_CCOST;
                        orxd.m_type = 3;

                        break;
                    case RPConstants.TGRID_CRTYPE:
                        orxd.m_dispname = RPConstants.CONST_CRTYPE;

                        break;
                    case RPConstants.TGRID_PLANID:
                        orxd.m_dispname = RPConstants.CONST_PLANID;

                        break;
                    case RPConstants.TGRID_PRIORITY:
                        orxd.m_dispname = RPConstants.CONST_PRIORITY;


                        break;
                    case RPConstants.TGRID_PLANGRP:
                        orxd.m_dispname = RPConstants.CONST_PLANGRP;

                        break;
                    case RPConstants.TGRID_MAJCAT:
                        orxd.m_dispname = RPConstants.CONST_ROWMAJORCAT;
                        break;
                    case RPConstants.TGRID_FROLL:
                        orxd.m_dispname = RPConstants.CONST_ROWFULLCATROLE;
                        break;
                    case RPConstants.TGRID_GENERIC:
                        orxd.m_dispname = RPConstants.CONST_ROWGENERIC;
                        break;
                }

                orxd.m_realname = orxd.m_dispname;


                m_detmastercln.Add(i, orxd);
                m_detdispcln.Add(orxd);


            }

            i = RPConstants.CONST_TOP_FIXED_FIELDS + 1;
            errlog = "D004";
            if (m_cResVals.PlanFields != null)
            {
                foreach (clsPortField opf in m_cResVals.PlanFields)
                {
                    orxd = new clsRXDisp();

                    orxd.m_col_hidden = false;
                    orxd.m_id = opf.ID;
                    orxd.m_col = i;
                    orxd.m_acc = m_detmastercln.Count + 1;
                    orxd.m_width = -1;


                    if (opf.GivenName != "")
                    {
                        orxd.m_dispname = opf.GivenName;
                    }
                    else
                    {
                        orxd.m_dispname = opf.Name;
                    }

                    orxd.m_realname = "x" + orxd.m_dispname;

                    m_detmastercln.Add(opf.ID, orxd);
                    m_detdispcln.Add(orxd);


                    i++;
                }
            }
            errlog = "D005";
            if (m_cResVals.PIFields != null)
            {
                foreach (clsPortField opf in m_cResVals.PIFields)
                {
                    orxd = new clsRXDisp();

                    orxd.m_col_hidden = false;
                    orxd.m_id = opf.ID;
                    orxd.m_col = i;
                    orxd.m_acc = m_detmastercln.Count + 1;
                    orxd.m_width = -1;


                    if (opf.GivenName != "")
                    {
                        orxd.m_dispname = opf.GivenName;
                    }
                    else
                    {
                        orxd.m_dispname = opf.Name;
                    }

                    orxd.m_realname = "x" + orxd.m_dispname;

                    m_detmastercln.Add(opf.ID, orxd);
                    m_detdispcln.Add(orxd);


                    i++;
                }
            }
            errlog = "D006";
            if (m_cResVals.ResFields != null)
            {
                foreach (clsPortField opf in m_cResVals.ResFields)
                {
                    orxd = new clsRXDisp();
                    orxd.m_col_hidden = false;
                    orxd.m_id = opf.ID;
                    orxd.m_col = i;
                    orxd.m_acc = m_detmastercln.Count + 1;
                    orxd.m_width = -1;


                    if (opf.GivenName != "")
                    {
                        orxd.m_dispname = opf.GivenName;
                    }
                    else
                    {
                        orxd.m_dispname = opf.Name;
                    }

                    orxd.m_realname = "x" + orxd.m_dispname;

                    m_detmastercln.Add(opf.ID, orxd);
                    m_detdispcln.Add(orxd);


                    i++;
                }
            }

        }



        private void ReDrawGrid()
        {
            m_clnsort = new List<clsResXData>();

            foreach (clsResXData cdata in m_resdata.Values)
            {
                cdata.bDisplay = DoIShowReqType(cdata.Status);


                if (cdata.bDisplay == true)
                    m_clnsort.Add(cdata);

            }


            NewRedrawTotals();


            return;


        }

        private bool DoIShowReqType(int stat)
        {
            switch (stat)
            {
                case RPConstants.CONST_Commitment:
                    return (chkCommit == true);
                case RPConstants.CONST_Offer:
                    return (chkOffers == true); // && m_cResVals.CommitmentsOpMode == 0);
                case RPConstants.CONST_Pending:
                    return (chkPend == true); // && m_cResVals.CommitmentsOpMode == 0);
                case RPConstants.CONST_REQUEST:
                    return (chkRequests == true); // && m_cResVals.CommitmentsOpMode == 0);
                case RPConstants.CONST_NW:
                    return (chkNonWork == true);
                case RPConstants.CONST_MSPF:
                    return (ckkMSPF == true);

                case RPConstants.CONST_ACTUALWORK:
                    return (chkActual == true);

                case RPConstants.CONST_REQUIRE:
                    return (chkOpenRequire == true);
                case RPConstants.CONST_OPENREQUEST:
                    return (chkOpenRequest == true);
            }

            return false;
        }

        private void GetMajorCatStrings(int lUID, out string sShort, out string sFull)
        {

            clsCatItem oc;
            sShort = "";
            sFull = "";

            if (m_cResVals.CostCategories.TryGetValue(lUID, out oc) == true)
            {

                sShort = GetMajorCat(oc.MajorCategory);

                if (m_cResVals.CostCategories.TryGetValue(oc.Category, out oc) == true)
                    sFull = oc.FullName;

                return;
            }

            sShort = "";
            sFull = "";
        }

        private string GetMajorCat(int mcat)
        {
            if (mcat == 0)
                return "";

            clsListItem oLItem;

            if (m_maj_Cat_lookup.ListItems.TryGetValue(mcat, out oLItem) == true)
                return oLItem.Name;

            return "";
        }

        private void NewRedrawTotals()
        {

            m_heatmap_text = "";
            if (m_use_heatmap)
            {
                // convert m_use_heatmapID into text


                foreach (RPATGRow otg in TotGeneral)
                {
                    if (otg.fid == m_use_heatmapID)
                    {
                        m_heatmap_text = otg.Name;
                        break;
                    }
                }

                foreach (RPATGRow otg in TotCapacity)
                {
                    if (otg.fid == m_use_heatmapID)
                    {
                        m_heatmap_text = otg.Name;
                        break;
                    }
                }
            }


            clsRXDisp oResorRole = null;

            for (int xj = 0; xj < m_totdispcln.Count; xj++)
            {
                if (m_totdispcln[xj].m_id == RPConstants.TGRID_TOTRESRES_ID)
                {
                    oResorRole = m_totdispcln[xj];
                    break;

                }
            }



            if (m_use_role == true)
            {
                if (oResorRole != null)
                    oResorRole.m_realname = RPConstants.CONST_ROLE;


                foreach (clsResFullDAta rFull in m_ccrolelist.Values)
                {
                    rFull.CreateTotals(chkCommit, chkNonWork, ckkMSPF, chkActual, chkOpenRequest);

                }
                foreach (clsResFullDAta rFull in m_rolelist.Values)
                {
                    rFull.CreateTotals(chkCommit, chkNonWork, ckkMSPF, chkActual, chkOpenRequest);

                }
            }
            else
            {
                if (oResorRole != null)
                    oResorRole.m_realname = RPConstants.CONST_RESOURCE;

                foreach (clsResFullDAta rFull in m_reslist.Values)
                {
                    rFull.CreateTotals(chkCommit, chkNonWork, ckkMSPF, chkActual, chkOpenRequest);

                }
            }
        }



        public string GetTopGrid()
        {

            RPATopGrid oGrid = new RPATopGrid();
            string s;
            oGrid.InitializeGridLayout(m_detdispcln, m_pmo_admin);
            int i = 0;



            List<RPATGRow> displist;

            displist = TGStandard;


            foreach (CPeriod period in m_cResVals.Periods.Values)
            {
                i++;
                oGrid.AddPeriodColumn(period.PeriodID.ToString(), period.PeriodName, m_DispMode, displist, m_pmo_admin);
            }

            oGrid.FinalizeGridLayout();
            oGrid.InitializeGridData();
            clsPIData oPIData;

            displist = TGStandard;

            i = 0;

            foreach (clsResXData oDet in m_clnsort)
            {

                oDet.rowid = i;


                m_cln_pis.TryGetValue(oDet.ProjectID, out oPIData);
                oGrid.AddDetailRow(oDet, m_detdispcln, m_cResVals, m_maj_Cat_lookup, oPIData, ++i, m_DispMode, displist, m_cResVals.TargetColors);
            }

            s = oGrid.GetString();

            return s;


        }


        public int GetRawDataCount()
        {

            return m_resdata.Values.Count;
        }

        public int GetFilteredDataCount()
        {

            return m_clnsort.Count;
        }

        public string GetBottomGrid()
        {

            RPANewBottomGrid oGrid = new RPANewBottomGrid();
            string s;

            if (m_use_role)
                s = RPConstants.CONST_ROLE;
            else
                s = RPConstants.CONST_RESOURCE;

            oGrid.InitializeGridLayout(m_totdispcln, m_use_role, s);

            int i = 0;
            foreach (CPeriod period in m_cResVals.Periods.Values)
            {
                i++;
                oGrid.AddPeriodColumn(period.PeriodID.ToString(), period.PeriodName, m_DispMode, TotSelectedOrder, m_use_heatmap);
            }

            oGrid.FinalizeGridLayout();
            oGrid.InitializeGridData();
            i = 0;

            Dictionary<int, clsResFullDAta> cln;

            if (m_use_role == false)
                cln = m_reslist;
            else if (m_role_mode == 2)
                cln = m_rolelist;
            else
                cln = m_ccrolelist;



            foreach (clsResFullDAta oRFull in cln.Values)
            {
                try
                {

                    oGrid.AddDetailRow(oRFull, m_totdispcln, m_cResVals, m_cResVals.TargetColors, ++i, m_DispMode, m_use_role, TotSelectedOrder, m_use_heatmap, m_use_heatmapID, m_use_role, m_use_heatmapColour);
                }
                catch (Exception ex)
                {
                    string StatusText = "";
                    StatusText = "WriteTrace Exception : " + ex.Message.ToString();
                }
            }

            s = oGrid.GetString();

            return s;

        }

        public string GetTotalsData(bool bRetColumnData)
        {


            CStruct xRoot = new CStruct();
            CStruct xWork;
            CStruct xNode;
            xRoot.Initialize("TotalsConfiguration");

            xWork = xRoot.CreateSubStruct("TotalByRole");
            xWork.CreateBooleanAttr("Value", m_use_role);

            xWork = xRoot.CreateSubStruct("RoleMode");
            xWork.CreateIntAttr("Value", m_role_mode);

            xWork = xRoot.CreateSubStruct("EnableHeatMap");
            xWork.CreateBooleanAttr("Value", m_use_heatmap);

            xWork = xRoot.CreateSubStruct("EnableHeatField");
            xWork.CreateIntAttr("Value", m_use_heatmapID);

            xWork = xRoot.CreateSubStruct("HeatFieldColour");
            xWork.CreateIntAttr("Value", m_use_heatmapColour);

            if (bRetColumnData == true)
            {

                xNode = xRoot.CreateSubStruct("ColumnOptions");

                foreach (RPATGRow otg in TotGeneral)
                {
                    xWork = xNode.CreateSubStruct("ColumnOption");
                    xWork.CreateIntAttr("ColumnID", otg.fid);
                    xWork.CreateBooleanAttr("Selected", otg.bUse);
                    xWork.CreateStringAttr("Name", otg.DisplayName);
                }

                foreach (RPATGRow otg in TotCapacity)
                {
                    xWork = xNode.CreateSubStruct("ColumnOption");
                    xWork.CreateIntAttr("ColumnID", otg.fid);
                    xWork.CreateBooleanAttr("Selected", otg.bUse);
                    xWork.CreateStringAttr("Name", otg.Name);
                }
            }

            xNode = xRoot.CreateSubStruct("SelectedOrderItems");
            foreach (RPATGRow otg in TotSelectedOrder)
            {
                xWork = xNode.CreateSubStruct("Item");
                xWork.CreateIntAttr("ItemID", otg.fid);
            }


            return xRoot.XML();


        }

        public string SetTotalsData(CStruct xData)
        {
            CStruct xTotbyRole = xData.GetSubStruct("TotalByRole");
            CStruct xRoleMode = xData.GetSubStruct("RoleMode");
            CStruct xUseHeatMap = xData.GetSubStruct("EnableHeatMap");
            CStruct xHeatMapID = xData.GetSubStruct("EnableHeatField");
            CStruct xSelOrder = xData.GetSubStruct("SelectedOrderItems");
            CStruct xSelColour = xData.GetSubStruct("HeatFieldColour");
            int heatmapcol = 0;



            if (xTotbyRole != null)
                m_use_role = xTotbyRole.GetIntAttr("Value", 0) == 1;

            if (xRoleMode != null)
                m_role_mode = xRoleMode.GetIntAttr("Value", 1);

            if (xUseHeatMap != null)
                m_use_heatmap = xUseHeatMap.GetIntAttr("Value", 0) == 1;

            if (xHeatMapID != null)
                m_use_heatmapID = xHeatMapID.GetIntAttr("Value", 0);

            if (xSelColour != null)
                m_use_heatmapColour = xSelColour.GetIntAttr("Value", 0);

            if (xSelOrder != null)
            {

                foreach (RPATGRow otg in TotGeneral)
                {
                    otg.bUse = false;
                }

                foreach (RPATGRow otg in TotCapacity)
                {
                    otg.bUse = false;

                }

                List<CStruct> cln = xSelOrder.GetChildNodeCollection();

                int i = 0;

                if (!(cln == null || cln.Count == 0))
                {


                    TotSelectedOrder = new List<RPATGRow>();

                    List<RPATGRow> uselist = null;

                    foreach (CStruct oNode in cln)
                    {
                        int tid = oNode.GetIntAttr("ItemID");
                        ++i;

                        if (tid > 0)
                            uselist = TotCapacity;
                        else
                            uselist = TotGeneral;

                        foreach (RPATGRow otg in uselist)
                        {
                            if (otg.fid == tid)
                            {
                                otg.bUse = true;
                                TotSelectedOrder.Add(otg);

                                if (m_use_heatmap && otg.fid == m_use_heatmapID)
                                    heatmapcol = i;

                                break;
                            }

                        }

                    }
                }

            }

            CStruct xRoot = new CStruct();
            CStruct xNode;
            xRoot.Initialize("TotalsGridSetting");


            NewRedrawTotals();

            xNode = xRoot.CreateSubStruct("HeatMap");
            xNode.CreateIntAttr("HeapMapSubCol", heatmapcol);

            int iTotCol = 0;
            foreach (RPATGRow ot in TotSelectedOrder)
            {
                ++iTotCol;
                if (ot.fid == 0)
                {
                    break;
                }
            }


            xNode.CreateIntAttr("HeapMapTotalsCol", iTotCol);
            xNode.CreateStringAttr("HeatMapText", m_heatmap_text);



            return xRoot.XML();
        }


        public string GetDetailsData()
        {
            CStruct xRoot = new CStruct();
            CStruct xWork;

            xRoot.Initialize("WorkDetails");

            xWork = xRoot.CreateSubStruct("ActualWork");
            xWork.CreateBooleanAttr("Value", chkActual);

            xWork = xRoot.CreateSubStruct("ProposedWork");
            xWork.CreateBooleanAttr("Value", chkOpenRequire);

            xWork = xRoot.CreateSubStruct("ScheduledWork");
            xWork.CreateBooleanAttr("Value", ckkMSPF);

            xWork = xRoot.CreateSubStruct("CommittedWork");
            xWork.CreateBooleanAttr("Value", chkCommit);

            xWork = xRoot.CreateSubStruct("PersonalWork");
            xWork.CreateBooleanAttr("Value", chkNonWork);

            xWork = xRoot.CreateSubStruct("OpenRequestWork");
            xWork.CreateBooleanAttr("Value", chkOpenRequest);

            xWork = xRoot.CreateSubStruct("NegMode");
            xWork.CreateIntAttr("Value", m_cResVals.CommitmentsOpMode);

            xWork = xRoot.CreateSubStruct("ShowPersonal");
            xWork.CreateIntAttr("Value", (m_cResVals.lRequestNo != (int)ResCenterRequest.ResourceValuesForPIs ? 1 : 0));

            xWork = xRoot.CreateSubStruct("ShowOpenReq");

            int xOpen = 0;

            if (m_hadopen_reqs == true)
            {
                xOpen = 1;
            }

            xWork.CreateIntAttr("Value", xOpen);


            return xRoot.XML();

        }

        public void SetDetailsData(CStruct xData)
        {
            CStruct xAWork = xData.GetSubStruct("ActualWork");
            CStruct xPWork = xData.GetSubStruct("ProposedWork");
            CStruct xSWork = xData.GetSubStruct("ScheduledWork");
            CStruct xCWork = xData.GetSubStruct("CommittedWork");
            CStruct xNWork = xData.GetSubStruct("PersonalWork");
            CStruct xOReq = xData.GetSubStruct("OpenRequestWork");

            if (xAWork != null)
                chkActual = xAWork.GetIntAttr("Value", 0) == 1;

            if (xPWork != null)
                chkOpenRequire = xPWork.GetIntAttr("Value", 0) == 1;

            if (xSWork != null)
                ckkMSPF = xSWork.GetIntAttr("Value", 0) == 1;

            if (xCWork != null)
                chkCommit = xCWork.GetIntAttr("Value", 0) == 1;

            if (xNWork != null)
                chkNonWork = xNWork.GetIntAttr("Value", 0) == 1;

            if (xOReq != null)
                chkOpenRequest = xOReq.GetIntAttr("Value", 0) == 1;

            ReDrawGrid();

        }

        public void SetDisplayMode(CStruct xData)
        {

            if (xData != null)
            {

                var iMode = xData.GetIntAttr("Mode", 0);

                if (iMode != 0)
                    m_DispMode = iMode - 1;
                else
                    m_DispMode = 0;
            }


            ReDrawGrid();

        }

        public string GetDisplayMode()
        {

            CStruct xRoot = new CStruct();

            xRoot.Initialize("WorkDisplayMode");
            xRoot.CreateIntAttr("Mode", m_DispMode + 1);

            return xRoot.XML();


        }
        public void SetSelectedForRows(CStruct xData)
        {
            bool bSel = xData.GetBooleanAttr("value", false);

            List<CStruct> rows = xData.GetList("Row");
            if (rows != null)
            {
                foreach (CStruct rowval in rows)
                {
                    string xrowid = rowval.GetStringAttr("rowid", "");
                    int rowid;
                    if (xrowid == "")
                        rowid = 0;
                    else
                        rowid = int.Parse(xrowid.Substring(1));


                    if (rowid >= 0 && rowid < m_clnsort.Count)
                    {
                        clsResXData oDet = m_clnsort[rowid];
                        oDet.bTotalize = bSel;
                    }
                }
            }
            NewRedrawTotals();

        }


        public void SetRADragRows(CStruct xData)
        {
            int fromCol = xData.GetIntAttr("fromCol");
            int toCol = xData.GetIntAttr("toCol");

            List<CStruct> rows = xData.GetList("Row");

            clsResXDragCloneList clonedlist = new clsResXDragCloneList();

            if (rows != null)
            {
                foreach (CStruct rowval in rows)
                {
                    string xrowid = rowval.GetStringAttr("rowid", "");
                    int rowid;
                    if (xrowid == "")
                        rowid = 0;
                    else
                        rowid = int.Parse(xrowid.Substring(1));


                    if (rowid >= 0 && rowid < m_clnsort.Count)
                    {
                        clsResXData oDet = m_clnsort[rowid];

                        clsRPAFTEConv ofte;

                        clsResXDragClone odetclone;

                        oDet.CloneArrayData(out odetclone);
                        odetclone.m_oDet = oDet;
                        clonedlist.m_cloneList.Add(odetclone);
                        ++oDet.iDragCnt;

                        m_fte_conv.TryGetValue(oDet.CostCat, out ofte);
                        oDet.ShuntData(fromCol, toCol, ofte, m_DispMode);
                    }
                }
            }

            m_drag_stack.Push(clonedlist);

            NewRedrawTotals();
        }

        public void UndoRADragRows()
        {

            clsResXDragCloneList clonedlist = new clsResXDragCloneList();
            clsResXData oDet;

            if (m_drag_stack.Count == 0)
                return;

            clonedlist = m_drag_stack.Pop();

            if (clonedlist.m_cloneList.Count == 0)
                return;

            foreach (clsResXDragClone odetclone in clonedlist.m_cloneList)
            {
                oDet = odetclone.m_oDet;
                --oDet.iDragCnt;
                oDet.ResoreClonedArrayData(odetclone);
            }

            NewRedrawTotals();
        }

        public void SetFilteredForRows(CStruct xData)
        {

            foreach (clsResXData od in m_clnsort)
                od.bFilteredOut = false;

            List<CStruct> rows = xData.GetList("Row");
            if (rows != null)
            {
                foreach (CStruct rowval in rows)
                {
                    string xrowid = rowval.GetStringAttr("rowid", "");
                    int rowid;
                    if (xrowid == "")
                        rowid = 0;
                    else
                        rowid = int.Parse(xrowid.Substring(1));


                    if (rowid >= 0 && rowid < m_clnsort.Count)
                    {
                        clsResXData oDet = m_clnsort[rowid];
                        oDet.bFilteredOut = true;
                    }
                }
            }
            NewRedrawTotals();

        }

        private string PrepareText(string sText)
        {

            return "'" + sText.Replace("'", "''") + "'";
        }


        private void AddElement(XmlDocument oXMLDocument, XmlNode oParent, string sName, string sValue)
        {
            XmlNode oXMLElement;
            oXMLElement = oXMLDocument.CreateElement(sName);
            oXMLElement.InnerText = sValue;
            oParent.AppendChild(oXMLElement);
        }


        private RPATGRow CreatetgLayout(bool bUse, int fid, string name, string displayname)
        {

            RPATGRow tglayout = new RPATGRow();

            tglayout = new RPATGRow();
            tglayout.bUse = bUse;
            tglayout.fid = fid;
            tglayout.Name = name;
            tglayout.DisplayName = (displayname == "" ? name : displayname);
            return tglayout;
        }

        public string GetTargetRGBData()
        {
            CStruct xRoot = new CStruct();
            CStruct xTarget;
            int maxid = -100;

            xRoot.Initialize("Targets");

            foreach (clsViewTargetColours oTar in m_cResVals.TargetColors.Values)
            {
                xTarget = xRoot.CreateSubStruct("Target");
                xTarget.CreateIntAttr("ID", oTar.ID);
                xTarget.CreateIntAttr("RGB", oTar.rgb_val);
                xTarget.CreateDoubleAttr("Lowval", oTar.low_val);
                xTarget.CreateDoubleAttr("Hival", oTar.high_val);
                if (oTar.ID > maxid && oTar.high_val != 0)
                    maxid = oTar.ID;
            }

            xTarget = xRoot.CreateSubStruct("MaxTargetID");
            xTarget.CreateIntAttr("Value", maxid);


            return xRoot.XML();

        }

        private clsResFullDAta CreateNewResFullDAta()
        {

            clsResFullDAta rFull = new clsResFullDAta();

            rFull.tot_Totals.SetUpPeriods(m_num_per);
            rFull.tot_actual.SetUpPeriods(m_num_per);
            rFull.tot_proposed.SetUpPeriods(m_num_per);
            rFull.tot_committed.SetUpPeriods(m_num_per);
            rFull.tot_personel.SetUpPeriods(m_num_per);
            rFull.tot_scheduled.SetUpPeriods(m_num_per);
            rFull.tot_avail.SetUpPeriods(m_num_per);

            return rFull;
        }

        public void StashViews(string sViews)
        {
            m_viewsxml = sViews;
        }

        public string ApplyServerSideViewSettings(string guid)
        {
            CStruct xRoot = new CStruct();
            List<CStruct> xviews;
            CStruct xReply = new CStruct();

            string sret = "";

            if (m_viewsxml == "")
                return "";

            if (xRoot.LoadXML(m_viewsxml) == false)
                return "";

            xviews = xRoot.GetList("View");

            if (xviews == null)
                return "";

            xReply.Initialize("ViewData");


            foreach (CStruct oNode in xviews)
            {
                if (oNode.GetStringAttr("ViewGUID", "") == guid)
                {

                    CStruct OtherData = oNode.GetSubStruct("OtherData");

                    if (OtherData != null)
                    {
                        CStruct oWork = OtherData.GetSubStruct("TotalsConfiguration");
                        if (oWork != null)
                            sret = SetTotalsData(oWork);

                        xReply.AppendXML(sret);

                        oWork = OtherData.GetSubStruct("WorkDetails");
                        if (oWork != null)
                            SetDetailsData(oWork);


                        oWork = OtherData.GetSubStruct("WorkDisplayMode");
                        if (oWork != null)
                            SetDisplayMode(oWork);

                        xReply.AppendXML(GetDisplayMode());

                    }


                    xReply.AppendXML(GetDetailsData());
                    break;
                }
            }
            return xReply.XML();
        }


        public void RemoveCapacityScenario(int csid)
        {
            List<RPATGRow> newTotscln = new List<RPATGRow>();

            foreach (RPATGRow otg in TotCapacity)
            {
                if (otg.fid != csid)
                    newTotscln.Add(otg);

            }

            TotCapacity = newTotscln;

            newTotscln = new List<RPATGRow>();

            foreach (RPATGRow otg in TotSelectedOrder)
            {
                if (otg.fid != csid)
                    newTotscln.Add(otg);
                else if (m_use_heatmapID == csid)
                    m_use_heatmapID = 0;
            }

            TotSelectedOrder = newTotscln;

            Dictionary<int, clsEPKItem> newCapTar = new Dictionary<int, clsEPKItem>();


            if (m_cResVals.CapacityTargets != null)
            {
                foreach (clsEPKItem oi in m_cResVals.CapacityTargets.Values)
                {
                    if (oi.ID != csid)
                        newCapTar.Add(oi.ID, oi);
                }
            }

            m_cResVals.CapacityTargets = newCapTar;

            List<clsCapacityValue> newCapVal = new List<clsCapacityValue>();

            if (m_cResVals.CapacityTargetValues != null)
            {

                foreach (clsCapacityValue oCapacityValue in m_cResVals.CapacityTargetValues)
                {
                    if (oCapacityValue.ID != csid)
                        newCapVal.Add(oCapacityValue);
                }
            }
            m_cResVals.CapacityTargetValues = newCapVal;
            string s = "";

            PopulateInternals(out s);
            ReDrawGrid();
        }

        public string PrepareCSGrid(string sXML)
        {
            CStruct xRoot = new CStruct();
            CStruct xPeriods;
            CStruct xCalendar;
            List<CStruct> clnPeriods;
            CStruct xCCRoles;
            List<CStruct> clnCC;

            CStruct xRetRoot = new CStruct();
            xRetRoot.Initialize("CS_Data");
            CStruct xRetPeriods = xRetRoot.CreateSubStruct("Periods");
            CStruct xRetCCs = xRetRoot.CreateSubStruct("CostCategories");
            CStruct xRetCapScens = xRetRoot.CreateSubStruct("CapScenRows");

            xRoot.LoadXML(sXML);
            xCalendar = xRoot.GetSubStruct("Calendar");
            xPeriods = xCalendar.GetSubStruct("Periods");
            clnPeriods = xPeriods.GetList("Period");

            int iCSCalID = xCalendar.GetIntAttr("CalID");

            m_cs_perlist = new List<CPeriod>();

            foreach (CStruct xPer in clnPeriods)
            {
                CPeriod oPer = new CPeriod();
                CStruct xRetPeriod = xRetPeriods.CreateSubStruct("Period");

                oPer.PeriodID = xPer.GetIntAttr("ID");
                oPer.PeriodName = xPer.GetStringAttr("Name");

                xRetPeriod.CreateIntAttr("ID", oPer.PeriodID);
                xRetPeriod.CreateStringAttr("Name", oPer.PeriodName);
                m_cs_perlist.Add(oPer);
            }

            xRetRoot.CreateIntAttr("PeriodCount", m_cs_perlist.Count);

            xCCRoles = xRoot.GetSubStruct("CostCategoryRoles");
            clnCC = xCCRoles.GetList("CostCategoryRole");

            m_cs_editdata = new Dictionary<int, clsResxAvail>();

            clsResxAvail oRA;


            for (int i = clnCC.Count - 1; i >= 0; i--)
            {
                CStruct xCC = clnCC[i];
                CStruct xRetCC = xRetCCs.CreateSubStruct("CostCategory");
                int ccid = xCC.GetIntAttr("ID");
                xRetCC.CreateIntAttr("ID", ccid);
                xRetCC.CreateStringAttr("Name", xCC.GetStringAttr("Name"));

                if (m_cs_editdata.TryGetValue(ccid, out oRA) == false)
                {
                    oRA = new clsResxAvail();
                    oRA.SetUpPeriods(m_cs_perlist.Count);
                    oRA.CostCat = ccid;
                    oRA.DeptID = xCC.GetIntAttr("Level");
                    oRA.Name = xCC.GetStringAttr("Name");
                    m_cs_editdata.Add(ccid, oRA);
                }

                double[] dft = new double[m_cs_perlist.Count];

                for (int j = 0; j < m_cs_perlist.Count; j++)
                    dft[j] = 0;

                CStruct xwp = xCC.GetSubStruct("Periods");
                CStruct xfe = xCC.GetSubStruct("FTEToHours");

                if (xwp != null && xfe != null)
                {
                    string per = xCC.GetString("Periods");
                    string fte = xCC.GetString("FTEToHours");

                    per = per.Replace(",", " ").Trim();
                    fte = fte.Replace(",", " ").Trim();


                    while (per != "")
                    {
                        int iper = RPConstants.StripNum(ref per);
                        double dFte = RPConstants.StripNum(ref fte);

                        dFte /= 100;

                        if (iper >= 1 && iper <= m_cs_perlist.Count)
                            dft[iper - 1] = dFte;
                    }


                }



                for (int j = 0; j < m_cs_perlist.Count; j++)
                {
                    CStruct xFTE = xRetCC.CreateSubStruct("FTEs");
                    xFTE.CreateDoubleAttr("Value", dft[j]);
                }

            }

            CStruct xCapScen = xRoot.GetSubStruct("CS_Values");
            List<CStruct> xCapVal = xCapScen.GetList("CS_Value");

            if (xCapVal == null)
                xCapVal = new List<CStruct>();

            foreach (CStruct xVal in xCapVal)
            {
                int iRoleID = xVal.GetIntAttr("Role_ID");

                if (m_cs_editdata.TryGetValue(iRoleID, out oRA) == true)
                {

                    int iPer = xVal.GetIntAttr("Per_ID");

                    if (iPer >= 1 && iPer <= m_cs_perlist.Count)
                    {
                        oRA.addvarr(iPer, xVal.GetDoubleAttr("Hours", 0));
                        oRA.addftarr(iPer, xVal.GetDoubleAttr("FTEs", 0) / 10000);

                    }
                }
            }

            foreach (clsResxAvail oRxA in m_cs_editdata.Values)
            {
                CStruct xRetCapScen = xRetCapScens.CreateSubStruct("CapScenRow");
                xRetCapScen.CreateIntAttr("ID", oRxA.CostCat);

                for (int i = 1; i <= m_cs_perlist.Count; i++)
                {
                    CStruct xHrs = xRetCapScen.CreateSubStruct("Hours");
                    xHrs.CreateDoubleAttr("Value", oRxA.getvarr(i));
                }

                for (int i = 1; i <= m_cs_perlist.Count; i++)
                {
                    CStruct xFTE = xRetCapScen.CreateSubStruct("FTEs");
                    xFTE.CreateDoubleAttr("Value", oRxA.getftarr(i));
                }

            }



            if (m_useingCal == iCSCalID)
            {
                Dictionary<int, clsResFullDAta> cln = m_ccrolelist;
                clsResFullDAta oRole = null;
                CStruct xRetroledatas = xRetRoot.CreateSubStruct("CapScenRoleDatas");

                for (int i = clnCC.Count - 1; i >= 0; i--)
                {
                    CStruct xCC = clnCC[i];
                    int ccid = xCC.GetIntAttr("ID");


                    if (cln.TryGetValue(ccid, out oRole) == true)
                    {


                        oRole.CreateTotals(chkCommit, chkNonWork, ckkMSPF, chkActual, chkOpenRequest);
                        CStruct xRetroledata = xRetroledatas.CreateSubStruct("CapScenRoleData");
                        xRetroledata.CreateIntAttr("RoleID", ccid);

                        for (int xj = 1; xj <= m_num_per; xj++)
                        {
                            CStruct xHrs = xRetroledata.CreateSubStruct("Hours");
                            xHrs.CreateDoubleAttr("Value", oRole.tot_Totals.getvarr(xj));
                        }
                        for (int xj = 1; xj <= m_num_per; xj++)
                        {
                            CStruct xFtes = xRetroledata.CreateSubStruct("FTE");
                            xFtes.CreateDoubleAttr("Value", oRole.tot_Totals.getftarr(xj));
                        }

                    }


                }

            }

            return xRetRoot.XML();
        }

        public string GetCapacityScenarioGrid()
        {

            RPATargetGrid oGrid = new RPATargetGrid();
            string s;
            oGrid.InitializeGridLayout();
            int i = 0;



            foreach (CPeriod period in m_cs_perlist)
            {
                i++;
                oGrid.AddPeriodColumn(period.PeriodID.ToString(), period.PeriodName, false);
            }

            oGrid.FinalizeGridLayout();
            oGrid.InitializeGridData();

            i = 0;

            foreach (clsResxAvail oDet in m_cs_editdata.Values)
            {
                oGrid.AddDetailRow(oDet, ++i, false, m_cs_perlist.Count);
            }

            s = oGrid.GetString();

            return s;



        }

        public string GetLegendGrid()
        {

            RPALegendGrid oGrid = new RPALegendGrid();
            string s;
            oGrid.InitializeGridLayout();
            int rgb = 0;
            string sRGB = "";


            foreach (clsViewTargetColours otar in m_cResVals.TargetColors.Values)
            {

                rgb = otar.rgb_val;

                if (rgb == -1)
                    sRGB = "";
                else
                    sRGB = "RGB(" + (rgb & 0xFF).ToString() + "," + ((rgb & 0xFF00) >> 8).ToString() + "," + ((rgb & 0xFF0000) >> 16).ToString() + ")";

                oGrid.AddRow(otar.Desc, sRGB);

            }


            s = oGrid.GetString();

            return s;
        }





        public void StashCapacityReloadXML(string sXML)
        {
            m_reload_cs_data = sXML;
        }

        public string GetCapacityReloadXML()
        {
            return m_reload_cs_data;
        }

        public string RPASaveDraggedData()
        {
            CStruct xRoot = new CStruct();
            xRoot.Initialize("RPADraggedCMTData");
            CStruct xRow;
            CStruct xPer;
            bool bFnd = false;


            foreach (clsResXData oDet in m_clnsort)
            {

                if (oDet.bDragged == true)
                {
                    oDet.bDragged = false;
                    xRow = xRoot.CreateSubStruct("CMT");
                    xRow.CreateIntAttr("CMT_UID", oDet.UID);
                    bFnd = true;

                    for (int i = 1; i <= m_cResVals.Periods.Count; i++)
                    {
                        if (oDet.WrkHours[i] != 0 || oDet.FTEVals[i] != 0)
                        {
                            xPer = xRow.CreateSubStruct("Period");
                            xPer.CreateIntAttr("PeriodID", i + m_StartPerOffset - 1);
                            xPer.CreateDoubleAttr("Hours", oDet.WrkHours[i] * 100);
                            xPer.CreateDoubleAttr("FTES", oDet.FTEVals[i] * 10000);
                        }
                    }
                }
            }

            if (bFnd == false)
                return "";



            return xRoot.XML();

        }

        public string GetPMOAdmin()
        {
            return m_pmo_admin.ToString();
        }

        public void GetStartFinishDataPeriods(out int istart, out int ifinish)
        {
            if (m_firstperiod_data == m_num_per && m_lastperiod_data == 0)
                m_firstperiod_data = 1;

            if (m_firstperiod_data == 0)
                m_firstperiod_data = 1;

            if (m_lastperiod_data == 0)
                m_lastperiod_data = m_num_per;

            if (m_lastperiod_data < m_firstperiod_data)
            {
                int i = m_firstperiod_data;
                m_firstperiod_data = m_lastperiod_data;
                m_lastperiod_data = i;
            }

            istart = m_firstperiod_data;
            ifinish = m_lastperiod_data;




        }


        public string GetHeatmapText()
        {
            return m_heatmap_text;
        }

        public string GetInitialParamXML()
        {
            return m_sParamXML;
        }



        internal void ReplaceCSData(clsResourceValues resValues)
        {
            m_cResVals.CapacityTargets = resValues.CapacityTargets;
            m_cResVals.CapacityTargetValues = resValues.CapacityTargetValues;

            string s = "";

            PopulateInternals(out s);
            ReDrawGrid();
        }

        private string ResolvePIName(int pid)
        {
            clsPIData oPIData;
            if (m_cln_pis.TryGetValue(pid, out oPIData) == true)
                return oPIData.PIName;

            return "";
        }

        public string GetRoleScrenarioData(string sXML)
        {
            CStruct xRoot = new CStruct();
            CStruct xCCRoles;
            List<CStruct> clnCC;

            xRoot.LoadXML(sXML);

            xCCRoles = xRoot.GetSubStruct("CostCategoryRoles");
            clnCC = xCCRoles.GetList("CostCategoryRole");

            Dictionary<int, clsResFullDAta> cln = m_ccrolelist;
            clsResFullDAta oRole = null;


            CStruct xRetRoot = new CStruct();
            xRetRoot.Initialize("CurrentCSData");

            for (int i = clnCC.Count - 1; i >= 0; i--)
            {
                CStruct xCC = clnCC[i];
                int ccid = xCC.GetIntAttr("ID");
                CStruct xRetroledata;

                if (cln.TryGetValue(ccid, out oRole) == true)
                {


                    oRole.CreateTotals(chkCommit, chkNonWork, ckkMSPF, chkActual, chkOpenRequest);

                    double hrs;
                    double ftes;

                    for (int xj = 1; xj <= m_num_per; xj++)
                    {

                        hrs = oRole.tot_Totals.getvarr(xj);
                        ftes = oRole.tot_Totals.getftarr(xj);

                        if (hrs != 0 || ftes != 0)
                        {
                            xRetroledata = xRetRoot.CreateSubStruct("CS_Value");
                            xRetroledata.CreateIntAttr("Per_ID", xj);
                            xRetroledata.CreateIntAttr("Role_ID", ccid);
                            xRetroledata.CreateDoubleAttr("Hours", hrs);
                            xRetroledata.CreateDoubleAttr("FTEs", ftes * 100);
                        }

                    }
                }

            }

            return xRetRoot.XML();

        }

        public bool GetNegotiationMode()
        {
            return m_neg_mode;
        }

    }

}
