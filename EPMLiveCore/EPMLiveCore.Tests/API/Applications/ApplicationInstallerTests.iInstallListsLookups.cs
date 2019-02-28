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
        private const string iInstallListsLookupsMethod = "iInstallListsLookups";

        [TestMethod]
        public void InstallListsLookups_When_Has_ParentList_And_FieldNew_And_Verify()
        {
            InstallListsLookupsCommon(true, true, true, true, true, true, 3, "Checking Lookups", "internalName", string.Empty, "Enabled Advanced Lookup");
        }

        [TestMethod]
        public void InstallListsLookups_When_Has_ParentList_And_FieldNew()
        {
            InstallListsLookupsCommon(false, true, true, true, true, true, 3, "Fixing Lookups", "internalName", "Field added", "Enabled Advanced Lookup");
        }


        [TestMethod]
        public void InstallListsLookups_When_Has_ParentList_And_FieldExist_And_Verify1()
        {
            InstallListsLookupsCommon(true, true, true, false, true, true, 3, "Checking Lookups", "internalName", "Field exists and will overwrite", "Enabled Advanced Lookup");
        }

        [TestMethod]
        public void InstallListsLookups_When_Has_ParentList_And_FieldExist_And_Verify2()
        {
            InstallListsLookupsCommon(true, false, true, false, true, true, 3, "Checking Lookups", "internalName", "Field exists and will not overwrite", "Enabled Advanced Lookup");
        }

        [TestMethod]
        public void InstallListsLookups_When_Has_ParentList_And_FieldExist_And_Not_OverWrite()
        {
            InstallListsLookupsCommon(false, false, true, false, true, true, 3, "Fixing Lookups", "internalName", "Field exists and will not overwrite", "Enabled Advanced Lookup");
        }

        [TestMethod]
        public void InstallListsLookups_When_Has_ParentList_And_FieldExist()
        {
            InstallListsLookupsCommon(false, true, true, false, true, true, 3, "Fixing Lookups", "internalName", "Field updated", "Enabled Advanced Lookup");
        }

        [TestMethod]
        public void InstallListsLookups_When_Has_ParentList_And_FieldExist_Not_Lookup()
        {
            InstallListsLookupsCommon(false, true, true, false, true, false, 3, "Fixing Lookups", "internalName", "Field exists and is not currently a lookup field", "Enabled Advanced Lookup");
        }

        [TestMethod]
        public void InstallListsLookups_When_FieldNew_And_Verify_And_DeleteIfNoList()
        {
            InstallListsLookupsCommon(true, true, false, true, true, true, 2, "Checking Lookups", "internalName", "Lookup List missing () field will be deleted", "Enabled Advanced Lookup");
        }

        [TestMethod]
        public void InstallListsLookups_When_FieldNew_And_Verify()
        {
            InstallListsLookupsCommon(true, true, false, true, false, true, 2, "Checking Lookups", "internalName", "Lookup List missing () field ignored", "Enabled Advanced Lookup");
        }

        [TestMethod]
        public void InstallListsLookups_When_FieldExist()
        {
            InstallListsLookupsCommon(false, true, false, false, true, true, 2, "Fixing Lookups", "internalName", "Lookup List missing () field deleted", "Enabled Advanced Lookup");
        }

        [TestMethod]
        public void InstallListsLookups_When_FieldNew()
        {
            InstallListsLookupsCommon(false, true, false, true, true, true, 2, "Fixing Lookups", "internalName", "Lookup List missing () field ignored", "Enabled Advanced Lookup");
        }

        private void InstallListsLookupsCommon(
            bool verifyOnly,
            bool overWrite,
            bool hasParentList,
            bool newField,
            bool deleteIfNoList,
            bool isLookUp,
            int expectedRowCount,
            string expectedRow03,
            string expectedRow13,
            string expectedRow14,
            string expectedRow23)
        {
            // Arrange
            var firstCall = true;
            var appDef = new ApplicationDef();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml($"<root><Lookups><Lookup InternalName='internalName' Overwrite='{overWrite}' DisplayName='displayName' AdvancedLookup='advancedLookup' DeleteIfNoList='{deleteIfNoList}'/></Lookups></root>");
            var ndList = xmlDoc.FirstChild;

            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);

            ShimSPListCollection.AllInstances.TryGetListString = (_, __) => hasParentList ? new ShimSPList() : null;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) =>
            {
                if (!firstCall)
                {
                    return new ShimSPFieldLookup();
                }

                firstCall = false;
                return newField ? null : new ShimSPFieldLookup();
            };
            ShimSPField.AllInstances.TypeGet = _ => isLookUp ? SPFieldType.Lookup : SPFieldType.Invalid;
            ShimSPField.AllInstances.SchemaXmlGet = _ => @"
<root List='' ShowField= ''>
</root>";

            // Act
            _privateObject.Invoke(iInstallListsLookupsMethod, new object[] { new ShimSPList().Instance, ndList, 0 });
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(expectedRowCount, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectedRow13, dtMessages.Rows[1][3]);
            Assert.AreEqual(expectedRow14, dtMessages.Rows[1][4]);
            if (expectedRowCount > 2)
            {
                Assert.AreEqual(expectedRow23, dtMessages.Rows[2][3]);
            }
        }
    }
}