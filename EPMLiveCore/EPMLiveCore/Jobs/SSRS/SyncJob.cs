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
                    IReportingService reportingService = new ReportingService(Convert.ToString(web.AllProperties["SSRSAdminUsername"]),
                                                                Convert.ToString(web.AllProperties["SSRSAdminPassword"]),
                                                                Convert.ToString(web.AllProperties["SSRSReportServerUrl"]),
                                                                Convert.ToString(web.AllProperties["SSRSAuthenticationType"]));
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
                if (web.AllProperties["SSRSSyncSiteCollectionTimestamp"] == null)
                {
                    try
                    {
                        IReportingService reportingService = new ReportingService(Convert.ToString(web.AllProperties["SSRSAdminUsername"]),
                                                                Convert.ToString(web.AllProperties["SSRSAdminPassword"]),
                                                                Convert.ToString(web.AllProperties["SSRSReportServerUrl"]),
                                                                Convert.ToString(web.AllProperties["SSRSAuthenticationType"]));
                        reportingService.CreateSiteCollectionMappedFolder(site.ID);
                        web.AllProperties.Add("SSRSSyncSiteCollectionTimestamp", DateTime.Now.ToString());
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
                IReportingService reportingService = new ReportingService(Convert.ToString(web.AllProperties["SSRSAdminUsername"]),
                                                                Convert.ToString(web.AllProperties["SSRSAdminPassword"]),
                                                                Convert.ToString(web.AllProperties["SSRSReportServerUrl"]),
                                                                Convert.ToString(web.AllProperties["SSRSAuthenticationType"]));
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