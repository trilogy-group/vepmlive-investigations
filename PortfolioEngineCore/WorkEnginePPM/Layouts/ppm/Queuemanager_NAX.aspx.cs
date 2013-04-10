using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;

namespace WorkEnginePPM
{
    public partial class Queuemanager_NAX : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dba = null;
            try
            {
                DGrid dg = dgrid1;
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.DBAUtil);
                dba = da.dba;

                if (dba.Open() == StatusEnum.rsSuccess)
                {
                    dg.AddColumn(title: "ID", width: 50, name: "JOB_GUID", isId: true, hidden: true);
                    _DGrid.DCol col = dg.AddColumn(title: "Context", width: 120, name: "JOB_CONTEXT");
                    col.AddKeyValuePair(0, "Custom");
                    col.AddKeyValuePair(1, "Import Project");
                    col.AddKeyValuePair(2, "Import Lookup");
                    col.AddKeyValuePair(3, "Import Resources");
                    col.AddKeyValuePair(4, "Execute ActiveX");
                    col.AddKeyValuePair(5, "Import PIs");
                    col.AddKeyValuePair(6, "Import Data");
                    col.AddKeyValuePair(7, "Export Data");
                    col.AddKeyValuePair(8, "Maintenance");
                    col.AddKeyValuePair(200, "Refresh Roles");
                    col.AddKeyValuePair(111, "Calc Availability");
                    col.AddKeyValuePair(112, "Calc Default FTEs");
                    col.AddKeyValuePair(100001, "Test");
                    dg.AddColumn(title: "Comment", width: 200, name: "JOB_COMMENT");
                    dg.AddColumn(title: "Submitted", width: 160, name: "JOB_SUBMITTED");
                    dg.AddColumn(title: "Started", width: 160, name: "JOB_STARTED");
                    dg.AddColumn(title: "Completed", width: 160, name: "JOB_COMPLETED");
                    col = dg.AddColumn(title: "Status", width: 140, name: "JOB_STATUS");
                    col.AddKeyValuePair(-2, "Completed with Errors");
                    col.AddKeyValuePair(-1, "Completed");
                    col.AddKeyValuePair(0, "Not Started");
                    col.AddKeyValuePair(1, "Started");
                    dg.AddColumn(title: "Error", width: 40, name: "JOB_ERRORCODE");
                    dg.AddColumn(title: "Status Message", width: 200, name: "JMG_MESSAGE");
                    dg.AddColumn(title: "User Name", width: 180, name: "RES_NAME");

                    DataTable dt;
                    DateTime dtTo = DateTime.Now;
                    DateTime dtFrom = dtTo.AddDays(-30);
                    string sStatusList = "-2,-1,0,1";
                    dbaQueueManager.SelectQueue(dba, dtFrom, dtTo, sStatusList, out dt);
                    dba.Close();
                    dg.SetDataTable(dt);
                    dg.Render();
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
}
