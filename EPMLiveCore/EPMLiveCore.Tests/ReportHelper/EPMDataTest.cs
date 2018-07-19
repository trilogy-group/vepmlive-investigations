using System;
using System.Data.SqlClient.Fakes;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.ReportHelper
{
    [TestClass]
    public class EPMDataTest
    {
        private static Guid _dummyGuid = new Guid();
        private const string DummyName = "Dummy Name";
        private const string DummyString = "Dummy String";
        private const string DummyUrl = "http://www.dummy.com";
        private const string CreateEventMessageMethod = "CreateEventMessage";
        private const string LogWindowsEventsMethod = "LogWindowsEvents";

        private const int MaxKilobytes = 32768;
        private const string DotDelimiter = ".";
        private const string EpmLiveKey = "EPM Live";
        private const string EpmLiveReportingKey = "EPMLive Reporting";

        private int _eventId;
        private string _logName;
        private string _source;
        private string _eventMessage;
        private Exception _exception;
        private PrivateObject _privateObject;

        [TestMethod]
        public void BulkInsertTest()
        {
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
               
               
                ShimEPMData.ConstructorGuid = (instance, _guid) =>
                {
                };
                ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (String1, String2, String3, String4, Int321, Int322, String5, _bool) => { return true; };
                ShimSqlConnection.AllInstances.BeginTransaction = (instance) => { return new ShimSqlTransaction() { Commit = () => { }, DisposeBoolean = (_bool) => { }, Rollback = () => { } }; };
                ShimSqlBulkCopy.ConstructorSqlConnectionSqlBulkCopyOptionsSqlTransaction = (_a, _b, _c, _d) =>
                {

                };
                ShimSqlBulkCopy.AllInstances.Close = (instance) => { };
                ShimSqlBulkCopy.AllInstances.NotifyAfterGet = (instance) => { return 0; };
                ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (instance, _dt) => { };
                ShimSqlBulkCopy.AllInstances.ColumnMappingsGet = (instance) => { return new ShimSqlBulkCopyColumnMappingCollection() { AddStringString = (_string, str) => { return new ShimSqlBulkCopyColumnMapping(); } }; };
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("TestColumn");
                ds.Tables.Add(dt);
                EPMData epmdata = new EPMData(Guid.NewGuid());
                string message = string.Empty;

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    var result = epmdata.BulkInsert(ds, true, out message);
                    //Assert
                    Assert.AreEqual(true, result);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    var result = epmdata.BulkInsert(ds, Guid.NewGuid());

                    //Assert
                    Assert.AreEqual(true, result);
                }
            }

        }

        [TestMethod]
        public void BulkInsertTest_ExecuteCatch()
        {
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ShimEPMData.ConstructorGuid = (instance, _guid) =>
                {
                };
                ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (String1, String2, String3, String4, Int321, Int322, String5, _bool) => { return true; };
                ShimSqlConnection.AllInstances.BeginTransaction = (instance) => { return new ShimSqlTransaction() { Commit = () => { }, DisposeBoolean = (_bool) => { }, Rollback = () => { } }; };
                ShimSqlBulkCopy.ConstructorSqlConnectionSqlBulkCopyOptionsSqlTransaction = (_a, _b, _c, _d) =>
                {

                };
                ShimSqlBulkCopy.AllInstances.Close = (instance) => { };
                
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("TestColumn");
                ds.Tables.Add(dt);
                EPMData epmdata = new EPMData(Guid.NewGuid());
                string message = string.Empty;

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    var result = epmdata.BulkInsert(ds, true, out message);
                    //Assert
                    Assert.AreEqual(false, result);
                }

                using (TestCheck.OpenCloseConnections)
                {
                    //Act
                    var result = epmdata.BulkInsert(ds, Guid.NewGuid());
                    //Assert
                    Assert.AreEqual(false, result);
                }
            }
        }
        [TestMethod]
        public void BulkInsertTest_ExecuteCatch_2()
        {
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                int Openconnection = 0;
                int Closeconnection = 0;
                
                ShimEPMData.ConstructorGuid = (instance, _guid) =>
                {
                };
                ShimSqlConnection.ConstructorString = (instance, _string) => { };
                
                ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (String1, String2, String3, String4, Int321, Int322, String5, _bool) => { return true; };
                ShimSqlConnection.AllInstances.DisposeBoolean = (instance, _bool) => { Closeconnection++; };
              
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("TestColumn");
                ds.Tables.Add(dt);
                EPMData epmdata = new EPMData(Guid.NewGuid());
                string message = string.Empty;
                //Act
                var result = epmdata.BulkInsert(ds, true, out message);
                
                //Assert
                Assert.AreEqual(false, result);
                Assert.AreNotEqual(Openconnection, Closeconnection);

                //Act
                result = epmdata.BulkInsert(ds, Guid.NewGuid());

                //Assert
                Assert.AreEqual(false, result);
                Assert.AreNotEqual(Openconnection, Closeconnection);
            }
        }

        [TestMethod]
        public void CreateEventMessage_WhenExceptionIsNull_ThrowsException()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                FakesForSpSecurity();
                FakesForContructor();

                var epmData = new EPMData(Guid.NewGuid());
                _privateObject = new PrivateObject(epmData);
                _exception = null;

                try
                {
                    // Act
                    _privateObject.Invoke(CreateEventMessageMethod, _exception);
                    Assert.Fail("CreateEventMessage: not throw ArgumentNullException");
                }
                catch (Exception ex)
                {
                    // Assert
                    Assert.IsTrue(ex is ArgumentNullException);
                }
            };
        }

        [TestMethod]
        public void CreateEventMessage_ShouldFillAllMessageParameters_ReturnsString()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                FakesForSpSecurity();
                FakesForContructor();

                var guid = Guid.NewGuid();
                var epmData = new EPMData(guid);
                _privateObject = new PrivateObject(epmData);
                _exception = new ArgumentNullException(nameof(epmData));

                // Act
                var message = _privateObject.Invoke(CreateEventMessageMethod, _exception);

                // Assert
                var result = $"Name: {DummyName} Url: {DummyUrl} ID: {guid} : {_exception.Message}{_exception.StackTrace}";
                Assert.AreEqual(result, message);
            };
        }

        [TestMethod]
        public void LogWindowsEvents_ShouldCreateEventLog_WriteEntry()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                FakesForSpSecurity();
                FakesForContructor();
                SetupParameters();

                var guid = Guid.NewGuid();
                var epmData = new EPMData(guid);
                _privateObject = new PrivateObject(epmData);

                var fullSourceResult = string.Empty;
                var eventMessageResult = string.Empty;
                var entryTypeResult = EventLogEntryType.SuccessAudit;
                var eventIdResult = 0;

                ShimEventLog.SourceExistsString = source =>
                {
                    fullSourceResult = source;
                    return false;
                };

                ShimEventLog.CreateEventSourceStringString = (source, logName) => { };
                ShimEventLog.ConstructorString = (_, logName) => new ShimEventLog();

                ShimEventLog.AllInstances.SourceSetString = (_, source) => { };
                ShimEventLog.AllInstances.MaximumKilobytesSetInt64 = (_, maxValue) => { };
                ShimEventLog.AllInstances.MachineNameSetString = (_, machineName) => { };
                ShimEventLog.AllInstances.ModifyOverflowPolicyOverflowActionInt32 = (_, action, days) => { };
                ShimEventLog.AllInstances.WriteEntryStringEventLogEntryTypeInt32 = (log, eventMessage, entryType, eventId) =>
                {
                    eventMessageResult = eventMessage;
                    entryTypeResult = entryType;
                    eventIdResult = eventId;
                };
                
                // Act
                _privateObject.Invoke(LogWindowsEventsMethod, _logName, _source, _eventMessage, true, _eventId);

                // Assert
                var fullSource = $"{EpmLiveReportingKey} - {_source}";
                Assert.AreEqual(fullSourceResult, fullSource);
                Assert.AreEqual(eventMessageResult, _eventMessage);
                Assert.AreEqual(entryTypeResult, EventLogEntryType.Error);
                Assert.AreEqual(eventIdResult, _eventId);
            };
        }

        private void SetupParameters()
        {
            _eventId = 20;
            _logName = DummyString;
            _source = DummyName;
            _eventMessage = DummyUrl;
        }

        private static void FakesForSpSecurity()
        {
            ShimSqlConnection.ConstructorString = (_, stringConn) => new ShimSqlConnection();

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (action) =>
            {
                action();
            };
        }

        private static void FakesForContructor()
        {
            ShimCoreFunctions.getConnectionStringGuid = _ => string.Empty;

            ShimSPSite.ConstructorGuid = (instance, guid) => new ShimSPSite(instance)
            {
                Dispose = () => { },
                WebApplicationGet = () => new ShimSPWebApplication(),
                OpenWeb = () => new ShimSPWeb
                {
                    ServerRelativeUrlGet = () => DummyUrl,
                    NameGet = () => DummyName,
                    IDGet = () => _dummyGuid
                }
            };
        }
    }
}