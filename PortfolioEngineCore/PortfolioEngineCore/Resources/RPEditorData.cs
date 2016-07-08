using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;

namespace PortfolioEngineCore
{

    internal class RPEditorData
    {

        //public static StatusEnum BuildResourcePlanGridXML(string sPlanData, out CStruct xGrid)
        //{
        //    CStruct xPlanData = new CStruct();
        //    xPlanData.LoadXML(sPlanData);
        //    return BuildResourcePlanGridXML(xPlanData, out xGrid);
        //}

        public static StatusEnum BuildResourcePlanGridXML(DBAccess databaseAccess, CStruct xPlanData, out CStruct xGrid)
        {
            // BUGBUG - remove this
            //string sXML = xPlanData.XML();

            xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);
            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Select", 0);
            xPanel.CreateIntAttr("Delete", 0);
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("MainCol", "ItemName");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("InEditMode", 1);
            //xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("Sorting", 1);
            xCfg.CreateIntAttr("ColsMoving", 1);
            xCfg.CreateIntAttr("ColsPosLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateIntAttr("VisibleLap", 1);
            xCfg.CreateIntAttr("SectionWidthLap", 1);
            xCfg.CreateIntAttr("GroupLap", 1);
            xCfg.CreateIntAttr("WideHScroll", 0);
            xCfg.CreateIntAttr("LeftWidth", 400);
            xCfg.CreateIntAttr("Width", 400);
            xCfg.CreateIntAttr("RightWidth", 400);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateIntAttr("ShowDeleted", 0);
            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("MaxSort", 2);
            xCfg.CreateStringAttr("DefaultSort", "ItemName");
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "RPEditor");
            xCfg.CreateIntAttr("FastColumns", 1);
            xCfg.CreateIntAttr("ExpandAllLevels", 3);
            xCfg.CreateIntAttr("GroupSortMain", 1);
            xCfg.CreateIntAttr("GroupRestoreSort", 1);
            //xCfg.CreateStringAttr("IdNames", "ItemName");
            xCfg.CreateIntAttr("NoTreeLines", 1);
            // setting this causes grid to scroll back to top when resized
            //xCfg.CreateIntAttr("ShowVScroll", 1);
            xCfg.CreateIntAttr("ConstHeight", 1); // If set to 1, updates height of grid to fill whole main tag. It does not modify main tag height, see MaxHeight.
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("SelectingCells", 0);
            xCfg.CreateStringAttr("DragCursor", "w-resize");
            xCfg.CreateIntAttr("StaticCursor", 1);
            xCfg.CreateIntAttr("StandardFilter", 2);

            CStruct xActions = xGrid.CreateSubStruct("Actions");
            xActions.CreateStringAttr("OnDrag", "DragCell");

            CStruct xDef = xGrid.CreateSubStruct("Def");
            CStruct xD = xDef.CreateSubStruct("D");
            xD.CreateStringAttr("Name", "Group");
            xD.CreateStringAttr("Expanded", "1");
            xD.CreateStringAttr("ItemNameHtmlPrefix", "<b>");
            xD.CreateStringAttr("ItemNameHtmlPostfix", "</b>");
            xD.CreateStringAttr("GroupMainCaption", "Item Name (grouped)");
            //CStruct xDef = xGrid.CreateSubStruct("Def");
            CStruct xDSummaryRow = xDef.CreateSubStruct("D");
            xDSummaryRow.CreateStringAttr("Name", "Summary");
            xD.CreateIntAttr("NoColorState", 1);

            CStruct xSolid = xGrid.CreateSubStruct("Solid");
            CStruct xGroup = xSolid.CreateSubStruct("Group");
            xGroup.CreateIntAttr("Visible", 0);
            //xGroup.CreateStringAttr("Cells", "List,Custom");
            xGroup.CreateStringAttr("Panel", "2");

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xMidCols = xGrid.CreateSubStruct("Cols");
            //CStruct xPeriodCols = xGrid.CreateSubStruct("Cols");
            CStruct xRightCols = xGrid.CreateSubStruct("RightCols");

            CStruct xHead = xGrid.CreateSubStruct("Head");
            CStruct xFilter = xHead.CreateSubStruct("Filter");
            xFilter.CreateStringAttr("id", "Filter");
            xFilter.CreateIntAttr("Visible", 0);

            //            <Head>
            //<Filter id="Filter1" Height="22" ENUMFilterOff="(All)" ICONTip="Input 'red', 'green' or 'yellow'" HTMLTip="Input 'yes', 'no', 'warn' or 'empty'"/>


            CStruct xHeader1 = xGrid.CreateSubStruct("Header");
            xHeader1.CreateIntAttr("ItemNameVisible", 1);
            xHeader1.CreateIntAttr("Spanned", -1);
            xHeader1.CreateIntAttr("SortIcons", 2);

            CStruct xC;
            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Note");
            xC.CreateStringAttr("Class", "rp_imagecol");
            xC.CreateStringAttr("Type", "Text");
            //xC.CreateStringAttr("Cursor", "pointer");
            xC.CreateIntAttr("CanEdit", 0);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanSort", 0);
            // Disabling export for this as we have used hidden column for it.
            xC.CreateIntAttr("CanExport", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("Width", 25);
            xHeader1.CreateStringAttr("Note", "");

            // Adding hidden column for note to be exported in excel
            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "ExportNote");
            xC.CreateStringAttr("Type", "Html");
            xC.CreateIntAttr("CanEdit", 0);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanHide", 1);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("Width", 50);
            xHeader1.CreateStringAttr("ExportNote", "Note");

            //xC = xLeftCols.CreateSubStruct("C");
            //xC.CreateStringAttr("Name", "RowEvent");
            //xC.CreateStringAttr("Class", "rp_imagecol");
            //xC.CreateStringAttr("Type", "Text");
            //xC.CreateStringAttr("Cursor", "pointer");
            //xC.CreateIntAttr("CanEdit", 0);
            //xC.CreateIntAttr("CanMove", 0);
            //xC.CreateIntAttr("CanHide", 0);
            //xC.CreateIntAttr("CanResize", 0);
            //xC.CreateIntAttr("CanSort", 0);
            //xC.CreateIntAttr("ShowHint", 0);
            //xC.CreateIntAttr("Width", 25);
            //xHeader1.CreateStringAttr("RowEvent", "");

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "RowStatus");
            //xC.CreateStringAttr("Class", "rp_imagecol");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("CanEdit", 0);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("Width", 25);
            xHeader1.CreateStringAttr("RowStatus", " ");

            bool bNegotiationMode = (xPlanData.GetIntAttr("OpMode") == 0);

            if (bNegotiationMode)
            {
                xC = xLeftCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "RowPMStatus");
                xC.CreateStringAttr("Align", "Center");
                xC.CreateStringAttr("Type", "Text");
                xC.CreateIntAttr("CanEdit", 0);
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateIntAttr("CanHide", 0);
                xC.CreateIntAttr("CanSort", 0);
                xC.CreateIntAttr("CanResize", 0);
                xC.CreateIntAttr("ShowHint", 0);
                xC.CreateIntAttr("Width", 30);
                xHeader1.CreateStringAttr("RowPMStatus", "PM");
                xC.CreateIntAttr("Visible", 1);

                xC = xLeftCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "RowRMStatus");
                xC.CreateStringAttr("Align", "Center");
                xC.CreateStringAttr("Type", "Text");
                xC.CreateIntAttr("CanEdit", 0);
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateIntAttr("CanHide", 0);
                xC.CreateIntAttr("CanSort", 0);
                xC.CreateIntAttr("CanResize", 0);
                xC.CreateIntAttr("ShowHint", 0);
                xC.CreateIntAttr("Width", 30);
                xHeader1.CreateStringAttr("RowRMStatus", "RM");
                xC.CreateIntAttr("Visible", 1);
            }

            //xC = xLeftCols.CreateSubStruct("C");

            xC = xMidCols.CreateSubStruct("C");
            CStruct xCPIInfo = xC;
            xC.CreateStringAttr("Name", "ItemName");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("Width", 200);
            xC.CreateIntAttr("CanEdit", 0);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xHeader1.CreateStringAttr("ItemName", "Item Name");
            xC.CreateIntAttr("Visible", 1);
            xC.CreateIntAttr("CaseSensitive", 0);



            CStruct xFieldDefinitions = xPlanData.GetSubStruct("FieldDefinitions");

            List<CStruct> listFields = xFieldDefinitions.GetList("Field");
            CStruct xCCRoles = xPlanData.GetSubStruct("CostCategoryRoles");
            SortedList<string, CStruct> listCCRoles = xCCRoles.GetListSortedByAttribute("CostCategoryRole", "ID");
            SortedList<string, CStruct> listRoles = xCCRoles.GetListSortedByAttribute("CostCategoryRole", "RoleUID");
            CStruct xPIs = xPlanData.GetSubStruct("PIs");
            SortedList<string, CStruct> listPIs = xPIs.GetListSortedByAttribute("PI", "ProjectID");

            string sPIs = "";
            foreach (CStruct xPI in listPIs.Values)
            {
                string sPI = xPI.GetStringAttr("ProjectID");
                if (sPIs == string.Empty)
                    sPIs = sPI;
                else
                    sPIs += "," + sPI;

                xCPIInfo.CreateStringAttr("PI" + sPI, xPI.GetStringAttr("Name"));
            }
            xCPIInfo.CreateStringAttr("PIs", sPIs);

            CStruct xRPCats = xPlanData.GetSubStruct("RPCategories");
            List<CStruct> listRPCats = xRPCats.GetList("RPCategory");
            SortedList<string, SortedList<string, CStruct>> listLookups = new SortedList<string, SortedList<string, CStruct>>();
            SortedList<string, CStruct> listDepts = null;
            SortedList<string, CStruct> listRates = null;
            foreach (CStruct xRPCat in listRPCats)
            {
                CStruct xLookup = xRPCat.GetSubStruct("LookupList");
                CStruct xItems = xLookup.GetSubStruct("Items");
                SortedList<string, CStruct> listItems = xItems.GetListSortedByAttribute("Item", "ID");
                int lFieldID = xRPCat.GetInt("FieldID");
                if (lFieldID == 9007) listDepts = listItems;
                if (lFieldID == (int)SpecialFieldIDsEnum.sfResourceRate) listRates = listItems;
                listLookups.Add(lFieldID.ToString(), listItems);
            }

            //string[] delims = new string[] { "/n" };
            foreach (CStruct xField in listFields)
            {
                CStruct xLookup = null;
                string sColIDName = "";
                bool bCanEdit = false;
                bool bVisible = !xField.GetBooleanAttr("Hidden");
                SpecialFieldIDsEnum eFieldID = (SpecialFieldIDsEnum)xField.GetIntAttr("ID");
                switch (eFieldID)
                {
                    case SpecialFieldIDsEnum.sfID:
                        break;
                    case SpecialFieldIDsEnum.sfProjectName:
                        sColIDName = "Project_Name";
                        break;
                    case SpecialFieldIDsEnum.sfRPEGroup:
                        sColIDName = "sfRPEGroup";
                        bVisible = false;
                        break;
                    case SpecialFieldIDsEnum.sfMajorCategory:
                        break;
                    case SpecialFieldIDsEnum.sfCostCategoryName:
                        //sColIDName = "CCRoleParent_Name";
                        sColIDName = "CCRole_Name";
                        break;
                    case SpecialFieldIDsEnum.sfCostCategoryRoleName:
                        //sColIDName = "CCRole_Name";
                        sColIDName = "Role_Name";
                        break;
                    case SpecialFieldIDsEnum.sfRoleName:
                        //sColIDName = "Role_Name";
                        break;
                    case SpecialFieldIDsEnum.sfRPDeptName:
                        sColIDName = "Dept_Name";
                        //xLookup = GetLookup(listRPCats, (int)eFieldID);
                        break;
                    case SpecialFieldIDsEnum.sfResourceName:
                        sColIDName = "Res_Names";
                        break;
                    case SpecialFieldIDsEnum.sfResourceRate:
                        sColIDName = "NamedRate_Name";
                        xLookup = GetLookup(listRPCats, (int)eFieldID);
                        break;
                    case SpecialFieldIDsEnum.sfDescription:
                        sColIDName = "Description";
                        bCanEdit = true;
                        break;
                    case SpecialFieldIDsEnum.sfTimestamp:
                        break;
                    case SpecialFieldIDsEnum.sfResourceGroups:
                        break;
                    case SpecialFieldIDsEnum.sfResourceType:
                        break;
                    case SpecialFieldIDsEnum.sfPortfolioField:
                        sColIDName = xField.GetStringAttr("Title");
                        if (!string.IsNullOrEmpty(sColIDName))
                        {
                            sColIDName = Regex.Replace(sColIDName, "[^a-zA-Z]+", "_"); 
                        }
                        break;
                    default:
                        if (eFieldID >= SpecialFieldIDsEnum.sfRPCatText1 && eFieldID <= SpecialFieldIDsEnum.sfRPCatCode5)
                        {
                            sColIDName = "X" + ((int)eFieldID).ToString("0000") + "_Name";
                            bCanEdit = true;
                            xLookup = GetLookup(listRPCats, (int)eFieldID);
                        }
                        break;
                }

                if (sColIDName != "")
                {
                    xC = xMidCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", sColIDName);
                    xC.CreateStringAttr("Type", "Text");
                    xC.CreateIntAttr("CanMove", 1);
                    xC.CreateBooleanAttr("Visible", bVisible);
                    xC.CreateIntAttr("ShowHint", 0);
                    xC.CreateIntAttr("CaseSensitive", 0);
                    xHeader1.CreateStringAttr(sColIDName, xField.GetStringAttr("Title").Replace("/n", "\n"));
                    if (xLookup != null)
                    {
                        xC.CreateIntAttr("CanEdit", 2);
                        CStruct xLookupList = xLookup.GetSubStruct("LookupList");
                        CStruct xItems = xLookupList.GetSubStruct("Items");
                        List<CStruct> listItems = xItems.GetList("Item");
                        bool bCatLeafOnly = xField.GetBooleanAttr("CatLeafOnly");
                        bool bUseFullName = xField.GetBooleanAttr("UseFullName");
                        xC.CreateStringAttr("Defaults", BuildJSONLookup(listItems.ToArray(), bCatLeafOnly, bUseFullName, true));
                        xC.CreateStringAttr("Button", "Defaults");
                        xC.CreateIntAttr("MinWidth", 30);
                        // setting WidthPad to 0 make dropdown button disappear
                        // Seems to be an auto col width sizing bug in treegrid - doesn't take into account button width
                        //xC.CreateIntAttr("WidthPad", 0);
                    }
                    else
                    {
                        xC.CreateBooleanAttr("CanEdit", bCanEdit);
                    }
                }
            }

            // required for padding
            xC = xMidCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P1");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("CanEdit", 0);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("Width", 25);
            xHeader1.CreateStringAttr("P1", "");

            CStruct xCalendar = xPlanData.GetSubStruct("Calendar");
            CStruct xPeriods = xCalendar.GetSubStruct("Periods");

            DateTime dtNow = DateTime.Now.Date;
            List<CStruct> listPeriods = xPeriods.GetList("Period");
            foreach (CStruct xPeriod in listPeriods)
            {
                CStruct xPeriodCols = xRightCols;
                string sId = xPeriod.GetStringAttr("ID");
                string sName = xPeriod.GetStringAttr("Name"); ;
                xHeader1.CreateStringAttr("Q" + sId, sName);

                xC = xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "Q" + sId);
                xC.CreateStringAttr("Type", "Text");
                xC.CreateStringAttr("Format", ",#.###");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateIntAttr("CanEdit", 0);
                xC.CreateIntAttr("CanHide", 0);
                xC.CreateIntAttr("MinWidth", 45);
                xC.CreateIntAttr("Width", 65);
                xC.CreateStringAttr("Align", "Center");

                DateTime dtStart = xPeriod.GetDateAttr("Start");
                DateTime dtFinish = xPeriod.GetDateAttr("Finish");
                if (dtStart <= dtNow && dtFinish >= dtNow)
                    xC.CreateBooleanAttr("Current", true);
            }

            // ******************************************* DATA *****************************************

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            SortedList<string, CStruct> listAddedProjects = new SortedList<string, CStruct>();

            CStruct xPlanRows = xPlanData.GetSubStruct("PlanRows");
            List<CStruct> listPlanRows = xPlanRows.GetList("PlanRow");
            SortedList<string, bool> listGroups = new SortedList<string, bool>();
            string sResourceUIDs = xPlanData.GetStringAttr("ResourceUIDs", "");
            string sProjectIDs = xPlanData.GetStringAttr("ProjectIDs", "");
            bool bProjectMode = (sProjectIDs != "") ? true : false;
            bool bRequired;
            CStruct xI;
            foreach (CStruct xPI in listPIs.Values)
            {
                string sProjectID = xPI.GetStringAttr("ProjectID");
                Dictionary<string, string> portfolioFieldsForProject;
                DBCommon.GetPortfolioFieldsAndValues(databaseAccess, sProjectID, out portfolioFieldsForProject);

                //bool bUserCanEdit = xPI.GetBooleanAttr("UserCanEdit", false);
                bool bIsUsed = xPI.GetBooleanAttr("IsUsed", false);
                if (sProjectID != "" && (bProjectMode || bIsUsed))
                {
                    xI = xB.CreateSubStruct("I");
                    xI.CreateStringAttr("Project_UID", sProjectID);
                    xI.CreateStringAttr("Project_Name", xPI.GetStringAttr("Name"));
                    xI.CreateStringAttr("Status", "0");
                    int lPeriod = xPI.GetIntAttr("StartPeriod", 0);
                    if (lPeriod > 0)
                        xI.CreateIntAttr("StartPeriod", lPeriod);
                    lPeriod = xPI.GetIntAttr("FinishPeriod", 0);
                    if (lPeriod > 0)
                        xI.CreateIntAttr("FinishPeriod", lPeriod);
                    xI.CreateIntAttr("CanEdit", 0);
                    if (xPI.GetBooleanAttr("UserIsPM", false) == true)
                        xI.CreateBooleanAttr("UserIsPM", true);
                    if (xPI.GetBooleanAttr("UserCanEdit", false) == true)
                        xI.CreateBooleanAttr("UserCanEdit", true);
                    xI.CreateStringAttr("HtmlPrefix", "<b>");
                    xI.CreateStringAttr("HtmlPostfix", "</b>");
                    foreach (CStruct xField in listFields)
                    {
                        SpecialFieldIDsEnum eFieldID = (SpecialFieldIDsEnum)xField.GetIntAttr("ID");
                        string sColIDName = "";
                        switch (eFieldID)
                        {
                            case SpecialFieldIDsEnum.sfID:
                            case SpecialFieldIDsEnum.sfProjectName:
                            case SpecialFieldIDsEnum.sfRPEGroup:
                            case SpecialFieldIDsEnum.sfMajorCategory:
                            case SpecialFieldIDsEnum.sfCostCategoryRoleName:
                            case SpecialFieldIDsEnum.sfRoleName:
                            case SpecialFieldIDsEnum.sfRPDeptName:
                            case SpecialFieldIDsEnum.sfResourceName:
                            case SpecialFieldIDsEnum.sfResourceRate:
                            case SpecialFieldIDsEnum.sfDescription:
                            case SpecialFieldIDsEnum.sfTimestamp:
                            case SpecialFieldIDsEnum.sfResourceGroups:
                            case SpecialFieldIDsEnum.sfResourceType:
                                break;
                            case SpecialFieldIDsEnum.sfPortfolioField:
                                sColIDName = xField.GetStringAttr("Title");

                                if (!string.IsNullOrEmpty(sColIDName))
                                {
                                    if (portfolioFieldsForProject.ContainsKey(sColIDName))
                                    {
                                        var sValue = portfolioFieldsForProject[sColIDName];
                                        var sColIdNameWithouSpace = Regex.Replace(sColIDName, "[^a-zA-Z]+", "_");
                                        xI.CreateStringAttr(sColIdNameWithouSpace, sValue);
                                    }
                                }

                                break;
                            default:
                                {
                                    if (eFieldID >= SpecialFieldIDsEnum.sfRPCatText1 && eFieldID <= SpecialFieldIDsEnum.sfRPCatCode5)
                                    {
                                        sColIDName = "X" + ((int)eFieldID).ToString("0000") + "_Name";
                                        xI.CreateIntAttr(sColIDName + "CanEdit", 0);
                                        CStruct xLookup = GetLookup(listRPCats, (int)eFieldID);
                                        if (xLookup != null)
                                            xI.CreateStringAttr(sColIDName + "Button", "");
                                    }
                                    break;
                                }
                        }
                    }
                    listAddedProjects.Add(sProjectID, xI);
                }
            }

            // build a keyed list of required Groups            
            foreach (CStruct xPlanRow in listPlanRows)
            {
                // do we want this row?
                bool bAdd = false;
                if (sResourceUIDs == "")
                    bAdd = true;
                else
                {
                    int lWResID = xPlanRow.GetInt("WResID");
                    if (lWResID > 0 && Common.IsIDInList(sResourceUIDs, lWResID) == true)
                        bAdd = true;
                    else
                    {
                        lWResID = xPlanRow.GetInt("PendingWResID");
                        if (lWResID > 0 && Common.IsIDInList(sResourceUIDs, lWResID) == true)
                            bAdd = true;
                    }
                }
                if (bAdd)
                {
                    string sGroup = xPlanRow.GetStringAttr("Group");
                    if (listGroups.TryGetValue(sGroup, out bRequired) == false)
                        listGroups.Add(sGroup, true);
                }
            }

            // now start building the treegrid rows

            //string s = xPlanData.XML().ToString();

            CStruct xIRequirement = null;
            CStruct xPlanRowRequirement = null;
            CStruct xIProject = null;

            SortedList<string, CStruct> listPIPlanRows = new SortedList<string, CStruct>();
            foreach (CStruct xPlanRow in listPlanRows)
            {
                string sGroup = xPlanRow.GetStringAttr("Group");
                if (listGroups.TryGetValue(sGroup, out bRequired) == true)
                {
                    string sProjectID = xPlanRow.GetStringAttr("ProjectID");
                    if (listAddedProjects.TryGetValue(sProjectID, out xIProject) == true)
                    {
                        int lRowType = xPlanRow.GetIntAttr("Status");
                        if (lRowType == 1)  // Requirement
                        {
                            xIRequirement = xIProject.CreateSubStruct("I");
                            xI = xIRequirement;
                            xPlanRowRequirement = xPlanRow;
                        }
                        else
                        {
                            if (xPlanRowRequirement != null)
                            {
                                if (xPlanRowRequirement.GetStringAttr("ProjectID") == xPlanRow.GetStringAttr("ProjectID")
                                    && xPlanRowRequirement.GetStringAttr("Group") == xPlanRow.GetStringAttr("Group"))
                                {
                                    xI = xIRequirement.CreateSubStruct("I");
                                }
                                else
                                {
                                    xPlanRowRequirement = null;
                                    xIRequirement = null;
                                    xI = xIProject.CreateSubStruct("I");
                                }
                            }
                            else
                            {
                                xI = xIProject.CreateSubStruct("I");
                            }
                        }

                        if (xIProject.GetBooleanAttr("UserCanEdit", false) == true)
                            xI.CreateBooleanAttr("UserCanEdit", true);
                        xI.CreateIntAttr("CanEdit", 0);
                        xI.CreateIntAttr("NoColorState", 1);


                        int lUID = 0;
                        CStruct xCCRole2 = null;
                        string sValue = "";
                        xI.CreateStringAttr("GUID", xPlanRow.GetStringAttr("GUID"));
                        xI.CreateStringAttr("UID", xPlanRow.GetStringAttr("UID"));
                        xI.CreateStringAttr("Project_UID", xPlanRow.GetStringAttr("ProjectID"));
                        xI.CreateStringAttr("Status", xPlanRow.GetStringAttr("Status"));
                        xI.CreateDateAttr("Timestamp", xPlanRow.GetDateAttr("Timestamp"));
                        xI.CreateStringAttr("Group", xPlanRow.GetStringAttr("Group"));
                        xI.CreateIntAttr("Private", xPlanRow.GetIntAttr("Private"));

                        if (bNegotiationMode)
                        {
                            xI.CreateStringAttr("PMStatus", xPlanRow.GetStringAttr("PMStatus"));
                            xI.CreateStringAttr("RMStatus", xPlanRow.GetStringAttr("RMStatus"));
                            if (xPlanRow.GetIntAttr("UserIsPM") == 1)
                                xI.CreateIntAttr("UserIsPM", 1);
                            if (xPlanRow.GetIntAttr("UserIsRM") == 1)
                                xI.CreateIntAttr("UserIsRM", 1);
                        }
                        xI.CreateStringAttr("ActiveCommitment", xPlanRow.GetStringAttr("ActiveCommitment"));
                        xI.CreateStringAttr("CCRoleParent_UID", xPlanRow.GetString("CCRoleParentUID"));
                        xI.CreateStringAttr("CCRole_UID", xPlanRow.GetString("CCRoleUID"));
                        xI.CreateStringAttr("Role_UID", xPlanRow.GetString("RoleUID"));
                        {
                            lUID = xPlanRow.GetInt("CCRoleParentUID");
                            sValue = "";
                            if (listCCRoles.TryGetValue(lUID.ToString(), out xCCRole2))
                                sValue = xCCRole2.GetStringAttr("Name");
                            //xI.CreateStringAttr("CCRoleParent_Name", sValue);
                            lUID = xPlanRow.GetInt("CCRoleUID");
                            //sValue = "";
                            if (listCCRoles.TryGetValue(lUID.ToString(), out xCCRole2))
                                sValue = sValue + "." + xCCRole2.GetStringAttr("Name");
                            xI.CreateStringAttr("CCRole_Name", sValue);
                        }
                        {
                            lUID = xPlanRow.GetInt("RoleUID");
                            sValue = "";
                            if (listRoles.TryGetValue(lUID.ToString(), out xCCRole2))
                                sValue = xCCRole2.GetStringAttr("Name");
                            xI.CreateStringAttr("Role_Name", sValue);
                        }

                        int lWResID = xPlanRow.GetInt("WResID");
                        if (lWResID > 0)
                        {
                            xI.CreateStringAttr("Res_UID", lWResID.ToString());
                            xI.CreateStringAttr("Res_Name", xPlanRow.GetString("ResName"));
                        }
                        //string sResName = xPlanRow.GetString("ResName");
                        //string sPendingResName = "";
                        int lDeptUID = xPlanRow.GetIntAttr("DeptUID");
                        int lPendingDeptUID = xPlanRow.GetIntAttr("PendingDeptUID");
                        xI.CreateStringAttr("Dept_UID", lDeptUID.ToString());
                        int lPendingWResID = xPlanRow.GetInt("PendingWResID");
                        if (lPendingWResID > 0)
                        {
                            xI.CreateIntAttr("PendingRes_UID", lPendingWResID);
                            //sPendingResName = xPlanRow.GetString("PendingResName");
                            xI.CreateStringAttr("PendingRes_Name", xPlanRow.GetString("PendingResName"));
                        }
                        if (lPendingDeptUID > 0)
                            xI.CreateStringAttr("PendingDept_UID", lPendingDeptUID.ToString());
                        {
                            sValue = "";
                            SortedList<string, CStruct> listItems;
                            if (listLookups.TryGetValue(((int)SpecialFieldIDsEnum.sfRPDeptName).ToString(), out listItems))
                            {
                                CStruct xItem;
                                if (listItems.TryGetValue(lDeptUID.ToString(), out xItem))
                                    sValue = xItem.GetStringAttr("Name");
                            }
                            xI.CreateStringAttr("Dept_Name", sValue);
                        }

                        CStruct xCCRole = GetPlanRowCCRole(xPlanRow, listCCRoles, listRoles);
                        //string sValue;
                        //if (sResName == "" && sPendingResName == "")
                        //{
                        //    sValue = "unknown";
                        //    if (xCCRole != null)
                        //        sValue = xCCRole.GetStringAttr("Name");

                        //    xI.CreateStringAttr("ItemName", "(" + sValue + ")");
                        //}
                        //else if (sResName == "")
                        //{
                        //    xI.CreateStringAttr("ItemName", sPendingResName);
                        //}
                        //else
                        //{
                        //    xI.CreateStringAttr("ItemName", sResName);
                        //}

                        xI.CreateIntAttr("CanEdit", 1);
                        int lRowNoteUID = xPlanRow.GetInt("RowNoteUID");
                        if (lRowNoteUID > 0)
                        {
                            xI.CreateIntAttr("RowNote", 1);
                            // Populating hidden note field to be used while exporting to excel
                            xI.CreateStringAttr("ExportNote", xPlanRow.GetString("RowNote_HTML"));
                        }
                        int lLastEventContext = xPlanRow.GetInt("LastRowEvent");
                        if (lLastEventContext > 0)
                            xI.CreateIntAttr("LastRowEvent", lLastEventContext);

                        //xI.CreateStringAttr("Def", "Summary");
                        foreach (CStruct xField in listFields)
                        {
                            sValue = "";
                            SpecialFieldIDsEnum eFieldID = (SpecialFieldIDsEnum)xField.GetIntAttr("ID");
                            string sColIDName = "";
                            //CStruct xCCRole2;
                            switch (eFieldID)
                            {
                                case SpecialFieldIDsEnum.sfID:
                                    //lUID = xPlanRow.GetIntAttr("UID");
                                    //sValue = "C" + lUID.ToString("0000");
                                    break;
                                case SpecialFieldIDsEnum.sfProjectName:
                                    sColIDName = "Project_Name";
                                    lUID = xPlanRow.GetIntAttr("ProjectID");
                                    CStruct xPI;
                                    if (listPIs.TryGetValue(lUID.ToString(), out xPI))
                                        sValue = xPI.GetStringAttr("Name");
                                    break;
                                case SpecialFieldIDsEnum.sfRPEGroup:
                                    sColIDName = "sfRPEGroup";
                                    sValue = xPlanRow.GetStringAttr("Group");
                                    break;
                                case SpecialFieldIDsEnum.sfMajorCategory:
                                    break;
                                case SpecialFieldIDsEnum.sfCostCategoryName:
                                    //sColIDName = "CCRoleParent_Name";
                                    //lUID = xPlanRow.GetInt("CCRoleParentUID");
                                    //if (listCCRoles.TryGetValue(lUID.ToString(), out xCCRole2))
                                    //    sValue = xCCRole2.GetStringAttr("Name");
                                    break;
                                case SpecialFieldIDsEnum.sfCostCategoryRoleName:
                                    //sColIDName = "CCRole_Name";
                                    //lUID = xPlanRow.GetInt("CCRoleUID");
                                    //if (listCCRoles.TryGetValue(lUID.ToString(), out xCCRole2))
                                    //    sValue = xCCRole2.GetStringAttr("Name");
                                    break;
                                case SpecialFieldIDsEnum.sfRoleName:
                                    //sColIDName = "Role_Name";
                                    //lUID = xPlanRow.GetInt("RoleUID");
                                    //if (listRoles.TryGetValue(lUID.ToString(), out xCCRole2))
                                    //    sValue = xCCRole2.GetStringAttr("Name");
                                    break;
                                case SpecialFieldIDsEnum.sfRPDeptName:
                                    //{
                                    //    sColIDName = "Dept_Name";
                                    //    //string sDeptName = "";
                                    //    //string sPendingDeptName = "";
                                    //    SortedList<string, CStruct> listItems;
                                    //    if (listLookups.TryGetValue(((int)eFieldID).ToString(), out listItems))
                                    //    {
                                    //        CStruct xItem;
                                    //        if (listItems.TryGetValue(lDeptUID.ToString(), out xItem))
                                    //            sValue = xItem.GetStringAttr("Name");
                                    //        //if (listItems.TryGetValue(lPendingDeptUID.ToString(), out xItem))
                                    //        //    sPendingDeptName = xItem.GetStringAttr("Name");
                                    //    }
                                    //    //sValue = FormatPendingNames(sDeptName, sPendingDeptName);
                                    //    break;
                                    //}
                                    break;
                                case SpecialFieldIDsEnum.sfResourceName:
                                    //sColIDName = "Res_Name";
                                    //sValue = FormatPendingNames(sResName, sPendingResName);
                                    break;
                                case SpecialFieldIDsEnum.sfResourceRate:
                                    sColIDName = "NamedRate_Name";
                                    lUID = xPlanRow.GetInt("Rate_UID");
                                    if (listRates.TryGetValue(lUID.ToString(), out xCCRole2))
                                        sValue = xCCRole2.GetStringAttr("Name");
                                    break;
                                case SpecialFieldIDsEnum.sfDescription:
                                    sColIDName = "Description";
                                    sValue = xPlanRow.GetString("Description");
                                    break;
                                case SpecialFieldIDsEnum.sfTimestamp:
                                    //sValue = xPlanRow.GetStringAttr("Timestamp");
                                    break;
                                case SpecialFieldIDsEnum.sfResourceGroups:
                                    break;
                                case SpecialFieldIDsEnum.sfResourceType:
                                    break;

                                default:
                                    {
                                        if (eFieldID >= SpecialFieldIDsEnum.sfRPCatText1 && eFieldID <= SpecialFieldIDsEnum.sfRPCatCode5)
                                        {
                                            sColIDName = "X" + ((int)eFieldID).ToString("0000") + "_Name";
                                            CStruct xLookup = GetLookup(listRPCats, (int)eFieldID);
                                            sValue = xPlanRow.GetString("Field" + ((int)eFieldID).ToString("0000"));
                                            if (xLookup != null)
                                            {
                                                SortedList<string, CStruct> listItems;
                                                if (listLookups.TryGetValue(((int)eFieldID).ToString(), out listItems))
                                                {
                                                    CStruct xItem;
                                                    if (listItems.TryGetValue(sValue, out xItem))
                                                    {
                                                        if (xField.GetBooleanAttr("UseFullName"))
                                                            sValue = xItem.GetStringAttr("FullName");
                                                        else
                                                            sValue = xItem.GetStringAttr("Name");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                            }
                            if (sColIDName != "")
                            {
                                xI.CreateStringAttr(sColIDName, sValue);
                                //xI.CreateStringAttr("Type", "Text");
                            }
                        }

                        char[] ch = new char[] { ',' };
                        //if (xCCRole != null)
                        //{
                        //    string sCCPeriods = xCCRole.GetString("Periods");
                        //    string[] aCCPeriod = sCCPeriods.Split(ch);
                        //    string sCCPeriodConv = xCCRole.GetString("FTEToHours");
                        //    string[] aCCPeriodConv = sCCPeriodConv.Split(ch);
                        //    foreach (CStruct xPeriod in listPeriods)
                        //    {
                        //        string sId = xPeriod.GetStringAttr("ID");
                        //        for (int i = 0; i < aCCPeriod.Length; i++)
                        //        {
                        //            if (sId == aCCPeriod[i])
                        //            {
                        //                double dbl = Convert.ToDouble(aCCPeriodConv[i]);
                        //                // D stands for divider - only using because C already used for Committed
                        //                xI.CreateDoubleAttr("D" + sId, dbl);
                        //                break;
                        //            }
                        //        }
                        //    }
                        //}

                        string sPeriods = xPlanRow.GetString("Periods");
                        //if (sPeriods != "")
                        //    xI.CreateStringAttr("Periods", sPeriods);
                        string[] aPeriod = sPeriods.Split(ch);
                        string sPeriodHours = xPlanRow.GetString("PeriodHours");
                        //if (sPeriodHours != "")
                        //    xI.CreateStringAttr("PeriodHours", sPeriodHours);
                        string[] aPeriodHours = sPeriodHours.Split(ch);
                        string sPeriodFTEs = xPlanRow.GetString("PeriodFTEs");
                        //if (sPeriodFTEs != "")
                        //    xI.CreateStringAttr("PeriodFTEs", sPeriodFTEs);
                        string[] aPeriodFTEs = sPeriodFTEs.Split(ch);
                        string sPeriodModes = xPlanRow.GetString("PeriodModes");
                        //if (sPeriodModes != "")
                        //    xI.CreateStringAttr("PeriodModes", sPeriodModes);
                        string[] aPeriodModes = sPeriodModes.Split(ch);

                        foreach (CStruct xPeriod in listPeriods)
                        {
                            string sId = xPeriod.GetStringAttr("ID");
                            for (int i = 0; i < aPeriod.Length; i++)
                            {
                                if (sId == aPeriod[i])
                                {
                                    double dbl = Convert.ToDouble(aPeriodHours[i]);
                                    xI.CreateDoubleAttr("H" + sId, dbl);
                                    dbl = Convert.ToDouble(aPeriodFTEs[i]);
                                    xI.CreateDoubleAttr("F" + sId, dbl);
                                    int mode = Convert.ToInt32(aPeriodModes[i]);
                                    xI.CreateIntAttr("M" + sId, mode);
                                    break;
                                }
                            }
                        }
                        if (bNegotiationMode)
                        {
                            string sPendingPeriods = xPlanRow.GetString("PendingPeriods");
                            string[] aPPeriod = sPendingPeriods.Split(ch);
                            string sPendingHours = xPlanRow.GetString("PendingHours");
                            string[] aPPeriodHours = sPendingHours.Split(ch);
                            string sPendingFTEs = xPlanRow.GetString("PendingFTEs");
                            string[] aPPeriodFTEs = sPendingFTEs.Split(ch);
                            string sPendingModes = xPlanRow.GetString("PendingModes");
                            string[] aPPeriodModes = sPendingModes.Split(ch);

                            foreach (CStruct xPeriod in listPeriods)
                            {
                                string sId = xPeriod.GetStringAttr("ID");
                                for (int i = 0; i < aPPeriod.Length; i++)
                                {
                                    if (sId == aPPeriod[i])
                                    {
                                        double dbl = Convert.ToDouble(aPPeriodHours[i]);
                                        xI.CreateDoubleAttr("h" + sId, dbl);
                                        dbl = Convert.ToDouble(aPPeriodFTEs[i]);
                                        xI.CreateDoubleAttr("f" + sId, dbl);
                                        int mode = Convert.ToInt32(aPPeriodModes[i]);
                                        xI.CreateIntAttr("m" + sId, mode);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return StatusEnum.rsSuccess;
        }

        private static string FormatPendingNames(string sResName, string sPendingResName)
        {
            string s = sResName;
            if (sPendingResName != "")
            {
                if (s == "")
                    s = sPendingResName;
                else s = sPendingResName + "(" + s + ")";
            }

            return s;
        }

        private static CStruct GetPlanRowCCRole(CStruct xPlanRow, SortedList<string, CStruct> listCCRoles, SortedList<string, CStruct> listRoles)
        {
            int lUID = xPlanRow.GetInt("CCRoleUID");
            CStruct xCCRole;
            if (listCCRoles.TryGetValue(lUID.ToString(), out xCCRole))
            {
                if (xCCRole != null)
                    return xCCRole;
            }
            lUID = xPlanRow.GetInt("RoleUID");
            if (listRoles.TryGetValue(lUID.ToString(), out xCCRole))
            {
                if (xCCRole != null)
                    return xCCRole;
            }
            // just return the first CCRole we find
            if (listCCRoles.Count > 0)
                return listCCRoles.Values[0];
            if (listRoles.Count > 0)
                return listRoles.Values[0];

            return null;
        }

        private static CStruct GetLookup(List<CStruct> listRPCats, int lFieldID)
        {
            foreach (CStruct xRPCat in listRPCats)
            {
                if (xRPCat.GetInt("FieldID") == lFieldID)
                    return xRPCat;
            }
            return null;
        }
        private static string BuildJSONLookup(CStruct[] lookupItems, bool bCatLeafOnly, bool bUseFullName, bool bIncludeNone)
        {
            string sJSON = BuildJSONLookup(lookupItems, 0, bCatLeafOnly, bUseFullName);
            if (bIncludeNone == true)
            {
                if (sJSON != "")
                    sJSON = "{Name:'0',Text:'[None]',Value:'0_'}," + sJSON;
                else
                    sJSON = "{Name:'0',Text:'[None]',Value:'0_'}";
            }
            return "{Items:[" + sJSON + "]}";
        }
        private static string BuildJSONLookup(CStruct[] lookupItems, int nIndex, bool bCatLeafOnly, bool bUseFullName)
        {
            string sJSON = "";
            int nItems = lookupItems.Length;
            for (int i = nIndex; i < nItems; i++)
            {
                if (lookupItems[nIndex].GetIntAttr("Level") == lookupItems[i].GetIntAttr("Level"))
                {
                    if (sJSON != "")
                        sJSON += ",";
                    string sDisabled = "";
                    if (lookupItems[i].GetBooleanAttr("Inactive", false) == true)
                        sDisabled = ",Disabled:1";
                    else if (i + 1 < nItems && lookupItems[i + 1].GetIntAttr("Level") > lookupItems[i].GetIntAttr("Level") && bCatLeafOnly == true)
                        sDisabled = ",Disabled:1";
                    string sName = "";
                    if (bUseFullName)
                        sName = lookupItems[i].GetStringAttr("FullName");
                    else
                        sName = lookupItems[i].GetStringAttr("Name");
                    sJSON += "{Name:'" + lookupItems[i].GetStringAttr("ID") + "',Text:'" + sName + "'" + sDisabled + ",Value:'" + lookupItems[i].GetStringAttr("ID") + "_" + sName + "'}";
                    if (i + 1 < nItems)
                    {
                        if (lookupItems[i + 1].GetIntAttr("Level") > lookupItems[i].GetIntAttr("Level"))
                        {
                            sJSON += ",{Name:'Level" + lookupItems[i].GetIntAttr("ID") + "',Expanded:-1,Level:1,Items:[" + BuildJSONLookup(lookupItems, i + 1, bCatLeafOnly, bUseFullName) + "]}";
                        }
                    }
                }
                else if (lookupItems[nIndex].GetIntAttr("Level") > lookupItems[i].GetIntAttr("Level"))
                    return sJSON;
                //else if (nIndex != 0)
                //    return sJSON;
            }
            return sJSON;
        }
    }
}
