using System.Collections.Generic;

namespace PortfolioEngineCore
{
    public class PFELookup
    {
        #region Fields (13) 

        public bool bflag;
        public string ChargeNumber;
        public string DataId;
        // only exist for Dept lookup
        public List<int> Executives;
        public string ExtId;
        public string fullname;
        public int ID;
        // only exist for Dept lookup
        public bool IsSummary;
        public int level;
        public List<int> Managers;
        public string name;
        // Personal Items
        public int Status;
        public int UID;
        public int UID_real;

        #endregion Fields 
    }
}
