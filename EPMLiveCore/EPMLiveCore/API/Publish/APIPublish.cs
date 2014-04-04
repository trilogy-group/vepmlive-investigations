using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Collections;

namespace EPMLiveCore.API
{
    internal class APIPublish
    {
        internal static string GetProjectInfoFromName(string xml, SPWeb web)
        {
            string id = "";
            string sPlannerId = "";

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string project = doc.FirstChild.InnerText;


                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + project + "</Value></Eq></Where>";

                string sProjectlist = "";
                try
                {
                    sProjectlist = doc.FirstChild.Attributes["List"].Value;
                }
                catch { }
                
                if(sProjectlist == "")
                    sProjectlist = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePublisherProjectCenter", false);

                SPList sList = web.Lists[sProjectlist];

                SPListItemCollection col = sList.GetItems(query);

                if(col.Count >= 1)
                {
                    id = (web.ID + "." + sList.ID + "." + col[0].ID).ToLower();
                    Dictionary<string, PlannerDefinition> defs = CoreFunctions.GetPlannerList(web, col[0]);

                    foreach(KeyValuePair<string, PlannerDefinition> def in defs)
                    {
                        sPlannerId = def.Key;
                    }
                }
                
                
            }
            catch(Exception ex)
            {

                throw new APIException(100001, "Error: " + ex.Message);
            }

            return "<ProjectInfo ProjectId=\"" + id + "\"></ProjectInfo>"; ;
        }



        private static XmlDocument iGetPublisherSettings(string planner, SPWeb web, SPWeb lWeb)
        {
            XmlDocument docProperties = new XmlDocument();
            docProperties.LoadXml("<Properties/>");
            XmlNode ndMain = docProperties.FirstChild;

            string locked = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PJLockItems");

            string[] sLocks = new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0" };

            if(locked != "")
                sLocks = locked.Split(',');

            XmlNode nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLivePubLock", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PJLockItems");
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveType", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PJType");
            XmlAttribute attr = docProperties.CreateAttribute("Locked");
            attr.Value = sLocks[0];
            nd.Attributes.Append(attr);
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLivePubSummary", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PJSummary");
            try
            {
                attr = docProperties.CreateAttribute("Locked");
                attr.Value = sLocks[1];
                nd.Attributes.Append(attr);
            }
            catch { }
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveTimePhased", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PJTP");
            try
            {
                attr = docProperties.CreateAttribute("Locked");
                attr.Value = sLocks[2];
                nd.Attributes.Append(attr);
            }
            catch { }
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveLMF", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PJstatus");
            try
            {
                attr = docProperties.CreateAttribute("Locked");
                attr.Value = sLocks[3];
                nd.Attributes.Append(attr);
            }
            catch { }
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveResField", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PJreslink");
            try
            {
                attr = docProperties.CreateAttribute("Locked");
                attr.Value = sLocks[4];
                nd.Attributes.Append(attr);
            }
            catch { }
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveSynchFields", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PJfields");
            try
            {
                attr = docProperties.CreateAttribute("Locked");
                attr.Value = sLocks[5];
                nd.Attributes.Append(attr);
            }
            catch { }
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveUseResv3", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PJuseres");
            ndMain.AppendChild(nd);

            string flag = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "TSFlag");
            if(flag == "") flag = "Flag15";
            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveTSFlag", docProperties.NamespaceURI);
            nd.InnerText = flag;
            ndMain.AppendChild(nd);

            string number = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "TSHours");
            if(number == "") number = "Number15";
            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveTSTimesheetHours", docProperties.NamespaceURI);
            nd.InnerText = number;
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLivePCList", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "ProjectCenter");
            attr = docProperties.CreateAttribute("Locked");
            attr.Value = "1";
            nd.Attributes.Append(attr);
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveTCList", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "TaskCenter");
            attr = docProperties.CreateAttribute("Locked");
            attr.Value = "1";
            nd.Attributes.Append(attr);
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLivePCListTC", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "PCField");
            attr = docProperties.CreateAttribute("Locked");
            attr.Value = "1";
            nd.Attributes.Append(attr);
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLiveUsePerformance", docProperties.NamespaceURI);
            nd.InnerText = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + planner + "UsePerf");
            attr = docProperties.CreateAttribute("Locked");
            attr.Value = "1";
            nd.Attributes.Append(attr);
            ndMain.AppendChild(nd);

            nd = docProperties.CreateNode(XmlNodeType.Element, "EPMLivePlanner", docProperties.NamespaceURI);
            nd.InnerText = planner;
            attr = docProperties.CreateAttribute("Locked");
            attr.Value = "1";
            nd.Attributes.Append(attr);
            ndMain.AppendChild(nd);

            return docProperties;
        }

        public static string GetPublisherItemInfo(string data, SPWeb web)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);

            string projectUrl = doc.FirstChild.InnerText;

            XmlDocument docProperties = new XmlDocument();

            if(!projectUrl.EndsWith(".mpp"))
                projectUrl = projectUrl + ".mpp";

            string ret = "";

            if(projectUrl.StartsWith("https://") || projectUrl.StartsWith("http://"))
            {
                string planner = GetPlannerFromPJUrl(web, projectUrl);

                string pjName = System.Web.HttpUtility.UrlDecode(System.IO.Path.GetFileNameWithoutExtension(projectUrl));

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    Guid lWeb = CoreFunctions.getLockedWeb(web);

                    if(lWeb != Guid.Empty)
                    {
                        using(SPSite site = new SPSite(web.Site.ID))
                        {
                            using(SPWeb web2 = site.OpenWeb(lWeb))
                            {
                                ret = iGetPublisherItemInfo(pjName, planner, web, web2);
                            }
                        }
                    }
                    else
                    {
                        ret = iGetPublisherItemInfo(pjName, planner, web, web);
                    }

                });
            }

            return ret;
        }

        private static string iGetPublisherItemInfo(string pjName, string planner, SPWeb web, SPWeb lockWeb)
        {
            string projectcenter = EPMLiveCore.CoreFunctions.getConfigSetting(lockWeb, "EPMLivePlanner" + planner + "ProjectCenter");

            SPList list = web.Lists.TryGetList(projectcenter);

            if(list != null)
            {
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type=\"Text\">" + pjName + "</Value></Eq></Where>";

                SPListItemCollection lic = list.GetItems(query);
                if(lic.Count > 0)
                {
                    return "<PublisherItemInfo ListId=\"" + list.ID + "\" ItemId=\"" + lic[0].ID + "\"/>";
                }
                else
                {
                    return "<PublisherItemInfo/>";
                }
            }

            return "<PublisherItemInfo/>";
        }

        public static string GetPublisherSettings(string data, SPWeb web)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);

            string projectUrl = System.Web.HttpUtility.UrlDecode(doc.FirstChild.InnerText);

            XmlDocument docProperties = new XmlDocument();

            if(!projectUrl.EndsWith(".mpp"))
                projectUrl = projectUrl + ".mpp";

            if(projectUrl.StartsWith("https://") || projectUrl.StartsWith("http://"))
            {
                string planner = GetPlannerFromPJUrl(web, projectUrl);

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    Guid lWeb = CoreFunctions.getLockedWeb(web);

                    if(lWeb != Guid.Empty)
                    {
                        using(SPSite site = new SPSite(web.Site.ID))
                        {
                            using(SPWeb web2 = site.OpenWeb(lWeb))
                            {
                                docProperties = iGetPublisherSettings(planner, web, web2);
                            }
                        }
                    }
                    else
                    {
                        docProperties = iGetPublisherSettings(planner, web, web);
                    }

                });
            }
            else
            {
                throw new APIException(1000, "Not valid URL.");
            }
            return docProperties.OuterXml;

        }

        private static string GetPlannerFromPJUrl(SPWeb web, string url)
        {

            SPFile f = web.GetFile(url);

            if(!f.Exists)
            {
                throw new APIException(4070, "Can't find project file");
            }
            else
            {

                return f.ParentFolder.Name;

            }
        }

        public static string Publish(string data)
        {
            string message = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);

                //string sProjectName = doc.FirstChild.Attributes["ProjectName"].Value;
                string sPlannerID = doc.FirstChild.Attributes["PlannerID"].Value;
                string sID = doc.FirstChild.Attributes["ID"].Value;
                
                XmlAttribute attr = doc.CreateAttribute("Key");
                attr.Value = "EPMLivePlanner" + doc.FirstChild.Attributes["PlannerID"].Value;
                doc.FirstChild.Attributes.Append(attr);

                SPSite oSite = SPContext.Current.Site;
                {
                    SPWeb oWeb = SPContext.Current.Web;
                    {
                        string sPlannerList = CoreFunctions.getLockConfigSetting(oWeb, "EPMLivePlanner" + sPlannerID + "ProjectCenter", false);

                        if(sPlannerList != "")
                        {
                            SPList oList = oWeb.Lists.TryGetList(sPlannerList);

                            if(oList != null)
                            {
                                doc.FirstChild.Attributes["ID"].Value = oWeb.ID  + "." + oList.ID + "." + doc.FirstChild.Attributes["ID"].Value;

                                int status = 2;

                                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(oSite.WebApplication.Id));

                                SPSecurity.RunWithElevatedPrivileges(delegate()
                                {
                                    cn.Open();
                                });

                                SqlCommand cmd = new SqlCommand("select timerjobuid,status from vwQueueTimerLog where siteguid=@siteguid and webguid=@webguid and listguid=@listguid and itemid=@itemid and jobtype=9 and [key] = @key", cn);
                                cmd.Parameters.AddWithValue("@siteguid", oSite.ID);
                                cmd.Parameters.AddWithValue("@webguid", oWeb.ID);
                                cmd.Parameters.AddWithValue("@listguid", oList.ID);
                                cmd.Parameters.AddWithValue("@itemid", sID);
                                cmd.Parameters.AddWithValue("@key", sPlannerID);
                                SqlDataReader dr = cmd.ExecuteReader();

                                Guid tJob = Guid.Empty;

                                if(!dr.Read())
                                {
                                    tJob = Guid.NewGuid();
                                    dr.Close();
                                    cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid, itemid, jobdata, [key]) VALUES (@timerjobuid, @siteguid, 9, 'Project Publish', 9, @webguid, @listguid, @itemid, @jobdata, @key)", cn);
                                    cmd.Parameters.AddWithValue("@siteguid", oSite.ID.ToString());
                                    cmd.Parameters.AddWithValue("@webguid", oWeb.ID);
                                    cmd.Parameters.AddWithValue("@listguid", oList.ID);
                                    cmd.Parameters.AddWithValue("@itemid", sID);
                                    cmd.Parameters.AddWithValue("@jobdata", doc.FirstChild.OuterXml);
                                    cmd.Parameters.AddWithValue("@timerjobuid", tJob);
                                    cmd.Parameters.AddWithValue("@key", sPlannerID);
                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    tJob = dr.GetGuid(0);
                                    if(!dr.IsDBNull(1))
                                        status = dr.GetInt32(1);

                                    dr.Close();

                                    cmd = new SqlCommand("update timerjobs set jobdata=@jobdata where timerjobuid=@timerjobuid", cn);
                                    cmd.Parameters.AddWithValue("@jobdata", doc.FirstChild.OuterXml);
                                    cmd.Parameters.AddWithValue("@timerjobuid", tJob);
                                    cmd.ExecuteNonQuery();
                                }

                                if(status == 2)
                                {
                                    if(tJob != Guid.Empty)
                                    {
                                        CoreFunctions.enqueue(tJob, 0);
                                        message = "Success";
                                    }

                                }
                                else
                                {
                                    throw new APIException(4019, "Item Already Queued");
                                }

                                cn.Close();
                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                throw new APIException(4010, ex.Message);
            }
            return message;
        }

        public static string PublishStatus(string xml)
        {
            string message = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string sPlannerID = doc.FirstChild.Attributes["PlannerID"].Value;
                string sID = doc.FirstChild.Attributes["ID"].Value;

                //string[] project = doc.FirstChild.Attributes["ID"].Value.Split('.');
                string showresults = doc.FirstChild.Attributes["ShowResults"].Value;

                SPSite site = SPContext.Current.Site;
                {
                    SPWeb oWeb = SPContext.Current.Web;
                    {
                        string sPlannerList = CoreFunctions.getLockConfigSetting(oWeb, "EPMLivePlanner" + sPlannerID + "ProjectCenter", false);
                        if(sPlannerList != "")
                        {
                            SPList oList = oWeb.Lists.TryGetList(sPlannerList);

                            if(oList != null)
                            {
                                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                                SPSecurity.RunWithElevatedPrivileges(delegate()
                                {
                                    cn.Open();
                                });
                                SqlCommand cmd = new SqlCommand("select percentComplete,status,dtfinished,result,resulttext from vwQueueTimerLog where siteguid=@siteguid and webguid=@webguid and listguid=@listguid and itemid=@itemid and jobtype=9 and [key] = @key", cn);
                                cmd.Parameters.AddWithValue("@siteguid", site.ID);
                                cmd.Parameters.AddWithValue("@webguid", oWeb.ID);
                                cmd.Parameters.AddWithValue("@listguid", oList.ID);
                                cmd.Parameters.AddWithValue("@itemid", sID);
                                cmd.Parameters.AddWithValue("@key", sPlannerID);
                                
                                SqlDataReader dr = cmd.ExecuteReader();

                                Guid tJob = Guid.Empty;

                                if(dr.Read())
                                {
                                    string status = "";
                                    string result = (dr.IsDBNull(3)) ? "" : dr.GetString(3);
                                    string resulttext = (dr.IsDBNull(4)) ? "" : dr.GetString(4);
                                    string dtfinish = (dr.IsDBNull(2)) ? "" : dr.GetDateTime(2).ToString();

                                    switch(dr.GetInt32(1))
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
                                    if(showresults.ToLower() == "true")
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
                }

            }
            catch(Exception ex)
            {
                 throw new APIException(4020, ex.Message);
            }


            return message;
        }

        public static string GetUpdateCount(string xml, SPWeb oWeb)
        {
            string message = "";

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string sPlannerID = doc.FirstChild.Attributes["PlannerID"].Value;
                string sID = doc.FirstChild.Attributes["ID"].Value;

                string key = "";

                try
                {
                    key = "EPMLivePlanner" + sPlannerID;
                }
                catch { }
                if(key != "")
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using(SPSite site = new SPSite(oWeb.Site.ID))
                        {
                            using(SPWeb web = site.OpenWeb(oWeb.ID))
                            {
                                string sPlannerList = CoreFunctions.getLockConfigSetting(web, "EPMLivePlanner" + sPlannerID + "ProjectCenter", false);

                                if(sPlannerList != "")
                                {
                                    SPList oProjectCenter = web.Lists.TryGetList(sPlannerList);

                                    if(oProjectCenter != null)
                                    {
                                        string taskCenterListName = CoreFunctions.getLockConfigSetting(web, key + "TaskCenter", false);
                                        string taskCenterProjectField = CoreFunctions.getLockConfigSetting(web, key + "TaskCenterProjectField", false);
                                        if(taskCenterProjectField == "")
                                            taskCenterProjectField = "Project";

                                        SPList oTaskCenter = web.Lists[taskCenterListName];
                                        SPListItem oProject = oProjectCenter.GetItemById(int.Parse(sID));


                                        SPSiteDataQuery query = new SPSiteDataQuery();
                                        query.Lists = "<Lists><List ID=\"" + oTaskCenter.ID.ToString() + "\"/></Lists>";
                                        query.Query = "<Where><And><Eq><FieldRef Name=\"" + taskCenterProjectField + "\" LookupId=\"True\"/><Value Type=\"Lookup\">" + sID + "</Value></Eq><Neq><FieldRef Name=\"IsPublished\"/><Value Type=\"Boolean\">1</Value></Neq></And></Where>";
                                        query.ViewFields = "<FieldRef Name=\"Title\"/><FieldRef Name=\"taskuid\"/><FieldRef Name=\"IsPublished\"/>";
                                        query.QueryThrottleMode = SPQueryThrottleOption.Override;
                                        string limit = EPMLiveCore.CoreFunctions.getConfigSetting(oWeb, "updateperflimit");

                                        if(limit != "")
                                        {
                                            try
                                            {
                                                query.RowLimit = uint.Parse(limit);
                                            }
                                            catch { }
                                        }

                                        DataTable dt = oTaskCenter.ParentWeb.GetSiteData(query);

                                        message = dt.Rows.Count.ToString();
                                        
                                    }
                                }
                            }
                        }
                    });
                }
                else
                {
                    throw new APIException(4031, "Invalid Key");
                }
            }
            catch(Exception ex)
            {
                throw new APIException(4032, ex.Message);
            }

            return message;
        }

        public static string ProcessUpdates(string xml, SPWeb oWeb)
        {
            string message = "";
            bool errors = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string sPlannerID = doc.FirstChild.Attributes["PlannerID"].Value;
                string sID = doc.FirstChild.Attributes["ID"].Value;

                string key = "";

                try
                {
                    key = "EPMLivePlanner" + sPlannerID;
                }
                catch { }

                if(key != "")
                {
                    SPSite site = SPContext.Current.Site;
                    {
                        SPWeb web = SPContext.Current.Web;
                        {
                            web.AllowUnsafeUpdates = true;

                            string sPlannerList = CoreFunctions.getLockConfigSetting(web, "EPMLivePlanner" + sPlannerID + "ProjectCenter", false);

                            if(sPlannerList != "")
                            {
                                SPList oProjectCenter = web.Lists.TryGetList(sPlannerList);

                                if(oProjectCenter != null)
                                {
                                    string taskCenterListName = CoreFunctions.getLockConfigSetting(web, key + "TaskCenter", false);
                                    string taskCenterFields = CoreFunctions.getLockConfigSetting(web, key + "TaskCenterFields", false);
                                    string taskCenterProjectField = CoreFunctions.getLockConfigSetting(web, key + "TaskCenterProjectField", false);
                                    if(taskCenterProjectField == "")
                                        taskCenterProjectField = "Project";

                                    Hashtable hshTaskCenterFields = new Hashtable();
                                    if(taskCenterFields != "")
                                    {
                                        foreach(string taskCenterField in taskCenterFields.Split('|'))
                                        {
                                            string[] sTaskCenterField = taskCenterField.Split(',');
                                            if(!hshTaskCenterFields.Contains(sTaskCenterField[0]))
                                            {
                                                hshTaskCenterFields.Add(sTaskCenterField[1], sTaskCenterField[0]);
                                            }
                                        }
                                    }
                                    SPList oTaskCenter = web.Lists[taskCenterListName];

                                    SPListItem oProject = oProjectCenter.GetItemById(int.Parse(sID));

                                    message = "<Project>";

                                    foreach(XmlNode ndTask in doc.FirstChild.SelectNodes("Task"))
                                    {
                                        string itemid = ndTask.Attributes["ItemID"].Value;

                                        try
                                        {
                                            SPListItem li = oTaskCenter.GetItemById(int.Parse(itemid));

                                            li["IsPublished"] = "1";
                                            if(ndTask.Attributes["Status"].Value == "1")
                                                li["Publisher_x0020_Approval_x0020_S"] = "Approved";
                                            else
                                                li["Publisher_x0020_Approval_x0020_S"] = "Rejected";

                                            li["Publisher_x0020_Approval_x0020_C"] = ndTask.InnerText;
                                            web.AllowUnsafeUpdates = true;

                                            try
                                            {
                                                if(ndTask.Attributes["taskuid"] != null)
                                                {
                                                    li["taskuid"] = ndTask.Attributes["taskuid"].Value;
                                                }

                                            }
                                            catch { }

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

                                    if(GetUpdateCount(xml, oWeb) == "0")
                                    {
                                        if(oProjectCenter.Fields.ContainsFieldWithInternalName("PendingUpdates"))
                                        {
                                            SPField fPend = oProjectCenter.Fields.GetFieldByInternalName("PendingUpdates");

                                            oProject[fPend.Id] = 0;
                                            oProject.SystemUpdate();
                                        }   
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new APIException(4051, "Invalid Key");
                }
            }
            catch(Exception ex)
            {
                throw new APIException(4052, ex.Message);
            }

            if(errors)
                throw new APIException(4055, message);
            

            return message;
        }

        public static string GetUpdates(string xml, SPWeb oWeb)
        {
            string message = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string sPlannerID = doc.FirstChild.Attributes["PlannerID"].Value;
                string sID = doc.FirstChild.Attributes["ID"].Value;
                int userType = 0;
                string dateformat = "";
                try
                {
                    dateformat = doc.FirstChild.Attributes["DateFormat"].Value;
                }
                catch { }
                try
                {
                    int.TryParse(doc.FirstChild.Attributes["UserType"].Value, out userType);
                }
                catch { }
                string key = "";

                try
                {
                    key = "EPMLivePlanner" + sPlannerID;
                }
                catch { }

                if(key != "")
                {

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using(SPSite site = new SPSite(oWeb.Site.ID))
                        {
                            using(SPWeb web = site.OpenWeb(oWeb.ID))
                            {
                                string sPlannerList = CoreFunctions.getLockConfigSetting(web, "EPMLivePlanner" + sPlannerID + "ProjectCenter", false);

                                if(sPlannerList != "")
                                {
                                    SPList oProjectCenter = web.Lists.TryGetList(sPlannerList);

                                    if(oProjectCenter != null)
                                    {
                                        string taskCenterListName = CoreFunctions.getLockConfigSetting(web, key + "TaskCenter", false);
                                        string taskCenterFields = CoreFunctions.getLockConfigSetting(web, key + "TaskCenterFields", false);
                                        string taskCenterProjectField = CoreFunctions.getLockConfigSetting(web, key + "TaskCenterProjectField", false);
                                        if(taskCenterProjectField == "")
                                            taskCenterProjectField = "Project";

                                        string resUrl = CoreFunctions.getLockConfigSetting(web, "EPMLiveResourceURL", true);

                                        DataTable dtTeam = null;
                                        dtTeam = APITeam.GetResourcePool("", web);

                                        /*if(resUrl.ToLower() == web.ServerRelativeUrl.ToLower())
                                        {
                                        
                                        }
                                        else
                                        {
                                            using(SPWeb rweb = web.Site.OpenWeb(resUrl))
                                            {
                                                dtTeam = APITeam.getTeam(rweb, "", "", true);
                                            }
                                        }*/

                                        Hashtable hshTaskCenterFields = new Hashtable();
                                        if(taskCenterFields != "")
                                        {
                                            foreach(string taskCenterField in taskCenterFields.Split('|'))
                                            {
                                                string[] sTaskCenterField = taskCenterField.Split(',');
                                                if(!hshTaskCenterFields.Contains(sTaskCenterField[0]))
                                                {
                                                    hshTaskCenterFields.Add(sTaskCenterField[1], sTaskCenterField[0]);
                                                }
                                            }
                                        }

                                        SPListItem oProject = oProjectCenter.GetItemById(int.Parse(sID));

                                        SPList oTaskCenter = web.Lists[taskCenterListName];

                                        SPSiteDataQuery query = new SPSiteDataQuery();
                                        query.Lists = "<Lists><List ID=\"" + oTaskCenter.ID.ToString() + "\"/></Lists>";
                                        query.Query = "<Where><And><Eq><FieldRef Name=\"" + taskCenterProjectField + "\" LookupId=\"True\"/><Value Type=\"Lookup\">" + sID + "</Value></Eq><Neq><FieldRef Name=\"IsPublished\"/><Value Type=\"Boolean\">1</Value></Neq></And></Where>";
                                        query.ViewFields = "<FieldRef Name=\"Title\"/>";
                                        query.QueryThrottleMode = SPQueryThrottleOption.Override;

                                        string limit = EPMLiveCore.CoreFunctions.getConfigSetting(oWeb, "updateperflimit");

                                        if(limit != "")
                                        {
                                            try
                                            {
                                                query.RowLimit = uint.Parse(limit);
                                            }
                                            catch { }
                                        }

                                        DataTable dt = oTaskCenter.ParentWeb.GetSiteData(query);

                                        message = "<Project>" + buildTasks(dt, hshTaskCenterFields, oTaskCenter, userType, dtTeam, dateformat) + "</Project>";

                                    }
                                }
                            }
                        }
                    });
                }
                else
                {
                    throw new APIException(4041, "Invalid Key");
                }
            }
            catch(Exception ex)
            {
                throw new APIException(4042, ex.Message);
            }

            return message;
        }

        private static string buildTask(SPField oField, SPListItem li, SPList oTaskCenter, string dateformat, int userType, DataTable dtTeam, Hashtable hshTaskCenterFields)
        {
            StringBuilder sb = new StringBuilder();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(oField.SchemaXml);

            string val = "";
            try
            {
                val = oTaskCenter.Fields[oField.Id].GetFieldValue(li[oField.Id].ToString()).ToString();
            }
            catch { }
            if(oField.Type == SPFieldType.Number || oField.Type == SPFieldType.Currency)
            {
                try
                {
                    System.Globalization.NumberFormatInfo providerEn = new System.Globalization.NumberFormatInfo();
                    providerEn.NumberDecimalSeparator = ".";
                    providerEn.NumberGroupSeparator = ",";
                    providerEn.NumberGroupSizes = new int[] { 3 };

                    val = Convert.ToDouble(li[oField.Id].ToString()).ToString(providerEn);
                }
                catch { }
            }
            else if(oField.Type == SPFieldType.DateTime)
            {
                try
                {
                    if(dateformat == "")
                        val = DateTime.Parse(li[oField.Id].ToString()).ToString("s");
                    else if(dateformat == "0")
                        val = DateTime.Parse(li[oField.Id].ToString()).ToString();
                    else
                        val = DateTime.Parse(li[oField.Id].ToString()).ToString(dateformat);
                }
                catch { }
            }
            else if(oField.Type == SPFieldType.Boolean)
            {
                try
                {
                    if(bool.Parse(li[oField.Id].ToString()))
                        val = "1";
                    else
                        val = "0";
                }
                catch { }
            }
            else if(oField.Type == SPFieldType.User)
            {

                try
                {
                    val = "";
                    SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(oTaskCenter.ParentWeb, li[oField.Id].ToString());
                    foreach(SPFieldUserValue uv in uvc)
                    {
                        switch(userType)
                        {
                            case 0:
                                val += "," + uv.User.LoginName;
                                break;
                            case 1:
                                val += "," + uv.User.ID;
                                break;
                            case 2:
                                val += "," + uv.User.LoginName;
                                break;
                            case 3:
                                if(dtTeam != null)
                                {
                                    DataRow[] drMember = dtTeam.Select("SPID='" + uv.LookupId + "'");
                                    if(drMember.Length > 0)
                                        val += ";" + drMember[0]["ID"];
                                }
                                break;
                        }
                    }
                    val = val.Trim(';');
                }
                catch { }
            }
            if(hshTaskCenterFields.Contains(oField.InternalName))
                sb.Append("<Field Name=\"" + hshTaskCenterFields[oField.InternalName].ToString() + "\"><![CDATA[" + val + "]]></Field>");
            else
                sb.Append("<Field Name=\"" + oField.InternalName + "\"><![CDATA[" + val + "]]></Field>");


            return sb.ToString();
        }

        private static string buildTasks(DataTable dt, Hashtable hshTaskCenterFields, SPList oTaskCenter, int userType, DataTable dtTeam, string dateformat)
        {
            GridGanttSettings gSettings = new GridGanttSettings(oTaskCenter);

            Dictionary<string, Dictionary<string, string>> fieldProperties = ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);

            SortedList arrWPFields = ReflectionMethods.GetWorkPlannerStatusFields(oTaskCenter.ParentWeb, oTaskCenter.Title);

            StringBuilder sb = new StringBuilder();

            foreach(DataRow dr in dt.Rows)
            {
                SPListItem li = null;
                try
                {
                    li = oTaskCenter.GetItemById(int.Parse(dr["ID"].ToString()));
                }
                catch { }

                if(li != null)
                {
                    string id = "";
                    string uid = "";
                    try
                    {
                        id = li["taskorder"].ToString();
                    }
                    catch { }
                    try
                    {
                        uid = li["taskuid"].ToString();
                    }
                    catch { }
                    sb.Append("<Task ID=\"" + id + "\" UID=\"" + uid + "\" ItemID=\"" + li.ID + "\">");
                    sb.Append("<Field Name=\"Title\"><![CDATA[" + li.Title + "]]></Field>");
                    try
                    {
                        SPFieldUserValue uv = new SPFieldUserValue(oTaskCenter.ParentWeb, li["Editor"].ToString());
                        sb.Append("<Field Name=\"Editor\"><![CDATA[" + uv.LookupValue + "]]></Field>");
                    }
                    catch { }
                    try
                    {
                        if(li["IsAssignment"].ToString() == "True")
                            sb.Append("<Field Name=\"IsAssignment\"><![CDATA[1]]></Field>");
                        else
                            sb.Append("<Field Name=\"IsAssignment\"><![CDATA[0]]></Field>");
                    }
                    catch { }
                    try
                    {
                        sb.Append("<Field Name=\"TaskHierarchy\"><![CDATA[" + li["TaskHierarchy"] + "]]></Field>");
                    }
                    catch { }

                    foreach(SPField oField in oTaskCenter.Fields)
                    {
                        //if(arrWPFields.Count > 0)
                        //{
                        if(arrWPFields.Contains(oField.InternalName))
                        {
                            sb.Append(buildTask(oField, li, oTaskCenter, dateformat, userType, dtTeam, hshTaskCenterFields));
                        }
                        else
                        {
                            if(oField.ShowInEditForm != null && oField.ShowInEditForm.Value && EditableFieldDisplay.isEditable(li, oField, fieldProperties) && oField.Type != SPFieldType.Calculated)
                                sb.Append(buildTask(oField, li, oTaskCenter, dateformat, userType, dtTeam, hshTaskCenterFields));
                        }
                    }

                    sb.Append("</Task>");
                }
            }

            return sb.ToString();
        }
    }

}
