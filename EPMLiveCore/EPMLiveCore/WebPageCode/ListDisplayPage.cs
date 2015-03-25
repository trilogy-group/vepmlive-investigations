using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Configuration;
using System.Linq;

namespace EPMLiveCore
{
    public class ListDisplayPage : LayoutsPageBase
    {
        private string pageRender;
        private SPList currentList;
        private SortedList<string, SPField> displayableFields = new SortedList<string, SPField>();
        private List<SPGroup> groups = new List<SPGroup>();
        private StringBuilder computeFieldsScript = new StringBuilder();
        private Dictionary<string, Dictionary<string, string>> hiddenFields = new Dictionary<string, Dictionary<string, string>>();
        private Dictionary<string, Dictionary<string, string>> fieldProperties = null;
        private string[] meFields = { "ID", "Author", "Editor" };

        protected Button OK = new Button();
        protected Button Cancel = new Button();

        protected override void OnLoad(EventArgs e)
        {
            this.Title = "Editable Fields";

            //if (this.CurrentList.ParentWeb.Properties.ContainsKey(String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(CurrentList.DefaultView.Url))))
            //    fieldProperties = ListDisplayUtils.ConvertFromString(this.CurrentList.ParentWeb.Properties[String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(CurrentList.DefaultView.Url))]);

            GridGanttSettings gSettings = new GridGanttSettings(CurrentList);

            if (gSettings.DisplaySettings != "")
                fieldProperties = ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);

            foreach (SPField field in this.CurrentList.Fields)
            {
                if (field.Reorderable && !field.Sealed)
                    displayableFields.Add(field.Title, field);
                else
                {
                    if (meFields.Contains(field.InternalName))
                         displayableFields.Add(field.Title, field);
                }
            }

            foreach (SPGroup group in this.CurrentList.ParentWeb.Groups)
                groups.Add(group);

            pageRender = this.PrepareRenderPage();
            RegisterScript();

            this.Cancel.PostBackUrl = string.Format("~/_layouts/listedit.aspx?List={0}", CurrentList.ID.ToString());
        }

        protected string RenderPage()
        {
            return pageRender;
        }

        protected SPList CurrentList
        {
            get
            {
                if (currentList == null)
                    currentList = SPContext.Current.Web.Lists[new Guid(Request.QueryString["List"])];

                return currentList;
            }
        }

        private string PrepareRenderPage()
        {
            StringBuilder result = new StringBuilder();

            result.Append("<table style=\"width:100%\" cellpadding=\"0\" cellspacing=\"0\">");

            foreach (SPField field in displayableFields.Values)
            {
                bool roFields = MatchROFields(field.Id);
                result.Append("<tr><td colspan=\"2\" class=\"ms-sectionline\" style=\"height:1px;\" ></td></tr>");
                if (roFields == false)
                    result.Append(string.Format("<tr><td valign=\"top\" class=\"ms-sectionheader\" style=\"width:120px\">{0}</td>", field.Title));                        
                else
                    result.Append(string.Format("<tr style=\"display:none;\"><td valign=\"top\" class=\"ms-sectionheader\" style=\"width:120px\">{0}</td>", field.Title));                        
                result.Append(string.Format("<td class=\"ms-authoringcontrols\">{0}</td></tr><tr><td></td><td class=\"ms-authoringcontrols\" style=\"height:10px;\"></td></tr>", RenderOptions(field)));                
            }

            result.Append("</table>");

            return result.ToString();
        }

        private bool MatchROFields(Guid fieldId)
        {
            if (SPBuiltInFieldId.ID == fieldId)
                return true;
            else if (SPBuiltInFieldId.Author == fieldId)
                return true;
            else if (SPBuiltInFieldId.Editor == fieldId)
                return true;
            else
                return false;

        }

        private string RenderOptions(SPField field)
        {
            StringBuilder result = new StringBuilder();
            bool showWhere = false;
            bool showEdit = false;
            // New mode
            if (field.Type != SPFieldType.Calculated)
            {
                result.Append("<table style=\"width: 100%\">");
                result.Append("<tr><td style=\"width: 150px;\"  class=\"ms-authoringcontrols\">");
                result.Append("On new item, display field : ");
                result.Append("</td><td class=\"ms-authoringcontrols\">");
                if (field.Required)
                    result.Append("Always (This field is required)");
                else
                {
                    result.Append(RenderOption(field, "New", ref showWhere, ref showEdit));
                    result.Append(RenderPanelWhere(field, "New", ref showWhere));
                    UpdateGlobalScript(field, "New");
                }
                result.Append("</td></tr>");
                result.Append("</table>");
            }
            // Display mode
            result.Append("<table style=\"width: 100%\">");
            result.Append("<tr><td style=\"width: 150px;\" class=\"ms-authoringcontrols\">");
            result.Append("On display item, display field : ");
            result.Append("</td><td class=\"ms-authoringcontrols\">");
            result.Append(RenderOption(field, "Display", ref showWhere, ref showEdit));
            result.Append(RenderPanelWhere(field, "Display", ref showWhere));
            UpdateGlobalScript(field, "Display");
            result.Append("</td></tr>");
            result.Append("</table>");

            // Edit mode
            //if (field.Type != SPFieldType.Calculated)
            showEdit = false;
            {
                result.Append("<table style=\"width: 100%\">");
                result.Append("<tr><td style=\"width: 150px;\"  class=\"ms-authoringcontrols\">");
                result.Append("On edit item, display field : ");
                result.Append("</td><td class=\"ms-authoringcontrols\">");
                result.Append(RenderOption(field, "Edit", ref showWhere, ref showEdit));
                result.Append(RenderPanelWhere(field, "Edit", ref showWhere));
                UpdateGlobalScript(field, "Edit");
                result.Append("</td></tr>");
                result.Append("</table>");
            }

            if (field.Type != SPFieldType.Calculated)
            {
                result.Append("<table style=\"width: 100%\" id=\"Editable" + field.InternalName + "Edit\" style=\"display:");
                if (!showEdit)
                    result.Append("none");                        
                result.Append(";\">");
                result.Append("<tr><td style=\"width: 150px;\"  class=\"ms-authoringcontrols\">");
                result.Append("On edit item, editable: ");
                result.Append("</td><td class=\"ms-authoringcontrols\">");
                result.Append(RenderOption(field, "Editable", ref showWhere, ref showEdit));
                result.Append(RenderPanelWhere(field, "Editable", ref showWhere));
                UpdateGlobalScript(field, "Editable");
                result.Append("</td></tr>");
                result.Append("</table>");
            }
            return result.ToString();
        }

        private void UpdateGlobalScript(SPField field, string mode)
        {
            computeFieldsScript.Append(String.Format("ComputeField(\"{0}{1}\");", field.InternalName, mode));
            if (!hiddenFields.ContainsKey(field.InternalName))
                hiddenFields.Add(field.InternalName, new Dictionary<string, string>());

            hiddenFields[field.InternalName].Add(mode, String.Format("Hidden{0}{1}", field.InternalName, mode));
            this.ClientScript.RegisterHiddenField(String.Format("Hidden{0}{1}", field.InternalName, mode), "");
        }

        protected void SaveCustomDisplay(object sender, EventArgs e)
        {
            fieldProperties = new Dictionary<string, Dictionary<string, string>>();
            this.CurrentList.ParentWeb.AllowUnsafeUpdates = true;

            foreach (string field in hiddenFields.Keys)
            {
                fieldProperties.Add(field, new Dictionary<string, string>());
                SPField fld;
                foreach (string mode in hiddenFields[field].Keys)
                {
                    fld = this.CurrentList.Fields.GetFieldByInternalName(field);
                    string condition = HttpContext.Current.Request.Params[hiddenFields[field][mode]].Split(";".ToCharArray())[0].ToLower();
                    if (condition == "always" || condition == "where")
                    {
                        switch (mode)
                        {
                            case "New":
                                fld.ShowInNewForm = true;
                                break;
                            case "Edit":
                                fld.ShowInEditForm = true;
                                break;
                            case "Display":
                                fld.ShowInDisplayForm = true;
                                break;
                        }
                    }
                    else
                    {
                        switch (mode)
                        {
                            case "New":
                                fld.ShowInNewForm = false;
                                break;
                            case "Edit":
                                fld.ShowInEditForm = false;
                                break;
                            case "Display":
                                fld.ShowInDisplayForm = false;
                                break;
                        }
                    }
                    try
                    {
                        fld.Update();
                    }
                    catch { }
                    fieldProperties[field].Add(mode, HttpContext.Current.Request.Params[hiddenFields[field][mode]]);
                }
            }

            //if (!this.CurrentList.ParentWeb.Properties.ContainsKey(String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(CurrentList.DefaultView.Url))))
            //    this.CurrentList.ParentWeb.Properties.Add(String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(CurrentList.DefaultView.Url)), ListDisplayUtils.ConvertToString(fieldProperties));
            //else
            //    this.CurrentList.ParentWeb.Properties[String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(CurrentList.DefaultView.Url))] = ListDisplayUtils.ConvertToString(fieldProperties);

            //this.CurrentList.ParentWeb.Properties.Update();

            GridGanttSettings gSettings = new GridGanttSettings(CurrentList);
            gSettings.DisplaySettings = ListDisplayUtils.ConvertToString(fieldProperties);
            gSettings.SaveSettings(CurrentList);

            //CoreFunctions.setListSetting(CurrentList, "DisplaySettings", ListDisplayUtils.ConvertToString(fieldProperties));

            this.CurrentList.ParentWeb.AllowUnsafeUpdates = false;

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("listedit.aspx?List=" + this.CurrentList.ID.ToString(), Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

        }

        //private string RenderCheck(SPField field)
        //{
        //    StringBuilder result = new StringBuilder();
    
        //    string chk = "";

        //    if ((fieldProperties != null) && (fieldProperties.ContainsKey(field.InternalName)) && (fieldProperties[field.InternalName].ContainsKey("ro")))
        //    {
        //        try
        //        {
        //            if (fieldProperties[field.InternalName]["ro"] == "true")
        //                chk = " checked";
        //        }
        //        catch { }
        //    }
        //    result.Append(String.Format("<input type=\"checkbox\" value=\"true\" id=\"Option{0}ro\"{1}> Read-Only", field.InternalName, chk));

        //    return result.ToString();
        //}

        private string RenderOption(SPField field, string mode, ref bool showWhere, ref bool showEdit)
        {
            StringBuilder result = new StringBuilder();            

            bool roFields = MatchROFields(field.Id);            
            result.Append(String.Format("<select id=\"Option{0}{1}\" runat=\"server\" onchange=\"javascript:OptionChange('{0}{1}');\" style=\"width: 100px;\">", field.InternalName, mode));

            
            string optionValueAlways = "";
            string optionValueNever = "";
            string optionValueWhere = "";

            if ((fieldProperties != null) && (fieldProperties.ContainsKey(field.InternalName)) && (fieldProperties[field.InternalName].ContainsKey(mode)))
            {
                string optionMode = "";
                try
                {                    
                    optionMode = fieldProperties[field.InternalName][mode];                 
                }
                catch { }
                string sSelectOption = optionMode.Split(";".ToCharArray())[0];

                if (sSelectOption.ToLower().Equals("where"))
                {
                    optionValueWhere = "selected ";
                    showEdit = true;
                }
                else
                {
                    switch (mode)
                    {
                        case "New":
                            if (field.ShowInNewForm == null)
                            {
                                optionValueAlways = "selected ";
                            }
                            else
                            {
                                if (field.ShowInNewForm.Value && roFields == false)
                                    optionValueAlways = "selected ";
                                else
                                    optionValueNever = "selected ";
                            }
                            break;
                        case "Edit":
                            if (field.ShowInEditForm == null)
                            {
                                if (field.Type == SPFieldType.Calculated)
                                {
                                    optionValueNever = "selected ";
                                }
                                else
                                {
                                    showEdit = true;
                                    optionValueAlways = "selected ";
                                }
                            }
                            else
                            {
                                if (field.ShowInEditForm.Value && roFields == false)
                                {
                                    showEdit = true;
                                    optionValueAlways = "selected ";
                                }
                                else
                                    optionValueNever = "selected ";
                            }
                            break;
                        case "Display":
                            if (field.ShowInDisplayForm == null)
                            {
                                optionValueAlways = "selected ";
                            }
                            else
                            {
                                if (field.ShowInDisplayForm.Value)
                                    optionValueAlways = "selected ";
                                else
                                    optionValueNever = "selected ";
                            }
                            break;
                        case "Editable":
                            if (sSelectOption.ToLower().Equals(""))
                                optionValueAlways = "selected ";
                            else if (sSelectOption.ToLower().Equals("always"))
                                optionValueAlways = "selected ";
                            else if (sSelectOption.ToLower().Equals("never"))
                                optionValueNever = "selected ";
                            else if (sSelectOption.ToLower().Equals("where"))
                                optionValueWhere = "selected ";
                            break;
                    }
                }

                result.Append(String.Format("<option {0}value=\"always\">Always</option>", optionValueAlways));
                result.Append(String.Format("<option {0}value=\"never\">Never</option>", optionValueNever));
                result.Append(String.Format("<option {0}value=\"where\">Where</option>", optionValueWhere));
                
                showWhere = sSelectOption.Equals("where") ? true : false;
            }
            else
            {
                switch (mode)
                {
                    case "New":
                        if (field.ShowInNewForm == null)
                        {
                            optionValueAlways = "selected ";
                        }
                        else
                        {
                            if (field.ShowInNewForm.Value && roFields == false)
                                optionValueAlways = "selected ";
                            else
                                optionValueNever = "selected ";
                        }
                        break;
                    case "Edit":
                        if (field.ShowInEditForm == null)
                        {
                            if (field.Type == SPFieldType.Calculated)
                            {
                                optionValueNever = "selected ";
                            }
                            else
                            {
                                showEdit = true;
                                optionValueAlways = "selected ";
                            }
                        }
                        else
                        {
                            if (field.ShowInEditForm.Value && roFields == false)
                            {
                                showEdit = true;
                                optionValueAlways = "selected ";
                            }
                            else
                                optionValueNever = "selected ";
                        }
                        break;
                    case "Display":
                        if (field.ShowInDisplayForm == null)
                        {
                            optionValueAlways = "selected ";
                        }
                        else
                        {
                            if(field.ShowInDisplayForm.Value)
                                optionValueAlways = "selected ";
                            else
                                optionValueNever = "selected ";
                        }
                        break;
                    case "Editable":
                        if(roFields == false)
                            optionValueAlways = "selected ";
                        else
                            optionValueNever = "selected ";
                        break;
                }

                result.Append(String.Format("<option {0}value=\"always\">Always</option>", optionValueAlways));
                result.Append(String.Format("<option {0}value=\"never\">Never</option>", optionValueNever));
                result.Append("<option value=\"where\">Where</option>");

                showWhere = false;
            }

            result.Append("</select>");
            result.Append("</td></tr>");

            return result.ToString();
        }

        private string RenderPanelWhere(SPField field, string mode, ref bool showWhere)
        {
            StringBuilder result = new StringBuilder();

            if (showWhere)
                result.Append(String.Format("<tr id=\"RowOptionPanel{0}{1}\" style=\"display:inline;\"><td style=\"width: 150px;\" ></td><td class=\"ms-authoringcontrols\">", field.InternalName, mode));
            else
                result.Append(String.Format("<tr id=\"RowOptionPanel{0}{1}\" style=\"display:none;\"><td style=\"width: 150px;\" ></td><td class=\"ms-authoringcontrols\">", field.InternalName, mode));

            result.Append(RenderWhere(field, mode));
            showWhere = false;

            return result.ToString();
        }

        private string RenderWhere(SPField field, string mode)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<table cellpadding=\"0px\" cellspacing=\"0px\" style=\"width: 100%;\">");
            result.Append("<tr><td>");

            if ((fieldProperties != null) && (fieldProperties.ContainsKey(field.InternalName)) && (fieldProperties[field.InternalName].ContainsKey(mode)))
            {
                string memMode = fieldProperties[field.InternalName][mode];
                if (memMode.Split(";".ToCharArray()).Length > 3)
                {
                    string memModeValue = memMode.Split(";".ToCharArray())[0];
                    string memOptionFieldWhere = memMode.Split(";".ToCharArray())[1];
                    string memOptionValueFieldNameWhere = "";
                    string memOptionConditionWhere = "";
                    string memOptionValueUserWhere = "";
                    string memOptionValueFieldWhere = "";

                    if (memOptionFieldWhere == "[Me]")
                    {
                        memOptionConditionWhere = memMode.Split(";".ToCharArray())[2];
                        memOptionValueUserWhere = memMode.Split(";".ToCharArray())[3];
                    }
                    else // [Field]
                    {
                        memOptionValueFieldNameWhere = memMode.Split(";".ToCharArray())[2];
                        memOptionConditionWhere = memMode.Split(";".ToCharArray())[3];
                        if (memMode.Split(";".ToCharArray()).Length > 4)
                        {
                            memOptionValueFieldWhere = memMode.Split(";".ToCharArray())[4];
                        }
                    }

                    if (memModeValue.Equals("where"))
                    {
                        result.Append(String.Format("<select id=\"OptionFieldWhere{0}{1}\" runat=\"server\" onchange=\"javascript:OptionFieldWhereChange('{0}{1}');\">", field.InternalName, mode));
                        if (memOptionFieldWhere.Equals("[Me]"))
                        {
                            result.Append("<option selected=\"selected\" value=\"[Me]\">[Me]</option>");
                            result.Append("<option value=\"[Field]\">Field</option>");
                        }
                        else
                        {
                            result.Append("<option selected=\"selected\" value=\"[Field]\">Field</option>");
                            result.Append("<option value=\"[Me]\">[Me]</option>");
                        }
                        result.Append("</select>");

                        if (memOptionFieldWhere.Equals("[Me]"))
                        {
                            result.Append(String.Format("<select id=\"OptionFieldNameWhere{0}{1}\" runat=\"server\" style=\"display:none\" >", field.InternalName, mode));
                        }
                        else
                        {
                            result.Append(String.Format("<select id=\"OptionFieldNameWhere{0}{1}\" runat=\"server\" >", field.InternalName, mode));
                        }
                        foreach (SPField fieldItem in displayableFields.Values)
                        {
                            if (memOptionValueFieldNameWhere.Equals(fieldItem.InternalName))
                                result.Append(String.Format("<option selected=\"selected\" value=\"{0}\">{1}</option>", fieldItem.InternalName, fieldItem.Title));
                            else
                                result.Append(String.Format("<option value=\"{0}\">{1}</option>", fieldItem.InternalName, fieldItem.Title));
                        }
                        //
                        result.Append("</select>");



                        result.Append(String.Format("<select id=\"OptionConditionWhere{0}{1}\" runat=\"server\" style=\"width: 200px\">", field.InternalName, mode));
                        if (memOptionFieldWhere.Equals("[Me]"))
                        {
                            result.Append(String.Format("<option {0}value=\"IsInGroup\">Is in group</option>", memOptionConditionWhere.Equals("IsInGroup") ? "selected=\"selected\" " : ""));
                            result.Append(String.Format("<option {0}value=\"IsNotInGroup\">Is not in group</option>", memOptionConditionWhere.Equals("IsNotInGroup") ? "selected=\"selected\" " : ""));
                        }
                        else
                        {
                            result.Append(String.Format("<option {0}value=\"IsEqualTo\">Is equal to</option>", memOptionConditionWhere.Equals("IsEqualTo") ? "selected=\"selected\" " : ""));
                            result.Append(String.Format("<option {0}value=\"IsNotEqualTo\">Is not equal to</option>", memOptionConditionWhere.Equals("IsNotEqualTo") ? "selected=\"selected\" " : ""));
                            result.Append(String.Format("<option {0}value=\"IsGreaterThan\">Is greater than</option>", memOptionConditionWhere.Equals("IsGreaterThan") ? "selected=\"selected\" " : ""));
                            result.Append(String.Format("<option {0}value=\"IsLessThan\">Is less than</option>", memOptionConditionWhere.Equals("IsLessThan") ? "selected=\"selected\" " : ""));
                            result.Append(String.Format("<option {0}value=\"IsGreaterThanOrEqual\">Is greater than or equal to</option>", memOptionConditionWhere.Equals("IsGreaterThanOrEqual") ? "selected=\"selected\" " : ""));
                            result.Append(String.Format("<option {0}value=\"IsLessThanOrEqual\">Is less than or equal to</option>", memOptionConditionWhere.Equals("IsLessThanOrEqual") ? "selected=\"selected\" " : ""));
                            result.Append(String.Format("<option {0}value=\"BeginWith\">Begins with</option>", memOptionConditionWhere.Equals("BeginWith") ? "selected=\"selected\" " : ""));
                            result.Append(String.Format("<option {0}value=\"EndWith\">Ends with</option>", memOptionConditionWhere.Equals("EndWith") ? "selected=\"selected\" " : ""));
                            result.Append(String.Format("<option {0}value=\"Contains\">Contains</option>", memOptionConditionWhere.Equals("Contains") ? "selected=\"selected\" " : ""));
                        }
                        result.Append("</select>");

                        if (memOptionFieldWhere.Equals("[Me]"))
                        {
                            result.Append(String.Format("<select id=\"OptionValueUserWhere{0}{1}\" runat=\"server\" style=\"width: 200px; display:inline\">", field.InternalName, mode));
                            foreach (SPGroup group in groups)
                                if (memOptionValueFieldWhere.Equals(group.Name))
                                    result.Append(String.Format("<option {0}value=\"{1}\" selected=\"selected\" >{2}</option>", memOptionValueUserWhere.Equals(group.Name) ? "selected=\"selected\" " : "", group.Name, group.Name));
                                else
                                    result.Append(String.Format("<option {0}value=\"{1}\">{2}</option>", memOptionValueUserWhere.Equals(group.Name) ? "selected=\"selected\" " : "", group.Name, group.Name));
                        }
                        else
                        {
                            result.Append(String.Format("<select id=\"OptionValueUserWhere{0}{1}\" runat=\"server\" style=\"width: 200px; display:none\">", field.InternalName, mode));
                            foreach (SPGroup group in groups)
                                if (memOptionValueFieldWhere.Equals(group.Name))
                                    result.Append(String.Format("<option selected=\"selected\" value=\"{0}\">{1}</option>", group.Name, group.Name));
                                else
                                    result.Append(String.Format("<option value=\"{0}\">{1}</option>", group.Name, group.Name));
                        }
                        result.Append("</select>");

                        if (memOptionFieldWhere.Equals("[Me]"))
                            result.Append(String.Format("<input id=\"OptionValueFieldWhere{0}{1}\" class=\"ms-long\" style=\"width: 200px; display: none\" />", field.InternalName, mode));
                        else
                            result.Append(String.Format("<input id=\"OptionValueFieldWhere{0}{1}\" class=\"ms-long\" style=\"width: 200px; display: inline\" value=\"{2}\" />", field.InternalName, mode, memOptionValueFieldWhere));
                    }
                    else
                    {
                        result.Append(String.Format("<select id=\"OptionFieldWhere{0}{1}\" runat=\"server\" onchange=\"javascript:OptionFieldWhereChange('{0}{1}');\">", field.InternalName, mode));
                        result.Append("<option selected=\"selected\" value=\"[Me]\">[Me]</option>");
                        result.Append("<option value=\"[Field]\">Field</option>");
                        result.Append("</select>");

                        result.Append(String.Format("<select id=\"OptionFieldNameWhere{0}{1}\" runat=\"server\" style=\"display:none\" >", field.InternalName, mode));
                        foreach (SPField fieldItem in displayableFields.Values)
                            result.Append(String.Format("<option value=\"{0}\">{1}</option>", fieldItem.InternalName, fieldItem.Title));

                        result.Append("</select>");

                        result.Append(String.Format("<select id=\"OptionConditionWhere{0}{1}\" runat=\"server\" style=\"width: 200px\">", field.InternalName, mode));
                        result.Append("<option selected=\"selected\" value=\"IsInGroup\">Is in group</option>");
                        result.Append("<option value=\"IsNotInGroup\">Is not in group</option>");
                        result.Append("</select>");

                        result.Append(String.Format("<select id=\"OptionValueUserWhere{0}{1}\" runat=\"server\" style=\"width: 200px\">", field.InternalName, mode));
                        foreach (SPGroup group in groups)
                            result.Append(String.Format("<option value=\"{0}\">{1}</option>", group.Name, group.Name));
                        result.Append("</select>");

                        result.Append(String.Format("<input id=\"OptionValueFieldWhere{0}{1}\" class=\"ms-long\" style=\"width: 200px; display: none\" />", field.InternalName, mode));
                    }
                }
            }
            else
            {
                result.Append(String.Format("<select id=\"OptionFieldWhere{0}{1}\" runat=\"server\" onchange=\"javascript:OptionFieldWhereChange('{0}{1}');\">", field.InternalName, mode));
                result.Append("<option selected=\"selected\" value=\"[Me]\">[Me]</option>");
                result.Append("<option value=\"[Field]\">Field</option>");
                result.Append("</select>");

                result.Append(String.Format("<select id=\"OptionFieldNameWhere{0}{1}\" runat=\"server\" style=\"display:none\" >", field.InternalName, mode));
                foreach (SPField fieldItem in displayableFields.Values)
                    result.Append(String.Format("<option value=\"{0}\">{1}</option>", fieldItem.InternalName, fieldItem.Title));
                //
                result.Append("</select>");

                result.Append(String.Format("<select id=\"OptionConditionWhere{0}{1}\" runat=\"server\" style=\"width: 200px\">", field.InternalName, mode));
                result.Append("<option selected=\"selected\" value=\"IsInGroup\">Is in group</option>");
                result.Append("<option value=\"IsNotInGroup\">Is not in group</option>");
                result.Append("</select>");

                result.Append(String.Format("<select id=\"OptionValueUserWhere{0}{1}\" runat=\"server\" style=\"width: 200px\">", field.InternalName, mode));
                foreach (SPGroup group in groups)
                    result.Append(String.Format("<option value=\"{0}\">{1}</option>", group.Name, group.Name));
                result.Append("</select>");

                result.Append(String.Format("<input id=\"OptionValueFieldWhere{0}{1}\" class=\"ms-long\" style=\"width: 200px; display: none\" />", field.InternalName, mode));
            }

            //result.Append(String.Format("&nbsp<a id=\"OptionAddMoreWhere{0}{1}\" class=\"ms-authoringcontrols\" style=\"cursor: pointer;\" onclick=\"javascript:AddMoreCondition('OptionAddMoreWhere{0}{1}','{0}{1}');\">Add more condition ...</a>", field.InternalName, mode));        
            result.Append(String.Format("<input id=\"Hidden{0}{1}\" type=\"hidden\" />", field.InternalName, mode));

            result.Append("</td></tr>");
            result.Append("</table>");

            return result.ToString();
        }

        private void RegisterScript()
        {
            computeFieldsScript.Insert(0, "function ComputeFields(){");
            computeFieldsScript.Append("}");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ComputeFields", computeFieldsScript.ToString(), true);


            string OptionChangeScript = @"function OptionChange(senderPartialId) 
                                        {
                                            var control = document.getElementById('Option' + senderPartialId);
                                            var selectedValue = control.options[control.selectedIndex].value;
                                            var controlToChange = document.getElementById('RowOptionPanel' + senderPartialId);

                                            var controlToChange2 = document.getElementById('Editable' + senderPartialId);
                                            if(controlToChange2 != null)
                                            {
                                                if(selectedValue == 'never')
                                                {
                                                    controlToChange2.style.display = 'none';
                                                }
                                                else
                                                {
                                                    controlToChange2.style.display = '';
                                                }
                                            }

                                            if(selectedValue == 'where')
                                            {
                                                controlToChange.style.display = 'inline';
                                            }
                                            else
                                            {
                                                controlToChange.style.display = 'none';
                                            }
                                        }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "OptionChange", OptionChangeScript, true);


            string OptionFieldWhereChangeScript = @"function OptionFieldWhereChange(senderPartialId)
                                                    {
                                                        var fieldControl = document.getElementById('OptionFieldWhere' + senderPartialId);
                                                        var conditionControl = document.getElementById('OptionConditionWhere' + senderPartialId);
                                                        var selectedValue =  fieldControl.options[fieldControl.selectedIndex].value;
                                                        
                                                        if(selectedValue == '[Me]') {
                                                            FillConditionForUser(conditionControl);
                                                            document.getElementById('OptionValueFieldWhere' + senderPartialId).style.display = 'none';
                                                            document.getElementById('OptionFieldNameWhere' + senderPartialId).style.display = 'none';
                                                            document.getElementById('OptionValueUserWhere' + senderPartialId).style.display = 'inline';
                                                        }
                                                        else {
                                                            FillConditionForField(conditionControl);
                                                            document.getElementById('OptionFieldNameWhere' + senderPartialId).style.display = 'inline';
                                                            document.getElementById('OptionValueUserWhere' + senderPartialId).style.display = 'none';
                                                            document.getElementById('OptionValueFieldWhere' + senderPartialId).style.display = 'inline';
                                                        }
                                                    }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "OptionFieldWhereChange", OptionFieldWhereChangeScript, true);

            string FillConditionForUserScript = @"function FillConditionForUser(conditionControl) 
                                                {
                                                    conditionControl.options.length = 2                
                                                    conditionControl.options[0].value = 'InGroup';
                                                    conditionControl.options[0].text = 'Is in group';
                                                    conditionControl.options[1].value = 'NotInGroup';
                                                    conditionControl.options[1].text = 'Is not in group';
                                                    conditionControl.selectedIndex = 0;        
                                                }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "FillConditionForUser", FillConditionForUserScript, true);

            string FillConditionForFieldScript = @"function FillConditionForField(conditionControl) 
                                                {
                                                    conditionControl.options.length = 9                
                                                    conditionControl.options[0].value = 'IsEqualTo';
                                                    conditionControl.options[0].text = 'Is equal to';
                                                    conditionControl.options[1].value = 'IsNotEqualTo';
                                                    conditionControl.options[1].text = 'Is not equal to';
                                                    conditionControl.options[2].value = 'IsGreaterThan';
                                                    conditionControl.options[2].text = 'Is greater than';
                                                    conditionControl.options[3].value = 'IsLessThan';
                                                    conditionControl.options[3].text = 'Is less than';
                                                    conditionControl.options[4].value = 'IsGreaterThanOrEqual';
                                                    conditionControl.options[4].text = 'Is greater than or equal to';
                                                    conditionControl.options[5].value = 'IsLessThanOrEqual';
                                                    conditionControl.options[5].text = 'Is less than or equal to';
                                                    conditionControl.options[6].value = 'BeginWith';
                                                    conditionControl.options[6].text = 'Begins with';
                                                    conditionControl.options[7].value = 'EndWith';
                                                    conditionControl.options[7].text = 'Ends with';
                                                    conditionControl.options[8].value = 'Contains';
                                                    conditionControl.options[8].text = 'Contains';
                                                    conditionControl.selectedIndex = 0;        
                                                }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "FillConditionForField", FillConditionForFieldScript, true);

            string ComputeFieldScript = @"function ComputeField(senderPartialId) 
                                        {
                                            var hiddenField = document.getElementById('Hidden' + senderPartialId);
                                            var option = document.getElementById('Option' + senderPartialId);
                                            var optionFieldWhere = document.getElementById('OptionFieldWhere' + senderPartialId);
                                            var optionFieldNameWhere = document.getElementById('OptionFieldNameWhere' + senderPartialId);
                                            var optionConditionWhere = document.getElementById('OptionConditionWhere' + senderPartialId);
                                            var optionValueUserWhere = document.getElementById('OptionValueUserWhere' + senderPartialId);
                                            var optionValueFieldWhere = document.getElementById('OptionValueFieldWhere' + senderPartialId);
                                            
                                            var optionValue = '';
                                            if(option.type != 'checkbox')
                                            {
                                                if (option != null) optionValue = option.options[option.selectedIndex].value;
                                                var optionFieldWhereValue = '';
                                                if (optionValue == 'where') if (optionFieldWhere != null) optionFieldWhereValue = optionFieldWhere.options[optionFieldWhere.selectedIndex].value;
                                                var optionFieldNameWhereValue = '';
                                                if (optionValue == 'where') if (optionFieldNameWhere != null) optionFieldNameWhereValue = optionFieldNameWhere.options[optionFieldNameWhere.selectedIndex].value;
                                                var optionConditionWhereValue = '';
                                                if (optionValue == 'where') if (optionConditionWhere != null) optionConditionWhereValue = optionConditionWhere.options[optionConditionWhere.selectedIndex].value;
                                                var optionValueUserWhereValue = '';
                                                if (optionValue == 'where') if (optionValueUserWhere != null) optionValueUserWhereValue = optionValueUserWhere.options[optionValueUserWhere.selectedIndex].value;
                                                var optionValueFieldWhereValue = '';
                                                if (optionValue == 'where') if (optionValueFieldWhere != null) optionValueFieldWhereValue = optionValueFieldWhere.value;
                                                
                                                if (optionFieldWhereValue == '[Me]')
                                                {
                                                    hiddenField.value = optionValue + ';' + optionFieldWhereValue + ';' + optionConditionWhereValue + ';' + optionValueUserWhereValue;
                                                }
                                                else
                                                {
                                                    hiddenField.value = optionValue + ';' + optionFieldWhereValue + ';' + optionFieldNameWhereValue + ';' + optionConditionWhereValue + ';' + optionValueFieldWhereValue;
                                                }
                                            }
                                            else
                                            {
                                                hiddenField.value = option.checked;
                                            }
                                            
                                          
                                         }";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ComputeField", ComputeFieldScript, true);

            string AddMoreConditionScript = @"function AddMoreCondition(sender, senderPartialId) 
                                            {
                                                var senderControl = document.getElementById(sender);
                                                senderControl.style.display = 'none';
                                                
                                                var newLine = document.createElement('<br/>');
                                                var newLabelAnd = document.createTextNode('And ');
                                                var newOptionAnd = document.createElement('<input type=""radio"" name=""AndOr' + senderPartialId + '"" value=""And"" checked=""checked""/>');
                                                var newLabelOr = document.createTextNode('  Or ');
                                                var newOptionOr = document.createElement('<input type=""radio"" name=""AndOr' + senderPartialId + '"" value=""Or""/>');
                                                
                                                senderControl.parentNode.appendChild(newLine);
                                                senderControl.parentNode.appendChild(newLabelAnd);
                                                senderControl.parentNode.appendChild(newOptionAnd);
                                                senderControl.parentNode.appendChild(newLabelOr);
                                                senderControl.parentNode.appendChild(newOptionOr);
                                            }";
        }
    }
}
