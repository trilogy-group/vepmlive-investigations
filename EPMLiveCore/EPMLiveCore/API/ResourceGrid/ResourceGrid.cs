using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace EPMLiveCore.API
{
    public sealed class ResourceGrid
    {
        #region Fields (2)

        private const string COMPONENT_NAME = "ResourceGrid";
        private static readonly Dictionary<string, string> _resourceDictionary = new Dictionary<string, string>();

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
            GetResourcePoolDataGridChanges,
            ExportResources
        }

        #endregion Enums

        #region Methods (22)

        // Public Methods (1) 

        public static void ClearCache(SPWeb spWeb)
        {
            CacheStore.Current.RemoveSafely(spWeb.Url, new CacheStoreCategory(spWeb).ResourceGrid);
        }

        // Private Methods (11) 

        /// <summary>
        ///     Builds the department hierarchy.
        /// </summary>
        /// <param name="dataRows">The data rows.</param>
        /// <param name="dataTable">The data table.</param>
        private static void BuildDepartmentHierarchy(IEnumerable<DataRow> dataRows, ref DataTable dataTable)
        {
            foreach (DataRow dataRow in dataRows)
            {
                DataRow currentRow = dataRow;

                List<DataRow> childRows = dataRow.GetChildRows("ParentChild").ToList();
                childRows.Remove(childRows.FirstOrDefault(childRow => childRow["IdClean"].Equals(currentRow["IdClean"])));

                DataRow row = dataTable.Select(String.Format("IdClean = '{0}'", dataRow["IdClean"])).First();
                var children = (List<string>)row["Children"];

                foreach (string child in childRows.Select(childRow => (string)childRow["Id"]).ToList()
                    .Where(child => !children.Contains(child)))
                {
                    children.Add(child);

                    DataRow[] parents = dataTable.Select(string.Format("IdClean = '{0}'", dataRow["ParentIdClean"]));
                    if (!parents.Any()) continue;

                    var siblings = (List<string>)parents[0]["Children"];
                    if (!siblings.Contains(child))
                    {
                        siblings.Add(child);
                    }
                }

                if (childRows.Any())
                {
                    BuildDepartmentHierarchy(childRows, ref dataTable);
                }
            }
        }

        /// <summary>
        ///     Builds the I element.
        /// </summary>
        /// <param name="gridFields">The grid fields.</param>
        /// <param name="resourcesList">The resources list.</param>
        /// <param name="gridSafeFields">The grid safe fields.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="field">The field.</param>
        /// <param name="iElement">The i element.</param>
        /// <param name="dtUserInfo">The dt user info.</param>
        /// <param name="dataElement">The data element.</param>
        /// <param name="profilePic">The profile pic.</param>
        /// <param name="resourceId">The resource id.</param>
        private static void BuildIElement(Dictionary<string, SPField> gridFields, SPList resourcesList,
            Dictionary<string, string> gridSafeFields, string type,
            string value, SPWeb spWeb, string field,
            XElement iElement, DataTable dtUserInfo, XElement dataElement,
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
                    DataRow dataRow = dtUserInfo.Rows.Find(resourceId);

                    var thumbnail = dataRow["Picture"] as string;

                    if (!string.IsNullOrEmpty(thumbnail))
                    {
                        profilePic = thumbnail.Remove(thumbnail.IndexOf(','));
                    }
                }
                catch { }
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
                    value = (dataElement.Value.ToBool() ? 1 : 0).ToString(CultureInfo.InvariantCulture);
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

            if (type.Equals("Lookup"))
            {
                var sVal = string.Empty;
                try
                {
                    sVal = new SPFieldLookupValue(dataElement.Value).LookupId.ToString();
                    if (sVal == "0")
                    {
                        sVal = "";
                    }
                }
                catch { }

                value = sVal;
            }

            iElement.Add(new XAttribute(gridSafeFieldName, value));
        }

        /// <summary>
        ///     Confirms the delete.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        /// <param name="resourceManager">The resource manager.</param>
        private static void ConfirmDelete(int resourceId, ResourcePoolManager resourceManager)
        {
            resourceManager.Delete(resourceId);
        }

        /// <summary>
        ///     Extracts the resource id.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="confirmDelete">
        ///     if set to <c>true</c> [confirm delete].
        /// </param>
        /// <returns></returns>
        private static int ExtractResourceId(string data, out bool confirmDelete)
        {
            int resourceId;
            confirmDelete = false;

            XDocument dataXml = XDocument.Parse(data);

            XElement rootXml = dataXml.Root;
            if (rootXml == null)
            {
                throw new APIException((int)Errors.DeleteResourceNoRootEle,
                    "Cannot find the DeleteResourcePoolResource element.");
            }

            XElement resourceElement = rootXml.Element("Resource");
            if (resourceElement == null)
            {
                throw new APIException((int)Errors.DeleteResourceNoResourceEle,
                    @"Cannot find the DeleteResourcePoolResource\Resource element.");
            }

            XAttribute idAttribute = resourceElement.Attribute("Id");
            if (idAttribute == null)
            {
                throw new APIException((int)Errors.DeleteResourceNoIdAttr,
                    @"Cannot find the DeleteResourcePoolResource\Resource Id attribute.");
            }

            string id = idAttribute.Value;
            if (!int.TryParse(id, out resourceId))
            {
                throw new APIException((int)Errors.DeleteResourceBadId,
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
        ///     Filters the department resources.
        /// </summary>
        /// <param name="resultXml">The result XML.</param>
        private static void FilterDepartmentResources(ref XDocument resultXml)
        {
            XDocument departmentsXml;

            using (var departmentManager = new DepartmentManager(SPContext.Current.Site.RootWeb))
            {
                departmentsXml = departmentManager.GetAll();
            }

            var dataTable = new DataTable("Managers");

            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("IdClean", typeof(string));
            dataTable.Columns.Add("ParentId", typeof(string));
            dataTable.Columns.Add("ParentIdClean", typeof(string));
            dataTable.Columns.Add("Managers", typeof(object));
            dataTable.Columns.Add("Children", typeof(List<string>));

            if (departmentsXml.Root == null)
            {
                throw new APIException((int)Errors.CantGetDepts, "Unable to query departments.");
            }

            foreach (XElement departmentElement in departmentsXml.Root.Elements("Department"))
            {
                string id = null;
                string idClean = null;
                string parent = null;
                var managers = new List<string>();

                foreach (XElement dataElement in departmentElement.Elements())
                {
                    XAttribute fieldAttribute = dataElement.Attribute("Field");

                    if (fieldAttribute == null)
                    {
                        throw new APIException((int)Errors.CantFindFieldAttr, "The Field attribute was not found.");
                    }

                    switch (fieldAttribute.Value)
                    {
                        case "Title":
                            XAttribute idAttribute = departmentElement.Attribute("ID");

                            if (idAttribute == null)
                            {
                                throw new APIException((int)Errors.CantFindIdAttr, "ID attribute was not found.");
                            }

                            idClean = idAttribute.Value;
                            id = string.Format("{0};#{1}", idClean, dataElement.Value);
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

                if (string.IsNullOrEmpty(parent))
                {
                    parent = id;
                }
                else if (parent.Equals("0;#"))
                {
                    parent = id;
                }

                dataTable.Rows.Add(id, idClean, parent, parent.Split(';')[0], managers, new List<string>());
            }

            var dataSet = new DataSet();

            dataSet.Tables.Add(dataTable);
            DataTable dsTable = dataSet.Tables["Managers"];

            dataSet.Relations.Add("ParentChild", dsTable.Columns["IdClean"], dsTable.Columns["ParentIdClean"]);

            BuildDepartmentHierarchy(dsTable.Select("ParentIdClean = IdClean"), ref dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                dataRow["Managers"] = string.Join(",", ((List<string>)dataRow["Managers"]).ToArray());

                var children = ((List<string>)dataRow["Children"]);
                children.Add((string)dataRow["Id"]);
            }

            SPUser currentUser = SPContext.Current.Web.CurrentUser;
            string username = string.Format("{0};#{1}", currentUser.ID, currentUser.Name);

            var departments = new List<string>();

            foreach (string department in dataTable.Select(string.Format("Managers LIKE '%{0}%'", username))
                .SelectMany(dataRow => ((List<string>)dataRow["Children"]),
                    (dataRow, department) => department.Split(';')[0])
                .Where(department => !departments.Contains(department)))
            {
                departments.Add(department);
            }

            if (resultXml.Root == null)
            {
                throw new APIException((int)Errors.CantFindResultRoot, "The Resources Root element was not found.");
            }

            foreach (XElement resourceElement in resultXml.Root.Elements())
            {
                bool validDepartment = false;

                foreach (XElement dataElement in resourceElement.Elements()
                    .Where(dataElement =>
                    {
                        XAttribute a = dataElement.Attribute("Field");
                        return a != null && a.Value.Equals("Department");
                    }))
                {
                    if (departments.Contains((dataElement.Value).Split(';')[0])) validDepartment = true;
                    break;
                }

                resourceElement.Add(new XAttribute("IsMyResource", validDepartment));
            }
        }

        private static string GetCacheKey(SPWeb web, string kind)
        {
            return "ResourceGrid_" + kind + "_W_" + web.ID + "_U_" + web.CurrentUser.ID;
        }


        private static string GetDataGrid(string data, SPWeb web)
        {
            using (var resourceManager = new ResourcePoolManager(SPContext.Current.Site.RootWeb))
            {
                SPList resourcesList = resourceManager.ParentList;


                while (web.Features[WEFeatures.BuildTeam.Id] == null) //Inherit | Open
                {
                    if (web.IsRootWeb)
                        break;
                    web = web.ParentWeb;
                }

                Guid webId = Guid.Empty;
                Guid listid = Guid.Empty;
                int itemid = 0;
                XmlDocument docQuery = new XmlDocument();
                docQuery.LoadXml(data);

                try
                {
                    webId = new Guid(docQuery.FirstChild.Attributes["WebId"].Value);
                }
                catch { }

                try
                {
                    listid = new Guid(docQuery.FirstChild.Attributes["ListId"].Value);
                }
                catch { }
                try
                {
                    itemid = int.Parse(docQuery.FirstChild.Attributes["ItemId"].Value);
                }
                catch { }

                XDocument resourceXml =
                  XDocument.Parse(GetResources(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data)), SPContext.Current.Site.RootWeb));

                XDocument resourceTeam = new XDocument();
                if (web.IsRootWeb && listid == Guid.Empty && itemid == 0)
                {
                    resourceTeam = resourceXml;
                }
                else
                {
                    XDocument teamXml = XDocument.Parse(APITeam.GetTeam(data, web));
                    XElement res = new XElement("Resources");
                    foreach (XElement ele in teamXml.Root.Elements("Member"))
                    {
                        XElement element = resourceXml.Root.Elements("Resource").FirstOrDefault(r => r.Attribute("ID").Value == ele.Attribute("ID").Value);
                        if (element != null)
                        {
                            res.Add(element);
                        }
                    }
                    resourceTeam.Add(res);
                }

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

                IEnumerable<XElement> resourceElements = resourceTeam.Root.Elements("Resource");

                var dtUserInfo = new DataTable();

                XElement[] arrResourceElements = resourceElements as XElement[] ?? resourceElements.ToArray();
                if (arrResourceElements.Any())
                {
                    dtUserInfo = web.Site.RootWeb.SiteUserInfoList.Items.GetDataTable();
                    dtUserInfo.PrimaryKey = new[] { dtUserInfo.Columns["ID"] };
                }

                foreach (XElement resourceElement in arrResourceElements)
                {
                    var iElement = new XElement("I");

                    int resourceId = 0;
                    string profilePic = string.Format("{0}/_layouts/15/epmlive/images/default-avatar.png",
                        web.SafeServerRelativeUrl());

                    foreach (XElement dataElement in resourceElement.Elements())
                    {
                        string field = dataElement.Attribute("Field").Value;

                        if (field.Equals("LinkTitle") || field.Equals("LinkTitleNoMenu")) continue;

                        string value = dataElement.Attribute("HtmlValue").Value;
                        string type = dataElement.Attribute("Type").Value;

                        BuildIElement(gridFields, resourcesList, gridSafeFields, type, value,
                            web, field, iElement, dtUserInfo, dataElement, ref profilePic,
                            ref resourceId);
                    }

                    iElement.Add(new XAttribute("ResourceID", resourceId));
                    iElement.Add(new XAttribute("ProfilePic",
                        string.Format(
                            @"<div class=""EPMLiveResourceGridPicture"">
															  <img src=""{0}"" height=""20""/>
														  </div>",
                            profilePic)));

                    iElement.Add(new XAttribute("IsMyResource",
                        resourceElement.Attribute("IsMyResource").Value.ToBool() ? 1 : 0));

                    iElement.Add(new XAttribute("itemid", resourceElement.Attribute("ID").Value));
                    iElement.Add(new XAttribute("listid", resourcesList.ID));
                    iElement.Add(new XAttribute("webid", web.ID));
                    iElement.Add(new XAttribute("siteid", web.Site.ID));

                    bElement.Add(iElement);
                }

                gridElement.Add(new XElement("Cols"));
                XElement colsElement = gridElement.Element("Cols");

                // build enum value rules for treegrid
                BuildEnumValues(gridFields, bElement, resourceTeam, colsElement);

                // ReSharper restore PossibleNullReferenceException
                return resultXml.ToString();
            }
        }

        private static void BuildEnumValues(Dictionary<string, SPField> gridFields, XElement bElement, XDocument resourceTeam,
            XElement colsElement)
        {
            var resourceDict = new Dictionary<int, XElement>();

            // Performance improvement for EPML-4060
            Parallel.ForEach(resourceTeam.Descendants("Resource"), element =>
            {
                try
                {
                    resourceDict.Add(Convert.ToInt32(element.Attribute("ID").Value), element);
                }
                catch { }
            });

            foreach (var kv in gridFields)
            {
                if (kv.Value.Type != SPFieldType.Lookup) continue;

                var cElement = new XElement("C");
                string gridSafeFieldName = Utils.ToGridSafeFieldName(kv.Value.InternalName);
                cElement.Add(new XAttribute("Name", gridSafeFieldName));
                cElement.Add(new XAttribute("Type", "Enum"));

                // build enum choices
                var lEnum = new List<string>();
                var lEnumKeys = new List<string>();
                foreach (XNode n in bElement.DescendantNodes())
                {
                    if (!(n is XElement)) continue;

                    XElement ele = (XElement)n;
                    if (!ele.Name.LocalName.Equals("I")) continue;

                    var sRaw = (string)ele.Attribute(gridSafeFieldName);
                    var ID = (int)ele.Attribute("ID");
                    
                    SPFieldLookupValueCollection lookupValCols = new SPFieldLookupValueCollection();

                    try
                    {
                        var iEle = resourceDict[ID];

                        string lookupVal = iEle.Elements("Data")
                            .First(e => e.Attribute("Field").Value.Equals(kv.Value.InternalName)).Value;

                        lookupValCols = new SPFieldLookupValueCollection(lookupVal);
                    }
                    catch { }

                    var sEnum = string.Empty;
                    var sEnumKey = string.Empty;

                    if (lookupValCols.Count > 0)
                    {
                        foreach (var lookupVal in lookupValCols)
                        {
                            sEnum += (lookupVal.LookupValue + ";");
                            sEnumKey += (lookupVal.LookupId.ToString() + ";");
                        }
                    }

                    if (!string.IsNullOrEmpty(sEnum.Trim()))
                    {
                        sEnum = sEnum.TrimEnd(new[] { ';' });
                        if (!lEnum.Contains(sEnum))
                        {
                            lEnum.Add(sEnum);
                        }
                    }

                    if (!string.IsNullOrEmpty(sEnumKey.Trim()))
                    {
                        sEnumKey = sEnumKey.TrimEnd(new[] { ';' });
                        if (!lEnumKeys.Contains(sEnumKey))
                        {
                            lEnumKeys.Add(sEnumKey);
                        }
                    }
                }

                cElement.Add(new XAttribute("Enum", (lEnum.Count > 0 ? ("|" + string.Join("|", lEnum.ToArray())) : "")));
                cElement.Add(new XAttribute("EnumKeys",
                    (lEnumKeys.Count > 0 ? ("|" + string.Join("|", lEnumKeys.ToArray())) : "")));
                cElement.Add(new XAttribute("Range", "1"));
                cElement.Add(new XAttribute("FilterEnumKeys", "1"));
                colsElement.Add(cElement);
            }
        }

        private static string GetLayoutGrid(string data)
        {
            XDocument dataXml = XDocument.Parse(Utilities.DecodeGridData(data));

            XDocument resultXml = XDocument.Parse(Resources.ResourceGridLayout);
            XElement resultRootElement = resultXml.Root;

            if (resultRootElement == null)
            {
                throw new APIException((int)Errors.LayoutGridCNFRootElement,
                    "Cannot find the Root element of the grid layout.");
            }

            RegisterGridIdAndCss(resultRootElement, dataXml);

            XElement leftColsElement = resultRootElement.Element("LeftCols");

            if (leftColsElement == null)
            {
                throw new APIException((int)Errors.LayoutGridCNFLeftColsElement,
                    "Cannot find the LeftCols element of the grid layout.");
            }

            XElement colsElement = resultRootElement.Element("Cols");

            if (colsElement == null)
            {
                throw new APIException((int)Errors.LayoutGridCNFColElement,
                    "Cannot find the Col element of the grid layout.");
            }

            XElement headerElement = resultRootElement.Element("Header");

            if (headerElement == null)
            {
                throw new APIException((int)Errors.LayoutGridCNFHeaderElement,
                    "Cannot find the Header element of the grid layout.");
            }

            var existingCols = new List<string>();

            foreach (XAttribute colName in colsElement.Elements().Select(colElement => colElement.Attribute("Name"))
                )
            {
                if (colName == null)
                {
                    throw new APIException((int)Errors.LayoutGridCNFColNameInCols,
                        "Cannot find the column name in the grid layout.");
                }

                existingCols.Add(colName.Value);
            }

            foreach (
                XAttribute colName in leftColsElement.Elements().Select(colElement => colElement.Attribute("Name")))
            {
                if (colName == null)
                {
                    throw new APIException((int)Errors.LayoutGridCNFColNameInLeftCols,
                        "Cannot find the column name in the grid layout.");
                }

                existingCols.Add(colName.Value);
            }

            SPWeb spGetWeb = SPContext.Current.Site.RootWeb;

            using (var resourceManager = new ResourcePoolManager(spGetWeb))
            {
                SPWeb spWeb = spGetWeb;
                SPRegionalSettings spRegionalSettings = spWeb.CurrentUser.RegionalSettings ??
                                                        spWeb.Site.RootWeb.RegionalSettings;

                var cultureInfo = new CultureInfo((int)spRegionalSettings.LocaleId);

                string currencyFormat = string.Format("{0}#.00", cultureInfo.NumberFormat.CurrencySymbol);
                string shortDatePattern = cultureInfo.DateTimeFormat.ShortDatePattern;

                SPList resourcesList = resourceManager.ParentList;

                foreach (SPField spField in resourcesList.Fields)
                {
                    if (spField.Hidden && !spField.InternalName.Equals("EXTID")) continue;

                    string internalName = spField.InternalName;

                    if (internalName.Equals("LinkTitle") || internalName.Equals("LinkTitleNoMenu")) continue;

                    if (existingCols.Contains(internalName)) continue;

                    string relatedGridType = Utils.GetRelatedGridTypeForReadOnly(spField);
                    string format = Utils.GetFormat(spField);

                    switch (spField.Type)
                    {
                        case SPFieldType.User:
                        //case SPFieldType.Lookup:
                        case SPFieldType.MultiChoice:
                            relatedGridType = "Html";
                            break;
                    }

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
                    else if (relatedGridType.Equals("Enum"))
                    {

                    }
                    else if (!string.IsNullOrEmpty(format))
                    {
                        cElement.Add(new XAttribute("Format", format));
                    }

                    cElement.Add(new XAttribute("Visible", 0));

                    if (spField.InternalName.Equals("EXTID"))
                    {
                        cElement.Add(new XAttribute("CanFilter", 0), new XAttribute("CanGroup", 0),
                            new XAttribute("CanHide", 0));
                    }

                    cElement.Add(new XAttribute("CaseSensitive", "0"));

                    colsElement.Add(cElement);

                    headerElement.Add(new XAttribute(gridSafeFieldName, spField.Title));
                }
                return resultXml.ToString();
            }
        }

        /// <summary>
        ///     Parses the resources.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static IEnumerable<string> ParseResources(string value)
        {
            if (value.Equals("0;#")) return new List<string>();

            SPWeb currentWeb = SPContext.Current.Site.RootWeb;
            SPList spList = currentWeb.Lists["Resources"];

            var resources = new List<string>();

            string[] list = value.Replace(";#", ";").Split(';');

            for (int i = 0; i < list.Count() - 1; i++)
            {
                string resourcePoolId = list[i];
                string resource = string.Format("{0};#{1}", resourcePoolId, list[++i]);

                if (!_resourceDictionary.ContainsKey(resource))
                {
                    SPListItem spListItem = spList.GetItemById(Convert.ToInt32(resourcePoolId));
                    _resourceDictionary.Add(resource, spListItem["SharePointAccount"].ToString());
                }

                string mappedResource = _resourceDictionary[resource];
                if (!resources.Contains(mappedResource)) resources.Add(mappedResource);
            }

            return resources;
        }

        /// <summary>
        ///     Registers the grid id and CSS.
        /// </summary>
        /// <param name="resultRootElement">The result root element.</param>
        /// <param name="dataXml">The data XML.</param>
        private static void RegisterGridIdAndCss(XElement resultRootElement, XDocument dataXml)
        {
            if (dataXml == null)
            {
                throw new APIException((int)Errors.RegisterIdCssLayoutDataNull, "Layout data cannot be null.");
            }

            if (dataXml.Root == null)
            {
                throw new APIException((int)Errors.RegisterIdCssCNFRootElement,
                    "Cannot find the Root element of the layout data.");
            }

            XElement idElement = dataXml.Root.Element("Id");
            if (idElement == null)
            {
                throw new APIException((int)Errors.RegisterIdCssCNFIdElement,
                    "Cannot find the Id element of the layout data.");
            }

            var cfgElement = new XElement("Cfg");
            cfgElement.Add(new XAttribute("id", idElement.Value));

            cfgElement.Add(new XAttribute("CSS",
                string.Format("{0}/_layouts/epmlive/treegrid/grid/grid.css",
                    SPContext.Current.Web.SafeServerRelativeUrl())),
                new XAttribute("Style", "GM"));

            resultRootElement.Add(cfgElement);
        }

        // Internal Methods (10) 

        /// <summary>
        ///     Deletes the resource pool resource.
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
                        throw new APIException((int)Errors.DeleteResourceInvalidId,
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
                            string[] message = exception.Message.Split(new[] { "|||" }, StringSplitOptions.None);

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
                throw new APIException((int)Errors.DeleteResourcePoolResource, e.Message);
            }
        }

        /// <summary>
        ///     Deletes the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="web"></param>
        /// <returns></returns>
        internal static string DeleteResourcePoolViews(string data, SPWeb web)
        {
            try
            {
                using (var gridViewFactory = new GridViewManagerFactory())
                {
                    foreach (GridView gridView in GridViewUtils.ExtractViews(data))
                    {
                        using (
                            IGridViewManager gridViewManager = gridViewFactory.MakeGridViewManager(COMPONENT_NAME,
                                gridView))
                        {
                            gridViewManager.Remove(gridView);
                        }
                    }
                }

                ClearCache(web);

                return "<ResourcePoolViews/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int)Errors.DeleteResourcePoolViews, e.Message);
            }
        }

        /// <summary>
        ///     Exports the resources.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        internal static string ExportResources(SPWeb spWeb)
        {
            try
            {
                string file;
                string message;

                var resourceExporter = new ResourceExporter(spWeb);
                bool exported = resourceExporter.Export(out file, out message);

                return string.Format(@"<ResourceExporter Success=""{0}"" Message=""{1}"" File=""{2}"" />", exported,
                    message, file);
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int)Errors.ExportResources, e.Message);
            }
        }

        /// <summary>
        ///     Gets the resource pool data grid.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetResourcePoolDataGrid(string data, SPWeb web)
        {
            try
            {
                return ((byte[])CacheStore.Current.Get(GetCacheKey(web, "Data"),
                    new CacheStoreCategory(web).ResourceGrid, () => GetDataGrid(data, web).Zip()).Value).Unzip();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int)Errors.GetResourcePoolDataGrid, e.Message);
            }
        }

        /// <summary>
        ///     Gets the resource pool data grid changes.
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

                var dtUserInfo = new DataTable();

                if (spListItems.Count > 0)
                {
                    dtUserInfo = spWeb.Site.RootWeb.SiteUserInfoList.Items.GetDataTable();
                    dtUserInfo.PrimaryKey = new[] { dtUserInfo.Columns["ID"] };
                }

                var gridSafeFields = new Dictionary<string, string>();
                var gridFields = new Dictionary<string, SPField>();

                foreach (SPListItem spListItem in spListItems)
                {
                    var iElement = new XElement("I", new XAttribute(changeType, 1));

                    int resourceId = 0;
                    string profilePic = string.Format("{0}/_layouts/15/epmlive/images/default-avatar.png", spWeb.SafeServerRelativeUrl());

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

                            var dataElement = new XElement("Data", new XCData(rawValue));

                            BuildIElement(gridFields, resourcesList, gridSafeFields, type, value,
                                spWeb, field, iElement, dtUserInfo, dataElement, ref profilePic,
                                ref resourceId);
                        }
                        catch { }
                    }

                    iElement.Add(new XAttribute("ResourceID", resourceId));
                    iElement.Add(new XAttribute("ProfilePic",
                        string.Format(
                            @"<div class=""EPMLiveResourceGridPicture"">
															  <img src=""{0}"" height=""20""/>
														  </div>",
                            profilePic)));

                    iElement.Add(new XAttribute("itemid", spListItem.ID));
                    iElement.Add(new XAttribute("listid", resourcesList.ID));
                    iElement.Add(new XAttribute("webid", spWeb.ID));
                    iElement.Add(new XAttribute("siteid", spWeb.Site.ID));

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
                throw new APIException((int)Errors.GetResourcePoolDataGridChanges, e.Message);
            }
        }

        /// <summary>
        ///     Gets the resource pool layout grid.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetResourcePoolLayoutGrid(string data, SPWeb web)
        {
            try
            {
                return ((byte[])CacheStore.Current.Get(GetCacheKey(web, "Layout"),
                    new CacheStoreCategory(web).ResourceGrid, () => GetLayoutGrid(data).Zip()).Value).Unzip();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int)Errors.GetResourcePoolLayoutGrid, e.Message);
            }
        }

        /// <summary>
        ///     Gets the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="web"></param>
        /// <returns></returns>
        internal static string GetResourcePoolViews(string data, SPWeb web)
        {
            try
            {
                return ((byte[])CacheStore.Current.Get(GetCacheKey(web, "Views"),
                    new CacheStoreCategory(web).ResourceGrid, () => GetViews().Zip()).Value).Unzip();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int)Errors.GetResourcePoolViews, e.Message);
            }
        }

        private static string GetViews()
        {
            var viewsXml = new XElement("Views");

            using (var gridViewManagerFactory = new GridViewManagerFactory())
            {
                foreach (
                    GridViewManagerKind gridViewManagerKind in
                        new[] { GridViewManagerKind.Global, GridViewManagerKind.Personal })
                {
                    using (
                        IGridViewManager gridViewManager = gridViewManagerFactory.MakeGridViewManager(
                            COMPONENT_NAME, gridViewManagerKind))
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

        /// <summary>
        ///     Gets the resources.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="oWeb"></param>
        /// <returns></returns>
        internal static string GetResources(string data, SPWeb web)
        {
            try
            {
                XDocument resultXml;

                using (var resourceManager = new ResourcePoolManager(web))
                {
                    bool includeHidden = false;
                    bool includeReadOnly = false;

                    if (!string.IsNullOrEmpty(data))
                    {
                        XDocument dataDocument = XDocument.Parse(data);

                        XElement rootElement = dataDocument.Root;
                        if (rootElement == null)
                        {
                            throw new APIException((int)Errors.GetResourcesRootElementNofFound,
                                @"The ""Root"" element is not specified.");
                        }

                        XElement includeHiddenElement = rootElement.Element("IncludeHidden");
                        if (includeHiddenElement != null)
                        {
                            includeHidden = includeHiddenElement.Value.ToBool();
                        }

                        XElement includeReadOnlyElement = rootElement.Element("IncludeReadOnly");
                        if (includeReadOnlyElement != null)
                        {
                            includeReadOnly = includeReadOnlyElement.Value.ToBool();
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
                throw new APIException((int)Errors.GetResources, e.GetBaseException().Message);
            }
        }

        /// <summary>
        ///     Saves the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="web"></param>
        /// <returns></returns>
        internal static string SaveResourcePoolViews(string data, SPWeb web)
        {
            try
            {
                using (var gridViewManagerFactory = new GridViewManagerFactory())
                {
                    foreach (GridView gridView in GridViewUtils.ExtractViews(data))
                    {
                        using (
                            IGridViewManager gridViewManager = gridViewManagerFactory.MakeGridViewManager(
                                COMPONENT_NAME, gridView))
                        {
                            if (gridView.Id.Equals("dv"))
                            {
                                gridView.Version = Convert.ToInt32(Resources.ResourceGridDefaultGlobalViewVersion);
                            }

                            gridViewManager.Add(gridView);
                        }
                    }
                }

                ClearCache(web);

                return "<ResourcePoolViews/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int)Errors.SaveResourcePoolViews, e.Message);
            }
        }

        /// <summary>
        ///     Updates the resource pool views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="web"></param>
        /// <returns></returns>
        internal static string UpdateResourcePoolViews(string data, SPWeb web)
        {
            try
            {
                using (var gridViewManagerFactory = new GridViewManagerFactory())
                {
                    foreach (GridView gridView in GridViewUtils.ExtractViews(data))
                    {
                        using (
                            IGridViewManager gridViewManager = gridViewManagerFactory.MakeGridViewManager(
                                COMPONENT_NAME, gridView))
                        {
                            gridViewManager.Update(gridView);
                        }
                    }
                }

                ClearCache(web);

                return "<ResourcePoolViews/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int)Errors.UpdateResourcePoolViews, e.Message);
            }
        }

        #endregion Methods
    }
}