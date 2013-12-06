using System;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.CONTROLTEMPLATES
{
    [MdsCompliant(true)]
    public partial class EPMLiveNotificationCounterV2 : UserControl
    {
        #region Fields (2)

        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";
        private string _prifilePicUrl;

        #endregion Fields

        #region Properties (1)

        public string PrifilePicUrl
        {
            get { return _prifilePicUrl ?? string.Empty; }
        }

        #endregion Properties

        #region Methods (6)

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + "stylesheets/notifications.v2.min.css");

            EPMLiveScriptManager.RegisterScript(Page, new[] { "libraries/jquery.min", "@EPMLive.Notifications.v2" });

            GetProfilePicture();
        }

        protected void Page_Load(object sender, EventArgs e) { }
        // Private Methods (4) 

        private void GetProfilePicture()
        {
            SPUser currentUser = SPContext.Current.Web.CurrentUser;
            if (currentUser == null) return;

            SPSite spSite = SPContext.Current.Site;
            currentUser = GetProfileUser(spSite, false, currentUser);
            SPListItem spListItem = spSite.RootWeb.SiteUserInfoList.GetItemById(currentUser.ID);
            _prifilePicUrl = GetProfilePicturePath(spListItem) + "?v=" + DateTime.Now.Ticks;
        }

        private string GetProfilePicturePath(SPListItem spListItem)
        {
            var profilePicturePath = spListItem["Picture"] as string;

            if (!string.IsNullOrEmpty(profilePicturePath))
            {
                if (profilePicturePath.Split(',').Length > 1)
                {
                    profilePicturePath = profilePicturePath.Split(',')[0];
                }
            }
            else
            {
                profilePicturePath = string.Empty;
            }

            return profilePicturePath;
        }

        private SPUser GetProfileUser(SPSite site, bool revertSystemAccount, SPUser user)
        {
            string loginName = user.LoginName;
            SPUser ensuredUser = user;

            if (!IsSharePointSystemAccount(loginName) || !revertSystemAccount) return ensuredUser;

            bool originalAllowUnsafeUpdatesFlag = site.RootWeb.AllowUnsafeUpdates;
            site.RootWeb.AllowUnsafeUpdates = true;

            loginName = site.WebApplication.ApplicationPool.Username;
            ensuredUser = site.RootWeb.EnsureUser(loginName);

            site.RootWeb.AllowUnsafeUpdates = originalAllowUnsafeUpdatesFlag;

            return ensuredUser;
        }

        private bool IsSharePointSystemAccount(string loginName)
        {
            return (loginName.ToLower() == @"sharepoint\system");
        }

        #endregion Methods
    }
}