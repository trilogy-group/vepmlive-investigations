using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.API;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using EPMLiveCore.Fakes;
using System.Data.SqlClient.Fakes;
using Microsoft.SharePoint;
using System.Data.SqlClient;

namespace EPMLiveCore.Tests.API.CreateWorkspace
{
    [TestClass]
    public class DALTests
    {
        private readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private IDisposable shimContext;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
        }

        private void SetupShims()
        {
            ShimSPPersistedObject.AllInstances.IdGet = _ => DummyGuid;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimCoreFunctions.getConnectionStringGuid = guid => DummyString;
            ShimSqlConnection.ConstructorString = (_, connectionString) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => 1;

            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb
            {

            };

            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication
            {

            };

        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        [TestMethod]
        public void IsFirstAttempt_ExecuteScalarReturns0_ReturnsTrue()
        {
            // Arrange
            var site = new ShimSPSite
            {
                IDGet = () => DummyGuid,
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            var web = new ShimSPWeb
            {
                IDGet = () => DummyGuid
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => 0;

            // Act
            var result = WorkspaceData.IsFirstAttempt(site, web, DummyString, DummyString);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstAttempt_ExecuteScalarReturns1_ReturnsFalse()
        {
            // Arrange
            var site = new ShimSPSite
            {
                IDGet = () => DummyGuid,
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            var web = new ShimSPWeb
            {
                IDGet = () => DummyGuid
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => 1;

            // Act
            var result = WorkspaceData.IsFirstAttempt(site, web, DummyString, DummyString);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SendCompletedSignalsToDB_Should_ExecuteCorrectly()
        {
            // Arrange
            var executeNonQuery = false;
            var web = new ShimSPWeb
            {
                IDGet = () => DummyGuid,
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                executeNonQuery = true;
                return 1;
            };

            // Act
            WorkspaceData.SendCompletedSignalsToDB(DummyGuid, web, web, DummyGuid, 1, DummyGuid, DummyString, DummyString, DummyString, DummyString);

            // Assert
            Assert.IsTrue(executeNonQuery);
        }

        [TestMethod]
        public void SendCompletedSignalsToDB_____Should_ExecuteCorrectly()
        {
            // Arrange
            var executeNonQuery = false;
            var web = new ShimSPWeb
            {
                IDGet = () => DummyGuid,
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                executeNonQuery = true;
                return 1;
            };

            // Act
            WorkspaceData.SendCompletedSignalsToDB(DummyGuid, web, DummyGuid, DummyString, DummyString, DummyString, DummyString);

            // Assert
            Assert.IsTrue(executeNonQuery);
        }

        [TestMethod]
        public void AddToFRF()
        {
            // Arrange
            var executeNonQuery = false;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                executeNonQuery = true;
                return 1;
            };

            // Act
            WorkspaceData.AddToFRF(DummyGuid, DummyGuid, DummyString, DummyString, 1, 1);

            // Assert
            Assert.IsTrue(executeNonQuery);
        }


        [TestMethod]
        public void AddToFRF_()
        {
            // Arrange
            var executeNonQuery = false;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                executeNonQuery = true;
                return 1;
            };

            // Act
            WorkspaceData.AddToFRF(DummyGuid, DummyGuid, DummyString, DummyString, 1, 1, DummyGuid, 1);

            // Assert
            Assert.IsTrue(executeNonQuery);
        }

        [TestMethod]
        public void DoesWorkspaceExist_ItemExists_ReturnsTrue()
        {
            // Arrange
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetInt32 = index => bool.TrueString
            };

            // Act
            var result = WorkspaceData.DoesWorkspaceExist(DummyGuid, DummyGuid, DummyGuid, 1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetWorkspaceStatus()
        {
            // Arrange
            const string ExpectedStatus = "Ready";
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 2,
                ItemGetInt32 = index => count == 2 ? "2" : "1"
            };

            // Act
            var result = WorkspaceData.GetWorkspaceStatus(DummyGuid, DummyGuid, DummyGuid, 1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ExpectedStatus, result);

        }



    }
}
