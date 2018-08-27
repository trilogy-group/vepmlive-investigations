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