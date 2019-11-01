using System;
using System.Data.SqlClient;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V713, Order = 0.1, Description = "Update SSRS Resouces Capacity Heat Map Report")]
    internal class Update_EPG_SP_ReadCBAttribs : UpgradeStep
    {
        private SPWeb _spWeb;
        private const string EPG_SP_ReadCBAttribs_UpdateQuery = @"ALTER PROCEDURE dbo.EPG_SP_ReadCBAttribs
/*
   Changes Log:
		2019/10/16: Distinct. Upgrade step marker: v7.1.3
*/
   @CBID INT,
   @CodeID INT
AS
IF (@CodeID  < 0)
 BEGIN
SELECT distinct BA_CODE_UID,BA_BC_UID,BA_RATETYPE_UID,BA_PRD_ID,BA_FTE_CONV,BA_RATE
  FROM EPGP_COST_BREAKDOWN_ATTRIBS
  WHERE CB_ID = @CBID
 ORDER BY BA_CODE_UID,BA_RATETYPE_UID,BA_BC_UID,BA_PRD_ID
 END
ELSE
 BEGIN
SELECT distinct BA_BC_UID,BA_RATETYPE_UID,BA_PRD_ID,BA_FTE_CONV,BA_RATE
  FROM EPGP_COST_BREAKDOWN_ATTRIBS
  WHERE CB_ID = @CBID And BA_CODE_UID = @CodeID
 ORDER BY BA_RATETYPE_UID,BA_BC_UID,BA_PRD_ID
END
";
        #region Constructors (1) 
        public Update_EPG_SP_ReadCBAttribs(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { _spWeb = spWeb; }

        #endregion Constructors 

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

        /// <summary>
        /// Upgrades the pfe database:
        ///  * Create column for projects table - column will be used as source for calculations in PFE instead of sharepoint list
        ///  * Create discount columns in detail values table - will help us on server side recalculations when discount rate is changed, so we will not have to find original rate
        ///  * Update stored procedure used to get cost detail values from VB6 code
        ///  * Populate configuration details table with missing data (partially data already populated by 6.4.0.1 step)
        /// </summary>
        private void UpgradePfeDatabase()
        {
            var connectionProvider = new PfeData.ConnectionProvider();
            LogMessage("Connecting to the database.", 2);
            using (var connection = connectionProvider.CreateConnection(Web))
            {
                UpdateStoredProcedure(connection, "EPG_SP_ReadCBAttribs", EPG_SP_ReadCBAttribs_UpdateQuery);

                
                LogMessage("EPG_SP_ReadCBAttribs updated.", MessageKind.SUCCESS, 1);
            }
        }
        private void UpdateStoredProcedure(SqlConnection connection, string name, string updateQuery)
        {
            var definition = connection.GetSpDefinition(name);
            if (definition != null && !definition.Contains("7.1.3"))
            {
                connection.ExecuteNonQuery(updateQuery);
                LogMessage($"{name} procedure updated.", MessageKind.SUCCESS, 2);
            }
            else
            {
                LogMessage($"{name} already have been updated.", MessageKind.SKIPPED, 2);
            }
        }


        #endregion
    }


}
