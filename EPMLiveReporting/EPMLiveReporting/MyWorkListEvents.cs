using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    public class MyWorkListEvents : SPItemEventReceiver
    {
        #region Fields (11) 

        private const string TABLE_NAME = "LSTMyWork";
        private ArrayList _defaultColumns;
        private DataTable _listColumns;
        private Guid _listId;
        private SPListItem _listItem;
        private string _listName;
        private MyWorkReportData _myWorkReportData;
        private SPItemEventProperties _properties;
        private Guid _siteId;
        private string _siteName;
        private string _siteUrl;

        #endregion Fields 

        #region Methods (9) 

        // Public Methods (3) 

        /// <summary>
        /// Asynchronous After event that occurs after a new item has been added to its containing object.
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
        /// Synchronous Before event that occurs before an existing item is completely deleted.
        /// </summary>
        /// <param name="properties"></param>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            try
            {
                if (Initialize(true, properties))
                {
                    DeleteItem();

                    if (_myWorkReportData.ListReportsWork(TABLE_NAME))
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
        /// Asynchronous After event that occurs after an existing item is changed, for example, when the user changes data in one or more fields.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPItemEventProperties"/> object that represents properties of the event handler.</param>
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

        // Private Methods (6) 

        /// <summary>
        /// Deletes the item.
        /// </summary>
        private void DeleteItem()
        {
            _myWorkReportData.DeleteListItem(GetSql("DELETE"));
        }

        /// <summary>
        /// Gets the SQL.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <returns></returns>
        private string GetSql(string operation)
        {
            string sql = string.Empty;

            switch (operation)
            {
                case "INSERT":
                    sql = _myWorkReportData.InsertSQL(TABLE_NAME, _listName, _listColumns, _listItem, _defaultColumns);
                    break;
                case "DELETE":
                    sql = _myWorkReportData.DeleteSQL(TABLE_NAME, _listId, _listItem.ID);
                    break;
            }

            return sql;
        }

        /// <summary>
        /// Initializes the specified populate columns.
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


                if (populateColumns)
                {
                    _defaultColumns = new ArrayList {"siteid", "webid", "listid", "itemid", "weburl"};
                    _listColumns = _myWorkReportData.GetListColumns("My Work");
                    _listColumns = _listColumns.DefaultView.ToTable(true,
                                                                    (from DataColumn dataColumn in _listColumns.Columns
                                                                     select dataColumn.ColumnName).ToArray());
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Inserts the item.
        /// </summary>
        private void InsertItem()
        {
            string sql = GetSql("INSERT");

            if (string.IsNullOrEmpty(sql)) return;

            if (!_myWorkReportData.InsertListItem(sql))
            {
                _myWorkReportData.LogStatus(_myWorkReportData.GetListId(_listName), _listName.Replace("'", string.Empty),
                                            "Url:" + _properties.RelativeWebUrl.Replace("'", string.Empty) +
                                            " Error: Add item was unsuccessful.", _myWorkReportData.GetError(), 2, 1);
            }

            if (_myWorkReportData.ListReportsWork(TABLE_NAME))
            {
                //Save list item "work" field values
                SaveWork();
            }
        }

        /// <summary>
        /// Logs the event.
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

        /// <summary>
        /// Updates the item.
        /// </summary>
        private void UpdateItem()
        {
            DeleteItem();
            InsertItem();
        }

        private bool SaveWork()
        {   
            bool blnWorkSaved = true, hasWork = false, hasAssignedTo = false, hasStartDate = false, hasDueDate = false;
            string sErrMsg = string.Empty;
            try
            {
                //List item "work" fields -- START 
                string sWork = string.Empty;
                string sAssignedTo = string.Empty;
                object StartDate = DBNull.Value;
                object DueDate = DBNull.Value;

                if (ItemHasValue(_listItem, "Work"))
                {
                    sWork = _listItem["Work"].ToString();
                    hasWork = true;
                }
                else
                {
                    //blnWorkSaved = false;
                    sErrMsg = "Work";
                }

                if (ItemHasValue(_listItem, "AssignedTo"))
                {
                    sAssignedTo = ReportData.AddLookUpFieldValues(_listItem["AssignedTo"].ToString(), "id");
                    hasAssignedTo = true;
                }
                else
                {
                    //blnWorkSaved = false;
                    if (sErrMsg == string.Empty)
                    {
                        sErrMsg = "Assigned To";
                    }
                    else
                    {
                        sErrMsg = sErrMsg + "," + "Assigned To";
                    }
                }


                if (ItemHasValue(_listItem, "StartDate"))
                {
                    StartDate = _listItem["StartDate"];
                    hasStartDate = true;
                }
                else
                {
                    //blnWorkSaved = false;
                    if (sErrMsg == string.Empty)
                    {
                        sErrMsg = "Start Date";
                    }
                    else
                    {
                        sErrMsg = sErrMsg + "," + "Start Date (Start)";
                    }
                }


                if (ItemHasValue(_listItem, "DueDate"))
                {
                    DueDate = _listItem["DueDate"];
                    hasDueDate = true;
                }
                else
                {
                    //blnWorkSaved = false;
                    if (sErrMsg == string.Empty)
                    {
                        sErrMsg = "Due Date";
                    }
                    else
                    {
                        sErrMsg = sErrMsg + "," + "Due Date (Finish)";
                    }
                }

                Guid SiteID = _siteId;
                Guid ListID = _listItem.ParentList.ID;
                Guid ItemID = _listItem.UniqueId;
                // "work" fields -- END

                //Save/Process "work" (a.k.a. assignment) fields
                if (blnWorkSaved && hasWork && hasAssignedTo && hasStartDate && hasDueDate)
                {
                    if (!_myWorkReportData.ProcessAssignments(sWork.Replace("'", ""), sAssignedTo, StartDate, DueDate, ListID, SiteID, _listItem.ID, _listItem.ParentList.Title)) // - CAT.NET false-positive: All single quotes are escaped/removed.
                    {
                        _myWorkReportData.LogStatus(string.Empty, string.Empty, "SaveWork() failed.", _myWorkReportData.GetError().Replace("'", ""), 2, 3, string.Empty); // - CAT.NET false-positive: All single quotes are escaped/removed.
                        blnWorkSaved = false;
                    }
                }
                // Missing required values
                // NOTE: we are assuming that values are missing because user did not want to submit work item
            }
            catch (Exception ex)
            {
                _myWorkReportData.LogStatus(string.Empty, string.Empty, "SaveWork() failed. Web: " + _listItem.ParentList.ParentWeb.Title + ". List: " + _listItem.ParentList.Title + ". Item: " + _listItem.Title + ".", ex.Message.Replace("'", ""), 2, 3, string.Empty); // - CAT.NET false-positive: All single quotes are escaped/removed.
                blnWorkSaved = false;
            }
            return blnWorkSaved;
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

        #endregion Methods 
       
    }
}