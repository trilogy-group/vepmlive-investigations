using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V718, Order = 1.0, Description = "Improve index on LSTMyWork")]
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

    [UpgradeStep(Version = EPMLiveVersion.V718, Order = 2.0, Description = "Add missing index on RPTColumn")]
    internal class AddIndex_RPTColumn_IX_RPTColumn_RPTListId : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private const string UpgradeScript = @"
if not exists(select * from sys.indexes where name = 'IX_RPTColumn_RPTListId')
begin
	CREATE INDEX [IX_RPTColumn_RPTListId] ON [dbo].[RPTColumn] ([RPTListId], [ColumnName]) INCLUDE ([SharePointType])
end";

        #region Constructors (1) 
        public AddIndex_RPTColumn_IX_RPTColumn_RPTListId(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

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

                        LogMessage("Index IX_RPTColumn_RPTListId has been created on RPTColumn.", MessageKind.SUCCESS, 4);
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

    [UpgradeStep(Version = EPMLiveVersion.V718, Order = 3.0, Description = "Add missing index on EPGP_COST_CATEGORIES")]
    internal class AddIndex_EPGPCostCategories_IX_EPGP_COST_CATEGORIES_BC_ID : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private readonly string CreateIndexScript = @"
if not exists(select * from sys.indexes where object_id = OBJECT_ID('dbo.EPGP_COST_CATEGORIES') and name = 'IX_EPGP_COST_CATEGORIES_BC_ID')
begin
	CREATE INDEX [IX_EPGP_COST_CATEGORIES_BC_ID] ON [dbo].[EPGP_COST_CATEGORIES] ([BC_ID])
end
";
        public AddIndex_EPGPCostCategories_IX_EPGP_COST_CATEGORIES_BC_ID(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);
                if (IsPfeSite)
                {
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.ToString(), MessageKind.FAILURE, 1);
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
                connection.ExecuteNonQuery(CreateIndexScript);
                LogMessage("Index IX_EPGP_COST_CATEGORIES_BC_ID ON EPGP_COST_CATEGORIES has been successfully created.", MessageKind.SUCCESS, 1);
            }
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V718, Order = 4.0, Description = "Add missing index on EPG_RESOURCEPLANS_HOURS")]
    internal class AddIndex_EPGResourcePlansHours_IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING : UpgradeStep
    {
        private readonly SPWeb _spWeb;
        private readonly string CreateIndexScript = @"
if not exists(select * from sys.indexes where [object_id] = OBJECT_ID('dbo.EPG_RESOURCEPLANS_HOURS') AND name = 'IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING')
begin
	CREATE NONCLUSTERED INDEX [IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING] ON [dbo].[EPG_RESOURCEPLANS_HOURS]	
    (	
	    [CMT_UID] ASC,
	    [PRD_ID] ASC,
	    [CMH_PENDING] ASC
    )	
    INCLUDE ([CMH_HOURS], [CMH_REVENUES],[CMH_FTES],[CMH_MODE],[CMH_ENTEREDBY])	
end
";
        public AddIndex_EPGResourcePlansHours_IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        public override bool Perform()
        {
            try
            {
                LogTitle(GetWebInfo(Web), 1);
                if (IsPfeSite)
                {
                    SPSecurity.RunWithElevatedPrivileges(UpgradePfeDatabase);
                }
            }
            catch (Exception e)
            {
                LogMessage(e.ToString(), MessageKind.FAILURE, 1);
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
                connection.ExecuteNonQuery(CreateIndexScript);
                LogMessage("Index IX_EPG_RESOURCEPLANS_HOURS_CMT_UID_PRD_ID_CMH_PENDING ON EPG_RESOURCEPLANS_HOURS has been successfully created.", MessageKind.SUCCESS, 1);
            }
        }
    }
}
