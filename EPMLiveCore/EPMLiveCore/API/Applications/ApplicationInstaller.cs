using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Navigation;
using System.Collections;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using System.Data.SqlClient;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using ReportFiltering;
using WebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveCore.API
{
    internal class ApplicationInstaller
    {
        private enum ErrorLevels
        {
            NoError = 0, Upgrade = 1, Warning = 5, Error = 10
        }

        private string _id;
        private int _maxErrorLevel = 0;
        private DataTable _dtMessages = new DataTable();
        private int _MessageId = 0;
        private SqlConnection _cn;
        private float _lastPercent = 0;
        private EPMLiveCore.Jobs.Applications.InstallAndConfigure _configJob;

        private float _currentBasePercent = 0;
        private float _currentPercentSpan = 10;

        private bool bIsInstalledElsewhere = false;
        private bool bVerifyOnly = true;
        private int iCommunity = 0;
        private SPWeb oWeb = null;
        private API.ApplicationDef appDef;
        private SPListItem oListItem;
        private SPList oAppList;

        public ApplicationInstaller(string id, SqlConnection cn, EPMLiveCore.Jobs.Applications.InstallAndConfigure configJob)
        {
            _id = id;
            _cn = cn;
            _configJob = configJob;

            _dtMessages.Columns.Add(new DataColumn("ID", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("ParentID", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("ErrorLevel", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("Message", typeof(string)));
            _dtMessages.Columns.Add(new DataColumn("Details", typeof(string)));
            _dtMessages.Columns.Add(new DataColumn("Tabbing", typeof(string)));
        }

        public static string getAttribute(XmlNode nd, string attribute)
        {
            try
            {
                return nd.Attributes[attribute].Value;
            }
            catch { return ""; }

        }

        public static string getChildNodeText(XmlNode nd, string child)
        {
            try
            {
                return nd.SelectSingleNode(child).InnerText;
            }
            catch { return ""; }

        }

        public void InstallAndConfigureApp(bool verifyonly, SPWeb web, int iCommunityId)
        {
            bVerifyOnly = verifyonly;
            oWeb = web;
            iCommunity = iCommunityId;
            appDef = API.Applications.GetApplicationInfo(_id);


            CheckInstalledRoot();

            oAppList = oWeb.Lists.TryGetList("Installed Applications");
            if (oAppList == null)
            {
                addMessage(ErrorLevels.Error, "Application List", "You do not have the application list installed", 0);
                return;
            }
            else
            {

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + appDef.Id + "</Value></Eq></Where>";
                SPListItemCollection lic = oAppList.GetItems(query);

                if (lic.Count > 0)
                {
                    oListItem = lic[0];
                }
                else
                {
                    addMessage(ErrorLevels.Error, "Open Application Item", "Could not find item in list", 0);
                    return;
                }

                if (appDef.loadErrorMessage == "")
                {
                    if (CheckPermissions())
                    {
                        if (CheckForApplicationList())
                        {
                            if (CheckForPreReqs())
                            {
                                if (CheckForKeys())
                                {
                                    iInstallAndConfigureApp();

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

        private void ReportToAppReporting(SPWeb web)
        {
            try
            {
                Act act = new Act(web);
                SPUser oUser = oWeb.AllUsers.GetByID(_configJob.userid);

                int source = 1;
                string sourceurl = "";


                if (act.IsOnline)
                {
                    source = 2;
                    sourceurl = web.Url;
                }

                AppStoreReporting.AppStore apprep = new AppStoreReporting.AppStore();
                apprep.Timeout = 1000;
                string ret = apprep.AddStoreInformation("<Info><Name><![CDATA[" + oUser.Name + "]]></Name><Email><![CDATA[" + oUser.Email + "]]></Email><Title><![CDATA[" + appDef.Title + "]]></Title><AppID><![CDATA[" + appDef.Id + "]]></AppID><Source><![CDATA[" + source + "]]></Source><SourceUrl><![CDATA[" + sourceurl + "]]></SourceUrl></Info>");


            }
            catch { }
        }

        private void reportResults()
        {
            if (bVerifyOnly)
            {
                if (_maxErrorLevel > 1)
                {
                    oListItem["Status"] = "PreCheck Failed";
                }
                else
                {
                    oListItem["Status"] = "PreCheck Successful";
                }
            }
            else
            {
                if (_maxErrorLevel > 5)
                {
                    oListItem["Status"] = "Install Failed";
                }
                else
                {
                    oListItem["Status"] = "Installed";
                    oListItem["Visible"] = false;
                }

            }


            oListItem["InstallPercent"] = 1;
            oListItem["Configured"] = true;
            oListItem.Update();
        }

        private void InstallOnRootWeb()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(oWeb.Site.ID))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        SPList list = Applications.GetApplicationList(web);


                        if (list != null)
                        {

                            SPListItem li = list.Items.Add();
                            li["Title"] = appDef.Title;
                            li["EXTID"] = appDef.Id;
                            li["AppVersion"] = appDef.Version;
                            li["Icon"] = appDef.Icon;
                            li["Status"] = "Not Installed";
                            li["InstallXML"] = appDef.ApplicationXml.OuterXml;
                            li["AppUrl"] = appDef.fullurl;

                            li.Update();
                        }
                    }
                }
            });
        }

        private bool CheckInstalledRoot()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(oWeb.Site.ID))
                {
                    using (SPWeb root = site.OpenWeb())
                    {
                        SPList list = root.Lists.TryGetList("Installed Applications");

                        SPQuery query = new SPQuery();
                        query.Query = "<Where><And><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + appDef.Id + "</Value></Eq><Eq><FieldRef Name='Status' /><Value Type='Text'>Installed</Value></Eq></And></Where>";

                        SPListItemCollection lic = list.GetItems(query);

                        if (lic.Count > 0)
                        {
                            int pId = addMessage(ErrorLevels.Upgrade, "Application Install", "Application is already installed in site collection and will configure.", 0);

                            try
                            {
                                SPListItem li = lic[0];
                                appDef.ApplicationXml.LoadXml(li["InstallXML"].ToString());
                                appDef.Version = li["AppVersion"].ToString();
                                try
                                {
                                    appDef.fullurl = oListItem["AppUrl"].ToString();
                                    appDef.appurl = appDef.fullurl.Replace(EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore"), "");
                                }
                                catch { }
                            }
                            catch (Exception ex)
                            {
                                addMessage(ErrorLevels.Error, "Copying Feature XML", "Error: " + ex.Message, pId);
                            }
                            bIsInstalledElsewhere = true;
                        }
                    }
                }
            });

            return true;
        }

        //public void ConfigureApp()
        //{
        //    if(CheckPermissions())
        //    {
        //        API.ApplicationDef appDef = API.Applications.GetApplicationInfo(_id);

        //        if(CheckInstalled())
        //        {
        //            if(CheckForApplicationList())
        //            {
        //                if(CheckForPreReqs())
        //                {
        //                    if(CheckForKeys())
        //                    {

        //                        iConfigureApp();

        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        #region Features

        private void iInstallFeature(Guid gFeatureId, SPFeatureDefinition def, SPFeatureDefinitionScope scope, int ParentMessageId)
        {
            switch (def.Scope)
            {
                case SPFeatureScope.Site:
                    if (!bVerifyOnly)
                        oWeb.Site.Features.Add(gFeatureId, true, scope);

                    addMessage(ErrorLevels.NoError, def.DisplayName, "", ParentMessageId);

                    break;
                case SPFeatureScope.Web:
                    if (!bVerifyOnly)
                    {
                        oWeb.Features.Add(gFeatureId, true, scope);
                        //TODO: Install on All Webs
                    }

                    addMessage(ErrorLevels.NoError, def.DisplayName, "", ParentMessageId);

                    break;
                default:
                    addMessage(ErrorLevels.Warning, def.DisplayName, "Feature Not scoped for Site or Web", ParentMessageId);

                    break;
            }
        }

        private void iInstallFeatures()
        {
            XmlNode ndFeatures = appDef.ApplicationXml.FirstChild.SelectSingleNode("Features");
            if (ndFeatures != null)
            {
                int ParentMessageId = 0;
                if (bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Features", "", 0);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Installing Features", "", 0);
                }

                float percent = 0;

                XmlNodeList ListNdFeatures = ndFeatures.SelectNodes("Feature");
                float max = ListNdFeatures.Count;
                float counter = 0;

                Dictionary<Guid, SPFeatureDefinition> ArrInstalledSiteFeatures14 = new Dictionary<Guid, SPFeatureDefinition>();
                Dictionary<Guid, SPFeatureDefinition> ArrInstalledFarmFeatures14 = new Dictionary<Guid, SPFeatureDefinition>();
                Dictionary<Guid, SPFeatureDefinition> ArrInstalledSiteFeatures15 = new Dictionary<Guid, SPFeatureDefinition>();
                Dictionary<Guid, SPFeatureDefinition> ArrInstalledFarmFeatures15 = new Dictionary<Guid, SPFeatureDefinition>();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(oWeb.Site.ID))
                    {
                        foreach (SPFeatureDefinition def in site.WebApplication.Farm.FeatureDefinitions)
                        {
                            if (def.CompatibilityLevel == 14)
                                ArrInstalledFarmFeatures14.Add(def.Id, def);
                            else
                                ArrInstalledFarmFeatures15.Add(def.Id, def);
                        }

                        foreach (SPFeatureDefinition def in site.FeatureDefinitions)
                        {
                            if (def.CompatibilityLevel == 14)
                                ArrInstalledSiteFeatures14.Add(def.Id, def);
                            else
                                ArrInstalledSiteFeatures15.Add(def.Id, def);
                        }
                    }
                });

                foreach (XmlNode ndFeature in ListNdFeatures)
                {
                    string FeatureId = getAttribute(ndFeature, "ID");
                    string sFeatureName = getAttribute(ndFeature, "Name");
                    if (FeatureId != "")
                    {
                        try
                        {

                            bool bIncluded = false;
                            bool.TryParse(getAttribute(ndFeature, "IncludedInSolutions"), out bIncluded);

                            Guid gFeatureId = new Guid(FeatureId);
                            if (ArrInstalledFarmFeatures15.ContainsKey(gFeatureId))
                            {
                                SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledFarmFeatures15[gFeatureId];

                                iInstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Farm, ParentMessageId);

                            }
                            else if (ArrInstalledFarmFeatures14.ContainsKey(gFeatureId))
                            {
                                SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledFarmFeatures14[gFeatureId];

                                iInstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Farm, ParentMessageId);

                            }
                            else if (ArrInstalledSiteFeatures15.ContainsKey(gFeatureId))
                            {
                                SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledSiteFeatures15[gFeatureId];

                                iInstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Site, ParentMessageId);
                            }
                            else if (ArrInstalledSiteFeatures14.ContainsKey(gFeatureId))
                            {
                                SPFeatureDefinition def = (SPFeatureDefinition)ArrInstalledSiteFeatures14[gFeatureId];

                                iInstallFeature(gFeatureId, def, SPFeatureDefinitionScope.Site, ParentMessageId);
                            }
                            else
                            {
                                if (bIncluded && bVerifyOnly)
                                {
                                    addMessage(ErrorLevels.NoError, (sFeatureName == "") ? FeatureId : sFeatureName, "", ParentMessageId);
                                }
                                else
                                {
                                    addMessage(ErrorLevels.Error, (sFeatureName == "") ? FeatureId : sFeatureName, "Feature Not Installed on Farm", ParentMessageId);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            addMessage(ErrorLevels.Error, (sFeatureName == "") ? FeatureId : sFeatureName, "Error: " + ex.Message, ParentMessageId);
                        }
                    }

                    counter++;
                    percent = counter / max;
                    updateLIPercent(percent);
                }
            }
        }

        #endregion

        private int updateParentStatus(int parent, ErrorLevels level)
        {
            if (parent > 0)
            {
                DataRow[] drParent = _dtMessages.Select("ID='" + parent + "'");
                if (drParent.Length > 0)
                {
                    if ((ErrorLevels)drParent[0][2] < level)
                    {
                        drParent[0][2] = (int)level;
                    }

                    int tabLength = updateParentStatus((int)drParent[0]["ParentID"], level);
                    return tabLength + 1;
                }
            }
            return 0;
        }

        private int addMessage(ErrorLevels level, string message, string details, int parent)
        {
            if (_maxErrorLevel < (int)level)
                _maxErrorLevel = (int)level;

            _MessageId++;

            int tabLength = updateParentStatus(parent, level);

            _dtMessages.Rows.Add(new object[] { _MessageId, parent, (int)level, message, details, tabLength.ToString() });

            return _MessageId;
        }

        private string GetCleanUrl(string url)
        {
            url = url.Replace("{SiteUrl}", (oWeb.ServerRelativeUrl == "/") ? "" : oWeb.ServerRelativeUrl);

            return url;
        }

        private bool IsListInstalledWithApplication(string list)
        {
            try
            {
                if (list != "" && appDef.ApplicationXml.FirstChild.SelectSingleNode("Lists").SelectNodes("List[@Name='" + list + "']").Count > 0)
                    return true;
            }
            catch { }
            return false;
        }

        private bool DoesLocationExist(string url, string rawUrl, string list, XmlNode ndFiles)
        {
            if (oWeb.GetFile(url).Exists || oWeb.GetFolder(url).Exists)
            {
                return true;
            }
            else
            {
                if (bVerifyOnly)
                {
                    try
                    {
                        if (ndFiles.SelectNodes("//File[@FullFile='" + rawUrl.Replace("{SiteUrl}/", "") + "']").Count > 0)
                            return true;
                    }
                    catch { }
                    try
                    {
                        if (list != "" && appDef.ApplicationXml.FirstChild.SelectSingleNode("Lists").SelectNodes("List[@Name='" + list + "']").Count > 0)
                            return true;
                    }
                    catch { }
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        private void updateLIPercent(float percent)
        {
            oListItem.ParentList.ParentWeb.AllowUnsafeUpdates = true;
            percent = percent * _currentPercentSpan + _currentBasePercent;

            if (oListItem != null)
            {
                oListItem["InstallMessages"] = Message;
                oListItem["InstallPercent"] = Math.Round(percent / 100, 2);
                oListItem.Update();

                if (percent != _lastPercent)
                {
                    _lastPercent = percent;
                    _configJob.SetPercent(_lastPercent);
                }
            }
        }

        #region QuickLaunch

        private SPNavigationNode iGetNavNode(SPNavigationNodeCollection navNode, string navField, string nodename, SPListItem oLiParent)
        {
            try
            {
                string[] navs = oLiParent[oLiParent.ParentList.Fields.GetFieldByInternalName(navField).Id].ToString().Split(',');

                foreach (SPNavigationNode ndNav in navNode)
                {
                    if (string.Equals(ndNav.Title, nodename, StringComparison.InvariantCultureIgnoreCase))
                    {
                        foreach (string nav in navs)
                        {
                            if (ndNav.Id == int.Parse(nav))
                                return ndNav;
                        }
                    }
                }
            }
            catch { }

            return null;
        }

        private float iInstallNavigationItem(SPNavigationNodeCollection navNode, XmlNodeList ndParentItems, int ParentMessageId, XmlNode docFiles, float counter, float max, string navField, SPListItem oParentListItem, ref ArrayList arrNavNodes)
        {

            ArrayList iArrNodes = new ArrayList();

            foreach (XmlNode nd in ndParentItems)
            {

                string sParentName = getAttribute(nd, "Name");
                string sParentUrl = GetCleanUrl(getAttribute(nd, "Url"));

                bool bParentExternal = false;
                bool.TryParse(getAttribute(nd, "External"), out bParentExternal);

                bool bAppend = false;
                bool.TryParse(getAttribute(nd, "Append"), out bAppend);

                if (bParentExternal || DoesLocationExist(sParentUrl, getAttribute(nd, "Url"), getAttribute(nd, "List"), docFiles))
                {
                    XmlNodeList ndChildItems = nd.SelectNodes("Item");

                    try
                    {
                        SPNavigationNode oNewNav = null;

                        if (!bVerifyOnly)
                            oNewNav = iGetNavNode(navNode, navField, sParentName, oParentListItem);

                        if (!bVerifyOnly && oNewNav == null)
                        {
                            oNewNav = new SPNavigationNode(sParentName, sParentUrl, bParentExternal);
                            navNode.AddAsLast(oNewNav);

                            iArrNodes.Add(oNewNav.Id.ToString());
                            arrNavNodes.Add(oNewNav.Id.ToString() + ((iCommunity != 0) ? (":" + appDef.Id) : ""));
                        }

                        int ParentNavMessageId = addMessage(ErrorLevels.NoError, sParentName, "", ParentMessageId);

                        foreach (XmlNode ndChild in nd.SelectNodes("Item"))
                        {
                            string sChildName = getAttribute(ndChild, "Name");

                            try
                            {
                                string sChildUrl = GetCleanUrl(getAttribute(ndChild, "Url"));
                                bool bChildExternal = false;
                                bool.TryParse(getAttribute(ndChild, "External"), out bChildExternal);

                                if (bChildExternal || DoesLocationExist(sChildUrl, getAttribute(ndChild, "Url"), getAttribute(ndChild, "List"), docFiles))
                                {
                                    if (oNewNav != null)
                                    {
                                        SPNavigationNode oNewChildNav = new SPNavigationNode(sChildName, GetCleanUrl(sChildUrl), bChildExternal);
                                        oNewNav.Children.AddAsLast(oNewChildNav);
                                        arrNavNodes.Add(oNewChildNav.Id.ToString() + ((iCommunity != 0) ? (":" + appDef.Id) : ""));
                                        iArrNodes.Add(oNewChildNav.Id.ToString());
                                    }

                                    addMessage(ErrorLevels.NoError, sChildName, "", ParentNavMessageId);
                                }
                                else
                                {

                                    addMessage(ErrorLevels.Warning, sChildName, "Url Doesn't Exist (" + sChildUrl + ")", ParentNavMessageId);
                                }
                            }
                            catch (Exception ex2)
                            {
                                addMessage(ErrorLevels.Warning, sChildName, "Error: " + ex2.Message, ParentNavMessageId);
                            }
                        }

                        if (oNewNav != null)
                            oNewNav.Update();
                    }
                    catch (Exception ex1)
                    {
                        addMessage(ErrorLevels.Warning, sParentName, "Error: " + ex1.Message, ParentMessageId);
                    }
                }
                else
                {
                    addMessage(ErrorLevels.Warning, sParentName, "Url Doesn't Exist (" + sParentUrl + ")", ParentMessageId);
                }

                counter++;
                float percent = counter / max;
                updateLIPercent(percent);
            }

            if (!bVerifyOnly && oParentListItem != null)
            {
                try
                {
                    if (oParentListItem[navField].ToString() != "")
                    {
                        string[] Navs = oParentListItem[navField].ToString().Split(',');
                        iArrNodes.AddRange(Navs);
                    }
                }
                catch { }
                oParentListItem[navField] = String.Join(",", (string[])iArrNodes.ToArray(typeof(string)));
                oParentListItem.Update();
            }

            return counter;
        }

        private SPListItem iNavGetParentApp(string ParentApplicationId)
        {
            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + ParentApplicationId + "</Value></Eq></Where>";
            SPListItemCollection lic = oAppList.GetItems(query);

            if (lic.Count > 0)
            {
                return lic[0];
            }

            return null;
        }

        private void iInstallQuickLaunch(XmlNode docFiles)
        {

            XmlNode appNod = appDef.ApplicationXml.FirstChild.SelectSingleNode("Application");

            if (appNod != null)
            {

                XmlNode ndQuickLaunch = appNod.SelectSingleNode("QuickLaunch");
                XmlNode ndTopNav = appNod.SelectSingleNode("TopNav");

                if (ndQuickLaunch != null || ndTopNav != null)
                {
                    int NavParentMessageId = 0;

                    if (bVerifyOnly)
                    {
                        NavParentMessageId = addMessage(0, "Checking Navigation", "", 0);
                    }
                    else
                    {
                        NavParentMessageId = addMessage(0, "Installing Navigation", "", 0);
                    }

                    float max = 0;
                    XmlNodeList ndTopNavItems = null;
                    XmlNodeList ndQuickLaunchItems = null;
                    try
                    {
                        ndQuickLaunchItems = ndQuickLaunch.SelectNodes("Item");
                        max += ndQuickLaunchItems.Count;
                    }
                    catch { }
                    try
                    {
                        ndTopNavItems = ndTopNav.SelectNodes("Item");
                        max += ndTopNavItems.Count;
                    }
                    catch { }

                    float counter = 0;

                    ArrayList arrTopNavNavNodes = new ArrayList();
                    ArrayList arrQuickLaunchNavNodes = new ArrayList();

                    //if(appDef.ParentApplications.Length > 0 && appDef.ParentApplications[0] != "")
                    //{

                    //    foreach(string sParentApp in appDef.ParentApplications)
                    //    {

                    //        SPListItem liParent = iNavGetParentApp(sParentApp);

                    //        if(liParent != null)
                    //        {
                    //            int NavParentAppMessageId = addMessage(0, "Parent Application: " + liParent.Title, "", NavParentMessageId);

                    //            if(ndQuickLaunch != null)
                    //            {
                    //                int ParentMessageId = addMessage(0, "QuickLaunch", "", NavParentAppMessageId);

                    //                counter = iInstallNavigationItem(oWeb.Navigation.QuickLaunch, ndQuickLaunchItems, ParentMessageId, docFiles, counter, max, "QuickLaunch", liParent, ref arrQuickLaunchNavNodes);
                    //            }

                    //            if(ndTopNav != null)
                    //            {
                    //                int ParentMessageId = addMessage(0, "TopNav", "", NavParentAppMessageId);

                    //                counter = iInstallNavigationItem(oWeb.Navigation.TopNavigationBar, ndTopNavItems, ParentMessageId, docFiles, counter, max, "TopNav", liParent, ref arrTopNavNavNodes);
                    //            }
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    if (ndQuickLaunch != null)
                    {
                        int ParentMessageId = addMessage(0, "QuickLaunch", "", NavParentMessageId);

                        counter = iInstallNavigationItem(oWeb.Navigation.QuickLaunch, ndQuickLaunchItems, ParentMessageId, docFiles, counter, max, "QuickLaunch", null, ref arrQuickLaunchNavNodes);
                    }

                    if (ndTopNav != null)
                    {
                        int ParentMessageId = addMessage(0, "TopNav", "", NavParentMessageId);

                        counter = iInstallNavigationItem(oWeb.Navigation.TopNavigationBar, ndTopNavItems, ParentMessageId, docFiles, counter, max, "TopNav", null, ref arrTopNavNavNodes);
                    }
                    //}

                    if (!bVerifyOnly)
                    {
                        if (iCommunity != 0)
                        {
                            SPListItem oLiCommunity = oAppList.GetItemById(iCommunity);

                            ArrayList arrCurQuickLaunch = new ArrayList();
                            ArrayList arrCurTopNav = new ArrayList();
                            try
                            {
                                arrCurQuickLaunch = new ArrayList(oLiCommunity["QuickLaunch"].ToString().Split(','));
                            }
                            catch { }
                            try
                            {
                                arrCurTopNav = new ArrayList(oLiCommunity["TopNav"].ToString().Split(','));
                            }
                            catch { }

                            arrCurQuickLaunch.AddRange(arrQuickLaunchNavNodes);
                            arrCurTopNav.AddRange(arrTopNavNavNodes);


                            oLiCommunity["QuickLaunch"] = String.Join(",", (string[])arrCurQuickLaunch.ToArray(typeof(string)));
                            oLiCommunity["TopNav"] = String.Join(",", (string[])arrCurTopNav.ToArray(typeof(string)));
                            oLiCommunity.Update();

                            API.Applications.CreateQuickLaunchXML(oLiCommunity.ID, oWeb);
                            API.Applications.CreateTopNavXML(oLiCommunity.ID, oWeb);
                        }
                        else
                        {
                            oListItem["QuickLaunch"] = String.Join(",", (string[])arrQuickLaunchNavNodes.ToArray(typeof(string)));
                            oListItem["TopNav"] = String.Join(",", (string[])arrTopNavNavNodes.ToArray(typeof(string)));
                            oListItem.Update();

                            API.Applications.CreateQuickLaunchXML(oListItem.ID, oWeb);
                            API.Applications.CreateTopNavXML(oListItem.ID, oWeb);
                        }
                    }
                }
            }
        }
        #endregion

        #region Property Installer

        private string iInstallPropertiesGet(string sPropertyName, bool bLockWeb)
        {
            if (bLockWeb)
            {
                return CoreFunctions.getLockConfigSetting(oWeb, sPropertyName, false);
            }
            else
            {
                return CoreFunctions.getConfigSetting(oWeb, sPropertyName);
            }
        }

        private void iInstallPropertiesSet(string sPropertyName, string sPropertyValue, bool bLockWeb)
        {
            if (bLockWeb)
            {
                Guid lWeb = CoreFunctions.getLockedWeb(oWeb);
                using (SPWeb tWeb = oWeb.Site.OpenWeb(lWeb))
                {
                    CoreFunctions.setConfigSetting(tWeb, sPropertyName, sPropertyValue);
                }
            }
            else
            {
                CoreFunctions.setConfigSetting(oWeb, sPropertyName, sPropertyValue);
            }
        }

        private void iInstallProperties()
        {
            XmlNode ndWeb = appDef.ApplicationXml.FirstChild.SelectSingleNode("Web");
            if (ndWeb != null)
            {
                XmlNode ndProperties = ndWeb.SelectSingleNode("Properties");
                if (ndProperties != null)
                {
                    int ParentMessageId = 0;

                    if (bVerifyOnly)
                    {
                        ParentMessageId = addMessage(0, "Checking Properties", "", 0);
                    }
                    else
                    {
                        ParentMessageId = addMessage(0, "Installing Properties", "", 0);
                    }

                    float percent = 0;

                    XmlNodeList ListNdProperties = ndProperties.SelectNodes("Property");
                    float max = ListNdProperties.Count;
                    float counter = 0;

                    foreach (XmlNode ndProperty in ListNdProperties)
                    {

                        try
                        {
                            string sPropertyName = ndProperty.Attributes["Name"].Value;
                            string sPropertyValue = ndProperty.Attributes["Value"].Value;
                            bool bAppend = false;
                            bool bOverwrite = false;
                            bool bIsLockWeb = false;
                            bool.TryParse(getAttribute(ndProperty, "Append"), out bAppend);
                            bool.TryParse(getAttribute(ndProperty, "Overwrite"), out bOverwrite);
                            bool.TryParse(getAttribute(ndProperty, "LockWebProperty"), out bIsLockWeb);

                            if (bAppend)
                            {
                                if (oWeb.Properties.ContainsKey(sPropertyName))
                                {

                                    char sSeperator = getAttribute(ndProperty, "Seperator")[0];
                                    if (getAttribute(ndProperty, "Seperator") == "\\n")
                                        sSeperator = '\n';

                                    if (getAttribute(ndProperty, "Seperator") == "\\r")
                                        sSeperator = '\r';

                                    if (sSeperator == '\0')
                                        sSeperator = ',';

                                    string DuplicateRegEx = getAttribute(ndProperty, "DuplicateRegEx");

                                    string curProp = iInstallPropertiesGet(sPropertyName, bIsLockWeb);

                                    if (sSeperator == '\r')
                                        curProp = curProp.Replace("\r\n", "\r");

                                    string[] sCurVals = curProp.Split(sSeperator);

                                    if (DuplicateRegEx == "")
                                        DuplicateRegEx = sPropertyValue;

                                    bool found = false;

                                    foreach (string sCurVal in sCurVals)
                                    {
                                        Match m = Regex.Match(sCurVal, DuplicateRegEx);
                                        if (m.Length > 0)
                                        {
                                            found = true;
                                        }
                                    }

                                    if (found)
                                    {
                                        if (bOverwrite)
                                        {
                                            if (!bVerifyOnly)
                                            {
                                                string newVal = "";

                                                foreach (string sCurVal in sCurVals)
                                                {
                                                    Match m = Regex.Match(sCurVal, DuplicateRegEx);
                                                    if (m.Length > 0)
                                                    {
                                                        if (sSeperator == '\r')
                                                            newVal += "\r\n" + sPropertyValue;
                                                        else
                                                            newVal += sSeperator + sPropertyValue;
                                                    }
                                                    else
                                                    {
                                                        if (sSeperator == '\r')
                                                            newVal += "\r\n" + sCurVal;
                                                        else
                                                            newVal += sSeperator + sCurVal;
                                                    }
                                                }

                                                if (sSeperator == '\r')
                                                    newVal = newVal.Trim('\n').Trim('\r');
                                                else
                                                    newVal = newVal.Trim(sSeperator);

                                                iInstallPropertiesSet(sPropertyName, newVal, bIsLockWeb);
                                            }

                                            addMessage(ErrorLevels.NoError, sPropertyName, "Property found and will append", ParentMessageId);
                                        }
                                        else
                                        {
                                            addMessage(ErrorLevels.Warning, sPropertyName, "Cannot append value, value already exists", ParentMessageId);
                                        }
                                    }
                                    else
                                    {
                                        if (!bVerifyOnly)
                                        {
                                            string newVal = iInstallPropertiesGet(sPropertyName, bIsLockWeb);

                                            if (sSeperator == '\r')
                                                newVal += "\r\n" + sPropertyValue;
                                            else
                                                newVal += sSeperator + sPropertyValue;

                                            if (sSeperator == '\r')
                                                newVal = newVal.Trim('\n').Trim('\r');
                                            else
                                                newVal = newVal.Trim(sSeperator);

                                            iInstallPropertiesSet(sPropertyName, newVal, bIsLockWeb);
                                        }

                                        addMessage(ErrorLevels.NoError, sPropertyName, "", ParentMessageId);
                                    }
                                }
                                else
                                {
                                    if (!bVerifyOnly)
                                    {
                                        iInstallPropertiesSet(sPropertyName, sPropertyValue, bIsLockWeb);
                                    }

                                    addMessage(ErrorLevels.NoError, sPropertyName, "", ParentMessageId);
                                }
                            }
                            else
                            {
                                if (bOverwrite)
                                {
                                    if (bVerifyOnly)
                                    {
                                        if (oWeb.Properties.ContainsKey(sPropertyName) && iInstallPropertiesGet(sPropertyName, bIsLockWeb) != sPropertyValue)
                                        {
                                            addMessage(ErrorLevels.Upgrade, sPropertyName, "Property already exists and will overwrite", ParentMessageId);
                                        }
                                        else
                                        {
                                            addMessage(ErrorLevels.NoError, sPropertyName, "", ParentMessageId);
                                        }
                                    }
                                    else
                                    {
                                        iInstallPropertiesSet(sPropertyName, sPropertyValue, bIsLockWeb);

                                        addMessage(ErrorLevels.NoError, sPropertyName, "", ParentMessageId);
                                    }
                                }
                                else
                                {
                                    if (oWeb.Properties.ContainsKey(sPropertyName) && iInstallPropertiesGet(sPropertyName, bIsLockWeb) != sPropertyValue)
                                    {
                                        addMessage(ErrorLevels.Warning, sPropertyName, "Property already exists and cannot overwrite", ParentMessageId);
                                    }
                                    else
                                    {
                                        if (!bVerifyOnly)
                                        {
                                            iInstallPropertiesSet(sPropertyName, sPropertyValue, bIsLockWeb);
                                        }

                                        addMessage(ErrorLevels.NoError, sPropertyName, "", ParentMessageId);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            addMessage(ErrorLevels.Error, ndProperty.Attributes["Name"].Value, ex.Message, ParentMessageId);
                        }

                        counter++;
                        percent = counter / max;
                        updateLIPercent(percent);

                    }


                }
            }
        }
        #endregion

        #region List Installer

        private bool DoesListExist(string name)
        {
            SPList list = oWeb.Lists.TryGetList(name);
            return list != null;
        }

        private SPListTemplateType GetTemplateType(string sType)
        {
            try
            {
                int iTemplate = 100;

                int.TryParse(sType, out iTemplate);

                return (SPListTemplateType)iTemplate;
            }
            catch { }

            return SPListTemplateType.GenericList;
        }

        private SPList iInstallListsAddList(XmlNode ndList, out string error)
        {
            error = "";
            SPList list = null;
            try
            {
                string sFileName = getAttribute(ndList, "FileName");
                string sTemplate = getAttribute(ndList, "Template");
                string sListName = getAttribute(ndList, "Name");
                string sDescription = getAttribute(ndList, "Description");
                SPDocumentLibrary lists = (SPDocumentLibrary)oWeb.Site.GetCatalog(SPListTemplateType.ListTemplateCatalog);

                if (sFileName != "")
                {
                    foreach (SPListTemplate template in oWeb.Site.GetCustomListTemplates(oWeb))
                    {
                        if (template.InternalName == sFileName)
                        {
                            Guid gList = oWeb.Lists.Add(sListName, sDescription, template);
                            list = oWeb.Lists[gList];
                            break;
                        }
                    }
                }
                else if (sTemplate != "")
                {
                    Guid gList = oWeb.Lists.Add(sListName, sDescription, GetTemplateType(sTemplate));
                    list = oWeb.Lists[gList];
                }
                else
                {
                    error = "List FileName or Template property not found";
                }
            }
            catch (Exception ex)
            {
                error = "Error: " + ex.Message;
            }

            return list;
        }

        private SPFieldType iGetFieldTypeByString(string sType)
        {
            switch (sType)
            {
                case "Boolean":
                    return SPFieldType.Boolean;
                case "Calculated":
                    return SPFieldType.Calculated;
                case "Choice":
                    return SPFieldType.Choice;
                case "Currency":
                    return SPFieldType.Currency;
                case "DateTime":
                    return SPFieldType.DateTime;
                case "MultiChoice":
                    return SPFieldType.MultiChoice;
                case "Note":
                    return SPFieldType.Note;
                case "Number":
                    return SPFieldType.Number;
                case "Text":
                    return SPFieldType.Text;
                case "URL":
                    return SPFieldType.URL;
                case "User":
                    return SPFieldType.User;
                default:
                    return SPFieldType.Invalid;
            }
        }

        private bool isValidSchemaAttribute(string attribute)
        {
            switch (attribute)
            {
                case "ID":
                case "SourceID":
                case "Type":
                case "StaticName":
                case "Name":
                case "ColName":
                case "RowOrdinal":
                    return false;
            }
            return true;
        }

        private bool isValidNewSchemaAttribute(string attribute)
        {
            switch (attribute)
            {
                case "ID":
                case "SourceID":
                case "ColName":
                case "RowOrdinal":
                    return false;
            }
            return true;
        }

        private SPField iInstallListFieldsAddField(SPList list, string sInternalName, string sType, XmlNode ndNewField)
        {
            SPFieldType oType = iGetFieldTypeByString(sType);
            if (oType != SPFieldType.Invalid)
            {
                list.Fields.Add(sInternalName, oType, false);

                SPField field = list.Fields.GetFieldByInternalName(sInternalName);

                return field;
            }
            else
            {
                try
                {
                    ArrayList arrAttr = new ArrayList();

                    foreach (XmlAttribute attr in ndNewField.Attributes)
                    {
                        if (!isValidNewSchemaAttribute(attr.Name))
                            arrAttr.Add(attr);
                    }

                    foreach (XmlAttribute attr in arrAttr)
                    {
                        ndNewField.Attributes.Remove(attr);
                    }

                    string sDisplay = ndNewField.Attributes["DisplayName"].Value;

                    ndNewField.Attributes["DisplayName"].Value = sInternalName;


                    list.Fields.AddFieldAsXml(ndNewField.OuterXml);
                    SPField field = list.Fields.GetFieldByInternalName(sInternalName);
                    field.Title = sDisplay;
                    ndNewField.Attributes["DisplayName"].Value = sDisplay;
                    return field;
                }
                catch (Exception ex)
                { throw new Exception("Error: " + ex.Message); }

            }
        }

        private void iInstallListFieldSwapXml(SPList list, SPField field, XmlNode ndNewField)
        {

            bool bIsSealed = field.Sealed;
            if (bIsSealed)
            {
                field.Sealed = false;
                field.Update();
            }

            iiInstallListFieldSwapXml(list, field.InternalName, ndNewField);

            if (bIsSealed)
            {
                field.Sealed = bIsSealed;
                field.Update(true);
            }
        }

        private void iiInstallListFieldSwapXml(SPList list, string sField, XmlNode ndNewField)
        {
            SPField field = list.Fields.GetFieldByInternalName(sField);

            if (field.Type == SPFieldType.Calculated)
            {
                SPFieldCalculated calc = (SPFieldCalculated)field;
                calc.Formula = ndNewField.SelectSingleNode("FormulaDisplayNames").InnerText;
                field.Update();
            }

            if (field.Type == SPFieldType.Choice || field.Type == SPFieldType.MultiChoice)
            {
                SPFieldChoice choice = (SPFieldChoice)field;
                choice.Choices.Clear();

                XmlNode ndChoices = ndNewField.SelectSingleNode("CHOICES");
                foreach (XmlNode ndChoice in ndChoices.SelectNodes("CHOICE"))
                {
                    choice.Choices.Add(ndChoice.InnerText);
                }

                try
                {
                    choice.ShowInEditForm = bool.Parse(ndNewField.Attributes["ShowInEditForm"].Value);
                }
                catch { }
                try
                {
                    choice.ShowInNewForm = bool.Parse(ndNewField.Attributes["ShowInNewForm"].Value);
                }
                catch { }
                try
                {
                    choice.ShowInDisplayForm = bool.Parse(ndNewField.Attributes["ShowInDisplayForm"].Value);
                }
                catch { }
                try
                {
                    choice.FillInChoice = bool.Parse(ndNewField.Attributes["FillInChoice"].Value);
                }
                catch { }
                choice.Title = ndNewField.Attributes["DisplayName"].Value;
                choice.Update();
            }
            else
            {
                XmlDocument docOldField = new XmlDocument();
                docOldField.LoadXml(field.SchemaXml);

                XmlNode ndOldField = docOldField.FirstChild;

                foreach (XmlAttribute attrNew in ndNewField.Attributes)
                {
                    if (isValidSchemaAttribute(attrNew.Name))
                    {
                        if (ndOldField.Attributes[attrNew.Name] == null)
                        {
                            XmlAttribute attr = docOldField.CreateAttribute(attrNew.Name);
                            attr.Value = ndNewField.Attributes[attrNew.Name].Value;
                            ndOldField.Attributes.Append(attr);
                        }
                        else
                        {
                            ndOldField.Attributes[attrNew.Name].Value = ndNewField.Attributes[attrNew.Name].Value;
                        }
                    }
                }
                ndOldField.InnerXml = ndNewField.InnerXml;

                field.SchemaXml = ndOldField.OuterXml;
                field.Update();
            }

        }



        private void iInstallListsItems(SPList list, XmlNode ndList, int ParentMessageId, bool added)
        {
            XmlNode ndItems = ndList.SelectSingleNode("Items");

            if (ndItems != null)
            {
                if (bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Items", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Installing Items", "", ParentMessageId);

                foreach (XmlNode ndItem in ndItems.SelectNodes("Item"))
                {

                    oWeb.AllowUnsafeUpdates = true;

                    string sTitle = "";
                    try
                    {
                        sTitle = ndItem.SelectSingleNode("Field[@Name='Title']").InnerText;
                    }
                    catch { }
                    if (sTitle == "")
                    {
                        try
                        {
                            sTitle = ndItem.FirstChild.InnerText;
                        }
                        catch { }
                    }

                    if (sTitle != "")
                    {

                        if (bVerifyOnly)
                        {
                            addMessage(0, sTitle, "", ParentMessageId);
                        }
                        else
                        {
                            try
                            {
                                SPListItem li = list.Items.Add();

                                foreach (XmlNode ndField in ndItem.SelectNodes("Field"))
                                {
                                    li[ndField.Attributes["Name"].Value] = ndField.InnerText;
                                }

                                li.Update();

                                addMessage(0, sTitle, "", ParentMessageId);
                            }
                            catch (Exception ex)
                            {
                                addMessage(ErrorLevels.Error, sTitle, "Error: " + ex.Message, ParentMessageId);
                            }
                        }

                    }

                }
            }
        }

        private void iInstallListsEvents(SPList list, XmlNode ndList, int ParentMessageId, bool added)
        {
            XmlNode ndEventHandlers = ndList.SelectSingleNode("EventHandlers");

            if (ndEventHandlers != null)
            {
                if (bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Event Handlers", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Installing Event Handlers", "", ParentMessageId);

                XmlNode ndParent = ndList.ParentNode;

                foreach (XmlNode ndEventHandler in ndEventHandlers.SelectNodes("EventHandler"))
                {

                    string sType = getAttribute(ndEventHandler, "Type");
                    string sAssembly = getAttribute(ndEventHandler, "Assembly");
                    string sClass = getAttribute(ndEventHandler, "Class");
                    SPEventReceiverType oType = CoreFunctions.iGetListEventType(sType);

                    if (oType != SPEventReceiverType.InvalidReceiver)
                    {
                        if (bVerifyOnly)
                        {
                            addMessage(0, sType + "(" + sClass + ")", "", ParentMessageId);
                        }
                        else
                        {
                            bool found = false;
                            foreach (SPEventReceiverDefinition oRecDef in list.EventReceivers)
                            {
                                if (oRecDef.Type == oType && oRecDef.Assembly.ToLower() == sAssembly.ToLower() && oRecDef.Class.ToLower() == oRecDef.Class.ToLower())
                                {
                                    found = true;
                                    addMessage(ErrorLevels.Upgrade, sType + "(" + sClass + ")", "Event found, skipped", ParentMessageId);
                                    break;
                                }
                            }

                            if (!found)
                            {
                                list.EventReceivers.Add(oType, sAssembly, sClass);

                                addMessage(0, sType + "(" + sClass + ")", "", ParentMessageId);
                            }
                        }
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, sType + "(" + sClass + ")", "Invalid receiver type", ParentMessageId);
                    }
                }
            }
        }

        private void iInstallListsWorkflowsInstall(SPList oList, string sName, string sDisplayName, SPList oTaskList, SPList oHistoryList, XmlNode ndWorkflow)
        {
            SPWorkflowAssociation assocation = null;

            bool bAllowManual = false;
            bool.TryParse(getAttribute(ndWorkflow, "AllowManual"), out bAllowManual);

            bool bStartOnCreate = false;
            bool.TryParse(getAttribute(ndWorkflow, "StartOnCreate"), out bStartOnCreate);

            bool bStartOnChange = false;
            bool.TryParse(getAttribute(ndWorkflow, "StartOnChange"), out bStartOnChange);


            foreach (SPWorkflowTemplate template in oWeb.WorkflowTemplates)
            {
                if (template.Name == sName)
                {
                    assocation = SPWorkflowAssociation.CreateListAssociation(template, sDisplayName, oTaskList, oHistoryList);
                    break;
                }
            }
            if (assocation != null)
            {
                assocation.AllowManual = bAllowManual;
                assocation.AutoStartChange = bStartOnChange;
                assocation.AutoStartCreate = bStartOnCreate;
                oList.WorkflowAssociations.Add(assocation);
            }

        }

        private void iInstallListsWorkflows(SPList list, XmlNode ndList, int ParentMessageId, bool added)
        {
            XmlNode ndWorkflows = ndList.SelectSingleNode("Workflows");

            if (ndWorkflows != null)
            {
                if (bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Workflows", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Updating Workflows", "", ParentMessageId);

                XmlNode ndParent = ndList.ParentNode;

                foreach (XmlNode ndWorkflow in ndWorkflows.SelectNodes("Workflow"))
                {

                    string sName = getAttribute(ndWorkflow, "Name");

                    string sDisplayName = getAttribute(ndWorkflow, "DisplayName");
                    if (sDisplayName == "")
                        sDisplayName = sName;

                    if (sName != "")
                    {
                        try
                        {
                            string sTaskList = getAttribute(ndWorkflow, "TaskList");
                            if (sTaskList == "")
                                sTaskList = "Workflow Tasks";

                            string sHistoryList = getAttribute(ndWorkflow, "HistoryList");
                            if (sHistoryList == "")
                                sHistoryList = "Workflow History";

                            bool bOverwrite = false;
                            bool.TryParse(getAttribute(ndWorkflow, "Overwrite"), out bOverwrite);

                            SPList oTaskList = oWeb.Lists.TryGetList(sTaskList);
                            SPList oHistoryList = oWeb.Lists.TryGetList(sHistoryList);

                            if (oTaskList != null || (IsListInstalledWithApplication(sTaskList) && bVerifyOnly))
                            {
                                if (oHistoryList != null || (IsListInstalledWithApplication(sHistoryList) && bVerifyOnly))
                                {
                                    if (bVerifyOnly)
                                    {
                                        bool found = false;
                                        if (list != null)
                                        {
                                            foreach (SPWorkflowAssociation association in list.WorkflowAssociations)
                                            {
                                                if (association.BaseTemplate.Name == sName)
                                                {
                                                    found = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (found && !bOverwrite)
                                        {
                                            addMessage(ErrorLevels.Error, sName, "Workflow found and cannot overwrite", ParentMessageId);
                                        }
                                        else if (found)
                                        {
                                            addMessage(ErrorLevels.Upgrade, sName, "Workflow found and will upgrade", ParentMessageId);
                                        }
                                        else
                                        {
                                            addMessage(ErrorLevels.NoError, sName, "", ParentMessageId);
                                        }
                                    }
                                    else
                                    {
                                        SPWorkflowAssociation association = null;

                                        bool found = false;

                                        foreach (SPWorkflowAssociation oassociation in list.WorkflowAssociations)
                                        {
                                            if (oassociation.BaseTemplate.Name == sName)
                                            {
                                                association = oassociation;
                                                found = true;
                                                break;
                                            }
                                        }

                                        if (found && bOverwrite)
                                        {
                                            found = false;
                                            list.WorkflowAssociations.Remove(association);

                                            iInstallListsWorkflowsInstall(list, sName, sDisplayName, oTaskList, oHistoryList, ndWorkflow);

                                            addMessage(ErrorLevels.Upgrade, sName, "Workflow found and was upgraded", ParentMessageId);
                                        }
                                        else if (found)
                                        {
                                            addMessage(ErrorLevels.Error, sName, "Workflow found and could not overwrite", ParentMessageId);
                                        }
                                        else
                                        {
                                            iInstallListsWorkflowsInstall(list, sName, sDisplayName, oTaskList, oHistoryList, ndWorkflow);

                                            addMessage(ErrorLevels.NoError, sName, "", ParentMessageId);
                                        }
                                    }

                                }
                                else
                                {
                                    addMessage(ErrorLevels.Error, sName, "Workflow history list (" + sHistoryList + ") does not exist", ParentMessageId);
                                }
                            }
                            else
                            {
                                addMessage(ErrorLevels.Error, sName, "Workflow task list (" + sTaskList + ") does not exist", ParentMessageId);
                            }


                        }
                        catch (Exception ex) { addMessage(ErrorLevels.Error, sName, "Error: " + ex.Message, ParentMessageId); }

                    }
                }
            }
        }

        private void iInstallListsViewsWebpartsInstall(SPView oView, XmlNode ndView, bool bInstallGrid, ApplicationStore.AppStore copy, int ParentMessageId)
        {
            SPFile oViewFile = oWeb.GetFile(oView.Url);

            if (oViewFile.Exists)
            {

                string sUrl = appDef.fullurl + "/Lists/" + oView.ParentList.Title + "/" + oView.Title + ".txt";

                bool bHasViewFile = false;
                try
                {
                    byte[] fileBytes = copy.GetFile(sUrl);
                    if (fileBytes != null)
                    {
                        SPFolder folder = oWeb.GetFolder("TempViewStorage");

                        if (!folder.Exists)
                            folder = oWeb.Folders.Add("TempViewStorage");

                        if (!bVerifyOnly)
                            folder.Files.Add(oView.Title + ".aspx", fileBytes);

                        bHasViewFile = true;
                    }
                }
                catch { }

                if (bVerifyOnly)
                {
                    if (bHasViewFile || bInstallGrid)
                    {
                        addMessage(0, oView.Title, "", ParentMessageId);
                    }
                }
                else
                {
                    SPLimitedWebPartManager oViewWebManager = oViewFile.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                    if (bHasViewFile)
                    {
                        SPFile oTempFile = null;
                        try
                        {

                            oTempFile = oWeb.GetFile("TempViewStorage/" + oView.Title + ".aspx");
                            var tempFileContents = oTempFile.GetContents();
                            oViewFile.UpdateContentsAndSave(tempFileContents);

                            SPLimitedWebPartManager oTempFileWebManager = oTempFile.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                            ArrayList arrWebParts = new ArrayList();

                            foreach (WebPart wp in oViewWebManager.WebParts)
                            {
                                if (wp is XsltListViewWebPart)
                                {
                                    wp.Hidden = true;
                                    oViewWebManager.SaveChanges(wp);
                                }

                                if (wp.GetType().ToString() != "Microsoft.SharePoint.WebPartPages.ErrorWebPart" && !(wp is XsltListViewWebPart))
                                {
                                    arrWebParts.Add(wp);
                                }
                            }

                            foreach (WebPart wp in arrWebParts)
                            {
                                oViewWebManager.DeleteWebPart(wp);
                            }

                            foreach (WebPart wp in oTempFileWebManager.WebParts)
                            {
                                if (wp.GetType().ToString() != "Microsoft.SharePoint.WebPartPages.ErrorWebPart" && !(wp is XsltListViewWebPart))
                                {
                                    oViewWebManager.AddWebPart(wp, wp.ZoneID, wp.ZoneIndex);
                                }
                            }


                            ConnectWebPartConsumersToReportFilter(oViewWebManager);


                            addMessage(0, oView.Title, "", ParentMessageId);
                        }
                        catch (Exception ex)
                        {
                            addMessage(ErrorLevels.Error, oView.Title, "Error: " + ex.Message, ParentMessageId);
                        }
                        finally
                        {
                            if (oTempFile != null) oTempFile.Delete();
                            oViewWebManager.Dispose();
                        }
                    }
                    else
                    {
                        bool bHasGrid = false;

                        try
                        {
                            if (bInstallGrid)
                            {
                                foreach (WebPart wp in oViewWebManager.WebParts)
                                {
                                    if (wp.GetType().ToString() == "EPMLiveWebParts.GridListView")
                                    {
                                        bHasGrid = true;
                                        break;
                                    }
                                }

                                if (!bHasGrid)
                                {
                                    EPMLiveWebParts.GridListView gv = new EPMLiveWebParts.GridListView();
                                    oViewWebManager.AddWebPart(gv, "Main", 0);
                                }
                            }
                            addMessage(0, oView.Title, "", ParentMessageId);
                        }
                        catch (Exception ex)
                        {
                            addMessage(ErrorLevels.Error, oView.Title, "Error: " + ex.Message, ParentMessageId);
                        }
                    }
                }
            }
        }

        private void ConnectWebPartConsumersToReportFilter(SPLimitedWebPartManager webPartManager)
        {
            // Get the report filter provider.
            var providerWebPart = webPartManager.WebParts.Cast<System.Web.UI.WebControls.WebParts.WebPart>().Where(e => e.GetType().ToString() == "EPMLiveWebParts.ReportingFilter").FirstOrDefault();

            if (providerWebPart == null) return;

            ProviderConnectionPoint providerConnection = null;

            foreach (ProviderConnectionPoint point in webPartManager.GetProviderConnectionPoints(providerWebPart))
            {
                if (point.InterfaceType == typeof(IReportID))
                {
                    providerConnection = point;
                    break;
                }
            }

            // Run through each consumer and connect them to the report filter.
            foreach (WebPart webPart in webPartManager.WebParts)
            {
                if (webPart == providerWebPart) continue;

                foreach (ConsumerConnectionPoint point in webPartManager.GetConsumerConnectionPoints(webPart))
                {
                    if (point.InterfaceType == typeof(IReportID))
                    {
                        webPartManager.SPConnectWebParts(providerWebPart, providerConnection, webPart, point);

                        break;
                    }
                }

            }
        }

        private void iInstallListsViewsWebparts(SPList oList, XmlNode ndList, int ParentMessageId, bool added)
        {
            //TODO: Install WebParts
            XmlNode ndViews = ndList.SelectSingleNode("Views");

            if (ndViews != null)
            {
                string storeurl = CoreFunctions.getFarmSetting("workenginestore");

                ServicePointManager.ServerCertificateValidationCallback +=
                delegate(
                    object sender,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                ApplicationStore.AppStore copy = new ApplicationStore.AppStore();
                copy.Credentials = CoreFunctions.GetStoreCreds();
                copy.Url = storeurl + "_vti_bin/appstore.asmx";

                if (bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking WebParts", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Updating WebParts", "", ParentMessageId);

                bool bInstallAll = false;
                bool.TryParse(getAttribute(ndViews, "InstallGridOnAllViews"), out bInstallAll);

                if (bInstallAll)
                    addMessage(0, "Grid on All Views", "", ParentMessageId);

                if (oList != null)
                {
                    foreach (SPView oView in oList.Views)
                    {
                        if (!oView.PersonalView)
                        {
                            XmlNode ndView = ndViews.SelectSingleNode("View[@Name='" + oView.Title + "']");

                            iInstallListsViewsWebpartsInstall(oView, ndView, bInstallAll, copy, ParentMessageId);

                        }
                    }
                }
            }
        }

        private void iInstallListsViews(SPList list, XmlNode ndList, int ParentMessageId, bool added)
        {
            XmlNode ndViews = ndList.SelectSingleNode("Views");

            if (ndViews != null)
            {
                if (bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Views", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Updating Views", "", ParentMessageId);

                foreach (XmlNode ndView in ndViews.SelectNodes("View"))
                {
                    string sName = getAttribute(ndView, "Name");
                    //XmlNode ndInternalViewXml = ndView.SelectSingleNode("Field");
                    bool bOverwrite = false;
                    bool.TryParse(getAttribute(ndView, "Overwrite"), out bOverwrite);

                    SPView view = null;
                    try
                    {
                        view = list.Views[sName];
                    }
                    catch { }

                    int ViewParentMessageId = 0;

                    if (bVerifyOnly)
                    {
                        if (view == null)
                        {
                            ViewParentMessageId = addMessage(0, sName, "", ParentMessageId);
                        }
                        else
                        {
                            if (bOverwrite)
                            {
                                ViewParentMessageId = addMessage(ErrorLevels.Upgrade, sName, "View exists and will overwrite", ParentMessageId);
                            }
                            else
                            {
                                ViewParentMessageId = addMessage(ErrorLevels.Warning, sName, "View exists but can't overwrite", ParentMessageId);
                            }
                        }
                    }
                    else
                    {
                        if (list != null)
                        {
                            if (view == null)
                            {
                                try
                                {
                                    System.Collections.Specialized.StringCollection sFields = new System.Collections.Specialized.StringCollection();
                                    sFields.AddRange(ndView.SelectSingleNode("Fields").InnerText.Split(','));
                                    string sQuery = getChildNodeText(ndView, "Query");
                                    string sProjectedFields = getChildNodeText(ndView, "ProjectedFields");
                                    string sJoins = getChildNodeText(ndView, "Joins");

                                    uint iRowLimit = 0;
                                    uint.TryParse(getAttribute(ndView, "RowLimit"), out iRowLimit);

                                    bool bDefault = false;
                                    bool.TryParse(getAttribute(ndView, "MakeDefault"), out bDefault);

                                    view = list.Views.Add(sName, sFields, sQuery, sJoins, sProjectedFields, iRowLimit, false, bDefault, SPViewCollection.SPViewType.Html, false);

                                    ViewParentMessageId = addMessage(0, sName, "", ParentMessageId);

                                }
                                catch (Exception ex)
                                {
                                    ViewParentMessageId = addMessage(ErrorLevels.Error, sName, "Error adding view: " + ex.Message, ParentMessageId);
                                }
                            }
                            else
                            {
                                if (bOverwrite)
                                {

                                    try
                                    {

                                        string[] sFields = ndView.SelectSingleNode("Fields").InnerText.Split(',');
                                        string sQuery = getChildNodeText(ndView, "Query");
                                        string sProjectedFields = getChildNodeText(ndView, "ProjectedFields");
                                        string sJoins = getChildNodeText(ndView, "Joins");

                                        uint iRowLimit = 0;
                                        uint.TryParse(getAttribute(ndView, "RowLimit"), out iRowLimit);

                                        bool bDefault = false;
                                        bool.TryParse(getAttribute(ndView, "MakeDefault"), out bDefault);

                                        view.ViewFields.DeleteAll();

                                        foreach (string sField in sFields)
                                        {
                                            SPField oField = null;
                                            try
                                            {
                                                oField = list.Fields.GetFieldByInternalName(sField);
                                            }
                                            catch { }
                                            if (oField != null)
                                                view.ViewFields.Add(oField);
                                        }

                                        view.Query = sQuery;
                                        view.ProjectedFields = sProjectedFields;
                                        view.Joins = sJoins;
                                        view.RowLimit = iRowLimit;
                                        view.DefaultView = bDefault;
                                        view.Update();

                                        ViewParentMessageId = addMessage(ErrorLevels.Upgrade, sName, "View exists and will overwrite", ParentMessageId);

                                    }
                                    catch (Exception ex)
                                    {
                                        ViewParentMessageId = addMessage(ErrorLevels.Error, sName, "Error updating view: " + ex.Message, ParentMessageId);
                                    }
                                }
                                else
                                {
                                    ViewParentMessageId = addMessage(ErrorLevels.Warning, sName, "View exists but can't overwrite", ParentMessageId);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void iInstallListsFields(SPList list, XmlNode ndList, int ParentMessageId, bool added)
        {
            XmlNode ndFields = ndList.SelectSingleNode("Fields");

            if (ndFields != null)
            {
                if (bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Fields", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Updating Fields", "", ParentMessageId);

                foreach (XmlNode ndField in ndFields.SelectNodes("Field"))
                {

                    string sInternalName = getAttribute(ndField, "InternalName");
                    XmlNode ndInternalFieldXml = ndField.SelectSingleNode("Field");
                    string sType = getAttribute(ndInternalFieldXml, "Type");
                    bool bOverwrite = false;
                    bool.TryParse(getAttribute(ndField, "Overwrite"), out bOverwrite);

                    string sTotal = getAttribute(ndField, "Total");

                    SPField oField = null;
                    try
                    {
                        oField = list.Fields.GetFieldByInternalName(sInternalName);
                    }
                    catch { }

                    if (oField == null)//field new let's add
                    {
                        if (bVerifyOnly)
                        {
                            SPFieldType oType = iGetFieldTypeByString(sType);

                            addMessage(ErrorLevels.NoError, sInternalName, "", ParentMessageId);

                        }
                        else
                        {
                            try
                            {
                                oField = iInstallListFieldsAddField(list, sInternalName, sType, ndInternalFieldXml);
                                try
                                {
                                    if (oField != null)
                                        iInstallListFieldSwapXml(list, oField, ndInternalFieldXml);

                                    addMessage(ErrorLevels.NoError, sInternalName, "", ParentMessageId);
                                }
                                catch (Exception ex)
                                {
                                    addMessage(ErrorLevels.Error, sInternalName, "Error updating field schema: " + ex.Message, ParentMessageId);
                                }
                            }
                            catch (Exception ex)
                            {
                                addMessage(ErrorLevels.Error, sInternalName, "Error adding field: " + ex.Message, ParentMessageId);
                            }


                        }
                    }
                    else//field exists so we can upgrade
                    {
                        if (oField.TypeAsString.ToLower() == sType.ToLower())
                        {
                            if (bOverwrite)
                            {
                                if (bVerifyOnly)
                                {
                                    addMessage(ErrorLevels.Upgrade, sInternalName, "Field exists and will overwrite", ParentMessageId);
                                }
                                else
                                {
                                    try
                                    {
                                        if (oField != null)
                                            iInstallListFieldSwapXml(list, oField, ndInternalFieldXml);

                                        addMessage(ErrorLevels.NoError, sInternalName, "Field updated", ParentMessageId);
                                    }
                                    catch (Exception ex)
                                    {
                                        addMessage(ErrorLevels.Error, sInternalName, "Error updating field schema: " + ex.Message, ParentMessageId);
                                    }
                                }
                            }
                            else
                            {
                                addMessage(ErrorLevels.Warning, sInternalName, "Field exists and cannot overwrite", ParentMessageId);
                            }
                        }
                        else
                        {
                            addMessage(ErrorLevels.Error, sInternalName, "Field type mistmatch", ParentMessageId);
                        }
                    }

                    if (!string.IsNullOrEmpty(sTotal))
                    {
                        GridGanttSettings gSettings = new GridGanttSettings(list);

                        string output = "";

                        string[] fieldList = gSettings.TotalSettings.Split('\n');

                        foreach (string field in fieldList)
                        {
                            if (field != "")
                            {
                                string[] fieldData = field.Split('|');
                                if (fieldData[0] != sInternalName)
                                {
                                    output += "\n" + field;
                                }
                            }
                        }

                        output += "\n" + sInternalName + "|" + sTotal;

                        gSettings.TotalSettings = output.Trim('\n');
                        gSettings.SaveSettings(list);
                    }
                }
            }
        }

        private void iInstallListsLookups(SPList list, XmlNode ndList, int ParentMessageId)
        {
            XmlNode ndParent = ndList.ParentNode;

            XmlNode ndLookups = ndList.SelectSingleNode("Lookups");

            if (ndLookups != null)
            {
                if (bVerifyOnly)
                    ParentMessageId = addMessage(0, "Checking Lookups", "", ParentMessageId);
                else
                    ParentMessageId = addMessage(0, "Fixing Lookups", "", ParentMessageId);

                foreach (XmlNode ndLookup in ndLookups.SelectNodes("Lookup"))
                {
                    string sInternalName = getAttribute(ndLookup, "InternalName");

                    try
                    {

                        string sList = getAttribute(ndLookup, "List");
                        string sField = getAttribute(ndLookup, "Field");
                        string sDisplayName = getAttribute(ndLookup, "DisplayName");
                        string sAdvancedLookup = getAttribute(ndLookup, "AdvancedLookup");

                        bool bOverwrite = false;
                        bool.TryParse(getAttribute(ndLookup, "Overwrite"), out bOverwrite);

                        bool bRequired = false;
                        bool.TryParse(getAttribute(ndLookup, "Required"), out bRequired);

                        bool bDeleteIfNoList = false;
                        bool.TryParse(getAttribute(ndLookup, "DeleteIfNoList"), out bDeleteIfNoList);

                        SPList tList = oWeb.Lists.TryGetList(sList);
                        SPField tField = null;
                        try
                        {
                            tField = list.Fields.GetFieldByInternalName(sInternalName);
                        }
                        catch { }

                        if (tList != null)//If the parent list is found then lets use it
                        {
                            int tParentFieldMessage = ParentMessageId;

                            if (tField == null)//Field does not exist, lets add
                            {
                                if (!bVerifyOnly)
                                {
                                    try
                                    {
                                        list.Fields.AddLookup(sInternalName, tList.ID, bRequired);
                                        SPFieldLookup ttField = (SPFieldLookup)list.Fields.GetFieldByInternalName(sInternalName);
                                        if (sDisplayName != "")
                                            ttField.Title = sDisplayName;
                                        ttField.LookupField = sField;

                                        ttField.Update();
                                        tParentFieldMessage = addMessage(0, sInternalName, "Field added", ParentMessageId);
                                    }
                                    catch (Exception ex)
                                    {
                                        tParentFieldMessage = addMessage(ErrorLevels.Error, sInternalName, "Error adding field: " + ex.Message, ParentMessageId);
                                    }
                                }
                                else
                                {
                                    tParentFieldMessage = addMessage(0, sInternalName, "", ParentMessageId);
                                }
                            }
                            else//If the field exists
                            {
                                if (tField.Type == SPFieldType.Lookup)
                                {
                                    if (bVerifyOnly)
                                    {
                                        if (bOverwrite)
                                        {
                                            tParentFieldMessage = addMessage(ErrorLevels.Upgrade, sInternalName, "Field exists and will overwrite", ParentMessageId);
                                        }
                                        else
                                        {
                                            tParentFieldMessage = addMessage(ErrorLevels.Error, sInternalName, "Field exists and will not overwrite", ParentMessageId);
                                        }
                                    }
                                    else
                                    {
                                        if (bOverwrite)
                                        {
                                            try
                                            {
                                                XmlDocument doc = new XmlDocument();
                                                doc.LoadXml(tField.SchemaXml);

                                                doc.FirstChild.Attributes["List"].Value = tList.ID.ToString("B");
                                                doc.FirstChild.Attributes["ShowField"].Value = sField;


                                                tField.SchemaXml = doc.FirstChild.OuterXml;
                                                tField.Update(true);

                                                tParentFieldMessage = addMessage(0, sInternalName, "Field updated", ParentMessageId);
                                            }
                                            catch (Exception ex)
                                            {
                                                tParentFieldMessage = addMessage(ErrorLevels.Error, sInternalName, "Error updating field: " + ex.Message, ParentMessageId);
                                            }
                                        }
                                        else
                                        {
                                            tParentFieldMessage = addMessage(ErrorLevels.Error, sInternalName, "Field exists and will not overwrite", ParentMessageId);
                                        }
                                    }
                                }
                                else
                                {
                                    tParentFieldMessage = addMessage(ErrorLevels.Error, sInternalName, "Field exists and is not currently a lookup field", ParentMessageId);
                                }
                            }


                            if (!string.IsNullOrEmpty(sAdvancedLookup))
                            {
                                GridGanttSettings gSettings = new GridGanttSettings(list);

                                string[] LookupArray = gSettings.Lookups.Split('|');

                                string output = "";

                                foreach (string sLookup in LookupArray)
                                {
                                    if (sLookup != "")
                                    {
                                        string[] sLookupInfo = sLookup.Split('^');

                                        if (sLookupInfo[0] != sInternalName)
                                        {
                                            output += "|" + sLookup;
                                        }
                                    }
                                }

                                output += "|" + sInternalName + "^" + sAdvancedLookup;

                                gSettings.Lookups = output.Trim('|');
                                gSettings.SaveSettings(list);

                                addMessage(ErrorLevels.NoError, "Enabled Advanced Lookup", "", tParentFieldMessage);

                            }
                        }
                        else //If parent list is not found
                        {
                            if (bVerifyOnly)
                            {
                                if (ndParent.SelectSingleNode("List[@Name='" + sList + "']") != null)
                                {
                                    addMessage(0, sInternalName, "", ParentMessageId);
                                }
                                else
                                {
                                    if (bDeleteIfNoList)
                                    {
                                        addMessage(ErrorLevels.Upgrade, sInternalName, "Lookup List missing (" + sList + ") field will be deleted", ParentMessageId);
                                    }
                                    else
                                    {
                                        addMessage(ErrorLevels.Upgrade, sInternalName, "Lookup List missing (" + sList + ") field ignored", ParentMessageId);
                                    }
                                }
                            }
                            else
                            {
                                if (bDeleteIfNoList && tField != null)
                                {
                                    try
                                    {
                                        tField.Delete();
                                        list.Update();

                                        addMessage(ErrorLevels.Upgrade, sInternalName, "Lookup List missing (" + sList + ") field deleted", ParentMessageId);
                                    }
                                    catch (Exception ex)
                                    {
                                        addMessage(ErrorLevels.Error, sInternalName, "Lookup List missing (" + sList + ") field failed to delete: " + ex.Message, ParentMessageId);
                                    }
                                }
                                else
                                {
                                    addMessage(ErrorLevels.Upgrade, sInternalName, "Lookup List missing (" + sList + ") field ignored", ParentMessageId);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        addMessage(ErrorLevels.Error, sInternalName, "Error processing: " + ex.Message, ParentMessageId);
                    }
                }

            }
        }

        private void iInstallLists()
        {

            XmlNode ndLists = appDef.ApplicationXml.FirstChild.SelectSingleNode("Lists");
            if (ndLists != null)
            {
                int ParentMessageId = 0;

                if (bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Lists", "", 0);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Installing Lists", "", 0);
                }

                float percent = 0;

                XmlNodeList ListNdLists = ndLists.SelectNodes("List");
                float max = ListNdLists.Count;
                float counter = 0;

                foreach (XmlNode ndList in ListNdLists)
                {
                    try
                    {
                        string sListName = ndList.Attributes["Name"].Value;

                        bool bCanUpgrade = false;
                        bool.TryParse(getAttribute(ndList, "CanUpgrade"), out bCanUpgrade);

                        bool bAddReporting = false;
                        bool.TryParse(getAttribute(ndList, "Reporting"), out bAddReporting);

                        bool bDoesListExist = DoesListExist(sListName);

                        if (bDoesListExist)
                        {
                            XmlAttribute attrNoDelete = ndList.Attributes["NoDelete"];
                            if (attrNoDelete == null)
                            {
                                attrNoDelete = ndList.OwnerDocument.CreateAttribute("NoDelete");
                                attrNoDelete.Value = "True";
                                ndList.Attributes.Append(attrNoDelete);
                            }
                            else
                            {
                                attrNoDelete.Value = "True";
                            }
                        }


                        if (bDoesListExist && bCanUpgrade || !bDoesListExist)
                        {
                            SPList oList = null;
                            int ListParentMessageId = 0;
                            bool bListAdded = false;
                            if (bDoesListExist && bCanUpgrade)
                            {
                                ListParentMessageId = addMessage(ErrorLevels.NoError, sListName, "List exists and will upgrade", ParentMessageId);
                            }
                            else
                            {
                                try
                                {
                                    string error = "";
                                    if (!bVerifyOnly)
                                    {
                                        oList = iInstallListsAddList(ndList, out error);
                                        bListAdded = true;
                                    }
                                    if (error == "")
                                    {
                                        ListParentMessageId = addMessage(ErrorLevels.NoError, sListName, "", ParentMessageId);
                                    }
                                    else
                                    {
                                        ListParentMessageId = addMessage(ErrorLevels.Error, sListName, error, ParentMessageId);
                                    }

                                }
                                catch { }

                            }

                            oList = oWeb.Lists.TryGetList(sListName);

                            if (oList != null)
                                iInstallListsFields(oList, ndList, ListParentMessageId, bListAdded);

                            iInstallListsLookups(oList, ndList, ListParentMessageId);
                            iInstallListsViews(oList, ndList, ListParentMessageId, bListAdded);
                            iInstallListsViewsWebparts(oList, ndList, ListParentMessageId, bListAdded);
                            iInstallListsWorkflows(oList, ndList, ListParentMessageId, bListAdded);
                            iInstallListsEvents(oList, ndList, ListParentMessageId, bListAdded);
                            iInstallListsItems(oList, ndList, ListParentMessageId, bListAdded);

                            if (bAddReporting)
                            {
                                if (bVerifyOnly)
                                    addMessage(ErrorLevels.NoError, "Add to Reporting Database", "", ListParentMessageId);
                                else
                                {
                                    try
                                    {
                                        var rb = new EPMLiveReportsAdmin.ReportBiz(oList.ParentWeb.Site.ID);
                                        EPMLiveReportsAdmin.ListBiz lb = rb.GetListBiz(oList.ID);

                                        if (string.IsNullOrEmpty(lb.ListName))
                                        {
                                            System.Web.UI.WebControls.ListItemCollection oFields = new System.Web.UI.WebControls.ListItemCollection();

                                            //foreach(SPField field in oList.Fields)
                                            //{
                                            //    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem(field.Title, field.Id.ToString());
                                            //    oFields.Add(li);
                                            //}

                                            //rb.CreateListBiz(oList.ID, oFields);

                                            rb.CreateListBiz(oList.ID);
                                            addMessage(ErrorLevels.NoError, "Add to Reporting Database", "", ListParentMessageId);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        addMessage(ErrorLevels.Error, "Add to Reporting Database", ex.Message, ListParentMessageId);
                                    }
                                }
                            }
                        }
                        else
                        {
                            addMessage(ErrorLevels.Error, sListName, "List exists and cannot upgrade", ParentMessageId);
                        }
                    }
                    catch (Exception ex)
                    {
                        addMessage(ErrorLevels.Error, ndList.Attributes["Name"].Value, "Error: " + ex.Message, ParentMessageId);
                    }

                    counter++;
                    percent = counter / max;
                    updateLIPercent(percent);
                }

            }
        }
        #endregion

        #region Install Solutions

        private void iInstallSolutions()
        {
            XmlNode ndSolutions = appDef.ApplicationXml.FirstChild.SelectSingleNode("Solutions");
            int ParentMessageId = 0;

            if (ndSolutions != null)
            {
                if (bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Solutions and Lists", "", 0);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Installing Solutions and Lists", "", 0);
                }

                float percent = 0;

                XmlNodeList ListNdSolutions = ndSolutions.ChildNodes;
                float max = ListNdSolutions.Count;
                float counter = 0;

                foreach (XmlNode ndSolution in ListNdSolutions)
                {
                    switch (ndSolution.Name)
                    {
                        case "Solution":
                            iInstallSolution(ndSolution, ParentMessageId);
                            break;
                        case "ListTemplate":
                            iInstallListTemplate(ndSolution, ParentMessageId);
                            break;
                    }

                    counter++;
                    percent = counter / max;
                    updateLIPercent(percent);
                }
            }
        }

        private void iInstallSolution(XmlNode ndSolution, int ParentMessageId)
        {
            try
            {
                SPDocumentLibrary solutions = (SPDocumentLibrary)oWeb.Site.GetCatalog(SPListTemplateType.SolutionCatalog);

                string FileName = getAttribute(ndSolution, "FileName");
                bool bOverwrite = false;
                bool.TryParse(getAttribute(ndSolution, "Overwrite"), out bOverwrite);

                if (bVerifyOnly)
                {
                    bool found = false;

                    foreach (SPFile f in solutions.RootFolder.Files)
                    {
                        if (f.Name == FileName)
                        {
                            found = true;
                        }
                    }

                    if (found)
                    {
                        if (bOverwrite)
                        {
                            addMessage(ErrorLevels.Upgrade, FileName, "Solution exists but will upgrade", ParentMessageId);
                        }
                        else
                        {
                            addMessage(ErrorLevels.Error, FileName, "Solution exists and cannot upgrade", ParentMessageId);
                        }
                    }
                    else
                        addMessage(ErrorLevels.NoError, FileName, "", ParentMessageId);
                }
                else
                {

                    bool found = false;
                    SPFile foundFile = null;
                    foreach (SPFile f in solutions.RootFolder.Files)
                    {
                        if (f.Name == FileName)
                        {
                            foundFile = f;
                            found = true;
                        }
                    }

                    if (found)
                    {
                        foreach (SPUserSolution us in oWeb.Site.Solutions)
                        {
                            if (us.Name == FileName)
                            {
                                oWeb.Site.Solutions.Remove(us);
                                break;
                            }
                        }

                        foundFile.Delete();
                    }


                    SPFile newFile = null;

                    using (WebClient webClient = new WebClient())
                    {
                        ServicePointManager.ServerCertificateValidationCallback +=
                        delegate(
                            object sender,
                            X509Certificate certificate,
                            X509Chain chain,
                            SslPolicyErrors sslPolicyErrors)
                        {
                            return true;
                        };

                        webClient.Credentials = CoreFunctions.GetStoreCreds();
                        byte[] fileBytes = null;
                        fileBytes = webClient.DownloadData(appDef.fullurl + "/Solutions/" + FileName);
                        newFile = solutions.RootFolder.Files.Add(FileName, fileBytes);
                    }

                    if (newFile != null)
                    {
                        SPUserSolution solution = oWeb.Site.Solutions.Add(newFile.Item.ID);
                    }

                    addMessage(ErrorLevels.NoError, FileName, "", ParentMessageId);
                }
            }
            catch (Exception ex)
            {
                addMessage(ErrorLevels.Error, ndSolution.Attributes["FileName"].Value, "Error: " + ex.Message, ParentMessageId);
            }


        }

        private void iInstallListTemplate(XmlNode ndSolution, int ParentMessageId)
        {
            try
            {
                SPDocumentLibrary solutions = (SPDocumentLibrary)oWeb.Site.GetCatalog(SPListTemplateType.ListTemplateCatalog);

                string FileName = getAttribute(ndSolution, "FileName");
                bool bOverwrite = false;
                bool.TryParse(getAttribute(ndSolution, "Overwrite"), out bOverwrite);

                if (bVerifyOnly)
                {
                    bool found = false;

                    foreach (SPFile f in solutions.RootFolder.Files)
                    {
                        if (f.Name == FileName)
                        {
                            found = true;
                        }
                    }

                    if (found)
                    {
                        if (bOverwrite)
                        {
                            addMessage(ErrorLevels.Upgrade, FileName, "List template exists but will upgrade", ParentMessageId);
                        }
                        else
                        {
                            addMessage(ErrorLevels.Error, FileName, "List template exists and cannot upgrade", ParentMessageId);
                        }
                    }
                    else
                        addMessage(ErrorLevels.NoError, FileName, "", ParentMessageId);
                }
                else
                {

                    bool found = false;
                    SPFile foundFile = null;
                    foreach (SPFile f in solutions.RootFolder.Files)
                    {
                        if (f.Name == FileName)
                        {
                            foundFile = f;
                            found = true;
                        }
                    }

                    if (found && bOverwrite)
                    {
                        foundFile.Delete();
                    }

                    if (!found || bOverwrite)
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            ServicePointManager.ServerCertificateValidationCallback +=
                            delegate(
                                object sender,
                                X509Certificate certificate,
                                X509Chain chain,
                                SslPolicyErrors sslPolicyErrors)
                            {
                                return true;

                            };

                            webClient.Credentials = CoreFunctions.GetStoreCreds();
                            byte[] fileBytes = null;
                            fileBytes = webClient.DownloadData(appDef.fullurl + "/Lists/" + FileName);
                            solutions.RootFolder.Files.Add(FileName, fileBytes);
                        }

                        if (found)
                            addMessage(ErrorLevels.NoError, FileName, "List template upgraded", ParentMessageId);
                        else
                            addMessage(ErrorLevels.NoError, FileName, "", ParentMessageId);
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, FileName, "List template exists and cannot upgrade", ParentMessageId);
                    }
                }
            }
            catch (Exception ex)
            {
                addMessage(ErrorLevels.Error, ndSolution.Attributes["FileName"].Value, "Error: " + ex.Message, ParentMessageId);
            }


        }

        #endregion

        #region Install Files
        private int GetParentFolderId(Hashtable hshParents, string sParentFolder, int mainId)
        {
            if (hshParents.ContainsKey(sParentFolder))
                return (int)hshParents[sParentFolder];

            return mainId;
        }

        private void iInstallFile(string sFileName, string sParentFolder, string sFullFile, ApplicationStore.AppStore copy)
        {
            SPFolder oParentFolder = oWeb.GetFolder(sParentFolder);

            if (oParentFolder.Exists)
            {
                string sUrl = appDef.fullurl + "/Files/" + sFullFile;

                byte[] fileBytes = copy.GetFile(sUrl);

                oParentFolder.Files.Add(sFileName, fileBytes, true);

            }
            else
            {
                throw new Exception("Parent folder does not exist");
            }
        }

        private void iInstallFilesProcessFolder(int ParentMessageId, float counter, XmlNode ndFolder, float max, ApplicationStore.AppStore copy, bool bOverwrite)
        {
            XmlNode ndLists = appDef.ApplicationXml.FirstChild.SelectSingleNode("Lists");

            foreach (XmlNode ndChild in ndFolder.ChildNodes)
            {
                string sRemoteName = getAttribute(ndChild, "RemoteFile");
                string sType = getAttribute(ndChild, "Type");
                string sFullFile = sRemoteName.Replace(appDef.appurl + "/Files/", "");
                string sFileName = getAttribute(ndChild, "Name");
                string sParentFolder = System.IO.Path.GetDirectoryName(sFullFile).Replace("\\", "/");

                try
                {

                    if (sType == "1")
                    {
                        SPFolder oFolder = oWeb.GetFolder(sFullFile);

                        int iId = ParentMessageId;
                        bool bProcessFolder = false;

                        if (!oFolder.Exists)
                        {
                            if (sFullFile.Contains("/"))
                            {
                                if (!bVerifyOnly)
                                {
                                    oWeb.Folders.Add(sFullFile);
                                    oFolder = oWeb.GetFolder(sFullFile);
                                }
                                bProcessFolder = true;
                                iId = addMessage(ErrorLevels.NoError, "Folder: " + sFileName, "", ParentMessageId);
                            }
                            else
                            {
                                XmlNode ndList = null;
                                try
                                {
                                    ndList = ndLists.SelectSingleNode("List[@Name='" + sFileName + "']");
                                }
                                catch { }

                                if (ndList == null)
                                {
                                    iId = addMessage(ErrorLevels.Error, "Folder: " + sFileName, "Document Library or Folder does not exist.", ParentMessageId);
                                }
                                else
                                {
                                    iId = addMessage(ErrorLevels.NoError, "Folder: " + sFileName, "", ParentMessageId);
                                    bProcessFolder = true;
                                }
                            }

                        }
                        else
                        {
                            XmlAttribute attrNoDelete = ndChild.Attributes["NoDelete"];
                            if (attrNoDelete == null)
                            {
                                attrNoDelete = ndChild.OwnerDocument.CreateAttribute("NoDelete");
                                attrNoDelete.Value = "True";
                                ndChild.Attributes.Append(attrNoDelete);
                            }
                            else
                            {
                                attrNoDelete.Value = "True";
                            }

                            bProcessFolder = true;
                            iId = addMessage(ErrorLevels.NoError, "Folder: " + sFileName, "", ParentMessageId);
                        }

                        bool bOverwriteFolder = bOverwrite;
                        try
                        {
                            bOverwriteFolder = bool.Parse(getAttribute(ndChild, "Overwrite"));
                        }
                        catch { }

                        if (bProcessFolder)
                            iInstallFilesProcessFolder(iId, counter, ndChild, max, copy, bOverwriteFolder);
                    }
                    else
                    {
                        bool bOverwriteFile = false;
                        try
                        {
                            bOverwriteFile = bool.Parse(getAttribute(ndChild, "Overwrite"));
                        }
                        catch { }

                        SPFile oFile = oWeb.GetFile(getAttribute(ndChild, "FullFile"));
                        if (oFile.Exists)
                        {
                            if (bOverwrite || bOverwriteFile)
                            {
                                try
                                {
                                    if (!bVerifyOnly)
                                        iInstallFile(sFileName, sParentFolder, sFullFile, copy);

                                    addMessage(ErrorLevels.NoError, "File: " + sFileName, "", ParentMessageId);
                                }
                                catch (Exception ex)
                                {
                                    addMessage(ErrorLevels.Error, "File: " + sFileName, "Error: " + ex.Message, ParentMessageId);
                                }
                            }
                            else
                            {
                                addMessage(ErrorLevels.Warning, "File: " + sFileName, "File exists and can't overwrite", ParentMessageId);
                            }
                        }
                        else
                        {
                            try
                            {
                                if (!bVerifyOnly)
                                    iInstallFile(sFileName, sParentFolder, sFullFile, copy);

                                addMessage(ErrorLevels.NoError, "File: " + sFileName, "", ParentMessageId);
                            }
                            catch (Exception ex)
                            {
                                addMessage(ErrorLevels.Error, "File: " + sFileName, "Error: " + ex.Message, ParentMessageId);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    addMessage(ErrorLevels.Error, sFileName, "Error: " + ex.Message, ParentMessageId);
                }

                counter++;
                float percent = counter / max;
                updateLIPercent(percent);
            }


        }

        private XmlNode iInstallFiles()
        {
            int ParentMessageId = 0;

            if (bVerifyOnly)
            {
                ParentMessageId = addMessage(0, "Checking Files", "", 0);
            }
            else
            {
                ParentMessageId = addMessage(0, "Installing Files", "", 0);
            }

            XmlDocument docFiles = new XmlDocument();
            docFiles.LoadXml("<Files/>");

            try
            {
                XmlNode ndFiles = appDef.ApplicationXml.FirstChild.SelectSingleNode("Files");

                string storeurl = CoreFunctions.getFarmSetting("workenginestore");

                ServicePointManager.ServerCertificateValidationCallback +=
                delegate(
                    object sender,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                var listSvc = new WorkEngineSolutionStoreListSvc.Lists();
                listSvc.Url = storeurl + "_vti_bin/lists.asmx";
                listSvc.Credentials = CoreFunctions.GetStoreCreds();

                ApplicationStore.AppStore copy = new ApplicationStore.AppStore();
                copy.Credentials = CoreFunctions.GetStoreCreds();
                copy.Url = storeurl + "_vti_bin/appstore.asmx";

                XmlDocument xDoc = new XmlDocument();

                XmlNode ndQuery = xDoc.CreateNode(XmlNodeType.Element, "Query", "");
                ndQuery.InnerXml = "<OrderBy><FieldRef Name='FileRef'/></OrderBy>";

                XmlNode ndQueryOptions = xDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
                ndQueryOptions.InnerXml = "<Folder>" + appDef.appurl + "/Files</Folder><ViewAttributes Scope=\"RecursiveAll\" />";

                XmlNode ndViewFields = xDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
                ndViewFields.InnerXml = "<FieldRef Name='Title'/>";

                XmlNode ndItems = listSvc.GetListItems("Applications", null, ndQuery, ndViewFields, "10000", ndQueryOptions, null);

                float max = 0;

                foreach (XmlNode nd in ndItems.ChildNodes)
                {
                    if (nd.Name == "rs:data")
                    {


                        float.TryParse(nd.Attributes["ItemCount"].Value, out max);
                        if (max > 0)
                        {
                            if (!bVerifyOnly)
                            {

                            }

                            foreach (XmlNode ndChild in nd.ChildNodes)
                            {
                                if (ndChild.Name == "z:row")
                                {
                                    SPFieldLookupValue lvFSObjType = new SPFieldLookupValue(ndChild.Attributes["ows_FSObjType"].Value);
                                    SPFieldLookupValue lvFileRef = new SPFieldLookupValue(ndChild.Attributes["ows_FileRef"].Value);
                                    SPFieldLookupValue lvFileLeafRef = new SPFieldLookupValue(ndChild.Attributes["ows_FileLeafRef"].Value);


                                    string sTitle = "";
                                    try
                                    {
                                        sTitle = ndChild.Attributes["ows_Title"].Value;
                                    }
                                    catch { sTitle = lvFileLeafRef.LookupValue; }

                                    string sRemoteFile = lvFileRef.LookupValue;
                                    string sFullFile = sRemoteFile.Replace(appDef.appurl + "/Files/", "");
                                    string sFileName = System.IO.Path.GetFileName(sFullFile);
                                    string sParentFolder = System.IO.Path.GetDirectoryName(sFullFile).Replace("\\", "/");

                                    bool bOverwrite = false;

                                    if (System.IO.Path.GetExtension(sFileName) == ".txt")
                                    {
                                        if (sTitle.Contains("."))
                                            sFileName = sTitle;
                                    }

                                    sFullFile = System.IO.Path.GetDirectoryName(sRemoteFile.Replace(appDef.appurl + "/Files/", "")) + "/" + sFileName;
                                    sFullFile = sFullFile.Replace("\\", "/");
                                    sFullFile = sFullFile.Trim('/');

                                    XmlNode ndNew = docFiles.CreateNode(XmlNodeType.Element, "File", docFiles.NamespaceURI);

                                    XmlAttribute attr = docFiles.CreateAttribute("Name");
                                    attr.Value = sFileName;
                                    ndNew.Attributes.Append(attr);


                                    attr = docFiles.CreateAttribute("RemoteFile");
                                    attr.Value = sRemoteFile;
                                    ndNew.Attributes.Append(attr);

                                    try
                                    {
                                        bOverwrite = bool.Parse(ndFiles.SelectSingleNode("File[@Path='" + sFullFile + "']").Attributes["Overwrite"].Value);
                                        attr = docFiles.CreateAttribute("Overwrite");
                                        attr.Value = bOverwrite.ToString();
                                        ndNew.Attributes.Append(attr);
                                    }
                                    catch { }

                                    try
                                    {
                                        attr = docFiles.CreateAttribute("NoDelete");
                                        attr.Value = ndFiles.SelectSingleNode("File[@Path='" + sFullFile + "']").Attributes["NoDelete"].Value;
                                        ndNew.Attributes.Append(attr);
                                    }
                                    catch { }

                                    attr = docFiles.CreateAttribute("Type");
                                    attr.Value = lvFSObjType.LookupValue;
                                    ndNew.Attributes.Append(attr);

                                    attr = docFiles.CreateAttribute("FullFile");
                                    attr.Value = sFullFile;
                                    ndNew.Attributes.Append(attr);

                                    XmlNode ndParent = docFiles.FirstChild.SelectSingleNode("//File[@FullFile='" + sParentFolder + "']");

                                    if (ndParent == null)
                                        docFiles.FirstChild.AppendChild(ndNew);
                                    else
                                        ndParent.AppendChild(ndNew);

                                }
                            }
                        }
                    }
                }

                iInstallFilesProcessFolder(ParentMessageId, 0, docFiles.FirstChild, max, copy, false);
            }
            catch (Exception ex)
            {
                addMessage(ErrorLevels.Error, "Installing Files", "Error: " + ex.Message, ParentMessageId);
            }

            return docFiles.FirstChild;
        }

        #endregion

        private void iProcessLI(XmlNode ndApp)
        {
            try
            {
                oListItem["Description"] = ndApp.SelectSingleNode("Description").InnerText;
            }
            catch { }
            if (bVerifyOnly)
            {
                oListItem["Status"] = "PreCheck Started";
            }
            else
            {
                oListItem["Status"] = "Install Started";
            }
            oListItem["InstallPercent"] = 0;
            oListItem["AppVersion"] = appDef.Version;
            oListItem["AppUrl"] = appDef.fullurl;
            oListItem.Update();

            if (!bVerifyOnly)
            {
                if (appDef.Icon != null && appDef.Icon != "")
                {
                    using (WebClient webClient = new WebClient())
                    {
                        ServicePointManager.ServerCertificateValidationCallback +=
                        delegate(
                            object sender,
                            X509Certificate certificate,
                            X509Chain chain,
                            SslPolicyErrors sslPolicyErrors)
                        {
                            return true;
                        };

                        webClient.Credentials = CoreFunctions.GetStoreCreds();
                        byte[] fileBytes = null;
                        fileBytes = webClient.DownloadData(appDef.Icon);

                        oWeb.Files.Add("AppDocuments/" + oListItem.ID + System.IO.Path.GetExtension(appDef.Icon), fileBytes, true);

                        oListItem["Icon"] = ((oWeb.ServerRelativeUrl == "/") ? "" : oWeb.ServerRelativeUrl) + "/AppDocuments/" + oListItem.ID + System.IO.Path.GetExtension(appDef.Icon);
                    }
                }
            }
        }

        private void iInstallAndConfigureApp()
        {
            XmlDocument docFiles = new XmlDocument();
            docFiles.LoadXml("<Files/>");

            try
            {
                if (oAppList != null)
                {

                    XmlNode ndApp = appDef.ApplicationXml.FirstChild.SelectSingleNode("Application");

                    iProcessLI(ndApp);

                    addMessage(ErrorLevels.NoError, "Install Version", appDef.Version, 0);

                    if (!oWeb.IsRootWeb && !bIsInstalledElsewhere && !bVerifyOnly)
                    {
                        InstallOnRootWeb();
                    }

                    if (!bIsInstalledElsewhere)
                    {
                        _currentPercentSpan = 10;
                        _currentBasePercent = 0;
                        iInstallSolutions();
                    }

                    _currentPercentSpan = 10;
                    _currentBasePercent = 10;
                    iInstallFeatures();

                    _currentPercentSpan = 40;
                    _currentBasePercent = 20;
                    iInstallLists();

                    _currentPercentSpan = 10;
                    _currentBasePercent = 60;
                    iInstallProperties();

                    _currentPercentSpan = 10;
                    _currentBasePercent = 70;
                    docFiles.LoadXml(iInstallFiles().OuterXml);
                    //TODO: Fix Reports in Report Library (Data Connections)

                    if (appDef.Community != "" && !bVerifyOnly)
                    {
                        try
                        {
                            iCommunity = Applications.CreateCommunity(appDef.Community, oWeb);

                            oListItem["LinkedCommunity"] = iCommunity;

                            addMessage(ErrorLevels.NoError, "Creating Community", appDef.Community, 0);
                        }
                        catch (Exception ex)
                        {
                            addMessage(ErrorLevels.Error, "Creating Community", "Error: " + ex.Message, 0);
                        }
                    }

                    _currentPercentSpan = 10;
                    _currentBasePercent = 80;
                    iInstallQuickLaunch(docFiles);

                    //if(iCommunity != 0 && !bVerifyOnly)
                    //{
                    //    try
                    //    {
                    //        SPListItem oLiCommunity = oAppList.Items.GetItemById(iCommunity);
                    //        Applications.AddAppToCommunity(oLiCommunity, appDef.Id);
                    //    }
                    //    catch { }
                    //}

                    bool bProcessReports = false;

                    try
                    {
                        bool.TryParse(ndApp.Attributes["ProcessReports"].Value, out bProcessReports);
                    }
                    catch { }

                    _currentPercentSpan = 10;
                    _currentBasePercent = 90;

                    if (bProcessReports)
                    {
                        if (bVerifyOnly)
                            addMessage(ErrorLevels.NoError, "Processing Reports", "", 0);
                        else
                        {
                            try
                            {
                                API.Reporting.ProcessReportDataSources(oWeb, docFiles.OuterXml);

                                addMessage(ErrorLevels.NoError, "Processing Reports", "", 0);
                            }
                            catch (Exception ex)
                            {
                                addMessage(ErrorLevels.Error, "Processing Reports", "Error: " + ex.Message, 0);
                            }
                        }
                    }

                    if (!bVerifyOnly)
                    {

                        try
                        {
                            oListItem["InstallXML"] = appDef.ApplicationXml.OuterXml;
                        }
                        catch { }

                        //if(getAttribute(ndApp, "HomePage") != "")
                        //{
                        //    SPFieldUrlValue urlVal = new SPFieldUrlValue();
                        //    urlVal.Description = getAttribute(ndApp, "HomePage");
                        //    urlVal.Url = getAttribute(ndApp, "HomePage");
                        //    try
                        //    {
                        //        oListItem["HomePage"] = (oWeb.ServerRelativeUrl == "/") ? "" : oWeb.ServerRelativeUrl + "/" + urlVal;
                        //    }
                        //    catch { }
                        //}

                        //if(getAttribute(ndApp, "Visible") != "")
                        //{
                        //    bool visible = false;
                        //    bool.TryParse(getAttribute(ndApp, "Visible"), out visible);
                        //    try
                        //    {
                        //        oListItem["Visible"] = visible;

                        //    }
                        //    catch { }
                        //}

                        oListItem.Update();
                    }
                }
                else
                {
                    if (!bVerifyOnly)
                    {
                        addMessage(ErrorLevels.Error, "Installing Application", "Unable to find Installed Applications List", 0);
                    }
                }
            }
            catch (Exception ex)
            {
                addMessage(ErrorLevels.Error, "Installing Application", "Exception: " + ex.Message, 0);
            }

            if (oListItem != null)
            {
                oListItem["InstalledFiles"] = docFiles.InnerXml;
            }
        }


        private bool CheckForKeys()
        {
            XmlNode ndApplication = appDef.ApplicationXml.FirstChild.SelectSingleNode("Application");
            if (ndApplication != null)
            {
                if (ndApplication.Attributes["RequiredFeatureKeys"] != null)
                {
                    string reqKeys = ndApplication.Attributes["RequiredFeatureKeys"].Value;
                    if (reqKeys != "")
                    {
                        int ParentMessageId = addMessage(ErrorLevels.NoError, "Activation Key Check", "", 0);

                        bool failed = false;

                        string[] featureIds = reqKeys.Split(',');
                        //ArrayList installedFeatures = CoreFunctions.getActivatedFeatures();

                        Act act = new Act(oWeb);

                        foreach (string featureId in featureIds)
                        {
                            try
                            {
                                if (act.CheckFeatureLicense((ActFeature)int.Parse(featureId)) == 0)
                                {
                                    addMessage(ErrorLevels.NoError, CoreFunctions.getFeatureName(featureId), "", ParentMessageId);
                                }
                                else
                                {
                                    addMessage(ErrorLevels.Error, CoreFunctions.getFeatureName(featureId), "Activation Key Not Installed", ParentMessageId);

                                    failed = true;
                                }
                            }
                            catch { }
                        }

                        return !failed;
                    }
                }
            }
            return true;
        }

        private bool CheckForPreReqs()
        {
            if (oAppList != null)
            {
                int ParentMessageId = addMessage(ErrorLevels.NoError, "Pre Requisite Check", "", 0);

                bool failed = false;

                foreach (DictionaryEntry de in appDef.PreReqs)
                {
                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + de.Key + "</Value></Eq></Where>";
                    SPListItemCollection lic = oAppList.GetItems(query);

                    if (lic.Count > 0)
                    {
                        addMessage(ErrorLevels.NoError, de.Value.ToString(), "", ParentMessageId);
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, de.Value.ToString(), "Application not installed", ParentMessageId);

                        failed = true;
                    }
                }

                return !failed;
            }
            else
            {
                addMessage(ErrorLevels.Error, "Pre-Requisite Check", "Unable to find Installed Applications List", 0);
                return false;
            }
        }

        private bool CheckPermissions()
        {
            bool bHasPerms = false;

            if (bIsInstalledElsewhere)
            {
                SPUser oUser = oWeb.AllUsers.GetByID(_configJob.userid);

                try
                {
                    using (SPSite tempSite = new SPSite(oWeb.Site.ID, oUser.UserToken))
                    {
                        tempSite.CatchAccessDeniedException = false;
                        using (SPWeb tempWeb = tempSite.OpenWeb(oWeb.ID))
                        {
                            if (tempWeb.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
                                bHasPerms = true;
                        }
                    }
                }
                catch { }

                if (bHasPerms)
                {
                    addMessage(ErrorLevels.NoError, "Permissions Check", "", 0);
                }
                else
                {
                    addMessage(ErrorLevels.Error, "Permissions Check", "You do not have Manage Web permissions", 0);
                }
            }
            else
            {

                bool bHasSolutions = false;

                try
                {
                    XmlNode ndSolutions = appDef.ApplicationXml.FirstChild.SelectSingleNode("Solutions");
                    if (ndSolutions.ChildNodes.Count > 0)
                        bHasSolutions = true;
                }
                catch { }

                if (bHasSolutions)
                {
                    SPUser oUser = oWeb.AllUsers.GetByID(_configJob.userid);

                    if (oUser.IsSiteAdmin)
                    {
                        addMessage(ErrorLevels.NoError, "Permissions Check", "", 0);
                        bHasPerms = true;
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, "Permissions Check", "You are not a site collection administrator", 0);
                    }
                }
                else
                {

                    SPUser oUser = oWeb.AllUsers.GetByID(_configJob.userid);

                    try
                    {
                        using (SPSite tempSite = new SPSite(oWeb.Site.ID, oUser.UserToken))
                        {
                            tempSite.CatchAccessDeniedException = false;
                            using (SPWeb tempWeb = tempSite.OpenWeb(oWeb.ID))
                            {
                                if (tempWeb.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
                                    bHasPerms = true;
                            }
                        }
                    }
                    catch { }

                    if (bHasPerms)
                    {
                        addMessage(ErrorLevels.NoError, "Permissions Check", "", 0);
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
                    };
                }
                else
                {
                    switch (li["Status"].ToString())
                    {
                        case "Install Queued":
                            return true;
                        default:
                            return false;
                    };
                }
            }
            catch { }
            return false;
        }

        private bool CheckForApplicationList()
        {


            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + appDef.Id + "</Value></Eq></Where>";
            SPListItemCollection lic = oAppList.GetItems(query);

            if (lic.Count > 0)
            {
                if (CheckStatus(lic[0]))
                {
                    addMessage(ErrorLevels.NoError, "Application List", "", 0);
                    return true;
                }
                else
                {
                    addMessage(ErrorLevels.Error, "Application List", "Application has not been queued.", 0);
                    return false;
                }
            }
            else
            {
                query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + appDef.Title + "</Value></Eq></Where>";
                lic = oAppList.GetItems(query);
                if (lic.Count > 0)
                {
                    addMessage(ErrorLevels.Error, "Application List", "You already have an application with the same name installed", 0);
                    return false;
                }
                else
                {
                    addMessage(ErrorLevels.NoError, "Application List", "", 0);
                    return true;
                }
            }

        }

        #region Accessors

        public DataTable DtMessages
        {
            get
            {
                return _dtMessages;
            }
        }

        public XmlDocument XmlMessages
        {
            get
            {
                XmlDocument docMessages = new XmlDocument();
                docMessages.LoadXml("<Messages/>");
                XmlNode ndParent = docMessages.FirstChild;

                foreach (DataRow dr in _dtMessages.Rows)
                {
                    XmlNode ndMessageRow = docMessages.CreateNode(XmlNodeType.Element, "MessageRow", docMessages.NamespaceURI);

                    XmlAttribute attr = docMessages.CreateAttribute("ID");
                    attr.Value = dr["ID"].ToString();
                    ndMessageRow.Attributes.Append(attr);

                    attr = docMessages.CreateAttribute("ErrorLevel");
                    attr.Value = dr["ErrorLevel"].ToString();
                    ndMessageRow.Attributes.Append(attr);

                    XmlNode ndMessage = docMessages.CreateNode(XmlNodeType.Element, "Message", docMessages.NamespaceURI);
                    ndMessage.InnerXml = "<![CDATA[" + System.Web.HttpUtility.HtmlEncode(dr["Message"].ToString()) + "]]>";

                    ndMessageRow.AppendChild(ndMessage);

                    ndMessage = docMessages.CreateNode(XmlNodeType.Element, "Details", docMessages.NamespaceURI);
                    ndMessage.InnerXml = "<![CDATA[" + System.Web.HttpUtility.HtmlEncode(dr["Details"].ToString()) + "]]>";

                    ndMessageRow.AppendChild(ndMessage);

                    XmlNode ndParentMessageRow = ndParent.SelectSingleNode("//MessageRow[@ID='" + dr["ParentID"].ToString() + "']");

                    if (ndParentMessageRow != null)
                        ndParentMessageRow.AppendChild(ndMessageRow);
                    else
                        ndParent.AppendChild(ndMessageRow);

                }


                return docMessages;
            }
        }


        public DataTable DtMessagesHTML
        {
            get
            {
                DataTable dt = DtMessages.Clone();
                foreach (DataRow dr in DtMessages.Rows)
                {
                    DataRow drNew = dt.Rows.Add(new object[] { dr[0], dr[1], dr[2], dr[3], dr[4], dr[5] });

                    for (int i = 0; i < int.Parse(drNew["Tabbing"].ToString()); i++)
                    {
                        drNew["Message"] = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + drNew["Message"].ToString();
                    }
                }
                return dt;
            }
        }

        public string Message
        {
            get
            {
                StringBuilder sbMessage = new StringBuilder();
                DataTable dt = DtMessagesHTML;
                foreach (DataRow dr in dt.Rows)
                {
                    sbMessage.Append(dr[3].ToString());
                    sbMessage.Append("...");

                    switch ((ErrorLevels)int.Parse(dr[2].ToString()))
                    {
                        case ErrorLevels.NoError:
                        case ErrorLevels.Upgrade:
                            sbMessage.Append("Success");
                            break;
                        case ErrorLevels.Warning:
                            sbMessage.Append("Warning");
                            break;
                        case ErrorLevels.Error:
                            sbMessage.Append("Failed");
                            break;
                    }

                    if (dr[4].ToString().Length > 0)
                    {
                        sbMessage.Append(" (");
                        sbMessage.Append(dr[4].ToString());
                        sbMessage.Append(")");
                    }
                    sbMessage.Append("<br>");
                }

                return sbMessage.ToString();
            }
        }

        public int MaxErrorLevel
        {
            get
            {
                return _maxErrorLevel;
            }
        }
        #endregion

    }
}
