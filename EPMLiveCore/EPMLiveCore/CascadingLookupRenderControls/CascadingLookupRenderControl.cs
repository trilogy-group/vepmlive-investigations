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
using System.Diagnostics;
using System.Reflection;

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
        private Literal _throttleMessageLiteral;
        private Literal _spanLiteral;
        private Literal _spanClosingLiteral;
        private LiteralControl _BrClosingLiteral;
        private DataView _dataSource;
        private SPList _lookupList;
        private SPList _parentLookupList;
        private bool m_throttled;
        private DropDownList _dropList;
        private TextBox _textBox;
        private Image _dropImage;
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
                if (_dataSource == null)
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("ValueField", typeof(int));
                    table.Columns.Add("TextField", typeof(string));

                    if (!base.Field.Required)
                    {
                        DataRow r_none = table.NewRow();
                        r_none["ValueField"] = 0;
                        r_none["TextField"] = "(None)";
                        table.Rows.Add(r_none);
                    }

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

                    _dataSource = new DataView(table);
                }

                return _dataSource;
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
                "<script> if (!_LookupFieldsPropsArray) { var _LookupFieldsPropsArray = new Array(); } </script>", false);

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
                "                                             ControlInfo:  { DropDownClientId: '" + (_dropList != null ? _dropList.ClientID : string.Empty) + "', " +
                "                                                             TextBoxClientId: '" + (_textBox != null ? _textBox.ClientID : string.Empty) + "', " +
                "                                                             DropImageClientId: '" + (_dropImage != null ? _dropImage.ClientID : string.Empty) + "', " +
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

            string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            if (string.IsNullOrEmpty(fileVersion) || fileVersion.Equals("1.0.0.0"))
            {
                fileVersion = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
            }

            ScriptLink.Register(Page, "/_layouts/epmlive/ModifiedDropDown.js?v=" + fileVersion, false);

            base.OnPreRender(e);

            if (!string.IsNullOrEmpty(parent))
            {
                this.Page.ClientScript.RegisterStartupScript(GetType(), "_HideChildCascadeField_" + this.ClientID,

                    "function HideControl_" + this.ClientID + "(){ " +
                    "   if ($('#" + this.ClientID + "').length > 0){ " +
                    "       $('#" + this.ClientID + "').prop('disabled', true); " +
                    "   } else { " +
                    "       setTimeout(HideControl_" + this.ClientID + ", 500); " +
                    "   } " +
                    "} " +

                    "$(document).ready(function () { " +
                        "HideControl_" + this.ClientID + "();" +
                    "});", true);
            }
        }

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
                            _throttleMessageLiteral = new Literal
                            {
                                Text = SPHttpUtility.HtmlEncode(str)
                            };
                            _spanLiteral = new Literal
                            {
                                Text = "<span style=\"vertical-align:middle\">"
                            };
                            _spanClosingLiteral = new Literal
                            {
                                Text = "</span>"
                            };
                            this.Controls.Add(_spanLiteral);
                            this.Controls.Add(_throttleMessageLiteral);
                            this.Controls.Add(_spanClosingLiteral);
                        }
                        else
                        {
                            if (((this.DataSource == null) || (this.DataSource.Count <= 20))) // || ((base.InDesign || !SPUtility.IsIE55Up(this.Page.Request)) || SPUtility.IsAccessibilityMode(this.Page.Request)))
                            {
                                this._dropList = new DropDownList();
                                this._dropList.ID = "Lookup";
                                this._dropList.TabIndex = this.TabIndex;
                                this._dropList.DataSource = this.DataSource;
                                this._dropList.DataValueField = "ValueField";
                                this._dropList.DataTextField = "TextField";
                                this._dropList.ToolTip = SPHttpUtility.NoEncode(field.Title);
                                this._dropList.DataBind();


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
                                    if (base.Field.Required)
                                    {
                                        this._dropList.SelectedIndex = ((lookupVal.LookupId - 1) >= 0) ? (lookupVal.LookupId - 1) : 0;
                                    }
                                    else
                                    {
                                        this._dropList.SelectedIndex = lookupVal.LookupId;
                                    }
                                    this.m_hasValueSet = true;
                                }

                                this._dropList.Attributes.Add("onchange", "window.ModifiedDropDown.UpdateChildrenValues('" + field.InternalName + "');");

                                if (LookupData.Parent != "" && lookupVal == null)
                                {
                                    this._dropList.Enabled = false;
                                }

                                this.Controls.Add(this._dropList);
                            }
                            else
                            {
                                this._textBox = new TextBox();
                                this._textBox.Attributes.Add("choices", this.Choices);
                                this._textBox.Attributes.Add("match", "");
                                this._textBox.Attributes.Add("onkeydown", "CoreInvoke('HandleKey')");
                                this._textBox.Attributes.Add("onkeypress", "CoreInvoke('HandleChar')");
                                this._textBox.Attributes.Add("onfocusout", "CoreInvoke('HandleLoseFocus')");
                                this._textBox.Attributes.Add("onchange", "CoreInvoke('HandleChange')");
                                this._textBox.Attributes.Add("class", "ms-lookuptypeintextbox");
                                this._textBox.Attributes.Add("title", SPHttpUtility.HtmlEncode(field.Title));
                                this._textBox.TabIndex = this.TabIndex;
                                this._textBox.Attributes["optHid"] = this.HiddenFieldName;
                                _spanLiteral = new Literal
                                {
                                    Text = "<span style=\"vertical-align:middle\">"
                                };
                                _spanClosingLiteral = new Literal
                                {
                                    Text = "</span>"
                                };
                                this.Controls.Add(_spanLiteral);
                                this.Controls.Add(this._textBox);
                                this._textBox.Attributes.Add("opt", "_Select");
                                this._dropImage = new Image();
                                this._dropImage.ImageUrl = "/_layouts/images/dropdown.gif";
                                this._dropImage.Attributes.Add("alt", SPResource.GetString("LookupWordWheelDropdownAlt", new object[0]));
                                this._dropImage.Attributes.Add("style", "vertical-align:middle;");
                                this.Controls.Add(this._dropImage);
                                this.Controls.Add(_spanClosingLiteral);
                            }
                            if (this.m_webForeign != null)
                            {
                                this.m_webForeign.Close();
                                this.m_webForeign = null;
                            }
                            _BrClosingLiteral = new LiteralControl("<br/>");
                            this.Controls.Add(_BrClosingLiteral);

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
            this._dataSource = null;
            this.m_selectedValueIndex = -1;
        }

        private void SetFieldControlValue(object value)
        {
            if (!this.m_hasValueSet || !(this.m_value.Equals(value)))
            {
                this.Clear();
                this.m_value = value;
                this.m_hasValueSet = true;
                if (this.DataSource != null)
                {
                    if (this._dropList != null)
                    {
                        if (this.m_selectedValueIndex >= 0)
                        {
                            this._dropList.SelectedIndex = this.m_selectedValueIndex;
                        }
                        else
                        {
                            this._dropList.SelectedIndex = -1;
                        }
                    }
                    else if (this._textBox != null)
                    {
                        DataRowView view = null;
                        if (this.m_selectedValueIndex >= 0)
                        {
                            view = this._dataSource[this.m_selectedValueIndex];
                            this._textBox.Text = view["TextField"] as string;
                        }
                        if (this.Page != null)
                        {
                            string str = "0";
                            if (this.m_selectedValueIndex >= 0)
                            {
                                view = this._dataSource[this.m_selectedValueIndex];
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
                ListItem[LookupField.InternalName] = new SPFieldLookupValue(int.Parse(this._dropList.SelectedValue), this._dropList.SelectedItem.ToString());
            }
            catch { }

        }

        public override void Dispose()
        {
            _dataSource?.Dispose();
            _throttleMessageLiteral?.Dispose();
            _dropList?.Dispose();
            _textBox?.Dispose();
            _spanLiteral?.Dispose();
            _spanClosingLiteral?.Dispose();
            _BrClosingLiteral?.Dispose();
            _dropImage?.Dispose();
            base.Dispose();
        }
    }
}
