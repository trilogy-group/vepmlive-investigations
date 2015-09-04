using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;
using Microsoft.SharePoint;

namespace WorkEnginePPM
{
    public partial class Rates_NAX : LayoutsPageBase
    {
        string sBaseInfo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dba = null;
            try
            {
                sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.PortAdmin);
                dba = da.dba;

                if (dba.Open() == StatusEnum.rsSuccess)
                {
                    DataTable dt;

                    dbaRates.SelectResources(dba, out dt);
                    ddlResources.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        int id = DBAccess.ReadIntValue(row["WRES_ID"]);
                        string name = DBAccess.ReadStringValue(row["RES_NAME"]);
                        ListItem li = new ListItem(name, id.ToString("0"));
                        li = new ListItem(name, id.ToString("0"));
                        ddlResources.Items.Add(li);
                    }

                    TGrid tgRates = tgridRates;
                    tgRates.AddColumn(title: "Effective Date", width: 180, name: "BC_EFFECTIVE_DATE", editable: true, type: _TGrid.Type.date);
                    tgRates.AddColumn(title: "Rate", width: 180, name: "BC_RATE", editable: true, type: _TGrid.Type.number);
                    tgRates.Render();

                    dbaRates.SelectAdminRates(dba, out dt);
                    TGrid tg = tgrid1;
                    tg.DragAndDrop = true;
                    tg.AddColumn(title: "ID", width: 50, name: "RT_UID", isId: true, hidden: true);
                    tg.AddColumn(title: "Name", width: 180, name: "RT_NAME", maincol: true, editable: true);
                    tg.AddColumn(title: "Level", width: 180, name: "RT_LEVEL", mainlevelcol: true, hidden: true);
                    tg.AddColumn(title: "Resources", width: 180, name: "res_names");
                    tg.AddColumn(title: "wres_ids", width: 180, name: "wres_ids", hidden: true);
                    tg.AddColumn(title: "rates", width: 180, name: "rates", hidden: true);

                    tg.SetDataTable(dt);
                    tg.Render();

                    //dbaCustomFields.SelectRoles(dba, out dt);
                    //ddlResourceRoles.Items.Clear();
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    int id = DBAccess.ReadIntValue(row["LV_UID"]);
                    //    string name = DBAccess.ReadStringValue(row["LV_VALUE"]);
                    //    ListItem li = new ListItem(name, id.ToString("0"));
                    //    ddlResourceRoles.Items.Add(li);
                    //}
                    dba.Close();
                    if (IsPostBack)
                        updateResourceRate(dt);

                    if (dba.Status != StatusEnum.rsSuccess)
                    {
                        lblGeneralError.Text = "Exception from CostCategories.Page_Load - " + dba.StatusText;
                        lblGeneralError.Visible = true;
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

        protected void updateResourceRate(DataTable dt)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    using (SPSite site = new SPSite(this.Site.Url))
                    {
                        using (SPWeb web = site.OpenWeb())
                        {
                            web.AllowUnsafeUpdates = true;
                            SPList list = web.Lists.TryGetList("Resources");
                            if (list != null)
                            {
                                AdminFunctions objAdminFunctions = new AdminFunctions(sBaseInfo);
                                foreach (DataRow row in dt.Rows)
                                {
                                    string[] wresIds = row["wres_ids"].ToString().Split(',');
                                    string[] resIds = row["res_ids"].ToString().Split(',');
                                    for (int i = 0; i < resIds.Length; i++)
                                    {
                                        if (!string.IsNullOrEmpty(resIds[i]))
                                        {
                                            if (Convert.ToInt32(resIds[i]) != 0)
                                            {
                                                decimal rate = objAdminFunctions.CalcResourceRate(Convert.ToInt32(wresIds[i]));
                                                SPListItem item = list.GetItemById(Convert.ToInt32(resIds[i]));
                                                if (Convert.ToDecimal(item["StandardRate"]) != rate)
                                                    item.Update();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (PFEException pex)
            {
                throw pex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
