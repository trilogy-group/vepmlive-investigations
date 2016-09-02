using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;

namespace WorkEnginePPM
{
    public partial class DBAdmin_NAX : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dba = null;
            try
            {
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PMO);
                dba = da.dba;

                if (dba.Open() == StatusEnum.rsSuccess)
                {
                    //DataTable dt;
                    //ListItem li = new ListItem("[None]", "0");
                    //ddlCostTypes.Items.Add(li);

                    //dbaCostTypes.SelectCostTypes(dba, out dt);
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    int id = DBAccess.ReadIntValue(row["CT_ID"]);
                    //    string name = DBAccess.ReadStringValue(row["CT_NAME"]);
                    //    int nEditmode = DBAccess.ReadIntValue(row["CT_EDIT_MODE"]);
                    //    int nInputcalendar = DBAccess.ReadIntValue(row["CT_CB_ID"]);
                    //    if (nEditmode != (int)CTEditMode.ctCalculated && nEditmode != (int)CTEditMode.ctCalculatedCumulative
                    //        && nEditmode != (int)CTEditMode.ctDisplay && nEditmode != (int)CTEditMode.ctDisplaywDetails
                    //        && !(nEditmode == (int)CTEditMode.ctBudget && nInputcalendar < 0))
                    //    {
                    //        li = new ListItem(name, id.ToString("0"));
                    //        ddlCostTypes.Items.Add(li);
                    //    }
                    //}
                    dba.Close();
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
