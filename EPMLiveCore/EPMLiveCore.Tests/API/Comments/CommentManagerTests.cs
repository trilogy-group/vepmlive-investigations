﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.SocialEngine;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
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

        [TestInitialize]
        public void Initialize()
        {
            _shimContext = ShimsContext.Create();
            SetupShims();
            _commentManager = new CommentManager();
            _privateObject = new PrivateObject(_commentManager);
            _privateType = new PrivateType(typeof(CommentManager));
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();
            ShimHttpContext.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimSPSite.AllInstances.MakeFullUrlString = (_, url) => DummyUrl;
        }

        [TestCleanup]
        public void Cleanup()
        {

            _shimContext?.Dispose();
        }


        [TestMethod]
        public void DeleteFromSocialStream()
        {
            // Arrange
            var currentWeb = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.NewGuid()
                },
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => 1
                }
            }.Instance;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                RegionalSettingsGet = () => new ShimSPRegionalSettings
                {
                    TimeZoneGet = () => new ShimSPTimeZone
                    {
                        UTCToLocalTimeDateTime = date => DateTime.Now
                    }
                }
            };
            
            // Act
            _privateType.InvokeStatic(
                DeleteFromSocialStreamMethodName,
                DummyString,
                DummyString, 
                Guid.NewGuid(),
                1,
                DummyUrl,
                Guid.NewGuid(),
                currentWeb);

            // Assert

        }

        [TestMethod]
        public void InsertCommentCount()
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail("Not Implemented");
        }

        [TestMethod]
        public void SetSocialEngineTransaction_Should_SetTransaction()
        {
            // Arrange
            var setTransactionWasCalled = false;
            var listItem = new ShimSPListItem
            {

            }.Instance;
            ShimSocialEngineProxy.SetTransactionGuidGuidInt32StringSPWeb =
                (guid, listId, itemId, componentName, web) =>
                {
                    setTransactionWasCalled = false;
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
        public void GetMyCommentsByDate_OnSuccess_QueueItemMessage()
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
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPField
                {
                    IdGet = () => Guid.NewGuid() // null on next test
                }
            };
            //ShimCommentManager

            // Act
            var result = _privateType.InvokeStatic(
                SendEmailNotificationMethodName, 
                1, Guid.NewGuid().ToString(), "1", DummyString, DummyString) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeTrue(),
                () => messageQueued.ShouldBeTrue());
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


    }
}
