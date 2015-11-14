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

        protected TextBox txtThreads;
        protected TextBox txtInterval;
        protected TextBox txtSecurityThreads;
        protected TextBox txtRollupQueueThreads;
        protected TextBox txtHighPriorityQueueThreads;

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
                txtThreads.Text = CoreFunctions.getFarmSetting("QueueThreads");
                txtSecurityThreads.Text = CoreFunctions.getFarmSetting("SecQueueThreads");
                txtRollupQueueThreads.Text = CoreFunctions.getFarmSetting("RollupQueueThreads");
                txtHighPriorityQueueThreads.Text = CoreFunctions.getFarmSetting("HighQueueThreads");
            }
        }

        private void GetInfo()
        {
            try
            {
                SPWeb web = SPContext.Current.Web;
                {
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(WebApplicationSelector1.CurrentItem.Id));

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        cn.Open();
                    });


                    SqlCommand cmd = new SqlCommand("select count(*) from queue where status = 0", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    lblLength.Text = "0";
                    if(dr.Read())
                    {
                        lblLength.Text = dr.GetInt32(0).ToString();
                    }
                    dr.Close();


                    cmd = new SqlCommand("select * from vwQueueStats", cn);
                    dr = cmd.ExecuteReader();
                    lblWait.Text = "";
                    lblJobTime.Text = "";
                    lblMaxQueue.Text = "";
                    lblMaxJob.Text = "";
                    lblTotalJobs.Text = "";

                    if(dr.Read())
                    {
                        if(!dr.IsDBNull(0))
                            lblJobTime.Text = showtime(dr.GetInt32(0));//.ToString() + " seconds";
                        if(!dr.IsDBNull(1))
                            lblWait.Text = showtime(dr.GetInt32(1));
                        if(!dr.IsDBNull(2))
                            lblMaxJob.Text = showtime(dr.GetInt32(2));
                        if(!dr.IsDBNull(3))
                            lblMaxQueue.Text = showtime(dr.GetInt32(3));
                        if(!dr.IsDBNull(4))
                            lblTotalJobs.Text = dr.GetInt32(4).ToString();

                    }
                    dr.Close();

                    cmd = new SqlCommand("select * from vwQueueItems order by status, dtfinished desc", cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    GvItems.DataSource = ds.Tables[0];
                    GvItems.DataBind();

                    cn.Close();
                }
                
            }
            catch { }
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            CoreFunctions.setFarmSetting("PollingInterval", txtInterval.Text);
            CoreFunctions.setFarmSetting("QueueThreads", txtThreads.Text);
            CoreFunctions.setFarmSetting("SecQueueThreads", txtSecurityThreads.Text);
            CoreFunctions.setFarmSetting("RollupQueueThreads", txtRollupQueueThreads.Text);
            CoreFunctions.setFarmSetting("HighQueueThreads", txtHighPriorityQueueThreads.Text);
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