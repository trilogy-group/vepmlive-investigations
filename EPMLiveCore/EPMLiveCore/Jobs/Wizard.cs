using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs
{
    class Wizard : BaseJob
    {

        private string ssrsurl = "";

        private string reportdb = "";
        private string reportserver = "";
        private string reportusername = "";
        private string reportpassword = "";
        private bool usewindows = false;

        public void execute(SPSite site, SPWeb web, string data)
        {
            try
            {
                string []sData = data.Split('|');
                reportserver = sData[0];
                reportdb = sData[1];
                reportusername = sData[2];
                reportpassword = sData[3];
                usewindows = bool.Parse(sData[4]);

                ssrsurl = EPMLiveCore.CoreFunctions.getWebAppSetting(site.WebApplication.Id, "ReportingServicesURL");

                try
                {
                    if (ssrsurl != "")
                    {
                        processReports(web);
                    }
                }
                catch (Exception ex)
                {
                    base.bErrors = true;
                    base.sErrors += "Error processing reports: " + ex.Message;

                }
                try
                {
                    ProcessExcel(web);
                }
                catch (Exception ex)
                {
                    base.bErrors = true;
                    base.sErrors += "Error processing excel: " + ex.Message;
                }
                try
                {
                    ProcessIzenda(web);
                }
                catch (Exception ex)
                {
                    base.bErrors = true;
                    base.sErrors += "Error processing analytics: " + ex.Message;
                }
            }
            catch (Exception ex)
            {
                base.bErrors = true;
                base.sErrors = "General Error: " + ex.Message;
            }
        }

        private void ProcessExcel(SPWeb web)
        {


            var connectionInfo = new ExcelConnectionInfo
            {
                SiteUrl = web.Url,                                         // The site URL that contains the files to be updated.
                DataConnectionLibraryName = "Excel Datasources",      // The name of the document library containing the odc files.
                ExcelFileLibraryName = "Excel Reports",                      // The name of the document library containing the excel files.
                DataConnectionReportDbName = reportdb,            // The name of the reporting database.
                DataConnectionServerName = reportserver,                      // The name of the server the reporting database is hosted on.
                DataConnectionUserName = reportusername,                 // The username to connect to the reporting database.
                DataConnectionUserPassword = reportpassword,
                ReportDatabaseToken = "{REPORTDB}",                        // The token that needs to be put into the odc/excel files to be replaced with DataConnectionReportDbName property above.
                ReportServerToken = "{DBSERVER}",                          // The token that needs to be put into the odc/excel files to be replaced with DataConnectionServerName property above.
                UserNameToken = "{USERNAME}",                              // The token that needs to be put into the odc/excel files to be replaced with DataConnectionUserName property above.
                PasswordToken = "{PASSWORD}",                              // The token that needs to be put into the odc/excel files to be replaced with DataConnectionUserPassword property above.
                SiteUrlToken = "{SITEURL}",                                // The token that needs to be put into the odc/excel files to be replaced with SiteUrl property above.
                DataConnectionLibraryToken = "{DATACONNECTIONLIBRARY}",    // The token that needs to be put into the odc/excel files to be replaced with DataConnectionLibraryName property above.
                OdcFilePrefix = "EPMLIVE_"                                 // This is what the odc files need to be prefixed with so that only those ones are updated.
            };

            // This is the updater object which takes in the object above along with a "SharepointService".
            // The SharepointService class simply encapsulates commands to interact with sharepoint like reading/writing files.
            var updater = new ExcelConnectionUpdatorService(connectionInfo, new SharepointService(web));

            // These are the only two methods that need to be called on the updater.
            // One to update the ODC files and another to update the Excel files.
            try
            {
                updater.ProcessOdcFiles();
                updater.ProcessExcelFiles();
            }
            catch { }
        }

        private void ProcessIzenda(SPWeb web)
        {
            SPList list = web.Lists.TryGetList("IzendaReports");
            if (list != null)
            {
                string errors = "";
                API.Reporting.ProcessIzendaReportsFromList(list, out errors);
            }
        }

        private void processReports(SPWeb web)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                SSRS2006.ReportingService2006 SSRS = new SSRS2006.ReportingService2006();
                SSRS.Url = ssrsurl + "/ReportService2006.asmx";
                SSRS.UseDefaultCredentials = true;

                string username = "";
                string password = "";
                EPMLiveCore.ReportAuth _chrono = web.Site.WebApplication.GetChild<EPMLiveCore.ReportAuth>("ReportAuth");
                if (_chrono != null)
                {
                    username = _chrono.Username;
                    password = EPMLiveCore.CoreFunctions.Decrypt(_chrono.Password, "KgtH(@C*&@Dhflosdf9f#&f");
                }

                if (password != "")
                {
                    SSRS.UseDefaultCredentials = false;
                    if (username.Contains("\\"))
                    {
                        SSRS.Credentials = new System.Net.NetworkCredential(username.Substring(username.IndexOf("\\") + 1), password, username.Substring(0, username.IndexOf("\\")));
                    }
                    else
                    {
                        SSRS.Credentials = new System.Net.NetworkCredential(username, password);
                    }
                }


                //try
                //{
                //    var authCookie = HttpContext.Current.Request.Cookies["FedAuth"];
                //    var fedAuth = new Cookie(authCookie.Name, authCookie.Value, authCookie.Path, string.IsNullOrEmpty(authCookie.Domain) ? HttpContext.Current.Request.Url.Host : authCookie.Domain);
                //    SSRS.CookieContainer = new CookieContainer();
                //    SSRS.CookieContainer.Add(fedAuth);
                //}
                //catch { }

                SPDocumentLibrary list = (SPDocumentLibrary)web.Lists["Report Library"];

                SPListItemCollection folders = list.GetItemsInFolder(list.DefaultView, list.RootFolder);

                foreach (SPListItem li in folders)
                {
                    if (li.FileSystemObjectType == SPFileSystemObjectType.Folder && li.Name == "Data Sources")
                    {
                        SSRS2006.DataSourceDefinition dsd = new SSRS2006.DataSourceDefinition();
                        dsd.ConnectString = "Data Source=" + reportserver + ";Initial Catalog=" + reportdb + ";";
                        dsd.CredentialRetrieval = SSRS2006.CredentialRetrievalEnum.Store;
                        dsd.UserName = reportusername;
                        dsd.Password = reportpassword;
                        dsd.WindowsCredentials = usewindows;

                        dsd.Enabled = true;
                        dsd.Extension = "SQL";

                        SSRS.CreateDataSource("EPMLiveReportDB.rsds", web.Url + "/" + li.Url, true, dsd, null);
                    }
                }

                SSRS2006.DataSourceReference dsr = new SSRS2006.DataSourceReference();
                dsr.Reference = web.Url + "/Report Library/Data Sources/EPMLiveReportDB.rsds";

                foreach (SPListItem li in folders)
                {
                    processRDL(SSRS, web, li, dsr, list);
                }
            });
        }

        private void processRDL(SSRS2006.ReportingService2006 SSRS, SPWeb web, SPListItem folder, SSRS2006.DataSourceReference dsr, SPDocumentLibrary list)
        {
            foreach (SPListItem li in list.GetItemsInFolder(list.DefaultView, folder.Folder))
            {
                if (li.FileSystemObjectType == SPFileSystemObjectType.Folder)
                {

                    processRDL(SSRS, web, li, dsr, list);
                }
                else
                {
                    try
                    {
                        SSRS2006.DataSource[] dsstl = SSRS.GetItemDataSources(web.Url + "/" + li.Url);
                        for (int i = 0; i < dsstl.Length; i++)
                        {
                            if (dsstl[i].Name == "EPMLiveReportDB")
                            {
                                dsstl[i].Item = dsr;
                            }
                        }
                        SSRS.SetItemDataSources(web.Url + "/" + li.Url, dsstl);
                    }
                    catch { }
                }
            }

        }
    }
}
