using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Data.SqlClient;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class ResourceListUpdater : LayoutsPageBase
    {
        SqlConnection cn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            try
            {
                SPWeb web = SPContext.Current.Web;
                if (!CoreFunctions.DoesCurrentUserHaveFullControl(web))
                {
                    Microsoft.SharePoint.Utilities.SPUtility.TransferToErrorPage("Access denied.");
                }

                {
                    if (!IsPostBack)
                    {

                        if (!web.IsRootWeb)
                        {
                            pnlTL.Visible = true;
                            hlAdmin.NavigateUrl = web.Site.Url + "/_layouts/epmlive/resourcelistupdater.aspx";
                            pnlMain.Visible = false;
                            return;
                        }
                        loadData(web);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void loadData(SPWeb web)
        {
            cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });

            SqlCommand cmd = new SqlCommand("select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=2", cn);
            cmd.Parameters.AddWithValue("@siteguid", web.Site.ID);
            SqlDataReader dr = cmd.ExecuteReader();

            bool processing = false;

            if (dr.Read())
            {

                FixTimes.SelectedValue = dr.GetInt32(1).ToString();
                if (!dr.IsDBNull(3))
                {
                    if (dr.GetInt32(3) == 0)
                    {
                        processing = true;
                        lblMessages.Text = "Queued";
                        lblLastResResult.Text = "Queued";
                        btnRunNow.Enabled = false;
                    }
                    else if (dr.GetInt32(3) == 1)
                    {
                        processing = true;
                        lblMessages.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
                        lblLastResResult.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
                        btnRunNow.Enabled = false;
                    }
                    else if (!dr.IsDBNull(5))
                    {
                        lblMessages.Text = dr.GetString(5);
                    }
                    else
                    {
                        lblMessages.Text = "No Results";
                    }
                }

                if (!dr.IsDBNull(4))
                    lblLastRun.Text = dr.GetDateTime(4).ToString();

                dr.Close();

                cmd = new SqlCommand("select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=1", cn);
                cmd.Parameters.AddWithValue("@siteguid", web.Site.ID);
                dr = cmd.ExecuteReader();

                if (!processing)
                {
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(3))
                        {
                            if (dr.GetInt32(3) == 0)
                            {
                                processing = true;
                                lblLastResResult.Text = "Queued";
                                btnRunNow.Enabled = false;
                            }
                            else if (dr.GetInt32(3) == 1)
                            {
                                processing = true;
                                lblLastResResult.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
                                btnRunNow.Enabled = false;
                            }
                            else if (!dr.IsDBNull(5))
                            {
                                lblLastResResult.Text = dr.GetString(5);
                            }
                            else
                            {
                                lblLastResResult.Text = "No Results";
                            }
                        }

                        if (!dr.IsDBNull(4))
                            lblLastResRun.Text = dr.GetDateTime(4).ToString();
                    }
                    dr.Close();
                }
            }

            cn.Close();

            if (Request["btnRun"] == "Run Timer Now" && !processing)
            {
                saveSettings(web);
            }
        }

        protected void btnRunNow_Click(object sender, EventArgs e)
        {
            try
            {
                //string url = "";
                SPSite site = SPContext.Current.Site;
                {
                    SPWeb web = SPContext.Current.Web;
                    {
                        saveSettings(web);

                        SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));

                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn.Open();
                        });

                        //=============================Res Plan================================
                        Guid jobguid = Guid.Empty;

                        SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=1", cn);
                        cmd.Parameters.AddWithValue("@siteguid", site.ID.ToString());
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jobguid = dr.GetGuid(0);
                        }
                        dr.Close();

                        if (jobguid != Guid.Empty)
                        {
                            CoreFunctions.enqueue(jobguid, 1);
                        }
                        //=============================Timer================================
                        jobguid = Guid.Empty;

                        cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=2", cn);
                        cmd.Parameters.AddWithValue("@siteguid", site.ID.ToString());
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            jobguid = dr.GetGuid(0);
                        }
                        dr.Close();

                        if (jobguid != Guid.Empty)
                        {
                            CoreFunctions.enqueue(jobguid, 0);
                        }
                    }
                }
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/resourcelistupdater.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        private void saveSettings(SPWeb currWeb)
        {
            currWeb.AllowUnsafeUpdates = true;

            string sTime = FixTimes.SelectedValue.ToString();
            SPWeb web = SPContext.Current.Web;
            {
                cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn.Open();
                });

                Guid timerjobguid;
                //=======================Timer Job==========================
                SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=2", cn);
                cmd.Parameters.AddWithValue("@siteguid", currWeb.Site.ID.ToString());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    timerjobguid = dr.GetGuid(0);
                    dr.Close();
                    cmd = new SqlCommand("UPDATE TIMERJOBS set runtime = @runtime where siteguid=@siteguid and jobtype=2", cn);
                    cmd.Parameters.AddWithValue("@siteguid", currWeb.Site.ID.ToString());
                    cmd.Parameters.AddWithValue("@runtime", FixTimes.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    timerjobguid = Guid.NewGuid();
                    dr.Close();
                    cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, runtime, scheduletype, webguid) VALUES (@timerjobuid, @siteguid, 2, 'Effective Rate', @runtime, 2, @webguid)", cn);
                    cmd.Parameters.AddWithValue("@siteguid", currWeb.Site.ID.ToString());
                    cmd.Parameters.AddWithValue("@timerjobuid", timerjobguid);
                    cmd.Parameters.AddWithValue("@webguid", currWeb.ID.ToString());
                    cmd.Parameters.AddWithValue("@runtime", FixTimes.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
        }

        //public class UserObject : IComparable
        //{
        //    public string Login;
        //    public string Name;

        //    public UserObject(string l, string n)
        //    {
        //        this.Login = l;
        //        this.Name = n;
        //    }

        //    public int CompareTo(object obj)
        //    {
        //        UserObject Compare = (UserObject)obj;
        //        int result = this.Name.CompareTo(Compare.Name);
        //        if (result == 0)
        //            result = this.Name.CompareTo(Compare.Name);
        //        return result;
        //    }
        //}
    }
}
