using System;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
using EPMLiveEnterprise;
using EPMLiveEnterprise.WebSvcProject.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EPMLiveEnterprise.EPMLivePublisher;
using static EPMLiveEnterprise.WebSvcProject.ProjectDataSet;

namespace EPMLivePS.Tests
{
    [TestClass]
    public class EPMLivePublisherTests
    {
        private const string ProjectIdColumn = "Proj_ID";
        private const string ValidUrl = "http://epmlive.com";
        private const string GetCustomFieldsMethod = "getCustomFields";

        private EPMLivePublisher _publisher;
        private PrivateObject _privateObject;
        private IDisposable _context;
        private bool _isConnectionOpenedCalled;
        private bool _isExecuteReaderCalled;
        private bool _isWriteEntryCalled;
        private bool _isExecuteNonQueryCalled;
        private bool _isConnectionDisposeCalled;
        private bool _isEventLogDisposeCalled;
        private bool _isSqlCommandDisposeCalled;

        [TestInitialize]
        public void Setup()
        {
            _isConnectionOpenedCalled = false;
            _isExecuteReaderCalled = false;
            _isWriteEntryCalled = false;
            _isExecuteNonQueryCalled = false;
            _isConnectionDisposeCalled = false;
            _isEventLogDisposeCalled = false;
            _isSqlCommandDisposeCalled = false;

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
            AssertThatObjectsAreDisposed();
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
            Assert.IsTrue(_isEventLogDisposeCalled);
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
            AssertThatObjectsAreDisposed();
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
            Assert.IsTrue(_isEventLogDisposeCalled);
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
            AssertThatObjectsAreDisposed();
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
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void GetAllProjectEnterpriseFieldList_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSPContext.CurrentGet = () => null;

            // Act
            var result = _publisher.getAllProjectEnterpriseFieldList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void GetAllTaskEnterpriseFieldList_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSPContext.CurrentGet = () => null;

            // Act
            var result = _publisher.getAllTaskEnterpriseFieldList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void GetCustomFields_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSqlConnection.AllInstances.Open = _ => { throw new InvalidOperationException(); };
            SetupPrivateObject();

            // Act
            var parameters = new object[] { string.Empty, 0, string.Empty };
            var result = _privateObject.Invoke(GetCustomFieldsMethod, parameters) as CustomField[];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void GetCustomFields_ValidConnection_OpenConnectionAndExecuteCommand()
        {
            // Arrange
            SetupShims();
            SetupPrivateObject();

            // Act
            var parameters = new object[] { string.Empty, 0, ValidUrl };
            var result = _privateObject.Invoke(GetCustomFieldsMethod, parameters) as CustomField[];

            // Assert
            Assert.IsTrue(_isConnectionOpenedCalled);
            Assert.IsTrue(_isExecuteReaderCalled);
            Assert.IsFalse(_isWriteEntryCalled);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            Assert.IsFalse(_isWriteEntryCalled);
            AssertThatObjectsAreDisposed();
        }

        private void SetupPrivateObject()
        {
            _privateObject = new PrivateObject(_publisher);
        }

        private void AssertThatObjectsAreDisposed()
        {
            Assert.IsTrue(_isConnectionDisposeCalled);
            Assert.IsTrue(_isSqlCommandDisposeCalled);
        }

        private void SetupShims()
        {
            var webApplication = new SPWebApplication()
            {
                Id = Guid.Empty
            };
            var shimSPSite = new ShimSPSite()
            {
                IDGet = () => Guid.Empty,
                WebApplicationGet = () => webApplication,
                RootWebGet = () => new ShimSPWeb()
                {
                    GetAvailableWebTemplatesUInt32 = _ => null
                },
                UrlGet = () => ValidUrl,
                Close = () => { }
            };
            ShimSPSite.ConstructorString = (site, _) =>
            {
                site = shimSPSite;
            };
            ShimSPSite.AllInstances.WebApplicationGet = _ => webApplication;
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => shimSPSite,
                WebGet = () => new ShimSPWeb()
                {
                    Close = () => { },
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = _ => new ShimSPList()
                        {
                            FieldsGet = () => new ShimSPFieldCollection()
                        }
                    }
                }
            };
            var spFields = new SPField[0];
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => spFields.GetEnumerator();
            EPMLiveEnterprise.WebSvcCustomFields.Fakes.ShimCustomFields.AllInstances.ReadCustomFieldsByEntityGuid =
                (_, __) => new EPMLiveEnterprise.WebSvcCustomFields.CustomFieldDataSet();
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
            ShimSqlConnection.AllInstances.DisposeBoolean = (_, __) =>
            {
                _isConnectionDisposeCalled = true;
            };
            ShimSqlCommand.AllInstances.DisposeBoolean = (_, __) =>
            {
                _isSqlCommandDisposeCalled = true;
            };
            ShimEventLog.AllInstances.DisposeBoolean = (_, __) =>
            {
                _isEventLogDisposeCalled = true;
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
