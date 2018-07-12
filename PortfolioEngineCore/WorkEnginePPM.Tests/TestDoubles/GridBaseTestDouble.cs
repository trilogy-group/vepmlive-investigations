using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataCache;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;

namespace WorkEnginePPM.Tests.TestDoubles
{
    public class GridBaseTestDouble : GridBase
    {
        public GridBaseTestDouble(
            ShimCStruct header1Shim,
            ShimCStruct header2Shim,
            ShimCStruct periodColsShim,

            bool useGrouping, 
            bool showFTEs, 
            bool showGantt, 
            DateTime dateStart, 
            DateTime dateEnd, 
            IList<SortFieldDefn> sortFields, 
            int detFreeze, 
            bool useQuantity, 
            bool useCost, 
            bool roundCost, 
            int fromPeriodIndex, 
            int toPeriodIndex
        ) : base(useGrouping, showFTEs, showGantt, dateStart, dateEnd, sortFields, detFreeze, useQuantity, useCost, roundCost, fromPeriodIndex, toPeriodIndex)
        {

            Header1 = header1Shim;
            Header2 = header2Shim;
            PeriodCols = periodColsShim;
        }

        public new void AddPeriodColumns(IEnumerable<PeriodData> periodsData)
        {
            base.AddPeriodColumns(periodsData);
        }

        protected override void AddDetailRow(DetailRowData detailRowData, int rowId)
        {
        }

        protected override void InitializeGridData(RenderingTypes renderingType)
        {
        }

        protected override void InitializeGridLayout(RenderingTypes renderingType)
        {
        }

        protected override string ResolvePeriodId(PeriodData periodData, int index)
        {
            return index.ToString();
        }
    }
}
