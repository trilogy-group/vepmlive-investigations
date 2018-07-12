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

        protected GridBase()
        {
            Constructor = new CStruct();
            Constructor.Initialize("Grid");
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

        public void AddPeriodColumn(string id, string name, bool showFTEs, bool useQuantity, bool useCost, bool bShowdeccosts)
        {
            CStruct xC = null;

            if (useQuantity)
            {
                if (useCost)
                {
                    Header1.CreateStringAttr("P" + id + "VSpan", "2");
                }

                Header1.CreateStringAttr("P" + id + "V", name);
            }
            else
            {
                Header1.CreateStringAttr("P" + id + "C", name);
            }

            if (useQuantity)
            {
                if (showFTEs)
                {
                    Header2.CreateStringAttr("P" + id + "V", " FTE ");
                }
                else
                {
                    Header2.CreateStringAttr("P" + id + "V", " Qty ");
                }
            }

            if (useCost)
            {
                Header2.CreateStringAttr("P" + id + "C", " Cost ");
            }

            if (useQuantity)
            {
                xC = PeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + id + "V");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", "#.##");
            }

            if (useCost)
            {
                xC = PeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + id + "C");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", (bShowdeccosts ? ",#.00;-,#.00;0" : ",0"));
            }
        }

        public string GetString()
        {
            return Constructor.XML();
        }
    }
}
