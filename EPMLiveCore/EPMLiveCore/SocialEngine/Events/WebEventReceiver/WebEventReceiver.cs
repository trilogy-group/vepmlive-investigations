﻿using System;
using System.Collections.Generic;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Events.WebEventReceiver
{
    /// <summary>
    ///     Web Events
    /// </summary>
    public class WebEventReceiver : SPWebEventReceiver
    {
        #region Methods (2) 

        // Public Methods (2) 

        /// <summary>
        ///     A site is being deleted.
        /// </summary>
        public override void WebDeleting(SPWebEventProperties properties)
        {
            try
            {
                SocialEngine.Current.ProcessActivity(ObjectKind.Workspace, ActivityKind.Deleted,
                new Dictionary<string, object>
                {
                    {"Id", properties.WebId},
                    {"Title", properties.Web.Title},
                    {"URL", properties.ServerRelativeUrl},
                    {"UserId", properties.Web.CurrentUser.ID},
                    {"ActivityTime", DateTime.Now}
                }, properties.Web);
            }
            catch { }
        }

        /// <summary>
        ///     A site was provisioned.
        /// </summary>
        public override void WebProvisioned(SPWebEventProperties properties)
        {
            try
            {
                SocialEngine.Current.ProcessActivity(ObjectKind.Workspace, ActivityKind.Created,
                    new Dictionary<string, object>
                    {
                        {"Id", properties.WebId},
                        {"Title", properties.Web.Title},
                        {"URL", properties.ServerRelativeUrl},
                        {"UserId", properties.Web.CurrentUser.ID},
                        {"ActivityTime", DateTime.Now}
                    }, properties.Web);
            }
            catch { }

            try
            {
                CoreFunctions.ScheduleReportingRefreshJob(properties.Web);
            }
            catch { }
        }

        #endregion Methods 
    }
}