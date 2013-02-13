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
    public partial class adminviewqueue : System.Web.UI.Page
    {
        protected Label lblJobName;
        protected Label lblWeb;
        protected Label lblList;
        protected Label lblJobType;
        protected Label lblStatus;
        protected Label lblFinished;
        protected Label lblWait;
        protected Label lblJobLength;
        protected Label lblErrors;


        protected void Page_Load(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(new Guid(Request["siteuid"])))
                {
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));

                    cn.Open();
                    
                    SqlCommand cmd = new SqlCommand("select * from vwQUeueTimerLog where timerjobuid=@timerjobuid", cn);
                    cmd.Parameters.AddWithValue("@timerjobuid", Request["timerjobuid"]);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        lblJobName.Text = dr["jobname"].ToString();
                        lblWeb.Text = "";
                        lblList.Text = "";
                        try
                        {
                            using (SPWeb web = site.OpenWeb(new Guid(dr["webguid"].ToString())))
                            {
                                try
                                {
                                    lblWeb.Text = web.Title + " (" + web.Url + ")";
                                    if (dr["listguid"].ToString() != "")
                                    {
                                        SPList list = web.Lists[new Guid(dr["listguid"].ToString())];
                                        lblList.Text = list.Title;
                                    }
                                }
                                catch { }
                            }
                        }
                        catch { }
                        switch(dr["jobtype"].ToString())
                        {
                            case "1":
                                lblJobType.Text = "Res Link";
                                break;
                            case "2":
                                lblJobType.Text = "Today Fix/Res Link";
                                break;
                            case "3":
                                lblJobType.Text = "Notifications";
                                break;
                            case "4":
                                lblJobType.Text = "Enterprise List Synch";
                                break;
                            case "5":
                                lblJobType.Text = "Reporting Cleanup";
                                break;
                            case "6":
                                lblJobType.Text = "Reporting Refresh";
                                break;
                            case "7":
                                lblJobType.Text = "Reporting Snapshot";
                                break;
                            default :
                                lblJobType.Text = "Unknown";
                                break;
                        }
                        
                        switch(dr["status"].ToString())
                        {
                            case "0":
                                lblStatus.Text = "Queued";
                                break;
                            case "1":
                                string pct = "";
                                try
                                {
                                    pct = int.Parse(dr["percentComplete"].ToString()).ToString("##0");
                                }
                                catch { }
                                lblStatus.Text = "Processing (" + pct + "%)";
                                break;
                            case "2":
                                lblStatus.Text = dr["result"].ToString();
                                break;
                        }

                        lblFinished.Text = dr["dtfinished"].ToString();
                        lblJobLength.Text = "";
                        try
                        {
                            DateTime dtQueue = DateTime.Parse(dr["dtcreated"].ToString());
                            DateTime dtStart = DateTime.Parse(dr["dtstarted"].ToString());
                            DateTime dtFinish = DateTime.MinValue;
                            try
                            {
                                dtFinish = DateTime.Parse(dr["dtfinished"].ToString());
                            }
                            catch { }
                            TimeSpan wait = dtStart - dtQueue;

                            lblWait.Text = showtime(wait.TotalSeconds);

                            if(dtFinish != DateTime.MinValue)
                            {
                                TimeSpan ts2 = dtFinish - dtStart;
                                lblJobLength.Text = showtime(ts2.TotalSeconds);
                            }
                        }catch{}

                        

                        lblErrors.Text = dr["resulttext"].ToString();
                    }
                    dr.Close();

                    cn.Close();
                }
            });
        }
        protected string showtime(double seconds)
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

    }
}