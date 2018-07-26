using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;

namespace CADataCache
{
    internal abstract class CADataGridCacheBase : GridBase<clsPeriodData, clsDetailRowData>
    {
        public readonly bool ShowFTEs;
        public readonly bool UseQuantity;
        public readonly bool UseCost;
        public readonly bool ShowCostDetailed;
        private readonly IList<CATGRow> _displayList;
        private readonly IList<clsColDisp> _columns;

        public CADataGridCacheBase(
            bool showFTEs, 
            bool useQuantity,
            bool useCost, 
            bool showCostDetailed, 
            IList<CATGRow> displayList,
            IList<clsColDisp> columns)
        {
            ShowFTEs = showFTEs;
            UseQuantity = useQuantity;
            UseCost = useCost;
            ShowCostDetailed = showCostDetailed;
            _displayList = displayList;
            _columns = columns;
        }

        protected string CleanupString(string input)
        {
            return RemoveCharacters(input, "!@#$%^&*()_+-={}[]|:;'?/~` '\r\n\"\\");
        }
    }
}
