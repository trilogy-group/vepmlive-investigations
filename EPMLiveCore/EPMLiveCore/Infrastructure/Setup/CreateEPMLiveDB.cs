using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Infrastructure.Setup
{
    public class CreateEPMLiveDB
    {
        protected string output = string.Empty;
        public string CreateEPMLiveDatabase(Guid webAppID, string sSqlServer, string sDatabase, string sUsername, string sPassword)
        {            
            try
            {
                SPWebApplication webapp = GetWebApplication(webAppID);

                string sSql = "";
                if (sUsername == "")
                    sSql = "Trusted_Connection=True";
                else
                    sSql = "User Id=" + sUsername + ";Password=" + sPassword;
                
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
                EPMLiveCore.CoreFunctions.setConnectionString(webapp.Id, sqlString, out sError);

                if (sError != "")
                {
                    output = "Error Setting String: " + sError;                    
                    return output;
                }                
            }
            catch (Exception ex)
            {                
                output = "Failed: " + ex.Message;
                return output;
            }            
            return output = "Sucess";
        }
        protected SPWebApplication GetWebApplication(Guid webAppId)
        {
            SPWebApplication web = SPWebService.ContentService.WebApplications[webAppId];
            return web;
        }
    }
}
