﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPMLiveCore;
using PortfolioEngineCore;

namespace ModelDataCache
{
    public abstract class GridBase
    {
        protected CStruct Constructor;
        protected readonly CStruct[] Levels = new CStruct[64];
        protected int Level = 0;
        protected CStruct Header1;
        protected CStruct Header2;
        protected CStruct PeriodCols;

        protected IList<PeriodData> Periods;
        protected IList<DetailRowData> DetailRows;
        
        public readonly bool UseGrouping;
        public readonly bool ShowFTEs;
        public readonly bool ShowGantt;
        public readonly DateTime DateStart;
        public readonly DateTime DateEnd;
        public readonly IList<SortFieldDefn> SortFields;
        public readonly int Freeze;
        public readonly bool UseQuantity;
        public readonly bool UseCost;
        public readonly bool ShowCostDetailed;
        public readonly int FromPeriodIndex;
        public readonly int ToPeriodIndex;

        public GridBase(
            bool useGrouping, 
            bool showFTEs, 
            bool showGantt, 
            DateTime dateStart, 
            DateTime dateEnd,
            IList<SortFieldDefn> sortFields,
            int detFreeze,
            bool useQuantity,
            bool useCost,
            bool showCostDetailed,
            int fromPeriodIndex,
            int toPeriodIndex)
        {
            UseGrouping = useGrouping;
            ShowFTEs = showFTEs;
            ShowGantt = showGantt;
            DateStart = dateStart;
            DateEnd = dateEnd;
            SortFields = sortFields;
            Freeze = detFreeze;
            UseQuantity = useQuantity;
            UseCost = useCost;
            ShowCostDetailed = showCostDetailed;
            FromPeriodIndex = fromPeriodIndex;
            ToPeriodIndex = toPeriodIndex;
        }

        protected bool CheckIfDetailRowShouldBeAdded(DetailRowData detailRow)
        {
            return detailRow.bRealone || detailRow.bGotChildren;
        }

        public void AddPeriodsData(IEnumerable<PeriodData> periods)
        {
            Periods = periods.ToArray();
        }

        public List<DetailRowData> AddDetailRowsData(IEnumerable<DetailRowData> detailRowsData)
        {
            var result = new List<DetailRowData>();
            foreach (var detailRow in detailRowsData)
            {
                if (CheckIfDetailRowShouldBeAdded(detailRow))
                {
                    result.Add(detailRow);
                }
            }

            DetailRows = result;
            return result;
        }

        public string RenderToXml(RenderingTypes renderingType)
        {
            if (renderingType == RenderingTypes.None)
            {
                throw new ArgumentException("renderingType");
            }

            Constructor = new CStruct();
            Constructor.Initialize("Grid");

            if (renderingType.HasFlag(RenderingTypes.Layout))
            {
                InitializeGridLayout(renderingType);

                if (Periods != null)
                {
                    AddPeriodColumns(Periods);
                }

                FinalizeGridLayout(renderingType);
            }

            if (renderingType.HasFlag(RenderingTypes.Data))
            {
                InitializeGridData(renderingType);

                if (DetailRows != null)
                {
                    for(var i = 0; i < DetailRows.Count; i++)
                    {
                        AddDetailRow(DetailRows[i], i);
                    }
                }
            }

            return Constructor.XML();
        }

        protected abstract void InitializeGridLayout(RenderingTypes renderingType);
        protected abstract void InitializeGridData(RenderingTypes renderingType);
        protected virtual void FinalizeGridLayout(RenderingTypes renderingType)
        {

        }

        protected abstract void AddDetailRow(DetailRowData detailRowData, int rowId);

        protected abstract string ResolvePeriodId(PeriodData periodData, int index);

        protected abstract string CleanUpString(string input);

        protected string RemoveCharacters(string input, string characters)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            var result = new StringBuilder(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (characters.IndexOf(input[i]) < 0)
                {
                    result.Append(input[i]);
                }
            }

            return result.ToString();
        }

        protected virtual void AddPeriodColumns(IEnumerable<PeriodData> periods)
        {
            var iNatural = 0;
            foreach(var period in periods)
            {
                iNatural++;

                if (iNatural >= FromPeriodIndex && iNatural <= ToPeriodIndex)
                {
                    AddPeriodColumn(ResolvePeriodId(period, iNatural), period.PeriodName);
                }
            }
        }

        private void AddPeriodColumn(string id, string name)
        {
            CStruct xC = null;

            if (UseQuantity)
            {
                if (UseCost)
                {
                    Header1.CreateStringAttr("P" + id + "VSpan", "2");
                }

                Header1.CreateStringAttr("P" + id + "V", name);
            }
            else
            {
                Header1.CreateStringAttr("P" + id + "C", name);
            }

            if (UseQuantity)
            {
                if (ShowFTEs)
                {
                    Header2.CreateStringAttr("P" + id + "V", " FTE ");
                }
                else
                {
                    Header2.CreateStringAttr("P" + id + "V", " Qty ");
                }
            }

            if (UseCost)
            {
                Header2.CreateStringAttr("P" + id + "C", " Cost ");
            }

            if (UseQuantity)
            {
                xC = PeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + id + "V");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", "#.##");
            }

            if (UseCost)
            {
                xC = PeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + id + "C");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", (ShowCostDetailed ? ",#.00;-,#.00;0" : ",0"));
            }
        }

        protected bool TryGetDataFromDetailRowDataField(DetailRowData detailRowData, int fid, out string value)
        {
            var result = true;
            value = null;

            switch (fid)
            {
                case (int)FieldIDs.SD_FID:
                    if (detailRowData.Det_Start != DateTime.MinValue)
                    {
                        value = detailRowData.Det_Start.ToShortDateString();
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                case (int)FieldIDs.FD_FID:
                    if (detailRowData.Det_Finish != DateTime.MinValue)
                    {
                        value = detailRowData.Det_Finish.ToShortDateString();
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                case (int)FieldIDs.FTOT_FID:
                    value = detailRowData.m_tot1.ToString();
                    break;
                case (int)FieldIDs.DTOT_FID:
                    value = detailRowData.m_tot2.ToString();
                    break;
                case (int)FieldIDs.PI_FID:
                    value = detailRowData.PI_Name;
                    break;
                case (int)FieldIDs.CT_FID:
                    value = detailRowData.CT_Name;
                    break;
                case (int)FieldIDs.SCEN_FID:
                    value = detailRowData.Scen_Name;
                    break;
                case (int)FieldIDs.BC_FID:
                    value = detailRowData.Cat_Name;
                    break;
                case (int)FieldIDs.FULLC_FID:
                    value = detailRowData.FullCatName;
                    break;
                case (int)FieldIDs.CAT_FID:
                    value = detailRowData.CC_Name;
                    break;
                case (int)FieldIDs.FULLCAT_FID:
                    value = detailRowData.FullCCName;
                    break;
                case (int)FieldIDs.BC_ROLE:
                    value = detailRowData.Role_Name;
                    break;
                case (int)FieldIDs.MC_FID:
                    value = detailRowData.MC_Name;
                    break;
                default:
                    if (fid >= 11801 && fid <= 11805)
                    {
                        value = detailRowData.Text_OCVal[fid - 11800];
                    }
                    else if (fid >= 11811 && fid <= 11815)
                    {
                        value = detailRowData.TXVal[fid - 11810];
                    }
                    else
                    {
                        value = " ";
                    }
                    break;
            }

            return result;
        }

        protected bool AddSortFieldsToColumns(CStruct xLeftCols, CStruct xCols, ref CStruct categoryColumn)
        {
            bool useCols = false;

            foreach (var sortField in SortFields)
            {
                var sortFieldName = CleanUpString(sortField.name);

                var h1 = GlobalConstants.Whitespace;
                var h2 = GlobalConstants.Whitespace;

                var indexOfSpace = sortField.name.IndexOf(GlobalConstants.Whitespace);
                if (indexOfSpace == -1)
                {
                    h1 = GlobalConstants.Whitespace;
                    h2 = sortField.name;
                }
                else
                {
                    h1 = sortField.name.Substring(0, indexOfSpace);
                    h2 = sortField.name.Substring(indexOfSpace + 1);
                }

                if (useCols)
                {
                    categoryColumn = xCols.CreateSubStruct("C");
                }
                else
                {
                    categoryColumn = xLeftCols.CreateSubStruct("C");
                }

                categoryColumn.CreateStringAttr("Name", sortFieldName);

                switch (sortField.fid)
                {
                    case (int)FieldIDs.SD_FID:
                    case (int)FieldIDs.FD_FID:
                        categoryColumn.CreateStringAttr("Type", "Date");
                        categoryColumn.CreateStringAttr("Format", "MM/dd/yyyy");
                        break;
                    case (int)FieldIDs.FTOT_FID:
                    case (int)FieldIDs.DTOT_FID:
                        categoryColumn.CreateStringAttr("Type", "Float");
                        categoryColumn.CreateStringAttr("Format", ",#.##");
                        break;
                    default:
                        categoryColumn.CreateStringAttr("Type", "Text");
                        break;
                }

                categoryColumn.CreateIntAttr("CanMove", 0);

                if (sortField.selected == 0)
                {
                    categoryColumn.CreateIntAttr("Width", 0);
                }

                categoryColumn.CreateBooleanAttr("CanEdit", false);
                Header1.CreateStringAttr(sortFieldName, h1);
                Header2.CreateStringAttr(sortFieldName, h2);

                if (sortField.fid == Freeze)
                {
                    useCols = true;
                }
            }

            return useCols;
        }

        protected CStruct InitializeGridLayoutConfig()
        {
            var config = Constructor.CreateSubStruct("Cfg");

            config.CreateIntAttr("MaxHeight", 0);
            config.CreateIntAttr("ShowDeleted", 0);
            config.CreateIntAttr("Deleting", 0);
            config.CreateIntAttr("Selecting", 0);
            config.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            config.CreateBooleanAttr("DateStrings", true);
            config.CreateBooleanAttr("NoTreeLines", true);
            config.CreateIntAttr("MaxWidth", 1);
            config.CreateIntAttr("AppendId", 0);
            config.CreateIntAttr("FullId", 0);
            config.CreateStringAttr("IdChars", "0123456789");
            config.CreateIntAttr("NumberId", 1);
            config.CreateIntAttr("Dragging", 0);
            config.CreateIntAttr("DragEdit", 0);
            config.CreateIntAttr("SuppressCfg", 3);
            config.CreateIntAttr("PrintCols", 0);
            config.CreateIntAttr("LeftWidth", 400);
            config.CreateStringAttr("IdPrefix", "R");
            config.CreateStringAttr("IdPostfix", "x");
            config.CreateIntAttr("CaseSensitiveId", 0);
            config.CreateStringAttr("Style", "GM");
            config.CreateStringAttr("CSS", "Modeler");
            config.CreateIntAttr("RightWidth", 800);
            config.CreateIntAttr("MinMidWidth", 200);
            config.CreateIntAttr("MinRightWidth", 400);
            config.CreateIntAttr("LeftCanResize", 1);
            config.CreateIntAttr("RightCanResize", 1);

            return config;
        }

        protected void InitializeGridLayoutDefinition()
        {
            var m_xDef = Constructor.CreateSubStruct("Def");
            var m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");

            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefTree.CreateIntAttr("NoColorState", 1);
        }

        protected void InitializeGridLayoutHeader1(CStruct xHead)
        {
            Header1 = xHead.CreateSubStruct("Header");
            Header1.CreateIntAttr("Spanned", -1);
            Header1.CreateIntAttr("SortIcons", 0);
            Header1.CreateStringAttr("HoverCell", "Color");
            Header1.CreateStringAttr("HoverRow", string.Empty);
        }

        protected void InitializeGridLayoutHeader2(CStruct xHead)
        {
            Header2 = xHead.CreateSubStruct("Header");
            Header2.CreateStringAttr("id", "Header");
            Header2.CreateIntAttr("SortIcons", 0);
            Header2.CreateStringAttr("HoverCell", "Color");
            Header2.CreateStringAttr("HoverRow", string.Empty);
        }

        protected abstract CStruct InitializeGridLayoutCategoryColumn(CStruct xLeftCols);

        [Flags]
        public enum RenderingTypes
        {
            None = 0,
            Layout = 1,
            Data = 2,
            Combined = Layout | Data
        }
    }
}