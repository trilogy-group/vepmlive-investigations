using System;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    [Guid("A18AFF50-0D2B-48b0-9C51-157202C3E59F")]
    public class CascadingLookupFieldSettings : System.Web.UI.UserControl, Microsoft.SharePoint.WebControls.IFieldEditor
    {
        #region Local Declarations
        protected Label lblUrl;
        protected Label lblList;
        protected Label lblField;
        protected Label lblParentField;
        protected Label lblFilterValueField;
        protected Label lblError;

        protected TextBox txtUrl;
        protected Button btnLoad;
        protected DropDownList ddlList;
        protected DropDownList ddlField;
        protected DropDownList ddlParentField;
        protected DropDownList ddlFilterValueField;

        protected CheckBox chkFilterCriteria;
        protected CheckBox chkDefineNone;

        private string Url = default(string);
        private string List = default(string);
        private string Field = default(string);
        private string ParentField = default(string);
        private string ChildrenField = default(string);
        private string FilterValueField = default(string);
        private string DefineNone = default(string);
        #endregion

        #region IFieldEditor Members
        public bool DisplayAsNewSection
        {
            get { return true; }
        }

        public void InitializeWithField(Microsoft.SharePoint.SPField field)
        {
            CascadingLookupField clField = field as CascadingLookupField;
            if (clField != null)
            {
                this.Url = clField.Url;
                this.List = clField.List;
                this.Field = clField.Field;
                this.ParentField = clField.ParentField;
                this.ChildrenField = clField.ChildrenField;
                this.FilterValueField = clField.FilterValueField;
                this.DefineNone = clField.DefineNone;

                EnsureChildControls();

                // Remove the current field from the FilterValueField list
                ListItem item = ddlFilterValueField.Items.FindByValue(field.InternalName);
                if (item != null)
                    ddlFilterValueField.Items.Remove(item);
            }
        }

        public void OnSaveChange(Microsoft.SharePoint.SPField field, bool isNewField)
        {
            ValidateSettings();

            this.Url = txtUrl.Text.Trim();
            this.List = (ddlList.SelectedIndex > 0) ? ddlList.SelectedValue : "";
            this.Field = (ddlField.SelectedIndex > 0) ? ddlField.SelectedValue : "";
            this.ParentField = (ddlParentField.SelectedIndex > 0) ? ddlParentField.SelectedValue : "";
            this.FilterValueField = (ddlFilterValueField.SelectedIndex > 0) ? ddlFilterValueField.SelectedValue : "";
            this.DefineNone = chkDefineNone.Checked.ToString();

            if (chkFilterCriteria.Checked)
            {
                if (!string.IsNullOrEmpty((this.FilterValueField)))
                {
                    SPField parentField = field.ParentList.Fields.GetFieldByInternalName(this.FilterValueField);

                    if (parentField != null)
                    {
                        CascadingLookupField clParentField = parentField as CascadingLookupField;

                        string childFieldName = ((isNewField) ? ConvertToInternalName(field.Title) : field.InternalName) + "] ";

                        if (!clParentField.ChildrenField.Contains(childFieldName))
                        {
                            clParentField.ChildrenField += childFieldName;
                            clParentField.Update();
                        }
                    }
                }
            }

            CascadingLookupField clField = field as CascadingLookupField;

            if (isNewField)
            {
                clField.UpdateMyCustomProperty("Url", this.Url);
                clField.UpdateMyCustomProperty("List", this.List);
                clField.UpdateMyCustomProperty("Field", this.Field);
                clField.UpdateMyCustomProperty("ParentField", this.ParentField);
                clField.UpdateMyCustomProperty("ChildrenField", this.ChildrenField);
                clField.UpdateMyCustomProperty("FilterValueField", this.FilterValueField);
                clField.UpdateMyCustomProperty("DefineNone", this.DefineNone);
            }
            else
            {
                clField.Url = this.Url;
                clField.List = this.List;
                clField.Field = this.Field;
                clField.ParentField = this.ParentField;
                clField.ChildrenField = CleanupChildrenField(field, this.ChildrenField);
                clField.FilterValueField = this.FilterValueField;
                clField.DefineNone = this.DefineNone;
            }
        }
        #endregion

        protected override void CreateChildControls()
        {
            try
            {
                base.CreateChildControls();

                ddlList.AutoPostBack = true;
                ddlField.AutoPostBack = true;
                chkFilterCriteria.AutoPostBack = true;

                ddlList.EnableViewState = true;
                ddlField.EnableViewState = true;
                ddlParentField.EnableViewState = true;
                ddlFilterValueField.EnableViewState = true;

                btnLoad.Click += new EventHandler(btnLoad_Click);
                ddlList.SelectedIndexChanged += new EventHandler(ddlList_SelectedIndexChanged);
                ddlField.SelectedIndexChanged += new EventHandler(ddlField_SelectedIndexChanged);
                chkFilterCriteria.CheckedChanged += new EventHandler(chkFilterCriteria_CheckedChanged);

                try
                {
                    chkDefineNone.Checked = Convert.ToBoolean(this.DefineNone);
                }
                catch
                {
                }

                if (!this.IsPostBack)
                {
                    WSSLoadFields(SPContext.Current.Fields, ddlFilterValueField, this.FilterValueField, this, true);

                    ShowList(false);
                    ShowField(false);
                    ShowFilterSettingsOption(false);
                    ShowFilterCriteria(false);

                    if (string.IsNullOrEmpty(this.Url))
                    {
                        txtUrl.Text = "Current";
                    }
                    else
                    {
                        txtUrl.Text = this.Url;
                    }

                    btnLoad_Click(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                ClearError();

                txtUrl.Text = txtUrl.Text.Trim();

                string sUrl = FindRelativeUrl(txtUrl.Text);

                WSSLoadLists(sUrl, ddlList, this.List, sender);

                ShowList(true);

                if (ddlList.SelectedIndex > 0)
                {
                    ddlList_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearError();

                ShowField((ddlList.SelectedIndex > 0) ? true : false);

                if (ddlList.SelectedIndex > 0)
                {
                    string sUrl = FindRelativeUrl(txtUrl.Text);

                    WSSLoadFields(sUrl, ddlList.SelectedValue, ddlField, this.Field, sender);
                    WSSLoadFields(sUrl, ddlList.SelectedValue, ddlParentField, this.ParentField, sender);

                    if (ddlField.SelectedIndex > 0)
                    {
                        ddlField_SelectedIndexChanged(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearError();

                ShowFilterSettingsOption((ddlField.SelectedIndex > 0) ? true : false);

                if (ddlField.SelectedIndex > 0)
                {
                    chkFilterCriteria_CheckedChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        void chkFilterCriteria_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ClearError();

                if (sender.GetType() == this.GetType())
                {
                    if ((!string.IsNullOrEmpty(this.ParentField)) || (!string.IsNullOrEmpty(this.FilterValueField)))
                    {
                        chkFilterCriteria.Checked = true;
                    }
                }

                ShowFilterCriteria(chkFilterCriteria.Checked);

                if (chkFilterCriteria.Checked)
                {
                    if (ddlField.SelectedIndex > 0)
                    {
                        string selectedValue = ddlParentField.SelectedValue;

                        ddlParentField.Items.Clear();

                        for (int i = 0; i < ddlField.Items.Count; i++)
                        {
                            if (i != ddlField.SelectedIndex)
                            {
                                ddlParentField.Items.Add(new ListItem(ddlField.Items[i].Text, ddlField.Items[i].Value));
                            }
                        }

                        if (ddlParentField.Items.Count == 1)
                        {
                            ddlParentField.Items.Clear();
                            throw new Exception("No usable Field present in the Parent List.");
                        }

                        if (ddlField.SelectedValue == selectedValue)
                        {
                            ddlParentField.Items[0].Selected = true;
                        }
                        else
                        {
                            UpdateDDLSelection(ddlParentField, selectedValue, "Invalid Field Name. Field does not exist in the Parent List.", sender);
                        }

                        if (ddlFilterValueField.Items.Count <= 0)
                        {
                            chkFilterCriteria.Checked = false;
                            ShowFilterCriteria(chkFilterCriteria.Checked);
                            throw new Exception("This list does not have any Cascading Lookup Field defined. Please define one and try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }

        private void ValidateSettings()
        {
            if (!chkFilterCriteria.Checked)
            {
                if (ddlParentField.Items.Count > 0)
                {
                    ddlParentField.Items[0].Selected = true;
                }

                if (ddlFilterValueField.Items.Count > 0)
                {
                    ddlFilterValueField.Items[0].Selected = true;
                }
            }
        }

        #region Error Handling Functions
        private void ClearError()
        {
            lblError.Text = "";
            lblError.Visible = false;
        }

        private void ReportError(Exception ex)
        {
            string errorMessage;

            string strFormat = "<b>Current Configuration</b><br />Site Url : {0}<br />List Name : {1}<br />Field Name (Internal) : {2}<br />Parent Field Name (Internal) : {3}<br />Field Value Field Name (Internal) : {4}";
            string oldConfiguration = string.Format(strFormat, this.Url, this.List, this.Field, this.ParentField, this.FilterValueField);

            if (oldConfiguration.Length > strFormat.Length)
            {
                errorMessage = ex.Message + "<br />" + oldConfiguration;
            }
            else
            {
                errorMessage = ex.Message;
            }

            lblError.Text = errorMessage;
            lblError.Visible = true;
        }
        #endregion

        #region Supporting Functions
        private void WSSLoadLists(string Url, DropDownList ddl, string selectedValue, object sender)
        {
            ddl.Items.Clear();
            ddl.Items.Add("[Select List]");

            using(SPSite site = new SPSite(Url))
            {
                using(SPWeb spWeb = site.OpenWeb())
                {
                    if(string.Compare(spWeb.Url, Url, true) == 0)
                    {
                        foreach(SPList list in spWeb.Lists)
                        {
                            if(!list.Hidden)
                            {
                                ddl.Items.Add(list.Title);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid Site Url. Site does not exist.");
                    }
                }
            }
            if (ddl.Items.Count == 1)
            {
                ddl.Items.Clear();
                throw new Exception("No Generic List present on the Site Url.");
            }

            UpdateDDLSelection(ddl, selectedValue, "Invalid List Name. List does not exist.", sender);
        }

        private void WSSLoadFields(SPFieldCollection fields, DropDownList ddl, string selectedValue, object sender, bool allowCustomFieldTypeOnly)
        {
            ddl.Items.Clear();
            ddl.Items.Add("[Select Field]");

            foreach (SPField field in fields)
            {
                if (allowCustomFieldTypeOnly)
                {
                    if (field.TypeAsString == "CascadingLookupField")
                    {
                        ddl.Items.Add(new ListItem(field.Title, field.InternalName));
                    }
                }
                else
                {
                    switch (field.Type)
                    {
                        case SPFieldType.Choice:
                        case SPFieldType.MultiChoice:
                        case SPFieldType.Currency:
                        case SPFieldType.DateTime:
                        case SPFieldType.Integer:
                        case SPFieldType.Number:
                        case SPFieldType.Text:
                        case SPFieldType.Note:
                        case SPFieldType.URL:
                        case SPFieldType.Lookup:
                        case SPFieldType.Invalid:
                            ddl.Items.Add(new ListItem(field.Title, field.InternalName));
                            break;

                        default:
                            break;
                    }
                }
            }

            if (ddl.Items.Count == 1)
            {
                ddl.Items.Clear();

                if (!allowCustomFieldTypeOnly)
                {
                    throw new Exception("No usable Field present in the List.");
                }
            }

            UpdateDDLSelection(ddl, selectedValue, "Invalid Field Name. Field does not exist.", sender);
        }

        private void WSSLoadFields(string Url, string List, DropDownList ddl, string selectedValue, object sender)
        {
            using(SPSite site = new SPSite(Url))
            {
                using (SPWeb spWeb = site.OpenWeb())
                {
                    WSSLoadFields(spWeb.Lists[List].Fields, ddl, selectedValue, sender, false);
                }
            }
        }

        private void UpdateDDLSelection(DropDownList ddl, string selectedValue, string messageOnError, object sender)
        {
            if (sender.GetType() == this.GetType())
            {
                if (!string.IsNullOrEmpty(selectedValue))
                {
                    ListItem item = ddl.Items.FindByValue(selectedValue);
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        ddl.Items[0].Selected = true;
                        throw new Exception(messageOnError);
                    }
                }
            }
        }

        private string CleanupChildrenField(SPField field, string childrenField)
        {
            string newChildrenField = "";
            string[] children = childrenField.Split(new string[] { "] " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string child in children)
            {
                try
                {
                    SPField childField = field.ParentList.Fields.GetFieldByInternalName(child);
                    newChildrenField += child + "] ";
                }
                catch
                {
                }
            }

            return newChildrenField;
        }

        private string ConvertToInternalName(string Name)
        {
            string internalName = ConvertSpecialColumnNameCharacters(Name);
            return (internalName.Length > 32) ? internalName.Substring(0, 32) : internalName;
        }

        private string ConvertSpecialColumnNameCharacters(string stringToConvert)
        {
            stringToConvert = stringToConvert.Replace("~", "_x007e_");
            stringToConvert = stringToConvert.Replace("!", "_x0021_");
            stringToConvert = stringToConvert.Replace("@", "_x0040_");
            stringToConvert = stringToConvert.Replace("#", "_x0023_");
            stringToConvert = stringToConvert.Replace("$", "_x0024_");
            stringToConvert = stringToConvert.Replace("%", "_x0025_");
            stringToConvert = stringToConvert.Replace("^", "_x005e_");
            stringToConvert = stringToConvert.Replace("&", "_x0026_");
            stringToConvert = stringToConvert.Replace("*", "_x002a_");
            stringToConvert = stringToConvert.Replace("(", "_x0028_");
            stringToConvert = stringToConvert.Replace(")", "_x0029_");
            stringToConvert = stringToConvert.Replace("_", "_x005F_");
            stringToConvert = stringToConvert.Replace("+", "_x002b_");
            stringToConvert = stringToConvert.Replace("-", "_x002d_");
            stringToConvert = stringToConvert.Replace("=", "_x003d_");
            stringToConvert = stringToConvert.Replace("{", "_x007b_");
            stringToConvert = stringToConvert.Replace("}", "_x007d_");
            stringToConvert = stringToConvert.Replace(":", "_x003a_");
            stringToConvert = stringToConvert.Replace("“", "_x0022_");
            stringToConvert = stringToConvert.Replace("|", "_x007c_");
            stringToConvert = stringToConvert.Replace(";", "_x003b_");
            stringToConvert = stringToConvert.Replace("‘", "_x0027_");
            stringToConvert = stringToConvert.Replace("\\", "_x005c_");
            stringToConvert = stringToConvert.Replace("<", "_x003c_");
            stringToConvert = stringToConvert.Replace(">", "_x003e_");
            stringToConvert = stringToConvert.Replace("?", "_x003f_");
            stringToConvert = stringToConvert.Replace(",", "_x002c_");
            stringToConvert = stringToConvert.Replace(".", "_x002e_");
            stringToConvert = stringToConvert.Replace("/", "_x002f_");
            stringToConvert = stringToConvert.Replace("`", "_x0060_");
            stringToConvert = stringToConvert.Replace(" ", "_x0020_");
            return stringToConvert;
        }

        internal static bool IsRelativeUrl(string Url)
        {
            if (string.Compare(Url, "Current", true) == 0)
                return true;

            if (string.Compare(Url, "Top", true) == 0)
                return true;

            if (Url.ToLower().StartsWith("parent"))
            {
                string[] dividers = Url.ToLower().Split(new string[] { "parent", "." }, StringSplitOptions.RemoveEmptyEntries);
                if (dividers.Length == 0)
                    return true;
            }

            return false;
        }

        private string FindRelativeUrl(string Url)
        {
            return FindRelativeUrl(Url, SPContext.Current);
        }

        internal static string FindRelativeUrl(string Url, SPContext CurrentContext)
        {
            if (IsRelativeUrl(Url))
            {
                if (string.Compare(Url, "Current", true) == 0)
                    return CurrentContext.Web.Url;

                if (string.Compare(Url, "Top", true) == 0)
                    return CurrentContext.Site.RootWeb.Url;

                if (Url.ToLower().StartsWith("parent"))
                {
                    try
                    {
                        string[] dividers = Url.ToLower().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

                        SPWeb parentWeb = CurrentContext.Web;

                        foreach (string d in dividers)
                        {
                            parentWeb = parentWeb.ParentWeb;
                        }

                        return parentWeb.Url;
                    }
                    catch (NullReferenceException)
                    {
                        throw new Exception("Unable to find Relative Url. Workspace does not exist.");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to find Relative Url. " + ex.Message);
                    }
                }

                return Url;
            }
            else
            {
                return Url;
            }
        }
        #endregion

        #region Show Hide Functions
        private void ShowControl(bool isVisible, WebControl control)
        {
            control.Visible = isVisible;
        }

        private void ShowList(bool isVisible)
        {
            ShowControl(isVisible, lblList);
            ShowControl(isVisible, ddlList);
        }

        private void ShowField(bool isVisible)
        {
            ShowControl(isVisible, lblField);
            ShowControl(isVisible, ddlField);
        }

        private void ShowFilterSettingsOption(bool isVisible)
        {
            ShowControl(isVisible, chkFilterCriteria);
            ShowControl(isVisible, chkDefineNone);
        }

        private void ShowFilterCriteria(bool isVisible)
        {
            ShowControl(isVisible, lblParentField);
            ShowControl(isVisible, ddlParentField);

            ShowControl(isVisible, lblFilterValueField);
            ShowControl(isVisible, ddlFilterValueField);
        }
        #endregion
    }
}
