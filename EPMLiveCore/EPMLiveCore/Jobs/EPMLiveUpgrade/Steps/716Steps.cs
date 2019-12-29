using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V716, Order = 1.0, Description = "Add missing index on EPG_WE_ACTUALHOURS")]
    internal class AddIndex_EPGWEActualHours_IX_EPG_WE_ACTUALHOURS_WEH_CHG_UID : UpgradeStep
    {
        private SPWeb _spWeb;
        private const string CreateIndexScript = @"
if not exists(select * from sys.indexes where name = 'IX_EPG_WE_ACTUALHOURS_WEH_CHG_UID')
begin
	CREATE INDEX [IX_EPG_WE_ACTUALHOURS_WEH_CHG_UID] ON [dbo].[EPG_WE_ACTUALHOURS] ([WEH_CHG_UID]) INCLUDE ([WEH_DATE], [WEH_NORMALHOURS], [WEH_OVERTIMEHOURS])
end
";
        #region Constructors (1) 
        public AddIndex_EPGWEActualHours_IX_EPG_WE_ACTUALHOURS_WEH_CHG_UID(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

        #region Overrides of UpgradeStep

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
                connection.ExecuteNonQuery(CreateIndexScript);
                LogMessage("Index created.", MessageKind.SUCCESS, 1);
            }
        }
        #endregion
    }
}
