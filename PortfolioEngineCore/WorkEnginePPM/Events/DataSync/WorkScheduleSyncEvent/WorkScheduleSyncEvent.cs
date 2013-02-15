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
    public class WorkScheduleSyncEvent : SPItemEventReceiver
    {
        #region Methods (8) 

        // Public Methods (4) 

        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                using (var workScheduleManager = new WorkScheduleManager(properties.Web))
                {
                    SPListItem spListItem = properties.ListItem;

                    workScheduleManager.Synchronize(new List<WorkSchedule>
                                                        {
                                                            new WorkSchedule
                                                                {
                                                                    Id = spListItem.ID,
                                                                    Title = (string) spListItem["Title"],
                                                                    Sunday = (decimal) spListItem["Sunday"],
                                                                    Monday = (decimal) spListItem["Monday"],
                                                                    Tuesday = (decimal) spListItem["Tuesday"],
                                                                    Wednesday = (decimal) spListItem["Wednesday"],
                                                                    Thursday = (decimal) spListItem["Thursday"],
                                                                    Friday = (decimal) spListItem["Friday"],
                                                                    Saturday = (decimal) spListItem["Saturday"],
                                                                    IsDefault = (bool) spListItem["IsDefault"],
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

            try
            {
                object friday;
                object thursday;
                object saturday;
                object wednesday;
                object sunday;
                object title;
                object tuesday;
                object monday;
                object isDefault;

                GetFieldValues(properties, out title, out sunday, out monday, out tuesday, out wednesday, out thursday,
                               out friday, out saturday, out isDefault);

                bool Default = bool.Parse(isDefault.ToString());

                List<WorkSchedule> workSchedules;

                Guid uniqueId = Guid.NewGuid();

                WorkSchedule workSchedule;

                using (var workScheduleManager = new WorkScheduleManager(properties.Web))
                {
                    workSchedules = workScheduleManager.GetExistingWorkSchedules(properties.List.Items);

                    workSchedule = new WorkSchedule
                                       {
                                           Title = (string) title,
                                           Sunday = (decimal) sunday,
                                           Monday = (decimal) monday,
                                           Tuesday = (decimal) tuesday,
                                           Wednesday = (decimal) wednesday,
                                           Thursday = (decimal) thursday,
                                           Friday = (decimal) friday,
                                           Saturday = (decimal) saturday,
                                           IsDefault = Default,
                                           UniqueId = uniqueId
                                       };

                    workSchedules.Add(workSchedule);

                    workScheduleManager.Synchronize(workSchedules);
                }

                UpdateDefault(properties, uniqueId, Default);
                SetExtId(properties, uniqueId, workSchedules);

                using (var workScheduleManager = new WorkScheduleManager(properties.Web))
                {
                    workScheduleManager.AddPFEWorkSchedules(workSchedule);
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
        /// An item is being deleted.
        /// </summary>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                using (var workScheduleManager = new WorkScheduleManager(properties.Web))
                {
                    SPListItem spListItem = properties.ListItem;

                    workScheduleManager.Delete(new WorkSchedule
                                                   {
                                                       Id = spListItem.ID,
                                                       ExtId = (string) spListItem["EXTID"],
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

            try
            {
                object friday;
                object thursday;
                object saturday;
                object wednesday;
                object sunday;
                object title;
                object tuesday;
                object monday;
                object isDefault;

                GetFieldValues(properties, out title, out sunday, out monday, out tuesday, out wednesday, out thursday,
                               out friday, out saturday, out isDefault);

                bool Default = bool.Parse(isDefault.ToString());

                object extId = properties.AfterProperties["EXTID"] ?? properties.ListItem["EXTID"];
                if (extId == null) throw new Exception("External ID cannot be empty.");

                var ws = new WorkSchedule();

                using (var workScheduleManager = new WorkScheduleManager(properties.Web))
                {
                    List<WorkSchedule> workSchedules =
                        workScheduleManager.GetExistingWorkSchedules(properties.List.Items);

                    SPListItem spListItem = properties.ListItem;

                    Guid uniqueId = spListItem.UniqueId;

                    foreach (
                        WorkSchedule workSchedule in
                            workSchedules.Where(workSchedule => workSchedule.UniqueId == uniqueId))
                    {
                        workSchedule.Title = (string) title;
                        workSchedule.Sunday = (decimal) sunday;
                        workSchedule.Monday = (decimal) monday;
                        workSchedule.Tuesday = (decimal) tuesday;
                        workSchedule.Wednesday = (decimal) wednesday;
                        workSchedule.Thursday = (decimal) thursday;
                        workSchedule.Friday = (decimal) friday;
                        workSchedule.Saturday = (decimal) saturday;
                        workSchedule.IsDefault = Default;
                        workSchedule.ExtId = (string) extId;

                        ws = workSchedule;

                        break;
                    }

                    workSchedules = workScheduleManager.Synchronize(workSchedules);

                    UpdateDefault(properties, uniqueId, Default);
                    SetExtId(properties, uniqueId, workSchedules);

                    workScheduleManager.AddPFEWorkSchedules(ws);
                }
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        // Private Methods (4) 

        /// <summary>
        /// Gets the field values.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="title">The title.</param>
        /// <param name="sunday">The sunday.</param>
        /// <param name="monday">The monday.</param>
        /// <param name="tuesday">The tuesday.</param>
        /// <param name="wednesday">The wednesday.</param>
        /// <param name="thursday">The thursday.</param>
        /// <param name="friday">The friday.</param>
        /// <param name="saturday">The saturday.</param>
        /// <param name="isDefault">The is default.</param>
        private static void GetFieldValues(SPItemEventProperties properties, out object title, out object sunday,
                                           out object monday, out object tuesday, out object wednesday,
                                           out object thursday, out object friday, out object saturday,
                                           out object isDefault)
        {
            title = properties.AfterProperties["Title"] ?? properties.ListItem["Title"];
            if (title == null) throw new Exception("Title cannot be empty.");

            sunday = properties.AfterProperties["Sunday"] ?? properties.ListItem["Sunday"];
            if (sunday == null) throw new Exception("Please provide work hours for Sunday.");
            sunday = decimal.Parse((string) sunday);

            monday = properties.AfterProperties["Monday"] ?? properties.ListItem["Monday"];
            if (monday == null) throw new Exception("Please provide work hours for Monday.");
            monday = decimal.Parse((string) monday);

            tuesday = properties.AfterProperties["Tuesday"] ?? properties.ListItem["Tuesday"];
            if (tuesday == null) throw new Exception("Please provide work hours for Tuesday.");
            tuesday = decimal.Parse((string) tuesday);

            wednesday = properties.AfterProperties["Wednesday"] ?? properties.ListItem["Wednesday"];
            if (wednesday == null) throw new Exception("Please provide work hours for Wednesday.");
            wednesday = decimal.Parse((string) wednesday);

            thursday = properties.AfterProperties["Thursday"] ?? properties.ListItem["Thursday"];
            if (thursday == null) throw new Exception("Please provide work hours for Thursday.");
            thursday = decimal.Parse((string) thursday);

            friday = properties.AfterProperties["Friday"] ?? properties.ListItem["Friday"];
            if (friday == null) throw new Exception("Please provide work hours for Friday.");
            friday = decimal.Parse((string) friday);

            saturday = properties.AfterProperties["Saturday"] ?? properties.ListItem["Saturday"];
            if (saturday == null) throw new Exception("Please provide work hours for Saturday.");
            saturday = decimal.Parse((string) saturday);

            isDefault = properties.AfterProperties["IsDefault"] ?? false;
        }

        /// <summary>
        /// Sets the ext id.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="uniqueId">The unique id.</param>
        /// <param name="workSchedules">The work schedules.</param>
        private void SetExtId(SPItemEventProperties properties, Guid uniqueId, IEnumerable<WorkSchedule> workSchedules)
        {
            EventFiringEnabled = false;

            foreach (WorkSchedule workSchedule in workSchedules)
            {
                if (workSchedule.UniqueId == uniqueId)
                {
                    properties.AfterProperties["EXTID"] = workSchedule.ExtId;
                }
                else
                {
                    SPListItem spListItem = properties.List.GetItemByUniqueId(workSchedule.UniqueId);

                    spListItem["EXTID"] = workSchedule.ExtId;
                    spListItem.SystemUpdate();
                }
            }

            EventFiringEnabled = true;
        }

        /// <summary>
        /// Updates the default.
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
        /// Validates the request.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private bool ValidateRequest(SPItemEventProperties properties)
        {
            return properties.OpenSite().Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null &&
                   properties.List.Title.Equals("Work Hours");
        }

        #endregion Methods 
    }
}