namespace EPMLive.SSRSConfigInjector.Resolver
{
    public interface IPathResolver
    {
        string GetReportingServicePath(string fileName = "");

        string GetReportWebAppPath(string fileName);
    }
}