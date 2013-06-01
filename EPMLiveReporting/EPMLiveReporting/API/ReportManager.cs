using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml.Linq;
using EPMLiveCore;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.SSRS2006;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveReportsAdmin.API
{
    public class ReportManager : BaseManager, IDisposable
    {
        #region Fields (1)

        private ReportingService2006 _reportingService2006;

        #endregion Fields

        #region Constructors (2)

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReportManager" /> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public ReportManager(SPWeb spWeb)
            : base(spWeb)
        {
        }

        /// <summary>
        ///     Releases unmanaged resources and performs other cleanup operations before the
        ///     <see cref="ReportManager" /> is reclaimed by garbage collection.
        /// </summary>
        ~ReportManager()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Methods (5)

        // Public Methods (1) 

        /// <summary>
        ///     Gets all reports.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string GetAllReports(string data)
        {
            try
            {
                ConfigureReportingService();

                var dataElement = new XElement("Data");

                SPDocumentLibrary spDocumentLibrary;

                try
                {
                    spDocumentLibrary = (SPDocumentLibrary) Web.Lists["Report Library"];
                }
                catch (Exception)
                {
                    throw new Exception("Document Library 'Report Library' does not exist.");
                }

                List<SPFolder> spFolders =
                    (from SPListItem spListItem in spDocumentLibrary.Folders select spListItem.Folder).ToList();

                BuildReportTree(spDocumentLibrary.RootFolder, spFolders, spDocumentLibrary, ref dataElement);

                return new XElement("GetAllReports", new XElement("Params"), dataElement).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.GetAllReports, exception.GetBaseException().Message);
            }
        }

        // Private Methods (4) 

        /// <summary>
        ///     Builds the report query string.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private string BuildReportQueryString(string url)
        {
            var stringBuilder = new StringBuilder();

            bool hasResourcesParam = false;

            foreach (ReportParameter reportParameter in _reportingService2006.GetReportParameters(url, null, null, null)
                )
            {
                string name = reportParameter.Name;
                if (string.IsNullOrEmpty(reportParameter.Prompt))
                {
                    switch (name)
                    {
                        case "URL":
                            stringBuilder.AppendFormat("&rp:URL={0}", HttpUtility.UrlEncode(Web.ServerRelativeUrl));
                            break;
                        case "SiteId":
                            stringBuilder.AppendFormat("&rp:SiteId={0}", Web.Site.ID);
                            break;
                        case "WebId":
                            stringBuilder.AppendFormat("&rp:WebId={0}", Web.ID);
                            break;
                        case "UserId":
                            stringBuilder.AppendFormat("&rp:UserId={0}", Web.CurrentUser.ID);
                            break;
                        case "Username":
                            stringBuilder.AppendFormat("&rp:Username={0}", HttpContext.Current.User.Identity.Name);
                            break;
                    }
                }

                if (name.Equals("Resources")) hasResourcesParam = true;
            }

            stringBuilder.Append("|" + hasResourcesParam);

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Builds the report tree.
        /// </summary>
        /// <param name="parentFolder">The parent folder.</param>
        /// <param name="spFolders">The sp folders.</param>
        /// <param name="spDocumentLibrary">The sp document library.</param>
        /// <param name="parentElement">The parent element.</param>
        private void BuildReportTree(SPFolder parentFolder, IEnumerable<SPFolder> spFolders,
                                     SPDocumentLibrary spDocumentLibrary, ref XElement parentElement)
        {
            var xElement = new XElement("Folder", new XAttribute("Name", parentFolder.Name));

            foreach (
                SPListItem spListItem in spDocumentLibrary.GetItemsInFolder(spDocumentLibrary.DefaultView, parentFolder)
                )
            {
                if (spListItem.FileSystemObjectType != SPFileSystemObjectType.File ||
                    !spListItem.File.Name.ToLower().EndsWith(".rdl")) continue;

                SPFile spFile = spListItem.File;
                string name = spFile.Name;

                string safeServerRelativeUrl = Web.SafeServerRelativeUrl();
                string url = string.Empty;
                string hasResourcesParam = string.Empty;
                string error = string.Empty;

                try
                {
                    string reportUrl = BuildReportQueryString(SPUrlUtility.CombineUrl(Web.Url, spListItem.Url));
                    string[] reportUrlParts = reportUrl.Split('|');

                    url =
                        string.Format(
                            @"{0}/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl={1}{2}&rv:HeaderArea=none",
                            safeServerRelativeUrl,
                            HttpUtility.UrlEncode(string.Format(@"{0}/{1}", safeServerRelativeUrl, spListItem.Url)),
                            reportUrlParts[0]);

                    hasResourcesParam = reportUrlParts[1];
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }

                var element = new XElement("Report", new XAttribute("Name", name.Substring(0, name.Length - 4)),
                                           new XAttribute("Url", url),
                                           new XAttribute("HasResourcesParam", hasResourcesParam));

                if (!string.IsNullOrEmpty(error))
                {
                    element.Add(new XElement("Error", new XCData(error)));
                }

                xElement.Add(element);
            }

            foreach (
                SPFolder spFolder in
                    spFolders.Where(f => f.ParentFolder.Name.Equals(parentFolder.Name)).Where(
                        spFolder => !spFolder.Name.Equals("Data Sources")))
            {
                BuildReportTree(spFolder, spFolders, spDocumentLibrary, ref xElement);
            }

            parentElement.Add(xElement);
        }

        /// <summary>
        ///     Configures the reporting service.
        /// </summary>
        private void ConfigureReportingService()
        {
            Guid webAppId = Web.Site.WebApplication.Id;

            bool ssrsIntegrated = bool.Parse(CoreFunctions.getWebAppSetting(webAppId, "ReportsUseIntegrated"));
            string reportingServiceUrl = CoreFunctions.getWebAppSetting(webAppId, "ReportingServicesURL");

            if (!ssrsIntegrated)
            {
                throw new APIException((int) Errors.GetAllReportsNotIntegrated,
                                       "Reporting API only supports Integrated SSRS setup.");
            }

            if (string.IsNullOrEmpty(reportingServiceUrl))
            {
                throw new APIException((int) Errors.GetAllReportsNoRSUrl, "ReportingServicesURL has not been set.");
            }

            string reportingServiceUsername = string.Empty;
            string reportingServicePassword = string.Empty;

            var reportAuth = Web.Site.WebApplication.GetChild<ReportAuth>("ReportAuth");

            if (reportAuth != null)
            {
                reportingServiceUsername = reportAuth.Username;
                reportingServicePassword = CoreFunctions.Decrypt(reportAuth.Password, "KgtH(@C*&@Dhflosdf9f#&f");
            }

            try
            {
                _reportingService2006 = new ReportingService2006
                    {
                        UseDefaultCredentials = true,
                        Url = string.Format("{0}/ReportService2006.asmx", reportingServiceUrl)
                    };

                try
                {
                    HttpCookie authCookie = HttpContext.Current.Request.Cookies["FedAuth"];
                    var fedAuth = new Cookie(authCookie.Name, authCookie.Value, authCookie.Path,
                                             string.IsNullOrEmpty(authCookie.Domain)
                                                 ? HttpContext.Current.Request.Url.Host
                                                 : authCookie.Domain);
                    _reportingService2006.CookieContainer = new CookieContainer();
                    _reportingService2006.CookieContainer.Add(fedAuth);
                }
                catch
                {
                }
            }
            catch (Exception)
            {
                throw new Exception("Cannot connect to the reporting service.");
            }

            if (string.IsNullOrEmpty(reportingServicePassword)) return;

            _reportingService2006.UseDefaultCredentials = false;

            if (reportingServiceUsername.Contains("\\"))
            {
                int index = reportingServiceUsername.IndexOf("\\", StringComparison.Ordinal);

                _reportingService2006.Credentials = new NetworkCredential(reportingServiceUsername.Substring(index + 1),
                                                                          reportingServicePassword,
                                                                          reportingServiceUsername.Substring(0, index));
            }
            else
            {
                _reportingService2006.Credentials = new NetworkCredential(reportingServiceUsername,
                                                                          reportingServicePassword);
            }
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (_reportingService2006 == null) return;

            _reportingService2006.Dispose();
            _reportingService2006 = null;
        }

        #endregion Methods

        #region Implementation of IDisposable

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}