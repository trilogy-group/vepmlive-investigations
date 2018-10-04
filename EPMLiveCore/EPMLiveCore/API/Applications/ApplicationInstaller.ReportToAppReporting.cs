using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
using EPMLiveCore.ApplicationStore;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private void ReportToAppReporting(SPWeb web)
        {
            try
            {
                var act = new Act(web);
                var oUser = oWeb.AllUsers.GetByID(_configJob.userid);

                var source = 1;
                var sourceurl = string.Empty;


                if (act.IsOnline)
                {
                    source = 2;
                    sourceurl = web.Url;
                }

                var apprep = new AppStoreReporting.AppStore();
                apprep.Timeout = 1000;
                var ret =
                    apprep.AddStoreInformation("<Info><Name><![CDATA[" + oUser.Name + "]]></Name><Email><![CDATA[" + oUser.Email +
                                               "]]></Email><Title><![CDATA[" + appDef.Title + "]]></Title><AppID><![CDATA[" + appDef.Id +
                                               "]]></AppID><Source><![CDATA[" + source + "]]></Source><SourceUrl><![CDATA[" + sourceurl +
                                               "]]></SourceUrl></Info>");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private void reportResults()
        {
            if (bVerifyOnly)
            {
                if (MaxErrorLevel > 1)
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
                if (MaxErrorLevel > 5)
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
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var site = new SPSite(oWeb.Site.ID))
                {
                    var list = Applications.GetApplicationList(site.RootWeb);
                    if (list != null)
                    {
                        var li = list.Items.Add();
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
            });
        }

        private bool CheckInstalledRoot()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var site = new SPSite(oWeb.Site.ID))
                {
                    using (var root = site.OpenWeb())
                    {
                        var list = root.Lists.TryGetList("Installed Applications");

                        var query = new SPQuery();
                        query.Query = "<Where><And><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + appDef.Id +
                                      "</Value></Eq><Eq><FieldRef Name='Status' /><Value Type='Text'>Installed</Value></Eq></And></Where>";

                        var lic = list.GetItems(query);

                        if (lic.Count > 0)
                        {
                            var pId = addMessage(ErrorLevels.Upgrade, "Application Install",
                                "Application is already installed in site collection and will configure.", 0);

                            try
                            {
                                var li = lic[0];
                                appDef.ApplicationXml.LoadXml(li["InstallXML"].ToString());
                                appDef.Version = li["AppVersion"].ToString();
                                try
                                {
                                    appDef.fullurl = oListItem["AppUrl"].ToString();
                                    appDef.appurl = appDef.fullurl.Replace(CoreFunctions.getFarmSetting("WorkEngineStore"), string.Empty);
                                }
                                catch (Exception ex)
                                {
                                    Trace.WriteLine(ex.ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                addMessage(ErrorLevels.Error, "Copying Feature XML", "Error: " + ex.Message, pId);

                                Trace.WriteLine(ex.ToString());
                            }
                            bIsInstalledElsewhere = true;
                        }
                    }
                }
            });

            return true;
        }

        private int updateParentStatus(int parent, ErrorLevels level)
        {
            if (parent > 0)
            {
                var drParent = _dtMessages.Select("ID='" + parent + "'");
                if (drParent.Length > 0)
                {
                    if ((ErrorLevels)drParent[0][2] < level)
                    {
                        drParent[0][2] = (int)level;
                    }

                    var tabLength = updateParentStatus((int)drParent[0]["ParentID"], level);
                    return tabLength + 1;
                }
            }
            return 0;
        }

        private int addMessage(ErrorLevels level, string message, string details, int parent)
        {
            if (MaxErrorLevel < (int)level)
            {
                MaxErrorLevel = (int)level;
            }

            _MessageId++;

            var tabLength = updateParentStatus(parent, level);

            _dtMessages.Rows.Add(_MessageId, parent, (int)level, message, details, tabLength.ToString());

            return _MessageId;
        }

        private string GetCleanUrl(string url)
        {
            url = url.Replace("{SiteUrl}", oWeb.ServerRelativeUrl == "/" ? string.Empty : oWeb.ServerRelativeUrl);

            return url;
        }

        private bool IsListInstalledWithApplication(string list)
        {
            try
            {
                if (list != string.Empty && appDef.ApplicationXml.FirstChild.SelectSingleNode("Lists").SelectNodes("List[@Name='" + list + "']").Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return false;
        }

        private bool DoesLocationExist(string url, string rawUrl, string list, XmlNode ndFiles)
        {
            if (oWeb.GetFile(url).Exists || oWeb.GetFolder(url).Exists)
            {
                return true;
            }
            if (url.Contains("_layouts/"))
            {
                return true;
            }
            if (bVerifyOnly)
            {
                try
                {
                    if (ndFiles.SelectNodes("//File[@FullFile='" + rawUrl.Replace("{SiteUrl}/", string.Empty) + "']").Count > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
                try
                {
                    if (list != string.Empty && appDef.ApplicationXml.FirstChild.SelectSingleNode("Lists").SelectNodes("List[@Name='" + list + "']").Count > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
                return false;
            }
            return false;
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

        private void iProcessLI(XmlNode ndApp)
        {
            try
            {
                oListItem["Description"] = ndApp.SelectSingleNode("Description").InnerText;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
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
                if (appDef.Icon != null && appDef.Icon != string.Empty)
                {
                    using (var webClient = new WebClient())
                    {
                        ServicePointManager.ServerCertificateValidationCallback +=
                            delegate { return true; };

                        webClient.Credentials = CoreFunctions.GetStoreCreds();
                        byte[] fileBytes = null;
                        fileBytes = webClient.DownloadData(appDef.Icon);

                        oWeb.Files.Add("AppDocuments/" + oListItem.ID + Path.GetExtension(appDef.Icon), fileBytes, true);

                        oListItem["Icon"] = (oWeb.ServerRelativeUrl == "/" ? string.Empty : oWeb.ServerRelativeUrl) + "/AppDocuments/" + oListItem.ID +
                                            Path.GetExtension(appDef.Icon);
                    }
                }
            }
        }

        private bool CheckForKeys()
        {
            var ndApplication = appDef.ApplicationXml.FirstChild.SelectSingleNode("Application");
            if (ndApplication != null)
            {
                if (ndApplication.Attributes["RequiredFeatureKeys"] != null)
                {
                    var reqKeys = ndApplication.Attributes["RequiredFeatureKeys"].Value;
                    if (reqKeys != string.Empty)
                    {
                        var ParentMessageId = addMessage(ErrorLevels.NoError, "Activation Key Check", string.Empty, 0);

                        var failed = false;

                        var featureIds = reqKeys.Split(',');

                        var act = new Act(oWeb);

                        foreach (var featureId in featureIds)
                        {
                            try
                            {
                                if (act.CheckFeatureLicense((ActFeature)int.Parse(featureId)) == 0)
                                {
                                    addMessage(ErrorLevels.NoError, CoreFunctions.getFeatureName(featureId), string.Empty, ParentMessageId);
                                }
                                else
                                {
                                    addMessage(ErrorLevels.Error, CoreFunctions.getFeatureName(featureId), "Activation Key Not Installed", ParentMessageId);

                                    failed = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                Trace.WriteLine(ex.ToString());
                            }
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
                var ParentMessageId = addMessage(ErrorLevels.NoError, "Pre Requisite Check", string.Empty, 0);

                var failed = false;

                foreach (DictionaryEntry de in appDef.PreReqs)
                {
                    var query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name='EXTID' /><Value Type='Number'>" + de.Key + "</Value></Eq></Where>";
                    var lic = oAppList.GetItems(query);

                    if (lic.Count > 0)
                    {
                        addMessage(ErrorLevels.NoError, de.Value.ToString(), string.Empty, ParentMessageId);
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, de.Value.ToString(), "Application not installed", ParentMessageId);

                        failed = true;
                    }
                }

                return !failed;
            }
            addMessage(ErrorLevels.Error, "Pre-Requisite Check", "Unable to find Installed Applications List", 0);
            return false;
        }

        private void iInstallListsViewsWebparts(SPList oList, XmlNode ndList, int ParentMessageId, bool added)
        {
            var ndViews = ndList.SelectSingleNode("Views");

            if (ndViews != null)
            {
                var storeurl = CoreFunctions.getFarmSetting("workenginestore");

                ServicePointManager.ServerCertificateValidationCallback +=
                    delegate { return true; };

                var copy = new AppStore();
                copy.Credentials = CoreFunctions.GetStoreCreds();
                copy.Url = storeurl + "_vti_bin/appstore.asmx";

                if (bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking WebParts", string.Empty, ParentMessageId);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Updating WebParts", string.Empty, ParentMessageId);
                }

                var bInstallAll = false;
                bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndViews, "InstallGridOnAllViews"), out bInstallAll);

                if (bInstallAll)
                {
                    addMessage(0, "Grid on All Views", string.Empty, ParentMessageId);
                }

                if (oList != null)
                {
                    foreach (SPView oView in oList.Views)
                    {
                        if (!oView.PersonalView)
                        {
                            var ndView = ndViews.SelectSingleNode("View[@Name='" + oView.Title + "']");

                            InstallListsViewsWebPartsInstall(oView, bInstallAll, copy, ParentMessageId);
                        }
                    }
                }
            }
        }

        private void iInstallSolutions()
        {
            var ndSolutions = appDef.ApplicationXml.FirstChild.SelectSingleNode("Solutions");
            var ParentMessageId = 0;

            if (ndSolutions != null)
            {
                if (bVerifyOnly)
                {
                    ParentMessageId = addMessage(0, "Checking Solutions and Lists", string.Empty, 0);
                }
                else
                {
                    ParentMessageId = addMessage(0, "Installing Solutions and Lists", string.Empty, 0);
                }

                float percent = 0;

                var ListNdSolutions = ndSolutions.ChildNodes;
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
                        default:
                            Trace.WriteLine("ArgumentOutOfRangeException ndSolution.Name");
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
                var solutions = (SPDocumentLibrary)oWeb.Site.GetCatalog(SPListTemplateType.SolutionCatalog);

                var FileName = ApplicationInstallerHelpers.getAttribute(ndSolution, "FileName");
                var bOverwrite = false;
                bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndSolution, "Overwrite"), out bOverwrite);

                if (bVerifyOnly)
                {
                    var found = false;

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
                    {
                        addMessage(ErrorLevels.NoError, FileName, string.Empty, ParentMessageId);
                    }
                }
                else
                {
                    var found = false;
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

                    using (var webClient = new WebClient())
                    {
                        ServicePointManager.ServerCertificateValidationCallback +=
                            delegate { return true; };

                        webClient.Credentials = CoreFunctions.GetStoreCreds();
                        byte[] fileBytes = null;
                        fileBytes = webClient.DownloadData(appDef.fullurl + "/Solutions/" + FileName);
                        newFile = solutions.RootFolder.Files.Add(FileName, fileBytes);
                    }

                    if (newFile != null)
                    {
                        var solution = oWeb.Site.Solutions.Add(newFile.Item.ID);
                    }

                    addMessage(ErrorLevels.NoError, FileName, string.Empty, ParentMessageId);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                addMessage(ErrorLevels.Error, ndSolution.Attributes["FileName"].Value, "Error: " + ex.Message, ParentMessageId);
            }
        }

        private void iInstallListTemplate(XmlNode ndSolution, int ParentMessageId)
        {
            try
            {
                var solutions = (SPDocumentLibrary)oWeb.Site.GetCatalog(SPListTemplateType.ListTemplateCatalog);

                var FileName = ApplicationInstallerHelpers.getAttribute(ndSolution, "FileName");
                var bOverwrite = false;
                bool.TryParse(ApplicationInstallerHelpers.getAttribute(ndSolution, "Overwrite"), out bOverwrite);

                if (bVerifyOnly)
                {
                    var found = false;

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
                    {
                        addMessage(ErrorLevels.NoError, FileName, string.Empty, ParentMessageId);
                    }
                }
                else
                {
                    var found = false;
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
                        using (var webClient = new WebClient())
                        {
                            ServicePointManager.ServerCertificateValidationCallback +=
                                delegate { return true; };

                            webClient.Credentials = CoreFunctions.GetStoreCreds();
                            byte[] fileBytes = null;
                            fileBytes = webClient.DownloadData(appDef.fullurl + "/Lists/" + FileName);
                            solutions.RootFolder.Files.Add(FileName, fileBytes);
                        }

                        if (found)
                        {
                            addMessage(ErrorLevels.NoError, FileName, "List template upgraded", ParentMessageId);
                        }
                        else
                        {
                            addMessage(ErrorLevels.NoError, FileName, string.Empty, ParentMessageId);
                        }
                    }
                    else
                    {
                        addMessage(ErrorLevels.Error, FileName, "List template exists and cannot upgrade", ParentMessageId);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                addMessage(ErrorLevels.Error, ndSolution.Attributes["FileName"].Value, "Error: " + ex.Message, ParentMessageId);
            }
        }

        private int GetParentFolderId(Hashtable hshParents, string sParentFolder, int mainId)
        {
            if (hshParents.ContainsKey(sParentFolder))
            {
                return (int)hshParents[sParentFolder];
            }

            return mainId;
        }

        private void iInstallFile(string sFileName, string sParentFolder, string sFullFile, AppStore copy)
        {
            var oParentFolder = oWeb.GetFolder(sParentFolder);

            if (oParentFolder.Exists)
            {
                var sUrl = appDef.fullurl + "/Files/" + sFullFile;

                var fileBytes = copy.GetFile(sUrl);

                oParentFolder.Files.Add(sFileName, fileBytes, true);
            }
            else
            {
                throw new Exception("Parent folder does not exist");
            }
        }
    }
}