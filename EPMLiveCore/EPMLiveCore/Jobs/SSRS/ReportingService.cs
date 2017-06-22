using EPMLiveCore.SSRS2010;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
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

        public void SyncReports(string siteCollectionId, SPDocumentLibrary reportLibrary, out string errors)
        {
            var client = GetClient();
            DeleteNonExistingReportsFromReportServer(siteCollectionId, reportLibrary, client);
            SyncReportsFromSpToReportServer(siteCollectionId, reportLibrary, client, out errors);
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

        private void DeleteNonExistingReportsFromReportServer(string siteCollectionId, SPDocumentLibrary reportLibrary, ReportingService2010 client)
        {
            var children = client.ListChildren($"/{siteCollectionId}", true).ToList().Where(x => x.TypeName == "Report");
            var reports = new List<string>();
            foreach (SPListItem item in reportLibrary.Items)
            {
                reports.Add(item.File.ParentFolder.Url + "/" + item.File.Name);
            }
            foreach (var report in children)
            {
                var mappedReport = "Report Library" + report.Path.Replace($"{siteCollectionId}/", string.Empty);
                if (!reports.Exists(x => x == mappedReport))
                {
                    client.DeleteItem(report.Path);
                }
            }
        }

        private void SyncReportsFromSpToReportServer(string siteCollectionId, SPDocumentLibrary reportLibrary, ReportingService2010 service, out string errors)
        {
            errors = string.Empty;

            foreach (SPListItem item in reportLibrary.Items)
            {
                if(Convert.ToBoolean(item.Fields["Synchronized"]) == false)
                {
                    var reportItem = new ReportItem()
                    {
                        FileName = item.File.Name,
                        LastModified = item.File.TimeLastModified,
                        Folder = item.File.ParentFolder.Url.Replace("Report Library", "").Replace("//", ""),
                        BinaryData = item.File.OpenBinary()
                    };
                    try
                    {
                        CreateFoldersIfNotExist(service, siteCollectionId, reportItem.Folder);
                        UploadReport(service, siteCollectionId, reportItem);
                        item["Synchronized"] = true;
                        item.Update();
                    }
                    catch (Exception exception)
                    {
                        errors += exception.ToString();
                    }
                }
            }
        }

        private void UploadReport(ReportingService2010 service, string siteCollectionId, ReportItem report)
        {
            Warning[] warnings;
            service.CreateCatalogItem("Report", report.FileName, $"/{siteCollectionId}{report.Folder}", true, report.BinaryData, null, out warnings);
        }

        private void CreateFoldersIfNotExist(ReportingService2010 service, string siteCollectionId, string folder)
        {
            var children = service.ListChildren($"/{siteCollectionId}", true).ToList();
            var folders = folder.Split('/').ToList();
            var folderToCheck = $"/{siteCollectionId}";
            for (int i = 0; i < folders.Count; i++)
            {
                if (!string.IsNullOrEmpty(folders[i]))
                {
                    var parentFolder = folderToCheck;
                    folderToCheck += $"/{folders[i]}";
                    if (!children.Exists(x => x.Path == folderToCheck))
                    {
                        service.CreateFolder(folders[i], parentFolder, null);
                        children = service.ListChildren($"/{siteCollectionId}", true).ToList();
                    }
                }
            }
        }
    }
}