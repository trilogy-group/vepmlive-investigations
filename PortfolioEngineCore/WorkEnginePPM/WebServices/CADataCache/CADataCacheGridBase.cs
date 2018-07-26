using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;
using PortfolioEngineCore;

namespace CADataCache
{
    internal abstract class CADataCacheGridBase : ADataCacheGridBase<clsPeriodData, clsDetailRowData>
    {
        protected readonly bool _showFTEs;
        protected readonly bool _useQuantity;
        protected readonly bool _useCost;
        protected readonly bool _showCostDetailed;
        protected readonly int _pmoAdmin;
        protected readonly IList<CATGRow> _displayList;
        protected readonly IList<clsColDisp> _columns;

        protected CStruct MiddleCols;

        protected CStruct Definitions;
        protected CStruct DefinitionRight;
        protected CStruct DefinitionLeaf;

        public CADataCacheGridBase(
            bool showFTEs, 
            bool useQuantity,
            bool useCost, 
            bool showCostDetailed, 
            int pmoAdmin,
            IList<CATGRow> displayList,
            IList<clsColDisp> columns)
        {
            _showFTEs = showFTEs;
            _useQuantity = useQuantity;
            _useCost = useCost;
            _showCostDetailed = showCostDetailed;
            _displayList = displayList;
            _columns = columns;
            _pmoAdmin = pmoAdmin;
        }

        protected string CleanupString(string input)
        {
            return RemoveCharacters(input, "!@#$%^&*()_+-={}[]|:;'?/~` '\r\n\"\\");
        }
    }
}
