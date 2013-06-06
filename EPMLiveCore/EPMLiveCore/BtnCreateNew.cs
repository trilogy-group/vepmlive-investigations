using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Web;
using System.Web.UI.WebControls;

namespace EPMLiveCore
{
    [ToolboxData("<{0}:BtnCreateNew runat=server></{0}:BtnCreateNew>")]
    public class BtnCreateNew : WebControl, INamingContainer
    {   
        private const string CREATE_NEW_ASYNC_DATA_PAGE = "/_layouts/epmlive/CreateNewAjaxDataHost.aspx?";
        private string _createNewDataHostPageUrl = string.Empty;

        public BtnCreateNew() { }

        protected override void Render(HtmlTextWriter writer)
        {
            bool doNotRender = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite tSite = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb tWeb = tSite.OpenWeb())
                    {
                        string setting = CoreFunctions.getConfigSetting(tWeb, "EPMLiveDisableCreateNew");
                        doNotRender = !string.IsNullOrEmpty(setting) ? bool.Parse(setting) : false;
                    }
                }
            });

            if (doNotRender)
            {
                return;
            }

            SPSite site = SPContext.Current.Site;
            SPWeb web = SPContext.Current.Web;
            _createNewDataHostPageUrl = site.MakeFullUrl(web.ServerRelativeUrl) + CREATE_NEW_ASYNC_DATA_PAGE;

            if (web.Lists.Cast<SPList>().Where(l => !l.Hidden).Count() > 0)
            {
                // render script and variables
                writer.Write("<script type=\"text/javascript\"> var createNewAsyncUrl = \"" + _createNewDataHostPageUrl + "\"; </script>");
                writer.Write("<script type=\"text/javascript\" src=\"" + site.MakeFullUrl(web.ServerRelativeUrl) + "/_layouts/epmlive/BtnCreateNew.js\"></script>");

                // render container div
                writer.Write("<div style=\"max-width:35px;height:32px;float:right;margin-right:20px;\" >");

                // render button
                writer.Write("<A id=lnkCreateNew rel=\"tooltipbottom\" title=\"Create New\" class=\"ms-socialNotif\" onclick=\"ToggleCreateNewMenu();return false;\" href=\"javascript:;\"><SPAN onlick=\"document.getElementById('lnkCreateNew').click()\"><SPAN onlick=\"document.getElementById('lnkCreateNew').click()\" style=\"POSITION: relative; WIDTH: 32px; DISPLAY: inline-block; HEIGHT: 32px; OVERFLOW: hidden\" ><IMG style=\"BORDER-BOTTOM: 0px; POSITION: absolute; BORDER-LEFT: 0px; BORDER-TOP: 0px; BORDER-RIGHT: 0px; LEFT: -461px !important; TOP: -11px;\" src=\"/_layouts/epmlive/images/epmlive-header.png\"></SPAN></SPAN></A>");

                // html for actual menu
                // ===================================================
                writer.Write("<div id=\"divCreateNewMenu\" style=\"z-index: 103; position:relative;width:200px; display:none; top: 2px; left: -160px\" dir=\"ltr\" class=\"ms-core-menu-box ms-core-defaultFont ms-shadow\" title=\"\" ismenu=\"true\" level=\"0\" _backgroundframeid=\"msomenuid4\" flipped=\"false\" LeftForBackIframe=\"13\" TopForBackIframe=\"30\">");
                writer.Write("<div id=\"divCreateNewMenuAsync\" >");
                // loading div
                // ========================================
                writer.Write("<div id=\"divCreateNewLoading\" style=\"width: 100%; text-align: center;padding-top:5px;padding-bottom:5px;\">");
                writer.Write("<img src=\"/_layouts/15/images/gears_anv4.gif\" style=\"vertical-align: middle\" />");
                writer.Write("Loading...");
                writer.Write("</div>");
                // =========================================
                writer.Write("</div>");
                writer.Write("</div>");

                // render container div closing tag
                writer.Write("</div>");
            }
        }
    }
}
