using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Text;
using EPMLiveCore.ReportHelper;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class AllSnapshots : LayoutsPageBase, IPostBackEventHandler
    {
        private EPMData _DAO;
        protected SPGridView grdVwSnapshots;

        public void RaisePostBackEvent(string snapshotuid)
        {
            SPUtility.Redirect("epmlive/Snapshot.aspx?uid=" + snapshotuid, SPRedirectFlags.RelativeToLayoutsPage,
                HttpContext.Current);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            _DAO = new EPMData(SPContext.Current.Web.Site.ID);
            LoadSchedules(true);
            LoadSnapshots();

            if (SPContext.Current.Web.ServerRelativeUrl.EndsWith("/"))
            {
                lnk_createSchedule.HRef = SPContext.Current.Web.ServerRelativeUrl +
                                          "_layouts/epmlive/ReportSchedule.aspx";
            }
            else
            {
                lnk_createSchedule.HRef = SPContext.Current.Web.ServerRelativeUrl +
                                          "/_layouts/epmlive/ReportSchedule.aspx";
            }
        }
         
        protected void LoadSnapshots()
        {
            try
            {
                DataTable manipulateDt = new DataTable();
                _DAO.Command = "spGetSnapshotManagementDetails";
                _DAO.CommandType = CommandType.StoredProcedure;
                DataTable dt = _DAO.GetTable(_DAO.GetClientReportingConnection);
                SPBoundField gridColumn;

                if (!IsPostBack)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        gridColumn = new SPBoundField();
                        gridColumn.HeaderText = column.ColumnName;
                        gridColumn.DataField = column.ColumnName;

                        if (column.ColumnName.ToLower().EndsWith("id"))
                        {
                            gridColumn.Visible = false;
                        }
                        grdVwSnapshots.Columns.Add(gridColumn);
                    }

                    grdVwSnapshots.DataSource = dt;
                    grdVwSnapshots.DataBind();
                }
            }
            catch { }
        }

        protected void LoadSchedules(bool blnLoadColums)
        {
            DataTable dt;
            SPBoundField gridColumn;

            _DAO.Command =
                "SELECT jobname as [Schedule Name], jobdata as [Lists], siteguid, timerjobuid  FROM TIMERJOBS WHERE siteguid ='" +
                SPContext.Current.Web.Site.ID + "' AND jobtype=7 AND ScheduleType <> 0";
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

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            MaintainScrollPositionOnPostBack = true;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            _DAO.Dispose();
        }
    }
}