using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.Administration;
using System.Threading;
using System.Data.SqlClient;

namespace EPMLiveCore
{
    public partial class createdatabase : System.Web.UI.Page
    {
        protected string output;

        protected void Page_Load(object sender, EventArgs e)
        {

            Server.ScriptTimeout = 300;

            string sSqlServer = Request["Server"];
            string sDatabase = Request["DB"];
            string sUsername = Request["Username"];
            string sPassword = Request["Password"];

            SPWebApplication webapp = SPWebService.ContentService.WebApplications[new Guid(Request["WEBAPP"])];

            string sSql = "";
            if(sUsername == "")
                sSql = "Trusted_Connection=True";
            else
                sSql = "User Id=" + sUsername + ";Password=" + sPassword;

            try
            {
                SqlConnection cn = new SqlConnection("Server=" + sSqlServer + ";Database=master;" + sSql);

                cn.Open();

                SqlCommand cmd = new SqlCommand("CREATE DATABASE " + sDatabase, cn);
                cmd.ExecuteNonQuery();

                cn.Close();

                cn = new SqlConnection("Server=" + sSqlServer + ";Database=" + sDatabase + ";" + sSql);

                cn.Open();

                try
                {
                    cmd = new SqlCommand("create user [" + webapp.ApplicationPool.Username + "] from login [" + webapp.ApplicationPool.Username + "]", cn);
                    cmd.ExecuteNonQuery();
                }
                catch { }

                try
                {
                    cmd = new SqlCommand("sp_addrolemember", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rolename", "db_owner");
                    cmd.Parameters.AddWithValue("@membername", webapp.ApplicationPool.Username);
                    cmd.ExecuteNonQuery();
                }
                catch { }

                cmd = new SqlCommand(Properties.Resources._0Tables01, cn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(Properties.Resources._0Tables02, cn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(Properties.Resources._1Views01, cn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(Properties.Resources._2SPs01, cn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(Properties.Resources._9Data01, cn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(Properties.Resources._9Data02, cn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("INSERT INTO VERSIONS (VERSION, DTINSTALLED) VALUES (@version, GETDATE())", cn);
                cmd.Parameters.AddWithValue("@version", CoreFunctions.GetFullAssemblyVersion());
                cmd.ExecuteNonQuery();

                cn.Close();

                string sError = "";
                string sqlString = "Server=" + sSqlServer + ";Database=" + sDatabase + ";" + sSql;
                SPContext.Current.Web.AllowUnsafeUpdates = true;
                SPContext.Current.Site.AllowUnsafeUpdates = true;
                EPMLiveCore.CoreFunctions.setConnectionString(webapp.Id, sqlString, out sError);

                if(sError != "")
                {
                    output = "Error Setting String: " + sError;
                    return;
                }
            }
            catch(Exception ex) { output = "Failed: " + ex.Message; return; }
            output = "Success";
        }

    }
}