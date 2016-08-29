using System;
using System.Runtime.InteropServices;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EPMLiveCore
{
    [Guid("be21a5b1-b558-4a06-96fb-06230d47ff09")]
    public class CascadingLookupFieldControl : Microsoft.SharePoint.WebControls.BaseFieldControl
    {
        #region Local Declarations
        DropDownList ddlCLField;
        Label lblError;

        private string strUrl;
        private string strList;
        private string strField;
        private string strParentField;
        private string strChildrenField;
        private string strFilterValueField;
        private string strDefineNone;

        private string lblErrorID
        {
            get
            {
                return "lblError_" + this.Field.InternalName;
            }
        }
        #endregion

        protected override string DefaultTemplateName
        {
            get { return "CascadingLookupFieldControl"; }
        }

        public override object Value
        {
            get
            {
                EnsureChildControls();

                if (ddlCLField != null)
                {
                    try
                    {
                        return ddlCLField.SelectedValue;
                    }
                    catch
                    {
                        return "ERROR ddlCLField";
                    }
                }
                else
                {
                    return "NULL ddlCLField";
                }
            }
            set
            {
                EnsureChildControls();

                if (ddlCLField != null)
                {
                    ListItem item = ddlCLField.Items.FindByValue((string)this.ItemFieldValue);

                    if (item != null)
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        // Show Some Error...
                    }
                }
            }
        }

        public override void Focus()
        {
            EnsureChildControls();
            ddlCLField.Focus();
        }

        public static Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
            {
                return Root;
            }

            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)
                {
                    return FoundCtl;
                }
            }

            return null;
        }

        protected override void CreateChildControls()
        {
            try
            {
                if (Field == null) return;
                base.CreateChildControls();
                if (ControlMode == SPControlMode.Display) return;

                lblError = (Label)this.TemplateContainer.FindControl("lblError");
                if (lblError != null)
                {
                    lblError.Visible = false;
                    lblError.ID = lblErrorID;
                }

                ddlCLField = (DropDownList)this.TemplateContainer.FindControl("ddlCLField");
                if (ddlCLField == null)
                {
                    throw new ArgumentNullException("ddlCLField control is null. Please contact Administrator.");
                }

                ddlCLField.ID = Field.InternalName;
                ddlCLField.TabIndex = this.TabIndex;
                ddlCLField.CssClass = this.CssClass;
                ddlCLField.ToolTip = Field.Title;

                strUrl = (Field.GetCustomProperty("Url") != null) ? Field.GetCustomProperty("Url").ToString() : "";
                strList = (Field.GetCustomProperty("List") != null) ? Field.GetCustomProperty("List").ToString() : "";
                strField = (Field.GetCustomProperty("Field") != null) ? Field.GetCustomProperty("Field").ToString() : "";
                strParentField = (Field.GetCustomProperty("ParentField") != null) ? Field.GetCustomProperty("ParentField").ToString() : "";
                strChildrenField = (Field.GetCustomProperty("ChildrenField") != null) ? Field.GetCustomProperty("ChildrenField").ToString() : "";
                strFilterValueField = (Field.GetCustomProperty("FilterValueField") != null) ? Field.GetCustomProperty("FilterValueField").ToString() : "";
                strDefineNone = (Field.GetCustomProperty("DefineNone") != null) ? Field.GetCustomProperty("DefineNone").ToString() : "";

                strUrl = CascadingLookupFieldSettings.FindRelativeUrl(strUrl, SPContext.Current);

                if (!string.IsNullOrEmpty(strChildrenField))
                {
                    ddlCLField.AutoPostBack = true;
                    ddlCLField.SelectedIndexChanged += new EventHandler(ddlCLField_SelectedIndexChanged);
                }

                PopulateDropdown();
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        void PopulateDropdown()
        {
            EnsureChildControls();

            try
            {
                ClearError();

                if (string.IsNullOrEmpty(strFilterValueField))
                {
                    SPQuery query = BuildQuery(strField, strParentField, strFilterValueField, "");
                    SPListItemCollection queryResults = ExecuteQuery(strUrl, strList, strField, query);
                    if (queryResults != null)
                    {
                        BindDDL(this, queryResults.GetDataTable(), strField);
                    }
                }
                else
                {
                    DropDownList ddlFilterValueField = (DropDownList)FindControlRecursive(this.Page, strFilterValueField);
                    SPQuery query = BuildQuery(strField, strParentField, strFilterValueField, ddlFilterValueField.SelectedValue);
                    SPListItemCollection queryResults = ExecuteQuery(strUrl, strList, strField, query);
                    if (queryResults != null)
                    {
                        BindDDL(this, queryResults.GetDataTable(), strField);
                    }
                }
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        void ddlCLField_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnsureChildControls();

            try
            {
                ClearError();

                if (!string.IsNullOrEmpty(strChildrenField))
                {
                    UpdateChildren(strChildrenField);
                }
            }
            catch(Exception ex)
            {
                ReportError(ex);
            }
        }

        void UpdateChildren(string ChildrenField)
        {
            string[] children = ChildrenField.Split(new string[] { "] " }, StringSplitOptions.RemoveEmptyEntries);

            Control control;
            foreach (string child in children)
            {
                control = FindControlRecursive(this.Page, child);
                if (control != null)
                {
                    CascadingLookupFieldControl childField = (CascadingLookupFieldControl)control.Parent.Parent;
                    if (childField != null)
                    {
                        control = FindControlRecursive(this.Page, childField.strFilterValueField);
                        if (control != null)
                        {
                            DropDownList ddlFilterValueField = (DropDownList)control;
                            PopulateChild(childField, ddlFilterValueField.SelectedValue);

                            if (!string.IsNullOrEmpty(childField.strChildrenField))
                            {
                                UpdateChildren(childField.strChildrenField);
                            }
                        }
                    }
                }
            }
        }

        void PopulateChild(CascadingLookupFieldControl field, string filterValue)
        {
            SPQuery query = BuildQuery(field.strField, field.strParentField, field.strFilterValueField, filterValue);
            SPListItemCollection queryResults = ExecuteQuery(field.strUrl, field.strList, field.strField, query);
            if (queryResults != null)
            {
                BindDDL(field, queryResults.GetDataTable(), field.strField);
            }
        }

        #region Supporting Functions
        private SPQuery BuildQuery(string field, string parentField, string filterValueField, string filterValue)
        {
            SPQuery query = new SPQuery();
            string caml = "";

            if (string.IsNullOrEmpty(parentField) || string.IsNullOrEmpty(filterValueField))
            {
                caml = @"<ViewFields><FieldRef Name='{0}' /></ViewFields><OrderBy><FieldRef Name='{0}' /></OrderBy>";
                query.Query = string.Format(caml, field);
            }
            else
            {
                caml = @"<ViewFields><FieldRef Name='{0}' /><FieldRef Name='{1}' /></ViewFields><OrderBy><FieldRef Name='{0}' /></OrderBy><Where><Eq><FieldRef Name='{1}' /><Value Type='Text'>{2}</Value></Eq></Where>";
                query.Query = string.Format(caml, field, parentField, filterValue);
            }

            return query;
        }

        private SPListItemCollection ExecuteQuery(string url, string list, string field, SPQuery query)
        {
            try
            {
                using(SPSite site = new SPSite(url))
                {
                    using(SPWeb spWeb = site.OpenWeb())
                    {
                        if(spWeb.Url != url)
                        {
                            throw new Exception("Configuration Error (Url). Please contact Administrator.");
                        }

                        SPList objList;
                        try
                        {
                            objList = spWeb.Lists[list];
                        }
                        catch
                        {
                            throw new Exception("Configuration Error (List). Please contact Administrator.");
                        }

                        try
                        {
                            SPField objField = objList.Fields.GetFieldByInternalName(field);
                        }
                        catch
                        {
                            throw new Exception("Configuration Error (Field). Please contact Administrator.");
                        }

                        SPListItemCollection resultItems = objList.GetItems(query);

                        return resultItems;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void InitializeDDL(DropDownList ddl, string defineNone)
        {
            ddl.Items.Clear();

            try
            {
                if (Convert.ToBoolean(defineNone))
                {
                    ddl.Items.Add(new ListItem("[Select One...]", ""));
                }
            }
            catch
            {
            }
        }

        private void EnsureDDLHasValues(CascadingLookupFieldControl field)
        {
            try
            {
                field.ClearError();

                int minItems = 0;
                try
                {
                    minItems = (Convert.ToBoolean(field.strDefineNone)) ? 1 : 0;
                }
                catch
                {
                }

                if (field.ddlCLField.Items.Count <= minItems)
                {
                    throw new Exception("No lookup results present.");
                }
            }
            catch (Exception ex)
            {
                field.ReportError(ex, "");
            }
        }

        private void BindDDL(CascadingLookupFieldControl field, DataTable dtItems, string FieldName)
        {
            InitializeDDL(field.ddlCLField, field.strDefineNone);

            if (dtItems != null)
            {
                DataTable dtResults = dtItems.DefaultView.ToTable(true, FieldName);
                BindDDL(field, dtResults.Select(), FieldName);
            }

            EnsureDDLHasValues(field);
        }

        private void BindDDL(CascadingLookupFieldControl field, DataRow[] drRows, string FieldName)
        {
            InitializeDDL(field.ddlCLField, field.strDefineNone);

            if (drRows != null)
            {
                foreach (DataRow dr in drRows)
                {
                    if (field.ddlCLField.Items.FindByValue(dr[FieldName].ToString()) == null)
                        field.ddlCLField.Items.Add(new ListItem(dr[FieldName].ToString(), dr[FieldName].ToString()));
                }
            }

            EnsureDDLHasValues(field);
        }
        #endregion

        #region Error Handling Functions
        private void ClearError()
        {
            lblError.Text = "";
            lblError.Visible = false;
            ddlCLField.Visible = true;
        }

        private void ReportError(Exception ex)
        {
            ReportError (ex, "ms-alerttext");
        }

        private void ReportError(Exception ex, string CssClass)
        {
            lblError.CssClass = CssClass;
            lblError.Text = ex.Message;
            lblError.Visible = true;
            ddlCLField.Visible = false;
        }
        #endregion
    }
}
