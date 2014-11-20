using System;
using System.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.DataSync;

namespace WorkEnginePPM.Events.DataSync
{
    /// <summary>
    ///     List Item Events
    /// </summary>
    public class TimeOffSyncEvent : SPItemEventReceiver
    {
        #region Methods (7) 

        // Public Methods (3) 

        /// <summary>
        ///     An item was added
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            Synchronize(properties);

            SetHours(properties);
        }

        public override void ItemAdding(SPItemEventProperties properties)
        {
            try
            {
                this.EventFiringEnabled = false;
                if (!string.IsNullOrEmpty(Convert.ToString(properties.AfterProperties["DueDate"])))
                    properties.AfterProperties["DueDate"] = System.Convert.ToDateTime(properties.AfterProperties["DueDate"]).AddDays(1).ToString("yyyy-MM-ddTHH:mm:ssZ");
                this.EventFiringEnabled = true;
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        ///     An item is being deleted
        /// </summary>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                using (var timeOffManager = new TimeOffManager(properties.Web))
                {
                    timeOffManager.Delete(properties.ListItem.ID, GetUserId(properties));
                }
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        ///     An item was updated
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            Synchronize(properties);

            SetHours(properties);
        }

        public override void ItemUpdating(SPItemEventProperties properties)
        {
            try
            {
                this.EventFiringEnabled = false;
                if (!string.IsNullOrEmpty(Convert.ToString(properties.AfterProperties["DueDate"])))
                properties.AfterProperties["DueDate"] = System.Convert.ToDateTime(properties.AfterProperties["DueDate"]).AddDays(1).ToString("yyyy-MM-ddTHH:mm:ssZ");
                this.EventFiringEnabled = true;
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        // Private Methods (4) 

        private static int GetUserId(SPItemEventProperties properties)
        {
            int userId = properties.Web.CurrentUser.ID;

            try
            {
                string user;

                try
                {
                    user = properties.AfterProperties["AssignedTo"].ToString();
                }
                catch
                {
                    user = properties.ListItem["AssignedTo"].ToString();
                }

                if (!string.IsNullOrEmpty(user))
                {
                    var userValue = new SPFieldUserValue(properties.Web, user);
                    userId = userValue.User.ID;
                }
            }
            catch { }

            return userId;
        }

        /// <summary>
        ///     Sets the hours.
        /// </summary>
        /// <param name="properties">The properties.</param>
        private static void SetHours(SPItemEventProperties properties)
        {
            try
            {
                using (new DisabledItemEventScope())
                {
                    SPListItem spListItem = properties.List.GetItemById(properties.ListItem.ID);

                    spListItem["Work"] =
                        properties.ListItem["WorkDetail"].ToString().Split(',').Sum(hour => Decimal.Parse(hour));
                    spListItem.SystemUpdate();
                }
            }
            catch { }
        }

        /// <summary>
        ///     Synchronizes the specified properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        private static void Synchronize(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            if (properties.ListItem == null) return;

            try
            {
                using (var timeOffManager = new TimeOffManager(properties.Web))
                {
                    timeOffManager.Synchronize(GetUserId(properties));
                }
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        ///     Validates the request.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private static bool ValidateRequest(SPItemEventProperties properties)
        {
            return properties.OpenSite().Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null &&
                   properties.List.Title.Equals("Time Off");
        }

        #endregion Methods 
    }
}