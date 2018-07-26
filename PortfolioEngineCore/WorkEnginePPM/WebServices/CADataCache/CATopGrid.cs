using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;
using EPMLiveCore;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint.Administration;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace CADataCache
{
    internal class CATopGridTemp : CADataCacheGridBase
    {
        public CATopGridTemp(
            bool showFTEs, 
            bool useQuantity,
            bool useCost, 
            bool showCostDetailed,
            int pmoAdmin,
            IList<CATGRow> displayList,
            IList<clsColDisp> columns) 
        : base(showFTEs, useQuantity, useCost, showCostDetailed, pmoAdmin, displayList, columns)
        {
        }

        protected override void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            InitializeGridLayoutConfig();

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            var xRightCols = Constructor.CreateSubStruct("RightCols");
            PeriodCols = xRightCols;
            MiddleCols = xCols;

            Definitions = Constructor.CreateSubStruct("Def");

            DefinitionRight = Definitions.CreateSubStruct("D");
            DefinitionRight.CreateStringAttr("Name", "R");
            DefinitionRight.CreateStringAttr("Calculated", "1");
            DefinitionRight.CreateStringAttr("Calculated", "1");
            DefinitionRight.CreateStringAttr("HoverCell", "Color");
            DefinitionRight.CreateStringAttr("HoverRow", "Color");
            DefinitionRight.CreateStringAttr("FocusCell", string.Empty);
            DefinitionRight.CreateStringAttr("HoverCell", "Color");
            DefinitionRight.CreateIntAttr("NoColorState", 1);
            DefinitionRight.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            DefinitionRight.CreateBooleanAttr("SelectCanEdit", true);
            DefinitionRight.CreateStringAttr("rowid", string.Empty);

            DefinitionLeaf = Definitions.CreateSubStruct("D");
            DefinitionLeaf.CreateStringAttr("Name", "Leaf");
            DefinitionLeaf.CreateStringAttr("Calculated", "0");
            DefinitionLeaf.CreateStringAttr("HoverCell", "Color");
            DefinitionLeaf.CreateStringAttr("HoverRow", "Color");
            DefinitionLeaf.CreateStringAttr("FocusCell", string.Empty);
            DefinitionLeaf.CreateStringAttr("HoverCell", "Color");
            DefinitionLeaf.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            DefinitionLeaf.CreateIntAttr("NoColorState", 1);

            var xHead = Constructor.CreateSubStruct("Head");
            var xFilter = xHead.CreateSubStruct("Filter");
            xFilter.CreateStringAttr("id", "Filter");

            Header1 = Constructor.CreateSubStruct("Header");
            Header1.CreateIntAttr("PortfolioItemVisible", 1);
            Header1.CreateIntAttr("Spanned", 1);
            Header1.CreateIntAttr("SortIcons", 2);
            Header1.CreateStringAttr("HoverCell", "Color");
            Header1.CreateStringAttr("HoverRow", string.Empty);
            Header1.CreateStringAttr("RowSel", GlobalConstants.Whitespace);
            Header1.CreateStringAttr("Select", GlobalConstants.Whitespace);

            Header2 = xHead.CreateSubStruct("Header");
            Header2.CreateIntAttr("PortfolioItemVisible", 1);
            Header2.CreateIntAttr("Spanned", -1);
            Header2.CreateIntAttr("SortIcons", 0);
            Header2.CreateStringAttr("HoverCell", "Color");
            Header2.CreateStringAttr("HoverRow", string.Empty);
            Header2.CreateStringAttr("RowSel", GlobalConstants.Whitespace);
            Header2.CreateStringAttr("Select", GlobalConstants.Whitespace);

            var xC = xLeftCols.CreateSubStruct("C");
            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "RowSel");
            xC.CreateStringAttr("Type", "Icon");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateStringAttr("Width", "20");
            xC.CreateStringAttr("Color", "rgb(223, 227, 232)");
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "rowid");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("Visible", 0);
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Select");
            xC.CreateStringAttr("Type", "Bool");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateStringAttr("Width", "20");
            xC.CreateStringAttr("Class", string.Empty);
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);

            var xSolid = Constructor.CreateSubStruct("Solid");
            var xGroup = xSolid.CreateSubStruct("Group");

            foreach (var column in _columns)
            {
                try
                {
                    var realName = "zX" + CleanupString(column.m_realname);
                    var displayName = column.m_dispname.Replace("/n", "\n");

                    xC = xCols.CreateSubStruct("C");

                    xC.CreateStringAttr("Name", realName);
                    xC.CreateStringAttr("Class", "GMCellMain");
                    xC.CreateIntAttr("CanDrag", 0);
                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateIntAttr("CaseSensitive", 0);
                    xC.CreateStringAttr("OnDragCell", "Focus,DragCell");

                    DefinitionRight.CreateIntAttr(realName + "CanDrag", 0);
                    DefinitionRight.CreateStringAttr(realName + "HtmlPrefix", "<B>");
                    DefinitionRight.CreateStringAttr(realName + "HtmlPostfix", "</B>");

                    DefinitionLeaf.CreateIntAttr(realName + "CanDrag", 0);
                    DefinitionLeaf.CreateStringAttr(realName + "HtmlPrefix", string.Empty);
                    DefinitionLeaf.CreateStringAttr(realName + "HtmlPostfix", string.Empty);

                    switch (column.m_type)
                    {
                        case 2:
                            break;
                        case 3:
                            xC.CreateStringAttr("Type", "Float");
                            xC.CreateStringAttr("Format", ",0.##");
                            break;
                        default:
                            xC.CreateStringAttr("Type", "Text");
                            break;
                    }

                    xC.CreateIntAttr("CanEdit", 0);
                    xC.CreateIntAttr("CanMove", 1);

                    if (column.m_unselectable == true)
                    {
                        xC.CreateIntAttr("CanHide", 0);
                    }

                    if (column.m_def_fld == false)
                    {
                        xC.CreateIntAttr("Visible", 0);
                    }

                    if (column.m_col_hidden == true)
                    {
                        xC.CreateIntAttr("Width", 0);
                    }

                    Header1.CreateStringAttr(realName, displayName);
                    Header2.CreateStringAttr(realName, GlobalConstants.Whitespace);

                    const string sMaxFunc = "(Row.id == 'Filter' ? '' : max())";
                    const string sMinFunc = "(Row.id == 'Filter' ? '' : min())";

                    xC = MiddleCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "xinterenalPeriodMin");
                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Type", "Int");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateStringAttr("Align", "Right");
                    xC.CreateIntAttr("Visible", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateIntAttr("CanDrag", 0);

                    DefinitionRight.CreateStringAttr("xinterenalPeriodMin" + "Formula", sMinFunc);
                    DefinitionRight.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);

                    DefinitionLeaf.CreateStringAttr("xinterenalPeriodMin" + "Formula", string.Empty);
                    DefinitionLeaf.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);

                    xC = MiddleCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "xinterenalPeriodMax");
                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Type", "Int");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateStringAttr("Align", "Right");
                    xC.CreateIntAttr("Visible", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateIntAttr("CanDrag", 0);

                    DefinitionRight.CreateStringAttr("xinterenalPeriodMax" + "Formula", sMaxFunc);
                    DefinitionRight.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);

                    DefinitionLeaf.CreateStringAttr("xinterenalPeriodMax" + "Formula", string.Empty);
                    DefinitionLeaf.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);

                    xC = MiddleCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", "xinterenalPeriodTotal");
                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateStringAttr("Type", "Int");
                    xC.CreateIntAttr("CanSort", 0);
                    xC.CreateIntAttr("CanMove", 0);
                    xC.CreateStringAttr("Align", "Right");
                    xC.CreateIntAttr("Visible", 0);
                    xC.CreateIntAttr("CanSelect", 0);
                    xC.CreateIntAttr("CanHide", 0);
                    xC.CreateIntAttr("CanDrag", 0);

                    DefinitionLeaf.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                    DefinitionRight.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                }
                catch (Exception ex)
                {
                    LoggingService.WriteTrace(
                       Area.EPMLiveWorkEnginePPM,
                       Categories.EPMLiveWorkEnginePPM.Others,
                       TraceSeverity.VerboseEx,
                       ex.ToString());
                }
            }
        }

        private void InitializeGridLayoutConfig()
        {
            var xToolbar = Constructor.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            var xPanel = Constructor.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            var xCfg = Constructor.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("MainCol", "zXPortfolioItem");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("SuppressMessage", 3);
            xCfg.CreateIntAttr("Dragging", _pmoAdmin);
            xCfg.CreateIntAttr("Sorting", 1);
            xCfg.CreateIntAttr("ColsMoving", 1);
            xCfg.CreateIntAttr("ColsPosLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateIntAttr("VisibleLap", 1);
            xCfg.CreateIntAttr("SectionWidthLap", 1);
            xCfg.CreateIntAttr("GroupLap", 1);
            xCfg.CreateIntAttr("WideHScroll", 0);
            xCfg.CreateIntAttr("LeftWidth", 150);
            xCfg.CreateIntAttr("Width", 400);
            xCfg.CreateIntAttr("RightWidth", 800);
            xCfg.CreateIntAttr("MinMidWidth", 50);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 0);
            xCfg.CreateIntAttr("RightCanResize", 1);
            xCfg.CreateIntAttr("FocusWholeRow", 1);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("MaxSort", 2);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");
            xCfg.CreateIntAttr("FastColumns", 1);
            xCfg.CreateIntAttr("ExpandAllLevels", 3);
            xCfg.CreateIntAttr("GroupSortMain", 1);
            xCfg.CreateIntAttr("GroupRestoreSort", 1);
            xCfg.CreateIntAttr("NoTreeLines", 1);
            xCfg.CreateIntAttr("ShowVScroll", 1);
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
