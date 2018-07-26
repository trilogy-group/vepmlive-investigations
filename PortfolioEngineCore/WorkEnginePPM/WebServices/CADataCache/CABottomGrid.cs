using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;
using PortfolioEngineCore;

namespace CADataCache
{
    internal class CABottomGridTemp : CADataCacheGridBase
    {
        public CABottomGridTemp(
            bool showFTEs,
            bool useQuantity,
            bool useCost,
            bool showCostDetailed,
            int pmoAdmin,
            IList<CATGRow> displayList,
            IList<clsColDisp> columns) 
        : base(showFTEs, useQuantity, useCost, showCostDetailed, pmoAdmin, displayList, columns, false)
        {
        }

        protected override void InitializeGridLayoutCategoryColumns(CStruct columnsContainer)
        {
            var column = CreateColumn(columnsContainer, "rowid", "Text",
                visible: false,
                canExport: false);
            column.CreateStringAttr("Color", "rgb(223, 227, 232)");
        }

        protected override string ResolvePeriodId(clsPeriodData periodData, int index)
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

        protected override void AddDetailRow(clsDetailRowData detailRowData, int rowId)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }
    }
}
