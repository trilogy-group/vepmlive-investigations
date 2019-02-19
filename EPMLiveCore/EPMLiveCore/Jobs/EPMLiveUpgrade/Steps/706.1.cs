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
    [UpgradeStep(Version = EPMLiveVersion.V706, Order = 1, Description = "Add unique Contraints on RPTWEBGROUPS ")]
    internal class AddRPTWEBGROUPSUniqueContraints : UpgradeStep
    {
        private const string ContraintName = "UQ_RPTWEBGROUPS_SITEID_WEBID_GROUPID";
        public AddRPTWEBGROUPSUniqueContraints(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);
                    string connectionString = CoreFunctions.getReportingConnectionString(Web.Site.WebApplication.Id, Web.Site.ID);
                    AddConstraint(connectionString);
                    LogMessage("Constraint updated in the Database..", 2);
                }
                catch (Exception exception)
                {
                    LogMessage(exception.ToString(), MessageKind.FAILURE, 4);
                }
            });
            return true;
        }

        private void AddConstraint(string connectionString)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(string.Format(@"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS   WHERE CONSTRAINT_NAME='{0}'))
                                                                BEGIN
                                                                       WITH CTE
                                                                            AS (SELECT ROW_NUMBER() OVER (PARTITION BY SITEID,WEBID,GROUPID
                                                                                                              ORDER BY (SELECT 0)) RN
                                                                                FROM   [dbo].[RPTWEBGROUPS])
                                                                       DELETE FROM CTE
                                                                       WHERE  RN > 1;
                                                                       ALTER TABLE [dbo].[RPTWEBGROUPS] ADD  CONSTRAINT {0} UNIQUE (SITEID,WEBID,GROUPID)
                                                                END", ContraintName), con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
