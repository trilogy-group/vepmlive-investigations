using System;
using System.Collections.Generic;

namespace ModelDataCache
{
    [Serializable()]
    class CustomFieldData
    {
        public int FieldID;
        public string Name;
        public string DisplayName;
        public int LookupOnly, LookupID, LeafOnly, UseFullName;
        public Dictionary<int, ListItemData> ListItems;
        public string jsonMenu;
    }
}
