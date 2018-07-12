using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataCache;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;

namespace WorkEnginePPM.Tests.TestDoubles
{
    public class GridBaseTestDouble : GridBase
    {
        public GridBaseTestDouble(ShimCStruct header1Shim, ShimCStruct header2Shim, ShimCStruct periodColsShim)
        {
            Header1 = header1Shim;
            Header2 = header2Shim;
            PeriodCols = periodColsShim;
        }
    }
}
