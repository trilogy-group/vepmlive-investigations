using EPMLiveCore.SSRS2010;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Claims;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace EPMLiveCore.Jobs.SSRS
{
    public class ReportingService : IReportingService
    {
        private readonly string siteCollectionId;
        private readonly ReportingService2010 client;

        public ReportingService(string username, string password, string reportServerUrl, string authenticationType, Guid siteCollectionId)
        {
            client = GetClient(username, password, reportServerUrl, authenticationType);
            this.siteCollectionId = siteCollectionId.ToString();
        }

        public static IReportingService GetInstance(SPSite site)
        {
            return new ReportingService(Convert.ToString(site.WebApplication.Properties["SSRSAdminUsername"]),
                                                                                Convert.ToString(site.WebApplication.Properties["SSRSAdminPassword"]),
                                                                                Convert.ToString(site.WebApplication.Properties["SSRSReportServerUrl"]),
                                                                                Convert.ToString(site.WebApplication.Properties["SSRSAuthenticationType"]),
                                                                                site.ID);
        }

        public void CreateSiteCollectionMappedFolder()
        {
            client.CreateFolder(siteCollectionId, "/", null);
        }

        public void DeleteSiteCollectionMappedFolder()
        {
            client.DeleteItem($"/{siteCollectionId}");
        }

        public void SyncReports(SPDocumentLibrary reportLibrary)
        {
            lock (siteCollectionId + "_ReportLibrary")
            {
                var errors = string.Empty;
                var spQuery = new SPQuery()
                {
                    Query = "<Where><Neq><FieldRef Name='Synchronized' /><Value Type='Boolean'>true</Value></Neq></Where>"
                };
                foreach (SPListItem item in reportLibrary.GetItems(spQuery))
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

                if (string.IsNullOrEmpty(errors))
                {
                    throw new Exception(errors);
                }
            }
        }

        public void DeleteReport(string data)
        {
            var report = data.Split(':')[1];
            var folder = data.Split(':')[2];
            client.DeleteItem($"/{siteCollectionId.ToString()}{folder.Replace("Report Library", "")}/{report}");
        }

        public void AssignRoleMapping(SPGroupCollection groups, SPList userList)
        {
            lock (siteCollectionId + "_RoleMapping")
            {
                var roles = client.ListRoles("Catalog", "");
                var errors = string.Empty;
                try
                {
                    AssignSsrsRole(groups, userList, client, roles.GetRole("Content Manager"), "Administrators");
                }
                catch (Exception exception)
                {
                    errors += exception.ToString();
                }
                try
                {
                    AssignSsrsRole(groups, userList, client, roles.GetRole("Browser"), "Report Viewers");
                }
                catch (Exception exception)
                {
                    errors += exception.ToString();
                }
                if (!string.IsNullOrEmpty(errors))
                {
                    throw new Exception(errors);
                }
            }
        }

        public void RemoveRoleMapping(string data)
        {
            var loginName = data.Split('~')[1];
            var group = data.Split('~')[2];
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
                if (roleList.Count == 0)
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

        private void AssignSsrsRole(SPGroupCollection groups, SPList userList, ReportingService2010 client, Role role, string spRole)
        {
            string errors = string.Empty;
            var reportViewers = groups.GetByName(spRole);
            foreach (SPUser user in reportViewers.Users)
            {
                try
                {
                    var extendedList = userList.Items.GetItemById(user.ID);
                    if ((extendedList["Synchronized"] == null || Convert.ToBoolean(extendedList["Synchronized"]) == false)
                        && user.Name != "System Account")
                    {
                        AssignRole(client, role, user.LoginName);
                        extendedList["Synchronized"] = true;
                        extendedList.SystemUpdate();
                    }
                }
                catch (Exception exception)
                {
                    errors += exception.ToString();
                }
            }
            if (!string.IsNullOrEmpty(errors))
            {
                throw new Exception(errors);
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

        private ReportingService2010 GetClient(string username, string password, string reportServerUrl, string authenticationType)
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
            if (report.FileName.EndsWith(".rdl"))
            {
                service.CreateCatalogItem("Report", report.FileName, $"/{siteCollectionId}{report.Folder}", true, report.BinaryData, null, out warnings);
            }
            else if (report.FileName.EndsWith(".rsds"))
            {
                var doc = new XmlDocument();
                doc.LoadXml(Encoding.UTF8.GetString(report.BinaryData));
                var definition = new DataSourceDefinition()
                {
                    CredentialRetrieval = (CredentialRetrievalEnum)Enum.Parse(typeof(CredentialRetrievalEnum), doc.SelectSingleNode("/DataSourceDefinition/CredentialRetrieval").InnerText),
                    ConnectString = doc.GetStringValue("/DataSourceDefinition/ConnectString"),
                    Enabled = doc.GetBooleanValue("/DataSourceDefinition/Enabled"),
                    Extension = doc.GetStringValue("/DataSourceDefinition/Extension"),
                    ImpersonateUser = doc.GetBooleanValue("/DataSourceDefinition/ImpersonateUser"),
                    OriginalConnectStringExpressionBased = doc.GetBooleanValue("/DataSourceDefinition/OriginalConnectStringExpressionBased"),
                    Password = doc.GetStringValue("/DataSourceDefinition/Password"),
                    Prompt = doc.GetStringValue("/DataSourceDefinition/Prompt"),
                    UseOriginalConnectString = doc.GetBooleanValue("/DataSourceDefinition/UseOriginalConnectString"),
                    UserName = doc.GetStringValue("/DataSourceDefinition/UserName"),
                    WindowsCredentials = doc.GetBooleanValue("/DataSourceDefinition/WindowsCredentials")
                };
                service.CreateDataSource(report.FileName, $"/{siteCollectionId}{report.Folder}", true, definition, null);
            }
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