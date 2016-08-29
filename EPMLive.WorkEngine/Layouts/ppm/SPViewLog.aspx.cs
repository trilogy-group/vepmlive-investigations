using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;

using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class SPViewLog : LayoutsPageBase
    {
        private string url = "";
        private DataTable dtFields = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Master.InitializePage();
            //this.Master.SetTitle("View Log");

            if (!IsPostBack)
            {
                //url = LMR_IF.getSiteUrl();
                //if (url != "")
                //{
                    //pnlNoUrl.Visible = false;
                    populateStatus();
                //}
                //else
                //{
                //    pnlMain.Visible = false;
                //}
            }
        }

        private static bool ExecuteProcess(string sContext, string sXMLRequest, out XmlNode xNode)
        {
            xNode = null;
            return ExecuteProcessEx("", sContext, sXMLRequest, out xNode);
        }

        private static bool ExecuteProcessEx(string sURL, string sContext, string sXMLRequest, out XmlNode xNode)
        {
            xNode = null;
            bool b = true;
            Integration integration = new Integration();
            xNode = integration.execute(sContext, sXMLRequest);
            integration = null;
            return b;
        }

        private void populateStatus()
        {
            XmlNode ndStatus = null;
            if (ExecuteProcess("GetTimerStatus", "<Status Schedule=\"10\"/>", out ndStatus) == false)
            {
                lblGeneralError.Text = "Error populateStatus : GetTimerStatus";
                lblGeneralError.Visible = true;
                return;
            }
            if (ndStatus.Attributes["Status"].Value == "0")
            {
                XmlNode ndTimer = ndStatus.SelectSingleNode("Timer");
                if (ndTimer != null)
                {
                    switch (ndTimer.Attributes["Status"].Value)
                    {
                        case "0":
                            lblStatus.Text = "Queued";
                            break;
                        case "1":
                            lblStatus.Text = "Processing (" + ndTimer.Attributes["PercentComplete"].Value + "%)";
                            break;
                        case "2":
                            lblStatus.Text = "Complete";
                            break;
                    };
                    lblLastRun.Text = ndTimer.Attributes["LastRun"].Value;
                    lblLastRunResult.Text = ndTimer.Attributes["LastResult"].Value;
                    lblLog.Text = ndTimer.InnerText;
                }
            }
            else
            {
                lblGeneralError.Text = "Error Getting Status: " + ndStatus.SelectSingleNode("Error").InnerText;
                lblGeneralError.Visible = true;
            }
        }
    }
}