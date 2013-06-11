using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint;
using System.Web.UI;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace EPMLiveCore
{
    public class GenericEntityEditor : EntityEditorWithPicker
    {
        private GenericEntityPickerPropertyBag propBag;
        private string requiredErrTxtId = string.Empty;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.PickerDialogType = typeof(GenericPickerDialog);
            propBag = new GenericEntityPickerPropertyBag(this.CustomProperty);
        }
                
        protected override void CreateChildControls()
        {   
            base.CreateChildControls();
            
            Control browseControl = FindBrowseLink(this);
            if (browseControl != null)
            {
                SPList l = GetListFromPropBag();
                if (l != null && l.DoesUserHavePermissions(SPBasePermissions.AddListItems))
                {
                    browseControl.Parent.Controls.Add(new LiteralControl("&nbsp;"));
                    LiteralControl addItemButton = new LiteralControl();
                    addItemButton.Text = "<a id=\"" + this.ClientID + "_addItem\" title=\"Add Item\" onclick=\"window.epmLiveGenericEntityEditor.OpenUrlWithModal('" + l.DefaultNewFormUrl + "');return false;\" href=\"#\">" +
                                            "<IMG style=\"BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px\" title=\"AddItem\" alt=\"Add item to lookup list\" src=\"/_layouts/epmlive/images/Plus14.png\">" +
                                         "</a>";

                    browseControl.Parent.Controls.Add(addItemButton);
                    Image dropImg = new Image();
                    dropImg.ImageUrl = "/_layouts/epmlive/images/dropdown2.png";
                    dropImg.Attributes["id"] = propBag.Field + "_ddlShowAll";
                    dropImg.Attributes["style"] = "margin-left: -5px;;margin-top:-1px;";
                    browseControl.Parent.Controls.AddAt(0, dropImg);
                }

                //if (propBag.Required)
                //{
                //    HtmlGenericControl divClear = new HtmlGenericControl("div");
                //    divClear.Attributes.Add("style", "clear:both");
                    
                //    HtmlGenericControl errorText = new HtmlGenericControl("textarea");
                //    errorText.ID = propBag.Field + "_errorText";
                //    errorText.Attributes.Add("class", "ms-inputuserfield");

                //    browseControl.Parent.Controls.Add(divClear);
                //    browseControl.Parent.Controls.Add(errorText);
                //    requiredErrTxtId = errorText.ClientID;
                //}
            }
        }
        

        private SPList GetListFromPropBag()
        {
            SPList result = null;
            if (propBag != null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (SPWeb ew = es.OpenWeb(propBag.LookupWebID))
                        {
                            try
                            {
                                result = ew.Lists[propBag.LookupListID];
                            }
                            catch { }
                        }
                    }
                });
            }

            return result;
        }

        private Control FindBrowseLink(Control container)
        {
            Control browselink = null;
            browselink = FindControlRecursive(container, "browse");
            return browselink;
        }

        private Control FindControlRecursive(Control container, string name)
        {
            if (!string.IsNullOrEmpty(container.ID) && container.ID.Equals(name.ToLower()))
                return container;

            foreach (Control ctrl in container.Controls)
            {
                Control foundCtrl = FindControlRecursive(ctrl, name);
                if (foundCtrl != null)
                    return foundCtrl;
            }
            return null;
        }

        //protected override void Render(HtmlTextWriter writer)
        //{
        //    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_LookupFieldsPropsArray_",
        //        "if (!_LookupFieldsPropsArray) { var _LookupFieldsPropsArray = new Array(); }", true);
        //    string sSingleSelectLookupVal = string.Empty;
        //    if (!this.MultiSelect && this.Entities.Count == 1)
        //    {
        //        sSingleSelectLookupVal = (this.Entities[0] as PickerEntity).Key;
        //    }
        //    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_LookupFieldsPropsArray_Edit_" + this.ClientID,
        //        "<script>" +
        //        "if (_LookupFieldsPropsArray) { " +
        //        "   var lookupFieldProp_" + propBag.Field + " = { FieldName : '" + propBag.Field + "', " +
        //        "                                                    ControlType: '" + propBag.ControlType + "', " +
        //        "                                                    FieldInfo:    { LookupWebId: '" + propBag.LookupWebID.ToString() + "', " +
        //        "                                                                    LookupListId: '" + propBag.LookupListID.ToString() + "', " +
        //        "                                                                    LookupFieldId: '" + propBag.LookupFieldSourceFieldID.ToString() + "', " +
        //        "                                                                    LookupField: '" + propBag.LookupFieldInternalName + "'}, " +
        //        "                                                    Required: '" + propBag.Required.ToString() + "', " +
        //        "                                                    RequiredErrorTextAreaId: '" + requiredErrTxtId + "', " +
        //        "                                                    ControlInfo:  { GenericEntityDivId: '" + this.ClientID + "_upLevelDiv', " +
        //        "                                                                    GenericEntityDivIdRoot: '" + this.ClientID + "'," +
        //        "                                                                    GenericEntityCheckNameId: '" + this.ClientID + "_checkNames'," +
        //        "                                                                    CurWebURL: '" + SPContext.Current.Web.Url + "', " +
        //        "                                                                    IsMultiSelect: " + propBag.IsMultiSelect.ToLower() + ", " +
        //        "                                                                    SourceDropDownID: '" + propBag.SourceDropDownID + "', " +
        //        "                                                                    SourceControlId: '" + propBag.SourceControlID + "', " +
        //        "                                                                    SelectCandidateId: '" + propBag.SelectCandidateID + "', " +
        //        "                                                                    AddButtonId: '" + propBag.AddButtonID + "', " +
        //        "                                                                    RemoveButtonId: '" + propBag.RemoveButtonID + "', " +
        //        "                                                                    SelectResultId: '" + propBag.SelectResultID + "', " +
        //        "                                                                    SearchText: '', " +
        //        "                                                                    SingleSelectLookupVal: '" + sSingleSelectLookupVal + "', " +
        //        "                                                                    SingleSelectDisplayVal: '', " +
        //        "                                                                    CandidateIndex: '-1', " +
        //        "                                                                    AutoCompleteDivId : 'autoCompleteDiv_" + this.ClientID + "', " +
        //        "                                                                    BrowseLinkOnClick : '', " +
        //        "                                                                    AddItemLinkOnClick : '', " +
        //        "                                                                    ShowAllDdlOnClick: '' }, " +
        //        "                                                    Parent: '" + propBag.Parent + "', " +
        //        "                                                    ParentListField: '" + propBag.ParentListField + "', " +
        //        "                                                    CachedValue: ''};" +
        //        "  var arrLength = _LookupFieldsPropsArray.length; " +
        //        "  _LookupFieldsPropsArray[arrLength] = lookupFieldProp_" + propBag.Field + "; " +
        //        "  }</script>", false);

        //    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_GenericEntityEditorJS_", "<script src='/_layouts/epmlive/javascripts/GenericEntityEditor.js'></script>", false);
        //    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_GenericEntityPickerStyle_", "<link href=\"/_layouts/epmlive/GenericEntityPickerStyle.css\" rel=\"stylesheet\" type=\"text/css\" />", false);

        //    if (this.Entities.Count == 0 && propBag.Parent != "")
        //    {
        //        this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "_hideControls_",
        //            "function HideControl_" + this.ClientID + "(){ " +
        //            "   if ($('#" + this.ClientID + "_upLevelDiv').length > 0){ " +
        //            "       $('#" + this.ClientID + "_upLevelDiv').prop('disabled', true); " +
        //            "   } else { " +
        //            "       setTimeout(HideControl_" + this.ClientID + ", 500); " +
        //            "   } " +
        //            "} " +

        //            "$(document).ready(function () { " +
        //                "HideControl_" + this.ClientID + "();" +
        //            "});", true);
        //    }

        //    base.Render(writer);
        //}

        protected override void OnPreRender(EventArgs e)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_LookupFieldsPropsArray_" + this.ClientID,
                "<script>if (!_LookupFieldsPropsArray) { var _LookupFieldsPropsArray = new Array(); }</script>", false);
            string sSingleSelectLookupVal = string.Empty;
            if (!this.MultiSelect && this.Entities.Count == 1)
            {
                sSingleSelectLookupVal = (this.Entities[0] as PickerEntity).Key;
            }
            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_LookupFieldsPropsArray_Edit_" + this.ClientID,
                "<script>" +
                "if (_LookupFieldsPropsArray) { " +
                "   var lookupFieldProp_" + propBag.Field + " = { FieldName : '" + propBag.Field + "', " +
                "                                                    ControlType: '" + propBag.ControlType + "', " +
                "                                                    FieldInfo:    { LookupWebId: '" + propBag.LookupWebID.ToString() + "', " +
                "                                                                    LookupListId: '" + propBag.LookupListID.ToString() + "', " +
                "                                                                    LookupFieldId: '" + propBag.LookupFieldSourceFieldID.ToString() + "', " +
                "                                                                    LookupField: '" + propBag.LookupFieldInternalName + "'}, " +
                "                                                    Required: '" + propBag.Required.ToString() + "', " +
                "                                                    RequiredErrorTextAreaId: '" + requiredErrTxtId + "', " +
                "                                                    ControlInfo:  { GenericEntityDivId: '" + this.ClientID + "_upLevelDiv', " +
                "                                                                    GenericEntityDivIdRoot: '" + this.ClientID + "'," +
                "                                                                    GenericEntityCheckNameId: '" + this.ClientID + "_checkNames'," +
                "                                                                    CurWebURL: '" + SPContext.Current.Web.Url + "', " +
                "                                                                    IsMultiSelect: " + propBag.IsMultiSelect.ToLower() + ", " +
                "                                                                    SourceDropDownID: '" + propBag.SourceDropDownID + "', " +
                "                                                                    SourceControlId: '" + propBag.SourceControlID + "', " +
                "                                                                    SelectCandidateId: '" + propBag.SelectCandidateID + "', " +
                "                                                                    AddButtonId: '" + propBag.AddButtonID + "', " +
                "                                                                    RemoveButtonId: '" + propBag.RemoveButtonID + "', " +
                "                                                                    SelectResultId: '" + propBag.SelectResultID + "', " +
                "                                                                    SearchText: '', " +
                "                                                                    SingleSelectLookupVal: '" + sSingleSelectLookupVal + "', " +
                "                                                                    SingleSelectDisplayVal: '', " +
                "                                                                    CandidateIndex: '-1', " +
                "                                                                    AutoCompleteDivId : 'autoCompleteDiv_" + this.ClientID + "', " +
                "                                                                    BrowseLinkOnClick : '', " +
                "                                                                    AddItemLinkOnClick : '', " +
                "                                                                    ShowAllDdlOnClick: '' }, " +
                "                                                    Parent: '" + propBag.Parent + "', " +
                "                                                    ParentListField: '" + propBag.ParentListField + "', " +
                "                                                    CachedValue: ''};" +
                "  var arrLength = _LookupFieldsPropsArray.length; " +
                "  _LookupFieldsPropsArray[arrLength] = lookupFieldProp_" + propBag.Field + "; " +
                "  }</script>", false);

            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_GenericEntityEditorJS_", "<script src='/_layouts/epmlive/javascripts/GenericEntityEditor.js'></script>", false);
            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "_GenericEntityPickerStyle_", "<link href=\"/_layouts/epmlive/GenericEntityPickerStyle.css\" rel=\"stylesheet\" type=\"text/css\" />", false);

            base.OnPreRender(e);

            if (this.Entities.Count == 0 && propBag.Parent != "")
            {
                this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "_hideControls_",
                    "function HideControl_" + this.ClientID + "(){ " +
                    "   if ($('#" + this.ClientID + "_upLevelDiv').length > 0){ " +
                    "       $('#" + this.ClientID + "_upLevelDiv').prop('disabled', true); " +
                    "   } else { " +
                    "       setTimeout(HideControl_" + this.ClientID + ", 500); " +
                    "   } " +
                    "} " +

                    "$(document).ready(function () { " +
                        "HideControl_" + this.ClientID + "();" +
                    "});", true);
            }


        }

        //protected override PickerEntity[] ResolveErrorBySearch(string unresolvedText)
        //{
        //    List<PickerEntity> entities = new List<PickerEntity>();

        //    if (propBag == null)
        //    {
        //        propBag = new GenericEntityPickerPropertyBag(this.CustomProperty);
        //    }

        //    using (SPWeb web = SPContext.Current.Site.OpenWeb(propBag.LookupWebID))
        //    {
        //        SPList list = web.Lists[propBag.LookupListID];
        //        SPField field = list.Fields[propBag.LookupFieldInternalName];
        //        string valueType = field.TypeAsString;

        //        if (field.Type == SPFieldType.Calculated)
        //        {
        //            valueType = "Text";
        //        }

        //        SPQuery query = new SPQuery();
        //        query.ViewAttributes = "Scope=\"Recursive\"";
        //        query.Query =
        //            string.Format(
        //                "<Where><Contains><FieldRef Name=\"{0}\"/><Value Type=\"{1}\">{2}</Value></Contains></Where>",
        //                field.InternalName, valueType, unresolvedText);
        //        SPListItemCollection items = list.GetItems(query);

        //        foreach (SPListItem item in items)
        //        {
        //            entities.Add(this.GetEntity(item));
        //        }
        //    }

        //    return entities.ToArray();
        //}

        public override PickerEntity ValidateEntity(PickerEntity needsValidation)
        {
            PickerEntity entity = needsValidation;

            if (propBag == null)
            {
                propBag = new GenericEntityPickerPropertyBag(this.CustomProperty);
            }

            if (!string.IsNullOrEmpty(needsValidation.Key))
            {
                using (SPWeb web = SPContext.Current.Site.OpenWeb(propBag.LookupWebID))
                {
                    SPList list = web.Lists[propBag.LookupListID];
                    SPField field = null;
                    string fieldType = null;

                    if (needsValidation.Key == needsValidation.DisplayText)
                    {
                        field = list.Fields.GetFieldByInternalName(propBag.LookupFieldInternalName);
                        fieldType = field.TypeAsString;
                    }
                    else
                    {
                        field = list.Fields[SPBuiltInFieldId.ID];
                        fieldType = field.TypeAsString;
                    }

                    string valueType = field.TypeAsString;
                    if (field.Type == SPFieldType.Calculated)
                    {
                        valueType = "Text";
                    }

                    string queryString = String.Empty;

                    queryString = string.Format(
                    "<Where><Eq><FieldRef Name=\"{0}\"/><Value Type=\"{1}\">{2}</Value></Eq></Where>",
                    field.InternalName, valueType, needsValidation.Key);

                    SPQuery queryByTitle = new SPQuery();
                    queryByTitle.Query = queryString;
                    queryByTitle.ViewAttributes = "Scope=\"Recursive\"";
                    SPListItemCollection items = list.GetItems(queryByTitle);
                    if (items.Count == 1)
                    {
                        entity = this.GetEntity(items[0]);
                    }

                }
            }

            return entity;

        }

        private PickerEntity GetEntity(SPListItem item)
        {
            GenericEntityPickerPropertyBag propertyBag = new GenericEntityPickerPropertyBag(this.CustomProperty);

            PickerEntity entity = new PickerEntity();
            string displayValue = null;
            try
            {
                displayValue = item[propertyBag.LookupFieldInternalName].ToString();
            }
            catch
            {
                //field has been deleted
            }

            if (displayValue != null
                && item.Fields.GetFieldByInternalName(propertyBag.LookupFieldInternalName).Type == SPFieldType.Calculated
                && item[propertyBag.LookupFieldInternalName] != null
                && item[propertyBag.LookupFieldInternalName].ToString().Contains("#"))
            {
                entity.DisplayText = displayValue.ToString().Split('#')[1];
            }
            else
                entity.DisplayText = displayValue ?? "";
            entity.Key = item.ID.ToString();
            entity.Description = entity.DisplayText;
            entity.IsResolved = true;

            return entity;
        }

        //protected override PickerEntity[] ResolveErrorBySearch(string unresolvedText)
        //{
        //    List<PickerEntity> entities = new List<PickerEntity>();

        //    using (SPWeb web = SPContext.Current.Site.OpenWeb(propBag.LookupWebID))
        //    {

        //        SPList list = web.Lists[propBag.LookupListID];
        //        SPField field = list.Fields[propBag.LookupFieldName];
        //        string valueType = field.TypeAsString;

        //        if (field.Type == SPFieldType.Calculated)
        //        {
        //            valueType = "Text";
        //        }

        //        SPQuery query = new SPQuery();
        //        query.ViewAttributes = "Scope=\"Recursive\"";
        //        query.Query =
        //            string.Format(
        //                "<Where><Contains><FieldRef ID=\"{0}\"/><Value Type=\"{1}\">{2}</Value></Contains></Where>",
        //                propBag.LookupFieldName, valueType, unresolvedText);
        //        SPListItemCollection items = list.GetItems(query);

        //        foreach (SPListItem item in items)
        //        {
        //            entities.Add(this.GetEntity(item));
        //        }
        //    }

        //    return entities.ToArray();
        //}

    }


}
