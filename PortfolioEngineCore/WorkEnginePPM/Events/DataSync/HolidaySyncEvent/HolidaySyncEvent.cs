using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore;
using EPMLiveCore.ListDefinitions;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.DataSync;
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Events.DataSync
{
    /// <summary>
    ///     List Item Events
    /// </summary>
    public class HolidaySyncEvent : SPItemEventReceiver
    {
        #region Methods (5)

        // Public Methods (3) 

        /// <summary>
        ///     An item is being added.
        /// </summary>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return;

            try
            {
                object schedule;
                object hours;
                object title;
                object date;

                GetFieldValues(properties, out schedule, out hours, out title, out date);

                Guid uniqueId = Guid.NewGuid();

                var newHoliday = new Holiday
                {
                    Title = (string)title,
                    Date = (string)date,
                    Hours = (double)hours,
                    UniqueId = uniqueId
                };

                int newHolidayScheduleId = new SPFieldLookupValue((string)schedule).LookupId;

                SPWeb spWeb = properties.Web;

                using (var holidayManager = new HolidayManager(spWeb))
                {
                    IEnumerable<SPList> spLists = spWeb.GetListByTemplateId((int)EPMLiveLists.HolidaySchedules);
                    if (spLists == null) throw new Exception("Cannot find the Holiday Schedules list.");

                    List<HolidaySchedule> holidaySchedules =
                        holidayManager.GetExistingHolidaySchedules(spLists.First().Items);

                    List<HolidaySchedule> newHolidaySchedules = new List<HolidaySchedule>();

                    foreach (HolidaySchedule holidaySchedule in holidaySchedules
                        .Where(holidaySchedule => holidaySchedule.Id == newHolidayScheduleId))
                    {
                        #region Check for duplicate holiday

                        int newHolidayYear = Convert.ToDateTime(date).Year;
                        bool duplicateHoliday = false;
                        foreach (Holiday currentHoliday in holidaySchedule.Holidays
                        .Where(currentHoliday => currentHoliday.Title.Equals((string)title, StringComparison.InvariantCultureIgnoreCase)
                        && Convert.ToDateTime(currentHoliday.Date).Year.Equals(newHolidayYear)))
                        {
                            duplicateHoliday = true;
                            break;
                        }
                        if (duplicateHoliday)
                        {
                            throw new Exception(string.Format("Holiday with title '{0}' already exists in holiday schedule '{1}' for year '{2}'", title, holidaySchedule.Title, newHolidayYear));
                        }

                        #endregion

                        holidaySchedule.Holidays.Add(newHoliday);
                        // Populates only that holiday schedule in which the new holiday is added.
                        newHolidaySchedules.Add(holidaySchedule);
                    }

                    // Syncs only that holiday schedule which is updated with new holiday.
                    holidayManager.Synchronize(newHolidaySchedules);
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

        /// <summary>
        ///     An item is being deleted.
        /// </summary>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                SPWeb spWeb = properties.Web;

                using (var holidayManager = new HolidayManager(spWeb))
                {
                    IEnumerable<SPList> spLists = spWeb.GetListByTemplateId((int)EPMLiveLists.HolidaySchedules);
                    if (spLists == null) throw new Exception("Cannot find the Holiday Schedules list.");

                    List<HolidaySchedule> holidaySchedules =
                        holidayManager.GetExistingHolidaySchedules(spLists.First().Items);

                    bool holidayToDeleteFound = false;

                    Holiday holidayToDelete = null;
                    int holidayScheduleIndex = -1;

                    for (int index = 0; index < holidaySchedules.Count; index++)
                    {
                        HolidaySchedule holidaySchedule = holidaySchedules[index];

                        foreach (Holiday holiday in holidaySchedule.Holidays
                            .Where(holiday => holiday.Id == properties.ListItem.ID))
                        {
                            holidayToDelete = holiday;
                            holidayToDeleteFound = true;

                            break;
                        }

                        if (!holidayToDeleteFound) continue;

                        holidayScheduleIndex = index;
                        break;
                    }

                    if (holidayScheduleIndex != -1)
                    {
                        holidaySchedules[holidayScheduleIndex].Holidays.Remove(holidayToDelete);
                    }

                    // Syncs only that holiday schedule whose holiday is deleted.
                    List<HolidaySchedule> updatedHolidaySchedules = new List<HolidaySchedule>();
                    updatedHolidaySchedules.Add(holidaySchedules[holidayScheduleIndex]);
                    holidayManager.Synchronize(updatedHolidaySchedules);
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
                object schedule;
                object hours;
                object title;
                object date;

                GetFieldValues(properties, out schedule, out hours, out title, out date);

                SPWeb spWeb = properties.Web;

                using (var holidayManager = new HolidayManager(spWeb))
                {
                    IEnumerable<SPList> spLists = spWeb.GetListByTemplateId((int)EPMLiveLists.HolidaySchedules);
                    if (spLists == null) throw new Exception("Cannot find the Holiday Schedules list.");

                    List<HolidaySchedule> holidaySchedules =
                        holidayManager.GetExistingHolidaySchedules(spLists.First().Items);

                    bool updatedHolidayFound = false;

                    Holiday updatedHoliday = null;
                    int updatedHolidayScheduleIndex = -1;
                    var spFieldLookupValue = new SPFieldLookupValue((string)schedule);
                    List<HolidaySchedule> updatedHolidaySchedules = new List<HolidaySchedule>();

                    // Get current holiday schedule
                    HolidaySchedule currentHolidaySchedule = holidaySchedules.Where(hs => hs.Id == spFieldLookupValue.LookupId).First();

                    for (int index = 0; index < holidaySchedules.Count; index++)
                    {
                        HolidaySchedule holidaySchedule = holidaySchedules[index];

                        foreach (Holiday holiday in holidaySchedule.Holidays
                            .Where(holiday => holiday.Id == properties.ListItem.ID))
                        {
                            int currentHolidayYear = Convert.ToDateTime(date).Year;
                            #region Check for duplicate holiday
                            bool duplicateHoliday = false;
                            // In case holiday schedule is changed
                            if (holidaySchedule.Id != currentHolidaySchedule.Id)
                            {
                                foreach (Holiday newHoliday in currentHolidaySchedule.Holidays.Where(newHoliday => newHoliday.Title.Equals((string)title, StringComparison.InvariantCultureIgnoreCase)
                                    && Convert.ToDateTime(newHoliday.Date).Year.Equals(currentHolidayYear)))
                                {
                                    duplicateHoliday = true;
                                    break;
                                }
                            }
                            // In case of same holiday schedule
                            else
                            {
                                foreach (Holiday newHoliday in holidaySchedule.Holidays.Where(newHoliday => newHoliday.Title.Equals((string)title, StringComparison.InvariantCultureIgnoreCase)
                                    && Convert.ToDateTime(newHoliday.Date).Year.Equals(currentHolidayYear)))
                                {
                                    duplicateHoliday = true;
                                    break;
                                }
                            }
                            if (duplicateHoliday)
                            {
                                throw new Exception(string.Format("Holiday with title '{0}' already exists in holiday schedule '{1}' for year '{2}'", title, currentHolidaySchedule.Title, currentHolidayYear));
                            }
                            #endregion

                            holiday.Title = (string)title;
                            holiday.Date = (string)date;
                            holiday.Hours = (double)hours;

                            updatedHoliday = holiday;
                            updatedHolidayFound = true;

                            break;
                        }

                        if (!updatedHolidayFound) continue;

                        updatedHolidayScheduleIndex = index;
                        break;
                    }

                    if (updatedHolidayScheduleIndex != -1)
                    {
                        holidaySchedules[updatedHolidayScheduleIndex].Holidays.Remove(updatedHoliday);
                        // Populates only that holiday schedule whose holiday list is just got updated.
                        updatedHolidaySchedules.Add(holidaySchedules[updatedHolidayScheduleIndex]);
                    }

                    foreach (HolidaySchedule holidaySchedule in holidaySchedules
                        .Where(holidaySchedule => holidaySchedule.Id == spFieldLookupValue.LookupId))
                    {
                        holidaySchedule.Holidays.Add(updatedHoliday);
                        // Populates only that holiday schedule whose holiday list is just got updated.
                        updatedHolidaySchedules.Add(holidaySchedule);
                        break;
                    }

                    // Syncs only that holiday schedule whose holiday is just modified.
                    holidayManager.Synchronize(updatedHolidaySchedules);
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

        // Private Methods (2) 

        /// <summary>
        ///     Gets the field values.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="schedule">The schedule.</param>
        /// <param name="hours">The hours.</param>
        /// <param name="title">The title.</param>
        /// <param name="date">The date.</param>
        private void GetFieldValues(SPItemEventProperties properties, out object schedule, out object hours,
            out object title, out object date)
        {
            title = properties.AfterProperties["Title"] ?? properties.ListItem["Title"];
            date = properties.AfterProperties["Date"] ?? properties.ListItem["Date"];
            hours = properties.AfterProperties["Hours"] ?? properties.ListItem["Hours"];
            schedule = properties.AfterProperties["HolidaySchedule"] ?? properties.ListItem["HolidaySchedule"];

            if (title == null) throw new Exception("Title cannot be empty.");
            if (date == null) throw new Exception("Date cannot be empty.");
            if (hours == null) throw new Exception("Hours cannot be empty.");
            if (schedule == null) throw new Exception("Please select a holiday schedule.");

            hours = double.Parse(hours.ToString());
            date = (date is string ? (string)date : ((DateTime)date).ToString("s")).Split('T')[0];
        }

        /// <summary>
        ///     Validates the request.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private bool ValidateRequest(SPItemEventProperties properties)
        {
            return properties.OpenSite().Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null &&
                   properties.List.Title.Equals("Holidays");
        }

        #endregion Methods
    }
}