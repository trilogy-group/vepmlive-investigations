using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
    public class TimeSheetItem
    {
        public int ItemID { get; set; }
        public string ProjectName { get; set; }
        public Guid Uid { get; set; }
        public List<TimeSheetHourItem> Hours { get; set; }
        public bool Changed { get; set; }
        public string AssignedToID { get; set; }
        public string ItemTitle { get; set; }
        public string WorkTypeField { get; set; }
    }

    public class TimeSheetHourItem
    {
        public DateTime Date { get; set; }
        public double Hour { get; set; }
    }
}
