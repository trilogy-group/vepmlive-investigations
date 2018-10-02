using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Linq;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.ReportHelper.Tests
{
    [TestClass()]
    public class ReportDataTests
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string SharepointType = "SharepointType";
        private const string InternalName = "internalname";
        private const string DummyString = "DummyString";
        private const string ColumnName = "ColumnName";
        private const string ColumnType = "ColumnType";
        private const string ColumnGuid = "ColumnGuid";
        private const string ColumnInt = "ColumnInt";
        private const string ColumnDataTime = "ColumnDateTime";
        private const string ColumnFloat = "ColumnFloat";
        private ReportData reportData;
        private IDisposable shimsContext;

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
            ShimReportData.AddLookUpFieldValuesStringString = (value, valueType) => DummyString;
            ShimDataTable.AllInstances.NewRow = _ => new ShimDataRow();
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
        public void MyWorkListItemsDataTable_OnSuccess_ReturnsDataTable()
        {
            // Arrange
            const string AssignedToText = "AssignedToText";
            const string DummyText = "dummyText";
            const string DummyIdColumn = "dummyId";
            const string DummyColumnGrid = "DummyColumnGrid";
            const string DummyColumnGuid = "DummyColumnGuid";
            var columnsTuple = new List<Tuple<string, object>>();
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
                        ItemGetString = GetItemValues(AssignedToText, SPFieldType.Lookup.ToString(), SPFieldType.Lookup.ToString())
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetItemValues(DummyText, SPFieldType.Lookup.ToString(), SPFieldType.Lookup.ToString())
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetItemValues(DummyIdColumn, SPFieldType.Lookup.ToString(), SPFieldType.Lookup.ToString())
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetItemValues(DummyColumnGrid, SPFieldType.GridChoice.ToString(), SPFieldType.GridChoice.ToString())
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetItemValues(DummyColumnGuid, SPFieldType.GridChoice.ToString(), SPFieldType.Guid.ToString())
                    },
                }.GetEnumerator()
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, name) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, name) => new ShimSPField
            {
                TypeGet = () =>
                {
                    SPFieldType type;
                    if (Enum.TryParse<SPFieldType>(name, out type))
                    {
                        return type;
                    }
                    else
                    {
                        return SPFieldType.AllDayEvent;
                    }
                }
            };
            var spFieldUserEnumerator = new List<SPFieldUserValue>
            {
                new ShimSPFieldUserValue
                {
                    UserGet = () => new ShimSPUser
                    {
                        NameGet = () => DummyString
                    }
                }
            }.GetEnumerator();
            ShimList<SPFieldUserValue>.AllInstances.GetEnumerator = _ => spFieldUserEnumerator;
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
                        ItemSetStringObject = (name, valueObject) => { },
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = name => new ShimSPField()
                        }
                    },
                }.GetEnumerator()
            };
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, name) => true;
            ShimDataRow.AllInstances.ItemSetStringObject = (_, columnName, objectValue) =>
            {
                columnsTuple.Add(new Tuple<string, object>(columnName, objectValue));
            };

            // Act
            var result = reportData.MyWorkListItemsDataTable(DummyGuid, DummyString, web, DummyString, list, DummyGuid, out error, out errorMessage);
            var assignetToTextValue = columnsTuple.FirstOrDefault(p => p.Item1 == AssignedToText)?.Item2.ToString();
            var dummyTextValue = columnsTuple.FirstOrDefault(p => p.Item1 == DummyText)?.Item2.ToString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => error.ShouldBeFalse(),
                () => errorMessage.ShouldBeEmpty(),
                () => result.ShouldNotBeNull(),
                () => assignetToTextValue.ShouldNotBeNullOrEmpty(),
                () => assignetToTextValue.ShouldBe(DummyString),
                () => dummyTextValue.ShouldNotBeNullOrEmpty(),
                () => dummyTextValue.ShouldBe(DummyString));
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

        private FakesDelegates.Func<string, object> GetItemValues(string columnName, string internalName, string sharepointType)
        {
            return name =>
            {
                switch (name)
                {
                    case ColumnName:
                        return columnName;
                    case InternalName:
                        return internalName;
                    case SharepointType:
                        return sharepointType;
                    default:
                        return string.Empty;
                }
            };
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
    }
}