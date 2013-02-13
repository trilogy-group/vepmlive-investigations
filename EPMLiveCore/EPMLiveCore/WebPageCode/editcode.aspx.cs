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
    public partial class editcode : System.Web.UI.Page
    {
        protected Label lblError;
        protected TextBox txtName;
        protected TextBox txtDisplayName;
        protected DropDownList ddlCodeType;
        protected HiddenField hdnId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnId.Value = Request["id"].ToString();

                SPWeb web = SPContext.Current.Web;
                SPList list = web.Lists["EPMLiveOutlineCodes"];

                SPListItem li = list.Items[new Guid(hdnId.Value)];

                txtName.Text = li.Title;
                txtDisplayName.Text = li["DisplayName"].ToString();
                ddlCodeType.SelectedValue = li["OutlineCodeType"].ToString();
            }
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
            
            SPListItem li = list.Items[new Guid(hdnId.Value)];
            li["Title"] = txtName.Text;
            li["DisplayName"] = txtDisplayName.Text;
            li["OutlineCodeType"] = ddlCodeType.SelectedItem.Text;
            li.Update();

            string url = web.ServerRelativeUrl;

            Page.RegisterStartupScript("repost", "<script language=\"javascript\">opener.location.href='" + url + "/_layouts/epmlive/tpsetup.aspx';window.close();</script>");

        }

    }
}