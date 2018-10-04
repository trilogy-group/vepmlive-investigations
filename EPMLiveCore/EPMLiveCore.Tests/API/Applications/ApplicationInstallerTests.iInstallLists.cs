using System;
using System.Data;
using System.Text;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{

    public partial class ApplicationInstallerTests
    {
        private const string iInstallListsMethod = "iInstallLists";

        [TestMethod]
        public void iInstallLists_When_Checking_And_ListExist_And_HasNoDelete()
        {
            iInstallListsCommon(true, true, true, true, 3, "Checking Lists", "name", "List exists and will upgrade", "Add to Reporting Database", "");
        }

        [TestMethod]
        public void iInstallLists_When_Checking_And_ListNotExist()
        {
            iInstallListsCommon(true, false, false, false, 3, "Checking Lists", "name", string.Empty, "Add to Reporting Database", "");
        }

        
        [TestMethod]
        public void iInstallLists_When_Installing()
        {
            iInstallListsCommon(false, true, true, true, 3, "Installing Lists", "name", "List exists and will upgrade", "Add to Reporting Database", "");
        }

        [TestMethod]
        public void iInstallLists_When_Installing_And_Cannot_Upgrade()
        {
            iInstallListsCommon(false, false, false, true, 2, "Installing Lists", "name", "List exists and cannot upgrade", "Add to Reporting Database", "");
        }

        private void iInstallListsCommon(
            bool verifyOnly,
            bool canUpgrade,
            bool hasNoDelete,
            bool isListExist,
            int rowCount,
            string expectedRow03,
            string expectedRow13,
            string expectedRow14,
            string expectedRow23,
            string expectedRow24)
        {
            // Arrange
            var guids = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var scopes = new[] { SPFeatureScope.Site, SPFeatureScope.Site, SPFeatureScope.Web, SPFeatureScope.Web };
            var i = 0;
            var k = 0;
            var appDef = new ApplicationDef();
            var xml = new StringBuilder();
            xml.Append("<root>")
                .Append("<Lists>")
                .AppendFormat("<List Name='name' CanUpgrade='{0}' Reporting='true' Template='template' ", canUpgrade)
                .Append(hasNoDelete ? "NoDelete=''" :string.Empty)
                .Append(" />")                
                .Append("</Lists>")
                .Append("</root>");
            appDef.ApplicationXml.LoadXml(xml.ToString());
            
            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);
            _privateObject.SetFieldOrProperty(ListItemProp, new ShimSPListItem().Instance);

            ShimSPListCollection.AllInstances.TryGetListString = (a, b) => isListExist ? new ShimSPList() : null;

            // Act
            _privateObject.Invoke(iInstallListsMethod);
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(rowCount, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectedRow13, dtMessages.Rows[1][3]);
            Assert.AreEqual(expectedRow14, dtMessages.Rows[1][4]);
            if (rowCount > 2)
            {
                Assert.AreEqual(expectedRow23, dtMessages.Rows[2][3]);
                Assert.AreEqual(expectedRow24, dtMessages.Rows[2][4]);
            }
        }
    }
}