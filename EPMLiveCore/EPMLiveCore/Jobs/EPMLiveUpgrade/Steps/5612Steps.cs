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
    [UpgradeStep(Version = EPMLiveVersion.V5612, Order = 1.0, Description = "Update TSRESMETA table (Username column) from 50 to 255 characters wide")]
    internal class UpdateTSRESMETAtableUsernameColumn : UpgradeStep
    {
        public UpdateTSRESMETAtableUsernameColumn(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        public override bool Perform()
        {
            LogMessage("Updating TSRESMETA table (Username column) from 50 to 255 characters wide", 2);
            try
            {
                string epmliveConnection = string.Empty;
                string errMsg = "Cannot get EPMLive database information.";
                epmliveConnection = CoreFunctions.getConnectionString(Web.Site.WebApplication.Id);
                if (!string.IsNullOrEmpty(epmliveConnection))
                {
                    using (SqlConnection conn = new SqlConnection(epmliveConnection))
                    {
                        Microsoft.SharePoint.SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            conn.Open();
                        });
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            StringBuilder sbUpdateLength = new StringBuilder();
                            sbUpdateLength.AppendLine("ALTER TABLE TSRESMETA");
                            sbUpdateLength.AppendLine("ALTER COLUMN Username varchar(255)");
                            cmd.CommandText = sbUpdateLength.ToString();
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                            LogMessage("Updated TSRESMETA table (Username column) from 50 to 255 characters wide", MessageKind.SUCCESS, 4);
                        }
                    }
                }
                else
                {
                    LogMessage(errMsg, MessageKind.FAILURE, 4);
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, MessageKind.FAILURE, 4);
            }
            return true;
        }
    }
}
