using System;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Security.Principal;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.ComponentModel;
using EPMLiveReportsAdmin.Properties;
using System.Data.SqlClient;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveReportsAdmin.Layouts.EPMLive  
{
    public partial class AllSchedules : LayoutsPageBase, IPostBackEventHandler
    {
        EPMData _DAO;
        //protected SPGridView grdVwSchedules;
        //protected DropDownList DropDownListTimes;
        //protected HtmlInputButton btnSave;
        protected MenuItemTemplate MenuItemTemplateDelete;
        protected MenuItemTemplate MenuItemTemplate1;

        //protected Label lblMessages;
        //protected Label lblLastRun;
        //protected HtmlAnchor lnk_createSchedule;

        protected void Page_Init(object sender, EventArgs e)
        {
            _DAO = new EPMData(SPContext.Current.Web.Site.ID);
            LoadSchedules(true);
            LoadScheduleStatus();
        }

        protected void LoadScheduleStatus()
        {

            if (SPContext.Current.Web.ServerRelativeUrl.EndsWith("/"))
            {
                lnk_createSchedule.HRef = SPContext.Current.Web.ServerRelativeUrl + "_layouts/epmlive/ReportSchedule.aspx";
            }
            else
            {
                lnk_createSchedule.HRef = SPContext.Current.Web.ServerRelativeUrl + "/_layouts/epmlive/ReportSchedule.aspx";
            }

            if (!IsPostBack)
            {
                try
                {
                    //using (SPSite site = SPContext.Current.Site)
                    //{
                        //using (SPWeb web = SPContext.Current.Web)
                        //{
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                cn.Open();
                            });

                            SqlCommand cmd = new SqlCommand("select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and listguid is null and jobtype=5 and scheduletype = 2", cn);
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
                       
                        //}
                    //}
                }
                catch (Exception ex)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - Page_Load"))
                            EventLog.CreateEventSource("EPMLive Reporting - Page_Load", "EPM Live");

                        EventLog myLog = new EventLog("EPM Live", ".", "EPMLive Reporting Page_Load");
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
            btnSave.ServerClick += new EventHandler(btnSave_ServerClick);
            btnCancel.ServerClick += btnCancel_ServerClick;
        }

        void btnCancel_ServerClick(object sender, EventArgs e)
        {
            SPUtility.Redirect(SPContext.Current.Web.Url + "/_layouts/epmlive/listmappings.aspx?Source=" + SPContext.Current.Web.Url + "/_layouts/epmlive/settings.aspx", SPRedirectFlags.Static, HttpContext.Current);
        }

        void btnSave_ServerClick(object sender, EventArgs e)
        {
            SaveSchedule();
        }

        protected void SaveSchedule()
        {
            try
            {
                //using (SPSite site = SPContext.Current.Site)
                //{
                    //using (SPWeb web = SPContext.Current.Web)
                    //{
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn.Open();
                        });

                        SqlCommand cmd = new SqlCommand("select timerjobuid from timerjobs where siteguid=@siteguid and listguid is null and jobtype=5 and scheduletype = 2", cn);
                        cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID.ToString());
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            cmd = new SqlCommand("UPDATE TIMERJOBS set runtime = @runtime where siteguid=@siteguid and listguid is null and jobtype=5 and scheduletype = 2", cn);
                            cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID.ToString());
                            cmd.Parameters.AddWithValue("@runtime", DropDownListTimes.SelectedValue);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            dr.Close();
                            cmd = new SqlCommand("INSERT INTO TIMERJOBS (siteguid, jobtype, jobname, scheduletype, webguid, runtime) VALUES (@siteguid, 5, 'Reporting Refresh All', 2, @webguid, @runtime)", cn);
                            cmd.Parameters.AddWithValue("@siteguid", SPContext.Current.Site.ID.ToString());
                            cmd.Parameters.AddWithValue("@webguid", SPContext.Current.Web.ID.ToString());
                            cmd.Parameters.AddWithValue("@runtime", DropDownListTimes.SelectedValue);

                            cmd.ExecuteNonQuery();
                        }

                        cn.Close();
                    //}
                //}
            }
            catch (Exception ex)
            {

            }
        }

        protected void LoadSchedules(bool blnLoadColums)
        {
            DataTable dt;
            SPBoundField gridColumn;

            _DAO.Command = "SELECT jobname as [Schedule Name], jobdata as [Lists], siteguid, timerjobuid  FROM TIMERJOBS WHERE siteguid ='" + SPContext.Current.Web.Site.ID + "' AND jobtype=7 AND ScheduleType <> 0";
            dt = _DAO.GetTable(_DAO.GetEPMLiveConnection);

            if (!IsPostBack || blnLoadColums)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    gridColumn = new SPBoundField();
                    gridColumn.HeaderText = column.ColumnName;
                    gridColumn.DataField = column.ColumnName;

                    if (column.ColumnName.EndsWith("uid"))
                    {
                        gridColumn.Visible = false;
                    }
                    grdVwSchedules.Columns.Add(gridColumn);
                }
            }

            grdVwSchedules.DataSource = dt;
            grdVwSchedules.DataBind();
        }

        public void RaisePostBackEvent(string timerjobuid)
        {
            if (timerjobuid.EndsWith("_"))
            {
                timerjobuid = timerjobuid.Replace("_", "");
                SPUtility.Redirect("/epmlive/ReportSchedule.aspx?uid=" + timerjobuid, SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            else
            {
                _DAO.Command = "DELETE TIMERJOBS where timerjobuid='" + timerjobuid + "'";
                _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
                SPUtility.Redirect("epmlive/AllSchedules.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            _DAO.Dispose();
        }
    }
}
