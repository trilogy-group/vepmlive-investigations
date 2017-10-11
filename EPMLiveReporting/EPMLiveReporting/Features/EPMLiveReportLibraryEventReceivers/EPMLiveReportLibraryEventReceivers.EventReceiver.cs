using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Reflection;

namespace EPMLiveReportsAdmin.Features.EPMLiveReportLibraryEventReceivers
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("9b59ae60-62a5-402f-94c0-bdc16cc96465")]
    public class EPMLiveReportLibraryEventReceiverEventsReceiver : SPFeatureReceiver
    {

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;
            var grpUserAdded = web.EventReceivers.Add();
            grpUserAdded.Name = "Event Receiver GroupUserAdded";
            grpUserAdded.Type = SPEventReceiverType.GroupUserAdded;
            grpUserAdded.Assembly = Assembly.GetExecutingAssembly().FullName;
            grpUserAdded.Class = "EPMLiveReportsAdmin.GroupUserEventReceiver";
            grpUserAdded.Update();
            web.Update();

            var grpUserRemoved = web.EventReceivers.Add();
            grpUserRemoved.Name = "Event Receiver GroupUserDeleted";
            grpUserRemoved.Type = SPEventReceiverType.GroupUserDeleted;
            grpUserRemoved.Assembly = Assembly.GetExecutingAssembly().FullName;
            grpUserRemoved.Class = "EPMLiveReportsAdmin.GroupUserEventReceiver";
            grpUserRemoved.Update();
            web.Update();

           
            base.FeatureActivated(properties);
        }

        
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;
            List<SPEventReceiverDefinition> toDelete = new List<SPEventReceiverDefinition>();
            foreach (SPEventReceiverDefinition grpUserAdded in web.EventReceivers)
            {
                if (grpUserAdded.Name == "Event Receiver GroupUserAdded" && grpUserAdded.Type == SPEventReceiverType.GroupUserAdded && grpUserAdded.Assembly == Assembly.GetExecutingAssembly().FullName && grpUserAdded.Class == "EPMLiveReportsAdmin.GroupUserEventReceiver")
                {
                    toDelete.Add(grpUserAdded);
                }
                else if (grpUserAdded.Name == "Event Receiver GroupUserDeleted" &&
                grpUserAdded.Type == SPEventReceiverType.GroupUserDeleted &&
                grpUserAdded.Assembly == Assembly.GetExecutingAssembly().FullName &&
                grpUserAdded.Class == "EPMLiveReportsAdmin.GroupUserEventReceiver")
                {
                    toDelete.Add(grpUserAdded);
                }
            }
            web.AllowUnsafeUpdates = true;
            foreach (SPEventReceiverDefinition grpUserAdded in toDelete)
            {
                grpUserAdded.Delete();
            }
            web.Update();
            web.AllowUnsafeUpdates = false;
            base.FeatureDeactivating(properties);
        }
    }
}
