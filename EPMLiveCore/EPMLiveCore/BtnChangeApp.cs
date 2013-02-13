using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.GlobalResources;

namespace EPMLiveCore
{
    [ToolboxData("<{0}:BtnChangeApp runat=server></{0}:BtnChangeApp>")]
    public class BtnChangeApp : WebControl, INamingContainer
    {
        private string _changeAppDataHostPageUrl = string.Empty;
        private AppSettingsHelper appHelper;
        public BtnChangeApp() { }

        private string GetWelcomePage()
        {
            string url = string.Empty;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        string urlWelcome = ew.RootFolder.WelcomePage;
                        if (!string.IsNullOrEmpty(urlWelcome))
                        {
                            url = es.MakeFullUrl(urlWelcome);
                        }
                    }
                }
            });

            return url;
        }

        protected override void Render(HtmlTextWriter writer)
        {   
            appHelper = new AppSettingsHelper();
            int communityId = -1;
            string currentUrl = HttpContext.Current.Request.Url.ToString();
            if (UrlIsHomePage(currentUrl, out communityId) && appHelper.CurrentAppId != communityId)
            {
                appHelper.SetCurrentAppId(communityId);
                SPUtility.Redirect(SPContext.Current.Web.Url, SPRedirectFlags.Default, HttpContext.Current);
            }

            SPSite site = SPContext.Current.Site;
            SPWeb web = SPContext.Current.Web;
            
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (appList != null)
                        {
                            SPListItem appItem = null;
                            try
                            {
                                appItem = appList.GetItemById(appHelper.CurrentAppId);
                            }
                            catch { }

                            if (appItem != null)
                            {
                                SPFieldUrlValue urlVal = new SPFieldUrlValue();
                                object fv = null;
                                try
                                {
                                    fv = appItem["HomePage"];
                                }
                                catch { }

                                if (fv != null)
                                {
                                    urlVal = new SPFieldUrlValue(fv.ToString());
                                }

                                string homeWebUrl = ew.Url + "/default.aspx";

                                if (currentUrl.Equals(GetWelcomePage()) &&
                                    !string.IsNullOrEmpty(urlVal.Url) &&
                                    urlVal.Url != currentUrl)
                                {
                                    string sUrl = string.Empty;
                                    if (urlVal.Url.StartsWith("/"))
                                    {
                                        sUrl = es.MakeFullUrl(sUrl);
                                    }
                                    else
                                    {
                                        sUrl = urlVal.Url;
                                    }

                                    SPUtility.Redirect(sUrl, SPRedirectFlags.Static, HttpContext.Current);
                                }
                            }
                        }
                        else
                        {
                            //doRender = false;
                        }
                    }
                }
            });

            //if (!doRender)
            //{
            //    return;
            //}

            _changeAppDataHostPageUrl = site.MakeFullUrl(web.ServerRelativeUrl) + MultiAppNavigationResources.CHANGE_APP_ASYNC_DATA_PAGE;

            string appTitle = appHelper.GetCurrentAppTitle();

            if (string.IsNullOrEmpty(appTitle))
            {
                appTitle = "No Community";
            }

            if (web.Lists.Cast<SPList>().Where(l => !l.Hidden).Count() > 0)
            {
                // render script and variables
               
                //writer.Write("<script type=\"text/javascript\" src=\"" + site.MakeFullUrl(web.ServerRelativeUrl) + "/_layouts/epmlive/jQueryLibrary/jquery-1.6.2.min.js\"></script>");
                writer.Write("<script type=\"text/javascript\" src=\"" + site.MakeFullUrl(web.ServerRelativeUrl) + "/_layouts/epmlive/javascripts/BtnChangeApp.js\"></script>");
                writer.Write("<script type=\"text/javascript\"> var changeAppAsyncUrl = \"" + _changeAppDataHostPageUrl + "\"; var btnChangeAppCurrentAppId = \"" + appHelper.CurrentAppId.ToString() + "\"; var webUrl = \"" + web.Url + "\"; </script>");
                
                
                // render button
                // =====================================================
                writer.Write("<a id=\"lnkChangeApp\" style=\"height: 15px;" +
                                                            "color: #FFFFFF;" +
                                                            "padding-top: 1px;" +
                                                            "padding-right: 10px;" +
                                                            "padding-bottom: 4px;" +
                                                            "padding-left: 5px;" +
                                                            "vertical-align: middle;" +
                                                            "border-top-color: transparent;" +
                                                            "border-right-color: transparent;" +
                                                            "border-bottom-color: transparent;" +
                                                            "border-left-color: transparent;" +
                                                            "border-top-width: 1px;" +
                                                            "border-right-width: 1px;" +
                                                            "border-bottom-width: 1px;" +
                                                            "border-left-width: 1px;" +
                                                            "border-top-style: solid;" +
                                                            "border-right-style: solid;" +
                                                            "border-bottom-style: solid;" +
                                                            "border-left-style: solid;" +
                                                            "display: inline-block;" +
                                                            "white-space: nowrap;\"" +
                                                            "onmouseover=\"this.style.color = '#FFFFFF';\"" +
                                                            "onmouseout=\"this.style.color = '#FFFFFF';\"" +
                                                            "href=\"#\"" +
                                                            "onclick=\"ToggleChangeAppMenu();return false;\">");
                //writer.Write("<span onlick=\"document.getElementById('lnkChangeApp').click()\" style=\"background-image:url('/_layouts/images/menu-down.gif'); background-position: right 5px; background-repeat: no-repeat; padding-right:12px;\">");
                writer.Write("<span onlick=\"document.getElementById('lnkChangeApp').click()\">");
                writer.Write(string.Format("<span onlick=\"document.getElementById('lnkChangeApp').click()\" id=\"spnChangeAppText\" >{0}</span>", appTitle));
                writer.Write("</span>");
                writer.Write("<SPAN style=\"POSITION: relative; WIDTH: 5px; DISPLAY: inline-block; HEIGHT: 3px; OVERFLOW: hidden; margin-left: 5px;\" class=\"s4-clust ms-viewselector-arrow\"><IMG style=\"POSITION: absolute; BORDER-RIGHT-WIDTH: 0px; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; TOP: -491px !important; LEFT: 0px !important\" alt=\"Open Menu\" src=\"/_layouts/images/fgimg.png\"></SPAN>");
                writer.Write("</a>");

                // html for actual menu
                // ===================================================
                writer.Write("<div id=\"divChangeAppMenu\" style=\"z-index: 103; position: absolute; display:none; max-height:450px; overflow-x:hidden;overflow-y:auto;\" dir=\"ltr\" class=\"ms-MenuUIPopupBody ms-MenuUIPopupScreen\" title=\"\" ismenu=\"true\" level=\"0\" _backgroundframeid=\"msomenuid6\" flipped=\"false\" leftforbackiframe=\"834\" topforbackiframe=\"29\">");
                writer.Write("<div style=\"overflow: visible\" class=\"ms-MenuUIPopupInner\" isinner=\"true\">");
                writer.Write("<div id=\"divChangeAppMenuAsync\" class=\"ms-MenuUI\" style=\"width:254px\">");
                // loading div
                // ========================================
                writer.Write("<div id=\"divChangeAppLoading\" style=\"width: 100%; text-align: center;padding-top:5px;padding-bottom:5px;\">");
                writer.Write("<img src=\"/_layouts/images/gears_anv4.gif\" style=\"vertical-align: middle\" />");
                writer.Write("Loading...");
                writer.Write("</div>");
                // =========================================
                writer.Write("</div>");
                writer.Write("</div>");
                writer.Write("</div>");
            }
        }

        private bool UrlIsHomePage(string url, out int appId)
        {
            bool isHomePage = false;
            appId = -1;
            int matchId = -1;
            string currentUrl = HttpContext.Current.Request.Url.ToString();

            SPSite site = SPContext.Current.Site;
            SPWeb web = SPContext.Current.Web;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);

                        if (appList != null)
                        {
                            SPListItemCollection items = appList.Items;
                            foreach (SPListItem i in items)
                            {
                                SPFieldUrlValue valUrl = null;
                                try { valUrl = new SPFieldUrlValue(i["HomePage"].ToString()); }
                                catch { }

                                if (valUrl != null && url == valUrl.Url)
                                {
                                    isHomePage = true;
                                    matchId = int.Parse(i["ID"].ToString());
                                    break;
                                }
                            }
                        }
                    }
                }
            });

            appId = matchId;

            return isHomePage;
        }
    }
}
