using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class TargetLegendGridData
    {
        private CStruct xGrid;
        private CStruct m_Par = new CStruct();
        public void InitializeGridData()
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateIntAttr("FilterEmpty", 1);

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_Par = xI;
        }

        public void AddRow(string Name, string srgb)
        {

            CStruct xI = m_Par.CreateSubStruct("I");

            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateIntAttr("NoColorState", 1);



            xI.CreateStringAttr("Key", Name);
            if (srgb != "")
                xI.CreateStringAttr("KeyColor", srgb);

        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }
}
