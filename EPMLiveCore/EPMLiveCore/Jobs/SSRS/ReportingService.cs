using EPMLiveCore.SSRS2010;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
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
            errors = string.Empty;
            var client = GetClient();
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
                        CreateFoldersIfNotExist(client, siteCollectionId.ToString(), reportItem.Folder);
                        UploadReport(client, siteCollectionId.ToString(), reportItem);
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

        public void DeleteReport(Guid siteCollectionId, string data)
        {
            var report = data.Split(':')[1];
            var folder = data.Split(':')[2];
            var client = GetClient();
            client.DeleteItem($"/{siteCollectionId.ToString()}{folder.Replace("Report Library", "")}/{report}");
        }

        public void AssignRoleMapping(Guid siteCollectionId, List<SPGroup> groups, SPList userList)
        {
            var client = GetClient();
            var roles = client.ListRoles("Catalog", "");
            var contentManagers = AssignContentManagerRole(siteCollectionId, groups, userList, client, roles.GetRole("Content Manager"));
            AssignReportViewerRole(siteCollectionId, groups, userList, client, roles.GetRole("Report Viewer"), contentManagers);
        }

        private void AssignReportViewerRole(Guid siteCollectionId, List<SPGroup> groups, SPList userList, ReportingService2010 client, Role role, List<SPUser> contentManagers)
        {
            var reportViewers = groups.Single(x => x.Name == "Report Viewers").Users.OfType<SPUser>().ToList();
            foreach (SPUser user in reportViewers)
            {
                var extendedList = userList.Items.GetItemById(user.ID);
                EnsureFieldExists(extendedList);
                if ((extendedList["Synchronized"] == null || Convert.ToBoolean(extendedList["Synchronized"]) == false)
                    && !contentManagers.Exists(x => x.Name == user.Name) && user.Name != "System Account")
                {
                    AssignRole(siteCollectionId, client, role, user.LoginName);
                    extendedList["Synchronized"] = true;
                }
            }
        }

        private List<SPUser> AssignContentManagerRole(Guid siteCollectionId, List<SPGroup> groups, SPList userList, ReportingService2010 client, Role role)
        {
            var contentManagers = groups.Single(x => x.Name == "Administrators").Users.OfType<SPUser>().ToList();
            foreach (SPUser user in contentManagers.Where(x => x.Name != "System Account"))
            {
                var extendedList = userList.Items.GetItemById(user.ID);
                EnsureFieldExists(extendedList);
                if ((extendedList["Synchronized"] == null || Convert.ToBoolean(extendedList["Synchronized"]) == false)
                    && user.Name != "System Account")
                {
                    AssignRole(siteCollectionId, client, role, user.LoginName);
                    extendedList["Synchronized"] = true;
                }
            }

            return contentManagers;
        }

        private static void EnsureFieldExists(SPListItem extendedList)
        {
            if (extendedList["Synchronized"] == null)
            {
                extendedList.Fields.Add("Synchronized", SPFieldType.Boolean, false);
            }
        }

        private void AssignRole(Guid siteCollectionId, ReportingService2010 client, Role role, string loginName)
        {
            var policies = new List<Policy>();
            policies.Add(new Policy
            {
                GroupUserName = loginName,
                Roles = new Role[] { role }
            });
            client.SetPolicies($"/{siteCollectionId.ToString()}", policies.ToArray());
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