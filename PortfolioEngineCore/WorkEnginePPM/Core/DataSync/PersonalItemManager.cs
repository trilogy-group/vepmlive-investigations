using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Core.DataSync
{
    public class PersonalItemManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="HolidayManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public PersonalItemManager(SPWeb spWeb) : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (4) 

        /// <summary>
        /// Adds the PFE personal items.
        /// </summary>
        /// <param name="currentPersonalItem">The current personal item.</param>
        public void AddPFEPersonalItems(PersonalItem currentPersonalItem)
        {
            SPList spList = Web.Lists["Non Work"];
            List<PersonalItem> existingPersonalItems = GetExistingPersonalItems(spList.Items);

            XDocument responseXml;
            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                responseXml = XDocument.Parse(portfolioEngineAPI.Execute("GetPersonalItems", string.Empty));
            }

            foreach (XElement descendant in responseXml.Descendants("Item"))
            {
                string title = descendant.Attribute("Title").Value;
                string extId = descendant.Attribute("Id").Value;

                PersonalItem personalItem = (from pi in existingPersonalItems
                                             where pi.Title.Equals(title)
                                             select pi).FirstOrDefault();
                if (personalItem == null)
                {
                    using (new DisabledItemEventScope())
                    {
                        SPListItem spListItem = spList.AddItem();

                        spListItem["Title"] = title;
                        spListItem["EXTID"] = extId;

                        spListItem.SystemUpdate();
                    }

                    existingPersonalItems.Add(new PersonalItem {Title = title});
                }
                else
                {
                    using (new DisabledItemEventScope())
                    {
                        SPListItem spListItem = spList.GetItemById((int) personalItem.Id);

                        spListItem["EXTID"] = extId;

                        spListItem.SystemUpdate();

                        existingPersonalItems[existingPersonalItems.IndexOf(personalItem)].ExtId = extId;
                    } 
                }
            }
        }

        /// <summary>
        /// Deletes the specified role.
        /// </summary>
        /// <param name="personalItem">The personal item.</param>
        /// <returns></returns>
        public bool Delete(PersonalItem personalItem)
        {
            var request = new XElement("DeletePersonalItems", new XElement("Params"),
                                       new XElement("Data",
                                                    new XElement("Item", new XAttribute("Id", personalItem.ExtId),
                                                                 new XAttribute("ExtId",
                                                                                (object) personalItem.Id ?? string.Empty),
                                                                 new XAttribute("DataId", personalItem.UniqueId))));

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("DeletePersonalItems", request.ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);
            }

            return true;
        }

        /// <summary>
        /// Gets the existing personal items.
        /// </summary>
        /// <param name="spListItemCollection">The sp list item collection.</param>
        /// <returns></returns>
        public List<PersonalItem> GetExistingPersonalItems(SPListItemCollection spListItemCollection)
        {
            List<PersonalItem> personalItems = (from SPListItem spListItem in spListItemCollection
                                                select new PersonalItem
                                                           {
                                                               Id = spListItem.ID,
                                                               Title = (string) spListItem["Title"],
                                                               ExtId = (string) spListItem["EXTID"],
                                                               UniqueId = spListItem.UniqueId
                                                           }).ToList();
            return personalItems;
        }

        /// <summary>
        /// Synchronizes the specified roles.
        /// </summary>
        /// <param name="personalItems">The personal items.</param>
        /// <returns></returns>
        public List<PersonalItem> Synchronize(List<PersonalItem> personalItems)
        {
            var requestDocument = new XDocument();

            var dataElement = new XElement("Data");
            requestDocument.Add(new XElement("UpdatePersonalItems", new XElement("Params"), dataElement));

            foreach (PersonalItem personalItem in personalItems)
            {
                dataElement.Add(new XElement("Item", new XAttribute("Id", personalItem.ExtId ?? string.Empty),
                                             new XAttribute("Title", personalItem.Title),
                                             new XAttribute("ExtId", (object) personalItem.Id ?? string.Empty),
                                             new XAttribute("DataId", personalItem.UniqueId)));
            }

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("UpdatePersonalItems", requestDocument.ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);

                IEnumerable<XElement> itemsElement = responseRootElement.Element("Data").Elements("Item");

                foreach (PersonalItem personalItem in personalItems)
                {
                    XElement itemElement =
                        itemsElement.FirstOrDefault(
                            e => e.Attribute("DataId").Value.Equals(personalItem.UniqueId.ToString()));

                    XElement resElement = itemElement.Element("Result");
                    if (resElement != null)
                    {
                        XAttribute statusEle = resElement.Attribute("Status");
                        if (statusEle != null && statusEle.Value.Equals("1"))
                        {
                            throw new Exception(resElement.Value);
                        }
                    }

                    personalItem.ExtId = itemElement.Attribute("Id").Value;
                }
            }

            return personalItems;
        }

        #endregion Methods 
    }
}