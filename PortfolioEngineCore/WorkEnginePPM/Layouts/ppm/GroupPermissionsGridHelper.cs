using System.Data;
using PortfolioEngineCore;
using WorkEnginePPM.Layouts.ppm;

namespace WorkEnginePPM
{
    public class GroupPermissionsGridHelper
    {
        internal static CStruct BuildGridLayout(DataTable dataTable)
        {
            var grid = InitializeGrid();
            AddToolBar(grid);
            AddPanel(grid);
            AddConfig(grid);
            AddDefinition(grid);
            CStruct cols;
            CStruct header;
            var leftCols = AddColumns(grid, out cols, out header);
            AddFieldIDColumn(leftCols);
            AddNameColumn(leftCols, header);
            var levels = AddCbColumn(cols, header, grid);

            if (dataTable != null)
            {
                XmlHelper.FillFieldsXml(dataTable, levels);
            }
            return grid;
        }

        private static CStruct[] AddCbColumn(CStruct cols, CStruct header, CStruct grid)
        {
            var xC = cols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "CB");
            header.CreateStringAttr("CB", "");
            xC.CreateStringAttr("Type", "Bool");

            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateIntAttr("MinWidth", 30);

            var levels = new CStruct[2];

            var body = grid.CreateSubStruct("Body");
            var xB = body.CreateSubStruct("B");
            levels[0] = xB;
            return levels;
        }

        private static void AddNameColumn(CStruct leftCols, CStruct header)
        {
            var xC = leftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Permission");
            header.CreateStringAttr("Permission", "");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateIntAttr("MinWidth", 350);
        }

        private static void AddFieldIDColumn(CStruct leftCols)
        {
            var xC = leftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "FieldID");
            xC.CreateStringAttr("Type", "Int");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateBooleanAttr("Visible", false);
        }

        private static CStruct AddColumns(CStruct grid, out CStruct cols, out CStruct header)
        {
            var leftCols = grid.CreateSubStruct("LeftCols");
            cols = grid.CreateSubStruct("Cols");
            header = grid.CreateSubStruct("Header");
            header.CreateIntAttr("Visible", 1);
            header.CreateIntAttr("SortIcons", 0);
            return leftCols;
        }

        private static void AddDefinition(CStruct grid)
        {
            var definition = grid.CreateSubStruct("Def");
            var xD = definition.CreateSubStruct("D");
            xD.CreateStringAttr("Name", "R");
            xD.CreateStringAttr("HoverCell", "Color");
            xD.CreateStringAttr("HoverRow", "Color");
            xD.CreateStringAttr("FocusCell", "");
            xD.CreateStringAttr("FocusRow", "Color");
        }

        private static void AddConfig(CStruct grid)
        {
            var config = grid.CreateSubStruct("Cfg");
            config.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            config.CreateIntAttr("SuppressCfg", 1);
            config.CreateIntAttr("InEditMode", 0);

            config.CreateIntAttr("Dragging", 0);
            config.CreateIntAttr("Dropping", 0);
            config.CreateIntAttr("ColsMoving", 0);
            config.CreateIntAttr("ColsPostLap", 1);
            config.CreateIntAttr("ColsLap", 1);
            config.CreateBooleanAttr("ShowDeleted", false);
            config.CreateBooleanAttr("DateStrings", true);

            config.CreateIntAttr("ConstWidth", 2);

            config.CreateIntAttr("MaxWidth", 1);
            config.CreateIntAttr("AppendId", 0);
            config.CreateIntAttr("FullId", 0);
            config.CreateStringAttr("IdChars", "0123456789");

            config.CreateIntAttr("SelectingCells", 1);
            config.CreateStringAttr("Style", "GM");
            config.CreateStringAttr("CSS", "TGrid");
            config.CreateIntAttr("Sorting", 0);
            config.CreateIntAttr("FastColumns", 1);
            config.CreateIntAttr("StaticCursor", 1);
            config.CreateIntAttr("FocusWholeRow", 1);
            config.CreateBooleanAttr("NoTreeLines", true);

            config.CreateStringAttr("MainCol", "Permission");
        }

        private static void AddPanel(CStruct grid)
        {
            var panel = grid.CreateSubStruct("Panel");
            panel.CreateIntAttr("Visible", 0);
            panel.CreateIntAttr("Delete", 0);
        }

        private static void AddToolBar(CStruct grid)
        {
            var toolbar = grid.CreateSubStruct("Toolbar");
            toolbar.CreateIntAttr("Visible", 0);
        }

        private static CStruct InitializeGrid()
        {
            var grid = new CStruct();
            grid.Initialize("Grid");
            return grid;
        }
    }
}