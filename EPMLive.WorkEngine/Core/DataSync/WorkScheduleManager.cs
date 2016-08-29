using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Core.DataSync
{
    public class WorkScheduleManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkScheduleManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public WorkScheduleManager(SPWeb spWeb) : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (4) 

        /// <summary>
        /// Adds the PFE work schedules.
        /// </summary>
        /// <param name="currentSchedule">The current schedule.</param>
        public void AddPFEWorkSchedules(WorkSchedule currentSchedule)
        {
            SPList spList = Web.Lists["Work Hours"];
            List<WorkSchedule> existingWorkSchedules = GetExistingWorkSchedules(spList.Items);

            XDocument responseXml;
            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                responseXml = XDocument.Parse(portfolioEngineAPI.Execute("GetWorkSchedules", string.Empty));
            }

            foreach (var schedule in (from descendant in responseXml.Descendants("WorkSchedule")
                                      let workSchedule = (from w in existingWorkSchedules
                                                          where w.Title.Equals(descendant.Attribute("Title").Value)
                                                          select w).FirstOrDefault()
                                      where workSchedule == null
                                      select new WorkSchedule
                                                 {
                                                     ExtId = descendant.Attribute("Id").Value,
                                                     Title = descendant.Attribute("Title").Value,
                                                     Sunday = Convert.ToDecimal(descendant.Attribute("Sunday").Value)/100,
                                                     Monday = Convert.ToDecimal(descendant.Attribute("Monday").Value)/100,
                                                     Tuesday = Convert.ToDecimal(descendant.Attribute("Tuesday").Value)/100,
                                                     Wednesday = Convert.ToDecimal(descendant.Attribute("Wednesday").Value)/100,
                                                     Thursday = Convert.ToDecimal(descendant.Attribute("Thursday").Value)/100,
                                                     Friday = Convert.ToDecimal(descendant.Attribute("Friday").Value)/100,
                                                     Saturday = Convert.ToDecimal(descendant.Attribute("Saturday").Value)/100
                                                 }).Where(schedule => !schedule.Title.Equals(currentSchedule.Title)))
            {
                using (new DisabledItemEventScope())
                {
                    SPListItem spListItem = spList.AddItem();

                    spListItem["Title"] = schedule.Title;
                    spListItem["EXTID"] = schedule.ExtId;
                    spListItem["Sunday"] = schedule.Sunday;
                    spListItem["Monday"] = schedule.Monday;
                    spListItem["Tuesday"] = schedule.Tuesday;
                    spListItem["Wednesday"] = schedule.Wednesday;
                    spListItem["Thursday"] = schedule.Thursday;
                    spListItem["Friday"] = schedule.Friday;
                    spListItem["Saturday"] = schedule.Saturday;

                    spListItem.SystemUpdate();

                    schedule.Id = spListItem.ID;
                }

                existingWorkSchedules.Add(schedule);
            }
        }

        /// <summary>
        /// Deletes the specified work schedule.
        /// </summary>
        /// <param name="workSchedule">The work schedule.</param>
        /// <returns></returns>
        public bool Delete(WorkSchedule workSchedule)
        {
            var request = new XElement("DeleteWorkSchedule", new XElement("Params"),
                                       new XElement("Data",
                                                    new XElement("WorkSchedule",
                                                                 new XAttribute("Id", workSchedule.ExtId),
                                                                 new XAttribute("ExtId",
                                                                                (object) workSchedule.Id ?? string.Empty),
                                                                 new XAttribute("DataId", workSchedule.UniqueId))));

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("DeleteWorkSchedule", request.ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);
            }

            return true;
        }

        /// <summary>
        /// Gets the existing work schedules.
        /// </summary>
        /// <param name="spListItemCollection">The sp list item collection.</param>
        /// <returns></returns>
        public List<WorkSchedule> GetExistingWorkSchedules(SPListItemCollection spListItemCollection)
        {
            var workSchedules = new List<WorkSchedule>();

            bool errors = false;
            var stringBuilder = new StringBuilder();

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
                    workSchedules.Add(new WorkSchedule
                                          {
                                              Id = id,
                                              Title = (string) title,
                                              Sunday = decimal.Parse(spListItem["Sunday"].ToString()),
                                              Monday = decimal.Parse(spListItem["Monday"].ToString()),
                                              Tuesday = decimal.Parse(spListItem["Tuesday"].ToString()),
                                              Wednesday = decimal.Parse(spListItem["Wednesday"].ToString()),
                                              Thursday = decimal.Parse(spListItem["Thursday"].ToString()),
                                              Friday = decimal.Parse(spListItem["Friday"].ToString()),
                                              Saturday = decimal.Parse(spListItem["Saturday"].ToString()),
                                              IsDefault = bool.Parse((spListItem["IsDefault"] ?? false).ToString()),
                                              ExtId = (string) spListItem["EXTID"],
                                              UniqueId = spListItem.UniqueId
                                          });
                }
            }

            if (errors) throw new Exception(stringBuilder.ToString());

            return workSchedules;
        }

        /// <summary>
        /// Synchronizes the specified work schedules.
        /// </summary>
        /// <param name="workSchedules">The work schedules.</param>
        /// <returns></returns>
        public List<WorkSchedule> Synchronize(List<WorkSchedule> workSchedules)
        {
            var dataElement = new XElement("Data");

            foreach (WorkSchedule workSchedule in workSchedules)
            {
                dataElement.Add(new XElement("WorkSchedule", new XAttribute("Id", workSchedule.ExtId ?? string.Empty),
                                             new XAttribute("Title", workSchedule.Title),
                                             new XAttribute("Sunday", workSchedule.Sunday),
                                             new XAttribute("Monday", workSchedule.Monday),
                                             new XAttribute("Tuesday", workSchedule.Tuesday),
                                             new XAttribute("Wednesday", workSchedule.Wednesday),
                                             new XAttribute("Thursday", workSchedule.Thursday),
                                             new XAttribute("Friday", workSchedule.Friday),
                                             new XAttribute("Saturday", workSchedule.Saturday),
                                             new XAttribute("Default", workSchedule.IsDefault ? "1" : "0"),
                                             new XAttribute("ExtId", (object) workSchedule.Id ?? string.Empty),
                                             new XAttribute("DataId", workSchedule.UniqueId)));
            }

            var requestDocument = new XDocument();
            requestDocument.Add(new XElement("UpdateWorkSchedule", new XElement("Params"), dataElement));

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("UpdateWorkSchedule", requestDocument.ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);

                IEnumerable<XElement> itemsElement = responseRootElement.Element("Data").Elements("WorkSchedule");

                foreach (WorkSchedule workSchedule in workSchedules)
                {
                    XElement itemElement = (from e in itemsElement
                                            where e.Attribute("DataId").Value.Equals(workSchedule.UniqueId.ToString())
                                            select e).FirstOrDefault();

                    XElement resElement = itemElement.Element("Result");
                    if (resElement != null)
                    {
                        XAttribute statusEle = resElement.Attribute("Status");
                        if (statusEle != null && statusEle.Value.Equals("1"))
                        {
                            throw new Exception(resElement.Value);
                        }
                    }

                    workSchedule.ExtId = itemElement.Attribute("Id").Value;
                }
            }

            return workSchedules;
        }

        #endregion Methods 
    }
}