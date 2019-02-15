using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the list fields and types from db.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static IOrderedEnumerable<KeyValuePair<string, string>> GetListFieldsAndTypesFromDb(
            Guid listId,
            Guid webId,
            SPWeb spWeb)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            try
            {
                var listFieldsAndTypes = new Dictionary<string, string>();

                using (var sqlConnection = GetSpContentDbSqlConnection(spWeb))
                {
                    var queryString =
                        @"SELECT tp_Fields FROM AllLists WHERE tp_ID = @listId AND tp_WebId = @webId";

                    using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue(AtListId, listId);
                        sqlCommand.Parameters.AddWithValue(AtWebId, webId);
                        SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                        var fields = ((byte[])sqlCommand.ExecuteScalar()).SpDecompress();
                        var xDocument = XDocument.Parse(
                            $"<Fields>{fields.Remove(0, fields.IndexOf("<"))}</Fields>");

                        foreach (var xElement in xDocument.Element(Fields)
                           .Elements()
                           .Where(
                                xElement => xElement.Name.LocalName.Equals(Field))
                           .Where(
                                xElement =>
                                    xElement.Attribute(Name) != null &&
                                    xElement.Attribute(Type) != null)
                        )
                        {
                            listFieldsAndTypes.Add(xElement.Attribute(Name).Value, xElement.Attribute(Type).Value);
                        }
                    }
                }

                return listFieldsAndTypes.OrderBy(f => f.Key);
            }
            catch (SqlException sqlException)
            {
                Trace.WriteLine(sqlException);
                throw new APIException(2005, sqlException.Message);
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2006, exception.Message);
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
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            try
            {
                using (var sqlConnection = GetSpContentDbSqlConnection(spWeb))
                {
                    var queryString =
                        @"SELECT tp_Title FROM AllLists WHERE tp_ID = @listId AND tp_WebId = @webId";

                    using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue(AtListId, listId);
                        sqlCommand.Parameters.AddWithValue(AtWebId, webId);
                        SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                        var listName = sqlCommand.ExecuteScalar() as string;
                        return listName;
                    }
                }
            }
            catch (SqlException sqlException)
            {
                Trace.WriteLine(sqlException);
                throw new APIException(2003, sqlException.Message);
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2004, exception.Message);
            }
        }

        /// <summary>
        ///     Gets my work list ids from db.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="archivedWebs">The archived webs.</param>
        /// <param name="selectedListIds">The selected list ids.</param>
        /// <returns></returns>
        private static IEnumerable<Guid> GetMyWorkListIdsFromDb(
            SPWeb spWeb,
            IList<Guid> archivedWebs,
            IList<string> selectedListIds)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(archivedWebs, nameof(archivedWebs));
            Guard.ArgumentIsNotNull(selectedListIds, nameof(selectedListIds));

            try
            {
                var listIds = new List<Guid>();

                using (var sqlConnection = GetSpContentDbSqlConnection(spWeb))
                {
                    AddListIds(spWeb, archivedWebs, selectedListIds, sqlConnection, listIds);
                }

                return listIds;
            }
            catch (SqlException sqlException)
            {
                Trace.WriteLine(sqlException);
                throw new APIException(2021, sqlException.Message);
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2022, exception.Message);
            }
        }

        private static void AddListIds(
            SPWeb spWeb,
            IList<Guid> archivedWebs,
            IList<string> selectedListIds,
            SqlConnection sqlConnection,
            IList<Guid> listIds)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(archivedWebs, nameof(archivedWebs));
            Guard.ArgumentIsNotNull(selectedListIds, nameof(selectedListIds));
            Guard.ArgumentIsNotNull(sqlConnection, nameof(sqlConnection));
            Guard.ArgumentIsNotNull(listIds, nameof(listIds));

            var webUrl = spWeb.ServerRelativeUrl;
            webUrl = webUrl.Equals(Slash)
                ? string.Empty
                : webUrl.Substring(1);
            var archivedWebString = string.Join(
                Comma,
                archivedWebs.Select(
                        archivedWeb => $"'{archivedWeb}'")
                   .ToArray());
            var selectedListString = string.Join(
                Comma,
                selectedListIds.Select(
                        selectedList => $"'{selectedList}'")
                   .ToArray());
            var queryBuilder = new StringBuilder(
                @"
                            SELECT      dbo.AllLists.tp_ID 
                            FROM        dbo.Webs 
                            INNER JOIN  dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId 
                            WHERE ");

            queryBuilder.Append(
                string.IsNullOrWhiteSpace(webUrl)
                    ? $@"(dbo.Webs.SiteId = '{spWeb.Site.ID}')"
                    : $@"(dbo.Webs.FullUrl LIKE '{webUrl}/%' OR dbo.Webs.FullUrl = '{webUrl}')");

            if (archivedWebs.Any())
            {
                queryBuilder.Append($@" AND (dbo.AllLists.tp_WebId NOT IN ({archivedWebString}))");
            }

            if (selectedListIds.Any())
            {
                queryBuilder.Append($@" AND (dbo.AllLists.tp_ID NOT IN ({selectedListString}))");
            }

            queryBuilder.Append($@" AND (dbo.AllLists.tp_ServerTemplate = {MyWorkListServerTemplateId})");

            using (var sqlCommand = new SqlCommand(queryBuilder.ToString(), sqlConnection))
            {
                SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    listIds.Add(sqlDataReader.GetGuid(0));
                }
            }
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
                    using (var spWeb = spSite.OpenWeb(webId))
                    {
                        using (var sqlConnection = GetSpContentDbSqlConnection(spWeb))
                        {
                            var queryString = @"SELECT Title FROM Webs WHERE Id = @webId";

                            using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue(AtWebId, webId);
                                SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                                return sqlCommand.ExecuteScalar() as string;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlException)
            {
                Trace.WriteLine(sqlException);
                throw new APIException(2010, sqlException.Message);
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2011, exception.Message);
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
            Guard.ArgumentIsNotNull(archivedWebs, nameof(archivedWebs));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            try
            {
                var listIds = new List<string>();

                using (var sqlConnection = GetSpContentDbSqlConnection(spWeb))
                {
                    var webUrl = spWeb.ServerRelativeUrl;
                    webUrl = webUrl.Equals(Slash)
                        ? string.Empty
                        : webUrl.Substring(1);

                    var archivedWebString = string.Join(
                        Comma,
                        archivedWebs.Select(
                                archivedWeb => $"'{archivedWeb}'")
                           .ToArray());

                    var queryBuilder = new StringBuilder(
                        $@"
                            SELECT      dbo.AllLists.tp_ID 
                            FROM        dbo.Webs 
                            INNER JOIN  dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId 
                            WHERE (dbo.AllLists.tp_Title = '{selectedList}') AND ");

                    queryBuilder.Append(
                        string.IsNullOrWhiteSpace(webUrl)
                            ? $@"(dbo.Webs.SiteId = '{spWeb.Site.ID}')"
                            : $@"(dbo.Webs.FullUrl LIKE '{webUrl}/%' OR dbo.Webs.FullUrl = '{webUrl}')");

                    if (archivedWebs.Any())
                    {
                        queryBuilder.Append($@" AND (dbo.AllLists.tp_WebId NOT IN ({archivedWebString}))");
                    }

                    using (var sqlCommand = new SqlCommand(queryBuilder.ToString(), sqlConnection))
                    {
                        SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                        var sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            listIds.Add(sqlDataReader.GetGuid(0).ToString());
                        }
                    }
                }

                return listIds;
            }
            catch (SqlException sqlException)
            {
                Trace.WriteLine(sqlException);
                throw new APIException(2001, sqlException.Message);
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2002, exception.Message);
            }
        }
    }
}