using System.Data;
using System.Text;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.Jobs.Applications.Fakes;
using EPMLiveCore.WorkEngineSolutionStoreListSvc.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    public partial class ApplicationInstallerTests
    {
        private const string CheckPermissionsMethod = "CheckPermissions";
        private const string IsInstalledElsewhereProp = "bIsInstalledElsewhere";
        private const string ConfigJobProp = "_configJob";
        
        [TestMethod]
        public void CheckPermissions_WhenIsInstalledElsewhere_And_HasPermission()
        {
            CheckPermissionsCommon(true, true, true, true, true, true, true, "Permissions Check", string.Empty);
        }

        [TestMethod]
        public void CheckPermissions_WhenIsInstalledElsewhere()
        {
            CheckPermissionsCommon(true, true, true, false, true, true, false, "Permissions Check", "You do not have Manage Web permissions");
        }

        [TestMethod]
        public void CheckPermissions_When_HasSolutions_And_IsSiteAdmin()
        {
            CheckPermissionsCommon(true, true, false, true, true, true, true, "Permissions Check", string.Empty);
        }

        [TestMethod]
        public void CheckPermissions_When_HasSolutions()
        {
            CheckPermissionsCommon(true, true, false, true, true, false, false, "Permissions Check", "You are not a site collection administrator");
        }

        [TestMethod]
        public void CheckPermissions_When_HasPermissions()
        {
            CheckPermissionsCommon(true, true, false, true, false, true, true, "Permissions Check", string.Empty);
        }

        [TestMethod]
        public void CheckPermissions()
        {
            CheckPermissionsCommon(true, true, false, false, false, false, false, "Permissions Check", "You do not have Manage Web permissions");
        }

        private void CheckPermissionsCommon(
            bool verifyOnly,
            bool overWrite,
            bool isInstalledElsewhere,
            bool hasPermissions,
            bool hasSolutions,
            bool isSiteAdmin,
            bool expected,
            string expectedRow03,
            string expectedRow04)
        {
            // Arrange
            var appDef = new ApplicationDef();
            var xml = new StringBuilder();
            xml.Append("<root>")
                .Append("<Solutions>")
                .Append(hasSolutions ? "<Solution/>" : string.Empty)
                .Append("</Solutions>")
                .Append("</root>");
            appDef.ApplicationXml.LoadXml(xml.ToString());
            
            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);
            _privateObject.SetFieldOrProperty(ListItemProp, new ShimSPListItem().Instance);
            _privateObject.SetFieldOrProperty(IsInstalledElsewhereProp, isInstalledElsewhere);
            _privateObject.SetFieldOrProperty(ConfigJobProp, new ShimInstallAndConfigure().Instance);
            
            xml.Clear();
            xml.Append("<root>")
                .Append("<rs:data xmlns:rs='http://www.w3.org/TR/html4/' ItemCount='1'>")
                .Append("<z:row xmlns:z='http://www.w3.org/TR/html4/' ows_FSObjType='ows_FSObjType' ows_FileRef='ows_FileRef' ows_FileLeafRef='ows_FileLeafRef' ows_Title='ows_Title'/>")
                .Append("</rs:data>")
                .Append("</root>");
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml.ToString());

            ShimLists.Constructor = _ => { };
            ShimLists.AllInstances.GetListItemsStringStringXmlNodeXmlNodeStringXmlNodeString = (a, b, c, d, e, f, g, h) => xmlDoc.FirstChild;
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions= (a, b) => hasPermissions;
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => isSiteAdmin;

            // Act
            var actual = (bool) _privateObject.Invoke(CheckPermissionsMethod);
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(1, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectedRow04, dtMessages.Rows[0][4]);
        }
    }
}