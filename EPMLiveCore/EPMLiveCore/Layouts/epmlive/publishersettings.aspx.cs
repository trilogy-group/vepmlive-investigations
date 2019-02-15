using System;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class publishersettings : LayoutsPageBase
    {

        protected static string url;
        protected Button Button1;

        protected DropDownList ddlPubType;
        protected CheckBox chkLockPublisher;
        protected DropDownList ddlSummary;
        protected DropDownList ddlTimePhased;

        protected DropDownList ddlSynchFields;
        protected DropDownList ddlPubStatus;
        protected DropDownList ddlResourceLink;

        protected CheckBox chkUseRes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SPWeb web = SPContext.Current.Web;
                {

                    web.Site.CatchAccessDeniedException = false;
                    web.AllowUnsafeUpdates = true;

                    Guid lWeb = CoreFunctions.getLockedWeb(web);

                    if(lWeb != web.ID)
                    {
                        pnlAdmin.Visible = true;
                        using(SPWeb w = web.Site.OpenWeb(lWeb))
                        {
                            hlAdmin.NavigateUrl = w.ServerRelativeUrl + "/_layouts/epmlive/publishersettings.aspx";
                        }
                        pnlMain.Visible = false;
                    }
                    else
                    {
                        if(CoreFunctions.getConfigSetting(web, "epmlivepub-lockpub") == "True")
                            chkLockPublisher.Checked = true;
                        else
                            chkLockPublisher.Checked = false;

                        ddlSummary.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLivePub-Summary");
                        ddlTimePhased.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLivePub-TP");
                        ddlPubType.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLivePub-Type");
                        ddlSynchFields.SelectedValue = CoreFunctions.getConfigSetting(web, "epmlivepub-synchfields");
                        ddlPubStatus.SelectedValue = CoreFunctions.getConfigSetting(web, "epmlivepub-pubstatus");
                        ddlResourceLink.SelectedValue = CoreFunctions.getConfigSetting(web, "epmlivepub-reslink");
                        try
                        {
                            chkUseRes.Checked = bool.Parse(CoreFunctions.getConfigSetting(web, "epmlivepub-useres"));
                        }
                        catch { }
                    }
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            web.AllowUnsafeUpdates = true;

            var locked = GetLocked(
                chkLockPublisher,
                ddlPubType,
                ddlSummary,
                ddlTimePhased,
                ddlPubStatus,
                ddlResourceLink,
                ddlSynchFields);

            CoreFunctions.setConfigSetting(web, "epmlivepub-lockpub", chkLockPublisher.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "epmlivepub-lock", locked);
            CoreFunctions.setConfigSetting(web, "EPMLivePub-Summary", ddlSummary.SelectedValue);
            CoreFunctions.setConfigSetting(web, "EPMLivePub-TP", ddlTimePhased.SelectedValue);
            CoreFunctions.setConfigSetting(web, "EPMLivePub-Type", ddlPubType.SelectedValue);
            CoreFunctions.setConfigSetting(web, "epmlivepub-pubstatus", ddlPubStatus.SelectedValue);
            CoreFunctions.setConfigSetting(web, "epmlivepub-reslink", ddlResourceLink.SelectedValue);
            CoreFunctions.setConfigSetting(web, "epmlivepub-synchfields", ddlSynchFields.SelectedValue);
            CoreFunctions.setConfigSetting(web, "epmlivepub-useres", chkUseRes.Checked.ToString());

            web.Update();

            string url = web.ServerRelativeUrl;

            if(!String.IsNullOrEmpty(Request["Source"]))
            {
                Response.Redirect(Request["Source"]);
            }
            else
            {
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("settings.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        public static string GetLocked(
            CheckBox lockPublisher,
            DropDownList pubType,
            DropDownList summary,
            DropDownList timePhased,
            DropDownList pubStatus,
            DropDownList resourceLink,
            DropDownList synchFields)
        {
            var locked = new StringBuilder();
            if (lockPublisher.Checked)
            {
                locked.Append(
                    !string.IsNullOrWhiteSpace(pubType?.SelectedValue)
                        ? "1"
                        : "0");

                locked.Append(
                    !string.IsNullOrWhiteSpace(summary?.SelectedValue)
                        ? ",1"
                        : ",0");

                locked.Append(
                    !string.IsNullOrWhiteSpace(timePhased?.SelectedValue)
                        ? ",1"
                        : ",0");

                locked.Append(
                    !string.IsNullOrWhiteSpace(pubStatus?.SelectedValue)
                        ? ",1"
                        : ",0");

                locked.Append(
                    !string.IsNullOrWhiteSpace(resourceLink?.SelectedValue)
                        ? ",1"
                        : ",0");

                locked.Append(
                    !string.IsNullOrWhiteSpace(synchFields?.SelectedValue)
                        ? ",1"
                        : ",0");
            }
            else
            {
                locked.Append("0,0,0,0,0,0");
            }
            return locked.ToString();
        }
    }
}
