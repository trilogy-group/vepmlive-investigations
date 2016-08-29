namespace EPMLiveReportsAdmin.API
{
    internal enum Errors
    {
        GetMyWorkData = 17000,
        ParseMyWorkDataNoRootElement,
        ParseMyWorkDataNoParamsElement,
        ParseMyWorkDataNoResourcesElement,
        InvalidReportingScope,
        GetMyWorkFields = 17100,
        GetAllReports = 17500,
        GetAllReportsNotIntegrated,
        GetAllReportsNoRSUrl,
        RefreshAll = 17600
    }
}