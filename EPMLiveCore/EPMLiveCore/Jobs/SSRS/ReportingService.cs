using EPMLiveCore.SSRS2010;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Claims;
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
        private readonly string siteCollectionId;

        public ReportingService(string username, string password, string reportServerUrl, string authenticationType, Guid siteCollectionId)
        {
            this.username = username;
            this.password = password;
            this.reportServerUrl = reportServerUrl;
            this.authenticationType = authenticationType;
            this.siteCollectionId = siteCollectionId.ToString();
        }

        public void CreateSiteCollectionMappedFolder()
        {
            var client = GetClient();
            client.CreateFolder(siteCollectionId, "/", null);
        }

        public void DeleteSiteCollectionMappedFolder()
        {
            var client = GetClient();
            client.DeleteItem($"/{siteCollectionId}");
        }

        public void SyncReports(SPDocumentLibrary reportLibrary)
        {
            var errors = string.Empty;
            var client = GetClient();
            foreach (SPListItem item in reportLibrary.Items)
            {
                EnsureFieldExists(item, "Synchronized", SPFieldType.Boolean);
                EnsureFieldExists(item, "UpdatedBy", SPFieldType.Text);
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
                        item["UpdatedBy"] = "RS";
                        item.SystemUpdate();
                    }
                    catch (Exception exception)
                    {
                        errors += exception.ToString();
                    }
                }
            }

            if(string.IsNullOrEmpty(errors))
            {
                throw new Exception(errors);
            }
        }

        public void DeleteReport(string data)
        {
            var report = data.Split(':')[1];
            var folder = data.Split(':')[2];
            var client = GetClient();
            client.DeleteItem($"/{siteCollectionId.ToString()}{folder.Replace("Report Library", "")}/{report}");
        }

        public void AssignRoleMapping(List<SPGroup> groups, SPList userList)
        {
            var client = GetClient();
            var roles = client.ListRoles("Catalog", "");
            var contentManagers = AssignContentManagerRole(groups, userList, client, roles.GetRole("Content Manager"));
            AssignReportViewerRole(groups, userList, client, roles.GetRole("Browser"), contentManagers);
        }

        public void RemoveRoleMapping(string data)
        {
            var loginName = data.Split('~')[1];
            var group = data.Split('~')[2];
            var client = GetClient();
            bool inheritParent;
            var policies = client.GetPolicies($"/{siteCollectionId.ToString()}", out inheritParent).ToList();
            loginName = SPClaimProviderManager.Local.DecodeClaim(loginName).Value;
            var existingRole = policies.SingleOrDefault(x => x.GroupUserName.ToLower() == loginName.ToLower());
            if (existingRole != null)
            {
                var roleList = existingRole.Roles.ToList();
                var roleToRemove = roleList.Where(x => x.Name == GetSSRSRole(group)).FirstOrDefault();
                roleList.Remove(roleToRemove);
                existingRole.Roles = roleList.ToArray();
                if(roleList.Count == 0)
                {
                    policies.RemoveAll(x => x.GroupUserName.ToLower() == loginName.ToLower());
                }
                client.SetPolicies($"/{siteCollectionId.ToString()}", policies.ToArray());
            }
        }

        private string GetSSRSRole(string group)
        {
            if (group == "Report Viewers")
                return "Browser";
            else if (group == "Administrators")
                return "Content Managers";
            return string.Empty;
        }

        private void AssignReportViewerRole(List<SPGroup> groups, SPList userList, ReportingService2010 client, Role role, List<SPUser> contentManagers)
        {
            var reportViewers = groups.Single(x => x.Name == "Report Viewers").Users.OfType<SPUser>().ToList();
            foreach (SPUser user in reportViewers)
            {
                var extendedList = userList.Items.GetItemById(user.ID);
                EnsureFieldExists(extendedList, "Synchronized", SPFieldType.Boolean);
                if ((extendedList["Synchronized"] == null || Convert.ToBoolean(extendedList["Synchronized"]) == false)
                    && !contentManagers.Exists(x => x.Name == user.Name) && user.Name != "System Account")
                {
                    AssignRole(client, role, user.LoginName);
                    extendedList["Synchronized"] = true;
                    extendedList.Update();
                }
            }
        }

        private List<SPUser> AssignContentManagerRole(List<SPGroup> groups, SPList userList, ReportingService2010 client, Role role)
        {
            var contentManagers = groups.Single(x => x.Name == "Administrators").Users.OfType<SPUser>().ToList();
            foreach (SPUser user in contentManagers.Where(x => x.Name != "System Account"))
            {
                var extendedList = userList.Items.GetItemById(user.ID);
                EnsureFieldExists(extendedList, "Synchronized", SPFieldType.Boolean);
                if ((extendedList["Synchronized"] == null || Convert.ToBoolean(extendedList["Synchronized"]) == false)
                    && user.Name != "System Account")
                {
                    AssignRole(client, role, user.LoginName);
                    extendedList["Synchronized"] = true;
                    extendedList.Update();
                }
            }

            return contentManagers;
        }

        private void EnsureFieldExists(SPListItem extendedList, string fieldName, SPFieldType fieldType)
        {
            if (!extendedList.Fields.ContainsField(fieldName))
            {
                extendedList.Fields.Add(fieldName, fieldType, false);
            }
        }

        private void AssignRole(ReportingService2010 client, Role role, string loginName)
        {
            bool inheritParent;
            var policies = client.GetPolicies($"/{siteCollectionId.ToString()}", out inheritParent).ToList();
            loginName = SPClaimProviderManager.Local.DecodeClaim(loginName).Value;
            var existingRole = policies.SingleOrDefault(x => x.GroupUserName.ToLower() == loginName.ToLower());
            if (existingRole == null)
            {
                policies.Add(new Policy
                {
                    GroupUserName = loginName,
                    Roles = new Role[] { role }
                });
            }
            else
            {
                var roleList = existingRole.Roles.ToList();
                roleList.Clear();
                roleList.Add(role);
                existingRole.Roles = roleList.ToArray();
            }
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