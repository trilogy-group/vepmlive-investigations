using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Collections;

namespace EPMLiveCore
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class StatusingEvent : SPItemEventReceiver
    {
        public override void ItemAdding(SPItemEventProperties properties)
        {
            processItem(properties, true);
        }

        private void processItem(SPItemEventProperties properties, bool isAdd)
        {
            bool allHidden = true;

            try
            {
                foreach (System.Collections.DictionaryEntry sField in properties.AfterProperties)
                {
                    if (!properties.List.Fields.GetFieldByInternalName(sField.Key.ToString()).Hidden)
                    {
                        allHidden = false;
                        break;
                    }
                }
            }
            catch { allHidden = false; }

            if (allHidden)
                return;

            string newPercent = null;
            string newComplete = null;
            string newStatus = null;

            string oldPercent = null;
            string oldStatus = null;
            string method = "";

            try
            {
                newPercent = properties.AfterProperties["PercentComplete"].ToString();
            }
            catch { }
            try
            {
                newComplete = properties.AfterProperties["Complete"].ToString();
            }
            catch { }
            try
            {
                if (properties.AfterProperties["Status"] == null)
                {
                    if (properties.List.Fields["Status"].DefaultValue != null)
                    {
                        newStatus = properties.List.Fields["Status"].DefaultValue;
                    }
                }
                else
                {
                    newStatus = properties.AfterProperties["Status"].ToString();
                }
            }
            catch { }
            try
            {
                oldPercent = properties.ListItem["PercentComplete"].ToString();
            }
            catch { }
            try
            {
                oldStatus = properties.ListItem["Status"].ToString();
            }
            catch { }

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(properties.SiteId))
                {
                    using (SPWeb web = site.OpenWeb(properties.Web.ID))
                    {
                        method = ReflectionMethods.GetStatusMethod(web, properties.ListTitle);

                        if (method == "1")
                        {
                            try
                            {
                                float aWork = float.Parse(properties.AfterProperties["ActualWork"].ToString());
                                float rWork = float.Parse(properties.AfterProperties["RemainingWork"].ToString());

                                if (aWork == 0 && rWork == 0)
                                    newPercent = "0";
                                else
                                    newPercent = (aWork / (rWork + aWork)).ToString();
                            }
                            catch { }
                        }

                        if (method == "2")
                        {
                            try
                            {
                                float Work = float.Parse(properties.ListItem["Work"].ToString());
                                float rWork = float.Parse(properties.AfterProperties["RemainingWork"].ToString());

                                if (Work == 0)
                                    newPercent = "0";
                                else
                                    newPercent = ((Work - rWork) / (Work)).ToString();
                            }
                            catch { }
                        }
                    }
                }
            });

            if (newPercent == null)
            {
                if (newComplete != null)
                {
                    if (newComplete == "1" || newComplete.ToLower() == "true")
                        newPercent = "1";
                    else if (newStatus != null)
                        newPercent = getPercentFromStatus(newStatus, oldPercent);
                    else
                        newPercent = "0";
                }
                else if (newStatus != null)
                {
                    newPercent = getPercentFromStatus(newStatus, oldPercent);
                }
                else
                {
                    try
                    {
                        newPercent = properties.ListItem["PercentComplete"].ToString();
                    }
                    catch { }
                }
            }

            if (newStatus == null)
            {
                if (newComplete != null)
                {
                    if (newComplete == "1" || newComplete.ToLower() == "true")
                        newStatus = "Completed";
                    else if (newPercent != null)
                        newStatus = getStatusFromPercent(newPercent);
                    else
                        newStatus = "Not Started";
                }
                else if (newPercent != null)
                {
                    newStatus = getStatusFromPercent(newPercent);
                }
                else
                {
                    try
                    {
                        newStatus = properties.ListItem["Status"].ToString();
                    }
                    catch { }
                }
            }

            if (newComplete == null)
            {
                if (newStatus != null)
                {
                    if (newStatus == "Completed")
                        newComplete = "1";
                    else
                        newComplete = "0";
                }
                else
                {
                    if (newPercent == "1")
                        newComplete = "1";
                    else
                        newComplete = "0";
                }
            }

            if (method != "1" && method != "2" && newStatus != oldStatus && newPercent == oldPercent)
            {
                newPercent = getPercentFromStatus(newStatus, oldPercent);
            }
            else if (newPercent != oldPercent && newStatus == oldStatus)
            {
                newStatus = getStatusFromPercent(newPercent);
            }

            properties.AfterProperties["PercentComplete"] = newPercent;
            properties.AfterProperties["Complete"] = newComplete;
            properties.AfterProperties["Status"] = newStatus;
        }

        private string getPercentFromStatus(string newStatus, string oldPercent)
        {
            if (newStatus == "Completed")
                return "1";
            else if (newStatus == "Not Started")
                return "0";
            else
            {
                if (oldPercent == "0" || oldPercent == null || oldPercent == "1")
                    return ".5";
            }

            return oldPercent;
        }

        private string getStatusFromPercent(string newPercent)
        {
            if (newPercent == "0")
                return "Not Started";
            else if (newPercent == "1")
                return "Completed";
            else
                return "In Progress";
        }

        /// <summary>
        /// An item is being updated.
        /// </summary>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            processItem(properties, false);
        }

        /// <summary>
        /// An item was deleted.
        /// </summary>
        public override void ItemDeleted(SPItemEventProperties properties)
        {

        }


    }
}
