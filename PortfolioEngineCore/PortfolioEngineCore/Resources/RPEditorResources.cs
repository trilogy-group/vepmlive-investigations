using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PortfolioEngineCore
{
    internal class RPEditorResources
    {
        public static string BuildPlanResourcesGridXML(string sPlanResources)
        {
            var xPlanResources = new CStruct();
            xPlanResources.LoadXML(sPlanResources);
            return BuildPlanResourcesGridXML(null, xPlanResources);
        }

        public static string BuildPlanResourcesGridXML(CStruct resultStruct, CStruct xPlanResources)
        {
            CStruct xGrid = resultStruct == null ? new CStruct() : resultStruct.CreateSubStruct("Grid");

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
            RPEditorData.CreateConfigAttributes(xCfg);
            xCfg.CreateStringAttr("IdNames", "id");
            xCfg.CreateIntAttr("NoTreeLines", 1);
            //xCfg.CreateIntAttr("ShowVScroll", 1);
            xCfg.CreateIntAttr("ConstHeight", 1); // If set to 1, updates height of grid to fill whole main tag. It does not modify main tag height, see MaxHeight.
            xCfg.CreateIntAttr("NoFormatEscape", 1); // means html can be put in format
            //xCfg.CreateIntAttr("StaticCursor", 1); // If set to 1, grid does not delete cursor when it loses focus   after click outside grid.
            xCfg.CreateIntAttr("FocusWholeRow", 1);
            xCfg.CreateIntAttr("Paging", 2);
            xCfg.CreateIntAttr("ChildPaging", 2);
            xCfg.CreateIntAttr("PageLength", 20);
            xCfg.CreateIntAttr("MaxPages", 1);
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

            //CStruct xSI = xSolid.CreateSubStruct("I");
            //xSI.CreateStringAttr("id", "PAGER");
            //xSI.CreateStringAttr("Cells", "LIST");
            //xSI.CreateStringAttr("Space", "4");
            //xSI.CreateStringAttr("LISTType", "Pages");
            //xSI.CreateStringAttr("LISTRelWidth", "1");
            //xSI.CreateStringAttr("LISTAlign", "left");
            //xSI.CreateStringAttr("LISTLeft", "10");

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

            //if (listPeriods != null)
            //{
            //    if (listPeriods.Count > 120)
            //    {
            //        xCfg.CreateIntAttr("PageLength", 10);
            //        xCfg.CreateIntAttr("MaxPages", 5);
            //    }
            //    else
            //    {
            //        xCfg.CreateIntAttr("PageLength", 50);
            //        xCfg.CreateIntAttr("MaxPages", 2);
            //    }
            //}

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
            var xBody = xGrid.CreateSubStruct("Body");
            xBody.CreateSubStruct("B");

            var planResourcesGridXml = resultStruct == null
                ? XElement.Parse(xGrid.XML())
                : XElement.Parse(resultStruct.XML());

            var xResources = xPlanResources.GetSubStruct("Resources");
            var listResources = xResources.GetList("Resource");

            foreach (var xResource in listResources)
            {
                planResourcesGridXml
                    .Element("Grid")
                    .Element("Body")
                    .Element("B")
                    .Add(BuildResourceXML(xResource, listFields));
            }
            return planResourcesGridXml.ToString();
        }

        private static XElement BuildResourceXML(CStruct xResource, IEnumerable<CStruct> listFields)
        {
            var element = AddBasicAttributes(xResource);
            ProcessFields(xResource, listFields, element);
            ProcessPeriods(xResource, element);

            return element;
        }

        private static XElement AddBasicAttributes(CStruct resource)
        {
            var element = new XElement("I");

            element.Add(new XAttribute("CanEdit", 0));
            element.Add(new XAttribute("id", resource.GetStringAttr("WResID")));
            element.Add(new XAttribute("Res_UID", resource.GetStringAttr("WResID")));
            element.Add(new XAttribute("Res_EMail", resource.GetStringAttr("EMail")));
            var userIsRm = resource.GetBooleanAttr("UserIsRM");
            if (userIsRm)
            {
                element.Add(new XAttribute("UserIsRM", 1));
            }

            var inTeam = resource.GetBoolean("InTeam");
            if (inTeam)
            {
                element.Add(new XAttribute("InTeam", 1));
            }
            var isGeneric = resource.GetBoolean("IsGeneric");
            element.Add(
                new XAttribute(
                    "IsGeneric",
                    isGeneric
                        ? 1
                        : 0));
            if (isGeneric)
            {
                element.Add(new XAttribute("Status", "/_layouts/ppm/images/generic.gif"));
            }
            var departmentUId = resource.GetInt("DeptUID");
            element.Add(new XAttribute("Dept_UID", departmentUId));
            var ccRoleUId = resource.GetInt("CCRoleUID");
            element.Add(new XAttribute("CCRole_UID", ccRoleUId));
            var ccRoleParentUId = resource.GetInt("CCRoleParentUID");
            if (ccRoleParentUId > 0)
            {
                element.Add(new XAttribute("CCRoleParent_UID", ccRoleParentUId));
            }
            var roleUId = resource.GetInt("RoleUID");
            element.Add(new XAttribute("Role_UID", roleUId));

            element.Add(new XAttribute("Role_Name", resource.GetString("RoleName")));
            element.Add(new XAttribute("CCRole_Name", resource.GetString("CCRoleName")));
            element.Add(new XAttribute("CCRoleParent_Name", resource.GetString("CCRoleParentName")));
            element.Add(new XAttribute("Dept_Name", resource.GetString("DeptName")));

            var itemName = resource.GetStringAttr("Name");
            element.Add(new XAttribute("ItemName", itemName));
            return element;
        }

        private static void ProcessPeriods(CStruct resource, XElement element)
        {
            var separator = new[]
            {
                ','
            };

            var availablePeriods = resource.GetString("AvailablePeriods").Split(separator);
            var committedPeriods = resource.GetString("CommittedPeriods").Split(separator);
            var nonWorkPeriods = resource.GetString("NonWorkPeriods").Split(separator);

            var availableHours = resource.GetString("AvailableHours").Split(separator);
            var committedHours = resource.GetString("CommittedHours").Split(separator);
            var offHours = resource.GetString("OffHours").Split(separator);
            var nonWorkHours = resource.GetString("NonWorkHours").Split(separator);

            for (var i = 0; i < availablePeriods.Length; i++)
            {
                var period = availablePeriods[i];
                if (string.IsNullOrWhiteSpace(period))
                {
                    break;
                }

                element.Add(new XAttribute(string.Format("A{0}", period), availableHours[i]));
                element.Add(new XAttribute(string.Format("O{0}", period), offHours[i]));
            }

            for (var i = 0; i < committedPeriods.Count(); i++)
            {
                var period = committedPeriods[i];
                if (string.IsNullOrWhiteSpace(period))
                {
                    break;
                }

                element.Add(new XAttribute(string.Format("C{0}", period), committedHours[i]));
            }

            for (var i = 0; i < nonWorkPeriods.Count(); i++)
            {
                var period = nonWorkPeriods[i];
                if (string.IsNullOrWhiteSpace(period))
                {
                    break;
                }

                element.Add(new XAttribute(string.Format("N{0}", period), nonWorkHours[i]));
            }
        }

        private static void ProcessFields(CStruct resource, IEnumerable<CStruct> listFields, XElement element)
        {
            foreach (var field in listFields)
            {
                var fieldValue = string.Empty;
                var colIdName = string.Empty;
                var fieldId = (SpecialFieldIDsEnum)field.GetIntAttr("FieldID");
                switch (fieldId)
                {
                    case SpecialFieldIDsEnum.sfResourceName:
                        colIdName = "Res_Name";
                        fieldValue = resource.GetStringAttr("Name");
                        break;
                    case SpecialFieldIDsEnum.sfResourceRate:
                        colIdName = "ResourceRate";
                        fieldValue = resource.GetString("Field" + (int)fieldId);
                        break;
                    case SpecialFieldIDsEnum.sfResourceGroups:
                        colIdName = "ResourceGroups";
                        fieldValue = resource.GetString("Field" + (int)fieldId);
                        break;
                    case SpecialFieldIDsEnum.sfResourceNotes:
                        colIdName = "ResourceNotes";
                        fieldValue = resource.GetString("Field" + (int)fieldId);
                        break;
                    case SpecialFieldIDsEnum.sfRoleName:
                    case SpecialFieldIDsEnum.sfResourceCostCategory:
                    case SpecialFieldIDsEnum.sfRPDeptName:
                        break;
                    default:
                        var fieldInt = (int)fieldId;
                        colIdName = string.Format("C{0}", fieldInt);
                        fieldValue = resource.GetString("Field" + fieldInt);
                        break;
                }
                if (colIdName != string.Empty)
                {
                    element.Add(new XAttribute(colIdName, fieldValue));
                }
            }
        }
    }
}
