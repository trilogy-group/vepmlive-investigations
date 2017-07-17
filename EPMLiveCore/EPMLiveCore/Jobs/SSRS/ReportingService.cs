using EPMLiveCore.SSRS2010;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Claims;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace EPMLiveCore.Jobs.SSRS
{
    public class ReportingService : IReportingService
    {
        private readonly string siteCollectionId;
        private readonly ReportingService2010Extended client;
        private List<CatalogItem> dataSources;

        public ReportingService(string username, string password, string reportServerUrl, string authenticationType, Guid siteCollectionId)
        {
            client = new ReportingService2010Extended()
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
            this.siteCollectionId = siteCollectionId.ToString();
        }

        public static IReportingService GetInstance(SPSite site)
        {
            var reportServerUrl = CoreFunctions.getWebAppSetting(site.WebApplication.Id, "ReportingServicesURL") + "ReportService2010.asmx";
            var authInfo = site.WebApplication.GetChild<ReportAuth>("ReportAuth");
            var username = authInfo.Username;
            var password = CoreFunctions.Decrypt(authInfo.Password, "KgtH(@C*&@Dhflosdf9f#&f");
            var authenticationType = bool.Parse(CoreFunctions.getWebAppSetting(site.WebApplication.Id, "ReportsWindowsAuthentication")) == true ? "WindowsAuthentication" : "FormsBasedAuthentication";
            return new ReportingService(username, password, reportServerUrl, authenticationType, site.ID);
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
                    Query = "<Where><And><Eq><FieldRef Name='FSObjType' /><Value Type='Integer'>0</Value></Eq><Neq><FieldRef Name='Synchronized' /><Value Type='Boolean'>1</Value></Neq></And></Where>",
                    ViewAttributes = "Scope=\"RecursiveAll\""
                };
                var items = reportLibrary.GetItems(spQuery).OfType<SPListItem>().OrderByDescending(x => new FileInfo(x.File.Name).Extension).ToList();
                foreach (SPListItem item in items)
                {
                    var reportItem = new ReportItem()
                    {
                        FileName = item.File.Name,
                        LastModified = item.File.TimeLastModified,
                        Folder = item.File.ParentFolder.Url,
                        BinaryData = item.File.OpenBinary(),
                        DatasourceCredentials = item.File.Name.ToLower().EndsWith(".rsds") ? CoreFunctions.Decrypt(Convert.ToString(item["Datasource Credentials"]), "FpUagQ2RG9") : null
                    };
                    try
                    {
                        CreateFoldersIfNotExist(siteCollectionId.ToString(), reportItem.Folder);
                        UploadReport(siteCollectionId.ToString(), reportItem);
                        item["Synchronized"] = true;
                        item["UpdatedBy"] = "RS";
                        item.SystemUpdate();
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
        }

        public void DeleteReport(string data)
        {
            var report = data.Split(':')[1];
            var folder = data.Split(':')[2];
            client.DeleteItem($"/{siteCollectionId.ToString()}{folder}/{report}");
        }

        public void AssignRoleMapping(SPGroupCollection groups, SPList userList)
        {
            lock (siteCollectionId + "_RoleMapping")
            {
                var roles = client.ListRoles("Catalog", "");
                var errors = string.Empty;
                try
                {
                    AssignSsrsRole(groups, userList, roles.GetRole("Content Manager"), "Administrators");
                }
                catch (Exception exception)
                {
                    errors += exception.ToString();
                }
                try
                {
                    AssignSsrsRole(groups, userList, roles.GetRole("Report Builder"), "Administrators");
                }
                catch (Exception exception)
                {
                    errors += exception.ToString();
                }
                try
                {
                    AssignSsrsRole(groups, userList, roles.GetRole("Browser"), "Report Viewers");
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
            loginName = SPClaimProviderManager.Local.DecodeClaim(loginName).Value.Split('\\').Last();
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

        public Subscription[] ListSubscriptions(string itemPathOrSiteURL)
        {
            return client.ListSubscriptions(itemPathOrSiteURL);
        }

        public Extension[] ListExtensions(string extensionType)
        {
            return client.ListExtensions(extensionType);
        }

        public ItemParameter[] GetItemParameters(string reportPath)
        {
            return client.GetItemParameters(reportPath, null, true, null, null);
        }

        public void EnableSubscription(string subscriptionID)
        {
            client.EnableSubscription(subscriptionID);
        }
        public void DisableSubscription(string subscriptionID)
        {
            client.DisableSubscription(subscriptionID);
        }
        public void DeleteSubscription(string subscriptionID)
        {
            client.DeleteSubscription(subscriptionID);
        }
        public CatalogItem[] ListChildren(string itemPath, bool recursive)
        {
            return client.ListChildren(itemPath, recursive);
        }
        public string CreateSubscription(string itemPath, ExtensionSettings extensionSettings, string description,
            string eventType, string matchData, ParameterValue[] parameters)
        {
            return client.CreateSubscription(itemPath, extensionSettings, description, eventType, matchData, parameters);
        }
        public void ChangeSubscriptionOwner(string subscriptionID, string newOwner)
        {
            client.ChangeSubscriptionOwner(subscriptionID, newOwner);
        }
        public SubscriptionProperties GetSubscriptionProperties(string subscriptionID)
        {
            ExtensionSettings extset = null;
            string desc, status, eventtype, matchdata;
            ParameterValue[] reportparams;
            ActiveState acs;

            var owner = client.GetSubscriptionProperties(subscriptionID, out extset, out desc, out acs,
                out status, out eventtype, out matchdata, out reportparams);

            return new SubscriptionProperties()
            {
                Active = acs,
                Description = desc,
                EventType = eventtype,
                DeliverySettings = extset,
                MatchData = matchdata,
                Owner = owner,
                ReportParams = reportparams,
                Status = status
            };
        }
        public void SetSubscriptionProperties(string subscriptionID, ExtensionSettings extensionSettings,
            string description, string eventType, string matchData, ParameterValue[] parameters)
        {
            client.SetSubscriptionProperties(subscriptionID, extensionSettings, description, eventType, matchData, parameters);
        }

        private string GetSSRSRole(string group)
        {
            if (group == "Report Viewers")
                return "Browser";
            else if (group == "Administrators")
                return "Content Managers";
            return string.Empty;
        }

        private void AssignSsrsRole(SPGroupCollection groups, SPList userList, Role role, string spRole)
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
                        AssignRole(role, user.LoginName);
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

        private void AssignRole(Role role, string loginName)
        {
            bool inheritParent;
            var policies = client.GetPolicies($"/{siteCollectionId.ToString()}", out inheritParent).ToList();
            loginName = SPClaimProviderManager.Local.DecodeClaim(loginName).Value;
            var existingRole = policies.SingleOrDefault(x => x.GroupUserName.ToLower() == loginName.ToLower());
            if (existingRole == null)
            {
                policies.Add(new Policy
                {
                    GroupUserName = loginName.Split('\\').Last(),
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

        private void UploadReport(string siteCollectionId, ReportItem report)
        {
            Warning[] warnings;
            if (report.FileName.ToLower().EndsWith(".rdl"))
            {
                if (dataSources == null)
                {
                    dataSources = client.ListChildren($"/{siteCollectionId}", true).Where(x => x.TypeName == "DataSource").ToList();
                }
                var catalogItem = client.CreateCatalogItem("Report", report.FileName, $"/{siteCollectionId}/{report.Folder}", true, report.BinaryData, null, out warnings);
                var reportDatasources = client.GetItemDataSources(catalogItem.Path);
                var itemRefs = new List<ItemReference>();
                foreach (DataSource reportDatasource in reportDatasources)
                {
                    if (reportDatasource.Item.GetType() == typeof(InvalidDataSourceReference))
                    {
                        var existingDatasource = dataSources.Where(x => x.Name == reportDatasource.Name + ".rsds").First();
                        var itemRef = new ItemReference()
                        {
                            Name = reportDatasource.Name,
                            Reference = existingDatasource.Path
                        };
                        itemRefs.Add(itemRef);
                    }
                }
                client.SetItemReferences(catalogItem.Path, itemRefs.ToArray());
            }
            else if (report.FileName.ToLower().EndsWith(".rsds"))
            {
                var doc = new XmlDocument();
                using (var memoryStream = new MemoryStream(report.BinaryData))
                {
                    doc.Load(memoryStream);
                    var definition = new DataSourceDefinition()
                    {
                        CredentialRetrieval = (CredentialRetrievalEnum)Enum.Parse(typeof(CredentialRetrievalEnum), doc.GetStringValue("/m:DataSourceDefinition/m:CredentialRetrieval")),
                        ConnectString = doc.GetStringValue("/m:DataSourceDefinition/m:ConnectString"),
                        Enabled = doc.GetBooleanValue("/m:DataSourceDefinition/m:Enabled"),
                        Extension = doc.GetStringValue("/m:DataSourceDefinition/m:Extension"),
                        ImpersonateUser = doc.GetBooleanValue("/m:DataSourceDefinition/m:ImpersonateUser"),
                        OriginalConnectStringExpressionBased = doc.GetBooleanValue("/m:DataSourceDefinition/m:OriginalConnectStringExpressionBased"),
                        Prompt = doc.GetStringValue("/m:DataSourceDefinition/m:Prompt"),
                        UseOriginalConnectString = doc.GetBooleanValue("/m:DataSourceDefinition/m:UseOriginalConnectString"),
                        WindowsCredentials = doc.GetBooleanValue("/m:DataSourceDefinition/m:WindowsCredentials"),
                        UserName = "",
                        Password = ""
                    };
                    if (!string.IsNullOrEmpty(report.DatasourceCredentials))
                    {
                        var parts = report.DatasourceCredentials.Split(':');
                        definition.UserName = parts[0].Trim();
                        definition.Password = parts[1].Trim();
                    }
                    client.CreateDataSource(report.FileName, $"/{siteCollectionId}/{report.Folder}", true, definition, null);
                }
            }
        }

        private void CreateFoldersIfNotExist(string siteCollectionId, string folder)
        {
            var children = client.ListChildren($"/{siteCollectionId}", true).ToList();
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
                        client.CreateFolder(folders[i], parentFolder, null);
                        children = client.ListChildren($"/{siteCollectionId}", true).ToList();
                    }
                }
            }
        }
    }
}