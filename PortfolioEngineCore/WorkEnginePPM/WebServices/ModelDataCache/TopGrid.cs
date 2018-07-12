using System;
using System.Collections.Generic;
using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class TopGrid : TopGridBase
    {
        public TopGrid(bool useGrouping, bool showFTEs, bool showGantt, DateTime dateStart, DateTime dateEnd, IList<SortFieldDefn> sortFields, int detFreeze, bool useQuantity, bool useCost, bool roundCost, int fromPeriodIndex, int toPeriodIndex) 
            : base(useGrouping, showFTEs, showGantt, dateStart, dateEnd, sortFields, detFreeze, useQuantity, useCost, roundCost, fromPeriodIndex, toPeriodIndex)
        {
        }

        public override bool InitializeGridLayout()
        {
            var useCols = false;

            if (DetFreeze == 0)
                useCols = true;

            Constructor = new CStruct();
            Constructor.Initialize("Grid");

            var xToolbar = Constructor.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            var xPanel = Constructor.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            var xCfg = Constructor.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("Grouping", "0");
            xCfg.CreateIntAttr("Sorting", 0);
            xCfg.CreateStringAttr("Filtering", "0");

            if (UseGrouping)
                xCfg.CreateStringAttr("MainCol", "xGrouping");

            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateBooleanAttr("NoTreeLines", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("FilterEmpty", 1);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            xCfg.CreateIntAttr("ExportFormat", 1);
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("PrintCols", 0);
            xCfg.CreateIntAttr("LeftWidth", 400);
            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "Modeler");
            xCfg.CreateIntAttr("RightWidth", 800);
            xCfg.CreateIntAttr("MinMidWidth", 200);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 1);
            xCfg.CreateIntAttr("RightCanResize", 1);

            CStruct m_xDef;
            CStruct m_xDefTree;
            m_xDef = Constructor.CreateSubStruct("Def");
            m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefTree.CreateIntAttr("NoColorState", 1);
            if (ShowGantt)
            {
                xCfg.CreateStringAttr("ScrollLeft", "0");
            }
            
            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            PeriodCols = Constructor.CreateSubStruct("RightCols");
            var xHead = Constructor.CreateSubStruct("Head");
            Header1 = xHead.CreateSubStruct("Header");
            Header2 = xHead.CreateSubStruct("Header");

            Header2.CreateStringAttr("id", "Header");
            Header2.CreateIntAttr("SortIcons", 0);

            Header1.CreateIntAttr("Spanned", -1);
            Header1.CreateIntAttr("SortIcons", 0);

            Header1.CreateStringAttr("HoverCell", "Color");
            Header1.CreateStringAttr("HoverRow", "");
            Header2.CreateStringAttr("HoverCell", "Color");
            Header2.CreateStringAttr("HoverRow", "");

            // Add category column
            var categoryColumn = xLeftCols.CreateSubStruct("C");
            categoryColumn.CreateStringAttr("Name", "Select");
            categoryColumn.CreateStringAttr("Type", "Bool");
            categoryColumn.CreateBooleanAttr("CanEdit", true);
            categoryColumn.CreateIntAttr("CanMove", 0);
            categoryColumn.CreateStringAttr("Width", "20");
            Header1.CreateStringAttr("Select", " ");
            Header2.CreateStringAttr("Select", " ");
            if (UseGrouping)
            {
                categoryColumn = xLeftCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", "xGrouping");
                categoryColumn.CreateStringAttr("Type", "Text");
                categoryColumn.CreateIntAttr("CanMove", 0);
                categoryColumn.CreateBooleanAttr("CanEdit", false);
                Header1.CreateStringAttr("xGrouping", " ");
                Header2.CreateStringAttr("xGrouping", "Grouping");
            }

            foreach (var sng in SortFields)
            {
                string sn = sng.name.Replace(" ", "");

                sn = sn.Replace("\r", "");
                sn = sn.Replace("\n", "");
                sn = RemoveNastyCharacters(sn);

                string h1 = " ";
                string h2 = " ";
                int isp = sng.name.IndexOf(" ");

                if (isp == -1)
                {
                    h1 = " ";
                    h2 = sng.name;
                }
                else
                {
                    h1 = sng.name.Substring(0, isp);
                    h2 = sng.name.Substring(isp + 1);
                }
                if (useCols)
                    categoryColumn = xCols.CreateSubStruct("C");
                else
                    categoryColumn = xLeftCols.CreateSubStruct("C");

                categoryColumn.CreateStringAttr("Name", sn);
                if (sng.fid == (int)FieldIDs.SD_FID || sng.fid == (int)FieldIDs.FD_FID)
                {
                    categoryColumn.CreateStringAttr("Type", "Date");
                    categoryColumn.CreateStringAttr("Format", "MM/dd/yyyy");
                }
                else if (sng.fid == (int)FieldIDs.FTOT_FID || sng.fid == (int)FieldIDs.DTOT_FID)
                {
                    categoryColumn.CreateStringAttr("Type", "Float");
                    categoryColumn.CreateStringAttr("Format", ",#.##");

                }
                else
                    categoryColumn.CreateStringAttr("Type", "Text");

                categoryColumn.CreateIntAttr("CanMove", 0);

                if (sng.selected == 0)
                {
                    categoryColumn.CreateIntAttr("Width", 0);
                }

                categoryColumn.CreateBooleanAttr("CanEdit", false);
                Header1.CreateStringAttr(sn, h1);
                Header2.CreateStringAttr(sn, h2);

                if (sng.fid == DetFreeze)
                    useCols = true;
            }

            if (ShowGantt == false)
                return true;

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
            Header1.CreateStringAttr("G", " ");

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

            return true;
        }

        public override void FinalizeGridLayout()
        {

        }

        public override bool InitializeGridData()
        {
            var body = Constructor.CreateSubStruct("Body");
            var b = body.CreateSubStruct("B");
            var i = body.CreateSubStruct("I");
            i.CreateBooleanAttr("CanEdit", false);

            Level = 0;
            Levels[Level] = i;
            return true;
        }
    }
}
