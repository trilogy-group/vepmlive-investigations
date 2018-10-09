using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{

    public partial class ApplicationInstallerTests
    {
        private const string iInstallFeaturesMethod = "InstallFeatures";

        [TestMethod]
        public void InstallFeatures_When_Checking()
        {
            iInstallFeaturesCommon(true, "Checking Features", "dsplayName1", "dsplayName2", "dsplayName3", "dsplayName4", "name5");
        }

        [TestMethod]
        public void InstallFeatures_When_Installing()
        {
            iInstallFeaturesCommon(false, "Installing Features", "dsplayName1", "dsplayName2", "dsplayName3", "dsplayName4", "name5");
        }

        private void iInstallFeaturesCommon(
            bool verifyOnly,
            string expectedRow03,
            string expectedRow13,
            string expectedRow23,
            string expectedRow33,
            string expectedRow43,
            string expectedRow53)
        {
            // Arrange
            var guids = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var scopes = new[] { SPFeatureScope.Site, SPFeatureScope.Site, SPFeatureScope.Web, SPFeatureScope.Web };
            var i = 0;
            var k = 0;
            var appDef = new ApplicationDef();
            var xml = new StringBuilder();
            xml.Append("<root>")
                .Append("<Features>")
                .AppendFormat("<Feature ID='{0}' Name='name1' IncludedInSolutions='{1}'/>", guids[0], true)
                .AppendFormat("<Feature ID='{0}' Name='name2' IncludedInSolutions='{1}'/>", guids[1], true)
                .AppendFormat("<Feature ID='{0}' Name='name3' IncludedInSolutions='{1}'/>", guids[2], true)
                .AppendFormat("<Feature ID='{0}' Name='name4' IncludedInSolutions='{1}'/>", guids[3], true)
                .AppendFormat("<Feature ID='{0}' Name='name5' IncludedInSolutions='{1}'/>", Guid.NewGuid(), true)
                .Append("</Features>")
                .Append("</root>");
            appDef.ApplicationXml.LoadXml(xml.ToString());
            
            _privateObject.SetFieldOrProperty(OWebProp, new ShimSPWeb().Instance);
            _privateObject.SetFieldOrProperty(AppDefProp, appDef);
            _privateObject.SetFieldOrProperty(VerifyOnlyProp, verifyOnly);
            _privateObject.SetFieldOrProperty(ListItemProp, new ShimSPListItem().Instance);

            ShimSPPersistedObjectCollection<SPFeatureDefinition>.AllInstances.GetEnumerator = _ =>
            {
                var list = new List<SPFeatureDefinition>
                {
                    new ShimSPFeatureDefinition
                    {
                        CompatibilityLevelGet = () => 14,
                        ScopeGet = () => scopes[k++],
                        IdGet = () => guids[i++],
                        DisplayNameGet =() => $"dsplayName{k}"
                    }.Instance,

                    new ShimSPFeatureDefinition
                    {
                        CompatibilityLevelGet = () => 15,
                        ScopeGet = () => scopes[k++],
                        IdGet = () => guids[i++],
                        DisplayNameGet =() => $"dsplayName{k}"
                    }.Instance
                };

                return list.GetEnumerator();
            };

            // Act
            _privateObject.Invoke(iInstallFeaturesMethod);
            var dtMessages = _privateObject.GetFieldOrProperty(DTMessagesProp) as DataTable;

            // Assert
            Assert.IsNotNull(dtMessages);
            Assert.AreEqual(6, dtMessages.Rows.Count);
            Assert.AreEqual(expectedRow03, dtMessages.Rows[0][3]);
            Assert.AreEqual(expectedRow13, dtMessages.Rows[1][3]);
            Assert.AreEqual(expectedRow23, dtMessages.Rows[2][3]);
            Assert.AreEqual(expectedRow33, dtMessages.Rows[3][3]);
            Assert.AreEqual(expectedRow43, dtMessages.Rows[4][3]);
            Assert.AreEqual(expectedRow53, dtMessages.Rows[5][3]);
        }
    }
}