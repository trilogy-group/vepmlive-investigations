using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Text;

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
            DataTable manipulateDt = new DataTable();

            _DAO.Command = "SELECT Enabled as [Active], Title as [Report Title], PeriodDate as [Reporting Period], DateArchived as [Snapshot Date], ListNames as [Lists],periodid,siteid FROM RPTPeriods";

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

                //EPML-4538 : List Names in Snapshot Management Page showing as Unique ID's
                //Manipulate data table to process List Guids and display list name on Snapshot Management page.
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StringBuilder listNames = new StringBuilder();
                        string listIds = Convert.ToString(dt.Rows[i]["Lists"]);
                        if (!string.IsNullOrEmpty(listIds) && listIds.Contains(","))
                            listIds = listIds.Replace(", ", "','").Trim();

                        _DAO.Command = "SELECT DISTINCT ListName FROM RPTList WHERE RPTListId in('" + listIds + "')";
                        manipulateDt = _DAO.GetTable(_DAO.GetClientReportingConnection);

                        if (manipulateDt != null && manipulateDt.Rows.Count > 0)
                        {
                            for (int id = 0; id < manipulateDt.Rows.Count; id++)
                            {
                                listNames.Append(Convert.ToString(manipulateDt.Rows[id][0]) + ", ");
                            }
                            if (listNames.Length > 0)
                                dt.Rows[i]["Lists"] = listNames.ToString().Substring(0, listNames.Length - 2).Trim();
                        }
                    }
                }

                grdVwSnapshots.DataSource = dt;
                grdVwSnapshots.DataBind();
            }
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