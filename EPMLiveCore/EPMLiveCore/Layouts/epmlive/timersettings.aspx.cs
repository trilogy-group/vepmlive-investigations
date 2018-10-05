using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint.Administration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections;

namespace EPMLiveCore
{
    public partial class timersettings : LayoutsPageBase
    {
        public string strTitle;
        public string strTemplate;
        public static Hashtable desc;
        protected Panel pnlAdmin;
        protected ListBox lstNotificationUsers;
        protected ListBox lstSiteUsers;
        protected CheckBox chkTask;
        protected CheckBox chkAdmin;
        protected TextBox Lists;
        protected DropDownList FixTimes;
        protected Panel pnlSaveResults;
        protected Label lblPropertyEPMLiveFixLists;
        protected TextBox txtPropertyEPMLiveFixListsValue;
        protected Label lblPropertyEPMLiveFixTime;
        protected Label lblPropertyEPMLiveFixTimeValue;
        protected Panel pnlTL;
        protected Panel pnlMain;
        protected HyperLink hlAdmin;
        protected Label lblLastRun;

        protected Label lblLastResRun;
        protected Label lblLastResResult;

        protected Label lblNotEnabled;
        protected TextBox txtResPlannerLists;
        protected Label lblMessages;
        protected Label lblResLog;

        protected Button btnRunNow;

        protected string disabled;

        protected string siteUrl;
        protected string siteid;

        SqlConnection cn;

        private bool _disposed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            try
            {
                //    try
                //    {
                //        using (SPSite site = SPContext.Current.Site)
                //        {
                //            siteUrl = site.Url;
                //            siteid = site.ID.ToString();
                //            SPSecurity.RunWithElevatedPrivileges(delegate()
                //            {
                //                SPSite realsite = new SPSite(site.ID);
                //                bool found = false;
                //                foreach (SPJobDefinition job in realsite.WebApplication.JobDefinitions)
                //                {
                //                    if (job.Name == "EPM Live Timer Service" && !job.IsDisabled)
                //                        found = true;
                //                }
                //                if (!found)
                //                    lblNotEnabled.Visible = true;
                //                else
                //                    lblNotEnabled.Visible = false;
                //                realsite.Close();
                //            });
                //        }
                //    }
                //    catch { }

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
                            hlAdmin.NavigateUrl = web.Site.Url + "/_layouts/epmlive/timersettings.aspx";
                            pnlMain.Visible = false;
                            return;
                        }
                        else
                        {
                            Lists.Text = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveFixLists");



                            //lblLastRun.Text = EPMLiveCore.CoreFunctions.getConfigSetting(web, "epmlivetimerlastrun");
                            txtResPlannerLists.Text = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResPlannerLists");
                            //lblLastResRun.Text = CoreFunctions.getConfigSetting(web, "epmlivetimerlastresrun");
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

        //void bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    string[] sParam = (string[])e.Argument;

        //    using(SPSite site = new SPSite(new Guid(sParam[1])))
        //    {
        //        TimerFix tf = new TimerFix();
        //        tf.processSite(site, sParam[0]);

        //    }
        //}

        protected void loadData(SPWeb web)
        {
            cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });

            var processing = false;

            using (var sqlCommand = new SqlCommand(
                "select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=2",
                cn))
            {
                sqlCommand.Parameters.AddWithValue("@siteguid", web.Site.ID);

                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        FixTimes.SelectedValue = dataReader.GetInt32(1).ToString();

                        if (!dataReader.IsDBNull(3))
                        {
                            if (dataReader.GetInt32(3) == 0)
                            {
                                processing = true;
                                lblMessages.Text = "Queued";
                                lblLastResResult.Text = "Queued";
                                btnRunNow.Enabled = false;
                            }
                            else if (dataReader.GetInt32(3) == 1)
                            {
                                processing = true;
                                lblMessages.Text = "Processing (" + dataReader.GetInt32(2).ToString("##0") + "%)";
                                lblLastResResult.Text = "Processing (" + dataReader.GetInt32(2).ToString("##0") + "%)";
                                btnRunNow.Enabled = false;
                            }
                            else if (!dataReader.IsDBNull(5))
                            {
                                lblMessages.Text = dataReader.GetString(5);
                            }
                            else
                            {
                                lblMessages.Text = "No Results";
                            }
                        }

                        if (!dataReader.IsDBNull(4))
                        {
                            lblLastRun.Text = dataReader.GetDateTime(4).ToString();
                        }
                    }
                }
            }

            using (var sqlCommand = new SqlCommand(
                "select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=1",
                cn))
            {
                sqlCommand.Parameters.AddWithValue("@siteguid", web.Site.ID);

                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    if (!processing)
                    {
                        if (dataReader.Read())
                        {
                            if (!dataReader.IsDBNull(3))
                            {
                                if (dataReader.GetInt32(3) == 0)
                                {
                                    processing = true;
                                    lblLastResResult.Text = "Queued";
                                    btnRunNow.Enabled = false;
                                }
                                else if (dataReader.GetInt32(3) == 1)
                                {
                                    processing = true;
                                    lblLastResResult.Text = "Processing (" + dataReader.GetInt32(2).ToString("##0") + "%)";
                                    btnRunNow.Enabled = false;
                                }
                                else if (!dataReader.IsDBNull(5))
                                {
                                    lblLastResResult.Text = dataReader.GetString(5);
                                }
                                else
                                {
                                    lblLastResResult.Text = "No Results";
                                }
                            }

                            if (!dataReader.IsDBNull(4))
                            {
                                lblLastResRun.Text = dataReader.GetDateTime(4).ToString();
                            }
                        }
                    }
                }
            }

            cn.Close();

            if (Request["btnRun"] == "Run Timer Now" && !processing)
            {
                saveSettings(web);
                //Page.RegisterStartupScript("runtimer", "<script type=\"text/javascript\">_spBodyOnLoadFunctionNames.push(\"runTimer\");</script>");
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
                        //url = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;
                        saveSettings(web);

                        using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id)))
                        {
                            SPSecurity.RunWithElevatedPrivileges(() => sqlConnection.Open());

                            var jobGuid = Guid.Empty;

                            using (var sqlCommand =
                                new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=1", sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@siteguid", site.ID.ToString());

                                using (var dataReader = sqlCommand.ExecuteReader())
                                {
                                    if (dataReader.Read())
                                    {
                                        jobGuid = dataReader.GetGuid(0);
                                    }
                                }
                            }

                            if (jobGuid != Guid.Empty)
                            {
                                CoreFunctions.enqueue(jobGuid, 1);
                            }

                            jobGuid = Guid.Empty;

                            using (var cmd =
                                new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=2", sqlConnection))
                            {
                                cmd.Parameters.AddWithValue("@siteguid", site.ID.ToString());

                                using (var dataReader = cmd.ExecuteReader())
                                {
                                    if (dataReader.Read())
                                    {
                                        jobGuid = dataReader.GetGuid(0);
                                    }
                                }
                            }

                            if (jobGuid != Guid.Empty)
                            {
                                CoreFunctions.enqueue(jobGuid, 0);
                            }
                        }
                    }
                }
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/timersettings.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "";
                SPWeb currWeb = SPContext.Current.Web;
                {
                    url = currWeb.ServerRelativeUrl;

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite site = new SPSite(currWeb.Site.ID))
                        {
                            using (SPWeb web = site.OpenWeb(currWeb.ID))
                            {
                                saveSettings(web);
                            }
                        }
                    });
                }

                if (!String.IsNullOrEmpty(Request["Source"]))
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

        private void saveSettings(SPWeb currWeb)
        {
            currWeb.AllowUnsafeUpdates = true;

            string sTime = FixTimes.SelectedValue.ToString();
            string sLists = Lists.Text;
            //EPMLiveCore.CoreFunctions.setConfigSetting(currWeb, "EPMLiveFixTime", sTime);
            EPMLiveCore.CoreFunctions.setConfigSetting(currWeb, "EPMLiveFixLists", sLists);
            EPMLiveCore.CoreFunctions.setConfigSetting(currWeb, "EPMLiveResPlannerLists", txtResPlannerLists.Text);


            SPWeb web = SPContext.Current.Web;
            {
                cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn.Open();
                });

                Guid timerjobguid;
                //=======================Timer Job==========================
                using (var sqlCommand = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=2", cn))
                {
                    sqlCommand.Parameters.AddWithValue("@siteguid", currWeb.Site.ID.ToString());

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            timerjobguid = dataReader.GetGuid(0);

                            using (var sqlUpdateCommand = new SqlCommand(
                                "UPDATE TIMERJOBS set runtime = @runtime where siteguid=@siteguid and jobtype=2",
                                cn))
                            {
                                sqlUpdateCommand.Parameters.AddWithValue("@siteguid", currWeb.Site.ID.ToString());
                                sqlUpdateCommand.Parameters.AddWithValue("@runtime", FixTimes.SelectedValue);
                                sqlUpdateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            timerjobguid = Guid.NewGuid();

                            using (var sqlInsertCommand = new SqlCommand(
                                "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, runtime, scheduletype, webguid) VALUES (@timerjobuid, @siteguid, 2, 'Resource Pool Rate Update', @runtime, 2, @webguid)",
                                cn))
                            {
                                sqlInsertCommand.Parameters.AddWithValue("@siteguid", currWeb.Site.ID.ToString());
                                sqlInsertCommand.Parameters.AddWithValue("@timerjobuid", timerjobguid);
                                sqlInsertCommand.Parameters.AddWithValue("@webguid", currWeb.ID.ToString());
                                sqlInsertCommand.Parameters.AddWithValue("@runtime", FixTimes.SelectedValue);
                                sqlInsertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                cn.Close();
            }
        }

        public class UserObject : IComparable
        {
            public string Login;
            public string Name;

            public UserObject(string l, string n)
            {
                this.Login = l;
                this.Name = n;
            }

            public int CompareTo(object obj)
            {
                UserObject Compare = (UserObject)obj;
                int result = this.Name.CompareTo(Compare.Name);
                if (result == 0)
                    result = this.Name.CompareTo(Compare.Name);
                return result;
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                cn?.Dispose();
                base.Dispose();
            }

            _disposed = true;
        }
    }
}
