using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Net;
using System.Security.Cryptography;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 60)]
    public class AddFiles : Step
    {
        string storeurl = "";

        public AddFiles(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        public override string Description
        {
            get { return "Updating Files"; }
        }

        public override bool Perform()
        {
            storeurl = CoreFunctions.getFarmSetting("workenginestore");

            SPFile file = SPWeb.GetFile("Resources.aspx");

            if(!file.Exists)
            {
                try
                {

                    AddFile("Resources.aspx", "Resources.txt");

                    LogMessage("Add Resources.aspx");
                }
                catch(Exception ex)
                {
                    LogMessage("", "Add Resources.aspx: " + ex.Message, 3);
                }
            }

            return true;
        }

        private void AddFile(string filename, string remotefile)
        {
            using(WebClient webClient = new WebClient())
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                delegate(
                    object sender,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    return true;

                };

                webClient.Credentials = CoreFunctions.GetStoreCreds();
                byte[] fileBytes = null;
                fileBytes = webClient.DownloadData(storeurl + "/43Upgrade/" + remotefile);
                SPFile f = SPWeb.RootFolder.Files.Add(filename, fileBytes, true);
            }
        }
    }
}
