using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.ReportHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using System.Data;
using EPMLiveCore.ReportHelper.Fakes;
using System.Data.SqlClient;
using Microsoft.QualityTools.Testing.Fakes;
using System.Collections;
using System.Data.Fakes;
using Shouldly;
using EPMLiveCore.Fakes;

namespace EPMLiveCore.ReportHelper.Tests
{
    [TestClass()]
    public class ReportDataTests
    {
        private IDisposable shimsContext;
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private const string ColumnName = "ColumnName";
        private const string ColumnType = "ColumnType";
        private const string ColumnGuid = "ColumnGuid";
        private const string ColumnInt = "ColumnInt";
        private const string ColumnDataTime = "ColumnDateTime";
        private const string ColumnFloat = "ColumnFloat";
        private ReportData reportData;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            reportData = new ReportData(DummyGuid, DummyString, DummyString, true, DummyString, DummyString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
            reportData?.Dispose();
        }

        private void SetupShims()
        {
            ShimEPMData.ConstructorGuidStringStringBooleanStringString = (_, siteId, dbName, serverName, useSAccount, username, password) => { };
            ShimReportData.AllInstances.GetListColumnsString = (_, name) => new DataTable();
            ShimReportData.AllInstances.AddMetaInfoColsDataTable = (_, dt) => new DataTable();
            ShimReportData.AllInstances.VerifyListColumnsDataTableString = (_, dataTable, tableName) => { };
            ShimReportData.AllInstances.ListReportsWorkString = (_, name) => true;
            ShimEPMData.AllInstances.SaveWorkSPListItem = (_, list) => true;

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
        public void MyWorkListItemsDataTable_Should_ReturnExpectedDataTableColumns()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => new ShimSPList()
                }
            };
            var list = new ArrayList();
            var error = false;
            var errorMessage = string.Empty;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = GetColumnValues("uniqueidentifier", ColumnGuid)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetColumnValues("int", ColumnInt)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetColumnValues("datetime", ColumnDataTime)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetColumnValues("float", ColumnFloat)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetColumnValues("unknownValue", DummyString)
                    }
                }.GetEnumerator()
            };
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection
            {
                GetEnumerator = () => new List<SPListItem>().GetEnumerator()
            };

            // Act
            var result = reportData.MyWorkListItemsDataTable(DummyGuid, DummyString, web, DummyString, list, DummyGuid, out error, out errorMessage);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => error.ShouldBeFalse(),
                () => errorMessage.ShouldBeEmpty(),
                () => result.ShouldNotBeNull(),
                () => ValidateColumsName(result));
        }

        [TestMethod]
        public void MyWorkListItemsDataTable_Should_()
        {
            // Arrange
            var web = new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => new ShimSPList()
                }
            };
            var list = new ArrayList();
            var error = false;
            var errorMessage = string.Empty;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => SPFieldType.Lookup.ToString()
                    }
                    //new ShimDataRow
                    //{
                    //    ItemGetString = GetColumnValues("uniqueidentifier", "column-guid")
                    //},
                    //new ShimDataRow
                    //{
                    //    ItemGetString = GetColumnValues("int", "column-int")
                    //},
                    //new ShimDataRow
                    //{
                    //    ItemGetString = GetColumnValues("datetime", "column-datetime")
                    //},
                    //new ShimDataRow
                    //{
                    //    ItemGetString = GetColumnValues("float", "column-float")
                    //},
                    //new ShimDataRow
                    //{
                    //    ItemGetString = GetColumnValues("defaultValue", DummyString)
                    //}
                }.GetEnumerator()
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, name) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) => new ShimSPField
            {
                TypeGet = () => SPFieldType.AllDayEvent
            };


            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection
            {
                GetEnumerator = () => new List<SPListItem>
                {
                    new ShimSPListItem
                    {
                        IDGet = () => 1,
                        TitleGet = () => DummyString,
                        ParentListGet = () => new ShimSPList
                        {
                            FieldsGet = () => new ShimSPFieldCollection()
                        },
                        ItemGetString = name => DummyString,
                        ItemSetStringObject = (name, valueObject) => { }
                    },
                }.GetEnumerator()
            };
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, name) => true;
            //ShimDataRow.AllInstances.ItemGetString = (_, name) => new object();
            //ShimDataRow.AllInstances.ItemSetStringObject = (_, name, objectValue) => { };
            ShimDataTable.AllInstances.NewRow = _ => new ShimDataRow();
            // Act
            var result = reportData.MyWorkListItemsDataTable(DummyGuid, DummyString, web, DummyString, list, DummyGuid, out error, out errorMessage);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => error.ShouldBeFalse(),
                () => errorMessage.ShouldBeEmpty(),
                () => result.ShouldNotBeNull());
        }

        private FakesDelegates.Func<string, object> GetColumnValues(string colType, string colName)
        {
            return name =>
            {
                switch (name)
                {
                    case ColumnType:
                        return colType;
                    case ColumnName:
                        return colName;
                    default:
                        return DummyString;
                }
            };
        }

        private void ValidateColumsName(DataTable dataTable)
        {
            dataTable.Columns[ColumnGuid].ShouldNotBeNull();
            dataTable.Columns[ColumnGuid].DataType.ShouldBe(typeof(Guid));
            dataTable.Columns[ColumnInt].ShouldNotBeNull();
            dataTable.Columns[ColumnInt].DataType.ShouldBe(typeof(decimal));
            dataTable.Columns[ColumnDataTime].ShouldNotBeNull();
            dataTable.Columns[ColumnDataTime].DataType.ShouldBe(typeof(DateTime));
            dataTable.Columns[ColumnFloat].ShouldNotBeNull();
            dataTable.Columns[ColumnFloat].DataType.ShouldBe(typeof(decimal));
        }

        [TestMethod]
        public void MyWorkListItemsDataTable_OnException_ReturnError()
        {
            // Arrange
            var web = new ShimSPWeb();
            var list = new ArrayList();
            var error = false;
            var errorMessage = string.Empty;
            ShimReportData.AllInstances.VerifyListColumnsDataTableString = (_, dataTable, tableName) => 
            {
                throw new Exception(DummyString);
            };

            // Act
            ReportData report = new ReportData(DummyGuid, DummyString, DummyString, true, DummyString, DummyString);
            var result = report.MyWorkListItemsDataTable(DummyGuid, DummyString, web, DummyString, list, DummyGuid, out error, out errorMessage);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => error.ShouldBeTrue(),
                () => errorMessage.ShouldNotBeNullOrEmpty(),
                () => errorMessage.ShouldContain(DummyString));
        }

    }
}