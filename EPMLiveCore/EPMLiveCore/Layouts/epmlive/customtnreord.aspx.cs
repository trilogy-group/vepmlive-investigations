using System;
using System.Web;
using EPMLiveCore.Controls.Navigation.Providers;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;

namespace EPMLiveCore
{
    public partial class CustomTnReord : LayoutsPageBase
    {
        #region constants

        private const string TOP_NAV_URL = "epmlive/customtopnav.aspx";
        private const string ASYNC_NAV_ACTIONS_URL = "/_layouts/epmlive/AsyncNavActions.aspx";

        #endregion

        #region fields

        private SPSite _site;
        private SPWeb _web;
        protected List<SPNavigationNode> _spNavCollTopNav;
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
            if (!string.IsNullOrEmpty(Request["appid"]))
            {
                try
                {
                    _appId = int.Parse(Request["appid"]);
                }
                catch { }
            }

            try
            {
                _nodeType = Request["nodeType"];
            }
            catch { }

            appHelper = new AppSettingsHelper();
            //_spNavCollTopNav = _web.Navigation.TopNavigationBar;
            _spNavCollTopNav = appHelper.TryGetTopNavNodeCollectionById(_appId);
            _origUserId = SPContext.Current.Web.CurrentUser.ID;
        }

        private void RedirectToTopNavPage()
        {
            SPUtility.Redirect(
                TOP_NAV_URL,
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

        protected void OnSubmit( object sender, EventArgs e )
        {
            UpdateNodeOrder();
            ClearCache();
            RedirectToTopNavPage();
        }

        protected void OnCancel( object sender, EventArgs e )
        {
            RedirectToTopNavPage();
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
            
            foreach( string movedItem in movedItems )
            {
                if( string.IsNullOrEmpty(movedItem) )
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
            //if (_appId != -1)
            //{
            //    // translate displayed index into real index in Web.Navigation
            //    oldIndex = AppSettingsHelper.GetRealIndex(parentNodeID, oldIndex, _appId, _nodeType);
            //}
            int newIndex = Convert.ToInt32(movementInfo[2]);
            //if (_appId != -1)
            //{
            //    // translate displayed index into real index in Web.Navigation
            //    newIndex = AppSettingsHelper.GetRealIndex(parentNodeID, newIndex, _appId, "topnav");
            //}

            SPNavigationNode parentNode = _web.Navigation.GetNodeById(parentNodeID);
            SPNavigationNodeCollection contextNodeCollection = parentNode.Children;
            SPNavigationNode node = contextNodeCollection[oldIndex];

            int currentlastIndex = contextNodeCollection.Count - 1;
                        
            if( newIndex != oldIndex )
            {
                if( newIndex == 0 )
                {
                    node.MoveToFirst(contextNodeCollection);
                }
                else if( newIndex == currentlastIndex )
                {
                    node.MoveToLast(contextNodeCollection);
                }
                else
                {  
                    if (newIndex < oldIndex)
                    {
                        node.Move(contextNodeCollection, contextNodeCollection[newIndex -1]);
                    }
                    else
                    {
                        node.Move(contextNodeCollection, contextNodeCollection[newIndex]);
                    }
                }
            }

            // note: 
            // when performing SPNavigationNode.(Move/MoveToFirst/MoveToLast) 
            // SPNavigationNode.Update() is not necessary according to MSDN documents
        }

        #endregion

        #region page lifecycle methods

        protected void Page_Load( object sender, EventArgs e )
        {
            ManageFields();
            RegisterControlEvents();
        }

        #endregion
    }
}
