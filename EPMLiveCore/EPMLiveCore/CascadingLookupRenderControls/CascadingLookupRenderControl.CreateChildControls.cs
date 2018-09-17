using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class CascadingLookupRenderControl : LookupField
    {
        private Literal ThrottleMessageLiteral { get; set; }
        private Literal SpanLiteral { get; set; }
        private Literal SpanClosingLiteral { get; set; }
        private LiteralControl BrClosingLiteral { get; set; }
        private object LookupValue { get; set; }
        private SPWeb WebForeign { get; set; }
        private bool HasValueSet { get; set; }

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
                    var field = (SPFieldLookup)base.Field;
                    if (!field.AllowMultipleValues)
                    {
                        Controls.Clear();
                        if (Throttled)
                        {
                            AddThrottledControls();
                        }
                        else
                        {
                            if (DataSource == null || DataSource.Count <= 20)
                            {
                                AddDropdown(field);
                            }
                            else
                            {
                                AddDropImage(field);
                            }

                            if (WebForeign != null)
                            {
                                WebForeign.Close();
                                WebForeign = null;
                            }
                            BrClosingLiteral = new LiteralControl("<br/>");
                            Controls.Add(BrClosingLiteral);

                            object fieldValue2 = null;
                            try
                            {
                                fieldValue2 = ListItem[LookupField.InternalName];
                            }
                            catch (Exception ex)
                            {
                                Trace.WriteLine(ex.ToString());
                            }

                            if (fieldValue2 != null)
                            {
                                SetFieldControlValue(fieldValue2);
                            }
                        }
                    }
                }
            }
        }

        private void AddDropImage(SPFieldLookup field)
        {
            TextField = new TextBox();
            TextField.Attributes.Add("choices", Choices);
            TextField.Attributes.Add("match", string.Empty);
            TextField.Attributes.Add("onkeydown", "CoreInvoke('HandleKey')");
            TextField.Attributes.Add("onkeypress", "CoreInvoke('HandleChar')");
            TextField.Attributes.Add("onfocusout", "CoreInvoke('HandleLoseFocus')");
            TextField.Attributes.Add("onchange", "CoreInvoke('HandleChange')");
            TextField.Attributes.Add("class", "ms-lookuptypeintextbox");
            TextField.Attributes.Add("title", SPHttpUtility.HtmlEncode(field.Title));
            TextField.TabIndex = TabIndex;
            TextField.Attributes["optHid"] = HiddenFieldName;
            SpanLiteral = new Literal
            {
                Text = "<span style=\"vertical-align:middle\">"
            };
            SpanClosingLiteral = new Literal
            {
                Text = "</span>"
            };
            Controls.Add(SpanLiteral);
            Controls.Add(TextField);
            TextField.Attributes.Add("opt", "_Select");
            DropImage = new Image();
            DropImage.ImageUrl = "/_layouts/images/dropdown.gif";
            DropImage.Attributes.Add("alt", SPResource.GetString("LookupWordWheelDropdownAlt", new object[0]));
            DropImage.Attributes.Add("style", "vertical-align:middle;");
            Controls.Add(DropImage);
            Controls.Add(SpanClosingLiteral);
        }

        private void AddDropdown(SPFieldLookup field)
        {
            DropList = new DropDownList();
            DropList.ID = "Lookup";
            DropList.TabIndex = TabIndex;
            DropList.DataSource = DataSource;
            DropList.DataValueField = "ValueField";
            DropList.DataTextField = "TextField";
            DropList.ToolTip = SPHttpUtility.NoEncode(field.Title);
            DropList.DataBind();


            object fieldValue = null;
            SPFieldLookupValue lookupVal = null;
            try
            {
                fieldValue = ListItem[LookupField.InternalName];
                if (fieldValue != null)
                {
                    lookupVal = new SPFieldLookupValue(fieldValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            if (lookupVal != null)
            {
                LookupValue = lookupVal.ToString();
                if (base.Field.Required)
                {
                    DropList.SelectedIndex = lookupVal.LookupId - 1 >= 0
                        ? lookupVal.LookupId - 1
                        : 0;
                }
                else
                {
                    DropList.SelectedIndex = lookupVal.LookupId;
                }
                HasValueSet = true;
            }

            DropList.Attributes.Add(
                "onchange",
                "window.ModifiedDropDown.UpdateChildrenValues('" + field.InternalName + "');");

            if (LookupData.Parent != "" && lookupVal == null)
            {
                DropList.Enabled = false;
            }

            Controls.Add(DropList);
        }

        private void AddThrottledControls()
        {
            var maxItemsPerThrottledOperation = Web.Site.WebApplication.MaxItemsPerThrottledOperation;
            string throttleMessage = base.Field.Required
                ? throttleMessage = SPResource.GetString(
                    "RequiredLookupThrottleMessage",
                    new object[]
                    {
                        maxItemsPerThrottledOperation.ToString(CultureInfo.InvariantCulture)
                    })
                : throttleMessage = SPResource.GetString(
                    "LookupThrottleMessage",
                    new object[]
                    {
                        maxItemsPerThrottledOperation.ToString(CultureInfo.InvariantCulture)
                    });

            ThrottleMessageLiteral = new Literal
            {
                Text = SPHttpUtility.HtmlEncode(throttleMessage)
            };
            SpanLiteral = new Literal
            {
                Text = "<span style=\"vertical-align:middle\">"
            };
            SpanClosingLiteral = new Literal
            {
                Text = "</span>"
            };
            Controls.Add(SpanLiteral);
            Controls.Add(ThrottleMessageLiteral);
            Controls.Add(SpanClosingLiteral);
        }

        private void SetFieldControlValue(object fieldValue)
        {
            if (!HasValueSet || !LookupValue.Equals(fieldValue))
            {
                Clear();
                LookupValue = fieldValue;
                HasValueSet = true;
                if (DataSource != null)
                {
                    if (DropList != null)
                    {
                        DropList.SelectedIndex = SelectedValueIndex >= 0
                            ? SelectedValueIndex
                            : -1;
                    }
                    else if (TextField != null)
                    {
                        DataRowView view = null;
                        if (SelectedValueIndex >= 0)
                        {
                            view = _dataSource[SelectedValueIndex];
                            TextField.Text = view["TextField"] as string;
                        }
                        if (Page != null)
                        {
                            var strFieldValue = "0";
                            if (SelectedValueIndex >= 0)
                            {
                                view = _dataSource[SelectedValueIndex];
                                strFieldValue = ((int)view["ValueField"]).ToString(CultureInfo.InvariantCulture);
                            }
                            else if (Page.IsPostBack)
                            {
                                strFieldValue = Context.Request.Form[HiddenFieldName];
                                if (string.IsNullOrWhiteSpace(strFieldValue))
                                {
                                    strFieldValue = "0";
                                }
                            }
                            Page.ClientScript.RegisterHiddenField(HiddenFieldName, strFieldValue);
                        }
                    }
                }
            }
        }
    }
}
