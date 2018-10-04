using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Xml;
using EPMLiveCore.Jobs.Applications;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Navigation;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller : ApplicationBase
    {
        private readonly InstallAndConfigure _configJob;

        private float _currentBasePercent;
        private float _currentPercentSpan = 10;

        private float _lastPercent;
        private int _MessageId;
        private ApplicationDef appDef;

        private bool bIsInstalledElsewhere;
        private bool bVerifyOnly = true;
        private int iCommunity;
        private SPList oAppList;
        private SPListItem oListItem;
        private SPWeb oWeb;

        
        public ApplicationInstaller(string id, SqlConnection cn, InstallAndConfigure configJob) : base(id, cn)
        {
            _configJob = configJob;
        }

        public void InstallAndConfigureApp(bool verifyonly, SPWeb web, int iCommunityId)
        {
            bVerifyOnly = verifyonly;
            oWeb = web;
            iCommunity = iCommunityId;
            appDef = Applications.GetApplicationInfo(_id);


            CheckInstalledRoot();

            oAppList = oWeb.Lists.TryGetList("Installed Applications");
            if (oAppList == null)
            {
                addMessage(ErrorLevels.Error, "Application List", "You do not have the application list installed", 0);
            }
            else
            {
                var query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + appDef.Id + "</Value></Eq></Where>";
                var lic = oAppList.GetItems(query);

                if (lic.Count > 0)
                {
                    oListItem = lic[0];
                }
                else
                {
                    addMessage(ErrorLevels.Error, "Open Application Item", "Could not find item in list", 0);
                    return;
                }

                if (appDef.loadErrorMessage == string.Empty)
                {
                    if (CheckPermissions())
                    {
                        if (CheckForApplicationList())
                        {
                            if (CheckForPreReqs())
                            {
                                if (CheckForKeys())
                                {
                                    InstallAndConfigureApp();

                                    if (!bVerifyOnly)
                                    {
                                        ReportToAppReporting(web);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    addMessage(ErrorLevels.Error, "Check Applications", appDef.loadErrorMessage, 0);
                }
                if (oListItem != null)
                {
                    reportResults();
                }
            }
        }

        private bool CheckPermissions()
        {
            var bHasPerms = false;

            if (bIsInstalledElsewhere)
            {
                var oUser = oWeb.AllUsers.GetByID(_configJob.userid);

                try
                {
                    using (var tempSite = new SPSite(oWeb.Site.ID, oUser.UserToken))
                    {
                        tempSite.CatchAccessDeniedException = false;
                        using (var tempWeb = tempSite.OpenWeb(oWeb.ID))
                        {
                            if (tempWeb.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
                            {
                                bHasPerms = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }

                if (bHasPerms)
                {
                    addMessage(ErrorLevels.NoError, "Permissions Check", string.Empty, 0);
                }
                else
                {
                    addMessage(ErrorLevels.Error, "Permissions Check", "You do not have Manage Web permissions", 0);
                }
            }
            else
            {
                var bHasSolutions = false;

                try
                {
                    var ndSolutions = appDef.ApplicationXml.FirstChild.SelectSingleNode("Solutions");
                    if (ndSolutions.SelectNodes("Solution").Count > 0)
                    {
                        bHasSolutions = true;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }

                if (bHasSolutions)
                {
                    var oUser = oWeb.AllUsers.GetByID(_configJob.userid);

                    if (oUser.IsSiteAdmin)
                    {
                        addMessage(ErrorLevels.NoError, "Permissions Check", string.Empty, 0);
                        bHasPerms = true;
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, "Permissions Check", "You are not a site collection administrator", 0);
                    }
                }
                else
                {
                    var oUser = oWeb.AllUsers.GetByID(_configJob.userid);

                    try
                    {
                        using (var tempSite = new SPSite(oWeb.Site.ID, oUser.UserToken))
                        {
                            tempSite.CatchAccessDeniedException = false;
                            using (var tempWeb = tempSite.OpenWeb(oWeb.ID))
                            {
                                if (tempWeb.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
                                {
                                    bHasPerms = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }

                    if (bHasPerms)
                    {
                        addMessage(ErrorLevels.NoError, "Permissions Check", string.Empty, 0);
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, "Permissions Check", "You do not have Manage Web permissions", 0);
                    }
                }
            }

            return bHasPerms;
        }

        private bool CheckStatus(SPListItem li)
        {
            try
            {
                if (bVerifyOnly)
                {
                    switch (li["Status"].ToString())
                    {
                        case "PreCheck Queued":
                            return true;
                        default:
                            return false;
                    }
                }
                switch (li["Status"].ToString())
                {
                    case "Install Queued":
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return false;
        }

        private bool CheckForApplicationList()
        {
            var query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + appDef.Id + "</Value></Eq></Where>";
            var lic = oAppList.GetItems(query);

            if (lic.Count > 0)
            {
                if (CheckStatus(lic[0]))
                {
                    addMessage(ErrorLevels.NoError, "Application List", string.Empty, 0);
                    return true;
                }
                addMessage(ErrorLevels.Error, "Application List", "Application has not been queued.", 0);
                return false;
            }
            query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + appDef.Title + "</Value></Eq></Where>";
            lic = oAppList.GetItems(query);
            if (lic.Count > 0)
            {
                addMessage(ErrorLevels.Error, "Application List", "You already have an application with the same name installed", 0);
                return false;
            }
            addMessage(ErrorLevels.NoError, "Application List", string.Empty, 0);
            return true;
        }

        private enum ErrorLevels
        {
            NoError = 0,
            Upgrade = 1,
            Warning = 5,
            Error = 10
        }

        private void iInstallFeature(Guid gFeatureId, SPFeatureDefinition def, SPFeatureDefinitionScope scope, int ParentMessageId)
        {
            switch (def.Scope)
            {
                case SPFeatureScope.Site:
                    if (!bVerifyOnly)
                    {
                        oWeb.Site.Features.Add(gFeatureId, true, scope);
                    }

                    addMessage(ErrorLevels.NoError, def.DisplayName, string.Empty, ParentMessageId);

                    break;
                case SPFeatureScope.Web:
                    if (!bVerifyOnly)
                    {
                        oWeb.Features.Add(gFeatureId, true, scope);
                    }

                    addMessage(ErrorLevels.NoError, def.DisplayName, string.Empty, ParentMessageId);

                    break;
                default:
                    addMessage(ErrorLevels.Warning, def.DisplayName, "Feature Not scoped for Site or Web", ParentMessageId);

                    break;
            }
        }

        private float iInstallNavigationItem(SPNavigationNodeCollection navNode, XmlNodeList ndParentItems, int ParentMessageId, XmlNode docFiles,
            float counter, float max, string navField, SPListItem oParentListItem, ref ArrayList arrNavNodes)
        {
            var iArrNodes = new ArrayList();

            foreach (XmlNode nd in ndParentItems)
            {
                var sParentName = ApplicationInstallerHelpers.getAttribute(nd, "Name");
                var sParentUrl = GetCleanUrl(ApplicationInstallerHelpers.getAttribute(nd, "Url"));

                var bParentExternal = false;
                bool.TryParse(ApplicationInstallerHelpers.getAttribute(nd, "External"), out bParentExternal);

                var bAppend = false;
                bool.TryParse(ApplicationInstallerHelpers.getAttribute(nd, "Append"), out bAppend);

                if (bParentExternal || DoesLocationExist(sParentUrl, ApplicationInstallerHelpers.getAttribute(nd, "Url"), ApplicationInstallerHelpers.getAttribute(nd, "List"), docFiles))
                {
                    var ndChildItems = nd.SelectNodes("Item");

                    try
                    {
                        SPNavigationNode oNewNav = null;

                        if (!bVerifyOnly)
                        {
                            oNewNav = ApplicationInstallerHelpers.GetNavNode(navNode, navField, sParentName, oParentListItem);
                        }

                        if (!bVerifyOnly && oNewNav == null)
                        {
                            oNewNav = new SPNavigationNode(sParentName, sParentUrl, bParentExternal);
                            navNode.AddAsLast(oNewNav);

                            iArrNodes.Add(oNewNav.Id.ToString());
                            arrNavNodes.Add(oNewNav.Id + (iCommunity != 0 ? ":" + appDef.Id : string.Empty));
                        }

                        var ParentNavMessageId = addMessage(ErrorLevels.NoError, sParentName, string.Empty, ParentMessageId);

                        foreach (XmlNode ndChild in nd.SelectNodes("Item"))
                        {
                            var sChildName = ApplicationInstallerHelpers.getAttribute(ndChild, "Name");

                            try
                            {
                                var sChildUrl = GetCleanUrl(ApplicationInstallerHelpers.getAttribute(ndChild, "Url"));
                                var bChildExternal = false;
                                bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndChild, "External"), out bChildExternal);

                                if (bChildExternal ||
                                    DoesLocationExist(sChildUrl, ApplicationInstallerHelpers.getAttribute(ndChild, "Url"), ApplicationInstallerHelpers.getAttribute(ndChild, "List"), docFiles))
                                {
                                    if (oNewNav != null)
                                    {
                                        var oNewChildNav = new SPNavigationNode(sChildName, GetCleanUrl(sChildUrl), bChildExternal);
                                        oNewNav.Children.AddAsLast(oNewChildNav);
                                        arrNavNodes.Add(oNewChildNav.Id + (iCommunity != 0 ? ":" + appDef.Id : string.Empty));
                                        iArrNodes.Add(oNewChildNav.Id.ToString());
                                    }

                                    addMessage(ErrorLevels.NoError, sChildName, string.Empty, ParentNavMessageId);
                                }
                                else
                                {
                                    addMessage(ErrorLevels.Warning, sChildName, "Url Doesn't Exist (" + sChildUrl + ")", ParentNavMessageId);
                                }
                            }
                            catch (Exception ex2)
                            {
                                Trace.WriteLine(ex2.ToString());
                                addMessage(ErrorLevels.Warning, sChildName, "Error: " + ex2.Message, ParentNavMessageId);
                            }
                        }

                        if (oNewNav != null)
                        {
                            oNewNav.Update();
                        }
                    }
                    catch (Exception ex1)
                    {
                        Trace.WriteLine(ex1.ToString());
                        addMessage(ErrorLevels.Warning, sParentName, "Error: " + ex1.Message, ParentMessageId);
                    }
                }
                else
                {
                    addMessage(ErrorLevels.Warning, sParentName, "Url Doesn't Exist (" + sParentUrl + ")", ParentMessageId);
                }

                counter++;
                var percent = counter / max;
                updateLIPercent(percent);
            }

            if (!bVerifyOnly && oParentListItem != null)
            {
                try
                {
                    if (oParentListItem[navField].ToString() != string.Empty)
                    {
                        var Navs = oParentListItem[navField].ToString().Split(',');
                        iArrNodes.AddRange(Navs);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
                oParentListItem[navField] = string.Join(",", (string[])iArrNodes.ToArray(typeof(string)));
                oParentListItem.Update();
            }

            return counter;
        }

        private SPListItem iNavGetParentApp(string ParentApplicationId)
        {
            var query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + ParentApplicationId + "</Value></Eq></Where>";
            var lic = oAppList.GetItems(query);

            if (lic.Count > 0)
            {
                return lic[0];
            }

            return null;
        }

    }    
}