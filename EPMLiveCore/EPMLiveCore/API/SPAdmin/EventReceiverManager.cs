using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EPMLiveCore.API.ResourceManagement;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.API.SPAdmin
{
    internal class EventReceiverManager : BaseManager
    {
        #region Enums (1) 

        internal enum Errors
        {
            Manage = 900100,
            ManageRootEleNotFound,
            ManageDataEleNotFound,
            ManageEventReceiverEleNotFound,
            ManageSiteIdAttrNotFound,
            ManageWebIdAttrNotFound,
            ManageListIdAttrNotFound,
            ManageTypeAttrNotFound,
            ManageOperationAttrNotFound,
            ManageInvalidOperation,
            ManageAssemblyAttrNotFound,
            ManageClassNameAttrNotFound,
            ManageAssemblyNotFound,
            ManageClassNotFound,
            ManageInvalidEvent,
            ManageNotAnEventReceiver,
            ManageWebNotFound
        }

        #endregion Enums 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public EventReceiverManager(SPWeb spWeb)
            : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (5) 

        // Public Methods (1) 

        /// <summary>
        /// Manages the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string Manage(string data)
        {
            try
            {
                var dataElement = new XElement("Data");

                DataTable dataTable = ParseRequestData(data);

                var siteWebListDict = new Dictionary<Guid, Dictionary<Guid, List<Guid>>>();

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var siteId = (Guid) dataRow["SiteId"];
                    var webId = (Guid) dataRow["WebId"];
                    var listId = (Guid) dataRow["ListId"];

                    if (!siteWebListDict.ContainsKey(siteId))
                    {
                        siteWebListDict.Add(siteId,
                                            new Dictionary<Guid, List<Guid>> {{webId, new List<Guid> {listId}}});
                    }
                    else
                    {
                        if (!siteWebListDict[siteId].ContainsKey(webId))
                        {
                            siteWebListDict[siteId].Add(webId, new List<Guid> {listId});
                        }
                        else
                        {
                            if (!siteWebListDict[siteId][webId].Contains(listId))
                                siteWebListDict[siteId][webId].Add(listId);
                        }
                    }
                }

                foreach (var siteInfo in siteWebListDict)
                {
                    using (var spSite = new SPSite(siteInfo.Key))
                    {
                        foreach (var webInfo in siteInfo.Value)
                        {
                            using (SPWeb spWeb = spSite.OpenWeb(webInfo.Key))
                            {
                                foreach (Guid listId in webInfo.Value)
                                {
                                    foreach (
                                        DataRow dataRow in dataTable.Select(string.Format("ListId = '{0}'", listId)))
                                    {
                                        object dataId = dataRow["DataId"];

                                        var resultElement = new XElement("Result", new XAttribute("Status", 0));

                                        var eventReceiverElement = new XElement("EventReceiver",
                                                                                new XAttribute("DataId", dataId));

                                        try
                                        {
                                            SPList spList = spWeb.Lists.GetList(listId, false);

                                            var assembly = (string) dataRow["Assembly"];
                                            var className = (string) dataRow["Class"];
                                            var spEventReceiverType = (SPEventReceiverType) dataRow["EventType"];

                                            switch ((string) dataRow["Operation"])
                                            {
                                                case "ADD":
                                                    AddEventReceiver(spList, assembly, className, spEventReceiverType,
                                                                     ref eventReceiverElement);
                                                    break;
                                                case "REMOVE":
                                                    RemoveEventReceiver(spList, assembly, className, spEventReceiverType,
                                                                        ref eventReceiverElement);
                                                    break;
                                                case "LIST":
                                                    ListEventReceivers(spList, ref eventReceiverElement);
                                                    break;
                                            }
                                        }
                                        catch (APIException apiException)
                                        {
                                            // ReSharper disable PossibleNullReferenceException

                                            resultElement.Attribute("Status").SetValue(1);
                                            resultElement.SetValue(string.Format("Error Id: {0}. Message: {1}",
                                                                                 apiException.ExceptionNumber,
                                                                                 apiException.Message));

                                            // ReSharper restore PossibleNullReferenceException
                                        }
                                        catch (Exception exception)
                                        {
                                            // ReSharper disable PossibleNullReferenceException

                                            resultElement.Attribute("Status").SetValue(1);
                                            resultElement.SetValue(exception.GetBaseException().Message);

                                            // ReSharper restore PossibleNullReferenceException
                                        }
                                        finally
                                        {
                                            eventReceiverElement.Add(resultElement);
                                            dataElement.Add(eventReceiverElement);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return new XElement("EventReceiverManager", dataElement).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.Manage, exception.GetBaseException().Message);
            }
        }

        // Private Methods (4) 

        /// <summary>
        /// Adds the event receiver.
        /// </summary>
        /// <param name="spList">The sp list.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="spEventReceiverType">Type of the sp event receiver.</param>
        /// <param name="eventReceiverElement">The event receiver element.</param>
        private void AddEventReceiver(SPList spList, string assembly, string className,
                                      SPEventReceiverType spEventReceiverType, ref XElement eventReceiverElement)
        {
            var eventElement = new XElement("EventReceiver", new XAttribute("Type", spEventReceiverType.ToString()),
                                            new XAttribute("Assembly", assembly), new XAttribute("Class", className),
                                            new XAttribute("SiteId", spList.ParentWeb.Site.ID),
                                            new XAttribute("WebId", spList.ParentWeb.ID),
                                            new XAttribute("ListId", spList.ID),
                                            new XAttribute("Status", 0));

            bool found = false;

            foreach (SPEventReceiverDefinition spEventReceiverDefinition in
                spList.EventReceivers.Cast<SPEventReceiverDefinition>()
                    .Where(spEventReceiverDefinition =>
                           spEventReceiverDefinition.Assembly.Equals(assembly) &&
                           spEventReceiverDefinition.Class.Equals(className) &&
                           spEventReceiverDefinition.Type == spEventReceiverType))
            {
                found = true;

                // ReSharper disable PossibleNullReferenceException

                eventElement.Attribute("Status").SetValue(1);

                // ReSharper restore PossibleNullReferenceException

                eventElement.SetValue("Operation not performed. Event receiver already exists.");
            }

            spList.ParentWeb.AllowUnsafeUpdates = true;

            if (!found)
            {
                spList.EventReceivers.Add(spEventReceiverType, assembly, className);
                spList.Update();

                eventElement.SetValue("Event receiver successfully installed.");
            }

            eventReceiverElement.Add(new XElement("Data", eventElement));
        }

        /// <summary>
        /// Lists the event receivers.
        /// </summary>
        /// <param name="spList">The sp list.</param>
        /// <param name="eventReceiverElement">The result element.</param>
        private void ListEventReceivers(SPList spList, ref XElement eventReceiverElement)
        {
            var dataElement = new XElement("Data");

            foreach (SPEventReceiverDefinition spEventReceiverDefinition in spList.EventReceivers)
            {
                dataElement.Add(new XElement("EventReceiver", new XAttribute("Id", spEventReceiverDefinition.Id),
                                             new XAttribute("Type", spEventReceiverDefinition.Type.ToString()),
                                             new XAttribute("Assembly", spEventReceiverDefinition.Assembly),
                                             new XAttribute("Class", spEventReceiverDefinition.Class),
                                             new XAttribute("SiteId", spEventReceiverDefinition.SiteId),
                                             new XAttribute("WebId", spEventReceiverDefinition.WebId),
                                             new XAttribute("ListId", spList.ID)));
            }

            eventReceiverElement.Add(dataElement);
        }

        /// <summary>
        /// Parses the request data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static DataTable ParseRequestData(string data)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("SiteId", typeof (Guid));
            dataTable.Columns.Add("WebId", typeof (Guid));
            dataTable.Columns.Add("ListId", typeof (Guid));
            dataTable.Columns.Add("Operation", typeof (string));
            dataTable.Columns.Add("EventType", typeof (SPEventReceiverType));
            dataTable.Columns.Add("Assembly", typeof (string));
            dataTable.Columns.Add("Class", typeof (string));
            dataTable.Columns.Add("DataId", typeof (string));

            XDocument requestDocument = XDocument.Parse(data);

            if (requestDocument.Root == null)
            {
                throw new APIException((int) Errors.ManageRootEleNotFound,
                                       "Cannot find the EventReceiverManager element.");
            }

            XElement dataElement = requestDocument.Root.Element("Data");

            if (dataElement == null)
            {
                throw new APIException((int) Errors.ManageDataEleNotFound,
                                       @"Cannot find the EventReceiverManager\Data element.");
            }

            IQueryable<XElement> eventReceiverElements = dataElement.Elements("EventReceiver").AsQueryable();

            if (!eventReceiverElements.Any())
            {
                throw new APIException((int) Errors.ManageEventReceiverEleNotFound,
                                       @"Cannot find the EventReceiverManager\Data\EventReceiver element.");
            }

            foreach (XElement eventReceiverElement in eventReceiverElements)
            {
                XAttribute dataIdAttribute = eventReceiverElement.Attribute("DataId");

                if (dataIdAttribute == null)
                {
                    throw new APIException((int) Errors.ManageSiteIdAttrNotFound,
                                           @"Cannot find the EventReceiverManager\Data\EventReceiver:DataId attribute.");
                }

                string dataId = dataIdAttribute.Value;

                XAttribute siteIdAttribute = eventReceiverElement.Attribute("SiteId");

                if (siteIdAttribute == null)
                {
                    throw new APIException((int) Errors.ManageSiteIdAttrNotFound,
                                           string.Format(
                                               @"DataId: {0}. Cannot find the EventReceiverManager\Data\EventReceiver:SiteId attribute.",
                                               dataId));
                }

                var siteId = new Guid(siteIdAttribute.Value);

                XAttribute webIdAttribute = eventReceiverElement.Attribute("WebId");

                if (webIdAttribute == null)
                {
                    throw new APIException((int) Errors.ManageWebIdAttrNotFound,
                                           string.Format(
                                               @"DataId: {0}. Cannot find the EventReceiverManager\Data\EventReceiver:WebId attribute.",
                                               dataId));
                }

                var webId = new Guid(webIdAttribute.Value);

                XAttribute listIdAttribute = eventReceiverElement.Attribute("ListId");

                if (listIdAttribute == null)
                {
                    throw new APIException((int) Errors.ManageListIdAttrNotFound,
                                           string.Format(
                                               @"DataId: {0}. Cannot find the EventReceiverManager\Data\EventReceiver:ListId attribute.",
                                               dataId));
                }

                var listId = new Guid(listIdAttribute.Value);

                XAttribute typeAttribute = eventReceiverElement.Attribute("Type");

                if (typeAttribute == null)
                {
                    throw new APIException((int) Errors.ManageTypeAttrNotFound,
                                           string.Format(
                                               @"DataId: {0}. Cannot find the EventReceiverManager\Data\EventReceiver:Type attribute.",
                                               dataId));
                }

                string eventType = typeAttribute.Value;

                SPEventReceiverType eventReceiverType;

                try
                {
                    eventReceiverType = (SPEventReceiverType) Enum.Parse(typeof (SPEventReceiverType), eventType);
                }
                catch (Exception exception)
                {
                    throw new APIException((int) Errors.ManageInvalidEvent,
                                           string.Format(
                                               @"Data Id: {0}. Invalid Event Receiver Type: {1}. Excepton: {2}", dataId,
                                               eventType, exception.GetBaseException().Message));
                }

                XAttribute operationAttribute = eventReceiverElement.Attribute("Operation");

                if (operationAttribute == null)
                {
                    throw new APIException((int) Errors.ManageOperationAttrNotFound,
                                           string.Format(
                                               @"DataId: {0}. Cannot find the EventReceiverManager\Data\EventReceiver:Operation attribute.",
                                               dataId));
                }

                string operation = operationAttribute.Value.ToUpper();

                if (!operation.Equals("ADD") && !operation.Equals("REMOVE") && !operation.Equals("LIST"))
                {
                    throw new APIException((int) Errors.ManageInvalidOperation,
                                           string.Format(
                                               @"DataId: {0}. Invalid operation. Valid operations: ADD, REMOVE, LIST",
                                               dataId));
                }

                string assembly = string.Empty;
                string className = string.Empty;

                if (!operation.Equals("LIST"))
                {
                    XAttribute assemblyAttribute = eventReceiverElement.Attribute("Assembly");

                    if (assemblyAttribute == null)
                    {
                        throw new APIException((int) Errors.ManageAssemblyAttrNotFound,
                                               string.Format(
                                                   @"DataId: {0}. Cannot find the EventReceiverManager\Data\EventReceiver:Assembly attribute.",
                                                   dataId));
                    }

                    assembly = assemblyAttribute.Value;

                    Assembly asm;

                    try
                    {
                        asm = Assembly.Load(assembly);
                    }
                    catch (Exception exception)
                    {
                        throw new APIException((int) Errors.ManageAssemblyNotFound,
                                               string.Format(@"DataId: {0}. Cannot load assembly: {1}. Exception: {2}",
                                                             dataId, assembly,
                                                             exception.GetBaseException().Message));
                    }

                    XAttribute classNameAttribute = eventReceiverElement.Attribute("ClassName");

                    if (classNameAttribute == null)
                    {
                        throw new APIException((int) Errors.ManageClassNameAttrNotFound,
                                               string.Format(
                                                   @"DataId: {0}. Cannot find the EventReceiverManager\Data\EventReceiver:ClassName attribute.",
                                                   dataId));
                    }

                    className = classNameAttribute.Value;

                    Type type = asm.GetType(className);

                    if (type == null)
                    {
                        throw new APIException((int) Errors.ManageClassNotFound,
                                               string.Format(@"DataId: {0}. Cannot find type: {1} in assembly: {2}",
                                                             dataId, className,
                                                             assembly));
                    }

                    if (type.BaseType != null && !type.BaseType.Name.Equals("SPItemEventReceiver"))
                    {
                        throw new APIException((int) Errors.ManageNotAnEventReceiver,
                                               string.Format(
                                                   @"DataId: {0}. {1} is not an event receiver. {1} must derive from SPItemEventReceiver.",
                                                   dataId, className));
                    }
                }

                using (var spSite = new SPSite(siteId))
                {
                    SPWeb spWeb;

                    try
                    {
                        spWeb = spSite.OpenWeb(webId);
                    }
                    catch (Exception)
                    {
                        throw new APIException((int) Errors.ManageWebNotFound,
                                               string.Format(@"DataId: {0}. Cannot find Web with id: {1}", dataId, webId));
                    }

                    spWeb.Lists.GetList(listId, false);

                    spWeb.Dispose();
                }

                dataTable.Rows.Add(siteId, webId, listId, operation, eventReceiverType, assembly, className, dataId);
            }

            return dataTable;
        }

        /// <summary>
        /// Removes the event receiver.
        /// </summary>
        /// <param name="spList">The sp list.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="spEventReceiverType">Type of the sp event receiver.</param>
        /// <param name="eventReceiverElement">The event receiver element.</param>
        private void RemoveEventReceiver(SPList spList, string assembly, string className,
                                         SPEventReceiverType spEventReceiverType, ref XElement eventReceiverElement)
        {
            var eventElement = new XElement("EventReceiver", new XAttribute("Type", spEventReceiverType.ToString()),
                                            new XAttribute("Assembly", assembly), new XAttribute("Class", className),
                                            new XAttribute("SiteId", spList.ParentWeb.Site.ID),
                                            new XAttribute("WebId", spList.ParentWeb.ID),
                                            new XAttribute("ListId", spList.ID),
                                            new XAttribute("Status", 0));

            bool found = false;
            
            var events = new List<SPEventReceiverDefinition>();

            foreach (SPEventReceiverDefinition spEventReceiverDefinition in
                spList.EventReceivers.Cast<SPEventReceiverDefinition>()
                    .Where(spEventReceiverDefinition =>
                           spEventReceiverDefinition.Assembly.Equals(assembly) &&
                           spEventReceiverDefinition.Class.Equals(className) &&
                           spEventReceiverDefinition.Type == spEventReceiverType))
            {
                found = true;

                events.Add(spEventReceiverDefinition);
            }

            if (found)
            {
                foreach (SPEventReceiverDefinition spEventReceiverDefinition in events)
                {
                    spEventReceiverDefinition.Delete();
                }

                spList.Update();

                eventElement.SetValue("Event receiver successfully uninstalled.");
            }
            else
            {
                // ReSharper disable PossibleNullReferenceException

                eventElement.Attribute("Status").SetValue(1);

                // ReSharper restore PossibleNullReferenceException

                eventElement.SetValue("Operation not performed. Event receiver was not found.");
            }

            eventReceiverElement.Add(new XElement("Data", eventElement));
        }

        #endregion Methods 
    }
}