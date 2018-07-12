using System;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V640, Order = 1.0, Description = "Adding rate per project feature")]
    internal class ProjectResourceRateFirstInstall64 : UpgradeStep
    {
        private const string ProjectRatesTableName = "EPG_PROJECT_RATES";

        private const string ProjectRatesCreateTableQuery = @"CREATE TABLE dbo.EPG_PROJECT_RATES(
    ID int IDENTITY(1,1) NOT NULL,
    PROJECT_ID int NOT NULL,
    WRES_ID int NOT NULL,
    PR_EFFECTIVE_DATE datetime NULL,
    PR_RATE decimal(15, 6) NULL
)";

        private const string ProjectRatesCreateIndexQuery = @"CREATE NONCLUSTERED INDEX [IX_EPG_PROJECT_RATES_PROJECT_ID] ON [dbo].[EPG_PROJECT_RATES]
(
    [PROJECT_ID] ASC
)";

        private const string ProjectRatesGetMaintenanceRecordCountQuery = @"SELECT COUNT(*) FROM [EPGP_COST_VALUES_TOSET] WHERE [TOSET_MAINKEY] = 101";

        private const string ProjectRatesPopulateMaintenanceRecordsQuery = @"INSERT INTO [EPGP_COST_VALUES_TOSET](
    [TOSET_MAINKEY],[CB_ID],[CT_ID],[CV_TIMESTAMP])
    SELECT 101, CT_CB_ID, CT_ID, GETDATE() 
    FROM EPGP_COST_TYPES 
    WHERE CT_EDIT_MODE IN (9, 41)";

        public ProjectResourceRateFirstInstall64(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        public override bool Perform()
        {
            try
            {
                if (IsPfeSite)
                {
                    LogTitle(GetWebInfo(Web), 1);
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
                else
                {
                    LogMessage("This is not a PFE site.", MessageKind.SKIPPED, 2);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 1);
                return false;
            }

            return true;
        }

        private void UpgradePfeDatabase()
        {
            var connectionProvider = new PfeData.ConnectionProvider();
            LogMessage("Connecting to the database.", 2);
            using (var connection = connectionProvider.CreateConnection(Web))
            {
                var tableExists = connection.TableExist(ProjectRatesTableName);
                if (!tableExists)
                {
                    connection.ExecuteNonQuery(ProjectRatesCreateTableQuery);
                    connection.ExecuteNonQuery(ProjectRatesCreateIndexQuery);
                    LogMessage($"{ProjectRatesTableName} table created.", MessageKind.SUCCESS, 2);
                }
                else
                {
                    LogMessage($"{ProjectRatesTableName} table already exists.", MessageKind.SKIPPED, 2);
                }

                var recordCount = connection.ExecuteReader(ProjectRatesGetMaintenanceRecordCountQuery, reader => reader.Read() ? reader.GetInt32(0) : 0);
                if (recordCount == 0)
                {
                    connection.ExecuteNonQuery(ProjectRatesPopulateMaintenanceRecordsQuery);
                    LogMessage("Added configuration records.", MessageKind.SUCCESS, 2);
                }
                else
                {
                    LogMessage("Configuration records already exists.", MessageKind.SKIPPED, 2);
                }

                LogMessage("Rate per project feature ready to use.", MessageKind.SUCCESS, 1);
            }
        }
    }
}
