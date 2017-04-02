using System;
using Microsoft.SharePoint;

namespace EPMLiveAccountManagement
{
    class PSEventsInstaller : SPFeatureReceiver
    {
        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = (SPSite)properties.Feature.Parent;

            WebSvcEvents.Events events = new WebSvcEvents.Events();
            events.Url = site.Url + "/_vti_bin/psi/events.asmx";
            events.UseDefaultCredentials = true;
            
            WebSvcEvents.EventHandlersDataSet ds = events.ReadEventHandlerAssociations();

            try
            {
                if (ds.EventHandlers.Select("EventId = 90 and name = 'WEResourceAdding'").Length <= 0)
                {
                    WebSvcEvents.EventHandlersDataSet newDs = new WebSvcEvents.EventHandlersDataSet();
                    newDs.EventHandlers.AddEventHandlersRow(new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F6"), "WEResourceAdding", "EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveAccountManagement.ProjectServerAccountEvents", 90, "", 10);
                    events.CreateEventHandlerAssociations(newDs);
                }

                if (ds.EventHandlers.Select("EventId = 96 and name = 'WEResourceChanging'").Length <= 0)
                {
                    WebSvcEvents.EventHandlersDataSet newDs = new WebSvcEvents.EventHandlersDataSet();
                    newDs.EventHandlers.AddEventHandlersRow(new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F6"), "WEResourceChanging", "EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveAccountManagement.ProjectServerAccountEvents", 96, "", 10);
                    events.CreateEventHandlerAssociations(newDs);
                }

                if (ds.EventHandlers.Select("EventId = 92 and name = 'WEResourceDeleting'").Length <= 0)
                {
                    WebSvcEvents.EventHandlersDataSet newDs = new WebSvcEvents.EventHandlersDataSet();
                    newDs.EventHandlers.AddEventHandlersRow(new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F8"), "WEResourceDeleting", "EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveAccountManagement.ProjectServerAccountEvents", 92, "", 9);
                    events.CreateEventHandlerAssociations(newDs);
                }
            }
            catch { }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite site = (SPSite)properties.Feature.Parent;

            WebSvcEvents.Events events = new WebSvcEvents.Events();
            events.Url = site.Url + "/_vti_bin/psi/events.asmx";
            events.UseDefaultCredentials = true;
            return;
            try
            {
                events.DeleteEventHandlerAssociations(new Guid[] { new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F6") });
            }
            catch { }

            try
            {
                events.DeleteEventHandlerAssociations(new Guid[] { new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F7") });
            }
            catch { }

            try
            {
                events.DeleteEventHandlerAssociations(new Guid[] { new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F8") });
            }
            catch { }


        }
    }
}
