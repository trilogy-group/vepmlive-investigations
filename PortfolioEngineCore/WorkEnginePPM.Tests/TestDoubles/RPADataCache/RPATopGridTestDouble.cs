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
        public RPATopGridTestDouble(
            IList<clsRXDisp> columns,
            int pmoAdmin,
            string xmlString,
            int displayMode,
            IList<RPATGRow> displayList,
            clsResourceValues resourceValues,
            clsLookupList categoryLookupList) 
        : base(columns, pmoAdmin, xmlString, displayMode, displayList, resourceValues, categoryLookupList)
        {
            Constructor = new CStruct();
            Constructor.Initialize("Grid");
        }

        public new void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            base.InitializeGridLayout(renderingType);
        }

        protected override string GetResourceAnalyzerView(string sXML)
        {
            return sXML;
        }
    }
}
