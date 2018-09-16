using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class CascadingLookupRenderControl : LookupField
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

        private DataView _dataSource;
        private SPList _lookupList;
        private bool _throttled;
        private DropDownList DropList { get; set; }
        private TextBox TextField { get; set; }
        private Image DropImage { get; set; }
        private int SelectedValueIndex { get; set; }

        private SPList LookupList
        {
            get
            {
                if (_lookupList == null)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (var site = new SPSite(SPContext.Current.Site.ID))
                        {
                            using (var web = site.OpenWeb(SPContext.Current.Web.ID))
                            {
                                _lookupList = web.Lists[new Guid(LookupField.LookupList)];
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
                if ((!_throttled && LookupList != null)
                    && (LookupList.IsThrottled 
                    && !Web.Site.WebApplication.CurrentUserIgnoreThrottle()))
                {
                    _throttled = true;
                }
                return _throttled;
            }
        }

        private ICollection DataSource
        {
            get
            {
                if (_dataSource == null)
                {
                    var table = new DataTable();
                    table.Columns.Add("ValueField", typeof(int));
                    table.Columns.Add("TextField", typeof(string));

                    if (!base.Field.Required)
                    {
                        var rowNone = table.NewRow();
                        rowNone["ValueField"] = 0;
                        rowNone["TextField"] = "(None)";
                        table.Rows.Add(rowNone);
                    }

                    var items = LookupList.Items;
                    foreach (SPListItem item in items)
                    {
                        object fieldValue = null;
                        var fieldValueInString = string.Empty;

                        try
                        {
                            fieldValue = item[LookupField.LookupField];
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                        }

                        try
                        {
                            fieldValueInString = fieldValue.ToString();
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                        }

                        var row = table.NewRow();
                        row["ValueField"] = item.ID;
                        row["TextField"] = item[LookupField.LookupField];
                        table.Rows.Add(row);
                    }

                    _dataSource = new DataView(table);
                }

                return _dataSource;
            }
        }

        private string Choices
        {
            get
            {
                var builder = new StringBuilder();
                var flag = true;
                foreach (DataRowView view in DataSource)
                {
                    var str = ((string)view["TextField"]).Replace("|", "||");
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
                return "SP" + Field + "_Hidden";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(
                Page.GetType(),
                "_LookupFieldsPropsArray_",
                "<script> if (!_LookupFieldsPropsArray) { var _LookupFieldsPropsArray = new Array(); } </script>",
                false);

            var fieldName = LookupData.Field != "none"
                ? LookupData.Field
                : LookupField.InternalName;
            var type = LookupData.Type;
            parent = LookupData.Parent;
            var parentListField = LookupData.ParentListField;

            Page.ClientScript.RegisterClientScriptBlock(
                Page.GetType(),
                "_LookupFieldsPropsArray_Edit_" + ClientID,
                "<script>" +
                "if (_LookupFieldsPropsArray) { " +
                "   var lookupFieldProp_" + fieldName + " = { FieldName : '" + fieldName + "', " +
                "                                             ControlType: '" + type + "', " +
                "                                             FieldInfo: { LookupWebId: '" + LookupField.LookupWebId.ToString() + "', " +
                "                                                          LookupListId: '" + LookupField.LookupList.ToString() + "', " +
                "                                                          LookupField: '" + LookupField.LookupField.ToString() + "' }, " +
                "                                             ControlInfo:  { DropDownClientId: '" + (DropList != null ? DropList.ClientID : string.Empty) + "', " +
                "                                                             TextBoxClientId: '" + (TextField != null ? TextField.ClientID : string.Empty) + "', " +
                "                                                             DropImageClientId: '" + (DropImage != null ? DropImage.ClientID : string.Empty) + "', " +
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

            var fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
                .FileVersion;
            if (string.IsNullOrWhiteSpace(fileVersion) || fileVersion.Equals("1.0.0.0"))
            {
                fileVersion = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
            }

            ScriptLink.Register(Page, "/_layouts/epmlive/ModifiedDropDown.js?v=" + fileVersion, false);

            base.OnPreRender(e);

            if (!string.IsNullOrWhiteSpace(parent))
            {
                Page.ClientScript.RegisterStartupScript(
                    GetType(),
                    "_HideChildCascadeField_" + ClientID,
                    "function HideControl_" + ClientID + "(){ " +
                    "   if ($('#" + ClientID + "').length > 0){ " +
                    "       $('#" + ClientID + "').prop('disabled', true); " +
                    "   } else { " +
                    "       setTimeout(HideControl_" + ClientID + ", 500); " +
                    "   } " +
                    "} " +
                    "$(document).ready(function () { " +
                        "HideControl_" + ClientID + "();" +
                    "});",
                    true);
            }
        }

        private void Clear()
        {
            _dataSource = null;
            SelectedValueIndex = -1;
        }

        public override void UpdateFieldValueInItem()
        {
            try
            {
                ListItem[LookupField.InternalName] = new SPFieldLookupValue(int.Parse(DropList.SelectedValue), DropList.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public override void Dispose()
        {
            _dataSource?.Dispose();
            ThrottleMessageLiteral?.Dispose();
            DropList?.Dispose();
            TextField?.Dispose();
            SpanLiteral?.Dispose();
            SpanClosingLiteral?.Dispose();
            BrClosingLiteral?.Dispose();
            DropImage?.Dispose();
            base.Dispose();
        }
    }
}
