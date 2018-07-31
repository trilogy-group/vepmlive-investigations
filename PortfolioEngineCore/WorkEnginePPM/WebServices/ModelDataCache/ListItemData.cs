using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;

namespace ModelDataCache
{
    [Serializable()]
    public class ListItemData : IListItemData
    {
        public int UID { get; set; }
        public int ID { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool InActive { get; set; }
    }
}
