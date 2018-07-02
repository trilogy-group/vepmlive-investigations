using System;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveCore.PfeData
{
    public class ConnectionProvider : IConnectionProvider
    {
        private const string FeatureGuid = "158c5682-d839-4248-b780-82b4710ee152";

        public static bool AllowDatabaseConnections(SPWeb web)
        {
            return web?.Site.Features[new Guid(FeatureGuid)] != null;
        }

        /// <summary>
        /// Creates connection from config settings stored in SPWeb.
        /// </summary>
        /// <returns>The new SqlConnection instance.</returns>
        public SqlConnection CreateConnection(SPWeb web)
        {
            if (web == null)
            {
                throw new ArgumentNullException(nameof(web));
            }

            if (!AllowDatabaseConnections(web))
            {
                throw new InvalidOperationException($"PPMFeature is not installed ({web.Site.Url})");
            }

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
            catch { return string.Empty; }
        }
    }
}
