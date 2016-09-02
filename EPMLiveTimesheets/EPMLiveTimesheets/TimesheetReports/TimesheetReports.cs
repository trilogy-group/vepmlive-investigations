using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace TimeSheets
{
    [Guid("695674b8-bcad-440e-95bf-f81bc4e1232a")]
    [ToolboxData("<{0}:TimeSheetReports runat=server></{0}:TimeSheetReports>")]
    [XmlRoot(Namespace = "TimeSheetReports")]
    public class TimeSheetReports : Microsoft.SharePoint.WebPartPages.WebPart
    {
        private int activation;
        private string error;
        private EPMLiveCore.Act act;
        public TimeSheetReports()
        {
        }

        protected override void CreateChildControls()
        {
            try
            {
                act = new EPMLiveCore.Act(SPContext.Current.Web);
                activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.Timesheets);
                if (activation != 0)
                    return;

                base.CreateChildControls();

                // TODO: add custom rendering code here.
                // Label label = new Label();
                // label.Text = "Hello World";
                // this.Controls.Add(label);
            }
            catch (Exception ex)
            {
                error = "Error Creating Controls: " + ex.Message;
            }
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            output.Write(error);

            if (activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            output.Write("<table border=\"0\" cellpadding=\"3\" cellspacing=\"0\">");

            SPWeb web = SPContext.Current.Web;

            string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);

            if (resUrl != "")
            {
                SPWeb resWeb = null;
                try
                {
                    if (resUrl.ToLower() != web.Url.ToLower())
                    {
                        using (SPSite tempSite = new SPSite(resUrl))
                        {

                            resWeb = tempSite.OpenWeb();
                            if (resWeb.Url.ToLower() != resUrl.ToLower())
                            {
                                resWeb = null;
                            }
                        }
                    }
                    else
                        resWeb = web;
                }
                catch { }

                if (resWeb != null)
                {
                    try
                    {
                        SPList list = resWeb.Lists["Resources"];

                        SPQuery query = new SPQuery();
                        query.Query = "<Where><Eq><FieldRef Name='TimesheetManager'/><Value Type='User'><UserID/></Value></Eq></Where>";

                        SPListItemCollection lic = list.GetItems(query);

                        bool hasReports = false;

                        if (lic.Count > 0)
                        {
                            hasReports = true;
                            output.Write("<tr><td><img src=\"/_layouts/images/XLS16.GIF\"></td><td><a href=\"#\" onclick=\"window.open('" + web.Url + "/_layouts/epmlive/gettsreport.aspx?report=1','', config='height=270,width=340, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no');\">Timesheet Manager Report</a></td></tr>");
                        }

                        query = new SPQuery();
                        query.Query = "<Where><Eq><FieldRef Name='SharePointAccount'/><Value Type='User'><UserID/></Value></Eq></Where>";

                        lic = list.GetItems(query);

                        if (lic.Count > 0)
                        {
                            try
                            {
                                if (lic[0]["TimesheetAdministrator"].ToString().ToLower() == "true")
                                {
                                    hasReports = true;
                                    output.Write("<tr><td><img src=\"/_layouts/images/XLS16.GIF\"></td><td><a href=\"#\" onclick=\"window.open('" + web.Url + "/_layouts/epmlive/gettsreport.aspx?report=2','', config='height=270,width=340, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no');\">Administrative Report</a></td></tr>");
                                }
                            }
                            catch { }
                        }

                        query = new SPQuery();
                        query.Query = "<Where><Eq><FieldRef Name='SharePointAccount'/><Value Type='User'><UserID/></Value></Eq></Where>";

                        lic = list.GetItems(query);

                        if (lic.Count > 0)
                        {
                            try
                            {
                                hasReports = true;
                                output.Write("<tr><td><img src=\"/_layouts/images/XLS16.GIF\"></td><td><a href=\"#\" onclick=\"window.open('" + web.Url + "/_layouts/epmlive/gettsreport.aspx?report=3','', config='height=270,width=340, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no');\">My Timesheet Report</a></td></tr>");
                            }
                            catch { }
                        }

                        if (!hasReports)
                        {
                            output.Write("<tr><td>No Available Reports.</td></tr>");
                        }

                    }
                    catch (Exception ex1)
                    {
                        output.Write("<tr><td>Error: + " + ex1.Message + "</td></tr>");
                    }
                    if (resWeb.ID != SPContext.Current.Web.ID)
                        resWeb.Close();
                }
                else
                {
                    output.Write("<tr><td>Failed to open Resource Pool.</td></tr>");
                }
            }
            else
            {
                output.Write("<tr><td>Resource Pool Not Configured.</td></tr>");
            }
            output.Write("</table>");
        }
    }
}
