using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Linq;
using EPMLiveCore.API;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API.CreateWorkspace
{
    [TestClass]
    public class DALTests
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private IDisposable shimContext;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
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
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
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
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SendCompletedSignalsToDBSPWeb_Should_ExecuteCorrectly()
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
            WorkspaceData.SendCompletedSignalsToDB(DummyGuid, web, DummyGuid, DummyString, DummyString, DummyString, DummyString);

            // Assert
            Assert.IsTrue(executeNonQuery);
        }

        [TestMethod]
        public void AddToFRFGuid_Should_ExecuteCorrectly()
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
        public void AddToFRF_Should_ExecuteCorrectly()
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
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetWorkspaceStatus_Should_ReturnExpectedStatus()
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

        [TestMethod]
        public void GetWorkspaceUrl_Should_ReturnExpectedUrl()
        {
            // Arrange
            const string Url = "https://dummy.org/url";
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    GetItemByIdInt32 = id => new ShimSPListItem
                    {
                        ItemGetString = name => Url
                    }
                }
            };

            // Act
            var result = WorkspaceData.GetWorkspaceUrl(DummyGuid, DummyGuid, DummyGuid, 1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Url, result);
        }

        [TestMethod]
        public void GetParentWebId_Should_ReturnExpectedResult()
        {
            // Arrange
            const string Url = "https://dummy.org/url";
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    GetItemByIdInt32 = id => new ShimSPListItem
                    {
                        ItemGetString = name => Url
                    }
                }
            };
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPWeb.AllInstances.IDGet = _ => DummyGuid;
            ShimSPWeb.AllInstances.ExistsGet = _ => true;

            // Act
            var result = WorkspaceData.GetParentWebId(DummyGuid, DummyGuid, DummyGuid, 1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(DummyGuid, result);
        }

        [TestMethod]
        public void AddWsPermission_Should_ExecuteCorrectly()
        {
            // Arrange
            var queryExecuted = false;
            var bulkInserted = false;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                queryExecuted = true;
                return 1;
            };
            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = _ =>
            {
                var list = new List<SPRoleAssignment>
                {
                    new ShimSPRoleAssignment
                    {
                        MemberGet = () => new ShimSPGroup(),
                        RoleDefinitionBindingsGet = () =>
                        {
                            var assignments = new List<SPRoleDefinition>
                            {
                                new ShimSPRoleDefinition
                                {
                                    BasePermissionsGet = () => SPBasePermissions.ViewListItems
                                }
                            }.AsEnumerable();
                            return new ShimSPRoleDefinitionBindingCollection().Bind(assignments);
                        }
                    }
                }.AsEnumerable();
                return new ShimSPRoleAssignmentCollection().Bind(list);
            };
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) =>
            {
                bulkInserted = true;
            };

            // Act
            WorkspaceData.AddWsPermission(DummyGuid, DummyGuid);

            // Assert
            Assert.IsTrue(bulkInserted);
            Assert.IsTrue(queryExecuted);
        }
    }
} 
