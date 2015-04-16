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
    public class PersonalItemsEvent : SPItemEventReceiver
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
                using (var personalItemManager = new PersonalItemManager(properties.Web))
                {
                    SPListItem spListItem = properties.ListItem;

                    personalItemManager.Synchronize(new List<PersonalItem>
                                                        {
                                                            new PersonalItem
                                                                {
                                                                    Id = spListItem.ID,
                                                                    Title = (string) spListItem["Title"],
                                                                    ExtId = (string) spListItem["EXTID"],
                                                                    UniqueId = spListItem.UniqueId
                                                                }
                                                        });
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

            if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return;

            var personalItem = new PersonalItem();

            object title = properties.AfterProperties["Title"];

            try
            {
                if (title == null) throw new Exception("Title cannot be empty.");

                //-- EPML-3648
                string sTitle = properties.AfterProperties["Title"].ToString().Trim();
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + sTitle + "</Value></Eq></Where>";
                SPListItemCollection items = properties.List.GetItems(query);
                if (items.Count > 0)
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = "Non work with title '" + sTitle + "' already exists.";
                    return;
                }
                // ---

                List<PersonalItem> personalItems;

                Guid uniqueId = Guid.NewGuid();

                using (var personalItemManager = new PersonalItemManager(properties.Web))
                {
                    personalItems = personalItemManager.GetExistingPersonalItems(properties.List.Items);
                    personalItem = new PersonalItem {Title = (string) title, UniqueId = uniqueId};
                    personalItems.Add(personalItem);

                    personalItems = personalItemManager.Synchronize(personalItems);
                }

                SetExtId(properties, uniqueId, personalItems);
            }
            catch (Exception exception)
            {
                if (exception.Message.ToLower().Contains("incomplete item list"))
                {
                    try
                    {
                        using (var personalItemManager = new PersonalItemManager(properties.Web))
                        {
                            personalItemManager.AddPFEPersonalItems(personalItem);
                        }

                        SPListItem spListItem = properties.List.AddItem();
                        spListItem["Title"] = title;
                        spListItem.Update();

                        properties.Cancel = true;
                        properties.Status = SPEventReceiverStatus.CancelNoError;
                    }
                    catch (Exception e)
                    {
                        properties.Cancel = true;
                        properties.ErrorMessage = e.Message;
                        properties.Status = SPEventReceiverStatus.CancelWithError;
                    }
                }
                else
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = exception.Message;
                    properties.Status = SPEventReceiverStatus.CancelWithError;
                }
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
                SPListItem spListItem = properties.ListItem;

                if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return;

                var extId = spListItem["EXTID"] as string;

                if (string.IsNullOrEmpty(extId)) return;

                using (var personalItemManager = new PersonalItemManager(properties.Web))
                {
                    personalItemManager.Delete(new PersonalItem
                                                   {
                                                       Id = spListItem.ID,
                                                       ExtId = extId,
                                                       UniqueId = spListItem.UniqueId
                                                   });
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
        /// An item is being updated.
        /// </summary>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            if (properties.ListItem == null) return;

            if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return;

            var personalItem = new PersonalItem();

            string title = null;
            string extId = null;

            try
            {
                title = (string) (properties.AfterProperties["Title"] ?? properties.ListItem["Title"]);
                if (string.IsNullOrEmpty(title)) throw new Exception("Title cannot be empty.");

                extId = (string) (properties.AfterProperties["EXTID"] ?? properties.ListItem["EXTID"]);
                if (string.IsNullOrEmpty(extId)) throw new Exception("External ID cannot be empty.");

                ////-----
                string sTitle = properties.AfterProperties["Title"].ToString().Trim();
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
                    properties.ErrorMessage = "Non work with title '" + sTitle + "' already exists.";
                    return;
                }
                ////----

                using (var personalItemManager = new PersonalItemManager(properties.Web))
                {
                    SPListItem spListItem = properties.ListItem;

                    List<PersonalItem> personalItems =
                        personalItemManager.GetExistingPersonalItems(properties.List.Items);

                    personalItems.Remove((personalItems.Where(p => p.Id == spListItem.ID)).FirstOrDefault());

                    personalItem = new PersonalItem
                                       {
                                           Id = spListItem.ID,
                                           Title = title,
                                           ExtId = extId,
                                           UniqueId = spListItem.UniqueId
                                       };

                    personalItems.Add(personalItem);

                    personalItems = personalItemManager.Synchronize(personalItems);

                    SetExtId(properties, spListItem.UniqueId, personalItems);
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.ToLower().Contains("incomplete item list"))
                {
                    try
                    {
                        using (var personalItemManager = new PersonalItemManager(properties.Web))
                        {
                            personalItemManager.AddPFEPersonalItems(personalItem);
                        }

                        properties.ListItem["Title"] = title;
                        properties.ListItem["EXTID"] = extId;

                        properties.ListItem.Update();

                        properties.Cancel = true;
                        properties.Status = SPEventReceiverStatus.CancelNoError;
                    }
                    catch (Exception e)
                    {
                        properties.Cancel = true;
                        properties.ErrorMessage = e.Message;
                        properties.Status = SPEventReceiverStatus.CancelWithError;
                    }
                }
                else
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = exception.Message;
                    properties.Status = SPEventReceiverStatus.CancelWithError;
                }
            }
        }

        // Private Methods (2) 

        /// <summary>
        /// Sets the ext id.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="uniqueId">The unique id.</param>
        /// <param name="personalItems">The personal items.</param>
        private void SetExtId(SPItemEventProperties properties, Guid uniqueId, IEnumerable<PersonalItem> personalItems)
        {
            EventFiringEnabled = false;

            foreach (PersonalItem personalItem in personalItems)
            {
                if (personalItem.UniqueId == uniqueId)
                {
                    properties.AfterProperties["EXTID"] = personalItem.ExtId;
                }
                else
                {
                    SPListItem spListItem = properties.List.GetItemByUniqueId(personalItem.UniqueId);

                    spListItem["EXTID"] = personalItem.ExtId;
                    spListItem.SystemUpdate();
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
            return properties.OpenSite().Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null &&
                   properties.List.Title.Equals("Non Work");
        }

        #endregion Methods 
    }
}