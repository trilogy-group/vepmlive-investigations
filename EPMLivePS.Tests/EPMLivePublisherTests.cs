using System;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
using System.Security.Principal;
using System.Web.Fakes;
using EPMLiveEnterprise;
using EPMLiveEnterprise.Fakes;
using EPMLiveEnterprise.WebSvcCustomFields;
using EPMLiveEnterprise.WebSvcCustomFields.Fakes;
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
        private const string SaveFieldsMethod = "saveFields";

        private EPMLivePublisher _publisher;
        private PrivateObject _privateObject;
        private IDisposable _context;
        private int _sqlReaderReadCount;
        private bool _isConnectionOpenedCalled;
        private int _executeReaderCallCount;
        private bool _isWriteEntryCalled;
        private bool _isExecuteNonQueryCalled;
        private bool _isConnectionDisposeCalled;
        private bool _isEventLogDisposeCalled;
        private int _sqlCommandDisposeCallCount;

        [TestInitialize]
        public void Setup()
        {
            _sqlReaderReadCount = 0;
            _isConnectionOpenedCalled = false;
            _executeReaderCallCount = 0;
            _isWriteEntryCalled = false;
            _isExecuteNonQueryCalled = false;
            _isConnectionDisposeCalled = false;
            _isEventLogDisposeCalled = false;
            _sqlCommandDisposeCallCount = 0;

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
            Assert.AreEqual(1, _executeReaderCallCount);
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
            Assert.AreEqual(0, _executeReaderCallCount);
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
            Assert.AreEqual(1, _executeReaderCallCount);
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
            Assert.AreEqual(0, _executeReaderCallCount);
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
            Assert.AreEqual(1, _executeReaderCallCount);
            Assert.IsTrue(_isExecuteNonQueryCalled);
            Assert.IsFalse(_isWriteEntryCalled);
            Assert.IsTrue(result);
            const int expectedSqlCommandDisposeCalls = 2;
            AssertThatObjectsAreDisposed(expectedSqlCommandDisposeCalls);
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
            Assert.AreEqual(0, _executeReaderCallCount);
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
            Assert.AreEqual(1, _executeReaderCallCount);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            Assert.IsFalse(_isWriteEntryCalled);
            AssertThatObjectsAreDisposed();
        }

        [TestMethod]
        public void SaveFields_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSPWeb.AllInstances.ListsGet = _ => { throw new InvalidOperationException(); };
            SetupPrivateObject();

            // Act
            var parameters = new object[] { string.Empty, null, null };
            _privateObject.Invoke(SaveFieldsMethod, parameters);

            // Assert
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void GetUpdates_ValidConnection_OpenConnectionAndExecuteCommand()
        {
            // Arrange
            var spFields = new SPField[1];
            spFields[0] = new ShimSPField()
            {
                IdGet = () => Guid.Empty,
                ReorderableGet = () => true,
                ShowInEditFormGet = () => true,
                InternalNameGet = () => string.Empty
            };
            SetupShims(spFields);
            SetupDataReaderShims(3);

            // Act
            var result = _publisher.getUpdates(Guid.NewGuid().ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            Assert.IsTrue(_isConnectionOpenedCalled);
            Assert.AreEqual(4, _executeReaderCallCount);
            Assert.IsTrue(_isWriteEntryCalled);
            const int expectedSqlCommandDisposeCalls = 3;
            AssertThatObjectsAreDisposed(expectedSqlCommandDisposeCalls);
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void GetUpdates_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSqlConnection.AllInstances.Open = _ => { throw new InvalidOperationException(); };
            ShimHttpContext.CurrentGet = () => new ShimHttpContext()
            {
                UserGet = () => new GenericPrincipal(
                    new GenericIdentity(string.Empty),
                    new string[0])
            };

            // Act
            var result = _publisher.getUpdates(Guid.NewGuid().ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
            Assert.IsFalse(_isConnectionOpenedCalled);
            Assert.AreEqual(0, _executeReaderCallCount);
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void SetApprovedTasks_ValidConnection_OpenConnectionAndExecuteCommand()
        {
            // Arrange
            SetupShims();
            SetupDataReaderShims(1);
            ShimEPMLivePublisher.AllInstances.getProjectSiteGuid = (_, __) => ValidUrl;
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => { throw new InvalidOperationException(); };

            // Act
            var taskApprovalItems = new TaskApprovalItem[] { new TaskApprovalItem() };
            _publisher.setApprovedTasks(taskApprovalItems, Guid.Empty);

            // Assert
            Assert.IsTrue(_isConnectionOpenedCalled);
            Assert.AreEqual(1, _executeReaderCallCount);
            Assert.IsTrue(_isWriteEntryCalled);
            AssertThatObjectsAreDisposed();
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void SetApprovedTasks_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimEPMLivePublisher.AllInstances.getProjectSiteGuid = (_, __) => ValidUrl;
            ShimSqlConnection.AllInstances.Open = _ => { throw new InvalidOperationException(); };

            // Act
            _publisher.setApprovedTasks(null, Guid.Empty);

            // Assert
            Assert.IsFalse(_isConnectionOpenedCalled);
            Assert.AreEqual(0, _executeReaderCallCount);
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void GetPublishType_ValidConnection_OpenConnectionAndExecuteCommand()
        {
            // Arrange
            SetupShims();

            // Act
            _publisher.getPublishType(Guid.Empty);

            // Assert
            Assert.IsTrue(_isConnectionOpenedCalled);
            Assert.AreEqual(1, _executeReaderCallCount);
            Assert.IsFalse(_isWriteEntryCalled);
            AssertThatObjectsAreDisposed();
        }

        [TestMethod]
        public void GetPublishType_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSqlConnection.AllInstances.Open = _ => { throw new InvalidOperationException(); };

            // Act
            _publisher.getPublishType(Guid.Empty);

            // Assert
            Assert.IsFalse(_isConnectionOpenedCalled);
            Assert.AreEqual(0, _executeReaderCallCount);
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void IsTaskUpdates_ValidConnection_OpenConnectionAndExecuteCommand()
        {
            // Arrange
            SetupShims();
            ShimSqlDataReader.AllInstances.Read = _ => { throw new InvalidOperationException(); };

            // Act
            var result = _publisher.isTaskUpdates(Guid.Empty);

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(_isConnectionOpenedCalled);
            Assert.AreEqual(1, _executeReaderCallCount);
            Assert.IsTrue(_isWriteEntryCalled);
            AssertThatObjectsAreDisposed();
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        [TestMethod]
        public void IsTaskUpdates_Exception_WriteEntryToEventLog()
        {
            // Arrange
            SetupShims();
            ShimSPWeb.AllInstances.SiteGet = _ => { throw new InvalidOperationException(); };

            // Act
            var result = _publisher.isTaskUpdates(Guid.Empty);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(_isConnectionOpenedCalled);
            Assert.AreEqual(0, _executeReaderCallCount);
            Assert.IsTrue(_isWriteEntryCalled);
            Assert.IsTrue(_isEventLogDisposeCalled);
        }

        private void SetupDataReaderShims(int readCount)
        {
            _sqlReaderReadCount = readCount;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (_sqlReaderReadCount == 0)
                {
                    return false;
                }

                _sqlReaderReadCount--;
                return true;
            };
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => Guid.Empty;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, __) => string.Empty;
        }

        private void SetupPrivateObject()
        {
            _privateObject = new PrivateObject(_publisher);
        }

        private void AssertThatObjectsAreDisposed(int expectedSqlCommandDisposeCalls = 1)
        {
            Assert.IsTrue(_isConnectionDisposeCalled);
            Assert.AreEqual(expectedSqlCommandDisposeCalls, _sqlCommandDisposeCallCount);
        }

        private void SetupShims(SPField[] spFields = null)
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
            ShimSPWeb.AllInstances.UrlGet = _ => ValidUrl;
            ShimSPWeb.AllInstances.SiteGet = _ => shimSPSite;
            var spFieldCollection = new ShimSPFieldCollection()
            {
                ItemGetGuid = _ => spFields?[0]
            };
            var spList = new ShimSPList()
            {
                FieldsGet = () => spFieldCollection
            };
            var spListCollection = new ShimSPListCollection()
            {
                ItemGetString = _ => spList,
                ItemGetGuid = _ => spList 
            };
            ShimSPWeb.AllInstances.ListsGet = _ => spListCollection;
            ShimSPSite.ConstructorString = (site, _) =>
            {
                site = shimSPSite;
            };
            ShimSPSite.AllInstances.WebApplicationGet = _ => webApplication;
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.Close = _ => { };
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => shimSPSite,
                WebGet = () => new ShimSPWeb()
                {
                    Close = () => { },
                    ListsGet = () => spListCollection
                }
            };
            if (spFields == null)
            {
                spFields = new SPField[0];
            }            
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => spFields.GetEnumerator();
            ShimCustomFields.AllInstances.ReadCustomFieldsByEntityGuid =
                (_, __) => new CustomFieldDataSet();
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                _isConnectionOpenedCalled = true;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                _executeReaderCallCount++;
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
                _sqlCommandDisposeCallCount++;
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
