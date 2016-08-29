using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Net;
using System.Security.Cryptography;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml;


namespace EPMLiveCore.Layouts.epmlive.Upgraders
{
    public partial class UpgradeDone : LayoutsPageBase
    {

        protected string sMessage = "";
        protected string sResult = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            XmlNode ndRes = API.Timer.GetTimerJobStatus(Web.Site.ID, Web.ID, Jobs.Upgrades.Steps.Utilities.GetJobType(Request["V"]), true);

            sResult = ndRes.InnerText.Replace("\r\n", "<br>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");

            string storeurl = CoreFunctions.getFarmSetting("workenginestore");

            try
            {
                using(WebClient webClient = new WebClient())
                {
                    ServicePointManager.ServerCertificateValidationCallback +=
                    delegate(
                        object sender2,
                        X509Certificate certificate,
                        X509Chain chain,
                        SslPolicyErrors sslPolicyErrors)
                    {
                        return true;

                    };

                    webClient.Credentials = CoreFunctions.GetStoreCreds();
                    byte[] fileBytes = null;
                    fileBytes = webClient.DownloadData(storeurl + "/43Upgrade/UpgradeText" + Request["V"] + ".txt");

                    System.Text.Encoding encoding = encoding = new System.Text.ASCIIEncoding();

                    sMessage = encoding.GetString(fileBytes);
                }
            }
            catch { }
        }

        
    }
}
