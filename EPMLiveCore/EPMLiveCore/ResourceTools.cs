using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class ResourceTools : WebControl
    {
        private const string True = "true";
        private const string ResToolsReportURL = "ResToolsReportURL";

        protected override void OnLoad(EventArgs e)
        {
            EnsureChildControls();
            base.OnLoad(e);
        }

        protected override void CreateChildControls()
        {
            var site = SPContext.Current.Site;
            {
                var currentWeb = SPContext.Current.Web;
                currentWeb.Site.CatchAccessDeniedException = false;
                try
                {
                    var resourceUrl = string.Empty;
                    var enablePlan = string.Empty;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        resourceUrl = CoreFunctions.getConfigSetting(currentWeb, "EPMLiveResourceURL");
                        try
                        {
                            GridGanttSettings gSettings = new GridGanttSettings(SPContext.Current.List);
                            enablePlan = gSettings.EnableResourcePlan.ToString();
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                        }
                    });

                    if (resourceUrl != string.Empty && enablePlan.Equals(True, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var menu = string.Empty;

                        var webId = CoreFunctions.getLockedWeb(currentWeb);
                        var reportUrl = string.Empty;
                        if (webId != currentWeb.ID)
                        {
                            using (SPWeb lWeb = site.OpenWeb(webId))
                            {
                                reportUrl = CoreFunctions.getConfigSetting(lWeb, ResToolsReportURL);
                            }
                        }
                        else
                        {
                            reportUrl = CoreFunctions.getConfigSetting(currentWeb, ResToolsReportURL);
                        }

                         
                        if (!string.IsNullOrWhiteSpace(reportUrl))
                        {
                            reportUrl = CoreFunctions.getWebAppSetting(currentWeb.Site.WebApplication.Id, "ReportingServicesURL") + "?%2fepmlivetl%2fResource%2fResource+Work+vs.+Capacity";
                        }

                        menu = "<ie:menuitem id=\"zz25_FindResources\" type=\"option\" iconSrc=\"/_layouts/images/epmlive_rt_find.gif\" onMenuClick=\"javascript:window.open('" + reportUrl + "&URL=" + currentWeb.ServerRelativeUrl + "','', config='height=600,width=800, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes'); return false\" text=\"Find Resource(s)\" description=\"Use this tool to find which resources are available for your work.\" menuGroupId=\"100\"></ie:menuitem>";
                        menu += "<ie:menuitem id=\"zz26_CheckResource\" type=\"option\" iconSrc=\"/_layouts/images/epmlive_rt_check.gif\" onMenuClick=\"javascript:showgantt('" + ((resourceUrl == "/")?string.Empty:resourceUrl) + "/_layouts/epmlive/checkresgantt.aspx','" + SPContext.Current.ListId + "','" + SPContext.Current.ItemId + "'); return false\" text=\"Check Resource(s)\" description=\"Use this tool to check your assignment against all other work in the system.\" menuGroupId=\"100\"></ie:menuitem>";

                        LiteralControl ctl = new LiteralControl("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"110\"><tr><td class='ms-toolbar'><img src=\"/_layouts/images/epmlive_rt_rt.GIF\" border=\"0\"></td><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"ResourceToolsMenuControls\" largeIconMode=\"true\">" + menu + "</menu></span><span title=\"Open Menu\"><div  id=\"ResourceToolsMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('ResourceToolsMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"ResourceToolsMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('ResourceToolsMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'), event);\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=ResourceToolsMenu,TEMPLATECLIENTID=ResourceToolsMenuControls\" serverclientid=\"ResourceToolsMenu\">Resource Tools<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>");
                        var tableControl = new LiteralControl("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"110\"><tr><td class='ms-toolbar'><img src=\"/_layouts/images/epmlive_rt_rt.GIF\" border=\"0\"></td><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"ResourceToolsMenuControls\" largeIconMode=\"true\">" + menu + "</menu></span><span title=\"Open Menu\"><div  id=\"ResourceToolsMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('ResourceToolsMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"ResourceToolsMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('ResourceToolsMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'), event);\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=ResourceToolsMenu,TEMPLATECLIENTID=ResourceToolsMenuControls\" serverclientid=\"ResourceToolsMenu\">Resource Tools<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>");
                        Controls.Add(tableControl);
                        var scriptControl = new LiteralControl("<script>" + Properties.Resources.txtCheckResourceJS + "</script>");
                        Controls.Add(scriptControl);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
            base.CreateChildControls();
        }

        public override void Dispose()
        {
            if (Controls != null)
            {
                for (var i = Controls.Count - 1; i >= 0; i--)
                {
                    Controls[i]?.Dispose();
                }
            }
            
            base.Dispose();
        }
    }
}