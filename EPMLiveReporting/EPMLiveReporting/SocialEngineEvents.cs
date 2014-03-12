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
        #region Methods (6) 

        // Public Methods (4) 

        public static bool AreEqualObjects(object obj1, object obj2)
        {
            if (obj1 == null) return obj2 == null;
            return obj2 != null && obj1.ToString().Equals(obj2.ToString());
        }

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
            GetAssociatedListItems(properties, data);

            SocialEngineProxy.ProcessActivity(ObjectKind.ListItem, ActivityKind.Created, data, properties.Web);
        }

        public static void ItemDeleting(SPItemEventProperties properties)
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
                {"UserId", properties.Web.CurrentUser.ID},
                {"ActivityTime", DateTime.Now}
            };

            GetAssociatedListItems(properties, data);

            SocialEngineProxy.ProcessActivity(ObjectKind.ListItem, ActivityKind.Deleted, data, properties.Web);
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

            GetAssignedToUsers(properties, data);
            GetAssociatedListItems(properties, data);

            SocialEngineProxy.ProcessActivity(ObjectKind.ListItem, ActivityKind.Updated, data, properties.Web);
        }

        // Private Methods (2) 

        private static void GetAssignedToUsers(SPItemEventProperties properties, Dictionary<string, object> data)
        {
            var users = new List<int>();

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

        private static void GetAssociatedListItems(SPItemEventProperties properties, Dictionary<string, object> data)
        {
            var dict = new Dictionary<Guid, int>();

            SPFieldCollection fields = properties.List.Fields;

            foreach (SPField field in fields)
            {
                if (field.Hidden || field.Type != SPFieldType.Lookup) continue;

                object value = properties.ListItem[field.InternalName];

                if (value == null) continue;

                var lookup = ((SPFieldLookup) field);

                if (lookup.AllowMultipleValues) continue;

                Guid listId;
                if (!Guid.TryParse(lookup.LookupList, out listId)) continue;

                var val = value as string;
                if (string.IsNullOrEmpty(val)) continue;

                var lookupValue = new SPFieldLookupValue(val);

                if (!dict.ContainsKey(listId)) dict.Add(listId, lookupValue.LookupId);
                else dict[listId] = lookupValue.LookupId;
            }

            List<string> list = dict.Select(lv => string.Format(@"{0}|{1}", lv.Key, lv.Value)).ToList();

            data.Add("AssociatedListItems", string.Join(",", list.Distinct().ToArray()));
        }

        #endregion Methods 
    }
}