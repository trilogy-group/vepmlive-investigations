using System;
using System.Collections;
using System.Diagnostics;
using Microsoft.SharePoint;

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
            if (!VerifyHiddenItems(properties))
            {
                return;
            }

            string newPercent = null;
            string newComplete = null;
            string newStatus = null;

            string oldPercent = null;
            string oldStatus = null;
            var method = string.Empty;

            GetPercentComplete(properties, ref newPercent);
            GetCompleteStatus(properties, ref newComplete);
            GetStatus(properties, ref newStatus);
            GetOldPercentComplete(properties, ref oldPercent);
            GetOldStatus(properties, ref oldStatus);

            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    using (var site = new SPSite(properties.SiteId))
                    {
                        using (var web = site.OpenWeb(properties.Web.ID))
                        {
                            ProcessMethod(properties, web, ref newPercent, out method);
                        }
                    }
                });

            UpdatePercent(properties, ref newPercent, newComplete, newStatus, oldPercent);
            UpdateStatus(properties, ref newStatus, newComplete, newPercent);
            UpdateComplete(ref newComplete, newStatus, newPercent);
            UpdateNewStatus(method, ref newStatus, oldStatus, oldPercent, ref newPercent);
            SetNewProperties(properties, newPercent, newComplete, newStatus);
        }

        private static void ProcessMethod(SPItemEventProperties properties, SPWeb web, ref string newPercent, out string method)
        {
            method = ReflectionMethods.GetStatusMethod(web, properties.ListTitle);

            if (method == "1")
            {
                try
                {
                    var workDone = float.Parse(properties.AfterProperties["ActualWork"].ToString());
                    var remainingWork = float.Parse(properties.AfterProperties["RemainingWork"].ToString());

                    newPercent = workDone == 0 && remainingWork == 0
                        ? "0"
                        : (workDone / (remainingWork + workDone)).ToString();
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }

            if (method == "2")
            {
                try
                {
                    var Work = float.Parse(properties.ListItem["Work"].ToString());
                    var rWork = float.Parse(properties.AfterProperties["RemainingWork"].ToString());

                    if (Work == 0)
                    {
                        newPercent = "0";
                    }
                    else
                    {
                        newPercent = ((Work - rWork) / Work).ToString();
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }
        }

        private static void SetNewProperties(
            SPItemEventProperties properties,
            string newPercent,
            string newComplete,
            string newStatus)
        {
            properties.AfterProperties["PercentComplete"] = newPercent;
            properties.AfterProperties["Complete"] = newComplete;
            properties.AfterProperties["Status"] = newStatus;
        }

        private void UpdateNewStatus(
            string method,
            ref string newStatus,
            string oldStatus,
            string oldPercent,
            ref string newPercent)
        {
            if (method != "1" && method != "2" && newStatus != oldStatus && newPercent == oldPercent)
            {
                newPercent = getPercentFromStatus(newStatus, oldPercent);
            }
            else if (newPercent != oldPercent && newStatus == oldStatus)
            {
                newStatus = getStatusFromPercent(newPercent);
            }
        }

        private static void UpdateComplete(ref string newComplete, string newStatus, string newPercent)
        {
            if (newComplete == null)
            {
                if (!string.IsNullOrWhiteSpace(newStatus))
                {
                    newComplete = newStatus == "Completed"
                        ? "1"
                        : "0";
                }
                else
                {
                    newComplete = newPercent == "1"
                        ? "1"
                        : "0";
                }
            }
        }

        private void UpdateStatus(SPItemEventProperties properties, ref string newStatus, string newComplete, string newPercent)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
            {
                if (newComplete != null)
                {
                    const string CompleteFlag = "1";
                    if (newComplete == CompleteFlag || string.Equals(newComplete, bool.TrueString, StringComparison.OrdinalIgnoreCase))
                    {
                        newStatus = "Completed";
                    }
                    else if (newPercent != null)
                    {
                        newStatus = getStatusFromPercent(newPercent);
                    }
                    else
                    {
                        newStatus = "Not Started";
                    }
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
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                }
            }
        }

        private void UpdatePercent(
            SPItemEventProperties properties,
            ref string newPercent,
            string newComplete,
            string newStatus,
            string oldPercent)
        {
            if (newPercent == null)
            {
                if (newComplete != null)
                {
                    if (newComplete == "1" || string.Equals(newComplete, "true", StringComparison.OrdinalIgnoreCase))
                    {
                        newPercent = "1";
                    }
                    else
                    {
                        newPercent = !string.IsNullOrWhiteSpace(newStatus)
                            ? getPercentFromStatus(newStatus, oldPercent)
                            : properties.ListItem["PercentComplete"] != null
                                ? properties.ListItem["PercentComplete"].ToString()
                                : "0";
                    }
                }
                else if (!string.IsNullOrWhiteSpace(newStatus))
                {
                    newPercent = getPercentFromStatus(newStatus, oldPercent);
                }
                else
                {
                    try
                    {
                        newPercent = properties.ListItem["PercentComplete"].ToString();
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                }
            }
        }

        private static void GetOldStatus(SPItemEventProperties properties, ref string oldStatus)
        {
            try
            {
                oldStatus = properties.ListItem["Status"].ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private static void GetOldPercentComplete(SPItemEventProperties properties, ref string oldPercent)
        {
            try
            {
                oldPercent = properties.ListItem["PercentComplete"].ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private static void GetStatus(SPItemEventProperties properties, ref string status)
        {
            try
            {
                if (properties.AfterProperties["Status"] == null)
                {
                    if (properties.List.Fields["Status"].DefaultValue != null)
                    {
                        status = properties.List.Fields["Status"].DefaultValue;
                    }
                }
                else
                {
                    status = properties.AfterProperties["Status"].ToString();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private static void GetCompleteStatus(SPItemEventProperties properties, ref string complete)
        {
            try
            {
                complete = properties.AfterProperties["Complete"].ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private static void GetPercentComplete(SPItemEventProperties properties, ref string percent)
        {
            try
            {
                percent = properties.AfterProperties["PercentComplete"].ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private static bool VerifyHiddenItems(SPItemEventProperties properties)
        {
            var allHidden = true;

            try
            {
                foreach (DictionaryEntry field in properties.AfterProperties)
                {
                    if (!properties.List.Fields.GetFieldByInternalName(field.Key.ToString()).Hidden)
                    {
                        allHidden = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                allHidden = false;
            }

            return !allHidden;
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
