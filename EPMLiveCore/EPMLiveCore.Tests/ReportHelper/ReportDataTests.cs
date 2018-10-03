using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.ReportHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using System.Data;
using System.Data.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Shouldly;

namespace EPMLiveCore.ReportHelper.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ReportDataTests
    {
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private const string DummyUrl = "http://dummy.url";
        private HttpContext _httpContext;
        private HttpRequest _httpRequest;
        private HttpResponse _httpResponse;
        private static readonly NameValueCollection _queryString = new NameValueCollection();
        private static readonly HttpCookieCollection _cookies = new HttpCookieCollection();

        private PrivateObject PrivateObject { get; set; }
        private PrivateType PrivateType { get; set; }
        private ReportData TestEntity { get; set; }
        private IDisposable ShimObject { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            ShimObject = ShimsContext.Create();
            ShimEPMData.ConstructorGuidStringStringBooleanStringString = (gid, n, s, use, uname, pwd, str) => { };
            TestEntity = new ReportData(new Guid(), "RD", "server", false, "username", "password");
            PrivateObject = new PrivateObject(TestEntity);
            PrivateType = new PrivateType(typeof(ReportData));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ShimObject?.Dispose();
        }

        [TestMethod]
        public void Constructor_OnIsRootWeb_UpdateFields()
        {
            // Arrange, Act, Assert
            TestConstructorWithThreeParams(true, false, false);
        }

        [TestMethod]
        public void Constructor_OnUseSA_UpdateFields()
        {
            // Arrange, Act, Assert
            TestConstructorWithThreeParams(true, false, true);
        }

        [TestMethod]
        public void Constructor_OnAccountInfoIsNull_UpdateFields()
        {
            // Arrange, Act, Assert
            TestConstructorWithThreeParams(false, true, true);
        }

        [TestMethod]
        public void Constructor_OnTwoParamsAndUseSA_UpdateFields()
        {
            // Arrange, Act, Assert
            TestConstructorWithTwoParams(false, true);
        }

        [TestMethod]
        public void Constructor_OnTwoParamsAndUseSAIsFalse_UpdateFields()
        {
            // Arrange, Act, Assert
            TestConstructorWithTwoParams(false, false);
        }

        [TestMethod]
        public void Constructor_OnTwoParamAndAccountInfoIsNull_UpdateFields()
        {
            // Arrange, Act, Assert
            TestConstructorWithTwoParams(true, true);
        }

        [TestMethod]
        public void Constructor_OnOneParamAndIsRootWeb_UpdateFields()
        {
            // Arrange, Act, Assert
            TestConstructorWithOneParam(true, false, false);
        }

        [TestMethod]
        public void Constructor_OnOneParamAndUseSA_UpdateFields()
        {
            // Arrange, Act, Assert
            TestConstructorWithOneParam(true, false, true);
        }

        [TestMethod]
        public void Constructor_OnOneParamAndAccountInfoIsNull_UpdateFields()
        {
            // Arrange, Act, Assert
            TestConstructorWithOneParam(false, true, true);
        }

        [TestMethod()]
        public void CreateTableTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {

                ColumnDefCollection columns = ColumnDef.GetDefaultColumns();

                columns.AddColumn(new DataColumn("PeriodId"));
                columns.AddColumn(new DataColumn("WebId"));
                columns.AddColumn(new DataColumn("ItemId"));

                string message = string.Empty;
                ShimEPMData.ConstructorGuidStringStringBooleanStringString = (gid, n, s, use, uname, pwd, str) => { };
                ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (instance, sqlcon) => { return true; };
                ShimEPMData.AllInstances.GetClientReportingConnectionGet = (instane) => { return new SqlConnection(); };
                ReportData rd = new ReportData(new Guid(), "RD", "server", false, "username", "password");
                ShimReportData.AllInstances.TableExistsString = (ins, str) => { return false; };
                //when _when_tablename_rpttsdata
                //Arrange 
                string name = "rpttsdata";
                //Act

                bool result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);

                //when _when_tablename_lstmyworksnapshot
                //Arrange 
                name = "lstmyworksnapshot";
                //Act

                result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);



                //when _when_tablename_Snapshot
                //Arrange 
                name = "Create workspace1_LSTWikisSnapshot_dba1432e40a2432394ea3462f8097f14";
                //Act

                result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);


                //when _when_tablename_lstmywork
                //Arrange 
                name = "lstmywork";
                //Act

                result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);

                //when _when_tablename_test
                //Arrange 
                name = "test";
                //Act

                result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void CreateTextFile_OnValidCall_InvokeCreateTextFile()
        {
            // Arrange
            var createTextFileInvoked = false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.CreateTextFileString = (_, _2) => { createTextFileInvoked = true; };

            // Act
            TestEntity.CreateTextFile(DummyString);

            // Assert
            createTextFileInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void WriteToFile_OnValidCall_InvokeWriteToFile()
        {
            // Arrange
            var writeToFileInvoked = false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.WriteToFileString = (_, _2) => { writeToFileInvoked = true; };

            // Act
            TestEntity.WriteToFile(DummyString);

            // Assert
            writeToFileInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteExistingTSData_OnValidCall_InvokeDeleteExistingTSData()
        {
            // Arrange
            var deleteExistingTSDataInvoked = false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.DeleteExistingTSData = _ =>
            {
                deleteExistingTSDataInvoked = true;
                return true;
            };

            // Act
            TestEntity.DeleteExistingTSData();

            // Assert
            deleteExistingTSDataInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void GetSite_OnValidCall_ReturnDataRow()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };

            // Act
            var actualResult = TestEntity.GetSite();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult[DummyString].ShouldNotBeNull(),
                () => actualResult[DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void ExecuteNonQuery_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;

            // Act
            var actualResult = TestEntity.ExecuteNonQuery(new SqlConnection());

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void CheckServerConnection_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetMasterDbConnectionGet = _ => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;

            // Act
            var actualResult = TestEntity.CheckServerConnection();

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DatabaseExists_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetMasterDbConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.remoteDbNameGet = _ => DummyString;

            // Act
            var actualResult = TestEntity.DatabaseExists();

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void IsReportingDB_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetMasterDbConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => "tablename exists";

            // Act
            var actualResult = TestEntity.IsReportingDB();

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void TableExists_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetMasterDbConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => true;

            // Act
            var actualResult = TestEntity.TableExists(DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void ColumnExists_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetMasterDbConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => DummyInt;

            // Act
            var actualResult = TestEntity.ColumnExists(DummyString, DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void ProcedureExists_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetMasterDbConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => true;

            // Act
            var actualResult = TestEntity.ProcedureExists(DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void GetError_OnValidCall_ReturnString()
        {
            // Arrange
            PrivateObject.SetField("_sqlError", DummyString);

            // Act
            var actualResult = TestEntity.GetError();

            // Assert
            actualResult.ShouldContain(DummyString);
        }

        [TestMethod]
        public void CreateDatabase_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.remoteDbNameGet = _ => DummyString;
            ShimEPMData.AllInstances.SqlErrorOccurredGet = _ => true;
            ShimEPMData.AllInstances.GetMasterDbConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;

            // Act
            var actualResult = TestEntity.CreateDatabase();

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void GetTableNames_OnValidCall_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };

            // Act
            var actualResult = TestEntity.GetTableNames(DummyString);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetSafeTableName_OnValidCall_ReturnString()
        {
            // Arrange, Act, Assert
            TestGetSafeTableName(0, false);
        }

        [TestMethod]
        public void GetSafeTableName_OnTableCountIsNotZero_ReturnString()
        {
            // Arrange, Act, Assert
            TestGetSafeTableName(DummyInt, false);
        }

        [TestMethod]
        public void GetSafeTableName_OnIsRootWeb_ReturnString()
        {
            // Arrange, Act, Assert
            TestGetSafeTableName(DummyInt, true);
        }

        [TestMethod]
        public void CreateTable_OnPassingTwoParams_ReturnBoolean()
        {
            // Arrange
            ShimReportData.AllInstances.TableExistsString = (_, __) => true;

            // Act
            var actualResult = TestEntity.CreateTable(DummyString, new List<ColumnDef>());

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void CreateTable_OnNameRpttsdata_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCreateTable("rpttsdata", true);
        }

        [TestMethod]
        public void CreateTable_OnNameLstmyworksnapshot_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCreateTable("lstmyworksnapshot", false);
        }

        [TestMethod]
        public void CreateTable_OnNameSnapshot_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCreateTable("snapshot", true);
        }

        [TestMethod]
        public void CreateTable_OnNameLstmywork_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCreateTable("lstmywork", true);
        }

        [TestMethod]
        public void CreateTable_OnNameDummyString_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCreateTable(DummyString, true);
        }

        [TestMethod]
        public void DeleteTable_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;

            // Act
            var actualResult = TestEntity.DeleteTable(DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void AddColumns_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;

            // Act
            var actualResult = TestEntity.AddColumns(DummyString, new List<ColumnDef> { new ColumnDef(new DataColumn()) });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateColumns_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;

            // Act
            var actualResult = TestEntity.UpdateColumns(DummyString, new List<ColumnDef> { new ColumnDef(new DataColumn()) });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void InsertDbEntry_OnValidCall_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestInsertDbEntry(true);
        }

        [TestMethod]
        public void InsertDbEntry_OnUseSqlAccountIsFalse_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestInsertDbEntry(false);
        }

        [TestMethod]
        public void DeleteDbEntry_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.DeleteDbEntry();

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void GetDbVersion_OnValidCall_ReturnString()
        {
            // Arrange, Act, Assert
            TestGetDbVersion(ConnectionState.Open, DummyInt);
        }

        [TestMethod]
        public void GetDbVersion_OnConnectiobNotOpened_ReturnString()
        {
            // Arrange, Act, Assert
            TestGetDbVersion(ConnectionState.Closed, DummyInt);
        }

        [TestMethod]
        public void GetDbVersion_OnEmptyRows_ReturnString()
        {
            // Arrange, Act, Assert
            TestGetDbVersion(ConnectionState.Open, 0);
        }

        [TestMethod]
        public void GetDbMappings_OnValidCall_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };

            // Act
            var actualResult = TestEntity.GetDbMappings();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetExistingDbCount_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => DummyInt;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.GetExistingDbCount();

            // Assert
            actualResult.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void GetDistinctDbMappings_OnValidCall_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };

            // Act
            var actualResult = TestEntity.GetDistinctDbMappings();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetListMappings_OnValidCall_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };

            // Act
            var actualResult = TestEntity.GetListMappings();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetListMappings_OnPassingListIds_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };

            // Act
            var actualResult = TestEntity.GetListMappings(DummyString);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetListMapping_OnPassingListId_ReturnDataRow()
        {
            // Arrange
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetRowSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable.Rows[0];
            };

            // Act
            var actualResult = TestEntity.GetListMapping(Guid.NewGuid());

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult[DummyString].ShouldNotBeNull(),
                () => actualResult[DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void InitializeDatabase_OnValidCall_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestInitializeDatabase(true);
        }

        [TestMethod]
        public void InitializeDatabase_OnQueryReturnFalse_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestInitializeDatabase(false);
        }

        [TestMethod]
        public void InsertList_OnValidCall_ReturnBoolean()
        {
            // Arrange
            SetupShimsForSharePoint();
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            ShimSPSite.AllInstances.AllWebsGet = _ =>
            {
                var list = new List<SPWeb>
                {
                    new ShimSPWeb
                    {
                        ListsGet = () =>
                        {
                            var spList = new List<SPList> {new ShimSPList()};
                            return new ShimSPListCollection().Bind(spList);
                        }
                    }
                };
                return new ShimSPWebCollection().Bind(list.AsEnumerable());
            };
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, _2) => new ShimSPList();
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();

            // Act
            var actualResult = TestEntity.InsertList(Guid.NewGuid(), DummyString, DummyString, true);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateList_OnValidCall_ReturnBoolean()
        {
            // Arrange
            SetupShimsForSharePoint();
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            ShimSPWeb.AllInstances.ListsGet = _ =>
            {
                var spList = new List<SPList> { new ShimSPList() };
                return new ShimSPListCollection().Bind(spList);
            };
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, _2) => new ShimSPList();
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();

            // Act
            var actualResult = TestEntity.UpdateList(Guid.NewGuid(), true);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteList_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.DeleteList(Guid.NewGuid());

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteAllListColumns_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.DeleteAllListColumns(Guid.NewGuid());

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteListColumns_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.DeleteListColumns(Guid.NewGuid(), new List<ColumnDef>
            {
                new ColumnDef(new DataColumn())
            });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteWork_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.DeleteWorkGuidInt32 = (_, _2, _3) => true;

            // Act
            var actualResult = TestEntity.DeleteWork(Guid.NewGuid(), DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteWork_OnPassingListIdOnly_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.DeleteWork(Guid.NewGuid());

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteMyWork_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.DeleteMyWork(Guid.NewGuid());

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void InsertListColumns_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.InsertListColumns(Guid.NewGuid(), new List<ColumnDef>
            {
                new ColumnDef(new DataColumn())
            });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateListColumns_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.UpdateListColumns(Guid.NewGuid(), new List<ColumnDef>
            {
                new ColumnDef(new DataColumn())
            });

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void InsertLog_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, _2, _3, _4, _5, _6, _7, _8) => true;

            // Act
            var actualResult = TestEntity.InsertLog(Guid.NewGuid(), DummyString, DummyString, DummyString, DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void GetLog_OnValidCall_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };

            // Act
            var actualResult = TestEntity.GetLog(Guid.NewGuid(), DummyInt);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetMaximumLogLevel_OnValidCall_ReturnInt()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => DummyInt;

            // Act
            var actualResult = TestEntity.GetMaximumLogLevel(Guid.NewGuid());

            // Assert
            actualResult.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void DeleteLog_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.DeleteLog(Guid.NewGuid());

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteLog_OnPassingLogType_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.DeleteLog(Guid.NewGuid(), DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void GetTableNameSnapshot_OnValidCall_ReturnString()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => DummyString;

            // Act
            var actualResult = TestEntity.GetTableNameSnapshot(Guid.NewGuid());

            // Assert
            actualResult.ShouldContain(DummyString);
        }

        [TestMethod]
        public void GetTSAllDataWithSchema_OnValidCall_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnectionBoolean = (_, _2, _3) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.GetTSAllDataWithSchema();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void InsertTSAllData_OnPassingLogType_ReturnBoolean()
        {
            // Arrange
            var message = string.Empty;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.BulkInsertDataSetBooleanStringOut = (EPMData data, DataSet ds, bool arg3, out string msg) =>
            {
                msg = string.Empty;
                return true;
            };

            // Act
            var actualResult = TestEntity.InsertTSAllData(new DataTable(), out message);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void RefreshTimeSheet_OnPassingLogType_ExecuteNonQuery()
        {
            // Arrange
            var executeNonQueryInvoked = false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimReportData.AllInstances.GetSafeTableNameString = (_, _2) => DummyString;
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) =>
            {
                executeNonQueryInvoked = true;
                return true;
            };
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            TestEntity.RefreshTimeSheet(Guid.NewGuid(), DummyString, Guid.NewGuid());

            // Assert
            executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void GetTableName_OnValidCall_ReturnString()
        {
            // Arrange
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => DummyString;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.GetTableName(Guid.NewGuid());

            // Assert
            actualResult.ShouldContain(DummyString);
        }

        [TestMethod]
        public void GetTableName_OnPassingListName_ReturnString()
        {
            // Arrange
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => DummyString;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.GetTableName(DummyString);

            // Assert
            actualResult.ShouldContain(DummyString);
        }

        [TestMethod]
        public void InsertSQL_OnValidCall_ReturnString()
        {
            // Arrange
            SetupShimsForSqlClient();
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => "lookup";
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            var dataTable = new DataTable();
            dataTable.Columns.Add("ColumnName", typeof(string));
            dataTable.Columns.Add("InternalName", typeof(string));
            dataTable.Columns.Add("SiteId", typeof(string));
            dataTable.Columns.Add("SharePointType", typeof(string));
            dataTable.Rows.Add("WebId", DummyString, DummyString, DummyString);
            dataTable.Rows.Add("Test", DummyString, DummyString, "Lookup");
            dataTable.Rows.Add("SiteId", DummyString, DummyString, "Lookup");
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimReportData.AllInstances.AddColumnValuesSPListItemDataTableArrayListArrayListString = (_, _2, _3, _4, _5, _6) => DummyString;

            // Act
            var actualResult = TestEntity.InsertSQL(
                DummyString,
                dataTable,
                new ShimSPListItem(),
                new ArrayList(),
                new ArrayList());

            // Assert
            actualResult.ShouldContain($"INSERT INTO {DummyString} ([WebId],[SiteIdID], [SiteIdText]) {DummyString}");
        }

        [TestMethod]
        public void UpdateSQL_OnValidCall_ReturnString()
        {
            // Arrange
            SetupShimsForSqlClient();
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => "lookup";
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            var dataTable = new DataTable();
            dataTable.Columns.Add("ColumnName", typeof(string));
            dataTable.Columns.Add("InternalName", typeof(string));
            dataTable.Columns.Add("SiteId", typeof(string));
            dataTable.Columns.Add("SharePointType", typeof(string));
            dataTable.Rows.Add(DummyString, DummyString, DummyString, DummyString);
            dataTable.Rows.Add("Test", DummyString, DummyString, "Lookup");
            dataTable.Rows.Add("text", DummyString, DummyString, "Lookup");
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimReportData.AllInstances.AddColumnValuesSPListItemDataTableArrayListArrayListString = (_, _2, _3, _4, _5, _6) => DummyString;
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();

            // Act
            var actualResult = TestEntity.UpdateSQL(
                DummyString,
                dataTable,
                new ShimSPListItem(),
                new ArrayList(),
                new ArrayList());

            // Assert
            actualResult.ShouldContain($"UPDATE {DummyString}");
        }

        [TestMethod]
        public void DeleteSQL_OnValidCall_ReturnString()
        {
            // Arrange
            Func<string> action = () => TestEntity.DeleteSQL(DummyString, Guid.NewGuid(), DummyInt);

            // Act
            var actualResult = action();

            // Assert
            actualResult.ShouldContain($"DELETE FROM {DummyString}");
        }

        [TestMethod]
        public void GetListColumns_OnValidCall_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.GetListColumns(DummyString);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void VerifyListColumns_OnInvalidCall_ThrowsException()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add("ColumnName", typeof(string));
            dataTable.Rows.Add(DummyString);
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => false;

            // Act, Assert
            Should.Throw<Exception>(() => TestEntity.VerifyListColumns(dataTable, DummyString))
                .Message.ShouldContain("Column mismatch error:");
        }

        [TestMethod]
        public void GetListColumns_OnPassingListId_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.GetListColumns(Guid.NewGuid());

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void ListReportsWork_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => true;

            // Act
            var actualResult = TestEntity.ListReportsWork(DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void Dispose_OnValidCall_DisposeObject()
        {
            // Arrange
            var objectDisposed = false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_cmdWithParams", new SqlCommand());
            ShimEPMData.AllInstances.Dispose = _ => { objectDisposed = true; };

            // Act
            TestEntity.Dispose();

            // Assert
            objectDisposed.ShouldBeTrue();
        }

        [TestMethod]
        public void BulkInsert_OnValidCall_InvokeCreateTextFile()
        {
            // Arrange
            var bulkInserteInvoked = false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.BulkInsertDataSetGuid = (_, _2, _3) =>
            {
                bulkInserteInvoked = true;
                return true;
            };

            // Act
            TestEntity.BulkInsert(new DataSet(), Guid.NewGuid());

            // Assert
            bulkInserteInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void ReportError_OnPassingLogType_ExecuteNonQuery()
        {
            // Arrange
            var executeNonQueryInvoked = false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimReportData.AllInstances.GetSafeTableNameString = (_, _2) => DummyString;
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) =>
            {
                executeNonQueryInvoked = true;
                return true;
            };
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            TestEntity.ReportError(Guid.NewGuid(), DummyString, DummyString, DummyString, DummyInt);

            // Assert
            executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void LogStatus_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, _2, _3, _4, _5, _6, _7, _8) => true;

            // Act
            var actualResult = TestEntity.LogStatus(DummyString, DummyString, DummyString, DummyString, DummyInt, DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void ProcessAssignments_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.SqlErrorOccurredGet = _ => true;

            // Act
            var actualResult = TestEntity.ProcessAssignments(DummyString, DummyString, DateTime.Now, DateTime.Now, Guid.NewGuid(), Guid.NewGuid(),
                DummyInt, DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void InsertListItem_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_cmdWithParams", new SqlCommand());
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlCommandSqlParameterCollectionSqlConnection = (_, _2, _3, _4) => true;
            ShimEPMData.AllInstances.SqlErrorOccurredGet = _ => true;

            // Act
            var actualResult = TestEntity.InsertListItem(DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateListItem_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_cmdWithParams", new SqlCommand());
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlCommandSqlParameterCollectionSqlConnection = (_, _2, _3, _4) => true;
            ShimEPMData.AllInstances.SqlErrorOccurredGet = _ => true;

            // Act
            var actualResult = TestEntity.UpdateListItem(DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void IsLookUpField_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => "lookup";
            ShimEPMData.AllInstances.SqlErrorOccurredGet = _ => true;

            // Act
            var actualResult = PrivateObject.Invoke("IsLookUpField", DummyString, DummyString) as bool?;

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.HasValue.ShouldBeTrue(),
                () => actualResult.Value.ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteListItem_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_cmdWithParams", new SqlCommand());
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, _2) => true;
            ShimEPMData.AllInstances.SqlErrorOccurredGet = _ => true;

            // Act
            var actualResult = TestEntity.DeleteListItem(DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void AddColums_OnValidCall_ReturnString()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_cmdWithParams", new SqlCommand());
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlCommandSqlParameterCollectionSqlConnection = (_, _2, _3, _4) => true;
            var dataTable = new DataTable();
            dataTable.Columns.Add("ColumnName", typeof(string));
            dataTable.Columns.Add("InternalName", typeof(string));
            dataTable.Columns.Add("SiteId", typeof(string));
            dataTable.Columns.Add("SharePointType", typeof(string));
            dataTable.Rows.Add(DummyString, DummyString, DummyString, DummyString);
            dataTable.Rows.Add("Test", DummyString, DummyString, "Lookup");
            dataTable.Rows.Add("text", DummyString, DummyString, "Lookup");

            // Act
            var actualResult = PrivateObject.Invoke("AddColums", dataTable) as string;

            // Assert
            actualResult.ShouldContain(DummyString);
        }

        [TestMethod]
        public void AddLookUpFieldValues_OnValidCall_ReturnString()
        {
            // Arrange
            SetupShimsForHttpRequest();
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimSPFieldLookupValueCollection.ConstructorString = (obj, _2) => { };

            // Act
            var actualResult = ReportData.AddLookUpFieldValues($"{DummyString};#{DummyString}", "text");

            // Assert
            actualResult.ShouldContain($"{DummyString},{DummyString}");
        }

        [TestMethod]
        public void AddMultiChoiceValues_OnValidCall_ReturnString()
        {
            // Arrange
            SetupShimsForHttpRequest();
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);

            // Act
            var actualResult = ReportData.AddMultiChoiceValues($"{DummyString};#{DummyString}", "text");

            // Assert
            actualResult.ShouldContain($"{DummyString},{DummyString}");
        }

        [TestMethod]
        public void AddColumnValues_OnValidCall_ReturnString()
        {
            // Arrange, Act, Assert
            TestAddColumnValues(true, false, SPFieldType.MultiChoice, false);
        }

        [TestMethod]
        public void AddColumnValues_OnFieldTypeCalculated_ReturnString()
        {
            // Arrange, Act, Assert
            TestAddColumnValues(true, false, SPFieldType.Calculated, false);
        }

        [TestMethod]
        public void AddColumnValues_OnFieldTypeGuid_ReturnString()
        {
            // Arrange, Act, Assert
            TestAddColumnValues(true, false, SPFieldType.Guid, false);
        }

        [TestMethod]
        public void AddColumnValues_OnIsLookUpField_ReturnString()
        {
            // Arrange, Act, Assert
            TestAddColumnValues(true, true, SPFieldType.WorkflowEventType, true);
        }

        [TestMethod]
        public void AddColumnValues_OnIsLookUpFieldAndNotMultiChoice_ReturnString()
        {
            // Arrange, Act, Assert
            TestAddColumnValues(true, true, SPFieldType.WorkflowEventType, false);
        }

        [TestMethod]
        public void AddColumnValues_OnContainsFieldIsFalse_ReturnString()
        {
            // Arrange, Act, Assert
            TestAddColumnValues(false, false, SPFieldType.WorkflowEventType, false);
        }

        [TestMethod]
        public void RemoveTags_OnValidCall_ReturnString()
        {
            // Arrange
            ShimSPField.AllInstances.GetFieldValueAsTextObject = (_, _2) => DummyString;

            // Act
            var actualResult = TestEntity.RemoveTags(DummyString, new ShimSPField());

            // Assert
            actualResult.ShouldContain(DummyString);
        }

        [TestMethod]
        public void GetListId_OnValidCall_ReturnString()
        {
            // Arrange
            var guid = Guid.NewGuid();
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_siteId", guid);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => guid;

            // Act
            var actualResult = TestEntity.GetListId(DummyString);

            // Assert
            actualResult.ShouldBe(guid);
        }

        [TestMethod]
        public void PopulateDefaultColumnValue_OnSiteId_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestPopulateDefaultColumnValue("siteid");
        }

        [TestMethod]
        public void PopulateDefaultColumnValue_OnWebId_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestPopulateDefaultColumnValue("webid");
        }

        [TestMethod]
        public void PopulateDefaultColumnValue_OnListId_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestPopulateDefaultColumnValue("listid");
        }

        [TestMethod]
        public void PopulateDefaultColumnValue_OnItemId_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestPopulateDefaultColumnValue("itemid");
        }

        [TestMethod]
        public void PopulateDefaultColumnValue_OnWebUrl_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestPopulateDefaultColumnValue("weburl");
        }

        [TestMethod]
        public void PopulateMandatoryHiddenFldsColumnValue_OnCommenters_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestPopulateMandatoryHiddenFldsColumnValue("commenters");
        }

        [TestMethod]
        public void PopulateMandatoryHiddenFldsColumnValue_OnCommentcount_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestPopulateMandatoryHiddenFldsColumnValue("commentcount");
        }

        [TestMethod]
        public void PopulateMandatoryHiddenFldsColumnValue_OnCommentersRead_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestPopulateMandatoryHiddenFldsColumnValue("commentersread");
        }

        [TestMethod]
        public void PopulateMandatoryHiddenFldsColumnValue_OnWorkSpaceUrl_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestPopulateMandatoryHiddenFldsColumnValue("workspaceurl");
        }

        [TestMethod]
        public void GetParam_OnInteger_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Integer, DummyString, SqlDbType.Float);
        }

        [TestMethod]
        public void GetParam_OnLookup_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Lookup, "id", SqlDbType.Int);
        }

        [TestMethod]
        public void GetParam_OnLookupAndNotId_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Lookup, DummyString, SqlDbType.NVarChar);
        }

        [TestMethod]
        public void GetParam_OnUser_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.User, "id", SqlDbType.Int);
        }

        [TestMethod]
        public void GetParam_OnUserAndNotId_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.User, DummyString, SqlDbType.NVarChar);
        }

        [TestMethod]
        public void GetParam_OnText_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Text, DummyString, SqlDbType.NVarChar);
        }

        [TestMethod]
        public void GetParam_OnNote_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Note, DummyString, SqlDbType.NText);
        }

        [TestMethod]
        public void GetParam_OnMultiChoice_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.MultiChoice, "id", SqlDbType.Int);
        }

        [TestMethod]
        public void GetParam_OnMultiChoiceAndNotId_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.MultiChoice, DummyString, SqlDbType.NVarChar);
        }

        [TestMethod]
        public void GetParam_OnNumber_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Number, DummyString, SqlDbType.Float);
        }

        [TestMethod]
        public void GetParam_OnCurrency_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Currency, DummyString, SqlDbType.Float);
        }

        [TestMethod]
        public void GetParam_OnBoolean_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Boolean, DummyString, SqlDbType.Bit);
        }

        [TestMethod]
        public void GetParam_OnDateTime_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.DateTime, DummyString, SqlDbType.DateTime);
        }

        [TestMethod]
        public void GetParam_OnCalculatedAndCurrency_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Calculated, "currency", SqlDbType.Float);
        }

        [TestMethod]
        public void GetParam_OnCalculatedAndNumber_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Calculated, "number", SqlDbType.Float);
        }

        [TestMethod]
        public void GetParam_OnCalculatedAndDateTime_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Calculated, "datetime", SqlDbType.DateTime);
        }

        [TestMethod]
        public void GetParam_OnCalculatedAndBoolean_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Calculated, "boolean", SqlDbType.Bit);
        }

        [TestMethod]
        public void GetParam_OnCalculatedAndText_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Calculated, "text", SqlDbType.NVarChar);
        }

        [TestMethod]
        public void GetParam_OnGuid_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Guid, DummyString, SqlDbType.UniqueIdentifier);
        }

        [TestMethod]
        public void GetParam_OnCounter_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.Counter, DummyString, SqlDbType.Int);
        }

        [TestMethod]
        public void GetParam_OnURL_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.URL, DummyString, SqlDbType.NVarChar);
        }

        [TestMethod]
        public void GetParam_OnWorkflowEventType_ReturnSqlParameter()
        {
            // Arrange, Act, Assert
            TestGetParam(SPFieldType.WorkflowEventType, DummyString, SqlDbType.Float);
        }

        [TestMethod]
        public void InsertAllItemsDB_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.BulkInsertDataSetGuid = (_, _2, _3) => true;

            // Act
            var actualResult = TestEntity.InsertAllItemsDB(new DataSet(), Guid.NewGuid());

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void GetClientReportingConnection_OnValidCall_ReturnSqlConnection()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();

            // Act
            var actualResult = TestEntity.GetClientReportingConnection();

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetDefaultColumnValue_OnSiteId_ReturnObject()
        {
            // Arrange, Act, Assert
            TestGetDefaultColumnValue("siteid");
        }

        [TestMethod]
        public void GetDefaultColumnValue_OnWebId_ReturnObject()
        {
            // Arrange, Act, Assert
            TestGetDefaultColumnValue("webid");
        }

        [TestMethod]
        public void GetDefaultColumnValue_OnRptListId_ReturnObject()
        {
            // Arrange, Act, Assert
            TestGetDefaultColumnValue("rptlistid");
        }

        [TestMethod]
        public void GetDefaultColumnValue_OnListId_ReturnObject()
        {
            // Arrange, Act, Assert
            TestGetDefaultColumnValue("listid");
        }

        [TestMethod]
        public void GetDefaultColumnValue_OnItemId_ReturnObject()
        {
            // Arrange, Act, Assert
            TestGetDefaultColumnValue("itemid");
        }

        [TestMethod]
        public void GetDefaultColumnValue_OnWebUrl_ReturnObject()
        {
            // Arrange, Act, Assert
            TestGetDefaultColumnValue("weburl");
        }

        [TestMethod]
        public void ListItemsDataTable_OnContainsField_ReturnDataTable()
        {
            // Arrange, Act, Assert
            TestListItemsDataTable(true);
        }

        [TestMethod]
        public void ListItemsDataTable_OnContainsFieldIsFalse_ReturnDataTable()
        {
            // Arrange, Act, Assert
            TestListItemsDataTable(false);
        }

        [TestMethod]
        public void MyWorkListItemsDataTable_OnContainsField_ReturnDataTable()
        {
            // Arrange, Act, Assert
            TestMyWorkListItemsDataTable(true, SPFieldType.Lookup);
        }

        [TestMethod]
        public void MyWorkListItemsDataTable_OnContainsFieldAndNotLookup_ReturnDataTable()
        {
            // Arrange, Act, Assert
            TestMyWorkListItemsDataTable(true, SPFieldType.MultiChoice);
        }

        [TestMethod]
        public void MyWorkListItemsDataTable_OnContainsFieldIsFalse_ReturnDataTable()
        {
            // Arrange, Act, Assert
            TestMyWorkListItemsDataTable(false, SPFieldType.AllDayEvent);
        }

        [TestMethod]
        public void AddMetaInfoCols_OnValidCall_ReturnDataTable()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add("RPTListId", typeof(string));
            dataTable.Columns.Add("ColumnType", typeof(string));
            dataTable.Columns.Add("ColumnName", typeof(string));
            dataTable.Columns.Add("SharepointType", typeof(string));
            dataTable.Columns.Add("internalname", typeof(string));
            dataTable.Columns.Add(DummyString, typeof(string));
            dataTable.Columns.Add("Test", typeof(string));
            dataTable.Rows.Add(DummyString, DummyString, DummyString, DummyString, DummyString, DummyString, DummyString);
            SetupShimsForSharePoint();

            // Act
            var actualResult = PrivateObject.Invoke("AddMetaInfoCols", dataTable) as DataTable;

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(6));
        }

        [TestMethod]
        public void SnapshotLists_OnValidCall_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, _2) => true;

            // Act
            var actualResult = TestEntity.SnapshotLists(DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void InitializeStatusLog_OnValidCall_InvokeInitializeStatusLog()
        {
            // Arrange
            var initializeStatusLogInvoked = false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.InitializeStatusLog = _ => { initializeStatusLogInvoked = true; };

            // Act
            TestEntity.InitializeStatusLog();

            // Assert
            initializeStatusLogInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void LogStatus_OnPassingGuid_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, _2, _3, _4, _5, _6, _7, _8) => true;

            // Act
            var actualResult = TestEntity.LogStatus(Guid.NewGuid(), DummyString, DummyString, DummyString, DummyInt, DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void LogStatus_OnPassingString_ReturnBoolean()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, _2, _3, _4, _5, _6, _7, _8) => true;

            // Act
            var actualResult = TestEntity.LogStatus(DummyString, DummyString, DummyString, DummyString, DummyInt, DummyInt, DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void GetStatusLog_OnValidCall_ReturnDataTable()
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetStatusLog = _ =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString, typeof(string));
                dataTable.Rows.Add(DummyString);
                return dataTable;
            };

            // Act
            var actualResult = TestEntity.GetStatusLog();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt),
                () => actualResult.Rows[0][DummyString].ShouldNotBeNull(),
                () => actualResult.Rows[0][DummyString].ShouldBe(DummyString));
        }

        [TestMethod]
        public void UpdateItem_OnValidCall_InvokeUpdateListItem()
        {
            // Arrange
            var updateListItemInvoked = false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimReportData.AllInstances.UpdateListItemString = (_, _2) =>
            {
                updateListItemInvoked = true;
                return true;
            };
            ShimReportData.AllInstances.UpdateSQLStringDataTableSPListItemArrayListArrayList = (_, _2, _3, _4, _5, _6) => DummyString;
            ShimReportData.AllInstances.GetListColumnsGuid = (_, __) => new DataTable();

            // Act
            TestEntity.UpdateItem(Guid.NewGuid(), new ShimSPListItem(), DummyString);

            // Assert
            updateListItemInvoked.ShouldBeTrue();
        }

        private void TestMyWorkListItemsDataTable(bool containsField, SPFieldType type)
        {
            // Arrange
            var error = false;
            var errorMessage = string.Empty;
            SetupShimsForSharePoint();
            ShimEPMData.AllInstances.GetTableNameGuid = (_, __) => DummyString;
            ShimEPMData.AllInstances.SaveWorkSPListItem = (_, __) => true;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, _2) => true;
            ShimReportData.AllInstances.ListReportsWorkString = (_, _2) => true;
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, _2) => containsField;
            ShimReportData.AllInstances.AddMetaInfoColsDataTable = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("ColumnType", typeof(string));
                dataTable.Columns.Add("ColumnName", typeof(string));
                dataTable.Columns.Add("SharepointType", typeof(string));
                dataTable.Columns.Add("internalname", typeof(string));
                dataTable.Rows.Add(DummyString, "assignedtotext", "lookup", DummyString);
                dataTable.Rows.Add("uniqueidentifier", "text", "lookup", DummyString);
                dataTable.Rows.Add("uniqueidentifier", "1text", "lookup", string.Empty);
                dataTable.Rows.Add("int", "id", "lookup", DummyString);
                dataTable.Rows.Add("int", "1id", "lookup", string.Empty);
                dataTable.Rows.Add("datetime", $"1{DummyString}", "multichoice", DummyString);
                dataTable.Rows.Add("datetime", $"2{DummyString}", "multichoice", string.Empty);

                dataTable.Rows.Add("float", $"3{DummyString}", DummyString, DummyString);
                dataTable.Rows.Add(DummyString, $"4{DummyString}", DummyString, DummyString);
                dataTable.Rows.Add(DummyString, "Work", DummyString, DummyString);
                dataTable.Rows.Add(DummyString, "WorkType", DummyString, DummyString);
                dataTable.Rows.Add("int", "DataSource", DummyString, DummyString);
                return dataTable;
            };
            ShimReportData.AllInstances.GetListColumnsString = (_, _2) => new DataTable();
            ShimReportData.AllInstances.VerifyListColumnsDataTableString = (_, _2, _3) => { };
            ShimReportData.AddLookUpFieldValuesStringString = (_, str) =>
            {
                if (str.Equals("text"))
                {
                    return Guid.NewGuid().ToString();
                }
                return DummyInt.ToString();
            };
            ShimReportData.AllInstances.GetDefaultColumnValueStringSPListItemBooleanOut =
                (ReportData data, string str, SPListItem arg3, out bool blnGuid) =>
                {
                    if (str.EndsWith("id")
                        || str.Equals($"3{DummyString.ToLower()}")
                        || str.Equals("datasource"))
                    {
                        blnGuid = false;
                        return DummyInt;
                    }

                    if (str.Equals($"1{DummyString.ToLower()}") || str.Equals($"2{DummyString.ToLower()}"))
                    {
                        blnGuid = false;
                        return DateTime.Now;
                    }

                    blnGuid = true;
                    return Guid.NewGuid();
                };
            ShimSPField.AllInstances.TypeAsStringGet = _ => "totalrollup";
            ShimSPField.AllInstances.TypeGet = _ => type;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPList.AllInstances.ItemsGet = _ =>
            {
                var list = new List<SPListItem>
                {
                    new ShimSPListItem()
                };
                return new ShimSPListItemCollection().Bind(list);
            };
            ShimSPListItem.AllInstances.ItemGetString = (_, str) => str;

            // Act
            var actualResult = TestEntity.MyWorkListItemsDataTable(Guid.NewGuid(), DummyString, new ShimSPWeb(), DummyString, new ArrayList(),
                Guid.NewGuid(), out error,
                out errorMessage);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt));
        }

        private void TestListItemsDataTable(bool containsField)
        {
            // Arrange
            var error = false;
            var errorMessage = string.Empty;
            SetupShimsForSharePoint();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, _2) => containsField;
            ShimReportData.AllInstances.GetListColumnsGuid = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("ColumnType", typeof(string));
                dataTable.Columns.Add("ColumnName", typeof(string));
                dataTable.Columns.Add("SharepointType", typeof(string));
                dataTable.Columns.Add("internalname", typeof(string));
                dataTable.Rows.Add("uniqueidentifier", "text", "lookup", DummyString);
                dataTable.Rows.Add("uniqueidentifier", "1text", "lookup", string.Empty);
                dataTable.Rows.Add("int", "id", "user", DummyString);
                dataTable.Rows.Add("int", "1id", "user", string.Empty);
                dataTable.Rows.Add("datetime", $"1{DummyString}", "multichoice", DummyString);
                dataTable.Rows.Add("float", $"2{DummyString}", DummyString, DummyString);
                dataTable.Rows.Add(DummyString, $"3{DummyString}", DummyString, DummyString);
                return dataTable;
            };
            ShimReportData.AllInstances.VerifyListColumnsDataTableString = (_, _2, _3) => { };
            ShimReportData.AddLookUpFieldValuesStringString = (_, str) =>
            {
                if (str.Equals("text"))
                {
                    return Guid.NewGuid().ToString();
                }
                return DummyInt.ToString();
            };
            ShimReportData.AllInstances.GetDefaultColumnValueStringSPListItemBooleanOut =
                (ReportData data, string str, SPListItem arg3, out bool blnGuid) =>
                {
                    if (str.EndsWith("id") || str.Equals($"2{DummyString.ToLower()}"))
                    {
                        blnGuid = false;
                        return DummyInt;
                    }

                    if (str.Equals($"1{DummyString.ToLower()}"))
                    {
                        blnGuid = false;
                        return DateTime.Now;
                    }
                    blnGuid = true;
                    return Guid.NewGuid();
                };
            ShimSPField.AllInstances.TypeAsStringGet = _ => "totalrollup";
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Boolean;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPList.AllInstances.ItemsGet = _ =>
            {
                var list = new List<SPListItem>
                {
                    new ShimSPListItem()
                };
                return new ShimSPListItemCollection().Bind(list);
            };
            ShimSPListItem.AllInstances.ItemGetString = (_, str) => str;

            // Act
            var actualResult = TestEntity.ListItemsDataTable(Guid.NewGuid(), DummyString, new ShimSPWeb(), DummyString, new ArrayList(), out error,
                out errorMessage);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(DummyInt));
        }

        private void TestGetDefaultColumnValue(string sColumn)
        {
            // Arrange
            var guid = Guid.NewGuid();
            SetupShimsForSharePoint();
            ShimSPSite.AllInstances.IDGet = _ => guid;
            ShimSPWeb.AllInstances.IDGet = _ => guid;
            ShimSPList.AllInstances.IDGet = _ => guid;
            ShimSPListItem.AllInstances.IDGet = _ => DummyInt;

            // Act
            var actualResult = PrivateObject.Invoke("GetDefaultColumnValue", sColumn, new ShimSPListItem().Instance, false);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () =>
                {
                    if (sColumn.Equals("itemid"))
                    {
                        actualResult.ShouldBe(DummyInt);
                    }
                    else if (sColumn.Equals("weburl"))
                    {
                        actualResult.ShouldBe(DummyUrl);
                    }
                    else
                    {
                        actualResult.ShouldBe(guid);
                    }
                },
                () => actualResult.ShouldNotBeNull());
        }

        private void TestGetParam(SPFieldType type, string sColumn, SqlDbType expecteDbType)
        {
            // Arrange
            ShimSPField.AllInstances.TypeGet = _ => type;
            ShimSPField.AllInstances.TypeAsStringGet = _ => "totalrollup";
            ShimSPField.AllInstances.GetPropertyString = (_, __) => sColumn;

            // Act
            var actualResult = ReportData.GetParam(new ShimSPField(), sColumn);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.SqlDbType.ShouldBe(expecteDbType));
        }

        private void TestPopulateMandatoryHiddenFldsColumnValue(string sColumn)
        {
            // Arrange
            SetupShimsForSharePoint();
            ShimSPListItem.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("CommentCount"))
                {
                    return DummyInt;
                }
                return DummyString;
            };

            // Act
            var actualResult = PrivateObject.Invoke("PopulateMandatoryHiddenFldsColumnValue", sColumn, new ShimSPListItem().Instance) as SqlParameter;

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () =>
                {
                    if (sColumn.Equals("commentcount"))
                    {
                        actualResult.Value.ShouldBe(DummyInt);
                    }
                    else
                    {
                        actualResult.Value.ShouldBe(DummyString);
                    }
                },
                () => actualResult.ParameterName.ShouldBe($"@{sColumn}"));
        }

        private void TestPopulateDefaultColumnValue(string sColumn)
        {
            // Arrange
            SetupShimsForSharePoint();

            // Act
            var actualResult = PrivateObject.Invoke("PopulateDefaultColumnValue", sColumn, new ShimSPListItem().Instance) as SqlParameter;

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () =>
                {
                    if (sColumn.Equals("listid"))
                    {
                        actualResult.ParameterName.ShouldBe("@rptlistid");
                    }
                    else
                    {
                        actualResult.ParameterName.ShouldBe($"@{sColumn}");
                    }
                });
        }

        private void TestAddColumnValues(bool containsField, bool isLookUpField, SPFieldType type, bool isMultiChoice)
        {
            // Arrange
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, _2) => "lookup";
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            var dataTable = new DataTable();
            dataTable.Columns.Add("ColumnName", typeof(string));
            dataTable.Columns.Add("InternalName", typeof(string));
            dataTable.Columns.Add("SiteId", typeof(string));
            dataTable.Columns.Add("SharePointType", typeof(string));
            dataTable.Rows.Add(DummyString, DummyString, DummyString, DummyString);
            dataTable.Rows.Add("Test", DummyString, DummyString, "Lookup");
            dataTable.Rows.Add("text", DummyString, DummyString, "Lookup");
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => $";#{DummyString};#";
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, _2) => containsField;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) =>
            {
                if (isMultiChoice)
                {
                    return new ShimSPFieldMultiChoice();
                }

                return new ShimSPField();
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Integer;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => type;
            ShimReportData.AllInstances.PopulateDefaultColumnValueStringSPListItem = (_, _2, _3) => new SqlParameter();
            ShimReportData.AllInstances.PopulateMandatoryHiddenFldsColumnValueStringSPListItem = (_, _2, _3) => new SqlParameter();
            ShimReportData.GetParamSPFieldString = (_, _2) => new SqlParameter
            {
                SqlDbType = SqlDbType.Float
            };
            ShimReportData.AllInstances.IsLookUpFieldStringString = (_, _2, _3) => isLookUpField;
            ShimReportData.AddMultiChoiceValuesStringString = (_, _2) => DummyString;
            ShimReportData.AddLookUpFieldValuesStringString = (_, _2) => DummyString;

            // Act
            var actualResult = PrivateObject.Invoke("AddColumnValues",
                new ShimSPListItem().Instance,
                dataTable,
                new ArrayList { DummyString.ToLower() },
                new ArrayList { "test" },
                "insert") as string;

            // Assert
            if (isLookUpField)
            {
                actualResult.ShouldContain(" VALUES(Parameter1,Parameter2,@text) ");
            }
            else
            {
                actualResult.ShouldContain($" VALUES(Parameter1,Parameter2,@{DummyString}) ");
            }
        }

        private void TestInitializeDatabase(bool queryResult)
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => queryResult;

            // Act
            var actualResult = TestEntity.InitializeDatabase();

            // Assert
            actualResult.ShouldBe(queryResult);
        }

        private void TestGetDbVersion(ConnectionState state, int rowsCount)
        {
            // Arrange
            SetupShimsForSqlClient();
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetSpecificReportingDbConnectionGuid = (_, __) => new SqlConnection();
            ShimSqlConnection.AllInstances.StateGet = _ => state;
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, _2) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Version", typeof(string));
                dataTable.Columns.Add("Installed On", typeof(string));
                if (rowsCount > 0)
                {
                    dataTable.Rows.Add(DummyString, DummyString);
                }

                return dataTable;
            };

            // Act
            var actualResult = TestEntity.GetDbVersion(Guid.NewGuid());

            // Assert
            if (state == ConnectionState.Open && rowsCount.Equals(DummyInt))
            {
                actualResult.ShouldContain(DummyString);
            }
            else if (rowsCount.Equals(0))
            {
                actualResult.ShouldContain("Unable to get version. Table may not exist.");
            }
            else
            {
                actualResult.ShouldContain("Unable to connect to database.");
            }
        }

        private void TestInsertDbEntry(bool useSqlAccount)
        {
            // Arrange
            SetupShimsForSharePoint();
            PrivateObject.SetField("_siteId", Guid.NewGuid());
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.UseSqlAccountGet = _ => useSqlAccount;
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };

            // Act
            var actualResult = TestEntity.InsertDbEntry();

            // Assert
            actualResult.ShouldBeTrue();
        }

        private void TestCreateTable(string name, bool queryResult)
        {
            // Arrange
            var message = string.Empty;
            ShimReportData.AllInstances.TableExistsString = (_, __) => false;
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => queryResult;
            ShimEPMData.AllInstances.SqlErrorGet = _ => DummyString;

            // Act
            var actualResult = TestEntity.CreateTable(
                name,
                new List<ColumnDef> { new ColumnDef(new DataColumn()) },
                true,
                out message);

            // Assert
            if (queryResult)
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => message.ShouldContain($"Table [{name}] successfully created."));
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeFalse(),
                    () => message.ShouldContain($"Error creating table: {DummyString}"));
            }
        }

        private void TestGetSafeTableName(int tableCount, bool isRootWeb)
        {
            // Arrange
            PrivateObject.SetField("_DAO", new ShimEPMData().Instance);
            PrivateObject.SetField("_isReportingV2Enabled", true);
            PrivateObject.SetField("_isRootWeb", isRootWeb);
            PrivateObject.SetField("_webId", Guid.NewGuid());
            ShimEPMData.AllInstances.AddParamStringObject = (_, _2, _3) => { };
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new SqlConnection();
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => tableCount;

            // Act
            var actualResult = TestEntity.GetSafeTableName(DummyString);

            // Assert
            actualResult.ShouldContain(DummyString);
        }

        private void TestConstructorWithThreeParams(bool isRootWeb, bool accountInfoIsNull, bool useSA)
        {
            // Arrange
            SetupShimsForSharePoint();
            ShimSPWeb.AllInstances.IsRootWebGet = _ => isRootWeb;
            ShimEPMData.SAccountInfoGuidGuid = (_, _2) => accountInfoIsNull ? null : new ShimDataRow();
            ShimEPMData.AllInstances.SiteNameGet = _ => DummyString;
            ShimEPMData.AllInstances.SiteUrlGet = _ => DummyUrl;
            ShimEPMData.ConstructorGuid = (_, __) => { };
            ShimDataRow.AllInstances.ItemGetString = (_, __) => useSA;

            // Act
            var actualResult = new ReportData(true, Guid.NewGuid(), Guid.NewGuid());
            var privateObject = new PrivateObject(actualResult);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => Get<bool>("_isRootWeb", privateObject).ShouldBe(isRootWeb),
                () => Get<string>("webTitle", privateObject).ShouldBe(DummyString),
                () => actualResult.SiteName.ShouldBe(DummyString),
                () => actualResult.SiteUrl.ShouldBe(DummyUrl));
        }

        private void TestConstructorWithTwoParams(bool accountInfoIsNull, bool useSA)
        {
            // Arrange
            SetupShimsForSharePoint();
            ShimEPMData.SAccountInfoGuidGuid = (_, _2) => accountInfoIsNull ? null : new ShimDataRow();
            ShimEPMData.AllInstances.SiteNameGet = _ => DummyString;
            ShimEPMData.AllInstances.SiteUrlGet = _ => DummyUrl;
            ShimEPMData.ConstructorGuid = (_, __) => { };
            ShimDataRow.AllInstances.ItemGetString = (_, __) => useSA;

            // Act
            var actualResult = new ReportData(Guid.NewGuid(), Guid.NewGuid());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.SiteName.ShouldBe(DummyString),
                () => actualResult.SiteUrl.ShouldBe(DummyUrl));
        }

        private void TestConstructorWithOneParam(bool isRootWeb, bool accountInfoIsNull, bool useSA)
        {
            // Arrange
            SetupShimsForSharePoint();
            ShimSPWeb.AllInstances.IsRootWebGet = _ => isRootWeb;
            ShimEPMData.SAccountInfoGuidGuid = (_, _2) => accountInfoIsNull ? null : new ShimDataRow();
            ShimEPMData.AllInstances.SiteNameGet = _ => DummyString;
            ShimEPMData.AllInstances.SiteUrlGet = _ => DummyUrl;
            ShimEPMData.ConstructorGuid = (_, __) => { };
            ShimDataRow.AllInstances.ItemGetString = (_, __) => useSA;

            // Act
            var actualResult = new ReportData(true, Guid.NewGuid(), Guid.NewGuid());
            var privateObject = new PrivateObject(actualResult);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => Get<bool>("_isRootWeb", privateObject).ShouldBe(isRootWeb),
                () => Get<string>("webTitle", privateObject).ShouldBe(DummyString),
                () => actualResult.SiteName.ShouldBe(DummyString),
                () => actualResult.SiteUrl.ShouldBe(DummyUrl));
        }

        private T Get<T>(string fieldOrProperty, PrivateObject privateObject = null)
        {
            if (privateObject == null)
            {
                return (T)PrivateObject.GetFieldOrProperty(fieldOrProperty);
            }

            return (T)privateObject.GetFieldOrProperty(fieldOrProperty);
        }

        private void SetupShimsForHttpRequest()
        {
            _queryString.Clear();
            _cookies.Clear();
            _httpRequest = new HttpRequest(DummyString, DummyUrl, DummyString);
            _httpResponse = new HttpResponse(TextWriter.Null);
            _httpContext = new HttpContext(_httpRequest, _httpResponse);
            ShimHttpContext.CurrentGet = () => _httpContext;
            ShimPage.AllInstances.RequestGet = _ => _httpRequest;
            ShimPage.AllInstances.ResponseGet = _ => _httpResponse;
            ShimHttpRequest.AllInstances.QueryStringGet = _ => _queryString;
            ShimHttpRequest.AllInstances.CookiesGet = _ => _cookies;
            ShimHttpResponse.AllInstances.CookiesGet = _ => _cookies;
            ShimHttpUtility.UrlEncodeString = str => str;
            ShimHttpUtility.UrlDecodeString = str => str;
            ShimHttpUtility.HtmlDecodeString = str => str;
            ShimHttpUtility.HtmlEncodeString = str => str;
        }

        private void SetupShimsForSharePoint()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.GetContextHttpContextGuidGuidSPWeb = (_, _2, _3, _4) => new ShimSPContext();
            ShimSPContext.AllInstances.ListGet = _ => new ShimSPList();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.ViewContextGet = _ => new ShimSPViewContext();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.TitleGet = _ => DummyString;
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPWeb.AllInstances.LocaleGet = _ => new CultureInfo(1033);
            ShimSPWeb.AllInstances.LanguageGet = _ => DummyInt;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.GetListFromUrlString = (_, __) => new ShimSPList();
            ShimSPWeb.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings();
            ShimSPWeb.AllInstances.PropertiesGet = _ => new ShimSPPropertyBag();
            ShimSPRegionalSettings.AllInstances.WorkDaysGet = _ => 5;
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPUser();
            ShimSPUserCollection.AllInstances.ItemGetString = (_, __) => new ShimSPUser();
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            ShimSPUser.AllInstances.NameGet = _ => DummyString;
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = elevated => { elevated(); };
            ShimSPSite.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb();
            ShimSPSite.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPFarm.LocalGet = () => new ShimSPFarm();
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();
            ShimSPPersistedObject.AllInstances.NameGet = _ => DummyString;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimSPWebApplication.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPFeature();
            ShimSPViewContext.AllInstances.ViewGet = _ => new ShimSPView();
            ShimSPForm.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPView.AllInstances.TitleGet = _ => DummyString;
            ShimSPView.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection();
            ShimSPView.AllInstances.ViewsGet = _ => new ShimSPViewCollection();
            ShimSPFieldCollection.AllInstances.CountGet = _ => DummyInt;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.DescriptionGet = _ => DummyString;
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection();
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => new ShimSPListItemCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.TitleGet = _ => DummyString;
            ShimSPList.AllInstances.BaseTypeGet = _ => SPBaseType.DiscussionBoard;
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DiscussionBoard;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            ShimSPList.AllInstances.DefaultViewGet = _ => new ShimSPView();
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb();
            ShimSPList.AllInstances.ViewsGet = _ => new ShimSPViewCollection();
            ShimSPViewCollection.AllInstances.ItemGetString = (_, __) => new ShimSPView();
            ShimSPFormCollection.AllInstances.ItemGetString = (_, __) => new ShimSPForm();
            ShimSPFormCollection.AllInstances.ItemGetPAGETYPE = (_, __) => new ShimSPForm();
            ShimSPForm.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>
            {
                new ShimSPListItem()
            }.GetEnumerator();
            ShimSPListItemCollection.AllInstances.CountGet = _ => DummyInt;
            ShimSPListItem.AllInstances.IDGet = _ => DummyInt;
            ShimSPListItem.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPList();
            ShimSPFieldUserValue.ConstructorSPWebString = (_, _2, _3) => { };
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
        }

        private static void SetupShimsForSqlClient()
        {
            var readCount = 0;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader()
                {
                    Read = () =>
                    {
                        if (readCount == 0)
                        {
                            readCount++;
                            return true;
                        }
                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => new ShimSqlCommand();
            ShimSqlDataReader.AllInstances.NextResult = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => DummyInt;
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, __) => DateTime.Now;
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (_, __) => true;
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => Guid.NewGuid();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => true;
            ShimSqlDataReader.AllInstances.NextResult = _ =>
            {
                readCount = 0;
                return true;
            };
        }
    }
}