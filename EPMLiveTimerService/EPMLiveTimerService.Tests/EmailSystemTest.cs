using System;
using System.Net.Mail;
using System.Net.Mail.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerService;

namespace EPMLiveTimerService.Tests
{
    [TestClass]
    public class EmailSystemTest
    {
        private const string DummyString = "DummyString";
        private const string HostEmailAddress = "host@email.com";
        private const string UserEmailAddress = "dummy@email.com";
        private const string SampleName = "John Doe";
        private const string SampleLoginName = "john.doe";
        
        private const string NameKey = "{ToUser_Name}";
        private const string EmailKey = "{ToUser_Email}";
        private const string UsernameKey = "{ToUser_Username}";

        private string _body;
        private string _subject;
        private bool _hideFrom;
        private SPUser _fromUser;
        private SPUser _toUser;
        private IDisposable _context;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();

            _body = $"Body Message: {NameKey}, {EmailKey}, {UsernameKey}";
            _subject = $"Subject Message: {NameKey}, {EmailKey}, {UsernameKey}";
            _hideFrom = true;

            _fromUser = CreateShimForSpUser();
            _toUser = CreateShimForSpUser();
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SendFullEmail_WhenBodyIsEmpty_ThrowsException()
        {
            // Arrange
            _body = string.Empty;

            // Act
            EmailSystem.SendFullEmail(_body, _subject, _hideFrom, _fromUser, _toUser);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SendFullEmail_WhenSubjectIsEmpty_ThrowsException()
        {
            // Arrange
            _subject = string.Empty;

            // Act
            EmailSystem.SendFullEmail(_body, _subject, _hideFrom, _fromUser, _toUser);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SendFullEmail_WhenFromUserIsNull_ThrowsException()
        {
            // Arrange
            _fromUser = null;

            // Act
            EmailSystem.SendFullEmail(_body, _subject, _hideFrom, _fromUser, _toUser);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SendFullEmail_WhenToUserIsNull_ThrowsException()
        {
            // Arrange
            _toUser = null;

            // Act
            EmailSystem.SendFullEmail(_body, _subject, _hideFrom, _fromUser, _toUser);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void SendFullEmail_WhenHideFromIsTrue_SendEmail()
        {
            // Arrange
            SetupFakesForGeneralPurpose();

            var mailMessage = new MailMessage();
            var smtpClient = new SmtpClient();
            ShimSmtpClient.AllInstances.SendMailMessage = (client, message) =>
            {
                smtpClient = client;
                mailMessage = message;
            };

            // Act
            EmailSystem.SendFullEmail(_body, _subject, _hideFrom, _fromUser, _toUser);

            // Assert
            var resultBody = GetResultBody(_body, SampleName, UserEmailAddress, SampleLoginName);
            var resultSubject = GetResultBody(_subject, SampleName, UserEmailAddress, SampleLoginName);

            Assert.AreEqual(DummyString, smtpClient.Host);
            Assert.AreEqual(HostEmailAddress, mailMessage.From.Address);
            Assert.AreEqual(resultBody, mailMessage.Body);
            Assert.AreEqual(resultSubject, mailMessage.Subject);
            Assert.IsTrue(mailMessage.IsBodyHtml);
        }

        [TestMethod]
        public void SendFullEmail_WhenHideFromIsFalseAndFromUserEmailIsEmpty_SendEmail()
        {
            // Arrange
            _hideFrom = false;
            _fromUser = new ShimSPUser
            {
                NameGet = () => SampleName,
                EmailGet = () => string.Empty,
                LoginNameGet = () => SampleLoginName
            };

            SetupFakesForGeneralPurpose();

            var mailMessage = new MailMessage();
            var smtpClient = new SmtpClient();
            ShimSmtpClient.AllInstances.SendMailMessage = (client, message) =>
            {
                smtpClient = client;
                mailMessage = message;
            };

            // Act
            EmailSystem.SendFullEmail(_body, _subject, _hideFrom, _fromUser, _toUser);

            // Assert
            var resultBody = GetResultBody(_body, SampleName, UserEmailAddress, SampleLoginName);
            var resultSubject = GetResultBody(_subject, SampleName, UserEmailAddress, SampleLoginName);

            Assert.AreEqual(DummyString, smtpClient.Host);
            Assert.AreEqual(HostEmailAddress, mailMessage.From.Address);
            Assert.AreEqual(SampleName, mailMessage.From.DisplayName);
            Assert.AreEqual(resultBody, mailMessage.Body);
            Assert.AreEqual(resultSubject, mailMessage.Subject);
            Assert.IsTrue(mailMessage.IsBodyHtml);
        }

        [TestMethod]
        public void SendFullEmail_WhenHideFromIsFalseAndFromUserEmailIsNotEmpty_SendEmail()
        {
            // Arrange
            _hideFrom = false;
            SetupFakesForGeneralPurpose();

            var mailMessage = new MailMessage();
            var smtpClient = new SmtpClient();
            ShimSmtpClient.AllInstances.SendMailMessage = (client, message) =>
            {
                smtpClient = client;
                mailMessage = message;
            };

            // Act
            EmailSystem.SendFullEmail(_body, _subject, _hideFrom, _fromUser, _toUser);

            // Assert
            var resultBody = GetResultBody(_body, SampleName, UserEmailAddress, SampleLoginName);
            var resultSubject = GetResultBody(_subject, SampleName, UserEmailAddress, SampleLoginName);

            Assert.AreEqual(DummyString, smtpClient.Host);
            Assert.AreEqual(UserEmailAddress, mailMessage.From.Address);
            Assert.AreEqual(SampleName, mailMessage.From.DisplayName);
            Assert.AreEqual(resultBody, mailMessage.Body);
            Assert.AreEqual(resultSubject, mailMessage.Subject);
            Assert.IsTrue(mailMessage.IsBodyHtml);
        }

        private static ShimSPUser CreateShimForSpUser()
        {
            return new ShimSPUser
            {
                NameGet = () => SampleName,
                EmailGet = () => UserEmailAddress,
                LoginNameGet = () => SampleLoginName
            };
        }

        private static void SetupFakesForGeneralPurpose()
        {
            ShimSPAdministrationWebApplication.LocalGet = () => new ShimSPAdministrationWebApplication();
            ShimSPWebApplication.AllInstances.OutboundMailServiceInstanceGet = application => new ShimSPOutboundMailServiceInstance();
            ShimSPServiceInstance.AllInstances.ServerGet = instance => new ShimSPServer
            {
                AddressGet = () => DummyString
            };

            ShimSPWebApplication.AllInstances.OutboundMailSenderAddressGet = application => HostEmailAddress;
        }

        private static string GetResultBody(string message, string name, string email, string login)
        {
            return message.Replace(NameKey, name)
                .Replace(EmailKey, email)
                .Replace(UsernameKey, GetJustUsername(login));
        }

        private static string GetJustUsername(string username)
        {
            try
            {
                var slittedValue = username.Split('|');
                return slittedValue[slittedValue.Length - 1];
            }
            catch
            {
                return username;
            }
        }
    }
}
