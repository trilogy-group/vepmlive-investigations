using System;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
using EPMLiveEnterprise;
using EPMLiveEnterprise.WebSvcProject.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EPMLiveEnterprise.WebSvcProject.ProjectDataSet;

namespace EPMLivePS.Tests
{
    [TestClass]
    public class EPMLivePublisherTests
    {
        private const string ProjectIdColumn = "Proj_ID";

        private EPMLivePublisher _publisher;
        private IDisposable _context;
        private bool _isConnectionOpenedCalled;
        private bool _isExecuteReaderCalled;
        private bool _isWriteEntryCalled;
        private bool _isExecuteNonQueryCalled;

        [TestInitialize]
        public void Setup()
        {
            _isConnectionOpenedCalled = false;
            _isExecuteReaderCalled = false;
            _isWriteEntryCalled = false;
            _isExecuteNonQueryCalled = false;
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

        [TestMethod]
        public void Publish_ValidConnection_OpenConnectionAndExecuteReader()
        {
            // Arrange
            SetupShims();

            // Act
            var result = _publisher.publish(Guid.Empty, 0, string.Empty);

            // Assert
            Assert.IsTrue(_isConnectionOpenedCalled);
            Assert.IsTrue(_isExecuteReaderCalled);
            Assert.IsTrue(_isExecuteNonQueryCalled);
            Assert.IsFalse(_isWriteEntryCalled);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Publish_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new InvalidOperationException();
            };

            // Act
            var result = _publisher.publish(Guid.Empty, 0, string.Empty);

            // Assert
            Assert.IsFalse(_isConnectionOpenedCalled);
            Assert.IsFalse(_isExecuteReaderCalled);
            Assert.IsFalse(_isExecuteNonQueryCalled);
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.IsFalse(result);
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
                    },
                    UrlGet = () => "http://epmlive.com"
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
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                _isExecuteNonQueryCalled = true;
                return 0;
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (_) =>
            {
                _.Invoke();
            };
            ShimEventLog.AllInstances.WriteEntryStringEventLogEntryTypeInt32 = (a, b, c, d) =>
            {
                _isWriteEntryCalled = true;
            };
            var projectDataTable = CreateProjectDataTable();
            ShimProject.AllInstances.ReadProjectGuidDataStoreEnum = (_, __, ___) => new ShimProjectDataSet()
            {
                ProjectGet = () => projectDataTable
            };
        }

        private static ProjectDataTable CreateProjectDataTable()
        {
            var projectDataTable = new ProjectDataTable();
            projectDataTable.Columns.Add(ProjectIdColumn);

            var row = projectDataTable.NewProjectRow();
            row.ProjectOwnerID = Guid.NewGuid();
            row.PROJ_UID = Guid.NewGuid();
            row.PROJ_NAME = "Project Name";
            row[ProjectIdColumn] = 1;
            projectDataTable.Rows.Add(row);

            return projectDataTable;
        }
    }
}
