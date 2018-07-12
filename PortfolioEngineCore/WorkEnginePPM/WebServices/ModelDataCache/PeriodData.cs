using System;

namespace ModelDataCache
{
    [Serializable()]
    public class PeriodData
    {
        public string PeriodName;
        public int PeriodID;
        public DateTime StartDate;
        public DateTime FinishDate;
    };
}
