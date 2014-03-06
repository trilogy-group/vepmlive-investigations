using System;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal abstract class BaseManager : IDisposable
    {
        #region Fields (2) 

        private readonly Guid _webAppId;
        protected SqlConnection SqlConnection;

        #endregion Fields 

        #region Constructors (2) 

        protected BaseManager(SPWeb contextWeb)
        {
            _webAppId = contextWeb.Site.WebApplication.Id;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                string cs = CoreFunctions.getReportingConnectionString(_webAppId, contextWeb.Site.ID);

                var builder = new SqlConnectionStringBuilder(cs) {ApplicationName = "EPM Live - Social Engine"};
                cs = builder.ToString();

                SqlConnection = new SqlConnection(cs);
                SqlConnection.Open();
            });
        }

        ~BaseManager()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Properties (1) 

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