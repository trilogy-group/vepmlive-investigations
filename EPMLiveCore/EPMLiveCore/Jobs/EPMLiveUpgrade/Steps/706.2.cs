using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{   
    [UpgradeStep(Version = EPMLiveVersion.V706, Order = 2, Description = "Add indexes to PPM DB")]
    internal class AddPPMIndexes : UpgradeStep
    {
        public AddPPMIndexes(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }
        
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
                string sqlPFEIndicesUpgrade = @"IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPGP_DETAIL_VALUES_CB_ID_CT_ID_PROJECT_ID' AND object_id = OBJECT_ID('dbo.EPGP_DETAIL_VALUES'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPGP_DETAIL_VALUES_CB_ID_CT_ID_PROJECT_ID]
ON [dbo].[EPGP_DETAIL_VALUES] ([CB_ID],[CT_ID],[PROJECT_ID])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPG_WE_CHARGES_PROJECT_ID' AND object_id = OBJECT_ID('dbo.EPG_WE_CHARGES'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPG_WE_CHARGES_PROJECT_ID]
ON [dbo].[EPG_WE_CHARGES] ([PROJECT_ID])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPG_WE_CHARGES_WRES_ID' AND object_id = OBJECT_ID('dbo.EPG_WE_CHARGES'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPG_WE_CHARGES_WRES_ID]
ON [dbo].[EPG_WE_CHARGES] ([WRES_ID])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPGP_COST_VALUES_CB_ID_CT_ID_PROJECT_ID' AND object_id = OBJECT_ID('dbo.EPGP_COST_VALUES'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPGP_COST_VALUES_CB_ID_CT_ID_PROJECT_ID]
ON [dbo].[EPGP_COST_VALUES] ([CB_ID],[CT_ID],[PROJECT_ID])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_COST_BREAKDOWN_ATTRIBS_CB_ID_BA_RATETYPE_UID_BA_CODE_UID' AND object_id = OBJECT_ID('dbo.EPGP_COST_BREAKDOWN_ATTRIBS'))
BEGIN
CREATE NONCLUSTERED INDEX [I_COST_BREAKDOWN_ATTRIBS_CB_ID_BA_RATETYPE_UID_BA_CODE_UID]
ON [dbo].[EPGP_COST_BREAKDOWN_ATTRIBS] ([CB_ID],[BA_RATETYPE_UID],[BA_CODE_UID])
INCLUDE ([BA_BC_UID],[BA_PRD_ID],[BA_FTE_CONV])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_COST_BREAKDOWN_ATTRIBS_BA_FTE_CONV_BA_RATE' AND object_id = OBJECT_ID('dbo.EPGP_COST_BREAKDOWN_ATTRIBS'))
BEGIN
CREATE NONCLUSTERED INDEX [I_COST_BREAKDOWN_ATTRIBS_BA_FTE_CONV_BA_RATE]
ON [dbo].[EPGP_COST_BREAKDOWN_ATTRIBS] ([BA_FTE_CONV],[BA_RATE])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPG_RESOURCEPLANS_HOURS_CMH_PENDING' AND object_id = OBJECT_ID('dbo.EPG_RESOURCEPLANS_HOURS'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPG_RESOURCEPLANS_HOURS_CMH_PENDING]
ON [dbo].[EPG_RESOURCEPLANS_HOURS] ([CMH_PENDING])
INCLUDE ([CMT_UID],[PRD_ID],[CMH_HOURS],[CMH_REVENUES])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPGP_COST_DETAILS_CB_ID_CT_ID_PROJECT_ID' AND object_id = OBJECT_ID('dbo.EPGP_COST_DETAILS'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPGP_COST_DETAILS_CB_ID_CT_ID_PROJECT_ID]
ON [dbo].[EPGP_COST_DETAILS] ([CB_ID], [CT_ID], [PROJECT_ID])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPGP_AVAIL_CATEGORIES_CT_ID' AND object_id = OBJECT_ID('dbo.EPGP_AVAIL_CATEGORIES'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPGP_AVAIL_CATEGORIES_CT_ID]
ON [dbo].[EPGP_AVAIL_CATEGORIES] ([CT_ID])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPGP_LOOKUP_VALUES_LOOKUP_UID' AND object_id = OBJECT_ID('dbo.EPGP_LOOKUP_VALUES'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPGP_LOOKUP_VALUES_LOOKUP_UID]
ON [dbo].[EPGP_LOOKUP_VALUES] ([LOOKUP_UID])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPG_PERIODS_CB_ID_PRD_ID' AND object_id = OBJECT_ID('dbo.EPG_PERIODS'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPG_PERIODS_CB_ID_PRD_ID]
ON [dbo].[EPG_PERIODS] ([CB_ID], [PRD_ID])
END

IF NOT EXISTS (SELECT *  FROM sys.indexes  WHERE name='I_EPGP_PI_WORK2_PROJECT_ID_WRES_ID' AND object_id = OBJECT_ID('dbo.EPGP_PI_WORK2'))
BEGIN
CREATE NONCLUSTERED INDEX [I_EPGP_PI_WORK2_PROJECT_ID_WRES_ID]
ON [dbo].[EPGP_PI_WORK2] ([PROJECT_ID],[WRES_ID])
INCLUDE ([PW_MAJORCATEGORY],[PW_DATE],[PW_WORK])
END
";
                connection.ExecuteNonQuery(sqlPFEIndicesUpgrade);
                LogMessage("PPM indices were updated successfully.", MessageKind.SUCCESS, 2);
            }
        }
    }
}
