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
        public readonly IList<RenderingTypes> InitializeGridLayoutCalls = new List<RenderingTypes>();
        public readonly IList<RenderingTypes> FinalizeGridLayoutCalls = new List<RenderingTypes>();
        public readonly IList<IEnumerable<PeriodData>> AddPeriodColumnsCalls = new List<IEnumerable<PeriodData>>();
        public readonly IList<RenderingTypes> InitializeGridDataCalls = new List<RenderingTypes>();
        public readonly IList<Tuple<DetailRowData, int>> AddDetailRowCalls = new List<Tuple<DetailRowData, int>>();
        public readonly IList<Tuple<string, string>> AddPeriodColumnCalls = new List<Tuple<string, string>>();

        public GridBaseTestDouble(
            ShimCStruct header1Shim,
            ShimCStruct header2Shim,
            ShimCStruct periodColsShim,

            int fromPeriodIndex, 
            int toPeriodIndex
        ) : base(fromPeriodIndex, toPeriodIndex)
        {

            Header1 = header1Shim;
            Header2 = header2Shim;
            PeriodCols = periodColsShim;

            Constructor = new PortfolioEngineCore.CStruct();
            Constructor.Initialize("Grid");
        }

        public void AddPeriodColumnsTest(IEnumerable<PeriodData> periodsData)
        {
            base.AddPeriodColumns(periodsData);
        }

        protected override void AddPeriodColumns(IEnumerable<PeriodData> periods)
        {
            AddPeriodColumnsCalls.Add(periods);
            base.AddPeriodColumns(periods);
        }

        public new bool TryGetDataFromDetailRowDataField(DetailRowData detailRowData, int fid, out string value)
        {
            return base.TryGetDataFromDetailRowDataField(detailRowData, fid, out value);
        }

        protected override void AddDetailRow(DetailRowData detailRowData, int rowId)
        {
            AddDetailRowCalls.Add(Tuple.Create(detailRowData, rowId));
        }

        protected override void AddPeriodColumn(string id, string name)
        {
            AddPeriodColumnCalls.Add(Tuple.Create(id, name));
        }

        protected override string CleanUpString(string input)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridData(RenderingTypes renderingType)
        {
            InitializeGridDataCalls.Add(renderingType);
        }

        protected override void InitializeGridLayout(RenderingTypes renderingType)
        {
            InitializeGridLayoutCalls.Add(renderingType);
        }

        protected override void FinalizeGridLayout(RenderingTypes renderingType)
        {
            FinalizeGridLayoutCalls.Add(renderingType);
        }

        protected override string ResolvePeriodId(PeriodData periodData, int index)
        {
            return index.ToString();
        }
    }
}
