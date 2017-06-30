using EPMLiveCore.Jobs.SSRS;
using Microsoft.SharePoint;
using System;

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
            QueueAgent.QueueJob(properties.Site.WebApplication, properties.Site);
        }

        /// <summary>
        /// An item was updated.
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            try
            {
                EventFiringEnabled = false;
                if (Convert.ToBoolean(properties.ListItem["Synchronized"]) == true
                && string.IsNullOrEmpty(Convert.ToString(properties.ListItem["UpdatedBy"])))
                {
                    properties.ListItem["Synchronized"] = false;
                    QueueAgent.QueueJob(properties.Site.WebApplication, properties.Site);
                }
                properties.ListItem["UpdatedBy"] = null;
                properties.ListItem.SystemUpdate(false);
                base.ItemUpdated(properties);
            }
            catch
            {                
            }
            finally
            {
                EventFiringEnabled = true;
            }            
        }

        public override void ItemDeleted(SPItemEventProperties properties)
        {
            base.ItemDeleted(properties);
            using (var site = new SPSite(properties.SiteId))
            {
                using (SPWeb web = site.OpenWeb(properties.Web.ID))
                {
                    var syncJob = new SyncJob();
                    syncJob.execute(site, web, $"deletereport:{properties.ListItem.Name}:{properties.ListItem.File.ParentFolder.Url}");
                }
            }
        }
    }
}