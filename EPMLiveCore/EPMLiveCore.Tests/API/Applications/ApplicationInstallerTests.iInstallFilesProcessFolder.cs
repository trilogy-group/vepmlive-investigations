using System;
using System.Data;
using System.Text;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.ApplicationStore.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    
    public partial class ApplicationInstallerTests
    {
        private const string iInstallFilesProcessFolderMethod = "InstallFilesProcessFolder";

        [TestMethod]
        public void InstallFilesProcessFolder_When_SkipReport()
        {
            iInstallFilesProcessFolderCommon(true, true, true, false, 1, true, "path/", "Folder: Report Library");
        }

        [TestMethod]
        public void InstallFilesProcessFolder_When_Type1()
        {
            iInstallFilesProcessFolderCommon(false, true, false, false, 1, true, "path/", "Folder: Report Library");
        }

        [TestMethod]
        public void InstallFilesProcessFolder_When_Type1_And_FolderNotExist()
        {
            iInstallFilesProcessFolderCommon(false, true, false, false, 1, true, "path", "Folder: Report Library");
        }

        [TestMethod]
        public void InstallFilesProcessFolder_When_Type1_And_FolderExist()
        {
            iInstallFilesProcessFolderCommon(false, true, false, true, 1, true, "path", "Folder: Report Library");
        }

        [TestMethod]
        public void InstallFilesProcessFolder_When_TypeOther_And_FileExist_And_OverWrite()
        {
            iInstallFilesProcessFolderCommon(false, true, false, true, 2, true, "path", "File: Report Library");
        }

        [TestMethod]
        public void InstallFilesProcessFolder_When_And_FileExist_TypeOther()
        {
            iInstallFilesProcessFolderCommon(false, false, false, true, 2, true, "path", "File: Report Library");
        }

        [TestMethod]
        public void InstallFilesProcessFolder_When_TypeOther_And_OverWrite()
        {
            iInstallFilesProcessFolderCommon(false, true, false, true, 2, false, "path", "File: Report Library");
        }

        [TestMethod]
        public void InstallFilesProcessFolder_When_And_TypeOther()
        {
            iInstallFilesProcessFolderCommon(false, false, false, true, 2, false, "path", "File: Report Library");
        }

        private void iInstallFilesProcessFolderCommon(
            bool verifyOnly,
            bool overWrite,
            bool skipReports, 
            bool folderExist,
            int typeValue,
            bool fileExist,
            string pathValue,
            string expectedRow03)                     
        {
            // Arrange
            var xml = new StringBuilder();
            var xmlDocument = new XmlDocument();
            xml.Append("<Folders>")
                .AppendFormat("<Folder RemoteFile='{0}' Type='{1}' Name='Report Library' Overwrite='false'/>", pathValue, typeValue)
                .Append("</Folders>");

            xmlDocument.LoadXml(xml.ToString());
            var ndFolder = xmlDocument.FirstChild;

            var appDef = new ApplicationDef();
            xml.Clear();
            xml.Append("<root>")
                .Append("<Lists>")
                .Append("</Lists>")
                .Append("</root>");
            appDef.ApplicationXml.LoadXml(xml.ToString());

            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);
            _privateObject.SetFieldOrProperty(ListItemProp, new ShimSPListItem().Instance);

            ShimSPWeb.AllInstances.IDGet = _ => skipReports ? Guid.NewGuid() : Guid.Empty;
            ShimSPFolder.AllInstances.ExistsGet = _ => folderExist;
            ShimSPFile.AllInstances.ExistsGet = _ => fileExist;

            // Act
            _privateObject.Invoke(iInstallFilesProcessFolderMethod, new object[] { 0, 0, ndFolder, 0, new ShimAppStore().Instance, overWrite });
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(1, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
        }
    }
}