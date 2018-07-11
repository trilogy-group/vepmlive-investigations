using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataCache;
using PortfolioEngineCore.Fakes;

namespace WorkEnginePPM.Tests.TestDoubles
{
    public class TopGridBaseTestDouble : TopGridBase
    {
        public TopGridBaseTestDouble()
        {
            for(var i = 0; i < Levels.Length; i++)
            {
                Levels[i] = new ShimCStruct();
            }
        }

        public new string RemoveNastyCharacters(string input)
        {
            return base.RemoveNastyCharacters(input);
        }
    }
}
