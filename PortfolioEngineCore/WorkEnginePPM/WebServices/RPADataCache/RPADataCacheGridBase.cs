using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataCache;
using ResourceValues;

namespace RPADataCache
{
    internal abstract class RPADataCacheGridBase : GridBase<CPeriod, Tuple<clsResXData, clsPIData>>
    {
        public RPADataCacheGridBase()
        {
        }
    }
}
