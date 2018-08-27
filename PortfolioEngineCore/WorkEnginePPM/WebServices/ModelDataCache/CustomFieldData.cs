using System;
using System.Collections.Generic;
using CostDataValues;

namespace ModelDataCache
{
    [Serializable()]
    public class CustomFieldData : ICustomFieldData<ListItemData>
    {
        public int FieldID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int LookupOnly { get; set; }
        public int LookupID { get; set; }
        public int LeafOnly { get; set; }
        public int UseFullName { get; set; }
        public IDictionary<int, ListItemData> ListItems { get; set; }
        public string jsonMenu { get; set; }
    }
}
