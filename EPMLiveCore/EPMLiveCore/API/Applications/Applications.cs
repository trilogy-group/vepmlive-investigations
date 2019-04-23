using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace EPMLiveCore.API
{
    internal class ApplicationDef
    {
        public string Title;
        public int Id;
        public SortedList PreReqs;
        public XmlDocument ApplicationXml;
        public string fullurl;
        public string appurl;
        public bool bIsConfigOnly = false;
        public string Icon;
        public string Version;
        public bool Visible = true;
        public string[] ParentApplications;
        public string Community = "";
        public string loadErrorMessage = "";
        public string AppAssemblyVersion = "";

        public ApplicationDef()
        {
            ParentApplications = new string[] { };
            ApplicationXml = new XmlDocument();
            PreReqs = new SortedList();
        }
    }

    internal class Applications
    {
        private const string INSTALLED_APP_LIST_NAME = "Installed Applications";
        private const string AddOperation = "ADD";
        private const string LinkedCommunityFieldName = "LinkedCommunity";
        private const string LinkedAppsFieldName = "LinkedApps";
        private const string InstallXmlFieldName = "InstallXML";
        private const string TopNavXmlFieldName = "TopNavXML";
        private const string QuickLaunchXmlFieldName = "QuickLaunchXML";
        private const string InstalledFilesFieldName = "InstalledFiles";
        private const string ConfiguredFieldName = "Configured";
        private const string InstallMessagesFieldName = "InstallMessages";
        private const string InstallPercentFieldName = "InstallPercent";
        private const string StatusFieldName = "Status";
        private const string AppUrlFieldName = "AppUrl";
        private const string AppVersionFieldName = "AppVersion";
        private const string IconFieldName = "Icon";
        private const string HomePageFieldName = "HomePage";
        private const string DefaultFieldName = "Default";
        private const string VisibleFieldName = "Visible";
        private const string TopNavFieldName = "TopNav";
        private const string QuickLaunchFieldName = "QuickLaunch";
        private const string ExtIdFieldName = "EXTID";
        private const string DescriptionFieldName = "Description";
        private const string TitleFieldName = "Title";
        private const string PreCheckQueuedStatus = "PreCheck Queued";
        private const string PreCheckStartedStatus = "PreCheck Started";
        private const string PreCheckFailedStatus = "PreCheck Failed";
        private const string PreCheckSuccessfulStatus = "PreCheck Successful";
        private const string NotInstalledStatus = "Not Installed";
        private const string InstallQueuedStatus = "Install Queued";
        private const string InstallStartedStatus = "Install Started";
        private const string InstallingStatus = "Installing";
        private const string InstalledStatus = "Installed";
        private const string InstallFailedStatus = "Install Failed";

        public static string getAttribute(XmlNode nd, string attribute)
        {
            try
            {
                return nd.Attributes[attribute].Value;
            }
            catch { return ""; }

        }

        public static SPList GetApplicationList(SPWeb web)
        {
            web.AllowUnsafeUpdates = true;
            SPList oList = web.Lists.TryGetList("AppDocuments");
            if (oList == null)
            {
                Guid gList = web.Lists.Add("AppDocuments", "", SPListTemplateType.DocumentLibrary);
                oList = web.Lists[gList];
                oList.Hidden = true;
                oList.Update();

                oList = null;
            }

            oList = web.Lists.TryGetList("Installed Applications");
            if (oList == null)
            {
                web.Features.Add(new Guid("21c3b2a2-f0c6-4abf-8671-a07c9f50d00d"), true);

                Guid gList = web.Lists.Add("Installed Applications", "", "Lists/Installed Applications", "21c3b2a2-f0c6-4abf-8671-a07c9f50d00d", 23413, "");
                oList = web.Lists[gList];
                oList.Hidden = true;
            }
            return CheckApplicationList(oList);

        }

        private static SPField GetField(SPList oList, string field)
        {
            try
            {
                return oList.Fields.GetFieldByInternalName(field);
            }
            catch { }
            return null;
        }

        private static SPList CheckApplicationList(SPList list)
        {
            if (list != null)
            {
                AddDescriptionField(list);
                UpdateExtIdField(list);
                UpdateQuickLaunchField(list);
                UpdateTopNavField(list);
                UpdateVisibleField(list);
                UpdateDefaultField(list);
                UpdateHomePageField(list);
                UpdateAppVersionField(list);
                UpdateAppUrlField(list);
                UpdateStatusField(list);
                UpdateInstallPercentField(list);
                UpdateInstallMessagesField(list);
                UpdateConfiguredField(list);
                UpdateInstalledFilesField(list);
                UpdateQuickLaunchXmlField(list);
                UpdateTopNavXmlField(list);
                UpdateInstallXmlField(list);
                UpdateLinkedAppsField(list);
                UpdateLinkedCommunityField(list);

                var dataElement = new XElement("Data");
                var assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                var className = "EPMLiveCore.AppsListEvents";
                var spEventReceiverTypes = new[]
                {
                    SPEventReceiverType.ItemDeleting
                };

                AddEventReceiverElement(
                    AddOperation,
                    className,
                    assemblyName,
                    spEventReceiverTypes,
                    list.ID,
                    ref dataElement,
                    list.ParentWeb);

                WorkEngineAPI.EventReceiverManager(new XElement("EventReceiverManager", dataElement).ToString(), list.ParentWeb);
            }

            return list;
        }

        private static void AddDescriptionField(SPList list)
        {
            var field = GetField(list, DescriptionFieldName);
            if (field == null)
            {
                list.Fields.Add(DescriptionFieldName, SPFieldType.Note, false);
            }
        }

        private static void UpdateExtIdField(SPList list)
        {
            var field = GetField(list, ExtIdFieldName);
            if (field == null)
            {
                list.Fields.Add(ExtIdFieldName, SPFieldType.Number, false);
                field = GetField(list, ExtIdFieldName);
                field.ShowInEditForm = false;
                field.ShowInNewForm = false;
                field.Update();
            }
        }

        private static void UpdateQuickLaunchField(SPList list)
        {
            var field = GetField(list, QuickLaunchFieldName);
            if (field == null)
            {
                list.Fields.Add(QuickLaunchFieldName, SPFieldType.Text, false);
                field = GetField(list, QuickLaunchFieldName);
                field.ShowInEditForm = false;
                field.ShowInNewForm = false;
                field.Update();
            }
        }

        private static void UpdateTopNavField(SPList list)
        {
            var field = GetField(list, TopNavFieldName);
            if (field == null)
            {
                list.Fields.Add(TopNavFieldName, SPFieldType.Text, false);
                field = GetField(list, TopNavFieldName);
                field.ShowInEditForm = false;
                field.ShowInNewForm = false;
                field.Update();
            }
        }

        private static void UpdateVisibleField(SPList list)
        {
            var field = GetField(list, VisibleFieldName);
            if (field == null)
            {
                list.Fields.Add(VisibleFieldName, SPFieldType.Boolean, false);
                var boolField = (SPFieldBoolean)GetField(list, VisibleFieldName);
                boolField.DefaultValue = "0";
                boolField.Update();
            }
        }

        private static void UpdateDefaultField(SPList list)
        {
            var field = GetField(list, DefaultFieldName);
            if (field == null)
            {
                list.Fields.Add(DefaultFieldName, SPFieldType.Boolean, false);
                var boolField = (SPFieldBoolean)GetField(list, DefaultFieldName);
                boolField.DefaultValue = "0";
                boolField.ShowInEditForm = false;
                boolField.ShowInNewForm = false;
                boolField.Update();
            }
        }

        private static void UpdateHomePageField(SPList list)
        {
            var field = GetField(list, HomePageFieldName);
            if (field == null)
            {
                list.Fields.Add(HomePageFieldName, SPFieldType.URL, false);
            }

            field = GetField(list, IconFieldName);
            if (field == null)
            {
                list.Fields.Add(IconFieldName, SPFieldType.URL, false);
            }
        }

        private static void UpdateAppVersionField(SPList list)
        {
            var field = GetField(list, AppVersionFieldName);
            if (field == null)
            {
                list.Fields.Add(AppVersionFieldName, SPFieldType.Text, false);
                field = GetField(list, AppVersionFieldName);
                field.ShowInEditForm = false;
                field.ShowInNewForm = false;
                field.Update();
            }
        }

        private static void UpdateAppUrlField(SPList list)
        {
            var field = GetField(list, AppUrlFieldName);
            if (field == null)
            {
                list.Fields.Add(AppUrlFieldName, SPFieldType.Text, false);
                field = GetField(list, AppUrlFieldName);
                field.ShowInEditForm = false;
                field.ShowInNewForm = false;
                field.Update();
            }
        }

        private static void UpdateStatusField(SPList list)
        {
            var field = GetField(list, StatusFieldName);
            if (field == null)
            {
                list.Fields.Add(StatusFieldName, SPFieldType.Text, false);
                field = GetField(list, StatusFieldName);
                field.ShowInEditForm = false;
                field.ShowInNewForm = false;
                field.Update();
            }
        }

        private static void UpdateInstallPercentField(SPList list)
        {
            var field = GetField(list, InstallPercentFieldName);
            if (field == null)
            {
                list.Fields.Add(InstallPercentFieldName, SPFieldType.Number, false);
                var numericField = (SPFieldNumber)GetField(list, InstallPercentFieldName);
                numericField.ShowAsPercentage = true;
                numericField.ShowInEditForm = false;
                numericField.ShowInNewForm = false;
                numericField.Update();
            }
        }

        private static void UpdateInstallMessagesField(SPList list)
        {
            var field = GetField(list, InstallMessagesFieldName);
            if (field == null)
            {
                list.Fields.Add(InstallMessagesFieldName, SPFieldType.Note, false);
                var numericField = (SPFieldMultiLineText)GetField(list, InstallMessagesFieldName);
                numericField.RichTextMode = SPRichTextMode.FullHtml;
                numericField.RichText = true;
                numericField.ShowInEditForm = false;
                numericField.ShowInNewForm = false;
                numericField.Update();
            }
        }

        private static void UpdateConfiguredField(SPList list)
        {
            var field = GetField(list, ConfiguredFieldName);
            if (field == null)
            {
                list.Fields.Add(ConfiguredFieldName, SPFieldType.Boolean, false);
                field = GetField(list, ConfiguredFieldName);
                field.ShowInEditForm = false;
                field.ShowInNewForm = false;
                field.Update();
            }
        }

        private static void UpdateInstalledFilesField(SPList list)
        {
            var field = GetField(list, InstalledFilesFieldName);
            if (field == null)
            {
                list.Fields.Add(InstalledFilesFieldName, SPFieldType.Note, false);
                field = GetField(list, InstalledFilesFieldName);
                field.Hidden = true;
                field.Update();
            }
        }

        private static void UpdateQuickLaunchXmlField(SPList list)
        {
            var field = GetField(list, QuickLaunchXmlFieldName);
            if (field == null)
            {
                list.Fields.Add(QuickLaunchXmlFieldName, SPFieldType.Note, false);
                field = GetField(list, QuickLaunchXmlFieldName);
                field.Hidden = true;
                field.Update();
            }
        }

        private static void UpdateTopNavXmlField(SPList list)
        {
            var field = GetField(list, TopNavXmlFieldName);
            if (field == null)
            {
                list.Fields.Add(TopNavXmlFieldName, SPFieldType.Note, false);
                field = GetField(list, TopNavXmlFieldName);
                field.Hidden = true;
                field.Update();
            }
        }

        private static void UpdateInstallXmlField(SPList list)
        {
            var field = GetField(list, InstallXmlFieldName);
            if (field == null)
            {
                list.Fields.Add(InstallXmlFieldName, SPFieldType.Note, false);
                field = GetField(list, InstallXmlFieldName);
                field.Hidden = true;
                field.Update();
            }
        }

        private static void UpdateLinkedAppsField(SPList list)
        {
            var field = GetField(list, LinkedAppsFieldName);
            if (field == null)
            {
                list.Fields.Add(LinkedAppsFieldName, SPFieldType.Note, false);
                field = GetField(list, LinkedAppsFieldName);
                field.Hidden = true;
                field.Update();
            }
        }

        private static void UpdateLinkedCommunityField(SPList list)
        {
            var field = GetField(list, LinkedCommunityFieldName);
            if (field == null)
            {
                list.Fields.Add(LinkedCommunityFieldName, SPFieldType.Number, false);
                field = GetField(list, LinkedCommunityFieldName);
                field.Hidden = true;
                field.Update();
            }
        }

        private static void AddEventReceiverElement(string operation, string className, string assembly, IEnumerable<SPEventReceiverType> spEventReceiverTypes, Guid listId, ref XElement dataElement, SPWeb web)
        {
            foreach (SPEventReceiverType spEventReceiverType in spEventReceiverTypes)
            {
                dataElement.Add(new XElement("EventReceiver", new XAttribute("SiteId", web.Site.ID),
                                             new XAttribute("WebId", web.ID), new XAttribute("ListId", listId),
                                             new XAttribute("Type", (int)spEventReceiverType),
                                             new XAttribute("Operation", operation),
                                             new XAttribute("Assembly", assembly),
                                             new XAttribute("ClassName", className),
                                             new XAttribute("DataId", listId)));
            }
        }

        private static void AddAppNav(SPListItem oLiCommunity, int appextid, XmlNode ndNav, SPNavigationNodeCollection nodeCollection, SPField NavField)
        {
            ArrayList arrNavs = new ArrayList();
            try
            {
                arrNavs = new ArrayList(oLiCommunity[NavField.Id].ToString().Split(','));
            }
            catch { }

            bool foundapp = false;

            foreach (string sNav in arrNavs)
            {
                string[] sNavInfo = sNav.Split(':');
                if (sNavInfo.Length > 1 && sNavInfo[1] == appextid.ToString())
                {
                    foundapp = true;
                }
            }

            if (!foundapp)
            {
                ArrayList arrNewNavs = new ArrayList();
                try
                {
                    arrNewNavs = new ArrayList(oLiCommunity[NavField.Id].ToString().Split(','));
                }
                catch { }

                AddAppNavSub(oLiCommunity, appextid, ndNav, nodeCollection, NavField, ref arrNewNavs);

                oLiCommunity[NavField.Id] = string.Join(",", (string[])arrNewNavs.ToArray(typeof(string)));
                oLiCommunity.Update();
            }
        }

        private static void AddAppNavSub(SPListItem oLiCommunity, int appextid, XmlNode ndNav, SPNavigationNodeCollection nodeCollection, SPField NavField, ref ArrayList arrNewNavs)
        {
            foreach (XmlNode nd in ndNav.SelectNodes("Item"))
            {
                try
                {
                    string sParentName = getAttribute(nd, "Name");
                    string sParentUrl = GetCleanUrl(oLiCommunity.ParentList.ParentWeb, getAttribute(nd, "Url"));

                    bool bParentExternal = false;
                    bool.TryParse(getAttribute(nd, "External"), out bParentExternal);

                    SPNavigationNode oNewNav = new SPNavigationNode(sParentName, sParentUrl, bParentExternal);
                    nodeCollection.AddAsLast(oNewNav);

                    arrNewNavs.Add(oNewNav.Id + ":" + appextid.ToString());

                    AddAppNavSub(oLiCommunity, appextid, nd, oNewNav.Children, NavField, ref arrNewNavs);
                }
                catch { }
            }
        }

        private static string GetCleanUrl(SPWeb oWeb, string url)
        {
            url = url.Replace("{SiteUrl}", (oWeb.ServerRelativeUrl == "/") ? "" : oWeb.ServerRelativeUrl);

            return url;
        }

        public static void AddAppToCommunity(SPListItem oLiCommunity, int appextid)
        {
            CheckApplicationList(oLiCommunity.ParentList);
            oLiCommunity.ParentList.ParentWeb.AllowUnsafeUpdates = true;
            try
            {
                ApplicationDef appDef = GetApplicationInfoFromList(oLiCommunity.ParentList.ParentWeb, appextid.ToString());

                SPField fQuickLaunch = oLiCommunity.ParentList.Fields.GetFieldByInternalName(QuickLaunchFieldName);

                XmlNode nd = appDef.ApplicationXml.FirstChild.SelectSingleNode("//Application/QuickLaunch");
                if (nd != null)
                {
                    AddAppNav(oLiCommunity, appextid, nd, oLiCommunity.ParentList.ParentWeb.Navigation.QuickLaunch, fQuickLaunch);

                    CreateQuickLaunchXML(oLiCommunity.ID, oLiCommunity.ParentList.ParentWeb);
                }

                SPField fTopNav = oLiCommunity.ParentList.Fields.GetFieldByInternalName("TopNav");

                nd = appDef.ApplicationXml.FirstChild.SelectSingleNode("//Application/TopNav");
                if (nd != null)
                {
                    AddAppNav(oLiCommunity, appextid, nd, oLiCommunity.ParentList.ParentWeb.Navigation.TopNavigationBar, fTopNav);

                    CreateTopNavXML(oLiCommunity.ID, oLiCommunity.ParentList.ParentWeb);
                }
            }
            catch { }
        }

        public static void RemoveAppFromCommunity(SPListItem oLiCommunity, int appextid)
        {
            oLiCommunity.ParentList.ParentWeb.AllowUnsafeUpdates = true;

            CheckApplicationList(oLiCommunity.ParentList);

            try
            {
                SPField fQuickLaunch = oLiCommunity.ParentList.Fields.GetFieldByInternalName(QuickLaunchFieldName);
                RemoveAppNav(oLiCommunity, appextid, oLiCommunity.ParentList.ParentWeb, fQuickLaunch);
                CreateQuickLaunchXML(oLiCommunity.ID, oLiCommunity.ParentList.ParentWeb);

                SPField fTopNav = oLiCommunity.ParentList.Fields.GetFieldByInternalName("TopNav");
                RemoveAppNav(oLiCommunity, appextid, oLiCommunity.ParentList.ParentWeb, fTopNav);
                CreateTopNavXML(oLiCommunity.ID, oLiCommunity.ParentList.ParentWeb);
            }
            catch { }
        }

        private static void RemoveAppNav(SPListItem oLiCommunity, int appid, SPWeb web, SPField NavField)
        {

            ArrayList arrNavs = new ArrayList();
            ArrayList arrNewNavs = new ArrayList();
            ArrayList arrDelNavs = new ArrayList();
            try
            {
                arrNavs = new ArrayList(oLiCommunity[NavField.Id].ToString().Split(','));

                foreach (string sNav in arrNavs)
                {
                    string[] sNavInfo = sNav.Split(':');
                    if (sNavInfo.Length > 1)
                    {
                        if (sNavInfo[1] == appid.ToString())
                        {
                            arrDelNavs.Add(sNavInfo[0]);
                        }
                        else
                        {
                            arrNewNavs.Add(sNav);
                        }
                    }
                    else
                    {
                        arrNewNavs.Add(sNav);
                    }
                }

                foreach (string sDelNav in arrDelNavs)
                {
                    try
                    {
                        SPNavigationNode node = web.Navigation.GetNodeById(int.Parse(sDelNav));
                        node.Delete();
                    }
                    catch { }
                }

                oLiCommunity[NavField.Id] = string.Join(",", (string[])arrNewNavs.ToArray(typeof(string)));
                oLiCommunity.Update();
            }
            catch { }

        }

        public static void RemoveCommunityNav(SPListItem oLiCommunity, SPWeb web, SPField NavField)
        {

            ArrayList arrNavs = new ArrayList();
            ArrayList arrNewNavs = new ArrayList();
            ArrayList arrDelNavs = new ArrayList();
            try
            {
                arrNavs = new ArrayList(oLiCommunity[NavField.Id].ToString().Split(','));

                foreach (string sNav in arrNavs)
                {
                    string[] sNavInfo = sNav.Split(':');
                    try
                    {
                        SPNavigationNode node = web.Navigation.GetNodeById(int.Parse(sNavInfo[0]));
                        node.Delete();
                    }
                    catch { }
                }
            }
            catch { }

        }

        //public static void UpdateCommunityNav(SPListItem oLiCommunity)
        //{

        //    SPField fQuickLaunch = oLiCommunity.ParentList.Fields.GetFieldByInternalName("QuickLaunch");
        //    SPField fTopNav = oLiCommunity.ParentList.Fields.GetFieldByInternalName("TopNav");
        //    SPField fLinkedApps = oLiCommunity.ParentList.Fields.GetFieldByInternalName("LinkedApps");

        //    ProcessCommunityNav(oLiCommunity, oLiCommunity.ParentList.ParentWeb.Navigation.QuickLaunch, fQuickLaunch, fLinkedApps);
        //    ProcessCommunityNav(oLiCommunity, oLiCommunity.ParentList.ParentWeb.Navigation.TopNavigationBar, fTopNav, fLinkedApps);

        //    CreateQuickLaunchXML(oLiCommunity.ID, oLiCommunity.ParentList.ParentWeb);
        //    CreateTopNavXML(oLiCommunity.ID, oLiCommunity.ParentList.ParentWeb);
        //}

        //private static void ProcessCommunityNav(SPListItem oLiCommunity, SPNavigationNodeCollection nodCollection, SPField oNavField, SPField fLinkedApps)
        //{
        //    oLiCommunity.ParentList.ParentWeb.AllowUnsafeUpdates = true;
        //    ArrayList curApps = new ArrayList();
        //    try
        //    {
        //        curApps = new ArrayList(oLiCommunity[fLinkedApps.Id].ToString().Split(','));
        //    }
        //    catch { }
        //    ArrayList oCurAppNavs;
        //    ArrayList oAllAppNavs;

        //    GetAppNavs(oLiCommunity.ParentList, curApps, oNavField, out oCurAppNavs, out oAllAppNavs);


        //    ArrayList curCommunityNav = new ArrayList();

        //    try
        //    {
        //        curCommunityNav = new ArrayList(oLiCommunity[oNavField.Id].ToString().Split(','));
        //    }
        //    catch { }

        //    foreach(string sNav in oCurAppNavs)
        //    {
        //        if(!curCommunityNav.Contains(sNav))
        //            curCommunityNav.Add(sNav);
        //    }

        //    ArrayList arrDels = new ArrayList();

        //    foreach(string sNav in curCommunityNav)
        //    {
        //        if(oAllAppNavs.Contains(sNav) && !oCurAppNavs.Contains(sNav) && curCommunityNav.Contains(sNav))
        //        {
        //            arrDels.Add(sNav);
        //        }
        //    }

        //    foreach(string sNav in arrDels)
        //    {
        //        curCommunityNav.Remove(sNav);
        //    }

        //    oLiCommunity[oNavField.Id] = string.Join(",", (string[])curCommunityNav.ToArray(typeof(string)));

        //    oLiCommunity.Update();
        //}

        //private static void GetAppNavs(SPList oList, ArrayList curApps, SPField oField, out ArrayList oCurNavs, out ArrayList oAllNavs)
        //{
        //    oCurNavs = new ArrayList();
        //    oAllNavs = new ArrayList();

        //    SPQuery query = new SPQuery();
        //    query.Query = "<Where><IsNotNull><FieldRef Name='EXTID'/></IsNotNull></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

        //    foreach(SPListItem li in oList.GetItems(query))
        //    {
        //        try
        //        {
        //            ArrayList oNavs = new ArrayList(li[oField.Id].ToString().Split(','));

        //            foreach(string s in oNavs)
        //            {
        //                try
        //                {
        //                    oAllNavs.Add(s);
        //                    if(curApps.Contains(li["EXTID"].ToString()))
        //                        oCurNavs.Add(s);
        //                }
        //                catch { }
        //            }
        //        }
        //        catch { }
        //    }
        //}

        public static void CreateQuickLaunchXML(int AppId, SPWeb cWeb)
        {
            CreateGenericXml(AppId, cWeb, QuickLaunchFieldName, cWeb.Navigation.QuickLaunch);
        }

        private static void CreateGenericXml(int AppId, SPWeb cWeb, string field, SPNavigationNodeCollection nodeCollection)
        {
            StringBuilder xml = new StringBuilder();
            cWeb.Site.CatchAccessDeniedException = false;
            cWeb.AllowUnsafeUpdates = true;
            SPList appsList = cWeb.Lists.TryGetList(INSTALLED_APP_LIST_NAME);
            if (appsList != null)
            {
                xml.Append("<" + field + ">");
                SPListItem currentApp = appsList.GetItemById(AppId);
                string sQlIds = (string)(currentApp[field] ?? string.Empty);
                if (!string.IsNullOrEmpty(sQlIds))
                {
                    string[] ids = sQlIds.Split(',');
                    Hashtable hshNavs = new Hashtable();
                    foreach (string s in ids)
                    {

                        string[] sIdInfo = s.Split(':');
                        string appid = "";
                        try
                        {
                            appid = sIdInfo[1];
                        }
                        catch { }
                        hshNavs.Add(sIdInfo[0], appid);
                    }

                    // go by the order of the web node collection, 
                    // rather than by the ids in "QuickLaunch" or "TopNav" column
                    foreach (SPNavigationNode n in nodeCollection.Parent.Children)
                    {
                        if (hshNavs.ContainsKey(n.Id.ToString()))
                        {
                            CreateChildXML(n, xml, cWeb, hshNavs);
                        }
                    }

                    //foreach(DictionaryEntry de in hshNavs)
                    //{
                    //    SPNavigationNode n = null;
                    //    try
                    //    {
                    //        n = cWeb.Navigation.GetNodeById(int.Parse(de.Key.ToString()));
                    //    }
                    //    catch { }

                    //    if(n != null && n.Parent.Id.Equals(nodeCollection.Parent.Id))
                    //    {
                    //        CreateChildXML(n, xml, cWeb, hshNavs);
                    //    }
                    //}
                }
                xml.Append("</" + field + ">");

                try
                {
                    currentApp[field + "XML"] = xml.ToString();
                    currentApp.Update();
                }
                catch { }
            }
        }


        private static void CreateChildXML(SPNavigationNode n, StringBuilder xml, SPWeb web, Hashtable hshNavs)
        {
            string url = web.ServerRelativeUrl;
            if (url == "/")
                url = n.Url;
            else
                url = n.Url.Replace(web.ServerRelativeUrl, "{SiteUrl}");

            if (hshNavs.ContainsKey(n.Id.ToString()) && hshNavs[n.Id.ToString()] != "")
                xml.Append("<Nav name=\"" + n.Title + "\" url=\"" + url + "\" isExternal=\"" + n.IsExternal + "\" AppId=\"" + hshNavs[n.Id.ToString()] + "\">");
            else
                xml.Append("<Nav name=\"" + n.Title + "\" url=\"" + url + "\" isExternal=\"" + n.IsExternal + "\" >");

            if (n.Children.Count > 0)
            {
                foreach (SPNavigationNode child in n.Children)
                {
                    CreateChildXML(child, xml, web, hshNavs);
                }
            }
            xml.Append("</Nav>");
        }

        public static void GenerateQuickLaunchFromApp(SPWeb web)
        {
            SPList list = web.Lists.TryGetList("Installed Applications");

            if (list != null)
            {
                SPListItemCollection lic = list.Items;

                Hashtable hshQuickLaunch = new Hashtable();
                Hashtable hshTopNav = new Hashtable();

                if (lic.Count > 0)
                {
                    foreach (SPListItem li in lic)
                    {
                        try
                        {
                            string xml = li["QuickLaunchXML"].ToString();
                            if (xml != "")
                            {
                                xml = xml.Replace("&", "&amp;");
                                hshQuickLaunch.Add(li.ID, xml);
                            }

                        }
                        catch { }

                        try
                        {
                            string xml = li["TopNavXML"].ToString();
                            if (xml != "")
                            {
                                xml = xml.Replace("&", "&amp;");
                                hshTopNav.Add(li.ID, xml);
                            }

                        }
                        catch { }
                    }

                    if (hshQuickLaunch.Count > 0)
                    {
                        foreach (DictionaryEntry de in hshQuickLaunch)
                        {
                            SPListItem li = list.GetItemById(int.Parse(Convert.ToString(de.Key)));
                            List<String> ids = new List<String>();
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(Convert.ToString(de.Value));

                            XmlNodeList xnList = xmlDoc.SelectNodes("/QuickLaunch/Nav");

                            foreach (XmlNode xn in xnList)
                            {
                                foreach (SPNavigationNode nd in web.Navigation.QuickLaunch)
                                {
                                    if (nd.Title == xn.Attributes["name"].Value && Path.GetFileName(nd.Url) == Path.GetFileName(xn.Attributes["url"].Value))
                                    {
                                        string appid = getAttribute(xn, "AppId");
                                        ids.Add(nd.Id + ((appid != "") ? ":" + appid : ""));
                                        break;
                                    }
                                }
                            }

                            li[QuickLaunchFieldName] = String.Join(",", ids.ToArray());
                            li.Update();
                        }
                    }

                    if (hshTopNav.Count > 0)
                    {
                        foreach (DictionaryEntry de in hshTopNav)
                        {
                            SPListItem li = list.GetItemById(int.Parse(Convert.ToString(de.Key)));
                            List<String> ids = new List<String>();
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(Convert.ToString(de.Value));

                            XmlNodeList xnList = xmlDoc.SelectNodes("/TopNav/Nav");

                            foreach (XmlNode xn in xnList)
                            {
                                foreach (SPNavigationNode nd in web.Navigation.QuickLaunch)
                                {
                                    if (nd.Title == xn.Attributes["name"].Value && Path.GetFileName(nd.Url) == Path.GetFileName(xn.Attributes["url"].Value))
                                    {
                                        string appid = getAttribute(xn, "AppId");
                                        ids.Add(nd.Id + ((appid != "") ? ":" + appid : ""));
                                        break;
                                    }
                                }
                            }

                            li["TopNav"] = String.Join(",", ids.ToArray());
                            li.Update();
                        }
                    }
                }

            }
        }

        private static void BuildNav(SPNavigationNodeCollection collection, XmlNode ndParent, ref string IDs, SPWeb web)
        {
            foreach (XmlNode nd in ndParent.ChildNodes)
            {
                string name = getAttribute(nd, "name");
                string url = getAttribute(nd, "url");
                string appid = getAttribute(nd, "AppId");
                bool external = false;

                bool.TryParse(getAttribute(nd, "isExternal"), out external);

                try
                {
                    string wurl = web.ServerRelativeUrl;
                    if (wurl == "/")
                        wurl = "";

                    SPNavigationNode newNav = new SPNavigationNode(name, url.Replace("{SiteUrl}", wurl), external);
                    collection.AddAsLast(newNav);

                    IDs += "," + newNav.Id + ((appid != "") ? ":" + appid : "");
                    BuildNav(newNav.Children, nd, ref IDs, web);
                }
                catch { }
            }
        }

        private static void ClearNav(SPNavigationNodeCollection collection)
        {
            ArrayList arrNodes = new ArrayList();
            foreach (SPNavigationNode nd in collection)
            {
                arrNodes.Add(nd);
            }

            foreach (SPNavigationNode nd in arrNodes)
            {
                collection.Delete(nd);
            }
        }

        public static void CreateTopNavXML(int AppId, SPWeb cWeb)
        {
            CreateGenericXml(AppId, cWeb, "TopNav", cWeb.Navigation.TopNavigationBar);
        }

        public static Guid QueueInstallAndConfigureApplication(string id, bool verifyOnly, SPWeb web, string community)
        {
            var applicationDefinition = GetApplicationInfo(id);
            ExecuteRootApplicationList(web);
            var applicationList = GetApplicationList(web);

            SPListItem listItem;

            var query = new SPQuery();

            query.Query = string.Format(
                "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>{0}</Value></Eq></Where>",
                id);

            SetListItem(id, verifyOnly, applicationList, query, applicationDefinition, out listItem);
            listItem[InstallPercentFieldName] = 0;

            UpdateListItem(
                verifyOnly
                    ? PreCheckQueuedStatus
                    : InstallQueuedStatus,
                listItem);

            return GetJob(verifyOnly, web, community, applicationList, listItem);
        }

        private static void UpdateListItem(string statusFieldName, SPListItem listItem)
        {
            listItem[InstallPercentFieldName] = 0;
            listItem[InstallMessagesFieldName] = string.Empty;
            listItem[StatusFieldName] = statusFieldName;
            listItem.Update();
        }

        private static void SetListItem(
            string id,
            bool verifyOnly,
            SPList applicationList,
            SPQuery query,
            ApplicationDef applicationDefinition,
            out SPListItem listItem)
        {
            var listItems = applicationList.GetItems(query);
            if (listItems.Count > 0)
            {
                try
                {
                    listItem = listItems[0];
                    VerifyApplicationStatus(verifyOnly, listItem);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                if (verifyOnly)
                {
                    listItem = applicationList.Items.Add();
                    listItem[TitleFieldName] = applicationDefinition.Title;
                    listItem[VisibleFieldName] = false;
                    listItem[ExtIdFieldName] = id;
                }
                else
                {
                    throw new Exception("Application has not run through a PreCheck.");
                }
            }
        }

        private static void ExecuteRootApplicationList(SPWeb web)
        {
            if (!web.IsRootWeb)
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(
                        delegate
                        {
                            using (var site = new SPSite(web.Site.ID))
                            {
                                GetApplicationList(site.RootWeb);
                            }
                        });
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }
        }

        private static Guid GetJob(
            bool verifyOnly,
            SPWeb web,
            string community,
            SPList applicationList,
            SPListItem listItem)
        {
            const int jobType = 51;
            const int runtime = -1;
            const int scheduleType = 9;
            const int defaultStatus = 0;

            var job = Timer.AddTimerJob(
                web.Site.ID,
                web.ID,
                applicationList.ID,
                listItem.ID,
                "App PreCheck",
                jobType,
                string.Format("<Data Verify=\"{0}\" Community=\"{1}\"/>", verifyOnly, community),
                string.Empty,
                runtime,
                scheduleType,
                string.Empty);
            CoreFunctions.enqueue(job, defaultStatus, web.Site);
            return job;
        }

        private static void VerifyApplicationStatus(bool verifyOnly, SPListItem listItem)
        {
            if (verifyOnly)
            {
                switch (listItem[StatusFieldName].ToString())
                {
                    case PreCheckQueuedStatus:
                    case PreCheckStartedStatus:
                        throw new Exception("PreCheck in Progress.");
                    case PreCheckFailedStatus:
                    case PreCheckSuccessfulStatus:
                    case NotInstalledStatus:
                        break;
                    case InstallQueuedStatus:
                    case InstallStartedStatus:
                    case InstallingStatus:
                        throw new Exception("Application install in progress.");
                    case InstallFailedStatus:
                    case InstalledStatus:
                        throw new Exception("Application already installed.");
                    default:
                        throw new Exception("Application install in progress.");
                }
            }
            else
            {
                switch (listItem[StatusFieldName].ToString())
                {
                    case PreCheckQueuedStatus:
                    case PreCheckStartedStatus:
                        throw new Exception("PreCheck in Progress.");
                    case PreCheckFailedStatus:
                    case PreCheckSuccessfulStatus:
                        break;
                    case InstallQueuedStatus:
                    case InstallStartedStatus:
                    case InstallingStatus:
                        throw new Exception("Application install in progress.");
                    case InstalledStatus:
                        throw new Exception("Application already installed.");
                    default:
                        throw new Exception("Application status unknown.");
                }
            }
        }

        public static XmlNode CheckUninstallStatus(string jobuid, SPWeb web)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<StatusCheck><Status/><Message/><PercentComplete/></StatusCheck>");

            XmlNode ndTimerStatus = API.Timer.GetTimerJobStatus(web, new Guid(jobuid));
            XmlNode ndStatus = doc.FirstChild;

            try
            {
                ndStatus.SelectSingleNode("Status").InnerText = ndTimerStatus.Attributes["Status"].Value;
            }
            catch
            {
                ndStatus.SelectSingleNode("Status").InnerText = "Could not read status";
            }

            try
            {
                ndStatus.SelectSingleNode("Message").InnerXml = ndTimerStatus.InnerXml;
            }
            catch
            {
                ndStatus.SelectSingleNode("Message").InnerText = "Could not read message";
            }

            try
            {
                ndStatus.SelectSingleNode("PercentComplete").InnerText = ndTimerStatus.Attributes["PercentComplete"].Value;
            }
            catch
            {
                ndStatus.SelectSingleNode("PercentComplete").InnerText = "Could not read % complete";
            }


            return doc.FirstChild;
        }

        public static Guid QueueUninstallApplication(string id, bool verifyOnly, SPWeb web)
        {
            //ApplicationDef appDef = GetApplicationInfoFromList(web, id);

            SPList oList = GetApplicationList(web);

            SPListItem oListItem = null;

            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='ID' /><Value Type='Number'>" + id + "</Value></Eq></Where>";
            SPListItemCollection lic = oList.GetItems(query);
            if (lic.Count > 0)
            {
                oListItem = lic[0];
                Guid job = EPMLiveCore.API.Timer.AddTimerJob(web.Site.ID, web.ID, oList.ID, oListItem.ID, "App Uninstall Check", 52, verifyOnly.ToString(), "", -1, 9, "");
                CoreFunctions.enqueue(job, 0, web.Site);

                return job;
            }
            else
            {
                throw new Exception("Application Not Installed");
            }
        }

        public static XmlNode CheckApplicationStatus(string id, SPWeb web)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<StatusCheck><Status/><Message/><PercentComplete/></StatusCheck>");

            XmlNode ndStatus = doc.FirstChild;

            ApplicationDef appDef = GetApplicationInfo(id);

            SPList oList = GetApplicationList(web);

            SPListItem oListItem = null;

            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + id + "</Value></Eq></Where>";
            SPListItemCollection lic = oList.GetItems(query);
            if (lic.Count > 0)
            {
                oListItem = lic[0];

                try
                {
                    ndStatus.SelectSingleNode("Status").InnerText = oListItem["Status"].ToString();
                }
                catch
                {
                    ndStatus.SelectSingleNode("Status").InnerText = "Could not read status";
                }

                try
                {
                    ndStatus.SelectSingleNode("PercentComplete").InnerText = Convert.ToInt32(float.Parse(oListItem["InstallPercent"].ToString()) * 100).ToString();
                }
                catch
                {
                    ndStatus.SelectSingleNode("PercentComplete").InnerText = "0";
                }

                try
                {
                    ndStatus.SelectSingleNode("Message").InnerText = (float.Parse(oListItem["InstallMessages"].ToString()) * 100).ToString();
                }
                catch
                {
                    ndStatus.SelectSingleNode("Message").InnerText = "";
                }
            }
            else
            {
                ndStatus.SelectSingleNode("Status").InnerText = "Unknown";
            }

            return doc.FirstChild;
        }

        public static XmlNode GetApplicationStatusMessage(string id, SPWeb web, int jobtype)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<StatusCheck><Status/><Message/></StatusCheck>");

            XmlNode ndStatus = doc.FirstChild;

            ApplicationDef appDef = GetApplicationInfo(id);

            SPList oList = GetApplicationList(web);

            SPListItem oListItem = null;

            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + id + "</Value></Eq></Where>";
            SPListItemCollection lic = oList.GetItems(query);
            if (lic.Count > 0)
            {
                oListItem = lic[0];

                try
                {
                    ndStatus.SelectSingleNode("Status").InnerText = oListItem["Status"].ToString();
                }
                catch
                {
                    ndStatus.SelectSingleNode("Status").InnerText = "Could not read status";
                }

                XmlNode ndJob = API.Timer.GetTimerJobStatus(web.Site.ID, web.ID, oList.ID, oListItem.ID, jobtype);

                try
                {
                    ndStatus.SelectSingleNode("Message").InnerXml = ndJob.InnerText;
                }
                catch { ndStatus.SelectSingleNode("Message").InnerText = ndJob.InnerText; }
            }
            else
            {
                ndStatus.SelectSingleNode("Status").InnerText = "Unknown";
            }

            return doc.FirstChild;
        }

        public static void DeleteCommunity(int id, SPWeb web)
        {

            SPList oList = web.Lists.TryGetList("Installed Applications");

            if (oList != null)
            {
                try
                {
                    web.AllowUnsafeUpdates = true;
                    oList.GetItemById(id).Delete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting community: " + ex.Message);
                }
            }
            else
            {
                throw new Exception("Install Applications list is missing");
            }

        }

        private static void CreateCommunityNav(SPListItem LiCommunity, SPNavigationNodeCollection ParentNav, XmlNode ndNavs, ref ArrayList arrNavs)
        {

            foreach (XmlNode nd in ndNavs.ChildNodes)
            {
                if (nd.Name == "Item")
                {
                    string wurl = LiCommunity.ParentList.ParentWeb.ServerRelativeUrl;
                    string title = getAttribute(nd, "Name");
                    string url = getAttribute(nd, "Url");
                    url = url.Replace("{SiteUrl}", (wurl == "/") ? "" : wurl);

                    bool bExternal = false;
                    bool.TryParse(getAttribute(nd, "External"), out bExternal);
                    try
                    {
                        SPNavigationNode newNavNode = new SPNavigationNode(title, url, bExternal);

                        ParentNav.AddAsLast(newNavNode);

                        arrNavs.Add(newNavNode.Id.ToString());

                        CreateCommunityNav(LiCommunity, newNavNode.Children, nd, ref arrNavs);
                    }
                    catch { }
                }
            }

        }

        private static bool bIsFirstCommunity(SPList list)
        {
            SPQuery query = new SPQuery();
            query.Query = "<Where><IsNull><FieldRef Name='EXTID'/></IsNull></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

            if (list.GetItems(query).Count == 0)
                return true;

            return false;
        }

        private static void ReadNavs(SPNavigationNodeCollection ParentNav, ref ArrayList arrNavs)
        {
            foreach (SPNavigationNode nd in ParentNav)
            {
                arrNavs.Add(nd.Id.ToString());

                ReadNavs(nd.Children, ref arrNavs);
            }
        }

        public static int CreateCommunity(string title, SPWeb web)
        {

            SPList oList = GetApplicationList(web);

            if (oList != null)
            {
                try
                {

                    bool bFirst = bIsFirstCommunity(oList);

                    SPListItem li = oList.Items.Add();
                    li["Title"] = title;
                    li["Visible"] = true;


                    string cleanTitle = "";
                    MatchCollection col = Regex.Matches(title, "\\w");
                    foreach (Match m in col)
                    {
                        cleanTitle += m.Value;
                    }

                    SPFile fDefault = web.RootFolder.Files["Default.aspx"];
                    if (fDefault.Exists)
                    {
                        fDefault.CopyTo("SitePages/" + cleanTitle + ".aspx", true);
                    }

                    li["HomePage"] = ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/SitePages/" + cleanTitle + ".aspx";
                    li.Update();


                    if (bFirst)
                    {
                        ArrayList arrNav = new ArrayList();

                        ReadNavs(web.Navigation.QuickLaunch, ref arrNav);

                        if (arrNav.Count > 0)
                        {
                            li[QuickLaunchFieldName] = String.Join(",", (string[])arrNav.ToArray(typeof(string)));
                            li.Update();

                            CreateQuickLaunchXML(li.ID, web);
                        }

                        arrNav = new ArrayList();

                        ReadNavs(web.Navigation.TopNavigationBar, ref arrNav);

                        if (arrNav.Count > 0)
                        {
                            li["TopNav"] = String.Join(",", (string[])arrNav.ToArray(typeof(string)));
                            li.Update();
                            CreateTopNavXML(li.ID, web);
                        }
                    }
                    else
                    {
                        string sNavs = CoreFunctions.getConfigSetting(web, "DefaultCommunityNavs");
                        if (sNavs == "")
                            sNavs = Properties.Resources.DefaultCommunityNavs;

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(sNavs);

                        XmlNode ndQL = doc.FirstChild.SelectSingleNode("//Navs/QuickLaunch");

                        if (ndQL != null)
                        {
                            ArrayList arrNav = new ArrayList();

                            SPNavigationNode newnav = new SPNavigationNode("Dashboard", "SitePages/" + cleanTitle + ".aspx");
                            web.Navigation.QuickLaunch.AddAsFirst(newnav);

                            arrNav.Add(newnav.Id.ToString());

                            CreateCommunityNav(li, web.Navigation.QuickLaunch, ndQL, ref arrNav);

                            li[QuickLaunchFieldName] = String.Join(",", (string[])arrNav.ToArray(typeof(string)));
                            li.Update();

                            CreateQuickLaunchXML(li.ID, web);
                        }

                        XmlNode ndTN = doc.FirstChild.SelectSingleNode("//Navs/TopNav");

                        if (ndTN != null)
                        {
                            ArrayList arrNav = new ArrayList();
                            CreateCommunityNav(li, web.Navigation.TopNavigationBar, ndTN, ref arrNav);

                            li["TopNav"] = String.Join(",", (string[])arrNav.ToArray(typeof(string)));
                            li.Update();
                            CreateTopNavXML(li.ID, web);
                        }
                    }

                    EPMLiveCore.Infrastructure.CacheStore.Current.RemoveSafely(web.Url, new Infrastructure.CacheStoreCategory(web).Navigation);

                    return li.ID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding community: " + ex.Message);
                }
            }
            else
            {
                throw new Exception("Install Applications list is missing");
            }

        }

        public static ApplicationDef GetApplicationInfoFromList(SPWeb oWeb, string id)
        {
            ApplicationDef appDef = new ApplicationDef();
            appDef.Id = 0;

            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + id + "</Value></Eq></Where>";

            SPList list = GetApplicationList(oWeb);

            SPListItemCollection lic = list.GetItems(query);

            if (lic.Count > 0)
            {
                SPListItem li = lic[0];

                appDef.Id = int.Parse(id);
                appDef.Title = li["Title"].ToString();

                appDef.ApplicationXml.LoadXml(li["InstallXML"].ToString());

                try
                {
                    appDef.Community = appDef.ApplicationXml.FirstChild.SelectSingleNode("//Application").Attributes["Community"].Value;
                }
                catch { }
            }

            return appDef;
        }

        private static string GetValidVersion(string checkVersion, string assVersion, string highestVersion)
        {

            if (isValidVersion(checkVersion, assVersion))
            {
                try
                {
                    if (highestVersion == "")
                        return checkVersion;

                    string[] sCheckVersion = checkVersion.Split('.');
                    string[] sHighVersion = highestVersion.Split('.');

                    if (int.Parse(sCheckVersion[0]) > int.Parse(sHighVersion[0]))
                    {
                        return checkVersion;
                    }
                    else
                    {
                        if (int.Parse(sCheckVersion[1]) > int.Parse(sHighVersion[1]))
                        {
                            return checkVersion;
                        }
                        else
                        {
                            if (int.Parse(sCheckVersion[2]) > int.Parse(sHighVersion[2]))
                            {
                                return checkVersion;
                            }
                            else
                            {

                                return highestVersion;

                            }
                        }
                    }
                }
                catch { }
                return highestVersion;

            }
            else
                return highestVersion;

        }

        private static bool isValidVersion(string checkVersion, string assVersion)
        {

            try
            {
                string[] sCheckVersion = checkVersion.Split('.');
                string[] sAssVersion = assVersion.Split('.');

                if (int.Parse(sCheckVersion[0]) < int.Parse(sAssVersion[0]))
                {
                    return true;
                }
                else if (int.Parse(sCheckVersion[0]) == int.Parse(sAssVersion[0]))
                {
                    if (int.Parse(sCheckVersion[1]) < int.Parse(sAssVersion[1]))
                    {
                        return true;
                    }
                    else if (int.Parse(sCheckVersion[1]) == int.Parse(sAssVersion[1]))
                    {
                        if (int.Parse(sCheckVersion[2]) <= int.Parse(sAssVersion[2]))
                        {
                            return true;
                        }
                        else
                        {

                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch { }
            return false;

        }

        private static string GetVersionFolder(WorkEngineSolutionStoreListSvc.Lists listSvc, string applicationfolder)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode queryOptions = xmlDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
            queryOptions.InnerXml = "<ViewAttributes Scope=\"RecursiveAll\" />";

            XmlNode query = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");
            query.InnerXml =
                "<Where><And><Eq><FieldRef Name='FileDirRef' />" +
                "<Value Type='Text'>Applications/" + applicationfolder + "</Value></Eq><Eq><FieldRef Name=\"FSObjType\" /><Value Type=\"Lookup\">1</Value></Eq></And></Where>";

            XmlNode node = listSvc.GetListItems("Applications", null, query, null, null, queryOptions, null);

            string version = "";

            string assVersion = CoreFunctions.GetAssemblyVersion();

            foreach (XmlNode nd in node.ChildNodes)
            {
                if (nd.Name == "rs:data")
                {
                    foreach (XmlNode ndChild in nd.ChildNodes)
                    {
                        if (ndChild.Name == "z:row")
                        {

                            string filename = getAttribute(ndChild, "ows_LinkFilename");

                            if (filename.StartsWith("VERSION_"))
                            {

                                filename = filename.Substring(8);

                                version = GetValidVersion(filename, assVersion, version);

                            }

                        }
                    }
                    break;
                }
            }
            return version;

        }

        public static ApplicationDef GetApplicationInfo(string id)
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

            WorkEngineSolutionStoreListSvc.Lists listSvc = new WorkEngineSolutionStoreListSvc.Lists();
            listSvc.Url = storeurl + "_vti_bin/lists.asmx";
            listSvc.Credentials = CoreFunctions.GetStoreCreds();

            ApplicationDef appDef = new ApplicationDef();

            XmlDocument xDoc = new XmlDocument();

            XmlNode ndQuery = xDoc.CreateNode(XmlNodeType.Element, "Query", "");
            ndQuery.InnerXml = "<Where><Eq><FieldRef Name='UID' /><Value Type='Text'>" + id + "</Value></Eq></Where>";

            XmlNode ndQueryOptions = xDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
            ndQueryOptions.InnerXml = "";

            XmlNode ndViewFields = xDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
            ndViewFields.InnerXml = "<FieldRef Name='Title'/><FieldRef Name='ShortDescription'/><FieldRef Name='PreReqs'/><FieldRef Name='Icon'/><FieldRef Name='AppVersion'/><FieldRef Name='PreReqs_x003a_UID'/>";

            XmlNode ndItems = listSvc.GetListItems("Applications", null, ndQuery, ndViewFields, "10000", ndQueryOptions, null);



            foreach (XmlNode nd in ndItems.ChildNodes)
            {
                if (nd.Name == "rs:data")
                {
                    foreach (XmlNode ndChild in nd.ChildNodes)
                    {
                        if (ndChild.Name == "z:row")
                        {
                            string versionInfo = GetVersionFolder(listSvc, getAttribute(ndChild, "ows_Title"));

                            if (versionInfo != "")
                            {
                                appDef.AppAssemblyVersion = versionInfo;
                                versionInfo = "/VERSION_" + versionInfo;
                            }

                            string rootFilePath = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "Applications/" + getAttribute(ndChild, "ows_Title") + versionInfo;
                            string sXml = "";
                            appDef.fullurl = rootFilePath;
                            appDef.appurl = "Applications/" + getAttribute(ndChild, "ows_Title") + versionInfo;
                            appDef.Title = getAttribute(ndChild, "ows_Title");
                            appDef.Icon = getAttribute(ndChild, "ows_Icon");
                            if (appDef.AppAssemblyVersion != "")
                            {
                                appDef.Version = appDef.AppAssemblyVersion + "_" + getAttribute(ndChild, "ows_AppVersion");
                            }
                            else
                                appDef.Version = getAttribute(ndChild, "ows_AppVersion");

                            try
                            {
                                appDef.Icon = new SPFieldUrlValue(appDef.Icon).Url;
                            }
                            catch { }
                            appDef.Id = int.Parse(id);


                            try
                            {
                                using (WebClient webClient = new WebClient())
                                {
                                    webClient.Credentials = CoreFunctions.GetStoreCreds();
                                    byte[] fileBytes = null;
                                    fileBytes = webClient.DownloadData(rootFilePath + "/Feature.xml");
                                    System.Text.Encoding enc = System.Text.Encoding.ASCII;
                                    sXml = enc.GetString(fileBytes).TrimStart('?');
                                    fileBytes = null;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.EndsWith("(404) Not Found."))
                                {
                                    appDef.loadErrorMessage = "No application for your version was found.";
                                    return appDef;
                                }
                            }
                            appDef.ApplicationXml.LoadXml(sXml);

                            try
                            {
                                if (appDef.ApplicationXml.FirstChild.SelectSingleNode("//Features/Feature[@ID='12345678-0000-0000-0000-000000000000']") != null)
                                {
                                    appDef.loadErrorMessage = "No application for your version was found.";
                                    return appDef;
                                }
                            }
                            catch { }

                            try
                            {
                                appDef.Visible = bool.Parse(appDef.ApplicationXml.FirstChild.SelectSingleNode("//Application").Attributes["Visible"].Value);
                            }
                            catch { }

                            try
                            {
                                appDef.ParentApplications = appDef.ApplicationXml.FirstChild.SelectSingleNode("//Application").Attributes["ParentApplications"].Value.Split(',');
                            }
                            catch { }

                            try
                            {
                                appDef.Community = appDef.ApplicationXml.FirstChild.SelectSingleNode("//Application").Attributes["Community"].Value;
                            }
                            catch { }

                            string sLvc = getAttribute(ndChild, "ows_PreReqs");
                            if (sLvc != "")
                            {
                                int counter = 0;
                                SPFieldLookupValueCollection lvcuid = new SPFieldLookupValueCollection(getAttribute(ndChild, "ows_PreReqs_x003a_UID"));
                                SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(sLvc);
                                foreach (SPFieldLookupValue lv in lvc)
                                {
                                    appDef.PreReqs.Add(lvcuid[counter].LookupValue, lv.LookupValue);
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }

            return appDef;
        }

        public static DataTable GetApplications(string dataxml)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Description");
            dt.Columns.Add("MoreInfo");
            dt.Columns.Add("Company");
            dt.Columns.Add("PreReqs");

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

            WorkEngineSolutionStoreListSvc.Lists listSvc = new WorkEngineSolutionStoreListSvc.Lists();
            listSvc.Url = storeurl + "_vti_bin/lists.asmx";
            listSvc.Credentials = CoreFunctions.GetStoreCreds();

            XmlDocument xDoc = new XmlDocument();

            XmlNode ndQuery = xDoc.CreateNode(XmlNodeType.Element, "Query", "");
            ndQuery.InnerXml = "<Query><Where><And><Eq><FieldRef Name='Visible' /><Value Type='Boolean'>1</Value></Eq><Eq><FieldRef Name='CodeVersions' /><Value Type='MultiChoice'>" + CoreFunctions.GetAssemblyVersion() + "</Value></Eq></And></Where><OrderBy><FieldRef Name='Title'/></OrderBy></Query>";

            XmlNode ndQueryOptions = xDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
            ndQueryOptions.InnerXml = "";

            XmlNode ndViewFields = xDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
            ndViewFields.InnerXml = "<FieldRef Name='Title'/><FieldRef Name='ShortDescription'/><FieldRef Name='MoreInfo'/><FieldRef Name='Company'/><FieldRef Name='PreReqs'/><FieldRef Name='UID'/>";

            XmlNode ndItems = listSvc.GetListItems("Applications", null, ndQuery, ndViewFields, "10000", ndQueryOptions, null);

            foreach (XmlNode nd in ndItems.ChildNodes)
            {
                if (nd.Name == "rs:data")
                {
                    foreach (XmlNode ndChild in nd.ChildNodes)
                    {
                        if (ndChild.Name == "z:row")
                        {
                            dt.Rows.Add(new string[] { getAttribute(ndChild, "ows_UID"), getAttribute(ndChild, "ows_Title"), getAttribute(ndChild, "ows_ShortDescription"), getAttribute(ndChild, "ows_MoreInfo"), getAttribute(ndChild, "ows_Company"), getAttribute(ndChild, "ows_PreReqs"), });
                        }
                    }
                }
            }

            return dt;
        }
    }
}
