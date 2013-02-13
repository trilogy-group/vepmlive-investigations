using System;
using Microsoft.SharePoint.WebPartPages;
using System.Web.UI;


namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:CustomToolPart runat=server></{0}:CustomToolPart>")]
    public class ReportingServicesToolPart : ToolPart
    {
        public ReportingServicesToolPart()
        {
            AllowMinimize = true;
            UseDefaultStyles = true;
            Title = "Reporting Services Reports";
        }
       
        protected override void RenderToolPart(HtmlTextWriter output)
        {
            base.RenderToolPart(output);
            var tp = ParentToolPane;
            var myWp = (ListReportView)tp.SelectedWebPart;
            output.Write("<div class=\"UserSectionTitle\">");

            output.Write("<script type=\"text/javascript\">function HandleClick(status) { if(status == true ) { document.getElementById('txtReportPath').disabled = true;document.getElementById('txtReportServicesUrl').disabled = true;document.getElementById('cbInteMode').disabled = true; if(document.getElementById('txtReportPath').value ==''){document.getElementById('txtReportPath').value = 'Using application defaults.';} if(document.getElementById('txtReportServicesUrl').value ==''){document.getElementById('txtReportServicesUrl').value = 'Using application defaults.';}} else { document.getElementById('txtReportPath').disabled = false;document.getElementById('txtReportServicesUrl').disabled = false; document.getElementById('cbInteMode').disabled = false;if(document.getElementById('txtReportPath').value =='Using application defaults.'){document.getElementById('txtReportPath').value = '';}if(document.getElementById('txtReportServicesUrl').value =='Using application defaults.'){document.getElementById('txtReportServicesUrl').value = '';}} }</script>");
            output.Write("<table style=\"PADDING-LEFT: 5px\" cellPadding=\"1\">");
            output.Write("<tbody>");
            output.Write("<tr>");
            output.Write("<td>");

            if (!myWp.UseDefaults)
            {
                output.Write("<input type=\"checkbox\" name=\"cbAppDeffault\" id = \"cbAppDeffault\"  value=\"true\"  onClick=\"HandleClick(this.checked)\" />Use Application Defaults");
            }
            else
            {
                output.Write("<input type=\"checkbox\" name=\"cbAppDeffault\" id = \"cbAppDeffault\"  value=\"true\"  onClick= \"HandleClick(this.checked)\" checked=\"checked\"   />Use Application Defaults");
            }

            output.Write("</td>");
            output.Write("</tr>");

            output.Write("<tr>");
            output.Write("<td>");
            if (myWp.IsTopList == null || myWp.IsTopList.Value)
            {
                output.Write("<input type=\"checkbox\" name=\"cbRollup\" id = \"cbRollup\" checked=\"checked\" value=\"true\" />Rollup Reports");
            }
            else
            {
                output.Write("<input type=\"checkbox\" name=\"cbRollup\" id = \"cbRollup\" value=\"true\" />Rollup Reports");
            }

            output.Write("</td>");
            output.Write("</tr>");

            output.Write("<tr>");
            output.Write("<td>");
            output.Write("<label>Reports Path</label>");
            output.Write("</td>");
            output.Write("</tr>");

            output.Write("<tr>");
            output.Write("<td>");
            if (myWp.UseDefaults)
            {
                output.Write("<input type=\"text\" name=\"txReportPath\" id = \"txtReportPath\" disabled=\"disabled\" size=\"30\" value=\"Using application defaults.\" />");
            }
            else
            {
                output.Write("<input type=\"text\" name=\"txtReportPath\" id = \"txtReportPath\"  size=\"30\" value=\"" + myWp.PropReportsPath + "\"/>");
            }
            output.Write("</td>");
            output.Write("</tr>");

            output.Write("<tr>");
            output.Write("<td>");
            output.Write("<label>SQL Reporting Services URL</label>");
            output.Write("</td>");
            output.Write("</tr>");

            output.Write("<tr>");
            output.Write("<td>");
            if (myWp.UseDefaults)
            {
                output.Write("<input type=\"text\" name=\"txtReportServicesUrl\"  id = \"txtReportServicesUrl\" size=\"30\" disabled=\"disabled\" value=\"Using application defaults.\" />");
            }
            else
            {
                output.Write("<input type=\"text\" name=\"txtReportServicesUrl\"  id = \"txtReportServicesUrl\" size=\"30\" value=\"" + myWp.PropSRSUrl + "\"/>");
            }
            output.Write("</td>");
            output.Write("</tr>");

            output.Write("<tr>");
            output.Write("<td>");

            if (myWp.UseDefaults)
            {
                if (myWp.IsIntegratedMode)
                {
                    output.Write("<input type=\"checkbox\" name=\"cbInteMode\" id = \"cbInteMode\" checked=\"checked\" value=\"true\"   disabled=\"disabled\" />Use Integrated Mode");
                }
                else
                {
                    output.Write("<input type=\"checkbox\" name=\"cbInteMode\" id = \"cbInteMode\" value=\"true\"   disabled=\"disabled\"/>Use Integrated Mode");
                }
            }
            else
            {
                if (myWp.IsIntegratedMode)
                {
                    output.Write("<input type=\"checkbox\" name=\"cbInteMode\" id = \"cbInteMode\" checked=\"checked\" value=\"true\"   />Use Integrated Mode");
                }
                else
                {
                    output.Write("<input type=\"checkbox\" name=\"cbInteMode\" id = \"cbInteMode\" value=\"true\" />Use Integrated Mode");
                }
            }
            output.Write("</td>");
            output.Write("</tr>");

            output.Write("</tbody>");
            output.Write("</table>");
            output.Write("</div>");
        }

        protected override void CreateChildControls()
        {
        }

        public override void ApplyChanges()
        {
            var parentToolPane = ParentToolPane;
            var myWp = (ListReportView)parentToolPane.SelectedWebPart;
            myWp.IsTopList = Page.Request.Form["cbRollup"] != null && Convert.ToBoolean(Page.Request.Form["cbRollup"]);
            myWp.PropSRSUrl = Page.Request.Form["txtReportServicesUrl"];
            myWp.PropReportsPath = Page.Request.Form["txtReportPath"];
            myWp.UseDefaults = Page.Request.Form["cbAppDeffault"] != null && Convert.ToBoolean(Page.Request.Form["cbAppDeffault"]);
            myWp.IsIntegratedMode = Page.Request.Form["cbInteMode"] != null && Convert.ToBoolean(Page.Request.Form["cbInteMode"]);
        }
    }
}
