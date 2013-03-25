using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    public partial class Pri_FormulasForm : LayoutsPageBase
    {
        //private List<int> c_formulas = null;
        //public List<int> Formulas
        //{
        //    get { return c_formulas; }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dba = null;
            if (!IsPostBack)
            {
                if (Request.QueryString.HasKeys())
                {
                    string m_sId = Request.QueryString["id"].ToString();
                    string m_sMode = Request.QueryString["mode"].ToString();

                    if (!WorkEnginePPM.WebAdmin.HasPagePermission("PrioritizationForm", m_sMode))
                        HttpContext.Current.Response.Redirect("NoPermForm.aspx");

                    lblMode.Text = "Prioritization Scenarios";
                    btnSave.Visible = true;

                    string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                    dba = new DBAccess(sDBConnect);
                    if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                    DataTable dt;

                    Dictionary<int, string> Fields = new Dictionary<int, string>();
                    ListItem liField;
                    if (dbaPrioritz.SelectFormulaFields(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
                    foreach (DataRow row in dt.Rows)
                    {
                        int nFieldID = DBAccess.ReadIntValue(row["FA_FIELD_ID"]);
                        string sField = DBAccess.ReadStringValue(row["FA_NAME"]);
                        Fields.Add(nFieldID, sField);
                    }

                    string sFieldName;
                    if (dbaPrioritz.SelectFormulas(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
                    foreach (DataRow row in dt.Rows)
                    {
                        int lFieldID = DBAccess.ReadIntValue(row["CW_RESULT"]);
                        if (Fields.TryGetValue(lFieldID, out sFieldName))
                        {
                            Fields.Remove(lFieldID);
                            ListItem listItem = new ListItem();
                            listItem.Value = lFieldID.ToString();
                            listItem.Text = sFieldName;
                            lstFormulas.Items.Add(listItem);
                        }
                    }

                    foreach (KeyValuePair<int, string> DicItem in Fields)
                    {
                        liField = new ListItem();
                        liField.Text = DicItem.Value.ToString();
                        liField.Value = DicItem.Key.ToString();
                        lstFields.Items.Add(liField);
                    }

                    dba.Close();
                }
            }
            return;
        Status_Error:
            if (dba != null)
            {
                dba.Close();
                lblGeneralError.Text = dba.FormatErrorText();
                lblGeneralError.Visible = true;
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            DBAccess dba = null;

            // Stick selected formulas into collection
            DataTable dtFormulas = new DataTable();
            foreach (ListItem li in lstFormulas.Items)
            {
                DataRow row = dtFormulas.NewRow();
                row["Formula"] = Int32.Parse(li.Value);
                dtFormulas.Rows.Add(row);
            }
            //c_formulas = new List<int>();
            //foreach (ListItem li in lstFormulas.Items)
            //{
            //    c_formulas.Add(Int32.Parse(li.Value));
            //}

            string sDBConnect = WebAdmin.GetConnectionString(this.Context);
            dba = new DBAccess(sDBConnect);
            if (dba.Open() != StatusEnum.rsSuccess) goto Exit_Function;

            DataTable dt;
            if (dbaPrioritz.SelectComponents(dba, out dt) != StatusEnum.rsSuccess) goto Exit_Function;
            if (dt.Rows.Count == 0)
            {
                lblGeneralError.Text = "Cannot save a scenario without components. Select at least one component first.";
                lblGeneralError.Visible = true;
                return;
            }


            int lRowsAffected;
            if (dbaPrioritz.UpdateFormulas(dba, dtFormulas, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

            //ClientScript.RegisterStartupScript(this.GetType(), "CT_Script", "OnFormulasSavedOK();", true);
        Exit_Function:
            if (dba != null)
            {
                if (dba.Status != StatusEnum.rsSuccess)
                {
                    lblGeneralError.Text = dba.FormatErrorText();
                    lblGeneralError.Visible = true;
                }
                dba.Close();
            }
            return;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            // NB - this is how we get the popup to close when the save has occurred
//            ClientScript.RegisterStartupScript(this.GetType(), "CT_Script", "OnFormulasClose();", true);
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            moveItems(lstFields, lstFormulas);
        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            moveItems(lstFormulas, lstFields);
        }
        private void moveItems(ListBox lstFrom, ListBox lstTo)
        {
            ArrayList selected = new ArrayList();
            foreach (ListItem li in lstFrom.Items)
            {
                if (li.Selected)
                    selected.Add(li);
            }

            foreach (ListItem li in selected)
            {
                lstTo.Items.Add(li);
                lstFrom.Items.Remove(li);
            }
        }
    }
}