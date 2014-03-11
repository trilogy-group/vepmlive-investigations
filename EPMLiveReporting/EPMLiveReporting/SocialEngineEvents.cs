using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMLiveCore;
using EPMLiveCore.SocialEngine;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    internal static class SocialEngineEvents
    {
        #region Methods (5) 

        // Public Methods (3) 

        public static void ItemAdded(SPItemEventProperties properties)
        {
            var data = new Dictionary<string, object>
            {
                {"Id", properties.ListItemId},
                {"Title", properties.ListItem.Title},
                {"URL", properties.ListItem.Url},
                {"ListTitle", properties.ListTitle},
                {"ListId", properties.ListId},
                {"WebId", properties.Web.ID},
                {"SiteId", properties.SiteId},
                {"UserId", new SPFieldUserValue(properties.Web, (string) properties.ListItem["Author"]).LookupId},
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
            var data = new Dictionary<string, object>
            {
                {"Id", properties.ListItemId},
                {"Title", properties.ListItem.Title},
                {"URL", properties.ListItem.Url},
                {"ListTitle", properties.ListTitle},
                {"ListId", properties.ListId},
                {"WebId", properties.Web.ID},
                {"SiteId", properties.SiteId},
                {"UserId", new SPFieldUserValue(properties.Web, (string) properties.ListItem["Editor"]).LookupId},
                {"ActivityTime", properties.ListItem["Modified"]}
            };

            var tasks = new List<Task>
            {
                Task.Factory.StartNew(() => GetAssignedToUsers(properties, data)),
                Task.Factory.StartNew(() => GetChangedProperties(properties, data))
            };

            Task.WaitAll(tasks.ToArray());

            SocialEngineProxy.ProcessActivity(ObjectKind.ListItem, ActivityKind.Updated, data, properties.Web);
        }

        // Private Methods (2) 

        private static void GetAssignedToUsers(SPItemEventProperties properties, Dictionary<string, object> data)
        {
            var users = new List<int>();
            var oldUsers = new List<int>();

            if (properties.List.Fields.ContainsFieldWithInternalName("AssignedTo"))
            {
                object assignedToUsers = properties.ListItem["AssignedTo"];
                if (assignedToUsers != null)
                {
                    var collection = (SPFieldUserValueCollection) assignedToUsers;
                    users.AddRange(collection.Select(userValue => userValue.LookupId));
                }
            }

            data.Add("AssignedTo", string.Join(",", users.AsParallel().Distinct().ToArray()));
        }

        private static void GetChangedProperties(SPItemEventProperties properties, Dictionary<string, object> data)
        {
            SPFieldCollection collection = properties.List.Fields;

            List<string> changedProperties = (from SPField spField in collection
                where !spField.Hidden && !spField.ReadOnlyField
                let internalName = spField.InternalName
                where properties.ListItem[internalName] != properties.BeforeProperties[internalName]
                select spField.Title).ToList();

            data.Add("ChangedProperties", string.Join(",", changedProperties.ToArray()));
        }

        #endregion Methods 
    }
}