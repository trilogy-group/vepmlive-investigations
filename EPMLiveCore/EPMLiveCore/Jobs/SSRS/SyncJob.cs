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
                    IReportingService reportingService = new ReportingService(Convert.ToString(web.Properties["SSRSNativeAdminUsername"]),
                                                                Convert.ToString(web.Properties["SSRSNativeAdminPassword"]),
                                                                Convert.ToString(web.Properties["RPT_SRV_URL"]));
                    reportingService.SyncReports(site.ID.ToString(), web.Lists["Report Library"] as SPDocumentLibrary, out errors);

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
                if (web.Properties["epmlivessrsfoldersyncts"] == null)
                {
                    try
                    {
                        IReportingService reportingService = new ReportingService(Convert.ToString(web.Properties["SSRSNativeAdminUsername"]),
                                                                    Convert.ToString(web.Properties["SSRSNativeAdminPassword"]),
                                                                    Convert.ToString(web.Properties["ReportServerUrl"]));
                        reportingService.CreateSiteCollectionMappedFolder(site.ID.ToString());
                        web.Properties.Add("epmlivessrsfoldersyncts", DateTime.Now.ToString());
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
                IReportingService reportingService = new ReportingService(Convert.ToString(web.Properties["SSRSNativeAdminUsername"]),
                                                            Convert.ToString(web.Properties["SSRSNativeAdminPassword"]),
                                                            Convert.ToString(web.Properties["ReportServerUrl"]));
                reportingService.DeleteSiteCollectionMappedFolder(site.ID.ToString());
            }
            catch (Exception exception)
            {
                bErrors = true;
                sErrors += exception.ToString();
            }
        }
    }
}