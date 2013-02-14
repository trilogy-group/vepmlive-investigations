using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace TimeSheets
{
    [CLSCompliant(false)]
    [Guid("0e64d883-6ba1-441a-a119-dae6b5fe3f05")]
    public class WorkLogFieldControl : NumberField
    {
        protected HtmlAnchor lnkPopup;

        protected override string DefaultTemplateName
        {
            get { return "WorkLogFieldControl"; }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            if (ControlMode == SPControlMode.New)
                BuildRegret();

            if (ControlMode == SPControlMode.Edit) 
                BuildControl();
        }

        private void BuildControl()
        {
           AssociateEditControls();

           // Pass in itemId and listId
            lnkPopup.Attributes["onclick"] = string.Format(
                "javascript:openwindow('{0}/_layouts/epmlive/WorkLog.aspx?ListId={1}&ItemId={2}');return false;",
                SPContext.Current.Web.ServerRelativeUrl.TrimEnd('/'), ListId, ListItem.ID);
        }

        private void BuildRegret()
        {
            AssociateEditControls();
            lnkPopup.InnerText = "Hours cannot be added until the item has been created.";
        }

        // Associate child controls in the .ascx file with the fields allocated by this control.
        private void AssociateEditControls()
        {
            lnkPopup = (HtmlAnchor) TemplateContainer.FindControl("lnkPopup");
        }

        protected override void Render(HtmlTextWriter output)
        {
            //output.Write("888");
            base.Render(output);
        }            

        protected override void RenderFieldForDisplay(HtmlTextWriter output)
        {
            output.Write(@"<script language=""javascript"">
                function openwindow(wurl) {
                    function myCallback(dialogResult, returnValue) { }

                    var options = { url: wurl, width: 600, dialogReturnValueCallback: myCallback };

                    SP.UI.ModalDialog.showModalDialog(options);
                }
            </script>");

            var link = string.Format(
                "<a href='#' onclick=\"javascript:openwindow('{0}/_layouts/epmlive/WorkLog.aspx?ListId={1}&ItemId={2}');return false;\">Edit Hours</a>",
                SPContext.Current.Web.ServerRelativeUrl.TrimEnd('/'), ListId, ListItem.ID);
            output.Write(link);
            //base.RenderFieldForDisplay(output);
        }
    }
}