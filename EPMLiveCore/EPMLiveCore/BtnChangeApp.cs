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
                            url = SPHttpUtility.UrlKeyValueDecode(url);
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
            string currentUrl = SPHttpUtility.UrlKeyValueDecode(HttpContext.Current.Request.Url.ToString());
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
                                    SPHttpUtility.UrlKeyValueDecode(urlVal.Url) != currentUrl)
                                {
                                    string sUrl = string.Empty;
                                    if (urlVal.Url.StartsWith("/"))
                                    {
                                        sUrl = es.MakeFullUrl(sUrl);
                                    }
                                    else
                                    {
                                        sUrl = SPHttpUtility.UrlKeyValueDecode(urlVal.Url);
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
                writer.Write("<div>");
                writer.Write("<span title='Open Menu' class='ms-menu-althov ms-welcome-root' style='white-space: nowrap;' hoverinactive='ms-menu-althov ms-welcome-root' hoveractive='ms-menu-althov-active ms-welcome-root ms-welcome-hover'>");
                writer.Write("<a id=\"lnkChangeApp\" class=\"ms-core-menu-root\" href=\"#\" onclick=\"ToggleChangeAppMenu();return false;\">");
             
                writer.Write("<span onlick=\"document.getElementById('lnkChangeApp').click()\">");
                writer.Write(string.Format("<span onlick=\"document.getElementById('lnkChangeApp').click()\" id=\"spnChangeAppText\" >{0}</span>", appTitle));
                writer.Write("</span>");
 
                writer.Write("<span style=\"POSITION: relative; WIDTH: 7px; DISPLAY: inline-block; HEIGHT: 4px; OVERFLOW: hidden\" class=\"s4-clust ms-viewselector-arrow ms-menu-stdarw ms-core-menu-arrow\">" +
                             "<img style=\"POSITION: absolute; TOP: -259px !important; LEFT: -95px !important\" alt=\"Open Menu\" src=\"/_layouts/15/images/spcommon.png?rev=23\">" +
                             "</span>");


                writer.Write("<span style=\"POSITION: relative; WIDTH: 7px; DISPLAY: inline-block; HEIGHT: 4px; OVERFLOW: hidden\" class=\"s4-clust ms-core-menu-arrow ms-viewselector-arrow ms-menu-hovarw\">" +
                             "<img style=\"POSITION: absolute; TOP: -259px !important; LEFT: -86px !important\" alt=\"Open Menu\" src=\"/_layouts/15/images/spcommon.png?rev=23\">" +
                             "</span>");
                
                
                writer.Write("</a>");
                writer.Write("</span>");
                writer.Write("</div>");

                // html for actual menu
                // ===================================================
                writer.Write("<div id=\"divChangeAppMenu\" style=\"z-index: 103; position: absolute; width: 159px; display:none; top: 30px; left: 13px\" dir=\"ltr\" class=\"ms-core-menu-box ms-core-defaultFont ms-shadow\" title=\"\" ismenu=\"true\" level=\"0\" _backgroundframeid=\"msomenuid4\" flipped=\"false\" LeftForBackIframe=\"13\" TopForBackIframe=\"30\">");
                writer.Write("<div id=\"divChangeAppMenuAsync\">");
                // loading div
                // ========================================
                writer.Write("<div id=\"divChangeAppLoading\" style=\"width: 100%; text-align: center;padding-top:5px;padding-bottom:5px;\">");
                writer.Write("<img src=\"/_layouts/images/gears_anv4.gif\" style=\"vertical-align: middle\" />");
                writer.Write("Loading...");
                writer.Write("</div>");
                // =========================================
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

                                if (valUrl != null && 
                                    url.ToLower() == SPHttpUtility.UrlKeyValueDecode(valUrl.Url).ToLower())
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
