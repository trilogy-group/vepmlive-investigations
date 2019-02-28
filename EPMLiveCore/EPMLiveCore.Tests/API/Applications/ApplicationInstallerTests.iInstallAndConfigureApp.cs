using System.Data;
using System.Text;
using EPMLiveCore.API;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{

    public partial class ApplicationInstallerTests
    {
        private const string InstallAndConfigureAppMethod = "InstallAndConfigureApp";
        private const string AppListProp = "oAppList";
        private const string CommunityProp = "iCommunity";

        [TestMethod]
        public void InstallAndConfigureApp_UnableToFind()
        {
            InstallAndConfigureAppCommon(false, 0, false, true, 1, "Installing Application", "Unable to find Installed Applications List", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        [TestMethod]
        public void InstallAndConfigureApp_When_Verify()
        {
            InstallAndConfigureAppCommon(true, 0, true, true, 8, "Install Version", "version", "Checking Files", string.Empty, "Checking Navigation", string.Empty, "QuickLaunch", "name", "name", "TopNav", "Processing Reports", string.Empty);
        }

        [TestMethod]
        public void InstallAndConfigureApp_When_Installing()
        {
            InstallAndConfigureAppCommon(true, 0, false, true, 9, "Install Version", "version", "Installing Files", string.Empty, "Creating Community", "community", "Installing Navigation", "QuickLaunch", "name", "name", "TopNav", "Processing Reports");
        }

        [TestMethod]
        public void InstallAndConfigureApp_When_Installing_And_Community()
        {
            InstallAndConfigureAppCommon(true, 1, false, true, 9, "Install Version", "version", "Installing Files", string.Empty, "Creating Community", "community", "Installing Navigation", "QuickLaunch", "name", "name", "TopNav", "Processing Reports");
        }

        private void InstallAndConfigureAppCommon(
            bool hasAppList,
            int community,
            bool verifyOnly,
            bool overWrite,
            int rowCount,
            string expectedRow03,
            string expectedRow04,
            string expectedRow13,
            string expectedRow14,
            string expectedRow23,
            string expectedRow24,
            string expectedRow33,
            string expectedRow43,
            string expectedRow53,
            string expectedRow63,
            string expectedRow73,
            string expectedRow83)

        {
            // Arrange
            var appDef = new ApplicationDef
            {
                Community = "community",
                Version = "version"
            };
            var xml = new StringBuilder();
            xml.Append("<root>")
                .Append("<Application ProcessReports='true'>")
                .Append("<QuickLaunch>")
                .Append("<Item Name='name' Url='url' External='true'>")
                .Append("<Item Name='name' Url='url' External='true'/>")
                .Append("</Item>")
                .Append("</QuickLaunch>")
                .Append("<TopNav/>")
                .Append("</Application>")
                .Append("</root>");
            appDef.ApplicationXml.LoadXml(xml.ToString());
            
            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);
            _privateObject.SetFieldOrProperty(ListItemProp, new ShimSPListItem().Instance);
            _privateObject.SetFieldOrProperty(AppListProp, hasAppList ? new ShimSPList().Instance : null);

            ShimSPListItem.AllInstances.IDGet = _ => community;

            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();

            // Act
            _privateObject.Invoke(InstallAndConfigureAppMethod);
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(rowCount, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectedRow04, dtMessages.Rows[0][4]);
            if (rowCount > 1)
            {
                Assert.AreEqual(expectedRow13, dtMessages.Rows[1][3]);
                Assert.AreEqual(expectedRow14, dtMessages.Rows[1][4]);

                if (rowCount > 2)
                {
                    Assert.AreEqual(expectedRow23, dtMessages.Rows[2][3]);
                    Assert.AreEqual(expectedRow24, dtMessages.Rows[2][4]);
                    Assert.AreEqual(expectedRow33, dtMessages.Rows[3][3]);
                    Assert.AreEqual(expectedRow43, dtMessages.Rows[4][3]);
                    Assert.AreEqual(expectedRow53, dtMessages.Rows[5][3]);

                    if (rowCount > 6)
                    {
                        Assert.AreEqual(expectedRow63, dtMessages.Rows[6][3]);
                        if (rowCount > 7)
                        {
                            Assert.AreEqual(expectedRow73, dtMessages.Rows[7][3]);
                            if (rowCount > 8)
                            {
                                Assert.AreEqual(expectedRow83, dtMessages.Rows[8][3]);
                            }
                        }
                    }
                }
            }
        }
    }
}