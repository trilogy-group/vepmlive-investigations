using System;
using System.Collections.Generic;
using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class TopGridCostsData
    {
        private CStruct xGrid;
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

        public bool InitializeGridData()
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            //xCfg.CreateStringAttr("id", "EditCostsGrid");
            //xCfg.CreateStringAttr("id", "g_" + CostTypeId.ToString());
            xCfg.CreateIntAttr("FilterEmpty", 1);

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

                //        xI.CreateStringAttr("Color", "0xDADCDD");             //     "204,236,255");

                //if (ShowGantt)
                //    bCellhtml = true;
                //else
                //{

                //    xI.CreateStringAttr("HtmlPrefix", "<B>");
                //    xI.CreateStringAttr("HtmlPostfix", "</B>");
                //}

            }
            else
            {
                xI.CreateStringAttr("Color", "255,255,255");

            }

            //    xI.CreateStringAttr("Color", "255,255,255");

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


                //if (bCellhtml)
                //{

                //    xI.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                //    xI.CreateStringAttr(sn + "HtmlPostfix", "</B>");
                //}

                //   if (oDet.bRealone == false)
                //        xI.CreateStringAttr(sn + "Color", "0xDADCDD");  


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
        public string GetString()
        {
            return xGrid.XML();
        }
    }
}
