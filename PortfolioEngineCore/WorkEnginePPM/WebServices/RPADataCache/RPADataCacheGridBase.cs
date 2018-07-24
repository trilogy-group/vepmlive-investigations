using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataCache;

namespace RPADataCache
{
    internal abstract class RPADataCacheGridBase : GridBase
    {
        public RPADataCacheGridBase(int fromPeriodIndex, int toPeriodIndex) 
            : base(fromPeriodIndex, toPeriodIndex)
        {
        }
    }
}
