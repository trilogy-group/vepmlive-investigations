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
    public partial class CustomEditNav : LayoutsPageBase
    {
        #region constants

        private const string TOP_NAV_URL = "epmlive/customtopnav.aspx";
        private const string QUICK_LNCH_URL = "epmlive/customquiklnch.aspx";
        private const string ASYNC_NAV_ACTIONS_URL = "/_layouts/epmlive/AsyncNavActions.aspx";

        #endregion

        #region fields

        private SPSite _site;
        private SPWeb _web;
        private SPSite _eSite;
        private SPWeb _eWeb;
        protected SPNavigationNode _currentNode;
        protected SPNavigationNode _eCurrentNode;
        protected int _iId = 0;
        private bool _isEditingHeading;
        protected string _nodeType = string.Empty;
        protected int _appId = -1;
        private AppSettingsHelper appHelper;

        protected string _asyncDelAction = "deletenode";
        protected string _asyncEditAction = "editnode";
        protected string _async_nav_actions_url = ASYNC_NAV_ACTIONS_URL;
        protected string _webUrl = string.Empty;
        

        #endregion

        #region private methods

        private void LoadUIContent()
        {
            LoadTitleAndUrl();
            LoadHeadingDropDownList();
        }

        private void LoadHeadingDropDownList()
        {
            if (!_isEditingHeading)
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

                if (_currentNode != null)
                {
                    ddlNavigationHeadings.SelectedValue = _currentNode.ParentId.ToString();
                }
            }
        }

        private void LoadTitleAndUrl()
        {
            if (_currentNode != null)
            {
                txtTitle.Text = _currentNode.Title;
                txtUrl.Text = _currentNode.Url;
            }
        }

        private void RegisterControEvents()
        {
            BtnDelete.Click += new EventHandler(OnDelete);
            BtnOk.Click += new EventHandler(OnSubmit);
            BtnCancel.Click += new EventHandler(OnCancel);

            if (_appId != -1)
            {
                BtnDelete.OnClientClick = "AsyncDeleteNode(); return false;";
                BtnOk.OnClientClick = "AsyncUpdateNode(); return false;";
                BtnCancel.OnClientClick = "SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', '0', ''); return false;";
            }
        }

        private void DisplayCategorySection()
        {
            if (_isEditingHeading)
            {
                EditLinkInTitleArea.Text = "Edit Heading";
            }
            CategorySection.Visible = !_isEditingHeading;
        }

        private void UpdateNode()
        {
            int newParentNodeID = -1;
            if (ddlNavigationHeadings.SelectedIndex != -1)
            {
                newParentNodeID = Convert.ToInt32(ddlNavigationHeadings.SelectedValue);
            }

            string url = txtUrl.Text;
            string title = !string.IsNullOrEmpty(txtTitle.Text) ? txtTitle.Text : url;

            appHelper.EditNodeById(newParentNodeID, _iId, title, url, _appId, _nodeType, SPContext.Current.Web.CurrentUser);

            API.Applications.CreateQuickLaunchXML(_appId, Web);
            API.Applications.CreateTopNavXML(_appId, Web);
            
        }

        #endregion

        #region helper methods

        private void ManageFields()
        {
            _site = SPContext.Current.Site;
            _web = SPContext.Current.Web;
            appHelper = new AppSettingsHelper();
            _webUrl = _web.Url;
            int.TryParse(GetParameter("ID"), out _iId);
            int.TryParse(GetParameter("appid"), out _appId);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                _eSite = new SPSite(_site.Url);
                _eWeb = _eSite.OpenWeb(_web.ServerRelativeUrl);
                _eCurrentNode = (_iId != 0) ? _eWeb.Navigation.GetNodeById(_iId) : null;
            });

            _currentNode = (_iId != 0) ? _web.Navigation.GetNodeById(_iId) : null;
            _nodeType = GetParameter("nodetype");

            if ((_currentNode.ParentId == _web.Navigation.TopNavigationBar.Parent.Id) ||
                (_currentNode.ParentId == _web.Navigation.QuickLaunch.Parent.Id))
            {
                _isEditingHeading = true;
            }
            else
            {
                _isEditingHeading = false;
            }
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

        private void AuthenticateUser()
        {
            if (!CoreFunctions.DoesCurrentUserHaveFullControl(_web))
            {
                SPUtility.TransferToErrorPage("Access denied.");
            }
        }

        #endregion

        #region event handlers

        protected void OnDelete(object sender, EventArgs e)
        {
            if (_currentNode != null)
            {   
                _eWeb.AllowUnsafeUpdates = true;
                _eWeb.Update();
                SPNavigationNode eNode = _eWeb.Navigation.GetNodeById(_currentNode.Id);
                
                // delete the ids from the 
                // respective app items first
                switch (_nodeType)
                {
                    case "topnav":
                        appHelper.DeleteAppTopNav(_appId, eNode.Id);
                        break;
                    case "quiklnch":
                        appHelper.DeleteAppQuickLaunch(_appId, eNode.Id);
                        break;
                    default:
                        break;
                }

                eNode.Delete();
                ClearCache();
            }

            Redirect();
        }

        protected void OnSubmit(object sender, EventArgs e)
        {
            UpdateNode();
            ClearCache();
            Redirect();
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            Redirect();
        }

        private void ClearCache()
        {
            new GenericLinkProvider(SPContext.Current.Site.ID, SPContext.Current.Web.ID, SPContext.Current.Web.CurrentUser.LoginName).ClearCache();
        }
        #endregion

        #region page lifecycle events

        protected void Page_Load(object sender, EventArgs e)
        {   
            ManageFields();
            AuthenticateUser();
            RegisterControEvents();
            DisplayCategorySection();

            if (!IsPostBack)
            {
                LoadUIContent();
            }

        }
        #endregion
    }
}
