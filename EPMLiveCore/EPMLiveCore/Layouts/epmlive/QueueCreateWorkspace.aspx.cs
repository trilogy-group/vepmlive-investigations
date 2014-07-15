using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.API;
using System.Web;
using System.Collections;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class QueueCreateWorkspace : LayoutsPageBase
    {
        private const string WORKENGINE_WS_URL = "/_vti_bin/WorkEngine.asmx/Execute";

        protected string _isStandAlone = "true";
        protected string _compLevels = string.Empty;
        protected string _workEngineSvcUrl = string.Empty;
        protected string _lstGuid = string.Empty;
        protected string _listName = string.Empty;
        protected string _itemId = string.Empty;
        protected string _newItemName = string.Empty;
        protected string _newItemNameLwrCs = string.Empty;
        protected string _templateType = string.Empty;
        protected string _workspaceTitle = string.Empty;
        protected string _rListName = string.Empty;
        protected string _reqListName = string.Empty;
        protected string _doNotDelRequest = string.Empty;
        protected string _tempGalRedirect = string.Empty;
        protected string _curWebUrl = string.Empty;
        protected string _requestProjectName = string.Empty;
        protected string _uniquePermission = "true";
        protected string _defaultCreateNewOpt = string.Empty;
        protected string _currentUserId = string.Empty;
        protected string _showInProgress = "false";
        protected bool _isDlg = false;
        protected bool _redirectToModal = false;
        protected bool _hideEverything = false;

        private string _projectWorkspaceSetting = string.Empty;
        protected bool _isCreateFromOnlineAvail = false;
        protected bool _isCreateFromLocalAvail = false;
        protected bool _isCreateFromExistingAvail = false;
        protected string _createFromLiveTemp = string.Empty;
        private ArrayList _features;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitFields();
            Respond();
        }

        private void Respond()
        {  
            if (!bool.Parse(_isStandAlone))
            {
                string url = WorkspaceData.GetWorkspaceUrl(SPContext.Current.Site.ID, SPContext.Current.Web.ID, new Guid(_lstGuid), int.Parse(_itemId));
                string status = WorkspaceData.GetWorkspaceStatus(SPContext.Current.Site.ID, SPContext.Current.Web.ID, new Guid(_lstGuid), int.Parse(_itemId));

                if (_isDlg)
                {
                    if (!string.IsNullOrEmpty(url))
                    {
                        // redirect parent window                        
                        ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(),
                            @"<script>$(function(){ window.top.location.href = '" + url + "'; });</script>");
                    }
                    else if (status == "InProgress")
                    {
                        // show msg
                        _showInProgress = "true";
                    }
                    else if (string.IsNullOrEmpty(url) && status == "NotTried")
                    {
                        // do nothing continue with normal page load
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(url))
                    {
                        // redirect window
                        SPUtility.Redirect(url, SPRedirectFlags.Default, HttpContext.Current);
                    }
                    else 
                    {
                        _hideEverything = true;
                        // pop up create modal
                        ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(),
                            @"<script>$(function(){ var options = { url: '_layouts/epmlive/QueueCreateWorkspace.aspx?listid=" + _lstGuid + "&itemid=" + _itemId + "'," +
                                             "allowMaximize: false, " +
                                             "showClose: false }; " +
                            "SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options); });</script>");

                    }
                }
            }
        }

        private void InitFields()
        {
            var _cSite = SPContext.Current.Site;
            var _cWeb = SPContext.Current.Web;

            GetQueryStringParameters();
            GetFeatures();

            _currentUserId = _cWeb.CurrentUser.ID.ToString();
            
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (var s = new SPSite(SPContext.Current.Site.ID))
                {
                    using (var lockedWeb = s.OpenWeb(CoreFunctions.getLockedWeb(Web)))
                    {
                        _createFromLiveTemp = CoreFunctions.getConfigSetting(lockedWeb, "EPMLiveUseLiveTemplates");
                        _workEngineSvcUrl = GetWorkengineServiceURL(lockedWeb);
                        _compLevels = GetCompLevels(lockedWeb);
                        _projectWorkspaceSetting = CoreFunctions.getConfigSetting(lockedWeb, "EPMLiveNewProjectWorkspaceType");

                        if (!string.IsNullOrEmpty(_lstGuid))
                        {
                            GridGanttSettings gSettings = new GridGanttSettings(_cWeb.Lists[new Guid(_lstGuid)]);
                            _newItemName = (!string.IsNullOrEmpty(_lstGuid) && !string.IsNullOrEmpty(gSettings.NewMenuName)) ? gSettings.NewMenuName : "workspace";
                            _newItemNameLwrCs = _newItemName.ToLower();
                            _listName = GetListName();
                            _workspaceTitle = GetWorkspaceTitle();
                            _rListName = (!string.IsNullOrEmpty(gSettings.RollupLists)) ? gSettings.RollupLists.Split(',')[0].Split('|')[0] : string.Empty;
                            _reqListName = gSettings.RequestList;
                        }

                        GetDefaultCreateWorkspaceUISettings(lockedWeb);
                    }
                }
            });
        }

        #region helper methods on page load

        private void GetFeatures()
        {
            Act act = new Act(Web);
            _features = act.GetActivatedLevels();
        }

        private void GetQueryStringParameters()
        {   
            if (!string.IsNullOrEmpty(Request["listid"]))
            {
                _lstGuid = Request["listid"];
            }

            if (!string.IsNullOrEmpty(Request["itemid"]))
            {
                _itemId = Request["itemid"];
            }

            if (!string.IsNullOrEmpty(_lstGuid))
            {
                _isStandAlone = "false";
            }
            else
            {
                _isStandAlone = "true";
            }

            try
            {
                _uniquePermission = bool.Parse(_isStandAlone)
                    ? "true": SPContext.Current.Web.Lists[new Guid(_lstGuid)].GetItemById(int.Parse(_itemId)).HasUniqueRoleAssignments.ToString();
            }
            catch { }

            if (!string.IsNullOrEmpty(Request["isDlg"]))
            {   
                string sIsDlg = Request["isDlg"].ToString();
                switch (sIsDlg)
                {
                    case "1":
                        _isDlg = true;
                        break;
                    case "0":
                        _isDlg = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private string GetTemplateResourceURLWithLockedWeb(SPWeb lockedWeb)
        {
            string token = string.Empty;
            string tempResUrl = string.Empty;
            try
            {
                token = CoreFunctions.getConfigSetting(lockedWeb, "EPMLiveTemplateGalleryURL", false, true);
                switch (token)
                {
                    case "{Site}":
                        tempResUrl = SPContext.Current.Web.ServerRelativeUrl;
                        break;
                    case "{site}":
                        tempResUrl = SPContext.Current.Web.ServerRelativeUrl;
                        break;
                    case "{Root}":
                        tempResUrl = CoreFunctions.getConfigSetting(lockedWeb, "EPMLiveTemplateGalleryURL", true, true);
                        break;
                    case "{root}":
                        tempResUrl = CoreFunctions.getConfigSetting(lockedWeb, "EPMLiveTemplateGalleryURL", true, true);
                        break;
                }
            }
            catch
            {
                tempResUrl = SPContext.Current.Web.ServerRelativeUrl;
            }
            return tempResUrl;
        }

        private string GetWorkengineServiceURL(SPWeb lockedWeb)
        {
            string tempResUrl = GetTemplateResourceURLWithLockedWeb(lockedWeb);
            string svcUrl = string.Empty;
            if (!string.IsNullOrEmpty(tempResUrl))
            {
                using (SPWeb w = Site.AllWebs[tempResUrl])
                {
                    svcUrl = w.Url + WORKENGINE_WS_URL;
                }
            }
            else
            {
                svcUrl = Web.Url + WORKENGINE_WS_URL;
            }

            return svcUrl;
        }

        private string GetCompLevels(SPWeb lockedWeb)
        {
            string compLvls = string.Empty;
            try { compLvls = lockedWeb.AllProperties["CompLevel"].ToString(); }
            catch { }
            try { compLvls = lockedWeb.AllProperties["complevel"].ToString(); }
            catch { }
            return compLvls;
        }

        private string GetListName()
        {
            string lstName = string.Empty;
            SPList tempList = null;
            try { tempList = SPContext.Current.Web.Lists[new Guid(_lstGuid)]; }
            catch { }
            lstName = (tempList != null) ? tempList.Title : string.Empty;
            return lstName;
        }

        private string GetWorkspaceTitle()
        {
            string title = string.Empty;
            SPList tempList = null;
            try { tempList = SPContext.Current.Web.Lists[new Guid(_lstGuid)]; }
            catch { }
            if (!bool.Parse(_isStandAlone) && tempList != null)
            {
                SPListItem i = null;
                try { i = tempList.GetItemById(int.Parse(_itemId)); }
                catch { }
                title = (i != null) ? i.Title : string.Empty;
            }
            
            if (title.Contains("'"))
            {
                title=title.Replace("'", "\\'");
            }
            return title;
        }

        private void GetDefaultCreateWorkspaceUISettings(SPWeb lockedWeb)
        {
            string epmLiveCreateNewSettings = CoreFunctions.getConfigSetting(lockedWeb, "EPMLiveCreateNewSettings");
            if (!string.IsNullOrEmpty(epmLiveCreateNewSettings))
            {
                PropertyHash props = new PropertyHash(epmLiveCreateNewSettings, ";#", '|', '^');
                if (props != null && props[0].Keys.Count > 0)
                {
                    _defaultCreateNewOpt = props[0]["Default"].ToString();
                    try { _isCreateFromOnlineAvail = bool.Parse(props[1]["Online"].ToString()); }catch { }
                    if (_defaultCreateNewOpt == "online")
                    {
                        _isCreateFromOnlineAvail = true;
                    }
                    
                    try{_isCreateFromLocalAvail = bool.Parse(props[1]["Local"].ToString());}catch{}
                    if (_defaultCreateNewOpt == "local")
                    {
                        _isCreateFromLocalAvail = true;
                    }
                    
                    try{_isCreateFromExistingAvail = bool.Parse(props[1]["Existing"].ToString());}catch { }
                    if (_defaultCreateNewOpt == "existing")
                    {
                        _isCreateFromExistingAvail = true;
                    }

                }
                else
                {
                    _defaultCreateNewOpt = "online";
                }
            }
            else
            {
                _defaultCreateNewOpt = "existing";
            }
            _createFromLiveTemp = CoreFunctions.getConfigSetting(lockedWeb, "EPMLiveUseLiveTemplates");
        }
        #endregion
    }
}
