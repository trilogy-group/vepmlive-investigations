using System;
using System.Collections;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveReportsAdmin;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveReporting.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ListRefreshTests2
    {
        private IDisposable _shimContext;
        private RefreshLists _testObject;
        private PrivateObject _privateObject;

        private const string IsReportingListMethodName = "IsReportingList";
        private const string AddItemsMethodName = "AddItems";
        private const string AddItemsMyWorkMethodName = "AddItems_MyWork";
        private const string ArrayListNamesField = "_ArrayListNames";
        private const string ArrayListTableNamesField = "_ArrayListTableNames";
        private const string DsListsField = "_dsLists";
        private const string DsMyWorkListsField = "_dsMyWorkLists";
        private const string ArrayListDefaultColumnsField = "_arrayListdefaultColumns";

        private static readonly DateTime DummyDateTimeNow = new DateTime(2018, 6, 15, 0, 0, 0, DateTimeKind.Utc);
        private static readonly Guid DummySiteGuid = new Guid("e1e2a29b-e5c3-4fe8-97c6-c1103e253d0d");
        private static readonly Guid DummyGuid = new Guid("93c80c9b-c518-4076-ab9a-f87723d28a19");
        private static readonly Guid DummyGuid2 = new Guid("a9bee730-07a4-42e7-9740-60aaf53efae2");
        private const string DummyItemName = "DummyItemName";
        private const string DummyItemName2 = "DummyItemName2";
        private const string DummyItemName3 = "DummyItemName3";
        private const string DummyList3Items = "DummyItemName,DummyItemName2,DummyItemName3";
        private const string DummyString = "DummyString";
        private const string DummyResultText = "DummyResultText";
        private const string DummyResultTextListNotPresent = "list not present";
        private const string DummyResultTextFailed = "failed";
        private const string DummyWebName = "DummyWebName ";
        private const string DummyWebUrl = "DummyWebUrl";
        private const string ListNameField = "ListName";
        private const string ResultTextField = "ResultText";
        private const string ShortNameField = "ShortMessage";
        private const string LongMessageField = "LongMessage";
        private const string TypeField = "Type";
        private const string TimestampField = "Timestamp";
        private const string TimerJobGuidField = "timerjobguid";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            ShimDateTime.NowGet = () => DummyDateTimeNow;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void Constructor_EmptyList_FillPropertiesFromDb()
        {
            // Arrange
            var spWeb = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummySiteGuid
                }
            };

            ShimReportData.ConstructorGuid = (sender, guid) =>
            {
                var reportData = new ShimReportData(sender)
                {
                    GetListMappings = () =>
                    {
                        var dataTable = new DataTable();
                        dataTable.Columns.Add(ListNameField);

                        var row = dataTable.NewRow();
                        row[ListNameField] = DummyItemName;
                        dataTable.Rows.Add(row);

                        return dataTable;
                    }
                };
            };

            // Act
            _testObject = new RefreshLists(spWeb, string.Empty);

            // Assert
            _privateObject = new PrivateObject(_testObject);
            var arrayListNames = (string[])_privateObject.GetField(ArrayListNamesField);
            var arrayListTableNames = (ArrayList)_privateObject.GetField(ArrayListTableNamesField);
            var dsLists = (DataSet)_privateObject.GetField(DsListsField);
            var dsMyWorkLists = (DataSet)_privateObject.GetField(DsMyWorkListsField);
            var arrayListDefaultColumns = (ArrayList)_privateObject.GetField(ArrayListDefaultColumnsField);

            this.ShouldSatisfyAllConditions(
                () => arrayListNames[0].ShouldBe(DummyItemName),
                () => arrayListTableNames.ShouldNotBeNull(),
                () => dsLists.ShouldNotBeNull(),
                () => dsMyWorkLists.ShouldNotBeNull(),
                () => arrayListDefaultColumns.Count.ShouldBe(5));
        }

        [TestMethod]
        public void Constructor_ListWith1Item_FillPropertiesFromList()
        {
            // Arrange
            var spWeb = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummySiteGuid
                }
            };

            ShimReportData.ConstructorGuid = (sender, guid) =>
            {
                var reportData = new ShimReportData(sender);
            };

            // Act
            _testObject = new RefreshLists(spWeb, DummyItemName);

            // Assert
            _privateObject = new PrivateObject(_testObject);
            var arrayListNames = (string[])_privateObject.GetField(ArrayListNamesField);
            var arrayListTableNames = (ArrayList)_privateObject.GetField(ArrayListTableNamesField);
            var dsLists = (DataSet)_privateObject.GetField(DsListsField);
            var dsMyWorkLists = (DataSet)_privateObject.GetField(DsMyWorkListsField);
            var arrayListDefaultColumns = (ArrayList)_privateObject.GetField(ArrayListDefaultColumnsField);

            this.ShouldSatisfyAllConditions(
                () => arrayListNames[0].ShouldBe(DummyItemName),
                () => arrayListTableNames.ShouldNotBeNull(),
                () => dsLists.ShouldNotBeNull(),
                () => dsMyWorkLists.ShouldNotBeNull(),
                () => arrayListDefaultColumns.Count.ShouldBe(5));
        }

        [TestMethod]
        public void Constructor_ListWith3Item_FillPropertiesFromList()
        {
            // Arrange
            var spWeb = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummySiteGuid
                }
            };

            ShimReportData.ConstructorGuid = (sender, guid) =>
            {
                var reportData = new ShimReportData(sender);
            };

            // Act
            _testObject = new RefreshLists(spWeb, DummyList3Items);

            // Assert
            _privateObject = new PrivateObject(_testObject);
            var arrayListNames = (string[])_privateObject.GetField(ArrayListNamesField);
            var arrayListTableNames = (ArrayList)_privateObject.GetField(ArrayListTableNamesField);
            var dsLists = (DataSet)_privateObject.GetField(DsListsField);
            var dsMyWorkLists = (DataSet)_privateObject.GetField(DsMyWorkListsField);
            var arrayListDefaultColumns = (ArrayList)_privateObject.GetField(ArrayListDefaultColumnsField);

            this.ShouldSatisfyAllConditions(
                () => arrayListNames[0].ShouldBe(DummyItemName),
                () => arrayListNames[1].ShouldBe(DummyItemName2),
                () => arrayListNames[2].ShouldBe(DummyItemName3),
                () => arrayListTableNames.ShouldNotBeNull(),
                () => dsLists.ShouldNotBeNull(),
                () => dsMyWorkLists.ShouldNotBeNull(),
                () => arrayListDefaultColumns.Count.ShouldBe(5));
        }

        [TestMethod]
        public void IsReportingListMethodName_ItemInTheList_ReturnsTrue()
        {
            // Arrange
            InitRefreshLists();

            // Act
            var actualResult = (bool)_privateObject.Invoke(IsReportingListMethodName, DummyItemName);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void IsReportingListMethodName_ItemNotInTheList_ReturnsTrue()
        {
            // Arrange
            InitRefreshLists();

            // Act
            var actualResult = (bool)_privateObject.Invoke(IsReportingListMethodName, DummyString);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void AddItems_OnValidCall_DsListAddTable()
        {
            // Arrange
            InitRefreshLists();

            ShimReportData.AllInstances.ListItemsDataTableGuidStringSPWebStringArrayListBooleanOutStringOut =
                (ReportData sender,
                    Guid timerJobGuid,
                    string sTableName,
                    SPWeb spWeb,
                    string sListName,
                    ArrayList defaultColumns,
                    out bool errorParam,
                    out string errMsg) =>
                {
                    errorParam = false;
                    errMsg = string.Empty;

                    var dataTable = new DataTable();
                    dataTable.Columns.Add(ListNameField);

                    var row = dataTable.NewRow();
                    row[ListNameField] = DummyItemName;
                    dataTable.Rows.Add(row);

                    return dataTable;
                };

            var args = new object[] { DummyGuid, DummyItemName, false, string.Empty };

            // Act
            _privateObject.Invoke(AddItemsMethodName, args);

            // Assert
            var dsLists = (DataSet)_privateObject.GetField(DsListsField);

            dsLists.Tables.Count.ShouldBe(1);
        }

        [TestMethod]
        public void AddItemsMyWork_OnValidCall_DsListAddTable()
        {
            // Arrange
            InitRefreshLists();

            ShimReportData.AllInstances.MyWorkListItemsDataTableGuidStringSPWebStringArrayListGuidBooleanOutStringOut =
                (ReportData sender,
                    Guid timerJobGuid,
                    string sTableName,
                    SPWeb spWeb,
                    string sListName,
                    ArrayList defaultColumns,
                    Guid listId,
                    out bool errorParam,
                    out string errMsg) =>
                {
                    errorParam = false;
                    errMsg = string.Empty;

                    var dataTable = new DataTable();
                    dataTable.Columns.Add(ListNameField);

                    var row = dataTable.NewRow();
                    row[ListNameField] = DummyItemName;
                    dataTable.Rows.Add(row);

                    return dataTable;
                };

            var args = new object[] { DummyGuid, DummyItemName, DummyGuid2, false, string.Empty };

            // Act
            _privateObject.Invoke(AddItemsMyWorkMethodName, args);

            // Assert
            var dsMyWorkLists = (DataSet)_privateObject.GetField(DsMyWorkListsField);

            dsMyWorkLists.Tables.Count.ShouldBe(1);
        }

        [TestMethod]
        public void AppendStatus_ListResultContainsListNotPresentFalseWebResultsResultTextNotEmpty_UpdateListResults()
        {
            // Arrange
            InitRefreshLists();
            var dtListResults = new DataTable();
            dtListResults.Columns.Add(ListNameField);
            dtListResults.Columns.Add(ResultTextField);
            var row = dtListResults.NewRow();
            row[ListNameField] = DummyItemName;
            row[ResultTextField] = DummyResultText;
            dtListResults.Rows.Add(row);

            var row2 = dtListResults.NewRow();
            row2[ListNameField] = DummyItemName;
            row2[ResultTextField] = string.Empty;
            dtListResults.Rows.Add(row2);

            var dtWebResults = new DataTable();
            dtWebResults.Columns.Add(ListNameField);
            dtWebResults.Columns.Add(ResultTextField);
            var rowWeb = dtWebResults.NewRow();
            rowWeb[ListNameField] = DummyItemName;
            rowWeb[ResultTextField] = DummyResultText;

            var rowWeb2 = dtWebResults.NewRow();
            rowWeb2[ListNameField] = DummyItemName;
            rowWeb2[ResultTextField] = DummyResultText;
            dtWebResults.Rows.Add(rowWeb2);

            // Act
            _testObject.AppendStatus(DummyWebName, DummyWebUrl, dtListResults, dtWebResults);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dtListResults.Rows[0][ResultTextField].ShouldBe($"{DummyResultText}Processing Web: {DummyWebName} ({DummyWebUrl}) <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Failed:<font style='color:red'>{DummyResultText}</font><br/>"),
                () => dtListResults.Rows[1][ResultTextField].ShouldBe($"Processing Web: {DummyWebName} ({DummyWebUrl}) <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Failed:<font style='color:red'>{DummyResultText}</font><br/>"));
        }

        [TestMethod]
        public void AppendStatus_ListResultContainsListNotPresentTrueWebResultsResultTextNotEmpty_UpdateListResults()
        {
            // Arrange
            InitRefreshLists();
            var dtListResults = new DataTable();
            dtListResults.Columns.Add(ListNameField);
            dtListResults.Columns.Add(ResultTextField);
            var row = dtListResults.NewRow();
            row[ListNameField] = DummyItemName;
            row[ResultTextField] = DummyResultText;
            dtListResults.Rows.Add(row);

            var row2 = dtListResults.NewRow();
            row2[ListNameField] = DummyItemName;
            row2[ResultTextField] = string.Empty;
            dtListResults.Rows.Add(row2);

            var dtWebResults = new DataTable();
            dtWebResults.Columns.Add(ListNameField);
            dtWebResults.Columns.Add(ResultTextField);
            var rowWeb = dtWebResults.NewRow();
            rowWeb[ListNameField] = DummyItemName;
            rowWeb[ResultTextField] = DummyResultTextListNotPresent;

            var rowWeb2 = dtWebResults.NewRow();
            rowWeb2[ListNameField] = DummyItemName;
            rowWeb2[ResultTextField] = DummyResultTextListNotPresent;
            dtWebResults.Rows.Add(rowWeb2);

            // Act
            _testObject.AppendStatus(DummyWebName, DummyWebUrl, dtListResults, dtWebResults);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dtListResults.Rows[0][ResultTextField].ShouldBe($"{DummyResultText}Processing Web: {DummyWebName} ({DummyWebUrl}) <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List not present. <br/>"),
                () => dtListResults.Rows[1][ResultTextField].ShouldBe($"Processing Web: {DummyWebName} ({DummyWebUrl}) <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List not present. <br/>"));
        }

        [TestMethod]
        public void AppendStatus_WebResultsResultTextEmpty_UpdateListResults()
        {
            // Arrange
            InitRefreshLists();
            var dtListResults = new DataTable();
            dtListResults.Columns.Add(ListNameField);
            dtListResults.Columns.Add(ResultTextField);
            var row = dtListResults.NewRow();
            row[ListNameField] = DummyItemName;
            row[ResultTextField] = DummyResultText;
            dtListResults.Rows.Add(row);

            var row2 = dtListResults.NewRow();
            row2[ListNameField] = DummyItemName;
            row2[ResultTextField] = string.Empty;
            dtListResults.Rows.Add(row2);

            var dtWebResults = new DataTable();
            dtWebResults.Columns.Add(ListNameField);
            dtWebResults.Columns.Add(ResultTextField);
            var rowWeb = dtWebResults.NewRow();
            rowWeb[ListNameField] = DummyItemName;
            rowWeb[ResultTextField] = string.Empty;

            var rowWeb2 = dtWebResults.NewRow();
            rowWeb2[ListNameField] = DummyItemName;
            rowWeb2[ResultTextField] = string.Empty;
            dtWebResults.Rows.Add(rowWeb2);

            // Act
            _testObject.AppendStatus(DummyWebName, DummyWebUrl, dtListResults, dtWebResults);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dtListResults.Rows[0][ResultTextField].ShouldBe($"{DummyResultText}Processing Web: {DummyWebName} ({DummyWebUrl}) <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; success.<br/>"),
                () => dtListResults.Rows[1][ResultTextField].ShouldBe($"Processing Web: {DummyWebName} ({DummyWebUrl}) <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; success.<br/>"));
        }

        [TestMethod]
        public void SaveResults_OnValidCall_ReturnsTrueBulkInsert()
        {
            // Arrange
            var countListIdAsk = 0;
            var actualDataSetBulk = new DataSet();
            var actualTimerJobGuid = Guid.Empty;

            InitRefreshLists();
            var dtResults = new DataTable();
            dtResults.Columns.Add(ListNameField);
            dtResults.Columns.Add(ResultTextField);
            var row = dtResults.NewRow();
            row[ListNameField] = DummyItemName;
            row[ResultTextField] = DummyResultText;
            dtResults.Rows.Add(row);

            var row2 = dtResults.NewRow();
            row2[ListNameField] = DummyItemName2;
            row2[ResultTextField] = DummyResultTextFailed;
            dtResults.Rows.Add(row2);

            ShimReportData.AllInstances.GetListIdString = (sender, listName) =>
            {
                if (countListIdAsk++ > 0)
                {
                    return DummyGuid2;
                }

                return Guid.Empty;
            };
            ShimReportData.AllInstances.BulkInsertDataSetGuid = (sender, dsLists, timerJobGuid) =>
            {
                actualDataSetBulk = dsLists;
                actualTimerJobGuid = timerJobGuid;
                return true;
            };
            ShimReportData.AllInstances.Dispose = sender => { };

            // Act
            var actualResult = _testObject.SaveResults(dtResults, DummyGuid);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => actualTimerJobGuid.ShouldBe(DummyGuid),
                () => actualDataSetBulk.ShouldNotBeNull(),
                () => actualDataSetBulk.Tables.Count.ShouldBe(1),
                () => actualDataSetBulk.Tables[0].Rows[0][ListNameField].ShouldBe(DummyItemName),
                () => actualDataSetBulk.Tables[0].Rows[0][ShortNameField].ShouldBe("Processed successfully without errors."),
                () => actualDataSetBulk.Tables[0].Rows[0][LongMessageField].ShouldBe(DummyResultText),
                () => actualDataSetBulk.Tables[0].Rows[0][TypeField].ShouldBe(3),
                () => actualDataSetBulk.Tables[0].Rows[0][TimestampField].ShouldBe(DummyDateTimeNow),
                () => actualDataSetBulk.Tables[0].Rows[0][TimerJobGuidField].ShouldBe(DummyGuid),
                () => actualDataSetBulk.Tables[0].Rows[1][ListNameField].ShouldBe(DummyItemName2),
                () => actualDataSetBulk.Tables[0].Rows[1][ShortNameField].ShouldBe("Processed with errors."),
                () => actualDataSetBulk.Tables[0].Rows[1][LongMessageField].ShouldBe(DummyResultTextFailed),
                () => actualDataSetBulk.Tables[0].Rows[1][TimestampField].ShouldBe(DummyDateTimeNow),
                () => actualDataSetBulk.Tables[0].Rows[1][TypeField].ShouldBe(3),
                () => actualDataSetBulk.Tables[0].Rows[1][TimerJobGuidField].ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void InitializeResultsDT_ListNames1ItemRefreshAllTrue_ReturnsDataTable()
        {
            // Arrange
            InitRefreshLists();

            // Act
            var actualResult = _testObject.InitializeResultsDT(DummyItemName, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(3),
                () => actualResult.Rows[0][ListNameField].ShouldBe(DummyItemName),
                () => actualResult.Rows[1][ListNameField].ShouldBe("Work Hours"),
                () => actualResult.Rows[2][ListNameField].ShouldBe("Resources"));
        }

        [TestMethod]
        public void InitializeResultsDT_ListNames3ItemRefreshAllFalse_ReturnsDataTable()
        {
            // Arrange
            InitRefreshLists();

            // Act
            var actualResult = _testObject.InitializeResultsDT(DummyList3Items, false);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.Rows.Count.ShouldBe(3),
                () => actualResult.Rows[0][ListNameField].ShouldBe(DummyItemName),
                () => actualResult.Rows[1][ListNameField].ShouldBe(DummyItemName2),
                () => actualResult.Rows[2][ListNameField].ShouldBe(DummyItemName3));
        }

        private void InitRefreshLists()
        {
            var spWeb = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummySiteGuid
                }
            };

            ShimReportData.ConstructorGuid = (sender, guid) =>
            {
                var reportData = new ShimReportData(sender)
                {
                    GetListMappings = () =>
                    {
                        var dataTable = new DataTable();
                        dataTable.Columns.Add(ListNameField);

                        var row = dataTable.NewRow();
                        row[ListNameField] = DummyItemName;
                        dataTable.Rows.Add(row);

                        return dataTable;
                    }
                };
            };
            _testObject = new RefreshLists(spWeb, string.Empty);
            _privateObject = new PrivateObject(_testObject);
        }
    }
}