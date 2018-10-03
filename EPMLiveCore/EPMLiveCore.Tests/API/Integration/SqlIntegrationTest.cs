using System;
using System.Collections;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.API.Integration;
using EPMLiveCore.API.Integration.Fakes;
using EPMLiveIntegration;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API.Integration
{
    [TestClass]
    public class SqlIntegrationTest
    {
        private const string DeleteCommandTemplate = "DELETE FROM {0} WHERE {1}=@id";
        private const string TableName = "Table";
        private const string ColNameId = "ID";
        private const string ColNameSpid = "SPID";
        private const string ColNameType = "TYPE";
        private const string PropKeyTable = "Table";
        private const string PropKeyIdColumn = "IDColumn";
        private const string DummyString = "Dummy";
        private const int SpId01 = 1;
        private const int SpId02 = 2;
        private const int Id01 = 3;
        private const int Id02 = 4;

        private IDisposable _shimsContext;
        private SQL _testEntity;
        private PrivateObject _testEntityPrivate;
        private AdoShims _adoShims;
        private IntegrationLog _logger;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testEntity = new SQL();
            _testEntityPrivate = new PrivateObject(_testEntity);
            _adoShims = AdoShims.ShimAdoNetCalls();
            _logger = new IntegrationLog(null, Guid.Empty, Guid.Empty, string.Empty);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void DeleteItems_WhenItemsPassedIntoMethod_DeletesItemsAndReturnsDeletedIdsAsTable()
        {
            // Assert
            var webProperties = CreateTestWebProperties();
            var items = CreateTestDataTable();

            var row01 = items.NewRow();
            row01[ColNameSpid] = SpId01;
            row01[ColNameId] = Id01;

            var row02 = items.NewRow();
            row02[ColNameSpid] = SpId02;
            row02[ColNameId] = Id02;

            items.Rows.Add(row01);
            items.Rows.Add(row02);

            // Act
            var result = _testEntity.DeleteItems(webProperties, items, null);

            // Arrange
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBe(2),
                () => result.Rows[0][ColNameSpid].ShouldBe(SpId01.ToString()),
                () => result.Rows[0][ColNameId].ShouldBe(Id01.ToString()),
                () => result.Rows[0][ColNameType].ShouldBe(((int)TransactionType.DELETE).ToString()),
                () => result.Rows[1][ColNameSpid].ShouldBe(SpId02.ToString()),
                () => result.Rows[1][ColNameId].ShouldBe(Id02.ToString()),
                () => result.Rows[1][ColNameType].ShouldBe(((int)TransactionType.DELETE).ToString()),
                () => _adoShims.ConnectionsCreated.Count.ShouldBe(1),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.CommandsCreated.Count.ShouldBe(2),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(2),
                () => _adoShims.CommandsCreated[0].CommandText.ShouldBe(string.Format(DeleteCommandTemplate, TableName, ColNameId)));
        }

        [TestMethod]
        public void DeleteItems_WhenExceptionOccurs_ReturnsFailedIdsTable()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => { throw new InvalidOperationException(); };

            var webProperties = CreateTestWebProperties();
            var items = CreateTestDataTable();

            var row01 = items.NewRow();
            row01[ColNameSpid] = SpId01;
            row01[ColNameId] = Id01;

            items.Rows.Add(row01);

            // Act
            var result = _testEntity.DeleteItems(webProperties, items, null);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBe(1),
                () => result.Rows[0][ColNameSpid].ShouldBe(SpId01.ToString()),
                () => result.Rows[0][ColNameId].ShouldBe(Id01.ToString()),
                () => result.Rows[0][ColNameType].ShouldBe(((int)TransactionType.FAILED).ToString()));
        }

        [TestMethod]
        public void UpdateItems_WhenIdIsEmpty_InsertsDataAndReturnsInsertedIdsTable()
        {
            // Assert
            var insertRowCalled = false;
            ShimSQL.AllInstances.InsertRowWebPropertiesDataRowIntegrationLogSqlConnection =
                (_1, _2, _3, _4, _5) =>
                {
                    insertRowCalled = true;
                    return Id01.ToString();
                };

            var webProperties = CreateTestWebProperties();
            var items = CreateTestDataTable();

            var row01 = items.NewRow();
            row01[ColNameSpid] = SpId01;
            row01[ColNameId] = string.Empty;
            
            items.Rows.Add(row01);

            // Act
            var result = _testEntity.UpdateItems(webProperties, items, _logger);

            // Arrange
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBe(1),
                () => result.Rows[0][ColNameSpid].ShouldBe(SpId01.ToString()),
                () => result.Rows[0][ColNameId].ShouldBe(Id01.ToString()),
                () => result.Rows[0][ColNameType].ShouldBe(((int)TransactionType.INSERT).ToString()),
                () => insertRowCalled.ShouldBeTrue(),
                () => _adoShims.ConnectionsCreated.Count.ShouldBe(1),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void UpdateItems_WhenIdIsNotEmptyButNoResultsFromDb_InsertsDataAndReturnsInsertedIdsTable()
        {
            // Assert
            var insertRowCalled = false;
            ShimSQL.AllInstances.InsertRowWebPropertiesDataRowIntegrationLogSqlConnection =
                (_1, _2, _3, _4, _5) =>
                {
                    insertRowCalled = true;
                    return Id01.ToString();
                };

            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                var emptyDataTable = new DataTable();
                dataSet.Tables.Add(emptyDataTable);
                return -1;
            };

            var webProperties = CreateTestWebProperties();
            var items = CreateTestDataTable();

            var row01 = items.NewRow();
            row01[ColNameSpid] = SpId01;
            row01[ColNameId] = 0;

            items.Rows.Add(row01);

            // Act
            var result = _testEntity.UpdateItems(webProperties, items, _logger);

            // Arrange
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBe(1),
                () => result.Rows[0][ColNameSpid].ShouldBe(SpId01.ToString()),
                () => result.Rows[0][ColNameId].ShouldBe(Id01.ToString()),
                () => result.Rows[0][ColNameType].ShouldBe(((int)TransactionType.INSERT).ToString()),
                () => insertRowCalled.ShouldBeTrue(),
                () => _adoShims.CommandsCreated.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1),
                () => _adoShims.ConnectionsCreated.Count.ShouldBe(1),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void UpdateItems_WhenIdIsNotEmptyAndResultsFilledToDataSet_UpdatesDataAndReturnsInsertedIdsTable()
        {
            // Assert
            var updateRowCalled = false;
            ShimSQL.AllInstances.UpdateRowWebPropertiesDataRowIntegrationLogSqlConnection =
                (instance, webProps, dataRow, log, sqlConnection) =>
                {
                    updateRowCalled = true;
                    return dataRow[ColNameId].ToString();
                };

            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                var dataTable = new DataTable();
                dataTable.Rows.Add(dataTable.NewRow());
                dataSet.Tables.Add(dataTable);
                return -1;
            };

            var webProperties = CreateTestWebProperties();
            var items = CreateTestDataTable();

            var row01 = items.NewRow();
            row01[ColNameSpid] = SpId01;
            row01[ColNameId] = Id01;

            items.Rows.Add(row01);

            // Act
            var result = _testEntity.UpdateItems(webProperties, items, _logger);

            // Arrange
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBe(1),
                () => result.Rows[0][ColNameSpid].ShouldBe(SpId01.ToString()),
                () => result.Rows[0][ColNameId].ShouldBe(Id01.ToString()),
                () => result.Rows[0][ColNameType].ShouldBe(((int)TransactionType.UPDATE).ToString()),
                () => updateRowCalled.ShouldBeTrue(),
                () => _adoShims.CommandsCreated.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1),
                () => _adoShims.ConnectionsCreated.Count.ShouldBe(1),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetColumns_Always_ReturnsColumnList()
        {
            // Arrange
            var readCallCount = 0;
            ShimSqlDataReader.AllInstances.Read = _ => ++readCallCount == 1;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_1, _2) => DummyString;
            ShimSQL.AllInstances.GetDefaultColumnStringString = (_1, _2, _3) => DummyString;

            var webProps = CreateTestWebProperties();

            // Act
            var result = _testEntity.GetColumns(webProps, null, string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(1),
                () => result[0].ColumnName.ShouldBe(DummyString),
                () => result[0].DiplayName.ShouldBe(DummyString),
                () => result[0].DefaultListColumn.ShouldBe(DummyString),
                () => _adoShims.CommandsCreated.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void PullData_Always_ReturnsDataTable()
        {
            // Arrange
            var webProps = CreateTestWebProperties();
            webProps.Properties[PropKeyIdColumn] = DummyString;
            var items = CreateTestDataTable();

            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add(webProps.Properties[PropKeyIdColumn].ToString());
            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                dataSet.Tables.Add(expectedDataTable);
                return -1;
            };

            // Act
            var result = _testEntity.PullData(webProps, null, items, DateTime.Now);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeSameAs(expectedDataTable),
                () => result.Columns.Count.ShouldBe(1),
                () => result.Columns[0].ColumnName.ShouldNotBe(DummyString),
                () => result.Columns[0].ColumnName.ShouldBe(ColNameId),
                () => _adoShims.CommandsCreated.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetItem_WhenDataTableHasRows_ReturnsDataTable()
        {
            // Arrange
            var webProps = CreateTestWebProperties();
            var items = CreateTestDataTable();

            var dataTable = CreateTestDataTable();
            var row01 = dataTable.NewRow();
            row01[ColNameSpid] = SpId01;
            dataTable.Rows.Add(row01);

            ShimDbDataAdapter.AllInstances.FillDataSet = (instance, dataSet) =>
            {
                dataSet.Tables.Add(dataTable);
                return -1;
            };

            // Act
            var result = _testEntity.GetItem(webProps, null, Id01.ToString(), items);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeSameAs(items),
                () => result.Rows.Count.ShouldBe(1),
                () => result.Rows[0][ColNameId].ShouldBe(Id01.ToString()),
                () => result.Rows[0][ColNameSpid].ShouldBe(SpId01.ToString()),
                () => _adoShims.CommandsCreated.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetDropDownValues_WhenPropertyValueIsTable_ReturnsDictionary()
        {
            // Arrange
            var readCallCount = 0;
            ShimSqlDataReader.AllInstances.Read = _ => ++readCallCount == 1;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_1, _2) => DummyString;

            var webProps = CreateTestWebProperties();

            // Act
            var result = _testEntity.GetDropDownValues(webProps, null, "Table", string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ContainsKey(DummyString).ShouldBeTrue(),
                () => result[DummyString].ShouldBe(DummyString),
                () => _adoShims.CommandsCreated.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void InsertRow_Always_ExecutesCommandAndReturnsScalarValue()
        {
            // Arrange
            var webProps = CreateTestWebProperties();
            var dataTable = CreateTestDataTable();
            var dataRow = dataTable.NewRow();

            ShimSqlCommand.AllInstances.ExecuteScalar = _ => Id01;

            // Act
            var result = _testEntityPrivate.Invoke("InsertRow", webProps, dataRow, null, null) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(Id01.ToString()),
                () => _adoShims.CommandsCreated.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void UpdateRow_Always_ExecutesCommandAndReturnsScalarValue()
        {
            // Arrange
            var webProps = CreateTestWebProperties();
            var dataTable = CreateTestDataTable();
            var dataRow = dataTable.NewRow();
            dataRow[ColNameId] = Id01;

            ShimSqlCommand.AllInstances.ExecuteScalar = _ => -1;

            // Act
            var result = _testEntityPrivate.Invoke("UpdateRow", webProps, dataRow, null, null) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(Id01.ToString()),
                () => _adoShims.CommandsCreated.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1));
        }

        private DataTable CreateTestDataTable()
        {
            var itemsToBeDeleted = new DataTable();
            itemsToBeDeleted.Columns.Add(ColNameId);
            itemsToBeDeleted.Columns.Add(ColNameSpid);

            return itemsToBeDeleted;
        }

        private WebProperties CreateTestWebProperties()
        {
            var webProperties = new WebProperties();
            webProperties.Properties = new Hashtable()
            {
                [PropKeyTable] = TableName,
                [PropKeyIdColumn] = ColNameId
            };

            return webProperties;
        }
    }
}
