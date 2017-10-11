using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using System.Reflection;
using System.Collections.Generic;

namespace EPMLiveReportsAdmin.Features.EPMLiveReportLibraryFields
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("c3340a7c-91d9-451f-8977-cee0ecf125dc")]
    public class EPMLiveReportLibraryFieldsEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            var reportLibrary = web.Lists["Report Library"] as SPDocumentLibrary;
            EnsureBoolFieldExists(reportLibrary, "Synchronized", false);
            EnsureTextFieldExists(reportLibrary, "UpdatedBy", false);
            EnsureTextFieldExists(reportLibrary, "Datasource Credentials", true);

            EnsureBoolFieldExists(web.SiteUserInfoList, "Synchronized", false);

            AssociateFieldWithContentType(reportLibrary, "Datasource Credentials", "Report Data Source");
            base.FeatureActivated(properties);
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

        private void EnsureBoolFieldExists(SPList extendedList, string fieldName, bool defaultValue)
        {
            if (!extendedList.Fields.ContainsField(fieldName))
            {
               
                extendedList.Fields.Add(fieldName, SPFieldType.Boolean, false);

                SPFieldBoolean boolField = extendedList.Fields[fieldName] as SPFieldBoolean;
                boolField.ShowInEditForm = false;
                boolField.DefaultValue = defaultValue ? "1" : "0";
                boolField.Hidden = false;// true;
                boolField.Update();
                
                extendedList.Update();
                var query = new SPQuery();
                query.Query = @"<Where><IsNull><FieldRef Name='" + fieldName + @"' /></IsNull></Where>";
                var items = extendedList.GetItems(query);
                foreach (SPListItem item in items)
                {
                    item[fieldName] = defaultValue ? "1" : "0";
                    item.Update();
                }
            }
        }

        private void EnsureTextFieldExists(SPList extendedList, string fieldName, bool showInEdit)
        {
            if (!extendedList.Fields.ContainsField(fieldName))
            {
                extendedList.Fields.Add(fieldName, SPFieldType.Text, false);
                SPFieldText textField = extendedList.Fields[fieldName] as SPFieldText;
                textField.Hidden = false; //!showInEdit;
                textField.ShowInEditForm = showInEdit;
                textField.Update();
                extendedList.Update();
            }
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
