using System;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveCore.PfeData
{
    public class ConnectionProvider : IConnectionProvider
    {
        /// <summary>
        /// Creates connection from config settings stored in SPWeb.
        /// </summary>
        /// <returns>The new SqlConnection instance.</returns>
        public SqlConnection CreateConnection(SPWeb web)
        {
            var basePath = GetBasePath(web);
            var connectionString = Utilities.GetPFEDBConnectionString(basePath);

            // convert sql connection string to proper format
            var connectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = connectionString };
            connectionStringBuilder.Remove("Provider");
            connectionStringBuilder.Add("Application Name", "EPMLiveCore");
            connectionString = connectionStringBuilder.ToString();

            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private static string GetBasePath(SPWeb web)
        {
            try
            {
                var basePath = CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPKBasepath").Replace("/", "").Replace("\\", "");
                return basePath;
            }
            catch { return ""; }
        }
    }
}
