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
        public bool CreateEPMLiveDatabase(Guid webAppID, string sSqlServer, string sDatabase, string sUsername, string sPassword, out string output)
        {            
            try
            {
                SPWebApplication webapp = GetWebApplication(webAppID);

                string sSql = "";
                if (sUsername == "")
                    sSql = "Trusted_Connection=True";
                else
                    sSql = "User Id=" + sUsername + ";Password=" + sPassword;
                
                using (SqlConnection cn = new SqlConnection("Server=" + sSqlServer + ";Database=master;" + sSql))
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("CREATE DATABASE " + sDatabase, cn);
                    cmd.ExecuteNonQuery();
                }

                using (var cn = new SqlConnection("Server=" + sSqlServer + ";Database=" + sDatabase + ";" + sSql))
                {                    
                    cn.Open();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("create user [" + webapp.ApplicationPool.Username + "] from login [" + webapp.ApplicationPool.Username + "]", cn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        output = "Failed : " + ex.Message;
                        return false;
                    }

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_addrolemember", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@rolename", "db_owner");
                            cmd.Parameters.AddWithValue("@membername", webapp.ApplicationPool.Username);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        output = "Failed : " + ex.Message;
                        return false;
                    }


                    string[] CommandTexts = new string[]
                    {
                        Properties.Resources._0Tables01,
                        Properties.Resources._0Tables02,
                        Properties.Resources._1Views01,
                        Properties.Resources._2SPs01,
                        Properties.Resources._9Data01,
                        Properties.Resources._9Data02
                    };

                    foreach (var cmdText in CommandTexts)
                    {
                        using (SqlCommand cmd = new SqlCommand(cmdText, cn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO VERSIONS (VERSION, DTINSTALLED) VALUES (@version, GETDATE())", cn))
                    {
                        cmd.Parameters.AddWithValue("@version", CoreFunctions.GetFullAssemblyVersion());
                        cmd.ExecuteNonQuery();
                    }
                    
                    string sError = "";
                    string sqlString = "Server=" + sSqlServer + ";Database=" + sDatabase + ";" + sSql;
                    EPMLiveCore.CoreFunctions.setConnectionString(webapp.Id, sqlString, out sError);

                    if (sError != "")
                    {
                        output = "Error Setting String: " + sError;
                        return false;
                    }
                }                
            }
            catch (Exception ex)
            {                
                output = "Failed: " + ex.Message;
                return false;
            }            
            output = "Sucess";
            return true;
        }
        protected SPWebApplication GetWebApplication(Guid webAppId)
        {
            SPWebApplication web = SPWebService.ContentService.WebApplications[webAppId];
            return web;
        }
    }
}
