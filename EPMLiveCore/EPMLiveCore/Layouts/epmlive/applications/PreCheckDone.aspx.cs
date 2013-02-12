using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class PreCheckDone : LayoutsPageBase
    {
        protected string ApplicationName = "";
        protected StringBuilder sbOutput = new StringBuilder();
        protected int maxError = 0;
        protected string sWebUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            Act act = new Act(Web);

            if(act.CheckFeatureLicense(ActFeature.AppsAndCommunities) != 0)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/applications/noact.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

            API.ApplicationDef appDef = API.Applications.GetApplicationInfo(Request["AppId"]);

            ApplicationName = appDef.Title;

            sWebUrl = Web.ServerRelativeUrl;

            int jobid = 51;

            if(appDef.bIsConfigOnly)
                jobid = 52;

            XmlNode ndStatus = API.Applications.GetApplicationStatusMessage(Request["AppId"], SPContext.Current.Web, jobid);

            string sStatus = ndStatus.SelectSingleNode("Status").InnerText;
            string sMessage = ndStatus.SelectSingleNode("Message").InnerText;

            sMessage = System.Web.HttpUtility.HtmlDecode(sMessage);

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(sMessage);

                DataTable dt = new DataTable();
                dt.Columns.Add("Status");
                dt.Columns.Add("Message");
                dt.Columns.Add("Detail");
                dt.Columns.Add("Level");

                appendTable(0, dt, doc.FirstChild);

                GridView2.DataSource = dt;
                GridView2.DataBind();


                switch(maxError)
                {
                    case 0:
                    case 1:
                        sbOutput.Append("<div class=\"alert alert-success\">This application has successfully passed the precheck.</div>");
                        break;
                    case 5:
                        sbOutput.Append("<div class=\"alert alert-warning\">This application has passed the precheck but there are 1 or more warnings. Click view details to get more information.</div>");
                        break;
                    case 10:
                        sbOutput.Append("<div class=\"alert alert-error\">This application has failed to pass the precheck. Click view details to get more information.</div>");
                        break;
                };

            }
            catch {

                sbOutput.Append("Error: " + sMessage);

            }
        }

        private void appendTable(int level, DataTable dt, XmlNode ndItem)
        {
            foreach(XmlNode ndChild in ndItem.SelectNodes("MessageRow"))
            {
                string spacing = "";

                for(int i = 0;i<level;i++)
                    spacing += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

                dt.Rows.Add(new object[] { ndChild.Attributes["ErrorLevel"].Value, spacing + ndChild.SelectSingleNode("Message").InnerText, ndChild.SelectSingleNode("Details").InnerText, level });

                appendTable(level + 1, dt, ndChild);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType != DataControlRowType.DataRow)
                return;

            if(((DataRowView)e.Row.DataItem).Row[3].ToString() == "0")
            {
                e.Row.Cells[1].Text = "<font style=\"font-size: 16px; font-weight:bold\">" + e.Row.Cells[1].Text + "</font>";
            }

            switch(((DataRowView)e.Row.DataItem).Row[0].ToString())
            {
                case "0":
                    e.Row.Cells[0].Text = "<SPAN class=\"label label-success\">Success</SPAN>";
                    break;
                case "1":
                    e.Row.Cells[0].Text = "<SPAN class=\"label label-info\">Info</SPAN>";
                    break;
                case "5":
                    if(maxError < 5)
                        maxError = 5;
                    e.Row.Cells[0].Text = "<SPAN class=\"label label-warning\">Warning</SPAN>";
                    break;
                case "10":
                    if(maxError < 10)
                        maxError = 10;
                    e.Row.Cells[0].Text = "<SPAN class=\"label label-important\">Error</SPAN>";
                    break;
            }
        }

    }
}
