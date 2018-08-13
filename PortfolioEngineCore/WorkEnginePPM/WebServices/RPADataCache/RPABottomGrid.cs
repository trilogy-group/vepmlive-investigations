using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint.Administration;
using PortfolioEngineCore;
using ResourceValues;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace RPADataCache
{
    internal class RPABottomGrid : RPADataCacheGridBase
    {
        private readonly bool _isLayoutByRole;
        private readonly string _roleHeader;

        protected CStruct DefinitionPI;

        public RPABottomGrid(
            bool isLayoutByRole,
            string roleHeader,
            IList<clsRXDisp> columns, 
            int pmoAdmin, 
            string xmlString, 
            int displayMode, 
            IList<RPATGRow> displayList, 
            clsResourceValues resourceValues, 
            clsLookupList categoryLookupList) 
        : base(columns, pmoAdmin, xmlString, displayMode, displayList, resourceValues, categoryLookupList)
        {
            _isLayoutByRole = isLayoutByRole;
            _roleHeader = roleHeader;
        }

        protected override void InitializeGridLayout(GridRenderingTypes renderingType)
        {
            if (renderingType == GridRenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

            var xToolbar = Constructor.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            var xMenuc = Constructor.CreateSubStruct("MenuCfg");

            var xPanel = Constructor.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            var xCfg = InitializeGridLayoutConfig("ResOrRole", 1, 0, 400, 400);
            xCfg.CreateIntAttr("ConstHeight", 1);
            xCfg.CreateIntAttr("LeftCanResize", 0);

            var xLeftCols = Constructor.CreateSubStruct("LeftCols");
            var xCols = Constructor.CreateSubStruct("Cols");
            var xRightCols = Constructor.CreateSubStruct("RightCols");
            PeriodCols = xRightCols;

            var m_xDef = Constructor.CreateSubStruct("Def");
            DefinitionRight = InitializeGridLayoutDefinition("R", m_xDef, true);
            DefinitionLeaf = InitializeGridLayoutDefinition("Leaf", m_xDef, false);
            DefinitionPI = InitializeGridLayoutDefinition("Leaf", m_xDef, false);

            var xHead = Constructor.CreateSubStruct("Head");
            InitializeGridLayoutHeader1(xHead, 1, 2);

            var categoryColumn = InitializeGridLayoutCategoryColumns(xLeftCols).Last();
            DefinitionRight.CreateBooleanAttr("rtSelectCanEdit", true);
            DefinitionLeaf.CreateStringAttr("IconFlag", "/_layouts/ppm/images/Nogif.gif");

            var xSolid = Constructor.CreateSubStruct("Solid");
            var xGroup = xSolid.CreateSubStruct("Group");

            foreach (var column in _columns)
            {
                categoryColumn = InitializeViewColumn(xCols, categoryColumn, column);
            }
        }

        private IEnumerable<CStruct> InitializeGridLayoutCategoryColumns(CStruct xLeftCols)
        {
            var categoryColumn = CreateColumn(xLeftCols, "RowSel", "Icon",
                width: 20,
                canMove: false,
                canExport: false,
                canEdit: false,
                canHide: null,
                canSelect: null);
            categoryColumn.CreateStringAttr("Color", "rgb(223, 227, 232)");
            Header1.CreateStringAttr("RowSel", GlobalConstants.Whitespace);
            Header2.CreateStringAttr("RowSel", GlobalConstants.Whitespace);
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "rowid", "Int",
                visible: false,
                canExport: false);
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "IconFlag", "Icon",
                width: 20,
                visible: true,
                canMove: false);
            Header1.CreateStringAttr("IconFlag", GlobalConstants.Whitespace);
            yield return categoryColumn;

            categoryColumn = CreateColumn(xLeftCols, "rtSelect", "Bool",
                width: 20,
                visible: true,
                canEdit: true,
                canMove: false);
            categoryColumn.CreateStringAttr("Class", string.Empty);
            Header1.CreateString("rtSelect", GlobalConstants.Whitespace);
            Header2.CreateString("rtSelect", GlobalConstants.Whitespace);
            yield return categoryColumn;
        }

        private CStruct InitializeViewColumn(CStruct xCols, CStruct categoryColumn, clsRXDisp col)
        {
            try
            {
                if (col.m_id == RPConstants.TGRID_TOTITEM_ID
                    || col.m_id == RPConstants.TGRID_TOTRESRES_ID
                    || _isLayoutByRole == false)
                {
                    var sn = RemoveCharacters(col.m_realname, " \r\n")
                        .Replace("/n", string.Empty);

                    var snv = col.m_dispname.Replace("/n", "\n");

                    if (col.m_id == RPConstants.TGRID_TOTRESRES_ID)
                    {
                        snv = _roleHeader;
                        sn = "ResOrRole";
                    }

                    categoryColumn = xCols.CreateSubStruct("C");
                    if (col.m_id > 100)
                    {
                        sn = "x" + sn;
                    }
                    categoryColumn.CreateStringAttr("Name", sn);
                    categoryColumn.CreateIntAttr("ShowHint", 0);
                    categoryColumn.CreateStringAttr("Class", "GMCellMain");

                    DefinitionRight.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                    DefinitionRight.CreateStringAttr(sn + "HtmlPostfix", "</B>");
                    DefinitionLeaf.CreateStringAttr(sn + "HtmlPrefix", string.Empty);
                    DefinitionLeaf.CreateStringAttr(sn + "HtmlPostfix", string.Empty);
                    DefinitionPI.CreateStringAttr(sn + "HtmlPrefix", string.Empty);
                    DefinitionPI.CreateStringAttr(sn + "HtmlPostfix", string.Empty);

                    switch (col.m_type)
                    {
                        case 2:
                            break;
                        case 3:
                            categoryColumn.CreateStringAttr("Type", "Float");
                            categoryColumn.CreateStringAttr("Format", ",0.##");
                            break;
                        default:
                            categoryColumn.CreateStringAttr("Type", "Text");
                            break;
                    }

                    if (sn.Equals(RPConstants.CONST_PRIORITY))
                    {
                        categoryColumn.CreateStringAttr("NumberSort", "1");
                    }

                    categoryColumn.CreateIntAttr("CanEdit", 0);
                    categoryColumn.CreateIntAttr("CanMove", 1);
                    categoryColumn.CreateIntAttr("CanSort", 1);
                    categoryColumn.CreateIntAttr("CaseSensitive", 0);

                    if (col.m_col_hidden == true)
                    {
                        categoryColumn.CreateIntAttr("Width", 0);
                    }

                    Header1.CreateStringAttr(sn, snv);
                    Header1.CreateIntAttr(sn + "SortIcons", 1);
                    Header2.CreateStringAttr(sn, GlobalConstants.Whitespace);
                }
            }
            catch (Exception ex)
            {
                WriteTrace(
                    Area.EPMLiveWorkEnginePPM,
                    Categories.EPMLiveWorkEnginePPM.Others,
                    TraceSeverity.VerboseEx,
                    ex.ToString());
            }

            return categoryColumn;
        }

        protected override string ResolvePeriodId(CPeriod periodData, int index)
        {
            throw new NotImplementedException();
        }

        protected override void AddPeriodColumns(IEnumerable<CPeriod> periods)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckIfDetailRowShouldBeAdded(Tuple<clsResXData, clsPIData> detailRow)
        {
            throw new NotImplementedException();
        }

        protected override void AddDetailRow(Tuple<clsResXData, clsPIData> detailRowData, int rowId)
        {
            throw new NotImplementedException();
        }

        protected override void InitializeGridData(GridRenderingTypes renderingType)
        {
            throw new NotImplementedException();
        }
    }
}
