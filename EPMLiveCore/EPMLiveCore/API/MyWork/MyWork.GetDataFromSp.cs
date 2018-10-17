using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
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
        private static IEnumerable<DataTable> GetDataFromSp(
            IList<string> selectedListIds,
            SPSiteDataQuery dataQuery,
            SPWeb spWeb,
            SPSite spSite)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(selectedListIds, nameof(selectedListIds));
            Guard.ArgumentIsNotNull(dataQuery, nameof(dataQuery));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));

            var locker = new object();
            var eventWaitHandles = new List<EventWaitHandle>();
            var dataTables = new List<DataTable>();
            var spExceptionOccured = false;

            foreach (var selectedList in GetMyWorkParams.SelectedLists.Distinct().OrderBy(l => l))
            {
                var theSelectedList = selectedList;
                var listIdsBuilder = new StringBuilder();

                foreach (
                    var listId in GetListIdsFromDb(selectedList, spWeb, GetMyWorkParams.ArchivedWebs)
                       .Where(listId => !selectedListIds.Contains(listId)))
                {
                    selectedListIds.Add(listId);
                    listIdsBuilder.Append($@"<List ID='{listId}'/>");
                }

                var listIds = listIdsBuilder.ToString();

                if (string.IsNullOrWhiteSpace(listIds))
                {
                    continue;
                }

                spExceptionOccured = SpExceptionOccured(dataQuery, spWeb, spSite, listIds, eventWaitHandles, selectedList, locker, dataTables, theSelectedList);
            }

            WaitHandle.WaitAll(eventWaitHandles.ToArray());

            if (spExceptionOccured)
            {
                throw new APIException(2016, CannotRunSpDataQuery);
            }

            ProcessDictWorkingOn(spWeb, dataTables);
            return dataTables;
        }

        private static bool SpExceptionOccured(
            SPSiteDataQuery dataQuery,
            SPWeb spWeb,
            SPSite spSite,
            string listIds,
            IList<EventWaitHandle> eventWaitHandles,
            string selectedList,
            object locker,
            IList<DataTable> dataTables,
            string theSelectedList)
        {
            Guard.ArgumentIsNotNull(dataQuery, nameof(dataQuery));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));
            Guard.ArgumentIsNotNull(eventWaitHandles, nameof(eventWaitHandles));
            Guard.ArgumentIsNotNull(dataTables, nameof(dataTables));

            var spExceptionOccured = false;
            dataQuery.Lists = $"<Lists MaxListLimit='0'>{listIds}</Lists>";

            var siteUrl = (string)spSite.Url.Clone();
            var webId = new Guid(spWeb.ID.ToString());
            var spUserToken = spWeb.CurrentUser.UserToken;
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
            var list = selectedList;
            var thread = new Thread(
                () =>
                {
                    try
                    {
                        var dataTable = QueryMyWorkData(spSiteDataQuery, siteUrl, webId, spUserToken);
                        dataTable.TableName = list;

                        lock (locker)
                        {
                            dataTables.Add(dataTable);
                        }
                    }
                    catch (SPException exception)
                    {
                        Trace.WriteLine(exception);
                        spExceptionOccured = true;
                    }

                    eventWaitHandle.Set();
                }) { Name = theSelectedList, IsBackground = true };

            thread.Start();
            return spExceptionOccured;
        }

        private static void ProcessDictWorkingOn(SPWeb spWeb, List<DataTable> dataTables)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(dataTables, nameof(dataTables));

            var dictWorkingOn = new Dictionary<string, List<string>>();

            foreach (DataRow dataRow in GetWorkingOn(spWeb).Rows)
            {
                var key = dataRow[ListId].ToString().ToUpper();

                key = key.Replace(OpenCurlyBrace, string.Empty);
                key = key.Replace(ClosedCurlyBrace, string.Empty);

                if (!dictWorkingOn.ContainsKey(key))
                {
                    dictWorkingOn.Add(key, new List<string>());
                }

                dictWorkingOn[key].Add(dataRow[ItemId].ToString());
            }

            foreach (var dataTable in dataTables.Where(dataTable => dataTable.Rows.Count > 0))
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var workingOn = false;
                    var key = dataRow[ListId].ToString().ToUpper();

                    key = key.Replace(OpenCurlyBrace, string.Empty);
                    key = key.Replace(ClosedCurlyBrace, string.Empty);

                    if (dictWorkingOn.ContainsKey(key))
                    {
                        if (dictWorkingOn[key].Contains(dataRow[IdText].ToString()))
                        {
                            workingOn = true;
                        }
                    }

                    dataRow[WorkingOnField] = workingOn;
                }
            }
        }
    }
}





