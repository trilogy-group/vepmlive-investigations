using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.SharePoint;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Threading;
using System.ComponentModel;
using System.DirectoryServices;
using System.Globalization;
using System.Text;
using EPMLiveCore;

namespace WorkEnginePPM
{
    [WebService(Namespace = "http://epmlive.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Integration : System.Web.Services.WebService
    {
        [WebMethod]
        public XmlNode execute(string commandMethod, string commandText)
        {
            XmlDocument doc = new XmlDocument();
            string ret = "<NoResults/>";
            switch (commandMethod.ToLower())
            {
                case "getmappedview":
                    ret = GetMappedView(commandText);
                    break;
                case "enablefeatures":
                    ret = EnableFeatures(commandText);
                    break;
                case "disablefeatures":
                    ret = DisableFeatures(commandText);
                    break;
                case "getresourcepoolurl":
                    ret = getresourcepoolurl();
                    break;
                case "updateresources":
                    ret = UpdateResources(commandText);
                    break;
                case "updateitems":
                    ret = UpdateItems(commandText);
                    break;
                case "setsettings":
                    ret = SetSettings(commandText);
                    break;
                case "clearsettings":
                    ret = ClearSettings(commandText);
                    break;
                case "getsettings":
                    ret = GetSettings(commandText);
                    break;
                case "runtimer":
                    ret = RunTimer(commandText);
                    break;
                case "gettimerstatus":
                    ret = GetTimerStatus(commandText);
                    break;
                case "getmissingeventhandlers":
                    ret = GetMissingEventHandlers(commandText);
                    break;
                case "enableevents":
                    ret = EnableEvents(commandText);
                    break;
                case "disableevents":
                    ret = DisableEvents(commandText);
                    break;
                case "disablealllistsevents":
                    ret = DisableAllListsEvents(commandText);
                    break;
                case "disableresources":
                    ret = DisableResources(commandText);
                    break;
                case "getavailablelists":
                    ret = GetAvailableLists(commandText);
                    break;
                case "getavailablefields":
                    ret = GetAvailableFields(commandText);
                    break;
                case "getavailableviews":
                    ret = GetAvailableViews(commandText);
                    break;
                case "publishtasks":
                    ret = PublishTasks(commandText);
                    break;
                case "publishstatus":
                    ret = PublishStatus(commandText);
                    break;
                case "getupdatecount":
                    ret = GetUpdateCount(commandText);
                    break;
                case "getupdates":
                    ret = GetUpdates(commandText);
                    break;
                case "processupdates":
                    ret = ProcessUpdates(commandText);
                    break;
                case "gettimesheettypes":
                    ret = GetTimesheetTypes(commandText);
                    break;
                case "getprojectidfromname":
                    ret = GetProjectIdFromName(commandText);
                    break;
                default:
                    ret = "<Result Status=\"1\"><Error ID=\"1\"><![CDATA[Invalid commandMethod]]></Error></Result>";
                    break;
            };
            
            doc.LoadXml(ret);

            return doc.FirstChild;
        }

        #region Tasks

        private void setupPublishList(SPList list)
        {
            if (!list.Fields.ContainsField("Status"))
            {
                System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
                sc.Add("Queued");
                sc.Add("Processing");
                sc.Add("Completed");
                list.Fields.Add("Status", SPFieldType.Choice, false, false, sc);
                list.Update();
            }
            if (!list.Fields.ContainsField("PercentComplete"))
            {
                list.Fields.Add("PercentComplete", SPFieldType.Number, false);
                list.Update();
            }
            if (!list.Fields.ContainsField("Result"))
            {
                list.Fields.Add("Result", SPFieldType.Text, false);
                list.Update();
            }
            if (!list.Fields.ContainsField("ResultText"))
            {
                list.Fields.Add("ResultText", SPFieldType.Note, false);
                list.Update();
            }
            if (!list.Fields.ContainsField("FinishDate"))
            {
                list.Fields.Add("FinishDate", SPFieldType.DateTime, false);
                list.Update();
            }
        }

        private string PublishTasks(string xml)
        {
            string message = "";
            bool errors = false;

            SortedList arrFields = new SortedList();

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string []project = doc.FirstChild.Attributes["ID"].Value.Split('.');

                
                    using (SPSite oSite = SPContext.Current.Site)
                    {
                        using (SPWeb oWeb = SPContext.Current.Web)
                        {
                            
                            int status = 2;

                            SqlConnection cn = new SqlConnection(ConfigFunctions.getConnectionString(oSite.WebApplication.Id));

                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                    cn.Open();
                            });

                            SqlCommand cmd = new SqlCommand("select timerjobuid,status from vwQueueTimerLog where siteguid=@siteguid and webguid=@webguid and listguid=@listguid and itemid=@itemid and jobtype=9", cn);
                            cmd.Parameters.AddWithValue("@siteguid", oSite.ID);
                            cmd.Parameters.AddWithValue("@webguid", project[0]);
                            cmd.Parameters.AddWithValue("@listguid", project[1]);
                            cmd.Parameters.AddWithValue("@itemid", project[2]);
                            SqlDataReader dr = cmd.ExecuteReader();

                            Guid tJob = Guid.Empty;

                            if (!dr.Read())
                            {
                                tJob = Guid.NewGuid();
                                dr.Close();
                                cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid, itemid, jobdata) VALUES (@timerjobuid, @siteguid, 9, 'Project Publish', 9, @webguid, @listguid, @itemid, @jobdata)", cn);
                                cmd.Parameters.AddWithValue("@siteguid", oSite.ID.ToString());
                                cmd.Parameters.AddWithValue("@webguid", project[0]);
                                cmd.Parameters.AddWithValue("@listguid", project[1]);
                                cmd.Parameters.AddWithValue("@itemid", project[2]);
                                cmd.Parameters.AddWithValue("@jobdata", xml);
                                cmd.Parameters.AddWithValue("@timerjobuid", tJob);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                tJob = dr.GetGuid(0);
                                if(!dr.IsDBNull(1))
                                    status = dr.GetInt32(1);

                                dr.Close();

                                cmd = new SqlCommand("update timerjobs set jobdata=@jobdata where timerjobuid=@timerjobuid", cn);
                                cmd.Parameters.AddWithValue("@jobdata", xml);
                                cmd.Parameters.AddWithValue("@timerjobuid", tJob);
                                cmd.ExecuteNonQuery();
                            }

                            if (status == 2)
                            {
                                if (tJob != Guid.Empty)
                                {
                                    ConfigFunctions.enqueue(tJob, 0);
                                }
                                message = "Successfully Queued";
                            }
                            else
                            {
                                errors = true;
                                message = "<Error ID=\"101\"><![CDATA[Item Already Queued]]></Error>";
                            }

                            cn.Close();

                        
                            
                        }
                    }
                
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        private string PublishStatus(string xml)
        {
            string message = "";
            bool errors = false;

            SortedList arrFields = new SortedList();

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string []project = doc.FirstChild.Attributes["ID"].Value.Split('.');
                string showresults = doc.FirstChild.Attributes["ShowResults"].Value;

                using (SPSite site = SPContext.Current.Site)
                {
                    using (SPWeb oWeb = SPContext.Current.Web)
                    {
                        SqlConnection cn = new SqlConnection(ConfigFunctions.getConnectionString(site.WebApplication.Id));
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn.Open();
                        });
                        SqlCommand cmd = new SqlCommand("select percentComplete,status,dtfinished,result,resulttext from vwQueueTimerLog where siteguid=@siteguid and webguid=@webguid and listguid=@listguid and itemid=@itemid and jobtype=9", cn);
                        cmd.Parameters.AddWithValue("@siteguid", site.ID);
                        cmd.Parameters.AddWithValue("@webguid", project[0]);
                        cmd.Parameters.AddWithValue("@listguid", project[1]);
                        cmd.Parameters.AddWithValue("@itemid", project[2]);
                        SqlDataReader dr = cmd.ExecuteReader();

                        Guid tJob = Guid.Empty;

                        if (dr.Read())
                        {
                            string status = "";
                            string result = (dr.IsDBNull(3)) ? "" : dr.GetString(3);
                            string resulttext = (dr.IsDBNull(4)) ? "" : dr.GetString(4);
                            string dtfinish = (dr.IsDBNull(2)) ? "" : dr.GetDateTime(2).ToString();

                            switch (dr.GetInt32(1))
                            {
                                case 0:
                                    status = "Queued";
                                    break;
                                case 1:
                                    status = "Processing";
                                    break;
                                case 2:
                                    status = "Complete";
                                    break;
                            };
                            if (showresults.ToLower() == "true")
                                message = "<PublishStatus Status=\"" + status + "\" PercentComplete=\"" + dr.GetInt32(0) + "\" TimeFinished=\"" + dtfinish + "\" Result=\"" + result + "\"><![CDATA[" + resulttext + "]]></PublishStatus>";
                            else
                                message = "<PublishStatus Status=\"" + status + "\" PercentComplete=\"" + dr.GetInt32(0) + "\" TimeFinished=\"" + dtfinish + "\" Result=\"" + result + "\"/>";
                        }
                        else
                        {
                            message = "<PublishStatus/>";
                        }

                        cn.Close();
                    }
                }
                
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        private string GetUpdateCount(string xml)
        {
            string message = "";
            bool errors = false;

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string[] project = doc.FirstChild.Attributes["ID"].Value.Split('.');

                string key = "";

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }
                if (key != "")
                {
                    using (SPSite site = SPContext.Current.Site)
                    {
                        using(SPWeb web = site.OpenWeb(new Guid(project[0])))
                        {
                            string taskCenterListName = ConfigFunctions.getLockConfigSetting(web, key + "TaskCenter", false);
                            string taskCenterProjectField = ConfigFunctions.getLockConfigSetting(web, key + "TaskCenterProjectField", false);
                            if (taskCenterProjectField == "")
                                taskCenterProjectField = "Project";

                            SPList oTaskCenter = web.Lists[taskCenterListName];
                            SPList oProjectCenter = web.Lists[new Guid(project[1])];
                            SPListItem oProject = oProjectCenter.GetItemById(int.Parse(project[2]));

                            string transuid = "";
                            try
                            {
                                transuid = oProject["PubTransUid"].ToString().ToUpper();
                            }
                            catch { }

                            SPSiteDataQuery query = new SPSiteDataQuery();
                            query.Lists = "<Lists><List ID=\"" + oTaskCenter.ID.ToString() + "\"/></Lists>";
                            query.Query = "<Where><And><Eq><FieldRef Name=\"" + taskCenterProjectField + "\" LookupId=\"True\"/><Value Type=\"Lookup\">" + project[2] + "</Value></Eq><Neq><FieldRef Name=\"PubTransUid\"/><Value Type=\"Text\">" + transuid + "</Value></Neq></And></Where>";
                            query.ViewFields = "<FieldRef Name=\"Title\"/><FieldRef Name=\"taskuid\"/><FieldRef Name=\"PubTransUid\"/>";

                            DataTable dt = oTaskCenter.ParentWeb.GetSiteData(query);

                            message = dt.Rows.Count.ToString();
                        }
                    }
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"100\"><![CDATA[Invalid Key]]></Error>";
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        private string buildTasks(DataTable dataTable, Hashtable hshTaskCenterFields, SPList taskCenter)
        {
            var strDisplay = ConfigFunctions.getListSetting(taskCenter, "DisplaySettings");
            var fieldProperties = ListDisplayUtils.ConvertFromString(strDisplay);

            var stringBuilder = new StringBuilder();

            foreach (DataRow dr in dataTable.Rows)
            {
                SPListItem listItem = null;
                try
                {
                    listItem = taskCenter.GetItemById(int.Parse(dr["ID"].ToString()));
                }
                catch(Exception ex)
                {
                    Trace.TraceError("Exeption Suppressed {0}", ex);
                }

                if (listItem != null)
                {
                    WriteIds(listItem, stringBuilder);
                    WriteTitle(stringBuilder, listItem);
                    WriteLookupValue(taskCenter, listItem, stringBuilder);
                    WriteIsAssignment(stringBuilder, listItem);
                    WriteTaskHierarchy(stringBuilder, listItem);
                    WriteFieldValues(hshTaskCenterFields, taskCenter, listItem, fieldProperties,stringBuilder);
                    stringBuilder.Append("</Task>");
                }
            }

            return stringBuilder.ToString();
        }

        private void WriteFieldValues(
            Hashtable hshTaskCenterFields,
            SPList taskCenter,
            SPListItem listItem,
            Dictionary<string, Dictionary<string, string>> fieldProperties,
            StringBuilder stringBuilder)
        {
            foreach (SPField spField in taskCenter.Fields)
            {
                if (spField.ShowInEditForm != null
                    && spField.ShowInEditForm.Value
                    && isEditable(listItem, spField, fieldProperties)
                    && spField.Type != SPFieldType.Calculated)
                {
                    var doc = new XmlDocument();
                    doc.LoadXml(spField.SchemaXml);

                    var stringValue = GetGenericFieldValue(taskCenter, spField, listItem);
                    if (spField.Type == SPFieldType.Number
                        || spField.Type == SPFieldType.Currency)
                    {
                        GetNumberFieldValue(ref stringValue, listItem, spField);
                    }
                    else if (spField.Type == SPFieldType.DateTime)
                    {
                        GetDateFieldValue(ref stringValue, listItem, spField);
                    }
                    else if (spField.Type == SPFieldType.User)
                    {
                        GetUserFieldValue(taskCenter, listItem, spField, ref stringValue);
                    }
                    stringBuilder.Append(
                        hshTaskCenterFields.Contains(spField.InternalName)
                            ? $"<Field Name=\"{hshTaskCenterFields[spField.InternalName]}\"><![CDATA[{stringValue}]]></Field>"
                            : $"<Field Name=\"{spField.InternalName}\"><![CDATA[{stringValue}]]></Field>");
                }
            }
        }

        private static void GetUserFieldValue(SPList oTaskCenter, SPListItem li, SPField oField, ref string stringValue)
        {
            try
            {
                var valueStringBuilder = new StringBuilder();
                var userValueCollection = new SPFieldUserValueCollection(oTaskCenter.ParentWeb, li[oField.Id].ToString());
                foreach (var userValue in userValueCollection)
                {
                    valueStringBuilder.Append($",{CoreFunctions.GetRealUserName(userValue.User.LoginName)}");
                }
                stringValue = valueStringBuilder.ToString().Trim(',');
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exeption Suppressed {0}", ex);
            }
        }

        private static void GetDateFieldValue(ref string stringValue, SPListItem li, SPField oField)
        {
            try
            {
                stringValue = DateTime.Parse(li[oField.Id].ToString()).ToString("s");
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exeption Suppressed {0}", ex);
            }
        }

        private static void GetNumberFieldValue(ref string stringValue, SPListItem li, SPField oField)
        {
            try
            {
                var providerEn = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ",",
                    NumberGroupSizes = new[]
                    {
                        3
                    }
                };

                stringValue = Convert.ToDouble(li[oField.Id].ToString()).ToString(providerEn);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exeption Suppressed {0}", ex);
            }
        }

        private static string GetGenericFieldValue(SPList oTaskCenter, SPField oField, SPListItem li)
        {
            var stringValue = string.Empty;
            try
            {
                stringValue = oTaskCenter.Fields[oField.Id].GetFieldValue(li[oField.Id].ToString()).ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exeption Suppressed {0}", ex);
            }
            return stringValue;
        }

        private static void WriteTitle(StringBuilder stringBuilder, SPListItem listItem)
        {
            stringBuilder.AppendFormat("<Title><![CDATA[{0}]]></Title>", listItem.Title);
        }

        private static void WriteIds(SPListItem li, StringBuilder stringBuilder)
        {
            var id = string.Empty;
            var uid = string.Empty;
            try
            {
                id = li["taskorder"].ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exeption Suppressed {0}", ex);
            }
            try
            {
                uid = li["taskuid"].ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exeption Suppressed {0}", ex);
            }
            stringBuilder.Append("<Task ID=\"" + id + "\" UID=\"" + uid + "\" ItemID=\"" + li.ID + "\">");
        }

        private static void WriteLookupValue(SPList oTaskCenter, SPListItem li, StringBuilder stringBuilder)
        {
            try
            {
                var uv = new SPFieldUserValue(
                    oTaskCenter.ParentWeb,
                    li["Editor"]
                        .ToString());
                stringBuilder.Append("<Field Name=\"Editor\"><![CDATA[" + uv.LookupValue + "]]></Field>");
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exeption Suppressed {0}", ex);
            }
        }

        private static void WriteIsAssignment(StringBuilder stringBuilder, SPListItem listItem)
        {
            try
            {
                stringBuilder.Append(listItem["IsAssignment"].ToString() == bool.TrueString
                        ? "<Field Name=\"IsAssignment\"><![CDATA[1]]></Field>"
                        : "<Field Name=\"IsAssignment\"><![CDATA[0]]></Field>");
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exeption Suppressed {0}", ex);
            }
        }

        private static void WriteTaskHierarchy(StringBuilder stringBuilder, SPListItem li)
        {
            try
            {
                stringBuilder.Append("<Field Name=\"TaskHierarchy\"><![CDATA[" + li["TaskHierarchy"] + "]]></Field>");
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exeption Suppressed {0}", ex);
            }
        }

        private bool isEditable(SPListItem listItem, SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties)
        {
            return HelperFunctions.IsEditable(listItem, field, fieldProperties);
        }

        private string GetUpdates(string xml)
        {
            string message = "";
            bool errors = false;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string[] project = doc.FirstChild.Attributes["ID"].Value.Split('.');

                string key = "";

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }
                if (key != "")
                {
                    using (SPSite site = SPContext.Current.Site)
                    {
                        using (SPWeb web = site.OpenWeb(new Guid(project[0])))
                        {
                            string taskCenterListName = ConfigFunctions.getLockConfigSetting(web, key + "TaskCenter", false);
                            string taskCenterFields = ConfigFunctions.getLockConfigSetting(web, key + "TaskCenterFields", false);
                            string taskCenterProjectField = ConfigFunctions.getLockConfigSetting(web, key + "TaskCenterProjectField", false);
                            if (taskCenterProjectField == "")
                                taskCenterProjectField = "Project";

                            Hashtable hshTaskCenterFields = new Hashtable();
                            if (taskCenterFields != "")
                            {
                                foreach (string taskCenterField in taskCenterFields.Split('|'))
                                {
                                    string[] sTaskCenterField = taskCenterField.Split(',');
                                    if (!hshTaskCenterFields.Contains(sTaskCenterField[0]))
                                    {
                                        hshTaskCenterFields.Add(sTaskCenterField[1], sTaskCenterField[0]);
                                    }
                                }
                            }

                            SPList oProjectCenter = web.Lists[new Guid(project[1])];
                            SPListItem oProject = oProjectCenter.GetItemById(int.Parse(project[2]));

                            string transuid = "";
                            try
                            {
                                transuid = oProject["PubTransUid"].ToString().ToUpper();
                            }
                            catch { }

                            SPList oTaskCenter = web.Lists[taskCenterListName];

                            SPSiteDataQuery query = new SPSiteDataQuery();
                            query.Lists = "<Lists><List ID=\"" + oTaskCenter.ID.ToString() + "\"/></Lists>";
                            query.Query = "<Where><And><Eq><FieldRef Name=\"" + taskCenterProjectField + "\" LookupId=\"True\"/><Value Type=\"Lookup\">" + project[2] + "</Value></Eq><Neq><FieldRef Name=\"PubTransUid\"/><Value Type=\"Text\">" + transuid + "</Value></Neq></And></Where>";
                            query.ViewFields = "<FieldRef Name=\"Title\"/>";

                            DataTable dt = oTaskCenter.ParentWeb.GetSiteData(query);

                            message = "<Project>" + buildTasks(dt, hshTaskCenterFields, oTaskCenter) + "</Project>";
                        }
                    }
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"100\"><![CDATA[Invalid Key]]></Error>";
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        private string ProcessUpdates(string xml)
        {
            string message = "";
            bool errors = false;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string[] project = doc.FirstChild.Attributes["ID"].Value.Split('.');

                string key = "";

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }
                if (key != "")
                {
                    using (SPSite site = SPContext.Current.Site)
                    {
                        using (SPWeb web = site.OpenWeb(new Guid(project[0])))
                        {
                            string taskCenterListName = ConfigFunctions.getLockConfigSetting(web, key + "TaskCenter", false);
                            string taskCenterFields = ConfigFunctions.getLockConfigSetting(web, key + "TaskCenterFields", false);
                            string taskCenterProjectField = ConfigFunctions.getLockConfigSetting(web, key + "TaskCenterProjectField", false);
                            if (taskCenterProjectField == "")
                                taskCenterProjectField = "Project";

                            Hashtable hshTaskCenterFields = new Hashtable();
                            if (taskCenterFields != "")
                            {
                                foreach (string taskCenterField in taskCenterFields.Split('|'))
                                {
                                    string[] sTaskCenterField = taskCenterField.Split(',');
                                    if (!hshTaskCenterFields.Contains(sTaskCenterField[0]))
                                    {
                                        hshTaskCenterFields.Add(sTaskCenterField[1], sTaskCenterField[0]);
                                    }
                                }
                            }
                            SPList oTaskCenter = web.Lists[taskCenterListName];

                            SPList oProjectCenter = web.Lists[new Guid(project[1])];
                            SPListItem oProject = oProjectCenter.GetItemById(int.Parse(project[2]));

                            string transuid = "";
                            try
                            {
                                transuid = oProject["PubTransUid"].ToString().ToUpper();
                            }
                            catch { }

                            message = "<Project>";

                            foreach (XmlNode ndTask in doc.FirstChild.SelectNodes("Task"))
                            {
                                string itemid = ndTask.Attributes["ItemID"].Value;

                                try
                                {
                                    SPListItem li = oTaskCenter.GetItemById(int.Parse(itemid));

                                    li["PubTransUid"] = transuid;
                                    if (ndTask.Attributes["Status"].Value == "1")
                                        li["Publisher_x0020_Approval_x0020_S"] = "Approved";
                                    else
                                        li["Publisher_x0020_Approval_x0020_S"] = "Rejected";

                                    li["Publisher_x0020_Approval_x0020_C"] = ndTask.InnerText;

                                    li.Update();

                                    message += "<Task ID=\"" + itemid + "\" Status=\"0\"/>";
                                }
                                catch(Exception ex)
                                {
                                    errors = true;
                                    message += "<Task ID=\"" + itemid + "\" Status=\"1\"><![CDATA[" + ex.Message + "]]></Task>";
                                }
                            }

                            message += "</Project>";
                        }
                    }
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"100\"><![CDATA[Invalid Key]]></Error>";
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        #endregion

        private string getresourcepoolurl()
        {
            try
            {
                string url = "";
                using (SPWeb web = SPContext.Current.Web)
                {
                    url = iGetResPool(web);
                }
                return "<Result Status=\"0\"><![CDATA[" + url + "]]></Result>";
            }
            catch (Exception ex)
            {
                return "<Result Status=\"1\"><Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error></Result>";
            }
        }

        private string GetMappedView(string xml)
        {
            try
            {
                string key = "";
                string list = "";
                string view = "";

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string project = doc.FirstChild.InnerText;
                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }
                try
                {
                    list = doc.FirstChild.Attributes["List"].Value;
                }
                catch { }
                try
                {
                    view = doc.FirstChild.Attributes["View"].Value;
                }
                catch { }
                if (key != "")
                {
                    using (SPWeb web = SPContext.Current.Web)
                    {
                        SPList oList = web.Lists[list];

                        SPView oView = null;
                        if (view == "")
                            oView = oList.DefaultView;
                        else
                            oView = oList.Views[view];

                        string[] sEPKViews = ConfigFunctions.getConfigSetting(web.Site.RootWeb, "EPKViews").Split('|');

                        string EPKView = "";


                        EPKView = EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPK" + oList.Title.Replace(" ", "") + "_costview");

                        if(EPKView == "")
                        {
                            foreach(string sEPKView in sEPKViews)
                            {
                                string[] sEPKViewMap = sEPKView.Split(',');
                                if(sEPKViewMap[0].ToLower() == oView.Title.ToLower())
                                    EPKView = sEPKViewMap[1];
                            }
                        }
                        return "<Result Status=\"0\"><DefaultView ViewId=\"" + EPKView + "\" ViewName=\"" + oView.Title + "\"/></Result>";
                    }

                }
                else
                {
                    return "<Result Status=\"1\"><Error ID=\"101\"><![CDATA[Invalid Key Value]]></Error></Result>";
                }

            }
            catch (Exception ex)
            {
                
                return "<Result Status=\"1\"><Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error></Result>";
            }
        }

        private string GetProjectIdFromName(string xml)
        {
            string id = "";
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string project = doc.FirstChild.InnerText;

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + project + "</Value></Eq></Where>";


                using (SPWeb web = SPContext.Current.Web)
                {
                    string sProjectlist = ConfigFunctions.getLockConfigSetting(web, "EPMLivePublisherProjectCenter", false);

                    SPList sList = web.Lists[sProjectlist];

                    SPListItemCollection col = sList.GetItems(query);

                    if (col.Count >= 1)
                    {
                        id = (web.ID + "." + sList.ID + "." + col[0].ID).ToLower();
                    }
                }
            }
            catch (Exception ex)
            {

                return "<Result Status=\"1\"><Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error></Result>";
            }
            return "<Result Status=\"0\">" + id + "</Result>"; ;
        }

        private string GetTimesheetTypes(string xml)
        {
            string key = "";

            try
            {
                
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }

                if (key != "")
                {
                    using (SPWeb web = SPContext.Current.Web)
                    {
                        SqlConnection cn = new SqlConnection(ConfigFunctions.getConnectionString(web.Site.WebApplication.Id));

                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn.Open();
                        });

                        

                        SqlCommand cmd = new SqlCommand("SELECT TSTYPE_ID, TSTYPE_NAME, TYPEID from TSTYPE where SITE_UID=@siteuid", cn);
                        cmd.Parameters.AddWithValue("@siteuid", web.Site.ID);

                        StringBuilder sbTypes = new StringBuilder();

                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            sbTypes.Append("<Type ID=\"");
                            sbTypes.Append(dr.GetInt32(0));
                            sbTypes.Append("\"");
                            if (!dr.IsDBNull(2))
                            {
                                sbTypes.Append(" Type=\"");
                                sbTypes.Append(dr.GetInt32(2));
                                sbTypes.Append("\"");
                            }
                            else
                                sbTypes.Append(" Type=\"1\"");
                            sbTypes.Append(">");
                            sbTypes.Append(dr.GetString(1));
                            sbTypes.Append("</Type>");
                        }
                        if(sbTypes.ToString() == "")
                        {
                            sbTypes.Append("<Type ID=\"0\" Type=\"1\">Work</Type>");
                        }
                        cn.Close();

                        return "<Result Status=\"0\"><Types>" + sbTypes + "</Types></Result>";
                    }

                }
                else
                {
                    return "<Result Status=\"1\"><Error ID=\"101\">Invalid Key Value</Error></Result>";
                }
            }
            catch (Exception ex)
            {
                return "<Result Status=\"1\"><Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error></Result>";
            }
        }

        #region ResourcePool
        private string iGetResPool(SPWeb web)
        {
            return ConfigFunctions.getLockConfigSetting(web, "EPMLiveResourceURL", false);
        }

        private string UpdateResources(string xml)
        {
            string message = "";
            bool errors = false;

            string key = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                using (SPWeb web = SPContext.Current.Web)
                {

                    string resUrl = iGetResPool(web);
                    SPWeb resWeb = null;
                    SPSite resSite = null;

                    if (resUrl.ToLower() != web.Url.ToLower())
                    {
                        resSite = new SPSite(resUrl);
                        resWeb = resSite.OpenWeb();
                    }
                    else
                    {
                        resSite = web.Site;
                        resWeb = web;
                    }

                    if (resWeb != null)
                    {
                        SPList resList = null;

                        try
                        {
                            resList = resWeb.Lists["Resources"];
                        }
                        catch { }

                        if (resList != null)
                        {
                            try
                            {
                                key = doc.FirstChild.Attributes["Key"].Value;
                            }
                            catch { }

                            HelperFunctions.prepareResList(resList);

                            Hashtable hshFields = new Hashtable();

                            string fields = "";
                            if(key!= "")
                                fields = ConfigFunctions.getLockConfigSetting(web, key + "ResourceFields", false);
                            if (fields != "")
                            {
                                foreach (string field in fields.Split('|'))
                                {
                                    string[] spField = field.Split(',');
                                    hshFields.Add(spField[0], spField[1]);
                                }
                            }

                            if (!hshFields.Contains("3020"))
                                hshFields.Add("3020", "Department");
                            if (!hshFields.Contains("3006"))
                                hshFields.Add("3006", "Generic");
                            if (!hshFields.Contains("3101"))
                                hshFields.Add("3101", "Role");

                            string sPrefix = EPMLiveCore.CoreFunctions.getPrefix();

                            foreach (XmlNode ndResource in doc.FirstChild.SelectNodes("Resource"))
                            {
                                bool e = false;
                                message += HelperFunctions.processResource(ndResource, resList, hshFields, ref e, sPrefix);
                                if (e)
                                    errors = true;
                            }
                        }
                        else
                        {
                            errors = true;
                            message = "<Error ID=\"101\"><![CDATA[Cannot open resource pool list]]></Error>";
                        }

                        resWeb.Close();
                        resSite.Close();

                    }
                    else
                    {
                        errors = true;
                        message = "<Error ID=\"101\"><![CDATA[Cannot open resource pool web]]></Error>";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";


            return message;
        }

        private string DisableResources(string xml)
        {
            string message = "";
            bool errors = false;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                using (SPWeb web = SPContext.Current.Web)
                {

                    string resUrl = iGetResPool(web);
                    SPWeb resWeb = null;
                    SPSite resSite = null;

                    if (resUrl.ToLower() != web.Url.ToLower())
                    {
                        resSite = new SPSite(resUrl);
                        resWeb = resSite.OpenWeb();
                    }
                    else
                    {
                        resSite = web.Site;
                        resWeb = web;
                    }

                    if (resWeb != null)
                    {
                        SPList resList = null;

                        try
                        {
                            resList = resWeb.Lists["Resources"];
                        }
                        catch { }

                        if (resList != null)
                        {
                            HelperFunctions.prepareResList(resList);

                            foreach (XmlNode ndResource in doc.FirstChild.SelectNodes("Resource"))
                            {
                                bool e = false;
                                message += HelperFunctions.processResourceDisable(ndResource, resList, out e);
                                if (e)
                                    errors = true;
                            }
                        }
                        else
                        {
                            errors = true;
                            message = "<Error ID=\"101\"><![CDATA[Cannot open resource pool list]]></Error>";
                        }

                        resWeb.Close();
                        resSite.Close();

                    }
                    else
                    {
                        errors = true;
                        message = "<Error ID=\"101\"><![CDATA[Cannot open resource pool web]]></Error>";
                    }

                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";


            return message;
        }

        
        #endregion

        #region UpdateItems
        private string UpdateItems(string xml)
        {
            var dataSet = new DataSet();
            var message = string.Empty;
            var messageStringBuilder = new StringBuilder();
            var errors = false;

            var source = "EPM Live";
            var log = "Application";

            CreateLogEventSource(source, log);

            try
            {
                var stringReader = new StringReader(xml);
                dataSet.ReadXml(stringReader, XmlReadMode.Auto);

                var siteId = SPContext.Current.Site.ID;
                var webId = SPContext.Current.Web.ID;

                errors = ProcessItems(source, siteId, webId, dataSet, messageStringBuilder);
                message = messageStringBuilder.ToString();
            }
            catch (Exception ex)
            {
                errors = true;
                message = $"<Error ID=\"100\"><![CDATA[{ex.Message}]]></Error>";

                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        EventLog.WriteEntry(source, $"In UpdateItems CATCH block: Error message: {ex.Message}", EventLogEntryType.Error);
                        EventLog.WriteEntry(source, $"In UpdateItems CATCH block: Stack Trace:\r\n{ex.StackTrace}", EventLogEntryType.Error);
                    });
            }

            ProcessErrorMessage(ref message, errors, source);

            return message;

        }

        private static bool ProcessItems(string source, Guid siteId, Guid webId, DataSet dataSet, StringBuilder messageStringBuilder)
        {
            var errors = false;
            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    EventLog.WriteEntry(source, "Inside UpdateItems", EventLogEntryType.Information);

                    using (var site = new SPSite(siteId))
                    {
                        using (var web = site.OpenWeb(webId))
                        {
                            var dataView = dataSet.Tables[1].DefaultView;
                            dataView.Sort = "itemid";

                            var webGuid = Guid.Empty;
                            SPWeb iWeb = null;
                            var listGuid = Guid.Empty;
                            SPList iList = null;

                            foreach (DataRow dataRow in dataView.Table.Rows)
                            {
                                var error = false;

                                var itemid = dataRow["itemid"].ToString().Split('.');

                                var wGuid = new Guid(itemid[0]);
                                var lGuid = new Guid(itemid[1]);

                                if (webGuid != wGuid)
                                {
                                    if (iWeb != null)
                                    {
                                        ReopenWeb(ref iWeb, web, wGuid);
                                    }
                                    else
                                    {
                                        OpenWeb(ref iWeb, web, wGuid);
                                    }
                                    if (iWeb != null)
                                    {
                                        webGuid = iWeb.ID;
                                    }
                                }
                                if (iWeb != null && listGuid != lGuid)
                                {
                                    try
                                    {
                                        iList = iWeb.Lists[lGuid];
                                    }
                                    catch(Exception ex)
                                    {
                                        Trace.TraceError("Exception Suppressed {0}", ex);
                                        EventLog.WriteEntry(
                                            source,
                                            $"In UpdateItems: list not found in the SP site: {lGuid}",
                                            EventLogEntryType.Information);
                                        continue;
                                    }
                                    listGuid = iList.ID;
                                }
                                error = ProcessPortfolioItem(dataSet, messageStringBuilder, iWeb, iList, itemid, dataRow);

                                if (error)
                                {
                                    errors = true;
                                }
                            }
                        }
                    }
                });
            return errors;
        }

        private static bool ProcessPortfolioItem(
            DataSet dataSet,
            StringBuilder messageStringBuilder,
            SPWeb iWeb,
            SPList iList,
            string[] itemid,
            DataRow dataRow)
        {
            bool error = false;
            if (iWeb != null)
            {
                messageStringBuilder.Append(
                    HelperFunctions.processPortfolioItem(
                        iWeb,
                        iList,
                        itemid[2],
                        dataSet.Tables[2]
                               .Select($"portfolioitem_id={dataRow["portfolioitem_id"]}"),
                        "1",
                        out error));
            }
            return error;
        }

        private static void OpenWeb(ref SPWeb iWeb, SPWeb web, Guid wGuid)
        {
            try
            {
                iWeb = web.Site.OpenWeb(wGuid);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private static void ReopenWeb(ref SPWeb iWeb, SPWeb web, Guid wGuid)
        {
            try
            {
                iWeb.Close();
                iWeb = null;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                iWeb = web.Site.OpenWeb(wGuid);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private static void ProcessErrorMessage(ref string message, bool errors, string source)
        {
            message = errors
                ? $"<Result Status=\"1\">{message}</Result>"
                : $"<Result Status=\"0\">{message}</Result>";

            SPSecurity.RunWithElevatedPrivileges(
                delegate { EventLog.WriteEntry(source, $"End of Method UpdateItems, errors:{errors}", EventLogEntryType.Information); });
        }

        private static void CreateLogEventSource(string source, string log)
        {
            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    if (!EventLog.SourceExists(source))
                    {
                        EventLog.CreateEventSource(source, log);
                    }
                });
        }

        #endregion

        #region Settings
        private void clearTimerJob(string jobtype, SPWeb web)
        {
            if (int.Parse(jobtype) >= 10)
            {
                SqlConnection cn = new SqlConnection(ConfigFunctions.getConnectionString(web.Site.WebApplication.Id));

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn.Open();
                });

                //=======================Timer Job==========================
                SqlCommand cmd = new SqlCommand("delete from timerjobs where siteguid=@siteguid and jobtype=@jobtype", cn);
                cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                cmd.Parameters.AddWithValue("@jobtype", jobtype);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        private string getTimerJob(string jobtype, SPWeb web)
        {
            string jobData = "";

            SqlConnection cn = new SqlConnection(ConfigFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });

            //=======================Timer Job==========================
            SqlCommand cmd = new SqlCommand("select jobname,runtime,scheduletype,coalesce(days,'') as days from timerjobs where siteguid=@siteguid and jobtype=@jobtype", cn);
            cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
            cmd.Parameters.AddWithValue("@jobtype", jobtype);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                jobData = dr.GetString(0) + "|" + jobtype + "|" + dr.GetInt32(1) + "|" + dr.GetInt32(2) + "|" + dr.GetString(3);
            }
            dr.Close();
            cn.Close();

            return jobData;
        }

        private void setTimerJob(string settings, SPWeb web)
        {
            string[] jobData = settings.Split('|');

            if (jobData.Length > 4)
            {
                if (int.Parse(jobData[1]) >= 10)
                {
                    SqlConnection cn = new SqlConnection(ConfigFunctions.getConnectionString(web.Site.WebApplication.Id));

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        cn.Open();
                    });

                    Guid timerjobguid;
                    //=======================Timer Job==========================
                    SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=@jobtype", cn);
                    cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                    cmd.Parameters.AddWithValue("@jobtype", jobData[1]);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        timerjobguid = dr.GetGuid(0);
                        dr.Close();
                        cmd = new SqlCommand("UPDATE TIMERJOBS set runtime = @runtime, days=@days,scheduletype=@scheduletype where siteguid=@siteguid and jobtype=@jobtype", cn);
                        cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                        cmd.Parameters.AddWithValue("@runtime", jobData[2]);
                        cmd.Parameters.AddWithValue("@scheduletype", jobData[3]);
                        cmd.Parameters.AddWithValue("@jobtype", jobData[1]);
                        if (jobData[4] == "")
                            cmd.Parameters.AddWithValue("@days", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@days", jobData[4]);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        timerjobguid = Guid.NewGuid();
                        dr.Close();
                        cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, runtime, scheduletype, webguid, days) VALUES (@timerjobuid, @siteguid, @jobtype, @name, @runtime, @scheduletype, @webguid, @days)", cn);
                        cmd.Parameters.AddWithValue("@siteguid", web.Site.ID.ToString());
                        cmd.Parameters.AddWithValue("@timerjobuid", timerjobguid);
                        cmd.Parameters.AddWithValue("@webguid", web.ID.ToString());
                        cmd.Parameters.AddWithValue("@runtime", jobData[2]);
                        cmd.Parameters.AddWithValue("@scheduletype", jobData[3]);
                        cmd.Parameters.AddWithValue("@jobtype", jobData[1]);
                        cmd.Parameters.AddWithValue("@name", jobData[0]);
                        if (jobData[4] == "")
                            cmd.Parameters.AddWithValue("@days", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@days", jobData[4]);

                        cmd.ExecuteNonQuery();
                    }

                    cn.Close();
                }
            }
        }

        private void setTimesheetMap(string map, SPWeb web)
        {
            SqlConnection cn = new SqlConnection(ConfigFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });

            foreach (string typemap in map.Split('|'))
            {
                string[] smap = typemap.Split(',');

                SqlCommand cmd = new SqlCommand("UPDATE TSTYPE SET TYPEID=@typeid where tstype_id=@tstypeid and site_uid=@siteuid", cn);
                cmd.Parameters.AddWithValue("@siteuid", web.Site.ID.ToString());
                cmd.Parameters.AddWithValue("@tstypeid", smap[0]);
                cmd.Parameters.AddWithValue("@typeid", smap[1]);
                cmd.ExecuteNonQuery();
            }

            cn.Close();
        }

        private string SetSettings(string xml)
        {
            string message = "";
            bool errors = false;

            string key = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }
                if (key != "")
                {
                    using (SPWeb web = SPContext.Current.Web)
                    {
                        foreach (XmlNode nd in doc.FirstChild.ChildNodes)
                        {
                            if (nd.Name.ToLower() == "schedule")
                            {
                                setTimerJob(nd.InnerText, web);
                            }
                            else if (nd.Name.ToLower() == "timesheetmap")
                            {
                                if (web.CurrentUser.IsSiteAdmin)
                                {
                                    setTimesheetMap(nd.InnerText, web);
                                }
                            }
                            else
                            {
                                ConfigFunctions.setConfigSetting(web, key + nd.Name, nd.InnerText);
                            }
                        }
                    }
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"100\"><![CDATA[Invalid Key Value]]></Error>";
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";


            return message;
        }

        private string GetSettings(string xml)
        {
            string message = "";
            bool errors = false;

            string key = "";
            string schedule = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }
                try
                {
                    schedule = doc.FirstChild.Attributes["Schedule"].Value;
                }
                catch { }

                if (key != "")
                {
                    using (SPWeb web = SPContext.Current.Web)
                    {
                        foreach(DictionaryEntry prop in web.Properties)
                        {
                            if (prop.Key.ToString().ToLower().IndexOf(key.ToLower()) == 0)
                            {
                                //string val = CoreFunctions.getConfigSetting(web, prop.Key.ToString());

                                try
                                {
                                    var propKey = prop.Key.ToString().Replace("&", "__and__");
                                    message += "<" + propKey.Replace(key.ToLower(), "") + "><![CDATA[" + prop.Value.ToString() + "]]></" + propKey.Replace(key.ToLower(), "") + ">";
                                }
                                catch { }
                            }
                        }
                        if (schedule != "")
                        {
                            message += "<Schedule><![CDATA[" + getTimerJob(schedule, web) + "]]></Schedule>";
                        }
                    }
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"100\"><![CDATA[Invalid Key Value]]></Error>";
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";


            return message;
        }

        private string ClearSettings(string xml)
        {
            string message = "";
            bool errors = false;

            string key = "";
            string schedule = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }
                try
                {
                    schedule = doc.FirstChild.Attributes["Schedule"].Value;
                }
                catch { }

                if (key != "")
                {
                    ArrayList delProps = new ArrayList();
                    using (SPWeb web = SPContext.Current.Web)
                    {
                        foreach (DictionaryEntry prop in web.Properties)
                        {
                            if (prop.Key.ToString().ToLower().IndexOf(key.ToLower()) == 0)
                            {
                                delProps.Add(prop.Key);   
                            }
                        }
                        foreach (string sProp in delProps)
                        {
                            web.Properties[sProp] = null;
                        }
                        web.Properties.Update();

                        if (schedule != "")
                        {
                            clearTimerJob(schedule, web);
                        }
                    }
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"100\"><![CDATA[Invalid Key Value]]></Error>";
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";


            return message;
        }
        #endregion

        #region Timer
        private string RunTimer(string xml)
        {
            string message = "";
            bool errors = false;

            string jobtype = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                try
                {
                    jobtype = doc.FirstChild.Attributes["Schedule"].Value;
                }
                catch { }

                if (jobtype != "" && int.Parse(jobtype) >= 10)
                {
                    using (SPSite site = SPContext.Current.Site)
                    {
                        SqlConnection cn = new SqlConnection(ConfigFunctions.getConnectionString(site.WebApplication.Id));

                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn.Open();
                        });

                        //=======================Timer Job==========================
                        SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=@jobtype", cn);
                        cmd.Parameters.AddWithValue("@siteguid", site.ID.ToString());
                        cmd.Parameters.AddWithValue("@jobtype", jobtype);
                        SqlDataReader dr = cmd.ExecuteReader();

                        Guid timerjobuid = Guid.Empty;

                        if (dr.Read())
                        {
                            timerjobuid = dr.GetGuid(0);
                        }
                        dr.Close();
                        cn.Close();

                        if (timerjobuid != Guid.Empty)
                            ConfigFunctions.enqueue(timerjobuid, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        private string GetTimerStatus(string xml)
        {
            string message = "";
            bool errors = false;

            string jobtype = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                try
                {
                    jobtype = doc.FirstChild.Attributes["Schedule"].Value;
                }
                catch { }

                if (jobtype != "" && int.Parse(jobtype) >= 10)
                {
                    using (SPSite site = SPContext.Current.Site)
                    {
                        SqlConnection cn = new SqlConnection(ConfigFunctions.getConnectionString(site.WebApplication.Id));

                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn.Open();
                        });

                        SqlCommand cmd = new SqlCommand("select timerjobuid,runtime,percentComplete,status,dtfinished,result,resulttext from vwQueueTimerLog where siteguid=@siteguid and jobtype=@jobtype", cn);
                        cmd.Parameters.AddWithValue("@siteguid", site.ID.ToString());
                        cmd.Parameters.AddWithValue("@jobtype", jobtype);
                        SqlDataReader dr = cmd.ExecuteReader();

                        Guid timerjobuid = Guid.Empty;


                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(3))
                            {
                                message = "<Timer Status=\"" + dr.GetInt32(3) + "\" LastResult=\"";
                                if (!dr.IsDBNull(5))
                                    message += dr.GetString(5);
                                message += "\" LastRun=\"";
                                if (!dr.IsDBNull(4))
                                    message += dr.GetDateTime(4);
                                message += "\" PercentComplete=\"";
                                if (!dr.IsDBNull(2))
                                    message += dr.GetInt32(2);
                                message += "\"><![CDATA[";

                                if (!dr.IsDBNull(6))
                                {
                                    message += dr.GetString(6);
                                }

                                message += "]]></Timer>";
                            }
                        }
                        dr.Close();
                        cn.Close();

    
                    }
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }
        #endregion

        #region List Info
        private string GetAvailableLists(string xml)
        {
            string message = "";
            bool errors = false;


            try
            {
                using (SPWeb web = SPContext.Current.Web)
                {
                    foreach (SPList list in web.Lists)
                    {
                        if (!list.Hidden)
                            message += "," + list.Title;
                    }
                }
                
                message = message.Trim(',');
                message = "<Lists><![CDATA[" + message + "]]></Lists>";
            }
            catch (Exception ex)
            {
                if (ex.Message == "Object reference not set to an instance of an object.")
                {
                    errors = true;
                    message = "<Error ID=\"101\"><![CDATA[Invalid Site]]></Error>";
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
                }
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        private string GetAvailableFields(string xml)
        {
            string message = "";
            bool errors = false;
            string key = "";
            string list = "";

            Hashtable arrFields = new Hashtable();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                
                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }

                try
                {
                    list = doc.FirstChild.Attributes["List"].Value;
                }
                catch { }

                if (key != "")
                {
                    
                    using (SPWeb web = SPContext.Current.Web)
                    {
                        if (list == "")
                        {
                            string slists = ConfigFunctions.getConfigSetting(web, key + "Lists");

                            foreach (string sList in slists.Split(','))
                            {
                                try
                                {
                                    SPList oList = web.Lists[sList];
                                    foreach (SPField oField in oList.Fields)
                                    {
                                        if (oField.Reorderable)
                                            if (!arrFields.Contains(oField.InternalName))
                                                arrFields.Add(oField.InternalName, oField.Title + "," + oField.TypeAsString);
                                    }
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            SPList oList = web.Lists[list];
                            foreach (SPField oField in oList.Fields)
                            {
                                if (oField.Reorderable)
                                    if (!arrFields.Contains(oField.InternalName))
                                        arrFields.Add(oField.InternalName, oField.Title + "," + oField.TypeAsString);
                            }
                        }
                        foreach (DictionaryEntry de in arrFields)
                        {
                            message += "|" + de.Key + "," + de.Value;
                        }

                        message = message.Trim('|');
                    }
                    
                    message.Trim(',');
                    message = "<Fields><![CDATA[" + message + "]]></Fields>";
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"101\"><![CDATA[Invalid Key]]></Error>";
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        private string GetAvailableViews(string xml)
        {
            string message = "";
            bool errors = false;
            string key = "";
            string list = "";

            SortedList arrFields = new SortedList();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }

                try
                {
                    list = doc.FirstChild.Attributes["List"].Value;
                }
                catch { }


                if (key != "")
                {
                    using (SPWeb web = SPContext.Current.Web)
                    {
                        if (list == "")
                        {
                            string slists = ConfigFunctions.getConfigSetting(web, key + "Lists");

                            foreach (string sList in slists.Split(','))
                            {
                                try
                                {
                                    SPList oList = web.Lists[sList];
                                    foreach (SPView oView in oList.Views)
                                    {
                                        if (!arrFields.Contains(oView.Title))
                                            arrFields.Add(oView.Title, "");
                                    }
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            try
                            {
                                SPList oList = web.Lists[list];
                                foreach (SPView oView in oList.Views)
                                {
                                    if (!arrFields.Contains(oView.Title))
                                        arrFields.Add(oView.Title, "");
                                }
                            }
                            catch { }
                        }

                        foreach (DictionaryEntry de in arrFields)
                        {
                            message += "|" + de.Key;
                        }

                        message = message.Trim('|');
                        
                    }
                    message.Trim(',');
                    message = "<Fields><![CDATA[" + message + "]]></Fields>";
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"101\"><![CDATA[Invalid Key]]></Error>";
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        private string GetMissingEventHandlers(string xml)
        {
            return HandleEvents(xml, GetMissinEventHandlerAction);
        }

        private static string HandleEvents(string xml, ProcessEventAction processEventAction)
        {
            var message = string.Empty;
            var errors = false;

            var key = string.Empty;
            var eventClass = string.Empty;

            try
            {
                LoadDataFromXml(xml, ref key, ref eventClass);

                if (key != string.Empty && eventClass != string.Empty)
                {
                    processEventAction?.Invoke(key, eventClass, ref message, ref errors);
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"101\"><![CDATA[Invalid Key or Event Class Value]]></Error>";
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                errors = true;
                message = $"<Error ID=\"100\"><![CDATA[{ex.Message}]]></Error>";
            }

            message = errors
                ? $"<Result Status=\"1\">{message}</Result>"
                : $"<Result Status=\"0\">{message}</Result>";

            return message;
        }

        private delegate void ProcessEventAction(string key, string eventClass, ref string message, ref bool errors);

        private static void GetMissinEventHandlerAction(string key, string eventClass, ref string message, ref bool errors)
        {
            using (var site = SPContext.Current.Site)
            {
                var listsString = ConfigFunctions.getConfigSetting(site.RootWeb, key + "Lists");

                if (!string.IsNullOrWhiteSpace(listsString))
                {
                    var lists = listsString.Split(',');

                    var spWebCollection = site.AllWebs;
                    for (var index = 0; index < spWebCollection.Count; index++)
                    {
                        using (var web = spWebCollection[index])
                        {
                            var badLists = string.Empty;

                            foreach (var list in lists)
                            {
                                var eventCount = 0;

                                try
                                {
                                    var spList = web.Lists[list];

                                    foreach (SPEventReceiverDefinition spEventDef in spList.EventReceivers)
                                    {
                                        if (spEventDef.Type == SPEventReceiverType.ItemAdded
                                            && string.Equals(spEventDef.Class, eventClass, StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            eventCount++;
                                        }

                                        if (spEventDef.Type == SPEventReceiverType.ItemUpdating
                                            && string.Equals(spEventDef.Class, eventClass, StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            eventCount++;
                                        }

                                        if (spEventDef.Type == SPEventReceiverType.ItemDeleting
                                            && string.Equals(spEventDef.Class, eventClass, StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            eventCount++;
                                        }
                                    }

                                    if (eventCount != 3)
                                    {
                                        badLists += $",{list}";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Trace.TraceError("Exception Suppressed {0}", ex);
                                }
                            }
                            if (badLists != string.Empty)
                            {
                                badLists = badLists.Trim(',');

                                message += string.Format(
                                    "<Web><URL><![CDATA[{0}]]></URL><Title><![CDATA[{1}]]></Title><Lists><![CDATA[{2}]]></Lists></Web>",
                                    web.ServerRelativeUrl,
                                    web.Title,
                                    badLists);
                            }
                        }
                    }
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"102\"><![CDATA[No Lists Defined]]></Error>";
                }
            }
        }

        private static void LoadDataFromXml(string xml, ref string key, ref string eventClass)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            try
            {
                key = doc.FirstChild.Attributes["Key"].Value;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                eventClass = doc.FirstChild.Attributes["EventClass"].Value;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private string EnableEvents(string xml)
        {
            var message = string.Empty;
            var errors = false;

            new SortedList();

            var key = string.Empty;
            var eventclass = string.Empty;

            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch(Exception ex)
                {
                    Trace.TraceError("Exception Supressed {0}", ex);
                }
                try
                {
                    eventclass = doc.FirstChild.Attributes["EventClass"].Value;
                }
                catch(Exception ex)
                {
                    Trace.TraceError("Exception Supressed {0}", ex);
                }
                if (key != string.Empty
                    && eventclass != string.Empty)
                {
                    using (var site = SPContext.Current.Site)
                    {
                        ProcessEvents(key, site, eventclass, ref errors, ref message);
                    }
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"101\"><![CDATA[Invalid Key or Event Class Value]]></Error>";
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
            {
                message = "<Result Status=\"1\">" + message + "</Result>";
            }
            else
            {
                message = "<Result Status=\"0\">" + message + "</Result>";
            }

            return message;
        }

        private static void ProcessEvents(
            string key,
            SPSite site,
            string eventClass,
            ref bool errors,
            ref string message)
        {
            var slists = ConfigFunctions.getConfigSetting(site.RootWeb, key + "Lists");

            if (slists != string.Empty)
            {
                var arrLists = slists.Split(',');
                var web = site.RootWeb;
                var badLists = string.Empty;
                var labelErrors = string.Empty;
                var badListsStringBuilder = new StringBuilder();
                var labelErrorsStringBuilder = new StringBuilder();

                foreach (var sList in arrLists)
                {
                    try
                    {
                        var list = web.Lists[sList];

                        var added = false;
                        var updating = false;
                        var deleting = false;
                        var adding = Guid.Empty;
                        foreach (SPEventReceiverDefinition spEventDef in list.EventReceivers)
                        {
                            if (spEventDef.Type == SPEventReceiverType.ItemAdding
                                && string.Equals(spEventDef.Class, eventClass, StringComparison.OrdinalIgnoreCase))
                            {
                                adding = spEventDef.Id;
                            }

                            if (spEventDef.Type == SPEventReceiverType.ItemAdded
                                && string.Equals(spEventDef.Class, eventClass, StringComparison.OrdinalIgnoreCase))
                            {
                                added = true;
                            }

                            if (spEventDef.Type == SPEventReceiverType.ItemUpdating
                                && string.Equals(spEventDef.Class, eventClass, StringComparison.OrdinalIgnoreCase))
                            {
                                updating = true;
                            }

                            if (spEventDef.Type == SPEventReceiverType.ItemDeleting
                                && string.Equals(spEventDef.Class, eventClass, StringComparison.OrdinalIgnoreCase))
                            {
                                deleting = true;
                            }
                        }

                        if (!added
                            || !updating
                            || !deleting)
                        {
                            badListsStringBuilder.Append($",{sList}");
                        }

                        AddEvents(eventClass, adding, list, added, updating, deleting, labelErrorsStringBuilder);
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Supressed {0}", ex);
                    }
                    badLists = badListsStringBuilder.ToString();
                    labelErrors = labelErrorsStringBuilder.ToString();
                }
                ProcessNonEmptyBadList(ref errors, ref message, badLists, labelErrors, web);
            }
            else
            {
                errors = true;
                message = "<Error ID=\"102\"><![CDATA[No Lists Defined]]></Error>";
            }
        }

        private static void AddEvents(
            string eventClass,
            Guid adding,
            SPList list,
            bool added,
            bool updating,
            bool deleting,
            StringBuilder labelErrors)
        {
            try
            {
                if (adding != Guid.Empty)
                {
                    list.EventReceivers[adding]
                        .Delete();
                }
                if (!added)
                {
                    list.EventReceivers.Add(
                        SPEventReceiverType.ItemAdded,
                        "WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5",
                        eventClass);
                }
                if (!updating)
                {
                    list.EventReceivers.Add(
                        SPEventReceiverType.ItemUpdating,
                        "WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5",
                        eventClass);
                }
                if (!deleting)
                {
                    list.EventReceivers.Add(
                        SPEventReceiverType.ItemDeleting,
                        "WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5",
                        eventClass);
                }
                if (!added
                    || !updating
                    || !deleting
                    || adding != Guid.Empty)
                {
                    list.Update();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Supressed {0}", ex);
                labelErrors.Append($"{ex.Message}  ");
            }
        }

        private static void ProcessNonEmptyBadList(ref bool errors, ref string message, string badLists, string labelErrors, SPWeb web)
        {
            if (badLists != string.Empty)
            {
                badLists = badLists.Trim(',');
                if (labelErrors != string.Empty)
                {
                    errors = true;
                }

                message += string.Format(
                    "<Web Status=\"{0}\"><Error>{1}</Error><URL><![CDATA[{2}]]></URL><Title><![CDATA[{3}]]></Title><Lists><![CDATA[{4}]]></Lists></Web>",
                    labelErrors != ""
                        ? "1"
                        : "0",
                    labelErrors,
                    web.ServerRelativeUrl,
                    web.Title,
                    badLists);
            }
        }

        private string DisableEvents(string xml)
        {
            return HandleEvents(xml, DisableEventsAction);
        }

        private static void DisableEventsAction(string key, string eventClass, ref string message, ref bool errors)
        {
            using (var site = SPContext.Current.Site)
            {
                var listsString = ConfigFunctions.getConfigSetting(site.RootWeb, key + "Lists");

                if (!string.IsNullOrWhiteSpace(listsString))
                {
                    var lists = listsString.Split(',');

                    var spWebCollection = site.AllWebs;
                    for (var index = 0; index < spWebCollection.Count; index++)
                    {
                        using (var web = spWebCollection[index])
                        {
                            var badLists = string.Empty;
                            var labelErrors = string.Empty;

                            foreach (var list in lists)
                            {
                                try
                                {
                                    var spList = web.Lists[list];

                                    var events = new ArrayList();
                                    foreach (SPEventReceiverDefinition spEventDef in spList.EventReceivers)
                                    {
                                        if ((spEventDef.Type == SPEventReceiverType.ItemAdding
                                                && string.Equals(spEventDef.Class, eventClass, StringComparison.CurrentCultureIgnoreCase))
                                            || (spEventDef.Type == SPEventReceiverType.ItemAdded
                                                && string.Equals(spEventDef.Class, eventClass, StringComparison.CurrentCultureIgnoreCase))
                                            || (spEventDef.Type == SPEventReceiverType.ItemUpdating
                                                && string.Equals(spEventDef.Class, eventClass, StringComparison.CurrentCultureIgnoreCase))
                                            || (spEventDef.Type == SPEventReceiverType.ItemDeleting
                                                && string.Equals(spEventDef.Class, eventClass, StringComparison.CurrentCultureIgnoreCase)))
                                        {
                                            events.Add(spEventDef.Id);
                                        }
                                    }

                                    try
                                    {
                                        foreach (Guid id in events)
                                        {
                                            spList.EventReceivers[id].Delete();
                                        }
                                        spList.Update();
                                    }
                                    catch (Exception ex)
                                    {
                                        Trace.TraceError("Exception Suppressed {0}", ex);
                                        labelErrors += ex.Message + "  ";
                                    }
                                    if (events.Count > 0)
                                    {
                                        badLists += "," + list;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Trace.TraceError("Exception Suppressed {0}", ex);
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(badLists))
                            {
                                badLists = badLists.Trim(',');
                                if (!string.IsNullOrWhiteSpace(labelErrors))
                                {
                                    errors = true;
                                }

                                message += string.Format(
                                    "<Web Status=\"{0}\"><Error>{1}</Error><URL><![CDATA[{2}]]></URL><Title><![CDATA[{3}]]></Title><Lists><![CDATA[{4}]]></Lists></Web>",
                                    labelErrors != ""
                                        ? "1"
                                        : "0",
                                    labelErrors,
                                    web.ServerRelativeUrl,
                                    web.Title,
                                    badLists);
                            }
                        }
                    }
                }
            }
        }

        private string DisableAllListsEvents(string xml)
        {
            string message = "";
            bool errors = false;

            SortedList arrFields = new SortedList();

            string key = "";
            string eventclass = "";

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value;
                }
                catch { }
                try
                {
                    eventclass = doc.FirstChild.Attributes["EventClass"].Value;
                }
                catch { }
                if (key != "" && eventclass != "")
                {
                    using (SPSite site = SPContext.Current.Site)
                    {
                        var spWebCollection = site.AllWebs;
                        for (int i = 0; i < spWebCollection.Count; i++)
                        {
                            using (var web = spWebCollection[i])
                            {
                                string badLists = "";
                                string lerrors = "";

                                for (int j = 0; j < web.Lists.Count; j++)
                                {
                                    SPList list = web.Lists[j];
                                    try
                                    {
                                        ArrayList arrEvents = new ArrayList();
                                        foreach (SPEventReceiverDefinition spEventDef in list.EventReceivers)
                                        {
                                            if (spEventDef.Type == SPEventReceiverType.ItemAdding && spEventDef.Class.ToLower() == eventclass.ToLower())
                                                arrEvents.Add(spEventDef.Id);

                                            if (spEventDef.Type == SPEventReceiverType.ItemAdded && spEventDef.Class.ToLower() == eventclass.ToLower())
                                                arrEvents.Add(spEventDef.Id);

                                            if (spEventDef.Type == SPEventReceiverType.ItemUpdating && spEventDef.Class.ToLower() == eventclass.ToLower())
                                                arrEvents.Add(spEventDef.Id);

                                            if (spEventDef.Type == SPEventReceiverType.ItemDeleting && spEventDef.Class.ToLower() == eventclass.ToLower())
                                                arrEvents.Add(spEventDef.Id);
                                        }

                                        try
                                        {
                                            foreach (Guid id in arrEvents)
                                            {
                                                list.EventReceivers[id].Delete();
                                            }
                                            list.Update();
                                        }
                                        catch (Exception ex)
                                        {
                                            lerrors += ex.Message + "  ";
                                        }
                                        if (arrEvents.Count > 0)
                                            badLists += "," + list.Title;
                                    }
                                    catch { }
                                }
                                if (badLists != "")
                                {
                                    badLists = badLists.Trim(',');
                                    if (lerrors != "")
                                        errors = true;

                                    message += "<Web Status=\"" + ((lerrors != "") ? "1" : "0") + "\"><Error>" + lerrors + "</Error><URL><![CDATA[" + web.ServerRelativeUrl + "]]></URL><Title><![CDATA[" + web.Title + "]]></Title><Lists><![CDATA[" + badLists + "]]></Lists></Web>";
                                }
                            }
                        }
                    }
                }
                else
                {
                    errors = true;
                    message = "<Error ID=\"101\"><![CDATA[Invalid Key or Event Class Value]]></Error>";
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }
        #endregion

        #region Features
        private string EnableFeatures(string xml)
        {
            string message = "";
            bool errors = false;

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                using (SPSite site = SPContext.Current.Site)
                {
                    foreach (XmlNode nd in doc.FirstChild.SelectNodes("Feature"))
                    {
                        try
                        {
                            site.Features.Add(new Guid(nd.InnerText), true);

                            message += "<Feature ID=\"" + nd.InnerText + "\" Status=\"0\"/>";
                        }
                        catch (Exception ex)
                        {
                            errors = true;
                            message += "<Feature ID=\"" + nd.InnerText + "\" Status=\"1\"><![CDATA[Error: " + ex.Message + "]]></Feature>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }

        private string DisableFeatures(string xml)
        {
            string message = "";
            bool errors = false;

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                using (SPSite site = SPContext.Current.Site)
                {
                    foreach (XmlNode nd in doc.FirstChild.SelectNodes("Feature"))
                    {
                        try
                        {
                            if(site.Features[new Guid(nd.InnerText)] != null)
                                site.Features.Remove(new Guid(nd.InnerText), true);

                            message += "<Feature ID=\"" + nd.InnerText + "\" Status=\"0\"/>";
                        }
                        catch (Exception ex)
                        {
                            errors = true;
                            message += "<Feature ID=\"" + nd.InnerText + "\" Status=\"1\"><![CDATA[Error: " + ex.Message + "]]></Feature>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Error ID=\"100\"><![CDATA[" + ex.Message + "]]></Error>";
            }

            if (errors)
                message = "<Result Status=\"1\">" + message + "</Result>";
            else
                message = "<Result Status=\"0\">" + message + "</Result>";

            return message;
        }
        #endregion

    }

}