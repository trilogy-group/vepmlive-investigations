using System;
using System.Linq;
using System.Xml;
using EPMLiveCore.API;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive.Upgraders
{
    public partial class proxy : LayoutsPageBase
    {
        #region Fields (3) 

        private readonly string[] _optInUpgraderVersions = {"5.5.0", "5.6.0"};
        protected string data = "";
        protected int jobtype = 0;

        #endregion Fields 

        #region Methods (4) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            jobtype = Jobs.Upgrades.Steps.Utilities.GetJobType(Request["V"]);

            if (jobtype == 0) jobtype = 201;

            if (jobtype != 0)
            {
                switch (Request["Action"])
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

        // Private Methods (3) 

        private void CheckStatus()
        {
            XmlNode ndRes = Timer.GetTimerJobStatus(Web.Site.ID, Web.ID, jobtype, false);

            outputData(ndRes.Attributes["Status"].Value, ndRes.InnerText, ndRes.Attributes["PercentComplete"].Value);
        }

        private void outputData(string status, string message, string percent)
        {
            data = "Status: \"" + status + "\", Message: \"" + message + "\", Percent: \"" + percent + "\"";
        }

        private void Start()
        {
            try
            {
                XmlNode ndRes = Timer.GetTimerJobStatus(Web.Site.ID, Web.ID, jobtype, false);

                string status = ndRes.Attributes["Status"].Value;

                if (status == "0" || status == "1")
                    outputData("Success", "", "0");
                else
                {
                    Guid jobuid;

                    string version = Request["V"] ?? string.Empty;

                    if (jobtype == 201 && _optInUpgraderVersions.Contains(version))
                    {
                        jobuid = Timer.AddTimerJob(Web.Site.ID, Web.ID, "Opt-in Upgrader", jobtype, version,
                            string.Empty, -1, 9, string.Empty);
                    }
                    else
                    {
                        jobuid = Timer.AddTimerJob(Web.Site.ID, Web.ID, "Upgrader", jobtype,
                            Jobs.Upgrades.Steps.Utilities.GetJobName(version), "", -1, 9, "");
                    }

                    Timer.Enqueue(jobuid, 0, Web.Site);

                    outputData("Success", "", "0");

                    data += ", jobuid: \"" + jobuid + "\"";
                }
            }
            catch (Exception ex)
            {
                outputData("Error", ex.Message, "0");
            }
        }

        #endregion Methods 
    }
}