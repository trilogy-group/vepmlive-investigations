using System;
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
            bool success = false;
            Guid webAppId = Web.Site.WebApplication.Id;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string connectionString = CoreFunctions.getConnectionString(webAppId);

                    using (var sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();

                        if (!CheckColumn(sqlConnection))
                        {
                            AddColumn(sqlConnection);
                            LogMessage("ASSIGNEDTOID column added", MessageKind.SUCCESS, 2);

                            PopulateColumn(sqlConnection,
                                CoreFunctions.getReportingConnectionString(webAppId, Web.Site.ID));
                            LogMessage("ASSIGNEDTOID column populated", MessageKind.SUCCESS, 2);
                        }
                        else
                        {
                            LogMessage("ASSIGNEDTOID column already exists", MessageKind.SKIPPED, 2);
                        }

                        sqlConnection.Close();
                    }
                }
                catch (Exception exception)
                {
                    string message = exception.InnerException != null
                        ? exception.InnerException.Message
                        : exception.Message;

                    LogMessage(message, MessageKind.FAILURE, 4);
                    success = false;
                }
            });

            return success;
        }

        private void AddColumn(SqlConnection sqlConnection)
        {
            using (var sqlCommand = new SqlCommand("ALTER TABLE TSITEM ADD ASSIGNEDTOID int NULL", sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }

        private void PopulateColumn(SqlConnection epmLiveConnection, string reportingCn)
        {
            using (var reportingConnection = new SqlConnection(reportingCn))
            {
                reportingConnection.Open();

                // Put logic to transfer AssignedTo ID from reporting to epmlive TSITEMS here ...

                reportingConnection.Close();
            }
        }

        private bool CheckColumn(SqlConnection sqlConnection)
        {
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
                    end";

                    using (var sqlCommand = new SqlCommand(SQL, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }

                    sqlConnection.Close();
                }

                LogMessage("Logging configured", MessageKind.SUCCESS, 2);
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