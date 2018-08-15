using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;
using EPMLiveCore;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint.Administration;
using PortfolioEngineCore;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace CADataCache
{
    internal abstract class CADataCacheGridBase<TDetailRowData> : ADataCacheGridBase<clsPeriodData, TDetailRowData>
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

        private readonly bool _respectColumnUnselectableProperty;

        public CADataCacheGridBase(
            bool showFTEs, 
            bool useQuantity,
            bool useCost, 
            bool showCostDetailed, 
            int pmoAdmin,
            IList<CATGRow> displayList,
            IList<clsColDisp> columns,
            bool respectColumnUnselectableProperty)
        {
            _showFTEs = showFTEs;
            _useQuantity = useQuantity;
            _useCost = useCost;
            _showCostDetailed = showCostDetailed;
            _displayList = displayList;
            _columns = columns;
            _pmoAdmin = pmoAdmin;
            _respectColumnUnselectableProperty = respectColumnUnselectableProperty;
        }
        
        protected override void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            if (renderingType == GridRenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

            InitializeGridLayoutConfig();

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            var xRightCols = Constructor.CreateSubStruct("RightCols");
            PeriodCols = xRightCols;
            MiddleCols = xCols;

            Definitions = Constructor.CreateSubStruct("Def");

            DefinitionRight = InitializeGridLayoutDefinition("R", Definitions, true);
            DefinitionRight.CreateBooleanAttr("SelectCanEdit", true);
            DefinitionRight.CreateStringAttr("rowid", string.Empty);

            DefinitionLeaf = InitializeGridLayoutDefinition("Leaf", Definitions, false);

            var xHead = Constructor.CreateSubStruct("Head");
            var xFilter = xHead.CreateSubStruct("Filter");
            xFilter.CreateStringAttr("id", "Filter");

            InitializeGridLayoutHeader1(xHead, 1, 2);
            Header1.CreateIntAttr("PortfolioItemVisible", 1);
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

            InitializeGridLayoutCategoryColumns(xLeftCols);

            var xSolid = Constructor.CreateSubStruct("Solid");
            var xGroup = xSolid.CreateSubStruct("Group");

            foreach (var column in _columns)
            {
                try
                {
                    InitializeDisplayColumn(column);
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

        private void InitializeDisplayColumn(clsColDisp column)
        {
            CStruct categoryColumn;

            var realName = "zX" + CleanUpString(column.m_realname);
            var displayName = column.m_dispname.Replace("/n", "\n");

            Header1.CreateStringAttr(realName, displayName);
            Header2.CreateStringAttr(realName, GlobalConstants.Whitespace);

            categoryColumn = CreateColumn(MiddleCols, realName,
                visible: !column.m_def_fld ? false : (bool?)null,
                canEdit: false,
                canMove: true,
                canResize: null,
                canFilter: null,
                canHide: _respectColumnUnselectableProperty && column.m_unselectable ? false : (bool?)null,
                canSelect: null);
            categoryColumn.CreateStringAttr("Class", "GMCellMain");
            categoryColumn.CreateIntAttr("CanDrag", 0);
            categoryColumn.CreateIntAttr("CaseSensitive", 0);
            categoryColumn.CreateStringAttr("OnDragCell", "Focus,DragCell");
            if (column.m_col_hidden)
            {
                categoryColumn.CreateIntAttr("Width", 0);
            }
            switch (column.m_type)
            {
                case 2:
                    break;
                case 3:
                    categoryColumn.CreateStringAttr("Type", "Float");
                    categoryColumn.CreateStringAttr("Format", ",0.##");
                    break;
                default:
                    categoryColumn.CreateStringAttr("Type", "Text");
                    break;
            }

            DefinitionRight.CreateIntAttr(realName + "CanDrag", 0);
            DefinitionRight.CreateStringAttr(realName + "HtmlPrefix", "<B>");
            DefinitionRight.CreateStringAttr(realName + "HtmlPostfix", "</B>");
            DefinitionLeaf.CreateIntAttr(realName + "CanDrag", 0);
            DefinitionLeaf.CreateStringAttr(realName + "HtmlPrefix", string.Empty);
            DefinitionLeaf.CreateStringAttr(realName + "HtmlPostfix", string.Empty);

            const string sMaxFunc = "(Row.id == 'Filter' ? '' : max())";
            const string sMinFunc = "(Row.id == 'Filter' ? '' : min())";

            categoryColumn = CreateColumn(MiddleCols, "xinterenalPeriodMin", "Int",
                visible: false,
                canMove: false,
                canResize: null,
                canFilter: null
            );
            categoryColumn.CreateIntAttr("CanDrag", 0);
            DefinitionRight.CreateStringAttr("xinterenalPeriodMin" + "Formula", sMinFunc);
            DefinitionRight.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);
            DefinitionLeaf.CreateStringAttr("xinterenalPeriodMin" + "Formula", string.Empty);
            DefinitionLeaf.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);

            categoryColumn = CreateColumn(MiddleCols, "xinterenalPeriodMax", "Int",
                visible: false,
                canMove: false,
                canResize: null,
                canFilter: null
            );
            categoryColumn.CreateStringAttr("Align", "Right");
            categoryColumn.CreateIntAttr("CanDrag", 0);
            DefinitionRight.CreateStringAttr("xinterenalPeriodMax" + "Formula", sMaxFunc);
            DefinitionRight.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
            DefinitionLeaf.CreateStringAttr("xinterenalPeriodMax" + "Formula", string.Empty);
            DefinitionLeaf.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);

            categoryColumn = CreateColumn(MiddleCols, "xinterenalPeriodTotal", "Int",
                visible: false,
                canMove: false,
                canResize: null,
                canFilter: null
            );
            categoryColumn.CreateStringAttr("Align", "Right");
            categoryColumn.CreateIntAttr("CanDrag", 0);
            DefinitionLeaf.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
            DefinitionRight.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
        }

        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            if (renderingType == GridRenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

            var xBody = Constructor.CreateSubStruct("Body");
            var xB = xBody.CreateSubStruct("B");
            var xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            Level = 0;
            Levels[Level] = xI;
        }

        protected string CleanUpString(string input)
        {
            return RemoveCharacters(input, "!@#$%^&*()_+-={}[]|:;'?/~` '\r\n\"\\");
        }
        
        protected CStruct DefinePeriodColumn(string attributePrefix, string columnFormat, string definitionFormat)
        {
            var column = CreateColumn(PeriodCols, attributePrefix, "Float",
                    canMove: false,
                    canResize: null,
                    canFilter: null);

            if (columnFormat != null)
            {
                column.CreateStringAttr("Format", columnFormat);
            }

            column.CreateIntAttr("CanDrag", _pmoAdmin);
            column.CreateStringAttr("Align", "Right");

            if (_pmoAdmin != 0)
            {
                column.CreateStringAttr("OnDragCell", "Focus,DragCell");
            }

            column.CreateIntAttr("MinWidth", 45);
            column.CreateIntAttr("Width", 65);

            const string sFunc = "(Row.id == 'Filter' ? '' : sum())";
            DefinitionRight.CreateStringAttr(attributePrefix + "Formula", sFunc);
            DefinitionRight.CreateStringAttr(attributePrefix + "Format", definitionFormat);
            DefinitionRight.CreateIntAttr(attributePrefix + "CanDrag", _pmoAdmin);
            DefinitionRight.CreateStringAttr(attributePrefix + "ClassInner", string.Empty);

            DefinitionLeaf.CreateStringAttr(attributePrefix + "Formula", string.Empty);
            DefinitionLeaf.CreateIntAttr(attributePrefix + "CanDrag", _pmoAdmin);
            DefinitionLeaf.CreateStringAttr(attributePrefix + "ClassInner", string.Empty);
            return column;
        }

        protected static string GeneratePeriodAttributeName(string prefix, string periodId, int counter, string suffix = null)
        {
            return string.Join(string.Empty, prefix, periodId, "C", counter, suffix);
        }

        // (CC-76588, 2018-07-26) It's actually a copy of ModelDataCacheGridBase method, 
        // we can not unify them because they use different enums (enums fully match in keys and values, but logically they are different entities and the enum values could change)
        protected bool TryGetDataFromDetailRowDataField(clsDetailRowData detailRowData, int fid, out string value)
        {
            var result = true;
            value = null;

            switch (fid)
            {
                case (int)FieldIDs.SD_FID:
                    if (detailRowData.Det_Start != DateTime.MinValue)
                    {
                        value = detailRowData.Det_Start.ToShortDateString();
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                case (int)FieldIDs.FD_FID:
                    if (detailRowData.Det_Finish != DateTime.MinValue)
                    {
                        value = detailRowData.Det_Finish.ToShortDateString();
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                case (int)FieldIDs.FTOT_FID:
                    value = detailRowData.m_tot1.ToString();
                    break;
                case (int)FieldIDs.DTOT_FID:
                    value = detailRowData.m_tot2.ToString();
                    break;
                case (int)FieldIDs.PI_FID:
                    value = detailRowData.PI_Name;
                    break;
                case (int)FieldIDs.CT_FID:
                    value = detailRowData.CT_Name;
                    break;
                case (int)FieldIDs.SCEN_FID:
                    value = detailRowData.Scen_Name;
                    break;
                case (int)FieldIDs.BC_FID:
                    value = detailRowData.Cat_Name;
                    break;
                case (int)FieldIDs.FULLC_FID:
                    value = detailRowData.FullCatName;
                    break;
                case (int)FieldIDs.CAT_FID:
                    value = detailRowData.CC_Name;
                    break;
                case (int)FieldIDs.FULLCAT_FID:
                    value = detailRowData.FullCCName;
                    break;
                case (int)FieldIDs.BC_ROLE:
                    value = detailRowData.Role_Name;
                    break;
                case (int)FieldIDs.MC_FID:
                    value = detailRowData.MC_Name;
                    break;
                default:
                    if (fid >= 11801 && fid <= 11805)
                    {
                        value = detailRowData.Text_OCVal[fid - 11800];
                    }
                    else if (fid >= 11811 && fid <= 11815)
                    {
                        value = detailRowData.TXVal[fid - 11810];
                    }
                    else if (fid >= (int)FieldIDs.PI_USE_EXTRA + 1 && fid <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                    {
                        if (detailRowData.m_PI_Format_Extra_data != null)
                        {
                            value = detailRowData.m_PI_Format_Extra_data[fid - (int)FieldIDs.PI_USE_EXTRA];
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        value = GlobalConstants.Whitespace;
                    }
                    break;
            }

            return result;
        }
        
        protected override string ResolvePeriodId(clsPeriodData periodData, int index)
        {
            return periodData.PeriodID.ToString();
        }

        protected override void AddPeriodColumns(IEnumerable<clsPeriodData> periods)
        {
            var index = 0;
            foreach (var period in periods)
            {
                var periodId = ResolvePeriodId(period, index++);
                var periodName = period.PeriodName;

                var counter = _displayList.Where(pred => pred.bUse).Count();
                if (counter == 0)
                {
                    return;
                }

                var span = CalculatePeriodColumnsSpan(periodId, periodName, counter);

                counter = 0;
                foreach (var displayRow in _displayList)
                {
                    try
                    {
                        if (displayRow.bUse)
                        {
                            ++counter;

                            if (counter == 1)
                            {
                                if (span > 1)
                                {
                                    Header1.CreateIntAttr(GeneratePeriodAttributeName("P", periodId, counter, "Span"), span);
                                }
                                Header1.CreateStringAttr(GeneratePeriodAttributeName("P", periodId, counter), periodName);
                            }
                            else
                            {
                                Header1.CreateStringAttr(GeneratePeriodAttributeName("P", periodId, counter), GlobalConstants.Whitespace);
                            }

                            InitializePeriodDisplayRow(periodId, periodName, counter, displayRow);
                        }
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
        }

        protected abstract void InitializeGridLayoutCategoryColumns(CStruct columnsContainer);

        protected abstract int CalculatePeriodColumnsSpan(string periodId, string periodName, int counter);

        protected abstract void InitializePeriodDisplayRow(string periodId, string periodName, int counter, CATGRow displayRow);

        protected override void AddDetailRow(TDetailRowData detailRowData, int rowId)
        {
            var xI = InitializeDetailRowDataStructure(detailRowData, rowId);

            var detailRowDataItem = GetDetailRowData(detailRowData);

            foreach (var column in _columns)
            {
                var attributeName = "zX" + CleanUpString(column.m_realname);

                string value;
                if (TryGetDataFromDetailRowDataField(detailRowDataItem, column.m_id, out value))
                {
                    xI.CreateStringAttr(attributeName, value);
                }
            }

            var periodTotal = detailRowDataItem.zFTE.Length - 1;

            var periodMin = CalculateInternalPeriodMin(detailRowData);
            var periodMax = 0;
            if (periodMin != 0)
            {
                periodMax = CalculateInternalPeriodMax(detailRowData);
            }
            else
            {
                periodMin = periodTotal + 1;
            }

            xI.CreateIntAttr("xinterenalPeriodMin", periodMin);
            xI.CreateIntAttr("xinterenalPeriodMax", periodMax);
            xI.CreateIntAttr("xinterenalPeriodTotal", periodTotal);

            for (int i = 1; i <= periodTotal; i++)
            {
                UpdateDisplayRowsWithPeriodData(detailRowData, xI, i);
            }
        }

        protected abstract void UpdateDisplayRowsWithPeriodData(TDetailRowData detailRowData, CStruct xI, int i);

        protected abstract clsDetailRowData GetDetailRowData(TDetailRowData detailRowData);

        protected abstract CStruct InitializeDetailRowDataStructure(TDetailRowData detailRowData, int rowId);
    }
}
