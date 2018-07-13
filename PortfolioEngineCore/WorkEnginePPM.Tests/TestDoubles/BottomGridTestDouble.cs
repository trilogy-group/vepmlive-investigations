using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataCache;
using PortfolioEngineCore.Fakes;

namespace WorkEnginePPM.Tests.TestDoubles
{
    public class BottomGridTestDouble : BottomGrid
    {
        public BottomGridTestDouble(bool applyTarget, IList<DetailRowData> targetsSorted, IList<TargetColours> targetColors, bool showRemaining, bool useGrouping, bool showFTEs, bool showGantt, DateTime dateStart, DateTime dateEnd, IList<SortFieldDefn> sortFields, int detFreeze, bool useQuantity, bool useCost, bool showCostDetailed, int fromPeriodIndex, int toPeriodIndex) : base(applyTarget, targetsSorted, targetColors, showRemaining, useGrouping, showFTEs, showGantt, dateStart, dateEnd, sortFields, detFreeze, useQuantity, useCost, showCostDetailed, fromPeriodIndex, toPeriodIndex)
        {
            for (var i = 0; i < Levels.Length; i++)
            {
                Levels[i] = new ShimCStruct();
            }

            Constructor = new PortfolioEngineCore.CStruct();
            Constructor.Initialize("Grid");
        }

        public void AddDetailRow(DetailRowData detailRowData)
        {
            AddDetailRow(detailRowData, 0);
        }

        public new void AddDetailRow(DetailRowData detailRowData, int rowId)
        {
            base.AddDetailRow(detailRowData, rowId);
        }

        public new void InitializeGridLayout(RenderingTypes renderingType)
        {
            base.InitializeGridLayout(renderingType);
        }
    }
}
