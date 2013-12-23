using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Linq;
using EPMLiveCore.ListDefinitions;
using EPMLiveWebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using System.Net;
using EPMLiveReportsAdmin;
using System.Collections.ObjectModel;
using System.Diagnostics;
using EPMLiveCore.Infrastructure;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class gridganttsettings : LayoutsPageBase
    {
        protected TextBox txtRollupLists;
        protected TextBox txtRollupSites;
        protected CheckBox chkExecutive;
        protected CheckBox chkShowViewToolbar;
        protected CheckBox chkHideNewButton;
        protected CheckBox chkUsePopup;
        protected CheckBox chkResTools;
        protected CheckBox chkPerformance;
        protected CheckBox chkAllowEdit;
        protected CheckBox chkEditDefault;
        protected CheckBox chkShowInsert;
        protected CheckBox chkDisableNewRollup;
        protected CheckBox chkEnableRequests;
        protected CheckBox chkUseNewMenu;
        protected TextBox txtNewMenuName;

        protected static string strListName;
        protected string strListId;
        protected string strReportActionUrl = string.Empty;

        protected DataTable dtGroupsPermissions = new DataTable();

        const string REPORT_CHECK_URL = "/_layouts/epmlive/ReportCheckActions.aspx";

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


        protected void btnGrpPermAdd_OnClick(object sender, EventArgs e)
        {

            if (ViewState["dtGroupsPermissions"] != null)
            {
                dtGroupsPermissions = (DataTable)ViewState["dtGroupsPermissions"];
                DataRow dr = dtGroupsPermissions.NewRow();
                dr["GroupsText"] = ddlGroups.Items[ddlGroups.SelectedIndex].Text;
                dr["GroupsID"] = ddlGroups.Items[ddlGroups.SelectedIndex].Value;
                dr["PermissionsText"] = ddlSPPermissions.Items[ddlSPPermissions.SelectedIndex].Text;
                dr["PermissionsID"] = ddlSPPermissions.Items[ddlSPPermissions.SelectedIndex].Value;

                bool blnRecordExists = false;
                foreach (DataRow dr2 in dtGroupsPermissions.Rows)
                {
                    if ((dr2["GroupsID"] + ";" + dr2["PermissionsID"]) == ddlGroups.Items[ddlGroups.SelectedIndex].Value + ";" + ddlSPPermissions.Items[ddlSPPermissions.SelectedIndex].Value)
                    {
                        blnRecordExists = true;
                        break;
                    }
                }

                if (!blnRecordExists)
                {
                    dtGroupsPermissions.Rows.Add(dr);
                    GvGroupsPermissions.DataSource = dtGroupsPermissions;
                    GvGroupsPermissions.DataBind();
                    ViewState["dtGroupsPermissions"] = dtGroupsPermissions;
                }
            }

            Button1.Focus();
        }
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "GridGanttSettings"
            });
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strListId = Request["List"];
                strReportActionUrl = SPContext.Current.Web.Url + REPORT_CHECK_URL;
                chkTimesheet.InputAttributes.Add("onclick", "CheckTimesheet();");

                SPWeb web = SPContext.Current.Web;
                {

                    SPRoleDefinitionCollection oRoleDefinitions = web.Site.RootWeb.RoleDefinitions;

                    foreach (SPRoleDefinition oRoleDefinition in oRoleDefinitions)
                    {
                        ddlSPPermissions.Items.Add(new ListItem(oRoleDefinition.Name, oRoleDefinition.Id.ToString()));
                    }

                    SPGroupCollection collGroups = web.Site.RootWeb.SiteGroups;
                    foreach (SPGroup oGroup in collGroups)
                    {
                        ddlGroups.Items.Add(new ListItem(oGroup.Name, oGroup.ID.ToString()));
                    }

                    dtGroupsPermissions.Columns.Add("GroupsText");
                    dtGroupsPermissions.Columns.Add("GroupsID");
                    dtGroupsPermissions.Columns.Add("PermissionsText");
                    dtGroupsPermissions.Columns.Add("PermissionsID");

                    ArrayList arrLookups = new ArrayList();
                    SPList list = web.Lists[new Guid(Request["List"])];
                    strListName = list.Title;

                    ddlStartDate.Items.Add(new ListItem("< Select Field >", ""));
                    ddlDueDate.Items.Add(new ListItem("< Select Field >", ""));
                    ddlProgressBar.Items.Add(new ListItem("< Select Field >", ""));
                    ddlMilestone.Items.Add(new ListItem("< Select Field >", ""));
                    ddlInformation.Items.Add(new ListItem("< Select Field >", ""));
                    ddlWBS.Items.Add(new ListItem("< Select Field >", ""));

                    if (list.Title == CoreFunctions.getConfigSetting(web, "EPMLiveProjectCenter") || list.Title == "Project Center Rollup")
                    {
                        ddlItemLink.Items.Add(new ListItem("Edit Work Plan", "workplan"));
                        ddlItemLink.Items.Add(new ListItem("Task Center", "tasks"));
                    }

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite site = new SPSite(web.Site.ID))
                        {
                            using (SPWeb w = site.OpenWeb(web.ID))
                            {
                                string planners = CoreFunctions.getLockConfigSetting(w, "EPMLivePlannerPlanners", false);

                                foreach (string planner in planners.Split(','))
                                {
                                    if (!String.IsNullOrEmpty(planner))
                                    {
                                        string[] sPlanner = planner.Split('|');
                                        string pc = CoreFunctions.getLockConfigSetting(w, "EPMLivePlanner" + sPlanner[0] + "ProjectCenter", false);

                                        if (pc == list.Title)
                                        {
                                            ddlItemLink.Items.Add(new ListItem("Planner", "planner"));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    });

                    foreach (SPField field in list.Fields)
                    {
                        if (!field.Hidden && field.Type != SPFieldType.Computed)
                        {
                            switch (field.Type)
                            {
                                case SPFieldType.DateTime:
                                    ddlStartDate.Items.Add(new ListItem(field.Title, field.InternalName));
                                    ddlDueDate.Items.Add(new ListItem(field.Title, field.InternalName));
                                    ddlInformation.Items.Add(new ListItem(field.Title, field.InternalName));
                                    break;
                                case SPFieldType.Number:
                                    ddlProgressBar.Items.Add(new ListItem(field.Title, field.InternalName));
                                    ddlInformation.Items.Add(new ListItem(field.Title, field.InternalName));
                                    break;
                                case SPFieldType.Text:
                                    ddlWBS.Items.Add(new ListItem(field.Title, field.InternalName));
                                    ddlInformation.Items.Add(new ListItem(field.Title, field.InternalName));
                                    break;
                                case SPFieldType.Boolean:
                                    ddlInformation.Items.Add(new ListItem(field.Title, field.InternalName));
                                    ddlMilestone.Items.Add(new ListItem(field.Title, field.InternalName));
                                    break;
                                default:
                                    ddlInformation.Items.Add(new ListItem(field.Title, field.InternalName));
                                    break;
                            };
                        }
                    }

                    var gSettings = new GridGanttSettings(list);

                    ddlStartDate.SelectedValue = gSettings.StartDate;
                    ddlDueDate.SelectedValue = gSettings.DueDate;
                    ddlProgressBar.SelectedValue = gSettings.Progress;
                    ddlWBS.SelectedValue = gSettings.WBS;
                    ddlMilestone.SelectedValue = gSettings.Milestone;
                    chkExecutive.Checked = gSettings.Executive;
                    ddlInformation.SelectedValue = gSettings.Information;
                    ddlItemLink.SelectedValue = gSettings.ItemLink;
                    txtRollupLists.Text = gSettings.RollupLists.Replace(",", "\r\n").Replace("|", ",");
                    txtRollupSites.Text = gSettings.RollupSites.Replace(",", "\r\n");
                    chkShowViewToolbar.Checked = gSettings.ShowViewToolbar;
                    chkHideNewButton.Checked = gSettings.HideNewButton;
                    chkPerformance.Checked = gSettings.Performance;
                    chkAllowEdit.Checked = gSettings.AllowEdit;
                    chkEditDefault.Checked = gSettings.EditDefault;
                    chkShowInsert.Checked = gSettings.ShowInsert;
                    chkDisableNewRollup.Checked = gSettings.DisableNewItemMod;
                    chkUseNewMenu.Checked = gSettings.UseNewMenu;
                    txtNewMenuName.Text = gSettings.NewMenuName;
                    chkUsePopup.Checked = gSettings.UsePopup;
                    chkEnableRequests.Checked = gSettings.EnableRequests;

                    var defaultTemps = GetAvailableDefaultTemps();
                    bool showAutoCreate = defaultTemps.Count > 1;

                    chkAutoCreate.Checked = gSettings.EnableAutoCreation;
                    ifcAutoCreate.Visible = showAutoCreate;

                    ddlAutoCreateTemplate.DataSource = defaultTemps;
                    ddlAutoCreateTemplate.DataTextField = "Key";
                    ddlAutoCreateTemplate.DataValueField = "Value";
                    ddlAutoCreateTemplate.DataBind();
                    ddlAutoCreateTemplate.SelectedValue = gSettings.AutoCreationTemplateId;
                    ifcAutoCreateTemplate.Visible = showAutoCreate;
                    ddlAutoCreateTemplate.Enabled = (showAutoCreate && chkAutoCreate.Checked);

                    //fill parentsitelookup ddl
                    ddlParentSiteLookup.DataSource = GetAvailableParentSiteLookups(list, gSettings);
                    ddlParentSiteLookup.DataTextField = "Key";
                    ddlParentSiteLookup.DataValueField = "Value";
                    ddlParentSiteLookup.DataBind();
                    ddlParentSiteLookup.SelectedValue = gSettings.WorkspaceParentSiteLookup;

                    //load list icon
                    spnListIcon.CssClass = string.IsNullOrEmpty(gSettings.ListIcon) ? "icon-square" : gSettings.ListIcon;
                    hdnListIcon.Value = string.IsNullOrEmpty(gSettings.ListIcon) ? "icon-square" : gSettings.ListIcon;

                    chkWorkListFeat.Checked = gSettings.EnableWorkList;
                    chkEmails.Checked = gSettings.SendEmails;
                    chkDeleteRequest.Checked = gSettings.DeleteRequest;
                    txtRequestList.Text = gSettings.RequestList;
                    chkUseParent.Checked = gSettings.UseParent;
                    chkSearch.Checked = gSettings.Search;
                    chkLockSearch.Checked = gSettings.LockSearch;
                    chkAssociatedItems.Checked = gSettings.AssociatedItems;
                    chkEnableTeam.Checked = gSettings.BuildTeam;
                    chkContentReporting.Checked = gSettings.EnableContentReporting;
                    chkResTools.Checked = gSettings.EnableResourcePlan;
                    chkDisplayRedirect.Checked = gSettings.DisplayFormRedirect;

                    //if ((uint)list.BaseTemplate == 10115 || (uint)list.BaseTemplate == 10702 || (uint)list.BaseTemplate == 10701)
                    {
                        SectionEmail.Visible = true;
                        //try
                        //{
                        //    chkEmails.Checked = bool.Parse(CoreFunctions.getListSetting(list, "AssignedToEmail"));
                        //}
                        //catch { }
                        //chkEmails.Checked = list.EnableAssignToEmail;
                    }

                    chkEnableTeamSecurity.Checked = gSettings.BuildTeamSecurity;

                    if (gSettings.BuildTeamPermissions.Length > 1)
                    {

                        string[] strOuter = gSettings.BuildTeamPermissions.Split(new string[] { "|~|" }, StringSplitOptions.None);
                        foreach (string strInner in strOuter)
                        {
                            string[] strInnerMost = strInner.Split('~');
                            DataRow dr = dtGroupsPermissions.NewRow();
                            SPGroup g = null;
                            SPRoleDefinition r = null;

                            try
                            {
                                g = web.SiteGroups.GetByID(Convert.ToInt32(strInnerMost[0]));
                                r = web.RoleDefinitions.GetById(Convert.ToInt32(strInnerMost[1]));
                            }
                            catch { }
                            if (g != null && r != null)
                            {
                                dr["GroupsText"] = g.Name;
                                dr["GroupsID"] = strInnerMost[0];
                                dr["PermissionsText"] = r.Name;
                                dr["PermissionsID"] = strInnerMost[1];
                                dtGroupsPermissions.Rows.Add(dr);
                            }
                        }
                    }

                    GvGroupsPermissions.DataSource = dtGroupsPermissions;
                    GvGroupsPermissions.DataBind();

                    if (ViewState["dtGroupsPermissions"] == null)
                        ViewState.Add("dtGroupsPermissions", dtGroupsPermissions);

                    SPWeb rootWeb = web.Site.RootWeb;

                    ArrayList lists = new ArrayList(CoreFunctions.getConfigSetting(rootWeb, "EPMLiveTSLists").Replace("\r\n", "\n").Split('\n')); ;

                    if (lists.Contains(list.Title))
                    {
                        chkTimesheet.Checked = true;
                    }

                    // display reporting section dynamically
                    ReportBiz reportBiz = new ReportBiz(SPContext.Current.Site.ID, SPContext.Current.Web.ID, false);
                    if (reportBiz.SiteExists())
                    {
                        ifsEnableReporting.Visible = true;
                        Collection<string> mappedLists = reportBiz.GetMappedLists();
                        Collection<string> mappedListIds = reportBiz.GetMappedListsIds();
                        bool isMapped = mappedLists.Contains(list.Title);
                        bool isMaster = mappedListIds.Contains(list.ID.ToString().ToLower());

                        cbEnableReporting.Checked = isMapped;
                        cbEnableReporting.Enabled = (isMaster || !isMapped);

                        List<SPEventReceiverDefinition> evts = GetListEvents(list,
                                                                            "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050",
                                                                            "EPMLiveReportsAdmin.ListEvents",
                                                                            new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded, 
                                                                                                            SPEventReceiverType.ItemUpdated, 
                                                                                                            SPEventReceiverType.ItemDeleting });

                        bool hasEvents = (evts.Count > 0);
                        btnAddEvt.Visible = (isMapped && !hasEvents);
                    }
                }
            }
        }


        private Dictionary<string, int> GetAvailableDefaultTemps()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("None", -1);
            SPQuery getAllItemsQuery = new SPQuery();
            getAllItemsQuery.Query = "<Where><Eq><FieldRef Name='Active' /><Value Type='Bool'>True</Value></Eq></Where><OrderBy><FieldRef Name=\"Title0\" Ascending=\"True\" /></OrderBy>";
            SPList tmpGalList = SPContext.Current.Web.Lists.TryGetList("Template Gallery");
            if (tmpGalList != null)
            {
                SPListItemCollection templates = tmpGalList.GetItems(getAllItemsQuery);
                foreach (SPListItem template in templates)
                {
                    // the templatetype is not matching, skip this template
                    if (template[tmpGalList.Fields.GetFieldByInternalName("TemplateType").Id] != null &&
                        template[tmpGalList.Fields.GetFieldByInternalName("TemplateType").Id].ToString()
                            .Trim()
                            .Equals("workspace", StringComparison.CurrentCultureIgnoreCase))
                    {
                        result.Add(template["Description"].ToString(), template.ID);
                    }
                }
            }

            return result;
        }

        private Dictionary<string, string> GetAvailableParentSiteLookups(SPList list, GridGanttSettings gSettings)
        {
            var result = new Dictionary<string, string> { { "None", "None" } };
            string[] LookupArray = gSettings.Lookups.Split('|');
            foreach (string sLookup in LookupArray)
            {
                if (sLookup != "")
                {
                    string[] sLookupInfo = sLookup.Split('^');
                    string fldName = sLookupInfo[0];
                    SPField fld = null;
                    if (!string.IsNullOrEmpty(fldName))
                    {
                        try
                        {
                            fld = list.Fields.GetFieldByInternalName(fldName);
                        }
                        catch { }
                    }
                    if (fld != null)
                    {
                        result.Add(fldName, fldName);
                    }
                }
            }

            return result;
        }

        private List<SPEventReceiverDefinition> GetListEvents(SPList list, string assemblyName, string className, List<SPEventReceiverType> types)
        {
            List<SPEventReceiverDefinition> evts = new List<SPEventReceiverDefinition>();

            try
            {
                evts = (from e in list.EventReceivers.OfType<SPEventReceiverDefinition>()
                        where e.Assembly.Equals(assemblyName, StringComparison.CurrentCultureIgnoreCase) &&
                              e.Class.Equals(className, StringComparison.CurrentCultureIgnoreCase) &&
                              types.Contains(e.Type)
                        select e).ToList<SPEventReceiverDefinition>();
            }
            catch
            {

            }

            return evts;
        }

        private void AddGridGanttToViews(SPList list)
        {
            //string siteUrl = SPContext.Current.Site.Url;
            //SPWeb web = SPContext.Current.Web;
            //SPList list = web.Lists[new Guid(Request["List"])];

            foreach (SPView v in list.Views)
            {
                if (v.Type.Equals("HTML", StringComparison.CurrentCultureIgnoreCase))
                {
                    using (SPLimitedWebPartManager wpMgr = Web.GetLimitedWebPartManager(v.ServerRelativeUrl, PersonalizationScope.Shared))
                    {
                        bool wpAlreadyExists = false;

                        foreach (System.Web.UI.WebControls.WebParts.WebPart wp in wpMgr.WebParts)
                        {
                            if (wp.GetType().Equals(typeof(GridListView)))
                            {
                                wpAlreadyExists = true;
                                break;
                            }
                        }

                        if (!wpAlreadyExists)
                        {
                            GridListView wpGridListView = new GridListView();
                            wpMgr.AddWebPart(wpGridListView, "Main", 0);
                            wpMgr.SaveChanges(wpGridListView);
                            Web.Update();
                        }
                    }
                }
            }

        }

        private void RemoveEventHandlers()
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists[new Guid(Request["List"])];
            web.AllowUnsafeUpdates = true;
            string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
            string className = "EPMLiveCore.StatusingEvent";

            SPEventReceiverDefinitionCollection eventColl = list.EventReceivers;
            List<SPEventReceiverDefinition> listsToDelete = new List<SPEventReceiverDefinition>();

            foreach (SPEventReceiverDefinition eventDef in eventColl)
            {
                if (eventDef.Assembly.Equals(assemblyName) &&
                    eventDef.Class.Equals(className))
                {
                    if (eventDef.Type.Equals(SPEventReceiverType.ItemAdding) ||
                        eventDef.Type.Equals(SPEventReceiverType.ItemUpdating) ||
                        eventDef.Type.Equals(SPEventReceiverType.ItemDeleted))
                    {
                        listsToDelete.Add(eventDef);
                    }
                }
            }

            if (listsToDelete.Count > 0)
            {
                foreach (SPEventReceiverDefinition eventDel in listsToDelete)
                {
                    eventDel.Delete();
                }
            }

            list.Update();

        }

        private void AddFields(SPList list)
        {

            // add Today field
            try
            {
                if (!FieldExistsInList(list, "Today"))
                {
                    string fldTodayIntName = list.Fields.Add("Today", SPFieldType.Text, false);
                    SPFieldText fldToday = list.Fields.GetFieldByInternalName(fldTodayIntName) as SPFieldText;
                    fldToday.Update();
                }
            }
            catch { }
            if (!FieldExistsInList(list, "Today"))
            {
                string fldTodayIntName = list.Fields.Add("Today", SPFieldType.Text, false);
                SPFieldText fldToday = list.Fields.GetFieldByInternalName(fldTodayIntName) as SPFieldText;
                fldToday.Update();
            }
            // add startdate field
            if (!FieldExistsInList(list, "StartDate"))
            {
                string fldSDIntName = list.Fields.Add("StartDate", SPFieldType.DateTime, false);
                SPFieldDateTime fldSD = list.Fields.GetFieldByInternalName(fldSDIntName) as SPFieldDateTime;
                fldSD.Title = "Start Date";
                fldSD.DisplayFormat = SPDateTimeFieldFormatType.DateOnly;
                fldSD.Sealed = false;
                fldSD.AllowDeletion = false;
                fldSD.Description = "Enter the estimated start date for this item.";
                fldSD.Update();
            }

            // add DueDate field
            if (!FieldExistsInList(list, "DueDate"))
            {
                string fldDDIntName = list.Fields.Add("DueDate", SPFieldType.DateTime, false);
                SPFieldDateTime fldDD = list.Fields.GetFieldByInternalName(fldDDIntName) as SPFieldDateTime;
                fldDD.Title = "Due Date";
                fldDD.DisplayFormat = SPDateTimeFieldFormatType.DateOnly;
                fldDD.Sealed = false;
                fldDD.AllowDeletion = false;
                fldDD.Description = "Enter the estimated due date for this item.";
                fldDD.Update();
            }

            // add AssignedTo field
            if (!FieldExistsInList(list, "AssignedTo"))
            {
                string fldATIntName = list.Fields.Add("AssignedTo", SPFieldType.User, false);
                SPFieldUser fldAT = list.Fields.GetFieldByInternalName(fldATIntName) as SPFieldUser;
                fldAT.Title = "Assigned To";
                fldAT.AllowMultipleValues = true;
                fldAT.Sealed = false;
                fldAT.AllowDeletion = false;
                fldAT.Description = "Enter the resource(s) assigned to this item.  You can enter their email address, username, or use the address book.";
                fldAT.Update();
            }

            // add Priority field
            if (!FieldExistsInList(list, "Priority"))
            {
                StringCollection choices = new StringCollection();
                choices.AddRange(new string[] { "(1) High", "(2) Normal", "(3) Low" });
                string fldPIntName = list.Fields.Add("Priority", SPFieldType.Choice, false, false, choices);
                SPFieldChoice fldP = list.Fields.GetFieldByInternalName(fldPIntName) as SPFieldChoice;
                fldP.Title = "Priority";
                fldP.DefaultValue = "(1) High";
                fldP.Sealed = false;
                fldP.AllowDeletion = false;
                fldP.Update();
            }

            // add status field
            if (!FieldExistsInList(list, "Status"))
            {
                StringCollection choices = new StringCollection();
                choices.AddRange(new string[] { "Not Started", "In Progress", "Completed", "Deferred", "Waiting on someone else" });
                string fldStatusIntName = list.Fields.Add("Status", SPFieldType.Choice, false, false, choices);
                SPFieldChoice fldStatus = list.Fields.GetFieldByInternalName(fldStatusIntName) as SPFieldChoice;
                fldStatus.DefaultValue = "Not Started";
                fldStatus.Sealed = true;
                fldStatus.AllowDeletion = false;
                fldStatus.ReadOnlyField = true;
                fldStatus.Update();
            }

            // add Work field
            if (!FieldExistsInList(list, "Work"))
            {
                string fldWIntName = list.Fields.Add("Work", SPFieldType.Number, false);
                SPFieldNumber fldW = list.Fields.GetFieldByInternalName(fldWIntName) as SPFieldNumber;
                fldW.Title = "Work";
                fldW.DisplayFormat = SPNumberFormatTypes.TwoDecimals;
                fldW.Description = "Enter the estimated work (in hours) for this item.";
                fldW.Update();
            }

            // add percent complete field
            if (!FieldExistsInList(list, "PercentComplete"))
            {
                string fldPCIntName = list.Fields.Add("PercentComplete", SPFieldType.Number, false);
                SPFieldNumber fldPC = list.Fields.GetFieldByInternalName(fldPCIntName) as SPFieldNumber;
                fldPC.Title = "% Complete";
                fldPC.ShowAsPercentage = true;
                fldPC.DisplayFormat = SPNumberFormatTypes.NoDecimal;
                fldPC.MinimumValue = 0;
                fldPC.MaximumValue = 1;
                fldPC.Sealed = false;
                fldPC.AllowDeletion = false;
                fldPC.Update();
            }

            // add body field
            if (!FieldExistsInList(list, "Body"))
            {
                string fldBIntName = list.Fields.Add("Body", SPFieldType.Note, false);
                SPFieldMultiLineText fldB = list.Fields.GetFieldByInternalName(fldBIntName) as SPFieldMultiLineText;
                fldB.Title = "Description";
                fldB.RichText = true;
                fldB.Sealed = false;
                fldB.AllowDeletion = false;
                fldB.Update();
            }

            // add commentcount field
            if (!FieldExistsInList(list, "CommentCount"))
            {
                string fldCCIntName = list.Fields.Add("CommentCount", SPFieldType.Number, false);
                SPFieldNumber fldCC = list.Fields.GetFieldByInternalName(fldCCIntName) as SPFieldNumber;
                fldCC.MinimumValue = 0;
                fldCC.Sealed = false;
                fldCC.AllowDeletion = false;
                fldCC.Hidden = true;
                fldCC.Update();
            }

            // add complete field
            if (!FieldExistsInList(list, "Complete"))
            {
                string fldCompleteIntName = list.Fields.Add("Complete", SPFieldType.Boolean, false);
                SPFieldBoolean fldComplete = list.Fields.GetFieldByInternalName(fldCompleteIntName) as SPFieldBoolean;
                fldComplete.Sealed = false;
                fldComplete.ShowInEditForm = true;
                fldComplete.ShowInNewForm = false;
                fldComplete.AllowDeletion = false;
                fldComplete.DefaultValue = "0";
                fldComplete.Update();
            }

            // add DaysOverdue field
            if (!FieldExistsInList(list, "DaysOverdue"))
            {
                string fldDOIntName = list.Fields.Add("DaysOverdue", SPFieldType.Calculated, false);
                SPFieldCalculated fldDO = list.Fields.GetFieldByInternalName(fldDOIntName) as SPFieldCalculated;
                fldDO.OutputType = SPFieldType.Number;
                fldDO.Title = "Days Overdue";
                fldDO.Sealed = false;
                fldDO.ShowInEditForm = false;
                fldDO.AllowDeletion = false;
                fldDO.Formula = "=IF([Due Date]<>\"\",IF(Status<>\"Completed\",IF([Due Date]<Today,Today-[Due Date],0),0),0)";
                fldDO.Update();
            }

            // add ScheduleStatus field
            if (!FieldExistsInList(list, "ScheduleStatus"))
            {
                string fldSSIntName = list.Fields.Add("ScheduleStatus", SPFieldType.Calculated, false);
                SPFieldCalculated fldSS = list.Fields.GetFieldByInternalName(fldSSIntName) as SPFieldCalculated;
                fldSS.Title = "Schedule Status";
                fldSS.OutputType = SPFieldType.Text;
                fldSS.Sealed = false;
                fldSS.ShowInEditForm = false;
                fldSS.ShowInNewForm = false;
                fldSS.AllowDeletion = false;
                fldSS.Formula = "=IF(Status=\"Completed\",\"checkmark.GIF\",IF([Days Overdue]>=30,\"RED.GIF\",IF([Days Overdue]>0,\"YELLOW.GIF\",\"GREEN.GIF\")))";
                fldSS.Update();
            }

            // add TodayYear field
            if (!FieldExistsInList(list, "TodayYear"))
            {
                string fldTYIntName = list.Fields.Add("TodayYear", SPFieldType.Calculated, false);
                SPFieldCalculated fldTY = list.Fields.GetFieldByInternalName(fldTYIntName) as SPFieldCalculated;
                fldTY.Title = "Today Year";
                fldTY.OutputType = SPFieldType.Number;
                fldTY.Sealed = false;
                fldTY.ShowInEditForm = false;
                fldTY.ShowInNewForm = false;
                fldTY.ShowInDisplayForm = false;
                fldTY.AllowDeletion = false;
                fldTY.Formula = "=YEAR(Today)";
                fldTY.Update();
            }

            // add TodayWeek field
            if (!FieldExistsInList(list, "TodayWeek"))
            {
                string fldTWIntName = list.Fields.Add("TodayWeek", SPFieldType.Calculated, false);
                SPFieldCalculated fldTW = list.Fields.GetFieldByInternalName(fldTWIntName) as SPFieldCalculated;
                fldTW.Title = "Today Week";
                fldTW.OutputType = SPFieldType.Number;
                fldTW.Sealed = false;
                fldTW.ShowInEditForm = false;
                fldTW.ShowInNewForm = false;
                fldTW.ShowInDisplayForm = false;
                fldTW.AllowDeletion = false;
                fldTW.Formula = "=IF(Today<>\"\",INT((Today-DATE(YEAR(Today),1,1)+(TEXT(WEEKDAY(DATE(YEAR(Today),1,1)),\"d\")))/7)+1,0)";
                fldTW.Update();
            }

            // add Year field
            if (!FieldExistsInList(list, "Year"))
            {
                string fldYIntName = list.Fields.Add("Year", SPFieldType.Calculated, false);
                SPFieldCalculated fldY = list.Fields.GetFieldByInternalName(fldYIntName) as SPFieldCalculated;
                fldY.Title = "Year";
                fldY.OutputType = SPFieldType.Number;
                fldY.Sealed = false;
                fldY.ShowInEditForm = false;
                fldY.ShowInNewForm = false;
                fldY.ShowInDisplayForm = false;
                fldY.AllowDeletion = false;
                fldY.Formula = "=IF([Due Date]<>\"\",YEAR([Due Date]))";
                fldY.Update();
            }

            // add Week field
            if (!FieldExistsInList(list, "Week"))
            {
                string fldWIntName = list.Fields.Add("Week", SPFieldType.Calculated, false);
                SPFieldCalculated fldW = list.Fields.GetFieldByInternalName(fldWIntName) as SPFieldCalculated;
                fldW.Title = "Week";
                fldW.OutputType = SPFieldType.Number;
                fldW.Sealed = false;
                fldW.ShowInEditForm = false;
                fldW.ShowInNewForm = false;
                fldW.ShowInDisplayForm = false;
                fldW.AllowDeletion = false;
                fldW.Formula = "=IF([Due Date]<>\"\",INT(([Due Date]-DATE(YEAR([Due Date]),1,1)+(TEXT(WEEKDAY(DATE(YEAR([Due Date]),1,1)),\"d\")))/7)+1,0)";
                fldW.Update();
            }

            // add Due field
            if (!FieldExistsInList(list, "Due"))
            {
                string fldDIntName = list.Fields.Add("Due", SPFieldType.Calculated, false);
                SPFieldCalculated fldD = list.Fields.GetFieldByInternalName(fldDIntName) as SPFieldCalculated;
                fldD.Title = "Due";
                fldD.OutputType = SPFieldType.Text;
                fldD.Sealed = false;
                fldD.ShowInEditForm = false;
                fldD.ShowInNewForm = false;
                fldD.AllowDeletion = false;
                fldD.Formula = "=IF([Status]=\"Completed\",\"NA\",IF([Due Date]=\"\",\"No Due Date\",IF([Due Date]<Today,\"(1) Overdue\",IF([Due Date]=Today,\"(2) Due Today\",IF([Due Date]=Today+1,\"(3) Due Tomorrow\",IF(Week=[Today Week],IF(Year=[Today Year],\"(4) Due This Week\",\"(7) Future\"),IF(Week=[Today Week]+1,IF(Year=[Today Year],\"(5) Due Next Week\",\"(7) Future\"),IF(MONTH([Due Date])=MONTH(Today),IF(Year=[Today Year],\"(6) Due This Month\",\"(7) Future\"),\"(7) Future\"))))))))";
                fldD.Update();
            }

            // add Commenters field
            if (!FieldExistsInList(list, "Commenters"))
            {
                string fldCIntName = list.Fields.Add("Commenters", SPFieldType.Note, false);
                SPFieldMultiLineText fldC = list.Fields.GetFieldByInternalName(fldCIntName) as SPFieldMultiLineText;
                fldC.Title = "Commenters";
                fldC.Hidden = true;
                fldC.Sealed = false;
                fldC.AllowDeletion = false;
                fldC.Update();
            }

            // add CommentersRead field
            if (!FieldExistsInList(list, "CommentersRead"))
            {
                string fldCRIntName = list.Fields.Add("CommentersRead", SPFieldType.Note, false);
                SPFieldMultiLineText fldCR = list.Fields.GetFieldByInternalName(fldCRIntName) as SPFieldMultiLineText;
                fldCR.Title = "Commenters Read";
                fldCR.Hidden = true;
                fldCR.Sealed = false;
                fldCR.AllowDeletion = false;
                fldCR.Update();
            }

            // remove Today field
            if (FieldExistsInList(list, "Today"))
            {
                try
                {
                    list.Fields.Delete("Today");
                }
                catch (Exception e) { }
            }

            list.Update();
        }

        private void AddEventHandlers()
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists[new Guid(Request["List"])];
            web.AllowUnsafeUpdates = true;
            string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
            string className = "EPMLiveCore.StatusingEvent";

            SPEventReceiverDefinitionCollection eventColl = list.EventReceivers;
            List<SPEventReceiverDefinition> listsToDelete = GetListEvents(list, assemblyName, className, new List<SPEventReceiverType> { SPEventReceiverType.ItemAdding, SPEventReceiverType.ItemUpdating, SPEventReceiverType.ItemDeleted });

            if (listsToDelete.Count > 0)
            {
                foreach (SPEventReceiverDefinition eventDel in listsToDelete)
                {
                    eventDel.Delete();
                }
            }

            list.EventReceivers.Add(SPEventReceiverType.ItemAdding, assemblyName, className);
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdating, assemblyName, className);
            list.EventReceivers.Add(SPEventReceiverType.ItemDeleted, assemblyName, className);

            List<SPEventReceiverDefinition> newEvts = GetListEvents(list, assemblyName, className, new List<SPEventReceiverType> { SPEventReceiverType.ItemAdding, SPEventReceiverType.ItemUpdating, SPEventReceiverType.ItemDeleted });
            foreach (SPEventReceiverDefinition evt in newEvts)
            {
                evt.SequenceNumber = 11000;
                evt.Update();
            }

            list.Update();
        }

        private void FixLookupFields()
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists[new Guid(Request["List"])];
            web.AllowUnsafeUpdates = true;

            for (int i = 0; i < list.Fields.Count; i++)
            {
                if (!(list.Fields[i] is SPFieldLookup))
                {
                    continue;
                }

                bool originalListExists = false;
                bool listEqualToInternalNameExists = false;
                SPList tempLookupList = null;

                try
                {
                    string lookupListGuidString = (list.Fields[i] as SPFieldLookup).LookupList;
                    if (!string.IsNullOrEmpty(lookupListGuidString))
                    {
                        tempLookupList = web.Lists[new Guid(lookupListGuidString)];
                    }
                }
                catch
                { }

                originalListExists = (tempLookupList != null);

                // if can't find list by guid, find it by field internal name
                if (!originalListExists)
                {
                    tempLookupList = web.Lists.TryGetList(list.Fields[i].InternalName);
                    listEqualToInternalNameExists = (tempLookupList != null);
                    if (!listEqualToInternalNameExists && list.Fields[i].InternalName.Equals("Project", StringComparison.CurrentCultureIgnoreCase))
                    {
                        tempLookupList = web.Lists.TryGetList("Project Center");
                    }

                    if (tempLookupList != null)
                    {
                        UpdateLookupReferences((list.Fields[i] as SPFieldLookup), web, tempLookupList);
                    }
                }

            }

        }

        private void EnableWorkengineListFeatures(SPList list)
        {
            AddGridGanttToViews(list);
            AddFields(list);
            AddEventHandlers();
            FixLookupFields();
            AddRemoveMyWorkReportingEvents("ADD");
        }

        private void AddRemoveMyWorkReportingEvents(string operation)
        {
            var dataElement = new XElement("Data");

            const string assembly =
                "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";

            const string className = "EPMLiveReportsAdmin.MyWorkListEvents";

            var spEventReceiverTypes = new[]
                                               {
                                                   SPEventReceiverType.ItemAdded, SPEventReceiverType.ItemUpdated,
                                                   SPEventReceiverType.ItemDeleting
                                               };

            AddEventReceiverElement(operation, className, assembly, spEventReceiverTypes, new Guid(Request["List"]),
                                    ref dataElement);

            WorkEngineAPI.EventReceiverManager(new XElement("EventReceiverManager", dataElement).ToString(), Web);
        }

        private void AddEventReceiverElement(string operation, string className, string assembly,
                                             IEnumerable<SPEventReceiverType> spEventReceiverTypes, Guid listId,
                                             ref XElement dataElement)
        {
            foreach (SPEventReceiverType spEventReceiverType in spEventReceiverTypes)
            {
                dataElement.Add(new XElement("EventReceiver", new XAttribute("SiteId", Web.Site.ID),
                                             new XAttribute("WebId", Web.ID), new XAttribute("ListId", listId),
                                             new XAttribute("Type", (int)spEventReceiverType),
                                             new XAttribute("Operation", operation),
                                             new XAttribute("Assembly", assembly),
                                             new XAttribute("ClassName", className),
                                             new XAttribute("DataId", listId)));
            }
        }

        private void RemoveWorkengineListFeatures()
        {
            RemoveEventHandlers();
            AddRemoveMyWorkReportingEvents("REMOVE");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists[new Guid(Request["List"])];
            var gSettings = new GridGanttSettings(list);

            gSettings.StartDate = ddlStartDate.SelectedValue;
            gSettings.DueDate = ddlDueDate.SelectedValue;
            gSettings.Progress = ddlProgressBar.SelectedValue;
            gSettings.WBS = ddlWBS.SelectedValue;
            gSettings.Milestone = ddlMilestone.SelectedValue;
            gSettings.Executive = chkExecutive.Checked;
            gSettings.Information = ddlInformation.SelectedValue;
            gSettings.ItemLink = ddlItemLink.SelectedValue;
            gSettings.RollupLists = txtRollupLists.Text.Replace(",", "|").Replace("\r\n", ",");
            gSettings.RollupSites = txtRollupSites.Text.Replace("\r\n", ",");
            gSettings.ShowViewToolbar = chkShowViewToolbar.Checked;
            gSettings.HideNewButton = chkHideNewButton.Checked;
            gSettings.Performance = chkPerformance.Checked;
            gSettings.AllowEdit = chkAllowEdit.Checked;
            gSettings.EditDefault = chkEditDefault.Checked;
            gSettings.ShowInsert = chkShowInsert.Checked;
            gSettings.DisableNewItemMod = chkDisableNewRollup.Checked;
            gSettings.UseNewMenu = chkUseNewMenu.Checked;
            gSettings.NewMenuName = txtNewMenuName.Text;
            gSettings.UsePopup = chkUsePopup.Checked;
            gSettings.EnableRequests = chkEnableRequests.Checked;
            gSettings.EnableAutoCreation = chkAutoCreate.Checked;
            gSettings.AutoCreationTemplateId = ddlAutoCreateTemplate.SelectedValue;
            gSettings.WorkspaceParentSiteLookup = ddlParentSiteLookup.SelectedValue;
            gSettings.ListIcon = hdnListIcon.Value;
            gSettings.EnableWorkList = chkWorkListFeat.Checked;
            gSettings.SendEmails = chkEmails.Checked;
            gSettings.DeleteRequest = chkDeleteRequest.Checked;
            gSettings.RequestList = txtRequestList.Text;
            gSettings.UseParent = chkUseParent.Checked;
            gSettings.Search = chkSearch.Checked;
            gSettings.LockSearch = chkLockSearch.Checked;
            gSettings.AssociatedItems = chkAssociatedItems.Checked;
            gSettings.DisplayFormRedirect = chkDisplayRedirect.Checked;
            gSettings.EnableResourcePlan = chkResTools.Checked;
            gSettings.BuildTeam = chkEnableTeam.Checked;
            gSettings.BuildTeamSecurity = chkEnableTeamSecurity.Checked;
            gSettings.BuildTeamPermissions = GetGroupsPermissionsAssignment();
            gSettings.EnableContentReporting = chkContentReporting.Checked;
            gSettings.SaveSettings(list);

            //if ((uint)list.BaseTemplate == 10115 || (uint)list.BaseTemplate == 10701 || (uint)list.BaseTemplate == 10702)
            {
                if (chkEmails.Checked)
                    API.APIEmail.InstallAssignedToEvent(list);
                else
                    API.APIEmail.UnInstallAssignedToEvent(list);
                //list.EnableAssignToEmail = chkEmails.Checked;
                //list.Update();
                //CoreFunctions.setListSetting(list, "AssignedToEmail", chkEmails.Checked.ToString());
            }

            if (gSettings.BuildTeamSecurity)
            {
                string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                string className = "EPMLiveCore.ItemSecurityEventReceiver";

                List<SPEventReceiverDefinition> evts = CoreFunctions.GetListEvents(list,
                                                                     assemblyName,
                                                                     className,
                                                                     new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded,
                                                                                                     SPEventReceiverType.ItemUpdated,
                                                                                                     SPEventReceiverType.ItemDeleting});
                foreach (SPEventReceiverDefinition evt in evts)
                {
                    evt.Delete();
                }

                list.EventReceivers.Add(SPEventReceiverType.ItemAdded, assemblyName, className);
                list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, assemblyName, className);
                list.EventReceivers.Add(SPEventReceiverType.ItemDeleting, assemblyName, className);

                List<SPEventReceiverDefinition> newEvts = CoreFunctions.GetListEvents(list,
                                                                   assemblyName,
                                                                   className,
                                                                   new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded,
                                                                                                     SPEventReceiverType.ItemUpdated,
                                                                                                     SPEventReceiverType.ItemDeleting});
                foreach (SPEventReceiverDefinition evt in newEvts)
                {
                    evt.SequenceNumber = 11000;
                    evt.Update();
                }

                list.Update();
            }
            else
            {
                bool hasSecFld = false;
                string lookups = gSettings.Lookups;
                if (!string.IsNullOrEmpty(lookups))
                {
                    string[] settings = lookups.Split('|');
                    foreach (string s in settings)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            string[] vals = s.Split('^');

                            bool isSec = false;
                            try
                            {
                                isSec = bool.Parse(vals[4]);
                            }
                            catch { }
                            if (isSec)
                            {
                                hasSecFld = true;
                                break;
                            }
                        }
                    }
                }

                if (!hasSecFld)
                {
                    string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                    string className = "EPMLiveCore.ItemSecurityEventReceiver";

                    List<SPEventReceiverDefinition> evts = CoreFunctions.GetListEvents(list,
                                                                         assemblyName,
                                                                         className,
                                                                         new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded,
                                                                                                     SPEventReceiverType.ItemUpdated,
                                                                                                     SPEventReceiverType.ItemDeleting});
                    foreach (SPEventReceiverDefinition evt in evts)
                    {
                        evt.Delete();
                    }
                    list.Update();
                }
            }



            if (chkEnableTeam.Checked && !chkEnableTeamSecurity.Checked)
            {
                API.ListCommands.EnableTeamFeatures(list);

                string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                string className = "EPMLiveCore.ItemEnableTeamEvent";

                List<SPEventReceiverDefinition> evts = CoreFunctions.GetListEvents(list,
                                                                     assemblyName,
                                                                     className,
                                                                     new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded });
                foreach (SPEventReceiverDefinition evt in evts)
                {
                    evt.Delete();
                }

                SPEventReceiverDefinition evtAdded = list.EventReceivers.Add();
                evtAdded.Type = SPEventReceiverType.ItemAdded;
                evtAdded.Assembly = assemblyName;
                evtAdded.Class = className;
                evtAdded.SequenceNumber = 11000;
                evtAdded.Update();
                list.Update();
            }
            else
            {
                string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                string className = "EPMLiveCore.ItemEnableTeamEvent";

                List<SPEventReceiverDefinition> evts = CoreFunctions.GetListEvents(list,
                                                                     assemblyName,
                                                                     className,
                                                                     new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded });
                foreach (SPEventReceiverDefinition evt in evts)
                {
                    evt.Delete();
                }

                list.Update();
            }

            // attached workspace auto creation event
            if (chkAutoCreate.Checked)
            {
                string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                string className = "EPMLiveCore.ItemWorkspaceEventReceiver";

                List<SPEventReceiverDefinition> evts = CoreFunctions.GetListEvents(list,
                                                                     assemblyName,
                                                                     className,
                                                                     new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded });
                foreach (SPEventReceiverDefinition evt in evts)
                {
                    evt.Delete();
                }

                SPEventReceiverDefinition evtAdded = list.EventReceivers.Add();
                evtAdded.Type = SPEventReceiverType.ItemAdded;
                evtAdded.Assembly = assemblyName;
                evtAdded.Class = className;
                evtAdded.Update();
                list.Update();
            }
            else
            {
                string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                string className = "EPMLiveCore.ItemWorkspaceEventReceiver";

                List<SPEventReceiverDefinition> evts = CoreFunctions.GetListEvents(list,
                                                                     assemblyName,
                                                                     className,
                                                                     new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded });
                foreach (SPEventReceiverDefinition evt in evts)
                {
                    evt.Delete();
                }

                list.Update();
            }

            if (chkTimesheet.Checked)
                API.ListCommands.EnableTimesheets(list, web);
            else
                API.ListCommands.DisableTimesheets(list, web);


            if (chkWorkListFeat.Checked)
            {
                EnableWorkengineListFeatures(list);
            }
            else
            {
                RemoveWorkengineListFeatures();
            }

            if (ifsEnableReporting.Visible && cbEnableReporting.Checked)
            {
                ReportBiz reportBiz = new ReportBiz(SPContext.Current.Site.ID);
                if (reportBiz.SiteExists())
                {
                    Collection<string> mappedLists = reportBiz.GetMappedListsIds();
                    if (!mappedLists.Contains(list.ID.ToString().ToLower()))
                    {
                        reportBiz.CreateListBiz(list.ID);

                        try
                        {
                            //FOREIGN IMPLEMENTATION -- START
                            EPMData DAO = new EPMData(SPContext.Current.Site.ID);
                            reportBiz.UpdateForeignKeys(DAO);
                            DAO.Dispose();
                            // -- END
                        }
                        catch (Exception ex)
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                if (!EventLog.SourceExists("EPMLive Reporting - UpdateForeignKeys"))
                                    EventLog.CreateEventSource("EPMLive Reporting - UpdateForeignKeys", "EPM Live");

                                EventLog myLog = new EventLog("EPM Live", ".", "EPMLive Reporting - UpdateForeignKeys");
                                myLog.MaximumKilobytes = 32768;
                                myLog.WriteEntry(ex.Message + ex.StackTrace, EventLogEntryType.Error, 4001);
                            });
                        }
                    }
                }
            }
            else if (ifsEnableReporting.Visible && !cbEnableReporting.Checked)
            {

                var reportBiz = new ReportBiz(SPContext.Current.Site.ID);
                Guid listId = new Guid(Request["List"]);
                EPMData _DAO = new EPMData(SPContext.Current.Site.ID);
                _DAO.Command = "SELECT TableName FROM RPTList WHERE RPTListID=@RPTListID";
                _DAO.AddParam("@RPTListID", Request["List"]);
                string sTableName = string.Empty;
                try
                {
                    sTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection).ToString();
                }
                catch { }
                DataTable refTables = new DataTable();

                if (!string.IsNullOrEmpty(sTableName))
                {
                    refTables = reportBiz.GetReferencingTables(_DAO, sTableName);
                    if (refTables.Rows.Count == 0)
                    {
                        reportBiz.GetListBiz(new Guid(Request["List"])).Delete();
                    }
                    else
                    {
                        //SPUtility.Redirect("epmlive/ListMappings.aspx?delete=true&id=" + param + "&name=" + sTableName, SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                        ShowAlert();
                    }
                }
            }

            Infrastructure.CacheStore.Current.RemoveCategory("GridSettings-" + list.ID);

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("listedit.aspx?List=" + Request["List"], Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void AddReportEvent(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists[new Guid(Request["List"])];
            string sAssembly = "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
            string sClass = "EPMLiveReportsAdmin.ListEvents";
            // remove existing event receivers first
            List<SPEventReceiverDefinition> evts = GetListEvents(list,
                                                                 sAssembly,
                                                                 sClass,
                                                                 new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded, 
                                                                                                                             SPEventReceiverType.ItemUpdated, 
                                                                                                                             SPEventReceiverType.ItemDeleting });

            foreach (SPEventReceiverDefinition ev in evts)
            {
                ev.Delete();
            }

            // then add event receivers
            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, sAssembly, sClass);
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, sAssembly, sClass);
            list.EventReceivers.Add(SPEventReceiverType.ItemDeleting, sAssembly, sClass);

            List<SPEventReceiverDefinition> newEvts = GetListEvents(list,
                                                                sAssembly,
                                                                sClass,
                                                                new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded, 
                                                                                                                             SPEventReceiverType.ItemUpdated, 
                                                                                                                             SPEventReceiverType.ItemDeleting });
            foreach (SPEventReceiverDefinition ev in newEvts)
            {
                ev.SequenceNumber = 11000;
                ev.Update();
            }

            list.Update();
        }

        void ShowAlert()
        {
            var reportBiz = new ReportBiz(SPContext.Current.Site.ID);
            Guid listId = new Guid(Request.QueryString["List"]);
            EPMData _DAO = new EPMData(SPContext.Current.Site.ID);
            _DAO.Command = "SELECT TableName FROM RPTList WHERE RPTListID=@RPTListID";
            _DAO.AddParam("@RPTListID", listId);

            string sTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection).ToString();
            DataTable refTables = reportBiz.GetReferencingTables(_DAO, sTableName);
            string sLists = GetRefLists(refTables, _DAO);

            string sAlert = "<script language='javascript' type='text/javascript'> alert('Before this list can be deleted the following lists must be deleted first: " + sLists + "); </script>";
            ClientScript.RegisterClientScriptBlock(GetType(), "EPMLiveWarning", sAlert);
        }

        private string GetRefLists(DataTable refTables, EPMData dao)
        {
            string sRefLists = string.Empty;
            foreach (DataRow table in refTables.Rows)
            {
                if (!table["oObjName"].ToString().ToLower().Contains("snapshot"))
                {
                    sRefLists = sRefLists + dao.GetListName(table["oObjName"].ToString()) + ",";
                }
            }

            sRefLists = sRefLists.Remove(sRefLists.LastIndexOf(","));
            return sRefLists;
        }

        private void EnableSiteFeature()
        {

        }

        public void ClearLookupReferences(SPFieldLookup lookupField)
        {
            lookupField.SchemaXml = ReplaceXmlAttributeValue(lookupField.SchemaXml, "List", "");
            lookupField.SchemaXml = ReplaceXmlAttributeValue(lookupField.SchemaXml, "WebId", "");
            lookupField.Update(true);
        }

        public void UpdateLookupReferences(SPFieldLookup lookupField, SPWeb web, SPList list)
        {
            if (string.IsNullOrEmpty(lookupField.LookupList))
            {
                lookupField.LookupWebId = web.ID;
                lookupField.LookupList = list.ID.ToString();
            }
            else
            {
                lookupField.SchemaXml = ReplaceXmlAttributeValue(lookupField.SchemaXml, "List", list.ID.ToString());
                lookupField.SchemaXml = ReplaceXmlAttributeValue(lookupField.SchemaXml, "WebId", web.ID.ToString());
            }

            lookupField.Update(true);
        }

        public string ReplaceXmlAttributeValue(string xml, string attributeName, string value)
        {
            string retVal = string.Empty;
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentNullException("xml");
            }

            int indexOfAttributeName = xml.IndexOf(attributeName, StringComparison.CurrentCultureIgnoreCase);
            if (!indexOfAttributeName.Equals(-1))
            {
                int indexOfAttibuteValueBegin = xml.IndexOf('"', indexOfAttributeName);
                int indexOfAttributeValueEnd = xml.IndexOf('"', indexOfAttibuteValueBegin + 1);
                retVal = xml.Substring(0, indexOfAttibuteValueBegin + 1) + value + xml.Substring(indexOfAttributeValueEnd);
            }

            if (string.IsNullOrEmpty(retVal))
            {
                retVal = xml;
            }

            return retVal;
        }

        public bool FieldExistsInList(SPList list, string fldInternalName)
        {
            SPField testField = null;
            try
            {
                testField = list.Fields.GetFieldByInternalName(fldInternalName);
            }
            catch
            {
                testField = null;
            }
            return (testField != null);
        }
    }
}
