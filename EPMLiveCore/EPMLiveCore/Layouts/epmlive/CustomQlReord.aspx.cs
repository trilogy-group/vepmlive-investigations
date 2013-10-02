using System;
using EPMLiveCore.Controls.Navigation.Providers;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Utilities;
using System.Web;
using System.Collections.Generic;

namespace EPMLiveCore
{
    public partial class CustomQlReord : LayoutsPageBase
    {
        #region constants

        private const string QUIK_LNCH_URL = "epmlive/customquiklnch.aspx";
        private const string ASYNC_NAV_ACTIONS_URL = "/_layouts/epmlive/AsyncNavActions.aspx";

        #endregion

        #region fields

        private SPSite _site;
        private SPWeb _web;
        private SPSite _eSite;
        private SPWeb _eWeb;
        protected List<SPNavigationNode> _spNavCollQuickLaunch;
        protected int _appId = -1;

        protected string _nodeType = string.Empty;
        protected string _actionMoveNode = "movenode";
        protected string _async_nav_actions_url = ASYNC_NAV_ACTIONS_URL;
        private AppSettingsHelper appHelper;
        protected int _origUserId = -1;

        #endregion

        #region helper methods

        private void ManageFields()
        {
            _site = SPContext.Current.Site;
            _web = SPContext.Current.Web;
            appHelper = new AppSettingsHelper();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                _eSite = new SPSite(_site.Url);
                _eWeb = _eSite.OpenWeb(_web.ServerRelativeUrl);
            });

            int.TryParse(Request["appid"], out _appId);

            if (!string.IsNullOrEmpty(Request["nodeType"]))
            {
                _nodeType = Request["nodeType"];
            }

            //_spNavCollQuickLaunch = _web.Navigation.QuickLaunch;
            _spNavCollQuickLaunch = appHelper.TryGetQuickLaunchNodeCollectionById(_appId);
            _origUserId = SPContext.Current.Web.CurrentUser.ID;
        }

        private void RedirectToQuikLnch()
        {
            SPUtility.Redirect(
                QUIK_LNCH_URL,
                SPRedirectFlags.RelativeToLayoutsPage,
                HttpContext.Current
                );
        }

        private void RegisterControlEvents()
        {
            BtnOk.Click += new EventHandler(OnSubmit);
            BtnCancel.Click += new EventHandler(OnCancel);

            if (_appId != -1)
            {
                BtnOk.OnClientClick = "AsyncMoveNode();return false;";
                BtnCancel.OnClientClick = "SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', '0', '');";
            }
        }

        #endregion

        #region event handlers

        protected void OnSubmit(object sender, EventArgs e)
        {
            UpdateNodeOrder();
            ClearCache();
            RedirectToQuikLnch();
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            RedirectToQuikLnch();
        }

        #endregion

        #region private methods

        private void ClearCache()
        {
            new GenericLinkProvider(SPContext.Current.Site.ID, SPContext.Current.Web.ID, SPContext.Current.Web.CurrentUser.LoginName).ClearCache();
        }

        private void UpdateNodeOrder()
        {
            // Get the moving record from html control called "MovedItems".
            // It a long string value that contains a ; separated set of integers. 
            // e.g., 2009, 0, 1; 2001, 2, 3;
            // Each set represents <parentId>, <oldIndex>, <newIndex>
            string movedItemsRecord = Request.Params["MovedItems"];

            string[] movedItems = movedItemsRecord.Split(new char[] { ';' });
            string[] movementInfo;

            _web.AllowUnsafeUpdates = true;

            foreach (string movedItem in movedItems)
            {
                if (string.IsNullOrEmpty(movedItem))
                {
                    continue;
                }

                movementInfo = movedItem.Split(new char[] { ',' });
                // do the actual re-ordering
                MoveNode(movementInfo);
            }

            _web.AllowUnsafeUpdates = false;
        }

        /// <summary>
        /// reads a set of integers
        /// that represents a recorded node movement and 
        /// perform the node re-ordering
        /// </summary>
        /// <param name="movementInfo"></param>
        private void MoveNode(string[] movementInfo)
        {
            int parentNodeID = Convert.ToInt32(movementInfo[0]);
            int oldIndex = Convert.ToInt32(movementInfo[1]);
            int newIndex = Convert.ToInt32(movementInfo[2]);

            _eWeb.AllowUnsafeUpdates = true;

            SPNavigationNode eParentNode = _eWeb.Navigation.GetNodeById(parentNodeID);
            SPNavigationNodeCollection eContextNodeCollection = eParentNode.Children;
            SPNavigationNode eNode = eContextNodeCollection[oldIndex];

            int currentlastIndex = eContextNodeCollection.Count - 1;

            if (newIndex != oldIndex)
            {
                if (newIndex == 0)
                {
                    eNode.MoveToFirst(eContextNodeCollection);
                }
                else if (newIndex == currentlastIndex)
                {
                    eNode.MoveToLast(eContextNodeCollection);
                }
                else
                {
                    if (newIndex < oldIndex)
                    {
                        eNode.Move(eContextNodeCollection, eContextNodeCollection[newIndex - 1]);
                    }
                    else
                    {
                        eNode.Move(eContextNodeCollection, eContextNodeCollection[newIndex]);
                    }
                }
            }

            // note: 
            // when performing SPNavigationNode.(Move/MoveToFirst/MoveToLast) 
            // SPNavigationNode.Update() is not necessary according to MSDN documents
        }

        private void AuthenticateUser()
        {
            if (!CoreFunctions.DoesCurrentUserHaveFullControl(_web))
            {
                SPUtility.TransferToErrorPage("Access denied.");
            }
        }

        #endregion

        #region page lifecycle methods

        protected void Page_Load(object sender, EventArgs e)
        {
            ManageFields();
            AuthenticateUser();
            RegisterControlEvents();
        }

        #endregion
    }
}
