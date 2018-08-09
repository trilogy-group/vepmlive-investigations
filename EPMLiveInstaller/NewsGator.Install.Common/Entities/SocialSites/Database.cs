using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SharePoint.Administration;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    /// <summary>
    /// Connection to the Social Sites Databases.
    /// </summary>
    internal class Database
    {
        private string _defaultDatabaseServer { get; set; }
        private string _connectionString { get; set; }
        private string _databaseVersion
        {
            get
            {
                using (var conn = new SqlSession(_connectionString))
                {
                    if (conn == null || conn.Connection == null)
                        return null;

                    return GetVersion(conn.Connection);
                }
            }
        }
        private DataSet _farmConfiguration
        {
            get
            {
                using (var conn = new SqlSession(_connectionString))
                {
                    if (conn == null || conn.Connection == null)
                        return null;

                    return GetFarmConfiguration(conn.Connection);
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Str")]
        internal DataSet GetFarmConfiguration(string connStr)
        {
            this._connectionString = connStr;
            return _farmConfiguration;
        }

        internal string GetDatabaseVersion(string connStr)
        {
            this._connectionString = connStr;
            return _databaseVersion;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1306:SetLocaleForDataTypes")]
        private static DataSet GetFarmConfiguration(SqlConnection conn)
        {
            if (conn == null)
                return null;

            try
            {
                using (DataSet dataTable = new DataSet())
                {
                    var sql = "SELECT * FROM dbo.FarmConfiguration";
                    using (var comm = new SqlCommand(sql, conn))
                    {
                        comm.CommandType = CommandType.Text;
                        conn.Open();
                        using (var da = new SqlDataAdapter(comm))
                        {
                            da.Fill(dataTable);
                        }
                        conn.Close();
                        return dataTable;
                    }
                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetVersion(SqlConnection conn)
        {
            if (conn == null)
                return null;

            try
            {
                var sql = "SELECT MAX(VersionNumber) FROM dbo.Version";
                using (var comm = new SqlCommand(sql, conn))
                {
                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    string version = comm.ExecuteScalar().ToString();
                    return version;
                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal string GetDefaultDatabaseServer()
        {
            if (this._defaultDatabaseServer == null)
                this._defaultDatabaseServer = new SPWebApplicationBuilder(LocalFarm.Get()).DatabaseServer;
            return this._defaultDatabaseServer;
        }
    }
}
