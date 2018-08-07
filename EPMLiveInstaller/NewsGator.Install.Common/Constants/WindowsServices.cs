namespace NewsGator.Install.Common.Constants
{
    /// <summary>
    /// Windows Service names used by the Social Sites Installer.
    /// </summary>
    internal static class WindowsServices
    {
        /// <summary>
        /// SharePoint Timer Service
        /// </summary>
        internal static string SharePointTimer = "SPTimerV4";
        /// <summary>
        /// SharePoint Administration Service
        /// </summary>
        internal static string SharePointAdmin = "SPAdminV4";
        /// <summary>
        /// SharePoint Server 2016 Search Service
        /// </summary>
        internal static string SharePointSearch16 = "OSearch16";
        /// <summary>
        /// SharePoint Server 2013 Search Service
        /// </summary>
        internal static string SharePointSearch15 = "OSearch15";
        /// <summary>
        /// SharePoint Server 2010 Search Service
        /// </summary>
        internal static string SharePointSearch14 = "OSearch14";        
        /// <summary>
        /// SharePoint Foundation 2010 Search Service
        /// </summary>
        internal static string SharePointSearchFoundation = "SPSearch4";
        /// <summary>
        /// SharePoint Server 2010 Web Analytics Service
        /// </summary>
        internal static string SharePointWebAnalytics = "WebAnalyticsService";
        /// <summary>
        /// ForeFront Identity Management Service
        /// </summary>
        internal static string ForeFrontIdentityManager = "FIMService";
        /// <summary>
        /// Internet Information Services Administration Service
        /// </summary>
        internal static string IISAdmin = "IISADMIN";
        /// <summary>
        /// Internet Information Services World Wide Web Publishing Service
        /// </summary>
        internal static string IISPublishing = "W3SVC";

        /// <summary>
        /// List of Windows Services, in order, to restart.
        /// </summary>
        internal static string[] GetAll = { SharePointAdmin, SharePointSearch14, SharePointSearch15, SharePointSearch16, SharePointSearchFoundation, SharePointTimer, SharePointWebAnalytics };
    }
}
