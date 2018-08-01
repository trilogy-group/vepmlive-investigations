using System.Collections.Generic;

namespace CostDataValues
{
    public interface ICustomFieldData<TListItemData>
        where TListItemData : IListItemData
    {
        int FieldID { get; set; }
        string Name { get; set; }
        string DisplayName { get; set; }
        int LookupOnly { get; set; }
        int LookupID { get; set; }
        int LeafOnly { get; set; }
        int UseFullName { get; set; }
        IDictionary<int, TListItemData> ListItems { get; set; }
        string jsonMenu { get; set; }
    }
}
