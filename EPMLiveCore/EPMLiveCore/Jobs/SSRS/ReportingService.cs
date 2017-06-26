using EPMLiveCore.SSRS2010;
using Microsoft.SharePoint;
using System;
using System.Linq;
using System.Net;

namespace EPMLiveCore.Jobs.SSRS
{
    public class ReportingService : IReportingService
    {
        private readonly string password;
        private readonly string reportServerUrl;
        private readonly string username;
        private readonly string authenticationType;

        public ReportingService(string username, string password, string reportServerUrl, string authenticationType)
        {
            this.username = username;
            this.password = password;
            this.reportServerUrl = reportServerUrl;
            this.authenticationType = authenticationType;
        }

        public void CreateSiteCollectionMappedFolder(Guid siteCollectionId)
        {
            var client = GetClient();
            client.CreateFolder(siteCollectionId.ToString(), "/", null);
        }

        public void DeleteSiteCollectionMappedFolder(Guid siteCollectionId)
        {
            var client = GetClient();
            client.DeleteItem($"/{siteCollectionId}");
        }

        public void SyncReports(Guid siteCollectionId, SPDocumentLibrary reportLibrary, out string errors)
        {
            var client = GetClient();
            SyncReportsFromSpToReportServer(siteCollectionId.ToString(), reportLibrary, client, out errors);
        }

        public void DeleteReport(Guid siteCollectionId, string data)
        {
            var report = data.Split(':')[1];
            var folder = data.Split(':')[2];
            var client = GetClient();
            client.DeleteItem($"/{siteCollectionId.ToString()}{folder.Replace("Report Library", "")}/{report}");
        }

        private ReportingService2010 GetClient()
        {
            var client = new ReportingService2010()
            {
                Url = reportServerUrl
            };
            if (authenticationType == "WindowsAuthentication")
            {
                client.Credentials = new NetworkCredential(username, password);
            }
            else if (authenticationType == "FormsBasedAuthentication")
            {
                client.LogonUser(username, password, null);
            }
            return client;
        }

        private void SyncReportsFromSpToReportServer(string siteCollectionId, SPDocumentLibrary reportLibrary, ReportingService2010 service, out string errors)
        {
            errors = string.Empty;

            foreach (SPListItem item in reportLibrary.Items)
            {
                var synchronizedField = item.Fields["Synchronized"] as SPFieldBoolean;
                var synchronized = (bool)synchronizedField.GetFieldValue(Convert.ToString(item["Synchronized"]));
                if (!synchronized)
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
                        item.SystemUpdate();
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