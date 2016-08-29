using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Threading;
using System.ComponentModel;
using System.Collections;

namespace EPMLiveCore
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class NotificationEvent : SPItemEventReceiver
    {
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            API.APIEmail.ClearNotificationItem(properties.ListItem);
        }

    }
}
