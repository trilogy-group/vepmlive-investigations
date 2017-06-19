using System.IO;

namespace EPMLive.SSRSConfigInjector.Resolver
{
    public class PathResolver : IPathResolver
    {
        private readonly string reportServerBasePath;

        public PathResolver(string reportServerBasePath)
        {
            this.reportServerBasePath = reportServerBasePath;
        }

        public string GetReportingServicePath(string fileName)
        {
            if(!string.IsNullOrEmpty(fileName))
            {
                return Path.Combine(reportServerBasePath, "Reporting Services", "ReportServer", fileName);
            }
            else
            {
                return Path.Combine(reportServerBasePath, "Reporting Services", "ReportServer");
            }            
        }

        public string GetReportWebAppPath(string fileName)
        {
            return Path.Combine(reportServerBasePath, "Reporting Services", "RSWebApp", fileName);
        }
    }
}