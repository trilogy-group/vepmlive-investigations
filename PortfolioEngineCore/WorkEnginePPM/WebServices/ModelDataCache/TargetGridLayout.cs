using System.Collections.Generic;
using PortfolioEngineCore;

namespace ModelDataCache
{
    internal class TargetGridLayout
    {
        private CStruct xGrid;

        private CStruct m_xHeader1;
        private CStruct m_xHeader2;
        private CStruct m_xPeriodCols;
        
        public bool InitializeGridLayout(bool ShowFTEs, Dictionary<int, CustomFieldData> CustFields, int ratecount, string costtypejsonMenu, string costcatjsonMenu, int MC_Count)
        {
            CStruct xC = null;

            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("ColResizing", 1);


            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateBooleanAttr("NoTreeLines", true);

            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("FilterEmpty", 1);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            xCfg.CreateIntAttr("ExportFormat", 1);

            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);


            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateStringAttr("Style", "GM");




            //xCfg.CreateIntAttr("ConstHeight", 0);
            //xCfg.CreateIntAttr("ConstWidth", 1);

            // xCfg.CreateIntAttr("MaxHeight", 300);

            //        xCfg.CreateIntAttr("ResizingMain", 3);
            //        xCfg.CreateIntAttr("ResizingMainLap", 1);



            //       xCfg.CreateIntAttr("ShowVScroll", 1);

            //       xCfg.CreateIntAttr("ExactSize", 0);





            xCfg.CreateStringAttr("CSS", "Modeler");

            xCfg.CreateIntAttr("LeftWidth", 400);



            xCfg.CreateIntAttr("SuppressCfg", 1);
            xCfg.CreateIntAttr("PrintCols", 0);

            xCfg.CreateIntAttr("Sorting", 0);


            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            m_xPeriodCols = xGrid.CreateSubStruct("Cols");
            //           m_xPeriodCols = xGrid.CreateSubStruct("RightCols");

            CStruct xHead = xGrid.CreateSubStruct("Head");
            m_xHeader1 = xHead.CreateSubStruct("Header");
            m_xHeader2 = xHead.CreateSubStruct("Header");

            m_xHeader2.CreateStringAttr("id", "Header");
            m_xHeader2.CreateIntAttr("SortIcons", 0);

            m_xHeader1.CreateIntAttr("Spanned", -1);
            m_xHeader1.CreateIntAttr("SortIcons", 0);

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Select");
            xC.CreateStringAttr("Type", "Bool");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Width", "20");
            m_xHeader1.CreateStringAttr("Select", " ");
            m_xHeader2.CreateStringAttr("Select", " ");


            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "GroupVal");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateBooleanAttr("Visible", false);
            m_xHeader1.CreateStringAttr("GroupVal", "Group");
            m_xHeader2.CreateStringAttr("GroupVal", "Value");

            // Add category column
            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateStringAttr("Name", "CostType");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateStringAttr("Defaults", costtypejsonMenu);
            m_xHeader1.CreateStringAttr("CostType", "Cost");
            m_xHeader2.CreateStringAttr("CostType", "Type");


            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "CostCategory");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateStringAttr("Defaults", costcatjsonMenu);
            m_xHeader1.CreateStringAttr("CostCategory", "Cost");
            m_xHeader2.CreateStringAttr("CostCategory", "Category");

            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "MajorCategory");
            xC.CreateBooleanAttr("CanEdit", false);

            if (MC_Count <= 1)
                xC.CreateIntAttr("Visible", 0);

            m_xHeader1.CreateStringAttr("MajorCategory", "Major");
            m_xHeader2.CreateStringAttr("MajorCategory", "Category");

            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "Role");
            xC.CreateBooleanAttr("CanEdit", false);
            m_xHeader1.CreateStringAttr("Role", " ");
            m_xHeader2.CreateStringAttr("Role", "Role");

            if (ratecount != 0)
            {

                xC = xLeftCols.CreateSubStruct("C");

                xC.CreateStringAttr("Name", "NamedRate");
                xC.CreateBooleanAttr("CanEdit", false);
                m_xHeader1.CreateStringAttr("NamedRate", "Named ");
                m_xHeader2.CreateStringAttr("NamedRate", "Rate");
            }


            foreach (CustomFieldData oc in CustFields.Values)
            {
                xC = xLeftCols.CreateSubStruct("C");

                xC.CreateStringAttr("Name", "z" + oc.Name);

                if (oc.jsonMenu == "")
                    xC.CreateBooleanAttr("CanEdit", true);
                else
                {
                    xC.CreateBooleanAttr("CanEdit", false);
                    xC.CreateStringAttr("Defaults", oc.jsonMenu);
                }
                m_xHeader1.CreateStringAttr("z" + oc.Name, " ");
                m_xHeader2.CreateStringAttr("z" + oc.Name, oc.DisplayName);

            }



            return true;
        }
        public void AddPeriodColumn(string sId, string sName, bool ShowFTEs)
        {
            CStruct xC = null;

            m_xHeader1.CreateStringAttr("P" + sId + "VSpan", "2");
            m_xHeader1.CreateStringAttr("P" + sId + "V", sName);

            if (ShowFTEs)
                m_xHeader2.CreateStringAttr("P" + sId + "V", " FTE ");
            else
                m_xHeader2.CreateStringAttr("P" + sId + "V", " Qty ");

            m_xHeader2.CreateStringAttr("P" + sId + "C", " Cost ");

            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P" + sId + "V");
            xC.CreateStringAttr("Type", "Float");
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Format", "0.###");

            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P" + sId + "C");
            xC.CreateStringAttr("Type", "Float");
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Format", "#.##");
        }

        public void FinalizeGridLayout()
        {
        }

        public string GetString()
        {
            return xGrid.XML();
        }
    }
}
