using System;
using System.Data;
using System.IO;
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

namespace EPMLiveCore
{
    public partial class rollupexport : System.Web.UI.Page
    {
        protected LinkButton lnkAttachment;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("WEB");
            sb.AppendLine("1");
            string sURL = SPContext.Current.Web.Url + "/_layouts/epmlive/viewrollup.aspx?List=" + Request["List"] + "&View=" + Request["View"] + "&Lists=" + Request["Lists"];
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
            Response.AppendHeader("content-disposition", "attachment; filename=" + "rollupexport.iqy");
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
