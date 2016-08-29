using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.IO;
using System.Data;
using System.Web;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class PlannerUpdates : LayoutsPageBase
    {
        protected string sParam = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            sParam = "<Grid View='' ID='" + Request["ID"] + "' Planner='" + Request["PlannerID"] + "'/>";

            sParam = HttpUtility.HtmlEncode(HttpUtility.HtmlEncode(sParam));
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {

        }
    }
}
