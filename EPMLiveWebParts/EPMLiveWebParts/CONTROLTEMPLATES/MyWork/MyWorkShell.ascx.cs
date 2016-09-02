using System;
using System.Net;
using System.Web.UI;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.CONTROLTEMPLATES.MyWork
{
    public partial class MyWorkShell : UserControl
    {
        #region Fields (5) 

        private const string MY_WORK_CONTROL_PATH = @"~/_CONTROLTEMPLATES/MyWork/MyWorkControl.ascx";
        private const string WORKING_ON_CONTROL_PATH = @"~/_CONTROLTEMPLATES/MyWork/WorkingOnControl.ascx";
        private string _profileImageUrl;
        private int _userId;
        private string _userName;

        #endregion Fields 

        #region Properties (5) 

        public MyWorkParams MyWorkParams { get; set; }

        protected string ProfileImageUrl
        {
            get { return _profileImageUrl; }
        }

        protected int UserId
        {
            get { return _userId; }
        }

        protected string UserName
        {
            get { return _userName; }
        }

        public WorkingOnParams WorkingOnParams { get; set; }

        #endregion Properties 

        #region Methods (4) 

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            //CssRegistration.Register("/_layouts/epmlive/styles/mywork/shell.css");

            //ScriptLink.Register(Page, "/_layouts/epmlive/javascripts/EPMLive.WorkCenter.js", false);

            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb spWeb = SPContext.Current.Web;

            var act = new Act(spWeb);
            int featureLicenseStatus = act.CheckFeatureLicense(ActFeature.MyWork);

            if (featureLicenseStatus != 0)
            {
                ErrorLabel.Text = act.translateStatus(featureLicenseStatus);
                ControlPanel.Visible = false;
            }

            //SPUser currentUser = spWeb.CurrentUser;

            //_userId = currentUser.ID;
            //_userName = currentUser.Name;

            //SPListItem spListItem = spWeb.SiteUserInfoList.GetItemById(_userId);
            //var profilePic = spListItem["Picture"] as string;

            //_profileImageUrl = !string.IsNullOrEmpty(profilePic)
            //                       ? profilePic.Remove(profilePic.IndexOf(',')).Replace("MThumb", "LThumb")
            //                       : "/_layouts/epmlive/images/mywork/DefaultProfilePic.jpg";

            ControlPanel.Controls.Clear();

            foreach (Control control in new[] {GetMyWorkControl()})
            {
                ControlPanel.Controls.Add(control);
            }
        }

        // Private Methods (2) 

        private Control GetMyWorkControl()
        {
            var control = (MyWorkControl) Page.LoadControl(MY_WORK_CONTROL_PATH);

            control.CrossSiteUrls = MyWorkParams.CrossSiteUrls;
            control.DefaultGlobalView = MyWorkParams.DefaultGlobalView;
            control.DisplayTitle = MyWorkParams.DisplayTitle;
            control.MyWorkSelectedLists = MyWorkParams.MyWorkSelectedLists;
            control.MyWorkSelectedLst = MyWorkParams.MyWorkSelectedLst;
            control.PerformanceMode = MyWorkParams.PerformanceMode;
            control.Qualifier = MyWorkParams.Qualifier;
            control.SelectedFields = MyWorkParams.SelectedFields;
            control.SelectedLists = MyWorkParams.SelectedLists;
            control.SelectedLst = MyWorkParams.SelectedLst;
            control.TotalWebPartCount = MyWorkParams.TotalWebPartCount;
            control.UseCentralizedSettings = MyWorkParams.UseCentralizedSettings;
            control.WebPartHeight = MyWorkParams.WebPartHeight;
            control.WebPartId = MyWorkParams.WebPartId;
            control.WebPartPageComponentId = MyWorkParams.WebPartPageComponentId;
            control.DueDayFilter = MyWorkParams.DueDayFilter;
            control.NewItemIndicator = MyWorkParams.NewItemIndicator;
            control.ShowToolbar = MyWorkParams.ShowToolbar;

            return control;
        }

        private Control GetWorkingOnControl()
        {
            var control = (WorkingOnControl) Page.LoadControl(WORKING_ON_CONTROL_PATH);

            control.GridId = WorkingOnParams.GridId;

            return control;
        }

        #endregion Methods 
    }
}