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
    internal class CABottomGrid : CADataCacheGridBase<CATotRow>
    {
        private readonly bool _useHeatMap;
        private readonly int _heatMapIndex;
        private readonly int _heatMapColor;
        private readonly IList<clsTargetColours> _targetColors;
        private readonly bool _showRemainingDetailRows;
        private readonly bool _doZeroRowCleverStuff;

        protected override bool SkipDetailRowGenerationErrors => true;

        public CABottomGrid(
            bool useHeatMap,
            int heatMapIndex, 
            int heatMapColor, 
            IList<clsTargetColours> targetColors, 
            bool showRemainingDetailRows,
            bool doZeroRowCleverStuff,
            bool showFTEs,
            bool useQuantity,
            bool useCost,
            bool showCostDetailed,
            int pmoAdmin,
            IList<CATGRow> displayList,
            IList<clsColDisp> columns) 
        : base(showFTEs, useQuantity, useCost, showCostDetailed, pmoAdmin, displayList, columns, false)
        {
            _useHeatMap = useHeatMap;
            _useHeatMap = useHeatMap;
            _heatMapIndex = heatMapIndex;
            _heatMapColor = heatMapColor;
            _targetColors = targetColors;
            _showRemainingDetailRows = showRemainingDetailRows;
            _doZeroRowCleverStuff = doZeroRowCleverStuff;
        }
        
        protected override void InitializeGridLayoutCategoryColumns(CStruct columnsContainer)
        {
            var column = CreateColumn(columnsContainer, "rowid", "Text",
                visible: false,
                canExport: false);
            column.CreateStringAttr("Color", "rgb(223, 227, 232)");
        }
        
        protected override int CalculatePeriodColumnsSpan(string periodId, string periodName, int counter)
        {
            var span = _useCost ? 1 : 0;
            span *= counter;

            const string sumFunc = "(Row.id == 'Filter' ? '' : sum())";
            if (_useHeatMap)
            {
                var prefix = "P" + periodId + "H";

                Header1.CreateStringAttr(prefix, periodName + "\nHeatMap");

                var column = CreateColumn(PeriodCols, prefix, "Float",
                    visible: false,
                    canMove: false,
                    canResize: null,
                    canFilter: null);
                column.CreateStringAttr("Format", ",0.##");
                column.CreateStringAttr("Align", "Right");
                column.CreateIntAttr("MinWidth", 45);
                column.CreateIntAttr("Width", 65);

                DefinitionRight.CreateStringAttr(prefix + "Formula", sumFunc);
                DefinitionRight.CreateStringAttr(prefix + "Format", ",#.##");
                DefinitionLeaf.CreateStringAttr(prefix + "Formula", string.Empty);

                span *= 2;
            }

            return span;
        }

        protected override void InitializePeriodDisplayRow(string periodId, string periodName, int counter, CATGRow displayRow)
        {
            const string maxFunc = "(Row.id == 'Filter' ? '' : max())";
            const string minFunc = "(Row.id == 'Filter' ? '' : min())";

            if (_useHeatMap)
            {
                Header1.CreateStringAttr(GeneratePeriodAttributeName("X", periodId, counter), GlobalConstants.Whitespace);
                Header1.CreateStringAttr(GeneratePeriodAttributeName("Y", periodId, counter), GlobalConstants.Whitespace);
                Header2.CreateStringAttr(GeneratePeriodAttributeName("X", periodId, counter), periodName + displayRow.Name + "HeatMap");
                Header2.CreateStringAttr(GeneratePeriodAttributeName("Y", periodId, counter), periodName + displayRow.Name + "HeatMap");

                var column = CreateColumn(PeriodCols, GeneratePeriodAttributeName("X", periodId, counter), "Float",
                    visible: false,
                    canMove: false,
                    canResize: null,
                    canFilter: null);
                column.CreateStringAttr("Format", ",0.##");
                column.CreateStringAttr("Align", "Right");

                column = CreateColumn(PeriodCols, GeneratePeriodAttributeName("Y", periodId, counter), "Float",
                    visible: false,
                    canMove: false,
                    canResize: null,
                    canFilter: null);
                column.CreateStringAttr("Format", ",0.##");
                column.CreateStringAttr("Align", "Right");
            }

            Header2.CreateStringAttr(GeneratePeriodAttributeName("P", periodId, counter), "Cost");
            DefinePeriodColumn(GeneratePeriodAttributeName("P", periodId, counter), null, ",0.###");

            DefinitionRight.CreateStringAttr(GeneratePeriodAttributeName("X", periodId, counter, "Format"), "##");
            DefinitionRight.CreateStringAttr(GeneratePeriodAttributeName("X", periodId, counter, "Formula"), maxFunc);
            DefinitionRight.CreateStringAttr(GeneratePeriodAttributeName("Y", periodId, counter, "Format"), "##");
            DefinitionRight.CreateStringAttr(GeneratePeriodAttributeName("Y", periodId, counter, "Formula"), minFunc);
            DefinitionLeaf.CreateStringAttr(GeneratePeriodAttributeName("X", periodId, counter, "Formula"), string.Empty);
            DefinitionLeaf.CreateStringAttr(GeneratePeriodAttributeName("Y", periodId, counter, "Formula"), string.Empty);
        }

        protected override bool CheckIfDetailRowShouldBeAdded(CATotRow detailRowTotal)
        {
            var prefix = string.Empty;
            detailRowTotal.bUsed = false;

            if (_doZeroRowCleverStuff)
            {
                var detailRowDataSelected = GetDetailRowDataSelected(detailRowTotal);
                return detailRowDataSelected != null;
            }

            return true;
        }

        private clsDetailRowData GetDetailRowDataSelected(CATotRow detailRowTotal)
        {
            var detailRowData = GetDetailRowData(detailRowTotal);
            var maxp = detailRowData.zFTE.Length - 1;
            var counter = 0;

            for (int i = 1; i <= maxp; i++)
            {
                try
                {
                    foreach (var displayRow in _displayList)
                    {
                        if (displayRow.bUse)
                        {
                            ++counter;

                            var detailRowSelected = displayRow.index < 0
                                ? detailRowTotal.m_targets[-displayRow.index]
                                : detailRowTotal.m_totals[displayRow.index];

                            if (detailRowSelected.zCost[i] != 0)
                            {
                                return detailRowSelected;
                            }
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

            return null;
        }
        
        protected override int CalculateInternalPeriodMin(CATotRow detailRowTotal)
        {
            var detailRowData = GetDetailRowData(detailRowTotal);

            for (int i = 1; i <= detailRowData.zFTE.Length - 1; i++)
            {
                foreach (var displayRow in _displayList)
                {
                    if (displayRow.bUse)
                    {
                        if (detailRowData.zCost[i] != 0)
                        {
                            return i;
                        }
                    }
                }
            }

            return 0;
        }

        protected override int CalculateInternalPeriodMax(CATotRow resxData)
        {
            return 0;
        }

        protected override clsDetailRowData GetDetailRowData(CATotRow detailRowTotal)
        {
            return detailRowTotal.m_totals[0];
        }

        protected override CStruct InitializeDetailRowDataStructure(CATotRow detailRowData, int rowId)
        {
            detailRowData.bUsed = true;

            var xIParent = Levels[0];
            var xI = xIParent.CreateSubStruct("I");

            Levels[1] = xI;
            xI.CreateStringAttr("id", rowId.ToString());
            xI.CreateStringAttr("Color", "white");
            xI.CreateStringAttr("Def", "Leaf");
            xI.CreateIntAttr("NoColorState", 1);
            xI.CreateBooleanAttr("CanEdit", false);

            return xI;
        }

        protected override void UpdateDisplayRowsWithPeriodData(CATotRow detailRowTotal, CStruct xI, int i)
        {
            var p1 = 0d;
            var targetCost = 0d;
            var rgb = string.Empty;

            if (_useHeatMap)
            {
                targetCost = _heatMapIndex < 0
                    ? detailRowTotal.m_targets[-_heatMapIndex].zCost[i]
                    : detailRowTotal.m_totals[_heatMapIndex].zCost[i];

                xI.CreateDoubleAttr("P" + i.ToString() + "H", targetCost);
            }

            var counter = 0;
            foreach (var displayRow in _displayList)
            {
                if (displayRow.bUse)
                {
                    ++counter;

                    var detailRowDataSelected = displayRow.index < 0 
                        ? detailRowTotal.m_targets[-displayRow.index]
                        : detailRowTotal.m_totals[displayRow.index];

                    const string prefix = "C";
                    var attributeNameSuffix = i + prefix + counter;

                    var cost = detailRowDataSelected.zCost[i];

                    if (displayRow.fid == 0 && _useHeatMap == true)
                    {
                        p1 = detailRowDataSelected.zCost[i];

                        targetCost = _heatMapIndex < 0
                            ? detailRowTotal.m_targets[-_heatMapIndex].zCost[i]
                            : detailRowTotal.m_totals[_heatMapIndex].zCost[i];

                        if (_showRemainingDetailRows)
                        {
                            cost = targetCost - p1;
                        }
                    }

                    if (detailRowDataSelected.zCost[i] != double.MinValue)
                    {
                        xI.CreateDoubleAttr("P" + attributeNameSuffix, _showCostDetailed ? cost : Math.Floor(cost));
                    }

                    if (displayRow.fid == 0 && _useHeatMap)
                    {
                        int targetLevel = 0;
                        if (targetCost == 0 && p1 == 0)
                        {
                            rgb = TargetBackground(targetCost, 1, out targetLevel);
                        }
                        else
                        {
                            rgb = TargetBackground(p1, targetCost, out targetLevel);
                        }
                        
                        xI.CreateIntAttr("X" + attributeNameSuffix, targetLevel);
                        xI.CreateIntAttr("Y" + attributeNameSuffix, targetLevel >= 0 ? targetLevel : 0);

                        if (!string.IsNullOrEmpty(rgb))
                        {
                            xI.CreateStringAttr("P" + attributeNameSuffix + "Color", rgb);
                        }
                    }
                }
            }
        }
        
        // (CC-76484, 2018-07-27) Could not understand from the context what Tdbl and Pdbl are supposed to mean
        // therefore restraining of renaming them
        private string TargetBackground(double Tdbl, double Pdbl, out int targetlevel)
        {
            targetlevel = 0;
            var result = "RGB(217, 255, 255)";
            if (_targetColors == null || _targetColors.Count == 0)
            {
                return result;
            }

            var rgb = -4;
            targetlevel = Tdbl == 0 && Pdbl == 0 ? -3 :
                          Tdbl == 0 ? -2 :
                          Pdbl == 0 ? -1 :
                          0;

            if (targetlevel > 0)
            {
                foreach (var color in _targetColors)
                {
                    if (color.ID == targetlevel)
                    {
                        rgb = color.rgb_val;
                        break;
                    }
                }
            }
            else
            {
                var percent = (_heatMapColor == 2 
                        ? (Pdbl / Tdbl) 
                        : (Tdbl / Pdbl)
                    ) * 100;

                foreach (var color in _targetColors)
                {
                    if (color.ID > 0)
                    {
                        if ((percent >= color.low_val && percent <= color.high_val) 
                            || (color.high_val == 0))
                        {
                            rgb = color.rgb_val;
                            targetlevel = color.ID;
                            break;
                        }
                    }
                }
            }

            if (rgb == -1)
            {
                return null;
            }

            return string.Format("RGB({0},{1},{2})",
                (rgb & 0xFF).ToString(),
                ((rgb & 0xFF00) >> 8).ToString(),
                ((rgb & 0xFF0000) >> 16).ToString());
        }
    }
}
