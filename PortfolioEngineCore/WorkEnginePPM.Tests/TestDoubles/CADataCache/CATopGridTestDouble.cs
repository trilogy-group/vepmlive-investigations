using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioEngineCore;
using ResourceValues;
using CADataCache;
using CostDataValues;

namespace WorkEnginePPM.Tests.TestDoubles.CADataCache
{
    internal class CATopGridTestDouble : CATopGrid
    {
        public new CStruct PeriodCols => base.PeriodCols;
        public new CStruct MiddleCols => base.MiddleCols;
        public new CStruct DefinitionRight => base.DefinitionRight;
        public new CStruct DefinitionLeaf => base.DefinitionLeaf;
        public new CStruct[] Levels => base.Levels;
        public new int Level => base.Level;

        public CATopGridTestDouble(
            bool hideRowsWithAllZeros,
            bool showFTEs,
            bool useQuantity,
            bool useCost,
            bool showCostDetailed,
            int pmoAdmin,
            IList<CATGRow> displayList,
            IList<clsColDisp> columns) 
        : base(hideRowsWithAllZeros, showFTEs, useQuantity, useCost, showCostDetailed, pmoAdmin, displayList, columns)
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

        public new void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            base.InitializeGridLayout(renderingType);
        }

        public new string ResolvePeriodId(clsPeriodData periodData, int index)
        {
            return base.ResolvePeriodId(periodData, index);
        }

        public new void AddPeriodColumns(IEnumerable<clsPeriodData> periods)
        {
            base.AddPeriodColumns(periods);
        }

        public new void InitializeGridData(GridRenderingTypes renderingType)
        {
            base.InitializeGridData(renderingType);
        }

        public new bool CheckIfDetailRowShouldBeAdded(clsDetailRowData detailRow)
        {
            return base.CheckIfDetailRowShouldBeAdded(detailRow);
        }

        public new void AddDetailRow(clsDetailRowData detailRowData, int rowId)
        {
            base.AddDetailRow(detailRowData, rowId);
        }
    }
}
