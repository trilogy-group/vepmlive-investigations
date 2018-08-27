using System;
using CostDataValues;

[Serializable()]
public class PeriodData : IPeriodData
{
    public string PeriodName { get; set; }
    public int PeriodID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
};
