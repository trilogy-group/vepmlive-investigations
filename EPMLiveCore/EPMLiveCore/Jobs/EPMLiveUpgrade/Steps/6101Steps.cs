using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V610, Order = 2.0,
        Description = "New columns LastSubmittedByName and LastSubmittedByUser added to Timesheets table")]
    internal class NewLastSubmitedColumns : UpgradeStep
    {
        public NewLastSubmitedColumns(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;

            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);

                    string epmLiveCnStr = CoreFunctions.getConnectionString(webAppId);
                    using (var epmLiveCn = new SqlConnection(epmLiveCnStr))
                    {
                        epmLiveCn.Open();

                        // add LastSubmittedByName column
                        if (!epmLiveCn.ColumnExist("dbo.TSTIMESHEET", "LastSubmittedByName"))
                        {
                            epmLiveCn.AddColumn("dbo.TSTIMESHEET", "LastSubmittedByName [varchar](255) NULL");
                            LogMessage("LastSubmittedByName column added to TSTIMESHEET table", MessageKind.SUCCESS, 4);
                        }
                        else
                        {
                            LogMessage("LastSubmittedByName column already exists in TSTIMESHEET table", MessageKind.SKIPPED, 4);
                        }

                        // add LastSubmittedByUser column
                        if (!epmLiveCn.ColumnExist("dbo.TSTIMESHEET", "LastSubmittedByUser"))
                        {
                            epmLiveCn.AddColumn("dbo.TSTIMESHEET", "LastSubmittedByUser [varchar](255) NULL");
                            LogMessage("LastSubmittedByUser column added to TSTIMESHEET table", MessageKind.SUCCESS, 4);
                        }
                        else
                        {
                            LogMessage("LastSubmittedByUser column already exists in TSTIMESHEET table", MessageKind.SKIPPED, 4);
                        }
                    }
                });

                return true;
            }
            catch (Exception exception)
            {
                string message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message, MessageKind.FAILURE, 4);
                return false;
            }
        }
    }
}