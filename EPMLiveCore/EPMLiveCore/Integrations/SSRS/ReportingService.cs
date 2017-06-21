using EPMLiveCore.SSRS2010;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Integrations.SSRS
{
    public class ReportingService : IReportingService
    {
        private readonly string password;
        private readonly string reportServerUrl;
        private readonly string username;

        public ReportingService(string username, string password, string reportServerUrl)
        {
            this.username = username;
            this.password = password;
            this.reportServerUrl = reportServerUrl;
        }

        public void CreateFolders(string webApplicationId, string siteCollectionId)
        {
            var client = new ReportingService2010()
            {
                Url = reportServerUrl
            };

            client.LogonUser(username, password, null);

            var parentFolderItem = client.CreateFolder(webApplicationId, "/", null);

            client.CreateFolder(siteCollectionId, parentFolderItem.Path, null);
        }
    }
}