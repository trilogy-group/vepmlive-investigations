using Microsoft.SharePoint;
using System;

namespace EPMLiveCore.Jobs.SSRS
{
    public class SyncJob : API.BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            CreateSiteCollectionMappedFolder(site, web);
            SyncReports(site, web);
        }

        private void SyncReports(SPSite site, SPWeb web)
        {
            try
            {
                try
                {
                    var errors = string.Empty;
                    IReportingService reportingService = new ReportingService(Convert.ToString(web.AllProperties["SSRSNativeAdminUsername"]),
                                                                Convert.ToString(web.AllProperties["SSRSNativeAdminPassword"]),
                                                                Convert.ToString(web.AllProperties["ReportServerUrl"]),
                                                                Convert.ToString(web.AllProperties["AuthenticationType"]));
                    reportingService.SyncReports(site.ID, web.Lists["Report Library"] as SPDocumentLibrary, out errors);
                    if(!string.IsNullOrEmpty(errors))
                    {
                        bErrors = true;
                        sErrors += errors;
                    }
                }
                catch (Exception exception)
                {
                    bErrors = true;
                    sErrors += exception.ToString();
                }
            }
            catch (Exception exception)
            {
                bErrors = true;
                sErrors += exception.ToString();
            }
        }

        private void CreateSiteCollectionMappedFolder(SPSite site, SPWeb web)
        {
            try
            {
                if (web.AllProperties["epmlivessrsfoldersyncts"] == null)
                {
                    try
                    {
                        IReportingService reportingService = new ReportingService(Convert.ToString(web.AllProperties["SSRSNativeAdminUsername"]),
                                                                Convert.ToString(web.AllProperties["SSRSNativeAdminPassword"]),
                                                                Convert.ToString(web.AllProperties["ReportServerUrl"]),
                                                                Convert.ToString(web.AllProperties["AuthenticationType"]));
                        reportingService.CreateSiteCollectionMappedFolder(site.ID);
                        web.AllProperties.Add("epmlivessrsfoldersyncts", DateTime.Now.ToString());
                        web.Update();
                    }
                    catch (Exception exception)
                    {
                        bErrors = true;
                        sErrors += exception.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                bErrors = true;
                sErrors += exception.ToString();
            }
        }

        private void DeleteSiteCollectionMappedFolder(SPSite site, SPWeb web)
        {
            try
            {
                IReportingService reportingService = new ReportingService(Convert.ToString(web.AllProperties["SSRSNativeAdminUsername"]),
                                                                Convert.ToString(web.AllProperties["SSRSNativeAdminPassword"]),
                                                                Convert.ToString(web.AllProperties["ReportServerUrl"]),
                                                                Convert.ToString(web.AllProperties["AuthenticationType"]));
                reportingService.DeleteSiteCollectionMappedFolder(site.ID);
            }
            catch (Exception exception)
            {
                bErrors = true;
                sErrors += exception.ToString();
            }
        }
    }
}