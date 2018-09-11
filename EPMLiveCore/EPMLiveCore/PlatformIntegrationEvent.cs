using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class PlatformIntegrationEvent : SPItemEventReceiver
    {
        private const string SuccessClosingTag = "<Success/>";
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

                    InsertPlatformIntegrationLogIfNotSuccess(properties, ret);
                }
                catch (Exception ex)
                {
                    InsertPlatformIntegrationLog(properties, ex.Message);
                    Trace.WriteLine(ex.ToString());
                }

            }
        }

        private void InsertPlatformIntegrationLogIfNotSuccess(SPItemEventProperties properties, string ret)
        {
            if (ret != SuccessClosingTag)
            {
                InsertPlatformIntegrationLog(properties, ret);
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

                    InsertPlatformIntegrationLogIfNotSuccess(properties, ret);
                }
                catch (Exception ex)
                {
                    InsertPlatformIntegrationLog(properties, ex.Message);
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        private void InsertPlatformIntegrationLog(SPItemEventProperties properties, string message)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                try
                {
                    if (properties?.Site?.WebApplication?.Id == null)
                    {
                        throw new ArgumentNullException("properties.Site.WebApplication.Id");
                    }
                    using (var connection = new SqlConnection(CoreFunctions.getConnectionString(properties.Site.WebApplication.Id)))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(
                            "INSERT INTO PLATFORMINTEGRATIONLOG (PlatformIntegrationId, DTLOGGED, MESSAGE, LOGLEVEL) VALUES (@intid, GETDATE(), @message, 30)",
                            connection))
                        {
                            command.Parameters.AddWithValue("@intid", id);
                            command.Parameters.AddWithValue("@message", message);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            });
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
