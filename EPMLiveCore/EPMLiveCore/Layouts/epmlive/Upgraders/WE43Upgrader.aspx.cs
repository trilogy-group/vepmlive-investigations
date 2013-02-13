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
    public partial class WE43Upgrader : LayoutsPageBase
    {
        protected string sText = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if(!Web.CurrentUser.IsSiteAdmin)
                {
                    pnlMain.Visible = false;
                    lblError.Text = "You are not an admin.";
                }
                else
                {
                    if (!Web.IsRootWeb)
                    {
                        NotRootMessageLabel.Visible = true;
                    }

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
                            fileBytes = webClient.DownloadData(storeurl + "/43Upgrade/PreUpgradeText4.3.0.txt");

                            System.Text.Encoding encoding = encoding = new System.Text.ASCIIEncoding();

                            sText = encoding.GetString(fileBytes);
                        }
                    }
                    catch { }
                }
            }
            catch { }


        }

       
    }
}