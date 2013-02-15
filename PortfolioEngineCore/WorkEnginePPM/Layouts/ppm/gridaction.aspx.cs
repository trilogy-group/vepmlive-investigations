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
            string script = "";
            try
            {
                SPWeb web = SPContext.Current.Web;
                SPSite site = web.Site;

                site.CatchAccessDeniedException = false;
                {
                    SPWeb w;

                    switch(Request["action"].ToLower())
                    {
                        case "postepkmultipage":
                            {

                                XmlDocument doc = new XmlDocument();
                                string response = "";
                                using(var analyzerManager = new WorkEnginePPM.WebServices.Core.AnalyzerManager(SPContext.Current.Web))
                                {
                                    response = analyzerManager.GenerateDataTicket("<Generate><Ticket>" + Request["IDs"].ToLower() + "</Ticket></Generate>");
                                }

                                doc.LoadXml(response);

                                string status = doc.SelectSingleNode("//Result").Attributes["Status"].Value;
                                if(status == "0")
                                {
                                    data = doc.SelectSingleNode("//Ticket").Attributes["Id"].Value;
                                }
                                else
                                {
                                    data = "Post Error: " + doc.SelectSingleNode("//Error").InnerText;
                                }
                                
                            }
                            break;
                        case "epkmultipage":
                            {
                                string epkurl = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPKURL");

                                url = ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_layouts/ppm/" + Request["epkcontrol"] + ".aspx?dataid=" + Request["ticket"] + "&epkurl=" + System.Web.HttpUtility.UrlEncode(epkurl) + "&view=" + Request["view"] + "&listid=" + Request["listid"] + "&isresource=0";
                            }
                            break;
                    }
                }

                url = url.Replace("//", "/");

                if(url != "")
                {
                    string source = Request["source"];
                    if(source != null && source != "")
                    {
                        if(url.Contains("?"))
                            url += "&source=" + source;
                        else
                            url += "?source=" + source;
                    }
                    if(Request["isDlg"] == "1")
                        url += "&IsDlg=1";
                    Response.Redirect(url);
                }
            }
            catch (Exception ex)
            {
                data = "General Error: " + ex.Message;
            }

        }
    }
}
