using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostDataValues
{
    public interface IListItemData
    {
        int UID { get; set; }
        int ID { get; set; }
        int Level { get; set; }
        string Name { get; set; }
        string FullName { get; set; }
        bool InActive { get; set; }
    }
}
