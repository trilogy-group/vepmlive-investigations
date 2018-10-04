using System.Data;
using System.Xml;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    public partial class ApplicationInstallerTests
    {
        private const string InstallListsFieldsMethod = "InstallListsFields";

        [TestMethod]
        public void InstallListsFields_When_Field_New()
        {
            InstallListsFieldsCommon(false, true, true, "BOOLEAN", "Updating Fields", "internalName", string.Empty);
        }

        [TestMethod]
        public void InstallListsFields_When_Field_New_And_Verify()
        {
            InstallListsFieldsCommon(true, true, true, "BOOLEAN", "Checking Fields", "internalName", string.Empty);
        }

        [TestMethod]
        public void InstallListsFields_When_Field_Exist()
        {
            InstallListsFieldsCommon(false, true, false, "BOOLEAN", "Updating Fields", "internalName", "Field updated");
        }

        [TestMethod]
        public void InstallListsFields_When_Field_Exist_And_Verify()
        {
            InstallListsFieldsCommon(true, true, false, "BOOLEAN", "Checking Fields", "internalName", "Field exists and will overwrite");
        }

        [TestMethod]
        public void InstallListsFields_When_Field_Exist_And_Type_Mismatch()
        {
            InstallListsFieldsCommon(false, true, false, string.Empty, "Updating Fields", "internalName", "Field type mistmatch");
        }

        [TestMethod]
        public void InstallListsFields_When_Field_Exist_And_Cannot_OverWrite()
        {
            InstallListsFieldsCommon(true, false, false, "BOOLEAN", "Checking Fields", "internalName", "Field exists and cannot overwrite");
        }

        private void InstallListsFieldsCommon(
            bool verifyOnly,
            bool overWrite,
            bool newField,
            string typeAsString,
            string expectedRow03,
            string expectedRow13,
            string expectedRow14)
        {
            // Arrange
            var appDef = new ApplicationDef();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml($"<root><Fields><Field InternalName='internalName' Overwrite='{overWrite}' Total='total'><Field Type='Boolean' DisplayName='displayName'><CHOICES><CHOICE/></CHOICES></Field></Field></Fields></root>");
            var ndList = xmlDoc.FirstChild;

            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);

            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => newField ? null : new ShimSPFieldChoice();
            ShimSPField.AllInstances.TypeAsStringGet = _ => typeAsString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;

            // Act
            _privateObject.Invoke(InstallListsFieldsMethod, new object[] { new ShimSPList().Instance, ndList, 0});
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