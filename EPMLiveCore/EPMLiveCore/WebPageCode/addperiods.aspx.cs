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
using EPMLiveCore.Infrastructure.Logging;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    public partial class addperiods : System.Web.UI.Page
    {

        protected DropDownList ddlPeriodType;
        protected Microsoft.SharePoint.WebControls.DateTimeControl calStart;
        static protected string display = "none";
        static protected string periodType = "Months";
        protected Label lblError;
        protected TextBox txtNumber;
        protected TextBox txtStartWeek;
        protected Button btnSubmit;
        protected GridView GridView2;
        protected Panel pnlData;
        protected Panel pnlGrid;

        protected void Page_Load(object sender, EventArgs e)
        {
            calStart.DatePickerFrameUrl = SPContext.Current.Web.Url + "/_layouts/iframe.aspx";
        }

        protected void ddlPeriodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPeriodType.SelectedItem.Text == "Weeks")
            {

                display = "";
            }
            else
            {
                display = "none";
            }
            periodType = ddlPeriodType.SelectedItem.Text;
        }

        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            web.AllowUnsafeUpdates = true;
            SPList list = web.Lists["EPMLivePeriods"];

            ArrayList arrPeriods = new ArrayList();
            foreach (SPListItem li in list.Items)
            {
                arrPeriods.Add(li.Title);
            }

            ArrayList arrNewPeriods = new ArrayList();

            foreach (GridViewRow gvr in GridView2.Rows)
            {
                TextBox txt = (TextBox)gvr.FindControl("txtName");
                string name = txt.Text;

                arrNewPeriods.Add(name);

                if (!arrPeriods.Contains(name))
                {
                    txt = (TextBox)gvr.FindControl("txtStart");
                    string start = txt.Text;

                    txt = (TextBox)gvr.FindControl("txtEnd");
                    string end = txt.Text;

                    txt = (TextBox)gvr.FindControl("txtCapacity");
                    string capacity = txt.Text;

                    SPListItem li = list.Items.Add();
                    li["Title"] = name;
                    li["StartDate"] = start;
                    li["EndDate"] = end;
                    li["Capacity"] = capacity;
                    li.Update();
                }
            }

            string url = web.ServerRelativeUrl;

            string[] periods = new string[arrNewPeriods.Count];
            int counter = 0;
            foreach (string p in arrNewPeriods)
            {
                periods[counter++] = p;
            }

            addWebPeriods(web, periods, web.Url);

            //web.Close();

            Page.RegisterStartupScript("repost", "<script language=\"javascript\">opener.location.href='" + url + "/_layouts/epmlive/tpsetup.aspx';window.close();</script>");
        }

        private void addWebPeriods(SPWeb web, string[] periods, string url)
        {
            try
            {
                web.AllowUnsafeUpdates = true;

                if (CoreFunctions.getConfigSetting(web, "EPMLiveTimePhasedURL").ToLower() == url.ToLower())
                {
                    SPList list = web.Lists["EPMLiveTimePhased"];
                    foreach (string period in periods)
                    {
                        try
                        {
                            SPField f = list.Fields.GetFieldByInternalName(period.Replace(" ", "_x0020_"));
                        }
                        catch
                        {
                            list.Fields.Add(period, SPFieldType.Number, false);
                        }
                    }
                    //f.Delete();
                }
            }
            catch { }
            foreach (SPWeb w in web.Webs)
            {
                try
                {
                    addWebPeriods(w, periods, url);
                }
                catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Others, TraceSeverity.Medium, ex.ToString()); }
                finally { if (w != null) w.Close(); }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            int number = 0;
            int.TryParse(txtNumber.Text, out number);

            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("start");
            dt.Columns.Add("finish");
            dt.Columns.Add("capacity");

            if (ddlPeriodType.SelectedItem.Text == "Weeks")
            {
                if (number == 0)
                {
                    lblError.Text = "Please enter a value for 'Number of Weeks'";
                    lblError.Visible = true;
                    return;
                }
                int weekStart = 0;
                int.TryParse(txtStartWeek.Text, out weekStart);
                if (weekStart == 0)
                {
                    lblError.Text = "Please enter a value for 'Start Weeks On #'";
                    lblError.Visible = true;
                    return;
                }

                if (calStart.SelectedDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    lblError.Text = "You must select the first day of a week.";
                    lblError.Visible = true;
                    return;
                }

                for (int i = 0; i < number; i++)
                {
                    DateTime dtMonth = calStart.SelectedDate.AddDays(i * 7);

                    string name = "Week " + (i + weekStart).ToString();
                    string start = dtMonth.ToShortDateString();
                    string end = dtMonth.AddDays(6).ToShortDateString();
                    string capacity = "";

                    try
                    {
                        long weekcount = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.WeekOfYear, DateTime.Parse(start), DateTime.Parse(end), Microsoft.VisualBasic.FirstDayOfWeek.System, Microsoft.VisualBasic.FirstWeekOfYear.System);
                        long daycount = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, DateTime.Parse(start), DateTime.Parse(end), Microsoft.VisualBasic.FirstDayOfWeek.System, Microsoft.VisualBasic.FirstWeekOfYear.System);
                        weekcount = weekcount * 2;
                        long dur = daycount - weekcount;
                        //ASSIGN NEW DURATION
                        capacity = ((dur + 1) * 8).ToString();
                    }
                    catch { }

                    dt.Rows.Add(new string[] { name, start, end, capacity });
                }
            }
            else
            {
                if (number == 0)
                {
                    lblError.Text = "Please enter a value for 'Number of Months'";
                    lblError.Visible = true;
                    return;
                }

                if (calStart.SelectedDate.Day != 1)
                {
                    lblError.Text = "You must select the first day of a month.";
                    lblError.Visible = true;
                    return;
                }

                if (calStart.SelectedDate.Year == 0001)
                {
                    lblError.Text = "You must select a date.";
                    lblError.Visible = true;
                    return;
                }

                for (int i = 0; i < number; i++)
                {
                    DateTime dtMonth = calStart.SelectedDate.AddMonths(i);

                    string name = dtMonth.ToString("MMM yy");
                    string start = dtMonth.ToShortDateString();
                    string end = dtMonth.AddDays(DateTime.DaysInMonth(dtMonth.Year, dtMonth.Month) - 1).ToShortDateString();

                    string capacity = "";

                    try
                    {
                        long weekcount = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.WeekOfYear, DateTime.Parse(start), DateTime.Parse(end), Microsoft.VisualBasic.FirstDayOfWeek.System, Microsoft.VisualBasic.FirstWeekOfYear.System);
                        long daycount = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, DateTime.Parse(start), DateTime.Parse(end), Microsoft.VisualBasic.FirstDayOfWeek.System, Microsoft.VisualBasic.FirstWeekOfYear.System);
                        weekcount = weekcount * 2;
                        long dur = daycount - weekcount;
                        //ASSIGN NEW DURATION
                        capacity = ((dur + 1) * 8).ToString();
                    }
                    catch { }

                    dt.Rows.Add(new string[] { name, start, end, capacity });
                }
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
            pnlData.Visible = false;
            pnlGrid.Visible = true;
        }

    }
}