using EPMLiveCore.SSRS2010;
using System.Linq;

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
            var parentFolderItem = GetOrCreateParentFolder(webApplicationId, client);
            client.CreateFolder(siteCollectionId, parentFolderItem.Path, null);
        }        

        public void DeleteSiteCollection(string webApplicationId, string siteCollectionId)
        {
            var client = GetClient();

            client.DeleteItem($"{webApplicationId}/{siteCollectionId}");
        }

        private CatalogItem GetOrCreateParentFolder(string webApplicationId, ReportingService2010 client)
        {
            var children = client.ListChildren("/", false).ToList();
            if (!children.Exists(x => x.Name == webApplicationId))
            {
                return client.CreateFolder(webApplicationId, "/", null);
            }
            else
            {
                return children.Where(x => x.Name == webApplicationId).First();
            }
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
    }
}