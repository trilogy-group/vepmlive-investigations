using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.Specialized.Fakes;
using System.Data.SqlClient.Fakes;
using System.Globalization;
using System.IO.Fakes;
using System.Net.Mail.Fakes;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.Jobs;
using EPMLiveCore.Jobs.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static EPMLiveCore.Jobs.Notifications;

namespace EPMLiveCore.Tests.Jobs
{
    [TestClass]
    public class NotificationsTests
    {
        protected internal const string SendEmailMethodName = "sendEmail";
        protected internal const string CreateMsgBodyMethodName = "createMsgBody";

        protected internal const string DummyUserEmail = "DummyUserEmail@gmail.com";
        protected internal const string DummyFromEmail = "DummyFromEmail@gmail.com";
        protected internal const string DummySubject = "DummySubject";
        protected internal const string DummyUserDisplayName = "DummyUserDisplayName";
        protected internal const string DummyServerName = "DummyServerName";
        private const string SpWebUrl = "http://www.url.com";

        private IDisposable _context;
        private Notifications _notifications;
        private PrivateObject _privateObject;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _notifications = new Notifications();
            _privateObject = new PrivateObject(_notifications);
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void SendEmail_DisposesProperly()
        {
            // Arrange
            var writerDisposeCalled = false;
            var smtpDisposeCalled = false;
            var sendCalled = false;
            ShimSmtpClient.AllInstances.SendMailMessage = (_1, _2) =>
            {
                if (smtpDisposeCalled)
                {
                    throw new InvalidOperationException("Smtp Client shouldn't dispose before sending");
                }
                sendCalled = true;
            };
            ShimSmtpClient.AllInstances.Dispose = _ => smtpDisposeCalled = true;
            ShimMailMessage.AllInstances.Dispose = _ =>
            {
                if (!smtpDisposeCalled
                    || !sendCalled)
                {
                    throw new InvalidOperationException("Mail Message can only be disposed after client send message and properly disposed");
                }
                writerDisposeCalled = true;
            };

            ShimSPAdministrationWebApplication.LocalGet = () =>
            {
                var spAdministrationWebApplication = new ShimSPAdministrationWebApplication();
                var spWebApplication = new ShimSPWebApplication(spAdministrationWebApplication)
                {
                    OutboundMailServiceInstanceGet = () =>
                    {
                        var spOutboundMailServiceInstance = new ShimSPOutboundMailServiceInstance();
                        var spServiceInstance = new ShimSPServiceInstance(spOutboundMailServiceInstance)
                        {
                            ServerGet = () =>
                            {
                                var spServer = new ShimSPServer();
                                var spPersistedOb = new ShimSPPersistedObject(spServer)
                                {
                                    NameGet = () => DummyServerName
                                };
                                return spServer;
                            }
                        };
                        return spOutboundMailServiceInstance;
                    }
                };
                return spAdministrationWebApplication;
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();

            // Act
            _privateObject.Invoke(
                SendEmailMethodName,
                DummyUserEmail,
                DummyFromEmail,
                DummySubject,
                DummyUserDisplayName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => writerDisposeCalled.ShouldBeTrue(),
                () => smtpDisposeCalled.ShouldBeTrue(),
                () => sendCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void CreateMsgBody_DisposesProperly()
        {
            // Arrange
            var stringWriterDisposed = false;
            var htmlWriterDisposed = false;

            ShimHtmlTextWriter.AllInstances.WriteString = (_1, _2) => { };
            ShimHtmlTextWriter.AllInstances.WriteStringObject = (_1, _2, _3) => { };

            ShimStringWriter.Constructor = writer =>
            {
                var shimWriter = new ShimStringWriter(writer)
                {
                    ToString = () => string.Empty
                };
                var textWriter = new ShimTextWriter(shimWriter)
                {
                    Dispose = () => stringWriterDisposed = true
                };
            };

            ShimHtmlTextWriter.ConstructorTextWriter = (writer, _) =>
            {
                var shimWriter = new ShimHtmlTextWriter(writer);
                var textWriter = new ShimTextWriter(shimWriter)
                {
                    Dispose = () =>
                    {
                        if (stringWriterDisposed)
                        {
                            throw new InvalidOperationException("HtmlTextWriter shouldn't dispose before  the inner stringWriter");
                        }
                        htmlWriterDisposed = true;
                    }
                };
            };
            ShimHttpUtility.HtmlDecodeString = s => s;
            ShimNotifications.AllInstances.convertDataToHTMLHtmlTextWriter = (_1, _2) => { };

            // Act
            _privateObject.Invoke(CreateMsgBodyMethodName, DummyUserDisplayName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => stringWriterDisposed.ShouldBeTrue(),
                () => htmlWriterDisposed.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_Always_SetExpectedValues()
        {
            // Arrange
            var shimSpWeb = ArrangeForExecute();
            var shim = new ShimSPWebCollection();
            var list = new List<SPWeb>
            {
                ArrangeForExecute()
            };
            new ShimSPBaseCollection(shim)
            {
                GetEnumerator = () => list.GetEnumerator()
            };
            shimSpWeb.WebsGet = () => shim;
            var shimSite = new ShimSPSite
            {
                RootWebGet = () => shimSpWeb
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated =
                codeToRun => codeToRun();
            ShimSPAdministrationWebApplication.LocalGet = () =>
            {
                var shimSPAdministrationWebApplication = new ShimSPAdministrationWebApplication();
                new ShimSPWebApplication(shimSPAdministrationWebApplication)
                {
                    OutboundMailServiceInstanceGet = () =>
                    {
                        var shimSPOutboundMailServiceInstance = new ShimSPOutboundMailServiceInstance();
                        new ShimSPServiceInstance(shimSPOutboundMailServiceInstance)
                        {
                            ServerGet = () =>
                            {
                                var shimSPServer = new ShimSPServer();
                                new ShimSPPersistedObject(shimSPServer)
                                {
                                    NameGet = () => "SPPersistedObject"
                                };
                                return shimSPServer;
                            }
                        };
                        return shimSPOutboundMailServiceInstance;
                    }
                };
                return shimSPAdministrationWebApplication;
            };
            ShimMailAddress.ConstructorString = (instance, address) => new ShimMailAddress(instance);
            ShimSmtpClient.Constructor = instance => new ShimSmtpClient(instance)
            {
                SendMailMessage = mailMessage => { }
            };
            ShimSqlConnection.AllInstances.Open = instance => { };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance => 0;
            var data = string.Empty;
            _notifications.EmailSubject = null;
            _notifications.FromEmail = null;
            _notifications.LogDetailedErrors = true;

            // Act
            _notifications.execute(
                shimSite,
                shimSpWeb,
                data);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ((string)_privateObject.GetFieldOrProperty("sMainURL")).ShouldBe(SpWebUrl),
                () => _notifications.FromEmail.ShouldBe("EPMLiveNotificationEmail"),
                () => _notifications.EmailSubject.ShouldBe("EPMLiveNotificationEmailSubject"),
                () => _notifications.LogDetailedErrors.ShouldBeFalse(),
                () => _notifications.ErrorLogDetailLevel.ShouldBe(ErrorLogDetailLevelEnum.SectionLevelErrors));
        }

        [TestMethod]
        public void ProcessField_Always_ReturnExpectedValueForDateTime()
        {
            // Arrange
            SPWeb spWeb = new ShimSPWeb
            {
                LocaleGet = () => new CultureInfo("en-US")
            };
            SPListItem listItem = new ShimSPListItem
            {
                ItemGetGuid = guidValue => "2018-12-05 00:00:00"
            };
            SPField field = new ShimSPField
            {
                TypeGet = () => SPFieldType.DateTime,
                SchemaXmlGet = () => "format=\"DATEONLY\""
            };

            // Act
            var result = _privateObject.Invoke(
                "ProcessField",
                spWeb,
                listItem,
                field) as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe("12/5/2018"));
        }

        [TestMethod]
        public void ProcessField_Always_ReturnExpectedValueForNumber()
        {
            // Arrange
            SPWeb spWeb = new ShimSPWeb
            {
                LocaleGet = () => new CultureInfo("en-US")
            };
            SPListItem listItem = new ShimSPListItem
            {
                ItemGetGuid = guidValue => "1"
            };
            SPField field = new ShimSPFieldNumber
            {
                ShowAsPercentageGet = () => true
            };
            new ShimSPField(field)
            {
                TypeGet = () => SPFieldType.Number
            };

            // Act
            var result = _privateObject.Invoke(
                "ProcessField",
                spWeb,
                listItem,
                field) as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe("100%"));
        }

        private ShimSPWeb ArrangeForExecute()
        {
            var list = new List<SPUser>
            {
                new ShimSPUser
                {
                    IDGet = () => 11,
                    NameGet = () => "Name",
                    EmailGet = () => "Email"
                }
            };
            var shimSPUserCollection = new ShimSPUserCollection
            {
                GetByIDInt32 = intValue => list[0]
            };
            new ShimSPBaseCollection(shimSPUserCollection)
            {
                GetEnumerator = () => list.GetEnumerator()
            };
            return new ShimSPWeb
            {
                AllUsersGet = () => shimSPUserCollection,
                ListsGet = () =>
                {
                    var listSpList = new List<SPList>
                    {
                        new ShimSPList
                        {
                            GetItemsSPQuery = spQuery =>
                            {
                                var listSPField = new List<SPField>
                                {
                                    new ShimSPField
                                    {
                                        InternalNameGet = () => "InternalName",
                                        SchemaXmlGet = () => " Percentage=\"TRUE\""
                                    }
                                };
                                var listListItem = new List<SPListItem>
                                {
                                    new ShimSPListItem
                                    {
                                        FieldsGet = () =>
                                        {
                                            var shimSPFieldCollection = new ShimSPFieldCollection
                                            {
                                                GetFieldByInternalNameString = stringValue => listSPField[0]
                                            };
                                            new ShimSPBaseCollection(shimSPUserCollection)
                                            {
                                                GetEnumerator = () => listSPField.GetEnumerator()
                                            };
                                            return shimSPFieldCollection;
                                        },
                                        ItemGetGuid = guidValue => "2018-05-12"
                                    }
                                };
                                var shimSPListItemCollection = new ShimSPListItemCollection
                                {
                                    CountGet = () => listListItem.Count,
                                    GetEnumerator = () => listListItem.GetEnumerator()
                                };
                                return shimSPListItemCollection;
                            }
                        }
                    };
                    var shim = new ShimSPListCollection
                    {
                        ItemGetString = stringValue => listSpList[0]
                    };
                    new ShimSPBaseCollection(shim)
                    {
                        GetEnumerator = () => listSpList.GetEnumerator()
                    };
                    return shim;
                },
                LocaleGet = () => new CultureInfo("en-US"),
                PropertiesGet = () =>
                {
                    var shim = new ShimSPPropertyBag();
                    var stringDictionary = new StringDictionary
                    {
                        ["EPMLiveNotificationLists"] = "notification|notificationC`notification|notificationC`notification|notificationC`notification|notificationC",
                        ["EPMLiveNotificationEmail"] = "EPMLiveNotificationEmail",
                        ["EPMLiveNotificationEmailSubject"] = "EPMLiveNotificationEmailSubject",
                        ["EPMLiveNotificationNote"] = "EPMLiveNotificationNote",
                        ["EPMLiveLogDetailedErrors"] = "EPMLiveLogDetailedErrors",
                        ["EPMLiveNotificationOptedOutUsers"] = "10"
                    };
                    new ShimStringDictionary(shim)
                    {
                        ContainsKeyString = key => stringDictionary.ContainsKey(key),
                        ItemGetString = key => stringDictionary.ContainsKey(key)
                            ? stringDictionary[key]
                            : null,
                        ItemSetStringString = (key, stringValue) =>
                        {
                            if (stringDictionary.ContainsKey(key))
                            {
                                stringDictionary[key] = stringValue;
                            }
                            else
                            {
                                stringDictionary.Add(key, stringValue);
                            }
                        }
                    };
                    return shim;
                },
                SiteUsersGet = () => shimSPUserCollection,
                UrlGet = () => SpWebUrl,
                WebsGet = () =>
                {
                    var shim = new ShimSPWebCollection();
                    new ShimSPBaseCollection(shim)
                    {
                        GetEnumerator = () => new List<SPWeb>().GetEnumerator()
                    };
                    return shim;
                }
            };
        }
    }
}