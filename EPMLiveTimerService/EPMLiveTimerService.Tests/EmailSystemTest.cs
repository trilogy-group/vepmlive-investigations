using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
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
        [ExpectedException(typeof(Exception))]
        public void SendFullEmail_WhenHideFromIsTrue_ThrowsException()
        {
            // Arrange
            ShimSPAdministrationWebApplication.LocalGet = () => new ShimSPAdministrationWebApplication();

            // Act
            EmailSystem.SendFullEmail(_body, _subject, _hideFrom, _fromUser, _toUser);

            // Assert
            // Expected ArgumentNullException
        }
    }
}
