
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
    public partial class getplanlist : System.Web.UI.Page
    {

        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            data = "Error: Failed";

            SPWeb web = SPContext.Current.Web;
            {
                web.AllowUnsafeUpdates = true;
                try
                {
                    SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["Resource Plan Scenarios"];

                    string files = "";

                    foreach (SPFile file in lib.RootFolder.Files)
                    {
                        if(System.IO.Path.GetExtension(file.Name) == ".xml")
                            files += "," + System.IO.Path.GetFileNameWithoutExtension(file.Name) + "|" + web.Url + "/" + file.Url;
                    }

                    if (files.Length > 1)
                        files = files.Substring(1);

                    data = files;
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