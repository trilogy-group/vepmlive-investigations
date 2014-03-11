using System;
using System.Collections.Generic;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Events.ListEventReceiver
{
    /// <summary>
    ///     List Events
    /// </summary>
    public class ListEventReceiver : SPListEventReceiver
    {
        #region Methods (2) 

        // Public Methods (2) 

        /// <summary>
        ///     A list was added.
        /// </summary>
        public override void ListAdded(SPListEventProperties properties)
        {
            if (!properties.List.Hidden)
            {
                SocialEngine.Current.ProcessActivity(ObjectKind.List, ActivityKind.Created,
                    new Dictionary<string, object>
                    {
                        {"Id", properties.ListId},
                        {"Title", properties.ListTitle},
                        {"URL", properties.List.DefaultViewUrl},
                        {"WebId", properties.WebId},
                        {"UserId", properties.Web.CurrentUser.ID},
                        {"ActivityTime", properties.List.Created}
                    }, properties.Web);
            }
        }

        /// <summary>
        ///     A list was deleted.
        /// </summary>
        public override void ListDeleting(SPListEventProperties properties)
        {
            if (!properties.List.Hidden)
            {
                SocialEngine.Current.ProcessActivity(ObjectKind.List, ActivityKind.Deleted,
                    new Dictionary<string, object>
                    {
                        {"Id", properties.ListId},
                        {"Title", properties.ListTitle},
                        {"URL", properties.List.DefaultViewUrl},
                        {"WebId", properties.WebId},
                        {"UserId", properties.Web.CurrentUser.ID},
                        {"ActivityTime", DateTime.Now}
                    }, properties.Web);
            }
        }

        #endregion Methods 
    }
}