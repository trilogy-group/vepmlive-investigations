using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class WorkPlannerWizard : LayoutsPageBase
    {
        protected string sItemID = "";
        protected string sProjectListId = "";
        protected string sPlannerID = "";
        protected string sProjectType = "";
        protected string sTaskListId = "";
        protected string sProjectName = "";
        protected string sOutputHtml = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            
            //int haspc = hasChildParent(web, Request["listid"], Request["ID"]);

            //if(haspc > 0 && String.IsNullOrEmpty(Request["PCSelected"]))
            //{
            //    SPList list = web.Lists[new Guid(Request["listid"])];

            //    SPListItem li = list.GetItemById(int.Parse(Request["ID"]));

            //    pnlParentChild.Visible = true;

            //    string[] sParentChild = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePlannerParentChild", false).Split(',');
            //    ddlChildParent.Items.Clear();
            //    if(haspc == 1)
            //    {
            //        ddlChildParent.Items.Add(new ListItem(sParentChild[0], web.ID + "." + list.ID + "." + li.ID));
            //        ddlChildParent.Items.Add(new ListItem(sParentChild[1], li["ChildItem"].ToString()));
            //    }
            //    else
            //    {
            //        ddlChildParent.Items.Add(new ListItem(sParentChild[0], li["ParentItem"].ToString()));
            //        ddlChildParent.Items.Add(new ListItem(sParentChild[1], web.ID + "." + list.ID + "." + li.ID));
            //    }
            //}
            //else
            //{
                sItemID = Request["ID"];
                sProjectListId = Request["listid"];
                sPlannerID = Request["Planner"];
                sProjectType = Request["PType"];
                sTaskListId = Request["tasklistid"];

                if(Request["Upload"] == "1")
                {
                    pnlUpload.Visible = true;
                    pnlTemplate.Visible = false;
                }
                else
                {

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {

                        using(SPSite site = new SPSite(web.Site.ID))
                        {
                            using(SPWeb iweb = site.OpenWeb(web.ID))
                            {
                                Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(iweb);
                                if(lockWeb == Guid.Empty || lockWeb == web.ID)
                                {
                                    iCheckParams(web, web);
                                }
                                else
                                {
                                    using(SPWeb w = site.OpenWeb(lockWeb))
                                    {
                                        iCheckParams(web, w);
                                    }

                                }
                            }
                        }
                    });
                }
            //}
        }


        private string GetPlannerTable(string plannerid, string plannername, SPWeb lWeb)
        {

            string icon = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "Fields");
            if(icon == "")
                icon = "/_layouts/epmlive/images/planner32.png";
            string desc = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + plannerid + "Description");
            
            bool bOnline = false;
            bool bProject = false;

            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + plannerid + "EnableOnline") == "" ? "true" : EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + plannerid + "EnableOnline"), out bOnline);
            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + plannerid + "EnableProject"), out bProject);

            StringBuilder sb = new StringBuilder();

            if(bOnline && plannerid != "MPP")
            {
                sb.Append("<a href=\"javascript:void(0);\" onclick=\"SelectPlanner('");
                sb.Append(plannerid);
                sb.Append("|Online')\" class=\"btn btn-large\"><TABLE border=0 cellSpacing=0 cellPadding=0 width=\"100%\" height=\"100%\"><tr>");
                sb.Append("<td style=\"vertical-align:middle; text-align:center\" width=\"80px\" valign=\"center\" align=\"center\">");
                sb.Append("<img src=\"");
                sb.Append(((Web.ServerRelativeUrl == "/") ? "" : Web.ServerRelativeUrl));
                sb.Append(icon);
                sb.Append("\"></td>");
                sb.Append("<td class=\"titletd\"><b>");
                sb.Append(plannername);
                sb.Append("</b>");
                if(desc != "")
                {
                    sb.Append("<div style=\"padding-top: 5px;padding-bottom:10px;padding-right:5px;work-wrap:break-word;\">");
                    sb.Append(desc);
                    sb.Append("</div>");
                }
                sb.Append("</td>");
                sb.Append("</tr></table></a>");
            }

            if(bProject || plannerid == "MPP")
            {
                sb.Append("<a href=\"javascript:void(0);\" onclick=\"SelectPlanner('");
                sb.Append(plannerid);
                sb.Append("|Project')\" class=\"btn btn-large\"><TABLE border=0 cellSpacing=0 cellPadding=0 width=\"100%\" height=\"100%\"><tr>");
                sb.Append("<td style=\"vertical-align:middle; text-align:center\" width=\"80px\" valign=\"center\" align=\"center\">");
                sb.Append("<img src=\"");
                sb.Append(((Web.ServerRelativeUrl == "/") ? "" : Web.ServerRelativeUrl));
                sb.Append("/_layouts/images/Project2007Logo.gif\"></td>");
                sb.Append("<td class=\"titletd\"><b>");
                sb.Append(plannername);
                if(plannername == "Microsoft Project" || plannerid == "MPP")
                    sb.Append("</b>");
                else
                    sb.Append(" for Microsoft Project</b>");
                if(desc != "")
                {
                    sb.Append("<div style=\"padding-top: 5px;padding-bottom:10px;padding-right:5px;work-wrap:break-word;\">");
                    sb.Append(desc);
                    sb.Append("</div>");
                }
                sb.Append("</td>");
                sb.Append("</tr></table></a>");
            }

            return sb.ToString();

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(FileUpload.FileName.EndsWith(".mpp"))
            {
                SPList oList = Web.Lists[new Guid(sProjectListId)];

                sProjectName = oList.GetItemById(int.Parse(sItemID)).Title;



                byte[] fBytes = FileUpload.FileBytes;

                SPFolder folder = Web.GetFolder("Project Schedules/" + sPlannerID);
                if(!folder.Exists)
                    folder = Web.Folders["Project Schedules"].SubFolders.Add(sPlannerID);

                folder.Files.Add(sProjectName + ".mpp", fBytes);

                pnlUpload.Visible = false;
                pnlUploadDone.Visible = true;
            }
            else
            {
                lblUploadError.Text = "That is not an mpp file<br>";
                lblUploadError.Visible = true;
            }
            

        }
        

        private string GetTemplateTable(DataRow drTemplate)
        {

            string icon = drTemplate["Icon"].ToString();

            if(icon == "")
                icon = "/_layouts/epmlive/images/WESite.png";

            string desc = drTemplate["Description"].ToString();

            StringBuilder sb = new StringBuilder();

            sb.Append("<a href=\"javascript:void(0);\" onclick=\"ApplyTemplate('");
            sb.Append(drTemplate["ID"].ToString());
            sb.Append("')\" class=\"btn btn-large\" style=\"height:50px !important;\"><TABLE border=0 cellSpacing=0 cellPadding=5 width=\"100%\"><tr>");
            sb.Append("<td class=\"titletd\"><b>");
            sb.Append(drTemplate["Title"].ToString());
            sb.Append("</b><br>");
            if(desc != "")
            {
                sb.Append("<div style=\"padding-top: 5px\">");
                sb.Append(desc);
                sb.Append("</div>");
            }
            sb.Append("</td>");
            sb.Append("</tr></table></a>");

            return sb.ToString();

        }


        private void iCheckParams(SPWeb web, SPWeb lWeb)
        {
            SPList oList = null;
            SPList oTaskList = null;
            SortedList slPlanners = new SortedList();

            try
            {
                oList = web.Lists[new Guid(sProjectListId)];
            }
            catch { }

            try
            {
                oTaskList = web.Lists[new Guid(sTaskListId)];
            }
            catch { }

            if(String.IsNullOrEmpty(sPlannerID))
            {
                if(!String.IsNullOrEmpty(sProjectListId))
                {
                    slPlanners = WorkPlannerAPI.GetPlannersByProjectList( oList.Title, web);

                    if(slPlanners.Count == 1)
                    {
                        string sTempPlanner = slPlanners.GetKey(0).ToString();

                        bool bOnline = false;
                        bool bProject = false;

                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline") == "" ? "true" : EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline"), out bOnline);
                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableProject"), out bProject);


                        if(bOnline && bProject)
                        {

                        }
                        else if(bOnline)
                        {
                            sPlannerID = slPlanners.GetKey(0).ToString();
                            sProjectType = "Online";
                        }
                        else if(bProject)
                        {
                            sPlannerID = slPlanners.GetKey(0).ToString();
                            sProjectType = "Project";
                        }
                    }
                }
                if(String.IsNullOrEmpty(sPlannerID))
                {
                    if(!String.IsNullOrEmpty(sTaskListId))
                    {
                        slPlanners = WorkPlannerAPI.GetPlannersByTaskList(web, oTaskList.Title);

                        if(slPlanners.Count == 1)
                        {
                            string sTempPlanner = slPlanners.GetKey(0).ToString();

                            bool bOnline = false;
                            bool bProject = false;

                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline") == "" ? "true" : EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline"), out bOnline);
                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableProject"), out bProject);


                            if(bOnline && bProject)
                            {

                            }
                            else if(bOnline)
                            {
                                sPlannerID = slPlanners.GetKey(0).ToString();
                                sProjectType = "Online";
                            }
                            else if(bProject)
                            {
                                sPlannerID = slPlanners.GetKey(0).ToString();
                                sProjectType = "Project";
                            }
                        }
                    }
                }

                if(slPlanners.Count == 0)
                {

                    string planners = EPMLiveCore.CoreFunctions.getLockConfigSetting(SPContext.Current.Web, "EPMLivePlannerPlanners", false);

                    foreach(string planner in planners.Split(','))
                    {
                        string[] sPlanner = planner.Split('|');

                        SPList oTempPList = web.Lists.TryGetList(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlanner[0] + "ProjectCenter"));
                        SPList oTempTList = web.Lists.TryGetList(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlanner[0] + "TaskCenter"));

                        if(oTempPList != null && oTempTList != null)
                            slPlanners.Add(sPlanner[0], sPlanner[1]);
                    }

                    if(slPlanners.Count == 1)
                    {
                        string sTempPlanner = slPlanners.GetKey(0).ToString();

                        bool bOnline = false;
                        bool bProject = false;

                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline") == "" ? "true" : EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline"), out bOnline);
                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableProject"), out bProject);


                        if(bOnline && bProject)
                        {

                        }
                        else if(bOnline)
                        {
                            sPlannerID = slPlanners.GetKey(0).ToString();
                            sProjectType = "Online";
                        }
                        else if(bProject)
                        {
                            sPlannerID = slPlanners.GetKey(0).ToString();
                            sProjectType = "Project";
                        }
                    }
                }
            }

            if(slPlanners.Count > 0 && String.IsNullOrEmpty(sPlannerID))
            {
                pnlPlanner.Visible = true;
                sOutputHtml = "<div style=\"width:100%;\">";

                foreach(DictionaryEntry de in slPlanners)
                {

                    sOutputHtml += GetPlannerTable(de.Key.ToString(), de.Value.ToString(), lWeb);

                }

                sOutputHtml += "</div>";
            }
            else
            {

                if(String.IsNullOrEmpty(sProjectListId))
                {
                    try
                    {
                        string sProjectList = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "ProjectCenter");
                        oList = web.Lists[sProjectList];
                        sProjectListId = oList.ID.ToString();
                    }
                    catch { }
                }

                if(String.IsNullOrEmpty(sItemID) && oList != null)
                {
                    if(oList.Items.Count == 1)
                        sItemID = oList.Items[0].ID.ToString();
                }

                if(String.IsNullOrEmpty(sItemID))
                {
                    //TODO: Show Item selection
                    pnlItem.Visible = true;

                    sOutputHtml = "<option value=\"\">--Select Item--</option>";

                    foreach(SPListItem li in oList.Items)
                    {
                        sOutputHtml += "<option value=\"" + li.ID.ToString() + "\">" + li.Title + "</option>";
                    }
                }
                else
                {
                    //if(!CheckProjectType(lWeb))
                    //{
                    //    pnlType.Visible = true;
                    //}
                    //else
                    //{



                    //}
                }
            }

            if(String.IsNullOrEmpty(sTaskListId) && !String.IsNullOrEmpty(sPlannerID))
            {
                try
                {
                    if(sPlannerID == "MPP")
                    {
                        oTaskList = web.Lists["Task Center"];
                        sTaskListId = oTaskList.ID.ToString();
                    }
                    else
                    {
                        string sTaskList = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "TaskCenter");
                        oTaskList = web.Lists[sTaskList];
                        sTaskListId = oTaskList.ID.ToString();
                    }
                }
                catch { }
            }

            if(!String.IsNullOrEmpty(sPlannerID) && !String.IsNullOrEmpty(sProjectListId) && !String.IsNullOrEmpty(sItemID) && !String.IsNullOrEmpty(sProjectType) && !String.IsNullOrEmpty(sTaskListId))
            {

                sProjectName = oList.GetItemById(int.Parse(sItemID)).Title;

                if(sProjectType == "Online")
                {
                    SPFile tFile = WorkPlannerAPI.GetTaskFile(web, sItemID, sPlannerID);

                    if((tFile == null || !tFile.Exists) && PopulateTemplates(web))
                    {
                        pnlTemplate.Visible = true;
                    }
                    else
                    {
                        pnlDone.Visible = true;
                    }
                }
                else
                {

                    string sPlannerIDPath = "";
                    if(sPlannerID != "MPP")
                        sPlannerIDPath = sPlannerID + "/";

                    SPFile tFile = web.GetFile("Project Schedules/" + sPlannerIDPath + sProjectName + ".mpp");

                    if((tFile == null || !tFile.Exists) && sPlannerID != "MPP" && PopulateTemplates(web))
                    {
                        pnlTemplate.Visible = true;
                    }
                    else
                    {
                        if(!String.IsNullOrEmpty(Request["setdefault"]))
                        {
                            try
                            {
                                if(bool.Parse(Request["setdefault"]))
                                    setDefault(web);
                            }
                            catch { }
                        }

                        pnlDone.Visible = true;
                    }
                }
            }

        }

        private void setDefault(SPWeb web)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using(SPSite site = new SPSite(web.Site.ID))
                    {
                        using(SPWeb rweb = site.OpenWeb(web.ID))
                        {
                            rweb.AllowUnsafeUpdates = true;
                            SPList list = rweb.Lists[new Guid(sProjectListId)];
                            SPListItem li = list.GetItemById(int.Parse(sItemID));

                            if(!list.Fields.ContainsField("DefaultPlanner"))
                            {
                                list.Fields.Add("DefaultPlanner", SPFieldType.Text, false);
                                SPField fld = list.Fields["DefaultPlanner"];
                                fld.Title = "DefaultPlanner";
                                fld.Hidden = true;
                                fld.Sealed = true;
                                fld.Update();
                                list.Update();
                            }

                            li["DefaultPlanner"] = Request["Planner"] + "|" + sProjectType;
                            li.SystemUpdate();
                        }
                    }
                });
            }
            catch { }
        }

        private bool PopulateTemplates(SPWeb web)
        {
            
            DataTable dtTemplates = WorkPlannerAPI.GetTemplates(web, sPlannerID, sProjectType);

            if(dtTemplates.Rows.Count == 0)
            {
                if(sProjectType == "Project")
                {
                    WorkPlannerAPI.ApplyNewTemplate(web, "", "", sItemID, sProjectType, sProjectName);
                }
                return false;
            }
            else if(dtTemplates.Rows.Count == 1 && dtTemplates.Rows[0]["ID"].ToString() != "-101")
            {
                WorkPlannerAPI.ApplyNewTemplate(web, sPlannerID, dtTemplates.Rows[0]["ID"].ToString(), sItemID, sProjectType, sProjectName);
                return false;
            }
            else
            {
                sOutputHtml = "<div style=\"\">";

                foreach(DataRow dr in dtTemplates.Rows)
                {
                    sOutputHtml += GetTemplateTable(dr);
                }

                sOutputHtml += "</div>";


                return true;
            }

            
        }

        private bool CheckProjectType(SPWeb lWeb)
        {
            if(String.IsNullOrEmpty(sProjectType))
            {

                bool bOnline = false;
                bool bProject = false;

                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "EnableOnline") == "" ? "true" : EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "EnableOnline"), out bOnline);
                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "EnableProject"), out bProject);

                if(bOnline && bProject)
                {
                    return false;
                }
                else if(bOnline)
                {
                    sProjectType = "Online";
                }
                else if(bProject)
                {
                    sProjectType = "Project";
                }
                else
                    sProjectType = "Online";

            }

            return true;
        }

        private int hasChildParent(SPWeb web, string listid, string itemid)
        {

            try
            {
                SPList list = web.Lists[new Guid(listid)];
                SPListItem li = list.GetItemById(int.Parse(itemid));
                try
                {
                    if(li["ChildItem"].ToString() != "")
                    {
                        return 1;
                    }
                }
                catch { }
                try
                {
                    if(li["ParentItem"].ToString() != "")
                    {
                        return 2;
                    }
                }
                catch { }
            }
            catch { }
            return 0;
        }
    }
}
