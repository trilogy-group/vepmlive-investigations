using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Data;
using Microsoft.SharePoint;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Utilities;
using System.Globalization;
using System.Web.UI;

namespace EPMLiveCore
{
    public class CascadingLookupRenderControl : LookupField
    {
        public LookupConfigData LookupData { get; set; }
        public SPFieldLookup LookupField { get; set; }
        public string CustomProperty { get; set; }
        private GenericEntityPickerPropertyBag propBag;
        private string parent = string.Empty;

        protected override void OnInit(EventArgs e)
        {
            propBag = new GenericEntityPickerPropertyBag(CustomProperty);
            base.OnInit(e);
        }
        private DataView m_dataSource;
        private SPList _lookupList;
        private SPList _parentLookupList;
        private bool m_throttled;
        private DropDownList m_dropList;
        private TextBox m_tbx;
        private Image m_dropImage;
        private List<int> m_ids;
        private object m_value;
        private int m_selectedValueIndex;
        private SPWeb m_webForeign;
        private bool m_hasValueSet;


        private SPList LookupList
        {
            get
            {
                if (_lookupList == null)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                        {
                            using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                            {
                                _lookupList = ew.Lists[new Guid(LookupField.LookupList)];
                            }
                        }
                    });
                }

                return _lookupList;
            }
        }





        private bool Throttled
        {
            get
            {
                if ((!this.m_throttled && (this.LookupList != null)) && (this.LookupList.IsThrottled && !this.Web.Site.WebApplication.CurrentUserIgnoreThrottle()))
                {
                    this.m_throttled = true;
                }
                return this.m_throttled;
            }
        }



        private ICollection DataSource
        {
            get
            {
                if (m_dataSource == null)
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("ValueField", typeof(int));
                    table.Columns.Add("TextField", typeof(string));
                    DataRow r_none = table.NewRow();
                    r_none["ValueField"] = 0;
                    r_none["TextField"] = "(None)";
                    table.Rows.Add(r_none);

                    SPListItemCollection items = LookupList.Items;

                    //if (LookupData.Parent != "none" && LookupData.ParentListField != "none")
                    //{
                    //    object fv = null;
                    //    string valueToMatch = string.Empty;
                    //    try
                    //    {
                    //        fv = ListItem[LookupData.Parent];
                    //    }
                    //    catch { }

                    //    if (fv != null)
                    //    {
                    //        valueToMatch = fv.ToString();
                    //    }

                    //    if (!string.IsNullOrEmpty(valueToMatch))
                    //    {
                    //        SPSecurity.RunWithElevatedPrivileges(delegate()
                    //        {
                    //            using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                    //            {
                    //                using (SPWeb ew = es.OpenWeb())
                    //                {
                    //                    SPList l = ew.Lists[LookupField.LookupList];
                    //                    SPListItemCollection itemsCol = l.Items;
                    //                    foreach (SPListItem i in itemsCol)
                    //                    {
                    //                        object childFv = null;
                    //                        string sChildFv = string.Empty;
                    //                        try
                    //                        {
                    //                            childFv = i[LookupData.ParentListField];
                    //                        }
                    //                        catch { }

                    //                        if (childFv != null)
                    //                        {
                    //                            sChildFv = childFv.ToString();
                    //                        }

                    //                        if (sChildFv == valueToMatch)
                    //                        {
                    //                            DataRow r = table.NewRow();
                    //                            r["ValueField"] = i.ID;
                    //                            r["TextField"] = i[LookupField.LookupField];
                    //                            table.Rows.Add(r);
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        });
                    //    }

                    //}
                    //else
                    //{
                        //if (LookupData.IsParent && LookupData.Parent == "none")
                        //{
                        foreach (SPListItem item in items)
                        {
                            object fv = null;
                            string sfv = string.Empty;

                            try
                            {
                                fv = item[LookupField.LookupField];
                            }
                            catch { }

                            try
                            {
                                sfv = fv.ToString();
                            }
                            catch { }

                            DataRow r = table.NewRow();
                            r["ValueField"] = item.ID;
                            r["TextField"] = item[LookupField.LookupField];
                            table.Rows.Add(r);
                        }
                        //}

                    //}

                    m_dataSource = new DataView(table);
                }

                return m_dataSource;
            }
        }

        private string Choices
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                bool flag = true;
                foreach (DataRowView view in this.DataSource)
                {
                    string str = (view["TextField"] as string).Replace("|", "||");
                    if (flag)
                    {
                        builder.Append(str);
                        flag = false;
                        builder.AppendFormat("|{0}", view["ValueField"]);
                    }
                    else
                    {
                        builder.AppendFormat("|{0}", str);
                        builder.AppendFormat("|{0}", view["ValueField"]);
                    }
                }
                return builder.ToString();
            }
        }

        private string HiddenFieldName
        {
            get
            {
                return ("SP" + Field + "_Hidden");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //ScriptLink.Register(Page, "/_layouts/epmlive/jQueryLibrary/jquery-1.6.2.min.js", false);

            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_LookupFieldsPropsArray_",
                "<script>if (!_LookupFieldsPropsArray) { var _LookupFieldsPropsArray = new Array(); }</script>", false);

            string fieldName = (LookupData.Field != "none" ? LookupData.Field : LookupField.InternalName);
            string type = LookupData.Type;
            parent = LookupData.Parent;
            string parentListField = LookupData.ParentListField;

            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_LookupFieldsPropsArray_Edit_" + this.ClientID,
                "<script>" +
                "if (_LookupFieldsPropsArray) { " +
                "   var lookupFieldProp_" + fieldName + " = { FieldName : '" + fieldName + "', " +
                "                                             ControlType: '" + type + "', " +
                "                                             FieldInfo: { LookupWebId: '" + LookupField.LookupWebId.ToString() + "', " +
                "                                                          LookupListId: '" + LookupField.LookupList.ToString() + "', " +
                "                                                          LookupField: '" + LookupField.LookupField.ToString() + "' }, " +
                "                                             ControlInfo:  { DropDownClientId: '" + (m_dropList != null ? m_dropList.ClientID : string.Empty) + "', " +
                "                                                             TextBoxClientId: '" + (m_tbx != null ? m_tbx.ClientID : string.Empty) + "', " +
                "                                                             DropImageClientId: '" + (m_dropImage != null ? m_dropImage.ClientID : string.Empty) + "', " +
                "                                                             CurWebURL: '" + SPContext.Current.Web.Url + "', " +
                "                                                             IsMultiSelect: " + propBag.IsMultiSelect.ToLower() + ", " +
                "                                                             SourceControlId: '" + propBag.SourceControlID + "', " +
                "                                                             SearchText: '', " +
                "                                                             SingleSelectLookupVal: '', " +
                "                                                             SingleSelectDisplayVal: ''}, " +
                "                                             Parent: '" + parent + "', " +
                "                                             ParentListField: '" + parentListField + "', " +
                "                                             CachedValue: ''};" +
                "  var arrLength = _LookupFieldsPropsArray.length; " +
                "  _LookupFieldsPropsArray[arrLength] = lookupFieldProp_" + fieldName + "}; " +
                "</script>"
                , false);

            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_ModifiedDropDownJS_", "<script src='/_layouts/epmlive/ModifiedDropDown.js'></script>", false);

            base.OnPreRender(e);

        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);

        //    if (!string.IsNullOrEmpty(parent))
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(GetType(), "_HideChildCascadeField_" + this.ClientID,

        //            "$(document).ready(function (){" +
        //                "$('#" + this.ClientID + "').prop('disabled', true);" +
        //                "$('#" + this.ClientID + "').change(function(){" +
        //                    "alert('value changed');" +
        //                "});" +
        //            "});"
        //            , true);
        //    }
        //}

        protected override void CreateChildControls()
        {
            if (base.IsFieldValueCached)
            {
                base.CreateChildControls();
            }
            else if (base.Field != null)
            {
                base.CreateChildControls();
                if (base.ControlMode != SPControlMode.Display)
                {
                    SPFieldLookup field = (SPFieldLookup)base.Field;
                    if (!field.AllowMultipleValues)
                    {
                        this.Controls.Clear();
                        if (this.Throttled)
                        {
                            string str;
                            uint maxItemsPerThrottledOperation = this.Web.Site.WebApplication.MaxItemsPerThrottledOperation;
                            if (base.Field.Required)
                            {
                                str = SPResource.GetString("RequiredLookupThrottleMessage", new object[] { maxItemsPerThrottledOperation.ToString(CultureInfo.InvariantCulture) });
                            }
                            else
                            {
                                str = SPResource.GetString("LookupThrottleMessage", new object[] { maxItemsPerThrottledOperation.ToString(CultureInfo.InvariantCulture) });
                            }
                            Literal child = new Literal
                            {
                                Text = SPHttpUtility.HtmlEncode(str)
                            };
                            Literal literal2 = new Literal
                            {
                                Text = "<span style=\"vertical-align:middle\">"
                            };
                            Literal literal3 = new Literal
                            {
                                Text = "</span>"
                            };
                            this.Controls.Add(literal2);
                            this.Controls.Add(child);
                            this.Controls.Add(literal3);
                        }
                        else
                        {
                            if (((this.DataSource == null) || (this.DataSource.Count <= 20))) // || ((base.InDesign || !SPUtility.IsIE55Up(this.Page.Request)) || SPUtility.IsAccessibilityMode(this.Page.Request)))
                            {
                                this.m_dropList = new DropDownList();
                                this.m_dropList.ID = "Lookup";
                                this.m_dropList.TabIndex = this.TabIndex;
                                this.m_dropList.DataSource = this.DataSource;
                                this.m_dropList.DataValueField = "ValueField";
                                this.m_dropList.DataTextField = "TextField";
                                this.m_dropList.ToolTip = SPHttpUtility.NoEncode(field.Title);
                                this.m_dropList.DataBind();


                                object fv = null;
                                SPFieldLookupValue lookupVal = null;
                                try
                                {
                                    fv = ListItem[LookupField.InternalName];
                                    if (fv != null)
                                    {
                                        lookupVal = new SPFieldLookupValue(fv.ToString());
                                    }
                                }
                                catch { }

                                if (lookupVal != null)
                                {
                                    this.m_value = lookupVal.ToString();
                                    this.m_dropList.SelectedIndex = lookupVal.LookupId;
                                    this.m_hasValueSet = true;
                                }

                                this.m_dropList.Attributes.Add("onchange", "window.ModifiedDropDown.UpdateChildrenValues('" + field.InternalName + "');");

                                if (LookupData.Parent != "" && lookupVal == null)
                                {
                                    this.m_dropList.Enabled = false;
                                }

                                this.Controls.Add(this.m_dropList);
                            }
                            else
                            {
                                this.m_tbx = new TextBox();
                                this.m_tbx.Attributes.Add("choices", this.Choices);
                                this.m_tbx.Attributes.Add("match", "");
                                this.m_tbx.Attributes.Add("onkeydown", "CoreInvoke('HandleKey')");
                                this.m_tbx.Attributes.Add("onkeypress", "CoreInvoke('HandleChar')");
                                this.m_tbx.Attributes.Add("onfocusout", "CoreInvoke('HandleLoseFocus')");
                                this.m_tbx.Attributes.Add("onchange", "CoreInvoke('HandleChange')");
                                this.m_tbx.Attributes.Add("class", "ms-lookuptypeintextbox");
                                this.m_tbx.Attributes.Add("title", SPHttpUtility.HtmlEncode(field.Title));
                                this.m_tbx.TabIndex = this.TabIndex;
                                this.m_tbx.Attributes["optHid"] = this.HiddenFieldName;
                                Literal literal4 = new Literal
                                {
                                    Text = "<span style=\"vertical-align:middle\">"
                                };
                                Literal literal5 = new Literal
                                {
                                    Text = "</span>"
                                };
                                this.Controls.Add(literal4);
                                this.Controls.Add(this.m_tbx);
                                this.m_tbx.Attributes.Add("opt", "_Select");
                                this.m_dropImage = new Image();
                                this.m_dropImage.ImageUrl = "/_layouts/images/dropdown.gif";
                                this.m_dropImage.Attributes.Add("alt", SPResource.GetString("LookupWordWheelDropdownAlt", new object[0]));
                                this.m_dropImage.Attributes.Add("style", "vertical-align:middle;");
                                this.Controls.Add(this.m_dropImage);
                                this.Controls.Add(literal5);
                            }
                            if (this.m_webForeign != null)
                            {
                                this.m_webForeign.Close();
                                this.m_webForeign = null;
                            }
                            this.Controls.Add(new LiteralControl("<br/>"));

                            object fv2 = null;
                            try
                            {
                                fv2 = ListItem[LookupField.InternalName];
                            }
                            catch { }

                            if (fv2 != null)
                            {
                                this.SetFieldControlValue(fv2);
                            }
                            
                        }
                    }
                }
            }

        }

        private void Clear()
        {
            this.m_ids = null;
            this.m_dataSource = null;
            this.m_selectedValueIndex = -1;
        }

        private void SetFieldControlValue(object value)
        {
            if (!(this.m_value.Equals(value)) || !this.m_hasValueSet)
            {
                this.Clear();
                this.m_value = value;
                this.m_hasValueSet = true;
                if (this.DataSource != null)
                {
                    if (this.m_dropList != null)
                    {
                        if (this.m_selectedValueIndex >= 0)
                        {
                            this.m_dropList.SelectedIndex = this.m_selectedValueIndex;
                        }
                        else
                        {
                            this.m_dropList.SelectedIndex = -1;
                        }
                    }
                    else if (this.m_tbx != null)
                    {
                        DataRowView view = null;
                        if (this.m_selectedValueIndex >= 0)
                        {
                            view = this.m_dataSource[this.m_selectedValueIndex];
                            this.m_tbx.Text = view["TextField"] as string;
                        }
                        if (this.Page != null)
                        {
                            string str = "0";
                            if (this.m_selectedValueIndex >= 0)
                            {
                                view = this.m_dataSource[this.m_selectedValueIndex];
                                str = ((int)view["ValueField"]).ToString(CultureInfo.InvariantCulture);
                            }
                            else if (this.Page.IsPostBack)
                            {
                                str = this.Context.Request.Form[this.HiddenFieldName];
                                if (string.IsNullOrEmpty(str))
                                {
                                    str = "0";
                                }
                            }
                            this.Page.ClientScript.RegisterHiddenField(this.HiddenFieldName, str);
                        }
                    }
                }
            }
        }


        public override void UpdateFieldValueInItem()
        {
            //base.UpdateFieldValueInItem();
            try
            {
                ListItem[LookupField.InternalName] = new SPFieldLookupValue(int.Parse(this.m_dropList.SelectedValue), this.m_dropList.SelectedItem.ToString());
            }
            catch { }

        }

    }
}
