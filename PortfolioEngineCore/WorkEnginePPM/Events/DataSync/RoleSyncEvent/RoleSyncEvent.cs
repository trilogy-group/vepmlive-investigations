using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.DataSync;
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Events.DataSync
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class RoleSyncEvent : SPItemEventReceiver
    {
        #region Methods (6) 

        // Public Methods (4) 

        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                using (var roleManager = new RoleManager(properties.Web))
                {
                    roleManager.AddOrUpdate(new Role
                                                {
                                                    RoleId = properties.ListItem["RoleId"].ToString(),
                                                    Id = properties.ListItem.ID,
                                                    Title = properties.ListItem.Title
                                                });

                    roleManager.RunRefresh();
                }
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        /// An item is being added.
        /// </summary>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                object title = properties.AfterProperties["Title"];
                if (title == null) throw new Exception("Title cannot be empty.");

                //-- EPML-3648
                string sTitle = Convert.ToString(properties.AfterProperties["Title"]).Trim();
                string strQuery = "<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + sTitle + "</Value></Eq></Where>";
                SPQuery query = new SPQuery();
                query.Query = strQuery;
                SPListItemCollection items = properties.List.GetItems(query);
                if (items.Count > 0)
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = "Role with title '" + sTitle + "' already exists.";
                    return;
                }
                // ---

                List<Role> roles;
                Role role;

                using (var roleManager = new RoleManager(properties.Web))
                {
                    role = new Role {Title = (string) title};
                    roles = roleManager.AddOrUpdate(role);
                }

                AutoCorrectList(role, roles, properties);
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        /// An item is being deleted.
        /// </summary>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                using (var roleManager = new RoleManager(properties.Web))
                {
                    SPListItem spListItem = properties.ListItem;

                    roleManager.Delete(new Role
                                           {
                                               Id = spListItem.ID,
                                               RoleId = (string) spListItem["RoleId"],
                                               CCRId = (string) spListItem["EXTID"]
                                           });
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.ToLower().Contains("cannot find the role id")) return;
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        /// An item is being updated.
        /// </summary>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            if (properties.ListItem == null || !ValidateRequest(properties)) return;

            try
            {
                var title = (properties.AfterProperties["Title"] ?? properties.ListItem["Title"]) as string;
                if (string.IsNullOrEmpty(title)) throw new Exception("Title cannot be empty.");

                var roleId = (properties.AfterProperties["RoleId"] ?? properties.ListItem["RoleId"]) as string;
                if (string.IsNullOrEmpty(roleId)) return;

                List<Role> roles;
                Role role;

                //-- EPML-3648
                string sTitle = Convert.ToString(properties.AfterProperties["Title"]).Trim();
                SPQuery query = new SPQuery();
                query.Query =
                    "<Where>" +
                    "<And>" +
                        "<Eq><FieldRef Name='Title' /><Value Type='Text'>" + sTitle + "</Value></Eq>" +
                        "<Neq><FieldRef Name='UniqueId' /><Value Type='Text'>" + properties.ListItem.UniqueId.ToString().ToUpper() + "</Value></Neq>" +
                    "</And>" +
                    "</Where>";
                SPListItemCollection items = properties.List.GetItems(query);
                if (items.Count > 0)
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = "Role with title '" + sTitle + "' already exists.";
                    return;
                }
                // ---

                using (var roleManager = new RoleManager(properties.Web))
                {
                    role = new Role
                               {
                                   RoleId = roleId,
                                   Id = properties.ListItem.ID,
                                   Title = title
                               };

                    roles = roleManager.AddOrUpdate(role);
                }

                role.CCRId = (properties.AfterProperties["EXTID"] ?? properties.ListItem["EXTID"]) as string;
                role.CCRName = (properties.AfterProperties["CCRName"] ?? properties.ListItem["CCRName"]) as string;

                AutoCorrectList(role, roles, properties);
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        // Private Methods (2) 

        /// <summary>
        /// Autoes the correct list.
        /// </summary>
        /// <param name="currentRole">The current role.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="properties">The properties.</param>
        private void AutoCorrectList(Role currentRole, IEnumerable<Role> roles, SPItemEventProperties properties)
        {
            EventFiringEnabled = false;

            var rolesToSync = new List<Role>();

            SPListItemCollection listItemCollection = properties.List.Items;

            List<Role> existingRoles = (from SPListItem spListItem in listItemCollection
                                        select new Role
                                                   {
                                                       Id = spListItem.ID,
                                                       RoleId = spListItem["RoleId"] as string ?? string.Empty,
                                                       Title = spListItem["Title"] as string ?? string.Empty,
                                                       CCRId = spListItem["EXTID"] as string ?? string.Empty,
                                                       CCRName = spListItem["CCRName"] as string ?? string.Empty,
                                                   }).ToList();

            foreach (Role role in roles)
            {
                if (role.Id == null)
                {
                    if (currentRole.Title.Equals(role.Title))
                    {
                        properties.AfterProperties["EXTID"] = role.CCRId;
                        properties.AfterProperties["RoleId"] = role.RoleId;
                        properties.AfterProperties["CCRName"] = role.CCRName;

                        continue;
                    }

                    Role existingRole =
                        (from r in existingRoles where r.Title.Equals(role.Title) && r.CCRId.Equals(role.CCRId) select r)
                            .FirstOrDefault() ??
                        (from r in existingRoles where r.Title.Equals(role.Title) select r).FirstOrDefault();

                    if (existingRole != null)
                    {
                        if (existingRole.Id == null) continue;

                        role.Id = existingRole.Id;

                        SPListItem spListItem = properties.List.GetItemById((int) role.Id);

                        spListItem["EXTID"] = role.CCRId;
                        spListItem["RoleId"] = role.RoleId;
                        spListItem["CCRName"] = role.CCRName;

                        spListItem.SystemUpdate();
                    }
                    else
                    {
                        SPListItem spListItem = properties.List.Items.Add();

                        spListItem["Title"] = role.Title;
                        spListItem["EXTID"] = role.CCRId;
                        spListItem["RoleId"] = role.RoleId;
                        spListItem["CCRName"] = role.CCRName;

                        spListItem.SystemUpdate();

                        role.Id = spListItem.ID;
                    }

                    existingRoles.Add(role);
                    rolesToSync.Add(role);

                    continue;
                }

                if (currentRole.Id == role.Id)
                {
                    if (currentRole.CCRId.Equals(role.CCRId))
                    {
                        properties.AfterProperties["Title"] = role.Title;
                        properties.AfterProperties["RoleId"] = role.RoleId;
                        properties.AfterProperties["EXTID"] = role.CCRId;
                        properties.AfterProperties["CCRName"] = role.CCRName;

                        continue;
                    }

                    Role existingRole =
                        (from r in existingRoles
                         where r.RoleId.Equals(role.RoleId) && r.CCRId.Equals(role.CCRId)
                         select r).FirstOrDefault();

                    bool isNew = false;
                    SPListItem spListItem;

                    if (existingRole != null)
                    {
                        spListItem = properties.List.GetItemById((int) existingRole.Id);

                        existingRoles.Remove(existingRole);

                        existingRole.Title = role.Title;
                        existingRole.RoleId = role.RoleId;
                        existingRole.CCRId = role.CCRId;
                        existingRole.CCRName = role.CCRName;

                        existingRoles.Add(existingRole);
                        rolesToSync.Add(existingRole);
                    }
                    else
                    {
                        spListItem = properties.List.Items.Add();
                        isNew = true;
                    }

                    spListItem["Title"] = role.Title;
                    spListItem["RoleId"] = role.RoleId;
                    spListItem["EXTID"] = role.CCRId;
                    spListItem["CCRName"] = role.CCRName;

                    spListItem.SystemUpdate();

                    if (isNew)
                    {
                        role.Id = spListItem.ID;
                        existingRoles.Add(role);
                        rolesToSync.Add(role);
                    }
                }
                else
                {
                    bool isNew = false;
                    SPListItem spListItem;

                    Role existingRole =
                        (from r in existingRoles
                         where r.RoleId.Equals(role.RoleId) && r.CCRName.Equals(role.CCRName)
                         select r).FirstOrDefault() ??
                        (from r in existingRoles
                         where r.RoleId.Equals(role.RoleId) && r.CCRId.Equals(role.CCRId)
                         select r).FirstOrDefault() ??
                        (from r in existingRoles
                         where r.Title.Equals(role.Title) && string.IsNullOrEmpty(r.RoleId)
                         select r).FirstOrDefault();

                    if (existingRole != null)
                    {
                        spListItem = properties.List.GetItemById((int) existingRole.Id);

                        existingRoles.Remove(existingRole);

                        existingRole.Title = role.Title;
                        existingRole.RoleId = role.RoleId;
                        existingRole.CCRId = role.CCRId;
                        existingRole.CCRName = role.CCRName;

                        existingRoles.Add(existingRole);
                        rolesToSync.Add(existingRole);
                    }
                    else
                    {
                        spListItem = properties.List.Items.Add();
                        isNew = true;
                    }

                    spListItem["Title"] = role.Title;
                    spListItem["EXTID"] = role.CCRId;
                    spListItem["RoleId"] = role.RoleId;
                    spListItem["CCRName"] = role.CCRName;

                    spListItem.SystemUpdate();

                    if (isNew)
                    {
                        role.Id = spListItem.ID;
                        existingRoles.Add(role);
                        rolesToSync.Add(role);
                    }
                }
            }

            SPListItemCollection spListItemCollection = properties.List.Items;
            rolesToSync.AddRange(from SPListItem spListItem in spListItemCollection
                                 where string.IsNullOrEmpty(spListItem["RoleId"] as string)
                                 select spListItem["Title"] as string
                                 into title where !string.IsNullOrEmpty(title) select new Role {Title = title});

            using (var roleManager = new RoleManager(properties.Web))
            {
                foreach (Role role in rolesToSync.Distinct())
                {
                    roleManager.AddOrUpdate(role);
                }
            }

            EventFiringEnabled = true;
        }

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private bool ValidateRequest(SPItemEventProperties properties)
        {
            if (properties.OpenSite().Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] == null) return false;
            if (!properties.List.Title.Equals("Roles")) return false;
            if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return false;
            return properties.List.Fields.ContainsFieldWithInternalName("RoleId") &&
                   properties.List.Fields.ContainsFieldWithInternalName("CCRName");
        }

        #endregion Methods 
    }
}