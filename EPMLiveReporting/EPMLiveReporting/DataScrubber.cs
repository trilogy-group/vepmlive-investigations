using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using EPMLiveCore;
using EPMLiveCore.Helpers;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    public static partial class DataScrubber
    {
        private const int OwnerId = 1073741823;

        public static void CleanTables(SPSite site, EPMData epmData)
        {
            Guard.ArgumentIsNotNull(site, nameof(site));
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));

            WipeData(DeleteReportListIds, WipeDataId, epmData);
            WipeData(DeleteRptWeb, WipeDataId, epmData);
            WipeData(DeleteRptWebGroups, WipeDataId, epmData);

            var listNames = new DataTable();
            var listIds = new DataTable();
            listIds.Columns.Add(new DataColumn(Id, typeof(Guid)));
            listIds.Columns.Add(new DataColumn(ListIcon, typeof(string)));

            var rptWeb = GetRptWebDataTable();
            var listIdsTest = new DataTable();
            var rptWebTest = new DataTable();
            var errMsg = new StringBuilder();
            bool hasError;
            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    using (var sqlCommand = new SqlCommand(SelectListTableRptList, epmData.GetClientReportingConnection))
                    {
                        using (var adapter = new SqlDataAdapter(sqlCommand))
                        {
                            adapter.Fill(listNames);
                        }

                        LogStatusLevel2Type3(RepopulateId, SelectListTableRptList, epmData);
                    }

                    using (var spSite = new SPSite(site.ID))
                    {
                        foreach (SPWeb spWeb in spSite.AllWebs)
                        {
                            GatherWebInfo(spWeb, rptWeb, spSite);
                            hasError = PopulateRptWebGroups(epmData, spWeb, spSite, errMsg);
                            hasError = GatherValidLists(listNames, spWeb, listIds, hasError, errMsg);
                            spWeb?.Dispose();
                        }

                        hasError = BulkInsertReportListIds(epmData, listIds, errMsg);
                        BulkInsertRptWeb(epmData, rptWeb, ref hasError, errMsg);
                    }

                    if (!CleanLstTables(epmData, listIdsTest, listNames, hasError, errMsg))
                    {
                        return;
                    }

                    var finalRecent = GetValidFrfRecentItems(epmData, errMsg, listIdsTest, rptWebTest);
                    BulkInsertFrfRecentItems(epmData, finalRecent, rptWeb, errMsg);
                });
        }

        private static DataTable GetRptWebDataTable()
        {
            var rptWeb = new DataTable();
            rptWeb.Columns.Add(new DataColumn(SiteId, typeof(Guid)));
            rptWeb.Columns.Add(new DataColumn(ItemWebId, typeof(Guid)));
            rptWeb.Columns.Add(new DataColumn(ItemListId, typeof(Guid)));
            rptWeb.Columns.Add(new DataColumn(ItemId, typeof(int)));
            rptWeb.Columns.Add(new DataColumn(ParentWebId, typeof(Guid)));
            rptWeb.Columns.Add(new DataColumn(WebId, typeof(Guid)));
            rptWeb.Columns.Add(new DataColumn(WebUrl, typeof(string)));
            rptWeb.Columns.Add(new DataColumn(WebTitle, typeof(string)));
            rptWeb.Columns.Add(new DataColumn(WebDescription, typeof(string)));
            rptWeb.Columns.Add(new DataColumn(WebOwnerId, typeof(int)));
            return rptWeb;
        }

        private static bool PopulateRptWebGroups(EPMData epmData, SPWeb spWeb, SPSite spSite, StringBuilder errMsg)
        {
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));
            Guard.ArgumentIsNotNull(errMsg, nameof(errMsg));

            var hasError = false;

            try
            {
                LogStatusLevel2Type3(PopulateRptWebGroupsId, StartBulkInsertRptWebGroups, epmData);

                var dataTable = new DataTable();
                var dataColumn = new DataColumn(RptWebGroups) { DataType = typeof(Guid) };
                dataTable.Columns.Add(dataColumn);
                dataColumn = new DataColumn(SiteId.ToUpper()) { DataType = typeof(Guid) };
                dataTable.Columns.Add(dataColumn);
                dataColumn = new DataColumn(WebId.ToUpper()) { DataType = typeof(Guid) };
                dataTable.Columns.Add(dataColumn);
                dataColumn = new DataColumn(GroupId) { DataType = typeof(int) };
                dataTable.Columns.Add(dataColumn);
                dataColumn = new DataColumn(SecType) { DataType = typeof(int) };
                dataTable.Columns.Add(dataColumn);

                foreach (SPRoleAssignment spRoleAssignment in spWeb.RoleAssignments)
                {
                    var type = spRoleAssignment.Member is SPGroup
                        ? 1
                        : 0;

                    var found = spRoleAssignment.RoleDefinitionBindings.Cast<SPRoleDefinition>()
                       .Any(def => (def.BasePermissions & SPBasePermissions.ViewListItems) == SPBasePermissions.ViewListItems);

                    if (found)
                    {
                        dataTable.Rows.Add(Guid.NewGuid(), spSite.ID, spWeb.ID, spRoleAssignment.Member.ID, type);
                    }
                }

                dataTable.Rows.Add(Guid.NewGuid(), spSite.ID, spWeb.ID, 999999, 1);

                using (var bulkCopy = new SqlBulkCopy(epmData.GetClientReportingConnection))
                {
                    bulkCopy.DestinationTableName = DboRptWebGroups;
                    bulkCopy.WriteToServer(dataTable);
                }

                LogStatusLevel2Type3(PopulateRptWebGroupsId, CompleteBulkInsertRptWebGroups, epmData);
            }
            catch (Exception exception)
            {
                hasError = true;
                errMsg.Append(exception.Message);
                LogStatusLevel2Type3(PopulateRptWebGroupsId, $"Error while Bulk insert dbo.RPTWEBGROUPS Error : {exception.Message}", epmData);
                Trace.WriteLine(exception);
            }

            return hasError;
        }

        private static bool GatherValidLists(DataTable listNames, SPWeb spWeb, DataTable listIds, bool hasError, StringBuilder errMsg)
        {
            Guard.ArgumentIsNotNull(listNames, nameof(listNames));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(listIds, nameof(listIds));
            Guard.ArgumentIsNotNull(errMsg, nameof(errMsg));

            try
            {
                if (listNames.Rows.Count > 0)
                {
                    var listName = string.Empty;

                    foreach (DataRow dataRow in listNames.Rows)
                    {
                        try
                        {
                            listName = dataRow[ListName].ToString();
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }

                        if (!string.IsNullOrWhiteSpace(listName))
                        {
                            var tempList = spWeb.Lists.TryGetList(listName);

                            if (tempList != null)
                            {
                                var gSettings = new GridGanttSettings(tempList);
                                var tempDataRow = listIds.Rows.Add();
                                tempDataRow[Id] = tempList.ID;
                                tempDataRow[ListIcon] = gSettings.ListIcon;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                hasError = true;
                errMsg.Append(exception.Message);
                Trace.WriteLine(exception);
            }

            return hasError;
        }

        private static void GatherWebInfo(SPWeb spWeb, DataTable rptWeb, SPSite spSite)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(rptWeb, nameof(rptWeb));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));

            var parentItem = string.Empty;

            try
            {
                parentItem = spWeb.AllProperties[ParentItem].ToString();
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }

            var dataRow = rptWeb.Rows.Add();

            if (!string.IsNullOrWhiteSpace(parentItem))
            {
                var parentItemTokens = parentItem.Split(new[] {"^^"}, StringSplitOptions.RemoveEmptyEntries);
                var itemWebId = parentItemTokens[0];
                var itemListId = parentItemTokens[1];
                var itemId = parentItemTokens[2];

                dataRow[SiteId] = spSite.ID;
                dataRow[ItemWebId] = !string.IsNullOrWhiteSpace(itemWebId)
                    ? new Guid(itemWebId)
                    : Guid.Empty;
                dataRow[ItemListId] = !string.IsNullOrWhiteSpace(itemListId)
                    ? new Guid(itemListId)
                    : Guid.Empty;
                dataRow[ItemId] = !string.IsNullOrWhiteSpace(itemId)
                    ? int.Parse(itemId)
                    : -1;
                dataRow[ParentWebId] = spWeb.ParentWeb?.ID ?? Guid.Empty;
                dataRow[WebId] = spWeb.ID;
                dataRow[WebUrl] = spWeb.ServerRelativeUrl;
                dataRow[WebTitle] = spWeb.Title;
            }
            else
            {
                dataRow[SiteId] = spSite.ID;
                dataRow[ItemWebId] = Guid.Empty;
                dataRow[ItemListId] = Guid.Empty;
                dataRow[ItemId] = -1;
                dataRow[ParentWebId] = spWeb.ParentWeb?.ID ?? Guid.Empty;
                dataRow[WebId] = spWeb.ID;
                dataRow[WebUrl] = spWeb.ServerRelativeUrl;
                dataRow[WebTitle] = spWeb.Title;
            }

            dataRow[WebDescription] = spWeb.Description;

            try
            {
                dataRow[WebOwnerId] = spWeb.Author.ID == OwnerId
                    ? 1
                    : (object)spWeb.Author.ID;
            }
            catch
            {
                dataRow[WebOwnerId] = 1;
            }
        }

        private static DataTable GetValidFrfRecentItems(EPMData epmData, StringBuilder errMsg, DataTable listIdsTest, DataTable rptWebTest)
        {
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));
            Guard.ArgumentIsNotNull(errMsg, nameof(errMsg));
            Guard.ArgumentIsNotNull(listIdsTest, nameof(listIdsTest));
            Guard.ArgumentIsNotNull(rptWebTest, nameof(rptWebTest));

            var recent = new DataTable();

            try
            {
                using (var cmd = new SqlCommand(SelectFrfType2, epmData.GetEPMLiveConnection))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(recent);
                    }
                }
            }
            catch (Exception exception)
            {
                LogStatusDataCleaning($"Error cleaning lst tables. Error: {exception.Message}", errMsg.ToString(), epmData);
                Trace.WriteLine(exception);
            }

            var lsListIds = (from id in listIdsTest.AsEnumerable()
                select id[Id].ToString()).ToList();
            var lsWebIds = (from webid in rptWebTest.AsEnumerable()
                select webid[WebId].ToString()).ToList();

            var results = (from dataRow in recent.AsEnumerable()
                where lsListIds.Contains(dataRow[ListId].ToString()) && lsWebIds.Contains(dataRow[WebId1].ToString())
                select dataRow).ToList();

            var finalRecent = new DataTable();

            foreach (var row in results)
            {
                finalRecent.Rows.Add(row);
            }

            return finalRecent;
        }
    }
}