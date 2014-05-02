using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using System.Data.SqlClient;

namespace EPMLiveCore
{
    public class PlatformIntegrationEvent : SPItemEventReceiver
    {
        private string url = "";
        private string key = "";


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

            if (url != "")
            {
                UplandPlatformAPI.IntegrationAPI api = new UplandPlatformAPI.IntegrationAPI();
                api.Url = url;
                api.PostItemSimple(key, properties.ListItemId.ToString());


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

                    SqlCommand cmd = new SqlCommand("select IntegrationUrl, IntegrationKey from PLATFORMINTEGRATIONS where ListId=@ListId", cn);
                    cmd.Parameters.AddWithValue("@ListId", properties.ListId);
                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        url = dr.GetString(0);
                        key = dr.GetString(1);
                    }
                    dr.Close();

                    cn.Close();
                }
                catch { }
            });
        }
    }
}
