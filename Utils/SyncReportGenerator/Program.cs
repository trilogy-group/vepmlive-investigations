using Microsoft.SharePoint;
using System;
using System.Linq;
using System.Configuration;
using System.IO;
using Microsoft.SharePoint.Administration.Claims;

namespace SyncReportGenerator
{
    public class Program
    {
        private static readonly string fileName = "Report.txt";
        static void Main(string[] args)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            FileStream fs = new FileStream(fileName, FileMode.CreateNew);
            fs.Close();
            var client = new ReportingService2010Extended()
            {
                Url = "http://win-6j09gf4nbp8:8082/ReportServer/ReportService2010.asmx"
            };
            client.LogonUser(ConfigurationManager.AppSettings["rsadminusername"], ConfigurationManager.AppSettings["rsadminpassword"], null);
            var topLevelFolders = client.ListChildren("/", false).ToList();
            using (var rootSite = new SPSite(ConfigurationManager.AppSettings["baseUrl"]))
            {
                var siteCollections = rootSite.WebApplication.Sites;
                foreach (SPSite site in siteCollections)
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        try
                        {
                            LogSuccess($"--------- Report for {site.Url} --------");
                            var reportLibrary = web.Lists["Report Library"] as SPDocumentLibrary;
                            if (!topLevelFolders.Any(x => x.Path == $"/{site.ID}"))
                            {
                                LogError($"Tenant folder does not exists for site with URL '{site.Url}'");
                            }
                            else
                            {
                                LogSuccess($"Tenant folder exists for site with URL '{site.Url}'");
                                ValidateCatalogItems(client, site, reportLibrary);
                                ValidateRole(client, site, web, "Administrators", "Content Manager");
                                ValidateRole(client, site, web, "Administrators", "Report Builder");
                                ValidateRole(client, site, web, "Report Viewers", "Browser");
                            }
                        }
                        catch (Exception exception)
                        {
                            LogError(exception.Message);
                        }
                    }
                }
            }

            Console.Read();
        }

        private static void ValidateRole(ReportingService2010Extended client, SPSite site, SPWeb web, string role, string ssrsRole)
        {
            try
            {
                bool inheritParent;
                var policies = client.GetPolicies($"/{site.ID.ToString()}", out inheritParent).ToList();
                var groups = web.SiteGroups;
                var reportViewers = groups.GetByName(role);
                foreach (SPUser user in reportViewers.Users.OfType<SPUser>().Where(i => i.Name != "System Account"))
                {
                    try
                    {
                        var loginName = SPClaimProviderManager.Local.DecodeClaim(user.LoginName).Value;
                        loginName = loginName.Split('\\').Last();
                        if (!policies.Any(x => x.GroupUserName.ToLower() == loginName.ToLower() && x.Roles.Where(y => y.Name == ssrsRole).Count() == 1))
                        {
                            LogError($"User {loginName} not assigned correct permissions of {ssrsRole}");
                        }
                        else
                        {
                            LogSuccess($"User {loginName} assigned correct permissions of {ssrsRole}");
                        }
                    }
                    catch (Exception exception)
                    {
                        LogError(exception.Message);
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception.Message == "Group cannot be found.")
                {
                    LogError($"Group {role} cannot be found.");
                }
                else
                {
                    LogError(exception.Message);
                }
            }
        }

        private static void ValidateCatalogItems(ReportingService2010Extended client, SPSite site, SPDocumentLibrary reportLibrary)
        {
            var items = reportLibrary.Items;
            var itemsSynced = client.ListChildren($"/{site.ID}", true).ToList();
            foreach (SPListItem item in items)
            {
                try
                {
                    if (!itemsSynced.Any(x => x.Path.Contains($"/{site.ID}/{item.File.Url}")))
                    {
                        LogError($"Item not synced '{site.Url}{item.File.ServerRelativeUrl}'");
                    }
                    else
                    {
                        LogSuccess($"Item synced '{site.Url}{item.File.ServerRelativeUrl}'");
                    }
                }
                catch (Exception exception)
                {
                    LogError(exception.Message);
                }
            }
        }

        private static void Log(string message, string level)
        {
            var content = string.Empty;
            if (level == "Success")
            {
                content = "INFO: ";
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (level == "Error")
            {
                content = "ERROR: ";
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(message);
            File.AppendAllText(fileName, content + message + Environment.NewLine);
            Console.ResetColor();
        }

        private static void LogSuccess(string message)
        {
            Log(message, "Success");
        }

        private static void LogError(string message)
        {
            Log(message, "Error");
        }
    }
}