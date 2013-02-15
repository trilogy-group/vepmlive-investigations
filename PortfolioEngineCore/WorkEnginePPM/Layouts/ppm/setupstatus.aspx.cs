using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class setupstatus : LayoutsPageBase
    {
        protected string sStatus = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            XmlNode ndResult = EPMLiveCore.API.Timer.GetTimerJobStatus(Web, new Guid(Request["jobid"]));

            string statusid = ndResult.Attributes["Status"].Value;

            switch(statusid)
            {
                case "0":
                    sStatus = "Queued";
                    break;
                case "1":
                    sStatus = "Processing...";
                    break;
                case "2":
                    sStatus = "Complete<br><br>Results: " + ndResult.Attributes["Result"].Value;
                    if(ndResult.Attributes["Result"].Value == "Errors")
                        sStatus += "<br><br>" + System.Web.HttpUtility.HtmlDecode(ndResult.InnerText);
                    break;
            }

        }
    }
}
