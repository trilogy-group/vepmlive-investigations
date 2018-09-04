using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Entities;
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
    public class ListItemTests
    {
        private ListItem _testObj;
        private PrivateObject _privateObj;
        private IDisposable _shimsContext;
        private SPWeb _spWeb;
        private Guid _guid;
        private const string ConnectionString = "connectionString";
        private const string Commenters = "1,2";
        private const string IdColumn = "Id";
        private const string KindColumn = "Kind";
        private const string DateColumn = "Date";
        private const string UserIdColumn = "UserId";
        private const string MassOperationColumn = "MassOperation";
        private const string ActivityKeyColumn = "ActivityKey";
        private const string DataColumnName = "Data";
        private const string TitleColumn = "Title";
        private const string UrlColumn = "URL";
        private const string LastActivityDateTimeColumn = "LastActivityDateTime";
        private const string FirstActivityDateTimeColumn = "FirstActivityDateTime";
        private const string WebIdColumn = "WebId";
        private const string ListIdColumn = "ListId";
        private const string ItemIdColumn = "ItemId";
        private const string DeletedColumn = "Deleted";
        private const string RoleColumn = "Role";
        private ThreadManager threadManager;
        private ActivityManager activityManager;
        private StreamManager streamManager;

        [TestInitialize]
        public void Setup()
        {
            SetUpShims();

            _testObj = new ListItem();
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        private void SetUpShims()
        {
            _shimsContext = ShimsContext.Create();

            _guid = Guid.NewGuid();

            _spWeb = new ShimSPWeb()
            {
                IDGet = () => _guid,
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => _guid,
                    WebApplicationGet = () => new ShimSPWebApplication(),
                    RootWebGet = () => new ShimSPWeb()
                }
            }.Instance;

            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimSPPersistedObject.AllInstances.IdGet = _ => _guid;
            ShimCoreFunctions.getReportingConnectionStringGuidGuid = (_, _1) => ConnectionString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, _1) => string.Empty;

            threadManager = new ThreadManager(new DBConnectionManager(_spWeb, false));
            activityManager = new ActivityManager(new DBConnectionManager(_spWeb, false));
            streamManager = new StreamManager(new DBConnectionManager(_spWeb, false));
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
            row[IdColumn] = _guid;
            row[KindColumn] = ActivityKind.CommentAdded;
            row[DateColumn] = DateTime.Now;
            row[UserIdColumn] = 1;
            row[MassOperationColumn] = true;
            row[ActivityKeyColumn] = "activityKey";
            row[DataColumnName] = Commenters;
            activityTable.Rows.Add(row);

            return activityTable;
        }

        private DataTable CreateThreadTable()
        {
            var threadTable = new DataTable();
            threadTable.Columns.Add(IdColumn, typeof(Guid));
            threadTable.Columns.Add(TitleColumn, typeof(string));
            threadTable.Columns.Add(UrlColumn, typeof(string));
            threadTable.Columns.Add(KindColumn, typeof(ObjectKind));
            threadTable.Columns.Add(LastActivityDateTimeColumn, typeof(DateTime));
            threadTable.Columns.Add(FirstActivityDateTimeColumn, typeof(DateTime));
            threadTable.Columns.Add(WebIdColumn, typeof(Guid));
            threadTable.Columns.Add(ListIdColumn, typeof(Guid));
            threadTable.Columns.Add(ItemIdColumn, typeof(int));
            threadTable.Columns.Add(DeletedColumn, typeof(int));
            var row = threadTable.NewRow();
            row[IdColumn] = _guid;
            row[TitleColumn] = "Title";
            row[UrlColumn] = "http://www.sampleurl.com";
            row[KindColumn] = ObjectKind.List;
            row[LastActivityDateTimeColumn] = DateTime.Now;
            row[FirstActivityDateTimeColumn] = DateTime.Now;
            row[WebIdColumn] = _guid;
            row[ListIdColumn] = _guid;
            row[ItemIdColumn] = 1;
            row[DeletedColumn] = 1;
            threadTable.Rows.Add(row);
            return threadTable;
        }

        [TestMethod]
        public void PerformPostRegistrationSteps_WhenCalled_Updates()
        {
            // Arrange
            const bool updateExpected = true;

            var updateActual = false;
            var dataTableCount = 1;
            var data = new Dictionary<string, object>()
            {
                ["UserId"] = 1,
                ["Commenters"] = Commenters,
                ["WebId"] = _guid,
                ["IsMassOperation"] = true,
                ["#!Activity"] = new Activity()
                {
                    Id = _guid
                },
                ["AssociatedListItems"] = $"{_guid.ToString()}|1,{_guid.ToString()}|2",
                ["#!Thread"] = new Thread()
                {
                    Id = _guid
                }
            };

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
                    return _guid;
                }
                else if (sqlCommand.CommandText.StartsWith("SELECT TOP (1) Role FROM SS_ThreadUsers"))
                {
                    return UserRole.Commenter;
                }
                return UserRole.Commenter;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand =>
            {
                var reader = new ShimSqlDataReader()
                {
                    Close = () => { }
                };
                return reader;
            };

            ShimDataTableExtensions.AsEnumerableDataTable = _ =>
            {
                EnumerableRowCollection<DataRow> result = null;
                ShimsContext.ExecuteWithoutShims(() =>
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

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.CommentAdded, data, _spWeb, streamManager, threadManager, activityManager);

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand =>
            {
                if (sqlCommand.CommandText.Contains("INSERT INTO SS_AssociatedThreads") && sqlCommand.CommandText.Contains("UPDATE SS_AssociatedThreads"))
                {
                    updateActual = true;
                }
                return 1;
            };

            // Act
            _privateObj.Invoke(
                "PerformPostRegistrationSteps",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[]
                {
                    args
                });

            // Assert
            updateActual.ShouldBe(updateExpected);
        }

        [TestMethod]
        public void EnsureNotIgnoredList_WhenCalled_ReturnsTrue()
        {
            // Arrange
            const string settingValue = "ListTitle";
            const string title = "ListTitle";
            const bool expected = true;

            var data = new Dictionary<string, object>()
            {
                ["ListTitle"] = title
            };

            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => settingValue
                }
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, _spWeb, streamManager, threadManager, activityManager);

            // Act
            var actual = (bool)_privateObj.Invoke("EnsureNotIgnoredList",
               BindingFlags.Static | BindingFlags.NonPublic,
               new object[]
               {
                    args,
                    data
               });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void EnsureNotIgnoredList_WhenCalled_ReturnsFalse()
        {
            // Arrange
            const string settingValue = "settingValue";
            const string title = "ListTitle";
            const bool expected = false;

            var data = new Dictionary<string, object>()
            {
                ["ListTitle"] = title
            };

            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => settingValue
                }
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, _spWeb, streamManager, threadManager, activityManager);

            // Act
            var actual = (bool)_privateObj.Invoke(
                "EnsureNotIgnoredList",
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[]
                {
                    args,
                    data
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetRelatedActivityInterval_WhenCalled_ReturnsTimespan()
        {
            // Arrange
            var expected = new TimeSpan(0, 10, 0);

            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => expected
                }
            };

            // Act
            var actual = (TimeSpan)_privateObj.Invoke(
                "GetRelatedActivityInterval",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[]
                {
                    _spWeb
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void PerformPreRegistrationSteps_WhenCalled_ReturnsTimespan()
        {
            // Arrange
            const bool expected = true;

            var actual = false;
            var readCount = 0;
            var data = new Dictionary<string, object>()
            {
                ["ActivityTime"] = DateTime.Now,
                ["ListId"] = _guid,
                ["Id"] = 1,
                ["UserId"] = 1,
                ["SiteId"] = _guid,
                ["WebId"] = _guid
            };

            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => new TimeSpan(0, 10, 0)
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand =>
            {
                if (sqlCommand.CommandText.StartsWith("UPDATE SS_Activities SET MassOperation = 1"))
                {
                    actual = true;
                }
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand => new ShimSqlDataReader()
            {
                Close = () => { },
                Read = () =>
                {
                    readCount++;
                    if (readCount == 1)
                    {
                        return true;
                    }
                    return false;
                },
                GetGuidInt32 = _ => _guid,
                GetBooleanInt32 = _ => false,
                GetDateTimeInt32 = _ => DateTime.Now
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.CommentAdded, data, _spWeb, streamManager, threadManager, activityManager);

            // Act
            _privateObj.Invoke(
                "PerformPreRegistrationSteps",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[]
                {
                    args
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void RegisterCommentCreationActivity_WhenThreadNotNull_RegistersActivity()
        {
            // Arrange
            const bool registerExpected = true;

            var registerActual = false;
            var data = new Dictionary<string, object>()
            {
                ["ActivityTime"] = DateTime.Now,
                ["ListId"] = _guid,
                ["Id"] = 1,
                ["UserId"] = 1,
                ["SiteId"] = _guid,
                ["WebId"] = _guid,
                ["CommentId"] = 1,
                ["Comment"] = "Comment",
                ["Commenters"] = Commenters,
                ["#!Thread"] = new Thread()
                {
                    Id = _guid
                }
            };

            var threadTable = CreateThreadTable();

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand =>
            {
                if (sqlCommand.CommandText.StartsWith("INSERT INTO SS_Activities"))
                {
                    registerActual = true;
                }
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand =>
            {
                var reader = new ShimSqlDataReader()
                {
                    Close = () => { }
                };
                return reader;
            };
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) =>
            {
                DataRow result = null;
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = threadTable.Rows[0];
                });
                return result;
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.CommentAdded, data, _spWeb, streamManager, threadManager, activityManager);

            // Act
            _privateObj.Invoke(
                "RegisterCommentCreationActivity",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[]
                {
                    args
                });

            // Assert
            registerActual.ShouldBe(registerExpected);
        }

        [TestMethod]
        public void RegisterCommentCreationActivity_WhenThreadNull_RegistersActivity()
        {
            // Arrange
            const bool registerExpected = true;

            var registerActual = false;
            var data = new Dictionary<string, object>()
            {
                ["Title"] = "Title",
                ["URL"] = "http://sampleurl.com",
                ["ActivityTime"] = DateTime.Now,
                ["ListId"] = _guid,
                ["Id"] = 1,
                ["UserId"] = 1,
                ["SiteId"] = _guid,
                ["WebId"] = _guid,
                ["CommentId"] = 1,
                ["Comment"] = "Comment",
                ["Commenters"] = Commenters
            };
            var threadTable = CreateThreadTable();

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand =>
            {
                if (sqlCommand.CommandText.StartsWith("INSERT INTO SS_Activities"))
                {
                    registerActual = true;
                }
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand =>
            {
                var reader = new ShimSqlDataReader()
                {
                    Close = () => { }
                };
                return reader;
            };
            ShimDataRowCollection.AllInstances.CountGet = _ => 0;
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) =>
            {
                DataRow result = null;
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = threadTable.Rows[0];
                });
                return result;
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.CommentAdded, data, _spWeb, streamManager, threadManager, activityManager);

            // Act
            _privateObj.Invoke(
                "RegisterCommentCreationActivity",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[]
                {
                    args
                });

            // Assert
            registerActual.ShouldBe(registerExpected);
        }

        [TestMethod]
        public void RegisterDeletionActivity_WhenCalled_RegistersActivity()
        {
            // Arrange
            const bool registerExpected = true;

            var registerActual = false;
            var data = new Dictionary<string, object>()
            {
                ["ActivityTime"] = DateTime.Now,
                ["WebId"] = _guid,
                ["Title"] = "Title",
                ["URL"] = "http://sampleurl.com",
                ["ListId"] = _guid,
                ["Id"] = 1,
                ["UserId"] = 1,
                ["CommentId"] = 1
            };
            var threadTable = CreateThreadTable();

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand =>
            {
                if (sqlCommand.CommandText.StartsWith("INSERT INTO SS_Activities"))
                {
                    registerActual = true;
                }
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand =>
            {
                var reader = new ShimSqlDataReader()
                {
                    Close = () => { }
                };
                return reader;
            };
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) =>
            {
                DataRow result = null;
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = threadTable.Rows[0];
                });
                return result;
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Deleted, data, _spWeb, streamManager, threadManager, activityManager);

            // Act
            _privateObj.Invoke(
                "RegisterCommentDeletionActivity",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[]
                {
                    args
                });

            // Assert
            registerActual.ShouldBe(registerExpected);
        }

        [TestMethod]
        public void RegisterUpdationActivity_WhenThreadNull_RegistersActivity()
        {
            // Arrange
            const bool registerExpected = true;

            var registerActual = false;
            var data = new Dictionary<string, object>()
            {
                ["ActivityTime"] = DateTime.Now,
                ["WebId"] = _guid,
                ["Title"] = "Title",
                ["URL"] = "http://sampleurl.com",
                ["ListId"] = _guid,
                ["Id"] = 1,
                ["UserId"] = 1,
                ["ChangedProperties"] = "ChangedProperties,title",
                ["CommentId"] = 1,
                ["Comment"] = "Comment",
                ["Commenters"] = Commenters
            };
            var threadTable = CreateThreadTable();

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand =>
            {
                if (sqlCommand.CommandText.StartsWith("INSERT INTO SS_Activities"))
                {
                    registerActual = true;
                }
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand =>
            {
                var reader = new ShimSqlDataReader()
                {
                    Close = () => { }
                };
                return reader;
            };
            ShimDataRowCollection.AllInstances.CountGet = _ => 0;
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) =>
            {
                DataRow result = null;
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = threadTable.Rows[0];
                });
                return result;
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, _spWeb, streamManager, threadManager, activityManager);

            // Act
            _privateObj.Invoke(
                "RegisterCommentUpdationActivity",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[]
                {
                    args
                });

            // Assert
            registerActual.ShouldBe(registerExpected);
        }

        [TestMethod]
        public void RegisterUpdationActivity_WhenThreadNotNull_RegistersActivity()
        {
            // Arrange
            const bool registerExpected = true;

            var registerActual = false;
            var data = new Dictionary<string, object>()
            {
                ["ActivityTime"] = DateTime.Now,
                ["WebId"] = _guid,
                ["Title"] = "Title",
                ["URL"] = "http://sampleurl.com",
                ["ListId"] = _guid,
                ["Id"] = 1,
                ["UserId"] = 1,
                ["ChangedProperties"] = "ChangedProperties,title",
                ["CommentId"] = 1,
                ["Comment"] = "Comment",
                ["Commenters"] = Commenters
            };
            var threadTable = CreateThreadTable();

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand =>
            {
                if (sqlCommand.CommandText.StartsWith("INSERT INTO SS_Activities"))
                {
                    registerActual = true;
                }
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand =>
            {
                var reader = new ShimSqlDataReader()
                {
                    Close = () => { }
                };
                return reader;
            };
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) =>
            {
                DataRow result = null;
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = threadTable.Rows[0];
                });
                return result;
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, _spWeb, streamManager, threadManager, activityManager);

            // Act
            _privateObj.Invoke(
                "RegisterCommentUpdationActivity",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[]
                {
                    args
                });

            // Assert
            registerActual.ShouldBe(registerExpected);
        }

        [TestMethod]
        public void UpdateThreadUsers_WhenCalled_UpdatesThreadUsers()
        {
            // Arrange
            const bool expectedUpdate = true;

            var actualUpdate = false;
            var thread = new Thread()
            {
                Id = _guid,
                Users = new User[]
                {
                    new User()
                    {
                        Id = 1,
                        Role = UserRole.Assignee
                    }
                }
            };
            var data = new Dictionary<string, object>()
            {
                ["UserId"] = 1,
                ["AssignedTo"] = "1,2"
            };

            ShimSqlCommand.AllInstances.ExecuteScalar = _ => UserRole.Assignee;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                actualUpdate = true;
                return new ShimSqlDataReader()
                {
                    Read = () => false,
                    Close = () => { }
                };
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, _spWeb, streamManager, threadManager, activityManager);

            // Act
            _privateObj.Invoke(
                "UpdateThreadUsers",
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[]
                {
                    args,
                    thread
                });

            // Assert
            actualUpdate.ShouldBe(expectedUpdate);
        }

        private Dictionary<string, object> CreateDataObject()
        {
            var data = new Dictionary<string, object>()
            {
                ["Id"] = 1,
                ["Title"] = "Title",
                ["URL"] = "http://sampleurl.com",
                ["ListTitle"] = "ListTitle",
                ["ListId"] = _guid,
                ["WebId"] = _guid,
                ["SiteId"] = _guid,
                ["UserId"] = 1,
                ["ActivityTime"] = DateTime.Now
            };
            return data;
        }

        [TestMethod]
        public void ValidateCreationActivity_WhenCalled_ThrowsException()
        {
        }
    }
}
