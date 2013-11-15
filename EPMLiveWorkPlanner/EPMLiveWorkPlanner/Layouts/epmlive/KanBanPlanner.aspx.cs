using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EPMLiveWorkPlanner.Layouts.EPMLiveWorkPlanner;
using System.Text;

namespace EPMLiveWorkPlanner
{
    public partial class KanBanPlanner : LayoutsPageBase
    {
        public string strPlanner
        {
            get
            {
                return Convert.ToString(Request["planner"]);
            }
        }

        public string strProjectId
        {
            get
            {
                return Convert.ToString(Request["ID"]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
