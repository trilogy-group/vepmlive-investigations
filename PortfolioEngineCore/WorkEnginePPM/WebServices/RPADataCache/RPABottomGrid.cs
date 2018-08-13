using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CostDataValues;
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
        private readonly int _heatFieldColor;
        private readonly int _mode;
        private readonly bool _useHeatMap;
        private readonly int _heatMapId;
        private readonly int _heatMapColor;
        private readonly IList<clsViewTargetColours> _targetColors;
        private readonly bool _doZeroRowCleverStuff;
        private readonly NumberFormatInfo _numberFormat = new NumberFormatInfo
        {
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ",",
            NumberGroupSizes = new int[] { 3 }
        };
        
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
            if (_doZeroRowCleverStuff)
            {
                if (_displayList.Count != 0)
                {
                    for (var i = 0; i < Periods.Count; i++)
                    {
                        try
                        {
                            foreach (var displayRow in _displayList)
                            {
                                if (GetDataValue(detailRow, displayRow.fid, _mode,  i, false, _useHeatMap ? _heatMapId : 0) != 0)
                                {
                                    return true;
                                }
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
                    }
                }

                return false;
            }

            return true;
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

        private double GetDataValue(clsResFullDAta oDet, int fid, int iMode, int i, bool bForHeatmap, int iHeatmapID)
        {
            double retval = 0;
            double vval = 0;
            double fval = 0;

            if (fid == 0)
            {
                vval = oDet.tot_Totals.getvarr(i);
                fval = oDet.tot_Totals.getftarr(i);
            }
            else if (fid == -1)
            {
                vval = oDet.tot_actual.getvarr(i);
                fval = oDet.tot_actual.getftarr(i);
            }
            else if (fid == -2)
            {
                vval = oDet.tot_proposal.getvarr(i);
                fval = oDet.tot_proposal.getftarr(i);
            }
            else if (fid == -3)
            {
                vval = oDet.tot_scheduled.getvarr(i);
                fval = oDet.tot_scheduled.getftarr(i);
            }
            else if (fid == -4)
            {
                vval = oDet.tot_committed.getvarr(i);
                fval = oDet.tot_committed.getftarr(i);
            }
            else if (fid == -5)
            {
                vval = oDet.tot_personel.getvarr(i);
                fval = oDet.tot_personel.getftarr(i);
            }
            else if (fid == -6)
            {
                vval = oDet.tot_avail.getvarr(i);
                fval = oDet.tot_avail.getftarr(i);
            }
            else if (fid == -7)
            {
                if (bForHeatmap)
                {
                    vval = oDet.tot_Totals.getvarr(i);
                    fval = oDet.tot_Totals.getftarr(i);
                }
                else
                {
                    vval = oDet.tot_avail.getvarr(i) - oDet.tot_Totals.getvarr(i);
                    fval = oDet.tot_avail.getftarr(i) - oDet.tot_Totals.getftarr(i);
                }
            }
            else if (fid == -8)
            {
                if (iHeatmapID == 0 || iHeatmapID > oDet.CapScen.Count)
                {
                    vval = -oDet.tot_Totals.getvarr(i);
                    fval = -oDet.tot_Totals.getftarr(i);
                }
                else if (iHeatmapID <= -1 && iHeatmapID >= -6)
                {
                    if (iHeatmapID == -1)
                    {
                        vval = oDet.tot_actual.getvarr(i);
                        fval = oDet.tot_actual.getftarr(i);
                    }
                    else if (iHeatmapID == -2)
                    {
                        vval = oDet.tot_proposal.getvarr(i);
                        fval = oDet.tot_proposal.getftarr(i);
                    }
                    else if (iHeatmapID == -3)
                    {
                        vval = oDet.tot_scheduled.getvarr(i);
                        fval = oDet.tot_scheduled.getftarr(i);
                    }
                    else if (iHeatmapID == -4)
                    {
                        vval = oDet.tot_committed.getvarr(i);
                        fval = oDet.tot_committed.getftarr(i);
                    }
                    else if (iHeatmapID == -5)
                    {
                        vval = oDet.tot_personel.getvarr(i);
                        fval = oDet.tot_personel.getftarr(i);
                    }
                    else if (iHeatmapID == -6)
                    {
                        vval = oDet.tot_avail.getvarr(i);
                        fval = oDet.tot_avail.getftarr(i);
                    }

                    vval -= oDet.tot_Totals.getvarr(i);
                    fval -= oDet.tot_Totals.getftarr(i);
                }

                else if (bForHeatmap)
                {
                    vval = oDet.tot_Totals.getvarr(i);
                    fval = oDet.tot_Totals.getftarr(i);
                }
                else
                {
                    vval = oDet.CapScen[iHeatmapID - 1].getvarr(i) - oDet.tot_Totals.getvarr(i);
                    fval = oDet.CapScen[iHeatmapID - 1].getftarr(i) - oDet.tot_Totals.getftarr(i);
                }
            }
            else if (fid > 0 && fid <= oDet.CapScen.Count)
            {
                vval = oDet.CapScen[fid - 1].getvarr(i);
                fval = oDet.CapScen[fid - 1].getftarr(i);
            }

            if (iMode == 3)
            {
                if (fval == 0)
                    retval = 0;
                else
                    retval = (vval * 100) / fval;
            }
            else if (iMode == 0)
                retval = vval;
            else
                retval = fval;

            if (iMode == 1)
                retval /= 100;

            return retval;
        }

        private double GetPIDataValue(clsResXData oDet, int iMode, int i)
        {
            double retval = 0;
            double vval = 0;
            double fval = 0;


            vval = oDet.getvarr(i);
            fval = oDet.getftarr(i);

            if (iMode == 3)
            {
                if (fval == 0)
                    retval = 0;
                else
                    retval = (vval * 100) / fval;
            }
            else if (iMode == 0)
                retval = vval;
            else
                retval = fval;



            if (iMode == 1)
                retval /= 100;

            return retval;
        }

        private double GetPIDataValue(clsResFullDAta oFullData, clsResXData oDet, int iMode, int i, int fid, int idx, bool bUseHeatmap, int iHeatMapID, int projectId, bool byRole)
        {
            //All the calculation performd for Show Totals section is based on following link:
            //https://upland.screenstepslive.com/s/EPMLive2013/m/UserGuide/l/147531-how-do-i-use-the-total-column-feature-within-the-resource-analyzer
            double retval = 0;
            double vval = 0;
            double fval = 0;

            try
            {
                if (fid == 0)
                {
                    vval = oDet.getvarr(i);
                    fval = oDet.getftarr(i);
                }
                else if (fid == -1)
                {
                    //Actual Work equals Timesheet Actuals entered.
                    if (oFullData.actual.Count > 0)
                    {
                        idx = -1;
                        if (byRole)
                        {
                            for (int counter = 0; counter < oFullData.actual.Count; counter++)
                            {
                                if (oFullData.actual[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    vval += Convert.ToDouble(oFullData.actual[idx].WrkHours[i]);
                                    fval += Convert.ToDouble(oFullData.actual[idx].FTEVals[i]);
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                        }
                        else
                        {
                            for (int counter = 0; counter < oFullData.actual.Count; counter++)
                            {
                                if (oFullData.actual[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.actual[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.actual[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -2)
                {
                    //Proposed Work equals resource planned work that has not yet been committed.
                    if (oFullData.proposal.Count > 0)
                    {
                        idx = -1;
                        if (byRole)
                        {
                            for (int counter = 0; counter < oFullData.proposal.Count; counter++)
                            {
                                if (oFullData.proposal[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    vval += Convert.ToDouble(oFullData.proposal[idx].WrkHours[i]);
                                    fval += Convert.ToDouble(oFullData.proposal[idx].FTEVals[i]);
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                        }
                        else
                        {
                            for (int counter = 0; counter < oFullData.proposal.Count; counter++)
                            {
                                if (oFullData.proposal[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.proposal[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.proposal[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -3)
                {
                    //Scheduled Work equals the work allocation pulled in from the designated work lists, such as Task Center, Issues, Risks, etc..
                    if (byRole)
                    {
                        for (int counter = 0; counter < oFullData.scheduled.Count; counter++)
                        {
                            if (oFullData.scheduled[counter].ProjectID == projectId)
                            {
                                idx = counter;
                                vval += Convert.ToDouble(oFullData.scheduled[idx].WrkHours[i]);
                                fval += Convert.ToDouble(oFullData.scheduled[idx].FTEVals[i]);
                            }
                        }
                        if (idx == -1)
                        {
                            vval = fval = 0;
                        }
                    }
                    else
                    {
                        if (oFullData.scheduled.Count > 0)
                        {
                            idx = -1;
                            for (int counter = 0; counter < oFullData.scheduled.Count; counter++)
                            {
                                if (oFullData.scheduled[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.scheduled[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.scheduled[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -4)
                {
                    //Committed Work equals the hours in resource plans that have been committed.
                    if (byRole)
                    {
                        for (int counter = 0; counter < oFullData.committed.Count; counter++)
                        {
                            if (oFullData.committed[counter].ProjectID == projectId)
                            {
                                idx = counter;
                                vval += Convert.ToDouble(oFullData.committed[idx].WrkHours[i]);
                                fval += Convert.ToDouble(oFullData.committed[idx].FTEVals[i]);
                            }
                        }
                        if (idx == -1)
                        {
                            vval = fval = 0;
                        }
                    }
                    else
                    {
                        if (oFullData.committed.Count > 0)
                        {
                            idx = -1;
                            for (int counter = 0; counter < oFullData.committed.Count; counter++)
                            {
                                if (oFullData.committed[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.committed[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.committed[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -5)
                {
                    //Personal Time Off pulls in the hours entered into the Time Off Requests.
                    if (byRole)
                    {
                        for (int counter = 0; counter < oFullData.personel.Count; counter++)
                        {
                            if (oFullData.personel[counter].ProjectID == projectId)
                            {
                                idx = counter;
                                vval += Convert.ToDouble(oFullData.personel[idx].WrkHours[i]);
                                fval += Convert.ToDouble(oFullData.personel[idx].FTEVals[i]);
                            }
                        }
                        if (idx == -1)
                        {
                            vval = fval = 0;
                        }
                    }
                    else
                    {
                        if (oFullData.personel.Count > 0)
                        {
                            idx = -1;
                            for (int counter = 0; counter < oFullData.personel.Count; counter++)
                            {
                                if (oFullData.personel[counter].ProjectID == projectId)
                                {
                                    idx = counter;
                                    break;
                                }
                            }
                            if (idx == -1)
                            {
                                vval = fval = 0;
                            }
                            else
                            {
                                vval = Convert.ToDouble(oFullData.personel[idx].WrkHours[i]);
                                fval = Convert.ToDouble(oFullData.personel[idx].FTEVals[i]);
                            }
                        }
                    }
                }
                else if (fid == -6)
                {
                    //Availability equals the number of work hours each resource is available for each calendar period (monthly/weekly/quarterly/etc.). 
                    //It is important to note that this is resource specific based on each resource’s work hours schedule.
                    vval = oFullData.tot_avail.getvarr(i);
                    fval = oFullData.tot_avail.getftarr(i);
                }
                else if (fid == -7)
                {
                    //Remaining Availability equals Availability minus any committed and scheduled work.
                    double totWrkHrs = 0, totFTEHrs = 0;
                    double avlWrkHrs = 0, avlFTEHrs = 0;

                    if (oDet.ProjectID == projectId)
                    {
                        if (byRole)
                        {
                            avlWrkHrs = oFullData.tot_avail.getvarr(i);
                            avlFTEHrs = oFullData.tot_avail.getftarr(i);
                        }
                        else
                        {
                            if (oFullData.avail.Count > 0)
                            {
                                idx = 0;
                                for (int counter = 0; counter < oFullData.avail.Count; counter++)
                                {
                                    if (oFullData.avail[counter].ProjectID == projectId)
                                    {
                                        idx = counter;
                                        break;
                                    }
                                }
                                if (idx == -1)
                                {
                                    avlWrkHrs = avlFTEHrs = 0;
                                }
                                else
                                {
                                    avlWrkHrs = Convert.ToDouble(oFullData.avail[idx].WrkHours[i]);
                                    avlFTEHrs = Convert.ToDouble(oFullData.avail[idx].FTEVals[i]);
                                }
                            }
                        }

                        totWrkHrs = oDet.getvarr(i);
                        totFTEHrs = oDet.getftarr(i);

                        vval = avlWrkHrs - totWrkHrs;
                        fval = avlFTEHrs - totFTEHrs;
                    }
                }
                else if (fid > 0 && fid <= oFullData.CapScen.Count)
                {
                    vval = oFullData.CapScen[fid - 1].getvarr(i);
                    fval = oFullData.CapScen[fid - 1].getftarr(i);
                }

                if (iMode == 3)
                {
                    if (fval == 0)
                        retval = 0;
                    else
                        retval = (vval * 100) / fval;
                }
                else if (iMode == 0)
                    retval = vval;
                else
                    retval = fval;

                if (iMode == 1)
                    retval /= 100;

                return retval;
            }
            catch { return 0; }
        }
    }
}
