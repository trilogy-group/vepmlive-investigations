using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int communityId;
            var currentUrl = SPHttpUtility.UrlKeyValueDecode(HttpContext.Current.Request.Url.ToString());
            if (UrlIsHomePage(currentUrl, out communityId) && appHelper.CurrentAppId != communityId)
            {
                appHelper.SetCurrentAppId(communityId);
                SPUtility.Redirect(SPContext.Current.Web.Url, SPRedirectFlags.Default, HttpContext.Current);
            }

            var site = SPContext.Current.Site;
            var web = SPContext.Current.Web;

            SPSecurity.RunWithElevatedPrivileges(delegate { CheckAppIsValid(site, web, currentUrl); });

            //if (!doRender)
            //{
            //    return;
            //}

            _changeAppDataHostPageUrl = site.MakeFullUrl(web.ServerRelativeUrl) + MultiAppNavigationResources.CHANGE_APP_ASYNC_DATA_PAGE;

            DoRender(writer, web, site);
        }

        private void CheckAppIsValid(SPSite site, SPWeb web, string currentUrl)
        {
            using (var spSite = new SPSite(site.ID))
            using (var spWeb = spSite.OpenWeb(web.ID))
            {
                spWeb.AllowUnsafeUpdates = true;
                var appList = spWeb.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                if (appList != null)
                {
                    SPListItem appItem = null;
                    try
                    {
                        appItem = appList.GetItemById(appHelper.CurrentAppId);
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }

                    if (appItem != null)
                    {
                        var urlValue = new SPFieldUrlValue();
                        object fieldValue = null;
                        try
                        {
                            fieldValue = appItem["HomePage"];
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceError("Exception Suppressed {0}", ex);
                        }

                        if (fieldValue != null)
                        {
                            urlValue = new SPFieldUrlValue(fieldValue.ToString());
                        }

                        RedirectToUrl(spWeb, currentUrl, urlValue, spSite);
                    }
                }
                else
                {
                    // CC-77299 Empty branch, but I'm keeping it because the commented out code signaled
                    // the intent of handling this scenario, even if currently it doesn't
                    //doRender = false;
                }
            }
        }

        private void RedirectToUrl(SPWeb spWeb, string currentUrl, SPFieldUrlValue urlValue, SPSite spSite)
        {
            // CC-77299 Unused variable but I'm keeping, also spWeb.Url has side effects so I would have to keep right side of the assignment to preserve behavior
            var homeWebUrl = string.Format("{0}/default.aspx", spWeb.Url);

            if (currentUrl.Equals(GetWelcomePage())
                && !string.IsNullOrWhiteSpace(urlValue.Url)
                && SPHttpUtility.UrlKeyValueDecode(urlValue.Url) != currentUrl)
            {
                var url = string.Empty;

                url = urlValue.Url.StartsWith("/", StringComparison.OrdinalIgnoreCase)
                    ? spSite.MakeFullUrl(url)
                    : SPHttpUtility.UrlKeyValueDecode(urlValue.Url);

                SPUtility.Redirect(url, SPRedirectFlags.Static, HttpContext.Current);
            }
        }

        private void DoRender(HtmlTextWriter writer, SPWeb web, SPSite site)
        {
            var appTitle = appHelper.GetCurrentAppTitle();

            if (string.IsNullOrWhiteSpace(appTitle))
            {
                appTitle = "No Community";
            }

            if (web.Lists.Cast<SPList>().Any(list => !list.Hidden))
            {
                RenderScriptsAndVariables(writer, site, web);
                RenderButton(writer, appTitle);
                RenderMenu(writer);
            }
        }

        private void RenderScriptsAndVariables(HtmlTextWriter writer, SPSite site, SPWeb web)
        {
            // render script and variables

            //writer.Write("<script type=\"text/javascript\" src=\"" + site.MakeFullUrl(web.ServerRelativeUrl) + "/_layouts/epmlive/jQueryLibrary/jquery-1.6.2.min.js\"></script>");
            writer.Write(
                string.Format(
                    "<script type=\"text/javascript\" src=\"{0}/_layouts/epmlive/javascripts/BtnChangeApp.js\"></script>",
                    site.MakeFullUrl(web.ServerRelativeUrl)));
            writer.Write(
                string.Format(
                    "<script type=\"text/javascript\"> var changeAppAsyncUrl = \"{0}\"; var btnChangeAppCurrentAppId = \"{1}\"; var webUrl = \"{2}\"; </script>",
                    _changeAppDataHostPageUrl,
                    appHelper.CurrentAppId,
                    web.Url));
        }

        private static void RenderButton(HtmlTextWriter writer, string appTitle)
        {
            // render button
            // =====================================================
            writer.Write("<div>");
            writer.Write(
                "<span title='Open Menu' class='ms-menu-althov ms-welcome-root' style='white-space: nowrap;'"
                + " hoverinactive='ms-menu-althov ms-welcome-root' hoveractive='ms-menu-althov-active ms-welcome-root ms-welcome-hover'"
                + " onmouseover='MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)'>");

            writer.Write("<a id=\"lnkChangeApp\" class=\"ms-core-menu-root\" href=\"#\" onclick=\"ToggleChangeAppMenu();return false;\">");

            writer.Write("<span onlick=\"document.getElementById('lnkChangeApp').click()\">");
            writer.Write(string.Format("<span onlick=\"document.getElementById('lnkChangeApp').click()\" id=\"spnChangeAppText\" >{0}</span>", appTitle));
            writer.Write("</span>");

            writer.Write("</a>");

            writer.Write(
                "<span style=\"POSITION: relative; WIDTH: 7px; DISPLAY: inline-block; HEIGHT: 4px; OVERFLOW: hidden\""
                + " class=\"s4-clust ms-viewselector-arrow ms-menu-stdarw ms-core-menu-arrow\">"
                + "<img style=\"POSITION: absolute; TOP: -259px !important; LEFT: -95px !important\" alt=\"Open Menu\" src=\"/_layouts/15/images/spcommon.png?rev=23\">"
                + "</span>");

            writer.Write(
                "<span style=\"POSITION: relative; WIDTH: 7px; DISPLAY: inline-block; HEIGHT: 4px; OVERFLOW: hidden\" class=\""
                + "s4-clust ms-core-menu-arrow ms-viewselector-arrow ms-menu-hovarw\">"
                + "<img style=\"POSITION: absolute; TOP: -259px !important; LEFT: -86px !important\" alt=\"Open Menu\" src=\"/_layouts/15/images/spcommon.png?rev=23\">"
                + "</span>");
        }

        private static void RenderMenu(HtmlTextWriter writer)
        {
            // html for actual menu
            // ===================================================
            writer.Write(
                "<div id=\"divChangeAppMenu\" style=\"z-index: 103; position: absolute; width: 159px; display:none; top: 28px; left: -86px\""
                + " dir=\"ltr\" class=\"ms-core-menu-box ms-core-defaultFont ms-shadow\" title=\"\" ismenu=\"true\" level=\"0\""
                + " _backgroundframeid=\"msomenuid4\" flipped=\"false\" LeftForBackIframe=\"13\" TopForBackIframe=\"30\">");
            writer.Write("<div id=\"divChangeAppMenuAsync\">");

            // loading div
            // ========================================
            writer.Write("<div id=\"divChangeAppLoading\" style=\"width: 100%; text-align: center;padding-top:5px;padding-bottom:5px;\">");
            writer.Write("<img src=\"/_layouts/15/images/gears_anv4.gif\" style=\"vertical-align: middle\" />");
            writer.Write("Loading...");
            writer.Write("</div>");

            // =========================================
            writer.Write("</div>");
            writer.Write("</div>");

            writer.Write("</span>");
            writer.Write("</div>");
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
