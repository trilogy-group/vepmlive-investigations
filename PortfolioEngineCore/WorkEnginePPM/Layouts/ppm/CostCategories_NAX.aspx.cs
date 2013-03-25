using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;

namespace WorkEnginePPM
{
    public partial class CostCategories_NAX : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dba = null;
            try
            {
                TGrid tg = tgrid1;
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PortAdmin);
                dba = da.dba;

                if (dba.Open() == StatusEnum.rsSuccess)
                {
                    DataTable dt;
                    ddlMajorCategoryLookups.Items.Clear();
                    CAdmin oAdmin = new CAdmin();
                    if (oAdmin.GetAdminInfo(dba) == StatusEnum.rsSuccess)
                    {
                        {
                            ListItem li = new ListItem("[None]", "0");
                            if (oAdmin.MajorCategoryCode == 0)
                                li.Selected = true;
                            ddlMajorCategoryLookups.Items.Add(li);
                        }
                        
                        dbaRPAdmin.SelectLookupTables(dba, out dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            int id = DBAccess.ReadIntValue(row["LOOKUP_UID"]);
                            string name = DBAccess.ReadStringValue(row["LOOKUP_NAME"]);
                            ListItem li = new ListItem(name, id.ToString("0"));
                            li = new ListItem(name, id.ToString("0"));
                            if (oAdmin.MajorCategoryCode == id)
                                li.Selected = true;
                            ddlMajorCategoryLookups.Items.Add(li);
                        }

                        dbaCostCategories.SelectCostCategories(dba, out dt);

                        tg.DragAndDrop = true;
                        tg.AddColumn(title: "ID", width: 50, name: "CA_UID", isId: true, hidden: true);
                        tg.AddColumn(title: "Category", width: 180, name: "CA_NAME", maincol: true, editable: true);
                        tg.AddColumn(title: "UoM", width: 180, name: "CA_UOM", editable: true);
                        tg.AddColumn(title: "Level", width: 180, name: "CA_LEVEL", mainlevelcol: true, hidden: true);
                        tg.AddColumn(title: "Role", width: 180, name: "CA_ROLE", hidden: true);

                        tg.SetDataTable(dt);
                        tg.Render();

                        dbaCustomFields.SelectRoles(dba, out dt);
                        ddlResourceRoles.Items.Clear();
                        foreach (DataRow row in dt.Rows)
                        {
                            int id = DBAccess.ReadIntValue(row["LV_UID"]);
                            string name = DBAccess.ReadStringValue(row["LV_VALUE"]);
                            ListItem li = new ListItem(name, id.ToString("0"));
                            ddlResourceRoles.Items.Add(li);
                        }
                        dba.Close();
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
}
