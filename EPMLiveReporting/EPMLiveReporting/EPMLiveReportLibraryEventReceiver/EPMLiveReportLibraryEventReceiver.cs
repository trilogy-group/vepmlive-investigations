using EPMLiveCore;
using EPMLiveCore.Jobs.SSRS;
using Microsoft.SharePoint;
using System;
using System.Linq;

namespace EPMLiveReportsAdmin
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EPMLiveReportLibraryEventReceiver : SPItemEventReceiver
    {
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);
            EventFiringEnabled = false;
            ProcessDataSourceCredentials(properties);
            properties.ListItem["Synchronized"] = false;
            properties.ListItem.SystemUpdate(false);
            EventFiringEnabled = true;
           
            SSRSSyncQueueAgent.EnequePFEJobSingleSiteCollection(properties.Site.WebApplication, properties.Site);
        }

        /// <summary>
        /// An item was updated.
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);

            EventFiringEnabled = false;
            ProcessDataSourceCredentials(properties);
            if (Convert.ToBoolean(properties.ListItem["Synchronized"]) == false || (Convert.ToBoolean(properties.ListItem["Synchronized"]) == true
                    && string.IsNullOrEmpty(Convert.ToString(properties.ListItem["UpdatedBy"]))))
            {
                properties.ListItem["Synchronized"] = false;
                properties.ListItem["UpdatedBy"] = null;
                properties.ListItem.SystemUpdate(false);
                SSRSSyncQueueAgent.EnequePFEJobSingleSiteCollection(properties.Site.WebApplication, properties.Site);
            }
            else
            {
                properties.ListItem["UpdatedBy"] = null;
                properties.ListItem.SystemUpdate(false);
            }
            EventFiringEnabled = true;

           

        }
        private void ProcessDataSourceCredentials(SPItemEventProperties properties)
        {
            var credentials = Convert.ToString(properties.ListItem["Datasource Credentials"]);
            if (properties.ListItem.ContentType.Name == "Report Data Source"
                && !string.IsNullOrEmpty(credentials)
                && string.IsNullOrEmpty(CoreFunctions.Decrypt(credentials, "FpUagQ2RG9")))
            {
                properties.ListItem["Datasource Credentials"] = CoreFunctions.Encrypt(credentials, "FpUagQ2RG9");
            }
        }
        
        public override void ItemDeleted(SPItemEventProperties properties)
        {
            base.ItemDeleted(properties);
            using (var site = new SPSite(properties.SiteId))
            {
                using (SPWeb web = site.OpenWeb(properties.Web.ID))
                {
                    var parts = properties.BeforeUrl.Split('/');
                    var syncJob = new SyncJob();
                    syncJob.execute(site, web, $"deletereport:{parts.Last()}:{string.Join("/", parts.Take(parts.Length - 1))}");
                }
            }
        }
    }
}