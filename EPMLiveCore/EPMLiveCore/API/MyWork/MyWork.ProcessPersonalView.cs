using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Renames the personal view.
        /// </summary>
        /// <param name="viewId">The view id.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="personalViews">The personal views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void RenamePersonalView(
            string viewId,
            string viewName,
            IEnumerable<MyWorkGridView> personalViews,
            SPWeb configWeb)
        {
            Guard.ArgumentIsNotNull(personalViews, nameof(personalViews));
            Guard.ArgumentIsNotNull(configWeb, nameof(configWeb));

            var myWorkGridViews = personalViews.ToList();

            foreach (
                var myWorkGridView in
                myWorkGridViews.Where(myWorkGridView => myWorkGridView.Id.Equals(viewId)))
            {
                myWorkGridView.Name = viewName;
            }

            SavePersonalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Saves the personal views.
        /// </summary>
        /// <param name="myWorkGridViews">My work grid views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void SavePersonalViews(IEnumerable<MyWorkGridView> myWorkGridViews, SPWeb configWeb)
        {
            Guard.ArgumentIsNotNull(myWorkGridViews, nameof(myWorkGridViews));
            Guard.ArgumentIsNotNull(configWeb, nameof(configWeb));

            try
            {
                using (var spSite = new SPSite(configWeb.Site.ID))
                {
                    using (
                        var sqlConnection =
                            new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        ProcessPersonalViewQuery(myWorkGridViews, spSite, sqlConnection);
                    }
                }
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2091, exception.Message);
            }
        }

        private static void ProcessPersonalViewQuery(IEnumerable<MyWorkGridView> myWorkGridViews, SPSite spSite, SqlConnection sqlConnection)
        {
            Guard.ArgumentIsNotNull(myWorkGridViews, nameof(myWorkGridViews));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));
            Guard.ArgumentIsNotNull(sqlConnection, nameof(sqlConnection));

            var queryString =
                $@"DELETE FROM PERSONALIZATIONS WHERE ([Key] = '{MyWorkGridPersonalViews}' AND [UserId] = '{SPContext.Current.Web.CurrentUser.ID}' AND [SiteId] = '{spSite.ID}')";

            using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlException)
                {
                    Trace.WriteLine(sqlException);
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
                    var xmlSerializer = new XmlSerializer(typeof(List<MyWorkGridView>));
                    var stringWriter = new StringWriter();
                    xmlSerializer.Serialize(stringWriter, myWorkGridViews);

                    sqlCommand.Parameters.AddWithValue(AtKey, MyWorkGridPersonalViews);
                    sqlCommand.Parameters.AddWithValue(AtValue, stringWriter.ToString());
                    sqlCommand.Parameters.AddWithValue(AtUserId, SPContext.Current.Web.CurrentUser.ID);
                    sqlCommand.Parameters.AddWithValue(AtSiteId, spSite.ID);

                    stringWriter.Close();

                    SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlException)
                {
                    Trace.WriteLine(sqlException);
                    throw new APIException(2093, sqlException.Message);
                }
            }
        }

        /// <summary>
        ///     Deletes the personal view.
        /// </summary>
        /// <param name="viewId">The view id.</param>
        /// <param name="personalViews">The personal views.</param>
        /// <param name="configWeb">The config web.</param>
        private static void DeletePersonalView(string viewId, IEnumerable<MyWorkGridView> personalViews, SPWeb configWeb)
        {
            Guard.ArgumentIsNotNull(personalViews, nameof(personalViews));
            Guard.ArgumentIsNotNull(configWeb, nameof(configWeb));

            var myWorkGridViews = personalViews.ToList();
            myWorkGridViews.RemoveAll(v => v.Id.Equals(viewId));
            SavePersonalViews(myWorkGridViews, configWeb);
        }

        /// <summary>
        ///     Gets the personal views.
        /// </summary>
        /// <param name="configWeb">The config web.</param>
        /// <returns></returns>
        private static IEnumerable<MyWorkGridView> GetPersonalViews(SPWeb configWeb)
        {
            Guard.ArgumentIsNotNull(configWeb, nameof(configWeb));

            try
            {
                using (var spSite = new SPSite(configWeb.Site.ID))
                {
                    using (
                        var sqlConnection =
                            new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        var queryString =
                            $@"SELECT Value FROM dbo.PERSONALIZATIONS WHERE ([Key] = N'{MyWorkGridPersonalViews}') AND (UserId = N'{SPContext.Current.Web.CurrentUser.ID}') AND (SiteId LIKE N'{spSite.ID}')";

                        using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                        {
                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                                var serializedPersonalViews = sqlCommand.ExecuteScalar() as string;

                                if (!string.IsNullOrWhiteSpace(serializedPersonalViews))
                                {
                                    var xmlSerializer = new XmlSerializer(typeof(List<MyWorkGridView>));
                                    return
                                        (IEnumerable<MyWorkGridView>)
                                        xmlSerializer.Deserialize(new StringReader(serializedPersonalViews));
                                }
                            }
                            catch (SqlException sqlException)
                            {
                                Trace.WriteLine(sqlException);
                                throw new APIException(2083, sqlException.Message);
                            }
                        }
                    }
                }

                return new List<MyWorkGridView>();
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2082, exception.Message);
            }
        }
    }
}