using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataCache;
using PortfolioEngineCore.Fakes;

namespace WorkEnginePPM.Tests.TestDoubles
{
    public class TopGridBaseTestDouble : TopGrid
    {
        public TopGridBaseTestDouble(
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
        }

        public new string RemoveNastyCharacters(string input)
        {
            return base.RemoveNastyCharacters(input);
        }

        public void AddDetailRow(DetailRowData detailRowData)
        {
            base.AddDetailRow(detailRowData, 0);
        }
    }
}
