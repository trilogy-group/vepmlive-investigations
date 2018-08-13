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
        public RPATopGrid(
            IList<clsRXDisp> columns, 
            int pmoAdmin, 
            string xmlString, 
            int displayMode, 
            IList<RPATGRow> displayList, 
            clsResourceValues resourceValues,
            clsLookupList categoryLookupList)
        : base (columns, pmoAdmin, xmlString, displayMode, displayList, resourceValues, categoryLookupList)
        {
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

            var xToolbar = Constructor.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            var xPanel = Constructor.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            var xCfg = InitializeGridLayoutConfig("PortfolioItem", 3, _pmoAdmin, 150, 800);
            xCfg.CreateIntAttr("MinMidWidth", 50);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 0);
            xCfg.CreateIntAttr("RightCanResize", 1);
            xCfg.CreateIntAttr("FocusWholeRow", 1);

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            var xRightCols = Constructor.CreateSubStruct("RightCols");
            PeriodCols = xRightCols;
            MiddleCols = xCols;

            var m_xDef = Constructor.CreateSubStruct("Def");
            DefinitionRight = InitializeGridLayoutDefinition("R", m_xDef, true);
            DefinitionLeaf = InitializeGridLayoutDefinition("Leaf", m_xDef, false);
            
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
        
        private CStruct InitializeViewColumn(
            IList<string[]> strCurrentViewCols, 
            CStruct xCols,
            CStruct categoryColumn, 
            clsRXDisp col)
        {
            try
            {
                // below code find columns which not matched with current saved view's column and that column hide on grid.

                var viewColumn = (from x in strCurrentViewCols
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
                if (viewColumn == null)
                {
                    categoryColumn.CreateIntAttr("Visible", 0);
                }

                DefinitionRight.CreateIntAttr(sn + "CanDrag", 0);
                DefinitionRight.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                DefinitionRight.CreateStringAttr(sn + "HtmlPostfix", "</B>");
                DefinitionLeaf.CreateIntAttr(sn + "CanDrag", 0);
                DefinitionLeaf.CreateStringAttr(sn + "HtmlPrefix", string.Empty);
                DefinitionLeaf.CreateStringAttr(sn + "HtmlPostfix", string.Empty);

                switch (col.m_type)
                {
                    case 2:
                        var format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        categoryColumn.CreateStringAttr("Format", format);
                        categoryColumn.CreateStringAttr("EditFormat", format);
                        switch (col.m_id)
                        {
                            case RPConstants.TGRID_SDATE:
                                const string sminFunc = "(Row.id == 'Filter' ? '' : min())";
                                categoryColumn.CreateStringAttr("Type", "Date");
                                DefinitionRight.CreateStringAttr(sn + "Formula", sminFunc);
                                break;
                            case RPConstants.TGRID_FDATE:
                                const string smaxFunc = "(Row.id == 'Filter' ? '' : max())";
                                categoryColumn.CreateStringAttr("Type", "Date");
                                DefinitionRight.CreateStringAttr(sn + "Formula", smaxFunc);
                                break;
                            default:
                                break;
                        }
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
            var categoryColumn = CreateColumn(xLeftCols, "RowSel", "Icon",
                width: 20,
                canMove: false,
                canExport: false,
                canEdit: false);
            categoryColumn.CreateStringAttr("Color", "rgb(223, 227, 232)");
            Header1.CreateStringAttr("RowSel", GlobalConstants.Whitespace);
            yield return categoryColumn;
            
            categoryColumn = CreateColumn(xLeftCols, "rowid", "Text",
                visible: false,
                canExport: false);
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "Select", "Bool",
                width: 20,
                canEdit: true,
                canMove: false);
            categoryColumn.CreateStringAttr("Class", string.Empty);
            Header1.CreateStringAttr("Select", "<img id='allSelectedTopGrid' src='/_layouts/ppm/images/checked-dark.png' />");
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "ChangedIcon", "Type",
                width: 20,
                canEdit: false,
                canMove: false,
                canExport: false);
            Header1.CreateStringAttr("ChangedIcon", GlobalConstants.Whitespace);
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "RowDraggable", "Bool",
                visible: false,
                canEdit: false,
                canMove: false);
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "RowChanged", "Int",
                visible: false,
                canEdit: false,
                canMove: false,
                canExport: false);
            yield return categoryColumn;
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
                            var prefix = "P" + periodId + "C" + count;

                            var xC = CreateColumn(
                                PeriodCols,
                                prefix,
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
                                DefinitionRight.CreateStringAttr(prefix + "Formula", sFunc);
                                
                                if (_displayMode == 1)
                                {
                                    DefinitionRight.CreateStringAttr(prefix + "Format", ",0.###");
                                }
                                else
                                {
                                    DefinitionRight.CreateStringAttr(prefix + "Format", ",0.##");
                                }
                            }

                            DefinitionLeaf.CreateStringAttr(prefix + "Formula", string.Empty);
                            DefinitionLeaf.CreateIntAttr(prefix + "CanDrag", _pmoAdmin);
                            DefinitionRight.CreateIntAttr(prefix + "CanDrag", _pmoAdmin);
                            DefinitionLeaf.CreateStringAttr(prefix + "ClassInner", string.Empty);
                            DefinitionRight.CreateStringAttr(prefix + "ClassInner", string.Empty);
                            DefinitionLeaf.CreateStringAttr(prefix + "HtmlPostfix", string.Empty);
                            DefinitionRight.CreateStringAttr(prefix + "HtmlPostfix", string.Empty);
                            DefinitionLeaf.CreateStringAttr(prefix + "HtmlPrefix", string.Empty);
                            DefinitionRight.CreateStringAttr(prefix + "HtmlPrefix", string.Empty);

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
            
            var periodMin = CalculateInternalPeriodMin(detailRowDataTuple);
            var periodMax = 0;
            if (periodMin != 0)
            {
                periodMax = CalculateInternalPeriodMax(detailRowDataTuple);
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
