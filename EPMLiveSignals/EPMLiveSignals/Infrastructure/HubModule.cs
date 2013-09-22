using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Hosting;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EPMLiveSignals.Infrastructure
{
    public class HubModule : IHttpModule
    {
        #region Fields (2) 

        private static bool _initialized;
        private readonly object _locker = new object();

        #endregion Fields 

        #region IHttpModule Members

        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        }

        private void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            if (_initialized) return;

            lock (_locker)
            {
                if (_initialized) return;

                GlobalHost.DependencyResolver.UseSqlServer(GetConnectionString());

                var hubConfiguration = new HubConfiguration
                {
                    EnableCrossDomain = true,
                    EnableDetailedErrors = true,
                    EnableJavaScriptProxies = true
                };

                RouteTable.Routes.MapHubs(hubConfiguration);
                HostingEnvironment.RegisterVirtualPathProvider(new SignalRVirtualPathProvider());

                _initialized = true;
            }
        }

        private static string GetConnectionString()
        {
            Guid webAppId = SPContext.Current.Web.Site.WebApplication.Id;
            string connectionString = null;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    SPWebApplication webapp = SPWebService.ContentService.WebApplications[webAppId];
                    connectionString = webapp.Properties["EPMLiveSignalRCN"].ToString();
                }
                catch { }
            });

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Cannot find the EPM Live SignalR connection string.");
            }

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
            }

            return connectionString;
        }

        #endregion
    }
}