using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal sealed class ResourceGrid
    {
        #region Fields (1) 

        private const string ComponentName = "ResourceGrid";

        #endregion Fields 

        #region Enums (1) 

        internal enum Errors
        {
            GetResources = 15000,
            GetResourcePoolDataGrid,
            GetResourcePoolLayoutGrid,
            LayoutGridCNFRootElement,
            LayoutGridCNFLeftColsElement,
            LayoutGridCNFColElement,
            LayoutGridCNFHeaderElement,
            LayoutGridCNFColNameInCols,
            LayoutGridCNFColNameInLeftCols,
            GetResourcePoolViews,
            SaveResourcePoolViews,
            DeleteResourcePoolViews,
            UpdateResourcePoolViews,
            DeleteResourcePoolResource,
            DeleteResourceBadId,
            DeleteResourceInvalidId,
            DeleteResourceNoRootEle,
            DeleteResourceNoResourceEle,
            DeleteResourceNoIdAttr,
            DecodeGridData = 15900,
            ExtractViewsCNFRootElement,
            ExtractViewsCNFViewId,
            RegisterIdCssLayoutDataNull,
            RegisterIdCssCNFRootElement,
            RegisterIdCssCNFIdElement,
            RPGVMInitialize,
            GetResourcesRootElementNofFound,
            NotDeptManager,
            CantGetDepts,
            CantFindFieldAttr,
            CantFindIdAttr,
            CantFindResultRoot,
            GetResourcePoolDataGridChanges
        }

        #endregion Enums 

        #region Methods (16) 

        // Private Methods (7) 

        /// <summary>
        /// Builds the department hierarchy.
        /// </summary>
        /// <param name="dataRows">The data rows.</param>
        /// <param name="dataTable">The data table.</param>
        private static void BuildDepartmentHierarchy(IEnumerable<DataRow> dataRows, ref DataTable dataTable)
        {
            foreach (DataRow dataRow in dataRows)
            {
                DataRow currentRow = dataRow;

                List<DataRow> childRows = dataRow.GetChildRows("ParentChild").ToList();
                childRows.Remove(childRows.FirstOrDefault(childRow => childRow["Id"].Equals(currentRow["Id"])));

                DataRow row = dataTable.Select(String.Format("Id = '{0}'", dataRow["Id"])).First();
                var children = (List<string>) row["Children"];

                foreach (string child in childRows.Select(childRow => (string) childRow["Id"]).ToList()
                    .Where(child => !children.Contains(child)))
                {
                    children.Add(child);
                }

                if (childRows.Any())
                {
                    BuildDepartmentHierarchy(childRows, ref dataTable);
                }
            }
        }

        /// <summary>
        /// Builds the I element.
        /// </summary>
        /// <param name="gridFields">The grid fields.</param>
        /// <param name="resourcesList">The resources list.</param>
        /// <param name="gridSafeFields">The grid safe fields.</param>
        /// <param name="type">The type.</param>
        /// <param name="specialValues">The special values.</param>
        /// <param name="value">The value.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="field">The field.</param>
        /// <param name="iElement">The i element.</param>
        /// <param name="userInfoList">The user info list.</param>
        /// <param name="dataElement">The data element.</param>
        /// <param name="profilePic">The profile pic.</param>
        /// <param name="resourceId">The resource id.</param>
        private static void BuildIElement(Dictionary<string, SPField> gridFields, SPList resourcesList,
                                          Dictionary<string, string> gridSafeFields, string type,
                                          IEnumerable<string> specialValues, string value, SPWeb spWeb, string field,
                                          XElement iElement, SPList userInfoList, XElement dataElement,
                                          ref string profilePic, ref int resourceId)
        {
            if (field.Equals("ID"))
            {
                iElement.Add(new XAttribute("id", value));
            }
            else if (field.Equals("SharePointAccount"))
            {
                resourceId = new SPFieldUserValue(spWeb, dataElement.Value).LookupId;

                try
                {
                    SPListItem spListItem = userInfoList.GetItemById(resourceId);

                    var thumbnail = spListItem["Picture"] as string;

                    if (!string.IsNullOrEmpty(thumbnail))
                    {
                        profilePic = thumbnail.Remove(thumbnail.IndexOf(','));
                    }
                }
                catch
                {
                }
            }

            if (!gridSafeFields.ContainsKey(field))
            {
                gridSafeFields.Add(field, Utils.ToGridSafeFieldName(field));
            }

            string gridSafeFieldName = gridSafeFields[field];

            if (!gridFields.ContainsKey(field))
            {
                gridFields.Add(field, resourcesList.Fields.GetFieldByInternalName(field));
            }

            SPField gridField = gridFields[field];

            if (!string.IsNullOrEmpty(value))
            {
                if (type.Equals("DateTime"))
                {
                    value = DateTime.Parse(value).ToShortDateString();
                }
                else if (type.Equals("Currency"))
                {
                    value = dataElement.Value;
                }
                else if (type.Equals("Boolean"))
                {
                    value =
                        (bool.Parse(dataElement.Value) ? 1 : 0).ToString(CultureInfo.InvariantCulture);
                }
            }

            if (type.Equals("Choice"))
            {
                string enumKeys;
                string enumValues;
                int enumRange;

                Utils.GetGridEnum(spWeb.Site, gridField, out enumValues, out enumRange, out enumKeys);

                enumValues = enumValues ?? enumKeys;

                iElement.Add(new XAttribute(string.Format("{0}Enum", gridSafeFieldName),
                                            string.Format("|{0}", enumValues)));
                iElement.Add(new XAttribute(string.Format("{0}EnumKeys", gridSafeFieldName),
                                            string.Format("|{0}", enumKeys)));
                iElement.Add(new XAttribute(string.Format("{0}Range", gridSafeFieldName), enumRange));
            }

            iElement.Add(new XAttribute(gridSafeFieldName, value));

            foreach (string specialValue in specialValues)
            {
                if (type.Equals("DateTime") || type.Equals("Boolean"))
                {
                    iElement.Add(
                        new XAttribute(
                            string.Format("{0}.{1}", gridSafeFieldName, specialValue.First()),
                            value));
                }
                else
                {
                    iElement.Add(
                        new XAttribute(
                            string.Format("{0}.{1}", gridSafeFieldName, specialValue.First()),
                            dataElement.Attribute(specialValue).Value));
                }
            }
        }

        /// <summary>
        /// Confirms the delete.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        /// <param name="resourceManager">The resource manager.</param>
        private static void ConfirmDelete(int resourceId, ResourcePoolManager resourceManager)
        {
            resourceManager.Delete(resourceId);
        }

        /// <summary>
        /// Extracts the resource id.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="confirmDelete">if set to <c>true</c> [confirm delete].</param>
        /// <returns></returns>
        private static int ExtractResourceId(string data, out bool confirmDelete)
        {
            int resourceId;
            confirmDelete = false;

            XDocument dataXml = XDocument.Parse(data);

            XElement rootXml = dataXml.Root;
            if (rootXml == null)
            {
                throw new APIException((int) Errors.DeleteResourceNoRootEle,
                                       "Cannot find the DeleteResourcePoolResource element.");
            }

            XElement resourceElement = rootXml.Element("Resource");
            if (resourceElement == null)
            {
                throw new APIException((int) Errors.DeleteResourceNoResourceEle,
                                       @"Cannot find the DeleteResourcePoolResource\Resource element.");
            }

            XAttribute idAttribute = resourceElement.Attribute("Id");
            if (idAttribute == null)
            {
                throw new APIException((int) Errors.DeleteResourceNoIdAttr,
                                       @"Cannot find the DeleteResourcePoolResource\Resource Id attribute.");
            }

            string id = idAttribute.Value;
            if (!int.TryParse(id, out resourceId))
            {
                throw new APIException((int) Errors.DeleteResourceBadId,
                                       string.Format("{0} is not a valid Resource Pool Id.", id));
            }

            XAttribute confirmDeleteAttribute = resourceElement.Attribute("ConfirmDelete");
            if (confirmDeleteAttribute != null)
            {
                bool.TryParse(confirmDeleteAttribute.Value, out confirmDelete);
            }

            return resourceId;
        }

        /// <summary>
        /// Filters the department resources.
        /// </summary>
        /// <param name="resultXml">The result XML.</param>
        private static void FilterDepartmentResources(ref XDocument resultXml)
        {
            bool filteringEnabled;

            bool.TryParse(CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLiveRBSSecurity"),
                          out filteringEnabled);

            if (!filteringEnabled) return;

            XDocument departmentsXml;

            using (var departmentManager = new DepartmentManager())
            {
                departmentsXml = departmentManager.GetAll();
            }

            var dataTable = new DataTable("Managers");

            dataTable.Columns.Add("Id", typeof (string));
            dataTable.Columns.Add("ParentId", typeof (string));
            dataTable.Columns.Add("Managers", typeof (object));
            dataTable.Columns.Add("Children", typeof (List<string>));

            if (departmentsXml.Root == null)
            {
                throw new APIException((int) Errors.CantGetDepts, "Unable to query departments.");
            }

            foreach (XElement departmentElement in departmentsXml.Root.Elements("Department"))
            {
                string id = null;
                string parent = null;
                var managers = new List<string>();

                foreach (XElement dataElement in departmentElement.Elements())
                {
                    XAttribute fieldAttribute = dataElement.Attribute("Field");

                    if (fieldAttribute == null)
                    {
                        throw new APIException((int) Errors.CantFindFieldAttr, "The Field attribute was not found.");
                    }

                    switch (fieldAttribute.Value)
                    {
                        case "Title":
                            XAttribute idAttribute = departmentElement.Attribute("ID");

                            if (idAttribute == null)
                            {
                                throw new APIException((int) Errors.CantFindIdAttr, "ID attribute was not found.");
                            }

                            id = string.Format("{0};#{1}", idAttribute.Value, dataElement.Value);
                            break;
                        case "RBS":
                            parent = dataElement.Value;
                            break;
                        case "Managers":
                        case "Executives":
                            foreach (string manager in ParseResources(dataElement.Value)
                                .Where(manager => !managers.Contains(manager)))
                            {
                                managers.Add(manager);
                            }
                            break;
                    }
                }

                if (string.IsNullOrEmpty(parent)) parent = id;

                dataTable.Rows.Add(id, parent, managers, new List<string>());
            }

            var dataSet = new DataSet();

            dataSet.Tables.Add(dataTable);
            DataTable dsTable = dataSet.Tables["Managers"];

            dataSet.Relations.Add("ParentChild", dsTable.Columns["Id"], dsTable.Columns["ParentId"]);

            BuildDepartmentHierarchy(dsTable.Select("ParentId = Id"), ref dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                dataRow["Managers"] = string.Join(",", ((List<string>) dataRow["Managers"]).ToArray());

                var children = ((List<string>) dataRow["Children"]);
                children.Add((string) dataRow["Id"]);
            }

            SPUser currentUser = SPContext.Current.Web.CurrentUser;
            string username = string.Format("{0};#{1}", currentUser.ID, currentUser.Name);

            var departments = new List<string>();
            foreach (
                string department in
                    from dataRow in dataTable.Select(string.Format("Managers LIKE '%{0}%'", username))
                    from department in ((List<string>) dataRow["Children"])
                    where !departments.Contains(department)
                    select department)
            {
                departments.Add(department);
            }

            if (!departments.Any())
            {
                throw new APIException((int) Errors.NotDeptManager,
                                       string.Format("{0} is not a manager of any department.",
                                                     currentUser.LoginName));
            }

            var resourcesToBeRemoved = new List<XElement>();

            if (resultXml.Root == null)
            {
                throw new APIException((int) Errors.CantFindResultRoot, "The Resources Root element was not found.");
            }

            foreach (XElement resourceElement in resultXml.Root.Elements())
            {
                bool validDepartment = false;

                foreach (XElement dataElement in resourceElement.Elements()
                    .Where(dataElement =>
                               {
                                   XAttribute fieldAttribute = dataElement.Attribute("Field");
                                   return fieldAttribute != null && fieldAttribute.Value.Equals("Department");
                               }))
                {
                    if (departments.Contains(dataElement.Value)) validDepartment = true;

                    break;
                }

                if (!validDepartment) resourcesToBeRemoved.Add(resourceElement);
            }

            foreach (XElement resourceElement in resourcesToBeRemoved)
            {
                resourceElement.Remove();
            }
        }

        /// <summary>
        /// Parses the resources.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static IEnumerable<string> ParseResources(string value)
        {
            var resources = new List<string>();

            string[] list = value.Replace(";#", ";").Split(';');

            for (int i = 0; i < list.Count() - 1; i++)
            {
                string resource = string.Format("{0};#{1}", list[i], list[++i]);
                if (!resources.Contains(resource)) resources.Add(resource);
            }

            return resources;
        }

        /// <summary>
        /// Registers the grid id and CSS.
        /// </summary>
        /// <param name="resultRootElement">The result root element.</param>
        /// <param name="dataXml">The data XML.</param>
        private static void RegisterGridIdAndCss(XElement resultRootElement, XDocument dataXml)
        {
            if (dataXml == null)
            {
                throw new APIException((int) Errors.RegisterIdCssLayoutDataNull, "Layout data cannot be null.");
            }

            if (dataXml.Root == null)
            {
                throw new APIException((int) Errors.RegisterIdCssCNFRootElement,
                                       "Cannot find the Root element of the layout data.");
            }

            XElement idElement = dataXml.Root.Element("Id");
            if (idElement == null)
            {
                throw new APIException((int) Errors.RegisterIdCssCNFIdElement,
                                       "Cannot find the Id element of the layout data.");
            }

            var cfgElement = new XElement("Cfg");
            cfgElement.Add(new XAttribute("id", idElement.Value));

            cfgElement.Add(new XAttribute("CSS",
                                          string.Format("{0}/_layouts/epmlive/treegrid/resourcegrid/grid.css",
                                                        SPContext.Current.Web.SafeServerRelativeUrl())),
                           new XAttribute("Style", "GS"));

            resultRootElement.Add(cfgElement);
        }

        // Internal Methods (9) 

        /// <summary>
        /// Deletes the resource pool resource.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string DeleteResourcePoolResource(string data)
        {
            try
            {
                bool confirmDelete;
                int resourceId = ExtractResourceId(data, out confirmDelete);

                var resourceElement = new XElement("Resource", new XAttribute("Id", resourceId));

                using (var resourceManager = new ResourcePoolManager())
                {
                    if (!resourceManager.ItemExists(resourceId))
                    {
                        throw new APIException((int) Errors.DeleteResourceInvalidId,
                                               string.Format("{0} is not a valid Resource Pool Id.", resourceId));
                    }

                    try
                    {
                        // this might seem strange, but we need this as we check from where 
                        // the "Delete" is being executed in the ItemDeleting event.

                        if (confirmDelete)
                        {
                            ConfirmDelete(resourceId, resourceManager);
                        }
                        else
                        {
                            resourceManager.Delete(resourceId);
                        }

                        resourceElement.Add(new XAttribute("Status", 0));
                    }
                    catch (Exception exception)
                    {
                        if (exception.Message.Contains("|||"))
                        {
                            string[] message = exception.Message.Split(new[] {"|||"}, StringSplitOptions.None);

                            resourceElement.Add(new XAttribute("Status", message[0].Equals("NO") ? 1 : 2),
                                                new XCData(message[1]));
                        }
                    }
                }

                return new XElement("DeleteResourcePoolResource", resourceElement).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.DeleteResourcePoolResource, e.Message);
            }
        }

        /// <summary>
        /// Deletes the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string DeleteResourcePoolViews(string data)
        {
            try
            {
                using (var gridViewFactory = new GridViewManagerFactory())
                {
                    foreach (GridView gridView in GridViewUtils.ExtractViews(data))
                    {
                        using (
                            IGridViewManager gridViewManager = gridViewFactory.MakeGridViewManager(ComponentName,
                                                                                                   gridView))
                        {
                            gridViewManager.Remove(gridView);
                        }
                    }
                }

                return "<ResourcePoolViews/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.DeleteResourcePoolViews, e.Message);
            }
        }

        /// <summary>
        /// Gets the resource pool data grid.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetResourcePoolDataGrid(string data)
        {
            try
            {
                using (var resourceManager = new ResourcePoolManager())
                {
                    SPList resourcesList = resourceManager.ParentList;
                    SPWeb spWeb = resourcesList.ParentWeb;
                    SPSite spSite = spWeb.Site;

                    SPList userInfoList = spSite.RootWeb.SiteUserInfoList;

                    XDocument resourceXml =
                        XDocument.Parse(GetResources(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data))));

                    var resultXml = new XDocument();
                    resultXml.Add(new XElement("Grid"));

                    // ReSharper disable PossibleNullReferenceException

                    XElement gridElement = resultXml.Root;

                    gridElement.Add(new XElement("Body"));
                    XElement bodyElement = gridElement.Element("Body");

                    bodyElement.Add(new XElement("B"));

                    XElement bElement = bodyElement.Element("B");

                    var gridSafeFields = new Dictionary<string, string>();
                    var gridFields = new Dictionary<string, SPField>();

                    var specialValues = new[] {"TextValue", "HtmlValue", "EditValue"};

                    IEnumerable<XElement> resourceElements = resourceXml.Root.Elements("Resource");

                    foreach (XElement resourceElement in resourceElements)
                    {
                        var iElement = new XElement("I");

                        int resourceId = 0;
                        string profilePic = string.Format("{0}/_layouts/images/person.gif", spWeb.SafeServerRelativeUrl());

                        foreach (XElement dataElement in resourceElement.Elements())
                        {
                            string field = dataElement.Attribute("Field").Value;
                            string value = dataElement.Attribute("HtmlValue").Value;
                            string type = dataElement.Attribute("Type").Value;

                            BuildIElement(gridFields, resourcesList, gridSafeFields, type, specialValues, value,
                                          spWeb, field, iElement, userInfoList, dataElement, ref profilePic,
                                          ref resourceId);
                        }

                        iElement.Add(new XAttribute("ResourceID", resourceId));
                        iElement.Add(new XAttribute("ProfilePic",
                                                    string.Format(
                                                        @"<div style=""width:100%;height:50px;text-align:center;padding-top:2.5px;padding-bottom:2.5px;"">
                                                              <img src=""{0}"" height=""50""/>
                                                          </div>",
                                                        profilePic)));

                        bElement.Add(iElement);
                    }

                    // ReSharper restore PossibleNullReferenceException

                    return resultXml.ToString();
                }
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetResourcePoolDataGrid, e.Message);
            }
        }

        /// <summary>
        /// Gets the resource pool data grid changes.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        internal static string GetResourcePoolDataGridChanges(string data, SPWeb spWeb)
        {
            try
            {
                XDocument requestXml = XDocument.Parse(data);

                // ReSharper disable PossibleNullReferenceException

                XElement paramsElement = requestXml.Root.Element("Params");

                string changeType = paramsElement.Element("ChangeType").Value;
                string[] ids = paramsElement.Element("Rows").Value.Split(',');

                // ReSharper restore PossibleNullReferenceException

                var changesXml = new XElement("Changes");

                SPList resourcesList = spWeb.Lists["Resources"];
                SPList userInfoList = spWeb.Site.RootWeb.SiteUserInfoList;

                var spListItems = new List<SPListItem>();

                if (changeType.Equals("Added"))
                {
                    SPListItemCollection spListItemCollection = resourcesList.Items;
                    spListItems.AddRange(
                        spListItemCollection.Cast<SPListItem>().Where(
                            i => !ids.Contains(i.ID.ToString(CultureInfo.InvariantCulture))));
                }
                else if (changeType.Equals("Deleted"))
                {
                    foreach (string id in ids)
                    {
                        int itemId;
                        if (!int.TryParse(id, out itemId)) continue;

                        try
                        {
                            resourcesList.GetItemById(itemId);
                        }
                        catch
                        {
                            changesXml.Add(new XElement("I", new XAttribute("id", id), new XAttribute(changeType, 1)));
                        }
                    }
                }
                else
                {
                    foreach (string id in ids)
                    {
                        int itemId;
                        if (!int.TryParse(id, out itemId)) continue;

                        SPListItem spListItem = resourcesList.GetItemById(itemId);

                        spListItems.Add(spListItem);
                    }
                }

                var gridSafeFields = new Dictionary<string, string>();
                var gridFields = new Dictionary<string, SPField>();

                var specialValues = new[] {"TextValue", "HtmlValue", "EditValue"};

                foreach (SPListItem spListItem in spListItems)
                {
                    var iElement = new XElement("I", new XAttribute(changeType, 1));

                    int resourceId = 0;
                    string profilePic = string.Format("{0}/_layouts/images/person.gif", spWeb.SafeServerRelativeUrl());

                    foreach (SPField spField in spListItem.Fields)
                    {
                        if (spField.Hidden) continue;

                        try
                        {
                            object val = spListItem[spField.Id];

                            string field = spField.InternalName;
                            string value = spField.GetFieldValueAsHtml(val);
                            string type = spField.Type.ToString();

                            string rawValue = (val as string) ?? string.Empty;

                            var dataElement = new XElement("Data", new XCData(rawValue),
                                                           new XAttribute("TextValue", spField.GetFieldValueAsText(val)),
                                                           new XAttribute("HtmlValue", value),
                                                           new XAttribute("EditValue", spField.GetFieldValueForEdit(val)));

                            BuildIElement(gridFields, resourcesList, gridSafeFields, type, specialValues, value,
                                          spWeb, field, iElement, userInfoList, dataElement, ref profilePic,
                                          ref resourceId);
                        }
                        catch
                        {
                        }
                    }

                    iElement.Add(new XAttribute("ResourceID", resourceId));
                    iElement.Add(new XAttribute("ProfilePic",
                                                string.Format(
                                                    @"<div style=""width:100%;height:50px;text-align:center;padding-top:2.5px;padding-bottom:2.5px;"">
                                                              <img src=""{0}"" height=""50""/>
                                                          </div>",
                                                    profilePic)));

                    changesXml.Add(iElement);
                }

                return new XElement("ResourcePoolDataGridChanges",
                                    new XElement("Data", new XCData(
                                                             new XElement("Grid", changesXml).ToString()))).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetResourcePoolDataGridChanges, e.Message);
            }
        }

        /// <summary>
        /// Gets the resource pool layout grid.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetResourcePoolLayoutGrid(string data)
        {
            try
            {
                XDocument dataXml = XDocument.Parse(Utilities.DecodeGridData(data));

                XDocument resultXml = XDocument.Parse(Resources.ResourceGridLayout);
                XElement resultRootElement = resultXml.Root;

                if (resultRootElement == null)
                {
                    throw new APIException((int) Errors.LayoutGridCNFRootElement,
                                           "Cannot find the Root element of the grid layout.");
                }

                RegisterGridIdAndCss(resultRootElement, dataXml);

                XElement leftColsElement = resultRootElement.Element("LeftCols");

                if (leftColsElement == null)
                {
                    throw new APIException((int) Errors.LayoutGridCNFLeftColsElement,
                                           "Cannot find the LeftCols element of the grid layout.");
                }

                XElement colsElement = resultRootElement.Element("Cols");

                if (colsElement == null)
                {
                    throw new APIException((int) Errors.LayoutGridCNFColElement,
                                           "Cannot find the Col element of the grid layout.");
                }

                XElement headerElement = resultRootElement.Element("Header");

                if (headerElement == null)
                {
                    throw new APIException((int) Errors.LayoutGridCNFHeaderElement,
                                           "Cannot find the Header element of the grid layout.");
                }

                var existingCols = new List<string>();

                foreach (XAttribute colName in colsElement.Elements().Select(colElement => colElement.Attribute("Name"))
                    )
                {
                    if (colName == null)
                    {
                        throw new APIException((int) Errors.LayoutGridCNFColNameInCols,
                                               "Cannot find the column name in the grid layout.");
                    }

                    existingCols.Add(colName.Value);
                }

                foreach (
                    XAttribute colName in leftColsElement.Elements().Select(colElement => colElement.Attribute("Name")))
                {
                    if (colName == null)
                    {
                        throw new APIException((int) Errors.LayoutGridCNFColNameInLeftCols,
                                               "Cannot find the column name in the grid layout.");
                    }

                    existingCols.Add(colName.Value);
                }

                using (var resourceManager = new ResourcePoolManager())
                {
                    SPWeb spWeb = SPContext.Current.Web;
                    SPRegionalSettings spRegionalSettings = spWeb.CurrentUser.RegionalSettings ??
                                                            spWeb.Site.RootWeb.RegionalSettings;

                    var cultureInfo = new CultureInfo((int) spRegionalSettings.LocaleId);

                    string currencyFormat = string.Format("{0}#.00", cultureInfo.NumberFormat.CurrencySymbol);
                    string shortDatePattern = cultureInfo.DateTimeFormat.ShortDatePattern;

                    SPList resourcesList = resourceManager.ParentList;

                    foreach (SPField spField in resourcesList.Fields)
                    {
                        if (spField.Hidden && !spField.InternalName.Equals("EXTID")) continue;

                        string internalName = spField.InternalName;

                        if (existingCols.Contains(internalName)) continue;

                        string relatedGridType = Utils.GetRelatedGridTypeForReadOnly(spField);
                        string format = Utils.GetFormat(spField);

                        var cElement = new XElement("C");

                        string gridSafeFieldName = Utils.ToGridSafeFieldName(internalName);

                        cElement.Add(new XAttribute("Name", gridSafeFieldName));
                        cElement.Add(new XAttribute("Type", relatedGridType));

                        if (relatedGridType.Equals("Icon"))
                        {
                            cElement.Add(new XAttribute("IconAlign", "Center"));
                        }

                        if (spField.Type == SPFieldType.Currency)
                        {
                            cElement.Add(new XAttribute("Format", currencyFormat));
                        }
                        else if (relatedGridType.Equals("Date"))
                        {
                            cElement.Add(new XAttribute("Format", shortDatePattern));
                        }
                        else if (!string.IsNullOrEmpty(format))
                        {
                            cElement.Add(new XAttribute("Format", format));
                        }

                        cElement.Add(new XAttribute("Visible", 0), new XAttribute("ReadOnly", spField.ReadOnlyField));

                        if (spField.InternalName.Equals("EXTID"))
                        {
                            cElement.Add(new XAttribute("CanFilter", 0), new XAttribute("CanGroup", 0),
                                         new XAttribute("CanHide", 0));
                        }

                        colsElement.Add(cElement);

                        headerElement.Add(new XAttribute(gridSafeFieldName, spField.Title));
                    }

                    return resultXml.ToString();
                }
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetResourcePoolLayoutGrid, e.Message);
            }
        }

        /// <summary>
        /// Gets the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetResourcePoolViews(string data)
        {
            try
            {
                var viewsXml = new XElement("Views");

                using (var gridViewManagerFactory = new GridViewManagerFactory())
                {
                    foreach (
                        GridViewManagerKind gridViewManagerKind in
                            new[] {GridViewManagerKind.Global, GridViewManagerKind.Personal})
                    {
                        using (
                            IGridViewManager gridViewManager = gridViewManagerFactory.MakeGridViewManager(
                                ComponentName, gridViewManagerKind))
                        {
                            gridViewManager.Initialize();

                            foreach (GridView gridView in gridViewManager.List)
                            {
                                viewsXml.Add(XDocument.Parse(gridView.Definition).Root);
                            }
                        }
                    }
                }

                return new XElement("ResourcePoolViews", viewsXml).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetResourcePoolViews, e.Message);
            }
        }

        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetResources(string data)
        {
            try
            {
                XDocument resultXml;

                using (var resourceManager = new ResourcePoolManager())
                {
                    bool includeHidden = false;
                    bool includeReadOnly = false;

                    if (!string.IsNullOrEmpty(data))
                    {
                        XDocument dataDocument = XDocument.Parse(data);

                        XElement rootElement = dataDocument.Root;
                        if (rootElement == null)
                        {
                            throw new APIException((int) Errors.GetResourcesRootElementNofFound,
                                                   @"The ""Root"" element is not specified.");
                        }

                        XElement includeHiddenElement = rootElement.Element("IncludeHidden");
                        if (includeHiddenElement != null)
                        {
                            includeHidden = bool.Parse(includeHiddenElement.Value);
                        }

                        XElement includeReadOnlyElement = rootElement.Element("IncludeReadOnly");
                        if (includeReadOnlyElement != null)
                        {
                            includeReadOnly = bool.Parse(includeReadOnlyElement.Value);
                        }
                    }

                    resultXml = resourceManager.GetAll(includeHidden, includeReadOnly);
                }

                FilterDepartmentResources(ref resultXml);

                return resultXml.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetResources, e.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Saves the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string SaveResourcePoolViews(string data)
        {
            try
            {
                using (var gridViewManagerFactory = new GridViewManagerFactory())
                {
                    foreach (GridView gridView in GridViewUtils.ExtractViews(data))
                    {
                        using (
                            IGridViewManager gridViewManager = gridViewManagerFactory.MakeGridViewManager(
                                ComponentName, gridView))
                        {
                            if (gridView.Id.Equals("dv"))
                            {
                                gridView.Version = Convert.ToInt32(Resources.ResourceGridDefaultGlobalViewVersion);
                            }

                            gridViewManager.Add(gridView);
                        }
                    }
                }

                return "<ResourcePoolViews/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.SaveResourcePoolViews, e.Message);
            }
        }

        /// <summary>
        /// Updates the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string UpdateResourcePoolViews(string data)
        {
            try
            {
                using (var gridViewManagerFactory = new GridViewManagerFactory())
                {
                    foreach (GridView gridView in GridViewUtils.ExtractViews(data))
                    {
                        using (
                            IGridViewManager gridViewManager = gridViewManagerFactory.MakeGridViewManager(
                                ComponentName, gridView))
                        {
                            gridViewManager.Update(gridView);
                        }
                    }
                }

                return "<ResourcePoolViews/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.UpdateResourcePoolViews, e.Message);
            }
        }

        #endregion Methods 
    }
}