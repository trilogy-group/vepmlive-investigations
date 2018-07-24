using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class FilterGridCostsData
    {
        private CStruct xGrid;
        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;
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

            m_nLevel = 0;
            m_xLevels[m_nLevel] = xI;
        }
        public void AddRow(int rID, int level, string Name, bool Selected)
        {
            CStruct xIParent = null;

            if (level != 0)
                xIParent = m_xLevels[level - 1];
            else
                xIParent = m_xLevels[0];

            CStruct xI = xIParent.CreateSubStruct("I");

            if (level != 0)
                m_xLevels[level] = xI;

            xI.CreateStringAttr("id", rID.ToString());
            if (level == 1)
            {

                xI.CreateStringAttr("Color", "204,236,255");
                xI.CreateStringAttr("SelectType", "Text");
                xI.CreateStringAttr("Select", " ");
                xI.CreateBooleanAttr("SelectCanEdit", false);
            }
            else
            {
                xI.CreateStringAttr("Color", "254,254,254");

                xI.CreateStringAttr("Select", (Selected ? "1" : "0"));
                xI.CreateBooleanAttr("SelectCanEdit", true);
            }

            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateBooleanAttr("CanEdit", false);
            xI.CreateIntAttr("NoColorState", 1);



            xI.CreateStringAttr("Filtering", Name);

        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }
}
