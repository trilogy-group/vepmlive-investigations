using System;
using System.Collections.Generic;
using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class BottomGrid
    {
        private CStruct xGrid;
        private CStruct m_xPeriodCols;
        private CStruct m_xHeader1;
        private CStruct m_xHeader2;
        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;

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

        }
        public string GetString()
        {
            return xGrid.XML();
        }

        public bool InitializeGridData(bool UsingGrouping)
        {
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
}
