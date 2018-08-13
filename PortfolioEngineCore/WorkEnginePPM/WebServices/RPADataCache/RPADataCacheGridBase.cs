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

        protected CStruct InitializeGridLayoutConfig(
            string mainColName, 
            int suppressCfgStatus,
            int draggingStatus,
            int leftWidth,
            int rightWidth)
        {
            var xCfg = Constructor.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("MainCol", mainColName);
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", suppressCfgStatus);
            xCfg.CreateIntAttr("SuppressMessage", 3);
            xCfg.CreateIntAttr("PrintCols", 0);
            xCfg.CreateIntAttr("Dragging", draggingStatus);
            xCfg.CreateIntAttr("Sorting", 1);
            xCfg.CreateIntAttr("ColsMoving", 1);
            xCfg.CreateIntAttr("ColsPosLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateIntAttr("VisibleLap", 1);
            xCfg.CreateIntAttr("SectionWidthLap", 1);
            xCfg.CreateIntAttr("GroupLap", 1);
            xCfg.CreateIntAttr("WideHScroll", 0);
            xCfg.CreateIntAttr("LeftWidth", leftWidth);
            xCfg.CreateIntAttr("Width", 400);
            xCfg.CreateIntAttr("RightWidth", rightWidth);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("MaxSort", 2);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");
            xCfg.CreateIntAttr("FastColumns", 1);
            xCfg.CreateIntAttr("ExpandAllLevels", 3);
            xCfg.CreateIntAttr("GroupSortMain", 1);
            xCfg.CreateIntAttr("GroupRestoreSort", 1);
            xCfg.CreateIntAttr("NoTreeLines", 1);
            xCfg.CreateIntAttr("ShowVScroll", 1);

            return xCfg;
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
