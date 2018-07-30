using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerService;

namespace EPMLiveTimerService.Tests
{
    [TestClass]
    public class EmailSystemTest
    {
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
    }
}
