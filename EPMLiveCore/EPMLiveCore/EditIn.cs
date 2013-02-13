using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public class EditIn : WebControl
    {
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
            catch { }

        }
        protected override void CreateChildControls()
        {
            //ListViewWebPart oListView = FindListView(Parent);

            //if (oListView == null) return;


            SPWeb cweb = SPContext.Current.Web;
            bool hasProject = false;
            bool eProject = false;
            if(cweb.Site.Features[new Guid("e6df7606-1541-4bf1-a810-e8e9b11819e3")] == null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using(SPSite site = new SPSite(cweb.Site.ID))
                    {
                        using(SPWeb web = site.OpenWeb(cweb.ID))
                        {
                            bool disablePlan = false;

                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePlanners"), out disablePlan);

                            if(!disablePlan)
                            {
                                if(web.Site.Features[new Guid("e6df7606-1541-4bf1-a810-e8e9b11819e3")] != null)
                                {

                                    string planners = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePlannerPlanners", false);

                                    foreach(string planner in planners.Split(','))
                                    {
                                        if(!String.IsNullOrEmpty(planner))
                                        {
                                            string[] sPlanner = planner.Split('|');
                                            string tc = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "TaskCenter", false);

                                            if(sListName == tc)
                                            {
                                                MenuItemTemplate menu = new MenuItemTemplate();
                                                menu.Text = "Edit In " + sPlanner[1];
                                                menu.Description = "Edit your attached schedule using " + sPlanner[1] + ".";
                                                menu.ImageUrl = "/_layouts/epmlive/images/planner32.png";
                                                menu.ClientOnClickNavigateUrl = web.ServerRelativeUrl + "/_layouts/epmlive/workplanner.aspx?Planner=" + sPlanner[0] + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]);

                                                Controls.Add(menu);
                                            }
                                        }
                                    }

                                }


                                if(web.Features[new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055")] == null)
                                {
                                    try
                                    {
                                        SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["Project Schedules"];
                                        if(lib != null)
                                        {
                                            string template = lib.DocumentTemplateUrl;
                                            if(template.Substring(template.Length - 3, 3) == "mpp")
                                            {
                                                hasProject = true;

                                            }
                                        }
                                    }
                                    catch { }
                                }
                                else
                                {
                                    eProject = true;
                                    hasProject = true;
                                }
                            }
                            try
                            {
                                Guid lWeb = CoreFunctions.getLockedWeb(web);
                                string projectcenter = "";
                                string taskcenter = "";
                                bool enableWP = false;
                                if(lWeb != web.ID)
                                {
                                    using(SPWeb tweb = site.OpenWeb(lWeb))
                                    {
                                        projectcenter = CoreFunctions.getConfigSetting(tweb, "EPMLiveWPProjectCenter");
                                        taskcenter = CoreFunctions.getConfigSetting(tweb, "EPMLiveWPTaskCenter");
                                        try
                                        {
                                            enableWP = bool.Parse(CoreFunctions.getConfigSetting(tweb, "EPMLiveWPEnable"));
                                        }
                                        catch { }
                                    }
                                }
                                else
                                {
                                    projectcenter = CoreFunctions.getConfigSetting(web, "EPMLiveWPProjectCenter");
                                    taskcenter = CoreFunctions.getConfigSetting(web, "EPMLiveWPTaskCenter");
                                    try
                                    {
                                        enableWP = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveWPEnable"));
                                    }
                                    catch { }
                                }

                                if(projectcenter != "" && (projectcenter == sListName || taskcenter == sListName) && enableWP)
                                {
                                    SPList list = web.Lists[projectcenter];
                                    if(list.Items.Count == 1)
                                    {
                                        SPListItem li = list.Items[0];
                                        MenuItemTemplate menu;

                                        if(hasProject)
                                        {
                                            menu = new MenuItemTemplate();
                                            menu.Text = "Edit With Project";
                                            menu.Description = "Edit your attached schedule using Microsoft Office Project.";
                                            menu.ImageUrl = "/_layouts/images/project2007logo.gif";
                                            if(eProject)
                                                menu.ClientOnClickScript = "javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/getpsproject.aspx?listID=" + list.ID.ToString() + "&amp;itemID=" + li.ID + "','', config='height=250,width=350, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false";
                                            else
                                                menu.ClientOnClickScript = "javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/getproject.aspx?listID=" + list.ID.ToString() + "&amp;ID=" + li.ID + "','', config='height=100,width=350, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false";

                                            Controls.Add(menu);
                                        }

                                        if(!disablePlan)
                                        {
                                            if(web.Site.Features[new Guid("91f0c887-2db2-44b2-b15c-47c69809c767")] != null)
                                            {
                                                menu = new MenuItemTemplate();
                                                menu.Text = "Edit In Work Planner";
                                                menu.Description = "Edit your attached schedule using Work Planner.";
                                                menu.ImageUrl = "/_layouts/images/epmlivelogo.gif";
                                                menu.ClientOnClickScript = "javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/tasks.aspx?ID=" + li.ID + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]) + "','', config='width=' + screen.width + ',height=' + screen.height + ',top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes'); return false;";

                                                Controls.Add(menu);
                                            }
                                        }
                                    }
                                    else if(list.Items.Count > 1)
                                    {
                                        SubMenuTemplate menu = new SubMenuTemplate();
                                        menu.Text = "Edit With Project";
                                        menu.Description = "Edit your attached schedule using Microsoft Office Project.";
                                        menu.ImageUrl = "/_layouts/images/project2007logo.gif";

                                        if(hasProject)
                                            Controls.Add(menu);

                                        SubMenuTemplate menuWP = new SubMenuTemplate();

                                        if(!disablePlan)
                                        {
                                            if(web.Site.Features[new Guid("91f0c887-2db2-44b2-b15c-47c69809c767")] != null)
                                            {

                                                menuWP.Text = "Edit In Work Planner";
                                                menuWP.Description = "Edit your attached schedule using Work Planner.";
                                                menuWP.ImageUrl = "/_layouts/images/epmlivelogo.gif";

                                                Controls.Add(menuWP);
                                            }

                                        }
                                        SPQuery query = new SPQuery();
                                        query.Query = "<OrderBy><FieldRef Name='Title'/></OrderBy>";

                                        foreach(SPListItem li in list.GetItems(query))
                                        {
                                            MenuItemTemplate menu1;

                                            if(hasProject)
                                            {
                                                if(eProject)
                                                {
                                                    menu1 = new MenuItemTemplate();
                                                    menu1.Text = li.Title;
                                                    menu1.ClientOnClickScript = "javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/getpsproject.aspx?listID=" + list.ID.ToString() + "&amp;itemID=" + li.ID + "','', config='height=250,width=350, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false";
                                                    menu.Controls.Add(menu1);
                                                }
                                                else
                                                {



                                                    //SPFile newFile = null;

                                                    //try
                                                    //{
                                                    //    newFile = lib.RootFolder.Files[li.Title + ".mpp"];
                                                    //}
                                                    //catch { }
                                                    //if (lib != null)
                                                    {
                                                        menu1 = new MenuItemTemplate();
                                                        menu1.Text = li.Title;
                                                        menu1.ClientOnClickScript = "javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/getproject.aspx?listID=" + list.ID.ToString() + "&amp;ID=" + li.ID + "','', config='height=100,width=350, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false";
                                                        menu.Controls.Add(menu1);
                                                    }
                                                }
                                            }

                                            if(web.Site.Features[new Guid("91f0c887-2db2-44b2-b15c-47c69809c767")] != null)
                                            {
                                                menu1 = new MenuItemTemplate();
                                                menu1.Text = li.Title;
                                                //menu1.ClientOnClickNavigateUrl = web.ServerRelativeUrl + "/_layouts/epmlive/tasks.aspx?ID=" + li.ID + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]);

                                                menu1.ClientOnClickScript = "javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/tasks.aspx?ID=" + li.ID + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]) + "','', config='width=' + screen.width + ',height=' + screen.height + ',top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes'); return false;";

                                                menuWP.Controls.Add(menu1);
                                            }
                                        }
                                    }
                                }
                            }
                            catch { }
                            try
                            {
                                if(!disablePlan)
                                {
                                    Guid lWeb = CoreFunctions.getLockedWeb(web);
                                    string projectcenter = "";
                                    string taskcenter = "";
                                    bool enableWP = false;
                                    if(lWeb != web.ID)
                                    {
                                        using(SPWeb tweb = site.OpenWeb(lWeb))
                                        {
                                            projectcenter = CoreFunctions.getConfigSetting(tweb, "EPMLiveAgileProjectCenter");
                                            taskcenter = CoreFunctions.getConfigSetting(tweb, "EPMLiveAgileTaskCenter");
                                            try
                                            {
                                                enableWP = bool.Parse(CoreFunctions.getConfigSetting(tweb, "EPMLiveAgileEnable"));
                                            }
                                            catch { }
                                        }
                                    }
                                    else
                                    {
                                        projectcenter = CoreFunctions.getConfigSetting(web, "EPMLiveAgileProjectCenter");
                                        taskcenter = CoreFunctions.getConfigSetting(web, "EPMLiveAgileTaskCenter");
                                        try
                                        {
                                            enableWP = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveAgileEnable"));
                                        }
                                        catch { }
                                    }

                                    if(projectcenter != "" && (projectcenter == sListName || taskcenter == sListName) && enableWP)
                                    {
                                        SPList list = web.Lists[projectcenter];
                                        if(list.Items.Count == 1)
                                        {
                                            SPListItem li = list.Items[0];
                                            MenuItemTemplate menu = new MenuItemTemplate();
                                            menu.Text = "Edit In Agile Planner";
                                            menu.Description = "Edit your attached schedule using Agile Planner.";
                                            menu.ImageUrl = "/_layouts/images/epmlivelogo.gif";
                                            //menu.ClientOnClickNavigateUrl = web.ServerRelativeUrl + "/_layouts/epmlive/agile/tasks.aspx?ID=" + li.ID + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]);
                                            menu.ClientOnClickScript = "javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/agile/tasks.aspx?ID=" + li.ID + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]) + "','', config='width=' + screen.width + ',height=' + screen.height + ',top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes'); return false;";

                                            Controls.Add(menu);
                                        }
                                        else if(list.Items.Count > 1)
                                        {

                                            SubMenuTemplate menuWP = new SubMenuTemplate();
                                            menuWP.Text = "Edit In Agile Planner";
                                            menuWP.Description = "Edit your attached schedule using Agile Planner.";
                                            menuWP.ImageUrl = "/_layouts/images/epmlivelogo.gif";

                                            Controls.Add(menuWP);

                                            SPQuery query = new SPQuery();
                                            query.Query = "<OrderBy><FieldRef Name='Title'/></OrderBy>";

                                            foreach(SPListItem li in list.GetItems(query))
                                            {
                                                MenuItemTemplate menu1 = new MenuItemTemplate();
                                                menu1.Text = li.Title;
                                                //menu1.ClientOnClickNavigateUrl = web.ServerRelativeUrl + "/_layouts/epmlive/agile/tasks.aspx?ID=" + li.ID + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]);
                                                menu1.ClientOnClickScript = "javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/agile/tasks.aspx?ID=" + li.ID + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]) + "','', config='width=' + screen.width + ',height=' + screen.height + ',top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes'); return false;";

                                                menuWP.Controls.Add(menu1);
                                            }
                                        }
                                    }
                                }
                            }
                            catch { }
                            //base.CreateChildControls();
                        }
                    }
                });
            }
        }
            
    }


}
