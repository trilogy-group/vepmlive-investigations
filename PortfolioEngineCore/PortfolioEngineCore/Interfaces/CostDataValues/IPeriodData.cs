using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostDataValues
{
    public interface IPeriodData
    {
        string PeriodName { get; set; }
        int PeriodID { get; set; }
        DateTime StartDate { get; set; }
        DateTime FinishDate { get; set; }
    }
}
