using System;
using System.Diagnostics;

namespace EPMLiveCore
{
    public partial class CascadingLookupFieldControl
    {
        private void ddlCLField_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnsureChildControls();
            try
            {
                ClearError();
                if (!string.IsNullOrWhiteSpace(strChildrenField))
                {
                    UpdateChildren(strChildrenField);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                ReportError(ex);
            }
        }
    }
}