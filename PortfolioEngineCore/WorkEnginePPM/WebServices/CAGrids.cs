using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Linq;
using WorkEnginePPM;
using CostDataValues;
using CADataCache;
using PortfolioEngineCore;


namespace CADataCache
{
    internal class CALegendGrid
    {
        private CStruct xGrid;
        private CStruct m_Par = new CStruct();

        public void InitializeGridLayout()
        {


            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);
            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 1);
            xPanel.CreateIntAttr("Delete", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("FilterEmpty", 1);
            xCfg.CreateIntAttr("SuppressMessage", 3);

            xCfg.CreateBooleanAttr("NoTreeLines", true);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("DragEdit", 0);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("HideHScroll", 1);


            //xCfg.CreateIntAttr("ExactSize", 0);
            xCfg.CreateIntAttr("SelectingCells", 1);





            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("FilterEmpty", 1);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");

            xCfg.CreateStringAttr("IdPrefix", "R");
            xCfg.CreateStringAttr("IdPostfix", "x");
            xCfg.CreateIntAttr("CaseSensitiveId", 0);



            CStruct xCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xHead = xGrid.CreateSubStruct("Header");

            xHead.CreateIntAttr("Visible", 0);
            // Add category column
            CStruct xC = xCols.CreateSubStruct("C");


            xC = xCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Key");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("Width", 400);
            xC.CreateBooleanAttr("CanEdit", false);
            xHead.CreateStringAttr("Key", " ");

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_Par = xI;
        }


        public string GetString()
        {
            return xGrid.XML();
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

    }

    internal class TargetGrid
    {
        private CStruct xGrid;

        private CStruct m_xHeader1;
        private CStruct m_xHeader2;
        private CStruct m_xPeriodCols;
        private CStruct m_xIParentRoot;
        private CStruct m_xDef;
        private CStruct m_xDefTree;
        private CStruct m_xDefNode;

        private void DoDefNodeBit(string sn)
        {

            m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");

 
            m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
            m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");
            m_xDefNode.CreateBooleanAttr(sn + "CanEdit", false);
        }

        public bool InitializeGridLayout(bool ShowFTEs, Dictionary<int, clsCustomFieldData> CustFields, int ratecount, string costtypejsonMenu, string costcatjsonMenu, int MC_Count)
        {

            CStruct xC = null;

            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            xPanel.CreateIntAttr("CanHide", 0);
            xPanel.CreateIntAttr("CanSelect", 0);

            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            xCfg.CreateStringAttr("MainCol", "CostCategory");
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateIntAttr("Deleting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("ColResizing", 1);
            xCfg.CreateIntAttr("ExpandAllLevels", 3);


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





            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");

            xCfg.CreateIntAttr("LeftWidth", 400);

            xCfg.CreateIntAttr("GroupSortMain", 1);
            xCfg.CreateIntAttr("GroupRestoreSort", 1);

            xCfg.CreateIntAttr("SuppressCfg", 1);
            xCfg.CreateIntAttr("PrintCols", 0);

            xCfg.CreateIntAttr("Sorting", 0);



            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            m_xPeriodCols = xGrid.CreateSubStruct("Cols");
            //           m_xPeriodCols = xGrid.CreateSubStruct("RightCols");

            m_xDef = xGrid.CreateSubStruct("Def");

            m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");
            m_xDefTree.CreateStringAttr("Calculated", "1");
            m_xDefTree.CreateStringAttr("Calculated", "1");
              

            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateIntAttr("NoColorState", 1);
//            m_xDefTree.CreateIntAttr("CanExpand", 0);
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");





            m_xDefNode = m_xDef.CreateSubStruct("D");
            m_xDefNode.CreateStringAttr("Name", "Leaf");
            m_xDefNode.CreateStringAttr("Calculated", "0");

            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("HoverRow", "Color");
            m_xDefNode.CreateStringAttr("FocusCell", "");
            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefNode.CreateIntAttr("NoColorState", 1);



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

            m_xDefTree.CreateBooleanAttr("SelectCanEdit", false);
 //           m_xDefTree.CreateStringAttr("SelectType", "Text");
            m_xDefNode.CreateBooleanAttr("SelectCanEdit", true);


            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "rowid");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateBooleanAttr("Visible", false);
            m_xHeader1.CreateStringAttr("rowid", " ");
            m_xHeader2.CreateStringAttr("rowid", " ");

            // Add category column

             m_xDefTree.CreateStringAttr("rowid", "");


            CStruct xSolid = xGrid.CreateSubStruct("Solid");
            CStruct xGroup = xSolid.CreateSubStruct("Group");

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateStringAttr("Name", "CostType");
            xC.CreateBooleanAttr("Visible", false); 
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateStringAttr("Defaults", costtypejsonMenu);
            m_xHeader1.CreateStringAttr("CostType", "Cost");
            m_xHeader2.CreateStringAttr("CostType", "Type");

            DoDefNodeBit("CostType");


            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "CostCategory");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateStringAttr("Defaults", costcatjsonMenu);
            m_xHeader1.CreateStringAttr("CostCategory", "Cost");
            m_xHeader2.CreateStringAttr("CostCategory", "Category");
            DoDefNodeBit("CostCategory");

            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "MajorCategory");
            xC.CreateBooleanAttr("CanEdit", false);

            if (MC_Count <= 1)
                xC.CreateIntAttr("Visible", 0);

            m_xHeader1.CreateStringAttr("MajorCategory", "Major");
            m_xHeader2.CreateStringAttr("MajorCategory", "Category");
            DoDefNodeBit("MajorCategory");
            xC = xLeftCols.CreateSubStruct("C");

            xC.CreateStringAttr("Name", "Role");
            xC.CreateBooleanAttr("CanEdit", false);
            DoDefNodeBit("Role");
            m_xHeader1.CreateStringAttr("Role", " ");
            m_xHeader2.CreateStringAttr("Role", "Role");

            if (ratecount != 0)
            {

                xC = xLeftCols.CreateSubStruct("C");

                xC.CreateStringAttr("Name", "NamedRate");
                xC.CreateBooleanAttr("CanEdit", false);
                DoDefNodeBit("NamedRate");
                m_xHeader1.CreateStringAttr("NamedRate", "Named ");
                m_xHeader2.CreateStringAttr("NamedRate", "Rate");
            }


            foreach (clsCustomFieldData oc in CustFields.Values)
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
                DoDefNodeBit("z" + oc.Name);
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

            string sFunc = "(Row.id == 'Filter' ? '' : sum())";


            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P" + sId + "V");
            xC.CreateStringAttr("Type", "Float");
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Format", "0.###");

            m_xDefTree.CreateStringAttr("P" + sId + "V" + "Formula", sFunc);
            m_xDefTree.CreateStringAttr("P" + sId + "V" + "Format", "0.###");
            m_xDefTree.CreateBooleanAttr("P" + sId + "V" + "CanEdit", false);
            m_xDefNode.CreateStringAttr("P" + sId + "V" + "Formula", "");

            xC = m_xPeriodCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P" + sId + "C");
            xC.CreateStringAttr("Type", "Float");
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateStringAttr("Format", "#.##");


             m_xDefTree.CreateStringAttr("P" + sId + "C" + "Formula", sFunc);
             m_xDefTree.CreateStringAttr("P" + sId + "C" + "Format", "#.##");
             m_xDefTree.CreateBooleanAttr("P" + sId + "C" + "CanEdit", false);
             m_xDefNode.CreateStringAttr("P" + sId + "C" + "Formula", "");

        }
        public void FinalizeGridLayout()
        {
            //m_xTabber.CreateStringAttr("Cells", m_sTabCells);


        }

        public bool InitializeGridData()
        {
            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");
            xI.CreateStringAttr("Grouping", "Totals");
            xI.CreateBooleanAttr("CanEdit", false);

            m_xIParentRoot = xI;
            return true;
        }
        public void AddDetailRow(clsDetailRowData oDet, int rID, bool ShowFTEs, int maxp, Dictionary<int, clsCustomFieldData> CustFields, int ratecount)
        {
            CStruct xIParent = m_xIParentRoot;
            CStruct xI = xIParent.CreateSubStruct("I");

            xI.CreateStringAttr("id", rID.ToString());
            xI.CreateStringAttr("rowid", rID.ToString());
            xI.CreateStringAttr("Def", "Leaf");


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


            foreach (clsCustomFieldData oc in CustFields.Values)
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

            string suom = "";

            if (oDet.sUoM != null)
            {
                suom = oDet.sUoM.Trim();
            }

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

  


                if (suom == "")
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