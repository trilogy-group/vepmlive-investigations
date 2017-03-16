using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Text;
using System.Xml;
using System.Data.SqlClient;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class WorkPlannerAction : System.Web.UI.Page
    {
        protected string output = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            switch (Request["Action"])
            {
                case "SaveTemplate":
                    SaveTemplate();
                    break;
                case "GetImportStatus":
                    GetImportStatus();
                    break;
                case "ApplyTemplate":
                    ApplyTemplate();
                    break;
                case "SaveView":
                    saveview();
                    break;
                case "DeleteView":
                    DeleteView();
                    break;
                case "Publish":
                    Publish();
                    break;
                case "PublishStatus":
                    PublishStatus();
                    break;
                case "GetUpdateCount":
                    GetUpdateCount();
                    break;
                case "ProcessUpdates":
                    ProcessUpdates();
                    break;
                case "GetTeam":
                    GetTeam();
                    break;
                case "SetProperty":
                    SetProperty();
                    break;
                case "SaveProject":
                    SaveProject();
                    break;
                case "GoToList":
                    GoToList();
                    break;
                case "RenameView":
                    RenameView();
                    break;
                case "GetRowInfo":
                    GetRowInfo();
                    break;
                case "CheckResources":

                    string id = Request["itemid"];

                    SPWeb web = SPContext.Current.Web;
                    SPList list = web.Lists[new Guid(Request["listid"])];
                    SPQuery query = new SPQuery();
                    query.Query = "<Where><And><Eq><FieldRef Name='Project' LookupId='True'/><Value Type='Lookup'>" + Request["pitemid"] + "</Value></Eq><Eq><FieldRef Name='taskuid'/><Value Type='Text'>" + Request["itemid"] + "</Value></Eq></And></Where>";

                    string newid = "";

                    SPListItemCollection lic = list.GetItems(query);
                    if (lic.Count > 0)
                    {
                        newid = lic[0].ID.ToString();
                    }

                    string url = "";

                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        using (SPSite site = new SPSite(web.Site.ID))
                        {
                            using (SPWeb oweb = site.OpenWeb(web.ID))
                            {
                                url = EPMLiveCore.CoreFunctions.getConfigSetting(oweb, "EPMLiveResourceURL");
                            }
                        }
                        if (url == "/")
                            url = "";
                    });
                    url += "/_layouts/epmlive/checkresgantt.aspx?showgantt=1&startdate=" + Request["startdate"] + "&enddate=" + Request["enddate"] + "&work=" + Request["work"] + "&resources=" + Request["resources"] + "&title=" + Request["title"] + "&listid=" + Request["listid"] + "&itemid=" + newid + "&callback=SetCheckDates&useResPool=true";

                    Response.Redirect(url);

                    break;
                default:
                    output = "Error: Invalid Command";
                    break;
            }

        }

        private void SaveTemplate()
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Request["pjData"]);

            XmlAttribute attr = doc.CreateAttribute("Planner");
            attr.Value = Request["PlannerID"];
            doc.FirstChild.Attributes.Append(attr);

            attr = doc.CreateAttribute("TemplateName");
            attr.Value = Request["TemplateName"];
            doc.FirstChild.Attributes.Append(attr);

            attr = doc.CreateAttribute("Description");
            attr.Value = Request["Description"];
            doc.FirstChild.Attributes.Append(attr);

            string result = WorkPlannerAPI.SaveTemplate(doc, SPContext.Current.Web);

            doc.LoadXml(result);

            if (doc.FirstChild.Attributes["Status"].Value != "0")
            {
                output = doc.FirstChild.InnerXml;
            }
            else
            {
                output = "Success";
            }

        }

        private void GetImportStatus()
        {


            SPWeb web = SPContext.Current.Web;

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite site = new SPSite(web.Site.ID))
                {
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT status,timerjobuid,percentcomplete,dtfinished,result,resulttext from vwQueueTimerLog where timerjobuid=@timerjobuid", cn);
                    cmd.Parameters.AddWithValue("@timerjobuid", Request["jobuid"]);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        output = dr.GetInt32(0).ToString() + "|";
                        output += dr.GetInt32(2).ToString() + "|";

                        if (!dr.IsDBNull(4))
                            output += dr.GetString(4);

                        output += "|";

                        if (!dr.IsDBNull(5))
                            output += dr.GetString(5);
                    }
                    else
                    {
                        output = "Unknown";
                    }
                    dr.Close();
                    cn.Close();
                }
            });
        }

        private void ApplyTemplate()
        {
            try
            {
                WorkPlannerAPI.ApplyNewTemplate(SPContext.Current.Web, Request["Planner"], Request["Template"], Request["ID"], Request["PType"], Request["ProjectName"]);

                output = "Success";
            }
            catch (Exception ex)
            {
                output = "Error: " + ex.Message;
            }
        }

        private void GoToList()
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists.TryGetList(Request["list"]);
            if (list != null)
            {

                PlannerProps p = getSettings(web, Request["PlannerID"]);

                SPList oProjectCenter = web.Lists.TryGetList(p.sListProjectCenter);

                SPListItem li = oProjectCenter.GetItemById(int.Parse(Request["ID"]));

                Response.Redirect(list.DefaultViewUrl + "?IsDlg=1&filterfield1=Project&filtervalue1=" + li.Title);
            }
        }

        internal class PlannerProps
        {
            public string sListProjectCenter;
            public string sListTaskCenter;
            public string wpFields;
            public string sWorkDays;
            public int[] iWorkHours = new int[2];
        }

        private PlannerProps getSettings(SPWeb web, string planner)
        {
            PlannerProps p = new PlannerProps();
            Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(web);
            if (lockWeb == Guid.Empty || lockWeb == web.ID)
            {
                p.sListProjectCenter = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "ProjectCenter");
                p.sListTaskCenter = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "TaskCenter");
                //try
                //{
                //    useResourcePool = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPUseResPool"));
                //}
                //catch { }
                //sResourcePoolUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                //sResourceList = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool");
                p.wpFields = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + planner + "Fields");

                int work = web.RegionalSettings.WorkDays;
                for (byte x = 0; x < 7; x++)
                {
                    p.sWorkDays = ((((work >> x) & 0x01) == 0x01) ? "1" : "0") + "," + p.sWorkDays;
                    //if(!(((work >> x) & 0x01) == 0x01))
                    //    nonwork++;
                }

                p.sWorkDays = p.sWorkDays.Trim(',');

                p.iWorkHours[0] = web.RegionalSettings.WorkDayStartHour;
                p.iWorkHours[1] = web.RegionalSettings.WorkDayEndHour;

            }
            else
            {
                SPSite site = SPContext.Current.Site;
                {
                    using (SPWeb w = site.OpenWeb(lockWeb))
                    {
                        p.sListProjectCenter = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "ProjectCenter");
                        p.sListTaskCenter = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "TaskCenter");
                        //try
                        //{
                        //    useResourcePool = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPUseResPool"));
                        //}
                        //catch { }
                        //sResourcePoolUrl = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveResourceURL", true, false);
                        //sResourceList = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveResourcePool");
                        p.wpFields = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLivePlanner" + planner + "Fields");

                        int work = w.RegionalSettings.WorkDays;
                        for (byte x = 0; x < 7; x++)
                        {
                            p.sWorkDays = ((((work >> x) & 0x01) == 0x01) ? "1" : "0") + "," + p.sWorkDays;
                            //if(!(((work >> x) & 0x01) == 0x01))
                            //    nonwork++;
                        }

                        p.sWorkDays = p.sWorkDays.Trim(',');

                        p.iWorkHours[0] = w.RegionalSettings.WorkDayStartHour;
                        p.iWorkHours[1] = w.RegionalSettings.WorkDayEndHour;

                    }
                }
            }
            return p;
        }

        private void SaveProject()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<UpdateProject ID=\"\" PlannerID=\"\" ShowResults=\"false\"></UpdateProject>");
            doc.FirstChild.Attributes["ID"].Value = Request["ID"];
            doc.FirstChild.Attributes["PlannerID"].Value = Request["PlannerID"];

            //doc.FirstChild.FirstChild.Attributes["Name"].Value = Request["Property"];
            //doc.FirstChild.FirstChild.InnerText = Request["Value"];

            XmlDocument docProject = new XmlDocument();
            docProject.LoadXml(Request["pjData"]);

            foreach (XmlNode nd in docProject.FirstChild.SelectNodes("//B/I"))
            {
                XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "Field", doc.NamespaceURI);

                XmlAttribute attr = doc.CreateAttribute("Name");
                attr.Value = nd.Attributes["id"].Value;
                ndNew.Attributes.Append(attr);

                ndNew.InnerText = nd.Attributes["V"].Value;

                if (!String.IsNullOrEmpty(ndNew.InnerText))
                    doc.FirstChild.AppendChild(ndNew);
            }

            XmlDocument docRes = new XmlDocument();
            docRes.LoadXml(WorkPlannerAPI.SaveProject(doc, SPContext.Current.Web));

            if (docRes.FirstChild.Attributes["Status"].Value == "0")
            {
                output = "Success";
            }
            else
            {
                output = "Error Saving: " + docRes.FirstChild.InnerText;
            }
        }

        private void SetProperty()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<UpdateProject ID=\"\" PlannerID=\"\" ShowResults=\"false\"><Field Name=\"\"></Field></UpdateProject>");
            doc.FirstChild.Attributes["ID"].Value = Request["ID"];
            doc.FirstChild.Attributes["PlannerID"].Value = Request["PlannerID"];

            doc.FirstChild.FirstChild.Attributes["Name"].Value = Request["PlannerID"] + Request["Property"];
            doc.FirstChild.FirstChild.InnerText = Request["Value"];

            XmlDocument docRes = new XmlDocument();
            docRes.LoadXml(WorkPlannerAPI.SaveProject(doc, SPContext.Current.Web));

            if (docRes.FirstChild.Attributes["Status"].Value == "0")
            {
                output = "Success";
            }
            else
            {
                output = "Error Saving: " + docRes.FirstChild.InnerText;
            }
        }

        private void GetTeam()
        {
            WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(SPContext.Current.Web, Request["PlannerID"]);

            //if(props.bUseTeam)
            output = PlannerCore.getResourceList("<Team ListId='" + Request["listid"] + "' ItemId='" + Request["itemid"] + "'/>", SPContext.Current.Web);
            //else
            //    output = PlannerCore.getResourceList("", SPContext.Current.Web);
        }

        private void ProcessUpdates()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<PublishStatus ID=\"\" PlannerID=\"\" ShowResults=\"false\"/>");
            doc.FirstChild.Attributes["ID"].Value = Request["ID"];
            doc.FirstChild.Attributes["PlannerID"].Value = Request["PlannerID"];

            doc.FirstChild.InnerXml = Request["Updates"];

            XmlDocument docRes = new XmlDocument();
            docRes.LoadXml(EPMLiveCore.WorkEngineAPI.ProcessUpdates(doc.OuterXml, SPContext.Current.Web));

            if (docRes.FirstChild.Attributes["Status"].Value == "0")
            {
                output = "Success";
            }
            else
            {
                output = "Error Processing Updates: " + docRes.FirstChild.InnerText;
            }
        }

        private void GetUpdateCount()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<PublishStatus ID=\"\" PlannerID=\"\" ShowResults=\"false\"/>");
            doc.FirstChild.Attributes["ID"].Value = Request["ID"];
            doc.FirstChild.Attributes["PlannerID"].Value = Request["PlannerID"];

            XmlDocument docRes = new XmlDocument();
            docRes.LoadXml(EPMLiveCore.WorkEngineAPI.GetUpdateCount(doc.OuterXml, SPContext.Current.Web));

            if (docRes.FirstChild.Attributes["Status"].Value == "0")
            {
                output = docRes.FirstChild.InnerText;
            }
            else
            {
                output = "Error Getting Status: " + docRes.FirstChild.InnerText;
            }
        }

        private void PublishStatus()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<PublishStatus ID=\"\" PlannerID=\"\" ShowResults=\"false\"/>");
            doc.FirstChild.Attributes["ID"].Value = Request["ID"];
            doc.FirstChild.Attributes["PlannerID"].Value = Request["PlannerID"];

            XmlDocument docRes = new XmlDocument();
            docRes.LoadXml(EPMLiveCore.WorkEngineAPI.PublishStatus(doc.OuterXml, SPContext.Current.Web));

            if (docRes.FirstChild.Attributes["Status"].Value == "0")
            {
                if (docRes.FirstChild.FirstChild.Attributes["Status"] != null)
                {
                    string pubStatus = docRes.FirstChild.FirstChild.Attributes["Status"].Value;
                    string result = docRes.FirstChild.FirstChild.Attributes["Result"].Value;
                    string pct = docRes.FirstChild.FirstChild.Attributes["PercentComplete"].Value;
                    string time = docRes.FirstChild.FirstChild.Attributes["TimeFinished"].Value;

                    SPWeb web = SPContext.Current.Web;
                    SPUser currentUser = web.CurrentUser;
                    SPRegionalSettings currentContextRegionalSettings = currentUser.RegionalSettings ?? web.RegionalSettings;
                    var date = currentContextRegionalSettings.TimeZone.UTCToLocalTime(Convert.ToDateTime(time).ToUniversalTime()).ToString();

                    switch (pubStatus)
                    {
                        case "Queued":
                            output = "false|false|Queued";
                            break;
                        case "Processing":
                            output = "false|false|Processing (" + pct + "%)";
                            break;
                        case "Complete":
                            if (result != "No Errors")
                                output = "true|true|Last Published at: " + date + " with errors. <a href=\"Javascript:PublishLog();\">[View Log]</a>";
                            else
                                output = "true|false|Last Published at: " + date + ". <a href=\"Javascript:PublishLog();\">[View Log]</a>";
                            break;
                    }
                }
                else
                    output = "true|false|Not Published";
            }
            else
            {
                output = "Error Getting Status: " + docRes.FirstChild.InnerText;
            }

        }

        private void Publish()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Publish ID=\"\" PlannerID=\"\"/>");

            doc.FirstChild.Attributes["ID"].Value = Request["ID"];
            doc.FirstChild.Attributes["PlannerID"].Value = Request["PlannerID"];

            XmlDocument docRes = new XmlDocument();
            docRes.LoadXml(WorkPlannerAPI.Publish(doc, SPContext.Current.Web));

            if (docRes.FirstChild.Attributes["Status"].Value == "0")
                output = "Success";
            else
                output = "Error: " + docRes.FirstChild.InnerText;
        }

        private void DeleteView()
        {
            SPWeb sweb = SPContext.Current.Web;
            if (EPMLiveCore.CoreFunctions.DoesCurrentUserHaveFullControl(sweb))
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {

                    using (SPSite site = new SPSite(sweb.Site.ID))
                    {
                        using (SPWeb web = site.OpenWeb(sweb.ID))
                        {
                            EPMLiveCore.API.PropertyHash props = new EPMLiveCore.API.PropertyHash(EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLivePlanner" + Request["PlannerID"] + "Views"));

                            for (int i = 0; i < props.Count; i++)
                            {
                                if (props[i][0].ToString().ToLower() == Request["title"].ToLower())
                                {
                                    props.Remove(i);
                                }
                            }

                            web.AllowUnsafeUpdates = true;
                            EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + Request["PlannerID"] + "Views", props.ToString());

                            output = "Success";
                        }
                    }
                });
            }
        }

        private string getFieldValue(SPListItem li, string field)
        {
            try
            {
                return li[field].ToString();
            }
            catch { }
            return "";
        }

        private void GetRowInfo()
        {
            output = "Success:";

            try
            {
                SPList list = SPContext.Current.Web.Lists[new Guid(Request["listid"])];

                SPQuery query = new SPQuery();
                query.Query = "<Where><And><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + Request["ProjectId"] + "</Value></Eq><Eq><FieldRef Name='taskuid'/><Value Type='Text'>" + Request["taskuid"] + "</Value></Eq></And></Where>";
                query.ViewFields = "<FieldRef Name='CommentCount'/><FieldRef Name='Attachments'/>";

                SPListItemCollection lic = list.GetItems(query);

                if (lic.Count > 0)
                {
                    output = "Success:CommentCount|" + getFieldValue(lic[0], "CommentCount") + ",Attachments|" + getFieldValue(lic[0], "Attachments");
                }
            }
            catch { }


        }

        private void RenameView()
        {
            SPWeb web = SPContext.Current.Web;

            EPMLiveCore.API.PropertyHash props = new EPMLiveCore.API.PropertyHash(EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLivePlanner" + Request["PlannerID"] + "Views"));

            for (int i = 0; i < props.Count; i++)
            {
                if (props[i][0].ToString().ToLower() == Request["oldtitle"].ToLower())
                {
                    props[i][0] = Request["newtitle"].Replace(" ", "");
                }
            }

            web.AllowUnsafeUpdates = true;
            EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWorkPlannerViews", props.ToString());

            output = "Success";
        }

        private void saveview()
        {
            SPWeb sweb = SPContext.Current.Web;

            if (EPMLiveCore.CoreFunctions.DoesCurrentUserHaveFullControl(sweb))
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {

                    using (SPSite site = new SPSite(sweb.Site.ID))
                    {
                        using (SPWeb web = site.OpenWeb(sweb.ID))
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(Request["title"]);
                            sb.Append("|");
                            sb.Append(Request["leftcols"]);
                            sb.Append("|");
                            sb.Append(Request["cols"]);
                            sb.Append("|");
                            sb.Append(Request["filters"]);
                            sb.Append("|");
                            sb.Append(Request["grouping"]);
                            sb.Append("|");
                            sb.Append(Request["sorting"]);
                            sb.Append("|");
                            sb.Append(Request["gantt"]);
                            sb.Append("|");
                            sb.Append(Request["details"]);
                            sb.Append("|");
                            sb.Append(Request["folders"]);
                            sb.Append("|");
                            sb.Append(Request["assignments"]);
                            sb.Append("|");
                            sb.Append(Request["summary"]);
                            sb.Append("|");
                            sb.Append(Request["allocation"]);
                            sb.Append("|");
                            sb.Append(Request["colsWidths"]);

                            if (!String.IsNullOrEmpty(Request["agileleft"]))
                            {
                                sb.Append("`");
                                sb.Append(Request["agileleft"]);
                                sb.Append("|");
                                sb.Append(Request["agilecols"]);
                                sb.Append("|");
                                sb.Append(Request["agilefilters"]);
                                sb.Append("|");
                                sb.Append(Request["agilegrouping"]);
                                sb.Append("|");
                                sb.Append(Request["agilesorting"]);
                                sb.Append("|");
                                sb.Append(Request["agilegantt"]);
                                sb.Append("|");
                                sb.Append(Request["backlog"]);
                            }

                            EPMLiveCore.API.PropertyHash props = new EPMLiveCore.API.PropertyHash(EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLivePlanner" + Request["PlannerID"] + "Views"));

                            bool found = false;

                            for (int i = 0; i < props.Count; i++)
                            {
                                if (props[i].Count > 0)
                                {
                                    if (props[i][0].ToString().ToLower() == Request["title"].ToLower())
                                    {
                                        props.Update(i, sb.ToString());

                                        found = true;
                                        break;
                                    }
                                }
                            }

                            if (!found)
                            {
                                props.Add(sb.ToString());
                            }

                            web.AllowUnsafeUpdates = true;
                            EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + Request["PlannerID"] + "Views", props.ToString());

                            if (Request["Default"] == "true")
                                EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + Request["PlannerID"] + "ViewsDefault", Request["title"]);
                        }
                    }
                });
            }

            output = "Success";
        }
    }
}
