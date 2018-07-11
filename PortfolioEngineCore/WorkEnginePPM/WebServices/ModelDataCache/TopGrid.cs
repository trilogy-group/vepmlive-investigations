using System;
using System.Collections.Generic;
using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class TopGrid
    {
        private CStruct xGrid;
        private CStruct m_xPeriodCols;
        private CStruct m_xHeader1;
        private CStruct m_xHeader2;
        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;

        private string RemoveNastyCharacters(string sn)
        {

            string retsn = "";
            string sNastyChars = "!@#$%^&*()_+-={}[]|:;'?/~`";

            sn = sn.Replace(" ", "");
            sn = sn.Replace("'", "");
            sn = sn.Replace("\r", "");
            sn = sn.Replace("\n", "");
            sn = sn.Replace("\"", "");
            sn = sn.Replace("\\", "");

            for (int i = 0; i < sn.Length; i++)
            {
                string sx = sn.Substring(i, 1);

                if (sNastyChars.IndexOf(sx) == -1)
                    retsn += sx;
            }

            return retsn;

        }

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

            xCfg.CreateStringAttr("Grouping", "0");


            xCfg.CreateIntAttr("Sorting", 0);
            xCfg.CreateStringAttr("Filtering", "0");



            if (UsingGrouping)
                xCfg.CreateStringAttr("MainCol", "xGrouping");

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
                xC.CreateStringAttr("Name", "xGrouping");
                xC.CreateStringAttr("Type", "Text");
                //xC.CreateIntAttr("Width", 250);
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateBooleanAttr("CanEdit", false);
                m_xHeader1.CreateStringAttr("xGrouping", " ");
                m_xHeader2.CreateStringAttr("xGrouping", "Grouping");
            }


            foreach (SortFieldDefn sng in DetCol)
            {
                string sn = sng.name.Replace(" ", "");

                sn = sn.Replace("\r", "");
                sn = sn.Replace("\n", "");
                sn = RemoveNastyCharacters(sn);

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


            }
            else
            {
                xI.CreateStringAttr("Color", "255,255,255");

            }



            xI.CreateStringAttr("Select", (oDet.bSelected ? "1" : "0"));
            xI.CreateBooleanAttr("SelectCanEdit", true);
            xI.CreateBooleanAttr("CanEdit", false);

            if (oDet.m_lev != 1)
                xI.CreateIntAttr("CanFilter", 2);


            if (UsingGrouping)
            {
                xI.CreateStringAttr("xGrouping", oDet.sName);
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
                sn = RemoveNastyCharacters(sn);

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

    }
}
