using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public class SPListItemManager : ISPListItemManager
    {
        #region Fields (3) 

        private readonly string _elementName;
        private readonly string _rootElementName;
        private int _batchProcessLimit;

        #endregion Fields 

        #region Constructors (3) 

        /// <summary>
        /// Initializes a new instance of the <see cref="SPListItemManager"/> class.
        /// </summary>
        /// <param name="listName">Name of the list.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="siteId">The site id.</param>
        /// <param name="rootElementName">Name of the root element.</param>
        /// <param name="elementName">Name of the element.</param>
        public SPListItemManager(string listName, Guid webId, Guid siteId, string rootElementName,
                                 string elementName)
        {
            try
            {
                using (var spSite = new SPSite(siteId))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                    {
                        SPList spList = spWeb.Lists.TryGetList(listName);

                        if (spList == null)
                        {
                            throw new APIException((int) Errors.SPLIMListNotFound,
                                                   string.Format(@"Cannot find the ""{0}"" list at {1}", listName,
                                                                 spWeb.Url));
                        }

                        ParentList = spList;

                        _rootElementName = rootElementName;
                        _elementName = elementName;
                        _batchProcessLimit = 100;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.SPLIM, exception.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SPListItemManager"/> class.
        /// </summary>
        /// <param name="listName">Name of the list.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="siteId">The site id.</param>
        public SPListItemManager(string listName, Guid webId, Guid siteId)
            : this(listName, webId, siteId, "Items", "Item")
        {
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="SPListItemManager"/> is reclaimed by garbage collection.
        /// </summary>
        ~SPListItemManager()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Properties (2) 

        /// <summary>
        /// Gets or sets the batch process limit.
        /// </summary>
        /// <value>
        /// The batch process limit.
        /// </value>
        public int BatchProcessLimit
        {
            get { return _batchProcessLimit; }
            set
            {
                if (value < 2)
                {
                    throw new APIException((int) Errors.SPLIMBatchProcessLimit,
                                           "The BatchProcessLimit cannot be less that 2");
                }

                _batchProcessLimit = value;
            }
        }

        /// <summary>
        /// Gets the parent list.
        /// </summary>
        public SPList ParentList { get; private set; }

        #endregion Properties 

        #region Methods (13) 

        // Public Methods (9) 

        /// <summary>
        /// Adds the specified serialized list items.
        /// </summary>
        /// <param name="serializedListItems">The serialized list items.</param>
        /// <returns></returns>
        public virtual XDocument Add(XDocument serializedListItems)
        {
            try
            {
                return PerformBatchListOperation(serializedListItems, "Save", true);
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.SPLIMAdd, exception.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Deletes the specified serialized list items.
        /// </summary>
        /// <param name="serializedListItems">The serialized list items.</param>
        /// <returns></returns>
        public virtual XDocument Delete(XDocument serializedListItems)
        {
            try
            {
                return PerformBatchListOperation(serializedListItems, "Delete");
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.SPLIMDelete, exception.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual XDocument GetAll()
        {
            return GetAll(false, false);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="includeHidden">if set to <c>true</c> [include hidden].</param>
        /// <returns></returns>
        public virtual XDocument GetAll(bool includeHidden)
        {
            return GetAll(includeHidden, false);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="includeHidden">if set to <c>true</c> [include hidden].</param>
        /// <param name="includeReadOnly">if set to <c>true</c> [include read only].</param>
        /// <returns></returns>
        public virtual XDocument GetAll(bool includeHidden, bool includeReadOnly)
        {
            try
            {
                SPListItemCollection spListItemCollection = ParentList.Items;
                SPFieldCollection spFieldCollection = ParentList.Fields;

                var rootElement = new XElement(_rootElementName);

                foreach (SPListItem spListItem in spListItemCollection)
                {
                    var itemElement = new XElement(_elementName);
                    itemElement.Add(new XAttribute("ID", spListItem["ID"]));

                    foreach (SPField spField in spFieldCollection)
                    {
                        string internalName = spField.InternalName;

                        bool isHidden = spField.Hidden;
                        bool isReadOnly = spField.ReadOnlyField;

                        if (!internalName.Equals("EXTID"))
                        {
                            if (isHidden && !includeHidden)
                            {
                                continue;
                            }

                            if (isReadOnly && !includeReadOnly)
                            {
                                continue;
                            }
                        }

                        object value;

                        try
                        {
                            value = spListItem[internalName] ?? string.Empty;
                        }
                        catch (Exception)
                        {
                            value = string.Empty;
                        }

                        string stringValue = value.ToString().Trim();

                        string fieldEditValue;
                        string fieldTextValue;
                        string fieldHtmlValue;
                        GetFieldSpecialValues(spField, stringValue, value, out fieldEditValue, out fieldTextValue,
                                              out fieldHtmlValue);

                        var dataElement = new XElement("Data", new XCData(stringValue));

                        dataElement.Add(new XAttribute("Field", internalName));
                        dataElement.Add(new XAttribute("Type", spField.Type));
                        dataElement.Add(new XAttribute("Format", Utils.GetFormat(spField)));
                        dataElement.Add(new XAttribute("Hidden", isHidden));
                        dataElement.Add(new XAttribute("ReadOnly", isReadOnly));
                        dataElement.Add(new XAttribute("TextValue", fieldTextValue));
                        dataElement.Add(new XAttribute("HtmlValue", fieldHtmlValue));
                        dataElement.Add(new XAttribute("EditValue", fieldEditValue));

                        itemElement.Add(dataElement);
                    }

                    rootElement.Add(itemElement);
                }

                var serializedListItems = new XDocument();
                serializedListItems.Add(rootElement);

                return serializedListItems;
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.SPLIMGetAll, exception.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Items the exists.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual bool ItemExists(int id)
        {
            SPListItem spListItem = ParentList.GetItemByIdSelectedFields(id, "ID");

            return spListItem != null;
        }

        /// <summary>
        /// Updates the specified serialized list items.
        /// </summary>
        /// <param name="serializedListItems">The serialized list items.</param>
        public virtual XDocument Update(XDocument serializedListItems)
        {
            try
            {
                return PerformBatchListOperation(serializedListItems, "Update");
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.SPLIMUpdate, exception.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual void Delete(int id)
        {
            SPListItem spListItem = ParentList.GetItemById(id);

            ParentList.ParentWeb.AllowUnsafeUpdates = true;

            spListItem.Delete();
            ParentList.Update();

            ParentList.ParentWeb.AllowUnsafeUpdates = false;
        }

        // Protected Methods (1) 

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(Boolean disposing)
        {
            if (!disposing) return;

            if (ParentList == null) return;

            ParentList = null;
        }

        // Private Methods (3) 

        /// <summary>
        /// Gets the field special values.
        /// </summary>
        /// <param name="spField">The sp field.</param>
        /// <param name="stringValue">The string value.</param>
        /// <param name="value">The value.</param>
        /// <param name="fieldEditValue">The field edit value.</param>
        /// <param name="fieldTextValue">The field text value.</param>
        /// <param name="fieldHtmlValue">The field HTML value.</param>
        private void GetFieldSpecialValues(SPField spField, string stringValue, object value,
                                           out string fieldEditValue,
                                           out string fieldTextValue, out string fieldHtmlValue)
        {
            if (spField.Type != SPFieldType.DateTime)
            {
                fieldTextValue = string.IsNullOrEmpty(stringValue)
                                     ? string.Empty
                                     : spField.GetFieldValueAsText(value) ?? string.Empty;

                fieldHtmlValue = string.IsNullOrEmpty(stringValue)
                                     ? string.Empty
                                     : spField.GetFieldValueAsHtml(value) ?? string.Empty;

                fieldEditValue = string.IsNullOrEmpty(stringValue)
                                     ? string.Empty
                                     : spField.GetFieldValueForEdit(value) ?? string.Empty;
            }
            else
            {
                string specialValue = string.IsNullOrEmpty(stringValue)
                                          ? string.Empty
                                          : ((DateTime) value).ToShortDateString();

                fieldTextValue = specialValue;
                fieldHtmlValue = specialValue;
                fieldEditValue = specialValue;
            }
        }

        /// <summary>
        /// Performs the batch list operation.
        /// </summary>
        /// <param name="serializedListItems">The serialized list items.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        private XDocument PerformBatchListOperation(XDocument serializedListItems, string command)
        {
            return PerformBatchListOperation(serializedListItems, command, false);
        }

        /// <summary>
        /// Performs the batch list operation.
        /// </summary>
        /// <param name="serializedListItems">The serialized list items.</param>
        /// <param name="command">The command.</param>
        /// <param name="createNew">if set to <c>true</c> [create new].</param>
        /// <returns></returns>
        private XDocument PerformBatchListOperation(XDocument serializedListItems, string command, bool createNew)
        {
            try
            {
                SPWeb parentWeb = ParentList.ParentWeb;

                using (var spSite = new SPSite(parentWeb.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(parentWeb.ID))
                    {
                        spWeb.AllowUnsafeUpdates = true;

                        XElement rootElement = serializedListItems.Element(_rootElementName);

                        if (rootElement == null)
                        {
                            throw new APIException((int) Errors.SPLIMBatchOpRootEleNotFound,
                                                   string.Format(@"Cannot find the ""{0}"" element.", _rootElementName));
                        }

                        IEnumerable<XElement> itemElements = rootElement.Elements(_elementName);

                        var batchBuilder = new StringBuilder();
                        var batchResultBuilder = new StringBuilder();

                        batchBuilder.Append(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
                        batchBuilder.Append(@"<ows:Batch OnError=""Continue""></ows:Batch>");

                        Guid listId = ParentList.ID;
                        int methodCounter = 0;

                        foreach (XElement itemElement in itemElements)
                        {
                            string itemId = "New";

                            if (!createNew)
                            {
                                XAttribute idAttribute = itemElement.Attribute("ID");

                                if (idAttribute == null)
                                {
                                    throw new APIException((int) Errors.SPLIMBatchOpIdNotFound,
                                                           string.Format(
                                                               @"ID is not specified for the item at index {0}",
                                                               methodCounter));
                                }

                                itemId = idAttribute.Value;
                            }

                            batchBuilder.Append(string.Format(@"<Method ID=""{0}"">", ++methodCounter));

                            batchBuilder.Append(string.Format(@"<SetList>{0}</SetList>", listId));
                            batchBuilder.Append(string.Format(@"<SetVar Name=""Cmd"">{0}</SetVar>", command));
                            batchBuilder.Append(string.Format(@"<SetVar Name=""ID"">{0}</SetVar>", itemId));

                            foreach (XElement dataElement in itemElement.Elements("Data"))
                            {
                                XAttribute fieldAttribute = dataElement.Attribute("Field");
                                if (fieldAttribute == null)
                                {
                                    throw new APIException((int) Errors.SPLIMBatchOpFieldAttrNotFound,
                                                           string.Format(
                                                               @"The Field attribute is not specified for the item with ID {0}",
                                                               itemId));
                                }

                                string field = fieldAttribute.Value;
                                if (field.Equals("ID")) continue;

                                batchBuilder.Append(
                                    string.Format(
                                        @"<SetVar Name=""urn:schemas-microsoft-com:office:office#{0}"">{1}</SetVar>",
                                        field, dataElement.Value));
                            }

                            batchBuilder.Append("</Method>");

                            if (methodCounter%_batchProcessLimit != 0) continue;

                            batchBuilder.Append("</ows:Batch>");
                            batchResultBuilder.Append(spWeb.ProcessBatchData(batchBuilder.ToString()));

                            batchBuilder = new StringBuilder();
                            batchBuilder.Append(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
                            batchBuilder.Append(@"<ows:Batch OnError=""Continue""></ows:Batch>");
                        }

                        batchBuilder.Append("</ows:Batch>");
                        batchResultBuilder.Append(spWeb.ProcessBatchData(batchBuilder.ToString()));

                        spWeb.AllowUnsafeUpdates = false;

                        return
                            XDocument.Parse(string.Format(@"<BatchProcessResult>{0}</BatchProcessResult>",
                                                          batchResultBuilder));
                    }
                }
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.SPLIMBatchOp, exception.GetBaseException().Message);
            }
        }

        #endregion Methods 
    }
}