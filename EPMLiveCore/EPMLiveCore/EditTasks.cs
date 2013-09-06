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
    public class EditTasks : WebControl
    {
        private string sListName;

        protected override void OnLoad(EventArgs e)
        {
            //EnsureChildControls();
            //base.OnLoad(e);

            if (Parent.Parent.Parent.Parent.Parent.Parent.GetType().ToString() == "FormsDesigner.Sharepoint.FDDataFormWebPart")
                sListName = ((Microsoft.SharePoint.WebPartPages.ListFormWebPart)Parent.Parent.Parent.Parent.Parent.Parent).ItemContext.List.Title;
            else
                sListName = ((Microsoft.SharePoint.WebPartPages.ListFormWebPart)Parent.Parent.Parent.Parent.Parent.Parent).ItemContext.List.Title;
        }

        protected override void CreateChildControls()
        {
            SPWeb web = SPContext.Current.Web;

            if(web.Site.Features[new Guid("e6df7606-1541-4bf1-a810-e8e9b11819e3")] == null)
            {

                string agile = "";
                string workplanner = "";
                string editinproject = "";

                try
                {
                    Guid lWeb = CoreFunctions.getLockedWeb(web);
                    string projectcenter = "";
                    bool enableWP = false;
                    if(lWeb != web.ID)
                    {
                        using(SPWeb tweb = SPContext.Current.Site.OpenWeb(lWeb))
                        {
                            projectcenter = CoreFunctions.getConfigSetting(tweb, "EPMLiveAgileProjectCenter");
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
                        try
                        {
                            enableWP = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveAgileEnable"));
                        }
                        catch { }

                    }

                    if(projectcenter == sListName && enableWP)
                    {

                        agile = "<ie:menuitem id=\"zz26_Workplanner\" type=\"option\" iconSrc=\"/_layouts/images/epmlivelogo.gif\" onMenuClick=\"window.location.href='" + web.ServerRelativeUrl + "/_layouts/epmlive/agile/tasks.aspx?ID=" + SPContext.Current.ListItem.ID + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]) + "'\" text=\"Edit In Agile Planner\" description=\"Edit your attached schedule using Agile Planner.\" menuGroupId=\"100\"></ie:menuitem>";
                    }
                }
                catch { }


                try
                {
                    Guid lWeb = CoreFunctions.getLockedWeb(web);
                    string projectcenter = "";
                    bool enableWP = false;
                    if(lWeb != web.ID)
                    {
                        using(SPWeb tweb = SPContext.Current.Site.OpenWeb(lWeb))
                        {
                            projectcenter = CoreFunctions.getConfigSetting(tweb, "EPMLiveWPProjectCenter");
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
                        try
                        {
                            enableWP = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveWPEnable"));
                        }
                        catch { }

                    }

                    if(projectcenter == sListName && enableWP && web.Site.Features[new Guid("91f0c887-2db2-44b2-b15c-47c69809c767")] != null)
                    {
                        workplanner = "<ie:menuitem id=\"zz26_Workplanner\" type=\"option\" iconSrc=\"/_layouts/images/epmlivelogo.gif\" onMenuClick=\"window.location.href='" + web.ServerRelativeUrl + "/_layouts/epmlive/tasks.aspx?ID=" + SPContext.Current.ListItem.ID + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()) + "'\" text=\"Edit In Work Planner\" description=\"Edit your attached schedule using Work Planner.\" menuGroupId=\"100\"></ie:menuitem>";
                    }
                }
                catch { }

                if(web.Features[new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055")] == null)
                {
                    try
                    {
                        SPDocumentLibrary list = (SPDocumentLibrary)web.Lists["Project Schedules"];
                        if(list != null)
                        {
                            string template = list.DocumentTemplateUrl;
                            if(template.Substring(template.Length - 3, 3) == "mpp")
                                editinproject = "<ie:menuitem id=\"zz25_Project\" type=\"option\" iconSrc=\"/_layouts/images/project2007logo.gif\" onMenuClick=\"javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/getproject.aspx?listID=" + SPContext.Current.List.ID.ToString() + "&amp;ID=" + SPContext.Current.ListItem.ID + "','', config='height=100,width=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false\" text=\"Edit With Project\" description=\"Edit your attached schedule using Microsoft Office Project.\" menuGroupId=\"100\"></ie:menuitem>";
                        }
                    }
                    catch { }
                }
                else
                {
                    editinproject = "<ie:menuitem id=\"zz25_Project\" type=\"option\" iconSrc=\"/_layouts/images/project2007logo.gif\" onMenuClick=\"javascript:window.open('" + web.ServerRelativeUrl + "/_layouts/epmlive/getpsproject.aspx?listID=" + SPContext.Current.List.ID.ToString() + "&amp;itemID=" + SPContext.Current.ListItem.ID + "','', config='height=250,width=350, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no'); return false\" text=\"Edit With Project\" description=\"Edit your schedule using Microsoft Office Project 2007.\" menuGroupId=\"100\"></ie:menuitem>";
                }


                //Agile
                if(workplanner != "" || editinproject != "" || agile != "")
                {
                    LiteralControl ctl = new LiteralControl("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"110\"><tr><td class='ms-toolbar'><img src=\"/_layouts/images/ALLMEET.GIF\" border=\"0\"></td><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"EditTasksMenuControls\" largeIconMode=\"true\">" + editinproject + workplanner + agile + "</menu></span><span title=\"Open Menu\"><div  id=\"EditTasksMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('EditTasksMenuControls'), MMU_GetMenuFromClientId('EditTasksMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('EditTasksMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"EditTasksMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('EditTasksMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('EditTasksMenuControls'), MMU_GetMenuFromClientId('EditTasksMenu'), event);\" onclick=\" MMU_Open(byid('EditTasksMenuControls'), MMU_GetMenuFromClientId('EditTasksMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=EditTasksMenu,TEMPLATECLIENTID=EditTasksMenuControls\" serverclientid=\"EditTasksMenu\">Edit Tasks<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>");

                    Controls.Add(ctl);
                }
            }
            base.CreateChildControls();
        }
    }


}
