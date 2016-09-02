using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Configuration;

namespace EPMLiveCore
{
    public class ResourceTools : WebControl
    {
        protected override void OnLoad(EventArgs e)
        {
            EnsureChildControls();
            base.OnLoad(e);
        }

        protected override void CreateChildControls()
        {
            SPSite site = SPContext.Current.Site;
            {
                SPWeb web = SPContext.Current.Web;
                web.Site.CatchAccessDeniedException = false;
                try
                {
                    string resurl = "";
                    string enablePlan = "";
                    SPSecurity.RunWithElevatedPrivileges(delegate(){
                        resurl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL");
                        try
                        {
                            GridGanttSettings gSettings = new GridGanttSettings(SPContext.Current.List);
                            enablePlan = gSettings.EnableResourcePlan.ToString();
                        }
                        catch { }


                        //enablePlan = EPMLiveCore.CoreFunctions.getConfigSetting(web, System.IO.Path.GetDirectoryName(SPContext.Current.List.DefaultView.Url) + "-EnableResPlan");
                        //SPSite tSite = new SPSite(resurl);
                        //SPWeb tWeb = tSite.OpenWeb();

                        //if (resurl.ToLower() == tWeb.ServerRelativeUrl.ToLower())
                        //{
                        //    resurl = tWeb.ServerRelativeUrl;
                        //}
                        //else
                        //    resurl = "";
                        //if (tWeb.ID != web.ID)
                        //{
                        //    tWeb.Close();
                        //    tSite.Close();
                        //}
                    });
                    if (resurl != "" && enablePlan.ToLower() == "true")
                    {
                        string menu = "";

                        Guid gWeb = CoreFunctions.getLockedWeb(web);
                        string ssrsUrl = "";
                        if (gWeb != web.ID)
                        {
                            using (SPWeb lWeb = site.OpenWeb(gWeb))
                            {
                                ssrsUrl = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "ResToolsReportURL");
                            }
                        }
                        else
                            ssrsUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "ResToolsReportURL");

                         
                        if (ssrsUrl == "")
                        {
                            ssrsUrl = CoreFunctions.getWebAppSetting(web.Site.WebApplication.Id, "ReportingServicesURL") + "?%2fepmlivetl%2fResource%2fResource+Work+vs.+Capacity";
                        }

                        menu = "<ie:menuitem id=\"zz25_FindResources\" type=\"option\" iconSrc=\"/_layouts/images/epmlive_rt_find.gif\" onMenuClick=\"javascript:window.open('" + ssrsUrl + "&URL=" + web.ServerRelativeUrl + "','', config='height=600,width=800, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes'); return false\" text=\"Find Resource(s)\" description=\"Use this tool to find which resources are available for your work.\" menuGroupId=\"100\"></ie:menuitem>";
                        menu += "<ie:menuitem id=\"zz26_CheckResource\" type=\"option\" iconSrc=\"/_layouts/images/epmlive_rt_check.gif\" onMenuClick=\"javascript:showgantt('" + ((resurl == "/")?"":resurl) + "/_layouts/epmlive/checkresgantt.aspx','" + SPContext.Current.ListId + "','" + SPContext.Current.ItemId + "'); return false\" text=\"Check Resource(s)\" description=\"Use this tool to check your assignment against all other work in the system.\" menuGroupId=\"100\"></ie:menuitem>";

                        LiteralControl ctl = new LiteralControl("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"110\"><tr><td class='ms-toolbar'><img src=\"/_layouts/images/epmlive_rt_rt.GIF\" border=\"0\"></td><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"ResourceToolsMenuControls\" largeIconMode=\"true\">" + menu + "</menu></span><span title=\"Open Menu\"><div  id=\"ResourceToolsMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('ResourceToolsMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"ResourceToolsMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('ResourceToolsMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'), event);\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=ResourceToolsMenu,TEMPLATECLIENTID=ResourceToolsMenuControls\" serverclientid=\"ResourceToolsMenu\">Resource Tools<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>");
                        Controls.Add(ctl);
                        LiteralControl ctl1 = new LiteralControl("<script>" + Properties.Resources.txtCheckResourceJS + "</script>");
                        Controls.Add(ctl1);
                    }
                }
                catch { }
            
            //web.Close();
            }
            base.CreateChildControls();
        }
    }


}
