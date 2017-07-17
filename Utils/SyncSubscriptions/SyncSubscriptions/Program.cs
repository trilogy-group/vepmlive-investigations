using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SyncSubscriptions.SSRS2010;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;

namespace SyncSubscriptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WriteToConsole("Starting...");

                var options = new Options();
                if (!CommandLine.Parser.Default.ParseArguments(args, options) || !ValidateParameters(options)) return;

                var result = new BashResult();
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    switch (options.Mode)
                    {
                        case "B":
                            var consoleKey = new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false);
                            while (consoleKey.Key != ConsoleKey.Y && consoleKey.Key != ConsoleKey.N)
                            {
                                WriteToConsole();
                                WriteToConsole("Are you sure you want to run this tool as backup mode? This operation will delete every files from Backup folder. (Y) yes, (N) no: ",
                                    MessageType.Warning, false);
                                consoleKey = Console.ReadKey();
                                WriteToConsole();
                                WriteToConsole();

                                if (consoleKey.Key == ConsoleKey.Y)
                                    result = RunBackupMode(options);
                            }
                            break;
                        case "R":
                            result = RunRestoreMode(options);
                            break;
                        default:
                            WriteToConsole("Running mode is not valid. Value should be B or R.", MessageType.Error);
                            break;
                    }

                    WriteToConsole();
                    WriteToConsole("**** PROCESS HAS FINISHED ***");
                    WriteToConsole($"Success: {result.Success}", MessageType.Sucess);
                    WriteToConsole($"Fail: {result.Errros}", (result.Errros > 0 ? MessageType.Error : MessageType.Default));                    
                });
            }
            catch (Exception exc)
            {
                WriteToConsole($"ERROR! {exc.Message}");
            }
            finally
            {
                WriteToConsole();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static BashResult RunRestoreMode(Options options)
        {
            WriteToConsole("Creating SSRS client instance (native SSRS server)...");
            var nativeClient = GetSSRSInstance(options.URL, options.Username, options.Password, options.AuthMode);
            var result = new BashResult();

            WriteToConsole("Reading backup files...");
            new DirectoryInfo(options.BackupPath).GetFiles()?.ToList().ForEach(file => 
            {
                WriteToConsole();
                WriteToConsole($"File: {file.Name}");                
                var subsList = XmlUtil.ReadFromXmlFile<List<SubscriptionProperties>>(file.FullName);
                WriteToConsole($"Site URL: {((subsList != null && subsList.Any()) ? subsList.First().SitePath : string.Empty)}");

                WriteToConsole($"   - Subscriptions found: {(subsList != null ? subsList.Count() : 0)}");

                var reportPath = string.Empty;
                var nativeSubscriptions = new List<SSRS2010.Subscription>();
                foreach (var integratedSub in subsList)
                    if (RestoreSubscription(integratedSub, file, nativeClient)) result.Success++; else result.Errros++;
            });

            return result;
        }

        private static bool RestoreSubscription(SubscriptionProperties integratedSub, FileInfo file, ReportingService2010 nativeClient)
        {
            try
            {
                var reportPath = $"/{Path.GetFileNameWithoutExtension(file.FullName)}{integratedSub.Path.Replace(integratedSub.SitePath, "")}".Replace("//", "/");
                var nativeSubscriptions = nativeClient.ListSubscriptions(reportPath)?.ToList();
                var nativesubs = nativeSubscriptions?.Where(x => (!(string.IsNullOrWhiteSpace(x.Description)) && x.Description.ToUpper().Contains(integratedSub.SubscriptionID.ToUpper())));

                if (nativeSubscriptions == null || nativeSubscriptions.Count() == 0 || !nativesubs.Any())
                {
                    var createdSubsID = nativeClient.CreateSubscription(reportPath, integratedSub.DeliverySettings, $"{integratedSub.Description} - {integratedSub.SubscriptionID}",
                        integratedSub.EventType, integratedSub.MatchData, integratedSub.ReportParams);
                    nativeClient.ChangeSubscriptionOwner(createdSubsID, integratedSub.Owner);

                    WriteToConsole($"     - ID: {createdSubsID} -> added!");
                }
                else
                {
                    nativeClient.SetSubscriptionProperties(nativesubs.First().SubscriptionID, integratedSub.DeliverySettings, nativesubs.First().Description,
                        integratedSub.EventType, integratedSub.MatchData, integratedSub.ReportParams);
                    WriteToConsole($"     - ID: {nativesubs.First().SubscriptionID} -> updated!");
                }

                return true;
            }
            catch (Exception exc)
            {
                WriteToConsole(exc.Message, MessageType.Error);
                return false;
            }
        }

        private static bool ValidateParameters(Options opt)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(opt.Mode))
                errors.Add("Running mode");
            if (string.IsNullOrWhiteSpace(opt.AuthMode))
                errors.Add("Authentication method for SSRS server");
            if (string.IsNullOrWhiteSpace(opt.Password))
                errors.Add("Password for SSRS server");
            if (string.IsNullOrWhiteSpace(opt.URL))
                errors.Add("URL for SSRS server");
            if (string.IsNullOrWhiteSpace(opt.Username))
                errors.Add("Username for SSRS server");
            if (opt.Mode == "B" && string.IsNullOrWhiteSpace(opt.WebApplicationURL))
                errors.Add("Web Application URL");
            if (string.IsNullOrWhiteSpace(opt.BackupPath))
            {
                var defaultPath = $"{Directory.GetCurrentDirectory()}\\Backup";
                opt.BackupPath = defaultPath;
            }

            if (!Directory.Exists(opt.BackupPath))
            {
                if (opt.Mode == "B")
                {
                    Directory.CreateDirectory(opt.BackupPath);
                    WriteToConsole($"Folliwng backup backup was created, as it was not found: {opt.BackupPath}", MessageType.Warning);
                }
                else if (opt.Mode == "R" && !Directory.Exists(opt.BackupPath))
                    errors.Add("Backup path");
            }

            if (errors.Any())
            {
                errors.ForEach(x => WriteToConsole($"- ERROR: {x} is either invalid or not informed.", MessageType.Error));
                WriteToConsole();
                WriteToConsole(opt.GetUsage());
            }
            
            return !errors.Any();
        }

        private static BashResult RunBackupMode(Options options)
        {
            WriteToConsole("Cleaning backup folder...");
            new DirectoryInfo(options.BackupPath).GetFiles()?.ToList().ForEach(x => x.Delete());

            WriteToConsole("Creating SSRS client instances (integrated SSRS server)...");
            var integratedClient = GetSSRSInstance(options.URL, options.Username, options.Password, options.AuthMode);

            WriteToConsole("Loading Web Application...");
            var oWebApp = SPWebApplication.Lookup(new Uri(options.WebApplicationURL));

            WriteToConsole("Loading and saving backup of current subscriptions from SSRS integrated server...");
            var result = new BashResult();
            foreach (var oSite in oWebApp.Sites)
                if (ExecuteIntegratedbackup((SPSite)oSite, integratedClient, options)) result.Success++; else result.Errros++;

            return result;
        }

        private static bool ExecuteIntegratedbackup(SPSite site, ReportingService2010 integratedClient, Options options)
        {
            try
            {
                var integratedSubscriptions = integratedClient.ListSubscriptions(site.Url);
                WriteToConsole();
                WriteToConsole($"Site: {site.Url}");
                WriteToConsole($"   - Subscriptions found: {(integratedSubscriptions != null ? integratedSubscriptions.Count() : 0)}");

                var subsList = new List<SubscriptionProperties>();
                SubscriptionProperties subsItem = null;
                foreach (var integratedSub in integratedSubscriptions)
                {
                    subsItem = new SubscriptionProperties(integratedSub);
                    var subsProp = GetSubscriptionProperties(integratedClient, integratedSub.SubscriptionID);
                    subsItem.ReportParams = subsProp.ReportParams;
                    subsItem.MatchData = subsProp.MatchData;
                    subsItem.SitePath = site.Url;

                    subsList.Add(subsItem);

                    WriteToConsole($"     - ID: {integratedSub.SubscriptionID}");
                }

                if (subsList.Any())
                {
                    var fileName = $"{options.BackupPath}\\{ site.ID}.xml";
                    WriteToConsole("   - Saving backup file...");
                    XmlUtil.WriteToXmlFile<List<SubscriptionProperties>>(fileName, subsList);
                    WriteToConsole($"   - Success! ", MessageType.Sucess, false);
                    WriteToConsole($"Backup file created: {Path.GetFileName(fileName)}", MessageType.Default);
                    WriteToConsole();
                }

                return true;
            }
            catch (Exception exc)
            {
                WriteToConsole(exc.Message, MessageType.Error);
                return false;
            }
        }
        
        private static SubscriptionProperties GetSubscriptionProperties(ReportingService2010 client, string susbID)
        {
            ExtensionSettings extset = null;
            string desc, status, eventtype, matchdata;
            ParameterValue[] reportparams;
            ActiveState acs;

            var owner = client.GetSubscriptionProperties(susbID, out extset, out desc, out acs,
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

        private static ReportingService2010 GetSSRSInstance(string url, string username, string password, string authMode)
        {
            var client = new ReportingService2010()
            {
                Url = url
            };

            switch (authMode)
            {
                case "W":
                    client.Credentials = new NetworkCredential(username, password);
                    break;
                case "F":
                    client.LogonUser(username, password, null);
                    break;
            }
            
            return client;
        }

        private static void WriteToConsole(string message = "", MessageType type = MessageType.Default, bool breakLine = true)
        {
            Console.ResetColor();

            switch (type)
            {
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case MessageType.Sucess:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            if (breakLine) Console.WriteLine(message);
            else Console.Write(message);

            Console.ResetColor();
        }
        
        private enum MessageType
        {
            Sucess = 1,
            Error = -1,
            Default = 0,
            Warning = 2
        }

        private class BashResult
        {
            public int Success { get; set; }
            public int Errros { get; set; }
        }
    }
}
