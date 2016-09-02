using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.SSRS2006;
using EPMLiveCore.SSRS2005;
using System.Net;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class resourcecapacity : LayoutsPageBase
    {
        ReportingService2006 srs2006;
        ReportingService2005 srs2005;

        SSRS2006.ReportParameter[] parametersSSRS2006 = null;
        SSRS2005.ReportParameter[] parametersSSRS2005 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        string customUrl = "";
                        string url = "";
                        bool integrated = false;

                        string ssrsUrl = CoreFunctions.getWebAppSetting(web.Site.WebApplication.Id, "ReportingServicesURL");
                        bool.TryParse(CoreFunctions.getWebAppSetting(site.WebApplication.Id, "ReportsUseIntegrated"), out integrated);
                        string username = "";
                        string password = "";

                        ReportAuth _chrono = site.WebApplication.GetChild<ReportAuth>("ReportAuth");
                        if (_chrono != null)
                        {
                            username = _chrono.Username;
                            password = CoreFunctions.Decrypt(_chrono.Password, "KgtH(@C*&@Dhflosdf9f#&f");
                        }
                        Guid lGuid = CoreFunctions.getLockedWeb(web);
                        if (lGuid != web.ID)
                        {
                            using (SPWeb lWeb = site.OpenWeb(lGuid))
                            {
                                customUrl = CoreFunctions.getConfigSetting(lWeb, "ResToolsReportURL");
                            }   
                        }
                        else
                        {
                            customUrl = CoreFunctions.getConfigSetting(web, "ResToolsReportURL");
                            
                        }
                        
                        
                        if (ssrsUrl != "")
                        {
                            try
                            {
                                if (integrated)
                                {
                                    srs2006 = new ReportingService2006();
                                    srs2006.UseDefaultCredentials = true;
                                    string rptWS = ssrsUrl + "/ReportService2006.asmx";
                                    srs2006.Url = rptWS;
                                    if (username != "")
                                    {
                                        srs2006.UseDefaultCredentials = false;
                                        if (username.Contains("\\"))
                                        {
                                            srs2006.Credentials = new NetworkCredential(username.Substring(username.IndexOf("\\") + 1), password, username.Substring(0, username.IndexOf("\\")));
                                        }
                                        else
                                        {
                                            srs2006.Credentials = new NetworkCredential(username, password);
                                        }
                                    }

                                    if (customUrl == "")
                                        customUrl = "/Report Library/Resource Work vs. Capacity.rdl";
                                    string sparams = RS(site.RootWeb.Url + customUrl, web);

                                    url = ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl=" + ((site.RootWeb.ServerRelativeUrl == "/") ? "" : site.RootWeb.ServerRelativeUrl) + customUrl + sparams;
                                }
                                else
                                {
                                    srs2005 = new ReportingService2005();
                                    srs2005.UseDefaultCredentials = true;
                                    string rptWS = ssrsUrl + "/ReportService2005.asmx";
                                    srs2005.Url = rptWS;
                                    if (username != "")
                                    {
                                        srs2005.UseDefaultCredentials = false;
                                        if (username.Contains("\\"))
                                        {
                                            srs2005.Credentials = new NetworkCredential(username.Substring(username.IndexOf("\\") + 1), password, username.Substring(0, username.IndexOf("\\")));
                                        }
                                        else
                                        {
                                            srs2005.Credentials = new NetworkCredential(username, password);
                                        }
                                    }

                                    if (customUrl == "")
                                        customUrl = "/Resource Work vs. Capacity";
                                    string sparams = RSNOIM(customUrl, web);

                                    url = ssrsUrl + "?" + customUrl + sparams;
                                }
                                Response.Redirect(url);
                            }
                            catch (Exception ex)
                            {
                                lblError.Text = "Error: " + ex.Message;
                            }
                        }
                        else
                        {
                            lblError.Text = "Reporting Services URL not set";
                        }
                    }
                }
            });
        }

        private string RSNOIM(string url, SPWeb web)
        {

            parametersSSRS2005 = srs2005.GetReportParameters(url, null, true, null, null);
            string parameters = "";
            foreach (SSRS2005.ReportParameter rp in parametersSSRS2005)
            {
                if (rp.Prompt == "")
                {
                    switch (rp.Name)
                    {
                        case "URL":
                            parameters += "&URL=" + HttpUtility.UrlEncode(web.ServerRelativeUrl);
                            break;
                        case "SiteId":
                            parameters += "&SiteId=" + SPContext.Current.Site.ID;
                            break;
                        case "WebId":
                            parameters += "&WebId=" + SPContext.Current.Web.ID;
                            break;
                        case "UserId":
                            parameters += "&UserId=" + SPContext.Current.Web.CurrentUser.ID;
                            break;
                        case "Username":
                            parameters += "&Username=" + HttpContext.Current.User.Identity.Name;
                            break;
                    };
                }
            }
            return (parameters);
        }

        private string RS(string url, SPWeb web)
        {
            parametersSSRS2006 = srs2006.GetReportParameters(url, null, null, null);
            string parameters = "";
            foreach (SSRS2006.ReportParameter rp in parametersSSRS2006)
            {
                if (rp.Prompt == "")
                {
                    switch (rp.Name)
                    {
                        case "URL":
                            parameters += "&rp:URL=" + HttpUtility.UrlEncode(web.ServerRelativeUrl);
                            break;
                        case "SiteId":
                            parameters += "&rp:SiteId=" + SPContext.Current.Site.ID;
                            break;
                        case "WebId":
                            parameters += "&rp:WebId=" + SPContext.Current.Web.ID;
                            break;
                        case "UserId":
                            parameters += "&rp:UserId=" + SPContext.Current.Web.CurrentUser.ID;
                            break;
                        case "Username":
                            parameters += "&rp:Username=" + HttpContext.Current.User.Identity.Name;
                            break;
                    };
                }
            }
            return (parameters);
        }
    }
}
