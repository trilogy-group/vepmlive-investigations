using System;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Web.CommandUI;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class WorkPlanner : LayoutsPageBase
    {
        protected string sFolderDataParam;
        protected string sPlannerDataParam;
        protected string sPlannerLayoutParam;
        protected string sViewObject;


        protected string sPlannerID = "";
        protected string sItemID = "";
        protected string sProjectType = "";
        protected string sProjectListId = "";
        protected string sTaskListId = "";
        protected string sWebId = "";

        protected string sPlannerName;
        protected string sProjectName;
        protected bool bUseFolders;

        protected string iTaskType;
        protected bool bEnableLink = false;
        private string sListProjectCenter;
        private string sListTaskCenter;

        protected string sResourceList = "";
        protected string sChoiceFields = "";
        //protected string sProjectChoiceFields = "";

        protected string sMultiChoiceJSON = "";

        protected string sResourceUrl = "";

        protected string sSource = "";

        protected string sBaselineFields = "";

        protected string sSummaryRollup = "false";

        //protected string sEditorID;

        protected bool bAgile = false;

        protected string sRollUp = "";
        protected string sRollDown = "";

        protected string sAttachedLists = "";
        protected string sAttachedDocLibs = "";

        protected string sTaskUserFields = "";
        protected string sProjectUserFields = "";
        protected string sDefaults = "";

        protected string sPlannerDescriptions = "";

        protected string sBaselineDate = "";

        protected string OldUrl = "";

        protected string sWebUrl = "";

        private SPList docLib = null;

        protected string DecimalSeparator = ".";
        protected string GroupSeparator = ",";

        protected string agileDiv = "";

        protected bool bCalcCost = false;
        protected bool bCalcWork = false;
        protected bool bUseTeam = false;

        protected int iWorkHours = 8;

        protected int EPKCost = 0;
        protected int EPKResPlan = 0;

        int activation = -1;

        protected string sLinkedTasks = "";

        protected string CanLinkExternal = "false";

        protected EPMLiveCore.TimeDebug tb;
        protected string timerString;

        public string EPMLiveVersion
        {
            get { return EPMLiveScriptManager.FileVersion; }
        }

        protected override void OnInit(EventArgs e)
        {
            tb = new EPMLiveCore.TimeDebug("WorkPlanner", Request["debug"]);
        }

        protected void getFields(SPWeb web)
        {
            tb.AddTimer();

            SPList lstTaskCenter = web.Lists[sListTaskCenter];

            try
            {
                if (lstTaskCenter.Fields.GetFieldByInternalName("IsExternal") != null && lstTaskCenter.Fields.GetFieldByInternalName("ExternalLink") != null)
                {
                    CanLinkExternal = "true";
                }
            }
            catch { }

            foreach (SPField oField in lstTaskCenter.Fields)
            {
                if (oField.Type == SPFieldType.User)
                    sTaskUserFields += ",'" + oField.InternalName + "'";
                else
                {
                    try
                    {
                        if (!oField.ReadOnlyField)
                        {
                            XmlDocument docF = new XmlDocument();
                            docF.LoadXml(oField.SchemaXml);

                            string sDefault = docF.SelectSingleNode("//Default").InnerText;
                            if (oField.Type == SPFieldType.DateTime && sDefault == "[today]")
                            {

                            }
                            else if (oField.Type == SPFieldType.Number || oField.Type == SPFieldType.Currency)
                            {
                                //if(sDefault != "0" && sDefault != ".00")
                                sDefaults += oField.InternalName + ":\"" + sDefault.Replace("\"", "'") + "\",";
                            }
                            else if (oField.Type == SPFieldType.Boolean)
                            {
                                if (sDefault != "0")
                                    sDefaults += oField.InternalName + ":\"" + sDefault.Replace("\"", "'") + "\",";
                            }
                            else
                            {
                                sDefaults += oField.InternalName + ":\"" + sDefault.Replace("\"", "'") + "\",";
                            }
                        }
                    }
                    catch { }
                }
            }
            sDefaults = sDefaults.Trim(',');
            sTaskUserFields = sTaskUserFields.Trim(',');

            SPList lstProjectCenter = web.Lists[sListProjectCenter];
            foreach (SPField oField in lstProjectCenter.Fields)
            {
                if (oField.Type == SPFieldType.User)
                    sProjectUserFields += ",'" + oField.InternalName + "'";
            }
            sProjectUserFields = sProjectUserFields.Trim(',');
            sTaskListId = lstTaskCenter.ID.ToString().ToUpper();

            StringBuilder sbBFields = new StringBuilder();

            foreach (SPField field in lstTaskCenter.Fields)
            {
                if (!field.Hidden && field.Reorderable)
                {
                    try
                    {
                        string fName = field.InternalName;

                        if (fName == "StartDate")
                            fName = "Start";
                        if (fName == "DueDate")
                            fName = "Finish";

                        SPField bField = lstTaskCenter.Fields.GetFieldByInternalName("Baseline" + fName);
                        if (bField != null)
                        {
                            sbBFields.Append(field.InternalName);
                            sbBFields.Append(":\"");
                            sbBFields.Append(bField.InternalName);
                            sbBFields.Append("\",");
                        }
                    }
                    catch { }
                }
            }

            sBaselineFields = sbBFields.ToString().Trim(',');

            tb.StopTimer();
        }



        protected void getAttachedLists(SPWeb web, string listid)
        {
            tb.AddTimer();
            /*foreach(SPList list in web.Lists)
            {
                foreach(SPField field in list.Fields)
                {
                    if(field.Type == SPFieldType.Lookup)
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(field.SchemaXml);

                        if(doc.FirstChild.Attributes["List"].Value.ToLower() == listid.ToLower())
                        {
                            sAttachedLists += "\"" + list.Title + "\",";
                        }
                    }
                }
            }*/
            foreach (SPList list in web.Lists)
            {
                if (!list.Hidden)
                {
                    EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

                    if (gSettings.AssociatedItems && list.Title != sListProjectCenter && list.Title != sListTaskCenter)
                    {
                        bool hasProject = false;
                        string sfield = "";
                        foreach (SPField field in list.Fields)
                        {
                            if (field.Type == SPFieldType.Lookup)
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(field.SchemaXml);
                                try
                                {
                                    if (doc.FirstChild.Attributes["List"].Value.ToLower() == listid.ToLower())
                                    {
                                        hasProject = true;
                                        sfield = field.InternalName;
                                    }
                                }
                                catch { }
                            }
                        }
                        if (hasProject)
                        {
                            if ((int)list.BaseType == 1)
                                sAttachedDocLibs += "\"" + System.Web.HttpUtility.HtmlEncode(list.Title) + "," + sfield + "." + System.Web.HttpUtility.HtmlEncode(list.Title) + "\",";
                            else
                                sAttachedLists += "\"" + System.Web.HttpUtility.HtmlEncode(list.Title) + "," + sfield + "." + System.Web.HttpUtility.HtmlEncode(list.Title) + "\",";
                        }
                    }
                }
            }

            sAttachedLists = sAttachedLists.Trim(',');
            sAttachedDocLibs = sAttachedDocLibs.Trim(',');
            tb.StopTimer();
        }

        protected void processRollups(WorkPlannerAPI.PlannerProps props)
        {
            tb.AddTimer();
            PlannerCore.WorkPlannerProperties wps = props.wpFields;

            for (int i = 0; i < wps.count(); i++)
            {
                PlannerCore.WorkPlannerProperty wp = wps.GetByIndex(i);

                if (wp.val == "RollDown")
                {
                    sRollDown += wp.field + ": \"" + wp.val + "\",";
                }
                else
                {
                    sRollUp += wp.field + ": \"" + wp.val + "\",";
                }
            }
            sRollUp = sRollUp.Trim(',');
            sRollDown = sRollDown.Trim(',');
            tb.StopTimer();
        }

        private void setDefault(SPWeb web)
        {
            tb.AddTimer();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(web.Site.ID))
                    {
                        using (SPWeb rweb = site.OpenWeb(web.ID))
                        {
                            rweb.AllowUnsafeUpdates = true;
                            SPList list = rweb.Lists[new Guid(Request["listid"])];
                            SPListItem li = list.GetItemById(int.Parse(Request["id"]));

                            if (!list.Fields.ContainsField("DefaultPlanner"))
                            {
                                list.Fields.Add("DefaultPlanner", SPFieldType.Text, false);
                                SPField fld = list.Fields["DefaultPlanner"];
                                fld.Title = "DefaultPlanner";
                                fld.Hidden = true;
                                fld.Sealed = true;
                                fld.Update();
                                list.Update();
                            }

                            li["DefaultPlanner"] = Request["Planner"] + "|" + Request["PType"];
                            li.SystemUpdate();
                        }
                    }
                });
            }
            catch { }
            tb.StopTimer();
        }

        private bool hasChildParent(SPWeb web, string listid, string itemid)
        {
            tb.AddTimer();
            try
            {
                SPList list = web.Lists[new Guid(listid)];
                SPListItem li = list.GetItemById(int.Parse(itemid));
                try
                {
                    if (li["ChildItem"].ToString() != "")
                    {
                        return true;
                    }
                }
                catch { }
                try
                {
                    if (li["ParentItem"].ToString() != "")
                    {
                        return true;
                    }
                }
                catch { }
            }
            catch { }
            tb.StopTimer();
            return false;
        }
        private bool checkParentChild(SPWeb web, string listid, string itemid)
        {
            tb.AddTimer();
            bool disable = false;


            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite rsite = new SPSite(web.Site.ID))
                {
                    using (SPWeb rweb = Site.OpenWeb(web.ID))
                    {
                        bool.TryParse(EPMLiveCore.CoreFunctions.getLockConfigSetting(rweb, "EPMLivePlanner" + Request["name"] + "DisablePC", false), out disable);
                    }
                }
            });

            if (!disable)
            {
                bool isPCItem = false;

                try
                {
                    SPList list = web.Lists[new Guid(listid)];
                    SPListItem li = list.GetItemById(int.Parse(itemid));
                    try
                    {
                        if (li["ChildItem"].ToString() != "" && String.IsNullOrEmpty(Request["PCSelected"]) && String.IsNullOrEmpty(Request["Planner"]))
                        {
                            isPCItem = true;

                            string[] sParentChild = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlannerParentChild").Split(',');
                            ddlChildParent.Items.Clear();
                            ddlChildParent.Items.Add(new ListItem(sParentChild[0], web.ID + "." + list.ID + "." + li.ID));
                            ddlChildParent.Items.Add(new ListItem(sParentChild[1], li["ChildItem"].ToString()));
                        }
                    }
                    catch { }
                    try
                    {
                        if (li["ParentItem"].ToString() != "" && String.IsNullOrEmpty(Request["PCSelected"]) && String.IsNullOrEmpty(Request["Planner"]))
                        {
                            isPCItem = true;

                            string[] sParentChild = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlannerParentChild").Split(',');
                            ddlChildParent.Items.Clear();
                            ddlChildParent.Items.Add(new ListItem(sParentChild[0], li["ParentItem"].ToString()));
                            ddlChildParent.Items.Add(new ListItem(sParentChild[1], web.ID + "." + list.ID + "." + li.ID));
                        }
                    }
                    catch { }
                }
                catch { }

                if (isPCItem)
                {
                    pnlMain.Visible = false;
                    pnlParentChild.Visible = true;
                    sPlannerName = "Choose Item";
                }
                tb.StopTimer();
                return isPCItem;
            }
            tb.StopTimer();
            return false;
        }

        private void showPlannerPopup()
        {
            pnlMain.Visible = false;
            pnlPopup.Visible = true;
        }

        private void LoadDefaults(SPList oList)
        {
            tb.AddTimer();
            if (oList != null && !String.IsNullOrEmpty(sItemID))
            {
                try
                {
                    SPListItem li = oList.GetItemById(int.Parse(sItemID));

                    string[] sPlannerInfo = li["DefaultPlanner"].ToString().Split('|');

                    sPlannerID = sPlannerInfo[0];
                    sProjectType = sPlannerInfo[1];
                }
                catch { }
            }
            tb.StopTimer();
        }

        private bool iCheckParams(SPWeb web, SPWeb lWeb)
        {
            tb.AddTimer();
            SPList oList = null;
            SPList oTaskList = null;
            sWebId = web.ID.ToString();
            try
            {
                oList = web.Lists[new Guid(sProjectListId)];
                sListProjectCenter = oList.Title;
            }
            catch { }

            try
            {
                oTaskList = web.Lists[new Guid(sTaskListId)];
                sListTaskCenter = oTaskList.Title;
            }
            catch { }

            LoadDefaults(oList);

            if (String.IsNullOrEmpty(sProjectListId))
            {
                if (!String.IsNullOrEmpty(sPlannerID))
                {
                    sListProjectCenter = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "ProjectCenter");

                    try
                    {
                        oList = web.Lists[sListProjectCenter];

                        sProjectListId = oList.ID.ToString();
                    }
                    catch { }
                }
            }

            if (String.IsNullOrEmpty(sPlannerID))
            {
                if (!String.IsNullOrEmpty(sProjectListId))
                {
                    SortedList slPlanners = WorkPlannerAPI.GetPlannersByProjectList(oList.Title, web);



                    if (slPlanners.Count == 1)
                    {
                        string sTempPlanner = slPlanners.GetKey(0).ToString();

                        bool bOnline = false;
                        bool bProject = false;

                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline") == "" ? "true" : EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline"), out bOnline);
                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableProject"), out bProject);

                        if (bOnline && bProject)
                        {

                        }
                        else if (bOnline)
                        {
                            sPlannerID = slPlanners.GetKey(0).ToString();
                            sProjectType = "Online";
                        }
                        else if (bProject)
                        {
                            sPlannerID = slPlanners.GetKey(0).ToString();
                            sProjectType = "Project";
                        }
                    }
                }
                if (String.IsNullOrEmpty(sPlannerID))
                {
                    if (!String.IsNullOrEmpty(sTaskListId))
                    {
                        SortedList slPlanners = WorkPlannerAPI.GetPlannersByTaskList(web, oTaskList.Title);

                        if (slPlanners.Count == 1)
                        {
                            string sTempPlanner = slPlanners.GetKey(0).ToString();

                            bool bOnline = false;
                            bool bProject = false;

                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline") == "" ? "true" : EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableOnline"), out bOnline);
                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sTempPlanner + "EnableProject"), out bProject);


                            if (bOnline && bProject)
                            {

                            }
                            else if (bOnline)
                            {
                                sPlannerID = slPlanners.GetKey(0).ToString();
                                sProjectType = "Online";
                            }
                            else if (bProject)
                            {
                                sPlannerID = slPlanners.GetKey(0).ToString();
                                sProjectType = "Project";
                            }
                        }
                    }
                }
            }

            if (String.IsNullOrEmpty(sProjectType) && !String.IsNullOrEmpty(sPlannerID))
            {
                bool bOnline = false;
                bool bProject = false;

                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "EnableOnline") == "" ? "true" : EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "EnableOnline"), out bOnline);
                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "EnableProject"), out bProject);

                if (bOnline && bProject)
                {

                }
                else if (bOnline)
                {
                    sProjectType = "Online";
                }
                else if (bProject)
                {
                    sProjectType = "Project";
                }
                else
                    sProjectType = "Online";
            }

            if (String.IsNullOrEmpty(sItemID) && !String.IsNullOrEmpty(sProjectListId))
            {
                if (oList.Items.Count == 1)
                    sItemID = oList.Items[0].ID.ToString();
            }

            if (String.IsNullOrEmpty(sTaskListId))
            {
                if (!String.IsNullOrEmpty(sPlannerID))
                {
                    if (sPlannerID == "MPP")
                    {
                        sListTaskCenter = "Task Center";

                        try
                        {
                            SPList tList = web.Lists.TryGetList(sListTaskCenter);
                            if (tList != null)
                                sTaskListId = tList.ID.ToString();
                        }
                        catch { }
                    }
                    else
                    {
                        sListTaskCenter = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "TaskCenter");

                        try
                        {
                            SPList tList = web.Lists.TryGetList(sListTaskCenter);
                            if (tList != null)
                                sTaskListId = tList.ID.ToString();
                        }
                        catch { }
                    }
                }
            }

            if (!String.IsNullOrEmpty(sPlannerID))
            {
                sListTaskCenter = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + sPlannerID + "TaskCenter");
            }

            tb.StopTimer();

            if (!String.IsNullOrEmpty(sPlannerID) && !String.IsNullOrEmpty(sProjectListId) && !String.IsNullOrEmpty(sItemID) && !String.IsNullOrEmpty(sProjectType) && !String.IsNullOrEmpty(sTaskListId))
            {
                SPList lstProjectCenter = web.Lists[sListProjectCenter];

                SPListItem liProject = lstProjectCenter.GetItemById(int.Parse(sItemID));

                sProjectName = liProject.Title;

                if (sProjectType == "Online")
                {
                    SPFile tFile = WorkPlannerAPI.GetTaskFile(web, sItemID, sPlannerID);

                    if ((tFile == null || !tFile.Exists) && PopulateTemplates(web))
                    {
                        return false;
                    }

                    return true;
                }
                else
                {
                    string sPlannerIDPath = "";
                    if (sPlannerID != "MPP")
                        sPlannerIDPath = sPlannerID + "/";

                    SPFile tFile = web.GetFile("Project Schedules/" + sPlannerIDPath + sProjectName + ".mpp");

                    if ((tFile == null || !tFile.Exists) && sPlannerID != "MPP" && PopulateTemplates(web))
                    {
                        return false;
                    }

                    return true;

                }
            }
            else
                return false;
        }

        private bool PopulateTemplates(SPWeb web)
        {

            DataTable dtTemplates = WorkPlannerAPI.GetTemplates(web, sPlannerID, sProjectType);

            if (dtTemplates.Rows.Count == 0)
            {
                if (sProjectType == "Project")
                {
                    WorkPlannerAPI.ApplyNewTemplate(web, "", "", sItemID, sProjectType, sProjectName);
                }
                return false;
            }
            else if (dtTemplates.Rows.Count == 1 && dtTemplates.Rows[0]["ID"].ToString() != "-101")
            {
                WorkPlannerAPI.ApplyNewTemplate(web, sPlannerID, dtTemplates.Rows[0]["ID"].ToString(), sItemID, sProjectType, sProjectName);
                return false;
            }
            else
            {
                return true;
            }


        }

        private bool checkParams(SPWeb web)
        {
            tb.AddTimer();

            switch (Request["Planner"])
            {
                case "MSProject":
                case "MPP":
                case "WEWorkPlanner":
                case "WEAgilePlanner":
                    return true;
            }

            sItemID = Request["ID"];
            sProjectListId = Request["listid"];
            sPlannerID = Request["Planner"];
            sProjectType = Request["PType"];
            sTaskListId = Request["tasklistid"];

            if (hasChildParent(web, Request["listid"], Request["ID"]) && String.IsNullOrEmpty(Request["PCSelected"]))
            {
                return false;
            }
            else
            {
                bool check = false;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    using (SPSite site = new SPSite(web.Site.ID))
                    {
                        using (SPWeb iweb = site.OpenWeb(web.ID))
                        {
                            Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(iweb);
                            if (lockWeb == Guid.Empty || lockWeb == web.ID)
                            {
                                check = iCheckParams(web, web);
                            }
                            else
                            {
                                using (SPWeb w = site.OpenWeb(lockWeb))
                                {
                                    check = iCheckParams(web, w);
                                }

                            }
                        }
                    }
                });
                tb.StopTimer();
                return check;

            }

        }

        private StringBuilder GetViewString(string[] props, string[] agileprops)
        {
            StringBuilder sb = new StringBuilder();

            if (props.Length > 1)
            {

                sb.Append(GetCleanString(props[0].ToString()));
                sb.Append(": {");
                sb.Append("title: \"");
                sb.Append(HttpUtility.HtmlEncode(props[0].ToString()).Replace("'", ""));
                sb.Append("\",");
                sb.Append("leftCols: \"");
                sb.Append(props[1]);
                sb.Append("\",");
                sb.Append("cols: \"");
                sb.Append(props[2]);
                sb.Append("\",");
                sb.Append("filters: \"");
                sb.Append(props[3]);
                sb.Append("\",");
                sb.Append("grouping: \"");
                sb.Append(props[4]);
                sb.Append("\",");
                sb.Append("sorting: \"");
                sb.Append(props[5]);
                sb.Append("\",");
                sb.Append("gantt: \"");
                sb.Append(props[6]);
                sb.Append("\",");
                sb.Append("details: \"");
                sb.Append(props[7]);
                sb.Append("\",");

                try
                {
                    if (props.Length > 9)
                    {
                        sb.Append("assignments: \"");
                        sb.Append(props[9]);
                        sb.Append("\",");
                    }
                }
                catch { }
                try
                {
                    if (props.Length > 10)
                    {
                        sb.Append("summary: \"");
                        sb.Append(props[10]);
                        sb.Append("\",");
                    }
                }
                catch { }
                try
                {
                    if (props.Length > 11)
                    {
                        sb.Append("allocation: \"");
                        sb.Append(props[11]);
                        sb.Append("\",");
                    }
                }
                catch { }

                if (bAgile)
                {
                    try
                    {
                        if (agileprops.Length > 0)
                        {
                            sb.Append("agileleft: \"");
                            sb.Append(agileprops[0]);
                            sb.Append("\",");
                        }
                    }
                    catch { }

                    try
                    {
                        if (agileprops.Length > 1)
                        {
                            sb.Append("agilecols: \"");
                            sb.Append(agileprops[1]);
                            sb.Append("\",");
                        }
                    }
                    catch { }
                    try
                    {
                        if (agileprops.Length > 2)
                        {
                            sb.Append("agilefilters: \"");
                            sb.Append(agileprops[2]);
                            sb.Append("\",");
                        }
                    }
                    catch { }
                    try
                    {
                        if (agileprops.Length > 3)
                        {
                            sb.Append("agilegrouping: \"");
                            sb.Append(agileprops[3]);
                            sb.Append("\",");
                        }
                    }
                    catch { }
                    try
                    {
                        if (agileprops.Length > 4)
                        {
                            sb.Append("agilesorting: \"");
                            sb.Append(agileprops[4]);
                            sb.Append("\",");
                        }
                    }
                    catch { }
                    try
                    {
                        if (agileprops.Length > 5)
                        {
                            sb.Append("agilegantt: \"");
                            sb.Append(agileprops[5]);
                            sb.Append("\",");
                        }
                    }
                    catch { }
                    try
                    {
                        if (agileprops.Length > 6)
                        {
                            sb.Append("backlog: \"");
                            sb.Append(agileprops[6]);
                            sb.Append("\",");
                        }
                    }
                    catch { }
                }

                sb.Append("folders: \"");
                sb.Append(props[8]);
                sb.Append("\"");
                sb.Append("}");
            }
            return sb;
        }

        protected void GetResourceList(SPWeb web)
        {
            tb.AddTimer();
            sResourceList = PlannerCore.getResourceList("<Team ListId='" + sProjectListId + "' ItemId='" + sItemID + "'><Columns>Title</Columns></Team>", web);
            tb.StopTimer();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            tb.AddTimer();
            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

            activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WorkPlanner);

            if (activation != 0)
            {
                pnlMain.Visible = false;
                lblAct.Text = act.translateStatus(activation);
                pnlAct.Visible = true;
                return;
            }

            DecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            GroupSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;

            SPWeb web = SPContext.Current.Web;
            sSource = Request["Source"];
            sWebUrl = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;

            docLib = web.Lists.TryGetList("Project Schedules");

            if (!String.IsNullOrEmpty(Request["setdefault"]))
            {
                try
                {
                    if (bool.Parse(Request["setdefault"]))
                        setDefault(web);
                }
                catch { }
            }

            if (checkParentChild(web, Request["listid"], Request["ID"]))
            {
                return;
            }
            if (!checkParams(web))
            {
                sPlannerID = "";
                sPlannerName = "Planner";
                showPlannerPopup();
                return;
            }
            if (sProjectType == "Project" && sPlannerID != "MPP")
            {
                pnlProject.Visible = true;
                pnlMain.Visible = false;

                string planners = EPMLiveCore.CoreFunctions.getLockConfigSetting(SPContext.Current.Web, "EPMLivePlannerPlanners", false);

                foreach (string planner in planners.Split(','))
                {
                    if (planner != "")
                    {
                        string[] sPlanner = planner.Split('|');

                        if (sPlanner[0] == sPlannerID)
                        {
                            sPlannerName = sPlanner[1];
                            sPlannerID = sPlanner[0];
                        }
                    }
                }

                WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(web, sPlannerID);
                sListProjectCenter = props.sListProjectCenter;

                SPList lstProjectCenter = web.Lists[sListProjectCenter];

                SPListItem liProject = lstProjectCenter.GetItemById(int.Parse(sItemID));

                sProjectName = liProject.Title;

            }
            else if (Request["Planner"] == "MSProject" || Request["Planner"] == "MPP")
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                    {
                        using (SPWeb rweb = site.OpenWeb(web.ID))
                        {
                            SPList list = web.Lists.TryGetList(EPMLiveCore.CoreFunctions.getLockConfigSetting(rweb, "epmlivepub-pc", true));
                            if (list != null)
                            {
                                sProjectListId = list.ID.ToString().ToUpper();
                                if (String.IsNullOrEmpty(sSource))
                                {
                                    sSource = list.DefaultView.ServerRelativeUrl;
                                }
                            }
                        }
                    }
                });

                sItemID = Request["ID"];
                pnlMain.Visible = false;
                pnlMSProject.Visible = true;
            }
            else if (Request["Planner"] == "WEWorkPlanner")
            {
                sItemID = Request["ID"];
                pnlMain.Visible = false;
                pnlOldPlanner.Visible = true;
                OldUrl = "tasks";
            }
            else if (Request["Planner"] == "WEAgilePlanner")
            {
                sItemID = Request["ID"];
                pnlMain.Visible = false;
                pnlOldPlanner.Visible = true;
                OldUrl = "agile/tasks";
            }
            else if (docLib == null)
            {
                pnlProjectSchedule.Visible = true;
                pnlMain.Visible = false;
            }
            else
            {
                //sEditorID = taskNotes.ClientID;

                bool found = false;

                string planners = EPMLiveCore.CoreFunctions.getLockConfigSetting(SPContext.Current.Web, "EPMLivePlannerPlanners", false);

                foreach (string planner in planners.Split(','))
                {
                    if (planner != "")
                    {
                        string[] sPlanner = planner.Split('|');

                        if (sPlanner[0] == sPlannerID)
                        {
                            sPlannerName = sPlanner[1];
                            sPlannerID = sPlanner[0];
                            found = true;
                        }
                    }
                }

                if (!found)
                {
                    showPlannerPopup();
                }
                else
                {

                    WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(web, sPlannerID);
                    sListProjectCenter = props.sListProjectCenter;
                    sListTaskCenter = props.sListTaskCenter;
                    bUseFolders = props.bUseFolders;
                    iTaskType = props.iTaskType.ToString();
                    bAgile = props.bAgile;
                    bEnableLink = props.bEnableLinking;
                    bCalcCost = props.bCalcCost;
                    bCalcWork = props.bCalcWork;

                    iWorkHours = props.iWorkHours[3] / 60 - props.iWorkHours[0] / 60 - (props.iWorkHours[2] - props.iWorkHours[1]);

                    SPList lstProjectCenter = web.Lists[sListProjectCenter];
                    SPList lstTaskCenter = web.Lists[sListTaskCenter];

                    //EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(lstProjectCenter);

                    SPListItem liProject = lstProjectCenter.GetItemById(int.Parse(sItemID));

                    //====================EPK============
                    try
                    {
                        string menus = "";
                        menus = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "EPK" + lstProjectCenter.Title.Replace(" ", "") + "_menus");
                        if (menus == "")
                            menus = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "EPKMenus");

                        ArrayList arrButtons = new ArrayList(menus.Split('|'));

                        string noactivex = "";
                        noactivex = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "EPK" + lstProjectCenter.Title.Replace(" ", "") + "_nonactivexs");
                        if (noactivex == "")
                            noactivex = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "epknonactivexs");

                        ArrayList arrActivex = new ArrayList(menus.Split('|'));

                        if (arrButtons.Contains("costs"))
                        {
                            EPKCost = 1;
                        }
                        if (arrButtons.Contains("resplan"))
                        {
                            if (arrActivex.Contains("resplan"))
                            {
                                EPKResPlan = 1;
                            }
                            else
                            {
                                EPKResPlan = 2;
                            }
                        }
                    }
                    catch { }
                    //=================================


                    bool canEdit = false;
                    if (web.CurrentUser.IsSiteAdmin)
                        canEdit = true;
                    try
                    {
                        SPFieldLookupValue lv = new SPFieldLookupValue(liProject[lstProjectCenter.Fields.GetFieldByInternalName("Author").Id].ToString());
                        if (lv.LookupId == web.CurrentUser.ID)
                            canEdit = true;
                    }
                    catch { }
                    try
                    {

                        SPList lstDocs = web.Lists["Project Schedules"];



                        string uplanners = "";
                        try
                        {
                            uplanners = liProject[lstProjectCenter.Fields.GetFieldByInternalName("Planners").Id].ToString();
                        }
                        catch { }
                        if (uplanners == "")
                        {
                            if (liProject.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                            {
                                if (lstTaskCenter.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                                {
                                    if (lstDocs.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                                    {
                                        canEdit = true;
                                    }
                                    else
                                    {
                                        lblPerms.Text = "You do not have permissions to edit the Project Schedules library.";
                                    }
                                }
                                else
                                {
                                    lblPerms.Text = "You do not have permissions to edit task center items.";
                                }
                            }
                            else
                            {
                                lblPerms.Text = "You do not have permissions to edit the project.";
                            }
                        }
                        else
                        {
                            SPFieldLookupValueCollection lvs = new SPFieldLookupValueCollection(uplanners);
                            foreach (SPFieldLookupValue lv in lvs)
                            {
                                if (lv.LookupId == web.CurrentUser.ID)
                                {
                                    if (liProject.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                                    {
                                        if (lstTaskCenter.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                                        {
                                            if (lstDocs.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                                            {
                                                canEdit = true;
                                            }
                                            else
                                            {
                                                lblPerms.Text = "You do not have permissions to edit the Project Schedules library.";
                                            }
                                        }
                                        else
                                        {
                                            lblPerms.Text = "You do not have permissions to edit task center items.";
                                        }
                                    }
                                    else
                                    {
                                        lblPerms.Text = "You do not have permissions to edit the project.";
                                    }
                                }
                            }
                        }
                    }
                    catch { }

                    if (!canEdit)
                    {
                        pnlMain.Visible = false;
                        pnlPerms.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            sBaselineDate = ((DateTime)liProject[sPlannerID + "BD"]).ToString();
                        }
                        catch { }

                        sProjectListId = lstProjectCenter.ID.ToString().ToUpper();
                        sProjectName = liProject.Title;

                        if (String.IsNullOrEmpty(sSource))
                        {
                            sSource = lstProjectCenter.DefaultView.ServerRelativeUrl;
                        }
                        else
                        {
                            if (Request["isDlg"] != null && Request["isDlg"] == "1")
                            {
                                sSource += "&ismodaldlg=1";
                            }
                        }

                        sFolderDataParam = "<Grid ID='" + sItemID + "' Planner='" + sPlannerID + "'/>";
                        sPlannerLayoutParam = "<Grid View='' ID='" + sItemID + "' Planner='" + sPlannerID + "'/>";
                        sPlannerDataParam = "<Grid ID='" + sItemID + "' Planner='" + sPlannerID + "'/>";

                        //sFolderDataParam = HttpUtility.HtmlEncode(sFolderDataParam);
                        //sPlannerDataParam = HttpUtility.HtmlEncode(sPlannerDataParam);
                        //sPlannerLayoutParam = HttpUtility.HtmlEncode(sPlannerLayoutParam);

                        sFolderDataParam = HttpUtility.HtmlEncode(sFolderDataParam);
                        sPlannerDataParam = HttpUtility.HtmlEncode(sPlannerDataParam);
                        sPlannerLayoutParam = HttpUtility.HtmlEncode(sPlannerLayoutParam);

                        if (bAgile)
                        {
                            agileDiv = Properties.Resources.txtAgileDiv.Replace("<%=sPlannerLayoutParam%>", sPlannerLayoutParam).Replace("<%=sPlannerDataParam%>", sPlannerDataParam);
                        }


                        //if(gSettings.BuildTeam)
                        //SPSecurity.RunWithElevatedPrivileges(delegate()
                        //{
                        //    using(SPSite tSite = new SPSite(web.Site.ID))
                        //    {
                        //        using(SPWeb tWeb = tSite.OpenWeb(web.ID))
                        //        {
                        GetResourceList(web);
                        //        }
                        //    }
                        //});
                        //else
                        //    sResourceList = PlannerCore.getResourceList("", web);

                        getFields(web);
                        processRollups(props);
                        getAttachedLists(web, lstProjectCenter.ID.ToString("B"));

                        if (lstProjectCenter.Fields.ContainsField(sPlannerID + "FSC"))
                        {
                            try
                            {
                                if (liProject[sPlannerID + "FSC"].ToString().ToLower() == "false")
                                    sSummaryRollup = "false";
                                else
                                    sSummaryRollup = "true";
                            }
                            catch { sSummaryRollup = "true"; }
                        }
                        else
                        {
                            sSummaryRollup = "true";
                        }
                        string defaultView = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLivePlanner" + sPlannerID + "ViewsDefault");

                        string sFullViewsList = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLivePlanner" + sPlannerID + "Views");
                        string[] sViewList = sFullViewsList.Replace(";#", "\n").Split('\n');

                        StringBuilder sb = new StringBuilder();

                        StringBuilder sDefaultView = new StringBuilder();

                        for (int i = 0; i < sViewList.Length; i++)
                        {
                            string[] sViewDataWithAgile = sViewList[i].Split('`');
                            string[] sViewData = sViewDataWithAgile[0].Split('|');
                            string[] sViewAgileData = new string[0] { };
                            try
                            {
                                sViewAgileData = sViewDataWithAgile[1].Split('|');
                            }
                            catch { }

                            if (sViewData.Length > 0)
                            {
                                if (sViewData[0].ToString() == defaultView)
                                {

                                    sDefaultView = GetViewString(sViewData, sViewAgileData);

                                }
                                else
                                {
                                    sb.Append(",");
                                    sb.Append(GetViewString(sViewData, sViewAgileData));
                                }
                            }
                        }

                        try
                        {
                            if (sDefaultView.ToString() != "")
                                sViewObject = String.Join(",", new string[] { sDefaultView.ToString(), sb.ToString().Trim(',') }).Trim(',');
                            else
                                sViewObject = sb.ToString().Trim(',');
                        }
                        catch { }
                    }
                }
            }
            tb.StopTimer();
            if (Request["debug"] == "true")
                timerString = tb.GetHtml();
        }

        protected override void OnPreRender(EventArgs e)
        {
            tb.AddTimer();
            base.OnPreRender(e);


            if (activation == 0)
            {
                if (!String.IsNullOrEmpty(sItemID) && !String.IsNullOrEmpty(sPlannerID) && pnlMain.Visible)
                {
                    this.AddRibbonTab();
                }
                AddTabEvents();                
            }
            tb.StopTimer();

        }

        private void AddRibbonTab()
        {
            // Gets the current instance of the ribbon on the page.
            SPRibbon ribbon = SPRibbon.GetCurrent(this.Page);

            //Prepares an XmlDocument object used to load the ribbon
            XmlDocument ribbonExtensions = new XmlDocument();

            //WorkPlanner Tab
            ribbonExtensions.LoadXml(Properties.Resources.txtWorkPlannerTab.Replace("#language#", Web.Language.ToString()));
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.Tabs._children");

            //Project Tab
            ribbonExtensions.LoadXml(Properties.Resources.txtProjectTab);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.Tabs._children");

            //Views Tab
            ribbonExtensions.LoadXml(Properties.Resources.txtViewsTab);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.Tabs._children");

            //Load the custom templates and register the ribbon.
            ribbonExtensions.LoadXml(Properties.Resources.txtWorkPlannerTabTempalte);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.Templates._children");

            ribbon.Minimized = false;
            ribbon.CommandUIVisible = true;
            const string initialTabId = "Ribbon.WorkPlanner";

            if (!ribbon.IsTabAvailable(initialTabId))
                ribbon.MakeTabAvailable(initialTabId);

            if (!ribbon.IsTabAvailable("Ribbon.Project"))
                ribbon.MakeTabAvailable("Ribbon.Project");

            if (!ribbon.IsTabAvailable("Ribbon.WorkViews"))
                ribbon.MakeTabAvailable("Ribbon.WorkViews");

            if (!EPMLiveCore.CoreFunctions.DoesCurrentUserHaveFullControl(SPContext.Current.Web))
            {
                ribbon.TrimById("Ribbon.WorkViews.WorkViewsGroup.SaveView");
                ribbon.TrimById("Ribbon.WorkViews.WorkViewsGroup.DeleteView");
            }

            if (!bEnableLink)
            {
                ribbon.TrimById("Ribbon.WorkPlanner.InsertGroup.LinkExternalTask");
            }

            if (bAgile)
            {
                ribbon.TrimById("Ribbon.WorkPlanner.InsertGroup.NewSummary");

                ribbon.TrimById("Ribbon.WorkPlanner.ScheduleGroup.LinkDown");
                ribbon.TrimById("Ribbon.WorkPlanner.ScheduleGroup.LinkUp");
                ribbon.TrimById("Ribbon.WorkPlanner.ScheduleGroup.Unlink");
            }
            else
            {
                ribbon.TrimById("Ribbon.WorkPlanner.InsertGroup.NewIteration");
                ribbon.TrimById("Ribbon.WorkPlanner.InsertGroup.ShowBacklog");
            }

            if (Web.Site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] == null)
            {
                ribbon.TrimById("Ribbon.WorkPlanner.ToolsGroup.EditCosts");
                ribbon.TrimById("Ribbon.WorkPlanner.ToolsGroup.EditResourcePlan");
            }


            ribbon.TrimById("Ribbon.WorkPlanner.ClipGroup.Copy");
            ribbon.TrimById("Ribbon.WorkPlanner.ClipGroup.Paste");


            ribbon.InitialTabId = initialTabId;            
        }

        public static string GetCleanString(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || (str[i] >= 'A' && str[i] <= 'z' || (str[i] == '.' || str[i] == '_')))
                    sb.Append(str[i]);
            }
            return sb.ToString();
        }

        private SPList CreateOrGetPlannerFragmentList()
        {
            //Create New 'PlannerFragments' list with following columns:
            //Title[PlannerName - Single Line of Text], Description [Multiple Line of Text], FragmentType [Choice], Tag [single Line of Text], FragmentXml [Multiple line of Text]
            try
            {
                SPSite site = SPContext.Current.Site;
                SPWeb web = SPContext.Current.Web;
                SPList plannerFragmentList = web.Lists.TryGetList("PlannerFragments");

                if (plannerFragmentList == null)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite currentSite = new SPSite(site.ID))
                        {
                            using (SPWeb currentWeb = currentSite.OpenWeb(web.ID))
                            {
                                currentWeb.AllowUnsafeUpdates = true;
                                Guid guid = currentWeb.Lists.Add("PlannerFragments", "Planner Fragments List - Used to store Planner Fragment details", SPListTemplateType.GenericList);
                                plannerFragmentList = currentWeb.Lists[guid];
                                //plannerFragmentList.Hidden = true; //TODO: Uncomment this while code check-in

                                plannerFragmentList.Fields.Add("Description", SPFieldType.Note, false);
                                plannerFragmentList.Fields.Add("FragmentType", SPFieldType.Choice, false);
                                plannerFragmentList.Fields.Add("FragmentXML", SPFieldType.Note, true);
                                plannerFragmentList.Fields.Add("PlannerID", SPFieldType.Text, false);
                                plannerFragmentList.Update();

                                //Add Planner Type - Choice Field
                                SPFieldChoice fragmentTypes = (SPFieldChoice)plannerFragmentList.Fields["FragmentType"];
                                fragmentTypes.Choices.Add("Private");
                                fragmentTypes.Choices.Add("Public");
                                fragmentTypes.DefaultValue = "Private";
                                fragmentTypes.Update();  //Saves choices to column
                                plannerFragmentList.Update();

                                SPView view = plannerFragmentList.DefaultView;
                                view.ViewFields.Add("Description");
                                view.ViewFields.Add("FragmentType");
                                view.ViewFields.Add("PlannerID");
                                view.ViewFields.Add("Author");
                                view.Update();

                                plannerFragmentList.Update();
                                currentWeb.Update();
                            }
                        }
                    });
                }
                return plannerFragmentList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void AddTabEvents()
        {
            var commands = new List<IRibbonCommand>();

            // register the command at the ribbon. Include the callback to the server     // to generate the xml
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.SaveButton", "SaveWorkPlan();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.PublishButton", "PublishWorkPlan();", "GridHasChanges()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.PrintButton", "PrintPlan();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.CloseButton", "Close();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ExcelButton", "ExcelExport();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.PDFButton", "PDFExport();", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.NewTask", "NewTask(false, false);", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.NewSummary", "NewTask(true, false);", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.NewIteration", "AgileNewIteration(true, false);", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.NewMilestone", "NewTask(false, true);", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.DeleteTasks", "DeleteTasks();", "MoreThan0Selected()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ShowBacklog", "ShowBacklog();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.LinkExternalTask", "LinkExternalTask();", "CanLinkExternal"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Details", "ShowTab('t1');", "canShowDetails"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Notes", "ShowNotes();", "canShowDetails"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Links", "ShowTab('t3');", "canShowDetails"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Comments", "OpenLocation('epmlive/comments','Comments');", "canShowDetails"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Alerts", "OpenLocation('subnew','Alerts');", "canShowDetails"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.History", "OpenLocation('versions','Version History');", "canShowDetails"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Permissions", "OpenLocation('user','Permissions');", "canShowDetails"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Attachments", "OpenLocation('attachfile','Attach File');", "canShowDetails"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Workflows", "OpenLocation('workflow','Workflows');", "canShowDetails"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Copy", "Copy();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Paste", "Paste();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Undo", "Undo();", "CanUndo()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Redo", "Redo();", "CanRedo()"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.AssignResources", "ShowTab('t2');", "canShowDetails"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.EditTeam", "BuildTeam();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ResourceInformation", "ResourceInformation();", "CanResourceInfo()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.CheckResource", "CheckResources();", "Just1Selected()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.SelectResColumns", "SelectResColumns();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ShowResGrid", "ShowResGrid();", "true"));


            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Indent", "Indent();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Outdent", "Outdent();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.LinkDown", "AddLinkMenu('down');", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.LinkUp", "AddLinkMenu('up');", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Unlink", "Unlink();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Percent0", "SetPercent(0);", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Percent50", "SetPercent(50);", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Percent100", "SetPercent(100);", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ZoomIn", "ZoomIn();", "CanZoomIn()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ZoomOut", "ZoomOut();", "CanZoomOut()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ZoomFit", "ZoomFit();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ScrollTo", "ScrollTo();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ShowHideGantt", "ShowHideGantt();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ShowBaseline", "ShowBaseline();", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.SaveView", "SaveView();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.EditView", "EditView();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.DeleteView", "DeleteView();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.CurrentView", "return true;", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.DisplayView", "DisplayView();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.SelectColumns", "SelectColumns();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.CreateColumn", "CreateColumn();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ShowFilters", "ShowFilters();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ShowGrouping", "ShowGrouping();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ClearSort", "ClearSort();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ShowAssignments", "ShowAssignments();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ShowSummary", "ShowSummary();", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.UpdateProject", "UpdateProject();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.UpdateStatus", "DoUpdates();", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ProjectInfo", "ShowTab('t4');", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.DisableCalc", "DisableCalc();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.SetBaseline", "SetBaseline();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ClearBaseline", "ClearBaseline();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.MoveProject", "MoveProject();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.RespectLinks", "RespectLinks();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.SummaryRollup", "SummaryRollup();", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.CreateNew", "DoCreateNew();", "true"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ImportFrom", "", "GridHasChanges()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ImportList", "ImportList();", "GridHasChanges()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ImportExcel", "ImportExcel();", "GridHasChanges()"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ImportCsv", "ImportCsv();", "GridHasChanges()"));

            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.SaveTemplate", "SaveTemplate();", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.EditCosts", "EditCosts();", "EPKEnabled('costs')"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.EditResourcePlan", "EditResourcePlan();", "EPKEnabled('resplan')"));

            //Fragment Section

            //Insert Fragment option is enabled for all users.
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.Fragment", "", "true"));
            commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.AddFragmentButton", "AddFragment();", "true"));

            //SPBasePermissions.ManageWeb – This is for saving public views
            //SPBasePermissions.EditListItems – Check this against the PlannerFragments list to see if the user can save fragments. If they have this but not manageweb then they can save private fragments only.
            //Any other users can’t save fragments, but can read them.
            bool doesUserHasEditListItemsPermission = false;
            SPList plannerFragmentsList = CreateOrGetPlannerFragmentList();

            if (plannerFragmentsList != null)
            {
                doesUserHasEditListItemsPermission = plannerFragmentsList.DoesUserHavePermissions(SPContext.Current.Web.CurrentUser, SPBasePermissions.EditListItems);
                commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.SaveFragmentButton", "SaveFragment();", doesUserHasEditListItemsPermission.ToString().ToLower()));
                commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.ManageFragmentButton", "ManageFragment();", doesUserHasEditListItemsPermission.ToString().ToLower()));
            }

            //commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.DoCreateNew", "DoCreateNew();", "true"));
            //commands.Add(new SPRibbonCommand("Ribbon.WorkPlanner.PopulateDisplayView", "PopulateDisplayView();", "true"));

            //Register initialize function
            var manager = new SPRibbonScriptManager();

            var methodInfo = typeof(SPRibbonScriptManager).GetMethod("RegisterInitializeFunction", BindingFlags.Instance | BindingFlags.NonPublic);

            methodInfo.Invoke(manager, new object[] { Page, "InitPageComponent", "/_layouts/epmlive/WorkPlannerPageComponent.js", false, "WorkPlannerPageComponent.PageComponent.initialize()" });

            // Register ribbon scripts
            manager.RegisterGetCommandsFunction(Page, "getGlobalCommands", commands);
            manager.RegisterCommandEnabledFunction(Page, "commandEnabled", commands);
            manager.RegisterHandleCommandFunction(Page, "handleCommand", commands);
        }
    }
}
