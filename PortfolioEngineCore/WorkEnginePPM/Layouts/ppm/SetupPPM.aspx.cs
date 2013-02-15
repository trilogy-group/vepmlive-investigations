using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Xml;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class SetupPPM : LayoutsPageBase
    {
        private bool overriden()
        {
            if(!string.IsNullOrEmpty(Request["override"]))
            {
                if(Request["override"].ToLower() == "f772e8e7-1e12-46c1-8547-f0d7a3bb89bf")
                    return true;
            }
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                EPMLiveCore.Act act = new EPMLiveCore.Act(Web);
                if(act.IsOnline && !overriden())
                {
                    ReportError("Operation not allowed.");
                    pnlMain.Visible = false;
                }
                else if(!string.IsNullOrEmpty(EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "epkbasepath")))
                {
                    ReportError("This site is already configured for PortfolioEngine.");
                    pnlMain.Visible = false;
                }
                else{

                    SPList list = Web.Lists.TryGetList("PFEScripts");
                    if(list == null)
                    {
                        ReportError("The PFEScripts list could not be found");
                        pnlMain.Visible = false;
                    }
                    else if(list.ItemCount == 0)
                    {
                        ReportError("The PFEScripts list is empty. Either a site has already been configured or this is not a valid template.");
                        pnlMain.Visible = false;
                    }
                    else
                    {
                        string[] sUrl = Web.Url.Split('/');
                        txtBasePath.Text = sUrl[sUrl.Length - 1].ToLower();
                    }
                }
            }
        }

        private void ReportError(string error)
        {
            lblError.Text = error;
            lblError.Visible = true;
            //pnlMain.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Settings><BasePath>" + txtBasePath.Text  + "</BasePath><PID>" + txtPID.Text + "</PID><Company>" + txtCompany.Text + "</Company><DBServer>" + txtDBServer.Text + "</DBServer><DB>" + txtDB.Text + "</DB><Username>" + txtUsername.Text + "</Username><Password>" + txtPassword.Text + "</Password></Settings>");

            Guid jobid = EPMLiveCore.API.Timer.AddTimerJob(Web.Site.ID, Web.ID, "Setup PfE", 82, doc.OuterXml, "", 0, 0, "");
            EPMLiveCore.API.Timer.Enqueue(jobid, 0, Web.Site);


            SPUtility.Redirect("ppm/setupstatus.aspx?jobid=" + jobid, SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
        }
    }
}
