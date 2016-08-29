using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using System.IO;
using System.Diagnostics;
using Microsoft.SharePoint.Administration;

namespace EPMLiveEnterprise
{
    class PublisherEventInstaller : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            if (!EventLog.SourceExists("EPM Live Feature Activation"))
                EventLog.CreateEventSource("EPM Live Feature Activation", "EPM Live");

            EventLog myLog = new EventLog("EPM Live", ".", "EPM Live Feature Activation");
            myLog.MaximumKilobytes = 32768;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    WebSvcEvents.Events events = new WebSvcEvents.Events();
                    events.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/events.asmx";
                    events.UseDefaultCredentials = true;

                    WebSvcEvents.EventHandlersDataSet ds = events.ReadEventHandlerAssociations();

                    //========================Publish=========================
                    if (ds.EventHandlers.Select("EventId = 53 and name = 'EPMLivePublisher'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new EPMLiveEnterprise.WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F5"), "EPMLivePublisher", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.OnPublish", 53, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Publishing EventHandler (Project.Published)", EventLogEntryType.Information, 610);
                    }
                    //========================Statusing=========================
                    if (ds.EventHandlers.Select("EventId = 133 and name = 'EPMLiveStatusing'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new EPMLiveEnterprise.WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("8BBBBC25-7E9D-440b-BE1C-78ED667D5D0B"), "EPMLiveStatusing", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.Status", 133, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Statusing EventHandler (Statusing.Applied)", EventLogEntryType.Information, 610);
                    }
                    //========================Resource Changed=========================
                    if (ds.EventHandlers.Select("EventId = 95 and name = 'EPMLiveResUpdated'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new EPMLiveEnterprise.WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("B0C1D09C-F1F6-4a6b-858C-529E22B7688C"), "EPMLiveResUpdated", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.ResourceEvents", 95, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Resource EventHandler (Resource.Updated)", EventLogEntryType.Information, 610);
                    }
                    //========================Resource Added=========================
                    if (ds.EventHandlers.Select("EventId = 89 and name = 'EPMLiveResCreated'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("286DE0F8-2042-4c8b-A8F7-3E276150CD9C"), "EPMLiveResCreated", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.ResourceEvents", 89, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Resource EventHandler (Resource.Created)", EventLogEntryType.Information, 610);
                    }
                    ////========================Resource Deleted=========================
                    if (ds.EventHandlers.Select("EventId = 92 and name = 'EPMLiveResDeleting'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("074BCE6F-CF3B-4a94-BCC4-A262B32AE41E"), "EPMLiveResDeleting", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.ResourceEvents", 92, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Resource EventHandler (Resource.Deleting)", EventLogEntryType.Information, 610);
                    }
                }
                catch (Exception ex)
                {
                    myLog.WriteEntry("Error Installing Enterprise Event Handler:\r\n " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, 650);
                }
            });

            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    WebSvcWssInterop.WssInterop wss = new WebSvcWssInterop.WssInterop();
                    wss.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/wssinterop.asmx";
                    wss.UseDefaultCredentials = true;

                    WebSvcWssInterop.WssSettingsDataSet dsWss = wss.ReadWssSettings();
                    dsWss.WssAdmin[0].WADMIN_AUTO_ADD_USER_TO_SUBWEB = 0;
                    dsWss.WssAdmin[0].WADMIN_AUTO_CREATE_SUBWEBS = 0;
                    wss.UpdateWssSettings(dsWss);

                    myLog.WriteEntry("Successfully Updated Project Workspace Provisioning Settings", EventLogEntryType.Information, 620);
                });
            }
            catch (Exception ex)
            {
                myLog.WriteEntry("Error Updating Project Workspace Provisioning Settings :\r\n " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, 651);
            }

            myLog.Close();
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            EventLog myLog = new EventLog("EPM Live", ".", "EPM Live Feature Deactivation");
            myLog.MaximumKilobytes = 32768;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    WebSvcEvents.Events events = new EPMLiveEnterprise.WebSvcEvents.Events();
                    events.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/events.asmx";
                    events.UseDefaultCredentials = true;

                    try
                    {
                        events.DeleteEventHandlerAssociations(new Guid[] { new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F5") });
                        myLog.WriteEntry("Successfully uninstalled EPM Live Publishing EventHandler (Project.Published)", EventLogEntryType.Information, 601);
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Project.Published):\r\n " + ex.Message, EventLogEntryType.Error, 652);
                    }

                    try
                    {
                        events.DeleteEventHandlerAssociations(new Guid[] { new Guid("8BBBBC25-7E9D-440b-BE1C-78ED667D5D0B") });
                        myLog.WriteEntry("Successfully uninstalled EPM Live Statusing EventHandler (Statusing.Applied)", EventLogEntryType.Information, 611);
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Statusing.Applied):\r\n " + ex.Message, EventLogEntryType.Error, 652);
                    }

                    try
                    {
                        events.DeleteEventHandlerAssociations(new Guid[] { new Guid("B0C1D09C-F1F6-4a6b-858C-529E22B7688C") });
                        myLog.WriteEntry("Successfully uninstalled EPM Live Resource EventHandler (Resource.Updated)", EventLogEntryType.Information, 611);
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Resource.Updated):\r\n " + ex.Message, EventLogEntryType.Error, 652);
                    }

                    try
                    {
                        events.DeleteEventHandlerAssociations(new Guid[] { new Guid("286DE0F8-2042-4c8b-A8F7-3E276150CD9C") });
                        myLog.WriteEntry("Successfully uninstalled EPM Live Statusing EventHandler (Resource.Created)", EventLogEntryType.Information, 611);
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Resource.Created):\r\n " + ex.Message, EventLogEntryType.Error, 652);
                    }

                    try
                    {
                        events.DeleteEventHandlerAssociations(new Guid[] { new Guid("074BCE6F-CF3B-4a94-BCC4-A262B32AE41E") });
                        myLog.WriteEntry("Successfully uninstalled EPM Live Statusing EventHandler (Resource.Deleting)", EventLogEntryType.Information, 611);
                    }
                    catch (Exception ex)
                    {
                        myLog.WriteEntry("Error Uninstalling Enterprise Event Handler (Resource.Deleted):\r\n " + ex.Message, EventLogEntryType.Error, 652);
                    }
                }
                catch (Exception ex)
                {
                    myLog.WriteEntry("Error Uninstalling Enterprise Event Handler(s):\r\n " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, 652);
                }
            });
            myLog.Close();
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
