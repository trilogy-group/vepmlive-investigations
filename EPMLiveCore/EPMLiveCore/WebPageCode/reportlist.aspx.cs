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

namespace EPMLiveCore
{
    public partial class reportlist : System.Web.UI.Page
    {

        protected void hltpreport_OnClick(object sender, CommandEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("WEB");
            sb.AppendLine("1");
            string sURL = SPContext.Current.Web.Url + "/_layouts/epmlive/tpreports/" + e.CommandArgument;
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
            Response.AppendHeader("content-disposition", "attachment; filename=" + "tpreport.iqy");
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(StrToByteArray(sb.ToString()));
            Response.Flush();
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }

    }
}