using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    class TotalsRollupFieldControl : BaseFieldControl
    {

        protected override void RenderFieldForDisplay(System.Web.UI.HtmlTextWriter output)
        {
            output.Write(base.Field.GetFieldValueAsText(ListItemFieldValue));
        }
    }
}
