using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Hosting;
using System.Web.Routing;
using EPMLiveCore;
using Microsoft.AspNet.SignalR;
using Microsoft.SharePoint;

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
            string connectionString = CoreFunctions.getWebAppSetting(webAppId, "EPMLiveSignalRCN");

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