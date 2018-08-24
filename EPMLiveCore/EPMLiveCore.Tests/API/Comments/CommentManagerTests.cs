using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.SocialEngine;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.Comments
{
    [TestClass]
    public class CommentManagerTests
    {
        private IDisposable _shimContext;
        private CommentManager _commentManager;
        private PrivateType _privateType;
        private PrivateObject _privateObject;
        private string GetXMLSafeVersionMethodName = "GetXMLSafeVersion";
        private string AlreadyDisplayedMethodName = "AlreadyDisplayed";
        private string ContainsItemMethodName = "ContainsItem";
        private string GetMyCommentsByDateMethodName = "GetMyCommentsByDate";
        private string UserIsAssignedMethodName = "UserIsAssigned";
        private string SendEmailNotificationMethodName = "SendEmailNotification";
        private string SetSocialEngineTransactionMethodName = "SetSocialEngineTransaction";

        private const string DummyUrl = "https://server.org/dummy/url";
        private const string DummyString = "DummyString";
        private string DeleteFromSocialStreamMethodName = "DeleteFromSocialStream";
        private string EnsurePublicCommentsListExistMethodName = "EnsurePublicCommentsListExist";
        private string EnsureMetaColsMethodName = "EnsureMetaCols";
        private const string StatusUpdateKey = "StatusUpdate";
        private const string StatusUpdateIdKey = "StatusUpdateId";
        private const string ListIdKey = "ListId";
        private const string ItemIdKey = "ItemId";
        private const string CommentKey = "Comment";
        private const string CreatedKey = "Created";
        private string SyncToSocialStreamMethodName = "SyncToSocialStream";
        private string SyncStatusUpdateToSocialStreamMethodName = "SyncStatusUpdateToSocialStream";

        [TestInitialize]
        public void Initialize()
        {
            _shimContext = ShimsContext.Create();
            SetupShims();
            _commentManager = new CommentManager();
            _privateObject = new PrivateObject(_commentManager);
            _privateType = new PrivateType(typeof(CommentManager));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();
            ShimHttpContext.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimSPSite.AllInstances.MakeFullUrlString = (_, url) => DummyUrl;
            ShimSPContext.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings();
            ShimSPRegionalSettings.AllInstances.TimeZoneGet = _ => new ShimSPTimeZone();
            ShimSPTimeZone.AllInstances.UTCToLocalTimeDateTime = (_, date) => DateTime.Now;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.IDGet = _ => 1;
            ShimSPUser.AllInstances.NameGet = _ => DummyString;
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPSite.AllInstances.OpenWebString = (_, url) => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimCoreFunctions.getConfigSettingSPWebString = (web, value) => DummyString;
            ShimCoreFunctions.setConfigSettingSPWebStringString = (web, setting, value) => { };
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, id) => new ShimSPUser();
            ShimSPRequestContext.CurrentGet = () => new ShimSPRequestContext();
            ShimCoreFunctions.getReportingConnectionStringGuidGuid = (webApp, siteId) => DummyString;
            ShimSqlConnection.ConstructorString = (_, connectionString) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimXMLDataManager.ConstructorString = (_, xml) => { };
            ShimSPListItem.AllInstances.ItemSetGuidObject = (_, guid, value) => { };
            ShimExtensionMethods.ToFriendlyDateAndTimeDateTimeSPWeb = (date, web) => DummyString;
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, guid) => new ShimSPList();
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem();
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
            ShimCommentManager.SetSocialEngineTransactionSPListItem = _ => { };
            ShimCommentManager.EnsureMetaColsSPList = _ => { };
            ShimCommentManager.InsertCommentCountStringString = (list, item) => { };


        }

        [TestMethod]
        public void CreateComment_OnSuccess_ReturnsCommentContent()
        {
            // Arrange
            ShimXMLDataManager.AllInstances.GetPropValString = (_, xml) =>
            {
                switch (xml)
                {
                    case StatusUpdateKey:
                        return bool.TrueString;
                    case StatusUpdateIdKey:
                        return Guid.NewGuid().ToString();
                    case ListIdKey:
                        return Guid.NewGuid().ToString();
                    case ItemIdKey:
                        return "2";
                    case CommentKey:
                        return DummyString;
                    default:
                        return null;
                }
            };
            var commentList = new ShimSPList
            {
                ItemsGet = () => new ShimSPListItemCollection
                {
                    Add = () => new ShimSPListItem()
                },
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField()
                }
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                TryGetListString = name => commentList
            };
            ShimSPListItem.AllInstances.ItemGetString = (_, name) =>
            {
                switch (name)
                {
                    case CreatedKey:
                        return DateTime.Now;
                    case ListIdKey:
                        return Guid.NewGuid().ToString();
                    case ItemIdKey:
                        return "2";
                    default:
                        return null;
                }
            };
            ShimSPListItem.AllInstances.IDGet = _ => 5;
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList
            {
                TitleGet = () => DummyString,
                IDGet = () => Guid.NewGuid()
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            ShimSPList.AllInstances.GetItemByUniqueIdGuid = (_, guid) => new ShimSPListItem();
            ShimSPUser.AllInstances.IDGet = _ => 10;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, name) => true;
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPField()
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) => "1,2,3";
            ShimSPFieldCollection.AllInstances.ItemGetGuid = (_, guid) =>
            {
                if (guid == SPBuiltInFieldId.Author)
                    return new ShimSPFieldUser().Instance;
                else
                    return new ShimSPField();
            };
            ShimSPFieldUser.AllInstances.GetFieldValueString = (_, name) =>
            {
                return new ShimSPFieldUserValue
                {
                    UserGet = () => new ShimSPUser
                    {
                        IDGet = () => 1
                    }
                }.Instance;
            };
            ShimCommentManager.UserIsAssignedInt32SPListItem = (id, list) => false;
            ShimCommentManager.SendEmailNotificationInt32StringStringStringString =
                (authorId, listId, itemIt, comment, type) => true;
            ShimCommentManager.SyncStatusUpdateToSocialStreamGuidStringGuidInt32DateTimeSPWebStringNullableOfDateTimeNullableOfGuid =
                (id, status, listId, itemId, time, spWeb, operation, commentTime, commentId) => { };
            ShimCommentManager.SyncToSocialStreamGuidStringGuidInt32StringStringStringListOfInt32DateTimeSPWebString =
                (id, comment, listId, itemId, itemTitle, listTitle, url, commmenters, time, spWeb, operaiton) => { };

            // Act
            var result = CommentManager.CreateComment(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void ReadComment_CommentListNull_ThrowException()
        {
            // Arrange
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => null;

            // Act
            Action action = () => CommentManager.ReadComment(DummyString);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void ReadComment_CommentList_ReturnsValue()
        {
            // Arrange
            const string CommentItemIdKey = "CommentItemId";
            const int CommentItemId = 1;
            ShimXMLDataManager.AllInstances.GetPropValString = (_, value) =>
            {
                switch (value)
                {
                    case ListIdKey:
                    case ItemIdKey:
                        return Guid.NewGuid().ToString();
                    case CommentItemIdKey:
                        return CommentItemId.ToString();
                    default:
                        return null;
                }
            };
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => new ShimSPList
            {
                GetItemsSPQuery = query => new ShimSPListItemCollection
                {
                    CountGet = () => 2,
                    GetEnumerator = () =>
                    {
                        return new List<SPListItem>
                        {
                            new ShimSPListItem
                            {
                                IDGet = () => 0
                            },
                            new ShimSPListItem
                            {
                                IDGet = () => CommentItemId
                            }
                        }.GetEnumerator();
                    }
                },
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField
                    {
                        IdGet = () => Guid.NewGuid()
                    }
                }
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) => DummyString;
            ShimCommentManager.InsertCommentCountStringString = (listId, ItemId) => { };

            // Act
            var result = CommentManager.ReadComment(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void EnsureMetaCols_Should_SetConfigSetting()
        {
            // Arrange
            var configSettingWasSet = true;
            var list = new ShimSPList
            {
                ParentWebGet = () => new ShimSPWeb(),
                IDGet = () => Guid.NewGuid(),
                FieldsGet = () => new ShimSPFieldCollection
                {
                    AddStringSPFieldTypeBoolean = (value, type, required) => value,
                    GetFieldByInternalNameString = name => new ShimSPFieldMultiLineText()
                }
            }.Instance;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, name) => false;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, value) => DummyString;
            ShimCoreFunctions.setConfigSettingSPWebStringString = (web, setting, value) =>
            {
                configSettingWasSet = true;
            };
            ShimCommentManager.EnsureMetaColsSPList = null;

            // Act
            _privateType.InvokeStatic(EnsureMetaColsMethodName, list);

            // Assert
            configSettingWasSet.ShouldBeTrue();
        }

        [TestMethod]
        public void SyncToSocialStream_Should_ExecuteCorrectly()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite(),
                CurrentUserGet = () => new ShimSPUser()
            }.Instance;
            var commentList = new List<int>();
            const string Operation = "ADD";
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => { };
            ShimCommentManager.SyncToSocialStreamGuidStringGuidInt32StringStringStringListOfInt32DateTimeSPWebString = null;

            // Act
            Action action = () => _privateType.InvokeStatic(SyncToSocialStreamMethodName,
                Guid.NewGuid(),
                DummyString,
                Guid.NewGuid(),
                1,
                DummyString,
                DummyString,
                DummyUrl,
                commentList,
                DateTime.Now,
                web,
                Operation);

            // Assert
            action.ShouldNotThrow();
        }

        [TestMethod]
        public void SyncStatusUpdateToSocialStream_Should_ExecuteCorrectly()
        {
            // Arrange
            const string Operation = "ADD";
            var web = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite(),
                CurrentUserGet = () => new ShimSPUser()
            }.Instance;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => { };
            ShimCommentManager.SyncStatusUpdateToSocialStreamGuidStringGuidInt32DateTimeSPWebStringNullableOfDateTimeNullableOfGuid = null;

            // Act
            Action action = () => _privateType.InvokeStatic(SyncStatusUpdateToSocialStreamMethodName,
                Guid.NewGuid(),
                DummyString,
                Guid.NewGuid(),
                1,
                DateTime.Now,
                web,
                Operation,
                DateTime.Now,
                Guid.NewGuid());

            // Assert
            action.ShouldNotThrow();
        }

        [TestMethod]
        public void CreatePublicComment()
        {
            // Arrange

            // Act

            // Assert
            //Assert.Fail("Not Implemented");
        }

        [TestMethod]
        public void EnsurePublicCommentsListExist_ListNull_SetSPList()
        {
            // Arrange
            var updateWasCalled = false;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                TryGetListString = name => null
            };
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = guid => new ShimSPList
                    {
                        Update = () =>
                        {
                            updateWasCalled = true;
                        },
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = name => new ShimSPFieldMultiLineText()
                        }
                    }
                }
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                try
                {
                    codeToRun();
                }
                catch { }
            };

            // Act
            _privateType.InvokeStatic(EnsurePublicCommentsListExistMethodName);

            // Assert
            updateWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteFromSocialStream_Should_NotThrowException()
        {
            // Arrange
            var currentWeb = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.NewGuid(),
                    WebApplicationGet = () => new SPWebApplication() { Id = Guid.NewGuid() }
                },
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => 1
                },
            }.Instance;
            //ShimSPContext.CurrentGet = () => new ShimSPContext
            //{
            //    RegionalSettingsGet = () => new ShimSPRegionalSettings
            //    {
            //        TimeZoneGet = () => new ShimSPTimeZone
            //        {
            //            UTCToLocalTimeDateTime = date => DateTime.Now
            //        }
            //    }
            //};
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => { };


            // Act
            Action action = () => _privateType.InvokeStatic(
                DeleteFromSocialStreamMethodName,
                DummyString,
                DummyString,
                Guid.NewGuid(),
                1,
                DummyUrl,
                Guid.NewGuid(),
                currentWeb);

            // Assert
            action.ShouldNotThrow();
        }

        [TestMethod]
        public void InsertCommentCount_CommentListNull_ThrowException()
        {
            // Arrange
            var listId = Guid.NewGuid().ToString();
            var itemId = "1";
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => null;
            ShimCommentManager.InsertCommentCountStringString = null;

            // Act
            Action action = () => CommentManager.InsertCommentCount(listId, itemId);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void InsertCommentCount_CommentCountFieldNotNull_UpdateSystem()
        {
            // Arrange
            var listId = Guid.NewGuid().ToString();
            var itemId = "1";
            var systemUpdateWasCalled = false;
            ShimCommentManager.InsertCommentCountStringString = null;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => new ShimSPList
            {
                GetItemsSPQuery = query => new ShimSPListItemCollection
                {
                    CountGet = () => 1,
                    GetEnumerator = () =>
                    {
                        return new List<SPListItem>().GetEnumerator();
                    }
                }
            };
            ShimSPListCollection.AllInstances.GetListGuidBoolean = (_, id, required) => new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField()
                }
            };
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSPSite.AllInstances.OpenWebString = (_, url) => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = guid => new ShimSPList
                    {
                        GetItemByIdInt32 = id => new ShimSPListItem()
                    }
                }
            };
            ShimCommentManager.SetSocialEngineTransactionSPListItem = item => { };
            ShimSPListItem.AllInstances.SystemUpdate = _ =>
            {
                systemUpdateWasCalled = true;
            };

            // Act
            CommentManager.InsertCommentCount(listId, itemId);

            // Assert
            systemUpdateWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void InsertCommentCount_CommentCountFieldNull_UpdateSystem()
        {
            // Arrange
            var listId = Guid.NewGuid().ToString();
            var itemId = "1";
            var systemUpdateWasCalled = false;
            ShimCommentManager.InsertCommentCountStringString = null;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => new ShimSPList
            {
                GetItemsSPQuery = query => new ShimSPListItemCollection
                {
                    CountGet = () => 1,
                    GetEnumerator = () =>
                    {
                        return new List<SPListItem>().GetEnumerator();
                    }
                }
            };
            ShimSPListCollection.AllInstances.GetListGuidBoolean = (_, id, required) => new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => null
                }
            };
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSPSite.AllInstances.OpenWebString = (_, url) => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = guid => new ShimSPList
                    {
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = name => new ShimSPFieldNumber()
                        },
                        GetItemByIdInt32 = id => new ShimSPListItem(),
                    }
                }
            };
            ShimCommentManager.SetSocialEngineTransactionSPListItem = item => { };
            ShimSPListItem.AllInstances.SystemUpdate = _ =>
            {
                systemUpdateWasCalled = true;
            };

            // Act
            CommentManager.InsertCommentCount(listId, itemId);

            // Assert
            systemUpdateWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void SetSocialEngineTransaction_Should_SetTransaction()
        {
            // Arrange
            ShimCommentManager.SetSocialEngineTransactionSPListItem = null;
            var setTransactionWasCalled = false;
            var listItem = new ShimSPListItem
            {
                WebGet = () => new ShimSPWeb(),
                ParentListGet = () => new ShimSPList()
            }.Instance;
            ShimSocialEngineProxy.SetTransactionGuidGuidInt32StringSPWeb =
                (guid, listId, itemId, componentName, web) =>
                {
                    setTransactionWasCalled = true;
                    return Guid.Empty;
                };

            // Act
            _privateType.InvokeStatic(SetSocialEngineTransactionMethodName, listItem);

            // Assert
            setTransactionWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void SendEmailNotification_OnSuccess_QueueMessage()
        {
            // Arrange
            var messageQueued = false;
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection
            {
                GetByIDInt32 = id => new ShimSPUser()
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList()
            };
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPField
                {
                    IdGet = () => Guid.NewGuid()
                }
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) => DummyString; // chante on next test
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection
            {
                ItemGetPAGETYPE = type => new ShimSPForm
                {
                    ServerRelativeUrlGet = () => DummyUrl
                }
            };
            ShimAPIEmail.QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPListItemSPUserBoolean =
                (template, hide, parameters, users, deleteUsers, doNotEmail, unmarked, listItem, user, force) =>
            {
                messageQueued = true;
            };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                NameGet = () => DummyString
            };

            // Act
            var result = _privateType.InvokeStatic(SendEmailNotificationMethodName,
                1, Guid.NewGuid().ToString(), "1", DummyString, DummyString) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => messageQueued.ShouldBeTrue());
        }

        [TestMethod]
        public void SendEmailNotification_OnException_ReturnsFalse()
        {
            // Arrange
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection
            {
                GetByIDInt32 = id => new ShimSPUser()
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList()
            };
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, id) => new ShimSPListItem();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPField
                {
                    IdGet = () => Guid.NewGuid()
                }
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) => null;
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection
            {
                ItemGetPAGETYPE = type => new ShimSPForm
                {
                    ServerRelativeUrlGet = () => DummyUrl
                }
            };
            ShimAPIEmail.QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPListItemSPUserBoolean =
                (template, hide, parameters, users, deleteUsers, doNotEmail, unmarked, listItem, user, force) =>
                {
                    throw new Exception();
                };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                NameGet = () => DummyString
            };
            var comment = DummyString + "%20";

            // Act
            var result = _privateType.InvokeStatic(SendEmailNotificationMethodName,
                1, Guid.NewGuid().ToString(), "1", comment, DummyString) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeFalse());
        }

        [TestMethod]
        public void BuildBody_Should_ReturnHashtable()
        {
            // Arrange
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = guid => new ShimSPList
                    {
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = name => new ShimSPField()
                        },
                        GetItemByIdInt32 = id => new ShimSPListItem
                        {
                            ItemGetGuid = itemGuid => DummyString
                        },
                        FormsGet = () => new ShimSPFormCollection
                        {
                            ItemGetPAGETYPE = type => new ShimSPForm
                            {
                                ServerRelativeUrlGet = () => DummyUrl
                            }
                        }
                    },
                },
            };

            // Act
            var result = CommentManager.BuildBody(DummyString, Guid.NewGuid().ToString(), "1", DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Keys.Count.ShouldBeGreaterThanOrEqualTo(1));
        }

        [TestMethod]
        public void UserIsAssigned_WithCurrentIdExpected_ReturnsTrue()
        {
            // Arrange
            const int UserId = 10;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                IDGet = () => UserId
            };

            var item = new ShimSPListItem
            {
                ItemGetGuid = guid => string.Format("{0};#{1}", DummyString, UserId),
                FieldsGet = () => new ShimSPFieldCollection
                {
                    ItemGetGuid = guid => new ShimSPField(),
                    GetFieldByInternalNameString = name => new ShimSPField
                    {
                        IdGet = () => Guid.NewGuid()
                    }
                }
            }.Instance;

            // Act
            var result = CommentManager.UserIsAssigned(UserId, item);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void SendEmailNotification_OnSuccess_QueueItemMessage()
        {
            // Arrange
            var messageQueued = false;
            ShimAPIEmail.QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPListItemSPUserBoolean =
                (templateId, hidden, additionalPArameters, newUsers, delUsers, doNotEMail, unmarked, listItem, currentUser, force) =>
                {
                    messageQueued = true;
                };
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection
            {
                GetByIDInt32 = id => new ShimSPUser()
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList
                {
                    GetItemByIdInt32 = id => new ShimSPListItem()
                }
            };
            ShimSPListItem.AllInstances.ItemGetGuid = (_, guid) => DummyString;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection
            {
                ItemGetPAGETYPE = type => new ShimSPForm
                {
                    ServerRelativeUrlGet = () => DummyUrl
                }
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPField
                {
                    IdGet = () => Guid.NewGuid() // null on next test
                }
            };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                NameGet = () => DummyString
            };
            //ShimCommentManager

            // Act
            var result = _privateType.InvokeStatic(
                SendEmailNotificationMethodName,
                1, Guid.NewGuid().ToString(), "1", DummyString, DummyString) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => messageQueued.ShouldBeTrue());
        }

        [TestMethod]
        public void GetMyCommentsByDate()
        {
            // Arrange

            // Act

            // Assert
            //Assert.Fail("Not implemented");
        }

        [TestMethod]
        public void ContainsItem_WithExpectedValue_ReturnsTrue()
        {
            // Arrange
            var dummyGuid = Guid.NewGuid().ToString();
            var items = new List<string[]>
            {
                new string[]{ Guid.Empty.ToString(), "1" },
                new string[]{ dummyGuid, "1" }
            };
            var item = new string[] { dummyGuid, "1" };

            // Act
            var result = _privateType.InvokeStatic(ContainsItemMethodName, items, item) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeTrue());
        }

        [TestMethod]
        public void AlreadyDisplayed_WithExpectedValue_ReturnsTrue()
        {
            // Arrange
            var items = new List<string[]>
            {
                new string[]{ "1", "2" },
                new string[]{ "2", "1" }
            };
            var item = new string[] { "2", "1" };

            // Act
            var result = _privateType.InvokeStatic(AlreadyDisplayedMethodName, items, item) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeTrue());
        }

        [TestMethod]
        public void GetXMLSafeVersion_Should_ReturnExepctedSafeValue()
        {
            // Arrange
            const string Value = "&dummy<value>";
            const string ExpectedValue = "#amp#dummy#lt#value#gt#";

            // Act
            var result = _privateType.InvokeStatic(GetXMLSafeVersionMethodName, Value) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void UpdateComment_CommentListNull_ThrowException()
        {
            // Arrange
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => null;

            // Act
            Action action = () => CommentManager.UpdateComment(DummyString);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void UpdateComment()
        {
            // Arrange
            const string CommentItemIdKey = "CommentItemId";
            const int CommentItemId = 1;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                }
            };
            ShimXMLDataManager.AllInstances.GetPropValString = (_, xml) =>
            {
                switch (xml)
                {
                    case StatusUpdateKey:
                        return bool.TrueString;
                    case StatusUpdateIdKey:
                        return Guid.NewGuid().ToString();
                    case ListIdKey:
                        return Guid.NewGuid().ToString();
                    case ItemIdKey:
                        return "2";
                    case CommentKey:
                        return DummyString;
                    case CommentItemIdKey:
                        return CommentItemId.ToString();
                    default:
                        return null;
                }
            };
            ShimSPList.AllInstances.GetItemsSPQuery = (_, query) => new ShimSPListItemCollection
            {
                CountGet = () => 1,
                GetEnumerator = () => new List<SPListItem>
                {
                    new ShimSPListItem
                    {
                        IDGet = () => CommentItemId,
                    }
                }.GetEnumerator()
            };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                NameGet = () => DummyString
            };

            // Act
            CommentManager.UpdateComment(DummyString);

            // Assert

        }


    }
}
