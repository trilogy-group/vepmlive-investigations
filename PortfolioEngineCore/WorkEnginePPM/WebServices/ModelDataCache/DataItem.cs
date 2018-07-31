using System;
using CostDataValues;

namespace ModelDataCache
{
    [Serializable()]
    public class DataItem : IDataItem
    {
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public int ID { get; set; } = 0;
        public int UID { get; set; } = 0;
        public int level { get; set; } = 0;
        public int group { get; set; } = 0;
        public bool bLoaded { get; set; } = false;
        public bool bEditiable { get; set; } = false;
        public bool bSelected { get; set; } = false;
        public bool bAllSelected { get; set; } = false;
        public int filterpos { get; set; } = 0;
    };
}
