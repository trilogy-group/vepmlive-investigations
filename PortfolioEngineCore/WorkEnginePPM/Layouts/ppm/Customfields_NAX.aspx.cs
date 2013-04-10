using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;

namespace WorkEnginePPM
{
    public partial class Customfields_NAX : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dba = null;
            try
            {
                DGrid dg = dgrid1;
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo, SecurityLevels.BaseAdmin);
                dba = da.dba;
                if (dba.Open() == StatusEnum.rsSuccess)
                {
                    dg.AddColumn(title: "Entity", width: 80, name: "ENTITY_NAME");
                    dg.AddColumn(title: "Name", width: 180, name: "FA_NAME");
                    dg.AddColumn(title: "Description", width: 200, name: "FA_DESC");
                    dg.AddColumn(title: "Field Type", width: 80, name: "FA_FORMAT_NAME");
                    dg.AddColumn(title: "Table", width: 200, name: "TABLE_NAME");
                    dg.AddColumn(title: "Field", width: 100, name: "FIELD_NAME");
                    dg.AddColumn(title: "Lookup", width: 80);
                    dg.AddColumn(title: "ID", width: 50, name: "FA_FIELD_ID", isId: true);

                    DataTable dt;
                    dbaCustomFields.SelectCustomFields(dba, out dt);
                    dba.Close();

                    // add the extra columns in to the datatable
                    DataColumn col = new DataColumn();
                    col.DataType = System.Type.GetType("System.String");
                    col.ColumnName = "ENTITY_NAME";
                    col.DefaultValue = "";
                    dt.Columns.Add(col);
                    col = new DataColumn();
                    col.DataType = System.Type.GetType("System.String");
                    col.ColumnName = "FA_FORMAT_NAME";
                    col.DefaultValue = "";
                    dt.Columns.Add(col);
                    col = new DataColumn();
                    col.DataType = System.Type.GetType("System.String");
                    col.ColumnName = "TABLE_NAME";
                    col.DefaultValue = "";
                    dt.Columns.Add(col);
                    col = new DataColumn();
                    col.DataType = System.Type.GetType("System.String");
                    col.ColumnName = "FIELD_NAME";
                    col.DefaultValue = "";
                    dt.Columns.Add(col);

                    foreach (DataRow row in dt.Rows)
                    {
                        int lEntity = DBAccess.ReadIntValue(row["Entity"]);
                        string sEntity = "";
                        if (lEntity == 2) sEntity = "Portfolio"; else sEntity = "Resource";
                        row["ENTITY_NAME"] = sEntity;

                        int lDataType = DBAccess.ReadIntValue(row["FA_FORMAT"]);
                        row["FA_FORMAT_NAME"] = EPKClass01.GetFieldFormat(lDataType);

                        string sTable;
                        string sField;
                        int lTable = DBAccess.ReadIntValue(row["FA_TABLE_ID"]);
                        int lField = DBAccess.ReadIntValue(row["FA_FIELD_IN_TABLE"]);
                        if (EPKClass01.GetTableAndField(lTable, lField, out sTable, out sField))
                        {
                            row["TABLE_NAME"] = sTable;
                            row["FIELD_NAME"] = sField;
                        }
                        else
                        {
                            row["TABLE_NAME"] = "Unknown Table";
                            row["FIELD_NAME"] = "";
                        }
                    }
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
