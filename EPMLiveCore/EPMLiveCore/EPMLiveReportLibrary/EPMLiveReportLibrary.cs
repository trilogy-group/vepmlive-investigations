﻿using Microsoft.SharePoint;
using System;
using System.Diagnostics;

namespace EPMLiveCore.EPMLiveReportLibrary
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EPMLiveReportLibrary : SPItemEventReceiver
    {
        private string eventLogSource = "EPM Live Report Center Events";
        private string eventLogName = "EPM Live";
        private string @event = "";

        /// <summary>
        /// An item was updated.
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);
            using (SPWeb web = properties.OpenWeb())
            {
                try
                {
                    SPListItem currentItem = properties.ListItem;
                    currentItem["Synchronized"] = false;
                    currentItem.Update();
                }
                catch (Exception exception)
                {
                    logException("Updating Report", exception.Message, exception.StackTrace);
                }
            }
        }

        private void logException(string sLoc, string sMsg, string sNotes)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                try
                {
                    @event = "Error occurred in " + sLoc + " : Error message is: " + sMsg + " Additional notes: " + sNotes;
                    if (!EventLog.SourceExists(eventLogSource))
                        EventLog.CreateEventSource(eventLogSource, eventLogName);
                    EventLog.WriteEntry(eventLogSource, @event, EventLogEntryType.Warning, 234);
                }
                catch { }
            });
        }
    }
}