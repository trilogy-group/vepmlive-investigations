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
                            string customPropsText = string.Empty;
                            using (SqlCommand cmd = new SqlCommand("select CustomProps from INT_MODULES where MODULE_ID = @module_Id", sqlConnection))
                            {
                                cmd.Parameters.AddWithValue("@module_Id", moduleId);
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        customPropsText = dr.GetString(0);
                                        dr.Close();
                                    }
                                }
                            }
                            if (customPropsText.Contains("UseBasicAuthentication"))
                            {
                                LogMessage(string.Format("Use Basic Authentication property for TFS integration is already exists."), MessageKind.SKIPPED, 4);
                            }
                            else
                            {

                                customPropsText = @"<Properties><Connection><Input Type=""Text"" Property=""ServerUrl"" Title=""Tfs Server Url"" /><Input Type=""Text"" Property=""Username"" Title=""Username"" /><Input Type=""Password"" Property=""Password"" Title=""Password"" /><Input Type=""Checkbox"" Property=""UseBasicAuthentication"" Title=""Use Basic Authentication"" /></Connection><General><Input Type=""Select"" Property=""TeamProjectCollection"" Title=""Project Collection"" /><Input Type=""Select"" Property=""Object"" Title=""Object"" /></General></Properties>";
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
                                LogMessage(string.Format("Use Basic Authentication property for TFS integration added successfully."), MessageKind.SUCCESS, 4);
                            }
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

    [UpgradeStep(Version = EPMLiveVersion.V569, Order = 2.0, Description = "Updates for Resource List Cleanup")]
    internal class UpdateTimerSetting : UpgradeStep
    {
        public UpdateTimerSetting(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }
        public override bool Perform()
        {
            Guid webAppId = Web.Site.WebApplication.Id;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    SPList list = Web.Lists.TryGetList("Resources");
                    string sLists = EPMLiveCore.CoreFunctions.getConfigSetting(Web, "epmlivefixlists");
                    if (list != null && sLists.ToLower().Contains("\r\nresources"))
                    {
                        LogMessage("Resource List Cleanup settings kept as is.", 2);
                    }
                    else
                    {
                        string connectionString = CoreFunctions.getConnectionString(webAppId);
                        using (var sqlConnection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                sqlConnection.Open();
                                Guid timerjobguid;
                                //=======================Timer Job==========================
                                using (SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=2", sqlConnection))
                                {
                                    cmd.Parameters.AddWithValue("@siteguid", Web.Site.ID.ToString());
                                    using (SqlDataReader dr = cmd.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            timerjobguid = dr.GetGuid(0);
                                            dr.Close();
                                            using (SqlCommand cmd1 = new SqlCommand("UPDATE TIMERJOBS set runtime = @runtime where siteguid=@siteguid and jobtype=2", sqlConnection))
                                            {
                                                cmd1.Parameters.AddWithValue("@siteguid", Web.Site.ID.ToString());
                                                cmd1.Parameters.AddWithValue("@runtime", "-1");
                                                cmd1.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            timerjobguid = Guid.NewGuid();
                                            dr.Close();
                                            using (SqlCommand cmd2 = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, runtime, scheduletype, webguid) VALUES (@timerjobuid, @siteguid, 2, 'Today Fix/Res Plan', @runtime, 2, @webguid)", sqlConnection))
                                            {
                                                cmd2.Parameters.AddWithValue("@siteguid", Web.Site.ID.ToString());
                                                cmd2.Parameters.AddWithValue("@timerjobuid", timerjobguid);
                                                cmd2.Parameters.AddWithValue("@webguid", Web.ID.ToString());
                                                cmd2.Parameters.AddWithValue("@runtime", "-1");
                                                cmd2.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }

                            }
                            finally
                            {
                                sqlConnection.Close();
                            }
                        }
                        LogMessage("Resource List Cleanup settings disabled.", 2);
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


    [UpgradeStep(Version = EPMLiveVersion.V569, Order = 3.0, Description = "Remove WalkMe Integration")]
    internal class RemoveWalkMeIntegration : UpgradeStep
    {
        private SPWeb _spWeb;
        public RemoveWalkMeIntegration(SPWeb spWeb, bool isPfeSite)
            : base(spWeb, isPfeSite)
        {
            _spWeb = spWeb;
        }
        public override bool Perform()
        {
            bool blnReturn = false;
            try
            {
                //Check if WalkMeID property is available 
                var walkMeId = CoreFunctions.getConfigSetting(_spWeb, "EPMLiveWalkMeId");
                if (walkMeId != null)
                {
                    //Remove EPMLiveWalkMeId from config settings 
                    _spWeb.Properties.Remove("EPMLiveWalkMeId");
                    _spWeb.Properties.Update();
                    blnReturn = true;
                    LogMessage("WalkMeId property removed.", MessageKind.SUCCESS, 4);
                }
                else
                {
                    LogMessage("WalkMeId property doesn't exists.", MessageKind.SKIPPED, 2);                    
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, MessageKind.FAILURE, 2);
                blnReturn = false; 
            }
            return blnReturn;
        }
    }
}
