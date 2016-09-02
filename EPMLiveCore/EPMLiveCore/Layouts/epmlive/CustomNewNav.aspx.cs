using System;
using System.Web;
using System.Web.UI.WebControls;
using EPMLiveCore.Controls.Navigation.Providers;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace EPMLiveCore
{
    public partial class CustomNewNav : LayoutsPageBase
    {
        #region constants

        private const string TOP_NAV_URL = "epmlive/customtopnav.aspx";
        private const string QUICK_LNCH_URL = "epmlive/customquiklnch.aspx";
        private const string ASYNC_NAV_ACTIONS_URL = "/_layouts/epmlive/AsyncNavActions.aspx";

        #endregion

        #region fields

        private SPSite _site;
        private SPWeb _web;
        private int _parentNodeId = 0;
        private bool _isNewHeading = false;
        private AppSettingsHelper appHelper;

        protected int _appId = -1;
        protected string _webUrl = string.Empty;
        protected string _async_nav_actions_url = string.Empty;
        protected string _createAction = string.Empty;
        protected string _nodeType = string.Empty;
        protected SPNavigationNode _parentNode;
        protected int _origUserId = -1;

        #endregion



        #region event handlers

        private void OnSubmit(object sender, EventArgs e)
        {
            CreateNodes();
            ClearCache();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Redirect();
        }

        #endregion

        #region helper methods

        /// <summary>
        /// Initialize fields on current page.
        /// </summary>
        private void ManageFields()
        {
            appHelper = new AppSettingsHelper();
            _site = SPContext.Current.Site;
            _web = SPContext.Current.Web;
            _webUrl = _web.Url;
            _async_nav_actions_url = ASYNC_NAV_ACTIONS_URL;
            int.TryParse(GetParameter("parentnodeid"), out _parentNodeId);
            _nodeType = GetParameter("nodetype");
            _isNewHeading = bool.TryParse(GetParameter("isheading"), out _isNewHeading);

            if (_isNewHeading)
            {
                _createAction = "createparentnode";
            }
            else
            {
                _createAction = "createchildnode";
            }

            if (_parentNodeId == 1002)
            {
                _parentNode = _web.Navigation.TopNavigationBar.Parent;
                _nodeType = "topnav";
            }

            if (_parentNodeId == 1025)
            {
                _parentNode = _web.Navigation.QuickLaunch.Parent;
                _nodeType = "quiklnch";
            }

            int.TryParse(GetParameter("appid"), out _appId);

            _origUserId = SPContext.Current.Web.CurrentUser.ID;
        }

        private string GetParameter(string key)
        {
            string retVal = string.Empty;
            string curUrl = HttpContext.Current.Request.RawUrl;
            string qs = string.Empty;

            if (curUrl.IndexOf('?') != -1)
            {
                qs = curUrl.Substring(curUrl.IndexOf('?'));
            }

            NameValueCollection qsColl = !string.IsNullOrEmpty(qs) ? HttpUtility.ParseQueryString(qs) : null;

            if (qsColl != null && qsColl.HasKeys())
            {
                try
                {
                    retVal = qsColl.Get(key);
                }
                catch { }
            }

            return retVal;
        }

        private void CreateNodes()
        {
            SPUser origUser = SPContext.Current.Web.CurrentUser;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(_web.Url))
                {
                    using (SPWeb ew = es.OpenWeb())
                    {
                        if (!_isNewHeading)
                        {
                            int headingNodeId = int.Parse(ddlNavigationHeadings.SelectedValue);
                            string title = !string.IsNullOrEmpty(txtTitle.Text) ? txtTitle.Text : txtUrl.Text;
                            string url = txtUrl.Text;
                            appHelper.CreateChildNode(_appId, _nodeType, title, url, headingNodeId, !appHelper.IsUrlInternal(url), origUser);
                            API.Applications.CreateQuickLaunchXML(_appId, ew);
                            API.Applications.CreateTopNavXML(_appId, ew);
                        }
                        else
                        {   
                            string title = !string.IsNullOrEmpty(txtTitle.Text) ? txtTitle.Text : txtUrl.Text;
                            string url = txtUrl.Text;
                            appHelper.CreateParentNode(_appId, _nodeType, title, url, !appHelper.IsUrlInternal(url), origUser);
                            API.Applications.CreateQuickLaunchXML(_appId, ew);
                            API.Applications.CreateTopNavXML(_appId, ew);
                        }
                    }
                }
            });

            Redirect();
        }

        private void RedirectToTopNavPage()
        {
            SPUtility.Redirect(
                TOP_NAV_URL,
                SPRedirectFlags.RelativeToLayoutsPage,
                HttpContext.Current
                );
        }

        private void RedirectToQuickLaunch()
        {
            SPUtility.Redirect(
                QUICK_LNCH_URL,
                SPRedirectFlags.RelativeToLayoutsPage,
                HttpContext.Current
                );
        }

        private void Redirect()
        {
            switch (_nodeType)
            {
                case "topnav":
                    RedirectToTopNavPage();
                    break;
                case "quiklnch":
                    RedirectToQuickLaunch();
                    break;
                default:
                    RedirectToQuickLaunch();
                    break;
            }
        }

        #endregion

        #region private methods

        private void ClearCache()
        {
            new GenericLinkProvider(SPContext.Current.Site.ID, SPContext.Current.Web.ID, SPContext.Current.Web.CurrentUser.LoginName).ClearCache();
        }

        private void RegisterControlEvents()
        {
            BtnOk.Click += new EventHandler(OnSubmit);
            BtnCancel.Click += new EventHandler(OnCancel);

            if (_appId != -1)
            {
                BtnOk.OnClientClick = "AsyncAddHeading(); return false;";
                BtnCancel.OnClientClick = "SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', '0', ''); return false;";
            }
        }

        /// <summary>
        /// Show the panel that contains the headings
        /// drop down list if creating a child navigation node.
        /// Hide it otherwise.
        /// </summary>
        /// <param name="isCreatingParent"></param>
        private void ShowCategorySection(bool isheading)
        {
            CategorySection.Visible = !isheading;
            if (isheading)
            {
                NewLinkInTitleArea.Text = "New Heading";
            }
        }

        private void LoadHeadingDropDownList()
        {
            if (!IsPostBack && !_isNewHeading)
            {
                SPNavigationNodeCollection coll = null;
                switch (_nodeType)
                {
                    case "topnav":
                        coll = _web.Navigation.TopNavigationBar;
                        break;
                    case "quiklnch":
                        coll = _web.Navigation.QuickLaunch;
                        break;
                }

                List<int> navIds = new List<int>();

                if (_appId != -1)
                {
                    switch (_nodeType)
                    {
                        case "topnav":
                            navIds = appHelper.TryGetTopNavIdsByAppId(_appId);
                            break;
                        case "quiklnch":
                            navIds = appHelper.TryGetQuickLaunchIdsByAppId(_appId);
                            break;
                    }
                }

                foreach (SPNavigationNode node in coll)
                {
                    if (navIds.Count > 0)
                    {
                        if (navIds.Contains(node.Id))
                        {
                            ddlNavigationHeadings.Items.Add(
                                new ListItem(node.Title, node.Id.ToString())
                                );
                        }
                    }
                    else
                    {
                        ddlNavigationHeadings.Items.Add(
                            new ListItem(node.Title, node.Id.ToString())
                            );
                    }
                }
            }
        }

        private void AuthenticateUser()
        {
            if (!CoreFunctions.DoesCurrentUserHaveFullControl(_web))
            {
                SPUtility.TransferToErrorPage("Access denied.");
            }
        }

        #endregion

        #region page lifecycle events

        protected void Page_Load(object sender, EventArgs e)
        {
            ManageFields();
            AuthenticateUser();
            RegisterControlEvents();
            ShowCategorySection(_isNewHeading);
            LoadHeadingDropDownList();
        }

        #endregion
    }


}
