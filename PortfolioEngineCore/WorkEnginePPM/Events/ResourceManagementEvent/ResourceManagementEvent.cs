﻿using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.ResourceManagement;

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
                                            out rate);
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
                EnsureNoDuplicates(properties);

                SPWeb spWeb = properties.Web;

                decimal rate;
                properties.AfterProperties["EXTID"] =
                    Utilities.AddUpdateResource(Utilities.BuildFieldsTable(properties, true), spWeb, properties.ListId,
                                                out rate);

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
                Utilities.AddUpdateResource(Utilities.BuildFieldsTable(properties, false), spWeb, properties.ListId,
                                            out rate);

                if (rate != 0) properties.AfterProperties["StandardRate"] = rate;
            }
            catch (Exception exception)
            {
                properties.ErrorMessage = exception.GetBaseException().Message;
                properties.Cancel = true;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        // Private Methods (2) 

        /// <summary>
        /// Ensures the no duplicates.
        /// </summary>
        /// <param name="properties">The properties.</param>
        private void EnsureNoDuplicates(SPItemEventProperties properties)
        {
            bool isGeneric;

            try
            {
                isGeneric = bool.Parse(properties.AfterProperties["Generic"].ToString());
            }
            catch
            {
                try
                {
                    isGeneric = bool.Parse(properties.ListItem["Generic"].ToString());
                }
                catch
                {
                    isGeneric = false;
                }
            }

            if(isGeneric) return;

            string sharePointAccount;

            try
            {
                sharePointAccount = properties.AfterProperties["SharePointAccount"].ToString();
            }
            catch
            {
                try
                {
                    sharePointAccount = properties.ListItem["SharePointAccount"].ToString();
                }
                catch
                {
                    sharePointAccount = string.Empty;
                }
            }

            if (string.IsNullOrEmpty(sharePointAccount))
            {
                throw new Exception("Please provide a valid SharePoint Account.");
            }

            SPFieldUserValue uv;

            try
            {
                uv = new SPFieldUserValue(properties.Web, sharePointAccount);
            }
            catch
            {
                throw new Exception(sharePointAccount + " is not a valid SharePoint account.");
            }

            SPUser u = uv.User ?? properties.Web.EnsureUser(uv.LookupValue);

            string query = string.Format(@"<Where><Eq><FieldRef Name='SharePointAccount' LookupId='TRUE'/><Value Type='Int'>{0}</Value></Eq></Where>", u.ID);
            const string viewFields = @"<FieldRef Name='Title' Nullable='TRUE'/>";

            SPListItemCollection spListItemCollection = null;

            try
            {
                spListItemCollection = properties.List.GetItems(new SPQuery { Query = query, ViewFields = viewFields });
            }
            catch { }

            if (spListItemCollection == null) return;
            if (spListItemCollection.Count <= 0) return;

            SPListItem spListItem = spListItemCollection[0];

            throw new Exception(string.Format("This SharePoint Account ({0}) is currently associated with {1}",
                                              u.LoginName, spListItem["Title"]));
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

        #endregion Methods 
    }
}
