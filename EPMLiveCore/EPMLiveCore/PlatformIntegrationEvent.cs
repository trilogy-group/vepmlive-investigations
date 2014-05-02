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

                    if (ret != "Success")
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            try
                            {
                                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(properties.Site.WebApplication.Id));
                                cn.Open();

                                SqlCommand cmd = new SqlCommand("INSERT INTO PLATFORMINTEGRATIONLOG (PlatformIntegrationId, DTLOGGED, MESSAGE) VALUES (@intid, GETDATE(), @message)", cn);
                                cmd.Parameters.AddWithValue("@intid", id);
                                cmd.Parameters.AddWithValue("@message", ret);
                                cmd.ExecuteNonQuery();

                                cn.Close();
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
                            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(properties.Site.WebApplication.Id));
                            cn.Open();

                            SqlCommand cmd = new SqlCommand("INSERT INTO PLATFORMINTEGRATIONLOG (PlatformIntegrationId, DTLOGGED, MESSAGE) VALUES (@intid, GETDATE(), @message)", cn);
                            cmd.Parameters.AddWithValue("@intid", id);
                            cmd.Parameters.AddWithValue("@message", ex.Message);
                            cmd.ExecuteNonQuery();

                            cn.Close();
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
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(properties.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select IntegrationUrl, IntegrationKey, PlatformIntegrationId from PLATFORMINTEGRATIONS where ListId=@ListId", cn);
                    cmd.Parameters.AddWithValue("@ListId", properties.ListId);
                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        url = dr.GetString(0);
                        key = dr.GetString(1);
                        id = dr.GetGuid(2);
                    }
                    dr.Close();

                    cn.Close();
                }
                catch { }
            });
        }
    }
}
