using System.Data;
using System.Reflection;
using System.Text;
using EPMLiveCore.API;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    public partial class ApplicationInstallerTests
    {
        [TestMethod]
        public void InstallAndConfigureApp_No_Item()
        {
            InstallAndConfigureApp(false, true, 1, true, true, 1, "Open Application Item", "Could not find item in list");
        }

        private void InstallAndConfigureApp(
            bool hasItems,
            bool hasAppList,
            int community,
            bool verifyOnly,
            bool overWrite,
            int rowCount,
            string expectedRow03,
            string expectedRow04)

        {
            // Arrange
            var appDef = new ApplicationDef
            {
                Community = "community",
                Version = "version"
            };
            var xml = new StringBuilder();
            xml.Append("<root>")                
                .Append("</root>");
            appDef.ApplicationXml.LoadXml(xml.ToString());
            
            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);
            _privateObject.SetFieldOrProperty(ListItemProp, new ShimSPListItem().Instance);
            _privateObject.SetFieldOrProperty(AppListProp, hasAppList ? new ShimSPList().Instance : null);

            ShimSPListItem.AllInstances.IDGet = _ => community;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPListItemCollection.AllInstances.CountGet = _ => hasItems ? 1 : 0;
            ShimSPListItemCollection.AllInstances.ItemGetInt32 = (a, b) => new ShimSPListItem();
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions= (a, b) => true;
            ShimSPListItem.AllInstances.ItemGetString = (a, b) => "PreCheck Queued";
            ShimSPListCollection.AllInstances.TryGetListString = (_, __) => new ShimSPList();

            // Act
            _applicationInstaller.InstallAndConfigureApp(verifyOnly, new ShimSPWeb().Instance, 0);
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(rowCount, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectedRow04, dtMessages.Rows[0][4]);
        }
    }
}