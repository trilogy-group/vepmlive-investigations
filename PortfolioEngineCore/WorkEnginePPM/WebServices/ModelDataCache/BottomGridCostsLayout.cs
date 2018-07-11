using System.Collections.Generic;
using PortfolioEngineCore;

namespace ModelDataCache
{
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
}
