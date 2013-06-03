using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Web;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    [ToolboxData("<{0}:BtnCommonActions runat=server></{0}:BtnCommonActions>")]
    public class BtnCommonActions : WebControl, INamingContainer
    {
        private const string COMMON_ACTIONS_LIST_NAME = "Common Actions";
        private const string COMMON_ACTIONS_ASYNC_DATA_PAGE = "/_layouts/epmlive/CommonActionsAjaxDataHost.aspx?";
        private string _commonActionsDataHostPageUrl = string.Empty;

        public BtnCommonActions()
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
                        string setting = CoreFunctions.getConfigSetting(tWeb, "EPMLiveDisableCommonActions");
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
            SPList commonActionsList = web.Lists.TryGetList(COMMON_ACTIONS_LIST_NAME);
            _commonActionsDataHostPageUrl = site.MakeFullUrl(web.ServerRelativeUrl) + COMMON_ACTIONS_ASYNC_DATA_PAGE;

            if (commonActionsList != null && commonActionsList.Items.Count > 0)
            {
                // render scripts and variables
                // ====================================================
                writer.Write("<script type=\"text/javascript\"> var commonActionsAsyncUrl = \"" + _commonActionsDataHostPageUrl + "\"; </script>");
                writer.Write("<script type=\"text/javascript\" src=\"" + site.MakeFullUrl(web.ServerRelativeUrl) + "/_layouts/epmlive/BtnCommonActions.js\"></script>");

                // container div
                writer.Write("<div style=\"max-width:35px;height:70px;float:right;margin-right:20px;\" >");

                // render the button
                writer.Write("<A id=\"lnkCommonActions\" title=\"Common Actions\" rel=\"tooltipbottom\" class=\"ms-socialNotif\" onclick=\"ToggleCommonActionsMenu();return false;\" href=\"javascript:;\"  style=\"width:55px\"><SPAN onlick=\"document.getElementById('lnkCommonActions').click()\"><SPAN onlick=\"document.getElementById('lnkCommonActions').click()\" style=\"POSITION: relative; WIDTH: 32px; DISPLAY: inline-block; HEIGHT: 32px; OVERFLOW: hidden\" ><IMG style=\"BORDER-BOTTOM: 0px; POSITION: absolute; BORDER-LEFT: 0px; BORDER-TOP: 0px; BORDER-RIGHT: 0px; LEFT: -409px !important; TOP:-11px;\" src=\"/_layouts/epmlive/images/epmlive-header.png\"></SPAN></SPAN></A>");

                // html for actual menu
                // ===================================================
                writer.Write("<div id=\"divCommonActionsMenu\" style=\"z-index: 103; width:200px; display:none;top:2px;left:-150px;position:relative;\" dir=\"ltr\" class=\"ms-core-menu-box ms-core-defaultFont ms-shadow\" title=\"\" ismenu=\"true\" level=\"0\" _backgroundframeid=\"msomenuid4\" flipped=\"false\" LeftForBackIframe=\"13\" TopForBackIframe=\"30\">");
                writer.Write("<div id=\"divCommonActionsMenuAsync\" >");
                // loading div
                // ========================================
                writer.Write("<div id=\"divCommonActionsLoading\" style=\"width: 100%; text-align: center;padding-top:5px;padding-bottom:5px;\">");
                writer.Write("<img src=\"/_layouts/15/images/gears_anv4.gif\" style=\"vertical-align: middle\" />");
                writer.Write("Loading...");
                writer.Write("</div>");
                // =========================================
                writer.Write("</div>");
                writer.Write("</div>");

                // container div closing tag
                writer.Write("</div>");
            }
        }
    }
}
