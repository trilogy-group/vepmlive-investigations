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
using System.Data.SqlClient;

namespace TimeSheets
{
    public partial class timesheetapprovalpage : System.Web.UI.Page
    {
        protected string data = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            data = TimesheetAPI.GetTimesheetApprovalsGridPage(Request["Data"], SPContext.Current.Web, Request["Period"]);
        }
    }
}

