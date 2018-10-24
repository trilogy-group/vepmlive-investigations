using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using EPMLiveCore.Fakes;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Core.Fakes;
using EPMLiveCore.SocialEngine.Entities;
using EPMLiveCore.SocialEngine.Entities.Fakes;
using EPMLiveCore.SocialEngine.Events;
using EPMLiveCore.SocialEngine.Modules;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.SocialEngine.Modules
{
    [TestClass]
    public class ListTests
    {
        private List testObj;
        private PrivateObject privateObj;
        private IDisposable shimsContext;
        private SPWeb spWeb;
        private Guid guid;
        private const string ConnectionString = "connectionString";
        private const string Commenters = "1,2";
        private const string IdColumn = "Id";
        private const string KindColumn = "Kind";
        private const string DateColumn = "Date";
        private const string UserIdColumn = "UserId";
        private const string MassOperationColumn = "MassOperation";
        private const string ActivityKeyColumn = "ActivityKey";
        private const string DataColumnName = "Data";
        private const string TitleString = "Title";
        private const string UrlColumn = "URL";
        private const string WebIdColumn = "WebId";
        private const string ListIdColumn = "ListId";
        private const string RoleColumn = "Role";
        private const string ActivityKey = "activityKey";
        private const string ListTitle = "ListTitle";
        private const string SiteIdColumn = "SiteId";
        private const string ActivityTimeColumn = "ActivityTime";
        private const string CommentersColumn = "Commenters";
        private const string IsMassOperation = "IsMassOperation";
        private const string ActivityValue = "#!Activity";
        private const string AssociatedListItems = "AssociatedListItems";
        private const string ThreadValue = "#!Thread";
        private const string TotalActivities = "TotalActivities";
        private ThreadManager threadManager;
        private ActivityManager activityManager;
        private StreamManager streamManager;

        [TestInitialize]
        public void Setup()
        {
            SetUpShims();
            testObj = new List();
            privateObj = new PrivateObject(testObj);
            new PrivateType(typeof(ListItemValidator));
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        private void SetUpShims()
        {
            shimsContext = ShimsContext.Create();
            guid = Guid.NewGuid();
            spWeb = new ShimSPWeb
            {
                IDGet = () => guid,
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => guid,
                    WebApplicationGet = () => new ShimSPWebApplication(),
                    RootWebGet = () => new ShimSPWeb()
                }
            }.Instance;
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimCoreFunctions.getReportingConnectionStringGuidGuid = (_, _1) => ConnectionString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, _1) => string.Empty;
            threadManager = new ThreadManager(new DBConnectionManager(spWeb, false));
            activityManager = new ActivityManager(new DBConnectionManager(spWeb, false));
            streamManager = new StreamManager(new DBConnectionManager(spWeb, false));
        }

        private DataTable CreateActivityTable()
        {
            var activityTable = new DataTable();
            activityTable.Columns.Add(IdColumn, typeof(Guid));
            activityTable.Columns.Add(KindColumn, typeof(ActivityKind));
            activityTable.Columns.Add(DateColumn, typeof(DateTime));
            activityTable.Columns.Add(UserIdColumn, typeof(int));
            activityTable.Columns.Add(MassOperationColumn, typeof(bool));
            activityTable.Columns.Add(ActivityKeyColumn, typeof(string));
            activityTable.Columns.Add(DataColumnName, typeof(object));
            var row = activityTable.NewRow();
            row[IdColumn] = guid;
            row[KindColumn] = ActivityKind.CommentAdded;
            row[DateColumn] = DateTime.Now;
            row[UserIdColumn] = 1;
            row[MassOperationColumn] = true;
            row[ActivityKeyColumn] = ActivityKey;
            row[DataColumnName] = Commenters;
            activityTable.Rows.Add(row);
            return activityTable;
        }

        private Dictionary<string, object> CreateDataObject()
        {
            var data = new Dictionary<string, object>
            {
                [IdColumn] = guid,
                [TitleString] = TitleString,
                [UrlColumn] = "http://sampleurl.com",
                [ListTitle] = ListTitle,
                [ListIdColumn] = guid,
                [WebIdColumn] = guid,
                [SiteIdColumn] = guid,
                [UserIdColumn] = 1,
                [ActivityTimeColumn] = DateTime.Now
            };
            return data;
        }

        [TestMethod]
        public void RegisterCreationActivity_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            const bool updateExpected = true;

            var updateActual = false;
            var dataTableCount = 1;
            var data = CreateDataObject();
            data.Add(CommentersColumn, Commenters);
            data.Add(IsMassOperation, true);
            data.Add(
                ActivityValue,
                new Activity
                {
                    Id = guid
                });
            data.Add(AssociatedListItems, $"{guid.ToString()}|1,{guid.ToString()}|2");
            data.Add(
                ThreadValue,
                new Thread
                {
                    Id = guid
                });

            var userTable = new DataTable();
            userTable.Columns.Add(UserIdColumn, typeof(int));
            userTable.Columns.Add(RoleColumn, typeof(UserRole));
            var row = userTable.NewRow();
            row[UserIdColumn] = 1;
            row[RoleColumn] = UserRole.Commenter;
            userTable.Rows.Add(row);

            ShimSqlCommand.AllInstances.ExecuteScalar = sqlCommand =>
            {
                if (sqlCommand.CommandText.StartsWith("SELECT Id FROM SS_Streams"))
                {
                    return guid;
                }

                if (sqlCommand.CommandText.StartsWith("SELECT TOP (1) Role FROM SS_ThreadUsers"))
                {
                    return UserRole.Commenter;
                }

                return UserRole.Commenter;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand =>
            {
                var reader = new ShimSqlDataReader
                {
                    Close = () => { }
                };
                return reader;
            };

            ShimDataTableExtensions.AsEnumerableDataTable = _ =>
            {
                EnumerableRowCollection<DataRow> result = null;
                ShimsContext.ExecuteWithoutShims(
                    () =>
                    {
                        if (dataTableCount == 1)
                        {
                            dataTableCount++;
                            result = CreateActivityTable().AsEnumerable();
                        }
                        else
                        {
                            dataTableCount++;
                            result = userTable.AsEnumerable();
                        }
                    });
                return result;
            };
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;

            var args = new ProcessActivityEventArgs(
                ObjectKind.List,
                ActivityKind.CommentAdded,
                data,
                spWeb,
                streamManager,
                threadManager,
                activityManager);

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand =>
            {
                if (sqlCommand.CommandText.Contains("INSERT INTO SS_AssociatedThreads") &&
                    sqlCommand.CommandText.Contains("UPDATE SS_AssociatedThreads"))
                {
                    updateActual = true;
                }

                return 1;
            };

            ShimThreadManager.AllInstances.UpdateUsersThread = (manager, thread) => { };
            var activityConstructorCount = 0;
            var activityDisposeCount = 0;

            ShimActivity.Constructor = activity => activityConstructorCount++;
            ShimActivity.AllInstances.Dispose = activity => activityDisposeCount++;

            // Act
            privateObj.Invoke("RegisterCreationActivity", BindingFlags.Instance | BindingFlags.NonPublic, args);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => activityConstructorCount.ShouldBe(1), 
                () => activityDisposeCount.ShouldBe(1));
        }

        [TestMethod]
        public void RegisterBulkOperationActivity_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            var dataTableCount = 1;
            var data = CreateDataObject();
            data.Add(CommentersColumn, Commenters);
            data.Add(IsMassOperation, true);
            data.Add(
                ActivityValue,
                new Activity
                {
                    Id = guid
                });
            data.Add(TotalActivities, null);
            data.Add(AssociatedListItems, $"{guid.ToString()}|1,{guid.ToString()}|2");
            data.Add(
                ThreadValue,
                new Thread
                {
                    Id = guid
                });

            var userTable = new DataTable();
            userTable.Columns.Add(UserIdColumn, typeof(int));
            userTable.Columns.Add(RoleColumn, typeof(UserRole));
            var row = userTable.NewRow();
            row[UserIdColumn] = 1;
            row[RoleColumn] = UserRole.Commenter;
            userTable.Rows.Add(row);

            ShimSqlCommand.AllInstances.ExecuteScalar = sqlCommand =>
            {
                if (sqlCommand.CommandText.StartsWith("SELECT Id FROM SS_Streams"))
                {
                    return guid;
                }

                if (sqlCommand.CommandText.StartsWith("SELECT TOP (1) Role FROM SS_ThreadUsers"))
                {
                    return UserRole.Commenter;
                }

                return UserRole.Commenter;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand =>
            {
                var reader = new ShimSqlDataReader
                {
                    Close = () => { }
                };
                return reader;
            };

            ShimDataTableExtensions.AsEnumerableDataTable = _ =>
            {
                EnumerableRowCollection<DataRow> result = null;
                ShimsContext.ExecuteWithoutShims(
                    () =>
                    {
                        if (dataTableCount == 1)
                        {
                            dataTableCount++;
                            result = CreateActivityTable().AsEnumerable();
                        }
                        else
                        {
                            dataTableCount++;
                            result = userTable.AsEnumerable();
                        }
                    });
                return result;
            };
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;

            var args = new ProcessActivityEventArgs(
                ObjectKind.List,
                ActivityKind.CommentAdded,
                data,
                spWeb,
                streamManager,
                threadManager,
                activityManager);

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand => 1;
            ShimThreadManager.AllInstances.UpdateUsersThread = (manager, thread) => { };
            var activityConstructorCount = 0;
            var activityDisposeCount = 0;

            ShimActivity.Constructor = activity => activityConstructorCount++;
            ShimActivity.AllInstances.Dispose = activity => activityDisposeCount++;

            // Act
            privateObj.Invoke("RegisterBulkOperationActivity", BindingFlags.Instance | BindingFlags.NonPublic, args);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => activityConstructorCount.ShouldBe(1),
                () => activityDisposeCount.ShouldBe(1));
        }

        [TestMethod]
        public void RegisterDeletionActivity_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            var dataTableCount = 1;
            var data = CreateDataObject();
            data.Add(CommentersColumn, Commenters);
            data.Add(IsMassOperation, true);
            data.Add(
                ActivityValue,
                new Activity
                {
                    Id = guid
                });
            data.Add(AssociatedListItems, $"{guid.ToString()}|1,{guid.ToString()}|2");
            data.Add(
                ThreadValue,
                new Thread
                {
                    Id = guid
                });

            var userTable = new DataTable();
            userTable.Columns.Add(UserIdColumn, typeof(int));
            userTable.Columns.Add(RoleColumn, typeof(UserRole));
            var row = userTable.NewRow();
            row[UserIdColumn] = 1;
            row[RoleColumn] = UserRole.Commenter;
            userTable.Rows.Add(row);

            ShimSqlCommand.AllInstances.ExecuteScalar = sqlCommand =>
            {
                if (sqlCommand.CommandText.StartsWith("SELECT Id FROM SS_Streams"))
                {
                    return guid;
                }

                if (sqlCommand.CommandText.StartsWith("SELECT TOP (1) Role FROM SS_ThreadUsers"))
                {
                    return UserRole.Commenter;
                }

                return UserRole.Commenter;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand =>
            {
                var reader = new ShimSqlDataReader
                {
                    Close = () => { }
                };
                return reader;
            };

            ShimDataTableExtensions.AsEnumerableDataTable = _ =>
            {
                EnumerableRowCollection<DataRow> result = null;
                ShimsContext.ExecuteWithoutShims(
                    () =>
                    {
                        if (dataTableCount == 1)
                        {
                            dataTableCount++;
                            result = CreateActivityTable().AsEnumerable();
                        }
                        else
                        {
                            dataTableCount++;
                            result = userTable.AsEnumerable();
                        }
                    });
                return result;
            };
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;

            var args = new ProcessActivityEventArgs(
                ObjectKind.List,
                ActivityKind.CommentAdded,
                data,
                spWeb,
                streamManager,
                threadManager,
                activityManager);

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand => 1;

            ShimThreadManager.AllInstances.GetThreadGuidNullableOfGuidNullableOfInt32StringArrayBoolean =
                (manager, guid1, arg3, arg4, arg5, arg6) => null;
            ShimThreadManager.AllInstances.UpdateUsersThread = (manager, thread) => { };
            var activityConstructorCount = 0;
            var activityDisposeCount = 0;

            ShimActivity.Constructor = activity => activityConstructorCount++;
            ShimActivity.AllInstances.Dispose = activity => activityDisposeCount++;

            // Act
            privateObj.Invoke("RegisterDeletionActivity", BindingFlags.Instance | BindingFlags.NonPublic, args);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => activityConstructorCount.ShouldBe(1),
                () => activityDisposeCount.ShouldBe(1));
        }
    }
}
