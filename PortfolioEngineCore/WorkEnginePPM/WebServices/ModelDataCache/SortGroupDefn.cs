using System;

namespace ModelDataCache
{
    [Serializable()]
    public class SortGroupDefn
    {
        public SortRowDefn[] DetRows;
        public SortRowDefn[] TotRows;
        public SortFieldDefn[] DetFields, TotFields;
        public int DetFreeze, TotFreeze, DetShowToLevel, TotShowToLevel;
        public int NumPIs, MissingPIs, LoadReturnCode, HaveLowlevelData;
        public string errMsg;
        public int TotalsCmp;
        public string ViewZoomTo = "";
    }
}
