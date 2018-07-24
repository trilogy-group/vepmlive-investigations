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
    public class GridBaseTestDouble : GridBase<PeriodData, DetailRowData>
    {
        public readonly IList<GridRenderingTypes> InitializeGridLayoutCalls = new List<GridRenderingTypes>();
        public readonly IList<GridRenderingTypes> FinalizeGridLayoutCalls = new List<GridRenderingTypes>();
        public readonly IList<IEnumerable<PeriodData>> AddPeriodColumnsCalls = new List<IEnumerable<PeriodData>>();
        public readonly IList<GridRenderingTypes> InitializeGridDataCalls = new List<GridRenderingTypes>();
        public readonly IList<Tuple<DetailRowData, int>> AddDetailRowCalls = new List<Tuple<DetailRowData, int>>();
        public readonly IList<Tuple<string, string>> AddPeriodColumnCalls = new List<Tuple<string, string>>();

        public GridBaseTestDouble(
            ShimCStruct header1Shim,
            ShimCStruct header2Shim,
            ShimCStruct periodColsShim
        )
        {

            Header1 = header1Shim;
            Header2 = header2Shim;
            PeriodCols = periodColsShim;

            Constructor = new PortfolioEngineCore.CStruct();
            Constructor.Initialize("Grid");
        }

        public void AddPeriodColumnsTest(IEnumerable<PeriodData> periodsData)
        {
            AddPeriodColumns(periodsData);
        }

        protected override void AddPeriodColumns(IEnumerable<PeriodData> periods)
        {
            AddPeriodColumnsCalls.Add(periods);
        }

        protected override void AddDetailRow(DetailRowData detailRowData, int rowId)
        {
            AddDetailRowCalls.Add(Tuple.Create(detailRowData, rowId));
        }
        
        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            InitializeGridDataCalls.Add(renderingType);
        }

        protected override void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            InitializeGridLayoutCalls.Add(renderingType);
        }

        protected override void FinalizeGridLayout(GridRenderingTypes renderingType)
        {
            FinalizeGridLayoutCalls.Add(renderingType);
        }

        protected override string ResolvePeriodId(PeriodData periodData, int index)
        {
            return index.ToString();
        }

        protected override bool CheckIfDetailRowShouldBeAdded(DetailRowData detailRow)
        {
            return true;
        }
    }
}
