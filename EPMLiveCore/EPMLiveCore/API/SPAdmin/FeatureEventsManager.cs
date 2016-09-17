using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ListDefinitions;
using Microsoft.SharePoint;

namespace EPMLiveCore.API.SPAdmin
{
    internal class FeatureEventsManager : BaseManager
    {
        #region Fields (1) 

        private static readonly IEnumerable<string> Features = new[]
                                                                   {
                                                                       "myworkreporting",
                                                                       "pfedatasync",
                                                                       "pferesourcemanagement"
                                                                   };

        #endregion Fields 

        #region Enums (1) 

        internal enum Errors
        {
            Manage = 900200,
            GFORootEleNotFound,
            GFODataEleNotFound,
            GFOFeatureEleNotFound,
            GFOFeatureNameAttrNotFound,
            GFOFeatureOpAttrNotFound,
            GFOInvalidFeature,
            GFOInvalidOperation
        }

        #endregion Enums 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureEventsManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public FeatureEventsManager(SPWeb spWeb)
            : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (7) 

        // Public Methods (1) 

        public string Manage(string data)
        {
            try
            {
                var dataElement = new XElement("Data");

                Dictionary<string, string> features = GetFeatures(data);

                foreach (var feature in features)
                {
                    if (feature.Key.Equals("myworkreporting"))
                    {
                        AddRemoveMyWorkReportingEvents(feature.Value, ref dataElement);
                    }
                    else if (feature.Key.Equals("pfedatasync"))
                    {
                        AddRemovePFEDataSyncEvents(feature.Value, ref dataElement);
                    }
                    else if (feature.Key.Equals("pferesourcemanagement"))
                    {
                        AddRemovePFEResourceManagementEvents(feature.Value, ref dataElement);
                    }
                }

                string response =
                    WorkEngineAPI.EventReceiverManager(new XElement("EventReceiverManager", dataElement).ToString(),
                                                       Web);

                XDocument responseDocument = XDocument.Parse(response);

                // ReSharper disable PossibleNullReferenceException

                responseDocument.Root.Name = "AddRemoveFeatureEvents";

                // ReSharper restore PossibleNullReferenceException

                return responseDocument.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new APIException((int) EventReceiverManager.Errors.Manage, exception.GetBaseException().Message);
            }
        }

        // Private Methods (6) 

        /// <summary>
        /// Adds the event receiver element.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="spEventReceiverTypes">The sp event receiver types.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="dataElement">The data element.</param>
        private void AddEventReceiverElement(string operation, string className, string assembly,
                                             IEnumerable<SPEventReceiverType> spEventReceiverTypes, Guid listId,
                                             ref XElement dataElement)
        {
            foreach (SPEventReceiverType spEventReceiverType in spEventReceiverTypes)
            {
                dataElement.Add(new XElement("EventReceiver", new XAttribute("SiteId", Web.Site.ID),
                                             new XAttribute("WebId", Web.ID), new XAttribute("ListId", listId),
                                             new XAttribute("Type", (int) spEventReceiverType),
                                             new XAttribute("Operation", operation),
                                             new XAttribute("Assembly", assembly),
                                             new XAttribute("ClassName", className),
                                             new XAttribute("DataId", listId)));
            }
        }

        /// <summary>
        /// Adds the remove my work reporting events.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="dataElement">The data element.</param>
        private void AddRemoveMyWorkReportingEvents(string operation, ref XElement dataElement)
        {
            const string assembly =
                "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";

            const string className = "EPMLiveReportsAdmin.MyWorkListEvents";

            IEnumerable<Guid> listIds = Web.Lists.Cast<SPList>()
                .Where(spList => (int) spList.BaseTemplate == (int) EPMLiveLists.MyWork)
                .Select(spList => spList.ID);

            foreach (Guid listId in listIds)
            {
                var spEventReceiverTypes = new[]
                                               {
                                                   SPEventReceiverType.ItemAdded, SPEventReceiverType.ItemUpdated,
                                                   SPEventReceiverType.ItemDeleting
                                               };

                AddEventReceiverElement(operation, className, assembly, spEventReceiverTypes, listId, ref dataElement);
            }
        }

        /// <summary>
        /// Adds the remove PFE data sync events.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="dataElement">The data element.</param>
        private void AddRemovePFEDataSyncEvents(string operation, ref XElement dataElement)
        {
            const string assembly = "WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";

            var classDict = new Dictionary<EPMLiveLists, string>
                                {
                                    {EPMLiveLists.Departments, "DepartmentSyncEvent"},
                                    {EPMLiveLists.Holidays, "HolidaySyncEvent"},
                                    {EPMLiveLists.Roles, "RoleSyncEvent"},
                                    {EPMLiveLists.WorkHours, "WorkScheduleSyncEvent"},
                                    {EPMLiveLists.HolidaySchedules, "HolidayScheduleSyncEvent"},
                                };

            using (SPSite spSite = new SPSite(Web.Site.ID))
            {
                spSite.AllowUnsafeUpdates = true;

                using (SPWeb spWeb = spSite.OpenWeb(Web.ID))
                {
                    spWeb.AllowUnsafeUpdates = true;

                    foreach (var keyValuePair in classDict)
                    {
                        KeyValuePair<EPMLiveLists, string> listEventInfo = keyValuePair;

                        IEnumerable<Guid> listIds = spWeb.Lists.Cast<SPList>()
                            .Where(spList => (int) spList.BaseTemplate == (int) listEventInfo.Key)
                            .Select(spList => spList.ID);

                        foreach (Guid listId in listIds)
                        {
                            var spEventReceiverTypes = new[]
                                                           {
                                                               SPEventReceiverType.ItemAdding,
                                                               SPEventReceiverType.ItemUpdating,
                                                               SPEventReceiverType.ItemDeleting,
                                                               SPEventReceiverType.ItemAdded
                                                           };

                            AddEventReceiverElement(operation,
                                                    string.Format("WorkEnginePPM.Events.DataSync.{0}",
                                                                  listEventInfo.Value),
                                                    assembly, spEventReceiverTypes,
                                                    listId, ref dataElement);

                            ConfigureExtIdField(listId, spWeb);
                        }
                    }

                    SPList timeOffList = spWeb.Lists.TryGetList("Time Off");

                    if (timeOffList != null)
                    {
                        var spEventReceiverTypes = new[]
                                                       {
                                                           SPEventReceiverType.ItemAdded,
                                                           SPEventReceiverType.ItemUpdated,
                                                           SPEventReceiverType.ItemDeleting
                                                       };

                        Guid listId = timeOffList.ID;

                        AddEventReceiverElement(operation, "WorkEnginePPM.Events.DataSync.TimeOffSyncEvent", assembly,
                                                spEventReceiverTypes, listId, ref dataElement);

                        ConfigureExtIdField(listId, spWeb);
                    }

                    SPList personalItemsList = spWeb.Lists.TryGetList("Non Work");

                    if (personalItemsList != null)
                    {
                        var spEventReceiverTypes = new[]
                                                       {
                                                           SPEventReceiverType.ItemAdded,
                                                           SPEventReceiverType.ItemAdding,
                                                           SPEventReceiverType.ItemUpdating,
                                                           SPEventReceiverType.ItemDeleting
                                                       };

                        Guid listId = personalItemsList.ID;

                        AddEventReceiverElement(operation, "WorkEnginePPM.Events.DataSync.PersonalItemsEvent", assembly,
                                                spEventReceiverTypes, listId, ref dataElement);

                        ConfigureExtIdField(listId, spWeb);
                    }

                    SPList rolesList = spWeb.Lists.TryGetList("Roles");

                    if (rolesList != null)
                    {
                        bool fieldAdded = false;

                        if (!rolesList.Fields.ContainsFieldWithInternalName("RoleId"))
                        {
                            var roleIdField = (SPFieldText) rolesList.Fields.CreateNewField(SPFieldType.Text.ToString(), "RoleId");

                            roleIdField.Hidden = true;

                            rolesList.Fields.Add(roleIdField);

                            fieldAdded = true;
                        }

                        if (!rolesList.Fields.ContainsFieldWithInternalName("CCRName"))
                        {
                            var ccrNameField = (SPFieldText) rolesList.Fields.CreateNewField(SPFieldType.Text.ToString(), "CCRName");

                            rolesList.Fields.Add(ccrNameField);

                            fieldAdded = true;
                        }

                        if (fieldAdded)
                        {
                            rolesList.Update();

                            SPField roleIdField = rolesList.Fields.GetFieldByInternalName("RoleId");
                            roleIdField.Title = "Role ID";
                            roleIdField.Update();

                            SPField ccrNameField = rolesList.Fields.GetFieldByInternalName("CCRName");
                            ccrNameField.Title = "Display Name";
                            ccrNameField.Update();
                        }
                    }

                    spWeb.AllowUnsafeUpdates = false;
                }

                spSite.AllowUnsafeUpdates = false;
            }
        }

        /// <summary>
        /// Adds the remove PFE resource management events.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="dataElement">The data element.</param>
        private void AddRemovePFEResourceManagementEvents(string operation, ref XElement dataElement)
        {
            const string assembly = "WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";

            using (var spSite = new SPSite(Web.Site.ID))
            {
                spSite.AllowUnsafeUpdates = true;

                using (SPWeb spWeb = spSite.OpenWeb(Web.ID))
                {
                    spWeb.AllowUnsafeUpdates = true;

                    SPList spList = spWeb.Lists.TryGetList("Resources");

                    if (spList != null)
                    {
                        var spEventReceiverTypes = new[]
                                                       {
                                                           SPEventReceiverType.ItemAdded,
                                                           SPEventReceiverType.ItemAdding,
                                                           SPEventReceiverType.ItemUpdating,
                                                           SPEventReceiverType.ItemUpdated,
                                                           SPEventReceiverType.ItemDeleting
                                                       };

                        Guid listId = spList.ID;

                        AddEventReceiverElement(operation, "WorkEnginePPM.Events.ResourceManagementEvent", assembly,
                                                spEventReceiverTypes, listId, ref dataElement);

                        ConfigureExtIdField(listId, spWeb);
                    }

                    spWeb.AllowUnsafeUpdates = false;
                }

                spSite.AllowUnsafeUpdates = false;
            }
        }

        /// <summary>
        /// Configures the ext id field.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="spWeb">The sp web.</param>
        private void ConfigureExtIdField(Guid listId, SPWeb spWeb)
        {
            SPList spList = spWeb.Lists.GetList(listId, true);

            if (spList.Fields.ContainsFieldWithInternalName("EXTID")) return;

            var spFieldText = (SPFieldText) spList.Fields.CreateNewField(SPFieldType.Text.ToString(), "EXTID");
            spFieldText.Hidden = true;

            spList.Fields.Add(spFieldText);

            spList.Update();
        }

        /// <summary>
        /// Gets the feature and operation.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private Dictionary<string, string> GetFeatures(string data)
        {
            var dictionary = new Dictionary<string, string>();

            XDocument requestDocument = XDocument.Parse(data);

            if (requestDocument.Root == null)
            {
                throw new APIException((int) Errors.GFORootEleNotFound,
                                       "Cannot find the AddRemoveFeatureEvents element.");
            }

            XElement dataElement = requestDocument.Root.Element("Data");

            if (dataElement == null)
            {
                throw new APIException((int) Errors.GFODataEleNotFound,
                                       @"Cannot find the AddRemoveFeatureEvents\Data element.");
            }

            IQueryable<XElement> featureElements = dataElement.Elements("Feature").AsQueryable();

            if (!featureElements.Any())
            {
                throw new APIException((int) Errors.GFOFeatureEleNotFound,
                                       @"Cannot find the AddRemoveFeatureEvents\Data\Feature element.");
            }

            foreach (XElement featureElement in featureElements)
            {
                XAttribute featureNameAttribute = featureElement.Attribute("Name");

                if (featureNameAttribute == null)
                {
                    throw new APIException((int) Errors.GFOFeatureNameAttrNotFound,
                                           @"Cannot find the AddRemoveFeatureEvents\Data\Feature:Name attribute.");
                }

                string featureName = featureNameAttribute.Value.ToLower();

                if (!Features.Contains(featureName))
                {
                    throw new APIException((int) Errors.GFOInvalidFeature,
                                           string.Format("{0} is not a valid feature.", featureName));
                }


                XAttribute featureOperationAttribute = featureElement.Attribute("Operation");

                if (featureOperationAttribute == null)
                {
                    throw new APIException((int) Errors.GFOFeatureOpAttrNotFound,
                                           @"Cannot find the AddRemoveFeatureEvents\Data\Feature:Operation attribute.");
                }

                string featureOperation = featureOperationAttribute.Value.ToUpper();

                if (!featureOperation.Equals("ADD") && !featureOperation.Equals("REMOVE"))
                {
                    throw new APIException((int) Errors.GFOInvalidOperation,
                                           string.Format(
                                               "{0} is not a valid operation. Supported operations are: ADD, REMOVE",
                                               featureOperation));
                }

                if (dictionary.ContainsKey(featureName)) dictionary[featureName] = featureOperation;
                else dictionary.Add(featureName, featureOperation);
            }

            return dictionary;
        }

        #endregion Methods 
    }
}