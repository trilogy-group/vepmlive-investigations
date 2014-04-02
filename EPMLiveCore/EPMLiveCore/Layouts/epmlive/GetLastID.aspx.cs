using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class GetLastID : LayoutsPageBase
    {
        protected string output = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sSource = Request["BackTo"];
                string sListId = Request["listid"];
                bool bDialog = false;
                if (Request["IsDlg"] == "1")
                    bDialog = true;

                SPList list = Web.Lists[new Guid(sListId)];

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Author'/><Value Type='Integer'><UserID/></Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='FALSE'/></OrderBy>";
                query.RowLimit = 1;

                SPListItem li = list.GetItems(query)[0];

                if (sSource == "close")
                    output = "<script>SP.SOD.execute('SP.UI.dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', 1, '" + li.ID + "');</script>";
                else
                    Response.Redirect(sSource + "?ID=" + li.ID + ((bDialog) ? "&isdlg=1" : ""));
            }
            catch (Exception ex) { output = "Error: " + ex.Message; }
        }
    }
}
