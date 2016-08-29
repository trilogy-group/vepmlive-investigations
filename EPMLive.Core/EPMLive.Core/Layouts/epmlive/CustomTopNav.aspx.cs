using System;
using System.Collections;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;

namespace EPMLiveCore
{
    public partial class CustomTopNav : LayoutsPageBase
    {
        #region fields

        protected int _appId = -1;
        private SPWeb _web;
        protected ArrayList _alLinkData;
        private AppSettingsHelper appHelper;
        #endregion

        #region helper methods

        private void InitProps()
        {
            _web = SPContext.Current.Web;
            ManageInternalArrayList();
            appHelper = new AppSettingsHelper();
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

            string _newNavUrl = "customnewnav.aspx?id=" + _web.Navigation.TopNavigationBar[0].Id.ToString() + "&nodetype=topnav";

            if (_alLinkData != null)
            {
                _alLinkData.Clear();
            }
            else
            {
                _alLinkData = new ArrayList();
            }
        }

        #endregion

        #region private methods

        private void LoadTopNavBarNodeCollInMemory()
        {
            if (!_web.Navigation.UseShared)
            {
                SPNavigationNodeCollection nav = _web.Navigation.TopNavigationBar;
                _web.AllowUnsafeUpdates = true;
                List<int> topNavIds = null;

                if (_appId != -1)
                {
                    topNavIds = appHelper.TryGetTopNavIdsByAppId(_appId);
                }

                string onclick = string.Empty;

                foreach (SPNavigationNode node in nav)
                {
                    if (_appId != -1)
                    {
                        if (topNavIds != null && topNavIds.Contains(node.Id))
                        {
                            onclick = "TNOpenUrlWithModal('/_layouts/epmlive/customeditnav.aspx?ID=" + node.Id + "&nodetype=topnav&appId=" + _appId.ToString() + "', 'Edit Top Nav');";
                            _alLinkData.Add(new Triplet(node.Title, onclick, true));
                            if (node.Children.Count > 0)
                            {
                                foreach (SPNavigationNode childNode in node.Children)
                                {
                                    if (topNavIds != null && topNavIds.Contains(childNode.Id))
                                    {
                                        onclick = "TNOpenUrlWithModal('/_layouts/epmlive/customeditnav.aspx?ID=" + childNode.Id + "&nodetype=topnav&appId=" + _appId.ToString() + "', 'Edit Top Nav');";
                                        _alLinkData.Add(new Triplet(childNode.Title, onclick, false));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        _alLinkData.Add(new Triplet(node.Title, _web.Url + "/_layouts/epmlive/customeditnav.aspx?ID=" + node.Id + "&nodetype=topnav", true));
                        if (node.Children.Count > 0)
                        {
                            foreach (SPNavigationNode childNode in node.Children)
                            {
                                if (topNavIds != null && topNavIds.Contains(childNode.Id))
                                {
                                    _alLinkData.Add(new Triplet(childNode.Title, _web.Url + "/_layouts/epmlive/customeditnav.aspx?ID=" + childNode.Id + "&nodetype=topnav", false));
                                }
                            }
                        }
                    }
                }

                _web.AllowUnsafeUpdates = false;
            }
        }

        private bool IsInheritingFromParent()
        {
            bool result = false;

            if (_web.Navigation.UseShared)
            {
                result = true;
            }

            return result;
        }

        private void ManageToolBarControls()
        {
            BtnUniqueTopNav.Visible = IsInheritingFromParent();
            idNewNavNode.Visible = !IsInheritingFromParent();
            idNewCatNode.Visible = !IsInheritingFromParent();
            BtnReorderNavNodes.Visible = !IsInheritingFromParent();
            BtnInheritTopNav.Visible = (_web.ParentWeb != null && !IsInheritingFromParent());

            if (_appId != -1)
            {
                List<int> appTopNavIds = appHelper.TryGetRootChildTopNavIdsByAppId(_appId);
                if (appTopNavIds != null && appTopNavIds.Count == 0)
                {
                    idNewNavNode.Visible = false;
                }
            }
        }

        private void CheckTopNavInheritance()
        {
            _web.AllowUnsafeUpdates = true;
            if (hdnOperation.Value == "topnavInherit")
            {
                _web.Navigation.UseShared = true;
                IdTopNavBar.DataBind();
                _web.Update();

            }
            else if (hdnOperation.Value == "topnavUnique")
            {
                _web.Navigation.UseShared = false;
                IdTopNavBar.DataBind();
                _web.Update();
            }
            _web.AllowUnsafeUpdates = false;
        }

        #endregion

        #region page lifecycle methods

        protected void Page_Load(object sender, EventArgs e)
        {
            InitProps();
            CheckTopNavInheritance();
            ManageToolBarControls();
            LoadTopNavBarNodeCollInMemory();
        }

        protected override void OnPreRender(EventArgs e)
        {
            //ScriptLink.Register(Page, "/_layouts/epmlive/jQueryLibrary/jquery-1.6.2.min.js", false);

            Page.ClientScript.RegisterClientScriptBlock(GetType(), "_ChangeButtonToOpenInModal_",
                    "<script>" +
                        "var webUrl = '" + Web.Url + "'; " +
                        "var btnNewNavId = '" + idNewNavNode.ClientID + "_LinkText'; " +
                        "var btnNewCatId = '" + idNewCatNode.ClientID + "_LinkText'; " +
                        "var btnReorderId = '" + BtnReorderNavNodes.ClientID + "_LinkText'; " +
                        "var appId = '" + _appId.ToString() + "';" +
                    "</script>", false);

            ScriptLink.Register(Page, "/_layouts/epmlive/EPMLiveTopNav.js", false);

            base.OnPreRender(e);
        }

        #endregion

    }
}
