using System;

namespace EPMLiveCore
{
    public partial class CascadingLookupFieldControl
    {
        private void ClearError()
        {
            lblError.Text = string.Empty;
            lblError.Visible = false;
            ddlCLField.Visible = true;
        }

        private void ReportError(Exception ex)
        {
            ReportError(ex, "ms-alerttext");
        }

        private void ReportError(Exception ex, string CssClass)
        {
            lblError.CssClass = CssClass;
            lblError.Text = ex.Message;
            lblError.Visible = true;
            ddlCLField.Visible = false;
        }
    }
}