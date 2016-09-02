using System;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class DBConnectionManager : IDisposable
    {
        #region Fields (1) 

        private readonly Guid _webAppId;

        #endregion Fields 

        #region Constructors (2) 

        public DBConnectionManager(SPWeb contextWeb, bool openConnection = true)
        {
            _webAppId = contextWeb.Site.WebApplication.Id;

            SqlConnection sqlConnection = null;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                string cs = CoreFunctions.getReportingConnectionString(_webAppId, contextWeb.Site.ID);

                var builder = new SqlConnectionStringBuilder(cs) {ApplicationName = "EPM Live - Social Engine"};
                cs = builder.ToString();

                sqlConnection = new SqlConnection(cs);
                if (openConnection) sqlConnection.Open();
            });

            SqlConnection = sqlConnection;
        }

        ~DBConnectionManager()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Properties (2) 

        public SqlConnection EPMLiveSqlConnection
        {
            get
            {
                SqlConnection sqlConnection = null;

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    string cs = CoreFunctions.getConnectionString(_webAppId);

                    var builder = new SqlConnectionStringBuilder(cs) {ApplicationName = "EPM Live - Social Engine"};
                    cs = builder.ToString();

                    sqlConnection = new SqlConnection(cs);
                    sqlConnection.Open();
                });

                return sqlConnection;
            }
        }

        public SqlConnection SqlConnection { get; private set; }

        #endregion Properties 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (SqlConnection == null) return;

            SqlConnection.Close();
            SqlConnection.Dispose();
            SqlConnection = null;
        }

        #endregion Methods 

        #region Implementation of IDisposable

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}