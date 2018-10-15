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
using System.Diagnostics;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the SP content DB SQL connection.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static SqlConnection GetSpContentDbSqlConnection(SPWeb spWeb)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            try
            {
                SqlConnection sqlConnection = null;
                SPSecurity.RunWithElevatedPrivileges(
                    () =>
                    {
                        var databaseConnectionString =
                            spWeb.Site.ContentDatabase.DatabaseConnectionString;
                        sqlConnection = new SqlConnection(databaseConnectionString);
                    });
                return sqlConnection;
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2008, exception.Message);
            }
        }

        /// <summary>
        ///     Shoulds the use reporting db.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static bool ShouldUseReportingDb(SPWeb spWeb)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            var useReportingDb = false;

            using (var configWeb = Utils.GetConfigWeb(spWeb, CoreFunctions.getLockedWeb(spWeb)))
            {
                var reportData = new ReportData(configWeb.Site.ID);

                if (reportData.GetSite() != null)
                {
                    if (reportData.GetListMapping(configWeb.Lists[MyWorkText].ID) != null)
                    {
                        useReportingDb = true;
                    }
                }
            }

            return useReportingDb;
        }

        /// <summary>
        ///     Builds the field element.
        /// </summary>
        /// <param name="fieldTypes">The field types.</param>
        /// <param name="value">The value.</param>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        private static XElement BuildFieldElement(IDictionary<string, SPField> fieldTypes, string value, string field)
        {
            value = value ?? string.Empty;

            string type;
            string format;

            GetTypeAndFormat(fieldTypes, field, out type, out format);

            if (field.Equals(Complete))
            {
                value = value.Equals(bool.TrueString)
                    ? One
                    : Zero;
            }

            var fieldElement = new XElement(Field, new XCData(value));
            fieldElement.Add(new XAttribute(Name, field));
            fieldElement.Add(new XAttribute(Type, type));
            fieldElement.Add(new XAttribute(Format, format));

            return fieldElement;
        }

        /// <summary>
        ///     Generates the col dictionary.
        /// </summary>
        /// <param name="myWorkDataTable">My work data table.</param>
        /// <param name="myWorkFields">My work fields.</param>
        /// <returns></returns>
        private static IDictionary<string, int> GenerateColDictionary(
            DataTable myWorkDataTable,
            IEnumerable<string> myWorkFields)
        {
            Guard.ArgumentIsNotNull(myWorkDataTable, nameof(myWorkDataTable));
            Guard.ArgumentIsNotNull(myWorkFields, nameof(myWorkFields));

            var colDict = new Dictionary<string, int>();

            foreach (var selectedField in myWorkFields)
            {
                if (myWorkDataTable.Columns.Contains(selectedField))
                {
                    colDict.Add(selectedField, 1);
                }
                else if (myWorkDataTable.Columns.Contains($"{selectedField}{IdText}"))
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
        ///     Checks if the SiteId col exists in the Tags Reporting DB table.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        private static bool TagSiteIdExists(SPWeb spWeb)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            var queryExecutor = new QueryExecutor(spWeb);

            var resultDt =
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
            Debug.WriteLine($"*** MyWork: {message}");
        }

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
                result.Add(new XElement(nameof(MyWork)));

                Guid listId;
                Guid webId;
                Guid siteId;
                string siteUrl;

                var myWorkElement = GetMyWorkElement(data);
                Utils.GetListWebSite(data, myWorkElement, out listId, out webId, out siteId, out siteUrl);

                var hasPermissions = false;

                using (var spSite = new SPSite(siteUrl))
                {
                    using (var spWeb = spSite.OpenWeb(webId))
                    {
                        hasPermissions = spWeb.Lists[listId]
                           .DoesUserHavePermissions(
                                SPContext.Current.Web.CurrentUser,
                                SPBasePermissions.EditListItems);
                    }
                }

                result.Element(nameof(MyWork)).Add(new XElement(HasEditPermission, hasPermissions));

                return result.ToString();
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2045, exception.Message);
            }
        }
    }
}