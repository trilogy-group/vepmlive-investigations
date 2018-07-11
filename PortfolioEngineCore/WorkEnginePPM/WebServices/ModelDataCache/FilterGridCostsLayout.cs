using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class FilterGridCostsLayout
    {
        private CStruct xGrid;

        public void InitializeGridLayout()
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            xCfg.CreateStringAttr("MainCol", "Filtering");

            xCfg.CreateBooleanAttr("NoTreeLines", true);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);

            xCfg.CreateIntAttr("ExactSize", 0);
            xCfg.CreateIntAttr("SelectingCells", 1);

            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("PrintCols", 0);

            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("FilterEmpty", 1);

            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);

            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "Modeler");

            CStruct xCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xHead = xGrid.CreateSubStruct("Header");

            xHead.CreateIntAttr("Visible", 0);
            // Add category column
            CStruct xC = xCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "Select");
            xC.CreateStringAttr("Type", "Bool");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateStringAttr("Width", "20");
            xHead.CreateStringAttr("Select", " ");

            xC = xCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Filtering");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("Width", 200);
            xC.CreateBooleanAttr("CanEdit", false);
            xHead.CreateStringAttr("Filtering", "Filter");
        }

        public string GetString()
        {
            return xGrid.XML();
        }
    }
}
