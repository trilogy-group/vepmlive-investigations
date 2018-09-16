using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class EventAudit
    {
        private readonly Dictionary<SPEventReceiverType, bool> itemEventTypes = new Dictionary<SPEventReceiverType, bool>
        {
            [SPEventReceiverType.ItemAdded] = false,
            [SPEventReceiverType.ItemUpdated] = false,
            [SPEventReceiverType.ItemDeleting] = false
        };

        private readonly Dictionary<SPEventReceiverType, bool> fieldEventTypes = new Dictionary<SPEventReceiverType, bool>
        {
            [SPEventReceiverType.ListDeleting] = false,
            [SPEventReceiverType.FieldAdded] = false,
            [SPEventReceiverType.FieldUpdated] = false,
            [SPEventReceiverType.FieldDeleting] = false,
            [SPEventReceiverType.FieldAdding] = false
        };

        private readonly Dictionary<SPEventReceiverType, string> eventTypeCaption = new Dictionary<SPEventReceiverType, string>
        {
            [SPEventReceiverType.ItemAdded] = "ItemAdded",
            [SPEventReceiverType.ItemUpdated] = "ItemUpdated",
            [SPEventReceiverType.ItemDeleting] = "ItemDeleting",
            [SPEventReceiverType.ListDeleting] = "ListDeleting",
            [SPEventReceiverType.FieldAdded] = "FieldAdded",
            [SPEventReceiverType.FieldUpdated] = "FieldUpdated",
            [SPEventReceiverType.FieldDeleting] = "FieldDeleting",
            [SPEventReceiverType.FieldAdding] = "FieldAdding",
        };

        protected void AuditWebs()
        {
            SPList spList = null;

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var spSite = new SPSite(_SiteID))
                {
                    foreach (SPWeb spWeb in spSite.AllWebs)
                    {
                        using (spWeb)
                        {
                            spWeb.AllowUnsafeUpdates = true;
                            spList = null;
                            try
                            {
                                // List may not always be present. IF NOT PRESENT, error will be caught.
                                spList = spWeb.Lists[_sListName];
                            }
                            catch (Exception ex)
                            {
                                SystemTrace.WriteLine(ex.ToString());
                            }

                            if (spList != null)
                            {
                                AuditWebs(spList.EventReceivers, spSite.RootWeb.Url, spWeb.Url, spWeb.ServerRelativeUrl);
                            }
                            else
                            {
                                // Report "List Not Present" error
                                AddAuditRecord("List Not Present.", _sListName, spWeb.ServerRelativeUrl);
                            }
                            spWeb.AllowUnsafeUpdates = false;
                        }
                    }
                }
            });

            if (_dtAuditRecs.Rows.Count > 0)
            {
                grdVwResults.ID = "grdVwResults";
                grdVwResults.RowCreated += grdVwResults_RowCreated;
                grdVwResults.DataSource = _dtAuditRecs;
                grdVwResults.AutoGenerateColumns = false;
                grdVwResults.DataBind();
            }
            else
            {
                var label = new Label
                {
                    Text = "All webs up to date."
                };
                grdVwResults.Visible = false;
                var masterPage = Master;
                var placeHolder = (ContentPlaceHolder)masterPage.FindControl(PlaceHolderId);
                placeHolder.Controls.Add(label);
            }
        }

        private void AuditWebs(
            SPEventReceiverDefinitionCollection eventReceivers,
            string siteRootWebUrl,
            string webUrl,
            string serverRelativeUrl)
        {
            if (eventReceivers == null)
            {
                throw new ArgumentNullException(nameof(eventReceivers));
            }
            foreach (SPEventReceiverDefinition eventDefinition in eventReceivers)
            {
                UpdateEvents(itemEventTypes, eventDefinition, EPMLiveCore.Properties.Resources.ReportingClassName);

                // Check for top level rootweb. IF TRUE, THEN check for listdeleting and columndeleting events
                if (webUrl.Equals(siteRootWebUrl, StringComparison.InvariantCultureIgnoreCase))
                {
                    UpdateEvents(fieldEventTypes, eventDefinition, EPMLiveReportsAdminLstEvents);
                }
            }

            foreach (var eventType in itemEventTypes.Keys)
            {
                if (!itemEventTypes[eventType])
                {
                    AddAuditRecord(eventTypeCaption[eventType], _sListName, serverRelativeUrl);
                }
            }

            // Check for top level rootweb. 
            if (webUrl.Equals(siteRootWebUrl, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var eventType in fieldEventTypes.Keys)
                {
                    if (!fieldEventTypes[eventType])
                    {
                        AddAuditRecord(eventTypeCaption[eventType], _sListName, serverRelativeUrl);
                    }
                }
            }
        }

        private static void UpdateEvents(
            Dictionary<SPEventReceiverType, bool> eventTypes,
            SPEventReceiverDefinition eventDefinition,
            string className)
        {
            if (eventTypes == null)
            {
                throw new ArgumentNullException(nameof(eventTypes));
            }
            if (eventDefinition == null)
            {
                throw new ArgumentNullException(nameof(eventDefinition));
            }

            var keys = eventTypes.Keys.ToList();
            for (var i = 0; i < keys.Count; i++)
            {
                var eventType = keys[i];
                eventTypes[eventType] =
                        eventDefinition.Type == eventType &&
                        eventDefinition.Class.Equals(className, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        protected void AddAuditRecord(string message, string listName, string webUrl)
        {
            var row = _dtAuditRecs.NewRow();
            row[WebId] = webUrl;
            row[ListNameColumn] = listName;
            row[MessageColumn] = message;
            _dtAuditRecs.Rows.Add(row);
        }
    }
}