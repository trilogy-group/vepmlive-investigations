using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EPMLiveCore;
using ModelDataCache;
using PortfolioEngineCore;
using WorkEnginePPM;

namespace RPADataCache
{
    internal class RPATopGrid1 : RPADataCacheGridBase
    {
        private readonly List<clsRXDisp> _columns;
        private readonly int _pmoAdminId;
        private readonly string _xmlString;

        private CStruct MiddleCols;

        public RPATopGrid1(List<clsRXDisp> columns, int pmoAdminId, string xmlString, int fromPeriodIndex, int toPeriodIndex)
            : base(fromPeriodIndex, toPeriodIndex)
        {
            _columns = columns;
            _pmoAdminId = pmoAdminId;
            _xmlString = xmlString;
        }

        protected override void AddDetailRow(DetailRowData detailRowData, int rowId)
        {
            throw new NotImplementedException();
        }

        protected override void AddPeriodColumn(string id, string name)
        {
            throw new NotImplementedException();
        }

        protected override string CleanUpString(string input)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridData(RenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridLayout(RenderingTypes renderingType)
        {
            if (renderingType == RenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

            var currentViewResult = GetResourceAnalyzerView(_xmlString);

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(currentViewResult.ToString());
            var currentViewCols = xdoc.SelectSingleNode("Result/View/g_1").Attributes["Cols"].InnerText;
            var strCurrentViewCols = currentViewCols.Split(',').Select(x => x.Split(':')).ToArray();
            
            var xToolbar = Constructor.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);
            var xPanel = Constructor.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);
            var xCfg = Constructor.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("MainCol", "PortfolioItem");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("SuppressMessage", 3);
            xCfg.CreateIntAttr("PrintCols", 0);
            xCfg.CreateIntAttr("Dragging", _pmoAdminId);
            xCfg.CreateIntAttr("Sorting", 1);
            xCfg.CreateIntAttr("ColsMoving", 1);
            xCfg.CreateIntAttr("ColsPosLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateIntAttr("VisibleLap", 1);
            xCfg.CreateIntAttr("SectionWidthLap", 1);
            xCfg.CreateIntAttr("GroupLap", 1);
            xCfg.CreateIntAttr("WideHScroll", 0);
            xCfg.CreateIntAttr("LeftWidth", 150);
            xCfg.CreateIntAttr("Width", 400);
            xCfg.CreateIntAttr("RightWidth", 800);
            xCfg.CreateIntAttr("MinMidWidth", 50);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 0);
            xCfg.CreateIntAttr("RightCanResize", 1);
            xCfg.CreateIntAttr("FocusWholeRow", 1);
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

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            var xRightCols = Constructor.CreateSubStruct("RightCols");
            PeriodCols = xRightCols;
            MiddleCols = xCols;

            var definitionRight = InitializeGridLayoutDefinition("R");
            definitionRight.CreateStringAttr("Calculated", "1");

            var definitionLeaf = InitializeGridLayoutDefinition("Leaf");
            definitionLeaf.CreateStringAttr("Calculated", "0");
            
            var xHead = Constructor.CreateSubStruct("Head");
            var xFilter = xHead.CreateSubStruct("Filter");
            xFilter.CreateStringAttr("id", "Filter");

            InitializeGridLayoutHeader1(xHead, -1, 2);
            Header1.CreateIntAttr("PortfolioItemVisible", 1);
            Header1.CreateIntAttr("NoEscape", 1);

            var categoryColumn = InitializeGridLayoutCategoryColumns(xLeftCols).Last();

            definitionRight.CreateBooleanAttr("SelectCanEdit", true);
            definitionRight.CreateStringAttr("rowid", string.Empty);

            var xSolid = Constructor.CreateSubStruct("Solid");
            var xGroup = xSolid.CreateSubStruct("Group");

            foreach (clsRXDisp col in _columns)
            {
                if (col.m_id != RPConstants.TGRID_GRP_ID)
                {
                    categoryColumn = InitializeViewColumn(strCurrentViewCols, xCols, definitionRight, definitionLeaf, categoryColumn, col);
                }
            }
        }

        private CStruct InitializeViewColumn(
            IList<string[]> strCurrentViewCols, 
            CStruct xCols, 
            CStruct definitionRight, 
            CStruct definitionLeaf, 
            CStruct categoryColumn, 
            clsRXDisp col)
        {
            try
            {
                // below code find columns which not matched with current saved view's column and that column hide on grid.

                var SelViewCols = (from x in strCurrentViewCols
                                   where x[0].ToString() == col.m_realname.Replace(" ", string.Empty)
                                   select x[0]).FirstOrDefault();

                var sn = RemoveCharacters(col.m_realname, " \r\n")
                    .Replace("/n", string.Empty);

                var snv = col.m_dispname.Replace("/n", "\n");

                categoryColumn = xCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", sn);
                categoryColumn.CreateStringAttr("Class", "GMCellMain");
                categoryColumn.CreateIntAttr("CanDrag", 0);
                categoryColumn.CreateIntAttr("ShowHint", 0);
                categoryColumn.CreateIntAttr("CaseSensitive", 0);
                categoryColumn.CreateStringAttr("OnDragCell", "Focus,DragCell");
                if (SelViewCols == null)
                {
                    categoryColumn.CreateIntAttr("Visible", 0);
                }

                definitionRight.CreateIntAttr(sn + "CanDrag", 0);
                definitionRight.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                definitionRight.CreateStringAttr(sn + "HtmlPostfix", "</B>");
                definitionLeaf.CreateIntAttr(sn + "CanDrag", 0);
                definitionLeaf.CreateStringAttr(sn + "HtmlPrefix", string.Empty);
                definitionLeaf.CreateStringAttr(sn + "HtmlPostfix", string.Empty);

                if (col.m_type == 2)
                {
                    string format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    categoryColumn.CreateStringAttr("Format", format);
                    categoryColumn.CreateStringAttr("EditFormat", format);
                    if (col.m_id == RPConstants.TGRID_SDATE)
                    {
                        categoryColumn.CreateStringAttr("Type", "Date");

                        string sminFunc = "(Row.id == 'Filter' ? '' : min())";
                        definitionRight.CreateStringAttr(sn + "Formula", sminFunc);
                    }
                    else if (col.m_id == RPConstants.TGRID_FDATE)
                    {
                        categoryColumn.CreateStringAttr("Type", "Date");

                        string smaxFunc = "(Row.id == 'Filter' ? '' : max())";
                        definitionRight.CreateStringAttr(sn + "Formula", smaxFunc);
                    }
                }
                else if (col.m_type == 3)
                {
                    categoryColumn.CreateStringAttr("Type", "Float");
                    categoryColumn.CreateStringAttr("Format", ",0.##");
                }
                else
                {
                    categoryColumn.CreateStringAttr("Type", "Text");
                }

                if (sn.Equals(RPConstants.CONST_PRIORITY))
                {
                    categoryColumn.CreateStringAttr("NumberSort", "1");
                }

                categoryColumn.CreateIntAttr("CanEdit", 0);
                categoryColumn.CreateIntAttr("CanMove", 1);

                if (col.m_col_hidden == true)
                {
                    categoryColumn.CreateIntAttr("Width", 0);
                }
                Header1.CreateStringAttr(sn, snv);

                string sMaxFunc = "(Row.id == 'Filter' ? '' : max())";
                string sMinFunc = "(Row.id == 'Filter' ? '' : min())";

                categoryColumn = MiddleCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", "xinterenalPeriodMin");

                categoryColumn.CreateIntAttr("ShowHint", 0);
                categoryColumn.CreateStringAttr("Type", "Int");
                categoryColumn.CreateIntAttr("CanSort", 0);
                categoryColumn.CreateIntAttr("CanMove", 0);
                categoryColumn.CreateStringAttr("Align", "Right");
                categoryColumn.CreateIntAttr("Visible", 0);
                categoryColumn.CreateIntAttr("CanSelect", 0);
                categoryColumn.CreateIntAttr("CanHide", 0);
                categoryColumn.CreateIntAttr("CanDrag", 0);

                definitionRight.CreateStringAttr("xinterenalPeriodMin" + "Formula", sMinFunc);
                definitionLeaf.CreateStringAttr("xinterenalPeriodMin" + "Formula", string.Empty);
                definitionLeaf.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);
                definitionRight.CreateIntAttr("xinterenalPeriodMin" + "CanDrag", 0);

                categoryColumn = MiddleCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", "xinterenalPeriodMax");

                categoryColumn.CreateIntAttr("ShowHint", 0);
                categoryColumn.CreateStringAttr("Type", "Int");
                categoryColumn.CreateIntAttr("CanSort", 0);
                categoryColumn.CreateIntAttr("CanMove", 0);
                categoryColumn.CreateStringAttr("Align", "Right");
                categoryColumn.CreateIntAttr("Visible", 0);
                categoryColumn.CreateIntAttr("CanSelect", 0);
                categoryColumn.CreateIntAttr("CanHide", 0);
                categoryColumn.CreateIntAttr("CanDrag", 0);

                definitionRight.CreateStringAttr("xinterenalPeriodMax" + "Formula", sMaxFunc);


                definitionLeaf.CreateStringAttr("xinterenalPeriodMax" + "Formula", string.Empty);

                definitionLeaf.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                definitionRight.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);

                categoryColumn = MiddleCols.CreateSubStruct("C");
                categoryColumn.CreateStringAttr("Name", "xinterenalPeriodTotal");

                categoryColumn.CreateIntAttr("ShowHint", 0);
                categoryColumn.CreateStringAttr("Type", "Int");
                categoryColumn.CreateIntAttr("CanSort", 0);
                categoryColumn.CreateIntAttr("CanMove", 0);
                categoryColumn.CreateStringAttr("Align", "Right");
                categoryColumn.CreateIntAttr("Visible", 0);
                categoryColumn.CreateIntAttr("CanSelect", 0);
                categoryColumn.CreateIntAttr("CanHide", 0);
                categoryColumn.CreateIntAttr("CanDrag", 0);

                definitionLeaf.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
                definitionRight.CreateIntAttr("xinterenalPeriodMax" + "CanDrag", 0);
            }
            catch (Exception ex)
            {

            }

            return categoryColumn;
        }

        protected override string ResolvePeriodId(PeriodData periodData, int index)
        {
            throw new NotImplementedException();
        }

        protected IEnumerable<CStruct> InitializeGridLayoutCategoryColumns(CStruct xLeftCols)
        {
            var categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "RowSel", "Icon",
                width: 20,
                canMove: false,
                canExport: false,
                canEdit: false);
            categoryColumn.CreateStringAttr("Color", "rgb(223, 227, 232)");
            Header1.CreateStringAttr("RowSel", GlobalConstants.Whitespace);
            yield return categoryColumn;
            
            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "rowid", "Text",
                visible: false,
                canExport: false);
            yield return categoryColumn;

            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "Select", "Bool",
                width: 20,
                canEdit: true,
                canMove: false);
            categoryColumn.CreateStringAttr("Class", string.Empty);
            Header1.CreateStringAttr("Select", "<img id='allSelectedTopGrid' src='/_layouts/ppm/images/checked-dark.png' />");
            yield return categoryColumn;

            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "ChangedIcon", "Type",
                width: 20,
                canEdit: false,
                canMove: false,
                canExport: false);
            Header1.CreateStringAttr("ChangedIcon", GlobalConstants.Whitespace);
            yield return categoryColumn;

            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "RowDraggable", "Bool",
                visible: false,
                canEdit: false,
                canMove: false);
            yield return categoryColumn;

            categoryColumn = InitializeGridLayoutCategoryColumn(xLeftCols, "RowChanged", "Int",
                visible: false,
                canEdit: false,
                canMove: false,
                canExport: false);
            yield return categoryColumn;
        }

        protected CStruct InitializeGridLayoutCategoryColumn(
            CStruct xLeftCols,
            string name,
            string type,
            bool? visible = null,
            int? width = null,
            bool? canEdit = null,
            bool? canMove = null,
            bool? canExport = null,
            bool canResize = false,
            bool canFilter = false,
            bool showHint = false,
            bool canSort = false,
            bool canHide = false,
            bool canSelect = false)
        {
            var categoryColumn = xLeftCols.CreateSubStruct("C");
            categoryColumn.CreateStringAttr("Name", name);
            categoryColumn.CreateStringAttr("Type", type);

            if (visible != null)
            {
                categoryColumn.CreateIntAttr("Visible", visible.Value ? 1 : 0);
            }
            if (width != null)
            {
                categoryColumn.CreateStringAttr("Width", width.ToString());
            }
            if (canEdit != null)
            {
                categoryColumn.CreateBooleanAttr("CanEdit", canEdit.Value);
            }
            if (canMove != null)
            {
                categoryColumn.CreateIntAttr("CanMove", canMove.Value ? 1 : 0);
            }
            if (canExport != null)
            {
                categoryColumn.CreateIntAttr("CanExport", canExport.Value ? 1 : 0);
            }
            categoryColumn.CreateIntAttr("CanResize", canResize ? 1 : 0);
            categoryColumn.CreateIntAttr("CanFilter", canFilter ? 1 : 0);
            categoryColumn.CreateIntAttr("ShowHint", showHint ? 1 : 0);
            categoryColumn.CreateIntAttr("CanSort", canSort ? 1 : 0);
            categoryColumn.CreateIntAttr("CanHide", canHide ? 1 : 0);
            categoryColumn.CreateIntAttr("CanSelect", canSelect ? 1 : 0);

            return categoryColumn;
        }

        private string GetResourceAnalyzerView(string sXML)
        {
            string basePath;
            string ppmId;
            string ppmCompany;
            string ppmDbConn;
            string username;
            SecurityLevels securityLevel;

            string sReply = string.Empty;

            WebAdmin.CapturePFEBaseInfo(out basePath, out username, out ppmId, out ppmCompany, out ppmDbConn, out securityLevel);
            var rpa = new ResourceAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel);

            try
            {
                var xExecute = new CStruct();
                if (xExecute.LoadXML(sXML) == false)
                {
                    return HandleError("GetResourceAnalyzerView", 99999, "Invalid request xml");
                }
                var viewNode = xExecute.GetXMLNode();
                var viewGuid = viewNode.SelectSingleNode("View").Attributes["ViewGUID"].InnerText;
                var guidView = Guid.Parse(viewGuid);

                string sViewsXML;
                if (rpa.GetResourceAnalyzerViewXML(guidView, out sViewsXML) == false)
                {
                    sReply = HandleError("GetResourceAnalyzerView", rpa.Status, rpa.FormatErrorText());
                }
                else
                {
                    var xResult = BuildResultXML("GetResourceAnalyzerView", 0);
                    xResult.AppendXML(sViewsXML);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetResourceAnalyzerViews", 99999, ex, string.Empty);
            }

            return sReply;
        }

        private string HandleError(string sContext, int nStatus, string sError)
        {
            var xResult = BuildResultXML(sContext, nStatus);
            var xError = xResult.CreateSubStruct("Error");
            xError.CreateIntAttr("ID", 100);
            xError.CreateStringAttr("Value", sError);
            return xResult.XML();
        }

        private CStruct BuildResultXML(string sContext = null, int nStatus = 0)
        {
            var xResult = new CStruct();
            xResult.Initialize("Result");
            xResult.CreateStringAttr("Context", sContext ?? string.Empty);
            xResult.CreateIntAttr("Status", nStatus);
            return xResult;
        }

        private string HandleException(string sContext, int nStatus, Exception ex, string sStage)
        {
            return HandleError(sContext, nStatus, "Exception in RPAGrids.cs (" + sStage + "): '" + ex.Message.ToString() + "'");
        }
    }
}
