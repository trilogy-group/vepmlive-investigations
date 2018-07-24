using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataCache
{
    [Serializable()]
    public class CustomFieldDefn
    {
        public int FieldID;
        public string Name;
        public int LookupOnly, LookupID, LeafOnly, UseFullName;
        public ListItemData[] LookUp;
        public string jsonMenu;
    }
}
