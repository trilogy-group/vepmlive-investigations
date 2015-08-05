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

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V569, Order = 1.0, Description = "Updates for TFS Integration")]
    internal class UpdateTfsCustomProps : UpgradeStep
    {
        public UpdateTfsCustomProps(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }
        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    LogMessage("Connecting to the database . . .", 2);
                    string connectionString = CoreFunctions.getConnectionString(webAppId);
                    using (var sqlConnection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            sqlConnection.Open();
                            string moduleId = "B0950B9B-3525-40B8-A456-6403156DC003";
                            string customPropsText = @"<Properties><Connection><Input Type=""Text"" Property=""ServerUrl"" Title=""Tfs Server Url"" /><Input Type=""Text"" Property=""Username"" Title=""Username"" /><Input Type=""Password"" Property=""Password"" Title=""Password"" /><Input Type=""Checkbox"" Property=""UseBasicAuthentication"" Title=""Use Basic Authentication"" /></Connection><General><Input Type=""Select"" Property=""TeamProjectCollection"" Title=""Project Collection"" /><Input Type=""Select"" Property=""Object"" Title=""Object"" /></General></Properties>";
                            using (
                               var sqlCommand =
                                   new SqlCommand(
                                       "update INT_MODULES set CustomProps = @customProps where MODULE_ID = @module_Id",
                                       sqlConnection))
                            {
                                sqlCommand.CommandType = CommandType.Text;
                                sqlCommand.Parameters.AddWithValue("@customProps", customPropsText);
                                sqlCommand.Parameters.AddWithValue("@module_Id", moduleId);
                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                        finally
                        {
                            sqlConnection.Close();
                        }
                        LogMessage(string.Format("Added new check box type field 'Use Basic Authentication' on the screen for TFS integration"), MessageKind.SUCCESS, 4);
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

    [UpgradeStep(Version = EPMLiveVersion.V569, Order = 2.0, Description = "Updates for Custom Project Field")]
    internal class UpdateCustomProjectField : UpgradeStep
    {
        public UpdateCustomProjectField(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }
        public override bool Perform()
        {
            return true;
        }
    }

    [UpgradeStep(Version = EPMLiveVersion.V569, Order = 3.0, Description = "Updates for Zendesk Widget Integration")]
    internal class UpdateZendeskWidgetIntegration : UpgradeStep
    {
        private SPWeb _spWeb;
        public UpdateZendeskWidgetIntegration(SPWeb spWeb, bool isPfeSite)
            : base(spWeb, isPfeSite)
        {
            _spWeb = spWeb;
        }
        public override bool Perform()
        {
            //Check if WalkMeID property is available 
            var walkMeId = CoreFunctions.getConfigSetting(_spWeb, "EPMLiveWalkMeId");
            if (walkMeId != null)
            {
                //Add new setting for ZendeskIntegration
                CoreFunctions.setConfigSetting(_spWeb, "SupportIntegration", "True");
                //Remove EPMLiveWalkMeId from config settings 
                _spWeb.Properties.Remove("EPMLiveWalkMeId");
                _spWeb.Properties.Update();
            }
            else
            {
                CoreFunctions.setConfigSetting(_spWeb, "SupportIntegration", "False");
            }

            return true;
        }
    }
}
