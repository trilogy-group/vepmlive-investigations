using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using EPMLiveCore.ListDefinitions;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps.OptIn
{
    [UpgradeStep(Version = EPMLiveVersion.V55, Order = 1.0, Description = "Updating User Interface", IsOptIn = true)]
    internal class UpdateUI55 : UpgradeStep
    {
        #region Constructors (1) 

        public UpdateUI55(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 

        #region Methods (3) 

        // Private Methods (3) 

        private void ChangeMasterPage(string masterPage, SPWeb spWeb)
        {
            LogMessage("Changing MasterPage to: " + masterPage, 2);

            string url = (spWeb.ServerRelativeUrl == "/" ? string.Empty : spWeb.ServerRelativeUrl);

            spWeb.MasterUrl = string.Format(url + "/_catalogs/masterpage/{0}.master", masterPage);
            spWeb.CustomMasterUrl = string.Format(url + "/_catalogs/masterpage/{0}.master", masterPage);
            spWeb.Update();
        }

        private void ResetFeature(Guid featureId, string featureName, SPWeb spWeb)
        {
            LogTitle("Feature: " + featureName, 2);

            SPFeature spFeature = spWeb.Features.FirstOrDefault(f => f.DefinitionId == featureId);

            if (spFeature != null)
            {
                LogTitle("Deactivating . . ", 4);
                spWeb.Features.Remove(spFeature.DefinitionId);
            }

            LogTitle("Activating . . ", 4);
            spWeb.Features.Add(featureId);

            LogMessage(string.Empty, MessageKind.SUCCESS, 3);
        }

        private void UpdateUI(Guid siteId, Guid webId)
        {
            SPWebCollection webCollection;

            using (var spSite = new SPSite(siteId))
            {
                using (SPWeb spWeb = spSite.OpenWeb(webId))
                {
                    LogTitle(GetWebInfo(spWeb), 1);

                    try
                    {
                        string masterUrl = spWeb.MasterUrl;
                        string fileName = Path.GetFileName(masterUrl).ToLower();

                        if (!fileName.Equals("uplandv5.master"))
                        {
                            var masterpages = new[]
                            {
                                "epmlive", "epmlivemasterv5blue", "masterv43lightbluetop",
                                "masterv43lightbluews", "wetoplevel",
                                "weworkspace", "weworkspacetopnav"
                            };

                            bool contains = false;
                            foreach (string masterpage in masterpages.Where(mp => (mp + ".master").Equals(fileName)))
                            {
                                contains = true;
                            }

                            if (contains)
                            {
                                ResetFeature(new Guid("046f0200-30e5-4545-b00f-c8c73aef9f0e"), "EPM Live Upland UI",
                                    spWeb);
                                ChangeMasterPage("UplandV5", spWeb);
                            }
                            else
                            {
                                LogMessage("The current default MasterPage is not one of EPM Live MasterPage.",
                                    MessageKind.SKIPPED, 2);
                            }
                        }
                        else
                        {
                            LogMessage("The default MasterPage is already set to UplandV5.", MessageKind.SKIPPED, 2);
                        }
                    }
                    catch (Exception exception)
                    {
                        LogMessage(exception.Message, MessageKind.FAILURE, 3);
                    }
                    finally
                    {
                        webCollection = spWeb.Webs;
                    }
                }
            }

            if (webCollection == null) return;

            foreach (SPWeb spWeb in webCollection)
            {
                UpdateUI(siteId, spWeb.ID);
            }
        }

        #endregion Methods 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                Guid siteId;
                Guid webId;

                using (var spSite = new SPSite(Web.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        siteId = spSite.ID;
                        webId = spWeb.ID;
                    }
                }

                UpdateUI(siteId, webId);
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }

            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V55, Order = 2.0, Description = "Updating Navigation", IsOptIn = true)]
    internal class UpdateNav55 : UpgradeStep
    {
        #region Constructors (1) 

        public UpdateNav55(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 

        #region Methods (1) 

        // Private Methods (1) 

        private void UpdateLink(string url, SPNavigationNode node)
        {
            try
            {
                LogMessage(string.Format("Node: {0}, URL: {1}", node.Title, url), 3);

                node.Url = url;
                node.Update();

                LogMessage(string.Empty, MessageKind.SUCCESS, 4);
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 3);
            }
        }

        #endregion Methods 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var spSite = new SPSite(Web.Site.ID))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb())
                        {
                            Web.AllowUnsafeUpdates = true;

                            LogTitle(GetWebInfo(spWeb), 1);

                            SPList spList = spWeb.Lists.TryGetList("Installed Applications");
                            if (spList != null)
                            {
                                var qry = new SPQuery
                                {
                                    Query =
                                        @"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>My Workplace</Value></Eq></Where>",
                                    ViewFields = @"<FieldRef Name='ID' />"
                                };

                                SPListItemCollection listItems = spList.GetItems(qry);

                                if (listItems.Count != 0)
                                {
                                    try
                                    {
                                        LogTitle("Changing My Workplace to Global My Workplace", 2);

                                        SPListItem item = spList.GetItemById(listItems[0].ID);

                                        item["Title"] = "Global My Workplace";
                                        item["HomePage"] = new SPFieldUrlValue
                                        {
                                            Url = spWeb.Url + "/SitePages/GlobalMyWorkplace.aspx",
                                            Description = "Global My Workplace"
                                        };

                                        item.SystemUpdate();

                                        LogTitle("Updating links", 2);

                                        string[] nodes = ((item["QuickLaunch"] ?? string.Empty).ToString()).Split(',');

                                        if (nodes.Any())
                                        {
                                            foreach (string nodeId in nodes)
                                            {
                                                try
                                                {
                                                    int id = Convert.ToInt32(nodeId.Split(':')[0]);

                                                    SPNavigationNode node = spWeb.Navigation.GetNodeById(id);
                                                    if (node.Title.Equals("My Work"))
                                                    {
                                                        UpdateLink(spWeb.Url + "/_layouts/15/epmlive/MyWork.aspx", node);
                                                    }
                                                    else if (node.Title.Equals("Timesheet"))
                                                    {
                                                        UpdateLink(spWeb.Url + "/_layouts/15/epmlive/MyTimesheet.aspx", node);
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    LogMessage(e.Message, MessageKind.FAILURE, 3);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            LogMessage("No navigation nodes were found.", MessageKind.FAILURE, 3);
                                        }

                                        CacheStore.Current.RemoveSafely(spWeb.Url, CacheStoreCategory.Navigation);
                                    }
                                    catch (Exception e)
                                    {
                                        LogMessage(e.Message, MessageKind.FAILURE, 3);
                                    }
                                }
                                else
                                {
                                    LogMessage("The My Workplace community was not found.", MessageKind.SKIPPED, 2);
                                }
                            }
                            else
                            {
                                LogMessage("The list Installed Applications does not exists.", MessageKind.FAILURE, 2);
                            }

                            spWeb.AllowUnsafeUpdates = false;
                            spWeb.Update();
                        }
                    }
                });
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }

            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V55, Order = 3.0, Description = "Updating List Icons", IsOptIn = true)]
    internal class UpdateListIcon55 : UpgradeStep
    {
        #region Fields (1) 

        private readonly Dictionary<string, string> _listIcons;

        #endregion Fields 

        #region Constructors (1) 

        public UpdateListIcon55(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
            _listIcons = new Dictionary<string, string>
            {
                {"Project Portfolios", "icon-notebook"},
                {"Project Center", "icon-briefcase-3"},
                {"Task Center", "icon-checkbox-checked"},
                {"Issues", "icon-warning"},
                {"Project Documents", "icon-libreoffice"},
                {"Resources", "icon-user-3"},
                {"Time Off", "icon-calendar-4"},
                {"To Do", "icon-list-5"}
            };
        }

        #endregion Constructors 

        #region Methods (1) 

        // Private Methods (1) 

        private void UpdateListIcon(Guid siteId, Guid webId)
        {
            SPWebCollection webCollection;

            using (var spSite = new SPSite(siteId))
            {
                using (SPWeb spWeb = spSite.OpenWeb(webId))
                {
                    LogTitle(GetWebInfo(spWeb), 1);

                    foreach (var listIcon in _listIcons)
                    {
                        try
                        {
                            SPList spList = spWeb.Lists.TryGetList(listIcon.Key);

                            if (spList != null)
                            {
                                LogTitle(GetListInfo(spList), 2);

                                LogTitle("Icon: " + listIcon.Value, 3);

                                var settings = new GridGanttSettings(spList);
                                if (string.IsNullOrEmpty(settings.ListIcon) || settings.ListIcon.Equals("icon-square"))
                                {
                                    settings.ListIcon = listIcon.Value;
                                    if (settings.SaveSettings(spList))
                                    {
                                        LogMessage(string.Empty, MessageKind.SUCCESS, 4);
                                    }
                                    else
                                    {
                                        LogMessage("Could not save the icon.", MessageKind.FAILURE, 4);
                                    }
                                }
                                else
                                {
                                    LogMessage("The icon is already set to: " + settings.ListIcon, MessageKind.SKIPPED,
                                        4);
                                }
                            }
                            else
                            {
                                LogMessage("The list " + listIcon.Key + " does not exists.", MessageKind.SKIPPED, 3);
                            }
                        }
                        catch (Exception e)
                        {
                            LogMessage(e.Message, MessageKind.FAILURE, 2);
                        }
                    }

                    webCollection = spWeb.Webs;
                }
            }

            if (webCollection == null) return;

            foreach (SPWeb spWeb in webCollection)
            {
                UpdateListIcon(siteId, spWeb.ID);
            }
        }

        #endregion Methods 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                Guid siteId;
                Guid webId;

                using (var spSite = new SPSite(Web.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        siteId = spSite.ID;
                        webId = spWeb.ID;
                    }
                }

                UpdateListIcon(siteId, webId);
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }

            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V55, Order = 4.0, Description = "Using Content DB", IsOptIn = true)]
    internal class UseContentDB55 : UpgradeStep
    {
        #region Constructors (1) 

        public UseContentDB55(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                using (var spSite = new SPSite(Web.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        LogTitle(GetWebInfo(spWeb), 1);

                        var queryExecutor = new QueryExecutor(spWeb);
                        foreach (SPList spList in queryExecutor.GetMappedListIds()
                            .Select(listId => spWeb.Lists.GetList(listId, true)))
                        {
                            LogTitle(GetListInfo(spList), 2);

                            var settings = new GridGanttSettings(spList);

                            string reason = string.Empty;

                            switch ((int) spList.BaseTemplate)
                            {
                                case (int) EPMLiveLists.ProjectCenter:
                                    reason = "List Definition: Project Center.";
                                    break;
                                case (int) EPMLiveLists.TaskCenter:
                                    reason = "List Definition: Task Center.";
                                    break;
                                default:
                                    if (settings.EnableWorkList) reason = "Work List.";
                                    break;
                            }

                            if (!string.IsNullOrEmpty(reason))
                            {
                                settings.EnableContentReporting = true;
                                settings.SaveSettings(spList);

                                LogMessage(reason, MessageKind.SUCCESS, 3);
                            }
                            else
                            {
                                LogMessage("List is not a Project Center, Task Center or a Work list.",
                                    MessageKind.SKIPPED, 3);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }
            finally
            {
                CacheStore.Current.RemoveSafely(Web.Url, CacheStoreCategory.Navigation);
            }

            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V55, Order = 5.0, Description = "Turning on Create Workspace functionality",
        IsOptIn = true)]
    internal class TurnOnCreateWorkspace55 : UpgradeStep
    {
        #region Constructors (1) 

        public TurnOnCreateWorkspace55(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                using (var spSite = new SPSite(Web.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        LogTitle(GetWebInfo(spWeb), 1);

                        SPList spList = spWeb.Lists.TryGetList("Project Center");

                        if (spList != null)
                        {
                            LogTitle(GetListInfo(spList), 2);

                            var settings = new GridGanttSettings(spList) {EnableRequests = true};
                            settings.SaveSettings(spList);

                            LogMessage(string.Empty, MessageKind.SUCCESS, 3);
                        }
                        else
                        {
                            LogMessage("Cannot find the Project Center list.", MessageKind.FAILURE, 2);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }

            return true;
        }

        #endregion
    }

    [UpgradeStep(Version = EPMLiveVersion.V55, Order = 6.0, Description = "Configuring Advance Reporting",
        IsOptIn = true)]
    internal class ConfigureAdvanceReporting55 : UpgradeStep
    {
        #region Fields (2) 

        private const string LIST_NAME = "IzendaReports";
        private readonly string _storeUrl;

        #endregion Fields 

        #region Constructors (1) 

        public ConfigureAdvanceReporting55(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;

            _storeUrl = "https://store.workengine.com";
        }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var spSite = new SPSite(Web.Site.ID))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb())
                        {
                            spWeb.AllowUnsafeUpdates = true;

                            LogTitle(GetWebInfo(spWeb), 1);

                            SPList spList = spWeb.Lists.TryGetList(LIST_NAME);

                            if (spList == null)
                            {
                                LogMessage("Downloading new " + LIST_NAME + " list", 2);

                                var catalog =
                                    (SPDocumentLibrary) Web.Site.GetCatalog(SPListTemplateType.ListTemplateCatalog);

                                const string TEMPLATE_NAME = LIST_NAME + " [5.5]";

                                using (var webClient = new WebClient())
                                {
                                    byte[] bytes =
                                        webClient.DownloadData(_storeUrl + "/Upgrade/" + LIST_NAME.ToLower() + ".stp");
                                    SPFile file = catalog.RootFolder.Files.Add(LIST_NAME + "_55.stp", bytes, true);
                                    SPListItem li = file.GetListItem();
                                    li["Title"] = TEMPLATE_NAME;
                                    li.SystemUpdate();
                                }

                                LogMessage("Creating the " + LIST_NAME + " list", 2);

                                SPListTemplateCollection listTemplates = spSite.GetCustomListTemplates(spWeb);
                                SPListTemplate template = listTemplates[TEMPLATE_NAME];

                                spWeb.Lists.Add(LIST_NAME, string.Empty, template);

                                SPList list = spWeb.Lists[LIST_NAME];
                                list.Title = LIST_NAME;
                                list.Hidden = true;
                                list.AllowDeletion = false;
                                list.Update();

                                LogMessage("Processing reports", 2);

                                string error;
                                Reporting.ProcessIzendaReportsFromList(list, out error);

                                if (!string.IsNullOrEmpty(error))
                                {
                                    LogMessage(error, MessageKind.FAILURE, 3);
                                }

                                LogMessage("Updating Navigation link", 2);

                                string newUrl = spWeb.Url + "/_layouts/15/epmlive/reporting/landing.aspx";

                                SPList lst = spWeb.Lists.TryGetList("Installed Applications");
                                if (lst != null)
                                {
                                    var qry = new SPQuery
                                    {
                                        Query = @"<Where><IsNotNull><FieldRef Name='QuickLaunch' /></IsNotNull></Where>",
                                        ViewFields = @"<FieldRef Name='QuickLaunch' />"
                                    };

                                    SPListItemCollection listItems = lst.GetItems(qry);

                                    foreach (SPNavigationNode navNode in from SPListItem item in listItems
                                        from node in item["QuickLaunch"].ToString().Split(',')
                                        select Convert.ToInt32(node.Split(':')[0])
                                        into nodeId
                                        select spWeb.Navigation.GetNodeById(nodeId)
                                        into navNode
                                        let url = navNode.Url.ToLower()
                                        where url.EndsWith(spWeb.ServerRelativeUrl + "/reports.aspx") ||
                                              url.EndsWith(spWeb.ServerRelativeUrl + "/sitepages/report.aspx")
                                        select navNode)
                                    {
                                        LogMessage("Node: " + navNode.Title, 3);
                                        LogMessage("Old URL: " + navNode.Url, 3);
                                        LogMessage("New URL: " + newUrl, 3);

                                        navNode.Url = newUrl;
                                        navNode.Update();

                                        LogMessage(null, MessageKind.SUCCESS, 4);
                                    }
                                }
                                else
                                {
                                    LogMessage("The list Installed Applications does not exists.", MessageKind.FAILURE,
                                        3);
                                }

                                LogMessage(null, MessageKind.SUCCESS, 3);
                            }
                            else
                            {
                                LogMessage("Advance reporting is already configured.", MessageKind.SKIPPED, 2);
                            }

                            spWeb.AllowUnsafeUpdates = false;
                            spWeb.Update();
                        }
                    }
                });
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }

            return true;
        }

        #endregion
    }
}