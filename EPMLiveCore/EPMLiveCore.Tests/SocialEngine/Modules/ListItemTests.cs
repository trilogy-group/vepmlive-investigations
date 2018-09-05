using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Reflection;
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
        private ListItem testObj;
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
        private const string LastActivityDateTimeColumn = "LastActivityDateTime";
        private const string FirstActivityDateTimeColumn = "FirstActivityDateTime";
        private const string WebIdColumn = "WebId";
        private const string ListIdColumn = "ListId";
        private const string ItemIdColumn = "ItemId";
        private const string DeletedColumn = "Deleted";
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
        private const string PerformPostRegistrationStepsMethod = "PerformPostRegistrationSteps";
        private const string EnsureNotIgnoredListMethod = "EnsureNotIgnoredList";
        private const string PerformPreRegistrationStepsMethod = "PerformPreRegistrationSteps";
        private const string RegisterCommentCreationActivityMethod = "RegisterCommentCreationActivity";
        private const string RegisterCommentDeletionActivityMethod = "RegisterCommentDeletionActivity";
        private const string RegisterCommentUpdationActivityMethod = "RegisterCommentUpdationActivity";
        private const string ValidateCommentCreationActivityMethod = "ValidateCommentCreationActivity";
        private ThreadManager threadManager;
        private ActivityManager activityManager;
        private StreamManager streamManager;

        [TestInitialize]
        public void Setup()
        {
            SetUpShims();
            testObj = new ListItem();
            privateObj = new PrivateObject(testObj);
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
            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                SiteGet = () => new ShimSPSite()
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

        private DataTable CreateThreadTable()
        {
            var threadTable = new DataTable();
            threadTable.Columns.Add(IdColumn, typeof(Guid));
            threadTable.Columns.Add(TitleString, typeof(string));
            threadTable.Columns.Add(UrlColumn, typeof(string));
            threadTable.Columns.Add(KindColumn, typeof(ObjectKind));
            threadTable.Columns.Add(LastActivityDateTimeColumn, typeof(DateTime));
            threadTable.Columns.Add(FirstActivityDateTimeColumn, typeof(DateTime));
            threadTable.Columns.Add(WebIdColumn, typeof(Guid));
            threadTable.Columns.Add(ListIdColumn, typeof(Guid));
            threadTable.Columns.Add(ItemIdColumn, typeof(int));
            threadTable.Columns.Add(DeletedColumn, typeof(int));
            var row = threadTable.NewRow();
            row[IdColumn] = guid;
            row[TitleString] = TitleString;
            row[UrlColumn] = "http://www.sampleurl.com";
            row[KindColumn] = ObjectKind.List;
            row[LastActivityDateTimeColumn] = DateTime.Now;
            row[FirstActivityDateTimeColumn] = DateTime.Now;
            row[WebIdColumn] = guid;
            row[ListIdColumn] = guid;
            row[ItemIdColumn] = 1;
            row[DeletedColumn] = 1;
            threadTable.Rows.Add(row);
            return threadTable;
        }

        private Dictionary<string, object> CreateDataObject()
        {
            var data = new Dictionary<string, object>()
            {
                [IdColumn] = 1,
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
        public void PerformPostRegistrationSteps_WhenCalled_Updates()
        {
            // Arrange
            const bool updateExpected = true;

            var updateActual = false;
            var dataTableCount = 1;
            var data = CreateDataObject();
            data.Add(CommentersColumn, Commenters);
            data.Add(IsMassOperation, true);
            data.Add(ActivityValue, new Activity()
            {
                Id = guid
            });
            data.Add(AssociatedListItems, $"{guid.ToString()}|1,{guid.ToString()}|2");
            data.Add(ThreadValue, new Thread()
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

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.CommentAdded, data, spWeb, streamManager, threadManager, activityManager);

            ShimSqlCommand.AllInstances.ExecuteNonQuery = sqlCommand =>
            {
                if (sqlCommand.CommandText.Contains("INSERT INTO SS_AssociatedThreads") && sqlCommand.CommandText.Contains("UPDATE SS_AssociatedThreads"))
                {
                    updateActual = true;
                }
                return 1;
            };

            // Act
            privateObj.Invoke(
                PerformPostRegistrationStepsMethod,
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
            const string settingValue = ListTitle;
            const bool expected = true;

            var data = CreateDataObject();

            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => settingValue
                }
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            var actual = (bool)privateObj.Invoke(EnsureNotIgnoredListMethod,
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
            const bool expected = false;

            var data = CreateDataObject();

            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => settingValue
                }
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            var actual = (bool)privateObj.Invoke(
                EnsureNotIgnoredListMethod,
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
            var actual = (TimeSpan)privateObj.Invoke(
                "GetRelatedActivityInterval",
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[]
                {
                    spWeb
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
            var data = CreateDataObject();

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
                GetGuidInt32 = _ => guid,
                GetBooleanInt32 = _ => false,
                GetDateTimeInt32 = _ => DateTime.Now
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.CommentAdded, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            privateObj.Invoke(
                PerformPreRegistrationStepsMethod,
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
            var data = CreateDataObject();
            data.Add("CommentId", 1);
            data.Add("Comment", "Comment");
            data.Add(CommentersColumn, Commenters);
            data.Add(ThreadValue, new Thread()
            {
                Id = guid
            });

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

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.CommentAdded, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            privateObj.Invoke(
                RegisterCommentCreationActivityMethod,
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
            var data = CreateDataObject();
            data.Add("CommentId", 1);
            data.Add("Comment", "Comment");
            data.Add(CommentersColumn, Commenters);

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

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.CommentAdded, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            privateObj.Invoke(
                RegisterCommentCreationActivityMethod,
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
            var data = CreateDataObject();
            data.Add("CommentId", 1);
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

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Deleted, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            privateObj.Invoke(
                RegisterCommentDeletionActivityMethod,
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
            var data = CreateDataObject();
            data.Add("ChangedProperties", "ChangedProperties,title");
            data.Add("CommentId", 1);
            data.Add("Comment", "Comment");
            data.Add(CommentersColumn, Commenters);

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

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            privateObj.Invoke(
                RegisterCommentUpdationActivityMethod,
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
            var data = CreateDataObject();
            data.Add("ChangedProperties", "ChangedProperties,title");
            data.Add("CommentId", 1);
            data.Add("Comment", "Comment");
            data.Add(CommentersColumn, Commenters);
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

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            privateObj.Invoke(
                RegisterCommentUpdationActivityMethod,
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
                Id = guid,
                Users = new User[]
                {
                    new User()
                    {
                        Id = 1,
                        Role = UserRole.Assignee
                    }
                }
            };
            var data = CreateDataObject();
            data.Add("AssignedTo", "1,2");

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

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Updated, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            privateObj.Invoke(
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

        [TestMethod]
        public void ValidateCommentCreationActivity_WhenCalled_ThrowsSameItemException()
        {
            // Arrange
            const string settingValue = "somevalue";
            const string expected = "Cannot register more than one created activity on the same list item.";

            var data = CreateDataObject();
            var actual = string.Empty;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => settingValue
                }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => 1;

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Created, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            try
            {
                privateObj.Invoke(
                    ValidateCommentCreationActivityMethod,
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    new object[]
                    {
                        args
                    });
            }
            catch (SocialEngineException exception)
            {
                actual = exception.Message;
            }

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ValidateCommentCreationActivity_WhenCalled_ThrowsNotRegisteredException()
        {
            // Arrange
            const string settingValue = "somevalue";
            const string expected = "Cannot register creation activity on the same comment more than once";

            var queryCount = 0;
            var data = CreateDataObject();
            data.Add("CommentId", guid);
            data.Add("Comment", "Comment");

            var actual = string.Empty;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => settingValue
                }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = _ =>
            {
                queryCount++;
                if (queryCount == 1)
                {
                    return 0;
                }
                return 1;
            };

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Created, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            try
            {
                privateObj.Invoke(
                    ValidateCommentCreationActivityMethod,
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    new object[]
                    {
                        args
                    });
            }
            catch (SocialEngineException exception)
            {
                actual = exception.Message;
            }

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ValidateCommentDeletionActivity_WhenCalled_ThrowsSameItemError()
        {
            // Arrange
            const string settingValue = "somevalue";
            const string expected = "Cannot register more than one deleted activity on the same item.";

            var data = CreateDataObject();
            var actual = string.Empty;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => settingValue
                }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => 1;

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Deleted, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            try
            {
                privateObj.Invoke(
                    "ValidateCommentDeletionActivity",
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    new object[]
                    {
                        args
                    });
            }
            catch (SocialEngineException exception)
            {
                actual = exception.Message;
            }

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ValidateCommentDeletionActivity_WhenCalled_ThrowsNotRegistered()
        {
            // Arrange
            const string settingValue = "somevalue";
            const string expected = "Cannot delete a comment that has not been registerd";

            var data = CreateDataObject();
            data.Add("CommentId", guid);

            var actual = string.Empty;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => settingValue
                }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => 0;

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Deleted, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            try
            {
                privateObj.Invoke(
                    "ValidateCommentDeletionActivity",
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    new object[]
                    {
                        args
                    });
            }
            catch (SocialEngineException exception)
            {
                actual = exception.Message;
            }

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ValidateCommentUpdationActivity_WhenCalled_ThrowsNotRegisteredException()
        {
            // Arrange
            const string settingValue = "somevalue";
            const string expected = "Cannot update a comment that has not been registerd";

            var data = CreateDataObject();
            data.Add("CommentId", guid);
            data.Add("Comment", "Comment");

            var actual = string.Empty;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                GetStringStringFuncOfObjectBoolean = (_, _1, _2, _3) => new ShimCachedValue()
                {
                    ValueGet = () => settingValue
                }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => 0;

            var args = new ProcessActivityEventArgs(ObjectKind.List, ActivityKind.Created, data, spWeb, streamManager, threadManager, activityManager);

            // Act
            try
            {
                privateObj.Invoke(
                    "ValidateCommentUpdationActivity",
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    new object[]
                    {
                        args
                    });
            }
            catch (SocialEngineException exception)
            {
                actual = exception.Message;
            }

            // Assert
            actual.ShouldBe(expected);
        }
    }
}
