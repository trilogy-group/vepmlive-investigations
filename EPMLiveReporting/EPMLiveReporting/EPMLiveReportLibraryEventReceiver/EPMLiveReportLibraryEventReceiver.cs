using EPMLiveCore.Jobs.SSRS;
using Microsoft.SharePoint;
using System;
using System.Diagnostics;

namespace EPMLiveReportsAdmin
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EPMLiveReportLibraryEventReceiver : SPItemEventReceiver
    {
        /// <summary>
        /// An item was updated.
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            if (Convert.ToBoolean(properties.ListItem["Synchronized"]) == true)
            {
                base.EventFiringEnabled = false;
                try
                {
                    properties.ListItem["Synchronized"] = false;
                    properties.ListItem.SystemUpdate(false);
                }
                catch
                {
                }
                finally
                {
                    base.EventFiringEnabled = true;
                }
            }
            base.ItemUpdated(properties);
        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            base.ItemDeleting(properties);
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