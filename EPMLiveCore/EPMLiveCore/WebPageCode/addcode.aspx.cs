using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public partial class addcode : System.Web.UI.Page
    {
        protected Label lblError;
        protected TextBox txtName;
        protected TextBox txtDisplayName;
        protected DropDownList ddlCodeType;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            web.AllowUnsafeUpdates = true;

            if (txtName.Text == "")
            {
                lblError.Text = "You must enter a Field Name";
                lblError.Visible = true;
                return;
            }
            if (txtDisplayName.Text == "")
            {
                lblError.Text = "You must enter a Display Name";
                lblError.Visible = true;
                return;
            }

            SPList list = web.Lists["EPMLiveOutlineCodes"];
            ArrayList arrCodes = new ArrayList();
            foreach (SPListItem li in list.Items)
            {
                arrCodes.Add(li.Title + ";#" + li["OutlineCodeType"].ToString());
            }

            if (!arrCodes.Contains(txtName.Text + ";#" + ddlCodeType.SelectedItem.Text))
            {
                SPListItem li = list.Items.Add();
                li["Title"] = txtName.Text;
                li["DisplayName"] = txtDisplayName.Text;
                li["OutlineCodeType"] = ddlCodeType.SelectedItem.Text;
                li.Update();
            }

            string url = web.ServerRelativeUrl;

            Page.RegisterStartupScript("repost", "<script language=\"javascript\">opener.location.href='" + url + "/_layouts/epmlive/tpsetup.aspx';window.close();</script>");

        }

    }
}