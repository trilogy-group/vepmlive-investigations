using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SyncSubscriptions.SSRS2010;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    WriteToConsole("Creating SSRS client instances...");
                    var nativeClient = GetSSRSInstance(options.NativeURL, options.NativeUsername, options.NativePassword, options.NativeAuthMode);
                    var integratedClient = GetSSRSInstance(options.IntegratedURL, options.IntegratedUsername, options.IntegratedPassword, options.IntegratedAuthMode);

                    WriteToConsole("Loading Web Application...");
                    var oWebApp = SPWebApplication.Lookup(new Uri(options.WebApplicationURL));

                    WriteToConsole("Syncing SSRS Report Subscriptions...");
                    WriteToConsole(string.Empty);
                    int success = 0, fail = 0;
                    foreach (var oSite in oWebApp.Sites)
                        if (SyncSubscriptions((SPSite)oSite, nativeClient, integratedClient)) success++; else fail++;

                    WriteToConsole(string.Empty);
                    WriteToConsole("**** PROCESS HAS FINISHED ***");
                    WriteToConsole($"Success: {success}", MessageType.Sucess);
                    WriteToConsole($"Fail: {fail}", (fail > 0 ? MessageType.Error : MessageType.Default));                    
                });
            }
            catch (Exception exc)
            {
                WriteToConsole($"ERROR! {exc.Message}");
            }
            finally
            {
                WriteToConsole(string.Empty);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static bool ValidateParameters(Options opt)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(opt.IntegratedAuthMode))
                errors.Add("Authentication method for integrated SSRS server");
            if (string.IsNullOrWhiteSpace(opt.IntegratedPassword))
                errors.Add("Password for integrated SSRS server");
            if (string.IsNullOrWhiteSpace(opt.IntegratedURL))
                errors.Add("URL for integrated SSRS server");
            if (string.IsNullOrWhiteSpace(opt.IntegratedUsername))
                errors.Add("Username for integrated SSRS server");
            if (string.IsNullOrWhiteSpace(opt.NativeAuthMode))
                errors.Add("Authentication method for native SSRS server");
            if (string.IsNullOrWhiteSpace(opt.NativePassword))
                errors.Add("Password for native SSRS server");
            if (string.IsNullOrWhiteSpace(opt.NativeURL))
                errors.Add("URL for native SSRS server");
            if (string.IsNullOrWhiteSpace(opt.NativeUsername))
                errors.Add("Username for native SSRS server");
            if (string.IsNullOrWhiteSpace(opt.WebApplicationURL))
                errors.Add("Web Application URL");

            if (errors.Any())
            {
                errors.ForEach(x => WriteToConsole($"- ERROR: {x} should be informed.", MessageType.Error));
                WriteToConsole(string.Empty);
                WriteToConsole(opt.GetUsage());
            }
            
            return !errors.Any();
        }

        private static bool SyncSubscriptions(SPSite site, ReportingService2010 nativeClient, ReportingService2010 integratedClient)
        {
            try
            {
                var integratedSubscriptions = integratedClient.ListSubscriptions(site.Url);
                var nativeSubscriptions = new List<SSRS2010.Subscription>();

                WriteToConsole($"Site: {site.Url}");
                WriteToConsole($"   - Subsriptions found: {(integratedSubscriptions != null ? integratedSubscriptions.Count() : 0)}");

                if (integratedSubscriptions != null)
                {
                    var reportPath = string.Empty;
                    foreach (var integratedSub in integratedSubscriptions)
                    {
                        var subsProp = GetSubscriptionProperties(integratedClient, integratedSub.SubscriptionID);
                        reportPath = $"/{site.ID.ToString()}{integratedSub.Path.Replace(site.Url, string.Empty)}".Replace("//", "/");
                        nativeSubscriptions = nativeClient.ListSubscriptions(reportPath)?.ToList();
                        var nativesubs = nativeSubscriptions?.Where(x => (!(string.IsNullOrWhiteSpace(x.Description)) && x.Description.ToUpper().Contains(integratedSub.SubscriptionID.ToUpper())));

                        if (nativeSubscriptions == null || nativeSubscriptions.Count() == 0 || !nativesubs.Any())
                        {
                            var createdSubsID = nativeClient.CreateSubscription(reportPath, subsProp.DeliverySettings, $"{subsProp.Description} - {integratedSub.SubscriptionID}",
                                subsProp.EventType, subsProp.MatchData, subsProp.ReportParams);
                            nativeClient.ChangeSubscriptionOwner(createdSubsID, integratedSub.Owner);
                        }
                        else
                            nativeClient.SetSubscriptionProperties(nativesubs.First().SubscriptionID, subsProp.DeliverySettings, nativesubs.First().Description,
                                subsProp.EventType, subsProp.MatchData, subsProp.ReportParams);
                    }
                }

                WriteToConsole($"   - Success!", MessageType.Sucess);
                return true;
            }
            catch (Exception exc)
            {
                WriteToConsole(exc.Message, MessageType.Error);
                return false;
            }
            finally
            {
                WriteToConsole(string.Empty);
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

        private static void WriteToConsole(string message, MessageType type = MessageType.Default)
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
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        private enum MessageType
        {
            Sucess = 1,
            Error = -1,
            Default = 0
        }
    }
}
