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
            if (renderingType == GridRenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

            var xToolbar = Constructor.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            var xMenuc = Constructor.CreateSubStruct("MenuCfg");

            var xPanel = Constructor.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            var xCfg = InitializeGridLayoutConfig("ResOrRole", 1, 0, 400, 400);
            xCfg.CreateIntAttr("ConstHeight", 1);
            xCfg.CreateIntAttr("LeftCanResize", 0);
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
