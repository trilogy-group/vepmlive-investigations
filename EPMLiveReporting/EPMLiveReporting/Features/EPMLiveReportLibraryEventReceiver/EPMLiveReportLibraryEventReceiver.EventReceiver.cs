using Microsoft.SharePoint;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Linq;


namespace EPMLiveReportsAdmin.Features.EPMLiveReportLibraryEventReceiver
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("80f22718-6a96-40bf-a902-6e636efef85b")]
    public class EPMLiveReportLibraryEventReceiverEventReceiver : SPFeatureReceiver
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

            var reportLibrary = web.Lists["Report Library"] as SPDocumentLibrary;
            EnsureFieldExists(reportLibrary, "Synchronized", SPFieldType.Boolean);
            EnsureFieldExists(reportLibrary, "UpdatedBy", SPFieldType.Text);
            EnsureFieldExists(web.SiteUserInfoList, "Synchronized", SPFieldType.Boolean);
        }

        private void EnsureFieldExists(SPList extendedList, string fieldName, SPFieldType fieldType)
        {
            if (!extendedList.Fields.ContainsField(fieldName))
            {
                extendedList.Fields.Add(fieldName, fieldType, false);
            }
        }
    }
}