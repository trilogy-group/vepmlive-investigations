using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.ReportHelper
{
    public partial class EPMDataTest
    {
        private IDisposable _shimContext;
        //private PrivateObject _privateObject;

        [TestInitialize]
        public void Initialize()
        {
            _shimContext = ShimsContext.Create();
            SetupShims();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimEPMData.AllInstances.PopulateInstanceFromData = _ => { };
            ShimEPMData.AllInstances.PopulateConnectionStrings = _ => { };
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimCoreFunctions.getConnectionStringGuid = guid => DummyString;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSqlConnection.ConstructorString = (_, conn) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Closed;

        }

        [TestMethod]
        public void Constrcutor_BoolGuidGuid_ShouldCreateInstance()
        {
            // Arrange
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ServerRelativeUrlGet = () => DummyUrl,
                NameGet = () => DummyName,
                IDGet = () => DummyGuid
            };
            _privateObject.SetFieldOrProperty("_epmLiveConOpen", true);

            // Act
            var instance = new EPMData(true, Guid.NewGuid(), Guid.NewGuid());

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull(),
                () => instance.SiteUrl.ShouldBe(DummyUrl),
                () => instance.SiteName.ShouldBe(DummyName));
        }

        [TestMethod]
        public void Constructor_GuidGuid_ShouldCreateInstance()
        {
            // Arrange
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb
            {
                ServerRelativeUrlGet = () => DummyUrl,
                NameGet = () => DummyName,
                IDGet = () => DummyGuid
            };

            // Act
            var instance = new EPMData(DummyGuid, DummyGuid);

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull(),
                () => instance.SiteUrl.ShouldBe(DummyUrl),
                () => instance.SiteName.ShouldBe(DummyName));
        }

        [TestMethod]
        public void Constructor_GuidGuidBool_ShoudCreateInstance()
        {
            // Arrange, Act
            var instance = new EPMData(DummyGuid, DummyGuid, true);

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull());
        }

        [TestMethod]
        public void Constrcutor_dfsdfds_ShouldCreateInstance()
        {
            // Arrange
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb
            {
                IDGet = () => DummyGuid
            };

            // Act
            var instance = new EPMData(DummyGuid, DummyName, DummyName, true, DummyName, DummyName);

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull(),
                () => instance.UserName.ShouldBe(DummyName),
                () => instance.Password.ShouldBe(DummyName));
        }


    }
}
