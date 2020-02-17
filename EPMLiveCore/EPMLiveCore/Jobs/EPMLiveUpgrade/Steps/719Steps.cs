using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V719, Order = 1.0, Description = "Add missing index on EPG_RESOURCEPLANS_HOURS")]
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
