using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPMLiveCore;
using PortfolioEngineCore;

namespace ModelDataCache
{
    public class TopGrid : ModelDataCacheGridBase
    {
        public TopGrid(
            bool useGrouping,
            bool showFTEs,
            bool showGantt, 
            DateTime dateStart, 
            DateTime dateEnd, 
            IList<SortFieldDefn> sortFields, 
            int detFreeze, 
            bool useQuantity, 
            bool useCost, 
            bool showCostDetailed, 
            int fromPeriodIndex, 
            int toPeriodIndex
        ) 
            : base(useGrouping, showFTEs, showGantt, dateStart, dateEnd, sortFields, detFreeze, useQuantity, useCost, showCostDetailed, fromPeriodIndex, toPeriodIndex)
        {
        }

        protected override void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            if (renderingType == GridRenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

            var useCols = Freeze == 0;

            var xToolbar = Constructor.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            var xPanel = Constructor.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            var xCfg = InitializeGridLayoutConfig();

            xCfg.CreateStringAttr("Grouping", "0");
            xCfg.CreateIntAttr("FilterEmpty", 1);
            xCfg.CreateIntAttr("ExportFormat", 1);

            if (renderingType == GridRenderingTypes.Combined)
            {
                xCfg.CreateIntAttr("Sorting", 0);
                xCfg.CreateStringAttr("Filtering", "0");
            }

            if (UseGrouping)
            {
                xCfg.CreateStringAttr("MainCol", "xGrouping");
            }

            if (ShowGantt)
            {
                xCfg.CreateStringAttr("ScrollLeft", "0");
            }

            var m_xDef = Constructor.CreateSubStruct("Def");
            InitializeGridLayoutDefinition("R", m_xDef, null);

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            PeriodCols = Constructor.CreateSubStruct("RightCols");
            var xHead = Constructor.CreateSubStruct("Head");

            InitializeGridLayoutHeader1(xHead);
            InitializeGridLayoutHeader2(xHead);

            Header1.CreateStringAttr("Select", GlobalConstants.Whitespace);
            Header2.CreateStringAttr("Select", GlobalConstants.Whitespace);

            if (UseGrouping)
            {
                Header1.CreateStringAttr("xGrouping", GlobalConstants.Whitespace);
                Header2.CreateStringAttr("xGrouping", "Grouping");
            }

            var categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols);

            useCols |= AddSortFieldsToColumns(xLeftCols, xCols, ref categoryColumn);

            if (ShowGantt)
            {
                InitializeGridLayoutGanttChart(categoryColumn);
            }
        }

        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            if (renderingType == GridRenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

            if (renderingType == GridRenderingTypes.Data)
            {
                var xCfg = Constructor.CreateSubStruct("Cfg");
                xCfg.CreateIntAttr("FilterEmpty", 1);
            }

            var body = Constructor.CreateSubStruct("Body");
            var b = body.CreateSubStruct("B");
            var i = body.CreateSubStruct("I");

            i.CreateBooleanAttr("CanEdit", false);

            Level = 0;
            Levels[Level] = i;
        }

        protected override string CleanUpString(string input)
        {
            const string nastyChars = "!@#$%^&*()_+-={}[]|:;'?/~`";
            const string charsToCleanup = nastyChars + " '\r\n\"\\";

            return RemoveCharacters(input, charsToCleanup);
        }

        protected override void AddDetailRow(DetailRowData detailRowData, int rowId)
        {
            var parent = Levels[detailRowData.m_lev - 1];
            var iSubStruct = parent.CreateSubStruct("I");

            var wrapCellInHtml = false;

            Levels[detailRowData.m_lev] = iSubStruct;
            iSubStruct.CreateStringAttr("id", rowId.ToString());
            if (detailRowData.bRealone)
            {
                iSubStruct.CreateStringAttr("Color", "255,255,255");
            }

            iSubStruct.CreateStringAttr("Select", (detailRowData.bSelected ? "1" : "0"));
            iSubStruct.CreateBooleanAttr("SelectCanEdit", true);
            iSubStruct.CreateBooleanAttr("CanEdit", false);

            if (detailRowData.m_lev != 1)
            {
                iSubStruct.CreateIntAttr("CanFilter", 2);
            }

            iSubStruct.CreateStringAttr("xGrouping", detailRowData.sName);
            if (wrapCellInHtml)
            {
                iSubStruct.CreateStringAttr("GroupingHtmlPrefix", "<B>");
                iSubStruct.CreateStringAttr("GroupingHtmlPostfix", "</B>");
            }

            foreach (var sortField in SortFields)
            {
                var sortFieldName = CleanUpString(sortField.name);

                string value;
                if (TryGetDataFromDetailRowDataField(detailRowData, sortField.fid, out value))
                {
                    // (CC-76681, 2018-07-13) Additional condition, specific to TopGrid
                    if (value == GlobalConstants.Whitespace)
                    {
                        if (sortField.fid >= (int)FieldIDs.PI_USE_EXTRA + 1 && sortField.fid <= (int)FieldIDs.PI_USE_EXTRA + (int)FieldIDs.MAX_PI_EXTRA)
                        {
                            if (detailRowData.m_PI_Format_Extra_data != null)
                            {
                                value = detailRowData.m_PI_Format_Extra_data[sortField.fid - (int)FieldIDs.PI_USE_EXTRA];
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    iSubStruct.CreateStringAttr(sortFieldName, value);
                }
            }

            iSubStruct.CreateIntAttr("NoColorState", 1);

            if (ShowGantt)
            {
                if (detailRowData.bGotChildren == false)
                {
                    iSubStruct.CreateStringAttr("GGanttClass", "GanttBlue");
                }
            }
            else
            {
                DisplayValues(detailRowData, iSubStruct);
            }
        }

        protected override string ResolvePeriodId(PeriodData periodData, int index)
        {
            return index.ToString();
        }

        private void DisplayValues(DetailRowData detailRowData, PortfolioEngineCore.CStruct iSubStruct)
        {
            for (var i = FromPeriodIndex; i <= ToPeriodIndex; i++)
            {
                if (UseQuantity)
                {
                    if (ShowFTEs)
                    {
                        if (detailRowData.zFTE[i] != double.MinValue)
                        {
                            iSubStruct.CreateDoubleAttr("P" + i.ToString() + "V", detailRowData.zFTE[i]);
                        }
                    }
                    else
                    {
                        if (detailRowData.zValue[i] != double.MinValue)
                        {
                            iSubStruct.CreateDoubleAttr("P" + i.ToString() + "V", detailRowData.zValue[i]);
                        }
                    }
                }

                if (UseCost)
                {
                    var dcost = detailRowData.zCost[i];

                    if (ShowCostDetailed == false)
                    {
                        dcost = Math.Floor(dcost);
                    }

                    if (detailRowData.zCost[i] != double.MinValue)
                    {
                        iSubStruct.CreateDoubleAttr("P" + i.ToString() + "C", dcost);
                    }
                }
            }
        }

        private void InitializeGridLayoutGanttChart(CStruct categoryColumn)
        {
            categoryColumn = PeriodCols.CreateSubStruct("C");
            categoryColumn.CreateStringAttr("Name", "G");
            categoryColumn.CreateStringAttr("Type", "Gantt");
            categoryColumn.CreateStringAttr("GanttObject", "Main");
            categoryColumn.CreateStringAttr("CanExport", "0");
            categoryColumn.CreateIntAttr("GanttLap", 1);
            categoryColumn.CreateStringAttr("GanttStart", "Start");
            categoryColumn.CreateStringAttr("GanttEnd", "Finish");
            categoryColumn.CreateStringAttr("GanttUnits", "d");
            categoryColumn.CreateStringAttr("GanttChartRound", "w");
            categoryColumn.CreateStringAttr("GanttRight", "1");
            categoryColumn.CreateStringAttr("GanttSlack", "Slack");
            categoryColumn.CreateStringAttr("GanttHeader1", "y#yy");
            categoryColumn.CreateStringAttr("GanttHeader2", "M#MMM");
            categoryColumn.CreateStringAttr("GanttChartMinStart", DateStart.ToString("MM/dd/yyyy"));
            categoryColumn.CreateStringAttr("GanttChartMinEnd", DateEnd.ToString("MM/dd/yyyy"));
            categoryColumn.CreateStringAttr("GanttChartMaxStart", DateStart.ToString("MM/dd/yyyy"));
            categoryColumn.CreateStringAttr("GanttChartMaxEnd", DateEnd.ToString("MM/dd/yyyy"));
            Header1.CreateStringAttr("G", GlobalConstants.Whitespace);

            var xZoom = Constructor.CreateSubStruct("Zoom");
            var xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom1");
            xZ.CreateStringAttr("GanttUnits", "M6");
            xZ.CreateStringAttr("GanttWidth", "60");
            xZ.CreateStringAttr("GanttChartRound", "M");
            xZ.CreateStringAttr("GanttHeader1", "y#yyyy");
            xZ.CreateStringAttr("GanttHeader2", "M6#MMM");
            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom2");
            xZ.CreateStringAttr("GanttWidth", "40");
            xZ.CreateStringAttr("GanttUnits", "M3");
            xZ.CreateStringAttr("GanttChartRound", "y");
            xZ.CreateStringAttr("GanttHeader1", "y#MM yyyy");
            xZ.CreateStringAttr("GanttHeader2", "M3#MMM");
            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom3");
            xZ.CreateStringAttr("GanttUnits", "M");
            xZ.CreateStringAttr("GanttWidth", "50");
            xZ.CreateStringAttr("GanttChartRound", "y");
            xZ.CreateStringAttr("GanttHeader1", "M6# MMM yyyy");
            xZ.CreateStringAttr("GanttHeader2", "M#MMM");
            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom4");
            xZ.CreateStringAttr("GanttUnits", "M");
            xZ.CreateStringAttr("GanttWidth", "50");
            xZ.CreateStringAttr("GanttChartRound", "M");
            xZ.CreateStringAttr("GanttHeader1", "M3#MM");
            xZ.CreateStringAttr("GanttHeader2", "M#MMM");
            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom5");
            xZ.CreateStringAttr("GanttUnits", "d");
            xZ.CreateStringAttr("GanttWidth", "6");
            xZ.CreateStringAttr("GanttChartRound", "M");
            xZ.CreateStringAttr("GanttHeader1", "M#MM yyyy");
            xZ.CreateStringAttr("GanttHeader2", "w#dd");

            xZ = xZoom.CreateSubStruct("Z");
            xZ.CreateStringAttr("Name", "Zoom6");
            xZ.CreateStringAttr("GanttUnits", "d");
            xZ.CreateStringAttr("GanttWidth", "20");
            xZ.CreateStringAttr("GanttChartRound", "M");
            xZ.CreateStringAttr("GanttHeader1", "M#MM yyyy");
            xZ.CreateStringAttr("GanttHeader2", "d#dd");
        }

        protected CStruct InitializeGridLayoutCategoryColumn(CStruct xLeftCols)
        {
            // Add category column
            var categoryColumn = xLeftCols.CreateSubStruct("C");
            categoryColumn.CreateStringAttr("Name", "Select");
            categoryColumn.CreateStringAttr("Type", "Bool");
            categoryColumn.CreateBooleanAttr("CanEdit", true);
            categoryColumn.CreateIntAttr("CanMove", 0);
            categoryColumn.CreateStringAttr("Width", "20");

            if (UseGrouping)
            {
                categoryColumn = xLeftCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", "xGrouping");
                categoryColumn.CreateStringAttr("Type", "Text");
                categoryColumn.CreateIntAttr("CanMove", 0);
                categoryColumn.CreateBooleanAttr("CanEdit", false);
            }

            return categoryColumn;
        }
    }
}
