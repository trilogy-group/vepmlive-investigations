using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.SharePoint;
using System.Diagnostics;
using System.Security.Principal;
using System.Xml;
using System.Web;
using System.Configuration;
using System.Collections;
using System.Data;


namespace EPMLiveReportsAdmin
{
    public class LstEvents : SPListEventReceiver
    {
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
            if (properties.Field.InternalName.ToLower() == "today")
            {
                return;
            }

            AddField(properties);
        }

        private bool DeleteList(SPListEventProperties properties)
        {
            bool isSuccessful = true;
            var reportBiz = new ReportBiz(properties.SiteId);
            Guid listId = properties.ListId;
            EPMData DAO = new EPMData(properties.SiteId);
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
                    DAO.LogStatus(listId.ToString(), sTableName, "Database table delete attempt: Unable to delete " + sTableName + ".", sTableName + " is referenced by other tables.", 2, 5, Guid.NewGuid().ToString()); //Logged in the RefreshAll event log.
                }
            }
            catch (Exception ex)
            {
                DAO.LogStatus(listId.ToString(), sTableName, "Database table delete attempt: Unable to delete " + sTableName + ". " + ex.Message, ex.StackTrace, 2, 5, Guid.NewGuid().ToString()); //Logged in the RefreshAll event log.
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
                ReportData rd = new ReportData(properties.SiteId);
                ColumnDefCollection cols = new ColumnDefCollection();
                //ColumnDef cd = new ColumnDef(properties.Field);
                tableName = rd.GetTableName(properties.ListTitle);
                ssTableName = rd.GetTableNameSnapshot(properties.ListId);
                cols.AddColumn(properties.Field);
                rd.DeleteColumns(tableName, cols);
                rd.DeleteColumns(ssTableName, cols);
                rd.DeleteListColumns(properties.ListId, cols);
                rd.Dispose();
            }
            catch (Exception ex)
            {
                EPMData DAO = new EPMData(properties.SiteId);
                DAO.LogStatus(properties.ListId.ToString(), properties.FieldName, "Database column delete attempt: Unable to column " + properties.FieldName + ". " + ex.Message, ex.StackTrace, 2, 5, Guid.NewGuid().ToString()); //Logged in the RefreshAll event log.
                DAO.Dispose();
            }

            if (properties.Field is SPFieldLookup)
            {
                try
                {
                    //FOREIGN IMPLEMENTATION -- START
                    EPMData DAO = new EPMData(properties.SiteId);
                    rb.UpdateForeignKeys(DAO);
                    DAO.Dispose();
                    // -- END
                }
                catch (Exception ex)
                {
                    isSuccessful = false;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - UpdateForeignKeys"))
                            EventLog.CreateEventSource("EPMLive Reporting - UpdateForeignKeys", "EPM Live");

                        EventLog myLog = new EventLog("EPM Live", ".", "EPMLive Reporting - UpdateForeignKeys");
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
                ReportData rd = new ReportData(properties.SiteId);
                ColumnDefCollection cols = new ColumnDefCollection();
                tableName = rd.GetTableName(properties.ListTitle);
                ssTableName = rd.GetTableNameSnapshot(properties.ListId);
                cols.AddColumn(properties.Field);
                rd.AddColumns(tableName, cols);
                rd.AddColumns(ssTableName, cols);
                rd.InsertListColumns(properties.ListId, cols);
                rd.Dispose();
            }
            catch (Exception ex)
            {
                EPMData DAO = new EPMData(properties.SiteId);
                DAO.LogStatus(properties.ListId.ToString(), properties.FieldName, "Database column add attempt: Unable to add column " + properties.FieldName + ". " + ex.Message, ex.StackTrace, 2, 5, Guid.NewGuid().ToString()); //Logged in the RefreshAll event log.
                DAO.Dispose();
            }

            if (properties.Field is SPFieldLookup)
            {
                try
                {
                    //FOREIGN IMPLEMENTATION -- START
                    EPMData DAO = new EPMData(properties.SiteId);
                    rb.UpdateForeignKeys(DAO);
                    DAO.Dispose();
                    // -- END
                }
                catch (Exception ex)
                {
                    isSuccessful = false;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - UpdateForeignKeys"))
                            EventLog.CreateEventSource("EPMLive Reporting - UpdateForeignKeys", "EPM Live");

                        EventLog myLog = new EventLog("EPM Live", ".", "EPMLive Reporting - UpdateForeignKeys");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(ex.Message + ex.StackTrace, EventLogEntryType.Error, 4001);
                    });
                }
            }

            return isSuccessful;
        }


        
    }
}
