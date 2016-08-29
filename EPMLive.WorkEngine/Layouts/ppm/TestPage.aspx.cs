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
    public partial class TestPage : LayoutsPageBase
    {
        protected string pageTitle = "Test Page for Resource and Cost Planners and Analyzers";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblGeneralError.Visible = false;
            if (!IsPostBack)
            {
                DBAccess dba = null;
                try
                {
                    EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

                    int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.PortfolioEngine);
                    if (activation != 0)
                    {
                        pageTitle = "Page Activation Issue";
                        lblGeneralError.Text = act.translateStatus(activation); 
                        lblGeneralError.Visible = true;
                        return;
                    }
                    string option = Request["option"];
                    if (string.IsNullOrEmpty(option) == false)
                    {
                        CreateControl(option.ToUpper());
                    }
                    else
                    {
                        idselectdiv.Visible = true;
                        string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PortAdmin);
                        dba = da.dba;

                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            ddlItems.Items.Clear();
                            ddlItems.Items.Add(new ListItem("Cost Planner", "CP"));
                            ddlItems.Items.Add(new ListItem("Resource Planner", "RP"));
                            ddlItems.Items.Add(new ListItem("Resource Analyzer", "RA"));
                            ddlItems.Items.Add(new ListItem("Cost Analyzer", "CA"));
                            ddlItems.Items.Add(new ListItem("Modeler", "MO"));

                            if (dba.Status != StatusEnum.rsSuccess)
                            {
                                lblGeneralError.Text = "Exception from CostCategories.Page_Load - " + dba.StatusText;
                                lblGeneralError.Visible = true;
                            }
                        }
                    }
                }
                catch (PFEException pex)
                {
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
            ListItem li = ddlItems.SelectedItem;
            if (li != null && li.Text != string.Empty)
            {
                CreateControl(li.Value);
            }
        }

        private void CreateControl(string sOption)
        {
            PlaceHolder1.Controls.Clear();
            switch (sOption)
            {
                case "CP":
                {
                    pageTitle = "Cost Planner";
                    WorkEnginePPM.ControlTemplates.WorkEnginePPM.EditCostsControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.EditCostsControl)LoadControl("/_layouts/ppm/EditCosts.ascx");
                    PlaceHolder1.Controls.Add(ctl);
                    break;
                }
                case "RP":
                {
                    pageTitle = "Resource Planner";
                    WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl)LoadControl("/_layouts/ppm/RPEditor.ascx");
                    ctl.IsResource = "0";
                    ctl.IsDlg = "0";
                    PlaceHolder1.Controls.Add(ctl);
                    break;
                }
                case "RA":
                {
                    pageTitle = "Resource Analyzer";
                    WorkEnginePPM.ControlTemplates.WorkEnginePPM.ResPlanAnalyzerControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.ResPlanAnalyzerControl)LoadControl("/_layouts/ppm/ResPlanAnalyzer.ascx");
                    PlaceHolder1.Controls.Add(ctl);
                    break;
                }
                case "MO":
                {
                    pageTitle = "Modeler";
                    WorkEnginePPM.ControlTemplates.WorkEnginePPM.ModelControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.ModelControl)LoadControl("/_layouts/ppm/Model.ascx");
                    PlaceHolder1.Controls.Add(ctl);
                    break;
                }
                case "CA":
                {
                    pageTitle = "Cost Analyzer";
                    WorkEnginePPM.ControlTemplates.WorkEnginePPM.CostAnalyzerControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.CostAnalyzerControl)LoadControl("/_layouts/ppm/CostAnalyzer.ascx");
                    PlaceHolder1.Controls.Add(ctl);
                    break;
                }
                default:
                    lblGeneralError.Text = "Unknown control : " + sOption + "\nValid options are : CP, RP, RA, MO, CA";
                    lblGeneralError.Visible = true;
                break;
            }
        }
    }
}
