using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SharePoint;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class EventAudit
    {
        protected void AddEventHandler(string webUrl, string listName)
        {
            SPList spList = null;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    var spSite = SPContext.Current.Site;
                    {
                        spList = null;
                        var spWeb = spSite.OpenWeb(webUrl);
                        spWeb.AllowUnsafeUpdates = true;
                        try
                        {
                            spList = spWeb.Lists[listName];

                            AddEventHandler(spList, EPMLiveCore.Properties.Resources.ReportingClassName, itemEventTypes.Keys.ToList());

                            if (webUrl.Equals(spSite.RootWeb.Url, StringComparison.InvariantCultureIgnoreCase))
                            {
                                AddEventHandler(spList, EPMLiveReportsAdminLstEvents, fieldEventTypes.Keys.ToList());
                            }
                            spList.Update();
                        }
                        catch (Exception ex)
                        {
                            SystemTrace.WriteLine(ex.ToString());
                        }
                        spWeb.AllowUnsafeUpdates = false;
                    }
                });
            }
            catch (Exception ex)
            {
                SystemTrace.WriteLine(ex.ToString());
            }
        }

        private void AddEventHandler(SPList spList, string reportingClassName, IList<SPEventReceiverType> eventTypes)
        {
            if (spList == null)
            {
                throw new ArgumentNullException(nameof(spList));
            }

            if (eventTypes == null)
            {
                throw new ArgumentNullException(nameof(eventTypes));
            }

            var deletedEvents = GetListEvents(spList,
                EPMLiveCore.Properties.Resources.ReportingAssembly,
                reportingClassName,
                eventTypes);

            foreach (var eventDefinition in deletedEvents)
            {
                eventDefinition.Delete();
            }

            foreach (var eventType in eventTypes)
            {
                spList.EventReceivers.Add(
                    eventType,
                    EPMLiveCore.Properties.Resources.ReportingAssembly,
                    reportingClassName);
            }

            var newEvents = GetListEvents(spList,
                EPMLiveCore.Properties.Resources.ReportingAssembly,
                reportingClassName,
                eventTypes);

            foreach (var eventDefinition in newEvents)
            {
                eventDefinition.SequenceNumber = 11000;
                eventDefinition.Update();
            }
        }
    }
}
