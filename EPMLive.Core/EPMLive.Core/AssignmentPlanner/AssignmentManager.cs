using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.AssignmentPlanner
{
    public class AssignmentManager
    {
        #region Fields (1) 

        private readonly SPWeb _spWeb;

        #endregion Fields 

        #region Enums (1) 

        private enum Errors
        {
            Publish = 18200,
            CantFindRootElement,
            CantFindDataElement,
            CantFindItemsElement,
            CantFindSiteIdAttr,
            CantFindWebIdAttr,
            CantFindListIdAttr,
            CantFindItemIdAttr
        }

        #endregion Enums 

        #region Constructors (1) 

        public AssignmentManager(SPWeb spWeb)
        {
            _spWeb = spWeb;
        }

        #endregion Constructors 

        #region Methods (2) 

        // Public Methods (1) 

        public string Publish(string data)
        {
            try
            {
                var errors = new StringBuilder();

                EnumerableRowCollection<DataRow> updatedItems = GetUpdatedItems(data).AsEnumerable();

                foreach (Guid spSiteId in (updatedItems.Select(i => i["SiteId"])).Distinct())
                {
                    Guid siteId = spSiteId;

                    using (var spSite = new SPSite(siteId))
                    {
                        foreach (
                            Guid spWebId in
                                (updatedItems.Where(i => (Guid) i["SiteId"] == siteId).Select(i => i["WebId"])).Distinct
                                    ())
                        {
                            Guid webId = spWebId;

                            using (SPWeb spWeb = spSite.OpenWeb(webId))
                            {
                                spWeb.AllowUnsafeUpdates = true;

                                foreach (
                                    Guid spListId in
                                        (from i in updatedItems where (Guid) i["WebId"] == webId select i["ListId"]).
                                            Distinct())
                                {
                                    Guid listId = spListId;

                                    SPList spList = spWeb.Lists.GetList(listId, false);

                                    foreach (var listItem in
                                        updatedItems.Where(i => (Guid) i["ListId"] == listId).Select(
                                            i =>
                                            new
                                                {
                                                    Id = (int) i["ItemId"],
                                                    StartDate = i["StartDate"],
                                                    DueDate = i["DueDate"]
                                                }))
                                    {
                                        bool updated = false;
                                        SPListItem spListItem = null;

                                        if (listItem.StartDate != DBNull.Value)
                                        {
                                            spListItem = spList.GetItemById(listItem.Id);
                                            spListItem["StartDate"] = listItem.StartDate;

                                            updated = true;
                                        }

                                        if (listItem.DueDate != DBNull.Value)
                                        {

                                            if (spListItem == null) spListItem = spList.GetItemById(listItem.Id);

                                            spListItem["DueDate"] = listItem.DueDate;

                                            updated = true;
                                        }

                                        try
                                        {
                                            if (updated) spListItem.Update();
                                        }
                                        catch (Exception exception)
                                        {
                                            errors.AppendLine(
                                                string.Format(
                                                    @"Site ID: {0}. Web ID: {1}. List ID: {2}. Item ID: {3}. Error: {4}",
                                                    siteId, webId, listId, listItem.Id,
                                                    exception.GetBaseException().Message));
                                        }
                                    }
                                }

                                spWeb.AllowUnsafeUpdates = false;
                            }
                        }
                    }
                }

                string errorMessage = errors.ToString();
                if (!string.IsNullOrEmpty(errorMessage)) throw new Exception(errorMessage);

                return string.Empty;
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.Publish, e.Message);
            }
        }

        // Private Methods (1) 

        /// <summary>
        /// Gets the updated items.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static DataTable GetUpdatedItems(string data)
        {
            var updatedItems = new DataTable();

            updatedItems.Columns.Add("SiteId", typeof (Guid));
            updatedItems.Columns.Add("WebId", typeof (Guid));
            updatedItems.Columns.Add("ListId", typeof (Guid));
            updatedItems.Columns.Add("ItemId", typeof (int));
            updatedItems.Columns.Add("StartDate");
            updatedItems.Columns.Add("DueDate");

            XDocument dataXml = XDocument.Parse(data);

            if (dataXml.Root == null)
            {
                throw new APIException((int) Errors.CantFindRootElement,
                                       "Cannot find the root Publish element.");
            }

            XElement dataElement = dataXml.Root.Element("Data");

            if (dataElement == null)
            {
                throw new APIException((int) Errors.CantFindDataElement,
                                       "Cannot find the Publish/Data element.");
            }
            XElement itemsElement = dataElement.Element("Items");

            if (itemsElement == null)
            {
                throw new APIException((int) Errors.CantFindItemsElement,
                                       "Cannot find the Publish/Data/Items element.");
            }

            foreach (XElement itemElement in itemsElement.Elements("Item"))
            {
                DataRow dataRow = updatedItems.NewRow();

                XAttribute siteIdAttribute = itemElement.Attribute("SiteId");
                if (siteIdAttribute == null)
                {
                    throw new APIException((int) Errors.CantFindSiteIdAttr,
                                           "Cannot find the SiteId attribute in Publish/Data/Items/Item.");
                }

                XAttribute webIdAttribute = itemElement.Attribute("WebId");
                if (webIdAttribute == null)
                {
                    throw new APIException((int) Errors.CantFindWebIdAttr,
                                           "Cannot find the WebId attribute in Publish/Data/Items/Item.");
                }

                XAttribute listIdAttribute = itemElement.Attribute("ListId");
                if (listIdAttribute == null)
                {
                    throw new APIException((int) Errors.CantFindListIdAttr,
                                           "Cannot find the ListId attribute in Publish/Data/Items/Item.");
                }

                XAttribute itemIdAttribute = itemElement.Attribute("ItemId");
                if (itemIdAttribute == null)
                {
                    throw new APIException((int) Errors.CantFindItemIdAttr,
                                           "Cannot find the ItemId attribute in Publish/Data/Items/Item.");
                }

                try
                {
                    dataRow["SiteId"] = new Guid(siteIdAttribute.Value);
                    dataRow["WebId"] = new Guid(webIdAttribute.Value);
                    dataRow["ListId"] = new Guid(listIdAttribute.Value);
                    dataRow["ItemId"] = int.Parse(itemIdAttribute.Value);

                    XAttribute startDateAttribute = itemElement.Attribute("StartDate");

                    if (startDateAttribute != null)
                    {
                        dataRow["StartDate"] = DateTime.Parse(startDateAttribute.Value);
                    }

                    XAttribute dueDateAttribute = itemElement.Attribute("DueDate");

                    if (dueDateAttribute != null)
                    {
                        dataRow["DueDate"] = DateTime.Parse(dueDateAttribute.Value);
                    }

                    updatedItems.Rows.Add(dataRow);
                }
                catch (Exception) { }
            }

            return updatedItems;
        }

        #endregion Methods 
    }
}