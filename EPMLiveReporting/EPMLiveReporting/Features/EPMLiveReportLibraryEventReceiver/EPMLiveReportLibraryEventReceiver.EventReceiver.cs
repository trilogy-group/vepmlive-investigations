using Microsoft.SharePoint;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

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
            Debugger.Launch();
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
            EnsureFieldExists(reportLibrary, "Datasource Credentials", SPFieldType.Text);
            EnsureFieldExists(web.SiteUserInfoList, "Synchronized", SPFieldType.Boolean);
            AssociateFieldWithContentType(reportLibrary, "Datasource Credentials", "Report Data Source");
        }

        private void AssociateFieldWithContentType(SPDocumentLibrary reportLibrary, string fieldName, string contentName)
        {
            var field = reportLibrary.Fields[fieldName];
            var fieldLink = new SPFieldLink(field);
            var contentType = reportLibrary.ContentTypes[contentName];
            if (contentType.FieldLinks[fieldName] == null)
            {
                contentType.FieldLinks.Add(fieldLink);
                contentType.Update();
            }
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