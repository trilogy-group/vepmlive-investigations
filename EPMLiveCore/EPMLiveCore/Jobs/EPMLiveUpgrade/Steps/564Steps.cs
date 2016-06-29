using System;
using System.Data;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V564, Order = 1.0, Description = "Updating Timesheets table")]
    internal class UpdateTsitemTable : UpgradeStep
    {
        #region Constructors (1) 

        public UpdateTsitemTable(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string connectionString = CoreFunctions.getConnectionString(webAppId);

                    if (!CheckColumn(connectionString))
                    {
                        AddColumn(connectionString);
                        LogMessage("ASSIGNEDTOID column added", MessageKind.SUCCESS, 4);
                    }
                    else
                    {
                        LogMessage("ASSIGNEDTOID column already exists", MessageKind.SKIPPED, 4);
                    }

                    PopulateColumn(connectionString,
                        CoreFunctions.getReportingConnectionString(webAppId, Web.Site.ID));
                    LogMessage("ASSIGNEDTOID column populated", MessageKind.SUCCESS, 4);
                }
                catch (Exception exception)
                {
                    string message = exception.InnerException != null
                        ? exception.InnerException.Message
                        : exception.Message;

                    LogMessage(message, MessageKind.FAILURE, 4);
                }
            });

            return true;
        }

        private void AddColumn(string connectionString)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                try
                {
                    using (
                        var sqlCommand = new SqlCommand("ALTER TABLE TSITEM ADD ASSIGNEDTOID int NULL", sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void PopulateColumn(string epmLiveCn, string reportingCn)
        {
            var dtLstMyWork = new DataTable();
            var dtToUpdate = new DataTable();

            using (
                var sqlDataAdapter =
                    new SqlDataAdapter(
                        "SELECT title,SiteId,WebId,ListId,ItemId,ProjectID,ProjectText,AssignedToText FROM dbo.LSTMyWork group by title,SiteId,WebId,ListId,ItemId,ProjectID,ProjectText,AssignedToText",
                        reportingCn))
            {
                sqlDataAdapter.Fill(dtLstMyWork);
            }

            using (
                var sqlDataAdapter =
                    new SqlDataAdapter(
                        "Select tsi.WEB_UID, tsi.LIST_UID, tsi.ITEM_ID, tsi.PROJECT_ID, ts.TS_UID,tu.TSUSERUID,tu.USER_ID,ts.RESOURCENAME from TSITEM tsi inner join TSTIMESHEET ts on ts.TS_UID = tsi.TS_UID inner join TSUSER tu on tu.TSUSERUID = ts.TSUSER_UID",
                        epmLiveCn))
            {
                sqlDataAdapter.Fill(dtToUpdate);
            }

            try
            {
                using (var sqlConnection = new SqlConnection(epmLiveCn))
                {
                    try
                    {
                        sqlConnection.Open();

                        foreach (DataRow dataRow in dtToUpdate.Rows)
                        {
                            DataRow[] drs;
                            if (Convert.ToString(dataRow["project_id"]) != "")
                            {
                                drs =
                                    dtLstMyWork.Select(
                                        string.Format("WebId='{0}' and ListId='{1}' and ItemId={2} and ProjectID={3}",
                                            dataRow["web_uid"], dataRow["list_uid"], dataRow["item_id"],
                                            dataRow["project_id"]));
                            }
                            else
                            {
                                drs =
                                    dtLstMyWork.Select(string.Format("WebId='{0}' and ListId='{1}' and ItemId={2}",
                                        dataRow["web_uid"], dataRow["list_uid"], dataRow["item_id"]));
                            }

                            if (drs.Length <= 0) continue;

                            string resourceName = Convert.ToString(dataRow["resourcename"]);
                            string assignedToText = Convert.ToString(drs[0]["AssignedToText"]);

                            using (
                                var sqlCommand =
                                    new SqlCommand(
                                        "update tsitem set assignedtoid = @assignedtoid where web_uid = @web_uid and list_uid = @list_uid and item_id = @item_id and project_id = @project_id and assignedtoid is null",
                                        sqlConnection))
                            {
                                sqlCommand.CommandType = CommandType.Text;
                                sqlCommand.Parameters.AddWithValue("@assignedtoid",
                                    assignedToText.Contains(resourceName) ? dataRow["user_id"] : DBNull.Value);
                                sqlCommand.Parameters.AddWithValue("@web_uid", dataRow["web_uid"]);
                                sqlCommand.Parameters.AddWithValue("@list_uid", dataRow["list_uid"]);
                                sqlCommand.Parameters.AddWithValue("@item_id", dataRow["item_id"]);
                                sqlCommand.Parameters.AddWithValue("@project_id", dataRow["project_id"]);

                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool CheckColumn(string connectionString)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    const string SQL = @"
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'ASSIGNEDTOID' AND [object_id] = OBJECT_ID(N'TSITEM'))
                        BEGIN
                            SELECT 1
                        END
                        ELSE SELECT 0";

                    using (var sqlCommand = new SqlCommand(SQL, sqlConnection))
                    {
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            return reader.GetInt32(0) != 1;
                        }
                    }
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            return false;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V564, Order = 2.0, Description = "Configure Logging")]
    internal class AddLogging : UpgradeStep
    {
        #region Constructors (1) 

        public AddLogging(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                string connectionString = CoreFunctions.getConnectionString(Web.Site.WebApplication.Id);

                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    const string SQL = @"
                        if not exists (select table_name from INFORMATION_SCHEMA.tables where table_name = 'Logs')
	                    begin
		                    CREATE TABLE [dbo].[Logs](
			                    [Id] [uniqueidentifier] NOT NULL,
			                    [Component] [nvarchar](255) NOT NULL,
			                    [Message] [nvarchar](max) NOT NULL,
			                    [StackTrace] [nvarchar](max) NULL,
                                [Details] [nvarchar](max) NULL,
			                    [Kind] [tinyint] NOT NULL,
			                    [WebId] [uniqueidentifier] NULL,
			                    [UserId] [int] NULL,
			                    [DateTime] [datetime2](7) NOT NULL,
		                     CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
		                    (
			                    [Id] ASC
		                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

		                    ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_Id]  DEFAULT (newid()) FOR [Id]
		                    ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_DateTime]  DEFAULT (getdate()) FOR [DateTime]

                            SELECT 1
                        end
                        else SELECT 0";

                    using (var sqlCommand = new SqlCommand(SQL, sqlConnection))
                    {
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == 1)
                            {
                                LogMessage("Logging configured", MessageKind.SUCCESS, 2);
                            }
                            else
                            {
                                LogMessage("Logging is already configured", MessageKind.SKIPPED, 2);
                            }

                            break;
                        }
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception exception)
            {
                LogMessage(exception.Message, MessageKind.FAILURE, 2);
            }

            return true;
        }

        #endregion
    }
}