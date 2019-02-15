using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public class EditIn : WebControl
    {
        private const string SiteFeaturesGuid = "91f0c887-2db2-44b2-b15c-47c69809c767";
        private const string LivePlannerGuid = "e6df7606-1541-4bf1-a810-e8e9b11819e3";
        private const string ProjectSchedulesGuid = "ebc3f0dc-533c-4c72-8773-2aaf3eac1055";
        private string sListName;

        protected override void OnLoad(EventArgs e)
        {
            //EnsureChildControls();
            //base.OnLoad(e);

            try
            {
                Control parent = Parent;
                while (parent != null)
                {
                    if (parent is Microsoft.SharePoint.WebControls.ViewToolBar)
                    {
                        sListName = ((Microsoft.SharePoint.WebControls.ViewToolBar)parent).RenderContext.List.Title;
                    }
                    parent = parent.Parent;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Except Suppressed {0}", ex);
            }

        }

        protected override void CreateChildControls()
        {
            var currentWeb = SPContext.Current.Web;
            var hasProject = false;
            var eProject = false;
            if (currentWeb.Site.Features[new Guid(LivePlannerGuid)] == null)
            {
                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        using (var site = new SPSite(currentWeb.Site.ID))
                        {
                            using (var web = site.OpenWeb(currentWeb.ID))
                            {
                                AddMenus(web, ref hasProject, site, ref eProject);
                            }
                        }
                    });
            }
        }

        private void AddMenus(SPWeb web, ref bool hasProject, SPSite site, ref bool eProject)
        {
            bool disablePlan;
            bool.TryParse(CoreFunctions.getConfigSetting(web, "EPMLiveDisablePlanners"), out disablePlan);

            if (!disablePlan)
            {
                AddEpmLivePlannersControls(web);
                VerifyProjects(web, out hasProject, out eProject);
            }
            try
            {
                var lockedWeb = CoreFunctions.getLockedWeb(web);
                string projectCenter;
                string taskCenter;
                var enableWp = false;

                SetWebSettings(lockedWeb, web, site, ref enableWp, out projectCenter, out taskCenter);

                if (projectCenter != string.Empty && (projectCenter == sListName || taskCenter == sListName) && enableWp)
                {
                    var list = web.Lists[projectCenter];
                    if (list.Items.Count == 1)
                    {
                        AddPlannerMenus(list, hasProject, eProject, web, disablePlan);
                    }
                    else if (list.Items.Count > 1)
                    {
                        AddEditProjectMenus(hasProject, disablePlan, web, list, eProject);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Except Suppressed {0}", ex);
            }
            try
            {
                if (!disablePlan)
                {
                    AddEditAgilePlannerMenus(web, site);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Except Suppressed {0}", ex);
            }
        }

        private static void SetWebSettings(Guid lockedWeb, SPWeb web, SPSite site, ref bool enableWp, out string projectCenter, out string taskCenter)
        {
            if (lockedWeb != web.ID)
            {
                using (var spWeb = site.OpenWeb(lockedWeb))
                {
                    projectCenter = CoreFunctions.getConfigSetting(spWeb, "EPMLiveWPProjectCenter");
                    taskCenter = CoreFunctions.getConfigSetting(spWeb, "EPMLiveWPTaskCenter");
                    try
                    {
                        enableWp = bool.Parse(CoreFunctions.getConfigSetting(spWeb, "EPMLiveWPEnable"));
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Except Suppressed {0}", ex);
                    }
                }
            }
            else
            {
                projectCenter = CoreFunctions.getConfigSetting(web, "EPMLiveWPProjectCenter");
                taskCenter = CoreFunctions.getConfigSetting(web, "EPMLiveWPTaskCenter");
                try
                {
                    enableWp = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveWPEnable"));
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Except Suppressed {0}", ex);
                }
            }
        }

        private void AddEpmLivePlannersControls(SPWeb web)
        {
            if (web.Site.Features[new Guid(LivePlannerGuid)] != null)
            {
                var planners = CoreFunctions.getLockConfigSetting(web, "EPMLivePlannerPlanners", false);

                foreach (var menu in planners.Split(',')
                    .Where(planner => !string.IsNullOrWhiteSpace(planner))
                    .Select(planner => planner.Split('|'))
                    .Select(
                        sPlanner => new
                        {
                            sPlanner,
                            tc = CoreFunctions.getLockConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "TaskCenter", false)
                        })
                    .Where(planner => sListName == planner.tc)
                    .Select(
                        planner => new MenuItemTemplate
                        {
                            Text = string.Format("Edit In {0}", planner.sPlanner[1]),
                            Description = string.Format("Edit your attached schedule using {0}.", planner.sPlanner[1]),
                            ImageUrl = "/_layouts/epmlive/images/planner32.png",
                            ClientOnClickNavigateUrl = string.Format(
                                "{0}/_layouts/epmlive/workplanner.aspx?Planner={1}&source={2}",
                                web.ServerRelativeUrl,
                                planner.sPlanner[0],
                                HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]))
                        }))
                {
                    Controls.Add(menu);
                }
            }
        }

        private static void VerifyProjects(SPWeb web, out bool hasProject, out bool eProject)
        {
            hasProject = false;
            eProject = false;
            if (web.Features[new Guid(ProjectSchedulesGuid)] == null)
            {
                try
                {
                    var lib = (SPDocumentLibrary)web.Lists["Project Schedules"];
                    if (lib != null)
                    {
                        var template = lib.DocumentTemplateUrl;
                        if (template.Substring(template.Length - 3, 3) == "mpp")
                        {
                            hasProject = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Except Suppressed {0}", ex);
                }
            }
            else
            {
                eProject = true;
                hasProject = true;
            }
        }

        private void AddPlannerMenus(SPList list, bool hasProject, bool eProject, SPWeb web, bool disablePlan)
        {
            var listItem = list.Items[0];
            MenuItemTemplate menu;

            if (hasProject)
            {
                menu = new MenuItemTemplate
                {
                    Text = "Edit With Project",
                    Description = "Edit your attached schedule using Microsoft Office Project.",
                    ImageUrl = "/_layouts/images/project2007logo.gif",
                    ClientOnClickScript = string.Format(
                        eProject
                            ? "javascript:window.open('{0}/_layouts/epmlive/getpsproject.aspx?listID={1}&amp;itemID={2}','', config='height=250,width=350, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false"
                            : "javascript:window.open('{0}/_layouts/epmlive/getproject.aspx?listID={1}&amp;ID={2}','', config='height=100,width=350, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false",
                        web.ServerRelativeUrl,
                        list.ID,
                        listItem.ID)
                };

                Controls.Add(menu);
            }

            if (!disablePlan)
            {
                if (web.Site.Features[new Guid(SiteFeaturesGuid)] != null)
                {
                    menu = new MenuItemTemplate
                    {
                        Text = "Edit In Work Planner",
                        Description = "Edit your attached schedule using Work Planner.",
                        ImageUrl = "/_layouts/images/epmlivelogo.gif",
                        ClientOnClickScript = string.Format(
                            "javascript:window.open('{0}/_layouts/epmlive/tasks.aspx?ID={1}&source={2}','', config='width=' + screen.width + ',height=' + screen.height + ',top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes'); return false;",
                            web.ServerRelativeUrl,
                            listItem.ID,
                            HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]))
                    };

                    Controls.Add(menu);
                }
            }
        }

        private void AddEditProjectMenus(bool hasProject, bool disablePlan, SPWeb web, SPList list, bool eProject)
        {
            var menu = new SubMenuTemplate
            {
                Text = "Edit With Project",
                Description = "Edit your attached schedule using Microsoft Office Project.",
                ImageUrl = "/_layouts/images/project2007logo.gif"
            };

            if (hasProject)
            {
                Controls.Add(menu);
            }

            var menuWP = new SubMenuTemplate();

            if (!disablePlan)
            {
                if (web.Site.Features[new Guid(SiteFeaturesGuid)] != null)
                {
                    menuWP.Text = "Edit In Work Planner";
                    menuWP.Description = "Edit your attached schedule using Work Planner.";
                    menuWP.ImageUrl = "/_layouts/images/epmlivelogo.gif";

                    Controls.Add(menuWP);
                }
            }
            var query = new SPQuery
            {
                Query = "<OrderBy><FieldRef Name='Title'/></OrderBy>"
            };

            foreach (SPListItem listItem in list.GetItems(query))
            {
                AddGetProjectsMenu(hasProject, eProject, listItem, web, list, menu);
                AddTasksMenu(web, listItem, menuWP);
            }
        }

        private void AddEditAgilePlannerMenus(SPWeb web, SPSite site)
        {
            var lockedWeb = CoreFunctions.getLockedWeb(web);
            string projectCenter;
            string taskCenter;
            var enableWp = false;
            GetEnableWp(lockedWeb, web, site, ref enableWp, out projectCenter, out taskCenter);
            AddEditAgilePlannerMenu(projectCenter, taskCenter, enableWp, web);
        }

        private static void AddGetProjectsMenu(bool hasProject, bool eProject, SPListItem listItem, SPWeb web, SPList list, SubMenuTemplate menu)
        {
            if (hasProject)
            {
                MenuItemTemplate menuItemTemplate;

                if (eProject)
                {
                    menuItemTemplate = new MenuItemTemplate
                    {
                        Text = listItem.Title,
                        ClientOnClickScript = string.Format(
                            "javascript:window.open('{0}/_layouts/epmlive/getpsproject.aspx?listID={1}&amp;itemID={2}','', config='height=250,width=350, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false",
                            web.ServerRelativeUrl,
                            list.ID,
                            listItem.ID)
                    };
                    menu.Controls.Add(menuItemTemplate);
                }
                else
                {
                    menuItemTemplate = new MenuItemTemplate
                    {
                        Text = listItem.Title,
                        ClientOnClickScript = string.Format(
                            "javascript:window.open('{0}/_layouts/epmlive/getproject.aspx?listID={1}&amp;ID={2}','', config='height=100,width=350, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false",
                            web.ServerRelativeUrl,
                            list.ID,
                            listItem.ID)
                    };
                    menu.Controls.Add(menuItemTemplate);
                }
            }
        }

        private static void AddTasksMenu(SPWeb web, SPListItem listItem, SubMenuTemplate menuWP)
        {
            if (web.Site.Features[new Guid(SiteFeaturesGuid)] != null)
            {
                var menuItemTemplate = new MenuItemTemplate
                {
                    Text = listItem.Title,
                    ClientOnClickScript = string.Format(
                        "javascript:window.open('{0}/_layouts/epmlive/tasks.aspx?ID={1}&source={2}','', config='width=' + screen.width + ',height=' + screen.height + ',top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes'); return false;",
                        web.ServerRelativeUrl,
                        listItem.ID,
                        HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]))
                };
                menuWP.Controls.Add(menuItemTemplate);
            }
        }

        private static void GetEnableWp(Guid lockedWeb, SPWeb web, SPSite site, ref bool enableWp, out string projectCenter, out string taskCenter)
        {
            if (lockedWeb != web.ID)
            {
                using (var spWeb = site.OpenWeb(lockedWeb))
                {
                    projectCenter = CoreFunctions.getConfigSetting(spWeb, "EPMLiveAgileProjectCenter");
                    taskCenter = CoreFunctions.getConfigSetting(spWeb, "EPMLiveAgileTaskCenter");
                    try
                    {
                        enableWp = bool.Parse(CoreFunctions.getConfigSetting(spWeb, "EPMLiveAgileEnable"));
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Except Suppressed {0}", ex);
                    }
                }
            }
            else
            {
                projectCenter = CoreFunctions.getConfigSetting(web, "EPMLiveAgileProjectCenter");
                taskCenter = CoreFunctions.getConfigSetting(web, "EPMLiveAgileTaskCenter");
                try
                {
                    enableWp = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveAgileEnable"));
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Except Suppressed {0}", ex);
                }
            }
        }

        private void AddEditAgilePlannerMenu(string projectCenter, string taskCenter, bool enableWp, SPWeb web)
        {
            if (projectCenter != string.Empty && (projectCenter == sListName || taskCenter == sListName) && enableWp)
            {
                var list = web.Lists[projectCenter];
                if (list.Items.Count == 1)
                {
                    var li = list.Items[0];
                    var menu = new MenuItemTemplate
                    {
                        Text = "Edit In Agile Planner",
                        Description = "Edit your attached schedule using Agile Planner.",
                        ImageUrl = "/_layouts/images/epmlivelogo.gif",
                        ClientOnClickScript = string.Format(
                            "javascript:window.open('{0}/_layouts/epmlive/agile/tasks.aspx?ID={1}&source={2}','', config='width=' + screen.width + ',height=' + screen.height + ',top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes'); return false;",
                            web.ServerRelativeUrl,
                            li.ID,
                            HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]))
                    };

                    Controls.Add(menu);
                }
                else if (list.Items.Count > 1)
                {
                    var menuWp = new SubMenuTemplate
                    {
                        Text = "Edit In Agile Planner",
                        Description = "Edit your attached schedule using Agile Planner.",
                        ImageUrl = "/_layouts/images/epmlivelogo.gif"
                    };

                    Controls.Add(menuWp);

                    var query = new SPQuery
                    {
                        Query = "<OrderBy><FieldRef Name='Title'/></OrderBy>"
                    };

                    foreach (SPListItem li in list.GetItems(query))
                    {
                        var menu1 = new MenuItemTemplate
                        {
                            Text = li.Title,
                            ClientOnClickScript = string.Format(
                                "javascript:window.open('{0}/_layouts/epmlive/agile/tasks.aspx?ID={1}&source={2}','', config='width=' + screen.width + ',height=' + screen.height + ',top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes'); return false;",
                                web.ServerRelativeUrl,
                                li.ID,
                                HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]))
                        };

                        menuWp.Controls.Add(menu1);
                    }
                }
            }
        }
    }
}
