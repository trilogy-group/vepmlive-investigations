using System;
using System.Collections.Generic;
using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class BottomGridCostsData
    {
        private CStruct xGrid;
        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;
        public bool InitializeGridData(bool UsingGrouping)
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            //xCfg.CreateStringAttr("id", "EditCostsGrid");
            //xCfg.CreateStringAttr("id", "g_" + CostTypeId.ToString());

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

        public string GetString()
        {
            return xGrid.XML();
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
