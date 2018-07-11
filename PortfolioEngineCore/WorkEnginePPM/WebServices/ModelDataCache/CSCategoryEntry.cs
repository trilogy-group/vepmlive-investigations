using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataCache
{
    [Serializable()]
    public class CSCategoryEntry
    {
        public int UID, ID, Level, Role_UID, Mode, PID, MC_UID, Category;
        public string Name, UoM, FullName, MC_Val, Role_Name;
        public double[] Rates, FTEConv;
    }
}
