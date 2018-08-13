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
    internal abstract class RPADataCacheGridBase<TDetailRowData> : ADataCacheGridBase<CPeriod, TDetailRowData>
    {
        protected readonly IList<clsRXDisp> _columns;
        protected readonly int _pmoAdmin;
        protected readonly string _xmlString;
        protected readonly int _displayMode;
        protected readonly IList<RPATGRow> _displayList;
        protected readonly clsResourceValues _resourceValues;
        protected readonly clsLookupList _categoryLookupList;

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
    }
}
