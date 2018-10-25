using System;
using System.Diagnostics;
using EPMLiveEnterprise.WebSvcEvents;
using EPMLiveEnterprise.WebSvcWssInterop;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EPMLiveEnterprise
{
    class PublisherEventInstaller : SPFeatureReceiver
    {
        private const int SuccessfullyUninstalledEPMLivePublishingEventHandlerCode = 601;
        private const int SuccessfullyStartedInstallOfEPMLiveResourceEventHandlerCode = 610;
        private const int SuccessfullyUninstalledEPMLiveStatusingEventHandlerCode = 611;
        private const int ErrorUninstallingEnterpriseEventHandlerCode = 652;

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            if (!EventLog.SourceExists("EPM Live Feature Activation"))
            {
                EventLog.CreateEventSource("EPM Live Feature Activation", "EPM Live");
            }

            using (var myLog = new EventLog("EPM Live", ".", "EPM Live Feature Activation"))
            {
                myLog.MaximumKilobytes = 32768;

                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    try
                    {
                        var events = new Events();
                        events.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/events.asmx";
                        events.UseDefaultCredentials = true;

                        var dataSet = events.ReadEventHandlerAssociations();

                        Publish(myLog, events, dataSet);
                        Statusing(myLog, events, dataSet);
                        ResourceChanged(myLog, events, dataSet);
                        ResourceAdded(myLog, events, dataSet);
                        ResourceDeleted(myLog, events, dataSet);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                        myLog.WriteEntry("Error Installing Enterprise Event Handler:\r\n " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, 650);
                    }
                });

                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        var wss = new WssInterop();
                        wss.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/wssinterop.asmx";
                        wss.UseDefaultCredentials = true;

                        var dsWss = wss.ReadWssSettings();
                        dsWss.WssAdmin[0].WADMIN_AUTO_ADD_USER_TO_SUBWEB = 0;
                        dsWss.WssAdmin[0].WADMIN_AUTO_CREATE_SUBWEBS = 0;
                        wss.UpdateWssSettings(dsWss);

                        myLog.WriteEntry("Successfully Updated Project Workspace Provisioning Settings", EventLogEntryType.Information, 620);
                    });
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    myLog.WriteEntry("Error Updating Project Workspace Provisioning Settings :\r\n " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, 651);
                }
            }
        }

        private static void Publish(EventLog myLog, Events events, EventHandlersDataSet dataSet)
        {
            if (myLog == null)
            {
                throw new ArgumentNullException(nameof(myLog));
            }

            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            if (dataSet == null)
            {
                throw new ArgumentNullException(nameof(dataSet));
            }

            if (dataSet.EventHandlers.Select("EventId = 53 and name = 'EPMLivePublisher'").Length <= 0)
            {
                var newDataSet = new EventHandlersDataSet();
                newDataSet.EventHandlers.AddEventHandlersRow(new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F5"), "EPMLivePublisher", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.OnPublish", 53, "", 10);
                events.CreateEventHandlerAssociations(newDataSet);
                myLog.WriteEntry("Successfully started install of EPM Live Publishing EventHandler (Project.Published)", EventLogEntryType.Information, SuccessfullyStartedInstallOfEPMLiveResourceEventHandlerCode);
            }
        }

        private static void Statusing(EventLog myLog, Events events, EventHandlersDataSet dataSet)
        {
            if (myLog == null)
            {
                throw new ArgumentNullException(nameof(myLog));
            }

            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            if (dataSet == null)
            {
                throw new ArgumentNullException(nameof(dataSet));
            }

            if (dataSet.EventHandlers.Select("EventId = 133 and name = 'EPMLiveStatusing'").Length <= 0)
            {
                var newDataSet = new EventHandlersDataSet();
                newDataSet.EventHandlers.AddEventHandlersRow(new Guid("8BBBBC25-7E9D-440b-BE1C-78ED667D5D0B"), "EPMLiveStatusing", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.Status", 133, "", 10);
                events.CreateEventHandlerAssociations(newDataSet);
                myLog.WriteEntry("Successfully started install of EPM Live Statusing EventHandler (Statusing.Applied)", EventLogEntryType.Information, SuccessfullyStartedInstallOfEPMLiveResourceEventHandlerCode);
            }
        }

        private static void ResourceChanged(EventLog myLog, Events events, EventHandlersDataSet dataSet)
        {
            if (myLog == null)
            {
                throw new ArgumentNullException(nameof(myLog));
            }

            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            if (dataSet == null)
            {
                throw new ArgumentNullException(nameof(dataSet));
            }

            if (dataSet.EventHandlers.Select("EventId = 95 and name = 'EPMLiveResUpdated'").Length <= 0)
            {
                var newDataSet = new EventHandlersDataSet();
                newDataSet.EventHandlers.AddEventHandlersRow(new Guid("B0C1D09C-F1F6-4a6b-858C-529E22B7688C"), "EPMLiveResUpdated", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.ResourceEvents", 95, "", 10);
                events.CreateEventHandlerAssociations(newDataSet);
                myLog.WriteEntry("Successfully started install of EPM Live Resource EventHandler (Resource.Updated)", EventLogEntryType.Information, SuccessfullyStartedInstallOfEPMLiveResourceEventHandlerCode);
            }
        }

        private static void ResourceAdded(EventLog myLog, Events events, EventHandlersDataSet dataSet)
        {
            if (myLog == null)
            {
                throw new ArgumentNullException(nameof(myLog));
            }

            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            if (dataSet == null)
            {
                throw new ArgumentNullException(nameof(dataSet));
            }

            if (dataSet.EventHandlers.Select("EventId = 89 and name = 'EPMLiveResCreated'").Length <= 0)
            {
                var newDataSet = new EventHandlersDataSet();
                newDataSet.EventHandlers.AddEventHandlersRow(new Guid("286DE0F8-2042-4c8b-A8F7-3E276150CD9C"), "EPMLiveResCreated", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.ResourceEvents", 89, "", 10);
                events.CreateEventHandlerAssociations(newDataSet);
                myLog.WriteEntry("Successfully started install of EPM Live Resource EventHandler (Resource.Created)", EventLogEntryType.Information, SuccessfullyStartedInstallOfEPMLiveResourceEventHandlerCode);
            }
        }

        private static void ResourceDeleted(EventLog myLog, Events events, EventHandlersDataSet dataSet)
        {
            if (myLog == null)
            {
                throw new ArgumentNullException(nameof(myLog));
            }

            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            if (dataSet == null)
            {
                throw new ArgumentNullException(nameof(dataSet));
            }

            if (dataSet.EventHandlers.Select("EventId = 92 and name = 'EPMLiveResDeleting'").Length <= 0)
            {
                var newDataSet = new EventHandlersDataSet();
                newDataSet.EventHandlers.AddEventHandlersRow(new Guid("074BCE6F-CF3B-4a94-BCC4-A262B32AE41E"), "EPMLiveResDeleting", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.ResourceEvents", 92, "", 10);
                events.CreateEventHandlerAssociations(newDataSet);
                myLog.WriteEntry("Successfully started install of EPM Live Resource EventHandler (Resource.Deleting)", EventLogEntryType.Information, SuccessfullyStartedInstallOfEPMLiveResourceEventHandlerCode);
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            using (var myLog = new EventLog("EPM Live", ".", "EPM Live Feature Deactivation"))
            {
                myLog.MaximumKilobytes = 32768;

                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    try
                    {
                        var events = new Events();
                        events.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/events.asmx";
                        events.UseDefaultCredentials = true;

                        try
                        {
                            events.DeleteEventHandlerAssociations(new Guid[] { new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F5") });
                            myLog.WriteEntry("Successfully uninstalled EPM Live Publishing EventHandler (Project.Published)", EventLogEntryType.Information, SuccessfullyUninstalledEPMLivePublishingEventHandlerCode);
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                            myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Project.Published):\r\n " + ex.Message, EventLogEntryType.Error, ErrorUninstallingEnterpriseEventHandlerCode);
                        }

                        try
                        {
                            events.DeleteEventHandlerAssociations(new Guid[] { new Guid("8BBBBC25-7E9D-440b-BE1C-78ED667D5D0B") });
                            myLog.WriteEntry("Successfully uninstalled EPM Live Statusing EventHandler (Statusing.Applied)", EventLogEntryType.Information, SuccessfullyUninstalledEPMLiveStatusingEventHandlerCode);
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                            myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Statusing.Applied):\r\n " + ex.Message, EventLogEntryType.Error, ErrorUninstallingEnterpriseEventHandlerCode);
                        }

                        try
                        {
                            events.DeleteEventHandlerAssociations(new Guid[] { new Guid("B0C1D09C-F1F6-4a6b-858C-529E22B7688C") });
                            myLog.WriteEntry("Successfully uninstalled EPM Live Resource EventHandler (Resource.Updated)", EventLogEntryType.Information, SuccessfullyUninstalledEPMLiveStatusingEventHandlerCode);
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                            myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Resource.Updated):\r\n " + ex.Message, EventLogEntryType.Error, ErrorUninstallingEnterpriseEventHandlerCode);
                        }

                        try
                        {
                            events.DeleteEventHandlerAssociations(new Guid[] { new Guid("286DE0F8-2042-4c8b-A8F7-3E276150CD9C") });
                            myLog.WriteEntry("Successfully uninstalled EPM Live Statusing EventHandler (Resource.Created)", EventLogEntryType.Information, SuccessfullyUninstalledEPMLiveStatusingEventHandlerCode);
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                            myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Resource.Created):\r\n " + ex.Message, EventLogEntryType.Error, ErrorUninstallingEnterpriseEventHandlerCode);
                        }

                        try
                        {
                            events.DeleteEventHandlerAssociations(new Guid[] { new Guid("074BCE6F-CF3B-4a94-BCC4-A262B32AE41E") });
                            myLog.WriteEntry("Successfully uninstalled EPM Live Statusing EventHandler (Resource.Deleting)", EventLogEntryType.Information, SuccessfullyUninstalledEPMLiveStatusingEventHandlerCode);
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex.ToString());
                            myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Resource.Deleted):\r\n " + ex.Message, EventLogEntryType.Error, ErrorUninstallingEnterpriseEventHandlerCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                        myLog.WriteEntry("Error Uninstalling Enterprise Event Handler(s):\r\n " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, ErrorUninstallingEnterpriseEventHandlerCode);
                    }
                });
            }
        }

        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
            SPFarm.Local.Services.GetValue<SPWebService>().ApplyApplicationContentToLocalServer();
        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
            //Not implementing but not throwing an error.
        }
    }
}
