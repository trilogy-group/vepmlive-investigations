using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public class WEPeopleEditor : Microsoft.SharePoint.WebControls.PeopleEditor
    {
        /// <summary>
        /// Overrides the OnLoad event and ads the logic to set which SelectionSets are allowed for the instance
        /// of the PeopleEditor.
        /// </summary>
        /// <param name="e"></param>
        /// 

        bool isWEEditor = false;

        private const string PEOPLE_EDITOR_AJAX_HANDLER_PAGE = "/_layouts/epmlive/WEPeopleEditorAjaxHandler.aspx";

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (SPWeb wweb = site.OpenWeb(SPContext.Current.Web.ID))
                        {
                            bool.TryParse(CoreFunctions.getLockConfigSetting(wweb, "EPMLiveUseWEPeoplePicker", false), out isWEEditor);
                        }
                    }
                });

                if (isWEEditor)
                    PickerDialogType = typeof(WEPickerDialog);

            }
            catch { }
        }

        public override Microsoft.SharePoint.WebControls.PickerEntity ValidateEntity(Microsoft.SharePoint.WebControls.PickerEntity entity)
        {
            try
            {
                if (isWEEditor)
                {
                    if(SPContext.Current.List == null || SPContext.Current.List.Title != "Resources")
                    {
                        this.ValidateResolvedEntity = false;
                        entity = base.ValidateEntity(entity);
                        
                        XmlDocument docTeam = new XmlDocument();
                        docTeam.LoadXml(WorkEngineAPI.GetTeam("<Filter Column='SharePointAccount' Value='" + entity.DisplayText + "'/>", SPContext.Current.Web));
                        if (docTeam.FirstChild.SelectSingleNode("//Team/Member") == null)
                            entity.IsResolved = false;
                        else
                        {
                            if (entity.EntityData["PrincipalType"].ToString().ToLower() == "sharepointgroup")
                            {
                                if (docTeam.FirstChild.SelectSingleNode("//Team/Member").Attributes["SharePointAccount"].Value.ToLower() != entity.EntityData["AccountName"].ToString().ToLower())
                                {
                                    entity.IsResolved = false;
                                }
                                else
                                {
                                    entity.IsResolved = true;
                                }
                            }
                            else
                            {
                                if (docTeam.FirstChild.SelectSingleNode("//Team/Member").Attributes["Username"].Value.ToLower() != entity.EntityData["AccountName"].ToString().ToLower())
                                {
                                    entity.IsResolved = false;
                                }
                            }
                        }
                    }
                    else
                        entity = base.ValidateEntity(entity);
                }
                else
                {
                    entity = base.ValidateEntity(entity);
                }
            }
            catch { }
            return entity;
        }


        //protected override void OnPreRender(EventArgs e)
        //{
        //    if (isWEEditor)
        //    {
        //        //ScriptLink.Register(Page, "/_layouts/epmlive/jQueryLibrary/jquery-1.6.2.min.js", false);
        //        ScriptLink.Register(Page, "/_layouts/epmlive/WEPeopleEditorAutoComplete.js", false);
        //        // we are sharing style sheets between this control and GenericEntityPicker
        //        this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "_WEPeopleEditorStyle_", "<link href=\"/_layouts/epmlive/GenericEntityPickerStyle.css\" rel=\"stylesheet\" type=\"text/css\" />", false);

        //        if (!Page.ClientScript.IsClientScriptBlockRegistered("_WEPeopleEditorGlobalVariables_"))
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(GetType(), "_WEPeopleEditorGlobalVariables_", "<script>var curWebURL = '" + SPContext.Current.Web.Url + "';</script>", false);
        //        }

        //        if (!Page.ClientScript.IsClientScriptBlockRegistered("_WEPeopleEditorGlobalObject_"))
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(GetType(), "_WEPeopleEditorGlobalObject_", "<script>var _wePeopleEditorControlPropertyArray = new Array();</script>", false);
        //        }

        //        if (!Page.ClientScript.IsClientScriptBlockRegistered("_WEPeopleEditorGlobalDataCache_"))
        //        {
        //            Page.ClientScript.RegisterClientScriptBlock(GetType(), "_WEPeopleEditorGlobalDataCache_", "<script>var _wePeopleEditorControlGlobalDataCache = new Array();</script>", false);
        //        }

        //        if (!Page.ClientScript.IsClientScriptBlockRegistered("_WEPeopleEditorControlProperties_" + this.ClientID))
        //        {
        //            this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "_WEPeopleEditorControlProperties_" + this.ClientID,
        //                "<script>" +
        //                "if (_wePeopleEditorControlPropertyArray) { " +
        //                "   var controlProps_" + this.ClientID + " = { wePeopleEditorDivIDRoot : '" + this.ClientID + "'," +
        //                "                                              wePeopleEditorDivID : '" + this.ClientID + "_upLevelDiv'," +
        //                "                                              wePeopleEdtiorCheckNameID : '" + this.ClientID + "_checkNames'," +
        //                "                                              ajaxHandlerPage : '" + PEOPLE_EDITOR_AJAX_HANDLER_PAGE + "', " +
        //                "                                              curWebURL : '" + SPContext.Current.Web.Url + "'," +
        //                "                                              isMultiSelect : " + this.MultiSelect.ToString().ToLower() + "," +
        //                "                                              searchText : '', " +
        //                "                                              singleSelectLookupVal : '', " +
        //                "                                              candidateIndex : '-1', " +
        //                "                                              autoCompleteDivID : 'autoCompleteDiv_" + this.ClientID + "', " +
        //                "                                              checkNamesOnClick : '', " +
        //                "                                              browseOnClick : '' }; " +
        //                "  var arrLength = _wePeopleEditorControlPropertyArray.length; " +
        //                "  _wePeopleEditorControlPropertyArray[arrLength] = controlProps_" + this.ClientID + "; " +
        //                "  }</script>", false);
        //        }
        //    }
        //    base.OnPreRender(e);
        //}

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

        }
    }
}
