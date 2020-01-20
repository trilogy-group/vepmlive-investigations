using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V716, Order = 1.0, Description = "Improve index on LSTMyWork")]
    internal class AlterLSTMyWorkIndex : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private const string UpgradeScript = @"
IF EXISTS (SELECT * FROM sys.indexes WHERE [object_id] = OBJECT_ID('dbo.LSTMyWork') AND [name] = 'IX_LSTMyWork_ListId_ItemID') 
BEGIN
    DROP INDEX [IX_LSTMyWork_ListId_ItemID] ON [dbo].[LSTMyWork];
END;
IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='IX_LSTMyWork_ListId_ItemID_AssignedToID' AND object_id = OBJECT_ID('dbo.LSTMyWork'))
BEGIN
	CREATE INDEX [IX_LSTMyWork_ListId_ItemID_AssignedToID] ON [dbo].[LSTMyWork] ([ListId], [ItemId], [AssignedToID]) WITH (FILLFACTOR=80);
END";

        #region Constructors (1) 
        public AlterLSTMyWorkIndex(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    LogMessage("Connecting to the database . . .", 2);
                    Guid webAppId = Web.Site.WebApplication.Id;
                    Guid siteId = Web.Site.ID;
                    string rptCnStr = CoreFunctions.getReportingConnectionString(webAppId, siteId);
                    using (var rptCn = new SqlConnection(rptCnStr))
                    {
                        rptCn.Open();

                        #region Index Code

                        rptCn.ExecuteNonQuery(UpgradeScript);

                        #endregion

                        LogMessage("Index IX_LSTMyWork_ListId_ItemID_AssignedToID has been created on LSTMyWork.", MessageKind.SUCCESS, 4);
                    }
                });
            }
            catch (Exception exception)
            {
                var message = exception.InnerException != null
                    ? exception.InnerException.Message
                    : exception.Message;

                LogMessage(message + exception, MessageKind.FAILURE, 4);
                return false;
            }
            return true;
        }

        #endregion
    }
}
