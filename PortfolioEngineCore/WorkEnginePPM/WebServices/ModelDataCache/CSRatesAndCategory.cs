using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataCache
{
    [Serializable()]
    public class CSRatesAndCategory
    {
        public int numberPeriods;
        public CSNamedRate[] NamedRates;
        public CSCategoryEntry[] Categories;
        public string CatjsonMenu;
        public ItemDefn[] Versions;
        public ItemDefn[] CostTypes;
        public CustomFieldDefn[] CustomFields;
        // custom codes and lookups...
    }
}
