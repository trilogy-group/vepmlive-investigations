using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    public partial class adminqueue : System.Web.UI.Page
    {
        protected SPGridView GvItems;
        protected Label lblLength;
        protected Label lblWait;
        protected Label lblJobTime;
        protected Label lblTotalJobs;
        protected Label lblMaxQueue;
        protected Label lblMaxJob;

        protected TextBox txtMainThreads;
        protected TextBox txtInterval;
        protected TextBox txtSecurityThreads;
        protected TextBox txtRollupQueueThreads;
        protected TextBox txtHighPriorityQueueThreads;
        protected TextBox txtTimesheetThreads;

        protected WebApplicationSelector WebApplicationSelector1;

        protected void WebApplicationSelector1_ContextChange(object sender, EventArgs e)
        {
            GetInfo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            MenuTemplate propertyNameListMenu = new MenuTemplate();
            propertyNameListMenu.ID = "PropertyNameListMenu";
            MenuItemTemplate testMenu = new MenuItemTemplate("View More Information", "/_layouts/images/16doc.gif");
            testMenu.ClientOnClickNavigateUrl = "viewqueue.aspx?timerjobuid=%NAME%&siteuid=%SITE%";

            propertyNameListMenu.Controls.Add(testMenu);



            this.Controls.Add(propertyNameListMenu);

            if(!IsPostBack)
            {
                txtInterval.Text = CoreFunctions.getFarmSetting("PollingInterval");
                txtMainThreads.Text = CoreFunctions.getFarmSetting("QueueThreads");
                txtSecurityThreads.Text = CoreFunctions.getFarmSetting("SecQueueThreads");
                txtRollupQueueThreads.Text = CoreFunctions.getFarmSetting("RollupQueueThreads");
                txtHighPriorityQueueThreads.Text = CoreFunctions.getFarmSetting("HighQueueThreads");
                txtTimesheetThreads.Text = CoreFunctions.getFarmSetting("TSQueueThreads");
            }
        }

        private void GetInfo()
        {
            try
            {
                var web = SPContext.Current.Web;
                {
                    using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(WebApplicationSelector1.CurrentItem.Id)))
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate { sqlConnection.Open(); });

                        using (var selectCountCommand = new SqlCommand("select count(*) from queue where status = 0", sqlConnection))
                        {
                            using (var dataReader = selectCountCommand.ExecuteReader())
                            {
                                lblLength.Text = "0";
                                if (dataReader.Read())
                                {
                                    lblLength.Text = dataReader.GetInt32(0).ToString();
                                }
                            }
                        }

                        using (var selectQueueStatsCommand = new SqlCommand("select * from vwQueueStats", sqlConnection))
                        {
                            using (var dataReader = selectQueueStatsCommand.ExecuteReader())
                            {
                                lblWait.Text = string.Empty;
                                lblJobTime.Text = string.Empty;
                                lblMaxQueue.Text = string.Empty;
                                lblMaxJob.Text = string.Empty;
                                lblTotalJobs.Text = string.Empty;

                                if (dataReader.Read())
                                {
                                    if (!dataReader.IsDBNull(0))
                                    {
                                        lblJobTime.Text = showtime(dataReader.GetInt32(0));
                                    }
                                    if (!dataReader.IsDBNull(1))
                                    {
                                        lblWait.Text = showtime(dataReader.GetInt32(1));
                                    }
                                    if (!dataReader.IsDBNull(2))
                                    {
                                        lblMaxJob.Text = showtime(dataReader.GetInt32(2));
                                    }
                                    if (!dataReader.IsDBNull(3))
                                    {
                                        lblMaxQueue.Text = showtime(dataReader.GetInt32(3));
                                    }
                                    if (!dataReader.IsDBNull(4))
                                    {
                                        lblTotalJobs.Text = dataReader.GetInt32(4).ToString();
                                    }
                                }
                            }
                        }

                        using (var selectQueueStatusOrderedCommand = new SqlCommand(
                            "select * from vwQueueItems order by status, dtfinished desc",
                            sqlConnection))
                        {
                            using (var dataAdapter = new SqlDataAdapter(selectQueueStatusOrderedCommand))
                            {
                                using (var dataSet = new DataSet())
                                {
                                    dataAdapter.Fill(dataSet);
                                    GvItems.DataSource = dataSet.Tables[0];
                                }
                            }
                        }
                        GvItems.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Exception suppressed: {0}", ex); 
            }
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            CoreFunctions.setFarmSetting("PollingInterval", txtInterval.Text);
            CoreFunctions.setFarmSetting("QueueThreads", txtMainThreads.Text);
            CoreFunctions.setFarmSetting("SecQueueThreads", txtSecurityThreads.Text);
            CoreFunctions.setFarmSetting("RollupQueueThreads", txtRollupQueueThreads.Text);
            CoreFunctions.setFarmSetting("HighQueueThreads", txtHighPriorityQueueThreads.Text);
            CoreFunctions.setFarmSetting("TSQueueThreads", txtTimesheetThreads.Text);
        }

        protected string showtime(int seconds)
        {
            string sTime = "";

            DateTime dt = DateTime.Now;
            DateTime dtend = dt.AddSeconds(seconds);

            TimeSpan ts = dtend - dt;

            if (ts.Days > 0)
                sTime += ts.Days + " Days ";
            if (ts.Hours > 0)
                sTime += ts.Hours + " Hours ";
            if (ts.Minutes > 0)
                sTime += ts.Minutes + " Minutes ";
            if (ts.Seconds > 0)
                sTime += ts.Seconds + " Seconds ";

            return sTime;
        }

        protected void GvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch(((DataRowView)e.Row.DataItem)["status"].ToString())
                {
                    case "0":
                        ((Label)e.Row.Cells[1].Controls[0]).Text = "Queued";
                        break;
                    case "1":
                        string pct = "";
                        try
                        {
                            pct = int.Parse((((DataRowView)e.Row.DataItem)["percentComplete"]).ToString()).ToString("##0");
                        }
                        catch { }
                        ((Label)e.Row.Cells[1].Controls[0]).Text = "Processing (" + pct + "%)";
                        break;
                    case "2":
                        ((Label)e.Row.Cells[1].Controls[0]).Text = ((DataRowView)e.Row.DataItem)["result"].ToString();
                        break;
                };

                

                //CheckBox cb = (CheckBox)e.Row.Cells[0].Text =
                //if (((DataRowView)e.Row.DataItem)["selected"].ToString().ToLower() == "true")
                //    cb.Checked = true;
            }
        }

    }
}