using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EPMLiveCore;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using Microsoft.SharePoint;
using ReportFiltering;
using ReportFiltering.DomainServices;

namespace EPMLiveWebParts
{
    public static class QueryHelper
    {
        public static List<string> GetFilteredTitles(SPWeb web, ReportFilterSelection fieldSelection)
        {
            var list = web.Lists[fieldSelection.ListToFilterOn];

            var query = new SPQuery { Query = ReportFilterQueryService.GetQueryForFiltering(fieldSelection) };

            if (fieldSelection.HasErrors) return null;

            return IsRollup(list) ? GetFilteredTitlesForRollup(web, list, query.Query) : GetFilteredTitlesForSubWeb(list, query);
        }

        private static bool IsRollup(SPList list)
        {
            var listSettings = new GridGanttSettings(list);
            return !string.IsNullOrEmpty(listSettings.RollupLists);
        }

        private static List<string> GetFilteredTitlesForSubWeb(SPList list, SPQuery query)
        {
            var items = list.GetItems(query);

            if (items.Count == 0) return new List<string>();

            return (from SPListItem item in items select item.Title).ToList();
        }

        private static List<string> GetFilteredTitlesForRollup(SPWeb web, SPList list, string query)
        {
            var resultsDataTable = CoreFunctions.getSiteItems(web, list.DefaultView, query, "Title", string.Empty, list.Title, new string[0]);

            if (resultsDataTable == null) return new List<string>();

            return (from DataRow row in resultsDataTable.Rows select row["Title"].ToString()).ToList();
        }
    }
}