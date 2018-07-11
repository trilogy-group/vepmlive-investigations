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

        public void AddPeriodColumn(string sId, string sName, bool ShowFTEs, bool bUseQTY, bool bUseCost, bool bShowdeccosts)
        {
            CStruct xC = null;

            if (bUseQTY && bUseCost)
            {
                Header1.CreateStringAttr("P" + sId + "VSpan", "2");
                Header1.CreateStringAttr("P" + sId + "V", sName);
            }
            else if (bUseQTY)
            {
                Header1.CreateStringAttr("P" + sId + "V", sName);
            }
            else
                Header1.CreateStringAttr("P" + sId + "C", sName);

            if (bUseQTY)
            {
                if (ShowFTEs)
                    Header2.CreateStringAttr("P" + sId + "V", " FTE ");
                else
                    Header2.CreateStringAttr("P" + sId + "V", " Qty ");
            }

            if (bUseCost)
                Header2.CreateStringAttr("P" + sId + "C", " Cost ");

            if (bUseQTY)
            {
                xC = PeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + sId + "V");
                xC.CreateStringAttr("Type", "Float");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateStringAttr("Format", "#.##");
            }

            if (bUseCost)
            {

                xC = PeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "P" + sId + "C");
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
