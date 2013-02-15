using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class Pri_ComponentsForm : LayoutsPageBase
    {
        private List<int> c_components = null;
        public List<int> Components
        {
            get { return c_components; }
        }

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

                    lblMode.Text = "Prioritization Components";
                    btnSave.Visible = true;

                    string sDBConnect = WebAdmin.GetConnectionString(this.Context);
                    dba = new DBAccess(sDBConnect);
                    if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                    DataTable dt;

                    Dictionary<int, string> Fields = new Dictionary<int, string>();
                    ListItem liField;
                    if (dbaPrioritz.SelectComponentFields(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
                    foreach (DataRow row in dt.Rows)
                    {
                        int nFieldID = DBAccess.ReadIntValue(row["FA_FIELD_ID"]);
                        string sField = DBAccess.ReadStringValue(row["FA_NAME"]);
                        Fields.Add(nFieldID, sField);
                    }

                    string sFieldName;
                    if (dbaPrioritz.SelectComponents(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
                    foreach (DataRow row in dt.Rows)
                    {
                        int lFieldID = DBAccess.ReadIntValue(row["CC_COMPONENT"]);
                        if (Fields.TryGetValue(lFieldID, out sFieldName))
                        {
                            Fields.Remove(lFieldID);
                            ListItem listItem = new ListItem();
                            listItem.Value = lFieldID.ToString();
                            listItem.Text = sFieldName;
                            lstComponents.Items.Add(listItem);
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


            // Stick selected components into collection
            c_components = new List<int>();
            foreach (ListItem li in lstComponents.Items)
            {
                c_components.Add(Int32.Parse(li.Value));
            }

            string sDBConnect = WebAdmin.GetConnectionString(this.Context);
            dba = new DBAccess(sDBConnect);
            if (dba.Open() != StatusEnum.rsSuccess) goto Exit_Function;

            int lRowsAffected;
            if (dbaPrioritz.UpdateComponents(dba, this, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

            //ClientScript.RegisterStartupScript(this.GetType(), "CT_Script", "OnComponentsSavedOK();", true);
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
        }

        //protected void btnClose_Click(object sender, EventArgs e)
        //{
        //    // NB - this is how we get the popup to close when the save has occurred
        //    ClientScript.RegisterStartupScript(this.GetType(), "CT_Script", "OnComponentsClose();", true);
        //}

        protected void AddButton_Click(object sender, EventArgs e)
        {
            moveItems(lstFields, lstComponents);
        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            moveItems(lstComponents, lstFields);
        }

        protected void UpButton_Click(object sender, EventArgs e)
        {
            int listindex = lstComponents.SelectedIndex;
            if (listindex > 0)
            {
                ListItem li = lstComponents.Items[listindex];
                lstComponents.Items.RemoveAt(listindex);
                lstComponents.Items.Insert(listindex - 1, li);
            }
        }

        protected void DownButton_Click(object sender, EventArgs e)
        {
            int listindex = lstComponents.SelectedIndex;
            if (listindex >= 0 && listindex < lstComponents.Items.Count - 1)
            {
                ListItem li = lstComponents.Items[listindex];
                lstComponents.Items.RemoveAt(listindex);
                lstComponents.Items.Insert(listindex + 1, li);
            }
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