using System;

namespace ModelDataCache
{
    [Serializable()]
    public class PeriodsAndOptions
    {
        public ItemDefn[] Periods;
        public int displayStart, displayFinish, dragStart, dragFinish, showQTY, showWhichQTY, showCosts, showRHSDecCosts;
    }
}
