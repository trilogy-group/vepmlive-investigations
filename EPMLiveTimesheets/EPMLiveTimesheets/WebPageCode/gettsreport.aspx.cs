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
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;

using System.Net.Mail;

namespace TimeSheets
{
    public partial class gettsreport : System.Web.UI.Page
    {
        protected DateTimeControl dtStart;
        protected DateTimeControl dtEnd;
        protected static string report;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dtTemp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtStart.SelectedDate = dtTemp;
                dtEnd.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dtTemp.AddMonths(1).AddDays(-1).Day);
                report = Request["Report"];

                dtStart.DatePickerFrameUrl = SPContext.Current.Web.Url + "/_layouts/iframe.aspx";
                dtEnd.DatePickerFrameUrl = SPContext.Current.Web.Url + "/_layouts/iframe.aspx";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("WEB");
            sb.AppendLine("1");
            string sURL = SPContext.Current.Web.Url + "/_layouts/epmlive/gettsreportdata.aspx?Report=" + Request["Report"] + "&start=" + dtStart.SelectedDate.ToShortDateString() + "&end=" + dtEnd.SelectedDate.ToShortDateString();
            sb.AppendLine(sURL);
            sb.AppendLine("");
            sb.AppendLine("Selection=");
            sb.AppendLine("EditWebPage=");
            sb.AppendLine("Formatting=None");
            sb.AppendLine("PreFormattedTextToColumns=True");
            sb.AppendLine("ConsecutiveDelimitersAsOne=True");
            sb.AppendLine("SingleBlockTextImport=False");
            sb.AppendLine("DisableDateRecognition=False");
            sb.AppendLine("DisableRedirections=False");

            Response.Clear();
            Response.AppendHeader("content-disposition", "attachment; filename=" + "timesheetdata.iqy");
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(StrToByteArray(sb.ToString()));
            Response.Flush();
            Response.End();
        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }
    }
}
