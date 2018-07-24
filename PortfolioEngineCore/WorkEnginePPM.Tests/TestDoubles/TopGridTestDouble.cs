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
    public class TopGridTestDouble : TopGrid
    {
        public new int Level => base.Level;
        public new CStruct[] Levels => base.Levels;

        public TopGridTestDouble(
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
        : base(useGrouping, showFTEs, showGantt, dateStart, dateEnd, sortFields, detFreeze, useQuantity, useCost, showCostDetailed, fromPeriodIndex, toPeriodIndex)
        {
            for (var i = 0; i < Levels.Length; i++)
            {
                Levels[i] = new ShimCStruct();
            }

            Constructor = new PortfolioEngineCore.CStruct();
            Constructor.Initialize("Grid");
        }

        public new string CleanUpString(string input)
        {
            return base.CleanUpString(input);
        }

        public new string ResolvePeriodId(PeriodData period, int index)
        {
            return base.ResolvePeriodId(period, index);
        }

        public void AddDetailRow(DetailRowData detailRowData)
        {
            AddDetailRow(detailRowData, 0);
        }

        public new void AddDetailRow(DetailRowData detailRowData, int rowId)
        {
            base.AddDetailRow(detailRowData, rowId);
        }

        public new void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            base.InitializeGridLayout(renderingType);
        }

        public new void InitializeGridData(GridRenderingTypes renderingType)
        {
            base.InitializeGridData(renderingType);
        }
    }
}
