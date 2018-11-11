using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using EPMLiveCore.API;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class ListDisplaySettingIterator : ListFieldIterator
    {
        private const string FeatureId1 = "e97da3cd-4c42-44cd-ba51-2bfbb2c397cb";
        private const string FeatureId2 = "19e6ae14-9e68-44fa-9a08-c1c4514bf12e";
        private const string ModeParam = "Mode";
        private const string LookupFieldParam = "LookupField";
        private const string LookupValueParam = "LookupValue";
        private const string SourceParam = "Source";
        private const string FormFieldType = "Microsoft.SharePoint.WebControls.FormField";
        private const string UserTitle = "User";
        private const string ProfileTitle = "Profile";
        private const string PermissionsTitle = "Permissions";
        private const string IsDialogParameter = "IsDlg";
        private const string GetLastIdParameter = "GetLastID";
        private const string DueName = "Due";
        private const string DaysOverdueName = "DaysOverdue";
        private const string ScheduleStatusName = "ScheduleStatus";
        private const string ResourceLevelTitle = "ResourceLevel";
        private const string CanLoginTitle = "CanLogin";
        private const string GenericTitle = "Generic";
        private const string TitleKey = "Title";
        private const string None = "none";
        private const string FirstNameKey = "FirstName";
        private const string LastNameKey = "LastName";
        private const string EmailKey = "Email";
        private const string New = "New";
        private const string Where = "where";
        private const string Me = "[Me]";
        private const string Separator = ";";
        private const string Edit = "Edit";
        private const string Always = "always";
        private const string Display = "Display";
        private const string SharePointAccount = "SharePointAccount";
        private const string Approved = "Approved";
        private const string No = "No";
        private const string Upload = "Upload";
        private const string Resources = "Resources";
        private const string Mode = "mode";
        private const string Listid = "ListId";
        private const string ForwardSlash = "/";
        private Dictionary<string, Dictionary<string, string>> fieldProperties = null;
        private SPList list = null;
        private SPControlMode mode = 0;
        private SortedList arrwpFields = new SortedList();
        private bool isResList = false;
        private bool isOnline = false;
        private string lookupField = string.Empty;
        private string lookupValue = string.Empty;

        #region ResourceList
        List<string> userPanelItems = new List<string>() { FirstNameKey, LastNameKey, EmailKey, GenericTitle, TitleKey, SharePointAccount };
        List<string> permissionPanelItems = new List<string>() { PermissionsTitle, ResourceLevelTitle, Approved, "TimesheetAdministrator", "Active", "Disable" };
        StringBuilder userPanelSb = new StringBuilder();
        HtmlTextWriter userPanel;
        StringBuilder profilePanelSb = new StringBuilder();
        HtmlTextWriter profilePanel;
        StringBuilder permissionPanelSb = new StringBuilder();
        HtmlTextWriter permissionPanel;
        #endregion

        private Dictionary<string, string> dControls = new Dictionary<string, string>();

        int max = 0;
        int count = 0;
        float width = 0;
        string barcolor = "";
        string ownerusername = "";
        string ownername = "";
        Guid accountid;
        bool isWorkList = true;
        int billingtype = 0;
        int userpanelRequiredCount = 0;
        int permissionPanelRequiredCount = 0;
        int profilepanelRequiredCount = 0;

        GenericEntityEditor picker;

        private bool isFeatureActivated = false;

        private bool DisplayFormRedirect = false;

        private bool bUseTeam = false;

        private int ActivationType = 0;
        private string WhiteSpaces10 = "          ";
        private string WhitSpaces6 = "      ";
        private string GenericType = "2";
        private string ModifiedType = "1";
        private string FalseConst;

        public ListDisplaySettingIterator()
        {
            FalseConst = "False";
        }

        private void FindSaveButtons(Control Parent, ref ArrayList Controls)
        {
            foreach (Control child in Parent.Controls)
            {
                if (child.GetType().ToString() == "Microsoft.SharePoint.WebControls.SaveButton")
                {
                    Controls.Add(child);
                }

                FindSaveButtons(child, ref Controls);
            }
        }

        protected void CustomHandler(object sender, EventArgs e)
        {
            if (SaveButton.SaveItem(SPContext.Current, this.list.BaseTemplate == SPListTemplateType.DocumentLibrary, ""))
            {
                string sUrl = (List.ParentWeb.ServerRelativeUrl == ForwardSlash) ? "" : List.ParentWeb.ServerRelativeUrl;

                RedirectUrl = String.Concat(sUrl, ForwardSlash, List.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url, @"?ID=", ListItem.ID, @"&Source=", ListItem.ParentList.DefaultViewUrl);

                ProcessNewItemRecent(ListItem);
            }
            else
            {
                //We cannot check validations prior to SaveButton.SaveItem event - Because validation setting is set on List level!
                //this means SaveItem is unsuccessful - Let's check for validation settings for New and Edit form mode
                //If item won't saved due to some other reason then that thing is already handled in respective ItemAdding/ItemUpdating event and throws proper exception on screen.
                //Here, we have handled this special case for List Validation Settings because this page is inherit from ListFieldIterator class.
                if (mode == SPControlMode.New || mode == SPControlMode.Edit)
                {
                    if (!string.IsNullOrEmpty(list.ValidationFormula))
                    {
                        HtmlGenericControl divValidationErrorMessage = new HtmlGenericControl("div");
                        divValidationErrorMessage.InnerHtml = "<span id='Error_WPQ2ClientFormPlaceholder' class='ms-formvalidation ms-csrformvalidation'>" + list.ValidationMessage + "</span>";
                        this.Controls.Add(divValidationErrorMessage);
                    }
                }
            }
        }

        protected void HandleNewItemRecent(object sender, EventArgs e)
        {
            if (SaveButton.SaveItem(SPContext.Current, this.list.BaseTemplate == SPListTemplateType.DocumentLibrary, ""))
            {
                ProcessNewItemRecent(SPContext.Current.ListItem);

            }
            else
            {
                //We cannot check validations prior to SaveButton.SaveItem event - Because validation setting is set on List level!
                //this means SaveItem is unsuccessful - Let's check for validation settings for New and Edit form mode
                //If item won't saved due to some other reason then that thing is already handled in respective ItemAdding/ItemUpdating event and throws proper exception on screen.
                //Here, we have handled this special case for List Validation Settings because this page is inherit from ListFieldIterator class.
                if (mode == SPControlMode.New || mode == SPControlMode.Edit)
                {
                    if (!string.IsNullOrEmpty(list.ValidationFormula))
                    {
                        HtmlGenericControl divValidationErrorMessage = new HtmlGenericControl("div");
                        divValidationErrorMessage.InnerHtml = "<span id='Error_WPQ2ClientFormPlaceholder' class='ms-formvalidation ms-csrformvalidation'>" + list.ValidationMessage + "</span>";
                        this.Controls.Add(divValidationErrorMessage);
                    }
                }
            }
        }

        protected void ProcessNewItemRecent(SPListItem i)
        {
            try
            {
                var queryCreateRecentItem =
                    @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @")
                    BEGIN
                        UPDATE FRF SET [F_Date] = GETDATE() 
                        WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @" 
                        SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @"
                    END
                    ELSE
                    BEGIN
                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Icon], [Title], [Type], [F_Date])
                        VALUES (@siteid, @webid, @listid, @itemid, @userid, @icon, @title, " + Convert.ToInt32(AnalyticsType.Recent) + @", GETDATE())
                        SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @"
                    END

                    IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 2) > 20)
                    BEGIN
	                    DELETE FROM FRF 
	                    WHERE [Type] = 2 
	                    AND [F_Date] NOT IN (SELECT TOP 20 [F_Date] FROM FRF WHERE [Type] = 2 ORDER BY [F_Date] DESC)
                    END
                    ";

                var qParams = new Dictionary<string, object>
                {
                    {"@siteid", i.ParentList.ParentWeb.Site.ID},
                    {"@webid", i.ParentList.ParentWeb.ID},
                    {"@listid", i.ParentList.ID},
                    {"@itemid", i.ID},
                    {"@userid", i.ParentList.ParentWeb.CurrentUser.ID},
                    {"@icon", new GridGanttSettings(i.ParentList).ListIcon},
                    {"@title", i.ParentList.Title.Contains("Template Gallery") ? new SPFieldUrlValue(i["URL"].ToString()).Description : i.Title},
                };

                var exec = new QueryExecutor(SPContext.Current.Web);
                exec.ExecuteEpmLiveQuery(queryCreateRecentItem, qParams);
                ClearCache();
            }
            catch { }
        }

        private static void ClearCache()
        {
            try
            {
                try
                {
                    new RecentItemsLinkProvider(SPContext.Current.Site.ID, SPContext.Current.Web.ID, SPContext.Current.Web.CurrentUser.LoginName).ClearCache();
                }
                catch
                {
                    CacheStore.Current.RemoveCategory(new CacheStoreCategory().Navigation);
                }
            }
            catch { }
        }

        #region resourcepool methods

        private void AddControlsToWriter(Control control, HtmlTextWriter writer, string internalName = "")
        {
            if (isResList)
            {
                if (userPanelItems.Contains(internalName))
                {
                    control.RenderControl(userPanel);
                }
                else if (permissionPanelItems.Contains(internalName))
                {
                    control.RenderControl(permissionPanel);
                }
                else
                {
                    control.RenderControl(profilePanel);
                }
            }
            else
            {
                control.RenderControl(writer);
            }

        }

        private string CreateHtmlPanelText(string panelTitle)
        {
            return "<tr><td colspan=\"2\"><div class=\"upcontainer\"><div class=\"upheader\"><img src=\"/_layouts/15/epmlive/images/navigation/collapse.png\" class=\"image_margin imgDownArrow\" alt=\"downArrow\" /><img src=\"/_layouts/15/epmlive/images/navigation/expand.png\" class=\"image_margin imgArrow\" alt=\"arrow\" /><span>" + panelTitle + "</span></div><div class=\"upcontent\"><table>";
        }

        #endregion

        protected override void CreateChildControls()
        {

            if (isFeatureActivated)
            {
                try
                {
                    for (int i = 0; i < Fields.Count; i++)
                    {
                        SPField field = Fields[i];
                        if (arrwpFields.Contains(field.InternalName) && mode == SPControlMode.Edit)
                        {
                            if ((bool)arrwpFields[field.InternalName])
                            {
                                TemplateContainer child = new TemplateContainer();
                                Controls.Add(child);

                                SetFieldName(child, field.InternalName);
                                SetControlMode(child, mode);

                                ControlTemplate.InstantiateIn(child);
                            }
                        }
                        else if (!IsFieldExcluded(field))
                        {

                            string editable = "";
                            try
                            {
                                editable = fieldProperties[field.InternalName]["Editable"];
                                editable = editable.Split(Separator.ToCharArray())[0].ToLower();
                            }
                            catch { }

                            if ((editable == "never" || editable == Where || field.Type == SPFieldType.Calculated) && mode != SPControlMode.New)
                            {
                                if (editable == Where && EditableFieldDisplay.canEdit(field, fieldProperties, this.ListItem))
                                {
                                    TemplateContainer child = new TemplateContainer();
                                    Controls.Add(child);

                                    SetFieldName(child, field.InternalName);
                                    SetControlMode(child, mode);

                                    ControlTemplate.InstantiateIn(child);
                                }
                                else
                                {
                                    TemplateContainer child = new TemplateContainer();
                                    Controls.Add(child);

                                    SetFieldName(child, field.InternalName);
                                    SetControlMode(child, SPControlMode.Display);

                                    ControlTemplate.InstantiateIn(child);
                                }
                            }
                            else
                            {
                                TemplateContainer child = new TemplateContainer();
                                Controls.Add(child);

                                SetFieldName(child, field.InternalName);
                                SetControlMode(child, mode);



                                ControlTemplate.InstantiateIn(child);
                            }
                        }
                    }
                }
                catch { }
                // prepopulate lookup fields with query string values

                InsertLookupValueByQueryString();

                // Add EPMLive custom entity picker control to 
                // lookup fields
                if (Fields != null)
                {
                    foreach (SPField f in Fields)
                    {
                        AddTypeAheadFieldControls(f);
                    }
                }
                //AddEntityPickersToLookups();
            }
            else
                base.CreateChildControls();

        }

        private void InsertLookupValueByQueryString()
        {
            if (mode == SPControlMode.New || (this.list.BaseTemplate == SPListTemplateType.DocumentLibrary && !string.IsNullOrEmpty(Page.Request[ModeParam]) && Page.Request[ModeParam] == Upload && mode == SPControlMode.Edit))
            {
                // assume single lookup
                bool valIsMulti = false;
                List<int> ids = new List<int>();
                if (!string.IsNullOrEmpty(this.lookupValue))
                {
                    valIsMulti = (this.lookupValue.IndexOf(',') != -1);
                    if (valIsMulti)
                    {
                        string[] sIds = this.lookupValue.Split(',');
                        foreach (string s in sIds)
                        {
                            if (!string.IsNullOrEmpty(s.Trim()))
                            {
                                ids.Add(int.Parse(s));
                            }
                        }
                    }
                }

                List<FormField> formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
                List<FormField> modCandidates = new List<FormField>();
                foreach (FormField fld in formFields)
                {
                    if (!string.IsNullOrEmpty(lookupField) && fld.Field.InternalName.Equals(lookupField))
                    {
                        modCandidates.Add(fld);
                    }
                }

                for (int index = 0; index < modCandidates.Count; index++)
                {
                    SPField spFld = modCandidates[index].Field;
                    SPFieldLookup lookupFld = modCandidates[index].Field as SPFieldLookup;
                    bool isMulti = lookupFld.AllowMultipleValues;

                    // insert single value to single lookup field
                    if (!isMulti && !valIsMulti)
                    {
                        int itemID = int.Parse(lookupValue.Trim());
                        SPFieldLookupValue lookupVal = new SPFieldLookupValue(itemID, GetLookupItemValue(lookupFld, itemID));
                        this.ListItem[spFld.Id] = lookupVal;
                    }
                    // insert multi lookup value to multi lookup field
                    else if (isMulti && valIsMulti)
                    {
                        SPFieldLookupValueCollection lookupValCol = new SPFieldLookupValueCollection();
                        foreach (int itemID in ids)
                        {
                            SPFieldLookupValue lookupVal = new SPFieldLookupValue(itemID, GetLookupItemValue(lookupFld, itemID));
                            lookupValCol.Add(lookupVal);
                        }
                        this.ListItem[spFld.Id] = lookupValCol;
                    }
                }
            }
        }

        private string GetLookupItemValue(SPFieldLookup lookupFld, int lookupItemID)
        {
            string result = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(lookupFld.LookupWebId))
                    {
                        SPList targetList = ew.Lists[new Guid(lookupFld.LookupList)];
                        SPListItem targetItem = targetList.GetItemById(lookupItemID);
                        result = targetItem[targetList.Fields.GetFieldByInternalName(lookupFld.LookupField).Id].ToString();
                    }
                }
            });

            return result;
        }

        private SPFieldLookupValueCollection GetQueryStringLookupVal(FormField currentFld)
        {
            if (string.IsNullOrEmpty(lookupField) || !currentFld.Field.InternalName.Equals(lookupField))
            {
                return null;
            }

            SPFieldLookupValueCollection result = new SPFieldLookupValueCollection();
            // assume single lookup
            bool valIsMulti = false;
            List<int> ids = new List<int>();
            if (!string.IsNullOrEmpty(this.lookupValue))
            {
                valIsMulti = this.lookupValue.Contains(',');
                if (valIsMulti)
                {
                    string[] sIds = this.lookupValue.Split(',');
                    foreach (string s in sIds)
                    {
                        if (!string.IsNullOrEmpty(s.Trim()))
                        {
                            ids.Add(int.Parse(s));
                        }
                    }
                }
            }

            //List<FormField> formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
            List<FormField> modCandidates = new List<FormField>() { currentFld };

            for (int index = 0; index < modCandidates.Count; index++)
            {
                SPField spFld = modCandidates[index].Field;
                SPFieldLookup lookupFld = modCandidates[index].Field as SPFieldLookup;
                bool isMulti = lookupFld.AllowMultipleValues;

                // insert single value to single lookup field
                if (!isMulti && !valIsMulti)
                {
                    int itemId;
                    if (int.TryParse(lookupValue.Trim(), out itemId))
                    {
                        result.Add(new SPFieldLookupValue(itemId, GetLookupItemValue(lookupFld, itemId)));
                    }
                }
                // insert multi lookup value to multi lookup field
                else if (isMulti && valIsMulti)
                {
                    foreach (int id in ids)
                    {
                        result.Add(new SPFieldLookupValue(id, GetLookupItemValue(lookupFld, id)));
                    }
                }
            }

            return result;
        }


        private SPFieldLookupValueCollection GetQueryStringLookupVal(SPField fld)
        {
            if (string.IsNullOrEmpty(lookupField) || !fld.InternalName.Equals(lookupField))
            {
                return null;
            }

            SPFieldLookupValueCollection result = new SPFieldLookupValueCollection();
            // assume single lookup
            bool valIsMulti = false;
            List<int> ids = new List<int>();
            if (!string.IsNullOrEmpty(this.lookupValue))
            {
                valIsMulti = this.lookupValue.Contains(',');
                if (valIsMulti)
                {
                    string[] sIds = this.lookupValue.Split(',');
                    foreach (string s in sIds)
                    {
                        if (!string.IsNullOrEmpty(s.Trim()))
                        {
                            ids.Add(int.Parse(s));
                        }
                    }
                }
            }

            SPFieldLookup lookupFld = fld as SPFieldLookup;
            bool isMulti = lookupFld.AllowMultipleValues;

            // insert single value to single lookup field
            if (!isMulti && !valIsMulti)
            {
                int itemId;
                if (int.TryParse(lookupValue.Trim(), out itemId))
                {
                    result.Add(new SPFieldLookupValue(itemId, GetLookupItemValue(lookupFld, itemId)));
                }
            }
            // insert multi lookup value to multi lookup field
            else if (isMulti && valIsMulti)
            {
                foreach (int id in ids)
                {
                    result.Add(new SPFieldLookupValue(id, GetLookupItemValue(lookupFld, id)));
                }
            }
            return result;
        }

        private void AddTypeAheadFieldControls(SPField fld)
        {
            if (mode == SPControlMode.New || mode == SPControlMode.Edit)
            {
                // this represents a comma separated list of lookup field internal names to modify
                EnhancedLookupConfigValuesHelper valueHelper = null;
                string unprocessedModCandidates = string.Empty;
                GridGanttSettings gSettings = new GridGanttSettings(this.list);

                try
                {
                    string rawValue = gSettings.Lookups;
                    //string rawValue = "Region^dropdown^none^none^xxx|State^autocomplete^Region^Region^xxx|City^autocomplete^State^State^xxx";                    
                    valueHelper = new EnhancedLookupConfigValuesHelper(rawValue);
                }
                catch { }

                if (valueHelper == null)
                {
                    return;
                }


                bool isEnhanced = valueHelper.ContainsKey(fld.InternalName);
                bool isParent = valueHelper.IsParentField(fld.InternalName);

                if (!isEnhanced && !isParent)
                {
                    return;
                }

                LookupConfigData lookupData = valueHelper.GetFieldData(fld.InternalName);

                if (isParent && !isEnhanced)
                {
                    SPFieldLookup lookupFld = fld as SPFieldLookup;
                    if (!lookupFld.AllowMultipleValues)
                    {
                        CascadingLookupRenderControl ctrl = new CascadingLookupRenderControl();
                        if (lookupData == null)
                        {
                            lookupData = new LookupConfigData();
                            lookupData.IsParent = true;
                        }
                        ctrl.LookupData = lookupData;
                        ctrl.LookupField = lookupFld;

                        string customValue =
                        "<Data>" +
                        "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                        "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                        "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                        "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                        "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                        "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                        "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                        "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                        "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                        "<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
                        GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                        "</Data>";

                        ctrl.CustomProperty = customValue;
                        FormField ff = this.GetFormFieldByField(fld);
                        if (ff != null)
                        {
                            ff.Parent.Controls.AddAfter(ff, ctrl);
                        }
                    }
                }
                else if (isParent && isEnhanced)
                {
                    if (lookupData.Type == GenericType)
                    {
                        #region INSERT EPMLIVE GENERIC PICKER CONTROL

                        picker = new GenericEntityEditor();
                        SPFieldLookup lookupFld = fld as SPFieldLookup;
                        picker.MultiSelect = lookupFld.AllowMultipleValues;

                        string customValue =
                            "<Data>" +
                            "<Param key=\"SPFieldType\"></Param>" +
                            "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                            "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                            "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                            "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                            "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                            "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                            "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                            "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                            GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                            "<Param key=\"Field\">" + lookupData.Field + "</Param>" +
                            "<Param key=\"ControlType\">" + lookupData.Type + "</Param>" +
                            "<Param key=\"Parent\">" + lookupData.Parent + "</Param>" +
                            "<Param key=\"ParentListField\">" + lookupData.ParentListField + "</Param>" +
                            "<Param key=\"Required\">" + lookupFld.Required.ToString() + "</Param>" +
                            "</Data>";

                        SPFieldLookupValueCollection lookupValCol = null;

                        if (mode == SPControlMode.New || (this.list.BaseTemplate == SPListTemplateType.DocumentLibrary && !string.IsNullOrEmpty(Page.Request[ModeParam]) && Page.Request[ModeParam] == Upload && mode == SPControlMode.Edit))
                        {
                            lookupValCol = GetQueryStringLookupVal(fld);
                        }
                        else
                        {
                            try
                            {
                                lookupValCol = new SPFieldLookupValueCollection(this.ListItem[lookupFld.Id].ToString());
                            }
                            catch { }
                        }

                        if (lookupValCol != null && lookupValCol.Count > 0)
                        {
                            ArrayList alItems = new ArrayList();
                            PickerEntity entity;
                            foreach (SPFieldLookupValue v in lookupValCol)
                            {
                                entity = new PickerEntity();
                                entity.Key = v.LookupId.ToString();
                                entity.DisplayText = v.LookupValue;
                                entity.IsResolved = true;
                                alItems.Add(entity);
                            }
                            picker.UpdateEntities(alItems);
                        }

                        picker.CustomProperty = customValue;

                        FormField ff = this.GetFormFieldByField(fld);
                        if (ff != null)
                        {
                            ff.Parent.Controls.AddAfter(ff, picker);
                        }

                        #endregion
                    }
                    else if (lookupData.Type == ModifiedType)
                    {
                        #region INSERT MODIFIED SP CONTROL

                        SPFieldLookup lookupFld = fld as SPFieldLookup;
                        if (!lookupFld.AllowMultipleValues)
                        {
                            CascadingLookupRenderControl cclrCtrl = new CascadingLookupRenderControl();
                            cclrCtrl.LookupData = lookupData;
                            cclrCtrl.LookupField = lookupFld;

                            string customValue =
                            "<Data>" +
                            "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                            "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                            "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                            "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                            "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                            "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                            "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                            "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                            "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                            "<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
                            GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                            "</Data>";

                            cclrCtrl.CustomProperty = customValue;

                            FormField ff = this.GetFormFieldByField(fld);
                            if (ff != null)
                            {
                                ff.Parent.Controls.AddAfter(ff, cclrCtrl);
                            }
                        }

                        #endregion
                    }
                }
                else if (!isParent && isEnhanced)
                {
                    if (lookupData.Type == GenericType)
                    {
                        #region INSERT EPMLIVE GENERIC PICKER CONTROL

                        picker = new GenericEntityEditor();
                        SPFieldLookup lookupFld = fld as SPFieldLookup;
                        picker.MultiSelect = lookupFld.AllowMultipleValues;

                        string customValue =
                            "<Data>" +
                            "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                            "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                            "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                            "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                            "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                            "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                            "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                            "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                            "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                            GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                            "<Param key=\"Field\">" + lookupData.Field + "</Param>" +
                            "<Param key=\"ControlType\">" + lookupData.Type + "</Param>" +
                            "<Param key=\"Parent\">" + lookupData.Parent + "</Param>" +
                            "<Param key=\"ParentListField\">" + lookupData.ParentListField + "</Param>" +
                            "<Param key=\"Required\">" + lookupFld.Required.ToString() + "</Param>" +
                            "</Data>";

                        SPFieldLookupValueCollection lookupValCol = null;

                        if (mode == SPControlMode.New || (this.list.BaseTemplate == SPListTemplateType.DocumentLibrary && !string.IsNullOrEmpty(Page.Request[ModeParam]) && Page.Request[ModeParam] == Upload && mode == SPControlMode.Edit))
                        {
                            lookupValCol = GetQueryStringLookupVal(fld);
                        }
                        else
                        {
                            try
                            {
                                lookupValCol = new SPFieldLookupValueCollection(this.ListItem[lookupFld.Id].ToString());
                            }
                            catch { }
                        }

                        if (lookupValCol != null && lookupValCol.Count > 0)
                        {
                            ArrayList alItems = new ArrayList();
                            PickerEntity entity;
                            foreach (SPFieldLookupValue v in lookupValCol)
                            {
                                entity = new PickerEntity();
                                entity.Key = v.LookupId.ToString();
                                entity.DisplayText = v.LookupValue;
                                entity.IsResolved = true;
                                alItems.Add(entity);
                            }
                            picker.UpdateEntities(alItems);
                        }

                        picker.CustomProperty = customValue;

                        FormField ff = this.GetFormFieldByField(fld);
                        if (ff != null)
                        {
                            ff.Parent.Controls.AddAfter(ff, picker);
                        }


                        #endregion
                    }
                    else if (lookupData.Type == ModifiedType)
                    {
                        #region INSERT MODIFIED SP CONTROL

                        SPFieldLookup lookupFld = fld as SPFieldLookup;
                        if (!lookupFld.AllowMultipleValues)
                        {
                            CascadingLookupRenderControl cclrCtrl = new CascadingLookupRenderControl();
                            cclrCtrl.LookupData = lookupData;
                            cclrCtrl.LookupField = lookupFld;

                            string customValue =
                            "<Data>" +
                            "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                            "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                            "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                            "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                            "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                            "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                            "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                            "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                            "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                            "<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
                            GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                            "</Data>";

                            cclrCtrl.CustomProperty = customValue;

                            FormField ff = this.GetFormFieldByField(fld);
                            if (ff != null)
                            {
                                ff.Parent.Controls.AddAfter(ff, cclrCtrl);
                            }
                        }
                        else
                        {
                            CascadingMultiLookupRenderControl cclrCtrl = new CascadingMultiLookupRenderControl();
                            cclrCtrl.LookupData = lookupData;
                            cclrCtrl.LookupField = lookupFld;

                            string customValue =
                            "<Data>" +
                            "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                            "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                            "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                            "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                            "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                            "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                            "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                            "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                            "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                            "<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
                            GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                            "</Data>";

                            cclrCtrl.CustomProperty = customValue;

                            FormField ff = this.GetFormFieldByField(fld);
                            if (ff != null)
                            {
                                ff.Parent.Controls.AddAfter(ff, cclrCtrl);
                            }
                        }

                        #endregion
                    }
                }
            }
        }

        private static Control GetControl(FieldMetadata formField)
        {
            return formField.FindControlRecursive(x => x.GetType() == GetChildControlBasedOnFieldType(formField.Field.FieldRenderingControl));
        }

        private static Type GetChildControlBasedOnFieldType(object field)
        {
            if (field.GetType().Equals(typeof(MultipleLookupField)))
            {
                return typeof(MultipleLookupField);
            }

            if (field.GetType().Equals(typeof(LookupField)))
            {
                return typeof(LookupField);
            }

            return null;
        }

        private static void SetFieldName(TemplateContainer child, string fieldName)
        {
            try
            {
                PropertyInfo property = child.GetType().GetProperty("FieldName", BindingFlags.NonPublic | BindingFlags.Instance);
                property.SetValue(child, fieldName, null);
            }
            catch (Exception) { }
        }

        private static void SetControlMode(TemplateContainer child, SPControlMode controlMode)
        {
            try
            {
                PropertyInfo property = child.GetType().GetProperty("ControlMode", BindingFlags.NonPublic | BindingFlags.Instance);
                property.SetValue(child, controlMode, null);
            }
            catch (Exception) { }
        }

        private static FieldLabel GetFieldLabel(Control control, int index1, int index2, int index3)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return (FieldLabel)control.Controls[index1].Controls[index2].Controls[index3];
        }

        private static FormField GetFormField(Control control, int index)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return (FormField)control.Controls[index];
        }

        private static FieldLabel GetFieldLabel(Control control, int index)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return (FieldLabel)control.Controls[index];
        }

        private static CompositeField GetCompositeField(Control control, int index)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return (CompositeField)control.Controls[index];
        }

        private static string GetControlType(Control control, int index)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return control.Controls[index].GetType().ToString();
        }
    }
}