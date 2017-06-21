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
            var client = GetClient();

            var children = client.ListChildren("/", false).ToList();

            CatalogItem parentFolderItem;

            if (!children.Exists(x => x.Name == webApplicationId))
            {
                parentFolderItem = client.CreateFolder(webApplicationId, "/", null);
            }
            else
            {
                parentFolderItem = children.Where(x => x.Name == webApplicationId).First();
            }

            parentFolderItem = client.CreateFolder(webApplicationId, "/", null);

            client.CreateFolder(siteCollectionId, parentFolderItem.Path, null);
        }

        private ReportingService2010 GetClient()
        {
            var client = new ReportingService2010()
            {
                Url = reportServerUrl
            };

            client.LogonUser(username, password, null);

            return client;
        }

        public void DeleteSiteCollection(string webApplicationId, string siteCollectionId)
        {
            var client = GetClient();

            client.DeleteItem($"{webApplicationId}/{siteCollectionId}");
        }
    }
}