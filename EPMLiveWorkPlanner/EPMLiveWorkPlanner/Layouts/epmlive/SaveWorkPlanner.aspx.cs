using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using System.Text;
using System.Xml;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class SaveWorkPlanner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/xml";
            Response.Charset = "utf-8";
            Response.AppendHeader("Cache-Control", "max-age=1, must-revalidate");

            XmlDocument docGrid = new XmlDocument();
            docGrid.LoadXml(HttpUtility.HtmlDecode(Request["TGData"]));

            XmlDocument docGridSettings = new XmlDocument();
            docGridSettings.LoadXml(HttpUtility.HtmlDecode(Request["Dataxml"]));

            XmlAttribute attr = docGrid.CreateAttribute("ID");
            attr.Value = docGridSettings.FirstChild.Attributes["ID"].Value;

            docGrid.FirstChild.Attributes.Append(attr);

            attr = docGrid.CreateAttribute("Planner");
            attr.Value = docGridSettings.FirstChild.Attributes["Planner"].Value;

            docGrid.FirstChild.Attributes.Append(attr);

            string response = WorkPlannerAPI.SaveWorkPlan(docGrid, SPContext .Current.Web);

            Response.Write(response);
        }

        
    }
}
