using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public readonly int DetFreeze;
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
            DetFreeze = detFreeze;
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

        private void AddPeriodColumns(IEnumerable<PeriodData> periods)
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


        [Flags]
        public enum RenderingTypes
        {
            Layout = 1,
            Data = 2,
            Combined = Layout | Data
        }
    }
}
