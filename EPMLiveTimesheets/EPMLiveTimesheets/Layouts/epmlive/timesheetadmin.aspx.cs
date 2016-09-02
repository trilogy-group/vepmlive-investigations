using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace TimeSheets
{
    public partial class timesheetadmin : LayoutsPageBase
    {

        protected Panel pnlTL;
        protected HyperLink hlAdmin;
        protected Panel pnlMain;
        protected CheckBox chkAllowUnassigned;
        protected DropDownList ddlFlagField;
        protected string siteUrl;

        protected string lastPeriod;
        protected string nextStart;
        protected string nextStartEnd;

        protected DateTimeControl dtSpStart;
        protected DateTimeControl dtSpEnd;

        protected TextBox txtLists;
        protected CheckBox chkAllowNotes;

        protected CheckBox chkSunday;
        protected CheckBox chkMonday;
        protected CheckBox chkTuesday;
        protected CheckBox chkWednesday;
        protected CheckBox chkThursday;
        protected CheckBox chkFriday;
        protected CheckBox chkSaturday;

        protected TextBox txtSundayMin;
        protected TextBox txtSundayMax;
        protected TextBox txtMondayMin;
        protected TextBox txtMondayMax;
        protected TextBox txtTuesdayMin;
        protected TextBox txtTuesdayMax;
        protected TextBox txtWednesdayMin;
        protected TextBox txtWednesdayMax;
        protected TextBox txtThursdayMin;
        protected TextBox txtThursdayMax;
        protected TextBox txtFridayMin;
        protected TextBox txtFridayMax;
        protected TextBox txtSaturdayMin;
        protected TextBox txtSaturdayMax;

        protected GridView GridView1;

        protected DropDownList ddlFieldLists;
        protected DropDownList ddlNonWork;

        protected DropDownList ddlTimesheetHours;

        protected string lstData;
        protected string inputData;

        protected Panel pnlActivation;
        protected Panel pnlTs;

        protected CheckBox chkDisableApprovals;

        protected CheckBox chkCurrentData;

        protected void Page_Load(object sender, EventArgs e)
        {

            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.Timesheets);
            if (activation != 0)
            {
                pnlActivation.Visible = true;
                pnlTs.Visible = false;
            }


            using (SPWeb web = SPContext.Current.Web)
            {

                dtSpStart.DatePickerFrameUrl = web.Url + "/_layouts/iframe.aspx";
                dtSpEnd.DatePickerFrameUrl = web.Url + "/_layouts/iframe.aspx";

                try
                {
                    if (!SPContext.Current.Web.UserIsSiteAdmin)
                        Response.Redirect(SPContext.Current.Web.Url + "/_layouts/accessdenied.aspx");

                    siteUrl = SPContext.Current.Web.Url;

                    if (!IsPostBack)
                    {
                        //using (SPWeb web = SPContext.Current.Web)
                        {

                            if (!web.IsRootWeb)
                            {
                                pnlTL.Visible = true;
                                hlAdmin.NavigateUrl = SPContext.Current.Site.Url + "/_layouts/epmlive/timesheetadmin.aspx";
                                pnlMain.Visible = false;
                            }
                            else
                            {

                                TimesheetSettings settings = new TimesheetSettings(Web);

                                SPList oMyWork = web.Lists.TryGetList("My Work");

                                string sFields = "";

                                if(oMyWork != null)
                                {
                                    SortedList sl = new SortedList();

                                    foreach(SPField field in oMyWork.Fields)
                                    {
                                        if(field.Reorderable && field.InternalName != "Title")
                                        {
                                            sl.Add(field.Title, field.InternalName);
                                        }
                                    }

                                    foreach(DictionaryEntry de in sl)
                                    {
                                        if(settings.TimesheetFields.Contains(de.Value.ToString()))
                                        {
                                            sFields += "," + de.Value.ToString();
                                            ListItem li = new ListItem(de.Key.ToString(), de.Value.ToString());
                                            ddlTSFieldsS.Items.Add(li);
                                        }
                                        else
                                        {
                                            ListItem li = new ListItem(de.Key.ToString(), de.Value.ToString());
                                            ddlTSFieldsA.Items.Add(li);
                                        }
                                    }
                                }

                                sFields = sFields.Trim(',');

                                hdnTSFields.Value = sFields;

                                chkAllowStopWatch.Checked = settings.AllowStopWatch;













                                //using (SPSite site = SPContext.Current.Site)
                                SPSite site = SPContext.Current.Site;
                                {
                                    //using (SPWeb rweb = site.RootWeb)
                                    SPWeb rweb = site.RootWeb;
                                    {
                                        try
                                        {
                                            chkAllowUnassigned.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSAllowUnassigned"));
                                        }
                                        catch { }
                                        try
                                        {
                                            chkAllowNotes.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSAllowNotes"));
                                        }
                                        catch { }

                                        ddlFlagField.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSFlag");
                                        txtLists.Text = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSLists");

                                        string dayDef = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveDaySettings");

                                        if (dayDef != "")
                                        {
                                            string[] daySettings = dayDef.Split('|');

                                            chkSunday.Checked = bool.Parse(daySettings[0]);
                                            txtSundayMin.Text = daySettings[1];
                                            txtSundayMax.Text = daySettings[2];

                                            chkMonday.Checked = bool.Parse(daySettings[3]);
                                            txtMondayMin.Text = daySettings[4];
                                            txtMondayMax.Text = daySettings[5];

                                            chkTuesday.Checked = bool.Parse(daySettings[6]);
                                            txtTuesdayMin.Text = daySettings[7];
                                            txtTuesdayMax.Text = daySettings[8];

                                            chkWednesday.Checked = bool.Parse(daySettings[9]);
                                            txtWednesdayMin.Text = daySettings[10];
                                            txtWednesdayMax.Text = daySettings[11];

                                            chkThursday.Checked = bool.Parse(daySettings[12]);
                                            txtThursdayMin.Text = daySettings[13];
                                            txtThursdayMax.Text = daySettings[14];

                                            chkFriday.Checked = bool.Parse(daySettings[15]);
                                            txtFridayMin.Text = daySettings[16];
                                            txtFridayMax.Text = daySettings[17];

                                            chkSaturday.Checked = bool.Parse(daySettings[18]);
                                            txtSaturdayMin.Text = daySettings[19];
                                            txtSaturdayMax.Text = daySettings[20];
                                        }
                                        chkCurrentData.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSUseCurrent"));
                                    }
                                }
                                SqlConnection cn = null;
                                SPSecurity.RunWithElevatedPrivileges(delegate()
                                {
                                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                                    cn.Open();
                                });

                                SqlCommand cmd = new SqlCommand("select top 1 period_end,period_id from tsperiod where site_id = @siteid order by period_id desc", cn);
                                cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                SqlDataReader dr = cmd.ExecuteReader();
                                if (dr.Read())
                                {
                                    lastPeriod = (dr.GetInt32(1) + 1).ToString();
                                    DateTime dtEnd = dr.GetDateTime(0);
                                    nextStart = dtEnd.AddDays(1).ToShortDateString();
                                    int stWeek = Microsoft.VisualBasic.DateAndTime.DatePart(Microsoft.VisualBasic.DateInterval.WeekOfYear, dtEnd.AddDays(1), Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.System);
                                    int enWeek = Microsoft.VisualBasic.DateAndTime.DatePart(Microsoft.VisualBasic.DateInterval.WeekOfYear, dtEnd.AddDays(7), Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.System);
                                    if (stWeek != enWeek && !(enWeek == 1 && stWeek == 53))
                                    {
                                        nextStartEnd = dtEnd.AddDays(6 - (int)dtEnd.DayOfWeek).ToShortDateString();
                                    }
                                    else if (dtEnd.AddDays(1).Month != dtEnd.AddDays(7).Month)
                                    {
                                        dtEnd = dtEnd.AddDays(7);
                                        dtEnd = dtEnd.AddDays(-1 * dtEnd.Day);
                                        nextStartEnd = dtEnd.ToShortDateString();
                                    }
                                    else
                                    {
                                        nextStartEnd = dtEnd.AddDays(7).ToShortDateString();
                                    }
                                    dtSpStart.SelectedDate = DateTime.Parse(nextStart);
                                    dtSpStart.DatePickerFrameUrl = web.Url + "/_layouts/iframe.aspx";
                                    dtSpEnd.SelectedDate = DateTime.Parse(nextStartEnd);
                                    dtSpEnd.DatePickerFrameUrl = web.Url + "/_layouts/iframe.aspx";

                                }
                                dr.Close();

                                loadTypes(cn);

                                ddlNonWork.Items.Add(new ListItem("-- Select List --", ""));

                                foreach (SPList list in web.Lists)
                                {
                                    if (!list.Hidden)
                                    {
                                        ddlNonWork.Items.Add(new ListItem(list.Title, list.Title));
                                    }
                                }

                                ddlNonWork.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTSNonWork");
                                ddlTimesheetHours.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTSTimesheetHours");
                                try
                                {
                                    chkDisableApprovals.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTSDisableApprovals"));
                                }
                                catch { }
                                try
                                {
                                    chkShowLiveHours.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTSLiveHours"));
                                }
                                catch { }
                                /////////

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }
                ddlFieldLists.Items.Clear();
                //ddlFieldLists.Items.Add(new ListItem("Resources", "Resources"));
                string[] lists = txtLists.Text.Replace("\r\n", "\n").Split('\n');

                inputData = "";
                foreach (string list in lists)
                {
                    if (list != "Project Center")
                        addListFieldData(web, web, list);
                }



                string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);

                if (resUrl != "")
                {
                    try
                    {
                        SPWeb resWeb;
                        if (resUrl.ToLower() != web.Url.ToLower())
                        {
                            using (SPSite tempSite = new SPSite(resUrl))
                            {
                                resWeb = tempSite.OpenWeb();
                                if (resWeb.Url.ToLower() != resUrl.ToLower())
                                {
                                    resWeb = null;
                                }
                            }
                        }
                        else
                            resWeb = web;
                        if (resWeb != null)
                        {
                            addListFieldData(resWeb, web, "Resources");
                            if (resWeb.ID != SPContext.Current.Web.ID)
                                resWeb.Close();
                        }

                    }
                    catch { }
                }
                addListFieldData(web, web, "Project Center");


            }
            ddlFieldLists.Attributes.Add("onchange", "switchList();");


        }

        private void addListFieldData(SPWeb web, SPWeb configweb, string list)
        {
            SPList splist = null;
            try
            {
                splist = web.Lists[list];
            }
            catch { }
            if (splist != null)
            {
                ddlFieldLists.Items.Add(list);
                string fields = "";

                SortedList<string, string> sl = new SortedList<string, string>();
                foreach (SPField f in splist.Fields)
                {
                    if (f.Type != SPFieldType.Computed && !f.Hidden && f.InternalName != "Title" && f.InternalName != "Project" && f.Reorderable)
                    {
                        sl.Add(f.Title, f.InternalName);

                    }
                }

                foreach (string f in sl.Keys)
                {
                    fields += "," + sl[f] + "|" + f;
                }

                if (fields.Length > 0)
                    fields = fields.Substring(1);
                lstData += "<input type='hidden' name='lst" + list.Replace(" ", "_") + "' id='lst" + list.Replace(" ", "_") + "' value='" + HttpUtility.HtmlEncode(fields) + "'>\r\n";
                string sFields = "";
                if (Page.IsPostBack)
                    sFields = Request["input" + list.Replace(" ", "_")];
                else
                    sFields = EPMLiveCore.CoreFunctions.getConfigSetting(configweb, "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(splist.DefaultView.Url));
                inputData += "<input type='hidden' name='input" + list.Replace(" ", "_") + "' id='input" + list.Replace(" ", "_") + "' value='" + sFields + "'>\r\n";
            }
        }

        private void loadTypes(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("select * from vwTSTypes where site_uid = @siteid", cn);
            cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

            cn.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                SqlConnection cn = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("delete from TSTYPE where site_uid = @siteid and tstype_id=@tstype_id", cn);
                    cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                    cmd.Parameters.AddWithValue("@tstype_id", e.CommandArgument);
                    cmd.ExecuteNonQuery();

                    loadTypes(cn);

                    cn.Close();
                });

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "TypeCount").ToString() == "0")
                {
                    LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                    l.Attributes.Add("onclick", "javascript:return " +
                        "confirm('Are you sure you want to delete " +
                        DataBinder.Eval(e.Row.DataItem, "tstype_name") + "?')");

                    l = (LinkButton)e.Row.FindControl("LinkButton2");
                    l.Attributes.Add("onclick", "javascript:editType('" + DataBinder.Eval(e.Row.DataItem, "tstype_id") + "','" + DataBinder.Eval(e.Row.DataItem, "tstype_name") + "');return false;");
                }
                else
                {
                    LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                    l.Visible = false;

                    l = (LinkButton)e.Row.FindControl("LinkButton2");
                    l.Visible = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                //using (SPSite site = SPContext.Current.Site)
                SPSite site = SPContext.Current.Site;
                {
                    //using (SPWeb web = site.RootWeb)
                    SPWeb web = site.RootWeb;
                    {
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSAllowUnassigned", chkAllowUnassigned.Checked.ToString());
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSAllowNotes", chkAllowNotes.Checked.ToString());
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSFlag", ddlFlagField.SelectedValue);
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSLists", txtLists.Text.Trim());
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSNonWork", ddlNonWork.SelectedValue);
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSTimesheetHours", ddlTimesheetHours.SelectedValue);
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSDisableApprovals", chkDisableApprovals.Checked.ToString());
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSUseCurrent", chkCurrentData.Checked.ToString());
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSLiveHours", chkShowLiveHours.Checked.ToString());
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSMyFields", hdnTSFields.Value);
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSAllowStopWatch", chkAllowStopWatch.Checked.ToString());

                        string daySettings = "";
                        daySettings += chkSunday.Checked.ToString() + "|" + txtSundayMin.Text + "|" + txtSundayMax.Text + "|";
                        daySettings += chkMonday.Checked.ToString() + "|" + txtMondayMin.Text + "|" + txtMondayMax.Text + "|";
                        daySettings += chkTuesday.Checked.ToString() + "|" + txtTuesdayMin.Text + "|" + txtTuesdayMax.Text + "|";
                        daySettings += chkWednesday.Checked.ToString() + "|" + txtWednesdayMin.Text + "|" + txtWednesdayMax.Text + "|";
                        daySettings += chkThursday.Checked.ToString() + "|" + txtThursdayMin.Text + "|" + txtThursdayMax.Text + "|";
                        daySettings += chkFriday.Checked.ToString() + "|" + txtFridayMin.Text + "|" + txtFridayMax.Text + "|";
                        daySettings += chkSaturday.Checked.ToString() + "|" + txtSaturdayMin.Text + "|" + txtSaturdayMax.Text;

                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveDaySettings", daySettings);

                        string[] lists = txtLists.Text.Replace("\r\n", "\n").Split('\n');

                        foreach (string list in lists)
                        {
                            SPList splist = null;
                            try
                            {
                                splist = web.Lists[list];
                            }
                            catch { }
                            if (splist != null)
                            {
                                EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(splist.DefaultView.Url), Request["input" + list.Replace(" ", "_")]);
                            }
                        }
                        {
                            string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);

                            if (resUrl != "")
                            {
                                try
                                {
                                    SPWeb resWeb;
                                    if (resUrl.ToLower() != web.Url.ToLower())
                                    {
                                        using (SPSite tempSite = new SPSite(resUrl))
                                        {
                                            resWeb = tempSite.OpenWeb();
                                            if (resWeb.Url.ToLower() != resUrl.ToLower())
                                            {
                                                resWeb = null;
                                            }
                                        }
                                    }
                                    else
                                        resWeb = web;
                                    if (resWeb != null)
                                    {
                                        SPList splist = null;
                                        try
                                        {
                                            splist = resWeb.Lists["Resources"];
                                        }
                                        catch { }
                                        if (splist != null)
                                        {
                                            EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(splist.DefaultView.Url), Request["inputResources"]);
                                        }
                                        if (resWeb.ID != SPContext.Current.Web.ID)
                                            resWeb.Close();
                                    }
                                }
                                catch { }
                            }
                        }
                        {
                            SPList splist = null;
                            try
                            {
                                splist = web.Lists["Project Center"];
                            }
                            catch { }
                            if (splist != null)
                            {
                                EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(splist.DefaultView.Url), Request["inputProject_Center"]);
                            }
                        }
                    }
                }
                if(!String.IsNullOrEmpty(Request["Source"]))
                {
                    Response.Redirect(Request["Source"]);
                }
                else
                {
                    Microsoft.SharePoint.Utilities.SPUtility.Redirect("settings.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void lnkRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}

