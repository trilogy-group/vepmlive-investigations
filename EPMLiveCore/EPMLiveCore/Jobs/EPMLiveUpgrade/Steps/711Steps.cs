using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V711, Order = 1.0, Description = "Update SSRS Resouces Capacity Heat Map Report")]
    internal class UpdateSSRSResoucesCapacityHeatMapReport : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public UpdateSSRSResoucesCapacityHeatMapReport(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Getting the report library.", 2);
                    SPList reportLibrary = _spWeb.Lists.TryGetList("Report Library");

                    if (reportLibrary != null)
                    {
                        LogMessage("Getting the Resource Capacity Heat Map report.", 2);

                        System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                        var spfile = _spWeb.GetFile(_spWeb.Url + "/Report Library/epmlivetl/Resources/Capacity Planning/Resource Capacity Heat Map.rdl");

                        if (spfile.Exists)
                        {
                            LogMessage("Updating the Resource Capacity Heat Map report.", 2);

                            byte[] byteArrayFileContentsBefore = spfile.OpenBinary();

                            if (byteArrayFileContentsBefore.Length > 0)
                            {
                                string strReportContentsBefore = enc.GetString(byteArrayFileContentsBefore);

                                string strReportContentsAfter = strReportContentsBefore.Replace("union", "union all");

                                byte[] byteArrayFileContentsAfter = null;
                                if (!strReportContentsAfter.Equals(string.Empty))
                                {
                                    _spWeb.AllowUnsafeUpdates = true;
                                    byteArrayFileContentsAfter = enc.GetBytes(strReportContentsAfter);
                                    spfile.SaveBinary(byteArrayFileContentsAfter); //save to the file.
                                    LogMessage("Resource Capacity Heat Map report updated succesfully", 2);
                                }
                                else
                                {
                                    LogMessage("Resource Capacity Heat Map report is empty", MessageKind.FAILURE, 4);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
                finally
                {
                    _spWeb.AllowUnsafeUpdates = false;
                }
            });
            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V711, Order = 2.0, Description = "Update SSRS Resouces Availability Report")]
    internal class UpdateSSRSResoucesAvailabilityReport : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public UpdateSSRSResoucesAvailabilityReport(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Getting the report library.", 2);
                    SPList reportLibrary = _spWeb.Lists.TryGetList("Report Library");

                    if (reportLibrary != null)
                    {
                        LogMessage("Getting the Resource Availability report.", 2);
                        System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                        var spfile = _spWeb.GetFile(_spWeb.Url + "/Report Library/epmlivetl/Resources/Capacity Planning/Resource Available vs. Planned by Dept.rdl");

                        if (spfile.Exists)
                        {
                            LogMessage("Updating the Availability report.", 2);

                            byte[] byteArrayFileContentsBefore = spfile.OpenBinary();

                            if (byteArrayFileContentsBefore.Length > 0)
                            {
                                string strReportContentsBefore = enc.GetString(byteArrayFileContentsBefore);

                                string strReportContentsAfter = strReportContentsBefore.Replace("union", "union all");

                                byte[] byteArrayFileContentsAfter = null;
                                if (!strReportContentsAfter.Equals(string.Empty))
                                {
                                    _spWeb.AllowUnsafeUpdates = true;
                                    byteArrayFileContentsAfter = enc.GetBytes(strReportContentsAfter);
                                    spfile.SaveBinary(byteArrayFileContentsAfter); //save to the file.
                                    LogMessage("Resource Capacity Heat Map report updated succesfully", 2);
                                }
                                else
                                {
                                    LogMessage("Resource Availability report is empty", MessageKind.FAILURE, 4);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
                finally
                {
                    _spWeb.AllowUnsafeUpdates = false;
                }
            });
            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V711, Order = 3.0, Description = "Add faster index to LSTMyWork")]
    internal class AddLSTMyWorkIndex : UpgradeStep
    {
        private SPWeb _spWeb;

        #region Constructors (1) 
        public AddLSTMyWorkIndex(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);
                    Guid webAppId = Web.Site.WebApplication.Id;
                    Guid SiteId = Web.Site.ID;
                    string rptCnStr = CoreFunctions.getReportingConnectionString(webAppId, SiteId);
                    using (var rptCn = new SqlConnection(rptCnStr))
                    {
                        rptCn.Open();

                        #region Index Code

                        rptCn.ExecuteNonQuery($@"
                            IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='IX_LSTMyWork_ListId_ItemID' AND object_id = OBJECT_ID('dbo.LSTMyWork'))
                            BEGIN
	                            CREATE INDEX IX_LSTMyWork_ListId_ItemID ON [dbo].[LSTMyWork]
	                            (
		                            ListId ASC, 
		                            ItemId ASC
	                            ) WITH (FILLFACTOR=80)
                            END													  
                                ");

                        #endregion

                        LogMessage("Index IX_LSTMyWork_ListId_ItemID has been created on LSTMyWork.", MessageKind.SUCCESS, 4);

                    }
                });


            }
            catch (Exception exception)
            {
                string message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message, MessageKind.FAILURE, 4);
                return false;
            }
            return true;
        }
        
        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V711, Order = 4.0, Description = "Invalid Data Clean Up for My Work")]
    internal class InvalidDataCleanUpMyWork : UpgradeStep
    {
        private const string SelectCommandText = "SELECT DISTINCT RPL.RPTLISTID,RPL.TABLENAME FROM RPTLIST RPL INNER JOIN LSTMYWORK MY ON MY.LISTID=RPL.RPTLISTID";
        public InvalidDataCleanUpMyWork(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        public override bool Perform()
        {
            var webAppId = Web.Site.WebApplication.Id;
            var ListIdTableNameCollection = new Dictionary<string, string>();
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);
                    string connectionString = CoreFunctions.getReportingConnectionString(Web.Site.WebApplication.Id, Web.Site.ID);
                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new InvalidOperationException("Connection string is not initialized ...");
                    }
                    using (var sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        using (var sqlCommand = new SqlCommand(SelectCommandText, sqlConnection))
                        {
                            using (var sqlDatareader = sqlCommand.ExecuteReader())
                            {
                                while (sqlDatareader.Read())
                                {
                                    ListIdTableNameCollection.Add(Convert.ToString(sqlDatareader[0]), Convert.ToString(sqlDatareader[1]));
                                }
                            }
                        }
                    }
                    if (ListIdTableNameCollection.Count > 0)
                    {
                        foreach (var item in ListIdTableNameCollection)
                        {
                            DeleteMyWorkData(item.Key, item.Value, connectionString);
                        }
                    }
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
            });
            return true;
        }

        private void DeleteMyWorkData(string rptListId, string tableName, string connectionString)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(string.Format(@"DELETE FROM LSTMYWORK WHERE ListId='{0}' and ItemID not in (Select ItemID from [{1}])", rptListId, tableName), con))
                    {
                        var rowsaffected = cmd.ExecuteNonQuery();
                        if (rowsaffected > 0)
                        {
                            LogMessage($"Cleaned up invalid data for table: [{tableName}] with {rowsaffected} row(s).", 2);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
            }
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V711, Order = 5.0, Description = "Updating timesheet administrator label.")]
    internal class UpdateTimesheetLabel : UpgradeStep
    {
        private readonly SPWeb _spWeb = null;
        private readonly string NewTitle = "To view all the timesheets, you should add yourself into the timesheet manager field explicitly for all the desired resources.";
        public UpdateTimesheetLabel(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
            if (spWeb == null)
            {
                throw new ArgumentNullException(nameof(spWeb));
            }

            _spWeb = spWeb;
        }

        public override bool Perform()
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    SPList list = _spWeb.Lists["Resources"];

                    var field = list.Fields.GetFieldByInternalName("TimesheetAdministrator");

                    if (!field.Description.Contains(NewTitle))
                    {
                        field.Description += "\r\n" + NewTitle;
                        field.Update();

                        LogMessage("Timesheet field description updated.", 2);
                    }
                    else
                    {
                        LogMessage("Timesheet field description is up-to-date.", 2);
                    }
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
            });
            return true;
        }
    }
}
