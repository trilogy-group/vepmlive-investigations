using EPMLiveCore.API.SPAdmin;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Infrastructure;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V5611, Order = 1.0, Description = "Remove Unused Integrations")]
    internal class RemoveUnsedIntegrations : UpgradeStep
    {
        public RemoveUnsedIntegrations(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
        }

        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database.", 2);
                    var connectionString = CoreFunctions.getConnectionString(webAppId);

                    using (var sqlConnection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            sqlConnection.Open();
                            const string moduleId = "B0950B9B-3525-40B8-A456-6403156DC003";

                            using (var cmd = new SqlCommand("select * FROM INT_MODULES intm LEFT JOIN  dbo.INT_LISTS intl on intl.MODULE_ID = intm.MODULE_ID WHERE intl.INT_LIST_ID is null AND intm.MODULE_ID <> @module_Id",sqlConnection))
                            {
                                cmd.Parameters.AddWithValue("@module_Id", moduleId);

                                using (var dr = cmd.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        dr.Close();
                                        //Delete ALL unused Integrations other than TFS for the customer
                                        using (
                                            var cmd1 =
                                                new SqlCommand(
                                                    "DELETE intm FROM INT_MODULES intm LEFT JOIN  dbo.INT_LISTS intl on intl.MODULE_ID = intm.MODULE_ID WHERE intl.INT_LIST_ID is null AND intm.MODULE_ID <> @module_Id;DELETE FROM INT_CATEGORY where INT_CAT_ID <> '7B2EE2FD-9A59-4CCA-B3AD-1E8A3017DC60'",
                                                    sqlConnection))
                                        {
                                            cmd1.Parameters.AddWithValue("@module_Id", moduleId);
                                            cmd1.ExecuteNonQuery();
                                            LogMessage(
                                                "Unused Integrations removed successfully.",
                                                MessageKind.SUCCESS, 4);
                                        }
                                    }
                                    else
                                    {
                                        LogMessage("Integrations checked", MessageKind.SKIPPED, 4);
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            string message = e.InnerException != null
                                ? e.InnerException.Message
                                : e.Message;

                            LogMessage(message, MessageKind.FAILURE, 4);
                        }
                        finally
                        {
                            sqlConnection.Close();
                        }
                    }
                }
                catch (Exception exception)
                {
                    string message = exception.InnerException != null
                        ? exception.InnerException.Message
                        : exception.Message;

                    LogMessage(message, MessageKind.FAILURE, 4);
                }
            });
            return true;
        }
    }

}
