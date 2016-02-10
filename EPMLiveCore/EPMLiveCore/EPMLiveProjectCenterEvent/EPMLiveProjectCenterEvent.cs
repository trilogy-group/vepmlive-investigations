using System;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore
{
    
    [Guid("2ef28a11-0ea0-40d6-a1cd-0d8d68f649b4")]
    public class EPMLiveProjectCenterEvent : SPItemEventReceiver
    {
        public struct propStruct
        {
            public string weburl;
            public SortedList<string, DataTable> lstListDataToDelete;
        };

        static string sEventLogSource = "EPM Live Project Center Events";
        static string sEventLogName = "EPM Live";
        static string sEvent = "";
        /// <summary>
        /// Initializes a new instance of the Microsoft.SharePoint.SPItemEventReceiver class.
        /// </summary>
        public EPMLiveProjectCenterEvent()
        {
        }

        //static void processList(SPList list, string fieldname, string projectname, SPWeb web)
        //{
        //    try
        //    {
        //        Hashtable hash = new Hashtable();
        //        foreach (SPListItem lItem in list.Items)
        //        {
        //            string pj = lItem[fieldname].ToString();
        //            if (pj == projectname || pj.Substring(pj.IndexOf(";#")).Length <= 2)
        //                if (list.Title == CoreFunctions.getConfigSetting(web, "EPMLiveTaskCenter") || list.Title == "Resource Center")
        //                    list.Items[lItem.UniqueId].Delete();
        //                else
        //                    list.Items[lItem.UniqueId].Recycle();
        //            //hash.Add(lItem.UniqueId, " ");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logException("DeletingProject", ex.Message, ex.StackTrace);
        //    }
        //}

        static void processDelete(object data)
        {
            try
            {
                bool isListHasEnabledThrottling = false;
                propStruct properties = (propStruct)data;
                SPSecurity.RunWithElevatedPrivileges(
                delegate()
                {
                    using (SPSite site = new SPSite(properties.weburl))
                    {
                        using (SPWeb web = site.OpenWeb())
                        {
                            web.AllowUnsafeUpdates = true;
                            foreach (string listname in properties.lstListDataToDelete.Keys)
                            {
                                try
                                {
                                    SPList list = web.Lists[listname];
                                    isListHasEnabledThrottling = list.EnableThrottling;
                                    list.EnableThrottling = false; //This will reset threshold for this list while cascade delete large number of items
                                    list.Update();

                                    DataTable dt = properties.lstListDataToDelete[listname];
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        try
                                        {
                                            list.GetItemById(int.Parse(dr["ID"].ToString())).Recycle();
                                        }
                                        catch { }
                                    }

                                    list.EnableThrottling = isListHasEnabledThrottling; //Set threshold back to the list...
                                    list.Update();
                                }
                                catch { }
                            }
                        }
                    }
                });
                //SPWeb spWeb = properties.web;
                //spWeb.AllowUnsafeUpdates = true;


                //string listid = spWeb.Lists["Project Center"].ID.ToString();

                //for (int i = 0; i < spWeb.Lists.Count; i++)
                //{

                //    string fieldname = "";

                //    foreach (SPField field in spWeb.Lists[i].Fields)
                //    {
                //        if (field.SchemaXml.Contains("Type=\"Lookup") && field.SchemaXml.ToLower().Contains("{" + listid.ToLower() + "}"))
                //        {
                //            fieldname = field.Title;
                //        }
                //    }
                //    if (fieldname != "")
                //        processList(spWeb.Lists[i], fieldname, properties.projectname);
                //}
            }
            catch (Exception ex)
            {
                logException("DeletingProject", ex.Message, ex.StackTrace);
            }
        }

        static void logException(string sLoc, string sMsg, string sNotes)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    sEvent = "Error occurred in " + sLoc + " : Error message is: " + sMsg + " Additional notes: " + sNotes;

                    if (!EventLog.SourceExists(sEventLogSource))
                        EventLog.CreateEventSource(sEventLogSource, sEventLogName);

                    //EventLog.WriteEntry(sEventLogSource, sEvent);
                    EventLog.WriteEntry(sEventLogSource, sEvent, EventLogEntryType.Warning, 234);
                }
                catch { }
            });
        }

        /// <summary>
        /// Synchronous before event that occurs before an existing item is completely deleted.
        /// </summary>
        /// <param name="properties">
        /// A Microsoft.SharePoint.SPItemEventProperties object that represents properties of the event handler.
        /// </param>
        public override void ItemDeleting(SPItemEventProperties properties)
        {

            //props.projectname = properties.ListItem.ID.ToString() + ";#" + properties.ListItem.Title;
            //props.web = properties.ListItem.Web;
            propStruct props = new propStruct();

            SPWeb web = properties.ListItem.Web;
            {
                SortedList<string, DataTable> lstListDataToDelete = new SortedList<string, DataTable>();

                foreach (SPList list in web.Lists)
                {
                    string fieldname = "";

                    foreach (SPField field in list.Fields)
                    {
                        if (field.SchemaXml.Contains("Type=\"Lookup") && field.SchemaXml.ToLower().Contains("{" + properties.ListId.ToString().ToLower() + "}"))
                        {
                            fieldname = field.InternalName;
                            SPSiteDataQuery query = new SPSiteDataQuery();
                            query.QueryThrottleMode = SPQueryThrottleOption.Override; //Used to set/reset throttling while retrieving records using CAML query.
                            query.Lists = "<Lists><List ID=\"" + list.ID.ToString() + "\"/></Lists>";
                            //query.RowLimit = (uint)0;
                            query.Query = "<Where><Eq><FieldRef Name=\"" + field.InternalName + "\" LookupId=\"True\"/><Value Type=\"Lookup\">" + properties.ListItemId + "</Value></Eq></Where>";
                            query.ViewFields = "<FieldRef Name=\"Title\"/>";

                            DataTable dt = web.GetSiteData(query);

                            if (dt != null && dt.Rows.Count > 0)
                                lstListDataToDelete.Add(list.Title, dt);
                        }
                    }
                    if (fieldname != "")
                    {

                    }
                }
                props.lstListDataToDelete = lstListDataToDelete;
                props.weburl = web.Url;
            }

            Thread thrDownload = new Thread(new ParameterizedThreadStart(processDelete));
            thrDownload.IsBackground = true;
            thrDownload.Start(props);
        }

        /// <summary>
        /// Synchronous Before event that occurs when a new item is added to its containing object.
        /// </summary>
        /// <param name="properties"></param>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            CopyScheduleFieldValueToPCField(properties);
        }

        /// <summary>
        /// Synchronous Before event that occurs when an existing item is changed, for example, when the user changes data in one or more fields.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPItemEventProperties"/> object that represents properties of the event handler.</param>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            CopyScheduleFieldValueToPCField(properties);
        }

        /// <summary>
        /// Copies the schedule field value to PC field.
        /// </summary>
        /// <param name="properties">The properties.</param>
        private static void CopyScheduleFieldValueToPCField(SPItemEventProperties properties)
        {
            if (properties.List.Fields.ContainsFieldWithInternalName("ProjectUpdate"))
            {
                var propertyValue = GetPropertyValue("ProjectUpdate", properties);

                if (propertyValue != null && !propertyValue.ToString().Equals("Schedule Driven")) return;

                foreach (SPField spField in properties.List.Fields)
                {
                    if (spField.InternalName.IndexOf("project", StringComparison.OrdinalIgnoreCase) < 0) continue;

                    Match match = Regex.Match(spField.InternalName, @"^Project(.*?)$", RegexOptions.IgnoreCase);
                    if (!match.Success) continue;

                    string field = match.Groups[1].Value;
                    if (!properties.List.Fields.ContainsFieldWithInternalName(field)) continue;

                    properties.AfterProperties[spField.InternalName] = GetPropertyValue(field, properties);
                }
            }
            else if (properties.List.Fields.ContainsFieldWithInternalName("PortfolioUpdate"))
            {
                var propertyValue = GetPropertyValue("PortfolioUpdate", properties);

                if (propertyValue != null && !propertyValue.ToString().Equals("Schedule Driven")) return;

                foreach (SPField spField in properties.List.Fields)
                {
                    if (spField.InternalName.IndexOf("portfolio", StringComparison.OrdinalIgnoreCase) < 0) continue;

                    Match match = Regex.Match(spField.InternalName, @"^Portfolio(.*?)$", RegexOptions.IgnoreCase);
                    if (!match.Success) continue;

                    string field = match.Groups[1].Value;
                    if (!properties.List.Fields.ContainsFieldWithInternalName(field)) continue;

                    properties.AfterProperties[spField.InternalName] = GetPropertyValue(field, properties);
                }
            }
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private static object GetPropertyValue(string fieldName, SPItemEventProperties properties)
        {
            try
            {
                var value = properties.AfterProperties[fieldName];

                if (value == null)
                {
                    if (properties.ListItem != null)
                    {
                        if (properties.ListItem.Fields.ContainsFieldWithInternalName(fieldName))
                        {
                            value = properties.ListItem[fieldName];

                            var spField = properties.List.Fields.GetFieldByInternalName(fieldName);
                            if (spField.Type == SPFieldType.DateTime)
                            {
                                value =
                                    SPUtility.CreateISO8601DateTimeFromSystemDateTime(Convert.ToDateTime(value.ToString()));
                            }
                        }
                    }
                }

                return value ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
