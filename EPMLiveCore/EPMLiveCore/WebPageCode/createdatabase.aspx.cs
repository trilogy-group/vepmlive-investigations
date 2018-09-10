using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using SysTrace = System.Diagnostics.Trace;
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
        private const string KeyServer = "Server";
        private const string KeyDatabase = "DB";
        private const string KeyUsername = "Username";
        private const string KeyPassword = "Password";
        private const string KeyWebApp = "WEBAPP";
        protected string output;

        protected void Page_Load(object sender, EventArgs e)
        {
            Server.ScriptTimeout = 300;

            var webapp = SPWebService.ContentService.WebApplications[new Guid(Request[KeyWebApp])];

            var server = Request[KeyServer];
            var database = Request[KeyDatabase];
            var username = Request[KeyUsername];
            var password = Request[KeyPassword];

            var credentials = string.IsNullOrWhiteSpace(username)
                ? "Trusted_Connection=True"
                : $"User Id={username};Password={password}";

            string connectionString;

            SqlConnection sqlConnection = null;

            try
            {
                connectionString = $"Server={server};Database=master;{credentials}";
                CreateDatabase(database, connectionString);

                connectionString = $"Server={server};Database={database};{credentials}";
                sqlConnection = new SqlConnection(connectionString);

                sqlConnection.Open();

                CreateUser(webapp.ApplicationPool.Username, sqlConnection);
                AddRoles(webapp.ApplicationPool.Username, sqlConnection);

                ExecuteCommand(Properties.Resources._0Tables01, sqlConnection);
                ExecuteCommand(Properties.Resources._0Tables02, sqlConnection);
                ExecuteCommand(Properties.Resources._1Views01, sqlConnection);
                ExecuteCommand(Properties.Resources._2SPs01, sqlConnection);
                ExecuteCommand(Properties.Resources._9Data01, sqlConnection);
                ExecuteCommand(Properties.Resources._9Data02, sqlConnection);
                InsertVersions(sqlConnection);

                sqlConnection.Close();

                string error;
                SPContext.Current.Web.AllowUnsafeUpdates = true;
                SPContext.Current.Site.AllowUnsafeUpdates = true;
                CoreFunctions.setConnectionString(webapp.Id, connectionString, out error);

                if (!string.IsNullOrWhiteSpace(error))
                {
                    output = $"Error Setting String: {error}";
                    return;
                }
            }
            catch (Exception ex)
            {
                SysTrace.TraceError(ex.ToString());
                output = $"Failed: {ex.Message}";
                return;
            }
            finally
            {
                sqlConnection?.Dispose();
            }

            output = "Success";
        }

        private void InsertVersions(SqlConnection cn)
        {
            using (var cmd = new SqlCommand("INSERT INTO VERSIONS (VERSION, DTINSTALLED) VALUES (@version, GETDATE())", cn))
            {
                cmd.Parameters.AddWithValue("@version", CoreFunctions.GetFullAssemblyVersion());
                cmd.ExecuteNonQuery();
            }
        }

        private void CreateDatabase(string databaseName, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand($"CREATE DATABASE {databaseName}", connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void AddRoles(string username, SqlConnection sqlConnection)
        {
            var cmd = default(SqlCommand);
            try
            {
                cmd = new SqlCommand("sp_addrolemember", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rolename", "db_owner");
                cmd.Parameters.AddWithValue("@membername", username);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                SysTrace.TraceError($"Error while adding roles to the user. Details: {ex}");
            }
            finally
            {
                cmd?.Dispose();
            }
        }

        private void CreateUser(string username, SqlConnection sqlConnection)
        {
            var createUserCommand = default(SqlCommand);
            try
            {
                createUserCommand = new SqlCommand($"create user [{username}] from login [{username}]", sqlConnection);
                createUserCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                SysTrace.TraceError($"Error while creating new user. Details: {ex}");
            }
            finally
            {
                createUserCommand?.Dispose();
            }
        }

        private void ExecuteCommand(string commandText, SqlConnection sqlConnection)
        {
            using (var cmd = new SqlCommand(commandText, sqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}