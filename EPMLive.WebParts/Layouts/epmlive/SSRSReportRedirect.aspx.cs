using System;
using System.Net;
using System.Web;
using EPMLiveCore;
using EPMLiveCore.Layouts.epmlive;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using EPMLiveWebParts.SSRS2006;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class SSRSReportRedirect : LayoutsPageBase
    {
        private string webUrl = string.Empty;
        private string itemUrl = string.Empty;

        private ReportingService2006 _srs2006;
        private string _reportingServicesUrl = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request["weburl"]))
            {
                webUrl = Request["weburl"];
            }

            if (!string.IsNullOrEmpty(Request["itemurl"]))
            {
                itemUrl = Request["itemurl"];
            }


            Redirect();
        }

        private void Redirect()
        {
            if (!string.IsNullOrEmpty(webUrl) && !string.IsNullOrEmpty(itemUrl))
            {
                var web = new SPSite(webUrl).OpenWeb();
                string sRedirectUrl = string.Empty;
                string queryString = string.Empty;

                if (!web.Exists)
                {
                    return;
                }

                if (itemUrl.Contains("?"))
                {
                    itemUrl = itemUrl.Remove(itemUrl.IndexOf("?"));
                }

                var urlim = getReportParameters(SPUrlUtility.CombineUrl(webUrl, itemUrl));
                var sServerReelativeUrl = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;
                
                //var sRedirectUrl = sServerReelativeUrl +
                //                   "/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl=" +
                //                   sServerReelativeUrl + "/" + itemUrl + urlim + "&rv:HeaderArea=none";
                
                if (Request.QueryString["rp:Resources"] != null)
                {
                    var queString = Convert.ToString(Request.QueryString["rp:Resources"]).Split(',');
                    foreach (var q in queString)
                    {
                        queryString += "&rp:Resources=" + q;
                    }
                }

                sRedirectUrl = sServerReelativeUrl +
                                "/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl=" +
                                sServerReelativeUrl + "/" + itemUrl + urlim + "&rv:HeaderArea=none" + queryString;

                SPUtility.Redirect(sRedirectUrl, SPRedirectFlags.Default, HttpContext.Current);
            }
        }

        private bool SetupSSRS()
        {
            var valid = false;
            try
            {
                _srs2006 = new ReportingService2006 { UseDefaultCredentials = true };
                var username = "";
                var password = "";
                var chrono = SPContext.Current.Site.WebApplication.GetChild<ReportAuth>("ReportAuth");
                if (chrono != null)
                {
                    username = chrono.Username;
                    password = CoreFunctions.Decrypt(chrono.Password, "KgtH(@C*&@Dhflosdf9f#&f");
                }

                if (!bool.Parse(EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportsUseIntegrated")))
                    return valid;

                _srs2006 = new ReportingService2006 { UseDefaultCredentials = true };
                var rptWs = _reportingServicesUrl + "/ReportService2006.asmx";
                _srs2006.Url = rptWs;

                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    if (password == "") return;
                    _srs2006.UseDefaultCredentials = false;
                    if (username.Contains("\\"))
                    {
                        _srs2006.Credentials = new NetworkCredential(username.Substring(username.IndexOf("\\") + 1),
                            password, username.Substring(0, username.IndexOf("\\")));
                    }
                    else
                    {
                        _srs2006.Credentials = new NetworkCredential(username, password);
                    }
                });

                try
                {
                    var authCookie = HttpContext.Current.Request.Cookies["FedAuth"];
                    var fedAuth = new Cookie(authCookie.Name, authCookie.Value, authCookie.Path, string.IsNullOrEmpty(authCookie.Domain) ? HttpContext.Current.Request.Url.Host : authCookie.Domain);
                    _srs2006.CookieContainer = new CookieContainer();
                    _srs2006.CookieContainer.Add(fedAuth);
                }
                catch { }

                valid = true;
            }
            catch { }

            return valid;
        }

        private string getReportParameters(string url)
        {

            var parameters = "";
            if (!SetupSSRS())
            {
                return parameters;
            }

            var parametersSSRS2006 = _srs2006.GetReportParameters(url, null, null, null);
            using (SPSite spSite = new SPSite(url))
            {
                SPWeb spWeb = spSite.OpenWeb();
                foreach (var rp in parametersSSRS2006)
                {
                    if (rp.Prompt != "") continue;
                    switch (rp.Name)
                    {
                        case "URL":
                            parameters += "&rp:URL=" + HttpUtility.UrlEncode(spWeb.ServerRelativeUrl);
                            break;
                        case "SiteId":
                            parameters += "&rp:SiteId=" + spWeb.Site.ID;
                            break;
                        case "WebId":
                            parameters += "&rp:WebId=" + spWeb.ID;
                            break;
                        case "UserId":
                            parameters += "&rp:UserId=" + spWeb.CurrentUser.ID;
                            break;
                        case "Username":
                            parameters += "&rp:Username=" + HttpContext.Current.User.Identity.Name;
                            break;
                    }
                }

            }

            return parameters;
        }
    }
}
