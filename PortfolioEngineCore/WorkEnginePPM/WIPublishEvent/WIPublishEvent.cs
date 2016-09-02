using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Threading;
using System.Xml;
using System.Collections;
using System.Data;
using System.ComponentModel;

namespace WorkEnginePPM.WIPublishEvent
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class WIPublishEvent : SPItemEventReceiver
    {
        public struct RunnerData
        {
            public int item;
            public Guid list;
            public Guid web;
            public Guid site;
        }

        public override void ItemUpdated(SPItemEventProperties properties)
        {
            try
            {
                if (properties.ListItem["Status"].ToString() == "Queued")
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.WorkerReportsProgress = true;
                    bw.WorkerSupportsCancellation = true;

                    bw.DoWork += execute;

                    RunnerData rd = new RunnerData();
                    rd.list = properties.ListId;
                    rd.item = properties.ListItemId;
                    rd.web = properties.Web.ID;
                    rd.site = properties.SiteId;

                    bw.RunWorkerAsync(rd);
                }
            }
            catch { }
        }

        public void execute(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);

            int totalCount = 0;
            RunnerData rd = (RunnerData)e.Argument;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate(){
                    using (SPSite site = new SPSite(rd.site))
                    {
                        using (SPWeb rWeb = site.OpenWeb(rd.web))
                        {
                            string sErrors = "";
                            bool bErrors = false;

                            SPList list = rWeb.Lists[rd.list];
                            SPListItem li = list.GetItemById(rd.item);
                            li["Status"] = "Processing";
                            li.Update();

                            SPFile f = li.File;

                            try
                            {
                                
                                byte[] oBytes = (byte[])f.OpenBinary();

                                string data = System.Text.ASCIIEncoding.ASCII.GetString(oBytes);

                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(data);

                                string key = "";

                                try
                                {
                                    key = doc.FirstChild.Attributes["Key"].Value;
                                }
                                catch { }
                                if (key != "")
                                {
                                    string[] project = doc.FirstChild.Attributes["ID"].Value.Split('.');

                                    using (SPWeb web = site.OpenWeb(new Guid(project[0])))
                                    {
                                        string taskCenterListName = ConfigFunctions.getLockConfigSetting(site.RootWeb, key + "TaskCenter", false);
                                        string taskCenterFields = ConfigFunctions.getLockConfigSetting(site.RootWeb, key + "TaskCenterFields", false);
                                        string taskCenterProjectField = ConfigFunctions.getLockConfigSetting(site.RootWeb, key + "TaskCenterProjectField", false);

                                        if (taskCenterListName == "")
                                            taskCenterListName = "Task Center";

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
                                                    hshTaskCenterFields.Add(sTaskCenterField[0], sTaskCenterField[1]);
                                                }
                                            }
                                        }

                                        SPList oProjectCenter = web.Lists[new Guid(project[1])];
                                        SPList oTaskCenter = web.Lists[taskCenterListName];

                                        setupTaskCenter(oTaskCenter);

                                        SPListItem oProject = oProjectCenter.GetItemById(int.Parse(project[2]));
                                        string projectid = oProject.ID.ToString();

                                        totalCount = doc.FirstChild.SelectNodes("Task").Count;

                                        publishTasks(doc, oTaskCenter, projectid, hshTaskCenterFields, taskCenterProjectField, ref bErrors, ref sErrors, totalCount, li);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                bErrors = true;
                                sErrors = "Error: " + ex.Message;
                            }

                            li["PercentComplete"] = 100;
                            li["Status"] = "Completed";
                            li["ResultText"] = sErrors;
                            li["FinishDate"] = DateTime.Now;
                            if (bErrors)
                            {
                                li["Result"] = "Errors";
                            }
                            else
                            {
                                li["Result"] = "No Errors";
                            }

                            li.Update();
                        }
                    }
                });
            }
            catch
            {
            }
        }

        private void setupTaskCenter(SPList list)
        {
            if (!list.Fields.ContainsField("PubUpdate"))
            {
                list.Fields.Add("PubUpdate", SPFieldType.Boolean, false);
                SPField f = list.Fields["PubUpdate"];
                f.Hidden = true;
                f.Update();
                list.Update();
            }
            bool hasEvent = false;
            foreach (SPEventReceiverDefinition spEventDef in list.EventReceivers)
            {
                if (spEventDef.Type == SPEventReceiverType.ItemUpdating && spEventDef.Class.ToLower() == "EPMLiveCore.GenericPublishEvent")
                    hasEvent = true;
            }

            if (!hasEvent)
            {
                list.EventReceivers.Add(SPEventReceiverType.ItemUpdating, "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveCore.GenericPublishEvent");
                list.Update();
            }
        }


        private void publishTasks(XmlDocument doc, SPList list, string projectid, Hashtable taskFields, string taskCenterProjectField, ref bool bErrors, ref string sErrors, float totalCount, SPListItem li)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            query.Lists = "<Lists><List ID=\"" + list.ID.ToString() + "\"/></Lists>";
            query.Query = "<Where><Eq><FieldRef Name=\"" + taskCenterProjectField + "\" LookupId=\"True\"/><Value Type=\"Lookup\">" + projectid + "</Value></Eq></Where>";
            query.ViewFields = "<FieldRef Name=\"Title\"/><FieldRef Name=\"taskuid\"/><FieldRef Name=\"PubUpdate\"/>";

            DataTable dt = list.ParentWeb.GetSiteData(query);

            float taskCount = 0;
            float lastPercent = 0;

            string sPrefix = EPMLiveCore.CoreFunctions.getPrefix();

            foreach (XmlNode ndTask in doc.FirstChild.SelectNodes("Task"))
            {
                string taskuid = ndTask.Attributes["UID"].Value;
                try
                {
                    DataRow[] dr = null;
                    try
                    {
                        dr = dt.Select("taskuid='" + taskuid + "'");
                    }
                    catch { }
                    SPListItem liTask = null;
                    bool PubUpdate = false;
                    if (dr != null && dr.Length > 0)
                    {
                        liTask = list.GetItemById(int.Parse(dr[0]["ID"].ToString()));
                        bool.TryParse(dr[0]["PubUpdate"].ToString(), out PubUpdate);
                    }
                    else
                    {
                        liTask = list.Items.Add();
                    }

                    if (!PubUpdate)
                    {
                        liTask["Title"] = ndTask.SelectSingleNode("Title").InnerText;
                        liTask["PubUpdate"] = 0;
                        liTask["Project"] = projectid;
                        liTask["taskuid"] = taskuid;
                        liTask["taskorder"] = ndTask.Attributes["ID"].Value;

                        processTask(ndTask, liTask, taskFields, list.ParentWeb, sPrefix);
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sErrors += "Error Task UID(" + taskuid + ") Error: " + ex.Message + "<br>";
                }

                updateProgress(taskCount++, totalCount, ref lastPercent, li);
            }
        }

        protected void updateProgress(float newCount, float totalCount, ref float lastPercent, SPListItem li)
        {
            float percent = (newCount + 1) / totalCount * 100;
            if (percent + 10 >= lastPercent)
            {
                li["PercentComplete"] = percent;
                li.Update();

                lastPercent = percent;
                
            }
        }

        private void processTask(XmlNode ndTask, SPListItem liTask, Hashtable taskFields, SPWeb web, string sPrefix)
        {
            foreach (XmlNode ndField in ndTask.SelectNodes("Field"))
            {
                string ndFieldName = ndField.Attributes["Name"].Value;
                string val = ndField.InnerText;

                if (taskFields.Contains(ndFieldName))
                {
                    SPField f = null;
                    try
                    {
                        f = liTask.ParentList.Fields.GetFieldByInternalName(taskFields[ndFieldName].ToString());
                    }
                    catch { }
                    if (f != null)
                    {
                        if (val == "")
                        {
                            liTask[f.Id] = null;
                        }
                        else if (f.Type == SPFieldType.User && !val.Contains(";#") && val != "")
                        {
                            liTask[f.Id] = ConfigFunctions.getUserString(val, web, sPrefix);
                        }
                        else
                        {
                            liTask[f.Id] = val;
                        }
                    }
                }
                else
                {
                    SPField f = null;
                    try
                    {
                        f = liTask.ParentList.Fields.GetFieldByInternalName(ndFieldName);
                    }
                    catch { }
                    if (f != null)
                    {
                        if (val == "")
                        {
                            liTask[f.Id] = null;
                        }
                        else if (f.Type == SPFieldType.User && !val.Contains(";#") && val != "")
                        {
                            liTask[f.Id] = ConfigFunctions.getUserString(val, web, sPrefix);
                        }
                        else
                        {
                            liTask[f.Id] = val;
                        }
                    }
                }
            }

            liTask.Update();
        }

        
    }
}
