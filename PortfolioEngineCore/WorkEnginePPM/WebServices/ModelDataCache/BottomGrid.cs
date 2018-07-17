using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore;
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
            if (renderingType == RenderingTypes.None)
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

            if (UseGrouping)
            {
                xCfg.CreateStringAttr("MainCol", "Grouping");
            }

            xCfg.CreateIntAttr("FocusWholeRow", 1);

            InitializeGridLayoutDefinition();

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            PeriodCols = Constructor.CreateSubStruct("RightCols");
            var xHead = Constructor.CreateSubStruct("Head");

            InitializeGridLayoutHeader1(xHead);
            InitializeGridLayoutHeader2(xHead);

            Header1.CreateIntAttr("CategoryVisible", -1);

            if (UseGrouping)
            {
                Header1.CreateStringAttr("Grouping", GlobalConstants.Whitespace);
                Header2.CreateStringAttr("Grouping", "Grouping");
            }

            var categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols);

            useCols |= AddSortFieldsToColumns(xLeftCols, xCols, ref categoryColumn);
        }

        protected override void InitializeGridData(RenderingTypes renderingType)
        {
            if (renderingType == RenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

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
                var sortFieldName = sortField.name.Replace(GlobalConstants.Whitespace, string.Empty);
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

        protected override string CleanUpString(string input)
        {
            return RemoveCharacters(input, " \r\n");
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

        protected override CStruct InitializeGridLayoutCategoryColumn(CStruct xLeftCols)
        {
            var categoryColumn = xLeftCols.CreateSubStruct("C");

            if (UseGrouping)
            {
                categoryColumn = xLeftCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", "Grouping");
                categoryColumn.CreateStringAttr("Type", "Text");
                categoryColumn.CreateIntAttr("CanMove", 0);
                categoryColumn.CreateBooleanAttr("CanEdit", false);
            }

            return categoryColumn;
        }
    }
}
