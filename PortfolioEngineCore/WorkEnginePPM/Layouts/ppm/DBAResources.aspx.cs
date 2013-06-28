
using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;

namespace WorkEnginePPM
{
    public partial class DBAResources : LayoutsPageBase
    {
        protected string strOutput = "";
        protected string RPETitle = "DBAPIs";

        protected void Page_Load(object sender, EventArgs e)
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
                            DataTable dt;
                            //string cmdText = "SELECT * FROM EPG_RESOURCES LEFT JOIN EPG_RESOURCES ON PROJECT_CHECKEDOUT_BY = WRES_ID order by PROJECT_NAME";
                            string cmdText = "SELECT RES_NAME,r.WRES_ID,WRES_EXT_UID,WRES_INACTIVE," +
                                            " x.BC_UID,BC_NAME as CC,WRES_RP_DEPT,d1.LV_FULLVALUE as RPDept," +
                                            " WRES_IS_RESOURCE,WRES_IS_GENERIC,WRES_CAN_LOGIN," +
                                            " case When (WRES_IS_GENERIC>0) Then '2 - Generic'" +
                                            "      When (WRES_IS_RESOURCE>0) Then '1 - Resource'" +
                                            "      When (WRES_CAN_LOGIN>0) Then '3 - User'" +
                                            "      Else '4 - Other' End as MainSortKey," +
                                            " case When (WRES_INACTIVE>0) Then 'Inactive'" +
                                            "      Else 'Active' End as Status" +
                                            " From EPG_RESOURCES r" +
                                            " Left Join EPGP_COST_XREF x On x.WRES_ID=r.WRES_ID" +
                                            " Left Join EPGP_LOOKUP_VALUES d1 On d1.LV_UID=r.WRES_RP_DEPT" +
                                            " Left Join EPGP_COST_CATEGORIES c On c.BC_UID=x.BC_UID" +
                                            " Order By MainSortKey,RES_NAME";
                            if (dba.SelectData(cmdText, (StatusEnum)99998, out dt) != StatusEnum.rsSuccess)
                            {
                                lblGeneralError.Text = "SelectData Error : " + dba.Status.ToString() + " - " + dba.StatusText;
                                lblGeneralError.Visible = true;
                            }
                            else
                            {
                                DGrid dg = dgrid1;
                                dg.AddColumn(title: "ID", width: 40, name: "WRES_ID", align: _DGrid.Align.center, isId: true);
                                dg.AddColumn(title: "Name", width: 180, name: "RES_NAME");
                                dg.AddColumn(title: "Ext ID", width: 50, name: "WRES_EXT_UID", align: _DGrid.Align.center);
                                dg.AddColumn(title: "Type", width: 100, name: "MainSortKey");
                                dg.AddColumn(title: "Status", width: 80, name: "Status");
                                dg.AddColumn(title: "Dept", width: 100, name: "RPDept");
                                dg.AddColumn(title: "Role", width: 100, name: "CC");
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

        //protected void ddlTables_OnTextChanged(object sender, EventArgs e)
        //{
        //    DBAccess dba = null;
        //    try
        //    {
        //        idPage.Text = "1";
        //        string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
        //        DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PortAdmin);
        //        dba = da.dba;
        //        if (dba.Open() == StatusEnum.rsSuccess)
        //        {
        //            ListItem li = ddlTables.SelectedItem;
        //            if (li != null && li.Text != string.Empty)
        //                PopulateColumnsList(dba, li.Text);
        //        }
        //    }
        //    catch (PFEException pex)
        //    {
        //        if (pex.ExceptionNumber == 9999)
        //            Response.Redirect(this.Site.Url + "/_layouts/ppm/NoPerm.aspx?requesturl='" + Request.RawUrl + "'");
        //        lblGeneralError.Text = "PFE Exception : " + pex.ExceptionNumber.ToString() + " - " + pex.Message;
        //        lblGeneralError.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblGeneralError.Text = ex.Message;
        //        lblGeneralError.Visible = true;
        //    }
        //    finally
        //    {
        //        if (dba != null)
        //            dba.Close();
        //    }
        //}

        //protected void btnPrev_Click(object sender, EventArgs e)
        //{
        //    int nPage = 0;
        //    Int32.TryParse(idPage.Text, out nPage);
        //    if (nPage > 1)
        //        idPage.Text = (nPage - 1).ToString("0");
        //    else
        //        idPage.Text = "1";

        //    btnGo_Click(sender, e);
        //}

        //protected void btnNext_Click(object sender, EventArgs e)
        //{
        //    int nPage = Int32.Parse(idPage.Text);
        //    idPage.Text = (nPage + 1).ToString("0");
        //    btnGo_Click(sender, e);
        //}

        //protected void btnGo_Click(object sender, EventArgs e)
        //{
        //    DBAccess dba = null;
        //    try
        //    {
        //        string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
        //        DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PortAdmin);
        //        dba = da.dba;
        //        if (dba.Open() == StatusEnum.rsSuccess)
        //        {
        //            if (dbaGeneral.CheckUserGlobalPermission(dba, GlobalPermissionsEnum.gpDBA) == false)
        //            {
        //                lblGeneralError.Text = "You do not have the required DBA permission to view this page";
        //                lblGeneralError.Visible = true;
        //                pnlMain.Visible = false;
        //            }
        //            else
        //            {
        //                DataTable dt;
        //                ListItem li = ddlTables.SelectedItem;
        //                if (li != null && li.Text != string.Empty)
        //                {
        //                    //CREATE PROCEDURE dbo.EPG_SP_ReadTableRowRange
        //                    //  @sTable NTEXT,
        //                    //  @sOrderByClause NTEXT,
        //                    //  @intStartRow int,
        //                    //  @intEndRow int
        //                    //AS
        //                    int nPageSize = 15;
        //                    if (Int32.TryParse(idRowsPerPageCount.Text, out nPageSize) == false)
        //                    {
        //                        nPageSize = 15;
        //                        idRowsPerPageCount.Text = nPageSize.ToString("0");
        //                    }
        //                    int nPage = 1;
        //                    if (Int32.TryParse(idPage.Text, out nPage) == false)
        //                    {
        //                        nPage = 1;
        //                        idPage.Text = nPage.ToString("0");
        //                    }
        //                    if (nPage < 1)
        //                    {
        //                        nPage = 1;
        //                        idPage.Text = nPage.ToString("0");
        //                    }
        //                    int nStartRow = (nPage - 1) * nPageSize + 1;
        //                    int nFinishRow = nStartRow + nPageSize - 1;

        //                    dba.SelectData("SELECT COUNT(0) as rowsintable FROM " + li.Text, (StatusEnum)99998, out dt);
        //                    int rowCount = 0;
        //                    if (dt.Rows.Count == 1)
        //                    {
        //                        DataRow row = dt.Rows[0];

        //                        rowCount = DBAccess.ReadIntValue(row["rowsintable"]);
        //                    }

        //                    idPageCount.Text = " of " + ((rowCount / nPageSize) + 1).ToString("0") + " (total: " + rowCount.ToString("0") + " rows)";

        //                    ListItem liColumns = ddlColumns.SelectedItem;
        //                    string sOrderBy = "ORDER BY " + liColumns.Text;
        //                    if (cbDescending.Checked)
        //                        sOrderBy += " DESC";
        //                    liColumns = ddlColumns2.SelectedItem;
        //                    if (liColumns.Text != "--NONE--" )
        //                    {
        //                        sOrderBy += ", " + liColumns.Text;
        //                        if (cbDescending2.Checked)
        //                            sOrderBy += " DESC";
        //                    }
        //                    string cmdText = "EPG_SP_ReadTableRowRange '" + li.Text + "', '" + sOrderBy + "', " + nStartRow.ToString("0") + ", " + nFinishRow.ToString("0");

        //                    if (dba.SelectData(cmdText, (StatusEnum)99998, out dt) != StatusEnum.rsSuccess)
        //                    {
        //                        lblGeneralError.Text = "SelectData Error : " + dba.Status.ToString() + " - " + dba.StatusText;
        //                        lblGeneralError.Visible = true;
        //                        pnlMain.Visible = false;
        //                    }
        //                    else
        //                    {
        //                        DGrid dg = dgrid1;
        //                        dg.SetDataTable(dt);
        //                        dg.Render();

        //                        pnlMain.Visible = true;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (PFEException pex)
        //    {
        //        if (pex.ExceptionNumber == 9999)
        //            Response.Redirect(this.Site.Url + "/_layouts/ppm/NoPerm.aspx?requesturl='" + Request.RawUrl + "'");
        //        lblGeneralError.Text = "PFE Exception : " + pex.ExceptionNumber.ToString() + " - " + pex.Message;
        //        lblGeneralError.Visible = true;
        //        pnlMain.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblGeneralError.Text = ex.Message;
        //        lblGeneralError.Visible = true;
        //        pnlMain.Visible = false;
        //    }
        //    finally
        //    {
        //        if (dba != null)
        //            dba.Close();
        //    }
        //}

        //private void PopulateTablesList(DBAccess dba)
        //{
        //    DataTable dt;
        //    string cmdText = "SELECT epgtables.name FROM sysobjects epgtables WHERE epgtables.xtype = 'U' order by epgtables.name";
        //    dba.SelectData(cmdText, (StatusEnum)99998, out dt);
        //    ddlColumns.Items.Clear();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        string name = DBAccess.ReadStringValue(row["name"]);
        //        ListItem li = new ListItem(name);
        //        ddlTables.Items.Add(li);
        //    }
        //}

        //private void PopulateColumnsList(DBAccess dba, string sTableName)
        //{
        //    if (sTableName != string.Empty)
        //    {
        //        DataTable dt;
        //        string cmdText = "select COLUMN_NAME from information_schema.columns where table_name = @p1";
        //        dba.SelectDataByName(cmdText, sTableName, (StatusEnum)99997, out dt);
        //        cbDescending.Checked = false;
        //        cbDescending2.Checked = false;
        //        ddlColumns.Items.Clear();
        //        ddlColumns2.Items.Clear();
        //        {
        //            ListItem li = new ListItem("--NONE--");
        //            ddlColumns2.Items.Add(li);
        //        }
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            string name = DBAccess.ReadStringValue(row["COLUMN_NAME"]);
        //            ListItem li = new ListItem(name);
        //            ddlColumns.Items.Add(li);
        //            ddlColumns2.Items.Add(li);
        //        }
        //    }
        //}
    }
}
