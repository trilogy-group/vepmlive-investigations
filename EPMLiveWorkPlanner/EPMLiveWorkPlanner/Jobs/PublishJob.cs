using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Xml;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SharePoint.Administration;

namespace EPMLiveWorkPlanner
{
    public class PublishJob: EPMLiveCore.API.BaseJob
    {
        private Hashtable hshTaskCenterFields;
        private string taskCenterProjectField;

        private Hashtable hshLinks = new Hashtable();

        public void execute(SPSite osite, SPWeb oweb, string data)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);

                string key = "";

                try
                {
                    key = doc.FirstChild.Attributes["Key"].Value.Replace("EPMLivePlanner", "");
                }
                catch { }
                if(key != "")
                {
                    string[] project = doc.FirstChild.Attributes["ID"].Value.Split('.');


                    EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps props = EPMLiveWorkPlanner.WorkPlannerAPI.getSettings(oweb, key);

                    string taskCenterListName = props.sListTaskCenter;

                    string taskCenterFields = props.sFieldMappings;
                    taskCenterProjectField = props.sProjectField;

                    //if(projectCenterListName == "")
                    //    projectCenterListName = "Project Center";

                    if(taskCenterListName == "")
                        taskCenterListName = "Task Center";

                    if(taskCenterProjectField == "")
                        taskCenterProjectField = "Project";

                    hshTaskCenterFields = new Hashtable();

                    if(taskCenterFields != "")
                    {
                        foreach(string taskCenterField in taskCenterFields.Split('|'))
                        {
                            string[] sTaskCenterField = taskCenterField.Split(',');
                            if(!hshTaskCenterFields.Contains(sTaskCenterField[0]))
                            {
                                hshTaskCenterFields.Add(sTaskCenterField[0], sTaskCenterField[1]);
                            }
                        }
                    }

                    SPList oProjectCenter = oweb.Lists[new Guid(project[1])];
                    SPList oTaskCenter = oweb.Lists[taskCenterListName];

                    setupProjectCenter(oProjectCenter);
                    setupTaskCenter(oTaskCenter);

                    if(userid != 0)
                    {
                        SPUser user = oweb.SiteUsers.GetByID(userid);

                        using(SPSite site = new SPSite(osite.ID, user.UserToken))
                        {
                            using(SPWeb web = site.OpenWeb(oweb.ID))
                            {
                                oProjectCenter = web.Lists[new Guid(project[1])];
                                oTaskCenter = web.Lists[taskCenterListName];
                                StartPublish(doc, site, web, oProjectCenter, oTaskCenter, project[2], props, key);
                                if(osite.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null)
                                {
                                    Guid jobid = EPMLiveCore.API.Timer.AddTimerJob(osite.ID, oweb.ID, oTaskCenter.ID, "Publish Work", 81, project[0] + "." + project[1] + "." + project[2], project[2], 0, 9, "");

                                    EPMLiveCore.API.Timer.Enqueue(jobid, 0, site);
                                }
                            }
                        }
                    }
                    else
                    {
                        StartPublish(doc, osite, oweb, oProjectCenter, oTaskCenter, project[2], props, key);
                        if(osite.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null)
                        {
                            Guid jobid = EPMLiveCore.API.Timer.AddTimerJob(osite.ID, oweb.ID, oTaskCenter.ID, "Publish Work", 81, project[0] + "." + project[1] + "." + project[2], project[2], 0, 9, "");

                            EPMLiveCore.API.Timer.Enqueue(jobid, 0, osite);
                        }
                    }


                }


            }
            catch(Exception ex)
            {
                bErrors = true;
                sErrors = "Error Publishing: " + ex.Message;
            }
        }

        private void StartPublish(XmlDocument doc, SPSite site, SPWeb web, SPList oProjectCenter, SPList oTaskCenter, string projectid, EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps props, string plannerid)
        {

            SPListItem oProject = oProjectCenter.GetItemById(int.Parse(projectid));

            totalCount = doc.FirstChild.SelectNodes("Task").Count;

            string sPrefix = getPrefix(site);

            //processTask(doc.FirstChild.SelectSingleNode("Task[@UID='0']"), oProject, hshTaskCenterFields, web, sPrefix);

            publishTasks(doc, oTaskCenter, projectid, hshTaskCenterFields, taskCenterProjectField, sPrefix, props, plannerid);

            oProject.Update();

        }

        private string getPrefix(SPSite site)
        {
            try
            {
                return System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/", site.WebApplication.Name).AppSettings.Settings["prefix"].Value;
            }
            catch { }
            return "";
        }

        private void setupProjectCenter(SPList list)
        {
            //if(!list.Fields.ContainsField("IsPublished"))
            //{
            //    list.Fields.Add("IsPublish", SPFieldType.Boolean, false);
            //    SPField f = list.Fields["IsPublished"];
            //    f.Hidden = true;
            //    f.Update();
            //    list.Update();
            //}
        }

        private void setupTaskCenter(SPList list)
        {
            if(!list.Fields.ContainsField("IsPublished"))
            {
                list.Fields.Add("IsPublished", SPFieldType.Boolean, false);
                SPField f = list.Fields["IsPublished"];
                f.Hidden = true;
                f.Update();
                list.Update();
            }
            if(!list.Fields.ContainsField("taskuid"))
            {
                list.Fields.Add("taskuid", SPFieldType.Text, false);
                SPField f = list.Fields["taskuid"];
                f.Hidden = true;
                f.Update();
                list.Update();
            }
            if(!list.Fields.ContainsField("taskorder"))
            {
                list.Fields.Add("taskorder", SPFieldType.Number, false);
                SPField f = list.Fields["taskorder"];
                f.Title = "Task ID";
                f.Update();
                list.Update();
            }

            bool hasEvent = false;
            foreach(SPEventReceiverDefinition spEventDef in list.EventReceivers)
            {
                if(spEventDef.Type == SPEventReceiverType.ItemUpdating && spEventDef.Class.ToLower() == "EPMLiveCore.GenericPublishEvent")
                    hasEvent = true;
            }

            if(!hasEvent)
            {
                list.EventReceivers.Add(SPEventReceiverType.ItemUpdating, "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveCore.GenericPublishEvent");
                list.Update();
            }
        }

        private void ensureFolder(SPList list, string folder)
        {
            SPContentType itemtype = list.ContentTypes["WEFolder"];

            string fullFolder = System.IO.Path.GetDirectoryName(list.DefaultViewUrl).Replace("\\", "/");

            string[] sFolders = folder.Split('/');

            foreach(string sFolder in sFolders)
            {
                if(sFolder != "")
                {
                    bool folderfound = false;
                    try
                    {
                        SPFolder f = list.ParentWeb.GetFolder(fullFolder + "/" + sFolder);
                        folderfound = f.Exists;
                    }
                    catch { }
                    if(!folderfound)
                    {
                        SPListItem oFolder = list.Items.Add(fullFolder, SPFileSystemObjectType.Folder, sFolder);
                        oFolder["Title"] = sFolder;
                        oFolder["ContentTypeId"] = itemtype.Id;
                        oFolder.Update();
                    }
                    fullFolder += "/" + sFolder;
                }
            }
        }

        public static void MoveListItemToFolder(SPListItem item, SPFolder destinationFolder)
        {


            // Remove the site's url from the destination url
            string destDir = Microsoft.SharePoint.Utilities.SPUrlUtility.CombineUrl(destinationFolder.ParentWeb.ServerRelativeUrl, destinationFolder.Url);
            // Remove any leading/trailing forward slashes
            destDir = destDir.Trim('/');

            using(SqlConnection conn = new SqlConnection(item.ParentList.ParentWeb.Site.ContentDatabase.DatabaseConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand command = conn.CreateCommand();
                    command.Transaction = transaction;
                    command.CommandText = "update AllUserData set tp_ParentId = @tp_ParentId where tp_ListId = @ListId and tp_ID = @ItemId;";
                    command.Parameters.Add("@tp_ParentId", System.Data.SqlDbType.UniqueIdentifier);
                    command.Parameters["@tp_ParentId"].Value = destinationFolder.UniqueId;
                    command.Parameters.Add("@ListId", System.Data.SqlDbType.UniqueIdentifier);
                    command.Parameters["@ListId"].Value = item.ParentList.ID;
                    command.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                    command.Parameters["@ItemId"].Value = item.ID;
                    command.ExecuteNonQuery();
                    //string leafName;
                    //using(SqlDataReader reader = command.ExecuteReader())
                    //{
                    //    reader.Read();
                    //    leafName = reader["tp_LeafName"] as string;
                    //}

                    command = conn.CreateCommand();
                    command.Transaction = transaction;
                    command.CommandText = "update AllDocs set DirName = @NewDir, ParentId = @ParentId where ListId = @ListId and doclibrowid = @ItemId";
                    command.Parameters.Add("@NewDir", System.Data.SqlDbType.NVarChar, 256);
                    command.Parameters["@NewDir"].Value = destDir;
                    command.Parameters.Add("@ListId", System.Data.SqlDbType.UniqueIdentifier);
                    command.Parameters["@ListId"].Value = item.ParentList.ID;
                    command.Parameters.Add("@ItemId", System.Data.SqlDbType.Int);
                    command.Parameters["@ItemId"].Value = item.ID;
                    command.Parameters.Add("@ParentId", System.Data.SqlDbType.UniqueIdentifier);
                    command.Parameters["@ParentId"].Value = destinationFolder.UniqueId;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    { }
                }
                finally
                {
                    transaction.Dispose();
                }
            }
        }

        private void publishTasks(XmlDocument doc, SPList list, string projectid, Hashtable taskFields, string taskCenterProjectField, string sPrefix, EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps props, string plannerid)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            query.Lists = "<Lists><List ID=\"" + list.ID.ToString() + "\"/></Lists>";
            query.Query = "<Where><Eq><FieldRef Name=\"" + taskCenterProjectField + "\" LookupId=\"True\"/><Value Type=\"Lookup\">" + projectid + "</Value></Eq></Where>";
            query.ViewFields = "<FieldRef Name=\"Title\"/><FieldRef Name=\"taskuid\"/><FieldRef Name=\"IsPublished\"/>";

            DataTable dt = list.ParentWeb.GetSiteData(query);

            float taskCount = 0;

            SPContentType ctIteration = null;

            try
            {
                foreach(SPContentType ct in list.ContentTypes)
                {
                    if(ct.Name == props.sIterationCT)
                    {
                        ctIteration = ct;
                    }
                }
            }
            catch { }

            foreach(XmlNode ndTask in doc.FirstChild.SelectNodes("Task"))
            {
                string taskuid = ndTask.Attributes["UID"].Value;
                string spid = "";
                try
                {
                    spid = ndTask.Attributes["SPID"].Value;
                }
                catch { }
                if(taskuid != "0")
                {
                    try
                    {
                        DataRow[] dr = null;
                        try
                        {
                            dr = dt.Select("taskuid='" + taskuid + "'");
                        }
                        catch { }
                        if(dr == null || dr.Length == 0)
                        {
                            try
                            {
                                dr = dt.Select("ID='" + spid + "'");
                            }
                            catch { }
                        }
                        SPListItem liTask = null;

                        bool IsPublished = false;
                        bool newtask = false;
                        string TaskFolder = "";
                        try
                        {
                            TaskFolder = ndTask.Attributes["Folder"].Value;
                        }
                        catch { }

                        string fullFolder = System.IO.Path.GetDirectoryName(list.DefaultViewUrl).Replace("\\", "/") + TaskFolder;
                        if(TaskFolder != "")
                            ensureFolder(list, TaskFolder);

                        if(dr != null && dr.Length > 0)
                        {
                            liTask = list.GetItemById(int.Parse(dr[0]["ID"].ToString()));
                            try
                            {
                                IsPublished = (dr[0]["IsPublished"].ToString() == "1") ? true : false;
                            }
                            catch { }
                            XmlAttribute attr = doc.CreateAttribute("SPUID");
                            attr.Value = liTask.ID.ToString();
                            ndTask.Attributes.Append(attr);
                        }
                        else
                        {
                            newtask = true;

                            if(TaskFolder == "")
                                liTask = list.Items.Add();
                            else
                                liTask = list.Items.Add(fullFolder, SPFileSystemObjectType.File, ndTask.SelectSingleNode("Title").InnerText);

                        }

                        if(IsPublished || newtask)
                        {
                            liTask["Title"] = ndTask.SelectSingleNode("Title").InnerText;
                            liTask[list.Fields.GetFieldByInternalName("IsPublished").Id] = "1";
                            liTask[list.Fields.GetFieldByInternalName("Project").Id] = projectid;
                            liTask[list.Fields.GetFieldByInternalName("taskuid").Id] = taskuid;
                            liTask[list.Fields.GetFieldByInternalName("taskorder").Id] = ndTask.Attributes["ID"].Value;

                            if(props.bAgile)
                            {
                                if(ndTask.Attributes["Iteration"] != null && ndTask.Attributes["Iteration"].Value == "1" && ctIteration != null)
                                    liTask["ContentTypeId"] = ctIteration.Id;

                                if(list.Fields.ContainsField("CT" + props.sIterationCT))
                                {
                                    string iteration = "";
                                    try
                                    {
                                        iteration = doc.SelectSingleNode("//Task[@UID='" + ndTask.SelectSingleNode("Field[@Name='CT" + props.sIterationCT + "']").InnerText + "']").Attributes["SPUID"].Value;

                                        if(iteration != "")
                                        {
                                            liTask[list.Fields.GetFieldByInternalName("CT" + props.sIterationCT).Id] = iteration;
                                        }
                                    }
                                    catch { }
                                    try
                                    {
                                        ndTask.RemoveChild(ndTask.SelectSingleNode("Field[@Name='CT" + props.sIterationCT + "']"));
                                    }
                                    catch { }
                                }


                            }

                            if(!newtask)
                            {
                                string curFolder = Microsoft.SharePoint.Utilities.SPUrlUtility.CombineUrl(list.ParentWeb.ServerRelativeUrl, Microsoft.SharePoint.Utilities.SPUtility.GetUrlDirectory(liTask.Url));

                                if(fullFolder != curFolder)
                                    MoveListItemToFolder(liTask, list.ParentWeb.GetFolder(fullFolder));
                            }
                            processTask(ndTask, liTask, taskFields, list.ParentWeb, sPrefix, projectid);
                            if(newtask)
                            {
                                XmlAttribute attr = doc.CreateAttribute("SPUID");
                                attr.Value = liTask.ID.ToString();
                                ndTask.Attributes.Append(attr);
                            }
                        }
                        else
                        {
                            sErrors += "Task (" + ndTask.SelectSingleNode("Title").InnerText + ") skipped because it is waiting for update.<br>";
                        }
                        if(dr != null && dr.Length > 0)
                        {
                            dt.Rows.Remove(dr[0]);
                        }
                    }
                    catch(Exception ex)
                    {
                        bErrors = true;
                        sErrors += "Error Task UID(" + taskuid + ") Error: " + ex.Message + "<br>";
                    }
                    updateProgress(taskCount++);
                }
            }
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Select("taskuid <> ''"))
                {
                    list.Items.DeleteItemById(int.Parse(dr["id"].ToString()));
                }
            }

            if(cn.State != ConnectionState.Open)
                cn.Open();

            SqlCommand cmd = new SqlCommand("delete from plannerlink where plannerid=@plannerid and destprojectid=@projectid", cn);
            cmd.Parameters.AddWithValue("@plannerid", plannerid);
            cmd.Parameters.AddWithValue("@projectid", projectid);
            cmd.ExecuteNonQuery();

            foreach(DictionaryEntry de in hshLinks)
            {
                string[] sSource = de.Key.ToString().Split('.');
                string[] sDest = de.Value.ToString().Split('.');

                cmd = new SqlCommand("INSERT INTO plannerlink (plannerid,sourceprojectid,sourcetaskid,destprojectid,desttaskid,predecessors,successors,linked) VALUES (@plannerid,@sourceprojectid,@sourcetaskid,@destprojectid,@desttaskid,@predecessors,@successors,@linked)", cn);
                cmd.Parameters.AddWithValue("@plannerid", plannerid);
                cmd.Parameters.AddWithValue("@sourceprojectid", sSource[1]);
                cmd.Parameters.AddWithValue("@sourcetaskid", sSource[2]);
                cmd.Parameters.AddWithValue("@destprojectid", sDest[0]);
                cmd.Parameters.AddWithValue("@desttaskid", sDest[1]);
                cmd.Parameters.AddWithValue("@predecessors", sDest[2]);
                cmd.Parameters.AddWithValue("@successors", sDest[3]);
                cmd.Parameters.AddWithValue("@linked", sDest[4]);


                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        private void processTask(XmlNode ndTask, SPListItem liTask, Hashtable taskFields, SPWeb web, string sPrefix, string projectid)
        {
            try
            {
                XmlNode ndExternal = ndTask.SelectSingleNode("Field[@Name='IsExternal']");
                XmlNode ndExternalLink = ndTask.SelectSingleNode("Field[@Name='ExternalLink']");

                string preds = "";
                try
                {
                    preds = ndTask.SelectSingleNode("Field[@Name='Predecessors']").InnerText;

                    string[] sPreds = preds.Split(';');

                    preds = "";

                    foreach(string sPred in sPreds)
                    {
                        try
                        {
                            preds += "," + ndTask.OwnerDocument.FirstChild.SelectSingleNode("//Task[@ID='" + sPred + "']").Attributes["UID"].Value;
                        }
                        catch { }
                    }
                    preds = preds.Trim(',');

                }catch{}

                string succ = "";
                try
                {
                    succ = ndTask.SelectSingleNode("Field[@Name='Descendants']").InnerText;
                }catch{}

                string linked = "";
                try
                {
                    linked = ndTask.SelectSingleNode("Field[@Name='LinkedTask']").InnerText;
                }
                catch { }

                if(ndExternal.InnerText == "1" && ndExternalLink.InnerText != "")
                {
                    hshLinks.Add(ndExternalLink.InnerText, projectid + "." + ndTask.Attributes["UID"].Value + "." + preds + "." + succ + "." + linked);
                }
            }
            catch { }

            foreach(XmlNode ndField in ndTask.SelectNodes("Field"))
            {
                string ndFieldName = ndField.Attributes["Name"].Value;
                string val = ndField.InnerText;
                if(ndFieldName != "Project")
                {
                    if(taskFields.Contains(ndFieldName))
                    {
                        SPField f = null;
                        try
                        {
                            f = liTask.ParentList.Fields.GetFieldByInternalName(taskFields[ndFieldName].ToString());
                        }
                        catch { }
                        if(f != null)
                        {
                            if(val == "")
                            {
                                liTask[f.Id] = null;
                            }
                            else if(f.Type == SPFieldType.User && !val.Contains(";#") && val != "")
                            {
                                liTask[f.Id] = EPMLiveCore.CoreFunctions.getUserString(val, web, sPrefix);
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
                        if(f != null)
                        {
                            if(!f.ReadOnlyField)
                            {
                                bool isMS = false;

                                if(f.InternalName == "DueDate")
                                {
                                    try
                                    {
                                        if(liTask["Duration"].ToString() == "0")
                                            isMS = true;
                                    }
                                    catch { }
                                }

                                if(isMS)
                                {
                                    try
                                    {
                                        liTask[f.Id] = liTask[liTask.ParentList.Fields.GetFieldByInternalName("StartDate").Id];
                                    }
                                    catch { }
                                }
                                else
                                {
                                    if(val == "" || val == "NaN")
                                    {
                                        liTask[f.Id] = null;
                                    }
                                    else if(f.Type == SPFieldType.User && !val.Contains(";#") && val != "")
                                    {
                                        liTask[f.Id] = EPMLiveCore.CoreFunctions.getUserString(val, web, sPrefix);
                                    }
                                    else
                                    {
                                        liTask[f.Id] = val;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            liTask.Update();
        }
    }
}
