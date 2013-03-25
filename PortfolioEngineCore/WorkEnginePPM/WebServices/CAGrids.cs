using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Linq;
using WorkEnginePPM;
using CostDataValues;
using CADataCache;
using PortfolioEngineCore;


namespace CADataCache
{
    internal class CATopGrid
    {
        private CStruct xGrid;
        private CStruct m_xPeriodCols;
        private CStruct m_xMiddleCols;
        private CStruct m_xHeader1;
        private CStruct m_xHeader2;
        private CStruct m_xDef;
        private CStruct m_xDefTree;
        private CStruct m_xDefNode;

        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;


        public bool InitializeGridLayout(List<clsColDisp> Cols, int gpPMOAdmin)
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("MainCol", "zXPortfolioItem");

            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("SuppressMessage", 3);


            xCfg.CreateIntAttr("Dragging", gpPMOAdmin);
            xCfg.CreateIntAttr("Sorting", 1);
            xCfg.CreateIntAttr("ColsMoving", 1);
            xCfg.CreateIntAttr("ColsPosLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateIntAttr("VisibleLap", 1);
            xCfg.CreateIntAttr("SectionWidthLap", 1);
            xCfg.CreateIntAttr("GroupLap", 1);
            xCfg.CreateIntAttr("WideHScroll", 0);
            xCfg.CreateIntAttr("LeftWidth", 150);
            xCfg.CreateIntAttr("Width", 400);
            xCfg.CreateIntAttr("RightWidth", 800);
            xCfg.CreateIntAttr("MinMidWidth", 50);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 0);
            xCfg.CreateIntAttr("RightCanResize", 1);
            xCfg.CreateIntAttr("FocusWholeRow", 1);



            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateBooleanAttr("DateStrings", true);
            //     xCfg.CreateIntAttr("MinRowHeight",26);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("MaxSort", 2);
            //     xCfg.CreateStringAttr("DefaultSort", "PortfolioItem");
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");
            xCfg.CreateIntAttr("FastColumns", 1);
            xCfg.CreateIntAttr("ExpandAllLevels", 3);
            xCfg.CreateIntAttr("GroupSortMain", 1);
            xCfg.CreateIntAttr("GroupRestoreSort", 1);


            xCfg.CreateIntAttr("NoTreeLines", 1);
            xCfg.CreateIntAttr("ShowVScroll", 1);

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");
            CStruct xRightCols = xGrid.CreateSubStruct("RightCols");
            m_xPeriodCols = xRightCols;
            m_xMiddleCols = xCols;

            m_xDef = xGrid.CreateSubStruct("Def");

            m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");
            m_xDefTree.CreateStringAttr("Calculated", "1");
            m_xDefTree.CreateStringAttr("Calculated", "1");

            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateIntAttr("NoColorState", 1);
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");





            m_xDefNode = m_xDef.CreateSubStruct("D");
            m_xDefNode.CreateStringAttr("Name", "Leaf");
            m_xDefNode.CreateStringAttr("Calculated", "0");

            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("HoverRow", "Color");
            m_xDefNode.CreateStringAttr("FocusCell", "");
            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefNode.CreateIntAttr("NoColorState", 1);


            CStruct xHead = xGrid.CreateSubStruct("Head");
            CStruct xFilter = xHead.CreateSubStruct("Filter");
            xFilter.CreateStringAttr("id", "Filter");

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


            CStruct xC = xLeftCols.CreateSubStruct("C");


            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "RowSel");
            xC.CreateStringAttr("Type", "Icon");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateStringAttr("Width", "20");
            xC.CreateStringAttr("Color", "rgb(223, 227, 232)");
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);
            m_xHeader1.CreateStringAttr("RowSel", " ");
            m_xHeader2.CreateStringAttr("RowSel", " ");



            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "rowid");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("Visible", 0);

            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);


            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Select");
            xC.CreateStringAttr("Type", "Bool");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateStringAttr("Width", "20");
            xC.CreateStringAttr("Class", "");
            m_xHeader1.CreateStringAttr("Select", " ");
            m_xHeader2.CreateStringAttr("Select", " ");

            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);

            //xC = xLeftCols.CreateSubStruct("C");
            //xC.CreateStringAttr("Name", "ChangedIcon");
            //xC.CreateStringAttr("Type", "Icon");
            //xC.CreateBooleanAttr("CanEdit", false);
            //xC.CreateIntAttr("CanMove", 0);
            //xC.CreateIntAttr("CanResize", 0);
            //xC.CreateIntAttr("ShowHint", 0);
            //xC.CreateIntAttr("CanSort", 0);
            //xC.CreateIntAttr("CanFilter", 0);
            //xC.CreateIntAttr("CanExport", 0); 
            //xC.CreateStringAttr("Width", "20");
            //m_xHeader1.CreateStringAttr("ChangedIcon", " ");

            //xC.CreateIntAttr("CanHide", 0);
            //xC.CreateIntAttr("CanSelect", 0);

            //xC = xLeftCols.CreateSubStruct("C");
            //xC.CreateStringAttr("Name", "RowDraggable");
            //xC.CreateStringAttr("Type", "Bool");
            //xC.CreateIntAttr("CanResize", 0); 
            //xC.CreateBooleanAttr("CanEdit", false);
            //xC.CreateIntAttr("CanMove", 0);
            //xC.CreateIntAttr("CanFilter", 0);
            //xC.CreateIntAttr("CanSort", 0);
            //xC.CreateIntAttr("ShowHint", 0);
            //xC.CreateIntAttr("Visible", 0);

            //xC.CreateIntAttr("CanHide", 0);
            //xC.CreateIntAttr("CanSelect", 0);

            //xC = xLeftCols.CreateSubStruct("C");
            //xC.CreateStringAttr("Name", "RowChanged");
            //xC.CreateStringAttr("Type", "Int");
            //xC.CreateBooleanAttr("CanEdit", false);
            //xC.CreateIntAttr("CanMove", 0);
            //xC.CreateIntAttr("CanResize", 0);
            //xC.CreateIntAttr("CanFilter", 0);
            //xC.CreateIntAttr("ShowHint", 0);
            //xC.CreateIntAttr("CanSort", 0);
            //xC.CreateIntAttr("CanExport", 0); 
            //xC.CreateIntAttr("Visible", 0);

            //xC.CreateIntAttr("CanHide", 0);
            //xC.CreateIntAttr("CanSelect", 0);




            m_xDefTree.CreateBooleanAttr("SelectCanEdit", true);
            m_xDefTree.CreateStringAttr("rowid", "");


            CStruct xSolid = xGrid.CreateSubStruct("Solid");
            CStruct xGroup = xSolid.CreateSubStruct("Group");

            foreach (clsColDisp col in Cols)
            {
                try
                {


                    string sn = col.m_realname.Replace("/n", "");
                    sn = sn.Replace(" ", "");
                    string snv = col.m_dispname.Replace("/n", "\n");

                    sn = "zX" + sn;

                    sn = sn.Replace(" ", "");
                    sn = sn.Replace("\r", "");
                    sn = sn.Replace("\n", "");

                    xC = xCols.CreateSubStruct("C");

                    xC.CreateStringAttr("Name", sn);
                    xC.CreateStringAttr("Class", "GMCellMain");
                    xC.CreateIntAttr("CanDrag", 0);
                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateIntAttr("CaseSensitive", 0);
                    xC.CreateStringAttr("OnDragCell", "Focus,DragCell");
                    m_xDefTree.CreateIntAttr(sn + "CanDrag", 0);


                    m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                    m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");

                    m_xDefNode.CreateIntAttr(sn + "CanDrag", 0);

                    m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
                    m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");



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


                    
                    if (col.m_unselectable == true)
                        xC.CreateIntAttr("CanHide", 0);

                   if (col.m_def_fld == false)
                        xC.CreateIntAttr("Visible", 0);

                    if (col.m_col_hidden == true)
                    {
                        xC.CreateIntAttr("Width", 0);
                    }
                    m_xHeader1.CreateStringAttr(sn, snv);
                    m_xHeader2.CreateStringAttr(sn, " ");


                    string sMaxFunc = "(Row.id == 'Filter' ? '' : max())";
                    string sMinFunc = "(Row.id == 'Filter' ? '' : min())";

                    xC = m_xMiddleCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "xinterenalPeriodMin");

                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Type", "Int");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateStringAttr("Align", "Right");
                    xC.CreateIntAttr("Visible", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateIntAttr("CanDrag", 0);

                    m_xDefTree.CreateStringAttr("xinterenalPeriodMin" + "Formula", sMinFunc);


                    m_xDefNode.CreateStringAttr("xinterenalPeriodMin" + "Formula", "");

                    m_xDefNode.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);
                    m_xDefTree.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);

                    xC = m_xMiddleCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "xinterenalPeriodMax");

                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Type", "Int");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateStringAttr("Align", "Right");
                    xC.CreateIntAttr("Visible", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateIntAttr("CanDrag", 0);

                    m_xDefTree.CreateStringAttr("xinterenalPeriodMax" + "Formula", sMaxFunc);


                    m_xDefNode.CreateStringAttr("xinterenalPeriodMax" + "Formula", "");

                    m_xDefNode.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                    m_xDefTree.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);

                    xC = m_xMiddleCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "xinterenalPeriodTotal");

                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Type", "Int");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateStringAttr("Align", "Right");
                    xC.CreateIntAttr("Visible", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateIntAttr("CanDrag", 0);

                    m_xDefNode.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                    m_xDefTree.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                }
                catch (Exception ex)
                {

                }

            }


            return true;
        }
        public void AddPeriodColumn(string sId, string sName, bool bUseFTE, List<CATGRow> disp, int gpPMOAdmin, bool bUseQTY, bool bUseCost)
        {


            CStruct xC = null;
            int cnt = 0;

            foreach (CATGRow ot in disp)
            {
                if (ot.bUse)
                    ++cnt;
            }

            if (cnt == 0)
                return;

            int spn = 0;

            if (bUseQTY)
                ++spn;

            if (bUseFTE)
                ++spn;

            if (bUseCost)
                ++spn;

            spn *= cnt;

            cnt = 0;

            string cpref = "";

            foreach (CATGRow ot in disp)
            {
                try
                {
                    if (ot.bUse)
                    {
                        ++cnt;


                        cpref = "C";

                        if (cnt == 1)
                        {
                            if (spn > 1)
                                m_xHeader1.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "Span", spn);

                            m_xHeader1.CreateStringAttr("P" + sId + cpref + cnt.ToString(), sName);
                        }
                        else
                            m_xHeader1.CreateStringAttr("P" + sId + cpref + cnt.ToString(), " ");




                        if (bUseQTY)
                        {
                            xC = m_xPeriodCols.CreateSubStruct("C");
                            xC.CreateStringAttr("Name", "P" + sId + cpref + cnt.ToString());
                            //                  xC.CreateStringAttr("Type", "Text");
                            xC.CreateStringAttr("Type", "Float");
                            m_xHeader2.CreateStringAttr("P" + sId + cpref + cnt.ToString(), "Qty");
                            xC.CreateStringAttr("Format", ",0.##");

                            xC.CreateIntAttr("ShowHint", 0);

                            xC.CreateIntAttr("CanSort", 0);
                            xC.CreateIntAttr("CanMove", 0);
                            xC.CreateIntAttr("CanDrag", gpPMOAdmin);
                            xC.CreateIntAttr("CanHide", 0);
                            xC.CreateIntAttr("CanSelect", 0);


                            if (gpPMOAdmin != 0)
                                xC.CreateStringAttr("OnDragCell", "Focus,DragCell");

                            xC.CreateStringAttr("Align", "Right");

                            string sFunc = "(Row.id == 'Filter' ? '' : sum())";
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", sFunc);
                            //"sum()");
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Format", ",0.##");

                            m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", "");

                            m_xDefNode.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);
                            m_xDefTree.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);

                            m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");

                            xC.CreateIntAttr("MinWidth", 45);
                            xC.CreateIntAttr("Width", 65);
                            ++cnt;
                        }
                        if (bUseFTE)
                        {
                            xC = m_xPeriodCols.CreateSubStruct("C");
                            xC.CreateStringAttr("Name", "P" + sId + cpref + cnt.ToString());
                            //                  xC.CreateStringAttr("Type", "Text");
                            xC.CreateStringAttr("Type", "Float");
                            m_xHeader2.CreateStringAttr("P" + sId + cpref + cnt.ToString(), "FTE");

                            xC.CreateStringAttr("Format", ",0.###");

                            xC.CreateIntAttr("ShowHint", 0);

                            xC.CreateIntAttr("CanSort", 0);
                            xC.CreateIntAttr("CanMove", 0);
                            xC.CreateIntAttr("CanDrag", gpPMOAdmin);
                            xC.CreateIntAttr("CanHide", 0);
                            xC.CreateIntAttr("CanSelect", 0);


                            if (gpPMOAdmin != 0)
                                xC.CreateStringAttr("OnDragCell", "Focus,DragCell");

                            xC.CreateStringAttr("Align", "Right");

                            string sFunc = "(Row.id == 'Filter' ? '' : sum())";
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", sFunc);
                            //"sum()");
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Format", ",0.##");

                            m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", "");

                            m_xDefNode.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);
                            m_xDefTree.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);

                            m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");

                            xC.CreateIntAttr("MinWidth", 45);
                            xC.CreateIntAttr("Width", 65);
                            ++cnt;
                        }

                        if (bUseCost)
                        {
                            xC = m_xPeriodCols.CreateSubStruct("C");
                            xC.CreateStringAttr("Name", "P" + sId + cpref + cnt.ToString());
                            //                  xC.CreateStringAttr("Type", "Text");
                            xC.CreateStringAttr("Type", "Float");
                            m_xHeader2.CreateStringAttr("P" + sId + cpref + cnt.ToString(), "Cost");


                            xC.CreateIntAttr("ShowHint", 0);

                            xC.CreateIntAttr("CanSort", 0);
                            xC.CreateIntAttr("CanMove", 0);
                            xC.CreateIntAttr("CanDrag", gpPMOAdmin);
                            xC.CreateIntAttr("CanHide", 0);
                            xC.CreateIntAttr("CanSelect", 0);


                            if (gpPMOAdmin != 0)
                                xC.CreateStringAttr("OnDragCell", "Focus,DragCell");

                            xC.CreateStringAttr("Align", "Right");

                            string sFunc = "(Row.id == 'Filter' ? '' : sum())";
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", sFunc);
                            //"sum()");

                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Format", ",0.###");

                            m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", "");

                            m_xDefNode.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);
                            m_xDefTree.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);

                            m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");

                            xC.CreateIntAttr("MinWidth", 45);
                            xC.CreateIntAttr("Width", 65);
                        }
                    }

                    //   m_xHeader2.CreateStringAttr("P" + sId + "C" + cnt.ToString(), ot.Name);
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

        public void AddDetailRow(clsDetailRowData oDet, int rID, bool ShowFTEs, List<clsColDisp> Cols, List<CATGRow> disp, bool bUseQTY, bool bUseCost, bool bshowcostdec)
        {
            CStruct xIParent = m_xLevels[0];
            CStruct xI = xIParent.CreateSubStruct("I");

            m_xLevels[1] = xI;
            xI.CreateStringAttr("id", rID.ToString());
            xI.CreateStringAttr("rowid", "r" + rID.ToString());
            xI.CreateStringAttr("Color", "white");
            xI.CreateStringAttr("Def", "Leaf");
            //       xI.CreateStringAttr("Calculated", "0");


            xI.CreateIntAttr("NoColorState", 1);
            xI.CreateBooleanAttr("CanEdit", false);

            xI.CreateStringAttr("Select", (oDet.bSelected ? "1" : "0"));

            xI.CreateBooleanAttr("SelectCanEdit", true);
            xI.CreateBooleanAttr("CanEdit", false);

            //xI.CreateStringAttr("RowDraggable", (oDet.bDraggable ? "1" : "0"));
            //xI.CreateIntAttr("RowChanged", oDet.iDragCnt);

            //xI.CreateStringAttr("ChangedIcon", (oDet.iDragCnt == 0 ? "/_layouts/ppm/images/Nogif.gif" : "/_layouts/ppm/images/Approve.gif"));



            foreach (clsColDisp sng in Cols)
            {
                string sn = sng.m_dispname.Replace(" ", "");




                sn = "zX" + sn;

                sn = sn.Replace(" ", "");
                sn = sn.Replace("\r", "");
                sn = sn.Replace("\n", "");

                if (sng.m_id == (int)FieldIDs.SD_FID)
                {

                    if (oDet.Det_Start != DateTime.MinValue)
                        xI.CreateStringAttr(sn, oDet.Det_Start.ToShortDateString());

                }
                else if (sng.m_id == (int)FieldIDs.FD_FID)
                {
                    if (oDet.Det_Finish != DateTime.MinValue)
                        xI.CreateStringAttr(sn, oDet.Det_Finish.ToShortDateString());
                }

                else if (sng.m_id == (int)FieldIDs.FTOT_FID)
                    xI.CreateStringAttr(sn, oDet.m_tot1.ToString());

                else if (sng.m_id == (int)FieldIDs.DTOT_FID)
                    xI.CreateStringAttr(sn, oDet.m_tot2.ToString());
                else if (sng.m_id == (int)FieldIDs.PI_FID)
                    xI.CreateStringAttr(sn, oDet.PI_Name);

                else if (sng.m_id == (int)FieldIDs.CT_FID)
                    xI.CreateStringAttr(sn, oDet.CT_Name);

                else if (sng.m_id == (int)FieldIDs.SCEN_FID)
                    xI.CreateStringAttr(sn, oDet.Scen_Name);

                else if (sng.m_id == (int)FieldIDs.BC_FID)
                    xI.CreateStringAttr(sn, oDet.Cat_Name);

                else if (sng.m_id == (int)FieldIDs.FULLC_FID)
                    xI.CreateStringAttr(sn, oDet.FullCatName);

                else if (sng.m_id == (int)FieldIDs.CAT_FID)
                    xI.CreateStringAttr(sn, oDet.CC_Name);

                else if (sng.m_id == (int)FieldIDs.FULLCAT_FID)
                    xI.CreateStringAttr(sn, oDet.FullCCName);

                else if (sng.m_id == (int)FieldIDs.BC_ROLE)
                    xI.CreateStringAttr(sn, oDet.Role_Name);

                else if (sng.m_id == (int)FieldIDs.MC_FID)
                    xI.CreateStringAttr(sn, oDet.MC_Name);

                else if (sng.m_id >= 11801 && sng.m_id <= 11805)
                    xI.CreateStringAttr(sn, oDet.Text_OCVal[sng.m_id - 11800]);

                else if (sng.m_id >= 11811 && sng.m_id <= 11815)
                    xI.CreateStringAttr(sn, oDet.TXVal[sng.m_id - 11810]);
                else if (sng.m_id >= (int)FieldIDs.PI_USE_EXTRA + 1 && sng.m_id <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                {

                    if (oDet.m_PI_Format_Extra_data != null)
                        xI.CreateStringAttr(sn, oDet.m_PI_Format_Extra_data[sng.m_id - (int)FieldIDs.PI_USE_EXTRA]);
                }
                else
                    xI.CreateStringAttr(sn, " ");

            }

            int maxp = oDet.zFTE.Length - 1;



            xI.CreateIntAttr("NoColorState", 1);



            int fp = 0;
            int lp = 0;

            double qval;
            double cval;
            double fval;

            for (int i = 1; i <= maxp; i++)
            {
                foreach (CATGRow ot in disp)
                {
                    if (ot.bUse)
                    {

                        cval = 0;
                        qval = 0;
                        fval = 0;

                        if (bUseQTY)
                        {
                            if (oDet.zValue[i] != double.MinValue)
                                qval = oDet.zValue[i];
                        }

                        if (ShowFTEs)
                        {
                            if (oDet.zFTE[i] != double.MinValue)
                                fval = oDet.zFTE[i];
                        }


                        if (bUseCost)
                        {
                            cval = oDet.zCost[i];

                        }

                        if (cval != 0 || qval != 0 || fval != 0)
                        {
                            fp = i;
                            break;
                        }
                    }
                }

                if (fp != 0)
                    break;
            }

            if (fp != 0)
            {
                for (int xi = maxp; xi > 1; xi--)
                {
                    foreach (CATGRow ot in disp)
                    {
                        if (ot.bUse)
                        {

                            cval = 0;
                            qval = 0;
                            fval = 0;

                            if (bUseQTY)
                            {
                                if (oDet.zValue[xi] != double.MinValue)
                                    qval = oDet.zValue[xi];
                            }

                            if (ShowFTEs)
                            {
                                if (oDet.zFTE[xi] != double.MinValue)
                                    fval = oDet.zFTE[xi];
                            }
                            if (bUseCost)
                            {
                                cval = oDet.zCost[xi];

                            }

                            if (cval != 0 || qval != 0 || fval != 0)
                            {
                                lp = xi;
                                break;
                            }
                        }

                    }

                    if (lp != 0)
                        break;
                }

            }

            if (fp == 0)
                fp = maxp + 1;


            xI.CreateIntAttr("xinterenalPeriodMin", fp);
            xI.CreateIntAttr("xinterenalPeriodMax", lp);
            xI.CreateIntAttr("xinterenalPeriodTotal", maxp);


            int cnt = 0;
            string cpref = "";
            for (int i = 1; i <= maxp; i++)
            {
                cnt = 0;
                foreach (CATGRow ot in disp)
                {
                    if (ot.bUse)
                    {
                        ++cnt;

                        cpref = "C";

                        if (bUseQTY)
                        {
                            if (oDet.zValue[i] != double.MinValue)
                                xI.CreateDoubleAttr("P" + i.ToString() + cpref + cnt.ToString(), oDet.zValue[i]);

                            ++cnt;
                        }


                        if (ShowFTEs)
                        {
                            if (oDet.zFTE[i] != double.MinValue)
                                xI.CreateDoubleAttr("P" + i.ToString() + cpref + cnt.ToString(), oDet.zFTE[i]);

                            ++cnt;
                        }
                        if (bUseCost)
                        {
                            double dcost = oDet.zCost[i];

                            if (bshowcostdec == false)
                                dcost = Math.Floor(dcost);

                            if (oDet.zCost[i] != double.MinValue)
                                xI.CreateDoubleAttr("P" + i.ToString() + cpref + cnt.ToString(), dcost);
                        }
                    }
                }
            }
        }

    }

    internal class CABottomGrid
    {
        private CStruct xGrid;
        private CStruct m_xPeriodCols;
        private CStruct m_xMiddleCols;
        private CStruct m_xHeader1;
        private CStruct m_xHeader2;
        private CStruct m_xDef;
        private CStruct m_xDefTree;
        private CStruct m_xDefNode;

        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;


        public bool InitializeGridLayout(List<clsColDisp> Cols, int gpPMOAdmin)
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("MainCol", "zXPortfolioItem");

            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("SuppressMessage", 3);


            xCfg.CreateIntAttr("Dragging", gpPMOAdmin);
            xCfg.CreateIntAttr("Sorting", 1);
            xCfg.CreateIntAttr("ColsMoving", 1);
            xCfg.CreateIntAttr("ColsPosLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateIntAttr("VisibleLap", 1);
            xCfg.CreateIntAttr("SectionWidthLap", 1);
            xCfg.CreateIntAttr("GroupLap", 1);
            xCfg.CreateIntAttr("WideHScroll", 0);
            xCfg.CreateIntAttr("LeftWidth", 150);
            xCfg.CreateIntAttr("Width", 400);
            xCfg.CreateIntAttr("RightWidth", 800);
            xCfg.CreateIntAttr("MinMidWidth", 50);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 0);
            xCfg.CreateIntAttr("RightCanResize", 1);
            xCfg.CreateIntAttr("FocusWholeRow", 1);



            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateBooleanAttr("DateStrings", true);
            //     xCfg.CreateIntAttr("MinRowHeight",26);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("MaxSort", 2);
            //     xCfg.CreateStringAttr("DefaultSort", "PortfolioItem");
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");
            xCfg.CreateIntAttr("FastColumns", 1);
            xCfg.CreateIntAttr("ExpandAllLevels", 3);
            xCfg.CreateIntAttr("GroupSortMain", 1);
            xCfg.CreateIntAttr("GroupRestoreSort", 1);


            xCfg.CreateIntAttr("NoTreeLines", 1);
            xCfg.CreateIntAttr("ShowVScroll", 1);

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");
            CStruct xRightCols = xGrid.CreateSubStruct("RightCols");
            m_xPeriodCols = xRightCols;
            m_xMiddleCols = xCols;

            m_xDef = xGrid.CreateSubStruct("Def");

            m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");
            m_xDefTree.CreateStringAttr("Calculated", "1");
            m_xDefTree.CreateStringAttr("Calculated", "1");

            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateIntAttr("NoColorState", 1);
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");





            m_xDefNode = m_xDef.CreateSubStruct("D");
            m_xDefNode.CreateStringAttr("Name", "Leaf");
            m_xDefNode.CreateStringAttr("Calculated", "0");

            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("HoverRow", "Color");
            m_xDefNode.CreateStringAttr("FocusCell", "");
            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefNode.CreateIntAttr("NoColorState", 1);


            CStruct xHead = xGrid.CreateSubStruct("Head");
            CStruct xFilter = xHead.CreateSubStruct("Filter");
            xFilter.CreateStringAttr("id", "Filter");

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


            CStruct xC = xLeftCols.CreateSubStruct("C");


            xC.CreateStringAttr("Name", "rowid");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("Visible", 0);

            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);






            m_xDefTree.CreateBooleanAttr("SelectCanEdit", true);
            m_xDefTree.CreateStringAttr("rowid", "");


            CStruct xSolid = xGrid.CreateSubStruct("Solid");
            CStruct xGroup = xSolid.CreateSubStruct("Group");

            foreach (clsColDisp col in Cols)
            {
                try
                {


                    string sn = col.m_realname.Replace("/n", "");
                    sn = sn.Replace(" ", "");
                    string snv = col.m_dispname.Replace("/n", "\n");

                    sn = "zX" + sn;

                    sn = sn.Replace(" ", "");
                    sn = sn.Replace("\r", "");
                    sn = sn.Replace("\n", "");

                    xC = xCols.CreateSubStruct("C");

                    xC.CreateStringAttr("Name", sn);
                    xC.CreateStringAttr("Class", "GMCellMain");
                    xC.CreateIntAttr("CanDrag", 0);
                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateIntAttr("CaseSensitive", 0);
                    xC.CreateStringAttr("OnDragCell", "Focus,DragCell");
                    m_xDefTree.CreateIntAttr(sn + "CanDrag", 0);

                    if (col.m_def_fld == false)
                        xC.CreateIntAttr("Visible", 0);



                    m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                    m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");

                    m_xDefNode.CreateIntAttr(sn + "CanDrag", 0);

                    m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
                    m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");



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

                    if (col.m_col_hidden == true)
                    {
                        xC.CreateIntAttr("Width", 0);
                    }
                    m_xHeader1.CreateStringAttr(sn, snv);
                    m_xHeader2.CreateStringAttr(sn, " ");


                    string sMaxFunc = "(Row.id == 'Filter' ? '' : max())";
                    string sMinFunc = "(Row.id == 'Filter' ? '' : min())";

                    xC = m_xMiddleCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "xinterenalPeriodMin");

                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Type", "Int");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateStringAttr("Align", "Right");
                    xC.CreateIntAttr("Visible", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateIntAttr("CanDrag", 0);

                    m_xDefTree.CreateStringAttr("xinterenalPeriodMin" + "Formula", sMinFunc);


                    m_xDefNode.CreateStringAttr("xinterenalPeriodMin" + "Formula", "");

                    m_xDefNode.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);
                    m_xDefTree.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);

                    xC = m_xMiddleCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "xinterenalPeriodMax");

                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Type", "Int");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateStringAttr("Align", "Right");
                    xC.CreateIntAttr("Visible", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateIntAttr("CanDrag", 0);

                    m_xDefTree.CreateStringAttr("xinterenalPeriodMax" + "Formula", sMaxFunc);


                    m_xDefNode.CreateStringAttr("xinterenalPeriodMax" + "Formula", "");

                    m_xDefNode.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                    m_xDefTree.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);

                    xC = m_xMiddleCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "xinterenalPeriodTotal");

                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Type", "Int");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateStringAttr("Align", "Right");
                    xC.CreateIntAttr("Visible", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateIntAttr("CanDrag", 0);

                    m_xDefNode.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                    m_xDefTree.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                }
                catch (Exception ex)
                {

                }

            }


            return true;
        }
        public void AddPeriodColumn(string sId, string sName, bool bUseFTE, List<CATGRow> disp, int gpPMOAdmin, bool bUseQTY, bool bUseCost)
        {


            CStruct xC = null;
            int cnt = 0;

            foreach (CATGRow ot in disp)
            {
                if (ot.bUse)
                    ++cnt;
            }

            if (cnt == 0)
                return;

            int spn = 0;

            //if (bUseQTY)
            //    ++spn;

            //if (bUseFTE)
            //    ++spn;

            if (bUseCost)
                ++spn;

            spn *= cnt;

            cnt = 0;

            string cpref = "";

            foreach (CATGRow ot in disp)
            {
                try
                {
                    if (ot.bUse)
                    {
                        ++cnt;


                        cpref = "C";

                        if (cnt == 1)
                        {
                            if (spn > 1)
                                m_xHeader1.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "Span", spn);

                            m_xHeader1.CreateStringAttr("P" + sId + cpref + cnt.ToString(), sName);
                        }
                        else
                            m_xHeader1.CreateStringAttr("P" + sId + cpref + cnt.ToString(), " ");




                        //if (bUseQTY)
                        //{
                        //    xC = m_xPeriodCols.CreateSubStruct("C");
                        //    xC.CreateStringAttr("Name", "P" + sId + cpref + cnt.ToString());
                        //    //                  xC.CreateStringAttr("Type", "Text");
                        //    xC.CreateStringAttr("Type", "Float");
                        //    m_xHeader2.CreateStringAttr("P" + sId + cpref + cnt.ToString(), "Qty");
                        //    xC.CreateStringAttr("Format", ",0.##");

                        //    xC.CreateIntAttr("ShowHint", 0);

                        //    xC.CreateIntAttr("CanSort", 0);
                        //    xC.CreateIntAttr("CanMove", 0);
                        //    xC.CreateIntAttr("CanDrag", gpPMOAdmin);
                        //    xC.CreateIntAttr("CanHide", 0);
                        //    xC.CreateIntAttr("CanSelect", 0);


                        //    if (gpPMOAdmin != 0)
                        //        xC.CreateStringAttr("OnDragCell", "Focus,DragCell");

                        //    xC.CreateStringAttr("Align", "Right");

                        //    string sFunc = "(Row.id == 'Filter' ? '' : sum())";
                        //    m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", sFunc);
                        //    //"sum()");
                        //    m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Format", ",0.##");

                        //    m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", "");

                        //    m_xDefNode.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);
                        //    m_xDefTree.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);

                        //    m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");
                        //    m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");

                        //    xC.CreateIntAttr("MinWidth", 45);
                        //    xC.CreateIntAttr("Width", 65);
                        //    ++cnt;
                        //}
                        //if (bUseFTE)
                        //{
                        //    xC = m_xPeriodCols.CreateSubStruct("C");
                        //    xC.CreateStringAttr("Name", "P" + sId + cpref + cnt.ToString());
                        //    //                  xC.CreateStringAttr("Type", "Text");
                        //    xC.CreateStringAttr("Type", "Float");
                        //    m_xHeader2.CreateStringAttr("P" + sId + cpref + cnt.ToString(), "FTE");

                        //    xC.CreateStringAttr("Format", ",0.###");

                        //    xC.CreateIntAttr("ShowHint", 0);

                        //    xC.CreateIntAttr("CanSort", 0);
                        //    xC.CreateIntAttr("CanMove", 0);
                        //    xC.CreateIntAttr("CanDrag", gpPMOAdmin);
                        //    xC.CreateIntAttr("CanHide", 0);
                        //    xC.CreateIntAttr("CanSelect", 0);


                        //    if (gpPMOAdmin != 0)
                        //        xC.CreateStringAttr("OnDragCell", "Focus,DragCell");

                        //    xC.CreateStringAttr("Align", "Right");

                        //    string sFunc = "(Row.id == 'Filter' ? '' : sum())";
                        //    m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", sFunc);
                        //    //"sum()");
                        //    m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Format", ",0.##");

                        //    m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", "");

                        //    m_xDefNode.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);
                        //    m_xDefTree.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);

                        //    m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");
                        //    m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");

                        //    xC.CreateIntAttr("MinWidth", 45);
                        //    xC.CreateIntAttr("Width", 65);
                        //    ++cnt;
                        //}

                        //if (bUseCost)
                        //{
                            xC = m_xPeriodCols.CreateSubStruct("C");
                            xC.CreateStringAttr("Name", "P" + sId + cpref + cnt.ToString());
                            //                  xC.CreateStringAttr("Type", "Text");
                            xC.CreateStringAttr("Type", "Float");
                            m_xHeader2.CreateStringAttr("P" + sId + cpref + cnt.ToString(), ot.Name);


                            xC.CreateIntAttr("ShowHint", 0);

                            xC.CreateIntAttr("CanSort", 0);
                            xC.CreateIntAttr("CanMove", 0);
                            xC.CreateIntAttr("CanDrag", gpPMOAdmin);
                            xC.CreateIntAttr("CanHide", 0);
                            xC.CreateIntAttr("CanSelect", 0);


                            if (gpPMOAdmin != 0)
                                xC.CreateStringAttr("OnDragCell", "Focus,DragCell");

                            xC.CreateStringAttr("Align", "Right");

                            string sFunc = "(Row.id == 'Filter' ? '' : sum())";
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", sFunc);
                            //"sum()");

                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Format", ",0.###");

                            m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "Formula", "");

                            m_xDefNode.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);
                            m_xDefTree.CreateIntAttr("P" + sId + cpref + cnt.ToString() + "CanDrag", gpPMOAdmin);

                            m_xDefNode.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");
                            m_xDefTree.CreateStringAttr("P" + sId + cpref + cnt.ToString() + "ClassInner", "");

                            xC.CreateIntAttr("MinWidth", 45);
                            xC.CreateIntAttr("Width", 65);
//                        }
                    }

                    //   m_xHeader2.CreateStringAttr("P" + sId + "C" + cnt.ToString(), ot.Name);
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

        public void AddDetailRow(clsDetailRowData oDet, clsDetailRowData otDet, List<clsTargetColours> TargetColours, int rID, bool ShowFTEs, List<clsColDisp> Cols, List<CATGRow> disp, bool bUseQTY, bool bUseCost, bool bshowcostdec, bool bshowRemaining, CATotRow oTotalRow, bool bDoHeatMap, int heatmapind, int heatmapcolur)
        {
            CStruct xIParent = m_xLevels[0];
            CStruct xI = xIParent.CreateSubStruct("I");

            m_xLevels[1] = xI;
            xI.CreateStringAttr("id", rID.ToString());
            xI.CreateStringAttr("Color", "white");
            xI.CreateStringAttr("Def", "Leaf");
            //       xI.CreateStringAttr("Calculated", "0");


            xI.CreateIntAttr("NoColorState", 1);
            xI.CreateBooleanAttr("CanEdit", false);





            foreach (clsColDisp sng in Cols)
            {
                string sn = sng.m_dispname.Replace(" ", "");

                sn = "zX" + sn;

                sn = sn.Replace(" ", "");
                sn = sn.Replace("\r", "");
                sn = sn.Replace("\n", "");

                if (sng.m_id == (int)FieldIDs.SD_FID)
                {

                    if (oDet.Det_Start != DateTime.MinValue)
                        xI.CreateStringAttr(sn, oDet.Det_Start.ToShortDateString());

                }
                else if (sng.m_id == (int)FieldIDs.FD_FID)
                {
                    if (oDet.Det_Finish != DateTime.MinValue)
                        xI.CreateStringAttr(sn, oDet.Det_Finish.ToShortDateString());
                }

                else if (sng.m_id == (int)FieldIDs.FTOT_FID)
                    xI.CreateStringAttr(sn, oDet.m_tot1.ToString());

                else if (sng.m_id == (int)FieldIDs.DTOT_FID)
                    xI.CreateStringAttr(sn, oDet.m_tot2.ToString());
                else if (sng.m_id == (int)FieldIDs.PI_FID)
                    xI.CreateStringAttr(sn, oDet.PI_Name);

                else if (sng.m_id == (int)FieldIDs.CT_FID)
                    xI.CreateStringAttr(sn, oDet.CT_Name);

                else if (sng.m_id == (int)FieldIDs.SCEN_FID)
                    xI.CreateStringAttr(sn, oDet.Scen_Name);

                else if (sng.m_id == (int)FieldIDs.BC_FID)
                    xI.CreateStringAttr(sn, oDet.Cat_Name);

                else if (sng.m_id == (int)FieldIDs.FULLC_FID)
                    xI.CreateStringAttr(sn, oDet.FullCatName);

                else if (sng.m_id == (int)FieldIDs.CAT_FID)
                    xI.CreateStringAttr(sn, oDet.CC_Name);

                else if (sng.m_id == (int)FieldIDs.FULLCAT_FID)
                    xI.CreateStringAttr(sn, oDet.FullCCName);

                else if (sng.m_id == (int)FieldIDs.BC_ROLE)
                    xI.CreateStringAttr(sn, oDet.Role_Name);

                else if (sng.m_id == (int)FieldIDs.MC_FID)
                    xI.CreateStringAttr(sn, oDet.MC_Name);

                else if (sng.m_id >= 11801 && sng.m_id <= 11805)
                    xI.CreateStringAttr(sn, oDet.Text_OCVal[sng.m_id - 11800]);

                else if (sng.m_id >= 11811 && sng.m_id <= 11815)
                    xI.CreateStringAttr(sn, oDet.TXVal[sng.m_id - 11810]);
                else if (sng.m_id >= (int)FieldIDs.PI_USE_EXTRA + 1 && sng.m_id <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                {

                    if (oDet.m_PI_Format_Extra_data != null)
                        xI.CreateStringAttr(sn, oDet.m_PI_Format_Extra_data[sng.m_id - (int)FieldIDs.PI_USE_EXTRA]);
                }
                else
                    xI.CreateStringAttr(sn, " ");

            }

            int maxp = oDet.zFTE.Length - 1;



            xI.CreateIntAttr("NoColorState", 1);



            int fp = 0;
            int lp = 0;

            double qval;
            double cval;
            double fval;

            for (int i = 1; i <= maxp; i++)
            {
                foreach (CATGRow ot in disp)
                {
                    if (ot.bUse)
                    {

                        cval = 0;
                        qval = 0;
                        fval = 0;

                        //if (bUseQTY)
                        //{
                        //    if (oDet.zValue[i] != double.MinValue)
                        //        qval = oDet.zValue[i];
                        //}

                        //if (ShowFTEs)
                        //{
                        //    if (oDet.zFTE[i] != double.MinValue)
                        //        fval = oDet.zFTE[i];
                        //}


                        //if (bUseCost)
                        {
                            cval = oDet.zCost[i];

                        }

                        if (cval != 0 || qval != 0 || fval != 0)
                        {
                            fp = i;
                            break;
                        }
                    }
                }

                if (fp != 0)
                    break;
            }

            if (fp != 0)
            {
                for (int xi = maxp; xi > 1; xi--)
                {
                    foreach (CATGRow ot in disp)
                    {
                        if (ot.bUse)
                        {

                            cval = 0;
                            qval = 0;
                            fval = 0;

                            //if (bUseQTY)
                            //{
                            //    if (oDet.zValue[xi] != double.MinValue)
                            //        qval = oDet.zValue[xi];
                            //}

                            //if (ShowFTEs)
                            //{
                            //    if (oDet.zFTE[xi] != double.MinValue)
                            //        fval = oDet.zFTE[xi];
                            //}
//                            if (bUseCost)
//                            {
                                cval = oDet.zCost[xi];

//                            }

                            if (cval != 0 || qval != 0 || fval != 0)
                            {
                                lp = xi;
                                break;
                            }
                        }

                    }

                    if (lp != 0)
                        break;
                }

            }

            if (fp == 0)
                fp = maxp + 1;

            xI.CreateIntAttr("xinterenalPeriodMin", fp);
            xI.CreateIntAttr("xinterenalPeriodMax", lp);
            xI.CreateIntAttr("xinterenalPeriodTotal", maxp);


            int cnt = 0;
            string cpref = "";

            double p1 = 0;
            double t1 = 0;
            string rgb = "";

            clsDetailRowData xDet;

            for (int i = 1; i <= maxp; i++)
            {
                cnt = 0;
                foreach (CATGRow ot in disp)
                {
                    if (ot.bUse)
                    {
                        ++cnt;

                        if (ot.index < 0)
                            xDet = oTotalRow.m_targets[-ot.index];
                        else
                            xDet = oTotalRow.m_totals[ot.index];

                        cpref = "C";

                        //if (bUseQTY)
                        //{

                        //    p1 = oDet.zValue[i];
                        //    t1 = otDet.zValue[i];

                        //    if (t1 == 0 && p1 == 0)
                        //        rgb = TargetBackground(t1, 1, TargetColours);
                        //    else
                        //        rgb = TargetBackground(t1, p1, TargetColours);

                        //    if (bshowRemaining)
                        //        p1 = t1 - p1;

                        //    if (p1 != double.MinValue)
                        //        xI.CreateDoubleAttr("P" + i.ToString() + cpref + cnt.ToString(), p1);

                        //    if (rgb != "")
                        //        xI.CreateStringAttr("P" + i.ToString() + cpref + cnt.ToString() + "Color", rgb);

                        //    ++cnt;
                        //}


                        //if (ShowFTEs)
                        //{
                        //    p1 = oDet.zFTE[i];
                        //    t1 = otDet.zFTE[i];



                        //    if (t1 == 0 && p1 == 0)
                        //        rgb = TargetBackground(t1, 1, TargetColours);
                        //    else
                        //        rgb = TargetBackground(t1, p1, TargetColours);

                        //    if (bshowRemaining)
                        //        p1 = t1 - p1;

                        //    if (oDet.zFTE[i] != double.MinValue)
                        //        xI.CreateDoubleAttr("P" + i.ToString() + cpref + cnt.ToString(), p1);

                        //    if (rgb != "")
                        //        xI.CreateStringAttr("P" + i.ToString() + cpref + cnt.ToString() + "Color", rgb);

                        //    ++cnt;
                        //}
                        //if (bUseCost)
                        //{

                            double dcost = xDet.zCost[i];
                            int tlev = 0;

                            if (ot.fid == 0 && bDoHeatMap == true)
                            {
                                p1 = xDet.zCost[i];

                                if (heatmapind < 0)
                                    t1 = oTotalRow.m_targets[-heatmapind].zCost[i];
                                else
                                    t1 = oTotalRow.m_totals[heatmapind].zCost[i];


                                if (bshowRemaining)
                                    dcost = t1 - p1;
                            }

                            if (bshowcostdec == false)
                                dcost = Math.Floor(dcost);

                            if (xDet.zCost[i] != double.MinValue)
                                xI.CreateDoubleAttr("P" + i.ToString() + cpref + cnt.ToString(), dcost);

                            if (ot.fid == 0 && bDoHeatMap == true)
                            {

                                if (t1 == 0 && p1 == 0)
                                    rgb = TargetBackground(t1, 1, TargetColours, out tlev, heatmapcolur);
                                else
                                    rgb = TargetBackground(t1, p1, TargetColours, out tlev, heatmapcolur);


                                if (rgb != "")
                                    xI.CreateStringAttr("P" + i.ToString() + cpref + cnt.ToString() + "Color", rgb);
                            }

                        // }
                    }
                }
            }
        }

        private string TargetBackground(double Tdbl, double Pdbl, List<clsTargetColours> TargetColours, out int targetlevel, int heatmapColour)
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
                foreach (clsTargetColours oT in TargetColours)
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
                foreach (clsTargetColours oT in TargetColours)
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
                foreach (clsTargetColours oT in TargetColours)
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

                foreach (clsTargetColours oT in TargetColours)
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
    internal class CALegendGrid
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
            xCfg.CreateIntAttr("SuppressMessage", 3);

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
            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");

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

    internal class TargetGrid
    {
        private CStruct xGrid;

        private CStruct m_xHeader1;
        private CStruct m_xHeader2;
        private CStruct m_xPeriodCols;
        private CStruct m_xIParentRoot;
        private CStruct m_xDef;
        private CStruct m_xDefTree;
        private CStruct m_xDefNode;

        private void DoDefNodeBit(string sn)
        {

            m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");

 
            m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
            m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");
            m_xDefNode.CreateBooleanAttr(sn + "CanEdit", false);
        }

        public bool InitializeGridLayout(bool ShowFTEs, Dictionary<int, clsCustomFieldData> CustFields, int ratecount, string costtypejsonMenu, string costcatjsonMenu, int MC_Count)
        {

            CStruct xC = null;

            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            xCfg.CreateStringAttr("MainCol", "CostCategory");
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("ColResizing", 1);
            xCfg.CreateIntAttr("ExpandAllLevels", 3);


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





            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");

            xCfg.CreateIntAttr("LeftWidth", 400);

            xCfg.CreateIntAttr("GroupSortMain", 1);
            xCfg.CreateIntAttr("GroupRestoreSort", 1);

            xCfg.CreateIntAttr("SuppressCfg", 1);
            xCfg.CreateIntAttr("PrintCols", 0);

            xCfg.CreateIntAttr("Sorting", 0);



            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            m_xPeriodCols = xGrid.CreateSubStruct("Cols");
            //           m_xPeriodCols = xGrid.CreateSubStruct("RightCols");

            m_xDef = xGrid.CreateSubStruct("Def");

            m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");
            m_xDefTree.CreateStringAttr("Calculated", "1");
            m_xDefTree.CreateStringAttr("Calculated", "1");
              

            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateIntAttr("NoColorState", 1);
//            m_xDefTree.CreateIntAttr("CanExpand", 0);
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");





            m_xDefNode = m_xDef.CreateSubStruct("D");
            m_xDefNode.CreateStringAttr("Name", "Leaf");
            m_xDefNode.CreateStringAttr("Calculated", "0");

            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("HoverRow", "Color");
            m_xDefNode.CreateStringAttr("FocusCell", "");
            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefNode.CreateIntAttr("NoColorState", 1);



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

            m_xDefTree.CreateBooleanAttr("SelectCanEdit", false);
 //           m_xDefTree.CreateStringAttr("SelectType", "Text");
            m_xDefNode.CreateBooleanAttr("SelectCanEdit", true);


            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "rowid");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateBooleanAttr("Visible", false);
            m_xHeader1.CreateStringAttr("rowid", " ");
            m_xHeader2.CreateStringAttr("rowid", " ");

            // Add category column

             m_xDefTree.CreateStringAttr("rowid", "");


            CStruct xSolid = xGrid.CreateSubStruct("Solid");
            CStruct xGroup = xSolid.CreateSubStruct("Group");

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateStringAttr("Name", "CostType");
            xC.CreateBooleanAttr("Visible", false); 
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateStringAttr("Defaults", costtypejsonMenu);
            m_xHeader1.CreateStringAttr("CostType", "Cost");
            m_xHeader2.CreateStringAttr("CostType", "Type");

            DoDefNodeBit("CostType");


            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "CostCategory");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateStringAttr("Defaults", costcatjsonMenu);
            m_xHeader1.CreateStringAttr("CostCategory", "Cost");
            m_xHeader2.CreateStringAttr("CostCategory", "Category");
            DoDefNodeBit("CostCategory");

            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "MajorCategory");
            xC.CreateBooleanAttr("CanEdit", false);

            if (MC_Count <= 1)
                xC.CreateIntAttr("Visible", 0);

            m_xHeader1.CreateStringAttr("MajorCategory", "Major");
            m_xHeader2.CreateStringAttr("MajorCategory", "Category");
            DoDefNodeBit("MajorCategory");
            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "Role");
            xC.CreateBooleanAttr("CanEdit", false);
            DoDefNodeBit("Role");
            m_xHeader1.CreateStringAttr("Role", " ");
            m_xHeader2.CreateStringAttr("Role", "Role");

            if (ratecount != 0)
            {

                xC = xLeftCols.CreateSubStruct("C");

                xC.CreateStringAttr("Name", "NamedRate");
                xC.CreateBooleanAttr("CanEdit", false);
                DoDefNodeBit("NamedRate");
                m_xHeader1.CreateStringAttr("NamedRate", "Named ");
                m_xHeader2.CreateStringAttr("NamedRate", "Rate");
            }


            foreach (clsCustomFieldData oc in CustFields.Values)
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
                DoDefNodeBit("z" + oc.Name);
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

            string sFunc = "(Row.id == 'Filter' ? '' : sum())";


            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P" + sId + "V");
            xC.CreateStringAttr("Type", "Float");
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Format", "0.###");

            m_xDefTree.CreateStringAttr("P" + sId + "V" + "Formula", sFunc);
            m_xDefTree.CreateStringAttr("P" + sId + "V" + "Format", "0.###");
            m_xDefTree.CreateBooleanAttr("P" + sId + "V" + "CanEdit", false);
            m_xDefNode.CreateStringAttr("P" + sId + "V" + "Formula", "");

            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P" + sId + "C");
            xC.CreateStringAttr("Type", "Float");
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Format", "#.##");


             m_xDefTree.CreateStringAttr("P" + sId + "C" + "Formula", sFunc);
             m_xDefTree.CreateStringAttr("P" + sId + "C" + "Format", "#.##");
             m_xDefTree.CreateBooleanAttr("P" + sId + "C" + "CanEdit", false);
             m_xDefNode.CreateStringAttr("P" + sId + "C" + "Formula", "");

        }
        public void FinalizeGridLayout()
        {
            //m_xTabber.CreateStringAttr("Cells", m_sTabCells);


        }

        public bool InitializeGridData()
        {
            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_xIParentRoot = xI;
            return true;
        }
        public void AddDetailRow(clsDetailRowData oDet, int rID, bool ShowFTEs, int maxp, Dictionary<int, clsCustomFieldData> CustFields, int ratecount)
        {
            CStruct xIParent = m_xIParentRoot;
            CStruct xI = xIParent.CreateSubStruct("I");

            xI.CreateStringAttr("id", rID.ToString());
            xI.CreateStringAttr("rowid", rID.ToString());
            xI.CreateStringAttr("Def", "Leaf");


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


            foreach (clsCustomFieldData oc in CustFields.Values)
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
  
}