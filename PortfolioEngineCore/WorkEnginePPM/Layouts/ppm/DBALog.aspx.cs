
using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;

namespace WorkEnginePPM
{
    public partial class DBALog : LayoutsPageBase
    {
        protected string strOutput = "";
        protected string RPETitle = "DBALog";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblGeneralError.Visible = false;
            if (!IsPostBack)
            {
                idPage.Text = "1";
                idRowsPerPageCount.Text = "20";
                Page_Reload(sender, e);
            }
        }

        protected void Page_Reload(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                DBAccess dba = null;
                try
                {
                    string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                    DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PortAdmin);
                    dba = da.dba;
                    if (dba.Open() == StatusEnum.rsSuccess)
                    {
                        if (dbaGeneral.CheckUserGlobalPermission(dba, GlobalPermissionsEnum.gpDBA) == false)
                        {
                            lblGeneralError.Text = "You do not have the required DBA permission to view this page";
                            lblGeneralError.Visible = true;
                        }
                        else
                        {
                            int nPageSize;
                            if (Int32.TryParse(idRowsPerPageCount.Text, out nPageSize) == false)
                            {
                                nPageSize = 20;
                                idRowsPerPageCount.Text = nPageSize.ToString("0");
                            }
                            int nPage;
                            if (Int32.TryParse(idPage.Text, out nPage) == false)
                            {
                                nPage = 1;
                                idPage.Text = nPage.ToString("0");
                            }
                            if (nPage < 1)
                            {
                                nPage = 1;
                                idPage.Text = nPage.ToString("0");
                            }
                            int nStartRow = (nPage - 1) * nPageSize + 1;
                            int nFinishRow = nStartRow + nPageSize - 1;

                            int nRowsPerPage = nPageSize;
                            DataTable dt;
                            string cmdText = "WITH pages AS (SELECT ROW_NUMBER() OVER(ORDER BY LOG_TIMESTAMP DESC, LOG_UID) as RowNumber, LOG_UID, (RES_NAME + '(' + convert(nvarchar(MAX), LOG_WRES_ID) + ')') as resname,LOG_STATUS,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS " +
                                            " FROM EPG_LOG " +
                                            " LEFT JOIN EPG_RESOURCES ON (LOG_WRES_ID = WRES_ID)) " +
                                            " SELECT * FROM pages WHERE RowNumber BETWEEN " + nStartRow.ToString() + " AND " + nFinishRow.ToString();
                            //string cmdText = "SELECT LOG_UID,(RES_NAME + '(' + convert(nvarchar(MAX), LOG_WRES_ID) + ')') as resname,LOG_STATUS,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS"
                            //                + " FROM EPG_LOG"
                            //                + " LEFT JOIN EPG_RESOURCES ON LOG_WRES_ID = WRES_ID order by LOG_TIMESTAMP DESC";
                            if (dba.SelectData(cmdText, (StatusEnum)99998, out dt) != StatusEnum.rsSuccess)
                            {
                                lblGeneralError.Text = "SelectData Error : " + dba.Status.ToString() + " - " + dba.StatusText;
                                lblGeneralError.Visible = true;
                            }
                            else
                            {
                                DGrid dg = dgrid1;
                                dg.AddColumn(title: "ID", width: 50, name: "LOG_UID", isId: true, hidden: true);
                                dg.AddColumn(title: "Row", width: 50, name: "RowNumber");
                                dg.AddColumn(title: "Name", width: 180, name: "resname");
                                dg.AddColumn(title: "Status", width: 60, name: "LOG_STATUS", align: _DGrid.Align.center);
                                dg.AddColumn(title: "Timestamp", width: 160, name: "LOG_TIMESTAMP");
                                dg.AddColumn(title: "Keyword", width: 120, name: "LOG_KEYWORD");
                                dg.AddColumn(title: "Function", width: 100, name: "LOG_FUNCTION");
                                dg.AddColumn(title: "Text", width: 200, name: "LOG_TEXT", editable: true);
                                dg.AddColumn(title: "Details", width: 200, name: "LOG_DETAILS", editable: true);
                                dg.SetDataTable(dt);
                                dg.Render();
                            }
                        }
                    }
                }
                catch (PFEException pex)
                {
                    if (pex.ExceptionNumber == 9999)
                        Response.Redirect(this.Site.Url + "/_layouts/ppm/NoPerm.aspx?requesturl='" + Request.RawUrl + "'");
                    lblGeneralError.Text = "PFE Exception : " + pex.ExceptionNumber.ToString() + " - " + pex.Message;
                    lblGeneralError.Visible = true;
                }
                catch (Exception ex)
                {
                    lblGeneralError.Text = ex.Message;
                    lblGeneralError.Visible = true;
                }
                finally
                {
                    if (dba != null)
                        dba.Close();
                }
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            idPage.Text = "1";
            Page_Reload(sender, e);
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            int nPage = 0;
            Int32.TryParse(idPage.Text, out nPage);
            if (nPage > 1)
                idPage.Text = (nPage - 1).ToString("0");
            else
                idPage.Text = "1";
            Page_Reload(sender, e);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            int nPage = Int32.Parse(idPage.Text);
            idPage.Text = (nPage + 1).ToString("0");
            Page_Reload(sender, e);
        }
    }
}
