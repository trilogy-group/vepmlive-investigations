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

            Constructor = new CStruct();
            Constructor.Initialize("Grid");
        }

        protected bool CheckIfDetailRowShouldBeAdded(DetailRowData detailRow)
        {
            return detailRow.bRealone || detailRow.bGotChildren;
        }

        protected void AddPeriodColumns(IEnumerable<PeriodData> periods, Func<PeriodData, int, string> columnIdFunc)
        {
            var iNatural = 0;
            foreach(var period in periods)
            {
                iNatural++;

                if (iNatural >= FromPeriodIndex && iNatural <= ToPeriodIndex)
                {
                    AddPeriodColumn(columnIdFunc(period, iNatural), period.PeriodName);
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

        public string GetString()
        {
            return Constructor.XML();
        }

        public virtual bool InitializeGridLayout()
        {
            return true;
        }
        
        public virtual void FinalizeGridLayout()
        {
        }

        public virtual bool InitializeGridData()
        {
            return true;
        }
    }
}
