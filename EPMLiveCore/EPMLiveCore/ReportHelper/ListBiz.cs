using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public class ListBiz
    {
        public static Collection<string> AutomaticFields = new Collection<string>
        {
            "Title",
            "Author",
            "Editor",
            "Created",
            "Modified"
        };

        public static Collection<string> RequiredResourceFields = new Collection<string>
        {
            "Work",
            "AssignedTo",
            "DueDate",
            "StartDate"
        };

        private Guid _listId;
        private string _listName;
        private bool _resourceList;
        private Guid _siteId;
        private bool _system;
        private string _tableName;
        private string _tableNameSnapshot;

        private ListBiz() { }

        public ListBiz(Guid listId, Guid siteId)
        {
            _listId = listId;
            _siteId = siteId;
            var rd = new ReportData(_siteId);
            DataRow row = rd.GetListMapping(_listId);
            if (row == null)
                return;
            //throw new Exception(string.Format("List not found. ListId: {0}, SiteId: {1} ", _listId, _siteId));
            PopulateInstance(row);
        }

        public bool ResourceList
        {
            get { return _resourceList; }
        }

        public bool System
        {
            get { return _system; }
        }

        public string ListName
        {
            get { return _listName; }
        }

        private void PopulateInstance(DataRow row)
        {
            _listName = row["ListName"].ToString().Replace("'", "");
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            _tableName = row["TableName"].ToString().Replace("'", "");
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            _tableNameSnapshot = row["TableNameSnapshot"].ToString().Replace("'", "");
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            _system = (bool)row["System"];
            _resourceList = (bool)row["ResourceList"];
        }

        public void UpdateListMapping(ListItemCollection fields)
        {
            SPList spList = null;
            SPUser user = null;
            using (var site = new SPSite(_siteId))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    user = web.CurrentUser;
                }
            }

            if (user != null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (var es = new SPSite(_siteId))
                    {
                        foreach (SPWeb ew in es.AllWebs)
                        {
                            if (ew.DoesUserHavePermissions(user.LoginName, SPBasePermissions.ViewPages))
                            {
                                try
                                {
                                    spList = ew.Lists[_listId];
                                }
                                catch { }
                                finally
                                {
                                    if (ew != null)
                                    {
                                        ew.Dispose();
                                    }
                                }

                                if (spList != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                });
            }

            ColumnDefCollection columns = ColumnDef.GetDefaultColumns();
            ColumnDefCollection columnsSnapshot = ColumnDef.GetDefaultColumnsSnapshot();
            int matches = 0;
            foreach (ListItem field in fields)
            {
                SPField spField = spList.Fields[new Guid(field.Value)];
                columns.AddColumn(spField);
                columnsSnapshot.AddColumn(spField);
                if (RequiredResourceFields.Contains(spField.InternalName))
                    matches++;
            }
            _resourceList = (RequiredResourceFields.Count == matches);
            Update(columns);
            RegisterEvent();
        }

        /// <summary>
        ///     Updates list mapping with the new field
        /// </summary>
        /// <param name="newfieldId"></param>
        public void UpdateListMapping(Guid newfieldId)
        {
            SPList spList = null;
            SPUser user = null;
            using (var site = new SPSite(_siteId))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    user = web.CurrentUser;
                }
            }

            if (user != null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (var es = new SPSite(_siteId))
                    {
                        foreach (SPWeb ew in es.AllWebs)
                        {
                            if (ew.DoesUserHavePermissions(user.LoginName, SPBasePermissions.ViewPages))
                            {
                                try
                                {
                                    spList = ew.Lists[_listId];
                                }
                                catch { }
                                finally
                                {
                                    if (ew != null)
                                    {
                                        ew.Dispose();
                                    }
                                }

                                if (spList != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                });
            }

            if (spList != null)
            {
                ColumnDefCollection columns = ColumnDef.GetDefaultColumns();
                ColumnDefCollection columnsSnapshot = ColumnDef.GetDefaultColumnsSnapshot();
                int matches = 0;

                SPField spField = spList.Fields[newfieldId];
                columns.AddColumn(spField);
                columns.AddRange(GetMappedFields());
                columnsSnapshot.AddColumn(spField);
                columnsSnapshot.AddRange(GetMappedFields());
                if (RequiredResourceFields.Contains(spField.InternalName))
                    matches++;

                _resourceList = (RequiredResourceFields.Count == matches);
                Update(columns);
                RegisterEvent();
            }
        }

        public static ListBiz CreateNewMapping(Guid siteId, Guid listId, ListItemCollection fields, bool isAuto)
        {
            string webIdWithoutHyphen = string.Empty;
            bool isReportingV2Enabled = false;
            SPList spList = null;
            SPUser user = null;
            using (var site = new SPSite(siteId))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    user = web.CurrentUser;
                }
            }

            if (user != null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (var es = new SPSite(siteId))
                    {
                        foreach (SPWeb ew in es.AllWebs)
                        {
                            if (ew.DoesUserHavePermissions(user.LoginName, SPBasePermissions.ViewPages))
                            {
                                try
                                {
                                    webIdWithoutHyphen = ew.ID.ToString().Replace("-", "");
                                    spList = ew.Lists[listId];
                                }
                                catch { }
                                finally
                                {
                                    if (ew != null)
                                    {
                                        ew.Dispose();
                                    }
                                }

                                if (spList != null)
                                {
                                    try
                                    {
                                        isReportingV2Enabled = Convert.ToBoolean(EPMLiveCore.CoreFunctions.getConfigSetting(es.OpenWeb(), "reportingV2"));
                                    }
                                    catch (Exception)
                                    {
                                        isReportingV2Enabled = false;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                });
            }
            Collection<string> automatic = AutomaticFields;
            Collection<string> required = new Collection<string>();
            foreach (string s in RequiredResourceFields)
            {
                required.Add(s);
            }

            var lb = new ListBiz();
            lb._siteId = siteId;
            lb._listId = listId;
            lb._listName = spList.Title;

            ColumnDefCollection columns = ColumnDef.GetDefaultColumns();
            ColumnDefCollection columnsSnapshot = ColumnDef.GetDefaultColumnsSnapshot();
            int matches = 0;

            foreach (SPField field in spList.Fields)
            {
                if (!field.Hidden &&
                    field.Type != SPFieldType.Computed &&
                    !automatic.Contains(field.InternalName) ||
                    required.Contains(field.InternalName) ||
                    field.InternalName == "Title")
                {
                    columns.AddColumn(field);
                    columnsSnapshot.AddColumn(field);
                    //if (RequiredResourceFields.Contains(field.InternalName))
                    //{
                    //    matches++;
                    //}
                    try
                    {
                        required.Remove(field.InternalName);
                    }
                    catch { }
                }
            }

            //Adding contenttype field specifically.
            SPField fldExtId = null;
            try
            {
                fldExtId = spList.Fields.TryGetFieldByStaticName("EXTID");
            }
            catch { }

            if (fldExtId != null && !FieldExistsInCollection(fields, "extid"))
            {
                var listField = new ListItem();
                listField.Text = fldExtId.Title;
                listField.Value = fldExtId.Id.ToString();
                fields.Add(listField);
            }

            foreach (ListItem field in fields)
            {
                SPField spField = spList.Fields[new Guid(field.Value)];
                columns.AddColumn(spField);
                columnsSnapshot.AddColumn(spField);
                //if (RequiredResourceFields.Contains(spField.InternalName))
                //    matches++;
                try
                {
                    required.Remove(spField.InternalName);
                }
                catch { }
            }
            lb._resourceList = (required.Count == 0 && RequiredResourceFields.Count > 0);

            //[Fix for:Issue - Resources list sqltable being rename to LST Resourcis in Report Model. Apparently, resources is a reserved word.] by xjh -- START
            string tableName;
            if (!spList.Title.ToLower().EndsWith("resources"))
            {
                tableName = Resources.ReportingListPrefix + Utility.GetCleanAlphaNumeric(spList.Title);
            }
            else
            {
                tableName = Resources.ReportingListPrefix + "Resourcepool";
            }
            // -- END

            lb.Create(columns, columnsSnapshot, tableName);
            lb.RegisterEvent();
            return lb;
        }

        public static ListBiz CreateNewMapping(Guid siteId, Guid listId, Guid webId, ListItemCollection fields)
        {
            string webIdWithoutHyphen = string.Empty;
            bool isReportingV2Enabled = false;
            SPList spList = null;
            SPUser user = null;

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var es = new SPSite(siteId))
                {
                    using (var web = es.OpenWeb(webId))
                    {
                        user = web.CurrentUser;

                        if (web.DoesUserHavePermissions(user.LoginName, SPBasePermissions.ViewPages))
                        {
                            try
                            {
                                webIdWithoutHyphen = web.ID.ToString().Replace("-", "");
                                spList = web.Lists[listId];
                            }
                            catch { }
                            finally
                            {
                                if (web != null)
                                {
                                    web.Dispose();
                                }
                            }

                            if (spList != null)
                            {
                                try
                                {
                                    isReportingV2Enabled = Convert.ToBoolean(EPMLiveCore.CoreFunctions.getConfigSetting(es.OpenWeb(), "reportingV2"));
                                }
                                catch (Exception)
                                {
                                    isReportingV2Enabled = false;
                                }
                            }
                        }
                    }
                }
            });

            Collection<string> automatic = AutomaticFields;
            Collection<string> required = RequiredResourceFields;

            var lb = new ListBiz();
            lb._siteId = siteId;
            lb._listId = listId;
            lb._listName = spList.Title;

            ColumnDefCollection columns = ColumnDef.GetDefaultColumns();
            ColumnDefCollection columnsSnapshot = ColumnDef.GetDefaultColumnsSnapshot();
            int matches = 0;

            foreach (SPField field in spList.Fields)
            {
                if (!field.Hidden &&
                    field.Type != SPFieldType.Computed &&
                    !automatic.Contains(field.InternalName) ||
                    required.Contains(field.InternalName) ||
                    field.InternalName == "Title")
                {
                    columns.AddColumn(field);
                    columnsSnapshot.AddColumn(field);
                    if (RequiredResourceFields.Contains(field.InternalName))
                    {
                        matches++;
                    }
                }
            }

            //Adding contenttype field specifically.
            SPField fldExtId = null;
            try
            {
                fldExtId = spList.Fields.TryGetFieldByStaticName("EXTID");
            }
            catch { }

            if (fldExtId != null && !FieldExistsInCollection(fields, "extid"))
            {
                var listField = new ListItem();
                listField.Text = fldExtId.Title;
                listField.Value = fldExtId.Id.ToString();
                fields.Add(listField);
            }

            matches = 0;
            foreach (ListItem field in fields)
            {
                SPField spField = spList.Fields[new Guid(field.Value)];
                columns.AddColumn(spField);
                columnsSnapshot.AddColumn(spField);
                if (RequiredResourceFields.Contains(spField.InternalName))
                    matches++;
            }
            lb._resourceList = (RequiredResourceFields.Count == matches);

            //[Fix for:Issue - Resources list sqltable being rename to LST Resourcis in Report Model. Apparently, resources is a reserved word.] by xjh -- START
            string tableName;
            if (!spList.Title.ToLower().EndsWith("resources"))
            {
                tableName = Resources.ReportingListPrefix + Utility.GetCleanAlphaNumeric(spList.Title);
            }
            else
            {
                tableName = Resources.ReportingListPrefix + "Resourcepool";
            }
            // -- END

            lb.Create(columns, columnsSnapshot, tableName, webId);
            lb.RegisterEvent();
            return lb;
        }

        private static bool FieldExistsInCollection(ListItemCollection liCol, string fieldName)
        {
            bool exists = false;
            foreach (ListItem li in liCol)
            {
                if (li.Text.Trim().Equals(fieldName.Trim(), StringComparison.CurrentCultureIgnoreCase))
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        //public static ListBiz CreateNewMapping(Guid siteId, Guid listId)
        //{
        //    SPList spList = null;
        //    SPUser user = null;
        //    using (var site = new SPSite(siteId))
        //    {
        //        using (var web = site.OpenWeb())
        //        {
        //            user = web.CurrentUser;
        //        }
        //    }

        //    if (user != null)
        //    {
        //        SPSecurity.RunWithElevatedPrivileges(delegate()
        //        {
        //            using (SPSite es = new SPSite(siteId))
        //            {
        //                foreach (SPWeb ew in es.AllWebs)
        //                {
        //                    if (ew.DoesUserHavePermissions(user.LoginName, SPBasePermissions.ViewPages))
        //                    {
        //                        try
        //                        {
        //                            spList = ew.Lists[listId];
        //                        }
        //                        catch { }
        //                        finally
        //                        {
        //                            if (ew != null)
        //                            {
        //                                ew.Dispose();
        //                            }
        //                        }

        //                        if (spList != null)
        //                        {
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //        });
        //    }

        //    var automatic = ListBiz.AutomaticFields;
        //    var required = ListBiz.RequiredResourceFields;

        //    var lb = new ListBiz();
        //    lb._siteId = siteId;
        //    lb._listId = listId;
        //    lb._listName = spList.Title;

        //    ColumnDefCollection columns = ColumnDef.GetDefaultColumns();
        //    ColumnDefCollection columnsSnapshot = ColumnDef.GetDefaultColumnsSnapshot();
        //    var matches = 0;
        //    foreach (SPField field in spList.Fields)
        //    {
        //        if (!field.Hidden &&
        //            field.Type != SPFieldType.Computed &&
        //            !automatic.Contains(field.InternalName) ||
        //            required.Contains(field.InternalName) ||
        //            field.InternalName == "Title")
        //        {
        //            columns.AddColumn(field);
        //            columnsSnapshot.AddColumn(field);
        //            if (RequiredResourceFields.Contains(field.InternalName))
        //            {
        //                matches++;
        //            }
        //        }
        //    }
        //    lb._resourceList = (RequiredResourceFields.Count == matches);


        //    //[Fix for:Issue - Resources list sqltable being rename to LST Resourcis in Report Model. Apparently, resources is a reserved word.] by xjh -- START
        //    string tableName;
        //    if (!spList.Title.ToLower().EndsWith("resources"))
        //    {
        //        tableName = Resources.ReportingListPrefix + Utility.GetCleanAlphaNumeric(spList.Title);
        //    }
        //    else
        //    {
        //        tableName = Resources.ReportingListPrefix + "Resourcepool";
        //    }
        //    // -- END

        //    lb.Create(columns, columnsSnapshot, tableName);
        //    lb.RegisterEvent();
        //    return lb;
        //}

        private void Create(ColumnDefCollection columns, List<ColumnDef> columnsSnapshot, string tableName)
        {
            bool success = true;
            string error = string.Empty;
            var rd = new ReportData(_siteId);

            string safeTableName = rd.GetSafeTableName(tableName);
            string tableNameSnapshot = rd.GetSafeTableName(tableName + Resources.ReportingSnapshotTableSuffix);

            if (!rd.CreateTable(safeTableName, columns))
            {
                rd.InsertLog(_listId, _listName, "Error creating table.",
                    string.Format("Error creating table {0}", safeTableName), 2);
                success = false;
            }

            if (!rd.CreateTable(tableNameSnapshot, columnsSnapshot))
            {
                rd.InsertLog(_listId, _listName, "Error creating table.",
                    string.Format("Error creating table {0}", tableNameSnapshot), 2);
                success = false;
            }

            // only insert into RPTList table if table created successfully
            if ((success || (rd.TableExists(safeTableName) && rd.TableExists(tableNameSnapshot))) &&
                !rd.InsertList(_listId, safeTableName, tableNameSnapshot, _resourceList))
            {
                rd.InsertLog(_listId, _listName, string.Format("Error creating list entry"),
                    string.Format("Error creating list entry"), 2);
                success = false;
            }

            // only insert into RPTColumn table if table created successfully
            if ((success || (rd.TableExists(safeTableName) && rd.TableExists(tableNameSnapshot))) &&
                !rd.InsertListColumns(_listId, columns))
            {
                rd.InsertLog(_listId, _listName.Replace("'", ""), string.Format("Error creating column entries"),
                    string.Format("Error creating column entries"), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                success = false;
            }

            if (success)
                rd.InsertLog(_listId, _listName.Replace("'", ""), "Created list mappings.",
                    string.Format("Created list mapping: Columns {0}", columns), 0);
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            else
                rd.InsertLog(_listId, _listName.Replace("'", ""), "An error occurred while creating list mapping.",
                    string.Format("Errors occurred while creating list mapping: Columns: {0}", columns), 1);
            // - CAT.NET false-positive: All single quotes are escaped/removed.
        }

        private void Create(ColumnDefCollection columns, List<ColumnDef> columnsSnapshot, string tableName, Guid webId)
        {
            bool success = true;
            string error = string.Empty;
            var rd = new ReportData(true, _siteId, webId);

            string safeTableName = rd.GetSafeTableName(tableName);
            string tableNameSnapshot = rd.GetSafeTableName(tableName + Resources.ReportingSnapshotTableSuffix);

            if (!rd.CreateTable(safeTableName, columns))
            {
                rd.InsertLog(_listId, _listName, "Error creating table.",
                    string.Format("Error creating table {0}", safeTableName), 2);
                success = false;
            }

            if (!rd.CreateTable(tableNameSnapshot, columnsSnapshot))
            {
                rd.InsertLog(_listId, _listName, "Error creating table.",
                    string.Format("Error creating table {0}", tableNameSnapshot), 2);
                success = false;
            }

            // only insert into RPTList table if table created successfully
            if ((success || (rd.TableExists(safeTableName) && rd.TableExists(tableNameSnapshot))) &&
                !rd.InsertList(_listId, safeTableName, tableNameSnapshot, _resourceList))
            {
                rd.InsertLog(_listId, _listName, string.Format("Error creating list entry"),
                    string.Format("Error creating list entry"), 2);
                success = false;
            }

            // only insert into RPTColumn table if table created successfully
            if ((success || (rd.TableExists(safeTableName) && rd.TableExists(tableNameSnapshot))) &&
                !rd.InsertListColumns(_listId, columns))
            {
                rd.InsertLog(_listId, _listName.Replace("'", ""), string.Format("Error creating column entries"),
                    string.Format("Error creating column entries"), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                success = false;
            }

            if (success)
                rd.InsertLog(_listId, _listName.Replace("'", ""), "Created list mappings.",
                    string.Format("Created list mapping: Columns {0}", columns), 0);
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            else
                rd.InsertLog(_listId, _listName.Replace("'", ""), "An error occurred while creating list mapping.",
                    string.Format("Errors occurred while creating list mapping: Columns: {0}", columns), 1);
            // - CAT.NET false-positive: All single quotes are escaped/removed.
        }

        private void Update(ColumnDefCollection columns)
        {
            ColumnDefCollection existingColumns = GetMappedFields();
            ColumnDefCollection newColumns = existingColumns.DiffColumns(columns);
            ColumnDefCollection oldColumns = columns.DiffColumns(existingColumns);

            bool success = true;

            var rd = new ReportData(_siteId);
            if (!rd.AddColumns(_tableName, newColumns))
            {
                rd.InsertLog(_listId, _listName.Replace("'", ""), "An error occurred while adding columns.",
                    string.Format("Error adding columns to table {0}", _tableName), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                success = false;
            }

            if (!rd.AddColumns(_tableNameSnapshot, newColumns))
            {
                rd.InsertLog(_listId, _listName.Replace("'", ""), "An error occurred while adding columns to table.",
                    string.Format("Error adding columns to table {0}", _tableNameSnapshot), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                success = false;
            }

            if (!rd.DeleteColumns(_tableName, oldColumns))
            {
                rd.InsertLog(_listId, _listName.Replace("'", ""), "An error occurred while deleting columns.",
                    string.Format("Error deleting columns from table {0}", _tableName), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                success = false;
            }

            if (!rd.DeleteColumns(_tableNameSnapshot, oldColumns))
            {
                rd.InsertLog(_listId, _listName.Replace("'", ""), "An error occurred while deleting columns.",
                    string.Format("Error deleting columns from table {0}", _tableNameSnapshot), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                success = false;
            }

            if (!rd.InsertListColumns(_listId, newColumns))
            {
                rd.InsertLog(_listId, _listName.Replace("'", ""), "Error creating column entries",
                    string.Format("Error creating column entries"), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                success = false;
            }
            if (!rd.DeleteListColumns(_listId, oldColumns))
            {
                rd.InsertLog(_listId, _listName.Replace("'", ""), "Error deleting column entries.",
                    string.Format("Error deleting column entries"), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                success = false;
            }

            if (!rd.UpdateList(_listId, _resourceList))
            {
                rd.InsertLog(_listId, _listName.Replace("'", ""), string.Format("Error updating list entry"),
                    string.Format("Error updating list entry"), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                success = false;
            }
            if (success)
                rd.InsertLog(_listId, _listName.Replace("'", ""), "Updated list mapping.",
                    string.Format("Updated list mapping: Added {0}, Deleted {1}", newColumns, oldColumns), 0);
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            else
                rd.InsertLog(_listId, _listName.Replace("'", ""), "Errors occurred while updating list mapping.",
                    string.Format("Errors occurred while updating list mapping: Adding {0}, Deleting {1}", newColumns,
                        oldColumns), 1); // - CAT.NET false-positive: All single quotes are escaped/removed.
        }

        public bool Delete()
        {
            var rd = new ReportData(_siteId);
            RemoveEvent();

            if (rd.DeleteTable(_tableName.Replace("'", ""))
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                && rd.DeleteTable(_tableNameSnapshot.Replace("'", "")))
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                return
                    //rd.DeleteAllListColumns(_listId) && 
                    rd.DeleteList(_listId)
                    && rd.DeleteLog(_listId)
                    && rd.DeleteWork(_listId);
            return false;
        }

        public DataTable GetLog(int minimumLevel)
        {
            var rd = new ReportData(_siteId);
            return rd.GetLog(_listId, minimumLevel);
        }

        public void ClearLog(object type)
        {
            var rd = new ReportData(_siteId);
            int it;
            bool success = int.TryParse(type.ToString(), out it);
            if (success)
                rd.DeleteLog(_listId, it);
            else
                rd.DeleteLog(_listId);
        }

        public int GetMaximumLogLevel()
        {
            var rd = new ReportData(_siteId);
            return rd.GetMaximumLogLevel(_listId);
        }

        public List<string> GetMappedFieldsStrings()
        {
            var fields = new List<string>();
            var rd = new ReportData(_siteId);
            DataTable dt = rd.GetListColumns(_listId);
            foreach (DataRow row in dt.Rows)
            {
                fields.Add(row["InternalName"].ToString());
            }
            return fields;
        }

        public ColumnDefCollection GetMappedFields()
        {
            var fields = new ColumnDefCollection();
            var rd = new ReportData(_siteId);
            DataTable dt = rd.GetListColumns(_listId);
            foreach (DataRow row in dt.Rows)
            {
                fields.Add(new ColumnDef(row));
            }
            return fields;
        }

        public bool SetResourceListFlag(bool flag)
        {
            var rd = new ReportData(_siteId);
            return rd.UpdateList(_listId, flag);
        }

        public bool Snapshot()
        {
            var rd = new ReportData(_siteId);
            bool success = rd.SnapshotLists(_listName.Replace("'", ""));
            if (success)
                rd.InsertLog(_listId, _listName.Replace("'", ""), "Snapshot completed.", "Manual snapshot completed", 0);
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            else
                rd.InsertLog(_listId, _listName.Replace("'", ""), "Error taking snapshot.",
                    "Error taking manual snapshot", 2);
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            return success;
        }

        private void RegisterEvent()
        {
            SPList spList = null;
            var DAO = new ReportData(_siteId);

            try
            {
                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        using (var spSite = new SPSite(_siteId))
                        {
                            spList = null;
                            foreach (SPWeb spWeb in spSite.AllWebs)
                            {
                                using (spWeb)
                                {
                                    spWeb.AllowUnsafeUpdates = true;
                                    try
                                    {
                                        try
                                        {
                                            spList = spWeb.Lists[_listName];
                                        }
                                        catch { }

                                        if (spList == null)
                                        {
                                            continue;
                                        }

                                        // remove existing event receivers first
                                        List<SPEventReceiverDefinition> evts = GetListEvents(spList,
                                            Resources.ReportingAssembly,
                                            Resources.ReportingClassName,
                                            new List<SPEventReceiverType>
                                            {
                                                SPEventReceiverType.ItemAdded,
                                                SPEventReceiverType.ItemUpdated,
                                                SPEventReceiverType.ItemDeleting
                                            });

                                        foreach (SPEventReceiverDefinition e in evts)
                                        {
                                            e.Delete();
                                        }

                                        // then add event receivers
                                        spList.EventReceivers.Add(SPEventReceiverType.ItemAdded, Resources.ReportingAssembly,
                                            Resources.ReportingClassName);
                                        spList.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Resources.ReportingAssembly,
                                            Resources.ReportingClassName);
                                        spList.EventReceivers.Add(SPEventReceiverType.ItemDeleting, Resources.ReportingAssembly,
                                            Resources.ReportingClassName);

                                        List<SPEventReceiverDefinition> newEvts = GetListEvents(spList,
                                            Resources.ReportingAssembly,
                                            Resources.ReportingClassName,
                                            new List<SPEventReceiverType>
                                            {
                                                SPEventReceiverType.ItemAdded,
                                                SPEventReceiverType.ItemUpdated,
                                                SPEventReceiverType.ItemDeleting
                                            });

                                        foreach (SPEventReceiverDefinition e in newEvts)
                                        {
                                            e.SequenceNumber = 11000;
                                            e.Update();
                                        }

                                        spList.Update();

                                        //Add list and field deleting event handlers IF it's the rootweb                                        
                                        //if (spWeb.Url.ToLower() == spSite.RootWeb.Url.ToLower())
                                        //{
                                        // remove existing event receivers first
                                        List<SPEventReceiverDefinition> delEvts = GetListEvents(spList,
                                            Resources.ReportingAssembly,
                                            "EPMLiveReportsAdmin.LstEvents",
                                            new List<SPEventReceiverType>
                                            {
                                                SPEventReceiverType.FieldAdding,
                                                SPEventReceiverType.ListDeleting,
                                                SPEventReceiverType.FieldAdded,
                                                SPEventReceiverType.FieldUpdated,
                                                SPEventReceiverType.FieldDeleting

                                            });

                                        foreach (SPEventReceiverDefinition e in delEvts)
                                        {
                                            e.Delete();
                                        }

                                        // then add event receivers
                                        spList.EventReceivers.Add(SPEventReceiverType.FieldAdding, Resources.ReportingAssembly,
                                          "EPMLiveReportsAdmin.LstEvents");
                                        spList.EventReceivers.Add(SPEventReceiverType.ListDeleting, Resources.ReportingAssembly,
                                            "EPMLiveReportsAdmin.LstEvents");
                                        spList.EventReceivers.Add(SPEventReceiverType.FieldAdded, Resources.ReportingAssembly,
                                            "EPMLiveReportsAdmin.LstEvents");
                                        spList.EventReceivers.Add(SPEventReceiverType.FieldUpdated, Resources.ReportingAssembly,
                                            "EPMLiveReportsAdmin.LstEvents");
                                        spList.EventReceivers.Add(SPEventReceiverType.FieldDeleting, Resources.ReportingAssembly,
                                            "EPMLiveReportsAdmin.LstEvents");

                                        List<SPEventReceiverDefinition> newEvts2 = GetListEvents(spList,
                                            Resources.ReportingAssembly,
                                            "EPMLiveReportsAdmin.LstEvents",
                                            new List<SPEventReceiverType>
                                            {
                                                SPEventReceiverType.FieldAdding,
                                                SPEventReceiverType.ListDeleting,
                                                SPEventReceiverType.FieldAdded,
                                                SPEventReceiverType.FieldUpdated,
                                                SPEventReceiverType.FieldDeleting,
                                            });
                                        foreach (SPEventReceiverDefinition e in newEvts2)
                                        {
                                            e.SequenceNumber = 11000;
                                            e.Update();
                                        }
                                        //}
                                    }
                                    catch (Exception ex)
                                    {
                                        //Report "List Not Present" error
                                        DAO.LogStatus(_listId, _listName,
                                            spWeb.ServerRelativeUrl + " - Event registration issue.",
                                            "Warning: " + _listName.Replace("'", "") + " list not present. On site:" +
                                            spWeb.ServerRelativeUrl, 0, 1);
                                        // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    }
                                    spWeb.AllowUnsafeUpdates = false;
                                }
                            }
                        }
                    });

                var rd = new ReportData(_siteId);
            }
            catch (Exception ex)
            {
                var rd = new ReportData(_siteId);
                if (spList != null)
                    rd.InsertLog(spList.ID, spList.Title.Replace("'", ""), "Created Mapping", "Created Mapping", 0);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                else
                    rd.InsertLog(Guid.Empty, "Unknown", "An error occurred while registering event.",
                        string.Format("Can't register event on site {0} - Exception: {1}", _siteId,
                            ex.Message.Replace("'", "")), 2);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
            }
        }

        private List<SPEventReceiverDefinition> GetListEvents(SPList list, string assemblyName, string className,
            List<SPEventReceiverType> types)
        {
            var evts = new List<SPEventReceiverDefinition>();

            try
            {
                evts = (from e in list.EventReceivers.OfType<SPEventReceiverDefinition>()
                        where e.Assembly.Equals(assemblyName, StringComparison.CurrentCultureIgnoreCase) &&
                              e.Class.Equals(className, StringComparison.CurrentCultureIgnoreCase) &&
                              types.Contains(e.Type)
                        select e).ToList<SPEventReceiverDefinition>();
            }
            catch { }

            return evts;
        }

        private void RemoveEvent()
        {
            SPEventReceiverDefinitionCollection spEventCollection = null;
            SPEventReceiverDefinition spEventDef;
            SPList spList = null;
            var DAO = new ReportData(_siteId);

            try
            {
                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        using (var spSite = new SPSite(_siteId))
                        {
                            foreach (SPWeb spWeb in spSite.AllWebs)
                            {
                                using (spWeb)
                                {
                                    spWeb.AllowUnsafeUpdates = true;
                                    spList = null;
                                    try
                                    {
                                        spList = spWeb.Lists[_listName];
                                        spEventCollection = spList.EventReceivers;
                                    }
                                    catch (Exception) { }

                                    if (spList != null)
                                    {
                                        var delEvents = new List<SPEventReceiverDefinition>();

                                        foreach (SPEventReceiverDefinition def in spEventCollection)
                                        {
                                            if (def.Class.Equals(Resources.ReportingClassName,
                                                StringComparison.CurrentCultureIgnoreCase))
                                            {
                                                delEvents.Add(def);
                                            }
                                        }

                                        foreach (SPEventReceiverDefinition def in delEvents)
                                        {
                                            def.Delete();
                                        }
                                    }
                                    else
                                    {
                                        //Report "List Not Present" error
                                        DAO.ReportError(_listId, _listName.Replace("'", ""),
                                            _listName.Replace("'", "") +
                                            ": Unable to delete event handlers. List not present.",
                                            spWeb.ServerRelativeUrl, 1);
                                        // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    }
                                    spWeb.AllowUnsafeUpdates = false;
                                }
                            }
                        }
                    });

                var rd = new ReportData(_siteId);
                rd.InsertLog(spList.ID, spList.Title, "Created Mapping", "Created Mapping", 0);
            }
            catch (Exception ex)
            {
                var rd = new ReportData(_siteId);
                if (spList != null)
                    rd.InsertLog(spList.ID, spList.Title, "Created Mapping", "Created Mapping", 0);
                else
                    rd.InsertLog(Guid.Empty, "Unknown", "An error occurred while registering event handlers.",
                        string.Format("Can't register event on site {0} - Exception: {1}", _siteId, ex.Message), 2);
            }
            //SPSecurity.RunWithElevatedPrivileges(delegate { c_spSite = new SPSite(_siteId); });

            //using (SPWeb c_spWeb = c_spSite.OpenWeb())
            //{
            //    c_spWeb.AllowUnsafeUpdates = true;
            //    spEventCollection = c_spWeb.Lists[_listId].EventReceivers;
            //    iEventCount = spEventCollection.Count;

            //    while (iEventCounter < iEventCount)
            //    {
            //        spEventDef = spEventCollection[iEventCounter];
            //        if (spEventDef.Class.ToLower() == Resources.ReportingClassName.ToLower())
            //        {
            //            spEventDef.Delete();
            //        }
            //        iEventCounter++;
            //    }
            //    c_spWeb.AllowUnsafeUpdates = false;
            //}
        }
    }
}