using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;

namespace WorkEnginePPM.Core.DataSync
{
    public class TimeOffManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="HolidayManager" /> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public TimeOffManager(SPWeb spWeb) : base(spWeb) { }

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (2) 

        /// <summary>
        ///     Deletes the specified role.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Delete(int id, int userId)
        {
            XElement resultElement = GetTimeOff(userId);

            XElement timeOffElement = (from e in resultElement.Descendants("TimeOff")
                where e.Attribute("Id").Value.Equals(id.ToString(CultureInfo.InvariantCulture))
                select e).FirstOrDefault();

            if (timeOffElement == null) return true;

            IEnumerable<XElement> itemsElement = timeOffElement.Descendants();
            XElement categoryElement = timeOffElement.Parent;
            XElement resourceElement = categoryElement.Parent;

            resourceElement.RemoveNodes();
            categoryElement.RemoveNodes();

            categoryElement.Add(itemsElement);
            resourceElement.Add(categoryElement);

            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                XDocument responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("DeleteResourceTimeoff",
                        new XElement("DeleteResourceTimeoff",
                            new XElement("Params"),
                            new XElement("Data", resourceElement)).
                            ToString()));

                XElement responseRootElement = responseDocument.Root;

                ValidateResponse(responseRootElement);
            }

            return true;
        }

        /// <summary>
        ///     Synchronizes the specified roles.
        /// </summary>
        /// <param name="userId"></param>
        public void Synchronize(int userId)
        {
            XElement resultElement = GetTimeOff(userId);

            foreach (XElement timeOffElement in resultElement.Descendants("TimeOff"))
            {
                timeOffElement.Parent.Add(timeOffElement.Descendants());
                timeOffElement.RemoveAll();
            }

            resultElement.Descendants("TimeOff").Remove();

            var requestElement = new XElement("UpdateResourceTimeOff", new XElement("Params"),
                new XElement("Data", resultElement.Descendants("Resource")));

            XDocument responseDocument;
            using (var portfolioEngineAPI = new PortfolioEngineAPI(Web))
            {
                responseDocument =
                    XDocument.Parse(portfolioEngineAPI.Execute("UpdateResourceTimeoff", requestElement.ToString()));
            }

            XElement responseRootElement = responseDocument.Root;

            ValidateResponse(responseRootElement);
        }

        // Private Methods (2) 

        /// <summary>
        ///     Gets the time off.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private XElement GetTimeOff(int userId)
        {
            XDocument requestDocument =
                XDocument.Parse(
                    (new XElement("GetResourceTimeOff",
                        new XElement("Params", new XElement("Resources", userId)),
                        new XElement("Data"))).ToString());

            XDocument responseDocument =
                XDocument.Parse(WorkEngineAPI.GetResourceTimeOff(requestDocument.ToString(), Web));

            XElement resultElement = responseDocument.Root;

            ValidateGetTimeOffResponse(resultElement);

            foreach (XElement xElement in resultElement.Descendants("Resource"))
            {
                FixIds(xElement);
            }

            foreach (XElement xElement in resultElement.Descendants("Category"))
            {
                FixIds(xElement);
            }

            return resultElement;
        }

        private static void FixIds(XElement xElement)
        {
            string id = xElement.Attribute("Id").Value;
            string extId = xElement.Attribute("ExtId").Value;

            xElement.Attribute("Id").SetValue(extId);
            xElement.Attribute("ExtId").SetValue(id);
        }

        /// <summary>
        ///     Validates the get time off response.
        /// </summary>
        /// <param name="resultElement">The result element.</param>
        private void ValidateGetTimeOffResponse(XElement resultElement)
        {
            try
            {
                foreach (XElement element in resultElement.Element("GetResourceTimeOff").Elements("Resource")
                    .Select(xElement => xElement.Element("Result"))
                    .Where(element => element.Attribute("Status").Value.Equals("1")))
                {
                    throw new Exception(element.Value);
                }
            }
            catch { }
        }

        #endregion Methods 
    }
}