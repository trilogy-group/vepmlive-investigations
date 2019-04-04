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
using PSLibrary = Microsoft.Office.Project.Server.Library;
using System.Data.SqlClient;
using EPMLiveCore;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;

namespace EPMLiveEnterprise
{
    public partial class eaction : System.Web.UI.Page
    {

        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"];
            switch (action)
            {
                case "link":

                    try
                    {
                        using(SPSite site = new SPSite(Request["url"]))
                        {
                            using (SPWeb web = site.OpenWeb())
                            {
                                if (web.Url.ToLower() == Request["url"].ToLower())
                                {
                                    SPSecurity.RunWithElevatedPrivileges(delegate() { ExecuteQuery(web); });
                                }
                                else
                                {
                                    data = "Error: Invalid Site";
                                }
                            }
                        }
                    }
                    catch(Exception exception)
                    {
                        data = "Error: " + exception .Message;
                    }

                    break;
            };
        }

        private void ExecuteQuery(SPWeb web)
        {
            using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id)))
            {
                sqlConnection.Open();

                using (var sqlCommand = new SqlCommand("UPDATE publishercheck set weburl=@url where projectguid=@projectguid", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@projectguid", Request["projectid"]);
                    sqlCommand.Parameters.AddWithValue("@url", web.Url);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
