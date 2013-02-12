using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;

namespace EPMLiveCore.Layouts.epmlive.Upgraders
{
    public partial class proxy : LayoutsPageBase
    {
        protected string data = "";
        protected int jobtype = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            jobtype = Jobs.Upgrades.Steps.Utilities.GetJobType(Request["V"]);

            if(jobtype != 0)
            {
                switch(Request["Action"])
                {
                    case "Start":
                        Start();
                        break;
                    case "CheckStatus":
                        CheckStatus();
                        break;
                    default:
                        outputData("Error", "Invalid Proxy Command", "0");
                        break;
                }
            }
            else
            {
                outputData("Error", "Invalid Version", "0");
            }
        }

        private void outputData(string status, string message, string percent)
        {
            data = "Status: \"" + status + "\", Message: \"" + message + "\", Percent: \"" + percent + "\"";
        }

        

        private void CheckStatus()
        {
            XmlNode ndRes = API.Timer.GetTimerJobStatus(Web.Site.ID, Web.ID, jobtype, false);

            outputData(ndRes.Attributes["Status"].Value, ndRes.InnerText, ndRes.Attributes["PercentComplete"].Value);
        }

        private void Start()
        {
            try
            {

                XmlNode ndRes = API.Timer.GetTimerJobStatus(Web.Site.ID, Web.ID, jobtype, false);

                string status = ndRes.Attributes["Status"].Value;

                if(status == "0" || status == "1")
                    outputData("Success", "", "0");
                else
                {
                    Guid jobuid = API.Timer.AddTimerJob(Web.Site.ID, Web.ID, "Upgrader", jobtype, Jobs.Upgrades.Steps.Utilities.GetJobName(Request["V"]), "", -1, 9, "");

                    API.Timer.Enqueue(jobuid, 0, Web.Site);

                    outputData("Success", "", "0");

                    data += ", jobuid: \"" + jobuid.ToString() + "\"";
                }
            }
            catch(Exception ex)
            {

                outputData("Error", ex.Message, "0");
                
            }
        }
    }
}
