using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.ResourceManagement;
using EPMLiveCore;
using Utilities = WorkEnginePPM.Core.ResourceManagement.Utilities;
using WorkEnginePPM.WebServices.Core;

namespace WorkEnginePPM.Events
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class ResourceManagementEvent : SPItemEventReceiver
    {
        #region Methods (6)

        // Public Methods (4) 

        /// <summary>
        /// An item was added
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                SPWeb spWeb = properties.Web;

                decimal rate;
                Utilities.AddUpdateResource(Utilities.BuildFieldsTable(properties, false), spWeb, properties.ListId,
                                            out rate, false);

                CalculateResourceAvailabilities(properties.ListItem["EXTID"].ToString(), spWeb);
            }
            catch (Exception exception)
            {
                properties.ErrorMessage = exception.GetBaseException().Message;
                properties.Cancel = true;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        /// An item is being added.
        /// </summary>
        /// <param name="properties"></param>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                SPWeb spWeb = properties.Web;

                decimal rate;
                properties.AfterProperties["EXTID"] =
                    Utilities.AddUpdateResource(Utilities.BuildFieldsTable(properties, true), spWeb, properties.ListId,
                                                out rate, true);

                if (rate != 0) properties.AfterProperties["StandardRate"] = rate;
            }
            catch (Exception exception)
            {
                properties.ErrorMessage = exception.GetBaseException().Message;
                properties.Cancel = true;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        /// An item is being deleted
        /// </summary>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                int extId;

                if (!int.TryParse(properties.ListItem["EXTID"] as string, out extId))
                {
                    return;
                }

                bool confirmDelete = false;

                StackFrame[] stackFrames = new StackTrace().GetFrames();
                if (stackFrames != null)
                {
                    if ((from stackFrame in stackFrames
                         select stackFrame.GetMethod()
                             into methodBase
                             where methodBase.Name.Equals("ConfirmDelete")
                             select methodBase.DeclaringType
                                 into declaringType
                                 where declaringType != null
                                 select declaringType.FullName)
                        .Any(fullName => fullName != null && fullName.Equals("EPMLiveCore.API.ResourceGrid")))
                    {
                        confirmDelete = true;
                    }
                }

                SPWeb spWeb = properties.Web;

                if (!confirmDelete)
                {
                    string deleteResourceCheckMessage;
                    string deleteResourceCheckStatus;

                    if (Utilities.PerformDeleteResourceCheck(extId, properties.ListItem.UniqueId, spWeb,
                                                             out deleteResourceCheckStatus,
                                                             out deleteResourceCheckMessage))
                    {
                        Utilities.DeleteResource(extId, properties.ListItem.UniqueId, spWeb);
                    }
                    else
                    {
                        properties.ErrorMessage = string.Format("{0}|||{1}", deleteResourceCheckStatus,
                                                                deleteResourceCheckMessage);
                        properties.Cancel = true;
                        properties.Status = SPEventReceiverStatus.CancelWithError;
                    }
                }
                else
                {
                    Utilities.DeleteResource(extId, properties.ListItem.UniqueId, spWeb);
                }
            }
            catch (Exception exception)
            {
                properties.ErrorMessage = exception.GetBaseException().Message;
                properties.Cancel = true;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        /// An item is being updated.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPItemEventProperties"/> object that represents properties of the event handler.</param>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;
            if (properties.ListItem == null) return;

            StackFrame[] stackFrames = new StackTrace().GetFrames();

            if (stackFrames != null)
            {
                if (
                    stackFrames.Select(stackFrame => stackFrame.GetMethod().Name).Any(
                        methodName =>
                        methodName.Equals("AddCommentersFields") || methodName.Equals("CreateComment") ||
                        methodName.Equals("UpdateComment") || methodName.Equals("DeleteComment")))
                {
                    properties.Cancel = true;
                    properties.Status = SPEventReceiverStatus.CancelNoError;

                    return;
                }
            }

            try
            {
                SPWeb spWeb = properties.Web;

                decimal rate;
                var extId = Utilities.AddUpdateResource(Utilities.BuildFieldsTable(properties, false), spWeb, properties.ListId, out rate, true);

                if (rate != 0) properties.AfterProperties["StandardRate"] = rate;
                properties.AfterProperties["EXTID"] = extId;
            }
            catch (Exception exception)
            {
                properties.ErrorMessage = exception.GetBaseException().Message;
                properties.Cancel = true;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        public override void ItemUpdated(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                CalculateResourceAvailabilities(properties.ListItem["EXTID"].ToString(), properties.Web);
            }
            catch (Exception exception)
            {
                properties.ErrorMessage = exception.GetBaseException().Message;
                properties.Cancel = true;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private bool ValidateRequest(SPItemEventProperties properties)
        {
            return properties.OpenSite().Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null &&
                   properties.List.Title.Equals("Resources");
        }

        private void CalculateResourceAvailabilities(string pfeResourceId, SPWeb spWeb)
        {
            using (var resourceManager = new ResourceManager(spWeb))
            {
                resourceManager.CalculateResourceAvailabilities(int.Parse(pfeResourceId));
            }
        }

        #endregion Methods
    }
}
