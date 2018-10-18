using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using EPMLiveCore.API;
using static System.Diagnostics.Trace;
using static EPMLiveCore.Layouts.epmlive.LayoutsHelper;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace EPMLiveCore
{
    public partial class setup : LayoutsPageBase
    {

        protected string url;
        protected Button Button1;
        protected TextBox txtResourceURL;
        //protected TextBox txtMasterURL;
        protected CheckBox chkLockConfig;

        protected ListBox lstAllTemplates;
        protected ListBox lstSelectedTemplates;

        protected TextBox txtProjectServer;

        protected DropDownList ddlWorkspaceType;
        protected DropDownList ddlNavigation;
        protected DropDownList ddlPermissions;

        protected SPGridView GvGroupsPermissions;
        protected DropDownList ddlGroups;
        protected DropDownList ddlSPPermissions;

        protected DataTable dtGroupsPermissions = new DataTable();
        protected Label lblGridFocus;

        protected DropDownList ddlRoleOwners;
        protected DropDownList ddlRoleMembers;
        protected DropDownList ddlRoleVisitors;

        protected TextBox txtResToolReportURL;

        protected void btnGrpPermAdd_OnClick(object sender, EventArgs e)
        {
            HandleGridPermanentAddClickEvent(
                ViewState,
                ref dtGroupsPermissions,
                ddlGroups,
                ddlSPPermissions,
                GvGroupsPermissions,
                Button1);
        }

        protected void lnkGrpPermDelete_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)sender;

            if (ViewState["dtGroupsPermissions"] != null)
            {
                dtGroupsPermissions = (DataTable)ViewState["dtGroupsPermissions"];

                foreach (DataRow dr in dtGroupsPermissions.Rows)
                {
                    if ((dr["GroupsID"] + ";" + dr["PermissionsID"]) == lnkDelete.CommandArgument)
                    {
                        dtGroupsPermissions.Rows.Remove(dr);
                        break;
                    }
                }



                GvGroupsPermissions.DataSource = dtGroupsPermissions;
                GvGroupsPermissions.DataBind();

                ViewState["dtGroupsPermissions"] = dtGroupsPermissions;
                Button1.Focus();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlPermissions.Attributes.Add("onchange", "javascript:showhideperms(this.value);");

            if (IsPostBack)
            {
                return;
            }

            var web = SPContext.Current.Web;
            {
                web.Site.CatchAccessDeniedException = false;
                web.AllowUnsafeUpdates = true;

                PopulatePermissionsDropDown(web);
                PopulateRoleDropDowns(web);
                PopulateDataTables(web);
                PopulateGridViews();
                PopulateViewState();
                PopulateTextBoxes(web);
                PopulateDropDownLists(web);
                PopulateCheckboxes(web);
                PopulateInputForms(web);
                SetEnterpriseVisibility(web);
                checkLocks(web);
            }

        }

        private void PopulatePermissionsDropDown(SPWeb web)
        {
            var oRoleDefinitions = web.Site.RootWeb.RoleDefinitions;

            foreach (SPRoleDefinition oRoleDefinition in oRoleDefinitions)
            {
                ddlSPPermissions.Items.Add(new ListItem(oRoleDefinition.Name, oRoleDefinition.Id.ToString()));
            }
        }

        private void PopulateRoleDropDowns(SPWeb web)
        {
            var collGroups = web.Site.RootWeb.SiteGroups;
            foreach (SPGroup oGroup in collGroups)
            {
                ddlGroups.Items.Add(new ListItem(oGroup.Name, oGroup.ID.ToString()));
                ddlRoleOwners.Items.Add(new ListItem(oGroup.Name, oGroup.ID.ToString()));
                ddlRoleMembers.Items.Add(new ListItem(oGroup.Name, oGroup.ID.ToString()));
                ddlRoleVisitors.Items.Add(new ListItem(oGroup.Name, oGroup.ID.ToString()));
            }
        }

        private void PopulateDataTables(SPWeb web)
        {
            dtGroupsPermissions.Columns.Add("GroupsText");
            dtGroupsPermissions.Columns.Add("GroupsID");
            dtGroupsPermissions.Columns.Add("PermissionsText");
            dtGroupsPermissions.Columns.Add("PermissionsID");

            var strEpmLiveGroupsPermAssignments = CoreFunctions.getConfigSetting(web, "EPMLiveGroupsPermAssignments");
            if (strEpmLiveGroupsPermAssignments.Length > 1)
            {
                var strOuter = strEpmLiveGroupsPermAssignments.Split(
                    new[]
                    {
                        "|~|"
                    },
                    StringSplitOptions.None);
                ProcessPermissionStrings(web, strOuter, dtGroupsPermissions);
            }
        }

        private void PopulateGridViews()
        {
            GvGroupsPermissions.DataSource = dtGroupsPermissions;
            GvGroupsPermissions.DataBind();
        }

        private void PopulateViewState()
        {
            if (ViewState["dtGroupsPermissions"] == null)
            {
                ViewState.Add("dtGroupsPermissions", dtGroupsPermissions);
            }
        }

        private void PopulateTextBoxes(SPWeb web)
        {
            url = web.Site.Url;

            txtGalleryUrl.Text = CoreFunctions.getConfigSetting(web, "EPMLiveTemplateGalleryURL", false, false);
            txtResourceURL.Text = CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", false, false);

            txtProjectServer.Text = CoreFunctions.getConfigSetting(web, "EPMLiveProjectServerURL", false, false);
            txtResToolReportURL.Text = CoreFunctions.getConfigSetting(web, "ResToolsReportURL");
        }

        private void PopulateDropDownLists(SPWeb web)
        {
            ddlWorkspaceType.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectWorkspaceType");
            ddlNavigation.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectNavigation");
            ddlPermissions.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectPermissions");

            ddlRoleOwners.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectRoleOwners");
            ddlRoleMembers.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectRoleMembers");
            ddlRoleVisitors.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectRoleVisitors");
        }

        private void PopulateCheckboxes(SPWeb web)
        {
            try
            {
                chkUsePE.Checked = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveUseWEPeoplePicker"));
            }
            catch (Exception ex)
            {
                TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                chkLiveTemplates.Checked = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveUseLiveTemplates"));
            }
            catch (Exception ex)
            {
                TraceError("Exception Suppressed {0}", ex);
            }
        }

        private void PopulateInputForms(SPWeb web)
        {
            var templates = web.Lists.TryGetList("Template Gallery");

            if (templates == null)
            {
                loadTemplates(CoreFunctions.getConfigSetting(web, "EPMLiveValidTemplates"));
                InputFormSectionCreateOptions.Visible = false;
                InputFormSectionGalleryUrl.Visible = false;
                InputFormSectionGalleryLive.Visible = false;
            }
            else
            {
                InputFormSection6.Visible = false;
                InputFormSectionGalleryUrl.Visible = true;
                InputFormSectionGalleryLive.Visible = true;
                var props = new PropertyHash(CoreFunctions.getConfigSetting(web, "EPMLiveCreateNewSettings"), ";#", '|', '^');
                try
                {
                    ddlDefaultCreate.SelectedValue = props[0]["Default"].ToString();
                    chkCreateOptions.Items[0].Selected = bool.Parse(props[1]["Online"].ToString());
                    chkCreateOptions.Items[1].Selected = bool.Parse(props[1]["Local"].ToString());
                    chkCreateOptions.Items[2].Selected = bool.Parse(props[1]["Existing"].ToString());
                }
                catch (Exception ex)
                {
                    TraceError("Exception Suppressed {0}", ex);
                }
            }
        }

        private void SetEnterpriseVisibility(SPWeb web)
        {
            if (web.Features[new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055")] != null)
            {
                pnlEnterprise.Visible = true;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ArrayList arrDel = new ArrayList();
            foreach (ListItem li in lstAllTemplates.Items)
            {
                if (li.Selected)
                {
                    arrDel.Add(li);
                    lstSelectedTemplates.Items.Add(li);
                }
            }

            foreach (ListItem li in arrDel)
            {
                lstAllTemplates.Items.Remove(li);
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            ArrayList arrDel = new ArrayList();
            foreach (ListItem li in lstSelectedTemplates.Items)
            {
                if (li.Selected)
                {
                    arrDel.Add(li);
                    lstAllTemplates.Items.Add(li);
                }
            }

            foreach (ListItem li in arrDel)
            {
                lstSelectedTemplates.Items.Remove(li);
            }
        }

        private void checkLocks(SPWeb web)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                Guid lockweb = EPMLiveCore.CoreFunctions.getLockedWeb(web);

                if (lockweb != Guid.Empty)
                {
                    if (lockweb != web.ID)
                    {
                        using(SPWeb lweb = web.Site.OpenWeb(lockweb))
                        {
                            bool isWebLocked = false;
                            
                            try
                            {
                                isWebLocked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(lweb, "EPMLiveLockConfig"));
                            }
                            catch { }

                            if(isWebLocked)
                            {
                                pnlConfigUrls.Visible = false;
                                chkLockConfig.Checked = false;
                            }
                            else
                            {
                                try
                                {
                                    chkLockConfig.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveLockConfig"));
                                }
                                catch { }
                            }
                        }
                    }
                    else
                    {
                        pnlConfigUrls.Visible = true;
                        try
                        {
                            chkLockConfig.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveLockConfig"));
                        }
                        catch { }
                    }
                }
                else
                {
                    pnlConfigUrls.Visible = true;
                    try
                    {
                        chkLockConfig.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveLockConfig"));
                    }
                    catch { }
                }


                
            });
        }

        protected void lnkButton_Click(object sender, EventArgs e)
        {
            string url = "";
            SPSite site = SPContext.Current.Site;
            {
                try
                {
                    site.Features.Add(new Guid("25aec3aa-cf9d-4c50-9a29-2c0784781769"), true);
                }
                catch { }
            }

            SPWeb web = SPContext.Current.Web;
            {
                try
                {
                    web.Features.Add(new Guid("43f848fd-8a3a-49be-88c6-18ae16a3714b"), true);
                }
                catch { }
                url = web.ServerRelativeUrl;
            }

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/setup.aspx?rnd=" + Guid.NewGuid(), Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            web.AllowUnsafeUpdates = true;


            CoreFunctions.setConfigSetting(web, "EPMLiveResourceURL", HttpUtility.UrlDecode(txtResourceURL.Text.Replace("default.aspx","")));
            //CoreFunctions.setConfigSetting(web, "EPMLiveTimePhasedURL", HttpUtility.UrlDecode(txtMasterURL.Text.Replace("default.aspx", "")));
            CoreFunctions.setConfigSetting(web, "ResToolsReportURL", HttpUtility.UrlDecode(txtResToolReportURL.Text));
            CoreFunctions.setConfigSetting(web, "EPMLiveTemplateGalleryURL", HttpUtility.UrlDecode(txtGalleryUrl.Text.Replace("default.aspx", "")));

            //CoreFunctions.setConfigSetting(web, "EPMLiveDisablePublishing", chkDisablePublishing.Checked.ToString());

            CoreFunctions.setConfigSetting(web, "EPMLiveNewProjectWorkspaceType",ddlWorkspaceType.SelectedValue);
            CoreFunctions.setConfigSetting(web, "EPMLiveNewProjectNavigation", ddlNavigation.SelectedValue);
            CoreFunctions.setConfigSetting(web, "EPMLiveNewProjectPermissions", ddlPermissions.SelectedValue);

            if (web.Features[new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055")] != null)
                CoreFunctions.setConfigSetting(web, "EPMLiveProjectServerURL", txtProjectServer.Text.Replace("default.aspx", ""));

            //if (web.CurrentUser.IsSiteAdmin)
            //    CoreFunctions.setConfigSetting(web, "EPMLiveAllowListSynch", chkAllowSynch.Checked.ToString());

            CoreFunctions.setConfigSetting(web, "EPMLiveLockConfig", chkLockConfig.Checked.ToString());

            CoreFunctions.setConfigSetting(web, "EPMLiveGroupsPermAssignments", GetGroupsPermissionsAssignment());

            CoreFunctions.setConfigSetting(web, "EPMLiveNewProjectRoleOwners", ddlRoleOwners.SelectedValue);
            CoreFunctions.setConfigSetting(web, "EPMLiveNewProjectRoleMembers", ddlRoleMembers.SelectedValue);
            CoreFunctions.setConfigSetting(web, "EPMLiveNewProjectRoleVisitors", ddlRoleVisitors.SelectedValue);
            CoreFunctions.setConfigSetting(web, "EPMLiveUseWEPeoplePicker", chkUsePE.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveUseLiveTemplates", chkLiveTemplates.Checked.ToString());
            
            string validtemplates = "";

            foreach (ListItem li in lstSelectedTemplates.Items)
            {
                validtemplates += "|" + li.Value;
            }
            if (validtemplates.Length > 1)
                validtemplates = validtemplates.Substring(1);
            CoreFunctions.setConfigSetting(web, "EPMLiveValidTemplates", validtemplates);

            API.PropertyHash props = new API.PropertyHash("",";#",'|','^');
            props.Update(0, "Default^" + ddlDefaultCreate.SelectedValue);
            props.Add("Online^" + chkCreateOptions.Items[0].Selected + "|Local^" + chkCreateOptions.Items[1].Selected + "|Existing^" + chkCreateOptions.Items[2].Selected);

            CoreFunctions.setConfigSetting(web, "EPMLiveCreateNewSettings", props.ToString());

            //web.MasterUrl = ddlMasterPages.SelectedValue.ToString(); 
            //web.Update();
            checkLocks(web);

            string url = web.ServerRelativeUrl;

            if(!String.IsNullOrEmpty(Request["Source"]))
            {
                Response.Redirect(Request["Source"]);
            }
            else
            {
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("settings.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            
        }

        private void loadTemplates(string validtemplates)
        {
            Hashtable hshTemplates = new Hashtable();
            SPWebTemplateCollection sptemps = SPContext.Current.Web.GetAvailableWebTemplates(SPContext.Current.Web.Language);

            SortedList sl = new SortedList();

            foreach (SPWebTemplate webTemplate in sptemps)
            {
                if (!webTemplate.IsHidden && !webTemplate.Title.Contains("EPM Live"))
                    hshTemplates.Add(webTemplate.Title, webTemplate.Title);
            }

            SPWeb web = SPContext.Current.Web;
            {
                string[] templates = validtemplates.Split('|');
                foreach (string template in templates)
                {
                    if (hshTemplates.Contains(template))
                    {
                        lstSelectedTemplates.Items.Add(new ListItem(hshTemplates[template].ToString(), template));
                        hshTemplates.Remove(template);
                    }
                }
            }

            foreach (DictionaryEntry de in hshTemplates)
            {
                sl.Add(de.Value.ToString(), de.Key.ToString());
            }

            foreach (DictionaryEntry de in sl)
            {
                lstAllTemplates.Items.Add(new ListItem(de.Key.ToString(), de.Value.ToString()));
            }
        }

        private string GetGroupsPermissionsAssignment()
        {
            StringBuilder sbGroupsPermissions = new StringBuilder();

            if (ViewState["dtGroupsPermissions"] != null)
            {
                dtGroupsPermissions = (DataTable)ViewState["dtGroupsPermissions"];

                foreach (DataRow dr in dtGroupsPermissions.Rows)
                {
                    sbGroupsPermissions.Append(dr["GroupsID"] + "~" + dr["PermissionsID"] + "|~|");
                }
            }
            if (sbGroupsPermissions.ToString().Length > 1)
            {
                string strTemp = sbGroupsPermissions.ToString().Substring(0, sbGroupsPermissions.ToString().Length - 3);
                return strTemp;
            }
            else
            {
                return String.Empty;
            }
        }

        protected void btnSynch_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            try
            {
                web.AllowUnsafeUpdates = true;

                string url = CoreFunctions.getConfigSetting(web, "EPMLiveTimePhasedURL");

                if (url != "")
                {

                    ArrayList periods = getPeriods(url);

                    SPList list = web.Lists["EPMLiveTimePhased"];

                    foreach (string period in periods)
                    {
                        try
                        {
                            SPField f = list.Fields.GetFieldByInternalName(period.Replace(" ", "_x0020_"));
                        }
                        catch
                        {
                            list.Fields.Add(period, SPFieldType.Number, false);
                        }
                    }

                    ArrayList arrDelFields = new ArrayList();

                    foreach (SPField f in list.Fields)
                    {
                        if (!f.Hidden && !f.Sealed && f.Type == SPFieldType.Number)
                        {
                            string fName = f.InternalName.Replace("_x0020_", " ");
                            if (!periods.Contains(fName))
                                arrDelFields.Add(fName);
                        }
                    }

                    foreach (string fName in arrDelFields)
                    {
                        list.Fields.GetFieldByInternalName(fName.Replace(" ", "_x0020_")).Delete();
                    }

                    Page.RegisterStartupScript("Alert", "<script language=\"javascript\">alert('All Periods have been synchronized');</script>");
                }
            }
            catch { }

        }

        private ArrayList getPeriods(string url)
        {
            url = url.ToLower();
            ArrayList ret = new ArrayList();
            using (SPSite site = new SPSite(url))
            {
                int ind = url.IndexOf(site.ServerRelativeUrl.ToLower());
                if (ind > 0)
                {
                    url = url.Substring(ind);
                }

                using (SPWeb web = site.OpenWeb(url))
                {

                    

                    try
                    {
                        SPList list = web.Lists["EPMLivePeriods"];
                        foreach (SPListItem li in list.Items)
                        {
                            ret.Add(li.Title);
                        }
                    }
                    catch { }
                }
            }
            return ret;
        }
    }
}
