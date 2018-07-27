using System;
using System.Collections.Generic;
using CADataCache;
using CostDataValues;
using PortfolioEngineCore;

namespace WorkEnginePPM.Tests.TestDoubles.CADataCache
{
    internal class CADataCacheGridBaseTestDouble : CADataCacheGridBase<clsDetailRowData>
    {
        public new CStruct PeriodCols => base.PeriodCols;
        public new CStruct MiddleCols => base.MiddleCols;
        public new CStruct DefinitionRight => base.DefinitionRight;
        public new CStruct DefinitionLeaf => base.DefinitionLeaf;
        public new CStruct[] Levels => base.Levels;
        public new int Level => base.Level;

        public CADataCacheGridBaseTestDouble(
            bool showFTEs,
            bool useQuantity,
            bool useCost,
            bool showCostDetailed,
            int pmoAdmin,
            IList<CATGRow> displayList,
            IList<clsColDisp> columns) 
        : base(showFTEs, useQuantity, useCost, showCostDetailed, pmoAdmin, displayList, columns, true)
        {
            Constructor = new CStruct();
            Constructor.Initialize("Grid");

            Header1 = Constructor.CreateSubStruct("Header");
            Header2 = Constructor.CreateSubStruct("Header");
            base.PeriodCols = Constructor.CreateSubStruct("RightCols");
            base.MiddleCols = Constructor.CreateSubStruct("Cols");
            base.DefinitionRight = Constructor.CreateSubStruct("Right");
            base.DefinitionLeaf = Constructor.CreateSubStruct("Leaf");

            Levels[0] = Constructor.CreateSubStruct("Test");
        }

        public new bool TryGetDataFromDetailRowDataField(clsDetailRowData detailRowData, int fid, out string value)
        {
            return base.TryGetDataFromDetailRowDataField(detailRowData, fid, out value);
        }

        protected override bool CheckIfDetailRowShouldBeAdded(clsDetailRowData detailRow)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }

        protected override void AddDetailRow(clsDetailRowData detailRowData, int rowId)
        {
            throw new NotImplementedException();
        }

        protected override string ResolvePeriodId(clsPeriodData periodData, int index)
        {
            throw new NotImplementedException();
        }

        protected override void AddPeriodColumns(IEnumerable<clsPeriodData> periods)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridLayoutCategoryColumns(CStruct columnsContainer)
        {
            throw new NotImplementedException();
        }

        protected override int CalculatePeriodColumnsSpan(string periodId, string periodName, int counter)
        {
            throw new NotImplementedException();
        }

        protected override void InitializePeriodDisplayRow(string periodId, string periodName, int counter, CATGRow displayRow)
        {
            throw new NotImplementedException();
        }

        protected override clsDetailRowData GetDetailRowDataItem(clsDetailRowData detailRowData)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateDisplayRowsWithPeriodData(clsDetailRowData detailRowData, CStruct xI, int i)
        {
            throw new NotImplementedException();
        }

        protected override CStruct InitializeDetailRowDataStructure(clsDetailRowData detailRowData, int rowId)
        {
            throw new NotImplementedException();
        }

        protected override int CalculateInternalPeriodMin(clsDetailRowData resxData)
        {
            throw new NotImplementedException();
        }

        protected override int CalculateInternalPeriodMax(clsDetailRowData resxData)
        {
            throw new NotImplementedException();
        }
    }
}
