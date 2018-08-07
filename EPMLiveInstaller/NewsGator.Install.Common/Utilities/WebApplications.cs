using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Resources;
using Microsoft.SharePoint.Utilities;
using System.Management;
using NewsGator.Install.Common.Output;
using System;
using System.Collections.Generic;
using System.DirectoryServices;

namespace NewsGator.Install.Common.Utilities
{
    public static class WebApplications
    {
        private static string WMIAppPoolPathFormat = @"IIS://{0}/W3SVC/AppPools/{1}";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "NewsGator.Install.Common.Output.OutputQueue.Add(System.String)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static OutputQueue EnsureApplicationPools()
        {
            var output = new OutputQueue();

            Parallel.ForEach(LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)),
                server =>
                {
                    if (SPWebService.ContentService.Instances.Any(p => p.Server.Id == server.Id) || SPWebService.AdministrationService.Instances.Any(p => p.Server.Id == server.Id))
                    {
                        var applicationPoolNames = new List<string>();

                        if (SPWebService.ContentService.Instances.Any(p => p.Server.Id == server.Id))
                            applicationPoolNames.AddRange(SPWebService.ContentService.WebApplications.Select(p => p.ApplicationPool.Name).Distinct());

                        if (SPWebService.AdministrationService.Instances.Any(p => p.Server.Id == server.Id))
                            applicationPoolNames.AddRange(SPWebService.AdministrationService.WebApplications.Select(p => p.ApplicationPool.Name).Distinct());

                        var applicationPoolPaths = new List<string>();

                        var serverName = server.Address;
                        foreach (var appPoolName in applicationPoolNames)
                            applicationPoolPaths.Add(string.Format(CultureInfo.InvariantCulture, WMIAppPoolPathFormat, serverName, appPoolName));

                        output.Add(string.Format(CultureInfo.InvariantCulture, "Stopping IIS Application Pools: {0}", serverName));
                        foreach (var appPoolPath in applicationPoolPaths)
                        {
                            try
                            {
                                output.Add(string.Format(CultureInfo.InvariantCulture, "Checking IIS Application Pool Status: {0}", appPoolPath));
                                using (var entry = new DirectoryEntry(appPoolPath))
                                {
                                    var status = (int)entry.InvokeGet("AppPoolState");
                                    if (status == 2)
                                    {
                                        output.Add(string.Format(CultureInfo.InvariantCulture, "Stopping IIS Application Pool: {0}", appPoolPath));
                                        entry.Invoke("Stop", null);
                                    }
                                    else if (status == 4)
                                    {
                                        output.Add(string.Format(CultureInfo.InvariantCulture, "IIS Application Pool Already Stopped: {0}", appPoolPath));
                                    }
                                    else
                                    {
                                        output.Add(string.Format(CultureInfo.InvariantCulture, "Unknown State for IIS Application Pool: {0}", appPoolPath));
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                if (exception.Message.IndexOf("The system cannot find the path specified", StringComparison.OrdinalIgnoreCase) == -1)
                                    output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
                            }
                        }

                        output.Add(string.Format(CultureInfo.InvariantCulture, "Starting IIS Application Pools: {0}", serverName));
                        foreach (var appPoolPath in applicationPoolPaths)
                        {
                            try
                            {
                                output.Add(string.Format(CultureInfo.InvariantCulture, "Checking IIS Application Pool Status: {0}", appPoolPath));
                                using (var entry = new DirectoryEntry(appPoolPath))
                                {
                                    var status = (int)entry.InvokeGet("AppPoolState");
                                    if (status == 4)
                                    {
                                        output.Add(string.Format(CultureInfo.InvariantCulture, "Starting IIS Application Pool: {0}", appPoolPath));
                                        entry.Invoke("Start", null);
                                    }
                                    else if (status == 2)
                                    {
                                        output.Add(string.Format(CultureInfo.InvariantCulture, "IIS Application Pool Already Started: {0}", appPoolPath));
                                    }
                                    else
                                    {
                                        output.Add(string.Format(CultureInfo.InvariantCulture, "Unknown State for IIS Application Pool: {0}", appPoolPath));
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                if (exception.Message.IndexOf("The system cannot find the path specified", StringComparison.OrdinalIgnoreCase) == -1)
                                    output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
                            }
                        }
                    }
                });

            return output;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static OutputQueue CopyApplicationBinContent(int timeOut)
        {
            var output = new OutputQueue();

            Parallel.ForEach(LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)),
                server =>
                {
                    if (SPWebService.ContentService.Instances.Any(p => p.Server.Id == server.Id) || SPWebService.AdministrationService.Instances.Any(p => p.Server.Id == server.Id))
                    {
                        var command = string.Format(CultureInfo.InvariantCulture, @"{0} -o copyappbincontent", SPUtility.GetGenericSetupPath(@"bin\stsadm.exe"));

                        output.Add(string.Format(CultureInfo.CurrentUICulture, UserDisplay.RunningCommandOn, command, server.Address));

                        try
                        {
                            var processWMI = new Threading.ProcessWMI();
                            processWMI.ExecuteRemoteProcessWMI(server.Address, command, timeOut);
                        }
                        catch (Exception exception)
                        {
                            output.Add(string.Format(CultureInfo.CurrentUICulture, Exceptions.ExceptionRunningCommandOn, command, server.Address, exception.Message), OutputType.Error, exception.ToString(), exception);                            
                        }
                    }
                });

            return output;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        public static Collection<SPWebApplication> GetWebApplications()
        {
            var webApplications = new Collection<SPWebApplication>();
            webApplications.AddRange(SPWebService.ContentService.WebApplications);
            return webApplications;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        public static Collection<string> GetWebApplicationUrls()
        {
            var webApplications = new Collection<string>();
            webApplications.AddRange(GetWebApplications().Select(p => p.GetResponseUri(SPUrlZone.Default).AbsoluteUri));
            return webApplications;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static Collection<string> IisGetAllWebAppFolders()
        {
            var folders = new Collection<string>();

            var serverAddresses = LocalFarm.Get().Servers.Where(server => Server.ValidSPServerRole(server.Role) && (SPWebService.ContentService.Instances.Any(p => p.Server.Id == server.Id) || SPWebService.AdministrationService.Instances.Any(p => p.Server.Id == server.Id))).Select(server => server.Address).ToArray();

            foreach (var webApp in LocalFarm.Get().Services.OfType<SPWebService>().SelectMany(ws => ws.WebApplications))
                foreach (SPUrlZone zone in webApp.IisSettings.Keys)
                    foreach (var m in serverAddresses.Select(a => Path.Combine(string.Format(CultureInfo.InvariantCulture, "\\\\{0}", a), webApp.IisSettings[zone].Path.ToString().Replace(':', '$'))))
                        folders.Add(m);

            return folders;
        }

        public static void EnableWebApplications()
        {
            foreach (var file in IisGetAllWebAppFolders().Select(path => new DirectoryInfo(path)).Where(path => path.Exists).SelectMany(path => path.GetFiles("app_offline.htm")))
                file.Delete();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static void DisableWebApplications(string literalPath)
        {
            string offlineFileContents;

            if (File.Exists(Path.Combine(literalPath, "app_offline.htm")))
            {
                offlineFileContents = File.ReadAllText(Path.Combine(literalPath, "app_offline.htm"));
            }
            else
            {
                offlineFileContents =
                    string.Format(CultureInfo.CurrentCulture, @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
                                      <html><head><title>NewsGator Social Sites</title></head><body><div style=""text-align:center;font-family:verdana;font-size:10;color:#999;margin-top:100px;"">
                                        {0}
                                        <div style=""padding-top:300px; font-size:9; color:#ccc"">{1}</div>
                                        <!--{2}-->
                                        </div></body></html>",
                                  UserDisplay.SocialSitesIsOfflineMessage, UserDisplay.SocialSitesIsOfflineMessageHowToFix,
                                  new string('-', 512));
            }

            foreach (var path in IisGetAllWebAppFolders().Where(path => Directory.Exists(path)))
                using (var streamWriter = File.CreateText(Path.Combine(path, "app_offline.htm")))
                {
                    streamWriter.Write(offlineFileContents);
                    streamWriter.Flush();
                }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings")]
        public static string GetWebApplicationZoneUrl(SPWebApplication webApplication, SPUrlZone urlZone = SPUrlZone.Default)
        {
            if (webApplication == null)
                return string.Empty;

            try
            {
                return webApplication.GetResponseUri(urlZone).AbsoluteUri;
            }
            catch
            {
                return string.Empty;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static string GetWebApplicationName(SPWebApplication webApplication)
        {
            if (webApplication == null)
                return string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(webApplication.DisplayName))
                    return webApplication.DisplayName;
                else if (!string.IsNullOrEmpty(webApplication.Name))
                    return webApplication.Name;
                else
                    return GetWebApplicationZoneUrl(webApplication);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
