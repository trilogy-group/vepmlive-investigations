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

namespace EPMLiveCore
{
    public partial class outlooksynch : System.Web.UI.Page
    {
        protected string sJS;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SPWeb web = SPContext.Current.Web;
                SPList list = web.Lists[new Guid(Request["ListId"])];

                string server = "";
                string sList = "";
                try
                {
                    server = HttpContext.Current.Request.Url.ToString();
                    server = server.Substring(0, server.IndexOf("/", 9));
                    server = server + SPContext.Current.Web.ServerRelativeUrl;
                    server = server.Replace("/", "\\u002f");
                }
                catch { }

                try
                {
                    sList = list.DefaultViewUrl;
                    sList = sList.Substring(0, sList.LastIndexOf("/"));
                    sList = sList.Replace("/", "\\u002f");
                }
                catch { }

                sJS = "ExportHailStorm('tasks','" + server + "','{" + list.ID + "}','" + web.Title + "','" + list.Title + "','" + sList + "','','" + sList + "');";
                sJS = sJS + "setTimeout(\"location.href='" + sList + "';\",1000);";

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }

        }
    }
}
