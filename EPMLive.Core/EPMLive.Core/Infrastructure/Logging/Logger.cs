using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        #region Fields (5) 

        private readonly SqlConnection _sqlConnection;
        private readonly int _userId;
        private readonly Guid _webAppId;
        private readonly Guid _webId;
        private bool _disposed;

        #endregion Fields 

        #region Constructors (3) 

        public Logger(SPWeb web, int userId)
        {
            _webAppId = web.Site.WebApplication.Id;
            _webId = web.ID;
            _userId = userId;
        }

        public Logger(SPWeb web) : this(web, web.CurrentUser.ID)
        {
            _sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(_webAppId));
            SPSecurity.RunWithElevatedPrivileges(() => _sqlConnection.Open());
        }

        ~Logger()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Methods (2) 

        // Private Methods (2) 

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Dispose();
            }

            _disposed = true;
        }

        private void InsertLog(string message, string details, string component, LogKind kind, string stackTrace = null)
        {
            const string SQL =
                @"INSERT INTO Logs (Component, Message, Details, StackTrace, Kind, WebId, UserId) VALUES (@Component, @Message, @Details, @StackTrace, @Kind, @WebId, @UserId)";

            using (var sqlCommand = new SqlCommand(SQL, _sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Component", component);
                sqlCommand.Parameters.AddWithValue("@Message", message);
                sqlCommand.Parameters.AddWithValue("@Kind", kind);
                sqlCommand.Parameters.AddWithValue("@WebId", _webId);
                sqlCommand.Parameters.AddWithValue("@UserId", _userId);
                sqlCommand.Parameters.AddWithValue("@Details",
                    string.IsNullOrEmpty(stackTrace) ? DBNull.Value : (object) details);
                sqlCommand.Parameters.AddWithValue("@StackTrace",
                    string.IsNullOrEmpty(stackTrace) ? DBNull.Value : (object) stackTrace);

                sqlCommand.ExecuteNonQuery();
            }
        }

        #endregion Methods 

        #region Implementation of ILogger

        public void LogMessage(Exception exception, string component, LogKind kind = LogKind.Error)
        {
            var aggregateException = exception as AggregateException;
            if (aggregateException != null)
            {
                foreach (Exception ex in aggregateException.InnerExceptions)
                {
                    LogMessage(ex, component, kind);
                }
            }
            else
            {
                InsertLog(exception.Message, string.Format(@"Exception Kind: {0}", exception.GetType()), component, kind,
                    exception.StackTrace);

                if (exception.InnerException != null) LogMessage(exception.InnerException, component, kind);
            }
        }

        public void LogMessage(string message, string component, LogKind kind, string details = null)
        {
            InsertLog(message, details, component, kind);
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}