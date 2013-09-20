using System.Web;
using System.Web.Hosting;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

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
            if (_initialized) return;

            lock (_locker)
            {
                if (_initialized) return;

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

        #endregion
    }
}