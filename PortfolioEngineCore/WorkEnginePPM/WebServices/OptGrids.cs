using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Linq;
using WorkEnginePPM;
using OptmizerDataCache;
using PortfolioEngineCore;

namespace OptmizerDataCache
{
    internal class OptTopGrid
    {
        private CStruct xGrid;
        private CStruct m_xMiddleCols;
        private CStruct m_xHeader1;
  //      private CStruct m_xHeader2;
        private CStruct m_xDef;
        private CStruct m_xDefTree;
        private CStruct m_xDefNode;

        private CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;


        public bool InitializeGridLayout(List<clsOptFieldDelf> fielddef, int curr_pos, int curr_digits, string curr_sym)
        {
            string InOutAutojsonMenu = "{Items:[" + "{Name:'1',Text:'In',Value:'In'},{Name:'2',Text:'Out',Value:'Out'},{Name:'3',Text:'Auto',Value:'Auto'}" + "]}";

// set up the currency formatting
            string currfmt;
    
            if (curr_digits == 0)
                currfmt = ",0";
            else if (curr_digits == 1)
                currfmt = ",0.0";
           else if (curr_digits == 0 || curr_digits == 2)
                currfmt = ",0.00";
            else
                currfmt = ",0.000";

            if  (curr_pos == 0)
                currfmt = curr_sym + currfmt;
            else if (curr_pos == 2)
                currfmt = curr_sym + " " + currfmt;
            else if (curr_pos == 1)
                currfmt = currfmt + curr_sym;
            else
                currfmt = currfmt + " " + curr_sym;
 
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
            xCfg.CreateStringAttr("MainCol", "PISelected");

            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("SuppressMessage", 3);


            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("Sorting", 1);
            xCfg.CreateIntAttr("ColsMoving", 1);
            xCfg.CreateIntAttr("ColsPosLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateIntAttr("VisibleLap", 1);
            xCfg.CreateIntAttr("SectionWidthLap", 1);
 //           xCfg.CreateIntAttr("GroupLap", 1);
            xCfg.CreateIntAttr("WideHScroll", 0);
            xCfg.CreateIntAttr("LeftWidth", 150);
            xCfg.CreateIntAttr("Width", 400);
            xCfg.CreateIntAttr("RightWidth", 800);
            xCfg.CreateIntAttr("MinMidWidth", 50);
            xCfg.CreateIntAttr("MinRightWidth", 400);
            xCfg.CreateIntAttr("LeftCanResize", 0);
            xCfg.CreateIntAttr("RightCanResize", 1);
            xCfg.CreateIntAttr("FocusWholeRow", 1);



            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateBooleanAttr("DateStrings", true);
            //     xCfg.CreateIntAttr("MinRowHeight",26);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("MaxSort", 2);
            //     xCfg.CreateStringAttr("DefaultSort", "PortfolioItem");
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "ResPlanAnalyzer");
            xCfg.CreateIntAttr("FastColumns", 1);
            xCfg.CreateIntAttr("ExpandAllLevels", 3);
   //         xCfg.CreateIntAttr("GroupSortMain", 1);
   //         xCfg.CreateIntAttr("GroupRestoreSort", 1);


            xCfg.CreateIntAttr("NoTreeLines", 1);
            xCfg.CreateIntAttr("ShowVScroll", 1);

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");

            m_xMiddleCols = xCols;

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
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");



            m_xDefTree.CreateIntAttr("ReCalc", 256);


            m_xDefNode = m_xDef.CreateSubStruct("D");
            m_xDefNode.CreateStringAttr("Name", "Leaf");
            m_xDefNode.CreateStringAttr("Calculated", "0");

            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("HoverRow", "Color");
            m_xDefNode.CreateStringAttr("FocusCell", "");
            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefNode.CreateIntAttr("NoColorState", 1);
            m_xDefNode.CreateIntAttr("ReCalc", 256);

            CStruct xHead = xGrid.CreateSubStruct("Head");


            m_xHeader1 = xGrid.CreateSubStruct("Header");
   //         m_xHeader1.CreateIntAttr("PISelected", 1);
            m_xHeader1.CreateIntAttr("Spanned", 1);
            m_xHeader1.CreateIntAttr("SortIcons", 2);
            //        m_xHeader1.CreateStringAttr("Def", "Tree");

            m_xHeader1.CreateStringAttr("HoverCell", "Color");
            m_xHeader1.CreateStringAttr("HoverRow", "");




            CStruct xC;

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "rowid");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("Visible", 0);

            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);

            m_xDefTree.CreateStringAttr("rowid", "");

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "pid");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("Visible", 0);

            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSelect", 0);

            m_xDefTree.CreateStringAttr("pid", "");

   //         CStruct xSolid = xGrid.CreateSubStruct("Solid");
   //         CStruct xGroup = xSolid.CreateSubStruct("Group");


            string sn; 

            xC = xCols.CreateSubStruct("C");

            sn = "PISelected";
            xC.CreateStringAttr("Name", sn);
            xC.CreateStringAttr("Class", "GMCellMain");
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("Width", 120);
            xC.CreateIntAttr("CaseSensitive", 0);
            xC.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
            m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");
            xC.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(sn, "Selected");
            xC.CreateIntAttr("CanHide", 0);

            sn = "PIName";
            xC = xCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", sn);
            xC.CreateStringAttr("Class", "GMCellMain");
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CaseSensitive", 0);
            xC.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
            m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");
            xC.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(sn, "Item Name");
            xC.CreateIntAttr("CanHide", 0);

            xC = xCols.CreateSubStruct("C");
            sn = "PIStatus";
            xC.CreateStringAttr("Name", sn);
            xC.CreateStringAttr("Class", "GMCellMain");
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CaseSensitive", 0);

            xC.CreateStringAttr("Defaults", InOutAutojsonMenu);


            xC.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
            m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");
            xC.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(sn, "Selection");
            xC.CreateIntAttr("CanHide", 0);
           

            xC = xCols.CreateSubStruct("C");

            sn = "PIStart";
            xC.CreateStringAttr("Name", "PIStart");
            xC.CreateStringAttr("Class", "GMCellMain");
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CaseSensitive", 0);
            xC.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
            m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");
            xC.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(sn, "Start");

            xC = xCols.CreateSubStruct("C");

            sn = "PIFinish";
            xC.CreateStringAttr("Name", "PIFinish");
            xC.CreateStringAttr("Class", "GMCellMain");
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CaseSensitive", 0);
            xC.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
            m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");
            xC.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(sn, "Finish");





            foreach (clsOptFieldDelf col in fielddef)
            {
                try
                {


                    sn = col.fname.Replace("/n", "");
                    sn = sn.Replace(" ", "");
                    sn = sn.Replace("\r", "");
                    sn = sn.Replace("\n", "");
                    string snv = col.fname.Replace("/n", "\n");

                    sn = "zX" + sn;

                    xC = xCols.CreateSubStruct("C");

                    xC.CreateStringAttr("Name", sn);
                    xC.CreateStringAttr("Class", "GMCellMain");
                    xC.CreateIntAttr("CanDrag", 0);

                    if (col.fname != "Budget")
                        xC.CreateIntAttr("Visible", 0);

                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateIntAttr("CaseSensitive", 0);
                    xC.CreateStringAttr("OnDragCell", "Focus,DragCell");
                    m_xDefTree.CreateIntAttr(sn + "CanDrag", 0);


                    m_xDefTree.CreateStringAttr(sn + "HtmlPrefix", "<B>");
                    m_xDefTree.CreateStringAttr(sn + "HtmlPostfix", "</B>");

                    m_xDefNode.CreateIntAttr(sn + "CanDrag", 0);

                    m_xDefNode.CreateStringAttr(sn + "HtmlPrefix", "");
                    m_xDefNode.CreateStringAttr(sn + "HtmlPostfix", "");

                    string sFunc = "(Row.id == 'Filter' ? '' : sum())";




                    if (col.ftype == 2)
                    {
                        xC.CreateStringAttr("Type", "Text");
                        //                       xC.CreateStringAttr("Type", "Date");
                        //                       xC.CreateStringAttr("Format", "MM/dd/yyyy");
                    }
                    else if (col.ftype == 3)
                    {
                        xC.CreateStringAttr("Type", "Float");
                        xC.CreateStringAttr("Format", ",0.##");
                        m_xDefTree.CreateStringAttr(sn + "Formula", sFunc);
                        m_xDefTree.CreateStringAttr(sn + "Format", ",0.##");
                        m_xDefNode.CreateStringAttr(sn + "Formula", "");
                    }
                    else if (col.ftype == 8)
                    {
                        xC.CreateStringAttr("Type", "Float");
                        xC.CreateStringAttr("Format", currfmt);
                        m_xDefTree.CreateStringAttr(sn + "Formula", sFunc);
                        m_xDefTree.CreateStringAttr(sn + "Format", currfmt);
                        m_xDefNode.CreateStringAttr(sn + "Formula", "");
                    }
                    else
                        xC.CreateStringAttr("Type", "Text");

                    xC.CreateIntAttr("CanEdit", 0);
                    xC.CreateIntAttr("CanMove", 1);

                    m_xHeader1.CreateStringAttr(sn, snv);
       //             m_xHeader2.CreateStringAttr(sn, " ");


                 }
                catch (Exception ex)
                {

                }

            }


            return true;
        }
         public void FinalizeGridLayout()
        {
        }
        public string GetString()
        {
            return xGrid.XML();
        }
        public bool InitializeGridData()
        {

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xpI = xBody.CreateSubStruct("I");
            CStruct xI;
  //          xI.CreateStringAttr("Grouping", "PISelected");
            xpI.CreateBooleanAttr("CanEdit", false);
            //         xI.CreateStringAttr("Def", "Summary");
            m_xLevels[0] = xpI;


            xI = xpI.CreateSubStruct("I");
            xI.CreateStringAttr("PISelected", "Selected");
            xI.CreateStringAttr("rowid", "rselected");
            xI.CreateStringAttr("pid", "-1");
 //           xI.CreateStringAttr("Def", "Leaf");
            m_xLevels[1] = xI;

            xI = xpI.CreateSubStruct("I");
            xI.CreateStringAttr("PISelected", "Unselected");
            xI.CreateStringAttr("rowid", "runselected");
            xI.CreateStringAttr("pid", "-2");
 //           xI.CreateStringAttr("Def", "Leaf");
            m_xLevels[2] = xI;


            //       xI.CreateStringAttr("Calculated", "0");

            return true;
        }

        public void AddDetailRow(clsOptPIData oDet, int rID, List<clsOptFieldDelf> fielddef)
        {
            CStruct xIParent = m_xLevels[0];   
            if (oDet.PI_Selected == 0)
                xIParent = m_xLevels[2]; 
            else
                xIParent = m_xLevels[1]; 




            CStruct xI = xIParent.CreateSubStruct("I");

            xI.CreateStringAttr("id", rID.ToString());
            xI.CreateStringAttr("rowid", "r" + rID.ToString());
            xI.CreateStringAttr("pid", oDet.PI_ID.ToString());
            xI.CreateStringAttr("Color", "white");
            xI.CreateStringAttr("Def", "Leaf");
            //       xI.CreateStringAttr("Calculated", "0");


            xI.CreateIntAttr("NoColorState", 1);
            xI.CreateBooleanAttr("CanEdit", false);

            xI.CreateStringAttr("PIName", oDet.PI_Name);

            if (oDet.PI_Mode == 1)
                xI.CreateStringAttr("PIStatus", "In");
            else if (oDet.PI_Mode == 2)
                xI.CreateStringAttr("PIStatus", "Out");
            else
                xI.CreateStringAttr("PIStatus", "Auto");

            //if (oDet.PI_Selected == 0)
            //    xI.CreateStringAttr("PISelected", "Unselected");
            //else
            //    xI.CreateStringAttr("PISelected", "Selected");

            xI.CreateStringAttr("PISelected", " ");

            xI.CreateStringAttr("PIStatusButton", "Defaults");

            if (oDet.StartDate == DateTime.MinValue)
                xI.CreateStringAttr("PIStart", "");
            else 
                xI.CreateStringAttr("PIStart", oDet.StartDate.ToString("MM/dd/yyyy"));

            if (oDet.FinishDate == DateTime.MinValue)
                xI.CreateStringAttr("PIFinish", "");
            else
                xI.CreateStringAttr("PIFinish", oDet.FinishDate.ToString("MM/dd/yyyy"));
            int colid = 0;

            foreach (clsOptFieldDelf col in fielddef)
            {

                try
                {
                    string sn = col.fname.Replace("/n", "");
                    sn = sn.Replace(" ", "");
                    sn = sn.Replace("\r", "");
                    sn = sn.Replace("\n", "");
                    sn = "zX" + sn;

                    string sfval = oDet.m_PI_Extra_data.ElementAt(colid);

                    ++colid;

                    xI.CreateStringAttr(sn, sfval);
                }

                catch (Exception ex) { }

            }


            xI.CreateIntAttr("NoColorState", 1);

        }

    }


}