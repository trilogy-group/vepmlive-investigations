using System;
using System.Data;
using System.Diagnostics;
using Microsoft.SharePoint;
using System.Web;
using System.Xml;


namespace EPMLiveReportsAdmin
{
    public class LstEvents : SPListEventReceiver
    {
        private HttpContext currentContext;
        static HttpContext _stCurrentContext;

        public LstEvents()
        {
            currentContext = HttpContext.Current;
        }

        public override void ListDeleting(SPListEventProperties properties)
        {
            DeleteList(properties);
        }

        public override void FieldDeleting(SPListEventProperties properties)
        {
            if (properties.Field.InternalName.ToLower() == "today")
            {
                return;
            }

            DeleteField(properties);
        }

        public override void FieldAdded(SPListEventProperties properties)
        {
            try
            {
                _stCurrentContext.Session["ViewSession"] = null;
            }
            catch {
            }
           
            if (properties.Field.InternalName.ToLower() == "today")
            {
                return;
            }

            AddField(properties);
        }

        public override void FieldAdding(SPListEventProperties properties)
        {
            _stCurrentContext = currentContext;
            if (properties != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(properties.FieldXml);
                if (doc != null)
                {
                    bool isHidden = Convert.ToBoolean(doc.FirstChild.Attributes["Hidden"].Value);
                    if (!isHidden)
                    {
                        if (properties.FieldName.ToLower().EndsWith("id") || properties.FieldName.ToLower().EndsWith("text"))
                        {
                            properties.Status = SPEventReceiverStatus.CancelWithError;
                            properties.ErrorMessage = "Field ending with ID or Text is not allowed.";

                        }
                    }
                }
            }            
        }

        public override void FieldUpdated(SPListEventProperties properties)
        {
            if (properties.Field.InternalName.ToLower() == "today")
            {
                return;
            }

            UpdateField(properties);
        }

        private bool DeleteList(SPListEventProperties properties)
        {
            bool isSuccessful = true;
            var reportBiz = new ReportBiz(properties.SiteId);
            Guid listId = properties.ListId;
            var DAO = new EPMData(properties.SiteId);
            DAO.Command = "SELECT TableName FROM RPTList WHERE RPTListID=@RPTListID";
            DAO.AddParam("@RPTListID", listId);
            string sTableName = string.Empty;
            try
            {
                sTableName = DAO.ExecuteScalar(DAO.GetClientReportingConnection).ToString();
                DataTable refTables = reportBiz.GetReferencingTables(DAO, sTableName);
                if (refTables.Rows.Count == 0)
                {
                    reportBiz.GetListBiz(listId).Delete();
                }
                else
                {
                    isSuccessful = false;
                    DAO.LogStatus(listId.ToString(), sTableName,
                        "Database table delete attempt: Unable to delete " + sTableName + ".",
                        sTableName + " is referenced by other tables.", 2, 5, Guid.NewGuid().ToString());
                    //Logged in the RefreshAll event log.
                }
            }
            catch (Exception ex)
            {
                DAO.LogStatus(listId.ToString(), sTableName,
                    "Database table delete attempt: Unable to delete " + sTableName + ". " + ex.Message, ex.StackTrace,
                    2, 5, Guid.NewGuid().ToString()); //Logged in the RefreshAll event log.
            }
            reportBiz = null;
            DAO.Dispose();
            return isSuccessful;
        }

        private bool DeleteField(SPListEventProperties properties)
        {
            bool isSuccessful = true;
            string tableName = string.Empty;
            string ssTableName = string.Empty;
            var rb = new ReportBiz(properties.SiteId);

            try
            {
                var rd = new ReportData(properties.SiteId);
                var cols = new ColumnDefCollection();
                //ColumnDef cd = new ColumnDef(properties.Field);
                tableName = rd.GetTableName(properties.ListId);
                ssTableName = rd.GetTableNameSnapshot(properties.ListId);
                cols.AddColumn(properties.Field);
                rd.DeleteColumns(tableName, cols);
                rd.DeleteColumns(ssTableName, cols);
                rd.DeleteListColumns(properties.ListId, cols);
                rd.Dispose();
            }
            catch (Exception ex)
            {
                var DAO = new EPMData(properties.SiteId);
                DAO.LogStatus(properties.ListId.ToString(), properties.FieldName,
                    "Database column delete attempt: Unable to column " + properties.FieldName + ". " + ex.Message,
                    ex.StackTrace, 2, 5, Guid.NewGuid().ToString()); //Logged in the RefreshAll event log.
                DAO.Dispose();
            }

            if (properties.Field is SPFieldLookup)
            {
                try
                {
                    //FOREIGN IMPLEMENTATION -- START
                    var DAO = new EPMData(properties.SiteId);
                    rb.UpdateForeignKeys(DAO);
                    DAO.Dispose();
                    // -- END
                }
                catch (Exception ex)
                {
                    isSuccessful = false;
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - UpdateForeignKeys"))
                            EventLog.CreateEventSource("EPMLive Reporting - UpdateForeignKeys", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting - UpdateForeignKeys");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(ex.Message + ex.StackTrace, EventLogEntryType.Error, 4001);
                    });
                }
            }

            return isSuccessful;
        }

        private bool AddField(SPListEventProperties properties)
        {
            bool isSuccessful = true;
            string tableName = string.Empty;
            string ssTableName = string.Empty;
            var rb = new ReportBiz(properties.SiteId);

            try
            {
                var rd = new ReportData(properties.SiteId);
                var cols = new ColumnDefCollection();
                tableName = rd.GetTableName(properties.ListId);
                ssTableName = rd.GetTableNameSnapshot(properties.ListId);

                if (!rd.ColumnExists(tableName, properties.Field.InternalName))
                {
                    cols.AddColumn(properties.Field);
                    rd.AddColumns(tableName, cols);
                    rd.AddColumns(ssTableName, cols);
                    rd.InsertListColumns(properties.ListId, cols);
                }
                rd.Dispose();
            }
            catch (Exception ex)
            {
                var DAO = new EPMData(properties.SiteId);
                DAO.LogStatus(properties.ListId.ToString(), properties.FieldName,
                    "Database column add attempt: Unable to add column " + properties.FieldName + ". " + ex.Message,
                    ex.StackTrace, 2, 5, Guid.NewGuid().ToString()); //Logged in the RefreshAll event log.
                DAO.Dispose();
            }

            if (properties.Field is SPFieldLookup)
            {
                try
                {
                    //FOREIGN IMPLEMENTATION -- START
                    var DAO = new EPMData(properties.SiteId);
                    rb.UpdateForeignKeys(DAO);
                    DAO.Dispose();
                    // -- END
                }
                catch (Exception ex)
                {
                    isSuccessful = false;
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - UpdateForeignKeys"))
                            EventLog.CreateEventSource("EPMLive Reporting - UpdateForeignKeys", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting - UpdateForeignKeys");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(ex.Message + ex.StackTrace, EventLogEntryType.Error, 4001);
                    });
                }
            }

            return isSuccessful;
        }

        private bool UpdateField(SPListEventProperties properties)
        {
            bool isSuccessful = true;
            string tableName = string.Empty;
            string ssTableName = string.Empty;
            var rb = new ReportBiz(properties.SiteId);
            bool isUpdateRequire = false;
            try
            {
                var rd = new ReportData(properties.SiteId);
                var cols = new ColumnDefCollection();
                // Actual table name
                tableName = rd.GetTableName(properties.ListId);
                // Snapshot table name
                ssTableName = rd.GetTableNameSnapshot(properties.ListId);
                // Create column definition collection to process with
                cols.AddColumn(properties.Field);

                var DAO = new EPMData(properties.SiteId);
                // Update only when field type is changed from single to multi value and vice-verse
                if (IsUpdateRequire(DAO, properties, tableName, cols[0].SqlColumnName))
                {
                    isUpdateRequire = true;

                    // Get Foreign Key
                    DataTable foreignKeyTable = rb.GetSpecificForeignKey(DAO, properties.ListId.ToString(), tableName, cols[0].SqlColumnName);

                    // Delete Foreign Key
                    if (foreignKeyTable.Rows.Count > 0)
                    {
                        rb.AddORRemoveForeignKey(DAO, foreignKeyTable.Rows[0], false);
                    }

                    // Delete & Add Field
                    rd.UpdateColumns(tableName, cols);
                    rd.UpdateColumns(ssTableName, cols);
                    rd.UpdateListColumns(properties.ListId, cols);

                    // Add Foreign Key only if lookup type is NOT allowed multi select
                    if (foreignKeyTable.Rows.Count > 0 && !properties.Field.TypeAsString.Equals("LookupMulti", StringComparison.InvariantCultureIgnoreCase))
                    {
                        rb.AddORRemoveForeignKey(DAO, foreignKeyTable.Rows[0], true);
                    }
                }
                DAO.Dispose();
                rd.Dispose();
            }
            catch (Exception ex)
            {
                var DAO = new EPMData(properties.SiteId);
                DAO.LogStatus(properties.ListId.ToString(), properties.FieldName,
                    "Database column update attempt: Unable to update column " + properties.FieldName + ". " + ex.Message,
                    ex.StackTrace, 2, 5, Guid.NewGuid().ToString()); //Logged in the RefreshAll event log.
                DAO.Dispose();
            }

            if (properties.Field is SPFieldLookup && isUpdateRequire)
            {
                #region Update all foreign keys
                try
                {
                    //FOREIGN IMPLEMENTATION -- START
                    var DAO = new EPMData(properties.SiteId);
                    rb.UpdateForeignKeys(DAO);
                    DAO.Dispose();
                    // -- END
                }
                catch (Exception ex)
                {
                    isSuccessful = false;
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - UpdateForeignKeys"))
                            EventLog.CreateEventSource("EPMLive Reporting - UpdateForeignKeys", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting - UpdateForeignKeys");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(ex.Message + ex.StackTrace, EventLogEntryType.Error, 4001);
                    });
                }
                #endregion

                #region Cleanup list after field data type update to retain value
                try
                {
                    // List clean up -- START
                    var _DAO = new EPMData(properties.SiteId);
                    CleanupListAfterFieldUpdate(_DAO, properties.ListTitle);
                    // -- END
                }
                catch (Exception ex)
                {
                    isSuccessful = false;
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - CleanupListAfterFieldUpdate"))
                            EventLog.CreateEventSource("EPMLive Reporting - CleanupListAfterFieldUpdate", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting - CleanupListAfterFieldUpdate");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(ex.Message + ex.StackTrace, EventLogEntryType.Error, 4001);
                    });
                }
                #endregion
            }
            return isSuccessful;
        }

        private void CleanupListAfterFieldUpdate(EPMData DAO, string sList)
        {
            using (SPSite site = new SPSite(DAO.SiteId))
            {
                using (SPWeb web = site.RootWeb)
                {
                    Guid listID = DAO.GetListId(sList, web.ID);

                    //DELETE WORK
                    DAO.DeleteWork(listID, -1);
                    //END

                    DAO.Command =
                        "select timerjobuid from timerjobs where siteguid=@siteguid and listguid = @listguid and jobtype=6";
                    DAO.AddParam("@siteguid", site.ID.ToString());
                    DAO.AddParam("@listguid", listID.ToString());
                    object oResult = DAO.ExecuteScalar(DAO.GetEPMLiveConnection);

                    Guid timerjobuid = Guid.Empty;

                    if (oResult != null)
                    {
                        timerjobuid = (Guid)oResult;
                    }
                    else
                    {
                        timerjobuid = Guid.NewGuid();
                        DAO.Command =
                            "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid, listguid, jobdata) VALUES (@timerjobuid, @siteguid, 6, 'List Data Cleanup', 0, @webguid, @listguid, @jobdata)";
                        DAO.AddParam("@siteguid", site.ID.ToString());
                        DAO.AddParam("@webguid", web.ID.ToString());
                        DAO.AddParam("@listguid", listID.ToString());
                        DAO.AddParam("@jobdata", sList);
                        DAO.AddParam("@timerjobuid", timerjobuid);
                        DAO.ExecuteNonQuery(DAO.GetEPMLiveConnection);
                    }

                    if (timerjobuid != Guid.Empty)
                        EPMLiveCore.CoreFunctions.enqueue(timerjobuid, 0, site);
                }
            }
            //--End
        }

        private bool IsUpdateRequire(EPMData DAO, SPListEventProperties properties, string tableName, string columnName)
        {
            if (properties.Field.Type.Equals(SPFieldType.Lookup))
            {
                string fieldType = properties.Field.TypeAsString;
                try
                {
                    DAO.Command = "SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "' AND COLUMN_NAME = '" + columnName + "'";
                    string result = Convert.ToString(DAO.ExecuteScalar(DAO.GetClientReportingConnection));

                    if ((result.Equals("ntext", StringComparison.InvariantCultureIgnoreCase) && fieldType.Equals("Lookup", StringComparison.InvariantCultureIgnoreCase))
                        || result.Equals("int", StringComparison.InvariantCultureIgnoreCase) && fieldType.Equals("LookupMulti", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}