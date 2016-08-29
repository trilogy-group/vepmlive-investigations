using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace EPMLiveCore
{
    public class FieldSynchPage : LayoutsPageBase
    {
        private SPWeb oFromWeb;
        private SPList oFromList;
        private SPField fldFromField;
        private SPList currentList;
        protected TextBox txtToList;
        protected SPGridView GvFields;
        protected Label lblListName;
        protected Button btnSynchronize = new Button();
        protected Button Cancel = new Button();
        private string sResults = "";
        private string sLeftPadding = "";
        protected Label lblResult;
        protected CheckBox chkCreateNewList;
        protected Panel pnlResults;

        protected override void OnLoad(EventArgs e)
        {
            this.Title = "Synchronize Fields";
            lblListName.Text = this.CurrentList.Title;
            txtToList.Text = this.CurrentList.Title;

            if (!Page.IsPostBack)
            {
                ListFields();
            }
        }

        protected void GvFields_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSync = (CheckBox)e.Row.FindControl("chkSync");
                CheckBox chkSeal = (CheckBox)e.Row.FindControl("chkSeal");

                if (DataBinder.Eval(e.Row.DataItem, "Synch").ToString() == "True" || DataBinder.Eval(e.Row.DataItem, "Synch").ToString() == "")
                    chkSync.Checked = true;
                if (DataBinder.Eval(e.Row.DataItem, "Seal").ToString() == "True" || DataBinder.Eval(e.Row.DataItem, "Seal").ToString() == "")
                    chkSeal.Checked = true;

                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;

            }

        }
        private void ListFields()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("InternalName");
            dt.Columns.Add("Synch");
            dt.Columns.Add("Seal");

            int cntFields = 0;

            foreach (SPField fld in this.CurrentList.Fields)
            {
                if (!fld.Sealed && fld.Type != SPFieldType.Attachments && fld.InternalName != "Order" && fld.Type != SPFieldType.File && fld.InternalName != "MetaInfo" && (!fld.ReadOnlyField || fld.Type == SPFieldType.Calculated))
                {
                    dt.Rows.Add(new string[] { fld.Title, fld.InternalName, "True", "False" });
                }

                cntFields++;
            }

            lblResult.Height = cntFields * 16;
            GvFields.PageSize = cntFields;
            GvFields.DataSource = dt;
            GvFields.DataBind();

        }

        protected SPList CurrentList
        {
            get
            {
                if (currentList == null)
                    currentList = SPContext.Current.Web.Lists[new Guid(Request.QueryString["List"])];

                return currentList;
            }
        }

        protected void btnSynchronize_Click(object sender, EventArgs e)
        {
            oFromWeb = SPContext.Current.Web;
            oFromList = this.CurrentList;
            string sListName;
            if (txtToList.Text.Trim() == "")
            {
                sListName = CurrentList.Title;
            }
            else
            {
                sListName = txtToList.Text;
            }

            foreach (SPWeb subWeb in SPContext.Current.Web.Webs)
            {
                try
                {
                    SyncFieldRecursive(subWeb, sListName);
                }
                catch { }
                subWeb.Close();
                subWeb.Dispose();
            }

            lblResult.Text = "Synchronization results:<br><br>" + sResults;
            pnlResults.Visible = true;
            GvFields.Visible = false;

            
        }

        protected void SyncFieldRecursive(SPWeb webTo, string sListName)
        {
            try
            {
                sResults += sLeftPadding + "Website: " + webTo.Name + "<br>";
                SPList oToList = null;
                try
                {
                    oToList = webTo.Lists[sListName] as SPList;
                }
                catch
                {
                    if (chkCreateNewList.Checked)
                    {
                        webTo.Lists.Add(sListName, oFromList.Description, oFromList.BaseTemplate);
                        webTo.Update();
                        oToList = webTo.Lists[sListName] as SPList;
                    }
                }

                if (oToList != null)
                {
                    string sFldName = "";

                    // Select the checkboxes from the GridView control
                    for (int i = 0; i < GvFields.Rows.Count; i++)
                    {
                        GridViewRow row = GvFields.Rows[i];
                        bool isSyncChecked = ((CheckBox)row.FindControl("chkSync")).Checked;
                        if (isSyncChecked)
                        {

                            bool isSealChecked = ((CheckBox)row.FindControl("chkSeal")).Checked;

                            sFldName = GvFields.DataKeys[i]["InternalName"].ToString();

                            fldFromField = oFromList.Fields.GetFieldByInternalName(sFldName);
                            SPField fldToTest = null;
                            try
                            {
                                fldToTest = oToList.Fields.GetFieldByInternalName(sFldName);
                                if (fldFromField.Type == fldToTest.Type)
                                {
                                    Boolean bIsUpdatable;
                                    if (!fldToTest.Sealed)
                                    {
                                        bIsUpdatable = true;
                                    }
                                    else if (fldToTest.Sealed & fldToTest.Type.ToString() != "User")
                                    {
                                        fldToTest.Sealed = false;
                                        bIsUpdatable = true;
                                    }
                                    else
                                    {
                                        bIsUpdatable = false;
                                    }

                                    if (bIsUpdatable)
                                    {
                                        fldToTest.SchemaXml = fldFromField.SchemaXml.Replace(oFromList.ID.ToString(), oToList.ID.ToString());
                                        fldToTest.DefaultValue = fldFromField.DefaultValue;
                                        if (fldFromField.Type == SPFieldType.Lookup)
                                        {
                                            string sTopListId = getFieldSchemaAttribValue(fldFromField.SchemaXml, "List");
                                            string sSubListId = "";
                                            try
                                            {
                                                sSubListId = webTo.Lists[oFromWeb.Lists[new Guid(sTopListId)].Title].ID.ToString();
                                            }
                                            catch { }
                                            fldToTest.SchemaXml = fldFromField.SchemaXml.Replace(sTopListId, "{" + sSubListId + "}");
                                        }

                                        fldToTest.Update();

                                        if (fldToTest.Type.ToString() != "User" && fldToTest.InternalName != "Title")
                                        {
                                            fldToTest.Sealed = isSealChecked;
                                        }
                                    }
                                    else
                                    {
                                        sResults += sLeftPadding + " Failed: the field " + sFldName + " of type '" + fldToTest.Type.ToString() + "' already exists in list " + oToList.Title + "<br>";
                                    }
                                }
                                else
                                {
                                    sResults += sLeftPadding + " - Failed: the field '" + sFldName + "' already exists in list " + oToList.Title + ".<br>";
                                    sResults += sLeftPadding + "           This field is of a different type (" + fldToTest.Type.ToString() + ") than <br>";
                                    sResults += sLeftPadding + "           the field being copied, which is of type " + fldFromField.Type.ToString() + ".<br>";
                                }

                            }
                            catch (Exception exc)
                            {
                                if ((fldToTest == null || fldToTest.InternalName != "Title") & exc.GetType().FullName == "System.ArgumentException")
                                {
                                    oToList.Fields.Add(fldFromField);
                                    //webTo.Update();
                                    SPField fldNewField = oToList.Fields.GetFieldByInternalName(sFldName);
                                    fldNewField.SchemaXml = fldFromField.SchemaXml.Replace(oFromList.ID.ToString(), oToList.ID.ToString());
                                    if (fldFromField.Type == SPFieldType.Lookup)
                                    {
                                        string sTopListId = getFieldSchemaAttribValue(fldFromField.SchemaXml, "List");
                                        string sSubListId = "";
                                        try
                                        {
                                            sSubListId = webTo.Lists[oFromWeb.Lists[new Guid(sTopListId)].Title].ID.ToString();
                                        }
                                        catch{}
                                        fldNewField.SchemaXml = fldFromField.SchemaXml.Replace(sTopListId, "{" + sSubListId + "}");
                                    }
                                    //fldNewField.Update();
                                    fldNewField.Sealed = isSealChecked;
                                    webTo.Update();
                                    //sResults += sLeftPadding + " - field " + sFldName + " added to list " + oToList.Title + "\r";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                sResults += sLeftPadding + " - Error: " + exc.Message;
            }

            sLeftPadding += "   ";

            foreach (SPWeb w in webTo.Webs)
            {
                try
                {
                    SyncFieldRecursive(w, sListName);
                }
                catch { }
                w.Close();
                w.Dispose();
            }

            sLeftPadding = sLeftPadding.Substring(1, sLeftPadding.Length - 3);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("../../Templates/_layouts/listedit.aspx?List=" + this.CurrentList.ID);
        }

        private string getFieldSchemaAttribValue(string sStringToSearch, string sAttribName)
        {
            string sAttribVal = "";
            try
            {
                int iFindPos = sStringToSearch.ToUpper().IndexOf(sAttribName.ToUpper() + "=");
                int iSubStrStart = iFindPos + sAttribName.Length + 2;
                int iSubStrEnd = sStringToSearch.IndexOf("\"", iSubStrStart);
                sAttribVal = sStringToSearch.Substring(iSubStrStart, iSubStrEnd - iSubStrStart);
            }
            catch { }
            return sAttribVal;
        }

    }
}
