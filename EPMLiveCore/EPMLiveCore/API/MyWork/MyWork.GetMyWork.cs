using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
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
                result.Add(new XElement(nameof(MyWork)));

                var theQuery = GetQuery(data);
                var query = !string.IsNullOrWhiteSpace(theQuery)
                    ? $@"<Where><And>{theQuery}<Eq><FieldRef Name='{AssignedToField}'/><Value Type='Integer'><UserID/></Value></Eq></And></Where>"
                    : $@"<Where><Eq><FieldRef Name='{AssignedToField}'/><Value Type='Integer'><UserID/></Value></Eq></Where>";

                GetSettings(data);

                var processFlag = false;

                foreach (var siteUrl in GetMyWorkParams.SiteUrls)
                {
                    using (var spSite = new SPSite(siteUrl))
                    {
                        using (var spWeb = spSite.OpenWeb())
                        {
                            GetMyWorkParams.FieldTypes = Utils.GetFieldTypes();
                            GetMyWorkParams.WorkTypes = new Dictionary<string, string>();
                            GetMyWorkParams.WorkSpaces = new Dictionary<string, string>();
                            GetMyWorkParams.ArchivedWebs = GetArchivedWebs(spWeb.Site.ID);

                            if (!GetMyWorkParams.PerformanceMode)
                            {
                                GetDataFromLists(
                                    result,
                                    query,
                                    spSite,
                                    spWeb);
                            }
                            else
                            {
                                result = ProcessXDocument(data, spWeb, spSite, result, query, ref processFlag);
                            }
                        }
                    }
                }

                result.Root.Add(new XElement(ParamsText, new XElement(ProcessFlag, processFlag)));

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
                throw new APIException(2000, exception.Message);
            }
        }

        private static XDocument ProcessXDocument(string data, SPWeb spWeb, SPSite spSite, XDocument result, string query, ref bool processFlag)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));
            Guard.ArgumentIsNotNull(result, nameof(result));

            if (ShouldUseReportingDb(spWeb))
            {
                var dataTables = GetDataFromReportingDb(
                    spWeb,
                    data);

                if (dataTables != null)
                {
                    foreach (var dataTable in dataTables)
                    {
                        ProcessMyWork(
                            dataTable,
                            spSite,
                            spWeb,
                            ref result);
                    }
                }
            }
            else
            {
                try
                {
                    var dataQuery = SpSiteDataQuery(query, GetMyWorkParams.SelectedFields);
                    var selectedListIds = new List<string>();

                    if (!GetMyWorkParams.NoListsSelected)
                    {
                        processFlag = true;
                        var dataTables = GetDataFromSp(
                            selectedListIds,
                            dataQuery,
                            spWeb,
                            spSite);

                        if (dataTables != null)
                        {
                            foreach (var dataTable in dataTables)
                            {
                                ProcessMyWork(
                                    dataTable,
                                    spSite,
                                    spWeb,
                                    ref result);
                            }
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
                    throw new APIException(
                        2014,
                        UnableToRetrieveMyWorkDataList);
                }
            }

            return result;
        }

        private static SPSiteDataQuery SpSiteDataQuery(string query, List<string> selectedFields)
        {
            Guard.ArgumentIsNotNull(selectedFields, nameof(selectedFields));

            var dataQuery = new SPSiteDataQuery
            {
                Webs = @"<Webs Scope='Recursive'>",
                Query = query,
                QueryThrottleMode = SPQueryThrottleOption.Override
            };

            foreach (var selectedField in selectedFields)
            {
                dataQuery.ViewFields += $@"<FieldRef Name='{selectedField}' Nullable='TRUE'/>";
            }

            foreach (var field in new[] {CompletedField, WorkingOnField}
               .Where(field => !selectedFields.Exists(f => f.Equals(field))))
            {
                dataQuery.ViewFields +=
                    $"<FieldRef Name='{field}' Nullable='TRUE'/>";
            }

            return dataQuery;
        }
    }
}