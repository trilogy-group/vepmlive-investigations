using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Linq.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API
{
    using EPMLiveCore.API;
    using EPMLiveCore.API.Fakes;
    using Fakes;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class NotificationTests
    {
        private const int DummyInt = 10;
        private const string EPMNotificationFullName = "EPMLiveCore.API.Notification+EPMNotification";
        private const string DummyString = "DummyString";
        private const string BuildNotificationElementMethodName = "BuildNotificationElement";
        private const string GetNotificationsMethodName = "GetNotifications";
        private const string GetNotificationsForTheFirstLoadMethodName = "GetNotificationsForTheFirstLoad";
        private const string GetPagingConstraintsMethodName = "GetPagingConstraints";
        private const string Status = "Status";
        private const string FirstLoad = "FirstLoad";
        private const string SetNotificationFlagMethodName = "SetNotificationFlag";
        private const string TranslateNotificationToPersonalizationMethodName = "TranslateNotificationToPersonalization";
        private const string ValidateSetNotificationFlagsInputDataMethodName = "ValidateSetNotificationFlagsInputData";
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private static readonly DateTime DummyDate = DateTime.UtcNow;
        private IDisposable shimsContext;
        private PrivateType privateType;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            privateType = new PrivateType(typeof(Notification));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSqlConnection.ConstructorString = (_, connection) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyString;
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, id) => new ShimSPUser();
        }

        [TestMethod]
        public void BuildNotificationElement_Should_AddElement()
        {
            // Arrange
            var result = new ShimXDocument
            {
                RootGet = () => new ShimXElement()
            }.Instance;
            var epmNotification = CreateEPMNotification();
            var objectAdded = new object();
            ShimXContainer.AllInstances.AddObject = (_, element) =>
            {
                objectAdded = element;
            };

            // Act
            privateType.InvokeStatic(BuildNotificationElementMethodName, result, epmNotification);
            var notificationElement = objectAdded as XElement;

            // Assert
            notificationElement.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetNotifications_Should_ReturnList()
        {
            // Arrange
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                GetOrdinalString = name => 1,
                GetGuidInt32 = i => DummyGuid,
                GetInt32Int32 = i => DummyInt,
                GetStringInt32 = i => DummyString,
                GetValueInt32 = i => DummyString,
                GetBooleanInt32 = i => true,
                GetDateTimeInt32 = i => DummyDate
            };
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings
            {
                LocaleIdGet = () => 6153,
                TimeZoneGet = () => new ShimSPTimeZone
                {
                    UTCToLocalTimeDateTime = date => date
                }
            };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, id) => new ShimSPUser
            {
                NameGet = () => DummyString,
                LoginNameGet = () => DummyString
            };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    SiteUserInfoListGet = () => new ShimSPList
                    {
                        GetItemByIdInt32 = id => new ShimSPListItem
                        {
                            ItemGetString = name => DummyString
                        }
                    }
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetNotificationsMethodName, DummyString, 1, 1, 1) as IEnumerable;

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetNotifications_OnAPIException_ThrowsException()
        {
            // Arrange
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) =>
            {
                throw new APIException(1, DummyString);
            };

            // Act
            Action action = () => privateType.InvokeStatic(GetNotificationsMethodName, DummyString, 1, 1, 1);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void GetNotifications_OnException_ThrowsException()
        {
            // Arrange
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) =>
            {
                throw new Exception();
            };

            // Act
            Action action = () => privateType.InvokeStatic(GetNotificationsMethodName, DummyString, 1, 1, 1);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void GetNotificationsForTheFirstLoad_StatusNotALL_ReturnsEmpty()
        {
            // Arrange, Act
            var result = privateType.InvokeStatic(GetNotificationsForTheFirstLoadMethodName, DummyString, 1, 1, 1) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void GetNotificationsForTheFirstLoad_StatusALL_ReturnsNotificationContent()
        {
            // Arrange
            var expectedContent = $"<Notification ID=\"{DummyGuid}\" Type=\"10\"";
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                GetOrdinalString = name => 1,
                GetGuidInt32 = i => DummyGuid,
                GetInt32Int32 = i => DummyInt,
                GetStringInt32 = i => DummyString,
                GetValueInt32 = i => DummyString,
                GetBooleanInt32 = i => true,
                GetDateTimeInt32 = i => DummyDate
            };
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings
            {
                LocaleIdGet = () => 6153,
                TimeZoneGet = () => new ShimSPTimeZone
                {
                    UTCToLocalTimeDateTime = date => date
                }
            };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, id) => new ShimSPUser
            {
                NameGet = () => DummyString,
                LoginNameGet = () => DummyString
            };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    SiteUserInfoListGet = () => new ShimSPList
                    {
                        GetItemByIdInt32 = id => new ShimSPListItem
                        {
                            ItemGetString = name => DummyString
                        }
                    }
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetNotificationsForTheFirstLoadMethodName, "ALL", 1, 1, 1) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expectedContent));
        }

        [TestMethod]
        public void GetNotificationsForTheFirstLoad_NotificationListMGreaterThan15_ReturnsNotificationContent()
        {
            // Arrange
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 17,
                GetOrdinalString = name => 1,
                GetGuidInt32 = i => DummyGuid,
                GetInt32Int32 = i => DummyInt,
                GetStringInt32 = i => DummyString,
                GetValueInt32 = i => DummyString,
                GetBooleanInt32 = i => true,
                GetDateTimeInt32 = i => DummyDate
            };
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings
            {
                LocaleIdGet = () => 6153,
                TimeZoneGet = () => new ShimSPTimeZone
                {
                    UTCToLocalTimeDateTime = date => date
                }
            };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, id) => new ShimSPUser
            {
                NameGet = () => DummyString,
                LoginNameGet = () => DummyString
            };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    SiteUserInfoListGet = () => new ShimSPList
                    {
                        GetItemByIdInt32 = id => new ShimSPListItem
                        {
                            ItemGetString = name => DummyString
                        }
                    }
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetNotificationsForTheFirstLoadMethodName, "ALL", 1, 1, 1) as string;
            var notificationCount = new Regex("<Notification ").Matches(result).Count;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => notificationCount.ShouldBe(15));
        }

        [TestMethod]
        public void GetPagingConstraints_DocumentRootNull_ThrowsAPIException()
        {
            // Arrange
            var args = new object[] { DummyString, string.Empty, 0, 0, 0, false };
            ShimXDocument.ParseString = content => new XDocument();

            // Act
            Action action = () => privateType.InvokeStatic(GetPagingConstraintsMethodName, args);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void GetPagingConstraints_UnkownStatus_ThrowsException()
        {
            // Arrange
            var args = new object[] { DummyString, string.Empty, 0, 0, 0, false };
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    },
                    AttributeXName = name => new XAttribute(name, DummyString)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(GetPagingConstraintsMethodName, args);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void GetPagingConstraints_Should_ExecuteCorrectly()
        {
            // Arrange
            var args = new object[] { DummyString, string.Empty, 0, 0, 0, false };
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    },
                    AttributeXName = name =>
                    {
                        switch (name.LocalName)
                        {
                            case Status:
                                return new XAttribute(name, "ALL");
                            case FirstLoad:
                                return new XAttribute(name, true);
                            default:
                                return new XAttribute(name, 1);
                        }
                    }
                }
            };

            // Act
            privateType.InvokeStatic(GetPagingConstraintsMethodName, args);
            var notificationStatus = args[1] as string;
            var firstPage = args[2] as int?;
            var lastPage = args[3] as int?;
            var limit = args[4] as int?;
            var firstLoad = args[5] as bool?;

            // Assert
            args.ShouldSatisfyAllConditions(
                () => notificationStatus.ShouldNotBeNullOrEmpty(),
                () => notificationStatus.ShouldBe("ALL"),
                () => firstPage.ShouldNotBeNull(),
                () => firstPage.Value.ShouldBe(1),
                () => lastPage.ShouldNotBeNull(),
                () => lastPage.Value.ShouldBe(1),
                () => limit.ShouldNotBeNull(),
                () => limit.Value.ShouldBe(1),
                () => firstLoad.GetValueOrDefault().ShouldBeTrue());
        }

        [TestMethod]
        public void SetNotificationFlag_SqlConnectionNull_ThrowsExcetion()
        {
            // Arrange
            var notification = CreateEPMNotification();
            var user = new ShimSPUser().Instance;
            var args = new object[] { notification, null, user };

            // Act
            Action action = () => privateType.InvokeStatic(SetNotificationFlagMethodName, args);

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void SetNotificationFlag_SPUserNull_ThrowsExcetion()
        {
            // Arrange
            var notification = CreateEPMNotification();
            var args = new object[] { notification, new SqlConnection(), null };

            // Act
            Action action = () => privateType.InvokeStatic(SetNotificationFlagMethodName, args);

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void SetNotificationFlag_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "spNSetBit";
            var executedCommand = string.Empty;
            var notification = CreateEPMNotification();
            var connection = new SqlConnection();
            var user = new ShimSPUser
            {
                LoginNameGet = () => DummyString,
                IDGet = () => 1
            }.Instance;
            var args = new object[] { notification, new SqlConnection(), user };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommand = command.CommandText;
                return 1;
            };

            // Act
            privateType.InvokeStatic(SetNotificationFlagMethodName, args);

            // Assert
            executedCommand.ShouldSatisfyAllConditions(
                () => executedCommand.ShouldNotBeNullOrEmpty(),
                () => executedCommand.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void TranslateNotificationToPersonalization_SqlConnectionNull_ThrowsExcetion()
        {
            // Arrange
            var notification = CreateEPMNotification();
            var user = new ShimSPUser().Instance;
            var args = new object[] { notification, null, user };

            // Act
            Action action = () => privateType.InvokeStatic(TranslateNotificationToPersonalizationMethodName, args);

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void TranslateNotificationToPersonalization_SPUserNull_ThrowsExcetion()
        {
            // Arrange
            var notification = CreateEPMNotification();
            var args = new object[] { notification, new SqlConnection(), null };

            // Act
            Action action = () => privateType.InvokeStatic(TranslateNotificationToPersonalizationMethodName, args);

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void TranslateNotificationToPersonalization_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedCommand = "spNTranslateNotificationToPersonalization";
            var executedCommand = string.Empty;
            var notification = CreateEPMNotification();
            var connection = new SqlConnection();
            var user = new ShimSPUser
            {
                LoginNameGet = () => DummyString,
                IDGet = () => 1
            }.Instance;
            var args = new object[] { notification, new SqlConnection(), user };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommand = command.CommandText;
                return 1;
            };

            // Act
            privateType.InvokeStatic(TranslateNotificationToPersonalizationMethodName, args);

            // Assert
            executedCommand.ShouldSatisfyAllConditions(
                () => executedCommand.ShouldNotBeNullOrEmpty(),
                () => executedCommand.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void GetNotifications_FirstLoad_CallsGetNotificationsForTheFirstLoad()
        {
            // Arrange
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    },
                    AttributeXName = name =>
                    {
                        switch (name.LocalName)
                        {
                            case Status:
                                return new XAttribute(name, "ALL");
                            case FirstLoad:
                                return new XAttribute(name, true);
                            default:
                                return new XAttribute(name, 1);
                        }
                    }
                }
            };
            var getNotificationsForTheFirstLoadWasCalled = false;
            ShimNotification.GetNotificationsForTheFirstLoadStringInt32Int32Int32 = (status, limit, first, last) =>
            {
                getNotificationsForTheFirstLoadWasCalled = true;
                return DummyString;
            };

            // Act
            var result = Notification.GetNotifications(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString),
                () => getNotificationsForTheFirstLoadWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void GetNotifications_FirstLoadFalse_ReturnNotifications()
        {
            // Arrange
            var expectedValue = $"<Notification ID=\"{DummyGuid}\" Type=\"{DummyInt}\"";
            ShimXDocument.ParseString = content => new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    },
                    AttributeXName = name =>
                    {
                        switch (name.LocalName)
                        {
                            case Status:
                                return new XAttribute(name, "ALL");
                            case FirstLoad:
                                return new XAttribute(name, false);
                            default:
                                return new XAttribute(name, 1);
                        }
                    }
                }
            };
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                GetOrdinalString = name => 1,
                GetGuidInt32 = i => DummyGuid,
                GetInt32Int32 = i => DummyInt,
                GetStringInt32 = i => DummyString,
                GetValueInt32 = i => DummyString,
                GetBooleanInt32 = i => true,
                GetDateTimeInt32 = i => DummyDate
            };
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings
            {
                LocaleIdGet = () => 6153,
                TimeZoneGet = () => new ShimSPTimeZone
                {
                    UTCToLocalTimeDateTime = date => date
                }
            };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, id) => new ShimSPUser
            {
                NameGet = () => DummyString,
                LoginNameGet = () => DummyString
            };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    SiteUserInfoListGet = () => new ShimSPList
                    {
                        GetItemByIdInt32 = id => new ShimSPListItem
                        {
                            ItemGetString = name => DummyString
                        }
                    }
                }
            };

            // Act
            var result = Notification.GetNotifications(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expectedValue));
        }

        [TestMethod]
        public void GetNotifications_OnException_ThrowsAPIException()
        {
            // Arrange
            ShimXDocument.ParseString = content =>
            {
                throw new Exception();
            };

            // Act
            Action action = () => Notification.GetNotifications(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void GetNotifications_OnAPIException_ThrowsAPIException()
        {
            // Arrange
            ShimXDocument.ParseString = content =>
            {
                throw new APIException(1, string.Empty);
            };

            // Act
            Action action = () => Notification.GetNotifications(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void SetNotificationFlags_MarkAllReadAttribute_ReturnsContent()
        {
            // Arrange
            var count = 0;
            ShimNotification.ValidateSetNotificationFlagsInputDataXDocument = _ => { };
            ShimXDocument.ParseString = _ => new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    AttributeXName = name => new XAttribute(name, true)
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                GetOrdinalString = name => 1,
                GetGuidInt32 = i => DummyGuid,
                GetInt32Int32 = i => DummyInt,
                GetStringInt32 = i => DummyString,
                GetValueInt32 = i => DummyString,
                GetBooleanInt32 = i => true,
                GetDateTimeInt32 = i => DummyDate
            };
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings
            {
                LocaleIdGet = () => 6153,
                TimeZoneGet = () => new ShimSPTimeZone
                {
                    UTCToLocalTimeDateTime = date => date
                }
            };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, id) => new ShimSPUser
            {
                NameGet = () => DummyString,
                LoginNameGet = () => DummyString
            };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    SiteUserInfoListGet = () => new ShimSPList
                    {
                        GetItemByIdInt32 = id => new ShimSPListItem
                        {
                            ItemGetString = name => DummyString
                        }
                    }
                }
            };

            // Act
            var result = Notification.SetNotificationFlags(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();

        }

        [TestMethod]
        public void SetNotificationFlags_MarkAllReadAttributeFalse_ReturnsContent()
        {
            // Arrange
            const string IdAttribute = "ID";
            const string TypeAttribute = "Type";
            var rootElements = true;
            ShimNotification.ValidateSetNotificationFlagsInputDataXDocument = _ => { };
            ShimXDocument.ParseString = _ => new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    AttributeXName = name => new XAttribute(name, false)
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimXContainer.AllInstances.ElementsXName = (_, name) =>
            {
                if (rootElements)
                {
                    rootElements = false;
                    return new List<XElement>
                    {
                        new ShimXElement()
                        {
                            AttributeXName = attrName =>
                            {
                                return attrName == IdAttribute
                                    ? new XAttribute(name, DummyGuid)
                                    : new XAttribute(name, 1);
                            },
                        }
                    };
                }
                else
                {
                    return new List<XElement>
                    {
                        new ShimXElement()
                        {
                            AttributeXName = attrName =>
                            {
                                return attrName == TypeAttribute
                                    ? new XAttribute(name, "EMAILED")
                                    : new XAttribute(name, true);
                            }
                        },
                        new ShimXElement()
                        {
                            AttributeXName = attrName =>
                            {
                                return attrName == TypeAttribute
                                    ? new XAttribute(name, "READ")
                                    : new XAttribute(name, true);
                            }
                        }
                    };
                }
            };

            // Act
            var result = Notification.SetNotificationFlags(DummyString);

            // Assert
            result.ShouldNotBeNullOrEmpty();
        }

        [TestMethod]
        public void SetNotificationFlags_OnException_ThrowsAPIException()
        {
            // Arrange
            ShimNotification.ValidateSetNotificationFlagsInputDataXDocument = _ => { };
            ShimXDocument.ParseString = _ =>
            {
                throw new Exception();
            };
            
            // Act
            Action action = () => Notification.SetNotificationFlags(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void SetNotificationFlags_OnAPIException_ThrowsAPIException()
        {
            // Arrange
            ShimNotification.ValidateSetNotificationFlagsInputDataXDocument = _ => { };
            ShimXDocument.ParseString = _ =>
            {
                throw new APIException(1, string.Empty);
            };

            // Act
            Action action = () => Notification.SetNotificationFlags(DummyString);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ValidateSetNotificationFlagsInputData_RootElementNull_ThrowsException()
        {
            // Arrange
            var xDocument = new ShimXDocument
            {
                RootGet = () => null
            }.Instance;

            // Act
            Action action = () => privateType.InvokeStatic(ValidateSetNotificationFlagsInputDataMethodName, xDocument);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ValidateSetNotificationFlagsInputData_AttributeIdMissing_ThrowsException()
        {
            // Arrange
            var xDocument = new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    }
                }
            }.Instance;
            ShimXContainer.AllInstances.ElementsXName = (_, elementName) => new List<XElement>
            {
                new ShimXElement
                {
                    Attributes = () => new List<XAttribute>()
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ValidateSetNotificationFlagsInputDataMethodName, xDocument);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ValidateSetNotificationFlagsInputData_AttributeTypeMissing_ThrowsException()
        {
            // Arrange
            var xDocument = new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    }
                }
            }.Instance;
            ShimXContainer.AllInstances.ElementsXName = (_, elementName) => new List<XElement>
            {
                new ShimXElement
                {
                    Attributes = () => new List<XAttribute>
                    {
                        new XAttribute("ID", DummyInt),
                    }
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ValidateSetNotificationFlagsInputDataMethodName, xDocument);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ValidateSetNotificationFlagsInputData_AttributeTypeNotAInteger_ThrowsException()
        {
            // Arrange
            var xDocument = new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    }
                }
            }.Instance;
            ShimXContainer.AllInstances.ElementsXName = (_, elementName) => new List<XElement>
            {
                new ShimXElement
                {
                    Attributes = () => new List<XAttribute>
                    {
                        new XAttribute("ID", DummyInt),
                        new XAttribute("Type", DummyString)
                    },
                    AttributeXName = name => new XAttribute(name, DummyString)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ValidateSetNotificationFlagsInputDataMethodName, xDocument);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ValidateSetNotificationFlagsInputData_AttributeNotFoundOnValidInputs_ThrowsException()
        {
            // Arrange
            const string FlagElement = "Flag";
            var xDocument = new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    }
                }
            }.Instance;
            ShimXContainer.AllInstances.ElementsXName = (_, elementName) =>
            {
                if (elementName == FlagElement)
                {
                    return new List<XElement>
                    {
                         new ShimXElement
                        {
                            Attributes = () => new List<XAttribute>
                            {
                                new XAttribute("ID", DummyInt),
                            },
                            AttributeXName = name => new XAttribute(name, DummyInt)
                        }
                    };
                }
                else
                {
                    return new List<XElement>
                    {
                        new ShimXElement
                        {
                            Attributes = () => new List<XAttribute>
                            {
                                new XAttribute("ID", DummyInt),
                                new XAttribute("Type", DummyString)
                            },
                            AttributeXName = name => new XAttribute(name, DummyInt)
                        }
                    };
                }
            };
            

            // Act
            Action action = () => privateType.InvokeStatic(ValidateSetNotificationFlagsInputDataMethodName, xDocument);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ValidateSetNotificationFlagsInputData_AttributeValueNotValid_ThrowsException()
        {
            // Arrange
            var xDocument = new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    }
                }
            }.Instance;
            ShimXContainer.AllInstances.ElementsXName = (_, elementName) => new List<XElement>
            {
                new ShimXElement
                {
                    Attributes = () => new List<XAttribute>
                    {
                        new XAttribute("ID", DummyInt),
                        new XAttribute("Type", DummyString)
                    },
                    AttributeXName = name => new XAttribute(name, DummyInt)
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ValidateSetNotificationFlagsInputDataMethodName, xDocument);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ValidateSetNotificationFlagsInputData_NoFlagsElements_ThrowsException()
        {
            // Arrange
            const string FlagElement = "Flag";
            var xDocument = new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    }
                }
            }.Instance;
            ShimXContainer.AllInstances.ElementsXName = (_, elementName) =>
            {
                if (elementName == FlagElement)
                {
                    return new List<XElement>();
                }
                else
                {
                    return new List<XElement>
                    {
                        new ShimXElement
                        {
                            Attributes = () => new List<XAttribute>
                            {
                                new XAttribute("ID", true),
                                new XAttribute("Type", "EMAILED")
                            },
                            AttributeXName = name => new XAttribute(name, DummyInt)
                        }
                    };
                }
            };

            // Act
            Action action = () => privateType.InvokeStatic(ValidateSetNotificationFlagsInputDataMethodName, xDocument);

            // Assert
            action.ShouldThrow<APIException>();
        }

        [TestMethod]
        public void ValidateSetNotificationFlagsInputData_NoNotificationElements_ThrowsException()
        {
            // Arrange
            var xDocument = new ShimXDocument
            {
                RootGet = () => new ShimXElement
                {
                    NameGet = () => new ShimXName
                    {
                        LocalNameGet = () => "Notifications"
                    }
                }
            }.Instance;
            ShimXContainer.AllInstances.ElementsXName = (_, elementName) => new List<XElement>();

            // Act
            Action action = () => privateType.InvokeStatic(ValidateSetNotificationFlagsInputDataMethodName, xDocument);

            // Assert
            action.ShouldThrow<APIException>();
        }

        private object CreateEPMNotification()
        {
            var instance = Activator.CreateInstance(EPMNotificationType);

            foreach (var field in EPMNotificationType.GetFields())
            {
                if (field.FieldType == typeof(string))
                {
                    field.SetValue(instance, DummyString);
                }
                else if (field.FieldType == typeof(int))
                {
                    field.SetValue(instance, DummyInt);
                }
                else if (field.FieldType == typeof(Guid))
                {
                    field.SetValue(instance, DummyGuid);
                }
                else if (field.FieldType == typeof(bool))
                {
                    field.SetValue(instance, true);
                }
            }
            return instance;
        }
        
        private static Type EPMNotificationType
        {
            get
            {
                return GetEPMNotificationType();
            }
        }

        private static Type GetEPMNotificationType()
        {
            var types = EPMLiveCoreAssembly?.GetTypes().Where(p => p.FullName == EPMNotificationFullName);
            return types.FirstOrDefault();
        }

        private static Assembly EPMLiveCoreAssembly
        {
            get
            {
                return GetEPMLiveCoreAssembly();
            }
        }

        private static Assembly GetEPMLiveCoreAssembly()
        {
            return Assembly.LoadFrom("EPM Live Core.dll");
        }
    }
}
