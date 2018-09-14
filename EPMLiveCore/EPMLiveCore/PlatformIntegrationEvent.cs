using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using System.Data.SqlClient;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace EPMLiveCore
{
    public class PlatformIntegrationEvent : SPItemEventReceiver
    {
        private string url = "";
        private string key = "";
        private Guid id;

        public override void ItemAdded(SPItemEventProperties properties)
        {
            SendItem(properties);
        }

        public override void ItemUpdated(SPItemEventProperties properties)
        {
            SendItem(properties);
        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            GetKeyAndUrl(properties);

            if (url != "")
            {

                try
                {
                    UplandPlatformAPI.IntegrationAPI api = new UplandPlatformAPI.IntegrationAPI();
                    api.Url = url;
                    string ret = api.DeleteItem(key, properties.ListItemId.ToString());

                    if (ret != "<Success/>")
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            try
                            {
                                using (var connection = new SqlConnection(CoreFunctions.getConnectionString(properties.Site.WebApplication.Id)))
                                {
                                    connection.Open();

                                    using (var command = new SqlCommand(
                                        "INSERT INTO PLATFORMINTEGRATIONLOG (PlatformIntegrationId, DTLOGGED, MESSAGE, LOGLEVEL) VALUES (@intid, GETDATE(), @message, 30)",
                                        connection))
                                    {
                                        command.Parameters.AddWithValue("@intid", id);
                                        command.Parameters.AddWithValue("@message", ret);
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                            catch { }
                        });
                    }
                }
                catch (Exception ex)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        try
                        {
                            using (var connection = new SqlConnection(CoreFunctions.getConnectionString(properties.Site.WebApplication.Id)))
                            {
                                connection.Open();

                                using (var command = new SqlCommand(
                                    "INSERT INTO PLATFORMINTEGRATIONLOG (PlatformIntegrationId, DTLOGGED, MESSAGE, LOGLEVEL) VALUES (@intid, GETDATE(), @message, 30)",
                                    connection))
                                {
                                    command.Parameters.AddWithValue("@intid", id);
                                    command.Parameters.AddWithValue("@message", ex.Message);
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        catch { }
                    });
                }

            }
        }

        private void SendItem(SPItemEventProperties properties)
        {
            GetKeyAndUrl(properties);

            ServicePointManager.ServerCertificateValidationCallback +=
                delegate(
                    object sender,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    return true;

                };
            if (url != "")
            {
                try
                {
                    UplandPlatformAPI.IntegrationAPI api = new UplandPlatformAPI.IntegrationAPI();
                    api.Url = url;
                    string ret = api.PostItemSimple(key, properties.ListItemId.ToString());

                    if (ret != "<Success/>")
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            try
                            {
                                using (var connection = new SqlConnection(CoreFunctions.getConnectionString(properties.Site.WebApplication.Id)))
                                {
                                    connection.Open();

                                    using (var command = new SqlCommand(
                                        "INSERT INTO PLATFORMINTEGRATIONLOG (PlatformIntegrationId, DTLOGGED, MESSAGE, LOGLEVEL) VALUES (@intid, GETDATE(), @message, 30)",
                                        connection))
                                    {
                                        command.Parameters.AddWithValue("@intid", id);
                                        command.Parameters.AddWithValue("@message", ret);
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                            catch { }
                        });
                    }
                }
                catch (Exception ex)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        try
                        {
                            using (var connection = new SqlConnection(CoreFunctions.getConnectionString(properties.Site.WebApplication.Id)))
                            {
                                connection.Open();

                                using (var command = new SqlCommand(
                                    "INSERT INTO PLATFORMINTEGRATIONLOG (PlatformIntegrationId, DTLOGGED, MESSAGE, LOGLEVEL) VALUES (@intid, GETDATE(), @message, 30)",
                                    connection))
                                {
                                    command.Parameters.AddWithValue("@intid", id);
                                    command.Parameters.AddWithValue("@message", ex.Message);
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        catch { }
                    });
                }
            }
        }

        private void GetKeyAndUrl(SPItemEventProperties properties)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    using (var connection = new SqlConnection(CoreFunctions.getConnectionString(properties.Site.WebApplication.Id)))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(
                            "select IntegrationUrl, IntegrationKey, PlatformIntegrationId from PLATFORMINTEGRATIONS where ListId=@ListId",
                            connection))
                        {
                            command.Parameters.AddWithValue("@ListId", properties.ListId);
                            command.ExecuteNonQuery();

                            using (var dataReader = command.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    url = dataReader.GetString(0);
                                    key = dataReader.GetString(1);
                                    id = dataReader.GetGuid(2);
                                }
                            }
                        }
                    }
                }
                catch { }
            });
        }
    }
}
