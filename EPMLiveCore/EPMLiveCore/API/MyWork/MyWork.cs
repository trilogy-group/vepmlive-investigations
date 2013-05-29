/***
 * ERROR CODES BEING USED
 * 
 * 2000
 * 2001
 * 2002
 * 2003
 * 2004
 * 2005
 * 2006
 * 2007
 * 2008
 * 2009
 * 2010
 * 
 * 2011
 * 2012
 * 2013
 * 
 * 2014
 * 
 * 2015
 * 
 * 2016
 * 
 * 2020
 * 
 * 2021
 * 2022
 * 
 * 2030
 * 
 * 2035
 * 
 * 2040
 * 
 * 2045
 * 
 * 2050
 * 2051
 * 2052
 * 
 * 2060
 * 2061
 * 2062
 * 
 * 2070
 * 
 * 2080
 * 2081
 * 2082
 * 
 * 2090
 * 2091
 * 2092
 * 
 * 
 **/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;
using EPMLiveCore.Properties;
using EPMLiveCore.ReportingProxy;
using EPMLiveReportsAdmin;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore.API
{
    public class MyWork
    {
        #region Fields (35) 

        private const string ASSIGNED_TO_FIELD = "AssignedTo";
        private const string COMMENT_COL_WIDTH = "36";
        private const string COMMENT_COUNT_FIELD = "CommentCount";
        private const string COMMENTERS_FIELD = "Commenters";
        private const string COMMENTERS_READ_FIELD = "CommentersRead";
        private const string COMPLETE_COL_WIDTH = "20";
        private const string COMPLETED_FIELD = "Complete";
        private const string CREATED_BY_FIELD = "Author";
        private const string CREATED_FIELD = "Created";
        private const string DUE_DATE_COL_WIDTH = "100";
        private const string DUE_DATE_FIELD = "DueDate";
        private const string DUE_DAY_COL_WIDTH = "150";
        private const string DUE_DAY_FIELD = "DueDay";
        private const string FLAG_COL_WIDTH = "40";
        private const string FLAG_FIELD = "Flag";
        private const string GENERAL_SETTINGS_CROSS_SITE_URLS = "EPMLive_MyWork_GeneralSettings_CrossSiteUrls";
        private const string GENERAL_SETTINGS_PERFORMANCE_MODE = "EPMLive_MyWork_GeneralSettings_PerformanceMode";
        private const string GENERAL_SETTINGS_SELECTED_FIELDS = "EPMLive_MyWork_GeneralSettings_SelectedFields";
        private const string GENERAL_SETTINGS_SELECTED_LISTS = "EPMLive_MyWork_GeneralSettings_SelectedLists";

        private const string GENERAL_SETTINGS_SELECTED_MY_WORK_LISTS =
            "EPMLive_MyWork_GeneralSettings_SelectedMyWorkLists";

        private const string LIST_ID_FIELD = "ListId";
        private const string MODIFIED_BY_FIELD = "Editor";
        private const string MODIFIED_FIELD = "Modified";
        private const string MY_WORK_GRID_GLOBAL_VIEWS = "EPMLive_MyWork_Grid_GlobalViews";
        private const string MY_WORK_GRID_PERSONAL_VIEWS = "EPMLive_MyWork_Grid_PersonalViews";
        private const int MY_WORK_LIST_SERVER_TEMPLATE_ID = 10115;
        private const string PRIORITY_COL_WIDTH = "25";
        private const string PRIORITY_FIELD = "Priority";
        private const string SITE_ID_FIELD = "SiteId";
        private const string SITE_URL_FIELD = "SiteUrl";
        private const string TITLE_COL_WIDTH = "0";
        private const string TITLE_FIELD = "Title";
        private const string WEB_ID_FIELD = "WebId";
        private const string WORK_TYPE_FIELD = "Work0000Type";
        private const string WORKING_ON_FIELD = "WorkingOn";

        #endregion Fields 

        #region Methods (56) 

        // Public Methods (8) 

        /// <summary>
        ///     Gets the archived webs.
        /// </summary>
        /// <param name="siteId">The site id.</param>
        /// <returns></returns>
        public static List<Guid> GetArchivedWebs(Guid siteId)
        {
            try
            {
                var archivedWebs = new List<Guid>();

                using (var spSite = new SPSite(siteId))
                {
                    using (
                        var sqlConnection =
                            new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        const string queryString =
                            "SELECT WebId FROM dbo.PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId)";

                        using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@siteId", siteId);

                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                                while (sqlDataReader.Read())
                                    archivedWebs.Add(new Guid(sqlDataReader[0].ToString()));
                            }
                            catch (SqlException sqlException)
                            {
                                throw new APIException(2013, sqlException.Message);
                            }
                            finally
                            {
                                sqlConnection.Close();
                            }
                        }
                    }
                }

                return archivedWebs;
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2012, e.Message);
            }
        }

        /// <summary>
        ///     Gets the global views.
        /// </summary>
        /// <param name="configWeb">The config web.</param>
        /// <returns></returns>
        public static IEnumerable<MyWorkGridView> GetGlobalViews(SPWeb configWeb)
        {
            try
            {
                var myWorkGridViews = new List<MyWorkGridView>();

                using (configWeb)
                {
                    string serializedGlobalViews = CoreFunctions.getConfigSetting(configWeb, MY_WORK_GRID_GLOBAL_VIEWS);

                    if (!string.IsNullOrEmpty(serializedGlobalViews))
                    {
                        var xmlSerializer = new XmlSerializer(typeof (List<MyWorkGridView>));
                        return
                            (IEnumerable<MyWorkGridView>)
                            xmlSerializer.Deserialize(new StringReader(serializedGlobalViews));
                    }
                }

                return myWorkGridViews;
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2081, e.Message);
            }
        }

        /// <summary>
        ///     Gets the list fields and types from db.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static IOrderedEnumerable<KeyValuePair<string, string>> GetListFieldsAndTypesFromDb(Guid listId,
                                                                                                   Guid webId,
                                                                                                   SPWeb spWeb)
        {
            try
            {
                var listFieldsAndTypes = new Dictionary<string, string>();

                using (SqlConnection sqlConnection = GetSpContentDbSqlConnection(spWeb))
                {
                    string queryString =
                        string.Format(@"SELECT tp_Fields FROM AllLists WHERE tp_ID = @listId AND tp_WebId = @webId");

                    using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@listId", listId);
                        sqlCommand.Parameters.AddWithValue("@webId", webId);


                        SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                        string fields = ((byte[]) sqlCommand.ExecuteScalar()).SpDecompress();

                        XDocument xDocument = XDocument.Parse(string.Format("<Fields>{0}</Fields>",
                                                                            fields.Remove(0, fields.IndexOf("<"))));

                        foreach (XElement xElement in xDocument.Element("Fields").Elements()
                                                               .Where(
                                                                   xElement => xElement.Name.LocalName.Equals("Field"))
                                                               .Where(
                                                                   xElement =>
                                                                   xElement.Attribute("Name") != null &&
                                                                   xElement.Attribute("Type") != null)
                            )
                        {
                            listFieldsAndTypes.Add(xElement.Attribute("Name").Value, xElement.Attribute("Type").Value);
                        }

                        sqlConnection.Close();
                    }
                }

                return listFieldsAndTypes.OrderBy(f => f.Key);
            }
            catch (SqlException sqlException)
            {
                throw new APIException(2005, sqlException.Message);
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2006, e.Message);
            }
        }

        /// <summary>
        ///     Gets the list ids from db.
        /// </summary>
        /// <param name="selectedList">The selected lists.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="archivedWebs">The archived webs.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetListIdsFromDb(string selectedList, SPWeb spWeb, List<Guid> archivedWebs)
        {
            try
            {
                var listIds = new List<string>();

                using (SqlConnection sqlConnection = GetSpContentDbSqlConnection(spWeb))
                {
                    string webUrl = spWeb.ServerRelativeUrl;
                    webUrl = webUrl.Equals("/") ? string.Empty : webUrl.Substring(1);

                    string archivedWebString = string.Join(",",
                                                           archivedWebs.Select(
                                                               archivedWeb => string.Format("'{0}'", archivedWeb)).
                                                                        ToArray());

                    string queryString =
                        string.Format(
                            @"
                            SELECT      dbo.AllLists.tp_ID 
                            FROM        dbo.Webs 
                            INNER JOIN  dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId 
                            WHERE (dbo.AllLists.tp_Title = '{0}') AND ",
                            selectedList);

                    queryString += string.IsNullOrEmpty(webUrl)
                                       ? string.Format(@"(dbo.Webs.SiteId = '{0}')", spWeb.Site.ID)
                                       : string.Format(
                                           @"(dbo.Webs.FullUrl LIKE '{0}/%' OR dbo.Webs.FullUrl = '{0}')", webUrl);

                    if (archivedWebs.Count > 0)
                        queryString += string.Format(@" AND (dbo.AllLists.tp_WebId NOT IN ({0}))", archivedWebString);

                    using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            listIds.Add(sqlDataReader.GetGuid(0).ToString());
                        }

                        sqlConnection.Close();
                    }
                }

                return listIds;
            }
            catch (SqlException sqlException)
            {
                throw new APIException(2001, sqlException.Message);
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2002, e.Message);
            }
        }

        /// <summary>
        ///     Gets the list name from db.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static string GetListNameFromDb(Guid listId, Guid webId, SPWeb spWeb)
        {
            try
            {
                using (SqlConnection sqlConnection = GetSpContentDbSqlConnection(spWeb))
                {
                    string queryString =
                        string.Format(@"SELECT tp_Title FROM AllLists WHERE tp_ID = @listId AND tp_WebId = @webId");

                    using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@listId", listId);
                        sqlCommand.Parameters.AddWithValue("@webId", webId);

                        string listName;

                        SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                        listName = sqlCommand.ExecuteScalar() as string;

                        sqlConnection.Close();


                        return listName;
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw new APIException(2003, sqlException.Message);
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2004, e.Message);
            }
        }

        /// <summary>
        ///     Gets the SP content DB SQL connection.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static SqlConnection GetSpContentDbSqlConnection(SPWeb spWeb)
        {
            try
            {
                SqlConnection sqlConnection = null;
                SPSecurity.RunWithElevatedPrivileges(() =>
                    {
                        string databaseConnectionString =
                            spWeb.Site.ContentDatabase.DatabaseConnectionString;
                        sqlConnection = new SqlConnection(databaseConnectionString);
                    });
                return sqlConnection;
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2008, e.Message);
            }
        }

        /// <summary>
        ///     Saves the global views.
        /// </summary>
        /// <param name="myWorkGridView">My work grid view.</param>
        /// <param name="configWeb">The config web.</param>
        public static void SaveGlobalViews(MyWorkGridView myWorkGridView, SPWeb configWeb)
        {
            List<MyWorkGridView> myWorkGridViews = GetGlobalViews(configWeb).ToList();
            myWorkGridViews.RemoveAll(v => v.Id.Equals(myWorkGridView.Id));

            if (myWorkGridView.Default)
            {
                foreach (MyWorkGridView gridView in myWorkGridViews)
                {
                    gridView.Default = false;
                }
            }

            myWorkGridViews.Add(myWorkGridView);

            SaveGlobalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Shoulds the use reporting db.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static bool ShouldUseReportingDb(SPWeb spWeb)
        {
            bool useReportingDb = false;

            using (SPWeb configWeb = Utils.GetConfigWeb(spWeb, CoreFunctions.getLockedWeb(spWeb)))
            {
                var reportData = new ReportData(configWeb.Site.ID);

                if (reportData.GetSite() != null)
                {
                    if (reportData.GetListMapping(configWeb.Lists["My Work"].ID) != null)
                    {
                        useReportingDb = true;
                    }
                }
            }

            return useReportingDb;
        }

        // Private Methods (32) 

        /// <summary>
        ///     Builds the field element.
        /// </summary>
        /// <param name="fieldTypes">The field types.</param>
        /// <param name="value">The value.</param>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        private static XElement BuildFieldElement(Dictionary<string, SPField> fieldTypes, string value, string field)
        {
            value = value ?? string.Empty;

            string type;
            string format;

            GetTypeAndFormat(fieldTypes, field, out type, out format);

            if (field.Equals("Complete"))
            {
                value = value.Equals("True") ? "1" : "0";
            }

            var fieldElement = new XElement("Field", new XCData(value));
            fieldElement.Add(new XAttribute("Name", field));
            fieldElement.Add(new XAttribute("Type", type));
            fieldElement.Add(new XAttribute("Format", format));

            return fieldElement;
        }

        /// <summary>
        ///     Deletes the global view.
        /// </summary>
        /// <param name="viewId">The view id.</param>
        /// <param name="globalViews">The global views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void DeleteGlobalView(string viewId, IEnumerable<MyWorkGridView> globalViews, SPWeb configWeb)
        {
            List<MyWorkGridView> myWorkGridViews = globalViews.ToList();
            myWorkGridViews.RemoveAll(v => v.Id.Equals(viewId));

            SaveGlobalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Deletes the personal view.
        /// </summary>
        /// <param name="viewId">The view id.</param>
        /// <param name="personalViews">The personal views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void DeletePersonalView(string viewId, IEnumerable<MyWorkGridView> personalViews, SPWeb configWeb)
        {
            List<MyWorkGridView> myWorkGridViews = personalViews.ToList();
            myWorkGridViews.RemoveAll(v => v.Id.Equals(viewId));

            SavePersonalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Generates the col dictionary.
        /// </summary>
        /// <param name="myWorkDataTable">My work data table.</param>
        /// <param name="myWorkFields">My work fields.</param>
        /// <returns></returns>
        private static Dictionary<string, int> GenerateColDictionary(DataTable myWorkDataTable,
                                                                     IEnumerable<string> myWorkFields)
        {
            var colDict = new Dictionary<string, int>();

            foreach (string selectedField in myWorkFields)
            {
                if (myWorkDataTable.Columns.Contains(selectedField))
                {
                    colDict.Add(selectedField, 1);
                }
                else if (myWorkDataTable.Columns.Contains(selectedField + "ID"))
                {
                    colDict.Add(selectedField, 2);
                }
                else
                {
                    colDict.Add(selectedField, 0);
                }
            }

            return colDict;
        }

        /// <summary>
        ///     Gets the data from lists.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="fieldTypes">The field types.</param>
        /// <param name="query">The query.</param>
        /// <param name="spSite">The sp site.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="selectedFields">The selected fields.</param>
        /// <param name="selectedLists">The selected lists.</param>
        private static void GetDataFromLists(XDocument result, Dictionary<string, SPField> fieldTypes, string query,
                                             SPSite spSite, SPWeb spWeb,
                                             List<string> selectedFields, List<string> selectedLists)
        {
            foreach (Guid theWebId in from webId in spWeb.ToTreeList()
                                      let archivedWebs = GetArchivedWebs(spSite.ID)
                                      let theWebId = webId
                                      where !archivedWebs.Exists(wId => wId == theWebId)
                                      select theWebId)
            {
                using (SPWeb web = spSite.OpenWeb(theWebId))
                {
                    var workingOnDict = new Dictionary<string, List<string>>();

                    DataTable dtWorkingOn = GetWorkingOn(web);
                    if (dtWorkingOn.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dtWorkingOn.Rows)
                        {
                            string key = dataRow["ListId"].ToString().ToUpper();
                            key = key.Replace("{", string.Empty);
                            key = key.Replace("}", string.Empty);

                            if (!workingOnDict.ContainsKey(key))
                            {
                                workingOnDict.Add(key, new List<string>());
                            }

                            workingOnDict[key].Add(dataRow["ItemId"].ToString());
                        }
                    }

                    foreach (string selectedList in selectedLists.Distinct().OrderBy(l => l))
                    {
                        SPList spList = web.Lists.TryGetList(selectedList);

                        if (spList == null) continue;

                        //WriteToDebugWindow("List: " + spList.Title);

                        var spQuery = new SPQuery
                            {QueryThrottleMode = SPQueryThrottleOption.Override};

                        foreach (string selectedField in selectedFields)
                        {
                            spQuery.ViewFields +=
                                string.Format(@"<FieldRef Name='{0}' Nullable='TRUE'/>",
                                              selectedField);
                        }

                        if (!selectedFields.Exists(f => f.Equals(COMPLETED_FIELD)))
                            spQuery.ViewFields +=
                                string.Format("<FieldRef Name='{0}' Nullable='TRUE'/>",
                                              COMPLETED_FIELD);

                        spQuery.Query = query;

                        SPListItemCollection spListItemCollection = null;

                        SPSecurity.RunWithElevatedPrivileges(
                            () => { spListItemCollection = spList.GetItems(spQuery); });

                        if (!spListItemCollection.HasItems()) continue;

                        bool listContainsField = selectedFields.Any(selectedField =>
                                                                    spListItemCollection.Fields.
                                                                                         ContainsField(selectedField));

                        if (!listContainsField) continue;

                        //WriteToDebugWindow("Total items: " + spListItemCollection.Count);

                        int itemCount = 1;
                        foreach (SPListItem spListItem in spListItemCollection)
                        {
                            //WriteToDebugWindow("Processing item # " + itemCount++);

                            SPListItem theListItem = spListItem;

                            var fieldsElement = new XElement("Fields");

                            foreach (string selectedField in selectedFields.Where(
                                selectedField =>
                                theListItem.Fields.ContainsFieldWithInternalName(selectedField)))
                            {
                                string value =
                                    (theListItem[selectedField] ?? string.Empty).ToString();

                                string type;
                                string format;

                                GetTypeAndFormat(fieldTypes, selectedField, out type, out format);

                                var fieldElement = new XElement("Field", new XCData(value));
                                fieldElement.Add(new XAttribute("Name", selectedField));
                                fieldElement.Add(new XAttribute("Type", type));
                                fieldElement.Add(new XAttribute("Format", format));

                                fieldsElement.Add(fieldElement);
                            }

                            string listId = spList.ID.ToString().ToUpper();

                            var itemElement = new XElement("Item");
                            itemElement.Add(new XAttribute("ID",
                                                           spListItem["ID"].ToString().ToUpper()));

                            itemElement.Add(new XAttribute("ListID", listId));
                            itemElement.Add(new XAttribute("WebID", theWebId.ToString().ToUpper()));
                            itemElement.Add(new XAttribute("SiteID", spSite.ID.ToString().ToUpper()));
                            itemElement.Add(new XAttribute("SiteURL", spSite.Url));
                            itemElement.Add(new XAttribute(WORK_TYPE_FIELD, spList.Title));
                            itemElement.Add(new XAttribute("Workspace", web.Title));

                            bool workingOn = false;

                            string key = listId;
                            key = key.Replace("{", string.Empty);
                            key = key.Replace("}", string.Empty);

                            if (workingOnDict.ContainsKey(key))
                            {
                                workingOn =
                                    workingOnDict[key].Contains(spListItem.ID.ToString(CultureInfo.InvariantCulture));
                            }

                            itemElement.Add(new XAttribute(WORKING_ON_FIELD, workingOn));

                            itemElement.Add(fieldsElement);

                            result.Element("MyWork").Add(itemElement);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the data from reporting DB.
        /// </summary>
        /// <param name="workTypes">The work types.</param>
        /// <param name="selectedFields">The selected fields.</param>
        /// <param name="archivedWebs">The archived webs.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="selectedLists">The selected lists.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static IEnumerable<DataTable> GetDataFromReportingDB(Dictionary<string, string> workTypes,
                                                                     IEnumerable<string> selectedFields,
                                                                     List<Guid> archivedWebs, SPWeb spWeb,
                                                                     List<string> selectedLists, string data)
        {
            const string dateFormat = "yyyy-MM-dd HH:mm:ss";

            SqlDateTime from = SqlDateTime.MinValue;
            SqlDateTime to = SqlDateTime.MaxValue;

            XDocument requestXml = XDocument.Parse(data);

            bool getCompletedItems = false;

            if (requestXml.Root != null)
            {
                XElement xElement = requestXml.Root.Element("CompleteItemsQuery");
                if (xElement != null)
                {
                    bool.TryParse(xElement.Value, out getCompletedItems);
                }

                XElement dateRange = requestXml.Root.Element("DateRange");
                if (dateRange != null)
                {
                    XAttribute fromAttribute = dateRange.Attribute("From");
                    if (fromAttribute != null)
                    {
                        DateTime f = DateTime.ParseExact(fromAttribute.Value, dateFormat, null);
                        if (f > from.Value) from = f;
                    }

                    XAttribute toAttribute = dateRange.Attribute("To");
                    if (toAttribute != null)
                    {
                        DateTime t = DateTime.ParseExact(toAttribute.Value, dateFormat, null);
                        if (t < to.Value) to = t;
                    }
                }
            }

            Guid myWorkListId;

            SPWeb theWeb = spWeb;
            Guid lockedWeb = CoreFunctions.getLockedWeb(theWeb);
            using (SPWeb configWeb = Utils.GetConfigWeb(theWeb, lockedWeb))
            {
                myWorkListId = configWeb.Lists["My Work"].ID;
            }

            var tables = new List<DataTable>();

            DataTable myWorkDataTable;
            DataTable fieldsTable;
            DataTable flagsTable;

            Guid siteId = spWeb.Site.ID;

            using (var myWorkReportData = new MyWorkReportData(siteId))
            {
                MapCompleteField(spWeb, myWorkReportData);

                string archivedWebIds = string.Empty;

                if (archivedWebs.Any())
                {
                    string @join = string.Join(",",
                                               archivedWebs.Distinct().Select(
                                                   w => string.Format(@"N'{0}'", w)).
                                                            ToArray());
                    archivedWebIds = string.Format(@"AND (WebId NOT IN ({0}))", @join);
                }

                string queryLists = string.Join(",",
                                                selectedLists.Select(
                                                    l => string.Format(@"N'{0}'", l)).
                                                              ToArray());

                SPUser currentUser = spWeb.CurrentUser;

                string sql = string.Format(
                    @"SELECT DISTINCT * FROM dbo.LSTMyWork WHERE ([AssignedToID] = {0})  AND ([Complete] {1} 1 OR [Complete] IS NULL)
                                AND ([WebUrl] LIKE N'{2}%' OR [WebUrl] = N'{2}' OR [WebUrl] = N'/' AND [SiteId] = N'{3}')
                                AND ([DueDate] IS NULL OR ([DueDate] >= '{4}' AND [DueDate] <= '{5}'))
                                AND ([WorkType] IN ({6})) {7}",
                    currentUser.ID, getCompletedItems ? "=" : "<>",
                    spWeb.SafeServerRelativeUrl(), siteId,
                    ((DateTime) from).ToString("MM/dd/yyyy HH:mm:ss"),
                    ((DateTime) to).ToString("MM/dd/yyyy HH:mm:ss"),
                    queryLists, archivedWebIds);

                DataTable dataTable = myWorkReportData.ExecuteSql(sql);

                myWorkDataTable = new DataTable();

                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    myWorkDataTable.Columns.Add(dataColumn.ColumnName, dataColumn.DataType);
                }

                var list = new List<string>();

                EnumerableRowCollection<DataRow> dataRows = dataTable.AsEnumerable();

                foreach (DataRow dataRow in dataRows)
                {
                    string key = dataRow["SiteId"].ToString() + dataRow["WebId"] + dataRow["ListId"] + dataRow["ItemId"] +
                                 dataRow["AssignedToID"];
                    key = key.Replace("{", string.Empty).Replace("}", string.Empty).ToUpper();

                    if (list.Contains(key)) continue;

                    list.Add(key);

                    DataRow row = myWorkDataTable.NewRow();

                    foreach (DataColumn dataColumn in myWorkDataTable.Columns)
                    {
                        row[dataColumn.ColumnName] = dataRow[dataColumn.ColumnName];
                    }

                    myWorkDataTable.Rows.Add(row);
                }

                if (myWorkDataTable.Rows.Count == 0) return tables;

                IEnumerable<string> columns = from DataColumn dataColumn in myWorkDataTable.Columns
                                              select string.Format(@"N'{0}'", dataColumn.ColumnName);

                var lists = new List<string>
                    {
                        string.Format(@"N'{0}'", myWorkListId.ToString()
                                                             .Replace("{", string.Empty)
                                                             .Replace("}", string.Empty))
                    };

                foreach (DataRow r in myWorkDataTable.Rows)
                {
                    string listId = r["ListId"].ToString();

                    string lstId = string.Format(@"N'{0}'", listId);
                    if (!lists.Contains(lstId))
                    {
                        lists.Add(lstId);
                    }

                    string uniqueId = (listId + r["WebId"] + r["SiteId"]).Md5();

                    if (!workTypes.ContainsKey(uniqueId))
                    {
                        workTypes.Add(uniqueId, r["WorkType"].ToString());
                    }
                }

                sql =
                    string.Format(
                        @"SELECT ColumnName, InternalName, SharePointType, RPTListId AS ListId 
                                 FROM dbo.RPTColumn WHERE (ColumnName IN ({0})) AND (RPTListId IN ({1}))",
                        string.Join(",", columns.ToArray()),
                        string.Join(",", lists.ToArray()));

                fieldsTable = myWorkReportData.ExecuteSql(sql);

                sql =
                    string.Format(
                        @"SELECT ListId, ItemId, Value FROM dbo.PERSONALIZATIONS WHERE [Key] = 'Flag' AND UserId = N'{0}'",
                        currentUser.LoginName);

                flagsTable = myWorkReportData.ExecuteEpmLiveSql(sql);
                flagsTable.PrimaryKey = new[] {flagsTable.Columns["ListId"], flagsTable.Columns["ItemId"]};
            }

            EnumerableRowCollection<DataRow> myWorkDtRows = myWorkDataTable.AsEnumerable();
            EnumerableRowCollection<DataRow> fieldsTableRows = fieldsTable.AsEnumerable();

            List<string> myWorkFields =
                (from r in fieldsTableRows select r["InternalName"].ToString()).Distinct().ToList();

            foreach (string selectedField in selectedFields.Where(f => !myWorkFields.Contains(f)))
            {
                myWorkFields.Add(selectedField);
            }

            Dictionary<string, int> colDict = GenerateColDictionary(myWorkDataTable, myWorkFields);

            var workingOnDict = new Dictionary<string, List<string>>();

            foreach (DataRow dataRow in GetWorkingOn(spWeb).Rows)
            {
                string key = dataRow["ListId"].ToString().ToUpper();

                key = key.Replace("{", string.Empty);
                key = key.Replace("}", string.Empty);

                if (!workingOnDict.ContainsKey(key))
                {
                    workingOnDict.Add(key, new List<string>());
                }

                workingOnDict[key].Add(dataRow["ItemId"].ToString());
            }

            foreach (string selectedList in selectedLists)
            {
                var dataTable = new DataTable();

                foreach (string field in myWorkFields)
                {
                    dataTable.Columns.Add(field, typeof (object));
                }

                if (!dataTable.Columns.Contains(WORKING_ON_FIELD))
                    dataTable.Columns.Add(WORKING_ON_FIELD, typeof (object));

                string sl = selectedList;
                EnumerableRowCollection<DataRow> dataRows = from r in myWorkDtRows
                                                            where r.Field<string>("WorkType").Equals(sl)
                                                            select r;

                foreach (DataRow dataRow in dataRows)
                {
                    DataRow row = dataTable.NewRow();

                    foreach (string selectedField in myWorkFields)
                    {
                        row[selectedField] = GetMyWorkFieldValue(selectedField, dataRow, colDict, fieldsTableRows,
                                                                 flagsTable);
                    }

                    bool workingOn = false;

                    string key = dataRow["ListId"].ToString().ToUpper();

                    key = key.Replace("{", string.Empty);
                    key = key.Replace("}", string.Empty);

                    if (workingOnDict.ContainsKey(key))
                    {
                        if (workingOnDict[key].Contains(dataRow["ItemId"].ToString()))
                        {
                            workingOn = true;
                        }
                    }

                    row[WORKING_ON_FIELD] = workingOn;

                    dataTable.Rows.Add(row);
                }

                tables.Add(dataTable);
            }

            return tables;
        }

        /// <summary>
        ///     Gets the data from SP.
        /// </summary>
        /// <param name="selectedListIds">The selected list ids.</param>
        /// <param name="dataQuery">The data query.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="spSite">The sp site.</param>
        /// <param name="archivedWebs">The archived webs.</param>
        /// <param name="selectedLists">The selected lists.</param>
        /// <returns></returns>
        private static IEnumerable<DataTable> GetDataFromSP(List<string> selectedListIds, SPSiteDataQuery dataQuery,
                                                            SPWeb spWeb, SPSite spSite,
                                                            List<Guid> archivedWebs, IEnumerable<string> selectedLists)
        {
            var locker = new object();
            var eventWaitHandles = new List<EventWaitHandle>();

            var dataTables = new List<DataTable>();
            bool spExceptionOccured = false;

            foreach (string selectedList in selectedLists.Distinct().OrderBy(l => l))
            {
                string theSelectedList = selectedList;
                string listIds = string.Empty;

                foreach (
                    string listId in GetListIdsFromDb(selectedList, spWeb, archivedWebs)
                        .Where(listId => !selectedListIds.Contains(listId)))
                {
                    selectedListIds.Add(listId);
                    listIds += string.Format(@"<List ID='{0}'/>", listId);
                }

                if (string.IsNullOrEmpty(listIds)) continue;

                dataQuery.Lists = string.Format("<Lists MaxListLimit='0'>{0}</Lists>",
                                                listIds);

                var url = (string) spSite.Url.Clone();
                var id = new Guid(spWeb.ID.ToString());
                SPUserToken spUserToken = spWeb.CurrentUser.UserToken;

                var spSiteDataQuery = new SPSiteDataQuery
                    {
                        Webs = dataQuery.Webs,
                        Query = dataQuery.Query,
                        QueryThrottleMode =
                            dataQuery.QueryThrottleMode,
                        ViewFields = dataQuery.ViewFields,
                        Lists = dataQuery.Lists
                    };

                var eventWaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
                eventWaitHandles.Add(eventWaitHandle);

                string list = selectedList;
                var thread = new Thread(() =>
                    {
                        try
                        {
                            DataTable dataTable = QueryMyWorkData(spSiteDataQuery, url, id,
                                                                  spUserToken);
                            dataTable.TableName = list;

                            lock (locker)
                            {
                                dataTables.Add(dataTable);
                            }
                        }
                        catch (SPException ex)
                        {
                            spExceptionOccured = true;
                        }

                        eventWaitHandle.Set();
                    }) {Name = theSelectedList, IsBackground = true};

                thread.Start();
            }

            WaitHandle.WaitAll(eventWaitHandles.ToArray());

            if (spExceptionOccured)
            {
                throw new APIException(2016, "Cannot run the SP site data query.");
            }

            var dictWorkingOn = new Dictionary<string, List<string>>();

            foreach (DataRow dataRow in GetWorkingOn(spWeb).Rows)
            {
                string key = dataRow["ListId"].ToString().ToUpper();

                key = key.Replace("{", string.Empty);
                key = key.Replace("}", string.Empty);

                if (!dictWorkingOn.ContainsKey(key))
                {
                    dictWorkingOn.Add(key, new List<string>());
                }

                dictWorkingOn[key].Add(dataRow["ItemId"].ToString());
            }

            foreach (DataTable dataTable in dataTables.Where(dataTable => dataTable.Rows.Count > 0))
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    bool workingOn = false;

                    string key = dataRow["ListId"].ToString().ToUpper();

                    key = key.Replace("{", string.Empty);
                    key = key.Replace("}", string.Empty);

                    if (dictWorkingOn.ContainsKey(key))
                    {
                        if (dictWorkingOn[key].Contains(dataRow["ID"].ToString()))
                        {
                            workingOn = true;
                        }
                    }

                    dataRow[WORKING_ON_FIELD] = workingOn;
                }
            }

            return dataTables;
        }

        private static string GetExampleDateFormat(SPWeb web, string yearLabel, string monthLabel, string dayLabel)
        {
            string format = string.Empty;

            SPContext context = SPContext.GetContext(web);

            SPRegionalSettings spRegionalSettings = context.Web.CurrentUser.RegionalSettings ?? context.RegionalSettings;

            string dateSeparator = spRegionalSettings.DateSeparator;
            var calendarOrderType = (SPCalendarOrderType) spRegionalSettings.DateFormat;

            switch (calendarOrderType)
            {
                case SPCalendarOrderType.MDY:
                    format = monthLabel + dateSeparator + dayLabel + dateSeparator + yearLabel;
                    break;
                case SPCalendarOrderType.DMY:
                    format = dayLabel + dateSeparator + monthLabel + dateSeparator + yearLabel;
                    break;
                case SPCalendarOrderType.YMD:
                    format = yearLabel + dateSeparator + monthLabel + dateSeparator + dayLabel;
                    break;
            }

            return format;
        }

        /// <summary>
        ///     Gets the grid safe value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        private static string GetGridSafeValue(XElement field)
        {
            string value = Utils.GetCleanFieldValue(field);
            string name = field.Attribute("Name").Value;

            if (field.Attribute("Format").Value.Equals("Indicator")) value = "/_layouts/images/" + value;

            if (name.Equals(COMMENT_COUNT_FIELD))
                value = !string.IsNullOrEmpty(value)
                            ? decimal.Truncate(Convert.ToDecimal(value, new CultureInfo("")))
                                     .ToString(CultureInfo.InvariantCulture)
                            : string.Empty;

            if (name.Equals("Priority"))
            {
                double priority;
                if (double.TryParse(value, out priority)) value = String.Format("{0:0.##########}", priority);
            }
            else
            {
                string type = field.Attribute("Type").Value;
                if (type.Equals("Number"))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            SPWeb spWeb = SPContext.Current.Web;
                            value = Decimal.Parse(value,
                                                  new CultureInfo(
                                                      (int)
                                                      (spWeb.CurrentUser.RegionalSettings ?? spWeb.RegionalSettings).
                                                          LocaleId))
                                           .ToString(CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                        }
                    }
                }
                else if (type.Contains("Date"))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            value = DateTime.Parse(value).ToString("yyyy-M-d HH:mm:ss");
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return value;
        }

        /// <summary>
        ///     Gets the left cols.
        /// </summary>
        /// <param name="myWorkGridView">My work grid view.</param>
        /// <returns></returns>
        private static string GetLeftCols(MyWorkGridView myWorkGridView)
        {
            var leftCols = new List<string>();

            foreach (string col in myWorkGridView.LeftCols.Split(','))
            {
                string[] c = col.Split(':');
                string width = c[1];

                switch (c[0])
                {
                    case "Complete":
                        width = COMPLETE_COL_WIDTH;
                        break;
                    case "CommentCount":
                        width = COMMENT_COL_WIDTH;
                        break;
                    case "Priority":
                        width = PRIORITY_COL_WIDTH;
                        break;
                }

                leftCols.Add(string.Format("{0}:{1}", c[0], width));
            }

            return string.Join(",", leftCols.ToArray());
        }

        /// <summary>
        ///     Gets my work element.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static XElement GetMyWorkElement(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new APIException(2061, "No parameters specified.");

            XDocument xDocument = XDocument.Parse(data);

            if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("MyWork")))
                throw new APIException(2062, "Cannot find element: MyWork");

            return xDocument.Element("MyWork");
        }

        /// <summary>
        ///     Gets my work field value.
        /// </summary>
        /// <param name="myWorkField">My work field.</param>
        /// <param name="myWorkDataRow">My work data row.</param>
        /// <param name="colDict">The col dict.</param>
        /// <param name="fieldsTableRows">The fields table rows.</param>
        /// <param name="flagsTable">The flags table.</param>
        /// <returns></returns>
        private static object GetMyWorkFieldValue(string myWorkField, DataRow myWorkDataRow,
                                                  Dictionary<string, int> colDict,
                                                  EnumerableRowCollection<DataRow> fieldsTableRows, DataTable flagsTable)
        {
            object value = null;

            object listId = myWorkDataRow["ListId"];

            if (!myWorkField.ToLower().Equals("flag"))
            {
                int colInfo = colDict[myWorkField];

                if (colInfo == 1)
                {
                    value = myWorkDataRow[myWorkField];
                }
                else if (colInfo == 2)
                {
                    var lstId = new Guid(listId.ToString());
                    string sf = myWorkField;

                    DataRow field = (from r in fieldsTableRows
                                     where
                                         r.Field<Guid>("ListId") == lstId &&
                                         r.Field<string>("InternalName").Equals(sf)
                                     select r).FirstOrDefault();

                    if (field != null)
                    {
                        string spType = field["SharePointType"].ToString();

                        if (spType.Equals("Lookup") || spType.Equals("User"))
                        {
                            object idValue = myWorkDataRow[myWorkField + "ID"];
                            object textValue = myWorkDataRow[myWorkField + "Text"];

                            if (idValue == null || idValue == DBNull.Value || textValue == null ||
                                textValue == DBNull.Value)
                            {
                                value = string.Empty;
                            }
                            else
                            {
                                string[] ids = idValue.ToString().Split(',');
                                string[] values = textValue.ToString().Split(',');

                                var list = new List<string>();

                                for (int i = 0; i < ids.Count(); i++)
                                {
                                    try
                                    {
                                        list.Add(ids[i]);
                                        list.Add(values[i]);
                                    }
                                    catch
                                    {
                                    }
                                }

                                value = string.Join(";#", list.ToArray());
                            }
                        }
                    }
                }
            }
            else
            {
                value = 0;

                DataRow result = flagsTable.Rows.Find(new[] {listId, myWorkDataRow["ItemId"]});
                if (result != null)
                {
                    value = result["Value"];

                    if (value == null || value == DBNull.Value) value = 0;
                }
            }

            return value;
        }

        /// <summary>
        ///     Gets my work grid view.
        /// </summary>
        /// <param name="xDocument">The x document.</param>
        /// <returns></returns>
        private static MyWorkGridView GetMyWorkGridView(XDocument xDocument)
        {
            if (!xDocument.Elements().ToList().Exists(e => e.Name.LocalName.Equals("MyWork")))
                throw new Exception("Cannot find MyWork element.");
            XElement myWorkElement = xDocument.Element("MyWork");

            if (!myWorkElement.Elements().ToList().Exists(e => e.Name.LocalName.Equals("View")))
                throw new Exception("Cannot find View element.");
            XElement viewElement = myWorkElement.Element("View");

            foreach (
                string attribute in
                    new[]
                        {
                            "ID", "Name", "Default", "Personal", "LeftCols", "Cols", "RightCols", "Filters", "Grouping",
                            "Sorting"
                        }
                        .Where(
                            attribute =>
                            !viewElement.Attributes().ToList().Exists(a => a.Name.LocalName.Equals(attribute))))
            {
                throw new Exception("Cannot find attribute " + attribute);
            }

            return new MyWorkGridView
                {
                    Id = viewElement.Attribute("ID").Value,
                    Name = viewElement.Attribute("Name").Value,
                    Default = Convert.ToBoolean(viewElement.Attribute("Default").Value),
                    Personal = Convert.ToBoolean(viewElement.Attribute("Personal").Value),
                    LeftCols = viewElement.Attribute("LeftCols").Value,
                    Cols = viewElement.Attribute("Cols").Value,
                    RightCols = viewElement.Attribute("RightCols").Value,
                    Filters = viewElement.Attribute("Filters").Value,
                    Grouping = viewElement.Attribute("Grouping").Value,
                    Sorting = viewElement.Attribute("Sorting").Value
                };
        }

        /// <summary>
        ///     Gets my work item element.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static XElement GetMyWorkItemElement(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new APIException(2051, "No parameters specified.");

            XDocument xDocument = XDocument.Parse(data);

            if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("MyWorkItem")))
                throw new APIException(2052, "Cannot find element: MyWorkItem");

            return xDocument.Element("MyWorkItem");
        }

        /// <summary>
        ///     Gets my work list ids from db.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="archivedWebs">The archived webs.</param>
        /// <param name="selectedListIds">The selected list ids.</param>
        /// <returns></returns>
        private static IEnumerable<Guid> GetMyWorkListIdsFromDb(SPWeb spWeb, List<Guid> archivedWebs,
                                                                List<string> selectedListIds)
        {
            try
            {
                var listIds = new List<Guid>();

                using (SqlConnection sqlConnection = GetSpContentDbSqlConnection(spWeb))
                {
                    string webUrl = spWeb.ServerRelativeUrl;
                    webUrl = webUrl.Equals("/") ? string.Empty : webUrl.Substring(1);

                    string archivedWebString = string.Join(",",
                                                           archivedWebs.Select(
                                                               archivedWeb => string.Format("'{0}'", archivedWeb)).
                                                                        ToArray());
                    string selectedListString = string.Join(",",
                                                            selectedListIds.Select(
                                                                selectedList => string.Format("'{0}'", selectedList)).
                                                                            ToArray());

                    string queryString =
                        @"
                            SELECT      dbo.AllLists.tp_ID 
                            FROM        dbo.Webs 
                            INNER JOIN  dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId 
                            WHERE ";

                    queryString += string.IsNullOrEmpty(webUrl)
                                       ? string.Format(@"(dbo.Webs.SiteId = '{0}')", spWeb.Site.ID)
                                       : string.Format(
                                           @"(dbo.Webs.FullUrl LIKE '{0}/%' OR dbo.Webs.FullUrl = '{0}')", webUrl);

                    if (archivedWebs.Count > 0)
                        queryString += string.Format(@" AND (dbo.AllLists.tp_WebId NOT IN ({0}))", archivedWebString);
                    if (selectedListIds.Count > 0)
                        queryString += string.Format(@" AND (dbo.AllLists.tp_ID NOT IN ({0}))", selectedListString);

                    queryString += string.Format(@" AND (dbo.AllLists.tp_ServerTemplate = {0})",
                                                 MY_WORK_LIST_SERVER_TEMPLATE_ID);

                    using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            listIds.Add(sqlDataReader.GetGuid(0));
                        }

                        sqlConnection.Close();
                    }
                }

                return listIds;
            }
            catch (SqlException sqlException)
            {
                throw new APIException(2021, sqlException.Message);
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2022, e.Message);
            }
        }

        /// <summary>
        ///     Gets the personal views.
        /// </summary>
        /// <param name="configWeb">The config web.</param>
        /// <returns></returns>
        private static IEnumerable<MyWorkGridView> GetPersonalViews(SPWeb configWeb)
        {
            try
            {
                var myWorkGridViews = new List<MyWorkGridView>();

                using (var spSite = new SPSite(configWeb.Site.ID))
                {
                    using (
                        var sqlConnection =
                            new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        string queryString = @"SELECT Value FROM dbo.PERSONALIZATIONS WHERE ([Key] = N'" +
                                             MY_WORK_GRID_PERSONAL_VIEWS + "') AND (UserId = N'"
                                             + SPContext.Current.Web.CurrentUser.ID + "') AND (SiteId LIKE N'" +
                                             spSite.ID + "')";

                        using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                        {
                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                                var serializedPersonalViews = sqlCommand.ExecuteScalar() as string;

                                if (!string.IsNullOrEmpty(serializedPersonalViews))
                                {
                                    var xmlSerializer = new XmlSerializer(typeof (List<MyWorkGridView>));
                                    return
                                        (IEnumerable<MyWorkGridView>)
                                        xmlSerializer.Deserialize(new StringReader(serializedPersonalViews));
                                }
                            }
                            catch (SqlException sqlException)
                            {
                                throw new APIException(2083, sqlException.Message);
                            }
                            finally
                            {
                                sqlConnection.Close();
                            }
                        }
                    }
                }

                return myWorkGridViews;
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2082, e.Message);
            }
        }

        /// <summary>
        ///     Gets the query.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static string GetQuery(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                XDocument xDocument = XDocument.Parse(data);
                if (xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("MyWork")))
                {
                    if (xDocument.Element("MyWork").Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Query")))
                    {
                        if (
                            xDocument.Element("MyWork").Element("Query").Descendants().ToList().Exists(
                                e => e.Name.LocalName.Equals("Where")))
                            return xDocument.Element("MyWork").Element("Query").Element("Where").ToString()
                                            .Replace("<Where>", string.Empty).Replace("</Where>", string.Empty)
                                            .Replace("<Where/>", string.Empty).Replace("<Where />", string.Empty);
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        ///     Gets the settings.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="selectedFields">The selected fields.</param>
        /// <param name="selectedLists">The selected lists.</param>
        /// <param name="siteUrls">The site urls.</param>
        /// <param name="performanceMode">
        ///     if set to <c>true</c> [performance mode].
        /// </param>
        /// <param name="noListsSelected">
        ///     if set to <c>true</c> [no lists selected].
        /// </param>
        private static void GetSettings(string data, ref List<string> selectedFields, ref List<string> selectedLists,
                                        ref List<string> siteUrls, ref bool performanceMode, ref bool noListsSelected)
        {
            try
            {
                bool fieldsSupplied = false;
                bool myWorkListsSupplied = false;
                bool listsSupplied = false;
                bool siteUrlsSupplied = false;
                bool performanceModeSupplied = false;

                if (!string.IsNullOrEmpty(data))
                {
                    XDocument xDocument = XDocument.Parse(data);
                    if (xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("MyWork")))
                    {
                        if (
                            xDocument.Element("MyWork").Descendants().ToList().Exists(
                                e => e.Name.LocalName.Equals("Lists")))
                        {
                            selectedLists.AddRange(xDocument.Element("MyWork").Element("Lists").Value.Split(new[] {','})
                                                            .Where(list => !string.IsNullOrEmpty(list)));

                            listsSupplied = true;
                        }

                        if (
                            xDocument.Element("MyWork").Descendants().ToList().Exists(
                                e => e.Name.LocalName.Equals("MyWorkLists")))
                        {
                            selectedLists.AddRange(xDocument.Element("MyWork").Element("MyWorkLists").Value.Split(
                                new[] {','})
                                                            .Where(list => !string.IsNullOrEmpty(list)));

                            myWorkListsSupplied = true;
                        }

                        if (
                            xDocument.Element("MyWork").Descendants().ToList().Exists(
                                e => e.Name.LocalName.Equals("Fields")))
                        {
                            selectedFields.AddRange(xDocument.Element("MyWork").Element("Fields").Value.Split(new[]
                                {','})
                                                             .Where(field => !string.IsNullOrEmpty(field)));

                            fieldsSupplied = true;
                        }

                        if (
                            xDocument.Element("MyWork").Descendants().ToList().Exists(
                                e => e.Name.LocalName.Equals("CrossSiteUrls")))
                        {
                            if (!string.IsNullOrEmpty(xDocument.Element("MyWork").Element("CrossSiteUrls").Value))
                            {
                                siteUrls.AddRange(xDocument.Element("MyWork").Element("CrossSiteUrls").Value.Split(
                                    new[] {','})
                                                           .Where(crossSite => !string.IsNullOrEmpty(crossSite)));

                                siteUrlsSupplied = true;
                            }
                        }

                        if (
                            xDocument.Element("MyWork").Descendants().ToList().Exists(
                                e => e.Name.LocalName.Equals("PerformanceMode")))
                        {
                            performanceMode = xDocument.Element("MyWork").Element("PerformanceMode").Value.Equals("on");
                            performanceModeSupplied = true;
                        }
                    }
                }

                SPWeb theWeb = SPContext.Current.Web;
                Guid lockedWeb = CoreFunctions.getLockedWeb(theWeb);
                using (SPWeb configWeb = Utils.GetConfigWeb(theWeb, lockedWeb))
                {
                    if (!listsSupplied)
                        selectedLists.AddRange(
                            CoreFunctions.getConfigSetting(configWeb, GENERAL_SETTINGS_SELECTED_LISTS)
                                         .Split(new[] {','}));

                    if (!myWorkListsSupplied)
                        selectedLists.AddRange(
                            CoreFunctions.getConfigSetting(configWeb, GENERAL_SETTINGS_SELECTED_MY_WORK_LISTS)
                                         .Split(new[] {','}));

                    if (!fieldsSupplied)
                        selectedFields.AddRange(
                            CoreFunctions.getConfigSetting(configWeb, GENERAL_SETTINGS_SELECTED_FIELDS).Split(new[]
                                {','}));

                    if (!siteUrlsSupplied)
                    {
                        if (
                            !string.IsNullOrEmpty(CoreFunctions.getConfigSetting(configWeb,
                                                                                 GENERAL_SETTINGS_CROSS_SITE_URLS)))
                        {
                            siteUrls.AddRange(CoreFunctions.getConfigSetting(configWeb, GENERAL_SETTINGS_CROSS_SITE_URLS)
                                                           .Split(new[] {'|'}));
                        }
                        else siteUrls.Add(SPContext.Current.Web.Url);
                    }

                    if (!performanceModeSupplied)
                        performanceMode = CoreFunctions.getConfigSetting(configWeb, GENERAL_SETTINGS_PERFORMANCE_MODE)
                                                       .Equals("on");
                }

                selectedLists.RemoveAll(string.IsNullOrEmpty);
                noListsSelected = selectedLists.Count == 0;

                selectedFields.RemoveAll(string.IsNullOrEmpty);

                var fieldsToRemove = new[] {WORK_TYPE_FIELD, LIST_ID_FIELD, WEB_ID_FIELD, SITE_ID_FIELD, SITE_URL_FIELD};
                foreach (string field in fieldsToRemove)
                {
                    selectedFields.RemoveAll(f => f.ToLower().Equals(field.ToLower()));
                }

                var fixedFields = new[]
                    {
                        COMPLETED_FIELD, COMMENT_COUNT_FIELD, PRIORITY_FIELD, FLAG_FIELD, TITLE_FIELD,
                        DUE_DATE_FIELD,
                        CREATED_FIELD, CREATED_BY_FIELD, MODIFIED_FIELD, MODIFIED_BY_FIELD,
                        COMMENTERS_FIELD,
                        COMMENTERS_READ_FIELD
                    };

                foreach (string fixedField in fixedFields)
                {
                    string field = fixedField;
                    if (!selectedFields.Exists(f => f.Equals(field))) selectedFields.Add(field);
                }
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2007, e.Message);
            }
        }

        /// <summary>
        ///     Gets the type and format.
        /// </summary>
        /// <param name="fieldTypes">The field types.</param>
        /// <param name="selectedField">The selected field.</param>
        /// <param name="type">The type.</param>
        /// <param name="format">The format.</param>
        private static void GetTypeAndFormat(Dictionary<string, SPField> fieldTypes, string selectedField,
                                             out string type, out string format)
        {
            type = string.Empty;
            format = string.Empty;

            if (!fieldTypes.ContainsKey(selectedField)) return;

            SPField field = fieldTypes[selectedField];

            format = Utils.GetFormat(field);
            type = field.Type.ToString();
        }

        /// <summary>
        ///     Gets the working on.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        private static DataTable GetWorkingOn(SPWeb spWeb)
        {
            const string sql = @"SELECT dbo.TagOrders.ItemId, dbo.TagOrders.ListId, dbo.Tags.SiteId
                                        FROM dbo.TagOrders INNER JOIN dbo.Tags ON dbo.TagOrders.TagId = dbo.Tags.TagId
                                        WHERE (dbo.Tags.Name = N'WorkingOn') AND (dbo.Tags.ResourceId = @ResourceId) AND (dbo.Tags.SiteId = @SiteId)";

            var queryExecutor = new QueryExecutor(spWeb);

            return queryExecutor.ExecuteEpmLiveQuery(sql,
                                                     new Dictionary<string, object>
                                                         {
                                                             {"@ResourceId", spWeb.CurrentUser.ID},
                                                             {"@SiteId", spWeb.Site.ID}
                                                         });
        }

        /// <summary>
        ///     Gets the working on.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static DataTable GetWorkingOn(string data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the workspace name from db.
        /// </summary>
        /// <param name="webId">The web id.</param>
        /// <param name="siteUrl">The site URL.</param>
        /// <returns></returns>
        private static string GetWorkspaceNameFromDb(Guid webId, string siteUrl)
        {
            try
            {
                using (var spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                    {
                        using (SqlConnection sqlConnection = GetSpContentDbSqlConnection(spWeb))
                        {
                            string queryString = string.Format(@"SELECT Title FROM Webs WHERE Id = @webId");

                            using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@webId", webId);

                                string workspaceName = string.Empty;

                                SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                                workspaceName = sqlCommand.ExecuteScalar() as string;

                                sqlConnection.Close();


                                return workspaceName;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw new APIException(2010, sqlException.Message);
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2011, e.Message);
            }
        }

        /// <summary>
        ///     Maps the complete field.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="myWorkReportData">My work report data.</param>
        private static void MapCompleteField(SPWeb spWeb, MyWorkReportData myWorkReportData)
        {
            using (var spSite = new SPSite(spWeb.Site.ID))
            {
                using (SPWeb web = spSite.OpenWeb(CoreFunctions.getLockedWeb(spWeb)))
                {
                    bool added;
                    bool.TryParse(CoreFunctions.getConfigSetting(web, "EPMLive_MyWork_CompleteFieldAdded"), out added);

                    if (added) return;

                    string query =
                        string.Format(
                            @"SELECT DISTINCT   dbo.RPTList.RPTListId AS ListId, dbo.RPTColumn.InternalName AS Col 
                                     FROM       dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId
                                     WHERE      (dbo.RPTList.ListName = N'My Work') AND (dbo.RPTList.SiteId = '{0}')",
                            spWeb.Site.ID);

                    DataTable table = myWorkReportData.ExecuteSql(query);
                    table.PrimaryKey = new[] {table.Columns["ListId"], table.Columns["Col"]};

                    object listId = table.Rows[0]["ListId"];

                    DataRow row = table.Rows.Find(new[] {listId, "Complete"});

                    if (row == null)
                    {
                        try
                        {
                            var columnDefs = new List<ColumnDef>
                                {
                                    new ColumnDef("Complete", "Complete", "Complete",
                                                  SPFieldType.Boolean, SqlDbType.Bit)
                                };

                            myWorkReportData.InsertListColumns((Guid) listId, columnDefs);
                            myWorkReportData.AddColumns("LSTMyWork", columnDefs);
                        }
                        catch
                        {
                            throw new APIException(2014,
                                                   "Unable to map MyWork 'Complete' column to the Reporting Database.");
                        }
                    }

                    CoreFunctions.setConfigSetting(web, "EPMLive_MyWork_CompleteFieldAdded", true.ToString());
                }
            }
        }

        /// <summary>
        ///     Processes my work.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="spSite">The sp site.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="selectedFields">The selected fields.</param>
        /// <param name="fieldTypes">The field types.</param>
        /// <param name="workTypes">The work types.</param>
        /// <param name="workspaces">The workspaces.</param>
        /// <param name="result">The result.</param>
        private static void ProcessMyWork(DataTable dataTable, SPSite spSite, SPWeb spWeb,
                                          IEnumerable<string> selectedFields, Dictionary<string, SPField> fieldTypes,
                                          Dictionary<string, string> workTypes, Dictionary<string, string> workspaces,
                                          ref XDocument result)
        {
            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string listId = Utils.CleanGuid(dataRow[LIST_ID_FIELD]);
                    string webId = Utils.CleanGuid(dataRow[WEB_ID_FIELD]);
                    string siteUrl = spSite.Url;

                    string uniqueId = (listId + webId + spSite.ID).Md5();

                    DataRow row = dataRow;

                    var fieldsElement = new XElement("Fields");

                    foreach (string selectedField in selectedFields)
                    {
                        string value = row[selectedField] == null || row[selectedField] == DBNull.Value
                                           ? string.Empty
                                           : row[selectedField].ToString();

                        if (selectedField.Equals("Author"))
                        {
                            string authorId = string.Empty;
                            if (!string.IsNullOrEmpty(authorId)) authorId = value.Split(';')[0];
                            var authorIdFieldElement = new XElement("Field", new XCData(authorId));
                            authorIdFieldElement.Add(new XAttribute("Name", "AuthorID"));
                            authorIdFieldElement.Add(new XAttribute("Type", string.Empty));
                            authorIdFieldElement.Add(new XAttribute("Format", string.Empty));

                            fieldsElement.Add(authorIdFieldElement);
                        }

                        string type;
                        string format;

                        GetTypeAndFormat(fieldTypes, selectedField, out type, out format);

                        if (selectedField.Equals("Complete"))
                        {
                            value = value.Equals("True") ? "1" : "0";
                        }

                        var fieldElement = new XElement("Field", new XCData(value));
                        fieldElement.Add(new XAttribute("Name", selectedField));
                        fieldElement.Add(new XAttribute("Type", type));
                        fieldElement.Add(new XAttribute("Format", format));

                        fieldsElement.Add(fieldElement);
                    }

                    Guid siteId = spSite.ID;

                    var itemElement = new XElement("Item");
                    itemElement.Add(new XAttribute("ID", Utils.CleanGuid(dataRow["ID"]).ToUpper()));
                    itemElement.Add(new XAttribute("ListID", listId.ToUpper()));
                    itemElement.Add(new XAttribute("WebID", webId.ToUpper()));
                    itemElement.Add(new XAttribute("SiteID", siteId.ToString().ToUpper()));
                    itemElement.Add(new XAttribute("SiteURL", siteUrl));

                    if (!workTypes.ContainsKey(uniqueId))
                        workTypes.Add(uniqueId, GetListNameFromDb(new Guid(listId), new Guid(webId), spWeb));
                    itemElement.Add(new XAttribute(WORK_TYPE_FIELD, workTypes[uniqueId]));

                    if (!workspaces.ContainsKey(uniqueId))
                        workspaces.Add(uniqueId, GetWorkspaceNameFromDb(new Guid(webId), siteUrl));
                    itemElement.Add(new XAttribute("Workspace", workspaces[uniqueId]));

                    itemElement.Add(fieldsElement);

                    itemElement.Add(new XAttribute(WORKING_ON_FIELD, row[WORKING_ON_FIELD]));

                    result.Element("MyWork").Add(itemElement);
                }
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2009, e.Message);
            }
        }

        /// <summary>
        ///     Queries my work data.
        /// </summary>
        /// <param name="dataQuery">The data query.</param>
        /// <param name="siteUrl">The site URL.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="userToken">The user token.</param>
        /// <returns></returns>
        private static DataTable QueryMyWorkData(SPSiteDataQuery dataQuery, string siteUrl, Guid webId,
                                                 SPUserToken userToken)
        {
            DataTable dataTable = null;
            using (var spSite = new SPSite(siteUrl, userToken))
            {
                using (SPWeb spWeb = spSite.OpenWeb(webId))
                {
                    SPSecurity.RunWithElevatedPrivileges(() => { dataTable = spWeb.GetSiteData(dataQuery); });
                }
            }

            return dataTable;
        }

        /// <summary>
        ///     Renames the global view.
        /// </summary>
        /// <param name="viewId">The view id.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="globalViews">The global views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void RenameGlobalView(string viewId, string viewName, IEnumerable<MyWorkGridView> globalViews,
                                             SPWeb configWeb)
        {
            List<MyWorkGridView> myWorkGridViews = globalViews.ToList();
            foreach (
                MyWorkGridView myWorkGridView in
                    myWorkGridViews.Where(myWorkGridView => myWorkGridView.Id.Equals(viewId)))
            {
                myWorkGridView.Name = viewName;
            }

            SaveGlobalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Renames the personal view.
        /// </summary>
        /// <param name="viewId">The view id.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="personalViews">The personal views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void RenamePersonalView(string viewId, string viewName, IEnumerable<MyWorkGridView> personalViews,
                                               SPWeb configWeb)
        {
            List<MyWorkGridView> myWorkGridViews = personalViews.ToList();
            foreach (
                MyWorkGridView myWorkGridView in
                    myWorkGridViews.Where(myWorkGridView => myWorkGridView.Id.Equals(viewId)))
            {
                myWorkGridView.Name = viewName;
            }

            SavePersonalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Saves the global views.
        /// </summary>
        /// <param name="myWorkGridViews">My work grid views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void SaveGlobalViews(IEnumerable<MyWorkGridView> myWorkGridViews, SPWeb configWeb)
        {
            try
            {
                var stringWriter = new StringWriter();
                var xmlSerializer = new XmlSerializer(typeof (List<MyWorkGridView>));
                xmlSerializer.Serialize(stringWriter, myWorkGridViews);
                stringWriter.Close();

                SPSecurity.RunWithElevatedPrivileges(() =>
                    {
                        configWeb.AllowUnsafeUpdates = true;
                        CoreFunctions.setConfigSetting(configWeb,
                                                       MY_WORK_GRID_GLOBAL_VIEWS,
                                                       stringWriter.ToString());
                        configWeb.AllowUnsafeUpdates = false;
                    });
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2094, e.Message);
            }
        }

        /// <summary>
        ///     Saves the personal views.
        /// </summary>
        /// <param name="myWorkGridViews">My work grid views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void SavePersonalViews(IEnumerable<MyWorkGridView> myWorkGridViews, SPWeb configWeb)
        {
            try
            {
                using (var spSite = new SPSite(configWeb.Site.ID))
                {
                    using (
                        var sqlConnection =
                            new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        string queryString = @"DELETE FROM PERSONALIZATIONS WHERE ([Key] = '" +
                                             MY_WORK_GRID_PERSONAL_VIEWS +
                                             "' AND [UserId] = '"
                                             + SPContext.Current.Web.CurrentUser.ID + "' AND [SiteId] = '" + spSite.ID +
                                             "')";

                        using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                        {
                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                                sqlCommand.ExecuteNonQuery();
                            }
                            catch (SqlException sqlException)
                            {
                                throw new APIException(2092, sqlException.Message);
                            }
                            finally
                            {
                                sqlConnection.Close();
                            }
                        }

                        queryString =
                            @"INSERT INTO PERSONALIZATIONS ([Key], [Value], [UserId], [SiteId]) VALUES (@key, @value, @userId, @siteId)";

                        using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                        {
                            try
                            {
                                var xmlSerializer = new XmlSerializer(typeof (List<MyWorkGridView>));
                                var stringWriter = new StringWriter();
                                xmlSerializer.Serialize(stringWriter, myWorkGridViews);

                                sqlCommand.Parameters.AddWithValue("@key", MY_WORK_GRID_PERSONAL_VIEWS);
                                sqlCommand.Parameters.AddWithValue("@value", stringWriter.ToString());
                                sqlCommand.Parameters.AddWithValue("@userId", SPContext.Current.Web.CurrentUser.ID);
                                sqlCommand.Parameters.AddWithValue("@siteId", spSite.ID);

                                stringWriter.Close();

                                SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                                sqlCommand.ExecuteNonQuery();
                            }
                            catch (SqlException sqlException)
                            {
                                throw new APIException(2093, sqlException.Message);
                            }
                            finally
                            {
                                sqlConnection.Close();
                            }
                        }
                    }
                }
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2091, e.Message);
            }
        }

        /// <summary>
        ///     Checks if the SiteId col exists in the Tags Reporting DB table.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        private static bool TagSiteIdExists(SPWeb spWeb)
        {
            var queryExecutor = new QueryExecutor(spWeb);

            DataTable resultDt =
                queryExecutor.ExecuteReportingDBQuery(
                    "SELECT * FROM sys.columns WHERE Name = N'SiteId' AND Object_ID = Object_ID(N'Tags')",
                    new Dictionary<string, object>());

            return resultDt.Rows.Count > 0;
        }

        /// <summary>
        ///     Writes to debug window.
        /// </summary>
        /// <param name="message">The message.</param>
        private static void WriteToDebugWindow(string message)
        {
            Debug.WriteLine("*** MyWork: " + message);
        }

        // Internal Methods (16) 

        /// <summary>
        ///     Checks the list edit permission.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string CheckListEditPermission(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWork"));

                Guid listId;
                Guid webId;
                Guid siteId;
                string siteUrl;

                XElement myWorkElement = GetMyWorkElement(data);
                Utils.GetListWebSite(data, myWorkElement, out listId, out webId, out siteId, out siteUrl);

                bool hasPermissions = false;

                using (var spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                    {
                        hasPermissions = spWeb.Lists[listId].DoesUserHavePermissions(SPContext.Current.Web.CurrentUser,
                                                                                     SPBasePermissions.EditListItems);
                    }
                }

                result.Element("MyWork").Add(new XElement("HasEditPermission", hasPermissions));

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2045, e.Message);
            }
        }

        /// <summary>
        ///     Deletes my work grid view.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string DeleteMyWorkGridView(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWork"));

                XDocument xDocument = XDocument.Parse(data);

                SPWeb configWeb = Utils.GetConfigWeb();

                if (!xDocument.Elements().ToList().Exists(e => e.Name.LocalName.Equals("MyWork")))
                    throw new Exception("Cannot find MyWork element.");
                XElement myWorkElement = xDocument.Element("MyWork");

                if (!myWorkElement.Elements().ToList().Exists(e => e.Name.LocalName.Equals("View")))
                    throw new Exception("Cannot find View element.");
                XElement viewElement = myWorkElement.Element("View");

                foreach (string attribute in new[] {"ID", "Personal"}
                    .Where(
                        attribute => !viewElement.Attributes().ToList().Exists(a => a.Name.LocalName.Equals(attribute)))
                    )
                {
                    throw new Exception("Cannot find attribute " + attribute);
                }

                string viewId = viewElement.Attribute("ID").Value;
                bool isViewPersonal = Convert.ToBoolean(viewElement.Attribute("Personal").Value);

                if (isViewPersonal) DeletePersonalView(viewId, GetPersonalViews(configWeb), configWeb);
                else DeleteGlobalView(viewId, GetGlobalViews(configWeb), configWeb);

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2035, e.Message);
            }
        }

        /// <summary>
        ///     Gets my work.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWork(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWork"));

                string theQuery = GetQuery(data);
                string query = !string.IsNullOrEmpty(theQuery)
                                   ? string.Format(
                                       @"<Where><And>{0}<Eq><FieldRef Name='{1}'/><Value Type='Integer'><UserID/></Value></Eq></And></Where>",
                                       theQuery, ASSIGNED_TO_FIELD)
                                   : string.Format(
                                       @"<Where><Eq><FieldRef Name='{0}'/><Value Type='Integer'><UserID/></Value></Eq></Where>",
                                       ASSIGNED_TO_FIELD);

                var selectedLists = new List<string>();
                var selectedFields = new List<string>();
                var siteUrls = new List<string>();
                bool performanceMode = true;
                bool noListsSelected = true;

                GetSettings(data, ref selectedFields, ref selectedLists, ref siteUrls, ref performanceMode,
                            ref noListsSelected);

                bool processFlag = false;

                foreach (string siteUrl in siteUrls)
                {
                    using (var spSite = new SPSite(siteUrl))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb())
                        {
                            Dictionary<string, SPField> fieldTypes = Utils.GetFieldTypes();

                            var workTypes = new Dictionary<string, string>();
                            var workSpaces = new Dictionary<string, string>();

                            List<Guid> archivedWebs = GetArchivedWebs(spWeb.Site.ID);

                            if (!performanceMode)
                            {
                                GetDataFromLists(result, fieldTypes, query, spSite, spWeb, selectedFields,
                                                 selectedLists);
                            }
                            else
                            {
                                if (ShouldUseReportingDb(spWeb))
                                {
                                    IEnumerable<DataTable> dataTables = GetDataFromReportingDB(workTypes,
                                                                                               selectedFields,
                                                                                               archivedWebs,
                                                                                               spWeb, selectedLists,
                                                                                               data);

                                    if (dataTables != null)
                                    {
                                        foreach (DataTable dataTable in dataTables)
                                        {
                                            ProcessMyWork(dataTable, spSite, spWeb, selectedFields, fieldTypes,
                                                          workTypes, workSpaces, ref result);
                                        }
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        var dataQuery = new SPSiteDataQuery
                                            {
                                                Webs = @"<Webs Scope='Recursive'>",
                                                Query = query,
                                                QueryThrottleMode = SPQueryThrottleOption.Override
                                            };

                                        foreach (string selectedField in selectedFields)
                                        {
                                            dataQuery.ViewFields += string.Format(
                                                @"<FieldRef Name='{0}' Nullable='TRUE'/>", selectedField);
                                        }

                                        foreach (string field in new[] {COMPLETED_FIELD, WORKING_ON_FIELD}
                                            .Where(field => !selectedFields.Exists(f => f.Equals(field))))
                                        {
                                            dataQuery.ViewFields +=
                                                string.Format("<FieldRef Name='{0}' Nullable='TRUE'/>", field);
                                        }

                                        var selectedListIds = new List<string>();

                                        if (!noListsSelected)
                                        {
                                            processFlag = true;
                                            IEnumerable<DataTable> dataTables = GetDataFromSP(selectedListIds,
                                                                                              dataQuery,
                                                                                              spWeb, spSite,
                                                                                              archivedWebs,
                                                                                              selectedLists);

                                            if (dataTables != null)
                                            {
                                                foreach (DataTable dataTable in dataTables)
                                                {
                                                    ProcessMyWork(dataTable, spSite, spWeb, selectedFields,
                                                                  fieldTypes,
                                                                  workTypes, workSpaces, ref result);
                                                }
                                            }
                                        }
                                    }
                                    catch (APIException)
                                    {
                                        throw;
                                    }
                                    catch (Exception e)
                                    {
                                        throw new APIException(2014,
                                                               "Unable to retrieve My Work data from My Work lists.");
                                    }
                                }
                            }
                        }
                    }
                }

                result.Root.Add(new XElement("Params", new XElement("ProcessFlag", processFlag)));

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2000, e.Message);
            }
        }

        /// <summary>
        ///     Gets the type of my work field.
        /// </summary>
        /// <param name="myWorkField">My work field.</param>
        /// <param name="fieldTypes">The field types.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        internal static string GetMyWorkFieldType(MyWorkField myWorkField, Dictionary<string, SPField> fieldTypes,
                                                  out string format)
        {
            string type = "Html";
            format = string.Empty;

            if (fieldTypes.ContainsKey(myWorkField.Name))
            {
                SPField spField = fieldTypes[myWorkField.Name];

                type = Utils.GetRelatedGridType(spField);
                format = Utils.GetFormat(spField);
            }

            return type;
        }

        /// <summary>
        ///     Gets the type of my work grid col.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridColType(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWork"));

                int itemId;
                Guid listId;
                Guid webId;
                Guid siteId;
                string siteUrl;

                XElement myWorkElement = GetMyWorkElement(data);
                Utils.GetItemListWebSite(data, myWorkElement, out itemId, out listId, out webId, out siteId, out siteUrl);

                result.Element("MyWork").Add(new XElement("Fields"));

                XElement xElement = result.Element("MyWork").Element("Fields");
                xElement.Add(new XAttribute("ItemID", itemId));
                xElement.Add(new XAttribute("ListID", listId));
                xElement.Add(new XAttribute("WebID", webId));
                xElement.Add(new XAttribute("SiteID", siteId));
                xElement.Add(new XAttribute("SiteURL", siteUrl));

                bool guessOriginalFieldNameSetting = FieldInfo.GetGuessOriginalFieldNameSetting(myWorkElement);
                using (var spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                    {
                        SPList spList = spWeb.Lists[listId];

                        SPListItem spListItem = spList.GetItemById(itemId);
                        foreach (string field in FieldInfo.GetFields(myWorkElement))
                        {
                            string theField = field;
                            if (guessOriginalFieldNameSetting) theField = Utils.ToOriginalFieldName(theField);

                            if (!spListItem.Fields.ContainsFieldWithInternalName(theField)) continue;

                            var element = new XElement("Field");
                            element.Add(new XAttribute("Name", theField));
                            element.Add(new XAttribute("Type",
                                                       Utils.GetRelatedGridType(
                                                           spListItem.Fields.GetFieldByInternalName(theField))));

                            xElement.Add(element);
                        }
                    }
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2060, e.Message);
            }
        }

        /// <summary>
        ///     Gets my work grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridData(string data)
        {
            try
            {
                string myWork = string.Empty;

                try
                {
                    myWork = GetMyWork(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data)));
                }
                catch (APIException apiException)
                {
                    return string.Format(@"<Grid><IO Result=""-{0}"" Message=""{1}"" /></Grid>",
                                         apiException.ExceptionNumber, apiException.Message);
                }

                var result = new XDocument();

                result.Add(new XElement("Grid"));

                XElement grid = result.Element("Grid");

                var selectedLists = new List<string>();
                var selectedFields = new List<string>();
                var siteUrls = new List<string>();
                bool performanceMode = true;
                bool noListSelected = true;

                GetSettings(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data)), ref selectedFields, ref selectedLists,
                            ref siteUrls, ref performanceMode, ref noListSelected);

                grid.Add(new XElement("Body"));
                grid.Element("Body").Add(new XElement("B"));

                XElement body = grid.Element("Body").Element("B");

                XDocument myWorkDocument = XDocument.Parse(myWork);

                bool processFlag;
                bool.TryParse(myWorkDocument.Root.Element("Params").Element("ProcessFlag").Value, out processFlag);

                foreach (XElement item in myWorkDocument.Element("MyWork").Elements("Item"))
                {
                    var i = new XElement("I");

                    string itemId = item.Attribute("ID").Value;
                    string listId = item.Attribute("ListID").Value;
                    string webId = item.Attribute("WebID").Value;
                    string siteId = item.Attribute("SiteID").Value;
                    string siteUrl = item.Attribute("SiteURL").Value;

                    string rowId = (string.Format("{0}-{1}-{2}-{3}", itemId, listId, webId, siteId)).Md5();

                    i.Add(new XAttribute("id", rowId));

                    foreach (XElement field in item.Element("Fields").Elements("Field"))
                    {
                        string name = Utils.ToGridSafeFieldName(field.Attribute("Name").Value);
                        string value = GetGridSafeValue(field);

                        if (name.Equals(DUE_DATE_FIELD) && !string.IsNullOrEmpty(value))
                        {
                            i.Add(new XAttribute(DUE_DAY_FIELD, Convert.ToDateTime(value).ToFriendlyDate()));
                        }

                        string type = field.Attribute("Type").Value;

                        if (type.Equals("Choice") && !string.IsNullOrEmpty(value))
                        {
                            string enumKeys = string.Format("|{0}", value);
                            i.Add(new XAttribute(string.Format("{0}Enum", name), enumKeys));
                            i.Add(new XAttribute(string.Format("{0}EnumKeys", name), enumKeys));
                            i.Add(new XAttribute(string.Format("{0}Range", name), 0));
                        }

                        i.Add(new XAttribute(name, value));
                    }

                    i.Add(new XAttribute(WORKING_ON_FIELD, bool.Parse(item.Attribute(WORKING_ON_FIELD).Value) ? 1 : 0));
                    i.Add(new XAttribute(WORK_TYPE_FIELD, item.Attribute(WORK_TYPE_FIELD).Value));
                    i.Add(new XAttribute("Workspace", item.Attribute("Workspace").Value));

                    if (processFlag)
                    {
                        string flagQuery =
                            string.Format(
                                @"<MyPersonalization><Keys>Flag</Keys><Item ID=""{0}""/><List ID=""{1}""/><Web ID=""{2}""/><Site ID=""{3}"" URL=""{4}""/></MyPersonalization>",
                                itemId, listId, webId, siteId, siteUrl);

                        XDocument xDocument = XDocument.Parse(MyPersonalization.GetMyPersonalization(flagQuery));

                        string flag = "0";

                        if (
                            xDocument.Element("MyPersonalization").Elements().ToList().Exists(
                                e => e.Name.LocalName.Equals("Personalizations")))
                        {
                            flag =
                                (xDocument.Element("MyPersonalization").Element("Personalizations").Elements().ToList()
                                          .Where(e => e.Attribute("Key").Value.Equals(FLAG_FIELD))).FirstOrDefault()
                                                                                                   .Attribute
                                    (
                                        "Value")
                                                                                                   .Value;
                        }

                        if (i.Attribute(FLAG_FIELD) != null) i.Attribute(FLAG_FIELD).Remove();
                        i.Add(new XAttribute(FLAG_FIELD, flag));
                    }

                    if (i.Attribute("Edit") != null) i.Attribute("Edit").Remove();
                    i.Add(new XAttribute("Edit", string.Empty));

                    if (i.Attribute("ItemID") != null) i.Attribute("ItemID").Remove();
                    if (i.Attribute("ListID") != null) i.Attribute("ListID").Remove();
                    if (i.Attribute("WebID") != null) i.Attribute("WebID").Remove();
                    if (i.Attribute("SiteID") != null) i.Attribute("SiteID").Remove();
                    if (i.Attribute("SiteURL") != null) i.Attribute("SiteURL").Remove();

                    i.Add(new XAttribute("ItemID", itemId));
                    i.Add(new XAttribute("ListID", listId));
                    i.Add(new XAttribute("WebID", webId));
                    i.Add(new XAttribute("SiteID", siteId));
                    i.Add(new XAttribute("SiteURL", siteUrl));

                    if (i.Attribute("MaxHeight") != null) i.Attribute("MaxHeight").Remove();
                    i.Add(new XAttribute("MaxHeight", 30));

                    body.Add(i);
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2020, e.Message);
            }
        }

        /// <summary>
        ///     Gets my work grid enum.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridEnum(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWork"));

                int itemId;
                Guid listId;
                Guid webId;
                Guid siteId;
                string siteUrl;

                XElement myWorkElement = GetMyWorkElement(data);
                Utils.GetItemListWebSite(data, myWorkElement, out itemId, out listId, out webId, out siteId, out siteUrl);

                result.Element("MyWork").Add(new XElement("Fields"));

                XElement xElement = result.Element("MyWork").Element("Fields");
                xElement.Add(new XAttribute("ItemID", itemId));
                xElement.Add(new XAttribute("ListID", listId));
                xElement.Add(new XAttribute("WebID", webId));
                xElement.Add(new XAttribute("SiteID", siteId));
                xElement.Add(new XAttribute("SiteURL", siteUrl));

                bool guessOriginalFieldNameSetting = FieldInfo.GetGuessOriginalFieldNameSetting(myWorkElement);

                using (var spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                    {
                        SPList spList = spWeb.Lists[listId];

                        SPListItem spListItem = spList.GetItemById(itemId);
                        foreach (string field in FieldInfo.GetFields(myWorkElement))
                        {
                            string theField = field;
                            if (guessOriginalFieldNameSetting) theField = Utils.ToOriginalFieldName(theField);

                            if (!spListItem.Fields.ContainsFieldWithInternalName(theField)) continue;

                            var element = new XElement("Field");
                            element.Add(new XAttribute("Name", theField));

                            SPField spField = spListItem.Fields.GetFieldByInternalName(theField);

                            string values;
                            int range;
                            string keys;

                            Utils.GetGridEnum(spSite, spField, out values, out range, out keys);

                            element.Add(new XAttribute("Enum", "|" + values));
                            element.Add(new XAttribute("EnumKeys", "|" + keys));
                            element.Add(new XAttribute("Range", range));

                            xElement.Add(element);
                        }
                    }
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2070, e.Message);
            }
        }

        /// <summary>
        ///     Gets my work grid layout.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridLayout(string data)
        {
            try
            {
                SPWeb spWeb = SPContext.Current.Web;

                var selectedLists = new List<string>();
                var selectedFields = new List<string>();
                var siteUrls = new List<string>();
                bool performanceMode = true;
                bool noListSelected = true;

                data = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data));

                GetSettings(data, ref selectedFields, ref selectedLists, ref siteUrls, ref performanceMode,
                            ref noListSelected);

                var fields = new List<MyWorkField>();

                foreach (string field in selectedFields.Where(field => !fields.Exists(f => f.Name.Equals(field))))
                {
                    fields.Add(new MyWorkField {Name = field, DisplayName = field.ToPrettierName(spWeb)});
                }

                XDocument result = XDocument.Parse(Resources.MyWorkGridLayout);

                XElement grid = result.Element("Grid");

                var cfgElement = new XElement("Cfg");

                cfgElement.Add(new XAttribute("id",
                                              XDocument.Parse(data).Element("MyWork").Element("WebPart").Attribute("ID")
                                                       .Value));
                cfgElement.Add(new XAttribute("CSS",
                                              string.Format("{0}/_layouts/epmlive/treegrid/mywork13/grid.css",
                                                            SPContext.Current.Web.Url)));

                grid.Add(cfgElement);

                IEnumerable<XElement> rightColElements = grid.Element("RightCols").Elements("C");

                IEnumerable<string> leftCols =
                    grid.Element("LeftCols").Elements("C").Attributes("Name").Select(a => a.Value);
                IEnumerable<string> centerCols =
                    grid.Element("Cols").Elements("C").Attributes("Name").Select(a => a.Value);
                IEnumerable<string> rightCols = rightColElements.Attributes("Name").Select(a => a.Value);

                Dictionary<string, SPField> fieldTypes = Utils.GetFieldTypes();

                XElement cols = grid.Element("Cols");
                foreach (MyWorkField myWorkField in fields.OrderBy(f => f.DisplayName)
                                                          .Where(myWorkField => !leftCols.Contains(myWorkField.Name))
                                                          .Where(myWorkField => !centerCols.Contains(myWorkField.Name))
                                                          .Where(myWorkField => !rightCols.Contains(myWorkField.Name)))
                {
                    string internalName = myWorkField.Name;

                    string format;
                    string type = GetMyWorkFieldType(myWorkField, fieldTypes, out format);

                    var c = new XElement("C");
                    c.Add(new XAttribute("Name", Utils.ToGridSafeFieldName(internalName)));

                    c.Add(new XAttribute("Type", type));
                    if (!string.IsNullOrEmpty(format))
                    {
                        string relatedGridFormat = GetRelatedGridFormat(type, format, fieldTypes[internalName], spWeb);
                        c.Add(new XAttribute("Format", relatedGridFormat));

                        if (type.Equals("Date") || (type.Equals("Float") && relatedGridFormat.Contains("%")))
                        {
                            c.Add(new XAttribute("EditFormat", relatedGridFormat));
                        }
                    }

                    if (type.Equals("Icon")) c.Add(new XAttribute("IconAlign", "Center"));

                    c.Add(new XAttribute("Visible", 0));

                    if (internalName.Equals(DUE_DATE_FIELD))
                        c.Add(new XAttribute("ClassFormula",
                                             string.Format("calculateDueColor('{0}',Row)", DUE_DATE_FIELD)));

                    cols.Add(c);
                }

                var workTypeCol = new XElement("C");
                workTypeCol.Add(new XAttribute("Name", WORK_TYPE_FIELD));
                workTypeCol.Add(new XAttribute("Type", "Html"));
                workTypeCol.Add(new XAttribute("Visible", 0));

                cols.Add(workTypeCol);

                foreach (XElement rightColElement in rightColElements)
                {
                    cols.Add(rightColElement);
                }

                XElement header = grid.Element("Header");

                foreach (MyWorkField myWorkField in fields.OrderBy(f => f.DisplayName)
                                                          .Where(myWorkField => !leftCols.Contains(myWorkField.Name))
                                                          .Where(
                                                              myWorkField => !rightCols.Contains(myWorkField.Name)))
                {
                    string name = Utils.ToGridSafeFieldName(myWorkField.Name);
                    string value = myWorkField.DisplayName;

                    string format;
                    string type = GetMyWorkFieldType(myWorkField, fieldTypes, out format);

                    if (name.Equals("Author"))
                    {
                        value = "Created By";
                    }
                    else if (name.Equals("Editor"))
                    {
                        value = "Modified By";
                    }

                    header.Add(new XAttribute(name, value));

                    if (type.Equals("Date") || type.Equals("Float"))
                        header.Add(new XAttribute(string.Format(@"{0}Align", name), "Right"));
                }

                grid.Element("RightCols").RemoveNodes();

                XDocument xDocument = XDocument.Parse(data);
                if (
                    xDocument.Element("MyWork").Descendants().ToList().Exists(
                        e => e.Name.LocalName.Equals("CompleteItemsQuery")))
                {
                    if (!bool.Parse(xDocument.Element("MyWork").Element("CompleteItemsQuery").Value))
                    {
                        result.Element("Grid").Element("LeftCols").Elements("C")
                              .FirstOrDefault(e => e.Attribute("Name").Value.Equals("Complete"))
                              .Add(new XAttribute("Tip", "Mark Complete"));
                    }
                }

                if (!ShouldUseReportingDb(spWeb))
                {
                    XElement workingOnElement =
                        (from e in result.Descendants("C")
                         where e.Attribute("Name").Value.Equals(WORKING_ON_FIELD)
                         select e).FirstOrDefault();

                    if (workingOnElement != null)
                    {
                        workingOnElement.Add(new XAttribute("CanFilter", 0), new XAttribute("CanGroup", 0),
                                             new XAttribute("CanHide", 0));
                    }
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2040, e.Message);
            }
        }

        /// <summary>
        ///     Gets my work grid views.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridViews(SPWeb spWeb)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWork"));

                result.Element("MyWork").Add(new XElement("Views"));
                XElement viewsElement = result.Element("MyWork").Element("Views");

                SPWeb configWeb = Utils.GetConfigWeb();

                List<MyWorkGridView> myWorkGridViews = GetGlobalViews(configWeb).ToList();

                if (!myWorkGridViews.ToList().Exists(v => v.Id.Equals("dv")))
                {
                    string cols = string.Format("Flag:{0},DueDate:{1},DueDay:{2}", FLAG_COL_WIDTH, DUE_DATE_COL_WIDTH,
                                                DUE_DAY_COL_WIDTH);

                    var myWorkGridView = new MyWorkGridView
                        {
                            Id = "dv",
                            Name = "Default View",
                            Default = true,
                            Personal = false,
                            LeftCols =
                                string.Format(
                                    "Complete:{0},CommentCount:{1},Priority:{2}Title:{3}",
                                    COMPLETE_COL_WIDTH, COMMENT_COL_WIDTH,
                                    PRIORITY_COL_WIDTH, TITLE_COL_WIDTH),
                            Cols = cols,
                            RightCols = string.Empty,
                            Filters = "0|",
                            Grouping = "0|",
                            Sorting = "DueDate"
                        };

                    SaveGlobalViews(myWorkGridView, Utils.GetConfigWeb());

                    myWorkGridViews.Insert(0, myWorkGridView);
                }

                foreach (MyWorkGridView myWorkGridView in myWorkGridViews)
                {
                    var xElement = new XElement("View");

                    xElement.Add(new XAttribute("ID", myWorkGridView.Id));
                    xElement.Add(new XAttribute("Name", myWorkGridView.Name));
                    xElement.Add(new XAttribute("LeftCols", GetLeftCols(myWorkGridView)));
                    xElement.Add(new XAttribute("Cols", myWorkGridView.Cols));
                    xElement.Add(new XAttribute("RightCols", myWorkGridView.RightCols));
                    xElement.Add(new XAttribute("Grouping", myWorkGridView.Grouping));
                    xElement.Add(new XAttribute("Filters", myWorkGridView.Filters));
                    xElement.Add(new XAttribute("Sorting", myWorkGridView.Sorting));
                    xElement.Add(new XAttribute("Default", myWorkGridView.Default));
                    xElement.Add(new XAttribute("Type", "Global"));

                    viewsElement.Add(xElement);
                }

                foreach (MyWorkGridView myWorkGridView in GetPersonalViews(configWeb))
                {
                    var xElement = new XElement("View");

                    xElement.Add(new XAttribute("ID", myWorkGridView.Id));
                    xElement.Add(new XAttribute("Name", myWorkGridView.Name));
                    xElement.Add(new XAttribute("LeftCols", GetLeftCols(myWorkGridView)));
                    xElement.Add(new XAttribute("Cols", myWorkGridView.Cols));
                    xElement.Add(new XAttribute("RightCols", myWorkGridView.RightCols));
                    xElement.Add(new XAttribute("Grouping", myWorkGridView.Grouping));
                    xElement.Add(new XAttribute("Filters", myWorkGridView.Filters));
                    xElement.Add(new XAttribute("Sorting", myWorkGridView.Sorting));
                    xElement.Add(new XAttribute("Default", myWorkGridView.Default));
                    xElement.Add(new XAttribute("Type", "Personal"));

                    viewsElement.Add(xElement);
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2080, e.Message);
            }
        }

        /// <summary>
        ///     Gets my work list item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkListItem(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWork"));

                XElement myWorkElement = result.Element("MyWork");

                XDocument xDocument = XDocument.Parse(ListItem.GetListItem(data.Replace("<MyWork>", "<ListItem>")
                                                                               .Replace("</MyWork>", "</ListItem>").
                                                                                Replace("<MyWork/>", "<ListItem/>")
                                                                               .Replace("<MyWork />", "<ListItem />")));

                XElement xElement = xDocument.Element("ListItem");

                string siteUrl = xElement.Element("Site").Attribute("URL").Value;
                string webId = xElement.Element("Web").Attribute("ID").Value;
                string listId = xElement.Element("List").Attribute("ID").Value;

                myWorkElement.Add(new XElement("Item"));
                myWorkElement.Element("Item").Add(new XAttribute("ID", xElement.Element("Item").Attribute("ID").Value));

                myWorkElement.Add(new XElement("List"));
                myWorkElement.Element("List").Add(new XAttribute("ID", listId));

                myWorkElement.Add(new XElement("Web"));
                myWorkElement.Element("Web").Add(new XAttribute("ID", webId));

                myWorkElement.Add(new XElement("Site"));
                myWorkElement.Element("Site").Add(new XAttribute("ID", xElement.Element("Site").Attribute("ID").Value));
                myWorkElement.Element("Site").Add(new XAttribute("URL", siteUrl));

                myWorkElement.Add(new XElement("Fields"));
                XElement fieldsElement = myWorkElement.Element("Fields");

                foreach (XElement field in xElement.Element("Fields").Elements("Field"))
                {
                    var value = GetGridSafeValue(field);

                    if (field.Attribute("Type").Value.Contains("Date"))
                    {
                        value = DateTime.Parse(value).ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    var element = new XElement("Field", new XCData(value));
                    element.Add(new XAttribute("Name", Utils.ToGridSafeFieldName(field.Attribute("Name").Value)));

                    fieldsElement.Add(element);
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2015, e.Message);
            }
        }

        /// <summary>
        ///     Gets the related grid format.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="format">The format.</param>
        /// <param name="spField">The sp field.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        internal static string GetRelatedGridFormat(string type, string format, SPField spField, SPWeb spWeb)
        {
            var currencyFormatDictionary = new Dictionary<int, string> {{0, "$n"}, {1, "n$"}, {2, "$ n"}, {3, "n $"}};

            switch (type)
            {
                case "Float":
                    if (spField.Type == SPFieldType.Number)
                    {
                        string percentageSign = string.Empty;

                        if (((SPFieldNumber) spField).ShowAsPercentage)
                        {
                            percentageSign = @"%";
                        }

                        switch (((SPFieldNumber) spField).DisplayFormat)
                        {
                            case SPNumberFormatTypes.Automatic:
                                return ",#0.##########" + percentageSign;
                            case SPNumberFormatTypes.NoDecimal:
                                return ",#0" + percentageSign;
                            case SPNumberFormatTypes.OneDecimal:
                                return ",#0.0" + percentageSign;
                            case SPNumberFormatTypes.TwoDecimals:
                                return ",#0.00" + percentageSign;
                            case SPNumberFormatTypes.ThreeDecimals:
                                return ",#0.000" + percentageSign;
                            case SPNumberFormatTypes.FourDecimals:
                                return ",#0.0000" + percentageSign;
                            case SPNumberFormatTypes.FiveDecimals:
                                return ",#0.00000" + percentageSign;
                        }
                    }
                    else if (spField.Type == SPFieldType.Currency)
                    {
                        var currenvyCultureInfo = new CultureInfo(((SPFieldCurrency) spField).CurrencyLocaleId);
                        NumberFormatInfo numberFormatInfo = currenvyCultureInfo.NumberFormat;

                        return currencyFormatDictionary[numberFormatInfo.CurrencyPositivePattern]
                            .Replace("$", numberFormatInfo.CurrencySymbol)
                            .Replace("n",
                                     string.Format("##,#.{0}", new string('0', numberFormatInfo.CurrencyDecimalDigits)));
                    }

                    return string.Empty;
                case "Date":
                    string dateFormat = GetExampleDateFormat(spWeb, "yyyy", "M", "d");
                    return format.Equals("DateOnly") ? dateFormat : string.Format("{0} h:mm tt", dateFormat);
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        ///     Gets the working on grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetWorkingOnGridData(string data)
        {
            try
            {
                var bElement = new XElement("B");

                DataTable dataTable = GetWorkingOn(data);

                if (dataTable.Rows.Count > 0)
                {
                    Dictionary<string, SPField> fieldTypes = Utils.GetFieldTypes();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var iElement = new XElement("I");

                        foreach (DataColumn dataColumn in dataTable.Columns)
                        {
                            string field = dataColumn.ColumnName;

                            string value = dataRow[field] == null || dataRow[field] == DBNull.Value
                                               ? string.Empty
                                               : dataRow[field].ToString();

                            value = GetGridSafeValue(BuildFieldElement(fieldTypes, value, field));

                            if (field.Equals(DUE_DATE_FIELD) && !string.IsNullOrEmpty(value))
                            {
                                iElement.Add(new XAttribute(DUE_DAY_FIELD, Convert.ToDateTime(value).ToFriendlyDate()));
                            }

                            iElement.Add(new XAttribute(field, value ?? string.Empty));
                        }

                        bElement.Add(iElement);
                    }
                }

                return new XElement("Grid", new XElement("Body", bElement)).ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2076, e.Message);
            }
        }

        /// <summary>
        ///     Gets the working on grid layout.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetWorkingOnGridLayout(string data)
        {
            try
            {
                data = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data));

                XDocument result = XDocument.Parse(Resources.WorkingOnGridLayout);

                XElement grid = result.Element("Grid");

                var cfgElement = new XElement("Cfg");

                cfgElement.Add(new XAttribute("id", XDocument.Parse(data).Root.Element("Params").Element("GridId").Value));
                cfgElement.Add(new XAttribute("CSS",
                                              string.Format("{0}/_layouts/epmlive/treegrid/workingon/grid.css",
                                                            SPContext.Current.Web.Url)));

                grid.Add(cfgElement);

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2075, e.Message);
            }
        }

        /// <summary>
        ///     Renames my work grid view.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string RenameMyWorkGridView(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWork"));

                XDocument xDocument = XDocument.Parse(data);

                SPWeb configWeb = Utils.GetConfigWeb();

                if (!xDocument.Elements().ToList().Exists(e => e.Name.LocalName.Equals("MyWork")))
                    throw new Exception("Cannot find MyWork element.");
                XElement myWorkElement = xDocument.Element("MyWork");

                if (!myWorkElement.Elements().ToList().Exists(e => e.Name.LocalName.Equals("View")))
                    throw new Exception("Cannot find View element.");
                XElement viewElement = myWorkElement.Element("View");

                foreach (string attribute in new[] {"ID", "Name", "Personal"}
                    .Where(
                        attribute => !viewElement.Attributes().ToList().Exists(a => a.Name.LocalName.Equals(attribute)))
                    )
                {
                    throw new Exception("Cannot find attribute " + attribute);
                }

                string viewId = viewElement.Attribute("ID").Value;
                string viewName = viewElement.Attribute("Name").Value;
                bool isViewPersonal = Convert.ToBoolean(viewElement.Attribute("Personal").Value);

                if (isViewPersonal) RenamePersonalView(viewId, viewName, GetPersonalViews(configWeb), configWeb);
                else RenameGlobalView(viewId, viewName, GetGlobalViews(configWeb), configWeb);

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2030, e.Message);
            }
        }

        /// <summary>
        ///     Saves my work grid view.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string SaveMyWorkGridView(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWork"));

                XDocument xDocument = XDocument.Parse(data);

                SPWeb configWeb = Utils.GetConfigWeb();

                MyWorkGridView myWorkGridView = GetMyWorkGridView(xDocument);

                if (myWorkGridView.Personal)
                {
                    List<MyWorkGridView> myWorkGridViews = GetPersonalViews(configWeb).ToList();
                    myWorkGridViews.RemoveAll(v => v.Id.Equals(myWorkGridView.Id));

                    if (myWorkGridView.Default)
                    {
                        foreach (MyWorkGridView gridView in myWorkGridViews)
                        {
                            gridView.Default = false;
                        }
                    }

                    myWorkGridViews.Add(myWorkGridView);

                    SavePersonalViews(myWorkGridViews, configWeb);
                }
                else
                {
                    SaveGlobalViews(myWorkGridView, configWeb);
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2090, e.Message);
            }
        }

        /// <summary>
        ///     Updates my work item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string UpdateMyWorkItem(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyWorkItem"));

                result.Element("MyWorkItem").Add(new XElement("Fields"));
                XElement fieldsElement = result.Element("MyWorkItem").Element("Fields");

                result.Element("MyWorkItem").Add(new XElement("Messages"));
                XElement messagesElement = result.Element("MyWorkItem").Element("Messages");

                int itemId;
                Guid listId;
                Guid webId;
                Guid siteId;
                string siteUrl;

                Utils.GetItemListWebSite(data, GetMyWorkItemElement(data), out itemId, out listId, out webId, out siteId,
                                         out siteUrl);

                Dictionary<string, string> fieldValues =
                    Utils.GetFieldValues(XDocument.Parse(data).Element("MyWorkItem"));

                Dictionary<string, string> originalFieldValues =
                    fieldValues.ToDictionary(fieldValue => Utils.ToOriginalFieldName(fieldValue.Key),
                                             fieldValue => fieldValue.Value);

                var listItemDocument = new XDocument();
                listItemDocument.Add(new XElement("ListItems"));
                listItemDocument.Element("ListItems").Add(new XElement("ListItem"));

                XElement listItemElement = listItemDocument.Element("ListItems").Element("ListItem");
                Utils.AddItemListWebSiteToXElement(itemId, listId, webId, siteId, siteUrl, ref listItemElement);

                listItemElement.Add(new XElement("Fields"));
                XElement listItemFieldsElement = listItemElement.Element("Fields");

                foreach (var originalFieldValue in originalFieldValues)
                {
                    var fieldElement = new XElement("Field", new XCData(originalFieldValue.Value));
                    fieldElement.Add(new XAttribute("Name", originalFieldValue.Key));

                    listItemFieldsElement.Add(fieldElement);
                }

                if (listItemFieldsElement.Elements("Field").Count() > 0)
                {
                    XDocument updateListItemDocument =
                        XDocument.Parse(ListItem.UpdateListItem(listItemDocument.ToString()));

                    foreach (
                        XElement element in
                            updateListItemDocument.Element("ListItems").Element("ListItem").Element("Messages").Elements
                                ("Message"))
                    {
                        var xElement = new XElement("Message", new XCData(element.Value));

                        messagesElement.Add(xElement);
                    }
                }

                var getItemDocument = new XDocument();
                getItemDocument.Add(new XElement("ListItem"));

                XElement getListItemElement = getItemDocument.Element("ListItem");
                Utils.AddItemListWebSiteToXElement(itemId, listId, webId, siteId, siteUrl, ref getListItemElement);

                XDocument getListItemDocument = XDocument.Parse(ListItem.GetListItem(getItemDocument.ToString()));

                foreach (XElement element in getListItemDocument.Element("ListItem").Element("Fields").Elements("Field")
                    )
                {
                    string name = element.Attribute("Name").Value;
                    string value = GetGridSafeValue(element);

                    DateTime dateTime = DateTime.MinValue;

                    if (element.Attribute("Type").Value.Contains("Date"))
                    {
                        dateTime = DateTime.Parse(value);
                        value = dateTime.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    }

                    var xElement = new XElement("Field", new XCData(value));
                    xElement.Add(new XAttribute("Name", Utils.ToGridSafeFieldName(name)));

                    if (name.Equals(DUE_DATE_FIELD) && !string.IsNullOrEmpty(value))
                    {
                        var dueDayElement = new XElement("Field", new XCData(dateTime.ToFriendlyDate()));
                        dueDayElement.Add(new XAttribute("Name", DUE_DAY_FIELD));

                        fieldsElement.Add(dueDayElement);
                    }

                    fieldsElement.Add(xElement);
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2050, e.Message);
            }
        }

        #endregion Methods 
    }
}