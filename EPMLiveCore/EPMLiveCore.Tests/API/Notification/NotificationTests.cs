using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    using EPMLiveCore.API;
    using EPMLiveCore;
    using System.Xml.Linq;
    using System.Reflection;
    using Shouldly;
    using System.Xml.Linq.Fakes;
    using System.Data.SqlClient.Fakes;
    using System.Data.SqlClient;
    using System.Collections;
    using Microsoft.SharePoint.Fakes;
    using Microsoft.SharePoint;
    using Fakes;
    using Microsoft.SharePoint.Administration.Fakes;
    using PortfolioEngineCore.Fakes;
    using System.Text.RegularExpressions;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class NotificationTests
    {
        private IDisposable shimsContext;
        private PrivateType privateType;
        private const string EPMNotificationFullName = "EPMLiveCore.API.Notification+EPMNotification";
        private const string DummyString = "DummyString";
        private const int DummyInt = 10;
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private static readonly DateTime DummyDate = DateTime.UtcNow;
        private string BuildNotificationElementMethodName = "BuildNotificationElement";
        private string GetNotificationsMethodName = "GetNotifications";
        private string GetNotificationsForTheFirstLoadMethodName = "GetNotificationsForTheFirstLoad";
        private string GetPagingConstraintsMethodName = "GetPagingConstraints";
        private const string Status = "Status";
        private const string FirstLoad = "FirstLoad";
        private string SetNotificationFlagMethodName = "SetNotificationFlag";

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

        private object CreateEPMNotification()
        {
            var type = GetEPMNotificationType();

            var instance = Activator.CreateInstance(type);

            foreach (var field in type.GetFields())
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

        private object CreateEPMNotification(IDictionary<string, object> values)
        {
            var type = GetEPMNotificationType();

            var instance = Activator.CreateInstance(type);


            foreach (var item in values)
            {
                var field = type.GetField(item.Key);
                field?.SetValue(instance, item.Value);
            }

            //foreach (var field in type.GetFields())
            //{
            //    if (field.FieldType == typeof(string))
            //    {
            //        field.SetValue(instance, DummyString);
            //    }
            //    else if (field.FieldType == typeof(int))
            //    {
            //        field.SetValue(instance, DummyInt);
            //    }
            //    else if (field.FieldType == typeof(Guid))
            //    {
            //        field.SetValue(instance, DummyGuid);
            //    }
            //    else if (field.FieldType == typeof(bool))
            //    {
            //        field.SetValue(instance, true);
            //    }
            //}
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
