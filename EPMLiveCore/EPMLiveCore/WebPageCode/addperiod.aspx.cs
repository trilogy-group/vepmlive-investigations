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
    public partial class addperiod : System.Web.UI.Page
    {

        protected Microsoft.SharePoint.WebControls.DateTimeControl calStart;
        protected Microsoft.SharePoint.WebControls.DateTimeControl calEnd;
        protected Label lblError;
        protected TextBox txtName;
        protected TextBox txtCapacity;

        protected void Page_Load(object sender, EventArgs e)
        {
            calStart.DatePickerFrameUrl = SPContext.Current.Web.Url + "/_layouts/iframe.aspx";
            calEnd.DatePickerFrameUrl = SPContext.Current.Web.Url + "/_layouts/iframe.aspx";
        }


        private void addWebPeriods(SPWeb web, string[] periods, string url)
        {
            try
            {
                web.AllowUnsafeUpdates = true;

                if (CoreFunctions.getConfigSetting(web, "EPMLiveTimePhasedURL").ToLower() == url.ToLower())
                {
                    SPList list = web.Lists["EPMLiveTimePhased"];
                    foreach (string period in periods)
                    {
                        try
                        {
                            SPField f = list.Fields.GetFieldByInternalName(period.Replace(" ", "_x0020_"));
                        }
                        catch
                        {
                            list.Fields.Add(period, SPFieldType.Number, false);
                        }
                    }
                }
            }
            catch { }
            foreach (SPWeb w in web.Webs)
            {
                try
                {
                    addWebPeriods(w, periods, url);
                }
                catch { }
                w.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            web.AllowUnsafeUpdates = true;

            if (txtName.Text == "")
            {
                lblError.Text = "You must enter a Period Name";
                lblError.Visible = true;
                return;
            }

            SPList list = web.Lists["EPMLivePeriods"];
            ArrayList arrPeriods = new ArrayList();
            foreach (SPListItem li in list.Items)
            {
                arrPeriods.Add(li.Title);
            }

            if (!arrPeriods.Contains(txtName.Text))
            {
                SPListItem li = list.Items.Add();
                li["Title"] = txtName.Text;
                li["StartDate"] = calStart.SelectedDate.ToShortDateString();
                li["EndDate"] = calEnd.SelectedDate.ToShortDateString();
                li["Capacity"] = txtCapacity.Text;
                li.Update();
                addWebPeriods(web, new string[] { txtName.Text }, web.Url);
            }

            string url = web.ServerRelativeUrl;

            Page.RegisterStartupScript("repost", "<script language=\"javascript\">opener.location.href='" + url + "/_layouts/epmlive/tpsetup.aspx';window.close();</script>");

        }

    }
}