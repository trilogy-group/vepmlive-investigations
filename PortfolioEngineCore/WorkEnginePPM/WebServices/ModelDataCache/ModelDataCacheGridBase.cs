using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore;
using PortfolioEngineCore;

namespace ModelDataCache
{
    public abstract class ModelDataCacheGridBase : GridBase
    {
        public readonly bool UseGrouping;
        public readonly bool ShowFTEs;
        public readonly bool ShowGantt;
        public readonly DateTime DateStart;
        public readonly DateTime DateEnd;
        public readonly IList<SortFieldDefn> SortFields;
        public readonly int Freeze;
        public readonly bool UseQuantity;
        public readonly bool UseCost;
        public readonly bool ShowCostDetailed;

        public ModelDataCacheGridBase(
            bool useGrouping,
            bool showFTEs,
            bool showGantt,
            DateTime dateStart,
            DateTime dateEnd,
            IList<SortFieldDefn> sortFields,
            int detFreeze,
            bool useQuantity,
            bool useCost,
            bool showCostDetailed,
            int fromPeriodIndex,
            int toPeriodIndex)
        : base (fromPeriodIndex, toPeriodIndex)
        {
            UseGrouping = useGrouping;
            ShowFTEs = showFTEs;
            ShowGantt = showGantt;
            DateStart = dateStart;
            DateEnd = dateEnd;
            SortFields = sortFields;
            Freeze = detFreeze;
            UseQuantity = useQuantity;
            UseCost = useCost;
            ShowCostDetailed = showCostDetailed;
        }

        protected override void AddPeriodColumn(string id, string name)
        {
            CStruct xC = null;

            if (UseQuantity)
            {
                if (UseCost)
                {
                    Header1.CreateStringAttr("P" + id + "VSpan", "2");
                }

                Header1.CreateStringAttr("P" + id + "V", name);
            }
            else
            {
                Header1.CreateStringAttr("P" + id + "C", name);
            }

            if (UseQuantity)
            {
                if (ShowFTEs)
                {
                    Header2.CreateStringAttr("P" + id + "V", " FTE ");
                }
                else
                {
                    Header2.CreateStringAttr("P" + id + "V", " Qty ");
                }
            }

            if (UseCost)
            {
                Header2.CreateStringAttr("P" + id + "C", " Cost ");
            }

            if (UseQuantity)
            {
                xC = PeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + id + "V");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", "#.##");
            }

            if (UseCost)
            {
                xC = PeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + id + "C");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", (ShowCostDetailed ? ",#.00;-,#.00;0" : ",0"));
            }
        }

        protected bool AddSortFieldsToColumns(CStruct xLeftCols, CStruct xCols, ref CStruct categoryColumn)
        {
            bool useCols = false;

            foreach (var sortField in SortFields)
            {
                var sortFieldName = CleanUpString(sortField.name);

                var h1 = GlobalConstants.Whitespace;
                var h2 = GlobalConstants.Whitespace;

                var indexOfSpace = sortField.name.IndexOf(GlobalConstants.Whitespace);
                if (indexOfSpace == -1)
                {
                    h1 = GlobalConstants.Whitespace;
                    h2 = sortField.name;
                }
                else
                {
                    h1 = sortField.name.Substring(0, indexOfSpace);
                    h2 = sortField.name.Substring(indexOfSpace + 1);
                }

                if (useCols)
                {
                    categoryColumn = xCols.CreateSubStruct("C");
                }
                else
                {
                    categoryColumn = xLeftCols.CreateSubStruct("C");
                }

                categoryColumn.CreateStringAttr("Name", sortFieldName);

                switch (sortField.fid)
                {
                    case (int)FieldIDs.SD_FID:
                    case (int)FieldIDs.FD_FID:
                        categoryColumn.CreateStringAttr("Type", "Date");
                        categoryColumn.CreateStringAttr("Format", "MM/dd/yyyy");
                        break;
                    case (int)FieldIDs.FTOT_FID:
                    case (int)FieldIDs.DTOT_FID:
                        categoryColumn.CreateStringAttr("Type", "Float");
                        categoryColumn.CreateStringAttr("Format", ",#.##");
                        break;
                    default:
                        categoryColumn.CreateStringAttr("Type", "Text");
                        break;
                }

                categoryColumn.CreateIntAttr("CanMove", 0);

                if (sortField.selected == 0)
                {
                    categoryColumn.CreateIntAttr("Width", 0);
                }

                categoryColumn.CreateBooleanAttr("CanEdit", false);
                Header1.CreateStringAttr(sortFieldName, h1);
                Header2.CreateStringAttr(sortFieldName, h2);

                if (sortField.fid == Freeze)
                {
                    useCols = true;
                }
            }

            return useCols;
        }
    }
}
