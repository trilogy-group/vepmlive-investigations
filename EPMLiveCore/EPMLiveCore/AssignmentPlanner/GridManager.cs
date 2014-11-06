using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore.AssignmentPlanner
{
    public class GridManager
    {
        #region Fields (3) 

        private const string ComponentName = "AssignmentPlanner";

        private const string ReportingConnectionError =
            "This site collection is not connected to a Reporting database.\nPlease connect this site to a Reporting database and try again.";

        private readonly SPWeb _spWeb;

        #endregion Fields 

        #region Enums (1) 

        private enum Errors
        {
            GetData = 18000,
            GetDataRootElementNotFound,
            GetLayout = 18100,
            NoGridElementFound,
            NoHeaderElementFound,
            NoColsElementFound,
            ConfigureColumns,
            ConfigureDefaultColumns,
            GetGanttExclude,
            RegisterIdCssLayoutDataNull,
            RegisterIdCssCNFRootElement,
            RegisterIdCssCNFIdElement,
            LoadViews = 18310,
            SaveViews = 18320,
            UpdateViews = 18330,
            DeleteViews = 18340,
            LoadModels = 18350,
            SaveModels = 18355,
            GetModels = 18360,
            ReportingConnection
        }

        #endregion Enums 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="GridManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public GridManager(SPWeb spWeb)
        {
            _spWeb = spWeb;
        }

        #endregion Constructors 

        #region Methods (14) 

        // Public Methods (9) 

        /// <summary>
        /// Deletes the views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string DeleteViews(string data)
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

                return "<AssignmentPlannerViews/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.DeleteViews, e.Message);
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string GetData(string data)
        {
            try
            {
                string response;
                NumberFormatInfo providerEn = new System.Globalization.NumberFormatInfo();
                providerEn.NumberDecimalSeparator = ".";
                providerEn.NumberGroupSeparator = ",";
                providerEn.NumberGroupSizes = new int[] { 3 };

                XElement dataRootElement = XDocument.Parse(data).Root;

                if (dataRootElement == null)
                {
                    throw new APIException((int) Errors.GetDataRootElementNotFound,
                                           "Cannot find the Root AssignmentPlanner element.");
                }

                using (var workEngineAPI = new WorkEngineAPI())
                {
                    response = workEngineAPI.Execute("Reporting_GetMyWorkData",
                                                     new XElement("GetMyWorkReportingData",
                                                                  dataRootElement.Element("Params")).ToString());
                }

                XDocument myWorkDataXml = XDocument.Parse(response);

                ValidateMyWorkDataResponse(myWorkDataXml);

                var gridSafeFields = new Dictionary<string, string>();

                var bElement = new XElement("B");
                var resourcesElement = new XElement("Resources");
                var footElement = new XElement("Foot");

                var resources = new Dictionary<int, string>();

                SPRegionalSettings spRegionalSettings = _spWeb.CurrentUser.RegionalSettings ??
                                                        _spWeb.Site.RootWeb.RegionalSettings;

                var workDayStartHour = (short) (spRegionalSettings.WorkDayStartHour/60);
                var workDayEndHour = (short) (spRegionalSettings.WorkDayEndHour/60);

                string siteUrl = _spWeb.Site.Url;
                string safeServerRelativeUrl = _spWeb.SafeServerRelativeUrl();

                foreach (
                    XElement resourceElement in
                        myWorkDataXml.Element("Result").Element("GetMyWorkData").Element("Data").Elements("Resource"))
                {
                    XElement resultElement = resourceElement.Element("Result");

                    if (!resultElement.Attribute("Status").Value.Equals("0")) continue;

                    int resourceId = 0;
                    string resourceName = string.Empty;

                    foreach (XElement itemElement in resourceElement.Element("Data").Elements("Item"))
                    {
                        var iElement = new XElement("I");

                        int itemId = 0;
                        Guid listId = Guid.Empty;
                        Guid webId = Guid.Empty;
                        Guid siteId = Guid.Empty;
                        string value = string.Empty;
                        float floatFieldValue;

                        foreach (XElement fieldElement in itemElement.Elements("Field"))
                        {
                            string field = fieldElement.Attribute("Name").Value;

                            if (!gridSafeFields.ContainsKey(field))
                            {
                                gridSafeFields.Add(field, Utils.ToGridSafeFieldName(field));
                            }

                            if (float.TryParse(fieldElement.Value.ToString(), out floatFieldValue))
                            {
                                value = floatFieldValue.ToString(providerEn);
                            }
                            else
                            {
                                value = fieldElement.Value;
                            }

                            string fieldName = field.ToLower();

                            if (fieldName.Equals("id")) itemId = Convert.ToInt32(value);
                            else if (fieldName.Equals("listid")) listId = new Guid(value);
                            else if (fieldName.Equals("webid")) webId = new Guid(value);
                            else if (fieldName.Equals("siteid")) siteId = new Guid(value);
                            else if (fieldName.Equals("assignedtoid")) resourceId = Convert.ToInt32(value);
                            else if (fieldName.Equals("assignedtotext")) resourceName = value;
                            else if (fieldElement.Attribute("Type").Value.Equals("System.DateTime") &&
                                     !string.IsNullOrEmpty(value))
                            {
                                DateTime localTime = SPUtility.CreateDateTimeFromISO8601DateTimeString(value);

                                if (fieldName.Equals("startdate") &&
                                    (localTime.Hour < workDayStartHour || localTime.Hour > workDayEndHour))
                                {
                                    localTime = new DateTime(localTime.Year, localTime.Month, localTime.Day,
                                                             workDayStartHour, 0, 0);
                                }
                                else if (fieldName.Equals("duedate") &&
                                         (localTime.Hour < workDayStartHour || localTime.Hour > workDayEndHour))
                                {
                                    localTime = new DateTime(localTime.Year, localTime.Month, localTime.Day,
                                                             workDayEndHour, 0, 0);
                                }

                                value = SPUtility.CreateISO8601DateTimeFromSystemDateTime(localTime);
                            }

                            iElement.Add(new XAttribute(gridSafeFields[field], value));
                        }

                        string flagQuery =
                            string.Format(
                                @"<MyPersonalization>
                                        <Keys>AssignmentPlannerFlag</Keys>
                                        <Item ID=""{0}""/>
                                        <List ID=""{1}""/>
                                        <Web ID=""{2}""/>
                                        <Site ID=""{3}"" URL=""{4}""/>
                                </MyPersonalization>",
                                itemId, listId, webId, siteId, siteUrl);

                        XDocument flagResponse = XDocument.Parse(MyPersonalization.GetMyPersonalization(flagQuery));

                        string flag = null;

                        XElement personalizationRootElement = flagResponse.Element("MyPersonalization");

                        if (personalizationRootElement != null)
                        {
                            flag = (from e in personalizationRootElement.Descendants("Personalization")
                                    let keyAttribute = e.Attribute("Key")
                                    where keyAttribute != null && keyAttribute.Value.Equals("AssignmentPlannerFlag")
                                    let valueAttribute = e.Attribute("Value")
                                    where valueAttribute != null
                                    select valueAttribute.Value).FirstOrDefault();
                        }

                        var flagValue = flag ?? "0";
                        var flagUrl = safeServerRelativeUrl + "/_layouts/epmlive/images/mywork/flagged.png";
                        if (flagValue.Equals("0")) flagUrl = safeServerRelativeUrl + "/_layouts/epmlive/images/mywork/unflagged.png";

                        iElement.Add(new XAttribute("Duration", string.Empty),
                                     new XAttribute("Flag", string.Format(@"<img src=""{0}"" class=""AP_Flag""/>", flagUrl)),
                                     new XAttribute("FlagValue", flagValue), new XAttribute("Height", 23));

                        if (resourceId == 0 || string.IsNullOrEmpty(resourceName)) continue;

                        bElement.Add(iElement);
                        if (!resources.ContainsKey(resourceId)) resources.Add(resourceId, resourceName);
                    }
                }

                foreach (var keyValuePair in resources)
                {
                    resourcesElement.Add(new XElement("R", new XAttribute("Name", keyValuePair.Value),
                                                      new XAttribute("Availability", 8), new XAttribute("Type", 1)));

                    footElement.Add(new XElement("I", new XAttribute("id", string.Format("-{0}", keyValuePair.Key)),
                                                 new XAttribute("Def", "Resource"),
                                                 new XAttribute("Title", keyValuePair.Value)));
                }

                return new XElement("Grid", new XElement("Body", bElement), resourcesElement, footElement).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetData, e.Message);
            }
        }

        /// <summary>
        /// Gets the layout.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string GetLayout(string data)
        {
            try
            {
                XDocument layoutXml = XDocument.Parse(Resources.AssignmentPlannerGridLayout);

                if (layoutXml.Root == null)
                {
                    throw new APIException((int) Errors.NoGridElementFound, "Cannot find the Grid element.");
                }

                XElement headerElement = layoutXml.Root.Element("Header");

                if (headerElement == null)
                {
                    throw new APIException((int) Errors.NoHeaderElementFound, "Cannot find the Header element.");
                }

                XElement colsElement = layoutXml.Root.Element("Cols");

                if (colsElement == null)
                {
                    throw new APIException((int) Errors.NoColsElementFound, "Cannot find the Cols element.");
                }

                string fieldsResponse;

                using (var workEngineAPI = new WorkEngineAPI())
                {
                    fieldsResponse = workEngineAPI.Execute("Reporting_GetMyWorkFields", string.Empty);
                }

                XElement errorElement = XDocument.Parse(fieldsResponse).Root.Descendants("Error").FirstOrDefault();

                if (errorElement != null)
                {
                    if (errorElement.Value.Contains("ExecuteReader requires an open and available Connection."))
                    {
                        throw new APIException((int) Errors.ReportingConnection, ReportingConnectionError);
                    }
                }

                XDocument dataXml = XDocument.Parse(Utilities.DecodeGridData(data));
                RegisterGridIdAndCss(layoutXml.Root, dataXml);

                XDocument fieldsXml = XDocument.Parse(fieldsResponse);

                List<string> fields =
                    fieldsXml.Root.Element("GetMyWorkFields").Element("Data").Elements("Field").Select(
                        e => e.Attribute("Name").Value).ToList();

                using (var spSite = new SPSite(_spWeb.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        SPList spList = spWeb.Lists["My Work"];

                        SPRegionalSettings regionalSettings = spWeb.RegionalSettings;

                        SPRegionalSettings spRegionalSettings = _spWeb.CurrentUser.RegionalSettings ?? regionalSettings;

                        var cultureInfo = new CultureInfo((int) spRegionalSettings.LocaleId);

                        string currencyFormat = string.Format("{0}#.00", cultureInfo.NumberFormat.CurrencySymbol);
                        string datePattern = cultureInfo.DateTimeFormat.ShortDatePattern;

                        var defaultColumns = new List<string>();

                        var workDayStartHour = (short) (regionalSettings.WorkDayStartHour/60);
                        var workDayEndHour = (short) (regionalSettings.WorkDayEndHour/60);

                        ConfigureDefaultColumns(spList, datePattern, currencyFormat, spWeb, workDayStartHour,
                                                workDayEndHour,
                                                GetGanttExclude(regionalSettings, spWeb, workDayStartHour,
                                                                workDayEndHour), ref layoutXml,
                                                ref defaultColumns);

                        ConfigureColumns(spWeb, currencyFormat, ref headerElement, ref colsElement, datePattern,
                                         defaultColumns, fields, spList);
                    }
                }

                return layoutXml.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetLayout, e.Message);
            }
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string GetModel(string data)
        {
            try
            {
                XDocument requestXml = XDocument.Parse(data);

                XElement rootElement = requestXml.Root;

                if (rootElement == null)
                {
                    throw new Exception("No Root element found.");
                }

                var dictionary = new Dictionary<string, int>();

                var spDocumentLibrary = (SPDocumentLibrary) _spWeb.Lists["Resource Plan Scenarios"];

                foreach (SPFile spFile in spDocumentLibrary.RootFolder.Files.Cast<SPFile>()
                    .Where(spFile => !dictionary.ContainsKey(spFile.Name)))
                {
                    dictionary.Add(spFile.Name, spFile.Item.ID);
                }

                XAttribute nameAttribute = rootElement.Attribute("Name");

                if (nameAttribute == null) throw new Exception("Cannot find the Name attribute.");

                string modelName = nameAttribute.Value;

                if (string.IsNullOrEmpty(modelName)) throw new Exception("Name attribute cannot be blank.");

                string name = modelName + ".xml";

                if (!dictionary.ContainsKey(name)) throw new Exception("Requested model does not exists.");

                return
                    Encoding.Default.GetString(
                        spDocumentLibrary.GetItemById(dictionary[name]).File.OpenBinary());
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetModels, e.Message);
            }
        }

        /// <summary>
        /// Loads the models.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string LoadModels(string data)
        {
            try
            {
                var modelsXml = new XElement("Models");

                var spDocumentLibrary = (SPDocumentLibrary) _spWeb.Lists["Resource Plan Scenarios"];

                foreach (SPFile spFile in spDocumentLibrary.RootFolder.Files)
                {
                    string fileName = spFile.Name;

                    if (string.IsNullOrEmpty(fileName)) continue;

                    string extension = Path.GetExtension(fileName);

                    if (extension == null || !extension.Equals(".xml")) continue;

                    string name = Path.GetFileNameWithoutExtension(fileName);

                    if (!string.IsNullOrEmpty(name))
                    {
                        modelsXml.Add(new XElement("Model", new XAttribute("Id", spFile.Item.UniqueId),
                                                   new XAttribute("Name", name),
                                                   new XAttribute("Url",
                                                                  string.Format("{0}/{1}", _spWeb.Url, spFile.Url))));
                    }
                }

                return new XElement("AssignmentPlannerModels", modelsXml).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.LoadModels, e.Message);
            }
        }

        /// <summary>
        /// Loads the views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string LoadViews(string data)
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

                return new XElement("AssignmentPlannerViews", viewsXml).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.LoadViews, e.Message);
            }
        }

        /// <summary>
        /// Saves the models.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string SaveModels(string data)
        {
            try
            {
                XDocument modelsXml = XDocument.Parse(data);

                if (modelsXml.Root != null)
                {
                    _spWeb.AllowUnsafeUpdates = true;

                    var spDocumentLibrary = (SPDocumentLibrary) _spWeb.Lists["Resource Plan Scenarios"];

                    foreach (XElement modelElement in modelsXml.Root.Elements("Model"))
                    {
                        XAttribute nameAttribute = modelElement.Attribute("Name");
                        string modelData = modelElement.Value;

                        if (nameAttribute == null || string.IsNullOrEmpty(modelData)) continue;

                        string name = nameAttribute.Value + ".xml";

                        spDocumentLibrary.RootFolder.Files.Add(name, Convert.FromBase64String(modelData));
                    }

                    _spWeb.AllowUnsafeUpdates = false;
                }

                return "<Models/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.SaveModels, e.Message);
            }
        }

        /// <summary>
        /// Saves the views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string SaveViews(string data)
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
                            gridViewManager.Add(gridView);
                        }
                    }
                }

                return "<AssignmentPlannerViews/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.SaveViews, e.Message);
            }
        }

        /// <summary>
        /// Updates the views.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string UpdateViews(string data)
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

                return "<AssignmentPlannerViews/>";
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.UpdateViews, e.Message);
            }
        }

        // Private Methods (5) 

        /// <summary>
        /// Configures the columns.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="currencyFormat">The currency format.</param>
        /// <param name="headerElement">The header element.</param>
        /// <param name="colsElement">The cols element.</param>
        /// <param name="datePattern">The date pattern.</param>
        /// <param name="defaultColumns">The default columns.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="spList">The sp list.</param>
        private static void ConfigureColumns(SPWeb spWeb, string currencyFormat, ref XElement headerElement,
                                             ref XElement colsElement,
                                             string datePattern, List<string> defaultColumns,
                                             IEnumerable<string> fields, SPList spList)
        {
            try
            {
                foreach (string field in fields)
                {
                    if (defaultColumns.Contains(field)) continue;
                    if (!spList.Fields.ContainsFieldWithInternalName(field)) continue;

                    SPField spField = spList.Fields.GetFieldByInternalName(field);

                    if (spField.InternalName.Equals("Title")) continue;

                    string relatedGridType = Utils.GetRelatedGridType(spField);

                    string format = Utils.GetFormat(spField);
                    format = MyWork.GetRelatedGridFormat(relatedGridType, format, spField, spWeb);

                    var cElement = new XElement("C");

                    string gridSafeFieldName = Utils.ToGridSafeFieldName(spField.InternalName);

                    switch (spField.Type)
                    {
                        case SPFieldType.User:
                        case SPFieldType.Lookup:
                            gridSafeFieldName += "Text";
                            break;
                        case SPFieldType.Choice:
                            relatedGridType = "Html";
                            break;
                    }

                    if (defaultColumns.Contains(gridSafeFieldName)) continue;

                    cElement.Add(new XAttribute("Name", gridSafeFieldName));
                    cElement.Add(new XAttribute("Type", relatedGridType));

                    if (relatedGridType.Equals("Icon"))
                    {
                        cElement.Add(new XAttribute("IconAlign", "Center"));
                    }

                    if (spField.Type == SPFieldType.Number)
                    {
                        if (((SPFieldNumber) spField).ShowAsPercentage) format = ",#0%";
                    }

                    if (spField.Type == SPFieldType.Currency)
                    {
                        cElement.Add(new XAttribute("Format", currencyFormat));
                    }
                    else if (relatedGridType.Equals("Date"))
                    {
                        cElement.Add(new XAttribute("Format", datePattern));
                    }
                    else if (!string.IsNullOrEmpty(format))
                    {
                        cElement.Add(new XAttribute("Format", format));
                    }

                    cElement.Add(new XAttribute("Visible", 0));

                    colsElement.Add(cElement);

                    headerElement.Add(new XAttribute(gridSafeFieldName, spField.Title));
                }
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.ConfigureColumns, exception.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Configures the default columns.
        /// </summary>
        /// <param name="spList">The sp list.</param>
        /// <param name="datePattern">The date pattern.</param>
        /// <param name="currencyFormat">The currency format.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="workDayStartHour">The work day start hour.</param>
        /// <param name="workDayEndHour">The work day end hour.</param>
        /// <param name="ganttExclude">The gantt exclude.</param>
        /// <param name="layoutXml">The layout XML.</param>
        /// <param name="defaultColumns">The default columns.</param>
        private static void ConfigureDefaultColumns(SPList spList, string datePattern, string currencyFormat,
                                                    SPWeb spWeb, short workDayStartHour, short workDayEndHour,
                                                    string ganttExclude, ref XDocument layoutXml,
                                                    ref List<string> defaultColumns)
        {
            try
            {
                foreach (string col in new[] {"LeftCols", "Cols", "RightCols"})
                {
                    XElement colElement = layoutXml.Root.Element(col);
                    if (colElement == null) continue;

                    foreach (XElement cElement in colElement.Elements("C"))
                    {
                        XAttribute nameAttribute = cElement.Attribute("Name");
                        if (nameAttribute == null) continue;

                        string colName = nameAttribute.Value;
                        if (defaultColumns.Contains(colName)) continue;

                        defaultColumns.Add(colName);

                        if (!spList.Fields.ContainsFieldWithInternalName(colName)) continue;

                        SPField spField = spList.Fields.GetFieldByInternalName(colName);

                        string relatedGridType = Utils.GetRelatedGridType(spField);

                        string format = Utils.GetFormat(spField);
                        format = MyWork.GetRelatedGridFormat(relatedGridType, format, spField, spWeb);

                        if (spField.Type == SPFieldType.Number)
                        {
                            if (((SPFieldNumber) spField).ShowAsPercentage) format = ",#0%";
                        }

                        if (spField.Type == SPFieldType.Currency)
                        {
                            cElement.Add(new XAttribute("Format", currencyFormat));
                        }
                        else if (relatedGridType.Equals("Date"))
                        {
                            cElement.Add(new XAttribute("Format", datePattern));
                        }
                        else if (!string.IsNullOrEmpty(format))
                        {
                            cElement.Add(new XAttribute("Format", format));
                        }
                    }

                    if (col.Equals("RightCols"))
                    {
                        colElement.Add(new XElement("C", new XAttribute("Name", "G"),
                                                    new XAttribute("GanttExclude", ganttExclude),
                                                    new XAttribute("GanttNewStart",
                                                                   string.Format("1/1/2000 {0}:00", workDayStartHour)),
                                                    new XAttribute("GanttNewEnd",
                                                                   string.Format("1/1/2000 {0}:00", workDayEndHour))));
                    }
                }
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.ConfigureDefaultColumns, exception.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Gets the gantt exclude.
        /// </summary>
        /// <param name="regionalSettings">The regional settings.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="workDayStartHour">The work day start hour.</param>
        /// <param name="workDayEndHour">The work day end hour.</param>
        /// <returns></returns>
        private string GetGanttExclude(SPRegionalSettings regionalSettings, SPWeb spWeb, short workDayStartHour,
                                       short workDayEndHour)
        {
            try
            {
                short lunchStartHour = 12;
                short lunchEndHour = 13;

                Guid lockedWeb = CoreFunctions.getLockedWeb(_spWeb);
                using (SPWeb configWeb = Utils.GetConfigWeb(_spWeb, lockedWeb))
                {
                    string startHour = CoreFunctions.getConfigSetting(configWeb,
                                                                      "EPMLive_MyWork_GeneralSettings_LunchStartHour");
                    if (!string.IsNullOrEmpty(startHour)) lunchStartHour = Convert.ToInt16(startHour);

                    string endHour = CoreFunctions.getConfigSetting(configWeb,
                                                                    "EPMLive_MyWork_GeneralSettings_LunchEndHour");
                    if (!string.IsNullOrEmpty(endHour)) lunchEndHour = Convert.ToInt16(endHour);
                }

                var stringBuilder = new StringBuilder();

                stringBuilder.Append("d#0:00~");
                stringBuilder.Append(workDayStartHour);
                stringBuilder.Append(":00#4;");

                stringBuilder.Append("d#");
                stringBuilder.Append(lunchStartHour);
                stringBuilder.Append(":00~");
                stringBuilder.Append(lunchEndHour);
                stringBuilder.Append(":00#4;");

                stringBuilder.Append("d#");
                stringBuilder.Append(workDayEndHour);
                stringBuilder.Append(":00~24:00#4;");

                short workingDays = regionalSettings.WorkDays;
                var jan62008 = new DateTime(633351744000000000);

                for (byte i = 0; i < 7; i++)
                {
                    if (((workingDays >> i) & 0x01) == 0x01) continue;

                    DateTime dateTime = jan62008.AddDays(i);

                    stringBuilder.Append("w#");
                    stringBuilder.Append(dateTime.ToString("yyyy-MM-dd"));
                    stringBuilder.Append("~");

                    dateTime = dateTime.AddDays(1);

                    stringBuilder.Append(dateTime.ToString("yyyy-MM-dd"));
                    stringBuilder.Append("#5;");
                }

                try
                {
                    foreach (DataRow dataRow in spWeb.Lists["Holidays"].Items.GetDataTable().Rows)
                    {
                        DateTime dateTime = DateTime.Parse(dataRow["Date"].ToString());

                        if (string.IsNullOrEmpty(dataRow["Hours"].ToString()))
                        {
                            stringBuilder.Append(dateTime.ToString("yyyy-MM-dd"));
                            stringBuilder.Append("~");
                            dateTime = dateTime.AddDays(1);

                            stringBuilder.Append(dateTime.ToString("yyyy-MM-dd"));
                            stringBuilder.Append("#3;");
                        }
                        else
                        {
                            stringBuilder.Append(dateTime.ToString("yyyy-MM-dd"));
                            stringBuilder.Append(" 00:00~");
                            stringBuilder.Append(dateTime.ToString("yyyy-MM-dd"));
                            stringBuilder.Append(" ");
                            stringBuilder.Append(workDayStartHour);
                            stringBuilder.Append(":00;");

                            stringBuilder.Append(dateTime.ToString("yyyy-MM-dd"));
                            stringBuilder.Append(" ");
                            stringBuilder.Append((workDayEndHour) - int.Parse(dataRow["Hours"].ToString()));
                            stringBuilder.Append(":00~");

                            dateTime = dateTime.AddDays(1);

                            stringBuilder.Append(dateTime.ToString("yyyy-MM-dd"));
                            stringBuilder.Append(" 24:00#3;");
                        }
                    }
                }
                catch (Exception)
                {
                }

                return stringBuilder.ToString().Trim(';');
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.GetGanttExclude, exception.GetBaseException().Message);
            }
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

            resultRootElement.Add(cfgElement);
        }

        /// <summary>
        /// Validates my work data response.
        /// </summary>
        /// <param name="myWorkDataXml">My work data XML.</param>
        private static void ValidateMyWorkDataResponse(XDocument myWorkDataXml)
        {
            if (myWorkDataXml.Root == null)
            {
                throw new Exception("Unable to retrive reporting data.");
            }

            XAttribute myWorkDataStatusAttribute = myWorkDataXml.Root.Attribute("Status");

            if (myWorkDataStatusAttribute == null ||
                (myWorkDataXml.Root == null || !myWorkDataStatusAttribute.Value.Equals("1")))
            {
                return;
            }

            XElement errorElement = myWorkDataXml.Root.Element("Error");

            if (errorElement != null)
            {
                XAttribute errorIdAttribute = errorElement.Attribute("ID");
                if (errorIdAttribute != null)
                {
                    throw new APIException(Convert.ToInt32(errorIdAttribute.Value), errorElement.Value);
                }
            }
        }

        #endregion Methods 
    }
}