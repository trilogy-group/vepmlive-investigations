using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataCache;

namespace WorkEnginePPM.Tests.TestDoubles
{
    public class TopGridBaseTestDouble : TopGridBase
    {
        public new string RemoveNastyCharacters(string input)
        {
            return base.RemoveNastyCharacters(input);
        }
    }
}
