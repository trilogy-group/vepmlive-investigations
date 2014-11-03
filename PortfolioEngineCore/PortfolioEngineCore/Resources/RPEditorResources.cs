using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace PortfolioEngineCore
{
    

    internal class RPEditorResources
    {
        public static StatusEnum BuildPlanResourcesGridXML(string sPlanResources, out CStruct xGrid)
        {
            CStruct xPlanResources = new CStruct();
            xPlanResources.LoadXML(sPlanResources);
            return BuildPlanResourcesGridXML(xPlanResources, out xGrid);
        }

        public static StatusEnum BuildPlanResourcesGridXML(CStruct xPlanResources, out CStruct xGrid)
        {
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
            xCfg.CreateIntAttr("Dragging", 1);
            xCfg.CreateIntAttr("ColsMoving", 1);
            xCfg.CreateIntAttr("ColsPosLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateIntAttr("Sorting", 1);
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
            xCfg.CreateStringAttr("IdNames", "id");
            xCfg.CreateIntAttr("NoTreeLines", 1);
            //xCfg.CreateIntAttr("ShowVScroll", 1);
            xCfg.CreateIntAttr("ConstHeight", 1); // If set to 1, updates height of grid to fill whole main tag. It does not modify main tag height, see MaxHeight.
            xCfg.CreateIntAttr("NoFormatEscape", 1); // means html can be put in format
            //xCfg.CreateIntAttr("StaticCursor", 1); // If set to 1, grid does not delete cursor when it loses focus   after click outside grid.
            xCfg.CreateIntAttr("FocusWholeRow", 1);
            xCfg.CreateIntAttr("Paging", 2);
            xCfg.CreateIntAttr("NoPager", 1);
            xCfg.CreateIntAttr("AllPages", 1);

            CStruct xDef = xGrid.CreateSubStruct("Def");
            CStruct xD = xDef.CreateSubStruct("D");
            xD.CreateStringAttr("Name", "Group");
            //xD.CreateStringAttr("ItemNameHtmlPrefix", "<b>");
            //xD.CreateStringAttr("ItemNameHtmlPostfix", "</b>");
            xD.CreateStringAttr("HtmlPrefix", "<b>");
            xD.CreateStringAttr("HtmlPostfix", "</b>");
            //xD.CreateStringAttr("ItemNameFormat", "&lt;style=&quot;font-weight:bold&quot;>");
            
            xD.CreateStringAttr("Expanded", "1");
            xD.CreateStringAttr("GroupMainCaption", "Item Name (grouped)");
            //CStruct xDef = xGrid.CreateSubStruct("Def");
            CStruct xDSummaryRow = xDef.CreateSubStruct("D");
            xDSummaryRow.CreateStringAttr("Name", "Summary");

            CStruct xSolid = xGrid.CreateSubStruct("Solid");
            CStruct xGroup = xSolid.CreateSubStruct("Group");
            xGroup.CreateStringAttr("id", "Group");
            xGroup.CreateIntAttr("Visible", 0);
            //xGroup.CreateStringAttr("Cells", "List,Custom");
            xGroup.CreateStringAttr("Panel", "1");

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xMidCols = xGrid.CreateSubStruct("Cols");
            CStruct xRightCols = xGrid.CreateSubStruct("RightCols");

            CStruct xHead = xGrid.CreateSubStruct("Head");
            CStruct xFilter = xHead.CreateSubStruct("Filter");
            xFilter.CreateStringAttr("id", "Filter");
            xFilter.CreateIntAttr("Visible", 0);

            CStruct xHeader1 = xGrid.CreateSubStruct("Header");
            xHeader1.CreateIntAttr("ItemNameVisible", 1);
            xHeader1.CreateIntAttr("Spanned", -1);
            xHeader1.CreateIntAttr("SortIcons", 2);

            CStruct xC;
            //xC = xLeftCols.CreateSubStruct("C");
            //xC.CreateStringAttr("Name", "Current");
            //xC.CreateStringAttr("Type", "Text");
            //xC.CreateIntAttr("CanEdit", 0);
            //xC.CreateIntAttr("CanMove", 0);
            //xC.CreateIntAttr("CanSort", 0);
            //xC.CreateIntAttr("Width", 15);
            //xHeader1.CreateStringAttr("Current", " ");

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Status");
            xC.CreateStringAttr("Class", "rp_imagecol");
            xC.CreateStringAttr("Type", "Icon");
            xC.CreateIntAttr("CanEdit", 0);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("Width", 25);
            xHeader1.CreateStringAttr("Status", " ");

            //xC = xLeftCols.CreateSubStruct("C");
            //xC.CreateStringAttr("Name", "ResStatus");
            //xC.CreateStringAttr("Type", "Icon");
            //xC.CreateIntAttr("CanEdit", 0);
            //xC.CreateIntAttr("CanMove", 0);
            //xC.CreateIntAttr("CanHide", 0);
            //xC.CreateIntAttr("ShowHint", 0);
            //xC.CreateIntAttr("Width", 25);
            //xHeader1.CreateStringAttr("ResStatus", " ");
            //xC.CreateIntAttr("Visible", 1);

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Match");
            xC.CreateStringAttr("Type", "Int");
            xC.CreateIntAttr("CanEdit", 0);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("CanResize", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("Width", 80);
            xHeader1.CreateStringAttr("Match", "% Match");
            xC.CreateStringAttr("Format", "#");
            xC.CreateStringAttr("Align", "Center");
            xC.CreateIntAttr("Visible", 0);

            xC = xMidCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "ItemName");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("Width", 200);
            //xC.CreateBooleanAttr("CanEdit", false);
            //xC.CreateIntAttr("GroupWidth", 1);
            xC.CreateIntAttr("CanEdit", 0);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("ShowHint", 0);
            xC.CreateIntAttr("CaseSensitive", 0);
            xHeader1.CreateStringAttr("ItemName", "Item Name");
            xC.CreateIntAttr("Visible", 1);

            CStruct xResourceDisplayFields = xPlanResources.GetSubStruct("ResourceDisplayFields");
            CStruct xFieldDefinitions = xResourceDisplayFields.GetSubStruct("Items");

            CStruct xRPCats = xPlanResources.GetSubStruct("RPCategories");
            List<CStruct> listRPCats = xRPCats.GetList("RPCategory");
            SortedList<string, SortedList<string, CStruct>> listLookups = new SortedList<string, SortedList<string, CStruct>>();
            foreach (CStruct xRPCat in listRPCats)
            {
                CStruct xLookup = xRPCat.GetSubStruct("LookupList");
                CStruct xItems = xLookup.GetSubStruct("Items");
                SortedList<string, CStruct> listItems = xItems.GetListSortedByAttribute("Item", "ID");
                listLookups.Add(xRPCat.GetString("FieldID"), listItems);
            }

            List<CStruct> listFields = xFieldDefinitions.GetList("Item");
            string sCalcOrder = "";
            foreach (CStruct xField in listFields)
            {
                string sColIDName = "";
                SpecialFieldIDsEnum eFieldID = (SpecialFieldIDsEnum)xField.GetIntAttr("FieldID");
                switch (eFieldID)
                {
                    case SpecialFieldIDsEnum.sfResourceName:
                        sColIDName = "Res_Name";
                        break;
                    case SpecialFieldIDsEnum.sfResourceEMail:
                        sColIDName = "Res_EMail";
                        break;
                    case SpecialFieldIDsEnum.sfRoleName:
                        sColIDName = "Role_Name";
                        break;
                    case SpecialFieldIDsEnum.sfResourceRate:
                        sColIDName = "ResourceRate";
                        break;
                    case SpecialFieldIDsEnum.sfResourceGroups:
                        sColIDName = "ResourceGroups";
                        break;
                    case SpecialFieldIDsEnum.sfResourceCostCategory:
                        sColIDName = "CCRole_Name";
                        break;
                    case SpecialFieldIDsEnum.sfRPDeptName:
                        sColIDName = "Dept_Name";
                        break;
                    case SpecialFieldIDsEnum.sfResourceNotes:
                        sColIDName = "ResourceNotes";
                        break;
                    default:
                        sColIDName = "C" + ((int)eFieldID).ToString();
                        break;
                }
                if (sColIDName != "")
                {
                    xC = xMidCols.CreateSubStruct("C");
                    xC.CreateStringAttr("Name", sColIDName);
                    xC.CreateStringAttr("Type", "Text");
                    xC.CreateIntAttr("CanMove", 1);
                    xC.CreateIntAttr("CaseSensitive", 0);
                    xC.CreateIntAttr("ShowHint", 0);
                    //xC.CreateIntAttr("GroupEmpty", 0);
                    //xC.CreateIntAttr("GroupSingle", 0);
                    //xC.CreateIntAttr("GroupSole", 0);
                    xC.CreateBooleanAttr("Visible", !xField.GetBooleanAttr("Hidden"));
                    xHeader1.CreateStringAttr(sColIDName, xField.GetStringAttr("Title").Replace("/n", "\n"));
                }
            }

            xC = xMidCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "P2");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateIntAttr("CanEdit", 0);
            xC.CreateIntAttr("CanMove", 0);
            xC.CreateIntAttr("CanFilter", 0);
            xC.CreateIntAttr("CanSort", 0);
            xC.CreateIntAttr("CanHide", 0);
            xC.CreateIntAttr("Width", 25);
            xHeader1.CreateStringAttr("P2", "");

            CStruct xCalendar = xPlanResources.GetSubStruct("Calendar");
            CStruct xPeriods = xCalendar.GetSubStruct("Periods");

            List<CStruct> listPeriods = xPeriods.GetList("Period");
            foreach (CStruct xPeriod in listPeriods)
            {
                CStruct xPeriodCols = xRightCols;
                string sId = xPeriod.GetStringAttr("ID");
                string sName = xPeriod.GetStringAttr("Name"); ;
                //xHeader1.CreateStringAttr("Q" + sId + "Span", "3");
                xHeader1.CreateStringAttr("Q" + sId, sName);
                xC = xPeriodCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "Q" + sId);
                if (sCalcOrder != "") sCalcOrder += ",";
                sCalcOrder += "Q" + sId;
                xD.CreateStringAttr("Q" + sId + "Formula", "sum()");
                //xC.CreateStringAttr("Type", "Text");
                ////xC.CreateStringAttr("Format", ",#.##");
                xC.CreateStringAttr("Type", "Float");
                //xC.CreateStringAttr("Format", "0.####;<span style='color:red;'>-0.####</span>;nothing");
                xC.CreateStringAttr("EmptyValue", "");
                xC.CreateIntAttr("CanMove", 0);
                xC.CreateIntAttr("CanHide", 0);
                xC.CreateIntAttr("ShowHint", 0);
                xC.CreateIntAttr("MinWidth", 45);
                xC.CreateIntAttr("Width", 65);
                xC.CreateStringAttr("Align", "Center");

            }
            if (sCalcOrder != "")
            {
                xD.CreateIntAttr("Calculated", 1);
                xD.CreateStringAttr("CalcOrder", sCalcOrder);
            }

            // DATA
            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");

            CStruct xResources = xPlanResources.GetSubStruct("Resources");

            string s = xPlanResources.XML().ToString();

            List<CStruct> listResources = xResources.GetList("Resource");
            foreach (CStruct xResource in listResources)
            {
                CStruct xI = xB.CreateSubStruct("I");
                //xI.CreateStringAttr("Status", "/_layouts/ppm/images/requirement.gif");
                xI.CreateIntAttr("CanEdit", 0);


                //xI.CreateStringAttr("rowid", xResource.GetStringAttr("WResID"));
                //xI.CreateIntAttr("CanEdit", 0);
                xI.CreateStringAttr("id", xResource.GetStringAttr("WResID"));
                xI.CreateStringAttr("Res_UID", xResource.GetStringAttr("WResID"));
                xI.CreateStringAttr("Res_EMail", xResource.GetStringAttr("EMail"));
                bool bUserIsRM = xResource.GetBooleanAttr("UserIsRM");
                if (bUserIsRM)
                    xI.CreateBooleanAttr("UserIsRM", bUserIsRM);

                bool bInTeam = xResource.GetBoolean("InTeam");
                if (bInTeam)
                    xI.CreateBooleanAttr("InTeam", bInTeam);
                bool bIsGeneric = xResource.GetBoolean("IsGeneric");
                xI.CreateBooleanAttr("IsGeneric", bIsGeneric);
                if (bIsGeneric)
                    xI.CreateStringAttr("Status", "/_layouts/ppm/images/generic.gif");
                int lDeptUID = xResource.GetInt("DeptUID");
                //if (lDeptUID > 0)
                xI.CreateIntAttr("Dept_UID", lDeptUID);
                int lCCRoleUID = xResource.GetInt("CCRoleUID");
                //if (lCCRoleUID > 0)
                xI.CreateIntAttr("CCRole_UID", lCCRoleUID);
                int lCCRoleParentUID = xResource.GetInt("CCRoleParentUID");
                if (lCCRoleParentUID > 0)
                    xI.CreateIntAttr("CCRoleParent_UID", lCCRoleParentUID);
                int lRoleUID = xResource.GetInt("RoleUID");
                //if (lRoleUID > 0)
                xI.CreateIntAttr("Role_UID", lRoleUID);

                xI.CreateStringAttr("Role_Name", xResource.GetString("RoleName"));
                xI.CreateStringAttr("CCRole_Name", xResource.GetString("CCRoleName"));
                xI.CreateStringAttr("CCRoleParent_Name", xResource.GetString("CCRoleParentName"));
                xI.CreateStringAttr("Dept_Name", xResource.GetString("DeptName"));

                string sItemName = xResource.GetStringAttr("Name");
                xI.CreateStringAttr("ItemName", sItemName);
                foreach (CStruct xField in listFields)
                {
                    string sValue = "";
                    string sColIDName = "";
                    SpecialFieldIDsEnum eFieldID = (SpecialFieldIDsEnum)xField.GetIntAttr("FieldID");
                    switch (eFieldID)
                    {
                        case SpecialFieldIDsEnum.sfResourceName:
                            sColIDName = "Res_Name";
                            sValue = xResource.GetStringAttr("Name");
                            break;
                        case SpecialFieldIDsEnum.sfRoleName:
                            //sColIDName = "Role_Name";
                            //sValue = xResource.GetString("Field" + ((int)(eFieldID)).ToString());
                            break;
                        case SpecialFieldIDsEnum.sfResourceRate:
                            sColIDName = "ResourceRate";
                            sValue = xResource.GetString("Field" + ((int)(eFieldID)).ToString());
                            break;
                        case SpecialFieldIDsEnum.sfResourceGroups:
                            sColIDName = "ResourceGroups";
                            sValue = xResource.GetString("Field" + ((int)(eFieldID)).ToString());
                            break;
                        case SpecialFieldIDsEnum.sfResourceCostCategory:
                            //sColIDName = "CCRole_Name";
                            //sValue = xResource.GetString("Field" + ((int)(eFieldID)).ToString());
                            break;
                        case SpecialFieldIDsEnum.sfRPDeptName:
                            //sColIDName = "Dept_Name";
                            //SortedList<string, CStruct> listItems;
                            //if (listLookups.TryGetValue(((int)eFieldID).ToString(), out listItems))
                            //{
                            //    CStruct xItem;
                            //    if (listItems.TryGetValue(lDeptUID.ToString(), out xItem))
                            //    {
                            //        sValue = xItem.GetStringAttr("Name");
                            //    }
                            //}
                            break;
                        case SpecialFieldIDsEnum.sfResourceNotes:
                            sColIDName = "ResourceNotes";
                            sValue = xResource.GetString("Field" + ((int)(eFieldID)).ToString());
                            break;
                        default:
                            sColIDName = "C" + ((int)eFieldID).ToString();
                            sValue = xResource.GetString("Field" + ((int)(eFieldID)).ToString());
                            break;
                    }
                    if (sColIDName != "")
                    {
                        xI.CreateStringAttr(sColIDName, sValue);
                        //xI.CreateStringAttr("Type", "Text");
                        //xI.CreateIntAttr("CanEdit", 0);
                        //xI.CreateIntAttr("CanMove", 0);
                    }
                }

                char[] ch = new char[] { ',' };
                {
                    string sPeriods = xResource.GetString("AvailablePeriods");
                    string[] aPeriod = sPeriods.Split(ch);
                    string sPeriodHours = xResource.GetString("AvailableHours");
                    string[] aPeriodHours = sPeriodHours.Split(ch);
                    foreach (CStruct xPeriod in listPeriods)
                    {
                        string sId = xPeriod.GetStringAttr("ID");
                        for (int i = 0; i < aPeriod.Length; i++)
                        {
                            if (sId == aPeriod[i])
                            {

                                double dbl = 0;
                                string sHours = aPeriodHours[i].ToString();
                                double.TryParse(sHours, out dbl);
                                xI.CreateDoubleAttr("A" + sId, dbl);
                                break;
                            }
                        }
                    }
                }
                {
                    string sPeriods = xResource.GetString("AvailablePeriods");
                    string[] aPeriod = sPeriods.Split(ch);
                    string sPeriodHours = xResource.GetString("OffHours");
                    string[] aPeriodHours = sPeriodHours.Split(ch);
                    foreach (CStruct xPeriod in listPeriods)
                    {
                        string sId = xPeriod.GetStringAttr("ID");
                        for (int i = 0; i < aPeriod.Length; i++)
                        {
                            if (sId == aPeriod[i])
                            {

                                double dbl = 0;
                                string sHours = aPeriodHours[i].ToString();
                                double.TryParse(sHours, out dbl);
                                xI.CreateDoubleAttr("O" + sId, dbl);
                                break;
                            }
                        }
                    }
                }
                {
                    string sPeriods = xResource.GetString("CommittedPeriods");
                    string[] aPeriod = sPeriods.Split(ch);
                    string sPeriodHours = xResource.GetString("CommittedHours");
                    string[] aPeriodHours = sPeriodHours.Split(ch);
                    foreach (CStruct xPeriod in listPeriods)
                    {
                        string sId = xPeriod.GetStringAttr("ID");
                        for (int i = 0; i < aPeriod.Length; i++)
                        {
                            if (sId == aPeriod[i])
                            {

                                double dbl = 0;
                                string sHours = aPeriodHours[i].ToString();
                                double.TryParse(sHours, out dbl);
                                xI.CreateDoubleAttr("C" + sId, dbl);
                                break;
                            }
                        }
                    }
                }
                {
                    string sPeriods = xResource.GetString("NonWorkPeriods");
                    string[] aPeriod = sPeriods.Split(ch);
                    string sPeriodHours = xResource.GetString("NonWorkHours");
                    string[] aPeriodHours = sPeriodHours.Split(ch);
                    foreach (CStruct xPeriod in listPeriods)
                    {
                        string sId = xPeriod.GetStringAttr("ID");
                        for (int i = 0; i < aPeriod.Length; i++)
                        {
                            if (sId == aPeriod[i])
                            {
                                double dbl = 0;
                                string sFTEToHours = aPeriodHours[i].ToString();
                                double.TryParse(sFTEToHours, out dbl);
                                xI.CreateDoubleAttr("N" + sId, dbl);
                                break;
                            }
                        }
                    }
                }
            }
            return StatusEnum.rsSuccess;
        }

        //public static StatusEnum BuildResourceSelectorGridXML(string sSelectedResources, out CStruct xGrid)
        //{
        //    CStruct xSelectedResources = new CStruct();
        //    xSelectedResources.LoadXML(sSelectedResources);
        //    return BuildResourceSelectorGridXML(xSelectedResources, out xGrid);
        //}

        //public static StatusEnum BuildResourceSelectorGridXML(CStruct xSelectedResources, out CStruct xGrid)
        //{
        //    xGrid = new CStruct();
        //    xGrid.Initialize("Grid");
        //    CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
        //    xToolbar.CreateIntAttr("Visible", 1);
        //    CStruct xPanel = xGrid.CreateSubStruct("Panel");
        //    xPanel.CreateIntAttr("Visible", 1);
        //    xPanel.CreateIntAttr("Delete", 0);
        //    CStruct xCfg = xGrid.CreateSubStruct("Cfg");
        //    xCfg.CreateStringAttr("MainCol", "ItemName");
        //    xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
        //    xCfg.CreateIntAttr("SuppressCfg", 3);
        //    xCfg.CreateIntAttr("Dragging", 1);
        //    xCfg.CreateIntAttr("ColsMoving", 1);
        //    xCfg.CreateIntAttr("ColsPosLap", 1);
        //    xCfg.CreateIntAttr("ColsLap", 1);
        //    xCfg.CreateIntAttr("Sorting", 1);
        //    xCfg.CreateIntAttr("VisibleLap", 1);
        //    xCfg.CreateIntAttr("SectionWidthLap", 1);
        //    xCfg.CreateIntAttr("GroupLap", 1);
        //    xCfg.CreateIntAttr("WideHScroll", 0);
        //    xCfg.CreateIntAttr("LeftWidth", 400);
        //    xCfg.CreateIntAttr("Width", 400);
        //    xCfg.CreateIntAttr("RightWidth", 400);
        //    xCfg.CreateIntAttr("MaxHeight", 0);
        //    xCfg.CreateIntAttr("ShowDeleted", 0);
        //    xCfg.CreateBooleanAttr("DateStrings", true);
        //    xCfg.CreateIntAttr("MaxWidth", 1);
        //    xCfg.CreateIntAttr("MaxSort", 2);
        //    xCfg.CreateStringAttr("DefaultSort", "ItemName");
        //    xCfg.CreateIntAttr("AppendId", 0);
        //    xCfg.CreateIntAttr("FullId", 0);
        //    xCfg.CreateStringAttr("IdChars", "0123456789");
        //    xCfg.CreateIntAttr("NumberId", 1);
        //    xCfg.CreateIntAttr("LastId", 1);
        //    xCfg.CreateIntAttr("CaseSensitiveId", 0);
        //    xCfg.CreateStringAttr("Style", "GM");
        //    xCfg.CreateStringAttr("CSS", "RPEditor");
        //    xCfg.CreateIntAttr("FastColumns", 1);
        //    xCfg.CreateIntAttr("ExpandAllLevels", 3);
        //    xCfg.CreateIntAttr("GroupSortMain", 1);
        //    xCfg.CreateIntAttr("GroupRestoreSort", 1);
        //    xCfg.CreateStringAttr("IdNames", "ItemName");

        //    CStruct xDef = xGrid.CreateSubStruct("Def");
        //    CStruct xD = xDef.CreateSubStruct("D");
        //    xD.CreateStringAttr("Name", "Group");
        //    xD.CreateStringAttr("Expanded", "1");
        //    xD.CreateStringAttr("GroupMainCaption", "Item Name (grouped)");
        //    //CStruct xDef = xGrid.CreateSubStruct("Def");
        //    CStruct xDSummaryRow = xDef.CreateSubStruct("D");
        //    xDSummaryRow.CreateStringAttr("Name", "Summary");

        //    CStruct xSolid = xGrid.CreateSubStruct("Solid");
        //    CStruct xGroup = xSolid.CreateSubStruct("Group");
        //    xGroup.CreateIntAttr("Visible", 0);
        //    //xGroup.CreateStringAttr("Cells", "List,Custom");
        //    xGroup.CreateStringAttr("Panel", "2");

        //    CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
        //    CStruct xMidCols = xGrid.CreateSubStruct("Cols");
        //    CStruct xRightCols = xGrid.CreateSubStruct("RightCols");

        //    CStruct xHead = xGrid.CreateSubStruct("Head");
        //    CStruct xFilter = xHead.CreateSubStruct("Filter");
        //    xFilter.CreateStringAttr("id", "Filter");

        //    CStruct xHeader1 = xGrid.CreateSubStruct("Header");
        //    xHeader1.CreateIntAttr("ItemNameVisible", 1);
        //    xHeader1.CreateIntAttr("Spanned", -1);

        //    CStruct xC;
        //    xC = xLeftCols.CreateSubStruct("C");
        //    xC.CreateStringAttr("Name", "Status");
        //    xC.CreateStringAttr("Type", "Icon");
        //    xC.CreateIntAttr("CanEdit", 0);
        //    xC.CreateIntAttr("CanMove", 0);
        //    xC.CreateIntAttr("Width", 25);
        //    xHeader1.CreateStringAttr("Status", " ");

        //    //xC = xLeftCols.CreateSubStruct("C");
        //    //xC.CreateStringAttr("Name", "ResStatus");
        //    //xC.CreateStringAttr("Type", "Icon");
        //    //xC.CreateIntAttr("CanEdit", 0);
        //    //xC.CreateIntAttr("CanMove", 0);
        //    //xC.CreateIntAttr("Width", 25);
        //    //xHeader1.CreateStringAttr("ResStatus", " ");
        //    //xC.CreateIntAttr("Visible", 0);

        //    xC = xLeftCols.CreateSubStruct("C");
        //    xC.CreateStringAttr("Name", "ItemName");
        //    xC.CreateStringAttr("Type", "Text");
        //    xC.CreateIntAttr("Width", 250);
        //    //xC.CreateBooleanAttr("CanEdit", false);
        //    //xC.CreateIntAttr("GroupWidth", 1);
        //    xC.CreateIntAttr("CanEdit", 0);
        //    xC.CreateIntAttr("CanMove", 0);
        //    xHeader1.CreateStringAttr("ItemName", "Item Name");
        //    xC.CreateIntAttr("Visible", 1);

        //    CStruct xResourceDisplayFields = xSelectedResources.GetSubStruct("ResourceDisplayFields");
        //    CStruct xFieldDefinitions = xResourceDisplayFields.GetSubStruct("Items");

        //    List<CStruct> listFields = xFieldDefinitions.GetList("Item");
        //    foreach (CStruct xField in listFields)
        //    {
        //        xC = xMidCols.CreateSubStruct("C");
        //        xC.CreateStringAttr("Name", "X" + xField.GetStringAttr("FieldID"));
        //        xC.CreateStringAttr("Type", "Text");
        //        xC.CreateIntAttr("CanEdit", 0);
        //        xC.CreateIntAttr("CanMove", 1);
        //        xC.CreateIntAttr("CanHide", 1);
        //        string sTitle = xField.GetStringAttr("Title").Replace("/n", "\n");
        //        xHeader1.CreateStringAttr("X" + xField.GetStringAttr("FieldID"), sTitle);
        //    }

        //    // DATA
        //    CStruct xBody = xGrid.CreateSubStruct("Body");
        //    CStruct xB = xBody.CreateSubStruct("B");

        //    CStruct xResources = xSelectedResources.GetSubStruct("Resources");

        //    string s = xSelectedResources.XML().ToString();

        //    List<CStruct> listResources = xResources.GetList("Resource");
        //    foreach (CStruct xResource in listResources)
        //    {
        //        CStruct xI = xB.CreateSubStruct("I");
        //        //xI.CreateStringAttr("Status", "/_layouts/ppm/images/requirement.gif");
        //        xI.CreateStringAttr("Status", "/_layouts/ppm/images/commitment.gif");
        //        xI.CreateIntAttr("CanEdit", 0);


        //        //xI.CreateStringAttr("rowid", xResource.GetStringAttr("WResID"));
        //        xI.CreateIntAttr("CanEdit", 0);
        //        xI.CreateStringAttr("WResID", xResource.GetStringAttr("WResID"));
        //        xI.CreateStringAttr("ItemName", xResource.GetString("ResourceName"));
        //        foreach (CStruct xField in listFields)
        //        {
        //            string sValue = "";
        //            //CStruct xCCRole;
        //            SpecialFieldIDsEnum eFieldID = (SpecialFieldIDsEnum)xField.GetIntAttr("FieldID");
        //            switch (eFieldID)
        //            {
        //                case SpecialFieldIDsEnum.sfRPEGroup:
        //                    sValue = xResource.GetStringAttr("Group");
        //                    break;
        //                case SpecialFieldIDsEnum.sfMajorCategory:
        //                    //sValue = xField.GetStringAttr("Group");
        //                    break;
        //                case SpecialFieldIDsEnum.sfResourceName:
        //                    sValue = xResource.GetString("ResourceName");
        //                    break;
        //                default:
        //                    break;
        //            }
        //            xI.CreateStringAttr("X" + xField.GetStringAttr("FieldID"), sValue);
        //            xI.CreateStringAttr("Type", "Text");
        //            xI.CreateIntAttr("CanEdit", 0);
        //            xI.CreateIntAttr("CanMove", 0);
        //        }
        //    }
        //    return StatusEnum.rsSuccess;
        //}
    }
}
