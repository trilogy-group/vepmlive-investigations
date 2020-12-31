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
using System.Collections.Generic;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class AllSchedules : LayoutsPageBase
    {
        protected MenuItemTemplate MenuItemTemplate1;
        protected MenuItemTemplate MenuItemTemplateDelete;
        private EPMData _DAO;
        static Dictionary<Guid, int> expectedRuntime = new Dictionary<Guid, int>();
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
                                "select timerjobuid,runtime,percentComplete,status,dtfinished,result,dtcreated from vwQueueTimerLog where siteguid=@siteguid and listguid is null and jobtype=5 and scheduletype = 2",
                                cn);
                        cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                                if (dr.Read())
                                {
                                    if (!dr.IsDBNull(1))
                                    {
                                        DropDownListTimes.SelectedValue = dr.GetInt32(1).ToString();
                                    }

                                    if (!dr.IsDBNull(3))
                                    {
                                        int status = dr.GetInt32(3);
                                        if (status == 0)
                                        {
                                            lblMessages.Text = "Queued";
                                        }
                                        else if (status == 1)
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
                                    {
                                        TimeSpan runPeriod = dr.GetDateTime(4) - dr.GetDateTime(6);
                                        if (runPeriod > new TimeSpan(0, 80, 0))
                                            runPeriod = new TimeSpan(0, 80, 0);
                                        if (expectedRuntime.ContainsKey(SPContext.Current.Site.ID))
                                        {
                                            expectedRuntime[SPContext.Current.Site.ID] = (int)runPeriod.TotalMinutes + 1;
                                        }
                                        else
                                        {
                                            expectedRuntime.Add(SPContext.Current.Site.ID, (int)runPeriod.TotalMinutes + 1);
                                        }
                                        lblLastRun.Text = dr.GetDateTime(4).ToString();
                                        hidRuntime.Value = "0";
                                    }
                                    else
                                    {
                                        if (!expectedRuntime.ContainsKey(SPContext.Current.Site.ID))
                                        {
                                            expectedRuntime.Add(SPContext.Current.Site.ID, 80);
                                        }
                                        int runtime = (DateTime.Now - dr.GetDateTime(6)).Minutes;
                                        lblLastRun.Text = runtime + " Minutes";
                                        hidRuntime.Value = (runtime).ToString();
                                    }
                                }
                                if (expectedRuntime.ContainsKey(SPContext.Current.Site.ID))
                                {
                                    hidRunPeriod.Value = expectedRuntime[SPContext.Current.Site.ID].ToString();
                                }
                            }
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

                    int numberOfJobs = 0;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(dr);
                            numberOfJobs = dt.Rows.Count;
                        }
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
                }
            });
        }

        protected void RunRefreshNow(object sender, EventArgs e)
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

                }

                SPUtility.Redirect("epmlive/AllSchedules.aspx", SPRedirectFlags.RelativeToLayoutsPage,
                    HttpContext.Current);
            });
        }

        protected void loadData(SPWeb web)
        {
            using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
            {
                SPSecurity.RunWithElevatedPrivileges(delegate { sqlConnection.Open(); });

                const string SelectJobType5Command =
                    "select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=5";

                var processing = false;

                using (var sqlCommand = new SqlCommand(SelectJobType5Command, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@siteguid", web.Site.ID);

                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            if (!dataReader.IsDBNull(3))
                            {
                                if (dataReader.GetInt32(3) == 0)
                                {
                                    processing = true;
                                    lblMessages.Text = "Queued";
                                    btnRunNow.Enabled = false;
                                }
                                else if (dataReader.GetInt32(3) == 1)
                                {
                                    processing = true;
                                    lblMessages.Text = $"Processing ({dataReader.GetInt32(2):##0}%)";
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

                const string SelectJobType1Command =
                    "select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=1";

                using (var selectJobType1SqlCommand = new SqlCommand(SelectJobType1Command, sqlConnection))
                {
                    selectJobType1SqlCommand.Parameters.AddWithValue("@siteguid", web.Site.ID);

                    using (var sqlDataReader = selectJobType1SqlCommand.ExecuteReader())
                    {
                        if (!processing && sqlDataReader.Read())
                        {
                            if (!sqlDataReader.IsDBNull(3))
                            {
                                if (sqlDataReader.GetInt32(3) == 0)
                                {
                                    lblMessages.Text = "Queued";
                                    btnRunNow.Enabled = false;
                                }
                                else if (sqlDataReader.GetInt32(3) == 1)
                                {
                                    lblMessages.Text = $"Processing ({sqlDataReader.GetInt32(2):##0}%)";
                                    btnRunNow.Enabled = false;
                                }
                                else if (!sqlDataReader.IsDBNull(5))
                                {
                                    lblMessages.Text = sqlDataReader.GetString(5);
                                }
                                else
                                {
                                    lblMessages.Text = "No Results";
                                }
                            }

                            if (!sqlDataReader.IsDBNull(4))
                            {
                                lblMessages.Text = sqlDataReader.GetDateTime(4).ToString();
                            }
                        }
                    }
                }
            }
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