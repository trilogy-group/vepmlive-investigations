using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Linq;
using EPMLive.TestFakes.Utility;
using EPMLiveReportsAdmin;
using EPMLiveReportsAdmin.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveReporting.Tests
{
    [TestClass]
    public class ProcessSecurityTests
    {
        private ProcessSecurity _testEntity;
        private PrivateObject _testEntityPrivate;
        private PrivateType _testEntityPrivateType;
        private IDisposable _shimsContext;
        private AdoShims _adoShims;
        private SharepointShims _spShims;

        [TestInitialize]
        public void TestInitialize()
        {
            _testEntity = new ProcessSecurity();
            _testEntityPrivate = new PrivateObject(_testEntity);
            _testEntityPrivateType = new PrivateType(typeof(ProcessSecurity));
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _spShims = SharepointShims.ShimSharepointCalls();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void ProcessSecurityGroups_WhenSecurityTablesExistAndUsersStringIsEmpty_CreatesExecutesAndDisposesSqlCommand()
        {
            // Arrange
            const string expectedCommandText = "DELETE FROM RPTGROUPUSER where SITEID=@siteid";
            ShimProcessSecurity.SecurityTablesExistSqlConnection = _ => true;
            SetupProcessSecurityGroupsShims();

            // Act
            ProcessSecurity.ProcessSecurityGroups(_spShims.SiteShim.Instance, _adoShims.ConnectionShim.Instance, string.Empty);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.IsCommandCreated(expectedCommandText).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(expectedCommandText).ShouldBeTrue());
        }

        [TestMethod]
        public void ProcessSecurityGroups_WhenSecurityTablesExistAndUsersStringIsNotEmpty_CreatesExecutesAndDisposesSqlCommand()
        {
            // Arrange
            const string expectedCommandText = "DELETE FROM RPTGROUPUSER where SITEID=@siteid and userid=@userid";
            ShimProcessSecurity.SecurityTablesExistSqlConnection = _ => true;
            SetupProcessSecurityGroupsShims();
            const string users = "1,2";

            // Act
            ProcessSecurity.ProcessSecurityGroups(_spShims.SiteShim.Instance, _adoShims.ConnectionShim.Instance, users);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.IsCommandCreated(expectedCommandText).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(expectedCommandText).ShouldBeTrue(),
                () => _adoShims.CommandsExecuted.Count(cmd => cmd.CommandText.Equals(expectedCommandText)).ShouldBe(2));
        }

        [TestMethod]
        public void SecurityTableExists_WhenExceptionOccursWhileExecutingSqlCommand_ReturnsFalse()
        {
            // Arrange
            const string expectedCommandText =
                "IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND  TABLE_NAME = 'RPTGROUPUSER')) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END";
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => { throw new InvalidOperationException(); };

            // Act
            var result = _testEntityPrivateType.InvokeStatic("SecurityTablesExist", _adoShims.ConnectionShim.Instance) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(false),
                () => _adoShims.IsCommandCreated(expectedCommandText).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText).ShouldBeFalse(),
                () => _adoShims.IsCommandDisposed(expectedCommandText).ShouldBeTrue());
        }

        [TestMethod]
        public void SecurityTableExists_WhenExceptionNotOccursWhileExecutingSqlCommand_ReturnsTrue()
        {
            // Arrange
            const string expectedCommandText =
                "IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND  TABLE_NAME = 'RPTGROUPUSER')) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END";

            // Act
            var result = _testEntityPrivateType.InvokeStatic("SecurityTablesExist", _adoShims.ConnectionShim.Instance) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(true),
                () => _adoShims.IsCommandCreated(expectedCommandText).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(expectedCommandText).ShouldBeTrue());
        }

        private void SetupProcessSecurityGroupsShims()
        {
            var groupList = new List<SPGroup>();
            var shimSpGroupCollection = new ShimSPGroupCollection();
            var shimSpBaseGroupCollection = new ShimSPBaseCollection(shimSpGroupCollection.Instance)
            {
                GetEnumerator = () => groupList.GetEnumerator()
            };

            var userList = new List<SPUser>();
            var shimSpUserCollection = new ShimSPUserCollection()
            {
                GetByIDInt32 = userId => new ShimSPUser()
                {
                    IDGet = () => userId,
                    GroupsGet = () => shimSpGroupCollection.Instance
                }
            };
            var shimSpBaseUserCollection = new ShimSPBaseCollection(shimSpUserCollection.Instance)
            {
                GetEnumerator = () => userList.GetEnumerator()
            };

            var shimRootWeb = new ShimSPWeb(_spShims.SiteShim.Instance.RootWeb)
            {
                SiteGroupsGet = () => shimSpGroupCollection.Instance,
                SiteUsersGet = () => shimSpUserCollection.Instance
            };

            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_1, _2) => { };
        }
    }
}
