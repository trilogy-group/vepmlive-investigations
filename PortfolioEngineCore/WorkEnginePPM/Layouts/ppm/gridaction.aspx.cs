using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class gridaction : System.Web.UI.Page
    {
        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "";
            try
            {
                SPWeb web = SPContext.Current.Web;
                SPSite site = web.Site;

                site.CatchAccessDeniedException = false;
                {
                    switch (Request["action"].ToLower())
                    {
                        case "postepkmultipage":
                            {
                                var result = GetTicket(Request["IDs"]);
                                data = result.Success ? result.Id : ("Post Error: " + result.Error);
                            }
                            break;
                        case "epkmultipage":
                            {
                                string epkurl = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPKURL");
                                var ticket = Request["ticket"];
                                var ids = Request["IDs"];

                                // if ticket is missing but ids passed, generate the ticket and do redirect
                                if (string.IsNullOrWhiteSpace(ticket) && !string.IsNullOrWhiteSpace(ids))
                                {
                                    var result = GetTicket(ids);
                                    if (result.Success)
                                    {
                                        ticket = result.Id;
                                    }
                                    else
                                    {
                                        data = result.Error;
                                        break;
                                    }
                                }

                                var serverRelativeUrl = web.ServerRelativeUrl == "/"
                                    ? string.Empty
                                    : web.ServerRelativeUrl;

                                var pathAndQuery = "/_layouts/ppm/" + Request["epkcontrol"] +
                                                 ".aspx?dataid=" + ticket +
                                                 "&epkurl=" + System.Web.HttpUtility.UrlEncode(epkurl) +
                                                 "&view=" + Request["view"] +
                                                 "&listid=" + Request["listid"] +
                                                 "&isresource=0";

                                url = serverRelativeUrl + pathAndQuery;
                            }
                            break;
                    }
                }

                url = url.Replace("//", "/");

                if (url != "")
                {
                    string source = Request["source"];
                    if (source != null && source != "")
                    {
                        if (url.Contains("?"))
                            url += "&source=" + source;
                        else
                            url += "?source=" + source;
                    }

                    // take the first argument
                    var isDialog = Request["isDlg"];
                    if (!string.IsNullOrWhiteSpace(isDialog) && isDialog.Contains(",")) isDialog = isDialog.Split(',')[0];
                    if (isDialog == "1" || isDialog == "0")
                    {
                        url += "&IsDlg=" + isDialog;
                    }

                    Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {
                data = "General Error: " + ex.Message;
            }

        }

        private GenerateTicketResponse GetTicket(string ids)
        {
            var doc = new XmlDocument();
            var status = string.Empty;
            var result = new GenerateTicketResponse();

            using (var analyzerManager = new WorkEnginePPM.WebServices.Core.AnalyzerManager(SPContext.Current.Web))
            {
                var response = analyzerManager.GenerateDataTicket("<Generate><Ticket>" + ids.ToLower() + "</Ticket></Generate>");
                doc.LoadXml(response);
                status = doc.SelectSingleNode("//Result").Attributes["Status"].Value;

                if (status == "0")
                {
                    result.Id = doc.SelectSingleNode("//Ticket").Attributes["Id"].Value;
                    result.Success = true;
                }
                else
                {
                    result.Error = doc.SelectSingleNode("//Error").InnerText;
                }
            }

            return result;
        }
    }
}