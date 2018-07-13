using System;
using System.Collections.Generic;
using System.Linq;
using PortfolioEngineCore;

namespace ModelDataCache
{
    public class BottomGrid : GridBase
    {
        public readonly bool ApplyTarget;
        public readonly IList<DetailRowData> TargetsSorted;
        public readonly IList<TargetColours> TargetColors;
        public readonly bool ShowRemaining;

        public BottomGrid(
            bool applyTarget,
            IList<DetailRowData> targetsSorted,
            IList<TargetColours> targetColors,
            bool showRemaining,

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
            ApplyTarget = applyTarget;
            TargetsSorted = targetsSorted;
            TargetColors = targetColors;
            ShowRemaining = showRemaining;
        }
        
        protected override void InitializeGridLayout(RenderingTypes renderingType)
        {
            var useCols = Freeze == 0;

            Constructor = new CStruct();
            Constructor.Initialize("Grid");

            var xToolbar = Constructor.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            var xPanel = Constructor.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            var xCfg = Constructor.CreateSubStruct("Cfg");

            if (UseGrouping)
            {
                xCfg.CreateStringAttr("MainCol", "Grouping");
            }

            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("PrintCols", 0);
            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateBooleanAttr("NoTreeLines", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            xCfg.CreateIntAttr("LeftWidth", 400);
            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "Modeler");
            xCfg.CreateIntAttr("FocusWholeRow", 1);
            
            var m_xDef = Constructor.CreateSubStruct("Def");
            var m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");

            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefTree.CreateIntAttr("NoColorState", 1);

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");

            PeriodCols = Constructor.CreateSubStruct("RightCols");
            var xHead = Constructor.CreateSubStruct("Head");
            Header1 = xHead.CreateSubStruct("Header");
            Header1.CreateIntAttr("CategoryVisible", -1);
            Header1.CreateIntAttr("Spanned", -1);
            Header1.CreateIntAttr("SortIcons", 0);

            Header2 = xHead.CreateSubStruct("Header");
            Header2.CreateStringAttr("id", "Header");
            Header2.CreateIntAttr("SortIcons", 0);

            Header1.CreateStringAttr("HoverCell", "Color");
            Header1.CreateStringAttr("HoverRow", "");
            Header2.CreateStringAttr("HoverCell", "Color");
            Header2.CreateStringAttr("HoverRow", "");

            xCfg.CreateIntAttr("RightWidth", 800);
            xCfg.CreateIntAttr("MinMidWidth", 200);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 1);
            xCfg.CreateIntAttr("RightCanResize", 1);

            // Add category column
            var xC = xLeftCols.CreateSubStruct("C");

            if (UseGrouping)
            {
                xC = xLeftCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "Grouping");
                xC.CreateStringAttr("Type", "Text");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateBooleanAttr("CanEdit", false);
                Header1.CreateStringAttr("Grouping", " ");
                Header2.CreateStringAttr("Grouping", "Grouping");
            }

            foreach (var sortField in SortFields)
            {
                var sortFieldName = sortField.name.Replace(" ", string.Empty);
                sortFieldName = sortFieldName.Replace("\r", string.Empty);
                sortFieldName = sortFieldName.Replace("\n", string.Empty);

                var h1 = " ";
                var h2 = " ";

                var indexOfSpace = sortField.name.IndexOf(" ");
                if (indexOfSpace == -1)
                {
                    h1 = " ";
                    h2 = sortField.name;
                }
                else
                {
                    h1 = sortField.name.Substring(0, indexOfSpace);
                    h2 = sortField.name.Substring(indexOfSpace + 1);
                }

                if (useCols)
                {
                    xC = xCols.CreateSubStruct("C");
                }
                else
                {
                    xC = xLeftCols.CreateSubStruct("C");
                }

                xC.CreateStringAttr("Name", sortFieldName);

                switch (sortField.fid)
                {
                    case (int)FieldIDs.SD_FID:
                    case (int)FieldIDs.FD_FID:
                        xC.CreateStringAttr("Type", "Date");
                        xC.CreateStringAttr("Format", "MM/dd/yyyy");
                        break;
                    case (int)FieldIDs.FTOT_FID:
                    case (int)FieldIDs.DTOT_FID:
                        xC.CreateStringAttr("Type", "Float");
                        xC.CreateStringAttr("Format", ",#.##");
                        break;
                    default:
                        xC.CreateStringAttr("Type", "Text");
                        break;
                }

                xC.CreateIntAttr("CanMove", 0);

                if (sortField.selected == 0)
                {
                    xC.CreateIntAttr("Width", 0);
                }

                xC.CreateBooleanAttr("CanEdit", false);
                Header1.CreateStringAttr(sortFieldName, h1);
                Header2.CreateStringAttr(sortFieldName, h2);

                if (sortField.fid == Freeze)
                {
                    useCols = true;
                }
            }
        }

        protected override void InitializeGridData(RenderingTypes renderingType)
        {
            if (renderingType == RenderingTypes.Data)
            {
                var xCfg = Constructor.CreateSubStruct("Cfg");
            }

            var xBody = Constructor.CreateSubStruct("Body");
            var xB = xBody.CreateSubStruct("B");
            var xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateStringAttr("Def", "Summary");
            Level = 0;
            Levels[Level] = xI;
        }

        protected override void AddDetailRow(DetailRowData detailRowData, int rowId)
        {
            var target = ApplyTarget
                ? TargetsSorted.ElementAt(rowId)
                : null;

            var xIParent = Levels[detailRowData.m_lev - 1];
            var iSubStruct = xIParent.CreateSubStruct("I");

            Levels[detailRowData.m_lev] = iSubStruct;

            iSubStruct.CreateStringAttr("id", rowId.ToString());
            iSubStruct.CreateStringAttr("Color", "255,255,255");

            iSubStruct.CreateBooleanAttr("CanEdit", false);
            if (UseGrouping)
            {
                iSubStruct.CreateStringAttr("Grouping", detailRowData.sName);
            }

            foreach (var sortField in SortFields)
            {
                var sortFieldName = sortField.name.Replace(" ", string.Empty);
                sortFieldName = sortFieldName.Replace("\r", string.Empty);
                sortFieldName = sortFieldName.Replace("\n", string.Empty);

                string value;
                if (TryGetDataFromDetailRowDataField(detailRowData, sortField.fid, out value))
                {
                    iSubStruct.CreateStringAttr(sortFieldName, value);
                }
            }

            double t1, t2, p1, p2, xval;
            var crgb = string.Empty;
            var qrgb = string.Empty;

            for (int i = FromPeriodIndex; i <= ToPeriodIndex; i++)
            {
                if (UseQuantity)
                {
                    if (ShowFTEs)
                    {
                        t1 = detailRowData.zFTE[i];
                        p1 = target != null
                            ? target.zFTE[i]
                            : 0;
                    }
                    else
                    {
                        t1 = detailRowData.zValue[i];
                        p1 = target != null
                            ? target.zValue[i]
                            : 0;
                    }

                    xval = t1;

                    if (ShowRemaining)
                    {
                        xval -= p1;
                    }

                    if (xval != 0)
                    {
                        iSubStruct.CreateStringAttr("P" + i.ToString() + "V", xval.ToString("0.###"));
                    }

                    if (t1 == 0 && p1 == 0)
                    {
                        qrgb = TargetBackground(t1, 1, TargetColors);
                    }
                    else
                    {
                        qrgb = TargetBackground(t1, p1, TargetColors);
                    }
                }

                if (UseCost)
                {
                    t2 = detailRowData.zCost[i];
                    p2 = target != null
                        ? target.zCost[i]
                        : 0;

                    crgb = TargetBackground(
                        t2,
                        t2 == 0 && p2 == 0 
                            ? 1 
                            : p2, 
                        TargetColors);

                    xval = t2;

                    if (ShowRemaining)
                    {
                        xval -= p2;
                    }

                    if (ShowCostDetailed == false)
                    {
                        xval = Math.Floor(xval);
                    }

                    iSubStruct.CreateStringAttr("P" + i.ToString() + "C", xval.ToString("0.##"));
                }

                if (crgb != string.Empty && UseCost)
                {
                    iSubStruct.CreateStringAttr("P" + i.ToString() + "CColor", crgb);
                }

                if (qrgb != string.Empty && UseQuantity)
                {
                    iSubStruct.CreateStringAttr("P" + i.ToString() + "VColor", qrgb);
                }
            }
        }

        protected override string ResolvePeriodId(PeriodData periodData, int index)
        {
            return periodData.PeriodID.ToString();
        }

        private string TargetBackground(double t, double p, IList<TargetColours> targetColors)
        {
            var result = "RGB(217, 255, 255)";
            var rgb = -1;

            if (targetColors == null)
            {
                return result;
            }

            if (targetColors.Count == 0)
            {
                return result;
            }

            foreach (var targetColor in targetColors)
            {
                var condition =
                    t == 0 && p == 0 ? targetColor.ID == -3 :
                    t == 0 ? targetColor.ID == -2 :
                    p == 0 ? targetColor.ID == -1 :
                    targetColor.ID == 0 ? 
                            (((t / p) * 100) >= targetColor.low_val 
                             && ((t / p) * 100) <= targetColor.high_val)
                           || (targetColor.high_val == 0) :
                    false;

                if (targetColor.ID == -3)
                {
                    rgb = targetColor.rgb_val;
                    break;
                }
            }

            if (rgb == -1)
            {
                result = string.Empty;
            }
            else
            {
                result = "RGB(" + (rgb & 0xFF).ToString() + "," + ((rgb & 0xFF00) >> 8).ToString() + "," + ((rgb & 0xFF0000) >> 16).ToString() + ")";
            }

            return result;
        }
    }
}
