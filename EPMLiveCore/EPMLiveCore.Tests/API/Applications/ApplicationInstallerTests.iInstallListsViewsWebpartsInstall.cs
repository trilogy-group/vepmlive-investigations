using System.Data;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.ApplicationStore.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    public partial class ApplicationInstallerTests
    {
        private const string InstallListsViewsWebpartsInstallMethod = "InstallListsViewsWebPartsInstall";

       [TestMethod]
        public void InstallListsViewsWebpartsInstall_When_VerifyOnly()
        {
            InstallListsViewsWebpartsInstallCommon(true, true, "title");
        }

        [TestMethod]
        public void InstallListsViewsWebpartsInstall_When_HasViewFile()
        {
            InstallListsViewsWebpartsInstallCommon(false, true, "title");
        }

        [TestMethod]
        public void InstallListsViewsWebpartsInstall_When_()
        {
            InstallListsViewsWebpartsInstallCommon(false, false, "title");
        }

        private void InstallListsViewsWebpartsInstallCommon(bool verifyOnly, bool hasViewFile, string expectedRow03)
        {
            // Arrange
            var appDef = new ApplicationDef();
            
            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);

            ShimAppStore.AllInstances.GetFileString = (a, b) => hasViewFile ? new byte[] { 0 } : null;

            // Act
            _privateObject.Invoke(InstallListsViewsWebpartsInstallMethod, new object[] { new ShimSPView().Instance, true, new ShimAppStore().Instance, 0 });
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(1, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);            
        }
    }
}