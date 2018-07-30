using System.Collections.Generic;

namespace PortfolioEngineCore
{
    public class PFELookup
    {
        public bool bflag { get; set; }
        public string ChargeNumber { get; set; }
        public string DataId { get; set; }
        // only exist for Dept lookup
        public List<int> Executives { get; set; }
        public string ExtId { get; set; }
        public string fullname { get; set; }
        public int ID { get; set; }
        // only exist for Dept lookup
        public bool IsSummary { get; set; }
        public int level { get; set; }
        public List<int> Managers { get; set; }
        public string name { get; set; }
        // Personal Items
        public int Status { get; set; }
        public int UID { get; set; }
        public int UID_real { get; set; }
    }
}
