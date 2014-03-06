using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore;
using EPMLiveCore.SocialEngine;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    internal static class SocialEngineEvents
    {
        #region Methods (4) 

        // Public Methods (3) 

        public static void ItemAdded(SPItemEventProperties properties)
        {
            var data = new Dictionary<string, object>
            {
                {"Id", properties.ListItemId},
                {"Title", properties.ListItem.Title},
                {"URL", properties.ListItem.Url},
                {"ListId", properties.ListId},
                {"WebId", properties.Web.ID},
                {"SiteId", properties.SiteId},
                {"UserId", ((SPFieldUserValue) properties.ListItem["Author"]).LookupId},
                {"ActivityTime", properties.ListItem["Created"]}
            };

            GetAssignedToUsers(properties, data);

            SocialEngineProxy.ProcessActivity(ObjectKind.ListItem, ActivityKind.Created, data, properties.Web);
        }

        public static void ItemDeleting(SPItemEventProperties properties)
        {
            throw new NotImplementedException();
        }

        public static void ItemUpdated(SPItemEventProperties properties)
        {
            throw new NotImplementedException();
        }

        // Private Methods (1) 

        private static void GetAssignedToUsers(SPItemEventProperties properties, Dictionary<string, object> data)
        {
            var users = new List<int>();

            if (properties.List.Fields.ContainsFieldWithInternalName("AssignedTo"))
            {
                object assignedToUsers = properties.ListItem["AssignedTo"];
                if (!string.IsNullOrEmpty(assignedToUsers as string))
                {
                    var collection = new SPFieldUserValueCollection(properties.Web, assignedToUsers.ToString());
                    users.AddRange(collection.Select(userValue => userValue.LookupId));
                }
            }

            data.Add("AssignedTo", string.Join(",", users.AsParallel().Distinct().ToArray()));
        }

        #endregion Methods 
    }
}