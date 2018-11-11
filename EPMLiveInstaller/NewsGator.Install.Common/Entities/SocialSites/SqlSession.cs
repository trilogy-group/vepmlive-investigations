using System;
using System.Data.SqlClient;
using System.Security.Principal;
using Microsoft.SharePoint;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    /// <summary>
    /// SQL Session to use when interacting with the Social Platform database.
    /// </summary>
    internal class SqlSession : IDisposable
    {
        [ThreadStatic]
        private static bool? shouldImpersonate = null;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        static internal bool Impersonate
        {
            get { return shouldImpersonate ?? true; }
            set { shouldImpersonate = value; }
        }

        #region DEBUG ONLY CHECKS
#if DEBUG
        [ThreadStatic]
        static bool? ThreadImpersonating = null;
#endif // DEBUG
        #endregion DEBUG ONLY CHECKS

        internal string ConnectionString { get; private set; }
        internal WindowsImpersonationContext ImpersonationContext { get; set; }

        internal SqlSession(string connectString)
        {
            DoImpersonate();
            this.ConnectionString = connectString;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        private void DoImpersonate()
        {
            if (Impersonate) // only run this code if we WANT to impersonate the thread. Otherwise, leave it alone! 
            {
                if (SPContext.Current != null
                    && SPContext.Current.Web != null
                     && SPContext.Current.Web.CurrentUser != null
                     && SPContext.Current.Web.CurrentUser.Name != null)
                //(WindowsIdentity.GetCurrent().ImpersonationLevel == TokenImpersonationLevel.Impersonation && SPContext.Current == null
                //    || (SPContext.Current != null && SPContext.Current.Web.CurrentUser.Name.IsSystemAccount()))
                {
                    // no impersonation here please. We are already running at the thread identity.
                    //log.DebugFormat("Not impersonating for SQL session: current user: {0}.", WindowsIdentity.GetCurrent().Name);
                }
                else
                {
                    #region DEBUG ONLY CHECKS
#if DEBUG
                    if (ThreadImpersonating ?? false)
                    {
                        // Reset this so it doesn't stay in this loop indefinitely. 
                        ThreadImpersonating = false;
                        throw new InvalidOperationException("An attempt to double-impersonate happened in Sql Session's impersonate code. Please contact support.");
                    }
                    ThreadImpersonating = true;
#endif //DEBUG
                    #endregion DEBUG ONLY CHECKS
                    //log.DebugFormat("Entering impersonation context for SQL connection.");
                    this.ImpersonationContext = System.Security.Principal.WindowsIdentity.Impersonate(IntPtr.Zero);
                    //log.DebugFormat("Impersonation context: current user: {0}.", WindowsIdentity.GetCurrent().Name);
                }
            }
            else
            {
                //log.DebugFormat("Not impersonating for SQL session: current user: {0}.", WindowsIdentity.GetCurrent().Name);              
            }
        }

        #region disposable
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this._sqlConnection != null)
                    {
                        if (this._sqlConnection.State != System.Data.ConnectionState.Closed)
                        {
                            this._sqlConnection.Close();
                        }

                        this._sqlConnection.Dispose();
                    }
                    if (this.ImpersonationContext != null)
                    {
                        //log.DebugFormat("Leaving impersonation context for SQL connection. Current impersonated user: {0}.", WindowsIdentity.GetCurrent().Name);
                        #region DEBUG ONLY CHECKS
#if DEBUG
                        ThreadImpersonating = false;
#endif // DEBUG
                        #endregion DEBUG ONLY CHECKS
                        this.ImpersonationContext.Undo();
                        this.ImpersonationContext.Dispose();
                        //log.DebugFormat("Current user: {0}.", WindowsIdentity.GetCurrent().Name);
                    }
                }
                disposed = true;
            }
        }
        #endregion disposable

        private SqlConnection _sqlConnection = null;
        internal SqlConnection Connection
        {
            get
            {
                if (_sqlConnection != null)
                {
                    return _sqlConnection;
                }

                if (!string.IsNullOrEmpty(ConnectionString))
                {
                    _sqlConnection = new SqlConnection(ConnectionString);
                    // DL: let's not auto-open: if (_sqlConnection.State != System.Data.ConnectionState.Open) _sqlConnection.Open();
                }

                return _sqlConnection;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal void Open()
        {
            if (_sqlConnection != null)
            {
                try
                {
                    //log.DebugFormat("Opening SQL Connection. Current user: {0}.", WindowsIdentity.GetCurrent().Name);
                    _sqlConnection.Open();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal void Close()
        {
            if (_sqlConnection != null)
            {
                //log.DebugFormat("Closing SQL Connection. ");
                _sqlConnection.Close();
            }
        }
    }
}
