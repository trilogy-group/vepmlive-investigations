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
        private const string InstallListsViewsMethod = "iInstallListsViews";

        [TestMethod]
        public void InstallListsViews_When_VerifyOnly()
        {
            InstallListsViewsCommon(true, false, true, "Checking Views", "name", string.Empty);
        }

        [TestMethod]
        public void InstallListsViews_When_VerifyOnly_And_OverWrite()
        {
            InstallListsViewsCommon(true, true, true, "Checking Views", "name", "View exists and will overwrite");
        }

        [TestMethod]
        public void InstallListsViews_When_VerifyOnly_And_NoOverWrite()
        {
            InstallListsViewsCommon(true, true, false, "Checking Views", "name", "View exists but can't overwrite");
        }

        [TestMethod]
        public void InstallListsViews_Wnen_No_View()
        {
            InstallListsViewsCommon(false, false, true, "Updating Views", "name", string.Empty);
        }

        [TestMethod]
        public void InstallListsViews_Wnen_View()
        {
            InstallListsViewsCommon(false, true, false, "Updating Views", "name", "View exists but can't overwrite");
        }

        [TestMethod]
        public void InstallListsViews_Wnen_View_And_OverWrite()
        {
            InstallListsViewsCommon(false, true, true, "Updating Views", "name", "View exists and will overwrite");
        }

        private void InstallListsViewsCommon(
            bool verifyOnly, 
            bool hasView, 
            bool overWrite,
            string expectedRow03,
            string expectedRow13,
            string expectedRow14)
        {
            // Arrange
            var appDef = new ApplicationDef();
            var xmlDoc = new XmlDocument();            
            xmlDoc.LoadXml($"<root><Views><View Name='name' Overwrite='{overWrite}'><Fields></Fields></View></Views></root>");
            var ndList = xmlDoc.FirstChild;

            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);

            ShimSPViewCollection.AllInstances.ItemGetString = (_, __) => hasView ? new ShimSPView(): null;

            // Act
            _privateObject.Invoke(InstallListsViewsMethod, new object[] { new ShimSPList().Instance, ndList, 0, true });
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(2, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectedRow13, dtMessages.Rows[1][3]);
            Assert.AreEqual(expectedRow14, dtMessages.Rows[1][4]);
        }
    }
}