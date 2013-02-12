using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Text;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class BuildTeamHelper : LayoutsPageBase
    {
        //private string searchVal = string.Empty;
        protected string output = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            switch(Request["Command"])
            {
                case "GetReports":
                    GetReports();
                    break;
                case "GoToReport":

                    Response.Redirect(System.Web.HttpUtility.UrlDecode(Request["surl"]));

                    break;
            }
        }

        private void GetReports()
        {
            XmlDocument doc = new XmlDocument();
            using(var workEngineAPI = new WorkEngineAPI())
            {
                doc.LoadXml(workEngineAPI.Execute("Reporting_GetAllReports", string.Empty));
            }

            if(doc.FirstChild.Attributes["Status"].Value == "0")
            {
                try
                {
                    XmlNode ndReports = doc.FirstChild.SelectSingleNode("//Data").FirstChild.SelectSingleNode("Folder[@Name='epmlivetl']").SelectSingleNode("Folder[@Name='(2) Resource']");

                    StringBuilder sb = new StringBuilder();

                    foreach(XmlNode nd in ndReports.SelectNodes("Report"))
                    {

                        sb.Append("<Button");
                        sb.Append(" Id=\'Ribbon.BuildTeam.ToolsGroup.Reports.ShowReport");
                        //sb.Append(nd.Attributes["Name"].Value.Replace(" ",""));
                        sb.Append("\' Command='Ribbon.BuildTeam.ShowReport\'");
                        sb.Append(" CommandValueId='");
                        sb.Append(System.Web.HttpUtility.UrlEncode(nd.Attributes["Url"].Value));
                        sb.Append("'");
                        sb.Append(" LabelText=\'");
                        sb.Append(nd.Attributes["Name"].Value);
                        sb.Append("\'/>");
                    }

                    output = sb.ToString();
                }
                catch { }


            }
            else
            {
                output = "Error";
            }

        }
    }
}
