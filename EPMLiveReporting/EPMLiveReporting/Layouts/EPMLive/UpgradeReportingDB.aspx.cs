﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using EPMLiveCore;
using EPMLiveReportsAdmin.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class UpgradeReportingDB : LayoutsPageBase
    {
		#region Fields (1) 

        private List<HtmlGenericControl> _messages;

		#endregion Fields 

		#region Methods (9) 

		// Public Methods (1) 

        public List<HtmlGenericControl> Upgrade()
        {
            _messages = new List<HtmlGenericControl>();

            UpgradeDatabase();
            UpgradeListMappings();

            return _messages;
        }
		// Protected Methods (2) 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var reportBiz = new ReportBiz(SPContext.Current.Site.ID);

                if (reportBiz.SiteExists()) return;

                NotConfiguredLabel.Visible = true;
                ConfiguredLabel.Visible = false;
                UpgradeButton.Enabled = false;
                UpgradeButton.CssClass += " button-green-disabled";
            }
            else
            {
                TitleLiteral.Text = "Upgrade Reporting Database - Completed";
                ConfiguredLabel.Visible = false;
                UpgradeButton.Visible = false;
            }
        }

        protected void UpgradeButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Upgrade();

                MessageLabel.Text = "Upgrade Result:";
            }
            catch (Exception exception)
            {
                MessageLabel.ForeColor = Color.Red;

                foreach (
                    string message in
                        exception.Message.Split(new[] {"\r", "\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries))
                {
                    MessageLabel.Text += message + "<br/>";
                }

                MessageLabel.Visible = true;
            }
            finally
            {
                foreach (HtmlGenericControl htmlGenericControl in _messages)
                {
                    MessagePanel.Controls.Add(htmlGenericControl);
                }
            }
        }
		// Private Methods (6) 

        private void ExecuteUpgradeScripts(EPMData epmData, Guid siteId)
        {
            using (SqlConnection sqlConnection = epmData.GetSpecificReportingDbConnection(siteId))
            {
                sqlConnection.FireInfoMessageEventOnUserErrors = true;
                sqlConnection.InfoMessage += SqlConnectionInfoMessage;

                FileVersionInfo fileVersionInfo =
                    FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

                foreach (
                    string command in new[] {Resources.InitDatabaseCreateTables, Resources.InitDatabaseCreateProcedures}
                        .Select(s => s.Replace("@version", "''" + fileVersionInfo.FileVersion + "''")))
                {
                    try
                    {
                        using (var sqlCommand = new SqlCommand(command, sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException exception)
                    {
                        foreach (SqlError sqlError in exception.Errors)
                        {
                            LogError(string.Format("Msg {0}, Procedure {1}, Line {2}", sqlError.Number,
                                                   sqlError.Procedure, sqlError.LineNumber));
                            LogError(exception.Message);
                        }
                    }
                }

                object username = null;

                try
                {
                    using (
                        var sqlCommand =
                            new SqlCommand("SELECT ClientUsername FROM dbo.RPTDATABASES WHERE (SiteId = @SiteId)",
                                           epmData.GetEPMLiveConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@SiteId", siteId);
                        sqlCommand.CommandType = CommandType.Text;

                        username = sqlCommand.ExecuteScalar();
                    }
                }
                catch (SqlException exception)
                {
                    //foreach (SqlError sqlError in exception.Errors)
                    //{
                    //    LogError(string.Format("Msg {0}, Procedure {1}, Line {2}", sqlError.Number,
                    //                           sqlError.Procedure, sqlError.LineNumber));
                    //    LogError(exception.Message);
                    //}
                }

                if (username != null && username != DBNull.Value)
                {
                    const string query =
                        @"EXEC sp_executesql N'IF (ISNULL(OBJECT_ID(''@SP''),'''')) <> '''' BEGIN PRINT ''Granting EXECUTE permission to @Username on @SP'' GRANT EXECUTE ON @SP TO @Username END'";

                    foreach (string sp in new[] {"spRPTWork", "spRPTGetCapacity", "spRPTGetTotalCapacity"})
                    {
                        try
                        {
                            username = username.ToString().Replace("'", "''");
                            using (
                                var sqlCommand =
                                    new SqlCommand(query.Replace("@SP", sp).Replace("@Username", username.ToString()),
                                                   sqlConnection))
                            {
                                sqlCommand.CommandType = CommandType.Text;
                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                        catch (SqlException exception)
                        {
                            foreach (SqlError sqlError in exception.Errors)
                            {
                                LogError(string.Format("Msg {0}, Procedure {1}, Line {2}", sqlError.Number,
                                                       sqlError.Procedure, sqlError.LineNumber));
                                LogError(exception.Message);
                            }
                        }
                    }
                }
            }
        }

        private void LogError(string message)
        {
            var htmlGenericControl = new HtmlGenericControl("div") {InnerHtml = message};
            htmlGenericControl.Style.Add(HtmlTextWriterStyle.Color, "red");

            _messages.Add(htmlGenericControl);
        }

        private void LogMessage(string message)
        {
            _messages.Add(new HtmlGenericControl("div") {InnerHtml = message});
        }

        private void SqlConnectionInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            foreach (
                string message in e.Message.Split(new[] {"\r", "\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                LogMessage(message);
            }
        }

        private void UpgradeDatabase()
        {
            Guid siteId = SPContext.Current.Site.ID;

            using (var epmData = new EPMData(siteId))
            {
                SPSecurity.RunWithElevatedPrivileges(() => { ExecuteUpgradeScripts(epmData, siteId); });
            }
        }

        private void UpgradeListMappings()
        {
            Guid siteId = SPContext.Current.Site.ID;

            var reportData = new ReportData(siteId);

            DataTable listMappings = reportData.GetListMappings();

            foreach (var mappings in (from l in listMappings.AsEnumerable()
                                      select
                                          new
                                              {
                                                  ListName = l["ListName"],
                                                  ListId = l["RPTListId"],
                                                  SiteId = l["SiteId"],
                                                  Table = l["TableName"],
                                                  SnapshotTable = l["TableNameSnapshot"]
                                              })
                .GroupBy(l => l.SiteId))
            {
                using (var spSite = new SPSite((Guid) mappings.Key))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        foreach (var mapping in mappings)
                        {
                            var listName = (string) mapping.ListName;

                            try
                            {
                                SPList spList = spWeb.Lists[listName];
                                LogMessage("Upgrading mapping for: " + spList.Title);

                                if (spList.Fields.ContainsFieldWithInternalName("EXTID"))
                                {
                                    DataTable listColumns = reportData.GetListColumns(listName);

                                    DataRow dataRow = (from c in listColumns.AsEnumerable()
                                                       where c["InternalName"].Equals("EXTID")
                                                       select c).FirstOrDefault();

                                    if (dataRow == null)
                                    {
                                        var listId = (Guid) mapping.ListId;
                                        var columnDefs = new List<ColumnDef> {new ColumnDef(spList.Fields["EXTID"])};

                                        reportData.InsertListColumns(listId, columnDefs);
                                        reportData.AddColumns((string) mapping.Table, columnDefs);
                                        reportData.AddColumns((string) mapping.SnapshotTable, columnDefs);

                                        LogMessage("-- EXTID is mapped.");
                                    }
                                    else
                                    {
                                        LogMessage("-- EXTID is already mapped.");
                                    }
                                }
                                else
                                {
                                    LogMessage("-- This list does not have the EXTID field.");
                                }
                            }
                            catch (Exception ex)
                            {
                                LogError("Unable to process EXTID mapping for list: " + listName + ". Exception: " +
                                         ex.Message);
                            }
                        }
                    }
                }
            }
        }

		#endregion Methods 
    }
}