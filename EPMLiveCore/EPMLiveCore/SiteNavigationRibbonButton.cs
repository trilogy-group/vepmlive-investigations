using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    [ToolboxData("<{0}:SiteNavigationRibbonButton runat=server></{0}:SiteNavigationRibbonButton>")]
    public class SiteNavigationRibbonButton : ThemedClusteredHoverImage, INamingContainer
    {
        public SiteNavigationRibbonButton()
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            bool doNotRender = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite tSite = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb tWeb = tSite.OpenWeb())
                    {
                        string setting = CoreFunctions.getConfigSetting(tWeb, "EPMLiveDisableMyWorkspaces");
                        doNotRender = !string.IsNullOrEmpty(setting) ? bool.Parse(setting) : false;
                    }
                }
            });

            if (doNotRender)
            {
                return;
            }

            string currentWebUrl = (SPContext.Current.Web.ServerRelativeUrl == "/" ? "" : SPContext.Current.Web.ServerRelativeUrl);
            string currentFullPageUrl = SPContext.Current.Site.MakeFullUrl(SPContext.Current.Web.ServerRelativeUrl);
            //writer.Write("<script type=\"text/javascript\" src=\"" + currentFullPageUrl + "/_layouts/epmlive/SiteHierarchyMenu.js\"></script>");
            //writer.Write("<script type=\"text/javascript\"> var currentWebUrl = \"" + currentWebUrl + "\"; </script>");
            //writer.Write("<span id=\"spnPopupNav\" onclick=\"javascript:PopupWorkspaceListWP();return false;\" oncontextmenu=\"javascript:PopupWorkspaceListWP();return false;\" class=\"ms-SPLink ms-SpLinkButtonInActive ms-welcomeMenu\" style=\"white-space: nowrap;\" onmouseover=\"MMU_EcbTableMouseOverOut(this, true)\" hoverinactive=\"ms-SPLink ms-SpLinkButtonInActive ms-welcomeMenu\" hoveractive=\"ms-SPLink ms-SpLinkButtonActive ms-welcomeMenu\">");
            //writer.Write("<a class=\"ms-menu-a\" id=\"lnkPopupNav\" style=\"color:white;white-space:nowrap;cursor:pointer;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('zz11_ID_PersonalActionMenu'), this, true);\" href=\"#\" >");
            //writer.Write("<span>My Workspaces</span>");
            //writer.Write("</a>");
            //writer.Write("<span class=\"s4-clust ms-viewselector-arrow\" style=\"position: relative; width: 5px; display: inline-block; height: 3px; overflow: hidden;\">");
            //writer.Write("<img style=\"position: absolute; border-right-width: 0px; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 0px; top: -491px !important; left: 0px !important;\" alt=\"Open Menu\" src=\"/_layouts/images/fgimg.png\" complete=\"complete\"/>");
            //writer.Write("</span>");
            //writer.Write("</span>");
            
            writer.Write("<script type=\"text/javascript\" src=\"" + currentFullPageUrl + "/_layouts/epmlive/SiteHierarchyMenu.js\"></script>");
            writer.Write("<script type=\"text/javascript\"> var currentWebUrl = \"" + currentWebUrl + "\"; </script>");
            base.Render(writer);
            //writer.Write("<a href=\"#\" rel=\"tooltipbottom\" title=\"My Workspaces\" onclick=\"javascript:PopupWorkspaceListWP();return false;\"><img src=\"/_layouts/epmlive/images/workspaces.png\" style=\"padding-top:3px;padding-right:5px;\" border=\"0\"></a>");

            //writer.Write("<span id=\"spnPopupNav\" onclick=\"javascript:PopupWorkspaceListWP();return false;\" oncontextmenu=\"javascript:PopupWorkspaceListWP();return false;\" class=\"ms-SPLink ms-SpLinkButtonInActive ms-welcomeMenu\" style=\"white-space: nowrap;\" onmouseover=\"MMU_EcbTableMouseOverOut(this, true)\" hoverinactive=\"ms-SPLink ms-SpLinkButtonInActive ms-welcomeMenu\" hoveractive=\"ms-SPLink ms-SpLinkButtonActive ms-welcomeMenu\">");
            //writer.Write("<a class=\"ms-menu-a\" id=\"lnkPopupNav\" style=\"color:white;white-space:nowrap;cursor:pointer;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('zz11_ID_PersonalActionMenu'), this, true);\" href=\"#\" >");
            //writer.Write("<span>My Workspaces</span>");
            //writer.Write("</a>");
            //writer.Write("<span class=\"s4-clust ms-viewselector-arrow\" style=\"position: relative; width: 5px; display: inline-block; height: 3px; overflow: hidden;\">");
            //writer.Write("<img style=\"position: absolute; border-right-width: 0px; border-top-width: 0px; border-bottom-width: 0px; border-left-width: 0px; top: -491px !important; left: 0px !important;\" alt=\"Open Menu\" src=\"/_layouts/images/fgimg.png\" complete=\"complete\"/>");
            //writer.Write("</span>");
            //writer.Write("</span>");
        }
    }


}
