using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveIntegration;
using System.Net;
using System.Collections.Specialized;

namespace UplandIntegrations.FileBound
{
    internal class FBConnection
    {
        public string FBGUID = "";

        public FBConnection(WebProperties WebProps, IntegrationLog log)
        {
            try
            {
                if (FBGUID == "")
                {
                    using (WebClient client = new WebClient())
                    {
                        NameValueCollection parameters = new NameValueCollection();
                        parameters.Add("username", WebProps.Properties["Username"].ToString());
                        parameters.Add("password", WebProps.Properties["Password"].ToString());

                        byte[] responseBytes = client.UploadValues(WebProps.Properties["APIUrl"].ToString() + "login?fbsite=" + WebProps.Properties["SiteUrl"].ToString(), "POST", parameters);
                        string responseBody = (new System.Text.UTF8Encoding()).GetString(responseBytes);

                        // remove the double quotes around the guid:
                        if (responseBody.Length > 0 && responseBody.EndsWith("\"")) responseBody = responseBody.Remove(responseBody.Length - 1);
                        if (responseBody.Length > 0 && responseBody.StartsWith("\"")) responseBody = responseBody.Remove(0, 1);
                        FBGUID = responseBody;
                    }
                }
            }
            catch(Exception ex)
            {
                log.LogMessage("Error Connecting: " + ex.Message, IntegrationLogType.Error);
            }
        }
    }
}
