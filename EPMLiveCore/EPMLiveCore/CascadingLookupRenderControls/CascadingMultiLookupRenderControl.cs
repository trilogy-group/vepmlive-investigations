﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class CascadingMultiLookupRenderControl : MultipleLookupField
    {
        public LookupConfigData LookupData { get; set; }
        public SPFieldLookup LookupField { get; set; }
        public string CustomProperty { get; set; }
        private GenericEntityPickerPropertyBag propBag;

        protected override void OnInit(EventArgs e)
        {
            propBag = new GenericEntityPickerPropertyBag(CustomProperty);
            base.OnInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            //ScriptLink.Register(Page, "/_layouts/epmlive/jQueryLibrary/jquery-1.6.2.min.js", false);

            Page.ClientScript.RegisterClientScriptBlock(GetType(), "_LookupFieldsPropsArray_",
                "if (!_LookupFieldsPropsArray) { var _LookupFieldsPropsArray = new Array(); }", true);

            this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "_LookupFieldsPropsArray_Edit_" + this.ClientID,
                
                "if (_LookupFieldsPropsArray) { " +
                "   var lookupFieldProp_" + LookupData.Field + " = { FieldName : '" + LookupData.Field + "', " +
                "                                                    ControlType: '" + LookupData.Type + "', " +
                "                                                    FieldInfo: { LookupWebId: '" + LookupField.LookupWebId.ToString() + "', " +
                "                                                                 LookupListId: '" + LookupField.LookupList.ToString() + "', " +
                "                                                                 LookupFieldId: '" + LookupField.Id.ToString() + "', " +
                "                                                                 LookupField: '" + LookupField.LookupField.ToString() + "'}, " +
                "                                                    ControlInfo: { SelectCandidateId: '" + TemplateContainer.ClientID + "_SelectCandidate', " +
                "                                                                   AddButtonId: '" + TemplateContainer.ClientID + "_AddButton'," +
                "                                                                   RemoveButtonId: '" + TemplateContainer.ClientID + "_RemoveButton'," +
                "                                                                   SelectResultId: '" + TemplateContainer.ClientID + "_SelectResult', " +
                "                                                                   SourceSelectCandidateID: '" + propBag.SelectCandidateID + "', " +
                "                                                                   SourceAddButtonID: '" + propBag.AddButtonID + "', " +
                "                                                                   SourceRemoveButtonID: '" + propBag.RemoveButtonID + "', " +
                "                                                                   SourceSelectResultID: '" + propBag.SelectResultID + "', " +
                "                                                                   CurWebURL: '" + SPContext.Current.Web.Url + "', " +
                "                                                                   IsMultiSelect: " + LookupField.AllowMultipleValues.ToString().ToLower() + ", " +
                "                                                                   SearchText: '', " +
                "                                                                   CandidateIndex: '-1', " +
                "                                                                   AutoCompleteDivID : 'autoCompleteDiv_" + this.ClientID + "'}, " +
                "                                                    Parent: '" + LookupData.Parent + "', " +
                "                                                    ParentListField: '" + LookupData.ParentListField + "', " +
                "                                                    CachedValue: ''};" +
                "  var arrLength = _LookupFieldsPropsArray.length; " +
                "  _LookupFieldsPropsArray[arrLength] = lookupFieldProp_" + LookupData.Field + "; " +
                "} "
                , true);


            ScriptLink.Register(Page, "epmlive/ModifiedDropDown.js", false);

            object fv = null;
            string sfv = string.Empty;
            try
            {
                fv = ListItem[LookupField.InternalName];
            }
            catch { }

            if (fv != null)
            {
                sfv = fv.ToString();
            }

            if (LookupData != null && LookupData.Parent != "" && string.IsNullOrEmpty(sfv))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "_hideControls_",
                    "function HideControl_" + this.ClientID + "(){ " +
                    "   if ($('#" + TemplateContainer.ClientID + "_SelectCandidate').length > 0){ " +
                    "       $('#" + TemplateContainer.ClientID + "_SelectCandidate').prop('disabled', true); " +
                    "       $('#" + TemplateContainer.ClientID + "_AddButton').prop('disabled', true); " +
                    "       $('#" + TemplateContainer.ClientID + "_RemoveButton').prop('disabled', true); " +
                    "       $('#" + TemplateContainer.ClientID + "_SelectResult').prop('disabled', true); " +
                    "   } else { " +
                    "       setTimeout(HideControl_" + this.ClientID + ", 500); " +
                    "   } " +
                    "} " +

                    "$(document).ready(function () { " +
                        "HideControl_" + this.ClientID + "();" +
                    "});", true);
            }

            base.OnPreRender(e);

        }
    }
}
