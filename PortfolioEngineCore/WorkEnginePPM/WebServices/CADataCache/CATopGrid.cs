using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;

namespace CADataCache
{
    internal class CATopGridTemp : CADataGridCacheBase
    {
        public CATopGridTemp(
            bool showFTEs, 
            bool useQuantity,
            bool useCost, 
            bool showCostDetailed,
            IList<CATGRow> displayList,
            IList<clsColDisp> columns) 
        : base(showFTEs, useQuantity, useCost, showCostDetailed, displayList, columns)
        {
        }

        protected override void AddDetailRow(clsDetailRowData detailRowData, int rowId)
        {
            throw new NotImplementedException();
        }

        protected override void AddPeriodColumns(IEnumerable<clsPeriodData> periods)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckIfDetailRowShouldBeAdded(clsDetailRowData detailRow)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }

        protected override string ResolvePeriodId(clsPeriodData periodData, int index)
        {
            throw new NotImplementedException();
        }
    }
}
