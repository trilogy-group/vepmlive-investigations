
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

namespace EPMLiveWebParts
{
    public partial class saveresplan : System.Web.UI.Page
    {
        private XmlDocument doc = new XmlDocument();
        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {

            string strTitle = Request["title"];
            string strData = Request["data"];

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            data = "Error: Failed";

            SPWeb web = SPContext.Current.Web;
            {
                web.AllowUnsafeUpdates = true;
                try
                {
                    SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["Resource Plan Scenarios"];

                    strData = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(strData));

                    SPFile newFile = lib.RootFolder.Files.Add(strTitle + ".xml", StrToByteArray(strData));

                    data = "Success";
                }
                catch (Exception ex)
                {
                    data = "Error: " + ex.Message;
                }
            }
            
        }
        public static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }

    }
}