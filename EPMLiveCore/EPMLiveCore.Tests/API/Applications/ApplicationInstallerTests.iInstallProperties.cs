using System.Collections.Specialized.Fakes;
using System.Data;
using System.Text;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.API
{
    public partial class ApplicationInstallerTests
    {
        private const string InstallPropertiesMethod = "iInstallProperties";
        private const string AppDefProp = "appDef";
        private const string OWebProp = "oWeb";
        private const string VerifyOnlyProp = "bVerifyOnly";
        private const string ListItemProp = "oListItem";
        private const string DTMessagesProp = "_dtMessages";

        [TestMethod]
        public void InstallProperties_When_Append()
        {
            InstallPropertiesCommon(false, true, true, "value\0", true, "Installing Properties", "name", "Property found and will append");
        }

        [TestMethod]
        public void InstallProperties_When_Append_And_Verify()
        {
            InstallPropertiesCommon(true, true, true, "value\0", true, "Checking Properties", "name", "Property found and will append");
        }

        [TestMethod]
        public void InstallProperties_When_Not_Found()
        {
            InstallPropertiesCommon(false, true, true, string.Empty, true, "Installing Properties", "name", string.Empty);
        }

        [TestMethod]
        public void InstallProperties_When_Append_And_Not_Overwrite()
        {
            InstallPropertiesCommon(true, true, false, "value\0", true, "Checking Properties", "name", "Cannot append value, value already exists");
        }

        [TestMethod]
        public void InstallProperties_When_Not_Contains()
        {
            InstallPropertiesCommon(true, true, false, "value\0", false, "Checking Properties", "name", string.Empty);
        }

        [TestMethod]
        public void InstallProperties_When_Not_Append()
        {
            InstallPropertiesCommon(false, false, true, "value\0", true, "Installing Properties", "name", string.Empty);
        }

        [TestMethod]
        public void InstallProperties_When_Not_Append_And_Verify()
        {
            InstallPropertiesCommon(true, false, true, "value\0", true, "Checking Properties", "name", "Property already exists and will overwrite");
        }

        [TestMethod]
        public void InstallProperties_When_Not_Append_And_Verify_And_Not_Contains()
        {
            InstallPropertiesCommon(true, false, true, "value\0", false, "Checking Properties", "name", string.Empty);
        }

        [TestMethod]
        public void InstallProperties_When_Not_Append_Not_OverWrite()
        {
            InstallPropertiesCommon(true, false, false, "value\0", true, "Checking Properties", "name", "Property already exists and cannot overwrite");
        }

        [TestMethod]
        public void InstallProperties_When_Not_Append_Not_OverWrite_Not_Contains()
        {
            InstallPropertiesCommon(true, false, false, "value\0", false, "Checking Properties", "name", string.Empty);
        }

        private void InstallPropertiesCommon(
            bool verifyOnly, 
            bool append, 
            bool overWrite, 
            string values, 
            bool containsKey,
            string expectedRow03,
            string expectdRow13,
            string expectedRow14)
        {
            // Arrange
            var appDef = new ApplicationDef();
            var xml = new StringBuilder();
            xml.Append("<root>")
                .Append("<Web>")
                .Append("<Properties>")
                .AppendFormat("<Property Name='name' Value='value' Append='{0}' Overwrite='{1}' LockWebProperty='false' Seperator='\\0' DuplicateRegEx=''>", append, overWrite)
                .Append("</Property>")
                .Append("</Properties>")
                .Append("</Web>")
                .Append("</root>");
            appDef.ApplicationXml.LoadXml(xml.ToString());
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);
            _privateObject.SetFieldOrProperty(ListItemProp, new ShimSPListItem().Instance);

            ShimCoreFunctions.getConfigSettingSPWebString = (a, b) => values;
            ShimStringDictionary.AllInstances.ContainsKeyString = (a, b) => containsKey;

            // Act
            _privateObject.Invoke(InstallPropertiesMethod);
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(2, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectdRow13, dtMessages.Rows[1][3]);
            Assert.AreEqual(expectedRow14, dtMessages.Rows[1][4]);
        }
    }
}