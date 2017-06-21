using EPMLiveIntegration;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data;

namespace EPMLiveCore.Integrations.SSRS
{
    public class FolderIntegrator : IIntegrator
    {
        public TransactionTable DeleteItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            throw new NotImplementedException();
        }

        public List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetDropDownValues(WebProperties WebProps, IntegrationLog log, string Property, string ParentPropertyValue)
        {
            throw new NotImplementedException();
        }

        public DataTable GetItem(WebProperties WebProps, IntegrationLog log, string ItemID, DataTable Items)
        {
            throw new NotImplementedException();
        }

        public bool InstallIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey, string APIUrl)
        {
            throw new NotImplementedException();
        }

        public DataTable PullData(WebProperties WebProps, IntegrationLog log, DataTable Items, DateTime LastSynchDate)
        {
            throw new NotImplementedException();
        }

        public bool RemoveIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey)
        {
            throw new NotImplementedException();
        }

        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            throw new NotImplementedException();
        }

        public TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog log)
        {
            using (var site = new SPSite(Convert.ToString(WebProps.Properties["SITE_URL"])))
            {
                using (var web = site.OpenWeb())
                {
                    if (web.Properties["epmlivessrsfoldersyncts"] == null)
                    {
                        try
                        {
                            var reportingService = new ReportingService(Convert.ToString(site.RootWeb.Properties["SSRSNativeAdminUsername"]),
                                                                        Convert.ToString(site.RootWeb.Properties["SSRSNativeAdminPassword"]), 
                                                                        Convert.ToString(WebProps.Properties["RPT_SRV_URL"]));

                            reportingService.CreateFolders(WebProps.Properties["WEB_ID"].ToString(), WebProps.Site.ID.ToString());

                            web.Properties.Add("epmlivessrsfoldersyncts", DateTime.Now.ToString());
                        }
                        catch (Exception exception)
                        {
                            log.LogMessage(exception.ToString(), IntegrationLogType.Error);
                        }
                    }
                }
            }

            return new TransactionTable();
        }
    }
}