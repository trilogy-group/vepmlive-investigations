using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;

namespace EPMLiveCore
{
    public partial class checkurl : System.Web.UI.Page
    {
        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            SPWeb web = SPContext.Current.Web;
            data = "1";
            try
            {
                SPWeb w = web.Webs[Request["URL"]];
                string title = w.Title;
                data = "0";
                w.Close();
            }
            catch { }

        }
            
    }
}