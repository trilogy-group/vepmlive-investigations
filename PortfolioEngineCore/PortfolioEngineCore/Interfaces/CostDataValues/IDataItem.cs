using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostDataValues
{
    public interface IDataItem
    {
        string Name { get; set; }
        string Desc { get; set; }
        int UID { get; set; }
        int ID { get; set; }
        bool bEditiable { get; set; }
        bool bSelected { get; set; }
    }
}
