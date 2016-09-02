using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class CustomQuikLnch : LayoutsPageBase
    {
        protected int _appId = -1;
        private SPWeb _web;
        protected ArrayList _alLinkData;
        private AppSettingsHelper appHelper;

        private void InitProps()
        {
            appHelper = new AppSettingsHelper();
            _web = SPContext.Current.Web;
            ManageInternalArrayList();

            if (!string.IsNullOrEmpty(Request["appid"]))
            {
                try
                {
                    _appId = int.Parse(Request["appid"]);
                }
                catch { }
            }
        }

        private void ManageInternalArrayList()
        {
            if (_alLinkData != null)
            {
                _alLinkData.Clear();
            }
            else
            {
                _alLinkData = new ArrayList();
            }
        }

        private void LoadTopNavBarNodeCollInMemory()
        {
            if (!_web.Navigation.UseShared)
            {
                SPNavigationNodeCollection nav = _web.Navigation.QuickLaunch;
                _web.AllowUnsafeUpdates = true;
                // get the list of quick launch nodes 
                // configured for particular app
                List<int> quickLaunchNavIds = null;

                if (_appId != -1)
                {
                    quickLaunchNavIds = appHelper.TryGetQuickLaunchIdsByAppId(_appId);
                }

                string onclick = string.Empty;

                foreach (SPNavigationNode node in nav)
                {   
                    if (_appId != -1) 
                    {
                        if (quickLaunchNavIds != null && quickLaunchNavIds.Contains(node.Id))
                        {
                            onclick = "QLOpenUrlWithModal('/_layouts/epmlive/customeditnav.aspx?ID=" + node.Id + "&nodetype=quiklnch&appId=" + _appId.ToString() + "', 'Edit Quick Launch Nav');";
                            _alLinkData.Add(new Triplet(node.Title, onclick, true));
                            if (node.Children.Count > 0)
                            {
                                foreach (SPNavigationNode childNode in node.Children)
                                {
                                    if (quickLaunchNavIds != null && quickLaunchNavIds.Contains(childNode.Id))
                                    {
                                        onclick = "QLOpenUrlWithModal('/_layouts/epmlive/customeditnav.aspx?ID=" + childNode.Id + "&nodetype=quiklnch&appId=" + _appId.ToString() + "', 'Edit Quick Launch Nav');";
                                        _alLinkData.Add(new Triplet(childNode.Title, onclick, false));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        _alLinkData.Add(new Triplet(node.Title, _web.ServerRelativeUrl + "/_layouts/epmlive/customeditnav.aspx?nodetype=quiklnch&id=" + node.Id, true));
                        if (node.Children.Count > 0)
                        {
                            foreach (SPNavigationNode childNode in node.Children)
                            {
                                if (quickLaunchNavIds != null && quickLaunchNavIds.Contains(childNode.Id))
                                {
                                    _alLinkData.Add(new Triplet(childNode.Title, _web.ServerRelativeUrl + "/_layouts/epmlive/customeditnav.aspx?nodetype=quiklnch&id=" + childNode.Id, false));
                                }
                            }
                        }
                    }
                }

                _web.AllowUnsafeUpdates = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitProps();
            AuthenticateUser();
            LoadTopNavBarNodeCollInMemory();
            ManageToolBarControls();
        }

        private void ManageToolBarControls()
        {
            if (_appId != -1)
            {
                List<int> appQuickLaunchIds = appHelper.TryGetRootChildQuickLaunchIdsByAppId(_appId);
                if (appQuickLaunchIds != null && appQuickLaunchIds.Count == 0)
                {
                    newNavNode.Visible = false;
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

        protected override void OnPreRender(EventArgs e)
        {
            //ScriptLink.Register(Page, "/_layouts/epmlive/jQueryLibrary/jquery-1.6.2.min.js", false);

            Page.ClientScript.RegisterClientScriptBlock(GetType(), "_ChangeButtonToOpenInModal_",
                    "<script>" +
                        "var webUrl = '" + Web.Url + "'; " +
                        "var btnNewNavId = '" + newNavNode.ClientID + "_LinkText'; " +
                        "var btnNewCatId = '" + newCatNode.ClientID + "_LinkText'; " +
                        "var btnReorderId = '" + btnReorderNavNodes.ClientID + "_LinkText'; " +
                        "var appId = '" + _appId.ToString() + "';" +
                    "</script>", false);

            ScriptLink.Register(Page, "/_layouts/epmlive/EPMLiveQuickLaunch.js", false);

            base.OnPreRender(e);
        }
    }
}
