using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore.Controls.Navigation.Providers;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     abstract factory class for different
    ///     workspace factories
    /// </summary>
    public abstract class WorkspaceFactory
    {
        #region Constructors (1)

        protected WorkspaceFactory(string data)
        {
            // param "data" should be
            // in XML format like below
            // ===========================
            //<Data>
            //<Param key="IsStandAlone"></Param>
            //<Param key="SiteTitle"></Param>
            //<Param key="SiteURL"></Param>
            //<Param key="TemplateId"></Param>
            //<Param key="UniquePermission"></Param>
            //<Param key="ContextWebUrl"></Param>
            //<Param key="ListId"></Param>
            //<Param key="ItemId"></Param>
            //</Data>

            _createParams = data;
            _xmlDataMgr = new XMLDataManager(data);
        }

        #endregion Constructors

        #region base class properties and fields

        protected const string temp_gal_title = "Template Gallery";
        protected string _createParams = string.Empty;
        protected Guid _createdWebId = Guid.Empty;
        protected string _createdWebTitle = string.Empty;
        protected string _createdWebUrl = string.Empty;
        protected string _createdWebServerRelativeUrl = string.Empty;
        protected List<string> _lstSolutionsToBeRemoved = new List<string>();

        protected XMLDataManager _xmlDataMgr;
        protected StringBuilder _xmlResult = new StringBuilder();

        protected bool _isStandAlone
        {
            get
            {
                bool bAlone = false;
                bool.TryParse(_xmlDataMgr.GetPropVal("IsStandAlone"), out bAlone);
                return bAlone;
            }
        }

        protected bool UniquePermission
        {
            get
            {
                bool unique = false;
                try
                {
                    unique = bool.Parse(_xmlDataMgr.GetPropVal("UniquePermission"));
                }
                catch
                {
                }

                return unique;
            }
        }

        protected Guid ParentWebId
        {
            get
            {
                if (_isStandAlone)
                {
                    return WebId;
                }
                Guid tempParentWebId = Guid.Empty;
                if (WebId != Guid.Empty &&
                    AttachedItemListId != Guid.Empty)
                {
                    SPSecurity.RunWithElevatedPrivileges(() =>
                    {
                        using (var s = new SPSite(SiteId))
                        {
                            using (SPWeb w = s.OpenWeb(WebId))
                            {
                                // if there is a parent site lookup, 
                                // find that web and use its url as the new parent web url
                                SPList list = null;
                                SPListItem pItem = null;
                                SPFieldLookup pFld = null;
                                SPFieldLookupValueCollection valColl = null;
                                try
                                {
                                    list = w.Lists[AttachedItemListId];
                                    pItem = list.GetItemById(AttachedItemId);
                                }
                                catch
                                {
                                }
                                var settings = new GridGanttSettings(list);
                                string sPFldName = settings.WorkspaceParentSiteLookup;
                                if (list != null && !string.IsNullOrEmpty(sPFldName) && sPFldName != "None")
                                {
                                    try
                                    {
                                        pFld = (SPFieldLookup)list.Fields.GetFieldByInternalName(sPFldName);
                                        var v = pItem[sPFldName];
                                        if (v != null)
                                        {
                                            valColl = new SPFieldLookupValueCollection(pItem[sPFldName].ToString());
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    if (pFld != null && valColl != null)
                                    {
                                        tempParentWebId = WorkspaceData.GetParentWebId(SiteId, WebId,
                                            new Guid(pFld.LookupList), valColl[0].LookupId);
                                        if (tempParentWebId == Guid.Empty)
                                        {
                                            throw new Exception(
                                                "Parent site either does not exist or is currently being provisioned. No item workspace will be created.");
                                        }
                                    }
                                }

                                tempParentWebId = tempParentWebId == Guid.Empty ? WebId : tempParentWebId;
                            }
                        }
                    });
                }
                return tempParentWebId;
            }
        }

        protected int AttachedItemId
        {
            get
            {
                int id = -1;
                if (!string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("AttachedItemId")))
                {
                    try
                    {
                        id = int.Parse(_xmlDataMgr.GetPropVal("AttachedItemId"));
                    }
                    catch
                    {
                    }
                }

                return id;
            }
        }

        protected Guid AttachedItemListId
        {
            get
            {
                Guid id = Guid.Empty;
                if (!string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("AttachedItemListGuid")))
                {
                    try
                    {
                        id = Guid.Parse(_xmlDataMgr.GetPropVal("AttachedItemListGuid"));
                    }
                    catch
                    {
                    }
                }

                return id;
            }
        }

        protected string AttachedItemTitle
        {
            get
            {
                string title = string.Empty;
                title = _xmlDataMgr.GetPropVal("SiteTitle");
                return title;
            }
        }

        protected Guid WebId
        {
            get
            {
                Guid id = Guid.Empty;
                Guid.TryParse(_xmlDataMgr.GetPropVal("WebId"), out id);
                return id;
            }
        }

        protected Guid TempGalWebId
        {
            get
            {
                Guid id = Guid.Empty;
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        var lockedWId = Guid.Empty;
                        using (var s = new SPSite(SiteId))
                        {
                            using (var w = s.OpenWeb(WebId))
                            {
                                if (w.Exists)
                                {
                                    lockedWId = CoreFunctions.getLockedWeb(w);
                                }
                            }
                            using (var lw = s.OpenWeb(lockedWId))
                            {
                                if (lw.Exists)
                                {
                                    var token = CoreFunctions.getConfigSetting(
                                        lw, "EPMLiveTemplateGalleryURL", false, true);
                                    switch (token)
                                    {
                                        case "{Site}":
                                            id = WebId;
                                            break;
                                        case "{site}":
                                            id = WebId;
                                            break;
                                        case "{Root}":
                                            id = lw.ID;
                                            break;
                                        case "{root}":
                                            id = lw.ID;
                                            break;
                                    }
                                }
                            }
                        }
                    });
                }
                catch
                {
                    id = Guid.Empty;
                }

                return id;
            }
        }

        protected Guid SiteId
        {
            get
            {
                Guid id = Guid.Empty;
                Guid.TryParse(_xmlDataMgr.GetPropVal("SiteId"), out id);
                return id;
            }
        }

        protected int CreatorId
        {
            get
            {
                int creatorId = -1;
                string id = _xmlDataMgr.GetPropVal("CreatorId");
                if (!string.IsNullOrEmpty(id))
                {
                    creatorId = int.Parse(id);
                }

                return creatorId;
            }
        }

        #endregion

        #region Abstract Methods To Be Overridden

        /// <summary>
        ///     The main method that figures
        ///     out if we're creating from online/downloaded template
        ///     and whether the ws is standalone or based on item
        /// </summary>
        /// <returns></returns>
        public abstract ICreatedWorkspaceInfo CreateWorkspace();

        #endregion

        #region Abstract Base Methods

        public void RemoveSolutionFromGallery(SPSite es, SPWeb ew)
        {
            if (_lstSolutionsToBeRemoved.Count > 0)
            {
                // if we're not creating a temp or workspace from web.availabletemps, then remove the 
                // newly created and acivated templates
                ew.Site.AllowUnsafeUpdates = true;
                ew.Site.RootWeb.AllowUnsafeUpdates = true;
                ew.AllowUnsafeUpdates = true;

                ew.Site.CatchAccessDeniedException = false;

                SPList solGallery = es.GetCatalog(SPListTemplateType.SolutionCatalog);

                // deactivate solution(s) in solution gallery
                // =======================================
                var delSols = new List<SPUserSolution>();

                delSols = (from s in es.Solutions.OfType<SPUserSolution>()
                           where _lstSolutionsToBeRemoved.Contains(s.Name.Replace(".wsp", ""))
                           select s).ToList<SPUserSolution>();

                if (delSols.Count > 0)
                {
                    foreach (SPUserSolution sol in delSols)
                    {
                        es.Solutions.Remove(sol);
                    }
                }
                // delete solution(s) from solution gallery
                // =====================================
                var delItems = new List<SPListItem>();

                delItems = (from i in solGallery.Items.OfType<SPListItem>()
                            where _lstSolutionsToBeRemoved.Contains(i.File.Name.Replace(".wsp", ""))
                            select i).ToList<SPListItem>();

                if (delItems.Count > 0)
                {
                    foreach (SPListItem i in delItems)
                    {
                        i.Delete();
                    }
                }
            }
        }

        public bool UserCanCreateSubSite(SPSite cSite, string childWebRelUrl)
        {
            bool hasPerm = false;
            childWebRelUrl = GetSiteRelativeWebUrl(childWebRelUrl, cSite);
            try
            {
                using (SPWeb web = cSite.OpenWeb(childWebRelUrl))
                {
                    hasPerm = web.DoesUserHavePermissions(SPBasePermissions.ManageSubwebs);
                }
            }
            catch
            {
            }

            return hasPerm;
        }

        public string GetSiteRelativeWebUrl(string targetWebUrl, SPSite cSite)
        {
            string retVal = targetWebUrl.Replace("default.aspx", "");

            if (retVal.StartsWith("/"))
            {
                retVal = cSite.MakeFullUrl(retVal);
            }

            // http://www.google.com
            // e.g., http://contoso.com/sites/testsite/default.aspx
            if (retVal.Contains(cSite.Url))
            {
                retVal = retVal.Replace(cSite.Url, "");
            }

            // e.g., /sites/testsite/
            if (retVal.EndsWith("/"))
            {
                retVal = retVal.Remove(retVal.LastIndexOf('/'));
            }

            if (retVal.StartsWith("/"))
            {
                retVal = retVal.Remove(retVal.IndexOf('/'), 1);
            }

            return retVal;
        }

        public void InstallOnlineSolutionByFeatureXml(string xmlString, string rootFilePath, out string tempName,
            SPSite cESite, SPWeb cEWeb)
        {
            tempName = string.Empty;
            bool tempNameAssigned = false;

            XDocument featureXml = XDocument.Parse(xmlString);
            IEnumerable<XElement> files = featureXml.Root.Descendants("File");

            foreach (XElement file in files)
            {
                if (!tempNameAssigned)
                {
                    tempName = file.Attribute("Name").Value;
                    tempNameAssigned = true;
                }

                InstallFileByFileNode(file, rootFilePath, cESite, cEWeb);
            }
        }

        public void InstallFileByFileNode(XElement file, string rootFilePath, SPSite cESite, SPWeb cEWeb)
        {
            string tempSolGuid = Guid.NewGuid().ToString("N");
            byte[] fileBytes;
            SPList solGallery = null;

            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");

                switch (file.Attribute("Type").Value)
                {
                    case "Solution":
                        fileBytes = client.DownloadData(rootFilePath + "/" + file.Attribute("Name").Value);
                        string fileDestination = (cEWeb.Site.ServerRelativeUrl == "/"
                            ? ""
                            : cEWeb.Site.ServerRelativeUrl) + "/_catalogs/solutions/" + tempSolGuid + ".wsp";
                        SPFile newSolutionfile = null;

                        cESite.CatchAccessDeniedException = false;
                        cESite.AllowUnsafeUpdates = true;
                        cESite.RootWeb.AllowUnsafeUpdates = true;
                        cEWeb.AllowUnsafeUpdates = true;
                        cEWeb.Update();

                        solGallery = cESite.GetCatalog(SPListTemplateType.SolutionCatalog);
                        newSolutionfile = solGallery.RootFolder.Files.Add(fileDestination, fileBytes);
                        SPUserSolution solution = cEWeb.Site.Solutions.Add(newSolutionfile.Item.ID);
                        EnsureSiteCollectionFeaturesActivated(solution, cESite);
                        cEWeb.Update();
                        _lstSolutionsToBeRemoved.Add(tempSolGuid);
                        fileBytes = null;
                        break;
                    case "List":
                        break;
                    default:
                        break;
                }
            }
        }

        public void EnsureSiteCollectionFeaturesActivated(SPUserSolution solution, SPSite site)
        {
            SPUserSolutionCollection solutions = site.Solutions;
            List<SPFeatureDefinition> oListofFeatures = GetFeatureDefinitionsInSolution(solution, site);
            foreach (SPFeatureDefinition def in oListofFeatures)
            {
                if (((def.Scope == SPFeatureScope.Site) && def.ActivateOnDefault) && (site.Features[def.Id] == null))
                {
                    try
                    {
                        site.Features.Add(def.Id, false, SPFeatureDefinitionScope.Site);
                        //site.Features.Add(def.Id);
                    }
                    catch
                    {
                    }
                }
            }
        }

        public List<SPFeatureDefinition> GetFeatureDefinitionsInSolution(SPUserSolution solution, SPSite site)
        {
            var list = new List<SPFeatureDefinition>();

            foreach (SPFeatureDefinition definition in site.FeatureDefinitions)
            {
                if (definition.SolutionId.Equals(solution.SolutionId))
                {
                    list.Add(definition);
                }
            }
            return list;
        }

        public bool EnsureWebInitFeature(string sWebId, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            bool success = true;

            if (sWebId != null)
            {
                try
                {
                    bool workEngineListEventsFeatEnabled = false;

                    if (sWebId.Equals(cWeb.ID))
                    {
                        foreach (SPFeature feat in cWeb.Features)
                        {
                            if (feat.DefinitionId.Equals(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61")))
                            {
                                workEngineListEventsFeatEnabled = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        using (SPWeb w = cSite.OpenWeb(new Guid(sWebId)))
                        {
                            foreach (SPFeature feat in w.Features)
                            {
                                if (feat.DefinitionId.Equals(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61")))
                                {
                                    workEngineListEventsFeatEnabled = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!workEngineListEventsFeatEnabled)
                    {
                        using (SPWeb tempWeb = cESite.OpenWeb(new Guid(sWebId)))
                        {
                            tempWeb.Site.AllowUnsafeUpdates = true;
                            tempWeb.Site.RootWeb.AllowUnsafeUpdates = true;
                            tempWeb.AllowUnsafeUpdates = true;
                            tempWeb.Features.Add(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61"));
                            tempWeb.Update();
                        }
                    }
                    else
                    {
                        using (SPWeb tempWeb = cESite.OpenWeb(new Guid(sWebId)))
                        {
                            tempWeb.Site.AllowUnsafeUpdates = true;
                            tempWeb.Site.RootWeb.AllowUnsafeUpdates = true;
                            tempWeb.AllowUnsafeUpdates = true;
                            tempWeb.Features.Remove(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61"));
                            tempWeb.Features.Add(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61"));
                            tempWeb.Update();
                        }
                    }
                }
                catch
                {
                    success = false;
                }
            }

            return success;
        }

        public bool EnsureFieldsInRequestItem()
        {
            bool success = false;

            if (AttachedItemListId == Guid.Empty || AttachedItemId == -1)
            {
                return success;
            }

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var es = new SPSite(SiteId))
                {
                    using (SPWeb ew = es.OpenWeb(WebId))
                    {
                        ew.AllowUnsafeUpdates = true;
                        SPList attachedItemList = ew.Lists[AttachedItemListId];
                        if (!FieldExistsInList(attachedItemList, "WorkspaceUrl"))
                        {
                            SPList newList = ew.Lists[attachedItemList.ID];
                            string fldWorkspaceUrlIntName = newList.Fields.Add("WorkspaceUrl", SPFieldType.URL, false);
                            var fldWorkspaceUrl = newList.Fields.GetFieldByInternalName(fldWorkspaceUrlIntName) as SPFieldUrl;
                            fldWorkspaceUrl.Hidden = true;
                            fldWorkspaceUrl.Update();
                        }

                        //if (!FieldExistsInList(attachedItemList, "ChildItem"))
                        //{
                        //    SPList newList = ew.Lists[attachedItemList.ID];
                        //    string fldChildItemIntName = newList.Fields.Add("ChildItem", SPFieldType.Text, false);
                        //    SPFieldText fldChildItem = newList.Fields.GetFieldByInternalName(fldChildItemIntName) as SPFieldText;
                        //    fldChildItem.Hidden = true;
                        //    fldChildItem.Update();
                        //}

                        var newVal = new SPFieldUrlValue();
                        newVal.Url = _createdWebUrl;
                        newVal.Description = newVal.Url.Substring(newVal.Url.LastIndexOf("/") + 1);
                        SPList spList = ew.Lists[attachedItemList.ID];
                        SPListItem item = spList.GetItemById(AttachedItemId);
                        item[spList.Fields.GetFieldByInternalName("WorkspaceUrl").Id] = newVal;

                        item.SystemUpdate();
                        success = true;
                    }
                }
            });

            return success;
        }

        private void RenameProjectFileByProjectItem(SPWeb web, string oldName, string newName)
        {
            var projectSchedule = (SPDocumentLibrary)web.Lists.TryGetList("Project Schedules");
            if (projectSchedule != null)
            {
                foreach (SPListItem item in projectSchedule.Items)
                {
                    if (Path.GetFileNameWithoutExtension(item["Name"].ToString()).Equals(oldName))
                    {
                        item.File.CheckOut();
                        item["Name"] = Path.ChangeExtension(newName, "mpp");
                        item.SystemUpdate();
                        item.File.CheckIn("");
                        break;
                    }
                }
            }
        }

        private bool FieldExistsInList(SPList list, string fieldInternalName)
        {
            SPField testFld = null;
            try
            {
                testFld = list.Fields.GetFieldByInternalName(fieldInternalName);
            }
            catch
            {
            }
            return (testFld != null);
        }

        private string GetSafeTitle(string grpName)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(grpName))
            {
                result = grpName;
                result = result.Replace("\"", "")
                    .Replace("/", "")
                    .Replace("\\", "")
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace(":", "")
                    .Replace("|", "")
                    .Replace("<", "")
                    .Replace(">", "")
                    .Replace("+", "")
                    .Replace("=", "")
                    .Replace(";", "")
                    .Replace(",", "")
                    .Replace("?", "")
                    .Replace("*", "")
                    .Replace("'", "")
                    .Replace("@", "");
            }

            return result;
        }

        public void BaseProvision(SPSite site, SPWeb web, SPSite cESite, SPWeb cEWeb)
        {   
            string sResultWebUrl = string.Empty;
            SPWeb parentWeb = site.OpenWeb(ParentWebId);

            site.CatchAccessDeniedException = false;
            site.RootWeb.AllowUnsafeUpdates = true;
            web.AllowUnsafeUpdates = true;
            web.Site.AllowUnsafeUpdates = true;

            string siteTitle = _xmlDataMgr.GetPropVal("SiteTitle");
            siteTitle = GetSafeTitle(siteTitle);
            string siteUrl = siteTitle;
            string templateName = _xmlDataMgr.GetPropVal("TemplateName");
            bool isStandAlone = bool.Parse(_xmlDataMgr.GetPropVal("IsStandAlone"));
            string siteOwnerName = web.AllUsers.GetByID(CreatorId).LoginName;
            bool uniquePermission = bool.Parse(_xmlDataMgr.GetPropVal("UniquePermission"));
            bool inheritTopLink = false;

            string err = string.Empty;
            if (parentWeb.DoesUserHavePermissions(siteOwnerName, SPBasePermissions.ManageSubwebs))
            {
                if (parentWeb.ID.Equals(web.ID))
                {
                    cESite.AllowUnsafeUpdates = true;
                    cESite.RootWeb.AllowUnsafeUpdates = true;
                    cEWeb.AllowUnsafeUpdates = true;
                    cEWeb.Update();
                    // assuming uniquepermission means we are creating from an item,
                    // we must pass in item
                    if (uniquePermission)
                    {
                        if (!isStandAlone)
                        {
                            err = CoreFunctions.CreateSiteFromItem(siteTitle, siteUrl, templateName, siteOwnerName, true,
                                inheritTopLink,
                                cEWeb, web, AttachedItemListId, AttachedItemId, out _createdWebId, out _createdWebUrl, out _createdWebServerRelativeUrl,
                                out _createdWebTitle);
                        }
                        else
                        {
                            err = CoreFunctions.createSite(siteTitle, siteUrl, templateName, siteOwnerName, true,
                                inheritTopLink, cEWeb, out _createdWebId, out _createdWebUrl, out _createdWebServerRelativeUrl, out _createdWebTitle);
                        }
                    }
                    else
                    {
                        if (!isStandAlone)
                        {
                            err = CoreFunctions.CreateSiteFromItem(siteTitle, siteUrl, templateName, siteOwnerName,
                                false, inheritTopLink,
                                cEWeb, web, AttachedItemListId, AttachedItemId, out _createdWebId, out _createdWebUrl, out _createdWebServerRelativeUrl,
                                out _createdWebTitle);
                        }
                        else
                        {
                            err = CoreFunctions.createSite(siteTitle, siteUrl, templateName, siteOwnerName, false,
                                inheritTopLink, cEWeb, out _createdWebId, out _createdWebUrl, out _createdWebServerRelativeUrl, out _createdWebTitle);
                        }
                    }
                }
                else
                {
                    using (SPWeb eParentWeb = cESite.OpenWeb(parentWeb.ID))
                    {
                        eParentWeb.AllowUnsafeUpdates = true;
                        cESite.RootWeb.AllowUnsafeUpdates = true;
                        eParentWeb.Update();
                        if (uniquePermission)
                        {
                            if (!isStandAlone)
                            {
                                //WorkspaceData.SendStartSignalsToDB(SiteId, WebId, AttachedItemListId, AttachedItemId);
                                err = CoreFunctions.CreateSiteFromItem(siteTitle, siteUrl, templateName, siteOwnerName, true, inheritTopLink,
                                    eParentWeb, web, AttachedItemListId, AttachedItemId, out _createdWebId, out _createdWebServerRelativeUrl,
                                    out _createdWebUrl, out _createdWebTitle);
                            }
                            else
                            {
                                err = CoreFunctions.createSite(siteTitle, siteUrl, templateName, siteOwnerName, true,
                                    inheritTopLink, cEWeb, out _createdWebId, out _createdWebUrl, out _createdWebServerRelativeUrl, out _createdWebTitle);
                            }
                        }
                        else
                        {
                            if (!_isStandAlone)
                            {
                                err = CoreFunctions.CreateSiteFromItem(siteTitle, siteUrl, templateName, siteOwnerName, false, inheritTopLink,
                                    eParentWeb, web, AttachedItemListId, AttachedItemId, out _createdWebId, out _createdWebServerRelativeUrl,
                                    out _createdWebUrl, out _createdWebTitle);
                            }
                            else
                            {
                                //WorkspaceData.SendStartSignalsToDB(SiteId, WebId, AttachedItemListId, AttachedItemId);
                                err = CoreFunctions.createSite(siteTitle, siteUrl, templateName, siteOwnerName, false,
                                    inheritTopLink, eParentWeb, out _createdWebId, out _createdWebUrl, out _createdWebServerRelativeUrl,
                                    out _createdWebTitle);
                            }
                        }
                    }
                }
            }
            else
            {
                err = "1:You do not have have permission to create subsite on the parent web selected.";
            }

            // try to recreate if error says we need to activate features
            if (err.Substring(0, 1) == "1")
            {
                if (err.Substring(2).StartsWith("The site template requires that the Feature") &&
                    err.EndsWith("be activated in the site collection."))
                {
                    int trys = 0;

                    while (err.Substring(2).StartsWith("The site template requires that the Feature") &&
                           err.EndsWith("be activated in the site collection.") && (trys < 5))
                    {
                        #region retry workspace creation

                        var neededFeatureId = new Guid(err.Substring(err.IndexOf("{") + 1).Split('}')[0]);
                        cESite.Features.Add(neededFeatureId, true);
                        if (parentWeb.DoesUserHavePermissions(siteOwnerName, SPBasePermissions.ManageSubwebs))
                        {
                            if (parentWeb.ID.Equals(web.ID))
                            {
                                cESite.AllowUnsafeUpdates = true;
                                cESite.RootWeb.AllowUnsafeUpdates = true;
                                cEWeb.AllowUnsafeUpdates = true;
                                cEWeb.Update();
                                // assuming uniquepermission means we are creating from an item,
                                // we must pass in item
                                if (uniquePermission)
                                {
                                    if (!isStandAlone)
                                    {
                                        //WorkspaceData.SendStartSignalsToDB(SiteId, WebId, AttachedItemListId, AttachedItemId);
                                        err = CoreFunctions.CreateSiteFromItem(siteTitle, siteUrl, templateName, siteOwnerName, true, inheritTopLink,
                                            cEWeb, web, AttachedItemListId, AttachedItemId, out _createdWebId, out _createdWebServerRelativeUrl,
                                            out _createdWebUrl, out _createdWebTitle);
                                    }
                                    else
                                    {
                                        err = CoreFunctions.CreateSiteFromItem(siteTitle, siteUrl, templateName, siteOwnerName, true, inheritTopLink,
                                            cEWeb, web, AttachedItemListId, AttachedItemId, out _createdWebId, out _createdWebServerRelativeUrl,
                                            out _createdWebUrl, out _createdWebTitle);
                                    }
                                }
                                else
                                {
                                    if (!isStandAlone)
                                    {
                                        err = CoreFunctions.CreateSiteFromItem(siteTitle, siteUrl, templateName, siteOwnerName, false, inheritTopLink,
                                            cEWeb, web, AttachedItemListId, AttachedItemId, out _createdWebId, out _createdWebServerRelativeUrl,
                                            out _createdWebUrl, out _createdWebTitle);
                                    }
                                    else
                                    {
                                        //WorkspaceData.SendStartSignalsToDB(SiteId, WebId, AttachedItemListId, AttachedItemId);
                                        err = CoreFunctions.createSite(siteTitle, siteUrl, templateName, siteOwnerName,
                                            false, inheritTopLink, cEWeb, out _createdWebId, out _createdWebUrl, out _createdWebServerRelativeUrl,
                                            out _createdWebTitle);
                                    }
                                }
                            }
                            else
                            {
                                using (SPWeb eParentWeb = cESite.OpenWeb(parentWeb.ID))
                                {
                                    eParentWeb.AllowUnsafeUpdates = true;
                                    cESite.RootWeb.AllowUnsafeUpdates = true;
                                    eParentWeb.Update();
                                    if (uniquePermission)
                                    {
                                        if (!isStandAlone)
                                        {
                                            //WorkspaceData.SendStartSignalsToDB(SiteId, WebId, AttachedItemListId, AttachedItemId);
                                            err = CoreFunctions.CreateSiteFromItem(siteTitle, siteUrl, templateName, siteOwnerName, true, inheritTopLink,
                                                eParentWeb, web, AttachedItemListId, AttachedItemId, out _createdWebId, out _createdWebServerRelativeUrl,
                                                out _createdWebUrl, out _createdWebTitle);
                                        }
                                        else
                                        {
                                            err = CoreFunctions.createSite(siteTitle, siteUrl, templateName,
                                                siteOwnerName, true, inheritTopLink, cEWeb, out _createdWebId,
                                                out _createdWebUrl, out _createdWebServerRelativeUrl, out _createdWebTitle);
                                        }
                                    }
                                    else
                                    {
                                        if (!_isStandAlone)
                                        {
                                            err = CoreFunctions.CreateSiteFromItem(siteTitle, siteUrl, templateName, siteOwnerName, false, inheritTopLink,
                                                eParentWeb, web, AttachedItemListId, AttachedItemId, out _createdWebId, out _createdWebServerRelativeUrl,
                                                out _createdWebUrl, out _createdWebTitle);
                                        }
                                        else
                                        {
                                            //WorkspaceData.SendStartSignalsToDB(SiteId, WebId, AttachedItemListId, AttachedItemId);
                                            err = CoreFunctions.createSite(siteTitle, siteUrl, templateName,
                                                siteOwnerName, false, inheritTopLink, eParentWeb, out _createdWebId,
                                                out _createdWebUrl, out _createdWebServerRelativeUrl, out _createdWebTitle);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new Exception(
                                "You do have have permission to create subsite on the parent web selected.");
                        }

                        trys++;

                        #endregion
                    }

                    if (err.Substring(0, 1) == "1")
                    {
                        throw new Exception(err.Substring(2));
                    }
                }
                else
                {   
                    throw new Exception(err.Substring(2));
                }
            }
            else
            {
                if (AttachedItemId != -1)
                {
                    WorkspaceData.SendCompletedSignalsToDB(SiteId, web, parentWeb, AttachedItemListId, AttachedItemId,
                        _createdWebId, _createdWebServerRelativeUrl, _createdWebTitle);
                }
                else
                {
                    WorkspaceData.SendCompletedSignalsToDB(SiteId, parentWeb, _createdWebId, _createdWebServerRelativeUrl, _createdWebTitle);
                }
            }
            if (parentWeb != null && !parentWeb.ID.Equals(web.ID))
            {
                parentWeb.Dispose();
            }
        }

        public void BuildWebInfoXml()
        {
            _xmlResult.Append("<WebInfo>");
            _xmlResult.Append("<ID><![CDATA[" + _createdWebId + "]]></ID>");
            _xmlResult.Append("<ServerRelativeUrl>" + _createdWebUrl + "</ServerRelativeUrl>");
            _xmlResult.Append("</WebInfo>");
        }

        /// <summary>
        ///     Notifies user that workspace has been created
        /// </summary>
        public void Notify(SPWeb cWeb)
        {
            SPUser originalUser = cWeb.AllUsers.GetByID(CreatorId);
            if (AttachedItemId != -1)
            {
                SPListItem li = cWeb.Lists[AttachedItemListId].GetItemById(AttachedItemId);
                // send notification and email user
                APIEmail.QueueItemMessage(6, true, BuildEmailData(_createdWebUrl, _createdWebTitle),
                    new[] { originalUser.ID.ToString() }, null, false, true, li, originalUser, true);
            }
            else
            {
                APIEmail.QueueItemMessage(6, true, BuildEmailData(_createdWebUrl, _createdWebTitle),
                    new[] { originalUser.ID.ToString() }, null, false, true, cWeb, originalUser, true);
            }
        }

        public void NotifyWsGeneralError(SPWeb cWeb, string error)
        {
            SPUser originalUser = cWeb.AllUsers.GetByID(CreatorId);
            APIEmail.QueueItemMessage(7, true, BuildErrorEmailData(_createdWebTitle, error),
                new[] { originalUser.ID.ToString() }, null, false, true, cWeb, originalUser, true);

        }

        public void AddToFavorites()
        {
            if (_isStandAlone)
            {
                // TODO: add ws info to favorites table in db
                WorkspaceData.AddToFRF(SiteId, _createdWebId, _createdWebTitle, _createdWebServerRelativeUrl, CreatorId, 4);
            }
            else
            {
                WorkspaceData.AddToFRF(SiteId, _createdWebId, _createdWebTitle, _createdWebServerRelativeUrl, CreatorId, 4, AttachedItemListId, AttachedItemId);
            }
        }

        public void AddPermission()
        {
            // TODO: add ws info to favorites table in db
            WorkspaceData.AddWsPermission(SiteId, _createdWebId);
        }

        private Hashtable BuildEmailData(string url, string wsName)
        {
            //{ItemUrl}
            //{Workspace_Name}
            var result = new Hashtable();
            result.Add("ItemUrl", url);
            result.Add("Workspace_Name", wsName);
            return result;
        }

        private Hashtable BuildErrorEmailData(string wsName, string error)
        {
            //{ItemUrl}
            //{Workspace_Name}
            var result = new Hashtable();
            result.Add("Workspace_Name", wsName);
            result.Add("CreateWorkspace_Error", error);
            return result;
        }

        /// <summary>
        ///     Record fresh workspace info
        ///     in reporting DB
        /// </summary>
        public void ModifyNewWSProperty()
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var s = new SPSite(SiteId))
                {
                    using (var w = s.OpenWeb(_createdWebId))
                    {
                        if (AttachedItemId != -1)
                        {
                            // stamp info on new site
                            w.AllProperties["ParentItem"] = WebId + "^^" + AttachedItemListId + "^^" + AttachedItemId +  "^^" + AttachedItemTitle;
                        }
                        else
                        {
                            w.AllProperties["ParentItem"] = Guid.Empty + "^^" + AttachedItemListId + "^^" + AttachedItemId + "^^" + AttachedItemTitle;
                        }

                        // add deleted event
                        var assemblyName =
                            "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                        var className = "EPMLiveCore.WorkspaceEvents";
                        var evts = CoreFunctions.GetWebEvents(w, assemblyName, className,
                            new List<SPEventReceiverType> { SPEventReceiverType.WebDeleting });
                        foreach (SPEventReceiverDefinition evt in evts)
                        {
                            evt.Delete();
                        }
                        w.EventReceivers.Add(SPEventReceiverType.WebDeleting, assemblyName, className);
                        w.Update();
                    }
                }
            });
        }

        public void ActivateFeature()
        {
            if (_isStandAlone && UniquePermission)
            {
                using (var s = new SPSite(SiteId))
                {
                    using (var w = s.OpenWeb(_createdWebId))
                    {
                        if (w.Features[new Guid("84520a2b-8e2b-4ada-8f48-60b138923d01")] == null)
                        {
                            w.Features.Add(new Guid("84520a2b-8e2b-4ada-8f48-60b138923d01"));
                        }

                        // add creator to team by default
                        var listRes = s.RootWeb.Lists.TryGetList("Resources");
                        var listTeam = w.Lists.TryGetList("Team");
                        w.Site.CatchAccessDeniedException = false;
                        if (listTeam == null)
                        {
                            w.AllowUnsafeUpdates = true;
                            w.Lists.Add("Team", "Use this list to manage your project team", SPListTemplateType.GenericList);
                            listTeam = w.Lists.TryGetList("Team");
                            try
                            {
                                listTeam.Fields.Add("ResID", SPFieldType.Number, false);
                                listTeam.Update();
                            }
                            catch { }
                        }

                        listTeam = w.Lists.TryGetList("Team");
                        if ((listRes != null) &&
                            (listRes.Items.Count > 0) &&
                            (listTeam != null))
                        {
                            var sQuery = @"<Where><Eq><FieldRef Name=""SharePointAccount"" LookupId=""True"" /><Value Type=""Int"">" + CreatorId + @"</Value></Eq></Where>";
                            var sViewFields = @"<FieldRef Name=""Title"" />";

                            var oQuery = new SPQuery();
                            oQuery.Query = sQuery;
                            oQuery.ViewFields = sViewFields;
                            var collListItems = listRes.GetItems(oQuery);
                            if (collListItems.Count == 0)
                            {
                                w.Update();
                                return;
                            }

                            SPListItem item = null;
                            try { item = collListItems[0]; }
                            catch { }

                            if (item != null)
                            {
                                var q = new SPQuery();
                                q.Query = "<Where><Eq><FieldRef Name=\"ResID\" /><Value Type=\"Number\">" + CreatorId + "</Value></Eq></Where>";
                                var tListItems = listTeam.GetItems(q);

                                if (tListItems.Count.Equals(0))
                                {
                                    var newTeamItem = listTeam.Items.Add();
                                    newTeamItem[listTeam.Fields.GetFieldByInternalName("Title").Id] = item["Title"];
                                    newTeamItem[listTeam.Fields.GetFieldByInternalName("ResID").Id] = item.ID;
                                    newTeamItem.Update();
                                    listTeam.Update();
                                }
                            }
                        }

                        w.Update();
                    }
                }
            }
        }

        #endregion

        protected void ClearCache()
        {
            try
            {
                using (var spSite = new SPSite(SiteId))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(WebId))
                    {
                        string loginName = spWeb.AllUsers.GetByID(CreatorId).LoginName;

                        try
                        {
                            new WorkspaceLinkProvider(SiteId, WebId, loginName).ClearCache(true);
                            new FavoritesLinkProvider(SiteId, WebId, loginName).ClearCache(true);
                        }
                        catch
                        {
                            new GenericLinkProvider(SiteId, WebId, loginName).ClearCache(true);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }

    /// <summary>
    ///     Concrete factory class for
    ///     workspace created from online templates
    /// </summary>
    public class OnlineTempWorkspaceFactory : WorkspaceFactory
    {
        public OnlineTempWorkspaceFactory(string data)
            : base(data)
        {
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
        }

        private bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslpolicyerrors)
        {
            return true;
        }

        #region class specific implementation of base abstract methods

        public override ICreatedWorkspaceInfo CreateWorkspace()
        {
            string id = string.Empty;
            var site = new SPSite(SiteId);
            SPWeb web = site.OpenWeb(WebId);


            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var eSite = new SPSite(SiteId))
                {
                    using (SPWeb eWeb = eSite.OpenWeb(WebId))
                    {
                        try
                        {
                            GrabOnlineFiles(eSite, eWeb);
                            BaseProvision(site, web, eSite, eWeb);
                            EnsureFieldsInRequestItem();
                            BuildWebInfoXml();
                            AddToFavorites();
                            AddPermission();
                            ModifyNewWSProperty();
                            ActivateFeature();
                            Notify(eWeb);
                        }
                        catch (Exception e)
                        {
                            NotifyWsGeneralError(web, e.Message);
                        }
                        finally
                        {
                            RemoveSolutionFromGallery(eSite, eWeb);
                            ClearCache();
                        }
                    }
                }
            });

            return new OnlineWorkspaceInfo(_xmlResult.ToString());
        }

        #endregion

        #region helper methods

        private void GrabOnlineFiles(SPSite cESite, SPWeb cEWeb)
        {
            //string rootFilePath = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "/Solutions/" + dataMgr.GetPropVal("SolutionName");
            string rootFilePath = CoreFunctions.getFarmSetting("WorkEngineStore") + "Solutions/" +
                                  CoreFunctions.GetAssemblyVersion() + "/" + _xmlDataMgr.GetPropVal("SolutionName");
            string sXML = string.Empty;
            // read feature.xml with WebClient class

            string address = rootFilePath + "/Feature.xml";

            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");
                    byte[] fileBytes = null;
                    fileBytes = webClient.DownloadData(address);
                    Encoding enc = Encoding.ASCII;
                    sXML = enc.GetString(fileBytes);
                    fileBytes = null;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("URL: {0}. Exception Message: {1}", address, exception.Message));
            }

            string tempName = string.Empty;

            InstallOnlineSolutionByFeatureXml(sXML, rootFilePath, out tempName, cESite, cEWeb);

            string originalSolName = tempName.Replace(".wsp", "");
            string SolNameWOSpace = originalSolName.Replace(" ", "");
            string sTempName = string.Empty;
            var lstTemps = (from t in cEWeb.GetAvailableWebTemplates(1033).OfType<SPWebTemplate>()
                            where t.Name.EndsWith(originalSolName, StringComparison.CurrentCultureIgnoreCase) ||
                                  t.Name.EndsWith(SolNameWOSpace, StringComparison.CurrentCultureIgnoreCase)
                            select t).ToList<SPWebTemplate>();

            if (lstTemps.Count > 0)
            {
                sTempName = lstTemps[0].Name;
            }

            _xmlDataMgr.EditProp("TemplateName", sTempName);

            if (string.IsNullOrEmpty(_xmlDataMgr.GetPropVal("TemplateName")))
            {
                throw new ArgumentOutOfRangeException(
                    "Could not find template during workspace creation, please make sure template name matches .wsp file name. e.g., If temp Name = AppManagement, .wsp file name should = AppManagement.wsp");
            }
        }

        #endregion
    }

    /// <summary>
    ///     Concrete factory class for workspace
    ///     created from downloaded templates
    /// </summary>
    public class DownloadedTempWorkspaceFactory : WorkspaceFactory
    {
        #region Constructors (1)

        public DownloadedTempWorkspaceFactory(string data)
            : base(data)
        {
        }

        #endregion Constructors

        #region Methods (3)

        // Public Methods (1) 

        public override ICreatedWorkspaceInfo CreateWorkspace()
        {
            string id = string.Empty;
            var site = new SPSite(SiteId);
            SPWeb web = site.OpenWeb(WebId);

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var eSite = new SPSite(SiteId))
                {
                    using (SPWeb eWeb = eSite.OpenWeb(WebId))
                    {
                        try
                        {
                            GetTempName(eSite, TempGalWebId);
                            BaseProvision(site, web, eSite, eWeb);
                            EnsureFieldsInRequestItem();
                            BuildWebInfoXml();
                            AddToFavorites();
                            AddPermission();
                            ModifyNewWSProperty();
                            ActivateFeature();
                            Notify(eWeb);
                        }
                        catch (Exception e)
                        {
                            NotifyWsGeneralError(web, e.Message);
                        }
                        finally
                        {
                            RemoveSolutionFromGallery(eSite, eWeb);
                            ClearCache();
                        }
                    }
                }
            });

            return new DownloadedWorkspaceInfo(_xmlResult.ToString());
        }

        // Private Methods (2) 

        /// <summary>
        ///     Get template name from the splistitem
        ///     that represents the template site
        /// </summary>
        /// <param name="eSite"></param>
        /// <param name="eWeb"></param>
        private void GetTempName(SPSite eSite, Guid TempGalWebId)
        {
            SPList tmpGalList = null;
            SPListItem tempGalItem = null;
            using (var eWeb = eSite.OpenWeb(TempGalWebId))
            {
                if (TryGetListAndItem(eSite, eWeb, out tmpGalList, out tempGalItem,
                    "Template Gallery", int.Parse(_xmlDataMgr.GetPropVal("TemplateItemId"))))
                {
                    string targetWebUrl =
                        new SPFieldUrlValue(tempGalItem[tmpGalList.Fields.GetFieldByInternalName("URL").Id].ToString())
                            .Url;
                    string relativeWebUrl = GetSiteRelativeWebUrl(targetWebUrl, eSite);
                    string tempSolGuid = Guid.NewGuid().ToString("N");
                    string sTempName = string.Empty;

                    if (bool.Parse(_xmlDataMgr.GetPropVal("CreateFromLiveTemp")))
                    {
                        using (SPWeb web = eSite.OpenWeb(relativeWebUrl))
                        {
                            eSite.CatchAccessDeniedException = false;
                            eSite.AllowUnsafeUpdates = true;
                            eSite.RootWeb.AllowUnsafeUpdates = true;
                            web.AllowUnsafeUpdates = true;

                            web.SaveAsTemplate(tempSolGuid, tempSolGuid, "", true);
                            _lstSolutionsToBeRemoved.Add(tempSolGuid);

                            List<SPWebTemplate> tempL =
                                (from t in web.Site.RootWeb.GetAvailableWebTemplates(1033).OfType<SPWebTemplate>()
                                 where t.Name.Split('#')[1] == tempSolGuid
                                 select t).ToList<SPWebTemplate>();

                            if (tempL.Count > 0)
                            {
                                sTempName = tempL[0].Name;
                            }
                        }
                    }
                    else
                    {
                        List<SPWebTemplate> tempList =
                            (from t in eWeb.GetAvailableWebTemplates(1033).OfType<SPWebTemplate>()
                             where t.Name.EndsWith(relativeWebUrl, StringComparison.CurrentCultureIgnoreCase)
                             select t).ToList<SPWebTemplate>();

                        if (tempList.Count > 0)
                        {
                            sTempName = tempList[0].Name;
                        }
                    }

                    _xmlDataMgr.EditProp("TemplateName", sTempName);
                }
            }
        }

        private bool TryGetListAndItem(SPSite site, SPWeb web, out SPList list, out SPListItem item, string listName,
            int itemId)
        {
            list = null;
            item = null;
            bool success = false;

            try
            {
                list = web.Lists.TryGetList(listName);
                item = list.GetItemById(itemId);
                success = true;
            }
            catch
            {
            }

            return success;
        }

        #endregion Methods
    }

    /// <summary>
    ///     Stores information for newly created workspace
    /// </summary>
    public interface ICreatedWorkspaceInfo
    {
    }

    public abstract class CreatedWorkspaceInfo
    {
        #region Fields (1)

        protected string sXml = string.Empty;

        #endregion Fields

        #region Constructors (1)

        public CreatedWorkspaceInfo(string data)
        {
            sXml = data;
        }

        #endregion Constructors
    }

    public class OnlineWorkspaceInfo : CreatedWorkspaceInfo, ICreatedWorkspaceInfo
    {
        #region Constructors (1)

        public OnlineWorkspaceInfo(string data)
            : base(data)
        {
        }

        #endregion Constructors
    }

    public class DownloadedWorkspaceInfo : CreatedWorkspaceInfo, ICreatedWorkspaceInfo
    {
        #region Constructors (1)

        public DownloadedWorkspaceInfo(string data)
            : base(data)
        {
        }

        #endregion Constructors
    }
}