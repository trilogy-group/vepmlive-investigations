using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using PortfolioEngineCore.Infrastructure.Entities;
using PortfolioEngineCore.Infrastructure.Fields;
using WorkEnginePPM.Core;
using EPMUtils = EPMLiveCore.API.Utils;

namespace WorkEnginePPM.WebServices.Core
{
    internal class ResourceManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public ResourceManager(SPWeb spWeb) : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (14) 

        // Private Methods (7) 

        /// <summary>
        /// Builds the resources table.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="requestedResources">The requested resources.</param>
        private void BuildResourcesTable(string data, ref DataTable requestedResources)
        {
            XDocument resourcesXml = XDocument.Parse(data);

            // ReSharper disable PossibleNullReferenceException

            foreach (XElement resourceElement in resourcesXml.Root.Element("Data").Elements("Resource"))
            {
                var dictionary = new Dictionary<string, string>();

                foreach (XElement fieldElement in resourceElement.Elements("Field"))
                {
                    string fieldId = fieldElement.Attribute("Id").Value;

                    if (!dictionary.ContainsKey(fieldId))
                    {
                        dictionary.Add(fieldId, fieldElement.Value);
                    }
                }

                if (dictionary.Count <= 0) continue;

                foreach (DataRow dataRow in requestedResources.Rows)
                {
                    if (!dataRow["DataId"].Equals(resourceElement.Attribute("DataId").Value)) continue;

                    foreach (var keyValuePair in dictionary)
                    {
                        string columnName = keyValuePair.Key;

                        if (!requestedResources.Columns.Contains(columnName))
                        {
                            requestedResources.Columns.Add(columnName);
                        }

                        dataRow[columnName] = keyValuePair.Value;
                    }

                    break;
                }
            }

            // ReSharper restore PossibleNullReferenceException
        }

        /// <summary>
        /// Gets the admin functions core.
        /// </summary>
        /// <param name="securityLevel">The security levels.</param>
        /// <param name="debugging">if set to <c>true</c> [debugging].</param>
        /// <returns></returns>
        private AdminFunctions GetAdminFunctionsCore(SecurityLevels securityLevel, bool debugging = false)
        {
            AdminFunctions adminFunctions = null;

            SPSecurity.RunWithElevatedPrivileges(
                () => { adminFunctions = InitilizeAdminFunctionsCore(securityLevel, debugging, Username); });

            return adminFunctions;
        }

        /// <summary>
        /// Gets the C data value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private object GetCDataValue(object value)
        {
            var stringValue = value as string;

            if (string.IsNullOrEmpty(stringValue)) return string.Empty;

            return new XCData(stringValue);
        }

        /// <summary>
        /// Gets the requested resources.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private DataTable GetRequestedResources(string data)
        {
            XDocument inputXml = XDocument.Parse(data);
            XElement rootElement = inputXml.Root;

            if (rootElement == null)
            {
                throw new Exception("Cannot find the root element.");
            }

            XElement dataElement = rootElement.Element("Data");

            if (dataElement == null)
            {
                throw new Exception("Cannot find the data element.");
            }

            IEnumerable<XElement> resourceElements = dataElement.Elements("Resource").ToList();

            if (!resourceElements.Any())
            {
                throw new Exception("No Resource element was found.");
            }

            var dataIds = new List<string>();

            var dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof (int));
            dataTable.Columns.Add("ExtId", typeof (string));
            dataTable.Columns.Add("Username", typeof (string));
            dataTable.Columns.Add("DataId", typeof (string));

            foreach (XElement resourceElement in resourceElements)
            {
                string id = null;
                string extId = null;
                string username = null;

                XAttribute idAttribute = resourceElement.Attribute("Id");
                if (idAttribute != null) id = idAttribute.Value;

                XAttribute extIdAttribute = resourceElement.Attribute("ExtId");
                if (extIdAttribute != null) extId = extIdAttribute.Value;

                XAttribute usernameAttribute = resourceElement.Attribute("Username");
                if (usernameAttribute != null) username = usernameAttribute.Value;

                if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(extId) && string.IsNullOrEmpty(username))
                {
                    throw new Exception("You must specify at least one of these attributes: Id, ExtId, Username");
                }

                XAttribute dataIdAttribute = resourceElement.Attribute("DataId");
                if (dataIdAttribute == null)
                {
                    throw new Exception("Cannot find the DataId attribute.");
                }

                string dataId = dataIdAttribute.Value;

                if (string.IsNullOrEmpty(dataId)) throw new Exception("Please specify the DataId Attribute.");

                if (dataIds.Contains(dataId))
                {
                    throw new Exception("Duplicate DataId found.");
                }

                dataTable.Rows.Add(Convert.ToInt32(id), extId, username, dataId);
                dataIds.Add(dataId);
            }

            return dataTable;
        }

        /// <summary>
        /// Gets the resource core.
        /// </summary>
        /// <param name="secLevel">The sec level.</param>
        /// <param name="debugging"> </param>
        /// <returns></returns>
        private Resources GetResourceCore(SecurityLevels secLevel, bool debugging = false)
        {
            Resources resClass = null;

            SPSecurity.RunWithElevatedPrivileges(
                () => { resClass = InitilizeResourceCore(secLevel, debugging, Username); });

            return resClass;
        }

        /// <summary>
        /// Initilizes the admin functions core.
        /// </summary>
        /// <param name="securityLevel">The security level.</param>
        /// <param name="debugging">if set to <c>true</c> [debugging].</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        private AdminFunctions InitilizeAdminFunctionsCore(SecurityLevels securityLevel, bool debugging, string username)
        {
            AdminFunctions adminFunctions;

            using (var site = new SPSite(Web.Site.ID))
            {
                SPWeb rootWeb = site.RootWeb;

                string basePath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                string ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                string ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                string ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

                adminFunctions = new AdminFunctions(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel,
                                                    debugging);
            }

            return adminFunctions;
        }

        /// <summary>
        /// Initilizes the resource core.
        /// </summary>
        /// <param name="secLevel">The sec level.</param>
        /// <param name="debugging">if set to <c>true</c> [debugging].</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        private Resources InitilizeResourceCore(SecurityLevels secLevel, bool debugging, string username)
        {
            Resources resClass;

            using (var site = new SPSite(Web.Site.ID))
            {
                SPWeb rootWeb = site.RootWeb;

                string basePath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                string ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                string ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                string ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

                resClass = new Resources(basePath, username, ppmId, ppmCompany, ppmDbConn, secLevel, debugging);
            }

            return resClass;
        }

        // Internal Methods (7) 

        /// <summary>
        /// Deletes the resource check.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeleteResourceCheck(string data)
        {
            try
            {
                var dataElement = new XElement("Data");

                DataTable requestedResources = GetRequestedResources(data);
                Resources resourceCore = GetResourceCore(SecurityLevels.EditResources);

                BuildResourcesTable(data, ref requestedResources);

                foreach (DataRow dataRow in requestedResources.Rows)
                {
                    var resourceElement = new XElement("Resource", new XAttribute("DataId", dataRow["DataId"]));
                    var resourceResultElement = new XElement("Result");

                    try
                    {
                        Resource resource = resourceCore.BuildResource(dataRow);

                        if (resource.Id == 0) throw new Exception("Resource cannot be found.");

                        string message;
                        string canDelete = resourceCore.CanDelete(resource, out message);

                        resourceElement.Add(new XAttribute("Id", resource.Id),
                                            new XAttribute("ExtId", resource.ExternalUId ?? string.Empty),
                                            new XAttribute("Username", resource.NTAccount ?? string.Empty),
                                            new XAttribute("CanDelete", canDelete));

                        resourceResultElement.Add(new XAttribute("Status", (int) Response.ExecutionStatus.Success),
                                                  new XCData(message));
                    }
                    catch (Exception exception)
                    {
                        Utils.SetResultError(exception, ref resourceResultElement);
                    }

                    resourceElement.Add(resourceResultElement);

                    dataElement.Add(resourceElement);
                }

                return Response.Success(dataElement.ToString());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeleteResourceCheck, exception);
            }
        }

        /// <summary>
        /// Deletes the resources.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string DeleteResources(string data)
        {
            try
            {
                var dataElement = new XElement("Data");

                DataTable requestedResources = GetRequestedResources(data);
                Resources resourceCore = GetResourceCore(SecurityLevels.EditResources);

                BuildResourcesTable(data, ref requestedResources);

                foreach (DataRow dataRow in requestedResources.Rows)
                {
                    var resourceElement = new XElement("Resource", new XAttribute("DataId", dataRow["DataId"]));
                    var resourceResultElement = new XElement("Result");

                    try
                    {
                        Resource resource = resourceCore.BuildResource(dataRow);

                        if (resource.Id == 0) throw new Exception("Resource cannot be found.");

                        resourceCore.Delete(resource, Web.CurrentUser.GetExtId(Web));

                        resourceElement.Add(new XAttribute("Id", resource.Id),
                                            new XAttribute("ExtId", resource.ExternalUId ?? string.Empty),
                                            new XAttribute("Username", resource.NTAccount ?? string.Empty));

                        resourceResultElement.Add(new XAttribute("Status", (int) Response.ExecutionStatus.Success));
                    }
                    catch (Exception exception)
                    {
                        Utils.SetResultError(exception, ref resourceResultElement);
                    }

                    resourceElement.Add(resourceResultElement);

                    dataElement.Add(resourceElement);
                }

                return Response.Success(dataElement.ToString());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.DeleteResources, exception);
            }
        }

        /// <summary>
        /// Reads the permission groups.
        /// </summary>
        /// <returns></returns>
        internal string ReadPermissionGroups()
        {
            try
            {
                Resources resourceCore = GetResourceCore(SecurityLevels.Base);

                var dataElement = new XElement("Data");

                IList<Group> permissionGroups = resourceCore.GetPermissionGroups();
                foreach (Group permissionGroup in permissionGroups)
                {
                    var permissionGroupElement = new XElement("PermissionGroup",
                                                              GetCDataValue(permissionGroup.Description));
                    permissionGroupElement.Add(new XAttribute("Id", permissionGroup.Id));
                    permissionGroupElement.Add(new XAttribute("Name", permissionGroup.Name));

                    dataElement.Add(permissionGroupElement);
                }

                return Response.Success(dataElement.ToString());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.ReadPermissionGroups, exception);
            }
        }

        /// <summary>
        /// Reads the resource cost category role.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string ReadResourceCostCategoryRole(string data)
        {
            try
            {
                DataTable requestedResources = GetRequestedResources(data);

                Resources resourceCore = GetResourceCore(SecurityLevels.Base);

                var dataElement = new XElement("Data");

                foreach (DataRow dataRow in requestedResources.Rows)
                {
                    var resourceElement = new XElement("Resource");
                    resourceElement.Add(new XAttribute("DataId", dataRow["DataId"]));

                    var resultElement = new XElement("Result");

                    try
                    {
                        var id = dataRow["Id"] as int?;
                        var extId = dataRow["ExtId"] as string;
                        var username = dataRow["Username"] as string;

                        resourceElement.Add(new XAttribute("Id",
                                                           id.HasValue
                                                               ? (id.Value == 0
                                                                      ? string.Empty
                                                                      : id.Value.ToString(CultureInfo.InvariantCulture))
                                                               : string.Empty));

                        resourceElement.Add(new XAttribute("ExtId", extId ?? string.Empty));
                        resourceElement.Add(new XAttribute("Username", username ?? string.Empty));

                        Role role = resourceCore.GetResourceCostCategoryRole(id, extId, username);

                        resourceElement.Add(
                            new XElement("CostCategoryRole", new XAttribute("Id", role.Id),
                                         new XAttribute("CostCategoryRoleId", role.CostCategoryRoleId),
                                         new XAttribute("Name", role.Name),
                                         new XAttribute("Status", (int) Response.ExecutionStatus.Success)));
                    }
                    catch (Exception exception)
                    {
                        Utils.SetResultError(exception, ref resultElement);
                    }

                    resourceElement.Add(resultElement);
                    dataElement.Add(resourceElement);
                }

                return Response.Success(dataElement.ToString());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.ReadResourceCostCategoryRole, exception);
            }
        }

        /// <summary>
        /// Reads the resource permission groups.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string ReadResourcePermissionGroups(string data)
        {
            try
            {
                DataTable requestedResources = GetRequestedResources(data);

                Resources resourceCore = GetResourceCore(SecurityLevels.Base);

                var dataElement = new XElement("Data");

                foreach (DataRow dataRow in requestedResources.Rows)
                {
                    var resourceElement = new XElement("Resource");
                    resourceElement.Add(new XAttribute("DataId", dataRow["DataId"]));

                    var resultElement = new XElement("Result");

                    try
                    {
                        var id = dataRow["Id"] as int?;
                        var extId = dataRow["ExtId"] as string;
                        var username = dataRow["Username"] as string;

                        resourceElement.Add(new XAttribute("Id",
                                                           id.HasValue
                                                               ? (id.Value == 0
                                                                      ? string.Empty
                                                                      : id.Value.ToString(CultureInfo.InvariantCulture))
                                                               : string.Empty));

                        resourceElement.Add(new XAttribute("ExtId", extId ?? string.Empty));
                        resourceElement.Add(new XAttribute("Username", username ?? string.Empty));

                        IList<Group> resourcePermissionGroups =
                            resourceCore.GetResourcePermissionGroups(id, extId, username);

                        foreach (Group resourcePermissionGroup in resourcePermissionGroups)
                        {
                            var groupElement = new XElement("PermissionGroup");
                            groupElement.Add(new XAttribute("Id", resourcePermissionGroup.Id));
                            groupElement.Add(new XAttribute("Name", resourcePermissionGroup.Name));

                            resourceElement.Add(groupElement);
                        }

                        resultElement.Add(new XAttribute("Status", (int) Response.ExecutionStatus.Success));
                    }
                    catch (Exception exception)
                    {
                        Utils.SetResultError(exception, ref resultElement);
                    }

                    resourceElement.Add(resultElement);
                    dataElement.Add(resourceElement);
                }

                return Response.Success(dataElement.ToString());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.ReadResourcePermissionGroups, exception);
            }
        }

        /// <summary>
        /// Builds the read resource response.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string ReadResources(string data)
        {
            try
            {
                DataTable requestedResources = GetRequestedResources(data);
                Resources resourceCore = GetResourceCore(SecurityLevels.Base);

                var dataElement = new XElement("Data");

                foreach (DataRow dataRow in requestedResources.Rows)
                {
                    var resourceElement = new XElement("Resource");
                    resourceElement.Add(new XAttribute("DataId", dataRow["DataId"]));

                    var resultElement = new XElement("Result");

                    try
                    {
                        var id = dataRow["Id"] as int?;
                        var extId = dataRow["ExtId"] as string;
                        var username = dataRow["Username"] as string;

                        Resource resource = resourceCore.FindResource(id, extId, username);

                        foreach (PropertyInfo propertyInfo in resource.GetType().GetProperties())
                        {
                            string propertyName = propertyInfo.Name;

                            if (propertyName.Equals("Password")) continue;

                            object propertyValue = propertyInfo.GetValue(resource, null);

                            if (propertyName.Equals("Id"))
                            {
                                resourceElement.Add(new XAttribute("Id", propertyValue));
                            }
                            else if (propertyName.Equals("CustomFields"))
                            {
                                foreach (IField field in resource.CustomFields)
                                {
                                    var fieldElement = new XElement("Field", field);

                                    fieldElement.Add(new XAttribute("Id", field.Id));
                                    fieldElement.Add(new XAttribute("Name", field.Name));

                                    object value = field.GetValue();

                                    var codeField = field as CodeField;

                                    if (codeField != null)
                                    {
                                        string code = codeField.GetCode().ToString(CultureInfo.InvariantCulture);
                                        if (code.Equals("0")) code = string.Empty;

                                        fieldElement.Add(new XAttribute("Code", code));
                                        fieldElement.SetValue(string.Empty);
                                        fieldElement.Add(GetCDataValue(value));
                                    }

                                    if (field is MultiValueCodeField)
                                    {
                                        fieldElement.SetValue(string.Empty);

                                        foreach (var keyValuePair in (Dictionary<int, string>) value)
                                        {
                                            var fieldDataElement = new XElement("FieldData",
                                                                                GetCDataValue(keyValuePair.Value));
                                            fieldDataElement.Add(new XAttribute("Code", keyValuePair.Key));

                                            fieldElement.Add(fieldDataElement);
                                        }
                                    }

                                    if (field is TextField)
                                    {
                                        fieldElement.SetValue(string.Empty);
                                        fieldElement.Add(GetCDataValue(value));
                                    }

                                    fieldElement.Add(new XAttribute("Type", field.GetType().Name));

                                    resourceElement.Add(fieldElement);
                                }
                            }
                            else
                            {
                                foreach (FieldInfoAttribute fieldInfoAttribute 
                                    in propertyInfo.GetCustomAttributes(typeof (FieldInfoAttribute), false))
                                {
                                    int fieldId = fieldInfoAttribute.Id;

                                    if (fieldId == 0) continue;

                                    var fieldElement = new XElement("Field", propertyValue);

                                    fieldElement.Add(new XAttribute("Id", fieldId));
                                    fieldElement.Add(new XAttribute("Name", propertyName));

                                    Type propertyType = propertyInfo.PropertyType;

                                    string fieldType = Utils.GetFieldType(propertyType);

                                    if (propertyName.Equals("Permissions"))
                                    {
                                        fieldElement.SetValue(string.Empty);

                                        foreach (var keyValuePair in resource.PermissionsDictionary)
                                        {
                                            var permissionGroupElement = new XElement("PermissionGroup",
                                                                                      keyValuePair.Value);
                                            permissionGroupElement.Add(new XAttribute("Id", keyValuePair.Key));

                                            fieldElement.Add(permissionGroupElement);
                                        }

                                        fieldType = "Dictionary<int, string>";
                                    }

                                    if (fieldType.Equals("String"))
                                    {
                                        fieldElement.SetValue(string.Empty);
                                        fieldElement.Add(GetCDataValue(propertyValue));
                                    }

                                    fieldElement.Add(new XAttribute("Type", fieldType));

                                    resourceElement.Add(fieldElement);
                                }
                            }
                        }

                        resourceElement.Add(new XAttribute("Status", (int) Response.ExecutionStatus.Success));
                    }
                    catch (Exception exception)
                    {
                        Utils.SetResultError(exception, ref resourceElement);
                    }

                    resourceElement.Add(resultElement);
                    dataElement.Add(resourceElement);
                }

                return Response.Success(dataElement.ToString());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.ReadResources, exception);
            }
        }

        /// <summary>
        /// Updates the resources.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string UpdateResources(string data)
        {
            try
            {
                var dataElement = new XElement("Data");

                DataTable requestedResources = GetRequestedResources(data);
                Resources resourceCore = GetResourceCore(SecurityLevels.EditResources);
                AdminFunctions adminFunctions = GetAdminFunctionsCore(SecurityLevels.AdminCalc);

                BuildResourcesTable(data, ref requestedResources);

                foreach (DataRow dataRow in requestedResources.Rows)
                {
                    var resourceElement = new XElement("Resource", new XAttribute("DataId", dataRow["DataId"]));
                    var resourceResultElement = new XElement("Result");

                    try
                    {
                        int resourceId = resourceCore.UpdateResource(resourceCore.BuildResource(dataRow));
                        adminFunctions.CalcAvailabilities(-1, resourceId.ToString(CultureInfo.InvariantCulture));

                        resourceElement.Add(new XAttribute("Id", resourceId),
                                            new XAttribute("Rate", adminFunctions.CalcResourceRate(resourceId)));
                        resourceResultElement.Add(new XAttribute("Status", (int) Response.ExecutionStatus.Success));
                    }
                    catch (Exception exception)
                    {
                        Utils.SetResultError(exception, ref resourceResultElement);
                    }

                    resourceElement.Add(resourceResultElement);

                    dataElement.Add(resourceElement);
                }

                return Response.Success(dataElement.ToString());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.UpdateResources, exception);
            }
        }

        #endregion Methods 
    }
}