using System;
using System.Collections.Generic;

namespace ModelDataCache
{
    public abstract class TopGridBase : GridBase
    {
        protected string RemoveNastyCharacters(string sn)
        {
            var result = string.Empty;
            string sNastyChars = "!@#$%^&*()_+-={}[]|:;'?/~`";

            sn = sn.Replace(" ", string.Empty);
            sn = sn.Replace("'", string.Empty);
            sn = sn.Replace("\r", string.Empty);
            sn = sn.Replace("\n", string.Empty);
            sn = sn.Replace("\"", string.Empty);
            sn = sn.Replace("\\", string.Empty);

            for (int i = 0; i < sn.Length; i++)
            {
                string sx = sn.Substring(i, 1);

                if (sNastyChars.IndexOf(sx) == -1)
                    result += sx;
            }

            return result;
        }

        internal void AddDetailRow(DetailRowData oDet, int rID, bool UsingGrouping, bool ShowFTEs, bool ShowGantt, IList<SortFieldDefn> DetCol, int minp, int maxp, bool bUseQTY, bool bUseCost, bool bshowcostdec)
        {
            var xIParent = Levels[oDet.m_lev - 1];
            var xI = xIParent.CreateSubStruct("I");

            bool bCellhtml = false;

            Levels[oDet.m_lev] = xI;
            xI.CreateStringAttr("id", rID.ToString());
            if (oDet.bRealone)
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

            foreach (var sortField in DetCol)
            {
                var sortFieldName = sortField.name.Replace(" ", "");

                sortFieldName = sortFieldName.Replace("\r", "");
                sortFieldName = sortFieldName.Replace("\n", "");
                sortFieldName = RemoveNastyCharacters(sortFieldName);

                switch (sortField.fid)
                {
                    case (int)FieldIDs.SD_FID:
                        if (oDet.Det_Start != DateTime.MinValue)
                        {
                            xI.CreateStringAttr(sortFieldName, oDet.Det_Start.ToShortDateString());
                        }
                        break;
                    case (int)FieldIDs.FD_FID:
                        if (oDet.Det_Finish != DateTime.MinValue)
                        {
                            xI.CreateStringAttr(sortFieldName, oDet.Det_Finish.ToShortDateString());
                        }
                        break;
                    case (int)FieldIDs.FTOT_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.m_tot1.ToString());
                        break;
                    case (int)FieldIDs.DTOT_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.m_tot2.ToString());
                        break;
                    case (int)FieldIDs.PI_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.PI_Name);
                        break;
                    case (int)FieldIDs.CT_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.CT_Name);
                        break;
                    case (int)FieldIDs.SCEN_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.Scen_Name);
                        break;
                    case (int)FieldIDs.BC_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.Cat_Name);
                        break;
                    case (int)FieldIDs.FULLC_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.FullCatName);
                        break;
                    case (int)FieldIDs.CAT_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.CC_Name);
                        break;
                    case (int)FieldIDs.FULLCAT_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.FullCCName);
                        break;
                    case (int)FieldIDs.BC_ROLE:
                        xI.CreateStringAttr(sortFieldName, oDet.Role_Name);
                        break;
                    case (int)FieldIDs.MC_FID:
                        xI.CreateStringAttr(sortFieldName, oDet.MC_Name);
                        break;
                    default:
                        if (sortField.fid >= 11801 && sortField.fid <= 11805)
                            xI.CreateStringAttr(sortFieldName, oDet.Text_OCVal[sortField.fid - 11800]);

                        else if (sortField.fid >= 11811 && sortField.fid <= 11815)
                            xI.CreateStringAttr(sortFieldName, oDet.TXVal[sortField.fid - 11810]);
                        else if (sortField.fid >= (int)FieldIDs.PI_USE_EXTRA + 1 && sortField.fid <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                        {

                            if (oDet.m_PI_Format_Extra_data != null)
                                xI.CreateStringAttr(sortFieldName, oDet.m_PI_Format_Extra_data[sortField.fid - (int)FieldIDs.PI_USE_EXTRA]);
                        }
                        else
                            xI.CreateStringAttr(sortFieldName, " ");
                        break;
                }
            }

            xI.CreateIntAttr("NoColorState", 1);

            if (ShowGantt)
            {
                if (oDet.bGotChildren == false)
                {
                    xI.CreateStringAttr("GGanttClass", "GanttBlue");
                }
                return;
            }

            for (var i = minp; i <= maxp; i++)
            {
                if (bUseQTY)
                {
                    if (ShowFTEs)
                    {
                        if (oDet.zFTE[i] != double.MinValue)
                        {
                            xI.CreateDoubleAttr("P" + i.ToString() + "V", oDet.zFTE[i]);
                        }
                    }
                    else
                    {
                        if (oDet.zValue[i] != double.MinValue)
                        {
                            xI.CreateDoubleAttr("P" + i.ToString() + "V", oDet.zValue[i]);
                        }
                    }
                }

                if (bUseCost)
                {
                    var dcost = oDet.zCost[i];

                    if (bshowcostdec == false)
                    {
                        dcost = Math.Floor(dcost);
                    }

                    if (oDet.zCost[i] != double.MinValue)
                    {
                        xI.CreateDoubleAttr("P" + i.ToString() + "C", dcost);
                    }
                }
            }
        }
    }
}
