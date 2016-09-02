using System;
using System.Xml.Linq;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.TagManager
{
    public class TagManager
    {
        #region Fields (3) 

        private readonly SPWeb _spWeb;
        private readonly TagOrderRepository _tagOrderRepository;
        private readonly TagRepository _tagRepository;

        #endregion Fields 

        #region Enums (1) 

        private enum Errors
        {
            GetTag = 19000,
            RegisterTag,
            AddTagOrder,
            RemoveTagOrder
        }

        #endregion Enums 

        #region Constructors (1) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="TagManager" /> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public TagManager(SPWeb spWeb)
        {
            _spWeb = spWeb;
            _tagRepository = new TagRepository(_spWeb);
            _tagOrderRepository = new TagOrderRepository(_spWeb);
        }

        #endregion Constructors 

        #region Methods (7) 

        // Private Methods (3) 

        /// <summary>
        ///     Parses the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="tagId">The tag id.</param>
        private static void ParseData(string data, out string listId, out string itemId, out string tagId)
        {
            XDocument requestXml = XDocument.Parse(data);

            XElement rootElement = requestXml.Root;

            if (rootElement == null)
            {
                throw new Exception("The root 'TagOrder' element is missing.");
            }

            XAttribute tagAttribute = rootElement.Attribute("TagId");

            if (tagAttribute == null)
            {
                throw new Exception("'TagId' attribute is missing.");
            }

            tagId = tagAttribute.Value;

            XAttribute listIdAttribute = rootElement.Attribute("ListId");

            if (listIdAttribute == null)
            {
                throw new Exception("'ListId' attribute is missing.");
            }

            listId = listIdAttribute.Value;

            XAttribute itemIdAttribute = rootElement.Attribute("ItemId");

            if (itemIdAttribute == null)
            {
                throw new Exception("'ItemId' attribute is missing.");
            }

            itemId = itemIdAttribute.Value;
        }

        /// <summary>
        ///     Parses the request.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="resourceId">The resource id.</param>
        /// <param name="tagType">Type of the tag.</param>
        private XDocument ParseRequest(string data, out int resourceId, out int tagType)
        {
            XDocument requestXml = XDocument.Parse(data);

            XElement rootElement = requestXml.Root;

            if (rootElement == null)
            {
                throw new Exception("The root 'Tag' element is missing.");
            }

            XAttribute typeAttribute = rootElement.Attribute("Type");
            if (typeAttribute == null)
            {
                throw new Exception("Tag type is missing.");
            }

            string type = typeAttribute.Value;

            if (!int.TryParse(type, out tagType))
            {
                throw new Exception(type + " is not a valid Tag type.");
            }

            resourceId = -99;

            XAttribute resourceIdAttribute = rootElement.Attribute("ResourceId");
            if (resourceIdAttribute != null)
            {
                if (!int.TryParse(resourceIdAttribute.Value, out resourceId))
                {
                    throw new Exception("Invalid resource id.");
                }
            }

            if (resourceId == -99)
            {
                resourceId = _spWeb.CurrentUser.ID;
            }

            return requestXml;
        }

        /// <summary>
        ///     Parses the request.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="name">The name.</param>
        /// <param name="tagType">Type of the tag.</param>
        /// <param name="resourceId">The resource id.</param>
        private void ParseRequest(string data, out string name, out int tagType, out int resourceId)
        {
            XDocument request = ParseRequest(data, out resourceId, out tagType);

            name = string.Empty;
            string tagName = request.Root.Attribute("Name").Value;
            if (!string.IsNullOrEmpty(tagName))
            {
                name = tagName.Trim();
            }
        }

        // Internal Methods (4) 

        /// <summary>
        ///     Adds the tag order.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string AddTagOrder(string data)
        {
            try
            {
                string listId;
                string itemId;
                string tagId;

                ParseData(data, out listId, out itemId, out tagId);

                TagOrder tagOrder = _tagOrderRepository.Add(new TagOrder
                                                                {
                                                                    TagId = new Guid(tagId),
                                                                    ListId = new Guid(listId),
                                                                    ItemId = int.Parse(itemId)
                                                                });
                return
                    new XElement("TagOrder", new XAttribute("Id", tagOrder.Id), new XAttribute("Order", tagOrder.Order))
                        .ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.AddTagOrder, e.Message);
            }
        }

        /// <summary>
        ///     Gets the tag.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string GetTag(string data)
        {
            try
            {
                int resourceId;
                int tagType;

                ParseRequest(data, out resourceId, out tagType);

                Tag tag = _tagRepository.Find(tagType, resourceId, _spWeb.Site.ID);

                if (tag.Id == Guid.Empty) return string.Empty;

                return
                    new XElement("Tag", new XAttribute("Id", tag.Id), new XAttribute("Name", tag.Name ?? string.Empty),
                                 new XAttribute("Type", tag.Type), new XAttribute("ResourceId", tag.ResourceId),
                                 new XAttribute("SiteId", tag.SiteId)).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetTag, e.Message);
            }
        }

        /// <summary>
        ///     Registers the tag.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string RegisterTag(string data)
        {
            try
            {
                string name;
                int tagType;
                int resourceId;

                ParseRequest(data, out name, out tagType, out resourceId);

                return
                    new XElement("Tag",
                                 new XAttribute("Id",
                                                _tagRepository.Add(new Tag
                                                                       {
                                                                           Name = name,
                                                                           Type = tagType,
                                                                           ResourceId = resourceId,
                                                                           SiteId = _spWeb.Site.ID
                                                                       }))).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.RegisterTag, e.Message);
            }
        }

        /// <summary>
        ///     Removes the tag order.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string RemoveTagOrder(string data)
        {
            try
            {
                string listId;
                string itemId;
                string tagId;

                ParseData(data, out listId, out itemId, out tagId);

                _tagOrderRepository.Remove(new TagOrder
                                               {
                                                   TagId = new Guid(tagId),
                                                   ListId = new Guid(listId),
                                                   ItemId = int.Parse(itemId)
                                               });

                return new XElement("TagOrder").ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.RemoveTagOrder, e.Message);
            }
        }

        #endregion Methods 
    }
}