using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Linq;
using ModelDataCache;
using WorkEnginePPM;
using CostDataValues;
using PortfolioEngineCore;

namespace CADataCache
{
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
    [Serializable()]
    public class clsColDisp
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
        public bool m_def_fld;
        public bool m_unselectable;


    }
    [Serializable()]
    class CATGRow
    {
        public bool bUse;
        public int fid;
        public string Name;
        public string DisplayName;
        public int index;
    }

    [Serializable()]
    class CATotRow
    {
        public clsDetailRowData[] m_totals;
        public clsDetailRowData[] m_targets;
        public bool bUsed;

        public CATotRow(int arrsize, int tarrsize, int persize)
        {
            m_totals = new clsDetailRowData[arrsize + 1];

            for (int i = 1; i <= arrsize; i++)
                m_totals[i] = new clsDetailRowData(persize);

            m_targets = new clsDetailRowData[tarrsize + 1];

            for (int i = 1; i <= tarrsize; i++)
                m_targets[i] = new clsDetailRowData(persize); 
        }
    }
    [Serializable()]
    public class CostAnalyzerDataCache
    {
        clsCostData m_clsda = null;
        private List<clsColDisp> m_topgridcln = null;
        private List<clsColDisp> m_bottomgridcln = null;
        private bool[] m_cust_Defn = null;
        private int[] m_cust_full = null;
        private clsCustomFieldData[] m_cust_ocf = null;
        private Dictionary<int, clsListItemData>[] m_cust_lk = null;
        private List<CATGRow> TGStandard = null;
        private List<CATGRow> BGStandard = null;

        private List<clsDetailRowData> m_clnsort = null;

        private int m_DispMode = 1;


        private string m_heatmap_text = "";

        private bool   bShowFTEs = false;
        private bool   bUseQTY = false;
        private bool   bUseCosts = true;
        private bool  m_show_rhs_dec_costs = true;

        private List<clsDataItem> m_TotalRoot = new List<clsDataItem>();
        private Dictionary<string, clsDetailRowData> m_total_dets = null, m_target_dets = null;
        private Dictionary<string, CATotRow> m_total_rows = null;

        private List<clsDataItem> m_CTCmpRoot = new List<clsDataItem>();
        private  Dictionary<string, clsDetailRowData> m_targetdata = new Dictionary<string, clsDetailRowData>();
        private string m_tarnames = "";
        private int m_apply_target = 0;
        private bool m_showremaining = false;
        private string m_viewsxml = "";

        private List<CATGRow> TotGeneral;
        private List<CATGRow> TotSelectedOrder;

        private bool m_use_heatmap = false;
        private int m_use_heatmapID = -1;
        private int m_use_heatmapColour = 1;
        private int m_heatmapcol = -1;
        private string m_heatmaptext = "";
        private string m_CostCatjsonMenu = "";
        private string m_CostTypejsonMenu = "";

        private List<clsDetailRowData> m_editTargetList = new List<clsDetailRowData>();

 
        public CostAnalyzerDataCache()
        {


        }

        public void GrabCAData(clsCostData clsda)
        {

            m_clsda = clsda;
            bool bdefsel = true;

            foreach (clsDataItem oItem in m_clsda.m_CostTypes.Values)
            {
                oItem.bSelected = bdefsel;
                bdefsel = false;
            }


            setupdispcolns();
            ReDrawGrid();

        }
        private void setupdispcolns()
        {
            int tempj;
            clsCustomFieldData xocf;
            m_cust_Defn = new bool[11];
            m_cust_full = new int[11];
            m_cust_ocf = new clsCustomFieldData[11];
            m_cust_lk = new Dictionary<int, clsListItemData>[11];

            TGStandard = new List<CATGRow>();

            TGStandard.Add(CreatetgLayout(true, 0, " ", "",0));

            BGStandard = new List<CATGRow>();

            BGStandard.Add(CreatetgLayout(true, 0, " ", "", 0));


            for (int xj = 1; xj <= 10; xj++)
                m_cust_Defn[xj] = false;


            foreach (clsCustomFieldData ocf in m_clsda.m_CustFields.Values)
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

            m_topgridcln = new List<clsColDisp>();
            m_bottomgridcln = new List<clsColDisp>();
            TotGeneral = new List<CATGRow>();
            TotSelectedOrder = new List<CATGRow>();

            TotGeneral.Add(CreatetgLayout(true, 0, "Totals", "Totals (from Top Grid)", 0));
            TotSelectedOrder.Add(TotGeneral[0]);
            int i = 0;
            foreach (clsDataItem oItem in m_clsda.m_CostTypes.Values)
            {
                ++i;
                TotGeneral.Add(CreatetgLayout(false, oItem.UID, oItem.Name, oItem.Name, i));
            }
            
            i = 0;
            foreach (clsDataItem oItem in m_clsda.m_targets.Values)
            {
                --i;
                oItem.ID = i;
                TotGeneral.Add(CreatetgLayout(false, -oItem.UID, oItem.Name, oItem.Name, i));
            }


            clsColDisp orxd;
            i = 0;

            AddColEntry("Portfolio Item", (int) FieldIDs.PI_FID, true, true, true, true);
            AddColEntry("Start", (int)FieldIDs.SD_FID, false, false, false, false);
            AddColEntry("Finish", (int)FieldIDs.FD_FID, false, false, false, false);


            AddColEntry("Cost Types", (int)FieldIDs.CT_FID, true, true, false, true);

            AddColEntry("Cost Categories", (int)FieldIDs.BC_FID, true, true, false, true);
            AddColEntry("Category", (int)FieldIDs.CAT_FID, true, false, false, true);

            AddColEntry("Role", (int)FieldIDs.BC_ROLE, true, false, false, true);
            AddColEntry("Major Category", (int)FieldIDs.MC_FID, false, false, false, false);
            AddColEntry("Full Cost Category", (int)FieldIDs.FULLC_FID, false, false, false, false);


             AddColEntry("Full Category", (int)FieldIDs.FULLCAT_FID, true, false, false, false);

            AddColEntry("Total Cost", (int)FieldIDs.FTOT_FID, true, false, false, false);
            AddColEntry("Display Cost", (int)FieldIDs.DTOT_FID, true, false, false, false);



            for (int xo = 21; xo <= 25; xo++)
            {
                if (m_cust_Defn[xo - 20] == true)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                    {
                        AddColEntry(xocf.Name, 11800 + xo - 20, true, false, false, false);
                    }

                }
            }

            for (int xo = 26; xo <= 30; xo++)
            {
                if (m_cust_Defn[xo - 20] == true)
                {
                    xocf = m_cust_ocf[xo - 20];

                    if (xocf != null)
                    {
                        AddColEntry(xocf.Name, 11810 + xo - 25, true, false, false, false);
                    }
                }
            }


            for (int xo = 1; xo <= m_clsda.m_Use_extra; xo++)
            {
                AddColEntry(m_clsda.m_ExtraFieldNames[xo], (int)FieldIDs.PI_USE_EXTRA + xo, true, false, false, false);
            }

            tempj = 0;

            foreach (clsPIData oPI in m_clsda.m_PIs.Values)
            {

                ++tempj;

                oPI.Internal_ID = tempj;


                for (int f = (int) FieldIDs.PI_USE_EXTRA + 1;
                     f <= (int) FieldIDs.PI_USE_EXTRA + (int) FieldIDs.MAX_PI_EXTRA;
                     ++f)
                {
                    if (m_clsda.m_ExtraFieldTypes[f - (int) FieldIDs.PI_USE_EXTRA] != 0)
                    {
                        oPI.m_PI_Format_Extra_data[f - (int) FieldIDs.PI_USE_EXTRA] =
                            FormatExtraDisplay(oPI.m_PI_Extra_data[f - (int) FieldIDs.PI_USE_EXTRA],
                                               m_clsda.m_ExtraFieldTypes[f - (int) FieldIDs.PI_USE_EXTRA]);
                    }
                    else
                        oPI.m_PI_Format_Extra_data[f - (int) FieldIDs.PI_USE_EXTRA] = "";
                }
            }

            clsPIData otempPI = null;
            string sKey;

            foreach (clsDetailRowData odet in (m_clsda.m_detaildata.Values))
            {
                sKey = odet.PROJECT_ID.ToString() + " " + odet.Scenario_ID.ToString();
                if ((m_clsda.m_PIs.TryGetValue(sKey, out otempPI) == false))
                {
                    odet.PROJECT_ID = 0;
                }
            else
                {

                    odet.m_PI_Format_Extra_data = otempPI.m_PI_Format_Extra_data;
                }


            }

            AddTotalEntry("Portfolio Items", (int)FieldIDs.PI_FID, true, 0);
            AddTotalEntry("Cost Types", (int)FieldIDs.CT_FID, false, 0);

            AddTotalEntry("Cost Categories", (int)FieldIDs.BC_FID, true, 0);
            AddTotalEntry("Category", (int)FieldIDs.CAT_FID, false, 0);
            AddTotalEntry("Role", (int)FieldIDs.BC_ROLE, false, 0);


            //for (int xo = 21; xo <= 25; xo++)
            //{
            //    if (m_cust_Defn[xo - 20] == true)
            //    {
            //        xocf = m_cust_ocf[xo - 20];

            //        if (xocf != null)
            //        {
            //            AddTotalEntry(xocf.Name, 11800 + xo - 20, false, 0);
            //        }

            //    }
            //}

            
            //for (int xo = 26; xo <= 30; xo++)
            //{
            //    if (m_cust_Defn[xo - 20] == true)
            //    {
            //        xocf = m_cust_ocf[xo - 20];

            //        if (xocf != null)
            //        {
            //            AddTotalEntry(xocf.Name, 11810 + xo - 25, false, 0);
            //        }
            //    }
            //}

            //for (int f = (int)FieldIDs.PI_USE_EXTRA + 1; f <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA; ++f)
            //{
            //    if (m_clsda.m_ExtraFieldTypes[f - (int)FieldIDs.PI_USE_EXTRA] != 0)
            //    {

            //        AddTotalEntry(m_clsda.m_ExtraFieldNames[f - (int)FieldIDs.PI_USE_EXTRA], m_clsda.m_fidextra[f - (int)FieldIDs.PI_USE_EXTRA], false, f);
  
            //    }
            //}

            foreach (clsDataItem oItem in m_clsda.m_CostTypes.Values)
            {

                clsDataItem oxItem = new clsDataItem();
                oxItem.Name = oItem.Name;
                oxItem.bSelected = false;
                oxItem.UID = oItem.UID;
                oxItem.ID = oItem.ID;
                m_CTCmpRoot.Add(oxItem); 
            }


            //foreach (clsDataItem oItem in m_clsda.m_targets.Values)
            //{

            //    clsDataItem oxItem = new clsDataItem();
            //    oxItem.Name = oItem.Name;
            //    oxItem.bSelected = false;
            //    oxItem.UID = -oItem.UID;
            //    oxItem.ID = -oItem.ID;
            //    m_CTCmpRoot.Add(oxItem);
            //}

            m_cust_Defn = new bool[11];
            m_cust_full = new int[11];
            m_cust_ocf = new clsCustomFieldData[11];
            m_cust_lk = new Dictionary<int, clsListItemData>[11];

            foreach (clsCustomFieldData ocf in m_clsda.m_CustFields.Values)
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

            
        }


        private void AddTotalEntry(string Name, int fid, bool bSel, int id)
        {
            clsDataItem oItem = new clsDataItem();
            oItem.Name = Name;
            oItem.bSelected = bSel;
            oItem.UID = fid;
            oItem.ID = id;
            m_TotalRoot.Add(oItem);
        }
        private void AddColEntry(string Name, int fid, bool bAddToTot, bool btdeffld, bool btunsel, bool bbdeffld)
        {
            clsColDisp orxd = new clsColDisp();

            orxd.m_dispname = Name;
            orxd.m_realname = orxd.m_dispname;
            orxd.m_col_hidden = false;
            orxd.m_id = fid;
            orxd.m_col = fid;
            orxd.m_acc = m_topgridcln.Count + 1;
            orxd.m_width = -1;
            orxd.m_type = 1;
            orxd.m_def_fld = btdeffld;
            orxd.m_unselectable = btunsel;

            m_topgridcln.Add(orxd);

            if (bAddToTot == true)
            {
                orxd = new clsColDisp();
                orxd.m_dispname = Name;
                orxd.m_realname = orxd.m_dispname;
                orxd.m_col_hidden = false;
                orxd.m_id = fid;
                orxd.m_col = fid;
                orxd.m_acc = m_bottomgridcln.Count + 1;
                orxd.m_width = -1;
                orxd.m_type = 1;

                orxd.m_def_fld = bbdeffld;
               
                m_bottomgridcln.Add(orxd);
            }
        }



        public string GetPeriodsData()
        {

            try
            {


                CStruct xRoot = new CStruct();
                xRoot.Initialize("Periods");

                foreach (clsPeriodData oPer in m_clsda.m_Periods.Values)
                {

                    CStruct xPeriod = xRoot.CreateSubStruct("Period");
                    xPeriod.CreateIntAttr("perID", oPer.PeriodID);
                    xPeriod.CreateStringAttr("perName", oPer.PeriodName);
                }

                return xRoot.XML();


            }
            catch (Exception ex)
            {
                return "";
            }

        }
        public string GetCostTypeNameData()
        {

            try
            {


                CStruct xRoot = new CStruct();
                xRoot.Initialize("CostTypes");

                foreach (clsDataItem oItem in m_clsda.m_CostTypes.Values)
                {

                    CStruct xCT = xRoot.CreateSubStruct("CostType");
                    xCT.CreateIntAttr("ID", oItem.UID);
                    xCT.CreateStringAttr("Name", oItem.Name);
                    xCT.CreateIntAttr("Sel", (oItem.bSelected ? 1 : 0));
                    xCT.CreateStringAttr("Event", "zCT" + oItem.UID.ToString());
                    xCT.CreateStringAttr("ButtonID", "chkCT" + oItem.UID.ToString());

                }

                return xRoot.XML();


            }
            catch (Exception ex)
            {
                return "";
            }

        }


        private void ReDrawGrid()
        {

            m_clnsort = new List<clsDetailRowData>();

            foreach (clsDetailRowData odet in m_clsda.m_detaildata.Values)
            {
                clsDataItem oItem;

                if (m_clsda.m_CostTypes.TryGetValue(odet.CT_ID, out oItem))
                {
                    if (oItem.bSelected)
                        m_clnsort.Add(odet);


                }

            }

            PrepareTotalsCollection();

            return;
        }

        private void PrepareTotalsCollection ()
        {

            m_total_dets = new Dictionary<string, clsDetailRowData>( );
            m_target_dets = new Dictionary<string, clsDetailRowData>( );
            m_total_rows = new Dictionary<string, CATotRow>();

            clsDetailRowData otot;
            CATotRow otrow;
            string sKey;

            foreach (clsDetailRowData odet in m_clsda.m_detaildata.Values)   //m_clnsort)
            {

                sKey = BuildTotalsKey(odet);

                if (m_total_dets.TryGetValue(sKey, out otot) == false)
                {
                    otot = new clsDetailRowData(m_clsda.m_max_period);
                    otot.m_uid = m_target_dets.Count + 1;
                    otot.lUoM = odet.lUoM;
                    otot.sUoM = odet.sUoM;
                    otot.m_PI_Format_Extra_data = new string[(int)cdFieldIDs.MAX_PI_EXTRA + 1];

                    for (int xi = 0; xi <= (int)cdFieldIDs.MAX_PI_EXTRA; xi++)
                        otot.m_PI_Format_Extra_data[xi] = "";

                    CopyOverTotFields(otot, odet, true);
                    otot.m_lev = 1;
                    m_target_dets.Add(sKey, otot);

                    otrow = new CATotRow(m_clsda.m_CostTypes.Count, m_clsda.m_targets.Count, m_clsda.m_max_period);

                    otot = new clsDetailRowData(m_clsda.m_max_period);
                    otrow.m_totals[0] = otot;

                    otot.m_uid = m_total_dets.Count + 1;
                    otot.lUoM = odet.lUoM;
                    otot.sUoM = odet.sUoM;

                    otot.m_PI_Format_Extra_data = new string[(int)cdFieldIDs.MAX_PI_EXTRA + 1];

                    for (int xi = 0; xi <= (int)cdFieldIDs.MAX_PI_EXTRA; xi++)
                        otot.m_PI_Format_Extra_data[xi] = "";

                    CopyOverTotFields(otot, odet, true);
                    otot.m_lev = 1;

                    m_total_dets.Add(sKey, otot);
                    m_total_rows.Add(sKey, otrow);
                }
                else
                {
                    if (otot.lUoM != odet.lUoM)
                        otot.lUoM = -1;

                    CopyOverTotFields(otot, odet, false);
                    
                }

                odet.m_total_to = otot.m_uid;
            }


            foreach (clsDetailRowData odet in m_clsda.m_detaildata.Values)
            {
                clsDetailRowData xdet;

                sKey = BuildTotalsKey(odet);


                if (m_total_rows.TryGetValue(sKey, out otrow) == true)
                {

                    if (odet.CT_ind != -1 && odet.CT_ind > 0)
                    {
                        try
                        {
                            xdet = otrow.m_totals[odet.CT_ind];

                            for (int i = 1; i <= m_clsda.m_max_period; i++)
                            {
                                xdet.zCost[i] += odet.zCost[i];
                                xdet.zValue[i] += odet.zValue[i];
                                xdet.zFTE[i] += odet.zFTE[i];
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                }



            }

            foreach (clsDetailRowData odet in m_clsda.m_targetdata.Values)
            {
                clsDetailRowData xdet;

                sKey = BuildTotalsKey(odet);


                if (m_total_rows.TryGetValue(sKey, out otrow) == true)
                {

                    if (odet.CT_ind != -1  && odet.CT_ind > 0)
                    {
                        try
                        {
                            xdet = otrow.m_targets[odet.CT_ind];

                            for (int i = 1; i <= m_clsda.m_max_period; i++)
                            {
                                xdet.zCost[i] += odet.zCost[i];
                                xdet.zValue[i] += odet.zValue[i];
                                xdet.zFTE[i] += odet.zFTE[i];
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                }



            }


            ProcessTotals();

        }

        private CATGRow CreatetgLayout(bool bUse, int fid, string name, string displayname, int indx)
        {

            CATGRow tglayout = new CATGRow();

            tglayout.bUse = bUse;
            tglayout.fid = fid;
            tglayout.Name = name;
            tglayout.index = indx;
            tglayout.DisplayName = (displayname == "" ? name : displayname);
            return tglayout;
        }

        public string GetTopGrid()
        {

            CATopGrid oGrid = new CATopGrid();
            string s;
            oGrid.InitializeGridLayout(m_topgridcln, 0);
            int i = 0;

            foreach (clsPeriodData oPer in m_clsda.m_Periods.Values)
            {
                i++;
                oGrid.AddPeriodColumn(oPer.PeriodID.ToString(), oPer.PeriodName, bShowFTEs, TGStandard, 0, bUseQTY, bUseCosts);
            }

            oGrid.FinalizeGridLayout();
            oGrid.InitializeGridData();
            //clsPIData oPIData;


            //displist = TGStandard;

            i = 0;
            foreach (clsDetailRowData oDet in m_clnsort)
            {

                oDet.rowid = i;

                oGrid.AddDetailRow(oDet, ++i, bShowFTEs, m_topgridcln, TGStandard, bUseQTY, bUseCosts, m_show_rhs_dec_costs);

                //    m_cln_pis.TryGetValue(oDet.ProjectID, out oPIData);
                //    oGrid.AddDetailRow(oDet, m_detdispcln, m_cResVals, m_maj_Cat_lookup, oPIData, ++i, m_DispMode, displist, m_cResVals.TargetColors);
            }

            s = oGrid.GetString();

            return s;



        }
 
        public string GetBottomGrid()
        {

            CABottomGrid oGrid = new CABottomGrid();
            string s;
            oGrid.InitializeGridLayout(m_bottomgridcln, 0);
            int i = 0;


            foreach (clsPeriodData oPer in m_clsda.m_Periods.Values)
            {
                i++;
                oGrid.AddPeriodColumn(oPer.PeriodID.ToString(), oPer.PeriodName, bShowFTEs, TotSelectedOrder, 0, bUseQTY, bUseCosts, m_use_heatmap);
            }

            oGrid.FinalizeGridLayout();
            oGrid.InitializeGridData();
            //clsPIData oPIData;


            bool bsrem = m_showremaining;

            if (m_apply_target == 0)
                bsrem = false;

            //displist = TGStandard;
            try
            {
                i = 0;
                foreach (CATotRow xTot in m_total_rows.Values)
                {
                    clsDetailRowData oDet = xTot.m_totals[0];
                    clsDetailRowData otDet = m_target_dets.ElementAt(i).Value;

                    oDet.rowid = i;



                    oGrid.AddDetailRow(oDet, otDet, m_clsda.m_clsTargetColours, ++i, bShowFTEs, m_bottomgridcln, TotSelectedOrder, bUseQTY, bUseCosts,
                                       m_show_rhs_dec_costs, bsrem, xTot, m_use_heatmap, m_heatmapcol, m_use_heatmapColour, true);

                    //    m_cln_pis.TryGetValue(oDet.ProjectID, out oPIData);
                    //    oGrid.AddDetailRow(oDet, m_detdispcln, m_cResVals, m_maj_Cat_lookup, oPIData, ++i, m_DispMode, displist, m_cResVals.TargetColors);
                }
            }
            catch (Exception ex)
            {
                string sx = ex.Message;
            }

            s = oGrid.GetString();

            return s;



        }

        public void SetCTStateData(CStruct xData)
        {

            List<CStruct> cts = xData.GetList("CT");

            if (cts == null)
                return;

            foreach (CStruct oNode in cts)
            {

                clsDataItem oItem;

                if (m_clsda.m_CostTypes.TryGetValue(oNode.GetIntAttr("ID"), out oItem))
                {
                    oItem.bSelected = (oNode.GetIntAttr("Value") != 0);
                }

  
            }

            ReDrawGrid();
        }


        public void SetDisplayMode(CStruct xData)
        {

            CStruct xval = xData.GetSubStruct("QTY");
            if (xval != null)
                bUseQTY = (xval.GetIntAttr("Value") != 0);

            xval = xData.GetSubStruct("FTE");
            if (xval != null)
                bShowFTEs = (xval.GetIntAttr("Value") != 0);

            xval = xData.GetSubStruct("COST");
            if (xval != null)
                bUseCosts = (xval.GetIntAttr("Value") != 0);

            xval = xData.GetSubStruct("DECOST");
            if (xval != null)
                m_show_rhs_dec_costs = (xval.GetIntAttr("Value") != 0);

        }

        public String GetDisplayMode()
        {

            CStruct xRoot = new CStruct();
            xRoot.Initialize("DisplayMode");

            CStruct xNode = xRoot.CreateSubStruct("QTY");
            xNode.CreateBooleanAttr("Value", bUseQTY);

            xNode = xRoot.CreateSubStruct("FTE");
            xNode.CreateBooleanAttr("Value", bShowFTEs);

            xNode = xRoot.CreateSubStruct("COST");
            xNode.CreateBooleanAttr("Value", bUseCosts);

            xNode = xRoot.CreateSubStruct("DECOST");
            xNode.CreateBooleanAttr("Value", m_show_rhs_dec_costs);

            return xRoot.XML();
          
     
        }

        public void GetStartFinishDataPeriods(out int istart, out int ifinish)
        {
            if (m_clsda.m_firstperiod_data == m_clsda.m_max_period && m_clsda.m_lastperiod_data == 0)
                m_clsda.m_firstperiod_data = 1;

            if (m_clsda.m_firstperiod_data == 0)
                m_clsda.m_firstperiod_data = 1;

            if (m_clsda.m_lastperiod_data == 0)
                m_clsda.m_lastperiod_data = m_clsda.m_max_period;

            if (m_clsda.m_lastperiod_data < m_clsda.m_firstperiod_data)
            {
                int i = m_clsda.m_firstperiod_data;
                m_clsda.m_firstperiod_data = m_clsda.m_lastperiod_data;
                m_clsda.m_lastperiod_data = i;
            }

            istart = m_clsda.m_firstperiod_data;
            ifinish = m_clsda.m_lastperiod_data;




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


                    if (rowid > 0 && rowid <= m_clnsort.Count)
                    {
                        clsDetailRowData oDet = m_clnsort[rowid - 1];
                        oDet.bSelected = bSel;
                    }
                }
            }
            NewRedrawTotals();

        }

        public void SetFilteredForRows(CStruct xData)
        {

            foreach (clsDetailRowData od in m_clnsort)
                od.bFiltered = false;

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
                        clsDetailRowData oDet = m_clnsort[rowid];
                        oDet.bFiltered = true;
                    }
                }
            }
            NewRedrawTotals();

        }

        private void NewRedrawTotals()
        {
            ProcessTotals();
            CreatePsuedoTarget();
            ProcessTargets();
        }

        private string FormatExtraDisplay(string sIn, int lt)
        {
            DateTime dt;
            int l;
            double d;
            clsDataItem oi;


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

                    if (m_clsda.m_codes.TryGetValue(l, out oi))
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

                    if (m_clsda.m_reses.TryGetValue(l, out oi))
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

                    if (m_clsda.m_stages.TryGetValue(l, out oi))
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

        private string BuildTotalsKey(clsDetailRowData odet)
        {
            string sKey = "K";
            int lVal;
            string sVal;
            int lFid = 0;

            foreach (clsDataItem oi in m_TotalRoot)
            {
                if (oi.bSelected == true)
                {
                    lFid = oi.UID;

                    GetDetFieldValue(odet, lFid, out lVal, out sVal);


                    sKey = sKey + " " + lVal.ToString() + " " + sVal;
                }
            }

            return sKey;

        }

        private void GetDetFieldValue(clsDetailRowData odet, int fid, out int lVal, out string sVal)
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
                sVal = odet.CC_Name;
            else if (fid >= 11800 && fid <= 11810)
            {
                lVal = odet.OCVal[fid - 11800];
                sVal = odet.Text_OCVal[fid - 11800];
            }
            else if (fid > 11810 && fid <= 11820)
                sVal = odet.TXVal[fid - 11810];
            else if (fid >= (int)FieldIDs.PI_USE_EXTRA && fid <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
            {
                lVal = 0;
                sVal = odet.m_PI_Format_Extra_data[fid - (int) FieldIDs.PI_USE_EXTRA];
            }

        }
        private void SetTotalDetFieldValue(clsDetailRowData odet, int fid, int lVal, string sVal)
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
                odet.CC_Name = sVal;
            else if (fid >= 11800 && fid <= 11810)
            {
                odet.OCVal[fid - 11800] = lVal;
                odet.Text_OCVal[fid - 11800] = sVal;
            }
            else if (fid > 11810 && fid <= 11820)
                odet.TXVal[fid - 11810] = sVal;
            else if (fid >= (int)FieldIDs.PI_USE_EXTRA && fid <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
            {
                odet.m_PI_Format_Extra_data[fid - (int) FieldIDs.PI_USE_EXTRA] = sVal;
            }


        }
        private void CopyOverTotFields(clsDetailRowData otot, clsDetailRowData odet, bool bFirstPass)
        {
            int lVal;
            string sVal;
            int lFid = (int)FieldIDs.BC_FID;
            bool bPid = false;

            foreach (clsDataItem oi in m_TotalRoot)
            {
                if (oi.bSelected == true)
                {
                    if (bFirstPass == true)
                    {
                        lFid = oi.UID;

                        GetDetFieldValue(odet, lFid, out lVal, out sVal);
                        SetTotalDetFieldValue(otot, lFid, lVal, sVal);

                        if (lFid == (int)FieldIDs.BC_FID)
                        {
                            otot.Cat_Name = odet.Cat_Name;
                            otot.FullCatName = odet.FullCatName;
                        }

                        else if (lFid == (int)FieldIDs.CAT_FID)
                        {
                            otot.CC_Name = odet.CC_Name;
                            otot.FullCCName = odet.FullCCName;
                        }

                        else if (lFid >= 11801 && lFid <= 11805)
                            otot.Text_OCVal[lFid - 11800] = odet.Text_OCVal[lFid - 11800];

                        else if (lFid >= 11811 && lFid <= 11815)
                            otot.TXVal[lFid - 11810] = odet.TXVal[lFid - 11810];

                        else if (lFid == (int)FieldIDs.SCEN_FID)
                        {
                            otot.Scen_Name = odet.Scen_Name;
                        }

                        else if (lFid == (int)FieldIDs.CT_FID)
                        {
                            otot.CT_Name = odet.CT_Name;
                        }

                        else if (lFid == (int)FieldIDs.BC_ROLE)
                        {
                            otot.Role_Name = odet.Role_Name;
                        }


                        else if (lFid == (int)FieldIDs.PI_FID)
                        {
                            otot.PI_Name = odet.PI_Name;

                            //     if (bPid)
                            otot.Internal_ID = odet.Internal_ID;
                        }
                        else
                        {
                            lFid = oi.ID;

                            if (lFid >= (int)FieldIDs.PI_USE_EXTRA && lFid <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                            {
                                otot.m_PI_Format_Extra_data[lFid - (int)FieldIDs.PI_USE_EXTRA] = odet.m_PI_Format_Extra_data[lFid - (int)FieldIDs.PI_USE_EXTRA];
                            }
                        }


                    }
                    else
                    {
                        int tlVal;
                        string tsVal;

                        lFid = oi.UID;

                        GetDetFieldValue(otot, lFid, out tlVal, out tsVal);
                        GetDetFieldValue(odet, lFid, out lVal, out sVal);

                        Boolean bSame = ((lVal == tlVal) && (sVal == tsVal));

                        if (bSame == false)
                        {

                            if (lFid == (int)FieldIDs.BC_FID)
                            {
                                otot.Cat_Name = "";
                                otot.FullCatName = "";
                            }

                            else if (lFid == (int)FieldIDs.CAT_FID)
                            {
                                otot.CC_Name = "";
                                otot.FullCCName = "";
                            }

                            else if (lFid >= 11801 && lFid <= 11805)
                                otot.Text_OCVal[lFid - 11800] = "";

                            else if (lFid >= 11811 && lFid <= 11815)
                                otot.TXVal[lFid - 11810] = "";


                            else if (lFid == (int)FieldIDs.CT_FID)
                            {
                                otot.CT_Name = "";
                            }

                            else if (lFid == (int)FieldIDs.BC_ROLE)
                            {
                                otot.Role_Name = "";
                            }


                            else if (lFid == (int)FieldIDs.PI_FID)
                            {
                                otot.PI_Name = "";

                                //     if (bPid)
                                otot.Internal_ID = 0;
                            }

                            else
                            {
                                lFid = oi.ID;

                                if (lFid >= (int)FieldIDs.PI_USE_EXTRA && lFid <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                                {
                                    otot.m_PI_Format_Extra_data[lFid - (int)FieldIDs.PI_USE_EXTRA] = "";
                                }
                            }

                        }
                    }
                }

            }
        }

        private void ProcessTotals()
        {
            clsDetailRowData oTot;
            foreach (clsDetailRowData odet in m_total_dets.Values)
            {

                for (int i = 1; i <= m_clsda.m_max_period; i++)
                {
                    odet.zCost[i] = 0;
                    odet.zValue[i] = 0;
                    odet.zFTE[i] = 0;
                }
            }


            foreach (clsDetailRowData odet in m_target_dets.Values)
            {

                for (int i = 1; i <= m_clsda.m_max_period; i++)
                {
                    odet.zCost[i] = 0;
                    odet.zValue[i] = 0;
                    odet.zFTE[i] = 0;
                }
            }

            foreach (clsDetailRowData odet in m_clnsort)
            {
                if (odet.bSelected && odet.bFiltered == false)
                {
                    oTot = m_total_dets.Values.ElementAt(odet.m_total_to - 1);


                    for (int i = 1; i <= m_clsda.m_max_period; i++)
                    {
                        oTot.zCost[i] += odet.zCost[i];
                        oTot.zValue[i] += odet.zValue[i];
                        oTot.zFTE[i] += odet.zFTE[i];
                    }

                }
            }
        }

        public string GetLegendGrid()
        {

            CALegendGrid oGrid = new CALegendGrid();
            string s;
            oGrid.InitializeGridLayout();
            int rgb = 0;
            string sRGB = "";

            foreach (clsTargetColours otar in m_clsda.m_clsTargetColours)
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

        public string GetTotalsData()
        {
            CStruct xNode;
            CStruct xWork;

            
            CStruct xRoot = new CStruct();
            xRoot.Initialize("TotalsConfiguration");

            xWork = xRoot.CreateSubStruct("EnableHeatMap");
            xWork.CreateBooleanAttr("Value", m_use_heatmap);

            xWork = xRoot.CreateSubStruct("EnableHeatField");
            xWork.CreateIntAttr("Value", m_use_heatmapID);

            xWork = xRoot.CreateSubStruct("HeatFieldColour");
            xWork.CreateIntAttr("Value", m_use_heatmapColour);


            foreach (clsDataItem oi in m_TotalRoot)
            {

                xNode = xRoot.CreateSubStruct("FIELD");
                xNode.CreateIntAttr("ID", oi.UID);
                xNode.CreateStringAttr("Name", oi.Name);
                xNode.CreateBooleanAttr("Selected", oi.bSelected);
            }


            xNode = xRoot.CreateSubStruct("ColumnOptions");

            foreach (CATGRow otg in TotGeneral)
            {
                xWork = xNode.CreateSubStruct("ColumnOption");
                xWork.CreateIntAttr("ColumnID", otg.fid);
                xWork.CreateBooleanAttr("Selected", otg.bUse);
                xWork.CreateStringAttr("Name", otg.DisplayName);
            }

 
            xNode = xRoot.CreateSubStruct("SelectedOrderItems");
            foreach (CATGRow otg in TotSelectedOrder)
            {
                xWork = xNode.CreateSubStruct("Item");
                xWork.CreateIntAttr("ItemID", otg.fid);
            }



            return xRoot.XML();       
        }

        public void SetTotalsData(CStruct xData)
        {


            foreach (clsDataItem oi in m_TotalRoot)
            {
                oi.bSelected = false;

            }

            List<CStruct> Items = xData.GetList("FIELD");
            CStruct xUseHeatMap = xData.GetSubStruct("EnableHeatMap");
            CStruct xHeatMapID = xData.GetSubStruct("EnableHeatField");
            CStruct xSelOrder = xData.GetSubStruct("SelectedOrderItems");
            CStruct xSelColour = xData.GetSubStruct("HeatFieldColour");
            int heatmapcol = 0;

            if (Items != null)
            {
                foreach (CStruct Itemsval in Items)
                {
                    int xfid = Itemsval.GetIntAttr("ID");
                    bool bSel = Itemsval.GetBooleanAttr("Selected");

                    foreach (clsDataItem oi in m_TotalRoot)
                    {
                        if (xfid == oi.UID)
                            oi.bSelected = bSel;

                    }

                }
            }


            if (xUseHeatMap != null)
                m_use_heatmap = xUseHeatMap.GetIntAttr("Value", 0) == 1;

            if (xHeatMapID != null)
                m_use_heatmapID = xHeatMapID.GetIntAttr("Value", 0);

            if (xSelColour != null)
                m_use_heatmapColour = xSelColour.GetIntAttr("Value", 0);
            
            m_heatmapcol = 0;
            m_heatmap_text = "";

            if (xSelOrder != null)
            {

                foreach (CATGRow otg in TotGeneral)
                {
                    otg.bUse = false;
     
                    if (m_use_heatmap && otg.fid == m_use_heatmapID)
                    {
                            m_heatmapcol = otg.index;
                            m_heatmap_text = otg.Name;
                    }
                }


                List<CStruct> cln = xSelOrder.GetChildNodeCollection();

                int i = 0;

                if (!(cln == null || cln.Count == 0))
                {


                    TotSelectedOrder = new List<CATGRow>();

                    List<CATGRow> uselist = null;

                    foreach (CStruct oNode in cln)
                    {
                        int tid = oNode.GetIntAttr("ItemID");
                        ++i;

                        uselist = TotGeneral;

                        foreach (CATGRow otg in uselist)
                        {
                            if (otg.fid == tid)
                            {
                                otg.bUse = true;
                                TotSelectedOrder.Add(otg);

                                break;
                            }

                        }

                    }
                }

            }

            PrepareTotalsCollection();
            NewRedrawTotals();

        }

        public string GetCompareCostTypeList()
        {

            
            CStruct xRoot = new CStruct();
            xRoot.Initialize("CTCmpConfiguration");


            foreach (clsDataItem oi in m_CTCmpRoot)
            {

                CStruct xNode = xRoot.CreateSubStruct("CostType");
                xNode.CreateIntAttr("ID", oi.UID);
                xNode.CreateStringAttr("Name", oi.Name);
                xNode.CreateBooleanAttr("Selected", oi.bSelected);
            }

            return xRoot.XML();       
        }

        public string SetCompareCostType(CStruct xData)
        {

            m_tarnames = "";

            foreach (clsDataItem oi in m_CTCmpRoot)
            {
                oi.bSelected = false;

            }

            List<CStruct> Items = xData.GetList("Item");
            if (Items != null)
            {
                foreach (CStruct Itemsval in Items)
                {
                    int xfid = Itemsval.GetIntAttr("ID");

                    foreach (clsDataItem oi in m_CTCmpRoot)
                    {
                        if (xfid == oi.UID)
                        {
                            if (m_tarnames != "")
                                m_tarnames += ",";

                            m_tarnames += oi.Name;
                            oi.bSelected = true;


                        }
                    }

                }
            }


            NewRedrawTotals();
            CStruct xRoot = new CStruct();
            xRoot.Initialize("HeatMapText");

            xRoot.CreateStringAttr("Value", m_tarnames);
            return xRoot.XML();       

        }

        private void CreatePsuedoTarget()
        {
            m_targetdata = new Dictionary<string, clsDetailRowData>();

            clsDetailRowData xdet = null;
            string sKey = "";

            m_tarnames = "";

            foreach (clsDataItem oi in m_CTCmpRoot)
            {
                if (oi.bSelected == true)
                {
                    if (m_tarnames != "")
                        m_tarnames += ",";

                    m_tarnames += oi.Name;
                    foreach (clsDetailRowData odet in m_clnsort)
                    {
                        if (odet.CT_ID == oi.UID)
                        {
                            // create a new copy o the detail

                            xdet = new clsDetailRowData(m_clsda.m_max_period);

                            xdet.CopyData(odet);

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

        public void SetShowRemaining(bool bShowRem)
        {
            m_showremaining = bShowRem;
        }

        private void ProcessTargets()
        {


            clsDetailRowData oTar;
            foreach (clsDetailRowData odet in m_target_dets.Values)
            {

                for (int i = 1; i <= m_clsda.m_max_period; i++)
                {
                    odet.zCost[i] = 0;
                    odet.zValue[i] = 0;
                    odet.zFTE[i] = 0;
                }
            }

            if (m_apply_target == 0)
                return;

            foreach (clsDetailRowData odet in m_targetdata.Values)
            {
                string sKey = BuildTotalsKey(odet);

                if (m_target_dets.TryGetValue(sKey, out oTar) == true)
                {

                    for (int i = 1; i <= m_clsda.m_max_period; i++)
                    {
                        oTar.zCost[i] += odet.zCost[i];
                        oTar.zValue[i] += odet.zValue[i];
                        oTar.zFTE[i] += odet.zFTE[i];
                    }
                }

            }
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
                        CStruct oWork;
                            
                        oWork = OtherData.GetSubStruct("TotalsConfiguration");
                        if (oWork != null)
                           SetTotalsData(oWork);

                        //xReply.AppendXML(sret);

                        oWork = OtherData.GetSubStruct("CTDetails");
                        if (oWork != null)
                            SetCTStateData(oWork);

                        oWork = OtherData.GetSubStruct("ShowDetails");
                        if (oWork != null)
                            SetDisplayMode(oWork);



                        //oWork = OtherData.GetSubStruct("WorkDisplayMode");
                        //if (oWork != null)
                        //    SetDisplayMode(oWork);

                        //xReply.AppendXML(GetDisplayMode());

                    }

                    CStruct Extradata;
                    Extradata = xReply.CreateSubStruct("TotalsConfiguration");
                    Extradata.CreateStringAttr("Value", GetTotalsData());
   //                 Extradata.AppendXML(GetTotalsData());

                    Extradata = xReply.CreateSubStruct("HeatMapText");
                    Extradata.CreateStringAttr("Value", m_heatmap_text);  


                    int icnt = 0;

                    foreach (CATGRow otg in TotSelectedOrder)
                    {
                        if (otg.bUse)
                        {
                            ++icnt;
                            if (otg.fid == 0)
                            {
                                Extradata = xReply.CreateSubStruct("HeatMapCol");
                                Extradata.CreateIntAttr("Value", icnt);
                                break;
                            }
                        }
                    }


                   

                    xReply.AppendXML(GetCostTypeNameData());
                    xReply.AppendXML(GetDisplayMode());
                    break;
                }
            }
            return xReply.XML();
        }

        public String GetTargetList()
        {

            CStruct xRoot = new CStruct();
            xRoot.Initialize("Targets");


            foreach (clsDataItem oItem in m_clsda.m_targets.Values)
            {
                CStruct xNode = xRoot.CreateSubStruct("Target");
                xNode.CreateStringAttr("Name", oItem.Name);
                xNode.CreateIntAttr("ID", oItem.UID);
            }

            return xRoot.XML();


        }

        public bool DeleteTarget(int delTarget, out string heatmaptext)
        {
            clsDataItem xItem;
            heatmaptext = m_heatmap_text;

            if (m_clsda.m_targets.Remove(delTarget) == true)
            {
                List<CATGRow> newtot = new List<CATGRow>();
                bool bNeg = false;
                int negind = 0;

                foreach (CATGRow otg in TotGeneral)
                {
                    if (otg.index < 0)
                        bNeg = true;
                    if (delTarget != -otg.fid)
                    {
                        if (bNeg)
                        {

                            otg.index = --negind;
                        }

                        newtot.Add(otg);
                      
                    }
 
                }

                TotGeneral = newtot;

                m_heatmapcol = 0;
                m_heatmap_text = "";

 
                foreach (CATGRow otg in TotGeneral)
                {
                    if (m_use_heatmap && otg.fid == m_use_heatmapID)
                    {
                            m_heatmapcol = otg.index;
                            m_heatmap_text = otg.Name;
                    }
                }

                if (m_heatmapcol == 0)
                    m_use_heatmap = false;

                TotSelectedOrder = new List<CATGRow>();

                foreach (CATGRow otg in TotGeneral)
                {
                    if (otg.bUse == true)
                    {
                        TotSelectedOrder.Add(otg);
                    }

                }





                int i = 0;
                foreach (clsDataItem oItem in m_clsda.m_targets.Values)
                {
                    ++i;
                    oItem.ID = i;
                }

                Dictionary<string, clsDetailRowData> newdata = new Dictionary<string, clsDetailRowData>();

                foreach (KeyValuePair<string, clsDetailRowData> pair in m_clsda.m_targetdata)
                {
                    if (pair.Value.Scenario_ID != delTarget)
                    {
                        newdata.Add(pair.Key, pair.Value);

                        if (m_clsda.m_targets.TryGetValue(pair.Value.Scenario_ID, out xItem) == true)
                            pair.Value.CT_ind = xItem.ID;
                        else
                            pair.Value.CT_ind = -1;

                    }

                }

                PrepareTotalsCollection();
                NewRedrawTotals();

                heatmaptext = m_heatmap_text;
                return true;
            }




            return false;

        }

        private string BuildCatJSon(int index, int max)
        {
            clsCatItemData ce, ne, initial;
            string sRet = "";

            initial = m_clsda.m_CostCat.ElementAt(index).Value;

            for (int i = index; i <= max; i++)
            {

                ce = m_clsda.m_CostCat.ElementAt(i).Value;

                if (initial.Level == ce.Level)
                {

                    if (sRet != "")
                        sRet = sRet + ",";

                    sRet += "{Name:'" + ce.ID.ToString() + "',Text:'" + ce.Name + "',Value:'" + ce.UID.ToString() + "'}";


                    if (i != max)
                    {
                        ne = m_clsda.m_CostCat.ElementAt(i + 1).Value ;

                        if (ne.Level > ce.Level)
                        {
                            sRet += ",{Name:'Level" + ce.ID.ToString() + "',Expanded:-1,Level:" + ce.Level.ToString() + ", Items:[ " + BuildCatJSon(i + 1, max) + "]}";
                        }
                        else if (ne.Level < ce.Level)
                            return sRet;

                    }
                }

            }


            return sRet;

        }

        private string BuildCustFieldJSon(clsCustomFieldData oc, int index, int max)
        {
            clsListItemData ce, ne, initial;
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
                        }
                        else if (ne.Level < ce.Level)
                            return sRet;

                    }
                }

            }


            return sRet;

        }


        public string RatesAndCategory()
        {
   
            CStruct xRoot = new CStruct();

            CStruct xNode;
            xRoot.Initialize("RatesAndCategories");

            //CSCategoryEntry ce = null;
            //ItemDefn ve = null;

            xRoot.CreateIntAttr("numberPeriods", m_clsda.m_Periods.Count);


            CStruct xCategories = xRoot.CreateSubStruct("Categories");
            CStruct xCostTypes = xRoot.CreateSubStruct("CostTypes");
            CStruct xCustomFields = xRoot.CreateSubStruct("CustomFields");
            CStruct xNamedRates = xRoot.CreateSubStruct("NamedRates");
            CStruct xPeriods = xRoot.CreateSubStruct("Periods");

 
            foreach (clsPeriodData oPer in m_clsda.m_Periods.Values)
            {

                CStruct xPeriod = xPeriods.CreateSubStruct("Period");
                xPeriod.CreateIntAttr("ID", oPer.PeriodID);
                xPeriod.CreateStringAttr("Name", oPer.PeriodName);
            }


            string jsonMenu = "";


            foreach (clsCatItemData oCat in m_clsda.m_CostCat.Values)
            {
                CStruct xCategory = xCategories.CreateSubStruct("Category");
 
                xCategory.CreateIntAttr("ID",oCat.ID);
                xCategory.CreateIntAttr("UID", oCat.UID);
                xCategory.CreateIntAttr("Level", oCat.Level);
                xCategory.CreateIntAttr("Role_UID", oCat.Role_UID);
                xCategory.CreateIntAttr("MC_UID",oCat.MC_UID);
                xCategory.CreateIntAttr("Category", oCat.Category);



                xCategory.CreateStringAttr("Name",oCat.Name);
                xCategory.CreateStringAttr("UoM", oCat.UoM);
                xCategory.CreateStringAttr("FullName", oCat.FullName);
                xCategory.CreateStringAttr("MC_Val", oCat.MC_Val);
                xCategory.CreateStringAttr("Role_Name", oCat.Role_Name);

                for (int xi = 0; xi < oCat.Rates.Length; xi++)
                {
                    CStruct xCategoryRate = xCategory.CreateSubStruct("Rate");
                    xCategoryRate.CreateDoubleAttr("Value", oCat.Rates[xi]);
                }

                for (int xi = 0; xi < oCat.FTEConv.Length; xi++)
                {
                    CStruct xCategoryFTE = xCategory.CreateSubStruct("FTE");
                    xCategoryFTE.CreateDoubleAttr("Value", oCat.FTEConv[xi]);
                }
            }

            jsonMenu = "{Items:[" + BuildCatJSon(0, m_clsda.m_CostCat.Count - 1) + "]}";

            m_CostCatjsonMenu = jsonMenu;



            //cnt = 0;

            //foreach (DataItem oi in m_Scenario.Values)
            //{
            //    ve = new ItemDefn();

            //    rdata.Versions[cnt] = ve;

            //    rdata.Versions[cnt].Id = oi.UID;
            //    rdata.Versions[cnt++].Name = oi.Name;

            //}

            //cnt = 0;
            jsonMenu = "{Name:'0',Text:'No Cost Type',Value:'0'}";

            foreach (clsDataItem oi in m_clsda.m_CostTypes.Values)
            {
                CStruct xCostType = xCostTypes.CreateSubStruct("CostType");

                xCostType.CreateIntAttr("Id", oi.UID);
                xCostType.CreateStringAttr("Name", oi.Name);

                jsonMenu += ",{Name:'" + oi.UID.ToString() + "',Text:'" + oi.Name + "',Value:'" + oi.UID.ToString() + "'}";
            }

            jsonMenu = "{Items:[" + jsonMenu + "]}";

            m_CostTypejsonMenu = jsonMenu;



  
            foreach (clsCustomFieldData oc in m_clsda.m_CustFields.Values)
            {
                CStruct xCustField = xCustomFields.CreateSubStruct("CustomField");

                xCustField.CreateIntAttr("FieldID", oc.FieldID);
                xCustField.CreateStringAttr("Name", "z" + oc.Name);

                xCustField.CreateIntAttr("LookupOnly", oc.LookupOnly);
                xCustField.CreateIntAttr("LookupID", oc.LookupID);
                xCustField.CreateIntAttr("LeafOnly", oc.LeafOnly);
                xCustField.CreateIntAttr("UseFullName", oc.UseFullName);
 

                jsonMenu = "";


                CStruct xLoopUps = xCustField.CreateSubStruct("LookUps");

                int xcnt = 0;

                foreach (clsListItemData oi in oc.ListItems.Values)
                {
                    CStruct xLoopUp = xLoopUps.CreateSubStruct("LookUp");


                    xLoopUp.CreateIntAttr("ID", oi.ID);
                    xLoopUp.CreateIntAttr("UID", oi.UID);
                    xLoopUp.CreateIntAttr("Level", oi.Level);

                    xLoopUp.CreateStringAttr("Name", oi.Name);
                    xLoopUp.CreateStringAttr("FullName", oi.FullName);

                    xLoopUp.CreateBooleanAttr("InActive", oi.InActive);

                }

                if (oc.ListItems.Count > 0)
                    jsonMenu = "{Items:[" + BuildCustFieldJSon(oc, 0, oc.ListItems.Count - 1) + "]}";

                xCustField.CreateStringAttr("jsonMenu", jsonMenu);

                oc.jsonMenu = jsonMenu;
 
            }


            return xRoot.XML();
        
        
        }

        private string GetLookUpString(int index, ref int lUID)
        {
            clsListItemData oLI = null;


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

        public string PrepareTargetData(string stargetID)
        {

            try
            {

                CStruct xRoot = new CStruct();

                CStruct xNode;
                xRoot.Initialize("TargetData");


                int targetID = int.Parse(stargetID);
                clsCatItemData oCat;
                clsDataItem oItem;
  

                m_editTargetList = new List<clsDetailRowData>();

                foreach (clsDetailRowData oDet in m_clsda.m_targetdata.Values)
                {

                    if (oDet.Scenario_ID == targetID)
                    {
                        if (m_clsda.m_CostCat.TryGetValue(oDet.BC_UID, out oCat))
                        {
                            oDet.Cat_Name = oCat.Name;
                            oDet.FullCatName = oCat.FullName;
                            oDet.MC_Name = oCat.MC_Val;
                            oDet.Role_Name = oCat.Role_Name;
                            oDet.sUoM = oCat.UoM;

                            if (m_clsda.m_CostCat.TryGetValue(oCat.Category, out oCat))
                            {
                                oDet.CC_Name = oCat.Name;
                                oDet.FullCCName = oCat.FullName;
                            }
                        }


                        if (m_clsda.m_CostTypes.TryGetValue(oDet.CT_ID, out oItem))
                            oDet.CT_Name = oItem.Name;
                        else
                            oDet.CT_Name = "";

                        clsRateTable ort;

                        if (m_clsda.m_Rates.TryGetValue(oDet.m_rt, out ort))
                            oDet.m_rt_name = ort.Name;
                        else
                            oDet.m_rt_name = "";

                        int tempj;

                        for (int i = 0; i <= 5; i++)
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

                m_editTargetList = AggreagteDuplicateRows(m_editTargetList);

                int xcnt = 0;

                foreach (clsDetailRowData oDet in m_editTargetList)
                {
                    xNode = xRoot.CreateSubStruct("targetRows");

                    ++xcnt;



                    xNode.CreateIntAttr("RID", xcnt);
                    xNode.CreateIntAttr("CT_ID", oDet.CT_ID);
                    xNode.CreateIntAttr("BC_UID", oDet.BC_UID);
                    xNode.CreateIntAttr("BC_ROLE_UID", oDet.BC_ROLE_UID);
                    xNode.CreateIntAttr("BC_SEQ", oDet.BC_SEQ);
                    xNode.CreateIntAttr("CAT_UID", oDet.CAT_UID);

                    xNode.CreateStringAttr("MC_Val", oDet.MC_Val);
                    xNode.CreateStringAttr("CT_Name", oDet.CT_Name);
                    xNode.CreateStringAttr("Cat_Name", oDet.Cat_Name);
                    xNode.CreateStringAttr("Role_Name", oDet.Role_Name);
                    xNode.CreateStringAttr("MC_Name", oDet.MC_Name);
                    xNode.CreateStringAttr("FullCatName", oDet.FullCatName);
                    xNode.CreateStringAttr("CC_Name", oDet.CC_Name);
                    xNode.CreateStringAttr("FullCCName", oDet.FullCCName);
                    xNode.CreateIntAttr("m_rt", 0);

                    for (int xi = 0; xi <= 5; xi++)
                    {
                        CStruct xCF = xNode.CreateSubStruct("OCVal");
                        xCF.CreateIntAttr("Value", oDet.OCVal[xi]);
                        xCF = xNode.CreateSubStruct("Text_OCVal");
                        xCF.CreateStringAttr("Value", oDet.Text_OCVal[xi]);
                        xCF = xNode.CreateSubStruct("TXVal");
                        xCF.CreateStringAttr("Value", oDet.TXVal[xi]);
                    }

                    for (int xi = 0; xi <= m_clsda.m_Periods.Count; xi++)
                    {

                        CStruct xDV = xNode.CreateSubStruct("zCost");
                        xDV.CreateDoubleAttr("Value", oDet.zCost[xi]);
                        xDV = xNode.CreateSubStruct("zValue");
                        xDV.CreateDoubleAttr("Value", oDet.zValue[xi]);
                        xDV = xNode.CreateSubStruct("zFTE");
                        xDV.CreateDoubleAttr("Value", oDet.zFTE[xi]);


                    }
                }

                return xRoot.XML();



            }

            catch (Exception ex)
            {
            }

            //m_oDataAccess = null;

            return "";

        }





        public String GetTargetGrid()
        {
            TargetGrid oGrid = new TargetGrid();
            oGrid.InitializeGridLayout(false, m_clsda.m_CustFields, m_clsda.m_Rates.Count, m_CostTypejsonMenu,
                                       m_CostCatjsonMenu, 0); //m_filter_sel[(int)FieldIDs.MC_FID].Count);

            int i = 0;

            foreach (clsPeriodData period in m_clsda.m_Periods.Values)
            {
                ++i;

                oGrid.AddPeriodColumn(i.ToString(), period.PeriodName, false);
            }

            oGrid.FinalizeGridLayout();
  
            oGrid.InitializeGridData();
            i = 0;

            foreach (clsDetailRowData oDet in m_editTargetList)
            {
                oGrid.AddDetailRow(oDet, ++i, false, m_clsda.m_Periods.Count, m_clsda.m_CustFields, m_clsda.m_Rates.Count);
            }

            string s = oGrid.GetString();

            return s;

        }

        private  List<clsDetailRowData> AggreagteDuplicateRows( List<clsDetailRowData> datain)
        {
            if (datain == null)
                return null;

            List<clsDetailRowData> rval = new List<clsDetailRowData>();
            Dictionary<string, clsDetailRowData> hashtab = new Dictionary<string, clsDetailRowData>();


            foreach (clsDetailRowData inDet in datain)
            {
                clsDetailRowData oDet = new clsDetailRowData(m_clsda.m_max_period);
                clsDetailRowData xDet;       
                CStruct xNode = new CStruct();
                string scmp;
                
                oDet.CopyData(inDet);


                xNode.Initialize("TRow");

                xNode.CreateIntAttr("CT_ID", oDet.CT_ID);
                xNode.CreateIntAttr("BC_UID", oDet.BC_UID);
                xNode.CreateIntAttr("BC_ROLE_UID", oDet.BC_ROLE_UID);
                xNode.CreateIntAttr("CAT_UID", oDet.CAT_UID);

                xNode.CreateStringAttr("MC_Val", oDet.MC_Val);
                xNode.CreateStringAttr("CT_Name", oDet.CT_Name);
                xNode.CreateStringAttr("Cat_Name", oDet.Cat_Name);
                xNode.CreateStringAttr("Role_Name", oDet.Role_Name);
                xNode.CreateStringAttr("MC_Name", oDet.MC_Name);
                xNode.CreateStringAttr("FullCatName", oDet.FullCatName);
                xNode.CreateStringAttr("CC_Name", oDet.CC_Name);
                xNode.CreateStringAttr("FullCCName", oDet.FullCCName);
                xNode.CreateIntAttr("m_rt", 0);

                for (int xi = 0; xi <= 5; xi++)
                {
                    CStruct xCF = xNode.CreateSubStruct("OCVal");
                    xCF.CreateIntAttr("Value", oDet.OCVal[xi]);
                    xCF = xNode.CreateSubStruct("Text_OCVal");
                    xCF.CreateStringAttr("Value", oDet.Text_OCVal[xi]);
                    xCF = xNode.CreateSubStruct("TXVal");
                    xCF.CreateStringAttr("Value", oDet.TXVal[xi]);
                }

                scmp = xNode.XML();

                if (hashtab.TryGetValue(scmp, out xDet) == true)
                {
                    for (int xi = 0; xi <= m_clsda.m_Periods.Count; xi++)
                    {

                        xDet.zCost[xi] += oDet.zCost[xi];
                        xDet.zValue[xi] += oDet.zValue[xi];
                        xDet.zFTE[xi] += oDet.zFTE[xi];
                    }
                }
                else
                {

                    hashtab.Add(scmp,oDet);
                    rval.Add(oDet);
                }

            }

            return rval;
        }

        public String GetTargetTotalsData()
        {
            try
            {

                CStruct xRoot = new CStruct();

                CStruct xNode;
                xRoot.Initialize("TargetTotalData");


                List<clsDetailRowData> tarrows = new List<clsDetailRowData>();


                foreach (CATotRow xTot in m_total_rows.Values)
                {

                    if (xTot.bUsed == true)
                    {
                        tarrows.Add(xTot.m_totals[0]);
                    }
                }



                tarrows = AggreagteDuplicateRows(tarrows);

                foreach (clsDetailRowData oDet in tarrows)
                {

                        xNode = xRoot.CreateSubStruct("totalRows");




                    xNode.CreateIntAttr("CT_ID", oDet.CT_ID);
                    xNode.CreateIntAttr("BC_UID", oDet.BC_UID);
                    xNode.CreateIntAttr("BC_ROLE_UID", oDet.BC_ROLE_UID);
                    xNode.CreateIntAttr("BC_SEQ", oDet.BC_SEQ);
                    xNode.CreateIntAttr("CAT_UID", oDet.CAT_UID);

                    xNode.CreateStringAttr("MC_Val", oDet.MC_Val);
                    xNode.CreateStringAttr("CT_Name", oDet.CT_Name);
                    xNode.CreateStringAttr("Cat_Name", oDet.Cat_Name);
                    xNode.CreateStringAttr("Role_Name", oDet.Role_Name);
                    xNode.CreateStringAttr("MC_Name", oDet.MC_Name);
                    xNode.CreateStringAttr("FullCatName", oDet.FullCatName);
                    xNode.CreateStringAttr("CC_Name", oDet.CC_Name);
                    xNode.CreateStringAttr("FullCCName", oDet.FullCCName);
                    xNode.CreateIntAttr("m_rt", 0);

                    for (int xi = 0; xi <= 5; xi++)
                    {
                        CStruct xCF = xNode.CreateSubStruct("OCVal");
                        xCF.CreateIntAttr("Value", oDet.OCVal[xi]);
                        xCF = xNode.CreateSubStruct("Text_OCVal");
                        xCF.CreateStringAttr("Value", oDet.Text_OCVal[xi]);
                        xCF = xNode.CreateSubStruct("TXVal");
                        xCF.CreateStringAttr("Value", oDet.TXVal[xi]);
                    }

                    for (int xi = 0; xi <= m_clsda.m_Periods.Count; xi++)
                    {

                        CStruct xDV = xNode.CreateSubStruct("zCost");
                        xDV.CreateDoubleAttr("Value", oDet.zCost[xi]);
                        xDV = xNode.CreateSubStruct("zValue");
                        xDV.CreateDoubleAttr("Value", oDet.zValue[xi]);
                        xDV = xNode.CreateSubStruct("zFTE");
                        xDV.CreateDoubleAttr("Value", oDet.zFTE[xi]);



                    }
                }

                return xRoot.XML();



            }

            catch (Exception ex)
            {
            }


            return "";
            
        }

        public int Get_CB_ID()
        {
            return m_clsda.m_CB_ID;
        }
        
        public int Get_MaxPeriods()
        {
            return m_clsda.m_max_period;
        }
        public void RefreshTargets(clsCostData cda)
        {
 
            m_clsda.m_targetdata = cda.m_targetdata;

            clsDataItem oItem;
            List<CATGRow> newtot = new List<CATGRow>();

            foreach (clsDataItem otar in  cda.m_targets.Values)
            {
                
                if (m_clsda.m_targets.TryGetValue(otar.UID, out oItem) == false)
                {
                    m_clsda.m_targets.Add(otar.UID, otar);
                    otar.ID = -m_clsda.m_targets.Count;
                    TotGeneral.Add(CreatetgLayout(false, -otar.UID, otar.Name, otar.Name, otar.ID));
                }
            }

            PrepareTotalsCollection();
            NewRedrawTotals();


        }

        public string GetTargetRGBData()
        {
            CStruct xRoot = new CStruct();
            CStruct xTarget;
            int maxid = -100;

            xRoot.Initialize("Targets");

            foreach (clsTargetColours oTar in m_clsda.m_clsTargetColours)
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


    }
}