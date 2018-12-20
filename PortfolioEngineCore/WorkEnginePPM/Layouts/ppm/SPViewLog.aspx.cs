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
            return SPHelper.ExecuteProcess(sContext, sXMLRequest, out xNode);
        }

        private static bool ExecuteProcessEx(string sURL, string sContext, string sXMLRequest, out XmlNode xNode)
        {
            return SPHelper.ExecuteProcessEx(sContext, sXMLRequest, out xNode);
        }

        private void populateStatus()
        {
            SPHelper.PopulateStatus(lblGeneralError, lblLastRun, lblLastRunResult, lblStatus, lblLog);
        }
    }
}