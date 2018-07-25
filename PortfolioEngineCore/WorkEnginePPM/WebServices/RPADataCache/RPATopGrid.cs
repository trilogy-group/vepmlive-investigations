using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EPMLiveCore;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint.Administration;
using ModelDataCache;
using PortfolioEngineCore;
using ResourceValues;
using WorkEnginePPM;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace RPADataCache
{
    internal class RPATopGrid : RPADataCacheGridBase
    {
        private readonly IList<clsRXDisp> _columns;
        private readonly int _pmoAdmin;
        private readonly string _xmlString;
        private readonly int _displayMode;
        private readonly IList<RPATGRow> _displayList;
        private readonly clsResourceValues _resourceValues;
        private readonly clsLookupList _categoryLookupList;

        private CStruct DefinitionRight;
        private CStruct DefinitionLeaf;
        private CStruct MiddleCols;

        public RPATopGrid(
            IList<clsRXDisp> columns, 
            int pmoAdmin, 
            string xmlString, 
            int displayMode, 
            IList<RPATGRow> displayList, 
            clsResourceValues resourceValues,
            clsLookupList categoryLookupList)
        {
            _columns = columns;
            _pmoAdmin = pmoAdmin;
            _xmlString = xmlString;
            _displayMode = displayMode;
            _displayList = displayList;
            _resourceValues = resourceValues;
            _categoryLookupList = categoryLookupList;
        }        

        protected override void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            if (renderingType == GridRenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

            var currentViewResult = GetResourceAnalyzerView(_xmlString);

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(currentViewResult.ToString());
            var currentViewCols = xdoc.SelectSingleNode("Result/View/g_1").Attributes["Cols"].InnerText;
            var strCurrentViewCols = currentViewCols.Split(',').Select(x => x.Split(':')).ToArray();

            InitializeGridLayoutConfig();

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            var xRightCols = Constructor.CreateSubStruct("RightCols");
            PeriodCols = xRightCols;
            MiddleCols = xCols;

            DefinitionRight = InitializeGridLayoutDefinition("R");
            DefinitionRight.CreateStringAttr("Calculated", "1");

            DefinitionLeaf = InitializeGridLayoutDefinition("Leaf");
            DefinitionLeaf.CreateStringAttr("Calculated", "0");
            
            var xHead = Constructor.CreateSubStruct("Head");
            var xFilter = xHead.CreateSubStruct("Filter");
            xFilter.CreateStringAttr("id", "Filter");

            InitializeGridLayoutHeader1(xHead, -1, 2);
            Header1.CreateIntAttr("PortfolioItemVisible", 1);
            Header1.CreateIntAttr("NoEscape", 1);

            var categoryColumn = InitializeGridLayoutCategoryColumns(xLeftCols).Last();

            DefinitionRight.CreateBooleanAttr("SelectCanEdit", true);
            DefinitionRight.CreateStringAttr("rowid", string.Empty);

            var xSolid = Constructor.CreateSubStruct("Solid");
            var xGroup = xSolid.CreateSubStruct("Group");

            foreach (clsRXDisp col in _columns)
            {
                if (col.m_id != RPConstants.TGRID_GRP_ID)
                {
                    categoryColumn = InitializeViewColumn(strCurrentViewCols, xCols, categoryColumn, col);
                }
            }
        }

        private CStruct InitializeGridLayoutConfig()
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
            xCfg.CreateStringAttr("MainCol", "PortfolioItem");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("SuppressMessage", 3);
            xCfg.CreateIntAttr("PrintCols", 0);
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

            return xCfg;
        }

        private CStruct InitializeViewColumn(
            IList<string[]> strCurrentViewCols, 
            CStruct xCols,
            CStruct categoryColumn, 
            clsRXDisp col)
        {
            try
            {
                // below code find columns which not matched with current saved view's column and that column hide on grid.

                var SelViewCols = (from x in strCurrentViewCols
                                   where x[0].ToString() == col.m_realname.Replace(" ", string.Empty)
                                   select x[0]).FirstOrDefault();

                var sn = RemoveCharacters(col.m_realname, " \r\n")
                    .Replace("/n", string.Empty);

                var snv = col.m_dispname.Replace("/n", "\n");

                categoryColumn = xCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", sn);
                categoryColumn.CreateStringAttr("Class", "GMCellMain");
                categoryColumn.CreateIntAttr("CanDrag", 0);
                categoryColumn.CreateIntAttr("ShowHint", 0);
                categoryColumn.CreateIntAttr("CaseSensitive", 0);
                categoryColumn.CreateStringAttr("OnDragCell", "Focus,DragCell");
                if (SelViewCols == null)
                {
                    categoryColumn.CreateIntAttr("Visible", 0);
                }

                DefinitionRight.CreateIntAttr(sn + "CanDrag", 0);
                DefinitionRight.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                DefinitionRight.CreateStringAttr(sn + "HtmlPostfix", "</B>");
                DefinitionLeaf.CreateIntAttr(sn + "CanDrag", 0);
                DefinitionLeaf.CreateStringAttr(sn + "HtmlPrefix", string.Empty);
                DefinitionLeaf.CreateStringAttr(sn + "HtmlPostfix", string.Empty);

                if (col.m_type == 2)
                {
                    string format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    categoryColumn.CreateStringAttr("Format", format);
                    categoryColumn.CreateStringAttr("EditFormat", format);
                    if (col.m_id == RPConstants.TGRID_SDATE)
                    {
                        categoryColumn.CreateStringAttr("Type", "Date");

                        string sminFunc = "(Row.id == 'Filter' ? '' : min())";
                        DefinitionRight.CreateStringAttr(sn + "Formula", sminFunc);
                    }
                    else if (col.m_id == RPConstants.TGRID_FDATE)
                    {
                        categoryColumn.CreateStringAttr("Type", "Date");

                        string smaxFunc = "(Row.id == 'Filter' ? '' : max())";
                        DefinitionRight.CreateStringAttr(sn + "Formula", smaxFunc);
                    }
                }
                else if (col.m_type == 3)
                {
                    categoryColumn.CreateStringAttr("Type", "Float");
                    categoryColumn.CreateStringAttr("Format", ",0.##");
                }
                else
                {
                    categoryColumn.CreateStringAttr("Type", "Text");
                }

                if (sn.Equals(RPConstants.CONST_PRIORITY))
                {
                    categoryColumn.CreateStringAttr("NumberSort", "1");
                }

                categoryColumn.CreateIntAttr("CanEdit", 0);
                categoryColumn.CreateIntAttr("CanMove", 1);

                if (col.m_col_hidden == true)
                {
                    categoryColumn.CreateIntAttr("Width", 0);
                }
                Header1.CreateStringAttr(sn, snv);

                string sMaxFunc = "(Row.id == 'Filter' ? '' : max())";
                string sMinFunc = "(Row.id == 'Filter' ? '' : min())";

                categoryColumn = MiddleCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", "xinterenalPeriodMin");

                categoryColumn.CreateIntAttr("ShowHint", 0);
                categoryColumn.CreateStringAttr("Type", "Int");
                categoryColumn.CreateIntAttr("CanSort", 0);
                categoryColumn.CreateIntAttr("CanMove", 0);
                categoryColumn.CreateStringAttr("Align", "Right");
                categoryColumn.CreateIntAttr("Visible", 0);
                categoryColumn.CreateIntAttr("CanSelect", 0);
                categoryColumn.CreateIntAttr("CanHide", 0);
                categoryColumn.CreateIntAttr("CanDrag", 0);

                DefinitionRight.CreateStringAttr("xinterenalPeriodMin" + "Formula", sMinFunc);
                DefinitionLeaf.CreateStringAttr("xinterenalPeriodMin" + "Formula", string.Empty);
                DefinitionLeaf.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);
                DefinitionRight.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);

                categoryColumn = MiddleCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", "xinterenalPeriodMax");

                categoryColumn.CreateIntAttr("ShowHint", 0);
                categoryColumn.CreateStringAttr("Type", "Int");
                categoryColumn.CreateIntAttr("CanSort", 0);
                categoryColumn.CreateIntAttr("CanMove", 0);
                categoryColumn.CreateStringAttr("Align", "Right");
                categoryColumn.CreateIntAttr("Visible", 0);
                categoryColumn.CreateIntAttr("CanSelect", 0);
                categoryColumn.CreateIntAttr("CanHide", 0);
                categoryColumn.CreateIntAttr("CanDrag", 0);

                DefinitionRight.CreateStringAttr("xinterenalPeriodMax" + "Formula", sMaxFunc);
                DefinitionLeaf.CreateStringAttr("xinterenalPeriodMax" + "Formula", string.Empty);
                DefinitionLeaf.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                DefinitionRight.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);

                categoryColumn = MiddleCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", "xinterenalPeriodTotal");

                categoryColumn.CreateIntAttr("ShowHint", 0);
                categoryColumn.CreateStringAttr("Type", "Int");
                categoryColumn.CreateIntAttr("CanSort", 0);
                categoryColumn.CreateIntAttr("CanMove", 0);
                categoryColumn.CreateStringAttr("Align", "Right");
                categoryColumn.CreateIntAttr("Visible", 0);
                categoryColumn.CreateIntAttr("CanSelect", 0);
                categoryColumn.CreateIntAttr("CanHide", 0);
                categoryColumn.CreateIntAttr("CanDrag", 0);

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

            return categoryColumn;
        }

        private IEnumerable<CStruct> InitializeGridLayoutCategoryColumns(CStruct xLeftCols)
        {
            var categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "RowSel", "Icon",
                width: 20,
                canMove: false,
                canExport: false,
                canEdit: false);
            categoryColumn.CreateStringAttr("Color", "rgb(223, 227, 232)");
            Header1.CreateStringAttr("RowSel", GlobalConstants.Whitespace);
            yield return categoryColumn;
            
            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "rowid", "Text",
                visible: false,
                canExport: false);
            yield return categoryColumn;

            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "Select", "Bool",
                width: 20,
                canEdit: true,
                canMove: false);
            categoryColumn.CreateStringAttr("Class", string.Empty);
            Header1.CreateStringAttr("Select", "<img id='allSelectedTopGrid' src='/_layouts/ppm/images/checked-dark.png' />");
            yield return categoryColumn;

            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "ChangedIcon", "Type",
                width: 20,
                canEdit: false,
                canMove: false,
                canExport: false);
            Header1.CreateStringAttr("ChangedIcon", GlobalConstants.Whitespace);
            yield return categoryColumn;

            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "RowDraggable", "Bool",
                visible: false,
                canEdit: false,
                canMove: false);
            yield return categoryColumn;

            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "RowChanged", "Int",
                visible: false,
                canEdit: false,
                canMove: false,
                canExport: false);
            yield return categoryColumn;
        }

        private CStruct InitializeGridLayoutCategoryColumn(
            CStruct xLeftCols,
            string name,
            string type,
            bool? visible = null,
            int? width = null,
            bool? canEdit = null,
            bool? canMove = null,
            bool? canExport = null,
            bool canResize = false,
            bool canFilter = false,
            bool showHint = false,
            bool canSort = false,
            bool canHide = false,
            bool canSelect = false)
        {
            var categoryColumn = xLeftCols.CreateSubStruct("C");
            categoryColumn.CreateStringAttr("Name", name);
            categoryColumn.CreateStringAttr("Type", type);

            if (visible != null)
            {
                categoryColumn.CreateIntAttr("Visible", visible.Value ? 1 : 0);
            }
            if (width != null)
            {
                categoryColumn.CreateStringAttr("Width", width.ToString());
            }
            if (canEdit != null)
            {
                categoryColumn.CreateBooleanAttr("CanEdit", canEdit.Value);
            }
            if (canMove != null)
            {
                categoryColumn.CreateIntAttr("CanMove", canMove.Value ? 1 : 0);
            }
            if (canExport != null)
            {
                categoryColumn.CreateIntAttr("CanExport", canExport.Value ? 1 : 0);
            }
            categoryColumn.CreateIntAttr("CanResize", canResize ? 1 : 0);
            categoryColumn.CreateIntAttr("CanFilter", canFilter ? 1 : 0);
            categoryColumn.CreateIntAttr("ShowHint", showHint ? 1 : 0);
            categoryColumn.CreateIntAttr("CanSort", canSort ? 1 : 0);
            categoryColumn.CreateIntAttr("CanHide", canHide ? 1 : 0);
            categoryColumn.CreateIntAttr("CanSelect", canSelect ? 1 : 0);

            return categoryColumn;
        }

        protected override string ResolvePeriodId(CPeriod periodData, int index)
        {
            return periodData.PeriodID.ToString();
        }

        protected override void AddPeriodColumns(IEnumerable<CPeriod> periods)
        {
            var i = 0;
            foreach (var period in periods)
            {
                var count = 0;
                var periodId = ResolvePeriodId(period, i++);
                var periodName = RPAData.GetPeriodName(period.PeriodName, _displayMode);

                foreach (var displayRow in _displayList)
                {
                    if (displayRow.bUse)
                        ++count;
                }

                if (count == 0)
                {
                    return;
                }

                Header1.CreateStringAttr("P" + periodId + "C1", periodName);

                count = 0;

                foreach (var displayRow in _displayList)
                {
                    try
                    {
                        if (displayRow.bUse)
                        {
                            ++count;

                            var xC = InitializeGridLayoutCategoryColumn(
                                PeriodCols,
                                "P" + periodId + "C" + count.ToString(),
                                "Float",
                                canMove: false);

                            xC.CreateIntAttr("CanDrag", _pmoAdmin);

                            if (_displayMode == 1)
                            {
                                xC.CreateStringAttr("Format", ",0.###");
                            }
                            else
                            {
                                xC.CreateStringAttr("Format", ",0.##");
                            }

                            if (_pmoAdmin != 0)
                            {
                                xC.CreateStringAttr("OnDragCell", "Focus,DragCell");
                            }

                            xC.CreateStringAttr("Align", "Right");

                            if (_displayMode != 3)
                            {
                                var sFunc = "(Row.id == 'Filter' ? '' : sum())";
                                DefinitionRight.CreateStringAttr("P" + periodId + "C" + count.ToString() + "Formula", sFunc);
                                
                                if (_displayMode == 1)
                                {
                                    DefinitionRight.CreateStringAttr("P" + periodId + "C" + count.ToString() + "Format", ",0.###");
                                }
                                else
                                {
                                    DefinitionRight.CreateStringAttr("P" + periodId + "C" + count.ToString() + "Format", ",0.##");
                                }
                            }

                            DefinitionLeaf.CreateStringAttr("P" + periodId + "C" + count.ToString() + "Formula", string.Empty);
                            DefinitionLeaf.CreateIntAttr("P" + periodId + "C" + count.ToString() + "CanDrag", _pmoAdmin);
                            DefinitionRight.CreateIntAttr("P" + periodId + "C" + count.ToString() + "CanDrag", _pmoAdmin);
                            DefinitionLeaf.CreateStringAttr("P" + periodId + "C" + count.ToString() + "ClassInner", string.Empty);
                            DefinitionRight.CreateStringAttr("P" + periodId + "C" + count.ToString() + "ClassInner", string.Empty);
                            DefinitionLeaf.CreateStringAttr("P" + periodId + "C" + count.ToString() + "HtmlPostfix", string.Empty);
                            DefinitionRight.CreateStringAttr("P" + periodId + "C" + count.ToString() + "HtmlPostfix", string.Empty);
                            DefinitionLeaf.CreateStringAttr("P" + periodId + "C" + count.ToString() + "HtmlPrefix", string.Empty);
                            DefinitionRight.CreateStringAttr("P" + periodId + "C" + count.ToString() + "HtmlPrefix", string.Empty);

                            xC.CreateIntAttr("MinWidth", 45);
                            xC.CreateIntAttr("Width", 65);
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
        
        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            var xBody = Constructor.CreateSubStruct("Body");
            var xB = xBody.CreateSubStruct("B");
            var xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            Level = 0;
            Levels[Level] = xI;
        }

        protected override bool CheckIfDetailRowShouldBeAdded(Tuple<clsResXData, clsPIData> detailRow)
        {
            return true;
        }

        protected override void AddDetailRow(Tuple<clsResXData, clsPIData> detailRowDataTuple, int rowId)
        {
            var resxData = detailRowDataTuple.Item1;
            var piData = detailRowDataTuple.Item2;

            var xIParent = Levels[0];
            var xI = xIParent.CreateSubStruct("I");
            clsResCap oRCap;
            clsCatItem oc;

            Levels[1] = xI;
            xI.CreateStringAttr("id", rowId.ToString());
            xI.CreateStringAttr("Color", "white");
            xI.CreateStringAttr("Def", "Leaf");
            xI.CreateIntAttr("NoColorState", 1);
            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateStringAttr("Select", (resxData.bTotalize ? "1" : "0"));
            xI.CreateStringAttr("RowDraggable", (resxData.bDraggable ? "1" : "0"));
            xI.CreateIntAttr("RowChanged", resxData.iDragCnt);
            xI.CreateStringAttr("ChangedIcon", (resxData.iDragCnt == 0 ? "/_layouts/ppm/images/Nogif.gif" : "/_layouts/ppm/images/Approve.gif"));
            xI.CreateBooleanAttr("SelectCanEdit", true);
            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateStringAttr("rowid", "r" + resxData.rowid);
            xI.CreateBooleanAttr("rowidCanEdit", false);

            ProcessDetailRowColumns(resxData, piData, xI);

            var counter = 0;
            foreach (var displayRow in _displayList)
            {
                if (displayRow.bUse)
                {
                    ++counter;
                }
            }

            if (counter == 0)
            {
                return;
            }
            
            var periodMin = CalculateInternalPeriodMin(resxData);
            var periodMax = 0;
            if (periodMin != 0)
            {
                periodMax = CalculateInternalPeriodMax(resxData);
            }

            xI.CreateIntAttr("xinterenalPeriodMin", periodMin);
            xI.CreateIntAttr("xinterenalPeriodMax", periodMax);
            xI.CreateIntAttr("xinterenalPeriodTotal", _resourceValues.Periods.Values.Count());

            var i = 0;
            foreach (var period in _resourceValues.Periods.Values)
            {
                try
                {
                    ProcessDetailDataRowPeriod(period, ++i, resxData, xI);
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

        private void ProcessDetailDataRowPeriod(CPeriod period, int i, clsResXData resxData, CStruct xI)
        {
            string cellval;
            string name;
            var counter = 0;

            foreach (var displayRow in _displayList)
            {
                if (displayRow.bUse)
                {
                    ++counter;
                    name = "P" + period.PeriodID.ToString() + "C" + counter.ToString();
                    var value = GetDetailRowValue(resxData, displayRow.fid, i);

                    cellval = string.Empty;

                    if (value != 0)
                    {
                        switch (_displayMode)
                        {
                            case 0:
                                cellval = value.ToString("0.##");
                                break;
                            case 2:
                            default:
                                cellval = value.ToString("0.###");
                                break;
                        }
                    }

                    if (cellval != string.Empty)
                    {
                        xI.CreateStringAttr(name, cellval);
                    }

                    xI.CreateStringAttr(name + "ClassInner", string.Empty);
                    xI.CreateStringAttr(name + "HtmlPostfix", string.Empty);
                    xI.CreateStringAttr(name + "HtmlPrefix", string.Empty);
                }
            }
        }

        private int CalculateInternalPeriodMax(clsResXData resxData)
        {
            for (int i = _resourceValues.Periods.Values.Count(); i > 1; i--)
            {
                foreach (var displayRow in _displayList)
                {
                    if (displayRow.bUse)
                    {
                        var value = GetDetailRowValue(resxData, displayRow.fid, i);

                        if (value != 0)
                        {
                            return i;
                        }
                    }
                }
            }

            return 0;
        }

        private int CalculateInternalPeriodMin(clsResXData resxData)
        {
            var i = 0;
            var fp = 0;
            foreach (var period in _resourceValues.Periods.Values)
            {
                ++i;
                foreach (var displayRow in _displayList)
                {
                    if (displayRow.bUse)
                    {
                        var value = GetDetailRowValue(resxData, displayRow.fid, i);

                        if (value != 0)
                        {
                            fp = i;
                            break;
                        }
                    }
                }

                if (fp != 0)
                {
                    break;
                }
            }

            return fp;
        }

        private void ProcessDetailRowColumns(clsResXData resxData, clsPIData piData, CStruct xI)
        {
            clsEPKItem oItem;
            clsListItem oListItem;

            foreach (var column in _columns)
            {
                try
                {
                    var sn = RemoveCharacters(column.m_realname, " \r\n")
                        .Replace("/n", string.Empty);

                    if (!TryProcessCostCategoryColumn(column, sn, resxData, xI)
                        && !TryProcessCostRealoneColumn(column, sn, resxData, xI)
                        && !TryProcessCostPIDataColumn(column, sn, piData, xI))
                    {
                        switch (column.m_id)
                        {
                            case RPConstants.TGRID_GRP_ID:
                                break;
                            case RPConstants.TGRID_DEPT_ID:
                                if (_resourceValues.Departments != null
                                    && _resourceValues.Departments.TryGetValue(resxData.DeptUID, out oItem)
                                    && resxData.bRealone)
                                {
                                    xI.CreateStringAttr(sn, oItem.Name);
                                }
                                break;
                            case RPConstants.TGRID_ROLE_ID:
                                if (_resourceValues.Roles != null
                                    && _resourceValues.Roles.TryGetValue(resxData.RoleUID, out oListItem)
                                    && resxData.bRealone)
                                {
                                    xI.CreateStringAttr(sn, oListItem.Name);
                                }
                                break;
                            case RPConstants.TGRID_CRATE:
                                if (resxData.cRate != 0 && resxData.bRealone)
                                {
                                    xI.CreateDoubleAttr(sn, resxData.cRate);
                                }
                                else
                                {
                                    xI.CreateStringAttr(sn, string.Empty);
                                }
                                break;
                            default:
                                ProcessOtherColumn(column, sn, resxData, xI);
                                break;
                        }
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

        private void ProcessOtherColumn(clsRXDisp column, string sn, clsResXData resxData, CStruct xI)
        {
            var j = 0;
            var sFull = string.Empty;

            if (column.m_col_hidden || !resxData.bRealone)
            {
                return;
            }

            if (_resourceValues.PlanFields != null)
            {
                foreach (clsPortField opf in _resourceValues.PlanFields)
                {
                    if (column.m_id == opf.ID)
                    {
                        RPConstants.GetCustValue(opf.ID, resxData.otherdata, out j, out sFull, _resourceValues);
                        xI.CreateStringAttr(sn, sFull);
                        break;
                    }
                }
            }

            if (_resourceValues.PIFields != null)
            {
                foreach (var opf in _resourceValues.PIFields)
                {
                    if (column.m_id == opf.ID)
                    {
                        RPConstants.GetCustValue(opf.ID, resxData.PIotherdata, out j, out sFull, _resourceValues);
                        xI.CreateStringAttr(sn, sFull);
                        break;
                    }
                }
            }

            if (_resourceValues.ResFields != null)
            {
                foreach (var opf in _resourceValues.ResFields)
                {
                    if (column.m_id == opf.ID)
                    {
                        RPConstants.GetCustValue(opf.ID, resxData.Resotherdata, out j, out sFull, _resourceValues);
                        xI.CreateStringAttr(sn, sFull);
                        break;
                    }
                }
            }
        }

        private bool TryProcessCostPIDataColumn(clsRXDisp column, string sn, clsPIData piData, CStruct xI)
        {
            Func<string> valueFunc = null;
            switch (column.m_id)
            {
                case RPConstants.TGRID_ITEM_ID:
                    valueFunc = () => piData.PIName;
                    break;
                case RPConstants.TGRID_SDATE:
                    if (piData != null && piData.start != DateTime.MinValue)
                    {
                        valueFunc = () => piData.start.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    break;
                case RPConstants.TGRID_FDATE:
                    if (piData != null && piData.finish != DateTime.MinValue)
                    {
                        valueFunc = () => piData.finish.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    break;
                case RPConstants.TGRID_OWNER:
                    valueFunc = () => piData.ItemManager;
                    break;
                case RPConstants.TGRID_STAGE:
                    valueFunc = () => piData.Stage;
                    break;
                case RPConstants.TGRID_STAGE_OWNER:
                    valueFunc = () => piData.StageOwner;
                    break;
                default:
                    return false;
            }

            if (valueFunc != null)
            {
                if (piData != null)
                {
                    xI.CreateStringAttr(sn, valueFunc());
                }
            }

            return true;
        }

        private bool TryProcessCostRealoneColumn(clsRXDisp column, string sn, clsResXData resxData, CStruct xI)
        {
            Func<string> valueFunc = null;
            switch (column.m_id)
            {
                case RPConstants.TGRID_RES_ID:
                    valueFunc = () =>
                    {
                        clsResCap resourceCap;
                        return _resourceValues.Resources.TryGetValue(resxData.WResID, out resourceCap)
                            ? resourceCap.Name
                            : "Unassigned";
                    };
                    break;
                case RPConstants.TGRID_GENERIC:
                    valueFunc = () =>
                    {
                        clsResCap resourceCap;
                        return _resourceValues.Resources.TryGetValue(resxData.WResID, out resourceCap)
                            ? (resourceCap.IsGeneric ? "Yes" : "No")
                            : GlobalConstants.Whitespace;
                    };
                    break;
                case RPConstants.TGRID_STAT_ID:
                    valueFunc = () => GetStatusText(resxData.Status);
                    break;
                case RPConstants.TGRID_PLANID:
                    valueFunc = () => resxData.PlanID;
                    break;
                case RPConstants.TGRID_PLANGRP:
                    valueFunc = () => resxData.PlanGroup;
                    break;
                case RPConstants.TGRID_PRIORITY:
                    valueFunc = () => resxData.Priority;
                    break;
                case RPConstants.TGRID_MAJCAT:
                    valueFunc = () => resxData.majorcat;
                    break;
                case RPConstants.TGRID_CSDATE:
                    if (resxData.cSDate != DateTime.MinValue)
                    {
                        valueFunc = () => resxData.cSDate.ToShortDateString();
                    }
                    break;
                case RPConstants.TGRID_CFDATE:
                    if (resxData.cFDate != DateTime.MinValue)
                    {
                        valueFunc = () => resxData.cFDate.ToShortDateString();
                    }
                    break;
                case RPConstants.TGRID_CCOST:
                    if (resxData.cCost != 0)
                    {
                        xI.CreateDoubleAttr(sn, resxData.cCost);
                        return true;
                    }
                    break;
                case RPConstants.TGRID_CRTYPE:
                    if (resxData.cRateType != string.Empty)
                    {
                        valueFunc = () => resxData.cRateType;
                    }
                    break;
                default:
                    return false;
            }

            if (valueFunc != null)
            {
                if (resxData.bRealone)
                {
                    xI.CreateStringAttr(sn, valueFunc());
                }
            }

            return true;
        }

        private bool TryProcessCostCategoryColumn(clsRXDisp column, string sn, clsResXData resxData, CStruct xI)
        {
            Func<clsCatItem, string> valueFunc = null;
            switch (column.m_id)
            {
                case RPConstants.TGRID_CC_ID:
                case RPConstants.TGRID_CCROLE_ID:
                    valueFunc = item => item.Name;
                    break;
                case RPConstants.TGRID_CCFULL_ID:
                case RPConstants.TGRID_CCROLEFULL_ID:
                case RPConstants.TGRID_FROLL:
                    valueFunc = item => item.FullName;
                    break;
                default:
                    return false;
            }

            if (valueFunc != null)
            {
                clsCatItem item;
                if (_resourceValues.CostCategories != null
                    && _resourceValues.CostCategories.TryGetValue(resxData.CostCat, out item)
                    && resxData.bRealone)
                {
                    xI.CreateStringAttr(sn, valueFunc(item));
                }
            }

            return true;
        }

        protected virtual string GetResourceAnalyzerView(string sXML)
        {
            string basePath;
            string ppmId;
            string ppmCompany;
            string ppmDbConn;
            string username;
            SecurityLevels securityLevel;

            string sReply = string.Empty;

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            var rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            try
            {
                var xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("GetResourceAnalyzerView", 99999, "Invalid request xml");
                }
                var viewNode = xExecute.GetXMLNode();
                var viewGuid = viewNode.SelectSingleNode("View").Attributes["ViewGUID"].InnerText;
                var guidView = Guid.Parse(viewGuid);

                string sViewsXML;
                if (rpa.GetResourceAnalyzerViewXML(guidView, out sViewsXML) == false)
                {
                    sReply = HandleError("GetResourceAnalyzerView", rpa.Status, rpa.FormatErrorText());
                }
                else
                {
                    var xResult = BuildResultXML("GetResourceAnalyzerView", 0);
                    xResult.AppendXML(sViewsXML);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetResourceAnalyzerViews", 99999, ex, string.Empty);

                LoggingService.WriteTrace(
                    Area.EPMLiveWorkEnginePPM,
                    Categories.EPMLiveWorkEnginePPM.Others,
                    TraceSeverity.VerboseEx,
                    ex.ToString());
            }

            return sReply;
        }

        private string HandleError(string sContext, int nStatus, string sError)
        {
            var xResult = BuildResultXML(sContext, nStatus);
            var xError = xResult.CreateSubStruct("Error");
            xError.CreateIntAttr("ID", 100);
            xError.CreateStringAttr("Value", sError);
            return xResult.XML();
        }

        private CStruct BuildResultXML(string sContext = null, int nStatus = 0)
        {
            var xResult = new CStruct();
            xResult.Initialize("Result");
            xResult.CreateStringAttr("Context", sContext ?? string.Empty);
            xResult.CreateIntAttr("Status", nStatus);
            return xResult;
        }

        private string HandleException(string sContext, int nStatus, Exception ex, string sStage)
        {
            return HandleError(sContext, nStatus, "Exception in RPAGrids.cs (" + sStage + "): '" + ex.Message.ToString() + "'");
        }

        private double GetDetailRowValue(clsResXData detailRowData, int fieldId, int i)
        {
            double result = 0;

            if (fieldId == 0)
            {
                switch (_displayMode)
                {
                    case 3:
                        try
                        {
                            if (detailRowData.getftarr(i) == 0)
                            {
                                result = 0;
                            }
                            else
                            {
                                result = detailRowData.getvarr(i) * 100;
                                result /= detailRowData.getftarr(i);
                                result = (int)result;
                            }
                        }
                        catch(Exception ex)
                        {
                            result = 0;

                            LoggingService.WriteTrace(
                                Area.EPMLiveWorkEnginePPM,
                                Categories.EPMLiveWorkEnginePPM.Others,
                                TraceSeverity.VerboseEx,
                                ex.ToString());
                        }
                        break;
                    case 0:
                        result = detailRowData.getvarr(i);
                        break;
                    default:
                        result = detailRowData.getftarr(i);
                        break;
                }
            }

            if (fieldId == 1)
            {
                if (detailRowData.bRealone)
                {
                    result = _displayMode == 0
                        ? detailRowData.getvarr(i)
                        : detailRowData.getftarr(i);
                }
            }

            if (_displayMode == 1)
            {
                result /= 100;
            }

            return result;
        }

        private string GetStatusText(int stat)
        {
            switch (stat)
            {
                case RPConstants.CONST_Commitment:
                    return RPConstants.CONST_text_Commitment;
                case RPConstants.CONST_REQUEST:
                    return RPConstants.CONST_text_Request;
                case RPConstants.CONST_NW:
                    return RPConstants.CONST_text_NW;
                case RPConstants.CONST_MSPF:
                    return RPConstants.CONST_text_MSPF;
                case RPConstants.CONST_REQUIRE:
                    return RPConstants.CONST_text_Request;
                case RPConstants.CONST_OPENREQUEST:
                    return RPConstants.CONST_text_OpenRequire;
                case RPConstants.CONST_ACTUALWORK:
                    return RPConstants.CONST_text_ACTUALWORK;
            }

            return "Unknown";
        }
    }
}
