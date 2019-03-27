using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    [Guid("be21a5b1-b558-4a06-96fb-06230d47ff09")]
    public partial class CascadingLookupFieldControl : BaseFieldControl
    {
        public static Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
            {
                return Root;
            }
            foreach (Control control in Root.Controls)
            {
                var found = FindControlRecursive(control, Id);
                if (found != null)
                {
                    return found;
                }
            }
            return null;
        }

        private string GetProperty(string propertyName)
        {
            var customProperty = Field.GetCustomProperty(propertyName);
            return customProperty != null
                ? customProperty.ToString()
                : string.Empty;
        }

        private DropDownList ddlCLField;
        private Label lblError;
        private string strUrl;
        private string strList;
        private string strField;
        private string strParentField;
        private string strChildrenField;
        private string strFilterValueField;
        private string strDefineNone;

        private string lblErrorID
        {
            get { return string.Format("lblError_{0}", Field.InternalName); }
        }
    }
}