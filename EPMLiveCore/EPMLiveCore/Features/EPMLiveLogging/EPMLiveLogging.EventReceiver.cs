using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace EPMLiveCore.Features.EPMLiveLogging
{

    [Guid("77933abc-9697-4979-9b7b-0b0a84283a92")]
    public class EPMLiveLoggingEventReceiver : SPFeatureReceiver
    {
        const string EventLogApplicationRegistryKeyPath = @"SYSTEM\CurrentControlSet\services\eventlog\Application";

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            RegisterLoggingService(properties);
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            UnRegisterLoggingService(properties);
        }

        private void RegisterLoggingService(SPFeatureReceiverProperties properties)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                SPFarm farm = properties.Definition.Farm;

                if (farm != null)
                {
                    LoggingService service = LoggingService.Local;

                    if (service == null)
                    {
                        service = new LoggingService();
                        service.Update();

                        if (service.Status != SPObjectStatus.Online)
                            service.Provision();
                    }
                    foreach (SPServer server in farm.Servers)
                    {
                        RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, server.Address);
                        RegisterKey(baseKey, LoggingService.Area.EPMLiveCore);
                        RegisterKey(baseKey, LoggingService.Area.EPMLiveWebParts);
                        RegisterKey(baseKey, LoggingService.Area.EPMLiveWorkPlanner);
                        RegisterKey(baseKey, LoggingService.Area.EPMLivePortfolioEngineCore);
                        RegisterKey(baseKey, LoggingService.Area.EPMLiveReporting);
                        RegisterKey(baseKey, LoggingService.Area.EPMLiveProjectServer);
                        RegisterKey(baseKey, LoggingService.Area.EPMLiveTimesheets);
                        RegisterKey(baseKey, LoggingService.Area.EPMLiveIntegrationService);
                    }
                }
            });
        }

        private void RegisterKey(RegistryKey baseKey, string key)
        {
            if (baseKey != null)
            {
                RegistryKey eventLogKey = baseKey.OpenSubKey(EventLogApplicationRegistryKeyPath, true);
                if (eventLogKey != null)
                {
                    RegistryKey loggingServiceKey = eventLogKey.OpenSubKey(key);
                    if (loggingServiceKey == null)
                    {
                        loggingServiceKey = eventLogKey.CreateSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree);
                        loggingServiceKey.SetValue("EventMessageFile", @"C:\Windows\Microsoft.NET\Framework\v2.0.50727\EventLogMessages.dll", RegistryValueKind.String);
                    }
                }
            }
        }

        private void UnRegisterLoggingService(SPFeatureReceiverProperties properties)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                SPFarm farm = properties.Definition.Farm;

                if (farm != null)
                {
                    LoggingService service = LoggingService.Local;

                    if (service != null)
                        service.Delete();

                    foreach (SPServer server in farm.Servers)
                    {
                        RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, server.Address);
                        DeRegisterKey(baseKey, LoggingService.Area.EPMLiveCore);
                        DeRegisterKey(baseKey, LoggingService.Area.EPMLiveWebParts);
                        DeRegisterKey(baseKey, LoggingService.Area.EPMLiveWorkPlanner);
                        DeRegisterKey(baseKey, LoggingService.Area.EPMLivePortfolioEngineCore);
                        DeRegisterKey(baseKey, LoggingService.Area.EPMLiveReporting);
                        DeRegisterKey(baseKey, LoggingService.Area.EPMLiveProjectServer);
                        DeRegisterKey(baseKey, LoggingService.Area.EPMLiveTimesheets);
                        DeRegisterKey(baseKey, LoggingService.Area.EPMLiveIntegrationService);
                    }
                }
            });
        }

        private void DeRegisterKey(RegistryKey baseKey, string key)
        {
            if (baseKey != null)
            {
                RegistryKey eventLogKey = baseKey.OpenSubKey(EventLogApplicationRegistryKeyPath, true);
                if (eventLogKey != null)
                {
                    RegistryKey loggingServiceKey = eventLogKey.OpenSubKey(key);
                    if (loggingServiceKey == null)
                    {
                        eventLogKey.DeleteSubKey(key);
                    }
                }
            }
        }

    }
}
