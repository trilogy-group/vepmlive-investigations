using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;
using System.Data.SqlClient;

namespace WorkEnginePPM
{
    public partial class RPTestData : LayoutsPageBase
    {
        protected string strOutput = "";
        protected string RPETitle = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

            //int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.PortfolioEngine);
            //if (activation != 0)
            //{
            //    RPETitle = "Resource Capacity Planner - Page Activation Issue";
            //    strOutput = act.translateStatus(activation);
            //    LiteralControl lit = new LiteralControl(strOutput.ToString());
            //    PlaceHolder1.Controls.Add(lit);
            //    return;
            //}
            lblGeneralError.Visible = false;
            if (!IsPostBack)
            {
                DBAccess dba = null;
                try
                {
                    string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                    DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PortAdmin);
                    dba = da.dba;

                    if (dba.Open() == StatusEnum.rsSuccess)
                    {
                        ddlPIs.Items.Clear();
                        string cmdText = "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION = 0 ORDER BY PROJECT_NAME";
                        SqlCommand oCommand = new SqlCommand(cmdText, dba.Connection);
                        DataTable dt;
                        if (dba.SelectData(oCommand, (StatusEnum)99999, out dt) == StatusEnum.rsSuccess)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                string extuid = DBAccess.ReadStringValue(row["PROJECT_EXT_UID"]);
                                string name = DBAccess.ReadStringValue(row["PROJECT_NAME"]);
                                ListItem li = new ListItem(name, extuid);
                                ddlPIs.Items.Add(li);
                                string id = DBAccess.ReadStringValue(row["PROJECT_ID"]);
                                li = new ListItem(name, id);
                                lstSaveAsPIs.Items.Add(li);
                            }
                            dba.Close();
                        }

                        if (dba.Status != StatusEnum.rsSuccess)
                        {
                            lblGeneralError.Text = "Exception from CostCategories.Page_Load - " + dba.StatusText;
                            lblGeneralError.Visible = true;
                        }
                    }
                }
                catch (PFEException pex)
                {
                    //if (pex.ExceptionNumber == 9999)
                    //    Response.Redirect(this.Site.Url + "/_layouts/ppm/NoPerm.aspx?requesturl='" + Request.RawUrl + "'");
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
        protected void btnGo_Click(object sender, EventArgs e)
        {
            ListItem li = ddlPIs.SelectedItem;
            if (li != null && li.Text != string.Empty)
            {
                PlaceHolder1.Controls.Clear();
                WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl)LoadControl("/_layouts/ppm/RPEditor.ascx");
                ctl.WEPID = li.Value;
                ctl.TicketVal = "";
                ctl.IsResource = "0";
                ctl.IsDlg = "0";
                PlaceHolder1.Controls.Add(ctl);
            }
        }
    }
}
