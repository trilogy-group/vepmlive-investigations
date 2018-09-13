using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.ReportHelper;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.ReportHelper
{
    [TestClass]
    public class MyWorkReportDataTest
    {
        private const string Sql = "SQL command";
        private const string GetDataSql = "SELECT DISTINCT * FROM [LSTMyWork] WHERE [WebId] = N'00000000-0000-0000-0000-000000000000' AND ([StartDate] <= '9999-12-31 23:59:59' AND [DueDate] >= '1800-01-01 00:00:00')";
        private const string GetFieldsSql = "SELECT DISTINCT InternalName FROM RPTColumn WHERE RPTListId = N'00000000-0000-0000-0000-000000000000'";
        private const string GetColumnTypeSql = "SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = N'LSTMyWork') AND (COLUMN_NAME = N'ColumnName')";
        private const string LogEntry = "Name:  Url:  ID: 00000000-0000-0000-0000-000000000000 : Message ColumnName: ColumnName InternalName: InternalName";

        private const string AddColumnValuesMethod = "AddColumnValues";
        private const string AddMetaInfoColsMethod = "AddMetaInfoCols";
        private const string GetColumnTypeMethod = "GetColumnType";
        private const string LogErrorMethod = "LogError";

        private const string ReportData = "ReportData";
        private const string Server = "server";
        private const string Username = "username";
        private const string Password = "password";
        private const string ColumnName = "ColumnName";
        private const string InternalName = "InternalName";
        private const string ItemId = "itemid";
        private const string ListItem = "ListItem";
        private const string Insert = "insert";
        private const string ColumnType = "ColumnType";
        private const string ValuesSubstring = "VALUES(@itemid_";
        private const string Columns = "(itemid)";
        private const string Values = "(1)";
        private const string Message = "Message";

        private IDisposable _shimsContext;
        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;
        private MyWorkReportData _testObj;
        private PrivateObject _privateObj;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _testObj = new MyWorkReportData(new Guid(), ReportData, Server, false, Username, Password);
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void ExecuteEpmLiveSql_ReturnsDataTable()
        {
            // Act
            _testObj.ExecuteEpmLiveSql(Sql);

            // Assert
            Assert.IsTrue(_adoShims.IsCommandCreated(Sql));
            Assert.IsTrue(_adoShims.IsCommandExecuted(Sql));
            Assert.IsTrue(_adoShims.IsDataReaderCreatedForCommand(Sql));
            Assert.IsTrue(_adoShims.IsDataReaderDisposedForCommand(Sql));
        }

        [TestMethod]
        public void ExecuteSql_ReturnsDataTable()
        {
            // Act
            _testObj.ExecuteSql(Sql);

            // Assert
            Assert.IsTrue(_adoShims.IsCommandCreated(Sql));
            Assert.IsTrue(_adoShims.IsCommandExecuted(Sql));
            Assert.IsTrue(_adoShims.IsDataReaderCreatedForCommand(Sql));
            Assert.IsTrue(_adoShims.IsDataReaderDisposedForCommand(Sql));
        }

        [TestMethod]
        public void GetData_ReturnsDataTable()
        {
            // Arrange
            ShimSPWeb.AllInstances.IDGet = (_) => { return new Guid(); };

            // Act
            _testObj.GetData(new Dictionary<string, IEnumerable<object>>(), ReportingScope.Web, new ShimSPWeb());

            // Assert
            Assert.IsTrue(_adoShims.IsCommandCreated(GetDataSql));
            Assert.IsTrue(_adoShims.IsCommandExecuted(GetDataSql));
            Assert.IsTrue(_adoShims.IsDataReaderCreatedForCommand(GetDataSql));
            Assert.IsTrue(_adoShims.IsDataReaderDisposedForCommand(GetDataSql));
        }

        [TestMethod]
        public void GetFields_ReturnsDataTable()
        {
            // Act
            _testObj.GetFields();

            // Assert
            Assert.IsTrue(_adoShims.IsCommandCreated(GetFieldsSql));
            Assert.IsTrue(_adoShims.IsCommandExecuted(GetFieldsSql));
            Assert.IsTrue(_adoShims.IsDataReaderCreatedForCommand(GetFieldsSql));
            Assert.IsTrue(_adoShims.IsDataReaderDisposedForCommand(GetFieldsSql));
        }

        [TestMethod]
        public void AddColumnValues_ReturnsString()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add(ColumnName, typeof(string));
            dataTable.Columns.Add(InternalName, typeof(string));

            var row = dataTable.NewRow();
            row[ColumnName] = ItemId;
            row[InternalName] = InternalName;
            dataTable.Rows.Add(row);

            var defColumns = new ArrayList() { ItemId };

            var spListItem = new ShimSPListItem();
            spListItem.IDGet = () => { return 1; };

            var args = new object[] { (SPListItem)spListItem, dataTable, defColumns, new ArrayList(), Insert, string.Empty };

            // Act
            var actual = _privateObj.Invoke(AddColumnValuesMethod, args);

            // Assert
            Assert.AreEqual(1, _adoShims.ConnectionsCreated.Count);
            StringAssert.Contains(actual as string, ValuesSubstring);
        }

        [TestMethod]
        public void AddMetaInfoCols_CreatesParameters()
        {
            // Arrange
            int count = 0;
            ShimSqlParameterCollection parameters = new ShimSqlParameterCollection();
            parameters.AddSqlParameter = (_) => { count++; return _; };
            ShimSqlCommand.AllInstances.ParametersGet = (_) => { return parameters; };

            var spListItem = new ShimSPListItem();
            var args = new object[] { ListItem, (SPListItem)spListItem, Columns, Values };

            // Act
            _privateObj.Invoke(AddMetaInfoColsMethod, args);

            // Assert
            Assert.AreEqual(1, _adoShims.ConnectionsCreated.Count);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetColumnType_ReturnsString()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteScalar = (_) => { return ColumnType; };
            var args = new object[] { ColumnName };

            // Act
            var actual = _privateObj.Invoke(GetColumnTypeMethod, args);

            // Assert
            Assert.IsTrue(_adoShims.IsCommandCreated(GetColumnTypeSql));
            Assert.AreEqual(ColumnType, actual);
        }

        [TestMethod]
        public void LogError_WritesEntry()
        {
            // Arrange
            string entry = null;
            ShimEventLog.AllInstances.WriteEntryStringEventLogEntryTypeInt32 = (_, message, type, eventId) => { entry = message; };
            var args = new object[] { InternalName, new Exception(Message), ColumnName };

            // Act
            _privateObj.Invoke(LogErrorMethod, args);

            // Assert
            Assert.AreEqual(LogEntry, entry);
        }
    }
}
