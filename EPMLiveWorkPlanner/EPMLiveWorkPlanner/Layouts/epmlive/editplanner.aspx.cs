using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPMLiveWorkPlanner
{
    public partial class editplanner : LayoutsPageBase
    {
        #region Controls and Variables

        protected GridView GridView1;
        protected DropDownList ddlAddCalculation;
        protected TextBox txtAddField;
        protected DropDownList ddlProjectCenter;
        protected DropDownList ddlTaskCenter;

        static PlannerCore.WorkPlannerProperties wps;

        protected string statusfields = "";
        protected string kanbanAdditionalColumns = "";
        protected string kanbanItemStatusFields = "";

        protected string workstart = "0";
        protected string workend = "0";
        protected string workhours = "0";

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            workstart = (web.RegionalSettings.WorkDayStartHour / 60).ToString();
            workend = (web.RegionalSettings.WorkDayEndHour / 60).ToString();
            workhours = ((web.RegionalSettings.WorkDayEndHour - web.RegionalSettings.WorkDayStartHour) / 60).ToString();

            for (int i = (web.RegionalSettings.WorkDayStartHour / 60) + 1; i < (web.RegionalSettings.WorkDayEndHour / 60); i++)
            {
                ddlLunchStart.Items.Add(new ListItem(i.ToString() + ":00", i.ToString()));
                ddlLunchEnd.Items.Add(new ListItem(i.ToString() + ":00", i.ToString()));
            }

            if (!String.IsNullOrEmpty(Request["statusfields"]))
                statusfields = Request["statusfields"];

            if (!String.IsNullOrEmpty(Request["kanbanAdditionalColumns"]))
                kanbanAdditionalColumns = Request["kanbanAdditionalColumns"];

            if (!String.IsNullOrEmpty(Request["kanbanItemStatusFields"]))
                kanbanItemStatusFields = Request["kanbanItemStatusFields"];

            if (!IsPostBack)
            {
                try
                {
                    chkOnlinePlanner.Attributes.Add("onclick", "Javascript:ToggleOnline();");
                    chkProjectPlanner.Attributes.Add("onclick", "Javascript:ToggleProject();");
                    chkAgilePlanner.Attributes.Add("onclick", "Javascript:ToggleAgile();");
                    chkKanBanPlanner.Attributes.Add("onclick", "Javascript:ToggleKanBan();");

                    Guid lWeb = EPMLiveCore.CoreFunctions.getLockedWeb(web);

                    if (Request["name"] != "")
                    {
                        wps = new PlannerCore.WorkPlannerProperties(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "Fields"));

                        loadFields(web);

                        string curList = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "ProjectCenter");

                        foreach (SPList list in web.Lists)
                        {
                            ListItem li = new ListItem(list.Title, list.ID.ToString().ToLower());
                            if (list.Title.ToLower() == curList.ToLower())
                                li.Selected = true;

                            ddlProjectCenter.Items.Add(li);
                        }

                        filltasklist(web);

                        //fillbackloglist(web);
                        statusfields = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "StatusFields");
                        try
                        {
                            bool c = false;
                            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "UseFolders"), out c);
                            chkUseFolders.Checked = c;
                        }
                        catch { }

                        try
                        {
                            chkOnlinePlanner.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "EnableOnline"));
                        }
                        catch { chkOnlinePlanner.Checked = true; }

                        try
                        {
                            chkProjectPlanner.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "EnableProject"));
                        }
                        catch { }

                        try
                        {
                            chkAgilePlanner.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "EnableAgile"));
                        }
                        catch { }


                        try
                        {
                            chkCalcWork.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "CalcWork"));
                        }
                        catch { }

                        try
                        {
                            chkCalcCost.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "CalcCost"));
                        }
                        catch { }

                        try
                        {
                            chkDisableParentChild.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "DisablePC"));
                        }
                        catch { }

                        try
                        {
                            ddTaskType.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "TaskType");
                        }
                        catch { }

                        try
                        {
                            ddlStatusMethod.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "StatusMethod");
                        }
                        catch { }

                        try
                        {
                            try
                            {
                                ddlLunchStart.SelectedValue = "12";
                            }
                            catch { }
                            ddlLunchStart.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "LunchStart");
                        }
                        catch { }

                        try
                        {
                            try
                            {
                                ddlLunchEnd.SelectedValue = "13";
                            }
                            catch { }
                            ddlLunchEnd.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "LunchEnd");
                        }
                        catch { }

                        txtDescription.Text = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "Description");

                        string planners = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlannerPlanners");

                        foreach (string planner in planners.Split(','))
                        {
                            if (planner != "")
                            {
                                string[] sPlanner = planner.Split('|');
                                if (sPlanner[0] == Request["name"])
                                {
                                    txtPlannerName.Text = sPlanner[1];
                                }
                            }
                        }

                        filltaskfields(web);
                        loadTaskCenterFields(web, false);

                        ddlSummary.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "PJSummary");
                        ddlTimePhased.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "PJTP");
                        ddlPubType.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "PJType");
                        ddlSynchFields.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "PJfields");
                        ddlPubStatus.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "PJstatus");
                        ddlResourceLink.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "PJreslink");

                        txtIcon.Text = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "Icon");
                        try
                        {
                            chkUseRes.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "PJuseres"));
                        }
                        catch { }

                        try
                        {
                            chkLockPublisher.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "PJLock"));
                        }
                        catch { }

                        try
                        {
                            chkLinking.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "EnableLink"));
                        }
                        catch { }
                        try
                        {
                            chkStartSoon.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "StartSoon"));
                        }
                        catch { }

                        #region KanBan Board Settings

                        try
                        {
                            chkKanBanPlanner.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "EnableKanBan"));
                        }
                        catch { }

                        GetStatusColumns(web);

                        try
                        {
                            ddlKanBanStatusColumn.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "KanBanStatusColumn");
                        }
                        catch { }


                        GetFilterColumns(web);

                        try
                        {
                            ddlKanBanFilterColumn.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "KanBanFilterColumn");
                        }
                        catch { }

                        GetAllListColumns(web, false);

                        try
                        {
                            ddlKanBanTitleColumn.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "KanBanTitleColumn");
                        }
                        catch { }

                        GetColumnValues(web, false);

                        try
                        {
                            kanbanAdditionalColumns = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "KanBanAdditionalColumns");
                        }
                        catch { }

                        try
                        {
                            kanbanItemStatusFields = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "KanBanItemStatusFields");
                        }
                        catch { }

                        #endregion
                    }
                }
                catch { }
            }
        }

        protected void ddlTaskCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusfields = "";
            kanbanAdditionalColumns = "";
            kanbanItemStatusFields = "";
            SPWeb web = SPContext.Current.Web;
            loadTaskCenterFields(web, true);
            filltaskfields(web);
        }

        protected void ddlProjectCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusfields = "";
            kanbanAdditionalColumns = "";
            kanbanItemStatusFields = "";
            SPWeb web = SPContext.Current.Web;
            filltasklist(web);
            //fillbackloglist(web);
            loadTaskCenterFields(web, true);
            filltaskfields(web);
            GetStatusColumns(web);
            GetFilterColumns(web);
            GetAllListColumns(web, true);
            GetColumnValues(web, true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = "";

            SPWeb web = SPContext.Current.Web;
            {
                url = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;

                string plannerName = "";

                string planners = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlannerPlanners");

                plannerName = Request["Name"];

                bool found = false;

                string newPlanners = "";

                if (plannerName != "")
                {
                    foreach (string planner in planners.Split(','))
                    {
                        if (planner != "")
                        {
                            string[] sPlanner = planner.Split('|');
                            if (sPlanner[0] == plannerName)
                            {
                                newPlanners += "," + sPlanner[0] + "|" + txtPlannerName.Text;
                                found = true;
                            }
                            else
                                newPlanners += "," + sPlanner[0] + "|" + sPlanner[1];
                        }
                    }
                }
                if (!found)
                {
                    plannerName = txtPlannerName.Text.Replace(" ", "");
                    newPlanners += "," + plannerName + "|" + txtPlannerName.Text;
                }

                newPlanners = newPlanners.Substring(1);

                if (plannerName != "")
                {
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlannerPlanners", newPlanners);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "Fields", wps.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "ProjectCenter", ddlProjectCenter.SelectedItem.Text);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "TaskCenter", ddlTaskCenter.SelectedItem.Text);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "UseFolders", chkUseFolders.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "TaskType", ddTaskType.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "Description", txtDescription.Text);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "StatusFields", Request["statusfields"]);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "StatusMethod", ddlStatusMethod.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "EnableOnline", chkOnlinePlanner.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "EnableProject", chkProjectPlanner.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "EnableAgile", chkAgilePlanner.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PCField", ddlTaskCenterPJField.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "CalcWork", chkCalcWork.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "CalcCost", chkCalcCost.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "LunchStart", ddlLunchStart.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "LunchEnd", ddlLunchEnd.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "DisablePC", chkDisableParentChild.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "EnableLink", chkLinking.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "StartSoon", chkStartSoon.Checked.ToString());

                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "EnableKanBan", chkKanBanPlanner.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "KanBanStatusColumn", ddlKanBanStatusColumn.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "KanBanFilterColumn", ddlKanBanFilterColumn.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "KanBanTitleColumn", ddlKanBanTitleColumn.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "KanBanAdditionalColumns", Request["kanbanAdditionalColumns"]);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "KanBanItemStatusFields", Request["kanbanItemStatusFields"]);

                    if (chkAgilePlanner.Checked)
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "AgileIterationField", ddlAgileContentType.SelectedValue);

                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "Icon", txtIcon.Text);

                    //Microsoft Project

                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PJSummary", ddlSummary.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PJTP", ddlTimePhased.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PJType", ddlPubType.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PJfields", ddlSynchFields.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PJstatus", ddlPubStatus.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PJreslink", ddlResourceLink.SelectedValue);
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PJuseres", chkUseRes.Checked.ToString());
                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PJLock", chkUseRes.Checked.ToString());

                    string locked = "";
                    if (chkLockPublisher.Checked)
                    {
                        if (ddlPubType.SelectedValue != "")
                            locked = "1";
                        else
                            locked = "0";

                        if (ddlSummary.SelectedValue != "")
                            locked += ",1";
                        else
                            locked += ",0";

                        if (ddlTimePhased.SelectedValue != "")
                            locked += ",1";
                        else
                            locked += ",0";

                        if (ddlPubStatus.SelectedValue != "")
                            locked += ",1";
                        else
                            locked += ",0";

                        if (ddlResourceLink.SelectedValue != "")
                            locked += ",1";
                        else
                            locked += ",0";

                        if (ddlSynchFields.SelectedValue != "")
                            locked += ",1";
                        else
                            locked += ",0";
                    }
                    else
                        locked = "0,0,0,0,0,0";

                    EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "PJLockItems", locked);


                    if (chkLinking.Checked)
                    {

                        SPList list = web.Lists[ddlTaskCenter.SelectedItem.Text];

                        SPField f = null;
                        try
                        {
                            f = list.Fields.GetFieldByInternalName("IsExternal");
                        }
                        catch { }
                        if (f == null)
                        {
                            string sF = list.Fields.Add("IsExternal", SPFieldType.Boolean, false);
                            f = list.Fields.GetFieldByInternalName("IsExternal");
                            f.ShowInEditForm = false;
                            f.ShowInNewForm = false;
                            f.Update();
                        }
                        f = null;
                        try
                        {
                            f = list.Fields.GetFieldByInternalName("ExternalLink");
                        }
                        catch { }
                        if (f == null)
                        {
                            string sF = list.Fields.Add("ExternalLink", SPFieldType.Text, false);
                            f = list.Fields.GetFieldByInternalName("ExternalLink");
                            f.ShowInEditForm = false;
                            f.ShowInNewForm = false;
                            f.Update();
                        }
                    }

                    //Agile
                    //EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + plannerName + "AgileBacklog", ddlAgileBacklog.SelectedItem.Text);
                }
            }
            Response.Redirect(url + "/_layouts/epmlive/planneradmin.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                SPWeb web = SPContext.Current.Web;

                wps.delete(e.CommandArgument.ToString());

                loadFields(web);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                l.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to delete " +
                    DataBinder.Eval(e.Row.DataItem, "field") + "?')");

                HyperLink link = (HyperLink)e.Row.FindControl("HyperLink1");
                link.NavigateUrl = "javascript:editField('" + DataBinder.Eval(e.Row.DataItem, "field") + "','" + DataBinder.Eval(e.Row.DataItem, "calc") + "','" + DataBinder.Eval(e.Row.DataItem, "item_id") + "')";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string id = "";
            try
            {
                id = Request["ctl00$PlaceHolderMain$hdnId"];
            }
            catch { }
            SPWeb web = SPContext.Current.Web;
            wps.set(txtAddField.Text.Replace(" ", "_x0020_"), ddlAddCalculation.SelectedValue);

            loadTaskCenterFields(SPContext.Current.Web, false);

            loadFields(web);

            txtAddField.Text = "";
        }

        #endregion

        #region Methods

        private void filltaskfields(SPWeb web)
        {

            string curField = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "PCField");
            string curAgileCT = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "AgileIterationField");

            ddlTaskCenterPJField.Items.Clear();

            try
            {

                SPList list = web.Lists[new Guid(ddlTaskCenter.SelectedValue)];

                foreach (SPField field in list.Fields)
                {
                    if (field.Type == SPFieldType.Lookup)
                    {
                        SPFieldLookup lp = (SPFieldLookup)field;
                        if (lp.LookupList.ToLower() == "{" + ddlProjectCenter.SelectedValue + "}")
                        {
                            ListItem li = new ListItem(field.Title, field.InternalName);
                            if (list.Title.ToLower() == curField.ToLower())
                                li.Selected = true;

                            ddlTaskCenterPJField.Items.Add(li);
                        }
                    }
                }

                ddlAgileContentType.Items.Clear();

                foreach (SPContentType ct in list.ContentTypes)
                {
                    if (!ct.Hidden)
                    {
                        ListItem li = new ListItem(ct.Name);

                        if (ct.Name == curAgileCT)
                            li.Selected = true;

                        ddlAgileContentType.Items.Add(li);
                    }
                }
            }
            catch { }
        }

        protected void loadTaskCenterFields(SPWeb web, bool clear)
        {
            ArrayList fields = new ArrayList();
            if (statusfields == "")
            {
                try
                {
                    fields = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "StatusFields").Split(','));
                }
                catch { }
            }
            else
            {
                fields = new ArrayList(statusfields.Split(','));
            }

            if (ddlTaskCenter.SelectedItem != null)
            {
                SPList list = web.Lists.TryGetList(ddlTaskCenter.SelectedItem.Text);
                ddlListSelectedFields.Items.Clear();
                ddlListAvailableFields.Items.Clear();
                if (list != null)
                {
                    foreach (SPField f in list.Fields)
                    {
                        if (!f.Hidden && f.Reorderable)
                        {
                            if (fields.Contains(f.InternalName) && !clear)
                                ddlListSelectedFields.Items.Add(new ListItem(f.Title, f.InternalName));
                            else
                                ddlListAvailableFields.Items.Add(new ListItem(f.Title, f.InternalName));
                        }
                    }
                }
            }
        }

        private void filltasklist(SPWeb web)
        {
            ddlTaskCenter.Items.Clear();

            string curList = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "TaskCenter");

            foreach (SPList list in web.Lists)
            {
                bool found = false;
                foreach (SPField field in list.Fields)
                {
                    if (field.Type == SPFieldType.Lookup)
                    {
                        SPFieldLookup lp = (SPFieldLookup)field;
                        if (lp.LookupList.ToLower() == "{" + ddlProjectCenter.SelectedValue + "}")
                        {
                            found = true;
                        }
                    }
                }

                if (found)
                {
                    ListItem li = new ListItem(list.Title, list.ID.ToString().ToLower());
                    if (list.Title.ToLower() == curList.ToLower())
                        li.Selected = true;

                    ddlTaskCenter.Items.Add(li);
                }
            }
        }

        //private void fillbackloglist(SPWeb web)
        //{
        //    ddlAgileBacklog.Items.Clear();

        //    string curList = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "AgileBacklog");

        //    foreach(SPList list in web.Lists)
        //    {
        //        bool found = false;
        //        foreach(SPField field in list.Fields)
        //        {
        //            if(field.Type == SPFieldType.Lookup)
        //            {
        //                SPFieldLookup lp = (SPFieldLookup)field;
        //                if(lp.LookupList.ToLower() == "{" + ddlProjectCenter.SelectedValue + "}")
        //                {
        //                    found = true;
        //                }
        //            }
        //        }

        //        if(found)
        //        {
        //            ListItem li = new ListItem(list.Title, list.ID.ToString().ToLower());
        //            if(list.Title.ToLower() == curList.ToLower())
        //                li.Selected = true;

        //            ddlAgileBacklog.Items.Add(li);
        //        }
        //    }
        //}

        protected void loadFields(SPWeb web)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("field");
            dt.Columns.Add("calc");
            dt.Columns.Add("item_id");

            for (int i = 0; i < wps.count(); i++)
            {
                PlannerCore.WorkPlannerProperty wp = wps.GetByIndex(i);
                dt.Rows.Add(new string[] { wp.field, wp.val, wp.field });
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        #endregion

        #region KanBan Planner Methods

        public void GetStatusColumns(SPWeb web)
        {
            ddlKanBanStatusColumn.Items.Clear();
            try
            {
                if (ddlProjectCenter.SelectedValue != null)
                {
                    SPList list = web.Lists[new Guid(ddlProjectCenter.SelectedValue)];

                    foreach (SPField field in list.Fields)
                    {
                        if (field.Type == SPFieldType.Choice && (!field.Hidden && field.Reorderable))
                        {
                            ListItem li = new ListItem(field.Title, field.InternalName);
                            ddlKanBanStatusColumn.Items.Add(li);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log Exception Message
            }
        }

        public void GetFilterColumns(SPWeb web)
        {
            try
            {
                ddlKanBanFilterColumn.Items.Clear();
                if (ddlProjectCenter.SelectedItem != null)
                {
                    SPList list = web.Lists[new Guid(ddlProjectCenter.SelectedValue)];

                    foreach (SPField field in list.Fields)
                    {
                        if ((field.Type == SPFieldType.Choice ||
                            field.Type == SPFieldType.Lookup ||
                            field.Type == SPFieldType.User) &&
                            (!field.Hidden && field.Reorderable))
                        {
                            ListItem li = new ListItem(field.Title, field.InternalName);
                            ddlKanBanFilterColumn.Items.Add(li);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log Exception Message
            }
        }

        public void GetColumnValues(SPWeb web, bool clear)
        {
            try
            {
                ArrayList fields = new ArrayList();
                if (kanbanItemStatusFields == "")
                {
                    try
                    {
                        fields = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "KanBanItemStatusFields").Split(','));
                    }
                    catch { }
                }
                else
                {
                    fields = new ArrayList(kanbanItemStatusFields.Split(','));
                }

                if (ddlKanBanStatusColumn.SelectedValue != null)
                {
                    ddlKanBanAvailableItemStatus.Items.Clear();
                    ddlKanBanSelectedItemStatus.Items.Clear();

                    SPList list = web.Lists[ddlProjectCenter.SelectedItem.Text];
                    SPFieldChoice choiceField = list.Fields.GetField(ddlKanBanStatusColumn.SelectedValue) as SPFieldChoice;
                    StringCollection choices = choiceField.Choices;

                    if (list != null)
                    {
                        if (choices.Count > 0)
                        {
                            foreach (String choice in choices)
                            {
                                if (fields.Contains(choice) && !clear)
                                    ddlKanBanSelectedItemStatus.Items.Add(choice);
                                else
                                    ddlKanBanAvailableItemStatus.Items.Add(choice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log exception
            }
        }

        public void GetAllListColumns(SPWeb web, bool clear)
        {
            try
            {
                ArrayList fields = new ArrayList();
                if (kanbanAdditionalColumns == "")
                {
                    try
                    {
                        fields = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + Request["name"] + "KanBanAdditionalColumns").Split(','));
                    }
                    catch { }
                }
                else
                {
                    fields = new ArrayList(kanbanAdditionalColumns.Split(','));
                }

                if (ddlProjectCenter.SelectedValue != null)
                {
                    SPList list = web.Lists.TryGetList(ddlProjectCenter.SelectedItem.Text);
                    ddlKanBanAvailableFields.Items.Clear();
                    ddlKanBanSelectedFields.Items.Clear();
                    ddlKanBanTitleColumn.Items.Clear();

                    if (list != null)
                    {
                        foreach (SPField f in list.Fields)
                        {
                            if (!f.Hidden && f.Reorderable)
                            {
                                if (fields.Contains(f.InternalName) && !clear)
                                {
                                    ddlKanBanSelectedFields.Items.Add(new ListItem(f.Title, f.InternalName));
                                }
                                else
                                {
                                    if (f.Id != SPBuiltInFieldId.Title)
                                        ddlKanBanAvailableFields.Items.Add(new ListItem(f.Title, f.InternalName));
                                    ddlKanBanTitleColumn.Items.Add(new ListItem(f.Title, f.InternalName));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log Exception Message
            }
        }

        #endregion

        #region KanBan Planner Events

        protected void ddlKanBanStatusColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetColumnValues(SPContext.Current.Web, false);
        }

        #endregion
    }
}