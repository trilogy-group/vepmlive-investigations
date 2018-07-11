using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataCache
{
    [Serializable()]
    public class ListItemData
    {
        public int UID, ID, Level;
        public string Name, FullName;
        public bool InActive;
    }
}
