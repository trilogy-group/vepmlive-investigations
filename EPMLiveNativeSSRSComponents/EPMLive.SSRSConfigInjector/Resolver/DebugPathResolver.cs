using System;

namespace EPMLive.SSRSConfigInjector.Resolver
{
    public class DebugPathResolver : IPathResolver
    {
        public string GetReportingServicePath(string fileName)
        {
            return ".\\..\\..\\Samples\\" + fileName;
        }

        public string GetReportWebAppPath(string fileName)
        {
            return ".\\..\\..\\Samples\\" + fileName;
        }
    }
}