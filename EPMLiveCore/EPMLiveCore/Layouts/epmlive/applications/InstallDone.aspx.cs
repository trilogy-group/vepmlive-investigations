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
    public partial class InstallDone : LayoutsPageBase
    {
        protected string ApplicationName = "";
        protected StringBuilder sbOutput = new StringBuilder();
        protected int maxError = 0;
        protected string sFullWebUrl = "";
        protected string newAppId = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            sFullWebUrl = Web.Url;
            API.ApplicationDef appDef = API.Applications.GetApplicationInfo(Request["AppId"]);

            ApplicationName = appDef.Title;

            if(appDef.Community != "")
            {
                try
                {
                    SPList list = API.Applications.GetApplicationList(Web);

                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + Request["AppId"] + "</Value></Eq></Where>";

                    SPListItemCollection lic = list.GetItems(query);

                    if(lic.Count > 0)
                    {

                        newAppId = lic[0]["LinkedCommunity"].ToString();
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    newAppId = Request["CommId"].ToString();
                }
                catch { }
            }

            int jobid = 51;

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
                        sbOutput.Append("<div class=\"alert alert-success\">This application has successfully installed into your community.</div>");
                        break;
                    case 5:
                        sbOutput.Append("<div class=\"alert alert-warning\">This application has been installed in your community but there was 1 or more warnings. Click view details to get more information.</div>");
                        break;
                    case 10:
                        sbOutput.Append("<div class=\"alert alert-error\">This application has been installed in your community, but there was 1 or more errors during install. Click view details to get more information.</div>");
                        break;
                };



            }
            catch
            {

                sbOutput.Append("Error: " + sMessage);

            }
        }

        private void appendTable(int level, DataTable dt, XmlNode ndItem)
        {
            foreach(XmlNode ndChild in ndItem.SelectNodes("MessageRow"))
            {
                string spacing = "";

                for(int i = 0; i < level; i++)
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
