using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Microsoft.QualityTools.Testing.Fakes;
using Shouldly;
using System.Web.Fakes;
using System.Collections.Specialized.Fakes;
using System.Data.Fakes;
using Microsoft.SharePoint.Fakes;
using EPMLiveWebParts.Fakes;
using System.Xml.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using System.Data.SqlClient.Fakes;
using System.Data.SqlClient;
using EPMLiveWebParts.Utilities.Fakes;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using Microsoft.SharePoint;
using ReportFiltering.DomainServices.Fakes;
using ReportFiltering.DomainServices;
using EPMLiveWebParts.EpmCharting.DomainServices.Fakes;
using EPMLiveWebParts.EpmCharting.DomainModel.Fakes;
using EPMLiveWebParts.EpmCharting.Mappers.Fakes;
using EPMLiveWebParts.EpmCharting.DomainModel;

namespace EPMLiveWebParts.Tests.ChartControl
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public partial class EpmChartTests
    {
        private IDisposable _shimObject;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private EpmChart _epmChart;
        private bool _loggerInvoked;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private const double DummyDouble = 1;
        private const long DummyLong = 1;
        private const decimal DummyDecimal = 1;

        private const string LoadChartDataUsingSPSiteDataQuery = "LoadChartDataUsingSPSiteDataQuery";
        private const string GetSiteDataUsingSPSiteDataQuery = "GetSiteDataUsingSPSiteDataQuery";
        private const string AppendLookupQueryIfApplicable = "AppendLookupQueryIfApplicable";
        private const string IsLookupQuery = "IsLookupQuery";
        private const string ConvertEmptySiteQueryDataToNoValue = "ConvertEmptySiteQueryDataToNoValue";
        private const string ProcessSiteQueryData = "ProcessSiteQueryData";
        private const string AddXAxisColumnToChartDataTableIfDoesntExist = "AddXAxisColumnToChartDataTableIfDoesntExist";
        private const string AddZAxisRowToChartDataTable = "AddZAxisRowToChartDataTable";
        private const string GetZaxisFieldValue = "GetZaxisFieldValue";
        private const string GetXaxisFieldValue = "GetXaxisFieldValue";
        private const string GetFilterQuery = "GetFilterQuery";
        private const string TraceHeader = "TraceHeader";
        private const string AddChartSeries = "AddChartSeries";
        private const string BuildSeriesArrayForBubbleChart = "BuildSeriesArrayForBubbleChart";
        private const string SeriesExistsInChartDataTable = "SeriesExistsInChartDataTable";
        private const string AddNewRowToChartDataTable = "AddNewRowToChartDataTable";
        private const string GetFieldSchemaAttribValue = "GetFieldSchemaAttribValue";
        private const string GetCleanNumberValue = "GetCleanNumberValue";
        private const string UpdateCellValue = "UpdateCellValue";
        private const string BuildSeriesArray = "BuildSeriesArray";
        private const string GetBubbleChartColumnMappings = "GetBubbleChartColumnMappings";
        private const string DataBindChart = "DataBindChart";

        [TestInitialize]
        public void TestInitialize()
        {
            _loggerInvoked = false;
            _shimObject = ShimsContext.Create();
            Setup();

            _epmChart = new EpmChart();
            var objEpmChart = new EpmChart(new ShimHttpRequest().Instance);
            _privateObject = new PrivateObject(_epmChart);
            _privateType = new PrivateType(typeof(EpmChart));
            InitializeSetup();
        }

        private void InitializeSetup()
        {
            ShimDataTable.ConstructorString = (_, _1) => new ShimDataTable();
            ShimDataTable.AllInstances.ColumnsGet = _ => new ShimDataColumnCollection();
            ShimDataColumnCollection.AllInstances.ItemGetString = (_, _1) => new ShimDataColumn();
            ShimDataColumnCollection.AllInstances.AddString = (_, _1) => new ShimDataColumn();
            ShimDataColumnCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataColumn();
            ShimDataColumn.AllInstances.ColumnNameGet = _ => DummyString;
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPList.AllInstances.ViewsGet = _ => new ShimSPViewCollection();
            ShimSPViewCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPView();
            ShimXmlDocument.Constructor = _ => new ShimXmlDocument();
            ShimSPView.AllInstances.QueryGet = _ => DummyString;
            ShimXmlDocument.AllInstances.LoadXmlString = (_, _1) => { };
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, _1) => new ShimXmlNode(new ShimXmlElement());
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlDocument();
            ShimXmlNode.AllInstances.RemoveChildXmlNode = (_,_1) => new ShimXmlNode(new ShimXmlElement());
            ShimSPQuery.Constructor = _ => new ShimSPQuery();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPSite.ConstructorString = (_, _1) => new ShimSPSite();
            ShimSPWeb.AllInstances.UrlGet = _ => DummyString;
            ShimSPSite.AllInstances.ContentDatabaseGet = _ => new ShimSPContentDatabase();
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;
            ShimSqlConnection.ConstructorString = (_, _1) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyString;
            ShimSPList.AllInstances.TitleGet = _ => DummyString;
            ShimSPSiteDataQuery.Constructor = _ => new ShimSPSiteDataQuery();
            ShimSPQuery.AllInstances.QueryGet = _ => DummyString;
            ShimDataTable.ConstructorString = (_, _1) => new ShimDataTable();
            ShimSPWeb.AllInstances.GetSiteDataSPSiteDataQuery = (_, _1) => new ShimDataTable();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimXmlNode.AllInstances.OuterXmlGet = _ => DummyString;
            ShimSPField.AllInstances.GetFieldValueAsTextObject = (_, _1) => DummyString;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, _1, _2) => new ShimSqlCommand();
            ShimSqlCommand.AllInstances.ParametersGet = _ => new ShimSqlParameterCollection()
            {
                AddWithValueStringObject = (_1, _2) => new SqlParameter()
                {
                    Value = new object()
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Close = _ => { };

            _privateObject.GetFieldOrProperty("PropChartTitleFontSize");
            _privateObject.SetFieldOrProperty("PropChartTitleFontSize", DummyInt);
            _privateObject.GetFieldOrProperty("PropChartXaxisLabelFontSize");
            _privateObject.SetFieldOrProperty("PropChartXaxisLabelFontSize", DummyInt);
            _privateObject.GetFieldOrProperty("PropChartZaxisLabelRotationAngle");
            _privateObject.SetFieldOrProperty("PropChartZaxisLabelRotationAngle", DummyInt);
            _privateObject.GetFieldOrProperty("PropChartSeriesDataPointLabelFontSize");
            _privateObject.SetFieldOrProperty("PropChartSeriesDataPointLabelFontSize", DummyInt);
            _privateObject.GetFieldOrProperty("PropChartLegendFontSize");
            _privateObject.SetFieldOrProperty("PropChartLegendFontSize", DummyInt);
            _privateObject.GetFieldOrProperty("PropChartLegendFontSize");
            _privateObject.SetFieldOrProperty("PropChartLegendFontSize", DummyInt);
            _privateObject.SetFieldOrProperty("oTopQuery", new ShimSPQuery().Instance);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        [TestMethod]
        public void LoadChartDataUsingSPSiteDataQuery_InputIsNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ShimVfChart.AllInstances.PropChartSelectedListGet = _ => DummyString;
            ShimVfChart.AllInstances.PropChartSelectedViewGet = _ => DummyString;
            ShimVfChart.AllInstances.PropChartRollupSitesGet = _ => "dummystring";
            ShimDataColumnCollection.AllInstances.ItemGetString = (_, _1) => null;
            ShimEpmChart.AllInstances.GetFilterQuerySPListXmlDocument = (_, _1, _2) => DummyString;
            ShimEpmChart.AllInstances.GetSiteDataUsingSPSiteDataQuerySPWeb = (_, _1) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                LoadChartDataUsingSPSiteDataQuery,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetSiteDataUsingSPSiteDataQuery_SPWebIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance };
            ShimVfChart.AllInstances.PropChartRollupListsGet = _ => string.Empty;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => "bubble";
            ShimEpmChart.AllInstances.AppendLookupQueryIfApplicableSPSiteDataQuery = (_, _1) => { };
            ShimEpmChart.AllInstances.ConvertEmptySiteQueryDataToNoValue = _ => { };
            ShimEpmChart.AllInstances.ProcessSiteQueryDataString = (_, _1) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                GetSiteDataUsingSPSiteDataQuery,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetSiteDataUsingSPSiteDataQuery_SPWebIsNotNullChartRollUpIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance };
            ShimVfChart.AllInstances.PropChartRollupListsGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => DummyString;
            ShimEpmChart.AllInstances.AppendLookupQueryIfApplicableSPSiteDataQuery = (_, _1) => { };
            ShimEpmChart.AllInstances.ConvertEmptySiteQueryDataToNoValue = _ => { };
            ShimEpmChart.AllInstances.ProcessSiteQueryDataString = (_, _1) => { };
            var count = 0;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                count++;
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            // Act
            var actualResult = _privateObject.Invoke(
                GetSiteDataUsingSPSiteDataQuery,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetSiteDataUsingSPSiteDataQuery_SPWebIsNotNullSiteUrlIsNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance };
            ShimVfChart.AllInstances.PropChartRollupListsGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => DummyString;
            ShimEpmChart.AllInstances.AppendLookupQueryIfApplicableSPSiteDataQuery = (_, _1) => { };
            ShimEpmChart.AllInstances.ConvertEmptySiteQueryDataToNoValue = _ => { };
            ShimEpmChart.AllInstances.ProcessSiteQueryDataString = (_, _1) => { };
            var count = 0;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                count++;
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => "a";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";

            // Act
            var actualResult = _privateObject.Invoke(
                GetSiteDataUsingSPSiteDataQuery,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AppendLookupQueryIfApplicable_SPSiteDataQueryIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPSiteDataQuery().Instance };
            ShimVfChart.AllInstances.ChartLookupFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.ChartLookupFieldListGet = _ => DummyString;
            ShimLookupFilterHelper.AppendLookupQueryToExistingQueryXmlDocumentRefStringString =
                (ref XmlDocument xmlQuery, string lookupField, string lookupFieldList) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                AppendLookupQueryIfApplicable,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void IsLookupQuery_InputIsNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { };
            ShimVfChart.AllInstances.ChartLookupFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.ChartLookupFieldListGet = _ => DummyString;

            // Act
            var actualResult = (bool)_privateObject.Invoke(
                IsLookupQuery,
                parameters);

            // Assert
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void ConvertEmptySiteQueryDataToNoValue_InputIsNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            _privateObject.SetFieldOrProperty("dtSPSiteDataQueryData", new ShimDataTable().Instance);
            var listDataRow = new List<DataRow>() { new ShimDataRow() };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection().Bind(listDataRow);
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataRow();
            ShimDataRow.AllInstances.ItemGetInt32 = (_, _1) => string.Empty;

            // Act
            var actualResult = _privateObject.Invoke(
                ConvertEmptySiteQueryDataToNoValue,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        private void ProcessSiteQueryDataSetup()
        {
            ShimVfChart.AllInstances.PropChartXaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimEpmChart.AllInstances.AddZAxisRowToChartDataTableInt32SPField = (_, _1, _2) => { };
            _privateObject.SetFieldOrProperty("dtSPSiteDataQueryData", new ShimDataTable().Instance);
            var listDataRow = new List<DataRow>() { new ShimDataRow() };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection().Bind(listDataRow);
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataRow();
            ShimDataRow.AllInstances.ItemGetInt32 = (_, _1) => DummyString;

            _privateObject.SetFieldOrProperty("oTopList", new ShimSPList().Instance);
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimEpmChart.AllInstances.GetXaxisFieldValueStringSPFieldInt32DataRow = (_, _1, _2, _3, _4) => DummyString;
            ShimEpmChart.AllInstances.GetZaxisFieldValueStringSPFieldInt32DataRow = (_, _1, _2, _3, _4) => DummyString;
            ShimEpmChart.AllInstances.AddXAxisColumnToChartDataTableIfDoesntExistString = (_, _1) => { };
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsCountIsTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "COUNT";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsCountIsFalse_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "COUNT";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsCountAndIsListMatch_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "COUNT";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimSPField.AllInstances.InternalNameGet = _ => "list";
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsCountAndIsListNotMatch_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "COUNT";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgIsTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            
            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgIsFalse_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgCounterIsSixAndIsTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 6;
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgCounterIsSixAndIsFalse_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 6;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgCounterIsOneAndIsFalse_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => DummyInt;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgCounterIsOneAndIsTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => DummyInt;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgCounterIsOneSPFieldIsNullAndIsFalse_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => DummyInt;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => null;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgCounterIsOneSPFieldIsNullAndIsTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => DummyInt;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => null;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvg_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 5;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString, DummyString, DummyString, DummyString, DummyString + ";#" };
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (_, _1) => "TRUE";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgSeriesIsFalse_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 5;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString, DummyString, DummyString, DummyString, DummyString + ";#" };
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (_, _1) => "TRUE";

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgValueSelected_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 6;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString, DummyString, DummyString, DummyString, DummyString, DummyString + ";#" };
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (_, _1) => "TRUE";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgValueSelectedIsFalse_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 6;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString, DummyString, DummyString, DummyString, DummyString, DummyString + ";#" };
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (_, _1) => "TRUE";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgValueSelectedIsFalseBubbleChartTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 6;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString, DummyString, DummyString, DummyString, DummyString + ";#", DummyString + ";#" };
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (_, _1) => "TRUE";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => "bubble";

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgValueSelectedIsTrueBubbleChartTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 6;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString, DummyString, DummyString, DummyString, DummyString + ";#", DummyString + ";#" };
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (_, _1) => "TRUE";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => true;
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => "bubble";

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgValueSelectedIsTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 6;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString, DummyString, DummyString, DummyString, DummyString + ";#", DummyString + ";#" };
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (_, _1) => "TRUE";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => true;
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => "bubble";

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ProcessSiteQueryData_ListNameIsNotNullAggregationTypeIsAvgValueSelectedIsFalseAndBubbleisTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ProcessSiteQueryDataSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "AVG";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimVfChart.AllInstances.GetYFields = _ => new string[] { DummyString };
            ShimInternalDataCollectionBase.AllInstances.CountGet = _ => 6;
            ShimDataColumn.AllInstances.ColumnNameGet = _ => "list";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            ShimEpmChart.AllInstances.UpdateCellValueStringStringStringString = (_, _1, _2, _3, _4) => true;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString, DummyString, DummyString, DummyString, DummyString + ";#", DummyString + ";#" };
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;
            ShimEpmChart.GetFieldSchemaAttribValueStringString = (_, _1) => "TRUE";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => "bubble";

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessSiteQueryData,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddXAxisColumnToChartDataTableIfDoesntExist_XAxisFieldValueIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataColumnCollection.AllInstances.ItemGetString = (_, _1) => null;
            
            // Act
            var actualResult = _privateObject.Invoke(
                AddXAxisColumnToChartDataTableIfDoesntExist,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddZAxisRowToChartDataTable_SPFieldAndCOlumnIndexIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyInt, new ShimSPField().Instance };
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "COUNT";
            ShimSPField.AllInstances.InternalNameGet = _ => "LIST";
            ShimEpmChart.AllInstances.SeriesExistsInChartDataTableString = (_, _1) => false;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                AddZAxisRowToChartDataTable,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddZAxisRowToChartDataTable_SPFieldAndCOlumnIndexIsNotNullInternalNameNotMatched_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { DummyInt, new ShimSPField().Instance };
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "COUNT";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimEpmChart.AllInstances.AddNewRowToChartDataTableString = (_, _1) => true;
            _privateObject.SetFieldOrProperty("dtSPSiteDataQueryData", new ShimDataTable().Instance);


            // Act
            var actualResult = _privateObject.Invoke(
                AddZAxisRowToChartDataTable,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetZaxisFieldValue_SPFieldAndDataRowIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPField().Instance, 0, new ShimDataRow().Instance };
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString };
            ShimSPField.AllInstances.InternalNameGet = _ => "LIST";

            // Act
            var actualResult = _privateObject.Invoke(
                GetZaxisFieldValue,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetZaxisFieldValue_SPFieldAndDataRowIsNotNullInternalNameNotMatched_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPField().Instance, 0, new ShimDataRow().Instance };
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString + ";#" };
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => "bubble";
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;

            // Act
            var actualResult = _privateObject.Invoke(
                GetZaxisFieldValue,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyDouble.ToString());
        }

        [TestMethod]
        public void GetXaxisFieldValue_SPFieldAndDataRowIsNotNullInternalNameNotMatched_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString + ";#", new ShimSPField().Instance, 0, new ShimDataRow().Instance };
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString  };
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => "bubble";
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;
            ShimSPField.AllInstances.GetFieldValueForEditObject = (_, _1) => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetXaxisFieldValue,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetXaxisFieldValue_SPFieldAndDataRowIsNotNullInternalNameMatched_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString + ";#", new ShimSPField().Instance, 0, new ShimDataRow().Instance };
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString };
            ShimSPField.AllInstances.InternalNameGet = _ => "LIST";
            ShimVfChart.AllInstances.PropChartMainStyleSafeGet = _ => "bubble";
            ShimEpmChart.AllInstances.GetCleanNumberValueString = (_, _1) => DummyDouble;

            // Act
            var actualResult = _privateObject.Invoke(
                GetXaxisFieldValue,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyDouble.ToString());
        }

        [TestMethod]
        public void GetFilterQuery_SPListAndXMlDocument_ReturnString()
        {
            // Arrange
            var parameters = new object[] { new ShimSPList().Instance, new ShimXmlDocument().Instance };
            ShimTitleFilterQueryService.Constructor = _ => new ShimTitleFilterQueryService();
            ShimTitleFilterQueryService.AllInstances.MergeExistingQueryWithTitleQuerySPListGuidXmlDocumentRef =
                (TitleFilterQueryService obj, SPList list, Guid reportWebPartId, ref XmlDocument xmlDocContainingQueryXml) => { };
            ShimXmlDocument.AllInstances.InnerXmlGet = _ => DummyString;
            _privateObject.SetFieldOrProperty("_reportFilterGuid", Guid.NewGuid());

            // Act
            var actualResult = _privateObject.Invoke(
                GetFilterQuery,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetFieldSchemaAttribValue_StringSearchAndAttributeIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString + "=t" + "\"" + DummyString, DummyString };
           
            // Act
            var actualResult = _privateType.InvokeStatic(
                GetFieldSchemaAttribValue,
                parameters);

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void AddNewRowToChartDataTable_ColValueIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.NewRow = _ => new ShimDataRow();
            ShimDataRowCollection.AllInstances.AddDataRow = (_, _1) => new ShimDataRow();
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();

            // Act
            var actualResult = _privateObject.Invoke(
                AddNewRowToChartDataTable,
                parameters);

            // Assert
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void SeriesExistsInChartDataTable_SeriesNameIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.SelectString = (_, _1) => new DataRow[] { new ShimDataRow() };

            // Act
            var actualResult = _privateObject.Invoke(
                SeriesExistsInChartDataTable,
                parameters);

            // Assert
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void GetCleanNumberValue_ToStringIsNotNull_ReturnDouble()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimChartHelper.ParseDoubleStringIFormatProviderEpmChartAggregateType = (_, _1, _2) => DummyDouble;

            // Act
            var actualResult = _privateObject.Invoke(
                GetCleanNumberValue,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyDouble);
        }

        [TestMethod]
        public void BuildSeriesArrayForBubbleChart_InputIsNull_ReturnListOfVfChartSeries()
        {
            // Arrange
            var parameters = new object[] { };
            ShimEpmChartAggregateType.Constructor = _ => new ShimEpmChartAggregateType();
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.PropBubbleChartColorFieldGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimEpmChartDataSeriesList.ConstructorDataTableEpmChartAggregateTypeSPFieldSPFieldSPFieldBooleanBooleanBubbleChartAxisToColumnMapping =
                (_, _1, _2, _3, _4, _5, _6, _7, _8) => new ShimEpmChartDataSeriesList();
            ShimEpmChartSeriesToVisifireChartSeriesMapper.GetVisifireChartSeriesEpmChartDataSeriesList = _ => new List<VfChartSeries>()
            {
                new ShimVfChartSeries()
                {
                    FormatGet = () => DummyString,
                    SeriesNameGet = () => DummyString
                }
            };

            // Act
            var actualResult = (List<VfChartSeries>)_privateObject.Invoke(
                BuildSeriesArrayForBubbleChart,
                parameters);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNull(DummyString),
                () => actualResult.Count.ShouldBe(DummyInt),
                () => actualResult[0].Format.ShouldBe(DummyString),
                () => actualResult[0].SeriesName.ShouldBe(DummyString));
        }

        [TestMethod]
        public void AddChartSeries_SeriesNameAndAgreegateTypeAreNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString, DummyInt, DummyInt, true, true };
            ShimEpmChart.AllInstances.BuildSeriesArrayStringString = (_, _1, _2) => new ShimVfChartSeries();
            ShimVfChart.AllInstances.SeriesGet = _ => new List<VfChartSeries>() { };

            // Act
            var actualResult = _privateObject.Invoke(
                AddChartSeries,
                parameters);

            // Assert
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void TraceHeader_InputIsNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection().Bind(new List<DataRow>() { new ShimDataRow() });
            ShimDataTable.AllInstances.ColumnsGet = _ => new ShimDataColumnCollection().Bind(new List<DataRow>() { new ShimDataRow() });
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                TraceHeader,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void TraceHeader_InputIsNullChartDataTableIsNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            _privateObject.SetFieldOrProperty("ChartDataTable", null);

            // Act
            var actualResult = _privateObject.Invoke(
                TraceHeader,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        private void DataBindChartSetup()
        {
            ShimEpmChart.AllInstances.LoadChartDataUsingSPSiteDataQuery = _ => { };
            ShimEpmChart.AllInstances.TraceHeader = _ => { };
            _privateObject.SetFieldOrProperty("_numberOfColumnsInChartDataTable", 2);
            _privateObject.SetFieldOrProperty("_numberOfRowsInChartDataTable", 2);
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.ColumnsGet = _ => new ShimDataColumnCollection().Bind(new List<DataColumn>() { new ShimDataColumn() });
            ShimDataTable.AllInstances.DefaultViewGet = _ => new ShimDataView();
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection().Bind(new List<DataRow>() { new ShimDataRow() });
            ShimDataView.AllInstances.ToTable = _ => new ShimDataTable().Instance;
            ShimDataRow.AllInstances.ItemGetString = (_, _1) => DummyString;
        }

        [TestMethod]
        public void DataBindChart_InputIsNullValueIsCountAndNotMatched_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            DataBindChartSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "count";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimEpmChart.AllInstances.AddChartSeriesStringStringInt32Int32BooleanBoolean = (_, _1, _2, _3, _4, _5, _6) => true;
            
            // Act
            var actualResult = _privateObject.Invoke(
                DataBindChart,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void DataBindChart_InputIsNullValueIsCountAndIsMatched_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            DataBindChartSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "count";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimEpmChart.AllInstances.AddChartSeriesStringStringInt32Int32BooleanBoolean = (_, _1, _2, _3, _4, _5, _6) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                DataBindChart,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void DataBindChart_InputIsNullValueIsAvgAndNotMatched_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            DataBindChartSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "avg";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimEpmChart.AllInstances.AddChartSeriesStringStringInt32Int32BooleanBoolean = (_, _1, _2, _3, _4, _5, _6) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                DataBindChart,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void DataBindChart_InputIsNullValueIsAvgAndIsMatched_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            DataBindChartSetup();
            ShimVfChart.AllInstances.PropChartAggregationTypeGet = _ => "avg";
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => "None Selected";
            ShimEpmChart.AllInstances.AddChartSeriesStringStringInt32Int32BooleanBoolean = (_, _1, _2, _3, _4, _5, _6) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                DataBindChart,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void DataBindChart_InputIsNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { };
            ShimEpmChart.AllInstances.LoadChartDataUsingSPSiteDataQuery = _ => { };
            ShimEpmChart.AllInstances.TraceHeader = _ => { };
            _privateObject.SetFieldOrProperty("_numberOfColumnsInChartDataTable", 0);
            _privateObject.SetFieldOrProperty("_numberOfRowsInChartDataTable", 0);

            // Act
            var actualResult = _privateObject.Invoke(
                DataBindChart,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetBubbleChartColumnMappings_InputIsNull_ReturnBubbleChartAxisToColumnMapping()
        {
            // Arrange
            var parameters = new object[] { };
            ShimVfChart.AllInstances.PropChartYaxisFieldGet = _ => DummyString + 1;
            ShimVfChart.AllInstances.PropChartXaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.PropBubbleChartColorFieldGet = _ => DummyString;

            // Act
            var actualResult = (BubbleChartAxisToColumnMapping)_privateObject.Invoke(
                GetBubbleChartColumnMappings,
                parameters);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.XaxisColumnIndex.ShouldBe(0),
                () => actualResult.YaxisColumnIndex.ShouldBe(DummyInt),
                () => actualResult.ZaxisColorColumnIndex.ShouldBe(0),
                () => actualResult.ZaxisColumnIndex.ShouldBe(0));
        }

        [TestMethod]
        public void GetBubbleChartColumnMappings_InputIsNullValueMatched_ReturnBubbleChartAxisToColumnMapping()
        {
            // Arrange
            var parameters = new object[] { };
            ShimVfChart.AllInstances.PropChartYaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.PropChartXaxisFieldGet = _ => DummyString + 1;
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString;
            ShimVfChart.AllInstances.PropBubbleChartColorFieldGet = _ => DummyString;

            // Act
            var actualResult = (BubbleChartAxisToColumnMapping)_privateObject.Invoke(
                GetBubbleChartColumnMappings,
                parameters);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.XaxisColumnIndex.ShouldBe(0),
                () => actualResult.YaxisColumnIndex.ShouldBe(DummyInt),
                () => actualResult.ZaxisColorColumnIndex.ShouldBe(DummyInt),
                () => actualResult.ZaxisColumnIndex.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void GetBubbleChartColumnMappings_InputIsNullValueMatchedAndCoverElsePart_ReturnBubbleChartAxisToColumnMapping()
        {
            // Arrange
            var parameters = new object[] { };
            ShimVfChart.AllInstances.PropChartYaxisFieldGet = _ => DummyString + 1;
            ShimVfChart.AllInstances.PropChartXaxisFieldGet = _ => DummyString + 2;
            ShimVfChart.AllInstances.PropChartZaxisFieldGet = _ => DummyString + 3;
            ShimVfChart.AllInstances.PropBubbleChartColorFieldGet = _ => DummyString;

            // Act
            var actualResult = (BubbleChartAxisToColumnMapping)_privateObject.Invoke(
                GetBubbleChartColumnMappings,
                parameters);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.XaxisColumnIndex.ShouldBe(0),
                () => actualResult.YaxisColumnIndex.ShouldBe(DummyInt),
                () => actualResult.ZaxisColorColumnIndex.ShouldBe(3),
                () => actualResult.ZaxisColumnIndex.ShouldBe(2));
        }

        [TestMethod]
        public void BuildSeriesArray_SeriesNameAndAggregatedTypeNameIsNotNull_VfChartSeries()
        {
            // Arrange
            var parameters = new object[] { DummyString, "AVG" };
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.SelectString = (_, _1) => new DataRow[] { new ShimDataRow() };
            ShimVfChartSeries.ConstructorString = (_, _1) => new ShimVfChartSeries();
            ShimDataRow.AllInstances.ItemGetInt32 = (_, _1) => DummyDouble.ToString();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyDouble.ToString(), DummyDouble.ToString() };
            ShimVfChartSeries.AllInstances.AddItemStringDoubleDouble = (_, _1, _2, _3) => { };

            // Act
            var actualResult = (VfChartSeries)_privateObject.Invoke(
                BuildSeriesArray,
                parameters);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult. Count.ShouldBe(0),
                () => actualResult.Format.ShouldBeNull());
        }

        [TestMethod]
        public void BuildSeriesArray_SeriesNameAndAggregatedTypeNameIsNotNullTypeNotMatched_VfChartSeries()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.SelectString = (_, _1) => new DataRow[] { new ShimDataRow() };
            ShimVfChartSeries.ConstructorString = (_, _1) => new ShimVfChartSeries();
            ShimDataRow.AllInstances.ItemGetInt32 = (_, _1) => DummyDouble.ToString();
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyDouble.ToString(), DummyDouble.ToString() };
            ShimVfChartSeries.AllInstances.AddItemStringDoubleDouble = (_, _1, _2, _3) => { };

            // Act
            var actualResult = (VfChartSeries)_privateObject.Invoke(
                BuildSeriesArray,
                parameters);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(0),
                () => actualResult.Format.ShouldBeNull());
        }

        [TestMethod]
        public void BuildSeriesArray_SeriesNameAndAggregatedTypeNameIsNotNullTypeNotMatchedValuesAreNull_VfChartSeries()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.SelectString = (_, _1) => new DataRow[] { new ShimDataRow() };
            ShimVfChartSeries.ConstructorString = (_, _1) => new ShimVfChartSeries();
            ShimDataRow.AllInstances.ItemGetInt32 = (_, _1) => string.Empty;
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyDouble.ToString(), DummyDouble.ToString() };
            ShimVfChartSeries.AllInstances.AddItemStringDoubleDouble = (_, _1, _2, _3) => { };

            // Act
            var actualResult = (VfChartSeries)_privateObject.Invoke(
                BuildSeriesArray,
                parameters);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(0),
                () => actualResult.Format.ShouldBeNull());
        }

        [TestMethod]
        public void BuildSeriesArray_SeriesNameAndAggregatedTypeNameIsNotNullValuesAreNull_VfChartSeries()
        {
            // Arrange
            var parameters = new object[] { DummyString, "AVG" };
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.SelectString = (_, _1) => new DataRow[] { new ShimDataRow() };
            ShimVfChartSeries.ConstructorString = (_, _1) => new ShimVfChartSeries();
            ShimDataRow.AllInstances.ItemGetInt32 = (_, _1) => string.Empty;
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyDouble.ToString(), DummyDouble.ToString() };
            ShimVfChartSeries.AllInstances.AddItemStringDoubleDouble = (_, _1, _2, _3) => { };

            // Act
            var actualResult = (VfChartSeries)_privateObject.Invoke(
                BuildSeriesArray,
                parameters);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.Count.ShouldBe(0),
                () => actualResult.Format.ShouldBeNull());
        }

        private void UpdateCellValueSetup()
        {
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.SelectString = (_, _1) => new DataRow[] { new ShimDataRow() };
            ShimDataRow.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataRow();
            ShimDataRow.AllInstances.ItemGetString = (_, _1) => DummyDouble;
            ShimDataRow.AllInstances.ItemArrayGet = _ => new string[] { DummyDouble.ToString(), DummyDouble.ToString() };
        }

        [TestMethod]
        public void UpdateCellValue_RowAndColumnNameAreNotNullAndValueIsCount_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString, DummyString + "%", "COUNT" };
            UpdateCellValueSetup();

            // Act
            var actualResult = (bool)_privateObject.Invoke(
                UpdateCellValue,
                parameters);

            // Assert
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void UpdateCellValue_RowAndColumnNameAreNotNullAndValueIsPct_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString, DummyString + "%", "PCT" };
            UpdateCellValueSetup();

            // Act
            var actualResult = (bool)_privateObject.Invoke(
                UpdateCellValue,
                parameters);

            // Assert
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void UpdateCellValue_RowAndColumnNameAreNotNullAndValueIsSum_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString, DummyDouble.ToString() + "%", "SUM" };
            UpdateCellValueSetup();

            // Act
            var actualResult = (bool)_privateObject.Invoke(
                UpdateCellValue,
                parameters);

            // Assert
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void UpdateCellValue_RowAndColumnNameAreNotNullAndValueIsAvg_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString, DummyString + "%", "AVG" };
            UpdateCellValueSetup();

            // Act
            var actualResult = (bool)_privateObject.Invoke(
                UpdateCellValue,
                parameters);

            // Assert
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void UpdateCellValue_RowAndColumnNameAreNotNullAndValueIsAvg_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString, DummyString, DummyString };
            _privateObject.SetFieldOrProperty("ChartDataTable", new ShimDataTable().Instance);
            ShimDataTable.AllInstances.SelectString = (_, _1) => null;

            // Act
            var actualResult = (bool)_privateObject.Invoke(
                UpdateCellValue,
                parameters);

            // Assert
            actualResult.ShouldBe(false);
        }

        private void Setup()
        {
            ShimHttpRequest.AllInstances.QueryStringGet = _ => new ShimNameValueCollection();
            ShimNameValueCollection.AllInstances.ItemGetString = (_, _1) => new Guid().ToString();
            ShimHttpRequest.AllInstances.ItemGetString = (_, _1) => "true";
        }
    }
}
