using EPMLiveCore;
using EPMLiveCore.ListDefinitions;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkEnginePPM.Core.DataSync;
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Events.DataSync
{
    /// <summary>
    ///     List Item Events
    /// </summary>
    public class HolidayScheduleSyncEvent : SPItemEventReceiver
    {
        #region Methods (7) 

        // Public Methods (4) 

        /// <summary>
        ///     An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;
            try
            {
                using (var holidayManager = new HolidayManager(properties.Web))
                {
                    holidayManager.AddPFEHolidays(properties);
                    List<HolidaySchedule> existingHolidaySchedules = holidayManager.GetExistingHolidaySchedules(properties.List.Items);
                    List<HolidaySchedule> newHolidaySchedules = existingHolidaySchedules.Where(holidaySchedule => holidaySchedule.Id.Equals(properties.ListItemId)).ToList<HolidaySchedule>();
                    holidayManager.Synchronize(newHolidaySchedules);                                        
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
        ///     An item is being added.
        /// </summary>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return;

            try
            {
                List<HolidaySchedule> newholidaySchedules = new List<HolidaySchedule>();
                List<HolidaySchedule> holidaySchedules;                

                object title = properties.AfterProperties["Title"];

                if (title == null) throw new Exception("Title cannot be empty.");

                using (var holidayManager = new HolidayManager(properties.Web))
                {
                    holidaySchedules = holidayManager.GetExistingHolidaySchedules(properties.List.Items);
                    var existingSchedule = holidaySchedules.Where(hs => hs.Title.Equals(title.ToString(), StringComparison.InvariantCultureIgnoreCase));
                    if (existingSchedule.Count() > 0)
                    {
                        throw new Exception(string.Format("Holiday schedule with title '{0}' already exists.", title.ToString()));                        
                    }
                }

                bool isDefault = bool.Parse((properties.AfterProperties["IsDefault"] ?? false).ToString());

                Guid uniqueId = Guid.NewGuid();

                using (var holidayManager = new HolidayManager(properties.Web))
                {
                    newholidaySchedules.Add(new HolidaySchedule
                    {
                        Title = (string)title,
                        IsDefault = isDefault,
                        UniqueId = uniqueId,
                        Holidays = new List<Holiday>()
                    });                    
                    
                    // Syncs only that holiday schedule which is recently created.
                    newholidaySchedules = holidayManager.Synchronize(newholidaySchedules);                    
                }

                UpdateDefault(properties, uniqueId, isDefault);
                SetExtId(properties, uniqueId, newholidaySchedules);
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        ///     An item is being deleted.
        /// </summary>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return;

            try
            {
                SPListItem spListItem = properties.ListItem;

                var extId = spListItem["EXTID"] as string;

                if (string.IsNullOrEmpty(extId)) return;

                using (var holidayManager = new HolidayManager(properties.Web))
                {
                    var holidaySchedule = new HolidaySchedule
                    {
                        Id = (int?) spListItem["ID"],
                        ExtId = extId,
                        UniqueId = spListItem.UniqueId
                    };

                    if (!holidayManager.DeleteSchedule(holidaySchedule)) return;

                    EventFiringEnabled = false;

                    IEnumerable<SPList> spLists = properties.Web.GetListByTemplateId((int) EPMLiveLists.Holidays);
                    if (spLists == null) throw new Exception("Cannot find the Holidays list.");

                    SPList spList = spLists.First();
                    SPListItemCollection spListItemCollection = spList.Items;

                    IEnumerable<int> holidaysToDelete = from SPListItem listItem in spListItemCollection
                        let spFieldLookupValue =
                            new SPFieldLookupValue(
                                (string) listItem["HolidaySchedule"])
                        where spFieldLookupValue.LookupId == spListItem.ID
                        select listItem.ID;

                    foreach (int holidayId in holidaysToDelete)
                    {
                        spList.Items.DeleteItemById(holidayId);
                    }

                    EventFiringEnabled = true;
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
        ///     An item is being updated.
        /// </summary>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            if (properties.ListItem == null) return;

            if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return;

            try
            {
                using (var holidayManager = new HolidayManager(properties.Web))
                {
                    List<HolidaySchedule> holidaySchedules =
                        holidayManager.GetExistingHolidaySchedules(properties.List.Items);

                    object title = properties.AfterProperties["Title"] ?? properties.ListItem["Title"];
                    object extId = properties.AfterProperties["EXTID"] ?? properties.ListItem["EXTID"];

                    if (title == null) throw new Exception("Title cannot be empty.");
                    if (extId == null) throw new Exception("External ID cannot be empty.");

                    HolidaySchedule existingSchedule = holidaySchedules.Where(hs => hs.Title.Equals(title.ToString(), StringComparison.InvariantCultureIgnoreCase)).First();
                    // Cancel holiday schedule updation if it is already exist with same title.
                    // Also ignore if same schedule is getting updated.
                    if (existingSchedule != null && existingSchedule.Id != properties.ListItemId)
                    {
                        throw new Exception(string.Format("Holiday schedule with title '{0}' already exists.", title.ToString()));
                    }

                    bool isDefault =
                        bool.Parse(
                            (properties.AfterProperties["IsDefault"] ?? (properties.ListItem["IsDefault"] ?? false))
                                .ToString());

                    Guid uniqueId = properties.ListItem.UniqueId;                    
                    List<HolidaySchedule> updatedHolidaySchedules = new List<HolidaySchedule>();

                    foreach (HolidaySchedule holidaySchedule in holidaySchedules
                        .Where(holidaySchedule => holidaySchedule.UniqueId == uniqueId))
                    {
                        holidaySchedule.Title = (string)title;
                        holidaySchedule.IsDefault = isDefault;
                        holidaySchedule.ExtId = (string)extId;
                        // Populating only updated holiday schedule
                        updatedHolidaySchedules.Add(holidaySchedule);
                        break;
                    }

                    // Syncs only the updated holiday schedule with PFE Database
                    updatedHolidaySchedules = holidayManager.Synchronize(updatedHolidaySchedules);
                    UpdateDefault(properties, uniqueId, isDefault);
                    SetExtId(properties, uniqueId, updatedHolidaySchedules);

                    holidayManager.AddPFEHolidays(properties);
                }
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        // Private Methods (3) 

        /// <summary>
        ///     Sets the ext id.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="uniqueId">The unique id.</param>
        /// <param name="holidaySchedules">The holiday schedules.</param>
        private void SetExtId(SPItemEventProperties properties, Guid uniqueId,
            IEnumerable<HolidaySchedule> holidaySchedules)
        {
            EventFiringEnabled = false;

            foreach (HolidaySchedule holidaySchedule in holidaySchedules)
            {
                if (holidaySchedule.UniqueId == uniqueId)
                {
                    properties.AfterProperties["EXTID"] = holidaySchedule.ExtId;
                }
                else
                {
                    SPListItem spListItem = properties.List.GetItemByUniqueId(holidaySchedule.UniqueId);

                    spListItem["EXTID"] = holidaySchedule.ExtId;
                    spListItem.SystemUpdate();
                }
            }

            EventFiringEnabled = true;
        }

        /// <summary>
        ///     Updates the default.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="uniqueId">The unique id.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        private void UpdateDefault(SPItemEventProperties properties, Guid uniqueId, bool isDefault)
        {
            if (!isDefault) return;

            EventFiringEnabled = false;

            SPListItemCollection spListItemCollection = properties.List.Items;

            foreach (SPListItem listItem in from SPListItem spListItem in spListItemCollection
                where spListItem.UniqueId != uniqueId
                select spListItem.ParentList.GetItemByUniqueId(spListItem.UniqueId))
            {
                listItem["IsDefault"] = false;
                listItem.SystemUpdate();
            }

            EventFiringEnabled = true;
        }

        /// <summary>
        ///     Validates the request.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private bool ValidateRequest(SPItemEventProperties properties)
        {
            return properties.OpenSite().Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null &&
                   properties.List.Title.Equals("Holiday Schedules");
        }

        #endregion Methods 
    }
}