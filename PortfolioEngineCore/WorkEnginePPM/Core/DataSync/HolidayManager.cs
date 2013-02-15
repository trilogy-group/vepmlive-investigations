using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Core.DataSync
{
    public class HolidayManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="HolidayManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public HolidayManager(SPWeb spWeb)
            : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (4) 

        /// <summary>
        /// Adds the PFE holidays.
        /// </summary>
        /// <param name="properties">The properties.</param>
        public void AddPFEHolidays(SPItemEventProperties properties)
        {
            bool isHolidayEvent = properties.List.Title.Equals("Holidays");
            string holidayDate = string.Empty;

            if (isHolidayEvent)
            {
                try
                {
                    holidayDate = ((string) ((properties.AfterProperties["Date"] ?? properties.ListItem["Date"]))).Split('T')[0];
                }
                catch { }
            }

            SPList holidaySchedulesList = Web.Lists["Holiday Schedules"];
            SPList holidaysList = Web.Lists["Holidays"];

            List<HolidaySchedule> existingHolidaySchedules = GetExistingHolidaySchedules(holidaySchedulesList.Items);
            List<Holiday> existingHolidays =
                existingHolidaySchedules.SelectMany(existingHolidaySchedule => existingHolidaySchedule.Holidays).ToList();

            XDocument responseXml;

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                responseXml = XDocument.Parse(portfolioEngineAPI.Execute("GetHolidaySchedules", string.Empty));
            }

            var title = string.Empty;

            try
            {
                title = properties.ListItem.Title;
            }
            catch { }

            foreach (XElement hsElement in responseXml.Descendants("HolidaySchedule"))
            {
                string hsId = hsElement.Attribute("Id").Value;
                string hsTitle = hsElement.Attribute("Title").Value;

                HolidaySchedule holidaySchedule = (from hs in existingHolidaySchedules
                                                   where hs.Title.Equals(hsTitle) || hs.Title.Equals(title)
                                                   select hs).FirstOrDefault();

                if (holidaySchedule == null)
                {
                    var schedule = new HolidaySchedule
                                       {
                                           Title = hsTitle,
                                           ExtId = hsId,
                                           Holidays = new List<Holiday>()
                                       };

                    using (new DisabledItemEventScope())
                    {
                        SPListItem spListItem = holidaySchedulesList.AddItem();

                        spListItem["Title"] = schedule.Title;
                        spListItem["EXTID"] = schedule.ExtId;

                        spListItem.SystemUpdate();

                        schedule.Id = spListItem.ID;

                        foreach (XElement hElement in hsElement.Descendants("Holiday"))
                        {
                            var holiday = new Holiday
                                              {
                                                  Title = hElement.Attribute("Title").Value,
                                                  Date = hElement.Attribute("Date").Value,
                                                  Hours = Convert.ToDouble(hElement.Attribute("Hours").Value)
                                              };

                            try
                            {
                                if (holiday.Hours == 24) holiday.Hours = 8;
                            }
                            catch { }

                            SPListItem listItem = holidaysList.AddItem();

                            listItem["Title"] = holiday.Title;
                            listItem["Date"] = holiday.Date;
                            listItem["Hours"] = holiday.Hours;
                            listItem["HolidaySchedule"] = new SPFieldLookupValue(spListItem.ID, spListItem.Title);

                            listItem.SystemUpdate();

                            holiday.Id = listItem.ID;

                            schedule.Holidays.Add(holiday);
                            existingHolidays.Add(holiday);
                        }
                    }

                    existingHolidaySchedules.Add(schedule);
                    continue;
                }

                foreach (XElement hElement in from hElement in hsElement.Descendants("Holiday")
                                              let hldy = (from h in existingHolidays
                                                          let d1 = DateTime.Parse(h.Date)
                                                          let d2 = DateTime.Parse(hElement.Attribute("Date").Value)
                                                          where d1.Date == d2.Date
                                                          select h).FirstOrDefault()
                                              where hldy == null
                                              select hElement)
                {
                    string date = hElement.Attribute("Date").Value;

                    if (isHolidayEvent && holidayDate.Equals(date.Split('T')[0])) continue;

                    using (new DisabledItemEventScope())
                    {
                        var holiday = new Holiday
                                          {
                                              Title = hElement.Attribute("Title").Value,
                                              Date = date,
                                              Hours = Convert.ToDouble(hElement.Attribute("Hours").Value)
                                          };

                        try
                        {
                            if (holiday.Hours == 24) holiday.Hours = 8;
                        }
                        catch { }

                        SPListItem listItem = holidaysList.AddItem();

                        listItem["Title"] = holiday.Title;
                        listItem["Date"] = holiday.Date;
                        listItem["Hours"] = holiday.Hours;
                        listItem["HolidaySchedule"] = new SPFieldLookupValue((int) holidaySchedule.Id,
                                                                             holidaySchedule.Title);

                        listItem.SystemUpdate();

                        holiday.Id = listItem.ID;

                        holidaySchedule.Holidays.Add(holiday);
                        existingHolidays.Add(holiday);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the schedule.
        /// </summary>
        /// <param name="holidaySchedule">The holiday schedule.</param>
        /// <returns></returns>
        public bool DeleteSchedule(HolidaySchedule holidaySchedule)
        {
            var request = new XElement("DeleteHolidaySchedules", new XElement("Params"),
                                       new XElement("Data",
                                                    new XElement("HolidaySchedule",
                                                                 new XAttribute("Id", holidaySchedule.ExtId),
                                                                 new XAttribute("ExtId",
                                                                                (object) holidaySchedule.Id ??
                                                                                string.Empty),
                                                                 new XAttribute("DataId", holidaySchedule.UniqueId))));

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("DeleteHolidaySchedule", request.ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);
            }

            return true;
        }

        /// <summary>
        /// Gets the existing holiday schedules.
        /// </summary>
        /// <param name="spListItemCollection">The sp list item collection.</param>
        /// <returns></returns>
        public List<HolidaySchedule> GetExistingHolidaySchedules(SPListItemCollection spListItemCollection)
        {
            var holidaySchedules = new List<HolidaySchedule>();

            bool errors = false;
            var stringBuilder = new StringBuilder();

            var dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof (int));
            dataTable.Columns.Add("Title", typeof (string));
            dataTable.Columns.Add("Date", typeof (string));
            dataTable.Columns.Add("Hours", typeof (double));
            dataTable.Columns.Add("UniqueId", typeof (Guid));
            dataTable.Columns.Add("ScheduleId", typeof (int));

            SPList holidayList =
                spListItemCollection.List.ParentWeb.Lists.TryGetList("Holidays");
            if (holidayList == null) throw new Exception("Cannot find the Holidays list.");

            SPListItemCollection listItemCollection = holidayList.Items;

            foreach (SPListItem spListItem in listItemCollection)
            {
                dataTable.Rows.Add(spListItem.ID, spListItem["Title"],
                                   ((DateTime) spListItem["Date"]).ToString("yyyy-MM-dd"),
                                   spListItem["Hours"], spListItem.UniqueId,
                                   new SPFieldLookupValue((string) spListItem["HolidaySchedule"]).LookupId);
            }

            foreach (SPListItem spListItem in spListItemCollection)
            {
                var id = (int) spListItem["ID"];
                object title = spListItem["Title"];

                if (title == null)
                {
                    stringBuilder.AppendLine(string.Format("[{0}] Title cannot be empty.", id));
                    errors = true;
                }
                else
                {
                    List<Holiday> holidays = dataTable.Select(string.Format("ScheduleId = {0}", id))
                        .Select(dataRow => new Holiday
                                               {
                                                   Id = (int) dataRow["Id"],
                                                   Title = (string) dataRow["Title"],
                                                   Date = (string) dataRow["Date"],
                                                   Hours = (double) dataRow["Hours"],
                                                   UniqueId = (Guid) dataRow["UniqueId"]
                                               }).ToList();

                    holidaySchedules.Add(new HolidaySchedule
                                             {
                                                 Id = id,
                                                 Title = (string) title,
                                                 IsDefault = bool.Parse((spListItem["IsDefault"] ?? false).ToString()),
                                                 ExtId = (string) spListItem["EXTID"],
                                                 UniqueId = spListItem.UniqueId,
                                                 Holidays = holidays
                                             });
                }
            }

            if (errors) throw new Exception(stringBuilder.ToString());

            return holidaySchedules;
        }

        /// <summary>
        /// Synchronizes the specified holiday schedules.
        /// </summary>
        /// <param name="holidaySchedules">The holiday schedules.</param>
        /// <returns></returns>
        public List<HolidaySchedule> Synchronize(List<HolidaySchedule> holidaySchedules)
        {
            var dataElement = new XElement("Data");

            foreach (HolidaySchedule holidaySchedule in holidaySchedules)
            {
                var holidayScheduleElement = new XElement("HolidaySchedule",
                                                          new XAttribute("Id", holidaySchedule.ExtId ?? string.Empty),
                                                          new XAttribute("Title", holidaySchedule.Title),
                                                          new XAttribute("Default",
                                                                         holidaySchedule.IsDefault ? "1" : "0"),
                                                          new XAttribute("ExtId",
                                                                         (object) (holidaySchedule.Id) ?? string.Empty),
                                                          new XAttribute("DataId", holidaySchedule.UniqueId));

                foreach (Holiday holiday in holidaySchedule.Holidays)
                {
                    holidayScheduleElement.Add(new XElement("Holiday", new XAttribute("Date", holiday.Date),
                                                            new XAttribute("Title", holiday.Title),
                                                            new XAttribute("Hours", holiday.Hours)));
                }

                dataElement.Add(holidayScheduleElement);
            }

            var rootElement = new XElement("UpdateHolidaySchedule", new XElement("Params"), dataElement);

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("UpdateHolidaySchedules", rootElement.ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);

                foreach (HolidaySchedule holidaySchedule in holidaySchedules)
                {
                    HolidaySchedule schedule = holidaySchedule;

                    foreach (
                        XElement holidayScheduleElement in
                            from e in responseRootElement.Element("Data").Elements("HolidaySchedule")
                            where e.Attribute("DataId").Value.Equals(schedule.UniqueId.ToString())
                            select e)
                    {
                        XElement resElement = holidayScheduleElement.Element("Result");
                        if (resElement != null)
                        {
                            XAttribute statusEle = resElement.Attribute("Status");
                            if (statusEle != null && statusEle.Value.Equals("1"))
                            {
                                throw new Exception(resElement.Value);
                            }
                        }

                        holidaySchedule.ExtId = holidayScheduleElement.Attribute("Id").Value;
                    }
                }
            }

            return holidaySchedules;
        }

        #endregion Methods 
    }
}