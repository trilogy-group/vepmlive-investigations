using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using EPMLiveCore.API;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Linq;
using System.Globalization;
using System.Xml;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.IO;

namespace EPMLiveCore
{
    public class ListDisplaySettingIterator : ListFieldIterator
    {
        private const string FeatureId1 = "e97da3cd-4c42-44cd-ba51-2bfbb2c397cb";
        private const string FeatureId2 = "19e6ae14-9e68-44fa-9a08-c1c4514bf12e";
        private const string ModeParam = "Mode";
        private const string LookupFieldParam = "LookupField";
        private const string LookupValueParam = "LookupValue";
        private const string SourceParam = "Source";
        private const string UserTitle = "User";
        private const string ProfileTitle = "Profile";
        private const string PermissionsTitle = "Permissions";
        private const string IsDialogParameter = "IsDlg";
        private const string ResourceLevelTitle = "ResourceLevel";
        private const string CanLoginTitle = "CanLogin";
        private const string GenericTitle = "Generic";
        private const string TitleKey = "Title";
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

        GenericEntityEditor picker;

        private bool isFeatureActivated = false;

        private bool DisplayFormRedirect = false;

        private int ActivationType = 0;

        private string GenericType = "2";
        private string ModifiedType = "1";
        private string FalseConst;
        private ListDisplaySettingIteratorRenderHelpers _renderHelpers;

        public ListDisplaySettingIterator()
        {
            FalseConst = "False";
            _renderHelpers = new ListDisplaySettingIteratorRenderHelpers();
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
                ListDisplaySettingIteratorHelpers.ClearCache();
            }
            catch { }
        }

        protected override void OnInit(EventArgs e)
        {
            var siteid = SPContext.Current.Site.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var site = new SPSite(siteid))
                {
                    if (site.Features[new Guid(FeatureId1)] != null ||
                        site.WebApplication.Features[new Guid(FeatureId2)] != null)
                    {
                        isFeatureActivated = true;
                    }
                }
            });

            base.OnInit(e);

            if (isFeatureActivated)
            {
                OnInit();

                if (mode == SPControlMode.New ||
                    (list.BaseTemplate == SPListTemplateType.DocumentLibrary && !string.IsNullOrWhiteSpace(Page.Request[ModeParam]) &&
                    Page.Request[ModeParam] == Upload && mode == SPControlMode.Edit))
                {
                    if (!string.IsNullOrWhiteSpace(Page.Request[LookupFieldParam]))
                    {
                        lookupField = Page.Request[LookupFieldParam];
                    }

                    if (!string.IsNullOrWhiteSpace(Page.Request[LookupValueParam]))
                    {
                        lookupValue = Page.Request[LookupValueParam];
                    }
                }
            }
        }

        private void OnInit()
        {
            try
            {
                InitFields();

                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (var rsite = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (var web = rsite.OpenWeb(SPContext.Current.Web.ID))
                        {
                            arrwpFields = ReflectionMethods.GetWorkPlannerStatusFields(web, list.Title);
                        }
                    }
                    try
                    {
                        if (list.Title == Resources)
                        {
                            isResList = true;
                            var site1 = SPContext.Current.Site;
                            if (site1.WebApplication.Features[new Guid(FeatureId2)] != null)
                            {
                                InitFeature2();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }
                });


                if (SPContext.Current.FormContext.FormMode != SPControlMode.Invalid)
                {
                    mode = SPContext.Current.FormContext.FormMode;
                }
                else
                {
                    try
                    {
                        mode = (SPControlMode)int.Parse(Page.Request[Mode]);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private void InitFields()
        {
            try
            {
                list = SPContext.Current.List;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            var gridSettings = new GridGanttSettings(list);

            DisplayFormRedirect = gridSettings.DisplayFormRedirect;

            if (DisplayFormRedirect && ControlMode == SPControlMode.New && Page.Request[IsDialogParameter] != ModifiedType)
            {
                SPContext.Current.FormContext.OnSaveHandler += CustomHandler;
            }
            else if (!string.IsNullOrWhiteSpace(Page.Request[SourceParam]))
            {
                RedirectUrl = Page.Request[SourceParam];
                SPContext.Current.FormContext.OnSaveHandler += HandleNewItemRecent;
            }
            else
            {
                SPContext.Current.FormContext.OnSaveHandler += HandleNewItemRecent;
            }

            if (gridSettings.DisplaySettings != string.Empty)
            {
                fieldProperties = ListDisplayUtils.ConvertFromString(gridSettings.DisplaySettings);
            }

            try
            {
                isWorkList = gridSettings.EnableWorkList;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            if (isWorkList)
            {
                SPPageContentManager.RegisterClientScriptInclude(
                    this,
                    GetType(),
                    "WorkEngineStatusing",
                    "/_layouts/15/epmlive/WorkEngineStatusing.js");
            }


            if (list == null)
            {
                list = SPContext.Current.Web.Lists[new Guid(Page.Request[Listid])];
            }
        }

        private void InitFeature2()
        {
            isOnline = true;

            try
            {
                SqlConnection connection = null;
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    var assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                    var thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.Settings", true, true);
                    var methodInfo = thisClass.GetMethod("getConnectionString");
                    var connectionString = (string)methodInfo.Invoke(null, new object[] { });

                    connection = new SqlConnection(connectionString);
                    connection.Open();
                });

                using (var command = new SqlCommand("2012SP_GetActivationInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                    command.Parameters.AddWithValue("@username", string.Empty);

                    using (var dataSet = new DataSet())
                    {
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet);
                        }

                        try
                        {
                            ActivationType = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                        }
                    }

                    if (ActivationType != 3)
                    {
                        InitActivationType(connection);
                    }
                    else
                    {
                        InitOwner(connection);
                    }
                }
                connection?.Dispose();
            }
            catch (Exception ex)
            {
                max = 0;
                Trace.WriteLine(ex.ToString());
            }
        }

        private void InitActivationType(SqlConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            using (var command = new SqlCommand("2010SP_GetSiteAccountNums", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                command.Parameters.AddWithValue("@contractLevel", CoreFunctions.getContractLevel());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        max = reader.GetInt32(0);
                        count = reader.GetInt32(1);
                        width = (count * 100) / max;

                        barcolor = string.Empty; ;

                        if (width > 100)
                        {
                            width = 100;
                        }

                        if ((max - count) <= 1)
                        {
                            barcolor = "FF0000";
                        }
                        else if ((max - count) < 5)
                        {
                            barcolor = "FFFF00";
                        }
                        else
                        {
                            barcolor = "009900";
                        }

                        ownerusername = reader.GetString(13);
                        ownername = reader.GetString(5);

                        accountid = reader.GetGuid(2);

                        billingtype = reader.GetInt32(11);
                    }
                }
            }
        }

        private void InitOwner(SqlConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            using (var command = new SqlCommand("2010SP_GetSiteAccountNums", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                command.Parameters.AddWithValue("@contractLevel", CoreFunctions.getContractLevel());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ownerusername = reader.GetString(13);
                        ownername = reader.GetString(5);
                    }
                }
            }
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            var relativeUrl = Web.ServerRelativeUrl == ForwardSlash ? string.Empty : Web.ServerRelativeUrl;

            if (isResList)
            {
                writer.WriteLine(" <script>$(document).ready(function () {$(\".imgArrow\").addClass(\"hideImage\"); $(\".upheader\").click(function () {$header = $(this);$arrowImage = $header.find(\".imgArrow\");$downArrowImage = $header.find(\".imgDownArrow\");$content = $header.next();");
                writer.Write("$content.slideToggle(100,function (){  if ($arrowImage.hasClass(\"hideImage\")) {$downArrowImage.addClass(\"hideImage\");$arrowImage.removeClass(\"hideImage\");$(\"#onetIDListForm\").attr(\"style\",\"width:95%\");}else {$arrowImage.addClass(\"hideImage\");$downArrowImage.removeClass(\"hideImage\");}});});});</script>");

                userPanel = new HtmlTextWriter(new StringWriter(userPanelSb, CultureInfo.InvariantCulture));
                userPanel.Write(CreateHtmlPanelText(UserTitle));

                profilePanel = new HtmlTextWriter(new StringWriter(profilePanelSb, CultureInfo.InvariantCulture));
                profilePanel.Write(CreateHtmlPanelText(ProfileTitle));

                if (CoreFunctions.DoesCurrentUserHaveFullControl(Web))
                {
                    permissionPanel = new HtmlTextWriter(new StringWriter(permissionPanelSb, CultureInfo.InvariantCulture));
                    permissionPanel.Write(CreateHtmlPanelText(PermissionsTitle));
                }
            }

            if (isFeatureActivated)
            {
                _renderHelpers.Init(CreateRenderParameters());
                _renderHelpers.RenderControl(writer, relativeUrl);
            }
            else
            {
                base.RenderControl(writer);
            }
        }

        private RenderParameters CreateRenderParameters()
        {
            return new RenderParameters
            {
                activationType = ActivationType,
                isOnline = isOnline,
                isResList = isResList,
                isWorkList = isWorkList,
                ownerUsername = ownerusername,
                ownerName = ownername,
                max = max,
                count = count,
                listId = ListId,
                itemId = ItemId,
                controls = Controls,
                accountId = accountid,
                billingType = billingtype,
                arrwpFields = arrwpFields,
                Web = Web,
                List = List,
                ControlMode = ControlMode,
                Page = Page,
                list = list,
                ListItem = ListItem,
                BaseListItem = base.ListItem,
                userPanel = userPanel,
                userPanelSb = userPanelSb,
                permissionPanel = permissionPanel,
                permissionPanelSb = permissionPanelSb,
                profilePanel = profilePanel,
                profilePanelSb = profilePanelSb,
                Controls = Controls,
                dControls = dControls
            };
        }

        #region resourcepool methods


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

                                ListDisplaySettingIteratorHelpers.SetFieldName(child, field.InternalName);
                                ListDisplaySettingIteratorHelpers.SetControlMode(child, mode);

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

                                    ListDisplaySettingIteratorHelpers.SetFieldName(child, field.InternalName);
                                    ListDisplaySettingIteratorHelpers.SetControlMode(child, mode);

                                    ControlTemplate.InstantiateIn(child);
                                }
                                else
                                {
                                    TemplateContainer child = new TemplateContainer();
                                    Controls.Add(child);

                                    ListDisplaySettingIteratorHelpers.SetFieldName(child, field.InternalName);
                                    ListDisplaySettingIteratorHelpers.SetControlMode(child, SPControlMode.Display);

                                    ControlTemplate.InstantiateIn(child);
                                }
                            }
                            else
                            {
                                TemplateContainer child = new TemplateContainer();
                                Controls.Add(child);

                                ListDisplaySettingIteratorHelpers.SetFieldName(child, field.InternalName);
                                ListDisplaySettingIteratorHelpers.SetControlMode(child, mode);



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


        private void AddEntityPickersToLookups()
        {
            if (mode == SPControlMode.New || mode == SPControlMode.Edit)
            {
                // this represents a comma separated list of lookup field internal names to modify
                EnhancedLookupConfigValuesHelper valueHelper = null;
                var gSettings = new GridGanttSettings(list);

                try
                {
                    var rawValue = gSettings.Lookups;
                    valueHelper = new EnhancedLookupConfigValuesHelper(rawValue);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }

                if (valueHelper == null)
                {
                    return;
                }

                var formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
                foreach (var formField in formFields)
                {
                    var isEnhanced = valueHelper.ContainsKey(formField.Field.InternalName);
                    var isParent = valueHelper.IsParentField(formField.Field.InternalName);

                    if (!isEnhanced && !isParent)
                    {
                        continue;
                    }

                    var lookupData = valueHelper.GetFieldData(formField.Field.InternalName);

                    if (isParent && !isEnhanced)
                    {
                        InsertModifiedSPControl1(formField, lookupData);
                    }
                    else if (isParent && isEnhanced)
                    {
                        if (lookupData.Type == GenericType)
                        {
                            InsertEPMLiveGenericPickerControl(formField, lookupData, string.Empty);
                        }
                        else if (lookupData.Type == ModifiedType)
                        {
                            InsertModifiedSPControl1(formField, lookupData);
                        }
                    }
                    else if (!isParent && isEnhanced)
                    {
                        if (lookupData.Type == GenericType)
                        {
                            InsertEPMLiveGenericPickerControl(formField, lookupData, "SPFieldUser");
                        }
                        else if (lookupData.Type == ModifiedType)
                        {
                            InsertModifiedSPControl2(formField, lookupData);
                        }
                    }
                }
            }
        }

        private void InsertEPMLiveGenericPickerControl(FormField formField, LookupConfigData lookupData, string fieldType)
        {
            if (formField == null)
            {
                throw new ArgumentNullException(nameof(formField));
            }
            picker = new GenericEntityEditor();
            var fieldLookup = ListDisplaySettingIteratorHelpers.GetFieldLookup(formField);
            picker.MultiSelect = fieldLookup.AllowMultipleValues;

            var customValue = GetCustomValue(formField, lookupData, fieldLookup, fieldType);

            SPFieldLookupValueCollection lookupValCol = null;

            if (mode == SPControlMode.New)
            {
                lookupValCol = GetQueryStringLookupVal(formField);
            }
            else
            {
                try
                {
                    lookupValCol = new SPFieldLookupValueCollection(ListItem[fieldLookup.Id].ToString());
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }

            if (lookupValCol?.Count > 0)
            {
                var alItems = new ArrayList();
                foreach (var field in lookupValCol)
                {
                    var entity = new PickerEntity
                    {
                        Key = field.LookupId.ToString(),
                        DisplayText = field.LookupValue,
                        IsResolved = true
                    };
                    alItems.Add(entity);
                }
                picker.UpdateEntities(alItems);
            }

            picker.CustomProperty = customValue;
            formField.Controls.Add(picker);
        }

        private string GetCustomValue(FormField formField, LookupConfigData lookupData, SPFieldLookup fieldLookup, string fieldType)
        {
            if (lookupData == null)
            {
                throw new ArgumentNullException(nameof(lookupData));
            }
            if (fieldLookup == null)
            {
                throw new ArgumentNullException(nameof(fieldLookup));
            }
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Data>")
                .AppendFormat("<Param key=\"SPFieldType\">{0}</Param>", fieldType)
                .AppendFormat("<Param key=\"ParentWebID\">{0}</Param>", fieldLookup.ParentList.ParentWeb.ID)
                .AppendFormat("<Param key=\"LookupWebID\">{0}</Param>", fieldLookup.LookupWebId)
                .AppendFormat("<Param key=\"LookupListID\">{0}</Param>", fieldLookup.LookupList)
                .AppendFormat("<Param key=\"LookupFieldInternalName\">{0}</Param>", fieldLookup.LookupField)
                .AppendFormat("<Param key=\"LookupFieldID\">{0}</Param>", fieldLookup.Id)
                .AppendFormat("<Param key=\"IsMultiSelect\">{0}</Param>", fieldLookup.AllowMultipleValues)
                .AppendFormat("<Param key=\"ListID\">{0}</Param>", ListId)
                .AppendFormat("<Param key=\"ItemID\">{0}</Param>", ItemId)
                .Append(GenerateControlDataForLookupField(formField, fieldLookup.AllowMultipleValues))
                .AppendFormat("<Param key=\"Field\">{0}</Param>", lookupData.Field)
                .AppendFormat("<Param key=\"ControlType\">{0}</Param>", lookupData.Type)
                .AppendFormat("<Param key=\"Parent\">{0}</Param>", lookupData.Parent)
                .AppendFormat("<Param key=\"ParentListField\">{0}</Param>", lookupData.ParentListField)
                .AppendFormat("<Param key=\"Required\">{0}</Param>", fieldLookup.Required)
                .Append("</Data>");

            return stringBuilder.ToString();
        }

        private void InsertModifiedSPControl1(FormField formField, LookupConfigData lookupData)
        {
            if (formField == null)
            {
                throw new ArgumentNullException(nameof(formField));
            }

            var fieldLookup = ListDisplaySettingIteratorHelpers.GetFieldLookup(formField);
            if (!fieldLookup.AllowMultipleValues)
            {
                var renderControl = new CascadingLookupRenderControl
                {
                    LookupData = lookupData,
                    LookupField = fieldLookup,
                    CustomProperty = GetCustomValue(formField, fieldLookup)
                };

                formField.Controls.Add(renderControl);
            }
        }

        private void InsertModifiedSPControl2(FormField formField, LookupConfigData lookupData)
        {
            if (formField == null)
            {
                throw new ArgumentNullException(nameof(formField));
            }

            var fieldLookup = ListDisplaySettingIteratorHelpers.GetFieldLookup(formField);
            if (!fieldLookup.AllowMultipleValues)
            {
                var renderControl = new CascadingLookupRenderControl
                {
                    LookupData = lookupData,
                    LookupField = fieldLookup,
                    CustomProperty = GetCustomValue(formField, fieldLookup)
                };

                formField.Controls.Add(renderControl);
            }
            else
            {
                var renderControl = new CascadingMultiLookupRenderControl
                {
                    LookupData = lookupData,
                    LookupField = fieldLookup,
                    CustomProperty = GetCustomValue(formField, fieldLookup)
                };

                formField.Controls.Add(renderControl);
            }
        }

        private string GetCustomValue(FormField formField, SPFieldLookup fieldLookup)
        {
            if (fieldLookup == null)
            {
                throw new ArgumentNullException(nameof(fieldLookup));
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Data>")
                .Append("<Param key=\"SPFieldType\">SPFieldUser</Param>")
                .AppendFormat("<Param key=\"ParentWebID\">{0}</Param>", fieldLookup.ParentList.ParentWeb.ID)
                .AppendFormat("<Param key=\"LookupWebID\">{0}</Param>", fieldLookup.LookupWebId)
                .AppendFormat("<Param key=\"LookupListID\">{0}</Param>", fieldLookup.LookupList)
                .AppendFormat("<Param key=\"LookupFieldInternalName\">{0}</Param>", fieldLookup.LookupField)
                .AppendFormat("<Param key=\"LookupFieldID\">{0}</Param>", fieldLookup.Id)
                .AppendFormat("<Param key=\"IsMultiSelect\">{0}</Param>", fieldLookup.AllowMultipleValues)
                .AppendFormat("<Param key=\"ListID\">{0}</Param>", ListId)
                .AppendFormat("<Param key=\"ItemID\">{0}</Param>", ItemId)
                .AppendFormat("<Param key=\"Required\">{0}</Param>", fieldLookup.Required)
                .Append(GenerateControlDataForLookupField(formField, fieldLookup.AllowMultipleValues))
                .Append("</Data>");

            return stringBuilder.ToString();
        }

        private string GenerateControlDataForLookupField(FormField sourceFld, bool isMulti)
        {
            StringBuilder sbResult = new StringBuilder();
            // in the case of multi select
            // we need the ids of four controls
            // to post back data
            if (isMulti)
            {
                // need control id for the addbutton, removeButton, selectCandidate, selectResult controls
                sbResult.Append("<Param key=\"SelectCandidateID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_SelectCandidate") + "</Param>" +
                                "<Param key=\"AddButtonID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_AddButton") + "</Param>" +
                                "<Param key=\"RemoveButtonID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_RemoveButton") + "</Param>" +
                                "<Param key=\"SelectResultID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_SelectResult") + "</Param>");

            }
            // in the case of a single select
            // we just need the input or the dropdown
            // controls id to post back data
            else
            {
                sbResult.Append("<Param key=\"SourceDropDownID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_$" + sourceFld.Field.FieldRenderingControl.GetType().Name) + "</Param>");
                sbResult.Append("<Param key=\"SourceControlID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_$" + sourceFld.Field.FieldRenderingControl.GetType().Name) + "</Param>");
            }

            return sbResult.ToString();
        }

        private string GenerateControlDataForLookupField(SPField fld, bool isMulti)
        {
            StringBuilder sbResult = new StringBuilder();
            // in the case of multi select
            // we need the ids of four controls
            // to post back data
            if (isMulti)
            {
                // need control id for the addbutton, removeButton, selectCandidate, selectResult controls
                sbResult.Append("<Param key=\"SelectCandidateID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_SelectCandidate") + "</Param>" +
                                "<Param key=\"AddButtonID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_AddButton") + "</Param>" +
                                "<Param key=\"RemoveButtonID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_RemoveButton") + "</Param>" +
                                "<Param key=\"SelectResultID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_SelectResult") + "</Param>");

            }
            // in the case of a single select
            // we just need the input or the dropdown
            // controls id to post back data
            else
            {
                sbResult.Append("<Param key=\"SourceDropDownID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_$" + fld.FieldRenderingControl.GetType().Name) + "</Param>");
                sbResult.Append("<Param key=\"SourceControlID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_$" + fld.FieldRenderingControl.GetType().Name) + "</Param>");
            }

            return sbResult.ToString();
        }

        protected override bool IsFieldExcluded(SPField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (!isFeatureActivated)
            {
                return base.IsFieldExcluded(field);
            }

            if (isResList)
            {
                try
                {
                    switch (field.InternalName)
                    {
                        case ResourceLevelTitle:
                            return IsFieldExcludedResourcesLevel();
                        case PermissionsTitle:
                            return IsFieldExcludedPermissions();
                        case TitleKey:
                            return IsFieldExcludedTitle();
                        case FirstNameKey:
                        case LastNameKey:
                            return IsFieldExcludedName();
                        case EmailKey:
                            return mode != SPControlMode.New;
                        case CanLoginTitle:
                            return true;
                        case GenericTitle:
                            return mode != SPControlMode.New;
                        case Approved:
                            return IsFieldExcludedApproved(field);
                        default:
                            if (IsFieldExcludedInternalName(field.InternalName))
                            {
                                return true;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }

            if (fieldProperties == null)
            {
                return base.IsFieldExcluded(field);
            }

            if (!fieldProperties.ContainsKey(field.InternalName))
            {
                return base.IsFieldExcluded(field);
            }

            switch (mode)
            {
                case SPControlMode.Display:
                    return IsFieldExcluded(field, Display);
                case SPControlMode.Edit:
                    return IsFieldExcludedEdit(field);
                case SPControlMode.New:
                    return IsFiedlExcludedNew(field);
                default:
                    return base.IsFieldExcluded(field);
            }
        }

        private bool IsFieldExcludedResourcesLevel()
        {
            if (Web.CurrentUser.IsSiteAdmin ||
                string.Equals(
                    CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName),
                    ownerusername,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                var act = new Act(Web);
                var actType = 0;

                var levels = act.GetLevelsFromSite(out actType, string.Empty);

                return actType <= 2;
            }

            return true;
        }

        private bool IsFieldExcludedPermissions()
        {
            if (mode == SPControlMode.New)
            {
                return false;
            }

            var generic = string.Empty;
            try
            {
                generic = ListItem[GenericTitle].ToString();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return generic != FalseConst;
        }

        private bool IsFieldExcludedTitle()
        {
            if (mode != SPControlMode.Edit)
            {
                return false;
            }

            try
            {
                if (!bool.Parse(ListItem[GenericTitle].ToString()))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return false;
        }

        private bool IsFieldExcludedName()
        {
            if (mode == SPControlMode.New)
            {
                return false;
            }
            try
            {
                if (bool.Parse(ListItem[GenericTitle].ToString()))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return false;
        }

        private bool IsFieldExcludedApproved(SPField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (field.ParentList.Fields.ContainsFieldWithInternalName(ResourceLevelTitle))
            {
                return true;
            }
            var approved = No;
            try
            {
                approved = ListItem[Approved].ToString();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            return !SPContext.Current.Web.UserIsSiteAdmin || approved != FalseConst || mode == SPControlMode.New;
        }

        private bool IsFieldExcludedInternalName(string fieldInternalName)
        {
            if (isOnline)
            {
                switch (fieldInternalName)
                {
                    case SharePointAccount:
                        return true;
                }
            }
            if (!isOnline)
            {
                switch (fieldInternalName)
                {
                    case CanLoginTitle:
                    case EmailKey:
                        return true;
                }
            }
            return false;
        }

        private bool IsFieldExcluded(SPField field, string key)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }
            var displaySettings = fieldProperties[field.InternalName][key];
            if (displaySettings.Split(Separator.ToCharArray())[0].Equals(Where, StringComparison.InvariantCultureIgnoreCase))
            {
                return IsFieldExcluded2(field, displaySettings);
            }

            return base.IsFieldExcluded(field);
        }

        private bool IsFieldExcludedEdit(SPField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }
            if (!fieldProperties[field.InternalName].ContainsKey(Edit))
            {
                return base.IsFieldExcluded(field);
            }
            var displaySettings = fieldProperties[field.InternalName][Edit];
            if (displaySettings.Split(Separator.ToCharArray())[0].Equals(Where, StringComparison.InvariantCultureIgnoreCase))
            {
                return IsFieldExcluded2(field, displaySettings);
            }

            if (field.Type == SPFieldType.Calculated &&
                displaySettings.Split(Separator.ToCharArray())[0].Equals(Always, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            return base.IsFieldExcluded(field);
        }

        private bool IsFiedlExcludedNew(SPField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (!fieldProperties[field.InternalName].ContainsKey(New))
            {
                return base.IsFieldExcluded(field);
            }

            var displaySettings = fieldProperties[field.InternalName][New];
            if (displaySettings.Split(Separator.ToCharArray())[0].Equals(Where, StringComparison.InvariantCultureIgnoreCase))
            {
                return IsFieldExcluded2(field, displaySettings);
            }
            return base.IsFieldExcluded(field);
        }

        private bool IsFieldExcluded2(SPField field, string displaySettings)
        {
            var whereField = displaySettings.Split(Separator.ToCharArray())[1];
            var conditionField = string.Empty;
            string condition;
            var groupField = string.Empty;
            var valueCondition = string.Empty;
            if (whereField.Equals(Me))
            {
                condition = displaySettings.Split(Separator.ToCharArray())[2];
                groupField = displaySettings.Split(Separator.ToCharArray())[3];
            }
            else
            {
                conditionField = displaySettings.Split(Separator.ToCharArray())[2];
                condition = displaySettings.Split(Separator.ToCharArray())[3];
                valueCondition = displaySettings.Split(Separator.ToCharArray())[4];
            }
            return !EditableFieldDisplay.RenderField(
                field,
                whereField,
                conditionField,
                condition,
                groupField,
                valueCondition,
                ListItem);
        }
    }
}