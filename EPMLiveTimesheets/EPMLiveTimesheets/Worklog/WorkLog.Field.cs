using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Security;
using System.Security;

namespace TimeSheets
{
    [CLSCompliant(false)]
    [Guid("833f1438-cd4d-4ff3-9b3a-8c2237ed6e79")]
    public class WorkLogField : SPFieldNumber
    {
        public WorkLogField(SPFieldCollection fields, string fieldName)
            : base(fields, fieldName)
        {
        }

        public WorkLogField(SPFieldCollection fields, string typeName, string displayName)
            : base(fields, typeName, displayName)
        {
        }

        public override string GetFieldValueAsHtml(object value)
        {
            //return string.Format(
            //    "javascript:window.open('{0}/_layouts/epmlive/WorkLog.aspx?ListId={1}&ItemId={2}','EPM','status=0,scrollbars=0,titlebar=0,resizable=1,toolbar=0,location=0,width=600,height=500');return false;",
            //    SPContext.Current.Web.ServerRelativeUrl.TrimEnd('/'), listId, listItem.ID);
            return "Edit";
        }

        public override BaseFieldControl FieldRenderingControl
        {
            [SecurityCritical]
            get
            {
                BaseFieldControl fieldControl = new WorkLogFieldControl();
                fieldControl.FieldName = this.InternalName;

                return fieldControl;
            }
        }
    }
}