using Microsoft.SharePoint;
using System;

namespace EPMLiveCore.Jobs.SSRS
{
    public class SyncJob : API.BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            DeleteSiteCollectionMappedFolder(site, web);
            CreateSiteCollectionMappedFolder(site, web);
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
                                                                    Convert.ToString(web.Properties["RPT_SRV_URL"]));
                        reportingService.CreateSiteCollectionMappedFolder(web.Properties["WEB_ID"].ToString(), site.ID.ToString());
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
                                                            Convert.ToString(web.Properties["RPT_SRV_URL"]));
                reportingService.DeleteSiteCollectionMappedFolder(web.ID.ToString(), site.ID.ToString());
            }
            catch (Exception exception)
            {
                bErrors = true;
                sErrors += exception.ToString();
            }
        }
    }
}