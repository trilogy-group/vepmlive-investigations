using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Xml;
using System.Collections.Generic;
using Microsoft.Web.CommandUI;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class BuildTeam : LayoutsPageBase
    {
        protected string sLayoutParam = "";
        protected string sResPool = "";
        protected string bCanAddResource = "false";
        protected string sNewResUrl = "";
        protected string bCanEditTeam = "false";
        protected string bCanAccessResourcePool = "false";
        protected string sUserInfoList = "";
        protected string sClose = "";

        protected string sDisable = "";

        protected string sDefaultGroup = "";

        protected string sResGrid = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            SPWeb web = SPContext.Current.Web;
            string resUrl = "";
            web.Site.CatchAccessDeniedException = false;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb aweb = site.OpenWeb(web.ID))
                    {
                        resUrl = CoreFunctions.getConfigSetting(aweb, "EPMLiveResourceURL", true, false);
                    }
                }
            });

            //bool canManageAGroup = false;
            SPListItem oLi = null;
            SPList oList = null;
            bool bUseTeam = false;
            try
            {
                oList = web.Lists[new Guid(Request["listid"])];
                oLi = oList.GetItemById(int.Parse(Request["id"]));
                GridGanttSettings gSettings = new GridGanttSettings(oList);
                bUseTeam = gSettings.BuildTeam;
            }
            catch { }

            if (bUseTeam)
            {

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite tSite = new SPSite(web.Site.ID))
                    {
                        using (SPWeb tWeb = tSite.OpenWeb(web.ID))
                        {
                            SPList tList = tWeb.Lists[new Guid(Request["listid"])];
                            SPListItem tLi = tList.GetItemById(int.Parse(Request["id"]));
                            web.Site.CatchAccessDeniedException = false;

                            foreach (SPRoleAssignment assn in tLi.RoleAssignments)
                            {
                                if (assn.Member.GetType() == typeof(Microsoft.SharePoint.SPGroup))
                                {
                                    try
                                    {
                                        SPGroup group = web.SiteGroups.GetByID(assn.Member.ID);

                                        if (group.CanCurrentUserEditMembership)
                                        {
                                            string[] sG = group.Name.Split(' ');
                                            if (sG[sG.Length - 1] == "Member")
                                                sDefaultGroup = group.ID.ToString();

                                            bCanEditTeam = "true";
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                });
            }
            else
            {

                foreach (SPGroup g in web.Groups)
                {
                    string[] sG = g.Name.Split(' ');
                    if (sG[sG.Length - 1] == "Member")
                        sDefaultGroup = g.ID.ToString();

                    if (g.CanCurrentUserEditMembership)
                    {
                        bCanEditTeam = "true";
                    }
                }
            }





            if (web.Features[new Guid("84520a2b-8e2b-4ada-8f48-60b138923d01")] == null && !bUseTeam)
            {
                sDisable = "_spBodyOnLoadFunctionNames.push(\"ShowDisable\");";
                SPList teamlist = web.Lists["Team"];
                //if(web.DoesUserHavePermissions(SPBasePermissions.ManagePermissions))
                //{
                //    bCanEditTeam = "true";
                //}
            }
            else
            {

                try
                {
                    using (SPSite rsite = new SPSite(resUrl))
                    {
                        using (SPWeb rweb = rsite.OpenWeb())
                        {
                            SPList list = rweb.Lists["Resources"];
                            //DataTable dtTemp = list.Items.GetDataTable();
                            bCanAccessResourcePool = "true";
                            if (list.DoesUserHavePermissions(SPBasePermissions.AddListItems))
                            {
                                bCanAddResource = "true";
                                sNewResUrl = list.Forms[PAGETYPE.PAGE_NEWFORM].ServerRelativeUrl;
                            }
                        }
                    }
                }
                catch { }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<Grid/>");




                if (bUseTeam)
                {
                    try
                    {

                        if (oLi.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                        {
                            bCanEditTeam = "true";
                        }

                        XmlAttribute attr = doc.CreateAttribute("ListId");
                        attr.Value = Request["listid"];
                        doc.FirstChild.Attributes.Append(attr);

                        attr = doc.CreateAttribute("ItemId");
                        attr.Value = Request["id"];
                        doc.FirstChild.Attributes.Append(attr);

                    }
                    catch
                    {

                    }
                }
                else
                {
                    SPList teamlist = web.Lists.TryGetList("Team");

                    if (teamlist == null)
                    {
                        web.AllowUnsafeUpdates = true;
                        web.Lists.Add("Team", "Use this list to manage your project team", SPListTemplateType.GenericList);
                        teamlist = web.Lists.TryGetList("Team");
                        try
                        {
                            teamlist.Fields.Add("ResID", SPFieldType.Number, false);
                            teamlist.Update();
                        }
                        catch { }
                    }
                }

                sLayoutParam = HttpUtility.HtmlEncode(doc.OuterXml);

                if (bCanEditTeam == "true")
                {
                    sResPool = Properties.Resources.txtBuildTeamResPool.Replace("#LayoutParam#", sLayoutParam).Replace("#DataParam#", sLayoutParam);
                    sResGrid = @"TreeGrid(   { 
                    Layout:{ Url:""../../_vti_bin/WorkEngine.asmx"", Method:""Soap"",Function:""Execute"",Namespace:""workengine.com"",Param:{Function:""GetResourceGridLayout"",Dataxml:""" + sLayoutParam + @""" } } ,
                    Data:{ Url:""../../_vti_bin/WorkEngine.asmx"", Method:""Soap"",Function:""Execute"",Namespace:""workengine.com"",Param:{Function:""GetResourceGridData"",Dataxml:""" + sLayoutParam + @""" } }, 
                    Debug:"""",SuppressMessage:""3""
                    }, 
	                ""divResPool"" );";
                }

            }

            sUserInfoList = web.SiteUserInfoList.ID.ToString().ToUpper();

            if (Request["isDlg"] == "1")
            {
                sClose = "SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', SP.UI.DialogResult.OK, '');";
            }
            else
            {
                if (String.IsNullOrEmpty(Request["Source"]))
                {
                    sClose = "location.href='" + ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "'";
                }
                else
                {
                    sClose = "location.href='" + Request["Source"] + "'";
                }
            }


        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            this.AddRibbonTab();

            AddTabEvents();
        }

        private void AddRibbonTab()
        {
            // Gets the current instance of the ribbon on the page.
            SPRibbon ribbon = SPRibbon.GetCurrent(this.Page);

            //Prepares an XmlDocument object used to load the ribbon
            XmlDocument ribbonExtensions = new XmlDocument();

            //WorkPlanner Tab
            ribbonExtensions.LoadXml(Properties.Resources.txtBuildTeamTab);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.Tabs._children");

            //Load the custom templates and register the ribbon.
            ribbonExtensions.LoadXml(Properties.Resources.txtBuildTeamRibbonTemplate);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.Templates._children");

            ribbon.Minimized = false;
            ribbon.CommandUIVisible = true;
            const string initialTabId = "Ribbon.BuildTeam";

            if (!ribbon.IsTabAvailable(initialTabId))
                ribbon.MakeTabAvailable(initialTabId);

            ribbon.InitialTabId = initialTabId;

            if (bCanEditTeam != "true")
            {
                if (sDisable != "")
                    ribbon.TrimById("Ribbon.BuildTeam.ResourceGroup");

                ribbon.TrimById("Ribbon.BuildTeam.StandardGroup.SaveButton");
                ribbon.TrimById("Ribbon.BuildTeam.StandardGroup.SaveCloseButton");
            }
            else if (sDisable != "")
            {
                ribbon.TrimById("Ribbon.BuildTeam.ResourceGroup");
                ribbon.TrimById("Ribbon.BuildTeam.TeamGroup.AddToTeam");
                ribbon.TrimById("Ribbon.BuildTeam.TeamGroup.RemoveFromTeam");
            }

        }

        private void AddTabEvents()
        {
            var commands = new List<IRibbonCommand>();

            // register the command at the ribbon. Include the callback to the server     // to generate the xml
            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.SaveButton", "SaveTeam();", "bCanEditTeam"));
            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.SaveCloseButton", "SaveAndClose();", "bCanEditTeam"));
            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.CloseButton", "Close();", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.ShowPool", "ShowPool();", "bCanEditTeam"));
            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.AddResource", "AddResourcePool();", "CanAddResource()"));
            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.AddResColumns", "AddResColumns();", "isResPoolShowing()"));
            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.AddTeamColumns", "AddTeamColumns();", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.Assignments", "Assignments();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.DisplayReports", "", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.AddToTeam", "AddResource()", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.BuildTeam.RemoveFromTeam", "RemoveResource()", "true"));

            //Register initialize function
            var manager = new SPRibbonScriptManager();
            var methodInfo = typeof(SPRibbonScriptManager).GetMethod(
            "RegisterInitializeFunction",
            BindingFlags.Instance | BindingFlags.NonPublic);
            methodInfo.Invoke(manager, new object[] { 
        Page, "InitPageComponent", 
        "/_layouts/epmlive/BuildTeamPageComponent.js", false, 
        "BuildTeamPageComponent.PageComponent.initialize()" });

            // Register ribbon scripts
            manager.RegisterGetCommandsFunction(Page, "getGlobalCommands", commands);
            manager.RegisterCommandEnabledFunction(Page, "commandEnabled", commands);
            manager.RegisterHandleCommandFunction(Page, "handleCommand", commands);
        }
    }
}
