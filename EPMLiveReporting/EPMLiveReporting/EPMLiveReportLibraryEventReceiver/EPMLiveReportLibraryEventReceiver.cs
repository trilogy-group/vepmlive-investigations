using Microsoft.SharePoint;
using System;
using System.Diagnostics;
using System.IO;

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
            Debugger.Launch();
            if (Convert.ToBoolean(properties.ListItem["Synchronized"]) == false
                && Convert.ToBoolean(properties.AfterProperties["Synchronized"]) == true)
            {
                base.ItemUpdated(properties);
            }
            else
            {
                if (properties.ListItem["Synchronized"] == null || Convert.ToBoolean(properties.ListItem["Synchronized"]) == true)
                {
                    properties.ListItem["Synchronized"] = false;
                    properties.ListItem.SystemUpdate();                    
                }
                base.ItemUpdated(properties);
            }            
        }
    }
}