﻿using Microsoft.SharePoint;
using System;

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
                AssignRoleMapping(site, web);
            }
            else if (data.StartsWith("deletereport"))
            {
                DeleteReport(site, web, data);
            }
            else if (data.StartsWith("removerole"))
            {
                RemoveRole(site, web, data);
            }
        }

        private void DeleteReport(SPSite site, SPWeb web, string data)
        {
            try
            {
                IReportingService reportingService = ReportingService.GetInstance(site);
                reportingService.DeleteReport(data);
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
                IReportingService reportingService = ReportingService.GetInstance(site);
                reportingService.SyncReports(web.Lists["Report Library"] as SPDocumentLibrary);
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
                    IReportingService reportingService = ReportingService.GetInstance(site);
                    reportingService.CreateSiteCollectionMappedFolder();
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
                IReportingService reportingService = ReportingService.GetInstance(site);
                reportingService.DeleteSiteCollectionMappedFolder();
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
                IReportingService reportingService = ReportingService.GetInstance(site);
                reportingService.AssignRoleMapping(web.SiteGroups, web.SiteUserInfoList);
            }
            catch (Exception exception)
            {
                bErrors = true;
                sErrors += exception.ToString();
            }
        }

        private void RemoveRole(SPSite site, SPWeb web, string data)
        {
            try
            {
                IReportingService reportingService = ReportingService.GetInstance(site);
                reportingService.RemoveRoleMapping(data);
            }
            catch (Exception exception)
            {
                bErrors = true;
                sErrors += exception.ToString();
            }
        }
    }
}