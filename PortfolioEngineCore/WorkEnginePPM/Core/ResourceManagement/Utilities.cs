using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using WorkEnginePPM.WebServices.Core;

namespace WorkEnginePPM.Core.ResourceManagement
{
    public static class Utilities
    {
        #region Methods (12)

        // Public Methods (6) 

        /// <summary>
        ///     Adds the update resource.
        /// </summary>
        /// <param name="fieldsTable">The fields table.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="rate">The rate.</param>
        /// <returns></returns>
        public static int AddUpdateResource(DataTable fieldsTable, SPWeb spWeb, Guid listId, out decimal rate, Boolean returnId)
        {
            string dataId = Guid.NewGuid().ToString();

            var resourceElement = new XElement("Resource");

            foreach (DataRow dataRow in fieldsTable.Rows)
            {
                var fieldId = (int)dataRow["Id"];
                object rawValue = dataRow["Value"];

                if (fieldId == 0)
                {
                    if (rawValue == DBNull.Value || string.IsNullOrEmpty((string)rawValue)) rawValue = "0";

                    if (rawValue.Equals("0"))
                    {
                        bool proceed = false;

                        DataRow[] idRows = fieldsTable.Select("Id = 3013");
                        if (idRows.Length == 0)
                        {
                            proceed = true;
                        }
                        else
                        {
                            object id = idRows[0]["Value"];
                            if (id == DBNull.Value || id == null)
                            {
                                proceed = true;
                            }
                            else
                            {
                                resourceElement.Add(new XAttribute("ExtId", id));
                            }
                        }

                        if (proceed)
                        {
                            long externalId = DateTime.Now.Ticks;
                            resourceElement.Add(new XAttribute("ExtId", externalId));

                            resourceElement.Add(new XElement("Field", externalId,
                                new XAttribute("Id", (int)PFEResourceField.ID)));
                        }
                    }
                    else
                    {
                        resourceElement.Add(new XAttribute("Id", rawValue));
                    }
                }
                else
                {
                    resourceElement.Add(new XElement("Field", GetCleanFieldValue(spWeb, dataRow, rawValue, returnId),
                        new XAttribute("Id", fieldId)));
                }
            }

            resourceElement.Add(new XElement("Field", true, new XAttribute("Id", (int)PFEResourceField.IsResource)));

            resourceElement.Add(new XAttribute("DataId", dataId));

            var rootElement = new XElement("UpdateResources", new XElement("Data", resourceElement));

            XDocument responseXml;

            using (var resourceManager = new ResourceManager(spWeb))
            {
                responseXml = XDocument.Parse(resourceManager.UpdateResources(rootElement.ToString()));
            }

            // ReSharper disable PossibleNullReferenceException

            XElement responseRoot = responseXml.Root;

            if (responseRoot != null)
            {
                XElement resultElement = responseRoot.Element("Result");
                XAttribute statusAttribute = resultElement != null
                    ? resultElement.Attribute("Status")
                    : responseRoot.Attribute("Status");

                if (statusAttribute != null && statusAttribute.Value.Equals("1") && statusAttribute.Parent != null)
                {
                    XElement errorElement = statusAttribute.Parent.Element("Error");

                    if (errorElement != null) throw new Exception(errorElement.Value);
                }
            }

            List<XElement> resourceElements = responseRoot.Element("Data").Elements("Resource").ToList();

            foreach (XElement resResultElement in resourceElements
                .Where(resElement => resElement.Attribute("DataId").Value.Equals(dataId))
                .Select(resElement => resElement.Element("Result"))
                .Where(resResultElement => !resResultElement.Attribute("Status").Value.Equals("0")))
            {
                throw new Exception(resResultElement.Value);
            }

            rate = 0;

            XAttribute rateAttribute = resourceElements[0].Attribute("Rate");
            XAttribute extIdAttribute = resourceElements[0].Attribute("Id");

            if (!String.IsNullOrEmpty(rateAttribute.Value))
            {
                decimal resourceRate;
                if (decimal.TryParse(rateAttribute.Value, out resourceRate)) rate = resourceRate;
            }

            return Convert.ToInt32(resourceElements[0].Attribute("Id").Value);

            // ReSharper restore PossibleNullReferenceException
        }

        /// <summary>
        ///     Builds the fields table.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="isNewResource">if set to <c>true</c> [is new resource].</param>
        /// <returns></returns>
        public static DataTable BuildFieldsTable(SPItemEventProperties properties, bool isNewResource)
        {
            bool isOnline = false;
            bool isGeneric = false;

            using (var spSite = new SPSite(properties.SiteId))
            {
                if (spSite.WebApplication.Features[new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")] != null)
                {
                    isOnline = true;
                }
            }

            PFEResourceField pfeResourceField;

            var fieldsTable = new DataTable();

            fieldsTable.Columns.Add("Id", typeof(int));
            fieldsTable.Columns.Add("Value", typeof(object));
            fieldsTable.Columns.Add("Field", typeof(SPField));

            var defaultFields = new List<int>();

            SPFieldCollection spFieldCollection = properties.List.Fields;

            SPFieldUserValue resourceUser = null;

            try
            {
                resourceUser = new SPFieldUserValue(properties.Web,
                    (string)
                        (properties.AfterProperties["SharePointAccount"] ?? properties.ListItem["SharePointAccount"]));
            }
            catch { }

            foreach (SPField spField in spFieldCollection)
            {
                string internalName = spField.InternalName;

                DataRow dataRow = fieldsTable.NewRow();

                object currentValue = GetValue(properties, internalName);

                if (internalName.Equals("ID"))
                {
                    dataRow["Id"] = 0;
                    dataRow["Field"] = spField;
                    dataRow["Value"] = isNewResource ? currentValue : properties.ListItem["EXTID"];

                    fieldsTable.Rows.Add(dataRow);

                    if (!isNewResource)
                    {
                        DataRow idRow = fieldsTable.NewRow();

                        idRow["Id"] = (int)PFEResourceField.ID;
                        idRow["Field"] = dataRow["Field"];
                        idRow["Value"] = properties.ListItem["ID"];

                        fieldsTable.Rows.Add(idRow);
                    }
                }
                else
                {
                    if (!TryGetPFEFieldId(internalName, out pfeResourceField)) continue;

                    var resourceField = (int)pfeResourceField;

                    if (internalName.Equals("Permissions"))
                    {
                        string value;

                        if (isNewResource)
                        {
                            value = properties.AfterProperties[internalName] as string;
                        }
                        else
                        {
                            value =
                                (properties.AfterProperties[internalName] ?? properties.ListItem[internalName]) as
                                    string;
                        }

                        value = value ?? string.Empty;

                        var list = new List<string>();
                        string[] currentPermissions = value.Split(',').Select(perm => perm.Trim()).ToArray();

                        foreach (SPGroup spGroup in APITeam.GetWebGroups(properties.Web))
                        {
                            try
                            {
                                if (currentPermissions.Contains(spGroup.Name))
                                {
                                    list.Add(spGroup.Name + ":" + true);
                                }
                                else
                                {
                                    if (currentPermissions.Contains(spGroup.ID.ToString(CultureInfo.InvariantCulture)))
                                    {
                                        list.Add(spGroup.Name + ":" + true);
                                    }
                                    else
                                    {
                                        try
                                        {
                                            if (spGroup.Users.GetByID(resourceUser.LookupId) != null)
                                            {
                                                list.Add(spGroup.Name + ":" + true);
                                            }
                                            else
                                            {
                                                list.Add(spGroup.Name + ":" + false);
                                            }
                                        }
                                        catch
                                        {
                                            list.Add(spGroup.Name + ":" + false);
                                        }
                                    }
                                }
                            }
                            catch { }
                        }

                        currentValue = string.Join(",", list.ToArray());

                        dataRow["Id"] = resourceField;
                        dataRow["Value"] = currentValue;
                        dataRow["Field"] = spField;

                        fieldsTable.Rows.Add(dataRow);

                        defaultFields.Add(resourceField);

                        continue;
                    }

                    if (isNewResource)
                    {
                        if (internalName.Equals("Generic"))
                        {
                            bool.TryParse((string)currentValue, out isGeneric);
                            currentValue = isGeneric;
                        }

                        dataRow["Id"] = resourceField;
                        dataRow["Value"] = currentValue;
                        dataRow["Field"] = spField;

                        fieldsTable.Rows.Add(dataRow);

                        defaultFields.Add(resourceField);
                    }
                    else
                    {
                        try
                        {
                            currentValue = properties.ListItem[internalName];
                        }
                        catch { }

                        object newValue = GetValue(properties, internalName);

                        if (internalName.Equals("Generic"))
                        {
                            newValue = currentValue;
                        }
                        else if (internalName.Equals("SharePointAccount") && newValue == null)
                        {
                            newValue = currentValue;
                        }

                        if (!AreEqualObjects(newValue, currentValue, spField, properties.Web) ||
                            internalName.Equals("Title") || internalName.Equals("SharePointAccount"))
                        {
                            dataRow["Id"] = resourceField;
                            dataRow["Value"] = newValue;
                            dataRow["Field"] = spField;

                            fieldsTable.Rows.Add(dataRow);

                            defaultFields.Add(resourceField);
                        }
                    }
                }
            }

            string resourceFields = string.Empty;

            SPSecurity.RunWithElevatedPrivileges(
                () =>
                {
                    using (SPWeb spWeb = properties.OpenWeb())
                    {
                        resourceFields = CoreFunctions.getConfigSetting(spWeb, "epkresourcefields");
                    }
                });

            if (!string.IsNullOrEmpty(resourceFields))
            {
                foreach (string epkResourceField in resourceFields.Split('|'))
                {
                    string[] fieldParts = epkResourceField.Split(',');

                    int fieldId = Convert.ToInt32(fieldParts[0]);

                    if (defaultFields.Contains(fieldId)) continue;

                    string internalName = fieldParts[1];

                    if (internalName.Equals("StandardRate")) continue;

                    if (TryGetPFEFieldId(internalName, out pfeResourceField)) continue;

                    DataRow dataRow = fieldsTable.NewRow();

                    SPField spField;

                    try
                    {
                        spField = spFieldCollection.GetFieldByInternalName(internalName);
                    }
                    catch
                    {
                        continue;
                    }

                    object afterProperty;

                    try
                    {
                        afterProperty = properties.AfterProperties[internalName];
                    }
                    catch
                    {
                        continue;
                    }

                    object currentValue = GetValue(properties, internalName);

                    if (isNewResource)
                    {
                        if (internalName.Equals("CanLogin"))
                        {
                            if (isOnline)
                            {
                                bool canLogin;
                                bool.TryParse((string)currentValue, out canLogin);
                                currentValue = canLogin;
                            }
                            else
                            {
                                currentValue = !isGeneric;
                            }
                        }

                        dataRow["Id"] = fieldId;
                        dataRow["Value"] = currentValue;
                        dataRow["Field"] = spField;

                        fieldsTable.Rows.Add(dataRow);
                    }
                    else
                    {
                        try
                        {
                            currentValue = properties.ListItem[internalName];
                        }
                        catch { }

                        object newValue = afterProperty;

                        if (internalName.Equals("CanLogin"))
                        {
                            newValue = currentValue;
                        }

                        dataRow["Id"] = fieldId;
                        dataRow["Value"] = newValue;
                        dataRow["Field"] = spField;

                        fieldsTable.Rows.Add(dataRow);
                    }
                }
            }

            if (!isNewResource)
            {
                DataRow row = fieldsTable.Rows.Cast<DataRow>().FirstOrDefault(r => r["Field"].ToString().Equals("Email"));

                if (row == null)
                {
                    string email = null;

                    try
                    {
                        try
                        {
                            email = (string)properties.AfterProperties["Email"];
                        }
                        catch
                        {
                            email = (string)properties.ListItem["Email"];
                        }
                    }
                    catch { }

                    if (!string.IsNullOrEmpty(email))
                    {
                        DataRow dataRow = fieldsTable.NewRow();
                        dataRow["Id"] = (int)PFEResourceField.Email;
                        dataRow["Value"] = email;
                        dataRow["Field"] = properties.List.Fields["Email"];

                        fieldsTable.Rows.Add(dataRow);
                    }
                }
            }

            return fieldsTable;
        }

        /// <summary>
        ///     Deletes the resource.
        /// </summary>
        /// <param name="extId">The ext id.</param>
        /// <param name="dataId">The data id.</param>
        /// <param name="spWeb">The sp web.</param>
        public static void DeleteResource(int extId, Guid dataId, SPWeb spWeb)
        {
            XDocument responseXml;

            using (var resourceManager = new ResourceManager(spWeb))
            {
                responseXml =
                    XDocument.Parse(
                        resourceManager.DeleteResources(
                            string.Format(
                                @"<DeleteResources><Data><Resource Id=""{0}"" DataId=""{1}""/></Data></DeleteResources>",
                                extId, dataId)));
            }

            XElement rootElement = responseXml.Root;

            if (rootElement == null)
            {
                throw new Exception("No Root element found.");
            }

            XElement resultElement = rootElement.Element("Result");
            XAttribute statusAttribute = resultElement != null
                ? resultElement.Attribute("Status")
                : rootElement.Attribute("Status");

            if (statusAttribute == null || !statusAttribute.Value.Equals("1") || statusAttribute.Parent == null) return;

            XElement errorElement = statusAttribute.Parent.Element("Error");

            if (errorElement != null) throw new Exception(errorElement.Value);
        }

        /// <summary>
        ///     Gets the clean field value.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="rawValue">The raw value.</param>
        /// <param name="spField">The sp field.</param>
        /// <returns></returns>
        public static string GetCleanFieldValue(SPWeb spWeb, object rawValue, SPField spField, Boolean returnId)
        {
            if (rawValue == null || rawValue == DBNull.Value) return string.Empty;
            if (rawValue is string && string.IsNullOrEmpty((string)rawValue)) return string.Empty;

            string value;

            switch (spField.Type)
            {
                case SPFieldType.DateTime:
                case SPFieldType.Boolean:
                case SPFieldType.Lookup:
                case SPFieldType.User:
                    value = rawValue.ToString();
                    break;
                default:
                    value = spField.GetFieldValueForEdit(rawValue);
                    break;
            }

            if (spField.TypeAsString.Equals("PFERole"))
            {
                return value.Split(new[] { "#;" }, StringSplitOptions.None)[0];
            }

            switch (spField.Type)
            {
                case SPFieldType.DateTime:
                    if (rawValue is DateTime)
                    {
                        value = SPUtility.CreateISO8601DateTimeFromSystemDateTime((DateTime)rawValue);
                    }
                    break;
                case SPFieldType.User:
                    {
                        var spFieldUser = (SPFieldUser)spField;

                        if (spFieldUser.AllowMultipleValues)
                        {
                            var users = new List<string>();

                            SPFieldUserValueCollection spFieldUserValueCollection = null;

                            if (rawValue is string)
                            {
                                spFieldUserValueCollection = new SPFieldUserValueCollection(spWeb, (string)rawValue);
                            }
                            else if (rawValue is SPFieldUserValueCollection)
                            {
                                spFieldUserValueCollection = (SPFieldUserValueCollection)rawValue;
                            }

                            if (spFieldUserValueCollection != null)
                            {
                                users.AddRange(
                                    spFieldUserValueCollection.Select(
                                        spFieldUserValue => GetUserName(spWeb, spFieldUserValue)));

                                value = string.Join(",", users.ToArray());
                            }
                        }
                        else
                        {
                            var spFieldUserValue = new SPFieldUserValue(spWeb, (string)rawValue);

                            value = GetUserName(spWeb, spFieldUserValue);
                        }
                    }
                    break;
                case SPFieldType.Lookup:
                    {
                        var spFieldLookup = (SPFieldLookup)spField;

                        SPList spList = spWeb.Lists[new Guid(spFieldLookup.LookupList)];

                        if (spFieldLookup.AllowMultipleValues)
                        {
                            var fieldValue = (SPFieldLookupValueCollection)spField.GetFieldValue(rawValue.ToString());

                            if (fieldValue != null)
                            {
                                IEnumerable<int> lookupIds =
                                    fieldValue.Select(spFieldLookupValue => spFieldLookupValue.LookupId);

                                SPListItemCollection spListItemCollection = spList.Items;

                                if (returnId)
                                {
                                    IEnumerable<string> values = spListItemCollection.Cast<SPListItem>()
                                        .Where(spListItem => lookupIds.Contains((int)spListItem["ID"]))
                                        .Select(spListItem => spList.Fields.ContainsField("EXTID") ? Convert.ToString(spListItem["EXTID"]) : Convert.ToString(spListItem["Title"]));

                                    value = string.Join(",", values.ToArray());
                                }
                                else
                                {
                                    IEnumerable<string> values = spListItemCollection.Cast<SPListItem>()
                                        .Where(spListItem => lookupIds.Contains((int)spListItem["ID"]))
                                        .Select(spListItem => Convert.ToString(spListItem["Title"]));

                                    value = string.Join(",", values.ToArray());
                                }
                            }
                            else
                            {
                                value = string.Empty;
                            }
                        }
                        else
                        {
                            var fieldValue = (SPFieldLookupValue)spField.GetFieldValue(rawValue.ToString());

                            if (fieldValue != null)
                            {
                                SPListItemCollection spListItemCollection = spList.Items;

                                foreach (SPListItem spListItem in spListItemCollection.Cast<SPListItem>()
                                    .Where(spListItem => (int)spListItem["ID"] == fieldValue.LookupId))
                                {
                                    if (returnId)
                                    {
                                        if (spList.Fields.ContainsField("EXTID"))
                                        {
                                            value = Convert.ToString(spListItem["EXTID"]);
                                        }
                                        else
                                        {
                                            value = Convert.ToString(spListItem["Title"]);
                                        }
                                    }
                                    else
                                    {
                                        value = Convert.ToString(spListItem["Title"]);
                                    }
                                }
                            }
                            else
                            {
                                value = string.Empty;
                            }
                        }
                    }
                    break;
            }

            return value;
        }

        /// <summary>
        ///     Performs the delete resource check.
        /// </summary>
        /// <param name="extId">The ext id.</param>
        /// <param name="dataId">The data id.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="deleteResourceCheckStatus">The delete resource check status.</param>
        /// <param name="deleteResourceCheckMessage">The delete resource check message.</param>
        /// <returns></returns>
        public static bool PerformDeleteResourceCheck(int extId, Guid dataId, SPWeb spWeb,
            out string deleteResourceCheckStatus,
            out string deleteResourceCheckMessage)
        {
            deleteResourceCheckStatus = string.Empty;
            deleteResourceCheckMessage = string.Empty;

            XDocument responseXml;

            using (var resourceManager = new ResourceManager(spWeb))
            {
                responseXml = XDocument.Parse(resourceManager.DeleteResourceCheck(
                    string.Format(
                        @"<DeleteResourceCheck><Data><Resource Id=""{0}"" DataId=""{1}""/></Data></DeleteResourceCheck>",
                        extId, dataId)));
            }

            XElement rootElement = responseXml.Root;

            if (rootElement != null)
            {
                XAttribute statusAttribute = rootElement.Attribute("Status");

                if (statusAttribute != null && statusAttribute.Value.Equals("1"))
                {
                    XElement errorElement = rootElement.Element("Error");

                    if (errorElement != null) throw new Exception(errorElement.Value);
                    throw new Exception("No error element found.");
                }

                XElement dataElement = rootElement.Element("Data");

                if (dataElement != null)
                {
                    foreach (var deleteCheckResponse in from e in dataElement.Elements("Resource")
                                                        let dataIdAttribute = e.Attribute("DataId")
                                                        where
                                                            dataIdAttribute != null &&
                                                            dataIdAttribute.Value.Equals(dataId.ToString())
                                                        let canDeleteAttribute = e.Attribute("CanDelete")
                                                        where canDeleteAttribute != null
                                                        select
                                                            new { Status = canDeleteAttribute.Value, Message = e.Value })
                    {
                        deleteResourceCheckStatus = deleteCheckResponse.Status;
                        deleteResourceCheckMessage = deleteCheckResponse.Message;

                        return deleteResourceCheckStatus.Equals("YES");
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Writes the data table to file.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="outputFilePath">The output file path.</param>
        public static void WriteDataTableToFile(DataTable dt, string outputFilePath)
        {
            var maxLengths = new int[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                maxLengths[i] = dt.Columns[i].ColumnName.Length;

                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull(i))
                    {
                        int length = row[i].ToString().Length;

                        if (length > maxLengths[i])
                        {
                            maxLengths[i] = length;
                        }
                    }
                }
            }

            using (var sw = new StreamWriter(outputFilePath, true))
            {
                string line = string.Empty;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    line += new string('-', maxLengths[i] + 2) + "+";
                }

                sw.WriteLine(line);

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
                    sw.Write("|");
                }

                sw.WriteLine();

                sw.WriteLine(line);

                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sw.Write(!row.IsNull(i)
                            ? row[i].ToString().PadRight(maxLengths[i] + 2)
                            : new string(' ', maxLengths[i] + 2));
                        sw.Write("|");
                    }

                    sw.WriteLine();
                }

                sw.WriteLine(line);

                sw.Close();
            }
        }

        // Private Methods (5) 

        /// <summary>
        ///     Ares the equal objects.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        /// <param name="currentValue">The current value.</param>
        /// <param name="spField">The sp field.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        private static bool AreEqualObjects(object newValue, object currentValue, SPField spField, SPWeb spWeb)
        {
            return newValue == null
                ? currentValue == null
                : currentValue != null &&
                  GetCleanFieldValue(spWeb, newValue, spField, true)
                      .Equals(GetCleanFieldValue(spWeb, currentValue, spField, true));
        }

        /// <summary>
        ///     Gets the clean field value.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="dataRow">The data row.</param>
        /// <param name="rawValue">The raw value.</param>
        /// <returns></returns>
        private static string GetCleanFieldValue(SPWeb spWeb, DataRow dataRow, object rawValue, Boolean returnId)
        {
            return GetCleanFieldValue(spWeb, rawValue, (SPField)dataRow["Field"], returnId);
        }

        /// <summary>
        ///     Gets the name of the user.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="spFieldUserValue">The sp field user value.</param>
        /// <returns></returns>
        private static string GetUserName(SPWeb spWeb, SPFieldUserValue spFieldUserValue)
        {
            SPUser spUser = spFieldUserValue.User;

            return spUser != null
                ? CoreFunctions.GetUserNameWithDomain(
                    CoreFunctions.GetRealUserName(spUser.LoginName, spWeb.Site))
                : (spFieldUserValue.LookupId == -1
                    ? (!string.IsNullOrEmpty(spFieldUserValue.LookupValue)
                        ? CoreFunctions.GetUserNameWithDomain(spFieldUserValue.LookupValue)
                        : string.Empty)
                    : string.Empty);
        }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="internalName">Name of the internal.</param>
        /// <returns></returns>
        private static object GetValue(SPItemEventProperties properties, string internalName)
        {
            if (properties.AfterProperties[internalName] != null)
            {
                return properties.AfterProperties[internalName];
            }

            return properties.ListItem != null ? properties.ListItem[internalName] : null;
        }

        /// <summary>
        ///     Tries the get PFE field id.
        /// </summary>
        /// <param name="internalName">Name of the internal.</param>
        /// <param name="pfeResourceField">The pfe resource field.</param>
        /// <returns></returns>
        private static bool TryGetPFEFieldId(string internalName, out PFEResourceField pfeResourceField)
        {
            try
            {
                pfeResourceField = (PFEResourceField)Enum.Parse(typeof(PFEResourceField), internalName);
                return true;
            }
            catch
            {
                pfeResourceField = 0;
                return false;
            }
        }

        /// <summary>
        /// Check whether user has Edit Resource Permissions.
        /// </summary>
        /// <param name="web">Current Web</param>
        /// <param name="lWResID">Resource Id</param>
        /// <param name="hasPFEResourceCenterPermissions">Returns True, If user has 01-Resource Center checked under Portfolio Permissions. False, otherwise</param>
        /// <returns></returns>
        public static bool CheckPFEResourceCenterPermission(SPWeb web, int lWResID, bool hasDeletePermission, out bool hasPFEResourceCenterPermissions)
        {
            PortfolioEngineCore.DBAccess dba = null;
            try
            {
                hasPFEResourceCenterPermissions = true;
                string sBaseInfo = WebAdmin.BuildBaseInfo(System.Web.HttpContext.Current, web);
                PortfolioEngineCore.DataAccess da = new PortfolioEngineCore.DataAccess(sBaseInfo, PortfolioEngineCore.SecurityLevels.EditResources);
                dba = da.dba;
                if (dba.Open() == PortfolioEngineCore.StatusEnum.rsSuccess)
                {
                    if (hasDeletePermission)
                    {
                        if (PortfolioEngineCore.dbaGeneral.CheckUserGlobalPermission(dba, PortfolioEngineCore.GlobalPermissionsEnum.gpDBA) == false)
                            hasPFEResourceCenterPermissions = false;
                        else
                            hasPFEResourceCenterPermissions = true;
                    }
                    else
                    {
                        if (PortfolioEngineCore.dbaGeneral.CheckUserGlobalPermission(dba, PortfolioEngineCore.GlobalPermissionsEnum.gpCapCenter) == false)
                            hasPFEResourceCenterPermissions = false;
                        else
                            hasPFEResourceCenterPermissions = true;
                    }
                }
            }
            catch (PortfolioEngineCore.PFEException)
            {
                hasPFEResourceCenterPermissions = false;
            }
            return hasPFEResourceCenterPermissions;
        }

        #endregion Methods
    }
}