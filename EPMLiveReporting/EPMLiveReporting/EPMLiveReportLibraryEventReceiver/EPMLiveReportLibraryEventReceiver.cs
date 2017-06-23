using Microsoft.SharePoint;
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
            properties.ListItem["Synchronized"] = false;
            properties.ListItem.SystemUpdate();
            base.ItemUpdated(properties);            
        }
    }
}