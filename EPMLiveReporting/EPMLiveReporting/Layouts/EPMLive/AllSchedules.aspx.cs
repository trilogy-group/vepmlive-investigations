using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.ReportHelper;
using System.Data;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class AllSchedules : LayoutsPageBase
    {
        protected MenuItemTemplate MenuItemTemplate1;
        protected MenuItemTemplate MenuItemTemplateDelete;
        private EPMData _DAO;

        protected void Page_Init(object sender, EventArgs e)
        {
            _DAO = new EPMData(SPContext.Current.Web.Site.ID);
            LoadScheduleStatus();
        }

        protected void LoadScheduleStatus()
        {
            if (!IsPostBack)
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        using (
                            var cn =
                                new SqlConnection(
                                    CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id)))
                        {
                            cn.Open();

                            var cmd =
                                new SqlCommand(
                                    "select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and listguid is null and jobtype=5 and scheduletype = 2",
                                    cn);
                            cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID);
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                if (!dr.IsDBNull(1))
                                {
                                    DropDownListTimes.SelectedValue = dr.GetInt32(1).ToString();
                                }

                                if (!dr.IsDBNull(3))
                                {
                                    if (dr.GetInt32(3) == 0)
                                    {
                                        lblMessages.Text = "Queued";
                                    }
                                    else if (dr.GetInt32(3) == 1)
                                    {
                                        lblMessages.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
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
                            }
                            dr.Close();
                            cn.Close();
                        }
                    });
                }
                catch (Exception ex)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - Page_Load"))
                            EventLog.CreateEventSource("EPMLive Reporting - Page_Load", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting Page_Load");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(ex.Message + ex.StackTrace, EventLogEntryType.Error, 2040);
                    });
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                loadData(SPContext.Current.Web);
            }
        }

        protected void SaveSchedule(object sender, EventArgs e)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (
                        var cn =
                            new SqlConnection(CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id))
                        )
                    {
                        cn.Open();

                        var cmd =
                            new SqlCommand(
                                "select timerjobuid from timerjobs where siteguid=@siteguid and listguid is null and jobtype=5 and scheduletype = 2",
                                cn);
                        cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID.ToString());
                        SqlDataReader dr = cmd.ExecuteReader();

                        int numberOfJobs = 0;
                        using (var dt = new DataTable())
                        {
                            dt.Load(dr);
                            numberOfJobs = dt.Rows.Count;
                            dr.Close();
                        }

                        if (numberOfJobs > 1)
                        {
                            var deleteCmd =
                           new SqlCommand(
                               "delete from timerjobs where siteguid=@siteguid and listguid is null and jobtype=5 and scheduletype = 2",
                               cn);
                            deleteCmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID.ToString());
                            deleteCmd.ExecuteNonQuery();
                        }

                        if (numberOfJobs == 1)
                        {
                            cmd =
                                new SqlCommand(
                                    "UPDATE TIMERJOBS set runtime = @runtime where siteguid=@siteguid and listguid is null and jobtype=5 and scheduletype = 2",
                                    cn);
                            cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID.ToString());
                            cmd.Parameters.AddWithValue("@runtime", DropDownListTimes.SelectedValue);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd =
                                new SqlCommand(
                                    "INSERT INTO TIMERJOBS (siteguid, jobtype, jobname, scheduletype, webguid, runtime) VALUES (@siteguid, 5, 'Reporting Refresh All', 2, @webguid, @runtime)",
                                    cn);
                            cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID.ToString());
                            cmd.Parameters.AddWithValue("@webguid", SPContext.Current.Web.ID.ToString());
                            cmd.Parameters.AddWithValue("@runtime", DropDownListTimes.SelectedValue);
                            cmd.ExecuteNonQuery();
                        }

                        cn.Close();
                    }
                });
            }
            catch (Exception ex) { }
        }

        protected void RunRefreshNow(object sender, EventArgs e)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (
                        var cn =
                            new SqlConnection(CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id))
                        )
                    {
                        cn.Open();

                        Guid timerjobuid = Guid.Empty;
                        var cmd =
                            new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and jobtype=5",
                                cn);
                        cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID.ToString());
                        object obj = cmd.ExecuteScalar();
                        if (obj != null)
                        {
                            timerjobuid = new Guid(obj.ToString());
                        }
                        else
                        {
                            timerjobuid = Guid.NewGuid();
                            cmd =
                                new SqlCommand(
                                    "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid) VALUES (@timerjobuid, @siteguid, 5, 'Reporting Refresh', 0, @webguid)",
                                    cn);
                            cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
                            cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID.ToString());
                            cmd.Parameters.AddWithValue("@webguid", SPContext.Current.Web.ID.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        if (timerjobuid != Guid.Empty)
                        {
                            CoreFunctions.enqueue(timerjobuid, 0);
                        }

                        cn.Close();
                    }

                    SPUtility.Redirect("epmlive/AllSchedules.aspx", SPRedirectFlags.RelativeToLayoutsPage,
                        HttpContext.Current);
                });
            }
            catch (Exception ex) { }
        }

        protected void loadData(SPWeb web)
        {
            var cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate { cn.Open(); });

            var cmd =
                new SqlCommand(
                    "select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=5",
                    cn);
            cmd.Parameters.AddWithValue("@siteguid", web.Site.ID);
            SqlDataReader dr = cmd.ExecuteReader();

            bool processing = false;

            if (dr.Read())
            {
                if (!dr.IsDBNull(3))
                {
                    if (dr.GetInt32(3) == 0)
                    {
                        processing = true;
                        //lblLastRun.Text = "Queued";
                        lblMessages.Text = "Queued";
                        btnRunNow.Enabled = false;
                    }
                    else if (dr.GetInt32(3) == 1)
                    {
                        processing = true;
                        //lblLastRun.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
                        lblMessages.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
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

                cmd =
                    new SqlCommand(
                        "select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=1",
                        cn);
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
                                //lblLastRun.Text = "Queued";
                                lblMessages.Text = "Queued";
                                btnRunNow.Enabled = false;
                            }
                            else if (dr.GetInt32(3) == 1)
                            {
                                processing = true;
                                //lblLastRun.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
                                lblMessages.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
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
                            lblMessages.Text = dr.GetDateTime(4).ToString();
                    }
                    dr.Close();
                }
            }

            cn.Close();
        }

        //protected void LoadSchedules(bool blnLoadColums)
        //{
        //    DataTable dt;
        //    SPBoundField gridColumn;

        //    _DAO.Command = "SELECT jobname as [Schedule Name], jobdata as [Lists], siteguid, timerjobuid  FROM TIMERJOBS WHERE siteguid ='" + SPContext.Current.Web.Site.ID + "' AND jobtype=7 AND ScheduleType <> 0";
        //    dt = _DAO.GetTable(_DAO.GetEPMLiveConnection);

        //    if (!IsPostBack || blnLoadColums)
        //    {
        //        foreach (DataColumn column in dt.Columns)
        //        {
        //            gridColumn = new SPBoundField();
        //            gridColumn.HeaderText = column.ColumnName;
        //            gridColumn.DataField = column.ColumnName;

        //            if (column.ColumnName.EndsWith("uid"))
        //            {
        //                gridColumn.Visible = false;
        //            }
        //            grdVwSchedules.Columns.Add(gridColumn);
        //        }
        //    }

        //    grdVwSchedules.DataSource = dt;
        //    grdVwSchedules.DataBind();
        //}

        //public void RaisePostBackEvent(string timerjobuid)
        //{
        //    if (timerjobuid.EndsWith("_"))
        //    {
        //        timerjobuid = timerjobuid.Replace("_", "");
        //        SPUtility.Redirect("/epmlive/ReportSchedule.aspx?uid=" + timerjobuid, SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        //    }
        //    else
        //    {
        //        _DAO.Command = "DELETE TIMERJOBS where timerjobuid='" + timerjobuid + "'";
        //        _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
        //        SPUtility.Redirect("epmlive/AllSchedules.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        //    }
        //}

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            _DAO.Dispose();
        }
    }
}