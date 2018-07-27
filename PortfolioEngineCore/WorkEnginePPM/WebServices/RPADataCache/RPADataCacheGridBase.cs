using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint.Administration;
using ModelDataCache;
using PortfolioEngineCore;
using ResourceValues;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace RPADataCache
{
    internal abstract class RPADataCacheGridBase : ADataCacheGridBase<CPeriod, Tuple<clsResXData, clsPIData>>
    {
        protected readonly IList<clsRXDisp> _columns;
        protected readonly int _pmoAdmin;
        protected readonly string _xmlString;
        protected readonly int _displayMode;
        protected readonly IList<RPATGRow> _displayList;
        protected readonly clsResourceValues _resourceValues;
        protected readonly clsLookupList _categoryLookupList;

        protected CStruct DefinitionRight;
        protected CStruct DefinitionLeaf;
        protected CStruct MiddleCols;

        public RPADataCacheGridBase(
            IList<clsRXDisp> columns,
            int pmoAdmin,
            string xmlString,
            int displayMode,
            IList<RPATGRow> displayList, 
            clsResourceValues resourceValues,
            clsLookupList categoryLookupList)
        {
            _columns = columns;
            _pmoAdmin = pmoAdmin;
            _xmlString = xmlString;
            _displayMode = displayMode;
            _displayList = displayList;
            _resourceValues = resourceValues;
            _categoryLookupList = categoryLookupList;
        }
        
        protected override int CalculateInternalPeriodMax(Tuple<clsResXData, clsPIData> data)
        {
            for (int i = _resourceValues.Periods.Values.Count; i > 1; i--)
            {
                foreach (var displayRow in _displayList)
                {
                    if (displayRow.bUse)
                    {
                        var value = GetDetailRowValue(data.Item1, displayRow.fid, i);

                        if (value != 0)
                        {
                            return i;
                        }
                    }
                }
            }

            return 0;
        }

        protected override int CalculateInternalPeriodMin(Tuple<clsResXData, clsPIData> data)
        {
            var i = 0;
            foreach (var period in _resourceValues.Periods.Values)
            {
                ++i;
                foreach (var displayRow in _displayList)
                {
                    if (displayRow.bUse)
                    {
                        var value = GetDetailRowValue(data.Item1, displayRow.fid, i);
                        return i;
                    }
                }
            }

            return 0;
        }

        protected double GetDetailRowValue(clsResXData detailRowData, int fieldId, int i)
        {
            double result = 0;

            if (fieldId == 0)
            {
                switch (_displayMode)
                {
                    case 3:
                        try
                        {
                            if (detailRowData.getftarr(i) == 0)
                            {
                                result = 0;
                            }
                            else
                            {
                                result = detailRowData.getvarr(i) * 100;
                                result /= detailRowData.getftarr(i);
                                result = (int)result;
                            }
                        }
                        catch (Exception ex)
                        {
                            result = 0;

                            LoggingService.WriteTrace(
                                Area.EPMLiveWorkEnginePPM,
                                Categories.EPMLiveWorkEnginePPM.Others,
                                TraceSeverity.VerboseEx,
                                ex.ToString());
                        }
                        break;
                    case 0:
                        result = detailRowData.getvarr(i);
                        break;
                    default:
                        result = detailRowData.getftarr(i);
                        break;
                }
            }

            if (fieldId == 1)
            {
                if (detailRowData.bRealone)
                {
                    result = _displayMode == 0
                        ? detailRowData.getvarr(i)
                        : detailRowData.getftarr(i);
                }
            }

            if (_displayMode == 1)
            {
                result /= 100;
            }

            return result;
        }
    }
}
