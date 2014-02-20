using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace EPMLiveCore.SocialEngine.Events.ListEventReceiver
{
    /// <summary>
    /// List Events
    /// </summary>
    public class ListEventReceiver : SPListEventReceiver
    {
        /// <summary>
        /// A list was added.
        /// </summary>
        public override void ListAdded(SPListEventProperties properties)
        {
            base.ListAdded(properties);
        }

        /// <summary>
        /// A list was deleted.
        /// </summary>
        public override void ListDeleted(SPListEventProperties properties)
        {
            base.ListDeleted(properties);
        }


    }
}