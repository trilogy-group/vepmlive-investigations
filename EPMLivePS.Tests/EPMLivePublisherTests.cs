using System;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
using EPMLiveEnterprise;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLivePS.Tests
{
    [TestClass]
    public class EPMLivePublisherTests
    {
        private EPMLivePublisher _publisher;
        private IDisposable _context;
        private bool _isConnectionOpenedCalled;
        private bool _isExecuteReaderCalled;
        private bool _isWriteEntryCalled;

        [TestInitialize]
        public void Setup()
        {
            _isConnectionOpenedCalled = false;
            _isExecuteReaderCalled = false;
            _isWriteEntryCalled = false;
            _context = ShimsContext.Create();
            _publisher = new EPMLivePublisher();
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void GetEnterpriseSetting_ValidConnection_OpenConnectionAndExecuteReader()
        {
            // Arrange
            SetupShims();

            // Act
            var result = _publisher.getEnterpriseSetting(string.Empty);

            // Assert
            Assert.IsTrue(_isConnectionOpenedCalled);
            Assert.IsTrue(_isExecuteReaderCalled);
            Assert.IsFalse(_isWriteEntryCalled);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetEnterpriseSetting_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new InvalidOperationException();
            };

            // Act
            var result = _publisher.getEnterpriseSetting(string.Empty);

            // Assert
            Assert.IsFalse(_isConnectionOpenedCalled);
            Assert.IsFalse(_isExecuteReaderCalled);
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetSiteTemplates_ValidConnection_OpenConnectionAndExecuteReader()
        {
            // Arrange
            SetupShims();
            Exception exception = null;

            // Act
            try
            {
                _publisher.getSiteTemplates();
            }
            catch (Exception ex)
            {
                exception = ex;
            }


            // Assert
            Assert.IsInstanceOfType(exception, typeof(NullReferenceException));
            Assert.IsTrue(_isConnectionOpenedCalled);
            Assert.IsTrue(_isExecuteReaderCalled);
            Assert.IsFalse(_isWriteEntryCalled);
        }

        [TestMethod]
        public void GetSiteTemplates_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new InvalidOperationException();
            };
            Exception exception = null;

            // Act
            try
            {
                _publisher.getSiteTemplates();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsInstanceOfType(exception, typeof(NullReferenceException));
            Assert.IsFalse(_isConnectionOpenedCalled);
            Assert.IsFalse(_isExecuteReaderCalled);
            Assert.IsTrue(_isWriteEntryCalled);
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => Guid.Empty,
                    WebApplicationGet = () => new SPWebApplication()
                    {
                        Id = Guid.Empty
                    },
                    RootWebGet = () => new ShimSPWeb()
                    {
                        GetAvailableWebTemplatesUInt32 = _ => null
                    }
                },
            };

            ShimSqlConnection.AllInstances.Open = _ =>
            {
                _isConnectionOpenedCalled = true;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                _isExecuteReaderCalled = true;
                return new ShimSqlDataReader();
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (_) =>
            {
                _.Invoke();
            };
            ShimEventLog.AllInstances.WriteEntryStringEventLogEntryTypeInt32 = (a, b, c, d) =>
            {
                _isWriteEntryCalled = true;
            };
        }
    }
}
