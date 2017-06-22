using EPMLiveCore.SSRS2010;
using System.Linq;
using System;
using Microsoft.SharePoint;
using System.Collections.Generic;

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
            client.DeleteItem($"{webApplicationId}/{siteCollectionId}");
        }

        public void SyncReports(string webApplicationId, string siteCollectionId, SPDocumentLibrary reportLibrary)
        {
            var client = GetClient();
            DeleteNonExistingReportsFromReportServer(webApplicationId, siteCollectionId, reportLibrary, client);
            SyncReportsFromSpToReportServer(webApplicationId, siteCollectionId, reportLibrary, client);
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

        private void DeleteNonExistingReportsFromReportServer(string webApplicationId, string siteCollectionId, SPDocumentLibrary reportLibrary, ReportingService2010 client)
        {
            var children = client.ListChildren($"/{webApplicationId}/{siteCollectionId}", true).ToList().Where(x => x.TypeName == "Report");
            var reports = new List<string>();
            foreach (SPListItem item in reportLibrary.Items)
            {
                reports.Add(item.File.ParentFolder.Url + "/" + item.File.Name);
            }
            foreach (var report in children)
            {
                var mappedReport = "Report Library" + report.Path.Replace($"{webApplicationId}/{siteCollectionId}/", string.Empty);
                if (!reports.Exists(x => x == mappedReport))
                {
                    client.DeleteItem(report.Path);
                }
            }
        }

        private static void SyncReportsFromSpToReportServer(string webApplicationId, string siteCollectionId, SPDocumentLibrary reportLibrary, ReportingService2010 service)
        {
            foreach (SPListItem item in reportLibrary.Items)
            {
                var reportItem = new ReportItem()
                {
                    FileName = item.File.Name,
                    LastModified = item.File.TimeLastModified,
                    Folder = item.File.ParentFolder.Url.Replace("Report Library", "").Replace("//", ""),
                    BinaryData = item.File.OpenBinary()
                };
                CreateFoldersIfNotExist(service, webApplicationId, siteCollectionId, reportItem.Folder);
                UploadReport(service, webApplicationId, siteCollectionId, reportItem);
            }
        }

        private static void UploadReport(ReportingService2010 service, string webApplicationId, string siteCollectionId, ReportItem report)
        {
            Warning[] warnings;
            service.CreateCatalogItem("Report", report.FileName, $"/{webApplicationId}/{siteCollectionId}{report.Folder}", true, report.BinaryData, null, out warnings);
        }

        private static void CreateFoldersIfNotExist(ReportingService2010 service, string webApplicationId, string siteCollectionId, string folder)
        {
            var children = service.ListChildren($"/{webApplicationId}/{siteCollectionId}", true).ToList();
            var folders = folder.Split('/').ToList();
            var folderToCheck = $"/{webApplicationId}/{siteCollectionId}";
            for (int i = 0; i < folders.Count; i++)
            {
                if (!string.IsNullOrEmpty(folders[i]))
                {
                    var parentFolder = folderToCheck;
                    folderToCheck += $"/{folders[i]}";
                    if (!children.Exists(x => x.Path == folderToCheck))
                    {
                        service.CreateFolder(folders[i], parentFolder, null);
                        children = service.ListChildren($"/{webApplicationId}/{siteCollectionId}", true).ToList();
                    }
                }
            }
        }
    }
}