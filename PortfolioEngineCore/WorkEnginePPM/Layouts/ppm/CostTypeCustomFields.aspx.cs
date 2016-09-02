using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;

namespace WorkEnginePPM
{
    public partial class CostTypeCustomFields : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dba = null;
            try
            {
                DGrid dg = dgrid1;
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PortAdmin);
                dba = da.dba;

                if (dba.Open() == StatusEnum.rsSuccess)
                {
                    DataTable dt;

                    //CAdmin oAdmin = new CAdmin();
                    //if (oAdmin.GetAdminInfo(dba) != StatusEnum.rsSuccess)
                    //    goto Status_Error;

                    dbaRPAdmin.SelectLookupTables(dba, out dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int id = DBAccess.ReadIntValue(row["LOOKUP_UID"]);
                        string name = DBAccess.ReadStringValue(row["LOOKUP_NAME"]);
                        ListItem li = new ListItem(name, id.ToString("0"));
                        li = new ListItem(name, id.ToString("0"));
                        ddlLookups.Items.Add(li);
                    }
                    dbaCostTypes.SelectCostTypeCustomFields(dba, out dt);

                    dg.AddColumn(title: "ID", width: 50, name: "FieldId", isId: true, hidden: true);
                    dg.AddColumn(title: "Fields", width: 80, name: "FieldName");
                    dg.AddColumn(title: "Linked Name", width: 180, name: "FA_NAME");
                    dg.AddColumn(title: "Lookupuid", width: 180, name: "FA_LOOKUP_UID", hidden: true);

                    dg.SetDataTable(dt);
                    dg.Render();
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
