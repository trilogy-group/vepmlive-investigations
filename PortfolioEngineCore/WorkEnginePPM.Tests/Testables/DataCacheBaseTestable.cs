using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDataCache;

namespace WorkEnginePPM.Tests.Testables
{
    public class DataCacheBaseTestable : DataCacheBase<DataItem, CustomFieldData, ListItemData> 
    {
        private IDictionary<int, DataItem> _codesDictionary;
        private IDictionary<int, DataItem> _resesDictionary;
        private IDictionary<int, DataItem> _stagesDictionary;

        public DataCacheBaseTestable(
            IDictionary<int, DataItem> codesDictionary,
            IDictionary<int, DataItem> resesDictionary,
            IDictionary<int, DataItem> stagesDictionary)
        {
            _codesDictionary = codesDictionary;
            _resesDictionary = resesDictionary;
            _stagesDictionary = stagesDictionary;
        }

        public string FormatExtraDisplay(string input, int inputType)
        {
            return FormatExtraDisplay(
                input,
                inputType,
                _codesDictionary,
                _resesDictionary,
                _stagesDictionary);
        }

        public new string BuildCustFieldJSon(CustomFieldData customFieldData, int index, int maxListItemIndex)
        {
            return DataCacheBase<DataItem, CustomFieldData, ListItemData>
                .BuildCustFieldJSon(customFieldData, index, maxListItemIndex);
        }
    }
}
