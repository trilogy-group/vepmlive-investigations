using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint.Administration;
using PortfolioEngineCore;
using ResourceValues;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace RPADataCache
{
    internal class RPABottomGrid : RPADataCacheGridBase<clsResFullDAta>
    {
        private readonly bool _isLayoutByRole;
        private readonly string _roleHeader;
        private readonly bool _useHeatMap;
        private readonly int _mode;

        protected CStruct DefinitionPI;

        public RPABottomGrid(
            bool isLayoutByRole,
            string roleHeader,
            bool useHeatMap,
            IList<clsRXDisp> columns, 
            int pmoAdmin, 
            string xmlString, 
            int displayMode, 
            IList<RPATGRow> displayList, 
            clsResourceValues resourceValues, 
            clsLookupList categoryLookupList) 
        : base(columns, pmoAdmin, xmlString, displayMode, displayList, resourceValues, categoryLookupList)
        {
            _isLayoutByRole = isLayoutByRole;
            _roleHeader = roleHeader;
            _useHeatMap = useHeatMap;
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

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            var xRightCols = Constructor.CreateSubStruct("RightCols");
            PeriodCols = xRightCols;

            var m_xDef = Constructor.CreateSubStruct("Def");
            DefinitionRight = InitializeGridLayoutDefinition("R", m_xDef, true);
            DefinitionLeaf = InitializeGridLayoutDefinition("Leaf", m_xDef, false);
            DefinitionPI = InitializeGridLayoutDefinition("Leaf", m_xDef, false);

            var xHead = Constructor.CreateSubStruct("Head");
            InitializeGridLayoutHeader1(xHead, 1, 2);

            var categoryColumn = InitializeGridLayoutCategoryColumns(xLeftCols).Last();
            DefinitionRight.CreateBooleanAttr("rtSelectCanEdit", true);
            DefinitionLeaf.CreateStringAttr("IconFlag", "/_layouts/ppm/images/Nogif.gif");

            var xSolid = Constructor.CreateSubStruct("Solid");
            var xGroup = xSolid.CreateSubStruct("Group");

            foreach (var column in _columns)
            {
                categoryColumn = InitializeViewColumn(xCols, categoryColumn, column);
            }
        }

        private IEnumerable<CStruct> InitializeGridLayoutCategoryColumns(CStruct xLeftCols)
        {
            var categoryColumn = CreateColumn(xLeftCols, "RowSel", "Icon",
                width: 20,
                canMove: false,
                canExport: false,
                canEdit: false,
                canHide: null,
                canSelect: null);
            categoryColumn.CreateStringAttr("Color", "rgb(223, 227, 232)");
            Header1.CreateStringAttr("RowSel", GlobalConstants.Whitespace);
            Header2.CreateStringAttr("RowSel", GlobalConstants.Whitespace);
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "rowid", "Int",
                visible: false,
                canExport: false);
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "IconFlag", "Icon",
                width: 20,
                visible: true,
                canMove: false);
            Header1.CreateStringAttr("IconFlag", GlobalConstants.Whitespace);
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "rtSelect", "Bool",
                width: 20,
                visible: true,
                canEdit: true,
                canMove: false);
            categoryColumn.CreateStringAttr("Class", string.Empty);
            Header1.CreateString("rtSelect", GlobalConstants.Whitespace);
            Header2.CreateString("rtSelect", GlobalConstants.Whitespace);
            yield return categoryColumn;
        }

        private CStruct InitializeViewColumn(CStruct xCols, CStruct categoryColumn, clsRXDisp col)
        {
            try
            {
                if (col.m_id == RPConstants.TGRID_TOTITEM_ID
                    || col.m_id == RPConstants.TGRID_TOTRESRES_ID
                    || _isLayoutByRole == false)
                {
                    var sn = RemoveCharacters(col.m_realname, " \r\n")
                        .Replace("/n", string.Empty);

                    var snv = col.m_dispname.Replace("/n", "\n");

                    if (col.m_id == RPConstants.TGRID_TOTRESRES_ID)
                    {
                        snv = _roleHeader;
                        sn = "ResOrRole";
                    }

                    categoryColumn = xCols.CreateSubStruct("C");
                    if (col.m_id > 100)
                    {
                        sn = "x" + sn;
                    }
                    categoryColumn.CreateStringAttr("Name", sn);
                    categoryColumn.CreateIntAttr("ShowHint", 0);
                    categoryColumn.CreateStringAttr("Class", "GMCellMain");

                    DefinitionRight.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                    DefinitionRight.CreateStringAttr(sn + "HtmlPostfix", "</B>");
                    DefinitionLeaf.CreateStringAttr(sn + "HtmlPrefix", string.Empty);
                    DefinitionLeaf.CreateStringAttr(sn + "HtmlPostfix", string.Empty);
                    DefinitionPI.CreateStringAttr(sn + "HtmlPrefix", string.Empty);
                    DefinitionPI.CreateStringAttr(sn + "HtmlPostfix", string.Empty);

                    switch (col.m_type)
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

                    if (sn.Equals(RPConstants.CONST_PRIORITY))
                    {
                        categoryColumn.CreateStringAttr("NumberSort", "1");
                    }

                    categoryColumn.CreateIntAttr("CanEdit", 0);
                    categoryColumn.CreateIntAttr("CanMove", 1);
                    categoryColumn.CreateIntAttr("CanSort", 1);
                    categoryColumn.CreateIntAttr("CaseSensitive", 0);

                    if (col.m_col_hidden == true)
                    {
                        categoryColumn.CreateIntAttr("Width", 0);
                    }

                    Header1.CreateStringAttr(sn, snv);
                    Header1.CreateIntAttr(sn + "SortIcons", 1);
                    Header2.CreateStringAttr(sn, GlobalConstants.Whitespace);
                }
            }
            catch (Exception ex)
            {
                WriteTrace(
                    Area.EPMLiveWorkEnginePPM,
                    Categories.EPMLiveWorkEnginePPM.Others,
                    TraceSeverity.VerboseEx,
                    ex.ToString());
            }

            return categoryColumn;
        }

        protected override string ResolvePeriodId(CPeriod periodData, int index)
        {
            return periodData.PeriodID.ToString();
        }

        protected override void AddPeriodColumns(IEnumerable<CPeriod> periods)
        {
            var index = 0;
            foreach (var period in periods)
            {
                var periodId = ResolvePeriodId(period, index++);
                var periodName = period.PeriodName;

                const string sumFunc = "(Row.id == 'Filter' ? '' : sum())";
                const string maxFunc = "(Row.id == 'Filter' ? '' : max())";
                const string minFunc = "(Row.id == 'Filter' ? '' : min())";

                var span = _displayList.Count;
                if (_useHeatMap)
                {
                    InitializePeriodHeatMapColumn(periodId, periodName, _mode != 3, sumFunc);
                    span *= 2;
                }

                var counter = 0;
                foreach (var displayRow in _displayList)
                {
                    try
                    {
                        counter++;
                        var prefix = $"P{periodId}C{counter}";
                        if (counter == 1)
                        {
                            if (_displayList.Count > 1)
                            {
                                Header1.CreateIntAttr($"P{periodId}C1Span", span);
                            }

                            Header1.CreateStringAttr(prefix, periodName);

                            var xC = CreateColumn(
                                PeriodCols,
                                prefix,
                                "Float",
                                canMove: false,
                                canResize: null,
                                canFilter: null);
                            xC.CreateStringAttr("Format", ",0.##");
                            xC.CreateStringAttr("Align", "Right");

                            if (_useHeatMap)
                            {
                                Header1.CreateStringAttr($"X{periodId}C{counter}", GlobalConstants.Whitespace);
                                Header1.CreateStringAttr($"Y{periodId}C{counter}", GlobalConstants.Whitespace);
                                Header2.CreateStringAttr($"X{periodId}C{counter}", periodName + displayRow.Name + "HeatMap");
                                Header2.CreateStringAttr($"Y{periodId}C{counter}", periodName + displayRow.Name + "HeatMap");

                                xC = CreateColumn(
                                    PeriodCols,
                                    $"X{periodId}C{counter}",
                                    "Float",
                                    visible: false,
                                    canMove: false,
                                    canResize: null,
                                    canFilter: null);
                                xC.CreateStringAttr("Format", ",0.##");
                                xC.CreateStringAttr("Align", "Right");
                                
                                xC = CreateColumn(
                                    PeriodCols,
                                    $"Y{periodId}C{counter}",
                                    "Float",
                                    visible: false,
                                    canMove: false,
                                    canResize: null,
                                    canFilter: null);
                                xC.CreateStringAttr("Format", ",0.##");
                                xC.CreateStringAttr("Align", "Right");
                            }

                            if (_mode != 3)
                            {
                                if (_useHeatMap)
                                {
                                    DefinitionRight.CreateStringAttr($"X{periodId}C{counter}Format", "##");
                                    DefinitionRight.CreateStringAttr($"X{periodId}C{counter}Formula", maxFunc);
                                    DefinitionRight.CreateStringAttr($"Y{periodId}C{counter}Format", "##");
                                    DefinitionRight.CreateStringAttr($"Y{periodId}C{counter}Formula", minFunc);
                                }

                                DefinitionRight.CreateStringAttr($"P{periodId}C{counter}Format", "##");
                                DefinitionRight.CreateStringAttr($"P{periodId}C{counter}Formula", sumFunc);
                            }

                            if (_useHeatMap)
                            {
                                DefinitionLeaf.CreateStringAttr($"X{periodId}C{counter}Formula", string.Empty);
                                DefinitionLeaf.CreateStringAttr($"Y{periodId}C{counter}Formula", string.Empty);
                                DefinitionPI.CreateStringAttr($"X{periodId}C{counter}Formula", string.Empty);
                                DefinitionPI.CreateStringAttr($"Y{periodId}C{counter}Formula", string.Empty);
                            }

                            DefinitionLeaf.CreateStringAttr($"P{periodId}C{counter}Formula", string.Empty);
                            DefinitionPI.CreateStringAttr($"P{periodId}C{counter}Formula", string.Empty);

                            xC.CreateIntAttr("MinWidth", 45);
                            xC.CreateIntAttr("Width", 65);
                        }
                        else
                        {
                            Header1.CreateStringAttr(prefix, GlobalConstants.Whitespace);
                        }

                        Header2.CreateStringAttr(prefix, displayRow.Name);
                        Header2.CreateStringAttr(prefix + "SortIcons", "0");
                    }
                    catch (Exception ex)
                    {
                        WriteTrace(
                          Area.EPMLiveWorkEnginePPM,
                          Categories.EPMLiveWorkEnginePPM.Others,
                          TraceSeverity.VerboseEx,
                          ex.ToString());
                    }
                }
            }
        }

        protected override bool CheckIfDetailRowShouldBeAdded(clsResFullDAta detailRow)
        {
            throw new NotImplementedException();
        }

        protected override void AddDetailRow(clsResFullDAta detailRowData, int rowId)
        {
            throw new NotImplementedException();
        }

        protected override int CalculateInternalPeriodMin(clsResFullDAta resxData)
        {
            throw new NotImplementedException();
        }

        protected override int CalculateInternalPeriodMax(clsResFullDAta resxData)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }
    }
}
