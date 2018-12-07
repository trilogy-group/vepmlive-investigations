using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
using System.Fakes;
using System.Globalization;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

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
        private const string SharePointType = "SharePointType";
        private const string TypeLookup = "Lookup";
        private const string DummyString = "DummyString";
        private const string MethodBuildSelectSql = "BuildSelectSql";
        private IDisposable _shimsContext;
        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;
        private MyWorkReportData _testObj;
        private PrivateObject _privateObj;
        private static readonly DateTime DefaultDate = new DateTime(2019, 1, 1);
        private string DefaultIdentifier = DefaultDate.Ticks.ToString(CultureInfo.InvariantCulture);

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _testObj = new MyWorkReportData(new Guid(), ReportData, Server, false, Username, Password);
            _privateObj = new PrivateObject(_testObj);

            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimDateTime.NowGet = () => DefaultDate;
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

        [TestMethod]
        public void InsertSQL_Invoke_ReturnsInsert()
        {
            // Arrange
            var dataTable = GetDataTable();

            var defaultColumns = new ArrayList { ColumnName };
            var hiddenFields = new ArrayList { ColumnName };
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPField.AllInstances.TypeAsStringGet = _ => ColumnType;

            // Act
            var result = _testObj.InsertSQL("Table", "List", dataTable, _sharepointShims.ListItemShim, defaultColumns, hiddenFields);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldContain($"INSERT INTO Table  ([itemid],[WorkType],[DataSource])   VALUES(@InternalName_{DefaultIdentifier},@WorkType_{DefaultIdentifier},@DataSource_{DefaultIdentifier})");
        }

        [TestMethod]
        public void InsertSQL_LookupAssignedToText_ReturnsInsert()
        {
            // Arrange
            var dataTable = GetDataTable(TypeLookup, "assignedtotext");

            var defaultColumns = new ArrayList { ColumnName };
            var hiddenFields = new ArrayList { ColumnName };
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPField.AllInstances.TypeAsStringGet = _ => TypeLookup;
            ShimEPMData.AllInstances.IsLookUpFieldStringString = (a, b, c) => true;

            // Act
            var result = _testObj.InsertSQL("Table", "List", dataTable, _sharepointShims.ListItemShim, defaultColumns, hiddenFields);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldContain($"INSERT INTO Table  ([assignedtotextID], [assignedtotextText],[WorkType],[DataSource])   VALUES(@assignedtotext_{DefaultIdentifier},@WorkType_{DefaultIdentifier},@DataSource_{DefaultIdentifier})");
        }

        [TestMethod]
        public void InsertSQL_LookupText_ReturnsInsert()
        {
            // Arrange
            var dataTable = GetDataTable(TypeLookup, "text");

            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPField.AllInstances.TypeAsStringGet = _ => TypeLookup;
            ShimEPMData.AllInstances.IsLookUpFieldStringString = (a, b, c) => true;
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;

            var defaultColumns = new ArrayList { ColumnName };
            var hiddenFields = new ArrayList { ColumnName };

            // Act
            var result = _testObj.InsertSQL("Table", "List", dataTable, _sharepointShims.ListItemShim, defaultColumns, hiddenFields);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldContain($"INSERT INTO Table  ([textID], [textText],[WorkType],[DataSource])   VALUES(@text_{DefaultIdentifier},@WorkType_{DefaultIdentifier},@DataSource_{DefaultIdentifier})");
        }

        [TestMethod]
        public void InsertSQL_LookupInteger_ReturnsInsert()
        {
            // Arrange
            var dataTable = GetDataTable(TypeLookup, "integer");

            var defaultColumns = new ArrayList { ColumnName };
            var hiddenFields = new ArrayList { ColumnName };
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPField.AllInstances.TypeAsStringGet = _ => TypeLookup;
            ShimEPMData.AllInstances.IsLookUpFieldStringString = (a, b, c) => true;
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => 1;

            var list = new List<SPFieldUserValue> { _sharepointShims.FieldUserValueShim };
            var count = list.Count;
            var enumerator = list.GetEnumerator();
            ShimList<SPFieldUserValue>.AllInstances.CountGet = _ => count;
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = x => enumerator;

            // Act
            var result = _testObj.InsertSQL("Table", "List", dataTable, _sharepointShims.ListItemShim, defaultColumns, hiddenFields);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldContain($"INSERT INTO Table  ([integerID], [integerText],[WorkType],[DataSource])   VALUES(@integer_{DefaultIdentifier},@WorkType_{DefaultIdentifier},@DataSource_{DefaultIdentifier})");
        }

        [TestMethod]
        public void InsertSQL_LookupNull_ReturnsInsert()
        {
            // Arrange
            var dataTable = GetDataTable(TypeLookup, "null");

            var defaultColumns = new ArrayList { ColumnName };
            var hiddenFields = new ArrayList { ColumnName };
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPField.AllInstances.TypeAsStringGet = _ => TypeLookup;
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => null;
            ShimEPMData.AllInstances.IsLookUpFieldStringString = (a, b, c) => true;

            // Act
            var result = _testObj.InsertSQL("Table", "List", dataTable, _sharepointShims.ListItemShim, defaultColumns, hiddenFields);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldContain($"INSERT INTO Table  ([nullID], [nullText],[WorkType],[DataSource])   VALUES(@null_{DefaultIdentifier},@WorkType_{DefaultIdentifier},@DataSource_{DefaultIdentifier})");
        }

        [TestMethod]
        public void InsertSQL_HiddenField_ReturnsInsert()
        {
            // Arrange
            var dataTable = GetDataTable(TypeLookup);

            var defaultColumns = new ArrayList { ColumnName };
            var fields = new string[] { "commenters", "commentcount", "commentersread", "workspaceurl" };
            var hiddenFields = new ArrayList(fields);
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPField.AllInstances.TypeAsStringGet = _ => TypeLookup;
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => 1;

            var list = new List<SPFieldUserValue> { _sharepointShims.FieldUserValueShim };
            var count = list.Count;
            var enumerator = list.GetEnumerator();
            ShimList<SPFieldUserValue>.AllInstances.CountGet = _ => count;
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = x => enumerator;

            foreach (var field in fields)
            {
                AddRowToInsert(InternalName, field, dataTable);
            }

            // Act
            var result = _testObj.InsertSQL("Table", "List", dataTable, _sharepointShims.ListItemShim, defaultColumns, hiddenFields);

            // Assert
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain("INSERT INTO Table  ([itemidID], [itemidText],[commenters],[commentcount],[commentersread],[workspaceurl],[WorkType],[DataSource])"),
                () => result.ShouldContain($"VALUES(@InternalName_{DefaultIdentifier},@commenters_{DefaultIdentifier},@commentcount_{DefaultIdentifier},@commentersread_{DefaultIdentifier},@workspaceurl_{DefaultIdentifier},@WorkType_{DefaultIdentifier},@DataSource_{DefaultIdentifier})"));
        }

        [TestMethod]
        public void InsertSQL_DefaultColumn_ReturnsInsert()
        {
            // Arrange
            var dataTable = GetDataTable(TypeLookup);

            var fields = new string[] { "siteid", "webid", "listid", "weburl" };
            var defaultColumns = new ArrayList(fields);
            var hiddenFields = new ArrayList { ColumnName };
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPField.AllInstances.TypeAsStringGet = _ => TypeLookup;
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => 1;

            var list = new List<SPFieldUserValue> { _sharepointShims.FieldUserValueShim };
            var count = list.Count;
            var enumerator = list.GetEnumerator();
            ShimList<SPFieldUserValue>.AllInstances.CountGet = _ => count;
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = x => enumerator;

            foreach (var field in fields)
            {
                AddRowToInsert(InternalName, field, dataTable);
            }

            // Act
            var result = _testObj.InsertSQL("Table", "List", dataTable, _sharepointShims.ListItemShim, defaultColumns, hiddenFields);

            // Assert
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain("INSERT INTO Table  ([itemidID], [itemidText],[siteid],[webid],[listid],[weburl],[WorkType],[DataSource])"),
                () => result.ShouldContain($"VALUES(@InternalName_{DefaultIdentifier},@siteid_{DefaultIdentifier},@webid_{DefaultIdentifier},@rptlistid_{DefaultIdentifier},@weburl_{DefaultIdentifier},@WorkType_{DefaultIdentifier},@DataSource_{DefaultIdentifier})"));
        }

        [TestMethod]
        public void InsertSQL_NotContainField_ReturnsInsert()
        {
            // Arrange
            var dataTable = GetDataTable(TypeLookup, "null");

            var defaultColumns = new ArrayList { ColumnName };
            var hiddenFields = new ArrayList { ColumnName };
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => false;
            ShimSPField.AllInstances.TypeAsStringGet = _ => TypeLookup;
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => null;

            // Act
            var result = _testObj.InsertSQL("Table", "List", dataTable, _sharepointShims.ListItemShim, defaultColumns, hiddenFields);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldContain($"INSERT INTO Table  ([nullID], [nullText],[WorkType],[DataSource])   VALUES(@null_{DefaultIdentifier},@WorkType_{DefaultIdentifier},@DataSource_{DefaultIdentifier})");
        }

        [TestMethod]
        public void BuildSelectSql_Site_ReturnsSelect()
        {
            // Arrange
            var filterValues = GetFilterValues();
            var dateString = DefaultDate.ToString("yyyy-MM-dd");

            // Act
            var result = _privateObj.Invoke(MethodBuildSelectSql, new object[] { filterValues, ReportingScope.Site, new ShimSPWeb().Instance });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"SELECT DISTINCT * FROM [LSTMyWork] WHERE [SiteId] = N'00000000-0000-0000-0000-000000000000' AND [intCol] IN (1) AND [varcharCol] IN (N'DummyString') AND ([StartDate] <= '{dateString} 23:59:59' AND [DueDate] >= '{dateString} 00:00:00')");
        }

        [TestMethod]
        public void BuildSelectSql_Recursive_ReturnsSelect()
        {
            // Arrange
            var filterValues = GetFilterValues();
            var dateString = DefaultDate.ToString("yyyy-MM-dd");
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => "/";

            // Act
            var result = _privateObj.Invoke(MethodBuildSelectSql, new object[] { filterValues, ReportingScope.Recursive, new ShimSPWeb().Instance });

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe($"SELECT DISTINCT * FROM [LSTMyWork] WHERE ([WebUrl] LIKE N'%' OR [WebUrl] = N'' OR [WebUrl] = N'/' AND [SiteId] = N'00000000-0000-0000-0000-000000000000') AND [intCol] IN (1) AND [varcharCol] IN (N'DummyString') AND ([StartDate] <= '{dateString} 23:59:59' AND [DueDate] >= '{dateString} 00:00:00')");
        }

        private Dictionary<string, IEnumerable<object>> GetFilterValues()
        {
            ShimMyWorkReportData.AllInstances.GetColumnTypeString = (_, key) =>
            {
                switch (key)
                {
                    case "intCol":
                        return "int";
                    default:
                        return "varchar";
                }
            };
            return new Dictionary<string, IEnumerable<object>>
            {
                { "intCol", new object[] { 1 } },
                { "varcharCol", new object[] { DummyString } },
                { "StartDate", new object[] { DefaultDate } },
                { "DueDate", new object[] { DefaultDate } },
            };
        }

        private DataTable GetDataTable(string spType = InternalName, string columnName = ItemId)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(InternalName);
            dataTable.Columns.Add(SharePointType);
            dataTable.Columns.Add(ColumnName);
            AddRowToInsert(spType, columnName, dataTable);
            return dataTable;
        }

        private void AddRowToInsert(string spType, string columnName, DataTable dataTable)
        {
            var row = dataTable.NewRow();
            row[InternalName] = InternalName;
            row[SharePointType] = spType;
            row[ColumnName] = columnName;
            dataTable.Rows.Add(row);
        }
    }
}
