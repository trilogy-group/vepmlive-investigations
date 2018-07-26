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
    internal class CABottomGridTemp : CADataCacheGridBase
    {
        private readonly bool _useHeatMap;

        public CABottomGridTemp(
            bool useHeatMap,
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

        protected override bool CheckIfDetailRowShouldBeAdded(clsDetailRowData detailRow)
        {
            throw new NotImplementedException();
        }

        protected override void AddDetailRow(clsDetailRowData detailRowData, int rowId)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }
    }
}
