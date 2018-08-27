using System.Collections.Generic;
using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class TargetGridsData
    {
        private CStruct xGrid;
        private CStruct m_xIParentRoot;

        public bool InitializeGridData()
        {
            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            //xCfg.CreateStringAttr("id", "EditCostsGrid");
            //xCfg.CreateStringAttr("id", "g_" + CostTypeId.ToString());
            xCfg.CreateIntAttr("FilterEmpty", 1);


            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_xIParentRoot = xI;
            return true;
        }
        public void AddDetailRow(DetailRowData oDet, int rID, bool ShowFTEs, int maxp, Dictionary<int, CustomFieldData> CustFields, int ratecount)
        {
            CStruct xIParent = m_xIParentRoot;
            CStruct xI = xIParent.CreateSubStruct("I");

            xI.CreateStringAttr("id", rID.ToString());


            xI.CreateStringAttr("CostType", oDet.CT_Name);
            xI.CreateStringAttr("CostCategory", oDet.FullCatName);

            xI.CreateStringAttr("CostTypeButton", "Defaults");
            xI.CreateStringAttr("CostCategoryButton", "Defaults");

            xI.CreateStringAttr("MajorCategory", oDet.MC_Name);
            xI.CreateIntAttr("MajorCategoryCanEdit", 0);
            xI.CreateStringAttr("Role", oDet.Role_Name);
            xI.CreateIntAttr("RoleCanEdit", 0);
            if (ratecount != 0)
            {
                xI.CreateStringAttr("NamedRate", oDet.m_rt_name);
            }


            foreach (CustomFieldData oc in CustFields.Values)
            {
                string stxt;

                if (oc.FieldID < 11810)
                    stxt = oDet.Text_OCVal[oc.FieldID - 11800];
                else
                    stxt = oDet.TXVal[oc.FieldID - 11810];

                xI.CreateStringAttr("z" + oc.Name, stxt);

                if (oc.jsonMenu != "")
                    xI.CreateStringAttr("z" + oc.Name + "Button", "Defaults");

            }


            xI.CreateIntAttr("NoColorState", 1);


            for (int i = 0; i <= maxp; i++)
            {
                if (ShowFTEs)
                {
                    if (oDet.zFTE[i] != double.MinValue)
                        xI.CreateDoubleAttr("P" + i.ToString() + "V", oDet.zFTE[i]);
                }
                else
                {
                    if (oDet.zValue[i] != double.MinValue)
                        xI.CreateDoubleAttr("P" + i.ToString() + "V", oDet.zValue[i]);
                }

                if (oDet.zCost[i] != double.MinValue)
                    xI.CreateDoubleAttr("P" + i.ToString() + "C", oDet.zCost[i]);


                if (oDet.sUoM == "")
                {
                    xI.CreateIntAttr("P" + i.ToString() + "VCanEdit", 0);
                    xI.CreateIntAttr("P" + i.ToString() + "CCanEdit", 1);
                }
                else
                {
                    xI.CreateIntAttr("P" + i.ToString() + "CCanEdit", 0);
                    xI.CreateIntAttr("P" + i.ToString() + "VCanEdit", 1);
                }
            }
        }
        public string GetString()
        {
            return xGrid.XML();
        }
    }
}
