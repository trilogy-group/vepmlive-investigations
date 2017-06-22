using EPMLiveCore.SSRS2010;
using System.Linq;

namespace EPMLiveCore.Jobs.SSRS
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

        public void CreateSiteCollectionMappedFolder(string siteCollectionId)
        {
            var client = GetClient();
            client.CreateFolder(siteCollectionId, "/", null);
        }

        public void DeleteSiteCollectionMappedFolder(string siteCollectionId)
        {
            var client = GetClient();
            client.DeleteItem($"/{siteCollectionId}");
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