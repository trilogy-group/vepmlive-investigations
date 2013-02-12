using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class CreateNewWorkspace : LayoutsPageBase
    {

        private SPWeb _cWeb;
        private SPSite _cSite;
        private const string WORKENGINE_WS_URL = "/_vti_bin/workengine.asmx";
        private const string SOLUTION_STORE_PROXY_URL = "/_layouts/EPMLive/SolutionStoreProxy.aspx?";
        private const string MORE_INFO_URL = "/_layouts/EPMLive/MoreInformation.aspx?";
        private const string SMALL_PARENT_URL = "/_layouts/EPMLive/SmallParentUrlDialog.aspx";
        private const string TEMP_GAL_REDIRECT = "/_layouts/EPMLive/TemplateGalleryRedirect.aspx";
        private string _projectWorkspaceSetting;
        private bool _isCreateFromOnlineAvail = false;
        private bool _isCreateFromLocalAvail = false;
        private bool _isCreateFromExistingAvail = false;

        protected string _nav = string.Empty;
        protected string _perms = string.Empty;
        protected string _defaultCreateNewOpt = string.Empty;
        protected string _templateResourceUrl = string.Empty;
        // this maps to the "Solution Type" column in online store
        protected string _solutionType = string.Empty;
        // this maps to the "Template Type" colum in online store
        protected string _templateType = string.Empty;
        protected string _siteHostName = string.Empty;
        protected string _siteUrl = string.Empty;
        protected string _currentWebRelativeUrl = string.Empty;
        protected string _sourceWebId = string.Empty;
        protected string _workengineSvcUrl = string.Empty;
        protected string _moreInfoUrl = string.Empty;
        protected string _smallParentUrl = string.Empty;
        protected string _solutionStoreServiceProxyUrl = string.Empty;
        protected string _baseURL = string.Empty;
        protected string _lstGuid = string.Empty;
        protected string _parentWebUrl = string.Empty;
        protected string _parentWebGuid_B = string.Empty;
        protected string _wsTypeNew = "checked";
        protected string _wsTypeExisting;
        protected string _includeContentClientId = string.Empty;
        protected string _moreInfoUrlClientId = string.Empty;
        protected string _featuresList = string.Empty;
        protected string _newItemName = string.Empty;
        protected string _newItemNameLwrCs = string.Empty;
        protected bool _hasCreateSubSitePerm = false;
        protected string _copyFrom = string.Empty;
        protected string _rListName = string.Empty;
        protected string _reqListName = string.Empty;
        protected string _doNotDelRequest = string.Empty;
        protected string _tempGalRedirect = string.Empty;
        protected string _curWebUrl = string.Empty;
        protected string _requestProjectName = string.Empty;
        protected string _compLevels = string.Empty;
        protected string _listName = string.Empty;
        protected string _createFromLiveTemp = string.Empty;
        protected int _timeOut = 0;

        private const string TMP_GAL_TITLE = "Template Gallery";
        private const string COL_TITLE = "Title";
        private const string COL_URL = "URL";
        private const string COL_TEMPLATETYPE = "TemplateType";
        private const string COL_TEMPLATECATEGORY = "TemplateCategory";
        private const string COL_DESCRIPTION = "Description";
        private const string COL_MOREINFO = "MoreInfo";
        private const string COL_DISPLAYINSTORE = "Active";
        private const string COL_ATTACHMENT = "Attachements";

        protected void Page_Init(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite eSite = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb eWeb = eSite.OpenWeb(SPContext.Current.Web.ID))
                    {
                        _timeOut = Server.ScriptTimeout;
                        Server.ScriptTimeout = 3600;
                    }
                }
            });
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite eSite = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb eWeb = eSite.OpenWeb(SPContext.Current.Web.ID))
                    {
                        Server.ScriptTimeout = _timeOut;
                    }
                }
            });
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ManageFields();
            LoadLeftDivOptions();
            ManageWorkspacePanelUI();
        }

        private void ManageWorkspacePanelUI()
        {
            Guid lockweb = CoreFunctions.getLockedWeb(_cWeb);

            if (lockweb != Guid.Empty)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPWeb web = Web.Site.OpenWeb(lockweb))
                    {
                        //string wsType = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectWorkspaceType");
                        string nav = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectNavigation");
                        string perms = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectPermissions");

                        string sTemplates = CoreFunctions.getConfigSetting(web, "EPMLiveValidTemplates");

                        if (nav == "True" || nav == "False")
                        {
                            InputformsectionTopNavInheritance.Visible = false;
                            _nav = nav;
                        }

                        if (perms == "Unique" || perms == "Same")
                        {
                            InputformsectionPermission.Visible = false;
                            _perms = perms;
                        }

                    }
                });
            }
        }

        private void ManageFields()
        {
            _cSite = SPContext.Current.Site;
            _cWeb = SPContext.Current.Web;

            _solutionType = (!string.IsNullOrEmpty(Request.Params["type"])) ? Request.Params["type"] : string.Empty;
            _lstGuid = (!string.IsNullOrEmpty(Request.Params["list"])) ? Request.Params["list"] : string.Empty;
            _copyFrom = (!string.IsNullOrEmpty(Request.Params["copyfrom"])) ? Request.Params["copyfrom"] : string.Empty;

            if (!string.IsNullOrEmpty(_copyFrom))
            {
                SPList rqList = _cWeb.Lists[new Guid(_lstGuid)];
                if (rqList != null)
                {
                    SPListItem item = null;
                    try
                    {
                        item = rqList.GetItemById(int.Parse(_copyFrom));
                    }
                    catch { }

                    if (item != null)
                    {
                        _requestProjectName = item["Title"].ToString();
                        txtURL.Text = _requestProjectName;
                    }
                }
            }

            Guid lockedWeb = CoreFunctions.getLockedWeb(Web);
            _parentWebGuid_B = Web.ID.ToString("B");
            _parentWebUrl = Web.ServerRelativeUrl;
            _siteUrl = Site.Url;
            _siteHostName = Site.HostName;
            _currentWebRelativeUrl = Web.ServerRelativeUrl;
            _sourceWebId = Web.ID.ToString();
            _curWebUrl = Web.Url;
            _solutionStoreServiceProxyUrl = Web.Url + SOLUTION_STORE_PROXY_URL;
            _baseURL = Web.ServerRelativeUrl == "/" ? Web.ServerRelativeUrl : Web.ServerRelativeUrl + "/";

            _includeContentClientId = InputformsectionIncludeContent.ClientID;
            _moreInfoUrlClientId = txtURL.ClientID;
            _hasCreateSubSitePerm = Web.DoesUserHavePermissions(Web.CurrentUser.LoginName, SPBasePermissions.ManageSubwebs);
            _moreInfoUrl = Web.Url + MORE_INFO_URL;
            _smallParentUrl = Web.Url + SMALL_PARENT_URL;
            _tempGalRedirect = (Web.ServerRelativeUrl == "/" ? "" : Web.ServerRelativeUrl) + TEMP_GAL_REDIRECT;

            // get available features from corefunctions, which is currently hardcoded for testing purposes
            //ArrayList features = CoreFunctions.getActivatedFeatures();

            Act act = new Act(Web);
            ArrayList features = act.GetActivatedLevels();

            foreach (object array in features)
            {
                _featuresList += array.ToString() + ";#";
            }

            string _untranslatedGalleryToken = string.Empty;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                // go to locked web to find settings that specifies the template resource site
                using (SPWeb web = Site.OpenWeb(lockedWeb))
                {
                    try 
                    {
                        _untranslatedGalleryToken = CoreFunctions.getConfigSetting(web, "EPMLiveTemplateGalleryURL", false, true);
                        switch (_untranslatedGalleryToken)
                        {
                            case "{Site}":
                                _templateResourceUrl = _cWeb.ServerRelativeUrl;
                                break;
                            case "{site}":
                                _templateResourceUrl = _cWeb.ServerRelativeUrl;
                                break;
                            case "{Root}":
                                _templateResourceUrl = CoreFunctions.getConfigSetting(web, "EPMLiveTemplateGalleryURL", true, true);
                                break;
                            case "{root}":
                                _templateResourceUrl = CoreFunctions.getConfigSetting(web, "EPMLiveTemplateGalleryURL", true, true);
                                break;
                        }
                    }
                    catch
                    {
                        _templateResourceUrl = _cWeb.ServerRelativeUrl;
                    }

                    if (string.IsNullOrEmpty(_templateResourceUrl) || _templateResourceUrl == " ")
                    {
                        _templateResourceUrl = _cWeb.ServerRelativeUrl;
                    }

                    if (!string.IsNullOrEmpty(_templateResourceUrl))
                    {
                        using (SPWeb templateResourceWeb = Site.AllWebs[_templateResourceUrl])
                        {
                            _workengineSvcUrl = templateResourceWeb.Url + WORKENGINE_WS_URL;
                        }
                    }
                    else
                    {
                        _workengineSvcUrl = Web.Url + WORKENGINE_WS_URL;
                    }

                    // get comp levels to filter templates by comp levels
                    try
                    {
                        _compLevels = web.AllProperties["CompLevel"].ToString();
                    }
                    catch { }
                    try
                    {
                        _compLevels = web.AllProperties["complevel"].ToString();
                    }
                    catch { }
                    //_workengineSvcUrl = "http://" + web.Site.HostName + (web.ServerRelativeUrl == "/" ? "" : web.ServerRelativeUrl) + WORKENGINE_WS_URL;
                    _projectWorkspaceSetting = CoreFunctions.getConfigSetting(web, "EPMLiveNewProjectWorkspaceType");

                    GridGanttSettings gSettings = new GridGanttSettings(_cWeb.Lists[new Guid(_lstGuid)]);

                    _newItemName = !string.IsNullOrEmpty(_lstGuid) ? gSettings.NewMenuName : "workspace";
                    _newItemName = !string.IsNullOrEmpty(_newItemName) ? _newItemName : "workspace";
                    _newItemNameLwrCs = _newItemName.ToLower();
                    _listName = _cWeb.Lists[new Guid(_lstGuid)].Title.ToLower();
                    _templateType = _newItemNameLwrCs;

                    if (_templateType.Equals("department site", StringComparison.CurrentCultureIgnoreCase))
                    {
                        _templateType = "department";
                    }

                    SPList curList = _cWeb.Lists[new Guid(_lstGuid)];


                    if (!string.IsNullOrEmpty(gSettings.RollupLists))
                    {
                        string[] tRollupLists = gSettings.RollupLists.Split(',');
                        _rListName = tRollupLists[0].Split('|')[0];
                    }

                    _reqListName = gSettings.RequestList;
                    _doNotDelRequest = gSettings.DeleteRequest.ToString();

                    string epmLiveCreateNewSettings = CoreFunctions.getConfigSetting(web, "EPMLiveCreateNewSettings");

                    if (!string.IsNullOrEmpty(epmLiveCreateNewSettings))
                    {
                        EPMLiveCore.API.PropertyHash props = new EPMLiveCore.API.PropertyHash(CoreFunctions.getConfigSetting(web, "EPMLiveCreateNewSettings"), ";#", '|', '^');
                        if (props != null && props[0].Keys.Count > 0)
                        {
                            _defaultCreateNewOpt = props[0]["Default"].ToString();
                            _isCreateFromOnlineAvail = bool.Parse(props[1]["Online"].ToString());
                            _isCreateFromLocalAvail = bool.Parse(props[1]["Local"].ToString());
                            _isCreateFromExistingAvail = bool.Parse(props[1]["Existing"].ToString());
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

                    _createFromLiveTemp = CoreFunctions.getConfigSetting(web, "EPMLiveUseLiveTemplates");

                }
            });

        }

        private void LoadLeftDivOptions()
        {
            switch (_newItemNameLwrCs)
            {
                case "project":
                    Project_LoadWorkspaceType();
                    Project_LoadCreateNewWorkspaceFrom();
                    //Project_LoadTemplateCategories();
                    Project_InitializeFilterPnl();
                    break;
                case "template":
                    Template_LoadBrowseFrom();
                    //Template_LoadTemplateCategories();
                    //Template_LoadSolGalFilters();
                    Template_InitializeFilters();
                    break;
                case "workspace":
                    Project_LoadWorkspaceType();
                    Project_LoadCreateNewWorkspaceFrom();
                    //Project_LoadTemplateCategories();
                    Project_InitializeFilterPnl();
                    break;
                default:
                    Project_LoadWorkspaceType();
                    Project_LoadCreateNewWorkspaceFrom();
                    //Project_LoadTemplateCategories();
                    Project_InitializeFilterPnl();
                    break;
            }

        }

        #region Load left div for creating new project

        private void Project_LoadWorkspaceType()
        {
            pnlWorkspaceType.Controls.Add(new LiteralControl("<ul class='ulWorkspaceType'>"));
            string tempVal = "<li class=\"ms-create-listitem\"><div class=\"divWorkSpaceLink newWorkspace\"><a id=\"linkNewWorkspace\" class=\"sameColorLink \" href=\"#\" onclick=\"javascript:window.epmLiveCreateWorkspace.ClearAllSelection(\'workspace\');$(this).addClass(\'selectedLink\');window.epmLiveCreateWorkspace.SwitchToCreateNewWorkspaceView(); window.epmLiveCreateWorkspace.SetParentWebUrl(\'New\'); window.epmLiveCreateWorkspace.SetWorkspaceType(\'True\'); window.epmLiveCreateWorkspace.SetCreateDefault(); return false;\">In New Workspace</a></div></li>";
            pnlWorkspaceType.Controls.Add(new LiteralControl(tempVal));

            if (_projectWorkspaceSetting != "New")
            {
                tempVal = "<li class=\"ms-create-listitem\"><div class=\"divWorkSpaceLink oldWorkspace\"><a id=\"linkExistingWorkspace\" class=\"sameColorLink\" href=\"#\" onclick=\"javascript:window.epmLiveCreateWorkspace.ClearAllSelection(\'workspace\');$(this).addClass(\'selectedLink\');window.epmLiveCreateWorkspace.SwitchToExistingWorkspace(); window.epmLiveCreateWorkspace.SetParentWebUrl(\'Existing\'); window.epmLiveCreateWorkspace.SetWorkspaceType(\'False\'); return false;\">In Existing Workspace</a></li>";
                pnlWorkspaceType.Controls.Add(new LiteralControl(tempVal));
            }

            pnlWorkspaceType.Controls.Add(new LiteralControl("</ul>"));
        }

        private void Project_LoadCreateNewWorkspaceFrom()
        {
            pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl("<ul class='ulCreateNewWorkspaceFrom'>"));
            string tempVal;

            if (_projectWorkspaceSetting == "New" || _projectWorkspaceSetting == "")
            {
                // enable the default create type
                switch (_defaultCreateNewOpt)
                {
                    case "online":
                        _isCreateFromOnlineAvail = true;
                        break;
                    case "local":
                        _isCreateFromLocalAvail = true;
                        break;
                    case "existing":
                        _isCreateFromExistingAvail = true;
                        break;
                }

                if (_isCreateFromOnlineAvail)
                {
                    tempVal = "<li class=\"ms-create-listitem\"><div class=\"divCreateNewWorkspaceFrom onlineTemplates\"><a id=\"lnkOnlineTemps\" class=\"sameColorLink \" href=\"#\" onclick=\"javascript:window.epmLiveCreateWorkspace.ClearAllSelection(\'createNewWorkspaceFrom\'); $(this).addClass(\'selectedLink\'); window.epmLiveCreateWorkspace.ChangeToLoadingScreen(); window.epmLiveCreateWorkspace.GetOnlineTemps(); window.epmLiveCreateWorkspace.SetCreateNewFrom(\'onlineTemps\');window.epmLiveCreateWorkspace.SetupSearchLogic(\'online\'); return false;\">Online Gallery</a></div></li>";
                    pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl(tempVal));
                }

                if (_isCreateFromLocalAvail)
                {
                    tempVal = "<li class=\"ms-create-listitem\"><div class=\"divCreateNewWorkspaceFrom installedTemplates\"><a id=\"lnkInstalledTemps\" class=\"sameColorLink \" href=\"#\" onclick=\"javascript:window.epmLiveCreateWorkspace.ClearAllSelection(\'createNewWorkspaceFrom\'); $(this).addClass(\'selectedLink\'); window.epmLiveCreateWorkspace.DisplayInstalledTemps(); window.epmLiveCreateWorkspace.SetCreateNewFrom(\'installedTemps\'); window.epmLiveCreateWorkspace.SelectAllCategory(\'local\');window.epmLiveCreateWorkspace.SetupSearchLogic(\'local\'); return false;\">Local Gallery</a></div></li>";
                    pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl(tempVal));
                }

                if (_isCreateFromExistingAvail)
                {
                    tempVal = "<li class=\"ms-create-listitem\"><div class=\"divCreateNewWorkspaceFrom fromExistingWorkspace\"><a id=\"lnkFromExistingWorkspace\" class=\"sameColorLink \" href=\"#\" onclick=\"javascript:window.epmLiveCreateWorkspace.ClearAllSelection(\'createNewWorkspaceFrom\'); $(this).addClass(\'selectedLink\'); window.epmLiveCreateWorkspace.SwitchToCreateFromExistingWorkspace(); window.epmLiveCreateWorkspace.SetCreateNewFrom(\'existingWorkspace\'); return false;\">Existing Workspace</a></div></li>";
                    pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl(tempVal));
                }
            }
            pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl("</ul>"));
        }

        //private void Project_LoadTemplateCategories()
        //{
        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        //Guid lockedWeb = CoreFunctions.getLockedWeb(Web);
        //        using (SPWeb web = Web.Site.OpenWeb(_templateResourceUrl))
        //        {
        //            pnlFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
        //            SPList list = web.Lists.TryGetList(TMP_GAL_TITLE);
        //            string tempVal = string.Empty;

        //            if (list != null)
        //            {
        //                // add template types filters
        //                SPFieldMultiChoice fld = (SPFieldMultiChoice)list.Fields[list.Fields.GetFieldByInternalName(COL_TEMPLATETYPE).Id];

        //                List<string> matchingTemps = (from s in fld.Choices.OfType<string>()
        //                                              where s.Equals(_templateType, StringComparison.CurrentCultureIgnoreCase)
        //                                              select s).ToList<string>();

        //                if (matchingTemps.Count == 0)
        //                {
        //                    tempVal = "<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a id=\"lnkAllTypes\" class=\"sameColorLink typefilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"typefilters\");$(this).addClass(\"selectedLink\");UpdateSelectedTempType(\"All Types\");FilterTempGalTemplates();return false;' >All Types</a></div></li>";
        //                    pnlFilterBy.Controls.Add(new LiteralControl(tempVal));

        //                    foreach (string str in fld.Choices)
        //                    {
        //                        if (!string.IsNullOrEmpty(str))
        //                        {
        //                            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a class=\"sameColorLink typefilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"typefilters\");$(this).addClass(\"selectedLink\");UpdateSelectedTempType(\"" + str + "\");FilterTempGalTemplates();return false;' >" + str + "</a></div></li>";
        //                            pnlFilterBy.Controls.Add(new LiteralControl(tempVal));
        //                        }
        //                    }

        //                    // add space between types and category filters
        //                    tempVal = "<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a class=\"sameColorLink\" href=\"#\" onclick=\"return false;\"></a></div></li>";
        //                    pnlFilterBy.Controls.Add(new LiteralControl(tempVal));
        //                }


        //                // add template categories filters
        //                SPFieldMultiChoice catFld = list.Fields[list.Fields.GetFieldByInternalName(COL_TEMPLATECATEGORY).Id] as SPFieldMultiChoice;

        //                tempVal = "<li class=\"ms-create-listitem\"><div class=\"divBrowseFromLink\"><a id=\"lnkAllCategories\" class=\"sameColorLink categoryfilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"categoryfilters\");$(this).addClass(\"selectedLink\");UpdateSelectedTempCat(\"All Categories\");FilterTempGalTemplates();return false;' >All Categories</a></div></li>";
        //                pnlFilterBy.Controls.Add(new LiteralControl(tempVal));

        //                foreach (string str in catFld.Choices)
        //                {
        //                    if (!string.IsNullOrEmpty(str))
        //                    {
        //                        tempVal = "<li class=\"ms-create-listitem\"><div class=\"divBrowseFromLink\"><a class=\"sameColorLink categoryfilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"categoryfilters\");$(this).addClass(\"selectedLink\");UpdateSelectedTempCat(\"" + str + "\");FilterTempGalTemplates();return false;' >" + str + "</a></div></li>";
        //                        pnlFilterBy.Controls.Add(new LiteralControl(tempVal));
        //                    }
        //                }
        //            }

        //            pnlFilterBy.Controls.Add(new LiteralControl("</ul>"));
        //        }
        //    });
        //}

        private void Project_InitializeFilterPnl()
        {
            pnlFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
            pnlFilterBy.Controls.Add(new LiteralControl("</ul>"));
            pnlSolGalFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
            pnlSolGalFilterBy.Controls.Add(new LiteralControl("</ul>"));
            pnlEPMLiveFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
            pnlEPMLiveFilterBy.Controls.Add(new LiteralControl("</ul>"));
        }

        #endregion

        #region Load left div for creating new template

        private void Template_LoadBrowseFrom()
        {
            pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl("<ul class='ulCreateNewWorkspaceFrom'>"));
            string tempVal;

            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divCreateNewWorkspaceFrom \"><a id=\"lnkNewTempFrmOnline\" class=\"sameColorLink\" href=\"#\" onclick=\"javascript:window.epmLiveCreateWorkspace.ClearAllSelection(\'createNewWorkspaceFrom\'); $(this).addClass(\'selectedLink\'); window.epmLiveCreateWorkspace.ChangeToLoadingScreen(); window.epmLiveCreateWorkspace.GetOnlineTemps(); window.epmLiveCreateWorkspace.SetCreateNewFrom(\'onlineTemps\');window.epmLiveCreateWorkspace.SetupSearchLogic(\'online\'); return false;\">Online Gallery</a></div></li>";
            pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl(tempVal));

            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divCreateNewWorkspaceFrom \"><a id=\"lnkNewTempFrmLocal\" class=\"sameColorLink\" href=\"#\" onclick=\"javascript:window.epmLiveCreateWorkspace.ClearAllSelection(\'createNewWorkspaceFrom\'); $(this).addClass(\'selectedLink\'); window.epmLiveCreateWorkspace.DisplayInstalledTemps(); window.epmLiveCreateWorkspace.SetCreateNewFrom(\'installedTemps\'); window.epmLiveCreateWorkspace.SelectAllCategory(\'local\'); window.epmLiveCreateWorkspace.SetupSearchLogic(\'local\'); return false;\">Local Gallery</a></div></li>";
            pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl(tempVal));

            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divCreateNewWorkspaceFrom \"><a id=\"lnkNewTempFrmSolGal\" class=\"sameColorLink\" href=\"#\" onclick=\"javascript:window.epmLiveCreateWorkspace.ClearAllSelection(\'createNewWorkspaceFrom\'); $(this).addClass(\'selectedLink\'); window.epmLiveCreateWorkspace.DisplaySolGalTemps(); window.epmLiveCreateWorkspace.SetCreateNewFrom(\'solutionGal\'); window.epmLiveCreateWorkspace.SelectAllCategory(\'solgal\'); window.epmLiveCreateWorkspace.SetupSearchLogic(\'solgal\'); return false;\">Solution Gallery</a></div></li>";
            pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl(tempVal));

            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divCreateNewWorkspaceFrom \"><a id=\"lnkNewTempFrmExisting\" class=\"sameColorLink\" href=\"#\" onclick=\"javascript:window.epmLiveCreateWorkspace.ClearAllSelection(\'createNewWorkspaceFrom\'); $(this).addClass(\'selectedLink\'); window.epmLiveCreateWorkspace.SwitchToCreateFromExistingWorkspace(); window.epmLiveCreateWorkspace.SetCreateNewFrom(\'existingWorkspace\');return false;\">Existing Workspace</a></div></li>";
            pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl(tempVal));

            pnlCreateNewWorkspaceFrom.Controls.Add(new LiteralControl("</ul>"));
        }

        //private void Template_LoadTemplateCategories()
        //{
        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        //Guid lockedWeb = CoreFunctions.getLockedWeb(Web);
        //        using (SPWeb web = Web.Site.OpenWeb(_templateResourceUrl))
        //        {
        //            pnlFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
        //            SPList list = web.Lists.TryGetList(TMP_GAL_TITLE);
        //            string tempVal = string.Empty;

        //            if (list != null)
        //            {
        //                // add template types filters
        //                SPFieldMultiChoice fld = (SPFieldMultiChoice)list.Fields[list.Fields.GetFieldByInternalName(COL_TEMPLATETYPE).Id];

        //                List<string> matchingTemps = (from s in fld.Choices.OfType<string>()
        //                                              where s.Equals(_templateType, StringComparison.CurrentCultureIgnoreCase)
        //                                              select s).ToList<string>();

        //                if (matchingTemps.Count == 0)
        //                {
        //                    tempVal = "<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a id=\"lnkAllTypes\" class=\"sameColorLink typefilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"typefilters\");$(this).addClass(\"selectedLink\");UpdateSelectedTempType(\"All Types\");FilterTempGalTemplates();return false;' >All Types</a></div></li>";
        //                    pnlFilterBy.Controls.Add(new LiteralControl(tempVal));

        //                    foreach (string str in fld.Choices)
        //                    {
        //                        if (!string.IsNullOrEmpty(str))
        //                        {
        //                            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a class=\"sameColorLink typefilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"typefilters\");$(this).addClass(\"selectedLink\");UpdateSelectedTempType(\"" + str + "\");FilterTempGalTemplates();return false;' >" + str + "</a></div></li>";
        //                            pnlFilterBy.Controls.Add(new LiteralControl(tempVal));
        //                        }
        //                    }

        //                    // add space between types and category filters
        //                    tempVal = "<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a class=\"sameColorLink\" href=\"#\" onclick=\"return false;\" ></a></div></li>";
        //                    pnlFilterBy.Controls.Add(new LiteralControl(tempVal));
        //                }

        //                // add template categories filters
        //                SPFieldMultiChoice catFld = list.Fields[list.Fields.GetFieldByInternalName(COL_TEMPLATECATEGORY).Id] as SPFieldMultiChoice;

        //                tempVal = "<li class=\"ms-create-listitem\"><div class=\"divBrowseFromLink\"><a id=\"lnkAllCategories\" class=\"sameColorLink categoryfilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"categoryfilters\");$(this).addClass(\"selectedLink\");UpdateSelectedTempCat(\"All Categories\");FilterTempGalTemplates();return false;' >All Categories</a></div></li>";
        //                pnlFilterBy.Controls.Add(new LiteralControl(tempVal));

        //                foreach (string str in catFld.Choices)
        //                {
        //                    if (!string.IsNullOrEmpty(str))
        //                    {
        //                        tempVal = "<li class=\"ms-create-listitem\"><div class=\"divBrowseFromLink\"><a class=\"sameColorLink categoryfilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"categoryfilters\");$(this).addClass(\"selectedLink\");UpdateSelectedTempCat(\"" + str + "\");FilterTempGalTemplates();return false;' >" + str + "</a></div></li>";
        //                        pnlFilterBy.Controls.Add(new LiteralControl(tempVal));
        //                    }
        //                }
        //            }

        //            pnlFilterBy.Controls.Add(new LiteralControl("</ul>"));
        //        }
        //    });
        //}

        //private void Template_LoadSolGalFilters()
        //{
        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        //Guid lockedWeb = CoreFunctions.getLockedWeb(Web);
        //        using (SPWeb web = Web.Site.OpenWeb(_templateResourceUrl))
        //        {
        //            pnlSolGalFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
        //            List<string> solGalFilters = new List<string>();
        //            foreach (SPWebTemplate temp in web.GetAvailableWebTemplates((uint)web.Locale.LCID))
        //            {
        //                if (!string.IsNullOrEmpty(temp.DisplayCategory))
        //                {
        //                    foreach (string filter in temp.DisplayCategory.Split(new string[] { "#;" }, StringSplitOptions.RemoveEmptyEntries))
        //                    {
        //                        if (!solGalFilters.Contains(filter))
        //                        {
        //                            solGalFilters.Add(filter);
        //                        }
        //                    }
        //                }
        //            }

        //            string tempVal = string.Empty;

        //            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a id=\"lnkSolGalAllTypes\" class=\"sameColorLink solGalTypeFilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"solGalTypeFilter\");$(this).addClass(\"selectedLink\");UpdateSelectedTempType(\"All Types\");FilterSolGalTemplates();return false;'>All Types</a></div></li>";
        //            pnlSolGalFilterBy.Controls.Add(new LiteralControl(tempVal));

        //            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a class=\"sameColorLink solGalTypeFilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"solGalTypeFilter\");$(this).addClass(\"selectedLink\");UpdateSelectedTempType(\"Site\");FilterSolGalTemplates();return false;'>Site</a></div></li>";
        //            pnlSolGalFilterBy.Controls.Add(new LiteralControl(tempVal));

        //            // add space between types and category filters
        //            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divFilterByLink\"><a class=\"sameColorLink\" href=\"#\" onclick=\"return false\"></a></div></li>";
        //            pnlSolGalFilterBy.Controls.Add(new LiteralControl(tempVal));

        //            // add template categories filters
        //            tempVal = "<li class=\"ms-create-listitem\"><div class=\"divBrowseFromLink\"><a id=\"lnkSolGalAllCategories\" class=\"sameColorLink solGalCategoryFilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"solGalCategoryFilter\");$(this).addClass(\"selectedLink\");UpdateSelectedTempCat(\"All Categories\");FilterSolGalTemplates();return false;' >All Categories</a></div></li>";
        //            pnlSolGalFilterBy.Controls.Add(new LiteralControl(tempVal));

        //            if (solGalFilters.Count > 0)
        //            {
        //                foreach (string str in solGalFilters)
        //                {
        //                    if (!string.IsNullOrEmpty(str))
        //                    {
        //                        tempVal = "<li class=\"ms-create-listitem\"><div class=\"divBrowseFromLink\"><a class=\"sameColorLink solGalCategoryFilter\" href=\"#\" onclick='javaScript:ClearAllSelection(\"solGalCategoryFilter\");$(this).addClass(\"selectedLink\");UpdateSelectedTempCat(\"" + str + "\");FilterSolGalTemplates();return false;' >" + str + "</a></div></li>";
        //                        pnlSolGalFilterBy.Controls.Add(new LiteralControl(tempVal));
        //                    }
        //                }
        //            }

        //            pnlSolGalFilterBy.Controls.Add(new LiteralControl("</ul>"));
        //        }
        //    });

        //}

        // this loads online tempalte filters
        private void Template_InitializeFilters()
        {
            pnlFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
            pnlFilterBy.Controls.Add(new LiteralControl("</ul>"));
            pnlSolGalFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
            pnlSolGalFilterBy.Controls.Add(new LiteralControl("</ul>"));
            pnlEPMLiveFilterBy.Controls.Add(new LiteralControl("<ul class='ulFilterBy'>"));
            pnlEPMLiveFilterBy.Controls.Add(new LiteralControl("</ul>"));
        }

        #endregion

        #region Helper Methods


        #endregion
    }
}
