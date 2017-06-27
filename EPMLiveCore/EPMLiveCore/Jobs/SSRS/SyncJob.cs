using Microsoft.SharePoint;
using System;
using System.Linq;

namespace EPMLiveCore.Jobs.SSRS
{
    public class SyncJob : API.BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                CreateSiteCollectionMappedFolder(site, web);
                SyncReports(site, web);
            }
            else if (data.StartsWith("deletereport"))
            {
                DeleteReport(site, web, data);
            }
        }

        private void DeleteReport(SPSite site, SPWeb web, string data)
        {
            try
            {
                IReportingService reportingService = new ReportingService(Convert.ToString(web.AllProperties["SSRSAdminUsername"]),
                                                                Convert.ToString(web.AllProperties["SSRSAdminPassword"]),
                                                                Convert.ToString(web.AllProperties["SSRSReportServerUrl"]),
                                                                Convert.ToString(web.AllProperties["SSRSAuthenticationType"]));
                reportingService.DeleteReport(site.ID, data);
            }
            catch (Exception exception)
            {
                bErrors = true;
                sErrors += exception.ToString();
            }
        }

        private void SyncReports(SPSite site, SPWeb web)
        {
            try
            {
                var errors = string.Empty;
                IReportingService reportingService = new ReportingService(Convert.ToString(web.AllProperties["SSRSAdminUsername"]),
                                                            Convert.ToString(web.AllProperties["SSRSAdminPassword"]),
                                                            Convert.ToString(web.AllProperties["SSRSReportServerUrl"]),
                                                            Convert.ToString(web.AllProperties["SSRSAuthenticationType"]));
                reportingService.SyncReports(site.ID, web.Lists["Report Library"] as SPDocumentLibrary, out errors);
                if (!string.IsNullOrEmpty(errors))
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

        private void CreateSiteCollectionMappedFolder(SPSite site, SPWeb web)
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

        private void AssignRoleMapping(SPSite site, SPWeb web)
        {
            try
            {
                IReportingService reportingService = new ReportingService(Convert.ToString(web.AllProperties["SSRSAdminUsername"]),
                                                                Convert.ToString(web.AllProperties["SSRSAdminPassword"]),
                                                                Convert.ToString(web.AllProperties["SSRSReportServerUrl"]),
                                                                Convert.ToString(web.AllProperties["SSRSAuthenticationType"]));
                reportingService.AssignRoleMapping(site.ID, web.SiteGroups.OfType<SPGroup>().ToList(), web.SiteUserInfoList);
            }
            catch (Exception exception)
            {
                bErrors = true;
                sErrors += exception.ToString();
            }
        }
    }
}