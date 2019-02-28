using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using EPMLiveCore.ApplicationStore;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private void InstallFilesProcessFolder(int parentMessageId, float counter, XmlNode ndFolder, float max, AppStore appCopy, bool overwrite)
        {
            if (ndFolder == null)
            {
                throw new ArgumentNullException(nameof(ndFolder));
            }
            var ndLists = appDef.ApplicationXml.FirstChild.SelectSingleNode("Lists");

            foreach (XmlNode ndChild in ndFolder.ChildNodes)
            {
                var remoteName = ApplicationInstallerHelpers.getAttribute(ndChild, "RemoteFile");
                var sType = ApplicationInstallerHelpers.getAttribute(ndChild, "Type");
                var fullFile = remoteName.Replace(appDef.appurl + "/Files/", string.Empty);
                var fileName = ApplicationInstallerHelpers.getAttribute(ndChild, "Name");
                var parentFolder = Path.GetDirectoryName(fullFile).Replace("\\", "/");

                try
                {
                    var bSkipReports = fileName == "Report Library" && oWeb.ID != oWeb.Site.RootWeb.ID;
                    if (bSkipReports)
                    {
                        addMessage(ErrorLevels.NoError, "Folder: Report Library", "Report Library will not be processed at web level", parentMessageId);
                    }
                    else
                    {
                        InstallFilesProcessFolder(parentMessageId, counter, max, appCopy, overwrite, ndLists, ndChild, sType, fullFile, fileName, parentFolder);
                    }
                }
                catch (Exception ex)
                {
                    addMessage(ErrorLevels.Error, fileName, "Error: " + ex.Message, parentMessageId);
                    Trace.WriteLine(ex.ToString());
                }

                counter++;
                var percent = counter / max;
                updateLIPercent(percent);
            }
        }

        private void InstallFilesProcessFolder(int parentMessageId, float counter, float max, AppStore appCopy, bool overwrite, XmlNode ndLists, XmlNode ndChild, string sType, string fullFile, string fileName, string parentFolder)
        {
            if (sType == "1")
            {
                var spFolder = oWeb.GetFolder(fullFile);

                var id = parentMessageId;
                var bProcessFolder = false;

                if (!spFolder.Exists)
                {
                    InstallFilesProcessFolder(parentMessageId, ndLists, fullFile, fileName, out id, out bProcessFolder);
                }
                else
                {
                    InstallFilesProcessFolder(parentMessageId, ndChild, fileName, out id, out bProcessFolder);
                }

                var overwriteFolder = overwrite;
                try
                {
                    overwriteFolder = bool.Parse(ApplicationInstallerHelpers.getAttribute(ndChild, "Overwrite"));
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }

                if (bProcessFolder)
                {
                    InstallFilesProcessFolder(id, counter, ndChild, max, appCopy, overwriteFolder);
                }
            }
            else
            {
                var overWriteFile = false;
                try
                {
                    overWriteFile = bool.Parse(ApplicationInstallerHelpers.getAttribute(ndChild, "Overwrite"));
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }

                InstallFile(parentMessageId, appCopy, overwrite, ndChild, fullFile, fileName, parentFolder, overWriteFile);
            }
        }

        private void InstallFilesProcessFolder(int parentMessageId, XmlNode ndLists, string fullFile, string fileName, out int id, out bool bProcessFolder)
        {
            bProcessFolder = false;
            if (fullFile.Contains("/"))
            {
                if (!bVerifyOnly)
                {
                    oWeb.Folders.Add(fullFile);
                    oWeb.GetFolder(fullFile);
                }
                bProcessFolder = true;
                id = addMessage(ErrorLevels.NoError, $"Folder: {fileName}", string.Empty, parentMessageId);
            }
            else
            {
                XmlNode ndList = null;
                try
                {
                    ndList = ndLists.SelectSingleNode($"List[@Name='{fileName}']");
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }

                if (ndList == null)
                {
                    id = addMessage(ErrorLevels.Error, $"Folder: {fileName}", "Document Library or Folder does not exist.", parentMessageId);
                }
                else
                {
                    id = addMessage(ErrorLevels.NoError, $"Folder: {fileName}", string.Empty, parentMessageId);
                    bProcessFolder = true;
                }
            }
        }

        private void InstallFilesProcessFolder(int parentMessageId, XmlNode ndChild, string fileName, out int id, out bool bProcessFolder)
        {
            var attrNoDelete = ndChild.Attributes["NoDelete"];
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
            id = addMessage(ErrorLevels.NoError, "Folder: " + fileName, string.Empty, parentMessageId);
        }

        private void InstallFile(int parentMessageId, AppStore appCopy, bool overwrite, XmlNode ndChild, string fullFile, string fileName, string parentFolder, bool overWriteFile)
        {
            var spFille = oWeb.GetFile(ApplicationInstallerHelpers.getAttribute(ndChild, "FullFile"));
            if (spFille.Exists)
            {
                if (overwrite || overWriteFile)
                {
                    try
                    {
                        if (!bVerifyOnly)
                        {
                            iInstallFile(fileName, parentFolder, fullFile, appCopy);
                        }

                        addMessage(ErrorLevels.NoError, "File: " + fileName, string.Empty, parentMessageId);
                    }
                    catch (Exception ex)
                    {
                        addMessage(ErrorLevels.Error, "File: " + fileName, "Error: " + ex.Message, parentMessageId);
                        Trace.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    addMessage(ErrorLevels.Warning, "File: " + fileName, "File exists and can't overwrite", parentMessageId);
                }
            }
            else
            {
                try
                {
                    if (!bVerifyOnly)
                    {
                        iInstallFile(fileName, parentFolder, fullFile, appCopy);
                    }

                    addMessage(ErrorLevels.NoError, "File: " + fileName, string.Empty, parentMessageId);
                }
                catch (Exception ex)
                {
                    addMessage(ErrorLevels.Error, "File: " + fileName, "Error: " + ex.Message, parentMessageId);
                    Trace.WriteLine(ex.ToString());
                }
            }
        }
    }
}