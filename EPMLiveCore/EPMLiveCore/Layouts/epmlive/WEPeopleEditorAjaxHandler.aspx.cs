using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Text;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class WEPeopleEditorAjaxHandler : LayoutsPageBase
    {
        //private string searchVal = string.Empty;
        protected string output = "";
        string xml = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //searchVal = Request["searchval"];
            IssueQuery();
            OutputResult();
        }

        private void IssueQuery()
        {
            XmlDocument docTeam = new XmlDocument();
            //docTeam.LoadXml(WorkEngineAPI.GetTeam("<GetTeam><Columns>Title,Username</Columns></GetTeam>"));
            //docTeam.LoadXml(WorkEngineAPI.GetTeam("<Filter Column='Title' Value='" + searchVal + "'/>"));
            docTeam.LoadXml(WorkEngineAPI.GetTeam("<GetTeam><Columns>Title,Email</Columns></GetTeam>", SPContext.Current.Web));
            xml = docTeam.OuterXml;
        }

        private void OutputResult()
        {  
            string jsonString = JSONUtil.ConvertXmlToJson(xml, "");
            if (!string.IsNullOrEmpty(jsonString))
            {
                output = jsonString;
                //output = xml;
            }
        }
    }
}
