using System;
using System.IO;
using System.IO.Fakes;
using System.Net.Mail.Fakes;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.Jobs;
using EPMLiveCore.Jobs.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

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
    }
}