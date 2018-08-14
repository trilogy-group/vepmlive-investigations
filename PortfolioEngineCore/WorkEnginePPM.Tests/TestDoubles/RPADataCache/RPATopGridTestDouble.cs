using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioEngineCore;
using ResourceValues;
using RPADataCache;

namespace WorkEnginePPM.Tests.TestDoubles.RPADataCache
{
    internal class RPATopGridTestDouble : RPATopGrid
    {
        public new CStruct PeriodCols => base.PeriodCols;
        public new CStruct MiddleCols => base.MiddleCols;
        public new CStruct DefinitionRight => base.DefinitionRight;
        public new CStruct DefinitionLeaf => base.DefinitionLeaf;
        public new CStruct[] Levels => base.Levels;
        public new int Level => base.Level;

        public RPATopGridTestDouble(
            IList<clsRXDisp> columns,
            int pmoAdmin,
            string xmlString,
            int displayMode,
            IList<RPATGRow> displayList,
            clsResourceValues resourceValues) 
        : base(columns, pmoAdmin, xmlString, displayMode, displayList, resourceValues)
        {
            Constructor = new CStruct();
            Constructor.Initialize("Grid");

            Header1 = Constructor.CreateSubStruct("Header");
            base.PeriodCols = Constructor.CreateSubStruct("RightCols");
            base.DefinitionRight = Constructor.CreateSubStruct("Right");
            base.DefinitionLeaf = Constructor.CreateSubStruct("Leaf");

            Levels[0] = Constructor.CreateSubStruct("Test");
        }

        public new void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            base.InitializeGridLayout(renderingType);
        }

        public new string ResolvePeriodId(CPeriod periodData, int index)
        {
            return base.ResolvePeriodId(periodData, index);
        }

        public new void AddPeriodColumns(IEnumerable<CPeriod> periods)
        {
            base.AddPeriodColumns(periods);
        }

        public new void InitializeGridData(GridRenderingTypes renderingType)
        {
            base.InitializeGridData(renderingType);
        }

        public new bool CheckIfDetailRowShouldBeAdded(Tuple<clsResXData, clsPIData> detailRow)
        {
            return base.CheckIfDetailRowShouldBeAdded(detailRow);
        }

        public new void AddDetailRow(Tuple<clsResXData, clsPIData> detailRowDataTuple, int rowId)
        {
            base.AddDetailRow(detailRowDataTuple, rowId);
        }

        protected override string GetResourceAnalyzerView(string sXML)
        {
            return sXML;
        }
    }
}
