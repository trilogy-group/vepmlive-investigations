using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Utilities;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using EPMLiveCore.GlobalResources;

namespace EPMLiveCore
{
    public partial class ChangeApp : System.Web.UI.Page
    {
        private int _appId = -1;
        private string failureUrl = string.Empty;
        private string _topnavNodes = string.Empty;
        private string _quickLaunchNodes = string.Empty;
        AppSettingsHelper appHelper;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                appHelper = new AppSettingsHelper();
                ManageFields();
                SetNewAppId();
                SPUtility.Redirect(SPContext.Current.Web.Url, SPRedirectFlags.Default, HttpContext.Current);
            }
            catch (Exception ex)
            {
                SPUtility.Redirect(SPContext.Current.Web.Url, SPRedirectFlags.Default, HttpContext.Current);
            }
        }

        private void ManageFields()
        {
            if (!string.IsNullOrEmpty(Request["appid"]))
            {
                try
                {
                    _appId = int.Parse(Request["appid"]);
                }
                catch { }
            }
        }

        private void SetNewAppId()
        {   
            SPListItem app = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb ew = es.OpenWeb())
                    {
                        try
                        {
                            app = ew.Lists.TryGetList("Installed Applications").GetItemById(_appId);
                        }
                        catch { }
                    }
                }
            });

            if (app != null && bool.Parse(app["Visible"].ToString()))
            {
                this.appHelper.SetCurrentAppId(_appId);
                //HttpCookie cookie = new HttpCookie("CurrentAppId_" + SPContext.Current.Web.ID.ToString("N"));
                //cookie.Value = _appId.ToString();
                //HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}
