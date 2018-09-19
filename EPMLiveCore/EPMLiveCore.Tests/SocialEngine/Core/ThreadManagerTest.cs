using System;
using System.Collections.Generic;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EPMLive.TestFakes;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Core.Fakes;
using EPMLiveCore.SocialEngine.Entities;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.SocialEngine.Core
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ThreadManagerTest
    {
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private readonly Guid DummyGuid = Guid.NewGuid();
        private bool _executeNonQueryInvoked;

        private PrivateObject PrivateObject { get; set; }
        private PrivateType PrivateType { get; set; }
        private ThreadManager TestEntity { get; set; }
        private IDisposable ShimObject { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            ShimObject = ShimsContext.Create();
            TestEntity = new ThreadManager(new ShimDBConnectionManager());
            ShimDBConnectionManager.AllInstances.SqlConnectionGet = _=> new ShimSqlConnection();
            PrivateObject = new PrivateObject(TestEntity);
            PrivateType = new PrivateType(typeof(ThreadManager));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ShimObject?.Dispose();
        }

        [TestMethod]
        public void AssociateStreams_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();

            // Act
            TestEntity.AssociateStreams(new Thread(), new[] {Guid.NewGuid()});

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void CleanupCommenters_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();
            ShimDataTable.AllInstances.LoadIDataReader = (dt, _) =>
            {
                dt.Columns.Add("UserId", typeof(int));
                dt.Columns.Add("Role", typeof(string));
                dt.Rows.Add(DummyInt, UserRole.Commenter.ToString());
                dt.Rows.Add(2, UserRole.Commenter.ToString());
            };

            // Act
            TestEntity.CleanupCommenters(new Thread(), new List<int> {DummyInt});

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteThread_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();

            // Act
            TestEntity.DeleteThread(new Thread());

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteThreads_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();

            // Act
            TestEntity.DeleteThreads(new List<Guid> {Guid.NewGuid()});

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }
        
        [TestMethod]
        public void GetThread_OnValidCall_ReturnThread()
        {
            // Arrange
            SetupGetThread();

            // Act
            var actualResult = TestEntity.GetThread(Guid.NewGuid(), new[] {DummyString}, true);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Title.ShouldContain(DummyString),
                () => actualResult.Kind.ShouldBe(ObjectKind.List));
        }

        [TestMethod]
        public void GetThread_OnPassingListId_ReturnThread()
        {
            // Arrange
            SetupGetThread();

            // Act
            var actualResult = TestEntity.GetThread(Guid.NewGuid(), Guid.NewGuid(), new[] {DummyString});

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Title.ShouldContain(DummyString),
                () => actualResult.Kind.ShouldBe(ObjectKind.List));
        }

        [TestMethod]
        public void GetThread_OnPassingItemId_ReturnThread()
        {
            // Arrange
            SetupGetThread();

            // Act
            var actualResult = TestEntity.GetThread(Guid.NewGuid(), Guid.NewGuid(), DummyInt, new[] { DummyString });

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Title.ShouldContain(DummyString),
                () => actualResult.Kind.ShouldBe(ObjectKind.List));
        }

        [TestMethod]
        public void GetThreadIds_OnValidCall_ReturnGuid()
        {
            // Arrange
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => DummyGuid;

            // Act
            var actualResult = TestEntity.GetThreadIds(Guid.NewGuid()).ToList();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeEmpty(),
                () => actualResult[0].ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void GetThreadIds_OnPassingListId_ReturnGuid()
        {
            // Arrange
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => DummyGuid;

            // Act
            var actualResult = TestEntity.GetThreadIds(Guid.NewGuid(), Guid.NewGuid()).ToList();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeEmpty(),
                () => actualResult[0].ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void GetThreadIds_OnPassingItemId_ReturnGuid()
        {
            // Arrange
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => DummyGuid;

            // Act
            var actualResult = TestEntity.GetThreadIds(Guid.NewGuid(), Guid.NewGuid(), DummyInt).ToList();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeEmpty(),
                () => actualResult[0].ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void GetThreadIds_OnPassingObjectKind_ReturnGuid()
        {
            // Arrange
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => DummyGuid;

            // Act
            var actualResult = TestEntity.GetThreadIds(Guid.NewGuid(), Guid.NewGuid(), DummyInt, ObjectKind.List).ToList();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeEmpty(),
                () => actualResult[0].ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void RemoveUserRoles_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => UserRole.Assignee | UserRole.Author;

            // Act
            TestEntity.RemoveUserRoles(Guid.NewGuid(), new Dictionary<int, UserRole>
            {
                {DummyInt, UserRole.Assignee}
            });

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void SaveThread_OnCreate_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();

            // Act
            TestEntity.SaveThread(new Thread {Id = Guid.Empty});

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void SaveThread_OnUpdate_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();

            // Act
            TestEntity.SaveThread(new Thread {Id = Guid.NewGuid(), Url = DummyString});

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateAssociatedThreads_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();

            // Act
            TestEntity.UpdateAssociatedThreads(Guid.NewGuid(), new Dictionary<Guid, int> {{Guid.NewGuid(), DummyInt}});

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateCommenters_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => UserRole.Assignee;

            // Act
            TestEntity.UpdateCommenters(new Thread
            {
                Users = new[]
                {
                    new User {Id = DummyInt, Role = UserRole.Commenter},
                    new User {Id = DummyInt, Role = UserRole.Assignee}
                }
            });

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateUsers_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            SetupShimsForSqlClient();
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => UserRole.Assignee;
            ShimDataTable.AllInstances.LoadIDataReader = (dt, _) =>
            {
                dt.Columns.Add("UserId", typeof(int));
                dt.Columns.Add("Role", typeof(string));
                dt.Rows.Add(3, UserRole.Assignee.ToString());
                dt.Rows.Add(2, UserRole.Commenter.ToString());
                dt.Rows.Add(4, UserRole.Assignee.ToString());
            };

            // Act
            TestEntity.UpdateUsers(new Thread
            {
                Users = new[]
                {
                    new User { Id = DummyInt, Role = UserRole.Assignee },
                    new User { Id = DummyInt, Role = UserRole.Commenter }
                }
            });

            // Assert
            _executeNonQueryInvoked.ShouldBeTrue();
        }

        private void SetupGetThread()
        {
            // Arrange
            SetupShimsForSqlClient();
            ShimDataTable.AllInstances.LoadIDataReader = (dt, _) =>
            {
                dt.Columns.Add("Id", typeof(Guid));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("URL", typeof(string));
                dt.Columns.Add("Kind", typeof(ObjectKind));
                dt.Columns.Add("LastActivityDateTime", typeof(DateTime));
                dt.Columns.Add("FirstActivityDateTime", typeof(DateTime));
                dt.Columns.Add("WebId", typeof(Guid));
                dt.Columns.Add("ListId", typeof(Guid));
                dt.Columns.Add("ItemId", typeof(int));
                dt.Columns.Add("Deleted", typeof(int));
                dt.Rows.Add(Guid.NewGuid(), DummyString, DummyString, ObjectKind.List, DateTime.Now, DateTime.Now, Guid.NewGuid(), Guid.NewGuid(),
                    DummyInt, DummyInt);
            };
        }

        private void SetupShimsForSqlClient()
        {
            var readCount = 0;
            _executeNonQueryInvoked = false;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader()
                {
                    Read = () =>
                    {
                        if (readCount == 0)
                        {
                            readCount++;
                            return true;
                        }
                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => new ShimSqlCommand();
            ShimSqlDataReader.AllInstances.NextResult = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => DummyInt;
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, __) => DateTime.Now;
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (_, __) => true;
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => Guid.NewGuid();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                _executeNonQueryInvoked = true;
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => true;
            ShimSqlDataReader.AllInstances.NextResult = _ =>
            {
                readCount = 0;
                return true;
            };
        }
    }
}
