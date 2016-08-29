namespace EPMLiveWebParts
{
    /// <summary>
    /// This class is used to house the values needed for replacing connection information in Excel and ODC files.
    /// </summary>
    public class ExcelConnectionInfo
    {
        public string SiteUrl { get; set; }
        public string OdcFilePrefix { get; set; }
        public string DataConnectionUserName { get; set; }
        public string DataConnectionUserPassword { get; set; }
        public string DataConnectionServerName { get; set; }
        public string DataConnectionReportDbName { get; set; }
        public string DataConnectionLibraryName { get; set; }
        public string ExcelFileLibraryName { get; set; }
        public string ReportServerToken { get; set; }
        public string ReportDatabaseToken { get; set; }
        public string UserNameToken { get; set; }
        public string PasswordToken { get; set; }
        public string SiteUrlToken { get; set; }
        public string DataConnectionLibraryToken { get; set; }
    }
}