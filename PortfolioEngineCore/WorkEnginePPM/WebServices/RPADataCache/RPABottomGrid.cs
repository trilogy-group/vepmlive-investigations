using System;
using System.Collections.Generic;
using ResourceValues;

namespace RPADataCache
{
    internal class RPABottomGrid : RPADataCacheGridBase
    {
        public RPABottomGrid(
            IList<clsRXDisp> columns, 
            int pmoAdmin, 
            string xmlString, 
            int displayMode, 
            IList<RPATGRow> displayList, 
            clsResourceValues resourceValues, 
            clsLookupList categoryLookupList) 
        : base(columns, pmoAdmin, xmlString, displayMode, displayList, resourceValues, categoryLookupList)
        {
        }

        protected override void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }

        protected override string ResolvePeriodId(CPeriod periodData, int index)
        {
            throw new NotImplementedException();
        }

        protected override void AddPeriodColumns(IEnumerable<CPeriod> periods)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckIfDetailRowShouldBeAdded(Tuple<clsResXData, clsPIData> detailRow)
        {
            throw new NotImplementedException();
        }

        protected override void AddDetailRow(Tuple<clsResXData, clsPIData> detailRowData, int rowId)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }
    }
}
