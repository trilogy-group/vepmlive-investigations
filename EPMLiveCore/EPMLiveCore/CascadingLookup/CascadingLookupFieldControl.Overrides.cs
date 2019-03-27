using System;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class CascadingLookupFieldControl
    {
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
                return "NULL ddlCLField";
            }

            // CC-78270 This is a setter that does not use the passed value,
            // perhaps a bug?
            set
            {
                EnsureChildControls();

                if (ddlCLField != null)
                {
                    var item = ddlCLField.Items.FindByValue((string)ItemFieldValue);

                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        public override void Focus()
        {
            EnsureChildControls();
            ddlCLField.Focus();
        }

        protected override void CreateChildControls()
        {
            try
            {
                if (Field == null)
                {
                    return;
                }
                base.CreateChildControls();
                if (ControlMode == SPControlMode.Display)
                {
                    return;
                }

                lblError = (Label)TemplateContainer.FindControl("lblError");
                if (lblError != null)
                {
                    lblError.Visible = false;
                    lblError.ID = lblErrorID;
                }

                ddlCLField = (DropDownList)TemplateContainer.FindControl("ddlCLField");
                if (ddlCLField == null)
                {
                    throw new ArgumentNullException("ddlCLField control is null. Please contact Administrator.");
                }

                ddlCLField.ID = Field.InternalName;
                ddlCLField.TabIndex = TabIndex;
                ddlCLField.CssClass = CssClass;
                ddlCLField.ToolTip = Field.Title;

                strUrl = GetProperty("Url");
                strList = GetProperty("List");
                strField = GetProperty("Field");
                strParentField = GetProperty("ParentField");
                strChildrenField = GetProperty("ChildrenField");
                strFilterValueField = GetProperty("FilterValueField");
                strDefineNone = GetProperty("DefineNone");

                strUrl = CascadingLookupFieldSettings.FindRelativeUrl(strUrl, SPContext.Current);

                if (!string.IsNullOrWhiteSpace(strChildrenField))
                {
                    ddlCLField.AutoPostBack = true;
                    ddlCLField.SelectedIndexChanged += ddlCLField_SelectedIndexChanged;
                }

                PopulateDropdown();
            }
            catch (Exception ex)
            {
                ReportError(ex);
            }
        }
    }
}