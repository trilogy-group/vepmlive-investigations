using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    public class MyWorkListEvents : SPItemEventReceiver
    {
        #region Fields (13) 

        private const string TABLE_NAME = "LSTMyWork";
        private Dictionary<string, object> _currentValues;
        private ArrayList _defaultColumns;
        private DataTable _listColumns;
        private Guid _listId;
        private SPListItem _listItem;
        private string _listName;
        private ArrayList _mandatoryHiddenFlds;
        private MyWorkReportData _myWorkReportData;
        private SPItemEventProperties _properties;
        private Guid _siteId;
        private string _siteName;
        private string _siteUrl;

        #endregion Fields 

        #region Methods (12) 

        // Public Methods (3) 

        /// <summary>
        ///     Asynchronous After event that occurs after a new item has been added to its containing object.
        /// </summary>
        /// <param name="properties"></param>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            try
            {
                if (Initialize(true, properties))
                {
                    InsertItem();
                }

                _myWorkReportData.Dispose();
            }
            catch (Exception exception)
            {
                SPSecurity.RunWithElevatedPrivileges(
                    () => LogEvent(exception, 6001, "EPMLive My Work Reporting Item Added"));
            }
        }

        /// <summary>
        ///     Synchronous Before event that occurs before an existing item is completely deleted.
        /// </summary>
        /// <param name="properties"></param>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            try
            {
                if (Initialize(true, properties))
                {
                    DeleteItem();

                    string tableName = _myWorkReportData.GetTableName(_listItem.ParentList.ID);
                    if (_myWorkReportData.ListReportsWork(tableName))
                    {
                        _myWorkReportData.DeleteWork(_listId, _properties.ListItemId);
                    }
                }

                _myWorkReportData.Dispose();
            }
            catch (Exception exception)
            {
                SPSecurity.RunWithElevatedPrivileges(
                    () => LogEvent(exception, 6003, "EPMLive My Work Reporting Item Deleting"));
            }
        }

        /// <summary>
        ///     Asynchronous After event that occurs after an existing item is changed, for example, when the user changes data in
        ///     one or more fields.
        /// </summary>
        /// <param name="properties">
        ///     An <see cref="T:Microsoft.SharePoint.SPItemEventProperties" /> object that represents
        ///     properties of the event handler.
        /// </param>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            try
            {
                if (Initialize(true, properties))
                {
                    UpdateItem();
                }

                _myWorkReportData.Dispose();
            }
            catch (Exception exception)
            {
                SPSecurity.RunWithElevatedPrivileges(
                    () => LogEvent(exception, 6002, "EPMLive My Work Reporting Item Updated"));
            }
        }

        // Private Methods (9) 

        /// <summary>
        ///     Deletes the item.
        /// </summary>
        private void DeleteItem()
        {
            _myWorkReportData.DeleteListItem(GetSql("DELETE"));
        }

        private Dictionary<string, object> GetItemFieldValueFromDB(string listId, string itemId)
        {
            var res = new Dictionary<string, object>();
            DataTable dt =
                _myWorkReportData.ExecuteSql("SELECT * FROM LSTMyWork WHERE [ListId] = '" + listId + "' AND [ItemId] = " +
                                             itemId + " AND [AssignedToID] != -99");

            try
            {
                res.Add("AssignedToIDs", dt.Rows[0]["AssignedToID"]);
                res.Add("Work", dt.Rows[0]["Work"]);
                res.Add("StartDate", dt.Rows[0]["StartDate"]);
                res.Add("DueDate", dt.Rows[0]["DueDate"]);
            }
            catch { }

            if (dt.Rows.Count <= 1) return res;

            string sIds = dt.Rows.Cast<DataRow>().Aggregate("", (current, r) => current + (r["AssignedToID"] + ","));

            res["AssignedToIDs"] = sIds;

            double sum = 0;
            foreach (DataRow r in dt.Rows)
            {
                double n = 0;
                try
                {
                    n = Convert.ToDouble(r["Work"].ToString());
                }
                catch { }
                sum += n;
            }

            res["Work"] = sum.ToString(CultureInfo.InvariantCulture);

            return res;
        }

        /// <summary>
        ///     Gets the SQL.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <returns></returns>
        private string GetSql(string operation)
        {
            string sql = string.Empty;

            switch (operation)
            {
                case "INSERT":
                    sql = _myWorkReportData.InsertSQL(TABLE_NAME, _listName, _listColumns, _listItem, _defaultColumns,
                        _mandatoryHiddenFlds);
                    break;
                case "DELETE":
                    sql = _myWorkReportData.DeleteSQL(TABLE_NAME, _listId, _listItem.ID);
                    break;
            }

            return sql;
        }

        /// <summary>
        ///     Initializes the specified populate columns.
        /// </summary>
        /// <param name="populateColumns">if set to <c>true</c> [populate columns].</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private bool Initialize(bool populateColumns, SPItemEventProperties properties)
        {
            try
            {
                _listName = properties.ListTitle;

                if (_listName.Equals("My Work")) return false;

                _siteId = properties.SiteId;
                _listId = properties.ListId;
                _listItem = properties.ListItem;
                _properties = properties;

                _myWorkReportData = new MyWorkReportData(_siteId);
                _siteName = _myWorkReportData.SiteName;
                _siteUrl = _myWorkReportData.SiteUrl;

                _currentValues = GetItemFieldValueFromDB(properties.ListId.ToString(), properties.ListItemId.ToString());

                if (!populateColumns) return true;

                _defaultColumns = new ArrayList {"siteid", "webid", "listid", "itemid", "weburl"};
                _mandatoryHiddenFlds = new ArrayList
                {
                    "commenters",
                    "commentersread",
                    "commentcount",
                    "workspaceurl"
                };

                _listColumns = _myWorkReportData.GetListColumns("My Work");
                _listColumns = _listColumns.DefaultView.ToTable(true,
                    (from DataColumn dataColumn in _listColumns.Columns
                        select dataColumn.ColumnName).ToArray());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Inserts the item.
        /// </summary>
        private void InsertItem()
        {
            string sql = GetSql("INSERT");

            if (string.IsNullOrEmpty(sql)) return;

            foreach (
                string stmt in
                    sql.Split(new[] {"!-x-x-x-x-x-!"}, StringSplitOptions.None)
                        .Where(stmt => !_myWorkReportData.InsertListItem(stmt)))
            {
                _myWorkReportData.LogStatus(_myWorkReportData.GetListId(_listName), _listName.Replace("'", string.Empty),
                    "Url:" + _properties.RelativeWebUrl.Replace("'", string.Empty) +
                    " Error: Add item was unsuccessful.", _myWorkReportData.GetError(), 2, 1);
            }

            string tableName = _myWorkReportData.GetTableName(_listItem.ParentList.ID);
            if (!string.IsNullOrEmpty(tableName) && _myWorkReportData.ListReportsWork(tableName))
            {
                SaveWork();
            }
        }

        private bool ItemHasValue(SPListItem i, string fldName)
        {
            string result = string.Empty;
            try
            {
                result = i[fldName].ToString();
            }
            catch { }

            return !string.IsNullOrEmpty(result);
        }

        /// <summary>
        ///     Logs the event.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="eventSource">The event source.</param>
        private void LogEvent(Exception exception, int eventId, string eventSource)
        {
            if (!EventLog.SourceExists(eventSource)) EventLog.CreateEventSource(eventSource, "EPM Live");

            var eventLog = new EventLog("EPM Live", ".", eventSource) {MaximumKilobytes = 32768};

            eventLog.WriteEntry(
                string.Format("Name: {0} Url: {1} ID: {2} : {3} {4}", _siteName, _siteUrl, _siteId, exception.Message,
                    exception.StackTrace), EventLogEntryType.Error, eventId);
        }

        private void SaveWork()
        {
            bool bHasChangedWork = false;
            bool bHasChangedAssignedTo = false;
            bool bHasChangedStartDate = false;
            bool bHasChangedDueDate = false;

            try
            {
                //List item "work" fields -- START 
                string sWork = string.Empty;
                string sAssignedTo = string.Empty;
                object startDate = DBNull.Value;
                object dueDate = DBNull.Value;

                if (ItemHasValue(_listItem, "Work"))
                {
                    try
                    {
                        sWork = _listItem["Work"].ToString();

                        switch (_properties.EventType)
                        {
                            case SPEventReceiverType.ItemAdded:
                                bHasChangedWork = true;
                                break;
                            case SPEventReceiverType.ItemUpdated:
                                if (_properties.ListItem["Work"] != null &&
                                    Math.Round(Convert.ToDouble(_currentValues["Work"].ToString()), 2) !=
                                    Math.Round(Convert.ToDouble(sWork), 2))
                                {
                                    bHasChangedWork = true;
                                }
                                break;
                        }
                    }
                    catch { }
                }

                if (ItemHasValue(_listItem, "AssignedTo"))
                {
                    try
                    {
                        sAssignedTo = ReportData.AddLookUpFieldValues(_listItem["AssignedTo"].ToString(), "id");

                        switch (_properties.EventType)
                        {
                            case SPEventReceiverType.ItemAdded:
                                bHasChangedAssignedTo = true;
                                break;
                            case SPEventReceiverType.ItemUpdated:
                                if (_properties.ListItem["AssignedTo"] != null)
                                {
                                    var lIdsBefore =
                                        new List<int>(
                                            _currentValues["AssignedToIDs"].ToString()
                                                .TrimEnd(',')
                                                .Split(',')
                                                .Select(int.Parse));
                                    var lookupValAfter =
                                        new SPFieldLookupValueCollection(_properties.ListItem["AssignedTo"].ToString());
                                    List<int> lIdsAfter = lookupValAfter.Select(v => v.LookupId).ToList();

                                    bool execute = false;
                                    if (lIdsBefore.Count() != lIdsAfter.Count()) execute = true;
                                    else
                                    {
                                        bool containsAll = lIdsBefore.All(lIdsAfter.Contains);
                                        if (!containsAll) execute = true;
                                    }

                                    if (execute) bHasChangedAssignedTo = true;
                                }
                                break;
                        }
                    }
                    catch { }
                }


                if (ItemHasValue(_listItem, "StartDate"))
                {
                    try
                    {
                        startDate = _listItem["StartDate"];

                        switch (_properties.EventType)
                        {
                            case SPEventReceiverType.ItemAdded:
                                bHasChangedStartDate = true;
                                break;
                            case SPEventReceiverType.ItemUpdated:
                                if (_properties.ListItem["StartDate"] != null)
                                {
                                    DateTime dateBefore =
                                        Convert.ToDateTime(_currentValues["StartDate"].ToString())
                                            .ToUniversalTime()
                                            .Date;
                                    DateTime dateAfter =
                                        Convert.ToDateTime(_properties.ListItem["StartDate"].ToString())
                                            .ToUniversalTime()
                                            .Date;

                                    if (dateBefore != dateAfter) bHasChangedStartDate = true;
                                }
                                break;
                        }
                    }
                    catch { }
                }


                if (ItemHasValue(_listItem, "DueDate"))
                {
                    try
                    {
                        dueDate = _listItem["DueDate"];

                        switch (_properties.EventType)
                        {
                            case SPEventReceiverType.ItemAdded:
                                bHasChangedDueDate = true;
                                break;
                            case SPEventReceiverType.ItemUpdated:
                                if (_properties.ListItem["DueDate"] != null)
                                {
                                    DateTime dueDateBefore =
                                        Convert.ToDateTime(_currentValues["DueDate"].ToString()).ToUniversalTime().Date;
                                    DateTime dueDateAfter =
                                        Convert.ToDateTime(_properties.ListItem["DueDate"].ToString())
                                            .ToUniversalTime()
                                            .Date;

                                    if (dueDateBefore != dueDateAfter) bHasChangedDueDate = true;
                                }
                                break;
                        }
                    }
                    catch { }
                }

                Guid siteId = _siteId;
                Guid listId = _listItem.ParentList.ID;

                if (!bHasChangedWork && !bHasChangedAssignedTo && !bHasChangedStartDate && !bHasChangedDueDate) return;

                if (_myWorkReportData.ProcessAssignments(sWork.Replace("'", ""), sAssignedTo, startDate, dueDate,
                    listId, siteId, _listItem.ID, _listItem.ParentList.Title)) return;

                _myWorkReportData.LogStatus(string.Empty, string.Empty, "SaveWork() failed.",
                    _myWorkReportData.GetError().Replace("'", ""), 2, 3, string.Empty);
            }
            catch (Exception ex)
            {
                _myWorkReportData.LogStatus(string.Empty, string.Empty,
                    "SaveWork() failed. Web: " + _listItem.ParentList.ParentWeb.Title + ". List: " +
                    _listItem.ParentList.Title + ". Item: " + _listItem.Title + ".", ex.Message.Replace("'", ""), 2, 3,
                    string.Empty);
            }
        }

        /// <summary>
        ///     Updates the item.
        /// </summary>
        private void UpdateItem()
        {
            DeleteItem();
            InsertItem();
        }

        #endregion Methods 
    }
}