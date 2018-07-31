using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Linq;
using WorkEnginePPM;
using ResourceValues;
using PortfolioEngineCore;
using System.Globalization;


namespace RPADataCache
{
    public static class RPAGridHelper
    {
        internal static string TargetBackground(double Tdbl, double Pdbl, Dictionary<int, clsViewTargetColours> TargetColours, out int targetlevel, int heatmapColour)
        {



            targetlevel = 0;

            string sRet = "RGB(217, 255, 255)";

            int rgb = -4;


            if (TargetColours == null)
                return sRet;

            if (TargetColours.Count == 0)
                return sRet;

            if (Tdbl == 0 && Pdbl == 0)
            {
                targetlevel = -3;
                foreach (clsViewTargetColours oT in TargetColours.Values)
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
                targetlevel = -2;
                foreach (clsViewTargetColours oT in TargetColours.Values)
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
                targetlevel = -1;
                foreach (clsViewTargetColours oT in TargetColours.Values)
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

                if (heatmapColour == 2)
                    percnt = (Pdbl / Tdbl) * 100;
                else
                    percnt = (Tdbl / Pdbl) * 100;

                foreach (clsViewTargetColours oT in TargetColours.Values)
                {
                    if (oT.ID > 0)
                    {

                        if ((percnt >= oT.low_val && percnt <= oT.high_val) || (oT.high_val == 0))
                        {
                            rgb = oT.rgb_val;
                            targetlevel = oT.ID;
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

    internal class RPANewBottomGrid
    {
        private CStruct xGrid;
        private CStruct m_xPeriodCols;
        private CStruct m_xHeader1;
        private CStruct m_xHeader2;
        private CStruct m_xDef;
        private CStruct m_xDefTree;
        private CStruct m_xDefNode;
        private CStruct m_xDefPI;

        private CStruct m_lastnode;

        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;



        public bool InitializeGridLayout(List<clsRXDisp> Cols, bool by_role, string sResRolHeader)
        {

            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xMenuc = xGrid.CreateSubStruct("MenuCfg");

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("MainCol", "ResOrRole");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("PrintCols", 0);
            xCfg.CreateIntAttr("SuppressCfg", 1);
            xCfg.CreateIntAttr("SuppressMessage", 3);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("Sorting", 1);
            xCfg.CreateIntAttr("ColsMoving", 1);
            xCfg.CreateIntAttr("ColsPosLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateIntAttr("VisibleLap", 1);
            xCfg.CreateIntAttr("SectionWidthLap", 1);
            xCfg.CreateIntAttr("GroupLap", 1);
            xCfg.CreateIntAttr("WideHScroll", 0);
            xCfg.CreateIntAttr("LeftWidth", 400);
            xCfg.CreateIntAttr("Width", 400);
            xCfg.CreateIntAttr("RightWidth", 400);
            xCfg.CreateIntAttr("MaxHeight", 0);
            //         xCfg.CreateIntAttr("MinRowHeight", 26); 
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("MaxSort", 2);
            //        xCfg.CreateStringAttr("DefaultSort", "rowid"); 
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");
            xCfg.CreateIntAttr("FastColumns", 1);
            xCfg.CreateIntAttr("ConstHeight", 1);

            xCfg.CreateIntAttr("ExpandAllLevels", 3);
            xCfg.CreateIntAttr("GroupSortMain", 1);
            xCfg.CreateIntAttr("GroupRestoreSort", 1);

            xCfg.CreateIntAttr("NoTreeLines", 1);
            xCfg.CreateIntAttr("ShowVScroll", 1);
            xCfg.CreateIntAttr("LeftCanResize", 0);

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");
            CStruct xRightCols = xGrid.CreateSubStruct("RightCols");
            m_xPeriodCols = xRightCols;

            m_xDef = xGrid.CreateSubStruct("Def");

            m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");
            m_xDefTree.CreateStringAttr("Calculated", "1");

            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefTree.CreateIntAttr("NoColorState", 1);


            m_xDefNode = m_xDef.CreateSubStruct("D");
            m_xDefNode.CreateStringAttr("Name", "Leaf");
            m_xDefNode.CreateStringAttr("Calculated", "0");

            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("HoverRow", "Color");
            m_xDefNode.CreateStringAttr("FocusCell", "");
            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefNode.CreateIntAttr("NoColorState", 1);

            m_xDefPI = m_xDef.CreateSubStruct("D");
            m_xDefPI.CreateStringAttr("Name", "PI");
            m_xDefPI.CreateStringAttr("Calculated", "0");

            m_xDefPI.CreateStringAttr("HoverCell", "Color");
            m_xDefPI.CreateStringAttr("HoverRow", "Color");
            m_xDefPI.CreateStringAttr("FocusCell", "");
            m_xDefPI.CreateStringAttr("HoverCell", "Color");
            m_xDefPI.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefPI.CreateIntAttr("NoColorState", 1);

            CStruct xHead = xGrid.CreateSubStruct("Head");
            //           xHead.CreateIntAttr("Visible", 0);


            //        m_xHeader1 = xGrid.CreateSubStruct("Header");
            m_xHeader1 = xGrid.CreateSubStruct("Header");
            m_xHeader2 = xHead.CreateSubStruct("Header");
            m_xHeader1.CreateIntAttr("PortfolioItemVisible", 1);
            m_xHeader1.CreateIntAttr("Spanned", 1);
            m_xHeader1.CreateIntAttr("SortIcons", 2);
            //        m_xHeader1.CreateStringAttr("Def", "Tree");

            m_xHeader1.CreateStringAttr("HoverCell", "Color");
            m_xHeader1.CreateStringAttr("HoverRow", "");

            m_xHeader2.CreateIntAttr("PortfolioItemVisible", 1);
            m_xHeader2.CreateIntAttr("Spanned", -1);
            m_xHeader2.CreateIntAttr("SortIcons", 0);

            m_xHeader2.CreateStringAttr("HoverCell", "Color");
            m_xHeader2.CreateStringAttr("HoverRow", "");

            CStruct xFilter = xHead.CreateSubStruct("Filter");
            xFilter.CreateStringAttr("id", "Filter");

            CStruct xC = xLeftCols.CreateSubStruct("C");



            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "RowSel");
            xC.CreateStringAttr("Type", "Icon");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateStringAttr("Width", "20");
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateStringAttr("Color", "rgb(223, 227, 232)");
            m_xHeader1.CreateStringAttr("RowSel", " ");
            m_xHeader2.CreateStringAttr("RowSel", " ");

            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "rowid");
            xC.CreateStringAttr("Type", "Int");
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateStringAttr("Width", "20");
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("Visible", 0);

            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "IconFlag");
            xC.CreateStringAttr("Type", "Icon");
            xC.CreateIntAttr("Visible", 1);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateStringAttr("Width", "20");
            xC.CreateIntAttr("CanExport", 0);
            m_xHeader1.CreateStringAttr("IconFlag", " ");
            m_xHeader2.CreateStringAttr("IconFlag", " ");

            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);


            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "rtSelect");
            xC.CreateStringAttr("Type", "Bool");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateStringAttr("Width", "20");
            xC.CreateStringAttr("Class", "");
            xC.CreateIntAttr("Visible", 1);
            m_xHeader1.CreateStringAttr("rtSelect", " ");
            m_xHeader2.CreateStringAttr("rtSelect", " ");


            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);

            m_xDefTree.CreateBooleanAttr("rtSelectCanEdit", true);
            //         m_xDefTree.CreateStringAttr("IconFlag", "/_layouts/ppm/images/Green.gif");   //"sum()");
            m_xDefNode.CreateStringAttr("IconFlag", "/_layouts/ppm/images/Nogif.gif");   //"sum()");

            CStruct xSolid = xGrid.CreateSubStruct("Solid");
            CStruct xGroup = xSolid.CreateSubStruct("Group");



            foreach (clsRXDisp col in Cols)
            {
                try
                {


                    bool bDoIt = false;

                    if (col.m_id == RPConstants.TGRID_TOTITEM_ID)
                        bDoIt = true;
                    else if (by_role == false)
                        bDoIt = true;
                    else if (col.m_id == RPConstants.TGRID_TOTRESRES_ID)
                        bDoIt = true;

                    if (bDoIt)
                    {
                        string sn = col.m_realname.Replace("/n", "");
                        sn = sn.Replace(" ", "");


                        sn = sn.Replace("\r", "");
                        sn = sn.Replace("\n", "");

                        string snv = col.m_dispname.Replace("/n", "\n");

                        if (col.m_id == RPConstants.TGRID_TOTRESRES_ID)
                        {
                            snv = sResRolHeader;
                            sn = "ResOrRole";
                        }



                        xC = xCols.CreateSubStruct("C");

                        if (col.m_id > 100)
                            sn = "x" + sn;

                        xC.CreateStringAttr("Name", sn);
                        xC.CreateIntAttr("ShowHint", 0);

                        m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                        m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");

                        m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
                        m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");

                        m_xDefPI.CreateStringAttr(sn + "HtmlPrefix", "");
                        m_xDefPI.CreateStringAttr(sn + "HtmlPostfix", "");

                        xC.CreateStringAttr("Class", "GMCellMain");
                        if (col.m_type == 2)
                        {
                            //                       xC.CreateStringAttr("Type", "Date");
                            //                       xC.CreateStringAttr("Format", "MM/dd/yyyy");
                        }
                        else if (col.m_type == 3)
                        {
                            xC.CreateStringAttr("Type", "Float");
                            xC.CreateStringAttr("Format", ",0.##");

                        }
                        else
                            xC.CreateStringAttr("Type", "Text");

                        xC.CreateIntAttr("CanEdit", 0);
                        xC.CreateIntAttr("CanMove", 1);
                        xC.CreateIntAttr("CanSort", 1);
                        xC.CreateIntAttr("CaseSensitive", 0);

                        if (col.m_col_hidden == true)
                        {
                            xC.CreateIntAttr("Width", 0);
                        }
                        m_xHeader2.CreateStringAttr(sn, " ");
                        m_xHeader1.CreateStringAttr(sn, snv);
                        m_xHeader1.CreateIntAttr(sn + "SortIcons", 1);

                    }
                }
                catch (Exception ex)
                {

                }
            }


            return true;
        }
        public void AddPeriodColumn(string sId, string sName, int iMode, List<RPATGRow> disp, bool bUseHeatmap)
        {


            CStruct xC = null;

            int cnt = disp.Count;
            ++cnt;

            if (cnt == 0)
                return;

            string sSumFunc = "(Row.id == 'Filter' ? '' : sum())";
            string sMaxFunc = "(Row.id == 'Filter' ? '' : max())";
            string sMinFunc = "(Row.id == 'Filter' ? '' : min())";
            //       string sIconFunc = "/_layouts/ppm/images/Nogif.gif"; // "/_layouts/ppm/images/Red.gif";     //"(Row.id == 'Filter' ? '' : '/_layouts/ppm/images/Red.gif')";


            cnt = 0;
            var spnncnt = disp.Count;

            if (bUseHeatmap)
            {
                m_xHeader1.CreateStringAttr("P" + sId + "H", sName + "\nHeatMap");
                xC = m_xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + sId + "H");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateStringAttr("Format", ",0.##");
                xC.CreateIntAttr("Visible", 0);
                xC.CreateIntAttr("CanSort", 0);
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateIntAttr("ShowHint", 0);
                xC.CreateStringAttr("Align", "Right");
                xC.CreateIntAttr("CanSelect", 0);
                xC.CreateIntAttr("CanHide", 0);
                if (iMode != 3)
                {
                    m_xDefTree.CreateStringAttr("P" + sId + "H" + "Formula", sSumFunc);   //"sum()");
                    m_xDefTree.CreateStringAttr("P" + sId + "H" + "Format", ",#.##");
                }

                m_xDefNode.CreateStringAttr("P" + sId + "H" + "Formula", "");


                xC.CreateIntAttr("MinWidth", 45);
                xC.CreateIntAttr("Width", 65);
                spnncnt *= 2;
            }



            foreach (RPATGRow ot in disp)
            {
                try
                {
                    ++cnt;



                    if (cnt == 1)
                    {
                        if (disp.Count > 1)
                            m_xHeader1.CreateIntAttr("P" + sId + "C1Span", spnncnt);

                        m_xHeader1.CreateStringAttr("P" + sId + "C1", sName);
                    }
                    else
                        m_xHeader1.CreateStringAttr("P" + sId + "C" + cnt.ToString(), " ");


                    m_xHeader2.CreateStringAttr("P" + sId + "C" + cnt.ToString(), ot.Name);
                    m_xHeader2.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "SortIcons", "0");


                    xC = m_xPeriodCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "P" + sId + "C" + cnt.ToString());
                    //                  xC.CreateStringAttr("Type", "Text");
                    xC.CreateStringAttr("Type", "Float");
                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Format", ",0.##");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateStringAttr("Align", "Right");
                    //             xC.CreateStringAttr("Icon", "/_layouts/ppm/images/Green.gif");

                    xC.CreateIntAttr("CanSelect", 0);

                    if (bUseHeatmap)
                    {
                        m_xHeader1.CreateStringAttr("X" + sId + "C" + cnt.ToString(), " ");
                        m_xHeader2.CreateStringAttr("X" + sId + "C" + cnt.ToString(), sName + ot.Name + "HeatMap");


                        m_xHeader1.CreateStringAttr("Y" + sId + "C" + cnt.ToString(), " ");
                        m_xHeader2.CreateStringAttr("Y" + sId + "C" + cnt.ToString(), sName + ot.Name + "HeatMap");


                        xC = m_xPeriodCols.CreateSubStruct("C");
                        xC.CreateStringAttr("Name", "X" + sId + "C" + cnt.ToString());
                        xC.CreateIntAttr("ShowHint", 0);
                        xC.CreateStringAttr("Type", "Float");
                        xC.CreateStringAttr("Format", ",0.##");
                        xC.CreateIntAttr("CanSort", 0);
                        xC.CreateIntAttr("CanMove", 0);
                        xC.CreateStringAttr("Align", "Right");
                        xC.CreateIntAttr("Visible", 0);
                        xC.CreateIntAttr("CanSelect", 0);
                        xC.CreateIntAttr("CanHide", 0);

                        xC = m_xPeriodCols.CreateSubStruct("C");
                        xC.CreateStringAttr("Name", "Y" + sId + "C" + cnt.ToString());
                        xC.CreateIntAttr("ShowHint", 0);
                        xC.CreateStringAttr("Type", "Float");
                        xC.CreateStringAttr("Format", ",0.##");
                        xC.CreateIntAttr("CanSort", 0);
                        xC.CreateIntAttr("CanMove", 0);
                        xC.CreateStringAttr("Align", "Right");
                        xC.CreateIntAttr("Visible", 0);
                        xC.CreateIntAttr("CanSelect", 0);
                        xC.CreateIntAttr("CanHide", 0);
                    }



                    if (iMode != 3)
                    {
                        if (bUseHeatmap)
                        {
                            m_xDefTree.CreateStringAttr("X" + sId + "C" + cnt.ToString() + "Format", "##");
                            m_xDefTree.CreateStringAttr("X" + sId + "C" + cnt.ToString() + "Formula", sMaxFunc);   //"sum()");
                            m_xDefTree.CreateStringAttr("Y" + sId + "C" + cnt.ToString() + "Format", "##");
                            m_xDefTree.CreateStringAttr("Y" + sId + "C" + cnt.ToString() + "Formula", sMinFunc);   //"sum()");
                            //m_xDefTree.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "Icon", sIconFunc);   //"sum()");
                            //m_xDefTree.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "IconAlign", "Left");   //"sum()");
                            //m_xDefNode.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "Icon", "/_layouts/ppm/images/Nogif.gif");   //"sum()");
                            //m_xDefNode.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "IconAlign", "Left");   //"sum()");

                        }

                        m_xDefTree.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "Format", ",0.##");
                        m_xDefTree.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "Formula", sSumFunc);   //"sum()");
                                                                                                               //     m_xDefTree.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "Formula", "sum()");
                    }

                    if (bUseHeatmap)
                    {
                        m_xDefNode.CreateStringAttr("X" + sId + "C" + cnt.ToString() + "Formula", "");
                        m_xDefNode.CreateStringAttr("Y" + sId + "C" + cnt.ToString() + "Formula", "");
                        m_xDefPI.CreateStringAttr("X" + sId + "C" + cnt.ToString() + "Formula", "");
                        m_xDefPI.CreateStringAttr("Y" + sId + "C" + cnt.ToString() + "Formula", "");
                    }

                    m_xDefNode.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "Formula", "");
                    m_xDefPI.CreateStringAttr("P" + sId + "C" + cnt.ToString() + "Formula", "");


                    xC.CreateIntAttr("MinWidth", 45);
                    xC.CreateIntAttr("Width", 65);
                }
                catch (Exception ex)
                {

                }

            }
        }
        public void FinalizeGridLayout()
        {
        }
        public string GetString()
        {
            return xGrid.XML();
        }
        public bool InitializeGridData()
        {

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);
            //         xI.CreateStringAttr("Def", "Summary");
            m_nLevel = 0;
            m_xLevels[m_nLevel] = xI;
            return true;
        }

        public void AddDetailRow(clsResFullDAta oDet, List<clsRXDisp> Cols, clsResourceValues o_cResVals, Dictionary<int, clsViewTargetColours> TargetColors, int rID, int iMode, bool by_role, List<RPATGRow> disp, bool bUseHeatmap, int iHeatMapID, bool bDoZeroRowCleverStuff, int HeatFieldColour)
        {

            int tarlev;

            double xval;
            double cval;
            int i;
            string cellval;
            int cnt = 0;

            NumberFormatInfo providerEn = new System.Globalization.NumberFormatInfo();
            providerEn.NumberDecimalSeparator = ".";
            providerEn.NumberGroupSeparator = ",";
            providerEn.NumberGroupSizes = new int[] { 3 };

            bool bDoIt = true;

            if (bDoZeroRowCleverStuff)
            {
                bDoIt = false;
                i = 0;
                cnt = disp.Count;

                if (cnt != 0)
                {

                    foreach (CPeriod oPer in o_cResVals.Periods.Values)
                    {
                        if (bDoIt)
                            break;

                        try
                        {

                            ++i;


                            cnt = 0;
                            foreach (RPATGRow ot in disp)
                            {
                                ++cnt;

                                xval = GetDataValue(oDet, ot.fid, iMode, i, false, (bUseHeatmap ? iHeatMapID : 0));

                                if (xval != 0)
                                {
                                    bDoIt = true;
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }


                }
            }

            if (bDoIt == false)
                return;


            CStruct xIParent = m_xLevels[0];
            CStruct xI = xIParent.CreateSubStruct("I");
            clsEPKItem oItem;
            clsListItem oListItem;
            clsCatItem oc;

            m_xLevels[1] = xI;

            m_lastnode = xI;

            xI.CreateStringAttr("id", rID.ToString());
            xI.CreateStringAttr("Color", "white");
            xI.CreateStringAttr("Def", "Leaf");

            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateIntAttr("NoColorState", 1);
            xI.CreateIntAttr("rowid", rID);
            xI.CreateBooleanAttr("rowidCanEdit", false);



            xI.CreateStringAttr("rtSelect", (oDet.bSelected ? "1" : "0"));
            xI.CreateBooleanAttr("rtSelectCanEdit", true);


            foreach (clsRXDisp col in Cols)
            {
                try
                {


                    if ((col.m_id == RPConstants.TGRID_TOTITEM_ID) || (!((by_role == true && col.m_id > 100) || (by_role == true && col.m_id == RPConstants.TGRID_TOTDEPT_ID))))
                    {
                        string sn = col.m_realname.Replace("/n", "");
                        sn = sn.Replace(" ", "");

                        sn = sn.Replace("\r", "");
                        sn = sn.Replace("\n", "");

                        if (col.m_id == RPConstants.TGRID_TOTRESRES_ID)
                            sn = "ResOrRole";


                        switch (col.m_id)
                        {

                            case RPConstants.TGRID_TOTDEPT_ID:
                                if (by_role == false)
                                {
                                    if (o_cResVals.Departments != null)
                                    {

                                        if (o_cResVals.Departments.TryGetValue(oDet.resavail.DeptID, out oItem) == true)
                                            xI.CreateStringAttr(sn, oItem.Name);
                                    }
                                }
                                break;

                            case RPConstants.TGRID_TOTRESRES_ID:
                                xI.CreateStringAttr(sn, oDet.ResOrRole);

                                break;

                            case RPConstants.TGRID_TOTROLE_ID:
                                if (by_role == false)
                                {
                                    if (o_cResVals.Roles.TryGetValue(oDet.resavail.RoleID, out oListItem) == true)
                                        xI.CreateStringAttr(sn, oListItem.Name);
                                    break;
                                }
                                break;


                            case RPConstants.TGRID_TOTITEM_ID:

                                string sPIVal = "";

                                foreach (string sval in oDet.PIList.Values)
                                {
                                    if (sPIVal == "")
                                        sPIVal = sval;
                                    else
                                        sPIVal += "," + sval;
                                }

                                xI.CreateStringAttr(sn, sPIVal);
                                break;

                            case RPConstants.TGRID_TOTCC_ID:
                                if (by_role == false)
                                {
                                    if (o_cResVals.CostCategories != null)
                                    {
                                        if (o_cResVals.CostCategories.TryGetValue(oDet.resavail.CostCat, out oc) == true)
                                            xI.CreateStringAttr(sn, oc.Name);
                                    }
                                }
                                break;

                            case RPConstants.TGRID_TOTCCFULL_ID:
                                if (by_role == false)
                                {
                                    if (o_cResVals.CostCategories != null)
                                    {
                                        if (o_cResVals.CostCategories.TryGetValue(oDet.resavail.CostCatRole, out oc) == true)
                                            xI.CreateStringAttr(sn, oc.FullName);
                                    }
                                }
                                break;



                            default:

                                int j = 0;
                                string sFull = "";
                                sn = "x" + sn;

                                if (o_cResVals.ResFields != null)
                                {

                                    foreach (clsPortField opf in o_cResVals.ResFields)
                                    {
                                        if (col.m_id == opf.ID)
                                        {
                                            RPConstants.GetCustValue(opf.ID, oDet.resavail.CustomFields, out j, out sFull, o_cResVals);
                                            xI.CreateStringAttr(sn, sFull);
                                            break;

                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {

                }


            }




            i = 0;
            cnt = disp.Count;

            if (cnt == 0)
                return;

            foreach (CPeriod oPer in o_cResVals.Periods.Values)
            {
                try
                {

                    string sCName;
                    ++i;
                    cval = 0;

                    if (bUseHeatmap)
                    {
                        cval = GetDataValue(oDet, iHeatMapID, iMode, i, true, 0);

                        if (iMode == 0)
                            cellval = cval.ToString(providerEn);
                        else if (iMode == 2)
                            cellval = cval.ToString(providerEn);
                        else
                            cellval = cval.ToString(providerEn);

                        xI.CreateStringAttr("P" + oPer.PeriodID.ToString() + "H", cellval);
                    }
                    cnt = 0;
                    foreach (RPATGRow ot in disp)
                    {
                        ++cnt;
                        sCName = "P" + oPer.PeriodID.ToString() + "C" + cnt.ToString();

                        xval = GetDataValue(oDet, ot.fid, iMode, i, false, (bUseHeatmap ? iHeatMapID : 0));
                        cellval = "";


                        if (iMode == 0)
                            cellval = xval.ToString(providerEn);
                        else if (iMode == 2)
                            cellval = xval.ToString(providerEn);
                        else
                            cellval = xval.ToString(providerEn);


                        xI.CreateStringAttr(sCName, cellval);

                        if (bUseHeatmap && ot.fid == 0)
                        {
                            xval = GetDataValue(oDet, ot.fid, iMode, i, true, iHeatMapID);
                            cval = GetDataValue(oDet, iHeatMapID, iMode, i, true, iHeatMapID);
                            string rgb = RPAGridHelper.TargetBackground(xval, cval, TargetColors, out tarlev, HeatFieldColour);
                            xI.CreateIntAttr("X" + oPer.PeriodID.ToString() + "C" + cnt.ToString(), tarlev);

                            if (tarlev <= 0)
                                tarlev = 0;

                            xI.CreateIntAttr("Y" + oPer.PeriodID.ToString() + "C" + cnt.ToString(), tarlev);

                            if (rgb != "" && iHeatMapID != ot.fid)
                            {
                                xI.CreateStringAttr(sCName + "Color", rgb);
                                xI.CreateStringAttr(sCName + "ExportStyle", "background-color: " + rgb);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }

        public void AddPIRow(clsResFullDAta oRFull, clsResXData oDet, List<clsRXDisp> Cols, clsResourceValues o_cResVals, Dictionary<int, clsViewTargetColours> TargetColors, int rID, int iMode, bool by_role, List<RPATGRow> disp, bool bUseHeatmap, int iHeatMapID, bool bDoZeroRowCleverStuff, int HeatFieldColour, int xLi, int projectId)
        {
            int tarlev;
            double xval;
            double cval;
            int i;
            string cellval;
            int cnt = 0;
            bool bDoIt = true;

            if (bDoZeroRowCleverStuff)
            {
                bDoIt = false;
                i = 0;
                cnt = disp.Count;

                if (cnt != 0)
                {
                    foreach (CPeriod oPer in o_cResVals.Periods.Values)
                    {
                        if (bDoIt)
                            break;
                        try
                        {
                            ++i;
                            cnt = 0;
                            foreach (RPATGRow ot in disp)
                            {
                                ++cnt;
                                xval = GetPIDataValue(oDet, iMode, i);
                                if (xval != 0)
                                {
                                    bDoIt = true;
                                    break;
                                }
                            }
                        }
                        catch (Exception ex) { }
                    }
                }
            }

            if (bDoIt == false)
                return;

            CStruct xIParent = m_xLevels[0];
            CStruct xI = m_lastnode.CreateSubStruct("I");
            clsEPKItem oItem;
            clsListItem oListItem;
            clsCatItem oc;

            m_xLevels[2] = xI;

            xI.CreateStringAttr("id", rID.ToString());
            xI.CreateStringAttr("Color", "white");
            xI.CreateStringAttr("Def", "PI");

            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateIntAttr("NoColorState", 1);
            xI.CreateIntAttr("rowid", rID);
            xI.CreateBooleanAttr("rowidCanEdit", false);

            xI.CreateStringAttr("rtSelectType", "Text");
            xI.CreateStringAttr("rtSelect", " ");
            xI.CreateBooleanAttr("rtSelectCanEdit", false);

            foreach (clsRXDisp col in Cols)
            {
                try
                {
                    if ((col.m_id == RPConstants.TGRID_TOTITEM_ID) || (!((by_role == true && col.m_id > 100) || (by_role == true && col.m_id == RPConstants.TGRID_TOTDEPT_ID))))
                    {
                        string sn = col.m_realname.Replace("/n", "");
                        sn = sn.Replace(" ", "");
                        sn = sn.Replace("\r", "");
                        sn = sn.Replace("\n", "");

                        if (col.m_id == RPConstants.TGRID_TOTRESRES_ID)
                            sn = "ResOrRole";

                        switch (col.m_id)
                        {
                            case RPConstants.TGRID_TOTDEPT_ID:
                            case RPConstants.TGRID_TOTRESRES_ID:
                            case RPConstants.TGRID_TOTROLE_ID:
                            case RPConstants.TGRID_TOTCC_ID:
                            case RPConstants.TGRID_TOTCCFULL_ID:
                                break;
                            case RPConstants.TGRID_TOTITEM_ID:
                                xI.CreateStringAttr(sn, oDet.ProjectName);
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception ex) { }
            }

            i = 0;
            cnt = disp.Count;

            if (cnt == 0)
                return;

            foreach (CPeriod oPer in o_cResVals.Periods.Values)
            {
                try
                {
                    string sCName;
                    ++i;
                    cval = 0;
                    cnt = 0;

                    foreach (RPATGRow ot in disp)
                    {
                        ++cnt;
                        sCName = "P" + oPer.PeriodID.ToString() + "C" + cnt.ToString();

                        if (ot.fid <= 0)
                        {
                            xval = GetPIDataValue(oRFull, oDet, iMode, i, ot.fid, xLi, bUseHeatmap, iHeatMapID, projectId, by_role);
                            cellval = "";

                            if (iMode == 0)
                                cellval = xval.ToString("0.##");
                            else if (iMode == 2)
                                cellval = xval.ToString("0.###");
                            else
                                cellval = xval.ToString("0.###");

                            xI.CreateStringAttr(sCName, cellval);

                            if (bUseHeatmap && ot.fid <= 0)
                            {
                                string rgb = RPAGridHelper.TargetBackground(xval, xval, TargetColors, out tarlev, HeatFieldColour);
                                xI.CreateIntAttr("X" + oPer.PeriodID.ToString() + "C" + cnt.ToString(), tarlev);

                                if (tarlev <= 0)
                                    tarlev = 0;

                                xI.CreateIntAttr("Y" + oPer.PeriodID.ToString() + "C" + cnt.ToString(), tarlev);

                                if (rgb != "" && iHeatMapID != ot.fid)
                                {
                                    xI.CreateStringAttr(sCName + "Color", rgb);
                                    xI.CreateStringAttr(sCName + "ExportStyle", "background-color: " + rgb);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex) { }
            }
        }

        private string GetStatusText(int stat)
        {

            switch (stat)
            {
                case RPConstants.CONST_Commitment:
                    return RPConstants.CONST_text_Commitment;

                case RPConstants.CONST_REQUEST:
                    return RPConstants.CONST_text_Request;

                case RPConstants.CONST_NW:
                    return RPConstants.CONST_text_NW;

                case RPConstants.CONST_MSPF:
                    return RPConstants.CONST_text_MSPF;

                case RPConstants.CONST_REQUIRE:
                    return RPConstants.CONST_text_OpenRequire;
            }

            return "Unknown";

        }

        private double GetDataValue(clsResFullDAta oDet, int fid, int iMode, int i, bool bForHeatmap, int iHeatmapID)
        {
            double retval = 0;
            double vval = 0;
            double fval = 0;

            if (fid == 0)
            {
                vval = oDet.tot_Totals.getvarr(i);
                fval = oDet.tot_Totals.getftarr(i);
            }
            else if (fid == -1)
            {
                vval = oDet.tot_actual.getvarr(i);
                fval = oDet.tot_actual.getftarr(i);
            }
            else if (fid == -2)
            {
                vval = oDet.tot_proposal.getvarr(i);
                fval = oDet.tot_proposal.getftarr(i);
            }
            else if (fid == -3)
            {
                vval = oDet.tot_scheduled.getvarr(i);
                fval = oDet.tot_scheduled.getftarr(i);
            }
            else if (fid == -4)
            {
                vval = oDet.tot_committed.getvarr(i);
                fval = oDet.tot_committed.getftarr(i);
            }
            else if (fid == -5)
            {
                vval = oDet.tot_personel.getvarr(i);
                fval = oDet.tot_personel.getftarr(i);
            }
            else if (fid == -6)
            {
                vval = oDet.tot_avail.getvarr(i);
                fval = oDet.tot_avail.getftarr(i);
            }
            else if (fid == -7)
            {
                if (bForHeatmap)
                {
                    vval = oDet.tot_Totals.getvarr(i);
                    fval = oDet.tot_Totals.getftarr(i);
                }
                else
                {
                    vval = oDet.tot_avail.getvarr(i) - oDet.tot_Totals.getvarr(i);
                    fval = oDet.tot_avail.getftarr(i) - oDet.tot_Totals.getftarr(i);
                }
            }
            else if (fid == -8)
            {
                if (iHeatmapID == 0 || iHeatmapID > oDet.CapScen.Count)
                {
                    vval = -oDet.tot_Totals.getvarr(i);
                    fval = -oDet.tot_Totals.getftarr(i);
                }
                else if (iHeatmapID <= -1 && iHeatmapID >= -6)
                {
                    if (iHeatmapID == -1)
                    {
                        vval = oDet.tot_actual.getvarr(i);
                        fval = oDet.tot_actual.getftarr(i);
                    }
                    else if (iHeatmapID == -2)
                    {
                        vval = oDet.tot_proposal.getvarr(i);
                        fval = oDet.tot_proposal.getftarr(i);
                    }
                    else if (iHeatmapID == -3)
                    {
                        vval = oDet.tot_scheduled.getvarr(i);
                        fval = oDet.tot_scheduled.getftarr(i);
                    }
                    else if (iHeatmapID == -4)
                    {
                        vval = oDet.tot_committed.getvarr(i);
                        fval = oDet.tot_committed.getftarr(i);
                    }
                    else if (iHeatmapID == -5)
                    {
                        vval = oDet.tot_personel.getvarr(i);
                        fval = oDet.tot_personel.getftarr(i);
                    }
                    else if (iHeatmapID == -6)
                    {
                        vval = oDet.tot_avail.getvarr(i);
                        fval = oDet.tot_avail.getftarr(i);
                    }

                    vval -= oDet.tot_Totals.getvarr(i);
                    fval -= oDet.tot_Totals.getftarr(i);
                }

                else if (bForHeatmap)
                {
                    vval = oDet.tot_Totals.getvarr(i);
                    fval = oDet.tot_Totals.getftarr(i);
                }
                else
                {
                    vval = oDet.CapScen[iHeatmapID - 1].getvarr(i) - oDet.tot_Totals.getvarr(i);
                    fval = oDet.CapScen[iHeatmapID - 1].getftarr(i) - oDet.tot_Totals.getftarr(i);
                }
            }
            else if (fid > 0 && fid <= oDet.CapScen.Count)
            {
                vval = oDet.CapScen[fid - 1].getvarr(i);
                fval = oDet.CapScen[fid - 1].getftarr(i);
            }

            if (iMode == 3)
            {
                if (fval == 0)
                    retval = 0;
                else
                    retval = (vval * 100) / fval;
            }
            else if (iMode == 0)
                retval = vval;
            else
                retval = fval;

            if (iMode == 1)
                retval /= 100;

            return retval;
        }

        private double GetPIDataValue(clsResXData oDet, int iMode, int i)
        {
            double retval = 0;
            double vval = 0;
            double fval = 0;


            vval = oDet.getvarr(i);
            fval = oDet.getftarr(i);

            if (iMode == 3)
            {
                if (fval == 0)
                    retval = 0;
                else
                    retval = (vval * 100) / fval;
            }
            else if (iMode == 0)
                retval = vval;
            else
                retval = fval;



            if (iMode == 1)
                retval /= 100;

            return retval;
        }

        private double GetPIDataValue(clsResFullDAta oFullData, clsResXData oDet, int iMode, int i, int fid, int idx, bool bUseHeatmap, int iHeatMapID, int projectId, bool byRole)
        {
            //All the calculation performd for Show Totals section is based on following link:
            //https://upland.screenstepslive.com/s/EPMLive2013/m/UserGuide/l/147531-how-do-i-use-the-total-column-feature-within-the-resource-analyzer
            double retval = 0;
            double vval = 0;
            double fval = 0;

            try
            {
                if (fid == 0)
                {
                    vval = oDet.getvarr(i);
                    fval = oDet.getftarr(i);
                }
                else if (fid == -1)
                {
                    //Actual Work equals Timesheet Actuals entered.
                    if (oFullData.actual.Count > 0)
                    {
                        idx = -1;
                        if (byRole)
                        {
                            for (int counter = 0; counter < oFullData.actual.Count; counter++)
                            {
                                if (oFullData.actual[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    vval += Convert.ToDouble(oFullData.actual[idx].WrkHours[i]);
                                    fval += Convert.ToDouble(oFullData.actual[idx].FTEVals[i]);
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                        }
                        else
                        {
                            for (int counter = 0; counter < oFullData.actual.Count; counter++)
                            {
                                if (oFullData.actual[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.actual[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.actual[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -2)
                {
                    //Proposed Work equals resource planned work that has not yet been committed.
                    if (oFullData.proposal.Count > 0)
                    {
                        idx = -1;
                        if (byRole)
                        {
                            for (int counter = 0; counter < oFullData.proposal.Count; counter++)
                            {
                                if (oFullData.proposal[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    vval += Convert.ToDouble(oFullData.proposal[idx].WrkHours[i]);
                                    fval += Convert.ToDouble(oFullData.proposal[idx].FTEVals[i]);
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                        }
                        else
                        {
                            for (int counter = 0; counter < oFullData.proposal.Count; counter++)
                            {
                                if (oFullData.proposal[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.proposal[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.proposal[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -3)
                {
                    //Scheduled Work equals the work allocation pulled in from the designated work lists, such as Task Center, Issues, Risks, etc..
                    if (byRole)
                    {
                        for (int counter = 0; counter < oFullData.scheduled.Count; counter++)
                        {
                            if (oFullData.scheduled[counter].ProjectID == projectId)
                            {
                                idx = counter;
                                vval += Convert.ToDouble(oFullData.scheduled[idx].WrkHours[i]);
                                fval += Convert.ToDouble(oFullData.scheduled[idx].FTEVals[i]);
                            }
                        }
                        if (idx == -1)
                        {
                            vval = fval = 0;
                        }
                    }
                    else
                    {
                        if (oFullData.scheduled.Count > 0)
                        {
                            idx = -1;
                            for (int counter = 0; counter < oFullData.scheduled.Count; counter++)
                            {
                                if (oFullData.scheduled[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.scheduled[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.scheduled[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -4)
                {
                    //Committed Work equals the hours in resource plans that have been committed.
                    if (byRole)
                    {
                        for (int counter = 0; counter < oFullData.committed.Count; counter++)
                        {
                            if (oFullData.committed[counter].ProjectID == projectId)
                            {
                                idx = counter;
                                vval += Convert.ToDouble(oFullData.committed[idx].WrkHours[i]);
                                fval += Convert.ToDouble(oFullData.committed[idx].FTEVals[i]);
                            }
                        }
                        if (idx == -1)
                        {
                            vval = fval = 0;
                        }
                    }
                    else
                    {
                        if (oFullData.committed.Count > 0)
                        {
                            idx = -1;
                            for (int counter = 0; counter < oFullData.committed.Count; counter++)
                            {
                                if (oFullData.committed[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.committed[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.committed[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -5)
                {
                    //Personal Time Off pulls in the hours entered into the Time Off Requests.
                    if (byRole)
                    {
                        for (int counter = 0; counter < oFullData.personel.Count; counter++)
                        {
                            if (oFullData.personel[counter].ProjectID == projectId)
                            {
                                idx = counter;
                                vval += Convert.ToDouble(oFullData.personel[idx].WrkHours[i]);
                                fval += Convert.ToDouble(oFullData.personel[idx].FTEVals[i]);
                            }
                        }
                        if (idx == -1)
                        {
                            vval = fval = 0;
                        }
                    }
                    else
                    {
                        if (oFullData.personel.Count > 0)
                        {
                            idx = -1;
                            for (int counter = 0; counter < oFullData.personel.Count; counter++)
                            {
                                if (oFullData.personel[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.personel[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.personel[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -6)
                {
                    //Availability equals the number of work hours each resource is available for each calendar period (monthly/weekly/quarterly/etc.). 
                    //It is important to note that this is resource specific based on each resource’s work hours schedule.
                    vval = oFullData.tot_avail.getvarr(i);
                    fval = oFullData.tot_avail.getftarr(i);
                }
                else if (fid == -7)
                {
                    //Remaining Availability equals Availability minus any committed and scheduled work.
                    double totWrkHrs = 0, totFTEHrs = 0;
                    double avlWrkHrs = 0, avlFTEHrs = 0;

                    if (oDet.ProjectID == projectId)
                    {
                        if (byRole)
                        {
                            avlWrkHrs = oFullData.tot_avail.getvarr(i);
                            avlFTEHrs = oFullData.tot_avail.getftarr(i);
                        }
                        else
                        {
                            if (oFullData.avail.Count > 0)
                            {
                                idx = 0;
                                for (int counter = 0; counter < oFullData.avail.Count; counter++)
                                {
                                    if (oFullData.avail[counter].ProjectID == projectId)
                                    {
                                        idx = counter;
                                        break;
                                    }
                                }
                                if (idx == -1)
                                {
                                    avlWrkHrs = avlFTEHrs = 0;
                                }
                                else
                                {
                                    avlWrkHrs = Convert.ToDouble(oFullData.avail[idx].WrkHours[i]);
                                    avlFTEHrs = Convert.ToDouble(oFullData.avail[idx].FTEVals[i]);
                                }
                            }
                        }

                        totWrkHrs = oDet.getvarr(i);
                        totFTEHrs = oDet.getftarr(i);

                        vval = avlWrkHrs - totWrkHrs;
                        fval = avlFTEHrs - totFTEHrs;
                    }
                }
                else if (fid > 0 && fid <= oFullData.CapScen.Count)
                {
                    vval = oFullData.CapScen[fid - 1].getvarr(i);
                    fval = oFullData.CapScen[fid - 1].getftarr(i);
                }

                if (iMode == 3)
                {
                    if (fval == 0)
                        retval = 0;
                    else
                        retval = (vval * 100) / fval;
                }
                else if (iMode == 0)
                    retval = vval;
                else
                    retval = fval;

                if (iMode == 1)
                    retval /= 100;

                return retval;
            }
            catch { return 0; }
        }
    }

    internal class RPATargetGrid
    {
        private CStruct xGrid;

        private CStruct m_xHeader1;
        private CStruct m_xPeriodCols;
        private CStruct m_xIParentRoot;


        public bool InitializeGridLayout()
        {

            CStruct xC = null;

            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("SuppressMessage", 3);

            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("ColResizing", 1);

            xCfg.CreateIntAttr("PrintCols", 0);

            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateBooleanAttr("NoTreeLines", true);

            //   xCfg.CreateIntAttr("MaxHeight", 300);
            xCfg.CreateIntAttr("MaxWidth", 1);

            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("FilterEmpty", 1);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            xCfg.CreateIntAttr("ExportFormat", 1);
            xCfg.CreateIntAttr("WideHScroll", 0);
            xCfg.CreateIntAttr("ShowVScroll", 1);

            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateIntAttr("FilterEmpty", 1);


            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");

            xCfg.CreateIntAttr("LeftWidth", 150);
            xCfg.CreateIntAttr("Width", 250);



            xCfg.CreateIntAttr("Sorting", 0);


            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            m_xPeriodCols = xGrid.CreateSubStruct("Cols");

            CStruct xHead = xGrid.CreateSubStruct("Head");
            m_xHeader1 = xGrid.CreateSubStruct("Header");

            m_xHeader1.CreateIntAttr("Spanned", -1);
            m_xHeader1.CreateIntAttr("SortIcons", 0);

            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "CostCategory");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateIntAttr("CanMove", 0);
            m_xHeader1.CreateStringAttr("CostCategory", "Cost Category");

            xC = xLeftCols.CreateSubStruct("C");


            return true;
        }

        public void AddPeriodColumn(string sId, string sName, bool ShowFTEs)
        {
            CStruct xC = null;

            m_xHeader1.CreateStringAttr("P" + sId + "V", sName);


            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P" + sId + "V");
            xC.CreateStringAttr("Type", "Float");
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Format", "0.###");


        }
        public void FinalizeGridLayout()
        {

        }
        public string GetString()
        {
            return xGrid.XML();
        }


        public bool InitializeGridData()
        {


            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateBooleanAttr("CanEdit", false);

            m_xIParentRoot = xI;
            return true;
        }

        public void AddDetailRow(clsResxAvail oRA, int rID, bool ShowFTEs, int maxp)
        {
            CStruct xIParent = m_xIParentRoot;
            CStruct xI = xIParent.CreateSubStruct("I");

            xI.CreateStringAttr("id", rID.ToString());

            string sPad = "";

            for (int i = 2; i <= oRA.DeptID; i++)
                sPad += "   ";


            xI.CreateStringAttr("Color", "white");
            xI.CreateStringAttr("CostCategory", sPad + oRA.Name);

            xI.CreateIntAttr("NoColorState", 1);

            for (int i = 1; i <= maxp; i++)
            {
                if (ShowFTEs)
                {
                    xI.CreateDoubleAttr("P" + i.ToString() + "V", oRA.getftarr(i));
                }
                else
                {
                    xI.CreateDoubleAttr("P" + i.ToString() + "V", oRA.getvarr(i));
                }


                xI.CreateIntAttr("P" + i.ToString() + "VCanEdit", 1);
            }
        }
    }

    internal class RPALegendGrid
    {
        private CStruct xGrid;
        private CStruct m_Par = new CStruct();

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
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("SuppressMessage", 3);
            xCfg.CreateIntAttr("PrintCols", 0);
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

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_Par = xI;
        }


        public string GetString()
        {
            return xGrid.XML();
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

    }

}