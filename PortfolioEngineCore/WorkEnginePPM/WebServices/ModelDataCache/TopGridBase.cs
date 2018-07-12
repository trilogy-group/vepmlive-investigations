using System;
using System.Collections.Generic;
using System.Text;

namespace ModelDataCache
{
    public abstract class TopGridBase : GridBase
    {
        public TopGridBase(bool useGrouping, bool showFTEs, bool showGantt, DateTime dateStart, DateTime dateEnd, IList<SortFieldDefn> sortFields, int detFreeze, bool useQuantity, bool useCost, bool showCostDetailed, int fromPeriodIndex, int toPeriodIndex) 
            : base(useGrouping, showFTEs, showGantt, dateStart, dateEnd, sortFields, detFreeze, useQuantity, useCost, showCostDetailed, fromPeriodIndex, toPeriodIndex)
        {
        }

        protected string RemoveNastyCharacters(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            const string nastyChars = "!@#$%^&*()_+-={}[]|:;'?/~`";
            const string charsToCleanup = nastyChars + " '\r\n\"\\";

            var result = new StringBuilder(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (charsToCleanup.IndexOf(input[i]) < 0)
                {
                    result.Append(input[i]);
                }
            }

            return result.ToString();
        }

        // (CC-76582, 2018-07-12) Not using enumerator pattern, because rows will only be added if enumeration is fully completed, which is not obvious. 
        // One might call AddDetailRows without processing the result and the expectation would be that rows are added.
        // List is returned because the calling code consumes List instead of IList and will not be refactored in scope of the current refactoring
        public List<DetailRowData> AddDetailRows(IList<DetailRowData> detailRows)
        {
            var i = 0;
            var result = new List<DetailRowData>();

            foreach(var detailRow in detailRows)
            {
                if (CheckIfDetailRowShouldBeAdded(detailRow))
                {
                    AddDetailRow(detailRow, i++);
                    result.Add(detailRow);
                }
            }

            return result;
        }

        private void AddDetailRow(DetailRowData detailRowData, int rowId)
        {
            var parent = Levels[detailRowData.m_lev - 1];
            var iSubStruct = parent.CreateSubStruct("I");

            var wrapCellInHtml = false;

            Levels[detailRowData.m_lev] = iSubStruct;
            iSubStruct.CreateStringAttr("id", rowId.ToString());
            if (detailRowData.bRealone)
            {
                iSubStruct.CreateStringAttr("Color", "255,255,255");
            }

            iSubStruct.CreateStringAttr("Select", (detailRowData.bSelected ? "1" : "0"));
            iSubStruct.CreateBooleanAttr("SelectCanEdit", true);
            iSubStruct.CreateBooleanAttr("CanEdit", false);

            if (detailRowData.m_lev != 1)
            {
                iSubStruct.CreateIntAttr("CanFilter", 2);
            }

            iSubStruct.CreateStringAttr("xGrouping", detailRowData.sName);
            if (wrapCellInHtml)
            {
                iSubStruct.CreateStringAttr("GroupingHtmlPrefix", "<B>");
                iSubStruct.CreateStringAttr("GroupingHtmlPostfix", "</B>");
            }

            foreach (var sortField in SortFields)
            {
                var sortFieldName = RemoveNastyCharacters(sortField.name);

                string value;
                if (TryGetDataFromDetailRowDataField(detailRowData, sortField.fid, out value))
                {
                    iSubStruct.CreateStringAttr(sortFieldName, value);
                }
            }

            iSubStruct.CreateIntAttr("NoColorState", 1);

            if (ShowGantt)
            {
                if (detailRowData.bGotChildren == false)
                {
                    iSubStruct.CreateStringAttr("GGanttClass", "GanttBlue");
                }
            }
            else
            {
                DisplayValues(detailRowData, iSubStruct);
            }
        }

        private void DisplayValues(DetailRowData detailRowData, PortfolioEngineCore.CStruct iSubStruct)
        {
            for (var i = FromPeriodIndex; i <= ToPeriodIndex; i++)
            {
                if (UseQuantity)
                {
                    if (ShowFTEs)
                    {
                        if (detailRowData.zFTE[i] != double.MinValue)
                        {
                            iSubStruct.CreateDoubleAttr("P" + i.ToString() + "V", detailRowData.zFTE[i]);
                        }
                    }
                    else
                    {
                        if (detailRowData.zValue[i] != double.MinValue)
                        {
                            iSubStruct.CreateDoubleAttr("P" + i.ToString() + "V", detailRowData.zValue[i]);
                        }
                    }
                }

                if (UseCost)
                {
                    var dcost = detailRowData.zCost[i];

                    if (ShowCostDetailed == false)
                    {
                        dcost = Math.Floor(dcost);
                    }

                    if (detailRowData.zCost[i] != double.MinValue)
                    {
                        iSubStruct.CreateDoubleAttr("P" + i.ToString() + "C", dcost);
                    }
                }
            }
        }

        private bool TryGetDataFromDetailRowDataField(DetailRowData detailRowData, int fid, out string value)
        {
            var result = true;

            switch (fid)
            {
                case (int)FieldIDs.SD_FID:
                    if (detailRowData.Det_Start != DateTime.MinValue)
                    {
                        value = detailRowData.Det_Start.ToShortDateString();
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                case (int)FieldIDs.FD_FID:
                    if (detailRowData.Det_Finish != DateTime.MinValue)
                    {
                        value = detailRowData.Det_Finish.ToShortDateString();
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                case (int)FieldIDs.FTOT_FID:
                    value = detailRowData.m_tot1.ToString();
                    break;
                case (int)FieldIDs.DTOT_FID:
                    value = detailRowData.m_tot2.ToString();
                    break;
                case (int)FieldIDs.PI_FID:
                    value = detailRowData.PI_Name;
                    break;
                case (int)FieldIDs.CT_FID:
                    value = detailRowData.CT_Name;
                    break;
                case (int)FieldIDs.SCEN_FID:
                    value = detailRowData.Scen_Name;
                    break;
                case (int)FieldIDs.BC_FID:
                    value = detailRowData.Cat_Name;
                    break;
                case (int)FieldIDs.FULLC_FID:
                    value = detailRowData.FullCatName;
                    break;
                case (int)FieldIDs.CAT_FID:
                    value = detailRowData.CC_Name;
                    break;
                case (int)FieldIDs.FULLCAT_FID:
                    value = detailRowData.FullCCName;
                    break;
                case (int)FieldIDs.BC_ROLE:
                    value = detailRowData.Role_Name;
                    break;
                case (int)FieldIDs.MC_FID:
                    value = detailRowData.MC_Name;
                    break;
                default:
                    if (fid >= 11801 && fid <= 11805)
                    {
                        value = detailRowData.Text_OCVal[fid - 11800];
                    }
                    else if (fid >= 11811 && fid <= 11815)
                    {
                        value = detailRowData.TXVal[fid - 11810];
                    }
                    else if (fid >= (int)FieldIDs.PI_USE_EXTRA + 1 && fid <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                    {
                        if (detailRowData.m_PI_Format_Extra_data != null)
                        {
                            value = detailRowData.m_PI_Format_Extra_data[fid - (int)FieldIDs.PI_USE_EXTRA];
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        value = " ";
                    }
                    break;
            }

            value = null;
            return result;
        }
    }
}
